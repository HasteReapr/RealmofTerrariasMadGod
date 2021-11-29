using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ROTMG_Items.Buffs
{
    class Inspired : ModBuff
    //in GlobalItem Shoot() multiply SpeedX, SpeedY by 1.5.
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Inspired!");
            Description.SetDefault("You feel inspired!\nIncreases projectile speed by 50%");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }
    }
}
