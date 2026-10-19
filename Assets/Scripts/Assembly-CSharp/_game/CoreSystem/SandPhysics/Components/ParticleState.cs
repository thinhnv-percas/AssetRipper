using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Entities;

namespace _game.CoreSystem.SandPhysics.Components
{
	[Token(Token = "0x200011D")]
	public struct ParticleState : IComponentData, IQueryTypeParameter
	{
		[Token(Token = "0x40003B3")]
		[FieldOffset(Offset = "0x0")]
		public byte flags;

		[Token(Token = "0x40003B4")]
		[FieldOffset(Offset = "0x1")]
		public byte absorbTargetColumn;

		[Token(Token = "0x40003B5")]
		[FieldOffset(Offset = "0x2")]
		public byte lastConveyorSegment;

		[Token(Token = "0x40003B6")]
		public const byte NoTarget = 255;

		[Token(Token = "0x40003B7")]
		public const byte NoSegmentCache = 255;

		[Token(Token = "0x17000088")]
		public bool IsSettled
		{
			[Token(Token = "0x60005DA")]
			[Address(RVA = "0x3DA6FB0", Offset = "0x3DA6FB0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.flags & 1;\n\treturn returnVal1;\n")]
			get
			{
				return (byte)(flags & 1) != 0;
			}
			[Token(Token = "0x60005DB")]
			[Address(RVA = "0x3DB0278", Offset = "0x3DB0278", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.flags & 0xFE;\n\tv3 = v2 | value;\n\tthis.flags = v3;\n\treturn;\n")]
			set
			{
				int num = flags & 0xFE;
				int num2 = num | (value ? 1 : 0);
				flags = (byte)num2;
			}
		}

		[Token(Token = "0x17000089")]
		public bool IsExited
		{
			[Token(Token = "0x60005DC")]
			[Address(RVA = "0x3DA6FBC", Offset = "0x3DA6FBC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.flags >> 1;\n\treturnVal1 = v2 & 1;\n\treturn returnVal1;\n")]
			get
			{
				int num = flags >> 1;
				return (byte)(num & 1) != 0;
			}
			[Token(Token = "0x60005DD")]
			[Address(RVA = "0x3DB028C", Offset = "0x3DB028C", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.flags & -3;\n\tv8 = value == 0;\n\tv14 = ~v8;\n\tv15 = ~v14;\n\tif (v15) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv18 = 2;\n\tgoto L_0013;\nL_FFFFFFFF:\n\tv18 = 0;\nL_0013:\n\tv19 = v2 | v18;\n\tthis.flags = v19;\n\treturn;\n")]
			set
			{
				int num = flags & -3;
				int num2 = (value ? 2 : 0);
				int num3 = num | num2;
				flags = (byte)num3;
			}
		}

		[Token(Token = "0x1700008A")]
		public bool IsAbsorbing
		{
			[Token(Token = "0x60005DE")]
			[Address(RVA = "0x3DA6FC8", Offset = "0x3DA6FC8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.flags >> 2;\n\treturnVal1 = v2 & 1;\n\treturn returnVal1;\n")]
			get
			{
				int num = flags >> 2;
				return (byte)(num & 1) != 0;
			}
			[Token(Token = "0x60005DF")]
			[Address(RVA = "0x3DB02AC", Offset = "0x3DB02AC", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.flags & -5;\n\tv8 = value == 0;\n\tv14 = ~v8;\n\tv15 = ~v14;\n\tif (v15) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv18 = 4;\n\tgoto L_0013;\nL_FFFFFFFF:\n\tv18 = 0;\nL_0013:\n\tv19 = v2 | v18;\n\tthis.flags = v19;\n\treturn;\n")]
			set
			{
				int num = flags & -5;
				int num2 = (value ? 4 : 0);
				int num3 = num | num2;
				flags = (byte)num3;
			}
		}

		[Token(Token = "0x1700008B")]
		public bool IsOnConveyor
		{
			[Token(Token = "0x60005E0")]
			[Address(RVA = "0x3DABBF8", Offset = "0x3DABBF8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.flags >> 3;\n\treturnVal1 = v2 & 1;\n\treturn returnVal1;\n")]
			get
			{
				int num = flags >> 3;
				return (byte)(num & 1) != 0;
			}
			[Token(Token = "0x60005E1")]
			[Address(RVA = "0x3DB02CC", Offset = "0x3DB02CC", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.flags & -9;\n\tv8 = value == 0;\n\tv14 = ~v8;\n\tv15 = ~v14;\n\tif (v15) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv18 = 8;\n\tgoto L_0013;\nL_FFFFFFFF:\n\tv18 = 0;\nL_0013:\n\tv19 = v2 | v18;\n\tthis.flags = v19;\n\treturn;\n")]
			set
			{
				int num = flags & -9;
				int num2 = (value ? 8 : 0);
				int num3 = num | num2;
				flags = (byte)num3;
			}
		}

		[Token(Token = "0x1700008C")]
		public bool IsVacuumReserved
		{
			[Token(Token = "0x60005E2")]
			[Address(RVA = "0x3DB02EC", Offset = "0x3DB02EC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.flags >> 7;\n\treturn returnVal1;\n")]
			get
			{
				return (byte)(flags >> 7) != 0;
			}
			[Token(Token = "0x60005E3")]
			[Address(RVA = "0x3DB02F8", Offset = "0x3DB02F8", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = value == 0;\n\tv13 = ~v7;\n\tv14 = ~v13;\n\tif (v14) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv17 = 0xFFFFFFFFFFFFFF80;\n\tgoto L_0013;\nL_FFFFFFFF:\n\tv17 = 0;\nL_0013:\n\tv19 = this.flags & 0x7F;\n\tv20 = v17 & 0xFFFFFFFFFFFFFF80;\n\tv21 = v20 | v19;\n\tthis.flags = v21;\n\treturn;\n")]
			set
			{
				int num = (value ? (-128) : 0);
				int num2 = flags & 0x7F;
				int num3 = num & -128;
				int num4 = num3 | num2;
				flags = (byte)num4;
			}
		}
	}
}
