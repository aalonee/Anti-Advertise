using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace Plugin
{
    public class Config : IConfig
    {
        [Description("Is plugin enabled")]
        public bool IsEnabled { get; set; } = true;

        [Description("Should debug (show kick logs in the server console)")]
        public bool Debug { get; set; } = false;

        [Description("The action to perform (rename/kick/ban. rename by default)")]
        public string Action { get; set; } = "rename";

        [Description("The nickname to replace nicknames containing ads with if the \"rename\" mode is selected")]
        public string Nickname { get; set; } = "[ADVERTISEMENT]";

        [Description("Ban duration in seconds if the \"ban\" mode is selected")]
        public int BanDuration { get; set; } = 60;

        [Description("Kick message")]
        public string Kick_msg { get; set; } = "[ANTI AD] Please remove the ads from your nickname and restart the game.";

        [Description("Banned words")]
        public List<string> ad { get; set; } = new List<string>() { ".com", ".su", ".net", ".ru", ".me", ".ovh", ".xyz", ".site", ".online", ".eu", ".ua", ".shop", ".рф", ".biz", ".tv", ".gg", ".io", ".uy", ".de", ".co", ".uk", ".at", ".kz", ".cz"};
    }
}