using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;

namespace _game.CoreGameKit.BaseLayer.UI
{
	[Token(Token = "0x2000645")]
	public class InvokeLevelLeaveEventComponent : MonoBehaviour, IServiceButtonListener
	{
		[Inject(false)]
		[Token(Token = "0x400158F")]
		[FieldOffset(Offset = "0x20")]
		private EventBus _eventBus;

		[Token(Token = "0x6001AB4")]
		[Address(RVA = "0x3D56020", Offset = "0x3D56020", Length = "0x58")]
		public void ServiceCalled()
		{
			_eventBus.InvokeEvent(default(UventLevelLeave));
		}

		[Token(Token = "0x6001AB5")]
		[Address(RVA = "0x3D56078", Offset = "0x3D56078", Length = "0x8")]
		public InvokeLevelLeaveEventComponent()
		{
		}
	}
}
