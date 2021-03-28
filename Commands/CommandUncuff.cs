using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System.Collections.Generic;

namespace Mroczny.CuffPlugin.Commands
{
    public class CommandUncuff : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "Uncuff";

        public string Help => "uncuff players";

        public string Syntax => "<player>";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (command.Length < 1)
            {
                UnturnedChat.Say(caller, CuffPlugin.Instance.Translate("UncuffFormat"), CuffPlugin.Instance.MessageColor);
                return;
            }

            var target = UnturnedPlayer.FromName(command[0]);

            if (target != null)
            {
                Uncuff(target.Player);
                UnturnedChat.Say(caller, CuffPlugin.Instance.Translate("UncuffSuccess", target.DisplayName), CuffPlugin.Instance.MessageColor);
                if (CuffPlugin.Instance.Configuration.Instance.SendPlayerUncuffMessage)
                {
                    UnturnedChat.Say(target, CuffPlugin.Instance.Translate("SendPlayerUncuffMessage"), CuffPlugin.Instance.MessageColor);
                }
            }
            else
            {
                UnturnedChat.Say(caller, CuffPlugin.Instance.Translate("PlayerNotFound"), UnityEngine.Color.red);
            }
        }

        void Uncuff(Player playerUncuff)
        {
            playerUncuff.animator.sendGesture(EPlayerGesture.ARREST_STOP, true);
        }
    }
}
