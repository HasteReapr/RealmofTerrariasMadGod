using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Terraria.DataStructures;
using ROTMG_Items;
using Terraria.ID;

//this modplayer handles the XP functions.
namespace ROTMG_Items
{
    class XPFunction : ModPlayer
    {
        public int XP = 0;
        public int XPLevel = 1;
        public int XPMax = 100;
        public int LvlZeroDeaths = 0;
        public int XPTotal = 0;

        public override void clientClone(ModPlayer clientClone)
        {
            XPFunction clone = clientClone as XPFunction;
            clone.XPLevel = 1;
            clone.XP = 0;
            clone.XPMax = 100;
            clone.LvlZeroDeaths = 0;
            clone.XPTotal = 0;
        }

        internal enum SyncPlayerMessage : byte
        {
            XPOnly,
            XPLevel,
            XP,
            XPMax,
            LvlZeroDeaths,
            XPTotal,
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (ROTMG_Items.ExpHotKey.JustPressed)
            {
                Main.NewText($"Your experience is at {XP}", color: Microsoft.Xna.Framework.Color.Blue);
                Main.NewText($"Your level is at {XPLevel}", color: Microsoft.Xna.Framework.Color.DarkOrange);
            }
        }

        public override TagCompound Save()
        {
            return new TagCompound {
                {"XP", XP},
                {"XPLevel", XPLevel},
                {"XPMax", XPMax},
                {"LvlZeroDeaths", LvlZeroDeaths},
                {"XPTotal", XPTotal},
            };
        }

        public override void Load(TagCompound tag)
        {
            XP = tag.GetInt("XP");
            XPLevel = tag.GetInt("XPLevel");
            XPMax = tag.GetInt("XPMax");
            LvlZeroDeaths = tag.GetInt("LvlZeroDeaths");
            XPTotal = tag.GetInt("XPTotal");
        }

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = mod.GetPacket();
            packet.Write((byte)SyncPlayerMessage.XPOnly);
            packet.Write((byte)player.whoAmI);
            packet.Write(XP);
            packet.Write(XPLevel);
            packet.Write(XPMax);
            packet.Write(LvlZeroDeaths);
            packet.Write(XPTotal);
            packet.Send(toWho, fromWho);
        }

        public override void PostUpdate()
        {
            ExperienceLevels();
        }

        private void ExperienceLevels()
        {
            if (XP >= XPMax)
            {
                XP = 0;
                XPMax = (int)(XPMax * (XPLevel >= 10 ? 1.3f : 1.1f));
                XPLevel += 1;
            }
            else
            {
                return;
            }
        }

        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            if (Main.myPlayer == player.whoAmI)
            {
                if (XPLevel == 0)
                {
                    LvlZeroDeaths += 1;
                }
                if (LvlZeroDeaths >= 5)
                {
                    Main.NewText("You need to level up to actually get fame.", color: Microsoft.Xna.Framework.Color.DarkRed);
                    LvlZeroDeaths = 0;
                }
                //player.QuickSpawnItem(ModContent.ItemType<Items.Currency.Fame>(), XPLevel * Main.rand.Next(100, 300));
                player.QuickSpawnItem(ModContent.ItemType<Items.Currency.Fame>(), XPLevel + (XPTotal / 2));
                Main.NewText($"Your total XP was: {XPTotal}!");
                XP = 0;
                XPLevel = 0;
                XPMax = 100;
                XPTotal = 0;
            }
        }
    }
}
