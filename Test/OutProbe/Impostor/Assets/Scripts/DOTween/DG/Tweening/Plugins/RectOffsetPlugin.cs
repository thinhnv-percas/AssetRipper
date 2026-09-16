using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening.Plugins
{
	[Token(Token = "0x200007E")]
	public class RectOffsetPlugin : ABSTweenPlugin<RectOffset, RectOffset, NoOptions>
	{
		[Token(Token = "0x4000161")]
		private static RectOffset _r;

		[Token(Token = "0x600031B")]
		[Address(RVA = "0xC223D8", Offset = "0xC223D8", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tt.startValue = 0;\n\tt.endValue = 0;\n\tt.changeValue = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset(TweenerCore<RectOffset, RectOffset, NoOptions> t)
		{
			t.startValue = null;
			t.endValue = null;
			t.changeValue = null;
		}

		[Token(Token = "0x600031C")]
		[Address(RVA = "0xC223F4", Offset = "0xC223F4", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.RectOffset, UnityEngine.RectOffset, DG.Tweening.Plugins.Options.NoOptions>)+148]);\n\t*([v10 @ X8_v2+18])(v43, *([v10 @ X8_v2+40]), *([v10 @ X8_v2+28]), isRelative, methodInfo, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86);\n\tt.startValue = t.endValue;\n\tt.endValue = v43;\n\tv89 = isRelative == 0;\n\tif (v89) goto L_0059;\n\tv44 = UnityEngine.RectOffset::get_left(t.endValue);\n\tv118 = UnityEngine.RectOffset::get_left(t.endValue);\n\tv34 = v118 + v44;\n\tUnityEngine.RectOffset::set_left(t.endValue, v34);\n\tv46 = UnityEngine.RectOffset::get_right(t.startValue);\n\tv122 = UnityEngine.RectOffset::get_right(t.endValue);\n\tv36 = v122 + v46;\n\tUnityEngine.RectOffset::set_right(t.startValue, v36);\n\tv48 = UnityEngine.RectOffset::get_top(t.startValue);\n\tv126 = UnityEngine.RectOffset::get_top(t.endValue);\n\tv38 = v126 + v48;\n\tUnityEngine.RectOffset::set_top(t.startValue, v38);\n\tv50 = UnityEngine.RectOffset::get_bottom(t.startValue);\n\tv130 = UnityEngine.RectOffset::get_bottom(t.endValue);\n\tv92 = v130 + v50;\n\tUnityEngine.RectOffset::set_bottom(t.startValue, v92);\nL_0059:\n\tv62 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.RectOffset, UnityEngine.RectOffset, DG.Tweening.Plugins.Options.NoOptions>)+150]);\n\tv107 = t.startValue;\n\tv99 = *([v62 @ X8_v4+18]);\n\tv109 = *([v62 @ X8_v4+40]);\n\tv101 = *([v62 @ X8_v4+28]);\n\t// 101 IndirectJump v99 @ X3_v1, v109 @ X0_v6, v109 @ X0_v6, v107 @ X1_v4 (UnityEngine.RectOffset), v101 @ X2_v3, v99 @ X3_v1, v75 @ X4, v76 @ X5, v77 @ X6, v78 @ X7, v79 @ V0, v80 @ V1, v81 @ V2, v82 @ V3, v83 @ V4, v84 @ V5, v85 @ V6, v86 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<RectOffset, RectOffset, NoOptions> t, bool isRelative)
		{
			//IL_0010: Expected O, but got I
			//IL_019f: Expected O, but got I
			//IL_01c1: Expected O, but got I
			//IL_01d1: Expected O, but got I
			//IL_01e1: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.RectOffset, UnityEngine.RectOffset, DG.Tweening.Plugins.Options.NoOptions>)+148]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v10 @ X8_v2+18] (should have been resolved before IL gen)");
			t.startValue = t.endValue;
			RectOffset endValue = default(RectOffset);
			t.endValue = endValue;
			if (isRelative)
			{
				int left = t.endValue.left;
				int left2 = t.endValue.left;
				int left3 = left2 + left;
				t.endValue.left = left3;
				int right = t.startValue.right;
				int right2 = t.endValue.right;
				int right3 = right2 + right;
				t.startValue.right = right3;
				int top = t.startValue.top;
				int top2 = t.endValue.top;
				int top3 = top2 + top;
				t.startValue.top = top3;
				int bottom = t.startValue.bottom;
				int bottom2 = t.endValue.bottom;
				int bottom3 = bottom2 + bottom;
				t.startValue.bottom = bottom3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.RectOffset, UnityEngine.RectOffset, DG.Tweening.Plugins.Options.NoOptions>)+150]");
			object obj2 = 0;
			RectOffset startValue = t.startValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X8_v4+18]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X8_v4+40]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X8_v4+28]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v99 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600031D")]
		[Address(RVA = "0xC22540", Offset = "0xC22540", Length = "0x21C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = isRelative == 0;\n\tif (v22) goto L_0083;\n\tv25 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.RectOffset, UnityEngine.RectOffset, DG.Tweening.Plugins.Options.NoOptions>)+148]);\n\t*([v25 @ X8_v4+18])(v58, *([v25 @ X8_v4+40]), *([v25 @ X8_v4+28]), fromValue, setImmediately, isRelative, methodInfo, v82, v83, v84, v85, v86, v87, v88, v89, v90, v91);\n\tv59 = UnityEngine.RectOffset::get_left(t.endValue);\n\tv136 = UnityEngine.RectOffset::get_left(v58);\n\tv51 = v136 + v59;\n\tUnityEngine.RectOffset::set_left(t.endValue, v51);\n\tv139 = UnityEngine.RectOffset::get_right(t.endValue);\n\tv142 = UnityEngine.RectOffset::get_right(v58);\n\tv52 = v142 + v139;\n\tUnityEngine.RectOffset::set_right(t.endValue, v52);\n\tv145 = UnityEngine.RectOffset::get_top(t.endValue);\n\tv148 = UnityEngine.RectOffset::get_top(v58);\n\tv53 = v148 + v145;\n\tUnityEngine.RectOffset::set_top(t.endValue, v53);\n\tv151 = UnityEngine.RectOffset::get_bottom(t.endValue);\n\tv154 = UnityEngine.RectOffset::get_bottom(v58);\n\tv54 = v154 + v151;\n\tUnityEngine.RectOffset::set_bottom(t.endValue, v54);\n\tv157 = UnityEngine.RectOffset::get_left(fromValue);\n\tv161 = UnityEngine.RectOffset::get_left(v58);\n\tv162 = v161 + v157;\n\tUnityEngine.RectOffset::set_left(fromValue, v162);\n\tv167 = UnityEngine.RectOffset::get_right(fromValue);\n\tv171 = UnityEngine.RectOffset::get_right(v58);\n\tv172 = v171 + v167;\n\tUnityEngine.RectOffset::set_right(fromValue, v172);\n\tv177 = UnityEngine.RectOffset::get_top(fromValue);\n\tv181 = UnityEngine.RectOffset::get_top(v58);\n\tv182 = v181 + v177;\n\tUnityEngine.RectOffset::set_top(fromValue, v182);\n\tv187 = UnityEngine.RectOffset::get_bottom(fromValue);\n\tv190 = UnityEngine.RectOffset::get_bottom(v58);\n\tv94 = v190 + v187;\n\tUnityEngine.RectOffset::set_bottom(fromValue, v94);\n\tgoto L_0083;\nL_0083:\n\tt.startValue = fromValue;\n\tv99 = setImmediately == 0;\n\tif (v99) goto L_009F;\n\tv71 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.RectOffset, UnityEngine.RectOffset, DG.Tweening.Plugins.Options.NoOptions>)+150]);\n\tv112 = *([v71 @ X8_v3+18]);\n\tv124 = *([v71 @ X8_v3+40]);\n\tv114 = *([v71 @ X8_v3+28]);\n\t// 150 IndirectJump v112 @ X3_v1, v124 @ X0_v4, v124 @ X0_v4, fromValue @ X2 (UnityEngine.RectOffset), v114 @ X2_v3, v112 @ X3_v1, isRelative @ X4 (System.Boolean), methodInfo @ X5 (Il2CppMethodInfo), v82 @ X6, v83 @ X7, v84 @ V0, v85 @ V1, v86 @ V2, v87 @ V3, v88 @ V4, v89 @ V5, v90 @ V6, v91 @ V7\nL_009F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<RectOffset, RectOffset, NoOptions> t, RectOffset fromValue, bool setImmediately, bool isRelative)
		{
			//IL_002d: Expected O, but got I
			//IL_028e: Expected O, but got I
			//IL_02a3: Expected O, but got I
			//IL_02b3: Expected O, but got I
			//IL_02c3: Expected O, but got I
			if (isRelative)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.RectOffset, UnityEngine.RectOffset, DG.Tweening.Plugins.Options.NoOptions>)+148]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v25 @ X8_v4+18] (should have been resolved before IL gen)");
				int left = t.endValue.left;
				RectOffset rectOffset = default(RectOffset);
				int left2 = rectOffset.left;
				int left3 = left2 + left;
				t.endValue.left = left3;
				int right = t.endValue.right;
				int right2 = rectOffset.right;
				int right3 = right2 + right;
				t.endValue.right = right3;
				int top = t.endValue.top;
				int top2 = rectOffset.top;
				int top3 = top2 + top;
				t.endValue.top = top3;
				int bottom = t.endValue.bottom;
				int bottom2 = rectOffset.bottom;
				int bottom3 = bottom2 + bottom;
				t.endValue.bottom = bottom3;
				int left4 = fromValue.left;
				int left5 = rectOffset.left;
				int left6 = left5 + left4;
				fromValue.left = left6;
				int right4 = fromValue.right;
				int right5 = rectOffset.right;
				int right6 = right5 + right4;
				fromValue.right = right6;
				int top4 = fromValue.top;
				int top5 = rectOffset.top;
				int top6 = top5 + top4;
				fromValue.top = top6;
				int bottom4 = fromValue.bottom;
				int bottom5 = rectOffset.bottom;
				int bottom6 = bottom5 + bottom4;
				fromValue.bottom = bottom6;
			}
			t.startValue = fromValue;
			if (setImmediately)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.RectOffset, UnityEngine.RectOffset, DG.Tweening.Plugins.Options.NoOptions>)+150]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X8_v3+18]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X8_v3+40]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X8_v3+28]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v112 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600031E")]
		[Address(RVA = "0xC2275C", Offset = "0xC2275C", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = UnityEngine.RectOffset;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, t, value, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 1;\n\t*([1A35772]) = v39;\nL_0019:\n\tv45 = UnityEngine.RectOffset::get_left(value);\n\tv50 = UnityEngine.RectOffset::get_right(value);\n\tv54 = UnityEngine.RectOffset::get_top(value);\n\tv84 = UnityEngine.RectOffset::get_bottom(value);\n\tv87 = new UnityEngine.RectOffset();\n\tUnityEngine.RectOffset::.ctor(v87, v45, v50, v54, v84);\n\treturn v87;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override RectOffset ConvertToStartValue(TweenerCore<RectOffset, RectOffset, NoOptions> t, RectOffset value)
		{
			int left = value.left;
			int right = value.right;
			int top = value.top;
			int bottom = value.bottom;
			return new RectOffset(left, right, top, bottom);
		}

		[Token(Token = "0x600031F")]
		[Address(RVA = "0xC22818", Offset = "0xC22818", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = UnityEngine.RectOffset::get_left(t.endValue);\n\tv91 = UnityEngine.RectOffset::get_left(t.startValue);\n\tv30 = v91 + v38;\n\tUnityEngine.RectOffset::set_left(t.endValue, v30);\n\tv40 = UnityEngine.RectOffset::get_right(t.endValue);\n\tv95 = UnityEngine.RectOffset::get_right(t.startValue);\n\tv32 = v95 + v40;\n\tUnityEngine.RectOffset::set_right(t.endValue, v32);\n\tv42 = UnityEngine.RectOffset::get_top(t.endValue);\n\tv99 = UnityEngine.RectOffset::get_top(t.startValue);\n\tv34 = v99 + v42;\n\tUnityEngine.RectOffset::set_top(t.endValue, v34);\n\tv44 = UnityEngine.RectOffset::get_bottom(t.endValue);\n\tv104 = UnityEngine.RectOffset::get_bottom(t.startValue);\n\tv81 = v104 + v44;\n\tUnityEngine.RectOffset::set_bottom(t.endValue, v81);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetRelativeEndValue(TweenerCore<RectOffset, RectOffset, NoOptions> t)
		{
			int left = t.endValue.left;
			int left2 = t.startValue.left;
			int left3 = left2 + left;
			t.endValue.left = left3;
			int right = t.endValue.right;
			int right2 = t.startValue.right;
			int right3 = right2 + right;
			t.endValue.right = right3;
			int top = t.endValue.top;
			int top2 = t.startValue.top;
			int top3 = top2 + top;
			t.endValue.top = top3;
			int bottom = t.endValue.bottom;
			int bottom2 = t.startValue.bottom;
			int bottom3 = bottom2 + bottom;
			t.endValue.bottom = bottom3;
		}

		[Token(Token = "0x6000320")]
		[Address(RVA = "0xC22924", Offset = "0xC22924", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = UnityEngine.RectOffset;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, t, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv49 = 1;\n\t*([1A35773]) = v49;\nL_001E:\n\tv72 = UnityEngine.RectOffset::get_left(t.endValue);\n\tv73 = UnityEngine.RectOffset::get_left(t.startValue);\n\tv74 = UnityEngine.RectOffset::get_right(t.endValue);\n\tv75 = UnityEngine.RectOffset::get_right(t.startValue);\n\tv76 = UnityEngine.RectOffset::get_top(t.endValue);\n\tv77 = UnityEngine.RectOffset::get_top(t.startValue);\n\tv78 = UnityEngine.RectOffset::get_bottom(t.endValue);\n\tv146 = UnityEngine.RectOffset::get_bottom(t.startValue);\n\tv127 = new UnityEngine.RectOffset();\n\tv125 = v72 - v73;\n\tv109 = v74 - v75;\n\tv107 = v76 - v77;\n\tv105 = v78 - v146;\n\tUnityEngine.RectOffset::.ctor(v127, v125, v109, v107, v105);\n\tt.changeValue = v127;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 86 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetChangeValue(TweenerCore<RectOffset, RectOffset, NoOptions> t)
		{
			int left = t.endValue.left;
			int left2 = t.startValue.left;
			int right = t.endValue.right;
			int right2 = t.startValue.right;
			int top = t.endValue.top;
			int top2 = t.startValue.top;
			int bottom = t.endValue.bottom;
			int bottom2 = t.startValue.bottom;
			int left3 = default(int);
			int right3 = default(int);
			int top3 = default(int);
			int bottom3 = default(int);
			RectOffset changeValue = new RectOffset(left3, right3, top3, bottom3);
			left3 = left - left2;
			right3 = right - right2;
			top3 = top - top2;
			bottom3 = bottom - bottom2;
			t.changeValue = changeValue;
		}

		[Token(Token = "0x6000321")]
		[Address(RVA = "0xC22A74", Offset = "0xC22A74", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = System.Math;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, options, changeValue, methodInfo, v26, v27, v28, v29, unitsXSecond, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A35774]) = v40;\nL_001A:\n\tv46 = UnityEngine.RectOffset::get_right(changeValue);\n\tv49 = -v46;\n\tv53 = v46 < 0;\n\tv56 = v46 ^ v46;\n\tv57 = v46 & v56;\n\tv58 = v57 < 0;\n\tv61 = v53 == v58;\n\tv62 = ~v61;\n\tv63 = ~v62;\n\tif (v63) goto L_FFFFFFFF;\n\tgoto L_0030;\nL_0030:\n\tv123 = UnityEngine.RectOffset::get_bottom(changeValue);\n\tv126 = -v123;\n\tv97 = v123 < 0;\n\tv88 = v123 ^ v123;\n\tv85 = v123 & v88;\n\tv82 = v85 < 0;\n\tv128 = v97 == v82;\n\tv79 = ~v128;\n\tv76 = ~v79;\n\tif (v76) goto L_FFFFFFFF;\n\tgoto L_0049;\nL_0049:\n\tgoto L_004B;\n\tv133 = \"il2cpp_codegen_runtime_class_init\"(v124, v60, changeValue, methodInfo, v26, v27, v28, v29, v125, v126, v31, v32, v33, v34, v35, v36);\nL_004B:\n\tv134 = v122 * v122;\n\tv106 = v131 * v131;\n\tv135 = v134 + v106;\n\tv136 = UnityEngine.Mathf::Sqrt(v135);\n\treturnVal2 = v136 / unitsXSecond;\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturn unitsXSecond;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float GetSpeedBasedDuration(NoOptions options, float unitsXSecond, RectOffset changeValue)
		{
			int right = changeValue.right;
			int num = -right;
			bool flag = right < 0;
			int num2 = right ^ right;
			int num3 = right & num2;
			bool flag2 = num3 < 0;
			int num4 = ((flag == flag2) ? right : num);
			int bottom = changeValue.bottom;
			int num5 = -bottom;
			bool flag3 = bottom < 0;
			int num6 = bottom ^ bottom;
			int num7 = bottom & num6;
			bool flag4 = num7 < 0;
			int num8 = ((flag3 == flag4) ? bottom : num5);
			int num9 = num4 * num4;
			int num10 = num8 * num8;
			float f = (float)num9 + (float)num10;
			float num11 = Mathf.Sqrt(f);
			return num11 / unitsXSecond;
		}

		[Token(Token = "0x6000322")]
		[Address(RVA = "0xC22B30", Offset = "0xC22B30", Length = "0x724")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tv50 = System.Math;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, options, t, isRelative, getter, setter, startValue, changeValue, elapsed, duration, v55, v56, v57, v58, v59, v60);\n\tv71 = DG.Tweening.Plugins.RectOffsetPlugin;\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, options, t, isRelative, getter, setter, startValue, changeValue, elapsed, duration, v55, v56, v57, v58, v59, v60);\n\tv78 = UnityEngine.RectOffset;\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v78, options, t, isRelative, getter, setter, startValue, changeValue, elapsed, duration, v55, v56, v57, v58, v59, v60);\n\tv65 = 1;\n\t*([1A35775]) = v65;\nL_002D:\n\tgoto L_0036;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v66, options, t, isRelative, getter, setter, startValue, changeValue, elapsed, duration, v55, v56, v57, v58, v59, v60);\n\tv75 = DG.Tweening.Plugins.RectOffsetPlugin;\nL_0036:\n\tv83 = UnityEngine.RectOffset::get_left(startValue);\n\tUnityEngine.RectOffset::set_left(v79._r, v83);\n\tv271 = UnityEngine.RectOffset::get_right(startValue);\n\tUnityEngine.RectOffset::set_right(v343._r, v271);\n\tv272 = UnityEngine.RectOffset::get_top(startValue);\n\tUnityEngine.RectOffset::set_top(v344._r, v272);\n\tv273 = UnityEngine.RectOffset::get_bottom(startValue);\n\tUnityEngine.RectOffset::set_bottom(v345._r, v273);\n\tv157 = t.loopType != 2;\n\tif (v157) goto L_00C0;\n\tgoto L_007E;\n\tv461 = \"il2cpp_codegen_runtime_class_init\"(v448, v254, v240, isRelative, getter, setter, startValue, changeValue, elapsed, duration, v55, v56, v57, v58, v59, v60);\n\tv462 = DG.Tweening.Plugins.RectOffsetPlugin;\nL_007E:\n\tv275 = UnityEngine.RectOffset::get_left(v346._r);\n\tv150 = t.completedLoops - t.isComplete;\n\tv499 = UnityEngine.RectOffset::get_left(changeValue);\n\tv502 = v499 * v150;\n\tv256 = v275 + v502;\n\tUnityEngine.RectOffset::set_left(v346._r, v256);\n\tv515 = UnityEngine.RectOffset::get_right(v347._r);\n\tv522 = UnityEngine.RectOffset::get_right(changeValue);\n\tv533 = v522 * v150;\n\tv257 = v515 + v533;\n\tUnityEngine.RectOffset::set_right(v347._r, v257);\n\tv575 = UnityEngine.RectOffset::get_top(v348._r);\n\tv587 = UnityEngine.RectOffset::get_top(changeValue);\n\tv614 = v587 * v150;\n\tv258 = v575 + v614;\n\tUnityEngine.RectOffset::set_top(v348._r, v258);\n\tv628 = UnityEngine.RectOffset::get_bottom(v349._r);\n\tv639 = UnityEngine.RectOffset::get_bottom(changeValue);\n\tv456 = v639 * v150;\n\tv453 = v628 + v456;\n\tUnityEngine.RectOffset::set_bottom(v349._r, v453);\nL_00C0:\n\tv460 = ~t.isSequenced;\n\tif (v460) goto L_0138;\n\tv350 = t.sequenceParent;\n\tv464 = v350.loopType != 2;\n\tif (v464) goto L_0138;\n\tv158 = t.loopType != 2;\n\tif (v158) goto L_FFFFFFFF;\n\tv152 = t.loops;\n\tgoto L_00E6;\nL_00E6:\n\tgoto L_00EF;\n\tv507 = \"il2cpp_codegen_runtime_class_init\"(v503, v259, v244, isRelative, getter, setter, startValue, changeValue, elapsed, duration, v55, v56, v57, v58, v59, v60);\n\tv508 = DG.Tweening.Plugins.RectOffsetPlugin;\nL_00EF:\n\tv281 = UnityEngine.RectOffset::get_left(v351._r);\n\tv535 = v350.completedLoops - v350.isComplete;\n\tv153 = v535 * v152;\n\tv538 = UnityEngine.RectOffset::get_left(changeValue);\n\tv550 = v538 * v153;\n\tv261 = v281 + v550;\n\tUnityEngine.RectOffset::set_left(v351._r, v261);\n\tv590 = UnityEngine.RectOffset::get_right(v352._r);\n\tv617 = UnityEngine.RectOffset::get_right(changeValue);\n\tv623 = v617 * v153;\n\tv262 = v590 + v623;\n\tUnityEngine.RectOffset::set_right(v352._r, v262);\n\tv642 = UnityEngine.RectOffset::get_top(v353._r);\n\tv655 = UnityEngine.RectOffset::get_top(changeValue);\n\tv678 = v655 * v153;\n\tv263 = v642 + v678;\n\tUnityEngine.RectOffset::set_top(v353._r, v263);\n\tv713 = UnityEngine.RectOffset::get_bottom(v354._r);\n\tv720 = UnityEngine.RectOffset::get_bottom(changeValue);\n\tv480 = v720 * v153;\n\tv476 = v713 + v480;\n\tUnityEngine.RectOffset::set_bottom(v354._r, v476);\nL_0138:\n\tv128 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);\n\tgoto L_0146;\n\tv493 = \"il2cpp_codegen_runtime_class_init\"(v487, v269, v248, isRelative, getter, setter, startValue, changeValue, v128, v122, v136, v134, v57, v58, v59, v60);\n\tv495 = DG.Tweening.Plugins.RectOffsetPlugin;\nL_0146:\n\tv285 = UnityEngine.RectOffset::get_left(v355._r);\n\tv512 = UnityEngine.RectOffset::get_left(changeValue);\n\tgoto L_0159;\n\tv523 = v517;\n\tv524 = \"il2cpp_codegen_runtime_class_init\"(v523, v265, v248, isRelative, getter, setter, startValue, changeValue, v128, v122, v136, v134, v57, v58, v59, v60);\nL_0159:\n\tv528 = v128 * v512;\n\tv529 = v528 + v285;\n\tv532 = 0x1854ED0(&v115 @ stack_-78_v2 (System.Double), 0, 0, isRelative, getter, setter, startValue, changeValue, v529, v528, t.easeOvershootOrAmplitude, t.easePeriod, v57, v58, v59, v60);\n\tv548 = v529 >= 0;\n\tif (v548) goto L_0183;\n\tv561 = v529 != -0.5d;\n\tif (v561) goto L_0195;\n\tgoto L_0188;\nL_0183:\n\tv572 = v529 != 0.5d;\n\tif (v572) goto L_0198;\nL_0188:\n\tv603 = v592 + v591;\n\tv604 = v592 & 1;\n\tv606 = v604 == 0;\n\tv609 = ~v606;\n\tif (v609) goto L_FFFFFFFF;\n\tgoto L_0194;\nL_0194:\n\tgoto L_01A0;\nL_0195:\n\tv579 = v529 + -0.5d;\n\tv120 = System.Math::Ceiling(v579);\n\tgoto L_01A0;\nL_0198:\n\tv583 = v529 + 0.5d;\n\tv120 = System.Math::Floor(v583);\nL_01A0:\n\tv621 = UnityEngine.RectOffset::get_right(v356._r);\n\tv625 = UnityEngine.RectOffset::get_right(changeValue);\n\tv632 = v128 * v625;\n\tv633 = v632 + v621;\n\tv636 = 0x1854ED0(&v115 @ stack_-78_v2 (System.Double), 0, 0, isRelative, getter, setter, startValue, changeValue, v633, v632, t.easeOvershootOrAmplitude, t.easePeriod, v57, v58, v59, v60);\n\tv652 = v633 >= 0;\n\tif (v652) goto L_01D1;\n\tv666 = v633 != -0.5d;\n\tif (v666) goto L_01E3;\n\tgoto L_01D6;\nL_01D1:\n\tv677 = v633 != 0.5d;\n\tif (v677) goto L_01E6;\nL_01D6:\n\tv700 = v689 + v688;\n\tv701 = v689 & 1;\n\tv703 = v701 == 0;\n\tv706 = ~v703;\n\tif (v706) goto L_FFFFFFFF;\n\tgoto L_01E2;\nL_01E2:\n\tgoto L_01EE;\nL_01E3:\n\tv681 = v633 + -0.5d;\n\tv112 = System.Math::Ceiling(v681);\n\tgoto L_01EE;\nL_01E6:\n\tv685 = v633 + 0.5d;\n\tv112 = System.Math::Floor(v685);\nL_01EE:\n\tv717 = UnityEngine.RectOffset::get_top(v357._r);\n\tv722 = UnityEngine.RectOffset::get_top(changeValue);\n\tv725 = v128 * v722;\n\tv109 = v725 + v717;\n\tv729 = 0x1854ED0(&v115 @ stack_-78_v2 (System.Double), 0, 0, isRelative, getter, setter, startValue, changeValue, v109, v725, t.easeOvershootOrAmplitude, t.easePeriod, v57, v58, v59, v60);\n\tv739 = v109 >= 0;\n\tif (v739) goto L_021F;\n\tv750 = v109 != -0.5d;\n\tif (v750) goto L_0231;\n\tgoto L_0224;\nL_021F:\n\tv761 = v109 != 0.5d;\n\tif (v761) goto L_0234;\nL_0224:\n\tv782 = v771 + v770;\n\tv783 = v771 & 1;\n\tv785 = v783 == 0;\n\tv788 = ~v785;\n\tif (v788) goto L_FFFFFFFF;\n\tgoto L_0230;\nL_0230:\n\tgoto L_023E;\nL_0231:\n\tv764 = v109 + -0.5d;\n\tv323 = System.Math::Ceiling(v764);\n\tgoto L_023E;\nL_0234:\n\tv768 = v109 + 0.5d;\n\tv323 = System.Math::Floor(v768);\nL_023E:\n\tv797 = UnityEngine.RectOffset::get_bottom(v358._r);\n\tv800 = UnityEngine.RectOffset::get_bottom(changeValue);\n\tv803 = v128 * v800;\n\tv110 = v803 + v797;\n\tv807 = 0x1854ED0(&v115 @ stack_-78_v2 (System.Double), 0, 0, isRelative, getter, setter, startValue, changeValue, v110, v803, t.easeOvershootOrAmplitude, t.easePeriod, v57, v58, v59, v60);\n\tv817 = v110 >= 0;\n\tif (v817) goto L_026F;\n\tv828 = v110 != -0.5d;\n\tif (v828) goto L_0281;\n\tgoto L_0274;\nL_026F:\n\tv839 = v110 != 0.5d;\n\tif (v839) goto L_0284;\nL_0274:\n\tv126 = v849 + v848;\n\tv861 = v849 & 1;\n\tv863 = v861 == 0;\n\tv866 = ~v863;\n\tif (v866) goto L_FFFFFFFF;\n\tgoto L_0280;\nL_0280:\n\tgoto L_0287;\nL_0281:\n\tv842 = v110 + -0.5d;\n\tv341 = System.Math::Ceiling(v842);\n\tgoto L_0287;\nL_0284:\n\tv846 = v110 + 0.5d;\n\tv341 = System.Math::Floor(v846);\nL_0287:\n\tv289 = new UnityEngine.RectOffset();\n\tv893 = v120 != 0x7FF0000000000000;\n\tif (v893) goto L_FFFFFFFF;\n\tgoto L_02A6;\nL_02A6:\n\tv905 = v112 != 0x7FF0000000000000;\n\tif (v905) goto L_FFFFFFFF;\n\tgoto L_02B6;\nL_02B6:\n\tv917 = v323 != 0x7FF0000000000000;\n\tif (v917) goto L_FFFFFFFF;\n\tgoto L_02C5;\nL_02C5:\n\tv101 = v341 != 0x7FF0000000000000;\n\tif (v101) goto L_FFFFFFFF;\n\tgoto L_02CD;\nL_02CD:\n\tUnityEngine.RectOffset::.ctor(v289, v268, v249, v95, v93);\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.RectOffset>::Invoke(setter, v289);\n\tthrow System.NullReferenceException;\n\treturn;\n// 543 bookkeeping instructions omitted: fla\n// ... truncated")]
		public override void EvaluateAndApply(NoOptions options, Tween t, bool isRelative, DOGetter<RectOffset> getter, DOSetter<RectOffset> setter, float elapsed, RectOffset startValue, RectOffset changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice)
		{
			//IL_0a81: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a86: Expected I4, but got Unknown
			//IL_0acb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ad0: Expected I4, but got Unknown
			//IL_0b15: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b1a: Expected I4, but got Unknown
			//IL_09fb: Expected I4, but got F8
			//IL_0b5f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b64: Expected I4, but got Unknown
			//IL_0a16: Expected I4, but got F8
			//IL_0a31: Expected I4, but got F8
			//IL_0a4c: Expected I4, but got F8
			int left = startValue.left;
			_r.left = left;
			int right = startValue.right;
			_r.right = right;
			int top = startValue.top;
			_r.top = top;
			int bottom = startValue.bottom;
			_r.bottom = bottom;
			if (t.loopType == LoopType.Incremental)
			{
				int left2 = _r.left;
				int num = t.completedLoops - (t.isComplete ? 1 : 0);
				int left3 = changeValue.left;
				int num2 = left3 * num;
				int left4 = left2 + num2;
				_r.left = left4;
				int right2 = _r.right;
				int right3 = changeValue.right;
				int num3 = right3 * num;
				int right4 = right2 + num3;
				_r.right = right4;
				int top2 = _r.top;
				int top3 = changeValue.top;
				int num4 = top3 * num;
				int top4 = top2 + num4;
				_r.top = top4;
				int bottom2 = _r.bottom;
				int bottom3 = changeValue.bottom;
				int num5 = bottom3 * num;
				int bottom4 = bottom2 + num5;
				_r.bottom = bottom4;
			}
			if (t.isSequenced)
			{
				Sequence sequenceParent = t.sequenceParent;
				if (sequenceParent.loopType == LoopType.Incremental)
				{
					int num6 = ((t.loopType != LoopType.Incremental) ? 1 : t.loops);
					int left5 = _r.left;
					int num7 = sequenceParent.completedLoops - (sequenceParent.isComplete ? 1 : 0);
					int num8 = num7 * num6;
					int left6 = changeValue.left;
					int num9 = left6 * num8;
					int left7 = left5 + num9;
					_r.left = left7;
					int right5 = _r.right;
					int right6 = changeValue.right;
					int num10 = right6 * num8;
					int right7 = right5 + num10;
					_r.right = right7;
					int top5 = _r.top;
					int top6 = changeValue.top;
					int num11 = top6 * num8;
					int top7 = top5 + num11;
					_r.top = top7;
					int bottom5 = _r.bottom;
					int bottom6 = changeValue.bottom;
					int num12 = bottom6 * num8;
					int bottom7 = bottom5 + num12;
					_r.bottom = bottom7;
				}
			}
			float num13 = EaseManager.Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);
			int left8 = _r.left;
			int left9 = changeValue.left;
			float num14 = num13 * (float)left9;
			float num15 = num14 + (float)left8;
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
			double num16;
			double num17;
			double num18;
			double num19 = default(double);
			if (num15 < 0f)
			{
				if ((double)num15 != -0.5)
				{
					double a = (double)num15 + -0.5;
					num16 = Math.Ceiling(a);
					goto IL_0587;
				}
				num17 = -1.0;
				num18 = num19;
			}
			else
			{
				if ((double)num15 != 0.5)
				{
					double d = (double)num15 + 0.5;
					num16 = Math.Floor(d);
					goto IL_0587;
				}
				num17 = 1.0;
				num18 = num19;
			}
			double num20 = num18 + num17;
			num16 = (((num18 & 1) != 0) ? num20 : num18);
			goto IL_0587;
			IL_0587:
			int right8 = _r.right;
			int right9 = changeValue.right;
			float num21 = num13 * (float)right9;
			float num22 = num21 + (float)right8;
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
			double num23;
			double num24;
			double num25;
			if (num22 < 0f)
			{
				if ((double)num22 != -0.5)
				{
					double a2 = (double)num22 + -0.5;
					num23 = Math.Ceiling(a2);
					goto IL_06de;
				}
				num24 = -1.0;
				num25 = num19;
			}
			else
			{
				if ((double)num22 != 0.5)
				{
					double d2 = (double)num22 + 0.5;
					num23 = Math.Floor(d2);
					goto IL_06de;
				}
				num24 = 1.0;
				num25 = num19;
			}
			double num26 = num25 + num24;
			num23 = (((num25 & 1) != 0) ? num26 : num25);
			goto IL_06de;
			IL_09a6:
			int left10 = default(int);
			int right10 = default(int);
			int top8 = default(int);
			int bottom8 = default(int);
			RectOffset pNewValue = new RectOffset(left10, right10, top8, bottom8);
			if (num16 == 9.218868437227405E+18)
			{
				left10 = int.MinValue;
			}
			else
			{
				left10 = (int)num16;
			}
			if (num23 == 9.218868437227405E+18)
			{
				right10 = int.MinValue;
			}
			else
			{
				right10 = (int)num23;
			}
			double num27;
			if (num27 == 9.218868437227405E+18)
			{
				top8 = int.MinValue;
			}
			else
			{
				top8 = (int)num27;
			}
			double num28;
			if (num28 == 9.218868437227405E+18)
			{
				bottom8 = int.MinValue;
			}
			else
			{
				bottom8 = (int)num28;
			}
			setter(pNewValue);
			return;
			IL_0835:
			int bottom9 = _r.bottom;
			int bottom10 = changeValue.bottom;
			float num29 = num13 * (float)bottom10;
			float num30 = num29 + (float)bottom9;
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
			double num32;
			double num33;
			double num31;
			if (num30 < 0f)
			{
				if ((double)num30 != -0.5)
				{
					double a3 = (double)num30 + -0.5;
					num28 = Math.Ceiling(a3);
					num31 = -0.5;
					goto IL_09a6;
				}
				num32 = -1.0;
				num33 = num19;
			}
			else
			{
				if ((double)num30 != 0.5)
				{
					double d3 = (double)num30 + 0.5;
					num28 = Math.Floor(d3);
					num31 = 0.5;
					goto IL_09a6;
				}
				num32 = 1.0;
				num33 = num19;
			}
			num31 = num33 + num32;
			num28 = (((num33 & 1) != 0) ? num31 : num33);
			goto IL_09a6;
			IL_06de:
			int top9 = _r.top;
			int top10 = changeValue.top;
			float num34 = num13 * (float)top10;
			float num35 = num34 + (float)top9;
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
			double num36;
			double num37;
			if (num35 < 0f)
			{
				if ((double)num35 != -0.5)
				{
					double a4 = (double)num35 + -0.5;
					num27 = Math.Ceiling(a4);
					goto IL_0835;
				}
				num36 = -1.0;
				num37 = num19;
			}
			else
			{
				if ((double)num35 != 0.5)
				{
					double d4 = (double)num35 + 0.5;
					num27 = Math.Floor(d4);
					goto IL_0835;
				}
				num36 = 1.0;
				num37 = num19;
			}
			double num38 = num37 + num36;
			num27 = (((num37 & 1) != 0) ? num38 : num37);
			goto IL_0835;
		}

		[Token(Token = "0x6000323")]
		[Address(RVA = "0xC23254", Offset = "0xC23254", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35776]) = v37;\nL_001A:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<System.Object, System.Object, DG.Tweening.Plugins.Options.NoOptions>::.ctor(this);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RectOffsetPlugin()
		{
		}

		[Token(Token = "0x6000324")]
		[Address(RVA = "0xC2329C", Offset = "0xC2329C", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = DG.Tweening.Plugins.RectOffsetPlugin;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv43 = UnityEngine.RectOffset;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv39 = 1;\n\t*([1A35777]) = v39;\nL_0018:\n\tv41 = new UnityEngine.RectOffset();\n\tUnityEngine.RectOffset::.ctor(v41);\n\tv47._r = v41;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static RectOffsetPlugin()
		{
			RectOffset r = new RectOffset();
			_r = r;
		}
	}
}
