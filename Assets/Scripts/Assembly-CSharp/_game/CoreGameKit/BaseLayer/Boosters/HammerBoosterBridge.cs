using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using Unco.Extensions;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreGameKit.BaseLayer.Services;
using _game.CoreGameKit.CoreSerivces.BoosterSystem.Core;
using _game.CoreGameKit.UiControllers;
using _game.CoreSystem.Events;
using _game.CoreSystem.New.BoosterSystem.ForcePour.Core;

namespace _game.CoreGameKit.BaseLayer.Boosters
{
	[Token(Token = "0x20006E9")]
	public class HammerBoosterBridge : IDisposable
	{
		[Token(Token = "0x4001739")]
		private const string HammerBoosterId = "hammer_booster";

		[Inject(true)]
		[Token(Token = "0x400173A")]
		[FieldOffset(Offset = "0x10")]
		private BaseLayerBoosterController _boosterController;

		[Inject(false)]
		[Token(Token = "0x400173B")]
		[FieldOffset(Offset = "0x18")]
		private ForcePourController _forcePourController;

		[Inject(true)]
		[Token(Token = "0x400173C")]
		[FieldOffset(Offset = "0x20")]
		private UiManager _uiManager;

		[Inject(true)]
		[Token(Token = "0x400173D")]
		[FieldOffset(Offset = "0x28")]
		private IBoosterService _boosterService;

		[Inject(true)]
		[Token(Token = "0x400173E")]
		[FieldOffset(Offset = "0x30")]
		private InputBlockService _inputBlockService;

		[Inject(true)]
		[Token(Token = "0x400173F")]
		[FieldOffset(Offset = "0x38")]
		private EventBus _eventBus;

		[Token(Token = "0x4001740")]
		[FieldOffset(Offset = "0x40")]
		private IDisposable _handle;

		[Inject(false)]
		[Token(Token = "0x6001D35")]
		[Address(RVA = "0x3D75914", Offset = "0x3D75914", Length = "0x1F4")]
		private void Construct()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HammerBoosterBridge::Construct");
		}

		[Token(Token = "0x6001D36")]
		[Address(RVA = "0x3D75B08", Offset = "0x3D75B08", Length = "0x2BC")]
		public void Dispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HammerBoosterBridge::Dispose");
		}

		[Token(Token = "0x6001D37")]
		[Address(RVA = "0x3D75DC4", Offset = "0x3D75DC4", Length = "0x1C")]
		private void OnForcePourTutorialTriggered(UForcePourTutorialTriggered evt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HammerBoosterBridge::OnForcePourTutorialTriggered");
		}

		[Token(Token = "0x6001D38")]
		[Address(RVA = "0x3D75DE0", Offset = "0x3D75DE0", Length = "0x2D0")]
		private void OnBoosterUsed(string boosterId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HammerBoosterBridge::OnBoosterUsed");
		}

		[Token(Token = "0x6001D39")]
		[Address(RVA = "0x3D76164", Offset = "0x3D76164", Length = "0x68")]
		protected IDisposable RequestInputBlock(InputChannel channels)
		{
			return _inputBlockService.RequestBlock("BoosterTutorial", channels);
		}

		[Token(Token = "0x6001D3A")]
		[Address(RVA = "0x3D760B0", Offset = "0x3D760B0", Length = "0xB4")]
		private void ShowInfoUi()
		{
			HammerBoosterInfoUi hammerBoosterInfoUi = _uiManager.Show<HammerBoosterInfoUi>();
			Action onClose = delegate
			{
				_forcePourController.Cancel();
				_uiManager.Hide<HammerBoosterInfoUi>();
			};
			hammerBoosterInfoUi.Init(onClose);
		}

		[Token(Token = "0x6001D3B")]
		[Address(RVA = "0x3D762E0", Offset = "0x3D762E0", Length = "0xD4")]
		private void OnForcePourCancelled()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HammerBoosterBridge::OnForcePourCancelled");
		}

		[Token(Token = "0x6001D3C")]
		[Address(RVA = "0x3D763B4", Offset = "0x3D763B4", Length = "0x8")]
		public HammerBoosterBridge()
		{
		}
	}
}
