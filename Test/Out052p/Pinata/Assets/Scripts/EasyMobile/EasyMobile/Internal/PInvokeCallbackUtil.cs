using System;
using System.Collections;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal
{
	[Token(Token = "0x20000C8")]
	internal static class PInvokeCallbackUtil
	{
		[Token(Token = "0x20001B1")]
		internal enum Type
		{
			[Token(Token = "0x4000690")]
			Permanent = 0,
			[Token(Token = "0x4000691")]
			Temporary = 1
		}

		[Token(Token = "0x40003B2")]
		private static readonly bool VERBOSE_DEBUG;

		[Token(Token = "0x600073E")]
		[Address(RVA = "0xBAC57C", Offset = "0xBAC57C", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1ED88B0]);\n\tv27 = *([v26 @ X8_v17]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, conversionFunction, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022C15]) = v44;\nL_001D:\n\tgoto L_0021;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, conversionFunction, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0021:\n\tv55 = new Il2CppClass<EasyMobile.Internal.PInvokeCallbackUtil+<>c__DisplayClass1_0`1<T>>();\n\tv60 = EasyMobile.Internal.PInvokeCallbackUtil+<>c__DisplayClass1_0`1<T>::.ctor(v55);\n\tv55.conversionFunction = conversionFunction;\n\tv55.callback = callback;\n\tv65 = new System.Action`1<System.IntPtr>();\n\tSystem.Action`1<System.IntPtr>::.ctor(v65, v55, Il2CppMethodInfo);\n\tgoto L_004B;\n\tv104 = *([v77 @ X0_v10+E0]);\n\tv105 = v104 == 0;\n\tv106 = ~v105;\n\tif (v106) goto L_004B;\n\tv108 = \"il2cpp_codegen_runtime_class_init\"(v77, v71, v73, v74, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_004B:\n\treturnVal2 = EasyMobile.Internal.PInvokeCallbackUtil::ToIntPtr /* +1 sharing this address */(v65, v55);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static IntPtr ToIntPtr<T>(Action<T> callback, Func<IntPtr, T> conversionFunction) where T : InteropObject
		{
			Action<IntPtr> action = delegate(IntPtr arg)
			{
				T val = conversionFunction(arg);
				if (callback != null)
				{
					callback(val);
				}
				bool flag = (object)val == null;
				IDisposable disposable = val;
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				if (!flag)
				{
					disposable.Dispose();
					num3 = num;
					num4 = num2;
				}
				if (num3 + 1 == 0 && num4 != 0)
				{
					TypeLoadException ex = new TypeLoadException();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
				}
			};
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BAC1E4 (EasyMobile.Internal.PInvokeCallbackUtil::ToIntPtr, and 1 more at this address)");
			IntPtr result = default(IntPtr);
			return result;
		}

		[Token(Token = "0x600073F")]
		[Address(RVA = "0xBAC2B4", Offset = "0xBAC2B4", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1ED6258]);\n\tv27 = *([v26 @ X8_v18]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, conversionFunction, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022C11]) = v44;\nL_001D:\n\tgoto L_0021;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, conversionFunction, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0021:\n\tv55 = new Il2CppClass<EasyMobile.Internal.PInvokeCallbackUtil+<>c__DisplayClass2_0`2<T, P>>();\n\tv60 = EasyMobile.Internal.PInvokeCallbackUtil+<>c__DisplayClass2_0`2<T, P>::.ctor(v55);\n\tv55.conversionFunction = conversionFunction;\n\tv55.callback = callback;\n\tgoto L_0035;\n\tv70 = v63;\n\tv71 = 0x8907BC(v70, v58, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0035:\n\tv74 = new Il2CppClass<System.Action`2<System.IntPtr, P>>();\n\tv81 = System.Action`2<System.IntPtr, P>::.ctor(v74, v55, Il2CppMethodInfo);\n\tgoto L_004F;\n\tv113 = *([v84 @ X0_v12+E0]);\n\tv114 = v113 == 0;\n\tv115 = ~v114;\n\tif (v115) goto L_004F;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v84, v76, v79, v78, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_004F:\n\tv96 = Il2CppMethodInfo;\n\tv93 = *([v96 @ X1_v3 (Il2CppMethodInfo)]);\n\t// 84 IndirectJump v93 @ X2_v2, v74 @ X0_v10 (System.Action`2<System.IntPtr, P>), v74 @ X0_v10 (System.Action`2<System.IntPtr, P>), methodof(EasyMobile.Internal.PInvokeCallbackUtil::ToIntPtr), v93 @ X2_v2, methodof(System.Action`2<System.IntPtr, P>::.ctor), v30 @ X4, v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static IntPtr ToIntPtr<T, P>(Action<T, P> callback, Func<IntPtr, T> conversionFunction) where T : InteropObject
		{
			//IL_005a: Expected O, but got I
			while (true)
			{
				Action<IntPtr, P> action = delegate(IntPtr param1, P param2)
				{
					T val = conversionFunction(param1);
					if (callback != null)
					{
						callback(val, param2);
					}
					bool flag = (object)val == null;
					IDisposable disposable = val;
					int num = 0;
					int num2 = 0;
					int num3 = 0;
					int num4 = 0;
					if (!flag)
					{
						disposable.Dispose();
						num3 = num;
						num4 = num2;
					}
					if (num4 + 1 == 0 && num3 != 0)
					{
						TypeLoadException ex = new TypeLoadException();
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
					}
				};
				IntPtr intPtr = (IntPtr)0;
				object obj = (long)intPtr;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v93 @ X2_v2 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000740")]
		[Address(RVA = "0xBAC3B4", Offset = "0xBAC3B4", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1EA6698]);\n\tv31 = *([v30 @ X8_v17]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, conversionFunctionT, conversionFunctionP, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2022C12]) = v47;\nL_001F:\n\tgoto L_0023;\n\tv54 = v49;\n\tv55 = 0x8907BC(v54, conversionFunctionT, conversionFunctionP, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0023:\n\tv58 = new Il2CppClass<EasyMobile.Internal.PInvokeCallbackUtil+<>c__DisplayClass3_0`2<T, P>>();\n\tv63 = EasyMobile.Internal.PInvokeCallbackUtil+<>c__DisplayClass3_0`2<T, P>::.ctor(v58);\n\tv58.conversionFunctionT = conversionFunctionT;\n\tv58.conversionFunctionP = conversionFunctionP;\n\tv58.callback = callback;\n\tv68 = new System.Action`2<System.IntPtr, System.IntPtr>();\n\tSystem.Action`2<System.IntPtr, System.IntPtr>::.ctor(v68, v58, Il2CppMethodInfo);\n\tgoto L_004F;\n\tv109 = *([v80 @ X0_v10+E0]);\n\tv110 = v109 == 0;\n\tv111 = ~v110;\n\tif (v111) goto L_004F;\n\tv113 = \"il2cpp_codegen_runtime_class_init\"(v80, v74, v76, v77, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_004F:\n\treturnVal2 = EasyMobile.Internal.PInvokeCallbackUtil::ToIntPtr /* +1 sharing this address */(v68, v58);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static IntPtr ToIntPtr<T, P>(Action<T, P> callback, Func<IntPtr, T> conversionFunctionT, Func<IntPtr, P> conversionFunctionP) where T : InteropObject where P : InteropObject
		{
			Action<IntPtr, IntPtr> action = delegate(IntPtr t, IntPtr p)
			{
				T val = conversionFunctionT(t);
				IDisposable disposable = conversionFunctionP(p);
				bool flag = callback == null;
				IntPtr intPtr2 = default(IntPtr);
				IntPtr intPtr = intPtr2;
				if (!flag)
				{
					callback(val, (P)disposable);
					intPtr = (IntPtr)0;
				}
				disposable?.Dispose();
				int num = 0;
				bool flag2 = (object)val == null;
				IDisposable disposable2 = val;
				int num2 = 0;
				int num3 = num;
				int num4 = 0;
				if (!flag2)
				{
					disposable2.Dispose();
					num3 = num;
					num4 = num2;
				}
				if (num3 + 1 != 0 || num4 == 0)
				{
					return;
				}
				throw new TypeLoadException();
			};
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BAC114 (EasyMobile.Internal.PInvokeCallbackUtil::ToIntPtr, and 1 more at this address)");
			IntPtr result = default(IntPtr);
			return result;
		}

		[Token(Token = "0x6000741")]
		[Address(RVA = "0xBAC114", Offset = "0xBAC114", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F04088]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022C0D]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = EasyMobile.Internal.PInvokeCallbackUtil::ToIntPtr(callback);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static IntPtr ToIntPtr<T, P>(Action<T, P> callback)
		{
			return ToIntPtr((Delegate)callback);
		}

		[Token(Token = "0x6000742")]
		[Address(RVA = "0xBAC1E4", Offset = "0xBAC1E4", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F06998]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022C0F]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = EasyMobile.Internal.PInvokeCallbackUtil::ToIntPtr(callback);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static IntPtr ToIntPtr<T>(Action<T> callback)
		{
			return ToIntPtr((Delegate)callback);
		}

		[Token(Token = "0x6000743")]
		[Address(RVA = "0xC05E28", Offset = "0xC05E28", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EBD0F8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022FE6]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\treturnVal1 = EasyMobile.Internal.PInvokeCallbackUtil::ToIntPtr(callback);\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static IntPtr ToIntPtr(Action callback)
		{
			return ToIntPtr((Delegate)callback);
		}

		[Token(Token = "0x6000744")]
		[Address(RVA = "0xBAC4AC", Offset = "0xBAC4AC", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F057A8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022C13]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = EasyMobile.Internal.PInvokeCallbackUtil::ToIntPtr(function);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static IntPtr ToIntPtr<T, P>(Func<T, P> function)
		{
			return ToIntPtr((Delegate)function);
		}

		[Token(Token = "0x6000745")]
		[Address(RVA = "0xC05E8C", Offset = "0xC05E8C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F0ABB0]);\n\tv19 = *([v18 @ X8_v4]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022FE7]) = v38;\nL_0013:\n\tv39 = callback == 0;\n\tif (v39) goto L_0027;\n\tv42 = System.Runtime.InteropServices.GCHandle::Alloc(callback);\n\tv50 = v42 & 0xFFFFFFFF;\n\treturnVal2 = System.Runtime.InteropServices.GCHandle::ToIntPtr(v50);\n\treturn returnVal2;\nL_0027:\n\treturn 0;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static IntPtr ToIntPtr(Delegate callback)
		{
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			if (callback != null)
			{
				GCHandle gCHandle = GCHandle.Alloc(callback);
				GCHandle value = (GCHandle)(gCHandle & 0xFFFFFFFFL);
				return GCHandle.ToIntPtr(value);
			}
			return (IntPtr)0;
		}

		[Token(Token = "0x6000746")]
		[Address(RVA = "0xB88250", Offset = "0xB88250", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1ED2BE8]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20229FC]) = v41;\nL_001B:\n\tgoto L_0027;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0027;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0027:\n\tv61 = Il2CppMethodInfo;\n\tv63 = *([v61 @ X2_v1 (Il2CppMethodInfo)]);\n\t// 44 IndirectJump v63 @ X3_v1, handle @ X0 (System.IntPtr), handle @ X0 (System.IntPtr), 1, methodof(EasyMobile.Internal.PInvokeCallbackUtil::IntPtrToCallback), v63 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\treturn X0;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static T IntPtrToTempCallback<T>(IntPtr handle) where T : class
		{
			//IL_0013: Expected O, but got I
			while (true)
			{
				IntPtr intPtr = (IntPtr)0;
				object obj = (long)intPtr;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v63 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000747")]
		[Address(RVA = "0xB881D0", Offset = "0xB881D0", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EBBCC0]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20229FB]) = v41;\nL_001B:\n\tgoto L_0027;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0027;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0027:\n\tv61 = Il2CppMethodInfo;\n\tv63 = *([v61 @ X2_v1 (Il2CppMethodInfo)]);\n\t// 44 IndirectJump v63 @ X3_v1, handle @ X0 (System.IntPtr), handle @ X0 (System.IntPtr), 0, methodof(EasyMobile.Internal.PInvokeCallbackUtil::IntPtrToCallback), v63 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\treturn X0;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static T IntPtrToPermanentCallback<T>(IntPtr handle) where T : class
		{
			//IL_0013: Expected O, but got I
			while (true)
			{
				IntPtr intPtr = (IntPtr)0;
				object obj = (long)intPtr;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v63 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000748")]
		[Address(RVA = "0xC05EF4", Offset = "0xC05EF4", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = EasyMobile.Internal.PInvokeUtil::IsNull(handle);\n\tv14 = v11 == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0017;\n\tv18 = System.Runtime.InteropServices.GCHandle::FromIntPtr(handle);\n\thandle = 0xF75014(&v18 @ X0_v4 (System.Runtime.InteropServices.GCHandle), 0, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0017:\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void UnpinCallbackHandle(IntPtr handle)
		{
			if (!PInvokeUtil.IsNull(handle))
			{
				GCHandle gCHandle = GCHandle.FromIntPtr(handle);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @F75014 (inside System.Runtime.InteropServices.GCHandle::Alloc +0x28)");
			}
		}

		[Token(Token = "0x6000749")]
		[Address(RVA = "0xB87DE0", Offset = "0xB87DE0", Length = "0x3F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1ED7928]);\n\tv29 = *([v28 @ X8_v51]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, unpinHandle, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20229FA]) = v46;\nL_001B:\n\tv50 = EasyMobile.Internal.PInvokeUtil::IsNull(handle);\n\tv53 = v50 == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_0055;\n\tv57 = System.Runtime.InteropServices.GCHandle::FromIntPtr(handle);\n\tv119 = 0xF74DF0(&v57 @ X0_v7 (System.Runtime.InteropServices.GCHandle), 0, v444, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_0032;\n\tv127 = v122;\n\tv128 = 0x8907BC(v127, v118, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0032:\n\tv130 = v119 == 0;\n\tif (v130) goto L_0059;\n\t// 54 IsInst v133 @ X0_v92 (T), typeof(T), v119 @ X0_v9 (System.Int32)\n\tv140 = v133 == 0;\n\tif (v140) goto L_0063;\n\tv170 = unpinHandle == 0;\n\tif (v170) goto L_0042;\nL_0041:\n\thandle = 0xF75014(&v57 @ X0_v7 (System.Runtime.InteropServices.GCHandle), 0, v444, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0042:\n\tv100 = v102 + 1;\n\tv85 = v100 == 0;\n\tv76 = ~v85;\n\tif (v76) goto L_0055;\n\tv217 = v487 == 0;\n\tv99 = ~v217;\n\tif (v99) goto L_FFFFFFFF;\nL_0055:\n\treturn v107;\nL_0059:\n\tv137 = unpinHandle == 0;\n\tv138 = ~v137;\n\tif (v138) goto L_0041;\n\tgoto L_0042;\n\tthrow System.TypeLoadException;\nL_0063:\n\tv210 = new System.InvalidCastException();\n\tgoto L_006B;\nL_006B:\n\tv224 = Il2CppClass<T> == 1;\n\tif (v224) goto L_0089;\nL_007C:\n\tv154 = Il2CppClass<T> != 1;\n\tif (v154) goto L_00A0;\n\thandle = 0x6D2BC0(v348, v166, v444, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv175 = *([handle @ X0 (System.IntPtr)]);\n\thandle = 0x6D2490(handle, v166, v444, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv325 = unpinHandle == 0;\n\tv171 = ~v325;\n\tif (v171) goto L_0041;\n\tgoto L_0042;\nL_0089:\n\tv267 = 0x6D2BC0(v210, Il2CppClass<T>, v444, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv293 = *([v267 @ X0_v73 (System.InvalidCastException)]);\n\tv166 = *([v293 @ X21_v11 (Il2CppClass<System.InvalidCastException>)]);\n\thandle = \"il2cpp_vm_class_is_assignable_from\"(System.InvalidCastException, *([v293 @ X21_v11 (Il2CppClass<System.InvalidCastException>)]), v444, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv323 = handle & 1;\n\tv316 = v323 == 0;\n\tif (v316) goto L_00A2;\n\thandle = 0x6D2490(handle, *([v293 @ X21_v11 (Il2CppClass<System.InvalidCastException>)]), v444, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\t// 153 NewArr v346 @ X0_v78 (System.Object[]), typeof(System.Object[]), 4\n\tv373 = v346 == 0;\n\tv286 = ~v373;\n\tif (v286) goto L_00AC;\n\tv284 = new System.NullReferenceException();\nL_00A0:\n\thandle = 0x6D2380(handle, v166, v444, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00A2:\n\thandle = 0x6D1E60(8, v166, v444, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\t*([handle @ X0 (System.IntPtr)]) = *([v348 @ X22_v7 (System.InvalidCastException)]);\n\tv328 = 0x1E8A000 + 0x870;\n\thandle = 0x6D2A00(handle, v328, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00AC:\n\tv355 = \"GC Handle pointed to unexpected type: \" == 0;\n\tif (v355) goto L_00B9;\n\tv358 = *([v348 @ X22_v7 (System.InvalidCastException)]);\n\thandle = \"il2cpp_codegen_object_is_inst\"(\"GC Handle pointed to unexpected type: \", *([v358 @ X8_v38 (Il2CppClass<System.InvalidCastException>)+40]), v444, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv374 = handle == 0;\n\tv368 = ~v374;\n\tif (v368) goto L_00B9;\n\tv387 = new System.ArrayTypeMismatchException();\n\tthrow v387;\nL_00B9:\n\tv371 = v348._message == 0;\n\tv372 = ~v371;\n\tif (v372) goto L_00C1;\n\tv375 = new System.IndexOutOfRangeException();\n\tthrow v375;\nL_00C1:\n\tv348._data = \"GC Handle pointed to unexpected type: \";\n\tv391 = 0xF74DF0(&v57 @ X0_v7 (System.Runtime.InteropServices.GCHandle), 0, v444, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv388 = v391 == 0;\n\tv389 = ~v388;\n\tif (v389) goto L_00CC;\n\tv391 = new System.NullReferenceException();\nL_00CC:\n\tv395 = System.Exception::ToString(v391);\n\tv397 = v395 == 0;\n\tif (v397) goto L_00DB;\n\tv398 = *([v348 @ X22_v7 (System.InvalidCastException)]);\n\thandle = \"il2cpp_codegen_object_is_inst\"(v395, *([v398 @ X8_v37 (Il2CppClass<System.InvalidCastException>)+40]), v444, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv423 = handle == 0;\n\tv409 = ~v423;\n\tif (v409) goto L_00DB;\n\tv440 = new System.ArrayTypeMismatchException();\n\tthrow v440;\nL_00DB:\n\tv452 = v348._message;\n\tv412 = v348._message < 1;\n\tv413 = ~v412;\n\tv414 = v348._message - 1;\n\tv416 = v414 == 0;\n\tv421 = ~v413;\n\tv422 = v421 | v416;\n\tif (v422) goto L_00F8;\n\tv348._innerException = v395;\n\tv427 = \". Expected \" == 0;\n\tif (v427) goto L_00FD;\n\tv438 = *([v348 @ X22_v7 (System.InvalidCastException)]);\n\thandle = \"il2cpp_codegen_object_is_inst\"(\". Expected \", *([v438 @ X8_v36 (Il2CppClass<System.InvalidCastException>)+40]), v444, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv468 = handle == 0;\n\tv436 = ~v468;\n\tif (v436) goto L_00FC;\n\tv493 = new System.ArrayTypeMismatchException();\n\tthrow v493;\nL_00F8:\n\tv439 = new System.IndexOutOfRangeException();\n\tthrow v439;\nL_00FC:\n\tv452 = v348._message;\nL_00FD:\n\tv454 = v452 < 2;\n\tv455 = ~v454;\n\tv456 = v452 - 2;\n\tv458 = v456 == 0;\n\tv463 = ~v455;\n\tv464 = v463 | v458;\n\tif (v464) goto L_012A;\n\tv348._helpURL = *([v250 @ X23_v9 (System.String)]);\n\tgoto L_011B;\n\tv494 = *([v472 @ X0_v39+E0]);\n\tv495 = v494 == 0;\n\tv496 = ~v495;\n\tif (v496) goto L_011B;\n\tv498 = \"il2cpp_codegen_runtime_class_init\"(v472, v446, v443, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_011B:\n\tv503 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tv507 = v503 == 0;\n\tif (v507) goto L_012F;\n\tv490 = *([v348 @ X22_v7 (System.InvalidCastException)]);\n\thandle = \"il2cpp_codegen_object_is_inst\"(v503, *([v490 @ X8_v31 (Il2CppClass<System.InvalidCastException>)+40]), v444, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv533 = handle == 0;\n\tv486 = ~v533;\n\tif (v486) goto L_012F;\n\tv540 = new System.ArrayTypeMismatchException();\n\tthrow v540;\nL_012A:\n\tv491 = new System.IndexOutOfRangeException();\n\tthrow v491;\nL_012F:\n\tv517 = v348._message < 3;\n\tv245 = ~v517;\n\tv238 = v348._message - 3;\n\tv247 = v238 == 0;\n\tv518 = ~v245;\n\tv241 = v518 | v247;\n\tif (v241) goto L_0155;\n\tv348._stackTrace = v514;\n\tv522 = System.String::Concat(v348);\n\tgoto L_014E;\n\tv541 = *([v536 @ X0_v30+E0]);\n\tv542 = v541 == 0;\n\tv543 = ~v542;\n\tif (v543) goto L_014E;\n\tv545 = \"il2cpp_codegen_runtime_class_init\"(v536, v521, v508, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_014E:\n\tUnityEngine.Debug::LogError(v522);\n\tv528 = new System.TypeLoadException();\nL_0155:\n\tv532 = new System.IndexOutOfRangeException();\n\tthrow v532;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_007C;\n\tX21 = X1;\n\tX22 = X0;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_007C;\n\tX0 = 0x846AA4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 184 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static T IntPtrToCallback<T>(IntPtr handle, bool unpinHandle) where T : class
		{
			//IL_0172: Expected I, but got O
			//IL_004c: Expected O, but got I4
			//IL_0193: Expected I, but got O
			//IL_0093: Expected I, but got O
			//IL_00aa: Expected I, but got O
			//IL_0289: Expected I, but got O
			//IL_01a2: Expected I, but got O
			//IL_01f7: Expected I, but got O
			//IL_0368: Expected I, but got O
			//IL_0386: Expected I, but got O
			//IL_03b1: Expected I, but got O
			//IL_0431: Expected I, but got O
			//IL_033a: Expected I, but got O
			//IL_053b: Expected O, but got I
			//IL_03f1: Expected I, but got O
			//IL_0614: Expected I, but got O
			//IL_04b6: Expected I, but got O
			//IL_07dd: Expected O, but got I
			//IL_04f6: Expected I, but got O
			//IL_05b4: Expected I, but got O
			//IL_0701: Expected O, but got I
			//IL_0678: Expected I, but got O
			bool flag = PInvokeUtil.IsNull(handle);
			bool flag2 = !flag;
			bool flag3 = !flag2;
			T result = null;
			InvalidCastException ex2;
			IntPtr intPtr5;
			int num2;
			T val2;
			int num3;
			IntPtr intPtr;
			IntPtr intPtr4;
			IntPtr intPtr2 = default(IntPtr);
			if (!flag3)
			{
				GCHandle gCHandle = GCHandle.FromIntPtr(handle);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @F74DF0 (inside System.Runtime.InteropServices.GCHandle::GetTargetHandle +0x14)");
				int num = default(int);
				if (num != 0)
				{
					T val = num as T;
					bool flag4 = val == null;
					intPtr = intPtr2;
					if (flag4)
					{
						InvalidCastException ex = new InvalidCastException();
						bool flag5 = (IntPtr)0 == (IntPtr)1;
						IntPtr intPtr3 = (IntPtr)0;
						ex2 = ex;
						if (!flag5)
						{
							bool flag6 = (IntPtr)0 != (IntPtr)1;
							intPtr4 = (IntPtr)ex2;
							if (!flag6)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
								intPtr5 = handle;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
								bool flag7 = !unpinHandle;
								bool flag8 = !flag7;
								num2 = -1;
								val2 = null;
								if (flag8)
								{
									goto IL_00c0;
								}
								num3 = -1;
								intPtr = handle;
								result = null;
								goto IL_00e7;
							}
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
							InvalidCastException ex3 = default(InvalidCastException);
							IntPtr intPtr6 = (IntPtr)ex3;
							intPtr3 = intPtr6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
							int num4 = (int)((long)handle & 1L);
							bool flag9 = num4 == 0;
							ex2 = ex3;
							if (flag9)
							{
								goto IL_0356;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
							object[] array = new object[4];
							bool flag10 = array == null;
							bool flag11 = !flag10;
							ex2 = (InvalidCastException)(object)array;
							if (flag11)
							{
								goto IL_038b;
							}
							NullReferenceException ex4 = new NullReferenceException();
							intPtr3 = (IntPtr)4;
							intPtr4 = (IntPtr)ex4;
							ex2 = (InvalidCastException)(object)array;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
						goto IL_0356;
					}
					bool flag12 = !unpinHandle;
					num2 = 0;
					intPtr5 = (IntPtr)null;
					val2 = val;
					num3 = 0;
					intPtr = (IntPtr)null;
					result = val;
					if (!flag12)
					{
						goto IL_00c0;
					}
				}
				else
				{
					bool flag13 = !unpinHandle;
					bool flag14 = !flag13;
					num2 = num;
					intPtr5 = (IntPtr)null;
					val2 = null;
					if (flag14)
					{
						goto IL_00c0;
					}
					num3 = num;
					intPtr = (IntPtr)null;
					result = null;
				}
				goto IL_00e7;
			}
			goto IL_0145;
			IL_00e7:
			if (num3 + 1 != 0 || intPtr == (IntPtr)0)
			{
				goto IL_0145;
			}
			intPtr2 = (IntPtr)null;
			throw new TypeLoadException();
			IL_038b:
			if ("GC Handle pointed to unexpected type: " != null)
			{
				IntPtr intPtr7 = (IntPtr)ex2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_codegen_object_is_inst\"");
				if (handle == (IntPtr)0)
				{
					ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
					intPtr2 = (IntPtr)null;
					throw ex5;
				}
			}
			if (((Exception)ex2)._message == null)
			{
				IndexOutOfRangeException ex6 = new IndexOutOfRangeException();
				intPtr2 = (IntPtr)null;
				throw ex6;
			}
			((Exception)ex2)._data = (IDictionary)(object)"GC Handle pointed to unexpected type: ";
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @F74DF0 (inside System.Runtime.InteropServices.GCHandle::GetTargetHandle +0x14)");
			NullReferenceException ex7 = default(NullReferenceException);
			if (ex7 == null)
			{
				ex7 = new NullReferenceException();
			}
			string text = ex7.ToString();
			if (text != null)
			{
				IntPtr intPtr8 = (IntPtr)ex2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_codegen_object_is_inst\"");
				if (handle == (IntPtr)0)
				{
					ArrayTypeMismatchException ex8 = new ArrayTypeMismatchException();
					intPtr2 = (IntPtr)null;
					throw ex8;
				}
			}
			string message = ((Exception)ex2)._message;
			bool flag15 = (long)(IntPtr)((Exception)ex2)._message < 1L;
			bool flag16 = !flag15;
			object obj = (long)(IntPtr)((Exception)ex2)._message - 1L;
			bool flag17 = obj == null;
			bool flag18 = !flag16;
			bool flag19 = flag18 || flag17;
			string text2 = text;
			if (!flag19)
			{
				((Exception)ex2)._innerException = (Exception)(object)text;
				bool flag20 = ". Expected " == null;
				text2 = ". Expected ";
				if (!flag20)
				{
					IntPtr intPtr9 = (IntPtr)ex2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_codegen_object_is_inst\"");
					bool flag21 = handle == (IntPtr)0;
					bool flag22 = !flag21;
					text2 = ". Expected ";
					if (!flag22)
					{
						ArrayTypeMismatchException ex9 = new ArrayTypeMismatchException();
						text2 = ". Expected ";
						throw ex9;
					}
					message = ((Exception)ex2)._message;
				}
				bool flag23 = (long)(IntPtr)message < 2L;
				bool flag24 = !flag23;
				object obj2 = (long)(IntPtr)message - 2L;
				bool flag25 = obj2 == null;
				bool flag26 = !flag24;
				if (!(flag26 || flag25))
				{
					((Exception)ex2)._helpURL = text2;
					System.Type typeFromHandle = typeof(T);
					bool flag27 = (object)typeFromHandle == null;
					object stackTrace = typeFromHandle;
					if (!flag27)
					{
						IntPtr intPtr10 = (IntPtr)ex2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_codegen_object_is_inst\"");
						bool flag28 = handle == (IntPtr)0;
						bool flag29 = !flag28;
						stackTrace = typeFromHandle;
						if (!flag29)
						{
							ArrayTypeMismatchException ex10 = new ArrayTypeMismatchException();
							throw ex10;
						}
					}
					bool flag30 = (long)(IntPtr)((Exception)ex2)._message < 3L;
					bool flag31 = !flag30;
					object obj3 = (long)(IntPtr)((Exception)ex2)._message - 3L;
					bool flag32 = obj3 == null;
					bool flag33 = !flag31;
					if (!(flag33 || flag32))
					{
						((Exception)ex2)._stackTrace = stackTrace;
						string message2 = string.Concat((object[])(object)ex2);
						Debug.LogError(message2);
						TypeLoadException ex11 = new TypeLoadException();
					}
					IndexOutOfRangeException ex12 = new IndexOutOfRangeException();
					throw ex12;
				}
				IndexOutOfRangeException ex13 = new IndexOutOfRangeException();
				throw ex13;
			}
			IndexOutOfRangeException ex14 = new IndexOutOfRangeException();
			intPtr2 = (IntPtr)null;
			throw ex14;
			IL_0145:
			return result;
			IL_00c0:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @F75014 (inside System.Runtime.InteropServices.GCHandle::Alloc +0x28)");
			num3 = num2;
			intPtr = intPtr5;
			result = val2;
			goto IL_00e7;
			IL_0356:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
			intPtr4 = (IntPtr)ex2;
			int num5 = 32022528 + 2160;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2A00 (native __cxa_throw)");
			intPtr2 = (IntPtr)null;
			goto IL_038b;
		}

		[Token(Token = "0x600074A")]
		[Address(RVA = "0xC05F54", Offset = "0xC05F54", Length = "0x35C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv28 = *([1ED2880]);\n\tv29 = *([v28 @ X8_v41]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, callbackType, callbackPtr, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2022FE8]) = v46;\nL_001E:\n\tgoto L_0027;\n\tv53 = *([v49 @ X0_v2 (Il2CppClass<EasyMobile.Internal.PInvokeCallbackUtil>)+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0027;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v49, callbackType, callbackPtr, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv57 = EasyMobile.Internal.PInvokeCallbackUtil;\nL_0027:\n\tv62 = ~v60.VERBOSE_DEBUG;\n\tif (v62) goto L_0042;\n\tv69 = System.String::Concat(\"Entering internal callback for \", callbackName);\n\tgoto L_003F;\n\tv95 = *([v81 @ X8_v38+E0]);\n\tv96 = v95 == 0;\n\tv97 = ~v96;\n\tif (v97) goto L_003F;\n\tv125 = v81;\n\tv99 = \"il2cpp_codegen_runtime_class_init\"(v125, v66, v67, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_003F:\n\tUnityEngine.Debug::Log(v69);\nL_0042:\n\tv85 = callbackType == 0;\n\tif (v85) goto L_0055;\n\tgoto L_0050;\n\tv101 = *([v76 @ X0_v4+E0]);\n\tv102 = v101 == 0;\n\tv103 = ~v102;\n\tif (v103) goto L_0050;\n\tv105 = \"il2cpp_codegen_runtime_class_init\"(v76, v74, v73, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0050:\n\tv112 = EasyMobile.Internal.PInvokeCallbackUtil::IntPtrToTempCallback(callbackPtr);\n\tgoto L_0065;\nL_0055:\n\tgoto L_005F;\n\tv113 = *([v76 @ X0_v4+E0]);\n\tv114 = v113 == 0;\n\tv115 = ~v114;\n\tif (v115) goto L_005F;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v76, v74, v73, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_005F:\n\tv124 = EasyMobile.Internal.PInvokeCallbackUtil::IntPtrToPermanentCallback(callbackPtr);\nL_0065:\n\tgoto L_006E;\n\tv137 = *([v133 @ X0_v6 (Il2CppClass<EasyMobile.Internal.PInvokeCallbackUtil>)+E0]);\n\tv138 = v137 == 0;\n\tv139 = ~v138;\n\tgoto L_006E;\n\tv147 = \"il2cpp_codegen_runtime_class_init\"(v133, v128, v73, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv141 = EasyMobile.Internal.PInvokeCallbackUtil;\nL_006E:\n\tv146 = ~v144.VERBOSE_DEBUG;\n\tif (v146) goto L_0085;\n\tgoto L_0080;\n\tv165 = *([v150 @ X0_v12+E0]);\n\tv166 = v165 == 0;\n\tv167 = ~v166;\n\tif (v167) goto L_0080;\n\tv169 = \"il2cpp_codegen_runtime_class_init\"(v150, v128, v73, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0080:\n\tUnityEngine.Debug::Log(\"Internal Callback converted to action\");\nL_0085:\n\tgoto L_0095;\n\tv173 = *([v156 @ X0_v8+E0]);\n\tv174 = v173 == 0;\n\tv175 = ~v174;\n\tgoto L_0095;\n\tv177 = \"il2cpp_codegen_runtime_class_init\"(v156, v154, v73, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0095:\n\tEasyMobile.Internal.PInvokeCallbackUtil::InvokeConvertedCallback(callbackName, v131);\n\treturn;\n\tgoto L_0098;\nL_0098:\n\tX20 = X0;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_013B;\n\tX0 = X20;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\n\tX20 = *([X21]);\n\tX8 = *([1EDD7C0]);\n\tX1 = *([X20]);\n\tX0 = *([X8]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0130;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EFE3C0]);\n\tX1 = 0 | 4;\n\tX0 = *([X8]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\n\tif (TEMP) goto L_0138;\n\tX22 = *([1F075F8]);\n\tX0 = *([X22]);\n\tif (TEMP) goto L_00C3;\n\tX8 = *([X21]);\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_012C;\nL_00C3:\n\tX8 = *([X21+18]);\n\tif (TEMP) goto L_012A;\n\tX9 = *([X22]);\n\t*([X21+20]) = X9;\n\tif (TEMP) goto L_00D1;\n\tX8 = *([X21]);\n\tX0 = X19;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_012C;\n\tX8 = *([X21+18]);\nL_00D1:\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_012A;\n\t*([X21+28]) = X19;\n\tX19 = *([1EDA590]);\n\tX0 = *([X19]);\n\tif (TEMP) goto L_00E9;\n\tX8 = *([X21]);\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_012C;\n\tX8 = *([X21+18]);\nL_00E9:\n\tC = X8 < 2;\n\tC = ~C;\n\tTEMP1 = X8 - 2;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 2;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_012A;\n\tX9 = *([X19]);\n\t*([X21+30]) = X9;\n\tif (TEMP) goto L_0100;\n\tX8 = *([X21]);\n\tX0 = X20;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_012C;\n\tX8 = *([X21+18]);\nL_0100:\n\tC = X8 < 3;\n\tC = ~C;\n\tTEMP1 = X8 - 3;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 3;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_012A;\n\tX0 = X21;\n\tX1 = 0;\n\t*([X21+38]) = X20;\n\tX0 = System.String::Concat(X0, X1);\n\tX8 = *([1EBC820]);\n\tX19 = X0;\n\tX8 = *([X8]);\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_011E;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_011E;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_011E:\n\tX0 = X19;\n\tX29 = stack[30];\n\tX30 = stack[38];\n\tX20 = stack[20];\n\tX19 = stack[28];\n\tX22 = stack[10];\n\tX21 = stack[18];\n\tX1 = 0;\n\tX23 = stack[0];\n\t// 295 ShiftStack 64\n\tUnityEngine.Debug::LogError(X0, X1);\n\treturn;\nL_012A:\n\tX0 = 0x8D82E4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_012D;\nL_012C:\n\tX0 = 0x8D82D8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_012D:\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0130:\n\tX0 = 0 | 8;\n\tX0 = 0x6D1E60(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X21]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0x870;\n\tX2 = 0;\n\tX0 = 0x6D2A00(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0138:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_013B:\n\tX0 = X20;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x846AA4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 109 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void PerformInternalCallback(string callbackName, Type callbackType, IntPtr callbackPtr)
		{
			if (VERBOSE_DEBUG)
			{
				string message = "Entering internal callback for " + callbackName;
				Debug.Log(message);
			}
			Action callback;
			if (callbackType != Type.Permanent)
			{
				Action action = IntPtrToTempCallback<Action>(callbackPtr);
				callback = action;
			}
			else
			{
				Action action2 = IntPtrToPermanentCallback<Action>(callbackPtr);
				callback = action2;
			}
			if (VERBOSE_DEBUG)
			{
				Debug.Log("Internal Callback converted to action");
			}
			InvokeConvertedCallback(callbackName, callback);
		}

		[Token(Token = "0x600074B")]
		[Address(RVA = "0xBB304C", Offset = "0xBB304C", Length = "0x380")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv36 = *([1EC9570]);\n\tv37 = *([v36 @ X8_v42]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, callbackType, param, callbackPtr, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2022C51]) = v52;\nL_0022:\n\tgoto L_002B;\n\tv59 = *([v55 @ X0_v2 (Il2CppClass<EasyMobile.Internal.PInvokeCallbackUtil>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tgoto L_002B;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v55, callbackType, param, callbackPtr, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv63 = EasyMobile.Internal.PInvokeCallbackUtil;\nL_002B:\n\tv68 = ~v66.VERBOSE_DEBUG;\n\tif (v68) goto L_0046;\n\tv75 = System.String::Concat(\"Entering internal callback for \", callbackName);\n\tgoto L_0043;\n\tv101 = *([v87 @ X8_v39+E0]);\n\tv102 = v101 == 0;\n\tv103 = ~v102;\n\tif (v103) goto L_0043;\n\tv133 = v87;\n\tv105 = \"il2cpp_codegen_runtime_class_init\"(v133, v72, v73, callbackPtr, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0043:\n\tUnityEngine.Debug::Log(v75);\nL_0046:\n\tv91 = callbackType == 0;\n\tif (v91) goto L_0059;\n\tgoto L_0054;\n\tv107 = *([v82 @ X0_v4+E0]);\n\tv108 = v107 == 0;\n\tv109 = ~v108;\n\tif (v109) goto L_0054;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v82, v80, v79, callbackPtr, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0054:\n\tv118 = EasyMobile.Internal.PInvokeCallbackUtil::IntPtrToTempCallback(callbackPtr);\n\tgoto L_0069;\nL_0059:\n\tgoto L_0063;\n\tv120 = *([v82 @ X0_v4+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tif (v122) goto L_0063;\n\tv124 = \"il2cpp_codegen_runtime_class_init\"(v82, v80, v79, callbackPtr, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0063:\n\tv131 = EasyMobile.Internal.PInvokeCallbackUtil::IntPtrToPermanentCallback(callbackPtr);\nL_0069:\n\tgoto L_0072;\n\tv143 = *([v139 @ X0_v6 (Il2CppClass<EasyMobile.Internal.PInvokeCallbackUtil>)+E0]);\n\tv144 = v143 == 0;\n\tv145 = ~v144;\n\tgoto L_0072;\n\tv153 = \"il2cpp_codegen_runtime_class_init\"(v139, v134, v79, callbackPtr, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv147 = EasyMobile.Internal.PInvokeCallbackUtil;\nL_0072:\n\tv152 = ~v150.VERBOSE_DEBUG;\n\tif (v152) goto L_0089;\n\tgoto L_0084;\n\tv171 = *([v156 @ X0_v12+E0]);\n\tv172 = v171 == 0;\n\tv173 = ~v172;\n\tif (v173) goto L_0084;\n\tv175 = \"il2cpp_codegen_runtime_class_init\"(v156, v134, v79, callbackPtr, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0084:\n\tUnityEngine.Debug::Log(\"Internal Callback converted to action\");\nL_0089:\n\tgoto L_0093;\n\tv179 = *([v162 @ X0_v8+E0]);\n\tv180 = v179 == 0;\n\tv181 = ~v180;\n\tgoto L_0093;\n\tv183 = \"il2cpp_codegen_runtime_class_init\"(v162, v160, v79, callbackPtr, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0093:\n\tv190 = Il2CppMethodInfo;\n\tv197 = *([v190 @ X3_v1 (Il2CppMethodInfo)]);\n\t// 159 IndirectJump v197 @ X4_v1, callbackName @ X0 (System.String), callbackName @ X0 (System.String), v137 @ X22_v2 (System.Action`1<T>), param @ X2 (T), methodof(EasyMobile.Internal.PInvokeCallbackUtil::InvokeConvertedCallback), v197 @ X4_v1, v39 @ X5, v40 @ X6, v41 @ X7, v42 @ V0, v43 @ V1, v44 @ V2, v45 @ V3, v46 @ V4, v47 @ V5, v48 @ V6, v49 @ V7\n\tgoto L_00A1;\nL_00A1:\n\tX20 = X0;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0146;\n\tX0 = X20;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\n\tX20 = *([X21]);\n\tX8 = *([1EDD7C0]);\n\tX1 = *([X20]);\n\tX0 = *([X8]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_013B;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EFE3C0]);\n\tX1 = 0 | 4;\n\tX0 = *([X8]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\n\tif (TEMP) goto L_0143;\n\tX22 = *([1F075F8]);\n\tX0 = *([X22]);\n\tif (TEMP) goto L_00CC;\n\tX8 = *([X21]);\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_0137;\nL_00CC:\n\tX8 = *([X21+18]);\n\tif (TEMP) goto L_0135;\n\tX9 = *([X22]);\n\t*([X21+20]) = X9;\n\tif (TEMP) goto L_00DA;\n\tX8 = *([X21]);\n\tX0 = X19;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_0137;\n\tX8 = *([X21+18]);\nL_00DA:\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_0135;\n\t*([X21+28]) = X19;\n\tX19 = *([1EDA590]);\n\tX0 = *([X19]);\n\tif (TEMP) goto L_00F2;\n\tX8 = *([X21]);\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_0137;\n\tX8 = *([X21+18]);\nL_00F2:\n\tC = X8 < 2;\n\tC = ~C;\n\tTEMP1 = X8 - 2;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 2;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_0135;\n\tX9 = *([X19]);\n\t*([X21+30]) = X9;\n\tif (TEMP) goto L_0109;\n\tX8 = *([X21]);\n\tX0 = X20;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_0137;\n\tX8 = *([X21+18]);\nL_0109:\n\tC = X8 < 3;\n\tC = ~C;\n\tTEMP1 = X8 - 3;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 3;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_0135;\n\tX0 = X21;\n\tX1 = 0;\n\t*([X21+38]) = X20;\n\tX0 = System.String::Concat(X0, X1);\n\tX8 = *([1EBC820]);\n\tX19 = X0;\n\tX8 = *([X8]);\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_0127;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0127;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0127:\n\tX0 = X19;\n\tX29 = stack[40];\n\tX30 = stack[48];\n\tX20 = stack[30];\n\tX19 = stack[38];\n\tX22 = stack[20];\n\tX21 = stack[28];\n\tX24 = stack[10];\n\tX23 = stack[18];\n\tX1 = 0;\n\tX25 = stack[0];\n\t// 306 ShiftStack 80\n\tUnityEngine.Debug::LogError(X0, X1);\n\treturn;\nL_0135:\n\tX0 = 0x8D82E4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_0138;\nL_0137:\n\tX0 = 0x8D82D8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0138:\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_013B:\n\tX0 = 0 | 8;\n\tX0 = 0x6D1E60(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X21]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0x870;\n\tX2 = 0;\n\tX0 = 0x6D2A00(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0143:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0146:\n\tX0 = X20;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x846AA4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 117 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void PerformInternalCallback<T>(string callbackName, Type callbackType, T param, IntPtr callbackPtr)
		{
			//IL_007a: Expected O, but got I
			while (true)
			{
				if (VERBOSE_DEBUG)
				{
					string message = "Entering internal callback for " + callbackName;
					Debug.Log(message);
				}
				if (callbackType != Type.Permanent)
				{
					Action<T> action = IntPtrToTempCallback<Action<T>>(callbackPtr);
				}
				else
				{
					Action<T> action2 = IntPtrToPermanentCallback<Action<T>>(callbackPtr);
				}
				if (VERBOSE_DEBUG)
				{
					Debug.Log("Internal Callback converted to action");
				}
				IntPtr intPtr = (IntPtr)0;
				object obj = (long)intPtr;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v197 @ X4_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600074C")]
		[Address(RVA = "0xBB2CC4", Offset = "0xBB2CC4", Length = "0x388")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv40 = *([1EE54B0]);\n\tv41 = *([v40 @ X8_v42]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, callbackType, param1, param2, callbackPtr, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2022C50]) = v55;\nL_0024:\n\tgoto L_002D;\n\tv62 = *([v58 @ X0_v2 (Il2CppClass<EasyMobile.Internal.PInvokeCallbackUtil>)+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tgoto L_002D;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v58, callbackType, param1, param2, callbackPtr, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv66 = EasyMobile.Internal.PInvokeCallbackUtil;\nL_002D:\n\tv71 = ~v69.VERBOSE_DEBUG;\n\tif (v71) goto L_0048;\n\tv78 = System.String::Concat(\"Entering internal callback for \", callbackName);\n\tgoto L_0045;\n\tv104 = *([v90 @ X8_v39+E0]);\n\tv105 = v104 == 0;\n\tv106 = ~v105;\n\tif (v106) goto L_0045;\n\tv136 = v90;\n\tv108 = \"il2cpp_codegen_runtime_class_init\"(v136, v75, v76, param2, callbackPtr, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_0045:\n\tUnityEngine.Debug::Log(v78);\nL_0048:\n\tv94 = callbackType == 0;\n\tif (v94) goto L_005B;\n\tgoto L_0056;\n\tv110 = *([v85 @ X0_v4+E0]);\n\tv111 = v110 == 0;\n\tv112 = ~v111;\n\tif (v112) goto L_0056;\n\tv114 = \"il2cpp_codegen_runtime_class_init\"(v85, v83, v82, param2, callbackPtr, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_0056:\n\tv121 = EasyMobile.Internal.PInvokeCallbackUtil::IntPtrToTempCallback(callbackPtr);\n\tgoto L_006B;\nL_005B:\n\tgoto L_0065;\n\tv123 = *([v85 @ X0_v4+E0]);\n\tv124 = v123 == 0;\n\tv125 = ~v124;\n\tif (v125) goto L_0065;\n\tv127 = \"il2cpp_codegen_runtime_class_init\"(v85, v83, v82, param2, callbackPtr, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_0065:\n\tv134 = EasyMobile.Internal.PInvokeCallbackUtil::IntPtrToPermanentCallback(callbackPtr);\nL_006B:\n\tgoto L_0074;\n\tv146 = *([v142 @ X0_v6 (Il2CppClass<EasyMobile.Internal.PInvokeCallbackUtil>)+E0]);\n\tv147 = v146 == 0;\n\tv148 = ~v147;\n\tgoto L_0074;\n\tv156 = \"il2cpp_codegen_runtime_class_init\"(v142, v137, v82, param2, callbackPtr, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv150 = EasyMobile.Internal.PInvokeCallbackUtil;\nL_0074:\n\tv155 = ~v153.VERBOSE_DEBUG;\n\tif (v155) goto L_008B;\n\tgoto L_0086;\n\tv174 = *([v159 @ X0_v12+E0]);\n\tv175 = v174 == 0;\n\tv176 = ~v175;\n\tif (v176) goto L_0086;\n\tv178 = \"il2cpp_codegen_runtime_class_init\"(v159, v137, v82, param2, callbackPtr, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_0086:\n\tUnityEngine.Debug::Log(\"Internal Callback converted to action\");\nL_008B:\n\tgoto L_0095;\n\tv182 = *([v165 @ X0_v8+E0]);\n\tv183 = v182 == 0;\n\tv184 = ~v183;\n\tgoto L_0095;\n\tv186 = \"il2cpp_codegen_runtime_class_init\"(v165, v163, v82, param2, callbackPtr, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_0095:\n\tv193 = Il2CppMethodInfo;\n\tv199 = *([v193 @ X4_v1 (Il2CppMethodInfo)]);\n\t// 163 IndirectJump v199 @ X5_v1, callbackName @ X0 (System.String), callbackName @ X0 (System.String), v140 @ X23_v2 (System.Action`2<T, P>), param1 @ X2 (T), param2 @ X3 (P), methodof(EasyMobile.Internal.PInvokeCallbackUtil::InvokeConvertedCallback), v199 @ X5_v1, v43 @ X6, v44 @ X7, v45 @ V0, v46 @ V1, v47 @ V2, v48 @ V3, v49 @ V4, v50 @ V5, v51 @ V6, v52 @ V7\n\tgoto L_00A5;\nL_00A5:\n\tX20 = X0;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_014B;\n\tX0 = X20;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\n\tX20 = *([X21]);\n\tX8 = *([1EDD7C0]);\n\tX1 = *([X20]);\n\tX0 = *([X8]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0140;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EFE3C0]);\n\tX1 = 0 | 4;\n\tX0 = *([X8]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\n\tif (TEMP) goto L_0148;\n\tX22 = *([1F075F8]);\n\tX0 = *([X22]);\n\tif (TEMP) goto L_00D0;\n\tX8 = *([X21]);\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_013C;\nL_00D0:\n\tX8 = *([X21+18]);\n\tif (TEMP) goto L_013A;\n\tX9 = *([X22]);\n\t*([X21+20]) = X9;\n\tif (TEMP) goto L_00DE;\n\tX8 = *([X21]);\n\tX0 = X19;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_013C;\n\tX8 = *([X21+18]);\nL_00DE:\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_013A;\n\t*([X21+28]) = X19;\n\tX19 = *([1EDA590]);\n\tX0 = *([X19]);\n\tif (TEMP) goto L_00F6;\n\tX8 = *([X21]);\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_013C;\n\tX8 = *([X21+18]);\nL_00F6:\n\tC = X8 < 2;\n\tC = ~C;\n\tTEMP1 = X8 - 2;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 2;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_013A;\n\tX9 = *([X19]);\n\t*([X21+30]) = X9;\n\tif (TEMP) goto L_010D;\n\tX8 = *([X21]);\n\tX0 = X20;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_013C;\n\tX8 = *([X21+18]);\nL_010D:\n\tC = X8 < 3;\n\tC = ~C;\n\tTEMP1 = X8 - 3;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 3;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_013A;\n\tX0 = X21;\n\tX1 = 0;\n\t*([X21+38]) = X20;\n\tX0 = System.String::Concat(X0, X1);\n\tX8 = *([1EBC820]);\n\tX19 = X0;\n\tX8 = *([X8]);\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_012B;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_012B;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_012B:\n\tX0 = X19;\n\tX29 = stack[40];\n\tX30 = stack[48];\n\tX20 = stack[30];\n\tX19 = stack[38];\n\tX22 = stack[20];\n\tX21 = stack[28];\n\tX24 = stack[10];\n\tX23 = stack[18];\n\tX1 = 0;\n\tX26 = stack[0];\n\tX25 = stack[8];\n\t// 311 ShiftStack 80\n\tUnityEngine.Debug::LogError(X0, X1);\n\treturn;\nL_013A:\n\tX0 = 0x8D82E4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_013D;\nL_013C:\n\tX0 = 0x8D82D8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_013D:\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0140:\n\tX0 = 0 | 8;\n\tX0 = 0x6D1E60(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X21]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0x870;\n\tX2 = 0;\n\tX0 = 0x6D2A00(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0148:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_014B:\n\tX0 = X20;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x846AA4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 121 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void PerformInternalCallback<T, P>(string callbackName, Type callbackType, T param1, P param2, IntPtr callbackPtr)
		{
			//IL_007a: Expected O, but got I
			while (true)
			{
				if (VERBOSE_DEBUG)
				{
					string message = "Entering internal callback for " + callbackName;
					Debug.Log(message);
				}
				if (callbackType != Type.Permanent)
				{
					Action<T, P> action = IntPtrToTempCallback<Action<T, P>>(callbackPtr);
				}
				else
				{
					Action<T, P> action2 = IntPtrToPermanentCallback<Action<T, P>>(callbackPtr);
				}
				if (VERBOSE_DEBUG)
				{
					Debug.Log("Internal Callback converted to action");
				}
				IntPtr intPtr = (IntPtr)0;
				object obj = (long)intPtr;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v199 @ X5_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600074D")]
		[Address(RVA = "0x14F7474", Offset = "0x14F7474", Length = "0x388")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv36 = *([1EAB8D0]);\n\tv37 = *([v36 @ X8_v42]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, callbackType, param, funcPtr, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2028E64]) = v52;\nL_0022:\n\tgoto L_002B;\n\tv59 = *([v55 @ X0_v2 (Il2CppClass<EasyMobile.Internal.PInvokeCallbackUtil>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tgoto L_002B;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v55, callbackType, param, funcPtr, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv63 = EasyMobile.Internal.PInvokeCallbackUtil;\nL_002B:\n\tv68 = ~v66.VERBOSE_DEBUG;\n\tif (v68) goto L_0046;\n\tv75 = System.String::Concat(\"Entering internal callback for \", funcName);\n\tgoto L_0043;\n\tv101 = *([v87 @ X8_v39+E0]);\n\tv102 = v101 == 0;\n\tv103 = ~v102;\n\tif (v103) goto L_0043;\n\tv133 = v87;\n\tv105 = \"il2cpp_codegen_runtime_class_init\"(v133, v72, v73, funcPtr, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0043:\n\tUnityEngine.Debug::Log(v75);\nL_0046:\n\tv91 = callbackType == 0;\n\tif (v91) goto L_0059;\n\tgoto L_0054;\n\tv107 = *([v82 @ X0_v4+E0]);\n\tv108 = v107 == 0;\n\tv109 = ~v108;\n\tif (v109) goto L_0054;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v82, v80, v79, funcPtr, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0054:\n\tv118 = EasyMobile.Internal.PInvokeCallbackUtil::IntPtrToTempCallback(funcPtr);\n\tgoto L_0069;\nL_0059:\n\tgoto L_0063;\n\tv120 = *([v82 @ X0_v4+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tif (v122) goto L_0063;\n\tv124 = \"il2cpp_codegen_runtime_class_init\"(v82, v80, v79, funcPtr, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0063:\n\tv131 = EasyMobile.Internal.PInvokeCallbackUtil::IntPtrToPermanentCallback(funcPtr);\nL_0069:\n\tgoto L_0072;\n\tv143 = *([v139 @ X0_v6 (Il2CppClass<EasyMobile.Internal.PInvokeCallbackUtil>)+E0]);\n\tv144 = v143 == 0;\n\tv145 = ~v144;\n\tgoto L_0072;\n\tv153 = \"il2cpp_codegen_runtime_class_init\"(v139, v134, v79, funcPtr, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv147 = EasyMobile.Internal.PInvokeCallbackUtil;\nL_0072:\n\tv152 = ~v150.VERBOSE_DEBUG;\n\tif (v152) goto L_0089;\n\tgoto L_0084;\n\tv171 = *([v156 @ X0_v12+E0]);\n\tv172 = v171 == 0;\n\tv173 = ~v172;\n\tif (v173) goto L_0084;\n\tv175 = \"il2cpp_codegen_runtime_class_init\"(v156, v134, v79, funcPtr, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0084:\n\tUnityEngine.Debug::Log(\"Internal Function converted to action\");\nL_0089:\n\tgoto L_0093;\n\tv179 = *([v162 @ X0_v8+E0]);\n\tv180 = v179 == 0;\n\tv181 = ~v180;\n\tgoto L_0093;\n\tv183 = \"il2cpp_codegen_runtime_class_init\"(v162, v160, v79, funcPtr, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0093:\n\tv190 = Il2CppMethodInfo;\n\tv197 = *([v190 @ X3_v1 (Il2CppMethodInfo)]);\n\t// 159 IndirectJump v197 @ X4_v1, funcName @ X0 (System.String), funcName @ X0 (System.String), v137 @ X22_v2 (System.Func`2<T, P>), param @ X2 (T), methodof(EasyMobile.Internal.PInvokeCallbackUtil::InvokeConvertedFunction), v197 @ X4_v1, v39 @ X5, v40 @ X6, v41 @ X7, v42 @ V0, v43 @ V1, v44 @ V2, v45 @ V3, v46 @ V4, v47 @ V5, v48 @ V6, v49 @ V7\n\tgoto L_00A1;\nL_00A1:\n\tX20 = X0;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0147;\n\tX0 = X20;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\n\tX20 = *([X21]);\n\tX8 = *([1EDD7C0]);\n\tX1 = *([X20]);\n\tX0 = *([X8]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_013C;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EFE3C0]);\n\tX1 = 0 | 4;\n\tX0 = *([X8]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\n\tif (TEMP) goto L_0144;\n\tX22 = *([1F075F8]);\n\tX0 = *([X22]);\n\tif (TEMP) goto L_00CC;\n\tX8 = *([X21]);\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_0138;\nL_00CC:\n\tX8 = *([X21+18]);\n\tif (TEMP) goto L_0136;\n\tX9 = *([X22]);\n\t*([X21+20]) = X9;\n\tif (TEMP) goto L_00DA;\n\tX8 = *([X21]);\n\tX0 = X19;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_0138;\n\tX8 = *([X21+18]);\nL_00DA:\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_0136;\n\t*([X21+28]) = X19;\n\tX19 = *([1EDA590]);\n\tX0 = *([X19]);\n\tif (TEMP) goto L_00F2;\n\tX8 = *([X21]);\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_0138;\n\tX8 = *([X21+18]);\nL_00F2:\n\tC = X8 < 2;\n\tC = ~C;\n\tTEMP1 = X8 - 2;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 2;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_0136;\n\tX9 = *([X19]);\n\t*([X21+30]) = X9;\n\tif (TEMP) goto L_0109;\n\tX8 = *([X21]);\n\tX0 = X20;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_0138;\n\tX8 = *([X21+18]);\nL_0109:\n\tC = X8 < 3;\n\tC = ~C;\n\tTEMP1 = X8 - 3;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 3;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_0136;\n\tX0 = X21;\n\tX1 = 0;\n\t*([X21+38]) = X20;\n\tX0 = System.String::Concat(X0, X1);\n\tX8 = *([1EBC820]);\n\tX19 = X0;\n\tX8 = *([X8]);\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_0127;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0127;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0127:\n\tX0 = X19;\n\tX1 = 0;\n\tUnityEngine.Debug::LogError(X0, X1);\n\tX29 = stack[40];\n\tX30 = stack[48];\n\tX20 = stack[30];\n\tX19 = stack[38];\n\tX22 = stack[20];\n\tX21 = stack[28];\n\tX24 = stack[10];\n\tX23 = stack[18];\n\tX0 = 0;\n\tX25 = stack[0];\n\t// 308 ShiftStack 80\n\treturn X0;\nL_0136:\n\tX0 = 0x8D82E4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_0139;\nL_0138:\n\tX0 = 0x8D82D8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0139:\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_013C:\n\tX0 = 0 | 8;\n\tX0 = 0x6D1E60(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X21]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0x870;\n\tX2 = 0;\n\tX0 = 0x6D2A00(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0144:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0147:\n\tX0 = X20;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x846AA4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 117 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static P PerformInternalFunction<T, P>(string funcName, Type callbackType, T param, IntPtr funcPtr)
		{
			//IL_007a: Expected O, but got I
			while (true)
			{
				if (VERBOSE_DEBUG)
				{
					string message = "Entering internal callback for " + funcName;
					Debug.Log(message);
				}
				if (callbackType != Type.Permanent)
				{
					Func<T, P> func = IntPtrToTempCallback<Func<T, P>>(funcPtr);
				}
				else
				{
					Func<T, P> func2 = IntPtrToPermanentCallback<Func<T, P>>(funcPtr);
				}
				if (VERBOSE_DEBUG)
				{
					Debug.Log("Internal Function converted to action");
				}
				IntPtr intPtr = (IntPtr)0;
				object obj = (long)intPtr;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v197 @ X4_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600074E")]
		[Address(RVA = "0xC062B0", Offset = "0xC062B0", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1EC93D0]);\n\tv25 = *([v24 @ X8_v4]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, callback, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022FE9]) = v43;\nL_0016:\n\tv44 = callback == 0;\n\tif (v44) goto L_0022;\n\tSystem.Action::Invoke(callback);\nL_0022:\n\treturn;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX20 = X0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00C5;\n\tX0 = X20;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX21 = *([X20]);\n\tX8 = *([1EDD7C0]);\n\tX1 = *([X21]);\n\tX0 = *([X8]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00BA;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EFE3C0]);\n\tX1 = 0 | 4;\n\tX0 = *([X8]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tif (TEMP) goto L_00C2;\n\tX22 = *([1F00AD0]);\n\tX0 = *([X22]);\n\tif (TEMP) goto L_004E;\n\tX8 = *([X20]);\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00B6;\nL_004E:\n\tX8 = *([X20+18]);\n\tif (TEMP) goto L_00B4;\n\tX9 = *([X22]);\n\t*([X20+20]) = X9;\n\tif (TEMP) goto L_005C;\n\tX8 = *([X20]);\n\tX0 = X19;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00B6;\n\tX8 = *([X20+18]);\nL_005C:\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_00B4;\n\t*([X20+28]) = X19;\n\tX19 = *([1EDA590]);\n\tX0 = *([X19]);\n\tif (TEMP) goto L_0074;\n\tX8 = *([X20]);\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00B6;\n\tX8 = *([X20+18]);\nL_0074:\n\tC = X8 < 2;\n\tC = ~C;\n\tTEMP1 = X8 - 2;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 2;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_00B4;\n\tX9 = *([X19]);\n\t*([X20+30]) = X9;\n\tif (TEMP) goto L_008B;\n\tX8 = *([X20]);\n\tX0 = X21;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00B6;\n\tX8 = *([X20+18]);\nL_008B:\n\tC = X8 < 3;\n\tC = ~C;\n\tTEMP1 = X8 - 3;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 3;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_00B4;\n\tX0 = X20;\n\tX1 = 0;\n\t*([X20+38]) = X21;\n\tX0 = System.String::Concat(X0, X1);\n\tX8 = *([1EBC820]);\n\tX19 = X0;\n\tX8 = *([X8]);\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_00A9;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00A9;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00A9:\n\tX0 = X19;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX1 = 0;\n\tX22 = stack[0];\n\tX21 = stack[8];\n\t// 177 ShiftStack 48\n\tUnityEngine.Debug::LogError(X0, X1);\n\treturn;\nL_00B4:\n\tX0 = 0x8D82E4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_00B7;\nL_00B6:\n\tX0 = 0x8D82D8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00B7:\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00BA:\n\tX0 = 0 | 8;\n\tX0 = 0x6D1E60(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X20]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0x870;\n\tX2 = 0;\n\tX0 = 0x6D2A00(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00C2:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00C5:\n\tX0 = X20;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x846AA4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void InvokeConvertedCallback(string callbackName, Action callback)
		{
			callback?.Invoke();
		}

		[Token(Token = "0x600074F")]
		[Address(RVA = "0xBB2AA4", Offset = "0xBB2AA4", Length = "0x220")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1F07B78]);\n\tv31 = *([v30 @ X8_v7]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, callback, param, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2022C4F]) = v47;\nL_0019:\n\tv48 = callback == 0;\n\tif (v48) goto L_0029;\n\tv54 = System.Action`1<T>::Invoke(callback, param);\nL_0029:\n\treturn;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX20 = X0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00CD;\n\tX0 = X20;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX21 = *([X20]);\n\tX8 = *([1EDD7C0]);\n\tX1 = *([X21]);\n\tX0 = *([X8]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00C2;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EFE3C0]);\n\tX1 = 0 | 4;\n\tX0 = *([X8]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tif (TEMP) goto L_00CA;\n\tX22 = *([1F00AD0]);\n\tX0 = *([X22]);\n\tif (TEMP) goto L_0055;\n\tX8 = *([X20]);\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00BE;\nL_0055:\n\tX8 = *([X20+18]);\n\tif (TEMP) goto L_00BC;\n\tX9 = *([X22]);\n\t*([X20+20]) = X9;\n\tif (TEMP) goto L_0063;\n\tX8 = *([X20]);\n\tX0 = X19;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00BE;\n\tX8 = *([X20+18]);\nL_0063:\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_00BC;\n\t*([X20+28]) = X19;\n\tX19 = *([1EDA590]);\n\tX0 = *([X19]);\n\tif (TEMP) goto L_007B;\n\tX8 = *([X20]);\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00BE;\n\tX8 = *([X20+18]);\nL_007B:\n\tC = X8 < 2;\n\tC = ~C;\n\tTEMP1 = X8 - 2;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 2;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_00BC;\n\tX9 = *([X19]);\n\t*([X20+30]) = X9;\n\tif (TEMP) goto L_0092;\n\tX8 = *([X20]);\n\tX0 = X21;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00BE;\n\tX8 = *([X20+18]);\nL_0092:\n\tC = X8 < 3;\n\tC = ~C;\n\tTEMP1 = X8 - 3;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 3;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_00BC;\n\tX0 = X20;\n\tX1 = 0;\n\t*([X20+38]) = X21;\n\tX0 = System.String::Concat(X0, X1);\n\tX8 = *([1EBC820]);\n\tX19 = X0;\n\tX8 = *([X8]);\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_00B0;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00B0;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00B0:\n\tX0 = X19;\n\tX29 = stack[30];\n\tX30 = stack[38];\n\tX20 = stack[20];\n\tX19 = stack[28];\n\tX22 = stack[10];\n\tX21 = stack[18];\n\tX1 = 0;\n\tX23 = stack[0];\n\t// 185 ShiftStack 64\n\tUnityEngine.Debug::LogError(X0, X1);\n\treturn;\nL_00BC:\n\tX0 = 0x8D82E4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_00BF;\nL_00BE:\n\tX0 = 0x8D82D8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00BF:\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00C2:\n\tX0 = 0 | 8;\n\tX0 = 0x6D1E60(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X20]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0x870;\n\tX2 = 0;\n\tX0 = 0x6D2A00(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00CA:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00CD:\n\tX0 = X20;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x846AA4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void InvokeConvertedCallback<T>(string callbackName, Action<T> callback, T param)
		{
			callback?.Invoke(param);
		}

		[Token(Token = "0x6000750")]
		[Address(RVA = "0xBB287C", Offset = "0xBB287C", Length = "0x228")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1F0AD90]);\n\tv35 = *([v34 @ X8_v7]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, callback, param1, param2, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2022C4E]) = v50;\nL_001B:\n\tv51 = callback == 0;\n\tif (v51) goto L_002D;\n\tv58 = System.Action`2<T, P>::Invoke(callback, param1, param2);\nL_002D:\n\treturn;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX20 = X0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00D2;\n\tX0 = X20;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX21 = *([X20]);\n\tX8 = *([1EDD7C0]);\n\tX1 = *([X21]);\n\tX0 = *([X8]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00C7;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EFE3C0]);\n\tX1 = 0 | 4;\n\tX0 = *([X8]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tif (TEMP) goto L_00CF;\n\tX22 = *([1F00AD0]);\n\tX0 = *([X22]);\n\tif (TEMP) goto L_0059;\n\tX8 = *([X20]);\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00C3;\nL_0059:\n\tX8 = *([X20+18]);\n\tif (TEMP) goto L_00C1;\n\tX9 = *([X22]);\n\t*([X20+20]) = X9;\n\tif (TEMP) goto L_0067;\n\tX8 = *([X20]);\n\tX0 = X19;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00C3;\n\tX8 = *([X20+18]);\nL_0067:\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_00C1;\n\t*([X20+28]) = X19;\n\tX19 = *([1EDA590]);\n\tX0 = *([X19]);\n\tif (TEMP) goto L_007F;\n\tX8 = *([X20]);\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00C3;\n\tX8 = *([X20+18]);\nL_007F:\n\tC = X8 < 2;\n\tC = ~C;\n\tTEMP1 = X8 - 2;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 2;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_00C1;\n\tX9 = *([X19]);\n\t*([X20+30]) = X9;\n\tif (TEMP) goto L_0096;\n\tX8 = *([X20]);\n\tX0 = X21;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00C3;\n\tX8 = *([X20+18]);\nL_0096:\n\tC = X8 < 3;\n\tC = ~C;\n\tTEMP1 = X8 - 3;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 3;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_00C1;\n\tX0 = X20;\n\tX1 = 0;\n\t*([X20+38]) = X21;\n\tX0 = System.String::Concat(X0, X1);\n\tX8 = *([1EBC820]);\n\tX19 = X0;\n\tX8 = *([X8]);\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_00B4;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00B4;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00B4:\n\tX0 = X19;\n\tX29 = stack[30];\n\tX30 = stack[38];\n\tX20 = stack[20];\n\tX19 = stack[28];\n\tX22 = stack[10];\n\tX21 = stack[18];\n\tX1 = 0;\n\tX24 = stack[0];\n\tX23 = stack[8];\n\t// 190 ShiftStack 64\n\tUnityEngine.Debug::LogError(X0, X1);\n\treturn;\nL_00C1:\n\tX0 = 0x8D82E4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_00C4;\nL_00C3:\n\tX0 = 0x8D82D8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00C4:\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00C7:\n\tX0 = 0 | 8;\n\tX0 = 0x6D1E60(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X20]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0x870;\n\tX2 = 0;\n\tX0 = 0x6D2A00(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00CF:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00D2:\n\tX0 = X20;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x846AA4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void InvokeConvertedCallback<T, P>(string callbackName, Action<T, P> callback, T param1, P param2)
		{
			callback?.Invoke(param1, param2);
		}

		[Token(Token = "0x6000751")]
		[Address(RVA = "0x14F725C", Offset = "0x14F725C", Length = "0x218")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EB9678]);\n\tv31 = *([v30 @ X8_v7]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, function, param, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2028E63]) = v47;\nL_0019:\n\tv48 = function == 0;\n\tif (v48) goto L_FFFFFFFF;\n\treturnVal1 = System.Func`2<T, P>::Invoke(function, param);\n\tgoto L_00B4;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX20 = X0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00C6;\n\tX0 = X20;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX21 = *([X20]);\n\tX8 = *([1EDD7C0]);\n\tX1 = *([X21]);\n\tX0 = *([X8]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00BB;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EFE3C0]);\n\tX1 = 0 | 4;\n\tX0 = *([X8]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tif (TEMP) goto L_00C3;\n\tX22 = *([1F00AD0]);\n\tX0 = *([X22]);\n\tif (TEMP) goto L_004D;\n\tX8 = *([X20]);\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00B7;\nL_004D:\n\tX8 = *([X20+18]);\n\tif (TEMP) goto L_00B5;\n\tX9 = *([X22]);\n\t*([X20+20]) = X9;\n\tif (TEMP) goto L_005B;\n\tX8 = *([X20]);\n\tX0 = X19;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00B7;\n\tX8 = *([X20+18]);\nL_005B:\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_00B5;\n\t*([X20+28]) = X19;\n\tX19 = *([1EDA590]);\n\tX0 = *([X19]);\n\tif (TEMP) goto L_0073;\n\tX8 = *([X20]);\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00B7;\n\tX8 = *([X20+18]);\nL_0073:\n\tC = X8 < 2;\n\tC = ~C;\n\tTEMP1 = X8 - 2;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 2;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_00B5;\n\tX9 = *([X19]);\n\t*([X20+30]) = X9;\n\tif (TEMP) goto L_008A;\n\tX8 = *([X20]);\n\tX0 = X21;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00B7;\n\tX8 = *([X20+18]);\nL_008A:\n\tC = X8 < 3;\n\tC = ~C;\n\tTEMP1 = X8 - 3;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 3;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_00B5;\n\tX0 = X20;\n\tX1 = 0;\n\t*([X20+38]) = X21;\n\tX0 = System.String::Concat(X0, X1);\n\tX8 = *([1EBC820]);\n\tX19 = X0;\n\tX8 = *([X8]);\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_00A8;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00A8;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00A8:\n\tX0 = X19;\n\tX1 = 0;\n\tUnityEngine.Debug::LogError(X0, X1);\nL_00B4:\n\treturn returnVal1;\nL_00B5:\n\tX0 = 0x8D82E4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_00B8;\nL_00B7:\n\tX0 = 0x8D82D8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00B8:\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00BB:\n\tX0 = 0 | 8;\n\tX0 = 0x6D1E60(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X20]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0x870;\n\tX2 = 0;\n\tX0 = 0x6D2A00(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00C3:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00C6:\n\tX0 = X20;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x846AA4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static P InvokeConvertedFunction<T, P>(string funcName, Func<T, P> function, T param)
		{
			return function?.Invoke(param);
		}
	}
}
