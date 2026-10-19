using System;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Compose
{
	[Token(Token = "0x20003A3")]
	public static class LlmJsonExtractor
	{
		[Token(Token = "0x6000F46")]
		[Address(RVA = "0x3C9A294", Offset = "0x3C9A294", Length = "0x198")]
		public static string Extract(string raw)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LlmJsonExtractor::Extract");
			return default;
		}

		[Token(Token = "0x6000F47")]
		[Address(RVA = "0x3C9A42C", Offset = "0x3C9A42C", Length = "0xE8")]
		private static string StripMarkdownFence(string s)
		{
			//IL_002e: Expected I4, but got I8
			//IL_007e: Expected I4, but got I8
			//IL_00e1: Expected I4, but got I8
			int num = s.IndexOf("```", StringComparison.Ordinal);
			if ((int)(num & 0x80000000L) == 0)
			{
				int num2 = s.IndexOf('\n', num);
				if ((int)(num2 & 0x80000000L) == 0)
				{
					int startIndex = num2 + 1;
					int num3 = s.IndexOf("```", startIndex, StringComparison.Ordinal);
					if ((int)(num3 & 0x80000000L) == 0)
					{
						int num4 = ~num2;
						int startIndex2 = num2 + 1;
						int length = num3 + num4;
						return s.Substring(startIndex2, length);
					}
					int startIndex3 = num2 + 1;
					return s.Substring(startIndex3);
				}
			}
			return s;
		}
	}
}
