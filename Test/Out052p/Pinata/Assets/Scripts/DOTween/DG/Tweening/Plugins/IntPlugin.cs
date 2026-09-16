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
	[Token(Token = "0x2000024")]
	public class IntPlugin : ABSTweenPlugin<int, int, NoOptions>
	{
		[Token(Token = "0x60001C0")]
		[Address(RVA = "0x1084530", Offset = "0x1084530", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset(TweenerCore<int, int, NoOptions> t)
		{
		}

		[Token(Token = "0x60001C1")]
		[Address(RVA = "0x1084534", Offset = "0x1084534", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EFC508]);\n\tv23 = *([v22 @ X8_v14]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, t, isRelative, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([2026A66]) = v41;\nL_001E:\n\tv50 = DG.Tweening.Core.DOGetter`1<System.Int32>::Invoke(*([t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Int32, System.Int32, DG.Tweening.Plugins.Options.NoOptions>)+130]));\n\tv65 = isRelative == 0;\n\tt.endValue = v50;\n\tv56 = ~v65;\n\tv53 = ~v56;\n\tif (v53) goto L_FFFFFFFF;\n\tgoto L_002E;\nL_002E:\n\tv70 = v76 + t.endValue;\n\tt.startValue = v70;\n\tDG.Tweening.Core.DOSetter`1<System.Int32>::Invoke(*([t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Int32, System.Int32, DG.Tweening.Plugins.Options.NoOptions>)+138]), v70);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<int, int, NoOptions> t, bool isRelative)
		{
			//IL_0016: Expected O, but got I
			//IL_008a: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Int32, System.Int32, DG.Tweening.Plugins.Options.NoOptions>)+130]");
			int num = ((DOGetter<int>)0)();
			bool flag = !isRelative;
			t.endValue = num;
			int num2 = ((!flag) ? num : 0);
			int pNewValue = (t.startValue = num2 + t.endValue);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Int32, System.Int32, DG.Tweening.Plugins.Options.NoOptions>)+138]");
			((DOSetter<int>)0)(pNewValue);
		}

		[Token(Token = "0x60001C2")]
		[Address(RVA = "0x10845D4", Offset = "0x10845D4", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1ED8168]);\n\tv27 = *([v26 @ X8_v7]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, t, fromValue, setImmediately, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2026A67]) = v44;\nL_0019:\n\tt.startValue = fromValue;\n\tv47 = setImmediately == 0;\n\tif (v47) goto L_0034;\n\tDG.Tweening.Core.DOSetter`1<System.Int32>::Invoke(*([t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Int32, System.Int32, DG.Tweening.Plugins.Options.NoOptions>)+138]), fromValue);\n\treturn;\nL_0034:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<int, int, NoOptions> t, int fromValue, bool setImmediately)
		{
			//IL_0044: Expected O, but got I
			t.startValue = fromValue;
			if (setImmediately)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Int32, System.Int32, DG.Tweening.Plugins.Options.NoOptions>)+138]");
				((DOSetter<int>)0)(fromValue);
			}
		}

		[Token(Token = "0x60001C3")]
		[Address(RVA = "0x1084660", Offset = "0x1084660", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override int ConvertToStartValue(TweenerCore<int, int, NoOptions> t, int value)
		{
			return value;
		}

		[Token(Token = "0x60001C4")]
		[Address(RVA = "0x1084668", Offset = "0x1084668", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = t.startValue + t.endValue;\n\tt.endValue = v4;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetRelativeEndValue(TweenerCore<int, int, NoOptions> t)
		{
			int endValue = t.startValue + t.endValue;
			t.endValue = endValue;
		}

		[Token(Token = "0x60001C5")]
		[Address(RVA = "0x1084690", Offset = "0x1084690", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = t.endValue - t.startValue;\n\tt.changeValue = v4;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetChangeValue(TweenerCore<int, int, NoOptions> t)
		{
			int changeValue = t.endValue - t.startValue;
			t.changeValue = changeValue;
		}

		[Token(Token = "0x60001C6")]
		[Address(RVA = "0x10846B8", Offset = "0x10846B8", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = changeValue / unitsXSecond;\n\tv4 = -returnVal1;\n\tv14 = returnVal1 >= 0;\n\tif (v14) goto L_0012;\n\tgoto L_0012;\nL_0012:\n\treturn returnVal1;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float GetSpeedBasedDuration(NoOptions options, float unitsXSecond, int changeValue)
		{
			float num = (float)changeValue / unitsXSecond;
			float num2 = 0f - num;
			if (num < 0f)
			{
				num = num2;
			}
			return num;
		}

		[Token(Token = "0x60001C7")]
		[Address(RVA = "0x10846D0", Offset = "0x10846D0", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv38 = *([1EA64C0]);\n\tv39 = *([v38 @ X8_v21]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, options, t, isRelative, getter, setter, startValue, changeValue, elapsed, duration, v44, v45, v46, v47, v48, v49);\n\tv53 = 0 | 1;\n\t*([2026A68]) = v53;\nL_0029:\n\tv65 = t.loopType != 2;\n\tif (v65) goto L_0032;\n\tv161 = t.completedLoops - t.isComplete;\n\tv162 = v161 * changeValue;\n\tv149 = startValue + v162;\nL_0032:\n\tv167 = ~t.isSequenced;\n\tif (v167) goto L_005E;\n\tv92 = t.sequenceParent;\n\tv173 = v92.loopType != 2;\n\tif (v173) goto L_005E;\n\tv172 = t.loopType != 2;\n\tif (v172) goto L_FFFFFFFF;\n\tv296 = t.loops;\n\tgoto L_0053;\nL_0053:\n\tv202 = v296 * changeValue;\n\tv170 = v92.completedLoops - v92.isComplete;\n\tv199 = v202 * v170;\n\tv149 = v149 + v199;\nL_005E:\n\tv206 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);\n\tgoto L_006E;\n\tv273 = *([v268 @ X0_v6+E0]);\n\tv274 = v273 == 0;\n\tv275 = ~v274;\n\tgoto L_006E;\n\tv277 = \"il2cpp_codegen_runtime_class_init\"(v268, v74, t, isRelative, getter, setter, startValue, changeValue, v206, v205, v72, v70, v46, v47, v48, v49);\nL_006E:\n\tv281 = v206 * changeValue;\n\tv147 = v281 + v149;\n\tv140 = 0x6D1ED0(&v76 @ stack_-38_v2 (System.Double), t.customEase, t, isRelative, getter, setter, startValue, changeValue, v147, v281, t.easeOvershootOrAmplitude, t.easePeriod, v46, v47, v48, v49);\n\tv295 = v147 >= 0;\n\tif (v295) goto L_0098;\n\tv96 = v147 != -0.5d;\n\tif (v96) goto L_00BC;\n\tgoto L_009D;\nL_0098:\n\tv95 = v147 != 0.5d;\n\tif (v95) goto L_00C2;\nL_009D:\n\tv85 = v219 + v308;\n\tv313 = v219 & 1;\n\tv123 = v313 == 0;\n\tv68 = ~v123;\n\tif (v68) goto L_FFFFFFFF;\n\tgoto L_00BA;\nL_00BA:\n\tDG.Tweening.Core.DOSetter`1<System.Int32>::Invoke(setter, v219);\n\treturn;\nL_00BC:\n\tv303 = v147 + -0.5d;\n\tv219 = System.Math::Ceiling(v303);\n\tv314 = setter == 0;\n\tv144 = ~v314;\n\tif (v144) goto L_00BA;\n\tgoto L_00C8;\nL_00C2:\n\tv306 = v147 + 0.5d;\n\tv219 = System.Math::Floor(v306);\n\tv315 = setter == 0;\n\tv142 = ~v315;\n\tif (v142) goto L_00BA;\nL_00C8:\n\tthrow System.NullReferenceException;\n// 141 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void EvaluateAndApply(NoOptions options, Tween t, bool isRelative, DOGetter<int> getter, DOSetter<int> setter, float elapsed, int startValue, int changeValue, float duration, bool usingInversePosition, UpdateNotice updateNotice)
		{
			//IL_01cf: Expected I4, but got F8
			//IL_0320: Unknown result type (might be due to invalid IL or missing references)
			//IL_0325: Expected I4, but got Unknown
			bool flag = t.loopType != LoopType.Incremental;
			int num = startValue;
			if (!flag)
			{
				int num2 = t.completedLoops - (t.isComplete ? 1 : 0);
				int num3 = num2 * changeValue;
				num = startValue + num3;
			}
			if (t.isSequenced)
			{
				Sequence sequenceParent = t.sequenceParent;
				if (sequenceParent.loopType == LoopType.Incremental)
				{
					int num4 = ((t.loopType != LoopType.Incremental) ? 1 : t.loops);
					int num5 = num4 * changeValue;
					int num6 = sequenceParent.completedLoops - (sequenceParent.isComplete ? 1 : 0);
					int num7 = num5 * num6;
					num += num7;
				}
			}
			float num8 = EaseManager.Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);
			float num9 = num8 * (float)changeValue;
			float num10 = num9 + (float)num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
			double num11;
			double num12 = default(double);
			double num13;
			if (num10 < 0f)
			{
				if ((double)num10 != -0.5)
				{
					double a = (double)num10 + -0.5;
					num11 = Math.Ceiling(a);
					if (setter != null)
					{
						goto IL_01c2;
					}
					goto IL_0267;
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
					if (setter != null)
					{
						goto IL_01c2;
					}
					goto IL_0267;
				}
				num11 = num12;
				num13 = 1.0;
			}
			double num14 = num11 + num13;
			if ((num11 & 1) != 0)
			{
				num11 = num14;
			}
			goto IL_01c2;
			IL_01c2:
			setter((int)num11);
			return;
			IL_0267:
			throw new NullReferenceException();
		}

		[Token(Token = "0x60001C8")]
		[Address(RVA = "0x1084884", Offset = "0x1084884", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1F09B60]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026A69]) = v38;\nL_001C:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<System.Int32, System.Int32, DG.Tweening.Plugins.Options.NoOptions>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IntPlugin()
		{
		}
	}
}
