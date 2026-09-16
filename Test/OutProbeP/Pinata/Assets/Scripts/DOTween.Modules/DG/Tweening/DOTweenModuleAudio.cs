using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Audio;

namespace DG.Tweening
{
	[Token(Token = "0x2000002")]
	public static class DOTweenModuleAudio
	{
		[Token(Token = "0x6000001")]
		[Address(RVA = "0x15756F0", Offset = "0x15756F0", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1EBFFA0]);\n\tv31 = *([v30 @ X8_v22]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, endValue, duration, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([202913E]) = v48;\nL_001C:\n\tv52 = new DG.Tweening.DOTweenModuleAudio+<>c__DisplayClass0_0();\n\tSystem.Object::.ctor(v52);\n\tv59 = endValue < 0;\n\tv52.target = target;\n\tif (v59) goto L_0041;\n\tv81 = endValue <= 1f;\n\tif (v81) goto L_0041;\nL_0041:\n\tv98 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v98, v52, Il2CppMethodInfo);\n\tv162 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v162, v52, Il2CppMethodInfo);\n\tgoto L_0069;\n\tv175 = *([v171 @ X0_v10+E0]);\n\tv176 = v175 == 0;\n\tv177 = ~v176;\n\tif (v177) goto L_0069;\n\tv179 = \"il2cpp_codegen_runtime_class_init\"(v171, v166, v168, v114, v36, v37, v38, v39, v84, duration, v40, v41, v42, v43, v44, v45);\nL_0069:\n\tv184 = DG.Tweening.DOTween::To(v98, v162, v85, duration);\n\tv187 = DG.Tweening.TweenSettingsExtensions::SetTarget(v184, v52.target);\n\treturn v184;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 98 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<float, float, FloatOptions> DOFade(this AudioSource target, float endValue, float duration)
		{
			bool flag = endValue < 0f;
			AudioSource target2 = target;
			float endValue2 = 0f;
			if (!flag)
			{
				bool flag2 = !(endValue > 1f);
				endValue2 = endValue;
				if (!flag2)
				{
					endValue2 = 1f;
				}
			}
			DOGetter<float> getter = () => target2.volume;
			DOSetter<float> setter = delegate(float x)
			{
				target2.volume = x;
			};
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, endValue2, duration);
			TweenerCore<float, float, FloatOptions> tweenerCore2 = tweenerCore.SetTarget(target2);
			return tweenerCore;
		}

		[Token(Token = "0x6000002")]
		[Address(RVA = "0x1575860", Offset = "0x1575860", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1EB6098]);\n\tv29 = *([v28 @ X8_v22]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202913F]) = v46;\nL_001B:\n\tv50 = new DG.Tweening.DOTweenModuleAudio+<>c__DisplayClass1_0();\n\tSystem.Object::.ctor(v50);\n\tv50.target = target;\n\tv57 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v57, v50, Il2CppMethodInfo);\n\tv71 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v71, v50, Il2CppMethodInfo);\n\tgoto L_004D;\n\tv117 = *([v113 @ X0_v10+E0]);\n\tv118 = v117 == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_004D;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v113, v108, v110, v81, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\nL_004D:\n\tv126 = DG.Tweening.DOTween::To(v57, v71, endValue, duration);\n\tv129 = DG.Tweening.TweenSettingsExtensions::SetTarget(v126, v50.target);\n\treturn v126;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<float, float, FloatOptions> DOPitch(this AudioSource target, float endValue, float duration)
		{
			DOGetter<float> getter = () => target.pitch;
			DOSetter<float> setter = delegate(float x)
			{
				target.pitch = x;
			};
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<float, float, FloatOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x6000003")]
		[Address(RVA = "0x15759A8", Offset = "0x15759A8", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1EAA8B0]);\n\tv31 = *([v30 @ X8_v22]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, floatName, methodInfo, v34, v35, v36, v37, v38, endValue, duration, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2029140]) = v47;\nL_001C:\n\tv51 = new DG.Tweening.DOTweenModuleAudio+<>c__DisplayClass2_0();\n\tSystem.Object::.ctor(v51);\n\tv51.target = target;\n\tv51.floatName = floatName;\n\tv58 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v58, v51, Il2CppMethodInfo);\n\tv72 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v72, v51, Il2CppMethodInfo);\n\tgoto L_004F;\n\tv118 = *([v114 @ X0_v10+E0]);\n\tv119 = v118 == 0;\n\tv120 = ~v119;\n\tif (v120) goto L_004F;\n\tv122 = \"il2cpp_codegen_runtime_class_init\"(v114, v109, v111, v80, v35, v36, v37, v38, endValue, duration, v39, v40, v41, v42, v43, v44);\nL_004F:\n\tv127 = DG.Tweening.DOTween::To(v58, v72, endValue, duration);\n\tv130 = DG.Tweening.TweenSettingsExtensions::SetTarget(v127, v51.target);\n\treturn v127;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static TweenerCore<float, float, FloatOptions> DOSetFloat(this AudioMixer target, string floatName, float endValue, float duration)
		{
			DOGetter<float> getter = delegate
			{
				//IL_0048: Expected F4, but got I
				object obj2 = default(object);
				object obj = obj2;
				_ = 0;
				bool flag = target.GetFloat(floatName, out *(float*)((long)(IntPtr)obj2 - 4L));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ X29_v1-4]");
				return 0f;
			};
			DOSetter<float> setter = delegate(float x)
			{
				bool flag = target.SetFloat(floatName, x);
			};
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
			TweenerCore<float, float, FloatOptions> tweenerCore2 = tweenerCore.SetTarget(target);
			return tweenerCore;
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x1575AF4", Offset = "0x1575AF4", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1F0F8F0]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, withCallbacks, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029141]) = v41;\nL_001B:\n\tgoto L_002A;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_002A;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, withCallbacks, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002A:\n\treturnVal1 = DG.Tweening.DOTween::Complete(target, withCallbacks);\n\treturn returnVal1;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOComplete(this AudioMixer target, bool withCallbacks = false)
		{
			return DOTween.Complete(target, withCallbacks);
		}

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x1575B6C", Offset = "0x1575B6C", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1F0A2B0]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, complete, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029142]) = v41;\nL_001B:\n\tgoto L_002A;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_002A;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, complete, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002A:\n\treturnVal1 = DG.Tweening.DOTween::Kill(target, complete);\n\treturn returnVal1;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOKill(this AudioMixer target, bool complete = false)
		{
			return DOTween.Kill(target, complete);
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0x1575BE4", Offset = "0x1575BE4", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EAB1F8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029143]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = DG.Tweening.DOTween::Flip(target);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOFlip(this AudioMixer target)
		{
			return DOTween.Flip(target);
		}

		[Token(Token = "0x6000007")]
		[Address(RVA = "0x1575C4C", Offset = "0x1575C4C", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EE4E08]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, andPlay, methodInfo, v30, v31, v32, v33, v34, to, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2029144]) = v44;\nL_001D:\n\tgoto L_002E;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002E;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, andPlay, methodInfo, v30, v31, v32, v33, v34, to, v35, v36, v37, v38, v39, v40, v41);\nL_002E:\n\treturnVal1 = DG.Tweening.DOTween::Goto(target, to, andPlay);\n\treturn returnVal1;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOGoto(this AudioMixer target, float to, bool andPlay = false)
		{
			return DOTween.Goto(target, to, andPlay);
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x1575CD4", Offset = "0x1575CD4", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC1658]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029145]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = DG.Tweening.DOTween::Pause(target);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOPause(this AudioMixer target)
		{
			return DOTween.Pause(target);
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x1575D3C", Offset = "0x1575D3C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F0F6B8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029146]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = DG.Tweening.DOTween::Play(target);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOPlay(this AudioMixer target)
		{
			return DOTween.Play(target);
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x1575DA4", Offset = "0x1575DA4", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ECEBA0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029147]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = DG.Tweening.DOTween::PlayBackwards(target);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOPlayBackwards(this AudioMixer target)
		{
			return DOTween.PlayBackwards(target);
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x1575E0C", Offset = "0x1575E0C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F108F0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029148]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = DG.Tweening.DOTween::PlayForward(target);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOPlayForward(this AudioMixer target)
		{
			return DOTween.PlayForward(target);
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x1575E74", Offset = "0x1575E74", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EDD930]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029149]) = v38;\nL_0019:\n\tgoto L_0028;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0028;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0028:\n\treturnVal1 = DG.Tweening.DOTween::Restart(target, 1, -1f);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DORestart(this AudioMixer target)
		{
			return DOTween.Restart(target);
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x1575EE4", Offset = "0x1575EE4", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF7310]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202914A]) = v38;\nL_0019:\n\tgoto L_0027;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0027;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0027:\n\treturnVal1 = DG.Tweening.DOTween::Rewind(target, 1);\n\treturn returnVal1;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DORewind(this AudioMixer target)
		{
			return DOTween.Rewind(target);
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x1575F50", Offset = "0x1575F50", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC9ED0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202914B]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = DG.Tweening.DOTween::SmoothRewind(target);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOSmoothRewind(this AudioMixer target)
		{
			return DOTween.SmoothRewind(target);
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x1575FB8", Offset = "0x1575FB8", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB4138]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202914C]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = DG.Tweening.DOTween::TogglePause(target);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DOTogglePause(this AudioMixer target)
		{
			return DOTween.TogglePause(target);
		}
	}
}
