using Terraria;
using Terraria.ModLoader;

namespace ROTMG_Items.Buffs
{
    public class HPBoost : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Health Boost");
            Description.SetDefault("You feel healthier.\nIncreases maximum life by 80.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statLifeMax2 += 80;
        }
    }
}