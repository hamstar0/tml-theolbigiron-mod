﻿using System;
using System.ComponentModel;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using HamstarHelpers.Classes.UI.ModConfig;


namespace TheMadRanger {
	class MyFloatInputElement : FloatInputElement { }




	[Label( "The Mad Ranger" )]
	public partial class TMRConfig : ModConfig {
		public static TMRConfig Instance => ModContent.GetInstance<TMRConfig>();



		////////////////

		public override ConfigScope Mode => ConfigScope.ServerSide;


		////////////////

		[DefaultValue( false )]
		public bool DebugModeInfo { get; set; } = false;

		//

		[DefaultValue( false )]
		public bool InfiniteAmmoCheat { get; set; } = false;


		//

		[Label("Color intensity of aim reticule")]
		[Range( 0f, 1f )]
		[DefaultValue( 1f )]
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public float ReticuleIntensityPercent { get; } = 1f;


		//

		[DefaultValue( false )]
		public bool RecipeAvailableForBandolier { get; set; } = false;

		[DefaultValue( true )]
		public bool RecipeAvailableForSpeedloader { get; set; } = true;

		[DefaultValue( false )]
		public bool RecipeAvailableForTheMadRanger { get; set; } = false;

		//

		[DefaultValue( true )]
		public bool PlayerSpawnsWithGun { get; set; } = true;

		[DefaultValue( true )]
		public bool PlayerSpawnsWithBandolier { get; set; } = true;

		[DefaultValue( true )]
		public bool BandolierNeededToReload { get; set; } = true;

		//

		[Label( "Tick duration of reload sequence start" )]
		[Range( 0, 60 * 60 )]
		[DefaultValue( 60 )]
		public int ReloadInitTickDuration { get; set; } = 60;

		[Label( "Tick duration of reload for each round" )]
		[Range( 0, 60 * 60 )]
		[DefaultValue( 28 )]	//35?
		public int ReloadRoundTickDuration { get; set; } = 28;

		[Label( "Tick duration of holster twirl animation" )]
		[Range( 0, 60 * 60 )]
		[DefaultValue( 60 )]
		public int HolsterTwirlTickDuration { get; set; } = 60;

		//

		[Label( "Tick duration of \"quick draw\" mode" )]
		[Range( 0, 60 * 60 )]
		[DefaultValue( 30 )]
		public int QuickDrawTickDuration { get; set; } = 30;

		//

		[Label( "Maximum damage of gun while aimed" )]
		[Range( 1, 999999 )]
		[DefaultValue( 60 )]
		[ReloadRequired]
		public int MaximumAimedGunDamage { get; set; } = 60;

		[Label( "Minimum damage of gun while un-aimed" )]
		[Range( 1, 999999 )]
		[DefaultValue( 40 )]	//10?
		[ReloadRequired]
		public int MinimumUnaimedGunDamage { get; set; } = 40;

		[Label( "Maximum damage of gun while un-aimed" )]
		[Range( 1, 999999 )]
		[DefaultValue( 60 )]	//40?
		[ReloadRequired]
		public int MaximumUnaimedGunDamage { get; set; } = 60;

		[Label( "Degrees range of un-aimed shoots" )]
		[Range( 0f, 360f )]
		[DefaultValue( 30f )]
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public float UnaimedConeDegreesRange { get; set; } = 30f;


		//

		[Label( "Tick duration before \"aim mode\" activates" )]
		[Range( 1, 60 * 60 * 60 )]
		[DefaultValue( 90 )]
		public int AimModeActivationTickDuration { get; set; } = 90;

		[Label( "Added tick duration before \"aim mode\" activates" )]
		[Range( 0, 9999 )]
		[DefaultValue( 10 )]
		public int AimModeActivationTickDurationAddedBuffer { get; set; } = 10;


		[Label( "Rate of \"aim mode\" increase while player moves" )]
		[Range( -60f, 60f )]
		[DefaultValue( -1f )]
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public float AimModeOnPlayerMoveBuildupAmount { get; set; } = -1f;

		[Label( "Rate of \"aim mode\" increase while mouse moves" )]
		[Range( -60f, 60f )]
		[DefaultValue( 0f )] //-0.2f?
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public float AimModeOnMouseMoveBuildupAmount { get; set; } = 0f;

		[Label( "Rate of \"aim mode\" increase while player idle" )]
		[Range( -60f, 60f )]
		[DefaultValue( 1f )]
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public float AimModeOnIdleBuildupAmount { get; set; } = 1f;

		[Label( "Rate of \"aim mode\" increase from landing shots" )]
		[Range( -999f, 999f )]
		[DefaultValue( 5f )]
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public float AimModeOnHitBuildupAmount { get; set; } = 5f;

		[Label( "Rate of \"aim mode\" increase from missing shots" )]
		[Range( -999f, 999f )]
		[DefaultValue( -5f )]
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public float AimModeOnMissBuildupAmount { get; set; } = -5f;


		[Label( "Mouse move distance-per-tick to count as 'moving'" )]
		[Range( 0f, 1000f )]
		[DefaultValue( 1000f )]	//1f
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public float AimModeMouseMoveThreshold { get; set; } = 1000f;

		//

		[Label( "Scale to adjust max movement speed while aim mode 'locked'" )]
		[Range( 0f, 5f )]
		[DefaultValue( 0.5f )]
		[CustomModConfigItem( typeof( MyFloatInputElement ) )]
		public float AimModeLockMoveSpeedScale { get; set; } = 0.5f;


		//

		[Label( "Tick duration of speedloader reloads" )]
		[Range( 0, 60 * 60 )]
		[DefaultValue( 180 )]
		public int SpeedloaderLoadTickDuration { get; set; } = 180;
	}
}
