using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Obi
{
	[StructLayout((LayoutKind)0, Size = 8)]
	[Attribute(Type = typeof(DefaultMemberAttribute), RVA = "0x744614", Offset = "0x744614")]
	[Token(Token = "0x200003A")]
	public struct ParticlePair
	{
		[Token(Token = "0x40000CD")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public int first;

		[Token(Token = "0x40000CE")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		public int second;

		[Token(Token = "0x17000051")]
		public unsafe int Item
		{
			[Token(Token = "0x60002C9")]
			[Address(RVA = "0x8560F0", Offset = "0x8560F0", Length = "0x18")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = this + 0x10;\n\tv2 = this + 0x14;\n\tv8 = index == 0;\n\tv13 = ~v8;\n\tv14 = ~v13;\n\tif (v14) goto L_0013;\n\tgoto L_0013;\nL_0013:\n\treturn *([v17 @ X8_v2]);\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000b: Expected O, but got Ref
				//IL_0016: Expected O, but got Ref
				//IL_005b: Expected I4, but got O
				object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
				object obj2 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 20));
				if (index != 0)
				{
					obj = obj2;
				}
				return (int)obj;
			}
			[Token(Token = "0x60002CA")]
			[Address(RVA = "0x856108", Offset = "0x856108", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = this + 0x10;\n\tv13 = index != 0;\n\tif (v13) goto L_0011;\n\tgoto L_0011;\nL_0011:\n\t*([v16 @ X8_v2]) = value;\n\treturn;\n\t// 19 ShiftStack -16\n\tstack[0] = X29;\n\tstack[8] = X30;\n\tX29 = &stack[0];\n\tX0 = X0 + 0xF00;\n\tX0 = 0x8D82DC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t// 29 ShiftStack -16\n\tstack[0] = X29;\n\tstack[8] = X30;\n\tX29 = &stack[0];\n\tX0 = X0 + 0xF00;\n\tX0 = 0x8D82DC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_000b: Expected O, but got Ref
				//IL_0039: Expected O, but got I4
				object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
				if (index == 0)
				{
				}
				obj = value;
			}
		}

		[Token(Token = "0x60002C8")]
		[Address(RVA = "0x8560E8", Offset = "0x8560E8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (Obi.ParticlePair)+10]) = first;\n\t*([this @ X0 (Obi.ParticlePair)+14]) = second;\n\treturn;\n")]
		public ParticlePair(int first, int second)
		{
		}
	}
}
