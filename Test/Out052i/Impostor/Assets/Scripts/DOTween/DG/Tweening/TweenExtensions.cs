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
	[Token(Token = "0x200001C")]
	public static class TweenExtensions
	{
		[Token(Token = "0x6000099")]
		[Address(RVA = "0xC0B904", Offset = "0xC0B904", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tDG.Tweening.TweenExtensions::Complete(t, 0);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Complete(this Tween t)
		{
			t.Complete(withCallbacks: false);
		}

		[Token(Token = "0x600009A")]
		[Address(RVA = "0xC0B90C", Offset = "0xC0B90C", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = DG.Tweening.Core.TweenManager;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, withCallbacks, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A356C1]) = v36;\nL_0012:\n\tv37 = t == 0;\n\tif (v37) goto L_0042;\n\tv39 = ~t.<active>k__BackingField;\n\tif (v39) goto L_0066;\n\tv45 = ~t.isSequenced;\n\tif (v45) goto L_008E;\n\tgoto L_0033;\n\tv143 = DG.Tweening.Core.Debugger;\n\tv144 = \"il2cpp_codegen_initialize_runtime_metadata\"(v143, withCallbacks, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv146 = 1;\n\t*([1A35757]) = v146;\nL_0033:\n\tv114 = v150._logPriority < 2;\n\tif (v114) goto L_008B;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\treturn;\nL_0042:\n\tgoto L_0057;\n\tv51 = DG.Tweening.Core.Debugger;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, withCallbacks, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv55 = 1;\n\t*([1A35757]) = v55;\nL_0057:\n\tv71 = v59._logPriority < 2;\n\tif (v71) goto L_008B;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\treturn;\nL_0066:\n\tgoto L_007B;\n\tv86 = DG.Tweening.Core.Debugger;\n\tv87 = \"il2cpp_codegen_initialize_runtime_metadata\"(v86, withCallbacks, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv90 = 1;\n\t*([1A35757]) = v90;\nL_007B:\n\tv106 = v94._logPriority < 2;\n\tif (v106) goto L_008B;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\treturn;\nL_008B:\n\treturn;\nL_008E:\n\tv78 = ~withCallbacks;\n\tgoto L_00A0;\n\tv153 = \"il2cpp_codegen_runtime_class_init\"(v81, withCallbacks, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_00A0:\n\tv163 = DG.Tweening.Core.TweenManager::Complete(t, 1, v78);\n\treturn;\n// 118 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Complete(this Tween t, bool withCallbacks)
		{
			if (t != null)
			{
				if (t.active)
				{
					if (!t.isSequenced)
					{
						bool updateMode = !withCallbacks;
						bool flag = TweenManager.Complete(t, modifyActiveLists: true, updateMode ? UpdateMode.Goto : UpdateMode.Update);
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

		[Token(Token = "0x600009B")]
		[Address(RVA = "0xCAE640", Offset = "0xCAE640", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A35843]) = v33;\nL_0010:\n\tv34 = t == 0;\n\tif (v34) goto L_003B;\n\tv36 = *([t @ X0 (T)+E8]) == 0;\n\tif (v36) goto L_005A;\n\tv42 = *([t @ X0 (T)+E9]) == 0;\n\tif (v42) goto L_0076;\n\tgoto L_0031;\n\tv152 = DG.Tweening.Core.Debugger;\n\tv153 = \"il2cpp_codegen_initialize_runtime_metadata\"(v152, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv155 = 1;\n\t*([1A35757]) = v155;\nL_0031:\n\tv114 = v159._logPriority < 2;\n\tif (v114) goto L_0094;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\tgoto L_0094;\nL_003B:\n\tgoto L_0050;\n\tv48 = DG.Tweening.Core.Debugger;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv52 = 1;\n\t*([1A35757]) = v52;\nL_0050:\n\tv68 = v56._logPriority < 2;\n\tif (v68) goto L_0094;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\tgoto L_0094;\nL_005A:\n\tgoto L_006F;\n\tv86 = DG.Tweening.Core.Debugger;\n\tv87 = \"il2cpp_codegen_initialize_runtime_metadata\"(v86, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv90 = 1;\n\t*([1A35757]) = v90;\nL_006F:\n\tv106 = v94._logPriority < 2;\n\tif (v106) goto L_0094;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\tgoto L_0094;\nL_0076:\n\tv74 = *([t @ X0 (T)+A0]) < 0;\n\tv75 = ~v74;\n\tv78 = *([t @ X0 (T)+A0]) == 0;\n\tv83 = ~v78;\n\tv84 = v75 & v83;\n\tif (v84) goto L_0094;\n\tgoto L_008E;\n\tv166 = \"il2cpp_codegen_runtime_class_init\"(v164, methodInfo, v17, v18, v19, v20, v21, v22, v73, v24, v25, v26, v27, v28, v29, v30);\nL_008E:\n\tv137 = DG.Tweening.Core.TweenManager::Complete(t, 1, 1);\nL_0094:\n\treturn t;\n// 101 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T Done<T>(this T t) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E9]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+A0]");
						bool flag = (nint)0 < (nint)0;
						bool flag2 = !flag;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+A0]");
						bool flag3 = (nint)0 == 0;
						bool flag4 = !flag3;
						if (!(flag2 && flag4))
						{
							bool flag5 = TweenManager.Complete(t);
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
			return t;
		}

		[Token(Token = "0x600009C")]
		[Address(RVA = "0xC0BA88", Offset = "0xC0BA88", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A356C2]) = v33;\nL_0010:\n\tv34 = t == 0;\n\tif (v34) goto L_003F;\n\tv36 = ~t.<active>k__BackingField;\n\tif (v36) goto L_0062;\n\tv42 = ~t.isSequenced;\n\tif (v42) goto L_0083;\n\tgoto L_0031;\n\tv134 = DG.Tweening.Core.Debugger;\n\tv135 = \"il2cpp_codegen_initialize_runtime_metadata\"(v134, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv137 = 1;\n\t*([1A35757]) = v137;\nL_0031:\n\tv106 = v141._logPriority < 2;\n\tif (v106) goto L_007C;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\treturn;\nL_003F:\n\tgoto L_0054;\n\tv48 = DG.Tweening.Core.Debugger;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv52 = 1;\n\t*([1A35757]) = v52;\nL_0054:\n\tv68 = v56._logPriority < 2;\n\tif (v68) goto L_007C;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\treturn;\nL_0062:\n\tgoto L_0076;\n\tv80 = DG.Tweening.Core.Debugger;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv84 = 1;\n\t*([1A35757]) = v84;\nL_0076:\n\tv99 = v88._logPriority >= 2;\n\tif (v99) goto L_0093;\nL_007C:\n\treturn;\nL_0083:\n\tgoto L_008B;\n\tv144 = \"il2cpp_codegen_runtime_class_init\"(v75, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_008B:\n\tv151 = DG.Tweening.Core.TweenManager::Flip(t);\n\treturn;\nL_0093:\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\treturn;\n// 106 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x600009D")]
		[Address(RVA = "0xC0BBF0", Offset = "0xC0BBF0", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A356C3]) = v33;\nL_0010:\n\tv34 = t == 0;\n\tif (v34) goto L_003F;\n\tv36 = ~t.<active>k__BackingField;\n\tif (v36) goto L_0062;\n\tv42 = ~t.isSequenced;\n\tif (v42) goto L_0083;\n\tgoto L_0031;\n\tv134 = DG.Tweening.Core.Debugger;\n\tv135 = \"il2cpp_codegen_initialize_runtime_metadata\"(v134, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv137 = 1;\n\t*([1A35757]) = v137;\nL_0031:\n\tv106 = v141._logPriority < 2;\n\tif (v106) goto L_007C;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\treturn;\nL_003F:\n\tgoto L_0054;\n\tv48 = DG.Tweening.Core.Debugger;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv52 = 1;\n\t*([1A35757]) = v52;\nL_0054:\n\tv68 = v56._logPriority < 2;\n\tif (v68) goto L_007C;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\treturn;\nL_0062:\n\tgoto L_0076;\n\tv80 = DG.Tweening.Core.Debugger;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv84 = 1;\n\t*([1A35757]) = v84;\nL_0076:\n\tv99 = v88._logPriority >= 2;\n\tif (v99) goto L_0094;\nL_007C:\n\treturn;\nL_0083:\n\tgoto L_008C;\n\tv144 = \"il2cpp_codegen_runtime_class_init\"(v75, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_008C:\n\tDG.Tweening.Core.TweenManager::ForceInit(t, 0);\n\treturn;\nL_0094:\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\treturn;\n// 107 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x600009E")]
		[Address(RVA = "0xC0BD5C", Offset = "0xC0BD5C", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tDG.Tweening.TweenExtensions::DoGoto(t, to, andPlay, 0);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Goto(this Tween t, float to, bool andPlay = false)
		{
			DoGoto(t, to, andPlay, withCallbacks: false);
		}

		[Token(Token = "0x600009F")]
		[Address(RVA = "0xC0BF58", Offset = "0xC0BF58", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tDG.Tweening.TweenExtensions::DoGoto(t, to, andPlay, 1);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void GotoWithCallbacks(this Tween t, float to, bool andPlay = false)
		{
			DoGoto(t, to, andPlay, withCallbacks: true);
		}

		[Token(Token = "0x60000A0")]
		[Address(RVA = "0xC0BD68", Offset = "0xC0BD68", Length = "0x1F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv28 = DG.Tweening.Core.TweenManager;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, andPlay, withCallbacks, methodInfo, v31, v32, v33, v34, to, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 1;\n\t*([1A356C4]) = v44;\nL_0017:\n\tv45 = t == 0;\n\tif (v45) goto L_004A;\n\tv47 = ~t.<active>k__BackingField;\n\tif (v47) goto L_0071;\n\tv53 = ~t.isSequenced;\n\tif (v53) goto L_009F;\n\tgoto L_0038;\n\tv152 = DG.Tweening.Core.Debugger;\n\tv153 = \"il2cpp_codegen_initialize_runtime_metadata\"(v152, andPlay, withCallbacks, methodInfo, v31, v32, v33, v34, to, v35, v36, v37, v38, v39, v40, v41);\n\tv155 = 1;\n\t*([1A35757]) = v155;\nL_0038:\n\tv120 = v159._logPriority < 2;\n\tif (v120) goto L_009C;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\treturn;\nL_004A:\n\tgoto L_005F;\n\tv59 = DG.Tweening.Core.Debugger;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, andPlay, withCallbacks, methodInfo, v31, v32, v33, v34, to, v35, v36, v37, v38, v39, v40, v41);\n\tv63 = 1;\n\t*([1A35757]) = v63;\nL_005F:\n\tv79 = v67._logPriority < 2;\n\tif (v79) goto L_009C;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\treturn;\nL_0071:\n\tgoto L_0086;\n\tv89 = DG.Tweening.Core.Debugger;\n\tv90 = \"il2cpp_codegen_initialize_runtime_metadata\"(v89, andPlay, withCallbacks, methodInfo, v31, v32, v33, v34, to, v35, v36, v37, v38, v39, v40, v41);\n\tv93 = 1;\n\t*([1A35757]) = v93;\nL_0086:\n\tv109 = v97._logPriority < 2;\n\tif (v109) goto L_009C;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\treturn;\nL_009C:\n\treturn;\nL_009F:\n\tv86 = *([1A35101]) == 0;\n\tv87 = ~v86;\n\tif (v87) goto L_00B0;\n\tgoto L_00AD;\n\tv247 = \"il2cpp_codegen_runtime_class_init\"(v164, andPlay, withCallbacks, methodInfo, v31, v32, v33, v34, to, v35, v36, v37, v38, v39, v40, v41);\nL_00AD:\n\tDG.Tweening.Core.TweenManager::ForceInit(t, 0);\nL_00B0:\n\tv178 = ~withCallbacks;\n\tv180 = UnityEngine.Mathf::Max(to, 0f);\n\tgoto L_00C7;\n\tv252 = \"il2cpp_codegen_runtime_class_init\"(v250, v170, v168, methodInfo, v31, v32, v33, v34, to, v35, v36, v37, v38, v39, v40, v41);\nL_00C7:\n\tv227 = DG.Tweening.Core.TweenManager::Goto(t, v180, andPlay, v178);\n\treturn;\n// 150 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void DoGoto(Tween t, float to, bool andPlay, bool withCallbacks)
		{
			if (t != null)
			{
				if (t.active)
				{
					if (!t.isSequenced)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1A35101]");
						if ((nint)0 == 0)
						{
							TweenManager.ForceInit(t);
						}
						bool updateMode = !withCallbacks;
						float to2 = Mathf.Max(to, 0f);
						bool flag = TweenManager.Goto(t, to2, andPlay, updateMode ? UpdateMode.Goto : UpdateMode.Update);
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

		[Token(Token = "0x60000A1")]
		[Address(RVA = "0xC0BF64", Offset = "0xC0BF64", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = DG.Tweening.DOTween;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, complete, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv46 = DG.Tweening.Core.TweenManager;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, complete, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A356C5]) = v41;\nL_0018:\n\tv42 = DG.Tweening.DOTween;\n\tv44 = *([v42 @ X0_v2 (Il2CppClass<DG.Tweening.DOTween>)+E0]) == 0;\n\tif (v44) goto L_0022;\n\tv47 = t == 0;\n\tv48 = ~v47;\n\tif (v48) goto L_0026;\n\tgoto L_007E;\nL_0022:\n\tv53 = t == 0;\n\tif (v53) goto L_007E;\nL_0026:\n\tv56 = ~v54.initialized;\n\tif (v56) goto L_007E;\n\tv99 = ~t.<active>k__BackingField;\n\tif (v99) goto L_007E;\n\tv153 = ~t.isSequenced;\n\tif (v153) goto L_0054;\n\tgoto L_0047;\n\tv159 = DG.Tweening.Core.Debugger;\n\tv160 = \"il2cpp_codegen_initialize_runtime_metadata\"(v159, complete, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv162 = 1;\n\t*([1A35757]) = v162;\nL_0047:\n\tv59 = v166._logPriority < 2;\n\tif (v59) goto L_007E;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\treturn;\nL_0054:\n\tv157 = complete == 0;\n\tif (v157) goto L_0070;\n\tgoto L_0062;\n\tv185 = \"il2cpp_codegen_runtime_class_init\"(v171, complete, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0062:\n\tv95 = DG.Tweening.Core.TweenManager::Complete(t, 1, 1);\n\tv177 = ~t.autoKill;\n\tif (v177) goto L_0070;\n\tv192 = t.loops & 0x80000000;\n\tv100 = v192 == 0;\n\tif (v100) goto L_007E;\nL_0070:\n\tgoto L_0075;\n\tv188 = \"il2cpp_codegen_runtime_class_init\"(v181, v91, v88, v85, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv189 = DG.Tweening.Core.TweenManager;\nL_0075:\n\tv98 = ~v190.isUpdateLoop;\n\tif (v98) goto L_0082;\n\tt.<active>k__BackingField = 0;\nL_007E:\n\treturn;\nL_0082:\n\tgoto L_008D;\n\tv193 = \"il2cpp_codegen_runtime_class_init\"(v94, v91, v88, v85, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_008D:\n\tDG.Tweening.Core.TweenManager::Despawn(t, 1);\n\treturn;\n// 91 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Kill(this Tween t, bool complete = false)
		{
			//IL_0179: Expected I, but got O
			//IL_0122: Expected I4, but got I8
			nint num = (nint)typeof(DOTween);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X0_v2 (Il2CppClass<DG.Tweening.DOTween>)+E0]");
			if ((nint)0 != 0)
			{
				if (t == null)
				{
					return;
				}
			}
			else if (t == null)
			{
				return;
			}
			if (!DOTween.initialized || !t.active)
			{
				return;
			}
			if (!t.isSequenced)
			{
				if (complete)
				{
					bool flag = TweenManager.Complete(t);
					if (t.autoKill && (int)(t.loops & 0x80000000L) == 0)
					{
						return;
					}
				}
				if (TweenManager.isUpdateLoop)
				{
					t.active = false;
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

		[Token(Token = "0x60000A2")]
		[Address(RVA = "0xC0C0E0", Offset = "0xC0C0E0", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv22 = DG.Tweening.Core.TweenManager;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, deltaTime, unscaledDeltaTime, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A356C6]) = v39;\nL_0014:\n\tv40 = t == 0;\n\tif (v40) goto L_0045;\n\tv42 = ~t.<active>k__BackingField;\n\tif (v42) goto L_006A;\n\tv48 = ~t.isSequenced;\n\tif (v48) goto L_008D;\n\tgoto L_0035;\n\tv144 = DG.Tweening.Core.Debugger;\n\tv145 = \"il2cpp_codegen_initialize_runtime_metadata\"(v144, methodInfo, v25, v26, v27, v28, v29, v30, deltaTime, unscaledDeltaTime, v31, v32, v33, v34, v35, v36);\n\tv147 = 1;\n\t*([1A35757]) = v147;\nL_0035:\n\tv114 = v151._logPriority < 2;\n\tif (v114) goto L_0086;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\treturn;\nL_0045:\n\tgoto L_005A;\n\tv54 = DG.Tweening.Core.Debugger;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v25, v26, v27, v28, v29, v30, deltaTime, unscaledDeltaTime, v31, v32, v33, v34, v35, v36);\n\tv58 = 1;\n\t*([1A35757]) = v58;\nL_005A:\n\tv74 = v62._logPriority < 2;\n\tif (v74) goto L_0086;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\treturn;\nL_006A:\n\tgoto L_007E;\n\tv86 = DG.Tweening.Core.Debugger;\n\tv87 = \"il2cpp_codegen_initialize_runtime_metadata\"(v86, methodInfo, v25, v26, v27, v28, v29, v30, deltaTime, unscaledDeltaTime, v31, v32, v33, v34, v35, v36);\n\tv90 = 1;\n\t*([1A35757]) = v90;\nL_007E:\n\tv105 = v94._logPriority >= 2;\n\tif (v105) goto L_00A4;\nL_0086:\n\treturn;\nL_008D:\n\tgoto L_009A;\n\tv154 = \"il2cpp_codegen_runtime_class_init\"(v81, methodInfo, v25, v26, v27, v28, v29, v30, deltaTime, unscaledDeltaTime, v31, v32, v33, v34, v35, v36);\nL_009A:\n\tv166 = DG.Tweening.Core.TweenManager::Update(t, deltaTime, unscaledDeltaTime, 1);\n\treturn;\nL_00A4:\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\treturn;\n// 123 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ManualUpdate(this Tween t, float deltaTime, float unscaledDeltaTime)
		{
			if (t != null)
			{
				if (t.active)
				{
					if (!t.isSequenced)
					{
						bool flag = TweenManager.Update(t, deltaTime, unscaledDeltaTime, isSingleTweenManualUpdate: true);
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

		[Token(Token = "0x60000A3")]
		[Address(RVA = "0xCAE7AC", Offset = "0xCAE7AC", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A35844]) = v33;\nL_0010:\n\tv34 = t == 0;\n\tif (v34) goto L_003B;\n\tv36 = *([t @ X0 (T)+E8]) == 0;\n\tif (v36) goto L_005A;\n\tv42 = *([t @ X0 (T)+E9]) == 0;\n\tif (v42) goto L_007B;\n\tgoto L_0031;\n\tv148 = DG.Tweening.Core.Debugger;\n\tv149 = \"il2cpp_codegen_initialize_runtime_metadata\"(v148, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv151 = 1;\n\t*([1A35757]) = v151;\nL_0031:\n\tv105 = v155._logPriority < 2;\n\tif (v105) goto L_0085;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\tgoto L_0085;\nL_003B:\n\tgoto L_0050;\n\tv48 = DG.Tweening.Core.Debugger;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv52 = 1;\n\t*([1A35757]) = v52;\nL_0050:\n\tv68 = v56._logPriority < 2;\n\tif (v68) goto L_0085;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\tgoto L_0085;\nL_005A:\n\tgoto L_006F;\n\tv80 = DG.Tweening.Core.Debugger;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv84 = 1;\n\t*([1A35757]) = v84;\nL_006F:\n\tv100 = v88._logPriority < 2;\n\tif (v100) goto L_0085;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\tgoto L_0085;\nL_007B:\n\tgoto L_007F;\n\tv158 = \"il2cpp_codegen_runtime_class_init\"(v75, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_007F:\n\tv135 = DG.Tweening.Core.TweenManager::Pause(t);\nL_0085:\n\treturn t;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T Pause<T>(this T t) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E9]");
					if ((nint)0 == 0)
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

		[Token(Token = "0x60000A4")]
		[Address(RVA = "0xCAE904", Offset = "0xCAE904", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A35845]) = v33;\nL_0010:\n\tv34 = t == 0;\n\tif (v34) goto L_003B;\n\tv36 = *([t @ X0 (T)+E8]) == 0;\n\tif (v36) goto L_005A;\n\tv42 = *([t @ X0 (T)+E9]) == 0;\n\tif (v42) goto L_007B;\n\tgoto L_0031;\n\tv148 = DG.Tweening.Core.Debugger;\n\tv149 = \"il2cpp_codegen_initialize_runtime_metadata\"(v148, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv151 = 1;\n\t*([1A35757]) = v151;\nL_0031:\n\tv105 = v155._logPriority < 2;\n\tif (v105) goto L_0085;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\tgoto L_0085;\nL_003B:\n\tgoto L_0050;\n\tv48 = DG.Tweening.Core.Debugger;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv52 = 1;\n\t*([1A35757]) = v52;\nL_0050:\n\tv68 = v56._logPriority < 2;\n\tif (v68) goto L_0085;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\tgoto L_0085;\nL_005A:\n\tgoto L_006F;\n\tv80 = DG.Tweening.Core.Debugger;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv84 = 1;\n\t*([1A35757]) = v84;\nL_006F:\n\tv100 = v88._logPriority < 2;\n\tif (v100) goto L_0085;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\tgoto L_0085;\nL_007B:\n\tgoto L_007F;\n\tv158 = \"il2cpp_codegen_runtime_class_init\"(v75, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_007F:\n\tv135 = DG.Tweening.Core.TweenManager::Play(t);\nL_0085:\n\treturn t;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T Play<T>(this T t) where T : Tween
		{
			if (t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (T)+E9]");
					if ((nint)0 == 0)
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

		[Token(Token = "0x60000A5")]
		[Address(RVA = "0xC0C274", Offset = "0xC0C274", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A356C7]) = v33;\nL_0010:\n\tv34 = t == 0;\n\tif (v34) goto L_003F;\n\tv36 = ~t.<active>k__BackingField;\n\tif (v36) goto L_0062;\n\tv42 = ~t.isSequenced;\n\tif (v42) goto L_0083;\n\tgoto L_0031;\n\tv134 = DG.Tweening.Core.Debugger;\n\tv135 = \"il2cpp_codegen_initialize_runtime_metadata\"(v134, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv137 = 1;\n\t*([1A35757]) = v137;\nL_0031:\n\tv106 = v141._logPriority < 2;\n\tif (v106) goto L_007C;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\treturn;\nL_003F:\n\tgoto L_0054;\n\tv48 = DG.Tweening.Core.Debugger;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv52 = 1;\n\t*([1A35757]) = v52;\nL_0054:\n\tv68 = v56._logPriority < 2;\n\tif (v68) goto L_007C;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\treturn;\nL_0062:\n\tgoto L_0076;\n\tv80 = DG.Tweening.Core.Debugger;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv84 = 1;\n\t*([1A35757]) = v84;\nL_0076:\n\tv99 = v88._logPriority >= 2;\n\tif (v99) goto L_0093;\nL_007C:\n\treturn;\nL_0083:\n\tgoto L_008B;\n\tv144 = \"il2cpp_codegen_runtime_class_init\"(v75, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_008B:\n\tv151 = DG.Tweening.Core.TweenManager::PlayBackwards(t);\n\treturn;\nL_0093:\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\treturn;\n// 106 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000A6")]
		[Address(RVA = "0xC0C3DC", Offset = "0xC0C3DC", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A356C8]) = v33;\nL_0010:\n\tv34 = t == 0;\n\tif (v34) goto L_003F;\n\tv36 = ~t.<active>k__BackingField;\n\tif (v36) goto L_0062;\n\tv42 = ~t.isSequenced;\n\tif (v42) goto L_0083;\n\tgoto L_0031;\n\tv134 = DG.Tweening.Core.Debugger;\n\tv135 = \"il2cpp_codegen_initialize_runtime_metadata\"(v134, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv137 = 1;\n\t*([1A35757]) = v137;\nL_0031:\n\tv106 = v141._logPriority < 2;\n\tif (v106) goto L_007C;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\treturn;\nL_003F:\n\tgoto L_0054;\n\tv48 = DG.Tweening.Core.Debugger;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv52 = 1;\n\t*([1A35757]) = v52;\nL_0054:\n\tv68 = v56._logPriority < 2;\n\tif (v68) goto L_007C;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\treturn;\nL_0062:\n\tgoto L_0076;\n\tv80 = DG.Tweening.Core.Debugger;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv84 = 1;\n\t*([1A35757]) = v84;\nL_0076:\n\tv99 = v88._logPriority >= 2;\n\tif (v99) goto L_0093;\nL_007C:\n\treturn;\nL_0083:\n\tgoto L_008B;\n\tv144 = \"il2cpp_codegen_runtime_class_init\"(v75, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_008B:\n\tv151 = DG.Tweening.Core.TweenManager::PlayForward(t);\n\treturn;\nL_0093:\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\treturn;\n// 106 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000A7")]
		[Address(RVA = "0xC0C544", Offset = "0xC0C544", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv22 = DG.Tweening.Core.TweenManager;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, includeDelay, methodInfo, v25, v26, v27, v28, v29, changeDelayTo, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A356C9]) = v39;\nL_0014:\n\tv40 = t == 0;\n\tif (v40) goto L_0045;\n\tv42 = ~t.<active>k__BackingField;\n\tif (v42) goto L_006A;\n\tv48 = ~t.isSequenced;\n\tif (v48) goto L_008D;\n\tgoto L_0035;\n\tv144 = DG.Tweening.Core.Debugger;\n\tv145 = \"il2cpp_codegen_initialize_runtime_metadata\"(v144, includeDelay, methodInfo, v25, v26, v27, v28, v29, changeDelayTo, v30, v31, v32, v33, v34, v35, v36);\n\tv147 = 1;\n\t*([1A35757]) = v147;\nL_0035:\n\tv114 = v151._logPriority < 2;\n\tif (v114) goto L_0086;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\treturn;\nL_0045:\n\tgoto L_005A;\n\tv54 = DG.Tweening.Core.Debugger;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, includeDelay, methodInfo, v25, v26, v27, v28, v29, changeDelayTo, v30, v31, v32, v33, v34, v35, v36);\n\tv58 = 1;\n\t*([1A35757]) = v58;\nL_005A:\n\tv74 = v62._logPriority < 2;\n\tif (v74) goto L_0086;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\treturn;\nL_006A:\n\tgoto L_007E;\n\tv86 = DG.Tweening.Core.Debugger;\n\tv87 = \"il2cpp_codegen_initialize_runtime_metadata\"(v86, includeDelay, methodInfo, v25, v26, v27, v28, v29, changeDelayTo, v30, v31, v32, v33, v34, v35, v36);\n\tv90 = 1;\n\t*([1A35757]) = v90;\nL_007E:\n\tv105 = v94._logPriority >= 2;\n\tif (v105) goto L_00A3;\nL_0086:\n\treturn;\nL_008D:\n\tgoto L_0099;\n\tv154 = \"il2cpp_codegen_runtime_class_init\"(v81, includeDelay, methodInfo, v25, v26, v27, v28, v29, changeDelayTo, v30, v31, v32, v33, v34, v35, v36);\nL_0099:\n\tv165 = DG.Tweening.Core.TweenManager::Restart(t, includeDelay, changeDelayTo);\n\treturn;\nL_00A3:\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\treturn;\n// 122 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000A8")]
		[Address(RVA = "0xC0C6D4", Offset = "0xC0C6D4", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = DG.Tweening.Core.TweenManager;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, includeDelay, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A356CA]) = v36;\nL_0012:\n\tv37 = t == 0;\n\tif (v37) goto L_0042;\n\tv39 = ~t.<active>k__BackingField;\n\tif (v39) goto L_0066;\n\tv45 = ~t.isSequenced;\n\tif (v45) goto L_0088;\n\tgoto L_0033;\n\tv139 = DG.Tweening.Core.Debugger;\n\tv140 = \"il2cpp_codegen_initialize_runtime_metadata\"(v139, includeDelay, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv142 = 1;\n\t*([1A35757]) = v142;\nL_0033:\n\tv110 = v146._logPriority < 2;\n\tif (v110) goto L_0081;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\treturn;\nL_0042:\n\tgoto L_0057;\n\tv51 = DG.Tweening.Core.Debugger;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, includeDelay, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv55 = 1;\n\t*([1A35757]) = v55;\nL_0057:\n\tv71 = v59._logPriority < 2;\n\tif (v71) goto L_0081;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\treturn;\nL_0066:\n\tgoto L_007A;\n\tv83 = DG.Tweening.Core.Debugger;\n\tv84 = \"il2cpp_codegen_initialize_runtime_metadata\"(v83, includeDelay, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv87 = 1;\n\t*([1A35757]) = v87;\nL_007A:\n\tv102 = v91._logPriority >= 2;\n\tif (v102) goto L_009B;\nL_0081:\n\treturn;\nL_0088:\n\tgoto L_0092;\n\tv149 = \"il2cpp_codegen_runtime_class_init\"(v78, includeDelay, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0092:\n\tv158 = DG.Tweening.Core.TweenManager::Rewind(t, includeDelay);\n\treturn;\nL_009B:\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\treturn;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000A9")]
		[Address(RVA = "0xC0C844", Offset = "0xC0C844", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A356CB]) = v33;\nL_0010:\n\tv34 = t == 0;\n\tif (v34) goto L_003F;\n\tv36 = ~t.<active>k__BackingField;\n\tif (v36) goto L_0062;\n\tv42 = ~t.isSequenced;\n\tif (v42) goto L_0083;\n\tgoto L_0031;\n\tv134 = DG.Tweening.Core.Debugger;\n\tv135 = \"il2cpp_codegen_initialize_runtime_metadata\"(v134, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv137 = 1;\n\t*([1A35757]) = v137;\nL_0031:\n\tv106 = v141._logPriority < 2;\n\tif (v106) goto L_007C;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\treturn;\nL_003F:\n\tgoto L_0054;\n\tv48 = DG.Tweening.Core.Debugger;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv52 = 1;\n\t*([1A35757]) = v52;\nL_0054:\n\tv68 = v56._logPriority < 2;\n\tif (v68) goto L_007C;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\treturn;\nL_0062:\n\tgoto L_0076;\n\tv80 = DG.Tweening.Core.Debugger;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv84 = 1;\n\t*([1A35757]) = v84;\nL_0076:\n\tv99 = v88._logPriority >= 2;\n\tif (v99) goto L_0093;\nL_007C:\n\treturn;\nL_0083:\n\tgoto L_008B;\n\tv144 = \"il2cpp_codegen_runtime_class_init\"(v75, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_008B:\n\tv151 = DG.Tweening.Core.TweenManager::SmoothRewind(t);\n\treturn;\nL_0093:\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\treturn;\n// 106 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000AA")]
		[Address(RVA = "0xC0C9AC", Offset = "0xC0C9AC", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A356CC]) = v33;\nL_0010:\n\tv34 = t == 0;\n\tif (v34) goto L_003F;\n\tv36 = ~t.<active>k__BackingField;\n\tif (v36) goto L_0062;\n\tv42 = ~t.isSequenced;\n\tif (v42) goto L_0083;\n\tgoto L_0031;\n\tv134 = DG.Tweening.Core.Debugger;\n\tv135 = \"il2cpp_codegen_initialize_runtime_metadata\"(v134, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv137 = 1;\n\t*([1A35757]) = v137;\nL_0031:\n\tv106 = v141._logPriority < 2;\n\tif (v106) goto L_007C;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\treturn;\nL_003F:\n\tgoto L_0054;\n\tv48 = DG.Tweening.Core.Debugger;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv52 = 1;\n\t*([1A35757]) = v52;\nL_0054:\n\tv68 = v56._logPriority < 2;\n\tif (v68) goto L_007C;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\treturn;\nL_0062:\n\tgoto L_0076;\n\tv80 = DG.Tweening.Core.Debugger;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv84 = 1;\n\t*([1A35757]) = v84;\nL_0076:\n\tv99 = v88._logPriority >= 2;\n\tif (v99) goto L_0093;\nL_007C:\n\treturn;\nL_0083:\n\tgoto L_008B;\n\tv144 = \"il2cpp_codegen_runtime_class_init\"(v75, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_008B:\n\tv151 = DG.Tweening.Core.TweenManager::TogglePause(t);\n\treturn;\nL_0093:\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\treturn;\n// 106 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000AB")]
		[Address(RVA = "0xC0CB14", Offset = "0xC0CB14", Length = "0x378")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = DG.Tweening.Core.TweenManager;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, waypointIndex, andPlay, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv45 = DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, waypointIndex, andPlay, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A356CD]) = v42;\nL_0018:\n\tv43 = t == 0;\n\tif (v43) goto L_004A;\n\tv47 = ~t.<active>k__BackingField;\n\tif (v47) goto L_0070;\n\tv53 = ~t.isSequenced;\n\tif (v53) goto L_0094;\n\tgoto L_0039;\n\tv185 = DG.Tweening.Core.Debugger;\n\tv186 = \"il2cpp_codegen_initialize_runtime_metadata\"(v185, waypointIndex, andPlay, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv188 = 1;\n\t*([1A35757]) = v188;\nL_0039:\n\tv134 = v192._logPriority < 2;\n\tif (v134) goto L_00DE;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\treturn;\nL_004A:\n\tgoto L_005F;\n\tv59 = DG.Tweening.Core.Debugger;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, waypointIndex, andPlay, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv63 = 1;\n\t*([1A35757]) = v63;\nL_005F:\n\tv79 = v67._logPriority < 2;\n\tif (v79) goto L_00DE;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\treturn;\nL_0070:\n\tgoto L_0085;\n\tv101 = DG.Tweening.Core.Debugger;\n\tv102 = \"il2cpp_codegen_initialize_runtime_metadata\"(v101, waypointIndex, andPlay, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv105 = 1;\n\t*([1A35757]) = v105;\nL_0085:\n\tv121 = v109._logPriority < 2;\n\tif (v121) goto L_00DE;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\treturn;\nL_0094:\n\tv86 = *([1A35000]);\n\tv87 = DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>;\n\tv90 = *([v86 @ X9_v2+130]) < *([v87 @ X8_v24 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>)+130]);\n\tv91 = ~v90;\n\tv99 = ~v91;\n\tif (v99) goto L_00B5;\n\tv196 = *([v87 @ X8_v24 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>)+130]) << 3;\n\tv197 = *([v86 @ X9_v2+C8]) + v196;\n\tv203 = *([v197 @ X9_v5-8]) == DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>;\n\tif (v203) goto L_00E0;\nL_00B5:\n\tgoto L_00CA;\n\tv334 = DG.Tweening.Core.Debugger;\n\tv335 = \"il2cpp_codegen_initialize_runtime_metadata\"(v334, waypointIndex, andPlay, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv337 = 1;\n\t*([1A35757]) = v337;\nL_00CA:\n\tv135 = v341._logPriority < 2;\n\tif (v135) goto L_00DE;\n\tDG.Tweening.Core.Debugger::LogNonPathTween(t);\n\treturn;\nL_00DE:\n\treturn;\nL_00E0:\n\tv331 = *([1A35101]) == 0;\n\tv332 = ~v331;\n\tif (v332) goto L_00EF;\n\tgoto L_00EE;\n\tv359 = \"il2cpp_codegen_runtime_class_init\"(v346, waypointIndex, andPlay, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00EE:\n\tDG.Tweening.Core.TweenManager::ForceInit(t, 0);\nL_00EF:\n\tv325 = *([1A35138]);\n\tv356 = waypointIndex & 0x80000000;\n\tv357 = v356 == 0;\n\tv358 = ~v357;\n\tif (v358) goto L_FFFFFFFF;\n\tv363 = *([v325 @ X8_v35+18]);\n\tv449 = *([v363 @ X9_v19+18]) - 1;\n\tv407 = v449 - waypointIndex;\n\tv408 = v407 < 0;\n\tv410 = v449 ^ waypointIndex;\n\tv411 = v449 ^ v407;\n\tv412 = v410 & v411;\n\tv413 = v412 < 0;\n\tv414 = v408 == v413;\n\tv415 = ~v414;\n\tv416 = ~v415;\n\tif (v416) goto L_FFFFFFFF;\n\tgoto L_010C;\nL_010C:\n\tv445 = v449 + 1;\n\tv428 = v445 >= 1;\n\tif (v428) goto L_011D;\n\tgoto L_011D;\nL_011D:\n\tv451 = v445 == 0;\n\tif (v451) goto L_FFFFFFFF;\n\tv370 = *([v325 @ X8_v35+10]) + 0x20;\nL_0132:\n\tv398 = v398 + 1;\n\tv472 = v472 + *([v370 @ X12_v2+v398 @ X9_v15 (System.Int32)*4]);\n\tv460 = v445 != v398;\n\tif (v460) goto L_0132;\n\tgoto L_0143;\nL_0143:\n\tv487 = *([1A350A4]) + 1;\n\tv489 = v487 == 0;\n\tv531 = v472 / *([v325 @ X8_v35+38]);\n\tif (v489) goto L_0160;\n\tv504 = *([1A350A4]) < 2;\n\tif (v504) goto L_0188;\nL_0160:\n\tv524 = *([1A350A8]) != 1;\n\tif (v524) goto L_0188;\n\tv561 = 0f - 0f;\n\tv562 = v561 < 0;\n\tv568 = *([1A3510C]) & 1;\n\tv547 = v562 ^ v568;\n\tv530 = 1f - v531;\n\tv540 = v547 == 0;\n\tv535 = ~v540;\n\tv534 = ~v535;\n\tif (v534) goto L_FFFFFFFF;\n\tgoto L_0188;\nL_0188:\n\tv551 = *([1A35111]) & 1;\n\tv324 = *([1A3510C]) - v551;\n\tv231 = 0f * v324;\n\tv554 = v531 * 0f;\n\tv555 = v554 + v231;\n\tgoto L_01A0;\n\tv570 = \"il2cpp_codegen_runtime_class_init\"(v552, v298, v252, methodInfo, v27, v28, v29, v30, v554, v233, v231, v229, v35, v36, v37, v38);\nL_01A0:\n\tv306 = DG.Tweening.Core.TweenManager::Goto(t, v555, andPlay, 1);\n\treturn;\n\tv401 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 295 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void GotoWaypoint(this Tween t, int waypointIndex, bool andPlay = false)
		{
			//IL_007b: Expected O, but got I
			//IL_0089: Expected I, but got O
			//IL_00f6: Expected O, but got I
			//IL_0188: Expected O, but got I
			//IL_019a: Expected I4, but got I8
			//IL_01d2: Expected O, but got I
			//IL_0519: Expected O, but got I
			//IL_02b5: Expected O, but got I
			//IL_0579: Expected O, but got I
			float num14;
			if (t != null)
			{
				if (t.active)
				{
					if (!t.isSequenced)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1A35000]");
						object obj = 0;
						nint num = (nint)typeof(TweenerCore<Vector3, Path, PathOptions>);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ X9_v2+130]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ X8_v24 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>)+130]");
						if (num2 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ X8_v24 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>)+130]");
							int num3 = (int)((nint)0 << 3);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ X9_v2+C8]");
							object obj2 = (nint)0 + (nint)num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ X9_v5-8]");
							if (0 == (nint)typeof(TweenerCore<Vector3, Path, PathOptions>))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1A35101]");
								if ((nint)0 == 0)
								{
									TweenManager.ForceInit(t);
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1A35138]");
								object obj3 = 0;
								int num9;
								if ((int)(waypointIndex & 0x80000000L) == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ X8_v35+18]");
									object obj4 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ X9_v19+18]");
									int num4 = (int)(-1);
									int num5 = num4 - waypointIndex;
									bool flag = num5 < 0;
									int num6 = num4 ^ waypointIndex;
									int num7 = num4 ^ num5;
									int num8 = num6 & num7;
									bool flag2 = num8 < 0;
									if (flag == flag2)
									{
										num4 = waypointIndex;
									}
									num9 = num4 + 1;
									if (num9 < 1)
									{
										num9 = 0;
									}
								}
								else
								{
									num9 = 1;
								}
								int num10;
								if (num9 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ X8_v35+10]");
									object obj5 = (nint)0 + (nint)32;
									num10 = 0;
									int num11 = 0;
									do
									{
										num11++;
										int num12 = num10;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ X12_v2+v398 @ X9_v15 (System.Int32)*4]");
										num10 = (int)((nint)num12 + (nint)0);
									}
									while (num9 != num11);
								}
								else
								{
									num10 = 0;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1A350A4]");
								object obj6 = (nint)0 + (nint)1;
								bool flag3 = obj6 == null;
								float num13 = num10;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ X8_v35+38]");
								num14 = num13 / 0f;
								if (!flag3)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1A350A4]");
									if ((nint)0 < (nint)2)
									{
										goto IL_054e;
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1A350A8]");
								if ((nint)0 == 1)
								{
									float num15 = 0f - 0f;
									bool flag4 = num15 < 0f;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1A3510C]");
									int num16 = (int)((nint)0 & (nint)1);
									int num17 = (flag4 ? 1 : 0) ^ num16;
									float num18 = 1f - num14;
									if (num17 == 0)
									{
										num14 = num18;
									}
								}
								goto IL_054e;
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
			return;
			IL_054e:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1A35111]");
			int num19 = (int)((nint)0 & (nint)1);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1A3510C]");
			object obj7 = -num19;
			float num20 = 0f * (float)obj7;
			float num21 = num14 * 0f;
			float to = num21 + num20;
			bool flag5 = TweenManager.Goto(t, to, andPlay);
		}

		[Token(Token = "0x60000AC")]
		[Address(RVA = "0xC0CEA8", Offset = "0xC0CEA8", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv14 = DG.Tweening.DOTween;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A356CE]) = v33;\nL_0013:\n\tv36 = ~t.<active>k__BackingField;\n\tif (v36) goto L_0033;\n\tgoto L_0025;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv57 = DG.Tweening.DOTween;\nL_0025:\n\tv120 = DG.Tweening.Core.DOTweenComponent::WaitForCompletion(v42.instance, t);\n\treturnVal3 = UnityEngine.MonoBehaviour::StartCoroutine(v42.instance, v120);\n\treturn returnVal3;\nL_0033:\n\tgoto L_0048;\n\tv59 = DG.Tweening.Core.Debugger;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv63 = 1;\n\t*([1A35757]) = v63;\nL_0048:\n\tv79 = v67._logPriority < 1;\n\tif (v79) goto L_0052;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_0052:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000AD")]
		[Address(RVA = "0xC0CF8C", Offset = "0xC0CF8C", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv14 = DG.Tweening.DOTween;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A356CF]) = v33;\nL_0013:\n\tv36 = ~t.<active>k__BackingField;\n\tif (v36) goto L_0033;\n\tgoto L_0025;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv57 = DG.Tweening.DOTween;\nL_0025:\n\tv120 = DG.Tweening.Core.DOTweenComponent::WaitForRewind(v42.instance, t);\n\treturnVal3 = UnityEngine.MonoBehaviour::StartCoroutine(v42.instance, v120);\n\treturn returnVal3;\nL_0033:\n\tgoto L_0048;\n\tv59 = DG.Tweening.Core.Debugger;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv63 = 1;\n\t*([1A35757]) = v63;\nL_0048:\n\tv79 = v67._logPriority < 1;\n\tif (v79) goto L_0052;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_0052:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000AE")]
		[Address(RVA = "0xC0D070", Offset = "0xC0D070", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv14 = DG.Tweening.DOTween;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A356D0]) = v33;\nL_0013:\n\tv36 = ~t.<active>k__BackingField;\n\tif (v36) goto L_0033;\n\tgoto L_0025;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv57 = DG.Tweening.DOTween;\nL_0025:\n\tv120 = DG.Tweening.Core.DOTweenComponent::WaitForKill(v42.instance, t);\n\treturnVal3 = UnityEngine.MonoBehaviour::StartCoroutine(v42.instance, v120);\n\treturn returnVal3;\nL_0033:\n\tgoto L_0048;\n\tv59 = DG.Tweening.Core.Debugger;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv63 = 1;\n\t*([1A35757]) = v63;\nL_0048:\n\tv79 = v67._logPriority < 1;\n\tif (v79) goto L_0052;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_0052:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000AF")]
		[Address(RVA = "0xC0D154", Offset = "0xC0D154", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = DG.Tweening.DOTween;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, elapsedLoops, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A356D1]) = v36;\nL_0015:\n\tv39 = ~t.<active>k__BackingField;\n\tif (v39) goto L_0037;\n\tgoto L_0028;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v51, elapsedLoops, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv60 = DG.Tweening.DOTween;\nL_0028:\n\tv128 = DG.Tweening.Core.DOTweenComponent::WaitForElapsedLoops(v45.instance, t, elapsedLoops);\n\treturnVal3 = UnityEngine.MonoBehaviour::StartCoroutine(v45.instance, v128);\n\treturn returnVal3;\nL_0037:\n\tgoto L_004C;\n\tv62 = DG.Tweening.Core.Debugger;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, elapsedLoops, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv66 = 1;\n\t*([1A35757]) = v66;\nL_004C:\n\tv82 = v70._logPriority < 1;\n\tif (v82) goto L_0057;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_0057:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000B0")]
		[Address(RVA = "0xC0D240", Offset = "0xC0D240", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = DG.Tweening.DOTween;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, position, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A356D2]) = v36;\nL_0015:\n\tv39 = ~t.<active>k__BackingField;\n\tif (v39) goto L_0037;\n\tgoto L_0028;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v51, methodInfo, v21, v22, v23, v24, v25, v26, position, v27, v28, v29, v30, v31, v32, v33);\n\tv60 = DG.Tweening.DOTween;\nL_0028:\n\tv128 = DG.Tweening.Core.DOTweenComponent::WaitForPosition(v45.instance, t, position);\n\treturnVal3 = UnityEngine.MonoBehaviour::StartCoroutine(v45.instance, v128);\n\treturn returnVal3;\nL_0037:\n\tgoto L_004C;\n\tv62 = DG.Tweening.Core.Debugger;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, methodInfo, v21, v22, v23, v24, v25, v26, position, v27, v28, v29, v30, v31, v32, v33);\n\tv66 = 1;\n\t*([1A35757]) = v66;\nL_004C:\n\tv82 = v70._logPriority < 1;\n\tif (v82) goto L_0057;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_0057:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000B1")]
		[Address(RVA = "0xC0D338", Offset = "0xC0D338", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv14 = DG.Tweening.DOTween;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A356D3]) = v33;\nL_0013:\n\tv36 = ~t.<active>k__BackingField;\n\tif (v36) goto L_0033;\n\tgoto L_0025;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv57 = DG.Tweening.DOTween;\nL_0025:\n\tv120 = DG.Tweening.Core.DOTweenComponent::WaitForStart(v42.instance, t);\n\treturnVal3 = UnityEngine.MonoBehaviour::StartCoroutine(v42.instance, v120);\n\treturn returnVal3;\nL_0033:\n\tgoto L_0048;\n\tv59 = DG.Tweening.Core.Debugger;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv63 = 1;\n\t*([1A35757]) = v63;\nL_0048:\n\tv79 = v67._logPriority < 1;\n\tif (v79) goto L_0052;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_0052:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000B2")]
		[Address(RVA = "0xC0D41C", Offset = "0xC0D41C", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = ~t.<active>k__BackingField;\n\tif (v10) goto L_0010;\n\treturnVal2 = t.completedLoops;\n\tgoto L_002F;\nL_0010:\n\tgoto L_0025;\n\tv71 = DG.Tweening.Core.Debugger;\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, methodInfo, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26);\n\tv75 = 1;\n\t*([1A35757]) = v75;\nL_0025:\n\tv33 = v79._logPriority < 1;\n\tif (v33) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_002F:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000B3")]
		[Address(RVA = "0xC0D498", Offset = "0xC0D498", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = ~t.<active>k__BackingField;\n\tif (v12) goto L_0011;\n\tv67 = t.delay;\n\tgoto L_0032;\nL_0011:\n\tgoto L_0027;\n\tv78 = DG.Tweening.Core.Debugger;\n\tv79 = \"il2cpp_codegen_initialize_runtime_metadata\"(v78, methodInfo, v15, v16, v17, v18, v19, v20, returnVal1, v22, v23, v24, v25, v26, v27, v28);\n\tv81 = 1;\n\t*([1A35757]) = v81;\nL_0027:\n\tv35 = v85._logPriority < 1;\n\tif (v35) goto L_0032;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_0032:\n\treturn v67;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000B4")]
		[Address(RVA = "0xC0D520", Offset = "0xC0D520", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = ~t.<active>k__BackingField;\n\tif (v12) goto L_0011;\n\tv67 = t.elapsedDelay;\n\tgoto L_0032;\nL_0011:\n\tgoto L_0027;\n\tv78 = DG.Tweening.Core.Debugger;\n\tv79 = \"il2cpp_codegen_initialize_runtime_metadata\"(v78, methodInfo, v15, v16, v17, v18, v19, v20, returnVal1, v22, v23, v24, v25, v26, v27, v28);\n\tv81 = 1;\n\t*([1A35757]) = v81;\nL_0027:\n\tv35 = v85._logPriority < 1;\n\tif (v35) goto L_0032;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_0032:\n\treturn v67;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float ElapsedDelay(this Tween t)
		{
			float result;
			if (t.active)
			{
				result = t.elapsedDelay;
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

		[Token(Token = "0x60000B5")]
		[Address(RVA = "0xC0D5A8", Offset = "0xC0D5A8", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = ~t.<active>k__BackingField;\n\tif (v12) goto L_001D;\n\tv30 = includeLoops == 0;\n\tif (v30) goto L_0039;\n\tv36 = t.loops + 1;\n\tv38 = v36 == 0;\n\tif (v38) goto L_FFFFFFFF;\n\tv121 = t.duration * t.loops;\n\tgoto L_0043;\nL_001D:\n\tgoto L_0033;\n\tv43 = DG.Tweening.Core.Debugger;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, includeLoops, methodInfo, v16, v17, v18, v19, v20, returnVal1, v22, v23, v24, v25, v26, v27, v28);\n\tv47 = 1;\n\t*([1A35757]) = v47;\nL_0033:\n\tv64 = v52._logPriority < 1;\n\tif (v64) goto L_0043;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\tgoto L_0043;\nL_0039:\n\tv121 = t.duration;\n\tgoto L_0043;\nL_0043:\n\treturn v121;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000B6")]
		[Address(RVA = "0xC0D65C", Offset = "0xC0D65C", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = ~t.<active>k__BackingField;\n\tif (v12) goto L_0025;\n\tv90 = t.<position>k__BackingField;\n\tv31 = includeLoops == 0;\n\tif (v31) goto L_0046;\n\tv40 = t.<position>k__BackingField - t.duration;\n\tv41 = v40 < 0;\n\tv43 = t.<position>k__BackingField ^ t.duration;\n\tv44 = t.<position>k__BackingField ^ v40;\n\tv45 = v43 & v44;\n\tv46 = v45 < 0;\n\tv47 = v41 == v46;\n\tv49 = t.completedLoops - v47;\n\tv51 = t.duration * v49;\n\tv90 = v90 + v51;\n\tgoto L_0046;\nL_0025:\n\tgoto L_003B;\n\tv101 = DG.Tweening.Core.Debugger;\n\tv102 = \"il2cpp_codegen_initialize_runtime_metadata\"(v101, includeLoops, methodInfo, v16, v17, v18, v19, v20, returnVal1, v22, v23, v24, v25, v26, v27, v28);\n\tv104 = 1;\n\t*([1A35757]) = v104;\nL_003B:\n\tv63 = v108._logPriority < 1;\n\tif (v63) goto L_0046;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_0046:\n\treturn v90;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000B7")]
		[Address(RVA = "0xC0D708", Offset = "0xC0D708", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = ~t.<active>k__BackingField;\n\tif (v12) goto L_0034;\n\tv30 = includeLoops == 0;\n\tif (v30) goto L_0052;\n\tv37 = t.fullDuration < 0;\n\tv38 = ~v37;\n\tv41 = t.fullDuration == 0;\n\tv46 = ~v38;\n\tv47 = v46 | v41;\n\tif (v47) goto L_0059;\n\tv134 = t.<position>k__BackingField - t.duration;\n\tv135 = v134 < 0;\n\tv137 = t.<position>k__BackingField ^ t.duration;\n\tv138 = t.<position>k__BackingField ^ v134;\n\tv139 = v137 & v138;\n\tv140 = v139 < 0;\n\tv141 = v135 == v140;\n\tv143 = t.completedLoops - v141;\n\tv145 = t.duration * v143;\n\tv146 = t.<position>k__BackingField + v145;\n\tv151 = v146 / t.fullDuration;\n\tgoto L_0059;\nL_0034:\n\tgoto L_004A;\n\tv52 = DG.Tweening.Core.Debugger;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, includeLoops, methodInfo, v16, v17, v18, v19, v20, returnVal1, v22, v23, v24, v25, v26, v27, v28);\n\tv56 = 1;\n\t*([1A35757]) = v56;\nL_004A:\n\tv73 = v61._logPriority < 1;\n\tif (v73) goto L_0059;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\tgoto L_0059;\nL_0052:\n\tv151 = t.<position>k__BackingField / t.duration;\nL_0059:\n\treturn v151;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000B8")]
		[Address(RVA = "0xC0D7D8", Offset = "0xC0D7D8", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = ~t.<active>k__BackingField;\n\tif (v12) goto L_0046;\n\tv68 = t.<position>k__BackingField / t.duration;\n\tv43 = t.completedLoops < 1;\n\tif (v43) goto L_0067;\n\tv49 = t.loops + 1;\n\tv51 = v49 == 0;\n\tif (v51) goto L_0038;\n\tv66 = t.loops < 2;\n\tif (v66) goto L_0067;\nL_0038:\n\tv67 = t.loopType != 1;\n\tif (v67) goto L_0067;\n\tv170 = ~t.isComplete;\n\tif (v170) goto L_0068;\n\tv171 = t.completedLoops & 1;\n\tv172 = v171 == 0;\n\tv109 = ~v172;\n\tif (v109) goto L_0067;\n\tgoto L_006C;\nL_0046:\n\tgoto L_005C;\n\tv118 = DG.Tweening.Core.Debugger;\n\tv119 = \"il2cpp_codegen_initialize_runtime_metadata\"(v118, methodInfo, v15, v16, v17, v18, v19, v20, returnVal1, v22, v23, v24, v25, v26, v27, v28);\n\tv121 = 1;\n\t*([1A35757]) = v121;\nL_005C:\n\tv65 = v125._logPriority < 1;\n\tif (v65) goto L_0067;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_0067:\n\treturn v68;\nL_0068:\n\tv173 = t.completedLoops & 1;\n\tv110 = v173 == 0;\n\tif (v110) goto L_0067;\nL_006C:\n\tv68 = 1f - v68;\n\tgoto L_0067;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float ElapsedDirectionalPercentage(this Tween t)
		{
			float num;
			if (t.active)
			{
				num = t.position / t.duration;
				if (t.completedLoops >= 1 && (t.loops + 1 == 0 || t.loops >= 2) && t.loopType == LoopType.Yoyo)
				{
					if (t.isComplete)
					{
						if ((t.completedLoops & 1) != 0)
						{
							goto IL_014a;
						}
					}
					else if ((t.completedLoops & 1) == 0)
					{
						goto IL_014a;
					}
					num = 1f - num;
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
			goto IL_014a;
			IL_014a:
			return num;
		}

		[Token(Token = "0x60000B9")]
		[Address(RVA = "0xC0D8B0", Offset = "0xC0D8B0", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = t == 0;\n\tif (v0) goto L_000E;\n\tv7 = t.<active>k__BackingField == 0;\n\tv12 = ~v7;\nL_000E:\n\treturn returnVal1;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsActive(this Tween t)
		{
			//IL_0017: Expected I4, but got O
			bool flag = t == null;
			bool result = (byte)(int)t != 0;
			if (!flag)
			{
				bool flag2 = !t.active;
				bool flag3 = !flag2;
				result = flag3;
			}
			return result;
		}

		[Token(Token = "0x60000BA")]
		[Address(RVA = "0xC0D8C4", Offset = "0xC0D8C4", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = ~t.<active>k__BackingField;\n\tif (v10) goto L_001B;\n\tv32 = t.isBackwards == 0;\n\tv37 = ~v32;\n\tgoto L_003A;\nL_001B:\n\tgoto L_0030;\n\tv73 = DG.Tweening.Core.Debugger;\n\tv74 = \"il2cpp_codegen_initialize_runtime_metadata\"(v73, methodInfo, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26);\n\tv77 = 1;\n\t*([1A35757]) = v77;\nL_0030:\n\tv49 = v81._logPriority < 1;\n\tif (v49) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_003A:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000BB")]
		[Address(RVA = "0xC0D948", Offset = "0xC0D948", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = ~t.<active>k__BackingField;\n\tif (v10) goto L_0031;\n\tv38 = ~t.isBackwards;\n\tif (v38) goto L_004F;\n\tv44 = t.completedLoops < 1;\n\tif (v44) goto L_FFFFFFFF;\n\tv124 = t.loopType != 1;\n\tif (v124) goto L_FFFFFFFF;\n\tv165 = t.completedLoops & 1;\n\tv167 = v165 == 0;\n\tgoto L_0064;\nL_0031:\n\tgoto L_0046;\n\tv48 = DG.Tweening.Core.Debugger;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26);\n\tv52 = 1;\n\t*([1A35757]) = v52;\nL_0046:\n\tv68 = v56._logPriority < 1;\n\tif (v68) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\tgoto L_FFFFFFFF;\n\tgoto L_0064;\nL_004F:\n\tv46 = t.completedLoops < 1;\n\tif (v46) goto L_FFFFFFFF;\n\tv146 = t.loopType != 1;\n\tif (v146) goto L_FFFFFFFF;\n\tv172 = t.completedLoops & 1;\n\tgoto L_0064;\nL_0064:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsLoopingOrExecutingBackwards(this Tween t)
		{
			if (t.active)
			{
				if (t.isBackwards)
				{
					if (t.completedLoops >= 1 && t.loopType == LoopType.Yoyo)
					{
						int num = t.completedLoops & 1;
						return num == 0;
					}
					return true;
				}
				if (t.completedLoops >= 1 && t.loopType == LoopType.Yoyo)
				{
					return (byte)(t.completedLoops & 1) != 0;
				}
			}
			else if (Debugger._logPriority >= 1)
			{
				Debugger.LogInvalidTween(t);
			}
			return false;
		}

		[Token(Token = "0x60000BC")]
		[Address(RVA = "0xC0DA0C", Offset = "0xC0DA0C", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = ~t.<active>k__BackingField;\n\tif (v10) goto L_001B;\n\tv32 = t.isComplete == 0;\n\tv37 = ~v32;\n\tgoto L_003A;\nL_001B:\n\tgoto L_0030;\n\tv73 = DG.Tweening.Core.Debugger;\n\tv74 = \"il2cpp_codegen_initialize_runtime_metadata\"(v73, methodInfo, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26);\n\tv77 = 1;\n\t*([1A35757]) = v77;\nL_0030:\n\tv49 = v81._logPriority < 1;\n\tif (v49) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_003A:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000BD")]
		[Address(RVA = "0xC0DA90", Offset = "0xC0DA90", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = ~t.<active>k__BackingField;\n\tif (v10) goto L_001B;\n\tv32 = t.startupDone == 0;\n\tv37 = ~v32;\n\tgoto L_003A;\nL_001B:\n\tgoto L_0030;\n\tv73 = DG.Tweening.Core.Debugger;\n\tv74 = \"il2cpp_codegen_initialize_runtime_metadata\"(v73, methodInfo, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26);\n\tv77 = 1;\n\t*([1A35757]) = v77;\nL_0030:\n\tv49 = v81._logPriority < 1;\n\tif (v49) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_003A:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000BE")]
		[Address(RVA = "0xC0DB14", Offset = "0xC0DB14", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = ~t.<active>k__BackingField;\n\tif (v10) goto L_001B;\n\tv32 = t.isPlaying == 0;\n\tv37 = ~v32;\n\tgoto L_003A;\nL_001B:\n\tgoto L_0030;\n\tv73 = DG.Tweening.Core.Debugger;\n\tv74 = \"il2cpp_codegen_initialize_runtime_metadata\"(v73, methodInfo, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26);\n\tv77 = 1;\n\t*([1A35757]) = v77;\nL_0030:\n\tv49 = v81._logPriority < 1;\n\tif (v49) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_003A:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000BF")]
		[Address(RVA = "0xC0DB98", Offset = "0xC0DB98", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = ~t.<active>k__BackingField;\n\tif (v10) goto L_0010;\n\treturnVal2 = t.loops;\n\tgoto L_002F;\nL_0010:\n\tgoto L_0025;\n\tv71 = DG.Tweening.Core.Debugger;\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, methodInfo, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26);\n\tv75 = 1;\n\t*([1A35757]) = v75;\nL_0025:\n\tv33 = v79._logPriority < 1;\n\tif (v33) goto L_FFFFFFFF;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\nL_002F:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60000C0")]
		[Address(RVA = "0xC0DC14", Offset = "0xC0DC14", Length = "0x294")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv18 = DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, pathPercentage, v27, v28, v29, v30, v31, v32, v33);\n\tv52 = \"The path is not finalized yet\";\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, methodInfo, v21, v22, v23, v24, v25, v26, pathPercentage, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A356D4]) = v37;\nL_0021:\n\tv50 = pathPercentage > 1f;\n\tif (v50) goto L_0030;\n\tv63 = pathPercentage >= 0;\n\tif (v63) goto L_0030;\nL_0030:\n\tv75 = t == 0;\n\tif (v75) goto L_005B;\n\tv77 = ~t.<active>k__BackingField;\n\tif (v77) goto L_007A;\n\tv83 = ~t.isSequenced;\n\tif (v83) goto L_0097;\n\tgoto L_0051;\n\tv234 = DG.Tweening.Core.Debugger;\n\tv235 = \"il2cpp_codegen_initialize_runtime_metadata\"(v234, methodInfo, v21, v22, v23, v24, v25, v26, returnVal2, v27, v28, v29, v30, v31, v32, v33);\n\tv237 = 1;\n\t*([1A35757]) = v237;\nL_0051:\n\tv175 = v241._logPriority < 2;\n\tif (v175) goto L_00D6;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\tgoto L_00D6;\nL_005B:\n\tgoto L_0070;\n\tv89 = DG.Tweening.Core.Debugger;\n\tv90 = \"il2cpp_codegen_initialize_runtime_metadata\"(v89, methodInfo, v21, v22, v23, v24, v25, v26, returnVal2, v27, v28, v29, v30, v31, v32, v33);\n\tv93 = 1;\n\t*([1A35757]) = v93;\nL_0070:\n\tv109 = v97._logPriority < 2;\n\tif (v109) goto L_00D6;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\tgoto L_00D6;\nL_007A:\n\tgoto L_008F;\n\tv131 = DG.Tweening.Core.Debugger;\n\tv132 = \"il2cpp_codegen_initialize_runtime_metadata\"(v131, methodInfo, v21, v22, v23, v24, v25, v26, returnVal2, v27, v28, v29, v30, v31, v32, v33);\n\tv135 = 1;\n\t*([1A35757]) = v135;\nL_008F:\n\tv151 = v139._logPriority < 2;\n\tif (v151) goto L_00D6;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\tgoto L_00D6;\nL_0097:\n\tv116 = *([1A35000]);\n\tv117 = DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>;\n\tv120 = *([v116 @ X9_v3+130]) < *([v117 @ X8_v32 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>)+130]);\n\tv121 = ~v120;\n\tv129 = ~v121;\n\tif (v129) goto L_00B8;\n\tv159 = *([v117 @ X8_v32 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>)+130]) << 3;\n\tv245 = *([v116 @ X9_v3+C8]) + v159;\n\tv250 = *([v245 @ X9_v6-8]) == DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>;\n\tif (v250) goto L_00E9;\nL_00B8:\n\tgoto L_00CD;\n\tv281 = DG.Tweening.Core.Debugger;\n\tv282 = \"il2cpp_codegen_initialize_runtime_metadata\"(v281, methodInfo, v21, v22, v23, v24, v25, v26, returnVal2, v27, v28, v29, v30, v31, v32, v33);\n\tv284 = 1;\n\t*([1A35757]) = v284;\nL_00CD:\n\tv174 = v288._logPriority < 2;\n\tif (v174) goto L_00D6;\n\tDG.Tweening.Core.Debugger::LogNonPathTween(t);\nL_00D6:\n\tgoto L_00E0;\n\tv266 = UnityEngine.Vector3;\n\tv267 = \"il2cpp_codegen_initialize_runtime_metadata\"(v266, v168, v154, v22, v23, v24, v25, v26, returnVal2, v27, v28, v29, v30, v31, v32, v33);\n\tv270 = 1;\n\t*([1A35519]) = v270;\nL_00E0:\n\treturnVal1 = v274.zeroVector;\nL_00E8:\n\treturn returnVal1;\nL_00E9:\n\tv278 = *([1A35130]);\n\tv316 = ~v278.isFinalized;\n\tif (v316) goto L_00F9;\n\treturnVal1 = DG.Tweening.Plugins.Core.PathCore.Path::GetPoint(v278, returnVal2, 1);\n\tgoto L_00E8;\nL_00F9:\n\tgoto L_010E;\n\tv354 = DG.Tweening.Core.Debugger;\n\tv355 = \"il2cpp_codegen_initialize_runtime_metadata\"(v354, methodInfo, v21, v22, v23, v24, v25, v26, returnVal2, v27, v28, v29, v30, v31, v32, v33);\n\tv357 = 1;\n\t*([1A35757]) = v357;\nL_010E:\n\tv176 = v361._logPriority < 2;\n\tif (v176) goto L_00D6;\n\tDG.Tweening.Core.Debugger::LogWarning(\"The path is not finalized yet\", t);\n\tgoto L_00D6;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 196 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector3 PathGetPoint(this Tween t, float pathPercentage)
		{
			//IL_00bf: Expected O, but got I
			//IL_00cd: Expected I, but got O
			//IL_013a: Expected O, but got I
			//IL_018c: Expected O, but got I
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
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1A35000]");
						object obj = 0;
						nint num = (nint)typeof(TweenerCore<Vector3, Path, PathOptions>);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X9_v3+130]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ X8_v32 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>)+130]");
						if (num2 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ X8_v32 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>)+130]");
							int num3 = (int)((nint)0 << 3);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X9_v3+C8]");
							object obj2 = (nint)0 + (nint)num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ X9_v6-8]");
							if (0 == (nint)typeof(TweenerCore<Vector3, Path, PathOptions>))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1A35130]");
								Path path = (Path)0;
								if (path.isFinalized)
								{
									return path.GetPoint(perc, convertToConstantPerc: true);
								}
								if (Debugger._logPriority >= 2)
								{
									Debugger.LogWarning("The path is not finalized yet", t);
								}
								goto IL_029f;
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
			goto IL_029f;
			IL_029f:
			return Vector3.zero;
		}

		[Token(Token = "0x60000C1")]
		[Address(RVA = "0xC0DEA8", Offset = "0xC0DEA8", Length = "0x240")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, subdivisionsXSegment, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv40 = \"The path is not finalized yet\";\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, subdivisionsXSegment, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A356D5]) = v37;\nL_0015:\n\tv38 = t == 0;\n\tif (v38) goto L_0040;\n\tv42 = ~t.<active>k__BackingField;\n\tif (v42) goto L_005F;\n\tv48 = ~t.isSequenced;\n\tif (v48) goto L_007C;\n\tgoto L_0036;\n\tv200 = DG.Tweening.Core.Debugger;\n\tv201 = \"il2cpp_codegen_initialize_runtime_metadata\"(v200, subdivisionsXSegment, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv203 = 1;\n\t*([1A35757]) = v203;\nL_0036:\n\tv127 = v207._logPriority < 2;\n\tif (v127) goto L_00BD;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\tgoto L_00BD;\nL_0040:\n\tgoto L_0055;\n\tv54 = DG.Tweening.Core.Debugger;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, subdivisionsXSegment, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv58 = 1;\n\t*([1A35757]) = v58;\nL_0055:\n\tv74 = v62._logPriority < 2;\n\tif (v74) goto L_00BD;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\tgoto L_00BD;\nL_005F:\n\tgoto L_0074;\n\tv96 = DG.Tweening.Core.Debugger;\n\tv97 = \"il2cpp_codegen_initialize_runtime_metadata\"(v96, subdivisionsXSegment, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv100 = 1;\n\t*([1A35757]) = v100;\nL_0074:\n\tv116 = v104._logPriority < 2;\n\tif (v116) goto L_00BD;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\tgoto L_00BD;\nL_007C:\n\tv81 = *([1A35000]);\n\tv82 = DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>;\n\tv85 = *([v81 @ X9_v2+130]) < *([v82 @ X8_v24 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>)+130]);\n\tv86 = ~v85;\n\tv94 = ~v86;\n\tif (v94) goto L_009D;\n\tv124 = *([v82 @ X8_v24 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>)+130]) << 3;\n\tv211 = *([v81 @ X9_v2+C8]) + v124;\n\tv216 = *([v211 @ X9_v5-8]) == DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>;\n\tif (v216) goto L_00BE;\nL_009D:\n\tgoto L_00B2;\n\tv266 = DG.Tweening.Core.Debugger;\n\tv267 = \"il2cpp_codegen_initialize_runtime_metadata\"(v266, subdivisionsXSegment, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv269 = 1;\n\t*([1A35757]) = v269;\nL_00B2:\n\tv126 = v273._logPriority < 2;\n\tif (v126) goto L_00BD;\n\tDG.Tweening.Core.Debugger::LogNonPathTween(t);\nL_00BD:\n\treturn 0;\nL_00BE:\n\tv264 = *([1A35130]);\n\tv254 = ~v264.isFinalized;\n\tif (v254) goto L_00D1;\n\treturnVal3 = DG.Tweening.Plugins.Core.PathCore.Path::GetDrawPoints(v264, subdivisionsXSegment);\n\treturn returnVal3;\nL_00D1:\n\tgoto L_00E6;\n\tv279 = DG.Tweening.Core.Debugger;\n\tv280 = \"il2cpp_codegen_initialize_runtime_metadata\"(v279, subdivisionsXSegment, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv282 = 1;\n\t*([1A35757]) = v282;\nL_00E6:\n\tv128 = v286._logPriority < 2;\n\tif (v128) goto L_00BD;\n\tDG.Tweening.Core.Debugger::LogWarning(\"The path is not finalized yet\", t);\n\tgoto L_00BD;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 166 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1A35000]");
						object obj = 0;
						nint num = (nint)typeof(TweenerCore<Vector3, Path, PathOptions>);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X9_v2+130]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ X8_v24 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>)+130]");
						if (num2 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ X8_v24 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>)+130]");
							int num3 = (int)((nint)0 << 3);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X9_v2+C8]");
							object obj2 = (nint)0 + (nint)num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ X9_v5-8]");
							if (0 == (nint)typeof(TweenerCore<Vector3, Path, PathOptions>))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1A35130]");
								Path path = (Path)0;
								if (path.isFinalized)
								{
									return Path.GetDrawPoints(path, subdivisionsXSegment);
								}
								if (Debugger._logPriority >= 2)
								{
									Debugger.LogWarning("The path is not finalized yet", t);
								}
								goto IL_013f;
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
			goto IL_013f;
			IL_013f:
			return null;
		}

		[Token(Token = "0x60000C2")]
		[Address(RVA = "0xC0E0E8", Offset = "0xC0E0E8", Length = "0x24C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv16 = DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, returnVal2, v26, v27, v28, v29, v30, v31, v32);\n\tv39 = \"The path is not finalized yet\";\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v39, methodInfo, v19, v20, v21, v22, v23, v24, returnVal2, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 1;\n\t*([1A356D6]) = v36;\nL_0014:\n\tv37 = t == 0;\n\tif (v37) goto L_0040;\n\tv41 = ~t.<active>k__BackingField;\n\tif (v41) goto L_0060;\n\tv47 = ~t.isSequenced;\n\tif (v47) goto L_007E;\n\tgoto L_0036;\n\tv216 = DG.Tweening.Core.Debugger;\n\tv217 = \"il2cpp_codegen_initialize_runtime_metadata\"(v216, methodInfo, v19, v20, v21, v22, v23, v24, returnVal2, v26, v27, v28, v29, v30, v31, v32);\n\tv219 = 1;\n\t*([1A35757]) = v219;\nL_0036:\n\tv133 = v223._logPriority < 2;\n\tif (v133) goto L_00EB;\n\tDG.Tweening.Core.Debugger::LogNestedTween(t);\n\tgoto L_00EB;\nL_0040:\n\tgoto L_0056;\n\tv53 = DG.Tweening.Core.Debugger;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, methodInfo, v19, v20, v21, v22, v23, v24, returnVal2, v26, v27, v28, v29, v30, v31, v32);\n\tv57 = 1;\n\t*([1A35757]) = v57;\nL_0056:\n\tv74 = v62._logPriority < 2;\n\tif (v74) goto L_00EB;\n\tDG.Tweening.Core.Debugger::LogNullTween(0);\n\tgoto L_00EB;\nL_0060:\n\tgoto L_0076;\n\tv96 = DG.Tweening.Core.Debugger;\n\tv97 = \"il2cpp_codegen_initialize_runtime_metadata\"(v96, methodInfo, v19, v20, v21, v22, v23, v24, returnVal2, v26, v27, v28, v29, v30, v31, v32);\n\tv100 = 1;\n\t*([1A35757]) = v100;\nL_0076:\n\tv117 = v105._logPriority < 2;\n\tif (v117) goto L_00EB;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(t);\n\tgoto L_00EB;\nL_007E:\n\tv81 = *([1A35000]);\n\tv82 = DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>;\n\tv85 = *([v81 @ X9_v2+130]) < *([v82 @ X8_v24 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>)+130]);\n\tv86 = ~v85;\n\tv94 = ~v86;\n\tif (v94) goto L_009F;\n\tv128 = *([v82 @ X8_v24 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>)+130]) << 3;\n\tv227 = *([v81 @ X9_v2+C8]) + v128;\n\tv159 = *([v227 @ X9_v5-8]) == DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>;\n\tif (v159) goto L_00BB;\nL_009F:\n\tgoto L_00B5;\n\tv266 = DG.Tweening.Core.Debugger;\n\tv267 = \"il2cpp_codegen_initialize_runtime_metadata\"(v266, methodInfo, v19, v20, v21, v22, v23, v24, returnVal2, v26, v27, v28, v29, v30, v31, v32);\n\tv269 = 1;\n\t*([1A35757]) = v269;\nL_00B5:\n\tv134 = v273._logPriority < 2;\n\tif (v134) goto L_00EB;\n\tDG.Tweening.Core.Debugger::LogNonPathTween(t);\n\tgoto L_00EB;\nL_00BB:\n\tv205 = *([1A35130]);\n\tv199 = *([v205 @ X8_v33+3C]) == 0;\n\tif (v199) goto L_00C7;\n\tv122 = *([v205 @ X8_v33+38]);\n\tgoto L_00EB;\nL_00C7:\n\tgoto L_00DD;\n\tv279 = DG.Tweening.Core.Debugger;\n\tv280 = \"il2cpp_codegen_initialize_runtime_metadata\"(v279, methodInfo, v19, v20, v21, v22, v23, v24, returnVal2, v26, v27, v28, v29, v30, v31, v32);\n\tv282 = 1;\n\t*([1A35757]) = v282;\nL_00DD:\n\tv132 = v286._logPriority < 2;\n\tif (v132) goto L_00EB;\n\tDG.Tweening.Core.Debugger::LogWarning(\"The path is not finalized yet\", t);\nL_00EB:\n\treturn v122;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 163 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1A35000]");
						object obj = 0;
						nint num = (nint)typeof(TweenerCore<Vector3, Path, PathOptions>);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X9_v2+130]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ X8_v24 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>)+130]");
						if (num2 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ X8_v24 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>)+130]");
							int num3 = (int)((nint)0 << 3);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X9_v2+C8]");
							object obj2 = (nint)0 + (nint)num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ X9_v5-8]");
							if (0 == (nint)typeof(TweenerCore<Vector3, Path, PathOptions>))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1A35130]");
								object obj3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ X8_v33+3C]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ X8_v33+38]");
									result = 0f;
								}
								else
								{
									bool flag = Debugger._logPriority < 2;
									result = -1f;
									if (!flag)
									{
										Debugger.LogWarning("The path is not finalized yet", t);
										result = -1f;
									}
								}
								goto IL_01d3;
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
			goto IL_01d3;
			IL_01d3:
			return result;
		}
	}
}
