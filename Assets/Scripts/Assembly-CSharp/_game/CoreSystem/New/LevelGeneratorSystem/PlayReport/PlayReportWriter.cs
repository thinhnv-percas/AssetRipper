using System;
using System.IO;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.CoreSystem.New.LevelGeneratorSystem.Report;

namespace _game.CoreSystem.New.LevelGeneratorSystem.PlayReport
{
	[Token(Token = "0x2000352")]
	public static class PlayReportWriter
	{
		[Token(Token = "0x40009C6")]
		public const string SectionStart = "<!-- PLAY-SUMMARY:START -->";

		[Token(Token = "0x40009C7")]
		public const string SectionEnd = "<!-- PLAY-SUMMARY:END -->";

		[Token(Token = "0x6000DF1")]
		[Address(RVA = "0x3F00534", Offset = "0x3F00534", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = System.String::IsNullOrEmpty(reportHtmlPath);\n\tv23 = v21 == 0;\n\tv24 = ~v23;\n\tif (v24) goto L_0034;\n\tv27 = System.IO.File::Exists(reportHtmlPath);\n\tv29 = ~v27;\n\tif (v29) goto L_0034;\n\tv61 = System.IO.File::ReadAllText(reportHtmlPath);\n\tv64 = _game.CoreSystem.New.LevelGeneratorSystem.PlayReport.PlayReportWriter::MergeCurve(v61, m, playedPercent);\n\tv67 = _game.CoreSystem.New.LevelGeneratorSystem.PlayReport.PlayReportWriter::InjectSummary(v64, m);\n\tSystem.IO.File::WriteAllText(reportHtmlPath, v67);\n\treturn reportHtmlPath;\nL_0034:\n\treturn 0;\n")]
		public static string ApplyToReport(string reportHtmlPath, PlayReportModel m, float[] playedPercent)
		{
			if (!string.IsNullOrEmpty(reportHtmlPath) && File.Exists(reportHtmlPath))
			{
				string html = File.ReadAllText(reportHtmlPath);
				string html2 = MergeCurve(html, m, playedPercent);
				string contents = InjectSummary(html2, m);
				File.WriteAllText(reportHtmlPath, contents);
				return reportHtmlPath;
			}
			return null;
		}

		[Token(Token = "0x6000DF2")]
		[Address(RVA = "0x3F005C8", Offset = "0x3F005C8", Length = "0x204")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_FFFFFFFF:\n\tv69 = \"{}\";\n\tgoto L_0031;\n\tv84 = m.Mode != 1;\n\tif (v84) goto L_0062;\n\tv109 = playedPercent == 0;\n\tv110 = ~v109;\nL_FFFFFFFF:\n\tv201 = playedPercent;\n\tif (v110) goto L_FFFFFFFF;\n\tgoto L_004A;\nL_004A:\n\tv168 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tv171 = *([v168 @ X0_v46 (Il2CppClass<System.EmptyArray`1<System.Single>>)+135]) & 1;\n\tv172 = v171 == 0;\nL_FFFFFFFF:\n\tv192 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tif (v172) goto L_00A1;\nL_0052:\n\tgoto L_005A;\nL_005A:\n\tgoto L_005D;\nL_005D:\n\tv201 = v121.Value;\nL_FFFFFFFF:\n\tv157 = 0x20;\n\tgoto L_0082;\nL_0062:\n\tv111 = playedPercent == 0;\n\tv112 = ~v111;\nL_FFFFFFFF:\n\tv201 = playedPercent;\n\tif (v112) goto L_FFFFFFFF;\n\tgoto L_006B;\nL_006B:\n\tv176 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tv179 = *([v176 @ X0_v30 (Il2CppClass<System.EmptyArray`1<System.Single>>)+135]) & 1;\n\tv180 = v179 == 0;\nL_FFFFFFFF:\n\tv213 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tif (v180) goto L_00B9;\nL_0073:\n\tgoto L_007B;\nL_007B:\n\tgoto L_007E;\nL_007E:\n\tv201 = v131.Value;\nL_FFFFFFFF:\n\tv157 = 0x28;\n\treturn returnVal2;\n\tv174 = System.Array::Empty();\n\tv185 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tv198 = *([v185 @ X0_v39 (Il2CppClass<System.EmptyArray`1<System.Single>>)+135]) & 1;\n\tv199 = v198 == 0;\n\tv187 = ~v199;\nL_FFFFFFFF:\n\tv192 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tif (v187) goto L_0052;\nL_00A1:\n\tv195 = 0x220C238(v192, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv237 = *([v195 @ X0_v36+E4]) == 0;\n\tv223 = ~v237;\n\tif (v223) goto L_005A;\n\tgoto L_00AE;\nL_00AE:\n\tgoto L_005D;\n\tv182 = System.Array::Empty();\n\tv206 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tv219 = *([v206 @ X0_v23 (Il2CppClass<System.EmptyArray`1<System.Single>>)+135]) & 1;\n\tv220 = v219 == 0;\n\tv208 = ~v220;\nL_FFFFFFFF:\n\tv213 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tif (v208) goto L_0073;\nL_00B9:\n\tv216 = 0x220C238(v213, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv257 = *([v216 @ X0_v20+E4]) == 0;\n\tv243 = ~v257;\n\tif (v243) goto L_007B;\n\tgoto L_00C6;\nL_00C6:\n\tgoto L_007E;\nL_001F:\n\tv69 = _game.CoreSystem.New.LevelGeneratorSystem.Report.FillCurveIsland::Extract(html);\n\tv66 = v69 != 0;\n\tif (v66) goto L_0031;\nL_0031:\n\tv71 = _game.CoreSystem.New.LevelGeneratorSystem.Report.FillCurveData::FromJson(v69);\nL_0082:\n\t*([v71 @ X0_v5 (_game.CoreSystem.New.LevelGeneratorSystem.Report.FillCurveData)+v157 @ X8_v6 (System.Int32)]) = v201;\n\tv240 = _game.CoreSystem.New.LevelGeneratorSystem.Report.FillCurveData::ToJson(v71);\n\treturnVal2 = _game.CoreSystem.New.LevelGeneratorSystem.Report.FillCurveIsland::Replace(html, v240);\n")]
		private static string MergeCurve(string html, PlayReportModel m, float[] playedPercent)
		{
			string text = FillCurveIsland.Extract(html);
			if (text == null)
			{
				text = "{}";
			}
			FillCurveData fillCurveData = FillCurveData.FromJson(text);
			if (m.Mode == LevelPlayMode.BasedOnPath)
			{
				bool flag = playedPercent == null;
				bool flag2 = !flag;
				float[] array = playedPercent;
				if (!flag2)
				{
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ X0_v46 (Il2CppClass<System.EmptyArray`1<System.Single>>)+135]");
					int num2 = (int)((nint)0 & (nint)1);
					bool flag3 = num2 == 0;
					nint num3 = 0;
					if (flag3)
					{
						Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ X0_v36+E4]");
						if ((nint)0 != 0)
						{
						}
					}
					array = Array.Empty<float>();
				}
				int num4 = 32;
			}
			else
			{
				bool flag4 = playedPercent == null;
				bool flag5 = !flag4;
				float[] array = playedPercent;
				if (!flag5)
				{
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ X0_v30 (Il2CppClass<System.EmptyArray`1<System.Single>>)+135]");
					int num6 = (int)((nint)0 & (nint)1);
					bool flag6 = num6 == 0;
					nint num7 = 0;
					if (flag6)
					{
						Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ X0_v20+E4]");
						if ((nint)0 != 0)
						{
						}
					}
					array = Array.Empty<float>();
				}
				int num4 = 40;
			}
			string newJson = fillCurveData.ToJson();
			return FillCurveIsland.Replace(html, newJson);
		}

		[Token(Token = "0x6000DF3")]
		[Address(RVA = "0x3F007CC", Offset = "0x3F007CC", Length = "0x1F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv77 = System.String::IndexOf(html, \"<!-- PLAY-SUMMARY:START -->\", 4);\n\tv103 = v77 & 0x80000000;\n\tv104 = v103 == 0;\n\tv105 = ~v104;\n\tif (v105) goto L_0065;\n\tv113 = System.String::IndexOf(html, \"<!-- PLAY-SUMMARY:END -->\", v77, 4);\n\tv174 = v113 & 0x80000000;\n\tv175 = v174 == 0;\n\tv120 = ~v175;\n\tif (v120) goto L_0065;\n\tv216 = System.String::Substring(html, 0, v77);\n\tv95 = \"<!-- PLAY-SUMMARY:END -->\";\n\tv205 = v95.Length + v113;\n\tv208 = System.String::Substring(html, v205);\n\tv142 = v208;\n\tgoto L_008C;\nL_0065:\n\tv187 = System.String::LastIndexOf(html, \"</div></body></html>\", 4);\n\tv176 = v187 & 0x80000000;\n\tv177 = v176 == 0;\n\tif (v177) goto L_0079;\n\tv187 = System.String::LastIndexOf(html, \"</body>\", 4);\n\tv196 = v187 & 0x80000000;\n\tv197 = v196 == 0;\n\tv152 = ~v197;\n\tif (v152) goto L_009A;\nL_0079:\n\tv216 = System.String::Substring(html, 0, v187);\n\tv202 = System.String::Substring(html, v187);\n\tv142 = v202;\nL_009A:\n\treturnVal2 = System.String::Concat(html, v62);\n\treturn returnVal2;\nL_002C:\n\tv54 = _game.CoreSystem.New.LevelGeneratorSystem.PlayReport.PlayReportHtml::BuildSection(m);\n\tv62 = System.String::Concat(\"<!-- PLAY-SUMMARY:START -->\\n\", v54, \"\\n<!-- PLAY-SUMMARY:END -->\");\nL_008C:\n\treturnVal3 = System.String::Concat(v216, v62, v142);\n\treturn returnVal3;\n")]
		private static string InjectSummary(string html, PlayReportModel m)
		{
			//IL_002e: Expected I4, but got I8
			//IL_0128: Expected I4, but got I8
			//IL_0083: Expected I4, but got I8
			//IL_016e: Expected I4, but got I8
			string text = PlayReportHtml.BuildSection(m);
			string text2 = "<!-- PLAY-SUMMARY:START -->\n" + text + "\n<!-- PLAY-SUMMARY:END -->";
			int num = html.IndexOf("<!-- PLAY-SUMMARY:START -->", StringComparison.Ordinal);
			string text3;
			string text6;
			if ((int)(num & 0x80000000L) == 0)
			{
				int num2 = html.IndexOf("<!-- PLAY-SUMMARY:END -->", num, StringComparison.Ordinal);
				if ((int)(num2 & 0x80000000L) == 0)
				{
					text3 = html.Substring(0, num);
					string text4 = "<!-- PLAY-SUMMARY:END -->";
					int startIndex = text4.Length + num2;
					string text5 = html.Substring(startIndex);
					text6 = text5;
					goto IL_020e;
				}
			}
			int num3 = html.LastIndexOf("</div></body></html>", StringComparison.Ordinal);
			if ((int)(num3 & 0x80000000L) != 0)
			{
				num3 = html.LastIndexOf("</body>", StringComparison.Ordinal);
				if ((int)(num3 & 0x80000000L) != 0)
				{
					return html + text2;
				}
			}
			text3 = html.Substring(0, num3);
			string text7 = html.Substring(num3);
			text6 = text7;
			goto IL_020e;
			IL_020e:
			return text3 + text2 + text6;
		}
	}
}
