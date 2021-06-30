using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ROTMG_Items.Items;

namespace ROTMG_Items.Items.Abilities
{
	public class GPrism : AncientCostFunction
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fractured Prism");
			Tooltip.SetDefault("This prism leaves behind a fragment of itself that explodes after some time.");
		}

		public override void SetDefaults()
		{
			// player.Teleport(Main.MouseWorld),
			item.rare = ItemRarityID.Cyan;
			item.damage = 0;
			item.useStyle = ItemUseStyleID.HoldingOut; //yes
			item.magic = true;
			AncientCost = 65;
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item20;
			item.autoReuse = false;
			item.shootSpeed = 0.01f;
		}
		public float TeleportWait = 0;
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.useStyle = ItemUseStyleID.HoldingUp;
				item.useTime = 20;
				item.useAnimation = 20;
				item.mana = 65;
				item.damage = 120;
				item.shoot = ModContent.ProjectileType<GBomb>();
				TeleportWait = 1;
				item.shootSpeed = 0.01f;
				if (TeleportWait == 1)
				{
					player.Teleport(Main.MouseWorld);
				}
			}
			else
			{
				item.useStyle = ItemUseStyleID.HoldingUp;
				item.useTime = 20;
				item.useAnimation = 20;
			}
			return base.CanUseItem(player);
		}
	}
}