namespace MBaumann.CodingGames.AdventOfCode2023.FSharp.Days

open System

module Day1Part1 =
    let (|!>) a f = f a; a

    let FindFirstNumber (str: string) = 
        str
        |> Seq.find (fun (elm) -> Char.IsDigit(elm))

    let FindLastNumber (str: string) =
        str
        |> Seq.findBack (fun (elm) -> Char.IsDigit(elm))

    let FindCalibrationValue (str: string) =
        let first = FindFirstNumber str
        let last = FindLastNumber str

        String [| first; last |]

    let Compute(input: string[]) =
        input
        |> Seq.map FindCalibrationValue
        |!> Seq.iter (printfn "Calibration value: %s")
        |> Seq.map int
        |> Seq.sum


