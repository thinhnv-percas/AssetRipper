using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening
{
	[Token(Token = "0x2000005")]
	public static class DOTweenModuleSprite
	{
		[Token(Token = "0x6000020")]
		[Address(RVA = "0x157862C", Offset = "0x157862C", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv40 = *([1EB0418]);\n\tv41 = *([v40 @ X8_v22]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, methodInfo, v44, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2029160]) = v55;\nL_0024:\n\tv59 = new DG.Tweening.DOTweenModuleSprite+<>c__DisplayClass0_0();\n\tSystem.Object::.ctor(v59);\n\tv59.target = target;\n\tv66 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v66, v59, Il2CppMethodInfo);\n\tv80 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v80, v59, Il2CppMethodInfo);\n\tgoto L_005A;\n\tv141 = *([v137 @ X0_v10+E0]);\n\tv142 = v141 == 0;\n\tv143 = ~v142;\n\tif (v143) goto L_005A;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v137, v132, v134, v93, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\nL_005A:\n\tv150 = DG.Tweening.DOTween::To(v66, v80, endValue, duration);\n\tv153 = DG.Tweening.TweenSettingsExtensions::SetTarget(v150, v59.target);\n\treturn v150;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Color, Color, ColorOptions> DOColor(this SpriteRenderer target, Color endValue, float duration)
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

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x157879C", Offset = "0x157879C", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1ED6F78]);\n\tv29 = *([v28 @ X8_v22]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2029161]) = v46;\nL_001B:\n\tv50 = new DG.Tweening.DOTweenModuleSprite+<>c__DisplayClass1_0();\n\tSystem.Object::.ctor(v50);\n\tv50.target = target;\n\tv57 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v57, v50, Il2CppMethodInfo);\n\tv71 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v71, v50, Il2CppMethodInfo);\n\tgoto L_004D;\n\tv117 = *([v113 @ X0_v10+E0]);\n\tv118 = v117 == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_004D;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v113, v108, v110, v81, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\nL_004D:\n\tv126 = DG.Tweening.DOTween::ToAlpha(v57, v71, endValue, duration);\n\tv129 = DG.Tweening.TweenSettingsExtensions::SetTarget(v126, v50.target);\n\treturn v126;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Color, Color, ColorOptions> DOFade(this SpriteRenderer target, float endValue, float duration)
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

		[Token(Token = "0x6000022")]
		[Address(RVA = "0x15788E4", Offset = "0x15788E4", Length = "0x1E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv44 = *([1EF8540]);\n\tv45 = *([v44 @ X8_v19]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, gradient, methodInfo, v48, v49, v50, v51, v52, duration, v53, v54, v55, v56, v57, v58, v59);\n\tv62 = 0 | 1;\n\t*([2029162]) = v62;\nL_0026:\n\tgoto L_002D;\n\tv69 = *([v65 @ X0_v2+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tgoto L_002D;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v65, gradient, methodInfo, v48, v49, v50, v51, v52, duration, v53, v54, v55, v56, v57, v58, v59);\nL_002D:\n\tv77 = DG.Tweening.DOTween::Sequence();\n\tv82 = UnityEngine.Gradient::get_colorKeys(gradient);\n\tv205 = v82.Length < 1;\n\tif (v205) goto L_00BC;\n\tv206 = v82.Length == 0;\n\tif (v206) goto L_00B3;\n\tv117 = v82.Length - 1;\n\tv113 = v82 + 0x30;\nL_0050:\n\tv432 = *([v113 @ X25_v7]);\n\tv394 = v119 == 0;\n\tv395 = ~v394;\n\tif (v395) goto L_0074;\n\tv396 = *([v113 @ X25_v7]) < 0;\n\tv148 = ~v396;\n\tv139 = *([v113 @ X25_v7]) == 0;\n\tv397 = ~v139;\n\tv124 = v148 & v397;\n\tif (v124) goto L_0074;\n\t// 104 MakeStruct v426 @ AGG15789D8_1_v7 (UnityEngine.Color), typeof(UnityEngine.Color), [v113 @ X25_v7-10], [v113 @ X25_v7-C], [v113 @ X25_v7-8], [v113 @ X25_v7-4]\n\tUnityEngine.SpriteRenderer::set_color(target, v426);\n\tgoto L_009A;\nL_0074:\n\tv357 = v117 != v119;\n\tif (v357) goto L_007C;\n\tv419 = DG.Tweening.TweenExtensions::Duration(v77, 0);\n\tv444 = duration - v419;\n\tgoto L_0091;\nL_007C:\n\tv376 = v119 == 0;\n\tif (v376) goto L_008B;\n\tv353 = v119 - 1;\n\tv428 = v353 < v158;\n\tv373 = ~v428;\n\tif (v373) goto L_00B3;\n\tv432 = v432 - *([v113 @ X25_v7-14]);\nL_008B:\n\tv444 = v432 * duration;\nL_0091:\n\t// 145 MakeStruct v464 @ AGG1578A30_1_v7 (UnityEngine.Color), typeof(UnityEngine.Color), [v113 @ X25_v7-10], [v113 @ X25_v7-C], [v113 @ X25_v7-8], [v113 @ X25_v7-4]\n\tv465 = DG.Tweening.DOTweenModuleSprite::DOColor(target, v464, v444);\n\tv481 = DG.Tweening.TweenSettingsExtensions::SetEase(v465, 1);\n\tv477 = DG.Tweening.TweenSettingsExtensions::Append(v77, v481);\nL_009A:\n\tv119 = v119 + 1;\n\tv255 = v119 >= v82.Length;\n\tif (v255) goto L_00BC;\n\tv158 = v82.Length;\n\tv113 = v113 + 0x14;\n\tv482 = v119 < v82.Length;\n\tv372 = ~v482;\n\tv356 = ~v372;\n\tif (v356) goto L_0050;\nL_00B3:\n\tv378 = new System.IndexOutOfRangeException();\n\tthrow v378;\nL_00BC:\n\tv296 = DG.Tweening.TweenSettingsExtensions::SetTarget(v77, target);\n\treturn v77;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 145 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sequence DOGradientColor(this SpriteRenderer target, Gradient gradient, float duration)
		{
			//IL_0082: Expected O, but got I
			//IL_02be: Expected F4, but got I
			//IL_02d3: Expected F4, but got I
			//IL_02e8: Expected F4, but got I
			//IL_02fd: Expected F4, but got I
			//IL_00ff: Expected F4, but got I
			//IL_0114: Expected F4, but got I
			//IL_0129: Expected F4, but got I
			//IL_013e: Expected F4, but got I
			//IL_01ff: Expected O, but got I
			//IL_024c: Expected O, but got I
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
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X25_v7-10]");
								color.r = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X25_v7-C]");
								color.g = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X25_v7-8]");
								color.b = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X25_v7-4]");
								color.a = 0f;
								target.color = color;
								goto IL_0204;
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
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X25_v7-14]");
								obj2 = (long)intPtr - 0L;
							}
							duration2 = (float)obj2 * duration;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X25_v7-10]");
						endValue.r = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X25_v7-C]");
						endValue.g = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X25_v7-8]");
						endValue.b = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X25_v7-4]");
						endValue.a = 0f;
						TweenerCore<Color, Color, ColorOptions> t = target.DOColor(endValue, duration2);
						TweenerCore<Color, Color, ColorOptions> t2 = t.SetEase(Ease.Linear);
						Sequence sequence2 = sequence.Append(t2);
						goto IL_0204;
						IL_0204:
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
						goto IL_028e;
					}
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			goto IL_028e;
			IL_028e:
			Sequence sequence3 = sequence.SetTarget(target);
			return sequence;
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x1578AC4", Offset = "0x1578AC4", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv40 = *([1F0FE08]);\n\tv41 = *([v40 @ X8_v25]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, methodInfo, v44, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2029163]) = v55;\nL_0024:\n\tv59 = new DG.Tweening.DOTweenModuleSprite+<>c__DisplayClass3_0();\n\tSystem.Object::.ctor(v59);\n\tv59.target = target;\n\tv69 = UnityEngine.SpriteRenderer::get_color(target);\n\tv84 = UnityEngine.Color::op_Subtraction(endValue, v69);\n\tv106 = 0;\n\tv162 = 0x101059C(&v106 @ stack_-60_v1 (System.Single), 0, v44, v45, v46, v47, v48, v49, 0, 0, 0, 0, v69, v69.g, v69.b, v69.a);\n\tv59.to.r = 0f;\n\tv59.to.g = v165;\n\tv59.to.a = v166;\n\tv170 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v170, v59, Il2CppMethodInfo);\n\tv182 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v182, v59, Il2CppMethodInfo);\n\tgoto L_0084;\n\tv195 = *([v191 @ X0_v14+E0]);\n\tv196 = v195 == 0;\n\tv197 = ~v196;\n\tif (v197) goto L_0084;\n\tv199 = \"il2cpp_codegen_runtime_class_init\"(v191, v186, v188, v93, v46, v47, v48, v49, v157, v158, v159, v160, v73, v74, v75, v76);\nL_0084:\n\tv204 = DG.Tweening.DOTween::To(v170, v182, v84, duration);\n\tv208 = DG.Tweening.Core.Extensions::Blendable(v204);\n\treturnVal2 = DG.Tweening.TweenSettingsExtensions::SetTarget(v208, v59.target);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 125 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener DOBlendableColor(this SpriteRenderer target, Color endValue, float duration)
		{
			//IL_0072: Expected F4, but got O
			SpriteRenderer target2 = target;
			Color color = target.color;
			Color endValue2 = endValue - color;
			float num = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
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
	}
}
