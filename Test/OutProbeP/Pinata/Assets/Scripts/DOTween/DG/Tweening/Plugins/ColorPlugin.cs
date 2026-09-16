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
	[Token(Token = "0x2000023")]
	public class ColorPlugin : ABSTweenPlugin<Color, Color, ColorOptions>
	{
		[Token(Token = "0x60001B7")]
		[Address(RVA = "0x107FCA4", Offset = "0x107FCA4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset(TweenerCore<Color, Color, ColorOptions> t)
		{
		}

		[Token(Token = "0x60001B8")]
		[Address(RVA = "0x107FCA8", Offset = "0x107FCA8", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1EBBB08]);\n\tv31 = *([v30 @ X8_v12]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, t, isRelative, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv49 = 0 | 1;\n\t*([2026A40]) = v49;\nL_001F:\n\tv92 = t.endValue;\n\tv90 = t.endValue.g;\n\tv88 = t.endValue.b;\n\tv86 = t.endValue.a;\n\tv61 = DG.Tweening.Core.DOGetter`1<UnityEngine.Color>::Invoke(t.getter);\n\tt.endValue.r = v61;\n\tt.endValue.g = v61.g;\n\tt.endValue.b = v61.b;\n\tt.endValue.a = v61.a;\n\tv103 = isRelative == 0;\n\tif (v103) goto L_0040;\n\t// 54 MakeStruct v110 @ AGG107FD40_1_v3 (UnityEngine.Color), typeof(UnityEngine.Color), t.endValue (UnityEngine.Color), t.endValue.g (System.Single), t.endValue.b (System.Single), t.endValue.a (System.Single)\n\tv111 = UnityEngine.Color::op_Addition(v61, v110);\nL_0040:\n\tt.startValue.r = v92;\n\tt.startValue.g = v90;\n\tt.startValue.b = v88;\n\tt.startValue.a = v86;\n\tv201 = t + 0x12C;\n\tv165 = t + 0x130;\n\tv162 = t + 0x134;\n\tv135 = t + 0x11C;\n\tv132 = t + 0x120;\n\tv129 = t + 0x124;\n\tv212 = t.plugOptions != 0;\n\tif (v212) goto L_005E;\n\tgoto L_005E;\nL_005E:\n\tv215 = t.plugOptions != 0;\n\tif (v215) goto L_0064;\n\tgoto L_0064;\nL_0064:\n\tv126 = t.plugOptions != 0;\n\tif (v126) goto L_0079;\n\tgoto L_0079;\nL_0079:\n\t// 121 MakeStruct v121 @ AGG107FDC8_1_v1 (UnityEngine.Color), typeof(UnityEngine.Color), [v201 @ X8_v7], [v165 @ X9_v2], [v162 @ X10_v2], v86 @ V8_v3 (System.Single)\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::Invoke(t.setter, v121);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<Color, Color, ColorOptions> t, bool isRelative)
		{
			//IL_0183: Expected O, but got I
			//IL_0192: Expected O, but got I
			//IL_01a1: Expected O, but got I
			//IL_01b0: Expected O, but got I
			//IL_01bf: Expected O, but got I
			//IL_01ce: Expected O, but got I
			//IL_02c3: Expected F4, but got O
			//IL_02d0: Expected F4, but got O
			//IL_02dd: Expected F4, but got O
			Color color = t.endValue;
			float g = t.endValue.g;
			float b = t.endValue.b;
			float a = t.endValue.a;
			Color color2 = t.getter();
			t.endValue.r = color2.r;
			t.endValue.g = color2.g;
			t.endValue.b = color2.b;
			t.endValue.a = color2.a;
			if (isRelative)
			{
				Color color3 = default(Color);
				color3.r = t.endValue.r;
				color3.g = t.endValue.g;
				color3.b = t.endValue.b;
				color3.a = t.endValue.a;
				Color color4 = color2 + color3;
				a = color4.a;
				b = color4.b;
				g = color4.g;
				color = color4;
			}
			t.startValue.r = color.r;
			t.startValue.g = g;
			t.startValue.b = b;
			t.startValue.a = a;
			object obj = (long)(IntPtr)t + 300L;
			object obj2 = (long)(IntPtr)t + 304L;
			object obj3 = (long)(IntPtr)t + 308L;
			object obj4 = (long)(IntPtr)t + 284L;
			object obj5 = (long)(IntPtr)t + 288L;
			object obj6 = (long)(IntPtr)t + 292L;
			if ((object)t.plugOptions == null)
			{
				obj = obj4;
			}
			if ((object)t.plugOptions == null)
			{
				obj2 = obj5;
			}
			if ((object)t.plugOptions == null)
			{
				obj3 = obj6;
			}
			Color pNewValue = default(Color);
			pNewValue.r = (float)obj;
			pNewValue.g = (float)obj2;
			pNewValue.b = (float)obj3;
			pNewValue.a = a;
			t.setter(pNewValue);
		}

		[Token(Token = "0x60001B9")]
		[Address(RVA = "0x107FDD4", Offset = "0x107FDD4", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv38 = *([1EE9FA8]);\n\tv39 = *([v38 @ X8_v12]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, t, setImmediately, methodInfo, v42, v43, v44, v45, fromValue, v0, v2, v3, v46, v47, v48, v49);\n\tv53 = 0 | 1;\n\t*([2026A41]) = v53;\nL_0022:\n\tt.startValue.r = fromValue;\n\tt.startValue.g = fromValue.g;\n\tt.startValue.b = fromValue.b;\n\tt.startValue.a = fromValue.a;\n\tv56 = setImmediately == 0;\n\tif (v56) goto L_005A;\n\tv59 = t.plugOptions == 0;\n\tif (v59) goto L_004D;\n\tv94 = DG.Tweening.Core.DOGetter`1<UnityEngine.Color>::Invoke(t.getter);\nL_004D:\n\t// 77 MakeStruct v106 @ AGG107FEA4_1_v1 (UnityEngine.Color), typeof(UnityEngine.Color), v80 @ V11_v4 (UnityEngine.Color), v82 @ V10_v4 (System.Single), v84 @ V9_v4 (System.Single), fromValue.a (System.Single)\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::Invoke(t.setter, v106);\n\treturn;\nL_005A:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<Color, Color, ColorOptions> t, Color fromValue, bool setImmediately)
		{
			Color color = default(Color);
			t.startValue.r = color.r;
			t.startValue.g = fromValue.g;
			t.startValue.b = fromValue.b;
			t.startValue.a = fromValue.a;
			if (setImmediately)
			{
				bool flag = (object)t.plugOptions == null;
				Color color2 = fromValue;
				float g = fromValue.g;
				float b = fromValue.b;
				if (!flag)
				{
					Color color3 = t.getter();
					color2 = color3;
					g = color3.g;
					b = color3.b;
				}
				Color pNewValue = default(Color);
				pNewValue.r = color2.r;
				pNewValue.g = g;
				pNewValue.b = b;
				pNewValue.a = fromValue.a;
				t.setter(pNewValue);
			}
		}

		[Token(Token = "0x60001BA")]
		[Address(RVA = "0x107FEC8", Offset = "0x107FEC8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Color ConvertToStartValue(TweenerCore<Color, Color, ColorOptions> t, Color value)
		{
			return value;
		}

		[Token(Token = "0x60001BB")]
		[Address(RVA = "0x107FECC", Offset = "0x107FECC", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t// 17 MakeStruct v20 @ AGG107FF04_0_v1 (UnityEngine.Color), typeof(UnityEngine.Color), t.endValue (UnityEngine.Color), t.endValue.g (System.Single), t.endValue.b (System.Single), t.endValue.a (System.Single)\n\t// 18 MakeStruct v21 @ AGG107FF04_1_v1 (UnityEngine.Color), typeof(UnityEngine.Color), t.startValue (UnityEngine.Color), t.startValue.g (System.Single), t.startValue.b (System.Single), t.startValue.a (System.Single)\n\tv22 = UnityEngine.Color::op_Addition(v20, v21);\n\tt.endValue.r = v22;\n\tt.endValue.g = v22.g;\n\tt.endValue.b = v22.b;\n\tt.endValue.a = v22.a;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetRelativeEndValue(TweenerCore<Color, Color, ColorOptions> t)
		{
			Color color = default(Color);
			color.r = t.endValue.r;
			color.g = t.endValue.g;
			color.b = t.endValue.b;
			color.a = t.endValue.a;
			Color color2 = default(Color);
			color2.r = t.startValue.r;
			color2.g = t.startValue.g;
			color2.b = t.startValue.b;
			color2.a = t.startValue.a;
			Color color3 = color + color2;
			t.endValue.r = color3.r;
			t.endValue.g = color3.g;
			t.endValue.b = color3.b;
			t.endValue.a = color3.a;
		}

		[Token(Token = "0x60001BC")]
		[Address(RVA = "0x107FF2C", Offset = "0x107FF2C", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t// 17 MakeStruct v20 @ AGG107FF64_0_v1 (UnityEngine.Color), typeof(UnityEngine.Color), t.endValue (UnityEngine.Color), t.endValue.g (System.Single), t.endValue.b (System.Single), t.endValue.a (System.Single)\n\t// 18 MakeStruct v21 @ AGG107FF64_1_v1 (UnityEngine.Color), typeof(UnityEngine.Color), t.startValue (UnityEngine.Color), t.startValue.g (System.Single), t.startValue.b (System.Single), t.startValue.a (System.Single)\n\tv22 = UnityEngine.Color::op_Subtraction(v20, v21);\n\tt.changeValue.r = v22;\n\tt.changeValue.g = v22.g;\n\tt.changeValue.b = v22.b;\n\tt.changeValue.a = v22.a;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetChangeValue(TweenerCore<Color, Color, ColorOptions> t)
		{
			Color color = default(Color);
			color.r = t.endValue.r;
			color.g = t.endValue.g;
			color.b = t.endValue.b;
			color.a = t.endValue.a;
			Color color2 = default(Color);
			color2.r = t.startValue.r;
			color2.g = t.startValue.g;
			color2.b = t.startValue.b;
			color2.a = t.startValue.a;
			Color color3 = color - color2;
			t.changeValue.r = color3.r;
			t.changeValue.g = color3.g;
			t.changeValue.b = color3.b;
			t.changeValue.a = color3.a;
		}

		[Token(Token = "0x60001BD")]
		[Address(RVA = "0x107FF8C", Offset = "0x107FF8C", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = 1f / unitsXSecond;\n\treturn returnVal1;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float GetSpeedBasedDuration(ColorOptions options, float unitsXSecond, Color changeValue)
		{
			return 1f / unitsXSecond;
		}

		[Token(Token = "0x60001BE")]
		[Address(RVA = "0x107FF98", Offset = "0x107FF98", Length = "0x258")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv34 = &v35 @ stack_-10_v2;\n\t*([v34 @ X29_v1-28]) = elapsed;\n\t*([v34 @ X29_v1-24]) = *([v34 @ X29_v1+10]);\n\tv56 = *([2026A42]) & 1;\n\tv57 = v56 == 0;\n\tv58 = ~v57;\n\tif (v58) goto L_003C;\n\tv61 = 0x1084DF4(this, options, t, isRelative, getter, setter, usingInversePosition, updateNotice, *([v34 @ X29_v1+10]), startValue, startValue.g, startValue.b, startValue.a, duration, v67, v68);\n\treturn;\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([2026A42]) = X8;\nL_003C:\n\tv80 = t.loopType != 2;\n\tif (v80) goto L_0061;\n\tv287 = t.completedLoops - t.isComplete;\n\t// 72 MakeStruct v292 @ AGG108004C_0_v3 (UnityEngine.Color), typeof(UnityEngine.Color), [v34 @ X29_v1-24], [v34 @ X29_v1+14], [v34 @ X29_v1+18], [v34 @ X29_v1+1C]\n\tv293 = UnityEngine.Color::op_Multiply(v292, v287);\n\tv306 = UnityEngine.Color::op_Addition(startValue, v293);\nL_0061:\n\tv311 = ~t.isSequenced;\n\tif (v311) goto L_00B3;\n\tv184 = t.sequenceParent;\n\tv328 = v184.loopType != 2;\n\tif (v328) goto L_00B3;\n\tv125 = t.loopType != 2;\n\tif (v125) goto L_FFFFFFFF;\n\tgoto L_0087;\nL_0087:\n\t// 135 MakeStruct v83 @ AGG10800D4_0_v3 (UnityEngine.Color), typeof(UnityEngine.Color), [v34 @ X29_v1-24], [v34 @ X29_v1+14], [v34 @ X29_v1+18], [v34 @ X29_v1+1C]\n\tv192 = UnityEngine.Color::op_Multiply(v83, v197);\n\tv185 = t.sequenceParent;\n\tv345 = v185.completedLoops - v185.isComplete;\n\tv390 = UnityEngine.Color::op_Multiply(v192, v345);\n\t// 163 MakeStruct v320 @ AGG1080120_0_v3 (UnityEngine.Color), typeof(UnityEngine.Color), v173 @ V13_v4 (UnityEngine.Color), v176 @ V14_v4 (System.Single), v179 @ V15_v4 (System.Single), v182 @ V9_v4 (System.Single)\n\tv348 = UnityEngine.Color::op_Addition(v320, v390);\nL_00B3:\n\tv193 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, *([v34 @ X29_v1-28]), *([v34 @ X29_v1+20]), t.easeOvershootOrAmplitude, t.easePeriod);\n\tv186 = options & 0xFF;\n\tv356 = v186 == 0;\n\tif (v356) goto L_00CE;\n\tv194 = DG.Tweening.Core.DOGetter`1<UnityEngine.Color>::Invoke(getter);\n\tv229 = v194.g;\n\tv281 = v194.b;\n\tv385 = *([v34 @ X29_v1+1C]) * v193;\n\tv279 = v182 + v385;\n\tgoto L_00E9;\nL_00CE:\n\tv365 = *([v34 @ X29_v1+1C]) * v193;\n\tv279 = v182 + v365;\n\tv369 = *([v34 @ X29_v1+18]) * v193;\n\tv370 = *([v34 @ X29_v1+14]) * v193;\n\tv371 = *([v34 @ X29_v1-24]) * v193;\n\tv281 = v179 + v369;\n\tv229 = v176 + v370;\n\tv374 = v173 + v371;\nL_00E9:\n\t// 233 MakeStruct v213 @ AGG10801E4_1_v1 (UnityEngine.Color), typeof(UnityEngine.Color), v374 @ V0_v11 (System.Single), v229 @ V1_v5 (System.Single), v281 @ V2_v6 (System.Single), v279 @ V3_v6 (System.Single)\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::Invoke(setter, v213);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 183 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void EvaluateAndApply(ColorOptions options, Tween t, bool isRelative, DOGetter<Color> getter, DOSetter<Color> setter, float elapsed, Color startValue, Color changeValue, float duration, bool usingInversePosition, UpdateNotice updateNotice)
		{
			//IL_0414: Expected F4, but got I
			//IL_0414: Expected F4, but got I
			//IL_0421: Unknown result type (might be due to invalid IL or missing references)
			//IL_0426: Expected I4, but got Unknown
			//IL_00ea: Expected F4, but got I
			//IL_00ff: Expected F4, but got I
			//IL_0114: Expected F4, but got I
			//IL_0129: Expected F4, but got I
			//IL_0458: Expected F4, but got I
			//IL_046d: Expected F4, but got I
			//IL_0482: Expected F4, but got I
			//IL_0497: Expected F4, but got I
			//IL_01ed: Expected F4, but got I4
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1+10]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [2026A42]");
			if (0 == 0)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1084DF4 (inside DG.Tweening.Plugins.LongPlugin::.ctor +0x1D0)");
				return;
			}
			bool flag = t.loopType != LoopType.Incremental;
			Color color = startValue;
			float g = startValue.g;
			float b = startValue.b;
			float a = startValue.a;
			if (!flag)
			{
				float num = (float)t.completedLoops - (float)(t.isComplete ? 1 : 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1-24]");
				Color color2 = default(Color);
				color2.r = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1+14]");
				color2.g = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1+18]");
				color2.b = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1+1C]");
				color2.a = 0f;
				Color color3 = color2 * num;
				Color color4 = startValue + color3;
				color = color4;
				g = color4.g;
				b = color4.b;
				a = color4.a;
			}
			if (t.isSequenced)
			{
				Sequence sequenceParent = t.sequenceParent;
				if (sequenceParent.loopType == LoopType.Incremental)
				{
					float num2 = ((t.loopType != LoopType.Incremental) ? 1f : ((float)t.loops));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1-24]");
					Color color5 = default(Color);
					color5.r = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1+14]");
					color5.g = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1+18]");
					color5.b = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1+1C]");
					color5.a = 0f;
					Color color6 = color5 * num2;
					Sequence sequenceParent2 = t.sequenceParent;
					float num3 = (float)sequenceParent2.completedLoops - (float)(sequenceParent2.isComplete ? 1 : 0);
					Color color7 = color6 * num3;
					Color color8 = default(Color);
					color8.r = color.r;
					color8.g = g;
					color8.b = b;
					color8.a = a;
					Color color9 = color8 + color7;
					color = color9;
					g = color9.g;
					b = color9.b;
					a = color9.a;
				}
			}
			Ease easeType = t.easeType;
			EaseFunction customEase = t.customEase;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1-28]");
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1+20]");
			float num4 = EaseManager.Evaluate(easeType, customEase, (long)intPtr, 0f, t.easeOvershootOrAmplitude, t.easePeriod);
			float g2;
			float b2;
			float a2;
			float r;
			if ((options & 0xFF) != 0)
			{
				Color color10 = getter();
				g2 = color10.g;
				b2 = color10.b;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1+1C]");
				float num5 = 0f * num4;
				a2 = a + num5;
				r = color10.r;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1+1C]");
				float num6 = 0f * num4;
				a2 = a + num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1+18]");
				float num7 = 0f * num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1+14]");
				float num8 = 0f * num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1-24]");
				float num9 = 0f * num4;
				b2 = b + num7;
				g2 = g + num8;
				r = color.r + num9;
			}
			Color pNewValue = default(Color);
			pNewValue.r = r;
			pNewValue.g = g2;
			pNewValue.b = b2;
			pNewValue.a = a2;
			setter(pNewValue);
		}

		[Token(Token = "0x60001BF")]
		[Address(RVA = "0x10801F0", Offset = "0x10801F0", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EDDC58]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026A43]) = v38;\nL_001C:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ColorPlugin()
		{
		}
	}
}
