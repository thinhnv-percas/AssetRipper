using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.ContainerSystem.Runtime;
using Unco.EventBusSystem.Runtime;
using Unco.RemoteManagementSystem;
using UnityEngine;
using _game.CoreGameKit.UiControllers;
using _game.CoreSystem.HealthSystem;

namespace _game.CoreGameKit.Ui.UiControllers
{
	[Token(Token = "0x200054F")]
	public class RefillHeartsUiController : UIController
	{
		[SerializeField]
		[Token(Token = "0x40011F0")]
		[FieldOffset(Offset = "0x48")]
		private RefillHeartPurchaseButton m_refillPurchaseButton;

		[SerializeField]
		[Token(Token = "0x40011F1")]
		[FieldOffset(Offset = "0x50")]
		private Transform m_purchaseButtonParent;

		[Inject(false)]
		[Token(Token = "0x40011F2")]
		[FieldOffset(Offset = "0x58")]
		private HealthController _healthController;

		[Inject(false)]
		[Token(Token = "0x40011F3")]
		[FieldOffset(Offset = "0x60")]
		private EventBus _eventBus;

		[Inject(false)]
		[Token(Token = "0x6001635")]
		[Address(RVA = "0x3D19B48", Offset = "0x3D19B48", Length = "0x494")]
		public unsafe void Construct(RemoteConfigManager remoteConfigManager, Instancer instancer)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RefillHeartsUiController::Construct");
		}

		[Token(Token = "0x6001636")]
		[Address(RVA = "0x3D19FF8", Offset = "0x3D19FF8", Length = "0xA0")]
		private void OnDestroy()
		{
			if (_healthController != null)
			{
				Action<HealthState> value = OnHealthStateChanged;
				_healthController.remove_OnHealthStateChanged(value);
			}
		}

		[Token(Token = "0x6001637")]
		[Address(RVA = "0x3D19FDC", Offset = "0x3D19FDC", Length = "0x1C")]
		private void OnHealthStateChanged(HealthState state)
		{
			int num = (int)(state | HealthState.Infinite);
			if (num == 2)
			{
				base.Hide();
			}
		}

		[Token(Token = "0x6001638")]
		[Address(RVA = "0x3D1A098", Offset = "0x3D1A098", Length = "0xA4")]
		private unsafe void OnPaymentComplete(RefillHeartConfig.PurchaseOption purchaseOption)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RefillHeartsUiController::OnPaymentComplete");
		}

		[Token(Token = "0x6001639")]
		[Address(RVA = "0x3D1A13C", Offset = "0x3D1A13C", Length = "0x54")]
		private void OnPaymentFailed(RefillHeartConfig.PurchaseOption purchaseOption)
		{
			_eventBus.InvokeEvent<UventHeartRefillCantAfford>();
		}

		[Token(Token = "0x600163A")]
		[Address(RVA = "0x3D1A190", Offset = "0x3D1A190", Length = "0x8")]
		public RefillHeartsUiController()
		{
		}
	}
}
