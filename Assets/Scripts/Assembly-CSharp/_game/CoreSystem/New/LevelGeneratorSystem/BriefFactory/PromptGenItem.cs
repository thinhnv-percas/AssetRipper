using System;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.BriefFactory
{
	[Serializable]
	[Token(Token = "0x20003B4")]
	public class PromptGenItem
	{
		[Token(Token = "0x4000B95")]
		[FieldOffset(Offset = "0x10")]
		public string brief;

		[Token(Token = "0x4000B96")]
		[FieldOffset(Offset = "0x18")]
		public bool failed;

		[Token(Token = "0x4000B97")]
		[FieldOffset(Offset = "0x20")]
		public string error;

		[Token(Token = "0x4000B98")]
		[FieldOffset(Offset = "0x28")]
		public long inputTokens;

		[Token(Token = "0x4000B99")]
		[FieldOffset(Offset = "0x30")]
		public long outputTokens;

		[Token(Token = "0x4000B9A")]
		[FieldOffset(Offset = "0x38")]
		public long cacheCreationTokens;

		[Token(Token = "0x4000B9B")]
		[FieldOffset(Offset = "0x40")]
		public long cacheReadTokens;

		[Token(Token = "0x4000B9C")]
		[FieldOffset(Offset = "0x48")]
		public long contextTokens;

		[Token(Token = "0x4000B9D")]
		[FieldOffset(Offset = "0x50")]
		public double elapsedSeconds;

		[Token(Token = "0x1700013B")]
		public long TotalTokens
		{
			[Token(Token = "0x6000F74")]
			[Address(RVA = "0x3C9DAB4", Offset = "0x3C9DAB4", Length = "0x18")]
			get
			{
				long result = inputTokens + cacheCreationTokens;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction ADDP not yet implemented.\"");
				return result;
			}
		}

		[Token(Token = "0x6000F75")]
		[Address(RVA = "0x3C9DACC", Offset = "0x3C9DACC", Length = "0x8")]
		public PromptGenItem()
		{
		}
	}
}
