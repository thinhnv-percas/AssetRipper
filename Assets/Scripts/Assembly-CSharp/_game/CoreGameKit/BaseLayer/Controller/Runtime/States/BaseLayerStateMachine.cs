using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using Unco.StateSystem.Runtime;
using _game.CoreGameKit.BaseLayer.Installers.Unco.ContainerSystem.Runtime;

namespace _game.CoreGameKit.BaseLayer.Controller.Runtime.States
{
	[Token(Token = "0x20006CA")]
	public class BaseLayerStateMachine : IStateMachine, IRequireUpdateCall, IDisposable
	{
		[CompilerGenerated]
		[Token(Token = "0x40016EB")]
		[FieldOffset(Offset = "0x10")]
		private Action<State, State> _003COnStateChanged_003Ek__BackingField;

		[Inject(false)]
		[Token(Token = "0x40016ED")]
		[FieldOffset(Offset = "0x20")]
		private EventBus _eventBus;

		[Token(Token = "0x170002DC")]
		[field: Token(Token = "0x40016EC")]
		[field: FieldOffset(Offset = "0x18")]
		public State CurrentState
		{
			[Token(Token = "0x6001CD6")]
			[Address(RVA = "0x3D724C0", Offset = "0x3D724C0", Length = "0x8")]
			get;
			[Token(Token = "0x6001CD7")]
			[Address(RVA = "0x3D724C8", Offset = "0x3D724C8", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x14000022")]
		public event Action<State, State> OnStateChanged
		{
			[CompilerGenerated]
			[Token(Token = "0x6001CD4")]
			[Address(RVA = "0x3D72358", Offset = "0x3D72358", Length = "0xB4")]
			add
			{
				global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerStateMachine::add_OnStateChanged");
			}
			[CompilerGenerated]
			[Token(Token = "0x6001CD5")]
			[Address(RVA = "0x3D7240C", Offset = "0x3D7240C", Length = "0xB4")]
			remove
			{
				global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerStateMachine::remove_OnStateChanged");
			}
		}

		[Token(Token = "0x6001CD8")]
		[Address(RVA = "0x3D724D0", Offset = "0x3D724D0", Length = "0x100")]
		public void SetState(State state)
		{
			if (CurrentState != null)
			{
				CurrentState.OnStateExit();
			}
			CurrentState = state;
			CurrentState.OnStateEnter();
			Type type = state.GetType();
			UventChapterStateChanged args = default(UventChapterStateChanged);
			_eventBus.InvokeEvent(args);
			if (_003COnStateChanged_003Ek__BackingField != null)
			{
				_003COnStateChanged_003Ek__BackingField(CurrentState, CurrentState);
			}
		}

		[Token(Token = "0x6001CD9")]
		[Address(RVA = "0x3D725D0", Offset = "0x3D725D0", Length = "0x18")]
		public void Update()
		{
			if (CurrentState != null)
			{
				State state = default(State);
				state.OnStateUpdate();
			}
		}

		[Token(Token = "0x6001CDA")]
		[Address(RVA = "0x3D725E8", Offset = "0x3D725E8", Length = "0x18")]
		public void FixedUpdate()
		{
			if (CurrentState != null)
			{
				State state = default(State);
				state.OnStateFixedUpdate();
			}
		}

		[Token(Token = "0x6001CDB")]
		[Address(RVA = "0x3D72600", Offset = "0x3D72600", Length = "0x18")]
		public void LateUpdate()
		{
			if (CurrentState != null)
			{
				State state = default(State);
				state.OnStateLateUpdate();
			}
		}

		[Token(Token = "0x6001CDC")]
		[Address(RVA = "0x3D72618", Offset = "0x3D72618", Length = "0x18")]
		public void Dispose()
		{
			if (CurrentState != null)
			{
				State state = default(State);
				state.OnStateExit();
			}
		}

		[Token(Token = "0x6001CDD")]
		[Address(RVA = "0x3D72630", Offset = "0x3D72630", Length = "0x8")]
		public BaseLayerStateMachine()
		{
		}
	}
}
