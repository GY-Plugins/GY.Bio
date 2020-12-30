namespace GY.Owner

open Rocket.API
open Rocket.Unturned.Chat
open Rocket.Unturned.Player
open UnityEngine

type CommandBio() =
    interface IRocketCommand with
        member this.AllowedCaller = AllowedCaller.Player
        member this.Name = "Bio"
        member this.Help = ""
        member this.Syntax = "/Bio [nick | steam]"
        member this.Aliases = ResizeArray []
        member this.Permissions = ResizeArray [ "gy.bio" ]
        member this.Execute(caller: IRocketPlayer, command: string []) =
            let current = CommandBio() :> IRocketCommand
            if command.Length >= 1 then
                let player = UnturnedPlayer.FromName(command.[0])
                if isNull player then
                    UnturnedChat.Say(caller, "Игрок не найден!", Color.red)
                else
                    UnturnedChat.Say(caller, sprintf "Nick: %s" player.DisplayName, Color.cyan)
                    UnturnedChat.Say(caller, sprintf "Steam ID: %u" player.CSteamID.m_SteamID, Color.cyan)
                    UnturnedChat.Say(caller, sprintf "Steam Nick: %s" player.SteamName, Color.cyan)
                    UnturnedChat.Say(caller, sprintf "Steam Group: %u" player.SteamGroupID.m_SteamID, Color.cyan)
                    UnturnedChat.Say(caller, sprintf "IP: %s" player.IP, Color.cyan)
                    UnturnedChat.Say(caller, sprintf "Ping: %f" player.Ping, Color.cyan)
                    
            else
                UnturnedChat.Say(caller, sprintf "Команда введена неверно, используйте %s." current.Name, Color.red)