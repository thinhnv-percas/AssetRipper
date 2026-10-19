using System;
using System.Collections;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.SaveSystem.Core.Variables
{
	[Token(Token = "0x2000014")]
	public class PermanentList<T> : PermanentObject<List<T>>, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		[Token(Token = "0x17000007")]
		public int Count
		{
			[Token(Token = "0x600008A")]
			[Address(RVA = "0x5ECB2F0", Offset = "0x5ECB2F0", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = Il2CppMethodInfo;\n\t*([v17 @ X1_v2 (Il2CppMethodInfo)+10])(v23, *([v17 @ X1_v2 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, 0, &v21 @ stack_-28_v2 (System.Collections.Generic.List`1<T>), v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\treturnVal1 = System.Collections.Generic.List`1<T>::get_Count(v21);\n\treturn returnVal1;\n")]
			get
			{
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v17 @ X1_v2 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				List<T> list = default(List<T>);
				return list.Count;
			}
		}

		[Token(Token = "0x17000008")]
		public bool IsReadOnly
		{
			[Token(Token = "0x600008B")]
			[Address(RVA = "0x5ECB35C", Offset = "0x5ECB35C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x17000009")]
		public unsafe T this[int index]
		{
			[Token(Token = "0x600008F")]
			[Address(RVA = "0x5ECB648", Offset = "0x5ECB648", Length = "0xF4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = *([A4731E0]);\n\tv25 = Il2CppClass<T>;\n\tv29 = *([v25 @ X9_v1 (Il2CppClass<T>)+FC]) + 0xF;\n\tv30 = v29 & 0x1FFFFFFF0;\n\t// 22 StackAlloc v31 @ X21_v1 (System.Byte*), v30 @ X10_v2 (System.Int32)\n\tv41 = Il2CppMethodInfo;\n\t*([v41 @ X1_v3 (Il2CppMethodInfo)+10])(v47, *([v41 @ X1_v3 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, 0, &v45 @ stack_-58_v3, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58);\n\tv77 = Il2CppMethodInfo;\n\tv79 = index;\n\tv45 = &v79 @ stack_-5C_v2 (System.Int32);\n\tv82 = v31;\n\t*([v77 @ X1_v4 (Il2CppMethodInfo)+10])(v86, *([v77 @ X1_v4 (Il2CppMethodInfo)]), Il2CppMethodInfo, &v79 @ stack_-5C_v2 (System.Int32), &v45 @ stack_-58_v3, v31, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58);\n\treturnVal2 = 0x8BF6A1C(il2cppRetVal, v31, *([v25 @ X9_v1 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv138 = *([A4731E0]);\n\tv93 = *([v138 @ X9_v5]) != *([v19 @ X8_v2]);\n\tif (v93) goto L_0052;\n\treturn returnVal2;\nL_0052:\n\treturnVal1 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\n")]
			get
			{
				//IL_0010: Expected O, but got I
				//IL_002c: Expected O, but got I
				//IL_003f: Expected I4, but got I8
				//IL_007a: Expected O, but got I4
				//IL_00ab: Expected O, but got I
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
				object obj = 0;
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X9_v1 (Il2CppClass<T>)+FC]");
				object obj2 = (nint)0 + (nint)15;
				int num2 = (int)((nint)obj2 & 0x1FFFFFFF0L);
				byte* ptr = stackalloc byte[(int)(uint)num2];
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v41 @ X1_v3 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				nint num4 = 0;
				object obj3 = index;
				byte* ptr2 = ptr;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v77 @ X1_v4 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
				object obj4 = 0;
				T result = default(T);
				if (obj4 == obj)
				{
					return result;
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5CF0");
				T result2 = default(T);
				return result2;
			}
			[Token(Token = "0x6000090")]
			[Address(RVA = "0x5ECB73C", Offset = "0x5ECB73C", Length = "0x140")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv27 = *([A4731E0]);\n\tv30 = value;\n\tv35 = Il2CppClass<T>;\n\tv39 = *([v35 @ X9_v1 (Il2CppClass<T>)+FC]) + 0xF;\n\tv40 = v39 & 0x1FFFFFFF0;\n\t// 27 StackAlloc v41 @ X22_v1 (System.Byte*), v40 @ X10_v2 (System.Int32)\n\tv50 = Il2CppMethodInfo;\n\t*([v50 @ X1_v3 (Il2CppMethodInfo)+10])(v57, *([v50 @ X1_v3 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, 0, &v54 @ stack_-78_v3, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv72 = Il2CppClass<T>;\n\tv77 = *([v72 @ X8_v10 (Il2CppClass<T>)+28]) < 0;\n\tv80 = *([v72 @ X8_v10 (Il2CppClass<T>)+28]) ^ *([v72 @ X8_v10 (Il2CppClass<T>)+28]);\n\tv81 = *([v72 @ X8_v10 (Il2CppClass<T>)+28]) & v80;\n\tv82 = v81 < 0;\n\tv84 = v77 == v82;\n\tv85 = ~v84;\n\tv86 = ~v85;\n\tif (v86) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv120 = value;\n\tgoto L_0043;\nL_FFFFFFFF:\n\tv120 = &v30 @ stack_-88_v1 (T);\n\tv230 = Il2CppMethodInfo;\n\tgoto L_004D;\n\treturn;\nL_007B:\n\tv183 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0043:\n\tv118 = 0x8BF6A1C(v41, v120, *([v35 @ X9_v1 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_004D:\n\tv136 = index;\n\tv54 = &v136 @ stack_-7C_v2 (System.Int32);\n\tv133 = v41;\n\t*([v230 @ X1_v5 (Il2CppMethodInfo)+10])(v237, *([v230 @ X1_v5 (Il2CppMethodInfo)]), Il2CppMethodInfo, &v136 @ stack_-7C_v2 (System.Int32), &v54 @ stack_-78_v3, v41, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv168 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<System.Collections.Generic.List`1<T>>::IncreaseCounter(this);\n\tv243 = *([A4731E0]);\n\tv139 = *([v243 @ X9_v5]) != *([v27 @ X8_v2]);\n\tif (v139) goto L_007B;\n")]
			set
			{
				//IL_0010: Expected O, but got I
				//IL_0034: Expected O, but got I
				//IL_0047: Expected I4, but got I8
				//IL_0151: Expected O, but got I4
				//IL_0179: Expected O, but got I
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
				object obj = 0;
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ X9_v1 (Il2CppClass<T>)+FC]");
				object obj2 = (nint)0 + (nint)15;
				int num2 = (int)((nint)obj2 & 0x1FFFFFFF0L);
				byte* ptr = stackalloc byte[(int)(uint)num2];
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X1_v3 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ X8_v10 (Il2CppClass<T>)+28]");
				bool flag = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ X8_v10 (Il2CppClass<T>)+28]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ X8_v10 (Il2CppClass<T>)+28]");
				int num6 = (int)(num5 ^ 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ X8_v10 (Il2CppClass<T>)+28]");
				int num7 = (int)((nint)0 & (nint)num6);
				bool flag2 = num7 < 0;
				if (flag != flag2)
				{
					T val = value;
				}
				else
				{
					T val = value;
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
				nint num8 = 0;
				object obj3 = index;
				IntPtr intPtr = (nint)ptr;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v230 @ X1_v5 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				IncreaseCounter();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
				object obj4 = 0;
				if (obj4 != obj)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5CF0");
				}
			}
		}

		[Token(Token = "0x6000082")]
		[Address(RVA = "0x5ECACE4", Offset = "0x5ECACE4", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv54 = new Il2CppClass<System.Collections.Generic.List`1<T>>();\n\tv60 = System.Collections.Generic.List`1<T>::.ctor(v54);\n\tv65 = Unco.SaveSystem.Core.Variables.PermanentObject`1<System.Collections.Generic.List`1<T>>::.ctor(v65, key, v54, remoteData, lastSavedRemoteTime);\n\treturn;\n")]
		public PermanentList(string key, object remoteData = null, DateTime? lastSavedRemoteTime = null)
			: base(key, new List<T>(), remoteData, lastSavedRemoteTime)
		{
		}

		[Token(Token = "0x6000083")]
		[Address(RVA = "0x5ECAD8C", Offset = "0x5ECAD8C", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = *([A4731E0]);\n\tv17 = Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>;\n\tv21 = *([v17 @ X9_v1 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+FC]) + 0xF;\n\tv22 = v21 & 0x1FFFFFFF0;\n\t// 18 StackAlloc v23 @ X20_v1 (System.Byte*), v22 @ X9_v4 (System.Int32)\n\tv29 = Il2CppMethodInfo;\n\t*([v29 @ X1_v3 (Il2CppMethodInfo)+10])(v35, *([v29 @ X1_v3 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, 0, &v66 @ stack_-30_v5 (System.Byte*), v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv64 = Il2CppMethodInfo;\n\tv66 = v23;\n\t*([v64 @ X1_v4 (Il2CppMethodInfo)+10])(v70, *([v64 @ X1_v4 (Il2CppMethodInfo)]), Il2CppMethodInfo, v23, &v66 @ stack_-30_v5 (System.Byte*), v23, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\t// 46 Box returnVal2 @ X0_v10 (System.Collections.Generic.IEnumerator`1<T>), typeof(Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>), v23 @ X20_v1 (System.Byte*)\n\tv117 = *([A4731E0]);\n\tv78 = *([v117 @ X9_v7]) != *([v11 @ X8_v2]);\n\tif (v78) goto L_0046;\n\treturn returnVal2;\nL_0046:\n\treturnVal1 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\n")]
		public unsafe IEnumerator<T> GetEnumerator()
		{
			//IL_0010: Expected O, but got I
			//IL_002c: Expected O, but got I
			//IL_003f: Expected I4, but got I8
			//IL_0099: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj = 0;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ X9_v1 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+FC]");
			object obj2 = (nint)0 + (nint)15;
			int num2 = (int)((nint)obj2 & 0x1FFFFFFF0L);
			byte* ptr = stackalloc byte[(int)(uint)num2];
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v29 @ X1_v3 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			nint num4 = 0;
			byte* ptr2 = ptr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v64 @ X1_v4 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			IEnumerator<T> result = (IEnumerator<T>)(object)(nint)ptr;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj3 = 0;
			if (obj3 == obj)
			{
				return result;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5CF0");
			IEnumerator<T> result2 = default(IEnumerator<T>);
			return result2;
		}

		[Token(Token = "0x6000084")]
		[Address(RVA = "0x5ECAE64", Offset = "0x5ECAE64", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis = Unco.SaveSystem.Core.Variables.PermanentList`1<T>::GetEnumerator(this);\n\treturn this;\n")]
		IEnumerator IEnumerable.GetEnumerator()
		{
			GetEnumerator();
			return (IEnumerator)this;
		}

		[Token(Token = "0x6000085")]
		[Address(RVA = "0x5ECAE78", Offset = "0x5ECAE78", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = *([A4731E0]);\n\tv26 = v115;\n\tv31 = Il2CppClass<T>;\n\tv35 = *([v31 @ X9_v1 (Il2CppClass<T>)+FC]) + 0xF;\n\tv36 = v35 & 0x1FFFFFFF0;\n\t// 25 StackAlloc v37 @ X21_v1 (System.Byte*), v36 @ X10_v2 (System.Int32)\n\tv44 = Il2CppMethodInfo;\n\t*([v44 @ X1_v3 (Il2CppMethodInfo)+10])(v51, *([v44 @ X1_v3 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, 0, &v152 @ stack_-60_v4 (System.IntPtr), v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv66 = Il2CppClass<T>;\n\tv71 = *([v66 @ X8_v10 (Il2CppClass<T>)+28]) < 0;\n\tv74 = *([v66 @ X8_v10 (Il2CppClass<T>)+28]) ^ *([v66 @ X8_v10 (Il2CppClass<T>)+28]);\n\tv75 = *([v66 @ X8_v10 (Il2CppClass<T>)+28]) & v74;\n\tv76 = v75 < 0;\n\tv78 = v71 == v76;\n\tv79 = ~v78;\n\tv80 = ~v79;\n\tif (v80) goto L_0040;\n\tgoto L_0040;\n\tv211 = Il2CppMethodInfo;\n\tgoto L_004A;\n\treturn;\nL_0073:\n\tv170 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0040:\n\tv113 = 0x8BF6A1C(v37, &v26 @ stack_-68_v1 (T), *([v31 @ X9_v1 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_004A:\n\tv152 = v37;\n\t*([v211 @ X1_v5 (Il2CppMethodInfo)+10])(v217, *([v211 @ X1_v5 (Il2CppMethodInfo)]), Il2CppMethodInfo, v37, &v152 @ stack_-60_v4 (System.IntPtr), v37, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv156 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<System.Collections.Generic.List`1<T>>::IncreaseCounter(this);\n\tv223 = *([A4731E0]);\n\tv127 = *([v223 @ X9_v5]) != *([v23 @ X8_v2]);\n\tif (v127) goto L_0073;\n")]
		public unsafe void Add(T item)
		{
			//IL_0010: Expected O, but got I
			//IL_0034: Expected O, but got I
			//IL_0047: Expected I4, but got I8
			//IL_0154: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj = 0;
			T val2 = default(T);
			T val = val2;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ X9_v1 (Il2CppClass<T>)+FC]");
			object obj2 = (nint)0 + (nint)15;
			int num2 = (int)((nint)obj2 & 0x1FFFFFFF0L);
			byte* ptr = stackalloc byte[(int)(uint)num2];
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v44 @ X1_v3 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X8_v10 (Il2CppClass<T>)+28]");
			bool flag = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X8_v10 (Il2CppClass<T>)+28]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X8_v10 (Il2CppClass<T>)+28]");
			int num6 = (int)(num5 ^ 0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X8_v10 (Il2CppClass<T>)+28]");
			int num7 = (int)((nint)0 & (nint)num6);
			bool flag2 = num7 < 0;
			if (flag != flag2)
			{
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
			nint num8 = 0;
			IntPtr intPtr = (nint)ptr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v211 @ X1_v5 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			IncreaseCounter();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj3 = 0;
			if (obj3 != obj)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5CF0");
			}
		}

		[Token(Token = "0x6000086")]
		[Address(RVA = "0x5ECAFA4", Offset = "0x5ECAFA4", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = Il2CppMethodInfo;\n\t*([v17 @ X1_v2 (Il2CppMethodInfo)+10])(v24, *([v17 @ X1_v2 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, 0, &v21 @ stack_-28_v2 (System.Collections.Generic.List`1<T>), v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv58 = System.Collections.Generic.List`1<T>::Clear(v21);\n\tv64 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<System.Collections.Generic.List`1<T>>::IncreaseCounter(this);\n\treturn;\n")]
		public void Clear()
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v17 @ X1_v2 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			List<T> list = default(List<T>);
			list.Clear();
			IncreaseCounter();
		}

		[Token(Token = "0x6000087")]
		[Address(RVA = "0x5ECB02C", Offset = "0x5ECB02C", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = *([A4731E0]);\n\tv24 = v106;\n\tv28 = Il2CppClass<T>;\n\tv31 = *([v28 @ X9_v1 (Il2CppClass<T>)+FC]) + 0xF;\n\tv32 = v31 & 0x1FFFFFFF0;\n\t// 24 StackAlloc v33 @ X19_v1 (System.Byte*), v32 @ X10_v2 (System.Int32)\n\tv39 = Il2CppMethodInfo;\n\t*([v39 @ X1_v3 (Il2CppMethodInfo)+10])(v45, *([v39 @ X1_v3 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, 0, &v144 @ stack_-50_v4 (System.IntPtr), v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv60 = Il2CppClass<T>;\n\tv65 = *([v60 @ X8_v10 (Il2CppClass<T>)+28]) < 0;\n\tv68 = *([v60 @ X8_v10 (Il2CppClass<T>)+28]) ^ *([v60 @ X8_v10 (Il2CppClass<T>)+28]);\n\tv69 = *([v60 @ X8_v10 (Il2CppClass<T>)+28]) & v68;\n\tv70 = v69 < 0;\n\tv72 = v65 == v70;\n\tv73 = ~v72;\n\tv74 = ~v73;\n\tif (v74) goto L_003D;\n\tgoto L_003D;\n\tv150 = Il2CppMethodInfo;\n\tgoto L_0047;\n\treturn v119;\nL_0069:\n\treturnVal1 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\nL_003D:\n\tv104 = 0x8BF6A1C(v33, &v24 @ stack_-60_v1 (T), *([v28 @ X9_v1 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0047:\n\tv144 = v33;\n\t*([v150 @ X1_v5 (Il2CppMethodInfo)+10])(v206, *([v150 @ X1_v5 (Il2CppMethodInfo)]), Il2CppMethodInfo, v33, &v144 @ stack_-50_v4 (System.IntPtr), &v119 @ stack_-51_v2 (System.Boolean), v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv208 = *([A4731E0]);\n\tv122 = *([v208 @ X9_v5]) != *([v21 @ X8_v2]);\n\tif (v122) goto L_0069;\n")]
		public unsafe bool Contains(T item)
		{
			//IL_0010: Expected O, but got I
			//IL_0034: Expected O, but got I
			//IL_0047: Expected I4, but got I8
			//IL_0156: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj = 0;
			T val2 = default(T);
			T val = val2;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ X9_v1 (Il2CppClass<T>)+FC]");
			object obj2 = (nint)0 + (nint)15;
			int num2 = (int)((nint)obj2 & 0x1FFFFFFF0L);
			byte* ptr = stackalloc byte[(int)(uint)num2];
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v39 @ X1_v3 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ X8_v10 (Il2CppClass<T>)+28]");
			bool flag = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ X8_v10 (Il2CppClass<T>)+28]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ X8_v10 (Il2CppClass<T>)+28]");
			int num6 = (int)(num5 ^ 0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ X8_v10 (Il2CppClass<T>)+28]");
			int num7 = (int)((nint)0 & (nint)num6);
			bool flag2 = num7 < 0;
			if (flag != flag2)
			{
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
			nint num8 = 0;
			IntPtr intPtr = (nint)ptr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v150 @ X1_v5 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj3 = 0;
			bool result = default(bool);
			if (obj3 == obj)
			{
				return result;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5CF0");
			bool result2 = default(bool);
			return result2;
		}

		[Token(Token = "0x6000088")]
		[Address(RVA = "0x5ECB138", Offset = "0x5ECB138", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = Il2CppMethodInfo;\n\t*([v25 @ X1_v2 (Il2CppMethodInfo)+10])(v31, *([v25 @ X1_v2 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, 0, &v29 @ stack_-38_v2 (System.Collections.Generic.List`1<T>), v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv66 = System.Collections.Generic.List`1<T>::CopyTo(v29, array, arrayIndex);\n\treturn;\n")]
		public void CopyTo(T[] array, int arrayIndex)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v25 @ X1_v2 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			List<T> list = default(List<T>);
			list.CopyTo(array, arrayIndex);
		}

		[Token(Token = "0x6000089")]
		[Address(RVA = "0x5ECB1BC", Offset = "0x5ECB1BC", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = *([A4731E0]);\n\tv26 = v114;\n\tv31 = Il2CppClass<T>;\n\tv34 = *([v31 @ X9_v1 (Il2CppClass<T>)+FC]) + 0xF;\n\tv35 = v34 & 0x1FFFFFFF0;\n\t// 25 StackAlloc v36 @ X21_v1 (System.Byte*), v35 @ X10_v2 (System.Int32)\n\tv43 = Il2CppMethodInfo;\n\t*([v43 @ X1_v3 (Il2CppMethodInfo)+10])(v50, *([v43 @ X1_v3 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, 0, &v154 @ stack_-60_v4 (System.IntPtr), v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv65 = Il2CppClass<T>;\n\tv70 = *([v65 @ X8_v10 (Il2CppClass<T>)+28]) < 0;\n\tv73 = *([v65 @ X8_v10 (Il2CppClass<T>)+28]) ^ *([v65 @ X8_v10 (Il2CppClass<T>)+28]);\n\tv74 = *([v65 @ X8_v10 (Il2CppClass<T>)+28]) & v73;\n\tv75 = v74 < 0;\n\tv77 = v70 == v75;\n\tv78 = ~v77;\n\tv79 = ~v78;\n\tif (v79) goto L_0040;\n\tgoto L_0040;\n\tv215 = Il2CppMethodInfo;\n\tgoto L_004A;\n\treturn v126;\nL_0075:\n\treturnVal1 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\nL_0040:\n\tv112 = 0x8BF6A1C(v36, &v26 @ stack_-70_v1 (T), *([v31 @ X9_v1 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_004A:\n\tv154 = v36;\n\t*([v215 @ X1_v5 (Il2CppMethodInfo)+10])(v222, *([v215 @ X1_v5 (Il2CppMethodInfo)]), Il2CppMethodInfo, v36, &v154 @ stack_-60_v4 (System.IntPtr), &v126 @ stack_-61_v2 (System.Boolean), v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv158 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<System.Collections.Generic.List`1<T>>::IncreaseCounter(this);\n\tv228 = *([A4731E0]);\n\tv129 = *([v228 @ X9_v5]) != *([v23 @ X8_v2]);\n\tif (v129) goto L_0075;\n")]
		public unsafe bool Remove(T item)
		{
			//IL_0010: Expected O, but got I
			//IL_0034: Expected O, but got I
			//IL_0047: Expected I4, but got I8
			//IL_015c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj = 0;
			T val2 = default(T);
			T val = val2;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ X9_v1 (Il2CppClass<T>)+FC]");
			object obj2 = (nint)0 + (nint)15;
			int num2 = (int)((nint)obj2 & 0x1FFFFFFF0L);
			byte* ptr = stackalloc byte[(int)(uint)num2];
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v43 @ X1_v3 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ X8_v10 (Il2CppClass<T>)+28]");
			bool flag = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ X8_v10 (Il2CppClass<T>)+28]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ X8_v10 (Il2CppClass<T>)+28]");
			int num6 = (int)(num5 ^ 0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ X8_v10 (Il2CppClass<T>)+28]");
			int num7 = (int)((nint)0 & (nint)num6);
			bool flag2 = num7 < 0;
			if (flag != flag2)
			{
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
			nint num8 = 0;
			IntPtr intPtr = (nint)ptr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v215 @ X1_v5 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			IncreaseCounter();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj3 = 0;
			bool result = default(bool);
			if (obj3 == obj)
			{
				return result;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5CF0");
			bool result2 = default(bool);
			return result2;
		}

		[Token(Token = "0x600008C")]
		[Address(RVA = "0x5ECB364", Offset = "0x5ECB364", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = *([A4731E0]);\n\tv24 = v106;\n\tv28 = Il2CppClass<T>;\n\tv31 = *([v28 @ X9_v1 (Il2CppClass<T>)+FC]) + 0xF;\n\tv32 = v31 & 0x1FFFFFFF0;\n\t// 24 StackAlloc v33 @ X19_v1 (System.Byte*), v32 @ X10_v2 (System.Int32)\n\tv39 = Il2CppMethodInfo;\n\t*([v39 @ X1_v3 (Il2CppMethodInfo)+10])(v45, *([v39 @ X1_v3 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, 0, &v144 @ stack_-50_v4 (System.IntPtr), v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv60 = Il2CppClass<T>;\n\tv65 = *([v60 @ X8_v10 (Il2CppClass<T>)+28]) < 0;\n\tv68 = *([v60 @ X8_v10 (Il2CppClass<T>)+28]) ^ *([v60 @ X8_v10 (Il2CppClass<T>)+28]);\n\tv69 = *([v60 @ X8_v10 (Il2CppClass<T>)+28]) & v68;\n\tv70 = v69 < 0;\n\tv72 = v65 == v70;\n\tv73 = ~v72;\n\tv74 = ~v73;\n\tif (v74) goto L_003D;\n\tgoto L_003D;\n\tv150 = Il2CppMethodInfo;\n\tgoto L_0047;\n\treturn v119;\nL_0069:\n\treturnVal1 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\nL_003D:\n\tv104 = 0x8BF6A1C(v33, &v24 @ stack_-60_v1 (T), *([v28 @ X9_v1 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0047:\n\tv144 = v33;\n\t*([v150 @ X1_v5 (Il2CppMethodInfo)+10])(v206, *([v150 @ X1_v5 (Il2CppMethodInfo)]), Il2CppMethodInfo, v33, &v144 @ stack_-50_v4 (System.IntPtr), &v119 @ stack_-54_v2 (System.Int32), v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv208 = *([A4731E0]);\n\tv122 = *([v208 @ X9_v5]) != *([v21 @ X8_v2]);\n\tif (v122) goto L_0069;\n")]
		public unsafe int IndexOf(T item)
		{
			//IL_0010: Expected O, but got I
			//IL_0034: Expected O, but got I
			//IL_0047: Expected I4, but got I8
			//IL_0156: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj = 0;
			T val2 = default(T);
			T val = val2;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ X9_v1 (Il2CppClass<T>)+FC]");
			object obj2 = (nint)0 + (nint)15;
			int num2 = (int)((nint)obj2 & 0x1FFFFFFF0L);
			byte* ptr = stackalloc byte[(int)(uint)num2];
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v39 @ X1_v3 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ X8_v10 (Il2CppClass<T>)+28]");
			bool flag = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ X8_v10 (Il2CppClass<T>)+28]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ X8_v10 (Il2CppClass<T>)+28]");
			int num6 = (int)(num5 ^ 0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ X8_v10 (Il2CppClass<T>)+28]");
			int num7 = (int)((nint)0 & (nint)num6);
			bool flag2 = num7 < 0;
			if (flag != flag2)
			{
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
			nint num8 = 0;
			IntPtr intPtr = (nint)ptr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v150 @ X1_v5 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj3 = 0;
			int result = default(int);
			if (obj3 == obj)
			{
				return result;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5CF0");
			int result2 = default(int);
			return result2;
		}

		[Token(Token = "0x600008D")]
		[Address(RVA = "0x5ECB470", Offset = "0x5ECB470", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv27 = *([A4731E0]);\n\tv30 = item;\n\tv35 = Il2CppClass<T>;\n\tv39 = *([v35 @ X9_v1 (Il2CppClass<T>)+FC]) + 0xF;\n\tv40 = v39 & 0x1FFFFFFF0;\n\t// 27 StackAlloc v41 @ X22_v1 (System.Byte*), v40 @ X10_v2 (System.Int32)\n\tv50 = Il2CppMethodInfo;\n\t*([v50 @ X1_v3 (Il2CppMethodInfo)+10])(v57, *([v50 @ X1_v3 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, 0, &v54 @ stack_-78_v3, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv72 = Il2CppClass<T>;\n\tv77 = *([v72 @ X8_v10 (Il2CppClass<T>)+28]) < 0;\n\tv80 = *([v72 @ X8_v10 (Il2CppClass<T>)+28]) ^ *([v72 @ X8_v10 (Il2CppClass<T>)+28]);\n\tv81 = *([v72 @ X8_v10 (Il2CppClass<T>)+28]) & v80;\n\tv82 = v81 < 0;\n\tv84 = v77 == v82;\n\tv85 = ~v84;\n\tv86 = ~v85;\n\tif (v86) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv120 = item;\n\tgoto L_0043;\nL_FFFFFFFF:\n\tv120 = &v30 @ stack_-88_v1 (T);\n\tv230 = Il2CppMethodInfo;\n\tgoto L_004D;\n\treturn;\nL_007B:\n\tv183 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0043:\n\tv118 = 0x8BF6A1C(v41, v120, *([v35 @ X9_v1 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_004D:\n\tv136 = index;\n\tv54 = &v136 @ stack_-7C_v2 (System.Int32);\n\tv133 = v41;\n\t*([v230 @ X1_v5 (Il2CppMethodInfo)+10])(v237, *([v230 @ X1_v5 (Il2CppMethodInfo)]), Il2CppMethodInfo, &v136 @ stack_-7C_v2 (System.Int32), &v54 @ stack_-78_v3, v41, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv168 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<System.Collections.Generic.List`1<T>>::IncreaseCounter(this);\n\tv243 = *([A4731E0]);\n\tv139 = *([v243 @ X9_v5]) != *([v27 @ X8_v2]);\n\tif (v139) goto L_007B;\n")]
		public unsafe void Insert(int index, T item)
		{
			//IL_0010: Expected O, but got I
			//IL_0034: Expected O, but got I
			//IL_0047: Expected I4, but got I8
			//IL_0151: Expected O, but got I4
			//IL_0179: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj = 0;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ X9_v1 (Il2CppClass<T>)+FC]");
			object obj2 = (nint)0 + (nint)15;
			int num2 = (int)((nint)obj2 & 0x1FFFFFFF0L);
			byte* ptr = stackalloc byte[(int)(uint)num2];
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X1_v3 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ X8_v10 (Il2CppClass<T>)+28]");
			bool flag = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ X8_v10 (Il2CppClass<T>)+28]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ X8_v10 (Il2CppClass<T>)+28]");
			int num6 = (int)(num5 ^ 0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ X8_v10 (Il2CppClass<T>)+28]");
			int num7 = (int)((nint)0 & (nint)num6);
			bool flag2 = num7 < 0;
			if (flag != flag2)
			{
				T val = item;
			}
			else
			{
				T val = item;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
			nint num8 = 0;
			object obj3 = index;
			IntPtr intPtr = (nint)ptr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v230 @ X1_v5 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			IncreaseCounter();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj4 = 0;
			if (obj4 != obj)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5CF0");
			}
		}

		[Token(Token = "0x600008E")]
		[Address(RVA = "0x5ECB5B0", Offset = "0x5ECB5B0", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = Il2CppMethodInfo;\n\t*([v23 @ X1_v2 (Il2CppMethodInfo)+10])(v30, *([v23 @ X1_v2 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, 0, &v27 @ stack_-38_v2 (System.Collections.Generic.List`1<T>), v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv65 = System.Collections.Generic.List`1<T>::RemoveAt(v27, index);\n\tv71 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<System.Collections.Generic.List`1<T>>::IncreaseCounter(this);\n\treturn;\n")]
		public void RemoveAt(int index)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v23 @ X1_v2 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			List<T> list = default(List<T>);
			list.RemoveAt(index);
			IncreaseCounter();
		}
	}
}
