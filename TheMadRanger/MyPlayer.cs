﻿using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameInput;
using HamstarHelpers.Helpers.Debug;
using TheMadRanger.Items.Weapons;
using TheMadRanger.Items.Accessories;
using TheMadRanger.NetProtocols;
using TheMadRanger.Logic;


namespace TheMadRanger {
	partial class TMRPlayer : ModPlayer {
		private int InventorySlotOfPreviousHeldItem = -1;


		////////////////

		public GunHandling GunHandling { get; } = new GunHandling();

		public PlayerAimMode AimMode { get; } = new PlayerAimMode();

		////

		public bool HasAttemptedShotSinceEquip { get; internal set; } = false;

		////////////////

		public override bool CloneNewInstances => false;



		////////////////

		public override void PreUpdate() {
			if( !Main.gamePaused && !this.player.dead ) {
				this.PreUpdateActive();
			}
		}

		private void PreUpdateActive() {
			if( this.InventorySlotOfPreviousHeldItem != this.player.selectedItem ) {
				if( this.InventorySlotOfPreviousHeldItem != -1 ) {
					Item prevItem = this.player.inventory[this.InventorySlotOfPreviousHeldItem];
					PlayerLogic.CheckPreviousHeldGunItemState( this, prevItem );
				}
			}

			if( PlayerLogic.CheckCurrentHeldGunItemState(this, this.InventorySlotOfPreviousHeldItem) ) {
				PlayerLogic.UpdatePlayerStateForAimMode( this );
			}

			if( this.InventorySlotOfPreviousHeldItem != this.player.selectedItem ) {
				this.InventorySlotOfPreviousHeldItem = this.player.selectedItem;
			}
		}

		////

		public override void UpdateDead() {
			this.GunHandling.UpdateUnequipped( this.player );
			this.AimMode.UpdateUnequippedAimState();
		}

		////////////////

		public override bool PreItemCheck() {
			return !this.GunHandling.IsAnimating;
		}


		////////////////

		public override void ProcessTriggers( TriggersSet triggersSet ) {
			void handleReload() {
				Item gun = this.player.HeldItem;
				if( gun?.active != true ) {
					return;
				}

				var mygun = gun.modItem as TheMadRangerItem;
				if( mygun == null ) {
					return;
				}

				if( this.GunHandling.BeginReload(this.player, mygun) ) {
					if( Main.netMode == NetmodeID.MultiplayerClient && this.player.whoAmI == Main.myPlayer ) {
						GunAnimationProtocol.Broadcast( GunAnimationType.Reload );
					}
				}
			}

			//

			if( TMRMod.Instance.ReloadKey.JustPressed ) {
				if( !Main.gamePaused && !this.player.dead ) {
					handleReload();
				}
			}
		}


		////////////////

		public override void SetupStartInventory( IList<Item> items, bool mediumcoreDeath ) {
			var config = TMRConfig.Instance;

			if( !mediumcoreDeath ) {
				if( config.Get<bool>( nameof(config.PlayerSpawnsWithGun) ) ) {
					var revolver = new Item();
					revolver.SetDefaults( ModContent.ItemType<TheMadRangerItem>() );

					items.Add( revolver );
				}

				if( config.Get<bool>( nameof(TMRConfig.PlayerSpawnsWithBandolier) ) ) {
					var bandolier = new Item();
					bandolier.SetDefaults( ModContent.ItemType<BandolierItem>() );

					items.Add( bandolier );
				}
			}
		}

		////

		public override void OnRespawn( Player player ) {
			if( PlayerLogic.IsHoldingGun(this.player) ) {
				((TheMadRangerItem)player.HeldItem.modItem).InsertAllOnRespawn( player );
			}
		}
	}
}
