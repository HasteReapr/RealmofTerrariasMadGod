/*using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Input;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.World.Generation;
using Terraria.GameContent.Generation;

namespace ROTMG_Items
{
    class WorldGenTutorialWorld : ModWorld
    {
        public static bool JustPressed(Keys key)
        {
            return Main.keyState.IsKeyDown(key) && !Main.oldKeyState.IsKeyDown(key);
        }

        public override void PostUpdate()
        {
            if (JustPressed(Keys.D1))
                TestMethod((int)Main.MouseWorld.X / 16, (int)Main.MouseWorld.Y / 16);
        }

        private void TestMethod(int x, int y)
        {
            Dust.QuickBox(new Vector2(x, y) * 16, new Vector2(x + 1, y + 1) * 16, 2, Color.YellowGreen, null);

            // Code to test placed here:                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   0 
            WorldUtils.Gen(new Point(x, y), new Shapes.Rectangle(20, 20), Actions.Chain(new GenAction[]
            {
                    new Actions.ClearTile(),
                    new Actions.PlaceWall(WallID.MarbleUnsafe),
            }));
            x += 3;
            y -= 2;
            WorldUtils.Gen(new Point(x, y), new Shapes.Rectangle(4, 22), new Actions.ClearTile());
        }
    }
}*/