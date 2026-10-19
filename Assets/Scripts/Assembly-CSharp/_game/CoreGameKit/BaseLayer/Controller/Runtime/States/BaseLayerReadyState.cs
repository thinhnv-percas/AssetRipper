using System.Collections.Generic;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States.Behaviors;
using _game.CoreGameKit.Ui.UiControllers;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.BaseLayer.Controller.Runtime.States
{
	[Token(Token = "0x20006C7")]
	public class BaseLayerReadyState : BaseLayerState
	{
		[Inject(false)]
		[Token(Token = "0x40016E8")]
		[FieldOffset(Offset = "0x18")]
		private UiManager _uiManager;

		[Inject(false)]
		[Token(Token = "0x40016E9")]
		[FieldOffset(Offset = "0x20")]
		private EventBus _eventBus;

		[Token(Token = "0x6001CC5")]
		[Address(RVA = "0x3D719E8", Offset = "0x3D719E8", Length = "0x84")]
		public override void OnStateEnter()
		{
			_eventBus.InvokeEvent(default(UventLevelStarted));
			CounterUiController counterUiController = _uiManager.Show<CounterUiController>();
			base.OnStateEnter();
		}

		[Token(Token = "0x6001CC6")]
		[Address(RVA = "0x3D71A6C", Offset = "0x3D71A6C", Length = "0x8C")]
		public BaseLayerReadyState()
		{
			List<IStateBehavior> stateBehaviors = new List<IStateBehavior>();
			m_stateBehaviors = stateBehaviors;
		}
	}
}
