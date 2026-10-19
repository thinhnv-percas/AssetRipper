using System;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Compose
{
	[Serializable]
	[Token(Token = "0x20003A2")]
	public class LlmCompositionDraft
	{
		[Token(Token = "0x4000B19")]
		[FieldOffset(Offset = "0x10")]
		public string id;

		[Token(Token = "0x4000B1A")]
		[FieldOffset(Offset = "0x18")]
		public string displayName;

		[Token(Token = "0x4000B1B")]
		[FieldOffset(Offset = "0x20")]
		public string definition;

		[Token(Token = "0x4000B1C")]
		[FieldOffset(Offset = "0x28")]
		public string designerNotes;

		[Token(Token = "0x6000F45")]
		[Address(RVA = "0x3C9A20C", Offset = "0x3C9A20C", Length = "0x88")]
		public LlmCompositionDraft()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LlmCompositionDraft::.ctor");
		}
	}
}
