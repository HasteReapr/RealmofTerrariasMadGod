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
            item.shoot = ModContent.ProjectileType<SealProjectile>();
            item.shootSpeed = 0;
            item.rare = ItemRarityID.Green;
            item.value = Item.buyPrice(gold: 1);
            isAbility = true;
            tier = 0;
            item.buffType = ModContent.BuffType<Buffs.Damaging>();
            item.buffTime = 300;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * item.shootSpeed, item.shoot, item.damage, item.knockBack, player.whoAmI, 0, tier);
            return false;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(item.buffType, item.buffTime);
//            for (int i = 0; i < Main.maxPlayers; i++)
//                if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
//                {
//                    Main.player[i].AddBuff(ModContent.BuffType<Buffs.Damaging>(), 300, false);
//                }
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
            item.shoot = ModContent.ProjectileType<SealProjectile>();
            item.shootSpeed = 0;
            item.rare = ItemRarityID.Green;
            item.value = Item.buyPrice(gold: 1);
            isAbility = true;
            tier = 1;
            item.buffType = ModContent.BuffType<Buffs.Damaging>();
            item.buffTime = 420;
            buffType2 = ModContent.BuffType<Buffs.Healing>();
            buffTime2 = 420;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * item.shootSpeed, item.shoot, item.damage, item.knockBack, player.whoAmI, 0, tier);
            return false;
        }
        public override bool UseItem(Player player)
        {
            player.AddBuff(item.buffType, item.buffTime);
            player.AddBuff(buffType2, buffTime2);
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
            item.shoot = ModContent.ProjectileType<SealProjectile>();
            item.shootSpeed = 0;
            item.rare = ItemRarityID.Green;
            item.value = Item.buyPrice(gold: 1);
            isAbility = true;
            tier = 2;
            item.buffType = ModContent.BuffType<Buffs.Damaging>();
            item.buffTime = 540;
            buffType2 = ModContent.BuffType<Buffs.Healing>();
            buffTime2 = 540;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * item.shootSpeed, item.shoot, item.damage, item.knockBack, player.whoAmI, 0, tier);
            return false;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(item.buffType, item.buffTime);
            player.AddBuff(buffType2, buffTime2);
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
            item.shoot = ModContent.ProjectileType<SealProjectile>();
            item.shootSpeed = 0;
            item.rare = ItemRarityID.Green;
            item.value = Item.buyPrice(gold: 1);
            isAbility = true;
            tier = 3;
            item.buffType = ModContent.BuffType<Buffs.Damaging>();
            item.buffTime = 660;
            buffType2 = ModContent.BuffType<Buffs.Healing>();
            buffTime2 = 660;
            buffType3 = ModContent.BuffType<Buffs.HPBoost4>();
            buffTime3 = 660;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * item.shootSpeed, item.shoot, item.damage, item.knockBack, player.whoAmI, 0, tier);
            return false;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(item.buffType, item.buffTime);
            player.AddBuff(buffType2, buffTime2);
            player.AddBuff(buffType3, buffTime3);
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
            item.shoot = ModContent.ProjectileType<SealProjectile>();
            item.shootSpeed = 0;
            item.rare = ItemRarityID.Green;
            item.value = Item.buyPrice(gold: 1);
            isAbility = true;
            tier = 4;
            item.buffType = ModContent.BuffType<Buffs.Damaging>();
            item.buffTime = 780;
            buffType2 = ModContent.BuffType<Buffs.Healing>();
            buffTime2 = 780;
            buffType3 = ModContent.BuffType<Buffs.HPBoost5>();
            buffTime3 = 780;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * item.shootSpeed, item.shoot, item.damage, item.knockBack, player.whoAmI, 0, tier);
            return false;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(item.buffType, item.buffTime);
            player.AddBuff(buffType2, buffTime2);
            player.AddBuff(buffType3, buffTime3);
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
            item.shoot = ModContent.ProjectileType<SealProjectile>();
            item.shootSpeed = 0;
            item.rare = ItemRarityID.Green;
            item.value = Item.buyPrice(gold: 1);
            isAbility = true;
            tier = 5;
            item.buffType = ModContent.BuffType<Buffs.Damaging>();
            item.buffTime = 1560;
            buffType2 = ModContent.BuffType<Buffs.Healing>();
            buffTime2 = 1560;
            buffType3 = ModContent.BuffType<Buffs.HPBoost6>();
            buffTime3 = 1560;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * item.shootSpeed, item.shoot, item.damage, item.knockBack, player.whoAmI, 0, tier);
            return false;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(item.buffType, item.buffTime);
            player.AddBuff(buffType2, buffTime2);
            player.AddBuff(buffType3, buffTime3);
            return true;
        }
    }
}