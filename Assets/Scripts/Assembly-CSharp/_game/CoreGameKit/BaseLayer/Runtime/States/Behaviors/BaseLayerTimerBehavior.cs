using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.TimeTaskSystem.Runtime;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Controller;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States.Behaviors;

namespace _game.CoreGameKit.BaseLayer.Runtime.States.Behaviors
{
	[Serializable]
	[Token(Token = "0x20006EF")]
	public class BaseLayerTimerBehavior : IStateBehavior
	{
		[SerializeField]
		[Token(Token = "0x4001750")]
		[FieldOffset(Offset = "0x10")]
		private bool m_pausedInState;

		[Token(Token = "0x4001751")]
		[FieldOffset(Offset = "0x18")]
		private BaseLayerTimerController _timerController;

		[Inject(false)]
		[Token(Token = "0x6001D52")]
		[Address(RVA = "0x3D772F8", Offset = "0x3D772F8", Length = "0x8")]
		public void Initialize(BaseLayerTimerController timerController)
		{
			_timerController = timerController;
		}

		[Token(Token = "0x6001D53")]
		[Address(RVA = "0x3D77300", Offset = "0x3D77300", Length = "0xAC")]
		public void OnStateEnter()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerTimerBehavior::OnStateEnter");
		}

		[Token(Token = "0x6001D54")]
		[Address(RVA = "0x3D773AC", Offset = "0x3D773AC", Length = "0xC0")]
		public void OnStateExit()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerTimerBehavior::OnStateExit");
		}

		[Token(Token = "0x6001D55")]
		[Address(RVA = "0x3D7746C", Offset = "0x3D7746C", Length = "0x8")]
		public BaseLayerTimerBehavior()
		{
		}
	}
}
