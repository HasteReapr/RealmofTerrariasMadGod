using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ROTMG_Items.Items.Materials;
using Microsoft.Xna.Framework;
using ROTMG_Items.Items.Abilities.Projectiles;

namespace ROTMG_Items.Items.Abilities
{
    public class Seals : AncientCostFunction
    {
        //t1 Seal
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Seal of the Monk");
            Tooltip.SetDefault("A seal used by monks to bless others.\nIncreases your damage by 25%.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 15;
            item.useTime = 15;
            AncientCost = 20;
            item.shootSpeed = 0;
            item.shoot = ModContent.ProjectileType<SealProjectile>();
            item.shootSpeed = 0;
            item.rare = ItemRarityID.Green;
            item.value = Item.buyPrice(gold: 1);
            isAbility = true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * item.shootSpeed, item.shoot, item.damage, item.knockBack, player.whoAmI, 0, tier);
            return false;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<Buffs.Damaging>(), 300, false);
            for (int i = 0; i < Main.maxPlayers; i++)
                if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                {
                    Main.player[i].AddBuff(ModContent.BuffType<Buffs.Damaging>(), 300, false);
                }
            return true;
        }
    }



    public class t2Seal : AncientCostFunction
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Seal of of the Monk");
            Tooltip.SetDefault("A seal used by monks to bless others.\nIncreases your damage by 25%.\nIncreases your healing.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 15;
            item.useTime = 15;
            AncientCost = 35;
            item.rare = ItemRarityID.Green;
            item.value = Item.buyPrice(gold: 1);
            isAbility = true;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<Buffs.Damaging>(), 420, false);
            player.AddBuff(ModContent.BuffType<Buffs.Healing>(), 420, false);
            for (int i = 0; i < Main.maxPlayers; i++)
                if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                {
                    Main.player[i].AddBuff(ModContent.BuffType<Buffs.Damaging>(), 420, false);
                    Main.player[i].AddBuff(ModContent.BuffType<Buffs.Healing>(), 420, false);
                }
            return true;
        }
    }



    public class t3Seal : AncientCostFunction
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Seal of of the Monk");
            Tooltip.SetDefault("A seal used by monks to bless others.\nIncreases your damage by 25%.\nIncreases your healing.");
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
            item.value = Item.buyPrice(gold: 1);
            isAbility = true;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<Buffs.Damaging>(), 540, false);
            player.AddBuff(ModContent.BuffType<Buffs.Healing>(), 540, false);
            for (int i = 0; i < Main.maxPlayers; i++)
                if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                {
                    Main.player[i].AddBuff(ModContent.BuffType<Buffs.Damaging>(), 540, false);
                    Main.player[i].AddBuff(ModContent.BuffType<Buffs.Healing>(), 540, false);
                }
            return true;
        }
    }



    public class t4Seal : AncientCostFunction
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Seal of of the Monk");
            Tooltip.SetDefault("A seal used by monks to bless others.\nIncreases your damage by 25%.\nIncreases your healing.\nIncreases your health by 80.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 15;
            item.useTime = 15;
            AncientCost = 50;
            item.rare = ItemRarityID.Green;
            item.value = Item.buyPrice(gold: 1);
            isAbility = true;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<Buffs.Damaging>(), 660, false);
            player.AddBuff(ModContent.BuffType<Buffs.Healing>(), 660, false);
            player.AddBuff(ModContent.BuffType<Buffs.HPBoost>(), 660, false);
            for (int i = 0; i < Main.maxPlayers; i++)
                if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                {
                    Main.player[i].AddBuff(ModContent.BuffType<Buffs.Damaging>(), 660, false);
                    Main.player[i].AddBuff(ModContent.BuffType<Buffs.Healing>(), 660, false);
                    Main.player[i].AddBuff(ModContent.BuffType<Buffs.HPBoost>(), 660, false);
                }
            return true;
        }
    }



    public class t5Seal : AncientCostFunction
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Seal of of the Monk");
            Tooltip.SetDefault("A seal used by monks to bless others.Increases your healing.\nIncreases your health by 80.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 15;
            item.useTime = 15;
            AncientCost = 55;
            item.rare = ItemRarityID.Green;
            item.value = Item.buyPrice(gold: 1);
            isAbility = true;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<Buffs.Damaging>(), 780, false);
            player.AddBuff(ModContent.BuffType<Buffs.Healing>(), 780, false);
            player.AddBuff(ModContent.BuffType<Buffs.HPBoost>(), 780, false);
            for (int i = 0; i < Main.maxPlayers; i++)
                if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                {
                    Main.player[i].AddBuff(ModContent.BuffType<Buffs.Damaging>(), 780, false);
                    Main.player[i].AddBuff(ModContent.BuffType<Buffs.Healing>(), 780, false);
                    Main.player[i].AddBuff(ModContent.BuffType<Buffs.HPBoost>(), 780, false);
                }
            return true;
        }
    }



    public class t6Seal : AncientCostFunction
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Seal of of the Monk");
            Tooltip.SetDefault("A seal used by monks to bless others.Increases your healing.\nIncreases your health by 80.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 15;
            item.useTime = 15;
            AncientCost = 60;
            item.rare = ItemRarityID.Green;
            item.value = Item.buyPrice(gold: 1);
            isAbility = true;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<Buffs.Damaging>(), 1560, false);
            player.AddBuff(ModContent.BuffType<Buffs.Healing>(), 1560, false);
            player.AddBuff(ModContent.BuffType<Buffs.HPBoost>(), 1560, false);
            for (int i = 0; i < Main.maxPlayers; i++)
                if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                {
                    Main.player[i].AddBuff(ModContent.BuffType<Buffs.Damaging>(), 1560, false);
                    Main.player[i].AddBuff(ModContent.BuffType<Buffs.Healing>(), 1560, false);
                    Main.player[i].AddBuff(ModContent.BuffType<Buffs.HPBoost>(), 1560, false);
                }
            return true;
        }
    }
}