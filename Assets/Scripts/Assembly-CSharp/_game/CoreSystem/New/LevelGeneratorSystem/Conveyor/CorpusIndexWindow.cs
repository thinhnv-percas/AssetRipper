using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Conveyor
{
	[Token(Token = "0x2000399")]
	public static class CorpusIndexWindow
	{
		[Token(Token = "0x4000B04")]
		public const int Start = 101;

		[Token(Token = "0x4000B05")]
		public const int End = 250;

		[Token(Token = "0x6000F20")]
		[Address(RVA = "0x3C95F7C", Offset = "0x3C95F7C", Length = "0x28")]
		public static void Resolve(int unique, out int start, out int count)
		{
			start = default(int);
			count = default(int);
			int num = unique - 101;
			bool flag = (uint)unique < 250u;
			bool flag2 = !flag;
			int num2 = unique - 250;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (flag2 && flag4)
			{
				num = 150;
			}
			int num3 = unique - 101;
			bool flag5 = num3 < 0;
			bool flag6 = num3 == 0;
			int num4 = unique ^ 0x65;
			int num5 = unique ^ num3;
			int num6 = num4 & num5;
			bool flag7 = num6 < 0;
			start = 101;
			bool flag8 = flag5 == flag7;
			bool flag9 = !flag6;
			if (!(flag8 && flag9))
			{
				num = 0;
			}
			count = num;
		}
	}
}
