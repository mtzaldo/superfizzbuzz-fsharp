open SuperFizzBuzz
open System.Collections.Generic

[<EntryPoint>]
let main argv =
    let range = Range(1, 100)

    let replacements = Dictionary<int, string>()
    replacements.Add(3, "Fizz")
    replacements.Add(5, "Buzz")

    let sfb = SuperFizzBuzz(range, replacements)

    sfb.Get |> Seq.iter (fun word -> printfn "%A" word)
    0
