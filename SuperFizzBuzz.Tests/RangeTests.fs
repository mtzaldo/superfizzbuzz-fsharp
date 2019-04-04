namespace SuperFizzBuzz.Tests

open System;
open System.Linq;
open SuperFizzBuzz
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type RangeTests () =

    [<TestMethod>]
    member this.``Range GetValues should return the correct number of values``() =
        let expected = 10;
        let range = Range(1, 10);
        let actual = range.GetValues.ToList().Count;

        Assert.AreEqual(expected, actual);

    [<TestMethod>]
    member this.``Range GetValues should return one value``() =
        let expected = 1;
        let range = Range(0, 0);
        let actual = range.GetValues.ToList().Count;

        Assert.AreEqual(expected, actual);

    [<TestMethod; ExpectedException(typeof<ArgumentException>)>]
    member this.``Range constructor should throw ArgumentException when start is greater than end``() =
        let range = Range(10, 1);
        ()