using System;
using Systems.FlowSystem.Scripts.Core;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using Unco.RemoteManagementSystem;
using Unco.Utils;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;
using _game.CoreGameKit.Ui.UiControllers;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.Flows
{
	[Token(Token = "0x2000604")]
	public class ZoomFlow : LevelBasedFlowStep
	{
		[Inject(false)]
		[Token(Token = "0x40014D0")]
		[FieldOffset(Offset = "0x60")]
		private new ILevelProgressService _levelProgressService;

		[Inject(false)]
		[Token(Token = "0x40014D1")]
		[FieldOffset(Offset = "0x68")]
		private RemoteConfigManager _remoteConfig;

		[Inject(false)]
		[Token(Token = "0x40014D2")]
		[FieldOffset(Offset = "0x70")]
		private UiManager _uiManager;

		[Inject(false)]
		[Token(Token = "0x40014D3")]
		[FieldOffset(Offset = "0x78")]
		private new EventBus _eventBus;

		[Token(Token = "0x40014D4")]
		[FieldOffset(Offset = "0x80")]
		private ZoomTutorialConfig _zoomRemote;

		[Token(Token = "0x40014D5")]
		[FieldOffset(Offset = "0x90")]
		private ZoomTutorialUiController _zoomTutorialUiController;

		[Token(Token = "0x1700026C")]
		public override FlowId FlowId
		{
			[Token(Token = "0x60019C5")]
			[Address(RVA = "0x3D4D9F4", Offset = "0x3D4D9F4", Length = "0x8")]
			get
			{
				return FlowId.ExampleZoomTutorial;
			}
		}

		[Inject(false)]
		[Token(Token = "0x60019C6")]
		[Address(RVA = "0x3D4D9FC", Offset = "0x3D4D9FC", Length = "0x68")]
		private void Initialize()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ZoomFlow::Initialize");
		}

		[Token(Token = "0x60019C7")]
		[Address(RVA = "0x3D4DA64", Offset = "0x3D4DA64", Length = "0xE0")]
		protected override void StartTutorial()
		{
			ZoomTutorialUiController zoomTutorialUiController = _uiManager.Show<ZoomTutorialUiController>();
			_zoomTutorialUiController = zoomTutorialUiController;
			Action onZoomComplete = base.OnTutorialComplete;
			_zoomTutorialUiController.StartAnimations(_zoomRemote, onZoomComplete);
		}

		[Token(Token = "0x60019C8")]
		[Address(RVA = "0x3D4DB44", Offset = "0x3D4DB44", Length = "0x5C")]
		public override void Dispose()
		{
			_uiManager.Hide<ZoomTutorialUiController>();
			base.Dispose();
		}

		[Token(Token = "0x60019C9")]
		[Address(RVA = "0x3D4DBA0", Offset = "0x3D4DBA0", Length = "0x88")]
		public ZoomFlow()
		{
			Pair<int, int> levelRange = new Pair<int, int>(0, 10);
			m_levelRange = levelRange;
			m_persistCompletion = true;
		}
	}
}
