using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

namespace ROTMG_Items.UI
{
	internal class AbilityUI : UIState
	{
		public DragableUIPanel AbilitySlot;
		public static bool Visible;
		private VanillaItemSlotWrapper _vanillaItemSlot;
		public override void OnInitialize()
		{
			AbilitySlot.Left.Set(400f, 0f);
			AbilitySlot.Top.Set(100f, 0f);
			AbilitySlot.Width.Set(170f, 0f);
			AbilitySlot.Height.Set(70f, 0f); // Sets the dimensions of the UI element.
			AbilitySlot.BackgroundColor = new Color(73, 94, 171); // Sets the color of the UI element, using RGB values.
		}
		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}
	}
}