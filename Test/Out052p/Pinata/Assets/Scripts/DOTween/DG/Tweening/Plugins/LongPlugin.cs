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
	[Token(Token = "0x200001F")]
	public class LongPlugin : ABSTweenPlugin<long, long, NoOptions>
	{
		[Token(Token = "0x6000191")]
		[Address(RVA = "0x10848D4", Offset = "0x10848D4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset(TweenerCore<long, long, NoOptions> t)
		{
		}

		[Token(Token = "0x6000192")]
		[Address(RVA = "0x10848D8", Offset = "0x10848D8", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EA5E40]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, t, isRelative, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([2026A6A]) = v41;\nL_001E:\n\tv50 = DG.Tweening.Core.DOGetter`1<System.Int64>::Invoke(*([t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Int64, System.Int64, DG.Tweening.Plugins.Options.NoOptions>)+140]));\n\tv68 = isRelative == 0;\n\tv59 = ~v68;\n\tv56 = ~v59;\n\tif (v56) goto L_FFFFFFFF;\n\tgoto L_002D;\nL_002D:\n\tv73 = v53 + t.endValue;\n\tt.startValue = v73;\n\tt.endValue = v50;\n\tDG.Tweening.Core.DOSetter`1<System.Int64>::Invoke(*([t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Int64, System.Int64, DG.Tweening.Plugins.Options.NoOptions>)+148]), v73);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<long, long, NoOptions> t, bool isRelative)
		{
			//IL_0016: Expected O, but got I
			//IL_0063: Expected I8, but got I4
			//IL_007d: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Int64, System.Int64, DG.Tweening.Plugins.Options.NoOptions>)+140]");
			long num = ((DOGetter<long>)0)();
			long num2 = ((!isRelative) ? 0 : num);
			long pNewValue = (t.startValue = num2 + t.endValue);
			t.endValue = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Int64, System.Int64, DG.Tweening.Plugins.Options.NoOptions>)+148]");
			((DOSetter<long>)0)(pNewValue);
		}

		[Token(Token = "0x6000193")]
		[Address(RVA = "0x1084974", Offset = "0x1084974", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EED130]);\n\tv27 = *([v26 @ X8_v7]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, t, fromValue, setImmediately, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2026A6B]) = v44;\nL_0019:\n\tt.startValue = fromValue;\n\tv47 = setImmediately == 0;\n\tif (v47) goto L_0034;\n\tDG.Tweening.Core.DOSetter`1<System.Int64>::Invoke(*([t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Int64, System.Int64, DG.Tweening.Plugins.Options.NoOptions>)+148]), fromValue);\n\treturn;\nL_0034:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<long, long, NoOptions> t, long fromValue, bool setImmediately)
		{
			//IL_0044: Expected O, but got I
			t.startValue = fromValue;
			if (setImmediately)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Int64, System.Int64, DG.Tweening.Plugins.Options.NoOptions>)+148]");
				((DOSetter<long>)0)(fromValue);
			}
		}

		[Token(Token = "0x6000194")]
		[Address(RVA = "0x1084A00", Offset = "0x1084A00", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override long ConvertToStartValue(TweenerCore<long, long, NoOptions> t, long value)
		{
			return value;
		}

		[Token(Token = "0x6000195")]
		[Address(RVA = "0x1084A08", Offset = "0x1084A08", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = t.startValue + t.endValue;\n\tt.endValue = v4;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetRelativeEndValue(TweenerCore<long, long, NoOptions> t)
		{
			long endValue = t.startValue + t.endValue;
			t.endValue = endValue;
		}

		[Token(Token = "0x6000196")]
		[Address(RVA = "0x1084A2C", Offset = "0x1084A2C", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = t.endValue - t.startValue;\n\tt.changeValue = v4;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetChangeValue(TweenerCore<long, long, NoOptions> t)
		{
			long changeValue = t.endValue - t.startValue;
			t.changeValue = changeValue;
		}

		[Token(Token = "0x6000197")]
		[Address(RVA = "0x1084A50", Offset = "0x1084A50", Length = "0x18")]
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

		[Token(Token = "0x6000198")]
		[Address(RVA = "0x1084A68", Offset = "0x1084A68", Length = "0x1BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv38 = *([1EC6E38]);\n\tv39 = *([v38 @ X8_v21]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, options, t, isRelative, getter, setter, startValue, changeValue, elapsed, duration, v44, v45, v46, v47, v48, v49);\n\tv53 = 0 | 1;\n\t*([2026A6C]) = v53;\nL_0029:\n\tv65 = t.loopType != 2;\n\tif (v65) goto L_0033;\n\tv161 = t.completedLoops - t.isComplete;\n\tv163 = v161 * changeValue;\n\tv149 = startValue + v163;\nL_0033:\n\tv168 = ~t.isSequenced;\n\tif (v168) goto L_0060;\n\tv92 = t.sequenceParent;\n\tv174 = v92.loopType != 2;\n\tif (v174) goto L_0060;\n\tv173 = t.loopType != 2;\n\tif (v173) goto L_FFFFFFFF;\n\tv297 = t.loops;\n\tgoto L_0054;\nL_0054:\n\tv203 = v297 * changeValue;\n\tv300 = v92.completedLoops - v92.isComplete;\n\tv200 = v203 * v300;\n\tv149 = v149 + v200;\nL_0060:\n\tv207 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);\n\tgoto L_0070;\n\tv274 = *([v269 @ X0_v6+E0]);\n\tv275 = v274 == 0;\n\tv276 = ~v275;\n\tgoto L_0070;\n\tv278 = \"il2cpp_codegen_runtime_class_init\"(v269, v74, t, isRelative, getter, setter, startValue, changeValue, v207, v206, v72, v70, v46, v47, v48, v49);\nL_0070:\n\tv282 = v207 * changeValue;\n\tv147 = v282 + v149;\n\tv140 = 0x6D1ED0(&v76 @ stack_-38_v2 (System.Double), t.customEase, t, isRelative, getter, setter, startValue, changeValue, v147, v282, t.easeOvershootOrAmplitude, t.easePeriod, v46, v47, v48, v49);\n\tv296 = v147 >= 0;\n\tif (v296) goto L_009A;\n\tv96 = v147 != -0.5d;\n\tif (v96) goto L_00BE;\n\tgoto L_009F;\nL_009A:\n\tv95 = v147 != 0.5d;\n\tif (v95) goto L_00C4;\nL_009F:\n\tv85 = v220 + v310;\n\tv315 = v220 & 1;\n\tv123 = v315 == 0;\n\tv68 = ~v123;\n\tif (v68) goto L_FFFFFFFF;\n\tgoto L_00BC;\nL_00BC:\n\tDG.Tweening.Core.DOSetter`1<System.Int64>::Invoke(setter, v220);\n\treturn;\nL_00BE:\n\tv305 = v147 + -0.5d;\n\tv220 = System.Math::Ceiling(v305);\n\tv316 = setter == 0;\n\tv144 = ~v316;\n\tif (v144) goto L_00BC;\n\tgoto L_00CA;\nL_00C4:\n\tv308 = v147 + 0.5d;\n\tv220 = System.Math::Floor(v308);\n\tv317 = setter == 0;\n\tv142 = ~v317;\n\tif (v142) goto L_00BC;\nL_00CA:\n\tthrow System.NullReferenceException;\n// 143 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void EvaluateAndApply(NoOptions options, Tween t, bool isRelative, DOGetter<long> getter, DOSetter<long> setter, float elapsed, long startValue, long changeValue, float duration, bool usingInversePosition, UpdateNotice updateNotice)
		{
			//IL_01cf: Expected I8, but got F8
			//IL_0320: Unknown result type (might be due to invalid IL or missing references)
			//IL_0325: Expected I4, but got Unknown
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
			setter((long)num11);
			return;
			IL_0267:
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000199")]
		[Address(RVA = "0x1084C24", Offset = "0x1084C24", Length = "0x11C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EDB828]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026A6D]) = v38;\nL_001C:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<System.Int64, System.Int64, DG.Tweening.Plugins.Options.NoOptions>::.ctor(this);\n\treturn;\n\t*([X0]) = 0;\n\treturn;\n\t*([X0]) = 0;\n\treturn;\n\treturn;\n\t// 35 ShiftStack -32\n\tstack[0] = X20;\n\tstack[8] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX8 = *([2026A6E]);\n\tX19 = X0;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0036;\n\tX8 = *([1EC1A50]);\n\tX0 = *([X8]);\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([2026A6E]) = X8;\nL_0036:\n\t*([X19+10]) = 0;\n\t*([X19]) = 0;\n\t*([X19+8]) = 0;\n\tX8 = *([1EE1550]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0045;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0045;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0045:\n\tX0 = 0;\n\tV0 = UnityEngine.Vector3::get_zero(X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\t*([X19+14]) = V0;\n\t*([X19+18]) = V1;\n\t*([X19+1C]) = V2;\n\t*([X19+20]) = 0;\n\t*([X19+28]) = 0;\n\t*([X19+2C]) = 0;\n\tX8 = *([1EC5B90]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_005B;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_005B;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_005B:\n\tX0 = 0;\n\tV0 = UnityEngine.Quaternion::get_identity(X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tX0 = 0;\n\t*([X19+30]) = V0;\n\t*([X19+34]) = V1;\n\t*([X19+38]) = V2;\n\t*([X19+3C]) = V3;\n\t*([X19+40]) = 0;\n\t*([X19+48]) = 0;\n\tV0 = UnityEngine.Quaternion::get_identity(X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\t*([X19+54]) = V0;\n\t*([X19+58]) = V1;\n\t*([X19+5C]) = V2;\n\t*([X19+60]) = V3;\n\t*([X19+64]) = 0;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 116 ShiftStack 32\n\treturn;\n\t// 118 ShiftStack -32\n\tstack[0] = X20;\n\tstack[8] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX8 = *([2026A6F]);\n\tX19 = X0;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0089;\n\tX8 = *([1EC72C8]);\n\tX0 = *([X8]);\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([2026A6F]) = X8;\nL_0089:\n\t*([X19]) = 0;\n\tX8 = *([1EE1550]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0096;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0096;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0096:\n\tX0 = 0;\n\tV0 = UnityEngine.Vector3::get_zero(X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\t*([X19+8]) = V0;\n\t*([X19+C]) = V1;\n\t*([X19+10]) = V2;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 161 ShiftStack 32\n\treturn;\n\t*([X0]) = 0;\n\treturn;\n\t*([X0]) = 0;\n\t*([X0+14]) = 0;\n\t*([X0+C]) = 0;\n\t*([X0+4]) = 0;\n\treturn;\n\tMorpeh.CacheComponents`1<Morpeh.Globals.ECS.GlobalEventComponent`1<System.Object>>::.cctor(X0);\n\treturn;\n\tX8 = *([X19]);\n\tX0 = 0x1074008(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\tX0 = *([X8]);\n\tX0 = 0x1080008(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\tX1 = *([X8]);\n\tX0 = 0x107F00C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\tX0 = *([X8]);\n\tX0 = 0x1073008(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\tX0 = *([X8]);\n\tX0 = 0x107C008(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\treturn;\n// 1050 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LongPlugin()
		{
		}
	}
}
