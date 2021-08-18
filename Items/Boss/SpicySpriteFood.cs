using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Boss
{
    class SpicySpriteFood : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spicy Sprite Food");
            Tooltip.SetDefault("The favorite food of some big sprite...");
            ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.rare = ItemRarityID.Cyan;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.UseSound = SoundID.Item44;
            item.consumable = true;
            item.maxStack = 20;
        }

        public override bool CanUseItem(Player player)
        {
            // "player.ZoneUnderworldHeight" could also be written as "player.position.Y / 16f > Main.maxTilesY - 200"
            return NPC.downedBoss1;
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Bosses.SpriteGoddess>());
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
    }
}
