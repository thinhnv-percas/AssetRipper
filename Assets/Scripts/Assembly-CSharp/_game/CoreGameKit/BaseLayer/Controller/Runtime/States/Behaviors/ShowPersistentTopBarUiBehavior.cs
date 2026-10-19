using System;
using Cpp2ILInjected;
using _game.CoreGameKit.Ui.UiControllers;

namespace _game.CoreGameKit.BaseLayer.Controller.Runtime.States.Behaviors
{
	[Serializable]
	[Token(Token = "0x20006DF")]
	public class ShowPersistentTopBarUiBehavior : ShowPersistentUiBehavior<BaseLayerTopBarUiController>
	{
		[Token(Token = "0x6001D03")]
		[Address(RVA = "0x3D73124", Offset = "0x3D73124", Length = "0x58")]
		public ShowPersistentTopBarUiBehavior()
		{
		}
	}
}
