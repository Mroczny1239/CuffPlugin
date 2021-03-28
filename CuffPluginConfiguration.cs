using Rocket.API;

namespace Mroczny.CuffPlugin
{
    public class CuffPluginConfiguration : IRocketPluginConfiguration
    {
        public string MessageColor { get; set; }
        public bool SendPlayerCuffMessage { get; set; }
        public bool SendPlayerUncuffMessage { get; set; }

        public void LoadDefaults()
        {
            MessageColor = "cyan";
            SendPlayerCuffMessage = true;
            SendPlayerUncuffMessage = true;
        }
    }
}
