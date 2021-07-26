using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ROTMG_Items.Items.Materials;

namespace ROTMG_Items.Items.Abilities
{
    public class t3Tome : AncientCostFunction
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tome of Rejuvination");
            Tooltip.SetDefault("Heals 100 HP and gives healing.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 15;
            item.useTime = 15;
            AncientCost = 40;
            item.rare = ItemRarityID.Green;
            item.buffType = ModContent.BuffType<Buffs.Healing>();
            item.buffTime = 300;
            item.value = Item.buyPrice(gold: 1);
            isAbility = true;
        }

        public override bool UseItem(Player player)
        {
            player.statLife += 100;
            for (int i = 0; i < Main.maxPlayers; i++)
                if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                {
                    Main.player[i].AddBuff(ModContent.BuffType<Buffs.Healing>(), 540, false);
                    Main.player[i].statLife += 100;
                }
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<t2Tome>());
            recipe.AddIngredient(ModContent.ItemType<UnholyEssence>());
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(this);
        }
    }
}