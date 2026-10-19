using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using Unco.GameBootstrap.Core;
using _game.CoreGameKit.BaseLayer.Services.Interface;
using _game.CoreSystem.HealthSystem;

namespace _game.CoreGameKit.BaseLayer.Services
{
	[Token(Token = "0x2000654")]
	public class BaseLayerRestartService : IBaseLayerRestartService
	{
		[Token(Token = "0x40015BA")]
		[FieldOffset(Offset = "0x10")]
		private GameStateController _stateController;

		[Inject(true)]
		[Token(Token = "0x40015BB")]
		[FieldOffset(Offset = "0x18")]
		private HealthController _healthController;

		[Inject(true)]
		[Token(Token = "0x40015BC")]
		[FieldOffset(Offset = "0x20")]
		private IBaseLayerExitService _exitService;

		[Inject(false)]
		[Token(Token = "0x40015BD")]
		[FieldOffset(Offset = "0x28")]
		private EventBus _eventBus;

		[Inject(false)]
		[Token(Token = "0x6001AD8")]
		[Address(RVA = "0x3D57400", Offset = "0x3D57400", Length = "0x8")]
		public void Construct(GameStateController stateController)
		{
			_stateController = stateController;
		}

		[Token(Token = "0x6001AD9")]
		[Address(RVA = "0x3D57408", Offset = "0x3D57408", Length = "0xE4")]
		public void Restart()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerRestartService::Restart");
		}

		[Token(Token = "0x6001ADA")]
		[Address(RVA = "0x3D5750C", Offset = "0x3D5750C", Length = "0x20")]
		public void RestartForDebug()
		{
			_stateController.StartBaseLayer();
		}

		[Token(Token = "0x6001ADB")]
		[Address(RVA = "0x3D574EC", Offset = "0x3D574EC", Length = "0x20")]
		private void RestartInternal()
		{
			_stateController.StartBaseLayer();
		}

		[Token(Token = "0x6001ADC")]
		[Address(RVA = "0x3D5752C", Offset = "0x3D5752C", Length = "0x8")]
		public BaseLayerRestartService()
		{
		}
	}
}
