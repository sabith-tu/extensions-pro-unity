using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace SABI
{
    public static class NavMeshAgentExtensions
    {
        public static bool HasReachedDestination(this NavMeshAgent agent)
        {
            if (agent == null)
                return false;
            return !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance;
        }

        public static bool SetRandomDestination(
            this NavMeshAgent agent,
            float radius,
            Vector3? origin = null,
            int areaMask = NavMesh.AllAreas
        )
        {
            if (agent == null)
                return false;

            for (int i = 0; i < 10; i++)
            {
                Vector3 randomDirection = Random.insideUnitSphere * radius;
                randomDirection += origin ?? agent.transform.position;
                if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, radius, areaMask))
                {
                    agent.SetDestination(hit.position);
                    return true;
                }
            }

            return false;
        }

        public static NavMeshAgent SmoothSpeedChange(
            this NavMeshAgent agent,
            MonoBehaviour monobehaviour,
            float targetSpeed,
            float duration
        )
        {
            if (agent == null)
                return null;
            float startSpeed = agent.speed;
            float elapsedTime = 0f;
            monobehaviour.StartCoroutine(Routine());
            IEnumerator Routine()
            {
                while (elapsedTime < duration)
                {
                    agent.speed = Mathf.Lerp(startSpeed, targetSpeed, elapsedTime / duration);
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
                agent.speed = targetSpeed;
            }
            return agent;
        }

        // Commented becuase better one is available under

        /// <summary>
        /// Call it from a loop
        /// </summary>
        public static NavMeshAgent PatrolDestination(
            this NavMeshAgent agent,
            List<Vector3> patrolPath,
            float tolerance = 1f
        )
        {
            if (agent == null || patrolPath == null || patrolPath.Count == 0)
                return null;

            Vector3 currentWaypoint = patrolPath[0];
            if (Vector3.Distance(agent.transform.position, currentWaypoint) <= tolerance)
            {
                int nextIndex = (patrolPath.IndexOf(currentWaypoint) + 1) % patrolPath.Count;
                currentWaypoint = patrolPath[nextIndex];
            }

            agent.SetDestination(currentWaypoint);
            return agent;
        }

        /// <summary>
        /// Call it from a loop
        /// </summary>
        public static NavMeshAgent PatrolDestination(
            this NavMeshAgent agent,
            List<Transform> patrolPath,
            float tolerance = 1f
        )
        {
            if (agent == null || patrolPath == null || patrolPath.Count == 0)
                return null;

            Transform currentWaypoint = patrolPath[0];
            if (Vector3.Distance(agent.transform.position, currentWaypoint.position) <= tolerance)
            {
                int nextIndex = (patrolPath.IndexOf(currentWaypoint) + 1) % patrolPath.Count;
                currentWaypoint = patrolPath[nextIndex];
            }

            agent.SetDestination(currentWaypoint.position);
            return agent;
        }

        public static NavMeshAgent AddKnockBack(
            this NavMeshAgent agent,
            Transform target,
            float force
        )
        {
            agent.ResetPath();
            Vector3 selfPosition = agent.transform.position;
            Vector3 targetPosition = target.position;
            Vector3 knockBackDirection = target.position.WithY(0) - selfPosition.WithY(0);
            agent.SetDestination(selfPosition + knockBackDirection.normalized * force);
            return agent;
        }

        public static NavMeshAgent FollowInRange(
            this NavMeshAgent agent,
            Transform target,
            float minDistance,
            float maxDistance
        )
        {
            Vector3 selfPosition = agent.transform.position;
            Vector3 targetPosition = target.position;
            float distance = selfPosition.Distance(targetPosition);

            if (distance < minDistance)
            {
                Vector3 directionToMoveWhenTooCloseToPlayer = (
                    target.position - selfPosition
                ).normalized;
                Vector3 positionToMove =
                    selfPosition
                    + (directionToMoveWhenTooCloseToPlayer * -1 * (maxDistance - distance));
                NavMeshPath path = new NavMeshPath();
                if (agent.CalculatePath(positionToMove, path))
                    agent.SetDestination(positionToMove.WithY(selfPosition.y));
            }
            else
            {
                agent.SetDestination(target.position);
            }

            return agent;
        }

        public static NavMeshAgent SetTemporarySpeed(
            this NavMeshAgent agent,
            MonoBehaviour monoBehaviour,
            float temporarySpeed,
            float duration
        )
        {
            if (agent == null || !agent.isActiveAndEnabled)
                return null;
            monoBehaviour.StartCoroutine(TemporarySpeedCoroutine(agent, temporarySpeed, duration));

            IEnumerator TemporarySpeedCoroutine(
                NavMeshAgent agent,
                float temporarySpeed,
                float duration
            )
            {
                float originalSpeed = agent.speed;
                agent.speed = temporarySpeed;

                yield return new WaitForSeconds(duration);

                if (agent != null && agent.isActiveAndEnabled)
                {
                    agent.speed = originalSpeed;
                }
            }

            return agent;
        }

        public static NavMeshAgent ContinuesWanderWhile(
            this NavMeshAgent agent,
            Func<bool> condition,
            float radius,
            MonoBehaviour monoBehaviour,
            float waitTimeBeforeSwitchingDestination = 1,
            Action OnStartMoving = null,
            Action OnStopMoving = null
        )
        {
            if (agent == null || !agent.isActiveAndEnabled)
                return null;
            monoBehaviour.StartCoroutine(WanderCoroutine());

            IEnumerator WanderCoroutine()
            {
                while (agent != null && agent.isActiveAndEnabled && condition())
                {
                    if (agent.SetRandomDestination(radius))
                    {
                        OnStartMoving?.Invoke();
                        yield return new WaitUntil(() => agent.HasReachedDestination());
                    }
                    OnStopMoving?.Invoke();
                    yield return new WaitForSeconds(waitTimeBeforeSwitchingDestination);
                }
            }

            return agent;
        }

        public static NavMeshAgent ContinuesChaseTargetWhile(
            this NavMeshAgent agent,
            Func<bool> condition,
            Transform target,
            float chaseRange,
            MonoBehaviour monoBehaviour
        )
        {
            if (agent == null || !agent.isActiveAndEnabled || target == null)
                return null;
            monoBehaviour.StartCoroutine(ChaseTargetCoroutine());

            IEnumerator ChaseTargetCoroutine()
            {
                while (agent != null && agent.isActiveAndEnabled && target != null && condition())
                {
                    if (Vector3.Distance(agent.transform.position, target.position) <= chaseRange)
                    {
                        agent.SetDestination(target.position);
                    }
                    else
                    {
                        agent.ResetPath(); // Stop chasing if the target is out of range
                    }
                    yield return null;
                }
            }

            return agent;
        }

        public static NavMeshAgent ContinuesFleeFromTargetWhile(
            this NavMeshAgent agent,
            Func<bool> condition,
            Transform target,
            float fleeDistance,
            MonoBehaviour monoBehaviour
        )
        {
            if (agent == null || !agent.isActiveAndEnabled || target == null)
                return null;
            monoBehaviour.StartCoroutine(FleeFromTargetCoroutine());

            IEnumerator FleeFromTargetCoroutine()
            {
                while (agent != null && agent.isActiveAndEnabled && target != null && condition())
                {
                    Vector3 fleeDirection = (agent.transform.position - target.position).normalized;
                    Vector3 fleePosition = agent.transform.position + fleeDirection * fleeDistance;

                    if (
                        NavMesh.SamplePosition(
                            fleePosition,
                            out NavMeshHit hit,
                            fleeDistance,
                            NavMesh.AllAreas
                        )
                    )
                    {
                        agent.SetDestination(hit.position);
                    }
                    yield return null;
                }
            }

            return agent;
        }

        public static NavMeshAgent ContinuesPatrolWaypointsWhile(
            this NavMeshAgent agent,
            Func<bool> condition,
            List<Transform> waypoints,
            float tolerance,
            MonoBehaviour monoBehaviour,
            bool followWaypointOrder = true
        )
        {
            if (
                agent == null
                || !agent.isActiveAndEnabled
                || waypoints == null
                || waypoints.Count == 0
            )
                return null;
            monoBehaviour.StartCoroutine(PatrolWaypointsCoroutine());

            IEnumerator PatrolWaypointsCoroutine()
            {
                int currentWaypointIndex = 0;

                while (agent != null && agent.isActiveAndEnabled && condition())
                {
                    Transform currentWaypoint = waypoints[currentWaypointIndex];
                    agent.SetDestination(currentWaypoint.position);

                    yield return new WaitUntil(() => agent.HasReachedDestination());

                    currentWaypointIndex = followWaypointOrder
                        ? (currentWaypointIndex + 1) % waypoints.Count
                        : Random.Range(0, waypoints.Count);
                }
            }

            return agent;
        }

        public static NavMeshAgent ContinuesAvoidObstaclesWhile(
            this NavMeshAgent agent,
            Func<bool> condition,
            LayerMask obstacleMask,
            float avoidanceRadius,
            MonoBehaviour monoBehaviour
        )
        {
            if (agent == null || !agent.isActiveAndEnabled)
                return null;
            monoBehaviour.StartCoroutine(AvoidObstaclesCoroutine());

            IEnumerator AvoidObstaclesCoroutine()
            {
                while (agent != null && agent.isActiveAndEnabled && condition())
                {
                    Collider[] obstacles = Physics.OverlapSphere(
                        agent.transform.position,
                        avoidanceRadius,
                        obstacleMask
                    );
                    if (obstacles.Length > 0)
                    {
                        Vector3 avoidanceDirection = Vector3.zero;
                        foreach (Collider obstacle in obstacles)
                        {
                            avoidanceDirection += (
                                agent.transform.position - obstacle.transform.position
                            ).normalized;
                        }
                        avoidanceDirection /= obstacles.Length;

                        Vector3 newDestination =
                            agent.transform.position + avoidanceDirection * avoidanceRadius;
                        if (
                            NavMesh.SamplePosition(
                                newDestination,
                                out NavMeshHit hit,
                                avoidanceRadius,
                                NavMesh.AllAreas
                            )
                        )
                        {
                            agent.SetDestination(hit.position);
                        }
                    }
                    yield return null;
                }
            }

            return agent;
        }

        // public static void WaitAtDestination(this NavMeshAgent agent,Func<bool> condition, float waitTime, MonoBehaviour monoBehaviour)
        // {
        //     if (agent == null || !agent.isActiveAndEnabled) return;
        //     monoBehaviour.StartCoroutine(WaitAtDestinationCoroutine());
        //
        //     IEnumerator WaitAtDestinationCoroutine()
        //     {
        //         agent.isStopped = true;
        //         yield return new WaitForSeconds(waitTime);
        //         if (agent != null && agent.isActiveAndEnabled)
        //         {
        //             agent.isStopped = false;
        //         }
        //     }
        // }
    }
}
