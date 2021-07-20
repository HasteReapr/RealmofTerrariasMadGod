using Terraria;
using Terraria.ID;
using Terraria.World;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria.ModLoader;
using SubworldLibrary;
using ROTMG_Items;
using Terraria.World.Generation;

public class DirtWorld : Subworld
{
	public override int width => 1000;
	public override int height => 1000;

	public override ModWorld modWorld => ModContent.GetInstance<TheWorld>();

	public override bool saveSubworld => false;
	public override bool disablePlayerSaving => false;
	public override bool saveModData => false;

	public override List<GenPass> tasks => new List<GenPass>()
	{
		new SubworldGenPass(progress =>
		{
			progress.Message = "Generating Test Subworld..."; //Sets the text above the worldgen progress bar
			Main.worldSurface = Main.maxTilesY - 42; //Hides the underground layer just out of bounds
			Main.rockLayer = Main.maxTilesY; //Hides the cavern layer way out of bounds
			for (int i = 0; i < Main.maxTilesX; i++)
			{
				for (int j = 0; j < Main.maxTilesY; j++)
				{
					progress.Set((j + i * Main.maxTilesY/2) / (float)(Main.maxTilesX * Main.maxTilesY)); //Controls the progress bar, should only be set between 0f and 1f
					Main.tile[i, j].active(true);
					Main.tile[i, j].type = TileID.Dirt;
				}
			}
		})
	};

	public override void Load()
	{
		Main.dayTime = true;
		Main.time = 27000;
	}
}