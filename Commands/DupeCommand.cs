using ROTMG_Items.UI;
using Terraria.ModLoader;

namespace ROTMG_Items.Commands
{
	class DupeCommand : ModCommand
	{
		public override CommandType Type
			=> CommandType.Chat;

		public override string Command
			=> "dupe";

		public override string Description
			=> "Show the dupe UI";

		public override void Action(CommandCaller caller, string input, string[] args)
		{
			DupeUIPanel.Visible = true;
		}
	}
}
