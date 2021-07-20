using Terraria.ID;
using ROTMG_Items;
using Terraria.ModLoader;
using Terraria;

namespace ROTMG_Items.Items.Consumables
{
    class SpookySigil : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lost Sigil");
            Tooltip.SetDefault("Wards of the lost paladins.");
        }

        public override void SetDefaults()
        {
            item.consumable = true;
            item.maxStack = 999;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useTime = 15;
            item.useAnimation = 15;
        }

        public override bool UseItem(Player player)
        {
            player.GetModPlayer<ROTMGPlayer>().moonded = true;
            return true;
        }
    }
}
