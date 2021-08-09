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

public class MarbleWorld : Subworld
{
    public override int width => 2000;
    public override int height => 2000;
    public override ModWorld modWorld => ModContent.GetInstance<TheWorld>();

    public override bool saveSubworld => false;
    public override bool disablePlayerSaving => false;
    public override bool saveModData => false;

    public int randomTotal;
    public override List<GenPass> tasks => new List<GenPass>()
    {
        new SubworldGenPass(progress =>
        {
            progress.Message = "Generating Lost Halls Subworld..."; //Sets the text above the worldgen progress bar
			Main.worldSurface = Main.maxTilesY - 42; //Hides the underground layer just out of bounds
			Main.rockLayer = Main.maxTilesY; //Hides the cavern layer way out of bounds
			SLWorld.noReturn = true;
            for (int i = 0; i < Main.maxTilesX; i++)
            {
                for (int j = 0; j < Main.maxTilesY; j++)
                {
                    progress.Set((j + i * Main.maxTilesY/2) / (float)(Main.maxTilesX * Main.maxTilesY)); //Controls the progress bar, should only be set between 0f and 1f
					Main.tile[i, j].active(true);
                    Main.tile[i, j].type = (ushort)ModContent.TileType<Lost_Block>();
                    Main.tile [i, j].wall = WallID.MarbleUnsafe;
                }
            }
        }),
        new SubworldGenPass(holes =>
        {
        int x = Main.maxTilesX / 2 - 1; //Main path.
		int y = Main.maxTilesY / 2 - 3;
        int roomcount = 0;
        float genprog = 0;
            holes.Message = "Generating rooms...";
            WorldUtils.Gen(new Point(x, y), new Shapes.Rectangle(20, 20), new Actions.ClearTile());
            for(randomTotal = 200; randomTotal > 0; randomTotal--)
            {
                Tile tile = Framing.GetTileSafely(x, y);
                holes.Set(genprog);
                int randomdir = Main.rand.Next(0, 4)+1; // chooses a random direction for the room to generate in.
				if(randomdir == 1)
                {
                    //holes.Message = "RandomDir1";
                    x += 22;
                    if(tile.type != (ushort)ModContent.TileType<Lost_Block>()) //if the tile is null, then don't generate there and add +1 to randomTotal, since this removes one from randomTotal.
					{
                        randomdir = Main.rand.Next(4)+1;
                        x -= 22;
						//randomTotal += 1; //It looks like this is what's causing the softlock issue.
					}
                    else
                    {
                        roomcount += 1;
                        genprog += 0.005f;
                    }
                } else if(randomdir == 2)
                {
                    //holes.Message = "RandomDir2";
                    x -= 22;
                    if(tile.type != (ushort)ModContent.TileType<Lost_Block>())
                    {
                        randomdir = Main.rand.Next(4)+1;
                        x +=22;
						//randomTotal += 1;
					}
                    else
                    {
                        roomcount += 1;
                        genprog += 0.005f;
                    }
                } else if(randomdir == 3)
                {
                    //holes.Message = "RandomDir3";
                    y += 22;
                    if(tile.type != (ushort)ModContent.TileType<Lost_Block>())
                    {
                        y -= 22;
                        randomdir = Main.rand.Next(4)+1;
						//randomTotal +=1;
					}
                    else
                    {
                        roomcount += 1;
                        genprog += 0.005f;
                    }
                } else if(randomdir == 4)
                {
                    //holes.Message = "RandomDir4";
                    y -= 22;
                    if(tile.type != (ushort)ModContent.TileType<Lost_Block>())
                    {
                        y += 22;
                        randomdir = Main.rand.Next(4)+1;
						//randomTotal +=1;
					}
                    else
                    {
                        roomcount += 1;
                        genprog += 0.005f;
                    }
                }
                WorldUtils.Gen(new Point(x, y), new Shapes.Rectangle(20, 20), Actions.Chain(new GenAction[]
                {
                    new Actions.ClearTile(),
                    new Actions.PlaceWall(WallID.MarbleUnsafe),
                }));
                if(randomdir == 1)
                {
                    y += 6;
                    x -= 2;
                    WorldUtils.Gen(new Point(x, y), new Shapes.Rectangle(22, 8), new Actions.ClearTile());
                    y -= 6;
                    x += 2;
                }
                if(randomdir == 2)
                {
                    y += 6;
                    WorldUtils.Gen(new Point(x, y), new Shapes.Rectangle(22, 8), new Actions.ClearTile());
                    y -= 6;
                }
                if(randomdir == 3)
                {
                    x += 6;
                    y -= 2;
                    WorldUtils.Gen(new Point(x, y), new Shapes.Rectangle(8, 22), new Actions.ClearTile());
                    x -= 6;
                    y += 2;
                }
                if(randomdir == 4)
                {
                    x += 6;
                    WorldUtils.Gen(new Point(x, y), new Shapes.Rectangle(8, 22), new Actions.ClearTile());
                    x -= 6;
                }

                if(roomcount == 200)
                {
					//WorldUtils.Gen(new Point(x, y), new Shapes.Rectangle(40, 40), new Actions.ClearTile());
					if(randomdir == 1)
                    {
                        x += 100;
                        y += 3;
                        WorldUtils.Gen(new Point(x, y), new Shapes.Rectangle(102, 8), new Actions.ClearTile());
                        x += 2;
                        y -= 3;
                    }else if(randomdir == 2)
                    {
                        x -= 100;
                        y += 3;
                        WorldUtils.Gen(new Point(x, y), new Shapes.Rectangle(102, 8), new Actions.ClearTile());
                        x -= 2;
                        y -= 3;
                    }else if(randomdir == 3)
                    {
                        y += 100;
                        x += 3;
                        WorldUtils.Gen(new Point(x, y), new Shapes.Rectangle(8, 102), new Actions.ClearTile());
                        y += 2;
                        x -= 3;
                    }else if(randomdir == 4)
                    {
                        y -= 102;
                        x += 3;
                        WorldUtils.Gen(new Point(x, y), new Shapes.Rectangle(8, 102), new Actions.ClearTile());
                        y -= 2;
                        x -= 3;
                    }
                    genprog += 0.005f;
                    WorldUtils.Gen(new Point(x, y), new Shapes.Rectangle(100, 100), Actions.Chain(new GenAction[]
                    {
                        new Actions.ClearTile(),
                        new Actions.PlaceWall(WallID.MarbleUnsafe),
                    }));
                }
            }
        }),

        new SubworldGenPass(Splits =>
        {
            int roomcount = 0;
            float genprog = 0;
            Splits.Message = "Generating splits...";
                        int X = Main.maxTilesX / 2 - 1; //First set of splits.
			int Y = Main.maxTilesY / 2 - 3;
            for(randomTotal = 100; randomTotal > 0; randomTotal--)
            {
                Tile tile = Framing.GetTileSafely(X, Y);
                Splits.Set(genprog);
                int randomdir = Main.rand.Next(5, 8)+1; // chooses a random direction for the room to generate in.
				if(randomdir == 5)
                {
                    X += 22;
                    if(tile.type != (ushort)ModContent.TileType<Lost_Block>()) //if the tile is null, then don't generate there and add +1 to randomTotal, since this removes one from randomTotal.
					{
                        randomdir = Main.rand.Next(5, 8)+1;
                        X -= 22;
						//randomTotal += 1; //It looks like this is what's causing the softlock issue.
					}
                    else
                    {
                        roomcount += 1;
                        genprog += 0.005f;
                    }
                } else if(randomdir == 6)
                {
                    X -= 22;
                    if(tile.type != (ushort)ModContent.TileType<Lost_Block>())
                    {
                        randomdir = Main.rand.Next(5, 8)+1;
                        X += 22;
						//randomTotal += 1;
					}
                    else
                    {
                        roomcount += 1;
                        genprog += 0.005f;
                    }
                } else if(randomdir == 7)
                {
                    Y += 22;
                    if(tile.type != (ushort)ModContent.TileType<Lost_Block>())
                    {
                        Y -= 22;
                        randomdir = Main.rand.Next(5, 8)+1;
						//randomTotal +=1;
					}
                    else
                    {
                        roomcount += 1;
                        genprog += 0.005f;
                    }
                } else if(randomdir == 8)
                {
                    Y -= 22;
                    if(tile.type != (ushort)ModContent.TileType<Lost_Block>())
                    {
                        Y += 22;
                        randomdir = Main.rand.Next(5, 8)+1;
						//randomTotal +=1;
					}
                    else
                    {
                        roomcount += 1;
                        genprog += 0.005f;
                    }
                }
                WorldUtils.Gen(new Point(X, Y), new Shapes.Rectangle(20, 20), Actions.Chain(new GenAction[]
                {
                    new Actions.ClearTile(),
                    new Actions.PlaceWall(WallID.MarbleUnsafe),
                }));
                if(randomdir == 5)
                {
                    Y += 6;
                    X -= 2;
                    WorldUtils.Gen(new Point(X, Y), new Shapes.Rectangle(22, 8), new Actions.ClearTile());
                    Y -= 6;
                    X += 2;
                }
                if(randomdir == 6)
                {
                    Y += 6;
                    WorldUtils.Gen(new Point(X, Y), new Shapes.Rectangle(22, 8), new Actions.ClearTile());
                    Y -= 6;
                }
                if(randomdir == 7)
                {
                    X += 6;
                    Y -= 2;
                    WorldUtils.Gen(new Point(X, Y), new Shapes.Rectangle(8, 22), new Actions.ClearTile());
                    X -= 6;
                    Y += 2;
                }
                if(randomdir == 8)
                {
                    X += 6;
                    WorldUtils.Gen(new Point(X, Y), new Shapes.Rectangle(8, 22), new Actions.ClearTile());
                    X -= 6;
                }
            }


            int XX = Main.maxTilesX / 2 - 1; //Second set of splits.
			int YY = Main.maxTilesY / 2 - 3;
            for(randomTotal = 100; randomTotal > 0; randomTotal--)
            {
                Tile tile = Framing.GetTileSafely(XX, YY);
                Splits.Set(genprog++ * 0.033f + 0.01f);
                int randomdir = Main.rand.Next(9, 12)+1; // chooses a random direction for the room to generate in.
				if(randomdir == 9)
                {
                    XX += 22;
                    if(tile.type != (ushort)ModContent.TileType<Lost_Block>()) //if the tile is null, then don't generate there and add +1 to randomTotal, since this removes one from randomTotal.
					{
                        randomdir = Main.rand.Next(5, 8)+1;
                        XX -= 22;
						//randomTotal += 1; //It looks like this is what's causing the softlock issue.
					}
                    else
                    {
                        roomcount += 1;
                        genprog += 0.005f;
                    }
                } else if(randomdir == 10)
                {
                    XX -= 22;
                    if(tile.type != (ushort)ModContent.TileType<Lost_Block>())
                    {
                        randomdir = Main.rand.Next(5, 8)+1;
                        XX += 22;
						//randomTotal += 1;
					}
                    else
                    {
                        roomcount += 1;
                        genprog += 0.005f;
                    }
                } else if(randomdir == 11)
                {
                    YY += 22;
                    if(tile.type != (ushort)ModContent.TileType<Lost_Block>())
                    {
                        YY -= 22;
                        randomdir = Main.rand.Next(5, 8)+1;
						//randomTotal +=1;
					}
                    else
                    {
                        roomcount += 1;
                        genprog += 0.005f;
                    }
                } else if(randomdir == 12)
                {
                    YY -= 22;
                    if(tile.type != (ushort)ModContent.TileType<Lost_Block>())
                    {
                        YY += 22;
                        randomdir = Main.rand.Next(5, 8)+1;
						//randomTotal +=1;
					}
                    else
                    {
                        roomcount += 1;
                        genprog += 0.005f;
                    }
                }
                WorldUtils.Gen(new Point(XX, YY), new Shapes.Rectangle(20, 20), Actions.Chain(new GenAction[]
                {
                    new Actions.ClearTile(),
                    new Actions.PlaceWall(WallID.MarbleUnsafe),
                }));
                if(randomdir == 9)
                {
                    YY += 6;
                    XX -= 2;
                    WorldUtils.Gen(new Point(XX, YY), new Shapes.Rectangle(22, 8), new Actions.ClearTile());
                    YY -= 6;
                    XX += 2;
                }
                if(randomdir == 10)
                {
                    YY += 6;
                    WorldUtils.Gen(new Point(XX, YY), new Shapes.Rectangle(22, 8), new Actions.ClearTile());
                    YY -= 6;
                }
                if(randomdir == 11)
                {
                    XX += 6;
                    YY -= 2;
                    WorldUtils.Gen(new Point(XX, YY), new Shapes.Rectangle(8, 22), new Actions.ClearTile());
                    XX -= 6;
                    YY += 2;
                }
                if(randomdir == 12)
                {
                    XX += 6;
                    WorldUtils.Gen(new Point(XX, YY), new Shapes.Rectangle(8, 22), new Actions.ClearTile());
                    XX -= 6;
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