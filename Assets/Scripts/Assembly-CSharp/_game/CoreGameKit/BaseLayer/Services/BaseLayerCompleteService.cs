using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.GameBootstrap.Core;
using _game.CoreGameKit.AppLayerInstaller;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;
using _game.CoreGameKit.BaseLayer.Services.Interface;

namespace _game.CoreGameKit.BaseLayer.Services
{
	[Token(Token = "0x2000650")]
	public class BaseLayerCompleteService : IBaseLayerCompleteService
	{
		[Token(Token = "0x40015A5")]
		[FieldOffset(Offset = "0x10")]
		private GameStateController _stateController;

		[Token(Token = "0x40015A6")]
		[FieldOffset(Offset = "0x18")]
		private ILevel _level;

		[Token(Token = "0x40015A7")]
		[FieldOffset(Offset = "0x20")]
		private IBaseLayerExitService _exitService;

		[Token(Token = "0x40015A8")]
		[FieldOffset(Offset = "0x28")]
		private IBaseLayerRestartService _restartService;

		[Inject(false)]
		[Token(Token = "0x40015A9")]
		[FieldOffset(Offset = "0x30")]
		private RateUsController _rateUsController;

		[Inject(false)]
		[Token(Token = "0x6001ACD")]
		[Address(RVA = "0x3D568A8", Offset = "0x3D568A8", Length = "0x50")]
		public void Construct(ILevel level, IBaseLayerExitService exitService, IBaseLayerRestartService restartService)
		{
			_level = level;
			_exitService = exitService;
			_restartService = restartService;
		}

		[Token(Token = "0x6001ACE")]
		[Address(RVA = "0x3D568F8", Offset = "0x3D568F8", Length = "0x1A0")]
		public void Complete()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerCompleteService::Complete");
		}

		[Token(Token = "0x6001ACF")]
		[Address(RVA = "0x3D56A98", Offset = "0x3D56A98", Length = "0x8")]
		public BaseLayerCompleteService()
		{
		}
	}
}
