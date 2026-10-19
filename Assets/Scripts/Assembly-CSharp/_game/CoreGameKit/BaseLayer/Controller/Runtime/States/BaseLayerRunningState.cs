using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States.Behaviors;

namespace _game.CoreGameKit.BaseLayer.Controller.Runtime.States
{
	[Serializable]
	[Token(Token = "0x20006C8")]
	public class BaseLayerRunningState : BaseLayerState
	{
		[Token(Token = "0x6001CC7")]
		[Address(RVA = "0x3D71AF8", Offset = "0x3D71AF8", Length = "0x8C")]
		public BaseLayerRunningState()
		{
			List<IStateBehavior> stateBehaviors = new List<IStateBehavior>();
			m_stateBehaviors = stateBehaviors;
		}
	}
}
