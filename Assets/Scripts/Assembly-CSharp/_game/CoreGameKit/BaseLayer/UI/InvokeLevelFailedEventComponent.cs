using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;
using _game.CoreSystem.HealthSystem;

namespace _game.CoreGameKit.BaseLayer.UI
{
	[Token(Token = "0x2000644")]
	public class InvokeLevelFailedEventComponent : MonoBehaviour, IServiceButtonListener
	{
		[SerializeField]
		[Token(Token = "0x400158C")]
		[FieldOffset(Offset = "0x20")]
		private bool m_isButtonFail;

		[Inject(false)]
		[Token(Token = "0x400158D")]
		[FieldOffset(Offset = "0x28")]
		private BaseLayerSessionController _sessionController;

		[Inject(false)]
		[Token(Token = "0x400158E")]
		[FieldOffset(Offset = "0x30")]
		private EventBus _eventBus;

		[Token(Token = "0x6001AB2")]
		[Address(RVA = "0x3D55FA0", Offset = "0x3D55FA0", Length = "0x78")]
		public void ServiceCalled()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InvokeLevelFailedEventComponent::ServiceCalled");
		}

		[Token(Token = "0x6001AB3")]
		[Address(RVA = "0x3D56018", Offset = "0x3D56018", Length = "0x8")]
		public InvokeLevelFailedEventComponent()
		{
		}
	}
}
