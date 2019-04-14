module ImplementationWorkflow

open System

type RoundingBuilder(accuracy: int) =
    member this.Bind(x: float, f: float -> float) =
        let roundedNumber = Math.Round(x, accuracy)
        Math.Round (f roundedNumber, accuracy)
    member this.Return(roundedNumber) = roundedNumber