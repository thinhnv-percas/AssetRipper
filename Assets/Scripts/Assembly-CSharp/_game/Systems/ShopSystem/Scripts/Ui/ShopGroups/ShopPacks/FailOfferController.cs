using System;
using Systems.ShopSystem.Scripts.Ui.ShopGroups;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using Unco.RemoteManagementSystem;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;
using _game.CoreGameKit.BaseLayer.Services;
using _game.CoreGameKit.Ui.UiControllers;
using _game.CoreGameKit.UiControllers;

namespace _game.Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopPacks
{
	[Token(Token = "0x200070D")]
	public class FailOfferController : MonoBehaviour, IDisposable
	{
		[SerializeField]
		[Token(Token = "0x400179F")]
		[FieldOffset(Offset = "0x20")]
		private ShopGroupView m_shopGroupView;

		[SerializeField]
		[Token(Token = "0x40017A0")]
		[FieldOffset(Offset = "0x28")]
		private GameObject m_keepPlayingInfo;

		[Inject(true)]
		[Token(Token = "0x40017A1")]
		[FieldOffset(Offset = "0x30")]
		private BaseLayerStateMachine _stateMachine;

		[Inject(true)]
		[Token(Token = "0x40017A2")]
		[FieldOffset(Offset = "0x38")]
		private BaseLayerRunningState _runningState;

		[Inject(false)]
		[Token(Token = "0x40017A3")]
		[FieldOffset(Offset = "0x40")]
		private UiManager _uiManager;

		[Inject(false)]
		[Token(Token = "0x40017A4")]
		[FieldOffset(Offset = "0x48")]
		private EventBus _eventBus;

		[Inject(false)]
		[Token(Token = "0x40017A5")]
		[FieldOffset(Offset = "0x50")]
		private KeepPlayingCostService _costService;

		[Inject(false)]
		[Token(Token = "0x40017A6")]
		[FieldOffset(Offset = "0x58")]
		private RemoteConfigManager _remoteConfigManager;

		[Inject(false)]
		[Token(Token = "0x6001DBD")]
		[Address(RVA = "0x3D7C554", Offset = "0x3D7C554", Length = "0xE4")]
		private void Construct()
		{
			Action value = OnPurchaseCompleted;
			m_shopGroupView.add_OnPurchaseCompleted(value);
			Action value2 = OnPurchaseFailed;
			m_shopGroupView.add_OnPurchaseFailed(value2);
		}

		[Token(Token = "0x6001DBE")]
		[Address(RVA = "0x3D7C638", Offset = "0x3D7C638", Length = "0x98")]
		private void OnPurchaseCompleted()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FailOfferController::OnPurchaseCompleted");
		}

		[Token(Token = "0x6001DBF")]
		[Address(RVA = "0x3D7C6D0", Offset = "0x3D7C6D0", Length = "0x4")]
		private void OnPurchaseFailed()
		{
		}

		[Token(Token = "0x6001DC0")]
		[Address(RVA = "0x3D7C6D4", Offset = "0x3D7C6D4", Length = "0xE4")]
		public void Dispose()
		{
			Action value = OnPurchaseCompleted;
			m_shopGroupView.remove_OnPurchaseCompleted(value);
			Action value2 = OnPurchaseFailed;
			m_shopGroupView.remove_OnPurchaseFailed(value2);
		}

		[Token(Token = "0x6001DC1")]
		[Address(RVA = "0x3D7C7B8", Offset = "0x3D7C7B8", Length = "0x8")]
		public FailOfferController()
		{
		}
	}
}
