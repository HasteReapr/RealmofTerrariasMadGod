using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Config.UI;
using Terraria.UI;

namespace ROTMG_Items
{
	[BackgroundColor(144, 252, 249)]
	[Label("Fame Multiplier")]
	public class FameConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;

		[DefaultValue(true)]
		public float FameMultiplier = 0.25f;

		// Structs - These require special code. We've implemented Color and Vector2 so far.
		// public Color SomeColor;
		// public Vector2 SomeVector2;
		// public Point SomePoint; // notice the not implemented message.

		// Using a custom class as a key in a Dictionary. When used as a Dictionary Key, special code must be used.
		//public Dictionary<ClassUsedAsKey, Color> CustomKey = new Dictionary<ClassUsedAsKey, Color>();

		public void ROTMG_Items_Config()
		{
			// Doing the initialization of defaults for reference types in a constructor is also acceptable.
			FameConfig fCon = new FameConfig()
			{
				FameMultiplier = .25f
			};
		}
	}
}