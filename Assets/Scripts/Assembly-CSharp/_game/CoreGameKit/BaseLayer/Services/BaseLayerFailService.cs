using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;
using _game.CoreGameKit.BaseLayer.Services.Interface;
using _game.CoreGameKit.BaseLayer.States;

namespace _game.CoreGameKit.BaseLayer.Services
{
	[Token(Token = "0x2000653")]
	public class BaseLayerFailService : IBaseLayerFailService
	{
		[Token(Token = "0x40015B7")]
		[FieldOffset(Offset = "0x10")]
		private BaseLayerStateMachine _stateMachine;

		[Token(Token = "0x40015B8")]
		[FieldOffset(Offset = "0x18")]
		private EventBus _eventBus;

		[Token(Token = "0x40015B9")]
		[FieldOffset(Offset = "0x20")]
		private BaseLayerFailState _failState;

		[Inject(false)]
		[Token(Token = "0x6001AD5")]
		[Address(RVA = "0x3D5733C", Offset = "0x3D5733C", Length = "0x50")]
		public void Construct(BaseLayerStateMachine stateMachine, EventBus eventBus, BaseLayerFailState failState)
		{
			_stateMachine = stateMachine;
			_eventBus = eventBus;
			_failState = failState;
		}

		[Token(Token = "0x6001AD6")]
		[Address(RVA = "0x3D5738C", Offset = "0x3D5738C", Length = "0x6C")]
		public void Fail()
		{
			_stateMachine.SetState(_failState);
			_eventBus.InvokeEvent(default(UventLevelFailed));
		}

		[Token(Token = "0x6001AD7")]
		[Address(RVA = "0x3D573F8", Offset = "0x3D573F8", Length = "0x8")]
		public BaseLayerFailService()
		{
		}
	}
}
