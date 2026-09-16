using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal
{
	[Serializable]
	[Token(Token = "0x20000BF")]
	public class SerializableKeyValuePair<K, V>
	{
		[SerializeField]
		[Token(Token = "0x40003A6")]
		[FieldOffset(Offset = "0x0")]
		private K key;

		[SerializeField]
		[Token(Token = "0x40003A7")]
		[FieldOffset(Offset = "0x0")]
		private V value;

		[Token(Token = "0x17000222")]
		public K Key
		{
			[Token(Token = "0x60006FF")]
			[Address(RVA = "0xD8FA64", Offset = "0xD8FA64", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.key;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Key;
			}
			[Token(Token = "0x6000700")]
			[Address(RVA = "0xD8FA6C", Offset = "0xD8FA6C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.key = value;\n\treturn;\n")]
			set
			{
				Key = value;
			}
		}

		[Token(Token = "0x17000223")]
		public V Value
		{
			[Token(Token = "0x6000701")]
			[Address(RVA = "0xD8FA74", Offset = "0xD8FA74", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.value;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Value;
			}
			[Token(Token = "0x6000702")]
			[Address(RVA = "0xD8FA7C", Offset = "0xD8FA7C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.value = value;\n\treturn;\n")]
			set
			{
				Value = value;
			}
		}

		[Token(Token = "0x60006FD")]
		[Address(RVA = "0xD8F9DC", Offset = "0xD8F9DC", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.key = key;\n\tthis.value = value;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SerializableKeyValuePair(K key, V value)
		{
			Key = key;
			Value = value;
		}

		[Token(Token = "0x60006FE")]
		[Address(RVA = "0xD8FA20", Offset = "0xD8FA20", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.key = pair;\n\tthis.value = methodInfo;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SerializableKeyValuePair(KeyValuePair<K, V> pair)
		{
			//IL_001a: Expected O, but got I
			base._002Ector();
			Key = (K)pair;
			IntPtr intPtr = default(IntPtr);
			Value = (V)(long)intPtr;
		}

		[Token(Token = "0x6000703")]
		[Address(RVA = "0xD8FA84", Offset = "0xD8FA84", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = System.Collections.Generic.KeyValuePair`2<K, V>::.ctor(&v14 @ stack_-20_v2 (System.Collections.Generic.KeyValuePair`2<K, V>), this.key, this.value);\n\treturn v14;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public KeyValuePair<K, V> ToKeyValuePair()
		{
			return new KeyValuePair<K, V>(Key, Value);
		}

		[Token(Token = "0x6000704")]
		[Address(RVA = "0xD8FAC0", Offset = "0xD8FAC0", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv68 = *([v19 @ X2+18]);\n\tv48 = *([v68 @ X22_v9+12E]);\n\tv26 = *([v68 @ X22_v9+12E]) & 1;\n\tv27 = v26 == 0;\n\tif (v27) goto L_004D;\n\tv28 = v48 & 1;\n\tv29 = v28 == 0;\n\tif (v29) goto L_0055;\nL_0015:\n\tv52 = v48 & 1;\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_001B;\nL_001A:\n\tv71 = 0x8907BC(v68, methodInfo, v19, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_001B:\n\tv76 = *([v75 @ X22_v5+C0]);\n\tv77 = *([v76 @ X8_v6+20]);\n\tv79 = *([v77 @ X22_v6+12E]) & 1;\n\tv80 = v79 == 0;\n\tv81 = ~v80;\n\tif (v81) goto L_0025;\n\tv84 = 0x8907BC(v77, methodInfo, v19, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0025:\n\tv87 = new v77();\n\tv88 = *([v19 @ X2+18]);\n\tv100 = *([v88 @ X24_v1+12E]);\n\tv92 = *([v88 @ X24_v1+12E]) & 1;\n\tv93 = v92 == 0;\n\tv94 = ~v93;\n\tif (v94) goto L_0032;\n\tv96 = 0x8907BC(v88, methodInfo, v19, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv97 = *([v19 @ X2+18]);\n\tv100 = *([v97 @ X23_v2+12E]);\nL_0032:\n\tv102 = *([v88 @ X24_v1+C0]);\n\tv103 = *([v102 @ X9_v1+28]);\n\tv105 = v100 & 1;\n\tv106 = v105 == 0;\n\tv107 = ~v106;\n\tif (v107) goto L_003B;\n\tv109 = 0x8907BC(v97, methodInfo, v19, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_003B:\n\tv111 = *([v97 @ X23_v2+C0]);\n\t*([v103 @ X9_v2])(v116, v87, pair, methodInfo, *([v111 @ X8_v10+28]), v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\treturn v87;\nL_004D:\n\tv31 = 0x8907BC(v68, methodInfo, v19, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv68 = *([v19 @ X2+18]);\n\tv48 = *([v68 @ X22_v9+12E]);\n\tv61 = *([v68 @ X22_v9+12E]) & 1;\n\tv62 = v61 == 0;\n\tv47 = ~v62;\n\tif (v47) goto L_0015;\nL_0055:\n\tv60 = 0x8907BC(v58, methodInfo, v19, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv68 = *([v19 @ X2+18]);\n\tv82 = *([v68 @ X22_v9+12E]) & 1;\n\tv65 = v82 == 0;\n\tif (v65) goto L_001A;\n\tgoto L_001B;\n\treturn X0;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static SerializableKeyValuePair<K, V> FromKeyValuePair(KeyValuePair<K, V> pair)
		{
			//IL_0010: Expected O, but got I
			//IL_0020: Expected O, but got I
			//IL_022c: Expected O, but got I
			//IL_023c: Expected O, but got I
			//IL_00ed: Expected O, but got I
			//IL_00fd: Expected O, but got I
			//IL_029c: Expected O, but got I
			//IL_015f: Expected O, but got I
			//IL_016f: Expected O, but got I
			//IL_02ec: Expected O, but got I
			//IL_02fc: Expected O, but got I
			//IL_0203: Expected O, but got I
			//IL_01cf: Expected O, but got I
			//IL_01df: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X2+18]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ X22_v9+12E]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ X22_v9+12E]");
			if (0u != 0)
			{
				int num = (int)((long)(IntPtr)obj2 & 1L);
				bool flag = num == 0;
				object obj3 = obj;
				if (!flag)
				{
					goto IL_0087;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8907BC");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X2+18]");
				obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ X22_v9+12E]");
				obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ X22_v9+12E]");
				int num2 = 0;
				bool flag2 = num2 == 0;
				bool flag3 = !flag2;
				object obj3 = obj;
				if (flag3)
				{
					goto IL_0087;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8907BC");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X2+18]");
			obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ X22_v9+12E]");
			if (0 == 0)
			{
				goto IL_00c6;
			}
			object obj4 = obj;
			goto IL_00dd;
			IL_00c6:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8907BC");
			obj4 = obj;
			goto IL_00dd;
			IL_0087:
			int num3 = (int)((long)(IntPtr)obj2 & 1L);
			bool flag4 = num3 == 0;
			bool flag5 = !flag4;
			obj4 = obj;
			if (!flag5)
			{
				goto IL_00c6;
			}
			goto IL_00dd;
			IL_00dd:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X22_v5+C0]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ X8_v6+20]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ X22_v6+12E]");
			if (0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8907BC");
			}
			SerializableKeyValuePair<K, V> result = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X2+18]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ X24_v1+12E]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ X24_v1+12E]");
			int num4 = 0;
			bool flag6 = num4 == 0;
			bool flag7 = !flag6;
			object obj9 = obj7;
			if (!flag7)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8907BC");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X2+18]");
				obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ X23_v2+12E]");
				obj8 = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ X24_v1+C0]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ X9_v1+28]");
			object obj11 = 0;
			if ((int)((long)(IntPtr)obj8 & 1L) == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8907BC");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ X23_v2+C0]");
			object obj12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v103 @ X9_v2] (should have been resolved before IL gen)");
			return result;
		}
	}
}
