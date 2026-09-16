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
	[Token(Token = "0x2000080")]
	public class UintPlugin : ABSTweenPlugin<uint, uint, UintOptions>
	{
		[Token(Token = "0x600032E")]
		[Address(RVA = "0xC23DE0", Offset = "0xC23DE0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset(TweenerCore<uint, uint, UintOptions> t)
		{
		}

		[Token(Token = "0x600032F")]
		[Address(RVA = "0xC23DE4", Offset = "0xC23DE4", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv39 = DG.Tweening.Core.DOGetter`1<System.UInt32>::Invoke(t.getter);\n\tv27 = isRelative == 0;\n\tv18 = ~v27;\n\tv15 = ~v18;\n\tif (v15) goto L_FFFFFFFF;\n\tgoto L_001E;\nL_001E:\n\tv36 = v42 + t.endValue;\n\tt.endValue = v39;\n\tt.startValue = v36;\n\tDG.Tweening.Core.DOSetter`1<System.UInt32>::Invoke(t.setter, v36);\n\tthrow System.NullReferenceException;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<uint, uint, UintOptions> t, bool isRelative)
		{
			uint num = t.getter();
			uint num2 = (isRelative ? num : 0u);
			uint num3 = num2 + t.endValue;
			t.endValue = num;
			t.startValue = num3;
			t.setter(num3);
		}

		[Token(Token = "0x6000330")]
		[Address(RVA = "0xC23E4C", Offset = "0xC23E4C", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = isRelative == 0;\n\tif (v16) goto L_FFFFFFFF;\n\tv49 = DG.Tweening.Core.DOGetter`1<System.UInt32>::Invoke(t.getter);\n\tv35 = v49 + fromValue;\n\tv52 = t.endValue + v49;\n\tt.endValue = v52;\n\tgoto L_001B;\nL_001B:\n\tt.startValue = v35;\n\tv56 = setImmediately == 0;\n\tif (v56) goto L_0031;\n\tDG.Tweening.Core.DOSetter`1<System.UInt32>::Invoke(t.setter, v35);\nL_0031:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<uint, uint, UintOptions> t, uint fromValue, bool setImmediately, bool isRelative)
		{
			//IL_0035: Expected O, but got I4
			uint num;
			if (isRelative)
			{
				object obj = t.getter();
				num = (uint)((nint)obj + (int)fromValue);
				uint endValue = (uint)((int)t.endValue + (nint)obj);
				t.endValue = endValue;
			}
			else
			{
				num = fromValue;
			}
			t.startValue = num;
			if (setImmediately)
			{
				t.setter(num);
			}
		}

		[Token(Token = "0x6000331")]
		[Address(RVA = "0xC23ED4", Offset = "0xC23ED4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override uint ConvertToStartValue(TweenerCore<uint, uint, UintOptions> t, uint value)
		{
			return value;
		}

		[Token(Token = "0x6000332")]
		[Address(RVA = "0xC23EDC", Offset = "0xC23EDC", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = t.startValue + t.endValue;\n\tt.endValue = v6;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetRelativeEndValue(TweenerCore<uint, uint, UintOptions> t)
		{
			int endValue = (int)(t.startValue + t.endValue);
			t.endValue = (uint)endValue;
		}

		[Token(Token = "0x6000333")]
		[Address(RVA = "0xC23F00", Offset = "0xC23F00", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = t.startValue - t.endValue;\n\tv7 = t.endValue < t.startValue;\n\tv8 = ~v7;\n\tv39 = t.endValue - t.startValue;\n\tv17 = ~v8;\n\tv19 = ~v8;\n\tv20 = ~v19;\n\tif (v20) goto L_001A;\n\tgoto L_001A;\nL_001A:\n\tt.plugOptions = v17;\n\tt.changeValue = v39;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000334")]
		[Address(RVA = "0xC23F34", Offset = "0xC23F34", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = changeValue / unitsXSecond;\n\tv4 = -returnVal1;\n\tv14 = returnVal1 >= 0;\n\tif (v14) goto L_0012;\n\tgoto L_0012;\nL_0012:\n\treturn returnVal1;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000335")]
		[Address(RVA = "0xC23F4C", Offset = "0xC23F4C", Length = "0x1E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv38 = System.Math;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, options, t, isRelative, getter, setter, startValue, changeValue, elapsed, duration, v42, v43, v44, v45, v46, v47);\n\tv51 = 1;\n\t*([1A3577D]) = v51;\nL_0028:\n\tv63 = t.loopType != 2;\n\tif (v63) goto L_0037;\n\tv137 = t.completedLoops - t.isComplete;\n\tv138 = v137 * changeValue;\n\tv139 = options & 1;\n\tv140 = v139 == 0;\n\tv141 = ~v140;\n\tif (v141) goto L_0035;\n\tv145 = v138 + startValue;\n\tgoto L_0037;\nL_0035:\n\tv144 = startValue - v138;\nL_0037:\n\tv147 = ~t.isSequenced;\n\tif (v147) goto L_006C;\n\tv87 = t.sequenceParent;\n\tv154 = v87.loopType != 2;\n\tif (v154) goto L_006C;\n\tv153 = t.loopType != 2;\n\tif (v153) goto L_FFFFFFFF;\n\tv260 = t.loops;\n\tgoto L_0058;\nL_0058:\n\tv263 = v260 * changeValue;\n\tv151 = v87.completedLoops - v87.isComplete;\n\tv184 = v263 * v151;\n\tv264 = options & 1;\n\tv265 = v264 == 0;\n\tv180 = ~v265;\n\tif (v180) goto L_0062;\n\tv182 = v184 + v128;\n\tgoto L_006C;\nL_0062:\n\tv181 = v128 - v184;\nL_006C:\n\tv189 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);\n\tgoto L_0075;\n\tv243 = \"il2cpp_codegen_runtime_class_init\"(v237, v69, v71, isRelative, getter, setter, startValue, changeValue, v189, v188, v67, v65, v44, v45, v46, v47);\nL_0075:\n\tv125 = v189 * changeValue;\n\tv118 = 0x1854ED0(&v79 @ stack_-38_v2 (System.Double), t.customEase, 0, isRelative, getter, setter, startValue, changeValue, v125, duration, t.easeOvershootOrAmplitude, t.easePeriod, v44, v45, v46, v47);\n\tv259 = v125 >= 0;\n\tif (v259) goto L_009E;\n\tv276 = v125 != -0.5d;\n\tif (v276) goto L_00B0;\n\tgoto L_00A3;\nL_009E:\n\tv287 = v125 != 0.5d;\n\tif (v287) goto L_00B3;\nL_00A3:\n\tv76 = v81 + v296;\n\tv309 = v81 & 1;\n\tv311 = v309 == 0;\n\tv314 = ~v311;\n\tif (v314) goto L_FFFFFFFF;\n\tgoto L_00AF;\nL_00AF:\n\tgoto L_00C0;\nL_00B0:\n\tv290 = v125 + -0.5d;\n\tv81 = System.Math::Ceiling(v290);\n\tgoto L_00C0;\nL_00B3:\n\tv294 = v125 + 0.5d;\n\tv81 = System.Math::Floor(v294);\nL_00C0:\n\tv74 = v81 >= 0;\n\tif (v74) goto L_FFFFFFFF;\n\tgoto L_00C8;\nL_00C8:\n\tv333 = options & 1;\n\tv334 = v333 == 0;\n\tv218 = ~v334;\n\tif (v218) goto L_00D1;\n\tv199 = setter.invoke_impl;\n\tv216 = setter.method_code;\n\tv197 = setter.method;\n\tv195 = v132 + v128;\n\tgoto L_00DF;\nL_00D1:\n\tv199 = setter.invoke_impl;\n\tv216 = setter.method_code;\n\tv197 = setter.method;\n\tv195 = v128 - v132;\nL_00DF:\n\t// 223 IndirectJump v199 @ X3_v1 (System.IntPtr), v216 @ X0_v9 (System.IntPtr), v216 @ X0_v9 (System.IntPtr), v195 @ X1_v3 (System.Double), v197 @ X2_v3 (System.IntPtr), v199 @ X3_v1 (System.IntPtr), getter @ X4 (DG.Tweening.Core.DOGetter`1<System.UInt32>), setter @ X5 (DG.Tweening.Core.DOSetter`1<System.UInt32>), startValue @ X6 (System.UInt32), changeValue @ X7 (System.UInt32), v81 @ V0_v10 (System.Double), v76 @ V1_v5 (System.Double), t.easeOvershootOrAmplitude (System.Single), t.easePeriod (System.Single), v44 @ V4, v45 @ V5, v46 @ V6, v47 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 148 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void EvaluateAndApply(UintOptions options, Tween t, bool isRelative, DOGetter<uint> getter, DOSetter<uint> setter, float elapsed, uint startValue, uint changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice)
		{
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Expected I4, but got Unknown
			//IL_0469: Unknown result type (might be due to invalid IL or missing references)
			//IL_046e: Expected I4, but got Unknown
			//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f2: Expected I4, but got Unknown
			//IL_0424: Unknown result type (might be due to invalid IL or missing references)
			//IL_0429: Expected I4, but got Unknown
			bool flag = t.loopType != LoopType.Incremental;
			uint num = startValue;
			if (!flag)
			{
				int num2 = t.completedLoops - (t.isComplete ? 1 : 0);
				int num3 = num2 * (int)changeValue;
				if ((options & 1) == 0)
				{
					int num4 = num3 + (int)startValue;
					num = (uint)num4;
				}
				else
				{
					int num5 = (int)startValue - num3;
					num = (uint)num5;
				}
			}
			if (t.isSequenced)
			{
				Sequence sequenceParent = t.sequenceParent;
				if (sequenceParent.loopType == LoopType.Incremental)
				{
					int num6 = ((t.loopType != LoopType.Incremental) ? 1 : t.loops);
					int num7 = num6 * (int)changeValue;
					int num8 = sequenceParent.completedLoops - (sequenceParent.isComplete ? 1 : 0);
					int num9 = num7 * num8;
					if ((options & 1) == 0)
					{
						int num10 = num9 + (int)num;
						num = (uint)num10;
					}
					else
					{
						int num11 = (int)num - num9;
						num = (uint)num11;
					}
				}
			}
			float num12 = EaseManager.Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);
			float num13 = num12 * (float)(int)changeValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854ED0 (native modf)");
			double num14;
			double num16;
			double num17 = default(double);
			double num15;
			if (num13 < 0f)
			{
				if ((double)num13 != -0.5)
				{
					double a = (double)num13 + -0.5;
					num14 = Math.Ceiling(a);
					num15 = -0.5;
					goto IL_02a4;
				}
				num16 = -1.0;
				num14 = num17;
			}
			else
			{
				if ((double)num13 != 0.5)
				{
					double d = (double)num13 + 0.5;
					num14 = Math.Floor(d);
					num15 = 0.5;
					goto IL_02a4;
				}
				num16 = 1.0;
				num14 = num17;
			}
			num15 = num14 + num16;
			if ((num14 & 1) != 0)
			{
				num14 = num15;
			}
			goto IL_02a4;
			IL_02a4:
			double num18 = ((!(num14 < 0.0)) ? num14 : num14);
			if ((options & 1) == 0)
			{
				IntPtr invoke_impl = setter.invoke_impl;
				IntPtr method_code = setter.method_code;
				IntPtr method = setter.method;
				double num19 = num18 + (double)(int)num;
			}
			else
			{
				IntPtr invoke_impl = setter.invoke_impl;
				IntPtr method_code = setter.method_code;
				IntPtr method = setter.method;
				double num19 = (double)(int)num - num18;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v199 @ X3_v1 (System.IntPtr) (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000336")]
		[Address(RVA = "0xC2412C", Offset = "0xC2412C", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A3577E]) = v37;\nL_001A:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<System.UInt32, System.UInt32, DG.Tweening.Plugins.Options.UintOptions>::.ctor(this);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public UintPlugin()
		{
		}
	}
}
