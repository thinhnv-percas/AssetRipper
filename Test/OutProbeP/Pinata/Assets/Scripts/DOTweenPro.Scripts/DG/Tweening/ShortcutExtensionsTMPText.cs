using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;

namespace DG.Tweening
{
	[Token(Token = "0x2000005")]
	public static class ShortcutExtensionsTMPText
	{
		[Token(Token = "0x600002A")]
		[Address(RVA = "0x15B6D80", Offset = "0x15B6D80", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv40 = *([1F019C8]);\n\tv41 = *([v40 @ X8_v22]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, methodInfo, v44, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([202990E]) = v55;\nL_0024:\n\tv59 = new DG.Tweening.ShortcutExtensionsTMPText+<>c__DisplayClass0_0();\n\tSystem.Object::.ctor(v59);\n\tv59.target = target;\n\tv66 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v66, v59, Il2CppMethodInfo);\n\tv80 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v80, v59, Il2CppMethodInfo);\n\tgoto L_005A;\n\tv141 = *([v137 @ X0_v10+E0]);\n\tv142 = v141 == 0;\n\tv143 = ~v142;\n\tif (v143) goto L_005A;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v137, v132, v134, v93, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\nL_005A:\n\tv150 = DG.Tweening.DOTween::To(v66, v80, endValue, duration);\n\tv153 = DG.Tweening.TweenSettingsExtensions::SetTarget(v150, v59.target);\n\treturn v150;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Color, Color, ColorOptions> DOColor(this TMP_Text target, Color endValue, float duration)
		{
			DOGetter<Color> getter = delegate
			{
				//IL_0017: Expected I, but got O
				//IL_0027: Expected O, but got I
				//IL_0037: Expected O, but got I
				//IL_0043: Expected O, but got I4
				TMP_Text tMP_Text = target;
				IntPtr intPtr = (IntPtr)tMP_Text;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v1 (Il2CppClass<TMPro.TMP_Text>)+290]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v1 (Il2CppClass<TMPro.TMP_Text>)+298]");
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
				TMP_Text tMP_Text = target;
				IntPtr intPtr = (IntPtr)tMP_Text;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ X8_v1 (Il2CppClass<TMPro.TMP_Text>)+2A0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ X8_v1 (Il2CppClass<TMPro.TMP_Text>)+2A8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v8 @ X2_v1 (should have been resolved before IL gen)");
			};
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<Color, Color, ColorOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x600002B")]
		[Address(RVA = "0x15B8B88", Offset = "0x15B8B88", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv36 = *([1F08C48]);\n\tv37 = *([v36 @ X8_v22]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, endValue, methodInfo, v40, v41, v42, v43, v44, duration, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([202990F]) = v54;\nL_001F:\n\tv58 = new DG.Tweening.ShortcutExtensionsTMPText+<>c__DisplayClass1_0();\n\tSystem.Object::.ctor(v58);\n\tv58.target = target;\n\tv65 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v65, v58, Il2CppMethodInfo);\n\tv79 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v79, v58, Il2CppMethodInfo);\n\tv136 = endValue & 0xFFFFFFFF;\n\tv138 = UnityEngine.Color32::op_Implicit(v136);\n\tgoto L_005F;\n\tv152 = *([v147 @ X0_v11+E0]);\n\tv153 = v152 == 0;\n\tv154 = ~v153;\n\tif (v154) goto L_005F;\n\tv156 = \"il2cpp_codegen_runtime_class_init\"(v147, v137, v135, v106, v41, v42, v43, v44, v138, v139, v140, v141, v48, v49, v50, v51);\nL_005F:\n\tv161 = DG.Tweening.DOTween::To(v65, v79, v138, duration);\n\tv164 = DG.Tweening.TweenSettingsExtensions::SetTarget(v161, v58.target);\n\treturn v161;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Color, Color, ColorOptions> DOFaceColor(this TMP_Text target, Color32 endValue, float duration)
		{
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Expected O, but got Unknown
			DOGetter<Color> getter = delegate
			{
				//IL_001c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0021: Expected O, but got Unknown
				Color32 faceColor = target.faceColor;
				Color32 color2 = (Color32)(faceColor & 0xFFFFFFFFL);
				return color2;
			};
			DOSetter<Color> setter = delegate(Color x)
			{
				//IL_001f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0024: Expected O, but got Unknown
				Color32 color2 = x;
				Color32 faceColor = (Color32)(color2 & 0xFFFFFFFFL);
				target.faceColor = faceColor;
			};
			Color32 color = (Color32)(endValue & 0xFFFFFFFFL);
			Color endValue2 = color;
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.To(getter, setter, endValue2, duration);
			TweenerCore<Color, Color, ColorOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x600002C")]
		[Address(RVA = "0x15B8D08", Offset = "0x15B8D08", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv36 = *([1EB6690]);\n\tv37 = *([v36 @ X8_v22]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, endValue, methodInfo, v40, v41, v42, v43, v44, duration, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2029910]) = v54;\nL_001F:\n\tv58 = new DG.Tweening.ShortcutExtensionsTMPText+<>c__DisplayClass2_0();\n\tSystem.Object::.ctor(v58);\n\tv58.target = target;\n\tv65 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v65, v58, Il2CppMethodInfo);\n\tv79 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v79, v58, Il2CppMethodInfo);\n\tv136 = endValue & 0xFFFFFFFF;\n\tv138 = UnityEngine.Color32::op_Implicit(v136);\n\tgoto L_005F;\n\tv152 = *([v147 @ X0_v11+E0]);\n\tv153 = v152 == 0;\n\tv154 = ~v153;\n\tif (v154) goto L_005F;\n\tv156 = \"il2cpp_codegen_runtime_class_init\"(v147, v137, v135, v106, v41, v42, v43, v44, v138, v139, v140, v141, v48, v49, v50, v51);\nL_005F:\n\tv161 = DG.Tweening.DOTween::To(v65, v79, v138, duration);\n\tv164 = DG.Tweening.TweenSettingsExtensions::SetTarget(v161, v58.target);\n\treturn v161;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Color, Color, ColorOptions> DOOutlineColor(this TMP_Text target, Color32 endValue, float duration)
		{
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Expected O, but got Unknown
			DOGetter<Color> getter = delegate
			{
				//IL_001c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0021: Expected O, but got Unknown
				Color32 outlineColor = target.outlineColor;
				Color32 color2 = (Color32)(outlineColor & 0xFFFFFFFFL);
				return color2;
			};
			DOSetter<Color> setter = delegate(Color x)
			{
				//IL_001f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0024: Expected O, but got Unknown
				Color32 color2 = x;
				Color32 outlineColor = (Color32)(color2 & 0xFFFFFFFFL);
				target.outlineColor = outlineColor;
			};
			Color32 color = (Color32)(endValue & 0xFFFFFFFFL);
			Color endValue2 = color;
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.To(getter, setter, endValue2, duration);
			TweenerCore<Color, Color, ColorOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x600002D")]
		[Address(RVA = "0x15B8E88", Offset = "0x15B8E88", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv42 = *([1EEA298]);\n\tv43 = *([v42 @ X8_v11]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, useSharedMaterial, methodInfo, v46, v47, v48, v49, v50, endValue, v0, v2, v3, duration, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2029911]) = v56;\nL_0025:\n\tv59 = useSharedMaterial == 0;\n\tif (v59) goto L_002F;\n\tv73 = TMPro.TMP_Text::get_fontSharedMaterial(target);\n\tgoto L_003A;\nL_002F:\n\tv73 = TMPro.TMP_Text::get_fontMaterial(target);\nL_003A:\n\tv85 = DG.Tweening.ShortcutExtensions::DOColor(v73, endValue, \"_GlowColor\", duration);\n\tv125 = DG.Tweening.TweenSettingsExtensions::SetTarget(v85, target);\n\treturn v85;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Color, Color, ColorOptions> DOGlowColor(this TMP_Text target, Color endValue, float duration, bool useSharedMaterial = false)
		{
			Material target2 = ((!useSharedMaterial) ? target.fontMaterial : target.fontSharedMaterial);
			TweenerCore<Color, Color, ColorOptions> tweenerCore = target2.DOColor(endValue, "_GlowColor", duration);
			TweenerCore<Color, Color, ColorOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x600002E")]
		[Address(RVA = "0x15B6EE8", Offset = "0x15B6EE8", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1EEEB10]);\n\tv29 = *([v28 @ X8_v22]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2029912]) = v46;\nL_001B:\n\tv50 = new DG.Tweening.ShortcutExtensionsTMPText+<>c__DisplayClass4_0();\n\tSystem.Object::.ctor(v50);\n\tv50.target = target;\n\tv57 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v57, v50, Il2CppMethodInfo);\n\tv71 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v71, v50, Il2CppMethodInfo);\n\tgoto L_004D;\n\tv117 = *([v113 @ X0_v10+E0]);\n\tv118 = v117 == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_004D;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v113, v108, v110, v81, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\nL_004D:\n\tv126 = DG.Tweening.DOTween::ToAlpha(v57, v71, endValue, duration);\n\tv129 = DG.Tweening.TweenSettingsExtensions::SetTarget(v126, v50.target);\n\treturn v126;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Color, Color, ColorOptions> DOFade(this TMP_Text target, float endValue, float duration)
		{
			DOGetter<Color> getter = delegate
			{
				//IL_0017: Expected I, but got O
				//IL_0027: Expected O, but got I
				//IL_0037: Expected O, but got I
				//IL_0043: Expected O, but got I4
				TMP_Text tMP_Text = target;
				IntPtr intPtr = (IntPtr)tMP_Text;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v1 (Il2CppClass<TMPro.TMP_Text>)+290]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v1 (Il2CppClass<TMPro.TMP_Text>)+298]");
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
				TMP_Text tMP_Text = target;
				IntPtr intPtr = (IntPtr)tMP_Text;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ X8_v1 (Il2CppClass<TMPro.TMP_Text>)+2A0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ X8_v1 (Il2CppClass<TMPro.TMP_Text>)+2A8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v8 @ X2_v1 (should have been resolved before IL gen)");
			};
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.ToAlpha(getter, setter, endValue, duration);
			TweenerCore<Color, Color, ColorOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x600002F")]
		[Address(RVA = "0x15B8F80", Offset = "0x15B8F80", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv27 = *([1ECB7A0]);\n\tv28 = *([v27 @ X8_v11]);\n\tv29 = \"il2cpp_codegen_initialize_method\"(v28, methodInfo, v31, v32, v33, v34, v35, v36, endValue, duration, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2029913]) = v45;\nL_001B:\n\tv49 = new DG.Tweening.ShortcutExtensionsTMPText+<>c__DisplayClass5_0();\n\tSystem.Object::.ctor(v49);\n\tv49.target = target;\n\tv56 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\treturnVal2 = 0x15B97B0(v56, 0, v31, v32, v33, v34, v35, v36, endValue, duration, v37, v38, v39, v40, v41, v42);\n\treturn returnVal2;\n\tX1 = X19;\n\tX20 = X0;\n\tX2 = *([X8]);\n\tX3 = *([1EFA000]);\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(X0, X1, X2, X3);\n\tX8 = *([1EED068]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EE02B8]);\n\tX9 = *([1EEBC98]);\n\tX1 = X19;\n\tX21 = X0;\n\tX2 = *([X8]);\n\tX3 = *([X9]);\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(X0, X1, X2, X3);\n\tX8 = *([1F00430]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0049;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0049;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0049:\n\tX0 = X20;\n\tX1 = X21;\n\tV0 = V9;\n\tV1 = V8;\n\tX2 = 0;\n\tX0 = DG.Tweening.DOTween::ToAlpha(X0, X1, V0, V1, X2);\n\tX1 = *([X19+10]);\n\tX8 = *([1EF3378]);\n\tX19 = X0;\n\tX2 = *([X8]);\n\tX0 = DG.Tweening.TweenSettingsExtensions::SetTarget /* +17 sharing this address */(X0, X1, X2);\n\tX0 = X19;\n\tX29 = stack[30];\n\tX30 = stack[38];\n\tX20 = stack[20];\n\tX19 = stack[28];\n\tX21 = stack[10];\n\tV9 = stack[0];\n\tV8 = stack[8];\n\t// 93 ShiftStack 64\n\treturn X0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Color, Color, ColorOptions> DOFaceFade(this TMP_Text target, float endValue, float duration)
		{
			DOGetter<Color> dOGetter = null;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @15B97B0 (inside DG.Tweening.ShortcutExtensionsTMPText+<>c__DisplayClass9_0::<DOText>b__1 +0x20)");
			TweenerCore<Color, Color, ColorOptions> result = default(TweenerCore<Color, Color, ColorOptions>);
			return result;
		}

		[Token(Token = "0x6000030")]
		[Address(RVA = "0x15B90C8", Offset = "0x15B90C8", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv34 = *([1EFA180]);\n\tv35 = *([v34 @ X8_v22]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2029914]) = v52;\nL_0020:\n\tv58 = new DG.Tweening.ShortcutExtensionsTMPText+<>c__DisplayClass6_0();\n\tSystem.Object::.ctor(v58);\n\tv64 = TMPro.TMP_Text::get_transform(target);\n\tv58.trans = v64;\n\tv77 = 0x1586898(&v72 @ stack_-60_v2, 0, v38, v39, v40, v41, v42, v43, endValue, endValue, endValue, v45, v46, v47, v48, v49);\n\tv128 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v128, v58, Il2CppMethodInfo);\n\tv140 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v140, v58, Il2CppMethodInfo);\n\tgoto L_0062;\n\tv157 = *([v153 @ X0_v15+E0]);\n\tv158 = v157 == 0;\n\tv159 = ~v158;\n\tif (v159) goto L_0062;\n\tv161 = \"il2cpp_codegen_runtime_class_init\"(v153, v144, v146, v92, v40, v41, v42, v43, v73, v74, v75, v45, v46, v47, v48, v49);\nL_0062:\n\t// 98 MakeStruct v81 @ AGG15B9214_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v72 @ stack_-60_v2, v151 @ stack_-5C, 0\n\tv166 = DG.Tweening.DOTween::To(v128, v140, v81, duration);\n\tv169 = DG.Tweening.TweenSettingsExtensions::SetTarget(v166, target);\n\treturn v166;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOScale(this TMP_Text target, float endValue, float duration)
		{
			//IL_0077: Expected F4, but got O
			//IL_0084: Expected F4, but got O
			Transform transform = target.transform;
			Transform trans = transform;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			DOGetter<Vector3> getter = () => trans.localScale;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				trans.localScale = x;
			};
			Vector3 endValue2 = default(Vector3);
			object obj = default(object);
			endValue2.x = (float)obj;
			object obj2 = default(object);
			endValue2.y = (float)obj2;
			endValue2.z = 0f;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue2, duration);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x6000031")]
		[Address(RVA = "0x15B9260", Offset = "0x15B9260", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1F05620]);\n\tv29 = *([v28 @ X8_v22]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2029915]) = v46;\nL_001B:\n\tv50 = new DG.Tweening.ShortcutExtensionsTMPText+<>c__DisplayClass7_0();\n\tSystem.Object::.ctor(v50);\n\tv50.target = target;\n\tv57 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v57, v50, Il2CppMethodInfo);\n\tv71 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v71, v50, Il2CppMethodInfo);\n\tgoto L_004D;\n\tv117 = *([v113 @ X0_v10+E0]);\n\tv118 = v117 == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_004D;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v113, v108, v110, v81, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\nL_004D:\n\tv126 = DG.Tweening.DOTween::To(v57, v71, endValue, duration);\n\tv129 = DG.Tweening.TweenSettingsExtensions::SetTarget(v126, v50.target);\n\treturn v126;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<float, float, FloatOptions> DOFontSize(this TMP_Text target, float endValue, float duration)
		{
			DOGetter<float> getter = delegate
			{
				TMP_Text tMP_Text = target;
				return tMP_Text.fontSize;
			};
			DOSetter<float> setter = delegate(float x)
			{
				target.fontSize = x;
			};
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<float, float, FloatOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x6000032")]
		[Address(RVA = "0x15B93A8", Offset = "0x15B93A8", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1EB25C0]);\n\tv29 = *([v28 @ X8_v22]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, endValue, methodInfo, v32, v33, v34, v35, v36, duration, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2029916]) = v46;\nL_001B:\n\tv50 = new DG.Tweening.ShortcutExtensionsTMPText+<>c__DisplayClass8_0();\n\tSystem.Object::.ctor(v50);\n\tv50.target = target;\n\tv57 = new DG.Tweening.Core.DOGetter`1<System.Int32>();\n\tDG.Tweening.Core.DOGetter`1<System.Int32>::.ctor(v57, v50, Il2CppMethodInfo);\n\tv71 = new DG.Tweening.Core.DOSetter`1<System.Int32>();\n\tDG.Tweening.Core.DOSetter`1<System.Int32>::.ctor(v71, v50, Il2CppMethodInfo);\n\tgoto L_004D;\n\tv116 = *([v112 @ X0_v10+E0]);\n\tv117 = v116 == 0;\n\tv118 = ~v117;\n\tif (v118) goto L_004D;\n\tv120 = \"il2cpp_codegen_runtime_class_init\"(v112, v106, v108, v109, v33, v34, v35, v36, duration, v37, v38, v39, v40, v41, v42, v43);\nL_004D:\n\tv125 = DG.Tweening.DOTween::To(v57, v71, endValue, duration);\n\tv128 = DG.Tweening.TweenSettingsExtensions::SetTarget(v125, v50.target);\n\treturn v125;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<int, int, NoOptions> DOMaxVisibleCharacters(this TMP_Text target, int endValue, float duration)
		{
			DOGetter<int> getter = delegate
			{
				TMP_Text tMP_Text = target;
				return tMP_Text.maxVisibleCharacters;
			};
			DOSetter<int> setter = delegate(int x)
			{
				target.maxVisibleCharacters = x;
			};
			TweenerCore<int, int, NoOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<int, int, NoOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x6000033")]
		[Address(RVA = "0x15B7028", Offset = "0x15B7028", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv40 = *([1EC4478]);\n\tv41 = *([v40 @ X8_v22]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, endValue, richTextEnabled, scrambleMode, scrambleChars, methodInfo, v44, v45, duration, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2029917]) = v55;\nL_0021:\n\tv59 = new DG.Tweening.ShortcutExtensionsTMPText+<>c__DisplayClass9_0();\n\tSystem.Object::.ctor(v59);\n\tv59.target = target;\n\tv66 = new DG.Tweening.Core.DOGetter`1<System.String>();\n\tDG.Tweening.Core.DOGetter`1<System.String>::.ctor(v66, v59, Il2CppMethodInfo);\n\tv80 = new DG.Tweening.Core.DOSetter`1<System.String>();\n\tDG.Tweening.Core.DOSetter`1<System.String>::.ctor(v80, v59, Il2CppMethodInfo);\n\tgoto L_0053;\n\tv133 = *([v129 @ X0_v10+E0]);\n\tv134 = v133 == 0;\n\tv135 = ~v134;\n\tif (v135) goto L_0053;\n\tv137 = \"il2cpp_codegen_runtime_class_init\"(v129, v123, v125, v126, scrambleChars, methodInfo, v44, v45, duration, v46, v47, v48, v49, v50, v51, v52);\nL_0053:\n\tv143 = DG.Tweening.DOTween::To(v66, v80, endValue, duration);\n\tv147 = DG.Tweening.TweenSettingsExtensions::SetOptions(v143, richTextEnabled, scrambleMode, scrambleChars);\n\tv149 = DG.Tweening.TweenSettingsExtensions::SetTarget(v147, v59.target);\n\treturn v143;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 86 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<string, string, StringOptions> DOText(this TMP_Text target, string endValue, float duration, bool richTextEnabled = true, ScrambleMode scrambleMode = ScrambleMode.None, string scrambleChars = null)
		{
			DOGetter<string> getter = delegate
			{
				TMP_Text tMP_Text = target;
				return tMP_Text.text;
			};
			DOSetter<string> setter = delegate(string x)
			{
				if (target != null)
				{
					target.text = x;
				}
				else
				{
					NullReferenceException ex = new NullReferenceException();
					IYandexAppMetrica instance = AppMetrica.Instance;
				}
			};
			TweenerCore<string, string, StringOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			Tweener t = tweenerCore.SetOptions(richTextEnabled, scrambleMode, scrambleChars);
			Tweener tweener = t.SetTarget(target);
			return tweenerCore;
		}
	}
}
