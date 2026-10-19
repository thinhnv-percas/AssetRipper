using System;
using Cpp2ILInjected;
using _game.CoreGameKit.Ui.UiControllers;

namespace _game.CoreGameKit.BaseLayer.Controller.Runtime.States.Behaviors
{
	[Serializable]
	[Token(Token = "0x20006D8")]
	public class HideTopBarUiBehavior : HideUiBehavior<BaseLayerTopBarUiController>
	{
		[Token(Token = "0x6001CEC")]
		[Address(RVA = "0x3D728CC", Offset = "0x3D728CC", Length = "0x58")]
		public HideTopBarUiBehavior()
		{
		}
	}
}
