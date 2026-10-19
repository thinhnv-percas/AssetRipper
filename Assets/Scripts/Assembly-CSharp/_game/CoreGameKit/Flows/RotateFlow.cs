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
	[Token(Token = "0x20005FF")]
	public class RotateFlow : LevelBasedFlowStep, IDisposable
	{
		[Inject(false)]
		[Token(Token = "0x40014AE")]
		[FieldOffset(Offset = "0x60")]
		private new ILevelProgressService _levelProgressService;

		[Inject(false)]
		[Token(Token = "0x40014AF")]
		[FieldOffset(Offset = "0x68")]
		private RemoteConfigManager _remoteConfig;

		[Inject(false)]
		[Token(Token = "0x40014B0")]
		[FieldOffset(Offset = "0x70")]
		private UiManager _uiManager;

		[Inject(false)]
		[Token(Token = "0x40014B1")]
		[FieldOffset(Offset = "0x78")]
		private new EventBus _eventBus;

		[Token(Token = "0x40014B2")]
		[FieldOffset(Offset = "0x80")]
		private float _swipeRemote;

		[Token(Token = "0x40014B3")]
		[FieldOffset(Offset = "0x88")]
		private RotateTutorialUiController _rotateUiController;

		[Token(Token = "0x17000268")]
		public override FlowId FlowId
		{
			[Token(Token = "0x60019AB")]
			[Address(RVA = "0x3D4BC20", Offset = "0x3D4BC20", Length = "0x8")]
			get
			{
				return FlowId.ExampleRotateTutorial;
			}
		}

		[Inject(false)]
		[Token(Token = "0x60019A9")]
		[Address(RVA = "0x3D4BB0C", Offset = "0x3D4BB0C", Length = "0x38")]
		private void Initialize()
		{
			float swipeRemote = _remoteConfig.GetFloat(RemoteKey.rotate_tutorial_swipe);
			_swipeRemote = swipeRemote;
		}

		[Token(Token = "0x60019AA")]
		[Address(RVA = "0x3D4BB44", Offset = "0x3D4BB44", Length = "0xDC")]
		protected override void StartTutorial()
		{
			RotateTutorialUiController rotateUiController = _uiManager.Show<RotateTutorialUiController>();
			_rotateUiController = rotateUiController;
			Action onRequiredInputCompleted = base.OnTutorialComplete;
			_rotateUiController.PlayTapAndSwipeAnimation(_swipeRemote, onRequiredInputCompleted);
		}

		[Token(Token = "0x60019AC")]
		[Address(RVA = "0x3D4BC28", Offset = "0x3D4BC28", Length = "0x5C")]
		public override void Dispose()
		{
			_uiManager.Hide<RotateTutorialUiController>();
			base.Dispose();
		}

		[Token(Token = "0x60019AD")]
		[Address(RVA = "0x3D4BC84", Offset = "0x3D4BC84", Length = "0x88")]
		public RotateFlow()
		{
			Pair<int, int> levelRange = new Pair<int, int>(0, 10);
			m_levelRange = levelRange;
			m_persistCompletion = true;
		}
	}
}
