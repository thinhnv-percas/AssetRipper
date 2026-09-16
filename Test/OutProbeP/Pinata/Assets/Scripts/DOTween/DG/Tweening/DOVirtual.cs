using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening
{
	[Token(Token = "0x2000009")]
	public static class DOVirtual
	{
		[Token(Token = "0x600005E")]
		[Address(RVA = "0x107EA74", Offset = "0x107EA74", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv32 = *([1EC95B0]);\n\tv33 = *([v32 @ X8_v27]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, from, to, duration, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2026A32]) = v49;\nL_001D:\n\tv53 = new DG.Tweening.DOVirtual+<>c__DisplayClass0_0();\n\tSystem.Object::.ctor(v53);\n\tv53.onVirtualUpdate = onVirtualUpdate;\n\tv53.val = from;\n\tv60 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v60, v53, Il2CppMethodInfo);\n\tv74 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v74, v53, Il2CppMethodInfo);\n\tgoto L_004F;\n\tv123 = *([v119 @ X0_v10+E0]);\n\tv124 = v123 == 0;\n\tv125 = ~v124;\n\tif (v125) goto L_004F;\n\tv127 = \"il2cpp_codegen_runtime_class_init\"(v119, v113, v115, v116, v38, v39, v40, v41, from, to, duration, v42, v43, v44, v45, v46);\nL_004F:\n\tv131 = DG.Tweening.DOTween::To(v60, v74, to, duration);\n\tv137 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v137, v53, Il2CppMethodInfo);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::OnUpdate(v131, v137);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener Float(float from, float to, float duration, TweenCallback<float> onVirtualUpdate)
		{
			DOGetter<float> getter = () => from;
			DOSetter<float> setter = delegate(float x)
			{
				from = x;
			};
			TweenerCore<float, float, FloatOptions> t = DOTween.To(getter, setter, to, duration);
			TweenCallback action = delegate
			{
				onVirtualUpdate(from);
			};
			return t.OnUpdate(action);
		}

		[Token(Token = "0x600005F")]
		[Address(RVA = "0x107EBF4", Offset = "0x107EBF4", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1F07730]);\n\tv31 = *([v30 @ X8_v8]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, from, to, lifetimePercentage, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2026A33]) = v47;\nL_001F:\n\tgoto L_002D;\n\tv54 = *([v50 @ X0_v2 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_002D;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v34, v35, v36, v37, v38, v39, from, to, lifetimePercentage, v40, v41, v42, v43, v44);\n\tv58 = DG.Tweening.DOTween;\nL_002D:\n\tv68 = DG.Tweening.Core.Easing.EaseManager::Evaluate(easeType, 0, lifetimePercentage, 1f, v61.defaultEaseOvershootOrAmplitude, v61.defaultEasePeriod);\n\tv70 = to - from;\n\tv71 = v70 * v68;\n\treturnVal1 = v71 + from;\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EasedValue(float from, float to, float lifetimePercentage, Ease easeType)
		{
			float num = EaseManager.Evaluate(easeType, null, lifetimePercentage, 1f, DOTween.defaultEaseOvershootOrAmplitude, DOTween.defaultEasePeriod);
			float num2 = to - from;
			float num3 = num2 * num;
			return num3 + from;
		}

		[Token(Token = "0x6000060")]
		[Address(RVA = "0x107EC9C", Offset = "0x107EC9C", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv34 = *([1EBA0C0]);\n\tv35 = *([v34 @ X8_v8]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, from, to, lifetimePercentage, overshoot, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2026A34]) = v50;\nL_0021:\n\tgoto L_002F;\n\tv57 = *([v53 @ X0_v2 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_002F;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v53, methodInfo, v38, v39, v40, v41, v42, v43, from, to, lifetimePercentage, overshoot, v44, v45, v46, v47);\n\tv61 = DG.Tweening.DOTween;\nL_002F:\n\tv71 = DG.Tweening.Core.Easing.EaseManager::Evaluate(easeType, 0, lifetimePercentage, 1f, overshoot, v64.defaultEasePeriod);\n\tv73 = to - from;\n\tv74 = v73 * v71;\n\treturnVal1 = v74 + from;\n\treturn returnVal1;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EasedValue(float from, float to, float lifetimePercentage, Ease easeType, float overshoot)
		{
			float num = EaseManager.Evaluate(easeType, null, lifetimePercentage, 1f, overshoot, DOTween.defaultEasePeriod);
			float num2 = to - from;
			float num3 = num2 * num;
			return num3 + from;
		}

		[Token(Token = "0x6000061")]
		[Address(RVA = "0x107ED4C", Offset = "0x107ED4C", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = DG.Tweening.Core.Easing.EaseManager::Evaluate(easeType, 0, lifetimePercentage, 1f, amplitude, period);\n\tv27 = to - from;\n\tv28 = v27 * v22;\n\treturnVal1 = v28 + from;\n\treturn returnVal1;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EasedValue(float from, float to, float lifetimePercentage, Ease easeType, float amplitude, float period)
		{
			float num = EaseManager.Evaluate(easeType, null, lifetimePercentage, 1f, amplitude, period);
			float num2 = to - from;
			float num3 = num2 * num;
			return num3 + from;
		}

		[Token(Token = "0x6000062")]
		[Address(RVA = "0x107ED90", Offset = "0x107ED90", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1ECE7B8]);\n\tv31 = *([v30 @ X8_v15]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, from, to, lifetimePercentage, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2026A35]) = v47;\nL_001C:\n\tv51 = new DG.Tweening.Core.Easing.EaseCurve();\n\tSystem.Object::.ctor(v51);\n\tv51._animCurve = easeCurve;\n\tv57 = new DG.Tweening.EaseFunction();\n\tv61 = Il2CppMethodInfo;\n\tv57.m_target = v51;\n\tv57.method = Il2CppMethodInfo;\n\tv57.method_ptr = *([v61 @ X8_v9 (Il2CppMethodInfo)]);\n\tgoto L_0041;\n\tv69 = *([v65 @ X0_v6 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tif (v71) goto L_0041;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v65, v52, v34, v35, v36, v37, v38, v39, from, to, lifetimePercentage, v40, v41, v42, v43, v44);\n\tv73 = DG.Tweening.DOTween;\nL_0041:\n\tv83 = DG.Tweening.Core.Easing.EaseManager::Evaluate(0x25, v57, lifetimePercentage, 1f, v76.defaultEaseOvershootOrAmplitude, v76.defaultEasePeriod);\n\tv85 = to - from;\n\tv86 = v85 * v83;\n\treturnVal1 = v86 + from;\n\treturn returnVal1;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static float EasedValue(float from, float to, float lifetimePercentage, AnimationCurve easeCurve)
		{
			EaseCurve easeCurve2 = null;
			easeCurve2._animCurve = easeCurve;
			EaseFunction easeFunction = null;
			IntPtr method_ptr = (IntPtr)0;
			((Delegate)easeFunction).m_target = easeCurve2;
			((Delegate)easeFunction).method = (IntPtr)__ldftn(EaseCurve.Evaluate);
			((Delegate)easeFunction).method_ptr = method_ptr;
			float num = EaseManager.Evaluate(Ease.INTERNAL_Custom, easeFunction, lifetimePercentage, 1f, DOTween.defaultEaseOvershootOrAmplitude, DOTween.defaultEasePeriod);
			float num2 = to - from;
			float num3 = num2 * num;
			return num3 + from;
		}

		[Token(Token = "0x6000063")]
		[Address(RVA = "0x107EE84", Offset = "0x107EE84", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1ECE9A8]);\n\tv27 = *([v26 @ X8_v15]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, ignoreTimeScale, methodInfo, v30, v31, v32, v33, v34, delay, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2026A36]) = v44;\nL_001D:\n\tgoto L_0023;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0023;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, ignoreTimeScale, methodInfo, v30, v31, v32, v33, v34, delay, v35, v36, v37, v38, v39, v40, v41);\nL_0023:\n\tv58 = DG.Tweening.DOTween::Sequence();\n\tv61 = DG.Tweening.TweenSettingsExtensions::AppendInterval(v58, delay);\n\tv66 = DG.Tweening.TweenSettingsExtensions::OnStepComplete(v61, callback);\n\tv72 = DG.Tweening.TweenSettingsExtensions::SetUpdate(v66, 0, ignoreTimeScale);\n\treturnVal1 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(v72, 1);\n\treturn returnVal1;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tween DelayedCall(float delay, TweenCallback callback, bool ignoreTimeScale = true)
		{
			Sequence s = DOTween.Sequence();
			Sequence t = s.AppendInterval(delay);
			Sequence t2 = t.OnStepComplete(callback);
			Sequence t3 = t2.SetUpdate(default(UpdateType), ignoreTimeScale);
			return t3.SetAutoKill(autoKillOnCompletion: true);
		}
	}
}
