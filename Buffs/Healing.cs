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

        int timer = 60;
        public override void Update(Player player, ref int buffIndex)
        {
            timer--;
            if(timer <= 0)
            {
                timer = 60;
                player.statLife += 1;
            }
            player.lifeRegen += 5;
        }
    }
}