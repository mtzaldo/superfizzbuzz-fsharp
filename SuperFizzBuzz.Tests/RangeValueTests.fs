namespace SuperFizzBuzz.Tests

open System;
open System.Linq;
open SuperFizzBuzz
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type RangeValueTests () =

    [<TestMethod>]
    member this.``RangeValue GetValues should return the correct number of values``() =
        let expected = 10;
        let values = seq[1..10];
        let range = RangeValue(values);
        let actual = range.GetValues.ToList().Count;

        Assert.AreEqual(expected, actual);

    [<TestMethod>]
    member this.``RangeValue GetValues should return one value``() =
        let expected = 1;
        let values = seq[0..0];
        let range = RangeValue(values);
        let actual = range.GetValues.ToList().Count;

        Assert.AreEqual(expected, actual);

    [<TestMethod; ExpectedException(typeof<ArgumentException>)>]
    member this.``RangeValue constructor should throw ArgumentException when value is null``() =
        let range = RangeValue(null);
        ()