# HanoiTower — AI Context Notes

- Tower of Hanoi solver written as a functional-programming exercise in C#; the entire logic lives in `HanoiTower/Program.cs` (~40 lines).
- Stack: .NET Core 2.1 console app (`netcoreapp2.1`), C# with NuGet packages: Funcursive (anonymous recursion), System.Interactive (lazy `EnumerableEx.Create` yielder), csharp-monad (`Try` monad for arg parsing), CSharp.Curry (partial application).
- Status: legacy sample from 2019, not maintained. netcoreapp2.1 is EOL — building requires an old SDK or bumping the TargetFramework.
- Layout: `HanoiTower.sln` at root, single project `HanoiTower/` with `HanoiTower.csproj` + `Program.cs`. The csproj excludes two source files that are not present in the repo.
- Run (with a 2.1-era SDK): `dotnet run --project HanoiTower [height] [steps]` — defaults: height=3, steps=2^height-1. Prints each move as `object: N, tower: A->B`.
- No tests, no CI, no LICENSE file.
