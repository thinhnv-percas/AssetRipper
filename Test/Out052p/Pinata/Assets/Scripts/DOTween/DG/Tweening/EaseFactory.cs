using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core.Easing;
using UnityEngine;

namespace DG.Tweening
{
	[Token(Token = "0x200000B")]
	public class EaseFactory
	{
		[CompilerGenerated]
		[Token(Token = "0x2000064")]
		private sealed class _003C_003Ec__DisplayClass2_0
		{
			[Token(Token = "0x40001C1")]
			[FieldOffset(Offset = "0x10")]
			public float motionDelay;

			[Token(Token = "0x40001C2")]
			[FieldOffset(Offset = "0x18")]
			public EaseFunction customEase;

			[Token(Token = "0x6000301")]
			[Address(RVA = "0x107F1B0", Offset = "0x107F1B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec__DisplayClass2_0()
			{
			}

			internal float _003CStopMotion_003Eb__0(float time, float duration, float overshootOrAmplitude, float period)
			{
				//IL_0038: Expected O, but got F4
				bool flag = !(time < duration);
				float time2 = time;
				if (!flag)
				{
					object obj = time % motionDelay;
					time2 = time - time;
				}
				return customEase(time2, duration, overshootOrAmplitude, period);
			}
		}

		[Token(Token = "0x6000064")]
		[Address(RVA = "0x107EFB4", Offset = "0x107EFB4", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv23 = *([1F0F398]);\n\tv24 = *([v23 @ X8_v12]);\n\tv25 = \"il2cpp_codegen_initialize_method\"(v24, ease, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2026A38]) = v42;\nL_0016:\n\tv43 = ease & 0xFF00000000;\n\tv44 = v43 == 0;\n\tif (v44) goto L_0026;\n\treturnVal1 = 0x1084DFC(&ease @ X1 (System.Nullable`1<DG.Tweening.Ease>), ease, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\treturn returnVal1;\n\tX0 = 0x115C1C4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_002F;\nL_0026:\n\tgoto L_002F;\n\tv55 = *([v51 @ X0_v2 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\t// 42 ConditionalJump @b17, v57 @ TEMP_v9\n\tv80 = \"il2cpp_codegen_runtime_class_init\"(v51, ease, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv59 = DG.Tweening.DOTween;\nL_002F:\n\tv81 = DG.Tweening.Core.Easing.EaseManager::ToEaseFunction(v62.defaultEaseType);\n\treturnVal2 = DG.Tweening.EaseFactory::StopMotion(motionFps, v81);\n\treturn returnVal2;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static EaseFunction StopMotion(int motionFps, Ease? ease = null)
		{
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected I4, but got Unknown
			if ((int)((_003F?)ease & 0xFF00000000L) != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1084DFC (inside DG.Tweening.Plugins.LongPlugin::.ctor +0x1D8)");
				EaseFunction result = default(EaseFunction);
				return result;
			}
			EaseFunction customEase = EaseManager.ToEaseFunction(DOTween.defaultEaseType);
			return StopMotion(motionFps, customEase);
		}

		[Token(Token = "0x6000065")]
		[Address(RVA = "0x107F110", Offset = "0x107F110", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1F0E388]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, animCurve, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2026A39]) = v41;\nL_0018:\n\tv45 = new DG.Tweening.Core.Easing.EaseCurve();\n\tSystem.Object::.ctor(v45);\n\tv45._animCurve = animCurve;\n\tv51 = new DG.Tweening.EaseFunction();\n\tv57 = Il2CppMethodInfo;\n\tv51.m_target = v45;\n\tv51.method = Il2CppMethodInfo;\n\tv51.method_ptr = *([v57 @ X9_v3 (Il2CppMethodInfo)]);\n\treturnVal1 = DG.Tweening.EaseFactory::StopMotion(motionFps, v51);\n\treturn returnVal1;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static EaseFunction StopMotion(int motionFps, AnimationCurve animCurve)
		{
			EaseCurve easeCurve = null;
			easeCurve._animCurve = animCurve;
			EaseFunction easeFunction = null;
			IntPtr method_ptr = (IntPtr)0;
			((Delegate)easeFunction).m_target = easeCurve;
			((Delegate)easeFunction).method = (IntPtr)__ldftn(EaseCurve.Evaluate);
			((Delegate)easeFunction).method_ptr = method_ptr;
			return StopMotion(motionFps, easeFunction);
		}

		[Token(Token = "0x6000066")]
		[Address(RVA = "0x107F060", Offset = "0x107F060", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EA8540]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, customEase, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2026A3A]) = v41;\nL_0018:\n\tv45 = new DG.Tweening.EaseFactory+<>c__DisplayClass2_0();\n\tSystem.Object::.ctor(v45);\n\tv51 = 1f / motionFps;\n\tv45.customEase = customEase;\n\tv45.motionDelay = v51;\n\treturnVal1 = new DG.Tweening.EaseFunction();\n\tv60 = Il2CppMethodInfo;\n\treturnVal1.m_target = v45;\n\treturnVal1.method = Il2CppMethodInfo;\n\treturnVal1.method_ptr = *([v60 @ X8_v9 (Il2CppMethodInfo)]);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static EaseFunction StopMotion(int motionFps, EaseFunction customEase)
		{
			_003C_003Ec__DisplayClass2_0 _003C_003Ec__DisplayClass2_1 = new _003C_003Ec__DisplayClass2_0();
			float motionDelay = 1f / (float)motionFps;
			_003C_003Ec__DisplayClass2_1.customEase = customEase;
			_003C_003Ec__DisplayClass2_1.motionDelay = motionDelay;
			EaseFunction easeFunction = null;
			IntPtr method_ptr = (IntPtr)0;
			((Delegate)easeFunction).m_target = _003C_003Ec__DisplayClass2_1;
			((Delegate)easeFunction).method = (IntPtr)__ldftn(_003C_003Ec__DisplayClass2_0._003CStopMotion_003Eb__0);
			((Delegate)easeFunction).method_ptr = method_ptr;
			return easeFunction;
		}

		[Token(Token = "0x6000067")]
		[Address(RVA = "0x107F1B8", Offset = "0x107F1B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EaseFactory()
		{
		}
	}
}
