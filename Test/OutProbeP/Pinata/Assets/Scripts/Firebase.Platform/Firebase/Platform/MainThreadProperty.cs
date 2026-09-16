using System;
using System.Threading;
using System.Threading.Tasks;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Firebase.Platform
{
	[Token(Token = "0x200002B")]
	internal class MainThreadProperty<T>
	{
		[Token(Token = "0x4000055")]
		[FieldOffset(Offset = "0x0")]
		private Func<T> getPropertyDelegate;

		[Token(Token = "0x4000056")]
		[FieldOffset(Offset = "0x0")]
		private int lastGetPropertyTickCount = -1;

		[Token(Token = "0x4000057")]
		[FieldOffset(Offset = "0x0")]
		private T cachedValue;

		[Token(Token = "0x1700002B")]
		public T Value
		{
			[Token(Token = "0x60000B3")]
			[Address(RVA = "0xD942A4", Offset = "0xD942A4", Length = "0x394")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv32 = *([1EF7D30]);\n\tv33 = *([v32 @ X8_v54]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([20240C0]) = v51;\nL_001A:\n\tv52 = &v53 @ stack_-60;\n\tSystem.Threading.Monitor::Enter(this.getPropertyDelegate);\n\tgoto L_0030;\n\tv64 = *([v60 @ X0_v3+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tgoto L_0030;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v60, v56, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_0030:\n\tgoto L_003B;\n\tv76 = *([1EC0810]);\n\tv77 = *([v76 @ X8_v50]);\n\tv78 = \"il2cpp_codegen_initialize_method\"(v77, v56, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv81 = 0 | 1;\n\t*([202413D]) = v81;\nL_003B:\n\tgoto L_004E;\n\tv86 = *([v82 @ X0_v6 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv87 = v86 == 0;\n\tv88 = ~v87;\n\tgoto L_004E;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v82, v56, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv90 = Firebase.Platform.FirebaseHandler;\nL_004E:\n\tv105 = v93.tickCount != this.lastGetPropertyTickCount;\n\tif (v105) goto L_0072;\n\tv115 = *([this @ X0 (Firebase.Platform.MainThreadProperty`1<T>)+1C]) == 0;\n\tv120 = ~v115;\n\t*([v52 @ X25_v1]) = 0xDE;\n\tSystem.Threading.Monitor::Exit(this.getPropertyDelegate);\nL_006E:\n\treturn v137;\nL_0072:\n\t*([v52 @ X25_v1]) = 0x35;\n\tSystem.Threading.Monitor::Exit(this.getPropertyDelegate);\nL_0074:\n\t;\n\tgoto L_007F;\n\tv268 = v187;\n\tv269 = 0x8907BC(v268, v124, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_007F:\n\tv272 = new Il2CppClass<System.Func`1<T>>();\n\tv279 = System.Func`1<T>::.ctor(v272, this, Il2CppMethodInfo);\n\tgoto L_0097;\n\tv284 = *([v280 @ X0_v13+E0]);\n\tv285 = v284 == 0;\n\tv286 = ~v285;\n\tif (v286) goto L_0097;\n\tv288 = \"il2cpp_codegen_runtime_class_init\"(v280, v274, v277, v134, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_0097:\n\tv296 = Firebase.Platform.FirebaseHandler::RunOnMainThreadAsync(v272);\n\tv300 = System.Threading.Tasks.Task::get_IsCompleted(v296);\n\tv303 = v300 == 0;\n\tv304 = ~v303;\n\tif (v304) goto L_00CA;\nL_00A5:\n\tv365 = System.Threading.Tasks.Task::get_IsFaulted(v296);\n\tv407 = v365 == 0;\n\tv369 = ~v407;\n\tif (v369) goto L_00CA;\n\tv366 = System.Threading.Tasks.Task::get_IsCanceled(v296);\n\tv339 = v362 > 0x63;\n\tif (v339) goto L_00CA;\n\tv430 = v366 == 0;\n\tv370 = ~v430;\n\tif (v370) goto L_00CA;\n\tSystem.Threading.Thread::Sleep(1);\n\tv362 = v362 + 1;\n\tv364 = System.Threading.Tasks.Task::get_IsCompleted(v296);\n\tv368 = v364 == 0;\n\tif (v368) goto L_00A5;\nL_00CA:\n\tv330 = System.Threading.Tasks.Task::get_IsFaulted(v296);\n\tv382 = v330 == 0;\n\tv332 = ~v382;\n\tif (v332) goto L_013E;\n\tv410 = System.Threading.Tasks.Task::get_IsCompleted(v296);\n\tv414 = v410 == 0;\n\tif (v414) goto L_00DB;\n\tv420 = System.Threading.Tasks.Task::get_IsCanceled(v296);\n\tv424 = v420 == 0;\n\tif (v424) goto L_012C;\nL_00DB:\n\tv247 = this.getPropertyDelegate;\n\tSystem.Threading.Monitor::Enter(this.getPropertyDelegate);\n\tgoto L_00ED;\n\tv450 = *([v432 @ X0_v41+E0]);\n\tv451 = v450 == 0;\n\tv452 = ~v451;\n\tif (v452) goto L_00ED;\n\tv454 = \"il2cpp_codegen_runtime_class_init\"(v432, v426, v277, v134, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_00ED:\n\tgoto L_00F8;\n\tv465 = *([1EC0810]);\n\tv466 = *([v465 @ X8_v41]);\n\tv467 = \"il2cpp_codegen_initialize_method\"(v466, v426, v277, v134, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv470 = 0 | 1;\n\t*([202413D]) = v470;\nL_00F8:\n\tgoto L_0108;\n\tv505 = *([v471 @ X0_v44 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv506 = v505 == 0;\n\tv507 = ~v506;\n\tgoto L_0108;\n\tv516 = \"il2cpp_codegen_runtime_class_init\"(v471, v426, v277, v134, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv508 = Firebase.Platform.FirebaseHandler;\nL_0108:\n\tv488 = *([this @ X0 (Firebase.Platform.MainThreadProperty`1<T>)+1C]) == 0;\n\tv478 = ~v488;\n\tthis.lastGetPropertyTickCount = v510.tickCount;\n\t*([v52 @ X25_v1]) = 0xDE;\nL_0114:\n\tSystem.Threading.Monitor::Exit(v247);\n\tv168 = v136 + 1;\n\tv513 = v168 == 0;\n\tif (v513) goto L_0126;\n\tv150 = *([v52 @ X25_v1+v136 @ X26_v1 (System.Int32)*4]) == 0xDE;\n\tif (v150) goto L_006E;\nL_0126:\n\tv518 = v164 == 0;\n\tv403 = ~v518;\n\tif (v403) goto L_0147;\nL_012C:\n\tv240 = Il2CppMethodInfo;\n\tv199 = *([v240 @ X1_v13 (Il2CppMethodInfo)]);\n\t// 314 IndirectJump v199 @ X2_v7, v296 @ X0_v16 (System.Threading.Tasks.Task), v296 @ X0_v16 (System.Threading.Tasks.Task), methodof(System.Threading.Tasks.Task`1<T>::get_Result), v199 @ X2_v7, methodof(System.Func`1<T>::.ctor), v37 @ X4, v38 @ X5, v39 @ X6, v40 @ X7, v41 @ V0, v42 @ V1, v43 @ V2, v44 @ V3, v45 @ V4, v46 @ V5, v47 @ V6, v48 @ V7\n\tthrow System.NullReferenceException;\nL_013E:\n\tv335 = System.Threading.Tasks.Task::get_Exception(v296);\n\tthrow System.TypeLoadException;\nL_0147:\n\tv411 = new System.TypeLoadException();\n\tgoto L_016E;\n\tv428 = System.Func`1<T>::.ctor(v411, 0, 0);\n\tv164 = *([v428 @ X0_v23 (System.Func`1<T>)]);\n\tv437 = System.Func`1<T>::.ctor(v428, 0, 0);\n\tgoto L_0114;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_016E;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX22 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X21;\n\tX1 = 0;\n\tSystem.Threading.Monitor::Exit(X0, X1);\n\tif (TEMP) goto L_0074;\n\tX0 = X22;\n\tgoto L_0147;\nL_016E:\n\treturnVal2 = System.Func`1<T>::.ctor(v411, 0, 0);\n\treturn returnVal2;\n// 223 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_005b: Expected O, but got I4
				//IL_0035: Expected O, but got I4
				//IL_0052: Expected O, but got I4
				//IL_019c: Expected O, but got I4
				//IL_0278: Expected O, but got I
				//IL_036d: Expected O, but got I4
				//IL_0383: Expected I, but got O
				//IL_013d: Expected O, but got I
				object obj2 = default(object);
				object obj = obj2;
				Monitor.Enter(getPropertyDelegate);
				bool flag3;
				if (FirebaseHandler.tickCount == lastGetPropertyTickCount)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Firebase.Platform.MainThreadProperty`1<T>)+1C]");
					bool flag = (IntPtr)0 == (IntPtr)0;
					bool flag2 = !flag;
					obj = 222;
					Monitor.Exit(getPropertyDelegate);
					flag3 = flag2;
					goto IL_004d;
				}
				obj = 53;
				Monitor.Exit(getPropertyDelegate);
				Func<T> f = [Token(Token = "0x60000B4")] [Address(RVA = "0xD94638", Offset = "0xD94638", Length = "0x144")] [NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1EC7018]);\n\tv27 = *([v26 @ X8_v23]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([20240C1]) = v45;\nL_0018:\n\tv47 = this.getPropertyDelegate == 0;\n\tif (v47) goto L_0058;\n\tv52 = System.Func`1<T>::Invoke(this.getPropertyDelegate);\n\tSystem.Threading.Monitor::Enter(this.getPropertyDelegate);\n\tv58 = v52 & 1;\n\t*([this @ X0 (Firebase.Platform.MainThreadProperty`1<T>)+1C]) = v58;\n\tgoto L_0036;\n\tv75 = *([v61 @ X0_v15+E0]);\n\tv76 = v75 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_0036;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v61, v55, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0036:\n\tgoto L_0041;\n\tv99 = *([1EC0810]);\n\tv100 = *([v99 @ X8_v18]);\n\tv101 = \"il2cpp_codegen_initialize_method\"(v100, v55, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv104 = 0 | 1;\n\t*([202413D]) = v104;\nL_0041:\n\tgoto L_004C;\n\tv110 = *([v105 @ X0_v18 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv111 = v110 == 0;\n\tv112 = ~v111;\n\tgoto L_004C;\n\tv164 = \"il2cpp_codegen_runtime_class_init\"(v105, v55, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv114 = Firebase.Platform.FirebaseHandler;\nL_004C:\n\tthis.lastGetPropertyTickCount = v117.tickCount;\n\tSystem.Threading.Monitor::Exit(this.getPropertyDelegate);\nL_004E:\n\treturnVal2 = v178 & 1;\n\treturn returnVal2;\nL_0058:\n\tv57 = new System.NullReferenceException();\n\tv74 = v89 != 1;\n\tif (v74) goto L_0070;\n\tv86 = 0x6D2BC0(v57, v89, v87, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv109 = 0x6D2490(v86, v89, v87, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tSystem.Threading.Monitor::Exit(0x2024000);\n\tv94 = *([v86 @ X0_v6]) == 0;\n\tif (v94) goto L_004E;\n\tv92 = new System.TypeLoadException();\nL_0070:\n\treturnVal1 = 0x6D2380(v57, 0, 0, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\treturn returnVal1;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")] () =>
				{
					//IL_00a7: Expected O, but got I4
					//IL_004c: Expected O, but got I
					//IL_0138: Expected I, but got O
					IntPtr intPtr4;
					if (getPropertyDelegate == null)
					{
						NullReferenceException ex2 = new NullReferenceException();
						IntPtr intPtr3 = default(IntPtr);
						if (intPtr3 == (IntPtr)1)
						{
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
							Monitor.Exit(33701888);
							object obj4 = default(object);
							bool flag8 = obj4 == null;
							intPtr4 = intPtr3;
							if (flag8)
							{
								goto IL_003d;
							}
							TypeLoadException ex3 = new TypeLoadException();
							ex2 = (NullReferenceException)(object)ex3;
						}
						Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
						T result2 = default(T);
						return result2;
					}
					T val = getPropertyDelegate();
					Monitor.Enter(getPropertyDelegate);
					int num2 = (int)((long)(IntPtr)val & 1L);
					lastGetPropertyTickCount = FirebaseHandler.tickCount;
					Monitor.Exit(getPropertyDelegate);
					intPtr4 = (IntPtr)val;
					goto IL_003d;
					IL_003d:
					return (T)((long)intPtr4 & 1L);
				};
				Task task = FirebaseHandler.RunOnMainThreadAsync(f);
				if (!task.IsCompleted)
				{
					Func<T> func = null;
					while (!task.IsFaulted)
					{
						bool isCanceled = task.IsCanceled;
						if ((long)(IntPtr)func > 99L || isCanceled)
						{
							break;
						}
						Thread.Sleep(1);
						func = (Func<T>)((long)(IntPtr)func + 1L);
						if (task.IsCompleted)
						{
							break;
						}
					}
				}
				bool isFaulted = task.IsFaulted;
				bool flag4 = !isFaulted;
				bool flag5 = !flag4;
				Func<T> func2 = (Func<T>)33701888;
				if (!flag5)
				{
					if (!task.IsCompleted || task.IsCanceled)
					{
						func2 = getPropertyDelegate;
						Monitor.Enter(getPropertyDelegate);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Firebase.Platform.MainThreadProperty`1<T>)+1C]");
						bool flag6 = (IntPtr)0 == (IntPtr)0;
						bool flag7 = !flag6;
						lastGetPropertyTickCount = FirebaseHandler.tickCount;
						obj = 222;
						int num = 0;
						flag3 = flag7;
						IntPtr intPtr = (IntPtr)null;
						Monitor.Exit(func2);
						if (num + 1 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X25_v1+v136 @ X26_v1 (System.Int32)*4]");
							if ((IntPtr)0 == (IntPtr)222)
							{
								goto IL_004d;
							}
						}
						if (intPtr != (IntPtr)0)
						{
							TypeLoadException ex = (TypeLoadException)(object)new Func<T>(null, (IntPtr)0);
							T result = default(T);
							return result;
						}
					}
					IntPtr intPtr2 = (IntPtr)0;
					object obj3 = (long)intPtr2;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v199 @ X2_v7 (should have been resolved before IL gen)");
				}
				AggregateException exception = task.Exception;
				throw new TypeLoadException();
				IL_004d:
				return (T)flag3;
			}
		}

		[Token(Token = "0x60000B2")]
		[Address(RVA = "0xD94264", Offset = "0xD94264", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.lastGetPropertyTickCount = 0xFFFFFFFF;\n\tSystem.Object::.ctor(this);\n\tthis.getPropertyDelegate = getPropertyDelegate;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MainThreadProperty(Func<T> getPropertyDelegate)
		{
			this.getPropertyDelegate = getPropertyDelegate;
		}
	}
}
