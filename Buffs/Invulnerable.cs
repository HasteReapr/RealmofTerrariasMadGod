using Terraria;
using Terraria.ModLoader;

namespace ROTMG_Items.Buffs
{
    public class Invulnerable : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Invulnerable");
            Description.SetDefault("You are immortal. Nothing can harm you.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }
    }
}