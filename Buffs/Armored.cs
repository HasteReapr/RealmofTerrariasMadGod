using Terraria;
using Terraria.ModLoader;

namespace ROTMG_Items.Buffs
{
    public class Armored : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Armored");
            Description.SetDefault("You feel powerful.\nIncreases your defense by 30.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 30;
        }
    }
}