using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Boosters;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;
using _game.CoreGameKit.UiControllers;
using _game.CoreSystem.Events;

namespace _game.CoreGameKit.Ui.UiControllers
{
	[Token(Token = "0x200053F")]
	public class BaseLayerTopBarUiController : UIController
	{
		[SerializeField]
		[Token(Token = "0x40011AE")]
		[FieldOffset(Offset = "0x48")]
		private RectTransform m_timerRectTransform;

		[SerializeField]
		[Token(Token = "0x40011AF")]
		[FieldOffset(Offset = "0x50")]
		private BoosterButtonView[] m_boosterButtonSlots;

		[SerializeField]
		[Token(Token = "0x40011B0")]
		[FieldOffset(Offset = "0x58")]
		private string[] m_baseLayerBoosterIds;

		[Inject(false)]
		[Token(Token = "0x40011B1")]
		[FieldOffset(Offset = "0x60")]
		private ILevel _level;

		[Inject(false)]
		[Token(Token = "0x40011B2")]
		[FieldOffset(Offset = "0x68")]
		private BaseLayerBoosterController _boosterController;

		[Inject(true)]
		[Token(Token = "0x40011B3")]
		[FieldOffset(Offset = "0x70")]
		private EventBus _eventBus;

		[Token(Token = "0x40011B4")]
		[FieldOffset(Offset = "0x78")]
		private bool _subscribed;

		[Token(Token = "0x40011B5")]
		[FieldOffset(Offset = "0x79")]
		private bool _warningVisible;

		[Token(Token = "0x17000202")]
		public RectTransform TimerRectTransform
		{
			[Token(Token = "0x60015F8")]
			[Address(RVA = "0x3D174B0", Offset = "0x3D174B0", Length = "0x8")]
			get
			{
				return m_timerRectTransform;
			}
		}

		[Inject(false)]
		[Token(Token = "0x60015F9")]
		[Address(RVA = "0x3D174B8", Offset = "0x3D174B8", Length = "0xD0")]
		private void Construct()
		{
			_boosterController.Init(m_boosterButtonSlots, m_baseLayerBoosterIds);
			if (_eventBus != null)
			{
				Action<UventConveyorWarningChanged> observer = OnConveyorWarningChanged;
				_eventBus.ListenEvent(observer);
				_subscribed = true;
			}
		}

		[Token(Token = "0x60015FA")]
		[Address(RVA = "0x3D17588", Offset = "0x3D17588", Length = "0xC")]
		private void OnConveyorWarningChanged(UventConveyorWarningChanged evt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerTopBarUiController::OnConveyorWarningChanged");
		}

		[Token(Token = "0x60015FB")]
		[Address(RVA = "0x3D17594", Offset = "0x3D17594", Length = "0x18C")]
		private void SetBoosterWarnings(bool show)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerTopBarUiController::SetBoosterWarnings");
		}

		[Token(Token = "0x60015FC")]
		[Address(RVA = "0x3D17720", Offset = "0x3D17720", Length = "0x48")]
		public override void OnDisable()
		{
			base.OnDisable();
			if (_warningVisible)
			{
				_warningVisible = false;
				SetBoosterWarnings(show: false);
			}
		}

		[Token(Token = "0x60015FD")]
		[Address(RVA = "0x3D17768", Offset = "0x3D17768", Length = "0xB8")]
		private void OnDestroy()
		{
			if (_subscribed && _eventBus != null)
			{
				Action<UventConveyorWarningChanged> observer = OnConveyorWarningChanged;
				_eventBus.RemoveListener(observer);
				_subscribed = false;
			}
		}

		[Token(Token = "0x60015FE")]
		[Address(RVA = "0x3D17820", Offset = "0x3D17820", Length = "0x8")]
		public BaseLayerTopBarUiController()
		{
		}
	}
}
