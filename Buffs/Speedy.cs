using Terraria;
using Terraria.ModLoader;

namespace ROTMG_Items.Buffs
{
    public class Speedy : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Speedy");
            Description.SetDefault("You feel immensely fast. \nIncrease run speed by 35%");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed *= 1.35f;
            player.maxRunSpeed *= 1.35f;
            player.runAcceleration += .35f;
        }
    }
}