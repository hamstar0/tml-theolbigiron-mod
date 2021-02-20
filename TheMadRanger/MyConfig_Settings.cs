﻿using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;


namespace TheMadRanger {
	public partial class TMRConfig : ModConfig {
		[DefaultValue( false )]
		public bool DebugModeInfo { get; set; } = false;

		//

		[DefaultValue( false )]
		public bool InfiniteAmmoCheat { get; set; } = false;


		//

		[Label("Color intensity of aim reticule")]
		[Range( 0f, 1f )]
		[DefaultValue( 0.8f )]
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public float ReticuleIntensityPercent { get; } = 0.8f;


		//

		[DefaultValue( false )]
		public bool RecipeAvailableForTheMadRanger { get; set; } = false;

		[DefaultValue( false )]
		public bool RecipeAvailableForBandolier { get; set; } = false;

		[DefaultValue( true )]
		public bool RecipeAvailableForSpeedloader { get; set; } = true;

		//

		[DefaultValue( true )]
		public bool PlayerSpawnsWithGun { get; set; } = true;

		[DefaultValue( true )]
		public bool PlayerSpawnsWithBandolier { get; set; } = true;

		[DefaultValue( true )]
		public bool BandolierNeededToReload { get; set; } = true;
	}
}
