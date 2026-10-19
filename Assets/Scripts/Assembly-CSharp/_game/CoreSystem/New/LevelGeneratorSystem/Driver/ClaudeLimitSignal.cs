using System;
using System.Text.RegularExpressions;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Driver
{
	[Token(Token = "0x2000372")]
	public static class ClaudeLimitSignal
	{
		[Token(Token = "0x6000E39")]
		[Address(RVA = "0x3F07798", Offset = "0x3F07798", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_002A:\n\treturn 0;\nL_002F:\n\tv113 = System.String::ToLowerInvariant(resultText);\n\tv119 = System.String::Contains(v113, \"usage limit reached\");\n\tv93 = v119 == 0;\n\tif (v93) goto L_0047;\n\treturn 1;\nL_0047:\n\tv126 = System.String::Contains(v113, \"hit your\");\n\tv127 = ~v126;\n\tif (v127) goto L_005F;\n\tv130 = System.String::Contains(v113, \"limit\");\n\tv94 = v130 == 0;\n\tif (v94) goto L_005F;\n\treturn 1;\nL_005F:\n\tv57 = System.String::Contains(v113, \"limit reached\");\n\tv60 = ~v57;\n\tif (v60) goto L_002A;\n\tv58 = System.String::Contains(v113, \"resets\");\n\tv61 = v58 == 0;\n\tif (v61) goto L_002A;\n\treturn 1;\nL_0020:\n\tv41 = System.String::IsNullOrWhiteSpace(resultText);\n\tv46 = v41 == 0;\n\tif (v46) goto L_002F;\n")]
		public static bool IsUsageLimit(string resultText)
		{
			if (!string.IsNullOrWhiteSpace(resultText))
			{
				string text = resultText.ToLowerInvariant();
				if (text.Contains("usage limit reached"))
				{
					return true;
				}
				if (text.Contains("hit your") && text.Contains("limit"))
				{
					return true;
				}
				if (text.Contains("limit reached") && text.Contains("resets"))
				{
					return true;
				}
			}
			return false;
		}

		[Token(Token = "0x6000E3A")]
		[Address(RVA = "0x3F078EC", Offset = "0x3F078EC", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001E:\n\tv52 = System.DateTime::get_UtcNow();\n\treturnVal1 = _game.CoreSystem.New.LevelGeneratorSystem.Driver.ClaudeLimitSignal::TryParseReset(text, resetUtc, v52);\n\treturn returnVal1;\nL_001B:\n\tgoto L_001E;\n")]
		public static bool TryParseReset(string text, out DateTime resetUtc)
		{
			resetUtc = default(DateTime);
			DateTime utcNow = DateTime.UtcNow;
			return TryParseReset(text, out resetUtc, utcNow);
		}

		[Token(Token = "0x6000E3B")]
		[Address(RVA = "0x3F07960", Offset = "0x3F07960", Length = "0x3C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tgoto L_00C6;\nL_0037:\n\tv123 = System.String::LastIndexOf(text, 0x7C);\n\tv311 = v123 & 0x80000000;\n\tv312 = v311 == 0;\n\tv313 = ~v312;\n\tif (v313) goto L_007A;\n\tv195 = text.Length - 1;\n\tv134 = v123 >= v195;\n\tif (v134) goto L_007A;\n\tv159 = v123 + 1;\n\tv171 = System.String::Substring(text, v159);\n\tv350 = System.String::Trim(v171);\n\tv333 = System.Int64::TryParse(v350, &v318 @ stack_-58_v6 (System.Int64));\n\tv335 = ~v333;\n\tif (v335) goto L_007A;\n\tv319 = v318 < 1;\n\tif (v319) goto L_007A;\n\tgoto L_006D;\nL_006D:\n\tv364 = System.DateTimeOffset::FromUnixTimeSeconds(v318);\n\tv367 = v364;\n\tv403 = System.DateTimeOffset::get_UtcDateTime(&v367 @ stack_-68_v2 (System.DateTimeOffset));\n\tgoto L_0162;\nL_007A:\n\tgoto L_0082;\nL_0082:\n\tv172 = System.Text.RegularExpressions.Regex::Match(text, \"resets\\\\s+(\\\\d{1,2})(?::(\\\\d{2}))?\\\\s*(am|pm)?\", 1);\n\treturnVal1 = System.Text.RegularExpressions.Group::get_Success(v172);\n\tv107 = ~returnVal1;\n\tif (v107) goto L_00C6;\n\tv173 = System.Text.RegularExpressions.Match::get_Groups(v172);\n\tv174 = System.Text.RegularExpressions.GroupCollection::get_Item(v173, 1);\n\tv366 = System.Text.RegularExpressions.Capture::get_Value(v174);\n\tv373 = System.Int32::Parse(v366);\n\tv175 = System.Text.RegularExpressions.Match::get_Groups(v172);\n\tv176 = System.Text.RegularExpressions.GroupCollection::get_Item(v175, 2);\n\tv415 = System.Text.RegularExpressions.Group::get_Success(v176);\n\tv416 = ~v415;\n\tif (v416) goto L_FFFFFFFF;\n\tv177 = System.Text.RegularExpressions.Match::get_Groups(v172);\n\tv178 = System.Text.RegularExpressions.GroupCollection::get_Item(v177, 2);\n\tv429 = System.Text.RegularExpressions.Capture::get_Value(v178);\n\tv423 = System.Int32::Parse(v429);\nL_FFFFFFFF:\n\tv201 = v423;\n\tgoto L_00CC;\nL_00C6:\n\treturn returnVal1;\nL_FFFFFFFF:\n\tv201 = 0;\n\tv179 = System.Text.RegularExpressions.GroupCollection::get_Item(v181, 3);\n\tv180 = System.Text.RegularExpressions.Capture::get_Value(v179);\n\tv431 = System.String::ToLowerInvariant(v180);\n\tv437 = System.String::op_Equality(v431, \"pm\");\n\tv438 = ~v437;\n\tif (v438) goto L_00F6;\n\tv450 = v373 > 0xB;\n\tif (v450) goto L_00F6;\n\tv413 = v373 + 0xC;\n\tgoto L_0125;\nL_00F6:\n\tv466 = System.String::op_Equality(v431, \"am\");\n\tv470 = v373 - 0xC;\n\tv472 = v470 == 0;\n\tv478 = v466 & v472;\n\tv480 = ~v478;\n\tv483 = ~v480;\n\tv484 = ~v483;\n\tif (v484) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv413 = 0;\n\tgoto L_0118;\nL_FFFFFFFF:\n\tv413 = v373;\nL_0125:\n\tv391 = v201 > 0x3B;\n\tif (v391) goto L_0160;\n\tgoto L_0131;\nL_0131:\n\tv528 = System.DateTime::get_Year(&v526 @ stack_-48_v3 (System.DateTime));\n\tv532 = System.DateTime::get_Month(&v526 @ stack_-48_v3 (System.DateTime));\n\tv535 = System.DateTime::get_Day(&v526 @ stack_-48_v3 (System.DateTime));\n\tSystem.DateTime::.ctor(&v380 @ stack_-50_v3 (System.DateTime), v528, v532, v535, v413, v201, 0, 1);\n\tv540 = System.DateTime::op_LessThan(v380, v526);\n\tv406 = v540 == 0;\n\tif (v406) goto L_FFFFFFFF;\n\tgoto L_0154;\nL_0154:\n\tv403 = System.DateTime::AddDays(&v380 @ stack_-50_v3 (System.DateTime), 1d);\n\tgoto L_0162;\nL_0160:\n\treturn 0;\nL_FFFFFFFF:\n\tv403 = v380;\nL_0029:\n\tresetUtc._dateData = 0;\n\tv53 = System.String::IsNullOrWhiteSpace(text);\n\tv58 = v53 == 0;\n\tif (v58) goto L_0037;\nL_0162:\n\tresetUtc._dateData = v403;\n\treturn 1;\nL_00CC:\n\tv181 = System.Text.RegularExpressions.Match::get_Groups(v172);\nL_0118:\n\tv488 = v413 > 0x17;\n\tif (v488) goto L_0160;\n")]
		public static bool TryParseReset(string text, out DateTime resetUtc, DateTime nowUtc)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ClaudeLimitSignal::TryParseReset");
			resetUtc = default;
			return default;
		}
	}
}
