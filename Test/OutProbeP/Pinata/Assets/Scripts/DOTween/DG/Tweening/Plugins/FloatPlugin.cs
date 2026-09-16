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
	[Token(Token = "0x200002D")]
	public class FloatPlugin : ABSTweenPlugin<float, float, FloatOptions>
	{
		[Token(Token = "0x600020F")]
		[Address(RVA = "0x108401C", Offset = "0x108401C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset(TweenerCore<float, float, FloatOptions> t)
		{
		}

		[Token(Token = "0x6000210")]
		[Address(RVA = "0x1084020", Offset = "0x1084020", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EBA498]);\n\tv27 = *([v26 @ X8_v20]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, t, isRelative, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv45 = 0 | 1;\n\t*([2026A62]) = v45;\nL_001D:\n\tv91 = t.endValue;\n\tv104 = DG.Tweening.Core.DOGetter`1<System.Single>::Invoke(t.getter);\n\tt.endValue.m_value = v104;\n\tv127 = t.endValue + v104;\n\tv130 = isRelative == 0;\n\tv133 = ~v130;\n\tv134 = ~v133;\n\tif (v134) goto L_0031;\n\tgoto L_0031;\nL_0031:\n\tt.startValue.m_value = v91;\n\tv173 = t.plugOptions == 0;\n\tif (v173) goto L_008F;\n\tgoto L_0043;\n\tv199 = *([v176 @ X0_v9+E0]);\n\tv200 = v199 == 0;\n\tv201 = ~v200;\n\tif (v201) goto L_0043;\n\tv203 = \"il2cpp_codegen_runtime_class_init\"(v176, v89, isRelative, methodInfo, v30, v31, v32, v33, v127, v35, v36, v37, v38, v39, v40, v41);\nL_0043:\n\tv195 = 0x6D1ED0(&v185 @ stack_-28_v4 (System.Double), Il2CppMethodInfo, isRelative, methodInfo, v30, v31, v32, v33, v91, v35, v36, v37, v38, v39, v40, v41);\n\tv218 = v91 >= 0;\n\tif (v218) goto L_0068;\n\tv229 = v91 != -0.5d;\n\tif (v229) goto L_007A;\n\tgoto L_006D;\nL_0068:\n\tv240 = v91 != 0.5d;\n\tif (v240) goto L_007D;\nL_006D:\n\tv261 = v193 + v249;\n\tv262 = v193 & 1;\n\tv264 = v262 == 0;\n\tv267 = ~v264;\n\tif (v267) goto L_FFFFFFFF;\n\tgoto L_0079;\nL_0079:\n\tgoto L_FFFFFFFF;\nL_007A:\n\tv243 = v91 + -0.5d;\n\tv193 = System.Math::Ceiling(v243);\n\tgoto L_FFFFFFFF;\nL_007D:\n\tv247 = v91 + 0.5d;\n\tv193 = System.Math::Floor(v247);\nL_008F:\n\tDG.Tweening.Core.DOSetter`1<System.Single>::Invoke(t.setter, v91);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<float, float, FloatOptions> t, bool isRelative)
		{
			//IL_020a: Unknown result type (might be due to invalid IL or missing references)
			//IL_020f: Expected I4, but got Unknown
			float num = t.endValue;
			float num2 = t.getter();
			t.endValue.m_value = num2;
			float num3 = t.endValue + num2;
			if (isRelative)
			{
				num = num3;
			}
			t.startValue.m_value = num;
			double num4;
			if ((object)t.plugOptions != null)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @6D1ED0 (native modf)");
				double num5;
				double num6 = default(double);
				if (num < 0f)
				{
					if ((double)num != -0.5)
					{
						double a = (double)num + -0.5;
						num4 = Math.Ceiling(a);
						goto IL_019e;
					}
					num5 = -1.0;
					num4 = num6;
				}
				else
				{
					if ((double)num != 0.5)
					{
						double d = (double)num + 0.5;
						num4 = Math.Floor(d);
						goto IL_019e;
					}
					num5 = 1.0;
					num4 = num6;
				}
				double num7 = num4 + num5;
				if ((num4 & 1) != 0)
				{
					num4 = num7;
				}
				goto IL_019e;
			}
			goto IL_01ab;
			IL_01ab:
			t.setter(num);
			return;
			IL_019e:
			num = (float)num4;
			goto IL_01ab;
		}

		[Token(Token = "0x6000211")]
		[Address(RVA = "0x1084164", Offset = "0x1084164", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv28 = *([1EED8D8]);\n\tv29 = *([v28 @ X8_v17]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, t, setImmediately, methodInfo, v32, v33, v34, v35, fromValue, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 0 | 1;\n\t*([2026A63]) = v46;\nL_001A:\n\tt.startValue.m_value = fromValue;\n\tv49 = setImmediately == 0;\n\tif (v49) goto L_0054;\n\tv102 = t.plugOptions == 0;\n\tif (v102) goto L_0086;\n\tgoto L_0031;\n\tv170 = *([v112 @ X0_v7+E0]);\n\tv171 = v170 == 0;\n\tv172 = ~v171;\n\tif (v172) goto L_0031;\n\tv174 = \"il2cpp_codegen_runtime_class_init\"(v112, t, setImmediately, methodInfo, v32, v33, v34, v35, fromValue, v36, v37, v38, v39, v40, v41, v42);\nL_0031:\n\tv130 = 0x6D1ED0(&v128 @ stack_-28_v3 (System.Double), t, setImmediately, methodInfo, v32, v33, v34, v35, fromValue, v36, v37, v38, v39, v40, v41, v42);\n\tv189 = fromValue >= 0;\n\tif (v189) goto L_005F;\n\tv200 = fromValue != -0.5d;\n\tif (v200) goto L_0071;\n\tgoto L_0064;\nL_0054:\n\treturn;\nL_005F:\n\tv211 = fromValue != 0.5d;\n\tif (v211) goto L_0074;\nL_0064:\n\tv232 = v127 + v220;\n\tv233 = v127 & 1;\n\tv235 = v233 == 0;\n\tv238 = ~v235;\n\tif (v238) goto L_FFFFFFFF;\n\tgoto L_0070;\nL_0070:\n\tgoto L_FFFFFFFF;\nL_0071:\n\tv214 = fromValue + -0.5d;\n\tv127 = System.Math::Ceiling(v214);\n\tgoto L_FFFFFFFF;\nL_0074:\n\tv218 = fromValue + 0.5d;\n\tv127 = System.Math::Floor(v218);\nL_0086:\n\tDG.Tweening.Core.DOSetter`1<System.Single>::Invoke(t.setter, v96);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<float, float, FloatOptions> t, float fromValue, bool setImmediately)
		{
			//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b0: Expected I4, but got Unknown
			t.startValue.m_value = fromValue;
			if (!setImmediately)
			{
				return;
			}
			bool flag = (object)t.plugOptions == null;
			float pNewValue = fromValue;
			double num;
			if (!flag)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @6D1ED0 (native modf)");
				double num2;
				double num3 = default(double);
				if (fromValue < 0f)
				{
					if ((double)fromValue != -0.5)
					{
						double a = (double)fromValue + -0.5;
						num = Math.Ceiling(a);
						goto IL_0173;
					}
					num2 = -1.0;
					num = num3;
				}
				else
				{
					if ((double)fromValue != 0.5)
					{
						double d = (double)fromValue + 0.5;
						num = Math.Floor(d);
						goto IL_0173;
					}
					num2 = 1.0;
					num = num3;
				}
				double num4 = num + num2;
				if ((num & 1) != 0)
				{
					num = num4;
				}
				goto IL_0173;
			}
			goto IL_0180;
			IL_0180:
			t.setter(pNewValue);
			return;
			IL_0173:
			pNewValue = (float)num;
			goto IL_0180;
		}

		[Token(Token = "0x6000212")]
		[Address(RVA = "0x1084298", Offset = "0x1084298", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n")]
		public override float ConvertToStartValue(TweenerCore<float, float, FloatOptions> t, float value)
		{
			return value;
		}

		[Token(Token = "0x6000213")]
		[Address(RVA = "0x108429C", Offset = "0x108429C", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = t.endValue + t.startValue;\n\tt.endValue.m_value = v4;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetRelativeEndValue(TweenerCore<float, float, FloatOptions> t)
		{
			float value = t.endValue + t.startValue;
			t.endValue.m_value = value;
		}

		[Token(Token = "0x6000214")]
		[Address(RVA = "0x10842C4", Offset = "0x10842C4", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = t.endValue - t.startValue;\n\tt.changeValue.m_value = v4;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetChangeValue(TweenerCore<float, float, FloatOptions> t)
		{
			float value = t.endValue - t.startValue;
			t.changeValue.m_value = value;
		}

		[Token(Token = "0x6000215")]
		[Address(RVA = "0x10842EC", Offset = "0x10842EC", Length = "0x14")]
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

		[Token(Token = "0x6000216")]
		[Address(RVA = "0x1084300", Offset = "0x1084300", Length = "0x1E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv42 = *([1EFF540]);\n\tv43 = *([v42 @ X8_v21]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, options, t, isRelative, getter, setter, usingInversePosition, updateNotice, elapsed, startValue, changeValue, duration, v49, v50, v51, v52);\n\tv56 = 0 | 1;\n\t*([2026A64]) = v56;\nL_002B:\n\tv68 = t.loopType != 2;\n\tif (v68) goto L_0035;\n\tv157 = t.completedLoops - t.isComplete;\n\tv159 = v157 * changeValue;\n\tv143 = v159 + startValue;\nL_0035:\n\tv163 = ~t.isSequenced;\n\tif (v163) goto L_0063;\n\tv93 = t.sequenceParent;\n\tv171 = v93.loopType != 2;\n\tif (v171) goto L_0063;\n\tv170 = t.loopType != 2;\n\tif (v170) goto L_FFFFFFFF;\n\tgoto L_0057;\nL_0057:\n\tv282 = v280 * changeValue;\n\tv190 = v93.completedLoops - v93.isComplete;\n\tv167 = v282 * v190;\n\tv143 = v143 + v167;\nL_0063:\n\tv140 = options & 0xFF;\n\tv192 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);\n\tv252 = v140 == 0;\n\tif (v252) goto L_0094;\n\tgoto L_0074;\n\tv265 = *([v256 @ X0_v8+E0]);\n\tv266 = v265 == 0;\n\tv267 = ~v266;\n\tif (v267) goto L_0074;\n\tv269 = \"il2cpp_codegen_runtime_class_init\"(v256, v77, t, isRelative, getter, setter, usingInversePosition, updateNotice, v192, v79, v75, v73, v49, v50, v51, v52);\nL_0074:\n\tv272 = v192 * changeValue;\n\tv146 = v143 + v272;\n\tv134 = 0x6D1ED0(&v83 @ stack_-58_v3 (System.Double), t.customEase, t, isRelative, getter, setter, usingInversePosition, updateNotice, v146, duration, t.easeOvershootOrAmplitude, t.easePeriod, v49, v50, v51, v52);\n\tv293 = v146 >= 0;\n\tif (v293) goto L_00A4;\n\tv304 = v146 != -0.5d;\n\tif (v304) goto L_00B6;\n\tgoto L_00A9;\nL_0094:\n\tv260 = v192 * changeValue;\n\tv206 = v143 + v260;\n\tv261 = setter == 0;\n\tv137 = ~v261;\n\tif (v137) goto L_00CD;\n\tgoto L_00D0;\nL_00A4:\n\tv315 = v146 != 0.5d;\n\tif (v315) goto L_00B9;\nL_00A9:\n\tv336 = v343 + v324;\n\tv337 = v343 & 1;\n\tv339 = v337 == 0;\n\tv342 = ~v339;\n\tif (v342) goto L_FFFFFFFF;\n\tgoto L_00B5;\nL_00B5:\n\tgoto L_FFFFFFFF;\nL_00B6:\n\tv318 = v146 + -0.5d;\n\tv343 = System.Math::Ceiling(v318);\n\tgoto L_FFFFFFFF;\nL_00B9:\n\tv322 = v146 + 0.5d;\n\tv343 = System.Math::Floor(v322);\nL_00CD:\n\tDG.Tweening.Core.DOSetter`1<System.Single>::Invoke(setter, v206);\n\treturn;\nL_00D0:\n\tthrow System.NullReferenceException;\n// 146 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void EvaluateAndApply(FloatOptions options, Tween t, bool isRelative, DOGetter<float> getter, DOSetter<float> setter, float elapsed, float startValue, float changeValue, float duration, bool usingInversePosition, UpdateNotice updateNotice)
		{
			//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b3: Expected I4, but got Unknown
			//IL_00d6: Expected F4, but got I4
			//IL_0367: Unknown result type (might be due to invalid IL or missing references)
			//IL_036c: Expected I4, but got Unknown
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
					float num4 = ((t.loopType != LoopType.Incremental) ? 1f : ((float)t.loops));
					float num5 = num4 * changeValue;
					int num6 = sequenceParent.completedLoops - (sequenceParent.isComplete ? 1 : 0);
					float num7 = num5 * (float)num6;
					num += num7;
				}
			}
			int num8 = options & 0xFF;
			float num9 = EaseManager.Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);
			double num12;
			if (num8 != 0)
			{
				float num10 = num9 * changeValue;
				float num11 = num + num10;
				Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @6D1ED0 (native modf)");
				double num13;
				double num14 = default(double);
				if (num11 < 0f)
				{
					if ((double)num11 != -0.5)
					{
						double a = (double)num11 + -0.5;
						num12 = Math.Ceiling(a);
						goto IL_0266;
					}
					num13 = -1.0;
					num12 = num14;
				}
				else
				{
					if ((double)num11 != 0.5)
					{
						double d = (double)num11 + 0.5;
						num12 = Math.Floor(d);
						goto IL_0266;
					}
					num13 = 1.0;
					num12 = num14;
				}
				double num15 = num12 + num13;
				if ((num12 & 1) != 0)
				{
					num12 = num15;
				}
				goto IL_0266;
			}
			float num16 = num9 * changeValue;
			float pNewValue = num + num16;
			if (setter == null)
			{
				throw new NullReferenceException();
			}
			goto IL_0273;
			IL_0273:
			setter(pNewValue);
			return;
			IL_0266:
			pNewValue = (float)num12;
			goto IL_0273;
		}

		[Token(Token = "0x6000217")]
		[Address(RVA = "0x10844E0", Offset = "0x10844E0", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EF1F20]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026A65]) = v38;\nL_001C:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FloatPlugin()
		{
		}
	}
}
