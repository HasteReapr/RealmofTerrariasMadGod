using Terraria;
using Terraria.ID;
using ROTMG_Items.Items;
using ROTMG_Items.Tiles;
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

public class TestWorld : Subworld
{
	public override int width => 1000;
	public override int height => 1000;

	public override ModWorld modWorld => ModContent.GetInstance<TheWorld>();

	public override bool saveSubworld => false;
	public override bool disablePlayerSaving => false;
	public override bool saveModData => false;
	public int randomTotal;

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
					progress.Set((j + i * Main.maxTilesY) / (float)(Main.maxTilesX * Main.maxTilesY)); //Controls the progress bar, should only be set between 0f and 1f
					Main.tile[i, j].active(true);
					Main.tile[i, j].type = TileID.Stone;
				}
			}
		}),
		new SubworldGenPass(Ores =>
        {
			Ores.Message = "Generating ores...";
				 {
					for(randomTotal = Main.rand.Next(100, 300)+1; randomTotal>0; randomTotal--) //define integer; set condition; modify integer
					{
							int x = WorldGen.genRand.Next(0, Main.maxTilesX);
							int y = WorldGen.genRand.Next(0, Main.maxTilesY);
							Tile tile = Framing.GetTileSafely(x, y);
							if (tile.active() && tile.type == TileID.Stone)
							WorldGen.TileRunner(x, y, WorldGen.genRand.Next(5, 9), WorldGen.genRand.Next(6, 9), ModContent.TileType<PrismaticShard>());
					}
				 }
		}),
		new SubworldGenPass(Pits =>
        {
			Pits.Message = "Generating pits...";
            {
				for(randomTotal = Main.rand.Next(50, 100)+1; randomTotal>0; randomTotal--)
                {
					int x = WorldGen.genRand.Next(0, Main.maxTilesX);
					int y = WorldGen.genRand.Next(0, Main.maxTilesY);
					Tile tile = Framing.GetTileSafely(x, y);
					if(tile.active() && tile.type == TileID.Stone)
						WorldGen.digTunnel(x, y, 0, 1, 50, 5);
                }
            }
        }),
		new SubworldGenPass(Lakes =>
        {
			Lakes.Message = "Generating lakes...";
            {
				for(randomTotal = Main.rand.Next(10)+1; randomTotal>0; randomTotal--)
                {
					int x = WorldGen.genRand.Next(0, Main.maxTilesX);
					int y = WorldGen.genRand.Next(0, Main.maxTilesY);
					Tile tile = Framing.GetTileSafely(x, y);
					if(tile.active() && tile.type == TileID.Stone)
						WorldGen.digTunnel(x, y, 0, 1, 50, 5, true);
                }
            }
        }),
	};

	public override void Load()
	{
		Main.dayTime = true;
		Main.time = 27000;
	}
}