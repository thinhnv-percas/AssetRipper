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
	[Token(Token = "0x200007C")]
	public class IntPlugin : ABSTweenPlugin<int, int, NoOptions>
	{
		[Token(Token = "0x6000307")]
		[Address(RVA = "0xC20FB4", Offset = "0xC20FB4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset(TweenerCore<int, int, NoOptions> t)
		{
		}

		[Token(Token = "0x6000308")]
		[Address(RVA = "0xC20FB8", Offset = "0xC20FB8", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Int32, System.Int32, DG.Tweening.Plugins.Options.NoOptions>)+138]);\n\t*([v10 @ X8_v2+18])(v39, *([v10 @ X8_v2+40]), *([v10 @ X8_v2+28]), isRelative, methodInfo, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv46 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Int32, System.Int32, DG.Tweening.Plugins.Options.NoOptions>)+140]);\n\tv27 = isRelative == 0;\n\tv18 = ~v27;\n\tv15 = ~v18;\n\tif (v15) goto L_FFFFFFFF;\n\tgoto L_001E;\nL_001E:\n\tv36 = v42 + t.endValue;\n\tt.endValue.m_value = v39;\n\tt.startValue.m_value = v36;\n\tv75 = *([v46 @ X8_v3+18]);\n\tv88 = *([v46 @ X8_v3+40]);\n\tv73 = *([v46 @ X8_v3+28]);\n\t// 43 IndirectJump v75 @ X3_v1, v88 @ X0_v5, v88 @ X0_v5, v36 @ X1_v3 (System.Int32), v73 @ X2_v1, v75 @ X3_v1, v52 @ X4, v53 @ X5, v54 @ X6, v55 @ X7, v56 @ V0, v57 @ V1, v58 @ V2, v59 @ V3, v60 @ V4, v61 @ V5, v62 @ V6, v63 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<int, int, NoOptions> t, bool isRelative)
		{
			//IL_0010: Expected O, but got I
			//IL_002f: Expected O, but got I
			//IL_008d: Expected O, but got I
			//IL_009d: Expected O, but got I
			//IL_00ad: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Int32, System.Int32, DG.Tweening.Plugins.Options.NoOptions>)+138]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v10 @ X8_v2+18] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Int32, System.Int32, DG.Tweening.Plugins.Options.NoOptions>)+140]");
			object obj2 = 0;
			int num2 = default(int);
			int num = (isRelative ? num2 : 0);
			while (true)
			{
				int value = num + t.endValue;
				t.endValue.m_value = num2;
				t.startValue.m_value = value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v3+18]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v3+40]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v3+28]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v75 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000309")]
		[Address(RVA = "0xC21020", Offset = "0xC21020", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = isRelative == 0;\n\tif (v16) goto L_FFFFFFFF;\n\tv19 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Int32, System.Int32, DG.Tweening.Plugins.Options.NoOptions>)+138]);\n\t*([v19 @ X8_v4+18])(v49, *([v19 @ X8_v4+40]), *([v19 @ X8_v4+28]), fromValue, setImmediately, isRelative, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv35 = v49 + fromValue;\n\tv52 = t.endValue + v49;\n\tt.endValue.m_value = v52;\n\tgoto L_001B;\nL_001B:\n\tt.startValue.m_value = v35;\n\tv56 = setImmediately == 0;\n\tif (v56) goto L_0031;\n\tv31 = *([t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Int32, System.Int32, DG.Tweening.Plugins.Options.NoOptions>)+140]);\n\tv68 = *([v31 @ X8_v3+18]);\n\tv72 = *([v31 @ X8_v3+40]);\n\tv66 = *([v31 @ X8_v3+28]);\n\t// 43 IndirectJump v68 @ X3_v1, v72 @ X0_v4, v72 @ X0_v4, v35 @ X19_v3 (System.Int32), v66 @ X2_v1, v68 @ X3_v1, isRelative @ X4 (System.Boolean), methodInfo @ X5 (Il2CppMethodInfo), v38 @ X6, v39 @ X7, v40 @ V0, v41 @ V1, v42 @ V2, v43 @ V3, v44 @ V4, v45 @ V5, v46 @ V6, v47 @ V7\nL_0031:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetFrom(TweenerCore<int, int, NoOptions> t, int fromValue, bool setImmediately, bool isRelative)
		{
			//IL_002d: Expected O, but got I
			//IL_00c0: Expected O, but got I
			//IL_00d5: Expected O, but got I
			//IL_00e5: Expected O, but got I
			//IL_00f5: Expected O, but got I
			int value;
			if (isRelative)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Int32, System.Int32, DG.Tweening.Plugins.Options.NoOptions>)+138]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v19 @ X8_v4+18] (should have been resolved before IL gen)");
				object obj2 = default(object);
				value = (int)((nint)obj2 + fromValue);
				int value2 = (int)(t.endValue + (nint)obj2);
				t.endValue.m_value = value2;
			}
			else
			{
				value = fromValue;
			}
			t.startValue.m_value = value;
			if (setImmediately)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X1 (DG.Tweening.Core.TweenerCore`3<System.Int32, System.Int32, DG.Tweening.Plugins.Options.NoOptions>)+140]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ X8_v3+18]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ X8_v3+40]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ X8_v3+28]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v68 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600030A")]
		[Address(RVA = "0xC210A8", Offset = "0xC210A8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override int ConvertToStartValue(TweenerCore<int, int, NoOptions> t, int value)
		{
			return value;
		}

		[Token(Token = "0x600030B")]
		[Address(RVA = "0xC210B0", Offset = "0xC210B0", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = t.startValue + t.endValue;\n\tt.endValue.m_value = v6;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetRelativeEndValue(TweenerCore<int, int, NoOptions> t)
		{
			int value = t.startValue + t.endValue;
			t.endValue.m_value = value;
		}

		[Token(Token = "0x600030C")]
		[Address(RVA = "0xC210D4", Offset = "0xC210D4", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = t.endValue - t.startValue;\n\tt.changeValue.m_value = v6;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetChangeValue(TweenerCore<int, int, NoOptions> t)
		{
			int value = t.endValue - t.startValue;
			t.changeValue.m_value = value;
		}

		[Token(Token = "0x600030D")]
		[Address(RVA = "0xC210F8", Offset = "0xC210F8", Length = "0x18")]
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

		[Token(Token = "0x600030E")]
		[Address(RVA = "0xC21110", Offset = "0xC21110", Length = "0x1B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv34 = System.Math;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, options, t, isRelative, getter, setter, startValue, changeValue, elapsed, duration, v39, v40, v41, v42, v43, v44);\n\tv48 = 1;\n\t*([1A3576E]) = v48;\nL_0026:\n\tv60 = t.loopType != 2;\n\tif (v60) goto L_002F;\n\tv134 = t.completedLoops - t.isComplete;\n\tv135 = v134 * changeValue;\n\tv125 = startValue + v135;\nL_002F:\n\tv140 = ~t.isSequenced;\n\tif (v140) goto L_005E;\n\tv84 = t.sequenceParent;\n\tv146 = v84.loopType != 2;\n\tif (v146) goto L_005E;\n\tv145 = t.loopType != 2;\n\tif (v145) goto L_FFFFFFFF;\n\tv262 = t.loops;\n\tgoto L_0050;\nL_0050:\n\tv175 = v262 * changeValue;\n\tv143 = v84.completedLoops - v84.isComplete;\n\tv172 = v175 * v143;\n\tv125 = v125 + v172;\nL_005E:\n\tv180 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, elapsed, duration, t.easeOvershootOrAmplitude, t.easePeriod);\n\tgoto L_0068;\n\tv243 = \"il2cpp_codegen_runtime_class_init\"(v237, v66, v71, isRelative, getter, setter, startValue, changeValue, v180, v179, v64, v62, v41, v42, v43, v44);\nL_0068:\n\tv247 = v180 * changeValue;\n\tv122 = v247 + v125;\n\tv115 = 0x1854ED0(&v74 @ stack_-48_v2 (System.Double), t.customEase, 0, isRelative, getter, setter, startValue, changeValue, v122, v247, t.easeOvershootOrAmplitude, t.easePeriod, v41, v42, v43, v44);\n\tv261 = v122 >= 0;\n\tif (v261) goto L_0092;\n\tv275 = v122 != -0.5d;\n\tif (v275) goto L_00A4;\n\tgoto L_0097;\nL_0092:\n\tv286 = v122 != 0.5d;\n\tif (v286) goto L_00A7;\nL_0097:\n\tv307 = v76 + v296;\n\tv308 = v76 & 1;\n\tv310 = v308 == 0;\n\tv313 = ~v310;\n\tif (v313) goto L_FFFFFFFF;\n\tgoto L_00A3;\nL_00A3:\n\tgoto L_00C3;\nL_00A4:\n\tv289 = v122 + -0.5d;\n\tv76 = System.Math::Ceiling(v289);\n\tgoto L_00C3;\nL_00A7:\n\tv293 = v122 + 0.5d;\n\tv76 = System.Math::Floor(v293);\nL_00C3:\n\tv186 = v76 != 0x7FF0000000000000;\n\tif (v186) goto L_FFFFFFFF;\n\tgoto L_00CA;\nL_00CA:\n\tDG.Tweening.Core.DOSetter`1<System.Int32>::Invoke(setter, v184);\n\tthrow System.NullReferenceException;\n\treturn;\n// 151 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void EvaluateAndApply(NoOptions options, Tween t, bool isRelative, DOGetter<int> getter, DOSetter<int> setter, float elapsed, int startValue, int changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice)
		{
			//IL_030b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0310: Expected I4, but got Unknown
			//IL_034a: Expected I4, but got F8
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
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
			double num11;
			double num12 = default(double);
			double num13;
			if (num10 < 0f)
			{
				if ((double)num10 != -0.5)
				{
					double a = (double)num10 + -0.5;
					num11 = Math.Ceiling(a);
					goto IL_0213;
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
					goto IL_0213;
				}
				num11 = num12;
				num13 = 1.0;
			}
			double num14 = num11 + num13;
			if ((num11 & 1) != 0)
			{
				num11 = num14;
			}
			goto IL_0213;
			IL_0213:
			double num15 = ((num11 != 9.218868437227405E+18) ? num11 : 1.0609978955E-314);
			setter((int)num15);
		}

		[Token(Token = "0x600030F")]
		[Address(RVA = "0xC212C0", Offset = "0xC212C0", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A3576F]) = v37;\nL_001A:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<System.Int32, System.Int32, DG.Tweening.Plugins.Options.NoOptions>::.ctor(this);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IntPlugin()
		{
		}
	}
}
