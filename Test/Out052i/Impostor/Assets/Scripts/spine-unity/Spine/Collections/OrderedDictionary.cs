using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.IL2CPP.Metadata;

namespace Spine.Collections
{
	[DebuggerTypeProxy(typeof(OrderedDictionaryDebugView<, >))]
	[DebuggerDisplay("Count = {Count}")]
	[Token(Token = "0x20000D0")]
	public sealed class OrderedDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IList<KeyValuePair<TKey, TValue>>
	{
		[Token(Token = "0x20000D1")]
		public sealed class KeyCollection : ICollection<TKey>, IEnumerable<TKey>, IEnumerable
		{
			[Token(Token = "0x4000467")]
			[FieldOffset(Offset = "0x0")]
			private readonly Dictionary<TKey, int> dictionary;

			[Token(Token = "0x170001CD")]
			public int Count
			{
				[Token(Token = "0x6000776")]
				[Address(RVA = "0xFC4064", Offset = "0xFC4064", Length = "0x28")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.dictionary;\n\tv8 = Il2CppMethodInfo;\n\tv9 = *([v8 @ X1_v1 (Il2CppMethodInfo)]);\n\t// 11 IndirectJump v9 @ X2_v1, v2 @ X0_v1 (System.Collections.Generic.Dictionary`2<TKey, System.Int32>), v2 @ X0_v1 (System.Collections.Generic.Dictionary`2<TKey, System.Int32>), methodof(System.Collections.Generic.Dictionary`2<TKey, System.Int32>::get_Count), v9 @ X2_v1, v11 @ X3, v12 @ X4, v13 @ X5, v14 @ X6, v15 @ X7, v16 @ V0, v17 @ V1, v18 @ V2, v19 @ V3, v20 @ V4, v21 @ V5, v22 @ V6, v23 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					//IL_001d: Expected O, but got I
					Dictionary<TKey, int> dictionary = this.dictionary;
					nint num = 0;
					object obj = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v9 @ X2_v1 (should have been resolved before IL gen)");
					return 0;
				}
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			[Token(Token = "0x170001CE")]
			bool ICollection<TKey>.IsReadOnly
			{
				[Token(Token = "0x600077B")]
				[Address(RVA = "0xFC42B4", Offset = "0xFC42B4", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return true;
				}
			}

			[Token(Token = "0x6000774")]
			[Address(RVA = "0xFC3FE0", Offset = "0xFC3FE0", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.dictionary = dictionary;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal KeyCollection(Dictionary<TKey, int> dictionary)
			{
				this.dictionary = dictionary;
			}

			[Token(Token = "0x6000775")]
			[Address(RVA = "0xFC4008", Offset = "0xFC4008", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = System.Collections.Generic.Dictionary`2<TKey, System.Int32>::get_Keys(this.dictionary);\n\tv50 = Il2CppMethodInfo;\n\tv51 = *([v50 @ X3_v1 (Il2CppMethodInfo)]);\n\t// 29 IndirectJump v51 @ X4_v1, v21 @ X0_v4 (System.Collections.Generic.Dictionary`2<TKey, System.Int32>+KeyCollection<TKey, System.Int32>), v21 @ X0_v4 (System.Collections.Generic.Dictionary`2<TKey, System.Int32>+KeyCollection<TKey, System.Int32>), array @ X1 (TKey[]), arrayIndex @ X2 (System.Int32), methodof(System.Collections.Generic.Dictionary`2<TKey, System.Int32>+KeyCollection<TKey, System.Int32>::CopyTo), v51 @ X4_v1, v23 @ X5, v24 @ X6, v25 @ X7, v26 @ V0, v27 @ V1, v28 @ V2, v29 @ V3, v30 @ V4, v31 @ V5, v32 @ V6, v33 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void CopyTo(TKey[] array, int arrayIndex)
			{
				//IL_0022: Expected O, but got I
				Dictionary<TKey, int>.KeyCollection keys = dictionary.Keys;
				nint num = 0;
				object obj = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v51 @ X4_v1 (should have been resolved before IL gen)");
			}

			[Token(Token = "0x6000777")]
			[Address(RVA = "0xFC408C", Offset = "0xFC408C", Length = "0xC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = &v11 @ stack_-30_v2;\n\t*([v10 @ X29_v1-8]) = *([v13 @ SYSREG+28]);\n\tv20 = Il2CppClass<System.Collections.Generic.Dictionary`2<TKey, System.Int32>+KeyCollection<TKey, System.Int32>+Enumerator<TKey, System.Int32>>;\n\tv22 = *([v20 @ X9_v1 (Il2CppClass<System.Collections.Generic.Dictionary`2<TKey, System.Int32>+KeyCollection<TKey, System.Int32>+Enumerator<TKey, System.Int32>>)+FC]) + 0xF;\n\tv23 = v22 & 0x1FFFFFFF0;\n\tv24 = &v16 @ stack_-40_v1 - v23;\n\tv32 = System.Collections.Generic.Dictionary`2<TKey, System.Int32>::get_Keys(this.dictionary);\n\tv56 = &v11 @ stack_-30_v2 - 0x10;\n\tv59 = Il2CppMethodInfo;\n\t*([v10 @ X29_v1-10]) = v24;\n\t*([v59 @ X1_v4 (Il2CppMethodInfo)+10])(v62, *([v59 @ X1_v4 (Il2CppMethodInfo)]), Il2CppMethodInfo, v32, v56, v24, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\t// 43 Box returnVal2 @ X0_v10 (System.Collections.Generic.IEnumerator`1<TKey>), typeof(Il2CppClass<System.Collections.Generic.Dictionary`2<TKey, System.Int32>+KeyCollection<TKey, System.Int32>+Enumerator<TKey, System.Int32>>), v24 @ X20_v1\n\tv70 = *([v13 @ SYSREG+28]) != *([v10 @ X29_v1-8]);\n\tif (v70) goto L_0042;\n\treturn returnVal2;\n\tv53 = new System.NullReferenceException();\nL_0042:\n\treturnVal1 = 0x1854EB0(v100, v98, v97, v96, v95, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\treturn returnVal1;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public IEnumerator<TKey> GetEnumerator()
			{
				//IL_0031: Expected O, but got I
				//IL_0044: Expected I4, but got I8
				//IL_0052: Expected O, but got I
				//IL_007a: Expected O, but got I
				//IL_0098: Expected I, but got O
				object obj2 = default(object);
				object obj = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ SYSREG+28]");
				_ = 0;
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X9_v1 (Il2CppClass<System.Collections.Generic.Dictionary`2<TKey, System.Int32>+KeyCollection<TKey, System.Int32>+Enumerator<TKey, System.Int32>>)+FC]");
				object obj3 = (nint)0 + (nint)15;
				int num2 = (int)((nint)obj3 & 0x1FFFFFFF0L);
				object obj5 = default(object);
				object obj4 = (nint)obj5 - num2;
				Dictionary<TKey, int>.KeyCollection keys = dictionary.Keys;
				object obj6 = (nint)obj2 - 16;
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v59 @ X1_v4 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				IEnumerator<TKey> result = (IEnumerator<TKey>)(object)(IntPtr)obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ SYSREG+28]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1-8]");
				if (num4 == 0)
				{
					return result;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EB0 (native __stack_chk_fail)");
				IEnumerator<TKey> result2 = default(IEnumerator<TKey>);
				return result2;
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			[Token(Token = "0x6000778")]
			[Address(RVA = "0xFC4154", Offset = "0xFC4154", Length = "0xD0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = &v13 @ stack_-30_v2;\n\t*([v12 @ X29_v1-8]) = *([v15 @ SYSREG+28]);\n\t*([v12 @ X29_v1-20]) = v48;\n\tv23 = Il2CppClass<TKey>;\n\tv25 = *([v23 @ X8_v3 (Il2CppClass<TKey>)+FC]) + 0xF;\n\tv26 = v25 & 0x1FFFFFFF0;\n\tv74 = &v18 @ stack_-50_v1 - v26;\n\tv36 = *([v23 @ X8_v3 (Il2CppClass<TKey>)+28]) < 0;\n\tv39 = *([v23 @ X8_v3 (Il2CppClass<TKey>)+28]) ^ *([v23 @ X8_v3 (Il2CppClass<TKey>)+28]);\n\tv40 = *([v23 @ X8_v3 (Il2CppClass<TKey>)+28]) & v39;\n\tv41 = v40 < 0;\n\tv42 = &v13 @ stack_-30_v2 - 0x20;\n\tv43 = v36 == v41;\n\tv44 = ~v43;\n\tv45 = ~v44;\n\tif (v45) goto L_002B;\n\tgoto L_002B;\nL_002B:\n\tv49 = 0x1854F10(v74, v42, *([v23 @ X8_v3 (Il2CppClass<TKey>)+FC]), v105, v104, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv66 = Il2CppMethodInfo;\n\tgoto L_0038;\n\tv73 = *([v27 @ X20_v1]);\nL_0038:\n\t*([v12 @ X29_v1-18]) = v74;\n\tv76 = &v13 @ stack_-30_v2 - 0x18;\n\tv77 = &v13 @ stack_-30_v2 - 0xC;\n\t*([v66 @ X1_v3 (Il2CppMethodInfo)+10])(v79, *([v66 @ X1_v3 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.dictionary, v76, v77, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv87 = *([v12 @ X29_v1-C]) == 0;\n\tv92 = ~v87;\n\tv103 = *([v15 @ SYSREG+28]) != *([v12 @ X29_v1-8]);\n\tif (v103) goto L_0061;\n\treturn v92;\n\tv72 = new System.NullReferenceException();\nL_0061:\n\treturnVal2 = 0x1854EB0(v116, v42, *([v23 @ X8_v3 (Il2CppClass<TKey>)+FC]), v105, v104, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\treturn returnVal2;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			bool ICollection<TKey>.Contains(TKey item)
			{
				//IL_0036: Expected O, but got I
				//IL_0049: Expected I4, but got I8
				//IL_0057: Expected O, but got I
				//IL_00be: Expected O, but got I
				//IL_0137: Expected O, but got I
				//IL_0146: Expected O, but got I
				object obj2 = default(object);
				object obj = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ SYSREG+28]");
				_ = 0;
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X8_v3 (Il2CppClass<TKey>)+FC]");
				object obj3 = (nint)0 + (nint)15;
				int num2 = (int)((nint)obj3 & 0x1FFFFFFF0L);
				object obj5 = default(object);
				object obj4 = (nint)obj5 - num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X8_v3 (Il2CppClass<TKey>)+28]");
				bool flag = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X8_v3 (Il2CppClass<TKey>)+28]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X8_v3 (Il2CppClass<TKey>)+28]");
				int num4 = (int)(num3 ^ 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X8_v3 (Il2CppClass<TKey>)+28]");
				int num5 = (int)((nint)0 & (nint)num4);
				bool flag2 = num5 < 0;
				TKey val = (TKey)((nint)obj2 - 32);
				if (flag != flag2)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
				nint num6 = 0;
				object obj6 = (nint)obj2 - 24;
				object obj7 = (nint)obj2 - 12;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v66 @ X1_v3 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1-C]");
				bool flag3 = (nint)0 == 0;
				bool result = !flag3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ SYSREG+28]");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1-8]");
				if (num7 == 0)
				{
					return result;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EB0 (native __stack_chk_fail)");
				bool result2 = default(bool);
				return result2;
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			[Token(Token = "0x6000779")]
			[Address(RVA = "0xFC4224", Offset = "0xFC4224", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v25, \"An attempt was made to edit a read-only list.\");\n\tthrow v25;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void ICollection<TKey>.Add(TKey item)
			{
				NotSupportedException ex = new NotSupportedException("An attempt was made to edit a read-only list.");
				throw ex;
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			[Token(Token = "0x600077A")]
			[Address(RVA = "0xFC426C", Offset = "0xFC426C", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v25, \"An attempt was made to edit a read-only list.\");\n\tthrow v25;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void ICollection<TKey>.Clear()
			{
				NotSupportedException ex = new NotSupportedException("An attempt was made to edit a read-only list.");
				throw ex;
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			[Token(Token = "0x600077C")]
			[Address(RVA = "0xFC42BC", Offset = "0xFC42BC", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v25, \"An attempt was made to edit a read-only list.\");\n\tthrow v25;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			bool ICollection<TKey>.Remove(TKey item)
			{
				NotSupportedException ex = new NotSupportedException("An attempt was made to edit a read-only list.");
				throw ex;
			}

			[Token(Token = "0x600077D")]
			[Address(RVA = "0xFC4304", Offset = "0xFC4304", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = Il2CppMethodInfo;\n\tv4 = *([v3 @ X1_v1 (Il2CppMethodInfo)]);\n\t// 4 IndirectJump v4 @ X2_v1, this @ X0 (Spine.Collections.OrderedDictionary`2<TKey, TValue>+KeyCollection<TKey, TValue>), this @ X0 (Spine.Collections.OrderedDictionary`2<TKey, TValue>+KeyCollection<TKey, TValue>), methodof(Spine.Collections.OrderedDictionary`2<TKey, TValue>+KeyCollection<TKey, TValue>::GetEnumerator), v4 @ X2_v1, v6 @ X3, v7 @ X4, v8 @ X5, v9 @ X6, v10 @ X7, v11 @ V0, v12 @ V1, v13 @ V2, v14 @ V3, v15 @ V4, v16 @ V5, v17 @ V6, v18 @ V7\n\treturn X0;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				//IL_000e: Expected O, but got I
				nint num = 0;
				object obj = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ X2_v1 (should have been resolved before IL gen)");
				return null;
			}
		}

		[Token(Token = "0x20000D2")]
		public sealed class ValueCollection : ICollection<TValue>, IEnumerable<TValue>, IEnumerable
		{
			[Token(Token = "0x4000468")]
			[FieldOffset(Offset = "0x0")]
			private readonly List<TValue> values;

			[Token(Token = "0x170001CF")]
			public int Count
			{
				[Token(Token = "0x6000780")]
				[Address(RVA = "0x1213D9C", Offset = "0x1213D9C", Length = "0x28")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.values;\n\tv8 = Il2CppMethodInfo;\n\tv9 = *([v8 @ X1_v1 (Il2CppMethodInfo)]);\n\t// 11 IndirectJump v9 @ X2_v1, v2 @ X0_v1 (System.Collections.Generic.List`1<TValue>), v2 @ X0_v1 (System.Collections.Generic.List`1<TValue>), methodof(System.Collections.Generic.List`1<TValue>::get_Count), v9 @ X2_v1, v11 @ X3, v12 @ X4, v13 @ X5, v14 @ X6, v15 @ X7, v16 @ V0, v17 @ V1, v18 @ V2, v19 @ V3, v20 @ V4, v21 @ V5, v22 @ V6, v23 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					//IL_001d: Expected O, but got I
					List<TValue> list = values;
					nint num = 0;
					object obj = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v9 @ X2_v1 (should have been resolved before IL gen)");
					return 0;
				}
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			[Token(Token = "0x170001D0")]
			bool ICollection<TValue>.IsReadOnly
			{
				[Token(Token = "0x6000785")]
				[Address(RVA = "0x1213FD0", Offset = "0x1213FD0", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return true;
				}
			}

			[Token(Token = "0x600077E")]
			[Address(RVA = "0x1213D4C", Offset = "0x1213D4C", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.values = values;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal ValueCollection(List<TValue> values)
			{
				this.values = values;
			}

			[Token(Token = "0x600077F")]
			[Address(RVA = "0x1213D74", Offset = "0x1213D74", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.values;\n\tv8 = Il2CppMethodInfo;\n\tv9 = *([v8 @ X3_v1 (Il2CppMethodInfo)]);\n\t// 11 IndirectJump v9 @ X4_v1, v2 @ X0_v1 (System.Collections.Generic.List`1<TValue>), v2 @ X0_v1 (System.Collections.Generic.List`1<TValue>), array @ X1 (TValue[]), arrayIndex @ X2 (System.Int32), methodof(System.Collections.Generic.List`1<TValue>::CopyTo), v9 @ X4_v1, v13 @ X5, v14 @ X6, v15 @ X7, v16 @ V0, v17 @ V1, v18 @ V2, v19 @ V3, v20 @ V4, v21 @ V5, v22 @ V6, v23 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void CopyTo(TValue[] array, int arrayIndex)
			{
				//IL_001d: Expected O, but got I
				List<TValue> list = values;
				nint num = 0;
				object obj = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v9 @ X4_v1 (should have been resolved before IL gen)");
			}

			[Token(Token = "0x6000781")]
			[Address(RVA = "0x1213DC4", Offset = "0x1213DC4", Length = "0xAC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = &v11 @ stack_-30_v2;\n\t*([v10 @ X29_v1-8]) = *([v13 @ SYSREG+28]);\n\tv20 = Il2CppClass<System.Collections.Generic.List`1<TValue>+Enumerator<TValue>>;\n\tv22 = *([v20 @ X9_v1 (Il2CppClass<System.Collections.Generic.List`1<TValue>+Enumerator<TValue>>)+FC]) + 0xF;\n\tv23 = v22 & 0x1FFFFFFF0;\n\tv24 = &v16 @ stack_-40_v1 - v23;\n\tv30 = Il2CppMethodInfo;\n\tv31 = &v11 @ stack_-30_v2 - 0x10;\n\t*([v10 @ X29_v1-10]) = v24;\n\t*([v30 @ X1_v2 (Il2CppMethodInfo)+10])(v35, *([v30 @ X1_v2 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.values, v31, v24, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\t// 35 Box returnVal1 @ X0_v7 (System.Collections.Generic.IEnumerator`1<TValue>), typeof(Il2CppClass<System.Collections.Generic.List`1<TValue>+Enumerator<TValue>>), v24 @ X20_v1 (Il2CppMethodInfo)\n\tv66 = *([v13 @ SYSREG+28]) != *([v10 @ X29_v1-8]);\n\tif (v66) goto L_003A;\n\treturn returnVal1;\n\tv52 = new System.NullReferenceException();\nL_003A:\n\treturnVal2 = 0x1854EB0(v85, v88, this.values, v87, v86, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\treturn returnVal2;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public IEnumerator<TValue> GetEnumerator()
			{
				//IL_0031: Expected O, but got I
				//IL_0044: Expected I4, but got I8
				//IL_006c: Expected O, but got I
				object obj2 = default(object);
				object obj = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ SYSREG+28]");
				_ = 0;
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X9_v1 (Il2CppClass<System.Collections.Generic.List`1<TValue>+Enumerator<TValue>>)+FC]");
				object obj3 = (nint)0 + (nint)15;
				int num2 = (int)((nint)obj3 & 0x1FFFFFFF0L);
				object obj4 = default(object);
				nint num3 = (nint)obj4 - num2;
				nint num4 = 0;
				object obj5 = (nint)obj2 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v30 @ X1_v2 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				IEnumerator<TValue> result = (IEnumerator<TValue>)(object)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ SYSREG+28]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1-8]");
				if (num5 == 0)
				{
					return result;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EB0 (native __stack_chk_fail)");
				IEnumerator<TValue> result2 = default(IEnumerator<TValue>);
				return result2;
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			[Token(Token = "0x6000782")]
			[Address(RVA = "0x1213E70", Offset = "0x1213E70", Length = "0xD0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = &v13 @ stack_-30_v2;\n\t*([v12 @ X29_v1-8]) = *([v15 @ SYSREG+28]);\n\t*([v12 @ X29_v1-20]) = v48;\n\tv23 = Il2CppClass<TValue>;\n\tv25 = *([v23 @ X8_v3 (Il2CppClass<TValue>)+FC]) + 0xF;\n\tv26 = v25 & 0x1FFFFFFF0;\n\tv74 = &v18 @ stack_-50_v1 - v26;\n\tv36 = *([v23 @ X8_v3 (Il2CppClass<TValue>)+28]) < 0;\n\tv39 = *([v23 @ X8_v3 (Il2CppClass<TValue>)+28]) ^ *([v23 @ X8_v3 (Il2CppClass<TValue>)+28]);\n\tv40 = *([v23 @ X8_v3 (Il2CppClass<TValue>)+28]) & v39;\n\tv41 = v40 < 0;\n\tv42 = &v13 @ stack_-30_v2 - 0x20;\n\tv43 = v36 == v41;\n\tv44 = ~v43;\n\tv45 = ~v44;\n\tif (v45) goto L_002B;\n\tgoto L_002B;\nL_002B:\n\tv49 = 0x1854F10(v74, v42, *([v23 @ X8_v3 (Il2CppClass<TValue>)+FC]), v105, v104, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv66 = Il2CppMethodInfo;\n\tgoto L_0038;\n\tv73 = *([v27 @ X20_v1]);\nL_0038:\n\t*([v12 @ X29_v1-18]) = v74;\n\tv76 = &v13 @ stack_-30_v2 - 0x18;\n\tv77 = &v13 @ stack_-30_v2 - 0xC;\n\t*([v66 @ X1_v3 (Il2CppMethodInfo)+10])(v79, *([v66 @ X1_v3 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.values, v76, v77, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv87 = *([v12 @ X29_v1-C]) == 0;\n\tv92 = ~v87;\n\tv103 = *([v15 @ SYSREG+28]) != *([v12 @ X29_v1-8]);\n\tif (v103) goto L_0061;\n\treturn v92;\n\tv72 = new System.NullReferenceException();\nL_0061:\n\treturnVal2 = 0x1854EB0(v116, v42, *([v23 @ X8_v3 (Il2CppClass<TValue>)+FC]), v105, v104, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\treturn returnVal2;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			bool ICollection<TValue>.Contains(TValue item)
			{
				//IL_0036: Expected O, but got I
				//IL_0049: Expected I4, but got I8
				//IL_0057: Expected O, but got I
				//IL_00be: Expected O, but got I
				//IL_0137: Expected O, but got I
				//IL_0146: Expected O, but got I
				object obj2 = default(object);
				object obj = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ SYSREG+28]");
				_ = 0;
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X8_v3 (Il2CppClass<TValue>)+FC]");
				object obj3 = (nint)0 + (nint)15;
				int num2 = (int)((nint)obj3 & 0x1FFFFFFF0L);
				object obj5 = default(object);
				object obj4 = (nint)obj5 - num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X8_v3 (Il2CppClass<TValue>)+28]");
				bool flag = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X8_v3 (Il2CppClass<TValue>)+28]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X8_v3 (Il2CppClass<TValue>)+28]");
				int num4 = (int)(num3 ^ 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X8_v3 (Il2CppClass<TValue>)+28]");
				int num5 = (int)((nint)0 & (nint)num4);
				bool flag2 = num5 < 0;
				TValue val = (TValue)((nint)obj2 - 32);
				if (flag != flag2)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
				nint num6 = 0;
				object obj6 = (nint)obj2 - 24;
				object obj7 = (nint)obj2 - 12;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v66 @ X1_v3 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1-C]");
				bool flag3 = (nint)0 == 0;
				bool result = !flag3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ SYSREG+28]");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1-8]");
				if (num7 == 0)
				{
					return result;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EB0 (native __stack_chk_fail)");
				bool result2 = default(bool);
				return result2;
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			[Token(Token = "0x6000783")]
			[Address(RVA = "0x1213F40", Offset = "0x1213F40", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v25, \"An attempt was made to edit a read-only list.\");\n\tthrow v25;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void ICollection<TValue>.Add(TValue item)
			{
				NotSupportedException ex = new NotSupportedException("An attempt was made to edit a read-only list.");
				throw ex;
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			[Token(Token = "0x6000784")]
			[Address(RVA = "0x1213F88", Offset = "0x1213F88", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v25, \"An attempt was made to edit a read-only list.\");\n\tthrow v25;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void ICollection<TValue>.Clear()
			{
				NotSupportedException ex = new NotSupportedException("An attempt was made to edit a read-only list.");
				throw ex;
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			[Token(Token = "0x6000786")]
			[Address(RVA = "0x1213FD8", Offset = "0x1213FD8", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v25, \"An attempt was made to edit a read-only list.\");\n\tthrow v25;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			bool ICollection<TValue>.Remove(TValue item)
			{
				NotSupportedException ex = new NotSupportedException("An attempt was made to edit a read-only list.");
				throw ex;
			}

			[Token(Token = "0x6000787")]
			[Address(RVA = "0x1214020", Offset = "0x1214020", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = Il2CppMethodInfo;\n\tv4 = *([v3 @ X1_v1 (Il2CppMethodInfo)]);\n\t// 4 IndirectJump v4 @ X2_v1, this @ X0 (Spine.Collections.OrderedDictionary`2<TKey, TValue>+ValueCollection<TKey, TValue>), this @ X0 (Spine.Collections.OrderedDictionary`2<TKey, TValue>+ValueCollection<TKey, TValue>), methodof(Spine.Collections.OrderedDictionary`2<TKey, TValue>+ValueCollection<TKey, TValue>::GetEnumerator), v4 @ X2_v1, v6 @ X3, v7 @ X4, v8 @ X5, v9 @ X6, v10 @ X7, v11 @ V0, v12 @ V1, v13 @ V2, v14 @ V3, v15 @ V4, v16 @ V5, v17 @ V6, v18 @ V7\n\treturn X0;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				//IL_000e: Expected O, but got I
				nint num = 0;
				object obj = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ X2_v1 (should have been resolved before IL gen)");
				return null;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x20000D3")]
		private sealed class _003CGetEnumerator_003Ed__34 : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000469")]
			[FieldOffset(Offset = "0x0")]
			private int _003C_003E1__state;

			[Token(Token = "0x400046A")]
			[FieldOffset(Offset = "0x0")]
			private KeyValuePair<TKey, TValue> _003C_003E2__current;

			[Token(Token = "0x400046B")]
			[FieldOffset(Offset = "0x0")]
			public OrderedDictionary<TKey, TValue> _003C_003E4__this;

			[Token(Token = "0x400046C")]
			[FieldOffset(Offset = "0x0")]
			private int _003CstartVersion_003E5__2;

			[Token(Token = "0x400046D")]
			[FieldOffset(Offset = "0x0")]
			private int _003Cindex_003E5__3;

			[Token(Token = "0x170001D1")]
			KeyValuePair<TKey, TValue> IEnumerator<KeyValuePair<TKey, TValue>>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600078B")]
				[Address(RVA = "0xDCD5A0", Offset = "0xDCD5A0", Length = "0xA0")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = &v13 @ stack_-30_v2;\n\t*([v12 @ X29_v1-8]) = *([v15 @ SYSREG+28]);\n\tv19 = *([v20 @ X2+20]);\n\tv21 = *([v19 @ X8_v2+C0]);\n\tv22 = *([v21 @ X8_v3+40]);\n\tv26 = *([v22 @ X9_v1+FC]) + 0xF;\n\tv27 = v26 & 0x1FFFFFFF0;\n\tv28 = &v25 @ stack_-40_v1 - v27;\n\tv30 = *([v21 @ X8_v3]);\n\tv32 = *([v30 @ X8_v4+80]) + 0x20;\n\tv33 = 0xAD94BC(this, v32, v20, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv51 = 0x1854F10(v28, v33, *([v22 @ X9_v1+FC]), v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturnVal1 = 0x1854F10(methodInfo, v28, *([v22 @ X9_v1+FC]), v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv67 = *([v15 @ SYSREG+28]) != *([v12 @ X29_v1-8]);\n\tif (v67) goto L_0038;\n\treturn returnVal1;\nL_0038:\n\treturnVal2 = 0x1854EB0(returnVal1, v28, *([v22 @ X9_v1+FC]), v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn returnVal2;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					//IL_0025: Expected O, but got I
					//IL_0035: Expected O, but got I
					//IL_0045: Expected O, but got I
					//IL_005b: Expected O, but got I
					//IL_006e: Expected I4, but got I8
					//IL_007c: Expected O, but got I
					//IL_009a: Expected O, but got I
					object obj2 = default(object);
					object obj = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ SYSREG+28]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X2+20]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X8_v2+C0]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X8_v3+40]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X9_v1+FC]");
					object obj6 = (nint)0 + (nint)15;
					int num = (int)((nint)obj6 & 0x1FFFFFFF0L);
					object obj8 = default(object);
					object obj7 = (nint)obj8 - num;
					object obj9 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X8_v4+80]");
					object obj10 = (nint)0 + (nint)32;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94BC");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ SYSREG+28]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1-8]");
					KeyValuePair<TKey, TValue> result = default(KeyValuePair<TKey, TValue>);
					if (num2 == 0)
					{
						return result;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EB0 (native __stack_chk_fail)");
					KeyValuePair<TKey, TValue> result2 = default(KeyValuePair<TKey, TValue>);
					return result2;
				}
			}

			[Token(Token = "0x170001D2")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600078D")]
				[Address(RVA = "0xDCD674", Offset = "0xDCD674", Length = "0xA4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = &v13 @ stack_-30_v2;\n\t*([v12 @ X29_v1-8]) = *([v15 @ SYSREG+28]);\n\tv21 = Il2CppClass<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>;\n\tv25 = *([v21 @ X9_v1 (Il2CppClass<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>)+FC]) + 0xF;\n\tv26 = v25 & 0x1FFFFFFF0;\n\tv27 = &v24 @ stack_-40_v1 - v26;\n\tv29 = Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>;\n\tv31 = *([v29 @ X8_v4 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>)+80]) + 0x20;\n\tv32 = 0xAD94BC(this, v31, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv51 = 0x1854F10(v27, v32, *([v21 @ X9_v1 (Il2CppClass<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>)+FC]), v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t// 34 Box returnVal1 @ X0_v5 (System.Object), typeof(Il2CppClass<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>), v27 @ X21_v1\n\tv68 = *([v15 @ SYSREG+28]) != *([v12 @ X29_v1-8]);\n\tif (v68) goto L_0039;\n\treturn returnVal1;\nL_0039:\n\treturnVal2 = 0x1854EB0(returnVal1, v27, *([v21 @ X9_v1 (Il2CppClass<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>)+FC]), v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn returnVal2;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					//IL_0031: Expected O, but got I
					//IL_0044: Expected I4, but got I8
					//IL_0052: Expected O, but got I
					//IL_006e: Expected O, but got I
					//IL_0090: Expected I, but got O
					object obj2 = default(object);
					object obj = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ SYSREG+28]");
					_ = 0;
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X9_v1 (Il2CppClass<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>)+FC]");
					object obj3 = (nint)0 + (nint)15;
					int num2 = (int)((nint)obj3 & 0x1FFFFFFF0L);
					object obj5 = default(object);
					object obj4 = (nint)obj5 - num2;
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ X8_v4 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>)+80]");
					object obj6 = (nint)0 + (nint)32;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94BC");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
					object result = (IntPtr)obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ SYSREG+28]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1-8]");
					if (num4 == 0)
					{
						return result;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EB0 (native __stack_chk_fail)");
					object result2 = default(object);
					return result2;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000788")]
			[Address(RVA = "0xDCD010", Offset = "0xDCD010", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tv18 = Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>;\n\tv21 = 0xAC7A4C(*([v18 @ X8_v3 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>)+80]), 4, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 0xAD94BC(this, *([v18 @ X8_v3 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>)+80]), methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\t*([v37 @ X0_v4]) = <>1__state;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CGetEnumerator_003Ed__34(int _003C_003E1__state)
			{
				//IL_002d: Expected O, but got I4
				base._002Ector();
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AC7A4C");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94BC");
				object obj = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000789")]
			[Address(RVA = "0xDCD064", Offset = "0xDCD064", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x600078A")]
			[Address(RVA = "0xDCD068", Offset = "0xDCD068", Length = "0x538")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = &v1 @ X29;\n\t*([v1 @ X29-8]) = *([v26 @ SYSREG+28]);\n\tv34 = Il2CppClass<TKey>;\n\tv35 = Il2CppClass<TValue>;\n\tv36 = Il2CppClass<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>;\n\tv42 = *([v34 @ X8_v3 (Il2CppClass<TKey>)+FC]) + 0xF;\n\tv43 = v42 & 0x1FFFFFFF0;\n\tv44 = &v41 @ stack_-D0_v1 - v43;\n\tv48 = &v41 @ stack_-D0_v1 - v43;\n\t*([v1 @ X29-48]) = v48;\n\tv52 = &v41 @ stack_-D0_v1 - v43;\n\t*([v1 @ X29-68]) = v52;\n\tv54 = *([v35 @ X9_v1 (Il2CppClass<TValue>)+FC]) + 0xF;\n\tv57 = v54 & 0x1FFFFFFF0;\n\tv58 = &v41 @ stack_-D0_v1 - v57;\n\t*([v1 @ X29-50]) = v58;\n\tv62 = &v41 @ stack_-D0_v1 - v57;\n\t*([v1 @ X29-30]) = *([v34 @ X8_v3 (Il2CppClass<TKey>)+FC]);\n\t*([v1 @ X29-28]) = v62;\n\tv66 = &v41 @ stack_-D0_v1 - v57;\n\t*([v1 @ X29-58]) = v66;\n\tv68 = *([v36 @ X10_v1 (Il2CppClass<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>)+FC]) + 0xF;\n\tv71 = v68 & 0x1FFFFFFF0;\n\tv72 = &v41 @ stack_-D0_v1 - v71;\n\t*([v1 @ X29-40]) = v72;\n\tv76 = &v41 @ stack_-D0_v1 - v43;\n\tv80 = 0x1854F20(v76, 0, *([v34 @ X8_v3 (Il2CppClass<TKey>)+FC]), v246, v244, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93);\n\tv96 = &v41 @ stack_-D0_v1 - v57;\n\t*([v1 @ X29-38]) = *([v35 @ X9_v1 (Il2CppClass<TValue>)+FC]);\n\tv101 = 0x1854F20(v96, 0, *([v35 @ X9_v1 (Il2CppClass<TValue>)+FC]), v246, v244, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93);\n\tv102 = Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>;\n\tv105 = 0xAD94BC(this, *([v102 @ X8_v19 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>)+80]), *([v35 @ X9_v1 (Il2CppClass<TValue>)+FC]), v246, v244, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93);\n\tv110 = Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>;\n\tv267 = *([v110 @ X8_v22 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>)+80]) + 0x40;\n\tv113 = System.Collections.Generic.List`1<TKey>::get_Count(this);\n\tv114 = v113.m_value;\n\tv119 = *([v105 @ X0_v6]) == 1;\n\tif (v119) goto L_0087;\n\tv125 = *([v105 @ X0_v6]) == 0;\n\tv126 = ~v125;\n\tif (v126) goto L_016D;\n\t*([v1 @ X29-70]) = *([v36 @ X10_v1 (Il2CppClass<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>)+FC]);\n\t*([v1 @ X29-60]) = v26;\n\tv137 = Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>;\n\tv140 = 0xAC7A4C(*([v137 @ X8_v84 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>)+80]), 4, *([v35 @ X9_v1 (Il2CppClass<TValue>)+FC]), v246, v244, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93);\n\tv219 = 0xAD94BC(this, *([v137 @ X8_v84 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>)+80]), *([v35 @ X9_v1 (Il2CppClass<TValue>)+FC]), v246, v244, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93);\n\t*([v219 @ X0_v79]) = 0xFFFFFFFF;\n\tv388 = Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>;\n\tv390 = *([v388 @ X8_v88 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>)+80]) + 0x60;\n\tv392 = 0xAC7A4C(v390, 4, *([v35 @ X9_v1 (Il2CppClass<TValue>)+FC]), v246, v244, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93);\n\tv412 = 0xAD94BC(this, v390, *([v35 @ X9_v1 (Il2CppClass<TValue>)+FC]), v246, v244, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93);\n\t*([v412 @ X0_v83]) = *([v114 @ X24_v2 (System.Int32)+28]);\n\tgoto L_00B6;\nL_0087:\n\t*([v1 @ X29-70]) = *([v36 @ X10_v1 (Il2CppClass<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>)+FC]);\n\t*([v1 @ X29-60]) = v26;\n\tv130 = Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>;\n\tv133 = 0xAC7A4C(*([v130 @ X8_v70 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>)+80]), 4, *([v35 @ X9_v1 (Il2CppClass<TValue>)+FC]), v246, v244, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93);\n\tv216 = 0xAD94BC(this, *([v130 @ X8_v70 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>)+80]), *([v35 @ X9_v1 (Il2CppClass<TValue>)+FC]), v246, v244, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93);\n\t*([v216 @ X0_v70]) = 0xFFFFFFFF;\n\tv331 = Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>;\n\tv333 = *([v331 @ X8_v74 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>)+80]) + 0x60;\n\tv334 = 0xAD94BC(this, v333, *([v35 @ X9_v1 (Il2CppClass<TValue>)+FC]), v246, v244, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93);\n\tv403 = *([v114 @ X24_v2 (System.Int32)+28]) != *([v334 @ X0_v72]);\n\tif (v403) goto L_0182;\n\tv416 = Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>;\n\tv418 = *([v416 @ X8_v79 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>)+80]) + 0x80;\n\tv419 = 0xAD94BC(this, v418, *([v35 @ X9_v1 (Il2CppClass<TValue>)+FC]), v246, v244, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93);\n\tv366 = *([v419 @ X0_v74]) + 1;\nL_00B6:\n\tv435 = Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>;\n\tv186 = *([v435 @ X8_v27 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>)+80]) + 0x80;\n\tv438 = 0xAC7A4C(v186, 4, *([v35 @ X9_v1 (Il2CppClass<TValue>)+FC]), v246, v244, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93);\n\tv443 = 0xAD94BC(this, v186, *([v35 @ X9_v1 (Il2CppClass<TValue>)+FC]), v246, v244, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93);\n\t*([v443 @ X0_v13]) = v366;\n\tv448 = Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>;\n\tv358 = *([v448 @ X8_v31 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>)+80]) + 0x80;\n\tv362 = 0xAD94BC(this, v358, *([v35 @ X9_v1 (Il2CppClass<TValue>)+FC]), v246, v244, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93);\n\tv453 = System.Collections.Generic.List`1<TKey>::get_Count(*([v114 @ X24_v2 (System.Int32)+18]));\n\tv146 = *([v362 @ X0_v15]) != v453;\n\tif (v146) goto L_00E2;\n\tv199 = *([v1 @ X29-60]);\n\tgoto L_016D;\nL_00E2:\n\tv458 = Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>;\n\tv359 = *([v458 @ X8_v36 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>)+80]) + 0x80;\n\tv363 = 0xAD94BC(this, v359, *([v35 @ X9_v1 (Il2CppClass<TValue>)+FC]), v246, v244, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93);\n\tv367 = &v1 @ X29 - 0xC;\n\tv338 = &v1 @ X29 - 0x20;\n\tv462 = Il2CppMethodInfo;\n\t*([v1 @ X29-C]) = *([v363 @ X0_v19]);\n\t*([v1 @ X29-20]) = v367;\n\t*([v1 @ X29-18]) = v44;\n\t*([v462 @ X1_v11 (Il2CppMethodInfo)+10])(v466, *([v462 @ X1_v11 (Il2CppMethodInfo)]), Il2CppMethodInfo, *([v114 @ X24_v2 (System.Int32)+18]), v338, v44, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93);\n\tv469 = 0x1854F10(v76, v44, *([v1 @ X29-30]), v338, v44, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93);\n\tv473 = Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>;\n\tv360 = *([v473 @ X8_v44 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>)+80]) + 0x80;\n\tv364 = 0xAD94BC(this, v360, *([v1 @ X29-30]), v338, v44, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93);\n\tv475 = &v1 @ X29 - 0x20;\n\tv478 = Il2CppMethodInfo;\n\t*([v1 @ X29-20]) = v367;\n\t*([v1 @ X29-C]) = *([v364 @ X0_v25]);\n\t*([v1 @ X29-18]) = *([v1 @ X29-50]);\n\t*([v478 @ X1_v14 (Il2CppMethodInfo)+10])(v483, *([v478 @ X1_v14 (Il2CppMethodInfo)]), Il2CppMethodInfo, *([v114 @ X24_v2 (System.Int32)+20]), v475, *([v1 @ X29-50]), v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93);\n\tv487 = 0x1854F10(v96, *([v1 @ X29-50]), *([v1 @ X29-38]), v475, *([\n// ... truncated")]
			private unsafe bool MoveNext()
			{
				//IL_003d: Expected O, but got I
				//IL_0050: Expected I4, but got I8
				//IL_005e: Expected O, but got I
				//IL_006c: Expected O, but got I
				//IL_007f: Expected O, but got I
				//IL_009a: Expected O, but got I
				//IL_00ad: Expected I4, but got I8
				//IL_00bb: Expected O, but got I
				//IL_00ce: Expected O, but got I
				//IL_00ee: Expected O, but got I
				//IL_0109: Expected O, but got I
				//IL_011c: Expected I4, but got I8
				//IL_012a: Expected O, but got I
				//IL_013d: Expected O, but got I
				//IL_0155: Expected O, but got I
				//IL_02f3: Expected O, but got I8
				//IL_0209: Expected O, but got I
				//IL_0314: Expected O, but got I
				//IL_0361: Expected O, but got I
				//IL_0374: Unknown result type (might be due to invalid IL or missing references)
				//IL_0379: Expected I4, but got Unknown
				//IL_025d: Expected O, but got I8
				//IL_0618: Expected O, but got I4
				//IL_0677: Expected O, but got I
				//IL_0693: Expected O, but got I4
				//IL_06af: Expected O, but got I
				//IL_027e: Expected O, but got I
				//IL_038f: Expected O, but got I
				//IL_02a7: Expected O, but got I
				//IL_0402: Expected O, but got I
				//IL_0420: Expected O, but got I
				//IL_042f: Expected O, but got I
				//IL_0474: Expected O, but got I
				//IL_03c2: Expected O, but got I
				//IL_03e1: Expected O, but got I
				//IL_0492: Expected O, but got I
				//IL_04d3: Expected O, but got I
				//IL_050b: Expected O, but got I
				//IL_052b: Expected I4, but got I8
				//IL_0570: Expected O, but got I
				//IL_06d4: Expected O, but got I
				//IL_06ee: Expected I4, but got I8
				//IL_074b: Expected O, but got I
				//IL_058f: Expected O, but got I
				//IL_05ec: Expected O, but got I
				object obj = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ SYSREG+28]");
				_ = 0;
				nint num = 0;
				nint num2 = 0;
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X8_v3 (Il2CppClass<TKey>)+FC]");
				object obj2 = (nint)0 + (nint)15;
				int num4 = (int)((nint)obj2 & 0x1FFFFFFF0L);
				object obj4 = default(object);
				object obj3 = (nint)obj4 - num4;
				object obj5 = (nint)obj4 - num4;
				object obj6 = (nint)obj4 - num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ X9_v1 (Il2CppClass<TValue>)+FC]");
				object obj7 = (nint)0 + (nint)15;
				int num5 = (int)((nint)obj7 & 0x1FFFFFFF0L);
				object obj8 = (nint)obj4 - num5;
				object obj9 = (nint)obj4 - num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X8_v3 (Il2CppClass<TKey>)+FC]");
				_ = 0;
				object obj10 = (nint)obj4 - num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X10_v1 (Il2CppClass<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>)+FC]");
				object obj11 = (nint)0 + (nint)15;
				int num6 = (int)((nint)obj11 & 0x1FFFFFFF0L);
				object obj12 = (nint)obj4 - num6;
				object obj13 = (nint)obj4 - num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F20 (native memset)");
				object obj14 = (nint)obj4 - num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ X9_v1 (Il2CppClass<TValue>)+FC]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F20 (native memset)");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94BC");
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ X8_v22 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>)+80]");
				nint num9 = (nint)0 + (nint)64;
				int count = ((List<TKey>)this).Count;
				int value = ((int*)count)->m_value;
				object obj15 = default(object);
				bool result;
				int num12;
				if ((nint)obj15 != 1)
				{
					bool flag = obj15 == null;
					bool flag2 = !flag;
					result = false;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ X9_v1 (Il2CppClass<TValue>)+FC]");
					object obj16 = 0;
					object obj18 = default(object);
					object obj17 = obj18;
					if (flag2)
					{
						goto IL_062c;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X10_v1 (Il2CppClass<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>)+FC]");
					_ = 0;
					nint num10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AC7A4C");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94BC");
					object obj19 = 4294967295L;
					nint num11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ X8_v88 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>)+80]");
					object obj20 = (nint)0 + (nint)96;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AC7A4C");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94BC");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ X24_v2 (System.Int32)+28]");
					object obj21 = 0;
					num12 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X10_v1 (Il2CppClass<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>)+FC]");
					_ = 0;
					nint num13 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AC7A4C");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94BC");
					object obj22 = 4294967295L;
					nint num14 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v331 @ X8_v74 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>)+80]");
					object obj23 = (nint)0 + (nint)96;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94BC");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ X24_v2 (System.Int32)+28]");
					object obj24 = default(object);
					if (0 != (nint)obj24)
					{
						InvalidOperationException ex = new InvalidOperationException("Collection was modified; enumeration operation may not execute.");
						object obj16 = 0;
						throw ex;
					}
					nint num15 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ X8_v79 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>)+80]");
					object obj25 = (nint)0 + (nint)128;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94BC");
					object obj26 = default(object);
					num12 = obj26 + 1;
				}
				nint num16 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ X8_v27 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>)+80]");
				object obj27 = (nint)0 + (nint)128;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AC7A4C");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94BC");
				object obj28 = num12;
				nint num17 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ X8_v31 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>)+80]");
				object obj29 = (nint)0 + (nint)128;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94BC");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ X24_v2 (System.Int32)+18]");
				int count2 = ((List<TKey>)0).Count;
				object obj30 = default(object);
				if ((nint)obj30 == count2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-60]");
					object obj17 = 0;
					num9 = 0;
					result = false;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ X9_v1 (Il2CppClass<TValue>)+FC]");
					object obj16 = 0;
				}
				else
				{
					nint num18 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ X8_v36 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>)+80]");
					object obj31 = (nint)0 + (nint)128;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94BC");
					object obj32 = (nint)obj - 12;
					object obj33 = (nint)obj - 32;
					nint num19 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v462 @ X1_v11 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
					nint num20 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v473 @ X8_v44 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>)+80]");
					object obj34 = (nint)0 + (nint)128;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94BC");
					object obj35 = (nint)obj - 32;
					nint num21 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-50]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v478 @ X1_v14 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-48]");
					object obj36 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F20 (native memset)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-60]");
					object obj17 = 0;
					nint num22 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v502 @ X9_v7 (Il2CppClass<TKey>)+28]");
					global::Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType key;
					if (0 == 0)
					{
						key = (global::Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType)obj36;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-68]");
						key = (global::Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
					}
					nint num23 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-58]");
					global::Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType value2 = (global::Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ X9_v9 (Il2CppClass<TValue>)+28]");
					if (0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-28]");
						object obj37 = 0;
						value2 = (global::Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType)obj37;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-40]");
					*(KeyValuePair<global::Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType, global::Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>*)null = new KeyValuePair<global::Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType, global::Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>(key, value2);
					nint num24 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v541 @ X8_v55 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>)+80]");
					object obj38 = (nint)0 + (nint)32;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94C0");
					nint num25 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AC7A4C");
					int count3 = ((List<TKey>)this).Count;
					((int*)count3)->m_value = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ X8_v59 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>)+80]");
					num9 = 0;
					result = true;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-40]");
					object obj16 = 0;
				}
				goto IL_062c;
				IL_062c:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ X23_v5+28]");
				nint num26 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-8]");
				if (num26 == 0)
				{
					return result;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EB0 (native __stack_chk_fail)");
				bool result2 = default(bool);
				return result2;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600078C")]
			[Address(RVA = "0xDCD640", Offset = "0xDCD640", Length = "0x34")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v25);\n\tthrow v25;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x4000460")]
		[FieldOffset(Offset = "0x0")]
		private readonly Dictionary<TKey, int> dictionary;

		[Token(Token = "0x4000461")]
		[FieldOffset(Offset = "0x0")]
		private readonly List<TKey> keys;

		[Token(Token = "0x4000462")]
		[FieldOffset(Offset = "0x0")]
		private readonly List<TValue> values;

		[Token(Token = "0x4000463")]
		[FieldOffset(Offset = "0x0")]
		private int version;

		[Token(Token = "0x4000464")]
		private const string CollectionModifiedMessage = "Collection was modified; enumeration operation may not execute.";

		[Token(Token = "0x4000465")]
		private const string EditReadOnlyListMessage = "An attempt was made to edit a read-only list.";

		[Token(Token = "0x4000466")]
		private const string IndexOutOfRangeMessage = "The index is negative or outside the bounds of the collection.";

		[Token(Token = "0x170001C3")]
		public IEqualityComparer<TKey> Comparer
		{
			[Token(Token = "0x6000756")]
			[Address(RVA = "0x11335E0", Offset = "0x11335E0", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.dictionary;\n\tv8 = Il2CppMethodInfo;\n\tv9 = *([v8 @ X1_v1 (Il2CppMethodInfo)]);\n\t// 11 IndirectJump v9 @ X2_v1, v2 @ X0_v1 (System.Collections.Generic.Dictionary`2<TKey, System.Int32>), v2 @ X0_v1 (System.Collections.Generic.Dictionary`2<TKey, System.Int32>), methodof(System.Collections.Generic.Dictionary`2<TKey, System.Int32>::get_Comparer), v9 @ X2_v1, v11 @ X3, v12 @ X4, v13 @ X5, v14 @ X6, v15 @ X7, v16 @ V0, v17 @ V1, v18 @ V2, v19 @ V3, v20 @ V4, v21 @ V5, v22 @ V6, v23 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_001d: Expected O, but got I
				Dictionary<TKey, int> dictionary = this.dictionary;
				nint num = 0;
				object obj = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v9 @ X2_v1 (should have been resolved before IL gen)");
				return null;
			}
		}

		[Token(Token = "0x170001C4")]
		public KeyCollection Keys
		{
			[Token(Token = "0x600075C")]
			[Address(RVA = "0x1133EB4", Offset = "0x1133EB4", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv18 = 0xB348B0(v13, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0010:\n\tv34 = new Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+KeyCollection<TKey, TValue>>();\n\tv41 = Spine.Collections.OrderedDictionary`2<TKey, TValue>+KeyCollection<TKey, TValue>::.ctor(v34, this.dictionary);\n\treturn v34;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return new KeyCollection(dictionary);
			}
		}

		[Token(Token = "0x170001C5")]
		public ValueCollection Values
		{
			[Token(Token = "0x6000760")]
			[Address(RVA = "0x11344B0", Offset = "0x11344B0", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv18 = 0xB348B0(v13, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0010:\n\tv34 = new Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+ValueCollection<TKey, TValue>>();\n\tv41 = Spine.Collections.OrderedDictionary`2<TKey, TValue>+ValueCollection<TKey, TValue>::.ctor(v34, this.values);\n\treturn v34;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return new ValueCollection(values);
			}
		}

		[Token(Token = "0x170001C6")]
		public TValue this[int index]
		{
			[Token(Token = "0x6000761")]
			[Address(RVA = "0x113450C", Offset = "0x113450C", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = &v13 @ stack_-30_v2;\n\t*([v12 @ X29_v1-8]) = *([v15 @ SYSREG+28]);\n\tv19 = *([v92 @ X3_v1+20]);\n\tv21 = *([v19 @ X8_v2+C0]);\n\tv22 = *([v21 @ X8_v3+88]);\n\tv26 = *([v22 @ X9_v1+FC]) + 0xF;\n\tv27 = v26 & 0x1FFFFFFF0;\n\tv28 = &v25 @ stack_-50_v1 - v27;\n\tv33 = *([v21 @ X8_v3+110]);\n\tv34 = &v13 @ stack_-30_v2 - 0xC;\n\tv35 = &v13 @ stack_-30_v2 - 0x20;\n\t*([v12 @ X29_v1-C]) = v89;\n\t*([v12 @ X29_v1-20]) = v34;\n\t*([v12 @ X29_v1-18]) = v28;\n\t*([v33 @ X8_v5+10])(v41, *([v33 @ X8_v5]), *([v21 @ X8_v3+110]), this.values, v35, v28, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\treturnVal1 = 0x1854F10(methodInfo, v28, *([v22 @ X9_v1+FC]), v35, v28, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv70 = *([v15 @ SYSREG+28]) != *([v12 @ X29_v1-8]);\n\tif (v70) goto L_003F;\n\treturn returnVal1;\n\tv57 = new System.NullReferenceException();\nL_003F:\n\treturnVal2 = 0x1854EB0(v90, v89, this.values, v92, v91, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\treturn returnVal2;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0025: Expected O, but got I
				//IL_0035: Expected O, but got I
				//IL_0045: Expected O, but got I
				//IL_005b: Expected O, but got I
				//IL_006e: Expected I4, but got I8
				//IL_0091: Expected O, but got I
				//IL_00a0: Expected O, but got I
				//IL_00af: Expected O, but got I
				object obj2 = default(object);
				object obj = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ SYSREG+28]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ X3_v1+20]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X8_v2+C0]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X8_v3+88]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X9_v1+FC]");
				object obj6 = (nint)0 + (nint)15;
				int num = (int)((nint)obj6 & 0x1FFFFFFF0L);
				object obj7 = default(object);
				int num2 = (int)((nint)obj7 - num);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X8_v3+110]");
				object obj8 = 0;
				object obj9 = (nint)obj2 - 12;
				object obj10 = (nint)obj2 - 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v33 @ X8_v5+10] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ SYSREG+28]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1-8]");
				TValue result = default(TValue);
				if (num3 == 0)
				{
					return result;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EB0 (native __stack_chk_fail)");
				TValue result2 = default(TValue);
				return result2;
			}
			[Token(Token = "0x6000762")]
			[Address(RVA = "0x11345C0", Offset = "0x11345C0", Length = "0xE0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = &v15 @ stack_-40_v2;\n\t*([v14 @ X29_v1-8]) = *([v17 @ SYSREG+28]);\n\t*([v14 @ X29_v1-28]) = value;\n\tv27 = Il2CppClass<TValue>;\n\tv29 = *([v27 @ X9_v1 (Il2CppClass<TValue>)+FC]) + 0xF;\n\tv30 = v29 & 0x1FFFFFFF0;\n\tv78 = &v20 @ stack_-70_v1 - v30;\n\tv40 = *([v27 @ X9_v1 (Il2CppClass<TValue>)+28]) < 0;\n\tv43 = *([v27 @ X9_v1 (Il2CppClass<TValue>)+28]) ^ *([v27 @ X9_v1 (Il2CppClass<TValue>)+28]);\n\tv44 = *([v27 @ X9_v1 (Il2CppClass<TValue>)+28]) & v43;\n\tv45 = v44 < 0;\n\tv46 = &v15 @ stack_-40_v2 - 0x28;\n\tv47 = v40 == v45;\n\tv48 = ~v47;\n\tv49 = ~v48;\n\tif (v49) goto L_FFFFFFFF;\n\tgoto L_002E;\nL_002E:\n\tv54 = 0x1854F10(v78, v52, *([v27 @ X9_v1 (Il2CppClass<TValue>)+FC]), v98, v97, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv70 = Il2CppMethodInfo;\n\tgoto L_003B;\n\tv77 = *([v31 @ X20_v1]);\nL_003B:\n\tv79 = &v15 @ stack_-40_v2 - 0xC;\n\t*([v14 @ X29_v1-C]) = index;\n\t*([v14 @ X29_v1-20]) = v79;\n\t*([v14 @ X29_v1-18]) = v78;\n\tv81 = &v15 @ stack_-40_v2 - 0x20;\n\t*([v70 @ X1_v3 (Il2CppMethodInfo)+10])(v84, *([v70 @ X1_v3 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.values, v81, v78, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv96 = *([v17 @ SYSREG+28]) != *([v14 @ X29_v1-8]);\n\tif (v96) goto L_005C;\n\treturn;\n\tv76 = new System.NullReferenceException();\nL_005C:\n\tv115 = 0x1854EB0(v110, v52, *([v27 @ X9_v1 (Il2CppClass<TValue>)+FC]), v98, v97, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0036: Expected O, but got I
				//IL_0049: Expected I4, but got I8
				//IL_0057: Expected O, but got I
				//IL_00be: Expected O, but got I
				//IL_013f: Expected O, but got I
				object obj2 = default(object);
				object obj = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ SYSREG+28]");
				_ = 0;
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ X9_v1 (Il2CppClass<TValue>)+FC]");
				object obj3 = (nint)0 + (nint)15;
				int num2 = (int)((nint)obj3 & 0x1FFFFFFF0L);
				object obj5 = default(object);
				object obj4 = (nint)obj5 - num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ X9_v1 (Il2CppClass<TValue>)+28]");
				bool flag = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ X9_v1 (Il2CppClass<TValue>)+28]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ X9_v1 (Il2CppClass<TValue>)+28]");
				int num4 = (int)(num3 ^ 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ X9_v1 (Il2CppClass<TValue>)+28]");
				int num5 = (int)((nint)0 & (nint)num4);
				bool flag2 = num5 < 0;
				TValue val = (TValue)((nint)obj2 - 40);
				if (flag != flag2)
				{
					TValue val2 = value;
				}
				else
				{
					TValue val2 = val;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
				nint num6 = 0;
				object obj6 = (nint)obj2 - 12;
				nint num7 = (nint)obj2 - 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v70 @ X1_v3 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ SYSREG+28]");
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ X29_v1-8]");
				if (num8 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EB0 (native __stack_chk_fail)");
				}
			}
		}

		[Token(Token = "0x170001C7")]
		public TValue this[TKey key]
		{
			[Token(Token = "0x6000763")]
			[Address(RVA = "0x11346A0", Offset = "0x11346A0", Length = "0x150")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = &v23 @ stack_-60_v2;\n\t*([v22 @ X29_v1-8]) = *([v25 @ SYSREG+28]);\n\t*([v22 @ X29_v1-28]) = v70;\n\tv32 = *([v30 @ X3+20]);\n\tv33 = *([v32 @ X27_v1+C0]);\n\tv34 = *([v33 @ X8_v2+68]);\n\tv35 = *([v33 @ X8_v2+88]);\n\tv40 = *([v34 @ X9_v1+FC]) + 0xF;\n\tv41 = v40 & 0x1FFFFFFF0;\n\tv111 = &v39 @ stack_-90_v1 - v41;\n\tv44 = *([v35 @ X8_v3+FC]) + 0xF;\n\tv47 = v44 & 0x1FFFFFFF0;\n\tv48 = &v39 @ stack_-90_v1 - v47;\n\tv58 = *([v34 @ X9_v1+28]) < 0;\n\tv61 = *([v34 @ X9_v1+28]) ^ *([v34 @ X9_v1+28]);\n\tv62 = *([v34 @ X9_v1+28]) & v61;\n\tv63 = v62 < 0;\n\tv64 = &v23 @ stack_-60_v2 - 0x28;\n\tv65 = v58 == v63;\n\tv66 = ~v65;\n\tv67 = ~v66;\n\tif (v67) goto L_003A;\n\tgoto L_003A;\nL_003A:\n\tv71 = 0x1854F10(v111, v64, *([v34 @ X9_v1+FC]), v30, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83);\n\tv85 = *([v32 @ X27_v1+C0]);\n\tv86 = *([v85 @ X8_v10+68]);\n\tv87 = *([v85 @ X8_v10+A0]);\n\tv90 = *([v86 @ X9_v4+28]) & 0x80000000;\n\tv91 = v90 == 0;\n\tv92 = ~v91;\n\tif (v92) goto L_0047;\n\tv111 = *([v111 @ X24_v4]);\nL_0047:\n\t*([v22 @ X29_v1-20]) = v111;\n\tv96 = &v23 @ stack_-60_v2 - 0x20;\n\tv94 = &v23 @ stack_-60_v2 - 0xC;\n\tv103 = &v23 @ stack_-60_v2 - 0xC;\n\t*([v87 @ X1_v4+10])(v99, *([v87 @ X1_v4]), *([v85 @ X8_v10+A0]), this.dictionary, v96, v94, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83);\n\tv147 = *([v30 @ X3+20]);\n\tv115 = &v23 @ stack_-60_v2 - 0x20;\n\tv149 = *([v147 @ X8_v13+C0]);\n\tv150 = *([v149 @ X8_v14+110]);\n\t*([v22 @ X29_v1-C]) = *([v22 @ X29_v1-C]);\n\t*([v22 @ X29_v1-20]) = v103;\n\t*([v22 @ X29_v1-18]) = v48;\n\t*([v150 @ X1_v5+10])(v154, *([v150 @ X1_v5]), *([v149 @ X8_v14+110]), this.values, v115, v48, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83);\n\treturnVal2 = 0x1854F10(methodInfo, v48, *([v35 @ X8_v3+FC]), v115, v48, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83);\n\tv119 = *([v25 @ SYSREG+28]) != *([v22 @ X29_v1-8]);\n\tif (v119) goto L_007D;\n\treturn returnVal2;\n\tv109 = new System.NullReferenceException();\nL_007D:\n\treturnVal1 = 0x1854EB0(v136, v116, v140, v114, v112, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83);\n\treturn returnVal1;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_002a: Expected O, but got I
				//IL_003a: Expected O, but got I
				//IL_004a: Expected O, but got I
				//IL_005a: Expected O, but got I
				//IL_0070: Expected O, but got I
				//IL_0083: Expected I4, but got I8
				//IL_0091: Expected O, but got I
				//IL_00a7: Expected O, but got I
				//IL_00ba: Expected I4, but got I8
				//IL_00c8: Expected O, but got I
				//IL_012f: Expected O, but got I
				//IL_0176: Expected O, but got I
				//IL_0186: Expected O, but got I
				//IL_0196: Expected O, but got I
				//IL_01b0: Expected I4, but got I8
				//IL_02b5: Expected O, but got I
				//IL_02c4: Expected O, but got I
				//IL_02d3: Expected O, but got I
				//IL_01f5: Expected O, but got I
				//IL_0204: Expected O, but got I
				//IL_0214: Expected O, but got I
				//IL_0224: Expected O, but got I
				object obj2 = default(object);
				object obj = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ SYSREG+28]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X3+20]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X27_v1+C0]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ X8_v2+68]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ X8_v2+88]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X9_v1+FC]");
				object obj7 = (nint)0 + (nint)15;
				int num = (int)((nint)obj7 & 0x1FFFFFFF0L);
				object obj9 = default(object);
				object obj8 = (nint)obj9 - num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ X8_v3+FC]");
				object obj10 = (nint)0 + (nint)15;
				int num2 = (int)((nint)obj10 & 0x1FFFFFFF0L);
				object obj11 = (nint)obj9 - num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X9_v1+28]");
				bool flag = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X9_v1+28]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X9_v1+28]");
				int num4 = (int)(num3 ^ 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X9_v1+28]");
				int num5 = (int)((nint)0 & (nint)num4);
				bool flag2 = num5 < 0;
				TKey val = (TKey)((nint)obj2 - 40);
				if (flag != flag2)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X27_v1+C0]");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ X8_v10+68]");
				object obj13 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ X8_v10+A0]");
				object obj14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ X9_v4+28]");
				if (0 == 0)
				{
					obj8 = obj8;
				}
				object obj15 = (nint)obj2 - 32;
				object obj16 = (nint)obj2 - 12;
				object obj17 = (nint)obj2 - 12;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v87 @ X1_v4+10] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X3+20]");
				object obj18 = 0;
				object obj19 = (nint)obj2 - 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ X8_v13+C0]");
				object obj20 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ X8_v14+110]");
				object obj21 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1-C]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v150 @ X1_v5+10] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ SYSREG+28]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1-8]");
				TValue result = default(TValue);
				if (num6 == 0)
				{
					return result;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EB0 (native __stack_chk_fail)");
				TValue result2 = default(TValue);
				return result2;
			}
			[Token(Token = "0x6000764")]
			[Address(RVA = "0x11347F0", Offset = "0x11347F0", Length = "0x29C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-60_v2;\n\t*([v24 @ X29_v1-8]) = *([v27 @ SYSREG+28]);\n\t*([v24 @ X29_v1-30]) = value;\n\t*([v24 @ X29_v1-28]) = v291;\n\t*([v24 @ X29_v1-40]) = value;\n\tv38 = Il2CppClass<TKey>;\n\tv39 = Il2CppClass<TValue>;\n\tv44 = *([v38 @ X9_v1 (Il2CppClass<TKey>)+FC]) + 0xF;\n\tv45 = v44 & 0x1FFFFFFF0;\n\tv347 = &v43 @ stack_-B0_v1 - v45;\n\tv48 = *([v39 @ X8_v3 (Il2CppClass<TValue>)+FC]) + 0xF;\n\tv51 = v48 & 0x1FFFFFFF0;\n\tv377 = &v43 @ stack_-B0_v1 - v51;\n\t*([v24 @ X29_v1-34]) = 0;\n\tv61 = *([v38 @ X9_v1 (Il2CppClass<TKey>)+28]) < 0;\n\tv64 = *([v38 @ X9_v1 (Il2CppClass<TKey>)+28]) ^ *([v38 @ X9_v1 (Il2CppClass<TKey>)+28]);\n\tv65 = *([v38 @ X9_v1 (Il2CppClass<TKey>)+28]) & v64;\n\tv66 = v65 < 0;\n\tv67 = &v25 @ stack_-60_v2 - 0x28;\n\tv68 = v61 == v66;\n\tv69 = ~v68;\n\tv70 = ~v69;\n\tif (v70) goto L_FFFFFFFF;\n\tgoto L_003F;\nL_003F:\n\tv74 = 0x1854F10(v347, v73, *([v38 @ X9_v1 (Il2CppClass<TKey>)+FC]), methodInfo, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86);\n\tv90 = Il2CppMethodInfo;\n\tgoto L_004D;\n\tv163 = *([v46 @ X21_v1]);\nL_004D:\n\tv150 = &v25 @ stack_-60_v2 - 0x34;\n\t*([v24 @ X29_v1-20]) = v347;\n\t*([v24 @ X29_v1-18]) = v150;\n\tv101 = &v25 @ stack_-60_v2 - 0x20;\n\tv98 = &v25 @ stack_-60_v2 - 0xC;\n\t*([v24 @ X29_v1-48]) = v27;\n\t*([v90 @ X1_v4 (Il2CppMethodInfo)+10])(v167, *([v90 @ X1_v4 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.dictionary, v101, v98, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86);\n\tv169 = *([v24 @ X29_v1-C]) == 0;\n\tif (v169) goto L_00BA;\n\tv221 = Il2CppClass<TKey>;\n\tv128 = *([v221 @ X8_v30 (Il2CppClass<TKey>)+28]) < 0;\n\tv119 = *([v221 @ X8_v30 (Il2CppClass<TKey>)+28]) ^ *([v221 @ X8_v30 (Il2CppClass<TKey>)+28]);\n\tv116 = *([v221 @ X8_v30 (Il2CppClass<TKey>)+28]) & v119;\n\tv113 = v116 < 0;\n\tv157 = &v25 @ stack_-60_v2 - 0x28;\n\tv224 = v128 == v113;\n\tv110 = ~v224;\n\tv107 = ~v110;\n\tif (v107) goto L_FFFFFFFF;\n\tgoto L_0073;\nL_0073:\n\tv140 = 0x1854F10(v347, v291, *([v38 @ X9_v1 (Il2CppClass<TKey>)+FC]), v101, v98, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86);\n\tv314 = Il2CppMethodInfo;\n\tgoto L_0080;\n\tv322 = *([v46 @ X21_v1]);\nL_0080:\n\tv324 = &v25 @ stack_-60_v2 - 0xC;\n\t*([v24 @ X29_v1-C]) = *([v24 @ X29_v1-34]);\n\t*([v24 @ X29_v1-20]) = v324;\n\t*([v24 @ X29_v1-18]) = v347;\n\tv102 = &v25 @ stack_-60_v2 - 0x20;\n\t*([v314 @ X1_v14 (Il2CppMethodInfo)+10])(v327, *([v314 @ X1_v14 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.keys, v102, v347, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86);\n\tv330 = Il2CppClass<TValue>;\n\tv129 = *([v330 @ X8_v38 (Il2CppClass<TValue>)+28]) < 0;\n\tv120 = *([v330 @ X8_v38 (Il2CppClass<TValue>)+28]) ^ *([v330 @ X8_v38 (Il2CppClass<TValue>)+28]);\n\tv117 = *([v330 @ X8_v38 (Il2CppClass<TValue>)+28]) & v120;\n\tv114 = v117 < 0;\n\tv158 = &v25 @ stack_-60_v2 - 0x30;\n\tv333 = v129 == v114;\n\tv111 = ~v333;\n\tv108 = ~v111;\n\tif (v108) goto L_FFFFFFFF;\n\tgoto L_00A4;\nL_00A4:\n\tv141 = 0x1854F10(v377, v105, *([v39 @ X8_v3 (Il2CppClass<TValue>)+FC]), v102, v347, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86);\n\tv358 = Il2CppMethodInfo;\n\tv376 = *([v358 @ X1_v16 (Il2CppMethodInfo)]);\n\tgoto L_00B1;\n\tv384 = *([v52 @ X19_v1]);\nL_00B1:\n\tv217 = *([v24 @ X29_v1-48]);\n\tv380 = &v25 @ stack_-60_v2 - 0xC;\n\t*([v24 @ X29_v1-C]) = *([v24 @ X29_v1-34]);\n\t*([v24 @ X29_v1-20]) = v380;\n\tgoto L_00FB;\nL_00BA:\n\tv229 = Il2CppClass<TKey>;\n\tv234 = *([v229 @ X8_v19 (Il2CppClass<TKey>)+28]) < 0;\n\tv237 = *([v229 @ X8_v19 (Il2CppClass<TKey>)+28]) ^ *([v229 @ X8_v19 (Il2CppClass<TKey>)+28]);\n\tv238 = *([v229 @ X8_v19 (Il2CppClass<TKey>)+28]) & v237;\n\tv239 = v238 < 0;\n\tv240 = &v25 @ stack_-60_v2 - 0x28;\n\tv241 = v234 == v239;\n\tv242 = ~v241;\n\tv243 = ~v242;\n\tif (v243) goto L_FFFFFFFF;\n\tgoto L_00CE;\nL_00CE:\n\tv292 = 0x1854F10(v347, v291, *([v38 @ X9_v1 (Il2CppClass<TKey>)+FC]), v101, v98, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86);\n\tv297 = Il2CppClass<TValue>;\n\tv302 = *([v297 @ X8_v23 (Il2CppClass<TValue>)+28]) < 0;\n\tv305 = *([v297 @ X8_v23 (Il2CppClass<TValue>)+28]) ^ *([v297 @ X8_v23 (Il2CppClass<TValue>)+28]);\n\tv306 = *([v297 @ X8_v23 (Il2CppClass<TValue>)+28]) & v305;\n\tv307 = v306 < 0;\n\tv308 = &v25 @ stack_-60_v2 - 0x30;\n\tv309 = v302 == v307;\n\tv310 = ~v309;\n\tv311 = ~v310;\n\tif (v311) goto L_FFFFFFFF;\n\tgoto L_00E7;\nL_00E7:\n\tv335 = 0x1854F10(v377, v334, *([v39 @ X8_v3 (Il2CppClass<TValue>)+FC]), v101, v98, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86);\n\tv340 = Il2CppMethodInfo;\n\tv376 = *([v340 @ X1_v8 (Il2CppMethodInfo)]);\n\tgoto L_00F3;\n\tv346 = *([v46 @ X21_v1]);\nL_00F3:\n\tv217 = *([v24 @ X29_v1-48]);\n\tgoto L_00FA;\n\tv354 = *([v52 @ X19_v1]);\nL_00FA:\n\t*([v24 @ X29_v1-20]) = v347;\nL_00FB:\n\t*([v24 @ X29_v1-18]) = v377;\n\tv173 = &v25 @ stack_-60_v2 - 0x20;\n\t*([v175 @ X1_v5 (Il2CppMethodInfo)+10])(v199, v376, v175, v213, v173, v377, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86);\n\tv179 = *([v217 @ X22_v4+28]) != *([v24 @ X29_v1-8]);\n\tif (v179) goto L_011E;\n\treturn;\n\tv162 = new System.NullReferenceException();\nL_011E:\n\tv218 = 0x1854EB0(v198, v174, v196, v172, v170, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86);\n\treturn;\n// 168 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0046: Expected O, but got I
				//IL_0059: Expected I4, but got I8
				//IL_0067: Expected O, but got I
				//IL_007d: Expected O, but got I
				//IL_0090: Expected I4, but got I8
				//IL_009e: Expected O, but got I
				//IL_010b: Expected O, but got I
				//IL_0350: Expected O, but got I
				//IL_0369: Expected O, but got I
				//IL_0378: Expected O, but got I
				//IL_02c0: Expected O, but got I
				//IL_01cf: Expected O, but got I
				//IL_0565: Expected O, but got I
				//IL_05af: Expected O, but got I
				//IL_0314: Expected O, but got I
				//IL_05c4: Expected O, but got I
				//IL_03ca: Expected O, but got I
				//IL_03f0: Expected O, but got I
				//IL_0467: Expected O, but got I
				//IL_05dd: Expected O, but got I
				//IL_022e: Expected O, but got I
				//IL_024e: Expected O, but got I
				//IL_04b8: Expected O, but got I
				//IL_04c7: Expected O, but got I
				object obj2 = default(object);
				object obj = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ SYSREG+28]");
				_ = 0;
				nint num = 0;
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X9_v1 (Il2CppClass<TKey>)+FC]");
				object obj3 = (nint)0 + (nint)15;
				int num3 = (int)((nint)obj3 & 0x1FFFFFFF0L);
				object obj5 = default(object);
				object obj4 = (nint)obj5 - num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ X8_v3 (Il2CppClass<TValue>)+FC]");
				object obj6 = (nint)0 + (nint)15;
				int num4 = (int)((nint)obj6 & 0x1FFFFFFF0L);
				object obj7 = (nint)obj5 - num4;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X9_v1 (Il2CppClass<TKey>)+28]");
				bool flag = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X9_v1 (Il2CppClass<TKey>)+28]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X9_v1 (Il2CppClass<TKey>)+28]");
				int num6 = (int)(num5 ^ 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X9_v1 (Il2CppClass<TKey>)+28]");
				int num7 = (int)((nint)0 & (nint)num6);
				bool flag2 = num7 < 0;
				TKey val = (TKey)((nint)obj2 - 40);
				if (flag != flag2)
				{
					TKey val3 = default(TKey);
					TKey val2 = val3;
				}
				else
				{
					TKey val2 = val;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
				nint num8 = 0;
				object obj8 = (nint)obj2 - 52;
				object obj9 = (nint)obj2 - 32;
				object obj10 = (nint)obj2 - 12;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v90 @ X1_v4 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-C]");
				if ((nint)0 != 0)
				{
					nint num9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ X8_v30 (Il2CppClass<TKey>)+28]");
					bool flag3 = (nint)0 < (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ X8_v30 (Il2CppClass<TKey>)+28]");
					nint num10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ X8_v30 (Il2CppClass<TKey>)+28]");
					int num11 = (int)(num10 ^ 0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ X8_v30 (Il2CppClass<TKey>)+28]");
					int num12 = (int)((nint)0 & (nint)num11);
					bool flag4 = num12 < 0;
					TKey val4 = (TKey)((nint)obj2 - 40);
					if (flag3 == flag4)
					{
						TKey val3 = val4;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
					nint num13 = 0;
					object obj11 = (nint)obj2 - 12;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-34]");
					_ = 0;
					object obj12 = (nint)obj2 - 32;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v314 @ X1_v14 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
					nint num14 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ X8_v38 (Il2CppClass<TValue>)+28]");
					bool flag5 = (nint)0 < (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ X8_v38 (Il2CppClass<TValue>)+28]");
					nint num15 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ X8_v38 (Il2CppClass<TValue>)+28]");
					int num16 = (int)(num15 ^ 0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ X8_v38 (Il2CppClass<TValue>)+28]");
					int num17 = (int)((nint)0 & (nint)num16);
					bool flag6 = num17 < 0;
					object obj13 = (nint)obj2 - 48;
					if (flag5 != flag6)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-40]");
						object obj14 = 0;
					}
					else
					{
						object obj14 = obj13;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
					nint num18 = 0;
					object obj15 = num18;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-48]");
					object obj16 = 0;
					object obj17 = (nint)obj2 - 12;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-34]");
					_ = 0;
					nint num19 = 0;
					OrderedDictionary<TKey, TValue> orderedDictionary = (OrderedDictionary<TKey, TValue>)(object)values;
				}
				else
				{
					nint num20 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ X8_v19 (Il2CppClass<TKey>)+28]");
					bool flag7 = (nint)0 < (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ X8_v19 (Il2CppClass<TKey>)+28]");
					nint num21 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ X8_v19 (Il2CppClass<TKey>)+28]");
					int num22 = (int)(num21 ^ 0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ X8_v19 (Il2CppClass<TKey>)+28]");
					int num23 = (int)((nint)0 & (nint)num22);
					bool flag8 = num23 < 0;
					TKey val5 = (TKey)((nint)obj2 - 40);
					if (flag7 == flag8)
					{
						TKey val3 = val5;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
					nint num24 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ X8_v23 (Il2CppClass<TValue>)+28]");
					bool flag9 = (nint)0 < (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ X8_v23 (Il2CppClass<TValue>)+28]");
					nint num25 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ X8_v23 (Il2CppClass<TValue>)+28]");
					int num26 = (int)(num25 ^ 0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ X8_v23 (Il2CppClass<TValue>)+28]");
					int num27 = (int)((nint)0 & (nint)num26);
					bool flag10 = num27 < 0;
					object obj18 = (nint)obj2 - 48;
					if (flag9 != flag10)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-40]");
						object obj19 = 0;
					}
					else
					{
						object obj19 = obj18;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
					nint num28 = 0;
					object obj15 = num28;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-48]");
					object obj16 = 0;
					nint num19 = 0;
					OrderedDictionary<TKey, TValue> orderedDictionary = this;
				}
				object obj20 = (nint)obj2 - 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v175 @ X1_v5 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ X22_v4+28]");
				nint num29 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-8]");
				if (num29 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EB0 (native __stack_chk_fail)");
				}
			}
		}

		[Token(Token = "0x170001C8")]
		public int Count
		{
			[Token(Token = "0x6000766")]
			[Address(RVA = "0x1134B0C", Offset = "0x1134B0C", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.dictionary;\n\tv8 = Il2CppMethodInfo;\n\tv9 = *([v8 @ X1_v1 (Il2CppMethodInfo)]);\n\t// 11 IndirectJump v9 @ X2_v1, v2 @ X0_v1 (System.Collections.Generic.Dictionary`2<TKey, System.Int32>), v2 @ X0_v1 (System.Collections.Generic.Dictionary`2<TKey, System.Int32>), methodof(System.Collections.Generic.Dictionary`2<TKey, System.Int32>::get_Count), v9 @ X2_v1, v11 @ X3, v12 @ X4, v13 @ X5, v14 @ X6, v15 @ X7, v16 @ V0, v17 @ V1, v18 @ V2, v19 @ V3, v20 @ V4, v21 @ V5, v22 @ V6, v23 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_001d: Expected O, but got I
				Dictionary<TKey, int> dictionary = this.dictionary;
				nint num = 0;
				object obj = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v9 @ X2_v1 (should have been resolved before IL gen)");
				return 0;
			}
		}

		[Token(Token = "0x170001C9")]
		unsafe KeyValuePair<TKey, TValue> IList<KeyValuePair<TKey, TValue>>.this[int index]
		{
			[Token(Token = "0x600076A")]
			[Address(RVA = "0x1134EE8", Offset = "0x1134EE8", Length = "0x230")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-60_v2;\n\t*([v24 @ X29_v1-30]) = methodInfo;\n\t*([v24 @ X29_v1-28]) = v27;\n\t*([v24 @ X29_v1-8]) = *([v27 @ SYSREG+28]);\n\tv36 = *([v31 @ X3+20]);\n\tv37 = *([v36 @ X8_v3+C0]);\n\tv38 = *([v37 @ X24_v1+68]);\n\tv39 = *([v37 @ X24_v1+88]);\n\tv40 = *([v37 @ X24_v1+178]);\n\t*([v24 @ X29_v1-50]) = *([v38 @ X9_v1+FC]);\n\tv46 = *([v38 @ X9_v1+FC]) + 0xF;\n\tv47 = v46 & 0x1FFFFFFF0;\n\tv48 = &v45 @ stack_-B0_v1 - v47;\n\tv52 = &v45 @ stack_-B0_v1 - v47;\n\t*([v24 @ X29_v1-48]) = v52;\n\tv54 = *([v39 @ X8_v4+FC]) + 0xF;\n\tv57 = v54 & 0x1FFFFFFF0;\n\tv58 = &v45 @ stack_-B0_v1 - v57;\n\tv62 = &v45 @ stack_-B0_v1 - v57;\n\tv66 = &v45 @ stack_-B0_v1 - v57;\n\t*([v24 @ X29_v1-40]) = v66;\n\t*([v24 @ X29_v1-38]) = *([v40 @ X10_v1+FC]);\n\tv68 = *([v40 @ X10_v1+FC]) + 0xF;\n\tv71 = v68 & 0x1FFFFFFF0;\n\tv72 = &v45 @ stack_-B0_v1 - v71;\n\tv76 = &v45 @ stack_-B0_v1 - v57;\n\tv81 = 0x1854F20(v76, 0, *([v39 @ X8_v4+FC]), v31, v82, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93);\n\tv96 = *([v37 @ X24_v1+98]);\n\tv97 = &v25 @ stack_-60_v2 - 0xC;\n\tv98 = &v25 @ stack_-60_v2 - 0x20;\n\t*([v24 @ X29_v1-C]) = index;\n\t*([v24 @ X29_v1-20]) = v97;\n\t*([v24 @ X29_v1-18]) = v48;\n\t*([v96 @ X1_v4+10])(v102, *([v96 @ X1_v4]), *([v37 @ X24_v1+98]), this.keys, v98, v48, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93);\n\tv114 = *([v31 @ X3+20]);\n\tv115 = &v25 @ stack_-60_v2 - 0x20;\n\tv117 = *([v114 @ X8_v17+C0]);\n\tv118 = *([v117 @ X8_v18+110]);\n\t*([v24 @ X29_v1-C]) = index;\n\t*([v24 @ X29_v1-20]) = v97;\n\t*([v24 @ X29_v1-18]) = v58;\n\t*([v118 @ X1_v5+10])(v121, *([v118 @ X1_v5]), *([v117 @ X8_v18+110]), this.values, v115, v58, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93);\n\tv125 = 0x1854F10(v76, v58, *([v39 @ X8_v4+FC]), v115, v58, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93);\n\tv184 = 0x1854F10(v62, v76, *([v39 @ X8_v4+FC]), v115, v58, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93);\n\tv188 = 0x1854F20(v72, 0, *([v24 @ X29_v1-38]), v115, v58, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93);\n\tv175 = *([v31 @ X3+20]);\n\tv261 = *([v175 @ X19_v3+C0]);\n\tv232 = *([v261 @ X8_v22+68]);\n\tv234 = *([v232 @ X9_v8+28]) & 0x80000000;\n\tv235 = v234 == 0;\n\tv236 = ~v235;\n\tif (v236) goto L_0075;\n\tv177 = *([v48 @ X28_v1]);\n\tgoto L_007A;\nL_0075:\n\tv177 = *([v24 @ X29_v1-48]);\n\tv242 = 0x1854F10(*([v24 @ X29_v1-48]), v48, *([v24 @ X29_v1-50]), v115, v58, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93);\n\tv261 = *([v175 @ X19_v3+C0]);\nL_007A:\n\tv248 = *([v261 @ X8_v22+88]);\n\tv173 = *([v24 @ X29_v1-28]);\n\tv165 = *([v24 @ X29_v1-40]);\n\tv251 = *([v248 @ X9_v10+28]) & 0x80000000;\n\tv252 = v251 == 0;\n\tv167 = ~v252;\n\tif (v167) goto L_0088;\n\tv165 = *([v62 @ X26_v1]);\n\tgoto L_008E;\nL_0088:\n\tv257 = 0x1854F10(*([v24 @ X29_v1-40]), v62, *([v39 @ X8_v4+FC]), v115, v58, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93);\n\tv261 = *([v175 @ X19_v3+C0]);\nL_008E:\n\tSystem.Collections.Generic.KeyValuePair`2<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType, Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>::.ctor(v72, v177, v165);\n\treturnVal2 = 0x1854F10(*([v24 @ X29_v1-30]), v72, *([v24 @ X29_v1-38]), *([v261 @ X8_v22+1A0]), v58, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93);\n\tv128 = *([v173 @ X20_v3+28]) != *([v24 @ X29_v1-8]);\n\tif (v128) goto L_00B0;\n\treturn returnVal2;\n\tv113 = new System.NullReferenceException();\nL_00B0:\n\treturnVal1 = 0x1854EB0(v160, v158, v156, v154, v153, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93);\n\treturn returnVal1;\n// 102 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_002f: Expected O, but got I
				//IL_003f: Expected O, but got I
				//IL_004f: Expected O, but got I
				//IL_005f: Expected O, but got I
				//IL_006f: Expected O, but got I
				//IL_0092: Expected O, but got I
				//IL_00a5: Expected I4, but got I8
				//IL_00b3: Expected O, but got I
				//IL_00c1: Expected O, but got I
				//IL_00dc: Expected O, but got I
				//IL_00ef: Expected I4, but got I8
				//IL_00fd: Expected O, but got I
				//IL_010b: Expected O, but got I
				//IL_0119: Expected O, but got I
				//IL_0141: Expected O, but got I
				//IL_0154: Expected I4, but got I8
				//IL_0162: Expected O, but got I
				//IL_0170: Expected O, but got I
				//IL_018f: Expected O, but got I
				//IL_019e: Expected O, but got I
				//IL_01ad: Expected O, but got I
				//IL_01db: Expected O, but got I
				//IL_01ea: Expected O, but got I
				//IL_01fa: Expected O, but got I
				//IL_020a: Expected O, but got I
				//IL_0256: Expected O, but got I
				//IL_0266: Expected O, but got I
				//IL_0276: Expected O, but got I
				//IL_0290: Expected I4, but got I8
				//IL_02d5: Expected O, but got I
				//IL_02ef: Expected O, but got I
				//IL_0344: Expected O, but got I
				//IL_0354: Expected O, but got I
				//IL_0364: Expected O, but got I
				//IL_037e: Expected I4, but got I8
				//IL_031b: Expected O, but got I
				//IL_03b2: Expected native int or pointer, but got O
				object obj2 = default(object);
				object obj = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ SYSREG+28]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ X3+20]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X8_v3+C0]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X24_v1+68]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X24_v1+88]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X24_v1+178]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X9_v1+FC]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X9_v1+FC]");
				object obj8 = (nint)0 + (nint)15;
				int num = (int)((nint)obj8 & 0x1FFFFFFF0L);
				object obj10 = default(object);
				object obj9 = (nint)obj10 - num;
				object obj11 = (nint)obj10 - num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ X8_v4+FC]");
				object obj12 = (nint)0 + (nint)15;
				int num2 = (int)((nint)obj12 & 0x1FFFFFFF0L);
				object obj13 = (nint)obj10 - num2;
				object obj14 = (nint)obj10 - num2;
				object obj15 = (nint)obj10 - num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X10_v1+FC]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X10_v1+FC]");
				object obj16 = (nint)0 + (nint)15;
				int num3 = (int)((nint)obj16 & 0x1FFFFFFF0L);
				object obj17 = (nint)obj10 - num3;
				object obj18 = (nint)obj10 - num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F20 (native memset)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X24_v1+98]");
				object obj19 = 0;
				object obj20 = (nint)obj2 - 12;
				object obj21 = (nint)obj2 - 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v96 @ X1_v4+10] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ X3+20]");
				object obj22 = 0;
				object obj23 = (nint)obj2 - 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ X8_v17+C0]");
				object obj24 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ X8_v18+110]");
				object obj25 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v118 @ X1_v5+10] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F20 (native memset)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ X3+20]");
				object obj26 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ X19_v3+C0]");
				object obj27 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ X8_v22+68]");
				object obj28 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ X9_v8+28]");
				global::Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType key;
				if (0 == 0)
				{
					key = (global::Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType)obj9;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-48]");
					key = (global::Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ X19_v3+C0]");
					obj27 = 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ X8_v22+88]");
				object obj29 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-28]");
				object obj30 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-40]");
				global::Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType value = (global::Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ X9_v10+28]");
				if (0 == 0)
				{
					value = (global::Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType)obj14;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ X19_v3+C0]");
					obj27 = 0;
				}
				*(KeyValuePair<global::Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType, global::Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>*)(nint)obj17 = new KeyValuePair<global::Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType, global::Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>(key, value);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X20_v3+28]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-8]");
				KeyValuePair<TKey, TValue> result = default(KeyValuePair<TKey, TValue>);
				if (num4 == 0)
				{
					return result;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EB0 (native __stack_chk_fail)");
				KeyValuePair<TKey, TValue> result2 = default(KeyValuePair<TKey, TValue>);
				return result2;
			}
			[Token(Token = "0x600076B")]
			[Address(RVA = "0x1135118", Offset = "0x1135118", Length = "0x43C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-60_v2;\n\t*([v24 @ X29_v1-28]) = value;\n\t*([v24 @ X29_v1-8]) = *([v28 @ SYSREG+28]);\n\tv38 = Il2CppClass<TKey>;\n\tv42 = *([v38 @ X8_v3 (Il2CppClass<TKey>)+FC]) + 0xF;\n\tv43 = v42 & 0x1FFFFFFF0;\n\tv173 = &v41 @ stack_-A0_v1 - v43;\n\tv443 = &v41 @ stack_-A0_v1 - v43;\n\tv52 = &v41 @ stack_-A0_v1 - v43;\n\tv54 = Il2CppClass<TValue>;\n\tv58 = *([v54 @ X8_v7 (Il2CppClass<TValue>)+FC]) + 0xF;\n\tv59 = v58 & 0x1FFFFFFF0;\n\tv60 = &v41 @ stack_-A0_v1 - v59;\n\t*([v24 @ X29_v1-38]) = v60;\n\tv64 = &v41 @ stack_-A0_v1 - v43;\n\tv69 = 0x1854F20(v64, 0, *([v38 @ X8_v3 (Il2CppClass<TKey>)+FC]), methodInfo, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81);\n\tv84 = Il2CppMethodInfo;\n\tv85 = &v25 @ stack_-60_v2 - 0xC;\n\tv86 = &v25 @ stack_-60_v2 - 0x20;\n\t*([v24 @ X29_v1-C]) = index;\n\t*([v24 @ X29_v1-20]) = v85;\n\t*([v24 @ X29_v1-18]) = v173;\n\t*([v24 @ X29_v1-2C]) = index;\n\t*([v84 @ X1_v4 (Il2CppMethodInfo)+10])(v90, *([v84 @ X1_v4 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.keys, v86, v173, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81);\n\tv94 = 0x1854F10(v64, v173, *([v38 @ X8_v3 (Il2CppClass<TKey>)+FC]), v86, v173, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81);\n\tv251 = System.Collections.Generic.Dictionary`2<TKey, System.Int32>::get_Comparer(this.dictionary);\n\tv255 = 0x1854F10(v443, v64, *([v38 @ X8_v3 (Il2CppClass<TKey>)+FC]), v86, v173, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81);\n\tv135 = &v25 @ stack_-60_v2 - 0x20;\n\tv147 = Il2CppMethodInfo;\n\t*([v24 @ X29_v1-20]) = v52;\n\t*([v147 @ X1_v8 (Il2CppMethodInfo)+10])(v154, *([v147 @ X1_v8 (Il2CppMethodInfo)]), Il2CppMethodInfo, *([v24 @ X29_v1-28]), v135, v52, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81);\n\tgoto L_006D;\n\tv311 = v306;\n\tv312 = 0xB348B0(v311, v306, v141, v135, v129, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81);\n\tv323 = Il2CppClass<Spine.Collections.OrderedDictionary`2>;\n\tv314 = v312;\n\tv317 = Il2CppRgctx<Spine.Collections.OrderedDictionary`2>;\nL_006D:\n\tv318 = Il2CppClass<TKey>;\n\t*([v24 @ X29_v1-40]) = v28;\n\tv320 = *([v318 @ X8_v26 (Il2CppClass<TKey>)+28]) & 0x80000000;\n\tv321 = v320 == 0;\n\tv322 = ~v321;\n\tif (v322) goto L_FFFFFFFF;\n\tv328 = *([v443 @ X22_v6]);\n\tv327 = *([v52 @ X28_v1]);\n\tgoto L_0078;\nL_0078:\n\tv329 = *([v251 @ X0_v12 (System.Collections.Generic.IEqualityComparer`1<TKey>)]);\n\tv372 = *([v329 @ X8_v28 (Il2CppClass<System.Collections.Generic.IEqualityComparer`1<TKey>>)+12E]);\n\tv331 = *([v329 @ X8_v28 (Il2CppClass<System.Collections.Generic.IEqualityComparer`1<TKey>>)+12E]) == 0;\n\tif (v331) goto L_0098;\n\tv371 = *([v329 @ X8_v28 (Il2CppClass<System.Collections.Generic.IEqualityComparer`1<TKey>>)+B0]) + 8;\nL_0083:\n\tv377 = *([v371 @ X10_v8-8]) == Il2CppClass<System.Collections.Generic.IEqualityComparer`1<TKey>>;\n\tif (v377) goto L_009B;\n\tv357 = v372 - 1;\n\tv371 = v371 + 0x10;\n\tv337 = v372 != 1;\n\tif (v337) goto L_0083;\nL_0098:\n\tv388 = 0xB349B4(v251, Il2CppClass<System.Collections.Generic.IEqualityComparer`1<TKey>>, 0, v135, v52, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81);\n\tgoto L_009E;\nL_009B:\n\tv384 = *([v371 @ X10_v8]) << 4;\n\tv385 = v329 + v384;\n\tv388 = v385 + 0x138;\nL_009E:\n\t*([v24 @ X29_v1-20]) = v328;\n\t*([v24 @ X29_v1-18]) = v327;\n\tv390 = *([v388 @ X0_v18+8]);\n\tv391 = &v25 @ stack_-60_v2 - 0x20;\n\tv392 = &v25 @ stack_-60_v2 - 0xC;\n\t*([v390 @ X1_v11+10])(v396, *([v390 @ X1_v11+8]), *([v388 @ X0_v18+8]), v251, v391, v392, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81);\n\tv137 = &v25 @ stack_-60_v2 - 0x20;\n\tv149 = Il2CppMethodInfo;\n\t*([v24 @ X29_v1-20]) = v173;\n\t*([v149 @ X1_v12 (Il2CppMethodInfo)+10])(v156, *([v149 @ X1_v12 (Il2CppMethodInfo)]), Il2CppMethodInfo, *([v24 @ X29_v1-28]), v137, v173, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81);\n\tv402 = *([v24 @ X29_v1-C]) == 0;\n\tif (v402) goto L_00D2;\n\tv404 = Il2CppMethodInfo;\n\tgoto L_00C6;\n\tv419 = *([v44 @ X24_v1]);\nL_00C6:\n\tv421 = &v25 @ stack_-60_v2 - 0xC;\n\t*([v24 @ X29_v1-C]) = *([v24 @ X29_v1-2C]);\n\t*([v24 @ X29_v1-20]) = v173;\n\t*([v24 @ X29_v1-18]) = v421;\n\tv423 = &v25 @ stack_-60_v2 - 0x20;\n\tv424 = &v25 @ stack_-60_v2 - 0xC;\n\t*([v404 @ X1_v21 (Il2CppMethodInfo)+10])(v426, *([v404 @ X1_v21 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.dictionary, v423, v424, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81);\n\tv199 = *([v24 @ X29_v1-40]);\n\tgoto L_00FF;\nL_00D2:\n\tv412 = Il2CppMethodInfo;\n\tgoto L_00DB;\n\tv428 = *([v44 @ X24_v1]);\nL_00DB:\n\tv175 = &v25 @ stack_-60_v2 - 0xC;\n\t*([v24 @ X29_v1-C]) = *([v24 @ X29_v1-2C]);\n\t*([v24 @ X29_v1-20]) = v173;\n\t*([v24 @ X29_v1-18]) = v175;\n\tv136 = &v25 @ stack_-60_v2 - 0x20;\n\tv130 = &v25 @ stack_-60_v2 - 0xC;\n\t*([v412 @ X1_v18 (Il2CppMethodInfo)+10])(v431, *([v412 @ X1_v18 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.dictionary, v136, v130, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81);\n\tv155 = 0x1854F10(v443, v64, *([v38 @ X8_v3 (Il2CppClass<TKey>)+FC]), v136, v130, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81);\n\tv199 = *([v24 @ X29_v1-40]);\n\tv440 = Il2CppMethodInfo;\n\tgoto L_00F7;\n\tv478 = *([v48 @ X22_v1]);\nL_00F7:\n\t*([v24 @ X29_v1-20]) = v443;\n\tv436 = &v25 @ stack_-60_v2 - 0x20;\n\tv434 = &v25 @ stack_-60_v2 - 0xC;\n\t*([v440 @ X1_v20 (Il2CppMethodInfo)+10])(v442, *([v440 @ X1_v20 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.dictionary, v436, v434, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81);\nL_00FF:\n\tv139 = &v25 @ stack_-60_v2 - 0x20;\n\tv151 = Il2CppMethodInfo;\n\t*([v24 @ X29_v1-20]) = v173;\n\t*([v151 @ X1_v14 (Il2CppMethodInfo)+10])(v158, *([v151 @ X1_v14 (Il2CppMethodInfo)]), Il2CppMethodInfo, *([v24 @ X29_v1-28]), v139, v173, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81);\n\tv456 = Il2CppMethodInfo;\n\tgoto L_0115;\n\tv468 = *([v44 @ X24_v1]);\nL_0115:\n\tv469 = &v25 @ stack_-60_v2 - 0xC;\n\t*([v24 @ X29_v1-C]) = *([v24 @ X29_v1-2C]);\n\t*([v24 @ X29_v1-20]) = v469;\n\t*([v24 @ X29_v1-18]) = v173;\n\tv471 = &v25 @ stack_-60_v2 - 0x20;\n\t*([v456 @ X1_v15 (Il2CppMethodInfo)+10])(v474, *([v456 @ X1_v15 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.keys, v471, v173, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81);\n\tv138 = &v25 @ stack_-60_v2 - 0x20;\n\tv150 = Il2CppMethodInfo;\n\t*([v24 @ X29_v1-20]) = *([v24 @ X29_v1-38]);\n\t*([v150 @ X1_v16 (Il2CppMethodInfo)+10])(v157, *([v150 @ X1_v16 (Il2CppMethodInfo)]), Il2CppMethodInfo, *([v24 @ X29_v1-28]), v138, *([v24 @ X29_v1-38]), v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81);\n\tv228 = Il2CppMethodInfo;\n\tgoto L_0137;\n\tv486 = *([v187 @ X21_v5]);\nL_0137:\n\tv487 = &v25 @ stack_-60_v2 - 0xC;\n\t*([v24 @ X29_v1-C]) = *([v24 @ X29_v1-2C]);\n\t*([v24 @ X29_v1-20]) = v487;\n\t*([v24 @ X29_v1-18]) = *([v24 @ X29_v1-38]);\n\tv224 = &v25 @ stack_-60_v2 - 0x20;\n\t*([v228 @ X1_v17 (Il2CppMethodInfo)+10])(v230, *([v228 @ X1_v17 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.values, v224, *([v24 @ X29_v1-38]), v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81);\n\tv204 = *([v199 @ X25_v6+28]) != *([v24 @ X29_v1-8]);\n\tif (v204) goto L_015D;\n\treturn;\n\tv200 = new System.NullReferenceException();\nL_015D:\n\tv246 = 0x1854EB0(v229, v227, v225, v223, v221, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81);\n\treturn;\n// 214 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0036: Expected O, but got I
				//IL_0049: Expected I4, but got I8
				//IL_0057: Expected O, but got I
				//IL_0065: Expected O, but got I
				//IL_0073: Expected O, but got I
				//IL_008f: Expected O, but got I
				//IL_00a2: Expected I4, but got I8
				//IL_00b0: Expected O, but got I
				//IL_00c3: Expected O, but got I
				//IL_00e7: Expected O, but got I
				//IL_00f6: Expected O, but got I
				//IL_014b: Expected O, but got I
				//IL_02d1: Expected I4, but got I8
				//IL_0301: Expected I, but got O
				//IL_0311: Expected O, but got I
				//IL_0372: Expected O, but got I
				//IL_0381: Expected O, but got I
				//IL_0390: Expected O, but got I
				//IL_03a9: Expected O, but got I
				//IL_01aa: Expected O, but got I
				//IL_0212: Expected I4, but got O
				//IL_0220: Expected O, but got I
				//IL_022f: Expected O, but got I
				//IL_0435: Expected O, but got I
				//IL_045b: Expected O, but got I
				//IL_046a: Expected O, but got I
				//IL_01be: Expected O, but got I
				//IL_01cd: Expected O, but got I
				//IL_027f: Expected O, but got I
				//IL_03d2: Expected O, but got I
				//IL_03f8: Expected O, but got I
				//IL_0407: Expected O, but got I
				//IL_0421: Expected O, but got I
				//IL_0497: Expected O, but got I
				//IL_04a6: Expected O, but got I
				//IL_05aa: Expected O, but got I
				//IL_04c4: Expected O, but got I
				//IL_04ea: Expected O, but got I
				//IL_0503: Expected O, but got I
				//IL_0534: Expected O, but got I
				//IL_0562: Expected O, but got I
				object obj2 = default(object);
				object obj = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ SYSREG+28]");
				_ = 0;
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X8_v3 (Il2CppClass<TKey>)+FC]");
				object obj3 = (nint)0 + (nint)15;
				int num2 = (int)((nint)obj3 & 0x1FFFFFFF0L);
				object obj5 = default(object);
				object obj4 = (nint)obj5 - num2;
				object obj6 = (nint)obj5 - num2;
				object obj7 = (nint)obj5 - num2;
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X8_v7 (Il2CppClass<TValue>)+FC]");
				object obj8 = (nint)0 + (nint)15;
				int num4 = (int)((nint)obj8 & 0x1FFFFFFF0L);
				object obj9 = (nint)obj5 - num4;
				object obj10 = (nint)obj5 - num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F20 (native memset)");
				nint num5 = 0;
				object obj11 = (nint)obj2 - 12;
				object obj12 = (nint)obj2 - 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v84 @ X1_v4 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
				IEqualityComparer<TKey> comparer = dictionary.Comparer;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
				object obj13 = (nint)obj2 - 32;
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v147 @ X1_v8 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ X8_v26 (Il2CppClass<TKey>)+28]");
				if (0 == 0)
				{
					object obj14 = obj6;
					object obj15 = obj7;
				}
				else
				{
					object obj15 = obj7;
					object obj14 = obj6;
				}
				nint num8 = (nint)comparer;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ X8_v28 (Il2CppClass<System.Collections.Generic.IEqualityComparer`1<TKey>>)+12E]");
				object obj16 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ X8_v28 (Il2CppClass<System.Collections.Generic.IEqualityComparer`1<TKey>>)+12E]");
				if ((nint)0 == 0)
				{
					goto IL_01f5;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ X8_v28 (Il2CppClass<System.Collections.Generic.IEqualityComparer`1<TKey>>)+B0]");
				object obj17 = (nint)0 + (nint)8;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v371 @ X10_v8-8]");
					if ((nint)0 == 0)
					{
						break;
					}
					object obj18 = (nint)obj16 - 1;
					obj17 = (nint)obj17 + 16;
					bool flag = (nint)obj16 != 1;
					obj16 = obj18;
					if (flag)
					{
						continue;
					}
					goto IL_01f5;
				}
				int num9 = obj17 << 4;
				object obj19 = num8 + num9;
				object obj20 = (nint)obj19 + 312;
				goto IL_0358;
				IL_0358:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ X0_v18+8]");
				object obj21 = 0;
				object obj22 = (nint)obj2 - 32;
				object obj23 = (nint)obj2 - 12;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v390 @ X1_v11+10] (should have been resolved before IL gen)");
				object obj24 = (nint)obj2 - 32;
				nint num10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v149 @ X1_v12 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-C]");
				if ((nint)0 != 0)
				{
					nint num11 = 0;
					object obj25 = (nint)obj2 - 12;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-2C]");
					_ = 0;
					object obj26 = (nint)obj2 - 32;
					object obj27 = (nint)obj2 - 12;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v404 @ X1_v21 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-40]");
					object obj28 = 0;
				}
				else
				{
					nint num12 = 0;
					object obj29 = (nint)obj2 - 12;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-2C]");
					_ = 0;
					object obj30 = (nint)obj2 - 32;
					object obj31 = (nint)obj2 - 12;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v412 @ X1_v18 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-40]");
					object obj28 = 0;
					nint num13 = 0;
					object obj32 = (nint)obj2 - 32;
					object obj33 = (nint)obj2 - 12;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v440 @ X1_v20 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				}
				object obj34 = (nint)obj2 - 32;
				nint num14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v151 @ X1_v14 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				nint num15 = 0;
				object obj35 = (nint)obj2 - 12;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-2C]");
				_ = 0;
				object obj36 = (nint)obj2 - 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v456 @ X1_v15 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				object obj37 = (nint)obj2 - 32;
				nint num16 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-38]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v150 @ X1_v16 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				nint num17 = 0;
				object obj38 = (nint)obj2 - 12;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-2C]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-38]");
				_ = 0;
				object obj39 = (nint)obj2 - 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v228 @ X1_v17 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ X25_v6+28]");
				nint num18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-8]");
				if (num18 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EB0 (native __stack_chk_fail)");
				}
				return;
				IL_01f5:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @B349B4");
				goto IL_0358;
			}
		}

		[Token(Token = "0x170001CA")]
		ICollection<TKey> IDictionary<TKey, TValue>.Keys
		{
			[Token(Token = "0x600076C")]
			[Address(RVA = "0x1135554", Offset = "0x1135554", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = Il2CppMethodInfo;\n\tv4 = *([v3 @ X1_v1 (Il2CppMethodInfo)]);\n\t// 4 IndirectJump v4 @ X2_v1, this @ X0 (Spine.Collections.OrderedDictionary`2<TKey, TValue>), this @ X0 (Spine.Collections.OrderedDictionary`2<TKey, TValue>), methodof(Spine.Collections.OrderedDictionary`2<TKey, TValue>::get_Keys), v4 @ X2_v1, v6 @ X3, v7 @ X4, v8 @ X5, v9 @ X6, v10 @ X7, v11 @ V0, v12 @ V1, v13 @ V2, v14 @ V3, v15 @ V4, v16 @ V5, v17 @ V6, v18 @ V7\n\treturn X0;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000e: Expected O, but got I
				nint num = 0;
				object obj = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ X2_v1 (should have been resolved before IL gen)");
				return null;
			}
		}

		[Token(Token = "0x170001CB")]
		ICollection<TValue> IDictionary<TKey, TValue>.Values
		{
			[Token(Token = "0x600076D")]
			[Address(RVA = "0x1135568", Offset = "0x1135568", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = Il2CppMethodInfo;\n\tv4 = *([v3 @ X1_v1 (Il2CppMethodInfo)]);\n\t// 4 IndirectJump v4 @ X2_v1, this @ X0 (Spine.Collections.OrderedDictionary`2<TKey, TValue>), this @ X0 (Spine.Collections.OrderedDictionary`2<TKey, TValue>), methodof(Spine.Collections.OrderedDictionary`2<TKey, TValue>::get_Values), v4 @ X2_v1, v6 @ X3, v7 @ X4, v8 @ X5, v9 @ X6, v10 @ X7, v11 @ V0, v12 @ V1, v13 @ V2, v14 @ V3, v15 @ V4, v16 @ V5, v17 @ V6, v18 @ V7\n\treturn X0;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000e: Expected O, but got I
				nint num = 0;
				object obj = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ X2_v1 (should have been resolved before IL gen)");
				return null;
			}
		}

		[Token(Token = "0x170001CC")]
		bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly
		{
			[Token(Token = "0x6000771")]
			[Address(RVA = "0x1135CC0", Offset = "0x1135CC0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x6000752")]
		[Address(RVA = "0x113347C", Offset = "0x113347C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = Il2CppMethodInfo;\n\tv6 = *([v5 @ X3_v1 (Il2CppMethodInfo)]);\n\t// 6 IndirectJump v6 @ X4_v1, this @ X0 (Spine.Collections.OrderedDictionary`2<TKey, TValue>), this @ X0 (Spine.Collections.OrderedDictionary`2<TKey, TValue>), 0, 0, methodof(Spine.Collections.OrderedDictionary`2<TKey, TValue>::.ctor), v6 @ X4_v1, v8 @ X5, v9 @ X6, v10 @ X7, v11 @ V0, v12 @ V1, v13 @ V2, v14 @ V3, v15 @ V4, v16 @ V5, v17 @ V6, v18 @ V7\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public OrderedDictionary()
		{
			//IL_000e: Expected O, but got I
			nint num = 0;
			object obj = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v6 @ X4_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000753")]
		[Address(RVA = "0x1133498", Offset = "0x1133498", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = Il2CppMethodInfo;\n\tv5 = *([v4 @ X3_v1 (Il2CppMethodInfo)]);\n\t// 5 IndirectJump v5 @ X4_v1, this @ X0 (Spine.Collections.OrderedDictionary`2<TKey, TValue>), this @ X0 (Spine.Collections.OrderedDictionary`2<TKey, TValue>), capacity @ X1 (System.Int32), 0, methodof(Spine.Collections.OrderedDictionary`2<TKey, TValue>::.ctor), v5 @ X4_v1, v8 @ X5, v9 @ X6, v10 @ X7, v11 @ V0, v12 @ V1, v13 @ V2, v14 @ V3, v15 @ V4, v16 @ V5, v17 @ V6, v18 @ V7\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public OrderedDictionary(int capacity)
		{
			//IL_000e: Expected O, but got I
			nint num = 0;
			object obj = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v5 @ X4_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000754")]
		[Address(RVA = "0x11334B0", Offset = "0x11334B0", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = Il2CppMethodInfo;\n\tv8 = *([v7 @ X3_v1 (Il2CppMethodInfo)]);\n\t// 7 IndirectJump v8 @ X4_v1, this @ X0 (Spine.Collections.OrderedDictionary`2<TKey, TValue>), this @ X0 (Spine.Collections.OrderedDictionary`2<TKey, TValue>), 0, comparer @ X1 (System.Collections.Generic.IEqualityComparer`1<TKey>), methodof(Spine.Collections.OrderedDictionary`2<TKey, TValue>::.ctor), v8 @ X4_v1, v10 @ X5, v11 @ X6, v12 @ X7, v13 @ V0, v14 @ V1, v15 @ V2, v16 @ V3, v17 @ V4, v18 @ V5, v19 @ V6, v20 @ V7\n\treturn;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public OrderedDictionary(IEqualityComparer<TKey> comparer)
		{
			//IL_000e: Expected O, but got I
			nint num = 0;
			object obj = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v8 @ X4_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000755")]
		[Address(RVA = "0x11334D0", Offset = "0x11334D0", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tv21 = comparer == 0;\n\tv22 = ~v21;\n\tif (v22) goto L_001D;\n\tv27 = System.Collections.Generic.EqualityComparer`1<TKey>::get_Default();\nL_001D:\n\tgoto L_001F;\n\tv52 = 0xB348B0(v47, v14, comparer, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_001F:\n\tv54 = new Il2CppClass<System.Collections.Generic.Dictionary`2<TKey, System.Int32>>();\n\tv62 = System.Collections.Generic.Dictionary`2<TKey, System.Int32>::.ctor(v54, capacity, v44);\n\tthis.dictionary = v54;\n\tgoto L_0034;\n\tv72 = System.Collections.Generic.Dictionary`2<TKey, System.Int32>::.ctor(v66, v56, v57, v60);\nL_0034:\n\tv74 = new Il2CppClass<System.Collections.Generic.List`1<TKey>>();\n\tv81 = System.Collections.Generic.List`1<TKey>::.ctor(v74, capacity);\n\tthis.keys = v74;\n\tgoto L_0046;\n\tv110 = System.Collections.Generic.Dictionary`2<TKey, System.Int32>::.ctor(v84, v76, v79, v60);\nL_0046:\n\tv112 = new Il2CppClass<System.Collections.Generic.List`1<TValue>>();\n\tv96 = System.Collections.Generic.List`1<TValue>::.ctor(v112, capacity);\n\tthis.values = v112;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public OrderedDictionary(int capacity, IEqualityComparer<TKey> comparer)
		{
			bool flag = comparer == null;
			bool flag2 = !flag;
			IEqualityComparer<TKey> comparer2 = comparer;
			if (!flag2)
			{
				EqualityComparer<TKey> equalityComparer = EqualityComparer<TKey>.Default;
				comparer2 = equalityComparer;
			}
			Dictionary<TKey, int> dictionary = new Dictionary<TKey, int>(capacity, comparer2);
			this.dictionary = dictionary;
			List<TKey> list = new List<TKey>(capacity);
			keys = list;
			List<TValue> list2 = new List<TValue>(capacity);
			values = list2;
		}

		[Token(Token = "0x6000757")]
		[Address(RVA = "0x1133608", Offset = "0x1133608", Length = "0x220")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-60_v2;\n\t*([v24 @ X29_v1-40]) = v27;\n\t*([v24 @ X29_v1-8]) = *([v27 @ SYSREG+28]);\n\t*([v24 @ X29_v1-30]) = value;\n\t*([v24 @ X29_v1-28]) = v105;\n\t*([v24 @ X29_v1-38]) = value;\n\tv38 = Il2CppClass<TKey>;\n\tv39 = Il2CppClass<TValue>;\n\tv44 = *([v38 @ X9_v1 (Il2CppClass<TKey>)+FC]) + 0xF;\n\tv45 = v44 & 0x1FFFFFFF0;\n\tv215 = &v43 @ stack_-A0_v1 - v45;\n\tv144 = &v43 @ stack_-A0_v1 - v45;\n\tv52 = *([v39 @ X8_v4 (Il2CppClass<TValue>)+FC]) + 0xF;\n\tv55 = v52 & 0x1FFFFFFF0;\n\tv201 = &v43 @ stack_-A0_v1 - v55;\n\tv65 = *([v38 @ X9_v1 (Il2CppClass<TKey>)+28]) < 0;\n\tv68 = *([v38 @ X9_v1 (Il2CppClass<TKey>)+28]) ^ *([v38 @ X9_v1 (Il2CppClass<TKey>)+28]);\n\tv69 = *([v38 @ X9_v1 (Il2CppClass<TKey>)+28]) & v68;\n\tv70 = v69 < 0;\n\tv71 = &v25 @ stack_-60_v2 - 0x28;\n\tv72 = v65 == v70;\n\tv73 = ~v72;\n\tv74 = ~v73;\n\tif (v74) goto L_FFFFFFFF;\n\tgoto L_0042;\nL_0042:\n\tv78 = 0x1854F10(v215, v77, *([v38 @ X9_v1 (Il2CppClass<TKey>)+FC]), methodInfo, v79, v80, v81, v82, v83, v84, v85, v86, v87, v88, v89, v90);\n\tv96 = System.Collections.Generic.List`1<TValue>::get_Count(this.values);\n\tv165 = Il2CppMethodInfo;\n\tgoto L_0057;\n\tv214 = *([v46 @ X27_v1]);\nL_0057:\n\tv216 = &v25 @ stack_-60_v2 - 0xC;\n\t*([v24 @ X29_v1-C]) = v96;\n\t*([v24 @ X29_v1-20]) = v215;\n\t*([v24 @ X29_v1-18]) = v216;\n\tv102 = &v25 @ stack_-60_v2 - 0x20;\n\tv99 = &v25 @ stack_-60_v2 - 0xC;\n\t*([v165 @ X1_v5 (Il2CppMethodInfo)+10])(v219, *([v165 @ X1_v5 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.dictionary, v102, v99, v80, v81, v82, v83, v84, v85, v86, v87, v88, v89, v90);\n\tv222 = Il2CppClass<TKey>;\n\tv129 = *([v222 @ X8_v18 (Il2CppClass<TKey>)+28]) < 0;\n\tv120 = *([v222 @ X8_v18 (Il2CppClass<TKey>)+28]) ^ *([v222 @ X8_v18 (Il2CppClass<TKey>)+28]);\n\tv117 = *([v222 @ X8_v18 (Il2CppClass<TKey>)+28]) & v120;\n\tv114 = v117 < 0;\n\tv159 = &v25 @ stack_-60_v2 - 0x28;\n\tv225 = v129 == v114;\n\tv111 = ~v225;\n\tv108 = ~v111;\n\tif (v108) goto L_007A;\n\tgoto L_007A;\nL_007A:\n\tv141 = 0x1854F10(v144, v159, *([v38 @ X9_v1 (Il2CppClass<TKey>)+FC]), v102, v99, v80, v81, v82, v83, v84, v85, v86, v87, v88, v89, v90);\n\tv273 = Il2CppMethodInfo;\n\tgoto L_0087;\n\tv279 = *([v50 @ X24_v1]);\nL_0087:\n\t*([v24 @ X29_v1-20]) = v144;\n\tv103 = &v25 @ stack_-60_v2 - 0x20;\n\t*([v273 @ X1_v7 (Il2CppMethodInfo)+10])(v282, *([v273 @ X1_v7 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.keys, v103, v144, v80, v81, v82, v83, v84, v85, v86, v87, v88, v89, v90);\n\tv285 = Il2CppClass<TValue>;\n\tv130 = *([v285 @ X8_v25 (Il2CppClass<TValue>)+28]) < 0;\n\tv121 = *([v285 @ X8_v25 (Il2CppClass<TValue>)+28]) ^ *([v285 @ X8_v25 (Il2CppClass<TValue>)+28]);\n\tv118 = *([v285 @ X8_v25 (Il2CppClass<TValue>)+28]) & v121;\n\tv115 = v118 < 0;\n\tv160 = &v25 @ stack_-60_v2 - 0x30;\n\tv288 = v130 == v115;\n\tv112 = ~v288;\n\tv109 = ~v112;\n\tif (v109) goto L_FFFFFFFF;\n\tgoto L_00A7;\nL_00A7:\n\tv142 = 0x1854F10(v201, v106, *([v39 @ X8_v4 (Il2CppClass<TValue>)+FC]), v103, v144, v80, v81, v82, v83, v84, v85, v86, v87, v88, v89, v90);\n\tv176 = Il2CppMethodInfo;\n\tgoto L_00B4;\n\tv297 = *([v56 @ X20_v1]);\nL_00B4:\n\t*([v24 @ X29_v1-20]) = v201;\n\tv209 = *([v24 @ X29_v1-40]);\n\tv174 = &v25 @ stack_-60_v2 - 0x20;\n\t*([v176 @ X1_v9 (Il2CppMethodInfo)+10])(v199, *([v176 @ X1_v9 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.values, v174, v201, v80, v81, v82, v83, v84, v85, v86, v87, v88, v89, v90);\n\tv300 = this.version + 1;\n\tthis.version = v300;\n\tv179 = *([v209 @ X21_v6+28]) != *([v24 @ X29_v1-8]);\n\tif (v179) goto L_00DB;\n\treturn;\n\tv161 = new System.NullReferenceException();\nL_00DB:\n\tv213 = 0x1854EB0(v198, v175, v196, v173, v171, v80, v81, v82, v83, v84, v85, v86, v87, v88, v89, v90);\n\treturn;\n// 139 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Add(TKey key, TValue value)
		{
			//IL_004b: Expected O, but got I
			//IL_005e: Expected I4, but got I8
			//IL_006c: Expected O, but got I
			//IL_007a: Expected O, but got I
			//IL_0090: Expected O, but got I
			//IL_00a3: Expected I4, but got I8
			//IL_00b1: Expected O, but got I
			//IL_0118: Expected O, but got I
			//IL_01ea: Expected O, but got I
			//IL_0208: Expected O, but got I
			//IL_0217: Expected O, but got I
			//IL_028e: Expected O, but got I
			//IL_02e3: Expected O, but got I
			//IL_035a: Expected O, but got I
			//IL_01a3: Expected O, but got I
			//IL_03b0: Expected O, but got I
			//IL_03bf: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ SYSREG+28]");
			_ = 0;
			nint num = 0;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X9_v1 (Il2CppClass<TKey>)+FC]");
			object obj3 = (nint)0 + (nint)15;
			int num3 = (int)((nint)obj3 & 0x1FFFFFFF0L);
			object obj5 = default(object);
			object obj4 = (nint)obj5 - num3;
			object obj6 = (nint)obj5 - num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ X8_v4 (Il2CppClass<TValue>)+FC]");
			object obj7 = (nint)0 + (nint)15;
			int num4 = (int)((nint)obj7 & 0x1FFFFFFF0L);
			object obj8 = (nint)obj5 - num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X9_v1 (Il2CppClass<TKey>)+28]");
			bool flag = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X9_v1 (Il2CppClass<TKey>)+28]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X9_v1 (Il2CppClass<TKey>)+28]");
			int num6 = (int)(num5 ^ 0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X9_v1 (Il2CppClass<TKey>)+28]");
			int num7 = (int)((nint)0 & (nint)num6);
			bool flag2 = num7 < 0;
			TKey val = (TKey)((nint)obj2 - 40);
			if (flag != flag2)
			{
				TKey val3 = default(TKey);
				TKey val2 = val3;
			}
			else
			{
				TKey val2 = val;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
			int count = values.Count;
			nint num8 = 0;
			object obj9 = (nint)obj2 - 12;
			object obj10 = (nint)obj2 - 32;
			object obj11 = (nint)obj2 - 12;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v165 @ X1_v5 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ X8_v18 (Il2CppClass<TKey>)+28]");
			bool flag3 = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ X8_v18 (Il2CppClass<TKey>)+28]");
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ X8_v18 (Il2CppClass<TKey>)+28]");
			int num11 = (int)(num10 ^ 0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ X8_v18 (Il2CppClass<TKey>)+28]");
			int num12 = (int)((nint)0 & (nint)num11);
			bool flag4 = num12 < 0;
			TKey val4 = (TKey)((nint)obj2 - 40);
			if (flag3 != flag4)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
			nint num13 = 0;
			object obj12 = (nint)obj2 - 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v273 @ X1_v7 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			nint num14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ X8_v25 (Il2CppClass<TValue>)+28]");
			bool flag5 = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ X8_v25 (Il2CppClass<TValue>)+28]");
			nint num15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ X8_v25 (Il2CppClass<TValue>)+28]");
			int num16 = (int)(num15 ^ 0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ X8_v25 (Il2CppClass<TValue>)+28]");
			int num17 = (int)((nint)0 & (nint)num16);
			bool flag6 = num17 < 0;
			object obj13 = (nint)obj2 - 48;
			if (flag5 != flag6)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-38]");
				object obj14 = 0;
			}
			else
			{
				object obj14 = obj13;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
			nint num18 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-40]");
			object obj15 = 0;
			object obj16 = (nint)obj2 - 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v176 @ X1_v9 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			int num19 = version + 1;
			version = num19;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ X21_v6+28]");
			nint num20 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-8]");
			if (num20 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EB0 (native __stack_chk_fail)");
			}
		}

		[Token(Token = "0x6000758")]
		[Address(RVA = "0x1133828", Offset = "0x1133828", Length = "0x424")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = &v1 @ X29;\n\t*([v1 @ X29-8]) = *([v26 @ SYSREG+28]);\n\t*([v1 @ X29-30]) = value;\n\t*([v1 @ X29-28]) = key;\n\t*([v1 @ X29-40]) = key;\n\tv38 = Il2CppClass<TKey>;\n\tv39 = Il2CppClass<TValue>;\n\tv44 = *([v38 @ X8_v3 (Il2CppClass<TKey>)+FC]) + 0xF;\n\tv45 = v44 & 0x1FFFFFFF0;\n\tv225 = &v43 @ stack_-C0_v1 - v45;\n\tv50 = &v43 @ stack_-C0_v1 - v45;\n\tv54 = &v43 @ stack_-C0_v1 - v45;\n\t*([v1 @ X29-58]) = *([v39 @ X9_v1 (Il2CppClass<TValue>)+FC]);\n\t*([v1 @ X29-50]) = value;\n\tv56 = *([v39 @ X9_v1 (Il2CppClass<TValue>)+FC]) + 0xF;\n\tv59 = v56 & 0x1FFFFFFF0;\n\tv60 = &v43 @ stack_-C0_v1 - v59;\n\t*([v1 @ X29-48]) = v60;\n\tv64 = &v43 @ stack_-C0_v1 - v45;\n\tv69 = 0x1854F20(v64, 0, *([v38 @ X8_v3 (Il2CppClass<TKey>)+FC]), value, methodInfo, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80);\n\t*([v1 @ X29-34]) = index;\n\tv81 = index & 0x80000000;\n\tv82 = v81 == 0;\n\tv83 = ~v82;\n\tif (v83) goto L_0166;\n\tv116 = System.Collections.Generic.List`1<TValue>::get_Count(this.values);\n\tv88 = v116 < *([v1 @ X29-34]);\n\tif (v88) goto L_0166;\n\tv270 = Il2CppClass<TKey>;\n\tv177 = *([v270 @ X8_v39 (Il2CppClass<TKey>)+28]) < 0;\n\tv162 = *([v270 @ X8_v39 (Il2CppClass<TKey>)+28]) ^ *([v270 @ X8_v39 (Il2CppClass<TKey>)+28]);\n\tv157 = *([v270 @ X8_v39 (Il2CppClass<TKey>)+28]) & v162;\n\tv152 = v157 < 0;\n\tv255 = &v1 @ X29 - 0x28;\n\tv273 = v177 == v152;\n\tv147 = ~v273;\n\tv142 = ~v147;\n\tif (v142) goto L_FFFFFFFF;\n\tgoto L_006A;\nL_006A:\n\tv208 = 0x1854F10(v225, v200, *([v38 @ X8_v3 (Il2CppClass<TKey>)+FC]), value, methodInfo, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80);\n\t*([v1 @ X29-60]) = v26;\n\tv205 = Il2CppMethodInfo;\n\tgoto L_007A;\n\tv336 = *([v46 @ X25_v1 (Il2CppMethodInfo)]);\nL_007A:\n\tv262 = &v1 @ X29 - 0xC;\n\t*([v1 @ X29-20]) = v225;\n\t*([v1 @ X29-18]) = v262;\n\tv138 = &v1 @ X29 - 0x20;\n\t*([v1 @ X29-C]) = *([v1 @ X29-34]);\n\tv131 = &v1 @ X29 - 0xC;\n\t*([v205 @ X1_v19 (Il2CppMethodInfo)+10])(v338, *([v205 @ X1_v19 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.dictionary, v138, v131, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80);\n\tv411 = this.keys;\n\tv242 = *([v1 @ X29-34]);\nL_008B:\n\tv209 = System.Collections.Generic.List`1<TKey>::get_Count(v411);\n\tv171 = v242 == v209;\n\tif (v171) goto L_00E7;\n\tv137 = &v1 @ X29 - 0x20;\n\tv464 = Il2CppMethodInfo;\n\t*([v1 @ X29-C]) = v242;\n\t*([v1 @ X29-20]) = v262;\n\t*([v1 @ X29-18]) = v225;\n\t*([v464 @ X1_v22 (Il2CppMethodInfo)+10])(v466, *([v464 @ X1_v22 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.keys, v137, v225, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80);\n\tv470 = 0x1854F10(v64, v225, *([v38 @ X8_v3 (Il2CppClass<TKey>)+FC]), v137, v225, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80);\n\tv480 = 0x1854F10(v50, v64, *([v38 @ X8_v3 (Il2CppClass<TKey>)+FC]), v137, v225, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80);\n\tv210 = 0x1854F10(v54, v64, *([v38 @ X8_v3 (Il2CppClass<TKey>)+FC]), v137, v225, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80);\n\tgoto L_00BE;\n\tv508 = *([v54 @ X23_v1]);\nL_00BE:\n\tv510 = Il2CppMethodInfo;\n\tv511 = &v1 @ X29 - 0x20;\n\tv512 = &v1 @ X29 - 0xC;\n\t*([v1 @ X29-20]) = v54;\n\t*([v510 @ X1_v26 (Il2CppMethodInfo)+10])(v516, *([v510 @ X1_v26 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.dictionary, v511, v512, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80);\n\tgoto L_00D0;\n\tv524 = *([v50 @ X28_v1]);\nL_00D0:\n\tv199 = Il2CppMethodInfo;\n\tv134 = &v1 @ X29 - 0x20;\n\tv127 = &v1 @ X29 - 0xC;\n\tv233 = *([v1 @ X29-C]) + 1;\n\t*([v1 @ X29-C]) = v233;\n\t*([v1 @ X29-20]) = v50;\n\t*([v1 @ X29-18]) = v262;\n\t*([v199 @ X1_v27 (Il2CppMethodInfo)+10])(v528, *([v199 @ X1_v27 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.dictionary, v134, v127, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80);\n\tv411 = this.keys;\n\tv242 = v242 + 1;\n\tv529 = this.keys == 0;\n\tv218 = ~v529;\n\tif (v218) goto L_008B;\n\tthrow System.NullReferenceException;\nL_00E7:\n\tv294 = Il2CppClass<TKey>;\n\tv178 = *([v294 @ X8_v15 (Il2CppClass<TKey>)+28]) < 0;\n\tv163 = *([v294 @ X8_v15 (Il2CppClass<TKey>)+28]) ^ *([v294 @ X8_v15 (Il2CppClass<TKey>)+28]);\n\tv158 = *([v294 @ X8_v15 (Il2CppClass<TKey>)+28]) & v163;\n\tv153 = v158 < 0;\n\tv258 = &v1 @ X29 - 0x28;\n\tv297 = v178 == v153;\n\tv148 = ~v297;\n\tv144 = ~v148;\n\tif (v144) goto L_FFFFFFFF;\n\tgoto L_00FB;\nL_00FB:\n\tv211 = 0x1854F10(v225, v203, *([v38 @ X8_v3 (Il2CppClass<TKey>)+FC]), v138, v131, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80);\n\tv264 = *([v1 @ X29-60]);\n\tv325 = Il2CppMethodInfo;\n\tgoto L_010B;\n\tv339 = *([v226 @ X25_v3 (Il2CppMethodInfo)]);\nL_010B:\n\tv139 = &v1 @ X29 - 0x20;\n\t*([v1 @ X29-C]) = *([v1 @ X29-34]);\n\tv342 = &v1 @ X29 - 0xC;\n\t*([v1 @ X29-20]) = v342;\n\t*([v1 @ X29-18]) = v225;\n\t*([v325 @ X1_v9 (Il2CppMethodInfo)+10])(v344, *([v325 @ X1_v9 (Il2CppMethodInfo)]), Il2CppMethodInfo, v249, v139, v225, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80);\n\tv347 = Il2CppClass<TValue>;\n\tv179 = *([v347 @ X8_v24 (Il2CppClass<TValue>)+28]) < 0;\n\tv164 = *([v347 @ X8_v24 (Il2CppClass<TValue>)+28]) ^ *([v347 @ X8_v24 (Il2CppClass<TValue>)+28]);\n\tv159 = *([v347 @ X8_v24 (Il2CppClass<TValue>)+28]) & v164;\n\tv154 = v159 < 0;\n\tv259 = &v1 @ X29 - 0x30;\n\tv350 = v179 == v154;\n\tv149 = ~v350;\n\tv145 = ~v149;\n\tif (v145) goto L_FFFFFFFF;\n\tgoto L_012E;\nL_012E:\n\tv212 = 0x1854F10(*([v1 @ X29-48]), v204, *([v1 @ X29-58]), v139, v225, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80);\n\tv383 = Il2CppMethodInfo;\n\tgoto L_013C;\n\tv481 = *([v216 @ X23_v4]);\nL_013C:\n\tv359 = &v1 @ X29 - 0x20;\n\t*([v1 @ X29-C]) = *([v1 @ X29-34]);\n\tv483 = &v1 @ X29 - 0xC;\n\t*([v1 @ X29-20]) = v483;\n\t*([v1 @ X29-18]) = *([v1 @ X29-48]);\n\t*([v383 @ X1_v11 (Il2CppMethodInfo)+10])(v384, *([v383 @ X1_v11 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.values, v359, *([v1 @ X29-48]), v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80);\n\tv486 = this.version + 1;\n\tthis.version = v486;\n\tv363 = *([v264 @ X22_v5+28]) != *([v1 @ X29-8]);\n\tif (v363) goto L_0181;\n\treturn;\nL_0166:\n\t*([v1 @ X29-20]) = *([v1 @ X29-34]);\n\tv266 = &v1 @ X29 - 0x20;\n\t// 362 Box v267 @ X0_v9 (System.Object), typeof(System.Int32), v266 @ X1_v4\n\tv306 = new System.ArgumentOutOfRangeException();\n\tSystem.ArgumentOutOfRangeException::.ctor(v306, \"index\", v267, \"The index is negative or outside the bounds of the collection.\");\n\tthrow v306;\nL_0181:\n\tv401 = 0x1854EB0(v384, Il2CppMethodInfo, this.values, v359, *([v1 @ X29-48]), v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80);\n\treturn;\n// 243 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Insert(int index, TKey key, TValue value)
		{
			//IL_0046: Expected O, but got I
			//IL_0059: Expected I4, but got I8
			//IL_0075: Expected O, but got I
			//IL_0083: Expected O, but got I
			//IL_00ab: Expected O, but got I
			//IL_00be: Expected I4, but got I8
			//IL_00cc: Expected O, but got I
			//IL_00df: Expected O, but got I
			//IL_0100: Expected I4, but got I8
			//IL_03ca: Expected O, but got I
			//IL_03d3: Expected I4, but got O
			//IL_01c8: Expected O, but got I
			//IL_020a: Expected O, but got I
			//IL_0431: Expected O, but got I
			//IL_044a: Expected O, but got I
			//IL_04de: Expected I4, but got O
			//IL_0311: Expected O, but got I
			//IL_0250: Expected O, but got I
			//IL_0353: Expected O, but got I
			//IL_0375: Expected O, but got I
			//IL_050a: Expected O, but got I
			//IL_0526: Expected O, but got I
			//IL_05a7: Expected O, but got I
			//IL_0494: Expected O, but got I
			//IL_04a3: Expected O, but got I
			//IL_068e: Expected O, but got I
			//IL_06b4: Expected O, but got I
			//IL_070c: Expected I4, but got O
			//IL_0390: Expected O, but got I
			//IL_05f7: Expected O, but got I
			//IL_0613: Expected O, but got I
			object obj = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ SYSREG+28]");
			_ = 0;
			nint num = 0;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X8_v3 (Il2CppClass<TKey>)+FC]");
			object obj2 = (nint)0 + (nint)15;
			int num3 = (int)((nint)obj2 & 0x1FFFFFFF0L);
			object obj3 = default(object);
			nint num4 = (nint)obj3 - num3;
			object obj4 = (nint)obj3 - num3;
			object obj5 = (nint)obj3 - num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ X9_v1 (Il2CppClass<TValue>)+FC]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ X9_v1 (Il2CppClass<TValue>)+FC]");
			object obj6 = (nint)0 + (nint)15;
			int num5 = (int)((nint)obj6 & 0x1FFFFFFF0L);
			object obj7 = (nint)obj3 - num5;
			object obj8 = (nint)obj3 - num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F20 (native memset)");
			string text;
			if ((int)(index & 0x80000000L) == 0)
			{
				int count = values.Count;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-34]");
				if ((nint)count >= (nint)0)
				{
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ X8_v39 (Il2CppClass<TKey>)+28]");
					bool flag = (nint)0 < (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ X8_v39 (Il2CppClass<TKey>)+28]");
					nint num7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ X8_v39 (Il2CppClass<TKey>)+28]");
					int num8 = (int)(num7 ^ 0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ X8_v39 (Il2CppClass<TKey>)+28]");
					int num9 = (int)((nint)0 & (nint)num8);
					bool flag2 = num9 < 0;
					object obj9 = (nint)obj - 40;
					if (flag != flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-40]");
						object obj10 = 0;
					}
					else
					{
						object obj10 = obj9;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
					nint num10 = 0;
					object obj11 = (nint)obj - 12;
					TValue val = (TValue)((nint)obj - 32);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-34]");
					_ = 0;
					nint num11 = (nint)obj - 12;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v205 @ X1_v19 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
					List<TKey> list = keys;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-34]");
					int num12 = 0;
					while (true)
					{
						int count2 = list.Count;
						bool flag3 = num12 == count2;
						int num13 = (int)keys;
						if (flag3)
						{
							break;
						}
						TValue val2 = (TValue)((nint)obj - 32);
						nint num14 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v464 @ X1_v22 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
						nint num15 = 0;
						object obj12 = (nint)obj - 32;
						object obj13 = (nint)obj - 12;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v510 @ X1_v26 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
						nint num16 = 0;
						TValue val3 = (TValue)((nint)obj - 32);
						nint num17 = (nint)obj - 12;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-C]");
						object obj14 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v199 @ X1_v27 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
						list = keys;
						num12++;
						bool flag4 = keys == null;
						bool flag5 = !flag4;
						num13 = (int)dictionary;
						num11 = num17;
						val = val3;
						if (!flag5)
						{
							throw new NullReferenceException();
						}
					}
					nint num18 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ X8_v15 (Il2CppClass<TKey>)+28]");
					bool flag6 = (nint)0 < (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ X8_v15 (Il2CppClass<TKey>)+28]");
					nint num19 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ X8_v15 (Il2CppClass<TKey>)+28]");
					int num20 = (int)(num19 ^ 0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ X8_v15 (Il2CppClass<TKey>)+28]");
					int num21 = (int)((nint)0 & (nint)num20);
					bool flag7 = num21 < 0;
					object obj15 = (nint)obj - 40;
					if (flag6 != flag7)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-40]");
						object obj16 = 0;
					}
					else
					{
						object obj16 = obj15;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-60]");
					object obj17 = 0;
					nint num22 = 0;
					TValue val4 = (TValue)((nint)obj - 32);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-34]");
					_ = 0;
					object obj18 = (nint)obj - 12;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v325 @ X1_v9 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
					nint num23 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ X8_v24 (Il2CppClass<TValue>)+28]");
					bool flag8 = (nint)0 < (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ X8_v24 (Il2CppClass<TValue>)+28]");
					nint num24 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ X8_v24 (Il2CppClass<TValue>)+28]");
					int num25 = (int)(num24 ^ 0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ X8_v24 (Il2CppClass<TValue>)+28]");
					int num26 = (int)((nint)0 & (nint)num25);
					bool flag9 = num26 < 0;
					object obj19 = (nint)obj - 48;
					if (flag8 != flag9)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-50]");
						object obj20 = 0;
					}
					else
					{
						object obj20 = obj19;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
					nint num27 = 0;
					text = (string)((nint)obj - 32);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-34]");
					_ = 0;
					object obj21 = (nint)obj - 12;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-48]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v383 @ X1_v11 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
					int num28 = version + 1;
					version = num28;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ X22_v5+28]");
					nint num29 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-8]");
					if (num29 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EB0 (native __stack_chk_fail)");
					}
					return;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-34]");
			_ = 0;
			object obj22 = (nint)obj - 32;
			object actualValue = (int)obj22;
			ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("index", actualValue, "The index is negative or outside the bounds of the collection.");
			text = "The index is negative or outside the bounds of the collection.";
			throw ex;
		}

		[Token(Token = "0x6000759")]
		[Address(RVA = "0x1133C4C", Offset = "0x1133C4C", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = &v13 @ stack_-30_v2;\n\t*([v12 @ X29_v1-8]) = *([v15 @ SYSREG+28]);\n\t*([v12 @ X29_v1-20]) = v48;\n\tv23 = Il2CppClass<TKey>;\n\tv25 = *([v23 @ X8_v3 (Il2CppClass<TKey>)+FC]) + 0xF;\n\tv26 = v25 & 0x1FFFFFFF0;\n\tv74 = &v18 @ stack_-50_v1 - v26;\n\tv36 = *([v23 @ X8_v3 (Il2CppClass<TKey>)+28]) < 0;\n\tv39 = *([v23 @ X8_v3 (Il2CppClass<TKey>)+28]) ^ *([v23 @ X8_v3 (Il2CppClass<TKey>)+28]);\n\tv40 = *([v23 @ X8_v3 (Il2CppClass<TKey>)+28]) & v39;\n\tv41 = v40 < 0;\n\tv42 = &v13 @ stack_-30_v2 - 0x20;\n\tv43 = v36 == v41;\n\tv44 = ~v43;\n\tv45 = ~v44;\n\tif (v45) goto L_002B;\n\tgoto L_002B;\nL_002B:\n\tv49 = 0x1854F10(v74, v42, *([v23 @ X8_v3 (Il2CppClass<TKey>)+FC]), v105, v104, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv66 = Il2CppMethodInfo;\n\tgoto L_0038;\n\tv73 = *([v27 @ X20_v1]);\nL_0038:\n\t*([v12 @ X29_v1-18]) = v74;\n\tv76 = &v13 @ stack_-30_v2 - 0x18;\n\tv77 = &v13 @ stack_-30_v2 - 0xC;\n\t*([v66 @ X1_v3 (Il2CppMethodInfo)+10])(v79, *([v66 @ X1_v3 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.dictionary, v76, v77, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv87 = *([v12 @ X29_v1-C]) == 0;\n\tv92 = ~v87;\n\tv103 = *([v15 @ SYSREG+28]) != *([v12 @ X29_v1-8]);\n\tif (v103) goto L_0061;\n\treturn v92;\n\tv72 = new System.NullReferenceException();\nL_0061:\n\treturnVal2 = 0x1854EB0(v116, v42, *([v23 @ X8_v3 (Il2CppClass<TKey>)+FC]), v105, v104, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\treturn returnVal2;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool ContainsKey(TKey key)
		{
			//IL_0036: Expected O, but got I
			//IL_0049: Expected I4, but got I8
			//IL_0057: Expected O, but got I
			//IL_00be: Expected O, but got I
			//IL_0137: Expected O, but got I
			//IL_0146: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ SYSREG+28]");
			_ = 0;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X8_v3 (Il2CppClass<TKey>)+FC]");
			object obj3 = (nint)0 + (nint)15;
			int num2 = (int)((nint)obj3 & 0x1FFFFFFF0L);
			object obj5 = default(object);
			object obj4 = (nint)obj5 - num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X8_v3 (Il2CppClass<TKey>)+28]");
			bool flag = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X8_v3 (Il2CppClass<TKey>)+28]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X8_v3 (Il2CppClass<TKey>)+28]");
			int num4 = (int)(num3 ^ 0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X8_v3 (Il2CppClass<TKey>)+28]");
			int num5 = (int)((nint)0 & (nint)num4);
			bool flag2 = num5 < 0;
			TKey val = (TKey)((nint)obj2 - 32);
			if (flag != flag2)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
			nint num6 = 0;
			object obj6 = (nint)obj2 - 24;
			object obj7 = (nint)obj2 - 12;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v66 @ X1_v3 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1-C]");
			bool flag3 = (nint)0 == 0;
			bool result = !flag3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ SYSREG+28]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1-8]");
			if (num7 == 0)
			{
				return result;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EB0 (native __stack_chk_fail)");
			bool result2 = default(bool);
			return result2;
		}

		[Token(Token = "0x600075A")]
		[Address(RVA = "0x1133D20", Offset = "0x1133D20", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = &v13 @ stack_-30_v2;\n\t*([v12 @ X29_v1-8]) = *([v15 @ SYSREG+28]);\n\tv19 = *([v92 @ X3_v1+20]);\n\tv21 = *([v19 @ X8_v2+C0]);\n\tv22 = *([v21 @ X8_v3+68]);\n\tv26 = *([v22 @ X9_v1+FC]) + 0xF;\n\tv27 = v26 & 0x1FFFFFFF0;\n\tv28 = &v25 @ stack_-50_v1 - v27;\n\tv33 = *([v21 @ X8_v3+98]);\n\tv34 = &v13 @ stack_-30_v2 - 0xC;\n\tv35 = &v13 @ stack_-30_v2 - 0x20;\n\t*([v12 @ X29_v1-C]) = v89;\n\t*([v12 @ X29_v1-20]) = v34;\n\t*([v12 @ X29_v1-18]) = v28;\n\t*([v33 @ X8_v5+10])(v41, *([v33 @ X8_v5]), *([v21 @ X8_v3+98]), this.keys, v35, v28, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\treturnVal1 = 0x1854F10(methodInfo, v28, *([v22 @ X9_v1+FC]), v35, v28, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv70 = *([v15 @ SYSREG+28]) != *([v12 @ X29_v1-8]);\n\tif (v70) goto L_003F;\n\treturn returnVal1;\n\tv57 = new System.NullReferenceException();\nL_003F:\n\treturnVal2 = 0x1854EB0(v90, v89, this.keys, v92, v91, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\treturn returnVal2;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TKey GetKey(int index)
		{
			//IL_0025: Expected O, but got I
			//IL_0035: Expected O, but got I
			//IL_0045: Expected O, but got I
			//IL_005b: Expected O, but got I
			//IL_006e: Expected I4, but got I8
			//IL_0091: Expected O, but got I
			//IL_00a0: Expected O, but got I
			//IL_00af: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ SYSREG+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ X3_v1+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X8_v2+C0]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X8_v3+68]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X9_v1+FC]");
			object obj6 = (nint)0 + (nint)15;
			int num = (int)((nint)obj6 & 0x1FFFFFFF0L);
			object obj7 = default(object);
			int num2 = (int)((nint)obj7 - num);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X8_v3+98]");
			object obj8 = 0;
			object obj9 = (nint)obj2 - 12;
			object obj10 = (nint)obj2 - 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v33 @ X8_v5+10] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ SYSREG+28]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1-8]");
			TKey result = default(TKey);
			if (num3 == 0)
			{
				return result;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EB0 (native __stack_chk_fail)");
			TKey result2 = default(TKey);
			return result2;
		}

		[Token(Token = "0x600075B")]
		[Address(RVA = "0x1133DD4", Offset = "0x1133DD4", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = &v1 @ X29;\n\t*([v1 @ X29-8]) = *([v14 @ SYSREG+28]);\n\t*([v1 @ X29-28]) = v47;\n\tv22 = Il2CppClass<TKey>;\n\tv24 = *([v22 @ X8_v3 (Il2CppClass<TKey>)+FC]) + 0xF;\n\tv25 = v24 & 0x1FFFFFFF0;\n\tv73 = &v17 @ stack_-60_v1 - v25;\n\t*([v1 @ X29-2C]) = 0;\n\tv35 = *([v22 @ X8_v3 (Il2CppClass<TKey>)+28]) < 0;\n\tv38 = *([v22 @ X8_v3 (Il2CppClass<TKey>)+28]) ^ *([v22 @ X8_v3 (Il2CppClass<TKey>)+28]);\n\tv39 = *([v22 @ X8_v3 (Il2CppClass<TKey>)+28]) & v38;\n\tv40 = v39 < 0;\n\tv41 = &v1 @ X29 - 0x28;\n\tv42 = v35 == v40;\n\tv43 = ~v42;\n\tv44 = ~v43;\n\tif (v44) goto L_002C;\n\tgoto L_002C;\nL_002C:\n\tv48 = 0x1854F10(v73, v41, *([v22 @ X8_v3 (Il2CppClass<TKey>)+FC]), v98, v97, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv65 = Il2CppMethodInfo;\n\tgoto L_0039;\n\tv72 = *([v26 @ X20_v1]);\nL_0039:\n\tv74 = &v1 @ X29 - 0x2C;\n\t*([v1 @ X29-20]) = v73;\n\t*([v1 @ X29-18]) = v74;\n\tv76 = &v1 @ X29 - 0x20;\n\tv77 = &v1 @ X29 - 0xC;\n\t*([v65 @ X1_v3 (Il2CppMethodInfo)+10])(v79, *([v65 @ X1_v3 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.dictionary, v76, v77, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv88 = *([v1 @ X29-C]) == 0;\n\tv93 = ~v88;\n\tv94 = ~v93;\n\tif (v94) goto L_FFFFFFFF;\n\tgoto L_005E;\nL_005E:\n\tv102 = *([v14 @ SYSREG+28]) != *([v1 @ X29-8]);\n\tif (v102) goto L_006A;\n\treturn returnVal2;\n\tv71 = new System.NullReferenceException();\nL_006A:\n\treturnVal1 = 0x1854EB0(v119, v41, *([v22 @ X8_v3 (Il2CppClass<TKey>)+FC]), v98, v97, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\n\treturn returnVal1;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int IndexOf(TKey key)
		{
			//IL_0036: Expected O, but got I
			//IL_0049: Expected I4, but got I8
			//IL_0057: Expected O, but got I
			//IL_00c4: Expected O, but got I
			//IL_015b: Expected O, but got I
			//IL_0174: Expected O, but got I
			//IL_0183: Expected O, but got I
			object obj = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ SYSREG+28]");
			_ = 0;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X8_v3 (Il2CppClass<TKey>)+FC]");
			object obj2 = (nint)0 + (nint)15;
			int num2 = (int)((nint)obj2 & 0x1FFFFFFF0L);
			object obj4 = default(object);
			object obj3 = (nint)obj4 - num2;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X8_v3 (Il2CppClass<TKey>)+28]");
			bool flag = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X8_v3 (Il2CppClass<TKey>)+28]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X8_v3 (Il2CppClass<TKey>)+28]");
			int num4 = (int)(num3 ^ 0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X8_v3 (Il2CppClass<TKey>)+28]");
			int num5 = (int)((nint)0 & (nint)num4);
			bool flag2 = num5 < 0;
			TKey val = (TKey)((nint)obj - 40);
			if (flag != flag2)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
			nint num6 = 0;
			object obj5 = (nint)obj - 44;
			object obj6 = (nint)obj - 32;
			object obj7 = (nint)obj - 12;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v65 @ X1_v3 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-C]");
			int result;
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-2C]");
				result = 0;
			}
			else
			{
				result = -1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ SYSREG+28]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-8]");
			if (num7 == 0)
			{
				return result;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EB0 (native __stack_chk_fail)");
			int result2 = default(int);
			return result2;
		}

		[Token(Token = "0x600075D")]
		[Address(RVA = "0x1133F10", Offset = "0x1133F10", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = &v17 @ stack_-40_v2;\n\t*([v16 @ X29_v1-8]) = *([v19 @ SYSREG+28]);\n\t*([v16 @ X29_v1-28]) = v54;\n\tv30 = Il2CppClass<TKey>;\n\tv32 = *([v30 @ X8_v3 (Il2CppClass<TKey>)+FC]) + 0xF;\n\tv33 = v32 & 0x1FFFFFFF0;\n\tv80 = &v24 @ stack_-70_v1 - v33;\n\t*([v16 @ X29_v1-2C]) = 0;\n\tv42 = *([v30 @ X8_v3 (Il2CppClass<TKey>)+28]) < 0;\n\tv45 = *([v30 @ X8_v3 (Il2CppClass<TKey>)+28]) ^ *([v30 @ X8_v3 (Il2CppClass<TKey>)+28]);\n\tv46 = *([v30 @ X8_v3 (Il2CppClass<TKey>)+28]) & v45;\n\tv47 = v46 < 0;\n\tv48 = &v17 @ stack_-40_v2 - 0x28;\n\tv49 = v42 == v47;\n\tv50 = ~v49;\n\tv51 = ~v50;\n\tif (v51) goto L_0030;\n\tgoto L_0030;\nL_0030:\n\tv55 = 0x1854F10(v80, v48, *([v30 @ X8_v3 (Il2CppClass<TKey>)+FC]), v90, v89, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv72 = Il2CppMethodInfo;\n\tgoto L_003D;\n\tv79 = *([v34 @ X22_v1]);\nL_003D:\n\tv81 = &v17 @ stack_-40_v2 - 0x2C;\n\t*([v16 @ X29_v1-20]) = v80;\n\t*([v16 @ X29_v1-18]) = v81;\n\tv83 = &v17 @ stack_-40_v2 - 0x20;\n\tv84 = &v17 @ stack_-40_v2 - 0xC;\n\t*([v72 @ X1_v3 (Il2CppMethodInfo)+10])(v86, *([v72 @ X1_v3 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.dictionary, v83, v84, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv88 = *([v16 @ X29_v1-C]) == 0;\n\tif (v88) goto L_0055;\n\tv129 = Spine.Collections.OrderedDictionary`2<TKey, TValue>::RemoveAt(this, *([v16 @ X29_v1-2C]));\nL_0055:\n\tv136 = *([v16 @ X29_v1-C]) == 0;\n\tv141 = ~v136;\n\tv94 = *([v19 @ SYSREG+28]) != *([v16 @ X29_v1-8]);\n\tif (v94) goto L_0073;\n\treturn v141;\n\tv78 = new System.NullReferenceException();\nL_0073:\n\treturnVal1 = 0x1854EB0(v111, v48, *([v30 @ X8_v3 (Il2CppClass<TKey>)+FC]), v90, v89, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68);\n\treturn returnVal1;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Remove(TKey key)
		{
			//IL_0036: Expected O, but got I
			//IL_0049: Expected I4, but got I8
			//IL_0057: Expected O, but got I
			//IL_00c4: Expected O, but got I
			//IL_0150: Expected O, but got I
			//IL_0169: Expected O, but got I
			//IL_0178: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ SYSREG+28]");
			_ = 0;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X8_v3 (Il2CppClass<TKey>)+FC]");
			object obj3 = (nint)0 + (nint)15;
			int num2 = (int)((nint)obj3 & 0x1FFFFFFF0L);
			object obj5 = default(object);
			object obj4 = (nint)obj5 - num2;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X8_v3 (Il2CppClass<TKey>)+28]");
			bool flag = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X8_v3 (Il2CppClass<TKey>)+28]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X8_v3 (Il2CppClass<TKey>)+28]");
			int num4 = (int)(num3 ^ 0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X8_v3 (Il2CppClass<TKey>)+28]");
			int num5 = (int)((nint)0 & (nint)num4);
			bool flag2 = num5 < 0;
			TKey val = (TKey)((nint)obj2 - 40);
			if (flag != flag2)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
			nint num6 = 0;
			object obj6 = (nint)obj2 - 44;
			object obj7 = (nint)obj2 - 32;
			object obj8 = (nint)obj2 - 12;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v72 @ X1_v3 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X29_v1-C]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X29_v1-2C]");
				RemoveAt(0);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X29_v1-C]");
			bool flag3 = (nint)0 == 0;
			bool result = !flag3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ SYSREG+28]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X29_v1-8]");
			if (num7 == 0)
			{
				return result;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EB0 (native __stack_chk_fail)");
			bool result2 = default(bool);
			return result2;
		}

		[Token(Token = "0x600075E")]
		[Address(RVA = "0x113401C", Offset = "0x113401C", Length = "0x300")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-60_v2;\n\t*([v24 @ X29_v1-24]) = index;\n\t*([v24 @ X29_v1-30]) = v28;\n\t*([v24 @ X29_v1-8]) = *([v28 @ SYSREG+28]);\n\tv36 = Il2CppClass<TKey>;\n\tv40 = *([v36 @ X8_v4 (Il2CppClass<TKey>)+FC]) + 0xF;\n\tv41 = v40 & 0x1FFFFFFF0;\n\tv184 = &v39 @ stack_-90_v1 - v41;\n\tv46 = &v39 @ stack_-90_v1 - v41;\n\tv50 = &v39 @ stack_-90_v1 - v41;\n\tv54 = &v39 @ stack_-90_v1 - v41;\n\tv59 = 0x1854F20(v54, 0, *([v36 @ X8_v4 (Il2CppClass<TKey>)+FC]), v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72);\n\tv75 = &v39 @ stack_-90_v1 - v41;\n\tv80 = 0x1854F20(v75, 0, *([v36 @ X8_v4 (Il2CppClass<TKey>)+FC]), v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72);\n\tv83 = Il2CppMethodInfo;\n\tv85 = &v25 @ stack_-60_v2 - 0xC;\n\tv146 = &v25 @ stack_-60_v2 - 0x20;\n\t*([v24 @ X29_v1-C]) = *([v24 @ X29_v1-24]);\n\t*([v24 @ X29_v1-20]) = v85;\n\t*([v24 @ X29_v1-18]) = v184;\n\t*([v83 @ X1_v9 (Il2CppMethodInfo)+10])(v90, *([v83 @ X1_v9 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.keys, v146, v184, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72);\n\tv94 = 0x1854F10(v54, v184, *([v36 @ X8_v4 (Il2CppClass<TKey>)+FC]), v146, v184, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72);\n\tv228 = this.keys;\n\tv189 = *([v24 @ X29_v1-24]) + 1;\nL_004F:\n\tv165 = System.Collections.Generic.List`1<TKey>::get_Count(v228);\n\tv96 = v189 >= v165;\n\tif (v96) goto L_00AC;\n\tv145 = &v25 @ stack_-60_v2 - 0x20;\n\tv244 = Il2CppMethodInfo;\n\tv245 = &v25 @ stack_-60_v2 - 0xC;\n\t*([v24 @ X29_v1-C]) = v189;\n\t*([v24 @ X29_v1-20]) = v245;\n\t*([v24 @ X29_v1-18]) = v184;\n\t*([v244 @ X1_v13 (Il2CppMethodInfo)+10])(v247, *([v244 @ X1_v13 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.keys, v145, v184, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72);\n\tv251 = 0x1854F10(v75, v184, *([v36 @ X8_v4 (Il2CppClass<TKey>)+FC]), v145, v184, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72);\n\tv258 = 0x1854F10(v46, v75, *([v36 @ X8_v4 (Il2CppClass<TKey>)+FC]), v145, v184, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72);\n\tv166 = 0x1854F10(v50, v75, *([v36 @ X8_v4 (Il2CppClass<TKey>)+FC]), v145, v184, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72);\n\tgoto L_0083;\n\tv322 = *([v50 @ X25_v1]);\nL_0083:\n\tv324 = Il2CppMethodInfo;\n\tv325 = &v25 @ stack_-60_v2 - 0x20;\n\tv326 = &v25 @ stack_-60_v2 - 0xC;\n\t*([v24 @ X29_v1-20]) = v50;\n\t*([v324 @ X1_v17 (Il2CppMethodInfo)+10])(v330, *([v324 @ X1_v17 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.dictionary, v325, v326, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72);\n\tgoto L_0095;\n\tv338 = *([v46 @ X24_v1]);\nL_0095:\n\tv156 = Il2CppMethodInfo;\n\tv142 = &v25 @ stack_-60_v2 - 0x20;\n\tv136 = &v25 @ stack_-60_v2 - 0xC;\n\tv192 = *([v24 @ X29_v1-C]) - 1;\n\t*([v24 @ X29_v1-20]) = v46;\n\tv342 = &v25 @ stack_-60_v2 - 0xC;\n\t*([v24 @ X29_v1-C]) = v192;\n\t*([v24 @ X29_v1-18]) = v342;\n\t*([v156 @ X1_v18 (Il2CppMethodInfo)+10])(v343, *([v156 @ X1_v18 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.dictionary, v142, v136, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72);\n\tv228 = this.keys;\n\tv189 = v189 + 1;\n\tv344 = this.keys == 0;\n\tv177 = ~v344;\n\tif (v177) goto L_004F;\n\tthrow System.NullReferenceException;\nL_00AC:\n\tv167 = 0x1854F10(v184, v54, *([v36 @ X8_v4 (Il2CppClass<TKey>)+FC]), v146, v140, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72);\n\tv161 = Il2CppMethodInfo;\n\tgoto L_00BA;\n\tv240 = *([v185 @ X22_v2]);\nL_00BA:\n\t*([v24 @ X29_v1-20]) = v184;\n\tv147 = &v25 @ stack_-60_v2 - 0x20;\n\tv141 = &v25 @ stack_-60_v2 - 0xC;\n\t*([v161 @ X1_v5 (Il2CppMethodInfo)+10])(v241, *([v161 @ X1_v5 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.dictionary, v147, v141, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72);\n\tv254 = System.Collections.Generic.List`1<TKey>::RemoveAt(this.keys, *([v24 @ X29_v1-24]));\n\tv264 = System.Collections.Generic.List`1<TValue>::RemoveAt(this.values, *([v24 @ X29_v1-24]));\n\tv266 = this.version + 1;\n\tthis.version = v266;\n\tv267 = *([v24 @ X29_v1-30]);\n\tv279 = *([v267 @ X8_v23+28]) != *([v24 @ X29_v1-8]);\n\tif (v279) goto L_00F3;\n\treturn;\nL_00F3:\n\tv299 = System.Collections.Generic.List`1<TValue>::RemoveAt(v264, *([v24 @ X29_v1-24]));\n\treturn;\n// 166 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RemoveAt(int index)
		{
			//IL_003b: Expected O, but got I
			//IL_004e: Expected I4, but got I8
			//IL_005c: Expected O, but got I
			//IL_006a: Expected O, but got I
			//IL_0078: Expected O, but got I
			//IL_009e: Expected O, but got I
			//IL_00c2: Expected O, but got I
			//IL_00d1: Expected O, but got I
			//IL_013d: Expected O, but got I
			//IL_0152: Expected O, but got I
			//IL_02d7: Expected O, but got I
			//IL_02e6: Expected O, but got I
			//IL_0217: Expected O, but got I
			//IL_0272: Expected O, but got I
			//IL_0281: Expected O, but got I
			//IL_030b: Expected O, but got I
			//IL_031a: Expected O, but got I
			//IL_0331: Expected O, but got I
			//IL_0345: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ SYSREG+28]");
			_ = 0;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X8_v4 (Il2CppClass<TKey>)+FC]");
			object obj3 = (nint)0 + (nint)15;
			int num2 = (int)((nint)obj3 & 0x1FFFFFFF0L);
			object obj5 = default(object);
			object obj4 = (nint)obj5 - num2;
			object obj6 = (nint)obj5 - num2;
			object obj7 = (nint)obj5 - num2;
			nint num3 = (nint)obj5 - num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F20 (native memset)");
			object obj8 = (nint)obj5 - num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F20 (native memset)");
			nint num4 = 0;
			object obj9 = (nint)obj2 - 12;
			object obj10 = (nint)obj2 - 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-24]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v83 @ X1_v9 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
			List<TKey> list = keys;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-24]");
			int num5 = (int)((nint)0 + (nint)1);
			object obj11 = obj4;
			while (true)
			{
				int count = list.Count;
				if (num5 >= count)
				{
					break;
				}
				object obj12 = (nint)obj2 - 32;
				nint num6 = 0;
				object obj13 = (nint)obj2 - 12;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v244 @ X1_v13 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
				nint num7 = 0;
				object obj14 = (nint)obj2 - 32;
				object obj15 = (nint)obj2 - 12;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v324 @ X1_v17 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				nint num8 = 0;
				object obj16 = (nint)obj2 - 32;
				object obj17 = (nint)obj2 - 12;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-C]");
				object obj18 = -1;
				object obj19 = (nint)obj2 - 12;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v156 @ X1_v18 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				list = keys;
				num5++;
				bool flag = keys == null;
				bool flag2 = !flag;
				obj11 = obj17;
				obj10 = obj16;
				if (!flag2)
				{
					throw new NullReferenceException();
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
			nint num9 = 0;
			object obj20 = (nint)obj2 - 32;
			object obj21 = (nint)obj2 - 12;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v161 @ X1_v5 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			List<TKey> list2 = keys;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-24]");
			list2.RemoveAt(0);
			List<TValue> list3 = values;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-24]");
			list3.RemoveAt(0);
			int num10 = version + 1;
			version = num10;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-30]");
			object obj22 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ X8_v23+28]");
			nint num11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-8]");
			if (num11 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-24]");
				List<TValue> list4 = default(List<TValue>);
				list4.RemoveAt(0);
			}
		}

		[Token(Token = "0x600075F")]
		[Address(RVA = "0x113431C", Offset = "0x113431C", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = &v23 @ stack_-60_v2;\n\t*([v22 @ X29_v1-8]) = *([v25 @ SYSREG+28]);\n\t*([v22 @ X29_v1-28]) = v70;\n\tv36 = Il2CppClass<TKey>;\n\tv37 = Il2CppClass<TValue>;\n\tv42 = *([v36 @ X9_v1 (Il2CppClass<TKey>)+FC]) + 0xF;\n\tv43 = v42 & 0x1FFFFFFF0;\n\tv103 = &v41 @ stack_-90_v1 - v43;\n\tv46 = *([v37 @ X8_v3 (Il2CppClass<TValue>)+FC]) + 0xF;\n\tv49 = v46 & 0x1FFFFFFF0;\n\tv50 = &v41 @ stack_-90_v1 - v49;\n\t*([v22 @ X29_v1-2C]) = 0;\n\tv58 = *([v36 @ X9_v1 (Il2CppClass<TKey>)+28]) < 0;\n\tv61 = *([v36 @ X9_v1 (Il2CppClass<TKey>)+28]) ^ *([v36 @ X9_v1 (Il2CppClass<TKey>)+28]);\n\tv62 = *([v36 @ X9_v1 (Il2CppClass<TKey>)+28]) & v61;\n\tv63 = v62 < 0;\n\tv64 = &v23 @ stack_-60_v2 - 0x28;\n\tv65 = v58 == v63;\n\tv66 = ~v65;\n\tv67 = ~v66;\n\tif (v67) goto L_003B;\n\tgoto L_003B;\nL_003B:\n\tv71 = 0x1854F10(v103, v64, *([v36 @ X9_v1 (Il2CppClass<TKey>)+FC]), methodInfo, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83);\n\tv87 = Il2CppMethodInfo;\n\tgoto L_0048;\n\tv110 = *([v44 @ X24_v1]);\nL_0048:\n\tv111 = &v23 @ stack_-60_v2 - 0x2C;\n\t*([v22 @ X29_v1-20]) = v103;\n\t*([v22 @ X29_v1-18]) = v111;\n\tv118 = &v23 @ stack_-60_v2 - 0x20;\n\tv116 = &v23 @ stack_-60_v2 - 0xC;\n\t*([v87 @ X1_v4 (Il2CppMethodInfo)+10])(v99, *([v87 @ X1_v4 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.dictionary, v118, v116, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83);\n\tv114 = *([v22 @ X29_v1-C]) == 0;\n\tif (v114) goto L_0075;\n\tv156 = &v23 @ stack_-60_v2 - 0xC;\n\tv118 = &v23 @ stack_-60_v2 - 0x20;\n\tv160 = Il2CppMethodInfo;\n\t*([v22 @ X29_v1-C]) = *([v22 @ X29_v1-2C]);\n\t*([v22 @ X29_v1-20]) = v156;\n\t*([v22 @ X29_v1-18]) = v50;\n\t*([v160 @ X1_v7 (Il2CppMethodInfo)+10])(v164, *([v160 @ X1_v7 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.values, v118, v50, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83);\n\tv168 = 0x1854F10(value, v50, *([v37 @ X8_v3 (Il2CppClass<TValue>)+FC]), v118, v50, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83);\n\tgoto L_FFFFFFFF;\n\tv221 = 0xB348B0(v212, v166, v167, v157, v158, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83);\n\tgoto L_0082;\nL_0075:\n\tv154 = 0x1854F20(value, 0, *([v37 @ X8_v3 (Il2CppClass<TValue>)+FC]), v118, v116, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83);\nL_0082:\n\tv122 = *([v25 @ SYSREG+28]) != *([v22 @ X29_v1-8]);\n\tif (v122) goto L_0093;\n\treturn returnVal2;\n\tv109 = new System.NullReferenceException();\nL_0093:\n\treturnVal1 = 0x1854EB0(v139, v119, v144, v117, v115, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83);\n\treturn returnVal1;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool TryGetValue(TKey key, out TValue value)
		{
			//IL_0046: Expected O, but got I
			//IL_0059: Expected I4, but got I8
			//IL_0067: Expected O, but got I
			//IL_007d: Expected O, but got I
			//IL_0090: Expected I4, but got I8
			//IL_009e: Expected O, but got I
			//IL_010b: Expected O, but got I
			//IL_01fa: Expected O, but got I
			//IL_0213: Expected O, but got I
			//IL_0222: Expected O, but got I
			//IL_015c: Expected O, but got I
			//IL_016b: Expected O, but got I
			value = default(TValue);
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ SYSREG+28]");
			_ = 0;
			nint num = 0;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X9_v1 (Il2CppClass<TKey>)+FC]");
			object obj3 = (nint)0 + (nint)15;
			int num3 = (int)((nint)obj3 & 0x1FFFFFFF0L);
			object obj5 = default(object);
			object obj4 = (nint)obj5 - num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X8_v3 (Il2CppClass<TValue>)+FC]");
			object obj6 = (nint)0 + (nint)15;
			int num4 = (int)((nint)obj6 & 0x1FFFFFFF0L);
			object obj7 = (nint)obj5 - num4;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X9_v1 (Il2CppClass<TKey>)+28]");
			bool flag = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X9_v1 (Il2CppClass<TKey>)+28]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X9_v1 (Il2CppClass<TKey>)+28]");
			int num6 = (int)(num5 ^ 0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X9_v1 (Il2CppClass<TKey>)+28]");
			int num7 = (int)((nint)0 & (nint)num6);
			bool flag2 = num7 < 0;
			TKey val = (TKey)((nint)obj2 - 40);
			if (flag != flag2)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
			nint num8 = 0;
			object obj8 = (nint)obj2 - 44;
			object obj9 = (nint)obj2 - 32;
			object obj10 = (nint)obj2 - 12;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v87 @ X1_v4 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1-C]");
			bool result;
			if ((nint)0 != 0)
			{
				object obj11 = (nint)obj2 - 12;
				obj9 = (nint)obj2 - 32;
				nint num9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1-2C]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v160 @ X1_v7 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
				result = true;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F20 (native memset)");
				result = false;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ SYSREG+28]");
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1-8]");
			if (num10 == 0)
			{
				return result;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EB0 (native __stack_chk_fail)");
			bool result2 = default(bool);
			return result2;
		}

		[Token(Token = "0x6000765")]
		[Address(RVA = "0x1134A8C", Offset = "0x1134A8C", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = System.Collections.Generic.Dictionary`2<TKey, System.Int32>::Clear(this.dictionary);\n\tv46 = System.Collections.Generic.List`1<TKey>::Clear(this.keys);\n\tv51 = System.Collections.Generic.List`1<TValue>::Clear(this.values);\n\tv53 = this.version + 1;\n\tthis.version = v53;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Clear()
		{
			dictionary.Clear();
			keys.Clear();
			values.Clear();
			int num = version + 1;
			version = num;
		}

		[IteratorStateMachine(typeof(OrderedDictionary<, >._003CGetEnumerator_003Ed__34))]
		[Token(Token = "0x6000767")]
		[Address(RVA = "0x1134B34", Offset = "0x1134B34", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv19 = v14;\n\tv20 = 0xB348B0(v19, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = v20;\nL_0013:\n\tv39 = new Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>();\n\tv46 = Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>::.ctor(v39, 0);\n\tv51 = Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>;\n\tv53 = *([v51 @ X8_v10 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>)+80]) + 0x40;\n\tv55 = Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>::.ctor(v53, 8);\n\tv59 = Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>::.ctor(v39, v53);\n\t*([v59 @ X0_v9 (Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>)]) = this;\n\treturn v39;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			//IL_0021: Expected O, but got I
			IEnumerator<KeyValuePair<TKey, TValue>> result = new _003CGetEnumerator_003Ed__34(0);
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X8_v10 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>+<GetEnumerator>d__34<TKey, TValue>>)+80]");
			_003CGetEnumerator_003Ed__34 _003CGetEnumerator_003Ed__35 = (_003CGetEnumerator_003Ed__34)((nint)0 + (nint)64);
			return result;
		}

		[Token(Token = "0x6000768")]
		[Address(RVA = "0x1134BD0", Offset = "0x1134BD0", Length = "0x1D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = &v21 @ stack_-50_v2;\n\t*([v20 @ X29_v1-8]) = *([v23 @ SYSREG+28]);\n\tv35 = Il2CppClass<TKey>;\n\tv37 = *([v35 @ X9_v1 (Il2CppClass<TKey>)+FC]) + 0xF;\n\tv38 = v37 & 0x1FFFFFFF0;\n\tv94 = &v26 @ stack_-80_v1 - v38;\n\tv41 = Il2CppClass<TValue>;\n\tv45 = *([v41 @ X9_v5 (Il2CppClass<TValue>)+FC]) + 0xF;\n\tv46 = v45 & 0x1FFFFFFF0;\n\tv47 = &v26 @ stack_-80_v1 - v46;\n\tv51 = &v26 @ stack_-80_v1 - v46;\n\t*([v20 @ X29_v1-24]) = 0;\n\tv53 = Il2CppMethodInfo;\n\tv55 = &v21 @ stack_-50_v2 - 0x20;\n\t*([v20 @ X29_v1-20]) = v94;\n\t*([v53 @ X1_v1 (Il2CppMethodInfo)+10])(v60, *([v53 @ X1_v1 (Il2CppMethodInfo)]), Il2CppMethodInfo, item, v55, v94, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\tv76 = Il2CppMethodInfo;\n\tgoto L_003D;\n\tv99 = *([v39 @ X24_v1]);\nL_003D:\n\tv100 = &v21 @ stack_-50_v2 - 0x24;\n\t*([v20 @ X29_v1-20]) = v94;\n\t*([v20 @ X29_v1-18]) = v100;\n\tv141 = &v21 @ stack_-50_v2 - 0x20;\n\tv135 = &v21 @ stack_-50_v2 - 0xC;\n\t*([v76 @ X1_v4 (Il2CppMethodInfo)+10])(v85, *([v76 @ X1_v4 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.dictionary, v141, v135, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\tv103 = *([v20 @ X29_v1-C]) == 0;\n\tif (v103) goto L_FFFFFFFF;\n\tv156 = &v21 @ stack_-50_v2 - 0xC;\n\tv157 = &v21 @ stack_-50_v2 - 0x20;\n\tv160 = Il2CppMethodInfo;\n\t*([v20 @ X29_v1-C]) = *([v20 @ X29_v1-24]);\n\t*([v20 @ X29_v1-20]) = v156;\n\t*([v20 @ X29_v1-18]) = v47;\n\t*([v160 @ X1_v6 (Il2CppMethodInfo)+10])(v164, *([v160 @ X1_v6 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.values, v157, v47, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\t// 92 Box v169 @ X0_v14 (System.Object), typeof(Il2CppClass<TValue>), v47 @ X22_v1\n\tv141 = &v21 @ stack_-50_v2 - 0x20;\n\tv235 = Il2CppMethodInfo;\n\t*([v20 @ X29_v1-20]) = v51;\n\t*([v235 @ X1_v8 (Il2CppMethodInfo)+10])(v238, *([v235 @ X1_v8 (Il2CppMethodInfo)]), Il2CppMethodInfo, item, v141, v51, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\t// 109 Box v243 @ X0_v18 (System.Object), typeof(Il2CppClass<TValue>), v51 @ X21_v1\n\tv250 = System.Object::Equals(v169, v243);\n\tv178 = v250 == 0;\n\tv172 = ~v178;\n\tv170 = ~v172;\n\tif (v170) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_008C;\nL_008C:\n\tv121 = *([v23 @ SYSREG+28]) != *([v20 @ X29_v1-8]);\n\tif (v121) goto L_009C;\n\treturn returnVal2;\n\tv98 = new System.NullReferenceException();\nL_009C:\n\treturnVal1 = 0x1854EB0(v136, v142, v138, v140, v134, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\treturn returnVal1;\n// 105 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		int IList<KeyValuePair<TKey, TValue>>.IndexOf(KeyValuePair<TKey, TValue> item)
		{
			//IL_0031: Expected O, but got I
			//IL_0044: Expected I4, but got I8
			//IL_0052: Expected O, but got I
			//IL_006e: Expected O, but got I
			//IL_0081: Expected I4, but got I8
			//IL_008f: Expected O, but got I
			//IL_009d: Expected O, but got I
			//IL_00b8: Expected O, but got I
			//IL_01f8: Expected O, but got I
			//IL_0211: Expected O, but got I
			//IL_0220: Expected O, but got I
			//IL_00e6: Expected O, but got I
			//IL_00f5: Expected O, but got I
			//IL_0125: Expected I, but got O
			//IL_0138: Expected O, but got I
			//IL_0156: Expected I, but got O
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ SYSREG+28]");
			_ = 0;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ X9_v1 (Il2CppClass<TKey>)+FC]");
			object obj3 = (nint)0 + (nint)15;
			int num2 = (int)((nint)obj3 & 0x1FFFFFFF0L);
			object obj5 = default(object);
			object obj4 = (nint)obj5 - num2;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ X9_v5 (Il2CppClass<TValue>)+FC]");
			object obj6 = (nint)0 + (nint)15;
			int num4 = (int)((nint)obj6 & 0x1FFFFFFF0L);
			object obj7 = (nint)obj5 - num4;
			object obj8 = (nint)obj5 - num4;
			_ = 0;
			nint num5 = 0;
			object obj9 = (nint)obj2 - 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v53 @ X1_v1 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			nint num6 = 0;
			object obj10 = (nint)obj2 - 36;
			object obj11 = (nint)obj2 - 32;
			object obj12 = (nint)obj2 - 12;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v76 @ X1_v4 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X29_v1-C]");
			int result;
			if ((nint)0 != 0)
			{
				object obj13 = (nint)obj2 - 12;
				object obj14 = (nint)obj2 - 32;
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X29_v1-24]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v160 @ X1_v6 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				object objA = (IntPtr)obj7;
				obj11 = (nint)obj2 - 32;
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v235 @ X1_v8 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				object objB = (IntPtr)obj8;
				if (object.Equals(objA, objB))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X29_v1-24]");
					result = 0;
				}
				else
				{
					result = -1;
				}
			}
			else
			{
				result = -1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ SYSREG+28]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X29_v1-8]");
			if (num9 == 0)
			{
				return result;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EB0 (native __stack_chk_fail)");
			int result2 = default(int);
			return result2;
		}

		[Token(Token = "0x6000769")]
		[Address(RVA = "0x1134DA8", Offset = "0x1134DA8", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = &v19 @ stack_-50_v2;\n\t*([v18 @ X29_v1-8]) = *([v21 @ SYSREG+28]);\n\tv35 = Il2CppClass<TKey>;\n\tv37 = *([v35 @ X9_v1 (Il2CppClass<TKey>)+FC]) + 0xF;\n\tv38 = v37 & 0x1FFFFFFF0;\n\tv85 = &v24 @ stack_-80_v1 - v38;\n\tv41 = Il2CppClass<TValue>;\n\tv45 = *([v41 @ X9_v5 (Il2CppClass<TValue>)+FC]) + 0xF;\n\tv46 = v45 & 0x1FFFFFFF0;\n\tv92 = &v24 @ stack_-80_v1 - v46;\n\tv49 = Il2CppMethodInfo;\n\tv50 = &v19 @ stack_-50_v2 - 0x28;\n\t*([v18 @ X29_v1-28]) = v85;\n\t*([v49 @ X1_v1 (Il2CppMethodInfo)+10])(v54, *([v49 @ X1_v1 (Il2CppMethodInfo)]), Il2CppMethodInfo, item, v50, v85, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65);\n\tv67 = &v19 @ stack_-50_v2 - 0x28;\n\tv71 = Il2CppMethodInfo;\n\t*([v18 @ X29_v1-28]) = v92;\n\t*([v71 @ X1_v2 (Il2CppMethodInfo)+10])(v74, *([v71 @ X1_v2 (Il2CppMethodInfo)]), Il2CppMethodInfo, item, v67, v92, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65);\n\tv78 = Il2CppMethodInfo;\n\tgoto L_0044;\n\tv84 = *([v39 @ X21_v1]);\nL_0044:\n\tgoto L_0046;\n\tv91 = *([v47 @ X22_v1]);\nL_0046:\n\tv93 = &v19 @ stack_-50_v2 - 0xC;\n\t*([v18 @ X29_v1-C]) = index;\n\t*([v18 @ X29_v1-28]) = v93;\n\t*([v18 @ X29_v1-20]) = v85;\n\t*([v18 @ X29_v1-18]) = v92;\n\tv95 = &v19 @ stack_-50_v2 - 0x28;\n\t*([v78 @ X1_v3 (Il2CppMethodInfo)+10])(v98, *([v78 @ X1_v3 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, v95, v92, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65);\n\tv110 = *([v21 @ SYSREG+28]) != *([v18 @ X29_v1-8]);\n\tif (v110) goto L_0069;\n\treturn;\nL_0069:\n\tv126 = 0x1854EB0(v98, Il2CppMethodInfo, this, v95, v92, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65);\n\treturn;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		void IList<KeyValuePair<TKey, TValue>>.Insert(int index, KeyValuePair<TKey, TValue> item)
		{
			//IL_0031: Expected O, but got I
			//IL_0044: Expected I4, but got I8
			//IL_0052: Expected O, but got I
			//IL_006e: Expected O, but got I
			//IL_0081: Expected I4, but got I8
			//IL_008f: Expected O, but got I
			//IL_00a4: Expected O, but got I
			//IL_00c2: Expected O, but got I
			//IL_0102: Expected O, but got I
			//IL_0125: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ SYSREG+28]");
			_ = 0;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ X9_v1 (Il2CppClass<TKey>)+FC]");
			object obj3 = (nint)0 + (nint)15;
			int num2 = (int)((nint)obj3 & 0x1FFFFFFF0L);
			object obj5 = default(object);
			object obj4 = (nint)obj5 - num2;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ X9_v5 (Il2CppClass<TValue>)+FC]");
			object obj6 = (nint)0 + (nint)15;
			int num4 = (int)((nint)obj6 & 0x1FFFFFFF0L);
			object obj7 = (nint)obj5 - num4;
			nint num5 = 0;
			object obj8 = (nint)obj2 - 40;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v49 @ X1_v1 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			object obj9 = (nint)obj2 - 40;
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v71 @ X1_v2 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			nint num7 = 0;
			object obj10 = (nint)obj2 - 12;
			object obj11 = (nint)obj2 - 40;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v78 @ X1_v3 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ SYSREG+28]");
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ X29_v1-8]");
			if (num8 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EB0 (native __stack_chk_fail)");
			}
		}

		[Token(Token = "0x600076E")]
		[Address(RVA = "0x113557C", Offset = "0x113557C", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = &v17 @ stack_-40_v2;\n\t*([v16 @ X29_v1-8]) = *([v19 @ SYSREG+28]);\n\tv31 = Il2CppClass<TKey>;\n\tv33 = *([v31 @ X9_v1 (Il2CppClass<TKey>)+FC]) + 0xF;\n\tv34 = v33 & 0x1FFFFFFF0;\n\tv82 = &v22 @ stack_-60_v1 - v34;\n\tv37 = Il2CppClass<TValue>;\n\tv41 = *([v37 @ X9_v5 (Il2CppClass<TValue>)+FC]) + 0xF;\n\tv42 = v41 & 0x1FFFFFFF0;\n\tv89 = &v22 @ stack_-60_v1 - v42;\n\tv45 = Il2CppMethodInfo;\n\tv46 = &v17 @ stack_-40_v2 - 0x18;\n\t*([v16 @ X29_v1-18]) = v82;\n\t*([v45 @ X1_v1 (Il2CppMethodInfo)+10])(v51, *([v45 @ X1_v1 (Il2CppMethodInfo)]), Il2CppMethodInfo, item, v46, v82, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv64 = &v17 @ stack_-40_v2 - 0x18;\n\tv68 = Il2CppMethodInfo;\n\t*([v16 @ X29_v1-18]) = v89;\n\t*([v68 @ X1_v2 (Il2CppMethodInfo)+10])(v71, *([v68 @ X1_v2 (Il2CppMethodInfo)]), Il2CppMethodInfo, item, v64, v89, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv75 = Il2CppMethodInfo;\n\tgoto L_0043;\n\tv81 = *([v35 @ X20_v1]);\nL_0043:\n\tgoto L_0045;\n\tv88 = *([v43 @ X21_v1]);\nL_0045:\n\t*([v16 @ X29_v1-18]) = v82;\n\t*([v16 @ X29_v1-10]) = v89;\n\tv91 = &v17 @ stack_-40_v2 - 0x18;\n\t*([v75 @ X1_v3 (Il2CppMethodInfo)+10])(v94, *([v75 @ X1_v3 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, v91, v89, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv106 = *([v19 @ SYSREG+28]) != *([v16 @ X29_v1-8]);\n\tif (v106) goto L_0064;\n\treturn;\nL_0064:\n\tv119 = 0x1854EB0(v94, Il2CppMethodInfo, this, v91, v89, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
		{
			//IL_0031: Expected O, but got I
			//IL_0044: Expected I4, but got I8
			//IL_0052: Expected O, but got I
			//IL_006e: Expected O, but got I
			//IL_0081: Expected I4, but got I8
			//IL_008f: Expected O, but got I
			//IL_00a4: Expected O, but got I
			//IL_00c2: Expected O, but got I
			//IL_010c: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ SYSREG+28]");
			_ = 0;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ X9_v1 (Il2CppClass<TKey>)+FC]");
			object obj3 = (nint)0 + (nint)15;
			int num2 = (int)((nint)obj3 & 0x1FFFFFFF0L);
			object obj5 = default(object);
			object obj4 = (nint)obj5 - num2;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X9_v5 (Il2CppClass<TValue>)+FC]");
			object obj6 = (nint)0 + (nint)15;
			int num4 = (int)((nint)obj6 & 0x1FFFFFFF0L);
			object obj7 = (nint)obj5 - num4;
			nint num5 = 0;
			object obj8 = (nint)obj2 - 24;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v45 @ X1_v1 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			object obj9 = (nint)obj2 - 24;
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v68 @ X1_v2 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			nint num7 = 0;
			object obj10 = (nint)obj2 - 24;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v75 @ X1_v3 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ SYSREG+28]");
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X29_v1-8]");
			if (num8 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EB0 (native __stack_chk_fail)");
			}
		}

		[Token(Token = "0x600076F")]
		[Address(RVA = "0x11356A8", Offset = "0x11356A8", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = &v21 @ stack_-50_v2;\n\t*([v20 @ X29_v1-8]) = *([v23 @ SYSREG+28]);\n\tv35 = Il2CppClass<TKey>;\n\tv37 = *([v35 @ X9_v1 (Il2CppClass<TKey>)+FC]) + 0xF;\n\tv38 = v37 & 0x1FFFFFFF0;\n\tv94 = &v26 @ stack_-80_v1 - v38;\n\tv41 = Il2CppClass<TValue>;\n\tv45 = *([v41 @ X9_v5 (Il2CppClass<TValue>)+FC]) + 0xF;\n\tv46 = v45 & 0x1FFFFFFF0;\n\tv47 = &v26 @ stack_-80_v1 - v46;\n\tv51 = &v26 @ stack_-80_v1 - v46;\n\t*([v20 @ X29_v1-24]) = 0;\n\tv53 = Il2CppMethodInfo;\n\tv55 = &v21 @ stack_-50_v2 - 0x20;\n\t*([v20 @ X29_v1-20]) = v94;\n\t*([v53 @ X1_v1 (Il2CppMethodInfo)+10])(v60, *([v53 @ X1_v1 (Il2CppMethodInfo)]), Il2CppMethodInfo, item, v55, v94, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\tv76 = Il2CppMethodInfo;\n\tgoto L_003D;\n\tv99 = *([v39 @ X24_v1]);\nL_003D:\n\tv100 = &v21 @ stack_-50_v2 - 0x24;\n\t*([v20 @ X29_v1-20]) = v94;\n\t*([v20 @ X29_v1-18]) = v100;\n\tv138 = &v21 @ stack_-50_v2 - 0x20;\n\tv132 = &v21 @ stack_-50_v2 - 0xC;\n\t*([v76 @ X1_v4 (Il2CppMethodInfo)+10])(v85, *([v76 @ X1_v4 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.dictionary, v138, v132, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\tv103 = *([v20 @ X29_v1-C]) == 0;\n\tif (v103) goto L_FFFFFFFF;\n\tv171 = &v21 @ stack_-50_v2 - 0xC;\n\tv172 = &v21 @ stack_-50_v2 - 0x20;\n\tv175 = Il2CppMethodInfo;\n\t*([v20 @ X29_v1-C]) = *([v20 @ X29_v1-24]);\n\t*([v20 @ X29_v1-20]) = v171;\n\t*([v20 @ X29_v1-18]) = v47;\n\t*([v175 @ X1_v7 (Il2CppMethodInfo)+10])(v179, *([v175 @ X1_v7 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.values, v172, v47, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\t// 92 Box v184 @ X0_v15 (System.Object), typeof(Il2CppClass<TValue>), v47 @ X22_v1\n\tv138 = &v21 @ stack_-50_v2 - 0x20;\n\tv230 = Il2CppMethodInfo;\n\t*([v20 @ X29_v1-20]) = v51;\n\t*([v230 @ X1_v9 (Il2CppMethodInfo)+10])(v233, *([v230 @ X1_v9 (Il2CppMethodInfo)]), Il2CppMethodInfo, item, v138, v51, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\t// 109 Box v237 @ X0_v19 (System.Object), typeof(Il2CppClass<TValue>), v51 @ X21_v1\n\tv154 = System.Object::Equals(v184, v237);\n\tv164 = v154 == 0;\n\tif (v164) goto L_FFFFFFFF;\n\tgoto L_0083;\nL_0083:\n\tv106 = *([v23 @ SYSREG+28]) != *([v20 @ X29_v1-8]);\n\tif (v106) goto L_0093;\n\treturn returnVal2;\n\tv98 = new System.NullReferenceException();\nL_0093:\n\treturnVal1 = 0x1854EB0(v133, v139, v135, v137, v131, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\treturn returnVal1;\n// 99 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
		{
			//IL_0031: Expected O, but got I
			//IL_0044: Expected I4, but got I8
			//IL_0052: Expected O, but got I
			//IL_006e: Expected O, but got I
			//IL_0081: Expected I4, but got I8
			//IL_008f: Expected O, but got I
			//IL_009d: Expected O, but got I
			//IL_00b8: Expected O, but got I
			//IL_01ce: Expected O, but got I
			//IL_01e7: Expected O, but got I
			//IL_01f6: Expected O, but got I
			//IL_00e6: Expected O, but got I
			//IL_00f5: Expected O, but got I
			//IL_0125: Expected I, but got O
			//IL_0138: Expected O, but got I
			//IL_0156: Expected I, but got O
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ SYSREG+28]");
			_ = 0;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ X9_v1 (Il2CppClass<TKey>)+FC]");
			object obj3 = (nint)0 + (nint)15;
			int num2 = (int)((nint)obj3 & 0x1FFFFFFF0L);
			object obj5 = default(object);
			object obj4 = (nint)obj5 - num2;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ X9_v5 (Il2CppClass<TValue>)+FC]");
			object obj6 = (nint)0 + (nint)15;
			int num4 = (int)((nint)obj6 & 0x1FFFFFFF0L);
			object obj7 = (nint)obj5 - num4;
			object obj8 = (nint)obj5 - num4;
			_ = 0;
			nint num5 = 0;
			object obj9 = (nint)obj2 - 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v53 @ X1_v1 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			nint num6 = 0;
			object obj10 = (nint)obj2 - 36;
			object obj11 = (nint)obj2 - 32;
			object obj12 = (nint)obj2 - 12;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v76 @ X1_v4 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X29_v1-C]");
			bool result;
			if ((nint)0 != 0)
			{
				object obj13 = (nint)obj2 - 12;
				object obj14 = (nint)obj2 - 32;
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X29_v1-24]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v175 @ X1_v7 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				object objA = (IntPtr)obj7;
				obj11 = (nint)obj2 - 32;
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v230 @ X1_v9 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				object objB = (IntPtr)obj8;
				if (object.Equals(objA, objB))
				{
					result = true;
					goto IL_0226;
				}
			}
			result = false;
			goto IL_0226;
			IL_0226:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ SYSREG+28]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X29_v1-8]");
			if (num9 == 0)
			{
				return result;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EB0 (native __stack_chk_fail)");
			bool result2 = default(bool);
			return result2;
		}

		[Token(Token = "0x6000770")]
		[Address(RVA = "0x113587C", Offset = "0x113587C", Length = "0x444")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = &v1 @ X29;\n\t*([v1 @ X29-A0]) = v26;\n\t*([v1 @ X29-8]) = *([v26 @ SYSREG+28]);\n\tv37 = Il2CppClass<TKey>;\n\tv38 = Il2CppClass<TValue>;\n\tv39 = Il2CppClass<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>;\n\tv285 = *([v37 @ X8_v4 (Il2CppClass<TKey>)+FC]);\n\tv45 = *([v37 @ X8_v4 (Il2CppClass<TKey>)+FC]) + 0xF;\n\tv46 = v45 & 0x1FFFFFFF0;\n\tv47 = &v44 @ stack_-100_v1 - v46;\n\t*([v1 @ X29-50]) = v47;\n\t*([v1 @ X29-48]) = methodInfo;\n\tv51 = &v44 @ stack_-100_v1 - v46;\n\t*([v1 @ X29-58]) = v51;\n\tv55 = &v44 @ stack_-100_v1 - v46;\n\t*([v1 @ X29-90]) = v55;\n\tv57 = *([v38 @ X9_v1 (Il2CppClass<TValue>)+FC]) + 0xF;\n\tv60 = v57 & 0x1FFFFFFF0;\n\tv61 = &v44 @ stack_-100_v1 - v60;\n\t*([v1 @ X29-60]) = v61;\n\tv65 = &v44 @ stack_-100_v1 - v60;\n\t*([v1 @ X29-30]) = *([v39 @ X10_v1 (Il2CppClass<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>)+FC]);\n\t*([v1 @ X29-28]) = v65;\n\tv69 = &v44 @ stack_-100_v1 - v60;\n\t*([v1 @ X29-98]) = v69;\n\tv71 = *([v39 @ X10_v1 (Il2CppClass<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>)+FC]) + 0xF;\n\tv74 = v71 & 0x1FFFFFFF0;\n\tv270 = &v44 @ stack_-100_v1 - v74;\n\tv266 = &v44 @ stack_-100_v1 - v46;\n\tv84 = 0x1854F20(v266, 0, *([v37 @ X8_v4 (Il2CppClass<TKey>)+FC]), methodInfo, v85, v86, v87, v88, v89, v90, v91, v92, v93, v94, v95, v96);\n\tv99 = &v44 @ stack_-100_v1 - v60;\n\t*([v1 @ X29-68]) = v99;\n\t*([v1 @ X29-40]) = *([v38 @ X9_v1 (Il2CppClass<TValue>)+FC]);\n\tv103 = 0x1854F20(v99, 0, *([v38 @ X9_v1 (Il2CppClass<TValue>)+FC]), methodInfo, v85, v86, v87, v88, v89, v90, v91, v92, v93, v94, v95, v96);\n\tv104 = array == 0;\n\tif (v104) goto L_013B;\n\tv105 = arrayIndex & 0x80000000;\n\tv106 = v105 == 0;\n\tv107 = ~v106;\n\tif (v107) goto L_0147;\n\tv282 = *([v1 @ X29-48]);\n\tv340 = System.Collections.Generic.List`1<TKey>::get_Count(this.keys);\n\tv215 = v340 == 0;\n\tif (v215) goto L_0119;\n\t*([v1 @ X29-78]) = *([v37 @ X8_v4 (Il2CppClass<TKey>)+FC]);\n\t*([v1 @ X29-70]) = arrayIndex;\n\t*([v1 @ X29-88]) = arrayIndex;\n\t*([v1 @ X29-80]) = v266;\n\tv251 = &v1 @ X29 - 0xC;\nL_0067:\n\t;\n\tv288 = *([v1 @ X29-70]) + v291;\n\tv217 = v288 >= array.Length;\n\tif (v217) goto L_0119;\n\t*([v1 @ X29-38]) = v288;\n\tv500 = *([v282 @ X27_v10+20]);\n\tv501 = *([v500 @ X8_v33+C0]);\n\tv248 = &v1 @ X29 - 0x20;\n\tv502 = *([v501 @ X8_v34+98]);\n\t*([v1 @ X29-C]) = v291;\n\t*([v1 @ X29-20]) = v251;\n\t*([v1 @ X29-18]) = *([v1 @ X29-50]);\n\t*([v502 @ X1_v16+10])(v504, *([v502 @ X1_v16]), v502, this.keys, v248, *([v1 @ X29-50]), v86, v87, v88, v89, v90, v91, v92, v93, v94, v95, v96);\n\tv263 = 0x1854F10(v266, *([v1 @ X29-50]), v285, v248, *([v1 @ X29-50]), v86, v87, v88, v89, v90, v91, v92, v93, v94, v95, v96);\n\tv512 = *([v282 @ X27_v10+20]);\n\tv515 = &v1 @ X29 - 0x20;\n\tv516 = *([v512 @ X8_v36+C0]);\n\tv517 = *([v516 @ X8_v37+110]);\n\t*([v1 @ X29-C]) = v291;\n\t*([v1 @ X29-20]) = v251;\n\t*([v1 @ X29-18]) = *([v1 @ X29-60]);\n\t*([v517 @ X1_v18+10])(v520, *([v517 @ X1_v18]), v517, this.values, v515, *([v1 @ X29-60]), v86, v87, v88, v89, v90, v91, v92, v93, v94, v95, v96);\n\tv527 = 0x1854F10(*([v1 @ X29-68]), *([v1 @ X29-60]), *([v1 @ X29-40]), v515, *([v1 @ X29-60]), v86, v87, v88, v89, v90, v91, v92, v93, v94, v95, v96);\n\tv529 = *([v1 @ X29-58]);\n\tv533 = 0x1854F10(*([v1 @ X29-58]), v266, v285, v515, *([v1 @ X29-60]), v86, v87, v88, v89, v90, v91, v92, v93, v94, v95, v96);\n\tv537 = 0x1854F10(*([v1 @ X29-28]), *([v1 @ X29-68]), *([v1 @ X29-40]), v515, *([v1 @ X29-60]), v86, v87, v88, v89, v90, v91, v92, v93, v94, v95, v96);\n\tv541 = 0x1854F20(v270, 0, *([v1 @ X29-30]), v515, *([v1 @ X29-60]), v86, v87, v88, v89, v90, v91, v92, v93, v94, v95, v96);\n\tv542 = *([v282 @ X27_v10+20]);\n\tv575 = *([v542 @ X27_v12+C0]);\n\tv544 = *([v575 @ X8_v41+68]);\n\tv546 = *([v544 @ X9_v14+28]) & 0x80000000;\n\tv547 = v546 == 0;\n\tv548 = ~v547;\n\tif (v548) goto L_00BA;\n\tv378 = *([v529 @ X24_v11]);\n\tgoto L_00C0;\nL_00BA:\n\tv378 = *([v1 @ X29-90]);\n\tv554 = 0x1854F10(*([v1 @ X29-90]), *([v1 @ X29-58]), v285, v515, *([v1 @ X29-60]), v86, v87, v88, v89, v90, v91, v92, v93, v94, v95, v96);\n\tv575 = *([v542 @ X27_v12+C0]);\nL_00C0:\n\tv560 = *([v575 @ X8_v41+88]);\n\tv562 = *([v560 @ X9_v16+28]) & 0x80000000;\n\tv563 = v562 == 0;\n\tv384 = ~v563;\n\tif (v384) goto L_00CC;\n\tv564 = *([v1 @ X29-28]);\n\tv379 = *([v564 @ X9_v21]);\n\tgoto L_00D3;\nL_00CC:\n\t;\n\tv570 = 0x1854F10(*([v1 @ X29-98]), *([v1 @ X29-28]), *([v1 @ X29-40]), v515, *([v1 @ X29-60]), v86, v87, v88, v89, v90, v91, v92, v93, v94, v95, v96);\n\tv575 = *([v542 @ X27_v12+C0]);\nL_00D3:\n\t;\n\tv282 = *([v1 @ X29-48]);\n\tSystem.Collections.Generic.KeyValuePair`2<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType, Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>::.ctor(v270, v378, v379);\n\tv578 = array->klass;\n\tv289 = *([v1 @ X29-88]) + v291;\n\tv581 = *([v578 @ X8_v43 (Il2CppClass<System.Collections.Generic.KeyValuePair`2<TKey, TValue>[]>)+104]) * v289;\n\tv582 = array + v581;\n\tv583 = v582 + 0x20;\n\tv584 = 0x1854F10(v583, v270, *([v1 @ X29-30]), *([v575 @ X8_v41+1A0]), *([v1 @ X29-60]), v86, v87, v88, v89, v90, v91, v92, v93, v94, v95, v96);\n\tv585 = *([v282 @ X27_v10+20]);\n\tv266 = *([v1 @ X29-80]);\n\tv285 = *([v1 @ X29-78]);\n\tv251 = &v1 @ X29 - 0xC;\n\tv586 = *([v585 @ X8_v46+C0]);\n\tv587 = *([v586 @ X8_v47+178]);\n\tv589 = *([v587 @ X0_v63+135]) & 1;\n\tv590 = v589 == 0;\n\tv385 = ~v590;\n\tif (v385) goto L_0108;\n\tv591 = 0xB348B0(v587, v270, *([v1 @ X29-30]), *([v575 @ X8_v41+1A0]), *([v1 @ X29-60]), v86, v87, v88, v89, v90, v91, v92, v93, v94, v95, v96);\nL_0108:\n\t;\n\tv340 = System.Collections.Generic.List`1<TKey>::get_Count(this.keys);\n\tv291 = v291 + 1;\n\tv316 = v291 != v340;\n\tif (v316) goto L_0067;\nL_0119:\n\tv357 = *([v1 @ X29-A0]);\n\tv369 = *([v357 @ X8_v27+28]) != *([v1 @ X29-8]);\n\tif (v369) goto L_0163;\n\treturn;\n\tv305 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_013B:\n\tv211 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v211, \"array\");\n\tthrow v211;\nL_0147:\n\t*([v1 @ X29-20]) = arrayIndex;\n\tv306 = &v1 @ X29 - 0x20;\n\t// 332 Box v307 @ X0_v11 (System.Object), typeof(System.Int32), v306 @ X1_v5\n\tv466 = new System.ArgumentOutOfRangeException();\n\tSystem.ArgumentOutOfRangeException::.ctor(v466, \"arrayIndex\", v307, \"The index is negative or outside the bounds of the collection.\");\n\tthrow v466;\nL_0163:\n\tv465 = System.Collections.Generic.List`1<TKey>::get_Count(v340);\n\treturn;\n// 216 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		unsafe void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			//IL_003c: Expected O, but got I
			//IL_0052: Expected O, but got I
			//IL_0065: Expected I4, but got I8
			//IL_0073: Expected O, but got I
			//IL_008b: Expected O, but got I
			//IL_009e: Expected O, but got I
			//IL_00b9: Expected O, but got I
			//IL_00cc: Expected I4, but got I8
			//IL_00da: Expected O, but got I
			//IL_00ed: Expected O, but got I
			//IL_010d: Expected O, but got I
			//IL_0128: Expected O, but got I
			//IL_013b: Expected I4, but got I8
			//IL_0149: Expected O, but got I
			//IL_0157: Expected O, but got I
			//IL_016f: Expected O, but got I
			//IL_01bf: Expected I4, but got I8
			//IL_0653: Expected O, but got I
			//IL_065c: Expected I4, but got O
			//IL_01f7: Expected O, but got I
			//IL_05f1: Expected O, but got I
			//IL_0691: Expected O, but got I4
			//IL_0254: Expected O, but got I
			//IL_0727: Expected O, but got I
			//IL_0285: Expected O, but got I
			//IL_0296: Expected O, but got I
			//IL_02a5: Expected O, but got I
			//IL_02b5: Expected O, but got I
			//IL_02f7: Expected O, but got I
			//IL_0307: Expected O, but got I
			//IL_0317: Expected O, but got I
			//IL_0327: Expected O, but got I
			//IL_0366: Expected O, but got I
			//IL_03a0: Expected O, but got I
			//IL_03b0: Expected O, but got I
			//IL_03c0: Expected O, but got I
			//IL_03db: Expected I4, but got I8
			//IL_0420: Expected O, but got I
			//IL_043a: Expected O, but got I
			//IL_06a6: Expected O, but got I
			//IL_06c1: Expected I4, but got I8
			//IL_0479: Expected O, but got I
			//IL_0489: Expected O, but got I
			//IL_06fa: Expected O, but got I
			//IL_0706: Expected native int or pointer, but got O
			//IL_044f: Expected O, but got I
			//IL_0496: Expected I, but got O
			//IL_04ae: Expected O, but got I
			//IL_04c4: Expected O, but got I
			//IL_04d3: Expected O, but got I
			//IL_04e2: Expected O, but got I
			//IL_04fc: Expected O, but got I
			//IL_050c: Expected O, but got I
			//IL_051c: Expected O, but got I
			//IL_052b: Expected O, but got I
			//IL_053b: Expected O, but got I
			//IL_054b: Expected O, but got I
			object obj = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ SYSREG+28]");
			_ = 0;
			nint num = 0;
			nint num2 = 0;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X8_v4 (Il2CppClass<TKey>)+FC]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X8_v4 (Il2CppClass<TKey>)+FC]");
			object obj3 = (nint)0 + (nint)15;
			int num4 = (int)((nint)obj3 & 0x1FFFFFFF0L);
			object obj5 = default(object);
			object obj4 = (nint)obj5 - num4;
			object obj6 = (nint)obj5 - num4;
			object obj7 = (nint)obj5 - num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X9_v1 (Il2CppClass<TValue>)+FC]");
			object obj8 = (nint)0 + (nint)15;
			int num5 = (int)((nint)obj8 & 0x1FFFFFFF0L);
			object obj9 = (nint)obj5 - num5;
			object obj10 = (nint)obj5 - num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ X10_v1 (Il2CppClass<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>)+FC]");
			_ = 0;
			object obj11 = (nint)obj5 - num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ X10_v1 (Il2CppClass<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>)+FC]");
			object obj12 = (nint)0 + (nint)15;
			int num6 = (int)((nint)obj12 & 0x1FFFFFFF0L);
			object obj13 = (nint)obj5 - num6;
			object obj14 = (nint)obj5 - num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F20 (native memset)");
			object obj15 = (nint)obj5 - num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X9_v1 (Il2CppClass<TValue>)+FC]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F20 (native memset)");
			if (array != null)
			{
				if ((int)(arrayIndex & 0x80000000L) == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-48]");
					object obj16 = 0;
					int num7 = keys.Count;
					if (num7 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X8_v4 (Il2CppClass<TKey>)+FC]");
						_ = 0;
						object obj17 = (nint)obj - 12;
						int num8 = num7;
						int num9 = 0;
						bool flag2;
						do
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-70]");
							object obj18 = (nint)0 + (nint)num9;
							bool flag = (nint)obj18 >= array.Length;
							num7 = num8;
							if (flag)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ X27_v10+20]");
							object obj19 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v500 @ X8_v33+C0]");
							object obj20 = 0;
							object obj21 = (nint)obj - 32;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v501 @ X8_v34+98]");
							object obj22 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-50]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v502 @ X1_v16+10] (should have been resolved before IL gen)");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ X27_v10+20]");
							object obj23 = 0;
							object obj24 = (nint)obj - 32;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v512 @ X8_v36+C0]");
							object obj25 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v516 @ X8_v37+110]");
							object obj26 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-60]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v517 @ X1_v18+10] (should have been resolved before IL gen)");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-58]");
							object obj27 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F20 (native memset)");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ X27_v10+20]");
							object obj28 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v542 @ X27_v12+C0]");
							object obj29 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v575 @ X8_v41+68]");
							object obj30 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v544 @ X9_v14+28]");
							global::Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType key;
							if (0 == 0)
							{
								key = (global::Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType)obj27;
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-90]");
								key = (global::Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v542 @ X27_v12+C0]");
								obj29 = 0;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v575 @ X8_v41+88]");
							object obj31 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v560 @ X9_v16+28]");
							global::Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType value;
							if (0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-28]");
								object obj32 = 0;
								value = (global::Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType)obj32;
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v542 @ X27_v12+C0]");
								obj29 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-98]");
								value = (global::Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType)0;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-48]");
							obj16 = 0;
							*(KeyValuePair<global::Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType, global::Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>*)(nint)obj13 = new KeyValuePair<global::Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType, global::Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>(key, value);
							nint num10 = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-88]");
							object obj33 = (nint)0 + (nint)num9;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v578 @ X8_v43 (Il2CppClass<System.Collections.Generic.KeyValuePair`2<TKey, TValue>[]>)+104]");
							object obj34 = 0 * (nint)obj33;
							object obj35 = (nint)array + (nint)obj34;
							object obj36 = (nint)obj35 + 32;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ X27_v10+20]");
							object obj37 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-80]");
							obj14 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-78]");
							obj2 = 0;
							obj17 = (nint)obj - 12;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v585 @ X8_v46+C0]");
							object obj38 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ X8_v47+178]");
							object obj39 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v587 @ X0_v63+135]");
							if ((int)((nint)0 & (nint)1) == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @B348B0");
							}
							num7 = keys.Count;
							num9++;
							flag2 = num9 != num7;
							num8 = num7;
						}
						while (flag2);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-A0]");
					object obj40 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v357 @ X8_v27+28]");
					nint num11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ X29-8]");
					if (num11 != 0)
					{
						int count = ((List<TKey>)num7).Count;
					}
					return;
				}
				object obj41 = (nint)obj - 32;
				object actualValue = (int)obj41;
				ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("arrayIndex", actualValue, "The index is negative or outside the bounds of the collection.");
				throw ex;
			}
			ArgumentNullException ex2 = new ArgumentNullException("array");
			throw ex2;
		}

		[Token(Token = "0x6000772")]
		[Address(RVA = "0x1135CC8", Offset = "0x1135CC8", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = &v19 @ stack_-50_v2;\n\t*([v18 @ X29_v1-8]) = *([v21 @ SYSREG+28]);\n\tv31 = Il2CppClass<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>;\n\tv32 = Il2CppClass<TKey>;\n\tv37 = *([v32 @ X8_v3 (Il2CppClass<TKey>)+FC]) + 0xF;\n\tv38 = v37 & 0x1FFFFFFF0;\n\tv270 = &v36 @ stack_-70_v1 - v38;\n\tv41 = *([v31 @ X9_v1 (Il2CppClass<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>)+FC]) + 0xF;\n\tv44 = v41 & 0x1FFFFFFF0;\n\tv45 = &v36 @ stack_-70_v1 - v44;\n\tv48 = 0x1854F10(v45, v118, *([v31 @ X9_v1 (Il2CppClass<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>)+FC]), v83, v81, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\n\tgoto L_0030;\n\tv70 = v64;\n\tv71 = 0xB348B0(v70, v64, v33, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv73 = v71;\nL_0030:\n\tv75 = this->klass;\n\tv173 = this->klass->interface_offsets_count;\n\tv77 = *([v75 @ X8_v11 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>>)+12E]) == 0;\n\tif (v77) goto L_0050;\n\tv172 = *([v75 @ X8_v11 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>>)+B0]) + 8;\nL_003B:\n\tv178 = *([v172 @ X10_v6-8]) == Il2CppClass<System.Collections.Generic.ICollection`1<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>>;\n\tif (v178) goto L_0053;\n\tv158 = v173 - 1;\n\tv172 = v172 + 0x10;\n\tv138 = v173 != 1;\n\tif (v138) goto L_003B;\nL_0050:\n\tv237 = 0xB349B4(this, Il2CppClass<System.Collections.Generic.ICollection`1<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>>, 4, v83, v81, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\n\tgoto L_0057;\nL_0053:\n\tv224 = *([v172 @ X10_v6]) + 4;\n\tv225 = v224 << 4;\n\tv226 = v75 + v225;\n\tv237 = v226 + 0x138;\nL_0057:\n\t*([v18 @ X29_v1-18]) = v45;\n\tv119 = *([v237 @ X0_v7+8]);\n\tv84 = &v19 @ stack_-50_v2 - 0x18;\n\tv82 = &v19 @ stack_-50_v2 - 0xC;\n\t*([v119 @ X1_v5 (Il2CppMethodInfo)+10])(v247, *([v119 @ X1_v5 (Il2CppMethodInfo)+8]), *([v237 @ X0_v7+8]), this, v84, v82, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv249 = *([v18 @ X29_v1-C]) == 0;\n\tif (v249) goto L_FFFFFFFF;\n\tv251 = &v19 @ stack_-50_v2 - 0x18;\n\tv255 = Il2CppMethodInfo;\n\t*([v18 @ X29_v1-18]) = v270;\n\t*([v255 @ X1_v6 (Il2CppMethodInfo)+10])(v258, *([v255 @ X1_v6 (Il2CppMethodInfo)]), Il2CppMethodInfo, v118, v251, v270, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv262 = Il2CppMethodInfo;\n\tgoto L_0077;\n\tv269 = *([v39 @ X21_v1]);\nL_0077:\n\t*([v18 @ X29_v1-18]) = v270;\n\tv84 = &v19 @ stack_-50_v2 - 0x18;\n\tv82 = &v19 @ stack_-50_v2 - 0xC;\n\t*([v262 @ X1_v7 (Il2CppMethodInfo)+10])(v275, *([v262 @ X1_v7 (Il2CppMethodInfo)]), Il2CppMethodInfo, this, v84, v82, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv281 = *([v18 @ X29_v1-C]) == 0;\n\tv286 = ~v281;\n\tgoto L_0096;\nL_0096:\n\tv90 = *([v21 @ SYSREG+28]) != *([v18 @ X29_v1-8]);\n\tif (v90) goto L_00A5;\n\treturn returnVal2;\n\tv69 = new System.NullReferenceException();\nL_00A5:\n\treturnVal1 = 0x1854EB0(v120, v118, *([v31 @ X9_v1 (Il2CppClass<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>)+FC]), v83, v81, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\n\treturn returnVal1;\n// 108 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
		{
			//IL_0037: Expected O, but got I
			//IL_004a: Expected I4, but got I8
			//IL_0058: Expected O, but got I
			//IL_006e: Expected O, but got I
			//IL_0081: Expected I4, but got I8
			//IL_008f: Expected O, but got I
			//IL_01a8: Expected I, but got O
			//IL_01b8: Expected O, but got I
			//IL_0223: Expected O, but got I
			//IL_0232: Expected O, but got I
			//IL_00b9: Expected O, but got I
			//IL_0161: Expected O, but got I
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0121: Expected O, but got Unknown
			//IL_013e: Expected O, but got I
			//IL_014d: Expected O, but got I
			//IL_0275: Expected O, but got I
			//IL_0284: Expected O, but got I
			//IL_00cd: Expected O, but got I
			//IL_00dc: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ SYSREG+28]");
			_ = 0;
			nint num = 0;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X8_v3 (Il2CppClass<TKey>)+FC]");
			object obj3 = (nint)0 + (nint)15;
			int num3 = (int)((nint)obj3 & 0x1FFFFFFF0L);
			object obj5 = default(object);
			object obj4 = (nint)obj5 - num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ X9_v1 (Il2CppClass<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>)+FC]");
			object obj6 = (nint)0 + (nint)15;
			int num4 = (int)((nint)obj6 & 0x1FFFFFFF0L);
			object obj7 = (nint)obj5 - num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
			nint num5 = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X8_v11 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>>)+12E]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X8_v11 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>>)+12E]");
			if ((nint)0 == 0)
			{
				goto IL_0104;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X8_v11 (Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TValue>>)+B0]");
			object obj9 = (nint)0 + (nint)8;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ X10_v6-8]");
				if ((nint)0 == 0)
				{
					break;
				}
				object obj10 = (nint)obj8 - 1;
				obj9 = (nint)obj9 + 16;
				bool flag = (nint)obj8 != 1;
				obj8 = obj10;
				if (flag)
				{
					continue;
				}
				goto IL_0104;
			}
			object obj11 = obj9 + 4;
			int num6 = (int)((nint)obj11 << 4);
			object obj12 = num5 + num6;
			object obj13 = (nint)obj12 + 312;
			goto IL_01ff;
			IL_0104:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @B349B4");
			goto IL_01ff;
			IL_01ff:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ X0_v7+8]");
			nint num7 = 0;
			object obj14 = (nint)obj2 - 24;
			object obj15 = (nint)obj2 - 12;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v119 @ X1_v5 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ X29_v1-C]");
			bool result;
			if ((nint)0 != 0)
			{
				object obj16 = (nint)obj2 - 24;
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v255 @ X1_v6 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				nint num9 = 0;
				obj14 = (nint)obj2 - 24;
				obj15 = (nint)obj2 - 12;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v262 @ X1_v7 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ X29_v1-C]");
				bool flag2 = (nint)0 == 0;
				bool flag3 = !flag2;
				num7 = 0;
				result = flag3;
			}
			else
			{
				result = false;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ SYSREG+28]");
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ X29_v1-8]");
			if (num10 == 0)
			{
				return result;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EB0 (native __stack_chk_fail)");
			bool result2 = default(bool);
			return result2;
		}

		[Token(Token = "0x6000773")]
		[Address(RVA = "0x1135E7C", Offset = "0x1135E7C", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = Il2CppMethodInfo;\n\tv4 = *([v3 @ X1_v1 (Il2CppMethodInfo)]);\n\t// 4 IndirectJump v4 @ X2_v1, this @ X0 (Spine.Collections.OrderedDictionary`2<TKey, TValue>), this @ X0 (Spine.Collections.OrderedDictionary`2<TKey, TValue>), methodof(Spine.Collections.OrderedDictionary`2<TKey, TValue>::GetEnumerator), v4 @ X2_v1, v6 @ X3, v7 @ X4, v8 @ X5, v9 @ X6, v10 @ X7, v11 @ V0, v12 @ V1, v13 @ V2, v14 @ V3, v15 @ V4, v16 @ V5, v17 @ V6, v18 @ V7\n\treturn X0;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		IEnumerator IEnumerable.GetEnumerator()
		{
			//IL_000e: Expected O, but got I
			nint num = 0;
			object obj = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ X2_v1 (should have been resolved before IL gen)");
			return null;
		}
	}
}
