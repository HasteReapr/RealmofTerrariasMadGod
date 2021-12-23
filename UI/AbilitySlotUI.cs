using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.UI.Chat;
using Terraria.GameContent.UI.Elements;
using ROTMG_Items.Items.Abilities;

namespace ROTMG_Items.UI
{
	internal class AbilitySlotUI : UIState
	{
		public VanillaItemSlotWrapper _vanillaItemSlot;
		public AncientCostFunction ancientCostFunction;
		public UIImage empty;
		public UIImage full;
		public int XVal = Main.graphics.GraphicsDevice.Viewport.Width - 150 - 100;
		public int YVal = Main.graphics.GraphicsDevice.Viewport.Height - 150 - 300;
		Texture2D emptySlot = ModContent.GetTexture("ROTMG_Items/UI/EmptyAbilitySlot");
		Texture2D filledSlot = ModContent.GetTexture("ROTMG_Items/UI/FullAbilitySlot");

		public override void OnInitialize()
		{
			//Main.graphics.GraphicsDevice.Viewport.Width - SizeOfElementBecauseItWillBeOffTheScreen - DesiredWidthAwayFromRightSide(LikePadding)
			_vanillaItemSlot = new VanillaItemSlotWrapper(ItemSlot.Context.BankItem, 0.85f)
			{
				Left = { Pixels = XVal },
				Top = { Pixels = YVal},
				ValidItemFunc = item => item.IsAir || (item.modItem is AncientCostFunction function && function.isAbility)
			};

			//empty = new UIImage(emptySlot);
			//empty.Left.Set(1.5f, 0f);
			//empty.Top.Set(1.5f, 0f);
			//_vanillaItemSlot.Append(empty);

			Append(_vanillaItemSlot);
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			XVal = Main.graphics.GraphicsDevice.Viewport.Width - 150 - 100;
			YVal = Main.graphics.GraphicsDevice.Viewport.Height - 150 - 300;
			_vanillaItemSlot.Left.Pixels = XVal;
			_vanillaItemSlot.Top.Pixels = YVal;
		}

        public override void MouseOver(UIMouseEvent evt)
        {
			string message = "Put abilities here.";
			ChatManager.DrawColorCodedStringWithShadow(Main.spriteBatch, Main.fontMouseText, message, new Vector2(XVal + 50, YVal), new Color(Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor), 0f, Vector2.Zero, Vector2.One, -1f, 2f);
		}
	}
}