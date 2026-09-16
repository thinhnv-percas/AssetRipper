using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Scripting;

namespace Firebase.Unity
{
	[Preserve]
	[Token(Token = "0x200000E")]
	internal class UnitySynchronizationContext : SynchronizationContext
	{
		[Token(Token = "0x200000F")]
		private class SynchronizationContextBehavoir : MonoBehaviour
		{
			[CompilerGenerated]
			[Token(Token = "0x2000010")]
			private sealed class _003CStart_003Ec__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
			{
				[Token(Token = "0x4000026")]
				[FieldOffset(Offset = "0x10")]
				internal Tuple<SendOrPostCallback, object> _003Centry_003E__0;

				[Token(Token = "0x4000027")]
				[FieldOffset(Offset = "0x18")]
				internal object _0024locvar0;

				[Token(Token = "0x4000028")]
				[FieldOffset(Offset = "0x20")]
				internal SynchronizationContextBehavoir _0024this;

				[Token(Token = "0x4000029")]
				[FieldOffset(Offset = "0x28")]
				internal object _0024current;

				[Token(Token = "0x400002A")]
				[FieldOffset(Offset = "0x30")]
				internal bool _0024disposing;

				[Token(Token = "0x400002B")]
				[FieldOffset(Offset = "0x34")]
				internal int _0024PC;

				[Token(Token = "0x17000018")]
				object IEnumerator<object>.Current
				{
					[DebuggerHidden]
					[Token(Token = "0x6000060")]
					[Address(RVA = "0x15ECFA0", Offset = "0x15ECFA0", Length = "0x8")]
					[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.$current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
					get
					{
						return _0024current;
					}
				}

				[Token(Token = "0x17000019")]
				object IEnumerator.Current
				{
					[DebuggerHidden]
					[Token(Token = "0x6000061")]
					[Address(RVA = "0x15ECFA8", Offset = "0x15ECFA8", Length = "0x8")]
					[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.$current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
					get
					{
						return _0024current;
					}
				}

				[DebuggerHidden]
				[Token(Token = "0x600005E")]
				[Address(RVA = "0x15ECD7C", Offset = "0x15ECD7C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				public _003CStart_003Ec__Iterator0()
				{
				}

				[Token(Token = "0x600005F")]
				[Address(RVA = "0x15ECD84", Offset = "0x15ECD84", Length = "0x21C")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EEE1E8]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2029FBD]) = v40;\nL_0016:\n\tthis.$PC = 0xFFFFFFFF;\n\tv43 = this.$PC < 1;\n\tv44 = ~v43;\n\tv45 = this.$PC - 1;\n\tv47 = v45 == 0;\n\tv52 = ~v47;\n\tv53 = v44 & v52;\n\tif (v53) goto L_FFFFFFFF;\n\tthis.<entry>__0 = 0;\n\tv57 = Firebase.Unity.UnitySynchronizationContext+SynchronizationContextBehavoir::get_CallbackQueue(this.$this);\n\tthis.$locvar0 = v57;\n\tSystem.Threading.Monitor::Enter(v57);\n\tv137 = Firebase.Unity.UnitySynchronizationContext+SynchronizationContextBehavoir::get_CallbackQueue(this.$this);\n\tv142 = v137._size < 1;\n\tif (v142) goto L_004B;\n\tv178 = Firebase.Unity.UnitySynchronizationContext+SynchronizationContextBehavoir::get_CallbackQueue(this.$this);\n\tv180 = v178 == 0;\n\tif (v180) goto L_0069;\n\tv187 = System.Collections.Generic.Queue`1<System.Tuple`2<System.Threading.SendOrPostCallback, System.Object>>::Dequeue(v178);\n\tthis.<entry>__0 = v187;\nL_004B:\n\tSystem.Threading.Monitor::Exit(this.$locvar0);\nL_004C:\n\tv203 = this.<entry>__0;\n\tv204 = this.<entry>__0 == 0;\n\tif (v204) goto L_0057;\n\tv213 = v203.m_Item1 == 0;\n\tif (v213) goto L_0057;\n\tSystem.Threading.SendOrPostCallback::Invoke(v203.m_Item1, v203.m_Item2);\nL_0057:\n\tthis.$current = 0;\n\tv218 = ~this.$disposing;\n\tv84 = ~v218;\n\tif (v84) goto L_0064;\n\tthis.$PC = 1;\n\tgoto L_0064;\nL_0064:\n\treturn returnVal1;\n\tv58 = new System.NullReferenceException();\n\tv100 = new System.NullReferenceException();\n\tv140 = new System.NullReferenceException();\n\tv166 = new System.NullReferenceException();\nL_0069:\n\tv181 = new System.NullReferenceException();\n\tgoto L_00B7;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX20 = X0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00C7;\n\tX0 = X20;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\n\tX20 = *([X21]);\n\tX8 = *([1EDD7C0]);\n\tX1 = *([X20]);\n\tX0 = *([X8]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_009D;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00A5;\n\tX8 = *([X20]);\n\tX0 = X20;\n\tX9 = *([X8+160]);\n\tX1 = *([X8+168]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EBC820]);\n\tX20 = X0;\n\tX8 = *([X8]);\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_0099;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0099;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0099:\n\tX0 = X20;\n\tX1 = 0;\n\tUnityEngine.Debug::Log(X0, X1);\n\tgoto L_0057;\nL_009D:\n\tX0 = 0 | 8;\n\tX0 = 0x6D1E60(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X21]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0x870;\n\tX2 = 0;\n\tX0 = 0x6D2A00(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00A5:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_00C7;\n\tX0 = 0x846AA4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_00B7;\n\tgoto L_00B7;\nL_00B7:\n\tv106 = v124 != 1;\n\tif (v106) goto L_00C7;\n\tv206 = 0x6D2BC0(v181, v124, v104, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv219 = 0x6D2490(v206, v124, v104, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tSystem.Threading.Monitor::Exit(this.$locvar0);\n\tv200 = *([v206 @ X0_v11]) == 0;\n\tif (v200) goto L_004C;\n\tthrow System.TypeLoadException;\nL_00C7:\n\treturnVal2 = 0x6D2380(v181, v124, v104, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturn returnVal2;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				public bool MoveNext()
				{
					_0024PC = -1;
					bool flag = _0024PC < 1;
					bool flag2 = !flag;
					int num = _0024PC - 1;
					bool flag3 = num == 0;
					bool flag4 = !flag3;
					if (!(flag2 && flag4))
					{
						_003Centry_003E__0 = null;
						Monitor.Enter(_0024locvar0 = _0024this.CallbackQueue);
						Queue<Tuple<SendOrPostCallback, object>> callbackQueue = _0024this.CallbackQueue;
						if (callbackQueue.Count >= 1)
						{
							Queue<Tuple<SendOrPostCallback, object>> callbackQueue2 = _0024this.CallbackQueue;
							if (callbackQueue2 == null)
							{
								NullReferenceException ex = new NullReferenceException();
								int num2 = default(int);
								if (num2 == 1)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
									Monitor.Exit(_0024locvar0);
									object obj = default(object);
									if (obj != null)
									{
										int num3 = 0;
										num2 = 0;
										throw new TypeLoadException();
									}
									goto IL_00b6;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
								bool result = default(bool);
								return result;
							}
							Tuple<SendOrPostCallback, object> tuple = callbackQueue2.Dequeue();
							_003Centry_003E__0 = tuple;
						}
						Monitor.Exit(_0024locvar0);
						goto IL_00b6;
					}
					bool result2 = false;
					goto IL_028c;
					IL_028c:
					return result2;
					IL_00b6:
					Tuple<SendOrPostCallback, object> tuple2 = _003Centry_003E__0;
					if (_003Centry_003E__0 != null && tuple2.m_Item1 != null)
					{
						tuple2.m_Item1(tuple2.m_Item2);
					}
					_0024current = null;
					bool flag5 = !_0024disposing;
					bool flag6 = !flag5;
					result2 = true;
					if (!flag6)
					{
						_0024PC = 1;
						result2 = true;
					}
					goto IL_028c;
				}

				[DebuggerHidden]
				[Token(Token = "0x6000062")]
				[Address(RVA = "0x15ECFB0", Offset = "0x15ECFB0", Length = "0x14")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.$disposing = 1;\n\tthis.$PC = 0xFFFFFFFF;\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				public void Dispose()
				{
					_0024disposing = true;
					_0024PC = -1;
				}

				[DebuggerHidden]
				[Token(Token = "0x6000063")]
				[Address(RVA = "0x15ECFC4", Offset = "0x15ECFC4", Length = "0x64")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1ED2288]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([2029FBE]) = v34;\nL_0014:\n\tv38 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				public void Reset()
				{
					NotSupportedException ex = new NotSupportedException();
					throw new TypeLoadException();
				}
			}

			[Token(Token = "0x4000025")]
			[FieldOffset(Offset = "0x18")]
			private Queue<Tuple<SendOrPostCallback, object>> callbackQueue;

			[Token(Token = "0x17000017")]
			public Queue<Tuple<SendOrPostCallback, object>> CallbackQueue
			{
				[Token(Token = "0x600005C")]
				[Address(RVA = "0x15EC50C", Offset = "0x15EC50C", Length = "0x74")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1ECA7D8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029FBB]) = v38;\nL_0013:\n\tv51 = this.callbackQueue;\n\tv40 = this.callbackQueue == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_0027;\n\tv45 = new System.Collections.Generic.Queue`1<System.Tuple`2<System.Threading.SendOrPostCallback, System.Object>>();\n\tSystem.Collections.Generic.Queue`1<System.Tuple`2<System.Threading.SendOrPostCallback, System.Object>>::.ctor(v45);\n\tthis.callbackQueue = v45;\nL_0027:\n\treturn v51;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					Queue<Tuple<SendOrPostCallback, object>> result = callbackQueue;
					if (callbackQueue == null)
					{
						result = (callbackQueue = new Queue<Tuple<SendOrPostCallback, object>>());
					}
					return result;
				}
			}

			[Token(Token = "0x600005B")]
			[Address(RVA = "0x15ECD04", Offset = "0x15ECD04", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public SynchronizationContextBehavoir()
			{
			}

			[Preserve]
			[DebuggerHidden]
			[Token(Token = "0x600005D")]
			[Address(RVA = "0x15ECD0C", Offset = "0x15ECD0C", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1ED6728]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029FBC]) = v38;\nL_0016:\n\tv42 = new Firebase.Unity.UnitySynchronizationContext+SynchronizationContextBehavoir+<Start>c__Iterator0();\n\tSystem.Object::.ctor(v42);\n\tv42.$this = this;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private IEnumerator Start()
			{
				//yield-return decompiler failed: Could not find state field.
				_003CStart_003Ec__Iterator0 _003CStart_003Ec__Iterator1 = new _003CStart_003Ec__Iterator0();
				_003CStart_003Ec__Iterator1._0024this = this;
				return _003CStart_003Ec__Iterator1;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000014")]
		private sealed class _003CSend_003Ec__AnonStorey3
		{
			[Token(Token = "0x4000031")]
			[FieldOffset(Offset = "0x10")]
			internal SendOrPostCallback d;

			[Token(Token = "0x600006C")]
			[Address(RVA = "0x15EC9C4", Offset = "0x15EC9C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CSend_003Ec__AnonStorey3()
			{
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000015")]
		private sealed class _003CSend_003Ec__AnonStorey4
		{
			[Token(Token = "0x4000032")]
			[FieldOffset(Offset = "0x10")]
			internal ManualResetEvent newSignal;

			[Token(Token = "0x4000033")]
			[FieldOffset(Offset = "0x18")]
			internal _003CSend_003Ec__AnonStorey3 _003C_003Ef__ref_00243;

			[Token(Token = "0x600006D")]
			[Address(RVA = "0x15EC9CC", Offset = "0x15EC9CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CSend_003Ec__AnonStorey4()
			{
			}

			[Token(Token = "0x600006E")]
			[Address(RVA = "0x15ECA54", Offset = "0x15ECA54", Length = "0x144")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EA5BE0]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, x, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029FB8]) = v41;\nL_0015:\n\tv42 = this.<>f__ref$3;\n\tv45 = v42.d == 0;\n\tif (v45) goto L_002C;\n\tSystem.Threading.SendOrPostCallback::Invoke(v42.d, v146);\nL_001F:\n\tv97 = this.newSignal == 0;\n\tif (v97) goto L_0069;\n\tv104 = System.Threading.EventWaitHandle::Set(this.newSignal);\n\treturn;\n\tv47 = new System.NullReferenceException();\nL_002C:\n\tv52 = new System.NullReferenceException();\n\tgoto L_0038;\nL_0038:\n\tv58 = v146 != 1;\n\tif (v58) goto L_006D;\n\tv134 = 0x6D2BC0(v52, v146, v116, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv124 = *([v134 @ X0_v12]);\n\tv146 = *([v124 @ X20_v6]);\n\tv179 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v124 @ X20_v6]), v116, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv180 = v179 & 1;\n\tv181 = v180 == 0;\n\tif (v181) goto L_0061;\n\tv182 = 0x6D2490(v179, v146, v116, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv185 = v124 == 0;\n\tif (v185) goto L_0069;\n\tv191 = *([v124 @ X20_v6]);\n\t*([v191 @ X8_v10+160])(v195, v124, *([v191 @ X8_v10+168]), v116, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_005E;\n\tv202 = *([v93 @ X8_v13+E0]);\n\tv203 = v202 == 0;\n\tv204 = ~v203;\n\tif (v204) goto L_005E;\n\tv207 = v93;\n\tv206 = \"il2cpp_codegen_runtime_class_init\"(v207, v194, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_005E:\n\tUnityEngine.Debug::Log(v195);\n\tgoto L_001F;\nL_0061:\n\tv184 = 0x6D1E60(8, *([v124 @ X20_v6]), v116, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\t*([v184 @ X0_v18]) = *([v134 @ X0_v12]);\n\tv146 = 0x1E8A000 + 0x870;\n\tv190 = 0x6D2A00(v184, v146, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0069:\n\tv128 = new System.NullReferenceException();\n\tv132 = 0x6D2490(v128, v146, v116, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_006D:\n\tv153 = 0x6D2380(v149, v146, v116, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv168 = 0x846AA4(v153, v146, v116, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal void _003C_003Em__0(object x)
			{
				//IL_003e: Expected I, but got O
				//IL_016f: Expected O, but got I4
				//IL_017e: Expected I, but got O
				_003CSend_003Ec__AnonStorey3 _003CSend_003Ec__AnonStorey5 = _003C_003Ef__ref_00243;
				object obj = default(object);
				if (_003CSend_003Ec__AnonStorey5.d != null)
				{
					_003CSend_003Ec__AnonStorey5.d(obj);
					IntPtr intPtr = (IntPtr)null;
					goto IL_0043;
				}
				NullReferenceException ex = new NullReferenceException();
				bool flag = (IntPtr)obj != (IntPtr)1;
				NullReferenceException ex2 = ex;
				if (flag)
				{
					goto IL_0183;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj3 = default(object);
				object obj2 = obj3;
				obj = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				object obj4 = default(object);
				if ((uint)((ulong)(long)(IntPtr)obj4 & 1uL) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
					if (obj2 != null)
					{
						object obj5 = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v191 @ X8_v10+160] (should have been resolved before IL gen)");
						object message = default(object);
						Debug.Log(message);
						obj = null;
						goto IL_0043;
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
					object obj6 = obj3;
					obj = 32022528 + 2160;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2A00 (native __cxa_throw)");
					IntPtr intPtr = (IntPtr)null;
				}
				goto IL_01ac;
				IL_0183:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
				return;
				IL_0043:
				if (newSignal != null)
				{
					bool flag2 = newSignal.Set();
					return;
				}
				goto IL_01ac;
				IL_01ac:
				NullReferenceException ex3 = new NullReferenceException();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				ex2 = ex3;
				goto IL_0183;
			}
		}

		[Token(Token = "0x4000020")]
		private static UnitySynchronizationContext _instance = null;

		[Token(Token = "0x4000021")]
		[FieldOffset(Offset = "0x10")]
		private Queue<Tuple<SendOrPostCallback, object>> queue;

		[Token(Token = "0x4000022")]
		[FieldOffset(Offset = "0x18")]
		private SynchronizationContextBehavoir behavior;

		[Token(Token = "0x4000023")]
		[FieldOffset(Offset = "0x20")]
		private int mainThreadId;

		[Token(Token = "0x4000024")]
		private static Dictionary<int, ManualResetEvent> signalDictionary;

		[Token(Token = "0x6000054")]
		[Address(RVA = "0x15EC468", Offset = "0x15EC468", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EFDD58]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, gameObject, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029FB1]) = v41;\nL_0017:\n\tSystem.Threading.SynchronizationContext::.ctor(this);\n\tv45 = System.Threading.Thread::get_CurrentThread();\n\tv48 = System.Threading.Thread::get_ManagedThreadId(v45);\n\tthis.mainThreadId = v48;\n\tv52 = UnityEngine.GameObject::AddComponent(gameObject);\n\tthis.behavior = v52;\n\tv71 = Firebase.Unity.UnitySynchronizationContext+SynchronizationContextBehavoir::get_CallbackQueue(v52);\n\tthis.queue = v71;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private UnitySynchronizationContext(GameObject gameObject)
		{
			Thread currentThread = Thread.CurrentThread;
			mainThreadId = currentThread.ManagedThreadId;
			queue = (behavior = gameObject.AddComponent<SynchronizationContextBehavoir>()).CallbackQueue;
		}

		[Token(Token = "0x6000055")]
		[Address(RVA = "0x15E737C", Offset = "0x15E737C", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EFEA40]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2029FB2]) = v40;\nL_001A:\n\tgoto L_0023;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<Firebase.Unity.UnitySynchronizationContext>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0023;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = Firebase.Unity.UnitySynchronizationContext;\nL_0023:\n\tv56 = v54._instance == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_003D;\n\tv59 = new Firebase.Unity.UnitySynchronizationContext();\n\tFirebase.Unity.UnitySynchronizationContext::.ctor(v59, gameObject);\n\tgoto L_0036;\n\tv79 = *([v75 @ X0_v6 (Il2CppClass<Firebase.Unity.UnitySynchronizationContext>)+E0]);\n\tv80 = v79 == 0;\n\tv81 = ~v80;\n\tif (v81) goto L_0036;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v75, v61, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv82 = Firebase.Unity.UnitySynchronizationContext;\nL_0036:\n\tv67._instance = v59;\nL_003D:\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Create(GameObject gameObject)
		{
			if (_instance == null)
			{
				UnitySynchronizationContext instance = new UnitySynchronizationContext(gameObject);
				_instance = instance;
			}
		}

		[Token(Token = "0x6000056")]
		[Address(RVA = "0x15E7C04", Offset = "0x15E7C04", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F0E260]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029FB3]) = v35;\nL_0017:\n\tgoto L_001F;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Firebase.Unity.UnitySynchronizationContext>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001F;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Firebase.Unity.UnitySynchronizationContext;\nL_001F:\n\tv49._instance = 0;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Destroy()
		{
			_instance = null;
		}

		[Token(Token = "0x6000057")]
		[Address(RVA = "0x15EC580", Offset = "0x15EC580", Length = "0x1EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EED1D8]);\n\tv19 = *([v18 @ X8_v28]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2029FB4]) = v39;\nL_001A:\n\tgoto L_0025;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<Firebase.Unity.UnitySynchronizationContext>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0025;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv51 = Firebase.Unity.UnitySynchronizationContext;\nL_0025:\n\tSystem.Threading.Monitor::Enter(v54.signalDictionary);\n\tgoto L_0034;\n\tv63 = *([v59 @ X0_v5 (Il2CppClass<Firebase.Unity.UnitySynchronizationContext>)+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tgoto L_0034;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v59, v55, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv67 = Firebase.Unity.UnitySynchronizationContext;\nL_0034:\n\tv73 = System.Threading.Thread::get_CurrentThread();\n\tv77 = System.Threading.Thread::get_ManagedThreadId(v73);\n\tv92 = System.Collections.Generic.Dictionary`2<System.Int32, System.Threading.ManualResetEvent>::TryGetValue(v70.signalDictionary, v77, &v90 @ stack_-28_v6 (System.Threading.ManualResetEvent));\n\tv138 = v92 == 0;\n\tv139 = ~v138;\n\tif (v139) goto L_006E;\n\tv168 = new System.Threading.ManualResetEvent();\n\tSystem.Threading.ManualResetEvent::.ctor(v168, 0);\n\tgoto L_005E;\n\tv229 = *([v222 @ X0_v39 (Il2CppClass<Firebase.Unity.UnitySynchronizationContext>)+E0]);\n\tv230 = v229 == 0;\n\tv231 = ~v230;\n\tif (v231) goto L_005E;\n\tv253 = \"il2cpp_codegen_runtime_class_init\"(v222, v157, v154, v88, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv233 = Firebase.Unity.UnitySynchronizationContext;\nL_005E:\n\tv159 = System.Threading.Thread::get_CurrentThread();\n\tv200 = System.Threading.Thread::get_ManagedThreadId(v159);\n\tv180 = v163.signalDictionary == 0;\n\tif (v180) goto L_0082;\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Threading.ManualResetEvent>::set_Item(v163.signalDictionary, v200, v168);\nL_006E:\n\tSystem.Threading.Monitor::Exit(v54.signalDictionary);\nL_0073:\n\tv227 = System.Threading.EventWaitHandle::Reset(v168);\n\treturn v168;\n\tthrow System.NullReferenceException;\n\tv85 = new System.NullReferenceException();\n\tv136 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_0082:\n\tv204 = new System.NullReferenceException();\n\tgoto L_0093;\n\tgoto L_0093;\n\tgoto L_0093;\n\tgoto L_0093;\n\tgoto L_0093;\n\tgoto L_0093;\n\tgoto L_0093;\nL_0093:\n\tv207 = v247 != 1;\n\tif (v207) goto L_00A1;\n\tv243 = System.Collections.Generic.Dictionary`2<System.Int32, System.Threading.ManualResetEvent>::TryGetValue(v204, v247, v245);\n\tv275 = System.Collections.Generic.Dictionary`2<System.Int32, System.Threading.ManualResetEvent>::TryGetValue(v243, v247, v245);\n\tSystem.Threading.Monitor::Exit(v54.signalDictionary);\n\tv221 = ~v243.m_value;\n\tif (v221) goto L_0073;\n\tv250 = new System.TypeLoadException();\nL_00A1:\n\treturnVal2 = System.Collections.Generic.Dictionary`2<System.Int32, System.Threading.ManualResetEvent>::TryGetValue(v249, 0, 0);\n\treturn returnVal2;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe ManualResetEvent GetThreadEvent()
		{
			//IL_0187: Expected O, but got I4
			//IL_012d: Expected O, but got I4
			Monitor.Enter(signalDictionary);
			Thread currentThread = Thread.CurrentThread;
			int managedThreadId = currentThread.ManagedThreadId;
			ManualResetEvent manualResetEvent = default(ManualResetEvent);
			if (!signalDictionary.TryGetValue(managedThreadId, out var _))
			{
				manualResetEvent = new ManualResetEvent(initialState: false);
				Thread currentThread2 = Thread.CurrentThread;
				int managedThreadId2 = currentThread2.ManagedThreadId;
				if (signalDictionary == null)
				{
					NullReferenceException ex = new NullReferenceException();
					int num = default(int);
					bool flag = num != 1;
					Dictionary<int, ManualResetEvent> dictionary = (Dictionary<int, ManualResetEvent>)(object)ex;
					if (!flag)
					{
						ref ManualResetEvent value2 = default(ref ManualResetEvent);
						bool flag2 = ((Dictionary<int, ManualResetEvent>)(object)ex).TryGetValue(num, out value2);
						bool flag3 = ((Dictionary<int, ManualResetEvent>)flag2).TryGetValue(num, out value2);
						Monitor.Exit(signalDictionary);
						if (!((bool*)(flag2 ? 1 : 0))->m_value)
						{
							goto IL_00bf;
						}
						TypeLoadException ex2 = new TypeLoadException();
						dictionary = (Dictionary<int, ManualResetEvent>)(object)ex2;
					}
					return (ManualResetEvent)dictionary.TryGetValue(0, out *(ManualResetEvent*)null);
				}
				signalDictionary.set_Item(managedThreadId2, manualResetEvent);
			}
			Monitor.Exit(signalDictionary);
			goto IL_00bf;
			IL_00bf:
			bool flag4 = manualResetEvent.Reset();
			return manualResetEvent;
		}

		[Token(Token = "0x6000058")]
		[Address(RVA = "0x15EC76C", Offset = "0x15EC76C", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1EC4390]);\n\tv29 = *([v28 @ X8_v11]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, d, state, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2029FB5]) = v46;\nL_001B:\n\tSystem.Threading.Monitor::Enter(this.queue);\n\tv54 = new System.Tuple`2<System.Threading.SendOrPostCallback, System.Object>();\n\tSystem.Tuple`2<System.Threading.SendOrPostCallback, System.Object>::.ctor(v54, d, state);\n\tv62 = this.queue == 0;\n\tif (v62) goto L_003E;\n\tSystem.Collections.Generic.Queue`1<System.Tuple`2<System.Threading.SendOrPostCallback, System.Object>>::Enqueue(this.queue, v54);\n\tSystem.Threading.Monitor::Exit(this.queue);\n\treturn;\nL_003E:\n\tv69 = new System.NullReferenceException();\n\tgoto L_0049;\nL_0049:\n\tv88 = d != 1;\n\tif (v88) goto L_005D;\n\tv134 = System.Tuple`2<System.Threading.SendOrPostCallback, System.Object>::.ctor(v69, d, state);\n\tv137 = System.Tuple`2<System.Threading.SendOrPostCallback, System.Object>::.ctor(v134, d, state);\n\tSystem.Threading.Monitor::Exit(this.queue);\n\tv141 = *([v134 @ X0_v12]) == 0;\n\tv120 = ~v141;\n\tif (v120) goto L_0061;\n\treturn;\nL_005D:\n\tv135 = System.Tuple`2<System.Threading.SendOrPostCallback, System.Object>::.ctor(v69, d, state);\nL_0061:\n\tthrow System.TypeLoadException;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Post(SendOrPostCallback d, object state)
		{
			Monitor.Enter(queue);
			Tuple<SendOrPostCallback, object> item = new Tuple<SendOrPostCallback, object>(d, state);
			if (queue != null)
			{
				queue.Enqueue(item);
				Monitor.Exit(queue);
				return;
			}
			NullReferenceException ex = (NullReferenceException)(object)new Tuple<SendOrPostCallback, object>(d, state);
			if ((IntPtr)d == (IntPtr)1)
			{
				Monitor.Exit(queue);
				object obj = default(object);
				if (obj == null)
				{
					return;
				}
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x6000059")]
		[Address(RVA = "0x15EC884", Offset = "0x15EC884", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1F0AE70]);\n\tv27 = *([v26 @ X8_v17]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, d, state, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2029FB6]) = v44;\nL_001A:\n\tv48 = new Firebase.Unity.UnitySynchronizationContext+<Send>c__AnonStorey3();\n\tSystem.Object::.ctor(v48);\n\tv48.d = d;\n\tv54 = System.Threading.Thread::get_CurrentThread();\n\tv125 = System.Threading.Thread::get_ManagedThreadId(v54);\n\tv57 = this.mainThreadId != v125;\n\tif (v57) goto L_0044;\n\tSystem.Threading.SendOrPostCallback::Invoke(v48.d, state);\n\treturn;\nL_0044:\n\tv85 = new Firebase.Unity.UnitySynchronizationContext+<Send>c__AnonStorey4();\n\tSystem.Object::.ctor(v85);\n\tv85.<>f__ref$3 = v48;\n\tv169 = Firebase.Unity.UnitySynchronizationContext::GetThreadEvent(v85);\n\tv85.newSignal = v169;\n\tv173 = new System.Threading.SendOrPostCallback();\n\tSystem.Threading.SendOrPostCallback::.ctor(v173, v85, Il2CppMethodInfo);\n\tv180 = Firebase.Unity.UnitySynchronizationContext::Post(this, v173, state);\n\tv115 = v85.newSignal;\n\tv160 = *([v115 @ X0_v18 (System.Threading.ManualResetEvent)]);\n\tv129 = *([v160 @ X8_v14 (Il2CppClass<System.Threading.ManualResetEvent>)+1E0]);\n\tv132 = *([v160 @ X8_v14 (Il2CppClass<System.Threading.ManualResetEvent>)+1E8]);\n\t// 109 IndirectJump v129 @ X3_v4, v115 @ X0_v18 (System.Threading.ManualResetEvent), v115 @ X0_v18 (System.Threading.ManualResetEvent), 15000, v132 @ X2_v4, v129 @ X3_v4, v30 @ X4, v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Send(SendOrPostCallback d, object state)
		{
			//IL_00d8: Expected I, but got O
			//IL_00e8: Expected O, but got I
			//IL_00f8: Expected O, but got I
			_003CSend_003Ec__AnonStorey3 _003CSend_003Ec__AnonStorey5;
			while (true)
			{
				_003CSend_003Ec__AnonStorey5 = new _003CSend_003Ec__AnonStorey3();
				_003CSend_003Ec__AnonStorey5.d = d;
				Thread currentThread = Thread.CurrentThread;
				int managedThreadId = currentThread.ManagedThreadId;
				if (mainThreadId == managedThreadId)
				{
					break;
				}
				_003CSend_003Ec__AnonStorey4 CS_0024_003C_003E8__locals7 = new _003CSend_003Ec__AnonStorey4();
				CS_0024_003C_003E8__locals7._003C_003Ef__ref_00243 = _003CSend_003Ec__AnonStorey5;
				ManualResetEvent threadEvent = ((UnitySynchronizationContext)(object)CS_0024_003C_003E8__locals7).GetThreadEvent();
				CS_0024_003C_003E8__locals7.newSignal = threadEvent;
				SendOrPostCallback d2 = [Token(Token = "0x600006E")] [Address(RVA = "0x15ECA54", Offset = "0x15ECA54", Length = "0x144")] [NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EA5BE0]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, x, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029FB8]) = v41;\nL_0015:\n\tv42 = this.<>f__ref$3;\n\tv45 = v42.d == 0;\n\tif (v45) goto L_002C;\n\tSystem.Threading.SendOrPostCallback::Invoke(v42.d, v146);\nL_001F:\n\tv97 = this.newSignal == 0;\n\tif (v97) goto L_0069;\n\tv104 = System.Threading.EventWaitHandle::Set(this.newSignal);\n\treturn;\n\tv47 = new System.NullReferenceException();\nL_002C:\n\tv52 = new System.NullReferenceException();\n\tgoto L_0038;\nL_0038:\n\tv58 = v146 != 1;\n\tif (v58) goto L_006D;\n\tv134 = 0x6D2BC0(v52, v146, v116, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv124 = *([v134 @ X0_v12]);\n\tv146 = *([v124 @ X20_v6]);\n\tv179 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v124 @ X20_v6]), v116, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv180 = v179 & 1;\n\tv181 = v180 == 0;\n\tif (v181) goto L_0061;\n\tv182 = 0x6D2490(v179, v146, v116, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv185 = v124 == 0;\n\tif (v185) goto L_0069;\n\tv191 = *([v124 @ X20_v6]);\n\t*([v191 @ X8_v10+160])(v195, v124, *([v191 @ X8_v10+168]), v116, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_005E;\n\tv202 = *([v93 @ X8_v13+E0]);\n\tv203 = v202 == 0;\n\tv204 = ~v203;\n\tif (v204) goto L_005E;\n\tv207 = v93;\n\tv206 = \"il2cpp_codegen_runtime_class_init\"(v207, v194, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_005E:\n\tUnityEngine.Debug::Log(v195);\n\tgoto L_001F;\nL_0061:\n\tv184 = 0x6D1E60(8, *([v124 @ X20_v6]), v116, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\t*([v184 @ X0_v18]) = *([v134 @ X0_v12]);\n\tv146 = 0x1E8A000 + 0x870;\n\tv190 = 0x6D2A00(v184, v146, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0069:\n\tv128 = new System.NullReferenceException();\n\tv132 = 0x6D2490(v128, v146, v116, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_006D:\n\tv153 = 0x6D2380(v149, v146, v116, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv168 = 0x846AA4(v153, v146, v116, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")] (object x) =>
				{
					//IL_003e: Expected I, but got O
					//IL_016f: Expected O, but got I4
					//IL_017e: Expected I, but got O
					_003CSend_003Ec__AnonStorey3 _003CSend_003Ec__AnonStorey6 = CS_0024_003C_003E8__locals7._003C_003Ef__ref_00243;
					object obj3 = default(object);
					if (_003CSend_003Ec__AnonStorey6.d != null)
					{
						_003CSend_003Ec__AnonStorey6.d(obj3);
						IntPtr intPtr2 = (IntPtr)null;
						goto IL_0043;
					}
					NullReferenceException ex = new NullReferenceException();
					bool flag = (IntPtr)obj3 != (IntPtr)1;
					NullReferenceException ex2 = ex;
					if (flag)
					{
						goto IL_0183;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
					object obj5 = default(object);
					object obj4 = obj5;
					obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
					object obj6 = default(object);
					if ((uint)((ulong)(long)(IntPtr)obj6 & 1uL) != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
						if (obj4 != null)
						{
							object obj7 = obj4;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v191 @ X8_v10+160] (should have been resolved before IL gen)");
							object message = default(object);
							Debug.Log(message);
							obj3 = null;
							goto IL_0043;
						}
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
						object obj8 = obj5;
						obj3 = 32022528 + 2160;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2A00 (native __cxa_throw)");
						IntPtr intPtr2 = (IntPtr)null;
					}
					goto IL_01ac;
					IL_0183:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
					return;
					IL_0043:
					if (CS_0024_003C_003E8__locals7.newSignal != null)
					{
						bool flag2 = CS_0024_003C_003E8__locals7.newSignal.Set();
						return;
					}
					goto IL_01ac;
					IL_01ac:
					NullReferenceException ex3 = new NullReferenceException();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
					ex2 = ex3;
					goto IL_0183;
				};
				Post(d2, state);
				ManualResetEvent manualResetEvent = CS_0024_003C_003E8__locals7.newSignal;
				IntPtr intPtr = (IntPtr)manualResetEvent;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ X8_v14 (Il2CppClass<System.Threading.ManualResetEvent>)+1E0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ X8_v14 (Il2CppClass<System.Threading.ManualResetEvent>)+1E8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v129 @ X3_v4 (should have been resolved before IL gen)");
			}
			_003CSend_003Ec__AnonStorey5.d(state);
		}

		[Token(Token = "0x600005A")]
		[Address(RVA = "0x15EC9D4", Offset = "0x15EC9D4", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1ECDB88]);\n\tv17 = *([v16 @ X8_v12]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2029FB7]) = v37;\nL_0016:\n\tv41._instance = 0;\n\tv45 = new System.Collections.Generic.Dictionary`2<System.Int32, System.Threading.ManualResetEvent>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Threading.ManualResetEvent>::.ctor(v45);\n\tv51.signalDictionary = v45;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static UnitySynchronizationContext()
		{
			Dictionary<int, ManualResetEvent> dictionary = new Dictionary<int, ManualResetEvent>();
			signalDictionary = dictionary;
		}
	}
}
