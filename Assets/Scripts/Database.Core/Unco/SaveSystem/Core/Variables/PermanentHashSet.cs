using System;
using System.Collections;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.SaveSystem.Core.Variables
{
	[Serializable]
	[Token(Token = "0x2000012")]
	public class PermanentHashSet<T> : PermanentObject<HashSet<T>>, ISet<T>, ICollection<T>, IEnumerable<T>, IEnumerable, ISerializationCallbackReceiver
	{
		[SerializeField]
		[Token(Token = "0x4000011")]
		[FieldOffset(Offset = "0x0")]
		private List<T> _items = new List<T>();

		[Token(Token = "0x17000005")]
		public int Count
		{
			[Token(Token = "0x6000063")]
			[Address(RVA = "0x5ECA340", Offset = "0x5ECA340", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = Il2CppMethodInfo;\n\t*([v17 @ X1_v2 (Il2CppMethodInfo)+10])(v23, *([v17 @ X1_v2 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, 0, &v21 @ stack_-28_v2 (System.Collections.Generic.HashSet`1<T>), v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\treturnVal1 = System.Collections.Generic.HashSet`1<T>::get_Count(v21);\n\treturn returnVal1;\n")]
			get
			{
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v17 @ X1_v2 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				HashSet<T> hashSet = default(HashSet<T>);
				return hashSet.Count;
			}
		}

		[Token(Token = "0x17000006")]
		public bool IsReadOnly
		{
			[Token(Token = "0x6000064")]
			[Address(RVA = "0x5ECA3AC", Offset = "0x5ECA3AC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x600005A")]
		[Address(RVA = "0x5EC9C14", Offset = "0x5EC9C14", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv54 = new Il2CppClass<System.Collections.Generic.List`1<T>>();\n\tv60 = System.Collections.Generic.List`1<T>::.ctor(v54);\n\tthis._items = v54;\n\tgoto L_0032;\nL_0032:\n\tv75 = new Il2CppClass<System.Collections.Generic.HashSet`1<T>>();\n\tv81 = System.Collections.Generic.HashSet`1<T>::.ctor(v75);\n\tv86 = Unco.SaveSystem.Core.Variables.PermanentObject`1<System.Collections.Generic.HashSet`1<T>>::.ctor(v86, key, v75, remoteData, lastSavedRemoteTime);\n\treturn;\n")]
		internal PermanentHashSet(string key, object remoteData = null, DateTime? lastSavedRemoteTime = null)
			: base(key, new HashSet<T>(), remoteData, lastSavedRemoteTime)
		{
			_items = new List<T>();
		}

		[Token(Token = "0x600005B")]
		[Address(RVA = "0x5EC9D04", Offset = "0x5EC9D04", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = *([A4731E0]);\n\tv17 = Il2CppClass<System.Collections.Generic.HashSet`1<T>+Enumerator<T>>;\n\tv21 = *([v17 @ X9_v1 (Il2CppClass<System.Collections.Generic.HashSet`1<T>+Enumerator<T>>)+FC]) + 0xF;\n\tv22 = v21 & 0x1FFFFFFF0;\n\t// 18 StackAlloc v23 @ X20_v1 (System.Byte*), v22 @ X9_v4 (System.Int32)\n\tv29 = Il2CppMethodInfo;\n\t*([v29 @ X1_v3 (Il2CppMethodInfo)+10])(v35, *([v29 @ X1_v3 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, 0, &v66 @ stack_-30_v5 (System.Byte*), v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv64 = Il2CppMethodInfo;\n\tv66 = v23;\n\t*([v64 @ X1_v4 (Il2CppMethodInfo)+10])(v70, *([v64 @ X1_v4 (Il2CppMethodInfo)]), Il2CppMethodInfo, v23, &v66 @ stack_-30_v5 (System.Byte*), v23, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\t// 46 Box returnVal2 @ X0_v10 (System.Collections.Generic.IEnumerator`1<T>), typeof(Il2CppClass<System.Collections.Generic.HashSet`1<T>+Enumerator<T>>), v23 @ X20_v1 (System.Byte*)\n\tv117 = *([A4731E0]);\n\tv78 = *([v117 @ X9_v7]) != *([v11 @ X8_v2]);\n\tif (v78) goto L_0046;\n\treturn returnVal2;\nL_0046:\n\treturnVal1 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\n")]
		public unsafe IEnumerator<T> GetEnumerator()
		{
			//IL_0010: Expected O, but got I
			//IL_002c: Expected O, but got I
			//IL_003f: Expected I4, but got I8
			//IL_0099: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj = 0;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ X9_v1 (Il2CppClass<System.Collections.Generic.HashSet`1<T>+Enumerator<T>>)+FC]");
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

		[Token(Token = "0x600005C")]
		[Address(RVA = "0x5EC9DDC", Offset = "0x5EC9DDC", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis = Unco.SaveSystem.Core.Variables.PermanentHashSet`1<T>::GetEnumerator(this);\n\treturn this;\n")]
		IEnumerator IEnumerable.GetEnumerator()
		{
			GetEnumerator();
			return (IEnumerator)this;
		}

		[Token(Token = "0x600005D")]
		[Address(RVA = "0x5EC9DF0", Offset = "0x5EC9DF0", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = *([A4731E0]);\n\tv26 = v114;\n\tv31 = Il2CppClass<T>;\n\tv34 = *([v31 @ X9_v1 (Il2CppClass<T>)+FC]) + 0xF;\n\tv35 = v34 & 0x1FFFFFFF0;\n\t// 25 StackAlloc v36 @ X21_v1 (System.Byte*), v35 @ X10_v2 (System.Int32)\n\tv43 = Il2CppMethodInfo;\n\t*([v43 @ X1_v3 (Il2CppMethodInfo)+10])(v50, *([v43 @ X1_v3 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, 0, &v154 @ stack_-60_v4 (System.IntPtr), v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv65 = Il2CppClass<T>;\n\tv70 = *([v65 @ X8_v10 (Il2CppClass<T>)+28]) < 0;\n\tv73 = *([v65 @ X8_v10 (Il2CppClass<T>)+28]) ^ *([v65 @ X8_v10 (Il2CppClass<T>)+28]);\n\tv74 = *([v65 @ X8_v10 (Il2CppClass<T>)+28]) & v73;\n\tv75 = v74 < 0;\n\tv77 = v70 == v75;\n\tv78 = ~v77;\n\tv79 = ~v78;\n\tif (v79) goto L_0040;\n\tgoto L_0040;\n\tv215 = Il2CppMethodInfo;\n\tgoto L_004A;\n\tv238 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<System.Collections.Generic.HashSet`1<T>>::IncreaseCounter(this);\n\treturn v126;\nL_0080:\n\treturnVal1 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\nL_0040:\n\tv112 = 0x8BF6A1C(v36, &v26 @ stack_-70_v1 (T), *([v31 @ X9_v1 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_004A:\n\tv154 = v36;\n\t*([v215 @ X1_v5 (Il2CppMethodInfo)+10])(v222, *([v215 @ X1_v5 (Il2CppMethodInfo)]), Il2CppMethodInfo, v36, &v154 @ stack_-60_v4 (System.IntPtr), &v126 @ stack_-61_v2 (System.Boolean), v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv232 = v126 != 1;\n\tif (v232) goto L_0064;\nL_0064:\n\tv241 = *([A4731E0]);\n\tv129 = *([v241 @ X9_v5]) != *([v23 @ X8_v2]);\n\tif (v129) goto L_0080;\n")]
		public unsafe bool Add(T item)
		{
			//IL_0010: Expected O, but got I
			//IL_0034: Expected O, but got I
			//IL_0047: Expected I4, but got I8
			//IL_0181: Expected O, but got I
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
			bool flag3 = default(bool);
			if (flag3)
			{
				IncreaseCounter();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj3 = 0;
			if (obj3 == obj)
			{
				return flag3;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5CF0");
			bool result = default(bool);
			return result;
		}

		[Token(Token = "0x600005E")]
		[Address(RVA = "0x5EC9F2C", Offset = "0x5EC9F2C", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = *([A4731E0]);\n\tv20 = v48;\n\tv25 = Il2CppClass<T>;\n\tv28 = *([v25 @ X8_v5 (Il2CppClass<T>)+FC]) + 0xF;\n\tv29 = v28 & 0x1FFFFFFF0;\n\t// 22 StackAlloc v30 @ X20_v1 (System.Byte*), v29 @ X10_v2 (System.Int32)\n\tv36 = *([v25 @ X8_v5 (Il2CppClass<T>)+28]) < 0;\n\tv39 = *([v25 @ X8_v5 (Il2CppClass<T>)+28]) ^ *([v25 @ X8_v5 (Il2CppClass<T>)+28]);\n\tv40 = *([v25 @ X8_v5 (Il2CppClass<T>)+28]) & v39;\n\tv41 = v40 < 0;\n\tv43 = v36 == v41;\n\tv44 = ~v43;\n\tv45 = ~v44;\n\tif (v45) goto L_002C;\n\tgoto L_002C;\n\treturn;\nL_0052:\n\tv98 = 0x8BF5CF0(v77, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_002C:\n\tv50 = 0x8BF6A1C(v30, &v20 @ stack_-50_v1 (T), *([v25 @ X8_v5 (Il2CppClass<T>)+FC]), v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv64 = Il2CppMethodInfo;\n\tgoto L_0034;\nL_0034:\n\tv71 = v30;\n\t*([v64 @ X1_v2 (Il2CppMethodInfo)+10])(v77, *([v64 @ X1_v2 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, &v71 @ stack_-40_v1 (System.IntPtr), &v75 @ stack_-41, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv80 = *([A4731E0]);\n\tv91 = *([v80 @ X9_v3]) != *([v17 @ X8_v2]);\n\tif (v91) goto L_0052;\n")]
		unsafe void ICollection<T>.Add(T item)
		{
			//IL_0010: Expected O, but got I
			//IL_0034: Expected O, but got I
			//IL_0047: Expected I4, but got I8
			//IL_012e: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj = 0;
			T val2 = default(T);
			T val = val2;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X8_v5 (Il2CppClass<T>)+FC]");
			object obj2 = (nint)0 + (nint)15;
			int num2 = (int)((nint)obj2 & 0x1FFFFFFF0L);
			byte* ptr = stackalloc byte[(int)(uint)num2];
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X8_v5 (Il2CppClass<T>)+28]");
			bool flag = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X8_v5 (Il2CppClass<T>)+28]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X8_v5 (Il2CppClass<T>)+28]");
			int num4 = (int)(num3 ^ 0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X8_v5 (Il2CppClass<T>)+28]");
			int num5 = (int)((nint)0 & (nint)num4);
			bool flag2 = num5 < 0;
			if (flag != flag2)
			{
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
			nint num6 = 0;
			IntPtr intPtr = (nint)ptr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v64 @ X1_v2 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj3 = 0;
			if (obj3 != obj)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5CF0");
			}
		}

		[Token(Token = "0x600005F")]
		[Address(RVA = "0x5EC9FEC", Offset = "0x5EC9FEC", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = Il2CppMethodInfo;\n\t*([v17 @ X1_v2 (Il2CppMethodInfo)+10])(v24, *([v17 @ X1_v2 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, 0, &v21 @ stack_-28_v2 (System.Collections.Generic.HashSet`1<T>), v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv58 = System.Collections.Generic.HashSet`1<T>::Clear(v21);\n\tv64 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<System.Collections.Generic.HashSet`1<T>>::IncreaseCounter(this);\n\treturn;\n")]
		public void Clear()
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v17 @ X1_v2 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			HashSet<T> hashSet = default(HashSet<T>);
			hashSet.Clear();
			IncreaseCounter();
		}

		[Token(Token = "0x6000060")]
		[Address(RVA = "0x5ECA074", Offset = "0x5ECA074", Length = "0x10C")]
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

		[Token(Token = "0x6000061")]
		[Address(RVA = "0x5ECA180", Offset = "0x5ECA180", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = Il2CppMethodInfo;\n\t*([v25 @ X1_v2 (Il2CppMethodInfo)+10])(v31, *([v25 @ X1_v2 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, 0, &v29 @ stack_-38_v2 (System.Collections.Generic.HashSet`1<T>), v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv66 = System.Collections.Generic.HashSet`1<T>::CopyTo(v29, array, arrayIndex);\n\treturn;\n")]
		public void CopyTo(T[] array, int arrayIndex)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v25 @ X1_v2 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			HashSet<T> hashSet = default(HashSet<T>);
			hashSet.CopyTo(array, arrayIndex);
		}

		[Token(Token = "0x6000062")]
		[Address(RVA = "0x5ECA204", Offset = "0x5ECA204", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = *([A4731E0]);\n\tv26 = v114;\n\tv31 = Il2CppClass<T>;\n\tv34 = *([v31 @ X9_v1 (Il2CppClass<T>)+FC]) + 0xF;\n\tv35 = v34 & 0x1FFFFFFF0;\n\t// 25 StackAlloc v36 @ X21_v1 (System.Byte*), v35 @ X10_v2 (System.Int32)\n\tv43 = Il2CppMethodInfo;\n\t*([v43 @ X1_v3 (Il2CppMethodInfo)+10])(v50, *([v43 @ X1_v3 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, 0, &v154 @ stack_-60_v4 (System.IntPtr), v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv65 = Il2CppClass<T>;\n\tv70 = *([v65 @ X8_v10 (Il2CppClass<T>)+28]) < 0;\n\tv73 = *([v65 @ X8_v10 (Il2CppClass<T>)+28]) ^ *([v65 @ X8_v10 (Il2CppClass<T>)+28]);\n\tv74 = *([v65 @ X8_v10 (Il2CppClass<T>)+28]) & v73;\n\tv75 = v74 < 0;\n\tv77 = v70 == v75;\n\tv78 = ~v77;\n\tv79 = ~v78;\n\tif (v79) goto L_0040;\n\tgoto L_0040;\n\tv215 = Il2CppMethodInfo;\n\tgoto L_004A;\n\tv238 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<System.Collections.Generic.HashSet`1<T>>::IncreaseCounter(this);\n\treturn v126;\nL_0080:\n\treturnVal1 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\nL_0040:\n\tv112 = 0x8BF6A1C(v36, &v26 @ stack_-70_v1 (T), *([v31 @ X9_v1 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_004A:\n\tv154 = v36;\n\t*([v215 @ X1_v5 (Il2CppMethodInfo)+10])(v222, *([v215 @ X1_v5 (Il2CppMethodInfo)]), Il2CppMethodInfo, v36, &v154 @ stack_-60_v4 (System.IntPtr), &v126 @ stack_-61_v2 (System.Boolean), v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv232 = v126 != 1;\n\tif (v232) goto L_0064;\nL_0064:\n\tv241 = *([A4731E0]);\n\tv129 = *([v241 @ X9_v5]) != *([v23 @ X8_v2]);\n\tif (v129) goto L_0080;\n")]
		public unsafe bool Remove(T item)
		{
			//IL_0010: Expected O, but got I
			//IL_0034: Expected O, but got I
			//IL_0047: Expected I4, but got I8
			//IL_0181: Expected O, but got I
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
			bool flag3 = default(bool);
			if (flag3)
			{
				IncreaseCounter();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj3 = 0;
			if (obj3 == obj)
			{
				return flag3;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5CF0");
			bool result = default(bool);
			return result;
		}

		[Token(Token = "0x6000065")]
		[Address(RVA = "0x5ECA3B4", Offset = "0x5ECA3B4", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = Il2CppMethodInfo;\n\t*([v23 @ X1_v2 (Il2CppMethodInfo)+10])(v30, *([v23 @ X1_v2 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, 0, &v27 @ stack_-38_v2 (System.Collections.Generic.HashSet`1<T>), v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv65 = System.Collections.Generic.HashSet`1<T>::ExceptWith(v27, other);\n\tv71 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<System.Collections.Generic.HashSet`1<T>>::IncreaseCounter(this);\n\treturn;\n")]
		public void ExceptWith(IEnumerable<T> other)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v23 @ X1_v2 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			HashSet<T> hashSet = default(HashSet<T>);
			hashSet.ExceptWith(other);
			IncreaseCounter();
		}

		[Token(Token = "0x6000066")]
		[Address(RVA = "0x5ECA44C", Offset = "0x5ECA44C", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = Il2CppMethodInfo;\n\t*([v23 @ X1_v2 (Il2CppMethodInfo)+10])(v30, *([v23 @ X1_v2 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, 0, &v27 @ stack_-38_v2 (System.Collections.Generic.HashSet`1<T>), v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv65 = System.Collections.Generic.HashSet`1<T>::IntersectWith(v27, other);\n\tv71 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<System.Collections.Generic.HashSet`1<T>>::IncreaseCounter(this);\n\treturn;\n")]
		public void IntersectWith(IEnumerable<T> other)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v23 @ X1_v2 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			HashSet<T> hashSet = default(HashSet<T>);
			hashSet.IntersectWith(other);
			IncreaseCounter();
		}

		[Token(Token = "0x6000067")]
		[Address(RVA = "0x5ECA4E4", Offset = "0x5ECA4E4", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = Il2CppMethodInfo;\n\t*([v19 @ X1_v2 (Il2CppMethodInfo)+10])(v25, *([v19 @ X1_v2 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, 0, &v23 @ stack_-28_v2 (System.Collections.Generic.HashSet`1<T>), v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\treturnVal1 = System.Collections.Generic.HashSet`1<T>::IsProperSubsetOf(v23, other);\n\treturn returnVal1;\n")]
		public bool IsProperSubsetOf(IEnumerable<T> other)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v19 @ X1_v2 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			HashSet<T> hashSet = default(HashSet<T>);
			return hashSet.IsProperSubsetOf(other);
		}

		[Token(Token = "0x6000068")]
		[Address(RVA = "0x5ECA558", Offset = "0x5ECA558", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = Il2CppMethodInfo;\n\t*([v19 @ X1_v2 (Il2CppMethodInfo)+10])(v25, *([v19 @ X1_v2 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, 0, &v23 @ stack_-28_v2 (System.Collections.Generic.HashSet`1<T>), v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\treturnVal1 = System.Collections.Generic.HashSet`1<T>::IsProperSupersetOf(v23, other);\n\treturn returnVal1;\n")]
		public bool IsProperSupersetOf(IEnumerable<T> other)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v19 @ X1_v2 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			HashSet<T> hashSet = default(HashSet<T>);
			return hashSet.IsProperSupersetOf(other);
		}

		[Token(Token = "0x6000069")]
		[Address(RVA = "0x5ECA5CC", Offset = "0x5ECA5CC", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = Il2CppMethodInfo;\n\t*([v19 @ X1_v2 (Il2CppMethodInfo)+10])(v25, *([v19 @ X1_v2 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, 0, &v23 @ stack_-28_v2 (System.Collections.Generic.HashSet`1<T>), v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\treturnVal1 = System.Collections.Generic.HashSet`1<T>::IsSubsetOf(v23, other);\n\treturn returnVal1;\n")]
		public bool IsSubsetOf(IEnumerable<T> other)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v19 @ X1_v2 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			HashSet<T> hashSet = default(HashSet<T>);
			return hashSet.IsSubsetOf(other);
		}

		[Token(Token = "0x600006A")]
		[Address(RVA = "0x5ECA640", Offset = "0x5ECA640", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = Il2CppMethodInfo;\n\t*([v19 @ X1_v2 (Il2CppMethodInfo)+10])(v25, *([v19 @ X1_v2 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, 0, &v23 @ stack_-28_v2 (System.Collections.Generic.HashSet`1<T>), v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\treturnVal1 = System.Collections.Generic.HashSet`1<T>::IsSupersetOf(v23, other);\n\treturn returnVal1;\n")]
		public bool IsSupersetOf(IEnumerable<T> other)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v19 @ X1_v2 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			HashSet<T> hashSet = default(HashSet<T>);
			return hashSet.IsSupersetOf(other);
		}

		[Token(Token = "0x600006B")]
		[Address(RVA = "0x5ECA6B4", Offset = "0x5ECA6B4", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = Il2CppMethodInfo;\n\t*([v19 @ X1_v2 (Il2CppMethodInfo)+10])(v25, *([v19 @ X1_v2 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, 0, &v23 @ stack_-28_v2 (System.Collections.Generic.HashSet`1<T>), v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\treturnVal1 = System.Collections.Generic.HashSet`1<T>::Overlaps(v23, other);\n\treturn returnVal1;\n")]
		public bool Overlaps(IEnumerable<T> other)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v19 @ X1_v2 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			HashSet<T> hashSet = default(HashSet<T>);
			return hashSet.Overlaps(other);
		}

		[Token(Token = "0x600006C")]
		[Address(RVA = "0x5ECA728", Offset = "0x5ECA728", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = Il2CppMethodInfo;\n\t*([v19 @ X1_v2 (Il2CppMethodInfo)+10])(v25, *([v19 @ X1_v2 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, 0, &v23 @ stack_-28_v2 (System.Collections.Generic.HashSet`1<T>), v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\treturnVal1 = System.Collections.Generic.HashSet`1<T>::SetEquals(v23, other);\n\treturn returnVal1;\n")]
		public bool SetEquals(IEnumerable<T> other)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v19 @ X1_v2 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			HashSet<T> hashSet = default(HashSet<T>);
			return hashSet.SetEquals(other);
		}

		[Token(Token = "0x600006D")]
		[Address(RVA = "0x5ECA79C", Offset = "0x5ECA79C", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = Il2CppMethodInfo;\n\t*([v23 @ X1_v2 (Il2CppMethodInfo)+10])(v30, *([v23 @ X1_v2 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, 0, &v27 @ stack_-38_v2 (System.Collections.Generic.HashSet`1<T>), v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv65 = System.Collections.Generic.HashSet`1<T>::SymmetricExceptWith(v27, other);\n\tv71 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<System.Collections.Generic.HashSet`1<T>>::IncreaseCounter(this);\n\treturn;\n")]
		public void SymmetricExceptWith(IEnumerable<T> other)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v23 @ X1_v2 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			HashSet<T> hashSet = default(HashSet<T>);
			hashSet.SymmetricExceptWith(other);
			IncreaseCounter();
		}

		[Token(Token = "0x600006E")]
		[Address(RVA = "0x5ECA834", Offset = "0x5ECA834", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = Il2CppMethodInfo;\n\t*([v23 @ X1_v2 (Il2CppMethodInfo)+10])(v30, *([v23 @ X1_v2 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, 0, &v27 @ stack_-38_v2 (System.Collections.Generic.HashSet`1<T>), v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv65 = System.Collections.Generic.HashSet`1<T>::UnionWith(v27, other);\n\tv71 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<System.Collections.Generic.HashSet`1<T>>::IncreaseCounter(this);\n\treturn;\n")]
		public void UnionWith(IEnumerable<T> other)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v23 @ X1_v2 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			HashSet<T> hashSet = default(HashSet<T>);
			hashSet.UnionWith(other);
			IncreaseCounter();
		}

		[Token(Token = "0x600006F")]
		[Address(RVA = "0x5ECA8CC", Offset = "0x5ECA8CC", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = System.Collections.Generic.List`1<T>::Clear(this._items);\n\tv42 = Il2CppMethodInfo;\n\t*([v42 @ X1_v3 (Il2CppMethodInfo)+10])(v49, *([v42 @ X1_v3 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, 0, &v46 @ stack_-38_v2 (System.Collections.Generic.IEnumerable`1<T>), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv70 = System.Collections.Generic.List`1<T>::AddRange(this._items, v46);\n\treturn;\n")]
		public void OnBeforeSerialize()
		{
			_items.Clear();
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v42 @ X1_v3 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			IEnumerable<T> collection = default(IEnumerable<T>);
			_items.AddRange(collection);
		}

		[Token(Token = "0x6000070")]
		[Address(RVA = "0x5ECA964", Offset = "0x5ECA964", Length = "0x380")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv31 = *([A4731E0]);\n\tv37 = Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>;\n\tv39 = Il2CppClass<T>;\n\tgoto L_0025;\n\tv101 = Il2CppMethodInfo;\n\t*([v101 @ X1_v7 (Il2CppMethodInfo)+10])(v108, *([v101 @ X1_v7 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, 0, &v105 @ stack_-90_v5 (System.Collections.Generic.HashSet`1<T>), v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv110 = v105 == 0;\n\tif (v110) goto L_00EC;\n\tv116 = System.Collections.Generic.HashSet`1<T>::Clear(v105);\n\tv118 = this._items == 0;\n\tif (v118) goto L_00EE;\n\tv122 = Il2CppMethodInfo;\n\tv124 = v84;\n\t*([v122 @ X1_v9 (Il2CppMethodInfo)+10])(v128, *([v122 @ X1_v9 (Il2CppMethodInfo)]), Il2CppMethodInfo, this._items, &v124 @ stack_-90_v6 (System.Byte*), v84, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv132 = 0x8BF6A1C(v284, v84, *([v37 @ X0_v1 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv301 = Il2CppMethodInfo;\n\t*([v301 @ X1_v13 (Il2CppMethodInfo)+10])(v309, *([v301 @ X1_v13 (Il2CppMethodInfo)]), Il2CppMethodInfo, v181, &v169 @ stack_-70_v7 (Unco.SaveSystem.Core.Variables.PermanentHashSet`1<T>), v76, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv313 = 0x8BF6A1C(v93, v76, *([v39 @ X8_v6 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv343 = Il2CppMethodInfo;\n\t*([v343 @ X1_v15 (Il2CppMethodInfo)+10])(v346, *([v343 @ X1_v15 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, 0, &v169 @ stack_-70_v7 (Unco.SaveSystem.Core.Variables.PermanentHashSet`1<T>), v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv348 = 0x8BF6A1C(v79, v93, *([v39 @ X8_v6 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv204 = v169 == 0;\n\tif (v204) goto L_00E8;\n\tgoto L_00A4;\nL_FFFFFFFF:\n\tv172 = &v181 @ stack_-B0_v5 (System.Byte*);\nL_FFFFFFFF:\n\tv176 = &v72 @ stack_-A8_v1 (System.Byte*);\nL_FFFFFFFF:\n\tv183 = &v215 @ stack_-A0_v5 (Il2CppMethodInfo);\nL_FFFFFFFF:\n\tv105 = 0;\nL_FFFFFFFF:\n\tv209 = &v215 @ stack_-A0_v5 (Il2CppMethodInfo);\nL_FFFFFFFF:\n\tv220 = 0;\n\tv372 = 0x220C238(v372, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv383 = *([v209 @ X20_v2]);\n\tv384 = *([v383 @ X8_v26+20]);\n\tv373 = *([v384 @ X8_v27+C0]);\n\tv393 = *([A4731E0]);\n\tv230 = *([v393 @ X9_v11]) != *([v31 @ X8_v2]);\n\tif (v230) goto L_00F3;\n\treturn;\nL_00E8:\n\tv111 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv172 = &v181 @ stack_-B0_v5 (System.Byte*);\nL_FFFFFFFF:\n\tv176 = &v72 @ stack_-A8_v1 (System.Byte*);\nL_FFFFFFFF:\n\tv183 = &v215 @ stack_-A0_v5 (Il2CppMethodInfo);\nL_FFFFFFFF:\n\tv105 = 0;\nL_FFFFFFFF:\n\tv257 = v93;\n\tgoto L_00F2;\nL_00EA:\n\tv111 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv257 = *([v39 @ X8_v6 (Il2CppClass<T>)+FC]);\n\tgoto L_00F2;\nL_00EC:\n\tv111 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv257 = Il2CppMethodInfo;\n\tgoto L_00F2;\nL_00EE:\n\tv111 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv257 = Il2CppMethodInfo;\n\tgoto L_00F2;\nL_00F1:\n\tv211 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv111 = v211;\nL_00F2:\n\t// 242 Interrupt\nL_0104:\n\tv317 = v257 != 1;\n\tif (v317) goto L_010E;\n\tv386 = 0x8BF5BC4(v339, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv220 = *([v386 @ X0_v21]);\n\tv359 = 0x8BF5BF4(v386, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv105 = *([v386 @ X0_v21]);\nL_FFFFFFFF:\n\tv209 = v183;\n\tgoto L_00B1;\nL_010E:\n\tv335 = 0x339F3C8(&v105 @ stack_-90_v5 (System.Collections.Generic.HashSet`1<T>), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv336 = v339;\n\tgoto L_00F6;\nL_0025:\n\tv65 = *([v37 @ X0_v1 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+FC]) + 0x10;\n\tv68 = v65 + 0xF;\n\tv69 = v68 & 0x1FFFFFFF0;\n\t// 41 StackAlloc v70 @ X8_v13 (System.Byte*), v69 @ X8_v12 (System.Int32)\n\tv72 = v70;\n\tv74 = *([v39 @ X8_v6 (Il2CppClass<T>)+FC]) + 0xF;\n\tv75 = v74 & 0x1FFFFFFF0;\n\t// 47 StackAlloc v76 @ X21_v1 (System.Byte*), v75 @ X23_v1 (System.Int32)\n\t// 50 StackAlloc v79 @ X22_v1 (System.Byte*), v75 @ X23_v1 (System.Int32)\n\tv82 = *([v37 @ X0_v1 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+FC]) + 0xF;\n\tv83 = v82 & 0x1FFFFFFF0;\n\t// 55 StackAlloc v84 @ X26_v1 (System.Byte*), v83 @ X9_v5 (System.Int32)\n\t// 58 StackAlloc v284 @ X0_v36 (System.Byte*), v83 @ X9_v5 (System.Int32)\n\tv91 = 0x8BF5F18(v284, *([v37 @ X0_v1 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+FC]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t// 65 StackAlloc v93 @ X23_v2 (System.Byte*), v75 @ X23_v1 (System.Int32)\n\tv97 = 0x8BF5F18(v93, *([v39 @ X8_v6 (Il2CppClass<T>)+FC]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv98 = this == 0;\n\tif (v98) goto L_00EA;\nL_00A4:\n\tv280 = Il2CppMethodInfo;\n\tv272 = v79;\n\t*([v280 @ X1_v17 (Il2CppMethodInfo)+10])(v391, *([v280 @ X1_v17 (Il2CppMethodInfo)]), Il2CppMethodInfo, v169, &v272 @ stack_-70_v8 (System.IntPtr), &v390 @ stack_-91, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\nL_FFFFFFFF:\n\tv284 = v181;\n\tgoto L_0075;\nL_00BF:\n\tv257 = *([v373 @ X8_v23+148]);\n\tv111 = 0x21C1F68(v372, *([v373 @ X8_v23+148]), *([v176 @ stack_-80_v1]), *([v172 @ stack_-78_v1]), 0, 0, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv385 = v220 == 0;\n\tv203 = ~v385;\n\tif (v203) goto L_00F1;\nL_00F3:\n\tv269 = 0x8BF5CF0(v111, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv336 = v269;\nL_00B1:\n\tv362 = *([v209 @ X20_v2]);\n\tv363 = *([v362 @ X8_v20+20]);\n\tv373 = *([v363 @ X8_v21+C0]);\n\tv372 = *([v373 @ X8_v23+128]);\n\tv366 = *([v373 @ X8_v23+128]) + 0x135;\n\tv368 = *([v366 @ X9_v7]) & 1;\n\tv369 = v368 == 0;\n\tv370 = ~v369;\n\tif (v370) goto L_00BF;\nL_00F6:\n\tv339 = 0x8BF0368(v336, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0104;\nL_0075:\n\tv294 = System.Collections.Generic.List`1<T>+Enumerator<T>::MoveNext(v284);\n\tv296 = v294 == 0;\n\tif (v296) goto L_FFFFFFFF;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void OnAfterDeserialize()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PermanentHashSet::OnAfterDeserialize");
		}
	}
}
