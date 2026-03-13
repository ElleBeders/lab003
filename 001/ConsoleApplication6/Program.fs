open System

// Сисок пользователя
let rec readR acc =
    let ch = Console.ReadLine()
    if ch = "000" then
        List.rev acc
    else
        readR (int(ch) :: acc) 

let oneNumber (digits: seq<int>) : int =
    digits
    |> Seq.fold (fun acc digit ->
        if digit % 2 = 0 then     
            acc * 10 + digit  
        else
            acc              
    ) 0  

[<EntryPoint>]
let main argv =
    printfn "Введите цифры (по одной):"
    printfn "(000 — конец ввода)"
    
    let number = readR []
    let result = oneNumber (seq number) 
    
    printfn "Исходные цифры: %A" number
    printfn "Число из чётных цифр: %d" result
    0
