using System;
using System.Runtime.CompilerServices;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.StateSystem.Runtime
{
	[Token(Token = "0x2000005")]
	public class MonoStateMachine : MonoBehaviour, IStateMachine
	{
		[CompilerGenerated]
		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x28")]
		private Action<State, State> _003COnStateChanged_003Ek__BackingField;

		[Token(Token = "0x17000002")]
		[field: Token(Token = "0x4000006")]
		[field: FieldOffset(Offset = "0x20")]
		public State CurrentState
		{
			[Token(Token = "0x600000A")]
			[Address(RVA = "0x81DD6B0", Offset = "0x81DD6B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.CurrentState;\n")]
			get;
			[Token(Token = "0x600000B")]
			[Address(RVA = "0x81DD6B8", Offset = "0x81DD6B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.CurrentState = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x14000002")]
		public event Action<State, State> OnStateChanged
		{
			[CompilerGenerated]
			[Token(Token = "0x600000C")]
			[Address(RVA = "0x81DD6C0", Offset = "0x81DD6C0", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Combine(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`2<Unco.StateSystem.Runtime.State, Unco.StateSystem.Runtime.State>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.OnStateChanged;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.OnStateChanged (System.Action`2<Unco.StateSystem.Runtime.State, Unco.StateSystem.Runtime.State>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
			add
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MonoStateMachine::add_OnStateChanged");
			}
			[CompilerGenerated]
			[Token(Token = "0x600000D")]
			[Address(RVA = "0x81DD774", Offset = "0x81DD774", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Remove(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`2<Unco.StateSystem.Runtime.State, Unco.StateSystem.Runtime.State>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.OnStateChanged;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.OnStateChanged (System.Action`2<Unco.StateSystem.Runtime.State, Unco.StateSystem.Runtime.State>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
			remove
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MonoStateMachine::remove_OnStateChanged");
			}
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x81DD828", Offset = "0x81DD828", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.CurrentState == 0;\n\tif (v2) goto L_0007;\n\tv0 = Unco.StateSystem.Runtime.State::OnStateUpdate(v0);\n\treturn;\nL_0007:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Update()
		{
			if (CurrentState != null)
			{
				State state = default(State);
				state.OnStateUpdate();
			}
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x81DD840", Offset = "0x81DD840", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.CurrentState == 0;\n\tif (v2) goto L_0007;\n\tv0 = Unco.StateSystem.Runtime.State::OnStateFixedUpdate(v0);\n\treturn;\nL_0007:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void FixedUpdate()
		{
			if (CurrentState != null)
			{
				State state = default(State);
				state.OnStateFixedUpdate();
			}
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x81DD858", Offset = "0x81DD858", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.CurrentState == 0;\n\tif (v2) goto L_0007;\n\tv0 = Unco.StateSystem.Runtime.State::OnStateLateUpdate(v0);\n\treturn;\nL_0007:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LateUpdate()
		{
			if (CurrentState != null)
			{
				State state = default(State);
				state.OnStateLateUpdate();
			}
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0x81DD870", Offset = "0x81DD870", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = this.CurrentState == 0;\n\tif (v21) goto L_0014;\n\tv26 = Unco.StateSystem.Runtime.State::OnStateExit(this.CurrentState);\n\tv55 = Unco.StateSystem.Runtime.State::OnStateEnter(this.CurrentState);\n\tv57 = this.OnStateChanged == 0;\n\tif (v57) goto L_0036;\n\tSystem.Action`2<Unco.StateSystem.Runtime.State, Unco.StateSystem.Runtime.State>::Invoke(this.OnStateChanged, this.CurrentState, state);\n\treturn;\nL_0036:\n\treturn;\nL_0014:\n\tthis.CurrentState = state;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetState(State state)
		{
			if (CurrentState != null)
			{
				CurrentState.OnStateExit();
			}
			CurrentState = state;
			CurrentState.OnStateEnter();
			if (_003COnStateChanged_003Ek__BackingField != null)
			{
				_003COnStateChanged_003Ek__BackingField(CurrentState, state);
			}
		}

		[Token(Token = "0x6000012")]
		[Address(RVA = "0x81DD908", Offset = "0x81DD908", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public MonoStateMachine()
		{
		}
	}
}
