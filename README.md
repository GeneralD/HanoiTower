# HanoiTower

![language](https://img.shields.io/badge/C%23-7.x-blue) ![runtime](https://img.shields.io/badge/.NET%20Core-2.1-blue) ![paradigm](https://img.shields.io/badge/style-functional-blue) ![status](https://img.shields.io/badge/status-legacy-lightgrey)

![HanoiTower hero banner](assets/hero.jpg)

A small Tower of Hanoi solver written as a functional-programming exercise in C# (2019). It demonstrates how to write recursive, lazily-evaluated, monadic code in C# using community libraries rather than plain imperative loops.

## Features

- Recursive Hanoi solver defined as an anonymous recursive function via [Funcursive](https://www.nuget.org/packages/Funcursive) (`FuncR`)
- Lazy step generation with `EnumerableEx.Create` and an async yielder ([System.Interactive](https://www.nuget.org/packages/System.Interactive) / Ix.NET)
- Argument parsing wrapped in the `Try` monad from [csharp-monad](https://www.nuget.org/packages/csharp-monad), composed with LINQ query syntax
- Partial application of the solver via [CSharp.Curry](https://www.nuget.org/packages/CSharp.Curry)

## Requirements

- .NET Core SDK 2.1 (the target framework is `netcoreapp2.1`, long out of support — a modern SDK would need the target framework bumped)

## Usage

```sh
dotnet run --project HanoiTower [height] [steps]
```

- `height` — number of disks (default: `3`)
- `steps` — number of moves to print (default: `2^height - 1`, i.e. the full solution)

Each line prints one move:

```text
object: 1, tower: 1->3
object: 2, tower: 1->2
...
```

## Project Structure

```text
HanoiTower.sln
HanoiTower/
  HanoiTower.csproj   # netcoreapp2.1 console app, NuGet deps
  Program.cs          # entire implementation (~40 lines)
```

## Status

Legacy sample from 2019, kept as a reference for functional idioms in C#. Not actively maintained.
