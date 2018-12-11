using System;
using System.Collections;
using System.Collections.Generic;

namespace vmnet
{
    public static class FunctionalExtensions
    {
        public static T Tee<T>(this T @this, Action action) =>
            Functional.Tee<T>(@this, action);

        public static T Tee<T>(this T @this, Action<T> action) =>
            Functional.Tee<T>(@this, action);

        public static U Map<T, U>(this T @this, Func<T, U> f) =>
            f(@this);

        public static string StringJoin(this IEnumerable<string> @this, string separator) =>
            Functional.StringJoin(separator)(@this);
    }

    public static class MathExtensions
    {
        public static Func<int, int> Add(this int @this) =>
            Functional.Math.Add(@this);
    }
}