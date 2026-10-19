using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.FailCheck
{
	[Token(Token = "0x200041E")]
	public class FailCheckStateBridge : IDisposable
	{
		[Inject(false)]
		[Token(Token = "0x4000CF9")]
		[FieldOffset(Offset = "0x10")]
		private BaseLayerRunningState _runningState;

		[Inject(false)]
		[Token(Token = "0x4000CFA")]
		[FieldOffset(Offset = "0x18")]
		private FailCheckBehavior _failCheck;

		[Inject(false)]
		[Token(Token = "0x600113B")]
		[Address(RVA = "0x3CBE914", Offset = "0x3CBE914", Length = "0x24")]
		public void Initialize()
		{
			_runningState.AddBehavior(_failCheck);
		}

		[Token(Token = "0x600113C")]
		[Address(RVA = "0x3CBE938", Offset = "0x3CBE938", Length = "0x24")]
		public void Dispose()
		{
			_runningState.RemoveBehavior(_failCheck);
		}

		[Token(Token = "0x600113D")]
		[Address(RVA = "0x3CBDD5C", Offset = "0x3CBDD5C", Length = "0x8")]
		public FailCheckStateBridge()
		{
		}
	}
}
