using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Options;

namespace DG.Tweening.Plugins
{
	[Token(Token = "0x2000020")]
	public class UlongPlugin : ABSTweenPlugin<ulong, ulong, NoOptions>
	{
		[Token(Token = "0x600019A")]
		[Address(RVA = "0x10DDAD0", Offset = "0x10DDAD0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset(TweenerCore<ulong, ulong, NoOptions> t)
		{
		}

		[Token(Token = "0x600019B")]
		[Address(RVA = "0x10DDAD4", Offset = "0x10DDAD4", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1F03B38]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, t, isRelative, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([20274D9]) = v41;\nL_001E:\n\tv50 = DG.Tweening.Core.DOGetter`1<System.UInt64>::Invoke(*([t @ X1 (DG.Tweening.Core.TweenerCore`3<System.UInt64, System.UInt64, DG.Tweening.Plugins.Options.NoOptions>)+140]));\n\tv68 = isRelative == 0;\n\tv59 = ~v68;\n\tv56 = ~v59;\n\tif (v56) goto L_FFFFFFFF;\n\tgoto L_002D;\nL_002D:\n\tv73 = v53 + t.endValue;\n\tt.startValue = v73;\n\tt.endValue = v50;\n\tDG.Tweening.Core.DOSetter`1<System.UInt64>::Invoke(*([t @ X1 (DG.Tweening.Core.TweenerCore`3<System.UInt64, System.UInt64, DG.Tweening.Plugins.Options.NoOptions>)+148]), v73);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<ulong, ulong, NoOptions> t, bool isRelative)
		{
			//IL_0016: Expected O, but got I
			//IL_0063: Expected I8, but got I4
			//IL_007d: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<System.UInt64, System.UInt64, DG.Tweening.Plugins.Options.NoOptions>)+140]");
			ulong num = ((DOGetter<ulong>)0)();
			ulong num2 = ((!isRelative) ? 0 : num);
			ulong pNewValue = (t.startValue = num2 + t.endValue);
			t.endValue = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<System.UInt64, System.UInt64, DG.Tweening.Plugins.Options.NoOptions>)+148]");
			((DOSetter<ulong>)0)(pNewValue);
		}

		[Token(Token = "0x600019C")]
		[Address(RVA = "0x10DDB70", Offset = "0x10DDB70", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1F0E578]);\n\tv27 = *([v26 @ X8_v7]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, t, fromValue, setImmediately, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([20274DA]) = v44;\nL_0019:\n\tt.startValue = fromValue;\n\tv47 = setImmediately == 0;\n\tif (v47) goto L_0034;\n\tDG.Tweening.Core.DOSetter`1<System.UInt64>::Invoke(*([t @ X1 (DG.Tweening.Core.TweenerCore`3<System.UInt64, System.UInt64, DG.Tweening.Plugins.Options.NoOptions>)+148]), fromValue);\n\treturn;\nL_0034:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<ulong, ulong, NoOptions> t, ulong fromValue, bool setImmediately)
		{
			//IL_0044: Expected O, but got I
			t.startValue = fromValue;
			if (setImmediately)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<System.UInt64, System.UInt64, DG.Tweening.Plugins.Options.NoOptions>)+148]");
				((DOSetter<ulong>)0)(fromValue);
			}
		}

		[Token(Token = "0x600019D")]
		[Address(RVA = "0x10DDBFC", Offset = "0x10DDBFC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override ulong ConvertToStartValue(TweenerCore<ulong, ulong, NoOptions> t, ulong value)
		{
			return value;
		}

		[Token(Token = "0x600019E")]
		[Address(RVA = "0x10DDC04", Offset = "0x10DDC04", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = t.startValue + t.endValue;\n\tt.endValue = v4;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetRelativeEndValue(TweenerCore<ulong, ulong, NoOptions> t)
		{
			long endValue = (long)(t.startValue + t.endValue);
			t.endValue = (ulong)endValue;
		}

		[Token(Token = "0x600019F")]
		[Address(RVA = "0x10DDC28", Offset = "0x10DDC28", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = t.endValue - t.startValue;\n\tt.changeValue = v4;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetChangeValue(TweenerCore<ulong, ulong, NoOptions> t)
		{
			long changeValue = (long)(t.endValue - t.startValue);
			t.changeValue = (ulong)changeValue;
		}

		[Token(Token = "0x60001A0")]
		[Address(RVA = "0x10DDC4C", Offset = "0x10DDC4C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = changeValue / unitsXSecond;\n\tv5 = -returnVal1;\n\tv15 = returnVal1 >= 0;\n\tif (v15) goto L_0013;\n\tgoto L_0013;\nL_0013:\n\treturn returnVal1;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float GetSpeedBasedDuration(NoOptions options, float unitsXSecond, ulong changeValue)
		{
			float num = (float)(long)changeValue / unitsXSecond;
			float num2 = 0f - num;
			if (num < 0f)
			{
				num = num2;
			}
			return num;
		}

		[Token(Token = "0x60001A1")]
		[Address(RVA = "0x10DDC68", Offset = "0x10DDC68", Length = "0x1A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv38 = *([1EA9C88]);\n\tv39 = *([v38 @ X8_v20]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, options, t, isRelative, getter, setter, startValue, changeValue, elapsed, duration, v44, v45, v46, v47, v48, v49);\n\tv53 = 0 | 1;\n\t*([20274DB]) = v53;\nL_0029:\n\tv65 = t.loopType != 2;\n\tif (v65) goto L_0032;\n\tv138 = t.completedLoops - t.isComplete;\n\tv139 = v138 * changeValue;\n\tv140 = startValue + v139;\nL_0032:\n\tv144 = ~t.isSequenced;\n\tif (v144) goto L_005E;\n\tv87 = t.sequenceParent;\n\tv149 = v87.loopType != 2;\n\tif (v149) goto L_005E;\n\tv148 = t.loopType != 2;\n\tif (v148) goto L_FFFFFFFF;\n\tv242 = t.loops;\n\tgoto L_0053;\nL_0053:\n\tv171 = v242 * changeValue;\n\tv147 = v87.completedLoops - v87.isComplete;\n\tv167 = v171 * v147;\n\tv169 = v168 + v167;\nL_005E:\n\tgoto L_0066;\n\tv222 = *([v174 @ X0_v5+E0]);\n\tv223 = v222 == 0;\n\tv224 = ~v223;\n\tgoto L_0066;\n\tv226 = \"il2cpp_codegen_runtime_class_init\"(v174, options, t, isRelative, getter, setter, startValue, changeValue, elapsed, duration, v44, v45, v46, v47, v48, v49);\nL_0066:\n\tv231 = System.Decimal::op_Implicit(v168);\n\tv235 = System.Decimal::op_Implicit(changeValue);\n\tv75 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);\n\tv246 = System.Decimal::op_Explicit(v75);\n\tv252 = System.Decimal::op_Multiply(v235, 0);\n\tv256 = System.Decimal::op_Addition(v231, 0);\n\tv118 = System.Decimal::op_Explicit(v256);\n\tDG.Tweening.Core.DOSetter`1<System.UInt64>::Invoke(setter, v118);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 116 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void EvaluateAndApply(NoOptions options, Tween t, bool isRelative, DOGetter<ulong> getter, DOSetter<ulong> setter, float elapsed, ulong startValue, ulong changeValue, float duration, bool usingInversePosition, UpdateNotice updateNotice)
		{
			bool flag = t.loopType != LoopType.Incremental;
			ulong num = startValue;
			if (!flag)
			{
				int num2 = t.completedLoops - (t.isComplete ? 1 : 0);
				long num3 = (long)num2 * (long)changeValue;
				long num4 = (long)startValue + num3;
				num = (ulong)num4;
			}
			if (t.isSequenced)
			{
				Sequence sequenceParent = t.sequenceParent;
				if (sequenceParent.loopType == LoopType.Incremental)
				{
					int num5 = ((t.loopType != LoopType.Incremental) ? 1 : t.loops);
					long num6 = (long)num5 * (long)changeValue;
					int num7 = sequenceParent.completedLoops - (sequenceParent.isComplete ? 1 : 0);
					long num8 = num6 * num7;
					long num9 = (long)num + num8;
					num = (ulong)num9;
				}
			}
			decimal num10 = num;
			decimal num11 = changeValue;
			float num12 = EaseManager.Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);
			decimal num13 = (decimal)num12;
			decimal num14 = num11 * default(decimal);
			decimal num15 = num10 + default(decimal);
			ulong pNewValue = (ulong)num15;
			setter(pNewValue);
		}

		[Token(Token = "0x60001A2")]
		[Address(RVA = "0x10DDE08", Offset = "0x10DDE08", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1ECD660]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20274DC]) = v38;\nL_001C:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<System.UInt64, System.UInt64, DG.Tweening.Plugins.Options.NoOptions>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public UlongPlugin()
		{
		}
	}
}
