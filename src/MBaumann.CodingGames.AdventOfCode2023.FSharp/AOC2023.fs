namespace MBaumann.CodingGames.AdventOfCode2023.FSharp

open MBaumann.CodingGames.AdventOfCode2023.FSharp.Days
open MBaumann.CodingGames.Common
open System
open System.IO


module FSAOC2023 =
    type public AOC2023() =
        interface IGame with
            override this.GetGameMenu() =
                MenuItem("Advent Of Code 2023 F#", [|
                    PuzzleMenuItem("Day 1 Part 1", fun _ -> Console.WriteLine(Day1Part1.Compute(File.ReadAllLines($"Inputs{Path.DirectorySeparatorChar}2023Day1.txt")))) :> MenuItem
                |])
