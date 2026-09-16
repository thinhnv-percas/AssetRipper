using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening
{
	[Token(Token = "0x2000007")]
	public static class DOTweenModuleUnityVersion
	{
		[Token(Token = "0x600004C")]
		[Address(RVA = "0x157DFDC", Offset = "0x157DFDC", Length = "0x1E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv44 = *([1ED40B8]);\n\tv45 = *([v44 @ X8_v19]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, gradient, methodInfo, v48, v49, v50, v51, v52, duration, v53, v54, v55, v56, v57, v58, v59);\n\tv62 = 0 | 1;\n\t*([2029193]) = v62;\nL_0026:\n\tgoto L_002D;\n\tv69 = *([v65 @ X0_v2+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tgoto L_002D;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v65, gradient, methodInfo, v48, v49, v50, v51, v52, duration, v53, v54, v55, v56, v57, v58, v59);\nL_002D:\n\tv77 = DG.Tweening.DOTween::Sequence();\n\tv82 = UnityEngine.Gradient::get_colorKeys(gradient);\n\tv205 = v82.Length < 1;\n\tif (v205) goto L_00BD;\n\tv206 = v82.Length == 0;\n\tif (v206) goto L_00B4;\n\tv117 = v82.Length - 1;\n\tv113 = v82 + 0x30;\nL_0050:\n\tv432 = *([v113 @ X25_v7]);\n\tv394 = v119 == 0;\n\tv395 = ~v394;\n\tif (v395) goto L_0074;\n\tv396 = *([v113 @ X25_v7]) < 0;\n\tv148 = ~v396;\n\tv139 = *([v113 @ X25_v7]) == 0;\n\tv397 = ~v139;\n\tv124 = v148 & v397;\n\tif (v124) goto L_0074;\n\t// 104 MakeStruct v426 @ AGG157E0D0_1_v7 (UnityEngine.Color), typeof(UnityEngine.Color), [v113 @ X25_v7-10], [v113 @ X25_v7-C], [v113 @ X25_v7-8], [v113 @ X25_v7-4]\n\tUnityEngine.Material::set_color(target, v426);\n\tgoto L_009B;\nL_0074:\n\tv357 = v117 != v119;\n\tif (v357) goto L_007C;\n\tv419 = DG.Tweening.TweenExtensions::Duration(v77, 0);\n\tv444 = duration - v419;\n\tgoto L_0092;\nL_007C:\n\tv376 = v119 == 0;\n\tif (v376) goto L_008B;\n\tv353 = v119 - 1;\n\tv428 = v353 < v158;\n\tv373 = ~v428;\n\tif (v373) goto L_00B4;\n\tv432 = v432 - *([v113 @ X25_v7-14]);\nL_008B:\n\tv444 = v432 * duration;\nL_0092:\n\t// 146 MakeStruct v465 @ AGG157E12C_1_v7 (UnityEngine.Color), typeof(UnityEngine.Color), [v113 @ X25_v7-10], [v113 @ X25_v7-C], [v113 @ X25_v7-8], [v113 @ X25_v7-4]\n\tv466 = DG.Tweening.ShortcutExtensions::DOColor(target, v465, v444);\n\tv482 = DG.Tweening.TweenSettingsExtensions::SetEase(v466, 1);\n\tv478 = DG.Tweening.TweenSettingsExtensions::Append(v77, v482);\nL_009B:\n\tv119 = v119 + 1;\n\tv255 = v119 >= v82.Length;\n\tif (v255) goto L_00BD;\n\tv158 = v82.Length;\n\tv113 = v113 + 0x14;\n\tv483 = v119 < v82.Length;\n\tv372 = ~v483;\n\tv356 = ~v372;\n\tif (v356) goto L_0050;\nL_00B4:\n\tv378 = new System.IndexOutOfRangeException();\n\tthrow v378;\nL_00BD:\n\tv296 = DG.Tweening.TweenSettingsExtensions::SetTarget(v77, target);\n\treturn v77;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 146 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sequence DOGradientColor(this Material target, Gradient gradient, float duration)
		{
			//IL_0082: Expected O, but got I
			//IL_02bb: Expected F4, but got I
			//IL_02d0: Expected F4, but got I
			//IL_02e5: Expected F4, but got I
			//IL_02fa: Expected F4, but got I
			//IL_00fe: Expected F4, but got I
			//IL_0113: Expected F4, but got I
			//IL_0128: Expected F4, but got I
			//IL_013d: Expected F4, but got I
			//IL_01fc: Expected O, but got I
			//IL_0249: Expected O, but got I
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
								goto IL_0201;
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
						goto IL_0201;
						IL_0201:
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
						goto IL_028b;
					}
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			goto IL_028b;
			IL_028b:
			Sequence sequence3 = sequence.SetTarget(target);
			return sequence;
		}

		[Token(Token = "0x600004D")]
		[Address(RVA = "0x157E1C0", Offset = "0x157E1C0", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv48 = *([1EC44C0]);\n\tv49 = *([v48 @ X8_v19]);\n\tv50 = \"il2cpp_codegen_initialize_method\"(v49, gradient, property, methodInfo, v52, v53, v54, v55, duration, v56, v57, v58, v59, v60, v61, v62);\n\tv65 = 0 | 1;\n\t*([2029194]) = v65;\nL_0028:\n\tgoto L_002F;\n\tv72 = *([v68 @ X0_v2+E0]);\n\tv73 = v72 == 0;\n\tv74 = ~v73;\n\tgoto L_002F;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v68, gradient, property, methodInfo, v52, v53, v54, v55, duration, v56, v57, v58, v59, v60, v61, v62);\nL_002F:\n\tv80 = DG.Tweening.DOTween::Sequence();\n\tv85 = UnityEngine.Gradient::get_colorKeys(gradient);\n\tv208 = v85.Length < 1;\n\tif (v208) goto L_00C1;\n\tv209 = v85.Length == 0;\n\tif (v209) goto L_00B8;\n\tv120 = v85.Length - 1;\n\tv116 = v85 + 0x30;\nL_0052:\n\tv438 = *([v116 @ X26_v7]);\n\tv399 = v122 == 0;\n\tv400 = ~v399;\n\tif (v400) goto L_0077;\n\tv401 = *([v116 @ X26_v7]) < 0;\n\tv151 = ~v401;\n\tv142 = *([v116 @ X26_v7]) == 0;\n\tv402 = ~v142;\n\tv127 = v151 & v402;\n\tif (v127) goto L_0077;\n\t// 107 MakeStruct v432 @ AGG157E2C0_2_v7 (UnityEngine.Color), typeof(UnityEngine.Color), [v116 @ X26_v7-10], [v116 @ X26_v7-C], [v116 @ X26_v7-8], [v116 @ X26_v7-4]\n\tUnityEngine.Material::SetColor(target, property, v432);\n\tgoto L_009F;\nL_0077:\n\tv362 = v120 != v122;\n\tif (v362) goto L_007F;\n\tv424 = DG.Tweening.TweenExtensions::Duration(v80, 0);\n\tv450 = duration - v424;\n\tgoto L_0096;\nL_007F:\n\tv381 = v122 == 0;\n\tif (v381) goto L_008E;\n\tv358 = v122 - 1;\n\tv434 = v358 < v161;\n\tv378 = ~v434;\n\tif (v378) goto L_00B8;\n\tv438 = v438 - *([v116 @ X26_v7-14]);\nL_008E:\n\tv450 = v438 * duration;\nL_0096:\n\t// 150 MakeStruct v472 @ AGG157E320_1_v7 (UnityEngine.Color), typeof(UnityEngine.Color), [v116 @ X26_v7-10], [v116 @ X26_v7-C], [v116 @ X26_v7-8], [v116 @ X26_v7-4]\n\tv473 = DG.Tweening.ShortcutExtensions::DOColor(target, v472, property, v450);\n\tv489 = DG.Tweening.TweenSettingsExtensions::SetEase(v473, 1);\n\tv485 = DG.Tweening.TweenSettingsExtensions::Append(v80, v489);\nL_009F:\n\tv122 = v122 + 1;\n\tv258 = v122 >= v85.Length;\n\tif (v258) goto L_00C1;\n\tv161 = v85.Length;\n\tv116 = v116 + 0x14;\n\tv490 = v122 < v85.Length;\n\tv377 = ~v490;\n\tv361 = ~v377;\n\tif (v361) goto L_0052;\nL_00B8:\n\tv383 = new System.IndexOutOfRangeException();\n\tthrow v383;\nL_00C1:\n\tv299 = DG.Tweening.TweenSettingsExtensions::SetTarget(v80, target);\n\treturn v80;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 151 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sequence DOGradientColor(this Material target, Gradient gradient, string property, float duration)
		{
			//IL_0082: Expected O, but got I
			//IL_02bf: Expected F4, but got I
			//IL_02d4: Expected F4, but got I
			//IL_02e9: Expected F4, but got I
			//IL_02fe: Expected F4, but got I
			//IL_00fe: Expected F4, but got I
			//IL_0113: Expected F4, but got I
			//IL_0128: Expected F4, but got I
			//IL_013d: Expected F4, but got I
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
					Color value = default(Color);
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
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X26_v7-10]");
								value.r = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X26_v7-C]");
								value.g = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X26_v7-8]");
								value.b = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X26_v7-4]");
								value.a = 0f;
								target.SetColor(property, value);
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
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X26_v7-14]");
								obj2 = (long)intPtr - 0L;
							}
							duration2 = (float)obj2 * duration;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X26_v7-10]");
						endValue.r = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X26_v7-C]");
						endValue.g = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X26_v7-8]");
						endValue.b = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X26_v7-4]");
						endValue.a = 0f;
						TweenerCore<Color, Color, ColorOptions> t = target.DOColor(endValue, property, duration2);
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

		[Token(Token = "0x600004E")]
		[Address(RVA = "0x157E3B8", Offset = "0x157E3B8", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EA3330]);\n\tv19 = *([v18 @ X8_v19]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, returnCustomYieldInstruction, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029195]) = v38;\nL_0016:\n\tv41 = ~t.<active>k__BackingField;\n\tif (v41) goto L_0025;\n\tv47 = new DG.Tweening.DOTweenCYInstruction+WaitForCompletion();\n\tUnityEngine.CustomYieldInstruction::.ctor(v47);\n\tv47.t = t;\n\tgoto L_0047;\nL_0025:\n\tgoto L_003B;\n\tv55 = *([1ED7170]);\n\tv56 = *([v55 @ X8_v13]);\n\tv57 = \"il2cpp_codegen_initialize_method\"(v56, returnCustomYieldInstruction, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv60 = 0 | 1;\n\t*([2022B9B]) = v60;\nL_003B:\n\tv76 = v64._logPriority < 1;\n\tif (v76) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_0047:\n\treturn v126;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static CustomYieldInstruction WaitForCompletion(this Tween t, bool returnCustomYieldInstruction)
		{
			if (t.active)
			{
				DOTweenCYInstruction.WaitForCompletion waitForCompletion = (DOTweenCYInstruction.WaitForCompletion)new CustomYieldInstruction();
				waitForCompletion.t = t;
				return waitForCompletion;
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogInvalidTween(t);
			}
			return null;
		}

		[Token(Token = "0x600004F")]
		[Address(RVA = "0x157E484", Offset = "0x157E484", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1ED41C0]);\n\tv19 = *([v18 @ X8_v19]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, returnCustomYieldInstruction, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029196]) = v38;\nL_0016:\n\tv41 = ~t.<active>k__BackingField;\n\tif (v41) goto L_0025;\n\tv47 = new DG.Tweening.DOTweenCYInstruction+WaitForRewind();\n\tUnityEngine.CustomYieldInstruction::.ctor(v47);\n\tv47.t = t;\n\tgoto L_0047;\nL_0025:\n\tgoto L_003B;\n\tv55 = *([1ED7170]);\n\tv56 = *([v55 @ X8_v13]);\n\tv57 = \"il2cpp_codegen_initialize_method\"(v56, returnCustomYieldInstruction, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv60 = 0 | 1;\n\t*([2022B9B]) = v60;\nL_003B:\n\tv76 = v64._logPriority < 1;\n\tif (v76) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_0047:\n\treturn v126;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static CustomYieldInstruction WaitForRewind(this Tween t, bool returnCustomYieldInstruction)
		{
			if (t.active)
			{
				DOTweenCYInstruction.WaitForRewind waitForRewind = (DOTweenCYInstruction.WaitForRewind)new CustomYieldInstruction();
				waitForRewind.t = t;
				return waitForRewind;
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogInvalidTween(t);
			}
			return null;
		}

		[Token(Token = "0x6000050")]
		[Address(RVA = "0x157E550", Offset = "0x157E550", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EB6640]);\n\tv19 = *([v18 @ X8_v19]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, returnCustomYieldInstruction, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029197]) = v38;\nL_0016:\n\tv41 = ~t.<active>k__BackingField;\n\tif (v41) goto L_0025;\n\tv47 = new DG.Tweening.DOTweenCYInstruction+WaitForKill();\n\tUnityEngine.CustomYieldInstruction::.ctor(v47);\n\tv47.t = t;\n\tgoto L_0047;\nL_0025:\n\tgoto L_003B;\n\tv55 = *([1ED7170]);\n\tv56 = *([v55 @ X8_v13]);\n\tv57 = \"il2cpp_codegen_initialize_method\"(v56, returnCustomYieldInstruction, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv60 = 0 | 1;\n\t*([2022B9B]) = v60;\nL_003B:\n\tv76 = v64._logPriority < 1;\n\tif (v76) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_0047:\n\treturn v126;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static CustomYieldInstruction WaitForKill(this Tween t, bool returnCustomYieldInstruction)
		{
			if (t.active)
			{
				DOTweenCYInstruction.WaitForKill waitForKill = (DOTweenCYInstruction.WaitForKill)new CustomYieldInstruction();
				waitForKill.t = t;
				return waitForKill;
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogInvalidTween(t);
			}
			return null;
		}

		[Token(Token = "0x6000051")]
		[Address(RVA = "0x157E61C", Offset = "0x157E61C", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1F088C0]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, elapsedLoops, returnCustomYieldInstruction, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029198]) = v41;\nL_0018:\n\tv44 = ~t.<active>k__BackingField;\n\tif (v44) goto L_0028;\n\tv50 = new DG.Tweening.DOTweenCYInstruction+WaitForElapsedLoops();\n\tUnityEngine.CustomYieldInstruction::.ctor(v50);\n\tv50.t = t;\n\tv50.elapsedLoops = elapsedLoops;\n\tgoto L_004B;\nL_0028:\n\tgoto L_003E;\n\tv58 = *([1ED7170]);\n\tv59 = *([v58 @ X8_v13]);\n\tv60 = \"il2cpp_codegen_initialize_method\"(v59, elapsedLoops, returnCustomYieldInstruction, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv63 = 0 | 1;\n\t*([2022B9B]) = v63;\nL_003E:\n\tv79 = v67._logPriority < 1;\n\tif (v79) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_004B:\n\treturn v132;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static CustomYieldInstruction WaitForElapsedLoops(this Tween t, int elapsedLoops, bool returnCustomYieldInstruction)
		{
			if (t.active)
			{
				DOTweenCYInstruction.WaitForElapsedLoops waitForElapsedLoops = (DOTweenCYInstruction.WaitForElapsedLoops)new CustomYieldInstruction();
				waitForElapsedLoops.t = t;
				waitForElapsedLoops.elapsedLoops = elapsedLoops;
				return waitForElapsedLoops;
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogInvalidTween(t);
			}
			return null;
		}

		[Token(Token = "0x6000052")]
		[Address(RVA = "0x157E6F8", Offset = "0x157E6F8", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EF1708]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, returnCustomYieldInstruction, methodInfo, v27, v28, v29, v30, v31, position, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029199]) = v41;\nL_0018:\n\tv44 = ~t.<active>k__BackingField;\n\tif (v44) goto L_0028;\n\tv50 = new DG.Tweening.DOTweenCYInstruction+WaitForPosition();\n\tUnityEngine.CustomYieldInstruction::.ctor(v50);\n\tv50.t = t;\n\tv50.position = position;\n\tgoto L_004B;\nL_0028:\n\tgoto L_003E;\n\tv58 = *([1ED7170]);\n\tv59 = *([v58 @ X8_v13]);\n\tv60 = \"il2cpp_codegen_initialize_method\"(v59, returnCustomYieldInstruction, methodInfo, v27, v28, v29, v30, v31, position, v32, v33, v34, v35, v36, v37, v38);\n\tv63 = 0 | 1;\n\t*([2022B9B]) = v63;\nL_003E:\n\tv79 = v67._logPriority < 1;\n\tif (v79) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_004B:\n\treturn v131;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static CustomYieldInstruction WaitForPosition(this Tween t, float position, bool returnCustomYieldInstruction)
		{
			if (t.active)
			{
				DOTweenCYInstruction.WaitForPosition waitForPosition = (DOTweenCYInstruction.WaitForPosition)new CustomYieldInstruction();
				waitForPosition.t = t;
				waitForPosition.position = position;
				return waitForPosition;
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogInvalidTween(t);
			}
			return null;
		}

		[Token(Token = "0x6000053")]
		[Address(RVA = "0x157E7D4", Offset = "0x157E7D4", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EE18D0]);\n\tv19 = *([v18 @ X8_v19]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, returnCustomYieldInstruction, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202919A]) = v38;\nL_0016:\n\tv41 = ~t.<active>k__BackingField;\n\tif (v41) goto L_0025;\n\tv47 = new DG.Tweening.DOTweenCYInstruction+WaitForStart();\n\tUnityEngine.CustomYieldInstruction::.ctor(v47);\n\tv47.t = t;\n\tgoto L_0047;\nL_0025:\n\tgoto L_003B;\n\tv55 = *([1ED7170]);\n\tv56 = *([v55 @ X8_v13]);\n\tv57 = \"il2cpp_codegen_initialize_method\"(v56, returnCustomYieldInstruction, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv60 = 0 | 1;\n\t*([2022B9B]) = v60;\nL_003B:\n\tv76 = v64._logPriority < 1;\n\tif (v76) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_0047:\n\treturn v126;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static CustomYieldInstruction WaitForStart(this Tween t, bool returnCustomYieldInstruction)
		{
			if (t.active)
			{
				DOTweenCYInstruction.WaitForStart waitForStart = (DOTweenCYInstruction.WaitForStart)new CustomYieldInstruction();
				waitForStart.t = t;
				return waitForStart;
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogInvalidTween(t);
			}
			return null;
		}

		[Token(Token = "0x6000054")]
		[Address(RVA = "0x157E8A0", Offset = "0x157E8A0", Length = "0x1C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv34 = *([1EB8D88]);\n\tv35 = *([v34 @ X8_v33]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, propertyID, methodInfo, v38, v39, v40, v41, v42, endValue, v0, duration, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202919B]) = v50;\nL_001F:\n\tv54 = new DG.Tweening.DOTweenModuleUnityVersion+<>c__DisplayClass8_0();\n\tSystem.Object::.ctor(v54);\n\tv54.target = target;\n\tv54.propertyID = propertyID;\n\tv65 = UnityEngine.Material::HasProperty(target, propertyID);\n\tv67 = v65 == 0;\n\tif (v67) goto L_0069;\n\tv138 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v138, v54, Il2CppMethodInfo);\n\tv177 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v177, v54, Il2CppMethodInfo);\n\tgoto L_005D;\n\tv211 = *([v207 @ X0_v19+E0]);\n\tv212 = v211 == 0;\n\tv213 = ~v212;\n\tif (v213) goto L_005D;\n\tv215 = \"il2cpp_codegen_runtime_class_init\"(v207, v187, v189, v190, v39, v40, v41, v42, endValue, v0, duration, v43, v44, v45, v46, v47);\nL_005D:\n\tv220 = DG.Tweening.DOTween::To(v138, v177, endValue, duration);\n\tv197 = DG.Tweening.TweenSettingsExtensions::SetTarget(v220, v54.target);\n\tgoto L_008F;\nL_0069:\n\tgoto L_007F;\n\tv152 = *([1ED7170]);\n\tv153 = *([v152 @ X8_v14]);\n\tv154 = \"il2cpp_codegen_initialize_method\"(v153, v63, v64, v38, v39, v40, v41, v42, endValue, v0, duration, v43, v44, v45, v46, v47);\n\tv157 = 0 | 1;\n\t*([2022B9B]) = v157;\nL_007F:\n\tv173 = v161._logPriority < 1;\n\tif (v173) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogMissingMaterialProperty(v54.propertyID);\nL_008F:\n\treturn v202;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 109 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector2, Vector2, VectorOptions> DOOffset(this Material target, Vector2 endValue, int propertyID, float duration)
		{
			Material target2 = target;
			int propertyID2 = propertyID;
			if (target.HasProperty(propertyID))
			{
				DOGetter<Vector2> getter = () => target2.GetTextureOffset(propertyID2);
				DOSetter<Vector2> setter = delegate(Vector2 x)
				{
					target2.SetTextureOffset(propertyID2, x);
				};
				TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
				TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore2 = tweenerCore.SetTarget(target2);
				return tweenerCore;
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogMissingMaterialProperty(propertyID2);
			}
			return null;
		}

		[Token(Token = "0x6000055")]
		[Address(RVA = "0x157EA6C", Offset = "0x157EA6C", Length = "0x1C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv34 = *([1EEEB50]);\n\tv35 = *([v34 @ X8_v33]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, propertyID, methodInfo, v38, v39, v40, v41, v42, endValue, v0, duration, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202919C]) = v50;\nL_001F:\n\tv54 = new DG.Tweening.DOTweenModuleUnityVersion+<>c__DisplayClass9_0();\n\tSystem.Object::.ctor(v54);\n\tv54.target = target;\n\tv54.propertyID = propertyID;\n\tv65 = UnityEngine.Material::HasProperty(target, propertyID);\n\tv67 = v65 == 0;\n\tif (v67) goto L_0069;\n\tv138 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v138, v54, Il2CppMethodInfo);\n\tv177 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v177, v54, Il2CppMethodInfo);\n\tgoto L_005D;\n\tv211 = *([v207 @ X0_v19+E0]);\n\tv212 = v211 == 0;\n\tv213 = ~v212;\n\tif (v213) goto L_005D;\n\tv215 = \"il2cpp_codegen_runtime_class_init\"(v207, v187, v189, v190, v39, v40, v41, v42, endValue, v0, duration, v43, v44, v45, v46, v47);\nL_005D:\n\tv220 = DG.Tweening.DOTween::To(v138, v177, endValue, duration);\n\tv197 = DG.Tweening.TweenSettingsExtensions::SetTarget(v220, v54.target);\n\tgoto L_008F;\nL_0069:\n\tgoto L_007F;\n\tv152 = *([1ED7170]);\n\tv153 = *([v152 @ X8_v14]);\n\tv154 = \"il2cpp_codegen_initialize_method\"(v153, v63, v64, v38, v39, v40, v41, v42, endValue, v0, duration, v43, v44, v45, v46, v47);\n\tv157 = 0 | 1;\n\t*([2022B9B]) = v157;\nL_007F:\n\tv173 = v161._logPriority < 1;\n\tif (v173) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogMissingMaterialProperty(v54.propertyID);\nL_008F:\n\treturn v202;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 109 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector2, Vector2, VectorOptions> DOTiling(this Material target, Vector2 endValue, int propertyID, float duration)
		{
			Material target2 = target;
			int propertyID2 = propertyID;
			if (target.HasProperty(propertyID))
			{
				DOGetter<Vector2> getter = () => target2.GetTextureScale(propertyID2);
				DOSetter<Vector2> setter = delegate(Vector2 x)
				{
					target2.SetTextureScale(propertyID2, x);
				};
				TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue, duration);
				TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore2 = tweenerCore.SetTarget(target2);
				return tweenerCore;
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogMissingMaterialProperty(propertyID2);
			}
			return null;
		}
	}
}
