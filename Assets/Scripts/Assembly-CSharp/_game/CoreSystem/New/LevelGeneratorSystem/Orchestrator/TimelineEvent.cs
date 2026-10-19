using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Orchestrator
{
	[Serializable]
	[Token(Token = "0x2000368")]
	public class TimelineEvent
	{
		[Token(Token = "0x4000A2D")]
		[FieldOffset(Offset = "0x10")]
		public string ts;

		[Token(Token = "0x4000A2E")]
		[FieldOffset(Offset = "0x18")]
		public string kind;

		[Token(Token = "0x4000A2F")]
		[FieldOffset(Offset = "0x20")]
		public string cardId;

		[Token(Token = "0x4000A30")]
		[FieldOffset(Offset = "0x28")]
		public string difficulty;

		[Token(Token = "0x4000A31")]
		[FieldOffset(Offset = "0x30")]
		public int attempt;

		[Token(Token = "0x4000A32")]
		[FieldOffset(Offset = "0x38")]
		public string category;

		[Token(Token = "0x4000A33")]
		[FieldOffset(Offset = "0x40")]
		public string message;

		[Token(Token = "0x4000A34")]
		[FieldOffset(Offset = "0x48")]
		public string dataRef;

		[Token(Token = "0x6000E12")]
		[Address(RVA = "0x3F03260", Offset = "0x3F03260", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public TimelineEvent()
		{
		}
	}
}
