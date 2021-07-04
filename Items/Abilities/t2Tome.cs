﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Abilities
{
    public class t2Tome : AncientCostFunction
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spirit Salve Tome");
            Tooltip.SetDefault("Heals 70 HP and gives healing.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 15;
            item.useTime = 15;
            AncientCost = 30;
            item.rare = ItemRarityID.Green;
            item.buffType = ModContent.BuffType<Buffs.Healing>();
            item.buffTime = 300;
            item.value = Item.buyPrice(gold: 1);
        }

        public override bool UseItem(Player player)
        {
            player.statLife += 70;
            for (int i = 0; i < Main.maxPlayers; i++)
                if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                {
                    Main.player[i].AddBuff(ModContent.BuffType<Buffs.Healing>(), 420, false);
                    Main.player[i].statLife += 70;
                }
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<t1Tome>());
            recipe.AddIngredient(ModContent.ItemType<GreaterEssence>());
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(this);
        }
    }
}