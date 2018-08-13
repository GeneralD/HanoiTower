using System;
using System.Collections.Async;
using System.Threading;
using Functional;

namespace HanoiTower {
    class Program {
        static void Main(string[] args) {
            var hanoi = RecursableFuncExtensions.RecurseMemorised<int, int, int, int, AsyncEnumerable<string>>
            ((next, src, bare, dst, height) => new AsyncEnumerable<string>(async yield => {
                if (height > 1) foreach (var r in next(src, dst, bare, height - 1).ToEnumerable()) await yield.ReturnAsync(r);
                await yield.ReturnAsync($"object: {height}, tower: {src}->{dst}");
                if (height > 1) foreach (var r in next(bare, src, dst, height - 1).ToEnumerable()) await yield.ReturnAsync(r);
            }).Curry()(1)(2)(3);

            int h;
            if (args.Length == 0 || !int.TryParse(args[0], out h)) h = 3;
            hanoi(h).ForEachAsync(s => Console.WriteLine(s));
        }
    }
}