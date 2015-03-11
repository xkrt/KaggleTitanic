module KaggleTitanic.DataLoader

open System.IO
open ExtCore
open FSharp.Data

type private Csv = CsvProvider<"../data/train.csv">

let load () =
    let csvPath = __SOURCE_DIRECTORY__ + "/../data/train.csv"
    let csv = Csv.Load(csvPath)
    csv.Rows
    |> Seq.map (fun (r: Csv.Row) ->
        { PassengerId = r.PassengerId
          Survived = r.Survived
          Class = r.Pclass
          Name = r.Name
          Sex = match r.Sex with "male" -> Male | _ -> Female
          Age = r.Age
          SiblingsSpouses = r.SibSp
          ParentsChildren = r.Parch
          TicketNumber = r.Ticket
          Fare = float r.Fare
          Cabin = r.Cabin
          Port = match r.Embarked with
                 | "C" -> Some Cherbourg
                 | "Q" -> Some Queenstown
                 | "S" -> Some Southampton
                 | "" -> None
                 | _ -> failwithf "unknown Embarked" })
    |> Seq.toList
