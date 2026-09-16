using System;
using System.Collections;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening
{
	[Token(Token = "0x2000012")]
	public static class TweenExtensions
	{
		[Token(Token = "0x6000069")]
		[Address(RVA = "0x1602AE0", Offset = "0x1602AE0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tDG.Tweening.TweenExtensions::Complete(t, 0);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Complete(this Tween t)
		{
			t.Complete(withCallbacks: false);
		}

		[Token(Token = "0x600006A")]
		[Address(RVA = "0x1602AE8", Offset = "0x1602AE8", Length = "0x1DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EDA188]);\n\tv23 = *([v22 @ X8_v43]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, withCallbacks, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A1B9]) = v41;\nL_0015:\n\tv42 = t == 0;\n\tif (v42) goto L_0047;\n\tv44 = ~t.<active>k__BackingField;\n\tif (v44) goto L_006D;\n\tv50 = ~t.isSequenced;\n\tif (v50) goto L_0098;\n\tgoto L_0037;\n\tv149 = *([1EC8838]);\n\tv150 = *([v149 @ X8_v39]);\n\tv151 = \"il2cpp_codegen_initialize_method\"(v150, withCallbacks, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv153 = 0 | 1;\n\t*([2022B9B]) = v153;\nL_0037:\n\tv119 = v157._logPriority < 2;\n\tif (v119) goto L_0095;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\treturn;\nL_0047:\n\tgoto L_005D;\n\tv56 = *([1EC8838]);\n\tv57 = *([v56 @ X8_v12]);\n\tv58 = \"il2cpp_codegen_initialize_method\"(v57, withCallbacks, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv61 = 0 | 1;\n\t*([2022B9B]) = v61;\nL_005D:\n\tv77 = v65._logPriority < 2;\n\tif (v77) goto L_0095;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\treturn;\nL_006D:\n\tgoto L_0083;\n\tv89 = *([1EC8838]);\n\tv90 = *([v89 @ X8_v23]);\n\tv91 = \"il2cpp_codegen_initialize_method\"(v90, withCallbacks, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv94 = 0 | 1;\n\t*([2022B9B]) = v94;\nL_0083:\n\tv110 = v98._logPriority < 2;\n\tif (v110) goto L_0095;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\treturn;\nL_0095:\n\treturn;\nL_0098:\n\tv84 = DG.Tweening.Core.TweenManager;\n\tgoto L_00A5;\n\tv160 = *([v84 @ X0_v11 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv161 = v160 == 0;\n\tv162 = ~v161;\n\tif (v162) goto L_00A5;\n\tv237 = \"il2cpp_codegen_runtime_class_init\"(v84, withCallbacks, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv166 = DG.Tweening.Core.TweenManager;\n\tv169 = *([v166 @ X0_v18+12E]);\nL_00A5:\n\tv171 = ~withCallbacks;\n\tv179 = v170.isUpdateLoop == 0;\n\tv185 = ~v179;\n\tv186 = ~v185;\n\tif (v186) goto L_FFFFFFFF;\n\tgoto L_00BA;\nL_00BA:\n\tv241 = *([v84 @ X0_v11 (Il2CppClass<DG.Tweening.Core.TweenManager>)+12E]) & 0x200;\n\tv242 = v241 == 0;\n\tif (v242) goto L_00CC;\n\tgoto L_00CC;\n\tv247 = \"il2cpp_codegen_runtime_class_init\"(v165, withCallbacks, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00CC:\n\tv220 = DG.Tweening.Core.TweenManager::Complete(t, 1, v240);\n\treturn;\n// 141 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Complete(this Tween t, bool withCallbacks)
		{
			//IL_007a: Expected I, but got O
			if (t != null)
			{
				if (t.active)
				{
					if (!t.isSequenced)
					{
						IntPtr intPtr = (IntPtr)typeof(TweenManager);
						bool flag = !withCallbacks;
						int updateMode = ((!TweenManager.isUpdateLoop) ? (flag ? 1 : 0) : 3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ X0_v11 (Il2CppClass<DG.Tweening.Core.TweenManager>)+12E]");
						if (0u != 0)
						{
						}
						bool flag2 = TweenManager.Complete(t, modifyActiveLists: true, (UpdateMode)updateMode);
					}
					else if (Debugger._logPriority >= 2)
					{
						Debugger.LogNestedTween(t);
					}
				}
				else if (Debugger._logPriority >= 2)
				{
					Debugger.LogInvalidTween(t);
				}
			}
			else if (Debugger._logPriority >= 2)
			{
				Debugger.LogNullTween(null);
			}
		}

		[Token(Token = "0x600006B")]
		[Address(RVA = "0x1602CC4", Offset = "0x1602CC4", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EAF4B0]);\n\tv19 = *([v18 @ X8_v43]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A1BA]) = v38;\nL_0013:\n\tv39 = t == 0;\n\tif (v39) goto L_0044;\n\tv41 = ~t.<active>k__BackingField;\n\tif (v41) goto L_0069;\n\tv47 = ~t.isSequenced;\n\tif (v47) goto L_0096;\n\tgoto L_0035;\n\tv144 = *([1EC8838]);\n\tv145 = *([v144 @ X8_v39]);\n\tv146 = \"il2cpp_codegen_initialize_method\"(v145, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv148 = 0 | 1;\n\t*([2022B9B]) = v148;\nL_0035:\n\tv115 = v152._logPriority < 2;\n\tif (v115) goto L_008F;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\treturn;\nL_0044:\n\tgoto L_005A;\n\tv53 = *([1EC8838]);\n\tv54 = *([v53 @ X8_v12]);\n\tv55 = \"il2cpp_codegen_initialize_method\"(v54, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv58 = 0 | 1;\n\t*([2022B9B]) = v58;\nL_005A:\n\tv74 = v62._logPriority < 2;\n\tif (v74) goto L_008F;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\treturn;\nL_0069:\n\tgoto L_007F;\n\tv86 = *([1EC8838]);\n\tv87 = *([v86 @ X8_v23]);\n\tv88 = \"il2cpp_codegen_initialize_method\"(v87, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv91 = 0 | 1;\n\t*([2022B9B]) = v91;\nL_007F:\n\tv107 = v95._logPriority < 2;\n\tif (v107) goto L_008F;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\treturn;\nL_008F:\n\treturn;\nL_0096:\n\tgoto L_00A3;\n\tv155 = *([v81 @ X0_v11+E0]);\n\tv156 = v155 == 0;\n\tv157 = ~v156;\n\tif (v157) goto L_00A3;\n\tv159 = \"il2cpp_codegen_runtime_class_init\"(v81, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_00A3:\n\tv168 = DG.Tweening.Core.TweenManager::Flip(t);\n\treturn;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Flip(this Tween t)
		{
			if (t != null)
			{
				if (t.active)
				{
					if (!t.isSequenced)
					{
						bool flag = TweenManager.Flip(t);
					}
					else if (Debugger._logPriority >= 2)
					{
						Debugger.LogNestedTween(t);
					}
				}
				else if (Debugger._logPriority >= 2)
				{
					Debugger.LogInvalidTween(t);
				}
			}
			else if (Debugger._logPriority >= 2)
			{
				Debugger.LogNullTween(null);
			}
		}

		[Token(Token = "0x600006C")]
		[Address(RVA = "0x1602E48", Offset = "0x1602E48", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1ED5300]);\n\tv19 = *([v18 @ X8_v43]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A1BB]) = v38;\nL_0013:\n\tv39 = t == 0;\n\tif (v39) goto L_0044;\n\tv41 = ~t.<active>k__BackingField;\n\tif (v41) goto L_0069;\n\tv47 = ~t.isSequenced;\n\tif (v47) goto L_0096;\n\tgoto L_0035;\n\tv144 = *([1EC8838]);\n\tv145 = *([v144 @ X8_v39]);\n\tv146 = \"il2cpp_codegen_initialize_method\"(v145, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv148 = 0 | 1;\n\t*([2022B9B]) = v148;\nL_0035:\n\tv115 = v152._logPriority < 2;\n\tif (v115) goto L_008F;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\treturn;\nL_0044:\n\tgoto L_005A;\n\tv53 = *([1EC8838]);\n\tv54 = *([v53 @ X8_v12]);\n\tv55 = \"il2cpp_codegen_initialize_method\"(v54, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv58 = 0 | 1;\n\t*([2022B9B]) = v58;\nL_005A:\n\tv74 = v62._logPriority < 2;\n\tif (v74) goto L_008F;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\treturn;\nL_0069:\n\tgoto L_007F;\n\tv86 = *([1EC8838]);\n\tv87 = *([v86 @ X8_v23]);\n\tv88 = \"il2cpp_codegen_initialize_method\"(v87, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv91 = 0 | 1;\n\t*([2022B9B]) = v91;\nL_007F:\n\tv107 = v95._logPriority < 2;\n\tif (v107) goto L_008F;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\treturn;\nL_008F:\n\treturn;\nL_0096:\n\tgoto L_00A4;\n\tv155 = *([v81 @ X0_v11+E0]);\n\tv156 = v155 == 0;\n\tv157 = ~v156;\n\tif (v157) goto L_00A4;\n\tv159 = \"il2cpp_codegen_runtime_class_init\"(v81, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_00A4:\n\tDG.Tweening.Core.TweenManager::ForceInit(t, 0);\n\treturn;\n// 115 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ForceInit(this Tween t)
		{
			if (t != null)
			{
				if (t.active)
				{
					if (!t.isSequenced)
					{
						TweenManager.ForceInit(t);
					}
					else if (Debugger._logPriority >= 2)
					{
						Debugger.LogNestedTween(t);
					}
				}
				else if (Debugger._logPriority >= 2)
				{
					Debugger.LogInvalidTween(t);
				}
			}
			else if (Debugger._logPriority >= 2)
			{
				Debugger.LogNullTween(null);
			}
		}

		[Token(Token = "0x600006D")]
		[Address(RVA = "0x160209C", Offset = "0x160209C", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EE5908]);\n\tv27 = *([v26 @ X8_v43]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, andPlay, methodInfo, v30, v31, v32, v33, v34, to, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202A1BC]) = v44;\nL_0017:\n\tv45 = t == 0;\n\tif (v45) goto L_004A;\n\tv47 = ~t.<active>k__BackingField;\n\tif (v47) goto L_0071;\n\tv53 = ~t.isSequenced;\n\tif (v53) goto L_009F;\n\tgoto L_0039;\n\tv152 = *([1EC8838]);\n\tv153 = *([v152 @ X8_v39]);\n\tv154 = \"il2cpp_codegen_initialize_method\"(v153, andPlay, methodInfo, v30, v31, v32, v33, v34, to, v35, v36, v37, v38, v39, v40, v41);\n\tv156 = 0 | 1;\n\t*([2022B9B]) = v156;\nL_0039:\n\tv121 = v160._logPriority < 2;\n\tif (v121) goto L_009B;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\treturn;\nL_004A:\n\tgoto L_0060;\n\tv59 = *([1EC8838]);\n\tv60 = *([v59 @ X8_v12]);\n\tv61 = \"il2cpp_codegen_initialize_method\"(v60, andPlay, methodInfo, v30, v31, v32, v33, v34, to, v35, v36, v37, v38, v39, v40, v41);\n\tv64 = 0 | 1;\n\t*([2022B9B]) = v64;\nL_0060:\n\tv80 = v68._logPriority < 2;\n\tif (v80) goto L_009B;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\treturn;\nL_0071:\n\tgoto L_0087;\n\tv90 = *([1EC8838]);\n\tv91 = *([v90 @ X8_v23]);\n\tv92 = \"il2cpp_codegen_initialize_method\"(v91, andPlay, methodInfo, v30, v31, v32, v33, v34, to, v35, v36, v37, v38, v39, v40, v41);\n\tv95 = 0 | 1;\n\t*([2022B9B]) = v95;\nL_0087:\n\tv111 = v99._logPriority < 2;\n\tif (v111) goto L_009B;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\treturn;\nL_009B:\n\treturn;\nL_009F:\n\tv88 = UnityEngine.Mathf::Max(to, 0f);\n\tgoto L_00B6;\n\tv227 = *([v163 @ X0_v11+E0]);\n\tv228 = v227 == 0;\n\tv229 = ~v228;\n\tif (v229) goto L_00B6;\n\tv231 = \"il2cpp_codegen_runtime_class_init\"(v163, andPlay, methodInfo, v30, v31, v32, v33, v34, v87, v35, v36, v37, v38, v39, v40, v41);\nL_00B6:\n\tv207 = DG.Tweening.Core.TweenManager::Goto(t, v88, andPlay, 1);\n\treturn;\n// 132 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Goto(this Tween t, float to, bool andPlay = false)
		{
			if (t != null)
			{
				if (t.active)
				{
					if (!t.isSequenced)
					{
						float to2 = Mathf.Max(to, 0f);
						bool flag = TweenManager.Goto(t, to2, andPlay);
					}
					else if (Debugger._logPriority >= 2)
					{
						Debugger.LogNestedTween(t);
					}
				}
				else if (Debugger._logPriority >= 2)
				{
					Debugger.LogInvalidTween(t);
				}
			}
			else if (Debugger._logPriority >= 2)
			{
				Debugger.LogNullTween(null);
			}
		}

		[Token(Token = "0x600006E")]
		[Address(RVA = "0x1602FD0", Offset = "0x1602FD0", Length = "0x244")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EE31A8]);\n\tv23 = *([v22 @ X8_v59]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, complete, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A1BD]) = v41;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v44, complete, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv52 = DG.Tweening.DOTween;\nL_0024:\n\tv57 = ~v55.initialized;\n\tif (v57) goto L_00D3;\n\tv59 = t == 0;\n\tif (v59) goto L_0058;\n\tv144 = ~t.<active>k__BackingField;\n\tif (v144) goto L_007E;\n\tv199 = ~t.isSequenced;\n\tif (v199) goto L_00A1;\n\tgoto L_0048;\n\tv231 = *([1EC8838]);\n\tv232 = *([v231 @ X8_v54]);\n\tv233 = \"il2cpp_codegen_initialize_method\"(v232, complete, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv235 = 0 | 1;\n\t*([2022B9B]) = v235;\nL_0048:\n\tv62 = v239._logPriority < 2;\n\tif (v62) goto L_00D3;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\treturn;\nL_0058:\n\tgoto L_006E;\n\tv203 = *([1EC8838]);\n\tv204 = *([v203 @ X8_v16]);\n\tv205 = \"il2cpp_codegen_initialize_method\"(v204, complete, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv207 = 0 | 1;\n\t*([2022B9B]) = v207;\nL_006E:\n\tv63 = v211._logPriority < 2;\n\tif (v63) goto L_00D3;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\treturn;\nL_007E:\n\tgoto L_0094;\n\tv219 = *([1EC8838]);\n\tv220 = *([v219 @ X8_v27]);\n\tv221 = \"il2cpp_codegen_initialize_method\"(v220, complete, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv223 = 0 | 1;\n\t*([2022B9B]) = v223;\nL_0094:\n\tv64 = v227._logPriority < 2;\n\tif (v64) goto L_00D3;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\treturn;\nL_00A1:\n\tv217 = complete == 0;\n\tif (v217) goto L_00C1;\n\tgoto L_00B3;\n\tv258 = *([v244 @ X0_v21+E0]);\n\tv259 = v258 == 0;\n\tv260 = ~v259;\n\tif (v260) goto L_00B3;\n\tv262 = \"il2cpp_codegen_runtime_class_init\"(v244, complete, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00B3:\n\tv116 = DG.Tweening.Core.TweenManager::Complete(t, 1, 1);\n\tv250 = *([202209C]) == 0;\n\tif (v250) goto L_00C1;\n\tv277 = *([20220A4]) & 0x80000000;\n\tv122 = v277 == 0;\n\tif (v122) goto L_00D3;\nL_00C1:\n\tgoto L_00CA;\n\tv266 = *([v254 @ X0_v14 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv267 = v266 == 0;\n\tv268 = ~v267;\n\tif (v268) goto L_00CA;\n\tv273 = \"il2cpp_codegen_runtime_class_init\"(v254, v112, v109, v106, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv269 = DG.Tweening.Core.TweenManager;\nL_00CA:\n\tv121 = ~v272.isUpdateLoop;\n\tif (v121) goto L_00D7;\n\t*([20220E0]) = 0;\nL_00D3:\n\treturn;\nL_00D7:\n\tgoto L_00E6;\n\tv278 = *([v115 @ X0_v15 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv279 = v278 == 0;\n\tv280 = ~v279;\n\tif (v280) goto L_00E6;\n\tv282 = \"il2cpp_codegen_runtime_class_init\"(v115, v112, v109, v106, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00E6:\n\tDG.Tweening.Core.TweenManager::Despawn(t, 1);\n\treturn;\n// 148 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Kill(this Tween t, bool complete = false)
		{
			//IL_0100: Expected I4, but got I8
			if (!DOTween.initialized)
			{
				return;
			}
			if (t != null)
			{
				if (t.active)
				{
					if (!t.isSequenced)
					{
						if (complete)
						{
							bool flag = TweenManager.Complete(t);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [202209C]");
							if ((IntPtr)0 != (IntPtr)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [20220A4]");
								if (0 == 0)
								{
									return;
								}
							}
						}
						if (TweenManager.isUpdateLoop)
						{
							_ = 0;
						}
						else
						{
							TweenManager.Despawn(t);
						}
					}
					else if (Debugger._logPriority >= 2)
					{
						Debugger.LogNestedTween(t);
					}
				}
				else if (Debugger._logPriority >= 2)
				{
					Debugger.LogInvalidTween(t);
				}
			}
			else if (Debugger._logPriority >= 2)
			{
				Debugger.LogNullTween(null);
			}
		}

		[Token(Token = "0x600006F")]
		[Address(RVA = "0xB86AE8", Offset = "0xB86AE8", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EE5548]);\n\tv19 = *([v18 @ X8_v42]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20229EE]) = v38;\nL_0013:\n\tv39 = t == 0;\n\tif (v39) goto L_003F;\n\tv41 = *([t @ X0 (T)+E0]) == 0;\n\tif (v41) goto L_005F;\n\tv47 = *([t @ X0 (T)+E1]) == 0;\n\tif (v47) goto L_0081;\n\tgoto L_0035;\n\tv158 = *([1ED7020]);\n\tv159 = *([v158 @ X8_v39]);\n\tv160 = \"il2cpp_codegen_initialize_method\"(v159, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv162 = 0 | 1;\n\t*([2022B9B]) = v162;\nL_0035:\n\tv112 = v166._logPriority < 2;\n\tif (v112) goto L_0090;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\tgoto L_0090;\nL_003F:\n\tgoto L_0055;\n\tv53 = *([1ED7020]);\n\tv54 = *([v53 @ X8_v12]);\n\tv55 = \"il2cpp_codegen_initialize_method\"(v54, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv58 = 0 | 1;\n\t*([2022B9B]) = v58;\nL_0055:\n\tv74 = v62._logPriority < 2;\n\tif (v74) goto L_0090;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\tgoto L_0090;\nL_005F:\n\tgoto L_0075;\n\tv86 = *([1ED7020]);\n\tv87 = *([v86 @ X8_v23]);\n\tv88 = \"il2cpp_codegen_initialize_method\"(v87, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv91 = 0 | 1;\n\t*([2022B9B]) = v91;\nL_0075:\n\tv107 = v95._logPriority < 2;\n\tif (v107) goto L_0090;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\tgoto L_0090;\nL_0081:\n\tgoto L_0089;\n\tv169 = *([v81 @ X0_v12+E0]);\n\tv170 = v169 == 0;\n\tv171 = ~v170;\n\tif (v171) goto L_0089;\n\tv173 = \"il2cpp_codegen_runtime_class_init\"(v81, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0089:\n\tv142 = DG.Tweening.Core.TweenManager::Pause(t);\nL_0090:\n\treturn t;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T Pause<T>(this T t) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E1]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						bool flag = TweenManager.Pause(t);
					}
					else if (Debugger._logPriority >= 2)
					{
						Debugger.LogNestedTween(t);
					}
				}
				else if (Debugger._logPriority >= 2)
				{
					Debugger.LogInvalidTween(t);
				}
			}
			else if (Debugger._logPriority >= 2)
			{
				Debugger.LogNullTween(null);
			}
			return t;
		}

		[Token(Token = "0x6000070")]
		[Address(RVA = "0xB86C5C", Offset = "0xB86C5C", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EBEF80]);\n\tv19 = *([v18 @ X8_v42]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20229EF]) = v38;\nL_0013:\n\tv39 = t == 0;\n\tif (v39) goto L_003F;\n\tv41 = *([t @ X0 (T)+E0]) == 0;\n\tif (v41) goto L_005F;\n\tv47 = *([t @ X0 (T)+E1]) == 0;\n\tif (v47) goto L_0081;\n\tgoto L_0035;\n\tv158 = *([1ED7020]);\n\tv159 = *([v158 @ X8_v39]);\n\tv160 = \"il2cpp_codegen_initialize_method\"(v159, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv162 = 0 | 1;\n\t*([2022B9B]) = v162;\nL_0035:\n\tv112 = v166._logPriority < 2;\n\tif (v112) goto L_0090;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\tgoto L_0090;\nL_003F:\n\tgoto L_0055;\n\tv53 = *([1ED7020]);\n\tv54 = *([v53 @ X8_v12]);\n\tv55 = \"il2cpp_codegen_initialize_method\"(v54, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv58 = 0 | 1;\n\t*([2022B9B]) = v58;\nL_0055:\n\tv74 = v62._logPriority < 2;\n\tif (v74) goto L_0090;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\tgoto L_0090;\nL_005F:\n\tgoto L_0075;\n\tv86 = *([1ED7020]);\n\tv87 = *([v86 @ X8_v23]);\n\tv88 = \"il2cpp_codegen_initialize_method\"(v87, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv91 = 0 | 1;\n\t*([2022B9B]) = v91;\nL_0075:\n\tv107 = v95._logPriority < 2;\n\tif (v107) goto L_0090;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\tgoto L_0090;\nL_0081:\n\tgoto L_0089;\n\tv169 = *([v81 @ X0_v12+E0]);\n\tv170 = v169 == 0;\n\tv171 = ~v170;\n\tif (v171) goto L_0089;\n\tv173 = \"il2cpp_codegen_runtime_class_init\"(v81, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0089:\n\tv142 = DG.Tweening.Core.TweenManager::Play(t);\nL_0090:\n\treturn t;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T Play<T>(this T t) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E1]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						bool flag = TweenManager.Play(t);
					}
					else if (Debugger._logPriority >= 2)
					{
						Debugger.LogNestedTween(t);
					}
				}
				else if (Debugger._logPriority >= 2)
				{
					Debugger.LogInvalidTween(t);
				}
			}
			else if (Debugger._logPriority >= 2)
			{
				Debugger.LogNullTween(null);
			}
			return t;
		}

		[Token(Token = "0x6000071")]
		[Address(RVA = "0x1603214", Offset = "0x1603214", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EF3380]);\n\tv19 = *([v18 @ X8_v43]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A1BE]) = v38;\nL_0013:\n\tv39 = t == 0;\n\tif (v39) goto L_0044;\n\tv41 = ~t.<active>k__BackingField;\n\tif (v41) goto L_0069;\n\tv47 = ~t.isSequenced;\n\tif (v47) goto L_0096;\n\tgoto L_0035;\n\tv144 = *([1EC8838]);\n\tv145 = *([v144 @ X8_v39]);\n\tv146 = \"il2cpp_codegen_initialize_method\"(v145, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv148 = 0 | 1;\n\t*([2022B9B]) = v148;\nL_0035:\n\tv115 = v152._logPriority < 2;\n\tif (v115) goto L_008F;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\treturn;\nL_0044:\n\tgoto L_005A;\n\tv53 = *([1EC8838]);\n\tv54 = *([v53 @ X8_v12]);\n\tv55 = \"il2cpp_codegen_initialize_method\"(v54, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv58 = 0 | 1;\n\t*([2022B9B]) = v58;\nL_005A:\n\tv74 = v62._logPriority < 2;\n\tif (v74) goto L_008F;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\treturn;\nL_0069:\n\tgoto L_007F;\n\tv86 = *([1EC8838]);\n\tv87 = *([v86 @ X8_v23]);\n\tv88 = \"il2cpp_codegen_initialize_method\"(v87, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv91 = 0 | 1;\n\t*([2022B9B]) = v91;\nL_007F:\n\tv107 = v95._logPriority < 2;\n\tif (v107) goto L_008F;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\treturn;\nL_008F:\n\treturn;\nL_0096:\n\tgoto L_00A3;\n\tv155 = *([v81 @ X0_v11+E0]);\n\tv156 = v155 == 0;\n\tv157 = ~v156;\n\tif (v157) goto L_00A3;\n\tv159 = \"il2cpp_codegen_runtime_class_init\"(v81, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_00A3:\n\tv168 = DG.Tweening.Core.TweenManager::PlayBackwards(t);\n\treturn;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void PlayBackwards(this Tween t)
		{
			if (t != null)
			{
				if (t.active)
				{
					if (!t.isSequenced)
					{
						bool flag = TweenManager.PlayBackwards(t);
					}
					else if (Debugger._logPriority >= 2)
					{
						Debugger.LogNestedTween(t);
					}
				}
				else if (Debugger._logPriority >= 2)
				{
					Debugger.LogInvalidTween(t);
				}
			}
			else if (Debugger._logPriority >= 2)
			{
				Debugger.LogNullTween(null);
			}
		}

		[Token(Token = "0x6000072")]
		[Address(RVA = "0x1603398", Offset = "0x1603398", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F0C4F0]);\n\tv19 = *([v18 @ X8_v43]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A1BF]) = v38;\nL_0013:\n\tv39 = t == 0;\n\tif (v39) goto L_0044;\n\tv41 = ~t.<active>k__BackingField;\n\tif (v41) goto L_0069;\n\tv47 = ~t.isSequenced;\n\tif (v47) goto L_0096;\n\tgoto L_0035;\n\tv144 = *([1EC8838]);\n\tv145 = *([v144 @ X8_v39]);\n\tv146 = \"il2cpp_codegen_initialize_method\"(v145, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv148 = 0 | 1;\n\t*([2022B9B]) = v148;\nL_0035:\n\tv115 = v152._logPriority < 2;\n\tif (v115) goto L_008F;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\treturn;\nL_0044:\n\tgoto L_005A;\n\tv53 = *([1EC8838]);\n\tv54 = *([v53 @ X8_v12]);\n\tv55 = \"il2cpp_codegen_initialize_method\"(v54, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv58 = 0 | 1;\n\t*([2022B9B]) = v58;\nL_005A:\n\tv74 = v62._logPriority < 2;\n\tif (v74) goto L_008F;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\treturn;\nL_0069:\n\tgoto L_007F;\n\tv86 = *([1EC8838]);\n\tv87 = *([v86 @ X8_v23]);\n\tv88 = \"il2cpp_codegen_initialize_method\"(v87, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv91 = 0 | 1;\n\t*([2022B9B]) = v91;\nL_007F:\n\tv107 = v95._logPriority < 2;\n\tif (v107) goto L_008F;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\treturn;\nL_008F:\n\treturn;\nL_0096:\n\tgoto L_00A3;\n\tv155 = *([v81 @ X0_v11+E0]);\n\tv156 = v155 == 0;\n\tv157 = ~v156;\n\tif (v157) goto L_00A3;\n\tv159 = \"il2cpp_codegen_runtime_class_init\"(v81, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_00A3:\n\tv168 = DG.Tweening.Core.TweenManager::PlayForward(t);\n\treturn;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void PlayForward(this Tween t)
		{
			if (t != null)
			{
				if (t.active)
				{
					if (!t.isSequenced)
					{
						bool flag = TweenManager.PlayForward(t);
					}
					else if (Debugger._logPriority >= 2)
					{
						Debugger.LogNestedTween(t);
					}
				}
				else if (Debugger._logPriority >= 2)
				{
					Debugger.LogInvalidTween(t);
				}
			}
			else if (Debugger._logPriority >= 2)
			{
				Debugger.LogNullTween(null);
			}
		}

		[Token(Token = "0x6000073")]
		[Address(RVA = "0x160351C", Offset = "0x160351C", Length = "0x1C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EF1FC0]);\n\tv27 = *([v26 @ X8_v43]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, includeDelay, methodInfo, v30, v31, v32, v33, v34, changeDelayTo, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202A1C0]) = v44;\nL_0017:\n\tv45 = t == 0;\n\tif (v45) goto L_004A;\n\tv47 = ~t.<active>k__BackingField;\n\tif (v47) goto L_0071;\n\tv53 = ~t.isSequenced;\n\tif (v53) goto L_00A2;\n\tgoto L_0039;\n\tv154 = *([1EC8838]);\n\tv155 = *([v154 @ X8_v39]);\n\tv156 = \"il2cpp_codegen_initialize_method\"(v155, includeDelay, methodInfo, v30, v31, v32, v33, v34, changeDelayTo, v35, v36, v37, v38, v39, v40, v41);\n\tv158 = 0 | 1;\n\t*([2022B9B]) = v158;\nL_0039:\n\tv123 = v162._logPriority < 2;\n\tif (v123) goto L_009B;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\treturn;\nL_004A:\n\tgoto L_0060;\n\tv59 = *([1EC8838]);\n\tv60 = *([v59 @ X8_v12]);\n\tv61 = \"il2cpp_codegen_initialize_method\"(v60, includeDelay, methodInfo, v30, v31, v32, v33, v34, changeDelayTo, v35, v36, v37, v38, v39, v40, v41);\n\tv64 = 0 | 1;\n\t*([2022B9B]) = v64;\nL_0060:\n\tv80 = v68._logPriority < 2;\n\tif (v80) goto L_009B;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\treturn;\nL_0071:\n\tgoto L_0087;\n\tv92 = *([1EC8838]);\n\tv93 = *([v92 @ X8_v23]);\n\tv94 = \"il2cpp_codegen_initialize_method\"(v93, includeDelay, methodInfo, v30, v31, v32, v33, v34, changeDelayTo, v35, v36, v37, v38, v39, v40, v41);\n\tv97 = 0 | 1;\n\t*([2022B9B]) = v97;\nL_0087:\n\tv113 = v101._logPriority < 2;\n\tif (v113) goto L_009B;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\treturn;\nL_009B:\n\treturn;\nL_00A2:\n\tgoto L_00B3;\n\tv165 = *([v87 @ X0_v11+E0]);\n\tv166 = v165 == 0;\n\tv167 = ~v166;\n\tif (v167) goto L_00B3;\n\tv169 = \"il2cpp_codegen_runtime_class_init\"(v87, includeDelay, methodInfo, v30, v31, v32, v33, v34, changeDelayTo, v35, v36, v37, v38, v39, v40, v41);\nL_00B3:\n\tv182 = DG.Tweening.Core.TweenManager::Restart(t, includeDelay, changeDelayTo);\n\treturn;\n// 130 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Restart(this Tween t, bool includeDelay = true, float changeDelayTo = -1f)
		{
			if (t != null)
			{
				if (t.active)
				{
					if (!t.isSequenced)
					{
						bool flag = TweenManager.Restart(t, includeDelay, changeDelayTo);
					}
					else if (Debugger._logPriority >= 2)
					{
						Debugger.LogNestedTween(t);
					}
				}
				else if (Debugger._logPriority >= 2)
				{
					Debugger.LogInvalidTween(t);
				}
			}
			else if (Debugger._logPriority >= 2)
			{
				Debugger.LogNullTween(null);
			}
		}

		[Token(Token = "0x6000074")]
		[Address(RVA = "0x16036E0", Offset = "0x16036E0", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EE6DA8]);\n\tv23 = *([v22 @ X8_v43]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, includeDelay, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A1C1]) = v41;\nL_0015:\n\tv42 = t == 0;\n\tif (v42) goto L_0047;\n\tv44 = ~t.<active>k__BackingField;\n\tif (v44) goto L_006D;\n\tv50 = ~t.isSequenced;\n\tif (v50) goto L_009C;\n\tgoto L_0037;\n\tv149 = *([1EC8838]);\n\tv150 = *([v149 @ X8_v39]);\n\tv151 = \"il2cpp_codegen_initialize_method\"(v150, includeDelay, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv153 = 0 | 1;\n\t*([2022B9B]) = v153;\nL_0037:\n\tv119 = v157._logPriority < 2;\n\tif (v119) goto L_0095;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\treturn;\nL_0047:\n\tgoto L_005D;\n\tv56 = *([1EC8838]);\n\tv57 = *([v56 @ X8_v12]);\n\tv58 = \"il2cpp_codegen_initialize_method\"(v57, includeDelay, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv61 = 0 | 1;\n\t*([2022B9B]) = v61;\nL_005D:\n\tv77 = v65._logPriority < 2;\n\tif (v77) goto L_0095;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\treturn;\nL_006D:\n\tgoto L_0083;\n\tv89 = *([1EC8838]);\n\tv90 = *([v89 @ X8_v23]);\n\tv91 = \"il2cpp_codegen_initialize_method\"(v90, includeDelay, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv94 = 0 | 1;\n\t*([2022B9B]) = v94;\nL_0083:\n\tv110 = v98._logPriority < 2;\n\tif (v110) goto L_0095;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\treturn;\nL_0095:\n\treturn;\nL_009C:\n\tgoto L_00AB;\n\tv160 = *([v84 @ X0_v11+E0]);\n\tv161 = v160 == 0;\n\tv162 = ~v161;\n\tif (v162) goto L_00AB;\n\tv164 = \"il2cpp_codegen_runtime_class_init\"(v84, includeDelay, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00AB:\n\tv175 = DG.Tweening.Core.TweenManager::Rewind(t, includeDelay);\n\treturn;\n// 122 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Rewind(this Tween t, bool includeDelay = true)
		{
			if (t != null)
			{
				if (t.active)
				{
					if (!t.isSequenced)
					{
						bool flag = TweenManager.Rewind(t, includeDelay);
					}
					else if (Debugger._logPriority >= 2)
					{
						Debugger.LogNestedTween(t);
					}
				}
				else if (Debugger._logPriority >= 2)
				{
					Debugger.LogInvalidTween(t);
				}
			}
			else if (Debugger._logPriority >= 2)
			{
				Debugger.LogNullTween(null);
			}
		}

		[Token(Token = "0x6000075")]
		[Address(RVA = "0x1603884", Offset = "0x1603884", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F03F60]);\n\tv19 = *([v18 @ X8_v43]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A1C2]) = v38;\nL_0013:\n\tv39 = t == 0;\n\tif (v39) goto L_0044;\n\tv41 = ~t.<active>k__BackingField;\n\tif (v41) goto L_0069;\n\tv47 = ~t.isSequenced;\n\tif (v47) goto L_0096;\n\tgoto L_0035;\n\tv144 = *([1EC8838]);\n\tv145 = *([v144 @ X8_v39]);\n\tv146 = \"il2cpp_codegen_initialize_method\"(v145, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv148 = 0 | 1;\n\t*([2022B9B]) = v148;\nL_0035:\n\tv115 = v152._logPriority < 2;\n\tif (v115) goto L_008F;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\treturn;\nL_0044:\n\tgoto L_005A;\n\tv53 = *([1EC8838]);\n\tv54 = *([v53 @ X8_v12]);\n\tv55 = \"il2cpp_codegen_initialize_method\"(v54, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv58 = 0 | 1;\n\t*([2022B9B]) = v58;\nL_005A:\n\tv74 = v62._logPriority < 2;\n\tif (v74) goto L_008F;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\treturn;\nL_0069:\n\tgoto L_007F;\n\tv86 = *([1EC8838]);\n\tv87 = *([v86 @ X8_v23]);\n\tv88 = \"il2cpp_codegen_initialize_method\"(v87, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv91 = 0 | 1;\n\t*([2022B9B]) = v91;\nL_007F:\n\tv107 = v95._logPriority < 2;\n\tif (v107) goto L_008F;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\treturn;\nL_008F:\n\treturn;\nL_0096:\n\tgoto L_00A3;\n\tv155 = *([v81 @ X0_v11+E0]);\n\tv156 = v155 == 0;\n\tv157 = ~v156;\n\tif (v157) goto L_00A3;\n\tv159 = \"il2cpp_codegen_runtime_class_init\"(v81, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_00A3:\n\tv168 = DG.Tweening.Core.TweenManager::SmoothRewind(t);\n\treturn;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SmoothRewind(this Tween t)
		{
			if (t != null)
			{
				if (t.active)
				{
					if (!t.isSequenced)
					{
						bool flag = TweenManager.SmoothRewind(t);
					}
					else if (Debugger._logPriority >= 2)
					{
						Debugger.LogNestedTween(t);
					}
				}
				else if (Debugger._logPriority >= 2)
				{
					Debugger.LogInvalidTween(t);
				}
			}
			else if (Debugger._logPriority >= 2)
			{
				Debugger.LogNullTween(null);
			}
		}

		[Token(Token = "0x6000076")]
		[Address(RVA = "0x1603A08", Offset = "0x1603A08", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EFA360]);\n\tv19 = *([v18 @ X8_v43]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A1C3]) = v38;\nL_0013:\n\tv39 = t == 0;\n\tif (v39) goto L_0044;\n\tv41 = ~t.<active>k__BackingField;\n\tif (v41) goto L_0069;\n\tv47 = ~t.isSequenced;\n\tif (v47) goto L_0096;\n\tgoto L_0035;\n\tv144 = *([1EC8838]);\n\tv145 = *([v144 @ X8_v39]);\n\tv146 = \"il2cpp_codegen_initialize_method\"(v145, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv148 = 0 | 1;\n\t*([2022B9B]) = v148;\nL_0035:\n\tv115 = v152._logPriority < 2;\n\tif (v115) goto L_008F;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\treturn;\nL_0044:\n\tgoto L_005A;\n\tv53 = *([1EC8838]);\n\tv54 = *([v53 @ X8_v12]);\n\tv55 = \"il2cpp_codegen_initialize_method\"(v54, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv58 = 0 | 1;\n\t*([2022B9B]) = v58;\nL_005A:\n\tv74 = v62._logPriority < 2;\n\tif (v74) goto L_008F;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\treturn;\nL_0069:\n\tgoto L_007F;\n\tv86 = *([1EC8838]);\n\tv87 = *([v86 @ X8_v23]);\n\tv88 = \"il2cpp_codegen_initialize_method\"(v87, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv91 = 0 | 1;\n\t*([2022B9B]) = v91;\nL_007F:\n\tv107 = v95._logPriority < 2;\n\tif (v107) goto L_008F;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\treturn;\nL_008F:\n\treturn;\nL_0096:\n\tgoto L_00A3;\n\tv155 = *([v81 @ X0_v11+E0]);\n\tv156 = v155 == 0;\n\tv157 = ~v156;\n\tif (v157) goto L_00A3;\n\tv159 = \"il2cpp_codegen_runtime_class_init\"(v81, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_00A3:\n\tv168 = DG.Tweening.Core.TweenManager::TogglePause(t);\n\treturn;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void TogglePause(this Tween t)
		{
			if (t != null)
			{
				if (t.active)
				{
					if (!t.isSequenced)
					{
						bool flag = TweenManager.TogglePause(t);
					}
					else if (Debugger._logPriority >= 2)
					{
						Debugger.LogNestedTween(t);
					}
				}
				else if (Debugger._logPriority >= 2)
				{
					Debugger.LogInvalidTween(t);
				}
			}
			else if (Debugger._logPriority >= 2)
			{
				Debugger.LogNullTween(null);
			}
		}

		[Token(Token = "0x6000077")]
		[Address(RVA = "0x1603B8C", Offset = "0x1603B8C", Length = "0x388")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1ECA020]);\n\tv29 = *([v28 @ X8_v65]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, waypointIndex, andPlay, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202A1C4]) = v46;\nL_0018:\n\tv47 = t == 0;\n\tif (v47) goto L_004C;\n\tv49 = ~t.<active>k__BackingField;\n\tif (v49) goto L_0074;\n\tv55 = ~t.isSequenced;\n\tif (v55) goto L_009A;\n\tgoto L_003A;\n\tv191 = *([1EC8838]);\n\tv192 = *([v191 @ X8_v61]);\n\tv193 = \"il2cpp_codegen_initialize_method\"(v192, waypointIndex, andPlay, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv195 = 0 | 1;\n\t*([2022B9B]) = v195;\nL_003A:\n\tv139 = v199._logPriority < 2;\n\tif (v139) goto L_00E7;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\treturn;\nL_004C:\n\tgoto L_0062;\n\tv61 = *([1EC8838]);\n\tv62 = *([v61 @ X8_v12]);\n\tv63 = \"il2cpp_codegen_initialize_method\"(v62, waypointIndex, andPlay, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv66 = 0 | 1;\n\t*([2022B9B]) = v66;\nL_0062:\n\tv82 = v70._logPriority < 2;\n\tif (v82) goto L_00E7;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\treturn;\nL_0074:\n\tgoto L_008A;\n\tv104 = *([1EC8838]);\n\tv105 = *([v104 @ X8_v23]);\n\tv106 = \"il2cpp_codegen_initialize_method\"(v105, waypointIndex, andPlay, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv109 = 0 | 1;\n\t*([2022B9B]) = v109;\nL_008A:\n\tv125 = v113._logPriority < 2;\n\tif (v125) goto L_00E7;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\treturn;\nL_009A:\n\tv89 = *([2022000]);\n\tv90 = DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>;\n\tv93 = *([v89 @ X9_v2+128]) < *([v90 @ X8_v28 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>)+128]);\n\tv94 = ~v93;\n\tv102 = ~v94;\n\tif (v102) goto L_00BB;\n\tv203 = *([v90 @ X8_v28 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>)+128]) << 3;\n\tv204 = *([v89 @ X9_v2+C8]) + v203;\n\tv210 = *([v204 @ X9_v5-8]) == DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>;\n\tif (v210) goto L_00E9;\nL_00BB:\n\tgoto L_00D1;\n\tv346 = *([1EC8838]);\n\tv347 = *([v346 @ X8_v37]);\n\tv348 = \"il2cpp_codegen_initialize_method\"(v347, waypointIndex, andPlay, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv350 = 0 | 1;\n\t*([2022B9B]) = v350;\nL_00D1:\n\tv140 = v354._logPriority < 2;\n\tif (v140) goto L_00E7;\n\tDG.Tweening.Core.Debugger::LogNonPathTween(t);\n\treturn;\nL_00E7:\n\treturn;\nL_00E9:\n\tv343 = *([20220F9]) == 0;\n\tv344 = ~v343;\n\tif (v344) goto L_00FC;\n\tgoto L_00FB;\n\tv376 = *([v359 @ X0_v26+E0]);\n\tv377 = v376 == 0;\n\tv378 = ~v377;\n\tif (v378) goto L_00FB;\n\tv380 = \"il2cpp_codegen_runtime_class_init\"(v359, waypointIndex, andPlay, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00FB:\n\tDG.Tweening.Core.TweenManager::ForceInit(t, 0);\nL_00FC:\n\tv333 = *([2022130]);\n\tv373 = waypointIndex & 0x80000000;\n\tv374 = v373 == 0;\n\tv375 = ~v374;\n\tif (v375) goto L_FFFFFFFF;\n\tv383 = *([v333 @ X8_v41+28]);\n\tv476 = *([v383 @ X9_v18+18]) - 1;\n\tv428 = v476 - waypointIndex;\n\tv429 = v428 < 0;\n\tv431 = v476 ^ waypointIndex;\n\tv432 = v476 ^ v428;\n\tv433 = v431 & v432;\n\tv434 = v433 < 0;\n\tv435 = v429 == v434;\n\tv436 = ~v435;\n\tv437 = ~v436;\n\tif (v437) goto L_FFFFFFFF;\n\tgoto L_0119;\nL_0119:\n\tv418 = v476 + 1;\n\tgoto L_0128;\nL_0128:\n\tv470 = v418 < 1;\n\tif (v470) goto L_FFFFFFFF;\n\tv416 = *([v333 @ X8_v41+10]);\n\tv390 = *([v333 @ X8_v41+10]) + 0x20;\nL_0131:\n\tv516 = v414 < *([v416 @ X11_v4+18]);\n\tv446 = ~v516;\n\tif (v446) goto L_01A3;\n\tv414 = v414 + 1;\n\tv491 = v491 + *([v390 @ X12_v2+v414 @ X10_v9 (System.Int32)*4]);\n\tv479 = v414 < v418;\n\tif (v479) goto L_0131;\n\tgoto L_0157;\nL_0157:\n\tv554 = v491 / *([v333 @ X8_v41+38]);\n\tv515 = *([20220A8]) != 1;\n\tif (v515) goto L_017D;\n\tv241 = *([20220A0]);\n\tv557 = *([2022104]);\n\tv523 = *([20220FC]) - *([20220A0]);\n\tv524 = v523 < 0;\n\tv530 = *([2022104]) & 1;\n\tv531 = ~v524;\n\tv533 = v531 ^ v530;\n\tv534 = 1f - v554;\n\tv539 = v533 == 0;\n\tv544 = ~v539;\n\tv545 = ~v544;\n\tif (v545) goto L_017C;\n\tgoto L_017C;\nL_017C:\n\tgoto L_0182;\nL_017D:\n\tv557 = *([2022104]);\n\tv241 = *([20220A0]);\nL_0182:\n\tv560 = v554 * v241;\n\tv561 = *([2022109]) & 1;\n\tv563 = v557 - v561;\n\tv239 = v241 * v563;\n\tv565 = v560 + v239;\n\tgoto L_019F;\n\tv568 = *([v562 @ X0_v16+E0]);\n\tv569 = v568 == 0;\n\tv570 = ~v569;\n\tgoto L_019F;\n\tv572 = \"il2cpp_codegen_runtime_class_init\"(v562, v365, v363, methodInfo, v32, v33, v34, v35, v560, v241, v239, v237, v40, v41, v42, v43);\nL_019F:\n\tv314 = DG.Tweening.Core.TweenManager::Goto(t, v565, andPlay, 1);\n\treturn;\n\tv422 = new System.NullReferenceException();\nL_01A3:\n\tv448 = new System.IndexOutOfRangeException();\n\tthrow v448;\n\treturn;\n// 283 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void GotoWaypoint(this Tween t, int waypointIndex, bool andPlay = false)
		{
			//IL_007b: Expected O, but got I
			//IL_0089: Expected I, but got O
			//IL_00f6: Expected O, but got I
			//IL_0188: Expected O, but got I
			//IL_019a: Expected I4, but got I8
			//IL_01d2: Expected O, but got I
			//IL_02a1: Expected O, but got I
			//IL_02b7: Expected O, but got I
			//IL_0429: Expected O, but got I
			//IL_0439: Expected O, but got I
			//IL_05a4: Expected O, but got I
			//IL_05b3: Expected O, but got I
			//IL_035f: Expected O, but got I
			//IL_036f: Expected O, but got I
			//IL_038c: Expected O, but got I
			if (t != null)
			{
				if (t.active)
				{
					if (!t.isSequenced)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [2022000]");
						object obj = 0;
						IntPtr intPtr = (IntPtr)typeof(TweenerCore<Vector3, Path, PathOptions>);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ X9_v2+128]");
						IntPtr intPtr2 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ X8_v28 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>)+128]");
						if ((long)intPtr2 >= 0L)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ X8_v28 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>)+128]");
							int num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ X9_v2+C8]");
							object obj2 = 0L + (long)num;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ X9_v5-8]");
							if ((IntPtr)0 == (IntPtr)typeof(TweenerCore<Vector3, Path, PathOptions>))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [20220F9]");
								if ((IntPtr)0 == (IntPtr)0)
								{
									TweenManager.ForceInit(t);
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [2022130]");
								object obj3 = 0;
								int num7;
								if ((int)(waypointIndex & 0x80000000L) == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ X8_v41+28]");
									object obj4 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v383 @ X9_v18+18]");
									int num2 = (int)(-1);
									int num3 = num2 - waypointIndex;
									bool flag = num3 < 0;
									int num4 = num2 ^ waypointIndex;
									int num5 = num2 ^ num3;
									int num6 = num4 & num5;
									bool flag2 = num6 < 0;
									if (flag == flag2)
									{
										num2 = waypointIndex;
									}
									num7 = num2 + 1;
								}
								else
								{
									num7 = 1;
								}
								int num8;
								if (num7 >= 1)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ X8_v41+10]");
									object obj5 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ X8_v41+10]");
									object obj6 = 0L + 32L;
									num8 = 0;
									int num9 = 0;
									do
									{
										int num10 = num9;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ X11_v4+18]");
										if ((long)num10 < 0L)
										{
											num9++;
											int num11 = num8;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ X12_v2+v414 @ X10_v9 (System.Int32)*4]");
											num8 = (int)((long)num11 + 0L);
											continue;
										}
										IndexOutOfRangeException ex = new IndexOutOfRangeException();
										throw ex;
									}
									while (num9 < num7);
								}
								else
								{
									num8 = 0;
								}
								float num12 = num8;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ X8_v41+38]");
								float num13 = num12 / 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [20220A8]");
								object obj7;
								object obj8;
								if ((IntPtr)0 == (IntPtr)1)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [20220A0]");
									obj7 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [2022104]");
									obj8 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [20220FC]");
									IntPtr intPtr3 = (IntPtr)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [20220A0]");
									object obj9 = (long)intPtr3 - 0L;
									bool flag3 = (long)(IntPtr)obj9 < 0L;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [2022104]");
									int num14 = 0;
									bool flag4 = !flag3;
									int num15 = (flag4 ? 1 : 0) ^ num14;
									float num16 = 1f - num13;
									if (num15 != 0)
									{
										num13 = num16;
									}
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [2022104]");
									obj8 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [20220A0]");
									obj7 = 0;
								}
								float num17 = num13 * (float)obj7;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [2022109]");
								int num18 = 0;
								object obj10 = (long)(IntPtr)obj8 - (long)num18;
								object obj11 = (long)(IntPtr)obj7 * (long)(IntPtr)obj10;
								float to = num17 + (float)obj11;
								bool flag5 = TweenManager.Goto(t, to, andPlay);
								return;
							}
						}
						if (Debugger._logPriority >= 2)
						{
							Debugger.LogNonPathTween(t);
						}
					}
					else if (Debugger._logPriority >= 2)
					{
						Debugger.LogNestedTween(t);
					}
				}
				else if (Debugger._logPriority >= 2)
				{
					Debugger.LogInvalidTween(t);
				}
			}
			else if (Debugger._logPriority >= 2)
			{
				Debugger.LogNullTween(null);
			}
		}

		[Token(Token = "0x6000078")]
		[Address(RVA = "0x1603F14", Offset = "0x1603F14", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EB2268]);\n\tv19 = *([v18 @ X8_v22]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A1C5]) = v38;\nL_0016:\n\tv41 = ~t.<active>k__BackingField;\n\tif (v41) goto L_0036;\n\tgoto L_002C;\n\tv62 = *([v54 @ X0_v12 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\t// 34 ConditionalJump @b21, v64 @ TEMP_v15\n\tv136 = \"il2cpp_codegen_runtime_class_init\"(v54, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv65 = DG.Tweening.DOTween;\nL_002C:\n\tv140 = DG.Tweening.Core.DOTweenComponent::WaitForCompletion(v47.instance, t);\n\tv149 = UnityEngine.MonoBehaviour::StartCoroutine(v47.instance, v140);\n\tgoto L_0057;\nL_0036:\n\tgoto L_004C;\n\tv69 = *([1EC8838]);\n\tv70 = *([v69 @ X8_v14]);\n\tv71 = \"il2cpp_codegen_initialize_method\"(v70, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv74 = 0 | 1;\n\t*([2022B9B]) = v74;\nL_004C:\n\tv90 = v78._logPriority < 1;\n\tif (v90) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_0057:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static YieldInstruction WaitForCompletion(this Tween t)
		{
			if (t.active)
			{
				IEnumerator routine = DOTween.instance.WaitForCompletion(t);
				return DOTween.instance.StartCoroutine(routine);
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogInvalidTween(t);
			}
			return null;
		}

		[Token(Token = "0x6000079")]
		[Address(RVA = "0x160400C", Offset = "0x160400C", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EE9988]);\n\tv19 = *([v18 @ X8_v22]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A1C6]) = v38;\nL_0016:\n\tv41 = ~t.<active>k__BackingField;\n\tif (v41) goto L_0036;\n\tgoto L_002C;\n\tv62 = *([v54 @ X0_v12 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\t// 34 ConditionalJump @b21, v64 @ TEMP_v15\n\tv136 = \"il2cpp_codegen_runtime_class_init\"(v54, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv65 = DG.Tweening.DOTween;\nL_002C:\n\tv140 = DG.Tweening.Core.DOTweenComponent::WaitForRewind(v47.instance, t);\n\tv149 = UnityEngine.MonoBehaviour::StartCoroutine(v47.instance, v140);\n\tgoto L_0057;\nL_0036:\n\tgoto L_004C;\n\tv69 = *([1EC8838]);\n\tv70 = *([v69 @ X8_v14]);\n\tv71 = \"il2cpp_codegen_initialize_method\"(v70, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv74 = 0 | 1;\n\t*([2022B9B]) = v74;\nL_004C:\n\tv90 = v78._logPriority < 1;\n\tif (v90) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_0057:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static YieldInstruction WaitForRewind(this Tween t)
		{
			if (t.active)
			{
				IEnumerator routine = DOTween.instance.WaitForRewind(t);
				return DOTween.instance.StartCoroutine(routine);
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogInvalidTween(t);
			}
			return null;
		}

		[Token(Token = "0x600007A")]
		[Address(RVA = "0x1604104", Offset = "0x1604104", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EC67D8]);\n\tv19 = *([v18 @ X8_v22]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A1C7]) = v38;\nL_0016:\n\tv41 = ~t.<active>k__BackingField;\n\tif (v41) goto L_0036;\n\tgoto L_002C;\n\tv62 = *([v54 @ X0_v12 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\t// 34 ConditionalJump @b21, v64 @ TEMP_v15\n\tv136 = \"il2cpp_codegen_runtime_class_init\"(v54, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv65 = DG.Tweening.DOTween;\nL_002C:\n\tv140 = DG.Tweening.Core.DOTweenComponent::WaitForKill(v47.instance, t);\n\tv149 = UnityEngine.MonoBehaviour::StartCoroutine(v47.instance, v140);\n\tgoto L_0057;\nL_0036:\n\tgoto L_004C;\n\tv69 = *([1EC8838]);\n\tv70 = *([v69 @ X8_v14]);\n\tv71 = \"il2cpp_codegen_initialize_method\"(v70, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv74 = 0 | 1;\n\t*([2022B9B]) = v74;\nL_004C:\n\tv90 = v78._logPriority < 1;\n\tif (v90) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_0057:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static YieldInstruction WaitForKill(this Tween t)
		{
			if (t.active)
			{
				IEnumerator routine = DOTween.instance.WaitForKill(t);
				return DOTween.instance.StartCoroutine(routine);
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogInvalidTween(t);
			}
			return null;
		}

		[Token(Token = "0x600007B")]
		[Address(RVA = "0x16041FC", Offset = "0x16041FC", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1ECA9D8]);\n\tv23 = *([v22 @ X8_v22]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, elapsedLoops, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A1C8]) = v41;\nL_0018:\n\tv44 = ~t.<active>k__BackingField;\n\tif (v44) goto L_0039;\n\tgoto L_002F;\n\tv65 = *([v57 @ X0_v12 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\t// 36 ConditionalJump @b21, v67 @ TEMP_v15\n\tv143 = \"il2cpp_codegen_runtime_class_init\"(v57, elapsedLoops, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv68 = DG.Tweening.DOTween;\nL_002F:\n\tv148 = DG.Tweening.Core.DOTweenComponent::WaitForElapsedLoops(v50.instance, t, elapsedLoops);\n\tv157 = UnityEngine.MonoBehaviour::StartCoroutine(v50.instance, v148);\n\tgoto L_005B;\nL_0039:\n\tgoto L_004F;\n\tv72 = *([1EC8838]);\n\tv73 = *([v72 @ X8_v14]);\n\tv74 = \"il2cpp_codegen_initialize_method\"(v73, elapsedLoops, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv77 = 0 | 1;\n\t*([2022B9B]) = v77;\nL_004F:\n\tv93 = v81._logPriority < 1;\n\tif (v93) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_005B:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static YieldInstruction WaitForElapsedLoops(this Tween t, int elapsedLoops)
		{
			if (t.active)
			{
				IEnumerator routine = DOTween.instance.WaitForElapsedLoops(t, elapsedLoops);
				return DOTween.instance.StartCoroutine(routine);
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogInvalidTween(t);
			}
			return null;
		}

		[Token(Token = "0x600007C")]
		[Address(RVA = "0x1604304", Offset = "0x1604304", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EC98E0]);\n\tv23 = *([v22 @ X8_v22]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, position, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A1C9]) = v41;\nL_0018:\n\tv44 = ~t.<active>k__BackingField;\n\tif (v44) goto L_0039;\n\tgoto L_002F;\n\tv65 = *([v57 @ X0_v12 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\t// 36 ConditionalJump @b21, v67 @ TEMP_v15\n\tv143 = \"il2cpp_codegen_runtime_class_init\"(v57, methodInfo, v26, v27, v28, v29, v30, v31, position, v32, v33, v34, v35, v36, v37, v38);\n\tv68 = DG.Tweening.DOTween;\nL_002F:\n\tv148 = DG.Tweening.Core.DOTweenComponent::WaitForPosition(v50.instance, t, position);\n\tv157 = UnityEngine.MonoBehaviour::StartCoroutine(v50.instance, v148);\n\tgoto L_005B;\nL_0039:\n\tgoto L_004F;\n\tv72 = *([1EC8838]);\n\tv73 = *([v72 @ X8_v14]);\n\tv74 = \"il2cpp_codegen_initialize_method\"(v73, methodInfo, v26, v27, v28, v29, v30, v31, position, v32, v33, v34, v35, v36, v37, v38);\n\tv77 = 0 | 1;\n\t*([2022B9B]) = v77;\nL_004F:\n\tv93 = v81._logPriority < 1;\n\tif (v93) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_005B:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static YieldInstruction WaitForPosition(this Tween t, float position)
		{
			if (t.active)
			{
				IEnumerator routine = DOTween.instance.WaitForPosition(t, position);
				return DOTween.instance.StartCoroutine(routine);
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogInvalidTween(t);
			}
			return null;
		}

		[Token(Token = "0x600007D")]
		[Address(RVA = "0x160440C", Offset = "0x160440C", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1ED6B38]);\n\tv19 = *([v18 @ X8_v21]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A1CA]) = v38;\nL_0016:\n\tv41 = ~t.<active>k__BackingField;\n\tif (v41) goto L_003B;\n\tgoto L_002C;\n\tv62 = *([v54 @ X0_v11 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\t// 34 ConditionalJump @b21, v64 @ TEMP_v14\n\tv131 = \"il2cpp_codegen_runtime_class_init\"(v54, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv65 = DG.Tweening.DOTween;\nL_002C:\n\tv135 = DG.Tweening.Core.DOTweenComponent::WaitForStart(v47.instance, t);\n\treturnVal3 = UnityEngine.MonoBehaviour::StartCoroutine(v47.instance, v135);\n\treturn returnVal3;\nL_003B:\n\tgoto L_0051;\n\tv69 = *([1EC8838]);\n\tv70 = *([v69 @ X8_v13]);\n\tv71 = \"il2cpp_codegen_initialize_method\"(v70, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv74 = 0 | 1;\n\t*([2022B9B]) = v74;\nL_0051:\n\tv90 = v78._logPriority < 1;\n\tif (v90) goto L_005C;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_005C:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Coroutine WaitForStart(this Tween t)
		{
			if (t.active)
			{
				IEnumerator routine = DOTween.instance.WaitForStart(t);
				return DOTween.instance.StartCoroutine(routine);
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogInvalidTween(t);
			}
			return null;
		}

		[Token(Token = "0x600007E")]
		[Address(RVA = "0x1604508", Offset = "0x1604508", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = ~t.<active>k__BackingField;\n\tif (v14) goto L_0012;\n\treturnVal2 = t.completedLoops;\n\tgoto L_0033;\nL_0012:\n\tgoto L_0028;\n\tv76 = *([1EC8838]);\n\tv77 = *([v76 @ X8_v11]);\n\tv78 = \"il2cpp_codegen_initialize_method\"(v77, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv81 = 0 | 1;\n\t*([2022B9B]) = v81;\nL_0028:\n\tv37 = v85._logPriority < 1;\n\tif (v37) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_0033:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int CompletedLoops(this Tween t)
		{
			if (t.active)
			{
				return t.completedLoops;
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogInvalidTween(t);
			}
			return 0;
		}

		[Token(Token = "0x600007F")]
		[Address(RVA = "0x160458C", Offset = "0x160458C", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = ~t.<active>k__BackingField;\n\tif (v16) goto L_0013;\n\tv71 = t.delay;\n\tgoto L_0036;\nL_0013:\n\tgoto L_002A;\n\tv83 = *([1EC8838]);\n\tv84 = *([v83 @ X8_v11]);\n\tv85 = \"il2cpp_codegen_initialize_method\"(v84, methodInfo, v19, v20, v21, v22, v23, v24, returnVal1, v26, v27, v28, v29, v30, v31, v32);\n\tv87 = 0 | 1;\n\t*([2022B9B]) = v87;\nL_002A:\n\tv39 = v91._logPriority < 1;\n\tif (v39) goto L_0036;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_0036:\n\treturn v71;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float Delay(this Tween t)
		{
			float result;
			if (t.active)
			{
				result = t.delay;
			}
			else
			{
				bool flag = Debugger._logPriority < 1;
				result = 0f;
				if (!flag)
				{
					Debugger.LogInvalidTween(t);
					result = 0f;
				}
			}
			return result;
		}

		[Token(Token = "0x6000080")]
		[Address(RVA = "0x160461C", Offset = "0x160461C", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = ~t.<active>k__BackingField;\n\tif (v16) goto L_001F;\n\tv34 = includeLoops == 0;\n\tif (v34) goto L_003C;\n\tv40 = t.loops + 1;\n\tv42 = v40 == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tv128 = t.duration * t.loops;\n\tgoto L_0047;\nL_001F:\n\tgoto L_0036;\n\tv47 = *([1EC8838]);\n\tv48 = *([v47 @ X8_v11]);\n\tv49 = \"il2cpp_codegen_initialize_method\"(v48, includeLoops, methodInfo, v20, v21, v22, v23, v24, returnVal1, v26, v27, v28, v29, v30, v31, v32);\n\tv52 = 0 | 1;\n\t*([2022B9B]) = v52;\nL_0036:\n\tv69 = v57._logPriority < 1;\n\tif (v69) goto L_0047;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\tgoto L_0047;\nL_003C:\n\tv128 = t.duration;\n\tgoto L_0047;\nL_0047:\n\treturn v128;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float Duration(this Tween t, bool includeLoops = true)
		{
			float result;
			if (t.active)
			{
				result = ((!includeLoops) ? t.duration : ((t.loops + 1 == 0) ? float.PositiveInfinity : (t.duration * (float)t.loops)));
			}
			else
			{
				bool flag = Debugger._logPriority < 1;
				result = 0f;
				if (!flag)
				{
					Debugger.LogInvalidTween(t);
					result = 0f;
				}
			}
			return result;
		}

		[Token(Token = "0x6000081")]
		[Address(RVA = "0x1601FE0", Offset = "0x1601FE0", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = ~t.<active>k__BackingField;\n\tif (v16) goto L_0027;\n\tv94 = t.<position>k__BackingField;\n\tv35 = includeLoops == 0;\n\tif (v35) goto L_004A;\n\tv44 = t.<position>k__BackingField - t.duration;\n\tv45 = v44 < 0;\n\tv47 = t.<position>k__BackingField ^ t.duration;\n\tv48 = t.<position>k__BackingField ^ v44;\n\tv49 = v47 & v48;\n\tv50 = v49 < 0;\n\tv51 = v45 == v50;\n\tv53 = t.completedLoops - v51;\n\tv55 = t.duration * v53;\n\tv94 = v94 + v55;\n\tgoto L_004A;\nL_0027:\n\tgoto L_003E;\n\tv106 = *([1EC8838]);\n\tv107 = *([v106 @ X8_v11]);\n\tv108 = \"il2cpp_codegen_initialize_method\"(v107, includeLoops, methodInfo, v20, v21, v22, v23, v24, returnVal1, v26, v27, v28, v29, v30, v31, v32);\n\tv110 = 0 | 1;\n\t*([2022B9B]) = v110;\nL_003E:\n\tv67 = v114._logPriority < 1;\n\tif (v67) goto L_004A;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_004A:\n\treturn v94;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float Elapsed(this Tween t, bool includeLoops = true)
		{
			//IL_0089: Expected I4, but got F4
			//IL_009b: Expected I4, but got F4
			//IL_00d7: Expected O, but got I4
			float num;
			if (t.active)
			{
				num = t.position;
				if (includeLoops)
				{
					float num2 = t.position - t.duration;
					bool flag = num2 < 0f;
					int num3 = t.position ^ t.duration;
					int num4 = t.position ^ num2;
					int num5 = num3 & num4;
					bool flag2 = num5 < 0;
					bool flag3 = flag == flag2;
					object obj = t.completedLoops - (flag3 ? 1 : 0);
					float num6 = t.duration * (float)obj;
					num += num6;
				}
			}
			else
			{
				bool flag4 = Debugger._logPriority < 1;
				num = 0f;
				if (!flag4)
				{
					Debugger.LogInvalidTween(t);
					num = 0f;
				}
			}
			return num;
		}

		[Token(Token = "0x6000082")]
		[Address(RVA = "0x16046D8", Offset = "0x16046D8", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = ~t.<active>k__BackingField;\n\tif (v16) goto L_0036;\n\tv34 = includeLoops == 0;\n\tif (v34) goto L_0055;\n\tv41 = t.fullDuration < 0;\n\tv42 = ~v41;\n\tv45 = t.fullDuration == 0;\n\tv50 = ~v42;\n\tv51 = v50 | v45;\n\tif (v51) goto L_005D;\n\tv141 = t.<position>k__BackingField - t.duration;\n\tv142 = v141 < 0;\n\tv144 = t.<position>k__BackingField ^ t.duration;\n\tv145 = t.<position>k__BackingField ^ v141;\n\tv146 = v144 & v145;\n\tv147 = v146 < 0;\n\tv148 = v142 == v147;\n\tv150 = t.completedLoops - v148;\n\tv152 = t.duration * v150;\n\tv153 = t.<position>k__BackingField + v152;\n\tv158 = v153 / t.fullDuration;\n\tgoto L_005D;\nL_0036:\n\tgoto L_004D;\n\tv56 = *([1EC8838]);\n\tv57 = *([v56 @ X8_v11]);\n\tv58 = \"il2cpp_codegen_initialize_method\"(v57, includeLoops, methodInfo, v20, v21, v22, v23, v24, returnVal1, v26, v27, v28, v29, v30, v31, v32);\n\tv61 = 0 | 1;\n\t*([2022B9B]) = v61;\nL_004D:\n\tv78 = v66._logPriority < 1;\n\tif (v78) goto L_005D;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\tgoto L_005D;\nL_0055:\n\tv158 = t.<position>k__BackingField / t.duration;\nL_005D:\n\treturn v158;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float ElapsedPercentage(this Tween t, bool includeLoops = true)
		{
			//IL_00e2: Expected I4, but got F4
			//IL_00f4: Expected I4, but got F4
			//IL_0130: Expected O, but got I4
			float result;
			if (t.active)
			{
				if (includeLoops)
				{
					bool flag = t.fullDuration < 0f;
					bool flag2 = !flag;
					bool flag3 = t.fullDuration == 0f;
					bool flag4 = !flag2;
					bool flag5 = flag4 || flag3;
					result = 0f;
					if (!flag5)
					{
						float num = t.position - t.duration;
						bool flag6 = num < 0f;
						int num2 = t.position ^ t.duration;
						int num3 = t.position ^ num;
						int num4 = num2 & num3;
						bool flag7 = num4 < 0;
						bool flag8 = flag6 == flag7;
						object obj = t.completedLoops - (flag8 ? 1 : 0);
						float num5 = t.duration * (float)obj;
						float num6 = t.position + num5;
						result = num6 / t.fullDuration;
					}
				}
				else
				{
					result = t.position / t.duration;
				}
			}
			else
			{
				bool flag9 = Debugger._logPriority < 1;
				result = 0f;
				if (!flag9)
				{
					Debugger.LogInvalidTween(t);
					result = 0f;
				}
			}
			return result;
		}

		[Token(Token = "0x6000083")]
		[Address(RVA = "0x16047B0", Offset = "0x16047B0", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = ~t.<active>k__BackingField;\n\tif (v16) goto L_0034;\n\tv74 = t.<position>k__BackingField / t.duration;\n\tv47 = t.completedLoops < 1;\n\tif (v47) goto L_005D;\n\tv62 = t.loopType != 1;\n\tif (v62) goto L_005D;\n\tv151 = ~t.isComplete;\n\tif (v151) goto L_0051;\n\tv152 = t.completedLoops & 1;\n\tv100 = v152 == 0;\n\tif (v100) goto L_0055;\n\tgoto L_005D;\nL_0034:\n\tgoto L_004B;\n\tv109 = *([1EC8838]);\n\tv110 = *([v109 @ X8_v11]);\n\tv111 = \"il2cpp_codegen_initialize_method\"(v110, methodInfo, v19, v20, v21, v22, v23, v24, returnVal1, v26, v27, v28, v29, v30, v31, v32);\n\tv113 = 0 | 1;\n\t*([2022B9B]) = v113;\nL_004B:\n\tv73 = v117._logPriority < 1;\n\tif (v73) goto L_005D;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\tgoto L_005D;\nL_0051:\n\tv153 = t.completedLoops & 1;\n\tv101 = v153 == 0;\n\tif (v101) goto L_005D;\nL_0055:\n\tv74 = 1f - v74;\nL_005D:\n\treturn v74;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float ElapsedDirectionalPercentage(this Tween t)
		{
			float num;
			if (t.active)
			{
				num = t.position / t.duration;
				if (t.completedLoops >= 1 && t.loopType == LoopType.Yoyo)
				{
					if (t.isComplete)
					{
						if ((t.completedLoops & 1) == 0)
						{
							goto IL_011d;
						}
					}
					else if ((t.completedLoops & 1) != 0)
					{
						goto IL_011d;
					}
				}
			}
			else
			{
				bool flag = Debugger._logPriority < 1;
				num = 0f;
				if (!flag)
				{
					Debugger.LogInvalidTween(t);
					num = 0f;
				}
			}
			goto IL_0132;
			IL_011d:
			num = 1f - num;
			goto IL_0132;
			IL_0132:
			return num;
		}

		[Token(Token = "0x6000084")]
		[Address(RVA = "0x160487C", Offset = "0x160487C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn t.<active>k__BackingField;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsActive(this Tween t)
		{
			return t.active;
		}

		[Token(Token = "0x6000085")]
		[Address(RVA = "0x1604894", Offset = "0x1604894", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = ~t.<active>k__BackingField;\n\tif (v14) goto L_001D;\n\tv36 = t.isBackwards == 0;\n\tv41 = ~v36;\n\tgoto L_003E;\nL_001D:\n\tgoto L_0033;\n\tv78 = *([1EC8838]);\n\tv79 = *([v78 @ X8_v11]);\n\tv80 = \"il2cpp_codegen_initialize_method\"(v79, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv83 = 0 | 1;\n\t*([2022B9B]) = v83;\nL_0033:\n\tv53 = v87._logPriority < 1;\n\tif (v53) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_003E:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsBackwards(this Tween t)
		{
			if (t.active)
			{
				bool flag = !t.isBackwards;
				return !flag;
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogInvalidTween(t);
			}
			return false;
		}

		[Token(Token = "0x6000086")]
		[Address(RVA = "0x1604920", Offset = "0x1604920", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = ~t.<active>k__BackingField;\n\tif (v14) goto L_001D;\n\tv36 = t.isComplete == 0;\n\tv41 = ~v36;\n\tgoto L_003E;\nL_001D:\n\tgoto L_0033;\n\tv78 = *([1EC8838]);\n\tv79 = *([v78 @ X8_v11]);\n\tv80 = \"il2cpp_codegen_initialize_method\"(v79, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv83 = 0 | 1;\n\t*([2022B9B]) = v83;\nL_0033:\n\tv53 = v87._logPriority < 1;\n\tif (v53) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_003E:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsComplete(this Tween t)
		{
			if (t.active)
			{
				bool flag = !t.isComplete;
				return !flag;
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogInvalidTween(t);
			}
			return false;
		}

		[Token(Token = "0x6000087")]
		[Address(RVA = "0x16049AC", Offset = "0x16049AC", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = ~t.<active>k__BackingField;\n\tif (v14) goto L_001D;\n\tv36 = t.startupDone == 0;\n\tv41 = ~v36;\n\tgoto L_003E;\nL_001D:\n\tgoto L_0033;\n\tv78 = *([1EC8838]);\n\tv79 = *([v78 @ X8_v11]);\n\tv80 = \"il2cpp_codegen_initialize_method\"(v79, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv83 = 0 | 1;\n\t*([2022B9B]) = v83;\nL_0033:\n\tv53 = v87._logPriority < 1;\n\tif (v53) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_003E:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsInitialized(this Tween t)
		{
			if (t.active)
			{
				bool flag = !t.startupDone;
				return !flag;
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogInvalidTween(t);
			}
			return false;
		}

		[Token(Token = "0x6000088")]
		[Address(RVA = "0x1604A38", Offset = "0x1604A38", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = ~t.<active>k__BackingField;\n\tif (v14) goto L_001D;\n\tv36 = t.isPlaying == 0;\n\tv41 = ~v36;\n\tgoto L_003E;\nL_001D:\n\tgoto L_0033;\n\tv78 = *([1EC8838]);\n\tv79 = *([v78 @ X8_v11]);\n\tv80 = \"il2cpp_codegen_initialize_method\"(v79, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv83 = 0 | 1;\n\t*([2022B9B]) = v83;\nL_0033:\n\tv53 = v87._logPriority < 1;\n\tif (v53) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_003E:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsPlaying(this Tween t)
		{
			if (t.active)
			{
				bool flag = !t.isPlaying;
				return !flag;
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogInvalidTween(t);
			}
			return false;
		}

		[Token(Token = "0x6000089")]
		[Address(RVA = "0x1604AC4", Offset = "0x1604AC4", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = ~t.<active>k__BackingField;\n\tif (v14) goto L_0012;\n\treturnVal2 = t.loops;\n\tgoto L_0033;\nL_0012:\n\tgoto L_0028;\n\tv76 = *([1EC8838]);\n\tv77 = *([v76 @ X8_v11]);\n\tv78 = \"il2cpp_codegen_initialize_method\"(v77, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv81 = 0 | 1;\n\t*([2022B9B]) = v81;\nL_0028:\n\tv37 = v85._logPriority < 1;\n\tif (v37) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_0033:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Loops(this Tween t)
		{
			if (t.active)
			{
				return t.loops;
			}
			if (Debugger._logPriority >= 1)
			{
				Debugger.LogInvalidTween(t);
			}
			return 0;
		}

		[Token(Token = "0x600008A")]
		[Address(RVA = "0x1604B48", Offset = "0x1604B48", Length = "0x294")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv22 = *([1EAF600]);\n\tv23 = *([v22 @ X8_v69]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, pathPercentage, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A1CB]) = v41;\nL_0021:\n\tv54 = pathPercentage > 1f;\n\tif (v54) goto L_0030;\n\tv65 = pathPercentage >= 0;\n\tif (v65) goto L_0030;\nL_0030:\n\tv77 = t == 0;\n\tif (v77) goto L_005C;\n\tv79 = ~t.<active>k__BackingField;\n\tif (v79) goto L_007C;\n\tv85 = ~t.isSequenced;\n\tif (v85) goto L_009A;\n\tgoto L_0052;\n\tv238 = *([1EC8838]);\n\tv239 = *([v238 @ X8_v65]);\n\tv240 = \"il2cpp_codegen_initialize_method\"(v239, methodInfo, v26, v27, v28, v29, v30, v31, returnVal2, v32, v33, v34, v35, v36, v37, v38);\n\tv242 = 0 | 1;\n\t*([2022B9B]) = v242;\nL_0052:\n\tv177 = v246._logPriority < 2;\n\tif (v177) goto L_00DC;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\tgoto L_00DC;\nL_005C:\n\tgoto L_0072;\n\tv91 = *([1EC8838]);\n\tv92 = *([v91 @ X8_v17]);\n\tv93 = \"il2cpp_codegen_initialize_method\"(v92, methodInfo, v26, v27, v28, v29, v30, v31, returnVal2, v32, v33, v34, v35, v36, v37, v38);\n\tv96 = 0 | 1;\n\t*([2022B9B]) = v96;\nL_0072:\n\tv112 = v100._logPriority < 2;\n\tif (v112) goto L_00DC;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\tgoto L_00DC;\nL_007C:\n\tgoto L_0092;\n\tv134 = *([1EC8838]);\n\tv135 = *([v134 @ X8_v28]);\n\tv136 = \"il2cpp_codegen_initialize_method\"(v135, methodInfo, v26, v27, v28, v29, v30, v31, returnVal2, v32, v33, v34, v35, v36, v37, v38);\n\tv139 = 0 | 1;\n\t*([2022B9B]) = v139;\nL_0092:\n\tv155 = v143._logPriority < 2;\n\tif (v155) goto L_00DC;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\tgoto L_00DC;\nL_009A:\n\tv119 = *([2022000]);\n\tv120 = DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>;\n\tv123 = *([v119 @ X9_v2+128]) < *([v120 @ X8_v33 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>)+128]);\n\tv124 = ~v123;\n\tv132 = ~v124;\n\tif (v132) goto L_00BB;\n\tv161 = *([v120 @ X8_v33 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>)+128]) << 3;\n\tv250 = *([v119 @ X9_v2+C8]) + v161;\n\tv255 = *([v250 @ X9_v5-8]) == DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>;\n\tif (v255) goto L_00ED;\nL_00BB:\n\tgoto L_00D1;\n\tv287 = *([1EC8838]);\n\tv288 = *([v287 @ X8_v42]);\n\tv289 = \"il2cpp_codegen_initialize_method\"(v288, methodInfo, v26, v27, v28, v29, v30, v31, returnVal2, v32, v33, v34, v35, v36, v37, v38);\n\tv291 = 0 | 1;\n\t*([2022B9B]) = v291;\nL_00D1:\n\tv176 = v295._logPriority < 2;\n\tif (v176) goto L_00DC;\n\tDG.Tweening.Core.Debugger::LogNonPathTween(t);\nL_00DC:\n\tgoto L_00E9;\n\tv270 = *([v233 @ X0_v3+E0]);\n\tv271 = v270 == 0;\n\tv272 = ~v271;\n\tif (v272) goto L_00E9;\n\tv274 = \"il2cpp_codegen_runtime_class_init\"(v233, v170, v26, v27, v28, v29, v30, v31, returnVal2, v32, v33, v34, v35, v36, v37, v38);\nL_00E9:\n\treturnVal1 = UnityEngine.Vector3::get_zero();\n\treturn returnVal1;\nL_00ED:\n\tv284 = *([2022128]);\n\tv301 = ~v284.isFinalized;\n\tif (v301) goto L_0103;\n\treturnVal3 = DG.Tweening.Plugins.Core.PathCore.Path::GetPoint(v284, returnVal2, 1);\n\treturn returnVal3;\nL_0103:\n\tgoto L_0119;\n\tv342 = *([1EC8838]);\n\tv343 = *([v342 @ X8_v55]);\n\tv344 = \"il2cpp_codegen_initialize_method\"(v343, methodInfo, v26, v27, v28, v29, v30, v31, returnVal2, v32, v33, v34, v35, v36, v37, v38);\n\tv346 = 0 | 1;\n\t*([2022B9B]) = v346;\nL_0119:\n\tv178 = v350._logPriority < 2;\n\tif (v178) goto L_00DC;\n\tDG.Tweening.Core.Debugger::LogWarning(\"The path is not finalized yet\");\n\tgoto L_00DC;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 201 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector3 PathGetPoint(this Tween t, float pathPercentage)
		{
			//IL_00bf: Expected O, but got I
			//IL_00cd: Expected I, but got O
			//IL_013a: Expected O, but got I
			//IL_019a: Expected O, but got I
			bool flag = pathPercentage > 1f;
			float perc = 1f;
			if (!flag)
			{
				bool flag2 = !(pathPercentage < 0f);
				perc = pathPercentage;
				if (!flag2)
				{
					perc = 0f;
				}
			}
			if (t != null)
			{
				if (t.active)
				{
					if (!t.isSequenced)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [2022000]");
						object obj = 0;
						IntPtr intPtr = (IntPtr)typeof(TweenerCore<Vector3, Path, PathOptions>);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ X9_v2+128]");
						IntPtr intPtr2 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ X8_v33 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>)+128]");
						if ((long)intPtr2 >= 0L)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ X8_v33 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>)+128]");
							int num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ X9_v2+C8]");
							object obj2 = 0L + (long)num;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ X9_v5-8]");
							if ((IntPtr)0 == (IntPtr)typeof(TweenerCore<Vector3, Path, PathOptions>))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [2022128]");
								Path path = (Path)0;
								if (path.isFinalized)
								{
									return path.GetPoint(perc, convertToConstantPerc: true);
								}
								if (Debugger._logPriority >= 2)
								{
									Debugger.LogWarning("The path is not finalized yet");
								}
								goto IL_017c;
							}
						}
						if (Debugger._logPriority >= 2)
						{
							Debugger.LogNonPathTween(t);
						}
					}
					else if (Debugger._logPriority >= 2)
					{
						Debugger.LogNestedTween(t);
					}
				}
				else if (Debugger._logPriority >= 2)
				{
					Debugger.LogInvalidTween(t);
				}
			}
			else if (Debugger._logPriority >= 2)
			{
				Debugger.LogNullTween(null);
			}
			goto IL_017c;
			IL_017c:
			return Vector3.zero;
		}

		[Token(Token = "0x600008B")]
		[Address(RVA = "0x1604DDC", Offset = "0x1604DDC", Length = "0x258")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EF08B8]);\n\tv23 = *([v22 @ X8_v59]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, subdivisionsXSegment, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A1CC]) = v41;\nL_0015:\n\tv42 = t == 0;\n\tif (v42) goto L_0041;\n\tv44 = ~t.<active>k__BackingField;\n\tif (v44) goto L_0061;\n\tv50 = ~t.isSequenced;\n\tif (v50) goto L_007F;\n\tgoto L_0037;\n\tv185 = *([1EC8838]);\n\tv186 = *([v185 @ X8_v55]);\n\tv187 = \"il2cpp_codegen_initialize_method\"(v186, subdivisionsXSegment, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv189 = 0 | 1;\n\t*([2022B9B]) = v189;\nL_0037:\n\tv128 = v193._logPriority < 2;\n\tif (v128) goto L_00C2;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\tgoto L_00C2;\nL_0041:\n\tgoto L_0057;\n\tv56 = *([1EC8838]);\n\tv57 = *([v56 @ X8_v12]);\n\tv58 = \"il2cpp_codegen_initialize_method\"(v57, subdivisionsXSegment, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv61 = 0 | 1;\n\t*([2022B9B]) = v61;\nL_0057:\n\tv77 = v65._logPriority < 2;\n\tif (v77) goto L_00C2;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\tgoto L_00C2;\nL_0061:\n\tgoto L_0077;\n\tv99 = *([1EC8838]);\n\tv100 = *([v99 @ X8_v23]);\n\tv101 = \"il2cpp_codegen_initialize_method\"(v100, subdivisionsXSegment, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv104 = 0 | 1;\n\t*([2022B9B]) = v104;\nL_0077:\n\tv120 = v108._logPriority < 2;\n\tif (v120) goto L_00C2;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\tgoto L_00C2;\nL_007F:\n\tv84 = *([2022000]);\n\tv85 = DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>;\n\tv88 = *([v84 @ X9_v2+128]) < *([v85 @ X8_v28 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>)+128]);\n\tv89 = ~v88;\n\tv97 = ~v89;\n\tif (v97) goto L_00A0;\n\tv197 = *([v85 @ X8_v28 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>)+128]) << 3;\n\tv198 = *([v84 @ X9_v2+C8]) + v197;\n\tv204 = *([v198 @ X9_v5-8]) == DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>;\n\tif (v204) goto L_00C3;\nL_00A0:\n\tgoto L_00B6;\n\tv260 = *([1EC8838]);\n\tv261 = *([v260 @ X8_v37]);\n\tv262 = \"il2cpp_codegen_initialize_method\"(v261, subdivisionsXSegment, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv264 = 0 | 1;\n\t*([2022B9B]) = v264;\nL_00B6:\n\tv127 = v268._logPriority < 2;\n\tif (v127) goto L_00C2;\n\tDG.Tweening.Core.Debugger::LogNonPathTween(t);\nL_00C2:\n\treturn 0;\nL_00C3:\n\tv277 = *([2022128]);\n\tv243 = ~v277.isFinalized;\n\tif (v243) goto L_00D7;\n\treturnVal3 = DG.Tweening.Plugins.Core.PathCore.Path::GetDrawPoints(v277, subdivisionsXSegment);\n\treturn returnVal3;\nL_00D7:\n\tgoto L_00E0;\n\tv274 = *([1EC8838]);\n\tv275 = *([v274 @ X8_v45]);\n\tv276 = \"il2cpp_codegen_initialize_method\"(v275, subdivisionsXSegment, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv279 = 0 | 1;\n\t*([2022B9B]) = v279;\nL_00E0:\n\treturnVal4 = 0x16062A8(v277, subdivisionsXSegment, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn returnVal4;\n\tX8 = *([X8+B8]);\n\tX8 = *([X8]);\n\tC = X8 < 2;\n\tC = ~C;\n\tTEMP1 = X8 - 2;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 2;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_00C2;\n\tX8 = *([1EE95A8]);\n\tX1 = 0;\n\tX0 = *([X8]);\n\tDG.Tweening.Core.Debugger::LogWarning(X0, X1);\n\tgoto L_00C2;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 153 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector3[] PathGetDrawPoints(this Tween t, int subdivisionsXSegment = 10)
		{
			//IL_0087: Expected O, but got I
			//IL_0095: Expected I, but got O
			//IL_0102: Expected O, but got I
			//IL_0151: Expected O, but got I
			if (t != null)
			{
				if (t.active)
				{
					if (!t.isSequenced)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [2022000]");
						object obj = 0;
						IntPtr intPtr = (IntPtr)typeof(TweenerCore<Vector3, Path, PathOptions>);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ X9_v2+128]");
						IntPtr intPtr2 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ X8_v28 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>)+128]");
						if ((long)intPtr2 >= 0L)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ X8_v28 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>)+128]");
							int num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ X9_v2+C8]");
							object obj2 = 0L + (long)num;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ X9_v5-8]");
							if ((IntPtr)0 == (IntPtr)typeof(TweenerCore<Vector3, Path, PathOptions>))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [2022128]");
								Path path = (Path)0;
								if (path.isFinalized)
								{
									return Path.GetDrawPoints(path, subdivisionsXSegment);
								}
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @16062A8 (inside DG.Tweening.Tweener::.ctor +0x2C)");
								Vector3[] result = default(Vector3[]);
								return result;
							}
						}
						if (Debugger._logPriority >= 2)
						{
							Debugger.LogNonPathTween(t);
						}
					}
					else if (Debugger._logPriority >= 2)
					{
						Debugger.LogNestedTween(t);
					}
				}
				else if (Debugger._logPriority >= 2)
				{
					Debugger.LogInvalidTween(t);
				}
			}
			else if (Debugger._logPriority >= 2)
			{
				Debugger.LogNullTween(null);
			}
			return null;
		}

		[Token(Token = "0x600008C")]
		[Address(RVA = "0x1605034", Offset = "0x1605034", Length = "0x25C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EDB3C8]);\n\tv21 = *([v20 @ X8_v64]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, returnVal2, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A1CD]) = v40;\nL_0014:\n\tv41 = t == 0;\n\tif (v41) goto L_0041;\n\tv43 = ~t.<active>k__BackingField;\n\tif (v43) goto L_0062;\n\tv49 = ~t.isSequenced;\n\tif (v49) goto L_0081;\n\tgoto L_0037;\n\tv219 = *([1EC8838]);\n\tv220 = *([v219 @ X8_v60]);\n\tv221 = \"il2cpp_codegen_initialize_method\"(v220, methodInfo, v24, v25, v26, v27, v28, v29, returnVal2, v31, v32, v33, v34, v35, v36, v37);\n\tv223 = 0 | 1;\n\t*([2022B9B]) = v223;\nL_0037:\n\tv135 = v227._logPriority < 2;\n\tif (v135) goto L_00F0;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\tgoto L_00F0;\nL_0041:\n\tgoto L_0058;\n\tv55 = *([1EC8838]);\n\tv56 = *([v55 @ X8_v12]);\n\tv57 = \"il2cpp_codegen_initialize_method\"(v56, methodInfo, v24, v25, v26, v27, v28, v29, returnVal2, v31, v32, v33, v34, v35, v36, v37);\n\tv60 = 0 | 1;\n\t*([2022B9B]) = v60;\nL_0058:\n\tv77 = v65._logPriority < 2;\n\tif (v77) goto L_00F0;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\tgoto L_00F0;\nL_0062:\n\tgoto L_0079;\n\tv99 = *([1EC8838]);\n\tv100 = *([v99 @ X8_v23]);\n\tv101 = \"il2cpp_codegen_initialize_method\"(v100, methodInfo, v24, v25, v26, v27, v28, v29, returnVal2, v31, v32, v33, v34, v35, v36, v37);\n\tv104 = 0 | 1;\n\t*([2022B9B]) = v104;\nL_0079:\n\tv121 = v109._logPriority < 2;\n\tif (v121) goto L_00F0;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\tgoto L_00F0;\nL_0081:\n\tv84 = *([2022000]);\n\tv85 = DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>;\n\tv88 = *([v84 @ X9_v2+128]) < *([v85 @ X8_v28 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>)+128]);\n\tv89 = ~v88;\n\tv97 = ~v89;\n\tif (v97) goto L_00A2;\n\tv130 = *([v85 @ X8_v28 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>)+128]) << 3;\n\tv231 = *([v84 @ X9_v2+C8]) + v130;\n\tv161 = *([v231 @ X9_v5-8]) == DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>;\n\tif (v161) goto L_00BF;\nL_00A2:\n\tgoto L_00B9;\n\tv270 = *([1EC8838]);\n\tv271 = *([v270 @ X8_v37]);\n\tv272 = \"il2cpp_codegen_initialize_method\"(v271, methodInfo, v24, v25, v26, v27, v28, v29, returnVal2, v31, v32, v33, v34, v35, v36, v37);\n\tv274 = 0 | 1;\n\t*([2022B9B]) = v274;\nL_00B9:\n\tv136 = v278._logPriority < 2;\n\tif (v136) goto L_00F0;\n\tDG.Tweening.Core.Debugger::LogNonPathTween(t);\n\tgoto L_00F0;\nL_00BF:\n\tv208 = *([2022128]);\n\tv201 = *([v208 @ X8_v39+3C]) == 0;\n\tif (v201) goto L_00CB;\n\tv124 = *([v208 @ X8_v39+38]);\n\tgoto L_00F0;\nL_00CB:\n\tgoto L_00E2;\n\tv285 = *([1EC8838]);\n\tv286 = *([v285 @ X8_v50]);\n\tv287 = \"il2cpp_codegen_initialize_method\"(v286, methodInfo, v24, v25, v26, v27, v28, v29, returnVal2, v31, v32, v33, v34, v35, v36, v37);\n\tv289 = 0 | 1;\n\t*([2022B9B]) = v289;\nL_00E2:\n\tv134 = v293._logPriority < 2;\n\tif (v134) goto L_00F0;\n\tDG.Tweening.Core.Debugger::LogWarning(\"The path is not finalized yet\");\nL_00F0:\n\treturn v124;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 165 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float PathLength(this Tween t)
		{
			//IL_00a2: Expected O, but got I
			//IL_00b0: Expected I, but got O
			//IL_011d: Expected O, but got I
			//IL_0173: Expected O, but got I
			//IL_01ad: Expected F4, but got I
			float result;
			if (t != null)
			{
				if (t.active)
				{
					if (!t.isSequenced)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [2022000]");
						object obj = 0;
						IntPtr intPtr = (IntPtr)typeof(TweenerCore<Vector3, Path, PathOptions>);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ X9_v2+128]");
						IntPtr intPtr2 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ X8_v28 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>)+128]");
						if ((long)intPtr2 >= 0L)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ X8_v28 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>)+128]");
							int num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ X9_v2+C8]");
							object obj2 = 0L + (long)num;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ X9_v5-8]");
							if ((IntPtr)0 == (IntPtr)typeof(TweenerCore<Vector3, Path, PathOptions>))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [2022128]");
								object obj3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ X8_v39+3C]");
								if ((IntPtr)0 != (IntPtr)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ X8_v39+38]");
									result = 0f;
								}
								else
								{
									bool flag = Debugger._logPriority < 2;
									result = -1f;
									if (!flag)
									{
										Debugger.LogWarning("The path is not finalized yet");
										result = -1f;
									}
								}
								goto IL_01cf;
							}
						}
						bool flag2 = Debugger._logPriority < 2;
						result = -1f;
						if (!flag2)
						{
							Debugger.LogNonPathTween(t);
							result = -1f;
						}
					}
					else
					{
						bool flag3 = Debugger._logPriority < 2;
						result = -1f;
						if (!flag3)
						{
							Debugger.LogNestedTween(t);
							result = -1f;
						}
					}
				}
				else
				{
					bool flag4 = Debugger._logPriority < 2;
					result = -1f;
					if (!flag4)
					{
						Debugger.LogInvalidTween(t);
						result = -1f;
					}
				}
			}
			else
			{
				bool flag5 = Debugger._logPriority < 2;
				result = -1f;
				if (!flag5)
				{
					Debugger.LogNullTween(null);
					result = -1f;
				}
			}
			goto IL_01cf;
			IL_01cf:
			return result;
		}
	}
}
