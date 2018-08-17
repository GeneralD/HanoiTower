using System;
using System.Collections.Async;
using System.Linq;
using CSharp.Curry;
using Funcursive;
using Monad;

namespace HanoiTower {
    class Program {
        private static void Main(string[] args) {
            var hanoi = FuncR<int, int, int, int, AsyncEnumerable<string>>.Create((src, bare, dst, height, next) =>
                new AsyncEnumerable<string>(async yield => {
                    if (height > 1)
                        foreach (var r in next(src, dst, bare, height - 1).ToEnumerable())
                            await yield.ReturnAsync(r);
                    await yield.ReturnAsync($"object: {height}, tower: {src}->{dst}");
                    if (height > 1)
                        foreach (var r in next(bare, src, dst, height - 1).ToEnumerable())
                            await yield.ReturnAsync(r);
                })).Curry()(1)(2)(3);

            Try<string> First(string[] ary) => () => ary.First();
            Try<int> TryParse(string str) => () => int.Parse(str);

            var monad = from v in First(args)
                from r in TryParse(v)
                select r;

            hanoi(monad.Match(i => i, e => 3)()).ForEachAsync(s => Console.WriteLine(s));
        }
    }
}