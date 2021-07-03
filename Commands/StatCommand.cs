using ROTMG_Items.UI;
using Terraria.ModLoader;

namespace ROTMG_Items.Commands
{
    class StatCommand : ModCommand
    {
		public override CommandType Type
			=> CommandType.Chat;

		public override string Command
			=> "stats";

		public override string Description
			=> "Show the stats UI";

		public override void Action(CommandCaller caller, string input, string[] args)
		{
			StatUI.Visible = true;
		}
	}
}
