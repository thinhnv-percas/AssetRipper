using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;

namespace _game.CoreGameKit.BaseLayer.UI
{
	[Token(Token = "0x2000642")]
	public class InvokeKeepPlayingClickedEventComponent : MonoBehaviour, IServiceButtonListener
	{
		[Inject(false)]
		[Token(Token = "0x400158A")]
		[FieldOffset(Offset = "0x20")]
		private EventBus _eventBus;

		[Token(Token = "0x6001AAE")]
		[Address(RVA = "0x3D55EE0", Offset = "0x3D55EE0", Length = "0x58")]
		public void ServiceCalled()
		{
			_eventBus.InvokeEvent(default(UventKeepPlayingClicked));
		}

		[Token(Token = "0x6001AAF")]
		[Address(RVA = "0x3D55F38", Offset = "0x3D55F38", Length = "0x8")]
		public InvokeKeepPlayingClickedEventComponent()
		{
		}
	}
}
