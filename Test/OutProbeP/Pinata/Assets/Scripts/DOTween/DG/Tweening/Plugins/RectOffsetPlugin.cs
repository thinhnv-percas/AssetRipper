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
	[Token(Token = "0x2000026")]
	public class RectOffsetPlugin : ABSTweenPlugin<RectOffset, RectOffset, NoOptions>
	{
		[Token(Token = "0x40000D1")]
		private static RectOffset _r;

		[Token(Token = "0x60001D2")]
		[Address(RVA = "0x10DA50C", Offset = "0x10DA50C", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tt.endValue = 0;\n\tt.changeValue = 0;\n\tt.startValue = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset(TweenerCore<RectOffset, RectOffset, NoOptions> t)
		{
			t.endValue = null;
			t.changeValue = null;
			t.startValue = null;
		}

		[Token(Token = "0x60001D3")]
		[Address(RVA = "0x10DA52C", Offset = "0x10DA52C", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EF2298]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, t, isRelative, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([20274BE]) = v41;\nL_001E:\n\tv59 = DG.Tweening.Core.DOGetter`1<UnityEngine.RectOffset>::Invoke(*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.RectOffset, UnityEngine.RectOffset, DG.Tweening.Plugins.Options.NoOptions>)+140]));\n\tt.startValue = t.endValue;\n\tt.endValue = v59;\n\tv110 = isRelative == 0;\n\tif (v110) goto L_0074;\n\tv60 = UnityEngine.RectOffset::get_left(t.endValue);\n\tv138 = UnityEngine.RectOffset::get_left(t.endValue);\n\tv52 = v138 + v60;\n\tUnityEngine.RectOffset::set_left(t.endValue, v52);\n\tv62 = UnityEngine.RectOffset::get_right(t.startValue);\n\tv142 = UnityEngine.RectOffset::get_right(t.endValue);\n\tv54 = v142 + v62;\n\tUnityEngine.RectOffset::set_right(t.startValue, v54);\n\tv64 = UnityEngine.RectOffset::get_top(t.startValue);\n\tv146 = UnityEngine.RectOffset::get_top(t.endValue);\n\tv56 = v146 + v64;\n\tUnityEngine.RectOffset::set_top(t.startValue, v56);\n\tv66 = UnityEngine.RectOffset::get_bottom(t.startValue);\n\tv150 = UnityEngine.RectOffset::get_bottom(t.endValue);\n\tv112 = v150 + v66;\n\tUnityEngine.RectOffset::set_bottom(t.startValue, v112);\nL_0074:\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.RectOffset>::Invoke(*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.RectOffset, UnityEngine.RectOffset, DG.Tweening.Plugins.Options.NoOptions>)+148]), t.startValue);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 90 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<RectOffset, RectOffset, NoOptions> t, bool isRelative)
		{
			//IL_0016: Expected O, but got I
			//IL_01a4: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.RectOffset, UnityEngine.RectOffset, DG.Tweening.Plugins.Options.NoOptions>)+140]");
			RectOffset endValue = ((DOGetter<RectOffset>)0)();
			t.startValue = t.endValue;
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.RectOffset, UnityEngine.RectOffset, DG.Tweening.Plugins.Options.NoOptions>)+148]");
			((DOSetter<RectOffset>)0)(t.startValue);
		}

		[Token(Token = "0x60001D4")]
		[Address(RVA = "0x10DA6AC", Offset = "0x10DA6AC", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EB18A0]);\n\tv27 = *([v26 @ X8_v7]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, t, fromValue, setImmediately, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([20274BF]) = v44;\nL_0019:\n\tt.startValue = fromValue;\n\tv47 = setImmediately == 0;\n\tif (v47) goto L_0034;\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.RectOffset>::Invoke(*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.RectOffset, UnityEngine.RectOffset, DG.Tweening.Plugins.Options.NoOptions>)+148]), fromValue);\n\treturn;\nL_0034:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<RectOffset, RectOffset, NoOptions> t, RectOffset fromValue, bool setImmediately)
		{
			//IL_0044: Expected O, but got I
			t.startValue = fromValue;
			if (setImmediately)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.RectOffset, UnityEngine.RectOffset, DG.Tweening.Plugins.Options.NoOptions>)+148]");
				((DOSetter<RectOffset>)0)(fromValue);
			}
		}

		[Token(Token = "0x60001D5")]
		[Address(RVA = "0x10DA738", Offset = "0x10DA738", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1EC7C60]);\n\tv25 = *([v24 @ X8_v8]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, t, value, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([20274C0]) = v44;\nL_001A:\n\tv48 = UnityEngine.RectOffset::get_left(value);\n\tv54 = UnityEngine.RectOffset::get_right(value);\n\tv58 = UnityEngine.RectOffset::get_top(value);\n\tv90 = UnityEngine.RectOffset::get_bottom(value);\n\tv95 = new UnityEngine.RectOffset();\n\tUnityEngine.RectOffset::.ctor(v95, v48, v54, v58, v90);\n\treturn v95;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override RectOffset ConvertToStartValue(TweenerCore<RectOffset, RectOffset, NoOptions> t, RectOffset value)
		{
			int left = value.left;
			int right = value.right;
			int top = value.top;
			int bottom = value.bottom;
			return new RectOffset(left, right, top, bottom);
		}

		[Token(Token = "0x60001D6")]
		[Address(RVA = "0x10DA808", Offset = "0x10DA808", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv42 = UnityEngine.RectOffset::get_left(t.endValue);\n\tv99 = UnityEngine.RectOffset::get_left(t.startValue);\n\tv34 = v99 + v42;\n\tUnityEngine.RectOffset::set_left(t.endValue, v34);\n\tv44 = UnityEngine.RectOffset::get_right(t.endValue);\n\tv103 = UnityEngine.RectOffset::get_right(t.startValue);\n\tv36 = v103 + v44;\n\tUnityEngine.RectOffset::set_right(t.endValue, v36);\n\tv46 = UnityEngine.RectOffset::get_top(t.endValue);\n\tv107 = UnityEngine.RectOffset::get_top(t.startValue);\n\tv38 = v107 + v46;\n\tUnityEngine.RectOffset::set_top(t.endValue, v38);\n\tv48 = UnityEngine.RectOffset::get_bottom(t.endValue);\n\tv111 = UnityEngine.RectOffset::get_bottom(t.startValue);\n\tv87 = v111 + v48;\n\tUnityEngine.RectOffset::set_bottom(t.endValue, v87);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60001D7")]
		[Address(RVA = "0x10DA924", Offset = "0x10DA924", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv34 = *([1F02850]);\n\tv35 = *([v34 @ X8_v17]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, t, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv54 = 0 | 1;\n\t*([20274C1]) = v54;\nL_0021:\n\tv79 = UnityEngine.RectOffset::get_left(t.endValue);\n\tv80 = UnityEngine.RectOffset::get_left(t.startValue);\n\tv81 = UnityEngine.RectOffset::get_right(t.endValue);\n\tv82 = UnityEngine.RectOffset::get_right(t.startValue);\n\tv83 = UnityEngine.RectOffset::get_top(t.endValue);\n\tv84 = UnityEngine.RectOffset::get_top(t.startValue);\n\tv85 = UnityEngine.RectOffset::get_bottom(t.endValue);\n\tv164 = UnityEngine.RectOffset::get_bottom(t.startValue);\n\tv147 = new UnityEngine.RectOffset();\n\tv145 = v79 - v80;\n\tv129 = v81 - v82;\n\tv127 = v83 - v84;\n\tv125 = v85 - v164;\n\tUnityEngine.RectOffset::.ctor(v147, v145, v129, v127, v125);\n\tt.changeValue = v147;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 90 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60001D8")]
		[Address(RVA = "0x10DAA80", Offset = "0x10DAA80", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1EDA9F0]);\n\tv27 = *([v26 @ X8_v8]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, options, changeValue, methodInfo, v31, v32, v33, v34, unitsXSecond, v35, v36, v37, v38, v39, v40, v41);\n\tv45 = 0 | 1;\n\t*([20274C2]) = v45;\nL_001B:\n\tv49 = UnityEngine.RectOffset::get_right(changeValue);\n\tv53 = -v49;\n\tv57 = v49 < 0;\n\tv60 = v49 ^ v49;\n\tv61 = v49 & v60;\n\tv62 = v61 < 0;\n\tv65 = v57 == v62;\n\tv66 = ~v65;\n\tv67 = ~v66;\n\tif (v67) goto L_FFFFFFFF;\n\tgoto L_0031;\nL_0031:\n\tv129 = UnityEngine.RectOffset::get_bottom(changeValue);\n\tv134 = -v129;\n\tv139 = v129 < 0;\n\tv142 = v129 ^ v129;\n\tv143 = v129 & v142;\n\tv144 = v143 < 0;\n\tv145 = v139 == v144;\n\tv146 = ~v145;\n\tv80 = ~v146;\n\tif (v80) goto L_FFFFFFFF;\n\tgoto L_004C;\nL_004C:\n\tgoto L_0052;\n\tv152 = *([v135 @ X0_v8 (Il2CppClass<System.Math>)+E0]);\n\tv153 = v152 == 0;\n\tv154 = ~v153;\n\tgoto L_0052;\n\tv156 = \"il2cpp_codegen_runtime_class_init\"(v135, v64, changeValue, methodInfo, v31, v32, v33, v34, v133, v134, v36, v37, v38, v39, v40, v41);\nL_0052:\n\tv157 = v128 * v128;\n\tv158 = v149 * v149;\n\tv110 = v157 + v158;\n\tv163 = UnityEngine.Mathf::Sqrt(v110);\n\tv104 = v163 - v163;\n\tv95 = v163 ^ v163;\n\tv92 = v163 ^ v104;\n\tv89 = v95 & v92;\n\tv86 = v89 < 0;\n\tv83 = ~v86;\n\tif (v83) goto L_0063;\n\tv162 = 0x6D2F50(System.Math, 0, changeValue, methodInfo, v31, v32, v33, v34, v110, v110, v36, v37, v38, v39, v40, v41);\nL_0063:\n\treturnVal2 = v163 / unitsXSecond;\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturn unitsXSecond;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float GetSpeedBasedDuration(NoOptions options, float unitsXSecond, RectOffset changeValue)
		{
			//IL_010d: Expected O, but got F4
			//IL_011a: Expected O, but got F4
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
			float num11 = (float)num9 + (float)num10;
			float num12 = Mathf.Sqrt(num11);
			float num13 = num12 - num12;
			object obj = num12 ^ num12;
			object obj2 = num12 ^ num13;
			int num14 = (int)((long)(IntPtr)obj & (long)(IntPtr)obj2);
			if (num14 < 0)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:sqrtf", "Method not found @6D2F50 (native sqrtf)");
				num12 = num11;
			}
			return num12 / unitsXSecond;
		}

		[Token(Token = "0x60001D9")]
		[Address(RVA = "0x10DAB60", Offset = "0x10DAB60", Length = "0x728")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv52 = *([1ED8FD8]);\n\tv53 = *([v52 @ X8_v69]);\n\tv54 = \"il2cpp_codegen_initialize_method\"(v53, options, t, isRelative, getter, setter, startValue, changeValue, elapsed, duration, v58, v59, v60, v61, v62, v63);\n\tv67 = 0 | 1;\n\t*([20274C3]) = v67;\nL_002A:\n\tgoto L_0037;\n\tv74 = *([v70 @ X0_v2 (Il2CppClass<DG.Tweening.Plugins.RectOffsetPlugin>)+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\t// 46 Jump @b139\n\tv82 = \"il2cpp_codegen_runtime_class_init\"(v70, options, t, isRelative, getter, setter, startValue, changeValue, elapsed, duration, v58, v59, v60, v61, v62, v63);\n\tv78 = DG.Tweening.Plugins.RectOffsetPlugin;\nL_0037:\n\tv87 = UnityEngine.RectOffset::get_left(startValue);\n\tUnityEngine.RectOffset::set_left(v83._r, v87);\n\tv221 = UnityEngine.RectOffset::get_right(startValue);\n\tUnityEngine.RectOffset::set_right(v280._r, v221);\n\tv222 = UnityEngine.RectOffset::get_top(startValue);\n\tUnityEngine.RectOffset::set_top(v281._r, v222);\n\tv223 = UnityEngine.RectOffset::get_bottom(startValue);\n\tUnityEngine.RectOffset::set_bottom(v282._r, v223);\n\tv138 = t.loopType != 2;\n\tif (v138) goto L_00C5;\n\tgoto L_0083;\n\tv490 = *([v477 @ X0_v81 (Il2CppClass<DG.Tweening.Plugins.RectOffsetPlugin>)+E0]);\n\tv491 = v490 == 0;\n\tv492 = ~v491;\n\t// 122 ConditionalJump @b140, v492 @ TEMP_v70\n\tv518 = \"il2cpp_codegen_runtime_class_init\"(v477, v208, v194, isRelative, getter, setter, startValue, changeValue, elapsed, duration, v58, v59, v60, v61, v62, v63);\n\tv493 = DG.Tweening.Plugins.RectOffsetPlugin;\nL_0083:\n\tv225 = UnityEngine.RectOffset::get_left(v283._r);\n\tv131 = t.completedLoops - t.isComplete;\n\tv537 = UnityEngine.RectOffset::get_left(changeValue);\n\tv541 = v537 * v131;\n\tv210 = v225 + v541;\n\tUnityEngine.RectOffset::set_left(v283._r, v210);\n\tv556 = UnityEngine.RectOffset::get_right(v284._r);\n\tv567 = UnityEngine.RectOffset::get_right(changeValue);\n\tv581 = v567 * v131;\n\tv211 = v556 + v581;\n\tUnityEngine.RectOffset::set_right(v284._r, v211);\n\tv624 = UnityEngine.RectOffset::get_top(v285._r);\n\tv636 = UnityEngine.RectOffset::get_top(changeValue);\n\tv663 = v636 * v131;\n\tv212 = v624 + v663;\n\tUnityEngine.RectOffset::set_top(v285._r, v212);\n\tv677 = UnityEngine.RectOffset::get_bottom(v286._r);\n\tv688 = UnityEngine.RectOffset::get_bottom(changeValue);\n\tv485 = v688 * v131;\n\tv482 = v677 + v485;\n\tUnityEngine.RectOffset::set_bottom(v286._r, v482);\nL_00C5:\n\tv489 = ~t.isSequenced;\n\tif (v489) goto L_0141;\n\tv287 = t.sequenceParent;\n\tv497 = v287.loopType != 2;\n\tif (v497) goto L_0141;\n\tv139 = t.loopType != 2;\n\tif (v139) goto L_FFFFFFFF;\n\tv133 = t.loops;\n\tgoto L_00EB;\nL_00EB:\n\tgoto L_00F8;\n\tv546 = *([v542 @ X0_v57 (Il2CppClass<DG.Tweening.Plugins.RectOffsetPlugin>)+E0]);\n\tv547 = v546 == 0;\n\tv548 = ~v547;\n\t// 239 Jump @b142\n\tv557 = \"il2cpp_codegen_runtime_class_init\"(v542, v213, v198, isRelative, getter, setter, startValue, changeValue, elapsed, duration, v58, v59, v60, v61, v62, v63);\n\tv549 = DG.Tweening.Plugins.RectOffsetPlugin;\nL_00F8:\n\tv230 = UnityEngine.RectOffset::get_left(v288._r);\n\tv583 = v287.completedLoops - v287.isComplete;\n\tv134 = v583 * v133;\n\tv586 = UnityEngine.RectOffset::get_left(changeValue);\n\tv599 = v586 * v134;\n\tv215 = v230 + v599;\n\tUnityEngine.RectOffset::set_left(v288._r, v215);\n\tv639 = UnityEngine.RectOffset::get_right(v289._r);\n\tv666 = UnityEngine.RectOffset::get_right(changeValue);\n\tv672 = v666 * v134;\n\tv216 = v639 + v672;\n\tUnityEngine.RectOffset::set_right(v289._r, v216);\n\tv691 = UnityEngine.RectOffset::get_top(v290._r);\n\tv704 = UnityEngine.RectOffset::get_top(changeValue);\n\tv727 = v704 * v134;\n\tv217 = v691 + v727;\n\tUnityEngine.RectOffset::set_top(v290._r, v217);\n\tv762 = UnityEngine.RectOffset::get_bottom(v291._r);\n\tv769 = UnityEngine.RectOffset::get_bottom(changeValue);\n\tv513 = v769 * v134;\n\tv509 = v762 + v513;\n\tUnityEngine.RectOffset::set_bottom(v291._r, v509);\nL_0141:\n\tv113 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);\n\tgoto L_0153;\n\tv527 = *([v521 @ X0_v23 (Il2CppClass<DG.Tweening.Plugins.RectOffsetPlugin>)+E0]);\n\tv528 = v527 == 0;\n\tv529 = ~v528;\n\t// 331 ConditionalJump @b143, v529 @ TEMP_v41\n\tv540 = \"il2cpp_codegen_runtime_class_init\"(v521, v377, v202, isRelative, getter, setter, startValue, changeValue, v113, v110, v118, v116, v60, v61, v62, v63);\n\tv531 = DG.Tweening.Plugins.RectOffsetPlugin;\nL_0153:\n\tv234 = UnityEngine.RectOffset::get_left(v292._r);\n\tv553 = UnityEngine.RectOffset::get_left(changeValue);\n\tgoto L_016A;\n\tv568 = *([v561 @ X8_v23+E0]);\n\tv569 = v568 == 0;\n\tv570 = ~v569;\n\tif (v570) goto L_016A;\n\tv587 = v561;\n\tv572 = \"il2cpp_codegen_runtime_class_init\"(v587, v374, v202, isRelative, getter, setter, startValue, changeValue, v113, v110, v118, v116, v60, v61, v62, v63);\nL_016A:\n\tv576 = v113 * v553;\n\tv577 = v576 + v234;\n\tv580 = 0x6D1ED0(&v319 @ stack_-88_v3 (System.Double), 0, 0, isRelative, getter, setter, startValue, changeValue, v577, v576, t.easeOvershootOrAmplitude, t.easePeriod, v60, v61, v62, v63);\n\tv597 = v577 >= 0;\n\tif (v597) goto L_0194;\n\tv610 = v577 != -0.5d;\n\tif (v610) goto L_01A6;\n\tgoto L_0199;\nL_0194:\n\tv621 = v577 != 0.5d;\n\tif (v621) goto L_01A9;\nL_0199:\n\tv652 = v641 + v640;\n\tv653 = v641 & 1;\n\tv655 = v653 == 0;\n\tv658 = ~v655;\n\tif (v658) goto L_FFFFFFFF;\n\tgoto L_01A5;\nL_01A5:\n\tgoto L_01B1;\nL_01A6:\n\tv628 = v577 + -0.5d;\n\tv108 = System.Math::Ceiling(v628);\n\tgoto L_01B1;\nL_01A9:\n\tv632 = v577 + 0.5d;\n\tv108 = System.Math::Floor(v632);\nL_01B1:\n\tv670 = UnityEngine.RectOffset::get_right(v398._r);\n\tv674 = UnityEngine.RectOffset::get_right(changeValue);\n\tv681 = v113 * v674;\n\tv682 = v681 + v670;\n\tv685 = 0x6D1ED0(&v319 @ stack_-88_v3 (System.Double), 0, 0, isRelative, getter, setter, startValue, changeValue, v682, v681, t.easeOvershootOrAmplitude, t.easePeriod, v60, v61, v62, v63);\n\tv701 = v682 >= 0;\n\tif (v701) goto L_01E2;\n\tv715 = v682 != -0.5d;\n\tif (v715) goto L_01F4;\n\tgoto L_01E7;\nL_01E2:\n\tv726 = v682 != 0.5d;\n\tif (v726) goto L_01F7;\nL_01E7:\n\tv749 = v738 + v737;\n\tv750 = v738 & 1;\n\tv752 = v750 == 0;\n\tv755 = ~v752;\n\tif (v755) goto L_FFFFFFFF;\n\tgoto L_01F3;\nL_01F3:\n\tgoto L_01FF;\nL_01F4:\n\tv730 = v682 + -0.5d;\n\tv103 = System.Math::Ceiling(v730);\n\tgoto L_01FF;\nL_01F7:\n\tv734 = v682 + 0.5d;\n\tv103 = System.Math::Floor(v734);\nL_01FF:\n\tv766 = UnityEngine.RectOffset::get_top(v399._r);\n\tv771 = UnityEngine.RectOffset::get_top(changeValue);\n\tv774 = v113 * v771;\n\tv316 = v774 + v766;\n\tv778 = 0x6D1ED0(&v319 @ stack_-88_v3 (System.Double), 0, 0, isRelative, getter, setter, startValue, changeValue, v316, v774, t.easeOvershootOrAmplitude, t.easePeriod, v60, v61, v62, v63);\n\tv788 = v316 >= 0;\n\tif (v788) goto L_0230;\n\tv799 = v316 != -0.5d;\n\tif (v799) goto L_0242;\n\tgoto L_0235;\nL_0230:\n\tv810 = v316 != 0.5d;\n\tif (v810) goto L_0245;\nL_0235:\n\tv831 = v820 + v819;\n\tv832 = v820 & 1;\n\tv834 = v832 == 0;\n\tv837 = ~v834;\n\tif (v837) goto L_FFFFFFFF;\n\tgoto L_0241;\nL_0241:\n\tgoto L_024D;\nL_0242:\n\tv813 = v316 + -0.5d;\n\tv261 = System.Math::Ceiling(v813);\n\tgoto L_024D;\nL_0245:\n\tv817 = v316 + 0.5d;\n\tv261 = System.Math::Floor(v817);\nL_024D:\n\tv845 = UnityEngine.RectOffset::get_bottom(v400._r);\n\tv848 = UnityEngine.RectOffset::get_bottom(changeValue);\n\tv851 = v113 * v848;\n\tv101 = v851 + v845;\n\tv855 = 0x6D1ED0(&v319 @ stack_-88_v3 (System.Double), 0, 0, isRelative, getter, setter, startValue, changeValue, v101, v851, t.easeOvershootOrAmplitude, t.easePeriod, v60, v61, v62, v63);\n\tv865 = v101 >= 0;\n\tif (v865) goto L_027E;\n\tv876 = v101 != -0.5d;\n\tif (v876) goto L_0290;\n\tgoto L_0283;\nL_027E:\n\tv887 = v101 != 0.5d;\n\tif (v887) goto L_0293;\nL_0283:\n\tv908 = v897 + v896;\n\tv909 = v897 & 1;\n\tv911 = v909 == 0;\n\tv914 = ~v911;\n\tif (v914) goto L_FFFFFFFF;\n\tgoto L_028F;\nL_028F:\n\tgoto L_0298;\nL_0290:\n\tv890 = v101 + -0.5d;\n\tv278 = System.Math::Ceiling(v890);\n\tgoto L_0298;\nL_0293:\n\tv894 = v101 + 0.5d;\n\tv278 = System.Math::Floor(v894);\nL_0298:\n\tv235 = new UnityEngine.RectOffset();\n\tUnityEngine.RectOffset::.ctor(v235, v108, v103, v261, v278);\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.RectOffset>::Invoke(setter, v235);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 495 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void EvaluateAndApply(NoOptions options, Tween t, bool isRelative, DOGetter<RectOffset> getter, DOSetter<RectOffset> setter, float elapsed, RectOffset startValue, RectOffset changeValue, float duration, bool usingInversePosition, UpdateNotice updateNotice)
		{
			//IL_09db: Unknown result type (might be due to invalid IL or missing references)
			//IL_09e0: Expected I4, but got Unknown
			//IL_0a25: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a2a: Expected I4, but got Unknown
			//IL_0a6f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a74: Expected I4, but got Unknown
			//IL_09a1: Expected I4, but got F8
			//IL_09a1: Expected I4, but got F8
			//IL_09a1: Expected I4, but got F8
			//IL_09a1: Expected I4, but got F8
			//IL_0ab9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0abe: Expected I4, but got Unknown
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
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @6D1ED0 (native modf)");
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
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @6D1ED0 (native modf)");
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
			IL_098c:
			double num27;
			double num28;
			RectOffset pNewValue = new RectOffset((int)num16, (int)num23, (int)num27, (int)num28);
			setter(pNewValue);
			return;
			IL_0835:
			int bottom8 = _r.bottom;
			int bottom9 = changeValue.bottom;
			float num29 = num13 * (float)bottom9;
			float num30 = num29 + (float)bottom8;
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @6D1ED0 (native modf)");
			double num31;
			double num32;
			if (num30 < 0f)
			{
				if ((double)num30 != -0.5)
				{
					double a3 = (double)num30 + -0.5;
					num28 = Math.Ceiling(a3);
					goto IL_098c;
				}
				num31 = -1.0;
				num32 = num19;
			}
			else
			{
				if ((double)num30 != 0.5)
				{
					double d3 = (double)num30 + 0.5;
					num28 = Math.Floor(d3);
					goto IL_098c;
				}
				num31 = 1.0;
				num32 = num19;
			}
			double num33 = num32 + num31;
			num28 = (((num32 & 1) != 0) ? num33 : num32);
			goto IL_098c;
			IL_06de:
			int top8 = _r.top;
			int top9 = changeValue.top;
			float num34 = num13 * (float)top9;
			float num35 = num34 + (float)top8;
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @6D1ED0 (native modf)");
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

		[Token(Token = "0x60001DA")]
		[Address(RVA = "0x10DB288", Offset = "0x10DB288", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1ED6578]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20274C4]) = v38;\nL_001C:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<UnityEngine.RectOffset, UnityEngine.RectOffset, DG.Tweening.Plugins.Options.NoOptions>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RectOffsetPlugin()
		{
		}

		[Token(Token = "0x60001DB")]
		[Address(RVA = "0x10DB2D8", Offset = "0x10DB2D8", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EB2DF0]);\n\tv15 = *([v14 @ X8_v10]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20274C5]) = v35;\nL_0014:\n\tv39 = new UnityEngine.RectOffset();\n\tUnityEngine.RectOffset::.ctor(v39);\n\tv45._r = v39;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static RectOffsetPlugin()
		{
			RectOffset r = new RectOffset();
			_r = r;
		}
	}
}
