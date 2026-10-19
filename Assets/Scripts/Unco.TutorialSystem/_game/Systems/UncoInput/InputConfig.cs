using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Systems.UncoInput
{
	[Serializable]
	[Token(Token = "0x2000009")]
	public class InputConfig
	{
		[Token(Token = "0x4000012")]
		[FieldOffset(Offset = "0x10")]
		public InputMode inputMode;

		[Token(Token = "0x4000013")]
		[FieldOffset(Offset = "0x14")]
		public float holdDuration;

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x81DE9F8", Offset = "0x81DE9F8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public InputConfig()
		{
		}
	}
}
