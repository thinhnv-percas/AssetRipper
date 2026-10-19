using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using Unco.ResourceSystem;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;
using _game.CoreGameKit.BaseLayer.Installers;
using _game.CoreGameKit.BaseLayer.LevelSystem;
using _game.CoreGameKit.BaseLayer.Services.Interface;
using _game.CoreGameKit.BaseLayer.States;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;
using _game.CoreGameKit.Tracking.Tools.Logging;

namespace _game.CoreGameKit.BaseLayer.Services
{
	[Token(Token = "0x2000651")]
	public class BaseLayerWinService : IBaseLayerWinService
	{
		[Token(Token = "0x40015AA")]
		[FieldOffset(Offset = "0x10")]
		internal readonly ULogger _logger;

		[Inject(false)]
		[Token(Token = "0x40015AB")]
		[FieldOffset(Offset = "0x18")]
		private ILevelProgressService _levelProgressService;

		[Inject(false)]
		[Token(Token = "0x40015AC")]
		[FieldOffset(Offset = "0x20")]
		private BaseLayerStateMachine _stateMachine;

		[Inject(false)]
		[Token(Token = "0x40015AD")]
		[FieldOffset(Offset = "0x28")]
		private BaseLayerWinState _winState;

		[Inject(false)]
		[Token(Token = "0x40015AE")]
		[FieldOffset(Offset = "0x30")]
		private BaseLayerWinSequenceController _winSequenceController;

		[Inject(false)]
		[Token(Token = "0x40015AF")]
		[FieldOffset(Offset = "0x38")]
		private IResourceService _resourceService;

		[Inject(false)]
		[Token(Token = "0x40015B0")]
		[FieldOffset(Offset = "0x40")]
		private LevelNavigationResolver _navigationResolver;

		[Inject(false)]
		[Token(Token = "0x40015B1")]
		[FieldOffset(Offset = "0x48")]
		private EventBus _eventBus;

		[Inject(false)]
		[Token(Token = "0x40015B2")]
		[FieldOffset(Offset = "0x50")]
		private BaseLayerWaitState _waitState;

		[Inject(false)]
		[Token(Token = "0x40015B3")]
		[FieldOffset(Offset = "0x58")]
		private LevelContext _levelContext;

		[Inject(false)]
		[Token(Token = "0x40015B4")]
		[FieldOffset(Offset = "0x60")]
		private InputBlockService _inputBlockService;

		[Inject(false)]
		[Token(Token = "0x40015B5")]
		[FieldOffset(Offset = "0x68")]
		private TransactionContextFactory _ctxFactory;

		[Token(Token = "0x6001AD0")]
		[Address(RVA = "0x3D56AA0", Offset = "0x3D56AA0", Length = "0x4F0")]
		public unsafe void Win()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerWinService::Win");
		}

		[Token(Token = "0x6001AD1")]
		[Address(RVA = "0x3D5727C", Offset = "0x3D5727C", Length = "0x78")]
		public BaseLayerWinService()
		{
			ULogger logger = new ULogger();
			_logger = logger;
		}
	}
}
