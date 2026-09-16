using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

namespace DG.Tweening
{
	[Token(Token = "0x2000006")]
	public static class DOTweenModuleUI
	{
		[Token(Token = "0x2000020")]
		public static class Utils
		{
			[Token(Token = "0x6000095")]
			[Address(RVA = "0x157DD2C", Offset = "0x157DD2C", Length = "0x2B0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv32 = *([1EB0A50]);\n\tv33 = *([v32 @ X8_v16]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, to, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([2029192]) = v51;\nL_0023:\n\tv60 = UnityEngine.RectTransform::get_rect(from);\n\tv128 = 0x10CD178(&v60 @ V0_v2 (UnityEngine.Rect), 0, methodInfo, v36, v37, v38, v39, v40, v60, v60.m_YMin, v60.m_Width, v60.m_Height, v45, v46, v47, v48);\n\tv60 = UnityEngine.RectTransform::get_rect(from);\n\tv206 = 0x10CD07C(&v60 @ V0_v2 (UnityEngine.Rect), 0, methodInfo, v36, v37, v38, v39, v40, v60, v60.m_YMin, v60.m_Width, v60.m_Height, v45, v46, v47, v48);\n\tv60 = UnityEngine.RectTransform::get_rect(from);\n\tv220 = 0x10CD188(&v60 @ V0_v2 (UnityEngine.Rect), 0, methodInfo, v36, v37, v38, v39, v40, v60, v60.m_YMin, v60.m_Width, v60.m_Height, v45, v46, v47, v48);\n\tv60 = UnityEngine.RectTransform::get_rect(from);\n\tv230 = 0x10CD084(&v60 @ V0_v2 (UnityEngine.Rect), 0, methodInfo, v36, v37, v38, v39, v40, v60, v60.m_YMin, v60.m_Width, v60.m_Height, v45, v46, v47, v48);\n\tv231 = v60 * 0.5f;\n\tv232 = v60 * 0.5f;\n\tv233 = v231 + v60;\n\tv234 = v232 + v60;\n\tv238 = 0x1588A6C(&v82 @ stack_-60_v3, 0, methodInfo, v36, v37, v38, v39, v40, v233, v234, v233, v232, v45, v46, v47, v48);\n\tv241 = UnityEngine.Transform::get_position(from);\n\tgoto L_007B;\n\tv253 = *([v249 @ X0_v20+E0]);\n\tv254 = v253 == 0;\n\tv255 = ~v254;\n\tif (v255) goto L_007B;\n\tv257 = \"il2cpp_codegen_runtime_class_init\"(v249, v240, methodInfo, v36, v37, v38, v39, v40, v241, v242, v243, v232, v45, v46, v47, v48);\nL_007B:\n\tv265 = UnityEngine.RectTransformUtility::WorldToScreenPoint(0, v241);\n\tgoto L_0093;\n\tv274 = *([v270 @ X0_v23+E0]);\n\tv275 = v274 == 0;\n\tv276 = ~v275;\n\tif (v276) goto L_0093;\n\tv278 = \"il2cpp_codegen_runtime_class_init\"(v270, v264, methodInfo, v36, v37, v38, v39, v40, v265, v266, v263, v232, v45, v46, v47, v48);\nL_0093:\n\t// 147 MakeStruct v71 @ AGG157DEC8_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v82 @ stack_-60_v3, v269 @ stack_-5C\n\tv108 = UnityEngine.Vector2::op_Addition(v265, v71);\n\tv112 = UnityEngine.RectTransformUtility::ScreenPointToLocalPointInRectangle(to, v108, 0, &v67 @ stack_-58_v3 (UnityEngine.Vector2));\n\tv60 = UnityEngine.RectTransform::get_rect(to);\n\tv296 = 0x10CD178(&v60 @ V0_v2 (UnityEngine.Rect), 0, &v67 @ stack_-58_v3 (UnityEngine.Vector2), 0, v37, v38, v39, v40, v60, v60.m_YMin, v60.m_Width, v60.m_Height, v45, v46, v47, v48);\n\tv60 = UnityEngine.RectTransform::get_rect(to);\n\tv310 = 0x10CD07C(&v60 @ V0_v2 (UnityEngine.Rect), 0, &v67 @ stack_-58_v3 (UnityEngine.Vector2), 0, v37, v38, v39, v40, v60, v60.m_YMin, v60.m_Width, v60.m_Height, v45, v46, v47, v48);\n\tv60 = UnityEngine.RectTransform::get_rect(to);\n\tv324 = 0x10CD188(&v60 @ V0_v2 (UnityEngine.Rect), 0, &v67 @ stack_-58_v3 (UnityEngine.Vector2), 0, v37, v38, v39, v40, v60, v60.m_YMin, v60.m_Width, v60.m_Height, v45, v46, v47, v48);\n\tv60 = UnityEngine.RectTransform::get_rect(to);\n\tv334 = 0x10CD084(&v60 @ V0_v2 (UnityEngine.Rect), 0, &v67 @ stack_-58_v3 (UnityEngine.Vector2), 0, v37, v38, v39, v40, v60, v60.m_YMin, v60.m_Width, v60.m_Height, v45, v46, v47, v48);\n\tv335 = v60 * 0.5f;\n\tv336 = v60 * 0.5f;\n\tv337 = v335 + v60;\n\tv338 = v336 + v60;\n\tv342 = 0x1588A6C(&v148 @ stack_-68_v2, 0, &v67 @ stack_-58_v3 (UnityEngine.Vector2), 0, v37, v38, v39, v40, v337, v338, v337, v336, v45, v46, v47, v48);\n\tv344 = UnityEngine.RectTransform::get_anchoredPosition(to);\n\t// 229 MakeStruct v142 @ AGG157DFA4_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v67 @ stack_-58_v3 (UnityEngine.Vector2), v348 @ stack_-54\n\tv350 = UnityEngine.Vector2::op_Addition(v344, v142);\n\t// 236 MakeStruct v136 @ AGG157DFB0_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v148 @ stack_-68_v2, v352 @ stack_-64\n\treturnVal2 = UnityEngine.Vector2::op_Subtraction(v350, v136);\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 197 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static Vector2 SwitchToRectTransform(RectTransform from, RectTransform to)
			{
				//IL_0121: Expected F4, but got O
				//IL_012e: Expected F4, but got O
				//IL_0270: Expected F4, but got O
				//IL_028e: Expected F4, but got O
				//IL_029b: Expected F4, but got O
				Rect rect = from.rect;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
				rect = from.rect;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD07C (inside UnityEngine.Rect::MinMaxRect +0xE0)");
				rect = from.rect;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
				rect = from.rect;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD084 (inside UnityEngine.Rect::MinMaxRect +0xE8)");
				float num = rect.x * 0.5f;
				float num2 = rect.x * 0.5f;
				float num3 = num + rect.x;
				float num4 = num2 + rect.x;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
				Vector3 position = from.position;
				Vector2 vector = RectTransformUtility.WorldToScreenPoint(null, position);
				Vector2 vector2 = default(Vector2);
				object obj = default(object);
				vector2.x = (float)obj;
				object obj2 = default(object);
				vector2.y = (float)obj2;
				Vector2 screenPoint = vector + vector2;
				bool flag = RectTransformUtility.ScreenPointToLocalPointInRectangle(to, screenPoint, null, out var localPoint);
				rect = to.rect;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
				rect = to.rect;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD07C (inside UnityEngine.Rect::MinMaxRect +0xE0)");
				rect = to.rect;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
				rect = to.rect;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD084 (inside UnityEngine.Rect::MinMaxRect +0xE8)");
				float num5 = rect.x * 0.5f;
				float num6 = rect.x * 0.5f;
				float num7 = num5 + rect.x;
				float num8 = num6 + rect.x;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
				Vector2 anchoredPosition = to.anchoredPosition;
				Vector2 vector3 = default(Vector2);
				vector3.x = localPoint.x;
				object obj3 = default(object);
				vector3.y = (float)obj3;
				Vector2 vector4 = anchoredPosition + vector3;
				Vector2 vector5 = default(Vector2);
				object obj4 = default(object);
				vector5.x = (float)obj4;
				object obj5 = default(object);
				vector5.y = (float)obj5;
				return vector4 - vector5;
			}
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0x1578DF0", Offset = "0x1578DF0", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1EB0000]);\n\tv29 = *([v28 @ X8_v22]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2029164]) = v46;\nL_001B:\n\tv50 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass0_0();\n\tSystem.Object::.ctor(v50);\n\tv50.target = target;\n\tv57 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v57, v50, Il2CppMethodInfo);\n\tv71 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v71, v50, Il2CppMethodInfo);\n\tgoto L_004D;\n\tv117 = *([v113 @ X0_v10+E0]);\n\tv118 = v117 == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_004D;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v113, v108, v110, v81, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\nL_004D:\n\tv126 = DG.Tweening.DOTween::To(v57, v71, endValue, duration);\n\tv129 = DG.Tweening.TweenSettingsExtensions::SetTarget(v126, v50.target);\n\treturn v126;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<float, float, FloatOptions> DOFade(this CanvasGroup target, float endValue, float duration)
		{
			DOGetter<float> getter = () => target.alpha;
			DOSetter<float> setter = delegate(float x)
			{
				target.alpha = x;
			};
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<float, float, FloatOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x6000025")]
		[Address(RVA = "0x1578F38", Offset = "0x1578F38", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv39 = *([1EF0320]);\n\tv40 = *([v39 @ X8_v15]);\n\tv41 = \"il2cpp_codegen_initialize_method\"(v40, methodInfo, v43, v44, v45, v46, v47, v48, endValue, v0, v2, v3, duration, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2029165]) = v54;\nL_0024:\n\tv58 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass1_0();\n\tSystem.Object::.ctor(v58);\n\tv58.target = target;\n\tv65 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v65, v58, Il2CppMethodInfo);\n\tv79 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\treturnVal2 = DG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v79, v58, Il2CppMethodInfo);\n\treturn returnVal2;\n\tX1 = X19;\n\tX21 = X0;\n\tX2 = *([X8]);\n\tX3 = *([1EEB000]);\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(X0, X1, X2, X3);\n\tX8 = *([1F00430]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0052;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0052;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0052:\n\tX0 = X20;\n\tX1 = X21;\n\tV0 = V12;\n\tV1 = V11;\n\tV2 = V10;\n\tV3 = V9;\n\tV4 = V8;\n\tX2 = 0;\n\t// 90 MakeStruct AGG157905C_2, typeof(UnityEngine.Color), V0, V1, V2, V3\n\tX0 = DG.Tweening.DOTween::To(X0, X1, AGG157905C_2, V4, X2);\n\tX1 = *([X19+10]);\n\tX8 = *([1EF3378]);\n\tX19 = X0;\n\tX2 = *([X8]);\n\tX0 = DG.Tweening.TweenSettingsExtensions::SetTarget /* +17 sharing this address */(X0, X1, X2);\n\tX0 = X19;\n\tX29 = stack[40];\n\tX30 = stack[48];\n\tX20 = stack[30];\n\tX19 = stack[38];\n\tX21 = stack[28];\n\tV9 = stack[18];\n\tV8 = stack[20];\n\tV11 = stack[8];\n\tV10 = stack[10];\n\tV12 = stack[0];\n\t// 109 ShiftStack 80\n\treturn X0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Color, Color, ColorOptions> DOColor(this Graphic target, Color endValue, float duration)
		{
			DOGetter<Color> dOGetter = delegate
			{
				//IL_0017: Expected I, but got O
				//IL_0027: Expected O, but got I
				//IL_0037: Expected O, but got I
				//IL_0043: Expected O, but got I4
				Graphic graphic = target;
				IntPtr intPtr = (IntPtr)graphic;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v1 (Il2CppClass<UnityEngine.UI.Graphic>)+290]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v1 (Il2CppClass<UnityEngine.UI.Graphic>)+298]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ X2_v1 (should have been resolved before IL gen)");
				return (Color)0;
			};
			DOSetter<Color> dOSetter = delegate
			{
				//IL_0017: Expected I, but got O
				//IL_0027: Expected O, but got I
				//IL_0037: Expected O, but got I
				//IL_0043: Expected O, but got I4
				Graphic graphic = target;
				IntPtr intPtr = (IntPtr)graphic;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v1 (Il2CppClass<UnityEngine.UI.Graphic>)+290]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v1 (Il2CppClass<UnityEngine.UI.Graphic>)+298]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ X2_v1 (should have been resolved before IL gen)");
				return (Color)0;
			};
			TweenerCore<Color, Color, ColorOptions> result = default(TweenerCore<Color, Color, ColorOptions>);
			return result;
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0x15790A8", Offset = "0x15790A8", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1EF1FB8]);\n\tv29 = *([v28 @ X8_v22]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2029166]) = v46;\nL_001B:\n\tv50 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass2_0();\n\tSystem.Object::.ctor(v50);\n\tv50.target = target;\n\tv57 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v57, v50, Il2CppMethodInfo);\n\tv71 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v71, v50, Il2CppMethodInfo);\n\tgoto L_004D;\n\tv117 = *([v113 @ X0_v10+E0]);\n\tv118 = v117 == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_004D;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v113, v108, v110, v81, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\nL_004D:\n\tv126 = DG.Tweening.DOTween::ToAlpha(v57, v71, endValue, duration);\n\tv129 = DG.Tweening.TweenSettingsExtensions::SetTarget(v126, v50.target);\n\treturn v126;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Color, Color, ColorOptions> DOFade(this Graphic target, float endValue, float duration)
		{
			DOGetter<Color> getter = delegate
			{
				//IL_0017: Expected I, but got O
				//IL_0027: Expected O, but got I
				//IL_0037: Expected O, but got I
				//IL_0043: Expected O, but got I4
				Graphic graphic = target;
				IntPtr intPtr = (IntPtr)graphic;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v1 (Il2CppClass<UnityEngine.UI.Graphic>)+290]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v1 (Il2CppClass<UnityEngine.UI.Graphic>)+298]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ X2_v1 (should have been resolved before IL gen)");
				return (Color)0;
			};
			DOSetter<Color> setter = delegate(Color x)
			{
				//IL_003e: Expected I, but got O
				//IL_004e: Expected O, but got I
				//IL_005e: Expected O, but got I
				float g = x.g;
				float b = x.b;
				float a = x.a;
				Graphic graphic = target;
				IntPtr intPtr = (IntPtr)graphic;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ X8_v1 (Il2CppClass<UnityEngine.UI.Graphic>)+2A0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ X8_v1 (Il2CppClass<UnityEngine.UI.Graphic>)+2A8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v8 @ X2_v1 (should have been resolved before IL gen)");
			};
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.ToAlpha(getter, setter, endValue, duration);
			TweenerCore<Color, Color, ColorOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x6000027")]
		[Address(RVA = "0x15791F0", Offset = "0x15791F0", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv40 = *([1EAA568]);\n\tv41 = *([v40 @ X8_v22]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, methodInfo, v44, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2029167]) = v55;\nL_0024:\n\tv59 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass3_0();\n\tSystem.Object::.ctor(v59);\n\tv59.target = target;\n\tv66 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v66, v59, Il2CppMethodInfo);\n\tv80 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v80, v59, Il2CppMethodInfo);\n\tgoto L_005A;\n\tv141 = *([v137 @ X0_v10+E0]);\n\tv142 = v141 == 0;\n\tv143 = ~v142;\n\tif (v143) goto L_005A;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v137, v132, v134, v93, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\nL_005A:\n\tv150 = DG.Tweening.DOTween::To(v66, v80, endValue, duration);\n\tv153 = DG.Tweening.TweenSettingsExtensions::SetTarget(v150, v59.target);\n\treturn v150;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Color, Color, ColorOptions> DOColor(this Image target, Color endValue, float duration)
		{
			DOGetter<Color> getter = delegate
			{
				//IL_0017: Expected I, but got O
				//IL_0027: Expected O, but got I
				//IL_0037: Expected O, but got I
				//IL_0043: Expected O, but got I4
				Image image = target;
				IntPtr intPtr = (IntPtr)image;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v1 (Il2CppClass<UnityEngine.UI.Image>)+290]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v1 (Il2CppClass<UnityEngine.UI.Image>)+298]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ X2_v1 (should have been resolved before IL gen)");
				return (Color)0;
			};
			DOSetter<Color> setter = delegate(Color x)
			{
				//IL_003e: Expected I, but got O
				//IL_004e: Expected O, but got I
				//IL_005e: Expected O, but got I
				float g = x.g;
				float b = x.b;
				float a = x.a;
				Image image = target;
				IntPtr intPtr = (IntPtr)image;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ X8_v1 (Il2CppClass<UnityEngine.UI.Image>)+2A0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ X8_v1 (Il2CppClass<UnityEngine.UI.Image>)+2A8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v8 @ X2_v1 (should have been resolved before IL gen)");
			};
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<Color, Color, ColorOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x6000028")]
		[Address(RVA = "0x1579360", Offset = "0x1579360", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1EF0028]);\n\tv29 = *([v28 @ X8_v22]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2029168]) = v46;\nL_001B:\n\tv50 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass4_0();\n\tSystem.Object::.ctor(v50);\n\tv50.target = target;\n\tv57 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v57, v50, Il2CppMethodInfo);\n\tv71 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v71, v50, Il2CppMethodInfo);\n\tgoto L_004D;\n\tv117 = *([v113 @ X0_v10+E0]);\n\tv118 = v117 == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_004D;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v113, v108, v110, v81, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\nL_004D:\n\tv126 = DG.Tweening.DOTween::ToAlpha(v57, v71, endValue, duration);\n\tv129 = DG.Tweening.TweenSettingsExtensions::SetTarget(v126, v50.target);\n\treturn v126;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Color, Color, ColorOptions> DOFade(this Image target, float endValue, float duration)
		{
			DOGetter<Color> getter = delegate
			{
				//IL_0017: Expected I, but got O
				//IL_0027: Expected O, but got I
				//IL_0037: Expected O, but got I
				//IL_0043: Expected O, but got I4
				Image image = target;
				IntPtr intPtr = (IntPtr)image;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v1 (Il2CppClass<UnityEngine.UI.Image>)+290]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v1 (Il2CppClass<UnityEngine.UI.Image>)+298]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ X2_v1 (should have been resolved before IL gen)");
				return (Color)0;
			};
			DOSetter<Color> setter = delegate(Color x)
			{
				//IL_003e: Expected I, but got O
				//IL_004e: Expected O, but got I
				//IL_005e: Expected O, but got I
				float g = x.g;
				float b = x.b;
				float a = x.a;
				Image image = target;
				IntPtr intPtr = (IntPtr)image;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ X8_v1 (Il2CppClass<UnityEngine.UI.Image>)+2A0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ X8_v1 (Il2CppClass<UnityEngine.UI.Image>)+2A8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v8 @ X2_v1 (should have been resolved before IL gen)");
			};
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.ToAlpha(getter, setter, endValue, duration);
			TweenerCore<Color, Color, ColorOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x6000029")]
		[Address(RVA = "0x15794A8", Offset = "0x15794A8", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1EB73F8]);\n\tv31 = *([v30 @ X8_v22]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, endValue, duration, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2029169]) = v48;\nL_001C:\n\tv52 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass5_0();\n\tSystem.Object::.ctor(v52);\n\tv52.target = target;\n\tv68 = endValue > 1f;\n\tif (v68) goto L_0041;\n\tv81 = endValue >= 0;\n\tif (v81) goto L_0041;\nL_0041:\n\tv96 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v96, v52, Il2CppMethodInfo);\n\tv163 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v163, v52, Il2CppMethodInfo);\n\tgoto L_0069;\n\tv176 = *([v172 @ X0_v10+E0]);\n\tv177 = v176 == 0;\n\tv178 = ~v177;\n\tif (v178) goto L_0069;\n\tv180 = \"il2cpp_codegen_runtime_class_init\"(v172, v167, v169, v114, v36, v37, v38, v39, endValue, duration, v40, v41, v42, v43, v44, v45);\nL_0069:\n\tv185 = DG.Tweening.DOTween::To(v96, v163, v91, duration);\n\tv188 = DG.Tweening.TweenSettingsExtensions::SetTarget(v185, v52.target);\n\treturn v185;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 98 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<float, float, FloatOptions> DOFillAmount(this Image target, float endValue, float duration)
		{
			bool flag = endValue > 1f;
			float endValue2 = 1f;
			if (!flag)
			{
				bool flag2 = !(endValue < 0f);
				endValue2 = endValue;
				if (!flag2)
				{
					endValue2 = 0f;
				}
			}
			DOGetter<float> getter = delegate
			{
				Image image = target;
				return image.fillAmount;
			};
			DOSetter<float> setter = delegate(float x)
			{
				target.fillAmount = x;
			};
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, endValue2, duration);
			TweenerCore<float, float, FloatOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x600002A")]
		[Address(RVA = "0x1579614", Offset = "0x1579614", Length = "0x1E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv44 = *([1F08D00]);\n\tv45 = *([v44 @ X8_v21]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, gradient, methodInfo, v48, v49, v50, v51, v52, duration, v53, v54, v55, v56, v57, v58, v59);\n\tv62 = 0 | 1;\n\t*([202916A]) = v62;\nL_0026:\n\tgoto L_002D;\n\tv69 = *([v65 @ X0_v2+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tgoto L_002D;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v65, gradient, methodInfo, v48, v49, v50, v51, v52, duration, v53, v54, v55, v56, v57, v58, v59);\nL_002D:\n\tv77 = DG.Tweening.DOTween::Sequence();\n\tv82 = UnityEngine.Gradient::get_colorKeys(gradient);\n\tv201 = v82.Length < 1;\n\tif (v201) goto L_00BD;\n\tv202 = v82.Length == 0;\n\tif (v202) goto L_00B4;\n\tv114 = v82.Length - 1;\n\tv110 = v82 + 0x30;\nL_0050:\n\tv427 = *([v110 @ X25_v7]);\n\tv387 = v116 == 0;\n\tv388 = ~v387;\n\tif (v388) goto L_0075;\n\tv389 = *([v110 @ X25_v7]) < 0;\n\tv145 = ~v389;\n\tv136 = *([v110 @ X25_v7]) == 0;\n\tv390 = ~v136;\n\tv121 = v145 & v390;\n\tif (v121) goto L_0075;\n\tv421 = UnityEngine.UI.Graphic::set_color(target, Color_arg);\n\tgoto L_009B;\nL_0075:\n\tv350 = v114 != v116;\n\tif (v350) goto L_007D;\n\tv412 = DG.Tweening.TweenExtensions::Duration(v77, 0);\n\tv439 = duration - v412;\n\tgoto L_0092;\nL_007D:\n\tv369 = v116 == 0;\n\tif (v369) goto L_008C;\n\tv347 = v116 - 1;\n\tv423 = v347 < v155;\n\tv366 = ~v423;\n\tif (v366) goto L_00B4;\n\tv427 = v427 - *([v110 @ X25_v7-14]);\nL_008C:\n\tv439 = v427 * duration;\nL_0092:\n\t// 146 MakeStruct v438 @ AGG1579768_1_v7 (UnityEngine.Color), typeof(UnityEngine.Color), [v110 @ X25_v7-10], [v110 @ X25_v7-C], [v110 @ X25_v7-8], [v110 @ X25_v7-4]\n\tv473 = DG.Tweening.DOTweenModuleUI::DOColor(target, v438, v439);\n\tv477 = DG.Tweening.TweenSettingsExtensions::SetEase(v473, 1);\n\tv464 = DG.Tweening.TweenSettingsExtensions::Append(v77, v477);\nL_009B:\n\tv116 = v116 + 1;\n\tv248 = v116 >= v82.Length;\n\tif (v248) goto L_00BD;\n\tv155 = v82.Length;\n\tv110 = v110 + 0x14;\n\tv474 = v116 < v82.Length;\n\tv365 = ~v474;\n\tv349 = ~v365;\n\tif (v349) goto L_0050;\nL_00B4:\n\tv371 = new System.IndexOutOfRangeException();\n\tthrow v371;\nL_00BD:\n\tv290 = DG.Tweening.TweenSettingsExtensions::SetTarget(v77, target);\n\treturn v77;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 147 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sequence DOGradientColor(this Image target, Gradient gradient, float duration)
		{
			//IL_0082: Expected O, but got I
			//IL_02bf: Expected F4, but got I
			//IL_02d4: Expected F4, but got I
			//IL_02e9: Expected F4, but got I
			//IL_02fe: Expected F4, but got I
			//IL_0101: Expected F4, but got I
			//IL_0116: Expected F4, but got I
			//IL_012b: Expected F4, but got I
			//IL_0140: Expected F4, but got I
			//IL_0200: Expected O, but got I
			//IL_024d: Expected O, but got I
			Sequence sequence = DOTween.Sequence();
			GradientColorKey[] colorKeys = gradient.colorKeys;
			if (colorKeys.Length >= 1)
			{
				if (colorKeys.Length != 0)
				{
					int num = colorKeys.Length - 1;
					object obj = (long)(IntPtr)colorKeys + 48L;
					int num2 = 0;
					int num3 = colorKeys.Length;
					Color color = default(Color);
					Color endValue = default(Color);
					while (true)
					{
						object obj2 = obj;
						if (num2 == 0)
						{
							bool flag = (long)(IntPtr)obj < 0L;
							bool flag2 = !flag;
							bool flag3 = obj == null;
							bool flag4 = !flag3;
							if (!(flag2 && flag4))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ X25_v7-10]");
								color.r = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ X25_v7-C]");
								color.g = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ X25_v7-8]");
								color.b = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ X25_v7-4]");
								color.a = 0f;
								target.color = color;
								goto IL_0205;
							}
						}
						float duration2;
						if (num == num2)
						{
							float num4 = sequence.Duration(includeLoops: false);
							duration2 = duration - num4;
						}
						else
						{
							if (num2 != 0)
							{
								int num5 = num2 - 1;
								if (num5 >= num3)
								{
									break;
								}
								IntPtr intPtr = (IntPtr)obj2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ X25_v7-14]");
								obj2 = (long)intPtr - 0L;
							}
							duration2 = (float)obj2 * duration;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ X25_v7-10]");
						endValue.r = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ X25_v7-C]");
						endValue.g = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ X25_v7-8]");
						endValue.b = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ X25_v7-4]");
						endValue.a = 0f;
						TweenerCore<Color, Color, ColorOptions> t = target.DOColor(endValue, duration2);
						TweenerCore<Color, Color, ColorOptions> t2 = t.SetEase(Ease.Linear);
						Sequence sequence2 = sequence.Append(t2);
						goto IL_0205;
						IL_0205:
						num2++;
						if (num2 < colorKeys.Length)
						{
							num3 = colorKeys.Length;
							obj = (long)(IntPtr)obj + 20L;
							if (num2 >= colorKeys.Length)
							{
								break;
							}
							continue;
						}
						goto IL_028f;
					}
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			goto IL_028f;
			IL_028f:
			Sequence sequence3 = sequence.SetTarget(target);
			return sequence;
		}

		[Token(Token = "0x600002B")]
		[Address(RVA = "0x15797FC", Offset = "0x15797FC", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv36 = *([1F05AF8]);\n\tv37 = *([v36 @ X8_v22]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, snapping, methodInfo, v40, v41, v42, v43, v44, endValue, v0, duration, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([202916B]) = v52;\nL_0020:\n\tv56 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass7_0();\n\tSystem.Object::.ctor(v56);\n\tv56.target = target;\n\tv63 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v63, v56, Il2CppMethodInfo);\n\tv77 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v77, v56, Il2CppMethodInfo);\n\tgoto L_0054;\n\tv132 = *([v128 @ X0_v10+E0]);\n\tv133 = v132 == 0;\n\tv134 = ~v133;\n\tif (v134) goto L_0054;\n\tv136 = \"il2cpp_codegen_runtime_class_init\"(v128, v123, v125, v90, v41, v42, v43, v44, endValue, v0, duration, v45, v46, v47, v48, v49);\nL_0054:\n\tv141 = DG.Tweening.DOTween::To(v63, v77, endValue, duration);\n\tv145 = DG.Tweening.TweenSettingsExtensions::SetOptions(v141, snapping);\n\tv147 = DG.Tweening.TweenSettingsExtensions::SetTarget(v145, v56.target);\n\treturn v141;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector2, Vector2, VectorOptions> DOFlexibleSize(this LayoutElement target, Vector2 endValue, float duration, bool snapping = false)
		{
			DOGetter<Vector2> getter = delegate
			{
				float flexibleWidth = target.flexibleWidth;
				float flexibleHeight = target.flexibleHeight;
				Vector2 vector = default(Vector2);
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
				return default(Vector2);
			};
			DOSetter<Vector2> setter = delegate(Vector2 x)
			{
				//IL_003d: Expected I, but got O
				//IL_004d: Expected O, but got I
				//IL_005d: Expected O, but got I
				float y = x.y;
				Vector2 vector = default(Vector2);
				target.flexibleWidth = vector.x;
				LayoutElement layoutElement = target;
				IntPtr intPtr = (IntPtr)layoutElement;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v3 (Il2CppClass<UnityEngine.UI.LayoutElement>)+3D0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v3 (Il2CppClass<UnityEngine.UI.LayoutElement>)+3D8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v49 @ X2_v1 (should have been resolved before IL gen)");
			};
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			Tweener t = tweenerCore.SetOptions(snapping);
			Tweener tweener = t.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x600002C")]
		[Address(RVA = "0x1579964", Offset = "0x1579964", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv36 = *([1EC98E8]);\n\tv37 = *([v36 @ X8_v22]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, snapping, methodInfo, v40, v41, v42, v43, v44, endValue, v0, duration, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([202916C]) = v52;\nL_0020:\n\tv56 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass8_0();\n\tSystem.Object::.ctor(v56);\n\tv56.target = target;\n\tv63 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v63, v56, Il2CppMethodInfo);\n\tv77 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v77, v56, Il2CppMethodInfo);\n\tgoto L_0054;\n\tv132 = *([v128 @ X0_v10+E0]);\n\tv133 = v132 == 0;\n\tv134 = ~v133;\n\tif (v134) goto L_0054;\n\tv136 = \"il2cpp_codegen_runtime_class_init\"(v128, v123, v125, v90, v41, v42, v43, v44, endValue, v0, duration, v45, v46, v47, v48, v49);\nL_0054:\n\tv141 = DG.Tweening.DOTween::To(v63, v77, endValue, duration);\n\tv145 = DG.Tweening.TweenSettingsExtensions::SetOptions(v141, snapping);\n\tv147 = DG.Tweening.TweenSettingsExtensions::SetTarget(v145, v56.target);\n\treturn v141;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector2, Vector2, VectorOptions> DOMinSize(this LayoutElement target, Vector2 endValue, float duration, bool snapping = false)
		{
			DOGetter<Vector2> getter = delegate
			{
				float minWidth = target.minWidth;
				float minHeight = target.minHeight;
				Vector2 vector = default(Vector2);
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
				return default(Vector2);
			};
			DOSetter<Vector2> setter = delegate(Vector2 x)
			{
				//IL_003d: Expected I, but got O
				//IL_004d: Expected O, but got I
				//IL_005d: Expected O, but got I
				float y = x.y;
				Vector2 vector = default(Vector2);
				target.minWidth = vector.x;
				LayoutElement layoutElement = target;
				IntPtr intPtr = (IntPtr)layoutElement;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v3 (Il2CppClass<UnityEngine.UI.LayoutElement>)+350]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v3 (Il2CppClass<UnityEngine.UI.LayoutElement>)+358]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v49 @ X2_v1 (should have been resolved before IL gen)");
			};
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			Tweener t = tweenerCore.SetOptions(snapping);
			Tweener tweener = t.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x600002D")]
		[Address(RVA = "0x1579ACC", Offset = "0x1579ACC", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv36 = *([1EE0538]);\n\tv37 = *([v36 @ X8_v22]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, snapping, methodInfo, v40, v41, v42, v43, v44, endValue, v0, duration, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([202916D]) = v52;\nL_0020:\n\tv56 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass9_0();\n\tSystem.Object::.ctor(v56);\n\tv56.target = target;\n\tv63 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v63, v56, Il2CppMethodInfo);\n\tv77 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v77, v56, Il2CppMethodInfo);\n\tgoto L_0054;\n\tv132 = *([v128 @ X0_v10+E0]);\n\tv133 = v132 == 0;\n\tv134 = ~v133;\n\tif (v134) goto L_0054;\n\tv136 = \"il2cpp_codegen_runtime_class_init\"(v128, v123, v125, v90, v41, v42, v43, v44, endValue, v0, duration, v45, v46, v47, v48, v49);\nL_0054:\n\tv141 = DG.Tweening.DOTween::To(v63, v77, endValue, duration);\n\tv145 = DG.Tweening.TweenSettingsExtensions::SetOptions(v141, snapping);\n\tv147 = DG.Tweening.TweenSettingsExtensions::SetTarget(v145, v56.target);\n\treturn v141;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector2, Vector2, VectorOptions> DOPreferredSize(this LayoutElement target, Vector2 endValue, float duration, bool snapping = false)
		{
			DOGetter<Vector2> getter = delegate
			{
				float preferredWidth = target.preferredWidth;
				float preferredHeight = target.preferredHeight;
				Vector2 vector = default(Vector2);
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
				return default(Vector2);
			};
			DOSetter<Vector2> setter = delegate(Vector2 x)
			{
				//IL_003d: Expected I, but got O
				//IL_004d: Expected O, but got I
				//IL_005d: Expected O, but got I
				float y = x.y;
				Vector2 vector = default(Vector2);
				target.preferredWidth = vector.x;
				LayoutElement layoutElement = target;
				IntPtr intPtr = (IntPtr)layoutElement;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v3 (Il2CppClass<UnityEngine.UI.LayoutElement>)+390]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v3 (Il2CppClass<UnityEngine.UI.LayoutElement>)+398]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v49 @ X2_v1 (should have been resolved before IL gen)");
			};
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			Tweener t = tweenerCore.SetOptions(snapping);
			Tweener tweener = t.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x600002E")]
		[Address(RVA = "0x1579C34", Offset = "0x1579C34", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv40 = *([1EE85C0]);\n\tv41 = *([v40 @ X8_v22]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, methodInfo, v44, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([202916E]) = v55;\nL_0024:\n\tv59 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass10_0();\n\tSystem.Object::.ctor(v59);\n\tv59.target = target;\n\tv66 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v66, v59, Il2CppMethodInfo);\n\tv80 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v80, v59, Il2CppMethodInfo);\n\tgoto L_005A;\n\tv141 = *([v137 @ X0_v10+E0]);\n\tv142 = v141 == 0;\n\tv143 = ~v142;\n\tif (v143) goto L_005A;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v137, v132, v134, v93, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\nL_005A:\n\tv150 = DG.Tweening.DOTween::To(v66, v80, endValue, duration);\n\tv153 = DG.Tweening.TweenSettingsExtensions::SetTarget(v150, v59.target);\n\treturn v150;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Color, Color, ColorOptions> DOColor(this Outline target, Color endValue, float duration)
		{
			DOGetter<Color> getter = delegate
			{
				Outline outline = target;
				return ((Shadow)outline).m_EffectColor;
			};
			DOSetter<Color> setter = delegate(Color x)
			{
				target.effectColor = x;
			};
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<Color, Color, ColorOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x600002F")]
		[Address(RVA = "0x1579DA4", Offset = "0x1579DA4", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1ECFB88]);\n\tv29 = *([v28 @ X8_v22]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202916F]) = v46;\nL_001B:\n\tv50 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass11_0();\n\tSystem.Object::.ctor(v50);\n\tv50.target = target;\n\tv57 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v57, v50, Il2CppMethodInfo);\n\tv71 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v71, v50, Il2CppMethodInfo);\n\tgoto L_004D;\n\tv117 = *([v113 @ X0_v10+E0]);\n\tv118 = v117 == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_004D;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v113, v108, v110, v81, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\nL_004D:\n\tv126 = DG.Tweening.DOTween::ToAlpha(v57, v71, endValue, duration);\n\tv129 = DG.Tweening.TweenSettingsExtensions::SetTarget(v126, v50.target);\n\treturn v126;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Color, Color, ColorOptions> DOFade(this Outline target, float endValue, float duration)
		{
			DOGetter<Color> getter = delegate
			{
				Outline outline = target;
				return ((Shadow)outline).m_EffectColor;
			};
			DOSetter<Color> setter = delegate(Color x)
			{
				target.effectColor = x;
			};
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.ToAlpha(getter, setter, endValue, duration);
			TweenerCore<Color, Color, ColorOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x6000030")]
		[Address(RVA = "0x1579EEC", Offset = "0x1579EEC", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv32 = *([1EAEB20]);\n\tv33 = *([v32 @ X8_v22]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, endValue, v0, duration, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2029170]) = v49;\nL_001E:\n\tv53 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass12_0();\n\tSystem.Object::.ctor(v53);\n\tv53.target = target;\n\tv60 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v60, v53, Il2CppMethodInfo);\n\tv74 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v74, v53, Il2CppMethodInfo);\n\tgoto L_0052;\n\tv127 = *([v123 @ X0_v10+E0]);\n\tv128 = v127 == 0;\n\tv129 = ~v128;\n\tif (v129) goto L_0052;\n\tv131 = \"il2cpp_codegen_runtime_class_init\"(v123, v118, v120, v87, v38, v39, v40, v41, endValue, v0, duration, v42, v43, v44, v45, v46);\nL_0052:\n\tv136 = DG.Tweening.DOTween::To(v60, v74, endValue, duration);\n\tv139 = DG.Tweening.TweenSettingsExtensions::SetTarget(v136, v53.target);\n\treturn v136;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector2, Vector2, VectorOptions> DOScale(this Outline target, Vector2 endValue, float duration)
		{
			DOGetter<Vector2> getter = delegate
			{
				Outline outline = target;
				return ((Shadow)outline).m_EffectDistance;
			};
			DOSetter<Vector2> setter = delegate(Vector2 x)
			{
				target.effectDistance = x;
			};
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x6000031")]
		[Address(RVA = "0x157A044", Offset = "0x157A044", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv36 = *([1EB9750]);\n\tv37 = *([v36 @ X8_v22]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, snapping, methodInfo, v40, v41, v42, v43, v44, endValue, v0, duration, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2029171]) = v52;\nL_0020:\n\tv56 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass13_0();\n\tSystem.Object::.ctor(v56);\n\tv56.target = target;\n\tv63 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v63, v56, Il2CppMethodInfo);\n\tv77 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v77, v56, Il2CppMethodInfo);\n\tgoto L_0054;\n\tv132 = *([v128 @ X0_v10+E0]);\n\tv133 = v132 == 0;\n\tv134 = ~v133;\n\tif (v134) goto L_0054;\n\tv136 = \"il2cpp_codegen_runtime_class_init\"(v128, v123, v125, v90, v41, v42, v43, v44, endValue, v0, duration, v45, v46, v47, v48, v49);\nL_0054:\n\tv141 = DG.Tweening.DOTween::To(v63, v77, endValue, duration);\n\tv145 = DG.Tweening.TweenSettingsExtensions::SetOptions(v141, snapping);\n\tv147 = DG.Tweening.TweenSettingsExtensions::SetTarget(v145, v56.target);\n\treturn v141;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector2, Vector2, VectorOptions> DOAnchorPos(this RectTransform target, Vector2 endValue, float duration, bool snapping = false)
		{
			DOGetter<Vector2> getter = () => target.anchoredPosition;
			DOSetter<Vector2> setter = delegate(Vector2 x)
			{
				target.anchoredPosition = x;
			};
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			Tweener t = tweenerCore.SetOptions(snapping);
			Tweener tweener = t.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x6000032")]
		[Address(RVA = "0x157A1AC", Offset = "0x157A1AC", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv32 = *([1EE8E00]);\n\tv33 = *([v32 @ X8_v22]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, snapping, methodInfo, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2029172]) = v49;\nL_001D:\n\tv53 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass14_0();\n\tSystem.Object::.ctor(v53);\n\tv53.target = target;\n\tv60 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v60, v53, Il2CppMethodInfo);\n\tv74 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v74, v53, Il2CppMethodInfo);\n\tv83 = 0;\n\tv129 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(&v83 @ stack_-48_v1, 0, Il2CppMethodInfo);\n\tgoto L_0056;\n\tv136 = *([v132 @ X0_v12+E0]);\n\tv137 = v136 == 0;\n\tv138 = ~v137;\n\tif (v138) goto L_0056;\n\tv140 = \"il2cpp_codegen_runtime_class_init\"(v132, v128, v123, v124, v37, v38, v39, v40, v127, v126, v41, v42, v43, v44, v45, v46);\nL_0056:\n\t// 86 MakeStruct v78 @ AGG157A2D0_2_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0, v142 @ stack_-44\n\tv146 = DG.Tweening.DOTween::To(v60, v74, v78, duration);\n\tv150 = DG.Tweening.TweenSettingsExtensions::SetOptions(v146, 2, snapping);\n\tv152 = DG.Tweening.TweenSettingsExtensions::SetTarget(v150, v53.target);\n\treturn v146;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector2, Vector2, VectorOptions> DOAnchorPosX(this RectTransform target, float endValue, float duration, bool snapping = false)
		{
			//IL_004d: Expected O, but got I4
			//IL_006d: Expected F4, but got O
			DOGetter<Vector2> getter = () => target.anchoredPosition;
			DOSetter<Vector2> setter = delegate(Vector2 x)
			{
				target.anchoredPosition = x;
			};
			object obj = 0;
			Vector2 endValue2 = default(Vector2);
			endValue2.x = 0f;
			object obj2 = default(object);
			endValue2.y = (float)obj2;
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue2, duration);
			Tweener t = tweenerCore.SetOptions(AxisConstraint.X, snapping);
			Tweener tweener = t.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x6000033")]
		[Address(RVA = "0x157A328", Offset = "0x157A328", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv32 = *([1F0C690]);\n\tv33 = *([v32 @ X8_v22]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, snapping, methodInfo, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2029173]) = v49;\nL_001D:\n\tv53 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass15_0();\n\tSystem.Object::.ctor(v53);\n\tv53.target = target;\n\tv60 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v60, v53, Il2CppMethodInfo);\n\tv74 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v74, v53, Il2CppMethodInfo);\n\tv83 = 0;\n\tv129 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(&v83 @ stack_-48_v1, 0, Il2CppMethodInfo);\n\tgoto L_0056;\n\tv136 = *([v132 @ X0_v12+E0]);\n\tv137 = v136 == 0;\n\tv138 = ~v137;\n\tif (v138) goto L_0056;\n\tv140 = \"il2cpp_codegen_runtime_class_init\"(v132, v128, v123, v124, v37, v38, v39, v40, v126, v127, v41, v42, v43, v44, v45, v46);\nL_0056:\n\t// 86 MakeStruct v78 @ AGG157A44C_2_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0, v142 @ stack_-44\n\tv146 = DG.Tweening.DOTween::To(v60, v74, v78, duration);\n\tv150 = DG.Tweening.TweenSettingsExtensions::SetOptions(v146, 4, snapping);\n\tv152 = DG.Tweening.TweenSettingsExtensions::SetTarget(v150, v53.target);\n\treturn v146;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector2, Vector2, VectorOptions> DOAnchorPosY(this RectTransform target, float endValue, float duration, bool snapping = false)
		{
			//IL_004d: Expected O, but got I4
			//IL_006d: Expected F4, but got O
			DOGetter<Vector2> getter = () => target.anchoredPosition;
			DOSetter<Vector2> setter = delegate(Vector2 x)
			{
				target.anchoredPosition = x;
			};
			object obj = 0;
			Vector2 endValue2 = default(Vector2);
			endValue2.x = 0f;
			object obj2 = default(object);
			endValue2.y = (float)obj2;
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue2, duration);
			Tweener t = tweenerCore.SetOptions(AxisConstraint.Y, snapping);
			Tweener tweener = t.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x6000034")]
		[Address(RVA = "0x157A4A4", Offset = "0x157A4A4", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv40 = *([1EF11E0]);\n\tv41 = *([v40 @ X8_v22]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, snapping, methodInfo, v44, v45, v46, v47, v48, endValue, v0, v2, duration, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2029174]) = v55;\nL_0023:\n\tv59 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass16_0();\n\tSystem.Object::.ctor(v59);\n\tv59.target = target;\n\tv66 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v66, v59, Il2CppMethodInfo);\n\tv80 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v80, v59, Il2CppMethodInfo);\n\tgoto L_0058;\n\tv139 = *([v135 @ X0_v10+E0]);\n\tv140 = v139 == 0;\n\tv141 = ~v140;\n\tif (v141) goto L_0058;\n\tv143 = \"il2cpp_codegen_runtime_class_init\"(v135, v130, v132, v93, v45, v46, v47, v48, endValue, v0, v2, duration, v49, v50, v51, v52);\nL_0058:\n\tv148 = DG.Tweening.DOTween::To(v66, v80, endValue, duration);\n\tv152 = DG.Tweening.TweenSettingsExtensions::SetOptions(v148, snapping);\n\tv154 = DG.Tweening.TweenSettingsExtensions::SetTarget(v152, v59.target);\n\treturn v148;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOAnchorPos3D(this RectTransform target, Vector3 endValue, float duration, bool snapping = false)
		{
			DOGetter<Vector3> getter = () => target.anchoredPosition3D;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.anchoredPosition3D = x;
			};
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			Tweener t = tweenerCore.SetOptions(snapping);
			Tweener tweener = t.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x6000035")]
		[Address(RVA = "0x157A614", Offset = "0x157A614", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv32 = *([1EA50A8]);\n\tv33 = *([v32 @ X8_v22]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, snapping, methodInfo, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2029175]) = v49;\nL_001D:\n\tv53 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass17_0();\n\tSystem.Object::.ctor(v53);\n\tv53.target = target;\n\tv60 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v60, v53, Il2CppMethodInfo);\n\tv74 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v74, v53, Il2CppMethodInfo);\n\tv83 = 0;\n\tv135 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(&v83 @ stack_-50_v1, 0, Il2CppMethodInfo);\n\tgoto L_0059;\n\tv142 = *([v138 @ X0_v12+E0]);\n\tv143 = v142 == 0;\n\tv144 = ~v143;\n\tif (v144) goto L_0059;\n\tv146 = \"il2cpp_codegen_runtime_class_init\"(v138, v134, v128, v129, v37, v38, v39, v40, v133, v131, v132, v42, v43, v44, v45, v46);\nL_0059:\n\t// 89 MakeStruct v78 @ AGG157A744_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v148 @ stack_-4C, 0\n\tv152 = DG.Tweening.DOTween::To(v60, v74, v78, duration);\n\tv156 = DG.Tweening.TweenSettingsExtensions::SetOptions(v152, 2, snapping);\n\tv158 = DG.Tweening.TweenSettingsExtensions::SetTarget(v156, v53.target);\n\treturn v152;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOAnchorPos3DX(this RectTransform target, float endValue, float duration, bool snapping = false)
		{
			//IL_004d: Expected O, but got I4
			//IL_006d: Expected F4, but got O
			DOGetter<Vector3> getter = () => target.anchoredPosition3D;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.anchoredPosition3D = x;
			};
			object obj = 0;
			Vector3 endValue2 = default(Vector3);
			endValue2.x = 0f;
			object obj2 = default(object);
			endValue2.y = (float)obj2;
			endValue2.z = 0f;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue2, duration);
			Tweener t = tweenerCore.SetOptions(AxisConstraint.X, snapping);
			Tweener tweener = t.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x6000036")]
		[Address(RVA = "0x157A79C", Offset = "0x157A79C", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv32 = *([1EE5E50]);\n\tv33 = *([v32 @ X8_v22]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, snapping, methodInfo, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2029176]) = v49;\nL_001D:\n\tv53 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass18_0();\n\tSystem.Object::.ctor(v53);\n\tv53.target = target;\n\tv60 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v60, v53, Il2CppMethodInfo);\n\tv74 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v74, v53, Il2CppMethodInfo);\n\tv83 = 0;\n\tv135 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(&v83 @ stack_-50_v1, 0, Il2CppMethodInfo);\n\tgoto L_0059;\n\tv142 = *([v138 @ X0_v12+E0]);\n\tv143 = v142 == 0;\n\tv144 = ~v143;\n\tif (v144) goto L_0059;\n\tv146 = \"il2cpp_codegen_runtime_class_init\"(v138, v134, v128, v129, v37, v38, v39, v40, v131, v133, v132, v42, v43, v44, v45, v46);\nL_0059:\n\t// 89 MakeStruct v78 @ AGG157A8CC_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v148 @ stack_-4C, 0\n\tv152 = DG.Tweening.DOTween::To(v60, v74, v78, duration);\n\tv156 = DG.Tweening.TweenSettingsExtensions::SetOptions(v152, 4, snapping);\n\tv158 = DG.Tweening.TweenSettingsExtensions::SetTarget(v156, v53.target);\n\treturn v152;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOAnchorPos3DY(this RectTransform target, float endValue, float duration, bool snapping = false)
		{
			//IL_004d: Expected O, but got I4
			//IL_006d: Expected F4, but got O
			DOGetter<Vector3> getter = () => target.anchoredPosition3D;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.anchoredPosition3D = x;
			};
			object obj = 0;
			Vector3 endValue2 = default(Vector3);
			endValue2.x = 0f;
			object obj2 = default(object);
			endValue2.y = (float)obj2;
			endValue2.z = 0f;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue2, duration);
			Tweener t = tweenerCore.SetOptions(AxisConstraint.Y, snapping);
			Tweener tweener = t.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x6000037")]
		[Address(RVA = "0x157A924", Offset = "0x157A924", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv32 = *([1ED8768]);\n\tv33 = *([v32 @ X8_v22]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, snapping, methodInfo, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2029177]) = v49;\nL_001D:\n\tv53 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass19_0();\n\tSystem.Object::.ctor(v53);\n\tv53.target = target;\n\tv60 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v60, v53, Il2CppMethodInfo);\n\tv74 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v74, v53, Il2CppMethodInfo);\n\tv83 = 0;\n\tv135 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(&v83 @ stack_-50_v1, 0, Il2CppMethodInfo);\n\tgoto L_0059;\n\tv142 = *([v138 @ X0_v12+E0]);\n\tv143 = v142 == 0;\n\tv144 = ~v143;\n\tif (v144) goto L_0059;\n\tv146 = \"il2cpp_codegen_runtime_class_init\"(v138, v134, v128, v129, v37, v38, v39, v40, v131, v132, v133, v42, v43, v44, v45, v46);\nL_0059:\n\t// 89 MakeStruct v78 @ AGG157AA54_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v148 @ stack_-4C, 0\n\tv152 = DG.Tweening.DOTween::To(v60, v74, v78, duration);\n\tv156 = DG.Tweening.TweenSettingsExtensions::SetOptions(v152, 8, snapping);\n\tv158 = DG.Tweening.TweenSettingsExtensions::SetTarget(v156, v53.target);\n\treturn v152;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOAnchorPos3DZ(this RectTransform target, float endValue, float duration, bool snapping = false)
		{
			//IL_004d: Expected O, but got I4
			//IL_006d: Expected F4, but got O
			DOGetter<Vector3> getter = () => target.anchoredPosition3D;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.anchoredPosition3D = x;
			};
			object obj = 0;
			Vector3 endValue2 = default(Vector3);
			endValue2.x = 0f;
			object obj2 = default(object);
			endValue2.y = (float)obj2;
			endValue2.z = 0f;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue2, duration);
			Tweener t = tweenerCore.SetOptions(AxisConstraint.Z, snapping);
			Tweener tweener = t.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x6000038")]
		[Address(RVA = "0x157AAAC", Offset = "0x157AAAC", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv36 = *([1F085E0]);\n\tv37 = *([v36 @ X8_v22]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, snapping, methodInfo, v40, v41, v42, v43, v44, endValue, v0, duration, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2029178]) = v52;\nL_0020:\n\tv56 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass20_0();\n\tSystem.Object::.ctor(v56);\n\tv56.target = target;\n\tv63 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v63, v56, Il2CppMethodInfo);\n\tv77 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v77, v56, Il2CppMethodInfo);\n\tgoto L_0054;\n\tv132 = *([v128 @ X0_v10+E0]);\n\tv133 = v132 == 0;\n\tv134 = ~v133;\n\tif (v134) goto L_0054;\n\tv136 = \"il2cpp_codegen_runtime_class_init\"(v128, v123, v125, v90, v41, v42, v43, v44, endValue, v0, duration, v45, v46, v47, v48, v49);\nL_0054:\n\tv141 = DG.Tweening.DOTween::To(v63, v77, endValue, duration);\n\tv145 = DG.Tweening.TweenSettingsExtensions::SetOptions(v141, snapping);\n\tv147 = DG.Tweening.TweenSettingsExtensions::SetTarget(v145, v56.target);\n\treturn v141;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector2, Vector2, VectorOptions> DOAnchorMax(this RectTransform target, Vector2 endValue, float duration, bool snapping = false)
		{
			DOGetter<Vector2> getter = () => target.anchorMax;
			DOSetter<Vector2> setter = delegate(Vector2 x)
			{
				target.anchorMax = x;
			};
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			Tweener t = tweenerCore.SetOptions(snapping);
			Tweener tweener = t.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x6000039")]
		[Address(RVA = "0x157AC14", Offset = "0x157AC14", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv36 = *([1EB8738]);\n\tv37 = *([v36 @ X8_v22]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, snapping, methodInfo, v40, v41, v42, v43, v44, endValue, v0, duration, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2029179]) = v52;\nL_0020:\n\tv56 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass21_0();\n\tSystem.Object::.ctor(v56);\n\tv56.target = target;\n\tv63 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v63, v56, Il2CppMethodInfo);\n\tv77 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v77, v56, Il2CppMethodInfo);\n\tgoto L_0054;\n\tv132 = *([v128 @ X0_v10+E0]);\n\tv133 = v132 == 0;\n\tv134 = ~v133;\n\tif (v134) goto L_0054;\n\tv136 = \"il2cpp_codegen_runtime_class_init\"(v128, v123, v125, v90, v41, v42, v43, v44, endValue, v0, duration, v45, v46, v47, v48, v49);\nL_0054:\n\tv141 = DG.Tweening.DOTween::To(v63, v77, endValue, duration);\n\tv145 = DG.Tweening.TweenSettingsExtensions::SetOptions(v141, snapping);\n\tv147 = DG.Tweening.TweenSettingsExtensions::SetTarget(v145, v56.target);\n\treturn v141;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector2, Vector2, VectorOptions> DOAnchorMin(this RectTransform target, Vector2 endValue, float duration, bool snapping = false)
		{
			DOGetter<Vector2> getter = () => target.anchorMin;
			DOSetter<Vector2> setter = delegate(Vector2 x)
			{
				target.anchorMin = x;
			};
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			Tweener t = tweenerCore.SetOptions(snapping);
			Tweener tweener = t.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x600003A")]
		[Address(RVA = "0x157AD7C", Offset = "0x157AD7C", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv32 = *([1EE9210]);\n\tv33 = *([v32 @ X8_v22]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, endValue, v0, duration, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([202917A]) = v49;\nL_001E:\n\tv53 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass22_0();\n\tSystem.Object::.ctor(v53);\n\tv53.target = target;\n\tv60 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v60, v53, Il2CppMethodInfo);\n\tv74 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v74, v53, Il2CppMethodInfo);\n\tgoto L_0052;\n\tv127 = *([v123 @ X0_v10+E0]);\n\tv128 = v127 == 0;\n\tv129 = ~v128;\n\tif (v129) goto L_0052;\n\tv131 = \"il2cpp_codegen_runtime_class_init\"(v123, v118, v120, v87, v38, v39, v40, v41, endValue, v0, duration, v42, v43, v44, v45, v46);\nL_0052:\n\tv136 = DG.Tweening.DOTween::To(v60, v74, endValue, duration);\n\tv139 = DG.Tweening.TweenSettingsExtensions::SetTarget(v136, v53.target);\n\treturn v136;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector2, Vector2, VectorOptions> DOPivot(this RectTransform target, Vector2 endValue, float duration)
		{
			DOGetter<Vector2> getter = () => target.pivot;
			DOSetter<Vector2> setter = delegate(Vector2 x)
			{
				target.pivot = x;
			};
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x600003B")]
		[Address(RVA = "0x157AED4", Offset = "0x157AED4", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1EB18D8]);\n\tv29 = *([v28 @ X8_v22]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202917B]) = v46;\nL_001B:\n\tv50 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass23_0();\n\tSystem.Object::.ctor(v50);\n\tv50.target = target;\n\tv57 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v57, v50, Il2CppMethodInfo);\n\tv71 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v71, v50, Il2CppMethodInfo);\n\tv80 = 0;\n\tv124 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(&v80 @ stack_-28_v1, 0, Il2CppMethodInfo);\n\tgoto L_0054;\n\tv131 = *([v127 @ X0_v12+E0]);\n\tv132 = v131 == 0;\n\tv133 = ~v132;\n\tif (v133) goto L_0054;\n\tv135 = \"il2cpp_codegen_runtime_class_init\"(v127, v123, v118, v119, v34, v35, v36, v37, v122, v121, v38, v39, v40, v41, v42, v43);\nL_0054:\n\t// 84 MakeStruct v75 @ AGG157AFF0_2_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0, v137 @ stack_-24\n\tv141 = DG.Tweening.DOTween::To(v57, v71, v75, duration);\n\tv145 = DG.Tweening.TweenSettingsExtensions::SetOptions(v141, 2, 0);\n\tv147 = DG.Tweening.TweenSettingsExtensions::SetTarget(v145, v50.target);\n\treturn v141;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector2, Vector2, VectorOptions> DOPivotX(this RectTransform target, float endValue, float duration)
		{
			//IL_004d: Expected O, but got I4
			//IL_006d: Expected F4, but got O
			DOGetter<Vector2> getter = () => target.pivot;
			DOSetter<Vector2> setter = delegate(Vector2 x)
			{
				target.pivot = x;
			};
			object obj = 0;
			Vector2 endValue2 = default(Vector2);
			endValue2.x = 0f;
			object obj2 = default(object);
			endValue2.y = (float)obj2;
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue2, duration);
			Tweener t = tweenerCore.SetOptions(AxisConstraint.X);
			Tweener tweener = t.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x600003C")]
		[Address(RVA = "0x157B044", Offset = "0x157B044", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1F07378]);\n\tv29 = *([v28 @ X8_v22]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202917C]) = v46;\nL_001B:\n\tv50 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass24_0();\n\tSystem.Object::.ctor(v50);\n\tv50.target = target;\n\tv57 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v57, v50, Il2CppMethodInfo);\n\tv71 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v71, v50, Il2CppMethodInfo);\n\tv80 = 0;\n\tv124 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(&v80 @ stack_-28_v1, 0, Il2CppMethodInfo);\n\tgoto L_0054;\n\tv131 = *([v127 @ X0_v12+E0]);\n\tv132 = v131 == 0;\n\tv133 = ~v132;\n\tif (v133) goto L_0054;\n\tv135 = \"il2cpp_codegen_runtime_class_init\"(v127, v123, v118, v119, v34, v35, v36, v37, v121, v122, v38, v39, v40, v41, v42, v43);\nL_0054:\n\t// 84 MakeStruct v75 @ AGG157B160_2_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0, v137 @ stack_-24\n\tv141 = DG.Tweening.DOTween::To(v57, v71, v75, duration);\n\tv145 = DG.Tweening.TweenSettingsExtensions::SetOptions(v141, 4, 0);\n\tv147 = DG.Tweening.TweenSettingsExtensions::SetTarget(v145, v50.target);\n\treturn v141;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector2, Vector2, VectorOptions> DOPivotY(this RectTransform target, float endValue, float duration)
		{
			//IL_004d: Expected O, but got I4
			//IL_006d: Expected F4, but got O
			DOGetter<Vector2> getter = () => target.pivot;
			DOSetter<Vector2> setter = delegate(Vector2 x)
			{
				target.pivot = x;
			};
			object obj = 0;
			Vector2 endValue2 = default(Vector2);
			endValue2.x = 0f;
			object obj2 = default(object);
			endValue2.y = (float)obj2;
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue2, duration);
			Tweener t = tweenerCore.SetOptions(AxisConstraint.Y);
			Tweener tweener = t.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x600003D")]
		[Address(RVA = "0x157B1B4", Offset = "0x157B1B4", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv36 = *([1EF7B20]);\n\tv37 = *([v36 @ X8_v22]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, snapping, methodInfo, v40, v41, v42, v43, v44, endValue, v0, duration, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([202917D]) = v52;\nL_0020:\n\tv56 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass25_0();\n\tSystem.Object::.ctor(v56);\n\tv56.target = target;\n\tv63 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v63, v56, Il2CppMethodInfo);\n\tv77 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v77, v56, Il2CppMethodInfo);\n\tgoto L_0054;\n\tv132 = *([v128 @ X0_v10+E0]);\n\tv133 = v132 == 0;\n\tv134 = ~v133;\n\tif (v134) goto L_0054;\n\tv136 = \"il2cpp_codegen_runtime_class_init\"(v128, v123, v125, v90, v41, v42, v43, v44, endValue, v0, duration, v45, v46, v47, v48, v49);\nL_0054:\n\tv141 = DG.Tweening.DOTween::To(v63, v77, endValue, duration);\n\tv145 = DG.Tweening.TweenSettingsExtensions::SetOptions(v141, snapping);\n\tv147 = DG.Tweening.TweenSettingsExtensions::SetTarget(v145, v56.target);\n\treturn v141;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector2, Vector2, VectorOptions> DOSizeDelta(this RectTransform target, Vector2 endValue, float duration, bool snapping = false)
		{
			DOGetter<Vector2> getter = () => target.sizeDelta;
			DOSetter<Vector2> setter = delegate(Vector2 x)
			{
				target.sizeDelta = x;
			};
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			Tweener t = tweenerCore.SetOptions(snapping);
			Tweener tweener = t.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x600003E")]
		[Address(RVA = "0x157B31C", Offset = "0x157B31C", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv46 = *([1EF0780]);\n\tv47 = *([v46 @ X8_v27]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, vibrato, snapping, methodInfo, v50, v51, v52, v53, punch, v0, duration, elasticity, v54, v55, v56, v57);\n\tv60 = 0 | 1;\n\t*([202917E]) = v60;\nL_0025:\n\tv64 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass26_0();\n\tSystem.Object::.ctor(v64);\n\tv64.target = target;\n\tv71 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v71, v64, Il2CppMethodInfo);\n\tv85 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v85, v64, Il2CppMethodInfo);\n\tgoto L_0056;\n\tv154 = *([v150 @ X0_v10+E0]);\n\tv155 = v154 == 0;\n\tv156 = ~v155;\n\tif (v156) goto L_0056;\n\tv158 = \"il2cpp_codegen_runtime_class_init\"(v150, v144, v146, v147, v50, v51, v52, v53, punch, v0, duration, elasticity, v54, v55, v56, v57);\nL_0056:\n\tv164 = UnityEngine.Vector2::op_Implicit(punch);\n\tgoto L_0072;\n\tv176 = *([v172 @ X0_v13+E0]);\n\tv177 = v176 == 0;\n\tv178 = ~v177;\n\tif (v178) goto L_0072;\n\tv180 = \"il2cpp_codegen_runtime_class_init\"(v172, v144, v146, v147, v50, v51, v52, v53, v164, v165, v166, elasticity, v54, v55, v56, v57);\nL_0072:\n\tv185 = DG.Tweening.DOTween::Punch(v71, v85, v164, duration, vibrato, elasticity);\n\tv189 = DG.Tweening.TweenSettingsExtensions::SetTarget(v185, v64.target);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetOptions(v189, snapping);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 108 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOPunchAnchorPos(this RectTransform target, Vector2 punch, float duration, int vibrato = 10, float elasticity = 1f, bool snapping = false)
		{
			DOGetter<Vector3> getter = delegate
			{
				Vector2 anchoredPosition = target.anchoredPosition;
				return anchoredPosition;
			};
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				Vector2 anchoredPosition = x;
				target.anchoredPosition = anchoredPosition;
			};
			Vector3 direction = punch;
			TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = DOTween.Punch(getter, setter, direction, duration, vibrato, elasticity);
			TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t2 = t.SetTarget(target);
			return t2.SetOptions(snapping);
		}

		[Token(Token = "0x600003F")]
		[Address(RVA = "0x157B4D8", Offset = "0x157B4D8", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv44 = *([1ECB528]);\n\tv45 = *([v44 @ X8_v24]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, vibrato, snapping, fadeOut, methodInfo, v48, v49, v50, duration, strength, randomness, v51, v52, v53, v54, v55);\n\tv58 = 0 | 1;\n\t*([202917F]) = v58;\nL_0023:\n\tv62 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass27_0();\n\tSystem.Object::.ctor(v62);\n\tv62.target = target;\n\tv69 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v69, v62, Il2CppMethodInfo);\n\tv83 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v83, v62, Il2CppMethodInfo);\n\tgoto L_0059;\n\tv144 = *([v140 @ X0_v10+E0]);\n\tv145 = v144 == 0;\n\tv146 = ~v145;\n\tif (v146) goto L_0059;\n\tv148 = \"il2cpp_codegen_runtime_class_init\"(v140, v134, v136, v137, methodInfo, v48, v49, v50, duration, strength, randomness, v51, v52, v53, v54, v55);\nL_0059:\n\tv153 = DG.Tweening.DOTween::Shake(v69, v83, duration, strength, vibrato, randomness, 1, fadeOut);\n\tv158 = DG.Tweening.TweenSettingsExtensions::SetTarget(v153, v62.target);\n\tv162 = DG.Tweening.Core.Extensions::SetSpecialStartupMode(v158, 2);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetOptions(v162, snapping);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOShakeAnchorPos(this RectTransform target, float duration, float strength = 100f, int vibrato = 10, float randomness = 90f, bool snapping = false, bool fadeOut = true)
		{
			DOGetter<Vector3> getter = delegate
			{
				Vector2 anchoredPosition = target.anchoredPosition;
				return anchoredPosition;
			};
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				Vector2 anchoredPosition = x;
				target.anchoredPosition = anchoredPosition;
			};
			TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = DOTween.Shake(getter, setter, duration, strength, vibrato, randomness, ignoreZAxis: true, fadeOut);
			TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t2 = t.SetTarget(target);
			TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t3 = t2.SetSpecialStartupMode(SpecialStartupMode.SetShake);
			return t3.SetOptions(snapping);
		}

		[Token(Token = "0x6000040")]
		[Address(RVA = "0x157B664", Offset = "0x157B664", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv50 = *([1EAF648]);\n\tv51 = *([v50 @ X8_v29]);\n\tv52 = \"il2cpp_codegen_initialize_method\"(v51, vibrato, snapping, fadeOut, methodInfo, v54, v55, v56, duration, strength, v0, randomness, v57, v58, v59, v60);\n\tv63 = 0 | 1;\n\t*([2029180]) = v63;\nL_0027:\n\tv67 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass28_0();\n\tSystem.Object::.ctor(v67);\n\tv67.target = target;\n\tv74 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v74, v67, Il2CppMethodInfo);\n\tv88 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v88, v67, Il2CppMethodInfo);\n\tgoto L_0058;\n\tv161 = *([v157 @ X0_v10+E0]);\n\tv162 = v161 == 0;\n\tv163 = ~v162;\n\tif (v163) goto L_0058;\n\tv165 = \"il2cpp_codegen_runtime_class_init\"(v157, v151, v153, v154, methodInfo, v54, v55, v56, duration, strength, v0, randomness, v57, v58, v59, v60);\nL_0058:\n\tv171 = UnityEngine.Vector2::op_Implicit(strength);\n\tgoto L_0075;\n\tv183 = *([v179 @ X0_v13+E0]);\n\tv184 = v183 == 0;\n\tv185 = ~v184;\n\tif (v185) goto L_0075;\n\tv187 = \"il2cpp_codegen_runtime_class_init\"(v179, v151, v153, v154, methodInfo, v54, v55, v56, v171, v172, v173, randomness, v57, v58, v59, v60);\nL_0075:\n\tv192 = DG.Tweening.DOTween::Shake(v74, v88, duration, v171, vibrato, randomness, fadeOut);\n\tv197 = DG.Tweening.TweenSettingsExtensions::SetTarget(v192, v67.target);\n\tv201 = DG.Tweening.Core.Extensions::SetSpecialStartupMode(v197, 2);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetOptions(v201, snapping);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 116 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOShakeAnchorPos(this RectTransform target, float duration, Vector2 strength, int vibrato = 10, float randomness = 90f, bool snapping = false, bool fadeOut = true)
		{
			DOGetter<Vector3> getter = delegate
			{
				Vector2 anchoredPosition = target.anchoredPosition;
				return anchoredPosition;
			};
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				Vector2 anchoredPosition = x;
				target.anchoredPosition = anchoredPosition;
			};
			Vector3 strength2 = strength;
			TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = DOTween.Shake(getter, setter, duration, strength2, vibrato, randomness, fadeOut);
			TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t2 = t.SetTarget(target);
			TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t3 = t2.SetSpecialStartupMode(SpecialStartupMode.SetShake);
			return t3.SetOptions(snapping);
		}

		[Token(Token = "0x6000041")]
		[Address(RVA = "0x157B83C", Offset = "0x157B83C", Length = "0x380")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv54 = *([1EA4020]);\n\tv55 = *([v54 @ X8_v45]);\n\tv56 = \"il2cpp_codegen_initialize_method\"(v55, numJumps, snapping, methodInfo, v58, v59, v60, v61, endValue, v0, jumpPower, duration, v62, v63, v64, v65);\n\tv68 = 0 | 1;\n\t*([2029181]) = v68;\nL_0029:\n\tv72 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass29_0();\n\tSystem.Object::.ctor(v72);\n\tv72.target = target;\n\tv72.endValue = endValue;\n\tv72.endValue.y = endValue.y;\n\tv72.startPosY = 0f;\n\tv72.offsetYSet = 0;\n\tv72.offsetY = -1f;\n\tv81 = numJumps - 1;\n\tv82 = v81 < 0;\n\tv83 = v81 == 0;\n\tv84 = numJumps ^ 1;\n\tv85 = numJumps ^ v81;\n\tv86 = v84 & v85;\n\tv87 = v86 < 0;\n\tv88 = v82 == v87;\n\tv89 = ~v83;\n\tv90 = v88 & v89;\n\tv91 = ~v90;\n\tif (v91) goto L_FFFFFFFF;\n\tgoto L_004E;\nL_004E:\n\tgoto L_0055;\n\tv188 = *([v97 @ X0_v6+E0]);\n\tv189 = v188 == 0;\n\tv190 = ~v189;\n\tgoto L_0055;\n\tv192 = \"il2cpp_codegen_runtime_class_init\"(v97, v73, snapping, methodInfo, v58, v59, v60, v61, endValue, v0, jumpPower, duration, v62, v63, v64, v65);\nL_0055:\n\tv195 = DG.Tweening.DOTween::Sequence();\n\tv72.s = v195;\n\tv199 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v199, v72, Il2CppMethodInfo);\n\tv211 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v211, v72, Il2CppMethodInfo);\n\tv120 = 0;\n\tv224 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(&v120 @ stack_-88_v1, 0, Il2CppMethodInfo);\n\tv228 = v96 << 1;\n\tv230 = duration / v228;\n\t// 127 MakeStruct v115 @ AGG157B9AC_2_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0, v227 @ stack_-84\n\tv234 = DG.Tweening.DOTween::To(v199, v211, v115, v230);\n\tv239 = DG.Tweening.TweenSettingsExtensions::SetOptions(v234, 4, snapping);\n\tv244 = DG.Tweening.TweenSettingsExtensions::SetEase(v239, 6);\n\tv248 = DG.Tweening.TweenSettingsExtensions::SetRelative(v244);\n\tv254 = DG.Tweening.TweenSettingsExtensions::SetLoops(v248, v228, 1);\n\tv260 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v260, v72, Il2CppMethodInfo);\n\tv272 = DG.Tweening.TweenSettingsExtensions::OnStart(v254, v260);\n\tv277 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v277, v72, Il2CppMethodInfo);\n\tv285 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v285, v72, Il2CppMethodInfo);\n\tv110 = 0;\n\tv296 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(&v110 @ stack_-90_v1, 0, Il2CppMethodInfo);\n\t// 201 MakeStruct v107 @ AGG157BACC_2_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0, v297 @ stack_-8C\n\tv301 = DG.Tweening.DOTween::To(v277, v285, v107, duration);\n\tv305 = DG.Tweening.TweenSettingsExtensions::SetOptions(v301, 2, snapping);\n\tv308 = DG.Tweening.TweenSettingsExtensions::SetEase(v305, 1);\n\tv312 = DG.Tweening.TweenSettingsExtensions::Append(v72.s, v308);\n\tv315 = DG.Tweening.TweenSettingsExtensions::Join(v312, v272);\n\tv320 = DG.Tweening.TweenSettingsExtensions::SetTarget(v315, v72.target);\n\tv328 = DG.Tweening.TweenSettingsExtensions::SetEase(v320, v325.defaultEaseType);\n\tv333 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v333, v72, Il2CppMethodInfo);\n\tv341 = DG.Tweening.TweenSettingsExtensions::OnUpdate(v72.s, v333);\n\treturn v72.s;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 199 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sequence DOJumpAnchorPos(this RectTransform target, Vector2 endValue, float jumpPower, int numJumps, float duration, bool snapping = false)
		{
			//IL_016e: Expected O, but got I4
			//IL_01ac: Expected F4, but got O
			//IL_0284: Expected O, but got I4
			//IL_029f: Expected F4, but got O
			Vector2 endValue2 = endValue;
			endValue2.y = endValue.y;
			float startPosY = 0f;
			bool offsetYSet = false;
			float offsetY = -1f;
			int num = numJumps - 1;
			bool flag = num < 0;
			bool flag2 = num == 0;
			int num2 = numJumps ^ 1;
			int num3 = numJumps ^ num;
			int num4 = num2 & num3;
			bool flag3 = num4 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			int num5 = ((!(flag4 && flag5)) ? 1 : numJumps);
			Sequence sequence = DOTween.Sequence();
			Sequence s = sequence;
			DOGetter<Vector2> getter = () => target.anchoredPosition;
			DOSetter<Vector2> setter = delegate(Vector2 x)
			{
				target.anchoredPosition = x;
			};
			object obj = 0;
			int num6 = num5 << 1;
			float duration2 = duration / (float)num6;
			Vector2 endValue3 = default(Vector2);
			endValue3.x = 0f;
			object obj2 = default(object);
			endValue3.y = (float)obj2;
			TweenerCore<Vector2, Vector2, VectorOptions> t = DOTween.To(getter, setter, endValue3, duration2);
			Tweener t2 = t.SetOptions(AxisConstraint.Y, snapping);
			Tweener relative = t2.SetEase(Ease.OutQuad);
			Tweener t3 = relative.SetRelative();
			Tweener t4 = t3.SetLoops(num6, LoopType.Yoyo);
			TweenCallback action = delegate
			{
				startPosY = target.anchoredPosition.y;
			};
			Tweener t5 = t4.OnStart(action);
			DOGetter<Vector2> getter2 = () => target.anchoredPosition;
			DOSetter<Vector2> setter2 = delegate(Vector2 x)
			{
				target.anchoredPosition = x;
			};
			object obj3 = 0;
			Vector2 endValue4 = default(Vector2);
			endValue4.x = 0f;
			object obj4 = default(object);
			endValue4.y = (float)obj4;
			TweenerCore<Vector2, Vector2, VectorOptions> t6 = DOTween.To(getter2, setter2, endValue4, duration);
			Tweener t7 = t6.SetOptions(AxisConstraint.X, snapping);
			Tweener t8 = t7.SetEase(Ease.Linear);
			Sequence s2 = s.Append(t8);
			Sequence t9 = s2.Join(t5);
			Sequence t10 = t9.SetTarget(target);
			Sequence sequence2 = t10.SetEase(DOTween.defaultEaseType);
			TweenCallback action2 = delegate
			{
				if (!offsetYSet)
				{
					Sequence sequence4 = s;
					offsetYSet = true;
					float num7 = endValue2.y;
					if (!sequence4.isRelative)
					{
						num7 -= startPosY;
					}
					offsetY = num7;
				}
				Vector2 anchoredPosition = target.anchoredPosition;
				float lifetimePercentage = s.ElapsedDirectionalPercentage();
				float num8 = DOVirtual.EasedValue(0f, offsetY, lifetimePercentage, Ease.OutQuad);
				float y = anchoredPosition.y + num8;
				Vector2 anchoredPosition2 = default(Vector2);
				anchoredPosition2.x = anchoredPosition.x;
				anchoredPosition2.y = y;
				target.anchoredPosition = anchoredPosition2;
			};
			Sequence sequence3 = s.OnUpdate(action2);
			return s;
		}

		[Token(Token = "0x6000042")]
		[Address(RVA = "0x157BBC4", Offset = "0x157BBC4", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv36 = *([1EB4078]);\n\tv37 = *([v36 @ X8_v22]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, snapping, methodInfo, v40, v41, v42, v43, v44, endValue, v0, duration, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2029182]) = v52;\nL_0020:\n\tv56 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass30_0();\n\tSystem.Object::.ctor(v56);\n\tv56.target = target;\n\tv63 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v63, v56, Il2CppMethodInfo);\n\tv77 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v77, v56, Il2CppMethodInfo);\n\tgoto L_0054;\n\tv132 = *([v128 @ X0_v10+E0]);\n\tv133 = v132 == 0;\n\tv134 = ~v133;\n\tif (v134) goto L_0054;\n\tv136 = \"il2cpp_codegen_runtime_class_init\"(v128, v123, v125, v90, v41, v42, v43, v44, endValue, v0, duration, v45, v46, v47, v48, v49);\nL_0054:\n\tv141 = DG.Tweening.DOTween::To(v63, v77, endValue, duration);\n\tv144 = DG.Tweening.TweenSettingsExtensions::SetOptions(v141, snapping);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v144, v56.target);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DONormalizedPos(this ScrollRect target, Vector2 endValue, float duration, bool snapping = false)
		{
			DOGetter<Vector2> getter = delegate
			{
				float horizontalNormalizedPosition = target.horizontalNormalizedPosition;
				float verticalNormalizedPosition = target.verticalNormalizedPosition;
				Vector2 vector = default(Vector2);
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
				return default(Vector2);
			};
			DOSetter<Vector2> setter = delegate(Vector2 x)
			{
				Vector2 vector = default(Vector2);
				target.horizontalNormalizedPosition = vector.x;
				target.verticalNormalizedPosition = x.y;
			};
			TweenerCore<Vector2, Vector2, VectorOptions> t = DOTween.To(getter, setter, endValue, duration);
			Tweener t2 = t.SetOptions(snapping);
			return t2.SetTarget(target);
		}

		[Token(Token = "0x6000043")]
		[Address(RVA = "0x157BD20", Offset = "0x157BD20", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv32 = *([1EBAF18]);\n\tv33 = *([v32 @ X8_v22]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, snapping, methodInfo, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2029183]) = v49;\nL_001D:\n\tv53 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass31_0();\n\tSystem.Object::.ctor(v53);\n\tv53.target = target;\n\tv60 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v60, v53, Il2CppMethodInfo);\n\tv74 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v74, v53, Il2CppMethodInfo);\n\tgoto L_004F;\n\tv122 = *([v118 @ X0_v10+E0]);\n\tv123 = v122 == 0;\n\tv124 = ~v123;\n\tif (v124) goto L_004F;\n\tv126 = \"il2cpp_codegen_runtime_class_init\"(v118, v113, v115, v84, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\nL_004F:\n\tv131 = DG.Tweening.DOTween::To(v60, v74, endValue, duration);\n\tv134 = DG.Tweening.TweenSettingsExtensions::SetOptions(v131, snapping);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v134, v53.target);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOHorizontalNormalizedPos(this ScrollRect target, float endValue, float duration, bool snapping = false)
		{
			DOGetter<float> getter = () => target.horizontalNormalizedPosition;
			DOSetter<float> setter = delegate(float x)
			{
				target.horizontalNormalizedPosition = x;
			};
			TweenerCore<float, float, FloatOptions> t = DOTween.To(getter, setter, endValue, duration);
			Tweener t2 = t.SetOptions(snapping);
			return t2.SetTarget(target);
		}

		[Token(Token = "0x6000044")]
		[Address(RVA = "0x157BE6C", Offset = "0x157BE6C", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv32 = *([1EE69F8]);\n\tv33 = *([v32 @ X8_v22]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, snapping, methodInfo, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2029184]) = v49;\nL_001D:\n\tv53 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass32_0();\n\tSystem.Object::.ctor(v53);\n\tv53.target = target;\n\tv60 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v60, v53, Il2CppMethodInfo);\n\tv74 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v74, v53, Il2CppMethodInfo);\n\tgoto L_004F;\n\tv122 = *([v118 @ X0_v10+E0]);\n\tv123 = v122 == 0;\n\tv124 = ~v123;\n\tif (v124) goto L_004F;\n\tv126 = \"il2cpp_codegen_runtime_class_init\"(v118, v113, v115, v84, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\nL_004F:\n\tv131 = DG.Tweening.DOTween::To(v60, v74, endValue, duration);\n\tv134 = DG.Tweening.TweenSettingsExtensions::SetOptions(v131, snapping);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v134, v53.target);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOVerticalNormalizedPos(this ScrollRect target, float endValue, float duration, bool snapping = false)
		{
			DOGetter<float> getter = () => target.verticalNormalizedPosition;
			DOSetter<float> setter = delegate(float x)
			{
				target.verticalNormalizedPosition = x;
			};
			TweenerCore<float, float, FloatOptions> t = DOTween.To(getter, setter, endValue, duration);
			Tweener t2 = t.SetOptions(snapping);
			return t2.SetTarget(target);
		}

		[Token(Token = "0x6000045")]
		[Address(RVA = "0x157BFB8", Offset = "0x157BFB8", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv32 = *([1EA3D40]);\n\tv33 = *([v32 @ X8_v22]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, snapping, methodInfo, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2029185]) = v49;\nL_001D:\n\tv53 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass33_0();\n\tSystem.Object::.ctor(v53);\n\tv53.target = target;\n\tv60 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v60, v53, Il2CppMethodInfo);\n\tv74 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v74, v53, Il2CppMethodInfo);\n\tgoto L_004F;\n\tv122 = *([v118 @ X0_v10+E0]);\n\tv123 = v122 == 0;\n\tv124 = ~v123;\n\tif (v124) goto L_004F;\n\tv126 = \"il2cpp_codegen_runtime_class_init\"(v118, v113, v115, v84, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\nL_004F:\n\tv131 = DG.Tweening.DOTween::To(v60, v74, endValue, duration);\n\tv135 = DG.Tweening.TweenSettingsExtensions::SetOptions(v131, snapping);\n\tv137 = DG.Tweening.TweenSettingsExtensions::SetTarget(v135, v53.target);\n\treturn v131;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<float, float, FloatOptions> DOValue(this Slider target, float endValue, float duration, bool snapping = false)
		{
			DOGetter<float> getter = delegate
			{
				//IL_0017: Expected I, but got O
				//IL_0027: Expected O, but got I
				//IL_0037: Expected O, but got I
				Slider slider = target;
				IntPtr intPtr = (IntPtr)slider;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v1 (Il2CppClass<UnityEngine.UI.Slider>)+410]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v1 (Il2CppClass<UnityEngine.UI.Slider>)+418]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ X2_v1 (should have been resolved before IL gen)");
				return 0f;
			};
			DOSetter<float> setter = delegate
			{
				//IL_0017: Expected I, but got O
				//IL_0027: Expected O, but got I
				//IL_0037: Expected O, but got I
				Slider slider = target;
				IntPtr intPtr = (IntPtr)slider;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v1 (Il2CppClass<UnityEngine.UI.Slider>)+420]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v1 (Il2CppClass<UnityEngine.UI.Slider>)+428]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ X2_v1 (should have been resolved before IL gen)");
			};
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			Tweener t = tweenerCore.SetOptions(snapping);
			Tweener tweener = t.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x6000046")]
		[Address(RVA = "0x157C110", Offset = "0x157C110", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv40 = *([1EBA098]);\n\tv41 = *([v40 @ X8_v22]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, methodInfo, v44, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2029186]) = v55;\nL_0024:\n\tv59 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass34_0();\n\tSystem.Object::.ctor(v59);\n\tv59.target = target;\n\tv66 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v66, v59, Il2CppMethodInfo);\n\tv80 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v80, v59, Il2CppMethodInfo);\n\tgoto L_005A;\n\tv141 = *([v137 @ X0_v10+E0]);\n\tv142 = v141 == 0;\n\tv143 = ~v142;\n\tif (v143) goto L_005A;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v137, v132, v134, v93, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\nL_005A:\n\tv150 = DG.Tweening.DOTween::To(v66, v80, endValue, duration);\n\tv153 = DG.Tweening.TweenSettingsExtensions::SetTarget(v150, v59.target);\n\treturn v150;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Color, Color, ColorOptions> DOColor(this Text target, Color endValue, float duration)
		{
			DOGetter<Color> getter = delegate
			{
				//IL_0017: Expected I, but got O
				//IL_0027: Expected O, but got I
				//IL_0037: Expected O, but got I
				//IL_0043: Expected O, but got I4
				Text text = target;
				IntPtr intPtr = (IntPtr)text;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v1 (Il2CppClass<UnityEngine.UI.Text>)+290]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v1 (Il2CppClass<UnityEngine.UI.Text>)+298]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ X2_v1 (should have been resolved before IL gen)");
				return (Color)0;
			};
			DOSetter<Color> setter = delegate(Color x)
			{
				//IL_003e: Expected I, but got O
				//IL_004e: Expected O, but got I
				//IL_005e: Expected O, but got I
				float g = x.g;
				float b = x.b;
				float a = x.a;
				Text text = target;
				IntPtr intPtr = (IntPtr)text;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ X8_v1 (Il2CppClass<UnityEngine.UI.Text>)+2A0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ X8_v1 (Il2CppClass<UnityEngine.UI.Text>)+2A8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v8 @ X2_v1 (should have been resolved before IL gen)");
			};
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<Color, Color, ColorOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x6000047")]
		[Address(RVA = "0x157C280", Offset = "0x157C280", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1F0D3F8]);\n\tv29 = *([v28 @ X8_v22]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2029187]) = v46;\nL_001B:\n\tv50 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass35_0();\n\tSystem.Object::.ctor(v50);\n\tv50.target = target;\n\tv57 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v57, v50, Il2CppMethodInfo);\n\tv71 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v71, v50, Il2CppMethodInfo);\n\tgoto L_004D;\n\tv117 = *([v113 @ X0_v10+E0]);\n\tv118 = v117 == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_004D;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v113, v108, v110, v81, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\nL_004D:\n\tv126 = DG.Tweening.DOTween::ToAlpha(v57, v71, endValue, duration);\n\tv129 = DG.Tweening.TweenSettingsExtensions::SetTarget(v126, v50.target);\n\treturn v126;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Color, Color, ColorOptions> DOFade(this Text target, float endValue, float duration)
		{
			DOGetter<Color> getter = delegate
			{
				//IL_0017: Expected I, but got O
				//IL_0027: Expected O, but got I
				//IL_0037: Expected O, but got I
				//IL_0043: Expected O, but got I4
				Text text = target;
				IntPtr intPtr = (IntPtr)text;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v1 (Il2CppClass<UnityEngine.UI.Text>)+290]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v1 (Il2CppClass<UnityEngine.UI.Text>)+298]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ X2_v1 (should have been resolved before IL gen)");
				return (Color)0;
			};
			DOSetter<Color> setter = delegate(Color x)
			{
				//IL_003e: Expected I, but got O
				//IL_004e: Expected O, but got I
				//IL_005e: Expected O, but got I
				float g = x.g;
				float b = x.b;
				float a = x.a;
				Text text = target;
				IntPtr intPtr = (IntPtr)text;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ X8_v1 (Il2CppClass<UnityEngine.UI.Text>)+2A0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ X8_v1 (Il2CppClass<UnityEngine.UI.Text>)+2A8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v8 @ X2_v1 (should have been resolved before IL gen)");
			};
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.ToAlpha(getter, setter, endValue, duration);
			TweenerCore<Color, Color, ColorOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x6000048")]
		[Address(RVA = "0x157C3C8", Offset = "0x157C3C8", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv40 = *([1F0B340]);\n\tv41 = *([v40 @ X8_v38]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, endValue, richTextEnabled, scrambleMode, scrambleChars, methodInfo, v44, v45, duration, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2029188]) = v55;\nL_0021:\n\tv59 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass36_0();\n\tSystem.Object::.ctor(v59);\n\tv59.target = target;\n\tv63 = endValue == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_0052;\n\tgoto L_0045;\n\tv112 = *([1ED7170]);\n\tv113 = *([v112 @ X8_v34]);\n\tv114 = \"il2cpp_codegen_initialize_method\"(v113, v60, richTextEnabled, scrambleMode, scrambleChars, methodInfo, v44, v45, duration, v46, v47, v48, v49, v50, v51, v52);\n\tv117 = 0 | 1;\n\t*([2022B9B]) = v117;\nL_0045:\n\tv72 = v121._logPriority < 1;\n\tif (v72) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogWarning(\"You can't pass a NULL string to DOText: an empty string will be used instead to avoid errors\");\nL_0052:\n\tv110 = new DG.Tweening.Core.DOGetter`1<System.String>();\n\tDG.Tweening.Core.DOGetter`1<System.String>::.ctor(v110, v59, Il2CppMethodInfo);\n\tv190 = new DG.Tweening.Core.DOSetter`1<System.String>();\n\tDG.Tweening.Core.DOSetter`1<System.String>::.ctor(v190, v59, Il2CppMethodInfo);\n\tgoto L_007A;\n\tv204 = *([v200 @ X0_v11+E0]);\n\tv205 = v204 == 0;\n\tv206 = ~v205;\n\tif (v206) goto L_007A;\n\tv208 = \"il2cpp_codegen_runtime_class_init\"(v200, v194, v196, v197, scrambleChars, methodInfo, v44, v45, duration, v46, v47, v48, v49, v50, v51, v52);\nL_007A:\n\tv214 = DG.Tweening.DOTween::To(v110, v190, v103, duration);\n\tv218 = DG.Tweening.TweenSettingsExtensions::SetOptions(v214, richTextEnabled, scrambleMode, scrambleChars);\n\tv220 = DG.Tweening.TweenSettingsExtensions::SetTarget(v218, v59.target);\n\treturn v214;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 113 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<string, string, StringOptions> DOText(this Text target, string endValue, float duration, bool richTextEnabled = true, ScrambleMode scrambleMode = ScrambleMode.None, string scrambleChars = null)
		{
			bool flag = endValue == null;
			bool flag2 = !flag;
			string endValue2 = endValue;
			if (!flag2)
			{
				if (Debugger._logPriority >= 1)
				{
					Debugger.LogWarning("You can't pass a NULL string to DOText: an empty string will be used instead to avoid errors");
				}
				endValue2 = "";
			}
			DOGetter<string> getter = delegate
			{
				//IL_0017: Expected I, but got O
				//IL_0027: Expected O, but got I
				//IL_0037: Expected O, but got I
				Text text = target;
				IntPtr intPtr = (IntPtr)text;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v1 (Il2CppClass<UnityEngine.UI.Text>)+5B0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v1 (Il2CppClass<UnityEngine.UI.Text>)+5B8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ X2_v1 (should have been resolved before IL gen)");
				return (string)null;
			};
			DOSetter<string> setter = delegate
			{
				//IL_0017: Expected I, but got O
				//IL_0027: Expected O, but got I
				//IL_0037: Expected O, but got I
				Text text = target;
				IntPtr intPtr = (IntPtr)text;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v1 (Il2CppClass<UnityEngine.UI.Text>)+5C0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v1 (Il2CppClass<UnityEngine.UI.Text>)+5C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ X3_v1 (should have been resolved before IL gen)");
			};
			TweenerCore<string, string, StringOptions> tweenerCore = DOTween.To(getter, setter, endValue2, duration);
			Tweener t = tweenerCore.SetOptions(richTextEnabled, scrambleMode, scrambleChars);
			Tweener tweener = t.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x6000049")]
		[Address(RVA = "0x157C5A4", Offset = "0x157C5A4", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv40 = *([1EAE0C8]);\n\tv41 = *([v40 @ X8_v26]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, methodInfo, v44, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2029189]) = v55;\nL_0024:\n\tv59 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass37_0();\n\tSystem.Object::.ctor(v59);\n\tv59.target = target;\n\tv71 = UnityEngine.UI.Graphic::get_color(target);\n\tv83 = UnityEngine.Color::op_Subtraction(endValue, endValue);\n\tv92 = 0;\n\tv99 = 0x101059C(&v92 @ stack_-60_v1 (System.Single), 0, v44, v45, v46, v47, v48, v49, 0, 0, 0, 0, endValue, endValue.g, endValue.b, endValue.a);\n\tv59.to.r = 0f;\n\tv59.to.g = v164;\n\tv59.to.a = v165;\n\tv169 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v169, v59, Il2CppMethodInfo);\n\tv181 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v181, v59, Il2CppMethodInfo);\n\tgoto L_0083;\n\tv194 = *([v190 @ X0_v15+E0]);\n\tv195 = v194 == 0;\n\tv196 = ~v195;\n\tif (v196) goto L_0083;\n\tv198 = \"il2cpp_codegen_runtime_class_init\"(v190, v185, v187, v108, v46, v47, v48, v49, v93, v94, v95, v96, v72, v73, v74, v75);\nL_0083:\n\tv203 = DG.Tweening.DOTween::To(v169, v181, v83, duration);\n\tv207 = DG.Tweening.Core.Extensions::Blendable(v203);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v207, v59.target);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 124 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOBlendableColor(this Graphic target, Color endValue, float duration)
		{
			//IL_0077: Expected F4, but got O
			Graphic target2 = target;
			Color color = target.color;
			Color endValue2 = endValue - endValue;
			float num = 0f;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
			Color to = default(Color);
			to.r = 0f;
			object obj = default(object);
			to.g = (float)obj;
			float a = default(float);
			to.a = a;
			DOGetter<Color> getter = () => to;
			DOSetter<Color> setter = delegate(Color x)
			{
				//IL_00de: Expected I, but got O
				Color color2 = default(Color);
				color2.r = to.r;
				color2.g = to.g;
				color2.b = to.b;
				color2.a = to.a;
				Color color3 = x - color2;
				Graphic graphic = target2;
				to = x;
				to.g = x.g;
				to.b = x.b;
				to.a = x.a;
				Color color4 = target2.color;
				Color color5 = color3 + color3;
				IntPtr intPtr = (IntPtr)graphic;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v78 @ X8_v2 (Il2CppClass<UnityEngine.UI.Graphic>)+2A0] (should have been resolved before IL gen)");
			};
			TweenerCore<Color, Color, ColorOptions> t = DOTween.To(getter, setter, endValue2, duration);
			TweenerCore<Color, Color, ColorOptions> t2 = t.Blendable();
			return t2.SetTarget(target2);
		}

		[Token(Token = "0x600004A")]
		[Address(RVA = "0x157C7AC", Offset = "0x157C7AC", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv40 = *([1EBD1F8]);\n\tv41 = *([v40 @ X8_v26]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, methodInfo, v44, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([202918A]) = v55;\nL_0024:\n\tv59 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass38_0();\n\tSystem.Object::.ctor(v59);\n\tv59.target = target;\n\tv71 = UnityEngine.UI.Graphic::get_color(target);\n\tv83 = UnityEngine.Color::op_Subtraction(endValue, endValue);\n\tv92 = 0;\n\tv99 = 0x101059C(&v92 @ stack_-60_v1 (System.Single), 0, v44, v45, v46, v47, v48, v49, 0, 0, 0, 0, endValue, endValue.g, endValue.b, endValue.a);\n\tv59.to.r = 0f;\n\tv59.to.g = v164;\n\tv59.to.a = v165;\n\tv169 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v169, v59, Il2CppMethodInfo);\n\tv181 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v181, v59, Il2CppMethodInfo);\n\tgoto L_0083;\n\tv194 = *([v190 @ X0_v15+E0]);\n\tv195 = v194 == 0;\n\tv196 = ~v195;\n\tif (v196) goto L_0083;\n\tv198 = \"il2cpp_codegen_runtime_class_init\"(v190, v185, v187, v108, v46, v47, v48, v49, v93, v94, v95, v96, v72, v73, v74, v75);\nL_0083:\n\tv203 = DG.Tweening.DOTween::To(v169, v181, v83, duration);\n\tv207 = DG.Tweening.Core.Extensions::Blendable(v203);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v207, v59.target);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 124 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOBlendableColor(this Image target, Color endValue, float duration)
		{
			//IL_0077: Expected F4, but got O
			Image target2 = target;
			Color color = target.color;
			Color endValue2 = endValue - endValue;
			float num = 0f;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
			Color to = default(Color);
			to.r = 0f;
			object obj = default(object);
			to.g = (float)obj;
			float a = default(float);
			to.a = a;
			DOGetter<Color> getter = () => to;
			DOSetter<Color> setter = delegate(Color x)
			{
				//IL_00de: Expected I, but got O
				Color color2 = default(Color);
				color2.r = to.r;
				color2.g = to.g;
				color2.b = to.b;
				color2.a = to.a;
				Color color3 = x - color2;
				Image image = target2;
				to = x;
				to.g = x.g;
				to.b = x.b;
				to.a = x.a;
				Color color4 = target2.color;
				Color color5 = color3 + color3;
				IntPtr intPtr = (IntPtr)image;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v78 @ X8_v2 (Il2CppClass<UnityEngine.UI.Image>)+2A0] (should have been resolved before IL gen)");
			};
			TweenerCore<Color, Color, ColorOptions> t = DOTween.To(getter, setter, endValue2, duration);
			TweenerCore<Color, Color, ColorOptions> t2 = t.Blendable();
			return t2.SetTarget(target2);
		}

		[Token(Token = "0x600004B")]
		[Address(RVA = "0x157C9B4", Offset = "0x157C9B4", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv40 = *([1EEECA0]);\n\tv41 = *([v40 @ X8_v26]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, methodInfo, v44, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([202918B]) = v55;\nL_0024:\n\tv59 = new DG.Tweening.DOTweenModuleUI+<>c__DisplayClass39_0();\n\tSystem.Object::.ctor(v59);\n\tv59.target = target;\n\tv71 = UnityEngine.UI.Graphic::get_color(target);\n\tv83 = UnityEngine.Color::op_Subtraction(endValue, endValue);\n\tv92 = 0;\n\tv99 = 0x101059C(&v92 @ stack_-60_v1 (System.Single), 0, v44, v45, v46, v47, v48, v49, 0, 0, 0, 0, endValue, endValue.g, endValue.b, endValue.a);\n\tv59.to.r = 0f;\n\tv59.to.g = v164;\n\tv59.to.a = v165;\n\tv169 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v169, v59, Il2CppMethodInfo);\n\tv181 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v181, v59, Il2CppMethodInfo);\n\tgoto L_0083;\n\tv194 = *([v190 @ X0_v15+E0]);\n\tv195 = v194 == 0;\n\tv196 = ~v195;\n\tif (v196) goto L_0083;\n\tv198 = \"il2cpp_codegen_runtime_class_init\"(v190, v185, v187, v108, v46, v47, v48, v49, v93, v94, v95, v96, v72, v73, v74, v75);\nL_0083:\n\tv203 = DG.Tweening.DOTween::To(v169, v181, v83, duration);\n\tv207 = DG.Tweening.Core.Extensions::Blendable(v203);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v207, v59.target);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 124 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOBlendableColor(this Text target, Color endValue, float duration)
		{
			//IL_0077: Expected F4, but got O
			Text target2 = target;
			Color color = target.color;
			Color endValue2 = endValue - endValue;
			float num = 0f;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
			Color to = default(Color);
			to.r = 0f;
			object obj = default(object);
			to.g = (float)obj;
			float a = default(float);
			to.a = a;
			DOGetter<Color> getter = () => to;
			DOSetter<Color> setter = delegate(Color x)
			{
				//IL_00de: Expected I, but got O
				Color color2 = default(Color);
				color2.r = to.r;
				color2.g = to.g;
				color2.b = to.b;
				color2.a = to.a;
				Color color3 = x - color2;
				Text text = target2;
				to = x;
				to.g = x.g;
				to.b = x.b;
				to.a = x.a;
				Color color4 = target2.color;
				Color color5 = color3 + color3;
				IntPtr intPtr = (IntPtr)text;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v78 @ X8_v2 (Il2CppClass<UnityEngine.UI.Text>)+2A0] (should have been resolved before IL gen)");
			};
			TweenerCore<Color, Color, ColorOptions> t = DOTween.To(getter, setter, endValue2, duration);
			TweenerCore<Color, Color, ColorOptions> t2 = t.Blendable();
			return t2.SetTarget(target2);
		}
	}
}
