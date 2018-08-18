using System;
using System.Collections.Generic;
using System.Linq;
using CSharp.Curry;
using Funcursive;
using Monad;

namespace HanoiTower {
    internal static class Program {
        private static void Main(string[] args) {
            var hanoi = FuncR<int, int, int, int, IEnumerable<Tuple<int, int, int>>>
                .Create((src, bare, dst, height, next) =>
                    EnumerableEx.Create<Tuple<int, int, int>>(async yielder => {
                        if (height > 1) foreach (var r in next(src, dst, bare, height - 1)) await yielder.Return(r);
                        await yielder.Return(new Tuple<int, int, int>(height, src, dst));
                        if (height > 1) foreach (var r in next(bare, src, dst, height - 1)) await yielder.Return(r);
                    })).Curry()(1)(2)(3);

            Try<string> First(string[] ary) => () => ary.First();
            Try<int> TryParse(string str) => () => int.Parse(str);

            var monad =
                from v in First(args)
                from r in TryParse(v)
                select r;

            hanoi(monad.Match(i => i, e => 3)())
                .ForEach(s => Console.WriteLine($"object: {s.Item1}, tower: {s.Item2}->{s.Item3}"));
        }
    }
}