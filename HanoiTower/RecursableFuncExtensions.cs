using System;
using System.Collections.Generic;

namespace Functional {

	public static class RecursableFuncExtensions {

		public static Func<T1, TResult> Recurse<T1, TResult>(this Func<Func<T1, TResult>, T1, TResult> f) {
			Func<T1, TResult> next = null;
			return next = p1 => f(next, p1);
		}

		public static Func<T1, T2, TResult> Recurse<T1, T2, TResult>(this Func<Func<T1, T2, TResult>, T1, T2, TResult> f) {
			Func<T1, T2, TResult> next = null;
			return next = (p1, p2) => f(next, p1, p2);
		}

		public static Func<T1, T2, T3, TResult> Recurse<T1, T2, T3, TResult>(this Func<Func<T1, T2, T3, TResult>, T1, T2, T3, TResult> f) {
			Func<T1, T2, T3, TResult> next = null;
			return next = (p1, p2, p3) => f(next, p1, p2, p3);
		}

		public static Func<T1, T2, T3, T4, TResult> Recurse<T1, T2, T3, T4, TResult>(this Func<Func<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult> f) {
			Func<T1, T2, T3, T4, TResult> next = null;
			return next = (p1, p2, p3, p4) => f(next, p1, p2, p3, p4);
		}

		public static Func<T1, T2, T3, T4, T5, TResult> Recurse<T1, T2, T3, T4, T5, TResult>(this Func<Func<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult> f) {
			Func<T1, T2, T3, T4, T5, TResult> next = null;
			return next = (p1, p2, p3, p4, p5) => f(next, p1, p2, p3, p4, p5);
		}

		public static Func<T1, T2, T3, T4, T5, T6, TResult> Recurse<T1, T2, T3, T4, T5, T6, TResult>(this Func<Func<T1, T2, T3, T4, T5, T6, TResult>, T1, T2, T3, T4, T5, T6, TResult> f) {
			Func<T1, T2, T3, T4, T5, T6, TResult> next = null;
			return next = (p1, p2, p3, p4, p5, p6) => f(next, p1, p2, p3, p4, p5, p6);
		}

		public static Func<T1, TResult> RecurseMemorised<T1, TResult>(this Func<Func<T1, TResult>, T1, TResult> f) {
			Dictionary<T1, TResult> memory = new Dictionary<T1, TResult>();
			Func<T1, TResult> next = null;
			return next = p1 => memory.ContainsKey(p1) ? memory[p1] : memory[p1] = f(next, p1);
		}

		public static Func<T1, T2, TResult> RecurseMemorised<T1, T2, TResult>(this Func<Func<T1, T2, TResult>, T1, T2, TResult> f) {
			Dictionary<object, TResult> memory = new Dictionary<object, TResult>();
			Func<T1, T2, TResult> next = null;
			return next = (p1, p2) => memory.ContainsKey(new { p1, p2 }) ? memory[new { p1, p2 }] : memory[new { p1, p2 }] = f(next, p1, p2);
		}

		public static Func<T1, T2, T3, TResult> RecurseMemorised<T1, T2, T3, TResult>(this Func<Func<T1, T2, T3, TResult>, T1, T2, T3, TResult> f) {
			Dictionary<object, TResult> memory = new Dictionary<object, TResult>();
			Func<T1, T2, T3, TResult> next = null;
			return next = (p1, p2, p3) => memory.ContainsKey(new { p1, p2, p3 }) ? memory[new { p1, p2, p3 }] : memory[new { p1, p2, p3 }] = f(next, p1, p2, p3);
		}

		public static Func<T1, T2, T3, T4, TResult> RecurseMemorised<T1, T2, T3, T4, TResult>(this Func<Func<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult> f) {
			Dictionary<object, TResult> memory = new Dictionary<object, TResult>();
			Func<T1, T2, T3, T4, TResult> next = null;
			return next = (p1, p2, p3, p4) => memory.ContainsKey(new { p1, p2, p3, p4 }) ? memory[new { p1, p2, p3, p4 }] : memory[new { p1, p2, p3, p4 }] = f(next, p1, p2, p3, p4);
		}

		public static Func<T1, T2, T3, T4, T5, TResult> RecurseMemorised<T1, T2, T3, T4, T5, TResult>(this Func<Func<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult> f) {
			Dictionary<object, TResult> memory = new Dictionary<object, TResult>();
			Func<T1, T2, T3, T4, T5, TResult> next = null;
			return next = (p1, p2, p3, p4, p5) => memory.ContainsKey(new { p1, p2, p3, p4, p5 }) ? memory[new { p1, p2, p3, p4, p5 }] : memory[new { p1, p2, p3, p4, p5 }] = f(next, p1, p2, p3, p4, p5);
		}

		public static Func<T1, T2, T3, T4, T5, T6, TResult> RecurseMemorised<T1, T2, T3, T4, T5, T6, TResult>(this Func<Func<T1, T2, T3, T4, T5, T6, TResult>, T1, T2, T3, T4, T5, T6, TResult> f) {
			Dictionary<object, TResult> memory = new Dictionary<object, TResult>();
			Func<T1, T2, T3, T4, T5, T6, TResult> next = null;
			return next = (p1, p2, p3, p4, p5, p6) => memory.ContainsKey(new { p1, p2, p3, p4, p5, p6 }) ? memory[new { p1, p2, p3, p4, p5, p6 }] : memory[new { p1, p2, p3, p4, p5, p6 }] = f(next, p1, p2, p3, p4, p5, p6);
		}
	}
}
