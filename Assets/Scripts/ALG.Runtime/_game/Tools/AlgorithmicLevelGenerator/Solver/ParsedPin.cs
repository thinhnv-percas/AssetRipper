using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x2000013")]
	public class ParsedPin
	{
		[Token(Token = "0x4000064")]
		[FieldOffset(Offset = "0x10")]
		public int PinId;

		[Token(Token = "0x4000065")]
		[FieldOffset(Offset = "0x18")]
		public List<(int Col, int Row)> Path;

		[Token(Token = "0x4000066")]
		[FieldOffset(Offset = "0x20")]
		public (int Col, int Row) MarkerCoord;

		[Token(Token = "0x6000047")]
		[Address(RVA = "0x3C0B59C", Offset = "0x3C0B59C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>();\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>::.ctor(v48);\n\tthis.Path = v48;\n")]
		public ParsedPin()
		{
			List<(int, int)> path = new List<(int, int)>();
			Path = path;
		}
	}
}
