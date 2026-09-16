using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening.Plugins
{
	[Token(Token = "0x200007B")]
	public class ColorPlugin : ABSTweenPlugin<Color, Color, ColorOptions>
	{
		[Token(Token = "0x60002FE")]
		[Address(RVA = "0xC20B8C", Offset = "0xC20B8C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset(TweenerCore<Color, Color, ColorOptions> t)
		{
		}

		[Token(Token = "0x60002FF")]
		[Address(RVA = "0xC20B90", Offset = "0xC20B90", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv29 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+13C]);\n\tv27 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+140]);\n\tv34 = DG.Tweening.Core.DOGetter`1<UnityEngine.Color>::Invoke(t.getter);\n\tt.endValue = v53;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+138]) = v54;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+13C]) = v55;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+140]) = v56;\n\tv66 = isRelative == 0;\n\tif (v66) goto L_0022;\n\tv29 = v29 + v55;\n\tv25 = t.endValue + v53;\n\tv27 = v27 + v56;\nL_0022:\n\tt.startValue = v25;\n\tv43 = t.setter;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+12C]) = v29;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+130]) = v27;\n\tv147 = t.plugOptions != 0;\n\tif (v147) goto L_FFFFFFFF;\n\tgoto L_003D;\nL_003D:\n\tv151 = t.plugOptions != 0;\n\tif (v151) goto L_FFFFFFFF;\n\tgoto L_0044;\nL_0044:\n\tv85 = t.plugOptions != 0;\n\tif (v85) goto L_FFFFFFFF;\n\tgoto L_0059;\nL_0059:\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::Invoke(t.setter, v43.method);\n\tthrow System.NullReferenceException;\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<Color, Color, ColorOptions> t, bool isRelative)
		{
			//IL_0016: Expected O, but got I
			//IL_0026: Expected O, but got I
			//IL_011a: Expected O, but got F4
			//IL_0092: Expected O, but got I
			//IL_00bf: Expected O, but got I
			//IL_0197: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+13C]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+140]");
			object obj2 = 0;
			object obj3 = t.getter();
			Color endValue = default(Color);
			t.endValue = endValue;
			bool flag = !isRelative;
			float num = t.endValue.r;
			if (!flag)
			{
				object obj4 = default(object);
				obj = (nint)obj + (nint)obj4;
				num = t.endValue.r + endValue.r;
				object obj5 = default(object);
				obj2 = (nint)obj2 + (nint)obj5;
			}
			t.startValue = (Color)num;
			DOSetter<Color> setter = t.setter;
			if ((object)t.plugOptions == null)
			{
			}
			if ((object)t.plugOptions == null)
			{
			}
			if ((object)t.plugOptions == null)
			{
			}
			t.setter((Color)(nint)setter.method);
		}

		[Token(Token = "0x6000300")]
		[Address(RVA = "0xC20C6C", Offset = "0xC20C6C", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = isRelative == 0;\n\tif (v28) goto L_FFFFFFFF;\n\tv90 = DG.Tweening.Core.DOGetter`1<UnityEngine.Color>::Invoke(t.getter);\n\tv95 = v34 + v34;\n\tv84 = t.endValue + v34;\n\tv70 = v34.g + v34.g;\n\tv73 = v34.b + v34.b;\n\tt.endValue = v84;\n\tv75 = v34.a + v34.a;\n\tgoto L_002B;\nL_002B:\n\tt.startValue = v67;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+128]) = v70;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+12C]) = v73;\n\t*([t @ X1 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+130]) = v75;\n\tv100 = setImmediately == 0;\n\tif (v100) goto L_005A;\n\tv106 = t.plugOptions == 0;\n\tif (v106) goto L_003F;\n\tv150 = DG.Tweening.Core.DOGetter`1<UnityEngine.Color>::Invoke(t.getter);\nL_003F:\n\tv61 = t.setter;\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::Invoke(t.setter, v61.method);\nL_005A:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<Color, Color, ColorOptions> t, Color fromValue, bool setImmediately, bool isRelative)
		{
			//IL_00ab: Expected O, but got F4
			//IL_00cc: Expected O, but got F4
			//IL_01b6: Expected O, but got I
			//IL_0180: Expected O, but got F4
			Color color = default(Color);
			float num2 = default(float);
			Color startValue;
			if (isRelative)
			{
				object obj = t.getter();
				float num = color.r + color.r;
				num2 = t.endValue.r + color.r;
				float num3 = color.g + color.g;
				float num4 = color.b + color.b;
				t.endValue = (Color)num2;
				float num5 = color.a + color.a;
				startValue = (Color)num;
			}
			else
			{
				startValue = color;
				float num3 = color.g;
				float num4 = color.b;
				float num5 = color.a;
			}
			t.startValue = startValue;
			if (setImmediately)
			{
				if ((object)t.plugOptions != null)
				{
					object obj2 = t.getter();
					startValue = (Color)num2;
					float num3 = color.g;
					float num4 = color.b;
				}
				DOSetter<Color> setter = t.setter;
				t.setter((Color)(nint)setter.method);
			}
		}

		[Token(Token = "0x6000301")]
		[Address(RVA = "0xC20D78", Offset = "0xC20D78", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Color ConvertToStartValue(TweenerCore<Color, Color, ColorOptions> t, Color value)
		{
			return value;
		}

		[Token(Token = "0x6000302")]
		[Address(RVA = "0xC20D7C", Offset = "0xC20D7C", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = t.endValue + t.startValue;\n\tt.endValue = v7;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetRelativeEndValue(TweenerCore<Color, Color, ColorOptions> t)
		{
			//IL_0030: Expected O, but got F4
			float num = t.endValue.r + t.startValue.r;
			t.endValue = (Color)num;
		}

		[Token(Token = "0x6000303")]
		[Address(RVA = "0xC20DA0", Offset = "0xC20DA0", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = t.endValue - t.startValue;\n\tt.changeValue = v7;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetChangeValue(TweenerCore<Color, Color, ColorOptions> t)
		{
			//IL_0030: Expected O, but got F4
			float num = t.endValue.r - t.startValue.r;
			t.changeValue = (Color)num;
		}

		[Token(Token = "0x6000304")]
		[Address(RVA = "0xC20DC4", Offset = "0xC20DC4", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = 1f / unitsXSecond;\n\treturn returnVal1;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float GetSpeedBasedDuration(ColorOptions options, float unitsXSecond, Color changeValue)
		{
			return 1f / unitsXSecond;
		}

		[Token(Token = "0x6000305")]
		[Address(RVA = "0xC20DD0", Offset = "0xC20DD0", Length = "0x19C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv51 = t.loopType != 2;\n\tif (v51) goto L_0036;\n\tv166 = t.completedLoops - t.isComplete;\n\tv168 = changeValue * v50;\n\tv169 = updateNotice * v166;\n\tv170 = v31 * v166;\n\tv131 = startValue + v168;\n\tv127 = startValue.b + v169;\n\tv138 = startValue.a + v170;\nL_0036:\n\tv178 = ~t.isSequenced;\n\tif (v178) goto L_006B;\n\tv91 = t.sequenceParent;\n\tv184 = v91.loopType != 2;\n\tif (v184) goto L_006B;\n\tv183 = t.loopType != 2;\n\tif (v183) goto L_005A;\n\tv277 = t.loops;\nL_005A:\n\tv204 = v91.completedLoops - v91.isComplete;\n\tv283 = updateNotice * v277;\n\tv54 = v31 * v277;\n\tv284 = changeValue * v50;\n\tv210 = v284 * v286;\n\tv266 = v283 * v204;\n\tv208 = v54 * v204;\n\tv131 = v131 + v210;\n\tv127 = v127 + v266;\n\tv138 = v138 + v208;\nL_006B:\n\tv220 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, elapsed, methodInfo, t.easeOvershootOrAmplitude, t.easePeriod);\n\tv272 = options & 1;\n\tv273 = v272 == 0;\n\tv274 = ~v273;\n\tif (v274) goto L_0087;\n\tv289 = updateNotice * v220;\n\tv229 = setter.invoke_impl;\n\tv227 = setter.method_code;\n\tv270 = v127 + v289;\n\tv222 = setter.method;\n\tv296 = v31 * v220;\n\tv297 = changeValue * v298;\n\tv220 = v131 + v297;\n\tv268 = v138 + v296;\n\tgoto L_0099;\nL_0087:\n\tv77 = DG.Tweening.Core.DOGetter`1<UnityEngine.Color>::Invoke(getter);\n\tv229 = setter.invoke_impl;\n\tv227 = setter.method_code;\n\tv222 = setter.method;\n\tv309 = v31 * v220;\n\tv268 = v138 + v309;\nL_0099:\n\t// 153 IndirectJump v229 @ X2_v3 (System.IntPtr), v227 @ X0_v4 (System.IntPtr), v227 @ X0_v4 (System.IntPtr), v222 @ X1_v3 (System.IntPtr), v229 @ X2_v3 (System.IntPtr), isRelative @ X3 (System.Boolean), getter @ X4 (DG.Tweening.Core.DOGetter`1<UnityEngine.Color>), setter @ X5 (DG.Tweening.Core.DOSetter`1<UnityEngine.Color>), usingInversePosition @ X6 (System.Boolean), newCompletedSteps @ X7 (System.Int32), v220 @ V0_v3 (System.Single), v232 @ V1_v4 (System.Single), v270 @ V2_v6 (System.Single), v268 @ V3_v6 (System.Single), v266 @ V4_v5 (UnityEngine.Color), v54 @ V5_v2 (System.Single), v131 @ V6_v4 (System.Single), v27 @ stack_4\n\tthrow System.NullReferenceException;\n\treturn;\n// 105 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void EvaluateAndApply(ColorOptions options, Tween t, bool isRelative, DOGetter<Color> getter, DOSetter<Color> setter, float elapsed, Color startValue, Color changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice)
		{
			//IL_0291: Expected F4, but got I
			//IL_029e: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a3: Expected I4, but got Unknown
			//IL_0092: Expected O, but got I
			//IL_0133: Expected I4, but got F4
			//IL_02ef: Expected O, but got I4
			//IL_0330: Expected O, but got I
			bool flag = t.loopType != LoopType.Incremental;
			float num = startValue.b;
			Color color = default(Color);
			float num2 = color.r;
			float num3 = startValue.a;
			Color color2 = default(Color);
			object obj = default(object);
			object obj3 = default(object);
			if (!flag)
			{
				int num4 = t.completedLoops - (t.isComplete ? 1 : 0);
				float num5 = color2.r * (float)obj;
				int num6 = (int)updateNotice * num4;
				object obj2 = (nint)obj3 * num4;
				num2 = color.r + num5;
				num = startValue.b + (float)num6;
				num3 = startValue.a + (float)obj2;
			}
			bool flag2 = !t.isSequenced;
			Color color3 = changeValue;
			if (!flag2)
			{
				Sequence sequenceParent = t.sequenceParent;
				bool flag3 = sequenceParent.loopType != LoopType.Incremental;
				color3 = changeValue;
				if (!flag3)
				{
					bool flag4 = t.loopType != LoopType.Incremental;
					int num7 = 1;
					if (!flag4)
					{
						num7 = t.loops;
					}
					int num8 = sequenceParent.completedLoops - (sequenceParent.isComplete ? 1 : 0);
					object obj4 = (int)updateNotice * num7;
					float num9 = (float)obj3 * (float)num7;
					float num10 = color2.r * (float)obj;
					object obj5 = default(object);
					float num11 = num10 * (float)obj5;
					color3 = (Color)((nint)obj4 * num8);
					float num12 = num9 * (float)num8;
					num2 += num11;
					num += color3.r;
					num3 += num12;
				}
			}
			IntPtr intPtr = default(IntPtr);
			float num13 = EaseManager.Evaluate(t.easeType, t.customEase, elapsed, (nint)intPtr, t.easeOvershootOrAmplitude, t.easePeriod);
			if ((options & 1) == 0)
			{
				float num14 = (float)updateNotice * num13;
				IntPtr invoke_impl = setter.invoke_impl;
				IntPtr method_code = setter.method_code;
				float num15 = num + num14;
				IntPtr method = setter.method;
				float num16 = (float)obj3 * num13;
				object obj6 = default(object);
				float num17 = color2.r * (float)obj6;
				num13 = num2 + num17;
				float num18 = num3 + num16;
			}
			else
			{
				object obj7 = getter();
				IntPtr invoke_impl = setter.invoke_impl;
				IntPtr method_code = setter.method_code;
				IntPtr method = setter.method;
				float num19 = (float)obj3 * num13;
				float num18 = num3 + num19;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v229 @ X2_v3 (System.IntPtr) (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000306")]
		[Address(RVA = "0xC20F6C", Offset = "0xC20F6C", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A3576D]) = v37;\nL_001A:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>::.ctor(this);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ColorPlugin()
		{
		}
	}
}
