// Learn more about F# at http://fsharp.org

open System



let rec binSearch target arr =
    match Array.length arr with
        | 0 -> None
        | i -> let middle = i / 2
               match  sign <| compare target arr.[middle] with
                | 0  -> Some(target)
                | -1 -> binSearch target arr.[..middle-1]
                | _  -> binSearch target arr.[middle+1..]
    
    
[<EntryPoint>]
let main argv =
    let thing = binSearch 7918 [|1..10000000|]
    printfn thing.ToString()
    0 // return an integer exit code