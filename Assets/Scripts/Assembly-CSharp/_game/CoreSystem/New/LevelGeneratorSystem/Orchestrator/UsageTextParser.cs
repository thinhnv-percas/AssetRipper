using System;
using System.Globalization;
using System.Text.RegularExpressions;
using AssetRipperInjected;
using Cpp2ILInjected;
using Newtonsoft.Json.Linq;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Orchestrator
{
	[Token(Token = "0x200036B")]
	public static class UsageTextParser
	{
		[Token(Token = "0x6000E14")]
		[Address(RVA = "0x3F032CC", Offset = "0x3F032CC", Length = "0x2E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0037;\nL_FFFFFFFF:\n\tv104 = \"\";\n\tgoto L_005D;\nL_FFFFFFFF:\n\tv104 = input;\n\tv161 = System.String::TrimStart(input);\n\tv233 = System.String::StartsWith(v161, \"{\");\n\tv234 = ~v233;\nL_FFFFFFFF:\n\tv157 = input;\n\tif (v234) goto L_009D;\n\tv200 = Newtonsoft.Json.Linq.JObject::Parse(input);\n\tv202 = v200 == 0;\n\tif (v202) goto L_00D2;\n\tv277 = Newtonsoft.Json.Linq.JObject::get_Item(v200, \"result\");\n\tgoto L_008A;\nL_008A:\n\tv251 = Newtonsoft.Json.Linq.JToken::op_Explicit(v277);\n\tv239 = v251 != 0;\n\tif (v239) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv157 = input;\n\tgoto L_009D;\nL_FFFFFFFF:\n\tv157 = v251;\n\t_game.CoreSystem.New.LevelGeneratorSystem.Orchestrator.UsageTextParser::ParseReset(v157, \"Current week \\\\(all models\\\\)\", nowRef, &v53.weekAllResetLocal (System.DateTime));\n\tv149 = _game.CoreSystem.New.LevelGeneratorSystem.Orchestrator.UsageTextParser::TryLine(v157, \"Current week \\\\(Sonnet only\\\\):\\\\s*(\\\\d+)%\", &v53.weekSonnetPct (System.Int32));\n\tv300 = v265 == 0;\n\tv182 = ~v300;\n\tif (v182) goto L_00D0;\n\tv302 = v283 == 0;\n\tv151 = ~v302;\n\tif (v151) goto L_00D0;\nL_00C5:\n\tv53.probeFailed = 1;\nL_00D2:\n\tv205 = new System.NullReferenceException();\n\tgoto L_00F7;\nL_00F7:\n\t// 247 Interrupt\n\tv235 = 0x8BF5BF4(v205, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv267 = 0x8BF0368(v205, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal2 = 0xA1B8(v267, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal2;\nL_0037:\n\tv53 = new _game.CoreSystem.New.LevelGeneratorSystem.Orchestrator.UsageSnapshot();\n\tgoto L_0047;\nL_0047:\n\tv53.raw = \"\";\n\tSystem.Object::.ctor(v53);\n\tv95 = input != 0;\n\tif (v95) goto L_FFFFFFFF;\nL_005D:\n\tv53.raw = v104;\n\tv112 = System.String::IsNullOrWhiteSpace(input);\n\tv117 = v112 == 0;\n\tv118 = ~v117;\n\tif (v118) goto L_00C5;\nL_009D:\n\t;\n\tv265 = _game.CoreSystem.New.LevelGeneratorSystem.Orchestrator.UsageTextParser::TryLine(v157, \"Current session:\\\\s*(\\\\d+)%\", &v53.sessionPct (System.Int32));\n\t_game.CoreSystem.New.LevelGeneratorSystem.Orchestrator.UsageTextParser::ParseReset(v157, \"Current session\", nowRef, &v53.sessionResetLocal (System.DateTime));\n\tv283 = _game.CoreSystem.New.LevelGeneratorSystem.Orchestrator.UsageTextParser::TryLine(v157, \"Current week \\\\(all models\\\\):\\\\s*(\\\\d+)%\", &v53.weekAllPct (System.Int32));\nL_00D0:\n\treturn v53;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static UsageSnapshot Parse(string input, DateTime nowRef)
		{
			UsageSnapshot usageSnapshot = new UsageSnapshot();
			usageSnapshot.raw = "";
			string raw = ((input != null) ? input : "");
			usageSnapshot.raw = raw;
			if (!string.IsNullOrWhiteSpace(input))
			{
				string text = input.TrimStart();
				bool flag = text.StartsWith("{");
				bool flag2 = !flag;
				string text2 = input;
				if (!flag2)
				{
					JObject jObject = JObject.Parse(input);
					if (jObject == null)
					{
						NullReferenceException ex = new NullReferenceException();
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5BF4");
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF0368");
						Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @A1B8");
						UsageSnapshot result = default(UsageSnapshot);
						return result;
					}
					JToken jToken = jObject["result"];
					string text3 = (string?)jToken;
					text2 = ((text3 != null) ? text3 : input);
				}
				bool flag3 = TryLine(text2, "Current session:\\s*(\\d+)%", out usageSnapshot.sessionPct);
				ParseReset(text2, "Current session", nowRef, ref usageSnapshot.sessionResetLocal);
				bool flag4 = TryLine(text2, "Current week \\(all models\\):\\s*(\\d+)%", out usageSnapshot.weekAllPct);
				ParseReset(text2, "Current week \\(all models\\)", nowRef, ref usageSnapshot.weekAllResetLocal);
				bool flag5 = TryLine(text2, "Current week \\(Sonnet only\\):\\s*(\\d+)%", out usageSnapshot.weekSonnetPct);
				if (flag3 || flag4)
				{
					goto IL_029f;
				}
			}
			usageSnapshot.probeFailed = true;
			goto IL_029f;
			IL_029f:
			return usageSnapshot;
		}

		[Token(Token = "0x6000E15")]
		[Address(RVA = "0x3F035B0", Offset = "0x3F035B0", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = *([B78E9C9]) & 1;\n\tv29 = v28 == 0;\n\tif (v29) goto L_0026;\n\t*([pct @ X2 (System.Int32&)]) = 0;\n\tgoto L_001D;\nL_001D:\n\tv59 = System.Text.RegularExpressions.Regex::Match(text, pattern, 1);\n\tv66 = v59 == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_0037;\n\tgoto L_005F;\nL_0026:\n\t*([B78E9C9]) = 1;\n\t*([pct @ X2 (System.Int32&)]) = 0;\n\tgoto L_001D;\nL_0037:\n\treturnVal2 = System.Text.RegularExpressions.Group::get_Success(v59);\n\tv102 = ~returnVal2;\n\tif (v102) goto L_005E;\n\tv99 = *([v59 @ X0_v20 (System.Text.RegularExpressions.Match)]);\n\t*([v99 @ X8_v4 (Il2CppClass<System.Text.RegularExpressions.Group>)+188])(v93, v59, *([v99 @ X8_v4 (Il2CppClass<System.Text.RegularExpressions.Group>)+190]), 1, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv94 = System.Text.RegularExpressions.GroupCollection::get_Item(v93, 1);\n\tv139 = System.Text.RegularExpressions.Capture::get_Value(v94);\n\treturnVal3 = System.Int32::TryParse(v139, pct);\n\treturn returnVal3;\nL_005E:\n\treturn returnVal2;\nL_005F:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n")]
		private static bool TryLine(string text, string pattern, out int pct)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UsageTextParser::TryLine");
			pct = default;
			return default;
		}

		[Token(Token = "0x6000E16")]
		[Address(RVA = "0x3F036C0", Offset = "0x3F036C0", Length = "0x45C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = nowRef;\n\tgoto L_0029;\nL_0035:\n\tv75 = System.Text.RegularExpressions.Regex::Match(text, v57, 1);\n\tv81 = System.Text.RegularExpressions.Group::get_Success(v75);\n\tv204 = v81 == 0;\n\tif (v204) goto L_0097;\n\tv137 = System.Text.RegularExpressions.Match::get_Groups(v75);\n\tv138 = System.Text.RegularExpressions.GroupCollection::get_Item(v137, 1);\n\tv292 = System.Text.RegularExpressions.Capture::get_Value(v138);\n\tv293 = _game.CoreSystem.New.LevelGeneratorSystem.Orchestrator.UsageTextParser::MonthOf(v292);\n\tv139 = System.Text.RegularExpressions.Match::get_Groups(v75);\n\tv140 = System.Text.RegularExpressions.GroupCollection::get_Item(v139, 2);\n\tv331 = System.Text.RegularExpressions.Capture::get_Value(v140);\n\tv333 = System.Int32::Parse(v331);\n\tv141 = System.Text.RegularExpressions.Match::get_Groups(v75);\n\tv142 = System.Text.RegularExpressions.GroupCollection::get_Item(v141, 3);\n\tv341 = System.Text.RegularExpressions.Capture::get_Value(v142);\n\tv343 = System.Int32::Parse(v341);\n\tv143 = System.Text.RegularExpressions.Match::get_Groups(v75);\n\tv144 = System.Text.RegularExpressions.GroupCollection::get_Item(v143, 4);\n\tv360 = System.Text.RegularExpressions.Group::get_Success(v144);\n\tv361 = ~v360;\n\tif (v361) goto L_FFFFFFFF;\n\tv145 = System.Text.RegularExpressions.Match::get_Groups(v75);\n\tv146 = System.Text.RegularExpressions.GroupCollection::get_Item(v145, 4);\n\tv386 = System.Text.RegularExpressions.Capture::get_Value(v146);\n\tv372 = System.Int32::Parse(v386);\nL_FFFFFFFF:\n\tv181 = v372;\n\tgoto L_00E3;\nL_0097:\n\tv211 = System.String::Concat(label, \".*?resets\\\\s+(\\\\d{1,2})(?::(\\\\d{2}))?\\\\s*(am|pm)?\");\n\tgoto L_00A3;\nL_00A3:\n\tv147 = System.Text.RegularExpressions.Regex::Match(text, v211, 1);\n\tv295 = System.Text.RegularExpressions.Group::get_Success(v147);\n\tv297 = ~v295;\n\tif (v297) goto L_015D;\n\tv148 = System.Text.RegularExpressions.Match::get_Groups(v147);\n\tv149 = System.Text.RegularExpressions.GroupCollection::get_Item(v148, 1);\n\tv335 = System.Text.RegularExpressions.Capture::get_Value(v149);\n\tv338 = System.Int32::Parse(v335);\n\tv150 = System.Text.RegularExpressions.Match::get_Groups(v147);\n\tv151 = System.Text.RegularExpressions.GroupCollection::get_Item(v150, 2);\n\tv345 = System.Text.RegularExpressions.Group::get_Success(v151);\n\tv347 = ~v345;\n\tif (v347) goto L_FFFFFFFF;\n\tv152 = System.Text.RegularExpressions.Match::get_Groups(v147);\n\tv153 = System.Text.RegularExpressions.GroupCollection::get_Item(v152, 2);\n\tv363 = System.Text.RegularExpressions.Capture::get_Value(v153);\n\tv354 = System.Int32::Parse(v363);\nL_FFFFFFFF:\n\tv201 = v354;\n\tgoto L_0128;\nL_FFFFFFFF:\n\tv181 = 0;\n\tv154 = System.Text.RegularExpressions.GroupCollection::get_Item(v156, 5);\n\tv393 = System.Text.RegularExpressions.Capture::get_Value(v154);\n\t_game.CoreSystem.New.LevelGeneratorSystem.Orchestrator.UsageTextParser::ApplyAmPm(v393, &v378 @ stack_-4C_v5 (System.Int32));\n\tv415 = v293 <= 0;\n\tif (v415) goto L_0114;\nL_FFFFFFFF:\n\tv447 = v293;\n\tgoto L_0104;\nL_0104:\n\tv462 = System.DateTime::get_Year(&v24 @ stack_-48_v1 (System.DateTime));\nL_FFFFFFFF:\n\tv301 = v181;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv304 = v378;\nL_FFFFFFFF:\n\tv316 = v333;\nL_FFFFFFFF:\n\tv317 = v447;\nL_FFFFFFFF:\n\tv318 = v462;\nL_FFFFFFFF:\n\tv319 = &v421 @ stack_-58_v4 (System.UInt64);\n\tgoto L_0151;\nL_0114:\n\tgoto L_0118;\nL_0118:\n\tv467 = System.DateTime::get_Month(&v24 @ stack_-48_v1 (System.DateTime));\nL_FFFFFFFF:\n\tv447 = v467;\n\tgoto L_0104;\nL_FFFFFFFF:\n\tv201 = 0;\n\tv155 = System.Text.RegularExpressions.GroupCollection::get_Item(v157, 3);\n\tv367 = System.Text.RegularExpressions.Capture::get_Value(v155);\n\t_game.CoreSystem.New.LevelGeneratorSystem.Orchestrator.UsageTextParser::ApplyAmPm(v367, &v378 @ stack_-4C_v5 (System.Int32));\n\tgoto L_013E;\nL_013E:\n\tv391 = System.DateTime::get_Year(&v24 @ stack_-48_v1 (System.DateTime));\n\tv397 = System.DateTime::get_Month(&v24 @ stack_-48_v1 (System.DateTime));\n\tv403 = System.DateTime::get_Day(&v24 @ stack_-48_v1 (System.DateTime));\nL_FFFFFFFF:\n\tv301 = v201;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv304 = v378;\nL_FFFFFFFF:\n\tv316 = v403;\nL_FFFFFFFF:\n\tv317 = v397;\nL_FFFFFFFF:\n\tv318 = v391;\nL_FFFFFFFF:\n\tv319 = &v421 @ stack_-58_v4 (System.UInt64);\nL_0029:\n\tv57 = System.String::Concat(label, \".*?resets\\\\s+([A-Za-z]{3})\\\\s+(\\\\d{1,2})\\\\s+at\\\\s+(\\\\d{1,2})(?::(\\\\d{2}))?\\\\s*(am|pm)?\");\n\tgoto L_0035;\nL_00E3:\n\tv156 = System.Text.RegularExpressions.Match::get_Groups(v75);\nL_015D:\n\treturn;\nL_0128:\n\tv157 = System.Text.RegularExpressions.Match::get_Groups(v147);\nL_0151:\n\tSystem.DateTime::.ctor(v319, v318, v317, v316, v304, v301, 0, 2);\n\tresult._dateData = v421;\n")]
		private unsafe static void ParseReset(string text, string label, DateTime nowRef, ref DateTime result)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UsageTextParser::ParseReset");
		}

		[Token(Token = "0x6000E17")]
		[Address(RVA = "0x3F03B1C", Offset = "0x3F03B1C", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tgoto L_0032;\nL_0032:\n\tv69 = System.String::ToLowerInvariant(\"\");\n\tv74 = System.String::op_Equality(v69, \"pm\");\n\tv75 = ~v74;\n\tif (v75) goto L_004C;\n\tv129 = *([hour @ X1 (System.Int32&)]) <= 0xB;\n\tif (v129) goto L_005D;\nL_004C:\n\tv145 = System.String::op_Equality(v69, \"am\");\n\tv147 = ~v145;\n\tif (v147) goto L_0066;\n\tv149 = *([hour @ X1 (System.Int32&)]) != 0xC;\n\tif (v149) goto L_0066;\n\tv170 = 0;\n\tgoto L_005E;\nL_005D:\n\tv170 = *([hour @ X1 (System.Int32&)]) + 0xC;\nL_0027:\n\tv56 = v64 != 0;\n\tif (v56) goto L_0032;\nL_0066:\n\treturn;\nL_005E:\n\t*([hour @ X1 (System.Int32&)]) = v170;\n")]
		private static void ApplyAmPm(string ampm, ref int hour)
		{
			string text = default(string);
			if (text == null)
			{
			}
			string text2 = "".ToLowerInvariant();
			int num;
			if (!(text2 == "pm") || hour > 11)
			{
				if (!(text2 == "am") || hour != 12)
				{
					return;
				}
				num = 0;
			}
			else
			{
				num = hour + 12;
			}
			hour = num;
		}

		[Token(Token = "0x6000E18")]
		[Address(RVA = "0x3F03C00", Offset = "0x3F03C00", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0024:\n\tv56 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tgoto L_0034;\nL_0034:\n\tv74 = System.DateTime::ParseExact(abbr, \"MMM\", v56);\n\tv75 = v74;\n\treturnVal1 = System.DateTime::get_Month(&v75 @ stack_-38_v2 (System.DateTime));\n\treturn returnVal1;\nL_0021:\n\tgoto L_0024;\n")]
		private static int MonthOf(string abbr)
		{
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			DateTime dateTime = DateTime.ParseExact(abbr, "MMM", invariantCulture);
			DateTime dateTime2 = dateTime;
			return dateTime2.Month;
		}
	}
}
