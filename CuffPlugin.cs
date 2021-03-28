using Rocket.API.Collections;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;

namespace Mroczny.CuffPlugin
{
    public class CuffPlugin : RocketPlugin<CuffPluginConfiguration>
    {
        public static CuffPlugin Instance { get; private set; }
        const string Version = "1.0.0";
        const string Creator = "Mroczny";
        public Color MessageColor { get; set; }

        protected override void Load()
        {
            Instance = this;
            MessageColor = UnturnedChat.GetColorFromName(Configuration.Instance.MessageColor, Color.green);
            Logger.LogWarning($"{Name} {Version} has been loaded!");
            Logger.LogWarning($"Plugin Made By {Creator}");
        }

        protected override void Unload()
        {
            Instance = null;
            Logger.LogWarning($"{Name} has been unloaded!");
        }

        public override TranslationList DefaultTranslations => new TranslationList(){
            {"CuffFormat","Use: /cuff <player>"},
            {"UncuffFormat","Use: /uncuff <player>"},
            {"PlayerNotFound","Player not found!"},
            {"CuffSuccess","Player {0} has been cuffed!"},
            {"UncuffSuccess","Player {0} has been uncuffed!"},
            {"SendPlayerCuffMessage","You've been cuffed!"},
            {"SendPlayerUncuffMessage","You've been uncuffed!"}
        };
    }
}
