using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace LunarConsolePluginInternal
{
	[Token(Token = "0x2000025")]
	internal abstract class BaseList<T> where T : class
	{
		[Token(Token = "0x4000076")]
		[FieldOffset(Offset = "0x0")]
		protected internal readonly List<T> list;

		[Token(Token = "0x4000077")]
		[FieldOffset(Offset = "0x0")]
		private readonly T nullElement;

		[Token(Token = "0x4000078")]
		[FieldOffset(Offset = "0x0")]
		private int removedCount;

		[Token(Token = "0x4000079")]
		[FieldOffset(Offset = "0x0")]
		private bool locked;

		[Token(Token = "0x1700002C")]
		public virtual int Count
		{
			[Token(Token = "0x60000F3")]
			[Address(RVA = "0xD95E10", Offset = "0xD95E10", Length = "0x44")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = System.Collections.Generic.List`1<T>::get_Count(this.list);\n\treturnVal1 = v17 - this.removedCount;\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				int count = list.Count;
				return count - removedCount;
			}
		}

		[Token(Token = "0x60000E8")]
		[Address(RVA = "0xD958E0", Offset = "0xD958E0", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = Il2CppMethodInfo;\n\tv7 = *([v6 @ X3_v1 (Il2CppMethodInfo)]);\n\t// 7 IndirectJump v7 @ X4_v1, this @ X0 (LunarConsolePluginInternal.BaseList`1<T>), this @ X0 (LunarConsolePluginInternal.BaseList`1<T>), nullElement @ X1 (T), 0, methodof(LunarConsolePluginInternal.BaseList`1<T>::.ctor), v7 @ X4_v1, v9 @ X5, v10 @ X6, v11 @ X7, v12 @ V0, v13 @ V1, v14 @ V2, v15 @ V3, v16 @ V4, v17 @ V5, v18 @ V6, v19 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected BaseList(T nullElement)
		{
			//IL_000e: Expected O, but got I
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v7 @ X4_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60000E9")]
		[Address(RVA = "0xD95908", Offset = "0xD95908", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv30 = *([1EA8DB0]);\n\tv31 = *([v30 @ X8_v21]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, nullElement, capacity, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20240D0]) = v47;\nL_0020:\n\tgoto L_0024;\n\tv55 = v50;\n\tv56 = 0x8907BC(v55, nullElement, capacity, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0024:\n\tv59 = new Il2CppClass<System.Collections.Generic.List`1<T>>();\n\tv66 = System.Collections.Generic.List`1<T>::.ctor(v59, capacity);\n\tv75 = LunarConsolePluginInternal.BaseList`1<T>::.ctor(this, v59, nullElement);\n\tv76 = nullElement == 0;\n\tif (v76) goto L_0046;\n\treturn;\n\tthrow System.NullReferenceException;\nL_0046:\n\tv95 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v95, \"nullElement\");\n\tthrow v95;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal BaseList(T nullElement, int capacity)
		{
			List<T> list = new List<T>(capacity);
			if (nullElement != null)
			{
				return;
			}
			ArgumentNullException ex = new ArgumentNullException("nullElement");
			throw ex;
		}

		[Token(Token = "0x60000EA")]
		[Address(RVA = "0xD95A14", Offset = "0xD95A14", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.list = list;\n\tthis.nullElement = nullElement;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected BaseList(List<T> list, T nullElement)
		{
			this.list = list;
			this.nullElement = nullElement;
		}

		[Token(Token = "0x60000EB")]
		[Address(RVA = "0xD95A58", Offset = "0xD95A58", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EEA4E0]);\n\tv27 = *([v26 @ X8_v15]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, e, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20240D1]) = v44;\nL_0017:\n\tv45 = e == 0;\n\tif (v45) goto L_002E;\n\tv57 = System.Collections.Generic.List`1<T>::Add(this.list, e);\n\treturn 1;\nL_002E:\n\tv51 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v51, \"e\");\n\tthrow v51;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual bool Add(T e)
		{
			if (e != null)
			{
				list.Add(e);
				return true;
			}
			ArgumentNullException ex = new ArgumentNullException("e");
			throw ex;
		}

		[Token(Token = "0x60000EC")]
		[Address(RVA = "0xD95B14", Offset = "0xD95B14", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = System.Collections.Generic.List`1<T>::IndexOf(this.list, e);\n\tv33 = v17 + 1;\n\tv35 = v33 == 0;\n\tif (v35) goto L_FFFFFFFF;\n\tv44 = LunarConsolePluginInternal.BaseList`1::RemoveAt(this, v17);\n\tgoto L_0022;\nL_0022:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual bool Remove(T e)
		{
			int num = list.IndexOf(e);
			if (num + 1 != 0)
			{
				((BaseList<>)(object)this).RemoveAt(num);
				return true;
			}
			return false;
		}

		[Token(Token = "0x60000ED")]
		[Address(RVA = "0xD95B7C", Offset = "0xD95B7C", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.list;\n\tv6 = Il2CppMethodInfo;\n\tv7 = *([v6 @ X2_v1 (Il2CppMethodInfo)]);\n\t// 7 IndirectJump v7 @ X3_v1, v0 @ X0_v1 (System.Collections.Generic.List`1<T>), v0 @ X0_v1 (System.Collections.Generic.List`1<T>), index @ X1 (System.Int32), methodof(System.Collections.Generic.List`1<T>::get_Item), v7 @ X3_v1, v9 @ X4, v10 @ X5, v11 @ X6, v12 @ X7, v13 @ V0, v14 @ V1, v15 @ V2, v16 @ V3, v17 @ V4, v18 @ V5, v19 @ V6, v20 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual T Get(int index)
		{
			//IL_001d: Expected O, but got I
			List<T> list = this.list;
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v7 @ X3_v1 (should have been resolved before IL gen)");
			return null;
		}

		[Token(Token = "0x60000EE")]
		[Address(RVA = "0xD95BA4", Offset = "0xD95BA4", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.list;\n\tv6 = Il2CppMethodInfo;\n\tv7 = *([v6 @ X2_v1 (Il2CppMethodInfo)]);\n\t// 7 IndirectJump v7 @ X3_v1, v0 @ X0_v1 (System.Collections.Generic.List`1<T>), v0 @ X0_v1 (System.Collections.Generic.List`1<T>), e @ X1 (T), methodof(System.Collections.Generic.List`1<T>::IndexOf), v7 @ X3_v1, v9 @ X4, v10 @ X5, v11 @ X6, v12 @ X7, v13 @ V0, v14 @ V1, v15 @ V2, v16 @ V3, v17 @ V4, v18 @ V5, v19 @ V6, v20 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual int IndexOf(T e)
		{
			//IL_001d: Expected O, but got I
			List<T> list = this.list;
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v7 @ X3_v1 (should have been resolved before IL gen)");
			return 0;
		}

		[Token(Token = "0x60000EF")]
		[Address(RVA = "0xD95BCC", Offset = "0xD95BCC", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = ~this.locked;\n\tif (v8) goto L_0017;\n\tv10 = this.list;\n\tv11 = this.removedCount + 1;\n\tthis.removedCount = v11;\n\tv17 = this.nullElement;\n\tv20 = Il2CppMethodInfo;\n\tv21 = *([v20 @ X3_v2 (Il2CppMethodInfo)]);\n\t// 22 IndirectJump v21 @ X4_v1, v10 @ X8_v5 (System.Collections.Generic.List`1<T>), v10 @ X8_v5 (System.Collections.Generic.List`1<T>), index @ X1 (System.Int32), v17 @ X2_v2 (T), methodof(System.Collections.Generic.List`1<T>::set_Item), v21 @ X4_v1, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\nL_0017:\n\tv13 = this.list;\n\tv39 = Il2CppMethodInfo;\n\tv40 = *([v39 @ X2_v1 (Il2CppMethodInfo)]);\n\t// 33 IndirectJump v40 @ X3_v1, v13 @ X0_v3 (System.Collections.Generic.List`1<T>), v13 @ X0_v3 (System.Collections.Generic.List`1<T>), index @ X1 (System.Int32), methodof(System.Collections.Generic.List`1<T>::RemoveAt), v40 @ X3_v1, v43 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void RemoveAt(int index)
		{
			//IL_0083: Expected O, but got I
			//IL_005c: Expected O, but got I
			if (locked)
			{
				List<T> list = this.list;
				int num = removedCount + 1;
				removedCount = num;
				T val = nullElement;
				IntPtr intPtr = (IntPtr)0;
				object obj = (long)intPtr;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v21 @ X4_v1 (should have been resolved before IL gen)");
			}
			List<T> list2 = this.list;
			IntPtr intPtr2 = (IntPtr)0;
			object obj2 = (long)intPtr2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v40 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60000F0")]
		[Address(RVA = "0xD95C38", Offset = "0xD95C38", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv124 = this.list;\n\tv18 = ~this.locked;\n\tif (v18) goto L_0040;\nL_0014:\n\tv72 = System.Collections.Generic.List`1<T>::get_Count(v124);\n\tv24 = v65 >= v72;\n\tif (v24) goto L_0038;\n\tv179 = System.Collections.Generic.List`1<T>::set_Item(this.list, v65, this.nullElement);\n\tv124 = this.list;\n\tv65 = v65 + 1;\n\tv180 = this.list == 0;\n\tv69 = ~v180;\n\tif (v69) goto L_0014;\n\tgoto L_004B;\nL_0038:\n\tv147 = System.Collections.Generic.List`1<T>::get_Count(this.list);\n\tgoto L_0042;\nL_0040:\n\tv81 = System.Collections.Generic.List`1<T>::Clear(this.list);\nL_0042:\n\tthis.removedCount = v147;\n\treturn;\nL_004B:\n\tthrow System.NullReferenceException;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void Clear()
		{
			List<T> list = this.list;
			int num2;
			if (locked)
			{
				int num = 0;
				while (true)
				{
					int count = list.Count;
					if (num >= count)
					{
						break;
					}
					this.list.set_Item(num, nullElement);
					list = this.list;
					num++;
					if (this.list == null)
					{
						throw new NullReferenceException();
					}
				}
				num2 = this.list.Count;
			}
			else
			{
				this.list.Clear();
				num2 = 0;
			}
			removedCount = num2;
		}

		[Token(Token = "0x60000F1")]
		[Address(RVA = "0xD95D10", Offset = "0xD95D10", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.list;\n\tv6 = Il2CppMethodInfo;\n\tv7 = *([v6 @ X2_v1 (Il2CppMethodInfo)]);\n\t// 7 IndirectJump v7 @ X3_v1, v0 @ X0_v1 (System.Collections.Generic.List`1<T>), v0 @ X0_v1 (System.Collections.Generic.List`1<T>), e @ X1 (T), methodof(System.Collections.Generic.List`1<T>::Contains), v7 @ X3_v1, v9 @ X4, v10 @ X5, v11 @ X6, v12 @ X7, v13 @ V0, v14 @ V1, v15 @ V2, v16 @ V3, v17 @ V4, v18 @ V5, v19 @ V6, v20 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual bool Contains(T e)
		{
			//IL_001d: Expected O, but got I
			List<T> list = this.list;
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v7 @ X3_v1 (should have been resolved before IL gen)");
			return false;
		}

		[Token(Token = "0x60000F2")]
		[Address(RVA = "0xD95D38", Offset = "0xD95D38", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = System.Collections.Generic.List`1<T>::get_Count(this.list);\n\tv50 = this.removedCount < 1;\n\tif (v50) goto L_0060;\n\tv108 = v24 - 1;\n\tv109 = v108 & 0x80000000;\n\tv110 = v109 == 0;\n\tv111 = ~v110;\n\tif (v111) goto L_0060;\n\tv99 = v24 - 2;\nL_002A:\n\tv58 = v99 + 1;\n\tv177 = System.Collections.Generic.List`1<T>::get_Item(this.list, v58);\n\tv81 = v177 == this.nullElement;\n\tif (v81) goto L_0045;\n\tv138 = this.removedCount;\n\tgoto L_0053;\nL_0045:\n\tv183 = System.Collections.Generic.List`1<T>::RemoveAt(this.list, v58);\n\tv138 = this.removedCount - 1;\n\tthis.removedCount = v138;\nL_0053:\n\tv117 = v138 < 1;\n\tif (v117) goto L_0060;\n\tv137 = v99 - 1;\n\tv190 = v99 & 0x80000000;\n\tv140 = v190 == 0;\n\tif (v140) goto L_002A;\nL_0060:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ClearRemoved()
		{
			//IL_004e: Expected I4, but got I8
			//IL_0125: Expected I4, but got I8
			int count = list.Count;
			if (removedCount < 1)
			{
				return;
			}
			int num = count - 1;
			if ((int)(num & 0x80000000L) != 0)
			{
				return;
			}
			int num2 = count - 2;
			bool flag;
			do
			{
				int index = num2 + 1;
				T val = list.get_Item(index);
				int num3;
				if (val != nullElement)
				{
					num3 = removedCount;
				}
				else
				{
					list.RemoveAt(index);
					num3 = --removedCount;
				}
				if (num3 >= 1)
				{
					int num4 = num2 - 1;
					int num5 = (int)(num2 & 0x80000000L);
					flag = num5 == 0;
					num2 = num4;
					continue;
				}
				break;
			}
			while (flag);
		}

		[Token(Token = "0x60000F4")]
		[Address(RVA = "0xD95E54", Offset = "0xD95E54", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.locked = 1;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal void Lock()
		{
			locked = true;
		}

		[Token(Token = "0x60000F5")]
		[Address(RVA = "0xD95E60", Offset = "0xD95E60", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = LunarConsolePluginInternal.BaseList`1<T>::ClearRemoved(this);\n\tthis.locked = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal void Unlock()
		{
			Clear();
			locked = false;
		}
	}
}
