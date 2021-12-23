using Terraria;
using Terraria.GameContent.UI;
using Terraria.ModLoader;
using Terraria.UI;
using Microsoft.Xna.Framework;
using ReLogic.Graphics;
using System.Collections.Generic;
using System.IO;
using ROTMG_Items.UI;

namespace ROTMG_Items
{
    public class ROTMG_Items : Mod
    {
        public static ModHotKey AbilityHotKey;
        public static ModHotKey ExpHotKey;
        public static DynamicSpriteFont exampleFont;
        private UserInterface _AbilityBarUserInterface;
        internal AbilityPowerBar AbilityPowerBar;
        public UserInterface _AbilitySlotUI;
        internal AbilitySlotUI AbilitySlotUI;
        public UserInterface _DupePanelUI;
        internal DupeUIPanel DupeUIPanel;

        //public static Texture2D CachedLogo = Main.logoTexture;

        public static int FaceCustomCurrencyId;

        private UserInterface _exampleUserInterface;
        internal UserInterface ExamplePersonUserInterface;

        internal StatUI StatUI;

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            ROTMGModMessageType msgType = (ROTMGModMessageType)reader.ReadByte();
            switch (msgType)
            {
                case ROTMGModMessageType.ROTMGPlayerSyncPlayer:

                    SyncPlayerMessage submessage = (SyncPlayerMessage)reader.ReadByte();
                    byte playernumber = reader.ReadByte();
                    switch (submessage)
                    {
                        case SyncPlayerMessage.XPOnly:
                            XPFunction XPFunction = Main.player[playernumber].GetModPlayer<XPFunction>();
                            int XP = reader.ReadInt32();
                            int XPLevel = reader.ReadInt32();
                            int XPMax = reader.ReadInt32();
                            int LvlZeroDeaths = reader.ReadInt32();
                            int XPTotal = reader.ReadInt32();
                            XPFunction.XP = XP;
                            XPFunction.XPLevel = XPLevel;
                            XPFunction.XPMax = XPMax;
                            XPFunction.LvlZeroDeaths = LvlZeroDeaths;
                            XPFunction.XPTotal = XPTotal;
                            break;
                        case SyncPlayerMessage.Potions:
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
                            bool moonded = reader.ReadBoolean();


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
                            ROTMGPlayer.AbilityPowerCurrent = AbilityPowerCurrent;
                            ROTMGPlayer.AbilityPowerMax = AbilityPowerMax;
                            ROTMGPlayer.AbilityPowerRegen = AbilityPowerRegen;
                            ROTMGPlayer.AbilityPowerRegenTimer = AbilityPowerRegenTimer;
                            ROTMGPlayer.AbilityPowerRegenRate = AbilityPowerRegenRate;
                            ROTMGPlayer.moonded = moonded;
                            break;
                        case SyncPlayerMessage.Pets:
                            PetPlayer PetPlayer = Main.player[playernumber].GetModPlayer<PetPlayer>();
                            bool SpritePet = reader.ReadBoolean();
                            bool Stonepet = reader.ReadBoolean();
                            bool SupporterPet = reader.ReadBoolean();
                            PetPlayer.Stonepet = Stonepet;
                            PetPlayer.SpritePet = SpritePet;
                            PetPlayer.SupporterPet = SupporterPet;
                            break;
                    }
                break;
            }
        }
        public override void Load()
        {
            FaceCustomCurrencyId = CustomCurrencyManager.RegisterCurrency(new Items.Currency.FameCurrency(ModContent.ItemType<Items.Currency.Fame>(), 1000000L));

            //Main.logoTexture = GetTexture("ROTMG_ItemsLogo");

            AbilityHotKey = RegisterHotKey("Ability Hot Key", "P");
            ExpHotKey = RegisterHotKey("Experience Hot Key", ";");
            if (!Main.dedServ)
            {
                AbilityPowerBar = new AbilityPowerBar();
                _AbilityBarUserInterface = new UserInterface();
                _AbilityBarUserInterface.SetState(AbilityPowerBar);

                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Realm_Title"), ItemType("Realm_Title_Box"), TileType("Realm_Title_Box_Placeable"));

                if (FontExists("Fonts/ExampleFont"))
                    exampleFont = GetFont("Fonts/ExampleFont");

                StatUI = new StatUI();
                StatUI.Activate();
                _exampleUserInterface = new UserInterface();
                _exampleUserInterface.SetState(StatUI);

                AbilitySlotUI = new AbilitySlotUI();
                _AbilitySlotUI = new UserInterface();
                _AbilitySlotUI.SetState(AbilitySlotUI);

                DupeUIPanel = new DupeUIPanel();
                _DupePanelUI = new UserInterface();
                _DupePanelUI.SetState(DupeUIPanel);
            }

        }
        public override void UpdateUI(GameTime gameTime)
        {
            if (StatUI.Visible)
            {
                _exampleUserInterface?.Update(gameTime);
            }
            if (DupeUIPanel.Visible)
            {
                _DupePanelUI?.Update(gameTime);
            }
            _AbilityBarUserInterface?.Update(gameTime);

            if (!Main.playerInventory)
            {
                ModContent.GetInstance<ROTMG_Items>()._AbilitySlotUI.SetState(null);
            }
            else if (Main.playerInventory)
            {
                ModContent.GetInstance<ROTMG_Items>()._AbilitySlotUI.SetState(AbilitySlotUI);
            }
        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));


            int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
            if (resourceBarIndex != -1)
            {
                layers.Insert(resourceBarIndex, new LegacyGameInterfaceLayer(
                    "ROTMG_Items: Ability Power Bar",
                    delegate
                    {
                        _AbilityBarUserInterface.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }

            int abilityslotUI_ = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));
            if (abilityslotUI_ != -1)
            {
                layers.Insert(abilityslotUI_, new LegacyGameInterfaceLayer(
                    "ROTMG_Items: Ability Item Slot",
                    delegate
                    {
                        _AbilitySlotUI.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }

            if (mouseTextIndex != -1)
            {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "ROTMG_Items: Dupe Panel",
                    delegate
                    {
                        if (DupeUIPanel.Visible == true)
                        {
                            _DupePanelUI.Draw(Main.spriteBatch, new GameTime());
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );


                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "ExampleMod: Coins Per Minute",
                    delegate
                    {
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
        public override void Unload()
        {
            //Main.logoTexture = CachedLogo;
            AbilityHotKey = null;
            ExpHotKey = null;
        }
        internal enum ROTMGModMessageType : byte
        {
            ROTMGPlayerSyncPlayer,
            SyncPlayerMessage,
            NonStopPartyChanged,
            AbilityPowerMax,
            AbilityPowerMax2,
            AbilityPowerRegen,
            AbilityPowerRegenTimer,
            AbilityPowerRegenRate,
        }

        internal enum SyncPlayerMessage : byte
        {
            XPOnly,
            Potions,
            Pets,
        }
    }
}