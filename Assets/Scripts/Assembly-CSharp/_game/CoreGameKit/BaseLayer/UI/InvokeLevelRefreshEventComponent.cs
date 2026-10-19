using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;

namespace _game.CoreGameKit.BaseLayer.UI
{
	[Token(Token = "0x2000646")]
	public class InvokeLevelRefreshEventComponent : MonoBehaviour, IServiceButtonListener
	{
		[Inject(false)]
		[Token(Token = "0x4001590")]
		[FieldOffset(Offset = "0x20")]
		private EventBus _eventBus;

		[Token(Token = "0x6001AB6")]
		[Address(RVA = "0x3D56080", Offset = "0x3D56080", Length = "0x58")]
		public void ServiceCalled()
		{
			_eventBus.InvokeEvent(default(UventLevelRefreshed));
		}

		[Token(Token = "0x6001AB7")]
		[Address(RVA = "0x3D560D8", Offset = "0x3D560D8", Length = "0x8")]
		public InvokeLevelRefreshEventComponent()
		{
		}
	}
}
