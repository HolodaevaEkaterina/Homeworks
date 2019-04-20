module TestsForOOP

open NUnit.Framework
open ObjectiveOrientedProgramming

[<Test>]
let ``Network with 4 computers supporting a connected graph(All computers must be infected)``() =
    let Symbian = OS("Symbian", 0.7)
    let Windows = OS("Windows", 0.8)
    let Linux = OS("Linux", 0.6)
    let DOS = OS("DOS", 0.9)
    let firstMachine = Machine(Symbian, [])
    let secondMachine = Machine(Windows, [])
    let thirdMachine = Machine(Linux, [])
    let fourthtMachine = Machine(DOS, [])
    firstMachine.Connected <- [thirdMachine; secondMachine]
    secondMachine.Connected <- [firstMachine]
    thirdMachine.Connected <- [secondMachine; fourthtMachine]
    fourthtMachine.Connected <- [thirdMachine]
    firstMachine.TimeOfInfection <- 1
    let computers = [firstMachine; secondMachine; thirdMachine; fourthtMachine]
    let net = Net(computers)
    net.networkOperationModel()
    Assert.IsTrue(net.Computers.[0].TimeOfInfection <> 0)
    Assert.IsTrue(net.Computers.[1].TimeOfInfection <> 0)
    Assert.IsTrue(net.Computers.[2].TimeOfInfection <> 0)
    Assert.IsTrue(net.Computers.[3].TimeOfInfection <> 0)
 
[<Test>]
let ``Network with 4 computers in which 2 computers will never be infected ``() =
    let Symbian = OS("Symbian", 0.7)
    let Windows = OS("Windows", 0.9)
    let Linux = OS("Linux", 0.8)
    let DOS = OS("DOS", 0.6)
    let firstMachine = Machine(Symbian, [])
    let secondMachine = Machine(Windows, [])
    let thirdMachine = Machine(Linux, [])
    let fourthtMachine = Machine(DOS, [])
    firstMachine.Connected <- [secondMachine]
    secondMachine.Connected <- [firstMachine]
    thirdMachine.Connected <- [fourthtMachine]
    fourthtMachine.Connected <- [thirdMachine]
    firstMachine.TimeOfInfection <- 1
    let computers = [firstMachine; secondMachine; thirdMachine; fourthtMachine]
    let net = Net(computers)
    net.networkOperationModel()
    Assert.IsTrue(net.Computers.[0].TimeOfInfection <> 0)
    Assert.IsTrue(net.Computers.[1].TimeOfInfection <> 0)
    Assert.IsTrue(net.Computers.[2].TimeOfInfection = 0)
    Assert.IsTrue(net.Computers.[3].TimeOfInfection = 0)

[<Test>]
let ``Network with 2 infected computers``() =
    let Symbian = OS("Symbian", 0.7)
    let Windows = OS("Windows", 0.8)
    let Linux = OS("Linux", 0.6)
    let DOS = OS("DOS", 0.9)
    let firstMachine = Machine(Symbian, [])
    let secondMachine = Machine(Windows, [])
    let thirdMachine = Machine(Linux, [])
    let fourthtMachine = Machine(DOS, [])
    firstMachine.Connected <- [secondMachine]
    secondMachine.Connected <- [firstMachine]
    thirdMachine.Connected <- [fourthtMachine]
    fourthtMachine.Connected <- [thirdMachine]
    firstMachine.TimeOfInfection <- 1
    thirdMachine.TimeOfInfection <- 1
    let computers = [firstMachine; secondMachine; thirdMachine; fourthtMachine]
    let net = Net(computers)
    net.networkOperationModel()
    Assert.IsTrue(net.Computers.[0].TimeOfInfection <> 0)
    Assert.IsTrue(net.Computers.[1].TimeOfInfection <> 0)
    Assert.IsTrue(net.Computers.[2].TimeOfInfection <> 0)
    Assert.IsTrue(net.Computers.[3].TimeOfInfection <> 0)