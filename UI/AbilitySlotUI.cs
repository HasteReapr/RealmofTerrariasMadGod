using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.Localization;
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

		public override void OnInitialize()
		{
			_vanillaItemSlot = new VanillaItemSlotWrapper(ItemSlot.Context.BankItem, 0.85f)
			{
				Left = { Pixels = 900 },
				Top = { Pixels = 270 },
				ValidItemFunc = item => item.IsAir || (item.modItem is AncientCostFunction function && function.isAbility)
			};
			Texture2D emptySlot = ModContent.GetTexture("ROTMG_Items/UI/EmptyAbilitySlot");
			Texture2D filledSlot = ModContent.GetTexture("ROTMG_Items/UI/FullAbilitySlot");

			empty = new UIImage(emptySlot);
			empty.Left.Set(1.5f, 0f);
			empty.Top.Set(1.5f, 0f);
			_vanillaItemSlot.Append(empty);

			Append(_vanillaItemSlot);
		}
		
		public override void Update(GameTime gameTime)
		{

		}
		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			const int slotX = 500;
			const int slotY = 270;
			if (!_vanillaItemSlot.Item.IsAir)
			{
				ItemSlot.DrawSavings(Main.spriteBatch, slotX + 130, Main.instance.invBottom, true);
				
			}
			else
			{
				string message = "Put abilities here.";
				ChatManager.DrawColorCodedStringWithShadow(Main.spriteBatch, Main.fontMouseText, message, new Vector2(slotX + 50, slotY), new Color(Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor), 0f, Vector2.Zero, Vector2.One, -1f, 2f);
			}
		}
	}
}