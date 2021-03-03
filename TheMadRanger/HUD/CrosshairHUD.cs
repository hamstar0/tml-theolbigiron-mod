﻿using System;
using Terraria;
using HamstarHelpers.Classes.Loadable;
using HamstarHelpers.Helpers.Debug;
using HamstarHelpers.Helpers.HUD;


namespace TheMadRanger.HUD {
	partial class CrosshairHUD : ILoadable {
		public const float CrosshairDurationTicksMax = 7f;



		////////////////

		private float PreAimZoomAnimationPercent = 0f;
		private float AimZoomAnimationPercent = -1f;



		////////////////

		void ILoadable.OnModsLoad() {
		}

		void ILoadable.OnModsUnload() {
		}

		void ILoadable.OnPostModsLoad() {
		}


		////////////////

		public bool ConsumesCursor( HUDDrawData hudDrawData ) {
			/*if( Main.InGameUI.CurrentState != null ) {
				return false;
			}*/
			if( HUDHelpers.IsMouseInterfacingWithUI ) { //Main.LocalPlayer.mouseInterface
				return false;
			}

			return hudDrawData.IsAimMode
				|| (hudDrawData.IsPreAimMode && hudDrawData.AimPercent > 0.25f);
		}
	}
}
