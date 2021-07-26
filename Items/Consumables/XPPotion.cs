using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace ROTMG_Items.Items.Consumables
{
    class XPPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Minor Experience Potion");
            Tooltip.SetDefault("A potion that increases your current XP level by 10.");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 17;
            item.useTime = 17;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = ItemRarityID.Orange;
            item.value = Item.buyPrice(gold: 1);
        }

        public override bool UseItem(Player player)
        {
            player.GetModPlayer<XPFunction>().XP += 10;
            player.GetModPlayer<XPFunction>().XPTotal += 10;
            return true;
        }
    }
}
