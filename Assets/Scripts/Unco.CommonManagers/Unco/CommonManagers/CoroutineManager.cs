using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.CommonManagers
{
	[Token(Token = "0x2000004")]
	public class CoroutineManager : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x2000005")]
		private sealed class _003CEndOfFrameInvoke_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000007")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4000008")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000009")]
			[FieldOffset(Offset = "0x20")]
			public int frameCount;

			[Token(Token = "0x400000A")]
			[FieldOffset(Offset = "0x28")]
			public Action action;

			[Token(Token = "0x400000B")]
			[FieldOffset(Offset = "0x30")]
			private int _003Ci_003E5__2;

			[Token(Token = "0x17000001")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000010")]
				[Address(RVA = "0x81A8248", Offset = "0x81A8248", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000002")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000012")]
				[Address(RVA = "0x81A8290", Offset = "0x81A8290", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600000D")]
			[Address(RVA = "0x81A802C", Offset = "0x81A802C", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CEndOfFrameInvoke_003Ed__8(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x600000E")]
			[Address(RVA = "0x81A8164", Offset = "0x81A8164", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x600000F")]
			[Address(RVA = "0x81A8168", Offset = "0x81A8168", Length = "0xE0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv48 = this.<>1__state == 0;\n\tv49 = ~v48;\n\tif (v49) goto L_0062;\n\tthis.<>1__state = -1;\n\tthis.<i>5__2 = 0;\n\tv76 = this.<>1__state >= this.frameCount;\n\tif (v76) goto L_0055;\nL_0032:\n\tv130 = new UnityEngine.WaitForEndOfFrame();\n\tUnityEngine.WaitForEndOfFrame::.ctor(v130);\n\tthis.<>2__current = v130;\n\tthis.<>1__state = 1;\n\treturn 1;\nL_0044:\n\tthis.<>1__state = -1;\n\tv52 = this.<i>5__2 + 1;\n\tthis.<i>5__2 = v52;\n\tv64 = v52 < this.frameCount;\n\tif (v64) goto L_0032;\nL_0055:\n\t;\n\tv105 = this.action == 0;\n\tif (v105) goto L_0062;\n\tSystem.Action::Invoke(this.action);\nL_0017:\n\tv43 = this.<>1__state == 1;\n\tif (v43) goto L_0044;\nL_0062:\n\treturn 0;\n")]
			private bool MoveNext()
			{
				if (_003C_003E1__state != 1)
				{
					if (_003C_003E1__state != 0)
					{
						goto IL_0120;
					}
					_003C_003E1__state = -1;
					_003Ci_003E5__2 = 0;
					if (_003C_003E1__state < frameCount)
					{
						goto IL_0068;
					}
				}
				else
				{
					_003C_003E1__state = -1;
					if (++_003Ci_003E5__2 < frameCount)
					{
						goto IL_0068;
					}
				}
				if (action != null)
				{
					action();
				}
				goto IL_0120;
				IL_0068:
				WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
				_003C_003E2__current = waitForEndOfFrame;
				_003C_003E1__state = 1;
				return true;
				IL_0120:
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000011")]
			[Address(RVA = "0x81A8250", Offset = "0x81A8250", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000006")]
		private sealed class _003CRepeatableAction_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400000C")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x400000D")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x400000E")]
			[FieldOffset(Offset = "0x20")]
			public Action repeatableAction;

			[Token(Token = "0x400000F")]
			[FieldOffset(Offset = "0x28")]
			public float timer;

			[Token(Token = "0x17000003")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000016")]
				[Address(RVA = "0x81A834C", Offset = "0x81A834C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000004")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000018")]
				[Address(RVA = "0x81A8394", Offset = "0x81A8394", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000013")]
			[Address(RVA = "0x81A7F54", Offset = "0x81A7F54", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CRepeatableAction_003Ed__6(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000014")]
			[Address(RVA = "0x81A8298", Offset = "0x81A8298", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000015")]
			[Address(RVA = "0x81A829C", Offset = "0x81A829C", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = this.<>1__state == 1;\n\tif (v21) goto L_003B;\n\tv26 = this.<>1__state == 0;\n\tv27 = ~v26;\n\tif (v27) goto L_0053;\n\tthis.<>1__state = -1;\n\tv80 = this.timer;\n\tv34 = this.timer < 0;\n\tv35 = this.timer == 0;\n\tv38 = this.timer == this.timer;\n\tv39 = ~v38;\n\tv40 = v34 == v39;\n\tv41 = ~v40;\n\tv42 = v41 | v35;\n\tif (v42) goto L_0053;\nL_0024:\n\t;\n\tv89 = this.repeatableAction == 0;\n\tif (v89) goto L_002C;\n\tSystem.Action::Invoke(this.repeatableAction);\nL_003B:\n\tthis.<>1__state = -1;\n\tv31 = UnityEngine.Time::get_deltaTime();\n\tv80 = this.timer - v31;\n\tthis.timer = v80;\n\tv49 = this.timer > v31;\n\tif (v49) goto L_0024;\nL_0053:\n\treturn 0;\nL_002C:\n\tthis.<>2__current = 0;\n\tthis.<>1__state = 1;\n\treturn 1;\n")]
			private bool MoveNext()
			{
				if (_003C_003E1__state != 1)
				{
					if (_003C_003E1__state == 0)
					{
						_003C_003E1__state = -1;
						float num = timer;
						bool flag = timer < 0f;
						bool flag2 = timer == 0f;
						bool flag3 = timer == timer;
						bool flag4 = !flag3;
						bool flag5 = flag == flag4;
						bool flag6 = !flag5;
						if (!(flag6 || flag2))
						{
							goto IL_00d7;
						}
					}
				}
				else
				{
					_003C_003E1__state = -1;
					float deltaTime = Time.deltaTime;
					float num = timer - deltaTime;
					timer = num;
					if (timer > deltaTime)
					{
						goto IL_00d7;
					}
				}
				return false;
				IL_00d7:
				if (repeatableAction != null)
				{
					repeatableAction();
				}
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000017")]
			[Address(RVA = "0x81A8354", Offset = "0x81A8354", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000007")]
		private sealed class _003CWaitForFrame_003Ed__3 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000010")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4000011")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000012")]
			[FieldOffset(Offset = "0x20")]
			public CoroutineManager _003C_003E4__this;

			[Token(Token = "0x4000013")]
			[FieldOffset(Offset = "0x28")]
			public int frame;

			[Token(Token = "0x4000014")]
			[FieldOffset(Offset = "0x30")]
			public Action action;

			[Token(Token = "0x17000005")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600001C")]
				[Address(RVA = "0x81A8444", Offset = "0x81A8444", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000006")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600001E")]
				[Address(RVA = "0x81A848C", Offset = "0x81A848C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000019")]
			[Address(RVA = "0x81A7E04", Offset = "0x81A7E04", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CWaitForFrame_003Ed__3(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x600001A")]
			[Address(RVA = "0x81A839C", Offset = "0x81A839C", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x600001B")]
			[Address(RVA = "0x81A83A0", Offset = "0x81A83A0", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.<>4__this;\n\tv17 = this.<>1__state == 1;\n\tif (v17) goto L_0035;\n\tv22 = this.<>1__state == 0;\n\tv23 = ~v22;\n\tif (v23) goto L_0053;\n\tthis.<>1__state = -1;\n\tv52 = this.frame <= 0;\n\tif (v52) goto L_0046;\nL_0028:\n\tv148 = this + 0x18;\n\tthis.<>2__current = v12._waitForEndOfFrame;\n\t*([v148 @ X0_v6-8]) = 1;\n\treturn 1;\nL_0035:\n\tthis.<>1__state = -1;\n\tv26 = this.frame - 1;\n\tthis.frame = v26;\n\tv38 = v26 > 0;\n\tif (v38) goto L_0028;\nL_0046:\n\t;\n\tv65 = this.action == 0;\n\tif (v65) goto L_0053;\n\tSystem.Action::Invoke(this.action);\nL_0053:\n\treturn 0;\n")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("CoroutineManager._003CWaitForFrame_003Ed__3::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600001D")]
			[Address(RVA = "0x81A844C", Offset = "0x81A844C", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000008")]
		private sealed class _003CWaitForSeconds_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000015")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4000016")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000017")]
			[FieldOffset(Offset = "0x20")]
			public float delay;

			[Token(Token = "0x4000018")]
			[FieldOffset(Offset = "0x28")]
			public Action action;

			[Token(Token = "0x17000007")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000022")]
				[Address(RVA = "0x81A8564", Offset = "0x81A8564", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000008")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000024")]
				[Address(RVA = "0x81A85AC", Offset = "0x81A85AC", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600001F")]
			[Address(RVA = "0x81A7F80", Offset = "0x81A7F80", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CWaitForSeconds_003Ed__7(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000020")]
			[Address(RVA = "0x81A8494", Offset = "0x81A8494", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000021")]
			[Address(RVA = "0x81A8498", Offset = "0x81A8498", Length = "0xCC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv57 = this.<>1__state != 1;\n\tif (v57) goto L_0044;\n\tthis.<>1__state = -1;\n\tv66 = this.action == 0;\n\tif (v66) goto L_0044;\n\tSystem.Action::Invoke(this.action);\n\tgoto L_0044;\nL_002F:\n\tthis.<>1__state = -1;\n\tv63 = new UnityEngine.WaitForSeconds();\n\tUnityEngine.WaitForSeconds::.ctor(v63, this.delay);\n\tthis.<>2__current = v63;\n\tthis.<>1__state = 1;\nL_0017:\n\tv47 = this.<>1__state == 0;\n\tif (v47) goto L_002F;\nL_0044:\n\tv106 = this.<>1__state == 0;\n\treturn v106;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				if (_003C_003E1__state != 0)
				{
					if (_003C_003E1__state == 1)
					{
						_003C_003E1__state = -1;
						if (action != null)
						{
							action();
						}
					}
				}
				else
				{
					_003C_003E1__state = -1;
					WaitForSeconds waitForSeconds = new WaitForSeconds(delay);
					_003C_003E2__current = waitForSeconds;
					_003C_003E1__state = 1;
				}
				return _003C_003E1__state == 0;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000023")]
			[Address(RVA = "0x81A856C", Offset = "0x81A856C", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x20")]
		private readonly WaitForEndOfFrame _waitForEndOfFrame;

		[Token(Token = "0x6000003")]
		[Address(RVA = "0x81A7BA8", Offset = "0x81A7BA8", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv51.delay = delay;\n\tv69 = UnityEngine.MonoBehaviour::StartCoroutine(this, v51);\n\treturn;\nL_001B:\n\tv51 = new Unco.CommonManagers.CoroutineManager+<WaitForSeconds>d__7();\n\tSystem.Object::.ctor(v51);\n\tv51.<>1__state = 0;\n\tv51.action = action;\n")]
		public void CreateCoroutine(Action action, float delay)
		{
			_003CWaitForSeconds_003Ed__7 _003CWaitForSeconds_003Ed__8 = (_003CWaitForSeconds_003Ed__7)FormatterServices.GetUninitializedObject(typeof(_003CWaitForSeconds_003Ed__7));
			_003CWaitForSeconds_003Ed__8._003C_003E1__state = 0;
			_003CWaitForSeconds_003Ed__8.action = action;
			_003CWaitForSeconds_003Ed__8.delay = delay;
			Coroutine coroutine = StartCoroutine(_003CWaitForSeconds_003Ed__8);
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x81A7CC4", Offset = "0x81A7CC4", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv51.action = action;\n\tv51.frame = frame;\n\tv73 = UnityEngine.MonoBehaviour::StartCoroutine(this, v51);\n\treturn;\nL_001B:\n\tv51 = new Unco.CommonManagers.CoroutineManager+<WaitForFrame>d__3();\n\tSystem.Object::.ctor(v51);\n\tv51.<>1__state = 0;\n\tv51.<>4__this = this;\n")]
		public void CreateCoroutine(Action action, int frame)
		{
			_003CWaitForFrame_003Ed__3 _003CWaitForFrame_003Ed__4 = (_003CWaitForFrame_003Ed__3)FormatterServices.GetUninitializedObject(typeof(_003CWaitForFrame_003Ed__3));
			_003CWaitForFrame_003Ed__4._003C_003E1__state = 0;
			_003CWaitForFrame_003Ed__4._003C_003E4__this = this;
			_003CWaitForFrame_003Ed__4.action = action;
			_003CWaitForFrame_003Ed__4.frame = frame;
			Coroutine coroutine = StartCoroutine(_003CWaitForFrame_003Ed__4);
		}

		[IteratorStateMachine(typeof(_003CWaitForFrame_003Ed__3))]
		[Token(Token = "0x6000005")]
		[Address(RVA = "0x81A7D68", Offset = "0x81A7D68", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv51.action = action;\n\tv51.frame = frame;\n\treturn v51;\nL_001B:\n\tv51 = new Unco.CommonManagers.CoroutineManager+<WaitForFrame>d__3();\n\tSystem.Object::.ctor(v51);\n\tv51.<>1__state = 0;\n\tv51.<>4__this = this;\n")]
		private IEnumerator WaitForFrame(Action action, int frame)
		{
			_003CWaitForFrame_003Ed__3 _003CWaitForFrame_003Ed__4 = (_003CWaitForFrame_003Ed__3)FormatterServices.GetUninitializedObject(typeof(_003CWaitForFrame_003Ed__3));
			_003CWaitForFrame_003Ed__4._003C_003E1__state = 0;
			_003CWaitForFrame_003Ed__4._003C_003E4__this = this;
			_003CWaitForFrame_003Ed__4.action = action;
			_003CWaitForFrame_003Ed__4.frame = frame;
			return _003CWaitForFrame_003Ed__4;
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0x81A7E30", Offset = "0x81A7E30", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.MonoBehaviour::StartCoroutine(this, enumerator);\n\treturn returnVal1;\n")]
		public Coroutine CreateCoroutine(IEnumerator enumerator)
		{
			return StartCoroutine(enumerator);
		}

		[Token(Token = "0x6000007")]
		[Address(RVA = "0x81A7E38", Offset = "0x81A7E38", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv51.timer = timer;\n\treturnVal1 = UnityEngine.MonoBehaviour::StartCoroutine(this, v51);\n\treturn returnVal1;\nL_001B:\n\tv51 = new Unco.CommonManagers.CoroutineManager+<RepeatableAction>d__6();\n\tSystem.Object::.ctor(v51);\n\tv51.<>1__state = 0;\n\tv51.repeatableAction = repeatableAction;\n")]
		public Coroutine RepeatCoroutine(Action repeatableAction, float timer)
		{
			_003CRepeatableAction_003Ed__6 _003CRepeatableAction_003Ed__7 = (_003CRepeatableAction_003Ed__6)FormatterServices.GetUninitializedObject(typeof(_003CRepeatableAction_003Ed__6));
			_003CRepeatableAction_003Ed__7._003C_003E1__state = 0;
			_003CRepeatableAction_003Ed__7.repeatableAction = repeatableAction;
			_003CRepeatableAction_003Ed__7.timer = timer;
			return StartCoroutine(_003CRepeatableAction_003Ed__7);
		}

		[IteratorStateMachine(typeof(_003CRepeatableAction_003Ed__6))]
		[Token(Token = "0x6000008")]
		[Address(RVA = "0x81A7ECC", Offset = "0x81A7ECC", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv50.timer = timer;\n\treturn v50;\nL_001A:\n\tv50 = new Unco.CommonManagers.CoroutineManager+<RepeatableAction>d__6();\n\tSystem.Object::.ctor(v50);\n\tv50.<>1__state = 0;\n\tv50.repeatableAction = repeatableAction;\n")]
		private IEnumerator RepeatableAction(Action repeatableAction, float timer)
		{
			_003CRepeatableAction_003Ed__6 _003CRepeatableAction_003Ed__7 = (_003CRepeatableAction_003Ed__6)FormatterServices.GetUninitializedObject(typeof(_003CRepeatableAction_003Ed__6));
			_003CRepeatableAction_003Ed__7._003C_003E1__state = 0;
			_003CRepeatableAction_003Ed__7.repeatableAction = repeatableAction;
			_003CRepeatableAction_003Ed__7.timer = timer;
			return _003CRepeatableAction_003Ed__7;
		}

		[IteratorStateMachine(typeof(_003CWaitForSeconds_003Ed__7))]
		[Token(Token = "0x6000009")]
		[Address(RVA = "0x81A7C3C", Offset = "0x81A7C3C", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv50.delay = delay;\n\treturn v50;\nL_001A:\n\tv50 = new Unco.CommonManagers.CoroutineManager+<WaitForSeconds>d__7();\n\tSystem.Object::.ctor(v50);\n\tv50.<>1__state = 0;\n\tv50.action = action;\n")]
		private IEnumerator WaitForSeconds(Action action, float delay)
		{
			_003CWaitForSeconds_003Ed__7 _003CWaitForSeconds_003Ed__8 = (_003CWaitForSeconds_003Ed__7)FormatterServices.GetUninitializedObject(typeof(_003CWaitForSeconds_003Ed__7));
			_003CWaitForSeconds_003Ed__8._003C_003E1__state = 0;
			_003CWaitForSeconds_003Ed__8.action = action;
			_003CWaitForSeconds_003Ed__8.delay = delay;
			return _003CWaitForSeconds_003Ed__8;
		}

		[IteratorStateMachine(typeof(_003CEndOfFrameInvoke_003Ed__8))]
		[Token(Token = "0x600000A")]
		[Address(RVA = "0x81A7FAC", Offset = "0x81A7FAC", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv46.frameCount = frameCount;\n\treturn v46;\nL_0018:\n\tv46 = new Unco.CommonManagers.CoroutineManager+<EndOfFrameInvoke>d__8();\n\tSystem.Object::.ctor(v46);\n\tv46.<>1__state = 0;\n\tv46.action = action;\n")]
		private IEnumerator EndOfFrameInvoke(Action action, int frameCount)
		{
			_003CEndOfFrameInvoke_003Ed__8 _003CEndOfFrameInvoke_003Ed__9 = (_003CEndOfFrameInvoke_003Ed__8)FormatterServices.GetUninitializedObject(typeof(_003CEndOfFrameInvoke_003Ed__8));
			_003CEndOfFrameInvoke_003Ed__9._003C_003E1__state = 0;
			_003CEndOfFrameInvoke_003Ed__9.action = action;
			_003CEndOfFrameInvoke_003Ed__9.frameCount = frameCount;
			return _003CEndOfFrameInvoke_003Ed__9;
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x81A8058", Offset = "0x81A8058", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv51.frameCount = frameCount;\n\tv69 = UnityEngine.MonoBehaviour::StartCoroutine(this, v51);\n\treturn;\nL_001B:\n\tv51 = new Unco.CommonManagers.CoroutineManager+<EndOfFrameInvoke>d__8();\n\tSystem.Object::.ctor(v51);\n\tv51.<>1__state = 0;\n\tv51.action = action;\n")]
		public void InvokeEndOfFrame(Action action, int frameCount = 1)
		{
			_003CEndOfFrameInvoke_003Ed__8 _003CEndOfFrameInvoke_003Ed__9 = (_003CEndOfFrameInvoke_003Ed__8)FormatterServices.GetUninitializedObject(typeof(_003CEndOfFrameInvoke_003Ed__8));
			_003CEndOfFrameInvoke_003Ed__9._003C_003E1__state = 0;
			_003CEndOfFrameInvoke_003Ed__9.action = action;
			_003CEndOfFrameInvoke_003Ed__9.frameCount = frameCount;
			Coroutine coroutine = StartCoroutine(_003CEndOfFrameInvoke_003Ed__9);
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x81A80EC", Offset = "0x81A80EC", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\nL_0017:\n\tv45 = new UnityEngine.WaitForEndOfFrame();\n\tUnityEngine.WaitForEndOfFrame::.ctor(v45);\n\tthis._waitForEndOfFrame = v45;\n")]
		public CoroutineManager()
		{
			WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
			_waitForEndOfFrame = waitForEndOfFrame;
		}
	}
}
