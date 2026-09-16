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
	[Token(Token = "0x2000028")]
	public class UintPlugin : ABSTweenPlugin<uint, uint, UintOptions>
	{
		[Token(Token = "0x60001E5")]
		[Address(RVA = "0x10DD6C8", Offset = "0x10DD6C8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset(TweenerCore<uint, uint, UintOptions> t)
		{
		}

		[Token(Token = "0x60001E6")]
		[Address(RVA = "0x10DD6CC", Offset = "0x10DD6CC", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EB0E60]);\n\tv23 = *([v22 @ X8_v14]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, t, isRelative, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([20274D5]) = v41;\nL_001E:\n\tv50 = DG.Tweening.Core.DOGetter`1<System.UInt32>::Invoke(t.getter);\n\tv65 = isRelative == 0;\n\tt.endValue = v50;\n\tv56 = ~v65;\n\tv53 = ~v56;\n\tif (v53) goto L_FFFFFFFF;\n\tgoto L_002E;\nL_002E:\n\tv70 = v76 + t.endValue;\n\tt.startValue = v70;\n\tDG.Tweening.Core.DOSetter`1<System.UInt32>::Invoke(t.setter, v70);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<uint, uint, UintOptions> t, bool isRelative)
		{
			uint num = t.getter();
			bool flag = !isRelative;
			t.endValue = num;
			uint num2 = ((!flag) ? num : 0u);
			uint pNewValue = (t.startValue = num2 + t.endValue);
			t.setter(pNewValue);
		}

		[Token(Token = "0x60001E7")]
		[Address(RVA = "0x10DD76C", Offset = "0x10DD76C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1F03B10]);\n\tv27 = *([v26 @ X8_v7]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, t, fromValue, setImmediately, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([20274D6]) = v44;\nL_0019:\n\tt.startValue = fromValue;\n\tv47 = setImmediately == 0;\n\tif (v47) goto L_0034;\n\tDG.Tweening.Core.DOSetter`1<System.UInt32>::Invoke(t.setter, fromValue);\n\treturn;\nL_0034:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<uint, uint, UintOptions> t, uint fromValue, bool setImmediately)
		{
			t.startValue = fromValue;
			if (setImmediately)
			{
				t.setter(fromValue);
			}
		}

		[Token(Token = "0x60001E8")]
		[Address(RVA = "0x10DD7F8", Offset = "0x10DD7F8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override uint ConvertToStartValue(TweenerCore<uint, uint, UintOptions> t, uint value)
		{
			return value;
		}

		[Token(Token = "0x60001E9")]
		[Address(RVA = "0x10DD800", Offset = "0x10DD800", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = t.startValue + t.endValue;\n\tt.endValue = v4;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetRelativeEndValue(TweenerCore<uint, uint, UintOptions> t)
		{
			int endValue = (int)(t.startValue + t.endValue);
			t.endValue = (uint)endValue;
		}

		[Token(Token = "0x60001EA")]
		[Address(RVA = "0x10DD828", Offset = "0x10DD828", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = t.startValue - t.endValue;\n\tv5 = t.endValue < t.startValue;\n\tv6 = ~v5;\n\tv42 = t.endValue - t.startValue;\n\tv15 = ~v6;\n\tv17 = ~v6;\n\tv18 = ~v17;\n\tif (v18) goto L_0018;\n\tgoto L_0018;\nL_0018:\n\tt.plugOptions = v15;\n\tt.changeValue = v42;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetChangeValue(TweenerCore<uint, uint, UintOptions> t)
		{
			//IL_009a: Expected O, but got I4
			int num = (int)(t.startValue - t.endValue);
			bool flag = (int)t.endValue < (int)t.startValue;
			bool flag2 = !flag;
			int changeValue = (int)(t.endValue - t.startValue);
			bool flag3 = !flag2;
			if (!flag2)
			{
				changeValue = num;
			}
			t.plugOptions = (UintOptions)flag3;
			t.changeValue = (uint)changeValue;
		}

		[Token(Token = "0x60001EB")]
		[Address(RVA = "0x10DD860", Offset = "0x10DD860", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = changeValue / unitsXSecond;\n\tv5 = -returnVal1;\n\tv15 = returnVal1 >= 0;\n\tif (v15) goto L_0013;\n\tgoto L_0013;\nL_0013:\n\treturn returnVal1;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float GetSpeedBasedDuration(UintOptions options, float unitsXSecond, uint changeValue)
		{
			float num = (float)(int)changeValue / unitsXSecond;
			float num2 = 0f - num;
			if (num < 0f)
			{
				num = num2;
			}
			return num;
		}

		[Token(Token = "0x60001EC")]
		[Address(RVA = "0x10DD87C", Offset = "0x10DD87C", Length = "0x204")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv42 = *([1EE63D8]);\n\tv43 = *([v42 @ X8_v21]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, options, t, isRelative, getter, setter, startValue, changeValue, elapsed, duration, v47, v48, v49, v50, v51, v52);\n\tv56 = 0 | 1;\n\t*([20274D7]) = v56;\nL_002B:\n\tv68 = t.loopType != 2;\n\tif (v68) goto L_0039;\n\tv166 = t.completedLoops - t.isComplete;\n\tv167 = options & 0xFF;\n\tv168 = v166 * changeValue;\n\tv169 = v167 == 0;\n\tif (v169) goto L_0037;\n\tv173 = startValue - v168;\n\tgoto L_0039;\nL_0037:\n\tv172 = v168 + startValue;\nL_0039:\n\tv175 = ~t.isSequenced;\n\tif (v175) goto L_006B;\n\tv97 = t.sequenceParent;\n\tv181 = v97.loopType != 2;\n\tif (v181) goto L_006B;\n\tv180 = t.loopType != 2;\n\tif (v180) goto L_FFFFFFFF;\n\tv307 = t.loops;\n\tgoto L_005A;\nL_005A:\n\tv310 = v307 * changeValue;\n\tv178 = v97.completedLoops - v97.isComplete;\n\tv176 = options & 0xFF;\n\tv211 = v310 * v178;\n\tv207 = v176 == 0;\n\tif (v207) goto L_0063;\n\tv209 = v154 - v211;\n\tgoto L_006B;\nL_0063:\n\tv208 = v211 + v154;\nL_006B:\n\tv215 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);\n\tgoto L_007B;\n\tv285 = *([v280 @ X0_v6+E0]);\n\tv286 = v285 == 0;\n\tv287 = ~v286;\n\tgoto L_007B;\n\tv289 = \"il2cpp_codegen_runtime_class_init\"(v280, v79, v73, isRelative, getter, setter, startValue, changeValue, v215, v214, v77, v75, v49, v50, v51, v52);\nL_007B:\n\tv152 = v215 * changeValue;\n\tv145 = 0x6D1ED0(&v85 @ stack_-58_v2 (System.Double), t.customEase, 0, isRelative, getter, setter, startValue, changeValue, v152, duration, t.easeOvershootOrAmplitude, t.easePeriod, v49, v50, v51, v52);\n\tv306 = v152 >= 0;\n\tif (v306) goto L_00A4;\n\tv101 = v152 != -0.5d;\n\tif (v101) goto L_00D1;\n\tgoto L_00A9;\nL_00A4:\n\tv100 = v152 != 0.5d;\n\tif (v100) goto L_00D7;\nL_00A9:\n\tv83 = v230 + v320;\n\tv326 = v230 & 1;\n\tv128 = v326 == 0;\n\tv71 = ~v128;\n\tif (v71) goto L_FFFFFFFF;\n\tgoto L_00B7;\nL_00B7:\n\tv333 = options & 0xFF;\n\tv255 = v333 == 0;\n\tif (v255) goto L_00C1;\n\tv336 = v154 - v230;\n\tgoto L_00CF;\nL_00C1:\n\tv339 = v154 + v230;\nL_00CF:\n\tDG.Tweening.Core.DOSetter`1<System.UInt32>::Invoke(setter, v225);\n\treturn;\nL_00D1:\n\tv316 = v152 + -0.5d;\n\tv230 = System.Math::Ceiling(v316);\n\tv327 = setter == 0;\n\tv149 = ~v327;\n\tif (v149) goto L_00B7;\n\tgoto L_00DD;\nL_00D7:\n\tv319 = v152 + 0.5d;\n\tv230 = System.Math::Floor(v319);\n\tv328 = setter == 0;\n\tv147 = ~v328;\n\tif (v147) goto L_00B7;\nL_00DD:\n\tthrow System.NullReferenceException;\n// 147 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void EvaluateAndApply(UintOptions options, Tween t, bool isRelative, DOGetter<uint> getter, DOSetter<uint> setter, float elapsed, uint startValue, uint changeValue, float duration, bool usingInversePosition, UpdateNotice updateNotice)
		{
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Expected I4, but got Unknown
			//IL_023c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0241: Expected I4, but got Unknown
			//IL_0294: Expected I4, but got F8
			//IL_0403: Unknown result type (might be due to invalid IL or missing references)
			//IL_0408: Expected I4, but got Unknown
			//IL_0276: Expected I4, but got F8
			//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c1: Expected I4, but got Unknown
			bool flag = t.loopType != LoopType.Incremental;
			uint num = startValue;
			if (!flag)
			{
				int num2 = t.completedLoops - (t.isComplete ? 1 : 0);
				int num3 = options & 0xFF;
				int num4 = num2 * (int)changeValue;
				if (num3 != 0)
				{
					int num5 = (int)startValue - num4;
					num = (uint)num5;
				}
				else
				{
					int num6 = num4 + (int)startValue;
					num = (uint)num6;
				}
			}
			if (t.isSequenced)
			{
				Sequence sequenceParent = t.sequenceParent;
				if (sequenceParent.loopType == LoopType.Incremental)
				{
					int num7 = ((t.loopType != LoopType.Incremental) ? 1 : t.loops);
					int num8 = num7 * (int)changeValue;
					int num9 = sequenceParent.completedLoops - (sequenceParent.isComplete ? 1 : 0);
					int num10 = options & 0xFF;
					int num11 = num8 * num9;
					if (num10 != 0)
					{
						int num12 = (int)num - num11;
						num = (uint)num12;
					}
					else
					{
						int num13 = num11 + (int)num;
						num = (uint)num13;
					}
				}
			}
			float num14 = EaseManager.Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);
			float num15 = num14 * (float)(int)changeValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
			double num16;
			double num17;
			double num18 = default(double);
			if (num15 < 0f)
			{
				if ((double)num15 != -0.5)
				{
					double a = (double)num15 + -0.5;
					num16 = Math.Ceiling(a);
					if (setter != null)
					{
						goto IL_0233;
					}
					goto IL_0331;
				}
				num17 = -1.0;
				num16 = num18;
			}
			else
			{
				if ((double)num15 != 0.5)
				{
					double d = (double)num15 + 0.5;
					num16 = Math.Floor(d);
					if (setter != null)
					{
						goto IL_0233;
					}
					goto IL_0331;
				}
				num17 = 1.0;
				num16 = num18;
			}
			double num19 = num16 + num17;
			if ((num16 & 1) != 0)
			{
				num16 = num19;
			}
			goto IL_0233;
			IL_0331:
			throw new NullReferenceException();
			IL_0233:
			uint pNewValue;
			if ((options & 0xFF) != 0)
			{
				double num20 = (double)(int)num - num16;
				pNewValue = (uint)(int)num20;
			}
			else
			{
				double num21 = (double)(int)num + num16;
				pNewValue = (uint)(int)num21;
			}
			setter(pNewValue);
		}

		[Token(Token = "0x60001ED")]
		[Address(RVA = "0x10DDA80", Offset = "0x10DDA80", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EE2538]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20274D8]) = v38;\nL_001C:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<System.UInt32, System.UInt32, DG.Tweening.Plugins.Options.UintOptions>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public UintPlugin()
		{
		}
	}
}
