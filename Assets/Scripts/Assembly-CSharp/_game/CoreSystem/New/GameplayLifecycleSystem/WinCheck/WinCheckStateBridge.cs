using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.WinCheck
{
	[Token(Token = "0x20003EC")]
	public class WinCheckStateBridge : IDisposable
	{
		[Inject(false)]
		[Token(Token = "0x4000C76")]
		[FieldOffset(Offset = "0x10")]
		private BaseLayerRunningState _runningState;

		[Inject(false)]
		[Token(Token = "0x4000C77")]
		[FieldOffset(Offset = "0x18")]
		private WinCheckBehavior _winCheck;

		[Inject(false)]
		[Token(Token = "0x6001084")]
		[Address(RVA = "0x3CB4AE0", Offset = "0x3CB4AE0", Length = "0x24")]
		public void Initialize()
		{
			_runningState.AddBehavior(_winCheck);
		}

		[Token(Token = "0x6001085")]
		[Address(RVA = "0x3CB4B04", Offset = "0x3CB4B04", Length = "0x24")]
		public void Dispose()
		{
			_runningState.RemoveBehavior(_winCheck);
		}

		[Token(Token = "0x6001086")]
		[Address(RVA = "0x3CB4B28", Offset = "0x3CB4B28", Length = "0x8")]
		public WinCheckStateBridge()
		{
		}
	}
}
