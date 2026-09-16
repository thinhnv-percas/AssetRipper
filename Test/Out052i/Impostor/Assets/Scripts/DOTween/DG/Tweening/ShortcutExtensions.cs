using System;
using System.Runtime.CompilerServices;
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
	[Token(Token = "0x200001F")]
	public static class ShortcutExtensions
	{
		[CompilerGenerated]
		[Token(Token = "0x2000026")]
		private sealed class _003C_003Ec__DisplayClass15_0
		{
			[Token(Token = "0x4000094")]
			[FieldOffset(Offset = "0x10")]
			public Color2 startValue;

			[Token(Token = "0x4000095")]
			[FieldOffset(Offset = "0x30")]
			public LineRenderer target;

			[Token(Token = "0x600014C")]
			[Address(RVA = "0xC11760", Offset = "0xC11760", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec__DisplayClass15_0()
			{
			}

			internal unsafe Color2 _003CDOColor_003Eb__0()
			{
				//IL_000a: Expected native int or pointer, but got O
				//IL_001e: Expected native int or pointer, but got O
				Color2 color = default(Color2);
				((Color2*)(nint)color)->ca = (Color)startValue;
				((Color2*)(nint)color)->cb = startValue.cb;
				return (Color2)this;
			}

			internal void _003CDOColor_003Eb__1(Color2 x)
			{
				target.startColor = x.ca;
				target.endColor = x.cb;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000061")]
		private sealed class _003C_003Ec__DisplayClass70_0
		{
			[Token(Token = "0x40000E8")]
			[FieldOffset(Offset = "0x10")]
			public Color to;

			[Token(Token = "0x40000E9")]
			[FieldOffset(Offset = "0x20")]
			public Material target;

			[Token(Token = "0x40000EA")]
			[FieldOffset(Offset = "0x28")]
			public string property;

			[Token(Token = "0x6000209")]
			[Address(RVA = "0xC18094", Offset = "0xC18094", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec__DisplayClass70_0()
			{
			}

			internal Color _003CDOBlendableColor_003Eb__0()
			{
				return to;
			}

			internal void _003CDOBlendableColor_003Eb__1(Color x)
			{
				to = x;
				to.g = x.g;
				to.b = x.b;
				to.a = x.a;
				float num = x.a - to.a;
				float num2 = x.b - to.b;
				float num3 = x.g - to.g;
				Color color = default(Color);
				float num4 = color.r - to.r;
				Color color2 = target.GetColor(property);
				float b = num2 + color2.b;
				float a = num + color2.a;
				float r = num4 + color2.r;
				float g = num3 + color2.g;
				Color value = default(Color);
				value.r = r;
				value.g = g;
				value.b = b;
				value.a = a;
				target.SetColor(property, value);
			}
		}

		[Token(Token = "0x60000D4")]
		[Address(RVA = "0xC0FBD0", Offset = "0xC0FBD0", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv34 = DG.Tweening.Core.DOGetter`1<System.Single>;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv56 = DG.Tweening.Core.DOSetter`1<System.Single>;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv61 = DG.Tweening.DOTween;\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv65 = Il2CppMethodInfo;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv83 = Il2CppMethodInfo;\n\tv84 = \"il2cpp_codegen_initialize_runtime_metadata\"(v83, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv90 = Il2CppMethodInfo;\n\tv91 = \"il2cpp_codegen_initialize_runtime_metadata\"(v90, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv131 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass0_0;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v131, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv52 = 1;\n\t*([1A356E3]) = v52;\nL_002E:\n\tv54 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass0_0();\n\tSystem.Object::.ctor(v54);\n\tv54.target = target;\n\tv80 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v80, v54, Il2CppMethodInfo);\n\tv93 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v93, v54, Il2CppMethodInfo);\n\tgoto L_0059;\n\tv137 = \"il2cpp_codegen_runtime_class_init\"(v135, v133, v132, v101, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\nL_0059:\n\tv141 = DG.Tweening.DOTween::To(v80, v93, endValue, duration);\n\tv143 = DG.Tweening.TweenSettingsExtensions::SetTarget(v141, v54.target);\n\treturn v141;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000D5")]
		[Address(RVA = "0xC0FD40", Offset = "0xC0FD40", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0037;\n\tv46 = DG.Tweening.Core.DOGetter`1<UnityEngine.Color>;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv65 = DG.Tweening.Core.DOSetter`1<UnityEngine.Color>;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv70 = DG.Tweening.DOTween;\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv74 = Il2CppMethodInfo;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv92 = Il2CppMethodInfo;\n\tv93 = \"il2cpp_codegen_initialize_runtime_metadata\"(v92, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv99 = Il2CppMethodInfo;\n\tv100 = \"il2cpp_codegen_initialize_runtime_metadata\"(v99, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv155 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass1_0;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v155, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv61 = 1;\n\t*([1A356E4]) = v61;\nL_0037:\n\tv63 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass1_0();\n\tSystem.Object::.ctor(v63);\n\tv63.target = target;\n\tv89 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v89, v63, Il2CppMethodInfo);\n\tv102 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v102, v63, Il2CppMethodInfo);\n\tgoto L_0066;\n\tv161 = \"il2cpp_codegen_runtime_class_init\"(v159, v157, v156, v113, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\nL_0066:\n\tv165 = DG.Tweening.DOTween::To(v89, v102, endValue, duration);\n\tv167 = DG.Tweening.TweenSettingsExtensions::SetTarget(v165, v63.target);\n\treturn v165;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 94 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Color, Color, ColorOptions> DOColor(this Camera target, Color endValue, float duration)
		{
			DOGetter<Color> getter = () => target.backgroundColor;
			DOSetter<Color> setter = delegate(Color x)
			{
				target.backgroundColor = x;
			};
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<Color, Color, ColorOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x60000D6")]
		[Address(RVA = "0xC0FED8", Offset = "0xC0FED8", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv34 = DG.Tweening.Core.DOGetter`1<System.Single>;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv56 = DG.Tweening.Core.DOSetter`1<System.Single>;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv61 = DG.Tweening.DOTween;\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv65 = Il2CppMethodInfo;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv83 = Il2CppMethodInfo;\n\tv84 = \"il2cpp_codegen_initialize_runtime_metadata\"(v83, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv90 = Il2CppMethodInfo;\n\tv91 = \"il2cpp_codegen_initialize_runtime_metadata\"(v90, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv131 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass2_0;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v131, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv52 = 1;\n\t*([1A356E5]) = v52;\nL_002E:\n\tv54 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass2_0();\n\tSystem.Object::.ctor(v54);\n\tv54.target = target;\n\tv80 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v80, v54, Il2CppMethodInfo);\n\tv93 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v93, v54, Il2CppMethodInfo);\n\tgoto L_0059;\n\tv137 = \"il2cpp_codegen_runtime_class_init\"(v135, v133, v132, v101, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\nL_0059:\n\tv141 = DG.Tweening.DOTween::To(v80, v93, endValue, duration);\n\tv143 = DG.Tweening.TweenSettingsExtensions::SetTarget(v141, v54.target);\n\treturn v141;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000D7")]
		[Address(RVA = "0xC10048", Offset = "0xC10048", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv34 = DG.Tweening.Core.DOGetter`1<System.Single>;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv56 = DG.Tweening.Core.DOSetter`1<System.Single>;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv61 = DG.Tweening.DOTween;\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv65 = Il2CppMethodInfo;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv83 = Il2CppMethodInfo;\n\tv84 = \"il2cpp_codegen_initialize_runtime_metadata\"(v83, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv90 = Il2CppMethodInfo;\n\tv91 = \"il2cpp_codegen_initialize_runtime_metadata\"(v90, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv131 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass3_0;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v131, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv52 = 1;\n\t*([1A356E6]) = v52;\nL_002E:\n\tv54 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass3_0();\n\tSystem.Object::.ctor(v54);\n\tv54.target = target;\n\tv80 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v80, v54, Il2CppMethodInfo);\n\tv93 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v93, v54, Il2CppMethodInfo);\n\tgoto L_0059;\n\tv137 = \"il2cpp_codegen_runtime_class_init\"(v135, v133, v132, v101, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\nL_0059:\n\tv141 = DG.Tweening.DOTween::To(v80, v93, endValue, duration);\n\tv143 = DG.Tweening.TweenSettingsExtensions::SetTarget(v141, v54.target);\n\treturn v141;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000D8")]
		[Address(RVA = "0xC101B8", Offset = "0xC101B8", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv34 = DG.Tweening.Core.DOGetter`1<System.Single>;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv56 = DG.Tweening.Core.DOSetter`1<System.Single>;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv61 = DG.Tweening.DOTween;\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv65 = Il2CppMethodInfo;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv83 = Il2CppMethodInfo;\n\tv84 = \"il2cpp_codegen_initialize_runtime_metadata\"(v83, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv90 = Il2CppMethodInfo;\n\tv91 = \"il2cpp_codegen_initialize_runtime_metadata\"(v90, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv131 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass4_0;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v131, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv52 = 1;\n\t*([1A356E7]) = v52;\nL_002E:\n\tv54 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass4_0();\n\tSystem.Object::.ctor(v54);\n\tv54.target = target;\n\tv80 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v80, v54, Il2CppMethodInfo);\n\tv93 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v93, v54, Il2CppMethodInfo);\n\tgoto L_0059;\n\tv137 = \"il2cpp_codegen_runtime_class_init\"(v135, v133, v132, v101, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\nL_0059:\n\tv141 = DG.Tweening.DOTween::To(v80, v93, endValue, duration);\n\tv143 = DG.Tweening.TweenSettingsExtensions::SetTarget(v141, v54.target);\n\treturn v141;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000D9")]
		[Address(RVA = "0xC10328", Offset = "0xC10328", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv34 = DG.Tweening.Core.DOGetter`1<System.Single>;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv56 = DG.Tweening.Core.DOSetter`1<System.Single>;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv61 = DG.Tweening.DOTween;\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv65 = Il2CppMethodInfo;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv83 = Il2CppMethodInfo;\n\tv84 = \"il2cpp_codegen_initialize_runtime_metadata\"(v83, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv90 = Il2CppMethodInfo;\n\tv91 = \"il2cpp_codegen_initialize_runtime_metadata\"(v90, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv131 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass5_0;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v131, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv52 = 1;\n\t*([1A356E8]) = v52;\nL_002E:\n\tv54 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass5_0();\n\tSystem.Object::.ctor(v54);\n\tv54.target = target;\n\tv80 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v80, v54, Il2CppMethodInfo);\n\tv93 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v93, v54, Il2CppMethodInfo);\n\tgoto L_0059;\n\tv137 = \"il2cpp_codegen_runtime_class_init\"(v135, v133, v132, v101, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\nL_0059:\n\tv141 = DG.Tweening.DOTween::To(v80, v93, endValue, duration);\n\tv143 = DG.Tweening.TweenSettingsExtensions::SetTarget(v141, v54.target);\n\treturn v141;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000DA")]
		[Address(RVA = "0xC10498", Offset = "0xC10498", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0037;\n\tv46 = DG.Tweening.Core.DOGetter`1<UnityEngine.Rect>;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv65 = DG.Tweening.Core.DOSetter`1<UnityEngine.Rect>;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv70 = DG.Tweening.DOTween;\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv74 = Il2CppMethodInfo;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv92 = Il2CppMethodInfo;\n\tv93 = \"il2cpp_codegen_initialize_runtime_metadata\"(v92, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv99 = Il2CppMethodInfo;\n\tv100 = \"il2cpp_codegen_initialize_runtime_metadata\"(v99, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv155 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass6_0;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v155, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv61 = 1;\n\t*([1A356E9]) = v61;\nL_0037:\n\tv63 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass6_0();\n\tSystem.Object::.ctor(v63);\n\tv63.target = target;\n\tv89 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Rect>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Rect>::.ctor(v89, v63, Il2CppMethodInfo);\n\tv102 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Rect>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Rect>::.ctor(v102, v63, Il2CppMethodInfo);\n\tgoto L_0066;\n\tv161 = \"il2cpp_codegen_runtime_class_init\"(v159, v157, v156, v113, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\nL_0066:\n\tv165 = DG.Tweening.DOTween::To(v89, v102, endValue, duration);\n\tv167 = DG.Tweening.TweenSettingsExtensions::SetTarget(v165, v63.target);\n\treturn v165;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 94 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000DB")]
		[Address(RVA = "0xC10630", Offset = "0xC10630", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0037;\n\tv46 = DG.Tweening.Core.DOGetter`1<UnityEngine.Rect>;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv65 = DG.Tweening.Core.DOSetter`1<UnityEngine.Rect>;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv70 = DG.Tweening.DOTween;\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv74 = Il2CppMethodInfo;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv92 = Il2CppMethodInfo;\n\tv93 = \"il2cpp_codegen_initialize_runtime_metadata\"(v92, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv99 = Il2CppMethodInfo;\n\tv100 = \"il2cpp_codegen_initialize_runtime_metadata\"(v99, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv155 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass7_0;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v155, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv61 = 1;\n\t*([1A356EA]) = v61;\nL_0037:\n\tv63 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass7_0();\n\tSystem.Object::.ctor(v63);\n\tv63.target = target;\n\tv89 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Rect>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Rect>::.ctor(v89, v63, Il2CppMethodInfo);\n\tv102 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Rect>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Rect>::.ctor(v102, v63, Il2CppMethodInfo);\n\tgoto L_0066;\n\tv161 = \"il2cpp_codegen_runtime_class_init\"(v159, v157, v156, v113, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\nL_0066:\n\tv165 = DG.Tweening.DOTween::To(v89, v102, endValue, duration);\n\tv167 = DG.Tweening.TweenSettingsExtensions::SetTarget(v165, v63.target);\n\treturn v165;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 94 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000DC")]
		[Address(RVA = "0xC107C8", Offset = "0xC107C8", Length = "0x250")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003B;\n\tv42 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv60 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv65 = DG.Tweening.DOTween;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv69 = UnityEngine.Debug;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv84 = Il2CppMethodInfo;\n\tv85 = \"il2cpp_codegen_initialize_runtime_metadata\"(v84, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv95 = Il2CppMethodInfo;\n\tv96 = \"il2cpp_codegen_initialize_runtime_metadata\"(v95, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv200 = Il2CppMethodInfo;\n\tv201 = \"il2cpp_codegen_initialize_runtime_metadata\"(v200, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv217 = Il2CppMethodInfo;\n\tv218 = \"il2cpp_codegen_initialize_runtime_metadata\"(v217, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv229 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass8_0;\n\tv230 = \"il2cpp_codegen_initialize_runtime_metadata\"(v229, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv237 = \"DOShakePosition: duration can't be 0, returning NULL without creating a tween\";\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v237, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv56 = 1;\n\t*([1A356EB]) = v56;\nL_003B:\n\tv58 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass8_0();\n\tSystem.Object::.ctor(v58);\n\tv71 = duration < 0;\n\tv72 = ~v71;\n\tv75 = duration == 0;\n\tv58.target = target;\n\tv80 = ~v72;\n\tv81 = v80 | v75;\n\tif (v81) goto L_0090;\n\tv89 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v89, v58, Il2CppMethodInfo);\n\tv205 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v205, v58, Il2CppMethodInfo);\n\tgoto L_0075;\n\tv238 = \"il2cpp_codegen_runtime_class_init\"(v233, v221, v224, v222, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\nL_0075:\n\tv243 = DG.Tweening.DOTween::Shake(v89, v205, duration, strength, vibrato, randomness, 1, fadeOut, randomnessMode);\n\tv248 = DG.Tweening.TweenSettingsExtensions::SetTarget(v243, v58.target);\n\treturnVal3 = DG.Tweening.Core.Extensions::SetSpecialStartupMode(v248, 4);\n\treturn returnVal3;\nL_0090:\n\tgoto L_00A5;\n\tv104 = DG.Tweening.Core.Debugger;\n\tv105 = \"il2cpp_codegen_initialize_runtime_metadata\"(v104, v62, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv108 = 1;\n\t*([1A35757]) = v108;\nL_00A5:\n\tv124 = v112._logPriority < 1;\n\tif (v124) goto L_00C0;\n\tgoto L_00B3;\n\tv225 = \"il2cpp_codegen_runtime_class_init\"(v208, v62, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\nL_00B3:\n\tUnityEngine.Debug::LogWarning(\"DOShakePosition: duration can't be 0, returning NULL without creating a tween\");\nL_00C0:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 140 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOShakePosition(this Camera target, float duration, float strength = 3f, int vibrato = 10, float randomness = 90f, bool fadeOut = true, ShakeRandomnessMode randomnessMode = ShakeRandomnessMode.Full)
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
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = DOTween.Shake(getter, setter, duration, strength, vibrato, randomness, ignoreZAxis: true, fadeOut, randomnessMode);
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t2 = t.SetTarget(target2);
				return t2.SetSpecialStartupMode(SpecialStartupMode.SetCameraShakePosition);
			}
			if (Debugger._logPriority >= 1)
			{
				Debug.LogWarning("DOShakePosition: duration can't be 0, returning NULL without creating a tween");
			}
			return null;
		}

		[Token(Token = "0x60000DD")]
		[Address(RVA = "0xC10A20", Offset = "0xC10A20", Length = "0x268")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0041;\n\tv50 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv66 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv71 = DG.Tweening.DOTween;\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv75 = UnityEngine.Debug;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv90 = Il2CppMethodInfo;\n\tv91 = \"il2cpp_codegen_initialize_runtime_metadata\"(v90, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv101 = Il2CppMethodInfo;\n\tv102 = \"il2cpp_codegen_initialize_runtime_metadata\"(v101, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv217 = Il2CppMethodInfo;\n\tv218 = \"il2cpp_codegen_initialize_runtime_metadata\"(v217, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv234 = Il2CppMethodInfo;\n\tv235 = \"il2cpp_codegen_initialize_runtime_metadata\"(v234, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv246 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass9_0;\n\tv247 = \"il2cpp_codegen_initialize_runtime_metadata\"(v246, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv254 = \"DOShakePosition: duration can't be 0, returning NULL without creating a tween\";\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v254, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv62 = 1;\n\t*([1A356EC]) = v62;\nL_0041:\n\tv64 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass9_0();\n\tSystem.Object::.ctor(v64);\n\tv77 = duration < 0;\n\tv78 = ~v77;\n\tv81 = duration == 0;\n\tv64.target = target;\n\tv86 = ~v78;\n\tv87 = v86 | v81;\n\tif (v87) goto L_009A;\n\tv95 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v95, v64, Il2CppMethodInfo);\n\tv222 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v222, v64, Il2CppMethodInfo);\n\tgoto L_007D;\n\tv255 = \"il2cpp_codegen_runtime_class_init\"(v250, v238, v241, v239, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\nL_007D:\n\tv260 = DG.Tweening.DOTween::Shake(v95, v222, duration, strength, vibrato, randomness, fadeOut, randomnessMode);\n\tv265 = DG.Tweening.TweenSettingsExtensions::SetTarget(v260, v64.target);\n\treturnVal3 = DG.Tweening.Core.Extensions::SetSpecialStartupMode(v265, 4);\n\treturn returnVal3;\nL_009A:\n\tgoto L_00AF;\n\tv110 = DG.Tweening.Core.Debugger;\n\tv111 = \"il2cpp_codegen_initialize_runtime_metadata\"(v110, v68, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv114 = 1;\n\t*([1A35757]) = v114;\nL_00AF:\n\tv130 = v118._logPriority < 1;\n\tif (v130) goto L_00CC;\n\tgoto L_00BD;\n\tv242 = \"il2cpp_codegen_runtime_class_init\"(v225, v68, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\nL_00BD:\n\tUnityEngine.Debug::LogWarning(\"DOShakePosition: duration can't be 0, returning NULL without creating a tween\");\nL_00CC:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 152 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOShakePosition(this Camera target, float duration, Vector3 strength, int vibrato = 10, float randomness = 90f, bool fadeOut = true, ShakeRandomnessMode randomnessMode = ShakeRandomnessMode.Full)
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
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = DOTween.Shake(getter, setter, duration, strength, vibrato, randomness, fadeOut, randomnessMode);
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t2 = t.SetTarget(target2);
				return t2.SetSpecialStartupMode(SpecialStartupMode.SetCameraShakePosition);
			}
			if (Debugger._logPriority >= 1)
			{
				Debug.LogWarning("DOShakePosition: duration can't be 0, returning NULL without creating a tween");
			}
			return null;
		}

		[Token(Token = "0x60000DE")]
		[Address(RVA = "0xC10C90", Offset = "0xC10C90", Length = "0x250")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003B;\n\tv42 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv60 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv65 = DG.Tweening.DOTween;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv69 = UnityEngine.Debug;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv84 = Il2CppMethodInfo;\n\tv85 = \"il2cpp_codegen_initialize_runtime_metadata\"(v84, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv95 = Il2CppMethodInfo;\n\tv96 = \"il2cpp_codegen_initialize_runtime_metadata\"(v95, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv200 = Il2CppMethodInfo;\n\tv201 = \"il2cpp_codegen_initialize_runtime_metadata\"(v200, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv217 = Il2CppMethodInfo;\n\tv218 = \"il2cpp_codegen_initialize_runtime_metadata\"(v217, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv229 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass10_0;\n\tv230 = \"il2cpp_codegen_initialize_runtime_metadata\"(v229, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv237 = \"DOShakeRotation: duration can't be 0, returning NULL without creating a tween\";\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v237, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv56 = 1;\n\t*([1A356ED]) = v56;\nL_003B:\n\tv58 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass10_0();\n\tSystem.Object::.ctor(v58);\n\tv71 = duration < 0;\n\tv72 = ~v71;\n\tv75 = duration == 0;\n\tv58.target = target;\n\tv80 = ~v72;\n\tv81 = v80 | v75;\n\tif (v81) goto L_0090;\n\tv89 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v89, v58, Il2CppMethodInfo);\n\tv205 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v205, v58, Il2CppMethodInfo);\n\tgoto L_0075;\n\tv238 = \"il2cpp_codegen_runtime_class_init\"(v233, v221, v224, v222, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\nL_0075:\n\tv243 = DG.Tweening.DOTween::Shake(v89, v205, duration, strength, vibrato, randomness, 0, fadeOut, randomnessMode);\n\tv248 = DG.Tweening.TweenSettingsExtensions::SetTarget(v243, v58.target);\n\treturnVal3 = DG.Tweening.Core.Extensions::SetSpecialStartupMode(v248, 2);\n\treturn returnVal3;\nL_0090:\n\tgoto L_00A5;\n\tv104 = DG.Tweening.Core.Debugger;\n\tv105 = \"il2cpp_codegen_initialize_runtime_metadata\"(v104, v62, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv108 = 1;\n\t*([1A35757]) = v108;\nL_00A5:\n\tv124 = v112._logPriority < 1;\n\tif (v124) goto L_00C0;\n\tgoto L_00B3;\n\tv225 = \"il2cpp_codegen_runtime_class_init\"(v208, v62, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\nL_00B3:\n\tUnityEngine.Debug::LogWarning(\"DOShakeRotation: duration can't be 0, returning NULL without creating a tween\");\nL_00C0:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 140 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOShakeRotation(this Camera target, float duration, float strength = 90f, int vibrato = 10, float randomness = 90f, bool fadeOut = true, ShakeRandomnessMode randomnessMode = ShakeRandomnessMode.Full)
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
					Vector3 vector = default(Vector3);
					float x2 = vector.x * ((float)Math.PI / 180f);
					float y = x.y * ((float)Math.PI / 180f);
					float z = x.z * ((float)Math.PI / 180f);
					Vector3 vector2 = default(Vector3);
					vector2.x = x2;
					vector2.y = y;
					vector2.z = z;
					Quaternion localRotation = Quaternion.Euler(vector2 * 57.29578f);
					transform.localRotation = localRotation;
				};
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = DOTween.Shake(getter, setter, duration, strength, vibrato, randomness, ignoreZAxis: false, fadeOut, randomnessMode);
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t2 = t.SetTarget(target2);
				return t2.SetSpecialStartupMode(SpecialStartupMode.SetShake);
			}
			if (Debugger._logPriority >= 1)
			{
				Debug.LogWarning("DOShakeRotation: duration can't be 0, returning NULL without creating a tween");
			}
			return null;
		}

		[Token(Token = "0x60000DF")]
		[Address(RVA = "0xC10EE8", Offset = "0xC10EE8", Length = "0x268")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0041;\n\tv50 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv66 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv71 = DG.Tweening.DOTween;\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv75 = UnityEngine.Debug;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv90 = Il2CppMethodInfo;\n\tv91 = \"il2cpp_codegen_initialize_runtime_metadata\"(v90, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv101 = Il2CppMethodInfo;\n\tv102 = \"il2cpp_codegen_initialize_runtime_metadata\"(v101, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv217 = Il2CppMethodInfo;\n\tv218 = \"il2cpp_codegen_initialize_runtime_metadata\"(v217, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv234 = Il2CppMethodInfo;\n\tv235 = \"il2cpp_codegen_initialize_runtime_metadata\"(v234, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv246 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass11_0;\n\tv247 = \"il2cpp_codegen_initialize_runtime_metadata\"(v246, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv254 = \"DOShakeRotation: duration can't be 0, returning NULL without creating a tween\";\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v254, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv62 = 1;\n\t*([1A356EE]) = v62;\nL_0041:\n\tv64 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass11_0();\n\tSystem.Object::.ctor(v64);\n\tv77 = duration < 0;\n\tv78 = ~v77;\n\tv81 = duration == 0;\n\tv64.target = target;\n\tv86 = ~v78;\n\tv87 = v86 | v81;\n\tif (v87) goto L_009A;\n\tv95 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v95, v64, Il2CppMethodInfo);\n\tv222 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v222, v64, Il2CppMethodInfo);\n\tgoto L_007D;\n\tv255 = \"il2cpp_codegen_runtime_class_init\"(v250, v238, v241, v239, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\nL_007D:\n\tv260 = DG.Tweening.DOTween::Shake(v95, v222, duration, strength, vibrato, randomness, fadeOut, randomnessMode);\n\tv265 = DG.Tweening.TweenSettingsExtensions::SetTarget(v260, v64.target);\n\treturnVal3 = DG.Tweening.Core.Extensions::SetSpecialStartupMode(v265, 2);\n\treturn returnVal3;\nL_009A:\n\tgoto L_00AF;\n\tv110 = DG.Tweening.Core.Debugger;\n\tv111 = \"il2cpp_codegen_initialize_runtime_metadata\"(v110, v68, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv114 = 1;\n\t*([1A35757]) = v114;\nL_00AF:\n\tv130 = v118._logPriority < 1;\n\tif (v130) goto L_00CC;\n\tgoto L_00BD;\n\tv242 = \"il2cpp_codegen_runtime_class_init\"(v225, v68, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\nL_00BD:\n\tUnityEngine.Debug::LogWarning(\"DOShakeRotation: duration can't be 0, returning NULL without creating a tween\");\nL_00CC:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 152 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOShakeRotation(this Camera target, float duration, Vector3 strength, int vibrato = 10, float randomness = 90f, bool fadeOut = true, ShakeRandomnessMode randomnessMode = ShakeRandomnessMode.Full)
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
					Vector3 vector = default(Vector3);
					float x2 = vector.x * ((float)Math.PI / 180f);
					float y = x.y * ((float)Math.PI / 180f);
					float z = x.z * ((float)Math.PI / 180f);
					Vector3 vector2 = default(Vector3);
					vector2.x = x2;
					vector2.y = y;
					vector2.z = z;
					Quaternion localRotation = Quaternion.Euler(vector2 * 57.29578f);
					transform.localRotation = localRotation;
				};
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = DOTween.Shake(getter, setter, duration, strength, vibrato, randomness, fadeOut, randomnessMode);
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t2 = t.SetTarget(target2);
				return t2.SetSpecialStartupMode(SpecialStartupMode.SetShake);
			}
			if (Debugger._logPriority >= 1)
			{
				Debug.LogWarning("DOShakeRotation: duration can't be 0, returning NULL without creating a tween");
			}
			return null;
		}

		[Token(Token = "0x60000E0")]
		[Address(RVA = "0xC11158", Offset = "0xC11158", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0037;\n\tv46 = DG.Tweening.Core.DOGetter`1<UnityEngine.Color>;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv65 = DG.Tweening.Core.DOSetter`1<UnityEngine.Color>;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv70 = DG.Tweening.DOTween;\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv74 = Il2CppMethodInfo;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv92 = Il2CppMethodInfo;\n\tv93 = \"il2cpp_codegen_initialize_runtime_metadata\"(v92, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv99 = Il2CppMethodInfo;\n\tv100 = \"il2cpp_codegen_initialize_runtime_metadata\"(v99, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv155 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass12_0;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v155, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv61 = 1;\n\t*([1A356EF]) = v61;\nL_0037:\n\tv63 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass12_0();\n\tSystem.Object::.ctor(v63);\n\tv63.target = target;\n\tv89 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v89, v63, Il2CppMethodInfo);\n\tv102 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v102, v63, Il2CppMethodInfo);\n\tgoto L_0066;\n\tv161 = \"il2cpp_codegen_runtime_class_init\"(v159, v157, v156, v113, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\nL_0066:\n\tv165 = DG.Tweening.DOTween::To(v89, v102, endValue, duration);\n\tv167 = DG.Tweening.TweenSettingsExtensions::SetTarget(v165, v63.target);\n\treturn v165;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 94 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000E1")]
		[Address(RVA = "0xC112F0", Offset = "0xC112F0", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv34 = DG.Tweening.Core.DOGetter`1<System.Single>;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv56 = DG.Tweening.Core.DOSetter`1<System.Single>;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv61 = DG.Tweening.DOTween;\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv65 = Il2CppMethodInfo;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv83 = Il2CppMethodInfo;\n\tv84 = \"il2cpp_codegen_initialize_runtime_metadata\"(v83, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv90 = Il2CppMethodInfo;\n\tv91 = \"il2cpp_codegen_initialize_runtime_metadata\"(v90, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv131 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass13_0;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v131, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv52 = 1;\n\t*([1A356F0]) = v52;\nL_002E:\n\tv54 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass13_0();\n\tSystem.Object::.ctor(v54);\n\tv54.target = target;\n\tv80 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v80, v54, Il2CppMethodInfo);\n\tv93 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v93, v54, Il2CppMethodInfo);\n\tgoto L_0059;\n\tv137 = \"il2cpp_codegen_runtime_class_init\"(v135, v133, v132, v101, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\nL_0059:\n\tv141 = DG.Tweening.DOTween::To(v80, v93, endValue, duration);\n\tv143 = DG.Tweening.TweenSettingsExtensions::SetTarget(v141, v54.target);\n\treturn v141;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000E2")]
		[Address(RVA = "0xC11460", Offset = "0xC11460", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv34 = DG.Tweening.Core.DOGetter`1<System.Single>;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv56 = DG.Tweening.Core.DOSetter`1<System.Single>;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv61 = DG.Tweening.DOTween;\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv65 = Il2CppMethodInfo;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv83 = Il2CppMethodInfo;\n\tv84 = \"il2cpp_codegen_initialize_runtime_metadata\"(v83, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv90 = Il2CppMethodInfo;\n\tv91 = \"il2cpp_codegen_initialize_runtime_metadata\"(v90, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv131 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass14_0;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v131, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv52 = 1;\n\t*([1A356F1]) = v52;\nL_002E:\n\tv54 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass14_0();\n\tSystem.Object::.ctor(v54);\n\tv54.target = target;\n\tv80 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v80, v54, Il2CppMethodInfo);\n\tv93 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v93, v54, Il2CppMethodInfo);\n\tgoto L_0059;\n\tv137 = \"il2cpp_codegen_runtime_class_init\"(v135, v133, v132, v101, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\nL_0059:\n\tv141 = DG.Tweening.DOTween::To(v80, v93, endValue, duration);\n\tv143 = DG.Tweening.TweenSettingsExtensions::SetTarget(v141, v54.target);\n\treturn v141;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000E3")]
		[Address(RVA = "0xC115D0", Offset = "0xC115D0", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv36 = DG.Tweening.Core.DOGetter`1<DG.Tweening.Color2>;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, startValue, endValue, methodInfo, v39, v40, v41, v42, duration, v43, v44, v45, v46, v47, v48, v49);\n\tv57 = DG.Tweening.Core.DOSetter`1<DG.Tweening.Color2>;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, startValue, endValue, methodInfo, v39, v40, v41, v42, duration, v43, v44, v45, v46, v47, v48, v49);\n\tv62 = DG.Tweening.DOTween;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, startValue, endValue, methodInfo, v39, v40, v41, v42, duration, v43, v44, v45, v46, v47, v48, v49);\n\tv70 = Il2CppMethodInfo;\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, startValue, endValue, methodInfo, v39, v40, v41, v42, duration, v43, v44, v45, v46, v47, v48, v49);\n\tv90 = Il2CppMethodInfo;\n\tv91 = \"il2cpp_codegen_initialize_runtime_metadata\"(v90, startValue, endValue, methodInfo, v39, v40, v41, v42, duration, v43, v44, v45, v46, v47, v48, v49);\n\tv97 = Il2CppMethodInfo;\n\tv98 = \"il2cpp_codegen_initialize_runtime_metadata\"(v97, startValue, endValue, methodInfo, v39, v40, v41, v42, duration, v43, v44, v45, v46, v47, v48, v49);\n\tv150 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass15_0;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v150, startValue, endValue, methodInfo, v39, v40, v41, v42, duration, v43, v44, v45, v46, v47, v48, v49);\n\tv53 = 1;\n\t*([1A356F2]) = v53;\nL_002F:\n\tv55 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass15_0();\n\tSystem.Object::.ctor(v55);\n\tv64 = startValue.ca;\n\tv55.startValue = startValue.ca;\n\tv55.startValue.cb = startValue.cb;\n\tv55.target = target;\n\tv87 = new DG.Tweening.Core.DOGetter`1<DG.Tweening.Color2>();\n\tDG.Tweening.Core.DOGetter`1<DG.Tweening.Color2>::.ctor(v87, v55, Il2CppMethodInfo);\n\tv100 = new DG.Tweening.Core.DOSetter`1<DG.Tweening.Color2>();\n\tDG.Tweening.Core.DOSetter`1<DG.Tweening.Color2>::.ctor(v100, v55, Il2CppMethodInfo);\n\tv64 = endValue.ca;\n\tgoto L_006A;\n\tv158 = \"il2cpp_codegen_runtime_class_init\"(v156, v152, v151, v116, v39, v40, v41, v42, v155, v154, v44, v45, v46, v47, v48, v49);\nL_006A:\n\tv164 = DG.Tweening.DOTween::To(v87, v100, &v64 @ V1_v1 (UnityEngine.Color), duration);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v164, v55.target);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static Tweener DOColor(this LineRenderer target, Color2 startValue, Color2 endValue, float duration)
		{
			//IL_0094: Expected O, but got Ref
			_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass15_0();
			Color ca = startValue.ca;
			CS_0024_003C_003E8__locals9.startValue = (Color2)startValue.ca;
			CS_0024_003C_003E8__locals9.startValue.cb = startValue.cb;
			CS_0024_003C_003E8__locals9.target = target;
			DOGetter<Color2> getter = delegate
			{
				//IL_000a: Expected native int or pointer, but got O
				//IL_001e: Expected native int or pointer, but got O
				Color2 color = default(Color2);
				((Color2*)(nint)color)->ca = (Color)CS_0024_003C_003E8__locals9.startValue;
				((Color2*)(nint)color)->cb = CS_0024_003C_003E8__locals9.startValue.cb;
				return (Color2)CS_0024_003C_003E8__locals9;
			};
			DOSetter<Color2> setter = delegate(Color2 x)
			{
				CS_0024_003C_003E8__locals9.target.startColor = x.ca;
				CS_0024_003C_003E8__locals9.target.endColor = x.cb;
			};
			ca = endValue.ca;
			TweenerCore<Color2, Color2, ColorOptions> t = DOTween.To(getter, setter, (Color2)(&ca), duration);
			return t.SetTarget(CS_0024_003C_003E8__locals9.target);
		}

		[Token(Token = "0x60000E4")]
		[Address(RVA = "0xC11768", Offset = "0xC11768", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0037;\n\tv46 = DG.Tweening.Core.DOGetter`1<UnityEngine.Color>;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv65 = DG.Tweening.Core.DOSetter`1<UnityEngine.Color>;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv70 = DG.Tweening.DOTween;\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv74 = Il2CppMethodInfo;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv92 = Il2CppMethodInfo;\n\tv93 = \"il2cpp_codegen_initialize_runtime_metadata\"(v92, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv99 = Il2CppMethodInfo;\n\tv100 = \"il2cpp_codegen_initialize_runtime_metadata\"(v99, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv155 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass16_0;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v155, methodInfo, v49, v50, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\n\tv61 = 1;\n\t*([1A356F3]) = v61;\nL_0037:\n\tv63 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass16_0();\n\tSystem.Object::.ctor(v63);\n\tv63.target = target;\n\tv89 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v89, v63, Il2CppMethodInfo);\n\tv102 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v102, v63, Il2CppMethodInfo);\n\tgoto L_0066;\n\tv161 = \"il2cpp_codegen_runtime_class_init\"(v159, v157, v156, v113, v51, v52, v53, v54, endValue, v0, v2, v3, duration, v55, v56, v57);\nL_0066:\n\tv165 = DG.Tweening.DOTween::To(v89, v102, endValue, duration);\n\tv167 = DG.Tweening.TweenSettingsExtensions::SetTarget(v165, v63.target);\n\treturn v165;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 94 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000E5")]
		[Address(RVA = "0xC11900", Offset = "0xC11900", Length = "0x1F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tv42 = DG.Tweening.Core.DOGetter`1<UnityEngine.Color>;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, property, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv60 = DG.Tweening.Core.DOSetter`1<UnityEngine.Color>;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, property, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv65 = DG.Tweening.DOTween;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, property, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv69 = Il2CppMethodInfo;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, property, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv75 = Il2CppMethodInfo;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, property, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv82 = Il2CppMethodInfo;\n\tv83 = \"il2cpp_codegen_initialize_runtime_metadata\"(v82, property, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv159 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass17_0;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v159, property, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv56 = 1;\n\t*([1A356F4]) = v56;\nL_0035:\n\tv58 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass17_0();\n\tSystem.Object::.ctor(v58);\n\tv58.target = target;\n\tv58.property = property;\n\tv80 = UnityEngine.Material::HasProperty(target, property);\n\tv85 = v80 == 0;\n\tif (v85) goto L_0078;\n\tv163 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v163, v58, Il2CppMethodInfo);\n\tv199 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v199, v58, Il2CppMethodInfo);\n\tgoto L_006C;\n\tv232 = \"il2cpp_codegen_runtime_class_init\"(v229, v207, v210, v208, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\nL_006C:\n\tv236 = DG.Tweening.DOTween::To(v163, v199, endValue, duration);\n\tv217 = DG.Tweening.TweenSettingsExtensions::SetTarget(v236, v58.target);\n\tgoto L_009F;\nL_0078:\n\tgoto L_008D;\n\tv175 = DG.Tweening.Core.Debugger;\n\tv176 = \"il2cpp_codegen_initialize_runtime_metadata\"(v175, v78, v79, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv179 = 1;\n\t*([1A35757]) = v179;\nL_008D:\n\tv195 = v183._logPriority < 1;\n\tif (v195) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogMissingMaterialProperty(v58.property);\nL_009F:\n\treturn v222;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 118 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000E6")]
		[Address(RVA = "0xC11AFC", Offset = "0xC11AFC", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tv42 = DG.Tweening.Core.DOGetter`1<UnityEngine.Color>;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, propertyID, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv60 = DG.Tweening.Core.DOSetter`1<UnityEngine.Color>;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, propertyID, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv65 = DG.Tweening.DOTween;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, propertyID, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv69 = Il2CppMethodInfo;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, propertyID, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv75 = Il2CppMethodInfo;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, propertyID, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv82 = Il2CppMethodInfo;\n\tv83 = \"il2cpp_codegen_initialize_runtime_metadata\"(v82, propertyID, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv159 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass18_0;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v159, propertyID, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv56 = 1;\n\t*([1A356F5]) = v56;\nL_0035:\n\tv58 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass18_0();\n\tSystem.Object::.ctor(v58);\n\tv58.target = target;\n\tv58.propertyID = propertyID;\n\tv80 = UnityEngine.Material::HasProperty(target, propertyID);\n\tv85 = v80 == 0;\n\tif (v85) goto L_0078;\n\tv163 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v163, v58, Il2CppMethodInfo);\n\tv199 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v199, v58, Il2CppMethodInfo);\n\tgoto L_006C;\n\tv232 = \"il2cpp_codegen_runtime_class_init\"(v229, v207, v210, v208, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\nL_006C:\n\tv236 = DG.Tweening.DOTween::To(v163, v199, endValue, duration);\n\tv217 = DG.Tweening.TweenSettingsExtensions::SetTarget(v236, v58.target);\n\tgoto L_009F;\nL_0078:\n\tgoto L_008D;\n\tv175 = DG.Tweening.Core.Debugger;\n\tv176 = \"il2cpp_codegen_initialize_runtime_metadata\"(v175, v78, v79, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv179 = 1;\n\t*([1A35757]) = v179;\nL_008D:\n\tv195 = v183._logPriority < 1;\n\tif (v195) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogMissingMaterialProperty(v58.propertyID);\nL_009F:\n\treturn v222;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 118 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000E7")]
		[Address(RVA = "0xC11CFC", Offset = "0xC11CFC", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv34 = DG.Tweening.Core.DOGetter`1<UnityEngine.Color>;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv56 = DG.Tweening.Core.DOSetter`1<UnityEngine.Color>;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv61 = DG.Tweening.DOTween;\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv65 = Il2CppMethodInfo;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv83 = Il2CppMethodInfo;\n\tv84 = \"il2cpp_codegen_initialize_runtime_metadata\"(v83, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv90 = Il2CppMethodInfo;\n\tv91 = \"il2cpp_codegen_initialize_runtime_metadata\"(v90, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv131 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass19_0;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v131, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv52 = 1;\n\t*([1A356F6]) = v52;\nL_002E:\n\tv54 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass19_0();\n\tSystem.Object::.ctor(v54);\n\tv54.target = target;\n\tv80 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v80, v54, Il2CppMethodInfo);\n\tv93 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v93, v54, Il2CppMethodInfo);\n\tgoto L_0059;\n\tv137 = \"il2cpp_codegen_runtime_class_init\"(v135, v133, v132, v101, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\nL_0059:\n\tv141 = DG.Tweening.DOTween::ToAlpha(v80, v93, endValue, duration);\n\tv143 = DG.Tweening.TweenSettingsExtensions::SetTarget(v141, v54.target);\n\treturn v141;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000E8")]
		[Address(RVA = "0xC11E6C", Offset = "0xC11E6C", Length = "0x1CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv30 = DG.Tweening.Core.DOGetter`1<UnityEngine.Color>;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, property, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv51 = DG.Tweening.Core.DOSetter`1<UnityEngine.Color>;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, property, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv56 = DG.Tweening.DOTween;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, property, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv60 = Il2CppMethodInfo;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, property, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv66 = Il2CppMethodInfo;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, property, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv73 = Il2CppMethodInfo;\n\tv74 = \"il2cpp_codegen_initialize_runtime_metadata\"(v73, property, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv135 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass20_0;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v135, property, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A356F7]) = v47;\nL_002C:\n\tv49 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass20_0();\n\tSystem.Object::.ctor(v49);\n\tv49.target = target;\n\tv49.property = property;\n\tv71 = UnityEngine.Material::HasProperty(target, property);\n\tv76 = v71 == 0;\n\tif (v76) goto L_006B;\n\tv139 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v139, v49, Il2CppMethodInfo);\n\tv175 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v175, v49, Il2CppMethodInfo);\n\tgoto L_005F;\n\tv204 = \"il2cpp_codegen_runtime_class_init\"(v201, v183, v186, v184, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\nL_005F:\n\tv208 = DG.Tweening.DOTween::ToAlpha(v139, v175, endValue, duration);\n\tv192 = DG.Tweening.TweenSettingsExtensions::SetTarget(v208, v49.target);\n\tgoto L_008F;\nL_006B:\n\tgoto L_0080;\n\tv151 = DG.Tweening.Core.Debugger;\n\tv152 = \"il2cpp_codegen_initialize_runtime_metadata\"(v151, v69, v70, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv155 = 1;\n\t*([1A35757]) = v155;\nL_0080:\n\tv171 = v159._logPriority < 1;\n\tif (v171) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogMissingMaterialProperty(v49.property);\nL_008F:\n\treturn v197;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 102 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000E9")]
		[Address(RVA = "0xC12040", Offset = "0xC12040", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv30 = DG.Tweening.Core.DOGetter`1<UnityEngine.Color>;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, propertyID, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv51 = DG.Tweening.Core.DOSetter`1<UnityEngine.Color>;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, propertyID, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv56 = DG.Tweening.DOTween;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, propertyID, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv60 = Il2CppMethodInfo;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, propertyID, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv66 = Il2CppMethodInfo;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, propertyID, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv73 = Il2CppMethodInfo;\n\tv74 = \"il2cpp_codegen_initialize_runtime_metadata\"(v73, propertyID, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv135 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass21_0;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v135, propertyID, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A356F8]) = v47;\nL_002C:\n\tv49 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass21_0();\n\tSystem.Object::.ctor(v49);\n\tv49.target = target;\n\tv49.propertyID = propertyID;\n\tv71 = UnityEngine.Material::HasProperty(target, propertyID);\n\tv76 = v71 == 0;\n\tif (v76) goto L_006B;\n\tv139 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v139, v49, Il2CppMethodInfo);\n\tv175 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v175, v49, Il2CppMethodInfo);\n\tgoto L_005F;\n\tv204 = \"il2cpp_codegen_runtime_class_init\"(v201, v183, v186, v184, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\nL_005F:\n\tv208 = DG.Tweening.DOTween::ToAlpha(v139, v175, endValue, duration);\n\tv192 = DG.Tweening.TweenSettingsExtensions::SetTarget(v208, v49.target);\n\tgoto L_008F;\nL_006B:\n\tgoto L_0080;\n\tv151 = DG.Tweening.Core.Debugger;\n\tv152 = \"il2cpp_codegen_initialize_runtime_metadata\"(v151, v69, v70, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv155 = 1;\n\t*([1A35757]) = v155;\nL_0080:\n\tv171 = v159._logPriority < 1;\n\tif (v171) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogMissingMaterialProperty(v49.propertyID);\nL_008F:\n\treturn v197;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 102 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000EA")]
		[Address(RVA = "0xC12218", Offset = "0xC12218", Length = "0x1CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv30 = DG.Tweening.Core.DOGetter`1<System.Single>;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, property, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv51 = DG.Tweening.Core.DOSetter`1<System.Single>;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, property, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv56 = DG.Tweening.DOTween;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, property, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv60 = Il2CppMethodInfo;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, property, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv66 = Il2CppMethodInfo;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, property, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv73 = Il2CppMethodInfo;\n\tv74 = \"il2cpp_codegen_initialize_runtime_metadata\"(v73, property, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv135 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass22_0;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v135, property, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A356F9]) = v47;\nL_002C:\n\tv49 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass22_0();\n\tSystem.Object::.ctor(v49);\n\tv49.target = target;\n\tv49.property = property;\n\tv71 = UnityEngine.Material::HasProperty(target, property);\n\tv76 = v71 == 0;\n\tif (v76) goto L_006B;\n\tv139 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v139, v49, Il2CppMethodInfo);\n\tv175 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v175, v49, Il2CppMethodInfo);\n\tgoto L_005F;\n\tv204 = \"il2cpp_codegen_runtime_class_init\"(v201, v183, v186, v184, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\nL_005F:\n\tv208 = DG.Tweening.DOTween::To(v139, v175, endValue, duration);\n\tv192 = DG.Tweening.TweenSettingsExtensions::SetTarget(v208, v49.target);\n\tgoto L_008F;\nL_006B:\n\tgoto L_0080;\n\tv151 = DG.Tweening.Core.Debugger;\n\tv152 = \"il2cpp_codegen_initialize_runtime_metadata\"(v151, v69, v70, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv155 = 1;\n\t*([1A35757]) = v155;\nL_0080:\n\tv171 = v159._logPriority < 1;\n\tif (v171) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogMissingMaterialProperty(v49.property);\nL_008F:\n\treturn v197;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 102 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000EB")]
		[Address(RVA = "0xC123EC", Offset = "0xC123EC", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv30 = DG.Tweening.Core.DOGetter`1<System.Single>;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, propertyID, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv51 = DG.Tweening.Core.DOSetter`1<System.Single>;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, propertyID, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv56 = DG.Tweening.DOTween;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, propertyID, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv60 = Il2CppMethodInfo;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, propertyID, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv66 = Il2CppMethodInfo;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, propertyID, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv73 = Il2CppMethodInfo;\n\tv74 = \"il2cpp_codegen_initialize_runtime_metadata\"(v73, propertyID, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv135 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass23_0;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v135, propertyID, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A356FA]) = v47;\nL_002C:\n\tv49 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass23_0();\n\tSystem.Object::.ctor(v49);\n\tv49.target = target;\n\tv49.propertyID = propertyID;\n\tv71 = UnityEngine.Material::HasProperty(target, propertyID);\n\tv76 = v71 == 0;\n\tif (v76) goto L_006B;\n\tv139 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v139, v49, Il2CppMethodInfo);\n\tv175 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v175, v49, Il2CppMethodInfo);\n\tgoto L_005F;\n\tv204 = \"il2cpp_codegen_runtime_class_init\"(v201, v183, v186, v184, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\nL_005F:\n\tv208 = DG.Tweening.DOTween::To(v139, v175, endValue, duration);\n\tv192 = DG.Tweening.TweenSettingsExtensions::SetTarget(v208, v49.target);\n\tgoto L_008F;\nL_006B:\n\tgoto L_0080;\n\tv151 = DG.Tweening.Core.Debugger;\n\tv152 = \"il2cpp_codegen_initialize_runtime_metadata\"(v151, v69, v70, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv155 = 1;\n\t*([1A35757]) = v155;\nL_0080:\n\tv171 = v159._logPriority < 1;\n\tif (v171) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogMissingMaterialProperty(v49.propertyID);\nL_008F:\n\treturn v197;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 102 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000EC")]
		[Address(RVA = "0xC125C4", Offset = "0xC125C4", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\n\tv38 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v41, v42, v43, v44, v45, v46, endValue, v0, duration, v47, v48, v49, v50, v51);\n\tv59 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v41, v42, v43, v44, v45, v46, endValue, v0, duration, v47, v48, v49, v50, v51);\n\tv64 = DG.Tweening.DOTween;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, methodInfo, v41, v42, v43, v44, v45, v46, endValue, v0, duration, v47, v48, v49, v50, v51);\n\tv68 = Il2CppMethodInfo;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, methodInfo, v41, v42, v43, v44, v45, v46, endValue, v0, duration, v47, v48, v49, v50, v51);\n\tv86 = Il2CppMethodInfo;\n\tv87 = \"il2cpp_codegen_initialize_runtime_metadata\"(v86, methodInfo, v41, v42, v43, v44, v45, v46, endValue, v0, duration, v47, v48, v49, v50, v51);\n\tv93 = Il2CppMethodInfo;\n\tv94 = \"il2cpp_codegen_initialize_runtime_metadata\"(v93, methodInfo, v41, v42, v43, v44, v45, v46, endValue, v0, duration, v47, v48, v49, v50, v51);\n\tv141 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass24_0;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v141, methodInfo, v41, v42, v43, v44, v45, v46, endValue, v0, duration, v47, v48, v49, v50, v51);\n\tv55 = 1;\n\t*([1A356FB]) = v55;\nL_0031:\n\tv57 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass24_0();\n\tSystem.Object::.ctor(v57);\n\tv57.target = target;\n\tv83 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v83, v57, Il2CppMethodInfo);\n\tv96 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v96, v57, Il2CppMethodInfo);\n\tgoto L_005E;\n\tv147 = \"il2cpp_codegen_runtime_class_init\"(v145, v143, v142, v107, v43, v44, v45, v46, endValue, v0, duration, v47, v48, v49, v50, v51);\nL_005E:\n\tv151 = DG.Tweening.DOTween::To(v83, v96, endValue, duration);\n\tv153 = DG.Tweening.TweenSettingsExtensions::SetTarget(v151, v57.target);\n\treturn v151;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000ED")]
		[Address(RVA = "0xC12744", Offset = "0xC12744", Length = "0x1DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv34 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, property, methodInfo, v37, v38, v39, v40, v41, endValue, v0, duration, v42, v43, v44, v45, v46);\n\tv54 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, property, methodInfo, v37, v38, v39, v40, v41, endValue, v0, duration, v42, v43, v44, v45, v46);\n\tv59 = DG.Tweening.DOTween;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, property, methodInfo, v37, v38, v39, v40, v41, endValue, v0, duration, v42, v43, v44, v45, v46);\n\tv63 = Il2CppMethodInfo;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, property, methodInfo, v37, v38, v39, v40, v41, endValue, v0, duration, v42, v43, v44, v45, v46);\n\tv69 = Il2CppMethodInfo;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, property, methodInfo, v37, v38, v39, v40, v41, endValue, v0, duration, v42, v43, v44, v45, v46);\n\tv76 = Il2CppMethodInfo;\n\tv77 = \"il2cpp_codegen_initialize_runtime_metadata\"(v76, property, methodInfo, v37, v38, v39, v40, v41, endValue, v0, duration, v42, v43, v44, v45, v46);\n\tv145 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass25_0;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v145, property, methodInfo, v37, v38, v39, v40, v41, endValue, v0, duration, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A356FC]) = v50;\nL_002F:\n\tv52 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass25_0();\n\tSystem.Object::.ctor(v52);\n\tv52.target = target;\n\tv52.property = property;\n\tv74 = UnityEngine.Material::HasProperty(target, property);\n\tv79 = v74 == 0;\n\tif (v79) goto L_0070;\n\tv149 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v149, v52, Il2CppMethodInfo);\n\tv185 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v185, v52, Il2CppMethodInfo);\n\tgoto L_0064;\n\tv216 = \"il2cpp_codegen_runtime_class_init\"(v213, v193, v196, v194, v38, v39, v40, v41, endValue, v0, duration, v42, v43, v44, v45, v46);\nL_0064:\n\tv220 = DG.Tweening.DOTween::To(v149, v185, endValue, duration);\n\tv203 = DG.Tweening.TweenSettingsExtensions::SetTarget(v220, v52.target);\n\tgoto L_0095;\nL_0070:\n\tgoto L_0085;\n\tv161 = DG.Tweening.Core.Debugger;\n\tv162 = \"il2cpp_codegen_initialize_runtime_metadata\"(v161, v72, v73, v37, v38, v39, v40, v41, endValue, v0, duration, v42, v43, v44, v45, v46);\n\tv165 = 1;\n\t*([1A35757]) = v165;\nL_0085:\n\tv181 = v169._logPriority < 1;\n\tif (v181) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogMissingMaterialProperty(v52.property);\nL_0095:\n\treturn v208;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 108 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000EE")]
		[Address(RVA = "0xC12928", Offset = "0xC12928", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\n\tv38 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v41, v42, v43, v44, v45, v46, endValue, v0, duration, v47, v48, v49, v50, v51);\n\tv59 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v41, v42, v43, v44, v45, v46, endValue, v0, duration, v47, v48, v49, v50, v51);\n\tv64 = DG.Tweening.DOTween;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, methodInfo, v41, v42, v43, v44, v45, v46, endValue, v0, duration, v47, v48, v49, v50, v51);\n\tv68 = Il2CppMethodInfo;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, methodInfo, v41, v42, v43, v44, v45, v46, endValue, v0, duration, v47, v48, v49, v50, v51);\n\tv86 = Il2CppMethodInfo;\n\tv87 = \"il2cpp_codegen_initialize_runtime_metadata\"(v86, methodInfo, v41, v42, v43, v44, v45, v46, endValue, v0, duration, v47, v48, v49, v50, v51);\n\tv93 = Il2CppMethodInfo;\n\tv94 = \"il2cpp_codegen_initialize_runtime_metadata\"(v93, methodInfo, v41, v42, v43, v44, v45, v46, endValue, v0, duration, v47, v48, v49, v50, v51);\n\tv141 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass26_0;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v141, methodInfo, v41, v42, v43, v44, v45, v46, endValue, v0, duration, v47, v48, v49, v50, v51);\n\tv55 = 1;\n\t*([1A356FD]) = v55;\nL_0031:\n\tv57 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass26_0();\n\tSystem.Object::.ctor(v57);\n\tv57.target = target;\n\tv83 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v83, v57, Il2CppMethodInfo);\n\tv96 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v96, v57, Il2CppMethodInfo);\n\tgoto L_005E;\n\tv147 = \"il2cpp_codegen_runtime_class_init\"(v145, v143, v142, v107, v43, v44, v45, v46, endValue, v0, duration, v47, v48, v49, v50, v51);\nL_005E:\n\tv151 = DG.Tweening.DOTween::To(v83, v96, endValue, duration);\n\tv153 = DG.Tweening.TweenSettingsExtensions::SetTarget(v151, v57.target);\n\treturn v151;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000EF")]
		[Address(RVA = "0xC12AA8", Offset = "0xC12AA8", Length = "0x1DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv34 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, property, methodInfo, v37, v38, v39, v40, v41, endValue, v0, duration, v42, v43, v44, v45, v46);\n\tv54 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, property, methodInfo, v37, v38, v39, v40, v41, endValue, v0, duration, v42, v43, v44, v45, v46);\n\tv59 = DG.Tweening.DOTween;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, property, methodInfo, v37, v38, v39, v40, v41, endValue, v0, duration, v42, v43, v44, v45, v46);\n\tv63 = Il2CppMethodInfo;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, property, methodInfo, v37, v38, v39, v40, v41, endValue, v0, duration, v42, v43, v44, v45, v46);\n\tv69 = Il2CppMethodInfo;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, property, methodInfo, v37, v38, v39, v40, v41, endValue, v0, duration, v42, v43, v44, v45, v46);\n\tv76 = Il2CppMethodInfo;\n\tv77 = \"il2cpp_codegen_initialize_runtime_metadata\"(v76, property, methodInfo, v37, v38, v39, v40, v41, endValue, v0, duration, v42, v43, v44, v45, v46);\n\tv145 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass27_0;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v145, property, methodInfo, v37, v38, v39, v40, v41, endValue, v0, duration, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A356FE]) = v50;\nL_002F:\n\tv52 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass27_0();\n\tSystem.Object::.ctor(v52);\n\tv52.target = target;\n\tv52.property = property;\n\tv74 = UnityEngine.Material::HasProperty(target, property);\n\tv79 = v74 == 0;\n\tif (v79) goto L_0070;\n\tv149 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v149, v52, Il2CppMethodInfo);\n\tv185 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v185, v52, Il2CppMethodInfo);\n\tgoto L_0064;\n\tv216 = \"il2cpp_codegen_runtime_class_init\"(v213, v193, v196, v194, v38, v39, v40, v41, endValue, v0, duration, v42, v43, v44, v45, v46);\nL_0064:\n\tv220 = DG.Tweening.DOTween::To(v149, v185, endValue, duration);\n\tv203 = DG.Tweening.TweenSettingsExtensions::SetTarget(v220, v52.target);\n\tgoto L_0095;\nL_0070:\n\tgoto L_0085;\n\tv161 = DG.Tweening.Core.Debugger;\n\tv162 = \"il2cpp_codegen_initialize_runtime_metadata\"(v161, v72, v73, v37, v38, v39, v40, v41, endValue, v0, duration, v42, v43, v44, v45, v46);\n\tv165 = 1;\n\t*([1A35757]) = v165;\nL_0085:\n\tv181 = v169._logPriority < 1;\n\tif (v181) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogMissingMaterialProperty(v52.property);\nL_0095:\n\treturn v208;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 108 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000F0")]
		[Address(RVA = "0xC12C8C", Offset = "0xC12C8C", Length = "0x1F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tv42 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, property, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv60 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector4>;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, property, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv65 = DG.Tweening.DOTween;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, property, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv69 = Il2CppMethodInfo;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, property, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv75 = Il2CppMethodInfo;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, property, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv82 = Il2CppMethodInfo;\n\tv83 = \"il2cpp_codegen_initialize_runtime_metadata\"(v82, property, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv159 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass28_0;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v159, property, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv56 = 1;\n\t*([1A356FF]) = v56;\nL_0035:\n\tv58 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass28_0();\n\tSystem.Object::.ctor(v58);\n\tv58.target = target;\n\tv58.property = property;\n\tv80 = UnityEngine.Material::HasProperty(target, property);\n\tv85 = v80 == 0;\n\tif (v85) goto L_0078;\n\tv163 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>::.ctor(v163, v58, Il2CppMethodInfo);\n\tv199 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector4>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector4>::.ctor(v199, v58, Il2CppMethodInfo);\n\tgoto L_006C;\n\tv232 = \"il2cpp_codegen_runtime_class_init\"(v229, v207, v210, v208, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\nL_006C:\n\tv236 = DG.Tweening.DOTween::To(v163, v199, endValue, duration);\n\tv217 = DG.Tweening.TweenSettingsExtensions::SetTarget(v236, v58.target);\n\tgoto L_009F;\nL_0078:\n\tgoto L_008D;\n\tv175 = DG.Tweening.Core.Debugger;\n\tv176 = \"il2cpp_codegen_initialize_runtime_metadata\"(v175, v78, v79, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv179 = 1;\n\t*([1A35757]) = v179;\nL_008D:\n\tv195 = v183._logPriority < 1;\n\tif (v195) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogMissingMaterialProperty(v58.property);\nL_009F:\n\treturn v222;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 118 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000F1")]
		[Address(RVA = "0xC12E88", Offset = "0xC12E88", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tv42 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, propertyID, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv60 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector4>;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, propertyID, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv65 = DG.Tweening.DOTween;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, propertyID, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv69 = Il2CppMethodInfo;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, propertyID, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv75 = Il2CppMethodInfo;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, propertyID, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv82 = Il2CppMethodInfo;\n\tv83 = \"il2cpp_codegen_initialize_runtime_metadata\"(v82, propertyID, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv159 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass29_0;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v159, propertyID, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv56 = 1;\n\t*([1A35700]) = v56;\nL_0035:\n\tv58 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass29_0();\n\tSystem.Object::.ctor(v58);\n\tv58.target = target;\n\tv58.propertyID = propertyID;\n\tv80 = UnityEngine.Material::HasProperty(target, propertyID);\n\tv85 = v80 == 0;\n\tif (v85) goto L_0078;\n\tv163 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector4>::.ctor(v163, v58, Il2CppMethodInfo);\n\tv199 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector4>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector4>::.ctor(v199, v58, Il2CppMethodInfo);\n\tgoto L_006C;\n\tv232 = \"il2cpp_codegen_runtime_class_init\"(v229, v207, v210, v208, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\nL_006C:\n\tv236 = DG.Tweening.DOTween::To(v163, v199, endValue, duration);\n\tv217 = DG.Tweening.TweenSettingsExtensions::SetTarget(v236, v58.target);\n\tgoto L_009F;\nL_0078:\n\tgoto L_008D;\n\tv175 = DG.Tweening.Core.Debugger;\n\tv176 = \"il2cpp_codegen_initialize_runtime_metadata\"(v175, v78, v79, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv179 = 1;\n\t*([1A35757]) = v179;\nL_008D:\n\tv195 = v183._logPriority < 1;\n\tif (v195) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogMissingMaterialProperty(v58.propertyID);\nL_009F:\n\treturn v222;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 118 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000F2")]
		[Address(RVA = "0xC13088", Offset = "0xC13088", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0030;\n\tv38 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v41, v42, v43, v44, v45, v46, toStartWidth, toEndWidth, duration, v47, v48, v49, v50, v51);\n\tv59 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v41, v42, v43, v44, v45, v46, toStartWidth, toEndWidth, duration, v47, v48, v49, v50, v51);\n\tv64 = DG.Tweening.DOTween;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, methodInfo, v41, v42, v43, v44, v45, v46, toStartWidth, toEndWidth, duration, v47, v48, v49, v50, v51);\n\tv68 = Il2CppMethodInfo;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, methodInfo, v41, v42, v43, v44, v45, v46, toStartWidth, toEndWidth, duration, v47, v48, v49, v50, v51);\n\tv86 = Il2CppMethodInfo;\n\tv87 = \"il2cpp_codegen_initialize_runtime_metadata\"(v86, methodInfo, v41, v42, v43, v44, v45, v46, toStartWidth, toEndWidth, duration, v47, v48, v49, v50, v51);\n\tv93 = Il2CppMethodInfo;\n\tv94 = \"il2cpp_codegen_initialize_runtime_metadata\"(v93, methodInfo, v41, v42, v43, v44, v45, v46, toStartWidth, toEndWidth, duration, v47, v48, v49, v50, v51);\n\tv141 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass30_0;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v141, methodInfo, v41, v42, v43, v44, v45, v46, toStartWidth, toEndWidth, duration, v47, v48, v49, v50, v51);\n\tv55 = 1;\n\t*([1A35701]) = v55;\nL_0030:\n\tv57 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass30_0();\n\tSystem.Object::.ctor(v57);\n\tv57.target = target;\n\tv83 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v83, v57, Il2CppMethodInfo);\n\tv96 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v96, v57, Il2CppMethodInfo);\n\tgoto L_005C;\n\tv147 = \"il2cpp_codegen_runtime_class_init\"(v145, v143, v142, v109, v43, v44, v45, v46, toStartWidth, toEndWidth, duration, v47, v48, v49, v50, v51);\nL_005C:\n\t// 92 MakeStruct v100 @ AGGC171C8_2_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), toStartWidth @ V0 (System.Single), toEndWidth @ V1 (System.Single)\n\tv151 = DG.Tweening.DOTween::To(v83, v96, v100, duration);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v151, v57.target);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOResize(this TrailRenderer target, float toStartWidth, float toEndWidth, float duration)
		{
			DOGetter<Vector2> getter = delegate
			{
				//IL_0028: Expected O, but got F4
				float startWidth = target.startWidth;
				float endWidth = target.endWidth;
				return (Vector2)startWidth;
			};
			DOSetter<Vector2> setter = delegate(Vector2 x)
			{
				Vector2 vector = default(Vector2);
				target.startWidth = vector.x;
				target.endWidth = x.y;
			};
			Vector2 endValue = default(Vector2);
			endValue.x = toStartWidth;
			endValue.y = toEndWidth;
			TweenerCore<Vector2, Vector2, VectorOptions> t = DOTween.To(getter, setter, endValue, duration);
			return t.SetTarget(target);
		}

		[Token(Token = "0x60000F3")]
		[Address(RVA = "0xC131FC", Offset = "0xC131FC", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv34 = DG.Tweening.Core.DOGetter`1<System.Single>;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv56 = DG.Tweening.Core.DOSetter`1<System.Single>;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv61 = DG.Tweening.DOTween;\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv65 = Il2CppMethodInfo;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv83 = Il2CppMethodInfo;\n\tv84 = \"il2cpp_codegen_initialize_runtime_metadata\"(v83, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv90 = Il2CppMethodInfo;\n\tv91 = \"il2cpp_codegen_initialize_runtime_metadata\"(v90, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv131 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass31_0;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v131, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv52 = 1;\n\t*([1A35702]) = v52;\nL_002E:\n\tv54 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass31_0();\n\tSystem.Object::.ctor(v54);\n\tv54.target = target;\n\tv80 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v80, v54, Il2CppMethodInfo);\n\tv93 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v93, v54, Il2CppMethodInfo);\n\tgoto L_0059;\n\tv137 = \"il2cpp_codegen_runtime_class_init\"(v135, v133, v132, v101, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\nL_0059:\n\tv141 = DG.Tweening.DOTween::To(v80, v93, endValue, duration);\n\tv143 = DG.Tweening.TweenSettingsExtensions::SetTarget(v141, v54.target);\n\treturn v141;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000F4")]
		[Address(RVA = "0xC1336C", Offset = "0xC1336C", Length = "0x19C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tv44 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, snapping, methodInfo, v47, v48, v49, v50, v51, endValue, v0, v2, duration, v52, v53, v54, v55);\n\tv63 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, snapping, methodInfo, v47, v48, v49, v50, v51, endValue, v0, v2, duration, v52, v53, v54, v55);\n\tv68 = DG.Tweening.DOTween;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, snapping, methodInfo, v47, v48, v49, v50, v51, endValue, v0, v2, duration, v52, v53, v54, v55);\n\tv72 = Il2CppMethodInfo;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, snapping, methodInfo, v47, v48, v49, v50, v51, endValue, v0, v2, duration, v52, v53, v54, v55);\n\tv88 = Il2CppMethodInfo;\n\tv89 = \"il2cpp_codegen_initialize_runtime_metadata\"(v88, snapping, methodInfo, v47, v48, v49, v50, v51, endValue, v0, v2, duration, v52, v53, v54, v55);\n\tv95 = Il2CppMethodInfo;\n\tv96 = \"il2cpp_codegen_initialize_runtime_metadata\"(v95, snapping, methodInfo, v47, v48, v49, v50, v51, endValue, v0, v2, duration, v52, v53, v54, v55);\n\tv147 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass32_0;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v147, snapping, methodInfo, v47, v48, v49, v50, v51, endValue, v0, v2, duration, v52, v53, v54, v55);\n\tv59 = 1;\n\t*([1A35703]) = v59;\nL_0035:\n\tv61 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass32_0();\n\tSystem.Object::.ctor(v61);\n\tv61.target = target;\n\tv85 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v85, v61, Il2CppMethodInfo);\n\tv98 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v98, v61, Il2CppMethodInfo);\n\tgoto L_0063;\n\tv155 = \"il2cpp_codegen_runtime_class_init\"(v151, v149, v148, v109, v48, v49, v50, v51, endValue, v0, v2, duration, v52, v53, v54, v55);\nL_0063:\n\tv161 = DG.Tweening.DOTween::To(v85, v98, endValue, duration);\n\tv163 = v161 == 0;\n\tif (v163) goto L_006F;\n\tv165 = ~v161.<active>k__BackingField;\n\tif (v165) goto L_006F;\n\t*([v161 @ X0_v12 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+14C]) = snapping;\nL_006F:\n\tv168 = DG.Tweening.TweenSettingsExtensions::SetTarget(v161, v61.target);\n\treturn v161;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOMove(this Transform target, Vector3 endValue, float duration, bool snapping = false)
		{
			DOGetter<Vector3> getter = () => target.position;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.position = x;
			};
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			if (tweenerCore == null || tweenerCore._003Cactive_003Ek__BackingField)
			{
			}
			Tweener tweener = ((Tweener)tweenerCore).SetTarget((object)target);
			return tweenerCore;
		}

		[Token(Token = "0x60000F5")]
		[Address(RVA = "0xC13528", Offset = "0xC13528", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv36 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv57 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv62 = DG.Tweening.DOTween;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv66 = Il2CppMethodInfo;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv82 = Il2CppMethodInfo;\n\tv83 = \"il2cpp_codegen_initialize_runtime_metadata\"(v82, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv89 = Il2CppMethodInfo;\n\tv90 = \"il2cpp_codegen_initialize_runtime_metadata\"(v89, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv140 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass33_0;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v140, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv53 = 1;\n\t*([1A35704]) = v53;\nL_002F:\n\tv55 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass33_0();\n\tSystem.Object::.ctor(v55);\n\tv55.target = target;\n\tv79 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v79, v55, Il2CppMethodInfo);\n\tv92 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v92, v55, Il2CppMethodInfo);\n\tgoto L_005C;\n\tv148 = \"il2cpp_codegen_runtime_class_init\"(v144, v142, v141, v110, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\nL_005C:\n\t// 92 MakeStruct v99 @ AGGC17668_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), endValue @ V0 (System.Single), 0, 0\n\tv154 = DG.Tweening.DOTween::To(v79, v92, v99, duration);\n\tv156 = v154 == 0;\n\tif (v156) goto L_006B;\n\tv158 = ~v154.<active>k__BackingField;\n\tif (v158) goto L_006B;\n\tv154.plugOptions = 2;\n\t*([v154 @ X0_v12 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+14C]) = snapping;\nL_006B:\n\tv162 = DG.Tweening.TweenSettingsExtensions::SetTarget(v154, v55.target);\n\treturn v154;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOMoveX(this Transform target, float endValue, float duration, bool snapping = false)
		{
			//IL_00d4: Expected O, but got I4
			DOGetter<Vector3> getter = () => target.position;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.position = x;
			};
			Vector3 endValue2 = default(Vector3);
			endValue2.x = endValue;
			endValue2.y = 0f;
			endValue2.z = 0f;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue2, duration);
			if (tweenerCore != null && tweenerCore._003Cactive_003Ek__BackingField)
			{
				tweenerCore.plugOptions = (VectorOptions)2;
			}
			Tweener tweener = ((Tweener)tweenerCore).SetTarget((object)target);
			return tweenerCore;
		}

		[Token(Token = "0x60000F6")]
		[Address(RVA = "0xC136E0", Offset = "0xC136E0", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv36 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv57 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv62 = DG.Tweening.DOTween;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv66 = Il2CppMethodInfo;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv82 = Il2CppMethodInfo;\n\tv83 = \"il2cpp_codegen_initialize_runtime_metadata\"(v82, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv89 = Il2CppMethodInfo;\n\tv90 = \"il2cpp_codegen_initialize_runtime_metadata\"(v89, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv140 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass34_0;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v140, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv53 = 1;\n\t*([1A35705]) = v53;\nL_002F:\n\tv55 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass34_0();\n\tSystem.Object::.ctor(v55);\n\tv55.target = target;\n\tv79 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v79, v55, Il2CppMethodInfo);\n\tv92 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v92, v55, Il2CppMethodInfo);\n\tgoto L_005C;\n\tv148 = \"il2cpp_codegen_runtime_class_init\"(v144, v142, v141, v110, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\nL_005C:\n\t// 92 MakeStruct v99 @ AGGC17820_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, endValue @ V0 (System.Single), 0\n\tv154 = DG.Tweening.DOTween::To(v79, v92, v99, duration);\n\tv156 = v154 == 0;\n\tif (v156) goto L_006B;\n\tv158 = ~v154.<active>k__BackingField;\n\tif (v158) goto L_006B;\n\tv154.plugOptions = 4;\n\t*([v154 @ X0_v12 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+14C]) = snapping;\nL_006B:\n\tv162 = DG.Tweening.TweenSettingsExtensions::SetTarget(v154, v55.target);\n\treturn v154;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOMoveY(this Transform target, float endValue, float duration, bool snapping = false)
		{
			//IL_00d4: Expected O, but got I4
			DOGetter<Vector3> getter = () => target.position;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.position = x;
			};
			Vector3 endValue2 = default(Vector3);
			endValue2.x = 0f;
			endValue2.y = endValue;
			endValue2.z = 0f;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue2, duration);
			if (tweenerCore != null && tweenerCore._003Cactive_003Ek__BackingField)
			{
				tweenerCore.plugOptions = (VectorOptions)4;
			}
			Tweener tweener = ((Tweener)tweenerCore).SetTarget((object)target);
			return tweenerCore;
		}

		[Token(Token = "0x60000F7")]
		[Address(RVA = "0xC1387C", Offset = "0xC1387C", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv36 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv57 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv62 = DG.Tweening.DOTween;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv66 = Il2CppMethodInfo;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv82 = Il2CppMethodInfo;\n\tv83 = \"il2cpp_codegen_initialize_runtime_metadata\"(v82, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv89 = Il2CppMethodInfo;\n\tv90 = \"il2cpp_codegen_initialize_runtime_metadata\"(v89, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv140 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass35_0;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v140, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv53 = 1;\n\t*([1A35706]) = v53;\nL_002F:\n\tv55 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass35_0();\n\tSystem.Object::.ctor(v55);\n\tv55.target = target;\n\tv79 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v79, v55, Il2CppMethodInfo);\n\tv92 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v92, v55, Il2CppMethodInfo);\n\tgoto L_005C;\n\tv148 = \"il2cpp_codegen_runtime_class_init\"(v144, v142, v141, v110, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\nL_005C:\n\t// 92 MakeStruct v99 @ AGGC179BC_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, 0, endValue @ V0 (System.Single)\n\tv154 = DG.Tweening.DOTween::To(v79, v92, v99, duration);\n\tv156 = v154 == 0;\n\tif (v156) goto L_006B;\n\tv158 = ~v154.<active>k__BackingField;\n\tif (v158) goto L_006B;\n\tv154.plugOptions = 8;\n\t*([v154 @ X0_v12 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+14C]) = snapping;\nL_006B:\n\tv162 = DG.Tweening.TweenSettingsExtensions::SetTarget(v154, v55.target);\n\treturn v154;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOMoveZ(this Transform target, float endValue, float duration, bool snapping = false)
		{
			//IL_00d4: Expected O, but got I4
			DOGetter<Vector3> getter = () => target.position;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.position = x;
			};
			Vector3 endValue2 = default(Vector3);
			endValue2.x = 0f;
			endValue2.y = 0f;
			endValue2.z = endValue;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue2, duration);
			if (tweenerCore != null && tweenerCore._003Cactive_003Ek__BackingField)
			{
				tweenerCore.plugOptions = (VectorOptions)8;
			}
			Tweener tweener = ((Tweener)tweenerCore).SetTarget((object)target);
			return tweenerCore;
		}

		[Token(Token = "0x60000F8")]
		[Address(RVA = "0xC13A18", Offset = "0xC13A18", Length = "0x19C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tv44 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, snapping, methodInfo, v47, v48, v49, v50, v51, endValue, v0, v2, duration, v52, v53, v54, v55);\n\tv63 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, snapping, methodInfo, v47, v48, v49, v50, v51, endValue, v0, v2, duration, v52, v53, v54, v55);\n\tv68 = DG.Tweening.DOTween;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, snapping, methodInfo, v47, v48, v49, v50, v51, endValue, v0, v2, duration, v52, v53, v54, v55);\n\tv72 = Il2CppMethodInfo;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, snapping, methodInfo, v47, v48, v49, v50, v51, endValue, v0, v2, duration, v52, v53, v54, v55);\n\tv88 = Il2CppMethodInfo;\n\tv89 = \"il2cpp_codegen_initialize_runtime_metadata\"(v88, snapping, methodInfo, v47, v48, v49, v50, v51, endValue, v0, v2, duration, v52, v53, v54, v55);\n\tv95 = Il2CppMethodInfo;\n\tv96 = \"il2cpp_codegen_initialize_runtime_metadata\"(v95, snapping, methodInfo, v47, v48, v49, v50, v51, endValue, v0, v2, duration, v52, v53, v54, v55);\n\tv147 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass36_0;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v147, snapping, methodInfo, v47, v48, v49, v50, v51, endValue, v0, v2, duration, v52, v53, v54, v55);\n\tv59 = 1;\n\t*([1A35707]) = v59;\nL_0035:\n\tv61 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass36_0();\n\tSystem.Object::.ctor(v61);\n\tv61.target = target;\n\tv85 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v85, v61, Il2CppMethodInfo);\n\tv98 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v98, v61, Il2CppMethodInfo);\n\tgoto L_0063;\n\tv155 = \"il2cpp_codegen_runtime_class_init\"(v151, v149, v148, v109, v48, v49, v50, v51, endValue, v0, v2, duration, v52, v53, v54, v55);\nL_0063:\n\tv161 = DG.Tweening.DOTween::To(v85, v98, endValue, duration);\n\tv163 = v161 == 0;\n\tif (v163) goto L_006F;\n\tv165 = ~v161.<active>k__BackingField;\n\tif (v165) goto L_006F;\n\t*([v161 @ X0_v12 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+14C]) = snapping;\nL_006F:\n\tv168 = DG.Tweening.TweenSettingsExtensions::SetTarget(v161, v61.target);\n\treturn v161;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOLocalMove(this Transform target, Vector3 endValue, float duration, bool snapping = false)
		{
			DOGetter<Vector3> getter = () => target.localPosition;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.localPosition = x;
			};
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			if (tweenerCore == null || tweenerCore._003Cactive_003Ek__BackingField)
			{
			}
			Tweener tweener = ((Tweener)tweenerCore).SetTarget((object)target);
			return tweenerCore;
		}

		[Token(Token = "0x60000F9")]
		[Address(RVA = "0xC13BBC", Offset = "0xC13BBC", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv36 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv57 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv62 = DG.Tweening.DOTween;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv66 = Il2CppMethodInfo;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv82 = Il2CppMethodInfo;\n\tv83 = \"il2cpp_codegen_initialize_runtime_metadata\"(v82, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv89 = Il2CppMethodInfo;\n\tv90 = \"il2cpp_codegen_initialize_runtime_metadata\"(v89, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv140 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass37_0;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v140, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv53 = 1;\n\t*([1A35708]) = v53;\nL_002F:\n\tv55 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass37_0();\n\tSystem.Object::.ctor(v55);\n\tv55.target = target;\n\tv79 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v79, v55, Il2CppMethodInfo);\n\tv92 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v92, v55, Il2CppMethodInfo);\n\tgoto L_005C;\n\tv148 = \"il2cpp_codegen_runtime_class_init\"(v144, v142, v141, v110, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\nL_005C:\n\t// 92 MakeStruct v99 @ AGGC17CFC_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), endValue @ V0 (System.Single), 0, 0\n\tv154 = DG.Tweening.DOTween::To(v79, v92, v99, duration);\n\tv156 = v154 == 0;\n\tif (v156) goto L_006B;\n\tv158 = ~v154.<active>k__BackingField;\n\tif (v158) goto L_006B;\n\tv154.plugOptions = 2;\n\t*([v154 @ X0_v12 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+14C]) = snapping;\nL_006B:\n\tv162 = DG.Tweening.TweenSettingsExtensions::SetTarget(v154, v55.target);\n\treturn v154;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOLocalMoveX(this Transform target, float endValue, float duration, bool snapping = false)
		{
			//IL_00d4: Expected O, but got I4
			DOGetter<Vector3> getter = () => target.localPosition;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.localPosition = x;
			};
			Vector3 endValue2 = default(Vector3);
			endValue2.x = endValue;
			endValue2.y = 0f;
			endValue2.z = 0f;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue2, duration);
			if (tweenerCore != null && tweenerCore._003Cactive_003Ek__BackingField)
			{
				tweenerCore.plugOptions = (VectorOptions)2;
			}
			Tweener tweener = ((Tweener)tweenerCore).SetTarget((object)target);
			return tweenerCore;
		}

		[Token(Token = "0x60000FA")]
		[Address(RVA = "0xC13D58", Offset = "0xC13D58", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv36 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv57 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv62 = DG.Tweening.DOTween;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv66 = Il2CppMethodInfo;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv82 = Il2CppMethodInfo;\n\tv83 = \"il2cpp_codegen_initialize_runtime_metadata\"(v82, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv89 = Il2CppMethodInfo;\n\tv90 = \"il2cpp_codegen_initialize_runtime_metadata\"(v89, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv140 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass38_0;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v140, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv53 = 1;\n\t*([1A35709]) = v53;\nL_002F:\n\tv55 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass38_0();\n\tSystem.Object::.ctor(v55);\n\tv55.target = target;\n\tv79 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v79, v55, Il2CppMethodInfo);\n\tv92 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v92, v55, Il2CppMethodInfo);\n\tgoto L_005C;\n\tv148 = \"il2cpp_codegen_runtime_class_init\"(v144, v142, v141, v110, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\nL_005C:\n\t// 92 MakeStruct v99 @ AGGC17E98_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, endValue @ V0 (System.Single), 0\n\tv154 = DG.Tweening.DOTween::To(v79, v92, v99, duration);\n\tv156 = v154 == 0;\n\tif (v156) goto L_006B;\n\tv158 = ~v154.<active>k__BackingField;\n\tif (v158) goto L_006B;\n\tv154.plugOptions = 4;\n\t*([v154 @ X0_v12 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+14C]) = snapping;\nL_006B:\n\tv162 = DG.Tweening.TweenSettingsExtensions::SetTarget(v154, v55.target);\n\treturn v154;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOLocalMoveY(this Transform target, float endValue, float duration, bool snapping = false)
		{
			//IL_00d4: Expected O, but got I4
			DOGetter<Vector3> getter = () => target.localPosition;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.localPosition = x;
			};
			Vector3 endValue2 = default(Vector3);
			endValue2.x = 0f;
			endValue2.y = endValue;
			endValue2.z = 0f;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue2, duration);
			if (tweenerCore != null && tweenerCore._003Cactive_003Ek__BackingField)
			{
				tweenerCore.plugOptions = (VectorOptions)4;
			}
			Tweener tweener = ((Tweener)tweenerCore).SetTarget((object)target);
			return tweenerCore;
		}

		[Token(Token = "0x60000FB")]
		[Address(RVA = "0xC13EF4", Offset = "0xC13EF4", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv36 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv57 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv62 = DG.Tweening.DOTween;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv66 = Il2CppMethodInfo;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv82 = Il2CppMethodInfo;\n\tv83 = \"il2cpp_codegen_initialize_runtime_metadata\"(v82, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv89 = Il2CppMethodInfo;\n\tv90 = \"il2cpp_codegen_initialize_runtime_metadata\"(v89, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv140 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass39_0;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v140, snapping, methodInfo, v39, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\n\tv53 = 1;\n\t*([1A3570A]) = v53;\nL_002F:\n\tv55 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass39_0();\n\tSystem.Object::.ctor(v55);\n\tv55.target = target;\n\tv79 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v79, v55, Il2CppMethodInfo);\n\tv92 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v92, v55, Il2CppMethodInfo);\n\tgoto L_005C;\n\tv148 = \"il2cpp_codegen_runtime_class_init\"(v144, v142, v141, v110, v40, v41, v42, v43, endValue, duration, v44, v45, v46, v47, v48, v49);\nL_005C:\n\t// 92 MakeStruct v99 @ AGGC18034_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, 0, endValue @ V0 (System.Single)\n\tv154 = DG.Tweening.DOTween::To(v79, v92, v99, duration);\n\tv156 = v154 == 0;\n\tif (v156) goto L_006B;\n\tv158 = ~v154.<active>k__BackingField;\n\tif (v158) goto L_006B;\n\tv154.plugOptions = 8;\n\t*([v154 @ X0_v12 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+14C]) = snapping;\nL_006B:\n\tv162 = DG.Tweening.TweenSettingsExtensions::SetTarget(v154, v55.target);\n\treturn v154;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOLocalMoveZ(this Transform target, float endValue, float duration, bool snapping = false)
		{
			//IL_00d4: Expected O, but got I4
			DOGetter<Vector3> getter = () => target.localPosition;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.localPosition = x;
			};
			Vector3 endValue2 = default(Vector3);
			endValue2.x = 0f;
			endValue2.y = 0f;
			endValue2.z = endValue;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue2, duration);
			if (tweenerCore != null && tweenerCore._003Cactive_003Ek__BackingField)
			{
				tweenerCore.plugOptions = (VectorOptions)8;
			}
			Tweener tweener = ((Tweener)tweenerCore).SetTarget((object)target);
			return tweenerCore;
		}

		[Token(Token = "0x60000FC")]
		[Address(RVA = "0xC14090", Offset = "0xC14090", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\n\tv46 = DG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, mode, methodInfo, v49, v50, v51, v52, v53, endValue, v0, v2, duration, v54, v55, v56, v57);\n\tv65 = DG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, mode, methodInfo, v49, v50, v51, v52, v53, endValue, v0, v2, duration, v54, v55, v56, v57);\n\tv70 = DG.Tweening.DOTween;\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, mode, methodInfo, v49, v50, v51, v52, v53, endValue, v0, v2, duration, v54, v55, v56, v57);\n\tv74 = Il2CppMethodInfo;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, mode, methodInfo, v49, v50, v51, v52, v53, endValue, v0, v2, duration, v54, v55, v56, v57);\n\tv125 = Il2CppMethodInfo;\n\tv126 = \"il2cpp_codegen_initialize_runtime_metadata\"(v125, mode, methodInfo, v49, v50, v51, v52, v53, endValue, v0, v2, duration, v54, v55, v56, v57);\n\tv131 = Il2CppMethodInfo;\n\tv132 = \"il2cpp_codegen_initialize_runtime_metadata\"(v131, mode, methodInfo, v49, v50, v51, v52, v53, endValue, v0, v2, duration, v54, v55, v56, v57);\n\tv174 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass40_0;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v174, mode, methodInfo, v49, v50, v51, v52, v53, endValue, v0, v2, duration, v54, v55, v56, v57);\n\tv61 = 1;\n\t*([1A3570B]) = v61;\nL_0036:\n\tv63 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass40_0();\n\tSystem.Object::.ctor(v63);\n\tv63.target = target;\n\tv89 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>::.ctor(v89, v63, Il2CppMethodInfo);\n\tv134 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>::.ctor(v134, v63, Il2CppMethodInfo);\n\tgoto L_0064;\n\tv180 = \"il2cpp_codegen_runtime_class_init\"(v177, v176, v175, v98, v50, v51, v52, v53, endValue, v0, v2, duration, v54, v55, v56, v57);\nL_0064:\n\tv184 = DG.Tweening.DOTween::To(v89, v134, endValue, duration);\n\tv108 = DG.Tweening.TweenSettingsExtensions::SetTarget(v184, v63.target);\n\tv184.plugOptions = mode;\n\treturn v184;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 94 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Quaternion, Vector3, QuaternionOptions> DORotate(this Transform target, Vector3 endValue, float duration, RotateMode mode = RotateMode.Fast)
		{
			//IL_008a: Expected O, but got I4
			DOGetter<Quaternion> getter = () => target.rotation;
			DOSetter<Quaternion> setter = delegate(Quaternion x)
			{
				target.rotation = x;
			};
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			tweenerCore.plugOptions = (QuaternionOptions)mode;
			return tweenerCore;
		}

		[Token(Token = "0x60000FD")]
		[Address(RVA = "0xC1422C", Offset = "0xC1422C", Length = "0x1C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003C;\n\tv50 = DG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, methodInfo, v53, v54, v55, v56, v57, v58, endValue, v0, v2, v3, duration, v59, v60, v61);\n\tv69 = DG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, methodInfo, v53, v54, v55, v56, v57, v58, endValue, v0, v2, v3, duration, v59, v60, v61);\n\tv74 = Il2CppMethodInfo;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, methodInfo, v53, v54, v55, v56, v57, v58, endValue, v0, v2, v3, duration, v59, v60, v61);\n\tv78 = DG.Tweening.DOTween;\n\tv79 = \"il2cpp_codegen_initialize_runtime_metadata\"(v78, methodInfo, v53, v54, v55, v56, v57, v58, endValue, v0, v2, v3, duration, v59, v60, v61);\n\tv98 = Il2CppMethodInfo;\n\tv99 = \"il2cpp_codegen_initialize_runtime_metadata\"(v98, methodInfo, v53, v54, v55, v56, v57, v58, endValue, v0, v2, v3, duration, v59, v60, v61);\n\tv105 = Il2CppMethodInfo;\n\tv106 = \"il2cpp_codegen_initialize_runtime_metadata\"(v105, methodInfo, v53, v54, v55, v56, v57, v58, endValue, v0, v2, v3, duration, v59, v60, v61);\n\tv164 = Il2CppMethodInfo;\n\tv165 = \"il2cpp_codegen_initialize_runtime_metadata\"(v164, methodInfo, v53, v54, v55, v56, v57, v58, endValue, v0, v2, v3, duration, v59, v60, v61);\n\tv169 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass41_0;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v169, methodInfo, v53, v54, v55, v56, v57, v58, endValue, v0, v2, v3, duration, v59, v60, v61);\n\tv65 = 1;\n\t*([1A3570C]) = v65;\nL_003C:\n\tv67 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass41_0();\n\tSystem.Object::.ctor(v67);\n\tv67.target = target;\n\tv95 = DG.Tweening.CustomPlugins.PureQuaternionPlugin::Plug();\n\tv103 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>::.ctor(v103, v67, Il2CppMethodInfo);\n\tv167 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>::.ctor(v167, v67, Il2CppMethodInfo);\n\tgoto L_0072;\n\tv176 = \"il2cpp_codegen_runtime_class_init\"(v174, v171, v170, v172, v55, v56, v57, v58, endValue, v0, v2, v3, duration, v59, v60, v61);\nL_0072:\n\tv181 = DG.Tweening.DOTween::To(v95, v103, v167, Il2CppMethodInfo, endValue);\n\tv183 = DG.Tweening.TweenSettingsExtensions::SetTarget(v181, v67.target);\n\treturn v181;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 105 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Quaternion, Quaternion, NoOptions> DORotateQuaternion(this Transform target, Quaternion endValue, float duration)
		{
			//IL_006e: Expected O, but got I
			PureQuaternionPlugin plugin = PureQuaternionPlugin.Plug();
			DOGetter<Quaternion> getter = () => target.rotation;
			DOSetter<Quaternion> setter = delegate(Quaternion x)
			{
				target.rotation = x;
			};
			Quaternion quaternion = default(Quaternion);
			TweenerCore<Quaternion, Quaternion, NoOptions> tweenerCore = DOTween.To(plugin, getter, setter, (Quaternion)0, quaternion.x);
			TweenerCore<Quaternion, Quaternion, NoOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x60000FE")]
		[Address(RVA = "0xC143F8", Offset = "0xC143F8", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\n\tv46 = DG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, mode, methodInfo, v49, v50, v51, v52, v53, endValue, v0, v2, duration, v54, v55, v56, v57);\n\tv65 = DG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, mode, methodInfo, v49, v50, v51, v52, v53, endValue, v0, v2, duration, v54, v55, v56, v57);\n\tv70 = DG.Tweening.DOTween;\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, mode, methodInfo, v49, v50, v51, v52, v53, endValue, v0, v2, duration, v54, v55, v56, v57);\n\tv74 = Il2CppMethodInfo;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, mode, methodInfo, v49, v50, v51, v52, v53, endValue, v0, v2, duration, v54, v55, v56, v57);\n\tv125 = Il2CppMethodInfo;\n\tv126 = \"il2cpp_codegen_initialize_runtime_metadata\"(v125, mode, methodInfo, v49, v50, v51, v52, v53, endValue, v0, v2, duration, v54, v55, v56, v57);\n\tv131 = Il2CppMethodInfo;\n\tv132 = \"il2cpp_codegen_initialize_runtime_metadata\"(v131, mode, methodInfo, v49, v50, v51, v52, v53, endValue, v0, v2, duration, v54, v55, v56, v57);\n\tv174 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass42_0;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v174, mode, methodInfo, v49, v50, v51, v52, v53, endValue, v0, v2, duration, v54, v55, v56, v57);\n\tv61 = 1;\n\t*([1A3570D]) = v61;\nL_0036:\n\tv63 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass42_0();\n\tSystem.Object::.ctor(v63);\n\tv63.target = target;\n\tv89 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>::.ctor(v89, v63, Il2CppMethodInfo);\n\tv134 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>::.ctor(v134, v63, Il2CppMethodInfo);\n\tgoto L_0064;\n\tv180 = \"il2cpp_codegen_runtime_class_init\"(v177, v176, v175, v98, v50, v51, v52, v53, endValue, v0, v2, duration, v54, v55, v56, v57);\nL_0064:\n\tv184 = DG.Tweening.DOTween::To(v89, v134, endValue, duration);\n\tv108 = DG.Tweening.TweenSettingsExtensions::SetTarget(v184, v63.target);\n\tv184.plugOptions = mode;\n\treturn v184;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 94 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Quaternion, Vector3, QuaternionOptions> DOLocalRotate(this Transform target, Vector3 endValue, float duration, RotateMode mode = RotateMode.Fast)
		{
			//IL_008a: Expected O, but got I4
			DOGetter<Quaternion> getter = () => target.localRotation;
			DOSetter<Quaternion> setter = delegate(Quaternion x)
			{
				target.localRotation = x;
			};
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			tweenerCore.plugOptions = (QuaternionOptions)mode;
			return tweenerCore;
		}

		[Token(Token = "0x60000FF")]
		[Address(RVA = "0xC14594", Offset = "0xC14594", Length = "0x1C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003C;\n\tv50 = DG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, methodInfo, v53, v54, v55, v56, v57, v58, endValue, v0, v2, v3, duration, v59, v60, v61);\n\tv69 = DG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, methodInfo, v53, v54, v55, v56, v57, v58, endValue, v0, v2, v3, duration, v59, v60, v61);\n\tv74 = Il2CppMethodInfo;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, methodInfo, v53, v54, v55, v56, v57, v58, endValue, v0, v2, v3, duration, v59, v60, v61);\n\tv78 = DG.Tweening.DOTween;\n\tv79 = \"il2cpp_codegen_initialize_runtime_metadata\"(v78, methodInfo, v53, v54, v55, v56, v57, v58, endValue, v0, v2, v3, duration, v59, v60, v61);\n\tv98 = Il2CppMethodInfo;\n\tv99 = \"il2cpp_codegen_initialize_runtime_metadata\"(v98, methodInfo, v53, v54, v55, v56, v57, v58, endValue, v0, v2, v3, duration, v59, v60, v61);\n\tv105 = Il2CppMethodInfo;\n\tv106 = \"il2cpp_codegen_initialize_runtime_metadata\"(v105, methodInfo, v53, v54, v55, v56, v57, v58, endValue, v0, v2, v3, duration, v59, v60, v61);\n\tv164 = Il2CppMethodInfo;\n\tv165 = \"il2cpp_codegen_initialize_runtime_metadata\"(v164, methodInfo, v53, v54, v55, v56, v57, v58, endValue, v0, v2, v3, duration, v59, v60, v61);\n\tv169 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass43_0;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v169, methodInfo, v53, v54, v55, v56, v57, v58, endValue, v0, v2, v3, duration, v59, v60, v61);\n\tv65 = 1;\n\t*([1A3570E]) = v65;\nL_003C:\n\tv67 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass43_0();\n\tSystem.Object::.ctor(v67);\n\tv67.target = target;\n\tv95 = DG.Tweening.CustomPlugins.PureQuaternionPlugin::Plug();\n\tv103 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>::.ctor(v103, v67, Il2CppMethodInfo);\n\tv167 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>::.ctor(v167, v67, Il2CppMethodInfo);\n\tgoto L_0072;\n\tv176 = \"il2cpp_codegen_runtime_class_init\"(v174, v171, v170, v172, v55, v56, v57, v58, endValue, v0, v2, v3, duration, v59, v60, v61);\nL_0072:\n\tv181 = DG.Tweening.DOTween::To(v95, v103, v167, Il2CppMethodInfo, endValue);\n\tv183 = DG.Tweening.TweenSettingsExtensions::SetTarget(v181, v67.target);\n\treturn v181;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 105 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Quaternion, Quaternion, NoOptions> DOLocalRotateQuaternion(this Transform target, Quaternion endValue, float duration)
		{
			//IL_006e: Expected O, but got I
			PureQuaternionPlugin plugin = PureQuaternionPlugin.Plug();
			DOGetter<Quaternion> getter = () => target.localRotation;
			DOSetter<Quaternion> setter = delegate(Quaternion x)
			{
				target.localRotation = x;
			};
			Quaternion quaternion = default(Quaternion);
			TweenerCore<Quaternion, Quaternion, NoOptions> tweenerCore = DOTween.To(plugin, getter, setter, (Quaternion)0, quaternion.x);
			TweenerCore<Quaternion, Quaternion, NoOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x6000100")]
		[Address(RVA = "0xC14760", Offset = "0xC14760", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0034;\n\tv42 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, methodInfo, v45, v46, v47, v48, v49, v50, endValue, v0, v2, duration, v51, v52, v53, v54);\n\tv62 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, methodInfo, v45, v46, v47, v48, v49, v50, endValue, v0, v2, duration, v51, v52, v53, v54);\n\tv67 = DG.Tweening.DOTween;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, methodInfo, v45, v46, v47, v48, v49, v50, endValue, v0, v2, duration, v51, v52, v53, v54);\n\tv71 = Il2CppMethodInfo;\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, methodInfo, v45, v46, v47, v48, v49, v50, endValue, v0, v2, duration, v51, v52, v53, v54);\n\tv89 = Il2CppMethodInfo;\n\tv90 = \"il2cpp_codegen_initialize_runtime_metadata\"(v89, methodInfo, v45, v46, v47, v48, v49, v50, endValue, v0, v2, duration, v51, v52, v53, v54);\n\tv96 = Il2CppMethodInfo;\n\tv97 = \"il2cpp_codegen_initialize_runtime_metadata\"(v96, methodInfo, v45, v46, v47, v48, v49, v50, endValue, v0, v2, duration, v51, v52, v53, v54);\n\tv148 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass44_0;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v148, methodInfo, v45, v46, v47, v48, v49, v50, endValue, v0, v2, duration, v51, v52, v53, v54);\n\tv58 = 1;\n\t*([1A3570F]) = v58;\nL_0034:\n\tv60 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass44_0();\n\tSystem.Object::.ctor(v60);\n\tv60.target = target;\n\tv86 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v86, v60, Il2CppMethodInfo);\n\tv99 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v99, v60, Il2CppMethodInfo);\n\tgoto L_0062;\n\tv154 = \"il2cpp_codegen_runtime_class_init\"(v152, v150, v149, v110, v47, v48, v49, v50, endValue, v0, v2, duration, v51, v52, v53, v54);\nL_0062:\n\tv158 = DG.Tweening.DOTween::To(v86, v99, endValue, duration);\n\tv160 = DG.Tweening.TweenSettingsExtensions::SetTarget(v158, v60.target);\n\treturn v158;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000101")]
		[Address(RVA = "0xC148E8", Offset = "0xC148E8", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv34 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv56 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv61 = DG.Tweening.DOTween;\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv65 = Il2CppMethodInfo;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv83 = Il2CppMethodInfo;\n\tv84 = \"il2cpp_codegen_initialize_runtime_metadata\"(v83, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv90 = Il2CppMethodInfo;\n\tv91 = \"il2cpp_codegen_initialize_runtime_metadata\"(v90, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv138 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass45_0;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v138, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv52 = 1;\n\t*([1A35710]) = v52;\nL_002E:\n\tv54 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass45_0();\n\tSystem.Object::.ctor(v54);\n\tv54.target = target;\n\tv80 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v80, v54, Il2CppMethodInfo);\n\tv93 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v93, v54, Il2CppMethodInfo);\n\tgoto L_005B;\n\tv144 = \"il2cpp_codegen_runtime_class_init\"(v142, v140, v139, v108, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\nL_005B:\n\t// 91 MakeStruct v97 @ AGGC18A24_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), endValue @ V0 (System.Single), endValue @ V0 (System.Single), endValue @ V0 (System.Single)\n\tv148 = DG.Tweening.DOTween::To(v80, v93, v97, duration);\n\tv150 = DG.Tweening.TweenSettingsExtensions::SetTarget(v148, v54.target);\n\treturn v148;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOScale(this Transform target, float endValue, float duration)
		{
			DOGetter<Vector3> getter = () => target.localScale;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.localScale = x;
			};
			Vector3 endValue2 = default(Vector3);
			endValue2.x = endValue;
			endValue2.y = endValue;
			endValue2.z = endValue;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue2, duration);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x6000102")]
		[Address(RVA = "0xC14A60", Offset = "0xC14A60", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tv32 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, methodInfo, v35, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv54 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v35, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv59 = DG.Tweening.DOTween;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v35, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv63 = Il2CppMethodInfo;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, methodInfo, v35, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv79 = Il2CppMethodInfo;\n\tv80 = \"il2cpp_codegen_initialize_runtime_metadata\"(v79, methodInfo, v35, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv86 = Il2CppMethodInfo;\n\tv87 = \"il2cpp_codegen_initialize_runtime_metadata\"(v86, methodInfo, v35, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv132 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass46_0;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v132, methodInfo, v35, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A35711]) = v50;\nL_002D:\n\tv52 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass46_0();\n\tSystem.Object::.ctor(v52);\n\tv52.target = target;\n\tv76 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v76, v52, Il2CppMethodInfo);\n\tv89 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v89, v52, Il2CppMethodInfo);\n\tgoto L_005A;\n\tv140 = \"il2cpp_codegen_runtime_class_init\"(v136, v134, v133, v104, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\nL_005A:\n\t// 90 MakeStruct v93 @ AGGC18B9C_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), endValue @ V0 (System.Single), 0, 0\n\tv146 = DG.Tweening.DOTween::To(v76, v89, v93, duration);\n\tv148 = v146 == 0;\n\tif (v148) goto L_0068;\n\tv150 = ~v146.<active>k__BackingField;\n\tif (v150) goto L_0068;\n\tv146.plugOptions = 2;\n\t*([v146 @ X0_v12 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+14C]) = 0;\nL_0068:\n\tv153 = DG.Tweening.TweenSettingsExtensions::SetTarget(v146, v52.target);\n\treturn v146;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOScaleX(this Transform target, float endValue, float duration)
		{
			//IL_00d4: Expected O, but got I4
			DOGetter<Vector3> getter = () => target.localScale;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.localScale = x;
			};
			Vector3 endValue2 = default(Vector3);
			endValue2.x = endValue;
			endValue2.y = 0f;
			endValue2.z = 0f;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue2, duration);
			if (tweenerCore != null && tweenerCore._003Cactive_003Ek__BackingField)
			{
				tweenerCore.plugOptions = (VectorOptions)2;
				_ = 0;
			}
			Tweener tweener = ((Tweener)tweenerCore).SetTarget((object)target);
			return tweenerCore;
		}

		[Token(Token = "0x6000103")]
		[Address(RVA = "0xC14BF4", Offset = "0xC14BF4", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tv32 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, methodInfo, v35, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv54 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v35, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv59 = DG.Tweening.DOTween;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v35, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv63 = Il2CppMethodInfo;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, methodInfo, v35, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv79 = Il2CppMethodInfo;\n\tv80 = \"il2cpp_codegen_initialize_runtime_metadata\"(v79, methodInfo, v35, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv86 = Il2CppMethodInfo;\n\tv87 = \"il2cpp_codegen_initialize_runtime_metadata\"(v86, methodInfo, v35, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv132 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass47_0;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v132, methodInfo, v35, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A35712]) = v50;\nL_002D:\n\tv52 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass47_0();\n\tSystem.Object::.ctor(v52);\n\tv52.target = target;\n\tv76 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v76, v52, Il2CppMethodInfo);\n\tv89 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v89, v52, Il2CppMethodInfo);\n\tgoto L_005A;\n\tv140 = \"il2cpp_codegen_runtime_class_init\"(v136, v134, v133, v104, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\nL_005A:\n\t// 90 MakeStruct v93 @ AGGC18D30_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, endValue @ V0 (System.Single), 0\n\tv146 = DG.Tweening.DOTween::To(v76, v89, v93, duration);\n\tv148 = v146 == 0;\n\tif (v148) goto L_0068;\n\tv150 = ~v146.<active>k__BackingField;\n\tif (v150) goto L_0068;\n\tv146.plugOptions = 4;\n\t*([v146 @ X0_v12 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+14C]) = 0;\nL_0068:\n\tv153 = DG.Tweening.TweenSettingsExtensions::SetTarget(v146, v52.target);\n\treturn v146;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOScaleY(this Transform target, float endValue, float duration)
		{
			//IL_00d4: Expected O, but got I4
			DOGetter<Vector3> getter = () => target.localScale;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.localScale = x;
			};
			Vector3 endValue2 = default(Vector3);
			endValue2.x = 0f;
			endValue2.y = endValue;
			endValue2.z = 0f;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue2, duration);
			if (tweenerCore != null && tweenerCore._003Cactive_003Ek__BackingField)
			{
				tweenerCore.plugOptions = (VectorOptions)4;
				_ = 0;
			}
			Tweener tweener = ((Tweener)tweenerCore).SetTarget((object)target);
			return tweenerCore;
		}

		[Token(Token = "0x6000104")]
		[Address(RVA = "0xC14D88", Offset = "0xC14D88", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tv32 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, methodInfo, v35, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv54 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v35, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv59 = DG.Tweening.DOTween;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v35, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv63 = Il2CppMethodInfo;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, methodInfo, v35, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv79 = Il2CppMethodInfo;\n\tv80 = \"il2cpp_codegen_initialize_runtime_metadata\"(v79, methodInfo, v35, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv86 = Il2CppMethodInfo;\n\tv87 = \"il2cpp_codegen_initialize_runtime_metadata\"(v86, methodInfo, v35, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv132 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass48_0;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v132, methodInfo, v35, v36, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A35713]) = v50;\nL_002D:\n\tv52 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass48_0();\n\tSystem.Object::.ctor(v52);\n\tv52.target = target;\n\tv76 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v76, v52, Il2CppMethodInfo);\n\tv89 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v89, v52, Il2CppMethodInfo);\n\tgoto L_005A;\n\tv140 = \"il2cpp_codegen_runtime_class_init\"(v136, v134, v133, v104, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\nL_005A:\n\t// 90 MakeStruct v93 @ AGGC18EC4_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, 0, endValue @ V0 (System.Single)\n\tv146 = DG.Tweening.DOTween::To(v76, v89, v93, duration);\n\tv148 = v146 == 0;\n\tif (v148) goto L_0068;\n\tv150 = ~v146.<active>k__BackingField;\n\tif (v150) goto L_0068;\n\tv146.plugOptions = 8;\n\t*([v146 @ X0_v12 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+14C]) = 0;\nL_0068:\n\tv153 = DG.Tweening.TweenSettingsExtensions::SetTarget(v146, v52.target);\n\treturn v146;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> DOScaleZ(this Transform target, float endValue, float duration)
		{
			//IL_00d4: Expected O, but got I4
			DOGetter<Vector3> getter = () => target.localScale;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.localScale = x;
			};
			Vector3 endValue2 = default(Vector3);
			endValue2.x = 0f;
			endValue2.y = 0f;
			endValue2.z = endValue;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue2, duration);
			if (tweenerCore != null && tweenerCore._003Cactive_003Ek__BackingField)
			{
				tweenerCore.plugOptions = (VectorOptions)8;
				_ = 0;
			}
			Tweener tweener = ((Tweener)tweenerCore).SetTarget((object)target);
			return tweenerCore;
		}

		[Token(Token = "0x6000105")]
		[Address(RVA = "0xC14F1C", Offset = "0xC14F1C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = DG.Tweening.ShortcutExtensions::LookAt(target, towards, duration, axisConstraint, up, methodInfo);\n\treturn returnVal1;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOLookAt(this Transform target, Vector3 towards, float duration, AxisConstraint axisConstraint = AxisConstraint.None, Vector3? up = null)
		{
			IntPtr intPtr = default(IntPtr);
			return target.LookAt(towards, duration, axisConstraint, up, (byte)(nint)intPtr != 0);
		}

		[Token(Token = "0x6000106")]
		[Address(RVA = "0xC15190", Offset = "0xC15190", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = DG.Tweening.ShortcutExtensions::LookAt(target, towards, duration, axisConstraint, up, methodInfo);\n\treturn returnVal1;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DODynamicLookAt(this Transform target, Vector3 towards, float duration, AxisConstraint axisConstraint = AxisConstraint.None, Vector3? up = null)
		{
			IntPtr intPtr = default(IntPtr);
			return target.LookAt(towards, duration, axisConstraint, up, (byte)(nint)intPtr != 0);
		}

		[Token(Token = "0x6000107")]
		[Address(RVA = "0xC14F24", Offset = "0xC14F24", Length = "0x26C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0046;\n\tv59 = DG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, axisConstraint, up, dynamic, methodInfo, v61, v62, v63, towards, v0, v2, duration, v64, v65, v66, v67);\n\tv75 = DG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, axisConstraint, up, dynamic, methodInfo, v61, v62, v63, towards, v0, v2, duration, v64, v65, v66, v67);\n\tv80 = DG.Tweening.DOTween;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, axisConstraint, up, dynamic, methodInfo, v61, v62, v63, towards, v0, v2, duration, v64, v65, v66, v67);\n\tv84 = Il2CppMethodInfo;\n\tv85 = \"il2cpp_codegen_initialize_runtime_metadata\"(v84, axisConstraint, up, dynamic, methodInfo, v61, v62, v63, towards, v0, v2, duration, v64, v65, v66, v67);\n\tv136 = Il2CppMethodInfo;\n\tv137 = \"il2cpp_codegen_initialize_runtime_metadata\"(v136, axisConstraint, up, dynamic, methodInfo, v61, v62, v63, towards, v0, v2, duration, v64, v65, v66, v67);\n\tv142 = Il2CppMethodInfo;\n\tv143 = \"il2cpp_codegen_initialize_runtime_metadata\"(v142, axisConstraint, up, dynamic, methodInfo, v61, v62, v63, towards, v0, v2, duration, v64, v65, v66, v67);\n\tv209 = Il2CppMethodInfo;\n\tv210 = \"il2cpp_codegen_initialize_runtime_metadata\"(v209, axisConstraint, up, dynamic, methodInfo, v61, v62, v63, towards, v0, v2, duration, v64, v65, v66, v67);\n\tv214 = Il2CppMethodInfo;\n\tv215 = \"il2cpp_codegen_initialize_runtime_metadata\"(v214, axisConstraint, up, dynamic, methodInfo, v61, v62, v63, towards, v0, v2, duration, v64, v65, v66, v67);\n\tv220 = Il2CppMethodInfo;\n\tv221 = \"il2cpp_codegen_initialize_runtime_metadata\"(v220, axisConstraint, up, dynamic, methodInfo, v61, v62, v63, towards, v0, v2, duration, v64, v65, v66, v67);\n\tv228 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass51_0;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v228, axisConstraint, up, dynamic, methodInfo, v61, v62, v63, towards, v0, v2, duration, v64, v65, v66, v67);\n\tv71 = 1;\n\t*([1A35714]) = v71;\nL_0046:\n\tv73 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass51_0();\n\tSystem.Object::.ctor(v73);\n\tv73.target = target;\n\tv101 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>::.ctor(v101, v73, Il2CppMethodInfo);\n\tv145 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>::.ctor(v145, v73, Il2CppMethodInfo);\n\tgoto L_0076;\n\tv222 = \"il2cpp_codegen_runtime_class_init\"(v216, v212, v211, v110, methodInfo, v61, v62, v63, towards, v0, v2, duration, v64, v65, v66, v67);\nL_0076:\n\tv226 = DG.Tweening.DOTween::To(v101, v145, towards, duration);\n\tv231 = DG.Tweening.TweenSettingsExtensions::SetTarget(v226, v73.target);\n\tv121 = DG.Tweening.Core.Extensions::SetSpecialStartupMode(v231, 1);\n\tv233 = up & 0xFF;\n\tv155 = v233 == 0;\n\t*([v121 @ X0_v15 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+14C]) = axisConstraint;\n\tif (v155) goto L_0093;\n\tv163 = System.Nullable`1<UnityEngine.Vector3>::get_Value(&up @ X2 (System.Nullable`1<UnityEngine.Vector3>));\n\tv207 = v163.y;\n\tv205 = v163.z;\n\tgoto L_00A0;\nL_0093:\n\tgoto L_009B;\n\tv246 = UnityEngine.Vector3;\n\tv247 = \"il2cpp_codegen_initialize_runtime_metadata\"(v246, v119, v112, v110, methodInfo, v61, v62, v63, v108, v133, v131, v106, v64, v65, v66, v67);\n\tv250 = 1;\n\t*([1A3575B]) = v250;\nL_009B:\n\tv253 = UnityEngine.Vector3;\n\tv254 = *([v253 @ X8_v14 (Il2CppClass<UnityEngine.Vector3>)+B8]);\n\tv163 = v254.upVector;\n\tv207 = *([v254 @ X8_v15 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]);\n\tv205 = *([v254 @ X8_v15 (Il2CppStaticFields<UnityEngine.Vector3>)+20]);\nL_00A0:\n\t*([v121 @ X0_v15 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+150]) = v163;\n\t*([v121 @ X0_v15 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+154]) = v207;\n\t*([v121 @ X0_v15 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+158]) = v205;\n\tv262 = methodInfo & 1;\n\tv181 = v262 == 0;\n\tif (v181) goto L_00AC;\n\t*([v121 @ X0_v15 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+160]) = towards;\n\t*([v121 @ X0_v15 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+164]) = towards.y;\n\t*([v121 @ X0_v15 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+15C]) = 1;\n\t*([v121 @ X0_v15 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+168]) = towards.z;\n\tgoto L_00BF;\nL_00AC:\n\t*([v121 @ X0_v15 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+15C]) = 0;\nL_00BF:\n\treturn v121;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 126 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Tweener LookAt(this Transform target, Vector3 towards, float duration, AxisConstraint axisConstraint, Vector3? up, bool dynamic)
		{
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Expected I4, but got Unknown
			//IL_017c: Expected I, but got O
			//IL_0185: Expected I, but got O
			//IL_019e: Expected F4, but got I
			//IL_01ae: Expected F4, but got I
			DOGetter<Quaternion> getter = () => target.rotation;
			DOSetter<Quaternion> setter = delegate(Quaternion x)
			{
				target.rotation = x;
			};
			TweenerCore<Quaternion, Vector3, QuaternionOptions> t = DOTween.To(getter, setter, towards, duration);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> t2 = t.SetTarget(target);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> result = t2.SetSpecialStartupMode(SpecialStartupMode.SetLookAt);
			if (((_003F?)up & 0xFF) != 0)
			{
				Vector3? vector = default(Vector3?);
				Vector3 value = vector.Value;
				float y = value.y;
				float z = value.z;
			}
			else
			{
				nint num = (nint)typeof(Vector3);
				nint num2 = (nint)Vector3.zero;
				Vector3 value = Vector3.upVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ X8_v15 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
				float y = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ X8_v15 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
				float z = 0f;
			}
			IntPtr intPtr = default(IntPtr);
			if ((int)((nint)intPtr & 1) != 0)
			{
				_ = towards.y;
				_ = 1;
				_ = towards.z;
			}
			else
			{
				_ = 0;
			}
			return result;
		}

		[Token(Token = "0x6000108")]
		[Address(RVA = "0xC151A0", Offset = "0xC151A0", Length = "0x230")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003C;\n\tv46 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, vibrato, snapping, methodInfo, v49, v50, v51, v52, punch, v0, v2, duration, elasticity, v53, v54, v55);\n\tv63 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, vibrato, snapping, methodInfo, v49, v50, v51, v52, punch, v0, v2, duration, elasticity, v53, v54, v55);\n\tv68 = DG.Tweening.DOTween;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, vibrato, snapping, methodInfo, v49, v50, v51, v52, punch, v0, v2, duration, elasticity, v53, v54, v55);\n\tv72 = UnityEngine.Debug;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, vibrato, snapping, methodInfo, v49, v50, v51, v52, punch, v0, v2, duration, elasticity, v53, v54, v55);\n\tv87 = Il2CppMethodInfo;\n\tv88 = \"il2cpp_codegen_initialize_runtime_metadata\"(v87, vibrato, snapping, methodInfo, v49, v50, v51, v52, punch, v0, v2, duration, elasticity, v53, v54, v55);\n\tv98 = Il2CppMethodInfo;\n\tv99 = \"il2cpp_codegen_initialize_runtime_metadata\"(v98, vibrato, snapping, methodInfo, v49, v50, v51, v52, punch, v0, v2, duration, elasticity, v53, v54, v55);\n\tv203 = Il2CppMethodInfo;\n\tv204 = \"il2cpp_codegen_initialize_runtime_metadata\"(v203, vibrato, snapping, methodInfo, v49, v50, v51, v52, punch, v0, v2, duration, elasticity, v53, v54, v55);\n\tv224 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass52_0;\n\tv225 = \"il2cpp_codegen_initialize_runtime_metadata\"(v224, vibrato, snapping, methodInfo, v49, v50, v51, v52, punch, v0, v2, duration, elasticity, v53, v54, v55);\n\tv253 = \"DOPunchPosition: duration can't be 0, returning NULL without creating a tween\";\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v253, vibrato, snapping, methodInfo, v49, v50, v51, v52, punch, v0, v2, duration, elasticity, v53, v54, v55);\n\tv59 = 1;\n\t*([1A35715]) = v59;\nL_003C:\n\tv61 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass52_0();\n\tSystem.Object::.ctor(v61);\n\tv74 = duration < 0;\n\tv75 = ~v74;\n\tv78 = duration == 0;\n\tv61.target = target;\n\tv83 = ~v75;\n\tv84 = v83 | v78;\n\tif (v84) goto L_0088;\n\tv92 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v92, v61, Il2CppMethodInfo);\n\tv208 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v208, v61, Il2CppMethodInfo);\n\tgoto L_0076;\n\tv260 = \"il2cpp_codegen_runtime_class_init\"(v256, v228, v231, v229, v49, v50, v51, v52, punch, v0, v2, duration, elasticity, v53, v54, v55);\nL_0076:\n\tv265 = DG.Tweening.DOTween::Punch(v92, v208, punch, duration, vibrato, elasticity);\n\tv241 = DG.Tweening.TweenSettingsExtensions::SetTarget(v265, v61.target);\n\tv242 = v241 == 0;\n\tif (v242) goto L_00B9;\n\tv243 = ~v241.<active>k__BackingField;\n\tif (v243) goto L_00B9;\n\t*([v241 @ X0_v24 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3[], DG.Tweening.Plugins.Options.Vector3ArrayOptions>)+144]) = snapping;\n\tgoto L_00B9;\nL_0088:\n\tgoto L_009D;\n\tv107 = DG.Tweening.Core.Debugger;\n\tv108 = \"il2cpp_codegen_initialize_runtime_metadata\"(v107, v65, snapping, methodInfo, v49, v50, v51, v52, punch, v0, v2, duration, elasticity, v53, v54, v55);\n\tv111 = 1;\n\t*([1A35757]) = v111;\nL_009D:\n\tv127 = v115._logPriority < 1;\n\tif (v127) goto L_FFFFFFFF;\n\tgoto L_00AB;\n\tv232 = \"il2cpp_codegen_runtime_class_init\"(v211, v65, snapping, methodInfo, v49, v50, v51, v52, punch, v0, v2, duration, elasticity, v53, v54, v55);\nL_00AB:\n\tUnityEngine.Debug::LogWarning(\"DOPunchPosition: duration can't be 0, returning NULL without creating a tween\");\nL_00B9:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 131 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOPunchPosition(this Transform target, Vector3 punch, float duration, int vibrato = 10, float elasticity = 1f, bool snapping = false)
		{
			bool flag = duration < 0f;
			bool flag2 = !flag;
			bool flag3 = duration == 0f;
			Transform target2 = target;
			bool flag4 = !flag2;
			Tweener result;
			if (!(flag4 || flag3))
			{
				DOGetter<Vector3> getter = () => target2.localPosition;
				DOSetter<Vector3> setter = delegate(Vector3 x)
				{
					target2.localPosition = x;
				};
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = DOTween.Punch(getter, setter, punch, duration, vibrato, elasticity);
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> tweenerCore = t.SetTarget(target2);
				bool flag5 = tweenerCore == null;
				result = tweenerCore;
				if (!flag5)
				{
					bool flag6 = !tweenerCore._003Cactive_003Ek__BackingField;
					result = tweenerCore;
					if (!flag6)
					{
						result = tweenerCore;
					}
				}
			}
			else
			{
				if (Debugger._logPriority >= 1)
				{
					Debug.LogWarning("DOPunchPosition: duration can't be 0, returning NULL without creating a tween");
				}
				result = null;
			}
			return result;
		}

		[Token(Token = "0x6000109")]
		[Address(RVA = "0xC153F0", Offset = "0xC153F0", Length = "0x22C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003A;\n\tv42 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, vibrato, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\n\tv60 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, vibrato, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\n\tv65 = DG.Tweening.DOTween;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, vibrato, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\n\tv69 = UnityEngine.Debug;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, vibrato, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\n\tv84 = Il2CppMethodInfo;\n\tv85 = \"il2cpp_codegen_initialize_runtime_metadata\"(v84, vibrato, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\n\tv95 = Il2CppMethodInfo;\n\tv96 = \"il2cpp_codegen_initialize_runtime_metadata\"(v95, vibrato, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\n\tv203 = Il2CppMethodInfo;\n\tv204 = \"il2cpp_codegen_initialize_runtime_metadata\"(v203, vibrato, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\n\tv220 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass53_0;\n\tv221 = \"il2cpp_codegen_initialize_runtime_metadata\"(v220, vibrato, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\n\tv231 = \"DOPunchScale: duration can't be 0, returning NULL without creating a tween\";\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v231, vibrato, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\n\tv56 = 1;\n\t*([1A35716]) = v56;\nL_003A:\n\tv58 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass53_0();\n\tSystem.Object::.ctor(v58);\n\tv71 = duration < 0;\n\tv72 = ~v71;\n\tv75 = duration == 0;\n\tv58.target = target;\n\tv80 = ~v72;\n\tv81 = v80 | v75;\n\tif (v81) goto L_008A;\n\tv89 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v89, v58, Il2CppMethodInfo);\n\tv208 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v208, v58, Il2CppMethodInfo);\n\tgoto L_0074;\n\tv237 = \"il2cpp_codegen_runtime_class_init\"(v234, v224, v226, v140, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\nL_0074:\n\tv242 = DG.Tweening.DOTween::Punch(v89, v208, punch, duration, vibrato, elasticity);\n\treturnVal3 = DG.Tweening.TweenSettingsExtensions::SetTarget(v242, v58.target);\n\treturn returnVal3;\nL_008A:\n\tgoto L_009F;\n\tv104 = DG.Tweening.Core.Debugger;\n\tv105 = \"il2cpp_codegen_initialize_runtime_metadata\"(v104, v62, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\n\tv108 = 1;\n\t*([1A35757]) = v108;\nL_009F:\n\tv124 = v112._logPriority < 1;\n\tif (v124) goto L_00BA;\n\tgoto L_00AD;\n\tv227 = \"il2cpp_codegen_runtime_class_init\"(v211, v62, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\nL_00AD:\n\tUnityEngine.Debug::LogWarning(\"DOPunchScale: duration can't be 0, returning NULL without creating a tween\");\nL_00BA:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 137 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x600010A")]
		[Address(RVA = "0xC15624", Offset = "0xC15624", Length = "0x22C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003A;\n\tv42 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, vibrato, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\n\tv60 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, vibrato, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\n\tv65 = DG.Tweening.DOTween;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, vibrato, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\n\tv69 = UnityEngine.Debug;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, vibrato, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\n\tv84 = Il2CppMethodInfo;\n\tv85 = \"il2cpp_codegen_initialize_runtime_metadata\"(v84, vibrato, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\n\tv95 = Il2CppMethodInfo;\n\tv96 = \"il2cpp_codegen_initialize_runtime_metadata\"(v95, vibrato, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\n\tv203 = Il2CppMethodInfo;\n\tv204 = \"il2cpp_codegen_initialize_runtime_metadata\"(v203, vibrato, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\n\tv220 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass54_0;\n\tv221 = \"il2cpp_codegen_initialize_runtime_metadata\"(v220, vibrato, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\n\tv231 = \"DOPunchRotation: duration can't be 0, returning NULL without creating a tween\";\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v231, vibrato, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\n\tv56 = 1;\n\t*([1A35717]) = v56;\nL_003A:\n\tv58 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass54_0();\n\tSystem.Object::.ctor(v58);\n\tv71 = duration < 0;\n\tv72 = ~v71;\n\tv75 = duration == 0;\n\tv58.target = target;\n\tv80 = ~v72;\n\tv81 = v80 | v75;\n\tif (v81) goto L_008A;\n\tv89 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v89, v58, Il2CppMethodInfo);\n\tv208 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v208, v58, Il2CppMethodInfo);\n\tgoto L_0074;\n\tv237 = \"il2cpp_codegen_runtime_class_init\"(v234, v224, v226, v140, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\nL_0074:\n\tv242 = DG.Tweening.DOTween::Punch(v89, v208, punch, duration, vibrato, elasticity);\n\treturnVal3 = DG.Tweening.TweenSettingsExtensions::SetTarget(v242, v58.target);\n\treturn returnVal3;\nL_008A:\n\tgoto L_009F;\n\tv104 = DG.Tweening.Core.Debugger;\n\tv105 = \"il2cpp_codegen_initialize_runtime_metadata\"(v104, v62, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\n\tv108 = 1;\n\t*([1A35757]) = v108;\nL_009F:\n\tv124 = v112._logPriority < 1;\n\tif (v124) goto L_00BA;\n\tgoto L_00AD;\n\tv227 = \"il2cpp_codegen_runtime_class_init\"(v211, v62, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\nL_00AD:\n\tUnityEngine.Debug::LogWarning(\"DOPunchRotation: duration can't be 0, returning NULL without creating a tween\");\nL_00BA:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 137 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
					Vector3 vector = default(Vector3);
					float x2 = vector.x * ((float)Math.PI / 180f);
					float y = x.y * ((float)Math.PI / 180f);
					float z = x.z * ((float)Math.PI / 180f);
					Vector3 vector2 = default(Vector3);
					vector2.x = x2;
					vector2.y = y;
					vector2.z = z;
					Quaternion localRotation = Quaternion.Euler(vector2 * 57.29578f);
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

		[Token(Token = "0x600010B")]
		[Address(RVA = "0xC15858", Offset = "0xC15858", Length = "0x254")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003D;\n\tv46 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, vibrato, snapping, fadeOut, randomnessMode, methodInfo, v49, v50, duration, strength, randomness, v51, v52, v53, v54, v55);\n\tv63 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, vibrato, snapping, fadeOut, randomnessMode, methodInfo, v49, v50, duration, strength, randomness, v51, v52, v53, v54, v55);\n\tv68 = DG.Tweening.DOTween;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, vibrato, snapping, fadeOut, randomnessMode, methodInfo, v49, v50, duration, strength, randomness, v51, v52, v53, v54, v55);\n\tv72 = UnityEngine.Debug;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, vibrato, snapping, fadeOut, randomnessMode, methodInfo, v49, v50, duration, strength, randomness, v51, v52, v53, v54, v55);\n\tv87 = Il2CppMethodInfo;\n\tv88 = \"il2cpp_codegen_initialize_runtime_metadata\"(v87, vibrato, snapping, fadeOut, randomnessMode, methodInfo, v49, v50, duration, strength, randomness, v51, v52, v53, v54, v55);\n\tv98 = Il2CppMethodInfo;\n\tv99 = \"il2cpp_codegen_initialize_runtime_metadata\"(v98, vibrato, snapping, fadeOut, randomnessMode, methodInfo, v49, v50, duration, strength, randomness, v51, v52, v53, v54, v55);\n\tv200 = Il2CppMethodInfo;\n\tv201 = \"il2cpp_codegen_initialize_runtime_metadata\"(v200, vibrato, snapping, fadeOut, randomnessMode, methodInfo, v49, v50, duration, strength, randomness, v51, v52, v53, v54, v55);\n\tv221 = Il2CppMethodInfo;\n\tv222 = \"il2cpp_codegen_initialize_runtime_metadata\"(v221, vibrato, snapping, fadeOut, randomnessMode, methodInfo, v49, v50, duration, strength, randomness, v51, v52, v53, v54, v55);\n\tv250 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass55_0;\n\tv251 = \"il2cpp_codegen_initialize_runtime_metadata\"(v250, vibrato, snapping, fadeOut, randomnessMode, methodInfo, v49, v50, duration, strength, randomness, v51, v52, v53, v54, v55);\n\tv259 = \"DOShakePosition: duration can't be 0, returning NULL without creating a tween\";\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v259, vibrato, snapping, fadeOut, randomnessMode, methodInfo, v49, v50, duration, strength, randomness, v51, v52, v53, v54, v55);\n\tv59 = 1;\n\t*([1A35718]) = v59;\nL_003D:\n\tv61 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass55_0();\n\tSystem.Object::.ctor(v61);\n\tv74 = duration < 0;\n\tv75 = ~v74;\n\tv78 = duration == 0;\n\tv61.target = target;\n\tv83 = ~v75;\n\tv84 = v83 | v78;\n\tif (v84) goto L_008E;\n\tv92 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v92, v61, Il2CppMethodInfo);\n\tv205 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v205, v61, Il2CppMethodInfo);\n\tgoto L_0077;\n\tv260 = \"il2cpp_codegen_runtime_class_init\"(v254, v225, v228, v226, randomnessMode, methodInfo, v49, v50, duration, strength, randomness, v51, v52, v53, v54, v55);\nL_0077:\n\tv265 = DG.Tweening.DOTween::Shake(v92, v205, duration, strength, vibrato, randomness, 0, fadeOut, randomnessMode);\n\tv270 = DG.Tweening.TweenSettingsExtensions::SetTarget(v265, v61.target);\n\tv240 = DG.Tweening.Core.Extensions::SetSpecialStartupMode(v270, 2);\n\tv241 = v240 == 0;\n\tif (v241) goto L_00BF;\n\tv242 = ~v240.<active>k__BackingField;\n\tif (v242) goto L_00BF;\n\t*([v240 @ X0_v25 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3[], DG.Tweening.Plugins.Options.Vector3ArrayOptions>)+144]) = snapping;\n\tgoto L_00BF;\nL_008E:\n\tgoto L_00A3;\n\tv107 = DG.Tweening.Core.Debugger;\n\tv108 = \"il2cpp_codegen_initialize_runtime_metadata\"(v107, v65, snapping, fadeOut, randomnessMode, methodInfo, v49, v50, duration, strength, randomness, v51, v52, v53, v54, v55);\n\tv111 = 1;\n\t*([1A35757]) = v111;\nL_00A3:\n\tv127 = v115._logPriority < 1;\n\tif (v127) goto L_FFFFFFFF;\n\tgoto L_00B1;\n\tv229 = \"il2cpp_codegen_runtime_class_init\"(v208, v65, snapping, fadeOut, randomnessMode, methodInfo, v49, v50, duration, strength, randomness, v51, v52, v53, v54, v55);\nL_00B1:\n\tUnityEngine.Debug::LogWarning(\"DOShakePosition: duration can't be 0, returning NULL without creating a tween\");\nL_00BF:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 134 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOShakePosition(this Transform target, float duration, float strength = 1f, int vibrato = 10, float randomness = 90f, bool snapping = false, bool fadeOut = true, ShakeRandomnessMode randomnessMode = ShakeRandomnessMode.Full)
		{
			bool flag = duration < 0f;
			bool flag2 = !flag;
			bool flag3 = duration == 0f;
			Transform target2 = target;
			bool flag4 = !flag2;
			Tweener result;
			if (!(flag4 || flag3))
			{
				DOGetter<Vector3> getter = () => target2.localPosition;
				DOSetter<Vector3> setter = delegate(Vector3 x)
				{
					target2.localPosition = x;
				};
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = DOTween.Shake(getter, setter, duration, strength, vibrato, randomness, ignoreZAxis: false, fadeOut, randomnessMode);
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t2 = t.SetTarget(target2);
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> tweenerCore = t2.SetSpecialStartupMode(SpecialStartupMode.SetShake);
				bool flag5 = tweenerCore == null;
				result = tweenerCore;
				if (!flag5)
				{
					bool flag6 = !tweenerCore._003Cactive_003Ek__BackingField;
					result = tweenerCore;
					if (!flag6)
					{
						result = tweenerCore;
					}
				}
			}
			else
			{
				if (Debugger._logPriority >= 1)
				{
					Debug.LogWarning("DOShakePosition: duration can't be 0, returning NULL without creating a tween");
				}
				result = null;
			}
			return result;
		}

		[Token(Token = "0x600010C")]
		[Address(RVA = "0xC15AB4", Offset = "0xC15AB4", Length = "0x268")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0043;\n\tv54 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, vibrato, snapping, fadeOut, randomnessMode, methodInfo, v57, v58, duration, strength, v0, v2, randomness, v59, v60, v61);\n\tv69 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, vibrato, snapping, fadeOut, randomnessMode, methodInfo, v57, v58, duration, strength, v0, v2, randomness, v59, v60, v61);\n\tv74 = DG.Tweening.DOTween;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, vibrato, snapping, fadeOut, randomnessMode, methodInfo, v57, v58, duration, strength, v0, v2, randomness, v59, v60, v61);\n\tv78 = UnityEngine.Debug;\n\tv79 = \"il2cpp_codegen_initialize_runtime_metadata\"(v78, vibrato, snapping, fadeOut, randomnessMode, methodInfo, v57, v58, duration, strength, v0, v2, randomness, v59, v60, v61);\n\tv93 = Il2CppMethodInfo;\n\tv94 = \"il2cpp_codegen_initialize_runtime_metadata\"(v93, vibrato, snapping, fadeOut, randomnessMode, methodInfo, v57, v58, duration, strength, v0, v2, randomness, v59, v60, v61);\n\tv104 = Il2CppMethodInfo;\n\tv105 = \"il2cpp_codegen_initialize_runtime_metadata\"(v104, vibrato, snapping, fadeOut, randomnessMode, methodInfo, v57, v58, duration, strength, v0, v2, randomness, v59, v60, v61);\n\tv215 = Il2CppMethodInfo;\n\tv216 = \"il2cpp_codegen_initialize_runtime_metadata\"(v215, vibrato, snapping, fadeOut, randomnessMode, methodInfo, v57, v58, duration, strength, v0, v2, randomness, v59, v60, v61);\n\tv236 = Il2CppMethodInfo;\n\tv237 = \"il2cpp_codegen_initialize_runtime_metadata\"(v236, vibrato, snapping, fadeOut, randomnessMode, methodInfo, v57, v58, duration, strength, v0, v2, randomness, v59, v60, v61);\n\tv267 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass56_0;\n\tv268 = \"il2cpp_codegen_initialize_runtime_metadata\"(v267, vibrato, snapping, fadeOut, randomnessMode, methodInfo, v57, v58, duration, strength, v0, v2, randomness, v59, v60, v61);\n\tv276 = \"DOShakePosition: duration can't be 0, returning NULL without creating a tween\";\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v276, vibrato, snapping, fadeOut, randomnessMode, methodInfo, v57, v58, duration, strength, v0, v2, randomness, v59, v60, v61);\n\tv65 = 1;\n\t*([1A35719]) = v65;\nL_0043:\n\tv67 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass56_0();\n\tSystem.Object::.ctor(v67);\n\tv80 = duration < 0;\n\tv81 = ~v80;\n\tv84 = duration == 0;\n\tv67.target = target;\n\tv89 = ~v81;\n\tv90 = v89 | v84;\n\tif (v90) goto L_0096;\n\tv98 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v98, v67, Il2CppMethodInfo);\n\tv220 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v220, v67, Il2CppMethodInfo);\n\tgoto L_007F;\n\tv277 = \"il2cpp_codegen_runtime_class_init\"(v271, v240, v243, v241, randomnessMode, methodInfo, v57, v58, duration, strength, v0, v2, randomness, v59, v60, v61);\nL_007F:\n\tv282 = DG.Tweening.DOTween::Shake(v98, v220, duration, strength, vibrato, randomness, fadeOut, randomnessMode);\n\tv287 = DG.Tweening.TweenSettingsExtensions::SetTarget(v282, v67.target);\n\tv255 = DG.Tweening.Core.Extensions::SetSpecialStartupMode(v287, 2);\n\tv256 = v255 == 0;\n\tif (v256) goto L_00C9;\n\tv257 = ~v255.<active>k__BackingField;\n\tif (v257) goto L_00C9;\n\t*([v255 @ X0_v25 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3[], DG.Tweening.Plugins.Options.Vector3ArrayOptions>)+144]) = snapping;\n\tgoto L_00C9;\nL_0096:\n\tgoto L_00AB;\n\tv113 = DG.Tweening.Core.Debugger;\n\tv114 = \"il2cpp_codegen_initialize_runtime_metadata\"(v113, v71, snapping, fadeOut, randomnessMode, methodInfo, v57, v58, duration, strength, v0, v2, randomness, v59, v60, v61);\n\tv117 = 1;\n\t*([1A35757]) = v117;\nL_00AB:\n\tv133 = v121._logPriority < 1;\n\tif (v133) goto L_FFFFFFFF;\n\tgoto L_00B9;\n\tv244 = \"il2cpp_codegen_runtime_class_init\"(v223, v71, snapping, fadeOut, randomnessMode, methodInfo, v57, v58, duration, strength, v0, v2, randomness, v59, v60, v61);\nL_00B9:\n\tUnityEngine.Debug::LogWarning(\"DOShakePosition: duration can't be 0, returning NULL without creating a tween\");\nL_00C9:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 144 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOShakePosition(this Transform target, float duration, Vector3 strength, int vibrato = 10, float randomness = 90f, bool snapping = false, bool fadeOut = true, ShakeRandomnessMode randomnessMode = ShakeRandomnessMode.Full)
		{
			bool flag = duration < 0f;
			bool flag2 = !flag;
			bool flag3 = duration == 0f;
			Transform target2 = target;
			bool flag4 = !flag2;
			Tweener result;
			if (!(flag4 || flag3))
			{
				DOGetter<Vector3> getter = () => target2.localPosition;
				DOSetter<Vector3> setter = delegate(Vector3 x)
				{
					target2.localPosition = x;
				};
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = DOTween.Shake(getter, setter, duration, strength, vibrato, randomness, fadeOut, randomnessMode);
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t2 = t.SetTarget(target2);
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> tweenerCore = t2.SetSpecialStartupMode(SpecialStartupMode.SetShake);
				bool flag5 = tweenerCore == null;
				result = tweenerCore;
				if (!flag5)
				{
					bool flag6 = !tweenerCore._003Cactive_003Ek__BackingField;
					result = tweenerCore;
					if (!flag6)
					{
						result = tweenerCore;
					}
				}
			}
			else
			{
				if (Debugger._logPriority >= 1)
				{
					Debug.LogWarning("DOShakePosition: duration can't be 0, returning NULL without creating a tween");
				}
				result = null;
			}
			return result;
		}

		[Token(Token = "0x600010D")]
		[Address(RVA = "0xC15D24", Offset = "0xC15D24", Length = "0x250")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003B;\n\tv42 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv60 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv65 = DG.Tweening.DOTween;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv69 = UnityEngine.Debug;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv84 = Il2CppMethodInfo;\n\tv85 = \"il2cpp_codegen_initialize_runtime_metadata\"(v84, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv95 = Il2CppMethodInfo;\n\tv96 = \"il2cpp_codegen_initialize_runtime_metadata\"(v95, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv200 = Il2CppMethodInfo;\n\tv201 = \"il2cpp_codegen_initialize_runtime_metadata\"(v200, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv217 = Il2CppMethodInfo;\n\tv218 = \"il2cpp_codegen_initialize_runtime_metadata\"(v217, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv229 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass57_0;\n\tv230 = \"il2cpp_codegen_initialize_runtime_metadata\"(v229, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv237 = \"DOShakeRotation: duration can't be 0, returning NULL without creating a tween\";\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v237, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv56 = 1;\n\t*([1A3571A]) = v56;\nL_003B:\n\tv58 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass57_0();\n\tSystem.Object::.ctor(v58);\n\tv71 = duration < 0;\n\tv72 = ~v71;\n\tv75 = duration == 0;\n\tv58.target = target;\n\tv80 = ~v72;\n\tv81 = v80 | v75;\n\tif (v81) goto L_0090;\n\tv89 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v89, v58, Il2CppMethodInfo);\n\tv205 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v205, v58, Il2CppMethodInfo);\n\tgoto L_0075;\n\tv238 = \"il2cpp_codegen_runtime_class_init\"(v233, v221, v224, v222, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\nL_0075:\n\tv243 = DG.Tweening.DOTween::Shake(v89, v205, duration, strength, vibrato, randomness, 0, fadeOut, randomnessMode);\n\tv248 = DG.Tweening.TweenSettingsExtensions::SetTarget(v243, v58.target);\n\treturnVal3 = DG.Tweening.Core.Extensions::SetSpecialStartupMode(v248, 2);\n\treturn returnVal3;\nL_0090:\n\tgoto L_00A5;\n\tv104 = DG.Tweening.Core.Debugger;\n\tv105 = \"il2cpp_codegen_initialize_runtime_metadata\"(v104, v62, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv108 = 1;\n\t*([1A35757]) = v108;\nL_00A5:\n\tv124 = v112._logPriority < 1;\n\tif (v124) goto L_00C0;\n\tgoto L_00B3;\n\tv225 = \"il2cpp_codegen_runtime_class_init\"(v208, v62, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\nL_00B3:\n\tUnityEngine.Debug::LogWarning(\"DOShakeRotation: duration can't be 0, returning NULL without creating a tween\");\nL_00C0:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 140 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOShakeRotation(this Transform target, float duration, float strength = 90f, int vibrato = 10, float randomness = 90f, bool fadeOut = true, ShakeRandomnessMode randomnessMode = ShakeRandomnessMode.Full)
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
					Vector3 vector = default(Vector3);
					float x2 = vector.x * ((float)Math.PI / 180f);
					float y = x.y * ((float)Math.PI / 180f);
					float z = x.z * ((float)Math.PI / 180f);
					Vector3 vector2 = default(Vector3);
					vector2.x = x2;
					vector2.y = y;
					vector2.z = z;
					Quaternion localRotation = Quaternion.Euler(vector2 * 57.29578f);
					target2.localRotation = localRotation;
				};
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = DOTween.Shake(getter, setter, duration, strength, vibrato, randomness, ignoreZAxis: false, fadeOut, randomnessMode);
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t2 = t.SetTarget(target2);
				return t2.SetSpecialStartupMode(SpecialStartupMode.SetShake);
			}
			if (Debugger._logPriority >= 1)
			{
				Debug.LogWarning("DOShakeRotation: duration can't be 0, returning NULL without creating a tween");
			}
			return null;
		}

		[Token(Token = "0x600010E")]
		[Address(RVA = "0xC15F7C", Offset = "0xC15F7C", Length = "0x268")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0041;\n\tv50 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv66 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv71 = DG.Tweening.DOTween;\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv75 = UnityEngine.Debug;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv90 = Il2CppMethodInfo;\n\tv91 = \"il2cpp_codegen_initialize_runtime_metadata\"(v90, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv101 = Il2CppMethodInfo;\n\tv102 = \"il2cpp_codegen_initialize_runtime_metadata\"(v101, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv217 = Il2CppMethodInfo;\n\tv218 = \"il2cpp_codegen_initialize_runtime_metadata\"(v217, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv234 = Il2CppMethodInfo;\n\tv235 = \"il2cpp_codegen_initialize_runtime_metadata\"(v234, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv246 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass58_0;\n\tv247 = \"il2cpp_codegen_initialize_runtime_metadata\"(v246, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv254 = \"DOShakeRotation: duration can't be 0, returning NULL without creating a tween\";\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v254, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv62 = 1;\n\t*([1A3571B]) = v62;\nL_0041:\n\tv64 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass58_0();\n\tSystem.Object::.ctor(v64);\n\tv77 = duration < 0;\n\tv78 = ~v77;\n\tv81 = duration == 0;\n\tv64.target = target;\n\tv86 = ~v78;\n\tv87 = v86 | v81;\n\tif (v87) goto L_009A;\n\tv95 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v95, v64, Il2CppMethodInfo);\n\tv222 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v222, v64, Il2CppMethodInfo);\n\tgoto L_007D;\n\tv255 = \"il2cpp_codegen_runtime_class_init\"(v250, v238, v241, v239, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\nL_007D:\n\tv260 = DG.Tweening.DOTween::Shake(v95, v222, duration, strength, vibrato, randomness, fadeOut, randomnessMode);\n\tv265 = DG.Tweening.TweenSettingsExtensions::SetTarget(v260, v64.target);\n\treturnVal3 = DG.Tweening.Core.Extensions::SetSpecialStartupMode(v265, 2);\n\treturn returnVal3;\nL_009A:\n\tgoto L_00AF;\n\tv110 = DG.Tweening.Core.Debugger;\n\tv111 = \"il2cpp_codegen_initialize_runtime_metadata\"(v110, v68, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv114 = 1;\n\t*([1A35757]) = v114;\nL_00AF:\n\tv130 = v118._logPriority < 1;\n\tif (v130) goto L_00CC;\n\tgoto L_00BD;\n\tv242 = \"il2cpp_codegen_runtime_class_init\"(v225, v68, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\nL_00BD:\n\tUnityEngine.Debug::LogWarning(\"DOShakeRotation: duration can't be 0, returning NULL without creating a tween\");\nL_00CC:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 152 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOShakeRotation(this Transform target, float duration, Vector3 strength, int vibrato = 10, float randomness = 90f, bool fadeOut = true, ShakeRandomnessMode randomnessMode = ShakeRandomnessMode.Full)
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
					Vector3 vector = default(Vector3);
					float x2 = vector.x * ((float)Math.PI / 180f);
					float y = x.y * ((float)Math.PI / 180f);
					float z = x.z * ((float)Math.PI / 180f);
					Vector3 vector2 = default(Vector3);
					vector2.x = x2;
					vector2.y = y;
					vector2.z = z;
					Quaternion localRotation = Quaternion.Euler(vector2 * 57.29578f);
					target2.localRotation = localRotation;
				};
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = DOTween.Shake(getter, setter, duration, strength, vibrato, randomness, fadeOut, randomnessMode);
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t2 = t.SetTarget(target2);
				return t2.SetSpecialStartupMode(SpecialStartupMode.SetShake);
			}
			if (Debugger._logPriority >= 1)
			{
				Debug.LogWarning("DOShakeRotation: duration can't be 0, returning NULL without creating a tween");
			}
			return null;
		}

		[Token(Token = "0x600010F")]
		[Address(RVA = "0xC161EC", Offset = "0xC161EC", Length = "0x2CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003E;\n\tv42 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv60 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv65 = DG.Tweening.DOTween;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv69 = UnityEngine.Debug;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv84 = Il2CppMethodInfo;\n\tv85 = \"il2cpp_codegen_initialize_runtime_metadata\"(v84, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv95 = System.Int32;\n\tv96 = \"il2cpp_codegen_initialize_runtime_metadata\"(v95, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv209 = Il2CppMethodInfo;\n\tv210 = \"il2cpp_codegen_initialize_runtime_metadata\"(v209, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv222 = Il2CppMethodInfo;\n\tv223 = \"il2cpp_codegen_initialize_runtime_metadata\"(v222, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv236 = Il2CppMethodInfo;\n\tv237 = \"il2cpp_codegen_initialize_runtime_metadata\"(v236, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv247 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass59_0;\n\tv248 = \"il2cpp_codegen_initialize_runtime_metadata\"(v247, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv267 = \"DOShakeScale: duration can't be 0, returning NULL without creating a tween\";\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v267, vibrato, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv56 = 1;\n\t*([1A3571C]) = v56;\nL_003E:\n\tv58 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass59_0();\n\tSystem.Object::.ctor(v58);\n\tv71 = duration < 0;\n\tv72 = ~v71;\n\tv75 = duration == 0;\n\tv58.target = target;\n\tv80 = ~v72;\n\tv81 = v80 | v75;\n\tif (v81) goto L_0093;\n\tv89 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v89, v58, Il2CppMethodInfo);\n\tv214 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v214, v58, Il2CppMethodInfo);\n\tgoto L_0078;\n\tv249 = \"il2cpp_codegen_runtime_class_init\"(v240, v226, v229, v227, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\nL_0078:\n\tv254 = DG.Tweening.DOTween::Shake(v89, v214, duration, strength, vibrato, randomness, 0, fadeOut, randomnessMode);\n\tv272 = DG.Tweening.TweenSettingsExtensions::SetTarget(v254, v58.target);\n\treturnVal3 = DG.Tweening.Core.Extensions::SetSpecialStartupMode(v272, 2);\n\treturn returnVal3;\nL_0093:\n\tgoto L_009F;\n\tv104 = DG.Tweening.Core.Debugger;\n\tv105 = \"il2cpp_codegen_initialize_runtime_metadata\"(v104, v62, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv108 = 1;\n\t*([1A35757]) = v108;\nL_009F:\n\tv116 = v115._logPriority;\n\t// 163 Box v119 @ X0_v7 (System.Object), typeof(System.Int32), &v116 @ X8_v7 (System.Int32)\n\tgoto L_00B0;\n\tv230 = v218;\n\tv231 = \"il2cpp_codegen_runtime_class_init\"(v230, v112, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\nL_00B0:\n\tUnityEngine.Debug::Log(v119);\n\tgoto L_00C7;\n\tv256 = DG.Tweening.Core.Debugger;\n\tv257 = \"il2cpp_codegen_initialize_runtime_metadata\"(v256, v234, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\n\tv260 = 1;\n\t*([1A35757]) = v260;\nL_00C7:\n\tv143 = v115._logPriority < 1;\n\tif (v143) goto L_00E0;\n\tgoto L_00D3;\n\tv282 = \"il2cpp_codegen_runtime_class_init\"(v273, v234, fadeOut, randomnessMode, methodInfo, v45, v46, v47, duration, strength, randomness, v48, v49, v50, v51, v52);\nL_00D3:\n\tUnityEngine.Debug::LogWarning(\"DOShakeScale: duration can't be 0, returning NULL without creating a tween\");\nL_00E0:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 159 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOShakeScale(this Transform target, float duration, float strength = 1f, int vibrato = 10, float randomness = 90f, bool fadeOut = true, ShakeRandomnessMode randomnessMode = ShakeRandomnessMode.Full)
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
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = DOTween.Shake(getter, setter, duration, strength, vibrato, randomness, ignoreZAxis: false, fadeOut, randomnessMode);
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

		[Token(Token = "0x6000110")]
		[Address(RVA = "0xC164C0", Offset = "0xC164C0", Length = "0x268")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0041;\n\tv50 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv66 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv71 = DG.Tweening.DOTween;\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv75 = UnityEngine.Debug;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv90 = Il2CppMethodInfo;\n\tv91 = \"il2cpp_codegen_initialize_runtime_metadata\"(v90, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv101 = Il2CppMethodInfo;\n\tv102 = \"il2cpp_codegen_initialize_runtime_metadata\"(v101, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv217 = Il2CppMethodInfo;\n\tv218 = \"il2cpp_codegen_initialize_runtime_metadata\"(v217, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv234 = Il2CppMethodInfo;\n\tv235 = \"il2cpp_codegen_initialize_runtime_metadata\"(v234, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv246 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass60_0;\n\tv247 = \"il2cpp_codegen_initialize_runtime_metadata\"(v246, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv254 = \"DOShakeScale: duration can't be 0, returning NULL without creating a tween\";\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v254, vibrato, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv62 = 1;\n\t*([1A3571D]) = v62;\nL_0041:\n\tv64 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass60_0();\n\tSystem.Object::.ctor(v64);\n\tv77 = duration < 0;\n\tv78 = ~v77;\n\tv81 = duration == 0;\n\tv64.target = target;\n\tv86 = ~v78;\n\tv87 = v86 | v81;\n\tif (v87) goto L_009A;\n\tv95 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v95, v64, Il2CppMethodInfo);\n\tv222 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v222, v64, Il2CppMethodInfo);\n\tgoto L_007D;\n\tv255 = \"il2cpp_codegen_runtime_class_init\"(v250, v238, v241, v239, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\nL_007D:\n\tv260 = DG.Tweening.DOTween::Shake(v95, v222, duration, strength, vibrato, randomness, fadeOut, randomnessMode);\n\tv265 = DG.Tweening.TweenSettingsExtensions::SetTarget(v260, v64.target);\n\treturnVal3 = DG.Tweening.Core.Extensions::SetSpecialStartupMode(v265, 2);\n\treturn returnVal3;\nL_009A:\n\tgoto L_00AF;\n\tv110 = DG.Tweening.Core.Debugger;\n\tv111 = \"il2cpp_codegen_initialize_runtime_metadata\"(v110, v68, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\n\tv114 = 1;\n\t*([1A35757]) = v114;\nL_00AF:\n\tv130 = v118._logPriority < 1;\n\tif (v130) goto L_00CC;\n\tgoto L_00BD;\n\tv242 = \"il2cpp_codegen_runtime_class_init\"(v225, v68, fadeOut, randomnessMode, methodInfo, v53, v54, v55, duration, strength, v0, v2, randomness, v56, v57, v58);\nL_00BD:\n\tUnityEngine.Debug::LogWarning(\"DOShakeScale: duration can't be 0, returning NULL without creating a tween\");\nL_00CC:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 152 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOShakeScale(this Transform target, float duration, Vector3 strength, int vibrato = 10, float randomness = 90f, bool fadeOut = true, ShakeRandomnessMode randomnessMode = ShakeRandomnessMode.Full)
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
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = DOTween.Shake(getter, setter, duration, strength, vibrato, randomness, fadeOut, randomnessMode);
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t2 = t.SetTarget(target2);
				return t2.SetSpecialStartupMode(SpecialStartupMode.SetShake);
			}
			if (Debugger._logPriority >= 1)
			{
				Debug.LogWarning("DOShakeScale: duration can't be 0, returning NULL without creating a tween");
			}
			return null;
		}

		[Token(Token = "0x6000111")]
		[Address(RVA = "0xC16730", Offset = "0xC16730", Length = "0x4D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0063;\n\tv58 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv75 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv80 = DG.Tweening.DOTween;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv84 = DG.Tweening.TweenCallback;\n\tv85 = \"il2cpp_codegen_initialize_runtime_metadata\"(v84, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv127 = Il2CppMethodInfo;\n\tv128 = \"il2cpp_codegen_initialize_runtime_metadata\"(v127, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv132 = Il2CppMethodInfo;\n\tv133 = \"il2cpp_codegen_initialize_runtime_metadata\"(v132, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv209 = Il2CppMethodInfo;\n\tv210 = \"il2cpp_codegen_initialize_runtime_metadata\"(v209, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv225 = Il2CppMethodInfo;\n\tv226 = \"il2cpp_codegen_initialize_runtime_metadata\"(v225, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv235 = Il2CppMethodInfo;\n\tv236 = \"il2cpp_codegen_initialize_runtime_metadata\"(v235, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv247 = Il2CppMethodInfo;\n\tv248 = \"il2cpp_codegen_initialize_runtime_metadata\"(v247, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv252 = Il2CppMethodInfo;\n\tv253 = \"il2cpp_codegen_initialize_runtime_metadata\"(v252, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv259 = Il2CppMethodInfo;\n\tv260 = \"il2cpp_codegen_initialize_runtime_metadata\"(v259, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv264 = Il2CppMethodInfo;\n\tv265 = \"il2cpp_codegen_initialize_runtime_metadata\"(v264, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv271 = Il2CppMethodInfo;\n\tv272 = \"il2cpp_codegen_initialize_runtime_metadata\"(v271, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv283 = Il2CppMethodInfo;\n\tv284 = \"il2cpp_codegen_initialize_runtime_metadata\"(v283, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv288 = Il2CppMethodInfo;\n\tv289 = \"il2cpp_codegen_initialize_runtime_metadata\"(v288, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv301 = Il2CppMethodInfo;\n\tv302 = \"il2cpp_codegen_initialize_runtime_metadata\"(v301, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv306 = Il2CppMethodInfo;\n\tv307 = \"il2cpp_codegen_initialize_runtime_metadata\"(v306, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv313 = Il2CppMethodInfo;\n\tv314 = \"il2cpp_codegen_initialize_runtime_metadata\"(v313, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv321 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass61_0;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v321, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv71 = 1;\n\t*([1A3571E]) = v71;\nL_0063:\n\tv73 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass61_0();\n\tSystem.Object::.ctor(v73);\n\tv88 = numJumps - 1;\n\tv89 = v88 < 0;\n\tv90 = v88 == 0;\n\tv91 = numJumps ^ 1;\n\tv92 = numJumps ^ v88;\n\tv93 = v91 & v92;\n\tv94 = v93 < 0;\n\tv95 = v89 == v94;\n\tv96 = ~v90;\n\tv97 = v95 & v96;\n\tv98 = ~v97;\n\tif (v98) goto L_FFFFFFFF;\n\tgoto L_007B;\nL_007B:\n\tv73.target = target;\n\tv73.endValue = endValue;\n\tv73.endValue.y = endValue.y;\n\tv73.endValue.z = endValue.z;\n\tv223 = UnityEngine.Transform::get_position(target);\n\tv73.startPosY = v223.y;\n\tv73.offsetY = -1f;\n\tv73.offsetYSet = 0;\n\tgoto L_00A0;\n\tv237 = \"il2cpp_codegen_runtime_class_init\"(v230, v222, snapping, methodInfo, v61, v62, v63, v64, v223, v227, v228, jumpPower, duration, v65, v66, v67);\nL_00A0:\n\tv245 = DG.Tweening.DOTween::Sequence();\n\tv73.s = v245;\n\tv250 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v250, v73, Il2CppMethodInfo);\n\tv262 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v262, v73, Il2CppMethodInfo);\n\tv273 = v100 << 1;\n\tv275 = duration / v273;\n\t// 184 MakeStruct v143 @ AGGC1A97C_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, jumpPower @ V3 (System.Single), 0\n\tv281 = DG.Tweening.DOTween::To(v250, v262, v143, v275);\n\tv286 = v281 == 0;\n\tif (v286) goto L_00C7;\n\tv291 = ~v281.<active>k__BackingField;\n\tif (v291) goto L_00C7;\n\tv281.plugOptions = 4;\n\t*([v281 @ X0_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+14C]) = snapping;\nL_00C7:\n\tv299 = DG.Tweening.TweenSettingsExtensions::SetEase(v281, 6);\n\tv304 = DG.Tweening.TweenSettingsExtensions::SetRelative(v299);\n\tv311 = DG.Tweening.TweenSettingsExtensions::SetLoops(v304, v273, 1);\n\tv317 = DG.Tweening.TweenCallback;\n\tv319 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v319, v73, Il2CppMethodInfo);\n\tv332 = DG.Tweening.TweenSettingsExtensions::OnStart(v311, v319);\n\tv73.yTween = v332;\n\tv337 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v337, v73, Il2CppMethodInfo);\n\tv347 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v347, v73, Il2CppMethodInfo);\n\t// 253 MakeStruct v140 @ AGGC1AA84_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v73.endValue (UnityEngine.Vector3), 0, 0\n\tv360 = DG.Tweening.DOTween::To(v337, v347, v140, duration);\n\tv361 = v360 == 0;\n\tif (v361) goto L_0111;\n\tv363 = ~v360.<active>k__BackingField;\n\tif (v363) goto L_0111;\n\tv360.plugOptions = 2;\n\t*([v360 @ X0_v27 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+14C]) = snapping;\nL_0111:\n\tv377 = DG.Tweening.TweenSettingsExtensions::SetEase(v360, 1);\n\tv380 = DG.Tweening.TweenSettingsExtensions::Append(v73.s, v377);\n\tv382 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v382, v73, Il2CppMethodInfo);\n\tv390 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v390, v73, Il2CppMethodInfo);\n\t// 301 MakeStruct v137 @ AGGC1AB38_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, 0, v73.endValue.z (System.Single)\n\tv398 = DG.Tweening.DOTween::To(v382, v390, v137, duration);\n\tv399 = v398 == 0;\n\tif (v399) goto L_013B;\n\tv401 = ~v398.<active>k__BackingField;\n\tif (v401) goto L_013B;\n\tv398.plugOptions = 8;\n\t*([v398 @ X0_v36 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+14C]) = snapping;\nL_013B:\n\tv408 = DG.Tweening.TweenSettingsExtensions::SetEase(v398, 1);\n\tv411 = DG.Tweening.TweenSettingsExtensions::Join(v73.s, v408);\n\tv413 = DG.Tweening.TweenSettingsExtensions::Join(v411, v73.yTween);\n\tv416 = DG.Tweening.TweenSettingsExtensions::SetTarget(v413, v73.target);\n\tv423 = DG.Tweening.TweenSettingsExtensions::SetEase(v416, v421.defaultEaseType);\n\tv426 = new *([v317 @ X2\n// ... truncated")]
		public static Sequence DOJump(this Transform target, Vector3 endValue, float jumpPower, int numJumps, float duration, bool snapping = false)
		{
			//IL_0210: Expected I, but got O
			//IL_01f8: Expected O, but got I4
			//IL_0313: Expected O, but got I4
			//IL_03d0: Expected O, but got I4
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
			float startPosY = target.position.y;
			float offsetY = -1f;
			bool offsetYSet = false;
			Sequence sequence = DOTween.Sequence();
			Sequence s = sequence;
			DOGetter<Vector3> getter = () => target2.position;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target2.position = x;
			};
			int num6 = num5 << 1;
			float duration2 = duration / (float)num6;
			Vector3 endValue3 = default(Vector3);
			endValue3.x = 0f;
			endValue3.y = jumpPower;
			endValue3.z = 0f;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue3, duration2);
			if (tweenerCore != null && tweenerCore._003Cactive_003Ek__BackingField)
			{
				tweenerCore.plugOptions = (VectorOptions)4;
			}
			Tweener relative = ((Tweener)tweenerCore).SetEase(Ease.OutQuad);
			Tweener t = relative.SetRelative();
			Tweener t2 = t.SetLoops(num6, LoopType.Yoyo);
			nint num7 = (nint)typeof(TweenCallback);
			TweenCallback action = delegate
			{
				startPosY = target2.position.y;
			};
			Tweener tweener = t2.OnStart(action);
			Tween yTween = tweener;
			DOGetter<Vector3> getter2 = () => target2.position;
			DOSetter<Vector3> setter2 = delegate(Vector3 x)
			{
				target2.position = x;
			};
			Vector3 endValue4 = default(Vector3);
			endValue4.x = endValue2.x;
			endValue4.y = 0f;
			endValue4.z = 0f;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = DOTween.To(getter2, setter2, endValue4, duration);
			if (tweenerCore2 != null && tweenerCore2._003Cactive_003Ek__BackingField)
			{
				tweenerCore2.plugOptions = (VectorOptions)2;
			}
			Tweener t3 = ((Tweener)tweenerCore2).SetEase(Ease.Linear);
			Sequence sequence2 = s.Append(t3);
			DOGetter<Vector3> getter3 = () => target2.position;
			DOSetter<Vector3> setter3 = delegate(Vector3 x)
			{
				target2.position = x;
			};
			Vector3 endValue5 = default(Vector3);
			endValue5.x = 0f;
			endValue5.y = 0f;
			endValue5.z = endValue2.z;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = DOTween.To(getter3, setter3, endValue5, duration);
			if (tweenerCore3 != null && tweenerCore3._003Cactive_003Ek__BackingField)
			{
				tweenerCore3.plugOptions = (VectorOptions)8;
			}
			Tweener t4 = ((Tweener)tweenerCore3).SetEase(Ease.Linear);
			Sequence s2 = s.Join(t4);
			Sequence t5 = s2.Join(yTween);
			Sequence t6 = t5.SetTarget(target2);
			Sequence sequence3 = t6.SetEase(DOTween.defaultEaseType);
			TweenCallback action2 = delegate
			{
				if (!offsetYSet)
				{
					Sequence sequence4 = s;
					offsetYSet = true;
					float num8 = endValue2.y;
					if (!sequence4.isRelative)
					{
						num8 -= startPosY;
					}
					offsetY = num8;
				}
				Vector3 position = target2.position;
				float lifetimePercentage = yTween.ElapsedPercentage();
				float num9 = DOVirtual.EasedValue(0f, offsetY, lifetimePercentage, Ease.OutQuad);
				float y = position.y + num9;
				Vector3 position2 = default(Vector3);
				position2.x = position.x;
				position2.y = y;
				position2.z = position.z;
				target2.position = position2;
			};
			Tween tween = yTween.OnUpdate(action2);
			return s;
		}

		[Token(Token = "0x6000112")]
		[Address(RVA = "0xC16C98", Offset = "0xC16C98", Length = "0x4D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0063;\n\tv58 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv75 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv80 = DG.Tweening.DOTween;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv84 = DG.Tweening.TweenCallback;\n\tv85 = \"il2cpp_codegen_initialize_runtime_metadata\"(v84, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv127 = Il2CppMethodInfo;\n\tv128 = \"il2cpp_codegen_initialize_runtime_metadata\"(v127, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv132 = Il2CppMethodInfo;\n\tv133 = \"il2cpp_codegen_initialize_runtime_metadata\"(v132, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv209 = Il2CppMethodInfo;\n\tv210 = \"il2cpp_codegen_initialize_runtime_metadata\"(v209, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv225 = Il2CppMethodInfo;\n\tv226 = \"il2cpp_codegen_initialize_runtime_metadata\"(v225, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv235 = Il2CppMethodInfo;\n\tv236 = \"il2cpp_codegen_initialize_runtime_metadata\"(v235, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv247 = Il2CppMethodInfo;\n\tv248 = \"il2cpp_codegen_initialize_runtime_metadata\"(v247, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv252 = Il2CppMethodInfo;\n\tv253 = \"il2cpp_codegen_initialize_runtime_metadata\"(v252, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv259 = Il2CppMethodInfo;\n\tv260 = \"il2cpp_codegen_initialize_runtime_metadata\"(v259, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv264 = Il2CppMethodInfo;\n\tv265 = \"il2cpp_codegen_initialize_runtime_metadata\"(v264, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv271 = Il2CppMethodInfo;\n\tv272 = \"il2cpp_codegen_initialize_runtime_metadata\"(v271, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv283 = Il2CppMethodInfo;\n\tv284 = \"il2cpp_codegen_initialize_runtime_metadata\"(v283, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv288 = Il2CppMethodInfo;\n\tv289 = \"il2cpp_codegen_initialize_runtime_metadata\"(v288, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv301 = Il2CppMethodInfo;\n\tv302 = \"il2cpp_codegen_initialize_runtime_metadata\"(v301, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv306 = Il2CppMethodInfo;\n\tv307 = \"il2cpp_codegen_initialize_runtime_metadata\"(v306, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv313 = Il2CppMethodInfo;\n\tv314 = \"il2cpp_codegen_initialize_runtime_metadata\"(v313, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv321 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass62_0;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v321, numJumps, snapping, methodInfo, v61, v62, v63, v64, endValue, v0, v2, jumpPower, duration, v65, v66, v67);\n\tv71 = 1;\n\t*([1A3571F]) = v71;\nL_0063:\n\tv73 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass62_0();\n\tSystem.Object::.ctor(v73);\n\tv88 = numJumps - 1;\n\tv89 = v88 < 0;\n\tv90 = v88 == 0;\n\tv91 = numJumps ^ 1;\n\tv92 = numJumps ^ v88;\n\tv93 = v91 & v92;\n\tv94 = v93 < 0;\n\tv95 = v89 == v94;\n\tv96 = ~v90;\n\tv97 = v95 & v96;\n\tv98 = ~v97;\n\tif (v98) goto L_FFFFFFFF;\n\tgoto L_007B;\nL_007B:\n\tv73.target = target;\n\tv73.endValue = endValue;\n\tv73.endValue.y = endValue.y;\n\tv73.endValue.z = endValue.z;\n\tv223 = UnityEngine.Transform::get_localPosition(target);\n\tv73.startPosY = v223.y;\n\tv73.offsetY = -1f;\n\tv73.offsetYSet = 0;\n\tgoto L_00A0;\n\tv237 = \"il2cpp_codegen_runtime_class_init\"(v230, v222, snapping, methodInfo, v61, v62, v63, v64, v223, v227, v228, jumpPower, duration, v65, v66, v67);\nL_00A0:\n\tv245 = DG.Tweening.DOTween::Sequence();\n\tv73.s = v245;\n\tv250 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v250, v73, Il2CppMethodInfo);\n\tv262 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v262, v73, Il2CppMethodInfo);\n\tv273 = v100 << 1;\n\tv275 = duration / v273;\n\t// 184 MakeStruct v143 @ AGGC1AEE4_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, jumpPower @ V3 (System.Single), 0\n\tv281 = DG.Tweening.DOTween::To(v250, v262, v143, v275);\n\tv286 = v281 == 0;\n\tif (v286) goto L_00C7;\n\tv291 = ~v281.<active>k__BackingField;\n\tif (v291) goto L_00C7;\n\tv281.plugOptions = 4;\n\t*([v281 @ X0_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+14C]) = snapping;\nL_00C7:\n\tv299 = DG.Tweening.TweenSettingsExtensions::SetEase(v281, 6);\n\tv304 = DG.Tweening.TweenSettingsExtensions::SetRelative(v299);\n\tv311 = DG.Tweening.TweenSettingsExtensions::SetLoops(v304, v273, 1);\n\tv317 = DG.Tweening.TweenCallback;\n\tv319 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v319, v73, Il2CppMethodInfo);\n\tv332 = DG.Tweening.TweenSettingsExtensions::OnStart(v311, v319);\n\tv73.yTween = v332;\n\tv337 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v337, v73, Il2CppMethodInfo);\n\tv347 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v347, v73, Il2CppMethodInfo);\n\t// 253 MakeStruct v140 @ AGGC1AFEC_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v73.endValue (UnityEngine.Vector3), 0, 0\n\tv360 = DG.Tweening.DOTween::To(v337, v347, v140, duration);\n\tv361 = v360 == 0;\n\tif (v361) goto L_0111;\n\tv363 = ~v360.<active>k__BackingField;\n\tif (v363) goto L_0111;\n\tv360.plugOptions = 2;\n\t*([v360 @ X0_v27 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+14C]) = snapping;\nL_0111:\n\tv377 = DG.Tweening.TweenSettingsExtensions::SetEase(v360, 1);\n\tv380 = DG.Tweening.TweenSettingsExtensions::Append(v73.s, v377);\n\tv382 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v382, v73, Il2CppMethodInfo);\n\tv390 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v390, v73, Il2CppMethodInfo);\n\t// 301 MakeStruct v137 @ AGGC1B0A0_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, 0, v73.endValue.z (System.Single)\n\tv398 = DG.Tweening.DOTween::To(v382, v390, v137, duration);\n\tv399 = v398 == 0;\n\tif (v399) goto L_013B;\n\tv401 = ~v398.<active>k__BackingField;\n\tif (v401) goto L_013B;\n\tv398.plugOptions = 8;\n\t*([v398 @ X0_v36 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+14C]) = snapping;\nL_013B:\n\tv408 = DG.Tweening.TweenSettingsExtensions::SetEase(v398, 1);\n\tv411 = DG.Tweening.TweenSettingsExtensions::Join(v73.s, v408);\n\tv413 = DG.Tweening.TweenSettingsExtensions::Join(v411, v73.yTween);\n\tv416 = DG.Tweening.TweenSettingsExtensions::SetTarget(v413, v73.target);\n\tv423 = DG.Tweening.TweenSettingsExtensions::SetEase(v416, v421.defaultEaseType);\n\tv426 = new *([v317\n// ... truncated")]
		public static Sequence DOLocalJump(this Transform target, Vector3 endValue, float jumpPower, int numJumps, float duration, bool snapping = false)
		{
			//IL_0210: Expected I, but got O
			//IL_01f8: Expected O, but got I4
			//IL_0313: Expected O, but got I4
			//IL_03d0: Expected O, but got I4
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
			float offsetY = -1f;
			bool offsetYSet = false;
			Sequence sequence = DOTween.Sequence();
			Sequence s = sequence;
			DOGetter<Vector3> getter = () => target2.localPosition;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target2.localPosition = x;
			};
			int num6 = num5 << 1;
			float duration2 = duration / (float)num6;
			Vector3 endValue3 = default(Vector3);
			endValue3.x = 0f;
			endValue3.y = jumpPower;
			endValue3.z = 0f;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue3, duration2);
			if (tweenerCore != null && tweenerCore._003Cactive_003Ek__BackingField)
			{
				tweenerCore.plugOptions = (VectorOptions)4;
			}
			Tweener relative = ((Tweener)tweenerCore).SetEase(Ease.OutQuad);
			Tweener t = relative.SetRelative();
			Tweener t2 = t.SetLoops(num6, LoopType.Yoyo);
			nint num7 = (nint)typeof(TweenCallback);
			TweenCallback action = delegate
			{
				startPosY = target2.localPosition.y;
			};
			Tweener tweener = t2.OnStart(action);
			Tween yTween = tweener;
			DOGetter<Vector3> getter2 = () => target2.localPosition;
			DOSetter<Vector3> setter2 = delegate(Vector3 x)
			{
				target2.localPosition = x;
			};
			Vector3 endValue4 = default(Vector3);
			endValue4.x = endValue2.x;
			endValue4.y = 0f;
			endValue4.z = 0f;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = DOTween.To(getter2, setter2, endValue4, duration);
			if (tweenerCore2 != null && tweenerCore2._003Cactive_003Ek__BackingField)
			{
				tweenerCore2.plugOptions = (VectorOptions)2;
			}
			Tweener t3 = ((Tweener)tweenerCore2).SetEase(Ease.Linear);
			Sequence sequence2 = s.Append(t3);
			DOGetter<Vector3> getter3 = () => target2.localPosition;
			DOSetter<Vector3> setter3 = delegate(Vector3 x)
			{
				target2.localPosition = x;
			};
			Vector3 endValue5 = default(Vector3);
			endValue5.x = 0f;
			endValue5.y = 0f;
			endValue5.z = endValue2.z;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = DOTween.To(getter3, setter3, endValue5, duration);
			if (tweenerCore3 != null && tweenerCore3._003Cactive_003Ek__BackingField)
			{
				tweenerCore3.plugOptions = (VectorOptions)8;
			}
			Tweener t4 = ((Tweener)tweenerCore3).SetEase(Ease.Linear);
			Sequence s2 = s.Join(t4);
			Sequence t5 = s2.Join(yTween);
			Sequence t6 = t5.SetTarget(target2);
			Sequence sequence3 = t6.SetEase(DOTween.defaultEaseType);
			TweenCallback action2 = delegate
			{
				if (!offsetYSet)
				{
					Sequence sequence4 = s;
					offsetYSet = true;
					float num8 = endValue2.y;
					if (!sequence4.isRelative)
					{
						num8 -= startPosY;
					}
					offsetY = num8;
				}
				Vector3 localPosition = target2.localPosition;
				float lifetimePercentage = yTween.ElapsedPercentage();
				float num9 = DOVirtual.EasedValue(0f, offsetY, lifetimePercentage, Ease.OutQuad);
				float y = localPosition.y + num9;
				Vector3 localPosition2 = default(Vector3);
				localPosition2.x = localPosition.x;
				localPosition2.y = y;
				localPosition2.z = localPosition.z;
				target2.localPosition = localPosition2;
			};
			Tween tween = yTween.OnUpdate(action2);
			return s;
		}

		[Token(Token = "0x6000113")]
		[Address(RVA = "0xC17178", Offset = "0xC17178", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003B;\n\tv48 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, path, pathType, pathMode, resolution, gizmoColor, methodInfo, v51, duration, v52, v53, v54, v55, v56, v57, v58);\n\tv66 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, path, pathType, pathMode, resolution, gizmoColor, methodInfo, v51, duration, v52, v53, v54, v55, v56, v57, v58);\n\tv71 = Il2CppMethodInfo;\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, path, pathType, pathMode, resolution, gizmoColor, methodInfo, v51, duration, v52, v53, v54, v55, v56, v57, v58);\n\tv75 = DG.Tweening.DOTween;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, path, pathType, pathMode, resolution, gizmoColor, methodInfo, v51, duration, v52, v53, v54, v55, v56, v57, v58);\n\tv163 = DG.Tweening.Plugins.Core.PathCore.Path;\n\tv164 = \"il2cpp_codegen_initialize_runtime_metadata\"(v163, path, pathType, pathMode, resolution, gizmoColor, methodInfo, v51, duration, v52, v53, v54, v55, v56, v57, v58);\n\tv168 = Il2CppMethodInfo;\n\tv169 = \"il2cpp_codegen_initialize_runtime_metadata\"(v168, path, pathType, pathMode, resolution, gizmoColor, methodInfo, v51, duration, v52, v53, v54, v55, v56, v57, v58);\n\tv221 = Il2CppMethodInfo;\n\tv222 = \"il2cpp_codegen_initialize_runtime_metadata\"(v221, path, pathType, pathMode, resolution, gizmoColor, methodInfo, v51, duration, v52, v53, v54, v55, v56, v57, v58);\n\tv227 = Il2CppMethodInfo;\n\tv228 = \"il2cpp_codegen_initialize_runtime_metadata\"(v227, path, pathType, pathMode, resolution, gizmoColor, methodInfo, v51, duration, v52, v53, v54, v55, v56, v57, v58);\n\tv233 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass63_0;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v233, path, pathType, pathMode, resolution, gizmoColor, methodInfo, v51, duration, v52, v53, v54, v55, v56, v57, v58);\n\tv62 = 1;\n\t*([1A35720]) = v62;\nL_003B:\n\tv64 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass63_0();\n\tSystem.Object::.ctor(v64);\n\tv89 = resolution - 1;\n\tv90 = v89 < 0;\n\tv91 = v89 == 0;\n\tv92 = resolution ^ 1;\n\tv93 = resolution ^ v89;\n\tv94 = v92 & v93;\n\tv95 = v94 < 0;\n\tv64.target = target;\n\tv97 = v90 == v95;\n\tv98 = ~v91;\n\tv99 = v97 & v98;\n\tv100 = ~v99;\n\tif (v100) goto L_FFFFFFFF;\n\tgoto L_005F;\nL_005F:\n\tv170 = DG.Tweening.Plugins.PathPlugin::Get();\n\tv225 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v225, v64, Il2CppMethodInfo);\n\tv235 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v235, v64, Il2CppMethodInfo);\n\tduration = *([gizmoColor @ X5 (System.Nullable`1<UnityEngine.Color>)]);\n\tv242 = new DG.Tweening.Plugins.Core.PathCore.Path();\n\tDG.Tweening.Plugins.Core.PathCore.Path::.ctor(v242, pathType, path, v118, &duration @ V0 (System.Single));\n\tgoto L_008D;\n\tv253 = \"il2cpp_codegen_runtime_class_init\"(v249, v243, v245, v246, v244, v102, methodInfo, v51, v240, v52, v53, v54, v55, v56, v57, v58);\nL_008D:\n\tv260 = DG.Tweening.DOTween::To(v170, v225, v235, v242, duration);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v260, v64.target);\n\treturnVal2.plugOptions = pathMode;\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 115 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static TweenerCore<Vector3, Path, PathOptions> DOPath(this Transform target, Vector3[] path, float duration, PathType pathType = PathType.Linear, PathMode pathMode = PathMode.Full3D, int resolution = 10, Color? gizmoColor = null)
		{
			//IL_00f0: Expected F4, but got O
			//IL_0105: Expected O, but got Ref
			//IL_0159: Expected O, but got I4
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
			TweenerCore<Vector3, object, PathOptions> t = DOTween.To((ABSTweenPlugin<Vector3, object, PathOptions>)(object)plugin, getter, setter, endValue, duration);
			TweenerCore<Vector3, Path, PathOptions> tweenerCore = ((TweenerCore<Vector3, Path, PathOptions>)(object)t).SetTarget(target2);
			tweenerCore.plugOptions = (PathOptions)pathMode;
			return tweenerCore;
		}

		[Token(Token = "0x6000114")]
		[Address(RVA = "0xC1738C", Offset = "0xC1738C", Length = "0x214")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003B;\n\tv48 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, path, pathType, pathMode, resolution, gizmoColor, methodInfo, v51, duration, v52, v53, v54, v55, v56, v57, v58);\n\tv66 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, path, pathType, pathMode, resolution, gizmoColor, methodInfo, v51, duration, v52, v53, v54, v55, v56, v57, v58);\n\tv71 = Il2CppMethodInfo;\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, path, pathType, pathMode, resolution, gizmoColor, methodInfo, v51, duration, v52, v53, v54, v55, v56, v57, v58);\n\tv75 = DG.Tweening.DOTween;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, path, pathType, pathMode, resolution, gizmoColor, methodInfo, v51, duration, v52, v53, v54, v55, v56, v57, v58);\n\tv163 = DG.Tweening.Plugins.Core.PathCore.Path;\n\tv164 = \"il2cpp_codegen_initialize_runtime_metadata\"(v163, path, pathType, pathMode, resolution, gizmoColor, methodInfo, v51, duration, v52, v53, v54, v55, v56, v57, v58);\n\tv168 = Il2CppMethodInfo;\n\tv169 = \"il2cpp_codegen_initialize_runtime_metadata\"(v168, path, pathType, pathMode, resolution, gizmoColor, methodInfo, v51, duration, v52, v53, v54, v55, v56, v57, v58);\n\tv221 = Il2CppMethodInfo;\n\tv222 = \"il2cpp_codegen_initialize_runtime_metadata\"(v221, path, pathType, pathMode, resolution, gizmoColor, methodInfo, v51, duration, v52, v53, v54, v55, v56, v57, v58);\n\tv227 = Il2CppMethodInfo;\n\tv228 = \"il2cpp_codegen_initialize_runtime_metadata\"(v227, path, pathType, pathMode, resolution, gizmoColor, methodInfo, v51, duration, v52, v53, v54, v55, v56, v57, v58);\n\tv233 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass64_0;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v233, path, pathType, pathMode, resolution, gizmoColor, methodInfo, v51, duration, v52, v53, v54, v55, v56, v57, v58);\n\tv62 = 1;\n\t*([1A35721]) = v62;\nL_003B:\n\tv64 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass64_0();\n\tSystem.Object::.ctor(v64);\n\tv89 = resolution - 1;\n\tv90 = v89 < 0;\n\tv91 = v89 == 0;\n\tv92 = resolution ^ 1;\n\tv93 = resolution ^ v89;\n\tv94 = v92 & v93;\n\tv95 = v94 < 0;\n\tv64.target = target;\n\tv97 = v90 == v95;\n\tv98 = ~v91;\n\tv99 = v97 & v98;\n\tv100 = ~v99;\n\tif (v100) goto L_FFFFFFFF;\n\tgoto L_005F;\nL_005F:\n\tv170 = DG.Tweening.Plugins.PathPlugin::Get();\n\tv225 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v225, v64, Il2CppMethodInfo);\n\tv235 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v235, v64, Il2CppMethodInfo);\n\tduration = *([gizmoColor @ X5 (System.Nullable`1<UnityEngine.Color>)]);\n\tv242 = new DG.Tweening.Plugins.Core.PathCore.Path();\n\tDG.Tweening.Plugins.Core.PathCore.Path::.ctor(v242, pathType, path, v118, &duration @ V0 (System.Single));\n\tgoto L_008D;\n\tv253 = \"il2cpp_codegen_runtime_class_init\"(v249, v243, v245, v246, v244, v102, methodInfo, v51, v240, v52, v53, v54, v55, v56, v57, v58);\nL_008D:\n\tv260 = DG.Tweening.DOTween::To(v170, v225, v235, v242, duration);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v260, v64.target);\n\treturnVal2.plugOptions = pathMode;\n\t*([returnVal2 @ X0_v18 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+180]) = 1;\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 116 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static TweenerCore<Vector3, Path, PathOptions> DOLocalPath(this Transform target, Vector3[] path, float duration, PathType pathType = PathType.Linear, PathMode pathMode = PathMode.Full3D, int resolution = 10, Color? gizmoColor = null)
		{
			//IL_00f0: Expected F4, but got O
			//IL_0105: Expected O, but got Ref
			//IL_0159: Expected O, but got I4
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
			TweenerCore<Vector3, object, PathOptions> t = DOTween.To((ABSTweenPlugin<Vector3, object, PathOptions>)(object)plugin, getter, setter, endValue, duration);
			TweenerCore<Vector3, Path, PathOptions> tweenerCore = ((TweenerCore<Vector3, Path, PathOptions>)(object)t).SetTarget(target2);
			tweenerCore.plugOptions = (PathOptions)pathMode;
			_ = 1;
			return tweenerCore;
		}

		[Token(Token = "0x6000115")]
		[Address(RVA = "0xC175A8", Offset = "0xC175A8", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tv42 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, path, pathMode, methodInfo, v45, v46, v47, v48, duration, v49, v50, v51, v52, v53, v54, v55);\n\tv63 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, path, pathMode, methodInfo, v45, v46, v47, v48, duration, v49, v50, v51, v52, v53, v54, v55);\n\tv68 = Il2CppMethodInfo;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, path, pathMode, methodInfo, v45, v46, v47, v48, duration, v49, v50, v51, v52, v53, v54, v55);\n\tv72 = DG.Tweening.DOTween;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, path, pathMode, methodInfo, v45, v46, v47, v48, duration, v49, v50, v51, v52, v53, v54, v55);\n\tv119 = Il2CppMethodInfo;\n\tv120 = \"il2cpp_codegen_initialize_runtime_metadata\"(v119, path, pathMode, methodInfo, v45, v46, v47, v48, duration, v49, v50, v51, v52, v53, v54, v55);\n\tv125 = Il2CppMethodInfo;\n\tv126 = \"il2cpp_codegen_initialize_runtime_metadata\"(v125, path, pathMode, methodInfo, v45, v46, v47, v48, duration, v49, v50, v51, v52, v53, v54, v55);\n\tv165 = Il2CppMethodInfo;\n\tv166 = \"il2cpp_codegen_initialize_runtime_metadata\"(v165, path, pathMode, methodInfo, v45, v46, v47, v48, duration, v49, v50, v51, v52, v53, v54, v55);\n\tv170 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass65_0;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v170, path, pathMode, methodInfo, v45, v46, v47, v48, duration, v49, v50, v51, v52, v53, v54, v55);\n\tv59 = 1;\n\t*([1A35722]) = v59;\nL_0035:\n\tv61 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass65_0();\n\tSystem.Object::.ctor(v61);\n\tv61.target = target;\n\tv89 = DG.Tweening.Plugins.PathPlugin::Get();\n\tv123 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v123, v61, Il2CppMethodInfo);\n\tv168 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v168, v61, Il2CppMethodInfo);\n\tgoto L_0068;\n\tv177 = \"il2cpp_codegen_runtime_class_init\"(v174, v172, v171, v173, v45, v46, v47, v48, duration, v49, v50, v51, v52, v53, v54, v55);\nL_0068:\n\tv182 = DG.Tweening.DOTween::To(v89, v123, v168, path, duration);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v182, v61.target);\n\treturnVal2.plugOptions = pathMode;\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Path, PathOptions> DOPath(this Transform target, Path path, float duration, PathMode pathMode = PathMode.Full3D)
		{
			//IL_0097: Expected O, but got I4
			ABSTweenPlugin<Vector3, Path, PathOptions> plugin = PathPlugin.Get();
			DOGetter<Vector3> getter = () => target.position;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.position = x;
			};
			TweenerCore<Vector3, object, PathOptions> t = DOTween.To((ABSTweenPlugin<Vector3, object, PathOptions>)(object)plugin, getter, setter, path, duration);
			TweenerCore<Vector3, Path, PathOptions> tweenerCore = ((TweenerCore<Vector3, Path, PathOptions>)(object)t).SetTarget(target);
			tweenerCore.plugOptions = (PathOptions)pathMode;
			return tweenerCore;
		}

		[Token(Token = "0x6000116")]
		[Address(RVA = "0xC17758", Offset = "0xC17758", Length = "0x1B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tv42 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, path, pathMode, methodInfo, v45, v46, v47, v48, duration, v49, v50, v51, v52, v53, v54, v55);\n\tv63 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, path, pathMode, methodInfo, v45, v46, v47, v48, duration, v49, v50, v51, v52, v53, v54, v55);\n\tv68 = Il2CppMethodInfo;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, path, pathMode, methodInfo, v45, v46, v47, v48, duration, v49, v50, v51, v52, v53, v54, v55);\n\tv72 = DG.Tweening.DOTween;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, path, pathMode, methodInfo, v45, v46, v47, v48, duration, v49, v50, v51, v52, v53, v54, v55);\n\tv119 = Il2CppMethodInfo;\n\tv120 = \"il2cpp_codegen_initialize_runtime_metadata\"(v119, path, pathMode, methodInfo, v45, v46, v47, v48, duration, v49, v50, v51, v52, v53, v54, v55);\n\tv125 = Il2CppMethodInfo;\n\tv126 = \"il2cpp_codegen_initialize_runtime_metadata\"(v125, path, pathMode, methodInfo, v45, v46, v47, v48, duration, v49, v50, v51, v52, v53, v54, v55);\n\tv166 = Il2CppMethodInfo;\n\tv167 = \"il2cpp_codegen_initialize_runtime_metadata\"(v166, path, pathMode, methodInfo, v45, v46, v47, v48, duration, v49, v50, v51, v52, v53, v54, v55);\n\tv171 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass66_0;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v171, path, pathMode, methodInfo, v45, v46, v47, v48, duration, v49, v50, v51, v52, v53, v54, v55);\n\tv59 = 1;\n\t*([1A35723]) = v59;\nL_0035:\n\tv61 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass66_0();\n\tSystem.Object::.ctor(v61);\n\tv61.target = target;\n\tv89 = DG.Tweening.Plugins.PathPlugin::Get();\n\tv123 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v123, v61, Il2CppMethodInfo);\n\tv169 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v169, v61, Il2CppMethodInfo);\n\tgoto L_0068;\n\tv178 = \"il2cpp_codegen_runtime_class_init\"(v175, v173, v172, v174, v45, v46, v47, v48, duration, v49, v50, v51, v52, v53, v54, v55);\nL_0068:\n\tv183 = DG.Tweening.DOTween::To(v89, v123, v169, path, duration);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v183, v61.target);\n\treturnVal2.plugOptions = pathMode;\n\t*([returnVal2 @ X0_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>)+180]) = 1;\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 94 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Path, PathOptions> DOLocalPath(this Transform target, Path path, float duration, PathMode pathMode = PathMode.Full3D)
		{
			//IL_0097: Expected O, but got I4
			ABSTweenPlugin<Vector3, Path, PathOptions> plugin = PathPlugin.Get();
			DOGetter<Vector3> getter = () => target.localPosition;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				target.localPosition = x;
			};
			TweenerCore<Vector3, object, PathOptions> t = DOTween.To((ABSTweenPlugin<Vector3, object, PathOptions>)(object)plugin, getter, setter, path, duration);
			TweenerCore<Vector3, Path, PathOptions> tweenerCore = ((TweenerCore<Vector3, Path, PathOptions>)(object)t).SetTarget(target);
			tweenerCore.plugOptions = (PathOptions)pathMode;
			_ = 1;
			return tweenerCore;
		}

		[Token(Token = "0x6000117")]
		[Address(RVA = "0xC17910", Offset = "0xC17910", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv34 = DG.Tweening.Core.DOGetter`1<System.Single>;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv56 = DG.Tweening.Core.DOSetter`1<System.Single>;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv61 = DG.Tweening.DOTween;\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv65 = Il2CppMethodInfo;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv83 = Il2CppMethodInfo;\n\tv84 = \"il2cpp_codegen_initialize_runtime_metadata\"(v83, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv90 = Il2CppMethodInfo;\n\tv91 = \"il2cpp_codegen_initialize_runtime_metadata\"(v90, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv131 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass67_0;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v131, methodInfo, v37, v38, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\n\tv52 = 1;\n\t*([1A35724]) = v52;\nL_002E:\n\tv54 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass67_0();\n\tSystem.Object::.ctor(v54);\n\tv54.target = target;\n\tv80 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v80, v54, Il2CppMethodInfo);\n\tv93 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v93, v54, Il2CppMethodInfo);\n\tgoto L_0059;\n\tv137 = \"il2cpp_codegen_runtime_class_init\"(v135, v133, v132, v101, v39, v40, v41, v42, endValue, duration, v43, v44, v45, v46, v47, v48);\nL_0059:\n\tv141 = DG.Tweening.DOTween::To(v80, v93, endValue, duration);\n\tv143 = DG.Tweening.TweenSettingsExtensions::SetTarget(v141, v54.target);\n\treturn v141;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000118")]
		[Address(RVA = "0xC17A80", Offset = "0xC17A80", Length = "0x1E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003F;\n\tv56 = DG.Tweening.Core.DOGetter`1<UnityEngine.Color>;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v59, v60, v61, v62, v63, v64, endValue, v0, v2, v3, duration, v65, v66, v67);\n\tv75 = DG.Tweening.Core.DOSetter`1<UnityEngine.Color>;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, methodInfo, v59, v60, v61, v62, v63, v64, endValue, v0, v2, v3, duration, v65, v66, v67);\n\tv80 = DG.Tweening.DOTween;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, methodInfo, v59, v60, v61, v62, v63, v64, endValue, v0, v2, v3, duration, v65, v66, v67);\n\tv84 = Il2CppMethodInfo;\n\tv85 = \"il2cpp_codegen_initialize_runtime_metadata\"(v84, methodInfo, v59, v60, v61, v62, v63, v64, endValue, v0, v2, v3, duration, v65, v66, v67);\n\tv93 = Il2CppMethodInfo;\n\tv94 = \"il2cpp_codegen_initialize_runtime_metadata\"(v93, methodInfo, v59, v60, v61, v62, v63, v64, endValue, v0, v2, v3, duration, v65, v66, v67);\n\tv113 = Il2CppMethodInfo;\n\tv114 = \"il2cpp_codegen_initialize_runtime_metadata\"(v113, methodInfo, v59, v60, v61, v62, v63, v64, endValue, v0, v2, v3, duration, v65, v66, v67);\n\tv187 = Il2CppMethodInfo;\n\tv188 = \"il2cpp_codegen_initialize_runtime_metadata\"(v187, methodInfo, v59, v60, v61, v62, v63, v64, endValue, v0, v2, v3, duration, v65, v66, v67);\n\tv194 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass68_0;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v194, methodInfo, v59, v60, v61, v62, v63, v64, endValue, v0, v2, v3, duration, v65, v66, v67);\n\tv71 = 1;\n\t*([1A35725]) = v71;\nL_003F:\n\tv73 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass68_0();\n\tSystem.Object::.ctor(v73);\n\tv73.target = target;\n\tv111 = UnityEngine.Light::get_color(target);\n\tv73.to = 0;\n\tv73.to.b = 0f;\n\tv123 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v123, v73, Il2CppMethodInfo);\n\tv196 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v196, v73, Il2CppMethodInfo);\n\tgoto L_0078;\n\tv202 = \"il2cpp_codegen_runtime_class_init\"(v200, v198, v197, v132, v61, v62, v63, v64, v111, v115, v116, v117, duration, v65, v66, v67);\nL_0078:\n\tv181 = endValue.a - v111.a;\n\tv183 = endValue.b - v111.b;\n\tv185 = endValue.g - v111.g;\n\tv142 = endValue - v111;\n\t// 126 MakeStruct v127 @ AGGC1BC1C_2_v1 (UnityEngine.Color), typeof(UnityEngine.Color), v142 @ V0_v2 (System.Single), v185 @ V1_v3 (System.Single), v183 @ V2_v3 (System.Single), v181 @ V3_v3 (System.Single)\n\tv206 = DG.Tweening.DOTween::To(v123, v196, v127, duration);\n\tv208 = DG.Tweening.Core.Extensions::Blendable(v206);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v208, v73.target);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 113 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOBlendableColor(this Light target, Color endValue, float duration)
		{
			Light target2 = target;
			Color color = target.color;
			Color to = default(Color);
			to.b = 0f;
			DOGetter<Color> getter = () => to;
			DOSetter<Color> setter = delegate(Color x)
			{
				to = x;
				to.g = x.g;
				to.b = x.b;
				to.a = x.a;
				float num = x.a - to.a;
				float num2 = x.b - to.b;
				float num3 = x.g - to.g;
				Color color3 = default(Color);
				float num4 = color3.r - to.r;
				Color color4 = target2.color;
				float b2 = num2 + color4.b;
				float a2 = num + color4.a;
				float r2 = num4 + color4.r;
				float g2 = num3 + color4.g;
				Color color5 = default(Color);
				color5.r = r2;
				color5.g = g2;
				color5.b = b2;
				color5.a = a2;
				target2.color = color5;
			};
			float a = endValue.a - color.a;
			float b = endValue.b - color.b;
			float g = endValue.g - color.g;
			Color color2 = default(Color);
			float r = color2.r - color.r;
			Color endValue2 = default(Color);
			endValue2.r = r;
			endValue2.g = g;
			endValue2.b = b;
			endValue2.a = a;
			TweenerCore<Color, Color, ColorOptions> t = DOTween.To(getter, setter, endValue2, duration);
			TweenerCore<Color, Color, ColorOptions> t2 = t.Blendable();
			return t2.SetTarget(target2);
		}

		[Token(Token = "0x6000119")]
		[Address(RVA = "0xC17C68", Offset = "0xC17C68", Length = "0x1E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003F;\n\tv56 = DG.Tweening.Core.DOGetter`1<UnityEngine.Color>;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v59, v60, v61, v62, v63, v64, endValue, v0, v2, v3, duration, v65, v66, v67);\n\tv75 = DG.Tweening.Core.DOSetter`1<UnityEngine.Color>;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, methodInfo, v59, v60, v61, v62, v63, v64, endValue, v0, v2, v3, duration, v65, v66, v67);\n\tv80 = DG.Tweening.DOTween;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, methodInfo, v59, v60, v61, v62, v63, v64, endValue, v0, v2, v3, duration, v65, v66, v67);\n\tv84 = Il2CppMethodInfo;\n\tv85 = \"il2cpp_codegen_initialize_runtime_metadata\"(v84, methodInfo, v59, v60, v61, v62, v63, v64, endValue, v0, v2, v3, duration, v65, v66, v67);\n\tv93 = Il2CppMethodInfo;\n\tv94 = \"il2cpp_codegen_initialize_runtime_metadata\"(v93, methodInfo, v59, v60, v61, v62, v63, v64, endValue, v0, v2, v3, duration, v65, v66, v67);\n\tv113 = Il2CppMethodInfo;\n\tv114 = \"il2cpp_codegen_initialize_runtime_metadata\"(v113, methodInfo, v59, v60, v61, v62, v63, v64, endValue, v0, v2, v3, duration, v65, v66, v67);\n\tv187 = Il2CppMethodInfo;\n\tv188 = \"il2cpp_codegen_initialize_runtime_metadata\"(v187, methodInfo, v59, v60, v61, v62, v63, v64, endValue, v0, v2, v3, duration, v65, v66, v67);\n\tv194 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass69_0;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v194, methodInfo, v59, v60, v61, v62, v63, v64, endValue, v0, v2, v3, duration, v65, v66, v67);\n\tv71 = 1;\n\t*([1A35726]) = v71;\nL_003F:\n\tv73 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass69_0();\n\tSystem.Object::.ctor(v73);\n\tv73.target = target;\n\tv111 = UnityEngine.Material::get_color(target);\n\tv73.to = 0;\n\tv73.to.b = 0f;\n\tv123 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v123, v73, Il2CppMethodInfo);\n\tv196 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v196, v73, Il2CppMethodInfo);\n\tgoto L_0078;\n\tv202 = \"il2cpp_codegen_runtime_class_init\"(v200, v198, v197, v132, v61, v62, v63, v64, v111, v115, v116, v117, duration, v65, v66, v67);\nL_0078:\n\tv181 = endValue.a - v111.a;\n\tv183 = endValue.b - v111.b;\n\tv185 = endValue.g - v111.g;\n\tv142 = endValue - v111;\n\t// 126 MakeStruct v127 @ AGGC1BE04_2_v1 (UnityEngine.Color), typeof(UnityEngine.Color), v142 @ V0_v2 (System.Single), v185 @ V1_v3 (System.Single), v183 @ V2_v3 (System.Single), v181 @ V3_v3 (System.Single)\n\tv206 = DG.Tweening.DOTween::To(v123, v196, v127, duration);\n\tv208 = DG.Tweening.Core.Extensions::Blendable(v206);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v208, v73.target);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 113 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOBlendableColor(this Material target, Color endValue, float duration)
		{
			Material target2 = target;
			Color color = target.color;
			Color to = default(Color);
			to.b = 0f;
			DOGetter<Color> getter = () => to;
			DOSetter<Color> setter = delegate(Color x)
			{
				to = x;
				to.g = x.g;
				to.b = x.b;
				to.a = x.a;
				float num = x.a - to.a;
				float num2 = x.b - to.b;
				float num3 = x.g - to.g;
				Color color3 = default(Color);
				float num4 = color3.r - to.r;
				Color color4 = target2.color;
				float b2 = num2 + color4.b;
				float a2 = num + color4.a;
				float r2 = num4 + color4.r;
				float g2 = num3 + color4.g;
				Color color5 = default(Color);
				color5.r = r2;
				color5.g = g2;
				color5.b = b2;
				color5.a = a2;
				target2.color = color5;
			};
			float a = endValue.a - color.a;
			float b = endValue.b - color.b;
			float g = endValue.g - color.g;
			Color color2 = default(Color);
			float r = color2.r - color.r;
			Color endValue2 = default(Color);
			endValue2.r = r;
			endValue2.g = g;
			endValue2.b = b;
			endValue2.a = a;
			TweenerCore<Color, Color, ColorOptions> t = DOTween.To(getter, setter, endValue2, duration);
			TweenerCore<Color, Color, ColorOptions> t2 = t.Blendable();
			return t2.SetTarget(target2);
		}

		[Token(Token = "0x600011A")]
		[Address(RVA = "0xC17E50", Offset = "0xC17E50", Length = "0x244")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0038;\n\tv42 = DG.Tweening.Core.DOGetter`1<UnityEngine.Color>;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, property, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv60 = DG.Tweening.Core.DOSetter`1<UnityEngine.Color>;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, property, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv65 = DG.Tweening.DOTween;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, property, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv69 = Il2CppMethodInfo;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, property, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv82 = Il2CppMethodInfo;\n\tv83 = \"il2cpp_codegen_initialize_runtime_metadata\"(v82, property, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv87 = Il2CppMethodInfo;\n\tv88 = \"il2cpp_codegen_initialize_runtime_metadata\"(v87, property, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv174 = Il2CppMethodInfo;\n\tv175 = \"il2cpp_codegen_initialize_runtime_metadata\"(v174, property, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv180 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass70_0;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v180, property, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv56 = 1;\n\t*([1A35727]) = v56;\nL_0038:\n\tv58 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass70_0();\n\tSystem.Object::.ctor(v58);\n\tv58.target = target;\n\tv58.property = property;\n\tv85 = UnityEngine.Material::HasProperty(target, property);\n\tv90 = v85 == 0;\n\tif (v90) goto L_0099;\n\tv183 = UnityEngine.Material::GetColor(v58.target, v58.property);\n\tv58.to = 0;\n\tv58.to.b = 0f;\n\tv144 = endValue - v183;\n\tv147 = endValue.g - v183.g;\n\tv150 = endValue.b - v183.b;\n\tv153 = endValue.a - v183.a;\n\tv202 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v202, v58, Il2CppMethodInfo);\n\tv214 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v214, v58, Il2CppMethodInfo);\n\tgoto L_007D;\n\tv223 = \"il2cpp_codegen_runtime_class_init\"(v220, v217, v130, v126, v46, v47, v48, v49, v183, v196, v197, v198, duration, v50, v51, v52);\nL_007D:\n\t// 125 MakeStruct v121 @ AGGC1BFE8_2_v1 (UnityEngine.Color), typeof(UnityEngine.Color), v144 @ V12_v3 (System.Single), v147 @ V11_v3 (System.Single), v150 @ V10_v3 (System.Single), v153 @ V9_v3 (System.Single)\n\tv227 = DG.Tweening.DOTween::To(v202, v214, v121, duration);\n\tv231 = DG.Tweening.Core.Extensions::Blendable(v227);\n\treturnVal3 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass70_0::<DOBlendableColor>b__1(v231, Color_arg);\n\treturn returnVal3;\n\tX20 = stack[40];\n\tX19 = stack[48];\n\tX22 = stack[30];\n\tX21 = stack[38];\n\tX30 = stack[28];\n\tX2 = *([1936000]);\n\tV9 = stack[18];\n\tV8 = stack[20];\n\tV11 = stack[8];\n\tV10 = stack[10];\n\tV12 = stack[0];\n\t// 146 ShiftStack 80\n\tX0 = DG.Tweening.TweenSettingsExtensions::SetTarget /* +1 sharing this address */(X0, X1, X2);\n\treturn X0;\nL_0099:\n\tgoto L_00AE;\n\tv185 = DG.Tweening.Core.Debugger;\n\tv186 = \"il2cpp_codegen_initialize_runtime_metadata\"(v185, v75, v73, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv189 = 1;\n\t*([1A35757]) = v189;\nL_00AE:\n\tv93 = v193._logPriority < 1;\n\tif (v93) goto L_00BF;\n\tDG.Tweening.Core.Debugger::LogMissingMaterialProperty(v58.property);\nL_00BF:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 125 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOBlendableColor(this Material target, Color endValue, string property, float duration)
		{
			Material target2 = target;
			string property2 = property;
			if (target.HasProperty(property))
			{
				Color color = target2.GetColor(property2);
				Color to = default(Color);
				to.b = 0f;
				Color color2 = default(Color);
				float r = color2.r - color.r;
				float g = endValue.g - color.g;
				float b = endValue.b - color.b;
				float a = endValue.a - color.a;
				DOGetter<Color> getter = () => to;
				DOSetter<Color> setter = delegate(Color color3)
				{
					to = color3;
					to.g = color3.g;
					to.b = color3.b;
					to.a = color3.a;
					float num = color3.a - to.a;
					float num2 = color3.b - to.b;
					float num3 = color3.g - to.g;
					Color color4 = default(Color);
					float num4 = color4.r - to.r;
					Color color5 = target2.GetColor(property2);
					float b2 = num2 + color5.b;
					float a2 = num + color5.a;
					float r2 = num4 + color5.r;
					float g2 = num3 + color5.g;
					Color value = default(Color);
					value.r = r2;
					value.g = g2;
					value.b = b2;
					value.a = a2;
					target2.SetColor(property2, value);
				};
				Color endValue2 = default(Color);
				endValue2.r = r;
				endValue2.g = g;
				endValue2.b = b;
				endValue2.a = a;
				TweenerCore<Color, Color, ColorOptions> t = DOTween.To(getter, setter, endValue2, duration);
				TweenerCore<Color, Color, ColorOptions> tweenerCore = t.Blendable();
				Color x = default(Color);
				x.r = r;
				x.g = g;
				x.b = b;
				x.a = a;
				((_003C_003Ec__DisplayClass70_0)(object)tweenerCore)._003CDOBlendableColor_003Eb__1(x);
				Tweener result = default(Tweener);
				return result;
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogMissingMaterialProperty(property2);
			}
			return null;
		}

		[Token(Token = "0x600011B")]
		[Address(RVA = "0xC1809C", Offset = "0xC1809C", Length = "0x248")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0038;\n\tv42 = DG.Tweening.Core.DOGetter`1<UnityEngine.Color>;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, propertyID, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv60 = DG.Tweening.Core.DOSetter`1<UnityEngine.Color>;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, propertyID, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv65 = DG.Tweening.DOTween;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, propertyID, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv69 = Il2CppMethodInfo;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, propertyID, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv82 = Il2CppMethodInfo;\n\tv83 = \"il2cpp_codegen_initialize_runtime_metadata\"(v82, propertyID, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv87 = Il2CppMethodInfo;\n\tv88 = \"il2cpp_codegen_initialize_runtime_metadata\"(v87, propertyID, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv178 = Il2CppMethodInfo;\n\tv179 = \"il2cpp_codegen_initialize_runtime_metadata\"(v178, propertyID, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv184 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass71_0;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v184, propertyID, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv56 = 1;\n\t*([1A35728]) = v56;\nL_0038:\n\tv58 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass71_0();\n\tSystem.Object::.ctor(v58);\n\tv58.target = target;\n\tv58.propertyID = propertyID;\n\tv85 = UnityEngine.Material::HasProperty(target, propertyID);\n\tv90 = v85 == 0;\n\tif (v90) goto L_0098;\n\tv187 = UnityEngine.Material::GetColor(v58.target, v58.propertyID);\n\tv58.to = 0;\n\tv58.to.b = 0f;\n\tv205 = endValue - v187;\n\tv206 = endValue.g - v187.g;\n\tv207 = endValue.b - v187.b;\n\tv209 = endValue.a - v187.a;\n\tv210 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v210, v58, Il2CppMethodInfo);\n\tv223 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v223, v58, Il2CppMethodInfo);\n\tgoto L_007D;\n\tv234 = \"il2cpp_codegen_runtime_class_init\"(v231, v226, v228, v127, v46, v47, v48, v49, v187, v200, v201, v202, duration, v50, v51, v52);\nL_007D:\n\t// 125 MakeStruct v122 @ AGGC1C238_2_v1 (UnityEngine.Color), typeof(UnityEngine.Color), v205 @ V12_v3 (System.Single), v206 @ V11_v3 (System.Single), v207 @ V10_v3 (System.Single), v209 @ V9_v3 (System.Single)\n\tv238 = DG.Tweening.DOTween::To(v210, v223, v122, duration);\n\tv242 = DG.Tweening.Core.Extensions::Blendable(v238);\n\treturnVal3 = DG.Tweening.TweenSettingsExtensions::SetTarget(v242, v58.target);\n\treturn returnVal3;\nL_0098:\n\tgoto L_00AD;\n\tv189 = DG.Tweening.Core.Debugger;\n\tv190 = \"il2cpp_codegen_initialize_runtime_metadata\"(v189, v75, v73, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv193 = 1;\n\t*([1A35757]) = v193;\nL_00AD:\n\tv93 = v197._logPriority < 1;\n\tif (v93) goto L_00BE;\n\tDG.Tweening.Core.Debugger::LogMissingMaterialProperty(v58.propertyID);\nL_00BE:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 138 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOBlendableColor(this Material target, Color endValue, int propertyID, float duration)
		{
			Material target2 = target;
			int propertyID2 = propertyID;
			if (target.HasProperty(propertyID))
			{
				Color color = target2.GetColor(propertyID2);
				Color to = default(Color);
				to.b = 0f;
				Color color2 = default(Color);
				float r = color2.r - color.r;
				float g = endValue.g - color.g;
				float b = endValue.b - color.b;
				float a = endValue.a - color.a;
				DOGetter<Color> getter = () => to;
				DOSetter<Color> setter = delegate(Color x)
				{
					to = x;
					to.g = x.g;
					to.b = x.b;
					to.a = x.a;
					float num = x.a - to.a;
					float num2 = x.b - to.b;
					float num3 = x.g - to.g;
					Color color3 = default(Color);
					float num4 = color3.r - to.r;
					Color color4 = target2.GetColor(propertyID2);
					float b2 = num2 + color4.b;
					float a2 = num + color4.a;
					float r2 = num4 + color4.r;
					float g2 = num3 + color4.g;
					Color value = default(Color);
					value.r = r2;
					value.g = g2;
					value.b = b2;
					value.a = a2;
					target2.SetColor(propertyID2, value);
				};
				Color endValue2 = default(Color);
				endValue2.r = r;
				endValue2.g = g;
				endValue2.b = b;
				endValue2.a = a;
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

		[Token(Token = "0x600011C")]
		[Address(RVA = "0xC182EC", Offset = "0xC182EC", Length = "0x1F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0039;\n\tv46 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, snapping, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv65 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, snapping, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv70 = DG.Tweening.DOTween;\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, snapping, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv74 = Il2CppMethodInfo;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, snapping, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv92 = Il2CppMethodInfo;\n\tv93 = \"il2cpp_codegen_initialize_runtime_metadata\"(v92, snapping, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv111 = Il2CppMethodInfo;\n\tv112 = \"il2cpp_codegen_initialize_runtime_metadata\"(v111, snapping, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv167 = Il2CppMethodInfo;\n\tv168 = \"il2cpp_codegen_initialize_runtime_metadata\"(v167, snapping, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv172 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass72_0;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v172, snapping, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv61 = 1;\n\t*([1A35729]) = v61;\nL_0039:\n\tv63 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass72_0();\n\tSystem.Object::.ctor(v63);\n\tv63.target = target;\n\tgoto L_0056;\n\tv95 = UnityEngine.Vector3;\n\tv96 = \"il2cpp_codegen_initialize_runtime_metadata\"(v95, v67, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv99 = 1;\n\t*([1A35519]) = v99;\nL_0056:\n\tv102 = UnityEngine.Vector3;\n\tv103 = *([v102 @ X8_v7 (Il2CppClass<UnityEngine.Vector3>)+B8]);\n\tv63.to = v103.zeroVector;\n\tv63.to.z = *([v103 @ X8_v8 (Il2CppStaticFields<UnityEngine.Vector3>)+8]);\n\tv109 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v109, v63, Il2CppMethodInfo);\n\tv170 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v170, v63, Il2CppMethodInfo);\n\tgoto L_007B;\n\tv180 = \"il2cpp_codegen_runtime_class_init\"(v176, v174, v173, v127, v50, v51, v52, v53, v104, v105, v2, duration, v54, v55, v56, v57);\nL_007B:\n\tv186 = DG.Tweening.DOTween::To(v109, v170, byValue, duration);\n\tv188 = DG.Tweening.Core.Extensions::Blendable(v186);\n\tv189 = v188 == 0;\n\tif (v189) goto L_0095;\n\tv191 = ~v188.<active>k__BackingField;\n\tif (v191) goto L_0095;\n\t*([v188 @ X0_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+14C]) = snapping;\nL_0095:\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v188, v63.target);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 105 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOBlendableMoveBy(this Transform target, Vector3 byValue, float duration, bool snapping = false)
		{
			//IL_00a9: Expected I, but got O
			//IL_00b2: Expected I, but got O
			//IL_00da: Expected F4, but got I
			nint num = (nint)typeof(Vector3);
			nint num2 = (nint)Vector3.zero;
			Vector3 to = Vector3.zero;
			ref Vector3 reference = ref to;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X8_v8 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			reference.z = 0f;
			DOGetter<Vector3> getter = () => to;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				to = x;
				to.y = x.y;
				to.z = x.z;
				float num3 = x.z - to.z;
				float num4 = x.y - to.y;
				Vector3 vector = default(Vector3);
				float num5 = vector.x - to.x;
				Vector3 position = target.position;
				float y = num4 + position.y;
				float z = num3 + position.z;
				float x2 = num5 + position.x;
				Vector3 position2 = default(Vector3);
				position2.x = x2;
				position2.y = y;
				position2.z = z;
				target.position = position2;
			};
			TweenerCore<Vector3, Vector3, VectorOptions> t = DOTween.To(getter, setter, byValue, duration);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = t.Blendable();
			if (tweenerCore == null || tweenerCore._003Cactive_003Ek__BackingField)
			{
			}
			return ((Tweener)tweenerCore).SetTarget((object)target);
		}

		[Token(Token = "0x600011D")]
		[Address(RVA = "0xC184E4", Offset = "0xC184E4", Length = "0x1F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0039;\n\tv46 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, snapping, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv65 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, snapping, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv70 = DG.Tweening.DOTween;\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, snapping, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv74 = Il2CppMethodInfo;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, snapping, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv92 = Il2CppMethodInfo;\n\tv93 = \"il2cpp_codegen_initialize_runtime_metadata\"(v92, snapping, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv111 = Il2CppMethodInfo;\n\tv112 = \"il2cpp_codegen_initialize_runtime_metadata\"(v111, snapping, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv167 = Il2CppMethodInfo;\n\tv168 = \"il2cpp_codegen_initialize_runtime_metadata\"(v167, snapping, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv172 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass73_0;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v172, snapping, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv61 = 1;\n\t*([1A3572A]) = v61;\nL_0039:\n\tv63 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass73_0();\n\tSystem.Object::.ctor(v63);\n\tv63.target = target;\n\tgoto L_0056;\n\tv95 = UnityEngine.Vector3;\n\tv96 = \"il2cpp_codegen_initialize_runtime_metadata\"(v95, v67, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv99 = 1;\n\t*([1A35519]) = v99;\nL_0056:\n\tv102 = UnityEngine.Vector3;\n\tv103 = *([v102 @ X8_v7 (Il2CppClass<UnityEngine.Vector3>)+B8]);\n\tv63.to = v103.zeroVector;\n\tv63.to.z = *([v103 @ X8_v8 (Il2CppStaticFields<UnityEngine.Vector3>)+8]);\n\tv109 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v109, v63, Il2CppMethodInfo);\n\tv170 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v170, v63, Il2CppMethodInfo);\n\tgoto L_007B;\n\tv180 = \"il2cpp_codegen_runtime_class_init\"(v176, v174, v173, v127, v50, v51, v52, v53, v104, v105, v2, duration, v54, v55, v56, v57);\nL_007B:\n\tv186 = DG.Tweening.DOTween::To(v109, v170, byValue, duration);\n\tv188 = DG.Tweening.Core.Extensions::Blendable(v186);\n\tv189 = v188 == 0;\n\tif (v189) goto L_0095;\n\tv191 = ~v188.<active>k__BackingField;\n\tif (v191) goto L_0095;\n\t*([v188 @ X0_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+14C]) = snapping;\nL_0095:\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v188, v63.target);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 105 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOBlendableLocalMoveBy(this Transform target, Vector3 byValue, float duration, bool snapping = false)
		{
			//IL_00a9: Expected I, but got O
			//IL_00b2: Expected I, but got O
			//IL_00da: Expected F4, but got I
			nint num = (nint)typeof(Vector3);
			nint num2 = (nint)Vector3.zero;
			Vector3 to = Vector3.zero;
			ref Vector3 reference = ref to;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X8_v8 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			reference.z = 0f;
			DOGetter<Vector3> getter = () => to;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				to = x;
				to.y = x.y;
				to.z = x.z;
				float num3 = x.z - to.z;
				float num4 = x.y - to.y;
				Vector3 vector = default(Vector3);
				float num5 = vector.x - to.x;
				Vector3 localPosition = target.localPosition;
				float y = num4 + localPosition.y;
				float z = num3 + localPosition.z;
				float x2 = num5 + localPosition.x;
				Vector3 localPosition2 = default(Vector3);
				localPosition2.x = x2;
				localPosition2.y = y;
				localPosition2.z = z;
				target.localPosition = localPosition2;
			};
			TweenerCore<Vector3, Vector3, VectorOptions> t = DOTween.To(getter, setter, byValue, duration);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = t.Blendable();
			if (tweenerCore == null || tweenerCore._003Cactive_003Ek__BackingField)
			{
			}
			return ((Tweener)tweenerCore).SetTarget((object)target);
		}

		[Token(Token = "0x600011E")]
		[Address(RVA = "0xC186DC", Offset = "0xC186DC", Length = "0x1E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0039;\n\tv46 = DG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, mode, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv65 = DG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, mode, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv70 = DG.Tweening.DOTween;\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, mode, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv74 = Il2CppMethodInfo;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, mode, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv125 = Il2CppMethodInfo;\n\tv126 = \"il2cpp_codegen_initialize_runtime_metadata\"(v125, mode, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv143 = Il2CppMethodInfo;\n\tv144 = \"il2cpp_codegen_initialize_runtime_metadata\"(v143, mode, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv186 = Il2CppMethodInfo;\n\tv187 = \"il2cpp_codegen_initialize_runtime_metadata\"(v186, mode, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv191 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass74_0;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v191, mode, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv61 = 1;\n\t*([1A3572B]) = v61;\nL_0039:\n\tv63 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass74_0();\n\tSystem.Object::.ctor(v63);\n\tv63.target = target;\n\tgoto L_005A;\n\tv128 = UnityEngine.Quaternion;\n\tv129 = \"il2cpp_codegen_initialize_runtime_metadata\"(v128, v67, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv132 = 1;\n\t*([1A3551A]) = v132;\nL_005A:\n\tv63.to = v137.identityQuaternion;\n\tv141 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>::.ctor(v141, v63, Il2CppMethodInfo);\n\tv189 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>::.ctor(v189, v63, Il2CppMethodInfo);\n\tgoto L_0079;\n\tv197 = \"il2cpp_codegen_runtime_class_init\"(v194, v193, v192, v98, v50, v51, v52, v53, v138, v0, v2, duration, v54, v55, v56, v57);\nL_0079:\n\tv201 = DG.Tweening.DOTween::To(v141, v189, byValue, duration);\n\tv203 = DG.Tweening.Core.Extensions::Blendable(v201);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v203, v63.target);\n\t*([returnVal2 @ X0_v16 (DG.Tweening.Tweener)+148]) = mode;\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 106 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOBlendableRotateBy(this Transform target, Vector3 byValue, float duration, RotateMode mode = RotateMode.Fast)
		{
			Quaternion to = Quaternion.identity;
			DOGetter<Quaternion> getter = () => to;
			DOSetter<Quaternion> setter = delegate(Quaternion x)
			{
				Quaternion rotation = default(Quaternion);
				rotation.x = to.x;
				rotation.y = to.y;
				rotation.z = to.z;
				rotation.w = to.w;
				Quaternion quaternion = Quaternion.Inverse(rotation);
				to = x;
				to.y = x.y;
				to.z = x.z;
				to.w = x.w;
				Quaternion rotation2 = target.rotation;
				Quaternion quaternion2 = Quaternion.Inverse(rotation2);
				Quaternion quaternion3 = default(Quaternion);
				float num = quaternion3.x * quaternion.w;
				float num2 = x.w * quaternion.x;
				float num3 = x.y * quaternion.w;
				float num4 = x.w * quaternion.y;
				float num5 = quaternion3.x * quaternion.x;
				float num6 = x.w * quaternion.z;
				float num7 = x.w * quaternion.w;
				float num8 = x.z * quaternion.w;
				float num9 = num2 + num;
				float num10 = rotation2.w * quaternion2.x;
				float num11 = num4 + num3;
				float num12 = rotation2.x * quaternion2.w;
				float num13 = num6 + num8;
				float num14 = rotation2.w * quaternion2.y;
				float num15 = num7 - num5;
				float num16 = rotation2.y * quaternion2.w;
				float num17 = x.y * quaternion.z;
				float num18 = x.z * quaternion.x;
				float num19 = num10 + num12;
				float num20 = rotation2.w * quaternion2.z;
				float num21 = num14 + num16;
				float num22 = rotation2.z * quaternion2.w;
				float num23 = x.z * quaternion.y;
				float num24 = quaternion3.x * quaternion.y;
				float num25 = x.y * quaternion.y;
				float num26 = rotation2.w * quaternion2.w;
				float num27 = num20 + num22;
				float num28 = rotation2.x * quaternion2.x;
				float num29 = num17 + num9;
				float num30 = num18 + num11;
				float num31 = rotation2.y * quaternion2.z;
				float num32 = num26 - num28;
				float num33 = num24 + num13;
				float num34 = num15 - num25;
				float num35 = rotation2.z * quaternion2.y;
				float num36 = num31 + num19;
				float num37 = rotation2.z * quaternion2.x;
				float num38 = rotation2.x * quaternion2.y;
				float num39 = rotation2.y * quaternion2.y;
				float num40 = quaternion3.x * quaternion.z;
				float num41 = x.y * quaternion.x;
				float num42 = x.z * quaternion.z;
				float num43 = num37 + num21;
				float num44 = num38 + num27;
				float num45 = rotation2.x * quaternion2.z;
				float num46 = rotation2.y * quaternion2.x;
				float num47 = rotation2.z * quaternion2.z;
				float num48 = num32 - num39;
				float num49 = num29 - num23;
				float num50 = num30 - num40;
				float num51 = num33 - num41;
				float num52 = num34 - num42;
				float num53 = num36 - num35;
				float num54 = num43 - num45;
				float num55 = num44 - num46;
				float num56 = num48 - num47;
				float num57 = num49 * num56;
				float num58 = num52 * num53;
				float num59 = num51 * num54;
				float num60 = num50 * num55;
				float num61 = num50 * num56;
				float num62 = num52 * num54;
				float num63 = num49 * num55;
				float num64 = num51 * num53;
				float num65 = num50 * num53;
				float num66 = num49 * num53;
				float num67 = num49 * num54;
				float num68 = num50 * num54;
				float num69 = num51 * num56;
				float num70 = num52 * num56;
				float num71 = num52 * num55;
				float num72 = num51 * num55;
				float num73 = num57 + num58;
				float num74 = num61 + num62;
				float num75 = num69 + num71;
				float num76 = num70 - num66;
				float num77 = num59 + num73;
				float num78 = num63 + num74;
				float num79 = num65 + num75;
				float num80 = num76 - num68;
				float num81 = num77 - num60;
				float num82 = num78 - num64;
				float num83 = num79 - num67;
				float num84 = num80 - num72;
				float num85 = rotation2.w * num84;
				float num86 = rotation2.x * num81;
				float num87 = rotation2.y * num82;
				float num88 = rotation2.z * num83;
				float num89 = rotation2.y * num81;
				float num90 = rotation2.z * num84;
				float num91 = rotation2.w * num83;
				float num92 = rotation2.x * num82;
				float num93 = rotation2.x * num83;
				float num94 = rotation2.y * num84;
				float num95 = rotation2.w * num82;
				float num96 = rotation2.z * num81;
				float num97 = rotation2.z * num82;
				float num98 = rotation2.x * num84;
				float num99 = rotation2.w * num81;
				float num100 = rotation2.y * num83;
				float num101 = num85 - num86;
				float num102 = num90 + num91;
				float num103 = num94 + num95;
				float num104 = num98 + num99;
				float num105 = num101 - num87;
				float num106 = num89 + num102;
				float num107 = num93 + num103;
				float num108 = num97 + num104;
				float w = num105 - num88;
				float z = num106 - num92;
				float y = num107 - num96;
				float x2 = num108 - num100;
				Quaternion rotation3 = default(Quaternion);
				rotation3.x = x2;
				rotation3.y = y;
				rotation3.z = z;
				rotation3.w = w;
				target.rotation = rotation3;
			};
			TweenerCore<Quaternion, Vector3, QuaternionOptions> t = DOTween.To(getter, setter, byValue, duration);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> t2 = t.Blendable();
			return t2.SetTarget(target);
		}

		[Token(Token = "0x600011F")]
		[Address(RVA = "0xC188C4", Offset = "0xC188C4", Length = "0x1E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0039;\n\tv46 = DG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, mode, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv65 = DG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, mode, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv70 = DG.Tweening.DOTween;\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, mode, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv74 = Il2CppMethodInfo;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, mode, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv125 = Il2CppMethodInfo;\n\tv126 = \"il2cpp_codegen_initialize_runtime_metadata\"(v125, mode, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv143 = Il2CppMethodInfo;\n\tv144 = \"il2cpp_codegen_initialize_runtime_metadata\"(v143, mode, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv186 = Il2CppMethodInfo;\n\tv187 = \"il2cpp_codegen_initialize_runtime_metadata\"(v186, mode, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv191 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass75_0;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v191, mode, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv61 = 1;\n\t*([1A3572C]) = v61;\nL_0039:\n\tv63 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass75_0();\n\tSystem.Object::.ctor(v63);\n\tv63.target = target;\n\tgoto L_005A;\n\tv128 = UnityEngine.Quaternion;\n\tv129 = \"il2cpp_codegen_initialize_runtime_metadata\"(v128, v67, methodInfo, v49, v50, v51, v52, v53, byValue, v0, v2, duration, v54, v55, v56, v57);\n\tv132 = 1;\n\t*([1A3551A]) = v132;\nL_005A:\n\tv63.to = v137.identityQuaternion;\n\tv141 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Quaternion>::.ctor(v141, v63, Il2CppMethodInfo);\n\tv189 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Quaternion>::.ctor(v189, v63, Il2CppMethodInfo);\n\tgoto L_0079;\n\tv197 = \"il2cpp_codegen_runtime_class_init\"(v194, v193, v192, v98, v50, v51, v52, v53, v138, v0, v2, duration, v54, v55, v56, v57);\nL_0079:\n\tv201 = DG.Tweening.DOTween::To(v141, v189, byValue, duration);\n\tv203 = DG.Tweening.Core.Extensions::Blendable(v201);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v203, v63.target);\n\t*([returnVal2 @ X0_v16 (DG.Tweening.Tweener)+148]) = mode;\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 106 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOBlendableLocalRotateBy(this Transform target, Vector3 byValue, float duration, RotateMode mode = RotateMode.Fast)
		{
			Quaternion to = Quaternion.identity;
			DOGetter<Quaternion> getter = () => to;
			DOSetter<Quaternion> setter = delegate(Quaternion x)
			{
				Quaternion rotation = default(Quaternion);
				rotation.x = to.x;
				rotation.y = to.y;
				rotation.z = to.z;
				rotation.w = to.w;
				Quaternion quaternion = Quaternion.Inverse(rotation);
				to = x;
				to.y = x.y;
				to.z = x.z;
				to.w = x.w;
				Quaternion localRotation = target.localRotation;
				Quaternion quaternion2 = Quaternion.Inverse(localRotation);
				Quaternion quaternion3 = default(Quaternion);
				float num = quaternion3.x * quaternion.w;
				float num2 = x.w * quaternion.x;
				float num3 = x.y * quaternion.w;
				float num4 = x.w * quaternion.y;
				float num5 = quaternion3.x * quaternion.x;
				float num6 = x.w * quaternion.z;
				float num7 = x.w * quaternion.w;
				float num8 = x.z * quaternion.w;
				float num9 = num2 + num;
				float num10 = localRotation.w * quaternion2.x;
				float num11 = num4 + num3;
				float num12 = localRotation.x * quaternion2.w;
				float num13 = num6 + num8;
				float num14 = localRotation.w * quaternion2.y;
				float num15 = num7 - num5;
				float num16 = localRotation.y * quaternion2.w;
				float num17 = x.y * quaternion.z;
				float num18 = x.z * quaternion.x;
				float num19 = num10 + num12;
				float num20 = localRotation.w * quaternion2.z;
				float num21 = num14 + num16;
				float num22 = localRotation.z * quaternion2.w;
				float num23 = x.z * quaternion.y;
				float num24 = quaternion3.x * quaternion.y;
				float num25 = x.y * quaternion.y;
				float num26 = localRotation.w * quaternion2.w;
				float num27 = num20 + num22;
				float num28 = localRotation.x * quaternion2.x;
				float num29 = num17 + num9;
				float num30 = num18 + num11;
				float num31 = localRotation.y * quaternion2.z;
				float num32 = num26 - num28;
				float num33 = num24 + num13;
				float num34 = num15 - num25;
				float num35 = localRotation.z * quaternion2.y;
				float num36 = num31 + num19;
				float num37 = localRotation.z * quaternion2.x;
				float num38 = localRotation.x * quaternion2.y;
				float num39 = localRotation.y * quaternion2.y;
				float num40 = quaternion3.x * quaternion.z;
				float num41 = x.y * quaternion.x;
				float num42 = x.z * quaternion.z;
				float num43 = num37 + num21;
				float num44 = num38 + num27;
				float num45 = localRotation.x * quaternion2.z;
				float num46 = localRotation.y * quaternion2.x;
				float num47 = localRotation.z * quaternion2.z;
				float num48 = num32 - num39;
				float num49 = num29 - num23;
				float num50 = num30 - num40;
				float num51 = num33 - num41;
				float num52 = num34 - num42;
				float num53 = num36 - num35;
				float num54 = num43 - num45;
				float num55 = num44 - num46;
				float num56 = num48 - num47;
				float num57 = num49 * num56;
				float num58 = num52 * num53;
				float num59 = num51 * num54;
				float num60 = num50 * num55;
				float num61 = num50 * num56;
				float num62 = num52 * num54;
				float num63 = num49 * num55;
				float num64 = num51 * num53;
				float num65 = num50 * num53;
				float num66 = num49 * num53;
				float num67 = num49 * num54;
				float num68 = num50 * num54;
				float num69 = num51 * num56;
				float num70 = num52 * num56;
				float num71 = num52 * num55;
				float num72 = num51 * num55;
				float num73 = num57 + num58;
				float num74 = num61 + num62;
				float num75 = num69 + num71;
				float num76 = num70 - num66;
				float num77 = num59 + num73;
				float num78 = num63 + num74;
				float num79 = num65 + num75;
				float num80 = num76 - num68;
				float num81 = num77 - num60;
				float num82 = num78 - num64;
				float num83 = num79 - num67;
				float num84 = num80 - num72;
				float num85 = localRotation.w * num84;
				float num86 = localRotation.x * num81;
				float num87 = localRotation.y * num82;
				float num88 = localRotation.z * num83;
				float num89 = localRotation.y * num81;
				float num90 = localRotation.z * num84;
				float num91 = localRotation.w * num83;
				float num92 = localRotation.x * num82;
				float num93 = localRotation.x * num83;
				float num94 = localRotation.y * num84;
				float num95 = localRotation.w * num82;
				float num96 = localRotation.z * num81;
				float num97 = localRotation.z * num82;
				float num98 = localRotation.x * num84;
				float num99 = localRotation.w * num81;
				float num100 = localRotation.y * num83;
				float num101 = num85 - num86;
				float num102 = num90 + num91;
				float num103 = num94 + num95;
				float num104 = num98 + num99;
				float num105 = num101 - num87;
				float num106 = num89 + num102;
				float num107 = num93 + num103;
				float num108 = num97 + num104;
				float w = num105 - num88;
				float z = num106 - num92;
				float y = num107 - num96;
				float x2 = num108 - num100;
				Quaternion localRotation2 = default(Quaternion);
				localRotation2.x = x2;
				localRotation2.y = y;
				localRotation2.z = z;
				localRotation2.w = w;
				target.localRotation = localRotation2;
			};
			TweenerCore<Quaternion, Vector3, QuaternionOptions> t = DOTween.To(getter, setter, byValue, duration);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> t2 = t.Blendable();
			return t2.SetTarget(target);
		}

		[Token(Token = "0x6000120")]
		[Address(RVA = "0xC18AAC", Offset = "0xC18AAC", Length = "0x288")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003D;\n\tv42 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, vibrato, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\n\tv60 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, vibrato, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\n\tv65 = DG.Tweening.DOTween;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, vibrato, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\n\tv69 = UnityEngine.Debug;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, vibrato, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\n\tv84 = Il2CppMethodInfo;\n\tv85 = \"il2cpp_codegen_initialize_runtime_metadata\"(v84, vibrato, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\n\tv95 = Il2CppMethodInfo;\n\tv96 = \"il2cpp_codegen_initialize_runtime_metadata\"(v95, vibrato, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\n\tv213 = Il2CppMethodInfo;\n\tv214 = \"il2cpp_codegen_initialize_runtime_metadata\"(v213, vibrato, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\n\tv232 = Il2CppMethodInfo;\n\tv233 = \"il2cpp_codegen_initialize_runtime_metadata\"(v232, vibrato, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\n\tv242 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass76_0;\n\tv243 = \"il2cpp_codegen_initialize_runtime_metadata\"(v242, vibrato, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\n\tv250 = \"DOBlendablePunchRotation: duration can't be 0, returning NULL without creating a tween\";\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v250, vibrato, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\n\tv56 = 1;\n\t*([1A3572D]) = v56;\nL_003D:\n\tv58 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass76_0();\n\tSystem.Object::.ctor(v58);\n\tv71 = duration < 0;\n\tv72 = ~v71;\n\tv75 = duration == 0;\n\tv58.target = target;\n\tv80 = ~v72;\n\tv81 = v80 | v75;\n\tif (v81) goto L_00A3;\n\tgoto L_005C;\n\tv98 = UnityEngine.Vector3;\n\tv99 = \"il2cpp_codegen_initialize_runtime_metadata\"(v98, v62, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\n\tv102 = 1;\n\t*([1A35519]) = v102;\nL_005C:\n\tv105 = UnityEngine.Vector3;\n\tv106 = *([v105 @ X8_v21 (Il2CppClass<UnityEngine.Vector3>)+B8]);\n\tv58.to = v106.zeroVector;\n\tv58.to.z = *([v106 @ X8_v22 (Il2CppStaticFields<UnityEngine.Vector3>)+8]);\n\tv112 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v112, v58, Il2CppMethodInfo);\n\tv237 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v237, v58, Il2CppMethodInfo);\n\tgoto L_0089;\n\tv256 = \"il2cpp_codegen_runtime_class_init\"(v253, v246, v248, v150, v46, v47, v48, v49, v107, v108, v2, duration, elasticity, v50, v51, v52);\nL_0089:\n\tv261 = DG.Tweening.DOTween::Punch(v112, v237, punch, duration, vibrato, elasticity);\n\tv265 = DG.Tweening.Core.Extensions::Blendable(v261);\n\treturnVal3 = DG.Tweening.TweenSettingsExtensions::SetTarget(v265, v58.target);\n\treturn returnVal3;\nL_00A3:\n\tgoto L_00B8;\n\tv114 = DG.Tweening.Core.Debugger;\n\tv115 = \"il2cpp_codegen_initialize_runtime_metadata\"(v114, v62, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\n\tv118 = 1;\n\t*([1A35757]) = v118;\nL_00B8:\n\tv134 = v122._logPriority < 1;\n\tif (v134) goto L_00D3;\n\tgoto L_00C6;\n\tv238 = \"il2cpp_codegen_runtime_class_init\"(v223, v62, methodInfo, v45, v46, v47, v48, v49, punch, v0, v2, duration, elasticity, v50, v51, v52);\nL_00C6:\n\tUnityEngine.Debug::LogWarning(\"DOBlendablePunchRotation: duration can't be 0, returning NULL without creating a tween\");\nL_00D3:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 150 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOBlendablePunchRotation(this Transform target, Vector3 punch, float duration, int vibrato = 10, float elasticity = 1f)
		{
			//IL_00f5: Expected I, but got O
			//IL_00fe: Expected I, but got O
			//IL_0126: Expected F4, but got I
			bool flag = duration < 0f;
			bool flag2 = !flag;
			bool flag3 = duration == 0f;
			Transform target2 = target;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				nint num = (nint)typeof(Vector3);
				nint num2 = (nint)Vector3.zero;
				Vector3 to = Vector3.zero;
				ref Vector3 reference = ref to;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ X8_v22 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				reference.z = 0f;
				DOGetter<Vector3> getter = () => to;
				DOSetter<Vector3> setter = delegate(Vector3 v)
				{
					float x = to.x * ((float)Math.PI / 180f);
					float y = to.y * ((float)Math.PI / 180f);
					float z = to.z * ((float)Math.PI / 180f);
					Vector3 vector = default(Vector3);
					vector.x = x;
					vector.y = y;
					vector.z = z;
					Quaternion rotation = Quaternion.Euler(vector * 57.29578f);
					Vector3 vector2 = default(Vector3);
					float x2 = vector2.x * ((float)Math.PI / 180f);
					float y2 = v.y * ((float)Math.PI / 180f);
					float z2 = v.z * ((float)Math.PI / 180f);
					Vector3 vector3 = default(Vector3);
					vector3.x = x2;
					vector3.y = y2;
					vector3.z = z2;
					Quaternion quaternion = Quaternion.Euler(vector3 * 57.29578f);
					Quaternion quaternion2 = Quaternion.Inverse(rotation);
					to = v;
					to.y = v.y;
					to.z = v.z;
					Quaternion rotation2 = target2.rotation;
					Quaternion quaternion3 = Quaternion.Inverse(rotation2);
					float num3 = quaternion.w * quaternion2.x;
					float num4 = quaternion.x * quaternion2.w;
					float num5 = quaternion.w * quaternion2.y;
					float num6 = quaternion.y * quaternion2.w;
					float num7 = quaternion.x * quaternion2.z;
					float num8 = quaternion.x * quaternion2.y;
					float num9 = quaternion.x * quaternion2.x;
					float num10 = quaternion.w * quaternion2.z;
					float num11 = quaternion.w * quaternion2.w;
					float num12 = quaternion.z * quaternion2.w;
					float num13 = num3 + num4;
					float num14 = rotation2.w * quaternion3.x;
					float num15 = num5 + num6;
					float num16 = rotation2.x * quaternion3.w;
					float num17 = num10 + num12;
					float num18 = rotation2.w * quaternion3.y;
					float num19 = num11 - num9;
					float num20 = rotation2.y * quaternion3.w;
					float num21 = quaternion.y * quaternion2.z;
					float num22 = quaternion.z * quaternion2.x;
					float num23 = num14 + num16;
					float num24 = rotation2.w * quaternion3.z;
					float num25 = num18 + num20;
					float num26 = rotation2.z * quaternion3.w;
					float num27 = quaternion.y * quaternion2.x;
					float num28 = quaternion.y * quaternion2.y;
					float num29 = rotation2.w * quaternion3.w;
					float num30 = num24 + num26;
					float num31 = rotation2.x * quaternion3.x;
					float num32 = num21 + num13;
					float num33 = num22 + num15;
					float num34 = rotation2.y * quaternion3.z;
					float num35 = num29 - num31;
					float num36 = num8 + num17;
					float num37 = num19 - num28;
					float num38 = rotation2.z * quaternion3.y;
					float num39 = num34 + num23;
					float num40 = rotation2.z * quaternion3.x;
					float num41 = rotation2.x * quaternion3.y;
					float num42 = rotation2.y * quaternion3.y;
					float num43 = quaternion.z * quaternion2.y;
					float num44 = quaternion.z * quaternion2.z;
					float num45 = num40 + num25;
					float num46 = num41 + num30;
					float num47 = rotation2.x * quaternion3.z;
					float num48 = rotation2.y * quaternion3.x;
					float num49 = rotation2.z * quaternion3.z;
					float num50 = num35 - num42;
					float num51 = num32 - num43;
					float num52 = num33 - num7;
					float num53 = num36 - num27;
					float num54 = num37 - num44;
					float num55 = num39 - num38;
					float num56 = num45 - num47;
					float num57 = num46 - num48;
					float num58 = num50 - num49;
					float num59 = num51 * num58;
					float num60 = num54 * num55;
					float num61 = num53 * num56;
					float num62 = num52 * num57;
					float num63 = num52 * num58;
					float num64 = num54 * num56;
					float num65 = num51 * num57;
					float num66 = num53 * num55;
					float num67 = num52 * num55;
					float num68 = num51 * num55;
					float num69 = num51 * num56;
					float num70 = num52 * num56;
					float num71 = num53 * num58;
					float num72 = num54 * num58;
					float num73 = num54 * num57;
					float num74 = num53 * num57;
					float num75 = num59 + num60;
					float num76 = num63 + num64;
					float num77 = num71 + num73;
					float num78 = num72 - num68;
					float num79 = num61 + num75;
					float num80 = num65 + num76;
					float num81 = num67 + num77;
					float num82 = num78 - num70;
					float num83 = num79 - num62;
					float num84 = num80 - num66;
					float num85 = num81 - num69;
					float num86 = num82 - num74;
					float num87 = rotation2.w * num86;
					float num88 = rotation2.x * num83;
					float num89 = rotation2.y * num84;
					float num90 = rotation2.z * num85;
					float num91 = rotation2.y * num83;
					float num92 = rotation2.z * num86;
					float num93 = rotation2.w * num85;
					float num94 = rotation2.x * num84;
					float num95 = rotation2.x * num85;
					float num96 = rotation2.y * num86;
					float num97 = rotation2.w * num84;
					float num98 = rotation2.z * num83;
					float num99 = rotation2.z * num84;
					float num100 = rotation2.x * num86;
					float num101 = rotation2.w * num83;
					float num102 = rotation2.y * num85;
					float num103 = num87 - num88;
					float num104 = num92 + num93;
					float num105 = num96 + num97;
					float num106 = num100 + num101;
					float num107 = num103 - num89;
					float num108 = num91 + num104;
					float num109 = num95 + num105;
					float num110 = num99 + num106;
					float w = num107 - num90;
					float z3 = num108 - num94;
					float y3 = num109 - num98;
					float x3 = num110 - num102;
					Quaternion rotation3 = default(Quaternion);
					rotation3.x = x3;
					rotation3.y = y3;
					rotation3.z = z3;
					rotation3.w = w;
					target2.rotation = rotation3;
				};
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = DOTween.Punch(getter, setter, punch, duration, vibrato, elasticity);
				TweenerCore<Vector3, object, Vector3ArrayOptions> t2 = ((TweenerCore<Vector3, object, Vector3ArrayOptions>)(object)t).Blendable();
				return ((TweenerCore<Vector3, Vector3[], Vector3ArrayOptions>)(object)t2).SetTarget(target2);
			}
			if (Debugger._logPriority >= 1)
			{
				Debug.LogWarning("DOBlendablePunchRotation: duration can't be 0, returning NULL without creating a tween");
			}
			return null;
		}

		[Token(Token = "0x6000121")]
		[Address(RVA = "0xC18D3C", Offset = "0xC18D3C", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0037;\n\tv42 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, methodInfo, v45, v46, v47, v48, v49, v50, byValue, v0, v2, duration, v51, v52, v53, v54);\n\tv62 = DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, methodInfo, v45, v46, v47, v48, v49, v50, byValue, v0, v2, duration, v51, v52, v53, v54);\n\tv67 = DG.Tweening.DOTween;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, methodInfo, v45, v46, v47, v48, v49, v50, byValue, v0, v2, duration, v51, v52, v53, v54);\n\tv71 = Il2CppMethodInfo;\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, methodInfo, v45, v46, v47, v48, v49, v50, byValue, v0, v2, duration, v51, v52, v53, v54);\n\tv89 = Il2CppMethodInfo;\n\tv90 = \"il2cpp_codegen_initialize_runtime_metadata\"(v89, methodInfo, v45, v46, v47, v48, v49, v50, byValue, v0, v2, duration, v51, v52, v53, v54);\n\tv110 = Il2CppMethodInfo;\n\tv111 = \"il2cpp_codegen_initialize_runtime_metadata\"(v110, methodInfo, v45, v46, v47, v48, v49, v50, byValue, v0, v2, duration, v51, v52, v53, v54);\n\tv164 = Il2CppMethodInfo;\n\tv165 = \"il2cpp_codegen_initialize_runtime_metadata\"(v164, methodInfo, v45, v46, v47, v48, v49, v50, byValue, v0, v2, duration, v51, v52, v53, v54);\n\tv169 = DG.Tweening.ShortcutExtensions+<>c__DisplayClass77_0;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v169, methodInfo, v45, v46, v47, v48, v49, v50, byValue, v0, v2, duration, v51, v52, v53, v54);\n\tv58 = 1;\n\t*([1A3572E]) = v58;\nL_0037:\n\tv60 = new DG.Tweening.ShortcutExtensions+<>c__DisplayClass77_0();\n\tSystem.Object::.ctor(v60);\n\tv60.target = target;\n\tgoto L_0055;\n\tv92 = UnityEngine.Vector3;\n\tv93 = \"il2cpp_codegen_initialize_runtime_metadata\"(v92, v64, v45, v46, v47, v48, v49, v50, byValue, v0, v2, duration, v51, v52, v53, v54);\n\tv96 = 1;\n\t*([1A35519]) = v96;\nL_0055:\n\tv100 = UnityEngine.Vector3;\n\tv101 = *([v100 @ X8_v7 (Il2CppClass<UnityEngine.Vector3>)+B8]);\n\tv60.to = v101.zeroVector;\n\tv60.to.z = *([v101 @ X8_v8 (Il2CppStaticFields<UnityEngine.Vector3>)+8]);\n\tv108 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::.ctor(v108, v60, Il2CppMethodInfo);\n\tv167 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::.ctor(v167, v60, Il2CppMethodInfo);\n\tgoto L_0079;\n\tv175 = \"il2cpp_codegen_runtime_class_init\"(v173, v171, v170, v126, v47, v48, v49, v50, v102, v103, v2, duration, v51, v52, v53, v54);\nL_0079:\n\tv179 = DG.Tweening.DOTween::To(v108, v167, byValue, duration);\n\tv181 = DG.Tweening.Core.Extensions::Blendable(v179);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v181, v60.target);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOBlendableScaleBy(this Transform target, Vector3 byValue, float duration)
		{
			//IL_007f: Expected I, but got O
			//IL_0088: Expected I, but got O
			//IL_00b0: Expected F4, but got I
			nint num = (nint)typeof(Vector3);
			nint num2 = (nint)Vector3.zero;
			Vector3 to = Vector3.zero;
			ref Vector3 reference = ref to;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ X8_v8 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			reference.z = 0f;
			DOGetter<Vector3> getter = () => to;
			DOSetter<Vector3> setter = delegate(Vector3 x)
			{
				to = x;
				to.y = x.y;
				to.z = x.z;
				float num3 = x.z - to.z;
				float num4 = x.y - to.y;
				Vector3 vector = default(Vector3);
				float num5 = vector.x - to.x;
				Vector3 localScale = target.localScale;
				float y = num4 + localScale.y;
				float z = num3 + localScale.z;
				float x2 = num5 + localScale.x;
				Vector3 localScale2 = default(Vector3);
				localScale2.x = x2;
				localScale2.y = y;
				localScale2.z = z;
				target.localScale = localScale2;
			};
			TweenerCore<Vector3, Vector3, VectorOptions> t = DOTween.To(getter, setter, byValue, duration);
			TweenerCore<Vector3, Vector3, VectorOptions> t2 = t.Blendable();
			return t2.SetTarget(target);
		}

		[Token(Token = "0x6000122")]
		[Address(RVA = "0xC18F14", Offset = "0xC18F14", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = DG.Tweening.DOTween;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, withCallbacks, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A3572F]) = v40;\nL_0019:\n\tgoto L_0023;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, withCallbacks, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0023:\n\treturnVal1 = DG.Tweening.DOTween::Complete(target, withCallbacks);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOComplete(this Component target, bool withCallbacks = false)
		{
			return DOTween.Complete(target, withCallbacks);
		}

		[Token(Token = "0x6000123")]
		[Address(RVA = "0xC18F78", Offset = "0xC18F78", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = DG.Tweening.DOTween;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, withCallbacks, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A35730]) = v40;\nL_0019:\n\tgoto L_0023;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, withCallbacks, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0023:\n\treturnVal1 = DG.Tweening.DOTween::Complete(target, withCallbacks);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOComplete(this Material target, bool withCallbacks = false)
		{
			return DOTween.Complete(target, withCallbacks);
		}

		[Token(Token = "0x6000124")]
		[Address(RVA = "0xC18FDC", Offset = "0xC18FDC", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = DG.Tweening.DOTween;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, complete, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A35731]) = v40;\nL_0019:\n\tgoto L_0023;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, complete, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0023:\n\treturnVal1 = DG.Tweening.DOTween::Kill(target, complete);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOKill(this Component target, bool complete = false)
		{
			return DOTween.Kill(target, complete);
		}

		[Token(Token = "0x6000125")]
		[Address(RVA = "0xC19040", Offset = "0xC19040", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = DG.Tweening.DOTween;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, complete, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A35732]) = v40;\nL_0019:\n\tgoto L_0023;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, complete, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0023:\n\treturnVal1 = DG.Tweening.DOTween::Kill(target, complete);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOKill(this Material target, bool complete = false)
		{
			return DOTween.Kill(target, complete);
		}

		[Token(Token = "0x6000126")]
		[Address(RVA = "0xC190A4", Offset = "0xC190A4", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = DG.Tweening.DOTween;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35733]) = v37;\nL_0017:\n\tgoto L_001F;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\treturnVal1 = DG.Tweening.DOTween::Flip(target);\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOFlip(this Component target)
		{
			return DOTween.Flip(target);
		}

		[Token(Token = "0x6000127")]
		[Address(RVA = "0xC190F8", Offset = "0xC190F8", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = DG.Tweening.DOTween;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35734]) = v37;\nL_0017:\n\tgoto L_001F;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\treturnVal1 = DG.Tweening.DOTween::Flip(target);\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOFlip(this Material target)
		{
			return DOTween.Flip(target);
		}

		[Token(Token = "0x6000128")]
		[Address(RVA = "0xC1914C", Offset = "0xC1914C", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = DG.Tweening.DOTween;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, andPlay, methodInfo, v29, v30, v31, v32, v33, to, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A35735]) = v43;\nL_001B:\n\tgoto L_0027;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v44, andPlay, methodInfo, v29, v30, v31, v32, v33, to, v34, v35, v36, v37, v38, v39, v40);\nL_0027:\n\treturnVal1 = DG.Tweening.DOTween::Goto(target, to, andPlay);\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOGoto(this Component target, float to, bool andPlay = false)
		{
			return DOTween.Goto(target, to, andPlay);
		}

		[Token(Token = "0x6000129")]
		[Address(RVA = "0xC191C0", Offset = "0xC191C0", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = DG.Tweening.DOTween;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, andPlay, methodInfo, v29, v30, v31, v32, v33, to, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A35736]) = v43;\nL_001B:\n\tgoto L_0027;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v44, andPlay, methodInfo, v29, v30, v31, v32, v33, to, v34, v35, v36, v37, v38, v39, v40);\nL_0027:\n\treturnVal1 = DG.Tweening.DOTween::Goto(target, to, andPlay);\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOGoto(this Material target, float to, bool andPlay = false)
		{
			return DOTween.Goto(target, to, andPlay);
		}

		[Token(Token = "0x600012A")]
		[Address(RVA = "0xC19234", Offset = "0xC19234", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = DG.Tweening.DOTween;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35737]) = v37;\nL_0017:\n\tgoto L_001F;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\treturnVal1 = DG.Tweening.DOTween::Pause(target);\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOPause(this Component target)
		{
			return DOTween.Pause(target);
		}

		[Token(Token = "0x600012B")]
		[Address(RVA = "0xC19288", Offset = "0xC19288", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = DG.Tweening.DOTween;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35738]) = v37;\nL_0017:\n\tgoto L_001F;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\treturnVal1 = DG.Tweening.DOTween::Pause(target);\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOPause(this Material target)
		{
			return DOTween.Pause(target);
		}

		[Token(Token = "0x600012C")]
		[Address(RVA = "0xC192DC", Offset = "0xC192DC", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = DG.Tweening.DOTween;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35739]) = v37;\nL_0017:\n\tgoto L_001F;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\treturnVal1 = DG.Tweening.DOTween::Play(target);\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOPlay(this Component target)
		{
			return DOTween.Play(target);
		}

		[Token(Token = "0x600012D")]
		[Address(RVA = "0xC19330", Offset = "0xC19330", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = DG.Tweening.DOTween;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A3573A]) = v37;\nL_0017:\n\tgoto L_001F;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\treturnVal1 = DG.Tweening.DOTween::Play(target);\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOPlay(this Material target)
		{
			return DOTween.Play(target);
		}

		[Token(Token = "0x600012E")]
		[Address(RVA = "0xC19384", Offset = "0xC19384", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = DG.Tweening.DOTween;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A3573B]) = v37;\nL_0017:\n\tgoto L_001F;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\treturnVal1 = DG.Tweening.DOTween::PlayBackwards(target);\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOPlayBackwards(this Component target)
		{
			return DOTween.PlayBackwards(target);
		}

		[Token(Token = "0x600012F")]
		[Address(RVA = "0xC193D8", Offset = "0xC193D8", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = DG.Tweening.DOTween;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A3573C]) = v37;\nL_0017:\n\tgoto L_001F;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\treturnVal1 = DG.Tweening.DOTween::PlayBackwards(target);\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOPlayBackwards(this Material target)
		{
			return DOTween.PlayBackwards(target);
		}

		[Token(Token = "0x6000130")]
		[Address(RVA = "0xC1942C", Offset = "0xC1942C", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = DG.Tweening.DOTween;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A3573D]) = v37;\nL_0017:\n\tgoto L_001F;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\treturnVal1 = DG.Tweening.DOTween::PlayForward(target);\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOPlayForward(this Component target)
		{
			return DOTween.PlayForward(target);
		}

		[Token(Token = "0x6000131")]
		[Address(RVA = "0xC19480", Offset = "0xC19480", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = DG.Tweening.DOTween;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A3573E]) = v37;\nL_0017:\n\tgoto L_001F;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\treturnVal1 = DG.Tweening.DOTween::PlayForward(target);\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOPlayForward(this Material target)
		{
			return DOTween.PlayForward(target);
		}

		[Token(Token = "0x6000132")]
		[Address(RVA = "0xC194D4", Offset = "0xC194D4", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = DG.Tweening.DOTween;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, includeDelay, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A3573F]) = v40;\nL_0019:\n\tgoto L_0024;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, includeDelay, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\treturnVal1 = DG.Tweening.DOTween::Restart(target, includeDelay, -1f);\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DORestart(this Component target, bool includeDelay = true)
		{
			return DOTween.Restart(target, includeDelay);
		}

		[Token(Token = "0x6000133")]
		[Address(RVA = "0xC1953C", Offset = "0xC1953C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = DG.Tweening.DOTween;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, includeDelay, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A35740]) = v40;\nL_0019:\n\tgoto L_0024;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, includeDelay, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\treturnVal1 = DG.Tweening.DOTween::Restart(target, includeDelay, -1f);\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DORestart(this Material target, bool includeDelay = true)
		{
			return DOTween.Restart(target, includeDelay);
		}

		[Token(Token = "0x6000134")]
		[Address(RVA = "0xC195A4", Offset = "0xC195A4", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = DG.Tweening.DOTween;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, includeDelay, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A35741]) = v40;\nL_0019:\n\tgoto L_0023;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, includeDelay, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0023:\n\treturnVal1 = DG.Tweening.DOTween::Rewind(target, includeDelay);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DORewind(this Component target, bool includeDelay = true)
		{
			return DOTween.Rewind(target, includeDelay);
		}

		[Token(Token = "0x6000135")]
		[Address(RVA = "0xC19608", Offset = "0xC19608", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = DG.Tweening.DOTween;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, includeDelay, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A35742]) = v40;\nL_0019:\n\tgoto L_0023;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, includeDelay, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0023:\n\treturnVal1 = DG.Tweening.DOTween::Rewind(target, includeDelay);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DORewind(this Material target, bool includeDelay = true)
		{
			return DOTween.Rewind(target, includeDelay);
		}

		[Token(Token = "0x6000136")]
		[Address(RVA = "0xC1966C", Offset = "0xC1966C", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = DG.Tweening.DOTween;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35743]) = v37;\nL_0017:\n\tgoto L_001F;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\treturnVal1 = DG.Tweening.DOTween::SmoothRewind(target);\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOSmoothRewind(this Component target)
		{
			return DOTween.SmoothRewind(target);
		}

		[Token(Token = "0x6000137")]
		[Address(RVA = "0xC196C0", Offset = "0xC196C0", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = DG.Tweening.DOTween;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35744]) = v37;\nL_0017:\n\tgoto L_001F;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\treturnVal1 = DG.Tweening.DOTween::SmoothRewind(target);\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOSmoothRewind(this Material target)
		{
			return DOTween.SmoothRewind(target);
		}

		[Token(Token = "0x6000138")]
		[Address(RVA = "0xC19714", Offset = "0xC19714", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = DG.Tweening.DOTween;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35745]) = v37;\nL_0017:\n\tgoto L_001F;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\treturnVal1 = DG.Tweening.DOTween::TogglePause(target);\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOTogglePause(this Component target)
		{
			return DOTween.TogglePause(target);
		}

		[Token(Token = "0x6000139")]
		[Address(RVA = "0xC19768", Offset = "0xC19768", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = DG.Tweening.DOTween;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35746]) = v37;\nL_0017:\n\tgoto L_001F;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\treturnVal1 = DG.Tweening.DOTween::TogglePause(target);\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOTogglePause(this Material target)
		{
			return DOTween.TogglePause(target);
		}
	}
}
