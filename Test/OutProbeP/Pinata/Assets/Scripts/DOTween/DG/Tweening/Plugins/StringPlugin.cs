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
	[Token(Token = "0x200002B")]
	public class StringPlugin : ABSTweenPlugin<string, string, StringOptions>
	{
		[Token(Token = "0x40000D2")]
		private static readonly StringBuilder _Buffer;

		[Token(Token = "0x40000D3")]
		private static readonly List<char> _OpenedTags;

		[Token(Token = "0x6000200")]
		[Address(RVA = "0x10DC350", Offset = "0x10DC350", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EFBC28]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, t, isRelative, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([20274CB]) = v38;\nL_001C:\n\tv47 = DG.Tweening.Core.DOGetter`1<System.String>::Invoke(t.getter);\n\tt.startValue = t.endValue;\n\tt.endValue = v47;\n\tDG.Tweening.Core.DOSetter`1<System.String>::Invoke(t.setter, t.endValue);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<string, string, StringOptions> t, bool isRelative)
		{
			string endValue = t.getter();
			t.startValue = t.endValue;
			t.endValue = endValue;
			t.setter(t.endValue);
		}

		[Token(Token = "0x6000201")]
		[Address(RVA = "0x10DC3D8", Offset = "0x10DC3D8", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EB73E8]);\n\tv27 = *([v26 @ X8_v7]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, t, fromValue, setImmediately, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([20274CC]) = v44;\nL_0019:\n\tt.startValue = fromValue;\n\tv47 = setImmediately == 0;\n\tif (v47) goto L_0034;\n\tDG.Tweening.Core.DOSetter`1<System.String>::Invoke(t.setter, fromValue);\n\treturn;\nL_0034:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<string, string, StringOptions> t, string fromValue, bool setImmediately)
		{
			t.startValue = fromValue;
			if (setImmediately)
			{
				t.setter(fromValue);
			}
		}

		[Token(Token = "0x6000202")]
		[Address(RVA = "0x10DC464", Offset = "0x10DC464", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tt.endValue = 0;\n\tt.changeValue = 0;\n\tt.startValue = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset(TweenerCore<string, string, StringOptions> t)
		{
			t.endValue = null;
			t.changeValue = null;
			t.startValue = null;
		}

		[Token(Token = "0x6000203")]
		[Address(RVA = "0x10DC484", Offset = "0x10DC484", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ConvertToStartValue(TweenerCore<string, string, StringOptions> t, string value)
		{
			return value;
		}

		[Token(Token = "0x6000204")]
		[Address(RVA = "0x10DC48C", Offset = "0x10DC48C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void SetRelativeEndValue(TweenerCore<string, string, StringOptions> t)
		{
		}

		[Token(Token = "0x6000205")]
		[Address(RVA = "0x10DC490", Offset = "0x10DC490", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EDEE60]);\n\tv23 = *([v22 @ X8_v14]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, t, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 0 | 1;\n\t*([20274CD]) = v42;\nL_0019:\n\tt.changeValue = t.endValue;\n\tgoto L_002E;\n\tv53 = *([v48 @ X0_v5+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_002E;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v48, t, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002E:\n\tv68 = System.Text.RegularExpressions.Regex::Replace(t.startValue, \"<[^>]*>\", \"\");\n\tt.plugOptions.startValueStrippedLength = v68.m_stringLength;\n\tv78 = System.Text.RegularExpressions.Regex::Replace(t.changeValue, \"<[^>]*>\", \"\");\n\tt.plugOptions.changeValueStrippedLength = v78.m_stringLength;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetChangeValue(TweenerCore<string, string, StringOptions> t)
		{
			t.changeValue = t.endValue;
			string text = Regex.Replace(t.startValue, "<[^>]*>", "");
			t.plugOptions.startValueStrippedLength = text.Length;
			string text2 = Regex.Replace(t.changeValue, "<[^>]*>", "");
			t.plugOptions.changeValueStrippedLength = text2.Length;
		}

		[Token(Token = "0x6000206")]
		[Address(RVA = "0x10DC55C", Offset = "0x10DC55C", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~options.richTextEnabled;\n\tif (v2) goto L_0007;\n\tv7 = options + 0x14;\n\tgoto L_000A;\nL_0007:\n\tv7 = changeValue + 0x10;\nL_000A:\n\treturnVal2 = *([v7 @ X8_v2]) / unitsXSecond;\n\tv13 = -returnVal2;\n\tv23 = returnVal2 >= 0;\n\tif (v23) goto L_001B;\n\tgoto L_001B;\nL_001B:\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturn unitsXSecond;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float GetSpeedBasedDuration(StringOptions options, float unitsXSecond, string changeValue)
		{
			//IL_0040: Expected O, but got I
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected O, but got Unknown
			object obj = ((!options.richTextEnabled) ? ((object)((long)(IntPtr)changeValue + 16L)) : ((object)(options + 20)));
			float num = (float)obj / unitsXSecond;
			float num2 = 0f - num;
			if (num < 0f)
			{
				num = num2;
			}
			return num;
		}

		[Token(Token = "0x6000207")]
		[Address(RVA = "0x10DC5A0", Offset = "0x10DC5A0", Length = "0x4C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv56 = *([1EC06E8]);\n\tv57 = *([v56 @ X8_v76]);\n\tv58 = \"il2cpp_codegen_initialize_method\"(v57, options, t, isRelative, getter, setter, startValue, changeValue, elapsed, duration, v60, v61, v62, v63, v64, v65);\n\tv68 = 0 | 1;\n\t*([20274CE]) = v68;\nL_002C:\n\tgoto L_0039;\n\tv75 = *([v71 @ X0_v2 (Il2CppClass<DG.Tweening.Plugins.StringPlugin>)+E0]);\n\tv76 = v75 == 0;\n\tv77 = ~v76;\n\t// 48 Jump @b93\n\tv85 = \"il2cpp_codegen_runtime_class_init\"(v71, options, t, isRelative, getter, setter, startValue, changeValue, elapsed, duration, v60, v61, v62, v63, v64, v65);\n\tv79 = DG.Tweening.Plugins.StringPlugin;\nL_0039:\n\tv88 = System.Text.StringBuilder::get_Length(v82._Buffer);\n\tv220 = System.Text.StringBuilder::Remove(v82._Buffer, 0, v88);\n\tv403 = isRelative == 0;\n\tif (v403) goto L_00B8;\n\tv404 = t.loopType != 2;\n\tif (v404) goto L_00B8;\n\tv400 = t.completedLoops - t.isComplete;\n\tv299 = v400 < 1;\n\tif (v299) goto L_00B8;\n\tgoto L_0071;\n\tv505 = *([v494 @ X0_v47 (Il2CppClass<DG.Tweening.Plugins.StringPlugin>)+E0]);\n\tv506 = v505 == 0;\n\tv507 = ~v506;\n\t// 104 ConditionalJump @b94, v507 @ TEMP_v78\n\tv522 = \"il2cpp_codegen_runtime_class_init\"(v494, v213, v206, v200, getter, setter, startValue, changeValue, elapsed, duration, v60, v61, v62, v63, v64, v65);\n\tv509 = DG.Tweening.Plugins.StringPlugin;\nL_0071:\n\tv525 = System.Text.StringBuilder::Append(v394._Buffer, startValue);\n\tv536 = DG.Tweening.Plugins.StringPlugin;\n\tv539 = *([v536 @ X0_v51 (Il2CppClass<DG.Tweening.Plugins.StringPlugin>)+12F]) >> 1;\n\tv566 = v539 & 1;\nL_0077:\n\tv568 = v566 & 1;\n\tv569 = v568 == 0;\n\tif (v569) goto L_0086;\n\tgoto L_0086;\n\tv621 = \"il2cpp_codegen_runtime_class_init\"(v563, v361, v356, v200, getter, setter, startValue, changeValue, elapsed, duration, v60, v61, v62, v63, v64, v65);\n\tv582 = DG.Tweening.Plugins.StringPlugin;\nL_0086:\n\tv622 = System.Text.StringBuilder::Append(v395._Buffer, changeValue);\n\tv564 = DG.Tweening.Plugins.StringPlugin;\n\tv387 = v387 + 1;\n\tv628 = *([v564 @ X0_v56 (Il2CppClass<DG.Tweening.Plugins.StringPlugin>)+12E]) >> 9;\n\tv566 = v628 & 1;\n\tv138 = v387 < v400;\n\tif (v138) goto L_0077;\n\tgoto L_00A8;\n\tv640 = *([v564 @ X0_v56 (Il2CppClass<DG.Tweening.Plugins.StringPlugin>)+E0]);\n\tv641 = v640 == 0;\n\tv642 = ~v641;\n\t// 158 ConditionalJump @b97, v642 @ TEMP_v74\n\tv683 = \"il2cpp_codegen_runtime_class_init\"(v564, v362, v207, v200, getter, setter, startValue, changeValue, elapsed, duration, v60, v61, v62, v63, v64, v65);\n\tv644 = DG.Tweening.Plugins.StringPlugin;\nL_00A8:\n\tv221 = System.Text.StringBuilder::ToString(v396._Buffer);\n\tv713 = System.Text.StringBuilder::get_Length(v257._Buffer);\n\tv416 = System.Text.StringBuilder::Remove(v257._Buffer, 0, v713);\nL_00B8:\n\tv421 = ~options.richTextEnabled;\n\tif (v421) goto L_00C4;\n\tv489 = options + 0x10;\n\tv487 = options + 0x14;\n\tv483 = t == 0;\n\tv229 = ~v483;\n\tif (v229) goto L_00D1;\n\tgoto L_021A;\nL_00C4:\n\tv489 = v250 + 0x10;\n\tv487 = changeValue + 0x10;\nL_00D1:\n\telapsed = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);\n\tgoto L_00E0;\n\tv512 = *([v501 @ X0_v14+E0]);\n\tv513 = v512 == 0;\n\tv514 = ~v513;\n\tif (v514) goto L_00E0;\n\tv516 = \"il2cpp_codegen_runtime_class_init\"(v501, v363, v357, v201, getter, setter, startValue, changeValue, v493, v492, v127, v125, v62, v63, v64, v65);\nL_00E0:\n\tv113 = elapsed * *([v487 @ X9_v4]);\n\tv521 = 0x6D1ED0(&v111 @ stack_-78_v3 (System.Double), t.customEase, 0, v201, getter, setter, startValue, changeValue, v113, duration, t.easeOvershootOrAmplitude, t.easePeriod, v62, v63, v64, v65);\n\tv535 = v113 >= 0;\n\tif (v535) goto L_0109;\n\tv551 = v113 != -0.5d;\n\tif (v551) goto L_011B;\n\tgoto L_010E;\nL_0109:\n\tv562 = v113 != 0.5d;\n\tif (v562) goto L_011E;\nL_010E:\n\tv597 = v119 + v585;\n\tv598 = v119 & 1;\n\tv600 = v598 == 0;\n\tv603 = ~v600;\n\tif (v603) goto L_FFFFFFFF;\n\tgoto L_011A;\nL_011A:\n\tgoto L_0121;\nL_011B:\n\tv572 = v113 + -0.5d;\n\tv119 = System.Math::Ceiling(v572);\n\tgoto L_0121;\nL_011E:\n\tv576 = v113 + 0.5d;\n\tv119 = System.Math::Floor(v576);\nL_0121:\n\tv618 = ~v119;\n\tv134 = v119 & v618;\n\tv343 = *([v487 @ X9_v4]) - v119;\n\tv337 = v343 < 0;\n\tv325 = *([v487 @ X9_v4]) ^ v119;\n\tv319 = *([v487 @ X9_v4]) ^ v343;\n\tv313 = v325 & v319;\n\tv307 = v313 < 0;\n\tv620 = v337 == v307;\n\tv301 = ~v620;\n\tv107 = ~v301;\n\tif (v107) goto L_FFFFFFFF;\n\tgoto L_0135;\nL_0135:\n\tv631 = isRelative == 0;\n\tif (v631) goto L_0164;\n\tgoto L_0148;\n\tv647 = *([v634 @ X0_v39 (Il2CppClass<DG.Tweening.Plugins.StringPlugin>)+E0]);\n\tv648 = v647 == 0;\n\tv649 = ~v648;\n\t// 319 ConditionalJump @b101, v649 @ TEMP_v50\n\tv686 = \"il2cpp_codegen_runtime_class_init\"(v634, v363, v357, v201, getter, setter, startValue, changeValue, v119, v115, v127, v125, v62, v63, v64, v65);\n\tv651 = DG.Tweening.Plugins.StringPlugin;\nL_0148:\n\tv689 = System.Text.StringBuilder::Append(v397._Buffer, v250);\n\tv175 = options.richTextEnabled == 0;\n\tv140 = ~v175;\n\tv223 = DG.Tweening.Plugins.StringPlugin::Append(v689, changeValue, 0, v242, v140);\n\tv723 = options.scrambleMode == 0;\n\tif (v723) goto L_FFFFFFFF;\n\tv717 = options.richTextEnabled;\n\tgoto L_017C;\nL_0164:\n\tv639 = options.scrambleMode == 0;\n\tif (v639) goto L_01B3;\n\tv662 = options.richTextEnabled == 0;\n\tv667 = ~v662;\n\tv669 = DG.Tweening.Plugins.StringPlugin::Append(v521, changeValue, 0, v242, v667);\n\tv695 = options.richTextEnabled;\nL_017C:\n\tv726 = DG.Tweening.Plugins.StringPlugin::ScrambledCharsToUse(v721, v719);\n\tgoto L_018B;\n\tv770 = *([v393 @ X8_v24+E0]);\n\tv771 = v770 == 0;\n\tv772 = ~v771;\n\tgoto L_018B;\n\tv811 = v393;\n\tv774 = \"il2cpp_codegen_runtime_class_init\"(v811, v719, v718, v352, v279, setter, startValue, changeValue, v287, v115, v127, v125, v62, v63, v64, v65);\nL_018B:\n\tv360 = *([v487 @ X9_v4]) - v242;\n\tv366 = DG.Tweening.Plugins.StringPluginExtensions::AppendScrambledChars(v807, v360, v726);\n\tv812 = v807 == 0;\n\tv373 = ~v812;\n\tif (v373) goto L_FFFFFFFF;\n\tgoto L_021A;\nL_0199:\n\tv224 = System.Text.StringBuilder::ToString(v820);\n\tDG.Tweening.Core.DOSetter`1<System.String>::Invoke(setter, v224);\n\treturn;\nL_01B3:\n\tv670 = *([v489 @ X8_v10]) - *([v487 @ X9_v4]);\n\tv682 = v670 < 1;\n\tif (v682) goto L_01CE;\n\tv697 = v242 / *([v487 @ X9_v4]);\n\tv699 = v697 * *([v489 @ X8_v10]);\nL_01CE:\n\tv705 = options.richTextEnabled == 0;\n\tv710 = ~v705;\n\tv225 = DG.Tweening.Plugins.StringPlugin::Append(v521, changeValue, 0, v242, v710);\n\tv738 = *([v487 @ X9_v4]) <= v242;\n\tif (v738) goto L_020C;\n\tv142 = v242 >= *([v489 @ X8_v10]);\n\tif (v142) goto L_020C;\n\tv748 = *([v489 @ X8_v10]) - v245;\n\tv754 = options.richTextEnabled == 0;\n\tv815 = ~v754;\n\tv747 = ~v815;\n\tif (v747) goto L_FFFFFFFF;\n\tgoto L_0204;\nL_0204:\n\tv749 = ~v754;\n\tv758 = v748 + v765;\n\tv762 = DG.Tweening.Plugins.StringPlugin::Append(v225, v250, v242, v758, v749);\nL_020C:\n\tgoto L_0214;\n\tv777 = *([v766 @ X0_v32 (Il2CppClass<DG.Tweening.Plugins.StringPlugin>)+E0]);\n\tv778 = v777 == 0;\n\tv779 = ~v778;\n\tif (v779) goto L_0214;\n\tv816 = \"il2cpp_codegen_runtime_class_init\"(v766, v364, v358, v353, v280, setter, startValue, changeValue, v121, v117, v127, v125, v62, v63, v64, v65);\n\tv781 = DG.Tweening.Plugins.StringPlugin;\nL_0214:\n\tv820 = v398._Buffer;\n\tgoto L_0199;\nL_021A:\n\tthrow System.NullReferenceException;\n// 362 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void EvaluateAndApply(StringOptions options, Tween t, bool isRelative, DOGetter<string> getter, DOSetter<string> setter, float elapsed, string startValue, string changeValue, float duration, bool usingInversePosition, UpdateNotice updateNotice)
		{
			//IL_0047: Expected O, but got I4
			//IL_026b: Expected O, but got I
			//IL_027a: Expected O, but got I
			//IL_007d: Expected O, but got I4
			//IL_021c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0221: Expected O, but got Unknown
			//IL_022a: Unknown result type (might be due to invalid IL or missing references)
			//IL_022f: Expected O, but got Unknown
			//IL_00c2: Expected O, but got I4
			//IL_03e0: Expected O, but got F8
			//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ee: Expected I4, but got Unknown
			//IL_041a: Unknown result type (might be due to invalid IL or missing references)
			//IL_041f: Expected I4, but got Unknown
			//IL_0427: Unknown result type (might be due to invalid IL or missing references)
			//IL_042c: Expected I4, but got Unknown
			//IL_00fd: Expected I, but got O
			//IL_0767: Unknown result type (might be due to invalid IL or missing references)
			//IL_076c: Expected I4, but got Unknown
			//IL_0482: Expected I4, but got O
			//IL_0154: Expected I, but got O
			//IL_064a: Expected I4, but got O
			//IL_05b1: Expected O, but got Ref
			//IL_0677: Unknown result type (might be due to invalid IL or missing references)
			//IL_067c: Expected I4, but got Unknown
			//IL_0684: Unknown result type (might be due to invalid IL or missing references)
			//IL_0689: Expected I4, but got Unknown
			//IL_01e8: Expected O, but got I4
			//IL_05ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_05d3: Expected I4, but got Unknown
			//IL_0526: Expected O, but got Ref
			//IL_06bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_06c2: Expected I4, but got Unknown
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
						IntPtr intPtr = (IntPtr)typeof(StringPlugin);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ X0_v51 (Il2CppClass<DG.Tweening.Plugins.StringPlugin>)+12F]");
						int num2 = 0;
						int num3 = num2 & 1;
						int num4 = 0;
						do
						{
							if ((num3 & 1) != 0)
							{
							}
							StringBuilder stringBuilder3 = _Buffer.Append(changeValue);
							IntPtr intPtr2 = (IntPtr)typeof(StringPlugin);
							num4++;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ X0_v56 (Il2CppClass<DG.Tweening.Plugins.StringPlugin>)+12E]");
							int num5 = 0;
							num3 = num5 & 1;
						}
						while (num4 < num);
						string text2 = _Buffer.ToString();
						int length2 = _Buffer.Length;
						StringBuilder stringBuilder4 = _Buffer.Remove(0, length2);
						obj = 0;
						text = text2;
					}
				}
			}
			object obj2;
			object obj3;
			if (options.richTextEnabled)
			{
				obj2 = options + 16;
				obj3 = options + 20;
				if (t == null)
				{
					goto IL_07cc;
				}
			}
			else
			{
				obj2 = (long)(IntPtr)text + 16L;
				obj3 = (long)(IntPtr)changeValue + 16L;
			}
			float num6 = EaseManager.Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);
			float num7 = elapsed * (float)obj3;
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @6D1ED0 (native modf)");
			double num8;
			double num9;
			double num10 = default(double);
			if (num7 < 0f)
			{
				if ((double)num7 != -0.5)
				{
					double a = (double)num7 + -0.5;
					num8 = Math.Ceiling(a);
					goto IL_03d7;
				}
				num9 = -1.0;
				num8 = num10;
			}
			else
			{
				if ((double)num7 != 0.5)
				{
					double d = (double)num7 + 0.5;
					num8 = Math.Floor(d);
					goto IL_03d7;
				}
				num9 = 1.0;
				num8 = num10;
			}
			double num11 = num8 + num9;
			if ((num8 & 1) != 0)
			{
				num8 = num11;
			}
			goto IL_03d7;
			IL_0876:
			StringBuilder stringBuilder5;
			string pNewValue = stringBuilder5.ToString();
			setter(pNewValue);
			return;
			IL_07cc:
			throw new NullReferenceException();
			IL_03d7:
			object obj4 = ~num8;
			int num12 = num8 & (long)(IntPtr)obj4;
			double num13 = (double)obj3 - num8;
			bool flag4 = num13 < 0.0;
			int num14 = obj3 ^ num8;
			int num15 = obj3 ^ num13;
			int num16 = num14 & num15;
			bool flag5 = num16 < 0;
			int num17 = ((flag4 == flag5) ? num12 : ((int)obj3));
			StringBuilder stringBuilder8;
			StringOptions options2;
			StringPlugin stringPlugin;
			if (isRelative)
			{
				StringBuilder stringBuilder6 = _Buffer.Append(text);
				bool flag6 = !options.richTextEnabled;
				bool richTextEnabled = !flag6;
				StringBuilder stringBuilder7 = ((StringPlugin)(object)stringBuilder6).Append(changeValue, 0, num17, richTextEnabled);
				if (options.scrambleMode == ScrambleMode.None)
				{
					stringBuilder8 = stringBuilder7;
					goto IL_0622;
				}
				bool richTextEnabled2 = options.richTextEnabled;
				options2 = (StringOptions)(&richTextEnabled2);
				stringPlugin = (StringPlugin)(object)stringBuilder7;
				stringBuilder8 = stringBuilder7;
			}
			else
			{
				StringPlugin stringPlugin2 = default(StringPlugin);
				if (options.scrambleMode == ScrambleMode.None)
				{
					int num18 = obj2 - obj3;
					bool flag7 = num18 < 1;
					int num19 = num17;
					if (!flag7)
					{
						int num20 = num17 / obj3;
						int num21 = num20 * obj2;
						num19 = num21;
					}
					bool flag8 = !options.richTextEnabled;
					bool richTextEnabled3 = !flag8;
					StringBuilder stringBuilder9 = stringPlugin2.Append(changeValue, 0, num17, richTextEnabled3);
					if ((long)(IntPtr)obj3 > (long)num17 && (long)num17 < (long)(IntPtr)obj2)
					{
						int num22 = obj2 - num19;
						bool flag9 = !options.richTextEnabled;
						int num23 = ((!flag9) ? num17 : 0);
						bool richTextEnabled4 = !flag9;
						int length3 = num22 + num23;
						StringBuilder stringBuilder10 = ((StringPlugin)(object)stringBuilder9).Append(text, num17, length3, richTextEnabled4);
					}
					stringBuilder5 = _Buffer;
					goto IL_0876;
				}
				bool flag10 = !options.richTextEnabled;
				bool richTextEnabled5 = !flag10;
				StringBuilder stringBuilder11 = stringPlugin2.Append(changeValue, 0, num17, richTextEnabled5);
				bool richTextEnabled6 = options.richTextEnabled;
				options2 = (StringOptions)(&richTextEnabled6);
				stringPlugin = (StringPlugin)(object)stringBuilder11;
				stringBuilder8 = stringBuilder11;
			}
			char[] chars = stringPlugin.ScrambledCharsToUse(options2);
			int length4 = obj3 - num17;
			StringBuilder stringBuilder12 = stringBuilder8.AppendScrambledChars(length4, chars);
			if (stringBuilder8 != null)
			{
				goto IL_0622;
			}
			goto IL_07cc;
			IL_0622:
			stringBuilder5 = stringBuilder8;
			goto IL_0876;
		}

		[Token(Token = "0x6000208")]
		[Address(RVA = "0x10DCA68", Offset = "0x10DCA68", Length = "0x6DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv40 = *([1ECC828]);\n\tv41 = *([v40 @ X8_v113]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, value, startIndex, length, richTextEnabled, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv57 = 0 | 1;\n\t*([20274CF]) = v57;\nL_0023:\n\tv63 = richTextEnabled == 0;\n\tif (v63) goto L_01CE;\n\tgoto L_0035;\n\tv68 = *([v60 @ X0_v2 (Il2CppClass<DG.Tweening.Plugins.StringPlugin>)+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\t// 43 ConditionalJump @b140, v70 @ TEMP_v129\n\tv88 = \"il2cpp_codegen_runtime_class_init\"(v60, value, startIndex, length, richTextEnabled, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv72 = DG.Tweening.Plugins.StringPlugin;\nL_0035:\n\tSystem.Collections.Generic.List`1<System.Char>::Clear(v75._OpenedTags);\n\tv429 = v98 < 1;\n\tif (v429) goto L_FFFFFFFF;\n\tv595 = value.m_stringLength - 1;\nL_004C:\n\tv629 = System.String::get_Chars(value, v289);\n\tv637 = v629 & 0xFFFF;\n\tv647 = v637 != 0x3C;\n\tif (v647) goto L_00B2;\n\tv140 = v289 + 1;\n\tv656 = System.String::get_Chars(value, v140);\n\tv673 = v656 & 0xFFFF;\n\tv676 = v289 - v595;\n\tv677 = v676 < 0;\n\tv679 = v289 ^ v595;\n\tv680 = v289 ^ v676;\n\tv681 = v679 & v680;\n\tv682 = v681 < 0;\n\tv683 = v677 == v682;\n\tv686 = v673 - 0x2F;\n\tv688 = v686 == 0;\n\tv694 = ~v688;\n\tv589 = v683 | v694;\n\tv157 = v589 != 1;\n\tif (v157) goto L_00CA;\n\tgoto L_0095;\n\tv771 = *([v672 @ X0_v75 (Il2CppClass<DG.Tweening.Plugins.StringPlugin>)+E0]);\n\tv772 = v771 == 0;\n\tv773 = ~v772;\n\t// 139 ConditionalJump @b141, v773 @ TEMP_v127\n\tv795 = \"il2cpp_codegen_runtime_class_init\"(v672, v249, v137, v97, richTextEnabled, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv775 = DG.Tweening.Plugins.StringPlugin;\nL_0095:\n\tv799 = v656 & 0xFFFF;\n\tv810 = v799 != 0x23;\n\tif (v810) goto L_FFFFFFFF;\n\tgoto L_00A6;\nL_00A6:\n\tSystem.Collections.Generic.List`1<System.Char>::Add(v297._OpenedTags, v829);\n\tgoto L_00DE;\nL_00B2:\n\tv163 = v289 < v621;\n\tif (v163) goto L_FFFFFFFF;\n\tgoto L_00C5;\n\tv740 = *([v696 @ X0_v67 (Il2CppClass<DG.Tweening.Plugins.StringPlugin>)+E0]);\n\tv741 = v740 == 0;\n\tv742 = ~v741;\n\t// 188 ConditionalJump @b143, v742 @ TEMP_v75\n\tv785 = \"il2cpp_codegen_runtime_class_init\"(v696, v250, v138, v97, richTextEnabled, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv744 = DG.Tweening.Plugins.StringPlugin;\nL_00C5:\n\tv705 = System.Text.StringBuilder::Append(v298._Buffer, v629);\n\tgoto L_01BD;\nL_00CA:\n\tgoto L_00D2;\n\tv778 = *([v672 @ X0_v75 (Il2CppClass<DG.Tweening.Plugins.StringPlugin>)+E0]);\n\tv779 = v778 == 0;\n\tv780 = ~v779;\n\tif (v780) goto L_00D2;\n\tv811 = \"il2cpp_codegen_runtime_class_init\"(v672, v249, v137, v97, richTextEnabled, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv782 = DG.Tweening.Plugins.StringPlugin;\nL_00D2:\n\tv263 = v299._OpenedTags;\n\tv815 = v263._size - 1;\n\tSystem.Collections.Generic.List`1<System.Char>::RemoveAt(v263, v815);\nL_00DE:\n\tv836 = System.String::Substring(value, v289);\n\tgoto L_00F2;\n\tv849 = *([v842 @ X8_v67+E0]);\n\tv850 = v849 == 0;\n\tv851 = ~v850;\n\tif (v851) goto L_00F2;\n\tv861 = v842;\n\tv853 = \"il2cpp_codegen_runtime_class_init\"(v861, v834, v835, v97, richTextEnabled, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_00F2:\n\tv252 = System.Text.RegularExpressions.Regex::Match(v836, \"<.*?(>)\");\n\tv759 = System.Text.RegularExpressions.Group::get_Success(v252);\n\tv760 = v759 == 0;\n\tif (v760) goto L_01BD;\n\tv876 = v152 | v589;\n\tv877 = v876 & 1;\n\tv878 = v877 == 0;\n\tv879 = ~v878;\n\tif (v879) goto L_0198;\n\tv884 = System.String::get_Chars(value, v140);\n\tv292 = v884 & 0xFFFF;\n\tv158 = v292 != 0x63;\n\tif (v158) goto L_012F;\n\t// 280 NewArr v253 @ X0_v121 (System.Char[]), typeof(System.Char[]), 2\n\tv462 = v253.Length == 0;\n\tif (v462) goto L_02CA;\n\tv452 = v253.Length == 1;\n\tv253[0] = 0x23;\n\tif (v452) goto L_02CA;\n\tv922 = v253 + 0x22;\n\tgoto L_0137;\nL_012F:\n\t// 303 NewArr v254 @ X0_v120 (System.Char[]), typeof(System.Char[]), 1\n\tv463 = v254.Length == 0;\n\tif (v463) goto L_02CA;\n\tv922 = v254 + 0x20;\nL_0137:\n\tv322 = v289 - 1;\n\t*([v922 @ X8_v81]) = v891;\n\tv964 = v322 & 0x80000000;\n\tv965 = v964 == 0;\n\tv919 = ~v965;\n\tif (v919) goto L_0198;\nL_013E:\n\tv337 = v340 - 1;\n\tv995 = System.String::get_Chars(value, v337);\n\tv1008 = v995 & 0xFFFF;\n\tv1018 = v1008 != 0x3C;\n\tif (v1018) goto L_016F;\n\tv1031 = System.String::get_Chars(value, v340);\n\tv1043 = v1031 & 0xFFFF;\n\tv1034 = v1043 == 0x2F;\n\tif (v1034) goto L_016F;\n\tv1049 = v340 + 1;\n\tv1052 = System.String::get_Chars(value, v1049);\n\tv1038 = System.Array::IndexOf(v888, v1052);\n\tv1040 = v1038 + 1;\n\tv364 = v1040 == 0;\n\tv343 = ~v364;\n\tif (v343) goto L_0179;\nL_016F:\n\tv921 = v340 - 2;\n\tv1044 = v921 & 0x80000000;\n\tv918 = v1044 == 0;\n\tif (v918) goto L_013E;\n\tgoto L_0198;\nL_0179:\n\tgoto L_0186;\n\tv1061 = *([v1057 @ X0_v110 (Il2CppClass<DG.Tweening.Plugins.StringPlugin>)+E0]);\n\tv1062 = v1061 == 0;\n\tv1063 = ~v1062;\n\tif (v1063) goto L_0186;\n\tv1074 = \"il2cpp_codegen_runtime_class_init\"(v1057, v1037, v1032, v97, richTextEnabled, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv1065 = DG.Tweening.Plugins.StringPlugin;\nL_0186:\n\tv1073 = System.String::IndexOf(value, 0x3E, v337);\n\tv408 = v1073 - v340;\n\tv1075 = v408 + 2;\n\tv386 = System.String::Substring(value, v337, v1075);\n\tv914 = System.Text.StringBuilder::Insert(v1068._Buffer, 0, v386);\nL_0198:\n\tgoto L_01A3;\n\tv933 = *([v923 @ X0_v85 (Il2CppClass<DG.Tweening.Plugins.StringPlugin>)+E0]);\n\tv934 = v933 == 0;\n\tv935 = ~v934;\n\tif (v935) goto L_01A3;\n\tv943 = \"il2cpp_codegen_runtime_class_init\"(v923, v909, v329, v98, richTextEnabled, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv937 = DG.Tweening.Plugins.StringPlugin;\nL_01A3:\n\tv387 = System.Text.RegularExpressions.Capture::get_Value(v252);\n\tv945 = System.Text.StringBuilder::Append(v409._Buffer, v387);\n\tv255 = System.Text.RegularExpressions.Match::get_Groups(v252);\n\tv256 = System.Text.RegularExpressions.GroupCollection::get_Item(v255, 1);\n\tv747 = v256._index + 1;\n\tv622 = v747 + v622;\n\tv621 = v747 + v621;\n\tv289 = v256._index + v289;\nL_01BD:\n\tv289 = v289 + 1;\n\tv598 = v289 < v622;\n\tif (v598) goto L_004C;\n\tgoto L_01E4;\nL_01CE:\n\tgoto L_01DD;\n\tv78 = *([v60 @ X0_v2 (Il2CppClass<DG.Tweening.Plugins.StringPlugin>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\t// 466 ConditionalJump @b151, v80 @ TEMP_v15\n\tv306 = \"il2cpp_codegen_runtime_class_init\"(v60, value, startIndex, length, richTextEnabled, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv82 = DG.Tweening.Plugins.StringPlugin;\nL_01DD:\n\tv311 = System.Text.StringBuilder::Append(v85._Buffer, value, startIndex, v98);\n\tgoto L_02C6;\nL_01E4:\n\tgoto L_01EC;\n\tv648 = *([v633 @ X0_v21 (Il2CppClass<DG.Tweening.Plugins.StringPlugin>)+E0]);\n\tv649 = v648 == 0;\n\tv650 = ~v649;\n\tgoto L_01EC;\n\tv659 = \"il2cpp_codegen_runtime_class_init\"(v633, v382, v331, v99, richTextEnabled, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv651 = DG.Tweening.Plugins.StringPlugin;\nL_01EC:\n\tv411 = v654._OpenedTags;\n\tv671 = v411._size < 1;\n\tif (v671) goto L_02B0;\n\tv302 = value.m_stringLength - 1;\n\tv719 = v289 >= v302;\n\tif (v719) goto L_02B0;\n\tgoto L_026A;\nL_0210:\n\tv257 = System.Text.RegularExpressions.Capture::get_Value(v260);\n\tv946 = System.String::get_Chars(v257, 2);\n\tgoto L_0224;\n\tv954 = *([v948 @ X8_v35 (Il2CppClass<DG.Tweening.Plugins.StringPlugin>)+E0]);\n\tv955 = v954 == 0;\n\tv956 = ~v955;\n\tif (v956) goto L_0224;\n\tv966 = v948;\n\tv957 = \"il2cpp_codegen_runtime_class_init\"(v966, v383, v330, v99, richTextEnabled, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv960 = DG.Tweening.Plugins.StringPlugin;\nL_0224:\n\tv113 = v412._OpenedTags;\n\tv150 = v113._size - 1;\n\tv968 = v113._size == 0;\n\tv969 = ~v968;\n\tif (v969) goto L_022E;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_022E:\n\tv973 = v113._items;\n\tv124 = v946 & 0xFFFF;\n\tv161 = v124 != v973[v150 @ X26_v9 (System.Int32)];\n\tif (v161) goto L_0261;\n\tgoto L_024D;\n\tv1019 = *([v996 @ X0_v44 (Il2CppClass<DG.Tweening.Plugins.StringPlugin>)+E0]);\n\tv1020 = v1019 == 0;\n\tv1021 = ~v1020;\n\tif (v1021) goto L_024D;\n\tv1045 = \"il2cpp_codegen_runtime_class_init\"(v996, v383, v330, v99, richTextEnabled, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv1023 \n// ... truncated")]
		private StringBuilder Append(string value, int startIndex, int length, bool richTextEnabled)
		{
			//IL_03b2: Expected O, but got I
			//IL_0864: Expected O, but got I4
			//IL_0876: Expected I4, but got I8
			//IL_035b: Expected O, but got I
			//IL_049b: Expected I4, but got I8
			int num = default(int);
			if (richTextEnabled)
			{
				_OpenedTags.Clear();
				int num5;
				if (num >= 1)
				{
					int num2 = value.Length - 1;
					bool flag = false;
					int num3 = startIndex;
					int num4 = num;
					num5 = 0;
					bool flag9;
					do
					{
						char c = value.get_Chars(num5);
						int num6 = c & 0xFFFF;
						bool flag7;
						Match match;
						char[] array2;
						char c4;
						object obj;
						if (num6 == 60)
						{
							int index = num5 + 1;
							char c2 = value.get_Chars(index);
							int num7 = c2 & 0xFFFF;
							int num8 = num5 - num2;
							bool flag2 = num8 < 0;
							int num9 = num5 ^ num2;
							int num10 = num5 ^ num8;
							int num11 = num9 & num10;
							bool flag3 = num11 < 0;
							bool flag4 = flag2 == flag3;
							int num12 = num7 - 47;
							bool flag5 = num12 == 0;
							bool flag6 = !flag5;
							flag7 = flag4 || flag6;
							if (flag7)
							{
								int num13 = c2 & 0xFFFF;
								char item = ((num13 != 35) ? c2 : 'c');
								_OpenedTags.Add(item);
							}
							else
							{
								List<char> openedTags = _OpenedTags;
								int index2 = openedTags.Count - 1;
								openedTags.RemoveAt(index2);
							}
							string input = value.Substring(num5);
							match = Regex.Match(input, "<.*?(>)");
							if (match.Success)
							{
								int num14 = ((flag || flag7) ? 1 : 0);
								if ((num14 & 1) == 0)
								{
									char c3 = value.get_Chars(index);
									int num15 = c3 & 0xFFFF;
									if (num15 == 99)
									{
										char[] array = new char[2];
										if (array.Length != 0)
										{
											bool flag8 = array.Length == 1;
											array[0] = '#';
											if (!flag8)
											{
												obj = (long)(IntPtr)array + 34L;
												array2 = array;
												c4 = 'c';
												goto IL_084e;
											}
										}
									}
									else
									{
										char[] array3 = new char[1];
										if (array3.Length != 0)
										{
											obj = (long)(IntPtr)array3 + 32L;
											array2 = array3;
											c4 = c3;
											goto IL_084e;
										}
									}
									IndexOutOfRangeException ex = new IndexOutOfRangeException();
									throw ex;
								}
								goto IL_0936;
							}
						}
						else
						{
							if (num5 >= num3)
							{
								StringBuilder stringBuilder = _Buffer.Append(c);
							}
							flag7 = flag;
						}
						goto IL_080e;
						IL_080e:
						num5++;
						flag9 = num5 < num4;
						flag = flag7;
						continue;
						IL_0936:
						string value2 = match.Value;
						StringBuilder stringBuilder2 = _Buffer.Append(value2);
						GroupCollection groups = match.Groups;
						Group obj2 = groups.get_Item(1);
						int num16 = obj2.Index + 1;
						num4 = num16 + num4;
						num3 = num16 + num3;
						num5 = obj2.Index + num5;
						goto IL_080e;
						IL_084e:
						int num17 = num5 - 1;
						obj = c4;
						if ((int)(num17 & 0x80000000L) == 0)
						{
							int num18 = num5;
							bool flag10;
							do
							{
								int num19 = num18 - 1;
								char c5 = value.get_Chars(num19);
								int num20 = c5 & 0xFFFF;
								if (num20 == 60)
								{
									char c6 = value.get_Chars(num18);
									int num21 = c6 & 0xFFFF;
									if (num21 != 47)
									{
										int index3 = num18 + 1;
										char value3 = value.get_Chars(index3);
										int num22 = Array.IndexOf(array2, value3);
										if (num22 + 1 != 0)
										{
											int num23 = value.IndexOf('>', num19);
											int num24 = num23 - num18;
											int length2 = num24 + 2;
											string value4 = value.Substring(num19, length2);
											StringBuilder stringBuilder3 = _Buffer.Insert(0, value4);
											break;
										}
									}
								}
								int num25 = num18 - 2;
								int num26 = (int)(num25 & 0x80000000L);
								flag10 = num26 == 0;
								num18 = num19;
							}
							while (flag10);
						}
						goto IL_0936;
					}
					while (flag9);
				}
				else
				{
					num5 = 0;
				}
				List<char> openedTags2 = _OpenedTags;
				if (openedTags2.Count >= 1)
				{
					int num27 = value.Length - 1;
					if (num5 < num27)
					{
						while (true)
						{
							List<char> openedTags3 = _OpenedTags;
							if (num5 < num27 && openedTags3.Count > 0)
							{
								string input2 = value.Substring(num5);
								Match match2 = Regex.Match(input2, "(</).*?>");
								if (match2.Success)
								{
									string value5 = match2.Value;
									char c7 = value5.get_Chars(2);
									List<char> openedTags4 = _OpenedTags;
									int num28 = openedTags4.Count - 1;
									if (openedTags4.Count == 0)
									{
										throw new ArgumentOutOfRangeException();
									}
									char[] items = openedTags4._items;
									int num29 = c7 & 0xFFFF;
									if (num29 == items[num28])
									{
										string value6 = match2.Value;
										StringBuilder stringBuilder4 = _Buffer.Append(value6);
										List<char> openedTags5 = _OpenedTags;
										int index4 = openedTags5.Count - 1;
										openedTags5.RemoveAt(index4);
									}
									string value7 = match2.Value;
									num5 = value7.Length + num5;
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

		[Token(Token = "0x6000209")]
		[Address(RVA = "0x10DD144", Offset = "0x10DD144", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EF69E8]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, options, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([20274D0]) = v38;\nL_0014:\n\tv40 = options.scrambleMode - 2;\n\tv41 = v40 < 3;\n\tv42 = ~v41;\n\tv43 = v40 - 3;\n\tv45 = v43 == 0;\n\tv50 = ~v45;\n\tv51 = v42 & v50;\n\tif (v51) goto L_003C;\n\tv53 = 0x1829000 + 0x334;\n\tv55 = *([v53 @ X9_v2 (System.Int32)+v40 @ X8_v4 (System.Int32)*4]) + v53;\n\t// 37 IndirectJump v55 @ X8_v10, v35 @ X0_v1 (DG.Tweening.Plugins.StringPlugin), v35 @ X0_v1 (DG.Tweening.Plugins.StringPlugin), options @ X1 (DG.Tweening.Plugins.Options.StringOptions), methodInfo @ X2 (Il2CppMethodInfo), v22 @ X3, v23 @ X4, v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\n\tX19 = *([1EEB888]);\n\tX0 = *([X19]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0033;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0033;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X19]);\nL_0033:\n\tX8 = *([X0+B8]);\n\tX8 = X8 + 8;\n\tgoto L_006C;\nL_003C:\n\tgoto L_0044;\n\tv78 = *([v58 @ X0_v2 (Il2CppClass<DG.Tweening.Plugins.StringPluginExtensions>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_0044;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v58, options, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv82 = DG.Tweening.Plugins.StringPluginExtensions;\nL_0044:\n\tgoto L_006C;\n\tX19 = *([1EEB888]);\n\tX0 = *([X19]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0052;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0052;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X19]);\nL_0052:\n\tX8 = *([X0+B8]);\n\tX8 = X8 + 0x10;\n\tgoto L_006C;\n\tX19 = *([1EEB888]);\n\tX0 = *([X19]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0062;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0062;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X19]);\nL_0062:\n\tX8 = *([X0+B8]);\n\tX8 = X8 + 0x18;\n\tgoto L_006C;\n\tX8 = X19 + 8;\nL_006C:\n\treturn v73.ScrambledCharsAll;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private char[] ScrambledCharsToUse(StringOptions options)
		{
			//IL_0029: Expected O, but got I
			int num = (int)(options.scrambleMode - 2);
			bool flag = num < 3;
			bool flag2 = !flag;
			int num2 = num - 3;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 25333760 + 820;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X9_v2 (System.Int32)+v40 @ X8_v4 (System.Int32)*4]");
				object obj = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v55 @ X8_v10 (should have been resolved before IL gen)");
			}
			return StringPluginExtensions.ScrambledCharsAll;
		}

		[Token(Token = "0x600020A")]
		[Address(RVA = "0x10DD3CC", Offset = "0x10DD3CC", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EA8F28]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20274D1]) = v38;\nL_001C:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<System.String, System.String, DG.Tweening.Plugins.Options.StringOptions>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public StringPlugin()
		{
		}

		[Token(Token = "0x600020B")]
		[Address(RVA = "0x10DD41C", Offset = "0x10DD41C", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EE3678]);\n\tv17 = *([v16 @ X8_v14]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20274D2]) = v37;\nL_0015:\n\tv41 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v41);\n\tv47._Buffer = v41;\n\tv51 = new System.Collections.Generic.List`1<System.Char>();\n\tSystem.Collections.Generic.List`1<System.Char>::.ctor(v51);\n\tv57._OpenedTags = v51;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static StringPlugin()
		{
			StringBuilder buffer = new StringBuilder();
			_Buffer = buffer;
			List<char> openedTags = new List<char>();
			_OpenedTags = openedTags;
		}
	}
}
