open System

let rec readRoman acc =
    let input = Console.ReadLine()
    if input = "000" then
        List.rev acc 
    else
        readRoman (input :: acc) 

let romanToDecimalMap =
    [("I", 1); ("II", 2); ("III", 3); ("IV", 4); ("V", 5);
     ("VI", 6); ("VII", 7); ("VIII", 8); ("IX", 9)]
    |> Map.ofList

let convertToDecimal (romanSeq: seq<string>) : seq<int> =
    romanSeq
    |> Seq.map (fun roman ->
        match romanToDecimalMap.TryFind roman with
        | Some decimal -> decimal
        | None -> 0
    )

[<EntryPoint>]
let main argv =
    printfn "Введите римские цифры (от I до IX):"
    printfn "(000 — конец ввода)"
    
    let romanNumerals = readRoman []
    let decimalNumbers = convertToDecimal (seq romanNumerals)

    
    printfn "Римские цифры: %A" romanNumerals
    printfn "Десятичные числа: %A" (Seq.toList decimalNumbers)
    0