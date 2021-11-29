using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Tiles
{
	public class Sprite_Bit : ModTile
	{
		public override void SetDefaults()
		{
			TileID.Sets.Ore[Type] = false;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileMergeDirt[Type] = true;
			minPick = 300;
			drop = ModContent.ItemType<Items.Placeable.Sprite_Bit_Item>();
			soundType = SoundID.Shatter;
			soundStyle = 1;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Cuboid Block");
			AddMapEntry(new Color(255, 255, 255), name);
			mineResist = 4f;
			minPick = 35;
		}
	}
}