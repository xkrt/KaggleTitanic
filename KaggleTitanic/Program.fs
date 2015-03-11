module KaggleTitanic.Program

open RDotNet
open RProvider
open RProvider.graphics

[<EntryPoint>]
let main argv =
    let data = DataLoader.load()
    let sex = data |> List.map (fun r -> match r.Sex with Male -> 1 | Female -> 2)
    let klass = data |> List.map (fun r -> r.Class)

    R.plot(sex, klass)

    System.Console.ReadLine() |> ignore
    0
