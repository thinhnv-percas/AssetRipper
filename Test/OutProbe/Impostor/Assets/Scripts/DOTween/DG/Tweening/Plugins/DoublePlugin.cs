using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Options;

namespace DG.Tweening.Plugins
{
	[Token(Token = "0x2000076")]
	public class DoublePlugin : ABSTweenPlugin<double, double, NoOptions>
	{
		[Token(Token = "0x60002CD")]
		[Address(RVA = "0xC1DBD0", Offset = "0xC1DBD0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset(TweenerCore<double, double, NoOptions> t)
		{
		}

		[Token(Token = "0x60002CE")]
		[Address(RVA = "0xC1DBD4", Offset = "0xC1DBD4", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Double, System.Double, DG.Tweening.Plugins.Options.NoOptions>)+148]);\n\t*([v10 @ X8_v2+18])(v45, *([v10 @ X8_v2+40]), *([v10 @ X8_v2+28]), isRelative, methodInfo, v58, v59, v60, v61, v32, v35, v62, v63, v64, v65, v66, v67);\n\tv52 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Double, System.Double, DG.Tweening.Plugins.Options.NoOptions>)+150]);\n\tv33 = t.endValue + v32;\n\tv27 = isRelative == 0;\n\tv18 = ~v27;\n\tv15 = ~v18;\n\tif (v15) goto L_FFFFFFFF;\n\tgoto L_0020;\nL_0020:\n\tt.startValue = v33;\n\tt.endValue = v32;\n\tv76 = *([v52 @ X8_v3+18]);\n\tv92 = *([v52 @ X8_v3+40]);\n\tv90 = *([v52 @ X8_v3+28]);\n\t// 44 IndirectJump v76 @ X2_v1, v92 @ X0_v5, v92 @ X0_v5, v90 @ X1_v3, v76 @ X2_v1, methodInfo @ X3 (Il2CppMethodInfo), v58 @ X4, v59 @ X5, v60 @ X6, v61 @ X7, v33 @ V0_v3 (System.Double), v32 @ V0 (System.Double), v62 @ V2, v63 @ V3, v64 @ V4, v65 @ V5, v66 @ V6, v67 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<double, double, NoOptions> t, bool isRelative)
		{
			//IL_0010: Expected O, but got I
			//IL_002f: Expected O, but got I
			//IL_009d: Expected O, but got I
			//IL_00ad: Expected O, but got I
			//IL_00bd: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Double, System.Double, DG.Tweening.Plugins.Options.NoOptions>)+148]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v10 @ X8_v2+18] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Double, System.Double, DG.Tweening.Plugins.Options.NoOptions>)+150]");
			object obj2 = 0;
			double num = default(double);
			double startValue = t.endValue + num;
			if (!isRelative)
			{
				startValue = t.endValue;
			}
			while (true)
			{
				t.startValue = startValue;
				t.endValue = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X8_v3+18]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X8_v3+40]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X8_v3+28]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v76 @ X2_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60002CF")]
		[Address(RVA = "0xC1DC44", Offset = "0xC1DC44", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = isRelative == 0;\n\tif (v16) goto L_FFFFFFFF;\n\tv19 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Double, System.Double, DG.Tweening.Plugins.Options.NoOptions>)+148]);\n\t*([v19 @ X8_v4+18])(v52, *([v19 @ X8_v4+40]), *([v19 @ X8_v4+28]), setImmediately, isRelative, methodInfo, v41, v42, v43, fromValue, v23, v44, v45, v46, v47, v48, v49);\n\tv38 = fromValue + fromValue;\n\tv23 = fromValue + t.endValue;\n\tt.endValue = v23;\n\tgoto L_001B;\nL_001B:\n\tt.startValue = v38;\n\tv58 = setImmediately == 0;\n\tif (v58) goto L_0031;\n\tv34 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Double, System.Double, DG.Tweening.Plugins.Options.NoOptions>)+150]);\n\tv70 = *([v34 @ X8_v3+18]);\n\tv75 = *([v34 @ X8_v3+40]);\n\tv73 = *([v34 @ X8_v3+28]);\n\t// 43 IndirectJump v70 @ X2_v1, v75 @ X0_v4, v75 @ X0_v4, v73 @ X1_v3, v70 @ X2_v1, isRelative @ X3 (System.Boolean), methodInfo @ X4 (Il2CppMethodInfo), v41 @ X5, v42 @ X6, v43 @ X7, v38 @ V8_v3 (System.Double), v23 @ V1_v2 (System.Double), v44 @ V2, v45 @ V3, v46 @ V4, v47 @ V5, v48 @ V6, v49 @ V7\nL_0031:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<double, double, NoOptions> t, double fromValue, bool setImmediately, bool isRelative)
		{
			//IL_002d: Expected O, but got I
			//IL_00b8: Expected O, but got I
			//IL_00cd: Expected O, but got I
			//IL_00dd: Expected O, but got I
			//IL_00ed: Expected O, but got I
			double startValue;
			if (isRelative)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Double, System.Double, DG.Tweening.Plugins.Options.NoOptions>)+148]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v19 @ X8_v4+18] (should have been resolved before IL gen)");
				startValue = fromValue + fromValue;
				double endValue = fromValue + t.endValue;
				t.endValue = endValue;
			}
			else
			{
				startValue = fromValue;
			}
			t.startValue = startValue;
			if (setImmediately)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Double, System.Double, DG.Tweening.Plugins.Options.NoOptions>)+150]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X8_v3+18]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X8_v3+40]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X8_v3+28]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v70 @ X2_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60002D0")]
		[Address(RVA = "0xC1DCD8", Offset = "0xC1DCD8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n")]
		public override double ConvertToStartValue(TweenerCore<double, double, NoOptions> t, double value)
		{
			return value;
		}

		[Token(Token = "0x60002D1")]
		[Address(RVA = "0xC1DCDC", Offset = "0xC1DCDC", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = t.endValue + t.startValue;\n\tt.endValue = v6;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetRelativeEndValue(TweenerCore<double, double, NoOptions> t)
		{
			double endValue = t.endValue + t.startValue;
			t.endValue = endValue;
		}

		[Token(Token = "0x60002D2")]
		[Address(RVA = "0xC1DCFC", Offset = "0xC1DCFC", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = t.endValue - t.startValue;\n\tt.changeValue = v6;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetChangeValue(TweenerCore<double, double, NoOptions> t)
		{
			double changeValue = t.endValue - t.startValue;
			t.changeValue = changeValue;
		}

		[Token(Token = "0x60002D3")]
		[Address(RVA = "0xC1DD1C", Offset = "0xC1DD1C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = changeValue / unitsXSecond;\n\tv4 = -returnVal1;\n\tv14 = returnVal1 >= 0;\n\tif (v14) goto L_0012;\n\tgoto L_0012;\nL_0012:\n\treturn returnVal1;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float GetSpeedBasedDuration(NoOptions options, float unitsXSecond, double changeValue)
		{
			float num = (float)changeValue / unitsXSecond;
			float num2 = 0f - num;
			if (num < 0f)
			{
				num = num2;
			}
			return num;
		}

		[Token(Token = "0x60002D4")]
		[Address(RVA = "0xC1DD34", Offset = "0xC1DD34", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = t.loopType != 2;\n\tif (v26) goto L_001E;\nL_001E:\n\tv112 = ~t.isSequenced;\n\tif (v112) goto L_004C;\n\tv55 = t.sequenceParent;\n\tv120 = v55.loopType != 2;\n\tif (v120) goto L_004C;\n\tv119 = t.loopType != 2;\n\tif (v119) goto L_003F;\nL_003F:\n\t;\nL_004C:\n\tv37 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);\n\tDG.Tweening.Core.DOSetter`1<System.Double>::Invoke(setter, setter.method);\n\tthrow System.NullReferenceException;\n\treturn;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void EvaluateAndApply(NoOptions options, Tween t, bool isRelative, DOGetter<double> getter, DOSetter<double> setter, float elapsed, double startValue, double changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice)
		{
			//IL_00a5: Expected F8, but got I
			if (t.loopType == LoopType.Incremental)
			{
			}
			if (t.isSequenced)
			{
				Sequence sequenceParent = t.sequenceParent;
				if (sequenceParent.loopType == LoopType.Incremental && t.loopType != LoopType.Incremental)
				{
				}
			}
			float num = EaseManager.Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);
			setter((nint)setter.method);
		}

		[Token(Token = "0x60002D5")]
		[Address(RVA = "0xC1DE0C", Offset = "0xC1DE0C", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A3575F]) = v37;\nL_001A:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<System.Double, System.Double, DG.Tweening.Plugins.Options.NoOptions>::.ctor(this);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DoublePlugin()
		{
		}
	}
}
