using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Concepts
{
	[Token(Token = "0x20003A0")]
	public readonly struct ConceptSummary
	{
		[Token(Token = "0x4000B15")]
		[FieldOffset(Offset = "0x0")]
		public readonly string Id;

		[Token(Token = "0x4000B16")]
		[FieldOffset(Offset = "0x8")]
		public readonly string DisplayName;

		[Token(Token = "0x4000B17")]
		[FieldOffset(Offset = "0x10")]
		public readonly string OneLineSummary;

		[Token(Token = "0x6000F3E")]
		[Address(RVA = "0x3C99178", Offset = "0x3C99178", Length = "0xC4")]
		public ConceptSummary(string id, string displayName, string oneLineSummary)
		{
			//IL_009a: Expected O, but got I
			//IL_00aa: Expected O, but got I
			//IL_0162: Expected O, but got I
			//IL_0172: Expected O, but got I
			//IL_00fa: Expected O, but got I
			//IL_010a: Expected O, but got I
			if (id != null)
			{
				Id = id;
				if (displayName != null)
				{
					goto IL_003f;
				}
			}
			else
			{
				int num = 192761856 + 1336;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X8_v12 (System.Int32)+90]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X8_v13+B8]");
				object id2 = 0;
				Id = (string)id2;
				if (displayName != null)
				{
					goto IL_003f;
				}
			}
			int num2 = 192761856 + 1336;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ X8_v8 (System.Int32)+90]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ X8_v9+B8]");
			object displayName2 = 0;
			DisplayName = (string)displayName2;
			bool flag = oneLineSummary == null;
			bool flag2 = !flag;
			string oneLineSummary2 = oneLineSummary;
			if (flag2)
			{
				goto IL_006d;
			}
			goto IL_0143;
			IL_006d:
			OneLineSummary = oneLineSummary2;
			return;
			IL_0143:
			int num3 = 192761856 + 1336;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ X8_v3 (System.Int32)+90]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ X8_v4+B8]");
			object obj4 = 0;
			oneLineSummary2 = (string)obj4;
			goto IL_006d;
			IL_003f:
			DisplayName = displayName;
			bool flag3 = oneLineSummary == null;
			oneLineSummary2 = oneLineSummary;
			if (!flag3)
			{
				goto IL_006d;
			}
			goto IL_0143;
		}
	}
}
