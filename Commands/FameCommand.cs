using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Terraria.DataStructures;

namespace ROTMG_Items.Commands
{
	class FameCommand : ModCommand
	{
		public override CommandType Type
			=> CommandType.Chat;

		public override string Command
			=> "fame";

		public override string Description
			=> "Tells you your fame on death.";

		public override void Action(CommandCaller caller, string input, string[] args)
		{
			var fameOnDeath = (int)((ModContent.GetInstance<XPFunction>().XPLevel + ModContent.GetInstance<XPFunction>().XPTotal) * ModContent.GetInstance<FameConfig>().FameMultiplier);
			Main.NewText($"Your fame on death is {fameOnDeath}.");
		}
	}
}
