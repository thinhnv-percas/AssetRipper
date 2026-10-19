using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Generator
{
	[Token(Token = "0x200004D")]
	public class GeneratorException : Exception
	{
		[Token(Token = "0x60000CE")]
		[Address(RVA = "0x3C19CAC", Offset = "0x3C19CAC", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_0027:\n\tSystem.Exception::.ctor(this, message);\n\treturn;\nL_001B:\n\tgoto L_0027;\n")]
		public GeneratorException(string message)
			: base(message)
		{
		}
	}
}
