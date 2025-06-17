using System;
using UnityEngine;

namespace SABI
{
    public static class FloatExtenssions
    {
        public static float RandomBias(
            this float value,
            float range,
            bool useNegativeBias = true
        ) => (value + (value * UnityEngine.Random.Range(useNegativeBias ? -range : 0, range)));

        public static float Round(this float value, int digits = 0) =>
            (float)Math.Round(value, digits);

        public static bool IsApproximatelyEqual(
            this float value,
            float other,
            float tolerance = 0.0001f
        ) => Math.Abs(value - other) < tolerance;

        public static float ToPercentage(this float value, float total) => (value / total) * 100f;

        public static bool IsInRange(this float value, float minValue, float maxValue) =>
            value >= minValue && value <= maxValue;

        public static float ClosestInRange(this float value, float minValue, float maxValue)
        {
            if (value.IsInRange(minValue, maxValue))
                return value;

            float diffrenceToMinValue = Mathf.Abs(value - minValue);
            float diffrenceToMaxValue = Mathf.Abs(value - maxValue);

            return MathF.Min(diffrenceToMinValue, diffrenceToMaxValue);
        }

        public static float Max(this float value, float max) => value <= max ? value : max;

        public static float Min(this float value, float min) => value <= min ? min : value;

        public static float Clamp(this float value, float min, float max) =>
            Mathf.Clamp(value, min, max);

        public static float Lerp(this float current, float target, float t) =>
            Mathf.Lerp(current, target, Mathf.Clamp01(t));

        public static float LerpUnclamped(this float current, float target, float t) =>
            Mathf.LerpUnclamped(current, target, t);

        public static float MoveTowards(this float current, float target, float maxDelta) =>
            Mathf.MoveTowards(current, target, maxDelta);

        /// <summary>
        /// Remap a value from source range to targetRange.
        /// </summary>
        public static float Remap(
            this float value,
            float min1,
            float max1,
            float min2,
            float max2
        ) => min2 + (value - min1) * (max2 - min2) / (max1 - min1);

        public static bool Approximately(this float value, float other) =>
            Mathf.Approximately(value, other);

        // ---------------------------------------------------------------------------------------------
        // Summary:
        //     Returns the sine of angle f.
        //
        // Parameters:
        //   f:
        //     The input angle, in radians.
        //
        // Returns:
        //     The return value between -1 and +1.
        public static float Sin(this float f) => Mathf.Sin(f);

        //
        // Summary:
        //     Returns the cosine of angle f.
        //
        // Parameters:
        //   f:
        //     The input angle, in radians.
        //
        // Returns:
        //     The return value between -1 and 1.
        public static float Cos(this float f) => Mathf.Cos(f);

        //
        // Summary:
        //     Returns the tangent of angle f in radians.
        //
        // Parameters:
        //   f:
        public static float Tan(this float f) => Mathf.Tan(f);

        //
        // Summary:
        //     Returns the arc-sine of f - the angle in radians whose sine is f.
        //
        // Parameters:
        //   f:
        public static float Asin(this float f) => Mathf.Asin(f);

        //
        // Summary:
        //     Returns the arc-cosine of f - the angle in radians whose cosine is f.
        //
        // Parameters:
        //   f:
        public static float Acos(this float f) => Mathf.Acos(f);

        //
        // Summary:
        //     Returns the arc-tangent of f - the angle in radians whose tangent is f.
        //
        // Parameters:
        //   f:
        public static float Atan(this float f) => Mathf.Atan(f);

        //
        // Summary:
        //     Returns the angle in radians whose Tan is y/x.
        //
        // Parameters:
        //   y:
        //
        //   x:
        public static float Atan2(this float y, float x) => Mathf.Atan2(y, x);

        //
        // Summary:
        //     Returns square root of f.
        //
        // Parameters:
        //   f:
        public static float Sqrt(this float f) => Mathf.Sqrt(f);

        //
        // Summary:
        //     Returns the absolute value of f.
        //
        // Parameters:
        //   f:
        public static float Abs(this float f) => Mathf.Abs(f);

        //
        // Summary:
        //     Returns f raised to power p.
        //
        // Parameters:
        //   f:
        //
        //   p:
        public static float Pow(this float f, float x) => Mathf.Pow(f, x);

        //
        // Summary:
        //     Returns e raised to the specified power.
        //
        // Parameters:
        //   power:
        public static float Exp(this float power) => Mathf.Exp(power);

        //
        // Summary:
        //     Returns the natural (base e) logarithm of a specified number.
        //
        // Parameters:
        //   f:
        public static float Log(this float f) => Mathf.Log(f);

        //
        // Summary:
        //     Returns the logarithm of a specified number in a specified base.
        //
        // Parameters:
        //   f:
        //
        //   p:
        public static float Log(this float f, float p) => Mathf.Log(f, p);

        //
        // Summary:
        //     Returns the base 10 logarithm of a specified number.
        //
        // Parameters:
        //   f:
        public static float Log10(this float f) => Mathf.Log10(f);

        //
        // Summary:
        //     Returns the smallest integer greater than or equal to f.
        //
        // Parameters:
        //   f:
        public static float Ceil(this float f) => Mathf.Ceil(f);

        //
        // Summary:
        //     Returns the largest integer smaller than or equal to f.
        //
        // Parameters:
        //   f:
        public static float Floor(this float f) => Mathf.Floor(f);

        //
        // Summary:
        //     Returns f rounded to the nearest integer.
        //
        // Parameters:
        //   f:
        public static float Round(this float f) => Mathf.Round(f);

        //
        // Summary:
        //     Clamps value between 0 and 1 and returns value.
        //
        // Parameters:
        //   value:
        public static float Clamp01(this float f) => Mathf.Clamp01(f);

        //
        // Summary:
        //     Same as Lerp but makes sure the values interpolate correctly when they wrap around
        //     360 degrees.
        //
        // Parameters:
        //   a:
        //     The start angle. A float expressed in degrees.
        //
        //   b:
        //     The end angle. A float expressed in degrees.
        //
        //   t:
        //     The interpolation value between the start and end angles. This value is clamped
        //     to the range [0, 1].
        //
        // Returns:
        //     Returns the interpolated float result between angle a and angle b, based on the
        //     interpolation value t.
        public static float LerpAngle(this float current, float target, float time) =>
            Mathf.LerpAngle(current, target, time);

        //
        // Summary:
        //     Same as MoveTowards but makes sure the values interpolate correctly when they
        //     wrap around 360 degrees.
        //
        // Parameters:
        //   current:
        //
        //   target:
        //
        //   maxDelta:
        public static float MoveTowardsAngle(this float current, float target, float time) =>
            Mathf.MoveTowardsAngle(current, target, time);

        //
        // Summary:
        //     Interpolates between from and to with smoothing at the limits.
        //
        // Parameters:
        //   from:
        //     The start of the range.
        //
        //   to:
        //     The end of the range.
        //
        //   t:
        //     The interpolation value between the from and to range limits.
        //
        // Returns:
        //     The interpolated float result between from and to.
        public static float SmoothStep(this float from, float to, float time) =>
            Mathf.SmoothStep(from, to, time);

        public static float Gamma(this float value, float absmax, float gamma) =>
            Mathf.Gamma(value, absmax, gamma);

        //
        // Summary:
        //     Loops the value t, so that it is never larger than length and never smaller than
        //     0.
        //
        // Parameters:
        //   t:
        //
        //   length:
        public static float Repeat(this float t, float length) => Mathf.Repeat(t, length);

        //
        // Summary:
        //     PingPong returns a value that increments and decrements between zero and the
        //     length. It follows the triangle wave formula where the bottom is set to zero
        //     and the peak is set to length.
        //
        // Parameters:
        //   t:
        //
        //   length:        public static float PingPong(this float t, float length) => Mathf.PingPong(t, length);
        public static float PingPong(this float t, float length) => Mathf.PingPong(t, length);

        //
        // Summary:
        //     Determines where a value lies between two points.
        //
        // Parameters:
        //   a:
        //     The start of the range.
        //
        //   b:
        //     The end of the range.
        //
        //   value:
        //     The point within the range you want to calculate.
        //
        // Returns:
        //     A value between zero and one, representing where the "value" parameter falls
        //     within the range defined by a and b.
        public static float InverseLerp(this float a, float b, float value) =>
            Mathf.InverseLerp(a, b, value);

        public static int CeilToInt(this float f) => Mathf.CeilToInt(f);

        //
        // Summary:
        //     Returns the largest integer smaller to or equal to f.
        //
        // Parameters:
        //   f:
        public static int FloorToInt(this float f) => Mathf.FloorToInt(f);

        //
        // Summary:
        //     Returns f rounded to the nearest integer.
        //
        // Parameters:
        //   f:
        public static float RoundToInt(this float f) => Mathf.RoundToInt(f);
    }
}
