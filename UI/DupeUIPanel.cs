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
	internal class DupeUIPanel : UIState
	{
		public VanillaItemSlotWrapper vanillaItemSlot;
		public DragableUIPanel DupeUI;
		public UIHoverImageButton CloseButton;
		public UIHoverImageButton DupeButton;
		private UIText DupeWords;
		private UIText points;
		public static bool Visible = false;

		public override void OnInitialize()
		{
			DupeUI = new DragableUIPanel();
			DupeUI.SetPadding(0);
			DupeUI.Left.Set(150f, 0f);
			DupeUI.Top.Set(150f, 0f);
			DupeUI.Width.Set(150f, 0f);
			DupeUI.Height.Set(150f, 0f);
			DupeUI.BackgroundColor = new Color(73, 94, 171);

			vanillaItemSlot = new VanillaItemSlotWrapper(ItemSlot.Context.BankItem, 0.85f)
			{
				Left = { Pixels = 55 },
				Top = { Pixels = 45 },
				Width = { Pixels = 50 },
				Height = { Pixels = 50 }
			};
			DupeUI.Append(vanillaItemSlot);

			Texture2D buttonDeleteTexture = ModContent.GetTexture("Terraria/UI/ButtonDelete");
			UIHoverImageButton closeButton = new UIHoverImageButton(buttonDeleteTexture, Language.GetTextValue("LegacyInterface.52")); // Localized text for "Close"
			closeButton.Left.Set(122, 0f);
			closeButton.Top.Set(10, 0f);
			closeButton.Width.Set(22, 0f);
			closeButton.Height.Set(22, 0f);
			closeButton.OnClick += new MouseEvent(CloseButtonClicked);
			DupeUI.Append(closeButton);

			Texture2D buttonButtonTexture = ModContent.GetTexture("ROTMG_Items/UI/Button_button");
			UIHoverImageButton dupeButton = new UIHoverImageButton(buttonButtonTexture, Language.GetTextValue("Dupe"));
			dupeButton.Left.Set(17, 0f);
			dupeButton.Top.Set(90, 0f);
			dupeButton.Width.Set(240, 0f);
			dupeButton.Width.Set(32, 0f);
			dupeButton.OnClick += (evt, elem) => ModContent.GetInstance<DupeUIFunction>().dupeGamble();
			DupeUI.Append(dupeButton);

			//image = new UIImage(ModContent.GetTexture("ROTMG_Items/Items/Consumables/LifePot"));
			//image.Left.Set(10, 0f);
			//image.Top.Set(10, 0f);
			//image.Width.Set(126, 0f);
			//image.Height.Set(18, 0f);
			//DupeUI.Append(DupeWords);

			DupeWords = new UIText("Duplicate Item");
			DupeWords.Width.Set(50, 0f);
			DupeWords.Height.Set(34, 0f);
			DupeWords.Top.Set(95, 0f);
			DupeWords.Left.Set(20, 0f);
			DupeUI.Append(DupeWords);

			points = new UIText("");
			points.Width.Set(130, 0f);
			points.Height.Set(34, 0f);
			points.Top.Set(125, 0f);
			points.Left.Set(0, 0f);
			DupeUI.Append(points);

			Append(DupeUI);
		}

		private void CloseButtonClicked(UIMouseEvent evt, UIElement listeningElement)
		{
			Main.PlaySound(SoundID.MenuClose);
			Visible = false;
		}

		public override void Update(GameTime gameTime)
		{
			var modPlayer = Main.LocalPlayer.GetModPlayer<DupeUIFunction>();
			points.SetText($"Dupe Points : {modPlayer.points}/10");
			base.Update(gameTime);
		}
	}
}