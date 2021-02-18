using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace System.Pipeline
{
    [DebuggerNonUserCode]
    static public class GrammarExtension
    {
        public static bool IsDefault<T>(this T obj)
        {
            return EqualityComparer<T>.Default.Equals(obj, default(T));
        }

        public static T Do<T>(this T obj, Action<T> action)
        {
            action(obj);
            return obj;
        }
        public static T DoIf<T>(this T obj, bool isTrue, Action<T> action)
        {
            if (isTrue) action(obj);
            return obj;
        }

        public static T DoIf<T>(this T obj, Func<T, bool> isTrue, Action<T> onTrue, Action<T> onFalse)
        {
            if (isTrue(obj))
                onTrue(obj);
            else
                onFalse(obj);
            return obj;
        }

        public static T DoNotNull<T>(this T obj, Action<T> onNotNull) where T : class
        {
            if (obj != null) onNotNull(obj);
            return obj;
        }

        public static T DoIsNull<T>(this T obj, Action onNull) where T : class
        {
            if (obj == null) onNull();
            return obj;
        }

        public static T DoNotDefault<T>(this T obj, Action<T> onNotDefault)
        {
            if (!obj.IsDefault()) onNotDefault(obj);
            return obj;
        }

        public static T DoIsDefault<T>(this T obj, Action onDefault)
        {
            if (obj.IsDefault()) onDefault();
            return obj;
        }
        public static bool IfDo(this bool isTrue, Action onTrue)
        {
            if (isTrue) onTrue();
            return isTrue;
        }

        public static bool IfDo(this bool isTrue, Action onTrue, Action onElse)
        {
            if (isTrue)
                onTrue();
            else
                onElse();
            return isTrue;
        }

        public static TOut To<TIn, TOut>(this TIn obj, Func<TIn, TOut> func)
        {
            return func(obj);
        }
        public static TOut ToIf<TIn, TOut>(this TIn obj, bool isTrue, Func<TIn, TOut> onTrue)
        {
            return isTrue ? onTrue(obj) : default(TOut);
        }

        public static TOut ToIf<TIn, TOut>(this TIn obj, Func<TIn, bool> isTrue, Func<TIn, TOut> onTrue)
        {
            return isTrue(obj) ? onTrue(obj) : default(TOut);
        }
        public static TOut ToIf<TIn, TOut>(this TIn obj, Func<TIn, bool> isTrue, Func<TIn, TOut> onTrue, Func<TIn, TOut> onFalse)
        {
            return isTrue(obj) ? onTrue(obj) : onFalse(obj);
        }
        public static TOut ToIf<TIn, TOut>(this TIn obj, bool isTrue, Func<TIn, TOut> onTrue, Func<TIn, TOut> onFalse)
        {
            return isTrue ? onTrue(obj) : onFalse(obj);
        }
        public static TOut ToIf<TIn, TOut>(this TIn obj, Func<TIn, bool> isTrue, Func<TIn, TOut> onTrue, TOut falseValue)
        {
            return isTrue(obj) ? onTrue(obj) : falseValue;
        }

        public static TOut ToIf<TIn, TOut>(this TIn obj, bool isTrue, Func<TIn, TOut> onTrue, TOut falseValue)
        {
            return isTrue ? onTrue(obj) : falseValue;
        }
        public static TOut ToIf<TIn, TOut>(this TIn obj, bool isTrue, Func<TIn, TOut> onTrue, Func<TOut> onFalse)
        {
            return isTrue ? onTrue(obj) : onFalse();
        }

        public static TOut ToNotNull<TIn, TOut>(this TIn obj, Func<TIn, TOut> onNotNull) where TIn : class
        {
            return obj != null ? onNotNull(obj) : default(TOut);
        }

        public static TOut ToNotNull<TIn, TOut>(this TIn obj, Func<TIn, TOut> onNotNull, Func<TOut> onElse) where TIn : class
        {
            return obj != null ? onNotNull(obj) : onElse();
        }

        public static TOut ToNotNull<TIn, TOut>(this TIn obj, Func<TIn, TOut> onNotNull, TOut defaultValue) where TIn : class
        {
            return obj != null ? onNotNull(obj) : defaultValue;
        }

        public static T ToIsNull<T>(this T obj, Func<T> onNull) where T : class
        {
            return obj ?? onNull();
        }

        public static TOut ToNotDefault<TIn, TOut>(this TIn obj, Func<TIn, TOut> onNotDefault)
        {
            return !obj.IsDefault() ? onNotDefault(obj) : default(TOut);
        }

        public static TOut ToNotDefault<TIn, TOut>(this TIn obj, Func<TIn, TOut> onNotDefault, Func<TOut> onElse)
        {
            return !obj.IsDefault() ? onNotDefault(obj) : onElse();
        }

        public static T ToIsDefault<T>(this T obj, Func<T> onDefault)
        {
            return obj.IsDefault() ? onDefault() : obj;
        }

        public static T IfTo<T>(this bool isTrue, Func<T> onTrue)
        {
            return isTrue ? onTrue() : default(T);
        }

        public static T IfTo<T>(this bool isTrue, Func<T> onTrue, Func<T> onElse)
        {
            return isTrue ? onTrue() : onElse();
        }

        public static T IfTo<T>(this bool isTrue, Func<T> onTrue, T elseValue)
        {
            return isTrue ? onTrue() : elseValue;
        }

        public static TOut ToUsing<TIn, TOut>(this TIn obj, Func<TIn, TOut> work) where TIn : IDisposable
        {
            using (obj) return work(obj);
        }
    }

    public class DummyAttribute : Attribute
    {
    }
}
