using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using ROTMG_Items.Items.Weapons.Projectiles;

namespace ROTMG_Items.Items.Weapons
{
    class SpookyScythe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectral Scythe");
            Tooltip.SetDefault("This is the chosen scythe of the Spectral Guard.\n" +
                "It has a cursed power and shoots incredibly powerful stars.\n" +
                "Press and hold attack to charge the scythe up to 6 times,\n" +
                "release to shoot all of the shots.");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LastPrism);
            item.magic = false;
            item.UseSound = SoundID.Item71;
            item.mana = 0;
            item.damage = 10000;
            item.melee = true;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.width = 68;
            item.height = 68;
            item.shoot = ModContent.ProjectileType<SpookyScythe_HoldoutProjectile>();
            item.shootSpeed = 30f;
        }

        public override bool CanUseItem(Player player) => player.ownedProjectileCounts[ModContent.ProjectileType<SpookyScythe_HoldoutProjectile>()] <= 0;
    }
}
