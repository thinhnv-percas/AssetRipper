using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.BaseLayer.Controller.Runtime.States.Behaviors
{
	[Serializable]
	[Token(Token = "0x20006DE")]
	public class ShowPersistentUiBehavior<T> : IStateBehavior where T : UIController
	{
		[Token(Token = "0x4001709")]
		[FieldOffset(Offset = "0x0")]
		private UiManager _uiFactory;

		[Inject(false)]
		[Token(Token = "0x6001CFF")]
		[Address(RVA = "0x626B80C", Offset = "0x626B80C", Length = "0x8")]
		public void Initialize(UiManager uiFactory)
		{
			_uiFactory = uiFactory;
		}

		[Token(Token = "0x6001D00")]
		[Address(RVA = "0x626B814", Offset = "0x626B814", Length = "0x60")]
		public void OnStateEnter()
		{
			if (!_uiFactory.Exist<T>())
			{
				T val = _uiFactory.Show<T>();
			}
		}

		[Token(Token = "0x6001D01")]
		[Address(RVA = "0x626B874", Offset = "0x626B874", Length = "0x4")]
		public void OnStateExit()
		{
		}

		[Token(Token = "0x6001D02")]
		[Address(RVA = "0x626B878", Offset = "0x626B878", Length = "0x8")]
		public ShowPersistentUiBehavior()
		{
		}
	}
}
