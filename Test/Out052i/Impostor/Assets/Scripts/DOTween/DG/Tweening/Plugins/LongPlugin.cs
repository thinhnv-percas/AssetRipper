using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Options;

namespace DG.Tweening.Plugins
{
	[Token(Token = "0x2000077")]
	public class LongPlugin : ABSTweenPlugin<long, long, NoOptions>
	{
		[Token(Token = "0x60002D6")]
		[Address(RVA = "0xC1DE54", Offset = "0xC1DE54", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset(TweenerCore<long, long, NoOptions> t)
		{
		}

		[Token(Token = "0x60002D7")]
		[Address(RVA = "0xC1DE58", Offset = "0xC1DE58", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Int64, System.Int64, DG.Tweening.Plugins.Options.NoOptions>)+148]);\n\t*([v10 @ X8_v2+18])(v39, *([v10 @ X8_v2+40]), *([v10 @ X8_v2+28]), isRelative, methodInfo, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv46 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Int64, System.Int64, DG.Tweening.Plugins.Options.NoOptions>)+150]);\n\tv27 = isRelative == 0;\n\tv18 = ~v27;\n\tv15 = ~v18;\n\tif (v15) goto L_FFFFFFFF;\n\tgoto L_001E;\nL_001E:\n\tv36 = v42 + t.endValue;\n\tt.startValue = v36;\n\tt.endValue = v39;\n\tv75 = *([v46 @ X8_v3+18]);\n\tv88 = *([v46 @ X8_v3+40]);\n\tv73 = *([v46 @ X8_v3+28]);\n\t// 43 IndirectJump v75 @ X3_v1, v88 @ X0_v5, v88 @ X0_v5, v36 @ X1_v3 (System.Int64), v73 @ X2_v1, v75 @ X3_v1, v52 @ X4, v53 @ X5, v54 @ X6, v55 @ X7, v56 @ V0, v57 @ V1, v58 @ V2, v59 @ V3, v60 @ V4, v61 @ V5, v62 @ V6, v63 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<long, long, NoOptions> t, bool isRelative)
		{
			//IL_0010: Expected O, but got I
			//IL_002f: Expected O, but got I
			//IL_0078: Expected I8, but got I4
			//IL_008d: Expected O, but got I
			//IL_009d: Expected O, but got I
			//IL_00ad: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Int64, System.Int64, DG.Tweening.Plugins.Options.NoOptions>)+148]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v10 @ X8_v2+18] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Int64, System.Int64, DG.Tweening.Plugins.Options.NoOptions>)+150]");
			object obj2 = 0;
			long num2 = default(long);
			long num = ((!isRelative) ? 0 : num2);
			while (true)
			{
				long startValue = num + t.endValue;
				t.startValue = startValue;
				t.endValue = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v3+18]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v3+40]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v3+28]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v75 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60002D8")]
		[Address(RVA = "0xC1DEBC", Offset = "0xC1DEBC", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = isRelative == 0;\n\tif (v16) goto L_FFFFFFFF;\n\tv19 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Int64, System.Int64, DG.Tweening.Plugins.Options.NoOptions>)+148]);\n\t*([v19 @ X8_v4+18])(v49, *([v19 @ X8_v4+40]), *([v19 @ X8_v4+28]), fromValue, setImmediately, isRelative, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv35 = v49 + fromValue;\n\tv52 = t.endValue + v49;\n\tt.endValue = v52;\n\tgoto L_001B;\nL_001B:\n\tt.startValue = v35;\n\tv56 = setImmediately == 0;\n\tif (v56) goto L_0031;\n\tv31 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Int64, System.Int64, DG.Tweening.Plugins.Options.NoOptions>)+150]);\n\tv68 = *([v31 @ X8_v3+18]);\n\tv72 = *([v31 @ X8_v3+40]);\n\tv66 = *([v31 @ X8_v3+28]);\n\t// 43 IndirectJump v68 @ X3_v1, v72 @ X0_v4, v72 @ X0_v4, v35 @ X19_v3 (System.Int64), v66 @ X2_v1, v68 @ X3_v1, isRelative @ X4 (System.Boolean), methodInfo @ X5 (Il2CppMethodInfo), v38 @ X6, v39 @ X7, v40 @ V0, v41 @ V1, v42 @ V2, v43 @ V3, v44 @ V4, v45 @ V5, v46 @ V6, v47 @ V7\nL_0031:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<long, long, NoOptions> t, long fromValue, bool setImmediately, bool isRelative)
		{
			//IL_002d: Expected O, but got I
			//IL_00b6: Expected O, but got I
			//IL_00cb: Expected O, but got I
			//IL_00db: Expected O, but got I
			//IL_00eb: Expected O, but got I
			long startValue;
			if (isRelative)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Int64, System.Int64, DG.Tweening.Plugins.Options.NoOptions>)+148]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v19 @ X8_v4+18] (should have been resolved before IL gen)");
				object obj2 = default(object);
				startValue = (nint)obj2 + fromValue;
				long endValue = t.endValue + (nint)obj2;
				t.endValue = endValue;
			}
			else
			{
				startValue = fromValue;
			}
			t.startValue = startValue;
			if (setImmediately)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Int64, System.Int64, DG.Tweening.Plugins.Options.NoOptions>)+150]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ X8_v3+18]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ X8_v3+40]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ X8_v3+28]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v68 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60002D9")]
		[Address(RVA = "0xC1DF44", Offset = "0xC1DF44", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override long ConvertToStartValue(TweenerCore<long, long, NoOptions> t, long value)
		{
			return value;
		}

		[Token(Token = "0x60002DA")]
		[Address(RVA = "0xC1DF4C", Offset = "0xC1DF4C", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = t.startValue + t.endValue;\n\tt.endValue = v6;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetRelativeEndValue(TweenerCore<long, long, NoOptions> t)
		{
			long endValue = t.startValue + t.endValue;
			t.endValue = endValue;
		}

		[Token(Token = "0x60002DB")]
		[Address(RVA = "0xC1DF6C", Offset = "0xC1DF6C", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = t.endValue - t.startValue;\n\tt.changeValue = v6;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetChangeValue(TweenerCore<long, long, NoOptions> t)
		{
			long changeValue = t.endValue - t.startValue;
			t.changeValue = changeValue;
		}

		[Token(Token = "0x60002DC")]
		[Address(RVA = "0xC1DF8C", Offset = "0xC1DF8C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = changeValue / unitsXSecond;\n\tv4 = -returnVal1;\n\tv14 = returnVal1 >= 0;\n\tif (v14) goto L_0012;\n\tgoto L_0012;\nL_0012:\n\treturn returnVal1;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float GetSpeedBasedDuration(NoOptions options, float unitsXSecond, long changeValue)
		{
			float num = (float)changeValue / unitsXSecond;
			float num2 = 0f - num;
			if (num < 0f)
			{
				num = num2;
			}
			return num;
		}

		[Token(Token = "0x60002DD")]
		[Address(RVA = "0xC1DFA4", Offset = "0xC1DFA4", Length = "0x1B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv34 = System.Math;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, options, t, isRelative, getter, setter, startValue, changeValue, elapsed, duration, v39, v40, v41, v42, v43, v44);\n\tv48 = 1;\n\t*([1A35760]) = v48;\nL_0026:\n\tv60 = t.loopType != 2;\n\tif (v60) goto L_0030;\n\tv134 = t.completedLoops - t.isComplete;\n\tv136 = v134 * changeValue;\n\tv125 = startValue + v136;\nL_0030:\n\tv141 = ~t.isSequenced;\n\tif (v141) goto L_0060;\n\tv84 = t.sequenceParent;\n\tv147 = v84.loopType != 2;\n\tif (v147) goto L_0060;\n\tv146 = t.loopType != 2;\n\tif (v146) goto L_FFFFFFFF;\n\tv263 = t.loops;\n\tgoto L_0051;\nL_0051:\n\tv176 = v263 * changeValue;\n\tv266 = v84.completedLoops - v84.isComplete;\n\tv173 = v176 * v266;\n\tv125 = v125 + v173;\nL_0060:\n\tv181 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);\n\tgoto L_006A;\n\tv244 = \"il2cpp_codegen_runtime_class_init\"(v238, v66, v71, isRelative, getter, setter, startValue, changeValue, v181, v180, v64, v62, v41, v42, v43, v44);\nL_006A:\n\tv248 = v181 * changeValue;\n\tv122 = v248 + v125;\n\tv115 = 0x1854ED0(&v74 @ stack_-48_v2 (System.Double), t.customEase, 0, isRelative, getter, setter, startValue, changeValue, v122, v248, t.easeOvershootOrAmplitude, t.easePeriod, v41, v42, v43, v44);\n\tv262 = v122 >= 0;\n\tif (v262) goto L_0094;\n\tv277 = v122 != -0.5d;\n\tif (v277) goto L_00A6;\n\tgoto L_0099;\nL_0094:\n\tv288 = v122 != 0.5d;\n\tif (v288) goto L_00A9;\nL_0099:\n\tv309 = v76 + v298;\n\tv310 = v76 & 1;\n\tv312 = v310 == 0;\n\tv315 = ~v312;\n\tif (v315) goto L_FFFFFFFF;\n\tgoto L_00A5;\nL_00A5:\n\tgoto L_00C5;\nL_00A6:\n\tv291 = v122 + -0.5d;\n\tv76 = System.Math::Ceiling(v291);\n\tgoto L_00C5;\nL_00A9:\n\tv295 = v122 + 0.5d;\n\tv76 = System.Math::Floor(v295);\nL_00C5:\n\tv187 = v76 != 0x7FF0000000000000;\n\tif (v187) goto L_FFFFFFFF;\n\tgoto L_00CC;\nL_00CC:\n\tDG.Tweening.Core.DOSetter`1<System.Int64>::Invoke(setter, v185);\n\tthrow System.NullReferenceException;\n\treturn;\n// 153 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void EvaluateAndApply(NoOptions options, Tween t, bool isRelative, DOGetter<long> getter, DOSetter<long> setter, float elapsed, long startValue, long changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice)
		{
			//IL_0306: Unknown result type (might be due to invalid IL or missing references)
			//IL_030b: Expected I4, but got Unknown
			//IL_0345: Expected I8, but got F8
			//IL_0241: Expected F8, but got I8
			bool flag = t.loopType != LoopType.Incremental;
			long num = startValue;
			if (!flag)
			{
				int num2 = t.completedLoops - (t.isComplete ? 1 : 0);
				long num3 = num2 * changeValue;
				num = startValue + num3;
			}
			if (t.isSequenced)
			{
				Sequence sequenceParent = t.sequenceParent;
				if (sequenceParent.loopType == LoopType.Incremental)
				{
					int num4 = ((t.loopType != LoopType.Incremental) ? 1 : t.loops);
					long num5 = num4 * changeValue;
					int num6 = sequenceParent.completedLoops - (sequenceParent.isComplete ? 1 : 0);
					long num7 = num5 * num6;
					num += num7;
				}
			}
			float num8 = EaseManager.Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);
			float num9 = num8 * (float)changeValue;
			float num10 = num9 + (float)num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854ED0 (native modf)");
			double num11;
			double num12 = default(double);
			double num13;
			if (num10 < 0f)
			{
				if ((double)num10 != -0.5)
				{
					double a = (double)num10 + -0.5;
					num11 = Math.Ceiling(a);
					goto IL_020e;
				}
				num11 = num12;
				num13 = -1.0;
			}
			else
			{
				if ((double)num10 != 0.5)
				{
					double d = (double)num10 + 0.5;
					num11 = Math.Floor(d);
					goto IL_020e;
				}
				num11 = num12;
				num13 = 1.0;
			}
			double num14 = num11 + num13;
			if ((num11 & 1) != 0)
			{
				num11 = num14;
			}
			goto IL_020e;
			IL_020e:
			double num15 = ((num11 != 9.218868437227405E+18) ? num11 : (-9.223372036854776E+18));
			setter((long)num15);
		}

		[Token(Token = "0x60002DE")]
		[Address(RVA = "0xC1E15C", Offset = "0xC1E15C", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35761]) = v37;\nL_001A:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<System.Int64, System.Int64, DG.Tweening.Plugins.Options.NoOptions>::.ctor(this);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LongPlugin()
		{
		}
	}
}
