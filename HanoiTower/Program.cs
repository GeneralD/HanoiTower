﻿using System;
using System.Collections.Generic;
using System.Linq;
using CSharp.Curry;
using Funcursive;
using Monad;

using Step = System.ValueTuple<int, int, int>;

namespace HanoiTower {
	internal static class Program {
		private static void Main(string[] args) {
			// recursive function
			var hanoi = FuncR<int, int, int, int, IEnumerable<Step>>.Create((src, bare, dst, h, f) =>
					EnumerableEx.Create<Step>(async yielder => {
						if (h == 0) return;
						foreach (var r in f(src, dst, bare, h - 1)) await yielder.Return(r);
						await yielder.Return((h, src, dst));
						foreach (var r in f(bare, src, dst, h - 1)) await yielder.Return(r);
					})).Curry(1, 2, 3, _.__);
			// monad
			Try<string> ArgAtIndex(int index) => () => args[index];
			Try<int> TryParse(string str) => () => int.Parse(str);
			Try<int> ParseArgToInt(int i) => from v in ArgAtIndex(i) from r in TryParse(v) select r;
			var height = ParseArgToInt(0).Match(i => i, e => 3)();
			var take = ParseArgToInt(1).Match(i => i, e => (int)MathF.Pow(2, height) - 1)();

			hanoi(height).Take(take).ForEach(s => Console.WriteLine($"object: {s.Item1}, tower: {s.Item2}->{s.Item3}"));
		}
	}
}