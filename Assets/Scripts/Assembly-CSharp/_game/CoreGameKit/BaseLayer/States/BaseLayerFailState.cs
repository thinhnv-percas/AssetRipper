using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.BaseLayer.States
{
	[Serializable]
	[Token(Token = "0x200064C")]
	public class BaseLayerFailState : BaseLayerState
	{
		[Inject(false)]
		[Token(Token = "0x400159D")]
		[FieldOffset(Offset = "0x18")]
		private UiManager _uiManager;

		[Token(Token = "0x6001AC3")]
		[Address(RVA = "0x3D5669C", Offset = "0x3D5669C", Length = "0x8")]
		public override void OnStateEnter()
		{
			base.OnStateEnter();
		}

		[Token(Token = "0x6001AC4")]
		[Address(RVA = "0x3D566A4", Offset = "0x3D566A4", Length = "0x8")]
		public BaseLayerFailState()
		{
		}
	}
}
