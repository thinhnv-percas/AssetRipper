using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal
{
	[Token(Token = "0x20000C9")]
	internal static class PInvokeUtil
	{
		[Token(Token = "0x20001B5")]
		internal delegate int NativeToManagedArray<T>([In][Out] T[] buffer, int length);

		[Token(Token = "0x6000753")]
		[Address(RVA = "0xBFFB18", Offset = "0xBFFB18", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1F03468]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022FEA]) = v41;\nL_0016:\n\tv43 = EasyMobile.Internal.PInvokeUtil::IsNull(methodInfo);\n\tv45 = v43 == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_0027;\n\treturn reference;\nL_0027:\n\tv57 = new System.InvalidOperationException();\n\tSystem.InvalidOperationException::.ctor(v57);\n\tthrow v57;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static HandleRef CheckNonNull(HandleRef reference)
		{
			IntPtr pointer = default(IntPtr);
			if (!IsNull(pointer))
			{
				return reference;
			}
			InvalidOperationException ex = new InvalidOperationException();
			throw ex;
		}

		[Token(Token = "0x6000754")]
		[Address(RVA = "0xBFFEC0", Offset = "0xBFFEC0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = EasyMobile.Internal.PInvokeUtil::IsNull(methodInfo);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool IsNull(HandleRef reference)
		{
			IntPtr pointer = default(IntPtr);
			return IsNull(pointer);
		}

		[Token(Token = "0x6000755")]
		[Address(RVA = "0xBFDFEC", Offset = "0xBFDFEC", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = &v7 @ stack_-10_v2;\n\t*([v6 @ X29_v1-8]) = pointer;\n\tgoto L_0015;\n\tv15 = *([1EE6098]);\n\tv16 = *([v15 @ X8_v6]);\n\tv17 = \"il2cpp_codegen_initialize_method\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv35 = 0 | 1;\n\t*([2022FEB]) = v35;\nL_0015:\n\tv39 = 0;\n\t// 23 Box v41 @ X0_v3, typeof(System.IntPtr), &v39 @ stack_-28_v1\n\tv43 = &v7 @ stack_-10_v2 - 8;\n\tv45 = 0xDC4D34(v43, v41, 0, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\treturnVal1 = v45 & 1;\n\treturn returnVal1;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool IsNull(IntPtr pointer)
		{
			//IL_001b: Expected O, but got I4
			//IL_0024: Expected I, but got O
			//IL_0037: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			object obj3 = 0;
			object obj4 = (IntPtr)obj3;
			object obj5 = (long)(IntPtr)obj2 - 8L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC4D34 (inside System.IntPtr::get_Size +0xB8)");
			object obj6 = default(object);
			return (byte)((ulong)(long)(IntPtr)obj6 & 1uL) != 0;
		}

		[Token(Token = "0x6000756")]
		[Address(RVA = "0xC064B4", Offset = "0xC064B4", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = EasyMobile.Internal.PInvokeUtil::IsNull(methodInfo);\n\tv9 = ~v8;\n\treturn v9;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool IsNotNull(HandleRef reference)
		{
			IntPtr pointer = default(IntPtr);
			bool flag = IsNull(pointer);
			return !flag;
		}

		[Token(Token = "0x6000757")]
		[Address(RVA = "0xC05F38", Offset = "0xC05F38", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = EasyMobile.Internal.PInvokeUtil::IsNull(pointer);\n\tv9 = ~v6;\n\treturn v9;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool IsNotNull(IntPtr pointer)
		{
			bool flag = IsNull(pointer);
			return !flag;
		}

		[Token(Token = "0x6000758")]
		[Address(RVA = "0xADC914", Offset = "0xADC914", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = EasyMobile.Internal.PInvokeUtil+NativeToManagedArray`1<T>::Invoke(method, 0, 0);\n\tgoto L_0029;\n\tv48 = v40;\n\tv49 = EasyMobile.Internal.PInvokeUtil+NativeToManagedArray`1<T>::Invoke(v48, v21, v22, v23);\nL_0029:\n\tv63 = v25 <= 0;\n\tif (v63) goto L_0037;\n\t// 44 NewArr v65 @ X0_v9 (T[]), typeof(Il2CppClass<T[]>), v25 @ X0_v3 (System.Int32)\n\tv117 = EasyMobile.Internal.PInvokeUtil+NativeToManagedArray`1<T>::Invoke(method, v65, v25);\n\tgoto L_0041;\nL_0037:\n\t// 55 NewArr v67 @ X0_v8 (T[]), typeof(Il2CppClass<T[]>), 0\nL_0041:\n\treturn v120;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static T[] GetNativeArray<T>(NativeToManagedArray<T> method)
		{
			int num = method(null, 0);
			if (num > 0)
			{
				T[] array = null;
				int num2 = method(array, num);
				return array;
			}
			return null;
		}

		[Token(Token = "0x6000759")]
		[Address(RVA = "0xC064D4", Offset = "0xC064D4", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EDD700]);\n\tv19 = *([v18 @ X8_v20]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022FEC]) = v38;\nL_0017:\n\tv43 = EasyMobile.Internal.PInvokeUtil::GetNativeArray(nativeToManagedCharArray);\n\tv45 = v43 == 0;\n\tif (v45) goto L_0060;\n\tv47 = v43.Length == 0;\n\tif (v47) goto L_FFFFFFFF;\n\tv103 = System.Text.Encoding::get_UTF8();\n\tv90 = v103 == 0;\n\tif (v90) goto L_0028;\n\treturnVal1 = System.Text.Encoding::GetString(v103, v43);\n\tgoto L_0060;\nL_0028:\n\tv148 = new System.NullReferenceException();\n\tgoto L_0034;\nL_0034:\n\tv104 = Il2CppMethodInfo != 1;\n\tif (v104) goto L_006C;\n\tv152 = EasyMobile.Internal.PInvokeUtil::GetNativeArray(v148);\n\tv163 = *([v152 @ X0_v15 (System.Byte[])]);\n\tv167 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v163 @ X19_v8 (Il2CppClass<System.Byte[]>)]), v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv168 = v167 & 1;\n\tv157 = v168 == 0;\n\tif (v157) goto L_0062;\n\tv169 = 0x6D2490(v167, *([v163 @ X19_v8 (Il2CppClass<System.Byte[]>)]), v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv176 = System.String::Concat(\"Exception creating string from char array: \", v163);\n\tgoto L_0059;\n\tv184 = *([v120 @ X8_v16+E0]);\n\tv185 = v184 == 0;\n\tv186 = ~v185;\n\tif (v186) goto L_0059;\n\tv189 = v120;\n\tv188 = \"il2cpp_codegen_runtime_class_init\"(v189, v174, v114, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0059:\n\tUnityEngine.Debug::LogError(v176);\nL_0060:\n\treturn returnVal1;\nL_0062:\n\tv171 = 0x6D1E60(8, *([v163 @ X19_v8 (Il2CppClass<System.Byte[]>)]), v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\t*([v171 @ X0_v19 (EasyMobile.Internal.PInvokeUtil+NativeToManagedArray`1<System.Byte>)]) = *([v152 @ X0_v15 (System.Byte[])]);\n\tv178 = EasyMobile.Internal.PInvokeUtil::GetNativeArray(v171);\n\tv156 = EasyMobile.Internal.PInvokeUtil::GetNativeArray(v178);\nL_006C:\n\tv161 = EasyMobile.Internal.PInvokeUtil::GetNativeArray(v142);\n\treturnVal2 = EasyMobile.Internal.PInvokeUtil::GetNativeArray(v161);\n\treturn returnVal2;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static string GetNativeString(NativeToManagedArray<byte> nativeToManagedCharArray)
		{
			//IL_00aa: Expected I, but got O
			//IL_00fd: Expected O, but got I
			byte[] nativeArray = GetNativeArray(nativeToManagedCharArray);
			bool flag = nativeArray == null;
			string result = (string)(object)nativeArray;
			if (!flag)
			{
				if (nativeArray.Length == 0)
				{
					goto IL_0119;
				}
				Encoding uTF = Encoding.UTF8;
				if (uTF == null)
				{
					NullReferenceException ex = new NullReferenceException();
					bool flag2 = (IntPtr)0 != (IntPtr)1;
					NullReferenceException method = ex;
					if (!flag2)
					{
						byte[] nativeArray2 = GetNativeArray((NativeToManagedArray<byte>)(object)ex);
						IntPtr intPtr = (IntPtr)nativeArray2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
						object obj = default(object);
						if ((uint)((ulong)(long)(IntPtr)obj & 1uL) != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
							string message = "Exception creating string from char array: " + (long)intPtr;
							Debug.LogError(message);
							goto IL_0119;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
						NativeToManagedArray<byte> method2 = (NativeToManagedArray<byte>)(object)nativeArray2;
						NullReferenceException nativeArray3 = (NullReferenceException)(object)GetNativeArray(method2);
						byte[] nativeArray4 = GetNativeArray((NativeToManagedArray<byte>)(object)nativeArray3);
						method = nativeArray3;
					}
					byte[] nativeArray5 = GetNativeArray((NativeToManagedArray<byte>)(object)method);
					return (string)(object)GetNativeArray((NativeToManagedArray<byte>)(object)nativeArray5);
				}
				result = uTF.GetString(nativeArray);
			}
			goto IL_01b8;
			IL_01b8:
			return result;
			IL_0119:
			result = null;
			goto IL_01b8;
		}

		[Token(Token = "0x600075A")]
		[Address(RVA = "0xC06620", Offset = "0xC06620", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EDEFA8]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, dataLength, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022FED]) = v41;\nL_0015:\n\tv42 = dataLength == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tv46 = 0;\n\t// 28 Box v48 @ X0_v5, typeof(System.IntPtr), &v46 @ stack_-38_v2\n\tv54 = 0xDC4D34(&v52 @ stack_-28_v3 (System.IntPtr), v48, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv87 = v54 & 1;\n\tv88 = v87 == 0;\n\tv73 = ~v88;\n\tif (v73) goto L_0049;\n\t// 42 NewArr v93 @ X0_v9 (System.Byte[]), typeof(System.Byte[]), dataLength @ X1 (System.Int32)\n\tgoto L_003F;\n\tv99 = *([v76 @ X8_v10+E0]);\n\tv100 = v99 == 0;\n\tv101 = ~v100;\n\tif (v101) goto L_003F;\n\tv104 = v76;\n\tv103 = \"il2cpp_codegen_runtime_class_init\"(v104, v91, v53, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003F:\n\tSystem.Runtime.InteropServices.Marshal::Copy(v52, v93, 0, dataLength);\n\tgoto L_0049;\nL_0049:\n\treturn v77;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static byte[] CopyNativeByteArray(IntPtr data, int dataLength)
		{
			//IL_000e: Expected O, but got I4
			//IL_0017: Expected I, but got O
			byte[] result;
			if (dataLength != 0)
			{
				object obj = 0;
				object obj2 = (IntPtr)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC4D34 (inside System.IntPtr::get_Size +0xB8)");
				object obj3 = default(object);
				int num = (int)((long)(IntPtr)obj3 & 1L);
				bool flag = num == 0;
				bool flag2 = !flag;
				result = null;
				if (!flag2)
				{
					byte[] array = new byte[dataLength];
					IntPtr source = default(IntPtr);
					Marshal.Copy(source, array, 0, dataLength);
					result = array;
				}
			}
			else
			{
				result = null;
			}
			return result;
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x7381AC", Offset = "0x7381AC")]
		[Token(Token = "0x600075B")]
		[Address(RVA = "0x957964", Offset = "0x957964", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv26 = v21;\n\tv27 = 0x8907BC(v26, getElement, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0015:\n\tv43 = new Il2CppClass<EasyMobile.Internal.PInvokeUtil+<ToEnumerable>d__9`1<T>>();\n\tv49 = EasyMobile.Internal.PInvokeUtil+<ToEnumerable>d__9`1<T>::.ctor(v43, 0xFFFFFFFE);\n\t*([v43 @ X0_v3 (System.Collections.Generic.IEnumerable`1<T>)+3C]) = size;\n\t*([v43 @ X0_v3 (System.Collections.Generic.IEnumerable`1<T>)+30]) = getElement;\n\treturn v43;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static IEnumerable<T> ToEnumerable<T>(int size, Func<int, T> getElement)
		{
			int i = 0;
			int num;
			int num2 = default(int);
			Func<int, T> func = default(Func<int, T>);
			while (num < num2)
			{
				yield return func(num);
				num = i + 1;
				i = num;
			}
		}
	}
}
