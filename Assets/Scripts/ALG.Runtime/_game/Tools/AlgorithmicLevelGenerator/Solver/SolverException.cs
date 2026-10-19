using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x200001D")]
	public class SolverException : Exception
	{
		[Token(Token = "0x6000050")]
		[Address(RVA = "0x3C05BA8", Offset = "0x3C05BA8", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_0027:\n\tSystem.Exception::.ctor(this, message);\n\treturn;\nL_001B:\n\tgoto L_0027;\n")]
		public SolverException(string message)
			: base(message)
		{
		}

		[Token(Token = "0x6000051")]
		[Address(RVA = "0x3C0B764", Offset = "0x3C0B764", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_002D:\n\tSystem.Exception::.ctor(this, message, inner);\n\treturn;\nL_001E:\n\tgoto L_002D;\n")]
		public SolverException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
