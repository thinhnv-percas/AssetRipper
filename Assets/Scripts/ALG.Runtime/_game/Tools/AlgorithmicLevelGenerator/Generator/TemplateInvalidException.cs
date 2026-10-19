using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Generator
{
	[Token(Token = "0x200004E")]
	public class TemplateInvalidException : GeneratorException
	{
		[Token(Token = "0x60000CF")]
		[Address(RVA = "0x3C18D18", Offset = "0x3C18D18", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_0027:\n\tSystem.Exception::.ctor(this, message);\n\treturn;\nL_001B:\n\tgoto L_0027;\n")]
		public TemplateInvalidException(string message)
			: base(message)
		{
		}
	}
}
