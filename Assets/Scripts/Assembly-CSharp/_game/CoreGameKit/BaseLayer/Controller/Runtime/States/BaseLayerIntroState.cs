using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States.Behaviors;
using _game.CoreGameKit.Ui.UiControllers;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.BaseLayer.Controller.Runtime.States
{
	[Serializable]
	[Token(Token = "0x20006C6")]
	public class BaseLayerIntroState : BaseLayerState
	{
		[Inject(false)]
		[Token(Token = "0x40016E7")]
		[FieldOffset(Offset = "0x18")]
		private UiManager _uiManager;

		[Token(Token = "0x6001CC3")]
		[Address(RVA = "0x3D71758", Offset = "0x3D71758", Length = "0x5C")]
		public override void OnStateEnter()
		{
			BaseLayerTopBarUiController baseLayerTopBarUiController = _uiManager.Show<BaseLayerTopBarUiController>();
			base.OnStateEnter();
		}

		[Token(Token = "0x6001CC4")]
		[Address(RVA = "0x3D718D0", Offset = "0x3D718D0", Length = "0x8C")]
		public BaseLayerIntroState()
		{
			List<IStateBehavior> stateBehaviors = new List<IStateBehavior>();
			m_stateBehaviors = stateBehaviors;
		}
	}
}
