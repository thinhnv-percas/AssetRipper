using System;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.BriefFactory
{
	[Serializable]
	[Token(Token = "0x20003A9")]
	public class ConceptDumpEntry
	{
		[Token(Token = "0x4000B42")]
		[FieldOffset(Offset = "0x10")]
		public string id;

		[Token(Token = "0x4000B43")]
		[FieldOffset(Offset = "0x18")]
		public string displayName;

		[Token(Token = "0x4000B44")]
		[FieldOffset(Offset = "0x20")]
		public string definition;

		[Token(Token = "0x6000F4F")]
		[Address(RVA = "0x3C9B3D4", Offset = "0x3C9B3D4", Length = "0x8")]
		public ConceptDumpEntry()
		{
		}
	}
}
