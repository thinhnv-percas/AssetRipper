using Cpp2ILInjected;
using Reflex.Attributes;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States.Behaviors;

namespace _game.CoreGameKit.BaseLayer.States.Behaviors
{
	[Token(Token = "0x200064E")]
	public class BaseLayerInstantStartBehavior : IStateBehavior
	{
		[Token(Token = "0x40015A0")]
		[FieldOffset(Offset = "0x10")]
		private BaseLayerStateMachine _stateMachine;

		[Token(Token = "0x40015A1")]
		[FieldOffset(Offset = "0x18")]
		private BaseLayerState _runningState;

		[Inject(false)]
		[Token(Token = "0x6001AC7")]
		[Address(RVA = "0x3D567A0", Offset = "0x3D567A0", Length = "0x34")]
		public void Initialize(BaseLayerStateMachine stateMachine, BaseLayerRunningState runningState)
		{
			_stateMachine = stateMachine;
			_runningState = runningState;
		}

		[Token(Token = "0x6001AC8")]
		[Address(RVA = "0x3D567D4", Offset = "0x3D567D4", Length = "0x24")]
		public void OnStateEnter()
		{
			_stateMachine.SetState(_runningState);
		}

		[Token(Token = "0x6001AC9")]
		[Address(RVA = "0x3D567F8", Offset = "0x3D567F8", Length = "0x8")]
		public BaseLayerInstantStartBehavior()
		{
		}
	}
}
