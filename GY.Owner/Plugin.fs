module GY.Owner.Plugin

open System
open Rocket.Core.Logging
open Rocket.Core.Plugins

type public Plugin() =
         inherit RocketPlugin()   
           override this.Load() =
               Logger.Log("Loading F# Unturned plugin!", ConsoleColor.Cyan)
           override this.Unload() =
               Logger.Log("Unloading F# Unturned plugin!", ConsoleColor.Yellow)
               