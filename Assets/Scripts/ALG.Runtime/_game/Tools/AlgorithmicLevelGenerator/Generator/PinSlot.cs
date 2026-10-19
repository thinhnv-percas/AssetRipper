using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Generator
{
	[Token(Token = "0x200005D")]
	public class PinSlot
	{
		[Token(Token = "0x4000183")]
		[FieldOffset(Offset = "0x10")]
		public int PinId;

		[Token(Token = "0x4000184")]
		[FieldOffset(Offset = "0x18")]
		public List<(int Col, int Row)> Path;

		[Token(Token = "0x4000185")]
		[FieldOffset(Offset = "0x20")]
		public (int Col, int Row) MarkerCoord;

		[Token(Token = "0x60000ED")]
		[Address(RVA = "0x3C1C188", Offset = "0x3C1C188", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>();\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>::.ctor(v48);\n\tthis.Path = v48;\n")]
		public PinSlot()
		{
			List<(int, int)> path = new List<(int, int)>();
			Path = path;
		}
	}
}
