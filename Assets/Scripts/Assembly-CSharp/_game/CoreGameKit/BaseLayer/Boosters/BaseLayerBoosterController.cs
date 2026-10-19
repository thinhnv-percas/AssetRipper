using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Services;
using _game.CoreGameKit.CoreSerivces.BoosterSystem.Config;
using _game.CoreGameKit.CoreSerivces.BoosterSystem.Core;
using _game.CoreGameKit.CoreSerivces.BoosterSystem.Purchase;
using _game.CoreGameKit.CoreSerivces.HoveringTextSystem;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;
using _game.CoreGameKit.Ui.UiControllers;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.BaseLayer.Boosters
{
	[Token(Token = "0x20006E6")]
	public class BaseLayerBoosterController : IDisposable
	{
		[Inject(false)]
		[Token(Token = "0x4001714")]
		[FieldOffset(Offset = "0x10")]
		private IBoosterService _boosterService;

		[Inject(false)]
		[Token(Token = "0x4001715")]
		[FieldOffset(Offset = "0x18")]
		private ILevelProgressService _levelProgressService;

		[Inject(false)]
		[Token(Token = "0x4001716")]
		[FieldOffset(Offset = "0x20")]
		private UiManager _uiManager;

		[Inject(false)]
		[Token(Token = "0x4001717")]
		[FieldOffset(Offset = "0x28")]
		private IBoosterPurchaseHandler _purchaseHandler;

		[Inject(false)]
		[Token(Token = "0x4001718")]
		[FieldOffset(Offset = "0x30")]
		private BoosterUnlockHandler _unlockHandler;

		[Inject(false)]
		[Token(Token = "0x4001719")]
		[FieldOffset(Offset = "0x38")]
		private InputBlockService _inputBlockService;

		[Token(Token = "0x400171A")]
		[FieldOffset(Offset = "0x40")]
		private BoosterButtonView[] _buttonSlots;

		[Token(Token = "0x400171B")]
		[FieldOffset(Offset = "0x48")]
		private string[] _boosterIds;

		[Token(Token = "0x400171C")]
		[FieldOffset(Offset = "0x50")]
		private readonly Dictionary<string, BoosterButtonView> _buttonMap;

		[Token(Token = "0x400171D")]
		[FieldOffset(Offset = "0x58")]
		private readonly Dictionary<string, BoosterRemoteConfigData> _configMap;

		[Token(Token = "0x400171E")]
		[FieldOffset(Offset = "0x60")]
		internal string _activeBoosterId;

		[Token(Token = "0x400171F")]
		private static readonly Dictionary<string, InputChannel> BoosterChannelMap = new Dictionary<string, InputChannel>
		{
			{
				"hammer_booster",
				InputChannel.HammerButton
			},
			{
				"vacuum_booster",
				InputChannel.VacuumButton
			},
			{
				"swap_booster",
				InputChannel.SwapButton
			}
		};

		[CompilerGenerated]
		[Token(Token = "0x4001720")]
		[FieldOffset(Offset = "0x68")]
		internal Action<string> OnBoosterUsed;

		[Inject(false)]
		[Token(Token = "0x4001721")]
		[FieldOffset(Offset = "0x70")]
		private HoveringTextController m_hoveringTextController;

		[CompilerGenerated]
		[Token(Token = "0x6001D15")]
		[Address(RVA = "0x3D736B4", Offset = "0x3D736B4", Length = "0xB4")]
		public void add_OnBoosterUsed(Action<string> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerBoosterController::add_OnBoosterUsed");
		}

		[CompilerGenerated]
		[Token(Token = "0x6001D16")]
		[Address(RVA = "0x3D73768", Offset = "0x3D73768", Length = "0xB4")]
		public void remove_OnBoosterUsed(Action<string> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerBoosterController::remove_OnBoosterUsed");
		}

		[Token(Token = "0x6001D17")]
		[Address(RVA = "0x3D7381C", Offset = "0x3D7381C", Length = "0xCC")]
		public static InputChannel GetChannel(string boosterId)
		{
			if (BoosterChannelMap.TryGetValue(boosterId, out var value))
			{
				return value;
			}
			return InputChannel.BoosterButtons;
		}

		[Token(Token = "0x6001D18")]
		[Address(RVA = "0x3D738E8", Offset = "0x3D738E8", Length = "0x1CC")]
		public void Init(BoosterButtonView[] buttonSlots, string[] boosterIds)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerBoosterController::Init");
		}

		[Token(Token = "0x6001D19")]
		[Address(RVA = "0x3D73F80", Offset = "0x3D73F80", Length = "0x110")]
		public void Dispose()
		{
			if (_boosterService != null)
			{
				Action<string, int> value = OnCountChanged;
				_boosterService.OnCountChanged -= value;
			}
		}

		[Token(Token = "0x6001D1A")]
		[Address(RVA = "0x3D73AB4", Offset = "0x3D73AB4", Length = "0x4CC")]
		private void InitializeButtons()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerBoosterController::InitializeButtons");
		}

		[Token(Token = "0x6001D1B")]
		[Address(RVA = "0x3D74090", Offset = "0x3D74090", Length = "0x1C8")]
		private BoosterButtonState ResolveState(string boosterId, int currentLevel)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerBoosterController::ResolveState");
			return default;
		}

		[Token(Token = "0x6001D1C")]
		[Address(RVA = "0x3D74510", Offset = "0x3D74510", Length = "0x8")]
		public void SetActiveBooster(string boosterId)
		{
			_activeBoosterId = boosterId;
		}

		[Token(Token = "0x6001D1D")]
		[Address(RVA = "0x3D74518", Offset = "0x3D74518", Length = "0x8")]
		public string GetActiveBooster()
		{
			return _activeBoosterId;
		}

		[Token(Token = "0x6001D1E")]
		[Address(RVA = "0x3D74520", Offset = "0x3D74520", Length = "0xC")]
		public void ClearActiveBooster()
		{
			_activeBoosterId = null;
		}

		[Token(Token = "0x6001D1F")]
		[Address(RVA = "0x3D7452C", Offset = "0x3D7452C", Length = "0xB8")]
		public unsafe RectTransform GetButtonRectTransform(string boosterId)
		{
			string key = default(string);
			Component value;
			if (_buttonMap.TryGetValue(key, out *(BoosterButtonView*)(&value)))
			{
				return value.GetComponent<RectTransform>();
			}
			return null;
		}

		[Token(Token = "0x6001D20")]
		[Address(RVA = "0x3D745E4", Offset = "0x3D745E4", Length = "0xAC")]
		public void TriggerBoosterUse(string boosterId)
		{
			if (_buttonMap.TryGetValue(boosterId, out var value) && value.CurrentState == BoosterButtonState.Active && OnBoosterUsed != null)
			{
				OnBoosterUsed(boosterId);
			}
		}

		[Token(Token = "0x6001D21")]
		[Address(RVA = "0x3D74690", Offset = "0x3D74690", Length = "0x1EC")]
		private void OnBoosterClicked(string boosterId)
		{
			if (_inputBlockService != null)
			{
				if (BoosterChannelMap == null)
				{
					throw new NullReferenceException();
				}
				InputChannel channel = ((!BoosterChannelMap.TryGetValue(boosterId, out var value)) ? InputChannel.BoosterButtons : value);
				if (_inputBlockService.IsBlocked(channel))
				{
					return;
				}
			}
			if (!_buttonMap.TryGetValue(boosterId, out var value2))
			{
				return;
			}
			if (value2.CurrentState != BoosterButtonState.NoStock)
			{
				if (value2.CurrentState != BoosterButtonState.Active)
				{
					if (value2.CurrentState == BoosterButtonState.Locked)
					{
						ShowLockedTooltip(boosterId);
					}
				}
				else if (OnBoosterUsed != null)
				{
					OnBoosterUsed(boosterId);
				}
			}
			else
			{
				ShowPurchasePopup(boosterId);
			}
		}

		[Token(Token = "0x6001D22")]
		[Address(RVA = "0x3D7487C", Offset = "0x3D7487C", Length = "0x198")]
		private void ShowLockedTooltip(string boosterId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerBoosterController::ShowLockedTooltip");
		}

		[Token(Token = "0x6001D23")]
		[Address(RVA = "0x3D74A14", Offset = "0x3D74A14", Length = "0x1FC")]
		private void ShowPurchasePopup(string boosterId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerBoosterController::ShowPurchasePopup");
		}

		[Token(Token = "0x6001D24")]
		[Address(RVA = "0x3D74C10", Offset = "0x3D74C10", Length = "0x118")]
		private void OnCountChanged(string boosterId, int newCount)
		{
			if (_buttonMap.TryGetValue(boosterId, out var value))
			{
				int currentLevelIndex = _levelProgressService.CurrentLevelIndex;
				BoosterButtonState state = ResolveState(boosterId, currentLevelIndex);
				value.UpdateState(state, newCount);
			}
		}

		[Token(Token = "0x6001D25")]
		[Address(RVA = "0x3D74F54", Offset = "0x3D74F54", Length = "0xE0")]
		public BaseLayerBoosterController()
		{
			Dictionary<string, BoosterButtonView> buttonMap = new Dictionary<string, BoosterButtonView>();
			_buttonMap = buttonMap;
			Dictionary<string, BoosterRemoteConfigData> configMap = new Dictionary<string, BoosterRemoteConfigData>();
			_configMap = configMap;
		}
	}
}
