using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Generator
{
	[Token(Token = "0x200004F")]
	public class ConstructiveExhaustedException : GeneratorException
	{
		[Token(Token = "0x4000155")]
		[FieldOffset(Offset = "0x8C")]
		public int RetriesAttempted;

		[Token(Token = "0x60000D0")]
		[Address(RVA = "0x3C19D18", Offset = "0x3C19D18", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_0023:\n\tSystem.Exception::.ctor(this, message);\n\tthis.RetriesAttempted = retries;\n\treturn;\nL_001E:\n\tgoto L_0023;\n")]
		public ConstructiveExhaustedException(string message, int retries)
			: base(message)
		{
			RetriesAttempted = retries;
		}
	}
}
