using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.CoreGameKit.BaseLayer.Services;

namespace _game.CoreGameKit.BaseLayer.Controller.Runtime.States.Behaviors
{
	[Serializable]
	[Token(Token = "0x20006DA")]
	public class InputBlockBehavior : IStateBehavior
	{
		[Token(Token = "0x40016F8")]
		[FieldOffset(Offset = "0x10")]
		private InputBlockService _inputBlockService;

		[Token(Token = "0x40016F9")]
		[FieldOffset(Offset = "0x18")]
		private IDisposable _blockHandle;

		[Inject(false)]
		[Token(Token = "0x6001CF0")]
		[Address(RVA = "0x3D72930", Offset = "0x3D72930", Length = "0x8")]
		public void Initialize(InputBlockService inputBlockService)
		{
			_inputBlockService = inputBlockService;
		}

		[Token(Token = "0x6001CF1")]
		[Address(RVA = "0x3D72938", Offset = "0x3D72938", Length = "0x6C")]
		public void OnStateEnter()
		{
			IDisposable blockHandle = _inputBlockService.RequestBlock("StateBehavior");
			_blockHandle = blockHandle;
		}

		[Token(Token = "0x6001CF2")]
		[Address(RVA = "0x3D729A4", Offset = "0x3D729A4", Length = "0xB0")]
		public void OnStateExit()
		{
			if (_blockHandle != null)
			{
				_blockHandle.Dispose();
			}
			_blockHandle = null;
		}

		[Token(Token = "0x6001CF3")]
		[Address(RVA = "0x3D72A54", Offset = "0x3D72A54", Length = "0x8")]
		public InputBlockBehavior()
		{
		}
	}
}
