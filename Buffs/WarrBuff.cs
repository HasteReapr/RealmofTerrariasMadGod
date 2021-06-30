using Terraria;
using Terraria.ModLoader;

namespace ROTMG_Items.Buffs
{
    public class WarrBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Berserker");
            Description.SetDefault("You feel a rage build inside you, so much so that you could tear through a whole goblin army. \nTemporarily increases your attack speed by 75%.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            Main.LocalPlayer.GetModPlayer<ROTMGPlayer>().WarriorBuff = true;
        }
    }
}