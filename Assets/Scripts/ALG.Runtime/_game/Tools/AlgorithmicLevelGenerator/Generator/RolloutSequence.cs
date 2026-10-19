using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Generator
{
	[Token(Token = "0x2000057")]
	public class RolloutSequence
	{
		[Token(Token = "0x400016F")]
		[FieldOffset(Offset = "0x10")]
		public List<(int Col, int Row)> Steps;

		[Token(Token = "0x4000170")]
		[FieldOffset(Offset = "0x18")]
		public bool Won;

		[Token(Token = "0x4000171")]
		[FieldOffset(Offset = "0x1C")]
		public int PeakAvailable;

		[Token(Token = "0x4000172")]
		[FieldOffset(Offset = "0x20")]
		public string FailReason;

		[Token(Token = "0x60000E4")]
		[Address(RVA = "0x3C1B044", Offset = "0x3C1B044", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tthis.FailReason = \"\";\n\tSystem.Object::.ctor(this);\n\treturn;\nL_0023:\n\tv54 = new System.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>();\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>::.ctor(v54);\n\tthis.Steps = v54;\n")]
		public RolloutSequence()
		{
			List<(int, int)> steps = new List<(int, int)>();
			Steps = steps;
			FailReason = "";
		}
	}
}
