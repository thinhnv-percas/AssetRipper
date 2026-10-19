using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.BriefFactory
{
	[Serializable]
	[Token(Token = "0x20003B5")]
	public class PromptGenResult
	{
		[Token(Token = "0x4000B9E")]
		[FieldOffset(Offset = "0x10")]
		public string band;

		[Token(Token = "0x4000B9F")]
		[FieldOffset(Offset = "0x18")]
		public int requestedCount;

		[Token(Token = "0x4000BA0")]
		[FieldOffset(Offset = "0x1C")]
		public int sampleCount;

		[Token(Token = "0x4000BA1")]
		[FieldOffset(Offset = "0x20")]
		public List<int> sampleIndices;

		[Token(Token = "0x4000BA2")]
		[FieldOffset(Offset = "0x28")]
		public List<PromptGenItem> prompts;

		[Token(Token = "0x4000BA3")]
		[FieldOffset(Offset = "0x30")]
		public long inputTokens;

		[Token(Token = "0x4000BA4")]
		[FieldOffset(Offset = "0x38")]
		public long outputTokens;

		[Token(Token = "0x4000BA5")]
		[FieldOffset(Offset = "0x40")]
		public long cacheCreationTokens;

		[Token(Token = "0x4000BA6")]
		[FieldOffset(Offset = "0x48")]
		public long cacheReadTokens;

		[Token(Token = "0x4000BA7")]
		[FieldOffset(Offset = "0x50")]
		public long contextTokens;

		[Token(Token = "0x4000BA8")]
		[FieldOffset(Offset = "0x58")]
		public double totalElapsedSeconds;

		[Token(Token = "0x4000BA9")]
		[FieldOffset(Offset = "0x60")]
		public int succeeded;

		[Token(Token = "0x4000BAA")]
		[FieldOffset(Offset = "0x64")]
		public int failed;

		[Token(Token = "0x1700013C")]
		public long TotalTokens
		{
			[Token(Token = "0x6000F76")]
			[Address(RVA = "0x3C9DAD4", Offset = "0x3C9DAD4", Length = "0x14")]
			get
			{
				long result = inputTokens + cacheCreationTokens;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction ADDP not yet implemented.\"");
				return result;
			}
		}

		[Token(Token = "0x6000F77")]
		[Address(RVA = "0x3C9DAE8", Offset = "0x3C9DAE8", Length = "0x1A4")]
		public unsafe void RecomputeTotals()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PromptGenResult::RecomputeTotals");
		}

		[Token(Token = "0x6000F78")]
		[Address(RVA = "0x3C9DC8C", Offset = "0x3C9DC8C", Length = "0xE0")]
		public PromptGenResult()
		{
			List<int> list = new List<int>();
			sampleIndices = list;
			List<PromptGenItem> list2 = new List<PromptGenItem>();
			prompts = list2;
		}
	}
}
