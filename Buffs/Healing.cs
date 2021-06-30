using Terraria;
using Terraria.ModLoader;

namespace ROTMG_Items.Buffs
{
    public class Healing : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Healing");
            Description.SetDefault("You feel rejuvinated.\nIncreases life healing.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen += 5;
        }
    }
}