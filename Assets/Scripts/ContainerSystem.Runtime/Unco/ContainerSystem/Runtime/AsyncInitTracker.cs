using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.ContainerSystem.Runtime
{
	[Token(Token = "0x200003F")]
	public class AsyncInitTracker
	{
		[CompilerGenerated]
		[Token(Token = "0x2000040")]
		private sealed class _003CRunAndComplete_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000066")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4000067")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000068")]
			[FieldOffset(Offset = "0x20")]
			public IEnumerator routine;

			[Token(Token = "0x4000069")]
			[FieldOffset(Offset = "0x28")]
			public AsyncInitHandle handle;

			[Token(Token = "0x17000026")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000E6")]
				[Address(RVA = "0x3F39344", Offset = "0x3F39344", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000027")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000E8")]
				[Address(RVA = "0x3F3938C", Offset = "0x3F3938C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60000E3")]
			[Address(RVA = "0x3F3920C", Offset = "0x3F3920C", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CRunAndComplete_003Ed__10(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x60000E4")]
			[Address(RVA = "0x3F39274", Offset = "0x3F39274", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60000E5")]
			[Address(RVA = "0x3F39278", Offset = "0x3F39278", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.<>1__state == 0;\n\tif (v12) goto L_0038;\n\tv22 = this.<>1__state != 1;\n\tif (v22) goto L_002B;\n\tthis.<>1__state = -1;\n\tv43 = this.handle;\n\tv91 = v43._completed == 0;\n\tv60 = ~v91;\n\tif (v60) goto L_002B;\n\tv43._completed = 1;\n\tv59 = v43._onComplete == 0;\n\tif (v59) goto L_002B;\n\tSystem.Action::Invoke(v43._onComplete);\nL_0038:\n\tv24 = this + 0x18;\n\tthis.<>2__current = this.routine;\n\tthis.<>1__state = -1;\n\t*([v24 @ X0_v1-8]) = 1;\n\tv80 = this.<>1__state == 0;\n\treturn v80;\nL_002B:\n\tv65 = this.<>1__state == 0;\n\treturn v65;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("AsyncInitTracker._003CRunAndComplete_003Ed__10::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60000E7")]
			[Address(RVA = "0x3F3934C", Offset = "0x3F3934C", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000041")]
		private sealed class _003CWaitUntilReady_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400006A")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x400006B")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x400006C")]
			[FieldOffset(Offset = "0x20")]
			public AsyncInitTracker _003C_003E4__this;

			[Token(Token = "0x17000028")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000EC")]
				[Address(RVA = "0x3F39420", Offset = "0x3F39420", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000029")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000EE")]
				[Address(RVA = "0x3F39468", Offset = "0x3F39468", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60000E9")]
			[Address(RVA = "0x3F391AC", Offset = "0x3F391AC", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CWaitUntilReady_003Ed__8(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x60000EA")]
			[Address(RVA = "0x3F39394", Offset = "0x3F39394", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60000EB")]
			[Address(RVA = "0x3F39398", Offset = "0x3F39398", Length = "0x88")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.<>1__state - 1;\n\tv13 = v12 < 2;\n\tv14 = ~v13;\n\tif (v14) goto L_0026;\n\tv22 = this.<>4__this;\n\tthis.<>1__state = -1;\n\tv38 = v22._pendingCount < 1;\n\tif (v38) goto L_003F;\n\tv76 = 2;\n\tgoto L_002C;\nL_0026:\n\tv25 = this.<>1__state == 0;\n\tv26 = ~v25;\n\tif (v26) goto L_003F;\n\tthis.<>1__state = -1;\n\tv76 = 1;\nL_003F:\n\treturn 0;\nL_002C:\n\tv89 = this + 0x18;\n\tthis.<>2__current = 0;\n\t*([v89 @ X0_v1-8]) = v76;\n\treturn 1;\n")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("AsyncInitTracker._003CWaitUntilReady_003Ed__8::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60000ED")]
			[Address(RVA = "0x3F39428", Offset = "0x3F39428", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x4000064")]
		[FieldOffset(Offset = "0x10")]
		private int _pendingCount;

		[CompilerGenerated]
		[Token(Token = "0x4000065")]
		[FieldOffset(Offset = "0x18")]
		private Action OnReady;

		[Token(Token = "0x17000025")]
		public bool IsReady
		{
			[Token(Token = "0x60000D9")]
			[Address(RVA = "0x3F38DA4", Offset = "0x3F38DA4", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this._pendingCount - 1;\n\tv5 = v4 < 0;\n\tv7 = this._pendingCount ^ 1;\n\tv8 = this._pendingCount ^ v4;\n\tv9 = v7 & v8;\n\tv10 = v9 < 0;\n\tv11 = v5 == v10;\n\tv12 = ~v11;\n\treturn v12;\n")]
			get
			{
				int num = _pendingCount - 1;
				bool flag = num < 0;
				int num2 = _pendingCount ^ 1;
				int num3 = _pendingCount ^ num;
				int num4 = num2 & num3;
				bool flag2 = num4 < 0;
				bool flag3 = flag == flag2;
				return !flag3;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x60000DA")]
		[Address(RVA = "0x3F38DB4", Offset = "0x3F38DB4", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnReady (System.Action), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Combine(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.Action;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnReady;\n\tgoto L_002C;\n")]
		public void add_OnReady(Action value)
		{
			Action action = OnReady;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref OnReady, value2, action2);
			}
			while ((object)action != action2);
		}

		[CompilerGenerated]
		[Token(Token = "0x60000DB")]
		[Address(RVA = "0x3F38E58", Offset = "0x3F38E58", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnReady (System.Action), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Remove(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.Action;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnReady;\n\tgoto L_002C;\n")]
		public void remove_OnReady(Action value)
		{
			Action action = OnReady;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref OnReady, value2, action2);
			}
			while ((object)action != action2);
		}

		[Token(Token = "0x60000DC")]
		[Address(RVA = "0x3F38EFC", Offset = "0x3F38EFC", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tSystem.Object::.ctor(v67);\n\tv67._onComplete = v56;\n\treturn v67;\nL_0023:\n\tv54 = this._pendingCount + 1;\n\tthis._pendingCount = v54;\n\tv56 = new System.Action();\n\tSystem.Action::.ctor(v56, this, Il2CppMethodInfo);\n\tv67 = new Unco.ContainerSystem.Runtime.AsyncInitHandle();\n")]
		public AsyncInitHandle Track()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AsyncInitTracker::Track");
			return default;
		}

		[Token(Token = "0x60000DD")]
		[Address(RVA = "0x3F38FFC", Offset = "0x3F38FFC", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = Unco.ContainerSystem.Runtime.AsyncInitTracker::Track(this);\n\tgoto L_001C;\n\tv52.handle = v22;\n\treturnVal1 = UnityEngine.MonoBehaviour::StartCoroutine(runner, v52);\n\treturn returnVal1;\nL_001C:\n\tv52 = new Unco.ContainerSystem.Runtime.AsyncInitTracker+<RunAndComplete>d__10();\n\tSystem.Object::.ctor(v52);\n\tv52.<>1__state = 0;\n\tv52.routine = routine;\n")]
		public Coroutine TrackCoroutine(MonoBehaviour runner, IEnumerator routine)
		{
			AsyncInitHandle handle = Track();
			_003CRunAndComplete_003Ed__10 _003CRunAndComplete_003Ed__11 = (_003CRunAndComplete_003Ed__10)FormatterServices.GetUninitializedObject(typeof(_003CRunAndComplete_003Ed__10));
			_003CRunAndComplete_003Ed__11._003C_003E1__state = 0;
			_003CRunAndComplete_003Ed__11.routine = routine;
			_003CRunAndComplete_003Ed__11.handle = handle;
			return runner.StartCoroutine(_003CRunAndComplete_003Ed__11);
		}

		[IteratorStateMachine(typeof(_003CWaitUntilReady_003Ed__8))]
		[Token(Token = "0x60000DE")]
		[Address(RVA = "0x3F39134", Offset = "0x3F39134", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\treturn v45;\nL_0017:\n\tv45 = new Unco.ContainerSystem.Runtime.AsyncInitTracker+<WaitUntilReady>d__8();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n")]
		public IEnumerator WaitUntilReady()
		{
			_003CWaitUntilReady_003Ed__8 _003CWaitUntilReady_003Ed__9 = (_003CWaitUntilReady_003Ed__8)FormatterServices.GetUninitializedObject(typeof(_003CWaitUntilReady_003Ed__8));
			_003CWaitUntilReady_003Ed__9._003C_003E1__state = 0;
			_003CWaitUntilReady_003Ed__9._003C_003E4__this = this;
			return _003CWaitUntilReady_003Ed__9;
		}

		[Token(Token = "0x60000DF")]
		[Address(RVA = "0x3F391D8", Offset = "0x3F391D8", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this._pendingCount - 1;\n\tthis._pendingCount = v2;\n\tv14 = v2 <= 0;\n\tif (v14) goto L_0011;\nL_0010:\n\treturn;\nL_0011:\n\tthis._pendingCount = 0;\n\tv17 = this.OnReady == 0;\n\tif (v17) goto L_0010;\n\tSystem.Action::Invoke(this.OnReady);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void HandleCompleted()
		{
			if (--_pendingCount <= 0)
			{
				_pendingCount = 0;
				if (OnReady != null)
				{
					OnReady();
				}
			}
		}

		[IteratorStateMachine(typeof(_003CRunAndComplete_003Ed__10))]
		[Token(Token = "0x60000E0")]
		[Address(RVA = "0x3F390A8", Offset = "0x3F390A8", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv46.handle = handle;\n\treturn v46;\nL_0018:\n\tv46 = new Unco.ContainerSystem.Runtime.AsyncInitTracker+<RunAndComplete>d__10();\n\tSystem.Object::.ctor(v46);\n\tv46.<>1__state = 0;\n\tv46.routine = routine;\n")]
		private static IEnumerator RunAndComplete(IEnumerator routine, AsyncInitHandle handle)
		{
			_003CRunAndComplete_003Ed__10 _003CRunAndComplete_003Ed__11 = (_003CRunAndComplete_003Ed__10)FormatterServices.GetUninitializedObject(typeof(_003CRunAndComplete_003Ed__10));
			_003CRunAndComplete_003Ed__11._003C_003E1__state = 0;
			_003CRunAndComplete_003Ed__11.routine = routine;
			_003CRunAndComplete_003Ed__11.handle = handle;
			return _003CRunAndComplete_003Ed__11;
		}

		[Token(Token = "0x60000E1")]
		[Address(RVA = "0x3F39238", Offset = "0x3F39238", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public AsyncInitTracker()
		{
		}
	}
}
