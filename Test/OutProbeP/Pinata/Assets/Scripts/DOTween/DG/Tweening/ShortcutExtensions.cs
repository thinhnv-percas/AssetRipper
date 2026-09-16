using System;
using System.Runtime.CompilerServices;
using System.Xml.Schema;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using DG.Tweening.CustomPlugins;
using DG.Tweening.Plugins;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening
{
	[Token(Token = "0x2000015")]
	public static class ShortcutExtensions
	{
		[CompilerGenerated]
		[Token(Token = "0x2000074")]
		private sealed class _003C_003Ec__DisplayClass15_0
		{
			[Token(Token = "0x40001D2")]
			[FieldOffset(Offset = "0x10")]
			public Color2 startValue;

			[Token(Token = "0x40001D3")]
			[FieldOffset(Offset = "0x30")]
			public LineRenderer target;

			[Token(Token = "0x6000330")]
			[Address(RVA = "0x10E4644", Offset = "0x10E4644", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec__DisplayClass15_0()
			{
			}

			internal unsafe Color2 _003CDOColor_003Eb__0()
			{
				//IL_000f: Expected native int or pointer, but got O
				//IL_001e: Expected native int or pointer, but got O
				Color2 color = default(Color2);
				((Color2*)(IntPtr)color)->cb = startValue.cb;
				((Color2*)(IntPtr)color)->ca = (Color)startValue;
				return (Color2)this;
			}

			internal void _003CDOColor_003Eb__1(Color2 x)
			{
				target.SetColors(x.ca, x.cb);
			}
		}

		[Token(Token = "0x600009D")]
		[Address(RVA = "0x10E2DF0", Offset = "0x10E2DF0", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1EC7148]);\n\tv29 = *([v28 @ X8_v22]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2027500]) = v46;\nL_001B:\n\tv50 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass0_0();\n\tSystem.Object::.ctor(v50);\n\tv50.target = target;\n\tv57 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v57, v50, Il2CppMethodInfo);\n\tv71 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v71, v50, Il2CppMethodInfo);\n\tgoto L_004D;\n\tv117 = *([v113 @ X0_v10+E0]);\n\tv118 = v117 == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_004D;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v113, v108, v110, v81, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\nL_004D:\n\tv126 = DG.Tweening.DOTween::To(v57, v71, endValue, duration);\n\tv129 = DG.Tweening.TweenSettingsExtensions::SetTarget(v126, v50.target);\n\treturn v126;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<float, float, FloatOptions> DOAspect(this Camera target, float endValue, float duration)
		{
			DOGetter<float> getter = () => target.aspect;
			DOSetter<float> setter = delegate(float x)
			{
				target.aspect = x;
			};
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<float, float, FloatOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x600009E")]
		[Address(RVA = "0x10E2F38", Offset = "0x10E2F38", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv39 = *([1EDE240]);\n\tv40 = *([v39 @ X8_v15]);\n\tv41 = \"il2cpp_codegen_initialize_method\"(v40, methodInfo, v43, v44, v45, v46, v47, v48, endValue, v0, v2, v3, duration, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2027501]) = v54;\nL_0024:\n\tv58 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass1_0();\n\tSystem.Object::.ctor(v58);\n\tv58.target = target;\n\tv65 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v65, v58, Il2CppMethodInfo);\n\tv79 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\treturnVal2 = DG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v79, v58, Il2CppMethodInfo);\n\treturn returnVal2;\n\tX1 = X19;\n\tX21 = X0;\n\tX2 = *([X8]);\n\tX3 = *([1EEB000]);\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(X0, X1, X2, X3);\n\tX8 = *([1F00430]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0052;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0052;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0052:\n\tX0 = X20;\n\tX1 = X21;\n\tV0 = V12;\n\tV1 = V11;\n\tV2 = V10;\n\tV3 = V9;\n\tV4 = V8;\n\tX2 = 0;\n\t// 90 MakeStruct AGG10E305C_2, typeof(UnityEngine.Color), V0, V1, V2, V3\n\tX0 = DG.Tweening.DOTween::To(X0, X1, AGG10E305C_2, V4, X2);\n\tX1 = *([X19+10]);\n\tX8 = *([1EF3378]);\n\tX19 = X0;\n\tX2 = *([X8]);\n\tX0 = DG.Tweening.TweenSettingsExtensions::SetTarget /* +17 sharing this address */(X0, X1, X2);\n\tX0 = X19;\n\tX29 = stack[40];\n\tX30 = stack[48];\n\tX20 = stack[30];\n\tX19 = stack[38];\n\tX21 = stack[28];\n\tV9 = stack[18];\n\tV8 = stack[20];\n\tV11 = stack[8];\n\tV10 = stack[10];\n\tV12 = stack[0];\n\t// 109 ShiftStack 80\n\treturn X0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Color, Color, ColorOptions> DOColor(this Camera target, Color endValue, float duration)
		{
			DOGetter<Color> dOGetter = () => target.backgroundColor;
			DOSetter<Color> dOSetter = () => target.backgroundColor;
			TweenerCore<Color, Color, ColorOptions> result = default(TweenerCore<Color, Color, ColorOptions>);
			return result;
		}

		[Token(Token = "0x600009F")]
		[Address(RVA = "0x10E30A8", Offset = "0x10E30A8", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1EB15F8]);\n\tv29 = *([v28 @ X8_v22]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2027502]) = v46;\nL_001B:\n\tv50 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass2_0();\n\tSystem.Object::.ctor(v50);\n\tv50.target = target;\n\tv57 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v57, v50, Il2CppMethodInfo);\n\tv71 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v71, v50, Il2CppMethodInfo);\n\tgoto L_004D;\n\tv117 = *([v113 @ X0_v10+E0]);\n\tv118 = v117 == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_004D;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v113, v108, v110, v81, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\nL_004D:\n\tv126 = DG.Tweening.DOTween::To(v57, v71, endValue, duration);\n\tv129 = DG.Tweening.TweenSettingsExtensions::SetTarget(v126, v50.target);\n\treturn v126;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<float, float, FloatOptions> DOFarClipPlane(this Camera target, float endValue, float duration)
		{
			DOGetter<float> getter = () => target.farClipPlane;
			DOSetter<float> setter = delegate(float x)
			{
				target.farClipPlane = x;
			};
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<float, float, FloatOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x60000A0")]
		[Address(RVA = "0x10E31F0", Offset = "0x10E31F0", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1EC89C0]);\n\tv29 = *([v28 @ X8_v22]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2027503]) = v46;\nL_001B:\n\tv50 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass3_0();\n\tSystem.Object::.ctor(v50);\n\tv50.target = target;\n\tv57 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v57, v50, Il2CppMethodInfo);\n\tv71 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v71, v50, Il2CppMethodInfo);\n\tgoto L_004D;\n\tv117 = *([v113 @ X0_v10+E0]);\n\tv118 = v117 == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_004D;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v113, v108, v110, v81, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\nL_004D:\n\tv126 = DG.Tweening.DOTween::To(v57, v71, endValue, duration);\n\tv129 = DG.Tweening.TweenSettingsExtensions::SetTarget(v126, v50.target);\n\treturn v126;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<float, float, FloatOptions> DOFieldOfView(this Camera target, float endValue, float duration)
		{
			DOGetter<float> getter = () => target.fieldOfView;
			DOSetter<float> setter = delegate(float x)
			{
				target.fieldOfView = x;
			};
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<float, float, FloatOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x60000A1")]
		[Address(RVA = "0x10E3338", Offset = "0x10E3338", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1EBC040]);\n\tv29 = *([v28 @ X8_v22]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2027504]) = v46;\nL_001B:\n\tv50 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass4_0();\n\tSystem.Object::.ctor(v50);\n\tv50.target = target;\n\tv57 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v57, v50, Il2CppMethodInfo);\n\tv71 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v71, v50, Il2CppMethodInfo);\n\tgoto L_004D;\n\tv117 = *([v113 @ X0_v10+E0]);\n\tv118 = v117 == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_004D;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v113, v108, v110, v81, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\nL_004D:\n\tv126 = DG.Tweening.DOTween::To(v57, v71, endValue, duration);\n\tv129 = DG.Tweening.TweenSettingsExtensions::SetTarget(v126, v50.target);\n\treturn v126;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<float, float, FloatOptions> DONearClipPlane(this Camera target, float endValue, float duration)
		{
			DOGetter<float> getter = () => target.nearClipPlane;
			DOSetter<float> setter = delegate(float x)
			{
				target.nearClipPlane = x;
			};
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<float, float, FloatOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x60000A2")]
		[Address(RVA = "0x10E3480", Offset = "0x10E3480", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1EDB070]);\n\tv29 = *([v28 @ X8_v22]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2027505]) = v46;\nL_001B:\n\tv50 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass5_0();\n\tSystem.Object::.ctor(v50);\n\tv50.target = target;\n\tv57 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v57, v50, Il2CppMethodInfo);\n\tv71 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v71, v50, Il2CppMethodInfo);\n\tgoto L_004D;\n\tv117 = *([v113 @ X0_v10+E0]);\n\tv118 = v117 == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_004D;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v113, v108, v110, v81, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\nL_004D:\n\tv126 = DG.Tweening.DOTween::To(v57, v71, endValue, duration);\n\tv129 = DG.Tweening.TweenSettingsExtensions::SetTarget(v126, v50.target);\n\treturn v126;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<float, float, FloatOptions> DOOrthoSize(this Camera target, float endValue, float duration)
		{
			DOGetter<float> getter = () => target.orthographicSize;
			DOSetter<float> setter = delegate(float x)
			{
				target.orthographicSize = x;
			};
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<float, float, FloatOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x60000A3")]
		[Address(RVA = "0x10E35C8", Offset = "0x10E35C8", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv40 = *([1EBE5A0]);\n\tv41 = *([v40 @ X8_v22]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, methodInfo, v44, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2027506]) = v55;\nL_0024:\n\tv59 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass6_0();\n\tSystem.Object::.ctor(v59);\n\tv59.target = target;\n\tv66 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Rect>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Rect>::.ctor(v66, v59, Il2CppMethodInfo);\n\tv80 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Rect>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Rect>::.ctor(v80, v59, Il2CppMethodInfo);\n\tgoto L_005A;\n\tv141 = *([v137 @ X0_v10+E0]);\n\tv142 = v141 == 0;\n\tv143 = ~v142;\n\tif (v143) goto L_005A;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v137, v132, v134, v93, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\nL_005A:\n\tv150 = DG.Tweening.DOTween::To(v66, v80, endValue, duration);\n\tv153 = DG.Tweening.TweenSettingsExtensions::SetTarget(v150, v59.target);\n\treturn v150;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Rect, Rect, RectOptions> DOPixelRect(this Camera target, Rect endValue, float duration)
		{
			DOGetter<Rect> getter = () => target.pixelRect;
			DOSetter<Rect> setter = delegate(Rect x)
			{
				target.pixelRect = x;
			};
			TweenerCore<Rect, Rect, RectOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<Rect, Rect, RectOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x60000A4")]
		[Address(RVA = "0x10E3738", Offset = "0x10E3738", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv40 = *([1ED7D58]);\n\tv41 = *([v40 @ X8_v22]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, methodInfo, v44, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2027507]) = v55;\nL_0024:\n\tv59 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass7_0();\n\tDG.Tweening.ShortcutExtensions+<>c__DisplayClass7_0::.ctor(v59);\n\tv59.target = target;\n\tv66 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Rect>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Rect>::.ctor(v66, v59, Il2CppMethodInfo);\n\tv80 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Rect>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Rect>::.ctor(v80, v59, Il2CppMethodInfo);\n\tgoto L_005A;\n\tv141 = *([v137 @ X0_v10+E0]);\n\tv142 = v141 == 0;\n\tv143 = ~v142;\n\tif (v143) goto L_005A;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v137, v132, v134, v93, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\nL_005A:\n\tv150 = DG.Tweening.DOTween::To(v66, v80, endValue, duration);\n\tv153 = DG.Tweening.TweenSettingsExtensions::SetTarget(v150, v59.target);\n\treturn v150;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Rect, Rect, RectOptions> DORect(this Camera target, Rect endValue, float duration)
		{
			DOGetter<Rect> getter = () => target.rect;
			DOSetter<Rect> setter = delegate(Rect x)
			{
				target.rect = x;
			};
			TweenerCore<Rect, Rect, RectOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<Rect, Rect, RectOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x60000A5")]
		[Address(RVA = "0x10E38A0", Offset = "0x10E38A0", Length = "0x1FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv40 = *([1EC7080]);\n\tv41 = *([v40 @ X8_v43]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, vibrato, fadeOut, methodInfo, v44, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2027508]) = v55;\nL_0021:\n\tv59 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass8_0();\n\tDG.Tweening.ShortcutExtensions+<>c__DisplayClass8_0::.ctor(v59);\n\tv63 = duration < 0;\n\tv64 = ~v63;\n\tv67 = duration == 0;\n\tv59.target = target;\n\tv72 = ~v64;\n\tv73 = v72 | v67;\n\tif (v73) goto L_0073;\n\tv79 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v79, v59, Il2CppMethodInfo);\n\tv190 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v190, v59, Il2CppMethodInfo);\n\tgoto L_0063;\n\tv241 = *([v237 @ X0_v20+E0]);\n\tv242 = v241 == 0;\n\tv243 = ~v242;\n\tif (v243) goto L_0063;\n\tv245 = \"il2cpp_codegen_runtime_class_init\"(v237, v210, v212, v213, v44, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\nL_0063:\n\tv250 = DG.Tweening.DOTween::Shake(v79, v190, duration, strength, vibrato, randomness, 1, fadeOut);\n\tv255 = DG.Tweening.TweenSettingsExtensions::SetTarget(v250, v59.target);\n\tv230 = DG.Tweening.Core.Extensions::SetSpecialStartupMode(v255, 4);\n\tgoto L_00A8;\nL_0073:\n\tgoto L_0089;\n\tv93 = *([1EFC598]);\n\tv94 = *([v93 @ X8_v22]);\n\tv95 = \"il2cpp_codegen_initialize_method\"(v94, v60, fadeOut, methodInfo, v44, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv98 = 0 | 1;\n\t*([2022B9B]) = v98;\nL_0089:\n\tv114 = v102._logPriority < 1;\n\tif (v114) goto L_FFFFFFFF;\n\tgoto L_009B;\n\tv214 = *([v193 @ X0_v10+E0]);\n\tv215 = v214 == 0;\n\tv216 = ~v215;\n\tif (v216) goto L_009B;\n\tv218 = \"il2cpp_codegen_runtime_class_init\"(v193, v60, fadeOut, methodInfo, v44, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\nL_009B:\n\tUnityEngine.Debug::LogWarning(\"DOShakePosition: duration can't be 0, returning NULL without creating a tween\");\nL_00A8:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 125 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOShakePosition(this Camera target, float duration, float strength = 3f, int vibrato = 10, float randomness = 90f, bool fadeOut = true)
		{
			bool flag = duration < 0f;
			bool flag2 = !flag;
			bool flag3 = duration == 0f;
			Camera target2 = target;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				DOGetter<Vector3> getter = delegate
				{
					Transform transform = target2.transform;
					return transform.localPosition;
				};
				DOSetter<Vector3> setter = delegate(Vector3 x)
				{
					Transform transform = target2.transform;
					transform.localPosition = x;
				};
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = DOTween.Shake(getter, setter, duration, strength, vibrato, randomness, ignoreZAxis: true, fadeOut);
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t2 = t.SetTarget(target2);
				return t2.SetSpecialStartupMode(SpecialStartupMode.SetCameraShakePosition);
			}
			if (Debugger._logPriority >= 1)
			{
				Debug.LogWarning("DOShakePosition: duration can't be 0, returning NULL without creating a tween");
			}
			return null;
		}

		[Token(Token = "0x60000A6")]
		[Address(RVA = "0x10E3A9C", Offset = "0x10E3A9C", Length = "0x210")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv48 = *([1F02830]);\n\tv49 = *([v48 @ X8_v43]);\n\tv50 = \"il2cpp_codegen_initialize_method\"(v49, vibrato, fadeOut, methodInfo, v52, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv61 = 0 | 1;\n\t*([2027509]) = v61;\nL_0027:\n\tv65 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass9_0();\n\tDG.Tweening.ShortcutExtensions+<>c__DisplayClass9_0::.ctor(v65);\n\tv69 = duration < 0;\n\tv70 = ~v69;\n\tv73 = duration == 0;\n\tv65.target = target;\n\tv78 = ~v70;\n\tv79 = v78 | v73;\n\tif (v79) goto L_007B;\n\tv85 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v85, v65, Il2CppMethodInfo);\n\tv205 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v205, v65, Il2CppMethodInfo);\n\tgoto L_006B;\n\tv258 = *([v254 @ X0_v20+E0]);\n\tv259 = v258 == 0;\n\tv260 = ~v259;\n\tif (v260) goto L_006B;\n\tv262 = \"il2cpp_codegen_runtime_class_init\"(v254, v225, v227, v228, v52, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\nL_006B:\n\tv267 = DG.Tweening.DOTween::Shake(v85, v205, duration, strength, vibrato, randomness, fadeOut);\n\tv272 = DG.Tweening.TweenSettingsExtensions::SetTarget(v267, v65.target);\n\tv245 = DG.Tweening.Core.Extensions::SetSpecialStartupMode(v272, 4);\n\tgoto L_00B2;\nL_007B:\n\tgoto L_0091;\n\tv99 = *([1EFC598]);\n\tv100 = *([v99 @ X8_v22]);\n\tv101 = \"il2cpp_codegen_initialize_method\"(v100, v66, fadeOut, methodInfo, v52, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv104 = 0 | 1;\n\t*([2022B9B]) = v104;\nL_0091:\n\tv120 = v108._logPriority < 1;\n\tif (v120) goto L_FFFFFFFF;\n\tgoto L_00A3;\n\tv229 = *([v208 @ X0_v10+E0]);\n\tv230 = v229 == 0;\n\tv231 = ~v230;\n\tif (v231) goto L_00A3;\n\tv233 = \"il2cpp_codegen_runtime_class_init\"(v208, v66, fadeOut, methodInfo, v52, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\nL_00A3:\n\tUnityEngine.Debug::LogWarning(\"DOShakePosition: duration can't be 0, returning NULL without creating a tween\");\nL_00B2:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 135 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOShakePosition(this Camera target, float duration, Vector3 strength, int vibrato = 10, float randomness = 90f, bool fadeOut = true)
		{
			bool flag = duration < 0f;
			bool flag2 = !flag;
			bool flag3 = duration == 0f;
			Camera target2 = target;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				DOGetter<Vector3> getter = delegate
				{
					Transform transform = target2.transform;
					return transform.localPosition;
				};
				DOSetter<Vector3> setter = delegate(Vector3 x)
				{
					Transform transform = target2.transform;
					transform.localPosition = x;
				};
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = DOTween.Shake(getter, setter, duration, strength, vibrato, randomness, fadeOut);
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t2 = t.SetTarget(target2);
				return t2.SetSpecialStartupMode(SpecialStartupMode.SetCameraShakePosition);
			}
			if (Debugger._logPriority >= 1)
			{
				Debug.LogWarning("DOShakePosition: duration can't be 0, returning NULL without creating a tween");
			}
			return null;
		}

		[Token(Token = "0x60000A7")]
		[Address(RVA = "0x10E3CAC", Offset = "0x10E3CAC", Length = "0x1FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv40 = *([1EC85F0]);\n\tv41 = *([v40 @ X8_v43]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, vibrato, fadeOut, methodInfo, v44, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([202750A]) = v55;\nL_0021:\n\tv59 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass10_0();\n\tSystem.Object::.ctor(v59);\n\tv63 = duration < 0;\n\tv64 = ~v63;\n\tv67 = duration == 0;\n\tv59.target = target;\n\tv72 = ~v64;\n\tv73 = v72 | v67;\n\tif (v73) goto L_0073;\n\tv79 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v79, v59, Il2CppMethodInfo);\n\tv190 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v190, v59, Il2CppMethodInfo);\n\tgoto L_0063;\n\tv241 = *([v237 @ X0_v20+E0]);\n\tv242 = v241 == 0;\n\tv243 = ~v242;\n\tif (v243) goto L_0063;\n\tv245 = \"il2cpp_codegen_runtime_class_init\"(v237, v210, v212, v213, v44, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\nL_0063:\n\tv250 = DG.Tweening.DOTween::Shake(v79, v190, duration, strength, vibrato, randomness, 0, fadeOut);\n\tv255 = DG.Tweening.TweenSettingsExtensions::SetTarget(v250, v59.target);\n\tv230 = DG.Tweening.Core.Extensions::SetSpecialStartupMode(v255, 2);\n\tgoto L_00A8;\nL_0073:\n\tgoto L_0089;\n\tv93 = *([1EFC598]);\n\tv94 = *([v93 @ X8_v22]);\n\tv95 = \"il2cpp_codegen_initialize_method\"(v94, v60, fadeOut, methodInfo, v44, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv98 = 0 | 1;\n\t*([2022B9B]) = v98;\nL_0089:\n\tv114 = v102._logPriority < 1;\n\tif (v114) goto L_FFFFFFFF;\n\tgoto L_009B;\n\tv214 = *([v193 @ X0_v10+E0]);\n\tv215 = v214 == 0;\n\tv216 = ~v215;\n\tif (v216) goto L_009B;\n\tv218 = \"il2cpp_codegen_runtime_class_init\"(v193, v60, fadeOut, methodInfo, v44, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\nL_009B:\n\tUnityEngine.Debug::LogWarning(\"DOShakeRotation: duration can't be 0, returning NULL without creating a tween\");\nL_00A8:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 125 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOShakeRotation(this Camera target, float duration, float strength = 90f, int vibrato = 10, float randomness = 90f, bool fadeOut = true)
		{
			bool flag = duration < 0f;
			bool flag2 = !flag;
			bool flag3 = duration == 0f;
			Camera target2 = target;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				DOGetter<Vector3> getter = delegate
				{
					Transform transform = target2.transform;
					return transform.localEulerAngles;
				};
				DOSetter<Vector3> setter = delegate(Vector3 x)
				{
					Transform transform = target2.transform;
					Quaternion localRotation = Quaternion.Euler(x);
					transform.localRotation = localRotation;
				};
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = DOTween.Shake(getter, setter, duration, strength, vibrato, randomness, ignoreZAxis: false, fadeOut);
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t2 = t.SetTarget(target2);
				return t2.SetSpecialStartupMode(SpecialStartupMode.SetShake);
			}
			if (Debugger._logPriority >= 1)
			{
				Debug.LogWarning("DOShakeRotation: duration can't be 0, returning NULL without creating a tween");
			}
			return null;
		}

		[Token(Token = "0x60000A8")]
		[Address(RVA = "0x10E3EB0", Offset = "0x10E3EB0", Length = "0x210")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv48 = *([1EB0880]);\n\tv49 = *([v48 @ X8_v43]);\n\tv50 = \"il2cpp_codegen_initialize_method\"(v49, vibrato, fadeOut, methodInfo, v52, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv61 = 0 | 1;\n\t*([202750B]) = v61;\nL_0027:\n\tv65 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass11_0();\n\tSystem.Object::.ctor(v65);\n\tv69 = duration < 0;\n\tv70 = ~v69;\n\tv73 = duration == 0;\n\tv65.target = target;\n\tv78 = ~v70;\n\tv79 = v78 | v73;\n\tif (v79) goto L_007B;\n\tv85 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v85, v65, Il2CppMethodInfo);\n\tv205 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v205, v65, Il2CppMethodInfo);\n\tgoto L_006B;\n\tv258 = *([v254 @ X0_v20+E0]);\n\tv259 = v258 == 0;\n\tv260 = ~v259;\n\tif (v260) goto L_006B;\n\tv262 = \"il2cpp_codegen_runtime_class_init\"(v254, v225, v227, v228, v52, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\nL_006B:\n\tv267 = DG.Tweening.DOTween::Shake(v85, v205, duration, strength, vibrato, randomness, fadeOut);\n\tv272 = DG.Tweening.TweenSettingsExtensions::SetTarget(v267, v65.target);\n\tv245 = DG.Tweening.Core.Extensions::SetSpecialStartupMode(v272, 2);\n\tgoto L_00B2;\nL_007B:\n\tgoto L_0091;\n\tv99 = *([1EFC598]);\n\tv100 = *([v99 @ X8_v22]);\n\tv101 = \"il2cpp_codegen_initialize_method\"(v100, v66, fadeOut, methodInfo, v52, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv104 = 0 | 1;\n\t*([2022B9B]) = v104;\nL_0091:\n\tv120 = v108._logPriority < 1;\n\tif (v120) goto L_FFFFFFFF;\n\tgoto L_00A3;\n\tv229 = *([v208 @ X0_v10+E0]);\n\tv230 = v229 == 0;\n\tv231 = ~v230;\n\tif (v231) goto L_00A3;\n\tv233 = \"il2cpp_codegen_runtime_class_init\"(v208, v66, fadeOut, methodInfo, v52, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\nL_00A3:\n\tUnityEngine.Debug::LogWarning(\"DOShakeRotation: duration can't be 0, returning NULL without creating a tween\");\nL_00B2:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 135 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOShakeRotation(this Camera target, float duration, Vector3 strength, int vibrato = 10, float randomness = 90f, bool fadeOut = true)
		{
			bool flag = duration < 0f;
			bool flag2 = !flag;
			bool flag3 = duration == 0f;
			Camera target2 = target;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				DOGetter<Vector3> getter = delegate
				{
					Transform transform = target2.transform;
					return transform.localEulerAngles;
				};
				DOSetter<Vector3> setter = delegate(Vector3 x)
				{
					Transform transform = target2.transform;
					Quaternion localRotation = Quaternion.Euler(x);
					transform.localRotation = localRotation;
				};
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = DOTween.Shake(getter, setter, duration, strength, vibrato, randomness, fadeOut);
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t2 = t.SetTarget(target2);
				return t2.SetSpecialStartupMode(SpecialStartupMode.SetShake);
			}
			if (Debugger._logPriority >= 1)
			{
				Debug.LogWarning("DOShakeRotation: duration can't be 0, returning NULL without creating a tween");
			}
			return null;
		}

		[Token(Token = "0x60000A9")]
		[Address(RVA = "0x10E40C8", Offset = "0x10E40C8", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv40 = *([1EC6980]);\n\tv41 = *([v40 @ X8_v22]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, methodInfo, v44, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([202750C]) = v55;\nL_0024:\n\tv59 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass12_0();\n\tSystem.Object::.ctor(v59);\n\tv59.target = target;\n\tv66 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v66, v59, Il2CppMethodInfo);\n\tv80 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v80, v59, Il2CppMethodInfo);\n\tgoto L_005A;\n\tv141 = *([v137 @ X0_v10+E0]);\n\tv142 = v141 == 0;\n\tv143 = ~v142;\n\tif (v143) goto L_005A;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v137, v132, v134, v93, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\nL_005A:\n\tv150 = DG.Tweening.DOTween::To(v66, v80, endValue, duration);\n\tv153 = DG.Tweening.TweenSettingsExtensions::SetTarget(v150, v59.target);\n\treturn v150;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Color, Color, ColorOptions> DOColor(this Light target, Color endValue, float duration)
		{
			DOGetter<Color> getter = () => target.color;
			DOSetter<Color> setter = delegate(Color x)
			{
				target.color = x;
			};
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<Color, Color, ColorOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x60000AA")]
		[Address(RVA = "0x10E4238", Offset = "0x10E4238", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1F079A0]);\n\tv29 = *([v28 @ X8_v22]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202750D]) = v46;\nL_001B:\n\tv50 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass13_0();\n\tSystem.Object::.ctor(v50);\n\tv50.target = target;\n\tv57 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v57, v50, Il2CppMethodInfo);\n\tv71 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v71, v50, Il2CppMethodInfo);\n\tgoto L_004D;\n\tv117 = *([v113 @ X0_v10+E0]);\n\tv118 = v117 == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_004D;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v113, v108, v110, v81, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\nL_004D:\n\tv126 = DG.Tweening.DOTween::To(v57, v71, endValue, duration);\n\tv129 = DG.Tweening.TweenSettingsExtensions::SetTarget(v126, v50.target);\n\treturn v126;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<float, float, FloatOptions> DOIntensity(this Light target, float endValue, float duration)
		{
			DOGetter<float> getter = () => target.intensity;
			DOSetter<float> setter = delegate(float x)
			{
				target.intensity = x;
			};
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<float, float, FloatOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x60000AB")]
		[Address(RVA = "0x10E4380", Offset = "0x10E4380", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1ED5270]);\n\tv29 = *([v28 @ X8_v22]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202750E]) = v46;\nL_001B:\n\tv50 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass14_0();\n\tSystem.Object::.ctor(v50);\n\tv50.target = target;\n\tv57 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v57, v50, Il2CppMethodInfo);\n\tv71 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v71, v50, Il2CppMethodInfo);\n\tgoto L_004D;\n\tv117 = *([v113 @ X0_v10+E0]);\n\tv118 = v117 == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_004D;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v113, v108, v110, v81, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\nL_004D:\n\tv126 = DG.Tweening.DOTween::To(v57, v71, endValue, duration);\n\tv129 = DG.Tweening.TweenSettingsExtensions::SetTarget(v126, v50.target);\n\treturn v126;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<float, float, FloatOptions> DOShadowStrength(this Light target, float endValue, float duration)
		{
			DOGetter<float> getter = () => target.shadowStrength;
			DOSetter<float> setter = delegate(float x)
			{
				target.shadowStrength = x;
			};
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<float, float, FloatOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x60000AC")]
		[Address(RVA = "0x10E44C8", Offset = "0x10E44C8", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1EBC478]);\n\tv31 = *([v30 @ X8_v22]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, startValue, endValue, methodInfo, v34, v35, v36, v37, duration, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([202750F]) = v47;\nL_001C:\n\tv51 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass15_0();\n\tSystem.Object::.ctor(v51);\n\tv54 = startValue.cb;\n\tv54 = startValue.ca;\n\tv51.startValue.cb = startValue.ca;\n\tv51.target = target;\n\tv51.startValue.ca = startValue.ca;\n\tv64 = new DG.Tweening.Core.DOGetter`1<DG.Tweening.Color2>();\n\tDG.Tweening.Core.DOGetter`1<DG.Tweening.Color2>::.ctor(v64, v51, Il2CppMethodInfo);\n\tv78 = new DG.Tweening.Core.DOSetter`1<DG.Tweening.Color2>();\n\tDG.Tweening.Core.DOSetter`1<DG.Tweening.Color2>::.ctor(v78, v51, Il2CppMethodInfo);\n\tv54 = endValue.ca;\n\tgoto L_005E;\n\tv139 = *([v135 @ X0_v10+E0]);\n\tv140 = v139 == 0;\n\tv141 = ~v140;\n\tif (v141) goto L_005E;\n\tv143 = \"il2cpp_codegen_runtime_class_init\"(v135, v127, v129, v130, v34, v35, v36, v37, v133, v38, v39, v40, v41, v42, v43, v44);\nL_005E:\n\tv149 = DG.Tweening.DOTween::To(v64, v78, &v54 @ V0_v1 (UnityEngine.Color), duration);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v149, v51.target);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static Tweener DOColor(this LineRenderer target, Color2 startValue, Color2 endValue, float duration)
		{
			//IL_0099: Expected O, but got Ref
			_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass15_0();
			Color color = startValue.cb;
			color = startValue.ca;
			CS_0024_003C_003E8__locals8.startValue.cb = startValue.ca;
			CS_0024_003C_003E8__locals8.target = target;
			CS_0024_003C_003E8__locals8.startValue.ca = startValue.ca;
			DOGetter<Color2> getter = delegate
			{
				//IL_000f: Expected native int or pointer, but got O
				//IL_001e: Expected native int or pointer, but got O
				Color2 color2 = default(Color2);
				((Color2*)(IntPtr)color2)->cb = CS_0024_003C_003E8__locals8.startValue.cb;
				((Color2*)(IntPtr)color2)->ca = (Color)CS_0024_003C_003E8__locals8.startValue;
				return (Color2)CS_0024_003C_003E8__locals8;
			};
			DOSetter<Color2> setter = delegate(Color2 x)
			{
				CS_0024_003C_003E8__locals8.target.SetColors(x.ca, x.cb);
			};
			color = endValue.ca;
			TweenerCore<Color2, Color2, ColorOptions> t = DOTween.To(getter, setter, (Color2)(&color), duration);
			return t.SetTarget(CS_0024_003C_003E8__locals8.target);
		}

		[Token(Token = "0x60000AD")]
		[Address(RVA = "0x10E464C", Offset = "0x10E464C", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv40 = *([1EF4D88]);\n\tv41 = *([v40 @ X8_v22]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, methodInfo, v44, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2027510]) = v55;\nL_0024:\n\tv59 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass16_0();\n\tSystem.Object::.ctor(v59);\n\tv59.target = target;\n\tv66 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v66, v59, Il2CppMethodInfo);\n\tv80 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v80, v59, Il2CppMethodInfo);\n\tgoto L_005A;\n\tv141 = *([v137 @ X0_v10+E0]);\n\tv142 = v141 == 0;\n\tv143 = ~v142;\n\tif (v143) goto L_005A;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v137, v132, v134, v93, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\nL_005A:\n\tv150 = DG.Tweening.DOTween::To(v66, v80, endValue, duration);\n\tv153 = DG.Tweening.TweenSettingsExtensions::SetTarget(v150, v59.target);\n\treturn v150;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Color, Color, ColorOptions> DOColor(this Material target, Color endValue, float duration)
		{
			DOGetter<Color> getter = () => target.color;
			DOSetter<Color> setter = delegate(Color x)
			{
				target.color = x;
			};
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<Color, Color, ColorOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x60000AE")]
		[Address(RVA = "0x10E47BC", Offset = "0x10E47BC", Length = "0x1D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv42 = *([1EFE3F8]);\n\tv43 = *([v42 @ X8_v33]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, property, methodInfo, v46, v47, v48, v49, v50, endValue, v0, v2, v3, duration, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2027511]) = v56;\nL_0025:\n\tv60 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass17_0();\n\tSystem.Object::.ctor(v60);\n\tv60.target = target;\n\tv60.property = property;\n\tv71 = UnityEngine.Material::HasProperty(target, property);\n\tv73 = v71 == 0;\n\tif (v73) goto L_0071;\n\tv152 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v152, v60, Il2CppMethodInfo);\n\tv191 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v191, v60, Il2CppMethodInfo);\n\tgoto L_0065;\n\tv227 = *([v223 @ X0_v19+E0]);\n\tv228 = v227 == 0;\n\tv229 = ~v228;\n\tif (v229) goto L_0065;\n\tv231 = \"il2cpp_codegen_runtime_class_init\"(v223, v201, v203, v204, v47, v48, v49, v50, endValue, v0, v2, v3, duration, v51, v52, v53);\nL_0065:\n\tv236 = DG.Tweening.DOTween::To(v152, v191, endValue, duration);\n\tv211 = DG.Tweening.TweenSettingsExtensions::SetTarget(v236, v60.target);\n\tgoto L_0099;\nL_0071:\n\tgoto L_0087;\n\tv166 = *([1EFC598]);\n\tv167 = *([v166 @ X8_v14]);\n\tv168 = \"il2cpp_codegen_initialize_method\"(v167, v69, v70, v46, v47, v48, v49, v50, endValue, v0, v2, v3, duration, v51, v52, v53);\n\tv171 = 0 | 1;\n\t*([2022B9B]) = v171;\nL_0087:\n\tv187 = v175._logPriority < 1;\n\tif (v187) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogMissingMaterialProperty(v60.property);\nL_0099:\n\treturn v216;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 119 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Color, Color, ColorOptions> DOColor(this Material target, Color endValue, string property, float duration)
		{
			Material target2 = target;
			string property2 = property;
			if (target.HasProperty(property))
			{
				DOGetter<Color> getter = () => target2.GetColor(property2);
				DOSetter<Color> setter = delegate(Color x)
				{
					target2.SetColor(property2, x);
				};
				TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
				TweenerCore<Color, Color, ColorOptions> tweenerCore2 = tweenerCore.SetTarget(target2);
				return tweenerCore;
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogMissingMaterialProperty(property2);
			}
			return null;
		}

		[Token(Token = "0x60000AF")]
		[Address(RVA = "0x10E499C", Offset = "0x10E499C", Length = "0x1DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv42 = *([1EBDD28]);\n\tv43 = *([v42 @ X8_v33]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, propertyID, methodInfo, v46, v47, v48, v49, v50, endValue, v0, v2, v3, duration, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2027512]) = v56;\nL_0025:\n\tv60 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass18_0();\n\tSystem.Object::.ctor(v60);\n\tv60.target = target;\n\tv60.propertyID = propertyID;\n\tv71 = UnityEngine.Material::HasProperty(target, propertyID);\n\tv73 = v71 == 0;\n\tif (v73) goto L_0071;\n\tv152 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v152, v60, Il2CppMethodInfo);\n\tv191 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v191, v60, Il2CppMethodInfo);\n\tgoto L_0065;\n\tv227 = *([v223 @ X0_v19+E0]);\n\tv228 = v227 == 0;\n\tv229 = ~v228;\n\tif (v229) goto L_0065;\n\tv231 = \"il2cpp_codegen_runtime_class_init\"(v223, v201, v203, v204, v47, v48, v49, v50, endValue, v0, v2, v3, duration, v51, v52, v53);\nL_0065:\n\tv236 = DG.Tweening.DOTween::To(v152, v191, endValue, duration);\n\tv211 = DG.Tweening.TweenSettingsExtensions::SetTarget(v236, v60.target);\n\tgoto L_0099;\nL_0071:\n\tgoto L_0087;\n\tv166 = *([1EFC598]);\n\tv167 = *([v166 @ X8_v14]);\n\tv168 = \"il2cpp_codegen_initialize_method\"(v167, v69, v70, v46, v47, v48, v49, v50, endValue, v0, v2, v3, duration, v51, v52, v53);\n\tv171 = 0 | 1;\n\t*([2022B9B]) = v171;\nL_0087:\n\tv187 = v175._logPriority < 1;\n\tif (v187) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogMissingMaterialProperty(v60.propertyID);\nL_0099:\n\treturn v216;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 119 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Color, Color, ColorOptions> DOColor(this Material target, Color endValue, int propertyID, float duration)
		{
			Material target2 = target;
			int propertyID2 = propertyID;
			if (target.HasProperty(propertyID))
			{
				DOGetter<Color> getter = () => target2.GetColor(propertyID2);
				DOSetter<Color> setter = delegate(Color x)
				{
					target2.SetColor(propertyID2, x);
				};
				TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
				TweenerCore<Color, Color, ColorOptions> tweenerCore2 = tweenerCore.SetTarget(target2);
				return tweenerCore;
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogMissingMaterialProperty(propertyID2);
			}
			return null;
		}

		[Token(Token = "0x60000B0")]
		[Address(RVA = "0x10E4B80", Offset = "0x10E4B80", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1EAA9B8]);\n\tv29 = *([v28 @ X8_v22]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2027513]) = v46;\nL_001B:\n\tv50 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass19_0();\n\tSystem.Object::.ctor(v50);\n\tv50.target = target;\n\tv57 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v57, v50, Il2CppMethodInfo);\n\tv71 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v71, v50, Il2CppMethodInfo);\n\tgoto L_004D;\n\tv117 = *([v113 @ X0_v10+E0]);\n\tv118 = v117 == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_004D;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v113, v108, v110, v81, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\nL_004D:\n\tv126 = DG.Tweening.DOTween::ToAlpha(v57, v71, endValue, duration);\n\tv129 = DG.Tweening.TweenSettingsExtensions::SetTarget(v126, v50.target);\n\treturn v126;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Color, Color, ColorOptions> DOFade(this Material target, float endValue, float duration)
		{
			DOGetter<Color> getter = () => target.color;
			DOSetter<Color> setter = delegate(Color x)
			{
				target.color = x;
			};
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.ToAlpha(getter, setter, endValue, duration);
			TweenerCore<Color, Color, ColorOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x60000B1")]
		[Address(RVA = "0x10E4CC8", Offset = "0x10E4CC8", Length = "0x1B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1EFD5F0]);\n\tv31 = *([v30 @ X8_v33]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, property, methodInfo, v34, v35, v36, v37, v38, endValue, duration, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2027514]) = v47;\nL_001C:\n\tv51 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass20_0();\n\tSystem.Object::.ctor(v51);\n\tv51.target = target;\n\tv51.property = property;\n\tv62 = UnityEngine.Material::HasProperty(target, property);\n\tv64 = v62 == 0;\n\tif (v64) goto L_0064;\n\tv128 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v128, v51, Il2CppMethodInfo);\n\tv167 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v167, v51, Il2CppMethodInfo);\n\tgoto L_0058;\n\tv199 = *([v195 @ X0_v19+E0]);\n\tv200 = v199 == 0;\n\tv201 = ~v200;\n\tif (v201) goto L_0058;\n\tv203 = \"il2cpp_codegen_runtime_class_init\"(v195, v177, v179, v180, v35, v36, v37, v38, endValue, duration, v39, v40, v41, v42, v43, v44);\nL_0058:\n\tv208 = DG.Tweening.DOTween::ToAlpha(v128, v167, endValue, duration);\n\tv186 = DG.Tweening.TweenSettingsExtensions::SetTarget(v208, v51.target);\n\tgoto L_0089;\nL_0064:\n\tgoto L_007A;\n\tv142 = *([1EFC598]);\n\tv143 = *([v142 @ X8_v14]);\n\tv144 = \"il2cpp_codegen_initialize_method\"(v143, v60, v61, v34, v35, v36, v37, v38, endValue, duration, v39, v40, v41, v42, v43, v44);\n\tv147 = 0 | 1;\n\t*([2022B9B]) = v147;\nL_007A:\n\tv163 = v151._logPriority < 1;\n\tif (v163) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogMissingMaterialProperty(v51.property);\nL_0089:\n\treturn v191;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 103 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Color, Color, ColorOptions> DOFade(this Material target, float endValue, string property, float duration)
		{
			Material target2 = target;
			string property2 = property;
			if (target.HasProperty(property))
			{
				DOGetter<Color> getter = () => target2.GetColor(property2);
				DOSetter<Color> setter = delegate(Color x)
				{
					target2.SetColor(property2, x);
				};
				TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.ToAlpha(getter, setter, endValue, duration);
				TweenerCore<Color, Color, ColorOptions> tweenerCore2 = tweenerCore.SetTarget(target2);
				return tweenerCore;
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogMissingMaterialProperty(property2);
			}
			return null;
		}

		[Token(Token = "0x60000B2")]
		[Address(RVA = "0x10E4E80", Offset = "0x10E4E80", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1EBC210]);\n\tv31 = *([v30 @ X8_v33]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, propertyID, methodInfo, v34, v35, v36, v37, v38, endValue, duration, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2027515]) = v47;\nL_001C:\n\tv51 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass21_0();\n\tSystem.Object::.ctor(v51);\n\tv51.target = target;\n\tv51.propertyID = propertyID;\n\tv62 = UnityEngine.Material::HasProperty(target, propertyID);\n\tv64 = v62 == 0;\n\tif (v64) goto L_0064;\n\tv128 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v128, v51, Il2CppMethodInfo);\n\tv167 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v167, v51, Il2CppMethodInfo);\n\tgoto L_0058;\n\tv199 = *([v195 @ X0_v19+E0]);\n\tv200 = v199 == 0;\n\tv201 = ~v200;\n\tif (v201) goto L_0058;\n\tv203 = \"il2cpp_codegen_runtime_class_init\"(v195, v177, v179, v180, v35, v36, v37, v38, endValue, duration, v39, v40, v41, v42, v43, v44);\nL_0058:\n\tv208 = DG.Tweening.DOTween::ToAlpha(v128, v167, endValue, duration);\n\tv186 = DG.Tweening.TweenSettingsExtensions::SetTarget(v208, v51.target);\n\tgoto L_0089;\nL_0064:\n\tgoto L_007A;\n\tv142 = *([1EFC598]);\n\tv143 = *([v142 @ X8_v14]);\n\tv144 = \"il2cpp_codegen_initialize_method\"(v143, v60, v61, v34, v35, v36, v37, v38, endValue, duration, v39, v40, v41, v42, v43, v44);\n\tv147 = 0 | 1;\n\t*([2022B9B]) = v147;\nL_007A:\n\tv163 = v151._logPriority < 1;\n\tif (v163) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogMissingMaterialProperty(v51.propertyID);\nL_0089:\n\treturn v191;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 103 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Color, Color, ColorOptions> DOFade(this Material target, float endValue, int propertyID, float duration)
		{
			Material target2 = target;
			int propertyID2 = propertyID;
			if (target.HasProperty(propertyID))
			{
				DOGetter<Color> getter = () => target2.GetColor(propertyID2);
				DOSetter<Color> setter = delegate(Color x)
				{
					target2.SetColor(propertyID2, x);
				};
				TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.ToAlpha(getter, setter, endValue, duration);
				TweenerCore<Color, Color, ColorOptions> tweenerCore2 = tweenerCore.SetTarget(target2);
				return tweenerCore;
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogMissingMaterialProperty(propertyID2);
			}
			return null;
		}

		[Token(Token = "0x60000B3")]
		[Address(RVA = "0x10E503C", Offset = "0x10E503C", Length = "0x1B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1EABA70]);\n\tv31 = *([v30 @ X8_v33]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, property, methodInfo, v34, v35, v36, v37, v38, endValue, duration, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2027516]) = v47;\nL_001C:\n\tv51 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass22_0();\n\tSystem.Object::.ctor(v51);\n\tv51.target = target;\n\tv51.property = property;\n\tv62 = UnityEngine.Material::HasProperty(target, property);\n\tv64 = v62 == 0;\n\tif (v64) goto L_0064;\n\tv128 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v128, v51, Il2CppMethodInfo);\n\tv167 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v167, v51, Il2CppMethodInfo);\n\tgoto L_0058;\n\tv199 = *([v195 @ X0_v19+E0]);\n\tv200 = v199 == 0;\n\tv201 = ~v200;\n\tif (v201) goto L_0058;\n\tv203 = \"il2cpp_codegen_runtime_class_init\"(v195, v177, v179, v180, v35, v36, v37, v38, endValue, duration, v39, v40, v41, v42, v43, v44);\nL_0058:\n\tv208 = DG.Tweening.DOTween::To(v128, v167, endValue, duration);\n\tv186 = DG.Tweening.TweenSettingsExtensions::SetTarget(v208, v51.target);\n\tgoto L_0089;\nL_0064:\n\tgoto L_007A;\n\tv142 = *([1EFC598]);\n\tv143 = *([v142 @ X8_v14]);\n\tv144 = \"il2cpp_codegen_initialize_method\"(v143, v60, v61, v34, v35, v36, v37, v38, endValue, duration, v39, v40, v41, v42, v43, v44);\n\tv147 = 0 | 1;\n\t*([2022B9B]) = v147;\nL_007A:\n\tv163 = v151._logPriority < 1;\n\tif (v163) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogMissingMaterialProperty(v51.property);\nL_0089:\n\treturn v191;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 103 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<float, float, FloatOptions> DOFloat(this Material target, float endValue, string property, float duration)
		{
			Material target2 = target;
			string property2 = property;
			if (target.HasProperty(property))
			{
				DOGetter<float> getter = () => target2.GetFloat(property2);
				DOSetter<float> setter = delegate(float x)
				{
					target2.SetFloat(property2, x);
				};
				TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
				TweenerCore<float, float, FloatOptions> tweenerCore2 = tweenerCore.SetTarget(target2);
				return tweenerCore;
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogMissingMaterialProperty(property2);
			}
			return null;
		}

		[Token(Token = "0x60000B4")]
		[Address(RVA = "0x10E51F4", Offset = "0x10E51F4", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1EE45D8]);\n\tv31 = *([v30 @ X8_v33]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, propertyID, methodInfo, v34, v35, v36, v37, v38, endValue, duration, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2027517]) = v47;\nL_001C:\n\tv51 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass23_0();\n\tSystem.Object::.ctor(v51);\n\tv51.target = target;\n\tv51.propertyID = propertyID;\n\tv62 = UnityEngine.Material::HasProperty(target, propertyID);\n\tv64 = v62 == 0;\n\tif (v64) goto L_0064;\n\tv128 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v128, v51, Il2CppMethodInfo);\n\tv167 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v167, v51, Il2CppMethodInfo);\n\tgoto L_0058;\n\tv199 = *([v195 @ X0_v19+E0]);\n\tv200 = v199 == 0;\n\tv201 = ~v200;\n\tif (v201) goto L_0058;\n\tv203 = \"il2cpp_codegen_runtime_class_init\"(v195, v177, v179, v180, v35, v36, v37, v38, endValue, duration, v39, v40, v41, v42, v43, v44);\nL_0058:\n\tv208 = DG.Tweening.DOTween::To(v128, v167, endValue, duration);\n\tv186 = DG.Tweening.TweenSettingsExtensions::SetTarget(v208, v51.target);\n\tgoto L_0089;\nL_0064:\n\tgoto L_007A;\n\tv142 = *([1EFC598]);\n\tv143 = *([v142 @ X8_v14]);\n\tv144 = \"il2cpp_codegen_initialize_method\"(v143, v60, v61, v34, v35, v36, v37, v38, endValue, duration, v39, v40, v41, v42, v43, v44);\n\tv147 = 0 | 1;\n\t*([2022B9B]) = v147;\nL_007A:\n\tv163 = v151._logPriority < 1;\n\tif (v163) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogMissingMaterialProperty(v51.propertyID);\nL_0089:\n\treturn v191;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 103 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<float, float, FloatOptions> DOFloat(this Material target, float endValue, int propertyID, float duration)
		{
			Material target2 = target;
			int propertyID2 = propertyID;
			if (target.HasProperty(propertyID))
			{
				DOGetter<float> getter = () => target2.GetFloat(propertyID2);
				DOSetter<float> setter = delegate(float x)
				{
					target2.SetFloat(propertyID2, x);
				};
				TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
				TweenerCore<float, float, FloatOptions> tweenerCore2 = tweenerCore.SetTarget(target2);
				return tweenerCore;
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogMissingMaterialProperty(propertyID2);
			}
			return null;
		}

		[Token(Token = "0x60000B5")]
		[Address(RVA = "0x10E53B0", Offset = "0x10E53B0", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv32 = *([1EDEBF8]);\n\tv33 = *([v32 @ X8_v22]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, endValue, v0, duration, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2027518]) = v49;\nL_001E:\n\tv53 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass24_0();\n\tSystem.Object::.ctor(v53);\n\tv53.target = target;\n\tv60 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v60, v53, Il2CppMethodInfo);\n\tv74 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v74, v53, Il2CppMethodInfo);\n\tgoto L_0052;\n\tv127 = *([v123 @ X0_v10+E0]);\n\tv128 = v127 == 0;\n\tv129 = ~v128;\n\tif (v129) goto L_0052;\n\tv131 = \"il2cpp_codegen_runtime_class_init\"(v123, v118, v120, v87, v38, v39, v40, v41, endValue, v0, duration, v42, v43, v44, v45, v46);\nL_0052:\n\tv136 = DG.Tweening.DOTween::To(v60, v74, endValue, duration);\n\tv139 = DG.Tweening.TweenSettingsExtensions::SetTarget(v136, v53.target);\n\treturn v136;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector2, Vector2, VectorOptions> DOOffset(this Material target, Vector2 endValue, float duration)
		{
			DOGetter<Vector2> getter = () => target.mainTextureOffset;
			DOSetter<Vector2> setter = delegate(Vector2 x)
			{
				target.mainTextureOffset = x;
			};
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x60000B6")]
		[Address(RVA = "0x10E5508", Offset = "0x10E5508", Length = "0x1C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv34 = *([1EA4860]);\n\tv35 = *([v34 @ X8_v33]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, property, methodInfo, v38, v39, v40, v41, v42, endValue, v0, duration, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2027519]) = v50;\nL_001F:\n\tv54 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass25_0();\n\tSystem.Object::.ctor(v54);\n\tv54.target = target;\n\tv54.property = property;\n\tv65 = UnityEngine.Material::HasProperty(target, property);\n\tv67 = v65 == 0;\n\tif (v67) goto L_0069;\n\tv138 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v138, v54, Il2CppMethodInfo);\n\tv177 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v177, v54, Il2CppMethodInfo);\n\tgoto L_005D;\n\tv211 = *([v207 @ X0_v19+E0]);\n\tv212 = v211 == 0;\n\tv213 = ~v212;\n\tif (v213) goto L_005D;\n\tv215 = \"il2cpp_codegen_runtime_class_init\"(v207, v187, v189, v190, v39, v40, v41, v42, endValue, v0, duration, v43, v44, v45, v46, v47);\nL_005D:\n\tv220 = DG.Tweening.DOTween::To(v138, v177, endValue, duration);\n\tv197 = DG.Tweening.TweenSettingsExtensions::SetTarget(v220, v54.target);\n\tgoto L_008F;\nL_0069:\n\tgoto L_007F;\n\tv152 = *([1EFC598]);\n\tv153 = *([v152 @ X8_v14]);\n\tv154 = \"il2cpp_codegen_initialize_method\"(v153, v63, v64, v38, v39, v40, v41, v42, endValue, v0, duration, v43, v44, v45, v46, v47);\n\tv157 = 0 | 1;\n\t*([2022B9B]) = v157;\nL_007F:\n\tv173 = v161._logPriority < 1;\n\tif (v173) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogMissingMaterialProperty(v54.property);\nL_008F:\n\treturn v202;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 109 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector2, Vector2, VectorOptions> DOOffset(this Material target, Vector2 endValue, string property, float duration)
		{
			Material target2 = target;
			string property2 = property;
			if (target.HasProperty(property))
			{
				DOGetter<Vector2> getter = () => target2.GetTextureOffset(property2);
				DOSetter<Vector2> setter = delegate(Vector2 x)
				{
					target2.SetTextureOffset(property2, x);
				};
				TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
				TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore2 = tweenerCore.SetTarget(target2);
				return tweenerCore;
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogMissingMaterialProperty(property2);
			}
			return null;
		}

		[Token(Token = "0x60000B7")]
		[Address(RVA = "0x10E56D0", Offset = "0x10E56D0", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv32 = *([1EB2F60]);\n\tv33 = *([v32 @ X8_v22]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, endValue, v0, duration, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([202751A]) = v49;\nL_001E:\n\tv53 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass26_0();\n\tSystem.Object::.ctor(v53);\n\tv53.target = target;\n\tv60 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v60, v53, Il2CppMethodInfo);\n\tv74 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v74, v53, Il2CppMethodInfo);\n\tgoto L_0052;\n\tv127 = *([v123 @ X0_v10+E0]);\n\tv128 = v127 == 0;\n\tv129 = ~v128;\n\tif (v129) goto L_0052;\n\tv131 = \"il2cpp_codegen_runtime_class_init\"(v123, v118, v120, v87, v38, v39, v40, v41, endValue, v0, duration, v42, v43, v44, v45, v46);\nL_0052:\n\tv136 = DG.Tweening.DOTween::To(v60, v74, endValue, duration);\n\tv139 = DG.Tweening.TweenSettingsExtensions::SetTarget(v136, v53.target);\n\treturn v136;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector2, Vector2, VectorOptions> DOTiling(this Material target, Vector2 endValue, float duration)
		{
			DOGetter<Vector2> getter = () => target.mainTextureScale;
			DOSetter<Vector2> setter = delegate(Vector2 x)
			{
				target.mainTextureScale = x;
			};
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x60000B8")]
		[Address(RVA = "0x10E5828", Offset = "0x10E5828", Length = "0x1C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv34 = *([1F10D80]);\n\tv35 = *([v34 @ X8_v33]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, property, methodInfo, v38, v39, v40, v41, v42, endValue, v0, duration, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202751B]) = v50;\nL_001F:\n\tv54 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass27_0();\n\tSystem.Object::.ctor(v54);\n\tv54.target = target;\n\tv54.property = property;\n\tv65 = UnityEngine.Material::HasProperty(target, property);\n\tv67 = v65 == 0;\n\tif (v67) goto L_0069;\n\tv138 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v138, v54, Il2CppMethodInfo);\n\tv177 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v177, v54, Il2CppMethodInfo);\n\tgoto L_005D;\n\tv211 = *([v207 @ X0_v19+E0]);\n\tv212 = v211 == 0;\n\tv213 = ~v212;\n\tif (v213) goto L_005D;\n\tv215 = \"il2cpp_codegen_runtime_class_init\"(v207, v187, v189, v190, v39, v40, v41, v42, endValue, v0, duration, v43, v44, v45, v46, v47);\nL_005D:\n\tv220 = DG.Tweening.DOTween::To(v138, v177, endValue, duration);\n\tv197 = DG.Tweening.TweenSettingsExtensions::SetTarget(v220, v54.target);\n\tgoto L_008F;\nL_0069:\n\tgoto L_007F;\n\tv152 = *([1EFC598]);\n\tv153 = *([v152 @ X8_v14]);\n\tv154 = \"il2cpp_codegen_initialize_method\"(v153, v63, v64, v38, v39, v40, v41, v42, endValue, v0, duration, v43, v44, v45, v46, v47);\n\tv157 = 0 | 1;\n\t*([2022B9B]) = v157;\nL_007F:\n\tv173 = v161._logPriority < 1;\n\tif (v173) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogMissingMaterialProperty(v54.property);\nL_008F:\n\treturn v202;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 109 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector2, Vector2, VectorOptions> DOTiling(this Material target, Vector2 endValue, string property, float duration)
		{
			Material target2 = target;
			string property2 = property;
			if (target.HasProperty(property))
			{
				DOGetter<Vector2> getter = () => target2.GetTextureScale(property2);
				DOSetter<Vector2> setter = delegate(Vector2 x)
				{
					target2.SetTextureScale(property2, x);
				};
				TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
				TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore2 = tweenerCore.SetTarget(target2);
				return tweenerCore;
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogMissingMaterialProperty(property2);
			}
			return null;
		}

		[Token(Token = "0x60000B9")]
		[Address(RVA = "0x10E59F0", Offset = "0x10E59F0", Length = "0x1D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv42 = *([1ED4888]);\n\tv43 = *([v42 @ X8_v33]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, property, methodInfo, v46, v47, v48, v49, v50, endValue, v0, v2, v3, duration, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([202751C]) = v56;\nL_0025:\n\tv60 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass28_0();\n\tSystem.Object::.ctor(v60);\n\tv60.target = target;\n\tv60.property = property;\n\tv71 = UnityEngine.Material::HasProperty(target, property);\n\tv73 = v71 == 0;\n\tif (v73) goto L_0071;\n\tv152 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>::.ctor(v152, v60, Il2CppMethodInfo);\n\tv191 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector4>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector4>::.ctor(v191, v60, Il2CppMethodInfo);\n\tgoto L_0065;\n\tv227 = *([v223 @ X0_v19+E0]);\n\tv228 = v227 == 0;\n\tv229 = ~v228;\n\tif (v229) goto L_0065;\n\tv231 = \"il2cpp_codegen_runtime_class_init\"(v223, v201, v203, v204, v47, v48, v49, v50, endValue, v0, v2, v3, duration, v51, v52, v53);\nL_0065:\n\tv236 = DG.Tweening.DOTween::To(v152, v191, endValue, duration);\n\tv211 = DG.Tweening.TweenSettingsExtensions::SetTarget(v236, v60.target);\n\tgoto L_0099;\nL_0071:\n\tgoto L_0087;\n\tv166 = *([1EFC598]);\n\tv167 = *([v166 @ X8_v14]);\n\tv168 = \"il2cpp_codegen_initialize_method\"(v167, v69, v70, v46, v47, v48, v49, v50, endValue, v0, v2, v3, duration, v51, v52, v53);\n\tv171 = 0 | 1;\n\t*([2022B9B]) = v171;\nL_0087:\n\tv187 = v175._logPriority < 1;\n\tif (v187) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogMissingMaterialProperty(v60.property);\nL_0099:\n\treturn v216;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 119 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector4, Vector4, VectorOptions> DOVector(this Material target, Vector4 endValue, string property, float duration)
		{
			Material target2 = target;
			string property2 = property;
			if (target.HasProperty(property))
			{
				DOGetter<Vector4> getter = () => target2.GetVector(property2);
				DOSetter<Vector4> setter = delegate(Vector4 x)
				{
					target2.SetVector(property2, x);
				};
				TweenerCore<Vector4, Vector4, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
				TweenerCore<Vector4, Vector4, VectorOptions> tweenerCore2 = tweenerCore.SetTarget(target2);
				return tweenerCore;
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogMissingMaterialProperty(property2);
			}
			return null;
		}

		[Token(Token = "0x60000BA")]
		[Address(RVA = "0x10E5BD0", Offset = "0x10E5BD0", Length = "0x1DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv42 = *([1EE7568]);\n\tv43 = *([v42 @ X8_v33]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, propertyID, methodInfo, v46, v47, v48, v49, v50, endValue, v0, v2, v3, duration, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([202751D]) = v56;\nL_0025:\n\tv60 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass29_0();\n\tSystem.Object::.ctor(v60);\n\tv60.target = target;\n\tv60.propertyID = propertyID;\n\tv71 = UnityEngine.Material::HasProperty(target, propertyID);\n\tv73 = v71 == 0;\n\tif (v73) goto L_0071;\n\tv152 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>::.ctor(v152, v60, Il2CppMethodInfo);\n\tv191 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector4>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector4>::.ctor(v191, v60, Il2CppMethodInfo);\n\tgoto L_0065;\n\tv227 = *([v223 @ X0_v19+E0]);\n\tv228 = v227 == 0;\n\tv229 = ~v228;\n\tif (v229) goto L_0065;\n\tv231 = \"il2cpp_codegen_runtime_class_init\"(v223, v201, v203, v204, v47, v48, v49, v50, endValue, v0, v2, v3, duration, v51, v52, v53);\nL_0065:\n\tv236 = DG.Tweening.DOTween::To(v152, v191, endValue, duration);\n\tv211 = DG.Tweening.TweenSettingsExtensions::SetTarget(v236, v60.target);\n\tgoto L_0099;\nL_0071:\n\tgoto L_0087;\n\tv166 = *([1EFC598]);\n\tv167 = *([v166 @ X8_v14]);\n\tv168 = \"il2cpp_codegen_initialize_method\"(v167, v69, v70, v46, v47, v48, v49, v50, endValue, v0, v2, v3, duration, v51, v52, v53);\n\tv171 = 0 | 1;\n\t*([2022B9B]) = v171;\nL_0087:\n\tv187 = v175._logPriority < 1;\n\tif (v187) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogMissingMaterialProperty(v60.propertyID);\nL_0099:\n\treturn v216;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 119 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector4, Vector4, VectorOptions> DOVector(this Material target, Vector4 endValue, int propertyID, float duration)
		{
			Material target2 = target;
			int propertyID2 = propertyID;
			if (target.HasProperty(propertyID))
			{
				DOGetter<Vector4> getter = () => target2.GetVector(propertyID2);
				DOSetter<Vector4> setter = delegate(Vector4 x)
				{
					target2.SetVector(propertyID2, x);
				};
				TweenerCore<Vector4, Vector4, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
				TweenerCore<Vector4, Vector4, VectorOptions> tweenerCore2 = tweenerCore.SetTarget(target2);
				return tweenerCore;
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogMissingMaterialProperty(propertyID2);
			}
			return null;
		}

		[Token(Token = "0x60000BB")]
		[Address(RVA = "0x10E5DB4", Offset = "0x10E5DB4", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv32 = *([1ED3830]);\n\tv33 = *([v32 @ X8_v22]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, toStartWidth, toEndWidth, duration, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([202751E]) = v49;\nL_001D:\n\tv53 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass30_0();\n\tSystem.Object::.ctor(v53);\n\tv53.target = target;\n\tv60 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v60, v53, Il2CppMethodInfo);\n\tv74 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v74, v53, Il2CppMethodInfo);\n\tv83 = 0;\n\tv128 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(&v83 @ stack_-48_v1, 0, Il2CppMethodInfo);\n\tgoto L_0056;\n\tv135 = *([v131 @ X0_v12+E0]);\n\tv136 = v135 == 0;\n\tv137 = ~v136;\n\tif (v137) goto L_0056;\n\tv139 = \"il2cpp_codegen_runtime_class_init\"(v131, v127, v123, v92, v38, v39, v40, v41, v125, v126, duration, v42, v43, v44, v45, v46);\nL_0056:\n\t// 86 MakeStruct v78 @ AGG10E5EDC_2_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0, v141 @ stack_-44\n\tv145 = DG.Tweening.DOTween::To(v60, v74, v78, duration);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v145, v53.target);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOResize(this TrailRenderer target, float toStartWidth, float toEndWidth, float duration)
		{
			//IL_004d: Expected O, but got I4
			//IL_006d: Expected F4, but got O
			DOGetter<Vector2> getter = delegate
			{
				float startWidth = target.startWidth;
				float endWidth = target.endWidth;
				Vector2 vector = default(Vector2);
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
				return default(Vector2);
			};
			DOSetter<Vector2> setter = delegate(Vector2 x)
			{
				Vector2 vector = default(Vector2);
				target.startWidth = vector.x;
				target.endWidth = x.y;
			};
			object obj = 0;
			Vector2 endValue = default(Vector2);
			endValue.x = 0f;
			object obj2 = default(object);
			endValue.y = (float)obj2;
			TweenerCore<Vector2, Vector2, VectorOptions> t = DOTween.To(getter, setter, endValue, duration);
			return t.SetTarget(target);
		}

		[Token(Token = "0x60000BC")]
		[Address(RVA = "0x10E5F20", Offset = "0x10E5F20", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1F046F0]);\n\tv29 = *([v28 @ X8_v22]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202751F]) = v46;\nL_001B:\n\tv50 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass31_0();\n\tSystem.Object::.ctor(v50);\n\tv50.target = target;\n\tv57 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v57, v50, Il2CppMethodInfo);\n\tv71 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v71, v50, Il2CppMethodInfo);\n\tgoto L_004D;\n\tv117 = *([v113 @ X0_v10+E0]);\n\tv118 = v117 == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_004D;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v113, v108, v110, v81, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\nL_004D:\n\tv126 = DG.Tweening.DOTween::To(v57, v71, endValue, duration);\n\tv129 = DG.Tweening.TweenSettingsExtensions::SetTarget(v126, v50.target);\n\treturn v126;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<float, float, FloatOptions> DOTime(this TrailRenderer target, float endValue, float duration)
		{
			DOGetter<float> getter = () => target.time;
			DOSetter<float> setter = delegate(float x)
			{
				target.time = x;
			};
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<float, float, FloatOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x60000BD")]
		[Address(RVA = "0x10E6068", Offset = "0x10E6068", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv40 = *([1EAF9F0]);\n\tv41 = *([v40 @ X8_v22]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, snapping, methodInfo, v44, v45, v46, v47, v48, endValue, v0, v2, duration, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2027520]) = v55;\nL_0023:\n\tv59 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass32_0();\n\tSystem.Object::.ctor(v59);\n\tv59.target = target;\n\tv66 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v66, v59, Il2CppMethodInfo);\n\tv80 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v80, v59, Il2CppMethodInfo);\n\tgoto L_0058;\n\tv139 = *([v135 @ X0_v10+E0]);\n\tv140 = v139 == 0;\n\tv141 = ~v140;\n\tif (v141) goto L_0058;\n\tv143 = \"il2cpp_codegen_runtime_class_init\"(v135, v130, v132, v93, v45, v46, v47, v48, endValue, v0, v2, duration, v49, v50, v51, v52);\nL_0058:\n\tv148 = DG.Tweening.DOTween::To(v66, v80, endValue, duration);\n\tv152 = DG.Tweening.TweenSettingsExtensions::SetOptions(v148, snapping);\n\tv154 = DG.Tweening.TweenSettingsExtensions::SetTarget(v152, v59.target);\n\treturn v148;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOMove(this Transform target, Vector3 endValue, float duration, bool snapping = false)
		{
			DOGetter<Vector3> getter = () => target.position;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.position = x;
			};
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			Tweener t = tweenerCore.SetOptions(snapping);
			Tweener tweener = t.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x60000BE")]
		[Address(RVA = "0x10E61D8", Offset = "0x10E61D8", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv32 = *([1F0BE90]);\n\tv33 = *([v32 @ X8_v22]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, snapping, methodInfo, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2027521]) = v49;\nL_001D:\n\tv53 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass33_0();\n\tSystem.Object::.ctor(v53);\n\tv53.target = target;\n\tv60 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v60, v53, Il2CppMethodInfo);\n\tv74 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v74, v53, Il2CppMethodInfo);\n\tv83 = 0;\n\tv135 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(&v83 @ stack_-50_v1, 0, Il2CppMethodInfo);\n\tgoto L_0059;\n\tv142 = *([v138 @ X0_v12+E0]);\n\tv143 = v142 == 0;\n\tv144 = ~v143;\n\tif (v144) goto L_0059;\n\tv146 = \"il2cpp_codegen_runtime_class_init\"(v138, v134, v128, v129, v37, v38, v39, v40, v133, v131, v132, v42, v43, v44, v45, v46);\nL_0059:\n\t// 89 MakeStruct v78 @ AGG10E6308_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v148 @ stack_-4C, 0\n\tv152 = DG.Tweening.DOTween::To(v60, v74, v78, duration);\n\tv156 = DG.Tweening.TweenSettingsExtensions::SetOptions(v152, 2, snapping);\n\tv158 = DG.Tweening.TweenSettingsExtensions::SetTarget(v156, v53.target);\n\treturn v152;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOMoveX(this Transform target, float endValue, float duration, bool snapping = false)
		{
			//IL_004d: Expected O, but got I4
			//IL_006d: Expected F4, but got O
			DOGetter<Vector3> getter = () => target.position;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.position = x;
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

		[Token(Token = "0x60000BF")]
		[Address(RVA = "0x10E6360", Offset = "0x10E6360", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv32 = *([1EAA598]);\n\tv33 = *([v32 @ X8_v22]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, snapping, methodInfo, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2027522]) = v49;\nL_001D:\n\tv53 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass34_0();\n\tSystem.Object::.ctor(v53);\n\tv53.target = target;\n\tv60 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v60, v53, Il2CppMethodInfo);\n\tv74 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v74, v53, Il2CppMethodInfo);\n\tv83 = 0;\n\tv135 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(&v83 @ stack_-50_v1, 0, Il2CppMethodInfo);\n\tgoto L_0059;\n\tv142 = *([v138 @ X0_v12+E0]);\n\tv143 = v142 == 0;\n\tv144 = ~v143;\n\tif (v144) goto L_0059;\n\tv146 = \"il2cpp_codegen_runtime_class_init\"(v138, v134, v128, v129, v37, v38, v39, v40, v131, v133, v132, v42, v43, v44, v45, v46);\nL_0059:\n\t// 89 MakeStruct v78 @ AGG10E6490_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v148 @ stack_-4C, 0\n\tv152 = DG.Tweening.DOTween::To(v60, v74, v78, duration);\n\tv156 = DG.Tweening.TweenSettingsExtensions::SetOptions(v152, 4, snapping);\n\tv158 = DG.Tweening.TweenSettingsExtensions::SetTarget(v156, v53.target);\n\treturn v152;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOMoveY(this Transform target, float endValue, float duration, bool snapping = false)
		{
			//IL_004d: Expected O, but got I4
			//IL_006d: Expected F4, but got O
			DOGetter<Vector3> getter = () => target.position;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.position = x;
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

		[Token(Token = "0x60000C0")]
		[Address(RVA = "0x10E64E8", Offset = "0x10E64E8", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv32 = *([1EB87B0]);\n\tv33 = *([v32 @ X8_v22]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, snapping, methodInfo, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2027523]) = v49;\nL_001D:\n\tv53 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass35_0();\n\tSystem.Object::.ctor(v53);\n\tv53.target = target;\n\tv60 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v60, v53, Il2CppMethodInfo);\n\tv74 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v74, v53, Il2CppMethodInfo);\n\tv83 = 0;\n\tv135 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(&v83 @ stack_-50_v1, 0, Il2CppMethodInfo);\n\tgoto L_0059;\n\tv142 = *([v138 @ X0_v12+E0]);\n\tv143 = v142 == 0;\n\tv144 = ~v143;\n\tif (v144) goto L_0059;\n\tv146 = \"il2cpp_codegen_runtime_class_init\"(v138, v134, v128, v129, v37, v38, v39, v40, v131, v132, v133, v42, v43, v44, v45, v46);\nL_0059:\n\t// 89 MakeStruct v78 @ AGG10E6618_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v148 @ stack_-4C, 0\n\tv152 = DG.Tweening.DOTween::To(v60, v74, v78, duration);\n\tv156 = DG.Tweening.TweenSettingsExtensions::SetOptions(v152, 8, snapping);\n\tv158 = DG.Tweening.TweenSettingsExtensions::SetTarget(v156, v53.target);\n\treturn v152;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOMoveZ(this Transform target, float endValue, float duration, bool snapping = false)
		{
			//IL_004d: Expected O, but got I4
			//IL_006d: Expected F4, but got O
			DOGetter<Vector3> getter = () => target.position;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.position = x;
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

		[Token(Token = "0x60000C1")]
		[Address(RVA = "0x10E6670", Offset = "0x10E6670", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv40 = *([1EED2F0]);\n\tv41 = *([v40 @ X8_v22]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, snapping, methodInfo, v44, v45, v46, v47, v48, endValue, v0, v2, duration, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2027524]) = v55;\nL_0023:\n\tv59 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass36_0();\n\tSystem.Object::.ctor(v59);\n\tv59.target = target;\n\tv66 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v66, v59, Il2CppMethodInfo);\n\tv80 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v80, v59, Il2CppMethodInfo);\n\tgoto L_0058;\n\tv139 = *([v135 @ X0_v10+E0]);\n\tv140 = v139 == 0;\n\tv141 = ~v140;\n\tif (v141) goto L_0058;\n\tv143 = \"il2cpp_codegen_runtime_class_init\"(v135, v130, v132, v93, v45, v46, v47, v48, endValue, v0, v2, duration, v49, v50, v51, v52);\nL_0058:\n\tv148 = DG.Tweening.DOTween::To(v66, v80, endValue, duration);\n\tv152 = DG.Tweening.TweenSettingsExtensions::SetOptions(v148, snapping);\n\tv154 = DG.Tweening.TweenSettingsExtensions::SetTarget(v152, v59.target);\n\treturn v148;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOLocalMove(this Transform target, Vector3 endValue, float duration, bool snapping = false)
		{
			DOGetter<Vector3> getter = () => target.localPosition;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.localPosition = x;
			};
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			Tweener t = tweenerCore.SetOptions(snapping);
			Tweener tweener = t.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x60000C2")]
		[Address(RVA = "0x10E67E0", Offset = "0x10E67E0", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv32 = *([1EDC3D0]);\n\tv33 = *([v32 @ X8_v22]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, snapping, methodInfo, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2027525]) = v49;\nL_001D:\n\tv53 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass37_0();\n\tSystem.Object::.ctor(v53);\n\tv53.target = target;\n\tv60 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v60, v53, Il2CppMethodInfo);\n\tv74 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v74, v53, Il2CppMethodInfo);\n\tv83 = 0;\n\tv135 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(&v83 @ stack_-50_v1, 0, Il2CppMethodInfo);\n\tgoto L_0059;\n\tv142 = *([v138 @ X0_v12+E0]);\n\tv143 = v142 == 0;\n\tv144 = ~v143;\n\tif (v144) goto L_0059;\n\tv146 = \"il2cpp_codegen_runtime_class_init\"(v138, v134, v128, v129, v37, v38, v39, v40, v133, v131, v132, v42, v43, v44, v45, v46);\nL_0059:\n\t// 89 MakeStruct v78 @ AGG10E6910_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v148 @ stack_-4C, 0\n\tv152 = DG.Tweening.DOTween::To(v60, v74, v78, duration);\n\tv156 = DG.Tweening.TweenSettingsExtensions::SetOptions(v152, 2, snapping);\n\tv158 = DG.Tweening.TweenSettingsExtensions::SetTarget(v156, v53.target);\n\treturn v152;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOLocalMoveX(this Transform target, float endValue, float duration, bool snapping = false)
		{
			//IL_004d: Expected O, but got I4
			//IL_006d: Expected F4, but got O
			DOGetter<Vector3> getter = () => target.localPosition;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.localPosition = x;
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

		[Token(Token = "0x60000C3")]
		[Address(RVA = "0x10E6968", Offset = "0x10E6968", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv32 = *([1EC4AD0]);\n\tv33 = *([v32 @ X8_v22]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, snapping, methodInfo, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2027526]) = v49;\nL_001D:\n\tv53 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass38_0();\n\tSystem.Object::.ctor(v53);\n\tv53.target = target;\n\tv60 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v60, v53, Il2CppMethodInfo);\n\tv74 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v74, v53, Il2CppMethodInfo);\n\tv83 = 0;\n\tv135 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(&v83 @ stack_-50_v1, 0, Il2CppMethodInfo);\n\tgoto L_0059;\n\tv142 = *([v138 @ X0_v12+E0]);\n\tv143 = v142 == 0;\n\tv144 = ~v143;\n\tif (v144) goto L_0059;\n\tv146 = \"il2cpp_codegen_runtime_class_init\"(v138, v134, v128, v129, v37, v38, v39, v40, v131, v133, v132, v42, v43, v44, v45, v46);\nL_0059:\n\t// 89 MakeStruct v78 @ AGG10E6A98_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v148 @ stack_-4C, 0\n\tv152 = DG.Tweening.DOTween::To(v60, v74, v78, duration);\n\tv156 = DG.Tweening.TweenSettingsExtensions::SetOptions(v152, 4, snapping);\n\tv158 = DG.Tweening.TweenSettingsExtensions::SetTarget(v156, v53.target);\n\treturn v152;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOLocalMoveY(this Transform target, float endValue, float duration, bool snapping = false)
		{
			//IL_004d: Expected O, but got I4
			//IL_006d: Expected F4, but got O
			DOGetter<Vector3> getter = () => target.localPosition;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.localPosition = x;
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

		[Token(Token = "0x60000C4")]
		[Address(RVA = "0x10E6AF0", Offset = "0x10E6AF0", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv32 = *([1F017D0]);\n\tv33 = *([v32 @ X8_v22]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, snapping, methodInfo, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2027527]) = v49;\nL_001D:\n\tv53 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass39_0();\n\tSystem.Object::.ctor(v53);\n\tv53.target = target;\n\tv60 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v60, v53, Il2CppMethodInfo);\n\tv74 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v74, v53, Il2CppMethodInfo);\n\tv83 = 0;\n\tv135 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(&v83 @ stack_-50_v1, 0, Il2CppMethodInfo);\n\tgoto L_0059;\n\tv142 = *([v138 @ X0_v12+E0]);\n\tv143 = v142 == 0;\n\tv144 = ~v143;\n\tif (v144) goto L_0059;\n\tv146 = \"il2cpp_codegen_runtime_class_init\"(v138, v134, v128, v129, v37, v38, v39, v40, v131, v132, v133, v42, v43, v44, v45, v46);\nL_0059:\n\t// 89 MakeStruct v78 @ AGG10E6C20_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v148 @ stack_-4C, 0\n\tv152 = DG.Tweening.DOTween::To(v60, v74, v78, duration);\n\tv156 = DG.Tweening.TweenSettingsExtensions::SetOptions(v152, 8, snapping);\n\tv158 = DG.Tweening.TweenSettingsExtensions::SetTarget(v156, v53.target);\n\treturn v152;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOLocalMoveZ(this Transform target, float endValue, float duration, bool snapping = false)
		{
			//IL_004d: Expected O, but got I4
			//IL_006d: Expected F4, but got O
			DOGetter<Vector3> getter = () => target.localPosition;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.localPosition = x;
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

		[Token(Token = "0x60000C5")]
		[Address(RVA = "0x10E6C78", Offset = "0x10E6C78", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv40 = *([1ED57E0]);\n\tv41 = *([v40 @ X8_v23]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, mode, methodInfo, v44, v45, v46, v47, v48, endValue, v0, v2, duration, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2027528]) = v55;\nL_0023:\n\tv59 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass40_0();\n\tSystem.Object::.ctor(v59);\n\tv59.target = target;\n\tv66 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>::.ctor(v66, v59, Il2CppMethodInfo);\n\tv111 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>::.ctor(v111, v59, Il2CppMethodInfo);\n\tgoto L_0058;\n\tv156 = *([v152 @ X0_v11+E0]);\n\tv157 = v156 == 0;\n\tv158 = ~v157;\n\tif (v158) goto L_0058;\n\tv160 = \"il2cpp_codegen_runtime_class_init\"(v152, v148, v149, v77, v45, v46, v47, v48, endValue, v0, v2, duration, v49, v50, v51, v52);\nL_0058:\n\tv166 = DG.Tweening.DOTween::To(v66, v111, endValue, duration);\n\tv86 = DG.Tweening.TweenSettingsExtensions::SetTarget(v166, v59.target);\n\tv166.plugOptions.rotateMode = mode;\n\treturn v166;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Quaternion, Vector3, QuaternionOptions> DORotate(this Transform target, Vector3 endValue, float duration, RotateMode mode = RotateMode.Fast)
		{
			DOGetter<Quaternion> getter = () => target.rotation;
			DOSetter<Quaternion> setter = delegate(Quaternion x)
			{
				target.rotation = x;
			};
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			tweenerCore.plugOptions.rotateMode = mode;
			return tweenerCore;
		}

		[Token(Token = "0x60000C6")]
		[Address(RVA = "0x10E6DE4", Offset = "0x10E6DE4", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv42 = *([1EB5AE8]);\n\tv43 = *([v42 @ X8_v25]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, methodInfo, v46, v47, v48, v49, v50, v51, endValue, v0, v2, v3, duration, v52, v53, v54);\n\tv57 = 0 | 1;\n\t*([2027529]) = v57;\nL_0025:\n\tv61 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass41_0();\n\tSystem.Object::.ctor(v61);\n\tv61.target = target;\n\tv66 = DG.Tweening.CustomPlugins.PureQuaternionPlugin::Plug();\n\tv74 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>::.ctor(v74, v61, Il2CppMethodInfo);\n\tv136 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>::.ctor(v136, v61, Il2CppMethodInfo);\n\tgoto L_0062;\n\tv150 = *([v146 @ X0_v12+E0]);\n\tv151 = v150 == 0;\n\tv152 = ~v151;\n\tif (v152) goto L_0062;\n\tv154 = \"il2cpp_codegen_runtime_class_init\"(v146, v140, v142, v143, v48, v49, v50, v51, endValue, v0, v2, v3, duration, v52, v53, v54);\nL_0062:\n\tv161 = DG.Tweening.DOTween::To(v66, v74, v136, endValue, duration);\n\tv164 = DG.Tweening.TweenSettingsExtensions::SetTarget(v161, v61.target);\n\treturn v161;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Quaternion, Quaternion, NoOptions> DORotateQuaternion(this Transform target, Quaternion endValue, float duration)
		{
			PureQuaternionPlugin plugin = PureQuaternionPlugin.Plug();
			DOGetter<Quaternion> getter = () => target.rotation;
			DOSetter<Quaternion> setter = delegate(Quaternion x)
			{
				target.rotation = x;
			};
			TweenerCore<Quaternion, Quaternion, NoOptions> tweenerCore = DOTween.To(plugin, getter, setter, endValue, duration);
			TweenerCore<Quaternion, Quaternion, NoOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x60000C7")]
		[Address(RVA = "0x10E6F70", Offset = "0x10E6F70", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv39 = *([1EDD2C0]);\n\tv40 = *([v39 @ X8_v11]);\n\tv41 = \"il2cpp_codegen_initialize_method\"(v40, mode, methodInfo, v43, v44, v45, v46, v47, endValue, v0, v2, duration, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([202752A]) = v54;\nL_0023:\n\tv58 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass42_0();\n\tSystem.Object::.ctor(v58);\n\tv58.target = target;\n\tv65 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>();\n\treturnVal2 = 0x10ED860(v65, 0, methodInfo, v43, v44, v45, v46, v47, endValue, endValue.y, endValue.z, duration, v48, v49, v50, v51);\n\treturn returnVal2;\n\tX1 = X20;\n\tX21 = X0;\n\tX2 = *([X8]);\n\tX3 = *([1EAA000]);\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>::.ctor(X0, X1, X2, X3);\n\tX8 = *([1ECA460]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1F0A8A8]);\n\tX9 = *([1F07E28]);\n\tX1 = X20;\n\tX22 = X0;\n\tX2 = *([X8]);\n\tX3 = *([X9]);\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>::.ctor(X0, X1, X2, X3);\n\tX8 = *([1F00430]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0051;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0051;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0051:\n\tX0 = X21;\n\tX1 = X22;\n\tV0 = V11;\n\tV1 = V10;\n\tV2 = V9;\n\tV3 = V8;\n\tX2 = 0;\n\t// 88 MakeStruct AGG10E708C_2, typeof(UnityEngine.Vector3), V0, V1, V2\n\tX0 = DG.Tweening.DOTween::To(X0, X1, AGG10E708C_2, V3, X2);\n\tX1 = *([X20+10]);\n\tX8 = *([1EF8A30]);\n\tX20 = X0;\n\tX2 = *([X8]);\n\tX0 = DG.Tweening.TweenSettingsExtensions::SetTarget /* +17 sharing this address */(X0, X1, X2);\n\tif (TEMP) goto L_0070;\n\t*([X20+140]) = X19;\n\tX0 = X20;\n\tX29 = stack[40];\n\tX30 = stack[48];\n\tX20 = stack[30];\n\tX19 = stack[38];\n\tX22 = stack[20];\n\tX21 = stack[28];\n\tV9 = stack[10];\n\tV8 = stack[18];\n\tV11 = stack[0];\n\tV10 = stack[8];\n\t// 110 ShiftStack 80\n\treturn X0;\nL_0070:\n\t;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Quaternion, Vector3, QuaternionOptions> DOLocalRotate(this Transform target, Vector3 endValue, float duration, RotateMode mode = RotateMode.Fast)
		{
			DOGetter<Quaternion> dOGetter = null;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10ED860 (inside DG.Tweening.ShortcutExtensions+<>c__DisplayClass72_0::<DOBlendableRotateBy>b__1 +0x190)");
			TweenerCore<Quaternion, Vector3, QuaternionOptions> result = default(TweenerCore<Quaternion, Vector3, QuaternionOptions>);
			return result;
		}

		[Token(Token = "0x60000C8")]
		[Address(RVA = "0x10E70DC", Offset = "0x10E70DC", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv42 = *([1EBD000]);\n\tv43 = *([v42 @ X8_v25]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, methodInfo, v46, v47, v48, v49, v50, v51, endValue, v0, v2, v3, duration, v52, v53, v54);\n\tv57 = 0 | 1;\n\t*([202752B]) = v57;\nL_0025:\n\tv61 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass43_0();\n\tSystem.Object::.ctor(v61);\n\tv61.target = target;\n\tv66 = DG.Tweening.CustomPlugins.PureQuaternionPlugin::Plug();\n\tv74 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>::.ctor(v74, v61, Il2CppMethodInfo);\n\tv136 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>::.ctor(v136, v61, Il2CppMethodInfo);\n\tgoto L_0062;\n\tv150 = *([v146 @ X0_v12+E0]);\n\tv151 = v150 == 0;\n\tv152 = ~v151;\n\tif (v152) goto L_0062;\n\tv154 = \"il2cpp_codegen_runtime_class_init\"(v146, v140, v142, v143, v48, v49, v50, v51, endValue, v0, v2, v3, duration, v52, v53, v54);\nL_0062:\n\tv161 = DG.Tweening.DOTween::To(v66, v74, v136, endValue, duration);\n\tv164 = DG.Tweening.TweenSettingsExtensions::SetTarget(v161, v61.target);\n\treturn v161;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Quaternion, Quaternion, NoOptions> DOLocalRotateQuaternion(this Transform target, Quaternion endValue, float duration)
		{
			PureQuaternionPlugin plugin = PureQuaternionPlugin.Plug();
			DOGetter<Quaternion> getter = () => target.localRotation;
			DOSetter<Quaternion> setter = delegate(Quaternion x)
			{
				target.localRotation = x;
			};
			TweenerCore<Quaternion, Quaternion, NoOptions> tweenerCore = DOTween.To(plugin, getter, setter, endValue, duration);
			TweenerCore<Quaternion, Quaternion, NoOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x60000C9")]
		[Address(RVA = "0x10E7268", Offset = "0x10E7268", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv36 = *([1EB6390]);\n\tv37 = *([v36 @ X8_v22]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, methodInfo, v40, v41, v42, v43, v44, v45, endValue, v0, v2, duration, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([202752C]) = v52;\nL_0021:\n\tv56 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass44_0();\n\tSystem.Object::.ctor(v56);\n\tv56.target = target;\n\tv63 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v63, v56, Il2CppMethodInfo);\n\tv77 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v77, v56, Il2CppMethodInfo);\n\tgoto L_0056;\n\tv134 = *([v130 @ X0_v10+E0]);\n\tv135 = v134 == 0;\n\tv136 = ~v135;\n\tif (v136) goto L_0056;\n\tv138 = \"il2cpp_codegen_runtime_class_init\"(v130, v125, v127, v90, v42, v43, v44, v45, endValue, v0, v2, duration, v46, v47, v48, v49);\nL_0056:\n\tv143 = DG.Tweening.DOTween::To(v63, v77, endValue, duration);\n\tv146 = DG.Tweening.TweenSettingsExtensions::SetTarget(v143, v56.target);\n\treturn v143;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOScale(this Transform target, Vector3 endValue, float duration)
		{
			DOGetter<Vector3> getter = () => target.localScale;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.localScale = x;
			};
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x60000CA")]
		[Address(RVA = "0x10E73C8", Offset = "0x10E73C8", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv32 = *([1EF5228]);\n\tv33 = *([v32 @ X8_v22]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, endValue, duration, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202752D]) = v50;\nL_001F:\n\tv56 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass45_0();\n\tSystem.Object::.ctor(v56);\n\tv56.target = target;\n\tv66 = 0x1586898(&v61 @ stack_-60_v2, 0, v36, v37, v38, v39, v40, v41, endValue, endValue, endValue, v43, v44, v45, v46, v47);\n\tv72 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v72, v56, Il2CppMethodInfo);\n\tv129 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v129, v56, Il2CppMethodInfo);\n\tgoto L_005C;\n\tv146 = *([v142 @ X0_v12+E0]);\n\tv147 = v146 == 0;\n\tv148 = ~v147;\n\tif (v148) goto L_005C;\n\tv150 = \"il2cpp_codegen_runtime_class_init\"(v142, v133, v135, v95, v38, v39, v40, v41, v62, v63, v64, v43, v44, v45, v46, v47);\nL_005C:\n\t// 92 MakeStruct v84 @ AGG10E7504_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v61 @ stack_-60_v2, v140 @ stack_-5C, 0\n\tv155 = DG.Tweening.DOTween::To(v72, v129, v84, duration);\n\tv158 = DG.Tweening.TweenSettingsExtensions::SetTarget(v155, v56.target);\n\treturn v155;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOScale(this Transform target, float endValue, float duration)
		{
			//IL_0065: Expected F4, but got O
			//IL_0072: Expected F4, but got O
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			DOGetter<Vector3> getter = () => target.localScale;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.localScale = x;
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

		[Token(Token = "0x60000CB")]
		[Address(RVA = "0x10E7550", Offset = "0x10E7550", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1F03BF8]);\n\tv29 = *([v28 @ X8_v22]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202752E]) = v46;\nL_001B:\n\tv50 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass46_0();\n\tSystem.Object::.ctor(v50);\n\tv50.target = target;\n\tv57 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v57, v50, Il2CppMethodInfo);\n\tv71 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v71, v50, Il2CppMethodInfo);\n\tv80 = 0;\n\tv130 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(&v80 @ stack_-50_v1, 0, Il2CppMethodInfo);\n\tgoto L_0057;\n\tv137 = *([v133 @ X0_v12+E0]);\n\tv138 = v137 == 0;\n\tv139 = ~v138;\n\tif (v139) goto L_0057;\n\tv141 = \"il2cpp_codegen_runtime_class_init\"(v133, v129, v123, v124, v34, v35, v36, v37, v128, v126, v127, v39, v40, v41, v42, v43);\nL_0057:\n\t// 87 MakeStruct v75 @ AGG10E767C_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v143 @ stack_-4C, 0\n\tv147 = DG.Tweening.DOTween::To(v57, v71, v75, duration);\n\tv151 = DG.Tweening.TweenSettingsExtensions::SetOptions(v147, 2, 0);\n\tv153 = DG.Tweening.TweenSettingsExtensions::SetTarget(v151, v50.target);\n\treturn v147;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOScaleX(this Transform target, float endValue, float duration)
		{
			//IL_004d: Expected O, but got I4
			//IL_006d: Expected F4, but got O
			DOGetter<Vector3> getter = () => target.localScale;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.localScale = x;
			};
			object obj = 0;
			Vector3 endValue2 = default(Vector3);
			endValue2.x = 0f;
			object obj2 = default(object);
			endValue2.y = (float)obj2;
			endValue2.z = 0f;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue2, duration);
			Tweener t = tweenerCore.SetOptions(AxisConstraint.X);
			Tweener tweener = t.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x60000CC")]
		[Address(RVA = "0x10E76D4", Offset = "0x10E76D4", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1EF36D8]);\n\tv29 = *([v28 @ X8_v22]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202752F]) = v46;\nL_001B:\n\tv50 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass47_0();\n\tSystem.Object::.ctor(v50);\n\tv50.target = target;\n\tv57 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v57, v50, Il2CppMethodInfo);\n\tv71 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v71, v50, Il2CppMethodInfo);\n\tv80 = 0;\n\tv130 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(&v80 @ stack_-50_v1, 0, Il2CppMethodInfo);\n\tgoto L_0057;\n\tv137 = *([v133 @ X0_v12+E0]);\n\tv138 = v137 == 0;\n\tv139 = ~v138;\n\tif (v139) goto L_0057;\n\tv141 = \"il2cpp_codegen_runtime_class_init\"(v133, v129, v123, v124, v34, v35, v36, v37, v126, v128, v127, v39, v40, v41, v42, v43);\nL_0057:\n\t// 87 MakeStruct v75 @ AGG10E7800_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v143 @ stack_-4C, 0\n\tv147 = DG.Tweening.DOTween::To(v57, v71, v75, duration);\n\tv151 = DG.Tweening.TweenSettingsExtensions::SetOptions(v147, 4, 0);\n\tv153 = DG.Tweening.TweenSettingsExtensions::SetTarget(v151, v50.target);\n\treturn v147;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOScaleY(this Transform target, float endValue, float duration)
		{
			//IL_004d: Expected O, but got I4
			//IL_006d: Expected F4, but got O
			DOGetter<Vector3> getter = () => target.localScale;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.localScale = x;
			};
			object obj = 0;
			Vector3 endValue2 = default(Vector3);
			endValue2.x = 0f;
			object obj2 = default(object);
			endValue2.y = (float)obj2;
			endValue2.z = 0f;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue2, duration);
			Tweener t = tweenerCore.SetOptions(AxisConstraint.Y);
			Tweener tweener = t.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x60000CD")]
		[Address(RVA = "0x10E7858", Offset = "0x10E7858", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1EC9758]);\n\tv29 = *([v28 @ X8_v22]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2027530]) = v46;\nL_001B:\n\tv50 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass48_0();\n\tSystem.Object::.ctor(v50);\n\tv50.target = target;\n\tv57 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v57, v50, Il2CppMethodInfo);\n\tv71 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v71, v50, Il2CppMethodInfo);\n\tv80 = 0;\n\tv130 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(&v80 @ stack_-50_v1, 0, Il2CppMethodInfo);\n\tgoto L_0057;\n\tv137 = *([v133 @ X0_v12+E0]);\n\tv138 = v137 == 0;\n\tv139 = ~v138;\n\tif (v139) goto L_0057;\n\tv141 = \"il2cpp_codegen_runtime_class_init\"(v133, v129, v123, v124, v34, v35, v36, v37, v126, v127, v128, v39, v40, v41, v42, v43);\nL_0057:\n\t// 87 MakeStruct v75 @ AGG10E7984_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v143 @ stack_-4C, 0\n\tv147 = DG.Tweening.DOTween::To(v57, v71, v75, duration);\n\tv151 = DG.Tweening.TweenSettingsExtensions::SetOptions(v147, 8, 0);\n\tv153 = DG.Tweening.TweenSettingsExtensions::SetTarget(v151, v50.target);\n\treturn v147;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOScaleZ(this Transform target, float endValue, float duration)
		{
			//IL_004d: Expected O, but got I4
			//IL_006d: Expected F4, but got O
			DOGetter<Vector3> getter = () => target.localScale;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.localScale = x;
			};
			object obj = 0;
			Vector3 endValue2 = default(Vector3);
			endValue2.x = 0f;
			object obj2 = default(object);
			endValue2.y = (float)obj2;
			endValue2.z = 0f;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue2, duration);
			Tweener t = tweenerCore.SetOptions(AxisConstraint.Z);
			Tweener tweener = t.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x60000CE")]
		[Address(RVA = "0x10E79DC", Offset = "0x10E79DC", Length = "0x1E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv162 = v127.y;\n\tv160 = v127.z;\n\tgoto L_0027;\n\tv47 = *([1EBC4D8]);\n\tv48 = *([v47 @ X8_v34]);\n\tv49 = \"il2cpp_codegen_initialize_method\"(v48, axisConstraint, up, methodInfo, v50, v51, v52, v53, towards, v0, v2, duration, v54, v55, v56, v57);\n\tv60 = 0 | 1;\n\t*([2027531]) = v60;\nL_0027:\n\tv64 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass49_0();\n\tSystem.Object::.ctor(v64);\n\tv64.target = target;\n\tv71 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>::.ctor(v71, v64, Il2CppMethodInfo);\n\tv116 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>::.ctor(v116, v64, Il2CppMethodInfo);\n\tgoto L_005C;\n\tv169 = *([v165 @ X0_v11+E0]);\n\tv170 = v169 == 0;\n\tv171 = ~v170;\n\tif (v171) goto L_005C;\n\tv173 = \"il2cpp_codegen_runtime_class_init\"(v165, v120, v121, v91, v50, v51, v52, v53, towards, v0, v2, duration, v54, v55, v56, v57);\nL_005C:\n\tv179 = DG.Tweening.DOTween::To(v71, v116, v127, duration);\n\tv184 = DG.Tweening.TweenSettingsExtensions::SetTarget(v179, v64.target);\n\tv100 = DG.Tweening.Core.Extensions::SetSpecialStartupMode(v184, 1);\n\tv186 = methodInfo & 0xFF00000000;\n\tv100.plugOptions.axisConstraint = axisConstraint;\n\tv187 = v186 == 0;\n\tif (v187) goto L_007A;\n\tv192 = DG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>::.ctor(&up @ X2 (System.Nullable`1<UnityEngine.Vector3>), Il2CppMethodInfo, Il2CppMethodInfo);\n\tgoto L_0084;\nL_007A:\n\tgoto L_0081;\n\tv199 = *([v195 @ X0_v19+E0]);\n\tv200 = v199 == 0;\n\tv201 = ~v200;\n\tif (v201) goto L_0081;\n\tv203 = \"il2cpp_codegen_runtime_class_init\"(v195, v98, v93, v91, v50, v51, v52, v53, v87, v111, v109, v85, v54, v55, v56, v57);\nL_0081:\n\tv127 = UnityEngine.Vector3::get_up();\n\tv162 = v127.y;\n\tv160 = v127.z;\nL_0084:\n\tv100.plugOptions.up.x = v127;\n\tv100.plugOptions.up.y = v162;\n\tv100.plugOptions.up.z = v160;\n\treturn v100;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 107 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOLookAt(this Transform target, Vector3 towards, float duration, AxisConstraint axisConstraint = AxisConstraint.None, Vector3? up = null)
		{
			//IL_00c1: Expected I4, but got I8
			Vector3 up2 = default(Vector3);
			float y = up2.y;
			float z = up2.z;
			DOGetter<Quaternion> getter = () => target.rotation;
			DOSetter<Quaternion> setter = delegate(Quaternion x)
			{
				target.rotation = x;
			};
			TweenerCore<Quaternion, Vector3, QuaternionOptions> t = DOTween.To(getter, setter, up2, duration);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> t2 = t.SetTarget(target);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = t2.SetSpecialStartupMode(SpecialStartupMode.SetLookAt);
			IntPtr intPtr = default(IntPtr);
			int num = (int)((long)intPtr & 0xFF00000000L);
			tweenerCore.plugOptions.axisConstraint = axisConstraint;
			if (num == 0)
			{
				up2 = Vector3.up;
				y = up2.y;
				z = up2.z;
			}
			tweenerCore.plugOptions.up.x = up2.x;
			tweenerCore.plugOptions.up.y = y;
			tweenerCore.plugOptions.up.z = z;
			return tweenerCore;
		}

		[Token(Token = "0x60000CF")]
		[Address(RVA = "0x10E7BC8", Offset = "0x10E7BC8", Length = "0x21C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv48 = *([1EEC9C8]);\n\tv49 = *([v48 @ X8_v40]);\n\tv50 = \"il2cpp_codegen_initialize_method\"(v49, vibrato, snapping, methodInfo, v52, v53, v54, v55, punch, v0, v2, duration, elasticity, v56, v57, v58);\n\tv61 = 0 | 1;\n\t*([2027532]) = v61;\nL_0027:\n\tv65 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass50_0();\n\tSystem.Object::.ctor(v65);\n\tv69 = duration < 0;\n\tv70 = ~v69;\n\tv73 = duration == 0;\n\tv65.target = target;\n\tv78 = ~v70;\n\tv79 = v78 | v73;\n\tif (v79) goto L_0085;\n\tv85 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v85, v65, Il2CppMethodInfo);\n\tv210 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v210, v65, Il2CppMethodInfo);\n\tgoto L_006A;\n\tv242 = *([v238 @ X0_v19+E0]);\n\tv243 = v242 == 0;\n\tv244 = ~v243;\n\tif (v244) goto L_006A;\n\tv246 = \"il2cpp_codegen_runtime_class_init\"(v238, v225, v227, v228, v52, v53, v54, v55, punch, v0, v2, duration, elasticity, v56, v57, v58);\nL_006A:\n\tv251 = DG.Tweening.DOTween::Punch(v85, v210, punch, duration, vibrato, elasticity);\n\tv255 = DG.Tweening.TweenSettingsExtensions::SetTarget(v251, v65.target);\n\treturnVal3 = DG.Tweening.TweenSettingsExtensions::SetOptions(v255, snapping);\n\treturn returnVal3;\nL_0085:\n\tgoto L_009B;\n\tv99 = *([1EFC598]);\n\tv100 = *([v99 @ X8_v21]);\n\tv101 = \"il2cpp_codegen_initialize_method\"(v100, v66, snapping, methodInfo, v52, v53, v54, v55, punch, v0, v2, duration, elasticity, v56, v57, v58);\n\tv104 = 0 | 1;\n\t*([2022B9B]) = v104;\nL_009B:\n\tv120 = v108._logPriority < 1;\n\tif (v120) goto L_00BC;\n\tgoto L_00AD;\n\tv229 = *([v213 @ X0_v9+E0]);\n\tv230 = v229 == 0;\n\tv231 = ~v230;\n\tif (v231) goto L_00AD;\n\tv233 = \"il2cpp_codegen_runtime_class_init\"(v213, v66, snapping, methodInfo, v52, v53, v54, v55, punch, v0, v2, duration, elasticity, v56, v57, v58);\nL_00AD:\n\tUnityEngine.Debug::LogWarning(\"DOPunchPosition: duration can't be 0, returning NULL without creating a tween\");\nL_00BC:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 145 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOPunchPosition(this Transform target, Vector3 punch, float duration, int vibrato = 10, float elasticity = 1f, bool snapping = false)
		{
			bool flag = duration < 0f;
			bool flag2 = !flag;
			bool flag3 = duration == 0f;
			Transform target2 = target;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				DOGetter<Vector3> getter = () => target2.localPosition;
				DOSetter<Vector3> setter = delegate(Vector3 x)
				{
					target2.localPosition = x;
				};
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = DOTween.Punch(getter, setter, punch, duration, vibrato, elasticity);
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t2 = t.SetTarget(target2);
				return t2.SetOptions(snapping);
			}
			if (Debugger._logPriority >= 1)
			{
				Debug.LogWarning("DOPunchPosition: duration can't be 0, returning NULL without creating a tween");
			}
			return null;
		}

		[Token(Token = "0x60000D0")]
		[Address(RVA = "0x10E7DEC", Offset = "0x10E7DEC", Length = "0x1EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv44 = *([1ED4980]);\n\tv45 = *([v44 @ X8_v41]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, vibrato, methodInfo, v48, v49, v50, v51, v52, punch, v0, v2, duration, elasticity, v53, v54, v55);\n\tv58 = 0 | 1;\n\t*([2027533]) = v58;\nL_0025:\n\tv62 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass51_0();\n\tSystem.Object::.ctor(v62);\n\tv66 = duration < 0;\n\tv67 = ~v66;\n\tv70 = duration == 0;\n\tv62.target = target;\n\tv75 = ~v67;\n\tv76 = v75 | v70;\n\tif (v76) goto L_0073;\n\tv82 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v82, v62, Il2CppMethodInfo);\n\tv198 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v198, v62, Il2CppMethodInfo);\n\tgoto L_0068;\n\tv250 = *([v246 @ X0_v20+E0]);\n\tv251 = v250 == 0;\n\tv252 = ~v251;\n\tif (v252) goto L_0068;\n\tv254 = \"il2cpp_codegen_runtime_class_init\"(v246, v218, v220, v221, v49, v50, v51, v52, punch, v0, v2, duration, elasticity, v53, v54, v55);\nL_0068:\n\tv259 = DG.Tweening.DOTween::Punch(v82, v198, punch, duration, vibrato, elasticity);\n\tv237 = DG.Tweening.TweenSettingsExtensions::SetTarget(v259, v62.target);\n\tgoto L_00A9;\nL_0073:\n\tgoto L_0089;\n\tv96 = *([1EFC598]);\n\tv97 = *([v96 @ X8_v22]);\n\tv98 = \"il2cpp_codegen_initialize_method\"(v97, v63, methodInfo, v48, v49, v50, v51, v52, punch, v0, v2, duration, elasticity, v53, v54, v55);\n\tv101 = 0 | 1;\n\t*([2022B9B]) = v101;\nL_0089:\n\tv117 = v105._logPriority < 1;\n\tif (v117) goto L_FFFFFFFF;\n\tgoto L_009B;\n\tv222 = *([v201 @ X0_v10+E0]);\n\tv223 = v222 == 0;\n\tv224 = ~v223;\n\tif (v224) goto L_009B;\n\tv226 = \"il2cpp_codegen_runtime_class_init\"(v201, v63, methodInfo, v48, v49, v50, v51, v52, punch, v0, v2, duration, elasticity, v53, v54, v55);\nL_009B:\n\tUnityEngine.Debug::LogWarning(\"DOPunchScale: duration can't be 0, returning NULL without creating a tween\");\nL_00A9:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 127 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOPunchScale(this Transform target, Vector3 punch, float duration, int vibrato = 10, float elasticity = 1f)
		{
			bool flag = duration < 0f;
			bool flag2 = !flag;
			bool flag3 = duration == 0f;
			Transform target2 = target;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				DOGetter<Vector3> getter = () => target2.localScale;
				DOSetter<Vector3> setter = delegate(Vector3 x)
				{
					target2.localScale = x;
				};
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = DOTween.Punch(getter, setter, punch, duration, vibrato, elasticity);
				return t.SetTarget(target2);
			}
			if (Debugger._logPriority >= 1)
			{
				Debug.LogWarning("DOPunchScale: duration can't be 0, returning NULL without creating a tween");
			}
			return null;
		}

		[Token(Token = "0x60000D1")]
		[Address(RVA = "0x10E7FE0", Offset = "0x10E7FE0", Length = "0x1EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv44 = *([1ECAF88]);\n\tv45 = *([v44 @ X8_v41]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, vibrato, methodInfo, v48, v49, v50, v51, v52, punch, v0, v2, duration, elasticity, v53, v54, v55);\n\tv58 = 0 | 1;\n\t*([2027534]) = v58;\nL_0025:\n\tv62 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass52_0();\n\tSystem.Object::.ctor(v62);\n\tv66 = duration < 0;\n\tv67 = ~v66;\n\tv70 = duration == 0;\n\tv62.target = target;\n\tv75 = ~v67;\n\tv76 = v75 | v70;\n\tif (v76) goto L_0073;\n\tv82 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v82, v62, Il2CppMethodInfo);\n\tv198 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v198, v62, Il2CppMethodInfo);\n\tgoto L_0068;\n\tv250 = *([v246 @ X0_v20+E0]);\n\tv251 = v250 == 0;\n\tv252 = ~v251;\n\tif (v252) goto L_0068;\n\tv254 = \"il2cpp_codegen_runtime_class_init\"(v246, v218, v220, v221, v49, v50, v51, v52, punch, v0, v2, duration, elasticity, v53, v54, v55);\nL_0068:\n\tv259 = DG.Tweening.DOTween::Punch(v82, v198, punch, duration, vibrato, elasticity);\n\tv237 = DG.Tweening.TweenSettingsExtensions::SetTarget(v259, v62.target);\n\tgoto L_00A9;\nL_0073:\n\tgoto L_0089;\n\tv96 = *([1EFC598]);\n\tv97 = *([v96 @ X8_v22]);\n\tv98 = \"il2cpp_codegen_initialize_method\"(v97, v63, methodInfo, v48, v49, v50, v51, v52, punch, v0, v2, duration, elasticity, v53, v54, v55);\n\tv101 = 0 | 1;\n\t*([2022B9B]) = v101;\nL_0089:\n\tv117 = v105._logPriority < 1;\n\tif (v117) goto L_FFFFFFFF;\n\tgoto L_009B;\n\tv222 = *([v201 @ X0_v10+E0]);\n\tv223 = v222 == 0;\n\tv224 = ~v223;\n\tif (v224) goto L_009B;\n\tv226 = \"il2cpp_codegen_runtime_class_init\"(v201, v63, methodInfo, v48, v49, v50, v51, v52, punch, v0, v2, duration, elasticity, v53, v54, v55);\nL_009B:\n\tUnityEngine.Debug::LogWarning(\"DOPunchRotation: duration can't be 0, returning NULL without creating a tween\");\nL_00A9:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 127 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOPunchRotation(this Transform target, Vector3 punch, float duration, int vibrato = 10, float elasticity = 1f)
		{
			bool flag = duration < 0f;
			bool flag2 = !flag;
			bool flag3 = duration == 0f;
			Transform target2 = target;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				DOGetter<Vector3> getter = () => target2.localEulerAngles;
				DOSetter<Vector3> setter = delegate(Vector3 x)
				{
					Quaternion localRotation = Quaternion.Euler(x);
					target2.localRotation = localRotation;
				};
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = DOTween.Punch(getter, setter, punch, duration, vibrato, elasticity);
				return t.SetTarget(target2);
			}
			if (Debugger._logPriority >= 1)
			{
				Debug.LogWarning("DOPunchRotation: duration can't be 0, returning NULL without creating a tween");
			}
			return null;
		}

		[Token(Token = "0x60000D2")]
		[Address(RVA = "0x10E81D4", Offset = "0x10E81D4", Length = "0x220")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv44 = *([1EBB1A8]);\n\tv45 = *([v44 @ X8_v42]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, vibrato, snapping, fadeOut, methodInfo, v48, v49, v50, duration, strength, randomness, v51, v52, v53, v54, v55);\n\tv58 = 0 | 1;\n\t*([2027535]) = v58;\nL_0023:\n\tv62 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass53_0();\n\tSystem.Object::.ctor(v62);\n\tv66 = duration < 0;\n\tv67 = ~v66;\n\tv70 = duration == 0;\n\tv62.target = target;\n\tv75 = ~v67;\n\tv76 = v75 | v70;\n\tif (v76) goto L_0084;\n\tv82 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v82, v62, Il2CppMethodInfo);\n\tv201 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v201, v62, Il2CppMethodInfo);\n\tgoto L_0065;\n\tv233 = *([v229 @ X0_v19+E0]);\n\tv234 = v233 == 0;\n\tv235 = ~v234;\n\tif (v235) goto L_0065;\n\tv237 = \"il2cpp_codegen_runtime_class_init\"(v229, v216, v218, v219, methodInfo, v48, v49, v50, duration, strength, randomness, v51, v52, v53, v54, v55);\nL_0065:\n\tv242 = DG.Tweening.DOTween::Shake(v82, v201, duration, strength, vibrato, randomness, 0, fadeOut);\n\tv247 = DG.Tweening.TweenSettingsExtensions::SetTarget(v242, v62.target);\n\tv251 = DG.Tweening.Core.Extensions::SetSpecialStartupMode(v247, 2);\n\treturnVal3 = DG.Tweening.TweenSettingsExtensions::SetOptions(v251, snapping);\n\treturn returnVal3;\nL_0084:\n\tgoto L_009A;\n\tv96 = *([1EFC598]);\n\tv97 = *([v96 @ X8_v21]);\n\tv98 = \"il2cpp_codegen_initialize_method\"(v97, v63, snapping, fadeOut, methodInfo, v48, v49, v50, duration, strength, randomness, v51, v52, v53, v54, v55);\n\tv101 = 0 | 1;\n\t*([2022B9B]) = v101;\nL_009A:\n\tv117 = v105._logPriority < 1;\n\tif (v117) goto L_00BA;\n\tgoto L_00AC;\n\tv220 = *([v204 @ X0_v9+E0]);\n\tv221 = v220 == 0;\n\tv222 = ~v221;\n\tif (v222) goto L_00AC;\n\tv224 = \"il2cpp_codegen_runtime_class_init\"(v204, v63, snapping, fadeOut, methodInfo, v48, v49, v50, duration, strength, randomness, v51, v52, v53, v54, v55);\nL_00AC:\n\tUnityEngine.Debug::LogWarning(\"DOShakePosition: duration can't be 0, returning NULL without creating a tween\");\nL_00BA:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 142 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOShakePosition(this Transform target, float duration, float strength = 1f, int vibrato = 10, float randomness = 90f, bool snapping = false, bool fadeOut = true)
		{
			bool flag = duration < 0f;
			bool flag2 = !flag;
			bool flag3 = duration == 0f;
			Transform target2 = target;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				DOGetter<Vector3> getter = () => target2.localPosition;
				DOSetter<Vector3> setter = delegate(Vector3 x)
				{
					target2.localPosition = x;
				};
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = DOTween.Shake(getter, setter, duration, strength, vibrato, randomness, ignoreZAxis: false, fadeOut);
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t2 = t.SetTarget(target2);
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t3 = t2.SetSpecialStartupMode(SpecialStartupMode.SetShake);
				return t3.SetOptions(snapping);
			}
			if (Debugger._logPriority >= 1)
			{
				Debug.LogWarning("DOShakePosition: duration can't be 0, returning NULL without creating a tween");
			}
			return null;
		}

		[Token(Token = "0x60000D3")]
		[Address(RVA = "0x10E83FC", Offset = "0x10E83FC", Length = "0x238")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv52 = *([1F0C658]);\n\tv53 = *([v52 @ X8_v42]);\n\tv54 = \"il2cpp_codegen_initialize_method\"(v53, vibrato, snapping, fadeOut, methodInfo, v56, v57, v58, duration, strength, v0, v2, randomness, v59, v60, v61);\n\tv64 = 0 | 1;\n\t*([2027536]) = v64;\nL_0029:\n\tv68 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass54_0();\n\tSystem.Object::.ctor(v68);\n\tv72 = duration < 0;\n\tv73 = ~v72;\n\tv76 = duration == 0;\n\tv68.target = target;\n\tv81 = ~v73;\n\tv82 = v81 | v76;\n\tif (v82) goto L_008E;\n\tv88 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v88, v68, Il2CppMethodInfo);\n\tv218 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v218, v68, Il2CppMethodInfo);\n\tgoto L_006D;\n\tv250 = *([v246 @ X0_v19+E0]);\n\tv251 = v250 == 0;\n\tv252 = ~v251;\n\tif (v252) goto L_006D;\n\tv254 = \"il2cpp_codegen_runtime_class_init\"(v246, v233, v235, v236, methodInfo, v56, v57, v58, duration, strength, v0, v2, randomness, v59, v60, v61);\nL_006D:\n\tv259 = DG.Tweening.DOTween::Shake(v88, v218, duration, strength, vibrato, randomness, fadeOut);\n\tv264 = DG.Tweening.TweenSettingsExtensions::SetTarget(v259, v68.target);\n\tv268 = DG.Tweening.Core.Extensions::SetSpecialStartupMode(v264, 2);\n\treturnVal3 = DG.Tweening.TweenSettingsExtensions::SetOptions(v268, snapping);\n\treturn returnVal3;\nL_008E:\n\tgoto L_00A4;\n\tv102 = *([1EFC598]);\n\tv103 = *([v102 @ X8_v21]);\n\tv104 = \"il2cpp_codegen_initialize_method\"(v103, v69, snapping, fadeOut, methodInfo, v56, v57, v58, duration, strength, v0, v2, randomness, v59, v60, v61);\n\tv107 = 0 | 1;\n\t*([2022B9B]) = v107;\nL_00A4:\n\tv123 = v111._logPriority < 1;\n\tif (v123) goto L_00C6;\n\tgoto L_00B6;\n\tv237 = *([v221 @ X0_v9+E0]);\n\tv238 = v237 == 0;\n\tv239 = ~v238;\n\tif (v239) goto L_00B6;\n\tv241 = \"il2cpp_codegen_runtime_class_init\"(v221, v69, snapping, fadeOut, methodInfo, v56, v57, v58, duration, strength, v0, v2, randomness, v59, v60, v61);\nL_00B6:\n\tUnityEngine.Debug::LogWarning(\"DOShakePosition: duration can't be 0, returning NULL without creating a tween\");\nL_00C6:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 154 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOShakePosition(this Transform target, float duration, Vector3 strength, int vibrato = 10, float randomness = 90f, bool snapping = false, bool fadeOut = true)
		{
			bool flag = duration < 0f;
			bool flag2 = !flag;
			bool flag3 = duration == 0f;
			Transform target2 = target;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				DOGetter<Vector3> getter = () => target2.localPosition;
				DOSetter<Vector3> setter = delegate(Vector3 x)
				{
					target2.localPosition = x;
				};
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = DOTween.Shake(getter, setter, duration, strength, vibrato, randomness, fadeOut);
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t2 = t.SetTarget(target2);
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t3 = t2.SetSpecialStartupMode(SpecialStartupMode.SetShake);
				return t3.SetOptions(snapping);
			}
			if (Debugger._logPriority >= 1)
			{
				Debug.LogWarning("DOShakePosition: duration can't be 0, returning NULL without creating a tween");
			}
			return null;
		}

		[Token(Token = "0x60000D4")]
		[Address(RVA = "0x10E863C", Offset = "0x10E863C", Length = "0x1FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv40 = *([1EFA560]);\n\tv41 = *([v40 @ X8_v43]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, vibrato, fadeOut, methodInfo, v44, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2027537]) = v55;\nL_0021:\n\tv59 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass55_0();\n\tSystem.Object::.ctor(v59);\n\tv63 = duration < 0;\n\tv64 = ~v63;\n\tv67 = duration == 0;\n\tv59.target = target;\n\tv72 = ~v64;\n\tv73 = v72 | v67;\n\tif (v73) goto L_0073;\n\tv79 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v79, v59, Il2CppMethodInfo);\n\tv190 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v190, v59, Il2CppMethodInfo);\n\tgoto L_0063;\n\tv241 = *([v237 @ X0_v20+E0]);\n\tv242 = v241 == 0;\n\tv243 = ~v242;\n\tif (v243) goto L_0063;\n\tv245 = \"il2cpp_codegen_runtime_class_init\"(v237, v210, v212, v213, v44, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\nL_0063:\n\tv250 = DG.Tweening.DOTween::Shake(v79, v190, duration, strength, vibrato, randomness, 0, fadeOut);\n\tv255 = DG.Tweening.TweenSettingsExtensions::SetTarget(v250, v59.target);\n\tv230 = DG.Tweening.Core.Extensions::SetSpecialStartupMode(v255, 2);\n\tgoto L_00A8;\nL_0073:\n\tgoto L_0089;\n\tv93 = *([1EFC598]);\n\tv94 = *([v93 @ X8_v22]);\n\tv95 = \"il2cpp_codegen_initialize_method\"(v94, v60, fadeOut, methodInfo, v44, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv98 = 0 | 1;\n\t*([2022B9B]) = v98;\nL_0089:\n\tv114 = v102._logPriority < 1;\n\tif (v114) goto L_FFFFFFFF;\n\tgoto L_009B;\n\tv214 = *([v193 @ X0_v10+E0]);\n\tv215 = v214 == 0;\n\tv216 = ~v215;\n\tif (v216) goto L_009B;\n\tv218 = \"il2cpp_codegen_runtime_class_init\"(v193, v60, fadeOut, methodInfo, v44, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\nL_009B:\n\tUnityEngine.Debug::LogWarning(\"DOShakeRotation: duration can't be 0, returning NULL without creating a tween\");\nL_00A8:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 125 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOShakeRotation(this Transform target, float duration, float strength = 90f, int vibrato = 10, float randomness = 90f, bool fadeOut = true)
		{
			bool flag = duration < 0f;
			bool flag2 = !flag;
			bool flag3 = duration == 0f;
			Transform target2 = target;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				DOGetter<Vector3> getter = () => target2.localEulerAngles;
				DOSetter<Vector3> setter = delegate(Vector3 x)
				{
					Quaternion localRotation = Quaternion.Euler(x);
					target2.localRotation = localRotation;
				};
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = DOTween.Shake(getter, setter, duration, strength, vibrato, randomness, ignoreZAxis: false, fadeOut);
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t2 = t.SetTarget(target2);
				return t2.SetSpecialStartupMode(SpecialStartupMode.SetShake);
			}
			if (Debugger._logPriority >= 1)
			{
				Debug.LogWarning("DOShakeRotation: duration can't be 0, returning NULL without creating a tween");
			}
			return null;
		}

		[Token(Token = "0x60000D5")]
		[Address(RVA = "0x10E8840", Offset = "0x10E8840", Length = "0x210")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv48 = *([1EE52F0]);\n\tv49 = *([v48 @ X8_v43]);\n\tv50 = \"il2cpp_codegen_initialize_method\"(v49, vibrato, fadeOut, methodInfo, v52, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv61 = 0 | 1;\n\t*([2027538]) = v61;\nL_0027:\n\tv65 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass56_0();\n\tSystem.Object::.ctor(v65);\n\tv69 = duration < 0;\n\tv70 = ~v69;\n\tv73 = duration == 0;\n\tv65.target = target;\n\tv78 = ~v70;\n\tv79 = v78 | v73;\n\tif (v79) goto L_007B;\n\tv85 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v85, v65, Il2CppMethodInfo);\n\tv205 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v205, v65, Il2CppMethodInfo);\n\tgoto L_006B;\n\tv258 = *([v254 @ X0_v20+E0]);\n\tv259 = v258 == 0;\n\tv260 = ~v259;\n\tif (v260) goto L_006B;\n\tv262 = \"il2cpp_codegen_runtime_class_init\"(v254, v225, v227, v228, v52, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\nL_006B:\n\tv267 = DG.Tweening.DOTween::Shake(v85, v205, duration, strength, vibrato, randomness, fadeOut);\n\tv272 = DG.Tweening.TweenSettingsExtensions::SetTarget(v267, v65.target);\n\tv245 = DG.Tweening.Core.Extensions::SetSpecialStartupMode(v272, 2);\n\tgoto L_00B2;\nL_007B:\n\tgoto L_0091;\n\tv99 = *([1EFC598]);\n\tv100 = *([v99 @ X8_v22]);\n\tv101 = \"il2cpp_codegen_initialize_method\"(v100, v66, fadeOut, methodInfo, v52, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv104 = 0 | 1;\n\t*([2022B9B]) = v104;\nL_0091:\n\tv120 = v108._logPriority < 1;\n\tif (v120) goto L_FFFFFFFF;\n\tgoto L_00A3;\n\tv229 = *([v208 @ X0_v10+E0]);\n\tv230 = v229 == 0;\n\tv231 = ~v230;\n\tif (v231) goto L_00A3;\n\tv233 = \"il2cpp_codegen_runtime_class_init\"(v208, v66, fadeOut, methodInfo, v52, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\nL_00A3:\n\tUnityEngine.Debug::LogWarning(\"DOShakeRotation: duration can't be 0, returning NULL without creating a tween\");\nL_00B2:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 135 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOShakeRotation(this Transform target, float duration, Vector3 strength, int vibrato = 10, float randomness = 90f, bool fadeOut = true)
		{
			bool flag = duration < 0f;
			bool flag2 = !flag;
			bool flag3 = duration == 0f;
			Transform target2 = target;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				DOGetter<Vector3> getter = () => target2.localEulerAngles;
				DOSetter<Vector3> setter = delegate(Vector3 x)
				{
					Quaternion localRotation = Quaternion.Euler(x);
					target2.localRotation = localRotation;
				};
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = DOTween.Shake(getter, setter, duration, strength, vibrato, randomness, fadeOut);
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t2 = t.SetTarget(target2);
				return t2.SetSpecialStartupMode(SpecialStartupMode.SetShake);
			}
			if (Debugger._logPriority >= 1)
			{
				Debug.LogWarning("DOShakeRotation: duration can't be 0, returning NULL without creating a tween");
			}
			return null;
		}

		[Token(Token = "0x60000D6")]
		[Address(RVA = "0x10E8A58", Offset = "0x10E8A58", Length = "0x274")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv40 = *([1EA41A8]);\n\tv41 = *([v40 @ X8_v48]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, vibrato, fadeOut, methodInfo, v44, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2027539]) = v55;\nL_0021:\n\tv59 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass57_0();\n\tSystem.Object::.ctor(v59);\n\tv63 = duration < 0;\n\tv64 = ~v63;\n\tv67 = duration == 0;\n\tv59.target = target;\n\tv72 = ~v64;\n\tv73 = v72 | v67;\n\tif (v73) goto L_0073;\n\tv79 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v79, v59, Il2CppMethodInfo);\n\tv188 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v188, v59, Il2CppMethodInfo);\n\tgoto L_0063;\n\tv223 = *([v215 @ X0_v29+E0]);\n\tv224 = v223 == 0;\n\tv225 = ~v224;\n\tif (v225) goto L_0063;\n\tv227 = \"il2cpp_codegen_runtime_class_init\"(v215, v200, v202, v203, v44, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\nL_0063:\n\tv239 = DG.Tweening.DOTween::Shake(v79, v188, duration, strength, vibrato, randomness, 0, fadeOut);\n\tv265 = DG.Tweening.TweenSettingsExtensions::SetTarget(v239, v59.target);\n\tv283 = DG.Tweening.Core.Extensions::SetSpecialStartupMode(v265, 2);\n\tgoto L_00CA;\nL_0073:\n\tgoto L_0080;\n\tv93 = *([1EFC598]);\n\tv94 = *([v93 @ X8_v27]);\n\tv95 = \"il2cpp_codegen_initialize_method\"(v94, v60, fadeOut, methodInfo, v44, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv98 = 0 | 1;\n\t*([2022B9B]) = v98;\nL_0080:\n\tv106 = v105._logPriority;\n\t// 132 Box v109 @ X0_v9 (System.Object), typeof(System.Int32), &v106 @ X8_v10 (System.Int32)\n\tgoto L_0095;\n\tv204 = *([v192 @ X8_v11+E0]);\n\tv205 = v204 == 0;\n\tv206 = ~v205;\n\tgoto L_0095;\n\tv219 = v192;\n\tv209 = \"il2cpp_codegen_runtime_class_init\"(v219, v102, fadeOut, methodInfo, v44, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\nL_0095:\n\tUnityEngine.Debug::Log(v109);\n\tgoto L_00AD;\n\tv241 = *([1EFC598]);\n\tv242 = *([v241 @ X8_v24]);\n\tv243 = \"il2cpp_codegen_initialize_method\"(v242, v212, fadeOut, methodInfo, v44, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv246 = 0 | 1;\n\t*([2022B9B]) = v246;\nL_00AD:\n\tv260 = v105._logPriority < 1;\n\tif (v260) goto L_FFFFFFFF;\n\tgoto L_00BD;\n\tv284 = *([v266 @ X0_v15+E0]);\n\tv285 = v284 == 0;\n\tv286 = ~v285;\n\tif (v286) goto L_00BD;\n\tv288 = \"il2cpp_codegen_runtime_class_init\"(v266, v212, fadeOut, methodInfo, v44, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\nL_00BD:\n\tUnityEngine.Debug::LogWarning(\"DOShakeScale: duration can't be 0, returning NULL without creating a tween\");\nL_00CA:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 143 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOShakeScale(this Transform target, float duration, float strength = 1f, int vibrato = 10, float randomness = 90f, bool fadeOut = true)
		{
			bool flag = duration < 0f;
			bool flag2 = !flag;
			bool flag3 = duration == 0f;
			Transform target2 = target;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				DOGetter<Vector3> getter = () => target2.localScale;
				DOSetter<Vector3> setter = delegate(Vector3 x)
				{
					target2.localScale = x;
				};
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = DOTween.Shake(getter, setter, duration, strength, vibrato, randomness, ignoreZAxis: false, fadeOut);
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t2 = t.SetTarget(target2);
				return t2.SetSpecialStartupMode(SpecialStartupMode.SetShake);
			}
			int logPriority = Debugger._logPriority;
			object message = logPriority;
			Debug.Log(message);
			if (Debugger._logPriority >= 1)
			{
				Debug.LogWarning("DOShakeScale: duration can't be 0, returning NULL without creating a tween");
			}
			return null;
		}

		[Token(Token = "0x60000D7")]
		[Address(RVA = "0x10E8CD4", Offset = "0x10E8CD4", Length = "0x210")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv48 = *([1EB6858]);\n\tv49 = *([v48 @ X8_v43]);\n\tv50 = \"il2cpp_codegen_initialize_method\"(v49, vibrato, fadeOut, methodInfo, v52, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv61 = 0 | 1;\n\t*([202753A]) = v61;\nL_0027:\n\tv65 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass58_0();\n\tSystem.Object::.ctor(v65);\n\tv69 = duration < 0;\n\tv70 = ~v69;\n\tv73 = duration == 0;\n\tv65.target = target;\n\tv78 = ~v70;\n\tv79 = v78 | v73;\n\tif (v79) goto L_007B;\n\tv85 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v85, v65, Il2CppMethodInfo);\n\tv205 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v205, v65, Il2CppMethodInfo);\n\tgoto L_006B;\n\tv258 = *([v254 @ X0_v20+E0]);\n\tv259 = v258 == 0;\n\tv260 = ~v259;\n\tif (v260) goto L_006B;\n\tv262 = \"il2cpp_codegen_runtime_class_init\"(v254, v225, v227, v228, v52, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\nL_006B:\n\tv267 = DG.Tweening.DOTween::Shake(v85, v205, duration, strength, vibrato, randomness, fadeOut);\n\tv272 = DG.Tweening.TweenSettingsExtensions::SetTarget(v267, v65.target);\n\tv245 = DG.Tweening.Core.Extensions::SetSpecialStartupMode(v272, 2);\n\tgoto L_00B2;\nL_007B:\n\tgoto L_0091;\n\tv99 = *([1EFC598]);\n\tv100 = *([v99 @ X8_v22]);\n\tv101 = \"il2cpp_codegen_initialize_method\"(v100, v66, fadeOut, methodInfo, v52, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv104 = 0 | 1;\n\t*([2022B9B]) = v104;\nL_0091:\n\tv120 = v108._logPriority < 1;\n\tif (v120) goto L_FFFFFFFF;\n\tgoto L_00A3;\n\tv229 = *([v208 @ X0_v10+E0]);\n\tv230 = v229 == 0;\n\tv231 = ~v230;\n\tif (v231) goto L_00A3;\n\tv233 = \"il2cpp_codegen_runtime_class_init\"(v208, v66, fadeOut, methodInfo, v52, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\nL_00A3:\n\tUnityEngine.Debug::LogWarning(\"DOShakeScale: duration can't be 0, returning NULL without creating a tween\");\nL_00B2:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 135 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOShakeScale(this Transform target, float duration, Vector3 strength, int vibrato = 10, float randomness = 90f, bool fadeOut = true)
		{
			bool flag = duration < 0f;
			bool flag2 = !flag;
			bool flag3 = duration == 0f;
			Transform target2 = target;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				DOGetter<Vector3> getter = () => target2.localScale;
				DOSetter<Vector3> setter = delegate(Vector3 x)
				{
					target2.localScale = x;
				};
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = DOTween.Shake(getter, setter, duration, strength, vibrato, randomness, fadeOut);
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t2 = t.SetTarget(target2);
				return t2.SetSpecialStartupMode(SpecialStartupMode.SetShake);
			}
			if (Debugger._logPriority >= 1)
			{
				Debug.LogWarning("DOShakeScale: duration can't be 0, returning NULL without creating a tween");
			}
			return null;
		}

		[Token(Token = "0x60000D8")]
		[Address(RVA = "0x10E8EEC", Offset = "0x10E8EEC", Length = "0x45C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv58 = *([1EF8328]);\n\tv59 = *([v58 @ X8_v49]);\n\tv60 = \"il2cpp_codegen_initialize_method\"(v59, numJumps, snapping, methodInfo, v62, v63, v64, v65, endValue, v0, v2, jumpPower, duration, v66, v67, v68);\n\tv71 = 0 | 1;\n\t*([202753B]) = v71;\nL_002C:\n\tv75 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass59_0();\n\tSystem.Object::.ctor(v75);\n\tv75.target = target;\n\tv75.endValue = endValue;\n\tv75.endValue.y = endValue.y;\n\tv75.endValue.z = endValue.z;\n\tv75.startPosY = 0f;\n\tv75.offsetYSet = 0;\n\tv75.offsetY = -1f;\n\tv84 = numJumps - 1;\n\tv85 = v84 < 0;\n\tv86 = v84 == 0;\n\tv87 = numJumps ^ 1;\n\tv88 = numJumps ^ v84;\n\tv89 = v87 & v88;\n\tv90 = v89 < 0;\n\tv91 = v85 == v90;\n\tv92 = ~v86;\n\tv93 = v91 & v92;\n\tv94 = ~v93;\n\tif (v94) goto L_FFFFFFFF;\n\tgoto L_0052;\nL_0052:\n\tgoto L_0059;\n\tv210 = *([v100 @ X0_v6+E0]);\n\tv211 = v210 == 0;\n\tv212 = ~v211;\n\tgoto L_0059;\n\tv214 = \"il2cpp_codegen_runtime_class_init\"(v100, v76, snapping, methodInfo, v62, v63, v64, v65, endValue, v0, v2, jumpPower, duration, v66, v67, v68);\nL_0059:\n\tv217 = DG.Tweening.DOTween::Sequence();\n\tv75.s = v217;\n\tv221 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v221, v75, Il2CppMethodInfo);\n\tv233 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v233, v75, Il2CppMethodInfo);\n\tv135 = 0;\n\tv247 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(&v135 @ stack_-A0_v1, 0, Il2CppMethodInfo);\n\tv252 = v99 << 1;\n\tv254 = duration / v252;\n\t// 134 MakeStruct v130 @ AGG10E9074_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v250 @ stack_-9C, 0\n\tv258 = DG.Tweening.DOTween::To(v221, v233, v130, v254);\n\tv263 = DG.Tweening.TweenSettingsExtensions::SetOptions(v258, 4, snapping);\n\tv268 = DG.Tweening.TweenSettingsExtensions::SetEase(v263, 6);\n\tv272 = DG.Tweening.TweenSettingsExtensions::SetRelative(v268);\n\tv278 = DG.Tweening.TweenSettingsExtensions::SetLoops(v272, v252, 1);\n\tv284 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v284, v75, Il2CppMethodInfo);\n\tv296 = DG.Tweening.TweenSettingsExtensions::OnStart(v278, v284);\n\tv75.yTween = v296;\n\tv299 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v299, v75, Il2CppMethodInfo);\n\tv307 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v307, v75, Il2CppMethodInfo);\n\tv122 = 0;\n\tv319 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(&v122 @ stack_-B0_v1, 0, Il2CppMethodInfo);\n\t// 210 MakeStruct v119 @ AGG10E919C_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v322 @ stack_-AC, 0\n\tv328 = DG.Tweening.DOTween::To(v299, v307, v119, duration);\n\tv332 = DG.Tweening.TweenSettingsExtensions::SetOptions(v328, 2, snapping);\n\tv335 = DG.Tweening.TweenSettingsExtensions::SetEase(v332, 1);\n\tv339 = DG.Tweening.TweenSettingsExtensions::Append(v75.s, v335);\n\tv343 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v343, v75, Il2CppMethodInfo);\n\tv351 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v351, v75, Il2CppMethodInfo);\n\tv113 = 0;\n\tv363 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(&v113 @ stack_-C0_v1, 0, Il2CppMethodInfo);\n\t// 258 MakeStruct v110 @ AGG10E9254_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v364 @ stack_-BC, 0\n\tv368 = DG.Tweening.DOTween::To(v343, v351, v110, duration);\n\tv372 = DG.Tweening.TweenSettingsExtensions::SetOptions(v368, 8, snapping);\n\tv375 = DG.Tweening.TweenSettingsExtensions::SetEase(v372, 1);\n\tv379 = DG.Tweening.TweenSettingsExtensions::Join(v339, v375);\n\tv382 = DG.Tweening.TweenSettingsExtensions::Join(v379, v75.yTween);\n\tv387 = DG.Tweening.TweenSettingsExtensions::SetTarget(v382, v75.target);\n\tv395 = DG.Tweening.TweenSettingsExtensions::SetEase(v387, v392.defaultEaseType);\n\tv400 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v400, v75, Il2CppMethodInfo);\n\tv408 = DG.Tweening.TweenSettingsExtensions::OnUpdate(v75.yTween, v400);\n\treturn v75.s;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 244 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sequence DOJump(this Transform target, Vector3 endValue, float jumpPower, int numJumps, float duration, bool snapping = false)
		{
			//IL_0185: Expected O, but got I4
			//IL_01c3: Expected F4, but got O
			//IL_02b6: Expected O, but got I4
			//IL_02d1: Expected F4, but got O
			//IL_037b: Expected O, but got I4
			//IL_039b: Expected F4, but got O
			Vector3 endValue2 = endValue;
			endValue2.y = endValue.y;
			endValue2.z = endValue.z;
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
			DOGetter<Vector3> getter = () => target.position;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.position = x;
			};
			object obj = 0;
			int num6 = num5 << 1;
			float duration2 = duration / (float)num6;
			Vector3 endValue3 = default(Vector3);
			endValue3.x = 0f;
			object obj2 = default(object);
			endValue3.y = (float)obj2;
			endValue3.z = 0f;
			TweenerCore<Vector3, Vector3, VectorOptions> t = DOTween.To(getter, setter, endValue3, duration2);
			Tweener t2 = t.SetOptions(AxisConstraint.Y, snapping);
			Tweener relative = t2.SetEase(Ease.OutQuad);
			Tweener t3 = relative.SetRelative();
			Tweener t4 = t3.SetLoops(num6, LoopType.Yoyo);
			TweenCallback action = delegate
			{
				startPosY = target.position.y;
			};
			Tweener tweener = t4.OnStart(action);
			Tween yTween = tweener;
			DOGetter<Vector3> getter2 = () => target.position;
			DOSetter<Vector3> setter2 = delegate(Vector3 x)
			{
				target.position = x;
			};
			object obj3 = 0;
			Vector3 endValue4 = default(Vector3);
			endValue4.x = 0f;
			object obj4 = default(object);
			endValue4.y = (float)obj4;
			endValue4.z = 0f;
			TweenerCore<Vector3, Vector3, VectorOptions> t5 = DOTween.To(getter2, setter2, endValue4, duration);
			Tweener t6 = t5.SetOptions(AxisConstraint.X, snapping);
			Tweener t7 = t6.SetEase(Ease.Linear);
			Sequence s2 = s.Append(t7);
			DOGetter<Vector3> getter3 = () => target.position;
			DOSetter<Vector3> setter3 = delegate(Vector3 x)
			{
				target.position = x;
			};
			object obj5 = 0;
			Vector3 endValue5 = default(Vector3);
			endValue5.x = 0f;
			object obj6 = default(object);
			endValue5.y = (float)obj6;
			endValue5.z = 0f;
			TweenerCore<Vector3, Vector3, VectorOptions> t8 = DOTween.To(getter3, setter3, endValue5, duration);
			Tweener t9 = t8.SetOptions(AxisConstraint.Z, snapping);
			Tweener t10 = t9.SetEase(Ease.Linear);
			Sequence s3 = s2.Join(t10);
			Sequence t11 = s3.Join(yTween);
			Sequence t12 = t11.SetTarget(target);
			Sequence sequence2 = t12.SetEase(DOTween.defaultEaseType);
			TweenCallback action2 = delegate
			{
				if (!offsetYSet)
				{
					Sequence sequence3 = s;
					offsetYSet = true;
					float num7 = endValue2.y;
					if (!sequence3.isRelative)
					{
						num7 -= startPosY;
					}
					offsetY = num7;
				}
				Vector3 position = target.position;
				float lifetimePercentage = yTween.ElapsedPercentage();
				float num8 = DOVirtual.EasedValue(0f, offsetY, lifetimePercentage, Ease.OutQuad);
				float y = position.y + num8;
				Vector3 position2 = default(Vector3);
				position2.x = position.x;
				position2.y = y;
				position2.z = position.z;
				target.position = position2;
			};
			Tween tween = yTween.OnUpdate(action2);
			return s;
		}

		[Token(Token = "0x60000D9")]
		[Address(RVA = "0x10E9350", Offset = "0x10E9350", Length = "0x434")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv58 = *([1EB33F8]);\n\tv59 = *([v58 @ X8_v49]);\n\tv60 = \"il2cpp_codegen_initialize_method\"(v59, numJumps, snapping, methodInfo, v62, v63, v64, v65, endValue, v0, v2, jumpPower, duration, v66, v67, v68);\n\tv71 = 0 | 1;\n\t*([202753C]) = v71;\nL_002C:\n\tv75 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass60_0();\n\tSystem.Object::.ctor(v75);\n\tv81 = numJumps - 1;\n\tv82 = v81 < 0;\n\tv83 = v81 == 0;\n\tv84 = numJumps ^ 1;\n\tv85 = numJumps ^ v81;\n\tv86 = v84 & v85;\n\tv87 = v86 < 0;\n\tv88 = v82 == v87;\n\tv89 = ~v83;\n\tv90 = v88 & v89;\n\tv91 = ~v90;\n\tif (v91) goto L_FFFFFFFF;\n\tgoto L_0044;\nL_0044:\n\tv75.target = target;\n\tv75.endValue = endValue;\n\tv75.endValue.y = endValue.y;\n\tv75.endValue.z = endValue.z;\n\tv222 = UnityEngine.Transform::get_localPosition(target);\n\tv75.startPosY = v222.y;\n\tv75.offsetYSet = 0;\n\tv75.offsetY = -1f;\n\tgoto L_0061;\n\tv232 = *([v228 @ X0_v7+E0]);\n\tv233 = v232 == 0;\n\tv234 = ~v233;\n\tif (v234) goto L_0061;\n\tv236 = \"il2cpp_codegen_runtime_class_init\"(v228, v221, snapping, methodInfo, v62, v63, v64, v65, v222, v223, v224, jumpPower, duration, v66, v67, v68);\nL_0061:\n\tv239 = DG.Tweening.DOTween::Sequence();\n\tv75.s = v239;\n\tv244 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v244, v75, Il2CppMethodInfo);\n\tv256 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v256, v75, Il2CppMethodInfo);\n\tv153 = 0;\n\tv270 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(&v153 @ stack_-A0_v1, 0, Il2CppMethodInfo);\n\t// 141 MakeStruct v148 @ AGG10E94E8_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v273 @ stack_-9C, 0\n\tv279 = DG.Tweening.DOTween::To(v244, v256, v148, duration);\n\tv284 = DG.Tweening.TweenSettingsExtensions::SetOptions(v279, 2, snapping);\n\tv289 = DG.Tweening.TweenSettingsExtensions::SetEase(v284, 1);\n\tv293 = DG.Tweening.TweenSettingsExtensions::Append(v239, v289);\n\tv297 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v297, v75, Il2CppMethodInfo);\n\tv305 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v305, v75, Il2CppMethodInfo);\n\tv140 = 0;\n\tv317 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(&v140 @ stack_-B0_v1, 0, Il2CppMethodInfo);\n\t// 192 MakeStruct v137 @ AGG10E95AC_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v320 @ stack_-AC, 0\n\tv326 = DG.Tweening.DOTween::To(v297, v305, v137, duration);\n\tv330 = DG.Tweening.TweenSettingsExtensions::SetOptions(v326, 8, snapping);\n\tv333 = DG.Tweening.TweenSettingsExtensions::SetEase(v330, 1);\n\tv337 = DG.Tweening.TweenSettingsExtensions::Join(v293, v333);\n\tv341 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v341, v75, Il2CppMethodInfo);\n\tv349 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v349, v75, Il2CppMethodInfo);\n\tv131 = 0;\n\tv361 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(&v131 @ stack_-C0_v1, 0, Il2CppMethodInfo);\n\tv365 = v117 << 1;\n\tv151 = duration / v365;\n\t// 243 MakeStruct v128 @ AGG10E9670_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v363 @ stack_-BC, 0\n\tv369 = DG.Tweening.DOTween::To(v341, v349, v128, v151);\n\tv373 = DG.Tweening.TweenSettingsExtensions::SetOptions(v369, 4, snapping);\n\tv376 = DG.Tweening.TweenSettingsExtensions::SetEase(v373, 6);\n\tv380 = DG.Tweening.TweenSettingsExtensions::SetRelative(v376);\n\tv386 = DG.Tweening.TweenSettingsExtensions::SetLoops(v380, v365, 1);\n\tv390 = DG.Tweening.TweenSettingsExtensions::Join(v337, v386);\n\tv395 = DG.Tweening.TweenSettingsExtensions::SetTarget(v390, v75.target);\n\tv403 = DG.Tweening.TweenSettingsExtensions::SetEase(v395, v400.defaultEaseType);\n\tv409 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v409, v75, Il2CppMethodInfo);\n\tv417 = DG.Tweening.TweenSettingsExtensions::OnUpdate(v403, v409);\n\treturn v75.s;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 240 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sequence DOLocalJump(this Transform target, Vector3 endValue, float jumpPower, int numJumps, float duration, bool snapping = false)
		{
			//IL_0153: Expected O, but got I4
			//IL_0173: Expected F4, but got O
			//IL_0218: Expected O, but got I4
			//IL_0233: Expected F4, but got O
			//IL_02d8: Expected O, but got I4
			//IL_0316: Expected F4, but got O
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
			Transform target2 = target;
			Vector3 endValue2 = endValue;
			endValue2.y = endValue.y;
			endValue2.z = endValue.z;
			float startPosY = target.localPosition.y;
			bool offsetYSet = false;
			float offsetY = -1f;
			Sequence s2;
			Sequence s = (s2 = DOTween.Sequence());
			DOGetter<Vector3> getter = () => target2.localPosition;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target2.localPosition = x;
			};
			object obj = 0;
			Vector3 endValue3 = default(Vector3);
			endValue3.x = 0f;
			object obj2 = default(object);
			endValue3.y = (float)obj2;
			endValue3.z = 0f;
			TweenerCore<Vector3, Vector3, VectorOptions> t = DOTween.To(getter, setter, endValue3, duration);
			Tweener t2 = t.SetOptions(AxisConstraint.X, snapping);
			Tweener t3 = t2.SetEase(Ease.Linear);
			Sequence s3 = s.Append(t3);
			DOGetter<Vector3> getter2 = () => target2.localPosition;
			DOSetter<Vector3> setter2 = delegate(Vector3 x)
			{
				target2.localPosition = x;
			};
			object obj3 = 0;
			Vector3 endValue4 = default(Vector3);
			endValue4.x = 0f;
			object obj4 = default(object);
			endValue4.y = (float)obj4;
			endValue4.z = 0f;
			TweenerCore<Vector3, Vector3, VectorOptions> t4 = DOTween.To(getter2, setter2, endValue4, duration);
			Tweener t5 = t4.SetOptions(AxisConstraint.Z, snapping);
			Tweener t6 = t5.SetEase(Ease.Linear);
			Sequence s4 = s3.Join(t6);
			DOGetter<Vector3> getter3 = () => target2.localPosition;
			DOSetter<Vector3> setter3 = delegate(Vector3 x)
			{
				target2.localPosition = x;
			};
			object obj5 = 0;
			int num6 = num5 << 1;
			float duration2 = duration / (float)num6;
			Vector3 endValue5 = default(Vector3);
			endValue5.x = 0f;
			object obj6 = default(object);
			endValue5.y = (float)obj6;
			endValue5.z = 0f;
			TweenerCore<Vector3, Vector3, VectorOptions> t7 = DOTween.To(getter3, setter3, endValue5, duration2);
			Tweener t8 = t7.SetOptions(AxisConstraint.Y, snapping);
			Tweener relative = t8.SetEase(Ease.OutQuad);
			Tweener t9 = relative.SetRelative();
			Tweener t10 = t9.SetLoops(num6, LoopType.Yoyo);
			Sequence t11 = s4.Join(t10);
			Sequence t12 = t11.SetTarget(target2);
			Sequence t13 = t12.SetEase(DOTween.defaultEaseType);
			TweenCallback action = delegate
			{
				if (!offsetYSet)
				{
					Sequence sequence2 = s2;
					offsetYSet = false;
					float num7 = endValue2.y;
					if (!sequence2.isRelative)
					{
						num7 -= startPosY;
					}
					offsetY = num7;
				}
				Vector3 localPosition = target2.localPosition;
				float lifetimePercentage = s2.ElapsedDirectionalPercentage();
				float num8 = DOVirtual.EasedValue(0f, offsetY, lifetimePercentage, Ease.OutQuad);
				float y = localPosition.y + num8;
				Vector3 localPosition2 = default(Vector3);
				localPosition2.x = localPosition.x;
				localPosition2.y = y;
				localPosition2.z = localPosition.z;
				target2.localPosition = localPosition2;
			};
			Sequence sequence = t13.OnUpdate(action);
			return s2;
		}

		[Token(Token = "0x60000DA")]
		[Address(RVA = "0x10E978C", Offset = "0x10E978C", Length = "0x1CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv46 = *([1F0FF10]);\n\tv47 = *([v46 @ X8_v29]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, path, pathType, pathMode, resolution, gizmoColor, methodInfo, v50, duration, v51, v52, v53, v54, v55, v56, v57);\n\tv60 = 0 | 1;\n\t*([202753D]) = v60;\nL_0024:\n\tv64 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass61_0();\n\tSystem.Object::.ctor(v64);\n\tv70 = resolution - 1;\n\tv71 = v70 < 0;\n\tv72 = v70 == 0;\n\tv73 = resolution ^ 1;\n\tv74 = resolution ^ v70;\n\tv75 = v73 & v74;\n\tv76 = v75 < 0;\n\tv64.target = target;\n\tv77 = v71 == v76;\n\tv78 = ~v72;\n\tv79 = v77 & v78;\n\tv80 = ~v79;\n\tif (v80) goto L_FFFFFFFF;\n\tgoto L_003D;\nL_003D:\n\tv144 = DG.Tweening.Plugins.PathPlugin::Get();\n\tv149 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v149, v64, Il2CppMethodInfo);\n\tv207 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v207, v64, Il2CppMethodInfo);\n\tduration = *([gizmoColor @ X5 (System.Nullable`1<UnityEngine.Color>)]);\n\tv219 = new DG.Tweening.Plugins.Core.PathCore.Path();\n\tDG.Tweening.Plugins.Core.PathCore.Path::.ctor(v219, pathType, path, v106, &duration @ V0 (System.Single));\n\tgoto L_007D;\n\tv230 = *([v226 @ X0_v14+E0]);\n\tv231 = v230 == 0;\n\tv232 = ~v231;\n\tif (v232) goto L_007D;\n\tv234 = \"il2cpp_codegen_runtime_class_init\"(v226, v221, v222, v223, v220, v85, methodInfo, v50, v216, v51, v52, v53, v54, v55, v56, v57);\nL_007D:\n\tv242 = DG.Tweening.DOTween::To(v144, v149, v207, v219, duration);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v242, v64.target);\n\treturnVal2.plugOptions.mode = pathMode;\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 109 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static TweenerCore<Vector3, Path, PathOptions> DOPath(this Transform target, Vector3[] path, float duration, PathType pathType = PathType.Linear, PathMode pathMode = PathMode.Full3D, int resolution = 10, Color? gizmoColor = null)
		{
			//IL_00f0: Expected F4, but got O
			//IL_0105: Expected O, but got Ref
			int num = resolution - 1;
			bool flag = num < 0;
			bool flag2 = num == 0;
			int num2 = resolution ^ 1;
			int num3 = resolution ^ num;
			int num4 = num2 & num3;
			bool flag3 = num4 < 0;
			Transform target2 = target;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			int subdivisionsXSegment = ((!(flag4 && flag5)) ? 1 : resolution);
			ABSTweenPlugin<Vector3, Path, PathOptions> plugin = PathPlugin.Get();
			DOGetter<Vector3> getter = () => target2.position;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target2.position = x;
			};
			float num5 = (float)gizmoColor;
			Path endValue = new Path(pathType, path, subdivisionsXSegment, (Color?)(object)(&num5));
			TweenerCore<Vector3, Path, PathOptions> t = DOTween.To(plugin, getter, setter, endValue, duration);
			TweenerCore<Vector3, Path, PathOptions> tweenerCore = t.SetTarget(target2);
			tweenerCore.plugOptions.mode = pathMode;
			return tweenerCore;
		}

		[Token(Token = "0x60000DB")]
		[Address(RVA = "0x10E9960", Offset = "0x10E9960", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv46 = *([1EEEEE0]);\n\tv47 = *([v46 @ X8_v30]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, path, pathType, pathMode, resolution, gizmoColor, methodInfo, v50, duration, v51, v52, v53, v54, v55, v56, v57);\n\tv60 = 0 | 1;\n\t*([202753E]) = v60;\nL_0024:\n\tv64 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass62_0();\n\tSystem.Object::.ctor(v64);\n\tv70 = resolution - 1;\n\tv71 = v70 < 0;\n\tv72 = v70 == 0;\n\tv73 = resolution ^ 1;\n\tv74 = resolution ^ v70;\n\tv75 = v73 & v74;\n\tv76 = v75 < 0;\n\tv64.target = target;\n\tv77 = v71 == v76;\n\tv78 = ~v72;\n\tv79 = v77 & v78;\n\tv80 = ~v79;\n\tif (v80) goto L_FFFFFFFF;\n\tgoto L_003D;\nL_003D:\n\tv144 = DG.Tweening.Plugins.PathPlugin::Get();\n\tv149 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v149, v64, Il2CppMethodInfo);\n\tv208 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v208, v64, Il2CppMethodInfo);\n\tduration = *([gizmoColor @ X5 (System.Nullable`1<UnityEngine.Color>)]);\n\tv220 = new DG.Tweening.Plugins.Core.PathCore.Path();\n\tDG.Tweening.Plugins.Core.PathCore.Path::.ctor(v220, pathType, path, v106, &duration @ V0 (System.Single));\n\tgoto L_007D;\n\tv231 = *([v227 @ X0_v14+E0]);\n\tv232 = v231 == 0;\n\tv233 = ~v232;\n\tif (v233) goto L_007D;\n\tv235 = \"il2cpp_codegen_runtime_class_init\"(v227, v222, v223, v224, v221, v85, methodInfo, v50, v217, v51, v52, v53, v54, v55, v56, v57);\nL_007D:\n\tv243 = DG.Tweening.DOTween::To(v144, v149, v208, v220, duration);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v243, v64.target);\n\treturnVal2.plugOptions.mode = pathMode;\n\treturnVal2.plugOptions.useLocalPosition = 1;\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 110 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static TweenerCore<Vector3, Path, PathOptions> DOLocalPath(this Transform target, Vector3[] path, float duration, PathType pathType = PathType.Linear, PathMode pathMode = PathMode.Full3D, int resolution = 10, Color? gizmoColor = null)
		{
			//IL_00f0: Expected F4, but got O
			//IL_0105: Expected O, but got Ref
			int num = resolution - 1;
			bool flag = num < 0;
			bool flag2 = num == 0;
			int num2 = resolution ^ 1;
			int num3 = resolution ^ num;
			int num4 = num2 & num3;
			bool flag3 = num4 < 0;
			Transform target2 = target;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			int subdivisionsXSegment = ((!(flag4 && flag5)) ? 1 : resolution);
			ABSTweenPlugin<Vector3, Path, PathOptions> plugin = PathPlugin.Get();
			DOGetter<Vector3> getter = () => target2.localPosition;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target2.localPosition = x;
			};
			float num5 = (float)gizmoColor;
			Path endValue = new Path(pathType, path, subdivisionsXSegment, (Color?)(object)(&num5));
			TweenerCore<Vector3, Path, PathOptions> t = DOTween.To(plugin, getter, setter, endValue, duration);
			TweenerCore<Vector3, Path, PathOptions> tweenerCore = t.SetTarget(target2);
			tweenerCore.plugOptions.mode = pathMode;
			tweenerCore.plugOptions.useLocalPosition = true;
			return tweenerCore;
		}

		[Token(Token = "0x60000DC")]
		[Address(RVA = "0x10E9B3C", Offset = "0x10E9B3C", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv34 = *([1EE54F8]);\n\tv35 = *([v34 @ X8_v26]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, path, pathMode, methodInfo, v38, v39, v40, v41, duration, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([202753F]) = v51;\nL_001E:\n\tv55 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass63_0();\n\tSystem.Object::.ctor(v55);\n\tv55.target = target;\n\tv59 = DG.Tweening.Plugins.PathPlugin::Get();\n\tv66 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v66, v55, Il2CppMethodInfo);\n\tv102 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v102, v55, Il2CppMethodInfo);\n\tgoto L_0056;\n\tv142 = *([v138 @ X0_v12+E0]);\n\tv143 = v142 == 0;\n\tv144 = ~v143;\n\tif (v144) goto L_0056;\n\tv146 = \"il2cpp_codegen_runtime_class_init\"(v138, v133, v134, v135, v38, v39, v40, v41, duration, v42, v43, v44, v45, v46, v47, v48);\nL_0056:\n\tv154 = DG.Tweening.DOTween::To(v59, v66, v102, path, duration);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v154, v55.target);\n\treturnVal2.plugOptions.mode = pathMode;\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Path, PathOptions> DOPath(this Transform target, Path path, float duration, PathMode pathMode = PathMode.Full3D)
		{
			ABSTweenPlugin<Vector3, Path, PathOptions> plugin = PathPlugin.Get();
			DOGetter<Vector3> getter = () => target.position;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.position = x;
			};
			TweenerCore<Vector3, Path, PathOptions> t = DOTween.To(plugin, getter, setter, path, duration);
			TweenerCore<Vector3, Path, PathOptions> tweenerCore = t.SetTarget(target);
			tweenerCore.plugOptions.mode = pathMode;
			return tweenerCore;
		}

		[Token(Token = "0x60000DD")]
		[Address(RVA = "0x10E9CA8", Offset = "0x10E9CA8", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv34 = *([1F01388]);\n\tv35 = *([v34 @ X8_v27]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, path, pathMode, methodInfo, v38, v39, v40, v41, duration, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([2027540]) = v51;\nL_001E:\n\tv55 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass64_0();\n\tSystem.Object::.ctor(v55);\n\tv55.target = target;\n\tv59 = DG.Tweening.Plugins.PathPlugin::Get();\n\tv66 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v66, v55, Il2CppMethodInfo);\n\tv102 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v102, v55, Il2CppMethodInfo);\n\tgoto L_0056;\n\tv143 = *([v139 @ X0_v12+E0]);\n\tv144 = v143 == 0;\n\tv145 = ~v144;\n\tif (v145) goto L_0056;\n\tv147 = \"il2cpp_codegen_runtime_class_init\"(v139, v134, v135, v136, v38, v39, v40, v41, duration, v42, v43, v44, v45, v46, v47, v48);\nL_0056:\n\tv155 = DG.Tweening.DOTween::To(v59, v66, v102, path, duration);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v155, v55.target);\n\treturnVal2.plugOptions.mode = pathMode;\n\treturnVal2.plugOptions.useLocalPosition = 1;\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Path, PathOptions> DOLocalPath(this Transform target, Path path, float duration, PathMode pathMode = PathMode.Full3D)
		{
			ABSTweenPlugin<Vector3, Path, PathOptions> plugin = PathPlugin.Get();
			DOGetter<Vector3> getter = () => target.localPosition;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.localPosition = x;
			};
			TweenerCore<Vector3, Path, PathOptions> t = DOTween.To(plugin, getter, setter, path, duration);
			TweenerCore<Vector3, Path, PathOptions> tweenerCore = t.SetTarget(target);
			tweenerCore.plugOptions.mode = pathMode;
			tweenerCore.plugOptions.useLocalPosition = true;
			return tweenerCore;
		}

		[Token(Token = "0x60000DE")]
		[Address(RVA = "0x10E9E1C", Offset = "0x10E9E1C", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1F036C0]);\n\tv29 = *([v28 @ X8_v22]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2027541]) = v46;\nL_001B:\n\tv50 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass65_0();\n\tSystem.Object::.ctor(v50);\n\tv50.target = target;\n\tv57 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v57, v50, Il2CppMethodInfo);\n\tv71 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v71, v50, Il2CppMethodInfo);\n\tgoto L_004D;\n\tv117 = *([v113 @ X0_v10+E0]);\n\tv118 = v117 == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_004D;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v113, v108, v110, v81, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\nL_004D:\n\tv126 = DG.Tweening.DOTween::To(v57, v71, endValue, duration);\n\tv129 = DG.Tweening.TweenSettingsExtensions::SetTarget(v126, v50.target);\n\treturn v126;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<float, float, FloatOptions> DOTimeScale(this Tween target, float endValue, float duration)
		{
			DOGetter<float> getter = delegate
			{
				Tween tween = target;
				return tween.timeScale;
			};
			DOSetter<float> setter = delegate(float x)
			{
				Tween tween = target;
				tween.timeScale = x;
			};
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<float, float, FloatOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x60000DF")]
		[Address(RVA = "0x10E9F64", Offset = "0x10E9F64", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv40 = *([1F0B9B8]);\n\tv41 = *([v40 @ X8_v25]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, methodInfo, v44, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2027542]) = v55;\nL_0024:\n\tv59 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass66_0();\n\tSystem.Object::.ctor(v59);\n\tv59.target = target;\n\tv69 = UnityEngine.Light::get_color(target);\n\tv84 = UnityEngine.Color::op_Subtraction(endValue, v69);\n\tv106 = 0;\n\tv162 = 0x101059C(&v106 @ stack_-60_v1 (System.Single), 0, v44, v45, v46, v47, v48, v49, 0, 0, 0, 0, v69, v69.g, v69.b, v69.a);\n\tv59.to.r = 0f;\n\tv59.to.g = v165;\n\tv59.to.a = v166;\n\tv170 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v170, v59, Il2CppMethodInfo);\n\tv182 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v182, v59, Il2CppMethodInfo);\n\tgoto L_0084;\n\tv195 = *([v191 @ X0_v14+E0]);\n\tv196 = v195 == 0;\n\tv197 = ~v196;\n\tif (v197) goto L_0084;\n\tv199 = \"il2cpp_codegen_runtime_class_init\"(v191, v186, v188, v93, v46, v47, v48, v49, v157, v158, v159, v160, v73, v74, v75, v76);\nL_0084:\n\tv204 = DG.Tweening.DOTween::To(v170, v182, v84, duration);\n\tv208 = DG.Tweening.Core.Extensions::Blendable(v204);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v208, v59.target);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 125 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOBlendableColor(this Light target, Color endValue, float duration)
		{
			//IL_0077: Expected F4, but got O
			Light target2 = target;
			Color color = target.color;
			Color endValue2 = endValue - color;
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
				Color color2 = default(Color);
				color2.r = to.r;
				color2.g = to.g;
				color2.b = to.b;
				color2.a = to.a;
				Color color3 = x - color2;
				to = x;
				to.g = x.g;
				to.b = x.b;
				to.a = x.a;
				Color color4 = target2.color;
				Color color5 = color4 + color3;
				target2.color = color5;
			};
			TweenerCore<Color, Color, ColorOptions> t = DOTween.To(getter, setter, endValue2, duration);
			TweenerCore<Color, Color, ColorOptions> t2 = t.Blendable();
			return t2.SetTarget(target2);
		}

		[Token(Token = "0x60000E0")]
		[Address(RVA = "0x10EA164", Offset = "0x10EA164", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv40 = *([1ECF550]);\n\tv41 = *([v40 @ X8_v25]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, methodInfo, v44, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2027543]) = v55;\nL_0024:\n\tv59 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass67_0();\n\tSystem.Object::.ctor(v59);\n\tv59.target = target;\n\tv69 = UnityEngine.Material::get_color(target);\n\tv84 = UnityEngine.Color::op_Subtraction(endValue, v69);\n\tv106 = 0;\n\tv162 = 0x101059C(&v106 @ stack_-60_v1 (System.Single), 0, v44, v45, v46, v47, v48, v49, 0, 0, 0, 0, v69, v69.g, v69.b, v69.a);\n\tv59.to.r = 0f;\n\tv59.to.g = v165;\n\tv59.to.a = v166;\n\tv170 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v170, v59, Il2CppMethodInfo);\n\tv182 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v182, v59, Il2CppMethodInfo);\n\tgoto L_0084;\n\tv195 = *([v191 @ X0_v14+E0]);\n\tv196 = v195 == 0;\n\tv197 = ~v196;\n\tif (v197) goto L_0084;\n\tv199 = \"il2cpp_codegen_runtime_class_init\"(v191, v186, v188, v93, v46, v47, v48, v49, v157, v158, v159, v160, v73, v74, v75, v76);\nL_0084:\n\tv204 = DG.Tweening.DOTween::To(v170, v182, v84, duration);\n\tv208 = DG.Tweening.Core.Extensions::Blendable(v204);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v208, v59.target);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 125 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOBlendableColor(this Material target, Color endValue, float duration)
		{
			//IL_0077: Expected F4, but got O
			Material target2 = target;
			Color color = target.color;
			Color endValue2 = endValue - color;
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
				Color color2 = default(Color);
				color2.r = to.r;
				color2.g = to.g;
				color2.b = to.b;
				color2.a = to.a;
				Color color3 = x - color2;
				to = x;
				to.g = x.g;
				to.b = x.b;
				to.a = x.a;
				Color color4 = target2.color;
				Color color5 = color4 + color3;
				target2.color = color5;
			};
			TweenerCore<Color, Color, ColorOptions> t = DOTween.To(getter, setter, endValue2, duration);
			TweenerCore<Color, Color, ColorOptions> t2 = t.Blendable();
			return t2.SetTarget(target2);
		}

		[Token(Token = "0x60000E1")]
		[Address(RVA = "0x10EA364", Offset = "0x10EA364", Length = "0x26C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv42 = *([1F08048]);\n\tv43 = *([v42 @ X8_v36]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, property, methodInfo, v46, v47, v48, v49, v50, endValue, v0, v2, v3, duration, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2027544]) = v56;\nL_0025:\n\tv60 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass68_0();\n\tSystem.Object::.ctor(v60);\n\tv60.target = target;\n\tv60.property = property;\n\tv70 = UnityEngine.Material::HasProperty(target, property);\n\tv79 = v70 == 0;\n\tif (v79) goto L_009F;\n\tv182 = UnityEngine.Material::GetColor(v60.target, v60.property);\n\tv220 = UnityEngine.Color::op_Subtraction(endValue, v182);\n\tv234 = 0;\n\tv241 = 0x101059C(&v234 @ stack_-60_v2 (System.Single), 0, 0, v46, v47, v48, v49, v50, 0, 0, 0, 0, v182, v182.g, v182.b, v182.a);\n\tv60.to.r = 0f;\n\tv60.to.g = v266;\n\tv60.to.a = v267;\n\tv271 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v271, v60, Il2CppMethodInfo);\n\tv282 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v282, v60, Il2CppMethodInfo);\n\tgoto L_0090;\n\tv294 = *([v290 @ X0_v24+E0]);\n\tv295 = v294 == 0;\n\tv296 = ~v295;\n\tif (v296) goto L_0090;\n\tv298 = \"il2cpp_codegen_runtime_class_init\"(v290, v286, v287, v243, v47, v48, v49, v50, v235, v236, v237, v238, v209, v210, v211, v212);\nL_0090:\n\tv303 = DG.Tweening.DOTween::To(v271, v282, v220, duration);\n\tv307 = DG.Tweening.Core.Extensions::Blendable(v303);\n\tv250 = DG.Tweening.TweenSettingsExtensions::SetTarget(v307, v60.target);\n\tgoto L_00C6;\nL_009F:\n\tgoto L_00B5;\n\tv184 = *([1EFC598]);\n\tv185 = *([v184 @ X8_v14]);\n\tv186 = \"il2cpp_codegen_initialize_method\"(v185, v68, v69, v46, v47, v48, v49, v50, endValue, v0, v2, v3, duration, v51, v52, v53);\n\tv189 = 0 | 1;\n\t*([2022B9B]) = v189;\nL_00B5:\n\tv205 = v193._logPriority < 1;\n\tif (v205) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogMissingMaterialProperty(v60.property);\nL_00C6:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 156 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOBlendableColor(this Material target, Color endValue, string property, float duration)
		{
			//IL_00c0: Expected F4, but got O
			Material target2 = target;
			string property2 = property;
			if (target.HasProperty(property))
			{
				Color color = target2.GetColor(property2);
				Color endValue2 = endValue - color;
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
					Color color2 = default(Color);
					color2.r = to.r;
					color2.g = to.g;
					color2.b = to.b;
					color2.a = to.a;
					Color color3 = x - color2;
					to = x;
					to.g = x.g;
					to.b = x.b;
					to.a = x.a;
					Color color4 = target2.GetColor(property2);
					Color value = color4 + color3;
					target2.SetColor(property2, value);
				};
				TweenerCore<Color, Color, ColorOptions> t = DOTween.To(getter, setter, endValue2, duration);
				TweenerCore<Color, Color, ColorOptions> t2 = t.Blendable();
				return t2.SetTarget(target2);
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogMissingMaterialProperty(property2);
			}
			return null;
		}

		[Token(Token = "0x60000E2")]
		[Address(RVA = "0x10EA5D8", Offset = "0x10EA5D8", Length = "0x270")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv42 = *([1EE4708]);\n\tv43 = *([v42 @ X8_v36]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, propertyID, methodInfo, v46, v47, v48, v49, v50, endValue, v0, v2, v3, duration, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2027545]) = v56;\nL_0025:\n\tv60 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass69_0();\n\tSystem.Object::.ctor(v60);\n\tv60.target = target;\n\tv60.propertyID = propertyID;\n\tv70 = UnityEngine.Material::HasProperty(target, propertyID);\n\tv79 = v70 == 0;\n\tif (v79) goto L_009F;\n\tv182 = UnityEngine.Material::GetColor(v60.target, v60.propertyID);\n\tv220 = UnityEngine.Color::op_Subtraction(endValue, v182);\n\tv234 = 0;\n\tv241 = 0x101059C(&v234 @ stack_-60_v2 (System.Single), 0, 0, v46, v47, v48, v49, v50, 0, 0, 0, 0, v182, v182.g, v182.b, v182.a);\n\tv60.to.r = 0f;\n\tv60.to.g = v266;\n\tv60.to.a = v267;\n\tv271 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v271, v60, Il2CppMethodInfo);\n\tv282 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v282, v60, Il2CppMethodInfo);\n\tgoto L_0090;\n\tv294 = *([v290 @ X0_v24+E0]);\n\tv295 = v294 == 0;\n\tv296 = ~v295;\n\tif (v296) goto L_0090;\n\tv298 = \"il2cpp_codegen_runtime_class_init\"(v290, v286, v287, v243, v47, v48, v49, v50, v235, v236, v237, v238, v209, v210, v211, v212);\nL_0090:\n\tv303 = DG.Tweening.DOTween::To(v271, v282, v220, duration);\n\tv307 = DG.Tweening.Core.Extensions::Blendable(v303);\n\tv250 = DG.Tweening.TweenSettingsExtensions::SetTarget(v307, v60.target);\n\tgoto L_00C6;\nL_009F:\n\tgoto L_00B5;\n\tv184 = *([1EFC598]);\n\tv185 = *([v184 @ X8_v14]);\n\tv186 = \"il2cpp_codegen_initialize_method\"(v185, v68, v69, v46, v47, v48, v49, v50, endValue, v0, v2, v3, duration, v51, v52, v53);\n\tv189 = 0 | 1;\n\t*([2022B9B]) = v189;\nL_00B5:\n\tv205 = v193._logPriority < 1;\n\tif (v205) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogMissingMaterialProperty(v60.propertyID);\nL_00C6:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 156 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOBlendableColor(this Material target, Color endValue, int propertyID, float duration)
		{
			//IL_00c0: Expected F4, but got O
			Material target2 = target;
			int propertyID2 = propertyID;
			if (target.HasProperty(propertyID))
			{
				Color color = target2.GetColor(propertyID2);
				Color endValue2 = endValue - color;
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
					Color color2 = default(Color);
					color2.r = to.r;
					color2.g = to.g;
					color2.b = to.b;
					color2.a = to.a;
					Color color3 = x - color2;
					to = x;
					to.g = x.g;
					to.b = x.b;
					to.a = x.a;
					Color color4 = target2.GetColor(propertyID2);
					Color value = color4 + color3;
					target2.SetColor(propertyID2, value);
				};
				TweenerCore<Color, Color, ColorOptions> t = DOTween.To(getter, setter, endValue2, duration);
				TweenerCore<Color, Color, ColorOptions> t2 = t.Blendable();
				return t2.SetTarget(target2);
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogMissingMaterialProperty(propertyID2);
			}
			return null;
		}

		[Token(Token = "0x60000E3")]
		[Address(RVA = "0x10EA850", Offset = "0x10EA850", Length = "0x19C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv40 = *([1EDD398]);\n\tv41 = *([v40 @ X8_v29]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, snapping, methodInfo, v44, v45, v46, v47, v48, byValue, v0, v2, duration, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2027546]) = v55;\nL_0023:\n\tv59 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass70_0();\n\tSystem.Object::.ctor(v59);\n\tv59.target = target;\n\tgoto L_0037;\n\tv71 = *([v65 @ X0_v6+E0]);\n\tv72 = v71 == 0;\n\tv73 = ~v72;\n\tif (v73) goto L_0037;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v65, v60, methodInfo, v44, v45, v46, v47, v48, byValue, v0, v2, duration, v49, v50, v51, v52);\nL_0037:\n\tv79 = UnityEngine.Vector3::get_zero();\n\tv59.to = v79;\n\tv59.to.y = v79.y;\n\tv59.to.z = v79.z;\n\tv85 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v85, v59, Il2CppMethodInfo);\n\tv143 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v143, v59, Il2CppMethodInfo);\n\tgoto L_006B;\n\tv156 = *([v152 @ X0_v13+E0]);\n\tv157 = v156 == 0;\n\tv158 = ~v157;\n\tif (v158) goto L_006B;\n\tv160 = \"il2cpp_codegen_runtime_class_init\"(v152, v147, v149, v96, v45, v46, v47, v48, v79, v80, v81, duration, v49, v50, v51, v52);\nL_006B:\n\tv165 = DG.Tweening.DOTween::To(v85, v143, byValue, duration);\n\tv169 = DG.Tweening.Core.Extensions::Blendable(v165);\n\tv172 = DG.Tweening.TweenSettingsExtensions::SetOptions(v169, snapping);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v172, v59.target);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 99 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOBlendableMoveBy(this Transform target, Vector3 byValue, float duration, bool snapping = false)
		{
			Vector3 to;
			Vector3 vector = (to = Vector3.zero);
			to.y = vector.y;
			to.z = vector.z;
			DOGetter<Vector3> getter = () => to;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				Vector3 vector2 = default(Vector3);
				vector2.x = to.x;
				vector2.y = to.y;
				vector2.z = to.z;
				Vector3 vector3 = x - vector2;
				to = x;
				to.y = x.y;
				to.z = x.z;
				Vector3 position = target.position;
				Vector3 position2 = position + vector3;
				target.position = position2;
			};
			TweenerCore<Vector3, Vector3, VectorOptions> t = DOTween.To(getter, setter, byValue, duration);
			TweenerCore<Vector3, Vector3, VectorOptions> t2 = t.Blendable();
			Tweener t3 = t2.SetOptions(snapping);
			return t3.SetTarget(target);
		}

		[Token(Token = "0x60000E4")]
		[Address(RVA = "0x10EA9F4", Offset = "0x10EA9F4", Length = "0x19C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv40 = *([1EA50C0]);\n\tv41 = *([v40 @ X8_v29]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, snapping, methodInfo, v44, v45, v46, v47, v48, byValue, v0, v2, duration, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2027547]) = v55;\nL_0023:\n\tv59 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass71_0();\n\tSystem.Object::.ctor(v59);\n\tv59.target = target;\n\tgoto L_0037;\n\tv71 = *([v65 @ X0_v6+E0]);\n\tv72 = v71 == 0;\n\tv73 = ~v72;\n\tif (v73) goto L_0037;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v65, v60, methodInfo, v44, v45, v46, v47, v48, byValue, v0, v2, duration, v49, v50, v51, v52);\nL_0037:\n\tv79 = UnityEngine.Vector3::get_zero();\n\tv59.to = v79;\n\tv59.to.y = v79.y;\n\tv59.to.z = v79.z;\n\tv85 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v85, v59, Il2CppMethodInfo);\n\tv143 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v143, v59, Il2CppMethodInfo);\n\tgoto L_006B;\n\tv156 = *([v152 @ X0_v13+E0]);\n\tv157 = v156 == 0;\n\tv158 = ~v157;\n\tif (v158) goto L_006B;\n\tv160 = \"il2cpp_codegen_runtime_class_init\"(v152, v147, v149, v96, v45, v46, v47, v48, v79, v80, v81, duration, v49, v50, v51, v52);\nL_006B:\n\tv165 = DG.Tweening.DOTween::To(v85, v143, byValue, duration);\n\tv169 = DG.Tweening.Core.Extensions::Blendable(v165);\n\tv172 = DG.Tweening.TweenSettingsExtensions::SetOptions(v169, snapping);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v172, v59.target);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 99 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOBlendableLocalMoveBy(this Transform target, Vector3 byValue, float duration, bool snapping = false)
		{
			Vector3 to;
			Vector3 vector = (to = Vector3.zero);
			to.y = vector.y;
			to.z = vector.z;
			DOGetter<Vector3> getter = () => to;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				Vector3 vector2 = default(Vector3);
				vector2.x = to.x;
				vector2.y = to.y;
				vector2.z = to.z;
				Vector3 vector3 = x - vector2;
				to = x;
				to.y = x.y;
				to.z = x.z;
				Vector3 localPosition = target.localPosition;
				Vector3 localPosition2 = localPosition + vector3;
				target.localPosition = localPosition2;
			};
			TweenerCore<Vector3, Vector3, VectorOptions> t = DOTween.To(getter, setter, byValue, duration);
			TweenerCore<Vector3, Vector3, VectorOptions> t2 = t.Blendable();
			Tweener t3 = t2.SetOptions(snapping);
			return t3.SetTarget(target);
		}

		[Token(Token = "0x60000E5")]
		[Address(RVA = "0x10EAB98", Offset = "0x10EAB98", Length = "0x19C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv40 = *([1EDF8D8]);\n\tv41 = *([v40 @ X8_v30]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, mode, methodInfo, v44, v45, v46, v47, v48, byValue, v0, v2, duration, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2027548]) = v55;\nL_0023:\n\tv59 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass72_0();\n\tSystem.Object::.ctor(v59);\n\tv59.target = target;\n\tgoto L_0037;\n\tv70 = *([v65 @ X0_v7+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_0037;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v65, v60, methodInfo, v44, v45, v46, v47, v48, byValue, v0, v2, duration, v49, v50, v51, v52);\nL_0037:\n\tv78 = UnityEngine.Quaternion::get_identity();\n\tv59.to = v78;\n\tv59.to.y = v78.y;\n\tv59.to.z = v78.z;\n\tv59.to.w = v78.w;\n\tv116 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>::.ctor(v116, v59, Il2CppMethodInfo);\n\tv159 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>::.ctor(v159, v59, Il2CppMethodInfo);\n\tgoto L_006D;\n\tv171 = *([v167 @ X0_v14+E0]);\n\tv172 = v171 == 0;\n\tv173 = ~v172;\n\tif (v173) goto L_006D;\n\tv175 = \"il2cpp_codegen_runtime_class_init\"(v167, v163, v164, v85, v45, v46, v47, v48, v78, v110, v111, v112, v49, v50, v51, v52);\nL_006D:\n\tv181 = DG.Tweening.DOTween::To(v116, v159, byValue, duration);\n\tv185 = DG.Tweening.Core.Extensions::Blendable(v181);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v185, v59.target);\n\t*([returnVal2 @ X0_v19 (DG.Tweening.Tweener)+140]) = mode;\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOBlendableRotateBy(this Transform target, Vector3 byValue, float duration, RotateMode mode = RotateMode.Fast)
		{
			Quaternion to;
			Quaternion quaternion = (to = Quaternion.identity);
			to.y = quaternion.y;
			to.z = quaternion.z;
			to.w = quaternion.w;
			DOGetter<Quaternion> getter = () => to;
			DOSetter<Quaternion> setter = delegate(Quaternion x)
			{
				//IL_0154: Expected O, but got I
				Quaternion rotation = default(Quaternion);
				rotation.x = to.x;
				rotation.y = to.y;
				rotation.z = to.z;
				rotation.w = to.w;
				Quaternion quaternion2 = Quaternion.Inverse(rotation);
				Quaternion quaternion3 = x * quaternion2;
				to = x;
				to.y = x.y;
				to.z = x.z;
				to.w = x.w;
				Quaternion rotation2 = target.rotation;
				Quaternion quaternion4 = Quaternion.Inverse(rotation2);
				Quaternion quaternion5 = rotation2 * quaternion4;
				Quaternion quaternion6 = quaternion5 * quaternion3;
				Quaternion rotation3 = quaternion6 * rotation2;
				if ((object)target != null)
				{
					target.rotation = rotation3;
				}
				else
				{
					IntPtr intPtr = default(IntPtr);
					NullReferenceException ex = (NullReferenceException)(object)new System.Xml.Schema.XmlBooleanConverter((XmlSchemaType)(long)intPtr);
				}
			};
			TweenerCore<Quaternion, Vector3, QuaternionOptions> t = DOTween.To(getter, setter, byValue, duration);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> t2 = t.Blendable();
			return t2.SetTarget(target);
		}

		[Token(Token = "0x60000E6")]
		[Address(RVA = "0x10EAD3C", Offset = "0x10EAD3C", Length = "0x19C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv40 = *([1F0A908]);\n\tv41 = *([v40 @ X8_v30]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, mode, methodInfo, v44, v45, v46, v47, v48, byValue, v0, v2, duration, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2027549]) = v55;\nL_0023:\n\tv59 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass73_0();\n\tDG.Tweening.ShortcutExtensions+<>c__DisplayClass73_0::.ctor(v59);\n\tv59.target = target;\n\tgoto L_0037;\n\tv70 = *([v65 @ X0_v7+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_0037;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v65, v60, methodInfo, v44, v45, v46, v47, v48, byValue, v0, v2, duration, v49, v50, v51, v52);\nL_0037:\n\tv78 = UnityEngine.Quaternion::get_identity();\n\tv59.to = v78;\n\tv59.to.y = v78.y;\n\tv59.to.z = v78.z;\n\tv59.to.w = v78.w;\n\tv116 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>::.ctor(v116, v59, Il2CppMethodInfo);\n\tv159 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>::.ctor(v159, v59, Il2CppMethodInfo);\n\tgoto L_006D;\n\tv171 = *([v167 @ X0_v14+E0]);\n\tv172 = v171 == 0;\n\tv173 = ~v172;\n\tif (v173) goto L_006D;\n\tv175 = \"il2cpp_codegen_runtime_class_init\"(v167, v163, v164, v85, v45, v46, v47, v48, v78, v110, v111, v112, v49, v50, v51, v52);\nL_006D:\n\tv181 = DG.Tweening.DOTween::To(v116, v159, byValue, duration);\n\tv185 = DG.Tweening.Core.Extensions::Blendable(v181);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v185, v59.target);\n\t*([returnVal2 @ X0_v19 (DG.Tweening.Tweener)+140]) = mode;\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOBlendableLocalRotateBy(this Transform target, Vector3 byValue, float duration, RotateMode mode = RotateMode.Fast)
		{
			Quaternion to;
			Quaternion quaternion = (to = Quaternion.identity);
			to.y = quaternion.y;
			to.z = quaternion.z;
			to.w = quaternion.w;
			DOGetter<Quaternion> getter = () => to;
			DOSetter<Quaternion> setter = delegate(Quaternion x)
			{
				Quaternion rotation = default(Quaternion);
				rotation.x = to.x;
				rotation.y = to.y;
				rotation.z = to.z;
				rotation.w = to.w;
				Quaternion quaternion2 = Quaternion.Inverse(rotation);
				Quaternion quaternion3 = x * quaternion2;
				to = x;
				to.y = x.y;
				to.z = x.z;
				to.w = x.w;
				Quaternion localRotation = target.localRotation;
				Quaternion quaternion4 = Quaternion.Inverse(localRotation);
				Quaternion quaternion5 = localRotation * quaternion4;
				Quaternion quaternion6 = quaternion5 * quaternion3;
				Quaternion localRotation2 = quaternion6 * localRotation;
				target.localRotation = localRotation2;
			};
			TweenerCore<Quaternion, Vector3, QuaternionOptions> t = DOTween.To(getter, setter, byValue, duration);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> t2 = t.Blendable();
			return t2.SetTarget(target);
		}

		[Token(Token = "0x60000E7")]
		[Address(RVA = "0x10EAED8", Offset = "0x10EAED8", Length = "0x22C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv44 = *([1EBCDE0]);\n\tv45 = *([v44 @ X8_v40]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, vibrato, methodInfo, v48, v49, v50, v51, v52, punch, v0, v2, duration, elasticity, v53, v54, v55);\n\tv58 = 0 | 1;\n\t*([202754A]) = v58;\nL_0025:\n\tv62 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass74_0();\n\tDG.Tweening.ShortcutExtensions+<>c__DisplayClass74_0::.ctor(v62);\n\tv66 = duration < 0;\n\tv67 = ~v66;\n\tv70 = duration == 0;\n\tv62.target = target;\n\tv75 = ~v67;\n\tv76 = v75 | v70;\n\tif (v76) goto L_008B;\n\tgoto L_0045;\n\tv89 = *([v81 @ X0_v15+E0]);\n\tv90 = v89 == 0;\n\tv91 = ~v90;\n\tif (v91) goto L_0045;\n\tv93 = \"il2cpp_codegen_runtime_class_init\"(v81, v63, methodInfo, v48, v49, v50, v51, v52, punch, v0, v2, duration, elasticity, v53, v54, v55);\nL_0045:\n\tv97 = UnityEngine.Vector3::get_zero();\n\tv62.to = v97;\n\tv62.to.y = v97.y;\n\tv62.to.z = v97.z;\n\tv189 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v189, v62, Il2CppMethodInfo);\n\tv218 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v218, v62, Il2CppMethodInfo);\n\treturnVal3 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v218, v62, Il2CppMethodInfo);\n\treturn returnVal3;\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0072;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0072;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0072:\n\tX0 = X21;\n\tX1 = X22;\n\tV0 = V12;\n\tV1 = V11;\n\tV2 = V10;\n\tV3 = V9;\n\tX2 = X19;\n\tV4 = V8;\n\tX3 = 0;\n\t// 123 MakeStruct AGG10EB03C_2, typeof(UnityEngine.Vector3), V0, V1, V2\n\tX0 = DG.Tweening.DOTween::Punch(X0, X1, AGG10EB03C_2, V3, X2, V4, X3);\n\tX8 = *([1ECF3B8]);\n\tX1 = *([X8]);\n\tX0 = DG.Tweening.Core.Extensions::Blendable /* +1 sharing this address */(X0, X1);\n\tX1 = *([X20+20]);\n\tX8 = *([1EB3980]);\n\tX2 = *([X8]);\n\tX0 = DG.Tweening.TweenSettingsExtensions::SetTarget /* +17 sharing this address */(X0, X1, X2);\n\tgoto L_00C1;\nL_008B:\n\tgoto L_00A1;\n\tv99 = *([1EFC598]);\n\tv100 = *([v99 @ X8_v21]);\n\tv101 = \"il2cpp_codegen_initialize_method\"(v100, v63, methodInfo, v48, v49, v50, v51, v52, punch, v0, v2, duration, elasticity, v53, v54, v55);\n\tv104 = 0 | 1;\n\t*([2022B9B]) = v104;\nL_00A1:\n\tv120 = v108._logPriority < 1;\n\tif (v120) goto L_00C1;\n\tgoto L_00B3;\n\tv208 = *([v192 @ X0_v9+E0]);\n\tv209 = v208 == 0;\n\tv210 = ~v209;\n\tif (v210) goto L_00B3;\n\tv212 = \"il2cpp_codegen_runtime_class_init\"(v192, v63, methodInfo, v48, v49, v50, v51, v52, punch, v0, v2, duration, elasticity, v53, v54, v55);\nL_00B3:\n\tUnityEngine.Debug::LogWarning(\"DOBlendablePunchRotation: duration can't be 0, returning NULL without creating a tween\");\nL_00C1:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 122 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOBlendablePunchRotation(this Transform target, Vector3 punch, float duration, int vibrato = 10, float elasticity = 1f)
		{
			bool flag = duration < 0f;
			bool flag2 = !flag;
			bool flag3 = duration == 0f;
			Transform target2 = target;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				Vector3 to;
				Vector3 vector = (to = Vector3.zero);
				to.y = vector.y;
				to.z = vector.z;
				DOGetter<Vector3> dOGetter = () => to;
				DOSetter<Vector3> dOSetter = delegate(Vector3 v)
				{
					Quaternion rotation = Quaternion.Euler(to.x, to.y, to.z);
					Vector3 vector2 = default(Vector3);
					Quaternion quaternion = Quaternion.Euler(vector2.x, v.y, v.z);
					Quaternion quaternion2 = Quaternion.Inverse(rotation);
					Quaternion quaternion3 = quaternion * quaternion2;
					to.x = vector2.x;
					to.y = v.y;
					to.z = v.z;
					Quaternion rotation2 = target2.rotation;
					Quaternion quaternion4 = Quaternion.Inverse(rotation2);
					Quaternion quaternion5 = rotation2 * quaternion4;
					Quaternion quaternion6 = quaternion5 * quaternion3;
					Quaternion rotation3 = quaternion6 * rotation2;
					target2.rotation = rotation3;
				};
				Tweener result = default(Tweener);
				return result;
			}
			if (Debugger._logPriority >= 1)
			{
				Debug.LogWarning("DOBlendablePunchRotation: duration can't be 0, returning NULL without creating a tween");
			}
			return null;
		}

		[Token(Token = "0x60000E8")]
		[Address(RVA = "0x10EB104", Offset = "0x10EB104", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv36 = *([1EE3318]);\n\tv37 = *([v36 @ X8_v29]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, methodInfo, v40, v41, v42, v43, v44, v45, byValue, v0, v2, duration, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([202754B]) = v52;\nL_0021:\n\tv56 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass75_0();\n\tDG.Tweening.ShortcutExtensions+<>c__DisplayClass75_0::.ctor(v56);\n\tv56.target = target;\n\tgoto L_0035;\n\tv68 = *([v62 @ X0_v6+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_0035;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v62, v57, v40, v41, v42, v43, v44, v45, byValue, v0, v2, duration, v46, v47, v48, v49);\nL_0035:\n\tv76 = UnityEngine.Vector3::get_zero();\n\tv56.to = v76;\n\tv56.to.y = v76.y;\n\tv56.to.z = v76.z;\n\tv82 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v82, v56, Il2CppMethodInfo);\n\tv138 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v138, v56, Il2CppMethodInfo);\n\tgoto L_0069;\n\tv151 = *([v147 @ X0_v13+E0]);\n\tv152 = v151 == 0;\n\tv153 = ~v152;\n\tif (v153) goto L_0069;\n\tv155 = \"il2cpp_codegen_runtime_class_init\"(v147, v142, v144, v93, v42, v43, v44, v45, v76, v77, v78, duration, v46, v47, v48, v49);\nL_0069:\n\tv160 = DG.Tweening.DOTween::To(v82, v138, byValue, duration);\n\tv164 = DG.Tweening.Core.Extensions::Blendable(v160);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v164, v56.target);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 94 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOBlendableScaleBy(this Transform target, Vector3 byValue, float duration)
		{
			Vector3 to;
			Vector3 vector = (to = Vector3.zero);
			to.y = vector.y;
			to.z = vector.z;
			DOGetter<Vector3> getter = () => to;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				Vector3 vector2 = default(Vector3);
				vector2.x = to.x;
				vector2.y = to.y;
				vector2.z = to.z;
				Vector3 vector3 = x - vector2;
				to = x;
				to.y = x.y;
				to.z = x.z;
				Vector3 localScale = target.localScale;
				Vector3 localScale2 = localScale + vector3;
				target.localScale = localScale2;
			};
			TweenerCore<Vector3, Vector3, VectorOptions> t = DOTween.To(getter, setter, byValue, duration);
			TweenerCore<Vector3, Vector3, VectorOptions> t2 = t.Blendable();
			return t2.SetTarget(target);
		}

		[Token(Token = "0x60000E9")]
		[Address(RVA = "0x10EB290", Offset = "0x10EB290", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EA3C50]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, withCallbacks, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202754C]) = v41;\nL_001B:\n\tgoto L_002A;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_002A;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, withCallbacks, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002A:\n\treturnVal1 = DG.Tweening.DOTween::Complete(target, withCallbacks);\n\treturn returnVal1;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOComplete(this Component target, bool withCallbacks = false)
		{
			return DOTween.Complete(target, withCallbacks);
		}

		[Token(Token = "0x60000EA")]
		[Address(RVA = "0x10EB308", Offset = "0x10EB308", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EFB718]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, withCallbacks, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202754D]) = v41;\nL_001B:\n\tgoto L_002A;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_002A;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, withCallbacks, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002A:\n\treturnVal1 = DG.Tweening.DOTween::Complete(target, withCallbacks);\n\treturn returnVal1;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOComplete(this Material target, bool withCallbacks = false)
		{
			return DOTween.Complete(target, withCallbacks);
		}

		[Token(Token = "0x60000EB")]
		[Address(RVA = "0x10EB380", Offset = "0x10EB380", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1ED27E0]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, complete, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202754E]) = v41;\nL_001B:\n\tgoto L_002A;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_002A;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, complete, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002A:\n\treturnVal1 = DG.Tweening.DOTween::Kill(target, complete);\n\treturn returnVal1;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOKill(this Component target, bool complete = false)
		{
			return DOTween.Kill(target, complete);
		}

		[Token(Token = "0x60000EC")]
		[Address(RVA = "0x10EB3F8", Offset = "0x10EB3F8", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EE50F8]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, complete, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202754F]) = v41;\nL_001B:\n\tgoto L_002A;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_002A;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, complete, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002A:\n\treturnVal1 = DG.Tweening.DOTween::Kill(target, complete);\n\treturn returnVal1;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOKill(this Material target, bool complete = false)
		{
			return DOTween.Kill(target, complete);
		}

		[Token(Token = "0x60000ED")]
		[Address(RVA = "0x10EB470", Offset = "0x10EB470", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F0FA60]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2027550]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = DG.Tweening.DOTween::Flip(target);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOFlip(this Component target)
		{
			return DOTween.Flip(target);
		}

		[Token(Token = "0x60000EE")]
		[Address(RVA = "0x10EB4D8", Offset = "0x10EB4D8", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC20D0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2027551]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = DG.Tweening.DOTween::Flip(target);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOFlip(this Material target)
		{
			return DOTween.Flip(target);
		}

		[Token(Token = "0x60000EF")]
		[Address(RVA = "0x10EB540", Offset = "0x10EB540", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1ECE008]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, andPlay, methodInfo, v30, v31, v32, v33, v34, to, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2027552]) = v44;\nL_001D:\n\tgoto L_002E;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002E;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, andPlay, methodInfo, v30, v31, v32, v33, v34, to, v35, v36, v37, v38, v39, v40, v41);\nL_002E:\n\treturnVal1 = DG.Tweening.DOTween::Goto(target, to, andPlay);\n\treturn returnVal1;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOGoto(this Component target, float to, bool andPlay = false)
		{
			return DOTween.Goto(target, to, andPlay);
		}

		[Token(Token = "0x60000F0")]
		[Address(RVA = "0x10EB5C8", Offset = "0x10EB5C8", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EA8838]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, andPlay, methodInfo, v30, v31, v32, v33, v34, to, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2027553]) = v44;\nL_001D:\n\tgoto L_002E;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002E;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, andPlay, methodInfo, v30, v31, v32, v33, v34, to, v35, v36, v37, v38, v39, v40, v41);\nL_002E:\n\treturnVal1 = DG.Tweening.DOTween::Goto(target, to, andPlay);\n\treturn returnVal1;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOGoto(this Material target, float to, bool andPlay = false)
		{
			return DOTween.Goto(target, to, andPlay);
		}

		[Token(Token = "0x60000F1")]
		[Address(RVA = "0x10EB650", Offset = "0x10EB650", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB9AE8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2027554]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = DG.Tweening.DOTween::Pause(target);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOPause(this Component target)
		{
			return DOTween.Pause(target);
		}

		[Token(Token = "0x60000F2")]
		[Address(RVA = "0x10EB6B8", Offset = "0x10EB6B8", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE8C48]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2027555]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = DG.Tweening.DOTween::Pause(target);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOPause(this Material target)
		{
			return DOTween.Pause(target);
		}

		[Token(Token = "0x60000F3")]
		[Address(RVA = "0x10EB720", Offset = "0x10EB720", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EA6D30]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2027556]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = DG.Tweening.DOTween::Play(target);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOPlay(this Component target)
		{
			return DOTween.Play(target);
		}

		[Token(Token = "0x60000F4")]
		[Address(RVA = "0x10EB788", Offset = "0x10EB788", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F086F8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2027557]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = DG.Tweening.DOTween::Play(target);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOPlay(this Material target)
		{
			return DOTween.Play(target);
		}

		[Token(Token = "0x60000F5")]
		[Address(RVA = "0x10EB7F0", Offset = "0x10EB7F0", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE0650]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2027558]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = DG.Tweening.DOTween::PlayBackwards(target);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOPlayBackwards(this Component target)
		{
			return DOTween.PlayBackwards(target);
		}

		[Token(Token = "0x60000F6")]
		[Address(RVA = "0x10EB858", Offset = "0x10EB858", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB77B8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2027559]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = DG.Tweening.DOTween::PlayBackwards(target);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOPlayBackwards(this Material target)
		{
			return DOTween.PlayBackwards(target);
		}

		[Token(Token = "0x60000F7")]
		[Address(RVA = "0x10EB8C0", Offset = "0x10EB8C0", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EFC1A8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202755A]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = DG.Tweening.DOTween::PlayForward(target);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOPlayForward(this Component target)
		{
			return DOTween.PlayForward(target);
		}

		[Token(Token = "0x60000F8")]
		[Address(RVA = "0x10EB928", Offset = "0x10EB928", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED1428]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202755B]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = DG.Tweening.DOTween::PlayForward(target);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOPlayForward(this Material target)
		{
			return DOTween.PlayForward(target);
		}

		[Token(Token = "0x60000F9")]
		[Address(RVA = "0x10EB990", Offset = "0x10EB990", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EC7CF8]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, includeDelay, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202755C]) = v41;\nL_001B:\n\tgoto L_002B;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_002B;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, includeDelay, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002B:\n\treturnVal1 = DG.Tweening.DOTween::Restart(target, includeDelay, -1f);\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DORestart(this Component target, bool includeDelay = true)
		{
			return DOTween.Restart(target, includeDelay);
		}

		[Token(Token = "0x60000FA")]
		[Address(RVA = "0x10EBA0C", Offset = "0x10EBA0C", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1ECEBB8]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, includeDelay, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202755D]) = v41;\nL_001B:\n\tgoto L_002B;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_002B;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, includeDelay, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002B:\n\treturnVal1 = DG.Tweening.DOTween::Restart(target, includeDelay, -1f);\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DORestart(this Material target, bool includeDelay = true)
		{
			return DOTween.Restart(target, includeDelay);
		}

		[Token(Token = "0x60000FB")]
		[Address(RVA = "0x10EBA88", Offset = "0x10EBA88", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EBB8F0]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, includeDelay, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202755E]) = v41;\nL_001B:\n\tgoto L_002A;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_002A;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, includeDelay, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002A:\n\treturnVal1 = DG.Tweening.DOTween::Rewind(target, includeDelay);\n\treturn returnVal1;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DORewind(this Component target, bool includeDelay = true)
		{
			return DOTween.Rewind(target, includeDelay);
		}

		[Token(Token = "0x60000FC")]
		[Address(RVA = "0x10EBB00", Offset = "0x10EBB00", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EAAE90]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, includeDelay, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202755F]) = v41;\nL_001B:\n\tgoto L_002A;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_002A;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, includeDelay, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002A:\n\treturnVal1 = DG.Tweening.DOTween::Rewind(target, includeDelay);\n\treturn returnVal1;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DORewind(this Material target, bool includeDelay = true)
		{
			return DOTween.Rewind(target, includeDelay);
		}

		[Token(Token = "0x60000FD")]
		[Address(RVA = "0x10EBB78", Offset = "0x10EBB78", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC4EF8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2027560]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = DG.Tweening.DOTween::SmoothRewind(target);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOSmoothRewind(this Component target)
		{
			return DOTween.SmoothRewind(target);
		}

		[Token(Token = "0x60000FE")]
		[Address(RVA = "0x10EBBE0", Offset = "0x10EBBE0", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED8F80]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2027561]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = DG.Tweening.DOTween::SmoothRewind(target);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOSmoothRewind(this Material target)
		{
			return DOTween.SmoothRewind(target);
		}

		[Token(Token = "0x60000FF")]
		[Address(RVA = "0x10EBC48", Offset = "0x10EBC48", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE3E48]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2027562]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = DG.Tweening.DOTween::TogglePause(target);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOTogglePause(this Component target)
		{
			return DOTween.TogglePause(target);
		}

		[Token(Token = "0x6000100")]
		[Address(RVA = "0x10EBCB0", Offset = "0x10EBCB0", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC3090]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2027563]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = DG.Tweening.DOTween::TogglePause(target);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOTogglePause(this Material target)
		{
			return DOTween.TogglePause(target);
		}
	}
}
