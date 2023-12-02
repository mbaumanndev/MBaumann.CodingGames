namespace MBaumann.CodingGames.AdventOfCode2023.FSharp.Days

open System

module Day1 =
    (* Debug tool *)
    let (|!>) a f = f a; a

    (* Map with digits spelled with int value *)
    let digits = Map [
        ("one", "1");
        ("two", "2");
        ("three", "3");
        ("four", "4");
        ("five", "5");
        ("six", "6");
        ("seven", "7");
        ("eight", "8");
        ("nine", "9");
    ]

    let FindFirstNumber (str: string) = 
        str
        |> Seq.find (fun (elm) -> Char.IsDigit(elm))

    let FindLastNumber (str: string) =
        str
        (* findBack search from the end of the seq *)
        |> Seq.findBack (fun (elm) -> Char.IsDigit(elm))

    let FindCalibrationValue (str: string) =
        let first = FindFirstNumber str
        let last = FindLastNumber str

        (* Concat char list to string *)
        String [| first; last |]

    (* May not be the best way to do it with F#, but works *)
    let FindFirstSpelledDigitWithInt (str: string) =
        let filtered = digits
                        (* Take each digit *)
                        |> Map.keys
                        (* Check if it is contained from start *)
                        |> Seq.map (fun digit -> (digit, str.IndexOf(digit)))
                        (* Keep found values *)
                        |> Seq.filter (fun kvp -> snd(kvp) > -1)

        if Seq.length(filtered) > 0 then
            (* If values found, take the smallest one *)
            filtered
            |> Seq.minBy (fun kvp -> snd(kvp))
            (* Only keep the digit key *)
            |> fst
        else
            (* Empty seq *)
            null

    let ReplaceFirstSpelledDigitWithInt (str: string) =
        let digit = str |> FindFirstSpelledDigitWithInt
        let replaceValue = digits |> Map.tryFind digit
        
        if replaceValue.IsSome then str.Replace(digit, replaceValue.Value) else str

    let FindLastSpelledDigitWithInt (str: string) =
        let filtered = digits
                        (* Take each digit *)
                        |> Map.keys
                        (* Check if it is contained from end *)
                        |> Seq.map (fun digit -> (digit, str.LastIndexOf(digit)))
                        (* Keep found values *)
                        |> Seq.filter (fun kvp -> snd(kvp) > -1)
                        
        if Seq.length(filtered) > 0 then
            (* If values found, take the biggest one *)
            filtered
            |> Seq.maxBy (fun kvp -> snd(kvp))
            (* Only keep the digit key *)
            |> fst
        else
            (* Empty seq *)
            null
            
    let ReplaceLastSpelledDigitWithInt (str: string) =
        let digit = str |> FindLastSpelledDigitWithInt
        let replaceValue = digits |> Map.tryFind digit
        
        if replaceValue.IsSome then str.Replace(digit, replaceValue.Value) else str

    let FindCalibrationValue2 (str: string) =
        let first = str |> ReplaceFirstSpelledDigitWithInt |> FindFirstNumber
        let last = str |> ReplaceLastSpelledDigitWithInt |> FindLastNumber

        String [| first; last |]

    let ComputePart1(input: string[]) =
        input
        |> Seq.map FindCalibrationValue
        |!> Seq.iter (printfn "Calibration value: %s")
        |> Seq.map int
        |> Seq.sum

    let ComputePart2(input: string[]) =
        input
        |> Seq.map FindCalibrationValue2
        |!> Seq.iter (printfn "Calibration value: %s")
        |> Seq.map int
        |> Seq.sum

