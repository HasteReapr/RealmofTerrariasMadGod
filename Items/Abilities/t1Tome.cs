using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ROTMG_Items.Items.Materials;

namespace ROTMG_Items.Items.Abilities
{
    public class t1Tome : AncientCostFunction
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Remedy Tome");
            Tooltip.SetDefault("Heals 40 HP and gives healing.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 15;
            item.useTime = 15;
            AncientCost = 20;
            item.rare = ItemRarityID.Green;
            item.buffType = ModContent.BuffType<Buffs.Healing>();
            item.buffTime = 300;
            item.value = Item.buyPrice(gold: 1);
            isAbility = true;
        }

        public override bool UseItem(Player player)
        {
            player.statLife += 40;
            for (int i = 0; i < Main.maxPlayers; i++)
                if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                {
                    Main.player[i].AddBuff(ModContent.BuffType<Buffs.Healing>(), 300, false);
                    Main.player[i].statLife += 40;
                }
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Book);
            recipe.AddIngredient(ItemID.LesserHealingPotion, 10);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}