using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using HamstarHelpers.Services.AnimatedColor;
using HamstarHelpers.Helpers.Debug;


namespace TheMadRanger {
	public partial class TMRMod : Mod {
		public const float CrosshairDurationTicksMax = 12f;



		////////////////

		private float PreAimZoomAnimationPercent = 0f;
		private float AimZoomAnimationPercent = -1f;
		private AnimatedColors ColorAnim = null;



		////////////////

		public override void ModifyInterfaceLayers( List<GameInterfaceLayer> layers ) {
			float aimPercent;
			bool hasGun;
			bool isAimMode = this.RunAimCursorAnimation( out hasGun, out aimPercent );
			bool isPreAimMode = isAimMode
				? false
				: this.RunPreAimCursorAnimation();

			int idx = layers.FindIndex( layer => layer.Name.Equals( "Vanilla: Cursor" ) );
			if( idx == -1 ) { return; }

			if( this.ColorAnim == null ) {
				this.ColorAnim = AnimatedColors.Create( 6, AnimatedColors.Alert.Colors.ToArray() );
			}

			GameInterfaceDrawMethod draw = () => {
				if( isPreAimMode ) {
					this.DrawPreAimCursor();
				} else if( isAimMode ) {
					this.DrawAimCursor();
				} else if( hasGun ) {
					this.DrawUnaimCursor();
				}

				if( TMRConfig.Instance.DebugModeInfo ) {
					this.DrawDebugLine();
				}

				return true;
			};
			var interfaceLayer = new LegacyGameInterfaceLayer( "TheMadRanger: Crosshair", draw, InterfaceScaleType.UI );

			//layers.RemoveAt( idx );
			layers.Insert( idx, interfaceLayer );
		}


		////////////////

		private void DrawDebugLine() {
			Player plr = Main.LocalPlayer;

			Vector2 fro = plr.MountedCenter;
			fro -= Main.screenPosition;

			Vector2 to = new Vector2( (float)Math.Cos( plr.itemRotation ), (float)Math.Sin( plr.itemRotation ) );
			to *= plr.direction * 64;
			to += plr.MountedCenter;
			to -= Main.screenPosition;

			Utils.DrawLine( Main.spriteBatch, fro, to, Color.White );
			Utils.DrawLaser( Main.spriteBatch, Main.magicPixel, fro, to, Vector2.One * 4f, new Utils.LaserLineFraming( DelegateMethods.RainbowLaserDraw ) );
		}
	}
}