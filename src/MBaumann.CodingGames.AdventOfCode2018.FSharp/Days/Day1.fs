namespace MBaumann.CodingGames.AdventOfCode2018.FSharp.Days

open System.Collections.Generic

module Day1Part1 =
    let Compute (input: string[]) =
        (Array.sumBy (int) (input))

module Seq = let rec cycle xs = seq { yield! xs; yield! cycle xs }

module Day1Part2 =
    let Cycle sequence = 
        sequence
        |> Array.map(fun l -> int l)
        |> Seq.cycle

    let Add1 integer =
        integer + 1

    let FindIndex sequence =
        let mutable seen = new List<int>()
        let mutable freq = 0

        seen.Add(0)

        let test change =
            freq <- freq + change
            if seen.Contains(freq) then
                false
            else
                seen.Add(freq) |> ignore
                true

        sequence
        |> Seq.takeWhile (fun (change) -> test(change))
        |> Seq.length
        |> Add1


    let Compute (input: string[]) =
        let elements = Cycle input
        let index = FindIndex elements
        Seq.sum (Seq.take index elements)
