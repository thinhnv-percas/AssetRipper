using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Actions
{
	[Token(Token = "0x20003CB")]
	public static class GeneratorColorPolicy
	{
		[Token(Token = "0x4000BED")]
		public const string ErrorCode = "COLOR_NOT_ALLOWED";

		[Token(Token = "0x4000BEE")]
		public const string RejectHint = "This color is disabled in level generation. Pick a different color from the tool schema's color list.";

		[Token(Token = "0x4000BEF")]
		internal static readonly HashSet<GameColor> DisallowedColors;

		[Token(Token = "0x6000FB3")]
		[Address(RVA = "0x3CA3538", Offset = "0x3CA3538", Length = "0xAC")]
		public static bool IsAllowed(GameColor color)
		{
			bool flag = DisallowedColors.Contains(color);
			return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
		}

		[Token(Token = "0x6000FB4")]
		[Address(RVA = "0x3CA35E4", Offset = "0x3CA35E4", Length = "0x150")]
		public static IReadOnlyList<GameColor> AllowedColors()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GeneratorColorPolicy::AllowedColors");
			return default;
		}

		[Token(Token = "0x6000FB5")]
		[Address(RVA = "0x3CA3734", Offset = "0x3CA3734", Length = "0x88")]
		public static string RejectMessage(GameColor color)
		{
			object arg = color;
			return $"Color {arg} is not allowed in generated levels.";
		}

		[Token(Token = "0x6000FB6")]
		[Address(RVA = "0x3CA37BC", Offset = "0x3CA37BC", Length = "0xC0")]
		static GeneratorColorPolicy()
		{
			HashSet<GameColor> hashSet = new HashSet<GameColor>();
			bool flag = hashSet.Add(GameColor.LightBlue);
			DisallowedColors = hashSet;
		}
	}
}
