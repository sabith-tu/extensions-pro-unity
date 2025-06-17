using System;
using UnityEngine;

namespace SABI
{
    public static class IntExtensions
    {
        public static string ToAbbreviatedString(this int n, uint digits = 0)
        {
            string s;
            var nabs = Math.Abs(n);
            if (nabs < 1000)
                s = n + "";
            else if (nabs < 1000000)
                s = ((decimal)n / 1000).TruncateTo(digits) + "k";
            else if (nabs < 1000000000)
                s = ((decimal)n / 1000000).TruncateTo(digits) + "m";
            else
                s = ((decimal)n / 1000000000).TruncateTo(digits) + "g";

            return s;
        }

        public static int RoundToMultipleOf(this int n, int binSize)
        {
            var result = (n / binSize) * binSize;
            if (n < 0)
            {
                result -= binSize;
            }
            return result;
        }

        public static bool IsInRange(this int value, int minValue, int maxValue) =>
            value >= minValue && value <= maxValue;

        public static int ClosestInRange(this int value, int minValue, int maxValue)
        {
            if (value.IsInRange(minValue, maxValue))
                return value;

            int diffrenceToMinValue = Mathf.Abs(value - minValue);
            int diffrenceToMaxValue = Mathf.Abs(value - maxValue);

            return (int)MathF.Min(diffrenceToMinValue, diffrenceToMaxValue);
        }

        public static int Max(this int value, int max) => value <= max ? value : max;

        public static int Min(this int value, int min) => value <= min ? min : value;

        public static int Clamp(this int value, int min, int max) =>
            Math.Max(min, Math.Min(max, value));

        public static int Lerp(this int current, int target, float t)
        {
            t = Mathf.Clamp01(t);
            return Mathf.RoundToInt(Mathf.Lerp(current, target, t));
        }

        public static int LerpUnclamped(this int current, int target, float t) =>
            Mathf.RoundToInt(Mathf.LerpUnclamped(current, target, t));

        public static int MoveTowards(this int current, int target, int maxDelta)
        {
            if (Mathf.Abs(target - current) <= maxDelta)
                return target;

            return current + (int)Mathf.Sign(target - current) * maxDelta;
        }

        /// <summary>
        /// Remap a value from source range to targetRange.
        /// </summary>
        public static int Remap(this int value, Vector2Int sourceRange, Vector2Int targetRange)
        {
            if (sourceRange.x == sourceRange.y)
                return targetRange.x; // Avoid division by zero
            float t = (value - sourceRange.x) / (float)(sourceRange.y - sourceRange.x);
            return Mathf.RoundToInt(Mathf.Lerp(targetRange.x, targetRange.y, t));
        }

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
        public static float Sin(this int f) => Mathf.Sin(f);

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
        public static float Cos(this int f) => Mathf.Cos(f);

        //
        // Summary:
        //     Returns the tangent of angle f in radians.
        //
        // Parameters:
        //   f:
        public static float Tan(this int f) => Mathf.Tan(f);

        //
        // Summary:
        //     Returns the arc-sine of f - the angle in radians whose sine is f.
        //
        // Parameters:
        //   f:
        public static float Asin(this int f) => Mathf.Asin(f);

        //
        // Summary:
        //     Returns the arc-cosine of f - the angle in radians whose cosine is f.
        //
        // Parameters:
        //   f:
        public static float Acos(this int f) => Mathf.Acos(f);

        //
        // Summary:
        //     Returns the arc-tangent of f - the angle in radians whose tangent is f.
        //
        // Parameters:
        //   f:
        public static float Atan(this int f) => Mathf.Atan(f);

        //
        // Summary:
        //     Returns the angle in radians whose Tan is y/x.
        //
        // Parameters:
        //   y:
        //
        //   x:
        public static float Atan2(this int y, int x) => Mathf.Atan2(y, x);

        //
        // Summary:
        //     Returns square root of f.
        //
        // Parameters:
        //   f:
        public static float Sqrt(this int f) => Mathf.Sqrt(f);

        //
        // Summary:
        //     Returns the absolute value of f.
        //
        // Parameters:
        //   f:
        public static float Abs(this int f) => Mathf.Abs(f);

        //
        // Summary:
        //     Returns f raised to power p.
        //
        // Parameters:
        //   f:
        //
        //   p:
        public static float Pow(this int f, float x) => Mathf.Pow(f, x);

        //
        // Summary:
        //     Returns e raised to the specified power.
        //
        // Parameters:
        //   power:
        public static float Exp(this int power) => Mathf.Exp(power);

        //
        // Summary:
        //     Returns the natural (base e) logarithm of a specified number.
        //
        // Parameters:
        //   f:
        public static float Log(this int f) => Mathf.Log(f);

        //
        // Summary:
        //     Returns the logarithm of a specified number in a specified base.
        //
        // Parameters:
        //   f:
        //
        //   p:
        public static float Log(this int f, float p) => Mathf.Log(f, p);

        //
        // Summary:
        //     Returns the base 10 logarithm of a specified number.
        //
        // Parameters:
        //   f:
        public static float Log10(this int f) => Mathf.Log10(f);

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
        public static float LerpAngle(this int current, float target, float time) =>
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
        public static float MoveTowardsAngle(this int current, float target, float time) =>
            Mathf.MoveTowardsAngle(current, target, time);

        //
        // Summary:
        //     Loops the value t, so that it is never larger than length and never smaller than
        //     0.
        //
        // Parameters:
        //   t:
        //
        //   length:
        public static float Repeat(this int t, float length) => Mathf.Repeat(t, length);

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
        public static float PingPong(this int t, float length) => Mathf.PingPong(t, length);
    }
}
