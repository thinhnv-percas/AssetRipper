using AssetRipperInjected;
using Cpp2ILInjected;
using Morpeh.Utils;
using Unity.IL2CPP.CompilerServices;

namespace Morpeh
{
	[Attribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73D39C", Offset = "0x73D39C")]
	[Attribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73D39C", Offset = "0x73D39C")]
	[Attribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73D39C", Offset = "0x73D39C")]
	[Token(Token = "0x2000011")]
	internal static class CommonCacheTypeIdentifier
	{
		[Token(Token = "0x200003E")]
		internal class TypeInfo
		{
			[Token(Token = "0x4000074")]
			[FieldOffset(Offset = "0x10")]
			internal int id;

			[Token(Token = "0x4000075")]
			[FieldOffset(Offset = "0x14")]
			internal bool isMarker;

			[Token(Token = "0x4000076")]
			[FieldOffset(Offset = "0x18")]
			internal FastBitMask mask;

			[Token(Token = "0x60000FF")]
			[Address(RVA = "0x15F559C", Offset = "0x15F559C", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.isMarker = isMarker;\n\tthis.mask.field2 = 0;\n\tthis.mask = 0;\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public TypeInfo(bool isMarker)
			{
				//IL_0020: Expected I8, but got I4
				base._002Ector();
				this.isMarker = isMarker;
				mask.field2 = 0uL;
				mask = default(FastBitMask);
			}

			[Token(Token = "0x6000100")]
			[Address(RVA = "0x15F55D8", Offset = "0x15F55D8", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = id >> 6;\n\tv2 = v0 < 3;\n\tv3 = ~v2;\n\tv4 = v0 - 3;\n\tv6 = v4 == 0;\n\tthis.id = id;\n\tv12 = ~v6;\n\tv13 = v3 & v12;\n\tif (v13) goto L_0020;\n\tv15 = 0x1844000 + 0x840;\n\tv17 = *([v15 @ X9_v2 (System.Int32)+v0 @ X8_v1 (System.Int32)*4]) + v15;\n\t// 18 IndirectJump v17 @ X8_v3, this @ X0 (Morpeh.CommonCacheTypeIdentifier+TypeInfo), this @ X0 (Morpeh.CommonCacheTypeIdentifier+TypeInfo), id @ X1 (System.Int32), methodInfo @ X2 (Il2CppMethodInfo), v19 @ X3, v20 @ X4, v21 @ X5, v22 @ X6, v23 @ X7, v24 @ V0, v25 @ V1, v26 @ V2, v27 @ V3, v28 @ V4, v29 @ V5, v30 @ V6, v31 @ V7\n\tX8 = X0 + 0x18;\n\tgoto L_001A;\n\tX8 = X0 + 0x20;\n\tgoto L_001A;\n\tX8 = X0 + 0x28;\n\tgoto L_001A;\n\tX8 = X0 + 0x30;\nL_001A:\n\tX9 = *([X8]);\n\tX10 = X1 & 0x3F;\n\tX11 = 0 | 1;\n\tX10 = X11 << X10;\n\tX9 = X9 | X10;\n\t*([X8]) = X9;\nL_0020:\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void SetID(int id)
			{
				//IL_0099: Expected O, but got I
				int num = id >> 6;
				bool flag = num < 3;
				bool flag2 = !flag;
				int num2 = num - 3;
				bool flag3 = num2 == 0;
				this.id = id;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					int num3 = 25444352 + 2112;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X9_v2 (System.Int32)+v0 @ X8_v1 (System.Int32)*4]");
					object obj = 0L + (long)num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v17 @ X8_v3 (should have been resolved before IL gen)");
				}
			}
		}

		[Token(Token = "0x4000031")]
		private static int counter;

		[Token(Token = "0x6000054")]
		[Address(RVA = "0x15F5544", Offset = "0x15F5544", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EABA48]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A03B]) = v35;\nL_0016:\n\tv41 = v39.counter + 1;\n\tv39.counter = v41;\n\treturn v39.counter;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int GetID()
		{
			int num = counter + 1;
			counter = num;
			return counter;
		}
	}
}
