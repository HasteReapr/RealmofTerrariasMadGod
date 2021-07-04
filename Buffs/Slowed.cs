using Terraria;
using Terraria.ModLoader;

namespace ROTMG_Items.Buffs
{
    public class Slowed : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Slowed");
            Description.SetDefault("You're bloated.\nDecreases your movement by 80%.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed *= 0.2f;
        }
    }
}