using Terraria;
using Terraria.ModLoader;

namespace ROTMG_Items.Buffs
{
    public class Damaging : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Damaging");
            Description.SetDefault("You feel as though you could hurl a mountain.\nDamage increased by 25%.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.allDamage *= 1.25f;
        }
    }
}