using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.CertainWinSpeedUp
{
	[Token(Token = "0x200042D")]
	public class CertainWinSpeedupBridge : IDisposable
	{
		[Inject(false)]
		[Token(Token = "0x4000D27")]
		[FieldOffset(Offset = "0x10")]
		private BaseLayerRunningState _runningState;

		[Inject(false)]
		[Token(Token = "0x4000D28")]
		[FieldOffset(Offset = "0x18")]
		private CertainWinSpeedUpBehavior _speedUp;

		[Inject(false)]
		[Token(Token = "0x6001173")]
		[Address(RVA = "0x3CC1000", Offset = "0x3CC1000", Length = "0x24")]
		public void Initialize()
		{
			_runningState.AddBehavior(_speedUp);
		}

		[Token(Token = "0x6001174")]
		[Address(RVA = "0x3CC1024", Offset = "0x3CC1024", Length = "0x24")]
		public void Dispose()
		{
			_runningState.RemoveBehavior(_speedUp);
		}

		[Token(Token = "0x6001175")]
		[Address(RVA = "0x3CC1048", Offset = "0x3CC1048", Length = "0x8")]
		public CertainWinSpeedupBridge()
		{
		}
	}
}
