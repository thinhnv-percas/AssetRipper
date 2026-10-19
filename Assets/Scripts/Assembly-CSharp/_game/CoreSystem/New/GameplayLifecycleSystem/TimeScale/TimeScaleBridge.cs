using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States.Behaviors;
using _game.CoreGameKit.BaseLayer.States;
using _game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.TimeScale
{
	[Token(Token = "0x20003F5")]
	public class TimeScaleBridge : IDisposable
	{
		[Inject(false)]
		[Token(Token = "0x4000C8F")]
		[FieldOffset(Offset = "0x10")]
		private GameSpeedController _gameSpeed;

		[Inject(false)]
		[Token(Token = "0x4000C90")]
		[FieldOffset(Offset = "0x18")]
		private BaseLayerRunningState _runningState;

		[Inject(false)]
		[Token(Token = "0x4000C91")]
		[FieldOffset(Offset = "0x20")]
		private BaseLayerWinState _winState;

		[Token(Token = "0x4000C92")]
		[FieldOffset(Offset = "0x28")]
		private TimeScaleBehavior _runningBehavior;

		[Token(Token = "0x4000C93")]
		[FieldOffset(Offset = "0x30")]
		private TimeScaleBehavior _winBehavior;

		[Inject(false)]
		[Token(Token = "0x60010AB")]
		[Address(RVA = "0x3CB6F98", Offset = "0x3CB6F98", Length = "0xE0")]
		public void Initialize()
		{
			TimeScaleBehavior runningBehavior = new TimeScaleBehavior(_gameSpeed, 1f, 0f);
			_runningBehavior = runningBehavior;
			TimeScaleBehavior winBehavior = new TimeScaleBehavior(_gameSpeed, 1f, 1f);
			_winBehavior = winBehavior;
			_runningState.AddBehavior(_runningBehavior);
			_winState.AddBehavior(_winBehavior);
		}

		[Token(Token = "0x60010AC")]
		[Address(RVA = "0x3CB7078", Offset = "0x3CB7078", Length = "0x9C")]
		public void Dispose()
		{
			if (_runningBehavior != null)
			{
				_runningState.RemoveBehavior(_runningBehavior);
				_runningBehavior.Dispose();
			}
			if (_winBehavior != null)
			{
				_winState.RemoveBehavior(_winBehavior);
				_winBehavior.Dispose();
			}
			_runningBehavior = null;
			_winBehavior = null;
		}

		[Token(Token = "0x60010AD")]
		[Address(RVA = "0x3CB7114", Offset = "0x3CB7114", Length = "0x8")]
		public TimeScaleBridge()
		{
		}
	}
}
