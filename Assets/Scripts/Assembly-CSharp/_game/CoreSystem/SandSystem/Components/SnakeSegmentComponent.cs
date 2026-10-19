using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Newtonsoft.Json;
using _game.CoreSystem.LevelCreator;

namespace _game.CoreSystem.SandSystem.Components
{
	[Serializable]
	[JsonObject]
	[Token(Token = "0x2000099")]
	public class SnakeSegmentComponent : ICellComponent
	{
		[Token(Token = "0x4000190")]
		[FieldOffset(Offset = "0x10")]
		public int snakeId;

		[Token(Token = "0x4000191")]
		[FieldOffset(Offset = "0x14")]
		public int nextCol;

		[Token(Token = "0x4000192")]
		[FieldOffset(Offset = "0x18")]
		public int nextRow;

		[JsonIgnore]
		[Token(Token = "0x17000051")]
		public bool IsHead
		{
			[Token(Token = "0x600028F")]
			[Address(RVA = "0x3C79D1C", Offset = "0x3C79D1C", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.nextCol & 0x80000000;\n\tv3 = v2 == 0;\n\tv4 = ~v3;\n\tif (v4) goto L_0009;\n\treturnVal1 = this.nextRow >> 0x1F;\n\treturn returnVal1;\nL_0009:\n\treturn 1;\n")]
			get
			{
				//IL_0014: Expected I4, but got I8
				if ((int)(nextCol & 0x80000000L) == 0)
				{
					return (byte)(nextRow >> 31) != 0;
				}
				return true;
			}
		}

		[Token(Token = "0x6000290")]
		[Address(RVA = "0x3C79D38", Offset = "0x3C79D38", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.nextCol = -1;\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SnakeSegmentComponent()
		{
			nextCol = -1;
			nextRow = -1;
		}
	}
}
