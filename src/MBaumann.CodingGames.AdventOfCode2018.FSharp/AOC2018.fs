namespace MBaumann.CodingGames.AdventOfCode2018.FSharp

open MBaumann.CodingGames.AdventOfCode2018.FSharp.Days
open MBaumann.CodingGames.Common
open System
open System.IO

module FSAOC =
    type public AOC2018() =
        interface IGame with
            override this.GetGameMenu() =
                MenuItem("Advent Of Code 2018 F#", [|
                    PuzzleMenuItem("Day 1 Part 1", fun _ -> Console.WriteLine(Day1Part1.Compute(File.ReadAllLines($"Inputs{Path.DirectorySeparatorChar}2018Day1.txt")))) :> MenuItem
                |])