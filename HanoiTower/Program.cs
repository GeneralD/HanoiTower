using System;
using System.Collections.Async;
using Functional;
using Monad;
using System.Linq;

namespace HanoiTower {
    class Program {
        private static void Main(string[] args) {
            var hanoi = RecursableFuncExtensions.RecurseMemorised<int, int, int, int, AsyncEnumerable<string>>
            ((next, src, bare, dst, height) => new AsyncEnumerable<string>(async yield => {
                if (height > 1)
                    foreach (var r in next(src, dst, bare, height - 1).ToEnumerable())
                        await yield.ReturnAsync(r);
                await yield.ReturnAsync($"object: {height}, tower: {src}->{dst}");
                if (height > 1)
                    foreach (var r in next(bare, src, dst, height - 1).ToEnumerable())
                        await yield.ReturnAsync(r);
            })).Curry()(1)(2)(3);

            Option<string> First(string[] ary) => () => ary.FirstOrDefault();
            Try<int> TryParse(string str) => () => int.Parse(str);

            var monad = First(args).Select(TryParse).Match(v => v, () => 3)();

            hanoi(monad().Value).ForEachAsync(s => Console.WriteLine(s));
        }
    }
}