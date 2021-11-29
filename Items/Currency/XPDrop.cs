using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace ROTMG_Items.Items.Currency
{
    class XPDrop : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault(" ");
        }
        public override void SetDefaults()
        {
            item.width = 900;
            item.height = 900;
            item.maxStack = 999;
        }

        public override bool OnPickup(Player player)
        {
            if (!Main.hardMode)
            {
                int preHardXP = Main.rand.Next(1, 20);
                player.GetModPlayer<XPFunction>().XP += preHardXP;
                player.GetModPlayer<XPFunction>().XPTotal += preHardXP;
            }
            else if (Main.hardMode)
            {
                int hardXP = Main.rand.Next(40, 80);
                player.GetModPlayer<XPFunction>().XP += hardXP;
                player.GetModPlayer<XPFunction>().XPTotal += hardXP;
            }
            else if (NPC.downedPlantBoss)
            {
                int downPlant = Main.rand.Next(40, 200);
                player.GetModPlayer<XPFunction>().XP += downPlant;
                player.GetModPlayer<XPFunction>().XPTotal += downPlant;
            }
            else if (NPC.downedMoonlord)
            {
                int downMoon = Main.rand.Next(200, 400);
                player.GetModPlayer<XPFunction>().XP += downMoon;
                player.GetModPlayer<XPFunction>().XPTotal += downMoon;
            }
            return false;
        }
    }
}
