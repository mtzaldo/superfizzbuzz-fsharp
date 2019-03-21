open SuperFizzBuzz
open System.Collections.Generic

[<EntryPoint>]
let main argv =
    let range = Range(-12, 145)

    let replacements = Dictionary<int, string>()
    replacements.Add(3, "Fizz")
    replacements.Add(7, "Buzz")
    replacements.Add(38, "Bazz")

    let sfb = SuperFizzBuzz(range, replacements)

    sfb.Get |> Seq.iter (fun word -> printfn "%A" word)
    0
