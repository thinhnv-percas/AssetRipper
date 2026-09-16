using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace LunarConsolePluginInternal
{
	[Token(Token = "0x2000029")]
	internal class Iterator<T>
	{
		[Token(Token = "0x400007B")]
		[FieldOffset(Offset = "0x0")]
		private IList<T> m_target;

		[Token(Token = "0x400007C")]
		[FieldOffset(Offset = "0x0")]
		private int m_current;

		[Token(Token = "0x1700002D")]
		public int Count
		{
			[Token(Token = "0x6000113")]
			[Address(RVA = "0xD96198", Offset = "0xD96198", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.m_target;\n\tgoto L_0013;\n\tv37 = v16;\n\tv38 = 0x8907BC(v37, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0013:\n\tv40 = *([v10 @ X19_v1 (System.Collections.Generic.IList`1<T>)]);\n\tv42 = *([v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]) == 0;\n\tif (v42) goto L_0035;\n\tv145 = *([v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\nL_001F:\n\tv150 = *([v145 @ X11_v5-8]) == Il2CppClass<System.Collections.Generic.ICollection`1<T>>;\n\tif (v150) goto L_0038;\n\tv144 = v144 + 1;\n\tv155 = v144 < *([v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]);\n\tv74 = ~v155;\n\tv145 = v145 + 0x10;\n\tv50 = ~v74;\n\tif (v50) goto L_001F;\nL_0035:\n\tv162 = 0x8909C4(v10, Il2CppClass<System.Collections.Generic.ICollection`1<T>>, 0, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tgoto L_003B;\nL_0038:\n\tv157 = *([v145 @ X11_v5]) << 4;\n\tv158 = v40 + v157;\n\tv162 = v158 + 0x130;\nL_003B:\n\tv94 = *([v162 @ X0_v4]);\n\tv96 = *([v162 @ X0_v4+8]);\n\t// 67 IndirectJump v94 @ X2_v2, v10 @ X19_v1 (System.Collections.Generic.IList`1<T>), v10 @ X19_v1 (System.Collections.Generic.IList`1<T>), v96 @ X1_v2, v94 @ X2_v2, v24 @ X3, v25 @ X4, v26 @ X5, v27 @ X6, v28 @ X7, v29 @ V0, v30 @ V1, v31 @ V2, v32 @ V3, v33 @ V4, v34 @ V5, v35 @ V6, v36 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_001c: Expected I, but got O
				//IL_013a: Expected O, but got I
				//IL_0057: Expected O, but got I
				//IL_00de: Expected I4, but got O
				//IL_00ec: Expected O, but got I
				//IL_00fb: Expected O, but got I
				//IL_00a3: Expected O, but got I
				IList<T> target = m_target;
				IntPtr intPtr = (IntPtr)target;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00bc;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00bc;
				}
				int num3 = obj << 4;
				object obj2 = (long)intPtr + (long)num3;
				object obj3 = (long)(IntPtr)obj2 + 304L;
				goto IL_0122;
				IL_00bc:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0122;
				IL_0122:
				object obj4 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ X0_v4+8]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v94 @ X2_v2 (should have been resolved before IL gen)");
				return 0;
			}
		}

		[Token(Token = "0x1700002E")]
		public int Position
		{
			[Token(Token = "0x6000114")]
			[Address(RVA = "0xD96238", Offset = "0xD96238", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Position;
			}
			[Token(Token = "0x6000115")]
			[Address(RVA = "0xD96240", Offset = "0xD96240", Length = "0x104")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EFD3C8]);\n\tv27 = *([v26 @ X8_v20]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, value, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20240D3]) = v44;\nL_0017:\n\tv45 = value + 1;\n\tv46 = v45 < 0;\n\tv50 = v46 == 0;\n\tv51 = ~v50;\n\tif (v51) goto L_0042;\n\tv78 = LunarConsolePluginInternal.Iterator`1<T>::get_Count(this);\n\tv54 = v78 <= value;\n\tif (v54) goto L_0042;\n\tthis.m_current = value;\n\treturn;\nL_0042:\n\t// 66 Box v87 @ X0_v7 (System.Object), typeof(System.Int32), &value @ X1 (System.Int32)\n\tv126 = System.String::Concat(\"Invalid position: \", v87);\n\tv137 = new System.IndexOutOfRangeException();\n\tSystem.IndexOutOfRangeException::.ctor(v137, v126);\n\tthrow v137;\n\tthrow System.NullReferenceException;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				int num = value + 1;
				if (num >= 0)
				{
					int count = Count;
					if (count > value)
					{
						m_current = value;
						return;
					}
				}
				object obj = value;
				string message = "Invalid position: " + obj;
				IndexOutOfRangeException ex = new IndexOutOfRangeException(message);
				throw ex;
			}
		}

		[Token(Token = "0x6000109")]
		[Address(RVA = "0xD95EA0", Offset = "0xD95EA0", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tv43 = Il2CppMethodInfo;\n\tv44 = *([v43 @ X2_v1 (Il2CppMethodInfo)]);\n\t// 27 IndirectJump v44 @ X3_v1, this @ X0 (LunarConsolePluginInternal.Iterator`1<T>), this @ X0 (LunarConsolePluginInternal.Iterator`1<T>), target @ X1 (System.Collections.Generic.IList`1<T>), methodof(LunarConsolePluginInternal.Iterator`1<T>::Init), v44 @ X3_v1, v23 @ X4, v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Iterator(IList<T> target)
		{
			//IL_0014: Expected O, but got I
			base._002Ector();
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v44 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600010A")]
		[Address(RVA = "0xD95EF8", Offset = "0xD95EF8", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1F0DB50]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, target, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20240D2]) = v41;\nL_0015:\n\tv42 = target == 0;\n\tif (v42) goto L_0024;\n\tthis.m_target = target;\n\tthis.m_current = 0xFFFFFFFF;\n\treturn;\nL_0024:\n\tv52 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v52, \"target\");\n\tthrow v52;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Init(IList<T> target)
		{
			if (target != null)
			{
				m_target = target;
				m_current = -1;
				return;
			}
			ArgumentNullException ex = new ArgumentNullException("target");
			throw ex;
		}

		[Token(Token = "0x600010B")]
		[Address(RVA = "0xD95F94", Offset = "0xD95F94", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = LunarConsolePluginInternal.Iterator`1<T>::get_Count(this);\n\tv36 = this.m_current + items;\n\tv39 = v36 - v20;\n\tv40 = v39 < 0;\n\tv42 = v36 ^ v20;\n\tv43 = v36 ^ v39;\n\tv44 = v42 & v43;\n\tv45 = v44 < 0;\n\tv46 = v40 == v45;\n\tv47 = ~v46;\n\treturn v47;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool HasNext(int items = 1)
		{
			int count = Count;
			int num = Position + items;
			int num2 = num - count;
			bool flag = num2 < 0;
			int num3 = num ^ count;
			int num4 = num ^ num2;
			int num5 = num3 & num4;
			bool flag2 = num5 < 0;
			bool flag3 = flag == flag2;
			return !flag3;
		}

		[Token(Token = "0x600010C")]
		[Address(RVA = "0xD95FDC", Offset = "0xD95FDC", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.m_current - items;\n\tv4 = v2 >> 0x1F;\n\treturnVal1 = v4 ^ 1;\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool HasPrev(int items = 1)
		{
			int num = Position - items;
			int num2 = num >> 31;
			return (byte)(num2 ^ 1) != 0;
		}

		[Token(Token = "0x600010D")]
		[Address(RVA = "0xD95FF0", Offset = "0xD95FF0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.m_current + items;\n\tthis.m_current = v2;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Skip(int items = 1)
		{
			int current = Position + items;
			m_current = current;
		}

		[Token(Token = "0x600010E")]
		[Address(RVA = "0xD96000", Offset = "0xD96000", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = LunarConsolePluginInternal.Iterator`1<T>::HasNext(this, items);\n\tv40 = v25 == 0;\n\tif (v40) goto L_FFFFFFFF;\n\tv48 = LunarConsolePluginInternal.Iterator`1<T>::Skip(this, items);\n\tgoto L_0026;\nL_0026:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool TrySkip(int items = 1)
		{
			if (HasNext(items))
			{
				Skip(items);
				return true;
			}
			return false;
		}

		[Token(Token = "0x600010F")]
		[Address(RVA = "0xD9607C", Offset = "0xD9607C", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.m_target;\n\tv17 = this.m_current;\n\tgoto L_0015;\n\tv40 = v19;\n\tv41 = 0x8907BC(v40, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0015:\n\tv43 = *([v12 @ X19_v1 (System.Collections.Generic.IList`1<T>)]);\n\tv45 = *([v43 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]) == 0;\n\tif (v45) goto L_0037;\n\tv152 = *([v43 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\nL_0021:\n\tv157 = *([v152 @ X11_v5-8]) == Il2CppClass<System.Collections.Generic.IList`1<T>>;\n\tif (v157) goto L_003A;\n\tv151 = v151 + 1;\n\tv162 = v151 < *([v43 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]);\n\tv77 = ~v162;\n\tv152 = v152 + 0x10;\n\tv53 = ~v77;\n\tif (v53) goto L_0021;\nL_0037:\n\tv169 = 0x8909C4(v12, Il2CppClass<System.Collections.Generic.IList`1<T>>, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_003D;\nL_003A:\n\tv164 = *([v152 @ X11_v5]) << 4;\n\tv165 = v43 + v164;\n\tv169 = v165 + 0x130;\nL_003D:\n\tv92 = *([v169 @ X0_v4]);\n\tv99 = *([v169 @ X0_v4+8]);\n\t// 71 IndirectJump v92 @ X3_v1, v12 @ X19_v1 (System.Collections.Generic.IList`1<T>), v12 @ X19_v1 (System.Collections.Generic.IList`1<T>), v17 @ X20_v1 (System.Int32), v99 @ X2_v2, v92 @ X3_v1, v28 @ X4, v29 @ X5, v30 @ X6, v31 @ X7, v32 @ V0, v33 @ V1, v34 @ V2, v35 @ V3, v36 @ V4, v37 @ V5, v38 @ V6, v39 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public T Current()
		{
			//IL_0026: Expected I, but got O
			//IL_0144: Expected O, but got I
			//IL_0061: Expected O, but got I
			//IL_00e8: Expected I4, but got O
			//IL_00f6: Expected O, but got I
			//IL_0105: Expected O, but got I
			//IL_00ad: Expected O, but got I
			IList<T> target = m_target;
			int position = Position;
			IntPtr intPtr = (IntPtr)target;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00c6;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00c6;
			}
			int num3 = obj << 4;
			object obj2 = (long)intPtr + (long)num3;
			object obj3 = (long)(IntPtr)obj2 + 304L;
			goto IL_012c;
			IL_00c6:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_012c;
			IL_012c:
			object obj4 = obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ X0_v4+8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v92 @ X3_v1 (should have been resolved before IL gen)");
			return (T)null;
		}

		[Token(Token = "0x6000110")]
		[Address(RVA = "0xD9612C", Offset = "0xD9612C", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.m_current + 1;\n\tthis.m_current = v2;\n\tv7 = Il2CppMethodInfo;\n\tv8 = *([v7 @ X1_v1 (Il2CppMethodInfo)]);\n\t// 9 IndirectJump v8 @ X2_v1, this @ X0 (LunarConsolePluginInternal.Iterator`1<T>), this @ X0 (LunarConsolePluginInternal.Iterator`1<T>), methodof(LunarConsolePluginInternal.Iterator`1<T>::Current), v8 @ X2_v1, v9 @ X3, v10 @ X4, v11 @ X5, v12 @ X6, v13 @ X7, v14 @ V0, v15 @ V1, v16 @ V2, v17 @ V3, v18 @ V4, v19 @ V5, v20 @ V6, v21 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public T Next()
		{
			//IL_002d: Expected O, but got I
			int current = Position + 1;
			m_current = current;
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v8 @ X2_v1 (should have been resolved before IL gen)");
			return (T)null;
		}

		[Token(Token = "0x6000111")]
		[Address(RVA = "0xD9615C", Offset = "0xD9615C", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.m_current - 1;\n\tthis.m_current = v2;\n\tv7 = Il2CppMethodInfo;\n\tv8 = *([v7 @ X1_v1 (Il2CppMethodInfo)]);\n\t// 9 IndirectJump v8 @ X2_v1, this @ X0 (LunarConsolePluginInternal.Iterator`1<T>), this @ X0 (LunarConsolePluginInternal.Iterator`1<T>), methodof(LunarConsolePluginInternal.Iterator`1<T>::Current), v8 @ X2_v1, v9 @ X3, v10 @ X4, v11 @ X5, v12 @ X6, v13 @ X7, v14 @ V0, v15 @ V1, v16 @ V2, v17 @ V3, v18 @ V4, v19 @ V5, v20 @ V6, v21 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public T Prev()
		{
			//IL_002d: Expected O, but got I
			int current = Position - 1;
			m_current = current;
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v8 @ X2_v1 (should have been resolved before IL gen)");
			return (T)null;
		}

		[Token(Token = "0x6000112")]
		[Address(RVA = "0xD9618C", Offset = "0xD9618C", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_current = 0xFFFFFFFF;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Reset()
		{
			m_current = -1;
		}
	}
}
