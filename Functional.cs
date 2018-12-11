using System;
using System.Collections;
using System.Collections.Generic;

namespace vmnet
{
    public static class Functional
    {
        public static T Tee<T>(T @this, Action action)
        {
            action();
            return @this;
        }

        public static T Tee<T>(T @this, Action<T> action) =>
            Tee(@this, () => action(@this));

        public static U Map<T, U>(T @this, Func<T, U> f) =>
            f(@this);

        public static T Identity<T>(T t) =>
            t;

        public static Func<IEnumerable<string>, string> StringJoin(string separator) => (IEnumerable<string> strings) =>
            string.Join(separator, strings);

        public static class Math
        {
            public static Func<int, int> Add(int a) => (int b) =>
                a + b;

            public static Func<int, int> Subtract(int a) =>
                Add(-a);
        }
    }
}