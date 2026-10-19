using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;
using _game.CoreGameKit.BaseLayer.Services;
using _game.CoreGameKit.CoreSerivces.BoosterSystem.Core;
using _game.CoreSystem.New.BoosterSystem.VacuumBooster.Runtime;
using _game.CoreSystem.VacuumSystem;

namespace _game.CoreGameKit.BaseLayer.Boosters
{
	[Token(Token = "0x20006EC")]
	public class VacuumBoosterBridge : MonoBehaviour, IDisposable
	{
		[Token(Token = "0x4001743")]
		private const string VacuumBoosterId = "vacuum_booster";

		[Token(Token = "0x4001744")]
		private const KeyCode DebugTriggerKey = KeyCode.V;

		[Inject(false)]
		[Token(Token = "0x4001745")]
		[FieldOffset(Offset = "0x20")]
		private VacuumFacade _vacuumFacade;

		[Inject(false)]
		[Token(Token = "0x4001746")]
		[FieldOffset(Offset = "0x28")]
		private VacuumConfig _config;

		[Inject(true)]
		[Token(Token = "0x4001747")]
		[FieldOffset(Offset = "0x30")]
		private EventBus _eventBus;

		[Inject(true)]
		[Token(Token = "0x4001748")]
		[FieldOffset(Offset = "0x38")]
		private BaseLayerBoosterController _boosterController;

		[Inject(true)]
		[Token(Token = "0x4001749")]
		[FieldOffset(Offset = "0x40")]
		private IBoosterService _boosterService;

		[Inject(true)]
		[Token(Token = "0x400174A")]
		[FieldOffset(Offset = "0x48")]
		private InputBlockService _inputBlockService;

		[Token(Token = "0x400174B")]
		[FieldOffset(Offset = "0x50")]
		private bool _isInitialized;

		[Token(Token = "0x400174C")]
		[FieldOffset(Offset = "0x58")]
		private IDisposable _inputBlock;

		[Inject(false)]
		[Token(Token = "0x6001D43")]
		[Address(RVA = "0x3D76600", Offset = "0x3D76600", Length = "0x1FC")]
		private void Construct()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumBoosterBridge::Construct");
		}

		[Token(Token = "0x6001D44")]
		[Address(RVA = "0x3D767FC", Offset = "0x3D767FC", Length = "0x25C")]
		public void Dispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumBoosterBridge::Dispose");
		}

		[Token(Token = "0x6001D45")]
		[Address(RVA = "0x3D76A58", Offset = "0x3D76A58", Length = "0xC0")]
		private void OnKeepPlayingPurchased(UventKeepPlayingPurchased evt)
		{
			VacuumFacade vacuumFacade = _vacuumFacade;
			if (_vacuumFacade != null && !vacuumFacade.IsVacuuming)
			{
				VacuumExecuteConfig keepPlayingConfig = _config.KeepPlayingConfig;
				if (_vacuumFacade.Execute(keepPlayingConfig) && _inputBlockService != null && _inputBlock == null)
				{
					IDisposable inputBlock = _inputBlockService.RequestBlock("vacuum_booster", InputChannel.BoosterButtons);
					_inputBlock = inputBlock;
				}
			}
		}

		[Token(Token = "0x6001D46")]
		[Address(RVA = "0x3D76B94", Offset = "0x3D76B94", Length = "0x4")]
		private void OnDestroy()
		{
			Dispose();
		}

		[Token(Token = "0x6001D47")]
		[Address(RVA = "0x3D76B98", Offset = "0x3D76B98", Length = "0x90")]
		private void Update()
		{
			if (_isInitialized)
			{
				if (_vacuumFacade != null)
				{
					float deltaTime = Time.deltaTime;
					_vacuumFacade.OnUpdate(deltaTime);
				}
				if (Input.GetKeyDown(KeyCode.V))
				{
					OnBoosterUsed("vacuum_booster");
				}
			}
		}

		[Token(Token = "0x6001D48")]
		[Address(RVA = "0x3D76C28", Offset = "0x3D76C28", Length = "0x198")]
		private void OnBoosterUsed(string boosterId)
		{
			if (boosterId != "vacuum_booster")
			{
				return;
			}
			VacuumFacade vacuumFacade = _vacuumFacade;
			if (_vacuumFacade == null || vacuumFacade.IsVacuuming)
			{
				return;
			}
			VacuumExecuteConfig boosterConfig = _config.BoosterConfig;
			if (_vacuumFacade.Execute(boosterConfig))
			{
				if (_boosterService != null)
				{
					bool flag = _boosterService.UseBooster("vacuum_booster");
				}
				BaseLayerBoosterController boosterController = _boosterController;
				if (_boosterController != null)
				{
					boosterController._activeBoosterId = "vacuum_booster";
				}
				if (_inputBlockService != null && _inputBlock == null)
				{
					IDisposable inputBlock = _inputBlockService.RequestBlock("vacuum_booster", InputChannel.BoosterButtons);
					_inputBlock = inputBlock;
				}
			}
		}

		[Token(Token = "0x6001D49")]
		[Address(RVA = "0x3D76DC0", Offset = "0x3D76DC0", Length = "0xC4")]
		private void OnVacuumCompleted()
		{
			BaseLayerBoosterController boosterController = _boosterController;
			if (_boosterController != null)
			{
				boosterController._activeBoosterId = null;
			}
			if (_inputBlock != null)
			{
				_inputBlock.Dispose();
			}
			_inputBlock = null;
		}

		[Token(Token = "0x6001D4A")]
		[Address(RVA = "0x3D76B18", Offset = "0x3D76B18", Length = "0x7C")]
		private void AcquireInputBlock()
		{
			if (_inputBlockService != null && _inputBlock == null)
			{
				IDisposable inputBlock = _inputBlockService.RequestBlock("vacuum_booster", InputChannel.BoosterButtons);
				_inputBlock = inputBlock;
			}
		}

		[Token(Token = "0x6001D4B")]
		[Address(RVA = "0x3D76E84", Offset = "0x3D76E84", Length = "0x8")]
		public VacuumBoosterBridge()
		{
		}
	}
}
