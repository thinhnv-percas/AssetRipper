using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.ContainerSystem.Runtime;
using Unco.StateSystem.Runtime;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States.Behaviors;

namespace _game.CoreGameKit.BaseLayer.Controller.Runtime.States
{
	[Serializable]
	[Token(Token = "0x20006C9")]
	public abstract class BaseLayerState : State, IDisposable
	{
		[SerializeReference]
		[Token(Token = "0x40016EA")]
		[FieldOffset(Offset = "0x10")]
		internal List<IStateBehavior> m_stateBehaviors;

		[Token(Token = "0x6001CC8")]
		[Address(RVA = "0x3D71B84", Offset = "0x3D71B84", Length = "0x130")]
		public void SetBehaviors(IStateBehavior[] behaviors)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerState::SetBehaviors");
		}

		[Token(Token = "0x6001CC9")]
		[Address(RVA = "0x3D71CB4", Offset = "0x3D71CB4", Length = "0x154")]
		public void AddBehavior(IStateBehavior behavior)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerState::AddBehavior");
		}

		[Token(Token = "0x6001CCA")]
		[Address(RVA = "0x3D71E08", Offset = "0x3D71E08", Length = "0xFC")]
		public void RemoveBehavior(IStateBehavior behavior)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerState::RemoveBehavior");
		}

		[Inject(false)]
		[Token(Token = "0x6001CCB")]
		[Address(RVA = "0x3D71F04", Offset = "0x3D71F04", Length = "0x4")]
		public void Initialize(Instancer instancer)
		{
			InjectBehaviors(instancer);
		}

		[Token(Token = "0x6001CCC")]
		[Address(RVA = "0x3D71FFC", Offset = "0x3D71FFC", Length = "0x4")]
		public void Dispose()
		{
			Dispose();
		}

		[Token(Token = "0x6001CCD")]
		[Address(RVA = "0x3D71F08", Offset = "0x3D71F08", Length = "0xF4")]
		private void InjectBehaviors(Instancer instancer)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerState::InjectBehaviors");
		}

		[Token(Token = "0x6001CCE")]
		[Address(RVA = "0x3D72000", Offset = "0x3D72000", Length = "0x118")]
		private void DisposeBehaviors()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerState::DisposeBehaviors");
		}

		[Token(Token = "0x6001CCF")]
		[Address(RVA = "0x3D717B4", Offset = "0x3D717B4", Length = "0x11C")]
		public override void OnStateEnter()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerState::OnStateEnter");
		}

		[Token(Token = "0x6001CD0")]
		[Address(RVA = "0x3D72118", Offset = "0x3D72118", Length = "0x120")]
		public override void OnStateUpdate()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerState::OnStateUpdate");
		}

		[Token(Token = "0x6001CD1")]
		[Address(RVA = "0x3D72238", Offset = "0x3D72238", Length = "0x120")]
		public override void OnStateExit()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerState::OnStateExit");
		}

		[Token(Token = "0x6001CD2")]
		[Address(RVA = "0x472E8A8", Offset = "0x472E8A8", Length = "0x1A4")]
		public unsafe TStateBehaviour TryFindBehavior<TStateBehaviour>() where TStateBehaviour : IStateBehavior
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerState::TryFindBehavior");
			return default;
		}

		[Token(Token = "0x6001CD3")]
		[Address(RVA = "0x3D7195C", Offset = "0x3D7195C", Length = "0x8C")]
		protected internal BaseLayerState()
		{
			List<IStateBehavior> stateBehaviors = new List<IStateBehavior>();
			m_stateBehaviors = stateBehaviors;
		}
	}
}
