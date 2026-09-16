using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening
{
	[Token(Token = "0x2000008")]
	public class DOTween
	{
		[Token(Token = "0x400000E")]
		public static readonly string Version = "1.2.305";

		[Token(Token = "0x400000F")]
		public static bool useSafeMode = true;

		[Token(Token = "0x4000010")]
		public static NestedTweenFailureBehaviour nestedTweenFailureBehaviour = default(NestedTweenFailureBehaviour);

		[Token(Token = "0x4000011")]
		public static bool showUnityEditorReport = false;

		[Token(Token = "0x4000012")]
		public static float timeScale = 1f;

		[Token(Token = "0x4000013")]
		public static bool useSmoothDeltaTime;

		[Token(Token = "0x4000014")]
		public static float maxSmoothUnscaledTime = 0.15f;

		[Token(Token = "0x4000015")]
		internal static RewindCallbackMode rewindCallbackMode = default(RewindCallbackMode);

		[Token(Token = "0x4000016")]
		private static LogBehaviour _logBehaviour = LogBehaviour.ErrorsOnly;

		[Token(Token = "0x4000017")]
		public static Func<LogType, object, bool> onWillLog;

		[Token(Token = "0x4000018")]
		public static bool drawGizmos = true;

		[Token(Token = "0x4000019")]
		public static UpdateType defaultUpdateType = default(UpdateType);

		[Token(Token = "0x400001A")]
		public static bool defaultTimeScaleIndependent = false;

		[Token(Token = "0x400001B")]
		public static AutoPlay defaultAutoPlay = AutoPlay.All;

		[Token(Token = "0x400001C")]
		public static bool defaultAutoKill = true;

		[Token(Token = "0x400001D")]
		public static LoopType defaultLoopType = default(LoopType);

		[Token(Token = "0x400001E")]
		public static bool defaultRecyclable;

		[Token(Token = "0x400001F")]
		public static Ease defaultEaseType = Ease.OutQuad;

		[Token(Token = "0x4000020")]
		public static float defaultEaseOvershootOrAmplitude = 1.70158f;

		[Token(Token = "0x4000021")]
		public static float defaultEasePeriod = 0f;

		[Token(Token = "0x4000022")]
		public static DOTweenComponent instance;

		[Token(Token = "0x4000023")]
		internal static int maxActiveTweenersReached;

		[Token(Token = "0x4000024")]
		internal static int maxActiveSequencesReached;

		[Token(Token = "0x4000025")]
		internal static SafeModeReport safeModeReport;

		[Token(Token = "0x4000026")]
		public static readonly List<TweenCallback> GizmosDelegates;

		[Token(Token = "0x4000027")]
		internal static bool initialized;

		[Token(Token = "0x4000028")]
		internal static bool isQuitting;

		[Token(Token = "0x17000001")]
		public static LogBehaviour logBehaviour
		{
			[Token(Token = "0x6000011")]
			[Address(RVA = "0x107AB24", Offset = "0x107AB24", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB7590]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20269E7]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = DG.Tweening.DOTween;\nL_0024:\n\treturn v49._logBehaviour;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return _logBehaviour;
			}
			[Token(Token = "0x6000012")]
			[Address(RVA = "0x107AB8C", Offset = "0x107AB8C", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EEB3A0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20269E8]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = DG.Tweening.DOTween;\nL_0021:\n\tv52._logBehaviour = value;\n\tDG.Tweening.Core.Debugger::SetLogPriority(v53._logBehaviour);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_logBehaviour = value;
				Debugger.SetLogPriority(_logBehaviour);
			}
		}

		[Token(Token = "0x6000013")]
		[Address(RVA = "0x107AC00", Offset = "0x107AC00", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EC8440]);\n\tv27 = *([v26 @ X8_v27]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, useSafeMode, logBehaviour, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20269E9]) = v44;\nL_001D:\n\tgoto L_0026;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0026;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v47, useSafeMode, logBehaviour, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = DG.Tweening.DOTween;\nL_0026:\n\tv60 = ~v58.initialized;\n\tif (v60) goto L_0036;\n\tgoto L_FFFFFFFF;\n\tv67 = *([v54 @ X0_v3 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_FFFFFFFF;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v54, useSafeMode, logBehaviour, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv98 = DG.Tweening.DOTween;\n\tv75 = *([v98 @ X8_v22+B8]);\n\tgoto L_0053;\nL_0036:\n\tv66 = UnityEngine.Application::get_isPlaying();\n\tv80 = v66 == 0;\n\tif (v80) goto L_0053;\n\tgoto L_0049;\n\tv161 = *([v94 @ X0_v8 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv162 = v161 == 0;\n\tv163 = ~v162;\n\tif (v163) goto L_0049;\n\tv169 = \"il2cpp_codegen_runtime_class_init\"(v94, useSafeMode, logBehaviour, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv165 = DG.Tweening.DOTween;\nL_0049:\n\tv85 = ~v168.isQuitting;\n\tif (v85) goto L_0058;\nL_0053:\n\treturn returnVal1;\nL_0058:\n\tv174 = UnityEngine.Resources::Load(\"DOTweenSettings\");\n\tgoto L_0065;\n\tv180 = *([v175 @ X8_v14+E0]);\n\tv181 = v180 == 0;\n\tv182 = ~v181;\n\tif (v182) goto L_0065;\n\tv187 = v175;\n\tv185 = \"il2cpp_codegen_runtime_class_init\"(v187, v172, logBehaviour, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0065:\n\tv148 = v174 == 0;\n\tif (v148) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_008C;\n\tv229 = v229_asT == 0;\n\tif (v229) goto L_FFFFFFFF;\n\tgoto L_008C;\nL_008C:\n\tv102 = useSafeMode & 0xFFFF;\n\tv142 = recycleAllByDefault & 0xFFFF;\n\treturnVal2 = DG.Tweening.DOTween::Init(v230, v142, v102, logBehaviour);\n\treturn returnVal2;\n// 96 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static IDOTweenInit Init(bool? recycleAllByDefault = null, bool? useSafeMode = null, LogBehaviour? logBehaviour = null)
		{
			//IL_0119: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Expected O, but got Unknown
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_012c: Expected O, but got Unknown
			IDOTweenInit result;
			if (!initialized)
			{
				bool isPlaying = Application.isPlaying;
				bool flag = !isPlaying;
				result = null;
				if (!flag)
				{
					if (!isQuitting)
					{
						UnityEngine.Object obj = Resources.Load("DOTweenSettings");
						DOTweenSettings settings;
						if ((object)obj == null)
						{
							settings = null;
						}
						else
						{
							DOTweenSettings dOTweenSettings = obj as DOTweenSettings;
							settings = (DOTweenSettings)(((object)dOTweenSettings == null) ? null : obj);
						}
						bool? flag2 = (bool?)(object)((_003F?)useSafeMode & 0xFFFF);
						bool? recycleAllByDefault2 = (bool?)(object)((_003F?)recycleAllByDefault & 0xFFFF);
						return Init(settings, recycleAllByDefault2, flag2, logBehaviour);
					}
					result = null;
				}
			}
			else
			{
				result = instance;
			}
			return result;
		}

		[Token(Token = "0x6000014")]
		[Address(RVA = "0x107B3F8", Offset = "0x107B3F8", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = *([1F0E7E0]);\n\tv15 = *([v14 @ X8_v14]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20269EA]) = v35;\nL_0015:\n\tv134 = UnityEngine.Resources::Load(\"DOTweenSettings\");\n\tv44 = DG.Tweening.DOTween;\n\tv46 = *([v44 @ X8_v7 (Il2CppClass<DG.Tweening.DOTween>)+12F]) & 2;\n\tv47 = v46 == 0;\n\tif (v47) goto L_0021;\n\tv49 = *([v44 @ X8_v7 (Il2CppClass<DG.Tweening.DOTween>)+E0]) == 0;\n\tif (v49) goto L_004A;\nL_0021:\n\tv52 = v134 == 0;\n\tif (v52) goto L_FFFFFFFF;\nL_0033:\n\tgoto L_FFFFFFFF;\n\tv116 = v116_asT == 0;\n\tif (v116) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0055;\nL_004A:\n\tv102 = v134 == 0;\n\tv58 = ~v102;\n\tif (v58) goto L_0033;\nL_0055:\n\tv143 = DG.Tweening.DOTween::Init(v133, 0, 0, 0);\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void AutoInit()
		{
			//IL_00d3: Expected I, but got O
			UnityEngine.Object obj = Resources.Load("DOTweenSettings");
			IntPtr intPtr = (IntPtr)typeof(DOTween);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v7 (Il2CppClass<DG.Tweening.DOTween>)+12F]");
			if (0u != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v7 (Il2CppClass<DG.Tweening.DOTween>)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					if ((object)obj != null)
					{
						goto IL_004c;
					}
					goto IL_00ad;
				}
			}
			if ((object)obj != null)
			{
				goto IL_004c;
			}
			goto IL_00ad;
			IL_004c:
			DOTweenSettings dOTweenSettings = obj as DOTweenSettings;
			if ((object)dOTweenSettings == null)
			{
				obj = null;
			}
			DOTweenSettings settings = (DOTweenSettings)obj;
			goto IL_0113;
			IL_0113:
			IDOTweenInit iDOTweenInit = Init(settings, null, null, null);
			return;
			IL_00ad:
			settings = null;
			goto IL_0113;
		}

		[Token(Token = "0x6000015")]
		[Address(RVA = "0x107AD74", Offset = "0x107AD74", Length = "0x684")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv30 = *([1EF6458]);\n\tv31 = *([v30 @ X8_v129]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, recycleAllByDefault, useSafeMode, logBehaviour, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20269EB]) = v47;\n\tgoto L_0029;\n\tv55 = *([v51 @ X0_v2 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tgoto L_0029;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v51, recycleAllByDefault, useSafeMode, logBehaviour, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv59 = DG.Tweening.DOTween;\nL_0029:\n\tv63 = recycleAllByDefault & 0xFFFF;\n\tv65 = v63 < 0xFF;\n\tv66 = ~v65;\n\tv67 = v63 - 0xFF;\n\tv69 = v67 == 0;\n\tv62.initialized = 1;\n\tv74 = ~v69;\n\tv75 = v66 & v74;\n\tif (v75) goto L_0042;\n\tv77 = useSafeMode >> 8;\n\tv78 = v77 & 0xFF;\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_005A;\n\tgoto L_006C;\nL_0042:\n\tv109 = 0x115B1E4(&recycleAllByDefault @ X1 (System.Nullable`1<System.Boolean>), Il2CppMethodInfo, useSafeMode, logBehaviour, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0051;\n\tv124 = *([v102 @ X8_v120 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv125 = v124 == 0;\n\tv126 = ~v125;\n\tif (v126) goto L_0051;\n\tv157 = v102;\n\tv128 = \"il2cpp_codegen_runtime_class_init\"(v157, v84, useSafeMode, logBehaviour, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv131 = DG.Tweening.DOTween;\nL_0051:\n\tv87 = v109 & 1;\n\tv62.defaultRecyclable = v87;\n\tv92 = v133 == 0;\n\tif (v92) goto L_006C;\nL_005A:\n\tv109 = 0x115B1E4(&useSafeMode @ X2 (System.Nullable`1<System.Boolean>), Il2CppMethodInfo, useSafeMode, logBehaviour, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0069;\n\tv150 = *([v120 @ X8_v114 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv151 = v150 == 0;\n\tv152 = ~v151;\n\tif (v152) goto L_0069;\n\tv167 = v120;\n\tv154 = \"il2cpp_codegen_runtime_class_init\"(v167, v100, useSafeMode, logBehaviour, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv156 = DG.Tweening.DOTween;\nL_0069:\n\tv107 = v109 & 1;\n\tv62.useSafeMode = v107;\nL_006C:\n\tv119 = v118 == 0;\n\tif (v119) goto L_0081;\n\tv138 = 0x115C1C4(&logBehaviour @ X3 (System.Nullable`1<DG.Tweening.LogBehaviour>), Il2CppMethodInfo, useSafeMode, logBehaviour, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0080;\n\tv168 = *([v149 @ X8_v110+E0]);\n\tv169 = v168 == 0;\n\tv170 = ~v169;\n\tif (v170) goto L_0080;\n\tv184 = v149;\n\tv172 = \"il2cpp_codegen_runtime_class_init\"(v184, v137, useSafeMode, logBehaviour, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0080:\n\tDG.Tweening.DOTween::set_logBehaviour(v138);\nL_0081:\n\tDG.Tweening.Core.DOTweenComponent::Create();\n\tgoto L_0091;\n\tv173 = *([v163 @ X0_v6+E0]);\n\tv174 = v173 == 0;\n\tv175 = ~v174;\n\tif (v175) goto L_0091;\n\tv177 = \"il2cpp_codegen_runtime_class_init\"(v163, v141, useSafeMode, logBehaviour, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0091:\n\tv183 = UnityEngine.Object::op_Inequality(settings, 0);\n\tv186 = v183 == 0;\n\tif (v186) goto L_0138;\n\tv188 = v133 == 0;\n\tv189 = ~v188;\n\tif (v189) goto L_00AA;\n\tgoto L_00A8;\n\tv381 = *([v261 @ X0_v97 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv382 = v381 == 0;\n\tv383 = ~v382;\n\tif (v383) goto L_00A8;\n\tv446 = \"il2cpp_codegen_runtime_class_init\"(v261, v181, v182, logBehaviour, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv384 = DG.Tweening.DOTween;\nL_00A8:\n\tv62.useSafeMode = settings.useSafeMode;\nL_00AA:\n\tv236 = v118 == 0;\n\tv237 = ~v236;\n\tif (v237) goto L_00BD;\n\tgoto L_00BB;\n\tv447 = *([v426 @ X0_v93+E0]);\n\tv448 = v447 == 0;\n\tv449 = ~v448;\n\tif (v449) goto L_00BB;\n\tv451 = \"il2cpp_codegen_runtime_class_init\"(v426, v181, v182, logBehaviour, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_00BB:\n\tDG.Tweening.DOTween::set_logBehaviour(settings.logBehaviour);\nL_00BD:\n\tv330 = v329 == 0;\n\tif (v330) goto L_00CA;\n\tv430 = settings == 0;\n\tv307 = ~v430;\n\tif (v307) goto L_00D3;\n\tgoto L_0271;\nL_00CA:\n\tgoto L_00D2;\n\tv496 = *([v457 @ X0_v89 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv497 = v496 == 0;\n\tv498 = ~v497;\n\tif (v498) goto L_00D2;\n\tv531 = \"il2cpp_codegen_runtime_class_init\"(v457, v181, v182, logBehaviour, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv499 = DG.Tweening.DOTween;\nL_00D2:\n\tv62.defaultRecyclable = settings.defaultRecyclable;\nL_00D3:\n\tv297 = settings.safeModeOptions;\n\tgoto L_00E4;\n\tv511 = *([v491 @ X8_v85 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv512 = v511 == 0;\n\tv513 = ~v512;\n\tif (v513) goto L_00E4;\n\tv623 = v491;\n\tv516 = \"il2cpp_codegen_runtime_class_init\"(v623, v181, v182, logBehaviour, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv519 = DG.Tweening.DOTween;\nL_00E4:\n\tv520.nestedTweenFailureBehaviour = v297.nestedTweenFailureBehaviour;\n\tv522.timeScale = settings.timeScale;\n\tv524.useSmoothDeltaTime = settings.useSmoothDeltaTime;\n\tv526.maxSmoothUnscaledTime = settings.maxSmoothUnscaledTime;\n\tv528.rewindCallbackMode = settings.rewindCallbackMode;\n\tv530 = v329 == 0;\n\tif (v530) goto L_0101;\n\tv628 = 0x115B1E4(&recycleAllByDefault @ X1 (System.Nullable`1<System.Boolean>), Il2CppMethodInfo, 0, logBehaviour, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_010B;\nL_0101:\n\tv634 = settings.defaultRecyclable == 0;\n\tv639 = ~v634;\nL_010B:\n\tgoto L_0115;\n\tv718 = *([v710 @ X8_v87 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv719 = v718 == 0;\n\tv720 = ~v719;\n\tgoto L_0115;\n\tv748 = v710;\n\tv722 = \"il2cpp_codegen_runtime_class_init\"(v748, v213, v182, logBehaviour, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv724 = DG.Tweening.DOTween;\nL_0115:\n\tv725.defaultRecyclable = v219;\n\tv728.showUnityEditorReport = settings.showUnityEditorReport;\n\tv730.drawGizmos = settings.drawGizmos;\n\tv732.defaultAutoPlay = settings.defaultAutoPlay;\n\tv734.defaultUpdateType = settings.defaultUpdateType;\n\tv736.defaultTimeScaleIndependent = settings.defaultTimeScaleIndependent;\n\tv738.defaultEaseType = settings.defaultEaseType;\n\tv740.defaultEaseOvershootOrAmplitude = settings.defaultEaseOvershootOrAmplitude;\n\tv742.defaultEasePeriod = settings.defaultEasePeriod;\n\tv209.defaultAutoKill = settings.defaultAutoKill;\n\tv62.defaultLoopType = settings.defaultLoopType;\nL_0138:\n\tgoto L_014E;\n\tv239 = *([1EC27E8]);\n\tv240 = *([v239 @ X8_v76]);\n\tv241 = \"il2cpp_codegen_initialize_method\"(v240, v212, v182, logBehaviour, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv244 = 0 | 1;\n\t*([2022B9B]) = v244;\nL_014E:\n\tv260 = v248._logPriority < 2;\n\tif (v260) goto L_0259;\n\t// 340 NewArr v335 @ X0_v21 (System.String[]), typeof(System.String[]), 7\n\tv464 = \"DOTween initialization (useSafeMode: \" == 0;\n\tif (v464) goto L_0162;\n\t// 351 IsInst v503 @ X0_v72, typeof(System.String), \"DOTween initialization (useSafeMode: \"\nL_0162:\n\tv62 = v335.Length;\n\tv510 = v335.Length == 0;\n\tif (v510) goto L_026A;\n\tv335[0] = \"DOTween initialization (useSafeMode: \";\n\tgoto L_0174;\n\tv695 = *([v533 @ X0_v30 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv696 = v695 == 0;\n\tv697 = ~v696;\n\tif (v697) goto L_0174;\n\tv716 = \"il2cpp_codegen_runtime_class_init\"(v533, v504, v182, logBehaviour, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv699 = DG.Tweening.DOTween;\nL_0174:\n\tv704 = v698.Version + 8;\n\tv705 = 0xE8F14C(v704, 0, 0, logBehaviour, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv717 = v705 == 0;\n\tif (v717) goto L_017F;\n\t// 380 IsInst v672 @ X0_v69, typeof(System.String), v705 @ X0_v33\nL_017F:\n\tv62 = v335.Length;\n\tv746 = v335.Length < 1;\n\tv581 = ~v746;\n\tv576 = v335.Length - 1;\n\tv566 = v576 == 0;\n\tv747 = ~v581;\n\tv541 = v747 | v566;\n\tif (v541) goto L_026A;\n\tv335[1] = v705;\n\tv751 = \", recycling: \" == 0;\n\tif (v751) goto L_0198;\n\t// 404 IsInst v673 @ X0_v67, typeof(System.String), \", recycling: \"\n\tv62 = v335.Length;\nL_0198:\n\tv753 = v62 < 2;\n\tv584 = ~v753;\n\tv579 = v62 - 2;\n\tv569 = v579 == 0;\n\tv754 = ~v584;\n\tv544 = v754 | v569;\n\tif (v544) goto L_026A;\n\tv335[2] = \", recycling: \";\n\tv655 = v759.defaultRecyclable == 0;\n\tv645 = ~v655;\n\tv339 = ~v645;\n\tif (v339) goto L_FFFFFF\n// ... truncated")]
		private unsafe static IDOTweenInit Init(DOTweenSettings settings, bool? recycleAllByDefault, bool? useSafeMode, LogBehaviour? logBehaviour)
		{
			//IL_0545: Expected I, but got O
			//IL_0553: Unknown result type (might be due to invalid IL or missing references)
			//IL_0558: Expected I4, but got Unknown
			//IL_0013: Expected I4, but got O
			//IL_07b3: Expected O, but got I
			//IL_026f: Expected O, but got I4
			//IL_0803: Expected O, but got I
			//IL_097e: Expected O, but got I
			//IL_087e: Expected O, but got I
			//IL_03f1: Expected I, but got O
			//IL_046a: Expected O, but got I4
			//IL_08fc: Expected O, but got I
			IntPtr intPtr = (IntPtr)typeof(DOTween);
			int num = (_003F?)recycleAllByDefault & 0xFFFF;
			bool flag = num < 255;
			bool flag2 = !flag;
			int num2 = num - 255;
			bool flag3 = num2 == 0;
			initialized = true;
			bool flag4 = !flag3;
			object obj = default(object);
			if (!(flag2 && flag4))
			{
				int num3 = (object?)useSafeMode >> 8;
				if ((num3 & 0xFF) != 0)
				{
					goto IL_005d;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115B1E4 (inside System.Linq.Set`1<System.Object>::InternalGetHashCode +0xE4)");
				int num4 = (int)((long)intPtr & 1L);
				defaultRecyclable = (byte)num4 != 0;
				if (obj != null)
				{
					goto IL_005d;
				}
			}
			goto IL_05bf;
			IL_0931:
			return instance;
			IL_05bf:
			object obj2 = default(object);
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115C1C4 (inside System.Nullable`1<System.Int32>::Unbox +0xC0)");
				LogBehaviour logBehaviour2 = default(LogBehaviour);
				DOTween.logBehaviour = logBehaviour2;
				intPtr = (IntPtr)(void*)(int)logBehaviour2;
			}
			DOTweenComponent.Create();
			if (settings != null)
			{
				if (obj == null)
				{
					DOTween.useSafeMode = settings.useSafeMode;
				}
				if (obj2 == null)
				{
					DOTween.logBehaviour = settings.logBehaviour;
				}
				object obj3 = default(object);
				if (obj3 != null)
				{
					if ((object)settings == null)
					{
						return (IDOTweenInit)new NullReferenceException();
					}
				}
				else
				{
					defaultRecyclable = settings.defaultRecyclable;
				}
				DOTweenSettings.SafeModeOptions safeModeOptions = settings.safeModeOptions;
				nestedTweenFailureBehaviour = safeModeOptions.nestedTweenFailureBehaviour;
				timeScale = settings.timeScale;
				useSmoothDeltaTime = settings.useSmoothDeltaTime;
				maxSmoothUnscaledTime = settings.maxSmoothUnscaledTime;
				rewindCallbackMode = settings.rewindCallbackMode;
				bool flag5;
				if (obj3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115B1E4 (inside System.Linq.Set`1<System.Object>::InternalGetHashCode +0xE4)");
					bool flag6 = default(bool);
					flag5 = flag6;
				}
				else
				{
					bool flag7 = !settings.defaultRecyclable;
					bool flag8 = !flag7;
					flag5 = flag8;
				}
				defaultRecyclable = flag5;
				showUnityEditorReport = settings.showUnityEditorReport;
				drawGizmos = settings.drawGizmos;
				defaultAutoPlay = settings.defaultAutoPlay;
				defaultUpdateType = settings.defaultUpdateType;
				defaultTimeScaleIndependent = settings.defaultTimeScaleIndependent;
				defaultEaseType = settings.defaultEaseType;
				defaultEaseOvershootOrAmplitude = settings.defaultEaseOvershootOrAmplitude;
				defaultEasePeriod = settings.defaultEasePeriod;
				defaultAutoKill = settings.defaultAutoKill;
				defaultLoopType = settings.defaultLoopType;
			}
			if (Debugger._logPriority >= 2)
			{
				string[] array = new string[7];
				if ("DOTween initialization (useSafeMode: " != null)
				{
					object obj4 = "DOTween initialization (useSafeMode: " as string;
				}
				IntPtr intPtr2 = (IntPtr)array.Length;
				if (array.Length != 0)
				{
					array[0] = "DOTween initialization (useSafeMode: ";
					object obj5 = (long)(IntPtr)Version + 8L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E8F14C (inside System.BitConverter::.cctor +0x64)");
					object obj6 = default(object);
					if (obj6 != null)
					{
						object obj7 = obj6 as string;
					}
					intPtr2 = (IntPtr)array.Length;
					bool flag9 = array.Length < 1;
					bool flag10 = !flag9;
					object obj8 = array.Length - 1;
					bool flag11 = obj8 == null;
					bool flag12 = !flag10;
					if (!(flag12 || flag11))
					{
						array[1] = (string)obj6;
						if (", recycling: " != null)
						{
							object obj9 = ", recycling: " as string;
							intPtr2 = (IntPtr)array.Length;
						}
						bool flag13 = (long)intPtr2 < 2L;
						bool flag14 = !flag13;
						object obj10 = (long)intPtr2 - 2L;
						bool flag15 = obj10 == null;
						bool flag16 = !flag14;
						if (!(flag16 || flag15))
						{
							array[2] = ", recycling: ";
							string text = ((!defaultRecyclable) ? "OFF" : "ON");
							if (text != null)
							{
								object obj11 = text as string;
								intPtr2 = (IntPtr)array.Length;
							}
							bool flag17 = (long)intPtr2 < 3L;
							bool flag18 = !flag17;
							object obj12 = (long)intPtr2 - 3L;
							bool flag19 = obj12 == null;
							bool flag20 = !flag18;
							if (!(flag20 || flag19))
							{
								array[3] = text;
								if (", logBehaviour: " != null)
								{
									object obj13 = ", logBehaviour: " as string;
									intPtr2 = (IntPtr)array.Length;
								}
								bool flag21 = (long)intPtr2 < 4L;
								bool flag22 = !flag21;
								object obj14 = (long)intPtr2 - 4L;
								bool flag23 = obj14 == null;
								bool flag24 = !flag22;
								if (!(flag24 || flag23))
								{
									array[4] = ", logBehaviour: ";
									LogBehaviour logBehaviour3 = _logBehaviour;
									object obj15 = logBehaviour3;
									intPtr2 = (IntPtr)obj15;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v62 @ X8_v5 (Il2CppStaticFields<DG.Tweening.DOTween>)+160] (should have been resolved before IL gen)");
									Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
									object obj16 = default(object);
									if (obj16 != null)
									{
										object obj17 = obj16 as string;
									}
									intPtr2 = (IntPtr)array.Length;
									bool flag25 = array.Length < 5;
									bool flag26 = !flag25;
									object obj18 = array.Length - 5;
									bool flag27 = obj18 == null;
									bool flag28 = !flag26;
									if (!(flag28 || flag27))
									{
										array[5] = (string)obj16;
										if (")" != null)
										{
											object obj19 = ")" as string;
											intPtr2 = (IntPtr)array.Length;
										}
										bool flag29 = (long)intPtr2 < 6L;
										bool flag30 = !flag29;
										object obj20 = (long)intPtr2 - 6L;
										bool flag31 = obj20 == null;
										bool flag32 = !flag30;
										if (!(flag32 || flag31))
										{
											array[6] = ")";
											string message = string.Concat(array);
											Debugger.Log(message);
											goto IL_0931;
										}
									}
								}
							}
						}
					}
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
				throw ex2;
			}
			goto IL_0931;
			IL_005d:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115B1E4 (inside System.Linq.Set`1<System.Object>::InternalGetHashCode +0xE4)");
			int num5 = (int)((long)intPtr & 1L);
			DOTween.useSafeMode = (byte)num5 != 0;
			goto IL_05bf;
		}

		[Token(Token = "0x6000016")]
		[Address(RVA = "0x107B4C0", Offset = "0x107B4C0", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1F00CE0]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, sequencesCapacity, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20269EC]) = v41;\nL_001B:\n\tgoto L_0029;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0029;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, sequencesCapacity, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0029:\n\tDG.Tweening.Core.TweenManager::SetCapacities(tweenersCapacity, sequencesCapacity);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetTweensCapacity(int tweenersCapacity, int sequencesCapacity)
		{
			TweenManager.SetCapacities(tweenersCapacity, sequencesCapacity);
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0x1070D88", Offset = "0x1070D88", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EBE350]);\n\tv19 = *([v18 @ X8_v22]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20269ED]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tDG.Tweening.Core.TweenManager::PurgeAll();\n\tDG.Tweening.Plugins.Core.PluginsManager::PurgeAll();\n\tv53 = destroy == 0;\n\tif (v53) goto L_006A;\n\tgoto L_0034;\n\tv64 = *([v56 @ X0_v4 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_0034;\n\tv99 = \"il2cpp_codegen_runtime_class_init\"(v56, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv68 = DG.Tweening.DOTween;\nL_0034:\n\tv71.initialized = 0;\n\tv74.useSafeMode = 0;\n\tv75.nestedTweenFailureBehaviour = 0;\n\tv76.showUnityEditorReport = 0;\n\tv77.drawGizmos = 1;\n\tv78.timeScale = 1f;\n\tv79.useSmoothDeltaTime = 0;\n\tDG.Tweening.DOTween::set_logBehaviour(2);\n\tv102.defaultEaseType = 6;\n\tv103.defaultEaseOvershootOrAmplitude = 1.70158f;\n\tv106.defaultEasePeriod = 0f;\n\tv107.defaultUpdateType = 0;\n\tv108.defaultTimeScaleIndependent = 0;\n\tv109.defaultAutoPlay = 3;\n\tv110.defaultLoopType = 0;\n\tv111.defaultAutoKill = 1;\n\tv112.defaultRecyclable = 0;\n\tv84.maxActiveSequencesReached = 0;\n\tv94.maxActiveTweenersReached = 0;\n\tDG.Tweening.Core.DOTweenComponent::DestroyInstance();\n\treturn;\nL_006A:\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Clear(bool destroy = false)
		{
			TweenManager.PurgeAll();
			PluginsManager.PurgeAll();
			if (destroy)
			{
				initialized = false;
				useSafeMode = false;
				nestedTweenFailureBehaviour = default(NestedTweenFailureBehaviour);
				showUnityEditorReport = false;
				drawGizmos = true;
				timeScale = 1f;
				useSmoothDeltaTime = false;
				logBehaviour = LogBehaviour.ErrorsOnly;
				defaultEaseType = Ease.OutQuad;
				defaultEaseOvershootOrAmplitude = 1.70158f;
				defaultEasePeriod = 0f;
				defaultUpdateType = default(UpdateType);
				defaultTimeScaleIndependent = false;
				defaultAutoPlay = AutoPlay.All;
				defaultLoopType = default(LoopType);
				defaultAutoKill = true;
				defaultRecyclable = false;
				maxActiveSequencesReached = 0;
				maxActiveTweenersReached = 0;
				DOTweenComponent.DestroyInstance();
			}
		}

		[Token(Token = "0x6000018")]
		[Address(RVA = "0x107B61C", Offset = "0x107B61C", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F0B570]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20269EE]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\tDG.Tweening.Core.TweenManager::PurgePools();\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ClearCachedTweens()
		{
			TweenManager.PurgePools();
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x107B678", Offset = "0x107B678", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB2C58]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20269EF]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\treturnVal1 = DG.Tweening.Core.TweenManager::Validate();\n\treturn returnVal1;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Validate()
		{
			return TweenManager.Validate();
		}

		[Token(Token = "0x600001A")]
		[Address(RVA = "0x107B6D4", Offset = "0x107B6D4", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1F00F48]);\n\tv27 = *([v26 @ X8_v19]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, v29, v30, v31, v32, v33, v34, v35, deltaTime, unscaledDeltaTime, v36, v37, v38, v39, v40, v41);\n\tv45 = 0 | 1;\n\t*([20269F0]) = v45;\nL_001D:\n\tgoto L_0023;\n\tv52 = *([v48 @ X0_v2 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0023;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, v29, v30, v31, v32, v33, v34, v35, deltaTime, unscaledDeltaTime, v36, v37, v38, v39, v40, v41);\nL_0023:\n\tDG.Tweening.DOTween::InitCheck();\n\tgoto L_0033;\n\tv65 = *([v61 @ X0_v4 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_0033;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v61, v29, v30, v31, v32, v33, v34, v35, deltaTime, unscaledDeltaTime, v36, v37, v38, v39, v40, v41);\n\tv69 = DG.Tweening.Core.TweenManager;\nL_0033:\n\tv74 = ~v72.hasActiveManualTweens;\n\tif (v74) goto L_0062;\n\tgoto L_0047;\n\tv87 = *([v76 @ X8_v9 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv88 = v87 == 0;\n\tv89 = ~v88;\n\tif (v89) goto L_0047;\n\tv127 = v76;\n\tv128 = \"il2cpp_codegen_runtime_class_init\"(v127, v29, v30, v31, v32, v33, v34, v35, deltaTime, unscaledDeltaTime, v36, v37, v38, v39, v40, v41);\n\tv95 = DG.Tweening.DOTween;\n\tv92 = DG.Tweening.Core.TweenManager;\nL_0047:\n\tgoto L_004D;\n\tv129 = *([v91 @ X0_v6+E0]);\n\tv130 = v129 == 0;\n\tv131 = ~v130;\n\tgoto L_004D;\n\tv133 = \"il2cpp_codegen_runtime_class_init\"(v91, v29, v30, v31, v32, v33, v34, v35, deltaTime, unscaledDeltaTime, v36, v37, v38, v39, v40, v41);\nL_004D:\n\tv108 = v96.timeScale * deltaTime;\n\tv106 = v96.timeScale * unscaledDeltaTime;\n\tDG.Tweening.Core.TweenManager::Update(3, v108, v106);\n\treturn;\nL_0062:\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ManualUpdate(float deltaTime, float unscaledDeltaTime)
		{
			InitCheck();
			if (TweenManager.hasActiveManualTweens)
			{
				float deltaTime2 = timeScale * deltaTime;
				float independentTime = timeScale * unscaledDeltaTime;
				TweenManager.Update(UpdateType.Manual, deltaTime2, independentTime);
			}
		}

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x107B89C", Offset = "0x107B89C", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1F019D8]);\n\tv31 = *([v30 @ X8_v11]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, setter, methodInfo, v34, v35, v36, v37, v38, endValue, duration, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20269F1]) = v47;\nL_001F:\n\tgoto L_0035;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0035;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, setter, methodInfo, v34, v35, v36, v37, v38, endValue, duration, v39, v40, v41, v42, v43, v44);\nL_0035:\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, endValue, duration, 0);\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<float, float, FloatOptions> To(DOGetter<float> getter, DOSetter<float> setter, float endValue, float duration)
		{
			return ApplyTo<float, float, FloatOptions>(getter, setter, endValue, duration);
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x107B938", Offset = "0x107B938", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1ED3BF0]);\n\tv31 = *([v30 @ X8_v11]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, setter, methodInfo, v34, v35, v36, v37, v38, endValue, duration, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20269F2]) = v47;\nL_001F:\n\tgoto L_0035;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0035;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, setter, methodInfo, v34, v35, v36, v37, v38, endValue, duration, v39, v40, v41, v42, v43, v44);\nL_0035:\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, endValue, duration, 0);\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<double, double, NoOptions> To(DOGetter<double> getter, DOSetter<double> setter, double endValue, float duration)
		{
			return ApplyTo<double, double, NoOptions>(getter, setter, endValue, duration);
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x107B9D4", Offset = "0x107B9D4", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1EE75D0]);\n\tv31 = *([v30 @ X8_v11]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, setter, endValue, methodInfo, v34, v35, v36, v37, duration, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20269F3]) = v47;\nL_001F:\n\tgoto L_0035;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0035;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, setter, endValue, methodInfo, v34, v35, v36, v37, duration, v38, v39, v40, v41, v42, v43, v44);\nL_0035:\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, endValue, duration, 0);\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<int, int, NoOptions> To(DOGetter<int> getter, DOSetter<int> setter, int endValue, float duration)
		{
			return ApplyTo<int, int, NoOptions>(getter, setter, endValue, duration);
		}

		[Token(Token = "0x600001E")]
		[Address(RVA = "0x107BA70", Offset = "0x107BA70", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1F10BB0]);\n\tv31 = *([v30 @ X8_v11]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, setter, endValue, methodInfo, v34, v35, v36, v37, duration, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20269F4]) = v47;\nL_001F:\n\tgoto L_0035;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0035;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, setter, endValue, methodInfo, v34, v35, v36, v37, duration, v38, v39, v40, v41, v42, v43, v44);\nL_0035:\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, endValue, duration, 0);\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<uint, uint, UintOptions> To(DOGetter<uint> getter, DOSetter<uint> setter, uint endValue, float duration)
		{
			return ApplyTo<uint, uint, UintOptions>(getter, setter, endValue, duration);
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x107BB0C", Offset = "0x107BB0C", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1EC3660]);\n\tv31 = *([v30 @ X8_v11]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, setter, endValue, methodInfo, v34, v35, v36, v37, duration, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20269F5]) = v47;\nL_001F:\n\tgoto L_0035;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0035;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, setter, endValue, methodInfo, v34, v35, v36, v37, duration, v38, v39, v40, v41, v42, v43, v44);\nL_0035:\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, endValue, duration, 0);\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<long, long, NoOptions> To(DOGetter<long> getter, DOSetter<long> setter, long endValue, float duration)
		{
			return ApplyTo<long, long, NoOptions>(getter, setter, endValue, duration);
		}

		[Token(Token = "0x6000020")]
		[Address(RVA = "0x107BBA8", Offset = "0x107BBA8", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1F0B418]);\n\tv31 = *([v30 @ X8_v11]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, setter, endValue, methodInfo, v34, v35, v36, v37, duration, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20269F6]) = v47;\nL_001F:\n\tgoto L_0035;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0035;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, setter, endValue, methodInfo, v34, v35, v36, v37, duration, v38, v39, v40, v41, v42, v43, v44);\nL_0035:\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, endValue, duration, 0);\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<ulong, ulong, NoOptions> To(DOGetter<ulong> getter, DOSetter<ulong> setter, ulong endValue, float duration)
		{
			return ApplyTo<ulong, ulong, NoOptions>(getter, setter, endValue, duration);
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x107BC44", Offset = "0x107BC44", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1EE9C60]);\n\tv31 = *([v30 @ X8_v11]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, setter, endValue, methodInfo, v34, v35, v36, v37, duration, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20269F7]) = v47;\nL_001F:\n\tgoto L_0035;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0035;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, setter, endValue, methodInfo, v34, v35, v36, v37, duration, v38, v39, v40, v41, v42, v43, v44);\nL_0035:\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, endValue, duration, 0);\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<string, string, StringOptions> To(DOGetter<string> getter, DOSetter<string> setter, string endValue, float duration)
		{
			return ApplyTo<string, string, StringOptions>(getter, setter, endValue, duration);
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0x107BCE0", Offset = "0x107BCE0", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv34 = *([1EFAA90]);\n\tv35 = *([v34 @ X8_v11]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, setter, methodInfo, v38, v39, v40, v41, v42, endValue, v0, duration, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20269F8]) = v50;\nL_0022:\n\tgoto L_003B;\n\tv57 = *([v53 @ X0_v2+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_003B;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v53, setter, methodInfo, v38, v39, v40, v41, v42, endValue, v0, duration, v43, v44, v45, v46, v47);\nL_003B:\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, endValue, duration, 0);\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector2, Vector2, VectorOptions> To(DOGetter<Vector2> getter, DOSetter<Vector2> setter, Vector2 endValue, float duration)
		{
			return ApplyTo<Vector2, Vector2, VectorOptions>(getter, setter, endValue, duration);
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x107BD8C", Offset = "0x107BD8C", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv38 = *([1ED6DC0]);\n\tv39 = *([v38 @ X8_v11]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, setter, methodInfo, v42, v43, v44, v45, v46, endValue, v0, v2, duration, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([20269F9]) = v53;\nL_0025:\n\tgoto L_0040;\n\tv60 = *([v56 @ X0_v2+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_0040;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v56, setter, methodInfo, v42, v43, v44, v45, v46, endValue, v0, v2, duration, v47, v48, v49, v50);\nL_0040:\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, endValue, duration, 0);\n\treturn returnVal1;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> To(DOGetter<Vector3> getter, DOSetter<Vector3> setter, Vector3 endValue, float duration)
		{
			return ApplyTo<Vector3, Vector3, VectorOptions>(getter, setter, endValue, duration);
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0x107BE40", Offset = "0x107BE40", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv42 = *([1EFB318]);\n\tv43 = *([v42 @ X8_v11]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, setter, methodInfo, v46, v47, v48, v49, v50, endValue, v0, v2, v3, duration, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([20269FA]) = v56;\nL_0028:\n\tgoto L_0045;\n\tv63 = *([v59 @ X0_v2+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tgoto L_0045;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v59, setter, methodInfo, v46, v47, v48, v49, v50, endValue, v0, v2, v3, duration, v51, v52, v53);\nL_0045:\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, endValue, duration, 0);\n\treturn returnVal1;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector4, Vector4, VectorOptions> To(DOGetter<Vector4> getter, DOSetter<Vector4> setter, Vector4 endValue, float duration)
		{
			return ApplyTo<Vector4, Vector4, VectorOptions>(getter, setter, endValue, duration);
		}

		[Token(Token = "0x6000025")]
		[Address(RVA = "0x107BF04", Offset = "0x107BF04", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv38 = *([1ED5820]);\n\tv39 = *([v38 @ X8_v11]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, setter, methodInfo, v42, v43, v44, v45, v46, endValue, v0, v2, duration, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([20269FB]) = v53;\nL_0025:\n\tgoto L_0040;\n\tv60 = *([v56 @ X0_v2+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_0040;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v56, setter, methodInfo, v42, v43, v44, v45, v46, endValue, v0, v2, duration, v47, v48, v49, v50);\nL_0040:\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, endValue, duration, 0);\n\treturn returnVal1;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Quaternion, Vector3, QuaternionOptions> To(DOGetter<Quaternion> getter, DOSetter<Quaternion> setter, Vector3 endValue, float duration)
		{
			return ApplyTo<Quaternion, Vector3, QuaternionOptions>(getter, setter, endValue, duration);
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0x107BFB8", Offset = "0x107BFB8", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = *([20269FC]) & 1;\n\tv39 = v38 == 0;\n\tv40 = ~v39;\n\tif (v40) goto L_0029;\n\treturnVal1 = 0x1084E0C(getter, setter, methodInfo, v45, v46, v47, v48, v49, endValue, endValue.g, endValue.b, endValue.a, duration, v50, v51, v52);\n\treturn returnVal1;\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([20269FC]) = X8;\nL_0029:\n\tgoto L_0046;\n\tv59 = *([v55 @ X0_v1+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tgoto L_0046;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v55, setter, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\nL_0046:\n\treturnVal2 = DG.Tweening.DOTween::ApplyTo(getter, setter, endValue, duration, 0);\n\treturn returnVal2;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Color, Color, ColorOptions> To(DOGetter<Color> getter, DOSetter<Color> setter, Color endValue, float duration)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [20269FC]");
			if (0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1084E0C (inside DG.Tweening.Plugins.LongPlugin::.ctor +0x1E8)");
				TweenerCore<Color, Color, ColorOptions> result = default(TweenerCore<Color, Color, ColorOptions>);
				return result;
			}
			return ApplyTo<Color, Color, ColorOptions>(getter, setter, endValue, duration);
		}

		[Token(Token = "0x6000027")]
		[Address(RVA = "0x107C07C", Offset = "0x107C07C", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv42 = *([1EE6088]);\n\tv43 = *([v42 @ X8_v11]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, setter, methodInfo, v46, v47, v48, v49, v50, endValue, v0, v2, v3, duration, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([20269FD]) = v56;\nL_0028:\n\tgoto L_0045;\n\tv63 = *([v59 @ X0_v2+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tgoto L_0045;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v59, setter, methodInfo, v46, v47, v48, v49, v50, endValue, v0, v2, v3, duration, v51, v52, v53);\nL_0045:\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, endValue, duration, 0);\n\treturn returnVal1;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Rect, Rect, RectOptions> To(DOGetter<Rect> getter, DOSetter<Rect> setter, Rect endValue, float duration)
		{
			return ApplyTo<Rect, Rect, RectOptions>(getter, setter, endValue, duration);
		}

		[Token(Token = "0x6000028")]
		[Address(RVA = "0x107C140", Offset = "0x107C140", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1EC9C60]);\n\tv31 = *([v30 @ X8_v11]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, setter, endValue, methodInfo, v34, v35, v36, v37, duration, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20269FE]) = v47;\nL_001F:\n\tgoto L_0035;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0035;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, setter, endValue, methodInfo, v34, v35, v36, v37, duration, v38, v39, v40, v41, v42, v43, v44);\nL_0035:\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, endValue, duration, 0);\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener To(DOGetter<RectOffset> getter, DOSetter<RectOffset> setter, RectOffset endValue, float duration)
		{
			return ApplyTo<RectOffset, RectOffset, NoOptions>(getter, setter, endValue, duration);
		}

		[Token(Token = "0x6000029")]
		[Address(RVA = "0x13632B8", Offset = "0x13632B8", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv46 = *([1F026B0]);\n\tv47 = *([v46 @ X8_v10]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, getter, setter, endValue, methodInfo, v50, v51, v52, duration, v33, v31, v29, v53, v54, v55, v56);\n\tv59 = 0 | 1;\n\t*([2028846]) = v59;\nL_0027:\n\tgoto L_002D;\n\tv66 = *([v62 @ X0_v2+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tgoto L_002D;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v62, getter, setter, endValue, methodInfo, v50, v51, v52, duration, v33, v31, v29, v53, v54, v55, v56);\nL_002D:\n\tv73 = *([endValue @ X3 (T2)+30]);\n\tv77 = *([v73 @ X8_v7]);\n\tv82 = *([v77 @ X3_v1]);\n\t// 67 IndirectJump v82 @ X4_v1, getter @ X1 (DG.Tweening.Core.DOGetter`1<T1>), getter @ X1 (DG.Tweening.Core.DOGetter`1<T1>), setter @ X2 (DG.Tweening.Core.DOSetter`1<T1>), plugin @ X0 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>), v77 @ X3_v1, v82 @ X4_v1, v50 @ X5, v51 @ X6, v52 @ X7, duration @ V0 (System.Single), v33 @ V1, v31 @ V2, v29 @ V3, v53 @ V4, v54 @ V5, v55 @ V6, v56 @ V7\n\treturn X0;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<T1, T2, TPlugOptions> To<T1, T2, TPlugOptions>(ABSTweenPlugin<T1, T2, TPlugOptions> plugin, DOGetter<T1> getter, DOSetter<T1> setter, T2 endValue, float duration) where TPlugOptions : struct, IPlugOptions
		{
			//IL_0015: Expected O, but got I
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [endValue @ X3 (T2)+30]");
				object obj = 0;
				object obj2 = obj;
				object obj3 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v82 @ X4_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600002A")]
		[Address(RVA = "0x107C1DC", Offset = "0x107C1DC", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv34 = *([1EBC4F8]);\n\tv35 = *([v34 @ X8_v11]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, setter, axisConstraint, methodInfo, v38, v39, v40, v41, endValue, duration, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20269FF]) = v50;\nL_0021:\n\tv52 = 0;\n\tv58 = 0x1586898(&v52 @ stack_-50_v1, 0, axisConstraint, methodInfo, v38, v39, v40, v41, endValue, endValue, endValue, v43, v44, v45, v46, v47);\n\tgoto L_0039;\n\tv65 = *([v61 @ X0_v4+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tgoto L_0039;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v61, v56, axisConstraint, methodInfo, v38, v39, v40, v41, v53, v54, v55, v43, v44, v45, v46, v47);\nL_0039:\n\t// 57 MakeStruct v83 @ AGG107C290_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v75 @ stack_-4C, 0\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, v83, duration, 0);\n\treturnVal1.plugOptions = axisConstraint;\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> ToAxis(DOGetter<Vector3> getter, DOSetter<Vector3> setter, float endValue, float duration, AxisConstraint axisConstraint = AxisConstraint.X)
		{
			//IL_0068: Expected O, but got I4
			//IL_0020: Expected F4, but got O
			//IL_005a: Expected O, but got I4
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			Vector3 endValue2 = default(Vector3);
			endValue2.x = 0f;
			object obj2 = default(object);
			endValue2.y = (float)obj2;
			endValue2.z = 0f;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ApplyTo<Vector3, Vector3, VectorOptions>(getter, setter, endValue2, duration);
			tweenerCore.plugOptions = (VectorOptions)axisConstraint;
			return tweenerCore;
		}

		[Token(Token = "0x600002B")]
		[Address(RVA = "0x107C2B8", Offset = "0x107C2B8", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1ED04D8]);\n\tv31 = *([v30 @ X8_v11]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, setter, methodInfo, v34, v35, v36, v37, v38, endValue, duration, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2026A00]) = v47;\nL_001F:\n\tv49 = 0;\n\tv56 = 0x101059C(&v49 @ stack_-50_v1, 0, methodInfo, v34, v35, v36, v37, v38, 0, 0, 0, endValue, v41, v42, v43, v44);\n\tgoto L_0039;\n\tv63 = *([v59 @ X0_v4+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tgoto L_0039;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v59, v54, methodInfo, v34, v35, v36, v37, v38, v50, v51, v52, v53, v41, v42, v43, v44);\nL_0039:\n\t// 57 MakeStruct v83 @ AGG107C368_2_v1 (UnityEngine.Color), typeof(UnityEngine.Color), 0, v73 @ stack_-4C, 0, v76 @ stack_-44\n\tv84 = DG.Tweening.DOTween::ApplyTo(getter, setter, v83, duration, 0);\n\tv88 = DG.Tweening.TweenSettingsExtensions::SetOptions(v84, 1);\n\treturn v84;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Color, Color, ColorOptions> ToAlpha(DOGetter<Color> getter, DOSetter<Color> setter, float endValue, float duration)
		{
			//IL_007a: Expected O, but got I4
			//IL_0020: Expected F4, but got O
			//IL_003b: Expected F4, but got O
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
			Color endValue2 = default(Color);
			endValue2.r = 0f;
			object obj2 = default(object);
			endValue2.g = (float)obj2;
			endValue2.b = 0f;
			object obj3 = default(object);
			endValue2.a = (float)obj3;
			TweenerCore<Color, Color, ColorOptions> tweenerCore = ApplyTo<Color, Color, ColorOptions>(getter, setter, endValue2, duration);
			Tweener tweener = tweenerCore.SetOptions(alphaOnly: true);
			return tweenerCore;
		}

		[Token(Token = "0x600002C")]
		[Address(RVA = "0x107C398", Offset = "0x107C398", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv32 = *([1EC9550]);\n\tv33 = *([v32 @ X8_v22]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, startValue, endValue, duration, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2026A01]) = v49;\nL_001D:\n\tv53 = new DG.Tweening.DOTween+<>c__DisplayClass55_0();\n\tSystem.Object::.ctor(v53);\n\tv53.setter = setter;\n\tv53.v = startValue;\n\tv60 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v60, v53, Il2CppMethodInfo);\n\tv74 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v74, v53, Il2CppMethodInfo);\n\tgoto L_004F;\n\tv121 = *([v117 @ X0_v10+E0]);\n\tv122 = v121 == 0;\n\tv123 = ~v122;\n\tif (v123) goto L_004F;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v117, v113, v86, v84, v38, v39, v40, v41, startValue, endValue, duration, v42, v43, v44, v45, v46);\nL_004F:\n\tv129 = DG.Tweening.DOTween::To(v60, v74, endValue, duration);\n\treturnVal2 = DG.Tweening.Core.Extensions::NoFrom(v129);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener To(DOSetter<float> setter, float startValue, float endValue, float duration)
		{
			DOGetter<float> getter = () => startValue;
			DOSetter<float> setter2 = delegate(float x)
			{
				startValue = x;
				setter(x);
			};
			TweenerCore<float, float, FloatOptions> t = To(getter, setter2, endValue, duration);
			return t.NoFrom();
		}

		[Token(Token = "0x600002D")]
		[Address(RVA = "0x107C4DC", Offset = "0x107C4DC", Length = "0x340")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tv58 = *([1ED0160]);\n\tv59 = *([v58 @ X8_v47]);\n\tv60 = \"il2cpp_codegen_initialize_method\"(v59, setter, vibrato, methodInfo, v62, v63, v64, v65, direction, v0, v2, duration, elasticity, v66, v67, v68);\n\tv71 = 0 | 1;\n\t*([2026A02]) = v71;\nL_0035:\n\tv84 = elasticity > 1f;\n\tif (v84) goto L_0046;\n\tv95 = elasticity >= 0;\n\tif (v95) goto L_0046;\nL_0046:\n\tv110 = 0x158AD58(&v108 @ stack_-A0_v2 (UnityEngine.Vector3), 0, vibrato, methodInfo, v62, v63, v64, v65, direction, direction.y, direction.z, duration, elasticity, v66, v67, v68);\n\tv159 = vibrato * duration;\n\tv120 = v159 - 2;\n\tv121 = v120 < 0;\n\tv122 = v120 == 0;\n\tv123 = v159 ^ 2;\n\tv124 = v159 ^ v120;\n\tv125 = v123 & v124;\n\tv126 = v125 < 0;\n\tv128 = v121 == v126;\n\tv129 = ~v122;\n\tv130 = v128 & v129;\n\tv131 = ~v130;\n\tif (v131) goto L_FFFFFFFF;\n\tgoto L_0062;\nL_0062:\n\t// 98 NewArr v136 @ X0_v5 (System.Single[]), typeof(System.Single[]), v134 @ X22_v2 (System.Single)\n\tv148 = v134 < 1;\n\tif (v148) goto L_0165;\n\tv154 = direction / v134;\nL_0079:\n\tv345 = v342 < v136.Length;\n\tv346 = ~v345;\n\tif (v346) goto L_0194;\n\tv152 = v342 + 1;\n\tv432 = v152 / v134;\n\tv182 = v432 * duration;\n\tv159 = v159 + v182;\n\tv136[v342 @ X8_v21 (System.Int32)] = v182;\n\tv325 = v152 < v134;\n\tif (v325) goto L_0079;\n\tv162 = v134 < 1;\n\tif (v162) goto L_0165;\n\tv378 = duration / v159;\nL_00A6:\n\tv579 = v470 < v136.Length;\n\tv463 = ~v579;\n\tif (v463) goto L_0194;\n\tv423 = v378 * v136[v470 @ X8_v25 (System.Int32)];\n\tv136[v470 @ X8_v25 (System.Int32)] = v423;\n\tv470 = v470 + 1;\n\tv561 = v470 < v134;\n\tif (v561) goto L_00A6;\n\t// 196 NewArr v408 @ X0_v23 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), v134 @ X22_v2 (System.Single)\n\tv417 = v134 - 1;\n\tv381 = v134 < 1;\n\tif (v381) goto L_016D;\n\tv225 = v408 + 0x28;\nL_00E1:\n\tv254 = v231 >= v417;\n\tif (v254) goto L_0107;\n\tv602 = v231 == 0;\n\tif (v602) goto L_0124;\n\tv609 = v231 & 1;\n\tv610 = v609 == 0;\n\tv611 = ~v610;\n\tif (v611) goto L_012D;\n\tgoto L_00FB;\n\tv622 = *([v607 @ X0_v31+E0]);\n\tv623 = v622 == 0;\n\tv624 = ~v623;\n\tif (v624) goto L_00FB;\n\tv626 = \"il2cpp_codegen_runtime_class_init\"(v607, v237, vibrato, methodInfo, v62, v63, v64, v65, v250, v317, v311, v213, elasticity, v66, v67, v68);\nL_00FB:\n\t// 251 MakeStruct v208 @ AGG107C6A8_0_v8 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v108 @ stack_-A0_v2 (UnityEngine.Vector3), direction.y (System.Single), direction.z (System.Single)\n\tv655 = UnityEngine.Vector3::ClampMagnitude(v208, v415);\n\tv669 = v655.y;\n\tv668 = v655.z;\n\tv646 = v408 == 0;\n\tv287 = ~v646;\n\tif (v287) goto L_0143;\n\tgoto L_0199;\nL_0107:\n\tgoto L_010E;\n\tv612 = *([v603 @ X0_v26+E0]);\n\tv613 = v612 == 0;\n\tv614 = ~v613;\n\tif (v614) goto L_010E;\n\tv616 = \"il2cpp_codegen_runtime_class_init\"(v603, v237, vibrato, methodInfo, v62, v63, v64, v65, v250, v317, v311, v213, elasticity, v66, v67, v68);\nL_010E:\n\tv249 = UnityEngine.Vector3::get_zero();\n\tv645 = v231 < v408.Length;\n\tv464 = ~v645;\n\tif (v464) goto L_0194;\n\t*([v225 @ X26_v6-8]) = v249;\n\t*([v225 @ X26_v6-4]) = v249.y;\n\t*([v225 @ X26_v6]) = v249.z;\n\tgoto L_0152;\nL_0124:\n\t;\n\tv468 = v408.Length == 0;\n\tif (v468) goto L_0194;\n\tgoto L_014E;\nL_012D:\n\tgoto L_0133;\n\tv631 = *([v607 @ X0_v31+E0]);\n\tv632 = v631 == 0;\n\tv633 = ~v632;\n\tif (v633) goto L_0133;\n\tv635 = \"il2cpp_codegen_runtime_class_init\"(v607, v237, vibrato, methodInfo, v62, v63, v64, v65, v250, v317, v311, v213, elasticity, v66, v67, v68);\nL_0133:\n\tv214 = v97 * v415;\n\t// 312 MakeStruct v204 @ AGG107C72C_0_v8 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v108 @ stack_-A0_v2 (UnityEngine.Vector3), direction.y (System.Single), direction.z (System.Single)\n\tv641 = UnityEngine.Vector3::ClampMagnitude(v204, v214);\n\tv655 = UnityEngine.Vector3::op_UnaryNegation(v641);\n\tv669 = v655.y;\n\tv668 = v655.z;\nL_0143:\n\t;\n\tv672 = v231 < v408.Length;\n\tv465 = ~v672;\n\tif (v465) goto L_0194;\nL_014E:\n\t*([v225 @ X26_v6-8]) = v655;\n\t*([v225 @ X26_v6-4]) = v669;\n\t*([v225 @ X26_v6]) = v668;\n\tv670 = v415 - v154;\nL_0152:\n\tv231 = v231 + 1;\n\tv225 = v225 + 0xC;\n\tv382 = v231 < v134;\n\tif (v382) goto L_00E1;\n\tgoto L_016D;\nL_0165:\n\t// 357 NewArr v190 @ X0_v15 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), v134 @ X22_v2 (System.Single)\nL_016D:\n\tgoto L_0177;\n\tv542 = *([v427 @ X0_v7+E0]);\n\tv543 = v542 == 0;\n\tv544 = ~v543;\n\tgoto L_0177;\n\tv546 = \"il2cpp_codegen_runtime_class_init\"(v427, v372, vibrato, methodInfo, v62, v63, v64, v65, v377, v422, v420, v360, elasticity, v66, v67, v68);\nL_0177:\n\tv551 = DG.Tweening.DOTween::ToArray(getter, setter, v419, v136);\n\tv557 = DG.Tweening.Core.Extensions::NoFrom(v551);\n\treturnVal2 = DG.Tweening.Core.Extensions::SetSpecialStartupMode(v557, 3);\n\treturn returnVal2;\nL_0194:\n\tv477 = new System.IndexOutOfRangeException();\n\tthrow v477;\nL_0199:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 276 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> Punch(DOGetter<Vector3> getter, DOSetter<Vector3> setter, Vector3 direction, float duration, int vibrato = 10, float elasticity = 1f)
		{
			//IL_0573: Unknown result type (might be due to invalid IL or missing references)
			//IL_0578: Expected O, but got Unknown
			//IL_0585: Expected O, but got F4
			//IL_01dd: Expected O, but got I
			//IL_0337: Expected O, but got F4
			//IL_0690: Expected O, but got I
			//IL_0450: Expected O, but got F4
			//IL_046c: Expected O, but got F4
			bool flag = elasticity > 1f;
			float num = 1f;
			if (!flag)
			{
				bool flag2 = !(elasticity < 0f);
				num = elasticity;
				if (!flag2)
				{
					num = 0f;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158AD58 (inside UnityEngine.Vector3::ClampMagnitude +0xDC)");
			float num2 = (float)vibrato * duration;
			float num3 = num2 - 3E-45f;
			bool flag3 = num3 < 0f;
			bool flag4 = num3 == 0f;
			object obj = num2 ^ 2;
			object obj2 = num2 ^ num3;
			int num4 = (int)((long)(IntPtr)obj & (long)(IntPtr)obj2);
			bool flag5 = num4 < 0;
			bool flag6 = flag3 == flag5;
			bool flag7 = !flag4;
			float num5 = ((!(flag6 && flag7)) ? 3E-45f : num2);
			float[] array = new float[num5];
			bool flag8 = num5 < float.Epsilon;
			float z = direction.z;
			if (flag8)
			{
				goto IL_047e;
			}
			Vector3 vector = default(Vector3);
			float num6 = vector.x / num5;
			num2 = 0f;
			int num7 = 0;
			while (num7 < array.Length)
			{
				int num8 = num7 + 1;
				float num9 = (float)num8 / num5;
				z = num9 * duration;
				num2 += z;
				array[num7] = z;
				bool flag9 = (float)num8 < num5;
				num7 = num8;
				if (flag9)
				{
					continue;
				}
				goto IL_00f7;
			}
			goto IL_04da;
			IL_04da:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_0471:
			Vector3[] array2;
			Vector3[] endValues = array2;
			goto IL_0498;
			IL_0498:
			TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = ToArray(getter, setter, endValues, array);
			TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t2 = t.NoFrom();
			return t2.SetSpecialStartupMode(SpecialStartupMode.SetPunch);
			IL_018a:
			array2 = new Vector3[num5];
			float num10 = num5 - float.Epsilon;
			bool flag10 = num5 < float.Epsilon;
			endValues = array2;
			if (!flag10)
			{
				object obj3 = (long)(IntPtr)array2 + 40L;
				int num11 = 0;
				Vector3 vector2 = direction;
				Vector3 vector3 = default(Vector3);
				Vector3 vector4 = default(Vector3);
				Vector3 vector6 = default(Vector3);
				while (true)
				{
					if ((float)num11 < num10)
					{
						float z2;
						if (num11 != 0)
						{
							if ((num11 & 1) == 0)
							{
								vector3.x = vector4.x;
								vector3.y = direction.y;
								vector3.z = direction.z;
								Vector3 vector5 = Vector3.ClampMagnitude(vector3, vector2.x);
								float y = vector5.y;
								z2 = vector5.z;
								if (array2 == null)
								{
									return (TweenerCore<Vector3, Vector3[], Vector3ArrayOptions>)(object)new NullReferenceException();
								}
							}
							else
							{
								float maxLength = num * vector2.x;
								vector6.x = vector4.x;
								vector6.y = direction.y;
								vector6.z = direction.z;
								Vector3 vector7 = Vector3.ClampMagnitude(vector6, maxLength);
								Vector3 vector5 = -vector7;
								float y = vector5.y;
								z2 = vector5.z;
							}
							if (num11 >= array2.Length)
							{
								break;
							}
						}
						else
						{
							if (array2.Length == 0)
							{
								break;
							}
							Vector3 vector5 = vector4;
							z2 = direction.z;
							float y = direction.y;
						}
						obj3 = z2;
						float num12 = vector2.x - num6;
						vector2 = (Vector3)num12;
					}
					else
					{
						Vector3 zero = Vector3.zero;
						if (num11 >= array2.Length)
						{
							break;
						}
						_ = zero.y;
						obj3 = zero.z;
					}
					num11++;
					obj3 = (long)(IntPtr)obj3 + 12L;
					if ((float)num11 < num5)
					{
						continue;
					}
					goto IL_0471;
				}
				goto IL_04da;
			}
			goto IL_0498;
			IL_047e:
			Vector3[] array3 = new Vector3[num5];
			endValues = array3;
			goto IL_0498;
			IL_00f7:
			if (num5 < float.Epsilon)
			{
				goto IL_047e;
			}
			float num13 = duration / num2;
			int num14 = 0;
			while (num14 < array.Length)
			{
				float num15 = num13 * array[num14];
				array[num14] = num15;
				num14++;
				if ((float)num14 < num5)
				{
					continue;
				}
				goto IL_018a;
			}
			goto IL_04da;
		}

		[Token(Token = "0x600002E")]
		[Address(RVA = "0x107CA20", Offset = "0x107CA20", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv46 = *([1ED2518]);\n\tv47 = *([v46 @ X8_v9]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, setter, vibrato, ignoreZAxis, fadeOut, methodInfo, v50, v51, duration, strength, randomness, v52, v53, v54, v55, v56);\n\tv59 = 0 | 1;\n\t*([2026A03]) = v59;\nL_0027:\n\tv61 = 0;\n\tv67 = 0x1586898(&v61 @ stack_-70_v1, 0, vibrato, ignoreZAxis, fadeOut, methodInfo, v50, v51, strength, strength, strength, v52, v53, v54, v55, v56);\n\tgoto L_0040;\n\tv74 = *([v70 @ X0_v4+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tgoto L_0040;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v70, v65, vibrato, ignoreZAxis, fadeOut, methodInfo, v50, v51, v62, v63, v64, v52, v53, v54, v55, v56);\nL_0040:\n\t// 64 MakeStruct v93 @ AGG107CAEC_3_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v83 @ stack_-6C, 0\n\treturnVal1 = DG.Tweening.DOTween::Shake(getter, setter, duration, v93, vibrato, randomness, ignoreZAxis, 0, fadeOut);\n\treturn returnVal1;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> Shake(DOGetter<Vector3> getter, DOSetter<Vector3> setter, float duration, float strength = 3f, int vibrato = 10, float randomness = 90f, bool ignoreZAxis = true, bool fadeOut = true)
		{
			//IL_006a: Expected O, but got I4
			//IL_0020: Expected F4, but got O
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			Vector3 strength2 = default(Vector3);
			strength2.x = 0f;
			object obj2 = default(object);
			strength2.y = (float)obj2;
			strength2.z = 0f;
			return Shake(getter, setter, duration, strength2, vibrato, randomness, ignoreZAxis, vectorBased: false, fadeOut);
		}

		[Token(Token = "0x600002F")]
		[Address(RVA = "0x107D0A0", Offset = "0x107D0A0", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv50 = *([1EC58C0]);\n\tv51 = *([v50 @ X8_v9]);\n\tv52 = \"il2cpp_codegen_initialize_method\"(v51, setter, vibrato, fadeOut, methodInfo, v54, v55, v56, duration, strength, v0, v2, randomness, v57, v58, v59);\n\tv62 = 0 | 1;\n\t*([2026A04]) = v62;\nL_002B:\n\tgoto L_004A;\n\tv69 = *([v65 @ X0_v2+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tgoto L_004A;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v65, setter, vibrato, fadeOut, methodInfo, v54, v55, v56, duration, strength, v0, v2, randomness, v57, v58, v59);\nL_004A:\n\treturnVal1 = DG.Tweening.DOTween::Shake(getter, setter, duration, strength, vibrato, randomness, 0, 1, fadeOut);\n\treturn returnVal1;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> Shake(DOGetter<Vector3> getter, DOSetter<Vector3> setter, float duration, Vector3 strength, int vibrato = 10, float randomness = 90f, bool fadeOut = true)
		{
			return Shake(getter, setter, duration, strength, vibrato, randomness, ignoreZAxis: false, vectorBased: true, fadeOut);
		}

		[Token(Token = "0x6000030")]
		[Address(RVA = "0x107CB10", Offset = "0x107CB10", Length = "0x590")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\n\tv71 = *([1EEE9F8]);\n\tv72 = *([v71 @ X8_v65]);\n\tv73 = \"il2cpp_codegen_initialize_method\"(v72, setter, vibrato, ignoreZAxis, vectorBased, fadeOut, methodInfo, v75, duration, strength, v0, v2, randomness, v76, v77, v78);\n\tv81 = 0 | 1;\n\t*([2026A05]) = v81;\nL_0031:\n\tv83 = vectorBased == 0;\n\tif (v83) goto L_003A;\n\tv87 = 0x158AD58(&v90 @ stack_-B0_v2 (UnityEngine.Vector3), 0, vibrato, ignoreZAxis, vectorBased, fadeOut, methodInfo, v75, duration, strength, strength.y, strength.z, randomness, v76, v77, v78);\nL_003A:\n\tv96 = vibrato * duration;\n\tv102 = v96 - 2;\n\tv103 = v102 < 0;\n\tv104 = v102 == 0;\n\tv105 = v96 ^ 2;\n\tv106 = v96 ^ v102;\n\tv107 = v105 & v106;\n\tv108 = v107 < 0;\n\tv109 = v103 == v108;\n\tv110 = ~v104;\n\tv111 = v109 & v110;\n\tv112 = ~v111;\n\tif (v112) goto L_FFFFFFFF;\n\tgoto L_0052;\nL_0052:\n\t// 82 NewArr v118 @ X0_v4 (System.Single[]), typeof(System.Single[]), v115 @ X26_v1 (System.Int32)\n\tv130 = v115 < 1;\n\tif (v130) goto L_00B9;\n\tv132 = duration / v115;\nL_0067:\n\tv215 = fadeOut == 0;\n\tif (v215) goto L_0070;\n\tv222 = v192 + 1;\n\tv224 = v222 / v115;\n\tv181 = v224 * duration;\nL_0070:\n\tv240 = v192 < v118.Length;\n\tv241 = ~v240;\n\tif (v241) goto L_0279;\n\tv118[v192 @ X9_v6 (System.Int32)] = v181;\n\tv192 = v192 + 1;\n\tv191 = v191 + v181;\n\tv194 = v192 < v115;\n\tif (v194) goto L_0067;\n\tv153 = v115 < 1;\n\tif (v153) goto L_00B9;\n\tv141 = duration / v191;\nL_0099:\n\tv794 = v595 < v118.Length;\n\tv625 = ~v794;\n\tif (v625) goto L_0279;\n\tv147 = v141 * v118[v595 @ X9_v9 (System.Int32)];\n\tv118[v595 @ X9_v9 (System.Int32)] = v147;\n\tv595 = v595 + 1;\n\tv152 = v595 < v115;\n\tif (v152) goto L_0099;\nL_00B9:\n\tv189 = UnityEngine.Random::Range(0f, 360f);\n\t// 191 NewArr v221 @ X0_v13 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), v115 @ X26_v1 (System.Int32)\n\tv236 = v115 - 1;\n\tv239 = v115 < 1;\n\tif (v239) goto L_024F;\n\tv478 = v896 / v115;\n\tv340 = -randomness;\n\tv464 = v221 + 0x28;\nL_00E5:\n\tv384 = v347 >= v236;\n\tif (v384) goto L_019F;\n\tv383 = v347 < 1;\n\tif (v383) goto L_00FB;\n\tv770 = UnityEngine.Random::Range(v340, randomness);\n\tv773 = v563 + -180f;\n\tv563 = v773 + v770;\nL_00FB:\n\tv777 = vectorBased == 0;\n\tif (v777) goto L_01BC;\n\tv799 = UnityEngine.Random::Range(v340, randomness);\n\tgoto L_010D;\n\tv820 = *([v806 @ X0_v47+E0]);\n\tv821 = v820 == 0;\n\tv822 = ~v821;\n\tif (v822) goto L_010D;\n\tv824 = \"il2cpp_codegen_runtime_class_init\"(v806, v218, vibrato, ignoreZAxis, vectorBased, fadeOut, methodInfo, v75, v799, v797, v653, v468, v311, v306, v301, v78);\nL_010D:\n\tv828 = UnityEngine.Vector3::get_up();\n\tgoto L_0125;\n\tv904 = *([v848 @ X0_v50+E0]);\n\tv905 = v904 == 0;\n\tv906 = ~v905;\n\tif (v906) goto L_0125;\n\tv908 = \"il2cpp_codegen_runtime_class_init\"(v848, v218, vibrato, ignoreZAxis, vectorBased, fadeOut, methodInfo, v75, v828, v841, v842, v468, v311, v306, v301, v78);\nL_0125:\n\tv916 = UnityEngine.Quaternion::AngleAxis(v799, v828);\n\tgoto L_0139;\n\tv954 = *([v933 @ X0_v53 (Il2CppClass<DG.Tweening.Core.Utils>)+E0]);\n\tv955 = v954 == 0;\n\tv956 = ~v955;\n\tif (v956) goto L_0139;\n\tv958 = \"il2cpp_codegen_runtime_class_init\"(v933, v218, vibrato, ignoreZAxis, vectorBased, fadeOut, methodInfo, v75, v916, v930, v931, v932, v311, v306, v301, v78);\nL_0139:\n\tv962 = DG.Tweening.Core.Utils::Vector3FromAngle(v563, v896);\n\tv977 = UnityEngine.Quaternion::op_Multiply(v916, v962);\n\tv992 = UnityEngine.Vector3::ClampMagnitude(v977, v90);\n\t// 342 MakeStruct v280 @ AGG107CE04_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v992 @ V0_v38 (UnityEngine.Vector3), v977.y (System.Single), v977.z (System.Single)\n\tv1004 = UnityEngine.Vector3::ClampMagnitude(v280, v557);\n\t// 351 MakeStruct v275 @ AGG107CE1C_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v992 @ V0_v38 (UnityEngine.Vector3), v1004.y (System.Single), v977.z (System.Single)\n\tv367 = UnityEngine.Vector3::ClampMagnitude(v275, v555);\n\tv1009 = v347 < v221.Length;\n\tv626 = ~v1009;\n\tif (v626) goto L_0279;\n\t*([v464 @ X19_v7-8]) = v992;\n\t*([v464 @ X19_v7-4]) = v1004.y;\n\t*([v464 @ X19_v7]) = v367.z;\n\tv1013 = v896 - v478;\n\tv881 = fadeOut == 0;\n\tv872 = ~v881;\n\tv863 = ~v872;\n\tif (v863) goto L_0188;\n\tgoto L_0188;\nL_0188:\n\tgoto L_0193;\n\tv1019 = *([v1010 @ X0_v59+E0]);\n\tv1020 = v1019 == 0;\n\tv1021 = ~v1020;\n\tgoto L_0193;\n\tv1023 = \"il2cpp_codegen_runtime_class_init\"(v1010, v218, vibrato, ignoreZAxis, vectorBased, fadeOut, methodInfo, v75, v1013, v375, v472, v467, v310, v305, v300, v78);\nL_0193:\n\t// 403 MakeStruct v862 @ AGG107CE7C_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v90 @ stack_-B0_v2 (UnityEngine.Vector3), v557 @ stack_-AC_v6 (System.Single), v555 @ stack_-A8_v6 (System.Single)\n\tv868 = UnityEngine.Vector3::ClampMagnitude(v862, v896);\n\tgoto L_023B;\nL_019F:\n\tgoto L_01A6;\n\tv778 = *([v758 @ X0_v24+E0]);\n\tv779 = v778 == 0;\n\tv780 = ~v779;\n\tif (v780) goto L_01A6;\n\tv782 = \"il2cpp_codegen_runtime_class_init\"(v758, v218, vibrato, ignoreZAxis, vectorBased, fadeOut, methodInfo, v75, v639, v640, v653, v468, v311, v306, v301, v78);\nL_01A6:\n\tv368 = UnityEngine.Vector3::get_zero();\n\tv819 = v347 < v221.Length;\n\tv627 = ~v819;\n\tif (v627) goto L_0279;\n\t*([v464 @ X19_v7-8]) = v368;\n\t*([v464 @ X19_v7-4]) = v368.y;\n\t*([v464 @ X19_v7]) = v368.z;\n\tgoto L_023B;\nL_01BC:\n\tv802 = ignoreZAxis == 0;\n\tif (v802) goto L_01D4;\n\tgoto L_01CA;\n\tv829 = *([v811 @ X0_v43 (Il2CppClass<DG.Tweening.Core.Utils>)+E0]);\n\tv830 = v829 == 0;\n\tv831 = ~v830;\n\tif (v831) goto L_01CA;\n\tv832 = \"il2cpp_codegen_runtime_class_init\"(v811, v218, vibrato, ignoreZAxis, vectorBased, fadeOut, methodInfo, v75, v771, v772, v653, v468, v311, v306, v301, v78);\nL_01CA:\n\tv592 = DG.Tweening.Core.Utils::Vector3FromAngle(v563, v896);\n\tv594 = v592.y;\n\tv637 = v592.z;\n\tv852 = v221 == 0;\n\tv432 = ~v852;\n\tif (v432) goto L_021F;\n\tgoto L_027E;\nL_01D4:\n\tv818 = UnityEngine.Random::Range(v340, randomness);\n\tgoto L_01E1;\n\tv853 = *([v836 @ X0_v31+E0]);\n\tv854 = v853 == 0;\n\tv855 = ~v854;\n\tif (v855) goto L_01E1;\n\tv857 = \"il2cpp_codegen_runtime_class_init\"(v836, v218, vibrato, ignoreZAxis, vectorBased, fadeOut, methodInfo, v75, v818, v816, v653, v468, v311, v306, v301, v78);\nL_01E1:\n\tv861 = UnityEngine.Vector3::get_up();\n\tgoto L_01F9;\n\tv941 = *([v926 @ X0_v34+E0]);\n\tv942 = v941 == 0;\n\tv943 = ~v942;\n\tif (v943) goto L_01F9;\n\tv945 = \"il2cpp_codegen_runtime_class_init\"(v926, v218, vibrato, ignoreZAxis, vectorBased, fadeOut, methodInfo, v75, v861, v919, v920, v468, v311, v306, v301, v78);\nL_01F9:\n\tv953 = UnityEngine.Quaternion::AngleAxis(v818, v861);\n\tgoto L_020D;\n\tv978 = *([v966 @ X0_v37 (Il2CppClass<DG.Tweening.Core.Utils>)+E0]);\n\tv979 = v978 == 0;\n\tv980 = ~v979;\n\tif (v980) goto L_020D;\n\tv982 = \"il2cpp_codegen_runtime_class_init\"(v966, v218, vibrato, ignoreZAxis, vectorBased, fadeOut, methodInfo, v75, v953, v963, v964, v965, v311, v306, v301, v78);\nL_020D:\n\tv986 = DG.Tweening.Core.Utils::Vector3FromAngle(v563, v896);\n\tv592 = UnityEngine.Quaternion::op_Multiply(v953, v986);\n\tv594 = v592.y;\n\tv637 = v592.z;\nL_021F:\n\t;\n\tv918 = v347 < v221.Length;\n\tv628 = ~v918;\n\tif (v628) goto L_0279;\n\t*([v464 @ X19_v7-8]) = v592;\n\t*([v464 @ X19_v7-4]) = v594;\n\t*([v464 @ X19_v7]) = v637;\n\tv882 = fadeOut == 0;\n\tv869 = v896 - v478;\n\tv873 = ~v882;\n\tv864 = ~v873;\n\tif (v864) goto L_023B;\n\tgoto L_023B;\nL_023B:\n\tv347 = v347 + 1;\n\tv464 = v464 + 0xC;\n\tv532 = v347 < v115;\n\tif (v532) goto L_00E5;\nL_024F:\n\tgoto L_0259;\n\tv655 = *([v576 @ X0_v15+E0]);\n\tv656 = v655 == 0;\n\tv657 = ~v656;\n\tif (v657) goto L_0259;\n\tv659 = \"il2cpp_codegen_runtime_class_init\"(v576, v218, vibrato, ignoreZAxis, vectorBased, fadeOut, methodInfo, v75, v527, v529, v572, v570, v509, v507, v505, v78);\nL_0259:\n\tv666 = DG.Tweening.DOTween::ToArray(getter, setter, v221, v118);\n\tv765 = DG.Tweening.Core.Extensions::NoFrom(v666);\n\treturnVal2 = DG.Tweening.Core.Extensions::SetSpecialStartupMode(v765, 2);\n\treturn returnVal2;\nL_0279:\n\tv638 = new System.IndexOutOfRangeException();\n\tthrow v638;\nL_027E:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 438 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> Shake(DOGetter<Vector3> getter, DOSetter<Vector3> setter, float duration, Vector3 strength, int vibrato, float randomness, bool ignoreZAxis, bool vectorBased, bool fadeOut)
		{
			//IL_0833: Unknown result type (might be due to invalid IL or missing references)
			//IL_0838: Expected O, but got Unknown
			//IL_0845: Expected O, but got F4
			//IL_0024: Expected I4, but got F4
			//IL_0206: Expected O, but got I
			//IL_04e9: Expected O, but got F4
			//IL_07cc: Expected O, but got I
			//IL_0624: Expected O, but got F4
			//IL_03dd: Expected O, but got F4
			bool flag = !vectorBased;
			Vector3 vector = strength;
			Vector3 vector2 = default(Vector3);
			float num = vector2.x;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158AD58 (inside UnityEngine.Vector3::ClampMagnitude +0xDC)");
				num = duration;
			}
			float num2 = (float)vibrato * duration;
			float num3 = num2 - 3E-45f;
			bool flag2 = num3 < 0f;
			bool flag3 = num3 == 0f;
			object obj = num2 ^ 2;
			object obj2 = num2 ^ num3;
			int num4 = (int)((long)(IntPtr)obj & (long)(IntPtr)obj2);
			bool flag4 = num4 < 0;
			bool flag5 = flag2 == flag4;
			bool flag6 = !flag3;
			int num5 = ((!(flag5 && flag6)) ? 2 : ((int)num2));
			float[] array = new float[num5];
			bool flag7 = num5 < 1;
			float y = strength.y;
			if (flag7)
			{
				goto IL_018e;
			}
			float num6 = duration / (float)num5;
			float num7 = 0f;
			int num8 = 0;
			while (true)
			{
				bool flag8 = !fadeOut;
				y = num6;
				if (!flag8)
				{
					int num9 = num8 + 1;
					int num10 = num9 / num5;
					y = (float)num10 * duration;
				}
				if (num8 >= array.Length)
				{
					break;
				}
				array[num8] = y;
				num8++;
				num7 += y;
				if (num8 < num5)
				{
					continue;
				}
				goto IL_0101;
			}
			goto IL_06ba;
			IL_0678:
			Vector3[] array2;
			TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = ToArray(getter, setter, array2, array);
			TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t2 = t.NoFrom();
			return t2.SetSpecialStartupMode(SpecialStartupMode.SetShake);
			IL_0101:
			if (num5 < 1)
			{
				goto IL_018e;
			}
			float num11 = duration / num7;
			int num12 = 0;
			while (num12 < array.Length)
			{
				float num13 = num11 * array[num12];
				array[num12] = num13;
				num12++;
				if (num12 < num5)
				{
					continue;
				}
				goto IL_018e;
			}
			goto IL_06ba;
			IL_018e:
			float num14 = UnityEngine.Random.Range(0f, 360f);
			array2 = new Vector3[num5];
			int num15 = num5 - 1;
			if (num5 >= 1)
			{
				float num16 = num / (float)num5;
				float min = 0f - randomness;
				object obj3 = (long)(IntPtr)array2 + 40L;
				int num17 = 0;
				float z = strength.z;
				float y2 = strength.y;
				float num18 = num14;
				Vector3 vector6 = default(Vector3);
				Vector3 vector8 = default(Vector3);
				Vector3 vector10 = default(Vector3);
				while (true)
				{
					if (num17 < num15)
					{
						if (num17 >= 1)
						{
							float num19 = UnityEngine.Random.Range(min, randomness);
							float num20 = num18 + -180f;
							num18 = num20 + num19;
						}
						if (vectorBased)
						{
							float angle = UnityEngine.Random.Range(min, randomness);
							Vector3 up = Vector3.up;
							Quaternion quaternion = Quaternion.AngleAxis(angle, up);
							Vector3 vector3 = Utils.Vector3FromAngle(num18, num);
							Vector3 vector4 = quaternion * vector3;
							Vector3 vector5 = Vector3.ClampMagnitude(vector4, vector.x);
							vector6.x = vector5.x;
							vector6.y = vector4.y;
							vector6.z = vector4.z;
							Vector3 vector7 = Vector3.ClampMagnitude(vector6, y2);
							vector8.x = vector5.x;
							vector8.y = vector7.y;
							vector8.z = vector4.z;
							Vector3 vector9 = Vector3.ClampMagnitude(vector8, z);
							if (num17 >= array2.Length)
							{
								break;
							}
							_ = vector7.y;
							obj3 = vector9.z;
							float num21 = num - num16;
							if (fadeOut)
							{
								num = num21;
							}
							vector10.x = vector.x;
							vector10.y = y2;
							vector10.z = z;
							Vector3 vector11 = Vector3.ClampMagnitude(vector10, num);
							z = vector11.z;
							y2 = vector11.y;
							vector = vector11;
						}
						else
						{
							float z2;
							if (ignoreZAxis)
							{
								Vector3 vector12 = Utils.Vector3FromAngle(num18, num);
								float y3 = vector12.y;
								z2 = vector12.z;
								if (array2 == null)
								{
									return (TweenerCore<Vector3, Vector3[], Vector3ArrayOptions>)(object)new NullReferenceException();
								}
							}
							else
							{
								float angle2 = UnityEngine.Random.Range(min, randomness);
								Vector3 up2 = Vector3.up;
								Quaternion quaternion2 = Quaternion.AngleAxis(angle2, up2);
								Vector3 vector13 = Utils.Vector3FromAngle(num18, num);
								Vector3 vector12 = quaternion2 * vector13;
								float y3 = vector12.y;
								z2 = vector12.z;
							}
							if (num17 >= array2.Length)
							{
								break;
							}
							obj3 = z2;
							bool flag9 = !fadeOut;
							float num22 = num - num16;
							if (!flag9)
							{
								num = num22;
							}
						}
					}
					else
					{
						Vector3 zero = Vector3.zero;
						if (num17 >= array2.Length)
						{
							break;
						}
						_ = zero.y;
						obj3 = zero.z;
					}
					num17++;
					obj3 = (long)(IntPtr)obj3 + 12L;
					if (num17 < num5)
					{
						continue;
					}
					goto IL_0678;
				}
				goto IL_06ba;
			}
			goto IL_0678;
			IL_06ba:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000031")]
		[Address(RVA = "0x107C81C", Offset = "0x107C81C", Length = "0x204")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv36 = *([1EDDBB8]);\n\tv37 = *([v36 @ X8_v27]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, setter, endValues, durations, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([2026A06]) = v53;\nL_002B:\n\tv171 = durations.Length != endValues.Length;\n\tif (v171) goto L_00DD;\n\t// 49 NewArr v232 @ X0_v11 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), durations.Length\n\t// 56 NewArr v150 @ X0_v13 (System.Single[]), typeof(System.Single[]), durations.Length\n\tv321 = durations.Length < 1;\n\tif (v321) goto L_00C3;\n\tv85 = endValues + 0x28;\n\tv78 = v232 + 0x28;\nL_004E:\n\tv383 = v93 < endValues.Length;\n\tv144 = ~v383;\n\tif (v144) goto L_00EB;\n\tv428 = v93 < v232.Length;\n\tv423 = ~v428;\n\tif (v423) goto L_00EB;\n\t*([v78 @ X13_v6-8]) = *([v85 @ X11_v6-8]);\n\t*([v78 @ X13_v6-4]) = *([v85 @ X11_v6-4]);\n\t*([v78 @ X13_v6]) = *([v85 @ X11_v6]);\n\tv430 = v93 < durations.Length;\n\tv145 = ~v430;\n\tif (v145) goto L_00EB;\n\tv431 = v93 < v150.Length;\n\tv424 = ~v431;\n\tif (v424) goto L_00EB;\n\tv85 = v85 + 0xC;\n\tv78 = v78 + 0xC;\n\tv150[v93 @ X9_v6 (System.Int32)] = durations[v93 @ X9_v6 (System.Int32)];\n\tv93 = v93 + 1;\n\tv365 = v93 < durations.Length;\n\tif (v365) goto L_004E;\n\tv339 = durations.Length < 1;\n\tif (v339) goto L_00C3;\nL_00A4:\n\tv446 = v399 < v150.Length;\n\tv425 = ~v446;\n\tif (v425) goto L_00EB;\n\tv399 = v399 + 1;\n\tv197 = v400 + v150[v399 @ X9_v10 (System.Int32)];\n\tv338 = v399 < durations.Length;\n\tif (v338) goto L_00A4;\nL_00C3:\n\tgoto L_00D1;\n\tv384 = *([v360 @ X0_v14+E0]);\n\tv385 = v384 == 0;\n\tv386 = ~v385;\n\tif (v386) goto L_00D1;\n\tv388 = \"il2cpp_codegen_runtime_class_init\"(v360, v101, endValues, durations, methodInfo, v40, v41, v42, v328, v44, v45, v46, v47, v48, v49, v50);\nL_00D1:\n\tv395 = DG.Tweening.DOTween::ApplyTo(getter, setter, v232, v197, 0);\n\treturnVal2 = DG.Tweening.Core.Extensions::NoFrom(v395);\n\t*([returnVal2 @ X0_v7 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3[], DG.Tweening.Plugins.Options.Vector3ArrayOptions>)+140]) = v150;\n\tgoto L_00EA;\nL_00DD:\n\tDG.Tweening.Core.Debugger::LogError(\"To Vector3 array tween: endValues and durations arrays must have the same length\");\nL_00EA:\n\treturn returnVal2;\nL_00EB:\n\tv426 = new System.IndexOutOfRangeException();\n\tthrow v426;\n\tv160 = new System.NullReferenceException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 182 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> ToArray(DOGetter<Vector3> getter, DOSetter<Vector3> setter, Vector3[] endValues, float[] durations)
		{
			//IL_0083: Expected O, but got I
			//IL_0092: Expected O, but got I
			//IL_014c: Expected O, but got I
			//IL_015b: Expected O, but got I
			if (durations.Length == endValues.Length)
			{
				Vector3[] array = new Vector3[durations.Length];
				float[] array2 = new float[durations.Length];
				bool flag = durations.Length < 1;
				float num = 0f;
				if (!flag)
				{
					object obj = (long)(IntPtr)endValues + 40L;
					object obj2 = (long)(IntPtr)array + 40L;
					int num2 = 0;
					while (true)
					{
						if (num2 < endValues.Length && num2 < array.Length)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ X11_v6-8]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ X11_v6-4]");
							_ = 0;
							obj2 = obj;
							if (num2 < durations.Length && num2 < array2.Length)
							{
								obj = (long)(IntPtr)obj + 12L;
								obj2 = (long)(IntPtr)obj2 + 12L;
								array2[num2] = durations[num2];
								num2++;
								if (num2 < durations.Length)
								{
									continue;
								}
								bool flag2 = durations.Length < 1;
								num = 0f;
								if (flag2)
								{
									break;
								}
								int num3 = 0;
								float num4 = 0f;
								while (num3 < array2.Length)
								{
									num3++;
									num = num4 + array2[num3];
									bool flag3 = num3 < durations.Length;
									num4 = num;
									if (!flag3)
									{
										goto end_IL_028a;
									}
								}
							}
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
						continue;
						end_IL_028a:
						break;
					}
				}
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = ApplyTo<Vector3, Vector3[], Vector3ArrayOptions>(getter, setter, array, num);
				return t.NoFrom();
			}
			Debugger.LogError("To Vector3 array tween: endValues and durations arrays must have the same length");
			return null;
		}

		[Token(Token = "0x6000032")]
		[Address(RVA = "0x107D174", Offset = "0x107D174", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1EE3F98]);\n\tv31 = *([v30 @ X8_v11]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, setter, endValue, methodInfo, v34, v35, v36, v37, duration, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2026A07]) = v47;\nL_001C:\n\tv51 = endValue.ca;\n\tgoto L_0035;\n\tv58 = *([v54 @ X0_v2+E0]);\n\tv59 = v58 == 0;\n\tv60 = ~v59;\n\tgoto L_0035;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v54, setter, endValue, methodInfo, v34, v35, v36, v37, v51, v38, v39, v40, v41, v42, v43, v44);\nL_0035:\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, &v51 @ V0_v2 (UnityEngine.Color), duration, 0);\n\treturn returnVal1;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe static TweenerCore<Color2, Color2, ColorOptions> To(DOGetter<Color2> getter, DOSetter<Color2> setter, Color2 endValue, float duration)
		{
			//IL_001b: Expected O, but got Ref
			Color ca = endValue.ca;
			return ApplyTo<Color2, Color2, ColorOptions>(getter, setter, (Color2)(&ca), duration);
		}

		[Token(Token = "0x6000033")]
		[Address(RVA = "0x107D234", Offset = "0x107D234", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EBD230]);\n\tv15 = *([v14 @ X8_v14]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2026A08]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tDG.Tweening.DOTween::InitCheck();\n\tgoto L_002A;\n\tv55 = *([v51 @ X0_v4 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_002A;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v51, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_002A:\n\tv62 = DG.Tweening.Core.TweenManager::GetSequence();\n\tDG.Tweening.Sequence::Setup(v62);\n\treturn v62;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sequence Sequence()
		{
			InitCheck();
			Sequence sequence = TweenManager.GetSequence();
			DG.Tweening.Sequence.Setup(sequence);
			return sequence;
		}

		[Token(Token = "0x6000034")]
		[Address(RVA = "0x107D2C8", Offset = "0x107D2C8", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EC3600]);\n\tv21 = *([v20 @ X8_v9]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2026A09]) = v40;\nL_0018:\n\tv45 = withCallbacks == 0;\n\tv51 = ~v45;\n\tv52 = ~v51;\n\tif (v52) goto L_FFFFFFFF;\n\tgoto L_0028;\nL_0028:\n\tgoto L_003B;\n\tv59 = *([v50 @ X0_v2+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tgoto L_003B;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v24, v25, v26, v27, v28, v29, v48, v49, v32, v33, v34, v35, v36, v37);\nL_003B:\n\treturnVal1 = DG.Tweening.Core.TweenManager::FilteredOperation(0, 0, 0, 0, v55, 0, 0);\n\treturn returnVal1;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int CompleteAll(bool withCallbacks = false)
		{
			float optionalFloat = ((!withCallbacks) ? 0f : 1f);
			return TweenManager.FilteredOperation(default(OperationType), default(FilterType), null, optionalBool: false, optionalFloat);
		}

		[Token(Token = "0x6000035")]
		[Address(RVA = "0x107D35C", Offset = "0x107D35C", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1ED9DC8]);\n\tv25 = *([v24 @ X8_v10]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, withCallbacks, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2026A0A]) = v43;\nL_0016:\n\tv44 = targetOrId == 0;\n\tif (v44) goto L_004A;\n\tv49 = withCallbacks == 0;\n\tv55 = ~v49;\n\tv56 = ~v55;\n\tif (v56) goto L_FFFFFFFF;\n\tgoto L_002C;\nL_002C:\n\tgoto L_0040;\n\tv113 = *([v54 @ X0_v3+E0]);\n\tv114 = v113 == 0;\n\tv115 = ~v114;\n\tgoto L_0040;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v54, withCallbacks, methodInfo, v28, v29, v30, v31, v32, v52, v53, v35, v36, v37, v38, v39, v40);\nL_0040:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(0, 1, targetOrId, 0, v109, 0, 0);\n\treturn returnVal2;\nL_004A:\n\treturn 0;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Complete(object targetOrId, bool withCallbacks = false)
		{
			if (targetOrId != null)
			{
				float optionalFloat = ((!withCallbacks) ? 0f : 1f);
				return TweenManager.FilteredOperation(default(OperationType), FilterType.TargetOrId, targetOrId, optionalBool: false, optionalFloat);
			}
			return 0;
		}

		[Token(Token = "0x6000036")]
		[Address(RVA = "0x107D418", Offset = "0x107D418", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF3A68]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2026A0B]) = v35;\nL_0017:\n\tgoto L_0028;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0028;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0028:\n\treturnVal1 = DG.Tweening.Core.TweenManager::FilteredOperation(0, 0, 0, 1, 0f, 0, 0);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int CompleteAndReturnKilledTot()
		{
			return TweenManager.FilteredOperation(default(OperationType), default(FilterType), null, optionalBool: true, 0f);
		}

		[Token(Token = "0x6000037")]
		[Address(RVA = "0x107D490", Offset = "0x107D490", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F0D430]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026A0C]) = v38;\nL_0013:\n\tv39 = targetOrId == 0;\n\tif (v39) goto L_0035;\n\tgoto L_002D;\n\tv51 = *([v42 @ X0_v3+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_002D;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(0, 1, targetOrId, 1, 0f, 0, 0);\n\treturn returnVal2;\nL_0035:\n\treturn 0;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int CompleteAndReturnKilledTot(object targetOrId)
		{
			if (targetOrId != null)
			{
				return TweenManager.FilteredOperation(default(OperationType), FilterType.TargetOrId, targetOrId, optionalBool: true, 0f);
			}
			return 0;
		}

		[Token(Token = "0x6000038")]
		[Address(RVA = "0x107D520", Offset = "0x107D520", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF3BF8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026A0D]) = v38;\nL_0019:\n\tgoto L_002B;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_002B;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002B:\n\treturnVal1 = DG.Tweening.Core.TweenManager::FilteredOperation(0, 3, 0, 1, 0f, 0, excludeTargetsOrIds);\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int CompleteAndReturnKilledTotExceptFor(params object[] excludeTargetsOrIds)
		{
			return TweenManager.FilteredOperation(default(OperationType), FilterType.AllExceptTargetsOrIds, null, optionalBool: true, 0f, null, excludeTargetsOrIds);
		}

		[Token(Token = "0x6000039")]
		[Address(RVA = "0x107D59C", Offset = "0x107D59C", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF5BD0]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2026A0E]) = v35;\nL_0017:\n\tgoto L_0028;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0028;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0028:\n\treturnVal1 = DG.Tweening.Core.TweenManager::FilteredOperation(2, 0, 0, 0, 0f, 0, 0);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int FlipAll()
		{
			return TweenManager.FilteredOperation(OperationType.Flip, default(FilterType), null, optionalBool: false, 0f);
		}

		[Token(Token = "0x600003A")]
		[Address(RVA = "0x107D614", Offset = "0x107D614", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EA72A0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026A0F]) = v38;\nL_0013:\n\tv39 = targetOrId == 0;\n\tif (v39) goto L_0035;\n\tgoto L_002D;\n\tv51 = *([v42 @ X0_v3+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_002D;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(2, 1, targetOrId, 0, 0f, 0, 0);\n\treturn returnVal2;\nL_0035:\n\treturn 0;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Flip(object targetOrId)
		{
			if (targetOrId != null)
			{
				return TweenManager.FilteredOperation(OperationType.Flip, FilterType.TargetOrId, targetOrId, optionalBool: false, 0f);
			}
			return 0;
		}

		[Token(Token = "0x600003B")]
		[Address(RVA = "0x107D6A4", Offset = "0x107D6A4", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EB2420]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, to, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2026A10]) = v41;\nL_001B:\n\tgoto L_002E;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_002E;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v26, v27, v28, v29, v30, v31, to, v32, v33, v34, v35, v36, v37, v38);\nL_002E:\n\treturnVal1 = DG.Tweening.Core.TweenManager::FilteredOperation(3, 0, 0, andPlay, to, 0, 0);\n\treturn returnVal1;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int GotoAll(float to, bool andPlay = false)
		{
			return TweenManager.FilteredOperation(OperationType.Goto, default(FilterType), null, andPlay, to);
		}

		[Token(Token = "0x600003C")]
		[Address(RVA = "0x107D72C", Offset = "0x107D72C", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EA61B8]);\n\tv27 = *([v26 @ X8_v10]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, andPlay, methodInfo, v30, v31, v32, v33, v34, to, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2026A11]) = v44;\nL_0017:\n\tv45 = targetOrId == 0;\n\tif (v45) goto L_003D;\n\tgoto L_0033;\n\tv59 = *([v48 @ X0_v3+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0033;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v48, andPlay, methodInfo, v30, v31, v32, v33, v34, to, v35, v36, v37, v38, v39, v40, v41);\nL_0033:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(3, 1, targetOrId, andPlay, to, 0, 0);\n\treturn returnVal2;\nL_003D:\n\treturn 0;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Goto(object targetOrId, float to, bool andPlay = false)
		{
			if (targetOrId != null)
			{
				return TweenManager.FilteredOperation(OperationType.Goto, FilterType.TargetOrId, targetOrId, andPlay, to);
			}
			return 0;
		}

		[Token(Token = "0x600003D")]
		[Address(RVA = "0x107D7DC", Offset = "0x107D7DC", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EAC5F8]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026A12]) = v38;\nL_0014:\n\tv40 = complete == 0;\n\tif (v40) goto L_FFFFFFFF;\n\tgoto L_0022;\n\tv48 = *([v43 @ X0_v8 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tif (v50) goto L_0022;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0022:\n\tv55 = DG.Tweening.DOTween::CompleteAndReturnKilledTot();\n\tgoto L_002C;\nL_002C:\n\tgoto L_0032;\n\tv67 = *([v63 @ X0_v3 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tgoto L_0032;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v63, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0032:\n\tv74 = DG.Tweening.Core.TweenManager::DespawnAll();\n\treturnVal1 = v74 + v58;\n\treturn returnVal1;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int KillAll(bool complete = false)
		{
			int num2;
			if (complete)
			{
				int num = CompleteAndReturnKilledTot();
				num2 = num;
			}
			else
			{
				num2 = 0;
			}
			int num3 = TweenManager.DespawnAll();
			return num3 + num2;
		}

		[Token(Token = "0x600003E")]
		[Address(RVA = "0x107D878", Offset = "0x107D878", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1F0A370]);\n\tv23 = *([v22 @ X8_v27]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, idsOrTargetsToExclude, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2026A13]) = v41;\nL_0015:\n\tv42 = idsOrTargetsToExclude == 0;\n\tif (v42) goto L_002B;\n\tv44 = complete == 0;\n\tif (v44) goto L_FFFFFFFF;\n\tgoto L_0027;\n\tv61 = *([v49 @ X0_v20+E0]);\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_0027;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v49, idsOrTargetsToExclude, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0027:\n\tv69 = DG.Tweening.DOTween::CompleteAndReturnKilledTotExceptFor(idsOrTargetsToExclude);\n\tgoto L_0043;\nL_002B:\n\tv46 = complete == 0;\n\tif (v46) goto L_FFFFFFFF;\n\tgoto L_0039;\n\tv81 = *([v56 @ X0_v9 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv82 = v81 == 0;\n\tv83 = ~v82;\n\tif (v83) goto L_0039;\n\tv85 = \"il2cpp_codegen_runtime_class_init\"(v56, idsOrTargetsToExclude, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0039:\n\tv88 = DG.Tweening.DOTween::CompleteAndReturnKilledTot();\n\tgoto L_005A;\nL_0043:\n\tgoto L_0050;\n\tv100 = *([v77 @ X0_v14+E0]);\n\tv101 = v100 == 0;\n\tv102 = ~v101;\n\tgoto L_0050;\n\tv104 = \"il2cpp_codegen_runtime_class_init\"(v77, idsOrTargetsToExclude, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0050:\n\tv114 = DG.Tweening.Core.TweenManager::FilteredOperation(1, 3, 0, 0, 0f, 0, idsOrTargetsToExclude);\n\treturnVal1 = v114 + v72;\n\tgoto L_0068;\nL_005A:\n\tgoto L_0060;\n\tv115 = *([v96 @ X0_v4 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv116 = v115 == 0;\n\tv117 = ~v116;\n\tgoto L_0060;\n\tv119 = \"il2cpp_codegen_runtime_class_init\"(v96, idsOrTargetsToExclude, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0060:\n\tv122 = DG.Tweening.Core.TweenManager::DespawnAll();\n\treturnVal1 = v122 + v91;\nL_0068:\n\treturn returnVal1;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int KillAll(bool complete, params object[] idsOrTargetsToExclude)
		{
			if (idsOrTargetsToExclude != null)
			{
				int num2;
				if (complete)
				{
					int num = CompleteAndReturnKilledTotExceptFor(idsOrTargetsToExclude);
					num2 = num;
				}
				else
				{
					num2 = 0;
				}
				int num3 = TweenManager.FilteredOperation(OperationType.Despawn, FilterType.AllExceptTargetsOrIds, null, optionalBool: false, 0f, null, idsOrTargetsToExclude);
				return num3 + num2;
			}
			int num5;
			if (complete)
			{
				int num4 = CompleteAndReturnKilledTot();
				num5 = num4;
			}
			else
			{
				num5 = 0;
			}
			int num6 = TweenManager.DespawnAll();
			return num6 + num5;
		}

		[Token(Token = "0x600003F")]
		[Address(RVA = "0x107D9A4", Offset = "0x107D9A4", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EF4EC8]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, complete, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2026A14]) = v41;\nL_0015:\n\tv42 = targetOrId == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tv44 = complete == 0;\n\tif (v44) goto L_FFFFFFFF;\n\tgoto L_0027;\n\tv78 = *([v48 @ X0_v11+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_0027;\n\tv82 = \"il2cpp_codegen_runtime_class_init\"(v48, complete, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0027:\n\tv86 = DG.Tweening.DOTween::CompleteAndReturnKilledTot(targetOrId);\n\tgoto L_0033;\n\tgoto L_0048;\nL_0033:\n\tgoto L_0040;\n\tv97 = *([v93 @ X0_v5+E0]);\n\tv98 = v97 == 0;\n\tv99 = ~v98;\n\tgoto L_0040;\n\tv101 = \"il2cpp_codegen_runtime_class_init\"(v93, complete, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0040:\n\tv103 = DG.Tweening.Core.TweenManager::FilteredOperation(1, 1, targetOrId, 0, 0f, 0, 0);\n\treturnVal1 = v103 + v70;\nL_0048:\n\treturn returnVal1;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Kill(object targetOrId, bool complete = false)
		{
			if (targetOrId != null)
			{
				int num2;
				if (complete)
				{
					int num = CompleteAndReturnKilledTot(targetOrId);
					num2 = num;
				}
				else
				{
					num2 = 0;
				}
				int num3 = TweenManager.FilteredOperation(OperationType.Despawn, FilterType.TargetOrId, targetOrId, optionalBool: false, 0f);
				return num3 + num2;
			}
			return 0;
		}

		[Token(Token = "0x6000040")]
		[Address(RVA = "0x107DA78", Offset = "0x107DA78", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F06650]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2026A15]) = v35;\nL_0017:\n\tgoto L_0028;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0028;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0028:\n\treturnVal1 = DG.Tweening.Core.TweenManager::FilteredOperation(4, 0, 0, 0, 0f, 0, 0);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int PauseAll()
		{
			return TweenManager.FilteredOperation(OperationType.Pause, default(FilterType), null, optionalBool: false, 0f);
		}

		[Token(Token = "0x6000041")]
		[Address(RVA = "0x107DAF0", Offset = "0x107DAF0", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EBEE50]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026A16]) = v38;\nL_0013:\n\tv39 = targetOrId == 0;\n\tif (v39) goto L_0035;\n\tgoto L_002D;\n\tv51 = *([v42 @ X0_v3+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_002D;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(4, 1, targetOrId, 0, 0f, 0, 0);\n\treturn returnVal2;\nL_0035:\n\treturn 0;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Pause(object targetOrId)
		{
			if (targetOrId != null)
			{
				return TweenManager.FilteredOperation(OperationType.Pause, FilterType.TargetOrId, targetOrId, optionalBool: false, 0f);
			}
			return 0;
		}

		[Token(Token = "0x6000042")]
		[Address(RVA = "0x107DB80", Offset = "0x107DB80", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ED5F48]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2026A17]) = v35;\nL_0017:\n\tgoto L_0028;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0028;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0028:\n\treturnVal1 = DG.Tweening.Core.TweenManager::FilteredOperation(5, 0, 0, 0, 0f, 0, 0);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int PlayAll()
		{
			return TweenManager.FilteredOperation(OperationType.Play, default(FilterType), null, optionalBool: false, 0f);
		}

		[Token(Token = "0x6000043")]
		[Address(RVA = "0x107DBF8", Offset = "0x107DBF8", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EE9F48]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026A18]) = v38;\nL_0013:\n\tv39 = targetOrId == 0;\n\tif (v39) goto L_0035;\n\tgoto L_002D;\n\tv51 = *([v42 @ X0_v3+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_002D;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(5, 1, targetOrId, 0, 0f, 0, 0);\n\treturn returnVal2;\nL_0035:\n\treturn 0;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Play(object targetOrId)
		{
			if (targetOrId != null)
			{
				return TweenManager.FilteredOperation(OperationType.Play, FilterType.TargetOrId, targetOrId, optionalBool: false, 0f);
			}
			return 0;
		}

		[Token(Token = "0x6000044")]
		[Address(RVA = "0x107DC88", Offset = "0x107DC88", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1F0A190]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, id, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2026A19]) = v41;\nL_0015:\n\tv42 = target == 0;\n\tif (v42) goto L_003B;\n\tv43 = id == 0;\n\tif (v43) goto L_003B;\n\tgoto L_0032;\n\tv85 = *([v53 @ X0_v3+E0]);\n\tv86 = v85 == 0;\n\tv87 = ~v86;\n\tif (v87) goto L_0032;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v53, id, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0032:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(5, 2, id, 0, 0f, target, 0);\n\treturn returnVal2;\nL_003B:\n\treturn 0;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Play(object target, object id)
		{
			if (target != null && id != null)
			{
				return TweenManager.FilteredOperation(OperationType.Play, FilterType.TargetAndId, id, optionalBool: false, 0f, target);
			}
			return 0;
		}

		[Token(Token = "0x6000045")]
		[Address(RVA = "0x107DD2C", Offset = "0x107DD2C", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EEF288]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2026A1A]) = v35;\nL_0017:\n\tgoto L_0028;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0028;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0028:\n\treturnVal1 = DG.Tweening.Core.TweenManager::FilteredOperation(7, 0, 0, 0, 0f, 0, 0);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int PlayBackwardsAll()
		{
			return TweenManager.FilteredOperation(OperationType.PlayBackwards, default(FilterType), null, optionalBool: false, 0f);
		}

		[Token(Token = "0x6000046")]
		[Address(RVA = "0x107DDA4", Offset = "0x107DDA4", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EA3E78]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026A1B]) = v38;\nL_0013:\n\tv39 = targetOrId == 0;\n\tif (v39) goto L_0035;\n\tgoto L_002D;\n\tv51 = *([v42 @ X0_v3+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_002D;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(7, 1, targetOrId, 0, 0f, 0, 0);\n\treturn returnVal2;\nL_0035:\n\treturn 0;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int PlayBackwards(object targetOrId)
		{
			if (targetOrId != null)
			{
				return TweenManager.FilteredOperation(OperationType.PlayBackwards, FilterType.TargetOrId, targetOrId, optionalBool: false, 0f);
			}
			return 0;
		}

		[Token(Token = "0x6000047")]
		[Address(RVA = "0x107DE34", Offset = "0x107DE34", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EE4910]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, id, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2026A1C]) = v41;\nL_0015:\n\tv42 = target == 0;\n\tif (v42) goto L_003B;\n\tv43 = id == 0;\n\tif (v43) goto L_003B;\n\tgoto L_0032;\n\tv85 = *([v53 @ X0_v3+E0]);\n\tv86 = v85 == 0;\n\tv87 = ~v86;\n\tif (v87) goto L_0032;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v53, id, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0032:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(7, 2, id, 0, 0f, target, 0);\n\treturn returnVal2;\nL_003B:\n\treturn 0;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int PlayBackwards(object target, object id)
		{
			if (target != null && id != null)
			{
				return TweenManager.FilteredOperation(OperationType.PlayBackwards, FilterType.TargetAndId, id, optionalBool: false, 0f, target);
			}
			return 0;
		}

		[Token(Token = "0x6000048")]
		[Address(RVA = "0x107DED8", Offset = "0x107DED8", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ECCA30]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2026A1D]) = v35;\nL_0017:\n\tgoto L_0028;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0028;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0028:\n\treturnVal1 = DG.Tweening.Core.TweenManager::FilteredOperation(6, 0, 0, 0, 0f, 0, 0);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int PlayForwardAll()
		{
			return TweenManager.FilteredOperation(OperationType.PlayForward, default(FilterType), null, optionalBool: false, 0f);
		}

		[Token(Token = "0x6000049")]
		[Address(RVA = "0x107DF50", Offset = "0x107DF50", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F0EAF0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026A1E]) = v38;\nL_0013:\n\tv39 = targetOrId == 0;\n\tif (v39) goto L_0035;\n\tgoto L_002D;\n\tv51 = *([v42 @ X0_v3+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_002D;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(6, 1, targetOrId, 0, 0f, 0, 0);\n\treturn returnVal2;\nL_0035:\n\treturn 0;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int PlayForward(object targetOrId)
		{
			if (targetOrId != null)
			{
				return TweenManager.FilteredOperation(OperationType.PlayForward, FilterType.TargetOrId, targetOrId, optionalBool: false, 0f);
			}
			return 0;
		}

		[Token(Token = "0x600004A")]
		[Address(RVA = "0x107DFE0", Offset = "0x107DFE0", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ED9DD8]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, id, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2026A1F]) = v41;\nL_0015:\n\tv42 = target == 0;\n\tif (v42) goto L_003B;\n\tv43 = id == 0;\n\tif (v43) goto L_003B;\n\tgoto L_0032;\n\tv85 = *([v53 @ X0_v3+E0]);\n\tv86 = v85 == 0;\n\tv87 = ~v86;\n\tif (v87) goto L_0032;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v53, id, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0032:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(6, 2, id, 0, 0f, target, 0);\n\treturn returnVal2;\nL_003B:\n\treturn 0;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int PlayForward(object target, object id)
		{
			if (target != null && id != null)
			{
				return TweenManager.FilteredOperation(OperationType.PlayForward, FilterType.TargetAndId, id, optionalBool: false, 0f, target);
			}
			return 0;
		}

		[Token(Token = "0x600004B")]
		[Address(RVA = "0x107E084", Offset = "0x107E084", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC7A70]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026A20]) = v38;\nL_0019:\n\tgoto L_002B;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_002B;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002B:\n\treturnVal1 = DG.Tweening.Core.TweenManager::FilteredOperation(0xA, 0, 0, includeDelay, 0f, 0, 0);\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int RestartAll(bool includeDelay = true)
		{
			return TweenManager.FilteredOperation(OperationType.Restart, default(FilterType), null, includeDelay, 0f);
		}

		[Token(Token = "0x600004C")]
		[Address(RVA = "0x107E100", Offset = "0x107E100", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1F0CCD8]);\n\tv27 = *([v26 @ X8_v10]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, includeDelay, methodInfo, v30, v31, v32, v33, v34, changeDelayTo, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2026A21]) = v44;\nL_0017:\n\tv45 = targetOrId == 0;\n\tif (v45) goto L_003D;\n\tgoto L_0033;\n\tv59 = *([v48 @ X0_v3+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0033;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v48, includeDelay, methodInfo, v30, v31, v32, v33, v34, changeDelayTo, v35, v36, v37, v38, v39, v40, v41);\nL_0033:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(0xA, 1, targetOrId, includeDelay, changeDelayTo, 0, 0);\n\treturn returnVal2;\nL_003D:\n\treturn 0;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Restart(object targetOrId, bool includeDelay = true, float changeDelayTo = -1f)
		{
			if (targetOrId != null)
			{
				return TweenManager.FilteredOperation(OperationType.Restart, FilterType.TargetOrId, targetOrId, includeDelay, changeDelayTo);
			}
			return 0;
		}

		[Token(Token = "0x600004D")]
		[Address(RVA = "0x107E1B0", Offset = "0x107E1B0", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EF3AD0]);\n\tv31 = *([v30 @ X8_v10]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, id, includeDelay, methodInfo, v34, v35, v36, v37, changeDelayTo, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2026A22]) = v47;\nL_0019:\n\tv48 = target == 0;\n\tif (v48) goto L_0043;\n\tv49 = id == 0;\n\tif (v49) goto L_0043;\n\tgoto L_0038;\n\tv97 = *([v61 @ X0_v3+E0]);\n\tv98 = v97 == 0;\n\tv99 = ~v98;\n\tif (v99) goto L_0038;\n\tv101 = \"il2cpp_codegen_runtime_class_init\"(v61, id, includeDelay, methodInfo, v34, v35, v36, v37, changeDelayTo, v38, v39, v40, v41, v42, v43, v44);\nL_0038:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(0xA, 2, id, includeDelay, changeDelayTo, target, 0);\n\treturn returnVal2;\nL_0043:\n\treturn 0;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Restart(object target, object id, bool includeDelay = true, float changeDelayTo = -1f)
		{
			if (target != null && id != null)
			{
				return TweenManager.FilteredOperation(OperationType.Restart, FilterType.TargetAndId, id, includeDelay, changeDelayTo, target);
			}
			return 0;
		}

		[Token(Token = "0x600004E")]
		[Address(RVA = "0x107E268", Offset = "0x107E268", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB5648]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026A23]) = v38;\nL_0019:\n\tgoto L_002B;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_002B;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002B:\n\treturnVal1 = DG.Tweening.Core.TweenManager::FilteredOperation(8, 0, 0, includeDelay, 0f, 0, 0);\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int RewindAll(bool includeDelay = true)
		{
			return TweenManager.FilteredOperation(OperationType.Rewind, default(FilterType), null, includeDelay, 0f);
		}

		[Token(Token = "0x600004F")]
		[Address(RVA = "0x107E2E4", Offset = "0x107E2E4", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1F058D0]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, includeDelay, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2026A24]) = v41;\nL_0015:\n\tv42 = targetOrId == 0;\n\tif (v42) goto L_0039;\n\tgoto L_0030;\n\tv55 = *([v45 @ X0_v3+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_0030;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v45, includeDelay, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0030:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(8, 1, targetOrId, includeDelay, 0f, 0, 0);\n\treturn returnVal2;\nL_0039:\n\treturn 0;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Rewind(object targetOrId, bool includeDelay = true)
		{
			if (targetOrId != null)
			{
				return TweenManager.FilteredOperation(OperationType.Rewind, FilterType.TargetOrId, targetOrId, includeDelay, 0f);
			}
			return 0;
		}

		[Token(Token = "0x6000050")]
		[Address(RVA = "0x107E384", Offset = "0x107E384", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EE8F68]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2026A25]) = v35;\nL_0017:\n\tgoto L_0028;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0028;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0028:\n\treturnVal1 = DG.Tweening.Core.TweenManager::FilteredOperation(9, 0, 0, 0, 0f, 0, 0);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int SmoothRewindAll()
		{
			return TweenManager.FilteredOperation(OperationType.SmoothRewind, default(FilterType), null, optionalBool: false, 0f);
		}

		[Token(Token = "0x6000051")]
		[Address(RVA = "0x107E3FC", Offset = "0x107E3FC", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EFA8F8]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026A26]) = v38;\nL_0013:\n\tv39 = targetOrId == 0;\n\tif (v39) goto L_0035;\n\tgoto L_002D;\n\tv51 = *([v42 @ X0_v3+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_002D;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(9, 1, targetOrId, 0, 0f, 0, 0);\n\treturn returnVal2;\nL_0035:\n\treturn 0;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int SmoothRewind(object targetOrId)
		{
			if (targetOrId != null)
			{
				return TweenManager.FilteredOperation(OperationType.SmoothRewind, FilterType.TargetOrId, targetOrId, optionalBool: false, 0f);
			}
			return 0;
		}

		[Token(Token = "0x6000052")]
		[Address(RVA = "0x107E48C", Offset = "0x107E48C", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EBE520]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2026A27]) = v35;\nL_0017:\n\tgoto L_0028;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0028;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0028:\n\treturnVal1 = DG.Tweening.Core.TweenManager::FilteredOperation(0xB, 0, 0, 0, 0f, 0, 0);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int TogglePauseAll()
		{
			return TweenManager.FilteredOperation(OperationType.TogglePause, default(FilterType), null, optionalBool: false, 0f);
		}

		[Token(Token = "0x6000053")]
		[Address(RVA = "0x107E504", Offset = "0x107E504", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EAB440]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026A28]) = v38;\nL_0013:\n\tv39 = targetOrId == 0;\n\tif (v39) goto L_0035;\n\tgoto L_002D;\n\tv51 = *([v42 @ X0_v3+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_002D;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(0xB, 1, targetOrId, 0, 0f, 0, 0);\n\treturn returnVal2;\nL_0035:\n\treturn 0;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int TogglePause(object targetOrId)
		{
			if (targetOrId != null)
			{
				return TweenManager.FilteredOperation(OperationType.TogglePause, FilterType.TargetOrId, targetOrId, optionalBool: false, 0f);
			}
			return 0;
		}

		[Token(Token = "0x6000054")]
		[Address(RVA = "0x107E594", Offset = "0x107E594", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EB4FF8]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, alsoCheckIfIsPlaying, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2026A29]) = v41;\nL_001B:\n\tgoto L_0028;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0028;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, alsoCheckIfIsPlaying, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0028:\n\tv62 = DG.Tweening.Core.TweenManager::FilteredOperation(0xC, 1, targetOrId, alsoCheckIfIsPlaying, 0f, 0, 0);\n\tv70 = v62 < 0;\n\tv71 = v62 == 0;\n\tv73 = v62 ^ v62;\n\tv74 = v62 & v73;\n\tv75 = v74 < 0;\n\tv76 = v70 == v75;\n\tv77 = ~v71;\n\tv78 = v76 & v77;\n\treturn v78;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsTweening(object targetOrId, bool alsoCheckIfIsPlaying = false)
		{
			int num = TweenManager.FilteredOperation(OperationType.IsTweening, FilterType.TargetOrId, targetOrId, alsoCheckIfIsPlaying, 0f);
			bool flag = num < 0;
			bool flag2 = num == 0;
			int num2 = num ^ num;
			int num3 = num & num2;
			bool flag3 = num3 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			return flag4 && flag5;
		}

		[Token(Token = "0x6000055")]
		[Address(RVA = "0x107E628", Offset = "0x107E628", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF7E00]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2026A2A]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\treturnVal1 = DG.Tweening.Core.TweenManager::TotalPlayingTweens();\n\treturn returnVal1;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int TotalPlayingTweens()
		{
			return TweenManager.TotalPlayingTweens();
		}

		[Token(Token = "0x6000056")]
		[Address(RVA = "0x107E684", Offset = "0x107E684", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EBDD60]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026A2B]) = v38;\nL_0013:\n\tv39 = fillableList == 0;\n\tif (v39) goto L_0020;\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::Clear(fillableList);\nL_0020:\n\tgoto L_002D;\n\tv53 = *([v49 @ X0_v3+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_002D;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v49, v44, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\treturnVal1 = DG.Tweening.Core.TweenManager::GetActiveTweens(1, fillableList);\n\treturn returnVal1;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static List<Tween> PlayingTweens(List<Tween> fillableList = null)
		{
			fillableList?.Clear();
			return TweenManager.GetActiveTweens(playing: true, fillableList);
		}

		[Token(Token = "0x6000057")]
		[Address(RVA = "0x107E704", Offset = "0x107E704", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EDB280]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026A2C]) = v38;\nL_0013:\n\tv39 = fillableList == 0;\n\tif (v39) goto L_0020;\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::Clear(fillableList);\nL_0020:\n\tgoto L_002D;\n\tv53 = *([v49 @ X0_v3+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_002D;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v49, v44, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\treturnVal1 = DG.Tweening.Core.TweenManager::GetActiveTweens(0, fillableList);\n\treturn returnVal1;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static List<Tween> PausedTweens(List<Tween> fillableList = null)
		{
			fillableList?.Clear();
			return TweenManager.GetActiveTweens(playing: false, fillableList);
		}

		[Token(Token = "0x6000058")]
		[Address(RVA = "0x107E784", Offset = "0x107E784", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EA9B90]);\n\tv27 = *([v26 @ X8_v13]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, playingOnly, fillableList, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2026A2D]) = v44;\nL_0017:\n\tv45 = id == 0;\n\tif (v45) goto L_0040;\n\tv46 = fillableList == 0;\n\tif (v46) goto L_0026;\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::Clear(fillableList);\nL_0026:\n\tgoto L_0036;\n\tv89 = *([v63 @ X0_v4+E0]);\n\tv90 = v89 == 0;\n\tv91 = ~v90;\n\tif (v91) goto L_0036;\n\tv93 = \"il2cpp_codegen_runtime_class_init\"(v63, v58, fillableList, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0036:\n\treturnVal2 = DG.Tweening.Core.TweenManager::GetTweensById(id, playingOnly, fillableList);\n\treturn returnVal2;\nL_0040:\n\treturn 0;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static List<Tween> TweensById(object id, bool playingOnly = false, List<Tween> fillableList = null)
		{
			if (id != null)
			{
				fillableList?.Clear();
				return TweenManager.GetTweensById(id, playingOnly, fillableList);
			}
			return null;
		}

		[Token(Token = "0x6000059")]
		[Address(RVA = "0x107E830", Offset = "0x107E830", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EBB088]);\n\tv27 = *([v26 @ X8_v12]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, playingOnly, fillableList, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2026A2E]) = v44;\nL_0017:\n\tv45 = fillableList == 0;\n\tif (v45) goto L_0024;\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::Clear(fillableList);\nL_0024:\n\tgoto L_0034;\n\tv59 = *([v55 @ X0_v3+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0034;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v55, v50, fillableList, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0034:\n\treturnVal1 = DG.Tweening.Core.TweenManager::GetTweensByTarget(target, playingOnly, fillableList);\n\treturn returnVal1;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static List<Tween> TweensByTarget(object target, bool playingOnly = false, List<Tween> fillableList = null)
		{
			fillableList?.Clear();
			return TweenManager.GetTweensByTarget(target, playingOnly, fillableList);
		}

		[Token(Token = "0x600005A")]
		[Address(RVA = "0x107B7DC", Offset = "0x107B7DC", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB5EC8]);\n\tv15 = *([v14 @ X8_v19]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2026A2F]) = v35;\nL_0017:\n\tgoto L_0020;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0020;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = DG.Tweening.DOTween;\nL_0020:\n\tv51 = ~v49.initialized;\n\tv52 = ~v51;\n\tif (v52) goto L_003B;\n\tv55 = UnityEngine.Application::get_isPlaying();\n\tv60 = v55 == 0;\n\tif (v60) goto L_003B;\n\tgoto L_0035;\n\tv83 = *([v79 @ X0_v7 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv84 = v83 == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_0035;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v79, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv86 = DG.Tweening.DOTween;\nL_0035:\n\tv59 = ~v89.isQuitting;\n\tif (v59) goto L_003F;\nL_003B:\n\treturn;\nL_003F:\n\tgoto L_0049;\n\tv94 = *([v57 @ X0_v8 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv95 = v94 == 0;\n\tv96 = ~v95;\n\tif (v96) goto L_0049;\n\tv97 = \"il2cpp_codegen_runtime_class_init\"(v57, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0049:\n\tDG.Tweening.DOTween::AutoInit();\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void InitCheck()
		{
			if (!initialized && Application.isPlaying && !isQuitting)
			{
				AutoInit();
			}
		}

		[Token(Token = "0x600005B")]
		[Address(RVA = "0x1361AC8", Offset = "0x1361AC8", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv38 = *([1EE8AC8]);\n\tv39 = *([v38 @ X8_v19]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, setter, endValue, plugin, methodInfo, v41, v42, v43, duration, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([2028831]) = v53;\nL_0023:\n\tgoto L_002A;\n\tv60 = *([v56 @ X0_v2+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_002A;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v56, setter, endValue, plugin, methodInfo, v41, v42, v43, duration, v44, v45, v46, v47, v48, v49, v50);\nL_002A:\n\tDG.Tweening.DOTween::InitCheck();\n\tgoto L_003A;\n\tv74 = *([v70 @ X0_v5+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tif (v76) goto L_003A;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v70, setter, endValue, plugin, methodInfo, v41, v42, v43, duration, v44, v45, v46, v47, v48, v49, v50);\nL_003A:\n\tv84 = DG.Tweening.Core.TweenManager::GetTweener();\n\tv85 = endValue->klass;\n\tv101 = DG.Tweening.Tweener::Setup(v84, getter, setter, &v85 @ V1_v1 (Il2CppClass<T2>), duration, plugin);\n\tv103 = v101 == 0;\n\tv104 = ~v103;\n\tif (v104) goto L_006A;\n\tgoto L_005D;\n\tv131 = *([v105 @ X0_v12+E0]);\n\tv132 = v131 == 0;\n\tv133 = ~v132;\n\tif (v133) goto L_005D;\n\tv135 = \"il2cpp_codegen_runtime_class_init\"(v105, v89, v90, v87, v94, v99, v42, v43, v100, v85, v45, v46, v47, v48, v49, v50);\nL_005D:\n\tDG.Tweening.Core.TweenManager::Despawn(v84, 1);\nL_006A:\n\treturn v117;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static TweenerCore<T1, T2, TPlugOptions> ApplyTo<T1, T2, TPlugOptions>(DOGetter<T1> getter, DOSetter<T1> setter, T2 endValue, float duration, ABSTweenPlugin<T1, T2, TPlugOptions> plugin = null) where TPlugOptions : struct, IPlugOptions
		{
			//IL_0020: Expected I, but got O
			//IL_003d: Expected O, but got I
			InitCheck();
			Tween tweener = TweenManager.GetTweener<T1, T2, TPlugOptions>();
			IntPtr intPtr = (IntPtr)endValue;
			bool flag = Tweener.Setup((TweenerCore<T1, T2, TPlugOptions>)tweener, getter, setter, (T2)(long)intPtr, duration, plugin);
			bool flag2 = !flag;
			bool flag3 = !flag2;
			TweenerCore<T1, T2, TPlugOptions> result = (TweenerCore<T1, T2, TPlugOptions>)tweener;
			if (!flag3)
			{
				TweenManager.Despawn(tweener);
				result = null;
			}
			return result;
		}

		[Token(Token = "0x600005C")]
		[Address(RVA = "0x107E8C4", Offset = "0x107E8C4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTween()
		{
		}

		[Token(Token = "0x600005D")]
		[Address(RVA = "0x107E8CC", Offset = "0x107E8CC", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv16 = *([1EBBF60]);\n\tv17 = *([v16 @ X8_v14]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2026A30]) = v37;\nL_001B:\n\tv45.Version = \"1.2.305\";\n\tv48.useSafeMode = 1;\n\tv49.nestedTweenFailureBehaviour = 0;\n\tv50.showUnityEditorReport = 0;\n\tv51.timeScale = 1f;\n\tv52.maxSmoothUnscaledTime = 0.15f;\n\tv55.rewindCallbackMode = 0;\n\tv57._logBehaviour = 2;\n\tv58.drawGizmos = 1;\n\tv60.defaultUpdateType = 0;\n\tv61.defaultTimeScaleIndependent = 0;\n\tv62.defaultAutoPlay = 3;\n\tv63.defaultAutoKill = 1;\n\tv64.defaultLoopType = 0;\n\tv66.defaultEaseType = 6;\n\tv67.defaultEaseOvershootOrAmplitude = 1.70158f;\n\tv70.defaultEasePeriod = 0f;\n\tv74 = new System.Collections.Generic.List`1<DG.Tweening.TweenCallback>();\n\tSystem.Collections.Generic.List`1<DG.Tweening.TweenCallback>::.ctor(v74);\n\tv80.GizmosDelegates = v74;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static DOTween()
		{
			List<TweenCallback> gizmosDelegates = new List<TweenCallback>();
			GizmosDelegates = gizmosDelegates;
		}
	}
}
