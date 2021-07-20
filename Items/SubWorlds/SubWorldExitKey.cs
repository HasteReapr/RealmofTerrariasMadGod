using Terraria.ModLoader;
using Terraria.ID;
using SubworldLibrary;
using Terraria;

namespace ROTMG_Items.Items.SubWorlds
{
    class SubWorldExitKey : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Exit Subworld Key");
            Tooltip.SetDefault("Teleports you to the main world.\nCAUTION:The subworlds do NOT save. Once you leave it is deleted!");
        }

        public override void SetDefaults()
        {
            item.height = 34;
            item.width = 34;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.maxStack = 1;
        }

        public override bool UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                Subworld.Exit();
            }

            return true;
        }
    }
}
