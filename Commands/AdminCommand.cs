using Terraria.ModLoader;
using ROTMG_Items.Buffs;

namespace ROTMG_Items.Commands
{
	class AdminCommand : ModCommand
	{
		public override CommandType Type
			=> CommandType.Chat;

		public override string Command
			=> "admin";

		public override string Description
			=> "Gives you godmode.";

		public override void Action(CommandCaller caller, string input, string[] args)
		{
			if(caller.Player.name.Equals("HasteReapr") || caller.Player.name.Equals("Test Subject"))
            {
				caller.Player.statLifeMax2 = int.MaxValue;
				caller.Player.lifeRegen = int.MaxValue;
				caller.Player.statDefense = int.MaxValue;
				caller.Player.AddBuff(ModContent.BuffType<Invulnerable>(), int.MaxValue);
				caller.Player.AddBuff(ModContent.BuffType<WarrBuff>(), int.MaxValue);
            }
            else
            {
				caller.Player.AddBuff(ModContent.BuffType<VoidSickness>(), int.MaxValue);
            }
		}
	}
}
