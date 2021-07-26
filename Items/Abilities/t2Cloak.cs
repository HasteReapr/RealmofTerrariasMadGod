using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ROTMG_Items.Items.Materials;

namespace ROTMG_Items.Items.Abilities
{
    public class t2Cloak : AncientCostFunction
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cloak of Stealth");
            Tooltip.SetDefault("Makes you invisible.\nWhile invisible, no enemies will target you.\nA cloak fabricated by a more potent cloth, hiding the user longer.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            AncientCost = 30;
            item.rare = ItemRarityID.Green;
            item.value = Item.buyPrice(gold: 5);
            item.buffType = ModContent.BuffType<Buffs.RogueInvisible>();
            item.buffTime = 720;
            isAbility = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<GreaterEssence>());
            recipe.AddIngredient(ModContent.ItemType<t1Cloak>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}