using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;

namespace ROTMG_Items.UI
{
	internal class StatUI : UIState
	{
		public DragableUIPanel CoinCounterPanel;
		public UIHoverImageButton ExampleButton;
		private UIImage Lifepot;
		private UIImage Manapot;
		private UIImage Vitpot;
		private UIImage Wispot;
		private UIImage Dexpot;
		private UIImage Attpot;
		private UIImage Spdpot;
		private UIImage Defpot;

		private UIImage GLifepot;
		private UIImage GManapot;
		private UIImage GVitpot;
		private UIImage GWispot;
		private UIImage GDexpot;
		private UIImage GAttpot;
		private UIImage GSpdpot;
		private UIImage GDefpot;

		private UIText Life;
		private UIText Mana;
		private UIText Vit;
		private UIText Wis;
		private UIText Dex;
		private UIText Att;
		private UIText Spd;
		private UIText Def;

		private UIText GLife;
		private UIText GMana;
		private UIText GVit;
		private UIText GWis;
		private UIText GDex;
		private UIText GAtt;
		private UIText GSpd;
		private UIText GDef;
		public static bool Visible;

		// In OnInitialize, we place various UIElements onto our UIState (this class).
		// UIState classes have width and height equal to the full screen, because of this, usually we first define a UIElement that will act as the container for our UI.
		// We then place various other UIElement onto that container UIElement positioned relative to the container UIElement.
		public override void OnInitialize()
		{
			// Here we define our container UIElement. In DragableUIPanel.cs, you can see that DragableUIPanel is a UIPanel with a couple added features.
			CoinCounterPanel = new DragableUIPanel();
			CoinCounterPanel.SetPadding(0);
			// We need to place this UIElement in relation to its Parent. Later we will be calling `base.Append(coinCounterPanel);`. 
			// This means that this class, ExampleUI, will be our Parent. Since ExampleUI is a UIState, the Left and Top are relative to the top left of the screen.
			CoinCounterPanel.Left.Set(400f, 0f);
			CoinCounterPanel.Top.Set(100f, 0f);
			CoinCounterPanel.Width.Set(436f, 0f);
			CoinCounterPanel.Height.Set(142f, 0f);
			CoinCounterPanel.BackgroundColor = new Color(73, 94, 171);

			// Next, we create another UIElement that we will place. Since we will be calling `coinCounterPanel.Append(playButton);`, Left and Top are relative to the top left of the coinCounterPanel UIElement. 
			// By properly nesting UIElements, we can position things relatively to each other easily.
			/*Texture2D buttonPlayTexture = ModContent.GetTexture("Terraria/UI/ButtonPlay");
			UIHoverImageButton playButton = new UIHoverImageButton(buttonPlayTexture, "Reset Coins Per Minute Counter");
			playButton.Left.Set(174, 0f);
			playButton.Top.Set(74, 0f);
			playButton.Width.Set(22, 0f);
			playButton.Height.Set(22, 0f);
			// UIHoverImageButton doesn't do anything when Clicked. Here we assign a method that we'd like to be called when the button is clicked.
			playButton.OnClick += new MouseEvent(PlayButtonClicked);
			CoinCounterPanel.Append(playButton);*/

			Texture2D buttonDeleteTexture = ModContent.GetTexture("Terraria/UI/ButtonDelete");
			UIHoverImageButton closeButton = new UIHoverImageButton(buttonDeleteTexture, Language.GetTextValue("LegacyInterface.52")); // Localized text for "Close"
			closeButton.Left.Set(408, 0f);
			closeButton.Top.Set(10, 0f);
			closeButton.Width.Set(22, 0f);
			closeButton.Height.Set(22, 0f);
			closeButton.OnClick += new MouseEvent(CloseButtonClicked);
			CoinCounterPanel.Append(closeButton);

			// UIMoneyDisplay is a fairly complicated custom UIElement. UIMoneyDisplay handles drawing some text and coin textures.
			// Organization is key to managing UI design. Making a contained UIElement like UIMoneyDisplay will make many things easier.

			Lifepot = new UIImage(ModContent.GetTexture("ROTMG_Items/Items/LifePot"));
			Lifepot.Left.Set(10, 0f);
			Lifepot.Top.Set(10, 0f);
			Lifepot.Width.Set(126, 0f);
			Lifepot.Height.Set(18, 0f);
			CoinCounterPanel.Append(Lifepot);

			Manapot = new UIImage(ModContent.GetTexture("ROTMG_Items/Items/ManaPot"));
			Manapot.Left.Set(60, 0f);
			Manapot.Top.Set(10, 0f);
			Manapot.Width.Set(126, 0f);
			Manapot.Height.Set(18, 0f);
			CoinCounterPanel.Append(Manapot);

			Wispot = new UIImage(ModContent.GetTexture("ROTMG_Items/Items/WisPot"));
			Wispot.Left.Set(110, 0f);
			Wispot.Top.Set(10, 0f);
			Wispot.Width.Set(126, 0f);
			Wispot.Height.Set(18, 0f);
			CoinCounterPanel.Append(Wispot);

			Vitpot = new UIImage(ModContent.GetTexture("ROTMG_Items/Items/VitPot"));
			Vitpot.Left.Set(160, 0f);
			Vitpot.Top.Set(10, 0f);
			Vitpot.Width.Set(126, 0f);
			Vitpot.Height.Set(18, 0f);
			CoinCounterPanel.Append(Vitpot);

			Dexpot = new UIImage(ModContent.GetTexture("ROTMG_Items/Items/DexPot"));
			Dexpot.Left.Set(210, 0f);
			Dexpot.Top.Set(10, 0f);
			Dexpot.Width.Set(126, 0f);
			Dexpot.Height.Set(18, 0f);
			CoinCounterPanel.Append(Dexpot);

			Attpot = new UIImage(ModContent.GetTexture("ROTMG_Items/Items/AttPot"));
			Attpot.Left.Set(260, 0f);
			Attpot.Top.Set(10, 0f);
			Attpot.Width.Set(126, 0f);
			Attpot.Height.Set(18, 0f);
			CoinCounterPanel.Append(Attpot);

			Spdpot = new UIImage(ModContent.GetTexture("ROTMG_Items/Items/SpdPot"));
			Spdpot.Left.Set(310, 0f);
			Spdpot.Top.Set(10, 0f);
			Spdpot.Width.Set(126, 0f);
			Spdpot.Height.Set(18, 0f);
			CoinCounterPanel.Append(Spdpot);

			Defpot = new UIImage(ModContent.GetTexture("ROTMG_Items/Items/DefPot"));
			Defpot.Left.Set(360, 0f);
			Defpot.Top.Set(10, 0f);
			Defpot.Width.Set(126, 0f);
			Defpot.Height.Set(18, 0f);
			CoinCounterPanel.Append(Defpot);


			//Greater pots I don't know how to organize code in a proper way.
			GLifepot = new UIImage(ModContent.GetTexture("ROTMG_Items/Items/GLifePot"));
			GLifepot.Left.Set(10, 0f);
			GLifepot.Top.Set(74, 0f);
			GLifepot.Width.Set(126, 0f);
			GLifepot.Height.Set(18, 0f);
			CoinCounterPanel.Append(GLifepot);

			GManapot = new UIImage(ModContent.GetTexture("ROTMG_Items/Items/GManaPot"));
			GManapot.Left.Set(60, 0f);
			GManapot.Top.Set(74, 0f);
			GManapot.Width.Set(126, 0f);
			GManapot.Height.Set(18, 0f);
			CoinCounterPanel.Append(GManapot);

			GWispot = new UIImage(ModContent.GetTexture("ROTMG_Items/Items/GWisPot"));
			GWispot.Left.Set(110, 0f);
			GWispot.Top.Set(74, 0f);
			GWispot.Width.Set(126, 0f);
			GWispot.Height.Set(18, 0f);
			CoinCounterPanel.Append(GWispot);

			GVitpot = new UIImage(ModContent.GetTexture("ROTMG_Items/Items/GVitPot"));
			GVitpot.Left.Set(160, 0f);
			GVitpot.Top.Set(74, 0f);
			GVitpot.Width.Set(126, 0f);
			GVitpot.Height.Set(18, 0f);
			CoinCounterPanel.Append(GVitpot);

			GDexpot = new UIImage(ModContent.GetTexture("ROTMG_Items/Items/GDexPot"));
			GDexpot.Left.Set(210, 0f);
			GDexpot.Top.Set(74, 0f);
			GDexpot.Width.Set(126, 0f);
			GDexpot.Height.Set(18, 0f);
			CoinCounterPanel.Append(GDexpot);

			GAttpot = new UIImage(ModContent.GetTexture("ROTMG_Items/Items/GAttPot"));
			GAttpot.Left.Set(260, 0f);
			GAttpot.Top.Set(74, 0f);
			GAttpot.Width.Set(126, 0f);
			GAttpot.Height.Set(18, 0f);
			CoinCounterPanel.Append(GAttpot);

			GSpdpot = new UIImage(ModContent.GetTexture("ROTMG_Items/Items/GSpdPot"));
			GSpdpot.Left.Set(310, 0f);
			GSpdpot.Top.Set(74, 0f);
			GSpdpot.Width.Set(126, 0f);
			GSpdpot.Height.Set(18, 0f);
			CoinCounterPanel.Append(GSpdpot);

			GDefpot = new UIImage(ModContent.GetTexture("ROTMG_Items/Items/GDefPot"));
			GDefpot.Left.Set(360, 0f);
			GDefpot.Top.Set(74, 0f);
			GDefpot.Width.Set(126, 0f);
			GDefpot.Height.Set(18, 0f);
			CoinCounterPanel.Append(GDefpot);


			Life = new UIText("");
			Life.Width.Set(138, 0f);
			Life.Height.Set(34, 0f);
			Life.Top.Set(50, 0f);
			Life.Left.Set(-40, 0f);
			CoinCounterPanel.Append(Life);

			Mana = new UIText("");
			Mana.Width.Set(138, 0f);
			Mana.Height.Set(34, 0f);
			Mana.Top.Set(50, 0f);
			Mana.Left.Set(10, 0f);
			CoinCounterPanel.Append(Mana);

			Vit = new UIText("");
			Vit.Width.Set(138, 0f);
			Vit.Height.Set(34, 0f);
			Vit.Top.Set(50, 0f);
			Vit.Left.Set(110, 0f);
			CoinCounterPanel.Append(Vit);

			Wis = new UIText("");
			Wis.Width.Set(138, 0f);
			Wis.Height.Set(34, 0f);
			Wis.Top.Set(50, 0f);
			Wis.Left.Set(60, 0f);
			CoinCounterPanel.Append(Wis);

			Dex = new UIText("");
			Dex.Width.Set(138, 0f);
			Dex.Height.Set(34, 0f);
			Dex.Top.Set(50, 0f);
			Dex.Left.Set(160, 0f);
			CoinCounterPanel.Append(Dex);

			Att = new UIText("");
			Att.Width.Set(138, 0f);
			Att.Height.Set(34, 0f);
			Att.Top.Set(50, 0f);
			Att.Left.Set(210, 0f);
			CoinCounterPanel.Append(Att);

			Spd = new UIText("");
			Spd.Width.Set(138, 0f);
			Spd.Height.Set(34, 0f);
			Spd.Top.Set(50, 0f);
			Spd.Left.Set(260, 0f);
			CoinCounterPanel.Append(Spd);

			Def = new UIText("");
			Def.Width.Set(138, 0f);
			Def.Height.Set(34, 0f);
			Def.Top.Set(50, 0f);
			Def.Left.Set(310, 0f);
			CoinCounterPanel.Append(Def);



			GLife = new UIText("");
			GLife.Width.Set(138, 0f);
			GLife.Height.Set(34, 0f);
			GLife.Top.Set(114, 0f);
			GLife.Left.Set(-40, 0f);
			CoinCounterPanel.Append(GLife);

			GMana = new UIText("");
			GMana.Width.Set(138, 0f);
			GMana.Height.Set(34, 0f);
			GMana.Top.Set(114, 0f);
			GMana.Left.Set(10, 0f);
			CoinCounterPanel.Append(GMana);

			GVit = new UIText("");
			GVit.Width.Set(138, 0f);
			GVit.Height.Set(34, 0f);
			GVit.Top.Set(114, 0f);
			GVit.Left.Set(110, 0f);
			CoinCounterPanel.Append(GVit);

			GWis = new UIText("");
			GWis.Width.Set(138, 0f);
			GWis.Height.Set(34, 0f);
			GWis.Top.Set(114, 0f);
			GWis.Left.Set(60, 0f);
			CoinCounterPanel.Append(GWis);

			GDex = new UIText("");
			GDex.Width.Set(138, 0f);
			GDex.Height.Set(34, 0f);
			GDex.Top.Set(114, 0f);
			GDex.Left.Set(160, 0f);
			CoinCounterPanel.Append(GDex);

			GAtt = new UIText("");
			GAtt.Width.Set(138, 0f);
			GAtt.Height.Set(34, 0f);
			GAtt.Top.Set(114, 0f);
			GAtt.Left.Set(210, 0f);
			CoinCounterPanel.Append(GAtt);

			GSpd = new UIText("");
			GSpd.Width.Set(138, 0f);
			GSpd.Height.Set(34, 0f);
			GSpd.Top.Set(114, 0f);
			GSpd.Left.Set(260, 0f);
			CoinCounterPanel.Append(GSpd);

			GDef = new UIText("");
			GDef.Width.Set(138, 0f);
			GDef.Height.Set(34, 0f);
			GDef.Top.Set(114, 0f);
			GDef.Left.Set(310, 0f);
			CoinCounterPanel.Append(GDef);

			Append(CoinCounterPanel);

			// As a recap, ExampleUI is a UIState, meaning it covers the whole screen. We attach coinCounterPanel to ExampleUI some distance from the top left corner.
			// We then place playButton, closeButton, and moneyDiplay onto coinCounterPanel so we can easily place these UIElements relative to coinCounterPanel.
			// Since coinCounterPanel will move, this proper organization will move playButton, closeButton, and moneyDiplay properly when coinCounterPanel moves.
		}

		private void CloseButtonClicked(UIMouseEvent evt, UIElement listeningElement)
		{
			Main.PlaySound(SoundID.MenuClose);
			Visible = false;
		}

		public override void Update(GameTime gameTime)
		{
			var modPlayer = Main.LocalPlayer.GetModPlayer<ROTMGPlayer>();
			Life.SetText($"{modPlayer.LifePot}/10");
			Mana.SetText($"{modPlayer.ManaPot}/5");
			Wis.SetText($"{modPlayer.WisPot}/5");
			Vit.SetText($"{modPlayer.VitPot}/5");
			Def.SetText($"{modPlayer.DefPot}/10");
			Att.SetText($"{modPlayer.AttPot}/10");
			Dex.SetText($"{modPlayer.DexPot}/5");
			Spd.SetText($"{modPlayer.SpdPot}/5");

			GLife.SetText($"{modPlayer.GLifePot}/10");
			GMana.SetText($"{modPlayer.GManaPot}/5");
			GWis.SetText($"{modPlayer.GWisPot}/5");
			GVit.SetText($"{modPlayer.GVitPot}/5");
			GDef.SetText($"{modPlayer.GDefPot}/10");
			GAtt.SetText($"{modPlayer.GAttPot}/10");
			GDex.SetText($"{modPlayer.GDexPot}/5");
			GSpd.SetText($"{modPlayer.GSpdPot}/5");
			base.Update(gameTime);
		}
	}
}