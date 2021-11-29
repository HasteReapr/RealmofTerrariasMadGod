using Terraria.ModLoader;
using Terraria.ID;
using SubworldLibrary;
using Terraria;

namespace ROTMG_Items.Items.SubWorlds
{
    class TestWorldKey : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Test World Key");
            Tooltip.SetDefault("Admin Item\nTeleports you to the Testing Subworld.");
        }

        public override void SetDefaults()
        {
            item.height = 34;
            item.width = 34;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.maxStack = 1;
            item.consumable = false;
        }

        public override bool UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                Subworld.Enter<TestWorld>();
            }

            return true;
        }
    }
}
