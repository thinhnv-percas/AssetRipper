using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.TapHoldSpeedUp
{
	[Token(Token = "0x20003F9")]
	public class TapHoldSpeedUpBridge : IDisposable
	{
		[Inject(false)]
		[Token(Token = "0x4000C9F")]
		[FieldOffset(Offset = "0x10")]
		private BaseLayerRunningState _runningState;

		[Inject(false)]
		[Token(Token = "0x4000CA0")]
		[FieldOffset(Offset = "0x18")]
		private TapHoldSpeedUpBehavior _behavior;

		[Inject(false)]
		[Token(Token = "0x60010BA")]
		[Address(RVA = "0x3CB8060", Offset = "0x3CB8060", Length = "0x24")]
		public void Initialize()
		{
			_runningState.AddBehavior(_behavior);
		}

		[Token(Token = "0x60010BB")]
		[Address(RVA = "0x3CB8084", Offset = "0x3CB8084", Length = "0x24")]
		public void Dispose()
		{
			_runningState.RemoveBehavior(_behavior);
		}

		[Token(Token = "0x60010BC")]
		[Address(RVA = "0x3CB80A8", Offset = "0x3CB80A8", Length = "0x8")]
		public TapHoldSpeedUpBridge()
		{
		}
	}
}
