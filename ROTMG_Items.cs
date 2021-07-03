using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using ROTMG_Items.UI;

namespace ROTMG_Items
{
	public class ROTMG_Items : Mod
	{
        public static DynamicSpriteFont exampleFont;
        private UserInterface _AbilityBarUserInterface;
		internal AbilityPowerBar AbilityPowerBar;


        private UserInterface _exampleUserInterface;

        internal UserInterface ExamplePersonUserInterface;
        internal StatUI StatUI;

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            ROTMGModMessageType msgType = (ROTMGModMessageType)reader.ReadByte();
            switch (msgType)
            {
                case ROTMGModMessageType.ROTMGPlayerSyncPlayer:
                    byte playernumber = reader.ReadByte();
                    ROTMGPlayer ROTMGPlayer = Main.player[playernumber].GetModPlayer<ROTMGPlayer>();
                    int LifePot = reader.ReadInt32();
                    int ManaPot = reader.ReadInt32();
                    int DefPot = reader.ReadInt32();
                    int AttPot = reader.ReadInt32();
                    int DexPot = reader.ReadInt32();
                    int SpdPot = reader.ReadInt32();
                    int VitPot = reader.ReadInt32();
                    int WisPot = reader.ReadInt32();
                    int GLifePot = reader.ReadInt32();
                    int GManaPot = reader.ReadInt32();
                    int GDefPot = reader.ReadInt32();
                    int GAttPot = reader.ReadInt32();
                    int GDexPot = reader.ReadInt32();
                    int GSpdPot = reader.ReadInt32();
                    int GVitPot = reader.ReadInt32();
                    int GWisPot = reader.ReadInt32();
                    int AbilityPowerCurrent = reader.ReadInt32();
                    int AbilityPowerMax = reader.ReadInt32();
                    float AbilityPowerRegen = reader.ReadSingle();
                    float AbilityPowerRegenTimer = reader.ReadSingle();
                    float AbilityPowerRegenRate = reader.ReadSingle();
                    ROTMGPlayer.AbilityPowerRegenRate = AbilityPowerRegenRate;
                    ROTMGPlayer.AbilityPowerCurrent = AbilityPowerCurrent;
                    ROTMGPlayer.AbilityPowerMax = AbilityPowerMax;
                    ROTMGPlayer.AbilityPowerRegen = AbilityPowerRegen;
                    ROTMGPlayer.AbilityPowerRegenTimer = AbilityPowerRegenTimer;
                    ROTMGPlayer.LifePot = LifePot;
                    ROTMGPlayer.ManaPot = ManaPot;
                    ROTMGPlayer.DefPot = DefPot;
                    ROTMGPlayer.AttPot = AttPot;
                    ROTMGPlayer.DexPot = DexPot;
                    ROTMGPlayer.SpdPot = SpdPot;
                    ROTMGPlayer.VitPot = VitPot;
                    ROTMGPlayer.WisPot = WisPot;
                    ROTMGPlayer.GLifePot = GLifePot;
                    ROTMGPlayer.GManaPot = GManaPot;
                    ROTMGPlayer.GDefPot = GDefPot;
                    ROTMGPlayer.GAttPot = GAttPot;
                    ROTMGPlayer.GDexPot = GDexPot;
                    ROTMGPlayer.GSpdPot = GSpdPot;
                    ROTMGPlayer.GVitPot = GVitPot;
                    ROTMGPlayer.GWisPot = GWisPot;
                    // SyncPlayer will be called automatically, so there is no need to forward this data to other clients.
                    break;
            }
        }
        public override void Load()
            {
            if (!Main.dedServ)
            {
                AbilityPowerBar = new AbilityPowerBar();
                _AbilityBarUserInterface = new UserInterface();
                _AbilityBarUserInterface.SetState(AbilityPowerBar);

                if (FontExists("Fonts/ExampleFont"))
                    exampleFont = GetFont("Fonts/ExampleFont");

                StatUI = new StatUI();
                StatUI.Activate();
                _exampleUserInterface = new UserInterface();
                _exampleUserInterface.SetState(StatUI);
            }

        }
        public override void UpdateUI(GameTime gameTime)
        {
            if (StatUI.Visible)
            {
                _exampleUserInterface?.Update(gameTime);
            }
            _AbilityBarUserInterface?.Update(gameTime);
        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));


            int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
            if (resourceBarIndex != -1)
            {
                layers.Insert(resourceBarIndex, new LegacyGameInterfaceLayer(
                    "ROTMG_Items: Ability Power Bar",
                    delegate {
                        _AbilityBarUserInterface.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }

            if (mouseTextIndex != -1)
            {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "ExampleMod: Coins Per Minute",
                    delegate {
                        if (StatUI.Visible)
                        {
                            _exampleUserInterface.Draw(Main.spriteBatch, new GameTime());
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }
        internal enum ROTMGModMessageType : byte
        {
            ROTMGPlayerSyncPlayer,
            NonStopPartyChanged,
            AbilityPowerMax,
            AbilityPowerMax2,
            AbilityPowerRegen,
            AbilityPowerRegenTimer,
            AbilityPowerRegenRate,
        }
    }
}