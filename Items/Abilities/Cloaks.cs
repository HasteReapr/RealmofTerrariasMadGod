using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ROTMG_Items.Items.Materials;

namespace ROTMG_Items.Items.Abilities
{
    public class Cloaks : AncientCostFunction
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cloak of Invisibility");
            Tooltip.SetDefault("Makes you invisible.\nWhile invisible, no enemies will target you.\nA cloak made of a magical essense that hides the user from sight.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            AncientCost = 20;
            item.rare = ItemRarityID.Green;
            item.value = Item.buyPrice(gold: 1);
            item.buffType = ModContent.BuffType<Buffs.RogueInvisible>();
            item.buffTime = 540;
            isAbility = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 15);
            recipe.AddIngredient(ItemID.InvisibilityPotion);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }



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
            recipe.AddIngredient(ModContent.ItemType<Cloaks>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }



    public class t3Cloak : AncientCostFunction
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cloak of the Goblin Thieves");
            Tooltip.SetDefault("Makes you invisible.\nWhile invisible, no enemies will target you.\nA cloak used by goblin thieves to cloak themselves.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            AncientCost = 35;
            item.rare = ItemRarityID.Green;
            item.value = Item.buyPrice(gold: 9);
            item.buffType = ModContent.BuffType<Buffs.RogueInvisible>();
            item.buffTime = 900;
            isAbility = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<UnholyEssence>());
            recipe.AddIngredient(ModContent.ItemType<t2Cloak>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }



    public class t4Cloak : AncientCostFunction
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cloak of the Mechanical Rogues");
            Tooltip.SetDefault("Makes you invisible.\nWhile invisible, no enemies will target you.\nA cloak used by mechanical rogues designed to steal treasures\nfrom even the most elaborate lairs.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            AncientCost = 40;
            item.rare = ItemRarityID.Green;
            item.value = Item.buyPrice(gold: 9);
            item.buffType = ModContent.BuffType<Buffs.RogueInvisible>();
            item.buffTime = 1080;
            isAbility = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<MechanicalEssence>());
            recipe.AddIngredient(ModContent.ItemType<t3Cloak>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }



    public class t5Cloak : AncientCostFunction
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cloak of the Plant Thieves");
            Tooltip.SetDefault("Makes you invisible.\nWhile invisible, no enemies will target you.\nA cloak designed to hide stealthily in the jungle.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            AncientCost = 45;
            item.rare = ItemRarityID.Green;
            item.value = Item.buyPrice(gold: 9);
            item.buffType = ModContent.BuffType<Buffs.RogueInvisible>();
            item.buffTime = 1260;
            isAbility = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<HerbalEssence>());
            recipe.AddIngredient(ModContent.ItemType<t4Cloak>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }



    public class t6Cloak : AncientCostFunction
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cloak of the Lunar Thieves");
            Tooltip.SetDefault("Makes you invisible.\nWhile invisible, no enemies will target you.\nA cloak made from otherwordly silk. It is designed specifically so nothing can spot you, ever.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            AncientCost = 50;
            item.rare = ItemRarityID.Green;
            item.value = Item.buyPrice(gold: 9);
            item.buffType = ModContent.BuffType<Buffs.RogueInvisible>();
            item.buffTime = 1440;
            isAbility = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<LunarEssence>());
            recipe.AddIngredient(ModContent.ItemType<t5Cloak>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}