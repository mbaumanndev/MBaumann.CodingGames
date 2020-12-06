using Microsoft.FSharp.Core;
using System;

namespace MBaumann.CommonTools.Extensions
{
    public static class FSharpExtensions
    {
        private static readonly Unit Unit = (Unit)Activator.CreateInstance(typeof(Unit), true);

        public static Func<T, Unit> ToFunc<T>(this Action<T> action)
        {
            return x => { action(x); return Unit; };
        }

        public static FSharpFunc<T, Unit> ToFSharpFunc<T>(this Action<T> action)
        {
            return FSharpFunc<T, Unit>.FromConverter(new Converter<T, Unit>(action.ToFunc()));
        }
    }
}
