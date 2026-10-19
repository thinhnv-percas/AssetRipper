using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States.Behaviors;

namespace _game.CoreGameKit.BaseLayer.Controller.Runtime.States
{
	[Serializable]
	[Token(Token = "0x20006D5")]
	public class BaseLayerWaitState : BaseLayerState
	{
		[Token(Token = "0x6001CE4")]
		[Address(RVA = "0x3D72670", Offset = "0x3D72670", Length = "0x8C")]
		public BaseLayerWaitState()
		{
			List<IStateBehavior> stateBehaviors = new List<IStateBehavior>();
			m_stateBehaviors = stateBehaviors;
		}
	}
}
