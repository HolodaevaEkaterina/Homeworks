﻿module ObjectiveOrientedProgramming

type OS(name : string, probability : double) =
    member val Name = name with get
    member val Probability = probability with get

type Machine(os : OS, connectedMachine : list<Machine>) =
    member val Os = os with get
    member val Connected = connectedMachine with get, set
    member val TimeOfInfection = 0 with get, set

 type Net(computers : list<Machine>) =
    let mutable time = 1
    let areAllMachinesInfected(connectedComp : list<Machine>) = 
      not <| List.exists(fun (elem : Machine) -> elem.TimeOfInfection <> time) connectedComp
    let areInfected(comp : Machine) = not <| (comp.TimeOfInfection <> time)
     
    ///1 step virus action 
    member this.VirusEpidemic() =
        for comp in computers do
            if comp.TimeOfInfection = time then
                for connectedComp in comp.Connected do
                    if (connectedComp.TimeOfInfection <> time) && (System.Random().NextDouble() <= connectedComp.Os.Probability) then
                        connectedComp.TimeOfInfection <- time + 1
                comp.TimeOfInfection <- time + 1
        time <- time + 1

    member val Computers = computers with get
    
    ///Infection of computers occurs until all neighbors of the infected computer are infected
    member this.networkOperationModel() =
        for comp in computers do
            if areInfected(comp) then
                while (not <|areAllMachinesInfected(comp.Connected)) do
                    this.VirusEpidemic()
                    let numberOfInfectedComputers = List.length <| List.filter(fun (elem : Machine) -> areInfected(elem)) computers
                    printfn "%d computers are infected" <| numberOfInfectedComputers