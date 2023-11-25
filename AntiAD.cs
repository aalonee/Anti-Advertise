using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.Events.Commands.Reload;
using Exiled.Events.EventArgs;
using Exiled.Events.EventArgs.Player;
using PluginAPI.Events;

namespace Plugin
{
    public sealed class Plugin : Plugin<Config>
    {
        List<String> AvailableModes = new List<String>() { "rename", "kick", "ban" };

        public override PluginPriority Priority { get; } = PluginPriority.Default;
        public override string Name { get; } = "AntiAD";

        public override string Author { get; } = "alone";

        public override string Prefix { get; } = "AntiAD";

        public override void OnEnabled()
        {
            base.OnEnabled();
            if (AvailableModes.Contains(Config.Action))
            {
                Exiled.Events.Handlers.Player.Verified += OnPlayerVerified;
            }
            else
            {
                Log.Error(" ");
                Log.Error($"Plugin mode \"{Config.Action}\" is invalid");
                Log.Error(" ");
            }
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            Exiled.Events.Handlers.Player.Verified -= OnPlayerVerified;
        }

        public void OnPlayerVerified(VerifiedEventArgs ev)
        {
            if (Config.ad.Any(ad => ev.Player.Nickname.ToLower().Contains(ad)))
            {
                if (Config.Action.ToLower() == "rename")
                {
                    ev.Player.CustomName = Config.Nickname;
                    if (Config.Debug)
                    {
                        Log.Debug($"{ev.Player.Nickname} was renamed for advertising in the nickname");
                    }
                }
                if (Config.Action.ToLower() == "kick")
                {
                    ev.Player.Kick(Config.Kick_msg);
                    if (Config.Debug)
                    {
                        Log.Debug($"{ev.Player.Nickname} was kicked for advertising in the nickname");
                    }
                }
                if (Config.Action.ToLower() == "ban")
                {
                    ev.Player.Ban(Config.BanDuration, Config.Kick_msg);
                    if (Config.Debug)
                    {
                        Log.Debug($"{ev.Player.Nickname} was banned for advertising in the nickname");
                    }
                }
            }
        }
    }
}