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
            if (NPC.downedBoss1)
            {
                player.GetModPlayer<XPFunction>().XP += Main.rand.Next(10, 200);
                player.GetModPlayer<XPFunction>().XPTotal += Main.rand.Next(10, 200);
            }
            else if (NPC.downedBoss2)
            {
                player.GetModPlayer<XPFunction>().XP += Main.rand.Next(300, 500);
                player.GetModPlayer<XPFunction>().XPTotal += Main.rand.Next(300, 500);
            }
            else if (NPC.downedPlantBoss)
            {
                player.GetModPlayer<XPFunction>().XP += Main.rand.Next(600, 900);
                player.GetModPlayer<XPFunction>().XPTotal += Main.rand.Next(600, 900);
            }
            else if (NPC.downedGolemBoss)
            {
                player.GetModPlayer<XPFunction>().XP += Main.rand.Next(1000, 1300);
                player.GetModPlayer<XPFunction>().XPTotal += Main.rand.Next(1000, 1300);
            }
            else if (NPC.downedMoonlord)
            {
                player.GetModPlayer<XPFunction>().XP += Main.rand.Next(1500, 2500);
                player.GetModPlayer<XPFunction>().XPTotal += Main.rand.Next(1500, 2500);
            }
            return false;
        }
    }
}
