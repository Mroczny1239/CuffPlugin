using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System.Collections.Generic;

namespace Mroczny.CuffPlugin.Commands
{
    public class CommandCuff : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "Cuff";

        public string Help => "cuff players";

        public string Syntax => "<player>";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;

            if (command.Length < 1)
            {
                UnturnedChat.Say(caller, CuffPlugin.Instance.Translate("CuffFormat"), CuffPlugin.Instance.MessageColor);
                return;
            }

            var target = UnturnedPlayer.FromName(command[0]);

            if (target != null)
            {
                Cuff(target.Player);
                UnturnedChat.Say(caller, CuffPlugin.Instance.Translate("CuffSuccess", target.DisplayName), CuffPlugin.Instance.MessageColor);
                if (CuffPlugin.Instance.Configuration.Instance.SendPlayerCuffMessage)
                {
                    UnturnedChat.Say(target, CuffPlugin.Instance.Translate("SendPlayerCuffMessage"), CuffPlugin.Instance.MessageColor);
                }
            }
            else
            {
                UnturnedChat.Say(caller, CuffPlugin.Instance.Translate("PlayerNotFound"), UnityEngine.Color.red);
            }

            void Cuff(Player playerCuff)
            {
                playerCuff.equipment.dequip();
                playerCuff.animator.sendGesture(EPlayerGesture.ARREST_START, true);
            }
        }
    }
}
