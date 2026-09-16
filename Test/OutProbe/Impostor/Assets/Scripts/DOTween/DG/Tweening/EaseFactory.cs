using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core.Easing;
using UnityEngine;

namespace DG.Tweening
{
	[Token(Token = "0x2000013")]
	public class EaseFactory
	{
		[Token(Token = "0x6000092")]
		[Address(RVA = "0xC0B658", Offset = "0xC0B658", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv19 = DG.Tweening.DOTween;\n\tv20 = \"il2cpp_codegen_initialize_runtime_metadata\"(v19, ease, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, ease, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv59 = Il2CppMethodInfo;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, ease, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A356BE]) = v38;\nL_0019:\n\tv39 = ease & 0xFF;\n\tv41 = v39 == 0;\n\tif (v41) goto L_002B;\n\tv66 = System.Nullable`1<System.Int32Enum>::get_Value(&ease @ X1 (System.Nullable`1<DG.Tweening.Ease>));\n\tgoto L_0031;\nL_002B:\n\tgoto L_002F;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v54, ease, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv62 = DG.Tweening.DOTween;\nL_002F:\n\tv66 = v63.defaultEaseType;\nL_0031:\n\tv71 = DG.Tweening.Core.Easing.EaseManager::ToEaseFunction(v66);\n\treturnVal1 = DG.Tweening.EaseFactory::StopMotion(motionFps, v71);\n\treturn returnVal1;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static EaseFunction StopMotion(int motionFps, Ease? ease = null)
		{
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Expected I4, but got Unknown
			Ease? ease3 = default(Ease?);
			Ease ease2 = ((((_003F?)ease & 0xFF) == 0) ? DOTween.defaultEaseType : ((Ease)((System.Int32Enum?*)(&ease3))->Value));
			EaseFunction customEase = EaseManager.ToEaseFunction(ease2);
			return StopMotion(motionFps, customEase);
		}

		[Token(Token = "0x6000093")]
		[Address(RVA = "0xC0B7D0", Offset = "0xC0B7D0", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, animCurve, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv53 = DG.Tweening.Core.Easing.EaseCurve;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, animCurve, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv59 = DG.Tweening.EaseFunction;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, animCurve, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv49 = 1;\n\t*([1A356BF]) = v49;\nL_0022:\n\tv51 = new DG.Tweening.Core.Easing.EaseCurve();\n\tDG.Tweening.Core.Easing.EaseCurve::.ctor(v51, animCurve);\n\tv61 = new DG.Tweening.EaseFunction();\n\tDG.Tweening.EaseFunction::.ctor(v61, v51, Il2CppMethodInfo);\n\treturnVal1 = DG.Tweening.EaseFactory::StopMotion(motionFps, v61);\n\treturn returnVal1;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static EaseFunction StopMotion(int motionFps, AnimationCurve animCurve)
		{
			EaseCurve easeCurve = new EaseCurve(animCurve);
			EaseFunction customEase = easeCurve.Evaluate;
			return StopMotion(motionFps, customEase);
		}

		[Token(Token = "0x6000094")]
		[Address(RVA = "0xC0B710", Offset = "0xC0B710", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = DG.Tweening.EaseFunction;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, customEase, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, customEase, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv50 = DG.Tweening.EaseFactory+<>c__DisplayClass2_0;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, customEase, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A356C0]) = v41;\nL_001C:\n\tv43 = new DG.Tweening.EaseFactory+<>c__DisplayClass2_0();\n\tSystem.Object::.ctor(v43);\n\tv56 = 1f / motionFps;\n\tv43.customEase = customEase;\n\tv43.motionDelay = v56;\n\tv60 = new DG.Tweening.EaseFunction();\n\tDG.Tweening.EaseFunction::.ctor(v60, v43, Il2CppMethodInfo);\n\treturn v60;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static EaseFunction StopMotion(int motionFps, EaseFunction customEase)
		{
			float num = 1f / (float)motionFps;
			EaseFunction customEase2 = customEase;
			float motionDelay = num;
			return delegate(float time, float duration, float overshootOrAmplitude, float period)
			{
				//IL_0067: Expected F4, but got O
				//IL_0067: Expected F4, but got O
				//IL_0067: Expected F4, but got I
				//IL_0067: Expected F4, but got I
				//IL_006b: Expected I, but got F4
				//IL_0070: Expected F4, but got I
				//IL_0031: Expected O, but got F4
				if (time < duration)
				{
					object obj = time % motionDelay;
				}
				EaseFunction easeFunction = customEase2;
				nint method_code = ((Delegate)easeFunction).method_code;
				object obj2 = default(object);
				object obj3 = default(object);
				method_code = (nint)easeFunction((nint)((Delegate)easeFunction).method, (nint)((Delegate)easeFunction).invoke_impl, (float)obj2, (float)obj3);
				return method_code;
			};
		}

		[Token(Token = "0x6000095")]
		[Address(RVA = "0xC0B88C", Offset = "0xC0B88C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EaseFactory()
		{
		}
	}
}
