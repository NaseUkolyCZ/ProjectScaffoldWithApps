﻿namespace FSharp.ProjectTemplate

open FSharp.ProjectTemplate.Domain
open Serilog
open System

/// Documentation for my library
///
/// ## Example
///
///     let h = Library.hello {"John";"Rambo"}
///     printfn "%s" h
///
module Library = 
  
    Log.Information( "Library FSharp.ProjectTemplate loaded" )

    // the support methods
    type SaveLastHello =
        Person -> unit
    type LoadLastHello =
        Person -> DateTime

    /// Returns Hello firstName lastName, I saw you for the last time on 1.1.1970
    ///
    /// ## Parameters
    ///  - `person` - someone you would like to say hello to
    let hello (loadLastHello:LoadLastHello, saveLastHello:SaveLastHello) (person : Person) = 
        sprintf "Hello %s %s, I saw you for the last time on %O" person.FirstName person.LastName (loadLastHello(person))
        saveLastHello (person)

    let api (loadLastHello:LoadLastHello, saveLastHello:SaveLastHello) = {
        Hello = hello (loadLastHello, saveLastHello)
    }
