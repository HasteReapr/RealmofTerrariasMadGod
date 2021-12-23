using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ROTMG_Items.Buffs
{
    public class RogueInvisible : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("True Invisibility");
            Description.SetDefault("Nothing can detect you... but you're not invincible.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.aggro -= 16000000;
            //something with alpha values
        }
    }
}