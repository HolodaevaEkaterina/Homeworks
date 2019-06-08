module TestsForOOP

open NUnit.Framework
open ObjectiveOrientedProgramming
open System

[<Test>]
let ``Network with 4 computers supporting a connected graph(All computers must be infected)``() =
    let symbian = OS("Symbian", 0.7)
    let windows = OS("Windows", 0.8)
    let linux = OS("Linux", 0.6)
    let dos = OS("DOS", 0.9)
    let firstMachine = Machine(symbian, [])
    let secondMachine = Machine(windows, [])
    let thirdMachine = Machine(linux, [])
    let fourthtMachine = Machine(dos, [])
    firstMachine.Connected <- [thirdMachine; secondMachine]
    secondMachine.Connected <- [firstMachine]
    thirdMachine.Connected <- [secondMachine; fourthtMachine]
    fourthtMachine.Connected <- [thirdMachine]
    firstMachine.TimeOfInfection <- 1
    let computers = [firstMachine; secondMachine; thirdMachine; fourthtMachine]
    let rand = new Random((int)DateTime.UtcNow.Ticks)
    let net = Net(computers, rand)
    net.NetworkOperationModel()
    Assert.IsTrue(net.Computers.[0].TimeOfInfection <> 0)
    Assert.IsTrue(net.Computers.[1].TimeOfInfection <> 0)
    Assert.IsTrue(net.Computers.[2].TimeOfInfection <> 0)
    Assert.IsTrue(net.Computers.[3].TimeOfInfection <> 0)
 
[<Test>]
let ``Network with 4 computers in which 2 computers will never be infected ``() =
    let symbian = OS("Symbian", 0.7)
    let windows = OS("Windows", 0.9)
    let linux = OS("Linux", 0.8)
    let dos = OS("DOS", 0.6)
    let firstMachine = Machine(symbian, [])
    let secondMachine = Machine(windows, [])
    let thirdMachine = Machine(linux, [])
    let fourthtMachine = Machine(dos, [])
    firstMachine.Connected <- [secondMachine]
    secondMachine.Connected <- [firstMachine]
    thirdMachine.Connected <- [fourthtMachine]
    fourthtMachine.Connected <- [thirdMachine]
    firstMachine.TimeOfInfection <- 1
    let computers = [firstMachine; secondMachine; thirdMachine; fourthtMachine]
    let rand = new Random((int)DateTime.UtcNow.Ticks)
    let net = Net(computers, rand)
    net.NetworkOperationModel()
    Assert.IsTrue(net.Computers.[0].TimeOfInfection <> 0)
    Assert.IsTrue(net.Computers.[1].TimeOfInfection <> 0)
    Assert.IsTrue(net.Computers.[2].TimeOfInfection = 0)
    Assert.IsTrue(net.Computers.[3].TimeOfInfection = 0)

[<Test>]
let ``Network with 2 infected computers``() =
    let symbian = OS("Symbian", 0.7)
    let windows = OS("Windows", 0.8)
    let linux = OS("Linux", 0.6)
    let dos = OS("DOS", 0.9)
    let firstMachine = Machine(symbian, [])
    let secondMachine = Machine(windows, [])
    let thirdMachine = Machine(linux, [])
    let fourthtMachine = Machine(dos, [])
    firstMachine.Connected <- [secondMachine]
    secondMachine.Connected <- [firstMachine]
    thirdMachine.Connected <- [fourthtMachine]
    fourthtMachine.Connected <- [thirdMachine]
    firstMachine.TimeOfInfection <- 1
    thirdMachine.TimeOfInfection <- 1
    let computers = [firstMachine; secondMachine; thirdMachine; fourthtMachine]
    let rand = new Random((int)DateTime.UtcNow.Ticks)
    let net = Net(computers, rand)
    net.NetworkOperationModel()
    Assert.IsTrue(net.Computers.[0].TimeOfInfection <> 0)
    Assert.IsTrue(net.Computers.[1].TimeOfInfection <> 0)
    Assert.IsTrue(net.Computers.[2].TimeOfInfection <> 0)
    Assert.IsTrue(net.Computers.[3].TimeOfInfection <> 0)