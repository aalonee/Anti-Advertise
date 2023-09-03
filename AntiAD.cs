using System;
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
        public override PluginPriority Priority { get; } = PluginPriority.Default;
        public override string Name { get; } = "AntiAD";

        public override string Author { get; } = "alone";

        public override string Prefix { get; } = "AntiAD";

        public override void OnEnabled()
        {
            Exiled.Events.Handlers.Player.Verified += OnPlayerVerified;
            Log.Info("Plugin enabled");
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.Verified -= OnPlayerVerified;
            Log.Info("Plugin disabled");
        }

        public void OnPlayerVerified(VerifiedEventArgs ev)
        {
            foreach (string s in Config.ad)
            {
                if (ev.Player.Nickname.Contains(s))
                {
                    if (Config.Action == "rename")
                    {
                        ev.Player.CustomName = Config.Nickname;
                        if (Config.Debug)
                        {
                            Log.Debug($"{ev.Player.Nickname} was renamed for advertising in the nickname");
                        }
                    }
                    if (Config.Action == "kick")
                    {
                        ev.Player.Kick(Config.Kick_msg);
                        if (Config.Debug)
                        {
                            Log.Debug($"{ev.Player.Nickname} was kicked for advertising in the nickname");
                        }
                    }
                    if (Config.Action == "ban")
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
}