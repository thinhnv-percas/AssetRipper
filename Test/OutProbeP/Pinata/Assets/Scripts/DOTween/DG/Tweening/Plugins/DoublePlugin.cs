using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Options;

namespace DG.Tweening.Plugins
{
	[Token(Token = "0x200001E")]
	public class DoublePlugin : ABSTweenPlugin<double, double, NoOptions>
	{
		[Token(Token = "0x6000188")]
		[Address(RVA = "0x1083CFC", Offset = "0x1083CFC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset(TweenerCore<double, double, NoOptions> t)
		{
		}

		[Token(Token = "0x6000189")]
		[Address(RVA = "0x1083D00", Offset = "0x1083D00", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv24 = *([1EC1438]);\n\tv25 = *([v24 @ X8_v10]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, t, isRelative, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 0 | 1;\n\t*([2026A5E]) = v43;\nL_001F:\n\tv52 = DG.Tweening.Core.DOGetter`1<System.Double>::Invoke(*([t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Double, System.Double, DG.Tweening.Plugins.Options.NoOptions>)+140]));\n\tv74 = t.endValue + v52;\n\tv67 = isRelative == 0;\n\tv58 = ~v67;\n\tv55 = ~v58;\n\tif (v55) goto L_FFFFFFFF;\n\tgoto L_002F;\nL_002F:\n\tt.startValue = v74;\n\tt.endValue = v52;\n\tDG.Tweening.Core.DOSetter`1<System.Double>::Invoke(*([t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Double, System.Double, DG.Tweening.Plugins.Options.NoOptions>)+148]), v74);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<double, double, NoOptions> t, bool isRelative)
		{
			//IL_0016: Expected O, but got I
			//IL_008d: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Double, System.Double, DG.Tweening.Plugins.Options.NoOptions>)+140]");
			double num = ((DOGetter<double>)0)();
			double num2 = t.endValue + num;
			if (!isRelative)
			{
				num2 = t.endValue;
			}
			t.startValue = num2;
			t.endValue = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Double, System.Double, DG.Tweening.Plugins.Options.NoOptions>)+148]");
			((DOSetter<double>)0)(num2);
		}

		[Token(Token = "0x600018A")]
		[Address(RVA = "0x1083DA4", Offset = "0x1083DA4", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EFA0C0]);\n\tv27 = *([v26 @ X8_v7]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, t, setImmediately, methodInfo, v30, v31, v32, v33, fromValue, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2026A5F]) = v44;\nL_0019:\n\tt.startValue = fromValue;\n\tv47 = setImmediately == 0;\n\tif (v47) goto L_0034;\n\tDG.Tweening.Core.DOSetter`1<System.Double>::Invoke(*([t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Double, System.Double, DG.Tweening.Plugins.Options.NoOptions>)+148]), fromValue);\n\treturn;\nL_0034:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<double, double, NoOptions> t, double fromValue, bool setImmediately)
		{
			//IL_0044: Expected O, but got I
			t.startValue = fromValue;
			if (setImmediately)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Double, System.Double, DG.Tweening.Plugins.Options.NoOptions>)+148]");
				((DOSetter<double>)0)(fromValue);
			}
		}

		[Token(Token = "0x600018B")]
		[Address(RVA = "0x1083E3C", Offset = "0x1083E3C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n")]
		public override double ConvertToStartValue(TweenerCore<double, double, NoOptions> t, double value)
		{
			return value;
		}

		[Token(Token = "0x600018C")]
		[Address(RVA = "0x1083E40", Offset = "0x1083E40", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = t.endValue + t.startValue;\n\tt.endValue = v4;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetRelativeEndValue(TweenerCore<double, double, NoOptions> t)
		{
			double endValue = t.endValue + t.startValue;
			t.endValue = endValue;
		}

		[Token(Token = "0x600018D")]
		[Address(RVA = "0x1083E64", Offset = "0x1083E64", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = t.endValue - t.startValue;\n\tt.changeValue = v4;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetChangeValue(TweenerCore<double, double, NoOptions> t)
		{
			double changeValue = t.endValue - t.startValue;
			t.changeValue = changeValue;
		}

		[Token(Token = "0x600018E")]
		[Address(RVA = "0x1083E88", Offset = "0x1083E88", Length = "0x18")]
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

		[Token(Token = "0x600018F")]
		[Address(RVA = "0x1083EA0", Offset = "0x1083EA0", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv38 = *([1EE74F0]);\n\tv39 = *([v38 @ X8_v15]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, options, t, isRelative, getter, setter, usingInversePosition, updateNotice, elapsed, startValue, changeValue, duration, v46, v47, v48, v49);\n\tv53 = 0 | 1;\n\t*([2026A60]) = v53;\nL_0029:\n\tv65 = t.loopType != 2;\n\tif (v65) goto L_0033;\n\tv127 = t.completedLoops - t.isComplete;\n\tv129 = v127 * changeValue;\n\tv119 = v129 + startValue;\nL_0033:\n\tv133 = ~t.isSequenced;\n\tif (v133) goto L_0061;\n\tv82 = t.sequenceParent;\n\tv141 = v82.loopType != 2;\n\tif (v141) goto L_0061;\n\tv140 = t.loopType != 2;\n\tif (v140) goto L_FFFFFFFF;\n\tgoto L_0055;\nL_0055:\n\tv214 = v211 * changeValue;\n\tv160 = v82.completedLoops - v82.isComplete;\n\tv137 = v214 * v160;\n\tv119 = v119 + v137;\nL_0061:\n\tv76 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);\n\tv207 = v76 * changeValue;\n\tv170 = v119 + v207;\n\tDG.Tweening.Core.DOSetter`1<System.Double>::Invoke(setter, v170);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void EvaluateAndApply(NoOptions options, Tween t, bool isRelative, DOGetter<double> getter, DOSetter<double> setter, float elapsed, double startValue, double changeValue, float duration, bool usingInversePosition, UpdateNotice updateNotice)
		{
			//IL_00d6: Expected F8, but got I4
			bool flag = t.loopType != LoopType.Incremental;
			double num = startValue;
			if (!flag)
			{
				int num2 = t.completedLoops - (t.isComplete ? 1 : 0);
				double num3 = (double)num2 * changeValue;
				num = num3 + startValue;
			}
			if (t.isSequenced)
			{
				Sequence sequenceParent = t.sequenceParent;
				if (sequenceParent.loopType == LoopType.Incremental)
				{
					double num4 = ((t.loopType != LoopType.Incremental) ? 1.0 : ((double)t.loops));
					double num5 = num4 * changeValue;
					int num6 = sequenceParent.completedLoops - (sequenceParent.isComplete ? 1 : 0);
					double num7 = num5 * (double)num6;
					num += num7;
				}
			}
			float num8 = EaseManager.Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);
			float num9 = num8 * (float)changeValue;
			double pNewValue = num + (double)num9;
			setter(pNewValue);
		}

		[Token(Token = "0x6000190")]
		[Address(RVA = "0x1083FCC", Offset = "0x1083FCC", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EEB3D0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026A61]) = v38;\nL_001C:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<System.Double, System.Double, DG.Tweening.Plugins.Options.NoOptions>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DoublePlugin()
		{
		}
	}
}
