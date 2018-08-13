using System;
namespace Functional {

	public delegate TResult PartialApply<T, TResult>(T arg);

	public static class PartialApplyFuncExtensions {
		public static PartialApply<T_, TResult> _<T_, TResult>(this Func<T_, TResult> func) => new PartialApply<T_, TResult>(func);
		public static PartialApply<T_, TResult> _<T_, TResult>(this Func<T_, PartialApply<T_, TResult>> func) => _ => func(_)(_);
		public static Func<T1, PartialApply<T_, TResult>> _<T_, T1, TResult>(this Func<T_, Func<T1, TResult>> func) => v1 => _ => func(_)(v1);
		public static Func<T1, PartialApply<T_, TResult>> _<T_, T1, TResult>(this Func<T_, Func<T1, PartialApply<T_, TResult>>> func) => v1 => _ => func(_)(v1)(_);
		public static Func<T1, Func<T2, PartialApply<T_, TResult>>> _<T_, T1, T2, TResult>(this Func<T_, Func<T1, Func<T2, TResult>>> func) => v1 => v2 => _ => func(_)(v1)(v2);
		public static Func<T1, Func<T2, PartialApply<T_, TResult>>> _<T_, T1, T2, TResult>(this Func<T_, Func<T1, Func<T2, PartialApply<T_, TResult>>>> func) => v1 => v2 => _ => func(_)(v1)(v2)(_);
		public static Func<T1, Func<T2, Func<T3, PartialApply<T_, TResult>>>> _<T_, T1, T2, T3, TResult>(this Func<T_, Func<T1, Func<T2, Func<T3, TResult>>>> func) => v1 => v2 => v3 => _ => func(_)(v1)(v2)(v3);
		public static Func<T, TResult> ToFunc<T, TResult>(PartialApply<T, TResult> func) => v => func(v);
	}

	public static class CurryFuncExtensions {
		public static Func<T1, TResult> Curry<T1, TResult>(this Func<T1, TResult> func) => v1 => func(v1);
		public static Func<T1, Func<T2, TResult>> Curry<T1, T2, TResult>(this Func<T1, T2, TResult> func) => v1 => v2 => func(v1, v2);
		public static Func<T1, Func<T2, Func<T3, TResult>>> Curry<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func) => v1 => v2 => v3 => func(v1, v2, v3);
		public static Func<T1, Func<T2, Func<T3, Func<T4, TResult>>>> Curry<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func) => v1 => v2 => v3 => v4 => func(v1, v2, v3, v4);
	}

	public static class CurryActionExtensions {
		public static Action<T1> Curry<T1>(this Action<T1> func) => v1 => func(v1);
		public static Func<T1, Action<T2>> Curry<T1, T2>(this Action<T1, T2> func) => v1 => v2 => func(v1, v2);
		public static Func<T1, Func<T2, Action<T3>>> Curry<T1, T2, T3>(this Action<T1, T2, T3> func) => v1 => v2 => v3 => func(v1, v2, v3);
		public static Func<T1, Func<T2, Func<T3, Action<T4>>>> Curry<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> func) => v1 => v2 => v3 => v4 => func(v1, v2, v3, v4);
	}

}
