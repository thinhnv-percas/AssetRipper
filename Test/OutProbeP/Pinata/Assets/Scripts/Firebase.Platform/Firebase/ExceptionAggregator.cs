using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Firebase.Platform;

namespace Firebase
{
	[Token(Token = "0x2000019")]
	internal class ExceptionAggregator
	{
		[ThreadStatic]
		[Token(Token = "0x400003B")]
		private static List<Exception> threadLocalExceptions;

		[Token(Token = "0x1700001E")]
		private static List<Exception> Exceptions
		{
			[Token(Token = "0x600007A")]
			[Address(RVA = "0x15E50E4", Offset = "0x15E50E4", Length = "0x90")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EF13E0]);\n\tv17 = *([v16 @ X8_v10]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2029F47]) = v37;\nL_0015:\n\tv41 = System.Collections.Generic.List`1<System.Exception>::.ctor(Firebase.ExceptionAggregator);\n\tv43 = *([v41 @ X0_v3 (System.Collections.Generic.List`1<System.Exception>)]) == 0;\n\tv44 = ~v43;\n\tif (v44) goto L_0027;\n\tv48 = new System.Collections.Generic.List`1<System.Exception>();\n\tSystem.Collections.Generic.List`1<System.Exception>::.ctor(v48);\n\tv52 = System.Collections.Generic.List`1<System.Exception>::.ctor(Firebase.ExceptionAggregator);\n\t*([v52 @ X0_v11 (System.Collections.Generic.List`1<System.Exception>)]) = v48;\nL_0027:\n\tv58 = System.Collections.Generic.List`1<System.Exception>::.ctor(Firebase.ExceptionAggregator);\n\treturn *([v58 @ X0_v6 (System.Collections.Generic.List`1<System.Exception>)]);\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				List<Exception> list = default(List<Exception>);
				if (list == null)
				{
					List<Exception> list2 = new List<Exception>();
					List<Exception> list3 = list2;
				}
				List<Exception> result = default(List<Exception>);
				return result;
			}
		}

		[Token(Token = "0x600007B")]
		[Address(RVA = "0x15E5174", Offset = "0x15E5174", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EE5A18]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2029F48]) = v39;\nL_0013:\n\tv40 = Firebase.ExceptionAggregator::get_Exceptions();\n\tv53 = v40._size != 1;\n\tif (v53) goto L_002F;\n\tv55 = v40._items;\n\tv73 = v55[0];\n\tgoto L_0046;\nL_002F:\n\tv66 = v40._size >= 2;\n\tif (v66) goto L_0037;\n\tgoto L_0046;\nL_0037:\n\tv97 = System.Collections.Generic.List`1<System.Exception>::ToArray(v40);\n\tv86 = new System.AggregateException();\n\tSystem.AggregateException::.ctor(v86, v97);\nL_0046:\n\tSystem.Collections.Generic.List`1<System.Exception>::Clear(v40);\n\treturn v73;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Exception GetAndClearPendingExceptions()
		{
			List<Exception> exceptions = Exceptions;
			Exception result;
			if (exceptions.Count == 1)
			{
				Exception[] items = exceptions._items;
				result = items[0];
			}
			else if (exceptions.Count < 2)
			{
				result = null;
			}
			else
			{
				Exception[] innerExceptions = exceptions.ToArray();
				AggregateException ex = new AggregateException((IEnumerable<Exception>)innerExceptions);
				result = ex;
			}
			exceptions.Clear();
			return result;
		}

		[Token(Token = "0x600007C")]
		[Address(RVA = "0x15E5244", Offset = "0x15E5244", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = *([1F0ACF0]);\n\tv15 = *([v14 @ X8_v7]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029F49]) = v35;\nL_0011:\n\tv36 = Firebase.ExceptionAggregator::GetAndClearPendingExceptions();\n\tv37 = v36 == 0;\n\tv38 = ~v37;\n\tif (v38) goto L_001A;\n\treturn;\nL_001A:\n\tv42 = Firebase.ExceptionAggregator::LogException(v36);\n\tthrow System.TypeLoadException;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ThrowAndClearPendingExceptions()
		{
			Exception andClearPendingExceptions = GetAndClearPendingExceptions();
			if (andClearPendingExceptions == null)
			{
				return;
			}
			Exception ex = LogException(andClearPendingExceptions);
			throw new TypeLoadException();
		}

		[Token(Token = "0x600007D")]
		[Address(RVA = "0x15E52A0", Offset = "0x15E52A0", Length = "0x348")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EFE980]);\n\tv27 = *([v26 @ X8_v42]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2029F4A]) = v46;\nL_0017:\n\tv47 = exception == 0;\n\tif (v47) goto L_0057;\n\tgoto L_FFFFFFFF;\n\tv143 = v143_asT != 0;\n\tif (v143) goto L_005B;\n\tv240 = System.Exception::ToString(exception);\nL_0043:\n\tgoto L_004C;\n\tv255 = *([v123 @ X8_v8+E0]);\n\tv256 = v255 == 0;\n\tv257 = ~v256;\n\tgoto L_004C;\n\tv263 = v123;\n\tv259 = \"il2cpp_codegen_runtime_class_init\"(v263, v224, v68, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_004C:\n\tFirebase.Platform.FirebaseLogger::LogMessage(4, v240);\nL_0057:\n\treturn exception;\nL_005B:\n\tv217 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v217);\n\tv262 = System.AggregateException::Flatten(exception);\n\tv264 = v262 == 0;\n\tif (v264) goto L_00E9;\n\tv266 = v262.m_innerExceptions == 0;\n\tif (v266) goto L_00E9;\n\tv317 = System.Collections.ObjectModel.ReadOnlyCollection`1<System.Exception>::GetEnumerator(v262.m_innerExceptions);\nL_007A:\n\tgoto L_00A1;\n\tv385 = *([v377 @ X8_v31+B0]);\n\tv386 = 0;\n\tv387 = v385 + 8;\n\tv389 = *([v454 @ X11_v29-8]);\n\tv459 = v389 == v378;\n\tif (v459) goto L_009A;\n\tv409 = v453 + 1;\n\tv545 = v409 < v379;\n\tv407 = ~v545;\n\tv411 = v454 + 0x10;\n\tv391 = ~v407;\n\tif (v391) goto L_FFFFFFFF;\n\tv412 = v276;\n\tv413 = 0;\n\tv414 = 0x8909C4(v412, v378, v413, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_00A1;\nL_009A:\n\tv546 = *([v454 @ X11_v29]);\n\tv547 = v546 << 4;\n\tv548 = v377 + v547;\n\tv549 = v548 + 0x130;\nL_00A1:\n\tv506 = System.Collections.IEnumerator::MoveNext(v317);\n\tv554 = v506 == 0;\n\tif (v554) goto L_00E0;\n\tgoto L_00D0;\n\tv625 = *([v588 @ X8_v34+B0]);\n\tv626 = 0;\n\tv627 = v625 + 8;\n\tv629 = *([v677 @ X11_v24-8]);\n\tv682 = v629 == v589;\n\tif (v682) goto L_00C9;\n\tv649 = v676 + 1;\n\tv687 = v649 < v590;\n\tv647 = ~v687;\n\tv651 = v677 + 0x10;\n\tv631 = ~v647;\n\tif (v631) goto L_FFFFFFFF;\n\tv652 = v276;\n\tv653 = 0;\n\tv654 = 0x8909C4(v652, v589, v653, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_00D0;\nL_00C9:\n\tv688 = *([v677 @ X11_v24]);\n\tv689 = v688 << 4;\n\tv690 = v588 + v689;\n\tv691 = v690 + 0x130;\nL_00D0:\n\tv435 = System.Collections.Generic.IEnumerator`1<System.Exception>::get_Current(v317);\n\tv465 = System.Exception::ToString(v435);\n\tSystem.Collections.Generic.List`1<System.String>::Add(v217, v465);\n\tgoto L_007A;\nL_00E0:\n\tv592 = v317 == 0;\n\tv508 = ~v592;\n\tif (v508) goto L_0107;\n\tgoto L_012F;\n\tv382 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tv308 = new System.NullReferenceException();\nL_00E9:\n\tv373 = new System.NullReferenceException();\n\tgoto L_00F9;\n\tgoto L_00F9;\n\tgoto L_00F9;\n\tgoto L_00F9;\n\tgoto L_00F9;\n\tgoto L_00F9;\nL_00F9:\n\tv330 = 0 != 1;\n\tif (v330) goto L_014E;\n\tv370 = 0x6D2BC0(v373, 0, v68, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv475 = *([v370 @ X0_v36]);\n\tv384 = 0x6D2490(v370, 0, v68, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv442 = v474 == 0;\n\tif (v442) goto L_012F;\nL_0107:\n\tgoto L_012E;\n\tv555 = *([v512 @ X8_v21+B0]);\n\tv556 = 0;\n\tv557 = v555 + 8;\n\tv559 = *([v604 @ X11_v13-8]);\n\tv609 = v559 == v515;\n\tif (v609) goto L_0127;\n\tv579 = v603 + 1;\n\tv655 = v579 < v514;\n\tv577 = ~v655;\n\tv581 = v604 + 0x10;\n\tv561 = ~v577;\n\tif (v561) goto L_FFFFFFFF;\n\tv582 = v474;\n\tv583 = 0;\n\tv584 = 0x8909C4(v582, v515, v583, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_012E;\nL_0127:\n\tv656 = *([v604 @ X11_v13]);\n\tv657 = v656 << 4;\n\tv658 = v512 + v657;\n\tv659 = v658 + 0x130;\nL_012E:\n\tSystem.IDisposable::Dispose(v474);\nL_012F:\n\tv544 = v220 + 1;\n\tv232 = v544 == 0;\n\tv227 = ~v232;\n\tif (v227) goto L_013F;\n\tv585 = v223 == 0;\n\tv586 = ~v585;\n\tif (v586) goto L_014B;\nL_013F:\n\tv622 = System.Collections.Generic.List`1<System.String>::ToArray(v217);\n\tv240 = System.String::Join(\"\\n\\n\", v622);\n\tgoto L_0043;\nL_014B:\n\tthrow System.TypeLoadException;\n\tv374 = new System.NullReferenceException();\nL_014E:\n\treturnVal2 = 0x6D2380(v373, 0, v68, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\treturn returnVal2;\n// 201 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Exception LogException(Exception exception)
		{
			//IL_01b0: Expected I4, but got O
			//IL_01ed: Expected I4, but got O
			if (exception == null)
			{
				goto IL_005c;
			}
			AggregateException ex = exception as AggregateException;
			string message;
			if (ex == null)
			{
				message = exception.ToString();
				goto IL_0049;
			}
			List<string> list = new List<string>();
			AggregateException ex2 = ((AggregateException)exception).Flatten();
			bool flag = ex2 == null;
			IEnumerator<Exception> enumerator2 = default(IEnumerator<Exception>);
			IEnumerator<Exception> enumerator = enumerator2;
			int num;
			int num2;
			int num3;
			int num4;
			if (!flag)
			{
				bool flag2 = ex2.InnerExceptions == null;
				IEnumerator<Exception> enumerator3 = default(IEnumerator<Exception>);
				enumerator = enumerator3;
				if (!flag2)
				{
					enumerator2 = ex2.InnerExceptions.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						Exception current = enumerator2.Current;
						string item = current.ToString();
						list.Add(item);
					}
					bool flag3 = enumerator2 == null;
					bool flag4 = !flag3;
					num = 0;
					enumerator = enumerator2;
					num2 = 0;
					if (!flag4)
					{
						num3 = 0;
						num4 = 0;
						goto IL_02c4;
					}
					goto IL_02fa;
				}
			}
			NullReferenceException ex3 = new NullReferenceException();
			if (0 == 1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj = default(object);
				num2 = (int)obj;
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				bool flag5 = enumerator == null;
				num = -1;
				num3 = -1;
				num4 = (int)obj;
				if (flag5)
				{
					goto IL_02c4;
				}
				goto IL_02fa;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			Exception result = default(Exception);
			return result;
			IL_005c:
			return exception;
			IL_02fa:
			enumerator.Dispose();
			num3 = num;
			num4 = num2;
			goto IL_02c4;
			IL_02c4:
			if (num3 + 1 != 0 || num4 == 0)
			{
				string[] value = list.ToArray();
				message = string.Join("\n\n", value);
				goto IL_0049;
			}
			throw new TypeLoadException();
			IL_0049:
			FirebaseLogger.LogMessage(PlatformLogLevel.Error, message);
			goto IL_005c;
		}

		[Token(Token = "0x600007E")]
		[Address(RVA = "0x15E4FF8", Offset = "0x15E4FF8", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EB7A38]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029F4B]) = v38;\nL_0013:\n\tv39 = action == 0;\n\tif (v39) goto L_001F;\n\tSystem.Action::Invoke(action);\n\treturn;\nL_001F:\n\tv43 = new System.NullReferenceException();\n\tv58 = v84 != 1;\n\tif (v58) goto L_0053;\n\tv103 = 0x6D2BC0(v43, v84, v104, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv115 = *([v103 @ X0_v9]);\n\tv105 = *([v115 @ X19_v4 (System.Exception)]);\n\tv119 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v115 @ X19_v4 (System.Exception)]), v104, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv120 = v119 & 1;\n\tv121 = v120 == 0;\n\tif (v121) goto L_0048;\n\tv122 = 0x6D2490(v119, v105, v104, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv86 = Firebase.ExceptionAggregator::get_Exceptions();\n\tv89 = v86 == 0;\n\tif (v89) goto L_004F;\n\tSystem.Collections.Generic.List`1<System.Exception>::Add(v86, v115);\n\treturn;\nL_0048:\n\tv124 = 0x6D1E60(8, *([v115 @ X19_v4 (System.Exception)]), v104, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\t*([v124 @ X0_v16]) = *([v103 @ X0_v9]);\n\tv105 = 0x1E8A000 + 0x870;\n\tv129 = 0x6D2A00(v124, v105, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_004F:\n\tv131 = new System.NullReferenceException();\n\tv107 = 0x6D2490(v131, v105, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0053:\n\tv113 = 0x6D2380(v93, v105, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv87 = 0x846AA4(v113, v105, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Wrap(Action action)
		{
			//IL_005f: Expected I, but got O
			if (action != null)
			{
				action();
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			IntPtr intPtr = default(IntPtr);
			bool flag = intPtr != (IntPtr)1;
			NullReferenceException ex2 = ex;
			if (!flag)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj = default(object);
				Exception ex3 = (Exception)obj;
				IntPtr intPtr2 = (IntPtr)ex3;
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				object obj2 = default(object);
				if ((uint)((ulong)(long)(IntPtr)obj2 & 1uL) != 0)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
					List<Exception> exceptions = Exceptions;
					if (exceptions != null)
					{
						exceptions.Add(ex3);
						return;
					}
				}
				else
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @6D1E60 (native __cxa_allocate_exception)");
					object obj3 = obj;
					intPtr2 = (IntPtr)(32022528 + 2160);
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @6D2A00 (native __cxa_throw)");
				}
				NullReferenceException ex4 = new NullReferenceException();
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				ex2 = ex4;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
		}
	}
}
