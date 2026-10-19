using System.Text.RegularExpressions;
using Cpp2ILInjected;
using _game.CoreSystem.New.GridEcsBinding;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Driver
{
	[Token(Token = "0x2000392")]
	public static class VisualIndexText
	{
		[Token(Token = "0x4000AEF")]
		private static readonly Regex CellPattern;

		[Token(Token = "0x4000AF0")]
		private static readonly Regex ParenPattern;

		[Token(Token = "0x6000EFD")]
		[Address(RVA = "0x3C91F0C", Offset = "0x3C91F0C", Length = "0x198")]
		public static string TranslateCoords(string text, VisualIndexMap map)
		{
			if (!string.IsNullOrEmpty(text) && map != null)
			{
				MatchEvaluator evaluator = delegate(Match m)
				{
					string text2 = IndexOf(map, m, 2, 3);
					return "Cell " + text2;
				};
				string input = CellPattern.Replace(text, evaluator);
				MatchEvaluator evaluator2 = delegate(Match m)
				{
					string text2 = IndexOf(map, m, 1, 2);
					return "cell " + text2;
				};
				return ParenPattern.Replace(input, evaluator2);
			}
			return text;
		}

		[Token(Token = "0x6000EFE")]
		[Address(RVA = "0x3C920AC", Offset = "0x3C920AC", Length = "0x178")]
		private static string IndexOf(VisualIndexMap map, Match m, int gx, int gy)
		{
			int value = 0;
			GroupCollection groups = m.Groups;
			Group obj = groups[gx];
			string value2 = obj.Value;
			int x = int.Parse(value2);
			GroupCollection groups2 = m.Groups;
			Group obj2 = groups2[gy];
			string value3 = obj2.Value;
			int y = int.Parse(value3);
			GridCoord key = new GridCoord(x, y);
			if (map._byCoord.TryGetValue(key, out value))
			{
				return value.ToString();
			}
			return "<off-map>";
		}

		[Token(Token = "0x6000EFF")]
		[Address(RVA = "0x3C92224", Offset = "0x3C92224", Length = "0xE8")]
		static VisualIndexText()
		{
			Regex cellPattern = new Regex("\\b(Cell|Coord)\\s+(\\d+),(\\d+)", RegexOptions.Compiled);
			CellPattern = cellPattern;
			Regex parenPattern = new Regex("\\((\\d+),\\s*(\\d+)\\)", RegexOptions.Compiled);
			ParenPattern = parenPattern;
		}
	}
}
