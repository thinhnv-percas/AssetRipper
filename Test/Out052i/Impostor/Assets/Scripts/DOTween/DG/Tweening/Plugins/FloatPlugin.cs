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
	[Token(Token = "0x2000085")]
	public class FloatPlugin : ABSTweenPlugin<float, float, FloatOptions>
	{
		[Token(Token = "0x6000358")]
		[Address(RVA = "0xC26FC4", Offset = "0xC26FC4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset(TweenerCore<float, float, FloatOptions> t)
		{
		}

		[Token(Token = "0x6000359")]
		[Address(RVA = "0xC26FC8", Offset = "0xC26FC8", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = System.Math;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, t, isRelative, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A35791]) = v40;\nL_0016:\n\tv42 = t.getter;\n\tv148 = t.endValue;\n\tv101 = DG.Tweening.Core.DOGetter`1<System.Single>::Invoke(t.getter);\n\tv97 = t.setter;\n\tt.endValue = v29;\n\tv103 = t.endValue + v29;\n\tv106 = isRelative == 0;\n\tv109 = ~v106;\n\tv110 = ~v109;\n\tif (v110) goto L_002E;\n\tgoto L_002E;\nL_002E:\n\tt.startValue = v148;\n\tv149 = t.plugOptions == 0;\n\tif (v149) goto L_0086;\n\tgoto L_003C;\n\tv175 = \"il2cpp_codegen_runtime_class_init\"(v152, v86, isRelative, methodInfo, v25, v26, v27, v28, v103, v30, v31, v32, v33, v34, v35, v36);\nL_003C:\n\tv171 = 0x1854ED0(&v161 @ stack_-38_v3 (System.Double), v42.method, isRelative, methodInfo, v25, v26, v27, v28, v148, v45, v31, v32, v33, v34, v35, v36);\n\tv188 = v148 >= 0;\n\tif (v188) goto L_0061;\n\tv199 = v148 != -0.5d;\n\tif (v199) goto L_0073;\n\tgoto L_0066;\nL_0061:\n\tv210 = v148 != 0.5d;\n\tif (v210) goto L_0076;\nL_0066:\n\tv45 = v169 + v219;\n\tv232 = v169 & 1;\n\tv234 = v232 == 0;\n\tv237 = ~v234;\n\tif (v237) goto L_FFFFFFFF;\n\tgoto L_0072;\nL_0072:\n\tgoto L_FFFFFFFF;\nL_0073:\n\tv213 = v148 + -0.5d;\n\tv169 = System.Math::Ceiling(v213);\n\tgoto L_FFFFFFFF;\nL_0076:\n\tv217 = v148 + 0.5d;\n\tv169 = System.Math::Floor(v217);\nL_0086:\n\tDG.Tweening.Core.DOSetter`1<System.Single>::Invoke(t.setter, v97.method);\n\tthrow System.NullReferenceException;\n\treturn;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<float, float, FloatOptions> t, bool isRelative)
		{
			//IL_0036: Expected O, but got F4
			//IL_01f1: Expected F4, but got I
			//IL_0239: Unknown result type (might be due to invalid IL or missing references)
			//IL_023e: Expected I4, but got Unknown
			DOGetter<float> getter = t.getter;
			float num = t.endValue;
			object obj = t.getter();
			DOSetter<float> setter = t.setter;
			float num2 = default(float);
			t.endValue = num2;
			float num3 = t.endValue + num2;
			if (isRelative)
			{
				num = num3;
			}
			t.startValue = num;
			double num4;
			if ((object)t.plugOptions != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854ED0 (native modf)");
				double num6;
				double num7 = default(double);
				double num5;
				if (num < 0f)
				{
					if ((double)num != -0.5)
					{
						double a = (double)num + -0.5;
						num4 = Math.Ceiling(a);
						num5 = -0.5;
						goto IL_01cd;
					}
					num6 = -1.0;
					num4 = num7;
				}
				else
				{
					if ((double)num != 0.5)
					{
						double d = (double)num + 0.5;
						num4 = Math.Floor(d);
						num5 = 0.5;
						goto IL_01cd;
					}
					num6 = 1.0;
					num4 = num7;
				}
				num5 = num4 + num6;
				if ((num4 & 1) != 0)
				{
					num4 = num5;
				}
				goto IL_01cd;
			}
			goto IL_01da;
			IL_01da:
			t.setter((nint)setter.method);
			return;
			IL_01cd:
			num = (float)num4;
			goto IL_01da;
		}

		[Token(Token = "0x600035A")]
		[Address(RVA = "0xC270F4", Offset = "0xC270F4", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = System.Math;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, t, setImmediately, isRelative, methodInfo, v31, v32, v33, fromValue, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A35792]) = v44;\nL_0018:\n\tv46 = isRelative == 0;\n\tif (v46) goto L_FFFFFFFF;\n\tv49 = t.getter;\n\tv111 = DG.Tweening.Core.DOGetter`1<System.Single>::Invoke(t.getter);\n\tv102 = fromValue + fromValue;\n\tv106 = fromValue + t.endValue;\n\tt.endValue = v106;\n\tgoto L_002A;\nL_002A:\n\tt.startValue = v102;\n\tv117 = setImmediately == 0;\n\tif (v117) goto L_0060;\n\tv100 = t.setter;\n\tv121 = t.plugOptions == 0;\n\tif (v121) goto L_0091;\n\tgoto L_003D;\n\tv191 = \"il2cpp_codegen_runtime_class_init\"(v168, v91, setImmediately, isRelative, methodInfo, v31, v32, v33, fromValue, v106, v35, v36, v37, v38, v39, v40);\nL_003D:\n\tv186 = 0x1854ED0(&v183 @ stack_-28_v3 (System.Double), v91, setImmediately, isRelative, methodInfo, v31, v32, v33, v102, v106, v35, v36, v37, v38, v39, v40);\n\tv204 = v102 >= 0;\n\tif (v204) goto L_006B;\n\tv215 = v102 != -0.5d;\n\tif (v215) goto L_007D;\n\tgoto L_0070;\nL_0060:\n\treturn;\nL_006B:\n\tv226 = v102 != 0.5d;\n\tif (v226) goto L_0080;\nL_0070:\n\tv185 = v182 + v245;\n\tv248 = v182 & 1;\n\tv250 = v248 == 0;\n\tv253 = ~v250;\n\tif (v253) goto L_FFFFFFFF;\n\tgoto L_007C;\nL_007C:\n\tgoto L_FFFFFFFF;\nL_007D:\n\tv229 = v102 + -0.5d;\n\tv182 = System.Math::Ceiling(v229);\n\tgoto L_FFFFFFFF;\nL_0080:\n\tv233 = v102 + 0.5d;\n\tv182 = System.Math::Floor(v233);\nL_0091:\n\tDG.Tweening.Core.DOSetter`1<System.Single>::Invoke(t.setter, v100.method);\n\tthrow System.NullReferenceException;\n\treturn;\n// 103 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<float, float, FloatOptions> t, float fromValue, bool setImmediately, bool isRelative)
		{
			//IL_0029: Expected O, but got F4
			//IL_0066: Expected O, but got I
			//IL_022f: Expected F4, but got I
			//IL_0265: Unknown result type (might be due to invalid IL or missing references)
			//IL_026a: Expected I4, but got Unknown
			float endValue;
			float num;
			if (isRelative)
			{
				DOGetter<float> getter = t.getter;
				object obj = t.getter();
				num = fromValue + fromValue;
				endValue = fromValue + t.endValue;
				t.endValue = endValue;
				TweenerCore<float, float, FloatOptions> tweenerCore = (TweenerCore<float, float, FloatOptions>)(nint)getter.method;
			}
			else
			{
				TweenerCore<float, float, FloatOptions> tweenerCore = t;
				num = fromValue;
			}
			t.startValue = num;
			if (!setImmediately)
			{
				return;
			}
			DOSetter<float> setter = t.setter;
			double num2;
			double num3;
			if ((object)t.plugOptions != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854ED0 (native modf)");
				double num4 = default(double);
				double num5;
				if (num < 0f)
				{
					if ((double)num != -0.5)
					{
						double a = (double)num + -0.5;
						num2 = Math.Ceiling(a);
						num3 = -0.5;
						goto IL_0203;
					}
					num2 = num4;
					num5 = -1.0;
				}
				else
				{
					if ((double)num != 0.5)
					{
						double d = (double)num + 0.5;
						num2 = Math.Floor(d);
						num3 = 0.5;
						goto IL_0203;
					}
					num2 = num4;
					num5 = 1.0;
				}
				num3 = num2 + num5;
				if ((num2 & 1) != 0)
				{
					num2 = num3;
				}
				goto IL_0203;
			}
			goto IL_0218;
			IL_0203:
			endValue = (float)num3;
			num = (float)num2;
			goto IL_0218;
			IL_0218:
			t.setter((nint)setter.method);
		}

		[Token(Token = "0x600035B")]
		[Address(RVA = "0xC27248", Offset = "0xC27248", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n")]
		public override float ConvertToStartValue(TweenerCore<float, float, FloatOptions> t, float value)
		{
			return value;
		}

		[Token(Token = "0x600035C")]
		[Address(RVA = "0xC2724C", Offset = "0xC2724C", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = t.endValue + t.startValue;\n\tt.endValue = v6;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetRelativeEndValue(TweenerCore<float, float, FloatOptions> t)
		{
			float endValue = t.endValue + t.startValue;
			t.endValue = endValue;
		}

		[Token(Token = "0x600035D")]
		[Address(RVA = "0xC27270", Offset = "0xC27270", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = t.endValue - t.startValue;\n\tt.changeValue = v6;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetChangeValue(TweenerCore<float, float, FloatOptions> t)
		{
			float changeValue = t.endValue - t.startValue;
			t.changeValue = changeValue;
		}

		[Token(Token = "0x600035E")]
		[Address(RVA = "0xC27294", Offset = "0xC27294", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = changeValue / unitsXSecond;\n\tv3 = -returnVal1;\n\tv13 = returnVal1 >= 0;\n\tif (v13) goto L_0011;\n\tgoto L_0011;\nL_0011:\n\treturn returnVal1;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float GetSpeedBasedDuration(FloatOptions options, float unitsXSecond, float changeValue)
		{
			float num = changeValue / unitsXSecond;
			float num2 = 0f - num;
			if (num < 0f)
			{
				num = num2;
			}
			return num;
		}

		[Token(Token = "0x600035F")]
		[Address(RVA = "0xC272A8", Offset = "0xC272A8", Length = "0x1B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv38 = System.Math;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, options, t, isRelative, getter, setter, usingInversePosition, newCompletedSteps, elapsed, startValue, changeValue, duration, v44, v45, v46, v47);\n\tv51 = 1;\n\t*([1A35793]) = v51;\nL_0028:\n\tv63 = t.loopType != 2;\n\tif (v63) goto L_0032;\n\tv136 = t.completedLoops - t.isComplete;\n\tv138 = v136 * changeValue;\n\tv177 = v138 + startValue;\nL_0032:\n\tv142 = ~t.isSequenced;\n\tif (v142) goto L_0060;\n\tv88 = t.sequenceParent;\n\tv151 = v88.loopType != 2;\n\tif (v151) goto L_0060;\n\tv150 = t.loopType != 2;\n\tif (v150) goto L_0053;\nL_0053:\n\tv246 = v244 * changeValue;\n\tv180 = v88.completedLoops - v88.isComplete;\n\tv146 = v246 * v180;\n\tv177 = v177 + v146;\nL_0060:\n\tv184 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);\n\tv229 = options & 1;\n\tv230 = v229 == 0;\n\tv231 = ~v230;\n\tif (v231) goto L_006F;\n\tgoto L_00C2;\nL_006F:\n\tgoto L_0071;\n\tv267 = \"il2cpp_codegen_runtime_class_init\"(v238, v72, v74, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v184, v183, v70, v68, v44, v45, v46, v47);\nL_0071:\n\tv269 = v184 * changeValue;\n\tv265 = v177 + v269;\n\tv261 = 0x1854ED0(&v250 @ stack_-28_v3 (System.Double), t.customEase, 0, isRelative, getter, setter, usingInversePosition, newCompletedSteps, v265, duration, t.easeOvershootOrAmplitude, t.easePeriod, v44, v45, v46, v47);\n\tv281 = v265 >= 0;\n\tif (v281) goto L_009B;\n\tv292 = v265 != -0.5d;\n\tif (v292) goto L_00AD;\n\tgoto L_00A0;\nL_009B:\n\tv303 = v265 != 0.5d;\n\tif (v303) goto L_00B0;\nL_00A0:\n\tv249 = v331 + v312;\n\tv325 = v331 & 1;\n\tv327 = v325 == 0;\n\tv330 = ~v327;\n\tif (v330) goto L_FFFFFFFF;\n\tgoto L_00AC;\nL_00AC:\n\tgoto L_FFFFFFFF;\nL_00AD:\n\tv306 = v265 + -0.5d;\n\tv331 = System.Math::Ceiling(v306);\n\tgoto L_FFFFFFFF;\nL_00B0:\n\tv310 = v265 + 0.5d;\n\tv331 = System.Math::Floor(v310);\nL_00C2:\n\tDG.Tweening.Core.DOSetter`1<System.Single>::Invoke(setter, setter.method);\n\tthrow System.NullReferenceException;\n\treturn;\n// 143 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void EvaluateAndApply(FloatOptions options, Tween t, bool isRelative, DOGetter<float> getter, DOSetter<float> setter, float elapsed, float startValue, float changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice)
		{
			//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ae: Expected I4, but got Unknown
			//IL_024c: Expected F4, but got I
			//IL_0338: Unknown result type (might be due to invalid IL or missing references)
			//IL_033d: Expected I4, but got Unknown
			//IL_00df: Expected F4, but got I4
			bool flag = t.loopType != LoopType.Incremental;
			float num = startValue;
			if (!flag)
			{
				int num2 = t.completedLoops - (t.isComplete ? 1 : 0);
				float num3 = (float)num2 * changeValue;
				num = num3 + startValue;
			}
			if (t.isSequenced)
			{
				Sequence sequenceParent = t.sequenceParent;
				if (sequenceParent.loopType == LoopType.Incremental)
				{
					bool flag2 = t.loopType != LoopType.Incremental;
					float num4 = 1f;
					if (!flag2)
					{
						num4 = t.loops;
					}
					float num5 = num4 * changeValue;
					int num6 = sequenceParent.completedLoops - (sequenceParent.isComplete ? 1 : 0);
					float num7 = num5 * (float)num6;
					num += num7;
				}
			}
			float num8 = EaseManager.Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);
			if ((options & 1) != 0)
			{
				float num9 = num8 * changeValue;
				float num10 = num + num9;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854ED0 (native modf)");
				double num13;
				double num14 = default(double);
				double num12;
				double num11;
				if (num10 < 0f)
				{
					if ((double)num10 != -0.5)
					{
						double a = (double)num10 + -0.5;
						num11 = Math.Ceiling(a);
						num12 = -0.5;
						goto IL_023a;
					}
					num13 = -1.0;
					num11 = num14;
				}
				else
				{
					if ((double)num10 != 0.5)
					{
						double d = (double)num10 + 0.5;
						num11 = Math.Floor(d);
						num12 = 0.5;
						goto IL_023a;
					}
					num13 = 1.0;
					num11 = num14;
				}
				num12 = num11 + num13;
				if ((num11 & 1) != 0)
				{
					num11 = num12;
				}
			}
			goto IL_023a;
			IL_023a:
			setter((nint)setter.method);
		}

		[Token(Token = "0x6000360")]
		[Address(RVA = "0xC27460", Offset = "0xC27460", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35794]) = v37;\nL_001A:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>::.ctor(this);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FloatPlugin()
		{
		}
	}
}
