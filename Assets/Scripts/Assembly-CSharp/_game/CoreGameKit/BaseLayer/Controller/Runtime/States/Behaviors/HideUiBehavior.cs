using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.BaseLayer.Controller.Runtime.States.Behaviors
{
	[Serializable]
	[Token(Token = "0x20006D7")]
	public class HideUiBehavior<T> : IStateBehavior where T : UIController
	{
		[Token(Token = "0x40016F7")]
		[FieldOffset(Offset = "0x0")]
		private UiManager _uiFactory;

		[Inject(false)]
		[Token(Token = "0x6001CE8")]
		[Address(RVA = "0x5407DF0", Offset = "0x5407DF0", Length = "0x8")]
		public void Initialize(UiManager uiFactory)
		{
			_uiFactory = uiFactory;
		}

		[Token(Token = "0x6001CE9")]
		[Address(RVA = "0x5407DF8", Offset = "0x5407DF8", Length = "0x24")]
		public void OnStateEnter()
		{
			_uiFactory.ForceHideIfExist<T>();
		}

		[Token(Token = "0x6001CEA")]
		[Address(RVA = "0x5407E1C", Offset = "0x5407E1C", Length = "0x4")]
		public void OnStateExit()
		{
		}

		[Token(Token = "0x6001CEB")]
		[Address(RVA = "0x5407E20", Offset = "0x5407E20", Length = "0x8")]
		public HideUiBehavior()
		{
		}
	}
}
