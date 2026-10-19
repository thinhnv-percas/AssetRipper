using Cpp2ILInjected;
using Newtonsoft.Json.Linq;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Driver
{
	[Token(Token = "0x2000385")]
	public sealed class TokenUsage
	{
		[Token(Token = "0x4000ACF")]
		[FieldOffset(Offset = "0x10")]
		public long InputTokens;

		[Token(Token = "0x4000AD0")]
		[FieldOffset(Offset = "0x18")]
		public long OutputTokens;

		[Token(Token = "0x4000AD1")]
		[FieldOffset(Offset = "0x20")]
		public long CacheCreationTokens;

		[Token(Token = "0x4000AD2")]
		[FieldOffset(Offset = "0x28")]
		public long CacheReadTokens;

		[Token(Token = "0x17000123")]
		public long Total
		{
			[Token(Token = "0x6000EB7")]
			[Address(RVA = "0x3F18210", Offset = "0x3F18210", Length = "0x14")]
			get
			{
				long result = InputTokens + CacheCreationTokens;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction ADDP not yet implemented.\"");
				return result;
			}
		}

		[Token(Token = "0x6000EB8")]
		[Address(RVA = "0x3F18224", Offset = "0x3F18224", Length = "0x24")]
		public void Add(TokenUsage other)
		{
			if (other != null)
			{
				OutputTokens = (long)((ulong)(InputTokens = other.InputTokens + InputTokens) >> 64);
				CacheReadTokens = (long)((ulong)(CacheCreationTokens = other.CacheCreationTokens + CacheCreationTokens) >> 64);
			}
		}

		[Token(Token = "0x6000EB9")]
		[Address(RVA = "0x3F1803C", Offset = "0x3F1803C", Length = "0x1D4")]
		public static TokenUsage TryFrom(JObject jo)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TokenUsage::TryFrom");
			return default;
		}

		[Token(Token = "0x6000EBA")]
		[Address(RVA = "0x3F18248", Offset = "0x3F18248", Length = "0x8")]
		public TokenUsage()
		{
		}
	}
}
