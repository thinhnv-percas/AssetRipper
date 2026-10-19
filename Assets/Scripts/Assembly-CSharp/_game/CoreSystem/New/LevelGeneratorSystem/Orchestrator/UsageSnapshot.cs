using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Orchestrator
{
	[Serializable]
	[Token(Token = "0x200036A")]
	public class UsageSnapshot
	{
		[Token(Token = "0x4000A4D")]
		[FieldOffset(Offset = "0x10")]
		public int sessionPct;

		[Token(Token = "0x4000A4E")]
		[FieldOffset(Offset = "0x18")]
		public DateTime sessionResetLocal;

		[Token(Token = "0x4000A4F")]
		[FieldOffset(Offset = "0x20")]
		public int weekAllPct;

		[Token(Token = "0x4000A50")]
		[FieldOffset(Offset = "0x28")]
		public DateTime weekAllResetLocal;

		[Token(Token = "0x4000A51")]
		[FieldOffset(Offset = "0x30")]
		public int weekSonnetPct;

		[Token(Token = "0x4000A52")]
		[FieldOffset(Offset = "0x34")]
		public bool probeFailed;

		[Token(Token = "0x4000A53")]
		[FieldOffset(Offset = "0x38")]
		public string raw;

		[Token(Token = "0x6000E13")]
		[Address(RVA = "0x3F03268", Offset = "0x3F03268", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tthis.raw = \"\";\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public UsageSnapshot()
		{
			raw = "";
		}
	}
}
