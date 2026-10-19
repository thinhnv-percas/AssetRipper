using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using Unco.ResourceSystem;
using Unco.RewardSystem;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Services;
using _game.CoreGameKit.BaseLayer.Services.Interface;
using _game.CoreGameKit.CoreSerivces.HoveringTextSystem;
using _game.CoreGameKit.Ui.UiControllers;
using _game.CoreGameKit.UiControllers;
using _game.Systems.PaymentSystem.Data;
using _game.Systems.PaymentSystem.Flow;

namespace _game.CoreGameKit.BaseLayer.Controller.Runtime.States.Behaviors
{
	[Serializable]
	[Token(Token = "0x20006DC")]
	public class KeepPlayingBehavior : IStateBehavior
	{
		[Inject(false)]
		[Token(Token = "0x40016FC")]
		[FieldOffset(Offset = "0x10")]
		private UiManager _uiManager;

		[Inject(false)]
		[Token(Token = "0x40016FD")]
		[FieldOffset(Offset = "0x18")]
		private KeepPlayingCostService _costService;

		[Inject(false)]
		[Token(Token = "0x40016FE")]
		[FieldOffset(Offset = "0x20")]
		private PaymentFlowController _paymentFlowController;

		[Inject(false)]
		[Token(Token = "0x40016FF")]
		[FieldOffset(Offset = "0x28")]
		private IBaseLayerRestartService _restartService;

		[Inject(false)]
		[Token(Token = "0x4001700")]
		[FieldOffset(Offset = "0x30")]
		private BaseLayerStateMachine _stateMachine;

		[Inject(false)]
		[Token(Token = "0x4001701")]
		[FieldOffset(Offset = "0x38")]
		private BaseLayerRunningState _runningState;

		[Inject(false)]
		[Token(Token = "0x4001702")]
		[FieldOffset(Offset = "0x40")]
		private EventBus _eventBus;

		[Inject(false)]
		[Token(Token = "0x4001703")]
		[FieldOffset(Offset = "0x48")]
		private HoveringTextController _hoveringTextController;

		[Token(Token = "0x4001704")]
		[FieldOffset(Offset = "0x50")]
		private readonly float _showDelay;

		[Token(Token = "0x4001705")]
		[FieldOffset(Offset = "0x54")]
		private float _elapsed;

		[Token(Token = "0x4001706")]
		[FieldOffset(Offset = "0x58")]
		private bool _uiShown;

		[Token(Token = "0x6001CF6")]
		[Address(RVA = "0x3D72A8C", Offset = "0x3D72A8C", Length = "0x34")]
		public KeepPlayingBehavior(float showDelay = 0f)
		{
			_showDelay = showDelay;
		}

		[Token(Token = "0x6001CF7")]
		[Address(RVA = "0x3D72AC0", Offset = "0x3D72AC0", Length = "0xC")]
		public void OnStateEnter()
		{
			_elapsed = 0f;
			_uiShown = false;
		}

		[Token(Token = "0x6001CF8")]
		[Address(RVA = "0x3D72ACC", Offset = "0x3D72ACC", Length = "0x68")]
		public void OnStateUpdate()
		{
			if (!_uiShown)
			{
				float deltaTime = Time.deltaTime;
				if (!((_elapsed += deltaTime) < _showDelay))
				{
					_uiShown = true;
					ShowKeepPlayingUi();
				}
			}
		}

		[Token(Token = "0x6001CF9")]
		[Address(RVA = "0x3D72C0C", Offset = "0x3D72C0C", Length = "0x54")]
		public void OnStateExit()
		{
			_uiManager.Hide<KeepPlayingUiController>();
		}

		[Token(Token = "0x6001CFA")]
		[Address(RVA = "0x3D72B34", Offset = "0x3D72B34", Length = "0xD8")]
		private void ShowKeepPlayingUi()
		{
			int currentCost = _costService.GetCurrentCost();
			KeepPlayingUiController keepPlayingUiController = _uiManager.Show<KeepPlayingUiController>();
			Action onContinue = OnContinue;
			keepPlayingUiController.Init(currentCost, onContinue);
		}

		[Token(Token = "0x6001CFB")]
		[Address(RVA = "0x3D72C60", Offset = "0x3D72C60", Length = "0x164")]
		private void OnContinue()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("KeepPlayingBehavior::OnContinue");
		}
	}
}
