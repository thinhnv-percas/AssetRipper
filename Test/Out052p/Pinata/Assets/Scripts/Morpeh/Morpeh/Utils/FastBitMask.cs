using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.IL2CPP.CompilerServices;

namespace Morpeh.Utils
{
	[StructLayout((LayoutKind)0, Size = 32)]
	[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73D964", Offset = "0x73D964")]
	[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73D964", Offset = "0x73D964")]
	[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73D964", Offset = "0x73D964")]
	[Token(Token = "0x2000032")]
	public struct FastBitMask : IEquatable<FastBitMask>
	{
		[Token(Token = "0x4000055")]
		public static readonly FastBitMask None;

		[Token(Token = "0x4000056")]
		private const int FIELD_COUNT = 4;

		[Token(Token = "0x4000057")]
		private const int BITS_PER_BYTE = 8;

		[Token(Token = "0x4000058")]
		private const int BITS_PER_FIELD = 64;

		[Token(Token = "0x4000059")]
		private const int BITS_PER_FIELD_SHIFT = 6;

		[Token(Token = "0x400005A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		internal ulong field0;

		[Token(Token = "0x400005B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		internal ulong field1;

		[Token(Token = "0x400005C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		internal ulong field2;

		[Token(Token = "0x400005D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		internal ulong field3;

		[Token(Token = "0x60000CD")]
		[Address(RVA = "0x863A00", Offset = "0x863A00", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x10;\n\tv2 = 0x15F8484(v0, bits, methodInfo, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17);\n\treturn;\n")]
		public unsafe FastBitMask(int[] bits)
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F8484 (inside Morpeh.UpdateSystem::.ctor +0x8)");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x60000CE")]
		[Address(RVA = "0x863A08", Offset = "0x863A08", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = *([index @ X1 (System.Int32&)]) >> 6;\n\tv3 = v2 < 3;\n\tv4 = ~v3;\n\tv5 = v2 - 3;\n\tv7 = v5 == 0;\n\tv12 = ~v7;\n\tv13 = v4 & v12;\n\tif (v13) goto L_0016;\n\tv15 = 0x1844000 + 0x890;\n\tv17 = *([v15 @ X10_v2 (System.Int32)+v2 @ X9_v1 (System.Int32)*4]) + v15;\n\t// 18 IndirectJump v17 @ X9_v3, this @ X0 (Morpeh.Utils.FastBitMask), this @ X0 (Morpeh.Utils.FastBitMask), index @ X1 (System.Int32&), methodInfo @ X2 (Il2CppMethodInfo), v20 @ X3, v21 @ X4, v22 @ X5, v23 @ X6, v24 @ X7, v25 @ V0, v26 @ V1, v27 @ V2, v28 @ V3, v29 @ V4, v30 @ V5, v31 @ V6, v32 @ V7\n\tX9 = X0 + 0x10;\n\tgoto L_001C;\nL_0016:\n\treturn 0;\n\tX9 = X0 + 0x18;\n\tgoto L_001C;\n\tX9 = X0 + 0x20;\n\tgoto L_001C;\n\tX9 = X0 + 0x28;\nL_001C:\n\tX9 = *([X9]);\n\tX8 = X8 & 0x3F;\n\tX10 = 0 | 1;\n\tX8 = X10 << X8;\n\tTEMP = X9 & X8;\n\tN = TEMP < 0;\n\tC = 0;\n\tV = 0;\n\tTEMPCOND = ~Z;\n\tX0 = TEMPCOND;\n\treturn X0;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool GetBit(in int index)
		{
			//IL_0094: Expected O, but got I
			int num = index >> 6;
			bool flag = num < 3;
			bool flag2 = !flag;
			int num2 = num - 3;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 25444352 + 2192;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X10_v2 (System.Int32)+v2 @ X9_v1 (System.Int32)*4]");
				object obj = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v17 @ X9_v3 (should have been resolved before IL gen)");
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x60000CF")]
		[Address(RVA = "0x863A6C", Offset = "0x863A6C", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = *([index @ X1 (System.Int32&)]) >> 6;\n\tv3 = v2 < 3;\n\tv4 = ~v3;\n\tv5 = v2 - 3;\n\tv7 = v5 == 0;\n\tv12 = ~v7;\n\tv13 = v4 & v12;\n\tif (v13) goto L_0020;\n\tv15 = 0x1844000 + 0x8B0;\n\tv17 = *([v15 @ X10_v2 (System.Int32)+v2 @ X9_v1 (System.Int32)*4]) + v15;\n\t// 18 IndirectJump v17 @ X9_v3, this @ X0 (Morpeh.Utils.FastBitMask), this @ X0 (Morpeh.Utils.FastBitMask), index @ X1 (System.Int32&), methodInfo @ X2 (Il2CppMethodInfo), v20 @ X3, v21 @ X4, v22 @ X5, v23 @ X6, v24 @ X7, v25 @ V0, v26 @ V1, v27 @ V2, v28 @ V3, v29 @ V4, v30 @ V5, v31 @ V6, v32 @ V7\n\tX9 = X0 + 0x10;\n\tgoto L_001A;\n\tX9 = X0 + 0x18;\n\tgoto L_001A;\n\tX9 = X0 + 0x20;\n\tgoto L_001A;\n\tX9 = X0 + 0x28;\nL_001A:\n\tX10 = *([X9]);\n\tX8 = X8 & 0x3F;\n\tX11 = 0 | 1;\n\tX8 = X11 << X8;\n\tX8 = X10 | X8;\n\t*([X9]) = X8;\nL_0020:\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetBit(in int index)
		{
			//IL_0094: Expected O, but got I
			int num = index >> 6;
			bool flag = num < 3;
			bool flag2 = !flag;
			int num2 = num - 3;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 25444352 + 2224;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X10_v2 (System.Int32)+v2 @ X9_v1 (System.Int32)*4]");
				object obj = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v17 @ X9_v3 (should have been resolved before IL gen)");
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x60000D0")]
		[Address(RVA = "0x863AC8", Offset = "0x863AC8", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = *([index @ X1 (System.Int32&)]) >> 6;\n\tv3 = v2 < 3;\n\tv4 = ~v3;\n\tv5 = v2 - 3;\n\tv7 = v5 == 0;\n\tv12 = ~v7;\n\tv13 = v4 & v12;\n\tif (v13) goto L_0020;\n\tv15 = 0x1844000 + 0x8D0;\n\tv17 = *([v15 @ X10_v2 (System.Int32)+v2 @ X9_v1 (System.Int32)*4]) + v15;\n\t// 18 IndirectJump v17 @ X9_v3, this @ X0 (Morpeh.Utils.FastBitMask), this @ X0 (Morpeh.Utils.FastBitMask), index @ X1 (System.Int32&), methodInfo @ X2 (Il2CppMethodInfo), v20 @ X3, v21 @ X4, v22 @ X5, v23 @ X6, v24 @ X7, v25 @ V0, v26 @ V1, v27 @ V2, v28 @ V3, v29 @ V4, v30 @ V5, v31 @ V6, v32 @ V7\n\tX9 = X0 + 0x10;\n\tgoto L_001A;\n\tX9 = X0 + 0x18;\n\tgoto L_001A;\n\tX9 = X0 + 0x20;\n\tgoto L_001A;\n\tX9 = X0 + 0x28;\nL_001A:\n\tX10 = *([X9]);\n\tX8 = X8 & 0x3F;\n\tX11 = 0 | 1;\n\tX8 = X11 << X8;\n\tX8 = X10 ^ X8;\n\t*([X9]) = X8;\nL_0020:\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void FlipBit(in int index)
		{
			//IL_0094: Expected O, but got I
			int num = index >> 6;
			bool flag = num < 3;
			bool flag2 = !flag;
			int num2 = num - 3;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 25444352 + 2256;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X10_v2 (System.Int32)+v2 @ X9_v1 (System.Int32)*4]");
				object obj = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v17 @ X9_v3 (should have been resolved before IL gen)");
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x60000D1")]
		[Address(RVA = "0x863B24", Offset = "0x863B24", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = *([index @ X1 (System.Int32&)]) >> 6;\n\tv3 = v2 < 3;\n\tv4 = ~v3;\n\tv5 = v2 - 3;\n\tv7 = v5 == 0;\n\tv12 = ~v7;\n\tv13 = v4 & v12;\n\tif (v13) goto L_0021;\n\tv15 = 0x1844000 + 0x8F0;\n\tv17 = *([v15 @ X10_v2 (System.Int32)+v2 @ X9_v1 (System.Int32)*4]) + v15;\n\t// 18 IndirectJump v17 @ X9_v3, this @ X0 (Morpeh.Utils.FastBitMask), this @ X0 (Morpeh.Utils.FastBitMask), index @ X1 (System.Int32&), methodInfo @ X2 (Il2CppMethodInfo), v20 @ X3, v21 @ X4, v22 @ X5, v23 @ X6, v24 @ X7, v25 @ V0, v26 @ V1, v27 @ V2, v28 @ V3, v29 @ V4, v30 @ V5, v31 @ V6, v32 @ V7\n\tX9 = X0 + 0x10;\n\tgoto L_001A;\n\tX9 = X0 + 0x18;\n\tgoto L_001A;\n\tX9 = X0 + 0x20;\n\tgoto L_001A;\n\tX9 = X0 + 0x28;\nL_001A:\n\tX10 = *([X9]);\n\tX8 = X8 & 0x3F;\n\tX11 = 0 | 1;\n\tX8 = X11 << X8;\n\tTEMP = ~X8;\n\tX8 = X10 & TEMP;\n\t*([X9]) = X8;\nL_0021:\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ClearBit(in int index)
		{
			//IL_0094: Expected O, but got I
			int num = index >> 6;
			bool flag = num < 3;
			bool flag2 = !flag;
			int num2 = num - 3;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 25444352 + 2288;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X10_v2 (System.Int32)+v2 @ X9_v1 (System.Int32)*4]");
				object obj = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v17 @ X9_v3 (should have been resolved before IL gen)");
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x60000D2")]
		[Address(RVA = "0x863B80", Offset = "0x863B80", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.field2 = 0xFFFFFFFF;\n\t*([this @ X0 (Morpeh.Utils.FastBitMask)+20]) = 0xFFFFFFFF;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetAll()
		{
			field2 = 4294967295uL;
			_ = 4294967295L;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x60000D3")]
		[Address(RVA = "0x863B8C", Offset = "0x863B8C", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.field2 = 0;\n\t*([this @ X0 (Morpeh.Utils.FastBitMask)+20]) = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ClearAll()
		{
			//IL_000b: Expected I8, but got I4
			field2 = 0uL;
			_ = 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x60000D4")]
		[Address(RVA = "0x863B98", Offset = "0x863B98", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = this.field2 != other.field0;\n\tif (v13) goto L_0032;\n\tv24 = this.field3 != other.field0;\n\tif (v24) goto L_0032;\n\tv26 = *([this @ X0 (Morpeh.Utils.FastBitMask)+20]) != other.field0;\n\tif (v26) goto L_0032;\n\tv63 = *([this @ X0 (Morpeh.Utils.FastBitMask)+28]) - other.field0;\n\tv59 = v63 == 0;\n\treturn v59;\nL_0032:\n\treturn 0;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Equals(FastBitMask other)
		{
			//IL_0092: Expected O, but got I8
			if (field2 == other.field0 && field3 == other.field0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Morpeh.Utils.FastBitMask)+20]");
				if (0 == other.field0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Morpeh.Utils.FastBitMask)+28]");
					object obj = 0 - other.field0;
					return obj == null;
				}
			}
			return false;
		}

		[Token(Token = "0x60000D5")]
		[Address(RVA = "0x863BD8", Offset = "0x863BD8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x10;\n\treturnVal1 = 0x15F86C4(v0, obj, methodInfo, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17);\n\treturn returnVal1;\n")]
		public unsafe override bool Equals(object obj)
		{
			//IL_000b: Expected O, but got Ref
			object obj2 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F86C4 (inside Morpeh.UpdateSystem::.ctor +0x248)");
			bool result = default(bool);
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x60000D6")]
		[Address(RVA = "0x15F87A4", Offset = "0x15F87A4", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = mask1.field0 != mask2.field0;\n\tif (v13) goto L_0032;\n\tv24 = mask1.field1 != mask2.field0;\n\tif (v24) goto L_0032;\n\tv26 = mask1.field2 != mask2.field0;\n\tif (v26) goto L_0032;\n\tv63 = mask1.field3 - mask2.field0;\n\tv59 = v63 == 0;\n\treturn v59;\nL_0032:\n\treturn 0;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool operator ==(FastBitMask mask1, FastBitMask mask2)
		{
			if (mask1.field0 == mask2.field0 && mask1.field1 == mask2.field0 && mask1.field2 == mask2.field0)
			{
				long num = (long)(mask1.field3 - mask2.field0);
				return num == 0;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x60000D7")]
		[Address(RVA = "0x15F87E4", Offset = "0x15F87E4", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = mask1.field0 != mask2.field0;\n\tif (v13) goto L_0033;\n\tv24 = mask1.field1 != mask2.field0;\n\tif (v24) goto L_0033;\n\tv26 = mask1.field2 != mask2.field0;\n\tif (v26) goto L_0033;\n\tv64 = mask1.field3 - mask2.field0;\n\tv60 = v64 == 0;\n\tv50 = ~v60;\n\treturn v50;\nL_0033:\n\treturn 1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool operator !=(FastBitMask mask1, FastBitMask mask2)
		{
			if (mask1.field0 == mask2.field0 && mask1.field1 == mask2.field0 && mask1.field2 == mask2.field0)
			{
				long num = (long)(mask1.field3 - mask2.field0);
				bool flag = num == 0;
				return !flag;
			}
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x60000D8")]
		[Address(RVA = "0x15F8824", Offset = "0x15F8824", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = mask2.field0 & mask1.field0;\n\tv11 = mask2.field1 & mask1.field1;\n\tv12 = mask2.field2 & mask1.field2;\n\tv13 = mask2.field3 & mask1.field3;\n\treturnBuffer.field0 = v10;\n\treturnBuffer.field1 = v11;\n\treturnBuffer.field2 = v12;\n\treturnBuffer.field3 = v13;\n\treturn mask1;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static FastBitMask operator &(FastBitMask mask1, FastBitMask mask2)
		{
			//IL_0064: Expected native int or pointer, but got O
			//IL_0071: Expected native int or pointer, but got O
			//IL_007e: Expected native int or pointer, but got O
			//IL_008b: Expected native int or pointer, but got O
			long num = (long)(mask2.field0 & mask1.field0);
			long num2 = (long)(mask2.field1 & mask1.field1);
			long num3 = (long)(mask2.field2 & mask1.field2);
			long num4 = (long)(mask2.field3 & mask1.field3);
			FastBitMask fastBitMask = default(FastBitMask);
			((FastBitMask*)(IntPtr)fastBitMask)->field0 = (ulong)num;
			((FastBitMask*)(IntPtr)fastBitMask)->field1 = (ulong)num2;
			((FastBitMask*)(IntPtr)fastBitMask)->field2 = (ulong)num3;
			((FastBitMask*)(IntPtr)fastBitMask)->field3 = (ulong)num4;
			return mask1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x60000D9")]
		[Address(RVA = "0x15F8850", Offset = "0x15F8850", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = mask2.field0 | mask1.field0;\n\tv11 = mask2.field1 | mask1.field1;\n\tv12 = mask2.field2 | mask1.field2;\n\tv13 = mask2.field3 | mask1.field3;\n\treturnBuffer.field0 = v10;\n\treturnBuffer.field1 = v11;\n\treturnBuffer.field2 = v12;\n\treturnBuffer.field3 = v13;\n\treturn mask1;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static FastBitMask operator |(FastBitMask mask1, FastBitMask mask2)
		{
			//IL_0064: Expected native int or pointer, but got O
			//IL_0071: Expected native int or pointer, but got O
			//IL_007e: Expected native int or pointer, but got O
			//IL_008b: Expected native int or pointer, but got O
			long num = (long)(mask2.field0 | mask1.field0);
			long num2 = (long)(mask2.field1 | mask1.field1);
			long num3 = (long)(mask2.field2 | mask1.field2);
			long num4 = (long)(mask2.field3 | mask1.field3);
			FastBitMask fastBitMask = default(FastBitMask);
			((FastBitMask*)(IntPtr)fastBitMask)->field0 = (ulong)num;
			((FastBitMask*)(IntPtr)fastBitMask)->field1 = (ulong)num2;
			((FastBitMask*)(IntPtr)fastBitMask)->field2 = (ulong)num3;
			((FastBitMask*)(IntPtr)fastBitMask)->field3 = (ulong)num4;
			return mask1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x60000DA")]
		[Address(RVA = "0x15F887C", Offset = "0x15F887C", Length = "0x19C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = ~mask.field0;\n\tv7 = ~mask.field1;\n\tv9 = ~mask.field2;\n\tv11 = ~mask.field3;\n\treturnBuffer.field0 = v5;\n\treturnBuffer.field1 = v7;\n\treturnBuffer.field2 = v9;\n\treturnBuffer.field3 = v11;\n\treturn mask;\n\tX8 = *([X1]);\n\tX9 = *([X0]);\n\tTEMP = ~X9;\n\tX8 = X8 & TEMP;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0030;\n\tX8 = *([X1+8]);\n\tX9 = *([X0+8]);\n\tTEMP = ~X9;\n\tX8 = X8 & TEMP;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0030;\n\tX8 = *([X1+10]);\n\tX9 = *([X0+10]);\n\tTEMP = ~X9;\n\tX8 = X8 & TEMP;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0030;\n\tX8 = *([X1+18]);\n\tX9 = *([X0+18]);\n\tTEMP = ~X9;\n\tTEMP = X8 & TEMP;\n\tN = TEMP < 0;\n\tC = 0;\n\tV = 0;\n\tX0 = Z;\n\treturn X0;\nL_0030:\n\tX0 = 0;\n\treturn X0;\n\t// 50 ShiftStack -64\n\tstack[0] = X24;\n\tstack[8] = X23;\n\tstack[10] = X22;\n\tstack[18] = X21;\n\tstack[20] = X20;\n\tstack[28] = X19;\n\tstack[30] = X29;\n\tstack[38] = X30;\n\tX29 = &stack[30];\n\tX8 = *([202A06C]);\n\tX21 = X0;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0049;\n\tX8 = *([1F0E5C8]);\n\tX0 = *([X8]);\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([202A06C]) = X8;\nL_0049:\n\tX8 = 0x1EC8000;\n\tX8 = *([1EC8B10]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX19 = X0;\n\tSystem.Text.StringBuilder::.ctor(X0, X1);\n\tX8 = *([1EC4EC0]);\n\tX1 = 0 | 4;\n\tX0 = *([X8]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X21]);\n\tX20 = X0;\n\tX20 = X20 + 0x20;\n\t*([X20]) = X8;\n\tX8 = *([X21+8]);\n\tX22 = 0;\n\t*([X20+8]) = X8;\n\tX8 = *([X21+10]);\n\t*([X20+10]) = X8;\n\tX8 = *([X21+18]);\n\tX23 = *([1F0DC70]);\n\t*([X20+18]) = X8;\n\tX24 = *([1ECE9F8]);\nL_0064:\n\tX0 = *([X23]);\n\tX21 = *([X20+X22]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_006F;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_006F;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_006F:\n\tX1 = 0 | 2;\n\tX0 = X21;\n\tX2 = 0;\n\tX0 = System.Convert::ToString(X0, X1, X2);\n\tX1 = 0 | 0x40;\n\tX2 = 0 | 0x30;\n\tX3 = 0;\n\tX0 = System.String::PadLeft(X0, X1, X2, X3);\n\tX1 = X0;\n\tX0 = X19;\n\tX2 = 0;\n\tX0 = System.Text.StringBuilder::Append(X0, X1, X2);\n\tX1 = *([X24]);\n\tX0 = X19;\n\tX2 = 0;\n\tX0 = System.Text.StringBuilder::Append(X0, X1, X2);\n\tX22 = X22 + 8;\n\tC = X22 < 0x20;\n\tC = ~C;\n\tTEMP1 = X22 - 0x20;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ 0x20;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0064;\n\tX8 = *([X19]);\n\tX0 = X19;\n\tX29 = stack[30];\n\tX30 = stack[38];\n\tX20 = stack[20];\n\tX19 = stack[28];\n\tX2 = *([X8+160]);\n\tX1 = *([X8+168]);\n\tX22 = stack[10];\n\tX21 = stack[18];\n\tX24 = stack[0];\n\tX23 = stack[8];\n\t// 151 ShiftStack 64\n\t// 152 IndirectJump X2, X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7\n\treturn X0;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static FastBitMask operator ~(FastBitMask mask)
		{
			//IL_0040: Expected native int or pointer, but got O
			//IL_004d: Expected native int or pointer, but got O
			//IL_005a: Expected native int or pointer, but got O
			//IL_0067: Expected native int or pointer, but got O
			long num = (long)(~mask.field0);
			long num2 = (long)(~mask.field1);
			long num3 = (long)(~mask.field2);
			long num4 = (long)(~mask.field3);
			FastBitMask fastBitMask = default(FastBitMask);
			((FastBitMask*)(IntPtr)fastBitMask)->field0 = (ulong)num;
			((FastBitMask*)(IntPtr)fastBitMask)->field1 = (ulong)num2;
			((FastBitMask*)(IntPtr)fastBitMask)->field2 = (ulong)num3;
			((FastBitMask*)(IntPtr)fastBitMask)->field3 = (ulong)num4;
			return mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x60000DB")]
		[Address(RVA = "0x863BE0", Offset = "0x863BE0", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = ~this.field2;\n\tv5 = *([mask @ X1 (Morpeh.Utils.FastBitMask&)]) & v4;\n\tv6 = v5 == 0;\n\tv7 = ~v6;\n\tif (v7) goto L_0020;\n\tv10 = ~this.field3;\n\tv11 = *([mask @ X1 (Morpeh.Utils.FastBitMask&)+8]) & v10;\n\tv12 = v11 == 0;\n\tv13 = ~v12;\n\tif (v13) goto L_0020;\n\tv22 = ~*([this @ X0 (Morpeh.Utils.FastBitMask)+20]);\n\tv19 = *([mask @ X1 (Morpeh.Utils.FastBitMask&)+10]) & v22;\n\tv23 = v19 == 0;\n\tv15 = ~v23;\n\tif (v15) goto L_0020;\n\tv44 = ~*([this @ X0 (Morpeh.Utils.FastBitMask)+28]);\n\tv39 = *([mask @ X1 (Morpeh.Utils.FastBitMask&)+18]) & v44;\n\tv33 = v39 == 0;\n\treturn v33;\nL_0020:\n\treturn 0;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Has(in FastBitMask mask)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Expected I8, but got Unknown
			long num = (long)(~field2);
			long num2 = (long)(mask & num);
			if (num2 == 0)
			{
				long num3 = (long)(~field3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [mask @ X1 (Morpeh.Utils.FastBitMask&)+8]");
				long num4 = 0 & num3;
				if (num4 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Morpeh.Utils.FastBitMask)+20]");
					int num5 = -1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [mask @ X1 (Morpeh.Utils.FastBitMask&)+10]");
					if ((int)(0L & (long)num5) == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Morpeh.Utils.FastBitMask)+28]");
						int num6 = -1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [mask @ X1 (Morpeh.Utils.FastBitMask&)+18]");
						int num7 = (int)(0L & (long)num6);
						return num7 == 0;
					}
				}
			}
			return false;
		}

		[Token(Token = "0x60000DC")]
		[Address(RVA = "0x863C2C", Offset = "0x863C2C", Length = "0x718")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x10;\n\treturnVal1 = 0x15F88EC(v0, methodInfo, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17);\n\treturn returnVal1;\n\t// 3 ShiftStack -32\n\tstack[0] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX19 = X0;\n\tX0 = &stack[8];\n\tX0 = 0x8A0B24(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX0 = 0x8D8470(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tFirebase.AppUtilPINVOKE+SWIGExceptionHelper::SetPendingApplicationException(X0, X1);\n\tX0 = &stack[8];\n\tX0 = 0x8A0B7C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX19 = stack[0];\n\t// 19 ShiftStack 32\n\treturn X0;\n\tX19 = X0;\n\tX0 = &stack[8];\n\tX0 = 0x8A0B7C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t// 26 ShiftStack -32\n\tstack[0] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX19 = X0;\n\tX0 = &stack[8];\n\tX0 = 0x8A0B24(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX0 = 0x8D8470(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tFirebase.AppUtilPINVOKE+SWIGExceptionHelper::SetPendingArithmeticException(X0, X1);\n\tX0 = &stack[8];\n\tX0 = 0x8A0B7C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX19 = stack[0];\n\t// 42 ShiftStack 32\n\treturn X0;\n\tX19 = X0;\n\tX0 = &stack[8];\n\tX0 = 0x8A0B7C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t// 49 ShiftStack -32\n\tstack[0] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX19 = X0;\n\tX0 = &stack[8];\n\tX0 = 0x8A0B24(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX0 = 0x8D8470(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tFirebase.AppUtilPINVOKE+SWIGExceptionHelper::SetPendingDivideByZeroException(X0, X1);\n\tX0 = &stack[8];\n\tX0 = 0x8A0B7C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX19 = stack[0];\n\t// 65 ShiftStack 32\n\treturn X0;\n\tX19 = X0;\n\tX0 = &stack[8];\n\tX0 = 0x8A0B7C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t// 72 ShiftStack -32\n\tstack[0] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX19 = X0;\n\tX0 = &stack[8];\n\tX0 = 0x8A0B24(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX0 = 0x8D8470(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tFirebase.AppUtilPINVOKE+SWIGExceptionHelper::SetPendingIndexOutOfRangeException(X0, X1);\n\tX0 = &stack[8];\n\tX0 = 0x8A0B7C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX19 = stack[0];\n\t// 88 ShiftStack 32\n\treturn X0;\n\tX19 = X0;\n\tX0 = &stack[8];\n\tX0 = 0x8A0B7C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t// 95 ShiftStack -32\n\tstack[0] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX19 = X0;\n\tX0 = &stack[8];\n\tX0 = 0x8A0B24(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX0 = 0x8D8470(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tFirebase.AppUtilPINVOKE+SWIGExceptionHelper::SetPendingInvalidCastException(X0, X1);\n\tX0 = &stack[8];\n\tX0 = 0x8A0B7C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX19 = stack[0];\n\t// 111 ShiftStack 32\n\treturn X0;\n\tX19 = X0;\n\tX0 = &stack[8];\n\tX0 = 0x8A0B7C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t// 118 ShiftStack -32\n\tstack[0] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX19 = X0;\n\tX0 = &stack[8];\n\tX0 = 0x8A0B24(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX0 = 0x8D8470(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tFirebase.AppUtilPINVOKE+SWIGExceptionHelper::SetPendingInvalidOperationException(X0, X1);\n\tX0 = &stack[8];\n\tX0 = 0x8A0B7C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX19 = stack[0];\n\t// 134 ShiftStack 32\n\treturn X0;\n\tX19 = X0;\n\tX0 = &stack[8];\n\tX0 = 0x8A0B7C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t// 141 ShiftStack -32\n\tstack[0] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX19 = X0;\n\tX0 = &stack[8];\n\tX0 = 0x8A0B24(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX0 = 0x8D8470(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tFirebase.AppUtilPINVOKE+SWIGExceptionHelper::SetPendingIOException(X0, X1);\n\tX0 = &stack[8];\n\tX0 = 0x8A0B7C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX19 = stack[0];\n\t// 157 ShiftStack 32\n\treturn X0;\n\tX19 = X0;\n\tX0 = &stack[8];\n\tX0 = 0x8A0B7C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t// 164 ShiftStack -32\n\tstack[0] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX19 = X0;\n\tX0 = &stack[8];\n\tX0 = 0x8A0B24(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX0 = 0x8D8470(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tFirebase.AppUtilPINVOKE+SWIGExceptionHelper::SetPendingNullReferenceException(X0, X1);\n\tX0 = &stack[8];\n\tX0 = 0x8A0B7C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX19 = stack[0];\n\t// 180 ShiftStack 32\n\treturn X0;\n\tX19 = X0;\n\tX0 = &stack[8];\n\tX0 = 0x8A0B7C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t// 187 ShiftStack -32\n\tstack[0] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX19 = X0;\n\tX0 = &stack[8];\n\tX0 = 0x8A0B24(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX0 = 0x8D8470(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tFirebase.AppUtilPINVOKE+SWIGExceptionHelper::SetPendingOutOfMemoryException(X0, X1);\n\tX0 = &stack[8];\n\tX0 = 0x8A0B7C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX19 = stack[0];\n\t// 203 ShiftStack 32\n\treturn X0;\n\tX19 = X0;\n\tX0 = &stack[8];\n\tX0 = 0x8A0B7C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t// 210 ShiftStack -32\n\tstack[0] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX19 = X0;\n\tX0 = &stack[8];\n\tX0 = 0x8A0B24(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX0 = 0x8D8470(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tFirebase.AppUtilPINVOKE+SWIGExceptionHelper::SetPendingOverflowException(X0, X1);\n\tX0 = &stack[8];\n\tX0 = 0x8A0B7C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX19 = stack[0];\n\t// 226 ShiftStack 32\n\treturn X0;\n\tX19 = X0;\n\tX0 = &stack[8];\n\tX0 = 0x8A0B7C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t// 233 ShiftStack -32\n\tstack[0] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX19 = X0;\n\tX0 = &stack[8];\n\tX0 = 0x8A0B24(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX0 = 0x8D8470(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tFirebase.AppUtilPINVOKE+SWIGExceptionHelper::SetPending\n// ... truncated")]
		public unsafe override string ToString()
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F88EC (inside Morpeh.Utils.FastBitMask::op_OnesComplement +0x70)");
			string result = default(string);
			return result;
		}

		[Token(Token = "0x60000DD")]
		[Address(RVA = "0x15F8A18", Offset = "0x15F8A18", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = *([1EF9EB8]);\n\tv15 = *([v14 @ X8_v10]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A06D]) = v35;\nL_0015:\n\t// 21 NewArr v40 @ X0_v3 (System.Int32[]), typeof(System.Int32[]), 0\n\tv44 = 0;\n\tv46 = 0x15F8484(&v44 @ stack_-40_v1 (Morpeh.Utils.FastBitMask), v40, v18, v19, v20, v21, v22, v23, 0, v25, v26, v27, v28, v29, v30, v31);\n\tv50 = Morpeh.Utils.FastBitMask;\n\tv51 = *([v50 @ X8_v7 (Il2CppClass<Morpeh.Utils.FastBitMask>)+B8]);\n\t*([v51 @ X8_v8 (Il2CppStaticFields<Morpeh.Utils.FastBitMask>)+10]) = 0;\n\tv51.None = 0;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static FastBitMask()
		{
			//IL_0035: Expected I, but got O
			//IL_003e: Expected I, but got O
			int[] array = new int[0];
			FastBitMask fastBitMask = default(FastBitMask);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F8484 (inside Morpeh.UpdateSystem::.ctor +0x8)");
			IntPtr intPtr = (IntPtr)typeof(FastBitMask);
			IntPtr intPtr2 = (IntPtr)None;
			_ = 0;
			None = default(FastBitMask);
		}
	}
}
