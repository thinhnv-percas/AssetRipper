using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Firebase
{
	[Token(Token = "0x2000023")]
	internal class Dispatcher
	{
		[Token(Token = "0x2000024")]
		private class CallbackStorage<TResult>
		{
			[Token(Token = "0x17000027")]
			public TResult Result
			{
				[CompilerGenerated]
				[Token(Token = "0x600009C")]
				[Address(RVA = "0xD94208", Offset = "0xD94208", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Result>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return Result;
				}
				[CompilerGenerated]
				[Token(Token = "0x600009D")]
				[Address(RVA = "0xD94210", Offset = "0xD94210", Length = "0xC")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = value & 1;\n\tthis.<Result>k__BackingField = v0;\n\treturn;\n")]
				set
				{
					//IL_0019: Expected O, but got I4
					int num = (int)((long)(IntPtr)value & 1L);
					_003CResult_003Ek__BackingField = (TResult)num;
				}
			}

			[Token(Token = "0x17000028")]
			public Exception Exception
			{
				[CompilerGenerated]
				[Token(Token = "0x600009E")]
				[Address(RVA = "0xD9421C", Offset = "0xD9421C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Exception>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return Exception;
				}
				[CompilerGenerated]
				[Token(Token = "0x600009F")]
				[Address(RVA = "0xD94224", Offset = "0xD94224", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Exception>k__BackingField = value;\n\treturn;\n")]
				set
				{
					Exception = value;
				}
			}

			[Token(Token = "0x600009B")]
			[Address(RVA = "0xD941F0", Offset = "0xD941F0", Length = "0x18")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public CallbackStorage()
			{
			}
		}

		[Token(Token = "0x4000044")]
		[FieldOffset(Offset = "0x10")]
		private int ownerThreadId;

		[Token(Token = "0x4000045")]
		[FieldOffset(Offset = "0x18")]
		private Queue<Action> queue;

		[Token(Token = "0x6000095")]
		[Address(RVA = "0x15E4DD8", Offset = "0x15E4DD8", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EA96C8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029F45]) = v38;\nL_0016:\n\tv42 = new System.Collections.Generic.Queue`1<System.Action>();\n\tSystem.Collections.Generic.Queue`1<System.Action>::.ctor(v42);\n\tthis.queue = v42;\n\tSystem.Object::.ctor(this);\n\tv50 = System.Threading.Thread::get_CurrentThread();\n\tv53 = System.Threading.Thread::get_ManagedThreadId(v50);\n\tthis.ownerThreadId = v53;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Dispatcher()
		{
			Queue<Action> queue = new Queue<Action>();
			this.queue = queue;
			Thread currentThread = Thread.CurrentThread;
			int managedThreadId = currentThread.ManagedThreadId;
			ownerThreadId = managedThreadId;
		}

		[Token(Token = "0x6000096")]
		[Address(RVA = "0xAD9814", Offset = "0xAD9814", Length = "0x23C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv28 = *([1EE3100]);\n\tv29 = *([v28 @ X8_v33]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, callback, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20223DE]) = v46;\nL_001E:\n\tgoto L_0022;\n\tv53 = v48;\n\tv54 = 0x8907BC(v53, callback, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0022:\n\tv57 = new Il2CppClass<Firebase.Dispatcher+<Run>c__AnonStorey0`1<TResult>>();\n\tv62 = Firebase.Dispatcher+<Run>c__AnonStorey0`1<TResult>::.ctor(v57);\n\tv57.callback = callback;\n\tv116 = Firebase.Dispatcher::ManagesThisThread(this);\n\tv149 = v116 == 0;\n\tif (v149) goto L_003C;\n\tv235 = v57.callback;\n\tgoto L_0086;\nL_003C:\n\tv183 = new System.Threading.EventWaitHandle();\n\tSystem.Threading.EventWaitHandle::.ctor(v183, 0, 1);\n\tv57.waitHandle = v183;\n\tgoto L_004D;\n\tv293 = v250;\n\tv294 = 0x8907BC(v293, v217, v216, v218, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_004D:\n\tv297 = new Il2CppClass<Firebase.Dispatcher+CallbackStorage`1<TResult>>();\n\tv309 = Firebase.Dispatcher+CallbackStorage`1<TResult>::.ctor(v297);\n\tv57.result = v297;\n\tSystem.Threading.Monitor::Enter(this.queue);\n\tv316 = new System.Action();\n\tSystem.Action::.ctor(v316, v57, Il2CppMethodInfo);\n\tSystem.Collections.Generic.Queue`1<System.Action>::Enqueue(this.queue, v316);\n\tSystem.Threading.Monitor::Exit(this.queue);\nL_0075:\n\tv329 = System.Threading.WaitHandle::WaitOne(v57.waitHandle);\n\tv104 = Firebase.Dispatcher+CallbackStorage`1<TResult>::get_Exception(v57.result);\n\tv332 = v104 == 0;\n\tv201 = ~v332;\n\tif (v201) goto L_0097;\nL_0086:\n\tv241 = *([v233 @ X1_v2 (Il2CppMethodInfo)]);\n\t// 143 IndirectJump v241 @ X2_v2, v235 @ X0_v6 (System.Func`1<TResult>), v235 @ X0_v6 (System.Func`1<TResult>), v233 @ X1_v2 (Il2CppMethodInfo), v241 @ X2_v2, v231 @ X3_v1, v32 @ X4, v33 @ X5, v34 @ X6, v35 @ X7, v36 @ V0, v37 @ V1, v38 @ V2, v39 @ V3, v40 @ V4, v41 @ V5, v42 @ V6, v43 @ V7\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_0097:\n\tv208 = Firebase.Dispatcher+CallbackStorage`1<TResult>::get_Exception(v204);\n\tv301 = new System.TypeLoadException();\n\tgoto L_FFFFFFFF;\n\tgoto L_00B5;\n\tv298 = Firebase.Dispatcher::Run(v301, 0);\n\tv312 = Firebase.Dispatcher::Run(v298, 0);\n\tSystem.Threading.Monitor::Exit(v203);\n\tv303 = ~v298.m_value;\n\tif (v303) goto L_0075;\n\tv301 = new System.TypeLoadException();\nL_00B5:\n\treturnVal1 = Firebase.Dispatcher::Run(v301, v281);\n\treturn returnVal1;\n// 131 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TResult Run<TResult>(Func<TResult> callback)
		{
			//IL_0204: Expected O, but got I
			//IL_00f8: Expected O, but got I4
			//IL_01f2: Expected O, but got I4
			IntPtr intPtr;
			if (ManagesThisThread())
			{
				Func<TResult> func = callback;
				intPtr = (IntPtr)0;
			}
			else
			{
				EventWaitHandle eventWaitHandle = new EventWaitHandle(initialState: false, EventResetMode.ManualReset);
				EventWaitHandle waitHandle = eventWaitHandle;
				CallbackStorage<TResult> callbackStorage = new CallbackStorage<TResult>();
				CallbackStorage<TResult> result = callbackStorage;
				Monitor.Enter(queue);
				Action item = [Token(Token = "0x60000A1")] [Address(RVA = "0xD93B90", Offset = "0xD93B90", Length = "0x1D4")] [NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = &v9 @ X29;\n\tgoto L_0021;\n\tv23 = *([1EB4040]);\n\tv24 = *([v23 @ X8_v29]);\n\tv25 = \"il2cpp_codegen_initialize_method\"(v24, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20240BC]) = v42;\nL_0021:\n\tv53 = System.Func`1<TResult>::Invoke(this.callback);\n\tv54 = this.result == 0;\n\tif (v54) goto L_005A;\n\tv60 = v53 & 1;\n\tv62 = Firebase.Dispatcher+CallbackStorage`1<TResult>::set_Result(this.result, v60);\nL_002E:\n\t*([v109 @ X22_v2]) = 0x3A;\nL_0033:\n\tv185 = System.Threading.EventWaitHandle::Set(this.waitHandle);\n\tv201 = v125 + 1;\n\tv203 = v201 == 0;\n\tif (v203) goto L_004B;\n\tv214 = v123 == 0;\n\tif (v214) goto L_0056;\n\tv251 = *([v109 @ X22_v2+v125 @ X21_v2 (System.Int32)*4]) == 0x3A;\n\tif (v251) goto L_0056;\nL_004A:\n\tthrow System.TypeLoadException;\nL_004B:\n\tv241 = v123 == 0;\n\tv242 = ~v241;\n\tif (v242) goto L_004A;\nL_0056:\n\treturn;\n\tv55 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_005A:\n\tv107 = new System.NullReferenceException();\n\tgoto L_005C;\nL_005C:\n\t*([v9 @ X29-28]) = v66;\n\tv127 = v173 != 1;\n\tif (v127) goto L_009D;\n\tv187 = System.Func`1<TResult>::Invoke(v107);\n\tv158 = *([v187 @ X0_v22 (TResult)]);\n\tv173 = *([v158 @ X21_v10 (Il2CppClass<TResult>)]);\n\tv211 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v158 @ X21_v10 (Il2CppClass<TResult>)]), v92, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv243 = v211 & 1;\n\tv244 = v243 == 0;\n\tif (v244) goto L_0083;\n\tv282 = System.Func`1<TResult>::Invoke(v211);\n\tv153 = this.result == 0;\n\tif (v153) goto L_008A;\n\tv151 = Firebase.Dispatcher+CallbackStorage`1<TResult>::set_Exception(this.result, v158);\n\tv109 = *([v9 @ X29-28]);\n\tgoto L_002E;\nL_0083:\n\tv284 = System.Func`1<TResult>::Invoke(8);\n\t*([v284 @ X0_v28 (TResult)]) = *([v187 @ X0_v22 (TResult)]);\n\tv173 = 0x1E8A000 + 0x870;\n\tv310 = System.Func`1<TResult>::Invoke(v284);\nL_008A:\n\tv193 = new System.NullReferenceException();\n\tgoto L_FFFFFFFF;\n\tgoto L_009D;\n\tX22 = X1;\n\tX21 = X0;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_009D:\n\tv162 = v188 != 1;\n\tif (v162) goto L_00A5;\n\tv212 = System.Func`1<TResult>::Invoke(v197);\n\tv123 = *([v212 @ X0_v19 (TResult)]);\n\tv175 = System.Func`1<TResult>::Invoke(v212);\n\tv109 = *([v9 @ X29-28]);\n\tgoto L_0033;\nL_00A5:\n\tv213 = System.Func`1<TResult>::Invoke(v197);\n\tv245 = System.Func`1<TResult>::Invoke(v213);\n\treturn;\n// 102 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")] () =>
				{
					//IL_0059: Expected O, but got I4
					//IL_02e9: Expected O, but got I4
					//IL_02ee: Expected I, but got O
					//IL_0169: Expected I, but got O
					//IL_0290: Expected I, but got O
					//IL_02b2: Expected O, but got I
					//IL_020b: Expected O, but got I4
					//IL_01ec: Expected O, but got I
					//IL_01fc: Expected O, but got I
					object obj3 = obj3;
					TResult val = callback();
					IntPtr intPtr4;
					int num2;
					object obj4;
					if (result == null)
					{
						NullReferenceException ex2 = new NullReferenceException();
						IntPtr intPtr2 = default(IntPtr);
						bool flag2 = intPtr2 != (IntPtr)1;
						int num = (int)(long)intPtr2;
						NullReferenceException ex3 = ex2;
						if (!flag2)
						{
							TResult val2 = ex2();
							IntPtr intPtr3 = (IntPtr)val2;
							intPtr2 = intPtr3;
							Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
							Func<TResult> func2 = default(Func<TResult>);
							if ((uint)((ulong)(long)(IntPtr)func2 & 1uL) != 0)
							{
								TResult val3 = func2();
								if (result != null)
								{
									result.Exception = (Exception)(long)intPtr3;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ X29-28]");
									obj4 = 0;
									goto IL_02e0;
								}
							}
							else
							{
								TResult val4 = ((Func<TResult>)8)();
								val4 = val2;
								intPtr2 = (IntPtr)(32022528 + 2160);
								TResult val5 = val4();
							}
							NullReferenceException ex4 = new NullReferenceException();
							num = (int)(long)intPtr2;
							ex3 = ex4;
						}
						if (num != 1)
						{
							TResult val6 = ex3();
							TResult val7 = val6();
							return;
						}
						TResult val8 = ex3();
						intPtr4 = (IntPtr)val8;
						TResult val9 = val8();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ X29-28]");
						obj4 = 0;
						num2 = -1;
						goto IL_0066;
					}
					int num3 = (int)((long)(IntPtr)val & 1L);
					result.Result = (TResult)num3;
					object obj5 = default(object);
					obj4 = obj5;
					goto IL_02e0;
					IL_02e0:
					obj4 = 58;
					intPtr4 = (IntPtr)null;
					num2 = 0;
					goto IL_0066;
					IL_0066:
					bool flag3 = waitHandle.Set();
					if (num2 + 1 != 0)
					{
						if (intPtr4 == (IntPtr)0)
						{
							return;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ X22_v2+v125 @ X21_v2 (System.Int32)*4]");
						if ((IntPtr)0 == (IntPtr)58)
						{
							return;
						}
					}
					else if (intPtr4 == (IntPtr)0)
					{
						return;
					}
					throw new TypeLoadException();
				};
				queue.Enqueue(item);
				Monitor.Exit(queue);
				object obj = 0;
				bool flag = waitHandle.WaitOne();
				Exception exception = result.Exception;
				if (exception != null)
				{
					CallbackStorage<TResult> callbackStorage2 = default(CallbackStorage<TResult>);
					Exception exception2 = callbackStorage2.Exception;
					TypeLoadException ex = new TypeLoadException();
					Func<bool> callback2 = null;
					return (TResult)((Dispatcher)(object)ex).Run(callback2);
				}
				intPtr = (IntPtr)0;
			}
			object obj2 = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v241 @ X2_v2 (should have been resolved before IL gen)");
			return (TResult)null;
		}

		[Token(Token = "0x6000097")]
		[Address(RVA = "0xBAF688", Offset = "0xBAF688", Length = "0x1B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv28 = *([1EAE1D0]);\n\tv29 = *([v28 @ X8_v24]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, callback, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2022C33]) = v46;\nL_001E:\n\tgoto L_0022;\n\tv53 = v48;\n\tv54 = 0x8907BC(v53, callback, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0022:\n\tv57 = new Il2CppClass<Firebase.Dispatcher+<RunAsync>c__AnonStorey1`1<TResult>>();\n\tv62 = Firebase.Dispatcher+<RunAsync>c__AnonStorey1`1<TResult>::.ctor(v57);\n\tv57.callback = callback;\n\tv69 = Firebase.Dispatcher::ManagesThisThread(this);\n\tv117 = v69 == 0;\n\tif (v117) goto L_003D;\n\tv170 = v57.callback;\n\tgoto L_0068;\nL_003D:\n\tgoto L_0041;\n\tv184 = v151;\n\tv185 = 0x8907BC(v184, v68, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0041:\n\tv188 = new Il2CppClass<System.Threading.Tasks.TaskCompletionSource`1<TResult>>();\n\tv230 = System.Threading.Tasks.TaskCompletionSource`1<TResult>::.ctor(v188);\n\tv57.tcs = v188;\n\tSystem.Threading.Monitor::Enter(this.queue);\n\tv243 = new System.Action();\n\tSystem.Action::.ctor(v243, v57, Il2CppMethodInfo);\n\tv138 = this.queue == 0;\n\tif (v138) goto L_0075;\n\tSystem.Collections.Generic.Queue`1<System.Action>::Enqueue(this.queue, v243);\n\tSystem.Threading.Monitor::Exit(this.queue);\nL_0063:\n\t;\nL_0068:\n\tv176 = *([v168 @ X1_v3 (Il2CppMethodInfo)]);\n\t// 113 IndirectJump v176 @ X2_v3, v170 @ X0_v8 (System.Func`1<TResult>), v170 @ X0_v8 (System.Func`1<TResult>), v168 @ X1_v3 (Il2CppMethodInfo), v176 @ X2_v3, v165 @ X3_v2, v32 @ X4, v33 @ X5, v34 @ X6, v35 @ X7, v36 @ V0, v37 @ V1, v38 @ V2, v39 @ V3, v40 @ V4, v41 @ V5, v42 @ V6, v43 @ V7\n\tthrow System.NullReferenceException;\nL_0075:\n\tv146 = new System.NullReferenceException();\n\tgoto L_0080;\nL_0080:\n\tv198 = v214 != 1;\n\tif (v198) goto L_008E;\n\tv233 = 0x6D2BC0(v146, v214, v211, v165, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv244 = 0x6D2490(v233, v214, v211, v165, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tSystem.Threading.Monitor::Exit(v141);\n\tv238 = *([v233 @ X0_v14]) == 0;\n\tif (v238) goto L_0063;\n\tv237 = new System.TypeLoadException();\nL_008E:\n\treturnVal1 = 0x6D2380(v146, 0, 0, v165, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\treturn returnVal1;\n// 98 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Task<TResult> RunAsync<TResult>(Func<TResult> callback)
		{
			//IL_01b0: Expected O, but got I
			//IL_00ec: Expected O, but got I4
			IntPtr intPtr;
			if (ManagesThisThread())
			{
				Func<TResult> func = callback;
				intPtr = (IntPtr)0;
				goto IL_01a8;
			}
			TaskCompletionSource<TResult> taskCompletionSource = new TaskCompletionSource<TResult>();
			TaskCompletionSource<TResult> tcs = taskCompletionSource;
			Monitor.Enter(queue);
			Action item = [Token(Token = "0x60000A3")] [Address(RVA = "0xD93F68", Offset = "0xD93F68", Length = "0x138")] [NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv24 = *([1EB4620]);\n\tv25 = *([v24 @ X8_v19]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20240BE]) = v43;\nL_001E:\n\tv51 = System.Func`1<TResult>::Invoke(this.callback);\n\tv52 = this.tcs == 0;\n\tif (v52) goto L_0032;\n\tv58 = v51 & 1;\n\tv60 = System.Threading.Tasks.TaskCompletionSource`1<TResult>::SetResult(this.tcs, v58);\n\treturn;\n\tthrow System.NullReferenceException;\nL_0032:\n\tv73 = new System.NullReferenceException();\n\tgoto L_003E;\nL_003E:\n\tv78 = v113 != 1;\n\tif (v78) goto L_0069;\n\tv135 = 0x6D2BC0(v73, v113, v137, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv147 = *([v135 @ X0_v11]);\n\tv113 = *([v147 @ X21_v5]);\n\tv151 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v147 @ X21_v5]), v137, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv152 = v151 & 1;\n\tv153 = v152 == 0;\n\tif (v153) goto L_005E;\n\tv154 = 0x6D2490(v151, v113, v137, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv118 = this.tcs == 0;\n\tif (v118) goto L_0065;\n\tv109 = Il2CppMethodInfo;\n\t// 92 IndirectJump [v109 @ X2_v4 (Il2CppMethodInfo)], this.tcs (System.Threading.Tasks.TaskCompletionSource`1<TResult>), this.tcs (System.Threading.Tasks.TaskCompletionSource`1<TResult>), v147 @ X21_v5, methodof(System.Threading.Tasks.TaskCompletionSource`1<TResult>::SetException), [v109 @ X2_v4 (Il2CppMethodInfo)], v29 @ X4, v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\nL_005E:\n\tv156 = 0x6D1E60(8, *([v147 @ X21_v5]), v137, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\t*([v156 @ X0_v18]) = *([v135 @ X0_v11]);\n\tv113 = 0x1E8A000 + 0x870;\n\tv161 = 0x6D2A00(v156, v113, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0065:\n\tv164 = new System.NullReferenceException();\n\tv140 = 0x6D2490(v164, v113, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0069:\n\tv145 = 0x6D2380(v129, v113, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv116 = 0x846AA4(v145, v113, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")] () =>
			{
				//IL_0051: Expected O, but got I4
				//IL_00a7: Expected I, but got O
				TResult val = callback();
				if (tcs != null)
				{
					int num = (int)((long)(IntPtr)val & 1L);
					tcs.SetResult((TResult)num);
					return;
				}
				NullReferenceException ex3 = new NullReferenceException();
				IntPtr intPtr2 = default(IntPtr);
				bool flag = intPtr2 != (IntPtr)1;
				NullReferenceException ex4 = ex3;
				if (!flag)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
					object obj6 = default(object);
					object obj5 = obj6;
					intPtr2 = (IntPtr)obj5;
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
					object obj7 = default(object);
					if ((uint)((ulong)(long)(IntPtr)obj7 & 1uL) != 0)
					{
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
						if (tcs == null)
						{
							goto IL_015f;
						}
						IntPtr intPtr3 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v109 @ X2_v4 (Il2CppMethodInfo)] (should have been resolved before IL gen)");
					}
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @6D1E60 (native __cxa_allocate_exception)");
					object obj8 = obj6;
					intPtr2 = (IntPtr)(32022528 + 2160);
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @6D2A00 (native __cxa_throw)");
					goto IL_015f;
				}
				goto IL_0184;
				IL_0184:
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
				return;
				IL_015f:
				NullReferenceException ex5 = new NullReferenceException();
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				ex4 = ex5;
				goto IL_0184;
			};
			if (queue != null)
			{
				queue.Enqueue(item);
				Monitor.Exit(queue);
				object obj = 0;
				goto IL_00f7;
			}
			NullReferenceException ex = new NullReferenceException();
			_003CRunAsync_003Ec__AnonStorey1<TResult> _003CRunAsync_003Ec__AnonStorey2 = default(_003CRunAsync_003Ec__AnonStorey1<TResult>);
			if ((IntPtr)_003CRunAsync_003Ec__AnonStorey2 == (IntPtr)1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				Queue<Action> obj2 = default(Queue<Action>);
				Monitor.Exit(obj2);
				object obj3 = default(object);
				if (obj3 == null)
				{
					goto IL_00f7;
				}
				TypeLoadException ex2 = new TypeLoadException();
				ex = (NullReferenceException)(object)ex2;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			Task<TResult> result = default(Task<TResult>);
			return result;
			IL_01a8:
			object obj4 = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v176 @ X2_v3 (should have been resolved before IL gen)");
			return null;
			IL_00f7:
			intPtr = (IntPtr)0;
			goto IL_01a8;
		}

		[Token(Token = "0x6000098")]
		[Address(RVA = "0xBAF9F8", Offset = "0xBAF9F8", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ECE470]);\n\tv23 = *([v22 @ X8_v26]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022C35]) = v41;\nL_0015:\n\tv42 = callback == 0;\n\tif (v42) goto L_0036;\n\tv47 = System.Func`1<TResult>::Invoke(callback);\n\tgoto L_002C;\n\tv57 = *([v51 @ X0_v31+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_002C;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v51, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002C:\n\tv67 = v47 & 1;\n\treturnVal1 = System.Threading.Tasks.Task::FromResult(v67);\n\treturn returnVal1;\nL_0036:\n\tv56 = new System.NullReferenceException();\n\tgoto L_0042;\nL_0042:\n\tv79 = v108 != 1;\n\tif (v79) goto L_0081;\n\tv131 = 0x6D2BC0(v56, v108, v132, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv144 = *([v131 @ X0_v9]);\n\tv148 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v144 @ X20_v4 (System.Exception)]), v132, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv149 = v148 & 1;\n\tv150 = v149 == 0;\n\tif (v150) goto L_0075;\n\tv151 = 0x6D2490(v148, *([v144 @ X20_v4 (System.Exception)]), v132, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_005B;\n\tv165 = v155;\n\tv166 = 0x8907BC(v165, v146, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_005B:\n\tv169 = new Il2CppClass<System.Threading.Tasks.TaskCompletionSource`1<TResult>>();\n\tv172 = System.Threading.Tasks.TaskCompletionSource`1<TResult>::.ctor(v169);\n\tv113 = v169 == 0;\n\tif (v113) goto L_007D;\n\tv183 = System.Threading.Tasks.TaskCompletionSource`1<TResult>::TrySetException(v169, v144);\n\tv107 = Il2CppMethodInfo;\n\tv75 = *([v107 @ X1_v8 (Il2CppMethodInfo)]);\n\t// 115 IndirectJump v75 @ X2_v5, v169 @ X0_v22 (System.Threading.Tasks.TaskCompletionSource`1<TResult>), v169 @ X0_v22 (System.Threading.Tasks.TaskCompletionSource`1<TResult>), methodof(System.Threading.Tasks.TaskCompletionSource`1<TResult>::get_Task), v75 @ X2_v5, v26 @ X3, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\nL_0075:\n\tv153 = 0x6D1E60(8, *([v144 @ X20_v4 (System.Exception)]), v132, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\t*([v153 @ X0_v17 (System.Threading.Tasks.TaskCompletionSource`1<TResult>)]) = *([v131 @ X0_v9]);\n\tv108 = 0x1E8A000 + 0x870;\n\tv164 = System.Threading.Tasks.TaskCompletionSource`1<TResult>::.ctor(v153);\nL_007D:\n\tv176 = new System.NullReferenceException();\n\tv135 = System.Threading.Tasks.TaskCompletionSource`1<TResult>::.ctor(v176);\nL_0081:\n\tv141 = 0x6D2380(v117, v108, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturnVal2 = 0x846AA4(v141, v108, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn returnVal2;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static Task<TResult> RunAsyncNow<TResult>(Func<TResult> callback)
		{
			//IL_002f: Expected O, but got I4
			//IL_0125: Expected O, but got I
			if (callback != null)
			{
				TResult val = callback();
				int num = (int)((long)(IntPtr)val & 1L);
				return Task.FromResult((TResult)num);
			}
			NullReferenceException ex = new NullReferenceException();
			IntPtr intPtr = default(IntPtr);
			bool flag = intPtr != (IntPtr)1;
			NullReferenceException ex2 = ex;
			if (!flag)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj = default(object);
				Exception exception = (Exception)obj;
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				object obj2 = default(object);
				if ((uint)((ulong)(long)(IntPtr)obj2 & 1uL) != 0)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
					TaskCompletionSource<TResult> taskCompletionSource = new TaskCompletionSource<TResult>();
					bool flag2 = taskCompletionSource == null;
					intPtr = (IntPtr)0;
					if (flag2)
					{
						goto IL_015a;
					}
					bool flag3 = taskCompletionSource.TrySetException(exception);
					IntPtr intPtr2 = (IntPtr)0;
					object obj3 = (long)intPtr2;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v75 @ X2_v5 (should have been resolved before IL gen)");
				}
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @6D1E60 (native __cxa_allocate_exception)");
				TaskCompletionSource<TResult> taskCompletionSource2 = (TaskCompletionSource<TResult>)obj;
				intPtr = (IntPtr)(32022528 + 2160);
				goto IL_015a;
			}
			goto IL_0171;
			IL_0171:
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
			Task<TResult> result = default(Task<TResult>);
			return result;
			IL_015a:
			NullReferenceException ex3 = (NullReferenceException)(object)new TaskCompletionSource<TResult>();
			ex2 = ex3;
			goto IL_0171;
		}

		[Token(Token = "0x6000099")]
		[Address(RVA = "0x15E4E68", Offset = "0x15E4E68", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = System.Threading.Thread::get_CurrentThread();\n\tv14 = System.Threading.Thread::get_ManagedThreadId(v11);\n\tv36 = v14 - this.ownerThreadId;\n\tv38 = v36 == 0;\n\treturn v38;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal bool ManagesThisThread()
		{
			Thread currentThread = Thread.CurrentThread;
			int managedThreadId = currentThread.ManagedThreadId;
			int num = managedThreadId - ownerThreadId;
			return num == 0;
		}

		[Token(Token = "0x600009A")]
		[Address(RVA = "0x15E4EA8", Offset = "0x15E4EA8", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1EECA68]);\n\tv35 = *([v34 @ X8_v12]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2029F46]) = v54;\nL_001B:\n\tv55 = &v56 @ stack_-70;\n\tgoto L_0043;\nL_0027:\n\tgoto L_002C;\n\tgoto L_008D;\nL_0029:\n\tv228 = 0xFFFFFFFF ^ v97;\n\tv97 = v97 + v228;\nL_002C:\n\tFirebase.ExceptionAggregator::Wrap(v106);\n\tgoto L_0043;\nL_002E:\n\tv123 = new System.NullReferenceException();\n\tgoto L_008E;\n\tgoto L_0031;\nL_0031:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_008E;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_005E;\nL_0043:\n\tSystem.Threading.Monitor::Enter(this.queue);\n\tv109 = this.queue;\n\tv110 = this.queue == 0;\n\tif (v110) goto L_002E;\n\tv122 = v109._size < 1;\n\tif (v122) goto L_005A;\n\tv125 = System.Collections.Generic.Queue`1<System.Action>::Dequeue(this.queue);\n\tv97 = v97 + 1;\n\t*([v55 @ X23_v1+v97 @ X28_v2*4]) = 0x40;\n\tgoto L_005E;\nL_005A:\n\tv97 = v97 + 1;\n\t*([v55 @ X23_v1+v97 @ X28_v2*4]) = 0x4B;\nL_005E:\n\tSystem.Threading.Monitor::Exit(this.queue);\n\tv164 = v97 + 1;\n\tv166 = v164 == 0;\n\tif (v166) goto L_0027;\n\tv174 = *([v55 @ X23_v1+v97 @ X28_v2*4]) == 0x40;\n\tif (v174) goto L_0029;\n\tv179 = *([v55 @ X23_v1+v97 @ X28_v2*4]) != 0x4B;\n\tif (v179) goto L_0027;\n\treturn;\nL_008D:\n\tv157 = new System.TypeLoadException();\nL_008E:\n\tv163 = 0x6D2380(v123, v153, 0, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\treturn;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void PollJobs()
		{
			//IL_017f: Expected O, but got I8
			//IL_00e2: Expected O, but got I
			//IL_01b1: Expected O, but got I
			//IL_00c0: Expected O, but got I
			//IL_0022: Expected I4, but got I8
			//IL_0030: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			object obj3 = 4294967295L;
			Action action = null;
			while (true)
			{
				Monitor.Enter(this.queue);
				Queue<Action> queue = this.queue;
				if (this.queue == null)
				{
					NullReferenceException ex = new NullReferenceException();
					int num = 0;
					Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
					break;
				}
				if (queue.Count >= 1)
				{
					Action action2 = this.queue.Dequeue();
					obj3 = (long)(IntPtr)obj3 + 1L;
					_ = 64;
					action = action2;
				}
				else
				{
					obj3 = (long)(IntPtr)obj3 + 1L;
					_ = 75;
				}
				Monitor.Exit(this.queue);
				object obj4 = (long)(IntPtr)obj3 + 1L;
				if (obj4 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X23_v1+v97 @ X28_v2*4]");
					if ((IntPtr)0 == (IntPtr)64)
					{
						int num2 = (int)(0xFFFFFFFFL ^ (long)(IntPtr)obj3);
						obj3 = (long)(IntPtr)obj3 + (long)num2;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X23_v1+v97 @ X28_v2*4]");
						if ((IntPtr)0 == (IntPtr)75)
						{
							break;
						}
					}
				}
				ExceptionAggregator.Wrap(action);
			}
		}
	}
}
