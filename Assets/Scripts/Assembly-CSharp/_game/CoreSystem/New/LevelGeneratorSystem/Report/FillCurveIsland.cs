using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Report
{
	[Token(Token = "0x2000330")]
	public static class FillCurveIsland
	{
		[Token(Token = "0x4000962")]
		public const string Open = "<script id=\"fc-data\" type=\"application/json\">";

		[Token(Token = "0x4000963")]
		public const string Close = "</script>";

		[Token(Token = "0x6000D9F")]
		[Address(RVA = "0x3EF3F80", Offset = "0x3EF3F80", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv60 = System.String::IndexOf(html, \"<script id=\\\"fc-data\\\" type=\\\"application/json\\\">\", 4);\n\tv106 = v60 & 0x80000000;\n\tv107 = v106 == 0;\n\tv63 = ~v107;\n\tif (v63) goto L_004B;\n\tv84 = \"<script id=\\\"fc-data\\\" type=\\\"application/json\\\">\";\n\tv69 = v84.Length + v60;\n\tv61 = System.String::IndexOf(html, \"</script>\", v69, 4);\n\tv111 = v61 & 0x80000000;\n\tv112 = v111 == 0;\n\tv64 = ~v112;\n\tif (v64) goto L_004B;\n\tv93 = v61 - v69;\n\treturnVal3 = System.String::Substring(html, v69, v93);\n\treturn returnVal3;\nL_004B:\n\treturn 0;\nL_0017:\n\tv41 = System.String::IsNullOrEmpty(html);\n\tv45 = v41 == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_004B;\n")]
		public static string Extract(string html)
		{
			//IL_002e: Expected I4, but got I8
			//IL_00a3: Expected I4, but got I8
			if (!string.IsNullOrEmpty(html))
			{
				int num = html.IndexOf("<script id=\"fc-data\" type=\"application/json\">", StringComparison.Ordinal);
				if ((int)(num & 0x80000000L) == 0)
				{
					string text = "<script id=\"fc-data\" type=\"application/json\">";
					int num2 = text.Length + num;
					int num3 = html.IndexOf("</script>", num2, StringComparison.Ordinal);
					if ((int)(num3 & 0x80000000L) == 0)
					{
						int length = num3 - num2;
						return html.Substring(num2, length);
					}
				}
			}
			return null;
		}

		[Token(Token = "0x6000DA0")]
		[Address(RVA = "0x3EF4054", Offset = "0x3EF4054", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv73 = System.String::IndexOf(html, \"<script id=\\\"fc-data\\\" type=\\\"application/json\\\">\", 4);\n\tv130 = v73 & 0x80000000;\n\tv131 = v130 == 0;\n\tv76 = ~v131;\n\tif (v76) goto L_0063;\n\tv101 = \"<script id=\\\"fc-data\\\" type=\\\"application/json\\\">\";\n\tv66 = v101.Length + v73;\n\tv74 = System.String::IndexOf(html, \"</script>\", v66, 4);\n\tv134 = v74 & 0x80000000;\n\tv135 = v134 == 0;\n\tv77 = ~v135;\n\tif (v77) goto L_0063;\n\tv137 = v101.Length + v73;\n\tv141 = System.String::Substring(html, 0, v137);\n\tv146 = System.String::Substring(html, v74);\n\treturnVal3 = System.String::Concat(v141, newJson, v146);\n\treturn returnVal3;\nL_0063:\n\treturn html;\nL_001C:\n\tv50 = System.String::IsNullOrEmpty(html);\n\tv54 = v50 == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_0063;\n")]
		public static string Replace(string html, string newJson)
		{
			//IL_002e: Expected I4, but got I8
			//IL_00a3: Expected I4, but got I8
			if (!string.IsNullOrEmpty(html))
			{
				int num = html.IndexOf("<script id=\"fc-data\" type=\"application/json\">", StringComparison.Ordinal);
				if ((int)(num & 0x80000000L) == 0)
				{
					string text = "<script id=\"fc-data\" type=\"application/json\">";
					int startIndex = text.Length + num;
					int num2 = html.IndexOf("</script>", startIndex, StringComparison.Ordinal);
					if ((int)(num2 & 0x80000000L) == 0)
					{
						int length = text.Length + num;
						string text2 = html.Substring(0, length);
						string text3 = html.Substring(num2);
						return text2 + newJson + text3;
					}
				}
			}
			return html;
		}
	}
}
