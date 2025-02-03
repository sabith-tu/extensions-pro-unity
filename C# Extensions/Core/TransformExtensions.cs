using UnityEngine;

namespace SABI
{
    public static class TransformExtensions
    {
        public static Transform ResetValues(this Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
            return transform;
        }

        #region LocalEulerAngle
        public static Transform SetLocalEulerAngles(
            this Transform transform,
            float? x = null,
            float? y = null,
            float? z = null
        )
        {
            var eulerAngles = transform.localEulerAngles;

            if (x.HasValue)
            {
                eulerAngles.x = x.Value;
            }

            if (y.HasValue)
            {
                eulerAngles.y = y.Value;
            }

            if (z.HasValue)
            {
                eulerAngles.z = z.Value;
            }

            transform.localEulerAngles = eulerAngles;
            return transform;
        }

        public static Transform AddLocalEulerAngles(
            this Transform transform,
            float? x = null,
            float? y = null,
            float? z = null
        )
        {
            var eulerAngles = transform.localEulerAngles;

            if (x.HasValue)
            {
                eulerAngles.x += x.Value;
            }

            if (y.HasValue)
            {
                eulerAngles.y += y.Value;
            }

            if (z.HasValue)
            {
                eulerAngles.z += z.Value;
            }

            transform.localEulerAngles = eulerAngles;
            return transform;
        }

        public static Transform SubtractLocalEulerAngles(
            this Transform transform,
            float? x = null,
            float? y = null,
            float? z = null
        )
        {
            var eulerAngles = transform.localEulerAngles;

            if (x.HasValue)
            {
                eulerAngles.x -= x.Value;
            }

            if (y.HasValue)
            {
                eulerAngles.y -= y.Value;
            }

            if (z.HasValue)
            {
                eulerAngles.z -= z.Value;
            }

            transform.localEulerAngles = eulerAngles;
            return transform;
        }

        public static Transform SetLocalEulerAngleX(this Transform transform, float x)
        {
            transform.localEulerAngles = transform.localEulerAngles.WithX(x);
            return transform;
        }

        public static Transform SetLocalEulerAngleY(this Transform transform, float y)
        {
            transform.localEulerAngles = transform.localEulerAngles.WithY(y);
            return transform;
        }

        public static Transform SetLocalEulerAngleZ(this Transform transform, float z)
        {
            transform.localEulerAngles = transform.localEulerAngles.WithZ(z);
            return transform;
        }

        public static Transform AddLocalEulerAngleX(this Transform transform, float x)
        {
            transform.localEulerAngles = transform.localEulerAngles.WithAddX(x);
            return transform;
        }

        public static Transform AddLocalEulerAngleY(this Transform transform, float y)
        {
            transform.localEulerAngles = transform.localEulerAngles.WithAddY(y);
            return transform;
        }

        public static Transform AddLocalEulerAngleZ(this Transform transform, float z)
        {
            transform.localEulerAngles = transform.localEulerAngles.WithAddZ(z);
            return transform;
        }

        public static Transform SubtractLocalEulerAngleX(this Transform transform, float x)
        {
            transform.localEulerAngles = transform.localEulerAngles.WithSubtractX(x);
            return transform;
        }

        public static Transform SubtractLocalEulerAngleY(this Transform transform, float y)
        {
            transform.localEulerAngles = transform.localEulerAngles.WithSubtractY(y);
            return transform;
        }

        public static Transform SubtractLocalEulerAngleZ(this Transform transform, float z)
        {
            transform.localEulerAngles = transform.localEulerAngles.WithSubtractZ(z);
            return transform;
        }
        #endregion

        #region EulerAngle
        public static Transform SetEulerAngles(
            this Transform transform,
            float? x = null,
            float? y = null,
            float? z = null
        )
        {
            var eulerAngles = transform.eulerAngles;

            if (x.HasValue)
            {
                eulerAngles.x = x.Value;
            }

            if (y.HasValue)
            {
                eulerAngles.y = y.Value;
            }

            if (z.HasValue)
            {
                eulerAngles.z = z.Value;
            }

            transform.eulerAngles = eulerAngles;
            return transform;
        }

        public static Transform AddEulerAngles(
            this Transform transform,
            float? x = null,
            float? y = null,
            float? z = null
        )
        {
            var eulerAngles = transform.eulerAngles;

            if (x.HasValue)
            {
                eulerAngles.x += x.Value;
            }

            if (y.HasValue)
            {
                eulerAngles.y += y.Value;
            }

            if (z.HasValue)
            {
                eulerAngles.z += z.Value;
            }

            transform.eulerAngles = eulerAngles;
            return transform;
        }

        public static Transform SubtractEulerAngles(
            this Transform transform,
            float? x = null,
            float? y = null,
            float? z = null
        )
        {
            var eulerAngles = transform.eulerAngles;

            if (x.HasValue)
            {
                eulerAngles.x -= x.Value;
            }

            if (y.HasValue)
            {
                eulerAngles.y -= y.Value;
            }

            if (z.HasValue)
            {
                eulerAngles.z -= z.Value;
            }

            transform.eulerAngles = eulerAngles;
            return transform;
        }

        public static Transform SetEulerAngleX(this Transform transform, float x)
        {
            transform.eulerAngles = transform.eulerAngles.WithX(x);
            return transform;
        }

        public static Transform SetEulerAngleY(this Transform transform, float y)
        {
            transform.eulerAngles = transform.eulerAngles.WithY(y);
            return transform;
        }

        public static Transform SetEulerAngleZ(this Transform transform, float z)
        {
            transform.eulerAngles = transform.eulerAngles.WithZ(z);
            return transform;
        }

        public static Transform AddEulerAngleX(this Transform transform, float x)
        {
            transform.eulerAngles = transform.eulerAngles.WithAddX(x);
            return transform;
        }

        public static Transform AddEulerAngleY(this Transform transform, float y)
        {
            transform.eulerAngles = transform.eulerAngles.WithAddY(y);
            return transform;
        }

        public static Transform AddEulerAngleZ(this Transform transform, float z)
        {
            transform.eulerAngles = transform.eulerAngles.WithAddZ(z);
            return transform;
        }

        public static Transform SubtractEulerAngleX(this Transform transform, float x)
        {
            transform.eulerAngles = transform.eulerAngles.WithSubtractX(x);
            return transform;
        }

        public static Transform SubtractEulerAngleY(this Transform transform, float y)
        {
            transform.eulerAngles = transform.eulerAngles.WithSubtractY(y);
            return transform;
        }

        public static Transform SubtractEulerAngleZ(this Transform transform, float z)
        {
            transform.eulerAngles = transform.eulerAngles.WithSubtractZ(z);
            return transform;
        }
        #endregion

        #region Position

        public static Transform SetPosition(
            this Transform transform,
            float? x = null,
            float? y = null,
            float? z = null
        )
        {
            var position = transform.position;

            if (x.HasValue)
            {
                position.x = x.Value;
            }

            if (y.HasValue)
            {
                position.y = y.Value;
            }

            if (z.HasValue)
            {
                position.z = z.Value;
            }

            transform.position = position;
            return transform;
        }

        public static Transform AddPosition(
            this Transform transform,
            float? x = null,
            float? y = null,
            float? z = null
        )
        {
            var position = transform.position;

            if (x.HasValue)
            {
                position.x += x.Value;
            }

            if (y.HasValue)
            {
                position.y += y.Value;
            }

            if (z.HasValue)
            {
                position.z += z.Value;
            }

            transform.position = position;
            return transform;
        }

        public static Transform SubtractPosition(
            this Transform transform,
            float? x = null,
            float? y = null,
            float? z = null
        )
        {
            var position = transform.position;

            if (x.HasValue)
            {
                position.x -= x.Value;
            }

            if (y.HasValue)
            {
                position.y -= y.Value;
            }

            if (z.HasValue)
            {
                position.z -= z.Value;
            }

            transform.position = position;
            return transform;
        }

        public static Transform SetPositionX(this Transform transform, float x)
        {
            transform.position = transform.position.WithX(x);
            return transform;
        }

        public static Transform SetPositionY(this Transform transform, float y)
        {
            transform.position = transform.position.WithY(y);
            return transform;
        }

        public static Transform SetPositionZ(this Transform transform, float z)
        {
            transform.position = transform.position.WithZ(z);
            return transform;
        }

        public static Transform AddPositionX(this Transform transform, float x)
        {
            transform.position = transform.position.WithAddX(x);
            return transform;
        }

        public static Transform AddPositionY(this Transform transform, float y)
        {
            transform.position = transform.position.WithAddY(y);
            return transform;
        }

        public static Transform AddPositionZ(this Transform transform, float z)
        {
            transform.position = transform.position.WithAddZ(z);
            return transform;
        }

        public static Transform SubtractPositionX(this Transform transform, float x)
        {
            transform.position = transform.position.WithSubtractX(x);
            return transform;
        }

        public static Transform SubtractPositionY(this Transform transform, float y)
        {
            transform.position = transform.position.WithSubtractY(y);
            return transform;
        }

        public static Transform SubtractPositionZ(this Transform transform, float z)
        {
            transform.position = transform.position.WithSubtractZ(z);
            return transform;
        }

        #endregion

        #region LocalPosition
        public static Transform SetLocalPosition(
            this Transform transform,
            float? x = null,
            float? y = null,
            float? z = null
        )
        {
            var localPosition = transform.localPosition;

            if (x.HasValue)
            {
                localPosition.x = x.Value;
            }

            if (y.HasValue)
            {
                localPosition.y = y.Value;
            }

            if (z.HasValue)
            {
                localPosition.z = z.Value;
            }

            transform.localPosition = localPosition;
            return transform;
        }

        public static Transform AddLocalPosition(
            this Transform transform,
            float? x = null,
            float? y = null,
            float? z = null
        )
        {
            var localPosition = transform.localPosition;

            if (x.HasValue)
            {
                localPosition.x += x.Value;
            }

            if (y.HasValue)
            {
                localPosition.y += y.Value;
            }

            if (z.HasValue)
            {
                localPosition.z += z.Value;
            }

            transform.localPosition = localPosition;
            return transform;
        }

        public static Transform SubtractLocalPosition(
            this Transform transform,
            float? x = null,
            float? y = null,
            float? z = null
        )
        {
            var localPosition = transform.localPosition;

            if (x.HasValue)
            {
                localPosition.x -= x.Value;
            }

            if (y.HasValue)
            {
                localPosition.y -= y.Value;
            }

            if (z.HasValue)
            {
                localPosition.z -= z.Value;
            }

            transform.localPosition = localPosition;
            return transform;
        }

        public static Transform SetLocalPositionX(this Transform transform, float x)
        {
            transform.localPosition = transform.localPosition.WithX(x);
            return transform;
        }

        public static Transform SetLocalPositionY(this Transform transform, float y)
        {
            transform.localPosition = transform.localPosition.WithY(y);
            return transform;
        }

        public static Transform SetLocalPositionZ(this Transform transform, float z)
        {
            transform.localPosition = transform.localPosition.WithZ(z);
            return transform;
        }

        public static Transform AddLocalPositionX(this Transform transform, float x)
        {
            transform.localPosition = transform.localPosition.WithAddX(x);
            return transform;
        }

        public static Transform AddLocalPositionY(this Transform transform, float y)
        {
            transform.localPosition = transform.localPosition.WithAddY(y);
            return transform;
        }

        public static Transform AddLocalPositionZ(this Transform transform, float z)
        {
            transform.localPosition = transform.localPosition.WithAddZ(z);
            return transform;
        }

        public static Transform SubtractLocalPositionX(this Transform transform, float x)
        {
            transform.localPosition = transform.localPosition.WithSubtractX(x);
            return transform;
        }

        public static Transform SubtractLocalPositionY(this Transform transform, float y)
        {
            transform.localPosition = transform.localPosition.WithSubtractY(y);
            return transform;
        }

        public static Transform SubtractLocalPositionZ(this Transform transform, float z)
        {
            transform.localPosition = transform.localPosition.WithSubtractZ(z);
            return transform;
        }

        #endregion

        #region Scale

        public static Transform SetScale(
            this Transform transform,
            float? x = null,
            float? y = null,
            float? z = null
        )
        {
            var scale = transform.localScale;

            if (x.HasValue)
            {
                scale.x = x.Value;
            }

            if (y.HasValue)
            {
                scale.y = y.Value;
            }

            if (z.HasValue)
            {
                scale.z = z.Value;
            }

            transform.localScale = scale;
            return transform;
        }

        public static Transform AddScale(
            this Transform transform,
            float? x = null,
            float? y = null,
            float? z = null
        )
        {
            var scale = transform.localScale;

            if (x.HasValue)
            {
                scale.x += x.Value;
            }

            if (y.HasValue)
            {
                scale.y += y.Value;
            }

            if (z.HasValue)
            {
                scale.z += z.Value;
            }

            transform.localScale = scale;
            return transform;
        }

        public static Transform SubtractScale(
            this Transform transform,
            float? x = null,
            float? y = null,
            float? z = null
        )
        {
            var scale = transform.localScale;

            if (x.HasValue)
            {
                scale.x -= x.Value;
            }

            if (y.HasValue)
            {
                scale.y -= y.Value;
            }

            if (z.HasValue)
            {
                scale.z -= z.Value;
            }

            transform.localScale = scale;
            return transform;
        }

        public static Transform SetScale(this Transform transform, float UniformScaleValue)
        {
            return transform.SetScale(UniformScaleValue, UniformScaleValue, UniformScaleValue);
        }

        public static Transform AddScale(this Transform transform, float UniformScaleValue)
        {
            return transform.AddScale(UniformScaleValue, UniformScaleValue, UniformScaleValue);
        }

        public static Transform SubtractScale(this Transform transform, float UniformScaleValue)
        {
            return transform.SubtractScale(UniformScaleValue, UniformScaleValue, UniformScaleValue);
        }

        public static Transform SetScaleX(this Transform transform, float x)
        {
            transform.localScale = transform.localScale.WithX(x);
            return transform;
        }

        public static Transform SetScaleY(this Transform transform, float y)
        {
            transform.localScale = transform.localScale.WithY(y);
            return transform;
        }

        public static Transform SetScaleZ(this Transform transform, float z)
        {
            transform.localScale = transform.localScale.WithZ(z);
            return transform;
        }

        public static Transform AddScaleX(this Transform transform, float x)
        {
            transform.localScale = transform.localScale.WithAddX(x);
            return transform;
        }

        public static Transform AddScaleY(this Transform transform, float y)
        {
            transform.localScale = transform.localScale.WithAddY(y);
            return transform;
        }

        public static Transform AddScaleZ(this Transform transform, float z)
        {
            transform.localScale = transform.localScale.WithAddZ(z);
            return transform;
        }

        public static Transform SubtractScaleX(this Transform transform, float x)
        {
            transform.localScale = transform.localScale.WithSubtractX(x);
            return transform;
        }

        public static Transform SubtractScaleY(this Transform transform, float y)
        {
            transform.localScale = transform.localScale.WithSubtractY(y);
            return transform;
        }

        public static Transform SubtractScaleZ(this Transform transform, float z)
        {
            transform.localScale = transform.localScale.WithSubtractZ(z);
            return transform;
        }

        #endregion

        #region Children

        public static Transform DestroyChildren(this Transform transform)
        {
            foreach (Transform child in transform)
            {
                UnityEngine.Object.Destroy(child.gameObject);
            }
            return transform;
        }

        public static Transform DetachChildren(this Transform transform)
        {
            foreach (Transform child in transform)
            {
                child.SetParent(null);
            }
            return transform;
        }

        public static Transform GetRandomChild(this Transform transform) =>
            transform.GetChild(Random.Range(0, transform.childCount));
        #endregion



        #region Distance

        public static float Distance(this Transform transform, Transform target)
                 => Vector3.Distance(transform.position, target.position);

        public static float Distance(this Transform transform, Vector3 target)
        => Vector3.Distance(transform.position, target);

        #endregion

        #region Direction
        public static Vector3 DirectionTo(this Transform source, Transform target) => target.position - source.position;
        public static Vector3 DirectionFrom(this Transform target, Transform source) => source.position - target.position;
        public static Vector3 NormalizedDirectionTo(this Transform source, Transform target) => DirectionTo(source, target).normalized;
        public static Vector3 NormalizedDirectionFrom(this Transform target, Transform source) => DirectionFrom(target, source).normalized;
        #endregion
    }
}
