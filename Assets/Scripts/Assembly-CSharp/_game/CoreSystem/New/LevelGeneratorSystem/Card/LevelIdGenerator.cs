using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Card
{
	[Token(Token = "0x20003A8")]
	public static class LevelIdGenerator
	{
		[Token(Token = "0x4000B40")]
		public const string Prefix = "level_";

		[Token(Token = "0x4000B41")]
		private static readonly Random _fallbackRng;

		[Token(Token = "0x6000F4C")]
		[Address(RVA = "0x3C9A984", Offset = "0x3C9A984", Length = "0x8EC")]
		public static string GenerateRandomUnused(IReadOnlyList<string> pool, IEnumerable<string> existingNames, Random rng, out bool poolExhausted)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelIdGenerator::GenerateRandomUnused");
			poolExhausted = default;
			return default;
		}

		[Token(Token = "0x6000F4D")]
		[Address(RVA = "0x3C9B270", Offset = "0x3C9B270", Length = "0xE4")]
		public static string ExtractWord(string name)
		{
			//IL_00b1: Expected I4, but got I8
			bool flag = string.IsNullOrEmpty(name);
			bool flag2 = !flag;
			bool flag3 = !flag2;
			string text = null;
			if (!flag3)
			{
				string text2 = name.Trim();
				string text3 = text2.ToLowerInvariant();
				bool flag4 = text3.StartsWith("level_");
				bool flag5 = !flag4;
				text = text3;
				if (!flag5)
				{
					string text4 = "level_";
					string text5 = text3.Substring(text4.Length);
					text = text5;
				}
				int num = text.IndexOf('_');
				if ((int)(num & 0x80000000L) == 0)
				{
					return text.Substring(0, num);
				}
			}
			return text;
		}

		[Token(Token = "0x6000F4E")]
		[Address(RVA = "0x3C9B354", Offset = "0x3C9B354", Length = "0x80")]
		static LevelIdGenerator()
		{
			Random fallbackRng = new Random();
			_fallbackRng = fallbackRng;
		}
	}
}
