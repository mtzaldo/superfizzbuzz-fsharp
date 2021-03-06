namespace SuperFizzBuzz

open System.Collections.Generic

type IRange =
    abstract member GetValues: seq<int>

type Range(start : int, last: int) = 
    do
        if start > last then
            invalidArg "start" "start should be less or equal than end"

    member this.GetValues: seq<int> =
        seq [start..last]    

    interface IRange with
        member this.GetValues = this.GetValues

type RangeValue(values: seq<int>) =
    do
        if isNull(values) then
            invalidArg "values" "values can't be null"

    member this.GetValues = values        

    interface IRange with
        member this.GetValues = this.GetValues

type SuperFizzBuzz(range: IRange, replacements: Dictionary<int, string>) =
    member this.Get: seq<string> =
        
        let closure (replaceNumber: int, replaceValue: string) =
            fun (number: int) ->
                match number with
                | number when number % replaceNumber = 0 -> replaceValue
                | _ -> ""

        let delegates =
            replacements |> Seq.map (fun repl -> closure(repl.Key, repl.Value))                         

        range.GetValues |>
            Seq.map (fun n -> 
                
                let sfb = Seq.fold (fun word fizzBuzz -> word + fizzBuzz(n)) "" delegates

                match sfb with
                | ""    -> n.ToString()
                | _     -> sfb
            )