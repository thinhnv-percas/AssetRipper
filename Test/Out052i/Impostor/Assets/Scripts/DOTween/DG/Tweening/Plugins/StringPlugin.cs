using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Options;

namespace DG.Tweening.Plugins
{
	[Token(Token = "0x2000083")]
	public class StringPlugin : ABSTweenPlugin<string, string, StringOptions>
	{
		[Token(Token = "0x4000162")]
		private static readonly StringBuilder _Buffer;

		[Token(Token = "0x4000163")]
		private static readonly List<char> _OpenedTags;

		[Token(Token = "0x6000349")]
		[Address(RVA = "0xC25AC4", Offset = "0xC25AC4", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = DG.Tweening.Core.DOGetter`1<System.String>::Invoke(t.getter);\n\tt.startValue = t.endValue;\n\tt.endValue = v17;\n\tDG.Tweening.Core.DOSetter`1<System.String>::Invoke(t.setter, t.endValue);\n\tthrow System.NullReferenceException;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<string, string, StringOptions> t, bool isRelative)
		{
			string endValue = t.getter();
			t.startValue = t.endValue;
			t.endValue = endValue;
			t.setter(t.endValue);
		}

		[Token(Token = "0x600034A")]
		[Address(RVA = "0xC25B1C", Offset = "0xC25B1C", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv30 = \"\";\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, t, fromValue, setImmediately, isRelative, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A35787]) = v46;\nL_0023:\n\tv57 = fromValue != 0;\n\tif (v57) goto L_FFFFFFFF;\n\tgoto L_002A;\nL_002A:\n\tv62 = isRelative == 0;\n\tif (v62) goto L_003D;\n\tv94 = DG.Tweening.Core.DOGetter`1<System.String>::Invoke(t.getter);\n\tv86 = System.String::Concat(v79, v94);\n\tgoto L_003D;\nL_003D:\n\tt.startValue = v79;\n\tv91 = setImmediately == 0;\n\tif (v91) goto L_0059;\n\tDG.Tweening.Core.DOSetter`1<System.String>::Invoke(t.setter, v79);\nL_0059:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<string, string, StringOptions> t, string fromValue, bool setImmediately, bool isRelative)
		{
			string text = ((fromValue != null) ? fromValue : "");
			if (isRelative)
			{
				string text2 = t.getter();
				string text3 = text + text2;
				text = text3;
			}
			t.startValue = text;
			if (setImmediately)
			{
				t.setter(text);
			}
		}

		[Token(Token = "0x600034B")]
		[Address(RVA = "0xC25BF8", Offset = "0xC25BF8", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = \"\";\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, t, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29);\n\tv33 = 1;\n\t*([1A35788]) = v33;\nL_0015:\n\tt.endValue = \"\";\n\tt.changeValue = \"\";\n\tt.startValue = \"\";\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset(TweenerCore<string, string, StringOptions> t)
		{
			t.endValue = "";
			t.changeValue = "";
			t.startValue = "";
		}

		[Token(Token = "0x600034C")]
		[Address(RVA = "0xC25C4C", Offset = "0xC25C4C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ConvertToStartValue(TweenerCore<string, string, StringOptions> t, string value)
		{
			return value;
		}

		[Token(Token = "0x600034D")]
		[Address(RVA = "0xC25C54", Offset = "0xC25C54", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void SetRelativeEndValue(TweenerCore<string, string, StringOptions> t)
		{
		}

		[Token(Token = "0x600034E")]
		[Address(RVA = "0xC25C58", Offset = "0xC25C58", Length = "0x278")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = System.Text.RegularExpressions.Regex;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, t, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv41 = \"<[^>]*>\";\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, t, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv197 = \"\";\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v197, t, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv38 = 1;\n\t*([1A35789]) = v38;\nL_001D:\n\tt.changeValue = t.endValue;\n\tv46 = System.String::IsNullOrEmpty(t.startValue);\n\tv201 = System.String::IsNullOrEmpty(t.changeValue);\n\tv203 = v46 == 0;\n\tif (v203) goto L_0031;\n\tgoto L_003F;\nL_0031:\n\tgoto L_003B;\n\tv264 = \"il2cpp_codegen_runtime_class_init\"(v249, v199, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_003B:\n\tv159 = System.Text.RegularExpressions.Regex::Replace(t.startValue, \"<[^>]*>\", \"\");\n\tv260 = v159._stringLength;\nL_003F:\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<System.String, System.String, DG.Tweening.Plugins.Options.StringOptions>)+150]) = v260;\n\tv263 = v201 == 0;\n\tif (v263) goto L_004C;\n\tgoto L_005A;\nL_004C:\n\tgoto L_0056;\n\tv281 = \"il2cpp_codegen_runtime_class_init\"(v272, v257, v253, v254, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0056:\n\tv160 = System.Text.RegularExpressions.Regex::Replace(t.changeValue, \"<[^>]*>\", \"\");\n\tv277 = v160._stringLength;\nL_005A:\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<System.String, System.String, DG.Tweening.Plugins.Options.StringOptions>)+154]) = v277;\n\tv280 = v46 == 0;\n\tif (v280) goto L_0068;\n\tv288 = v201 == 0;\n\tv289 = ~v288;\n\tif (v289) goto L_FFFFFFFF;\nL_0063:\n\tv182 = t.changeValue;\n\tv148 = v182._stringLength;\n\tgoto L_007A;\nL_0068:\n\tv183 = t.startValue;\n\tv143 = v183._stringLength;\n\tv292 = v201 == 0;\n\tif (v292) goto L_0063;\nL_007A:\n\tv54 = v145 < 4;\n\tif (v54) goto L_00CD;\n\tv342 = v145 - 1;\n\tv345 = System.String::get_Chars(t.startValue, v342);\n\tv349 = v345 & 0xFFFF;\n\tv305 = v349 != 0x3E;\n\tif (v305) goto L_00CD;\n\tv192 = v145 - 3;\nL_0094:\n\tv346 = System.String::get_Chars(t.startValue, v192);\n\tv186 = v346 & 0xFFFF;\n\tv94 = v186 == 0x3C;\n\tif (v94) goto L_00B2;\n\tv351 = v192 - 1;\n\tv306 = v192 > 0;\n\tif (v306) goto L_0094;\n\tgoto L_00CD;\nL_00B2:\n\tv341 = v192 + 1;\n\tv344 = System.String::get_Chars(t.startValue, v341);\n\tv350 = v344 & 0xFFFF;\n\tv324 = v350 == 0x2F;\n\tif (v324) goto L_00CD;\n\tv348 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<System.String, System.String, DG.Tweening.Plugins.Options.StringOptions>)+150]) + 1;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<System.String, System.String, DG.Tweening.Plugins.Options.StringOptions>)+150]) = v348;\nL_00CD:\n\tv56 = v148 < 4;\n\tif (v56) goto L_011C;\n\tv384 = v148 - 1;\n\tv386 = System.String::get_Chars(t.changeValue, v384);\n\tv389 = v386 & 0xFFFF;\n\tv355 = v389 != 0x3E;\n\tif (v355) goto L_011C;\n\tv194 = v148 - 3;\nL_00E7:\n\tv387 = System.String::get_Chars(t.changeValue, v194);\n\tv189 = v387 & 0xFFFF;\n\tv97 = v189 == 0x3C;\n\tif (v97) goto L_0105;\n\tv392 = v194 - 1;\n\tv356 = v194 > 0;\n\tif (v356) goto L_00E7;\n\tgoto L_011C;\nL_0105:\n\tv383 = v194 + 1;\n\tv385 = System.String::get_Chars(t.changeValue, v383);\n\tv390 = v385 & 0xFFFF;\n\tv369 = v390 == 0x2F;\n\tif (v369) goto L_011C;\n\tv388 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<System.String, System.String, DG.Tweening.Plugins.Options.StringOptions>)+154]) + 1;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<System.String, System.String, DG.Tweening.Plugins.Options.StringOptions>)+154]) = v388;\nL_011C:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 198 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetChangeValue(TweenerCore<string, string, StringOptions> t)
		{
			//IL_02e9: Expected O, but got I
			//IL_0436: Expected O, but got I
			t.changeValue = t.endValue;
			bool flag = string.IsNullOrEmpty(t.startValue);
			bool flag2 = string.IsNullOrEmpty(t.changeValue);
			if (flag)
			{
				int num = 0;
			}
			else
			{
				string text = Regex.Replace(t.startValue, "<[^>]*>", "");
				int num = text.Length;
			}
			if (flag2)
			{
				int num2 = 0;
			}
			else
			{
				string text2 = Regex.Replace(t.changeValue, "<[^>]*>", "");
				int num2 = text2.Length;
			}
			int num3;
			int num4;
			if (flag)
			{
				bool flag3 = !flag2;
				bool flag4 = !flag3;
				num3 = 0;
				num4 = 0;
				if (!flag4)
				{
					goto IL_0123;
				}
			}
			else
			{
				string startValue = t.startValue;
				num3 = startValue.Length;
				bool flag5 = !flag2;
				num4 = startValue.Length;
				if (flag5)
				{
					goto IL_0123;
				}
			}
			int num5 = 0;
			goto IL_0484;
			IL_0484:
			if (num4 >= 4)
			{
				int index = num4 - 1;
				char c = t.startValue[index];
				int num6 = c & 0xFFFF;
				if (num6 == 62)
				{
					int num7 = num4 - 3;
					bool flag6;
					do
					{
						char c2 = t.startValue[num7];
						int num8 = c2 & 0xFFFF;
						if (num8 != 60)
						{
							int num9 = num7 - 1;
							flag6 = num7 > 0;
							num7 = num9;
							continue;
						}
						int index2 = num7 + 1;
						char c3 = t.startValue[index2];
						int num10 = c3 & 0xFFFF;
						if (num10 != 47)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<System.String, System.String, DG.Tweening.Plugins.Options.StringOptions>)+150]");
							object obj = (nint)0 + (nint)1;
						}
						break;
					}
					while (flag6);
				}
			}
			if (num5 < 4)
			{
				return;
			}
			int index3 = num5 - 1;
			char c4 = t.changeValue[index3];
			int num11 = c4 & 0xFFFF;
			if (num11 != 62)
			{
				return;
			}
			int num12 = num5 - 3;
			while (true)
			{
				char c5 = t.changeValue[num12];
				int num13 = c5 & 0xFFFF;
				if (num13 == 60)
				{
					break;
				}
				int num14 = num12 - 1;
				bool flag7 = num12 > 0;
				num12 = num14;
				if (!flag7)
				{
					return;
				}
			}
			int index4 = num12 + 1;
			char c6 = t.changeValue[index4];
			int num15 = c6 & 0xFFFF;
			if (num15 != 47)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<System.String, System.String, DG.Tweening.Plugins.Options.StringOptions>)+154]");
				object obj2 = (nint)0 + (nint)1;
			}
			return;
			IL_0123:
			string changeValue = t.changeValue;
			num5 = changeValue.Length;
			num4 = num3;
			goto IL_0484;
		}

		[Token(Token = "0x600034F")]
		[Address(RVA = "0xC25ED0", Offset = "0xC25ED0", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = options.richTextEnabled == 0;\n\tv6 = ~v5;\n\tif (v6) goto L_000B;\n\tv27 = changeValue + 0x10;\n\tgoto L_000E;\nL_000B:\n\tv27 = options + 0x14;\nL_000E:\n\treturnVal2 = *([v27 @ X8_v2]) / unitsXSecond;\n\tv31 = -returnVal2;\n\tv41 = returnVal2 >= 0;\n\tif (v41) goto L_0021;\n\tgoto L_0021;\nL_0021:\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturn unitsXSecond;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float GetSpeedBasedDuration(StringOptions options, float unitsXSecond, string changeValue)
		{
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Expected O, but got Unknown
			//IL_003c: Expected O, but got I
			object obj = (options.richTextEnabled ? ((object)(options + 20)) : ((object)((nint)changeValue + 16)));
			float num = (float)obj / unitsXSecond;
			float num2 = 0f - num;
			if (num < 0f)
			{
				num = num2;
			}
			return num;
		}

		[Token(Token = "0x6000350")]
		[Address(RVA = "0xC25F10", Offset = "0xC25F10", Length = "0x498")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv54 = System.Math;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, options, t, isRelative, getter, setter, startValue, changeValue, elapsed, duration, v57, v58, v59, v60, v61, v62);\n\tv72 = DG.Tweening.Plugins.StringPluginExtensions;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, options, t, isRelative, getter, setter, startValue, changeValue, elapsed, duration, v57, v58, v59, v60, v61, v62);\n\tv81 = DG.Tweening.Plugins.StringPlugin;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v81, options, t, isRelative, getter, setter, startValue, changeValue, elapsed, duration, v57, v58, v59, v60, v61, v62);\n\tv66 = 1;\n\t*([1A3578A]) = v66;\nL_002F:\n\tgoto L_0038;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v67, options, t, isRelative, getter, setter, startValue, changeValue, elapsed, duration, v57, v58, v59, v60, v61, v62);\n\tv76 = DG.Tweening.Plugins.StringPlugin;\nL_0038:\n\tv84 = System.Text.StringBuilder::get_Length(v77._Buffer);\n\tv251 = System.Text.StringBuilder::Remove(v77._Buffer, 0, v84);\n\tv316 = isRelative == 0;\n\tif (v316) goto L_0093;\n\tv378 = t.loopType != 2;\n\tif (v378) goto L_0093;\n\tv312 = t.completedLoops - t.isComplete;\n\tv153 = v312 < 1;\n\tif (v153) goto L_0093;\n\tgoto L_006C;\n\tv425 = \"il2cpp_codegen_runtime_class_init\"(v415, v240, v231, v224, getter, setter, startValue, changeValue, elapsed, duration, v57, v58, v59, v60, v61, v62);\n\tv427 = DG.Tweening.Plugins.StringPlugin;\nL_006C:\n\tv431 = System.Text.StringBuilder::Append(v302._Buffer, startValue);\nL_0071:\n\tgoto L_0078;\n\tv452 = \"il2cpp_codegen_runtime_class_init\"(v442, v247, v232, v224, getter, setter, startValue, changeValue, elapsed, duration, v57, v58, v59, v60, v61, v62);\n\tv454 = DG.Tweening.Plugins.StringPlugin;\nL_0078:\n\tv439 = v312 == 0;\n\tif (v439) goto L_0082;\n\tv437 = System.Text.StringBuilder::Append(v303._Buffer, changeValue);\n\tv312 = v312 - 1;\n\tgoto L_0071;\nL_0082:\n\tv252 = System.Text.StringBuilder::ToString(v303._Buffer);\n\tv479 = System.Text.StringBuilder::get_Length(v296._Buffer);\n\tv392 = System.Text.StringBuilder::Remove(v296._Buffer, 0, v479);\nL_0093:\n\tv399 = options.richTextEnabled == 0;\n\tv400 = ~v399;\n\tif (v400) goto L_009E;\n\tv253 = System.String::IsNullOrEmpty(v289);\n\tv408 = v253 == 0;\n\tif (v408) goto L_00A2;\n\tgoto L_00A6;\nL_009E:\n\tv412 = options + 0x10;\n\tgoto L_00A3;\nL_00A2:\n\tv412 = v289 + 0x10;\nL_00A3:\n\tv140 = *([v412 @ X8_v8]);\nL_00A6:\n\tv423 = options.richTextEnabled == 0;\n\tv424 = ~v423;\n\tif (v424) goto L_00AD;\n\tv304 = changeValue + 0x10;\n\tgoto L_00B2;\nL_00AD:\n\tv304 = options + 0x14;\nL_00B2:\n\t;\n\telapsed = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);\n\tgoto L_00C3;\n\tv460 = \"il2cpp_codegen_runtime_class_init\"(v455, v248, v237, v225, getter, setter, startValue, changeValue, v451, v450, v136, v134, v59, v60, v61, v62);\nL_00C3:\n\tv123 = elapsed * *([v304 @ X8_v11]);\n\tv464 = 0x1854ED0(&v121 @ stack_-78_v2 (System.Double), t.customEase, 0, v225, getter, setter, startValue, changeValue, v123, duration, t.easeOvershootOrAmplitude, t.easePeriod, v59, v60, v61, v62);\n\tv476 = v123 >= 0;\n\tif (v476) goto L_00EC;\n\tv490 = v123 != -0.5d;\n\tif (v490) goto L_00FE;\n\tgoto L_00F1;\nL_00EC:\n\tv501 = v123 != 0.5d;\n\tif (v501) goto L_0101;\nL_00F1:\n\tv523 = v130 + v511;\n\tv524 = v130 & 1;\n\tv526 = v524 == 0;\n\tv529 = ~v526;\n\tif (v529) goto L_FFFFFFFF;\n\tgoto L_00FD;\nL_00FD:\n\tgoto L_0110;\nL_00FE:\n\tv505 = v123 + -0.5d;\n\tv130 = System.Math::Ceiling(v505);\n\tgoto L_0110;\nL_0101:\n\tv509 = v123 + 0.5d;\n\tv130 = System.Math::Floor(v509);\nL_0110:\n\tv555 = v130 != 0x7FF0000000000000;\n\tif (v555) goto L_FFFFFFFF;\n\tgoto L_0116;\nL_0116:\n\tv561 = ~v560;\n\tv149 = v560 & v561;\n\tv211 = v560 - *([v304 @ X8_v11]);\n\tv203 = v211 < 0;\n\tv195 = v211 == 0;\n\tv187 = v560 ^ *([v304 @ X8_v11]);\n\tv179 = v560 ^ v211;\n\tv171 = v187 & v179;\n\tv163 = v171 < 0;\n\tv563 = v203 == v163;\n\tv87 = ~v195;\n\tv155 = v563 & v87;\n\tv111 = ~v155;\n\tif (v111) goto L_FFFFFFFF;\n\tgoto L_012B;\nL_012B:\n\tv567 = isRelative == 0;\n\tif (v567) goto L_014C;\n\tgoto L_013A;\n\tv574 = \"il2cpp_codegen_runtime_class_init\"(v568, v248, v237, v225, getter, setter, startValue, changeValue, v132, v125, v136, v134, v59, v60, v61, v62);\n\tv576 = DG.Tweening.Plugins.StringPlugin;\nL_013A:\n\tv598 = System.Text.StringBuilder::Append(v305._Buffer, v289);\n\tv640 = DG.Tweening.Plugins.StringPlugin::Append(v598, changeValue, 0, v282, options.richTextEnabled);\n\tv656 = options.scrambleMode == 0;\n\tif (v656) goto L_FFFFFFFF;\n\tv648 = options.richTextEnabled;\n\tgoto L_015A;\nL_014C:\n\tv573 = options.scrambleMode == 0;\n\tif (v573) goto L_0186;\n\tv582 = DG.Tweening.Plugins.StringPlugin::Append(v464, changeValue, 0, v282, options.richTextEnabled);\n\tv648 = options.richTextEnabled;\nL_015A:\n\tv662 = DG.Tweening.Plugins.StringPlugin::ScrambledCharsToUse(v654, v652);\n\tgoto L_0165;\n\tv702 = v678;\n\tv703 = \"il2cpp_codegen_runtime_class_init\"(v702, v652, v651, v650, v647, setter, startValue, changeValue, v648, v125, v136, v134, v59, v60, v61, v62);\nL_0165:\n\tv699 = *([v304 @ X8_v11]) - v282;\n\tv700 = DG.Tweening.Plugins.StringPluginExtensions::AppendScrambledChars(v291, v699, v662);\nL_016F:\n\tv256 = System.Text.StringBuilder::ToString(v716);\n\tDG.Tweening.Core.DOSetter`1<System.String>::Invoke(setter, v256);\nL_0186:\n\tv583 = v140 - *([v304 @ X8_v11]);\n\tv595 = v583 < 1;\n\tif (v595) goto L_01B0;\n\tv608 = v282 / *([v304 @ X8_v11]);\n\tv610 = v608 * v140;\n\tv622 = v610 != 0x7F800000;\n\tif (v622) goto L_FFFFFFFF;\n\tgoto L_01B0;\nL_01B0:\n\tv257 = DG.Tweening.Plugins.StringPlugin::Append(v464, changeValue, 0, v282, options.richTextEnabled);\n\tv674 = *([v304 @ X8_v11]) <= v282;\n\tif (v674) goto L_01D9;\n\tv157 = v282 >= v140;\n\tif (v157) goto L_01D9;\n\tv685 = v140 - v285;\n\tv684 = options.richTextEnabled & v282;\n\tv686 = v685 + v684;\n\tv690 = DG.Tweening.Plugins.StringPlugin::Append(v257, v289, v282, v686, options.richTextEnabled);\nL_01D9:\n\tgoto L_01DD;\n\tv706 = \"il2cpp_codegen_runtime_class_init\"(v694, v249, v238, v229, v108, setter, startValue, changeValue, v131, v127, v138, v134, v59, v60, v61, v62);\n\tv708 = DG.Tweening.Plugins.StringPlugin;\nL_01DD:\n\tv716 = v306._Buffer;\n\tgoto L_016F;\n\tthrow System.NullReferenceException;\n\treturn;\n// 341 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void EvaluateAndApply(StringOptions options, Tween t, bool isRelative, DOGetter<string> getter, DOSetter<string> setter, float elapsed, string startValue, string changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice)
		{
			//IL_0047: Expected O, but got I4
			//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fc: Expected O, but got Unknown
			//IL_007d: Expected O, but got I4
			//IL_0699: Expected I4, but got O
			//IL_0210: Expected O, but got I
			//IL_00c2: Expected O, but got I4
			//IL_0232: Unknown result type (might be due to invalid IL or missing references)
			//IL_0237: Expected O, but got Unknown
			//IL_0224: Expected O, but got I
			//IL_06b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_06bb: Expected I4, but got Unknown
			//IL_017c: Expected O, but got I4
			//IL_06f1: Expected O, but got F8
			//IL_06fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_06ff: Expected I4, but got Unknown
			//IL_0740: Unknown result type (might be due to invalid IL or missing references)
			//IL_0745: Expected I4, but got Unknown
			//IL_0752: Expected O, but got F8
			//IL_03dd: Expected I4, but got O
			//IL_054b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0550: Expected I4, but got Unknown
			//IL_04e3: Expected O, but got Ref
			//IL_057e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0583: Expected I4, but got Unknown
			//IL_0500: Unknown result type (might be due to invalid IL or missing references)
			//IL_0505: Expected I4, but got Unknown
			//IL_0522: Expected F8, but got I4
			//IL_0471: Expected O, but got Ref
			int length = _Buffer.Length;
			StringBuilder stringBuilder = _Buffer.Remove(0, length);
			bool flag = !isRelative;
			object obj = 0;
			string text = startValue;
			if (!flag)
			{
				bool flag2 = t.loopType != LoopType.Incremental;
				obj = 0;
				text = startValue;
				if (!flag2)
				{
					int num = t.completedLoops - (t.isComplete ? 1 : 0);
					bool flag3 = num < 1;
					obj = 0;
					text = startValue;
					if (!flag3)
					{
						StringBuilder stringBuilder2 = _Buffer.Append(startValue);
						while (num != 0)
						{
							StringBuilder stringBuilder3 = _Buffer.Append(changeValue);
							num--;
						}
						string text2 = _Buffer.ToString();
						int length2 = _Buffer.Length;
						StringBuilder stringBuilder4 = _Buffer.Remove(0, length2);
						obj = 0;
						text = text2;
					}
				}
			}
			int num2;
			object obj2;
			if (!options.richTextEnabled)
			{
				if (string.IsNullOrEmpty(text))
				{
					num2 = 0;
					goto IL_0664;
				}
				obj2 = (nint)text + 16;
			}
			else
			{
				obj2 = options + 16;
			}
			num2 = (int)obj2;
			goto IL_0664;
			IL_0527:
			StringBuilder stringBuilder6;
			StringBuilder stringBuilder5 = stringBuilder6;
			goto IL_0832;
			IL_0390:
			double num4;
			double num3 = ((num4 != 9.218868437227405E+18) ? num4 : 1.0609978955E-314);
			object obj3 = ~num3;
			int num5 = num3 & (nint)obj3;
			object obj4;
			double num6 = num3 - (double)obj4;
			bool flag4 = num6 < 0.0;
			bool flag5 = num6 == 0.0;
			int num7 = num3 ^ obj4;
			object obj5 = num3 ^ num6;
			int num8 = (int)(num7 & (nint)obj5);
			bool flag6 = num8 < 0;
			bool flag7 = flag4 == flag6;
			bool flag8 = !flag5;
			int num9 = ((!(flag7 && flag8)) ? num5 : ((int)obj4));
			bool richTextEnabled;
			StringOptions options2;
			StringPlugin stringPlugin;
			if (isRelative)
			{
				StringBuilder stringBuilder7 = _Buffer.Append(text);
				StringBuilder stringBuilder8 = ((StringPlugin)(object)stringBuilder7).Append(changeValue, 0, num9, options.richTextEnabled);
				bool flag9 = options.scrambleMode == ScrambleMode.None;
				stringBuilder6 = stringBuilder8;
				if (flag9)
				{
					goto IL_0527;
				}
				richTextEnabled = options.richTextEnabled;
				options2 = (StringOptions)(&richTextEnabled);
				stringPlugin = (StringPlugin)(object)stringBuilder8;
				stringBuilder6 = stringBuilder8;
			}
			else
			{
				StringPlugin stringPlugin2 = default(StringPlugin);
				if (options.scrambleMode == ScrambleMode.None)
				{
					int num10 = num2 - obj4;
					bool flag10 = num10 < 1;
					int num11 = num9;
					if (!flag10)
					{
						int num12 = num9 / obj4;
						int num13 = num12 * num2;
						if (num13 == 2139095040)
						{
							num4 = num13;
							num11 = int.MinValue;
						}
						else
						{
							num4 = num13;
							num11 = num13;
						}
					}
					StringBuilder stringBuilder9 = stringPlugin2.Append(changeValue, 0, num9, options.richTextEnabled);
					if ((nint)obj4 > num9 && num9 < num2)
					{
						int num14 = num2 - num11;
						int num15 = (options.richTextEnabled ? 1 : 0) & num9;
						int length3 = num14 + num15;
						StringBuilder stringBuilder10 = ((StringPlugin)(object)stringBuilder9).Append(text, num9, length3, options.richTextEnabled);
					}
					stringBuilder5 = _Buffer;
					goto IL_0832;
				}
				StringBuilder stringBuilder11 = stringPlugin2.Append(changeValue, 0, num9, options.richTextEnabled);
				richTextEnabled = options.richTextEnabled;
				options2 = (StringOptions)(&richTextEnabled);
				stringPlugin = (StringPlugin)(object)stringBuilder11;
				stringBuilder6 = stringBuilder11;
			}
			char[] chars = stringPlugin.ScrambledCharsToUse(options2);
			int length4 = obj4 - num9;
			StringBuilder stringBuilder12 = stringBuilder6.AppendScrambledChars(length4, chars);
			num4 = (richTextEnabled ? 1 : 0);
			goto IL_0527;
			IL_0664:
			obj4 = (options.richTextEnabled ? ((object)(options + 20)) : ((object)((nint)changeValue + 16)));
			float num16 = EaseManager.Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);
			float num17 = elapsed * (float)obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854ED0 (native modf)");
			double num18;
			double num19 = default(double);
			if (num17 < 0f)
			{
				if ((double)num17 != -0.5)
				{
					double a = (double)num17 + -0.5;
					num4 = Math.Ceiling(a);
					goto IL_0390;
				}
				num18 = -1.0;
				num4 = num19;
			}
			else
			{
				if ((double)num17 != 0.5)
				{
					double d = (double)num17 + 0.5;
					num4 = Math.Floor(d);
					goto IL_0390;
				}
				num18 = 1.0;
				num4 = num19;
			}
			double num20 = num4 + num18;
			if ((num4 & 1) != 0)
			{
				num4 = num20;
			}
			goto IL_0390;
			IL_0832:
			string pNewValue = stringBuilder5.ToString();
			setter(pNewValue);
		}

		[Token(Token = "0x6000351")]
		[Address(RVA = "0xC263A8", Offset = "0xC263A8", Length = "0x6C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0040;\n\tv40 = Il2CppMethodInfo;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, value, startIndex, length, richTextEnabled, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv63 = System.Char[];\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, value, startIndex, length, richTextEnabled, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv72 = Il2CppMethodInfo;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, value, startIndex, length, richTextEnabled, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv79 = Il2CppMethodInfo;\n\tv80 = \"il2cpp_codegen_initialize_runtime_metadata\"(v79, value, startIndex, length, richTextEnabled, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv395 = Il2CppMethodInfo;\n\tv396 = \"il2cpp_codegen_initialize_runtime_metadata\"(v395, value, startIndex, length, richTextEnabled, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv457 = Il2CppMethodInfo;\n\tv458 = \"il2cpp_codegen_initialize_runtime_metadata\"(v457, value, startIndex, length, richTextEnabled, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv534 = Il2CppMethodInfo;\n\tv535 = \"il2cpp_codegen_initialize_runtime_metadata\"(v534, value, startIndex, length, richTextEnabled, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv661 = System.Text.RegularExpressions.Regex;\n\tv662 = \"il2cpp_codegen_initialize_runtime_metadata\"(v661, value, startIndex, length, richTextEnabled, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv671 = DG.Tweening.Plugins.StringPlugin;\n\tv672 = \"il2cpp_codegen_initialize_runtime_metadata\"(v671, value, startIndex, length, richTextEnabled, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv697 = \"<.*?(>)\";\n\tv698 = \"il2cpp_codegen_initialize_runtime_metadata\"(v697, value, startIndex, length, richTextEnabled, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv730 = \"(</).*?>\";\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v730, value, startIndex, length, richTextEnabled, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv57 = 1;\n\t*([1A3578B]) = v57;\nL_0040:\n\tgoto L_0045;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v58, value, startIndex, length, richTextEnabled, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv67 = DG.Tweening.Plugins.StringPlugin;\nL_0045:\n\tv70 = richTextEnabled == 0;\n\tif (v70) goto L_01F3;\n\tv74 = v68._OpenedTags;\n\tv82 = v74._version + 1;\n\tv74._size = 0;\n\tv74._version = v82;\n\tv408 = v91 < 1;\n\tif (v408) goto L_FFFFFFFF;\n\tv174 = value._stringLength - 1;\nL_006C:\n\tv590 = v788 > v174;\n\tif (v590) goto L_01EB;\n\tv664 = System.String::get_Chars(value, v788);\n\tv673 = v664 & 0xFFFF;\n\tv683 = v673 != 0x3C;\n\tif (v683) goto L_00DF;\n\tv128 = v788 + 1;\n\tv700 = System.String::get_Chars(value, v128);\n\tv732 = v700 & 0xFFFF;\n\tv735 = v788 - v174;\n\tv736 = v735 < 0;\n\tv738 = v788 ^ v174;\n\tv739 = v788 ^ v735;\n\tv740 = v738 & v739;\n\tv741 = v740 < 0;\n\tv742 = v736 == v741;\n\tv275 = v732 - 0x2F;\n\tv249 = v275 == 0;\n\tv185 = ~v249;\n\tgoto L_00A3;\n\tv765 = \"il2cpp_codegen_runtime_class_init\"(v731, v152, v135, v89, richTextEnabled, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv767 = DG.Tweening.Plugins.StringPlugin;\nL_00A3:\n\tv542 = v742 | v185;\n\tv310 = v366._OpenedTags;\n\tv768 = ~v542;\n\tif (v768) goto L_00F7;\n\tv802 = v700 & 0xFFFF;\n\tv111 = v802 != 0x23;\n\tif (v111) goto L_FFFFFFFF;\n\tgoto L_00BC;\nL_00BC:\n\tv365 = v310._items;\n\tv105 = v310._version + 1;\n\tv310._version = v105;\n\tv823 = v310._size;\n\tv849 = v310._size < v365.Length;\n\tv834 = ~v849;\n\tif (v834) goto L_00FE;\n\tv836 = v310._size + 1;\n\tv310._size = v836;\n\tv365[v823 @ X10_v11 (System.Int32)] = v151;\n\tgoto L_0102;\nL_00DF:\n\tv192 = v788 < v573;\n\tif (v192) goto L_FFFFFFFF;\n\tgoto L_00EF;\n\tv769 = \"il2cpp_codegen_runtime_class_init\"(v747, v166, v147, v89, richTextEnabled, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv771 = DG.Tweening.Plugins.StringPlugin;\nL_00EF:\n\tv756 = System.Text.StringBuilder::Append(v378._Buffer, v664);\n\tgoto L_01DB;\nL_00F7:\n\tv812 = v310._size - 1;\n\tSystem.Collections.Generic.List`1<System.Char>::RemoveAt(v310, v812);\n\tgoto L_0102;\nL_00FE:\n\tSystem.Collections.Generic.List`1<System.Char>::AddWithResize(v310, v151);\nL_0102:\n\tv844 = System.String::Substring(value, v788);\n\tgoto L_0112;\n\tv858 = v852;\n\tv859 = \"il2cpp_codegen_runtime_class_init\"(v858, v842, v843, v89, richTextEnabled, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_0112:\n\tv311 = System.Text.RegularExpressions.Regex::Match(v844, \"<.*?(>)\");\n\tv784 = System.Text.RegularExpressions.Group::get_Success(v311);\n\tv785 = v784 == 0;\n\tif (v785) goto L_01DB;\n\tv870 = v177 | v542;\n\tv871 = v870 & 1;\n\tv872 = v871 == 0;\n\tv873 = ~v872;\n\tif (v873) goto L_01BC;\n\tv877 = System.String::get_Chars(value, v128);\n\tv368 = v877 & 0xFFFF;\n\tv186 = v368 != 0x63;\n\tif (v186) goto L_014C;\n\t// 309 NewArr v312 @ X0_v113 (System.Char[]), typeof(System.Char[]), 2\n\tv312[0] = 0x23;\n\tv312[1] = 0x63;\n\tgoto L_0157;\nL_014C:\n\t// 332 NewArr v313 @ X0_v112 (System.Char[]), typeof(System.Char[]), 1\n\tv313[0] = v877;\nL_0157:\n\tv900 = v788 < 1;\n\tif (v900) goto L_01BC;\nL_015F:\n\tv122 = v179 - 1;\n\tv990 = System.String::get_Chars(value, v122);\n\tv991 = v990 & 0xFFFF;\n\tv1001 = v991 != 0x3C;\n\tif (v1001) goto L_019A;\n\tv1007 = System.String::get_Chars(value, v179);\n\tv1026 = v1007 & 0xFFFF;\n\tv1017 = v1026 == 0x2F;\n\tif (v1017) goto L_019A;\n\tv1030 = v179 + 1;\n\tv1033 = System.String::get_Chars(value, v1030);\n\tv1023 = System.Array::IndexOf(v880, v1033);\n\tv1024 = v1023 + 1;\n\tv252 = v1024 == 0;\n\tv187 = ~v252;\n\tif (v187) goto L_01A1;\nL_019A:\n\tv888 = v179 >= 2;\n\tif (v888) goto L_015F;\n\tgoto L_01BC;\nL_01A1:\n\tgoto L_01AA;\n\tv1040 = \"il2cpp_codegen_runtime_class_init\"(v1036, v1009, v1008, v89, richTextEnabled, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv1042 = DG.Tweening.Plugins.StringPlugin;\nL_01AA:\n\tv1048 = System.String::IndexOf(value, 0x3E, v122);\n\tv369 = v1048 - v179;\n\tv138 = v369 + 2;\n\tv314 = System.String::Substring(value, v122, v138);\n\tv906 = System.Text.StringBuilder::Insert(v1043._Buffer, 0, v314);\nL_01BC:\n\tgoto L_01C3;\n\tv923 = \"il2cpp_codegen_runtime_class_init\"(v915, v883, v139, v91, richTextEnabled, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv925 = DG.Tweening.Plugins.StringPlugin;\nL_01C3:\n\tv315 = System.Text.RegularExpressions.Capture::get_Value(v311);\n\tv933 = System.Text.StringBuilder::Append(v370._Buffer, v315);\n\tv316 = System.Text.RegularExpressions.Match::get_Groups(v311);\n\tv317 = System.Text.RegularExpressions.GroupCollection::get_Item(v316, 1);\n\tv783 = v317.<Index>k__BackingField + 1;\n\tv574 = v783 + v574;\n\tv573 = v783 + v573;\n\tv788 = v317.<Index>k__BackingField + v788;\nL_01DB:\n\tv363 = v788 + 1;\n\tv551 = v363 < v574;\n\tif (v551) goto L_006C;\nL_01EB:\n\tgoto L_01F9;\nL_01F3:\n\tv393 = System.Text.StringBuilder::Append(v68._Buffer, value, startIndex, v91);\n\tgoto L_02BB;\nL_01F9:\n\tgoto L_01FD;\n\tv667 = \"il2cpp_codegen_runtime_class_init\"(v612, v160, v142, v92, richTextEnabled, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv668 = DG.Tweening.Plugins.StringPlugin;\nL_01FD:\n\tv372 = v669._OpenedTags;\n\tv695 = v372._size < 1;\n\tif (v695) goto L_02A9;\n\tv386 = value._stringLength - 1;\n\tv712 = v363 >= v386;\n\tif (v712) goto L_02A9;\nL_0224:\n\tgoto L_0228;\n\tv804 = \"il2cpp_codegen_runtime_class_init\"(v793, v167, v148, v92, richTextEnabled, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv805 = DG.Tweening.Plugins.StringPlugin;\nL_0228:\n\tv379 = v806._OpenedTags;\n\tv714 = v363 >= v386;\n\tif (v714) goto L_02A9;\n\tv190 = v379._size <= 0;\n\tif (v190) goto L_02A9;\n\tv848 = System.String::Substring(value, v363);\n\tgoto L_0253;\n\tv863 = v373;\n\tv864 = \"il2cpp_codegen_runtime_class_init\"(v863, v846, v847, v92, richTextEnabled, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_0253:\n\tv319 = System.Text.RegularExpressions.Regex::Match(v848, \"(</).*?>\");\n\tv867 = System.Text.RegularExpressions.Group::get_Success(v319);\n\tv725 = v867 == 0;\n\tif (v725) goto L_02A9;\n\tv320 = System.Text.RegularExpressions.Capture::get_Value(v319);\n// ... truncated")]
		private StringBuilder Append(string value, int startIndex, int length, bool richTextEnabled)
		{
			int num = default(int);
			if (richTextEnabled)
			{
				List<char> openedTags = _OpenedTags;
				int version = openedTags._version + 1;
				openedTags._size = 0;
				openedTags._version = version;
				int num6;
				if (num >= 1)
				{
					int num2 = value.Length - 1;
					bool flag = false;
					int num3 = startIndex;
					int num4 = num;
					int num5 = 0;
					bool flag10;
					do
					{
						bool flag2 = num5 > num2;
						num6 = num5;
						if (flag2)
						{
							break;
						}
						char c = value[num5];
						int num7 = c & 0xFFFF;
						bool flag8;
						if (num7 == 60)
						{
							int index = num5 + 1;
							char c2 = value[index];
							int num8 = c2 & 0xFFFF;
							int num9 = num5 - num2;
							bool flag3 = num9 < 0;
							int num10 = num5 ^ num2;
							int num11 = num5 ^ num9;
							int num12 = num10 & num11;
							bool flag4 = num12 < 0;
							bool flag5 = flag3 == flag4;
							int num13 = num8 - 47;
							bool flag6 = num13 == 0;
							bool flag7 = !flag6;
							flag8 = flag5 || flag7;
							List<char> openedTags2 = _OpenedTags;
							if (flag8)
							{
								int num14 = c2 & 0xFFFF;
								char c3 = ((num14 != 35) ? c2 : 'c');
								char[] items = openedTags2._items;
								int version2 = openedTags2._version + 1;
								openedTags2._version = version2;
								int count = openedTags2.Count;
								if (openedTags2.Count < items.Length)
								{
									int size = openedTags2.Count + 1;
									openedTags2._size = size;
									items[count] = c3;
								}
								else
								{
									openedTags2.Add(c3);
								}
							}
							else
							{
								int index2 = openedTags2.Count - 1;
								openedTags2.RemoveAt(index2);
							}
							string input = value.Substring(num5);
							Match match = Regex.Match(input, "<.*?(>)");
							if (match.Success)
							{
								int num15 = ((flag || flag8) ? 1 : 0);
								if ((num15 & 1) == 0)
								{
									char c4 = value[index];
									int num16 = c4 & 0xFFFF;
									char[] array = ((num16 != 99) ? new char[1] { c4 } : new char[2] { '#', 'c' });
									if (num5 >= 1)
									{
										int num17 = num5;
										bool flag9;
										do
										{
											int num18 = num17 - 1;
											char c5 = value[num18];
											int num19 = c5 & 0xFFFF;
											if (num19 == 60)
											{
												char c6 = value[num17];
												int num20 = c6 & 0xFFFF;
												if (num20 != 47)
												{
													int index3 = num17 + 1;
													char value2 = value[index3];
													int num21 = Array.IndexOf(array, value2);
													if (num21 + 1 != 0)
													{
														int num22 = value.IndexOf('>', num18);
														int num23 = num22 - num17;
														int length2 = num23 + 2;
														string value3 = value.Substring(num18, length2);
														StringBuilder stringBuilder = _Buffer.Insert(0, value3);
														break;
													}
												}
											}
											flag9 = num17 >= 2;
											num17 = num18;
										}
										while (flag9);
									}
								}
								string value4 = match.Value;
								StringBuilder stringBuilder2 = _Buffer.Append(value4);
								GroupCollection groups = match.Groups;
								Group obj = groups[1];
								int num24 = obj.Index + 1;
								num4 = num24 + num4;
								num3 = num24 + num3;
								num5 = obj.Index + num5;
							}
						}
						else
						{
							if (num5 >= num3)
							{
								StringBuilder stringBuilder3 = _Buffer.Append(c);
							}
							flag8 = flag;
						}
						num6 = num5 + 1;
						flag10 = num6 < num4;
						flag = flag8;
						num5 = num6;
					}
					while (flag10);
				}
				else
				{
					num6 = 0;
				}
				List<char> openedTags3 = _OpenedTags;
				if (openedTags3.Count >= 1)
				{
					int num25 = value.Length - 1;
					if (num6 < num25)
					{
						while (true)
						{
							List<char> openedTags4 = _OpenedTags;
							if (num6 < num25 && openedTags4.Count > 0)
							{
								string input2 = value.Substring(num6);
								Match match2 = Regex.Match(input2, "(</).*?>");
								if (match2.Success)
								{
									string value5 = match2.Value;
									char c7 = value5[2];
									List<char> openedTags5 = _OpenedTags;
									int index4 = openedTags5.Count - 1;
									char c8 = openedTags5[index4];
									int num26 = c7 & 0xFFFF;
									if (num26 == c8)
									{
										string value6 = match2.Value;
										StringBuilder stringBuilder4 = _Buffer.Append(value6);
										List<char> openedTags6 = _OpenedTags;
										int index5 = openedTags6.Count - 1;
										openedTags6.RemoveAt(index5);
									}
									string value7 = match2.Value;
									num6 = value7.Length + num6;
									continue;
								}
								break;
							}
							break;
						}
					}
				}
			}
			else
			{
				StringBuilder stringBuilder5 = _Buffer.Append(value, startIndex, num);
			}
			return _Buffer;
		}

		[Token(Token = "0x6000352")]
		[Address(RVA = "0xC26A6C", Offset = "0xC26A6C", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = DG.Tweening.Plugins.StringPluginExtensions;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, options, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29);\n\tv33 = 1;\n\t*([1A3578C]) = v33;\nL_0011:\n\tv35 = options.scrambleMode - 2;\n\tv36 = v35 < 3;\n\tv37 = ~v36;\n\tv38 = v35 - 3;\n\tv40 = v38 == 0;\n\tv45 = ~v40;\n\tv46 = v37 & v45;\n\tif (v46) goto L_0037;\n\tv48 = 0x424000 + 0x16C;\n\tv51 = *([v48 @ X9_v2 (System.Int32)+v35 @ X8_v4 (System.Int32)]) << 2;\n\tv52 = 0xC2AAC0 + v51;\n\t// 36 IndirectJump v52 @ X10_v2 (System.Int32), v30 @ X0_v1 (DG.Tweening.Plugins.StringPlugin), v30 @ X0_v1 (DG.Tweening.Plugins.StringPlugin), options @ X1 (DG.Tweening.Plugins.Options.StringOptions), methodInfo @ X2 (Il2CppMethodInfo), v17 @ X3, v18 @ X4, v19 @ X5, v20 @ X6, v21 @ X7, v22 @ V0, v23 @ V1, v24 @ V2, v25 @ V3, v26 @ V4, v27 @ V5, v28 @ V6, v29 @ V7\n\tX19 = *([1937600]);\n\tX0 = *([X19]);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_002E;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X19]);\nL_002E:\n\tX8 = *([X0+B8]);\n\tX8 = X8 + 8;\n\tgoto L_005A;\nL_0037:\n\tgoto L_003B;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v55, options, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29);\n\tv80 = DG.Tweening.Plugins.StringPluginExtensions;\nL_003B:\n\tgoto L_005A;\n\tX19 = *([1937600]);\n\tX0 = *([X19]);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0045;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X19]);\nL_0045:\n\tX8 = *([X0+B8]);\n\tX8 = X8 + 0x10;\n\tgoto L_005A;\n\tX19 = *([1937600]);\n\tX0 = *([X19]);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0051;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X19]);\nL_0051:\n\tX8 = *([X0+B8]);\n\tX8 = X8 + 0x18;\n\tgoto L_005A;\n\tX8 = X19 + 8;\nL_005A:\n\treturn v75.ScrambledCharsAll;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private char[] ScrambledCharsToUse(StringOptions options)
		{
			int num = (int)(options.scrambleMode - 2);
			bool flag = num < 3;
			bool flag2 = !flag;
			int num2 = num - 3;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 4341760 + 364;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X9_v2 (System.Int32)+v35 @ X8_v4 (System.Int32)]");
				int num4 = (int)((nint)0 << 2);
				int num5 = 12757696 + num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v52 @ X10_v2 (System.Int32) (should have been resolved before IL gen)");
			}
			return StringPluginExtensions.ScrambledCharsAll;
		}

		[Token(Token = "0x6000353")]
		[Address(RVA = "0xC26C98", Offset = "0xC26C98", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A3578D]) = v37;\nL_001A:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<System.Object, System.Object, DG.Tweening.Plugins.Options.StringOptions>::.ctor(this);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public StringPlugin()
		{
		}

		[Token(Token = "0x6000354")]
		[Address(RVA = "0xC26CE0", Offset = "0xC26CE0", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv51 = System.Collections.Generic.List`1<System.Char>;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv56 = System.Text.StringBuilder;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv63 = DG.Tweening.Plugins.StringPlugin;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv47 = 1;\n\t*([1A3578E]) = v47;\nL_0024:\n\tv49 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v49);\n\tv59._Buffer = v49;\n\tv61 = new System.Collections.Generic.List`1<System.Char>();\n\tSystem.Collections.Generic.List`1<System.Char>::.ctor(v61);\n\tv69._OpenedTags = v61;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static StringPlugin()
		{
			StringBuilder buffer = new StringBuilder();
			_Buffer = buffer;
			List<char> openedTags = new List<char>();
			_OpenedTags = openedTags;
		}
	}
}
