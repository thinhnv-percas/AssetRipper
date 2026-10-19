using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;

namespace _game.CoreGameKit.BaseLayer.UI
{
	[Token(Token = "0x2000643")]
	public class InvokeKeepPlayingGiveUpEventComponent : MonoBehaviour, IServiceButtonListener
	{
		[Inject(false)]
		[Token(Token = "0x400158B")]
		[FieldOffset(Offset = "0x20")]
		private EventBus _eventBus;

		[Token(Token = "0x6001AB0")]
		[Address(RVA = "0x3D55F40", Offset = "0x3D55F40", Length = "0x58")]
		public void ServiceCalled()
		{
			_eventBus.InvokeEvent(default(UventKeepPlayingGiveUp));
		}

		[Token(Token = "0x6001AB1")]
		[Address(RVA = "0x3D55F98", Offset = "0x3D55F98", Length = "0x8")]
		public InvokeKeepPlayingGiveUpEventComponent()
		{
		}
	}
}
