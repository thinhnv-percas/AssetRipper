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
	[Token(Token = "0x200000A")]
	public class DOTween
	{
		[Token(Token = "0x400000E")]
		public static readonly string Version;

		[Token(Token = "0x400000F")]
		public static bool useSafeMode;

		[Token(Token = "0x4000010")]
		public static SafeModeLogBehaviour safeModeLogBehaviour;

		[Token(Token = "0x4000011")]
		public static NestedTweenFailureBehaviour nestedTweenFailureBehaviour;

		[Token(Token = "0x4000012")]
		public static bool showUnityEditorReport;

		[Token(Token = "0x4000013")]
		public static float timeScale;

		[Token(Token = "0x4000014")]
		public static float unscaledTimeScale;

		[Token(Token = "0x4000015")]
		public static bool useSmoothDeltaTime;

		[Token(Token = "0x4000016")]
		public static float maxSmoothUnscaledTime;

		[Token(Token = "0x4000017")]
		internal static RewindCallbackMode rewindCallbackMode;

		[Token(Token = "0x4000018")]
		private static LogBehaviour _logBehaviour;

		[Token(Token = "0x4000019")]
		public static Func<LogType, object, bool> onWillLog;

		[Token(Token = "0x400001A")]
		public static bool drawGizmos;

		[Token(Token = "0x400001B")]
		public static bool debugMode;

		[Token(Token = "0x400001C")]
		private static bool _fooDebugStoreTargetId;

		[Token(Token = "0x400001D")]
		public static UpdateType defaultUpdateType;

		[Token(Token = "0x400001E")]
		public static bool defaultTimeScaleIndependent;

		[Token(Token = "0x400001F")]
		public static AutoPlay defaultAutoPlay;

		[Token(Token = "0x4000020")]
		public static bool defaultAutoKill;

		[Token(Token = "0x4000021")]
		public static LoopType defaultLoopType;

		[Token(Token = "0x4000022")]
		public static bool defaultRecyclable;

		[Token(Token = "0x4000023")]
		public static Ease defaultEaseType;

		[Token(Token = "0x4000024")]
		public static float defaultEaseOvershootOrAmplitude;

		[Token(Token = "0x4000025")]
		public static float defaultEasePeriod;

		[Token(Token = "0x4000026")]
		public static DOTweenComponent instance;

		[Token(Token = "0x4000027")]
		private static bool _foo_isQuitting;

		[Token(Token = "0x4000028")]
		internal static int maxActiveTweenersReached;

		[Token(Token = "0x4000029")]
		internal static int maxActiveSequencesReached;

		[Token(Token = "0x400002A")]
		internal static SafeModeReport safeModeReport;

		[Token(Token = "0x400002B")]
		internal static readonly List<TweenCallback> GizmosDelegates;

		[Token(Token = "0x400002C")]
		internal static bool initialized;

		[Token(Token = "0x400002D")]
		private static int _isQuittingFrame;

		[Token(Token = "0x17000001")]
		public static LogBehaviour logBehaviour
		{
			[Token(Token = "0x6000014")]
			[Address(RVA = "0xC05DD4", Offset = "0xC05DD4", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = DG.Tweening.DOTween;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A3565C]) = v34;\nL_0015:\n\tgoto L_001E;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = DG.Tweening.DOTween;\nL_001E:\n\treturn v42._logBehaviour;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return _logBehaviour;
			}
			[Token(Token = "0x6000015")]
			[Address(RVA = "0xC05E2C", Offset = "0xC05E2C", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = DG.Tweening.DOTween;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A3565D]) = v37;\nL_0017:\n\tgoto L_001D;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv44 = DG.Tweening.DOTween;\nL_001D:\n\tv45._logBehaviour = value;\n\tDG.Tweening.Core.Debugger::SetLogPriority(value);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_logBehaviour = value;
				Debugger.SetLogPriority(value);
			}
		}

		[Token(Token = "0x17000002")]
		public static bool debugStoreTargetId
		{
			[Token(Token = "0x6000016")]
			[Address(RVA = "0xC05E90", Offset = "0xC05E90", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = DG.Tweening.DOTween;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A3565E]) = v34;\nL_0015:\n\tgoto L_001A;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = DG.Tweening.DOTween;\nL_001A:\n\tv44 = ~v42.debugMode;\n\tif (v44) goto L_FFFFFFFF;\n\tgoto L_0024;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v40, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv58 = DG.Tweening.DOTween;\n\tv59 = *([v58 @ X0_v12+B8]);\nL_0024:\n\tv53 = ~v55.useSafeMode;\n\tif (v53) goto L_FFFFFFFF;\n\tgoto L_0032;\n\tv99 = \"il2cpp_codegen_runtime_class_init\"(v51, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv104 = DG.Tweening.DOTween;\n\tv102 = *([v104 @ X8_v10+B8]);\nL_0032:\n\tv77 = v101._fooDebugStoreTargetId == 0;\n\tv62 = ~v77;\n\tgoto L_003F;\nL_003F:\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (!debugMode || !useSafeMode)
				{
					return false;
				}
				bool flag = !_fooDebugStoreTargetId;
				return !flag;
			}
			[Token(Token = "0x6000017")]
			[Address(RVA = "0xC05F30", Offset = "0xC05F30", Length = "0x60")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = DG.Tweening.DOTween;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A3565F]) = v37;\nL_0017:\n\tgoto L_001E;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv44 = DG.Tweening.DOTween;\nL_001E:\n\tv45._fooDebugStoreTargetId = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_fooDebugStoreTargetId = value;
			}
		}

		[Token(Token = "0x17000003")]
		internal static bool isQuitting
		{
			[Token(Token = "0x6000018")]
			[Address(RVA = "0xC05F90", Offset = "0xC05F90", Length = "0xC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = DG.Tweening.DOTween;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35660]) = v34;\nL_0015:\n\tgoto L_001A;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = DG.Tweening.DOTween;\nL_001A:\n\tv44 = ~v42._foo_isQuitting;\n\tif (v44) goto L_FFFFFFFF;\n\tv46 = UnityEngine.Time::get_frameCount();\n\tv48 = v46 & 0x80000000;\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tif (v50) goto L_FFFFFFFF;\n\tgoto L_002C;\n\tv112 = \"il2cpp_codegen_runtime_class_init\"(v105, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv114 = DG.Tweening.DOTween;\nL_002C:\n\tv110 = UnityEngine.Time::get_frameCount();\n\tv55 = v111._isQuittingFrame != v110;\n\tif (v55) goto L_0040;\n\tgoto L_004B;\n\tgoto L_004B;\nL_0040:\n\tgoto L_0046;\n\tv119 = v117;\n\tv120 = \"il2cpp_codegen_runtime_class_init\"(v119, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv123 = DG.Tweening.DOTween;\nL_0046:\n\tv97._foo_isQuitting = 0;\nL_004B:\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0020: Expected I4, but got I8
				if (_foo_isQuitting)
				{
					int frameCount = Time.frameCount;
					if ((int)(frameCount & 0x80000000L) == 0)
					{
						int frameCount2 = Time.frameCount;
						if (_isQuittingFrame != frameCount2)
						{
							_foo_isQuitting = false;
							return false;
						}
					}
					return true;
				}
				return false;
			}
			[Token(Token = "0x6000019")]
			[Address(RVA = "0xC06058", Offset = "0xC06058", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv21 = DG.Tweening.DOTween;\n\tv22 = \"il2cpp_codegen_initialize_runtime_metadata\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A35661]) = v40;\nL_0019:\n\tgoto L_001D;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv47 = DG.Tweening.DOTween;\nL_001D:\n\tv48._foo_isQuitting = value;\n\tv50 = value == 0;\n\tif (v50) goto L_0034;\n\tv52 = UnityEngine.Time::get_frameCount();\n\tgoto L_002D;\n\tv71 = v69;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v71, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv74 = DG.Tweening.DOTween;\nL_002D:\n\tv63._isQuittingFrame = v52;\nL_0034:\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_foo_isQuitting = value;
				if (value)
				{
					int frameCount = Time.frameCount;
					_isQuittingFrame = frameCount;
				}
			}
		}

		[Token(Token = "0x600001A")]
		[Address(RVA = "0xC060F0", Offset = "0xC060F0", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv26 = UnityEngine.Application;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, useSafeMode, logBehaviour, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv50 = DG.Tweening.Core.DOTweenSettings;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, useSafeMode, logBehaviour, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv59 = DG.Tweening.DOTween;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, useSafeMode, logBehaviour, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv71 = \"DOTweenSettings\";\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, useSafeMode, logBehaviour, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A35662]) = v44;\nL_0024:\n\tgoto L_0029;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v45, useSafeMode, logBehaviour, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv54 = DG.Tweening.DOTween;\nL_0029:\n\tv57 = ~v55.initialized;\n\tif (v57) goto L_003A;\n\tgoto L_FFFFFFFF;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v53, useSafeMode, logBehaviour, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv81 = DG.Tweening.DOTween;\n\tv75 = *([v81 @ X8_v20+B8]);\n\tgoto L_0055;\nL_003A:\n\tgoto L_003D;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v66, useSafeMode, logBehaviour, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_003D:\n\tv80 = UnityEngine.Application::get_isPlaying();\n\tv88 = v80 == 0;\n\tif (v88) goto L_0055;\n\tgoto L_0049;\n\tv164 = \"il2cpp_codegen_runtime_class_init\"(v161, useSafeMode, logBehaviour, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0049:\n\tv166 = DG.Tweening.DOTween::get_isQuitting();\n\tv87 = v166 == 0;\n\tif (v87) goto L_005A;\nL_0055:\n\treturn returnVal1;\nL_005A:\n\tv172 = UnityEngine.Resources::Load(\"DOTweenSettings\");\n\tgoto L_0063;\n\tv178 = v173;\n\tv179 = \"il2cpp_codegen_runtime_class_init\"(v178, v170, logBehaviour, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0063:\n\tv148 = v172 == 0;\n\tif (v148) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_008A;\n\tv222 = v222_asT == 0;\n\tif (v222) goto L_FFFFFFFF;\n\tgoto L_008A;\nL_008A:\n\tv142 = recycleAllByDefault & 0xFFFF;\n\tv102 = useSafeMode & 0xFFFF;\n\treturnVal2 = DG.Tweening.DOTween::Init(v223, v142, v102, logBehaviour);\n\treturn returnVal2;\n// 103 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static IDOTweenInit Init(bool? recycleAllByDefault = null, bool? useSafeMode = null, LogBehaviour? logBehaviour = null)
		{
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Expected O, but got Unknown
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Expected O, but got Unknown
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
						bool? recycleAllByDefault2 = (bool?)(object)((_003F?)recycleAllByDefault & 0xFFFF);
						bool? flag2 = (bool?)(object)((_003F?)useSafeMode & 0xFFFF);
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

		[Token(Token = "0x600001B")]
		[Address(RVA = "0xC06844", Offset = "0xC06844", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv14 = UnityEngine.Application;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = DG.Tweening.Core.DOTweenSettings;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = DG.Tweening.DOTween;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv53 = \"DOTweenSettings\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A35663]) = v35;\nL_001E:\n\tgoto L_0021;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v36, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0021:\n\tv46 = UnityEngine.Application::get_isPlaying();\n\tv51 = v46 == 0;\n\tif (v51) goto L_0035;\n\tgoto L_002D;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v56, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_002D:\n\tv61 = DG.Tweening.DOTween::get_isQuitting();\n\tv63 = v61 == 0;\n\tif (v63) goto L_003A;\nL_0035:\n\treturn;\nL_003A:\n\tv133 = UnityEngine.Resources::Load(\"DOTweenSettings\");\n\tv134 = DG.Tweening.DOTween;\n\tv137 = *([v134 @ X8_v8 (Il2CppClass<DG.Tweening.DOTween>)+E0]) == 0;\n\tif (v137) goto L_0046;\n\tv138 = v133 == 0;\n\tv139 = ~v138;\n\tif (v139) goto L_0057;\n\tgoto L_FFFFFFFF;\nL_0046:\n\tv144 = v133 == 0;\n\tif (v144) goto L_FFFFFFFF;\nL_0057:\n\tgoto L_FFFFFFFF;\n\tgoto L_0074;\n\tv188 = v188_asT == 0;\n\tif (v188) goto L_FFFFFFFF;\n\tgoto L_0074;\nL_0074:\n\tv119 = DG.Tweening.DOTween::Init(v189, 0, 0, 0);\n\treturn;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void AutoInit()
		{
			//IL_0073: Expected I, but got O
			if (!Application.isPlaying || isQuitting)
			{
				return;
			}
			UnityEngine.Object obj = Resources.Load("DOTweenSettings");
			nint num = (nint)typeof(DOTween);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ X8_v8 (Il2CppClass<DG.Tweening.DOTween>)+E0]");
			if ((nint)0 != 0)
			{
				if ((object)obj == null)
				{
					goto IL_00e7;
				}
			}
			else if ((object)obj == null)
			{
				goto IL_00e7;
			}
			DOTweenSettings dOTweenSettings = obj as DOTweenSettings;
			DOTweenSettings settings = (DOTweenSettings)(((object)dOTweenSettings == null) ? null : obj);
			goto IL_0137;
			IL_00e7:
			settings = null;
			goto IL_0137;
			IL_0137:
			IDOTweenInit iDOTweenInit = Init(settings, null, null, null);
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0xC06270", Offset = "0xC06270", Length = "0x5D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0048;\n\tv30 = System.Boolean;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, recycleAllByDefault, useSafeMode, logBehaviour, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv53 = DG.Tweening.DOTween;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, recycleAllByDefault, useSafeMode, logBehaviour, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv68 = DG.Tweening.LogBehaviour;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, recycleAllByDefault, useSafeMode, logBehaviour, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv92 = Il2CppMethodInfo;\n\tv93 = \"il2cpp_codegen_initialize_runtime_metadata\"(v92, recycleAllByDefault, useSafeMode, logBehaviour, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv118 = Il2CppMethodInfo;\n\tv119 = \"il2cpp_codegen_initialize_runtime_metadata\"(v118, recycleAllByDefault, useSafeMode, logBehaviour, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv146 = Il2CppMethodInfo;\n\tv147 = \"il2cpp_codegen_initialize_runtime_metadata\"(v146, recycleAllByDefault, useSafeMode, logBehaviour, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv158 = Il2CppMethodInfo;\n\tv159 = \"il2cpp_codegen_initialize_runtime_metadata\"(v158, recycleAllByDefault, useSafeMode, logBehaviour, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv170 = UnityEngine.Object;\n\tv171 = \"il2cpp_codegen_initialize_runtime_metadata\"(v170, recycleAllByDefault, useSafeMode, logBehaviour, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv175 = System.String[];\n\tv176 = \"il2cpp_codegen_initialize_runtime_metadata\"(v175, recycleAllByDefault, useSafeMode, logBehaviour, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv227 = \", recycling: \";\n\tv228 = \"il2cpp_codegen_initialize_runtime_metadata\"(v227, recycleAllByDefault, useSafeMode, logBehaviour, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv264 = \"DOTween initialization (useSafeMode: \";\n\tv265 = \"il2cpp_codegen_initialize_runtime_metadata\"(v264, recycleAllByDefault, useSafeMode, logBehaviour, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv398 = \", logBehaviour: \";\n\tv399 = \"il2cpp_codegen_initialize_runtime_metadata\"(v398, recycleAllByDefault, useSafeMode, logBehaviour, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv417 = \")\";\n\tv418 = \"il2cpp_codegen_initialize_runtime_metadata\"(v417, recycleAllByDefault, useSafeMode, logBehaviour, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv459 = \"ON\";\n\tv460 = \"il2cpp_codegen_initialize_runtime_metadata\"(v459, recycleAllByDefault, useSafeMode, logBehaviour, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv527 = \"OFF\";\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v527, recycleAllByDefault, useSafeMode, logBehaviour, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A35664]) = v47;\nL_0048:\n\tgoto L_004F;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v48, recycleAllByDefault, useSafeMode, logBehaviour, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv57 = DG.Tweening.DOTween;\nL_004F:\n\tv62 = recycleAllByDefault & 0xFF;\n\tv64 = v62 == 0;\n\tv59.initialized = 1;\n\tif (v64) goto L_0065;\n\tv73 = System.Nullable`1<System.Boolean>::get_Value(&v83 @ stack_-34_v2 (System.Nullable`1<System.Boolean>));\n\tgoto L_0063;\n\tv120 = v94;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v120, v70, useSafeMode, logBehaviour, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv123 = DG.Tweening.DOTween;\nL_0063:\n\tv82.defaultRecyclable = v73;\nL_0065:\n\tv86 = v84 & 0xFF;\n\tv88 = v86 == 0;\n\tif (v88) goto L_007C;\n\tv100 = System.Nullable`1<System.Boolean>::get_Value(&v110 @ stack_-38_v2 (System.Nullable`1<System.Boolean>));\n\tgoto L_0078;\n\tv148 = v124;\n\tv149 = \"il2cpp_codegen_runtime_class_init\"(v148, v97, useSafeMode, logBehaviour, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv151 = DG.Tweening.DOTween;\nL_0078:\n\tv109.useSafeMode = v100;\nL_007C:\n\tv116 = logBehaviour == 0;\n\tif (v116) goto L_008E;\n\tv131 = System.Nullable`1<System.Int32Enum>::get_Value(&v129 @ stack_-40_v3 (System.Nullable`1<System.Int32Enum>));\n\tgoto L_008C;\n\tv160 = v140;\n\tv161 = \"il2cpp_codegen_runtime_class_init\"(v160, v130, useSafeMode, logBehaviour, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_008C:\n\tDG.Tweening.DOTween::set_logBehaviour(v131);\nL_008E:\n\tDG.Tweening.Core.DOTweenComponent::Create();\n\tgoto L_0098;\n\tv163 = \"il2cpp_codegen_runtime_class_init\"(v153, v134, useSafeMode, logBehaviour, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0098:\n\tv168 = UnityEngine.Object::op_Inequality(settings, 0);\n\tv173 = v168 == 0;\n\tif (v173) goto L_0136;\n\tv178 = useSafeMode == 0;\n\tv179 = ~v178;\n\tif (v179) goto L_00AD;\n\tgoto L_00AB;\n\tv400 = \"il2cpp_codegen_runtime_class_init\"(v266, v166, v167, logBehaviour, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv401 = DG.Tweening.DOTween;\nL_00AB:\n\tv235.useSafeMode = settings.useSafeMode;\nL_00AD:\n\tv239 = logBehaviour == 0;\n\tv240 = ~v239;\n\tif (v240) goto L_00BC;\n\tgoto L_00BA;\n\tv446 = \"il2cpp_codegen_runtime_class_init\"(v402, v166, v167, logBehaviour, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00BA:\n\tDG.Tweening.DOTween::set_logBehaviour(settings.logBehaviour);\nL_00BC:\n\tv347 = recycleAllByDefault == 0;\n\tif (v347) goto L_00C9;\n\tv404 = settings == 0;\n\tv322 = ~v404;\n\tif (v322) goto L_00CE;\n\tgoto L_0213;\nL_00C9:\n\tgoto L_00CD;\n\tv464 = \"il2cpp_codegen_runtime_class_init\"(v453, v166, v167, logBehaviour, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv465 = DG.Tweening.DOTween;\nL_00CD:\n\tv451.defaultRecyclable = settings.defaultRecyclable;\nL_00CE:\n\tv538 = settings.safeModeOptions;\n\tv461 = DG.Tweening.DOTween;\n\tv463 = *([v461 @ X8_v57 (Il2CppClass<DG.Tweening.DOTween>)+E0]) == 0;\n\tif (v463) goto L_00DC;\n\tv528.safeModeLogBehaviour = v538.logBehaviour;\n\tgoto L_00E2;\nL_00DC:\n\tv538 = settings.safeModeOptions;\n\tv305.safeModeLogBehaviour = v538.logBehaviour;\nL_00E2:\n\tv537.nestedTweenFailureBehaviour = v538.nestedTweenFailureBehaviour;\n\tv537.timeScale = settings.timeScale;\n\tv537.useSmoothDeltaTime = settings.useSmoothDeltaTime;\n\tv537.maxSmoothUnscaledTime = settings.maxSmoothUnscaledTime;\n\tv537.rewindCallbackMode = settings.rewindCallbackMode;\n\tv548 = recycleAllByDefault == 0;\n\tif (v548) goto L_00F9;\n\tv556 = System.Nullable`1<System.Boolean>::get_Value(&v83 @ stack_-34_v2 (System.Nullable`1<System.Boolean>));\n\tgoto L_0103;\nL_00F9:\n\tv562 = settings.defaultRecyclable == 0;\n\tv567 = ~v562;\nL_0103:\n\tgoto L_010A;\n\tv581 = v575;\n\tv582 = \"il2cpp_codegen_runtime_class_init\"(v581, v211, v167, logBehaviour, methodInfo, v33, v34, v35, v545, v37, v38, v39, v40, v41, v42, v43);\n\tv585 = DG.Tweening.DOTween;\nL_010A:\n\tv586.defaultRecyclable = v576;\n\tv586.showUnityEditorReport = settings.showUnityEditorReport;\n\tv586.drawGizmos = settings.drawGizmos;\n\tv586.defaultAutoPlay = settings.defaultAutoPlay;\n\tv586.defaultUpdateType = settings.defaultUpdateType;\n\tv586.defaultTimeScaleIndependent = settings.defaultTimeScaleIndependent;\n\tv586.defaultEaseType = settings.defaultEaseType;\n\tv586.defaultEaseOvershootOrAmplitude = settings.defaultEaseOvershootOrAmplitude;\n\tv586.defaultAutoKill = settings.defaultAutoKill;\n\tv586.defaultLoopType = settings.defaultLoopType;\n\tv586.debugMode = settings.debugMode;\n\tgoto L_012C;\n\tv603 = v23;\n\tv604 = \"il2cpp_codegen_initialize_runtime_metadata\"(v603, v211, v167, logBehaviour, methodInfo, v33, v34, v35, v204, v37, v38, v39, v40, v41, v42, v43);\n\tv609 = DG.Tweening.DOTween;\n\tv606 = 1;\n\t*([1A35756]) = v606;\nL_012C:\n\tgoto L_0131;\n\tv625 = v608;\n\tv626 = \"il2cpp_codegen_runtime_class_init\"(v625, v211, v167, logBehaviour, methodInfo, v33, v34, v35, v204, v37, v38, v39, v40, v41, v42, v43);\n\tv628 = DG.Tweening.DOTween;\nL_0131:\n\tv219._fooDebugStoreTargetId = settings.debugStoreTargetId;\nL_0136:\n\tgoto L_014B;\n\tv242 = DG.Tweening.Core.Debugger;\n\tv24\n// ... truncated")]
		private unsafe static IDOTweenInit Init(DOTweenSettings settings, bool? recycleAllByDefault, bool? useSafeMode, LogBehaviour? logBehaviour)
		{
			//IL_0438: Unknown result type (might be due to invalid IL or missing references)
			//IL_043d: Expected I4, but got Unknown
			//IL_0350: Unknown result type (might be due to invalid IL or missing references)
			//IL_0355: Expected I4, but got Unknown
			//IL_0120: Expected I, but got O
			//IL_0572: Expected I, but got O
			//IL_057b: Expected O, but got I
			int num = (_003F?)recycleAllByDefault & 0xFF;
			bool flag = num == 0;
			initialized = true;
			bool? flag2 = recycleAllByDefault;
			bool? flag3 = useSafeMode;
			if (!flag)
			{
				bool value = flag2.Value;
				defaultRecyclable = value;
				flag3 = useSafeMode;
			}
			int num2 = (_003F?)flag3 & 0xFF;
			bool flag4 = num2 == 0;
			bool? flag5 = useSafeMode;
			if (!flag4)
			{
				bool value2 = flag5.Value;
				DOTween.useSafeMode = value2;
			}
			bool flag6 = (object)logBehaviour == null;
			System.Int32Enum? int32Enum = (System.Int32Enum?)logBehaviour;
			if (!flag6)
			{
				LogBehaviour value3 = (LogBehaviour)int32Enum.Value;
				DOTween.logBehaviour = value3;
			}
			DOTweenComponent.Create();
			if (settings != null)
			{
				if ((object)useSafeMode == null)
				{
					DOTween.useSafeMode = settings.useSafeMode;
				}
				if ((object)logBehaviour == null)
				{
					DOTween.logBehaviour = settings.logBehaviour;
				}
				if ((object)recycleAllByDefault != null)
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
				nint num3 = (nint)typeof(DOTween);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v461 @ X8_v57 (Il2CppClass<DG.Tweening.DOTween>)+E0]");
				if ((nint)0 != 0)
				{
					safeModeLogBehaviour = safeModeOptions.logBehaviour;
				}
				else
				{
					safeModeOptions = settings.safeModeOptions;
					safeModeLogBehaviour = safeModeOptions.logBehaviour;
				}
				nestedTweenFailureBehaviour = safeModeOptions.nestedTweenFailureBehaviour;
				timeScale = settings.timeScale;
				useSmoothDeltaTime = settings.useSmoothDeltaTime;
				maxSmoothUnscaledTime = settings.maxSmoothUnscaledTime;
				rewindCallbackMode = settings.rewindCallbackMode;
				bool flag7;
				if ((object)recycleAllByDefault != null)
				{
					bool value4 = flag2.Value;
					flag7 = value4;
				}
				else
				{
					bool flag8 = !settings.defaultRecyclable;
					bool flag9 = !flag8;
					flag7 = flag9;
				}
				defaultRecyclable = flag7;
				showUnityEditorReport = settings.showUnityEditorReport;
				drawGizmos = settings.drawGizmos;
				defaultAutoPlay = settings.defaultAutoPlay;
				defaultUpdateType = settings.defaultUpdateType;
				defaultTimeScaleIndependent = settings.defaultTimeScaleIndependent;
				defaultEaseType = settings.defaultEaseType;
				defaultEaseOvershootOrAmplitude = settings.defaultEaseOvershootOrAmplitude;
				defaultAutoKill = settings.defaultAutoKill;
				defaultLoopType = settings.defaultLoopType;
				debugMode = settings.debugMode;
				_fooDebugStoreTargetId = settings.debugStoreTargetId;
			}
			if (Debugger._logPriority >= 2)
			{
				string[] array = new string[7] { "DOTween initialization (useSafeMode: ", null, null, null, null, null, null };
				bool flag10 = (byte)((nint)Version + 8) != 0;
				string text = (flag10 ? ((bool*)1) : ((bool*)null))->ToString();
				array[1] = text;
				array[2] = ", recycling: ";
				string text2 = (defaultRecyclable ? "ON" : "OFF");
				array[3] = text2;
				array[4] = ", logBehaviour: ";
				nint num4 = (nint)typeof(LogBehaviour);
				string text3 = ((Enum)num4).ToString();
				array[5] = text3;
				array[6] = ")";
				string message = string.Concat(array);
				Debugger.Log(message);
			}
			return instance;
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0xC0696C", Offset = "0xC0696C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = DG.Tweening.Core.TweenManager;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, sequencesCapacity, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A35665]) = v40;\nL_0019:\n\tgoto L_0024;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, sequencesCapacity, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tDG.Tweening.Core.TweenManager::SetCapacities(tweenersCapacity, sequencesCapacity);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetTweensCapacity(int tweenersCapacity, int sequencesCapacity)
		{
			TweenManager.SetCapacities(tweenersCapacity, sequencesCapacity);
		}

		[Token(Token = "0x600001E")]
		[Address(RVA = "0xC069D4", Offset = "0xC069D4", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = DG.Tweening.DOTween;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35666]) = v37;\nL_0017:\n\tgoto L_0020;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0020:\n\tDG.Tweening.DOTween::Clear(destroy, 0);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Clear(bool destroy = false)
		{
			Clear(destroy, isApplicationQuitting: false);
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0xC06A2C", Offset = "0xC06A2C", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv22 = DG.Tweening.DOTween;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, isApplicationQuitting, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv47 = Il2CppMethodInfo;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, isApplicationQuitting, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv54 = DG.Tweening.Core.TweenManager;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, isApplicationQuitting, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A35667]) = v41;\nL_001F:\n\tgoto L_0023;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v42, isApplicationQuitting, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0023:\n\tDG.Tweening.Core.TweenManager::PurgeAll(isApplicationQuitting);\n\tDG.Tweening.Plugins.Core.PluginsManager::PurgeAll();\n\tv57 = destroy == 0;\n\tif (v57) goto L_007B;\n\tgoto L_003A;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v60, v52, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv71 = DG.Tweening.DOTween;\nL_003A:\n\tv73.initialized = 0;\n\tv73.useSafeMode = 0;\n\tv73.showUnityEditorReport = 0;\n\tv73.drawGizmos = 1;\n\tv73.timeScale = 0f;\n\tv73.useSmoothDeltaTime = 0;\n\tv73.safeModeLogBehaviour = 1E-323d;\n\tv73.maxSmoothUnscaledTime = 0.15f;\n\tDG.Tweening.DOTween::set_logBehaviour(2);\n\tv121.defaultEaseType = 6;\n\tv121.defaultAutoPlay = 3;\n\tv134 = v121.GizmosDelegates;\n\tv121.onWillLog = 0;\n\tv121.defaultEaseOvershootOrAmplitude = 5.292621394E-315d;\n\tv121.defaultUpdateType = 0;\n\tv121.defaultTimeScaleIndependent = 0;\n\tv121.defaultLoopType = 0;\n\tv121.defaultAutoKill = 1;\n\tv121.defaultRecyclable = 0;\n\tv121.maxActiveTweenersReached = 0;\n\tv121.maxActiveSequencesReached = 0;\n\tv119 = v134._version + 1;\n\tv134._size = 0;\n\tv134._version = v119;\n\tv88 = v134._size < 1;\n\tif (v88) goto L_0073;\n\tSystem.Array::Clear(v134._items, 0, v134._size);\nL_0073:\n\tDG.Tweening.Core.DOTweenComponent::DestroyInstance();\n\treturn;\nL_007B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void Clear(bool destroy, bool isApplicationQuitting)
		{
			//IL_0101: Expected I4, but got F8
			TweenManager.PurgeAll(isApplicationQuitting);
			PluginsManager.PurgeAll();
			if (destroy)
			{
				initialized = false;
				useSafeMode = false;
				showUnityEditorReport = false;
				drawGizmos = true;
				timeScale = 0f;
				useSmoothDeltaTime = false;
				safeModeLogBehaviour = SafeModeLogBehaviour.None;
				maxSmoothUnscaledTime = 0.15f;
				logBehaviour = LogBehaviour.ErrorsOnly;
				defaultEaseType = Ease.OutQuad;
				defaultAutoPlay = AutoPlay.All;
				List<TweenCallback> gizmosDelegates = GizmosDelegates;
				onWillLog = null;
				defaultEaseOvershootOrAmplitude = 0f;
				defaultUpdateType = default(UpdateType);
				defaultTimeScaleIndependent = false;
				defaultLoopType = default(LoopType);
				defaultAutoKill = true;
				defaultRecyclable = false;
				maxActiveTweenersReached = 0;
				maxActiveSequencesReached = 0;
				int version = gizmosDelegates._version + 1;
				gizmosDelegates._size = 0;
				gizmosDelegates._version = version;
				if (gizmosDelegates.Count >= 1)
				{
					Array.Clear(gizmosDelegates._items, 0, gizmosDelegates.Count);
				}
				DOTweenComponent.DestroyInstance();
			}
		}

		[Token(Token = "0x6000020")]
		[Address(RVA = "0xC06B9C", Offset = "0xC06B9C", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35668]) = v34;\nL_0015:\n\tgoto L_001C;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001C:\n\tDG.Tweening.Core.TweenManager::PurgePools();\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ClearCachedTweens()
		{
			TweenManager.PurgePools();
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0xC06BEC", Offset = "0xC06BEC", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35669]) = v34;\nL_0015:\n\tgoto L_001C;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001C:\n\treturnVal1 = DG.Tweening.Core.TweenManager::Validate();\n\treturn returnVal1;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Validate()
		{
			return TweenManager.Validate();
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0xC06C3C", Offset = "0xC06C3C", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv26 = DG.Tweening.DOTween;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, v28, v29, v30, v31, v32, v33, v34, deltaTime, unscaledDeltaTime, v35, v36, v37, v38, v39, v40);\n\tv53 = DG.Tweening.Core.TweenManager;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, v28, v29, v30, v31, v32, v33, v34, deltaTime, unscaledDeltaTime, v35, v36, v37, v38, v39, v40);\n\tv45 = 1;\n\t*([1A3566A]) = v45;\nL_0020:\n\tgoto L_0022;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, v28, v29, v30, v31, v32, v33, v34, deltaTime, unscaledDeltaTime, v35, v36, v37, v38, v39, v40);\nL_0022:\n\tDG.Tweening.DOTween::InitCheck();\n\tgoto L_002C;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v56, v28, v29, v30, v31, v32, v33, v34, deltaTime, unscaledDeltaTime, v35, v36, v37, v38, v39, v40);\n\tv62 = DG.Tweening.Core.TweenManager;\nL_002C:\n\tv65 = ~v63.hasActiveManualTweens;\n\tif (v65) goto L_0056;\n\tgoto L_003D;\n\tv77 = v66;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v77, v28, v29, v30, v31, v32, v33, v34, deltaTime, unscaledDeltaTime, v35, v36, v37, v38, v39, v40);\n\tv82 = DG.Tweening.DOTween;\n\tv80 = DG.Tweening.Core.TweenManager;\nL_003D:\n\tgoto L_003F;\n\tv115 = \"il2cpp_codegen_runtime_class_init\"(v79, v28, v29, v30, v31, v32, v33, v34, deltaTime, unscaledDeltaTime, v35, v36, v37, v38, v39, v40);\nL_003F:\n\tv100 = v83.timeScale * deltaTime;\n\tv117 = v83.unscaledTimeScale * unscaledDeltaTime;\n\tv98 = v83.timeScale * v117;\n\tDG.Tweening.Core.TweenManager::Update(3, v100, v98);\n\treturn;\nL_0056:\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ManualUpdate(float deltaTime, float unscaledDeltaTime)
		{
			InitCheck();
			if (TweenManager.hasActiveManualTweens)
			{
				float deltaTime2 = timeScale * deltaTime;
				float num = unscaledTimeScale * unscaledDeltaTime;
				float independentTime = timeScale * num;
				TweenManager.Update(UpdateType.Manual, deltaTime2, independentTime);
			}
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0xC06DF0", Offset = "0xC06DF0", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, setter, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv55 = DG.Tweening.DOTween;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, setter, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A3566B]) = v47;\nL_0022:\n\tgoto L_0032;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, setter, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\nL_0032:\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, endValue, duration, 0);\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<float, float, FloatOptions> To(DOGetter<float> getter, DOSetter<float> setter, float endValue, float duration)
		{
			return ApplyTo<float, float, FloatOptions>(getter, setter, endValue, duration);
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0xC06E88", Offset = "0xC06E88", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, setter, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv55 = DG.Tweening.DOTween;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, setter, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A3566C]) = v47;\nL_0022:\n\tgoto L_0032;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, setter, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\nL_0032:\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, endValue, duration, 0);\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<double, double, NoOptions> To(DOGetter<double> getter, DOSetter<double> setter, double endValue, float duration)
		{
			return ApplyTo<double, double, NoOptions>(getter, setter, endValue, duration);
		}

		[Token(Token = "0x6000025")]
		[Address(RVA = "0xC06F20", Offset = "0xC06F20", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, setter, endValue, methodInfo, v33, v34, v35, v36, duration, v37, v38, v39, v40, v41, v42, v43);\n\tv55 = DG.Tweening.DOTween;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, setter, endValue, methodInfo, v33, v34, v35, v36, duration, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A3566D]) = v47;\nL_0022:\n\tgoto L_0032;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, setter, endValue, methodInfo, v33, v34, v35, v36, duration, v37, v38, v39, v40, v41, v42, v43);\nL_0032:\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, endValue, duration, 0);\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<int, int, NoOptions> To(DOGetter<int> getter, DOSetter<int> setter, int endValue, float duration)
		{
			return ApplyTo<int, int, NoOptions>(getter, setter, endValue, duration);
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0xC06FB8", Offset = "0xC06FB8", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, setter, endValue, methodInfo, v33, v34, v35, v36, duration, v37, v38, v39, v40, v41, v42, v43);\n\tv55 = DG.Tweening.DOTween;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, setter, endValue, methodInfo, v33, v34, v35, v36, duration, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A3566E]) = v47;\nL_0022:\n\tgoto L_0032;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, setter, endValue, methodInfo, v33, v34, v35, v36, duration, v37, v38, v39, v40, v41, v42, v43);\nL_0032:\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, endValue, duration, 0);\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<uint, uint, UintOptions> To(DOGetter<uint> getter, DOSetter<uint> setter, uint endValue, float duration)
		{
			return ApplyTo<uint, uint, UintOptions>(getter, setter, endValue, duration);
		}

		[Token(Token = "0x6000027")]
		[Address(RVA = "0xC07050", Offset = "0xC07050", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, setter, endValue, methodInfo, v33, v34, v35, v36, duration, v37, v38, v39, v40, v41, v42, v43);\n\tv55 = DG.Tweening.DOTween;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, setter, endValue, methodInfo, v33, v34, v35, v36, duration, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A3566F]) = v47;\nL_0022:\n\tgoto L_0032;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, setter, endValue, methodInfo, v33, v34, v35, v36, duration, v37, v38, v39, v40, v41, v42, v43);\nL_0032:\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, endValue, duration, 0);\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<long, long, NoOptions> To(DOGetter<long> getter, DOSetter<long> setter, long endValue, float duration)
		{
			return ApplyTo<long, long, NoOptions>(getter, setter, endValue, duration);
		}

		[Token(Token = "0x6000028")]
		[Address(RVA = "0xC070E8", Offset = "0xC070E8", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, setter, endValue, methodInfo, v33, v34, v35, v36, duration, v37, v38, v39, v40, v41, v42, v43);\n\tv55 = DG.Tweening.DOTween;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, setter, endValue, methodInfo, v33, v34, v35, v36, duration, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A35670]) = v47;\nL_0022:\n\tgoto L_0032;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, setter, endValue, methodInfo, v33, v34, v35, v36, duration, v37, v38, v39, v40, v41, v42, v43);\nL_0032:\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, endValue, duration, 0);\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<ulong, ulong, NoOptions> To(DOGetter<ulong> getter, DOSetter<ulong> setter, ulong endValue, float duration)
		{
			return ApplyTo<ulong, ulong, NoOptions>(getter, setter, endValue, duration);
		}

		[Token(Token = "0x6000029")]
		[Address(RVA = "0xC07180", Offset = "0xC07180", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, setter, endValue, methodInfo, v33, v34, v35, v36, duration, v37, v38, v39, v40, v41, v42, v43);\n\tv55 = DG.Tweening.DOTween;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, setter, endValue, methodInfo, v33, v34, v35, v36, duration, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A35671]) = v47;\nL_0022:\n\tgoto L_0032;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, setter, endValue, methodInfo, v33, v34, v35, v36, duration, v37, v38, v39, v40, v41, v42, v43);\nL_0032:\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, endValue, duration, 0);\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<string, string, StringOptions> To(DOGetter<string> getter, DOSetter<string> setter, string endValue, float duration)
		{
			return (TweenerCore<string, string, StringOptions>)(object)ApplyTo<object, object, StringOptions>(getter, (DOSetter<object>)setter, endValue, duration);
		}

		[Token(Token = "0x600002A")]
		[Address(RVA = "0xC07218", Offset = "0xC07218", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv34 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, setter, methodInfo, v37, v38, v39, v40, v41, endValue, v0, duration, v42, v43, v44, v45, v46);\n\tv58 = DG.Tweening.DOTween;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, setter, methodInfo, v37, v38, v39, v40, v41, endValue, v0, duration, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A35672]) = v50;\nL_0025:\n\tgoto L_0038;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v51, setter, methodInfo, v37, v38, v39, v40, v41, endValue, v0, duration, v42, v43, v44, v45, v46);\nL_0038:\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, endValue, duration, 0);\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector2, Vector2, VectorOptions> To(DOGetter<Vector2> getter, DOSetter<Vector2> setter, Vector2 endValue, float duration)
		{
			return ApplyTo<Vector2, Vector2, VectorOptions>(getter, setter, endValue, duration);
		}

		[Token(Token = "0x600002B")]
		[Address(RVA = "0xC072C0", Offset = "0xC072C0", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv38 = Il2CppMethodInfo;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, setter, methodInfo, v41, v42, v43, v44, v45, endValue, v0, v2, duration, v46, v47, v48, v49);\n\tv61 = DG.Tweening.DOTween;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, setter, methodInfo, v41, v42, v43, v44, v45, endValue, v0, v2, duration, v46, v47, v48, v49);\n\tv53 = 1;\n\t*([1A35673]) = v53;\nL_0028:\n\tgoto L_003D;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v54, setter, methodInfo, v41, v42, v43, v44, v45, endValue, v0, v2, duration, v46, v47, v48, v49);\nL_003D:\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, endValue, duration, 0);\n\treturn returnVal1;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> To(DOGetter<Vector3> getter, DOSetter<Vector3> setter, Vector3 endValue, float duration)
		{
			return ApplyTo<Vector3, Vector3, VectorOptions>(getter, setter, endValue, duration);
		}

		[Token(Token = "0x600002C")]
		[Address(RVA = "0xC07370", Offset = "0xC07370", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv42 = Il2CppMethodInfo;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, setter, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv64 = DG.Tweening.DOTween;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, setter, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv56 = 1;\n\t*([1A35674]) = v56;\nL_002B:\n\tgoto L_0042;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v57, setter, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\nL_0042:\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, endValue, duration, 0);\n\treturn returnVal1;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector4, Vector4, VectorOptions> To(DOGetter<Vector4> getter, DOSetter<Vector4> setter, Vector4 endValue, float duration)
		{
			return ApplyTo<Vector4, Vector4, VectorOptions>(getter, setter, endValue, duration);
		}

		[Token(Token = "0x600002D")]
		[Address(RVA = "0xC07430", Offset = "0xC07430", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv38 = Il2CppMethodInfo;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, setter, methodInfo, v41, v42, v43, v44, v45, endValue, v0, v2, duration, v46, v47, v48, v49);\n\tv61 = DG.Tweening.DOTween;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, setter, methodInfo, v41, v42, v43, v44, v45, endValue, v0, v2, duration, v46, v47, v48, v49);\n\tv53 = 1;\n\t*([1A35675]) = v53;\nL_0028:\n\tgoto L_003D;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v54, setter, methodInfo, v41, v42, v43, v44, v45, endValue, v0, v2, duration, v46, v47, v48, v49);\nL_003D:\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, endValue, duration, 0);\n\treturn returnVal1;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Quaternion, Vector3, QuaternionOptions> To(DOGetter<Quaternion> getter, DOSetter<Quaternion> setter, Vector3 endValue, float duration)
		{
			return ApplyTo<Quaternion, Vector3, QuaternionOptions>(getter, setter, endValue, duration);
		}

		[Token(Token = "0x600002E")]
		[Address(RVA = "0xC074E0", Offset = "0xC074E0", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv42 = Il2CppMethodInfo;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, setter, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv64 = DG.Tweening.DOTween;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, setter, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv56 = 1;\n\t*([1A35676]) = v56;\nL_002B:\n\tgoto L_0041;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v57, setter, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\nL_0041:\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, 0, endValue, Il2CppMethodInfo);\n\treturn returnVal1;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Color, Color, ColorOptions> To(DOGetter<Color> getter, DOSetter<Color> setter, Color endValue, float duration)
		{
			//IL_002b: Expected O, but got I
			Color color = default(Color);
			return ApplyTo(getter, setter, default(Color), color.r, (ABSTweenPlugin<Color, Color, ColorOptions>)0);
		}

		[Token(Token = "0x600002F")]
		[Address(RVA = "0xC075A0", Offset = "0xC075A0", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv42 = Il2CppMethodInfo;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, setter, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv64 = DG.Tweening.DOTween;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, setter, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\n\tv56 = 1;\n\t*([1A35677]) = v56;\nL_002B:\n\tgoto L_0042;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v57, setter, methodInfo, v45, v46, v47, v48, v49, endValue, v0, v2, v3, duration, v50, v51, v52);\nL_0042:\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, endValue, duration, 0);\n\treturn returnVal1;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Rect, Rect, RectOptions> To(DOGetter<Rect> getter, DOSetter<Rect> setter, Rect endValue, float duration)
		{
			return ApplyTo<Rect, Rect, RectOptions>(getter, setter, endValue, duration);
		}

		[Token(Token = "0x6000030")]
		[Address(RVA = "0xC07660", Offset = "0xC07660", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, setter, endValue, methodInfo, v33, v34, v35, v36, duration, v37, v38, v39, v40, v41, v42, v43);\n\tv55 = DG.Tweening.DOTween;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, setter, endValue, methodInfo, v33, v34, v35, v36, duration, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A35678]) = v47;\nL_0022:\n\tgoto L_0032;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, setter, endValue, methodInfo, v33, v34, v35, v36, duration, v37, v38, v39, v40, v41, v42, v43);\nL_0032:\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, endValue, duration, 0);\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener To(DOGetter<RectOffset> getter, DOSetter<RectOffset> setter, RectOffset endValue, float duration)
		{
			return ApplyTo<object, object, NoOptions>(getter, (DOSetter<object>)setter, endValue, duration);
		}

		[Token(Token = "0x6000031")]
		[Address(RVA = "0xDA999C", Offset = "0xDA999C", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv39 = *([endValue @ X3 (T2)+38]) == 0;\n\tv40 = ~v39;\n\tif (v40) goto L_0027;\n\tv63 = *([endValue @ X3 (T2)+38]) == 0;\n\tv54 = ~v63;\n\tif (v54) goto L_0027;\n\tv52 = 0xB3490C(endValue, getter, setter, endValue, methodInfo, v45, v46, v47, duration, v30, v28, v26, v24, v48, v49, v50);\nL_0027:\n\tgoto L_0029;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v59, getter, setter, endValue, methodInfo, v45, v46, v47, duration, v30, v28, v26, v24, v48, v49, v50);\nL_0029:\n\t;\n\t// 62 MakeStruct v86 @ AGGDADA54_2_v1 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), duration @ V0 (System.Single), v30 @ V1, v28 @ V2, v26 @ V3\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, v86, v24, plugin);\n\treturn returnVal1;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<T1, T2, TPlugOptions> To<T1, T2, TPlugOptions>(ABSTweenPlugin<T1, T2, TPlugOptions> plugin, DOGetter<T1> getter, DOSetter<T1> setter, T2 endValue, float duration) where TPlugOptions : struct, IPlugOptions
		{
			//IL_0094: Expected F4, but got O
			//IL_00a1: Expected F4, but got O
			//IL_00ae: Expected F4, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [endValue @ X3 (T2)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [endValue @ X3 (T2)+38]");
				if ((nint)0 == 0)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @B3490C");
				}
			}
			Quaternion endValue2 = default(Quaternion);
			endValue2.x = duration;
			object obj = default(object);
			endValue2.y = (float)obj;
			object obj2 = default(object);
			endValue2.z = (float)obj2;
			object obj3 = default(object);
			endValue2.w = (float)obj3;
			float duration2 = default(float);
			return (TweenerCore<T1, T2, TPlugOptions>)(object)ApplyTo((DOGetter<Quaternion>)(object)getter, (DOSetter<Quaternion>)(object)setter, endValue2, duration2, (ABSTweenPlugin<Quaternion, Quaternion, NoOptions>)(object)plugin);
		}

		[Token(Token = "0x6000032")]
		[Address(RVA = "0xC076F8", Offset = "0xC076F8", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv34 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, setter, axisConstraint, methodInfo, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv58 = DG.Tweening.DOTween;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, setter, axisConstraint, methodInfo, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A35679]) = v50;\nL_0024:\n\tgoto L_002E;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v51, setter, axisConstraint, methodInfo, v37, v38, v39, v40, endValue, duration, v41, v42, v43, v44, v45, v46);\nL_002E:\n\t// 46 MakeStruct v69 @ AGGC0B788_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), endValue @ V0 (System.Single), endValue @ V0 (System.Single), endValue @ V0 (System.Single)\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, v69, duration, 0);\n\treturnVal1.plugOptions.axisConstraint = axisConstraint;\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3, VectorOptions> ToAxis(DOGetter<Vector3> getter, DOSetter<Vector3> setter, float endValue, float duration, AxisConstraint axisConstraint = AxisConstraint.X)
		{
			Vector3 endValue2 = default(Vector3);
			endValue2.x = endValue;
			endValue2.y = endValue;
			endValue2.z = endValue;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ApplyTo<Vector3, Vector3, VectorOptions>(getter, setter, endValue2, duration);
			tweenerCore.plugOptions.axisConstraint = axisConstraint;
			return tweenerCore;
		}

		[Token(Token = "0x6000033")]
		[Address(RVA = "0xC077AC", Offset = "0xC077AC", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, setter, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv55 = DG.Tweening.DOTween;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, setter, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A3567A]) = v47;\nL_0022:\n\tgoto L_002D;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, setter, methodInfo, v33, v34, v35, v36, v37, endValue, duration, v38, v39, v40, v41, v42, v43);\nL_002D:\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, 0, 0f, Il2CppMethodInfo);\n\tv68 = returnVal1 == 0;\n\tif (v68) goto L_003D;\n\tv70 = ~returnVal1.<active>k__BackingField;\n\tif (v70) goto L_003D;\n\treturnVal1.plugOptions.alphaOnly = 1;\nL_003D:\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Color, Color, ColorOptions> ToAlpha(DOGetter<Color> getter, DOSetter<Color> setter, float endValue, float duration)
		{
			//IL_0027: Expected O, but got I
			TweenerCore<Color, Color, ColorOptions> tweenerCore = ApplyTo(getter, setter, default(Color), 0f, (ABSTweenPlugin<Color, Color, ColorOptions>)0);
			if (tweenerCore != null && tweenerCore._003Cactive_003Ek__BackingField)
			{
				tweenerCore.plugOptions.alphaOnly = true;
			}
			return tweenerCore;
		}

		[Token(Token = "0x6000034")]
		[Address(RVA = "0xC07880", Offset = "0xC07880", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0030;\n\tv38 = DG.Tweening.Core.DOGetter`1<System.Single>;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v41, v42, v43, v44, v45, v46, startValue, endValue, duration, v47, v48, v49, v50, v51);\n\tv59 = DG.Tweening.Core.DOSetter`1<System.Single>;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v41, v42, v43, v44, v45, v46, startValue, endValue, duration, v47, v48, v49, v50, v51);\n\tv64 = DG.Tweening.DOTween;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, methodInfo, v41, v42, v43, v44, v45, v46, startValue, endValue, duration, v47, v48, v49, v50, v51);\n\tv68 = Il2CppMethodInfo;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, methodInfo, v41, v42, v43, v44, v45, v46, startValue, endValue, duration, v47, v48, v49, v50, v51);\n\tv86 = Il2CppMethodInfo;\n\tv87 = \"il2cpp_codegen_initialize_runtime_metadata\"(v86, methodInfo, v41, v42, v43, v44, v45, v46, startValue, endValue, duration, v47, v48, v49, v50, v51);\n\tv93 = Il2CppMethodInfo;\n\tv94 = \"il2cpp_codegen_initialize_runtime_metadata\"(v93, methodInfo, v41, v42, v43, v44, v45, v46, startValue, endValue, duration, v47, v48, v49, v50, v51);\n\tv136 = DG.Tweening.DOTween+<>c__DisplayClass67_0;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v136, methodInfo, v41, v42, v43, v44, v45, v46, startValue, endValue, duration, v47, v48, v49, v50, v51);\n\tv55 = 1;\n\t*([1A3567B]) = v55;\nL_0030:\n\tv57 = new DG.Tweening.DOTween+<>c__DisplayClass67_0();\n\tSystem.Object::.ctor(v57);\n\tv57.setter = setter;\n\tv57.v = startValue;\n\tv83 = new DG.Tweening.Core.DOGetter`1<System.Single>();\n\tDG.Tweening.Core.DOGetter`1<System.Single>::.ctor(v83, v57, Il2CppMethodInfo);\n\tv96 = new DG.Tweening.Core.DOSetter`1<System.Single>();\n\tDG.Tweening.Core.DOSetter`1<System.Single>::.ctor(v96, v57, Il2CppMethodInfo);\n\tgoto L_005C;\n\tv141 = \"il2cpp_codegen_runtime_class_init\"(v139, v137, v106, v104, v43, v44, v45, v46, startValue, endValue, duration, v47, v48, v49, v50, v51);\nL_005C:\n\tv145 = DG.Tweening.DOTween::To(v83, v96, endValue, duration);\n\treturnVal2 = DG.Tweening.Core.Extensions::NoFrom(v145);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Tweener To(DOSetter<float> setter, float startValue, float endValue, float duration)
		{
			DOGetter<float> getter = () => startValue;
			DOSetter<float> setter2 = delegate(float x)
			{
				//IL_002d: Expected F4, but got I
				DOSetter<float> dOSetter = setter;
				startValue = x;
				setter((nint)dOSetter.method);
			};
			TweenerCore<float, float, FloatOptions> t = To(getter, setter2, endValue, duration);
			return t.NoFrom();
		}

		[Token(Token = "0x6000035")]
		[Address(RVA = "0xC079F0", Offset = "0xC079F0", Length = "0x3F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0044;\n\tv62 = DG.Tweening.DOTween;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, setter, vibrato, methodInfo, v65, v66, v67, v68, direction, v0, v2, duration, elasticity, v69, v70, v71);\n\tv92 = Il2CppMethodInfo;\n\tv93 = \"il2cpp_codegen_initialize_runtime_metadata\"(v92, setter, vibrato, methodInfo, v65, v66, v67, v68, direction, v0, v2, duration, elasticity, v69, v70, v71);\n\tv123 = Il2CppMethodInfo;\n\tv124 = \"il2cpp_codegen_initialize_runtime_metadata\"(v123, setter, vibrato, methodInfo, v65, v66, v67, v68, direction, v0, v2, duration, elasticity, v69, v70, v71);\n\tv140 = System.Single[];\n\tv141 = \"il2cpp_codegen_initialize_runtime_metadata\"(v140, setter, vibrato, methodInfo, v65, v66, v67, v68, direction, v0, v2, duration, elasticity, v69, v70, v71);\n\tv162 = UnityEngine.Vector3[];\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v162, setter, vibrato, methodInfo, v65, v66, v67, v68, direction, v0, v2, duration, elasticity, v69, v70, v71);\n\tv75 = 1;\n\t*([1A3567C]) = v75;\nL_0044:\n\tv90 = elasticity > 1f;\n\tif (v90) goto L_0058;\n\tv104 = elasticity >= 0;\n\tif (v104) goto L_0058;\nL_0058:\n\tgoto L_0066;\n\tv126 = System.Math;\n\tv127 = \"il2cpp_codegen_initialize_runtime_metadata\"(v126, setter, vibrato, methodInfo, v65, v66, v67, v68, v105, v76, v2, duration, elasticity, v69, v70, v71);\n\tv130 = 1;\n\t*([1A35759]) = v130;\nL_0066:\n\tgoto L_006A;\n\tv142 = \"il2cpp_codegen_runtime_class_init\"(v134, setter, vibrato, methodInfo, v65, v66, v67, v68, v105, v76, v2, duration, elasticity, v69, v70, v71);\nL_006A:\n\tv146 = vibrato * duration;\n\tv160 = v146 != 0x7F800000;\n\tif (v160) goto L_FFFFFFFF;\n\tgoto L_0080;\nL_0080:\n\tv168 = v165 - 2;\n\tv169 = v168 < 0;\n\tv170 = v168 == 0;\n\tv171 = v165 ^ 2;\n\tv172 = v165 ^ v168;\n\tv173 = v171 & v172;\n\tv174 = v173 < 0;\n\tv176 = v169 == v174;\n\tv177 = ~v170;\n\tv178 = v176 & v177;\n\tv179 = ~v178;\n\tif (v179) goto L_FFFFFFFF;\n\tgoto L_0092;\nL_0092:\n\t// 146 NewArr v184 @ X0_v6 (System.Single[]), typeof(System.Single[]), v182 @ X24_v1 (System.Single)\n\tv187 = direction * direction;\n\tv188 = direction.y * direction.y;\n\tv190 = direction.z * direction.z;\n\tv192 = v187 + v188;\n\tv193 = v190 + v192;\n\tv549 = UnityEngine.Mathf::Sqrt(v193);\n\tv236 = v549 / v182;\nL_00AF:\n\tv234 = v353 + 1;\n\tv472 = v234 / v182;\n\tv374 = v472 * duration;\n\tv375 = v375 + v374;\n\tv184[v353 @ X10_v3 (System.Int32)] = v374;\n\tv356 = v182 != v234;\n\tif (v356) goto L_00AF;\n\tv475 = duration / v375;\nL_00CF:\n\tv535 = v475 * v184[v474 @ X10_v7 (System.Int32)];\n\tv184[v474 @ X10_v7 (System.Int32)] = v535;\n\tv474 = v474 + 1;\n\tv518 = v182 != v474;\n\tif (v518) goto L_00CF;\n\t// 225 NewArr v540 @ X0_v12 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), v182 @ X24_v1 (System.Single)\n\tv541 = direction / v549;\n\tv542 = direction.y / v549;\n\tv219 = v182 - 1;\n\tv325 = direction.z / v549;\n\tv205 = v540 + 0x28;\nL_00F0:\n\tv562 = v208 < v219;\n\tv303 = ~v562;\n\tif (v303) goto L_0135;\n\tv563 = v208 == 0;\n\tif (v563) goto L_0152;\n\tv566 = v208 & 1;\n\tv567 = v566 == 0;\n\tv568 = ~v567;\n\tif (v568) goto L_0159;\n\tgoto L_0107;\n\tv578 = v132;\n\tv579 = \"il2cpp_codegen_initialize_runtime_metadata\"(v578, v230, vibrato, methodInfo, v65, v66, v67, v68, v258, v346, v341, v190, elasticity, v69, v70, v71);\n\t*([1A3575A]) = v337;\nL_0107:\n\tv581 = v549 * v549;\n\tv262 = v193 <= v581;\n\tif (v262) goto L_0126;\n\tgoto L_0120;\n\tv664 = \"il2cpp_codegen_runtime_class_init\"(v603, v230, vibrato, methodInfo, v65, v66, v67, v68, v583, v584, v585, v190, elasticity, v69, v70, v71);\nL_0120:\n\tv650 = v325 * v549;\n\tv607 = v541 * v549;\n\tv652 = v542 * v549;\nL_0126:\n\tv667 = v208 < v540.Length;\n\tv507 = ~v667;\n\tv477 = ~v507;\n\tif (v477) goto L_018B;\n\tgoto L_01C8;\nL_0135:\n\tgoto L_0146;\n\tv569 = v253;\n\tv570 = \"il2cpp_codegen_initialize_runtime_metadata\"(v569, v230, vibrato, methodInfo, v65, v66, v67, v68, v258, v346, v341, v190, elasticity, v69, v70, v71);\n\t*([1A35519]) = v337;\nL_0146:\n\tv599 = UnityEngine.Vector3;\n\tv600 = *([v599 @ X8_v24 (Il2CppClass<UnityEngine.Vector3>)+B8]);\n\t*([v205 @ X26_v4-8]) = v600.zeroVector;\n\t*([v205 @ X26_v4]) = *([v600 @ X8_v25 (Il2CppStaticFields<UnityEngine.Vector3>)+8]);\n\tgoto L_018F;\nL_0152:\n\t*([v540 @ X0_v12 (UnityEngine.Vector3[])+20]) = direction;\n\t*([v540 @ X0_v12 (UnityEngine.Vector3[])+24]) = direction.y;\n\t*([v540 @ X0_v12 (UnityEngine.Vector3[])+28]) = direction.z;\n\tgoto L_018E;\nL_0159:\n\tgoto L_0160;\n\tv588 = v132;\n\tv589 = \"il2cpp_codegen_initialize_runtime_metadata\"(v588, v230, vibrato, methodInfo, v65, v66, v67, v68, v258, v346, v341, v190, elasticity, v69, v70, v71);\n\t*([1A3575A]) = v337;\nL_0160:\n\tv199 = v108 * v549;\n\tv594 = v199 * v199;\n\tv264 = v193 <= v594;\n\tif (v264) goto L_0188;\n\tgoto L_0178;\n\tv668 = \"il2cpp_codegen_runtime_class_init\"(v612, v230, vibrato, methodInfo, v65, v66, v67, v68, v596, v592, v593, v190, elasticity, v69, v70, v71);\nL_0178:\n\tv342 = v325 * v199;\n\tv616 = v541 * v199;\n\tv347 = v542 * v199;\nL_0188:\n\tv624 = -v259;\n\tv652 = -v347;\n\tv650 = -v342;\nL_018B:\n\t*([v205 @ X26_v4-8]) = v624;\n\t*([v205 @ X26_v4-4]) = v652;\n\t*([v205 @ X26_v4]) = v650;\nL_018E:\n\tv549 = v549 - v236;\nL_018F:\n\tv208 = v208 + 1;\n\tv205 = v205 + 0xC;\n\tv426 = v182 != v208;\n\tif (v426) goto L_00F0;\n\tgoto L_01A8;\n\tv680 = \"il2cpp_codegen_runtime_class_init\"(v674, v230, vibrato, methodInfo, v65, v66, v67, v68, v424, v470, v468, v190, elasticity, v69, v70, v71);\nL_01A8:\n\tv685 = DG.Tweening.DOTween::ToArray(getter, setter, v540, v184);\n\tv689 = DG.Tweening.Core.Extensions::NoFrom(v685);\n\treturnVal2 = DG.Tweening.Core.Extensions::SetSpecialStartupMode(v689, 3);\n\treturn returnVal2;\nL_01C8:\n\tv306 = new System.IndexOutOfRangeException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 319 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> Punch(DOGetter<Vector3> getter, DOSetter<Vector3> setter, Vector3 direction, float duration, int vibrato = 10, float elasticity = 1f)
		{
			//IL_04f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_04fd: Expected O, but got Unknown
			//IL_050a: Expected O, but got F4
			//IL_0296: Expected O, but got I
			//IL_0387: Expected I, but got O
			//IL_0390: Expected I, but got O
			//IL_03a6: Expected O, but got I
			//IL_05ff: Expected O, but got I
			//IL_0411: Unsupported input type for neg.
			//IL_0411: Unknown result type (might be due to invalid IL or missing references)
			//IL_0416: Expected O, but got Unknown
			//IL_05dd: Expected O, but got F4
			//IL_0408: Expected O, but got F4
			//IL_0336: Expected O, but got F4
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
			float num2 = (float)vibrato * duration;
			float num3 = ((num2 != float.PositiveInfinity) ? num2 : -0f);
			float num4 = num3 - 3E-45f;
			bool flag3 = num4 < 0f;
			bool flag4 = num4 == 0f;
			object obj = num3 ^ 2;
			object obj2 = num3 ^ num4;
			int num5 = (int)((nint)obj & (nint)obj2);
			bool flag5 = num5 < 0;
			bool flag6 = flag3 == flag5;
			bool flag7 = !flag4;
			float num6 = ((!(flag6 && flag7)) ? 3E-45f : num3);
			float[] array = new float[num6];
			Vector3 vector = default(Vector3);
			float num7 = vector.x * vector.x;
			float num8 = direction.y * direction.y;
			float num9 = direction.z * direction.z;
			float num10 = num7 + num8;
			float num11 = num9 + num10;
			float num12 = Mathf.Sqrt(num11);
			float num13 = num12 / num6;
			int num14 = 0;
			float num15 = 0f;
			bool flag8;
			do
			{
				int num16 = num14 + 1;
				float num17 = (float)num16 / num6;
				float num18 = num17 * duration;
				num15 += num18;
				array[num14] = num18;
				flag8 = num6 != (float)num16;
				num14 = num16;
			}
			while (flag8);
			float num19 = duration / num15;
			int num20 = 0;
			do
			{
				float num21 = num19 * array[num20];
				array[num20] = num21;
				num20++;
			}
			while (num6 != (float)num20);
			Vector3[] array2 = new Vector3[num6];
			float num22 = vector.x / num12;
			float num23 = direction.y / num12;
			float num24 = num6 - float.Epsilon;
			float num25 = direction.z / num12;
			object obj3 = (nint)array2 + 40;
			int num26 = 0;
			while (true)
			{
				if ((float)num26 < num24)
				{
					if (num26 != 0)
					{
						float num33;
						if ((num26 & 1) != 0)
						{
							float num27 = num * num12;
							float num28 = num27 * num27;
							bool flag9 = !(num11 > num28);
							Vector3 vector2 = direction;
							float num29 = direction.z;
							float num30 = direction.y;
							if (!flag9)
							{
								num29 = num25 * num27;
								float num31 = num22 * num27;
								num30 = num23 * num27;
								vector2 = (Vector3)num31;
							}
							Vector3 vector3 = 0 - vector2;
							float num32 = 0f - num30;
							num33 = 0f - num29;
						}
						else
						{
							float num34 = num12 * num12;
							bool flag10 = !(num11 > num34);
							Vector3 vector3 = direction;
							num33 = direction.z;
							float num32 = direction.y;
							if (!flag10)
							{
								num33 = num25 * num12;
								float num35 = num22 * num12;
								num32 = num23 * num12;
								vector3 = (Vector3)num35;
							}
							if (num26 >= array2.Length)
							{
								break;
							}
						}
						obj3 = num33;
					}
					else
					{
						_ = direction.y;
						_ = direction.z;
					}
					num12 -= num13;
				}
				else
				{
					nint num36 = (nint)typeof(Vector3);
					nint num37 = (nint)Vector3.zero;
					_ = Vector3.zero;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v600 @ X8_v25 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
					obj3 = 0;
				}
				num26++;
				obj3 = (nint)obj3 + 12;
				if (num6 == (float)num26)
				{
					TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = ToArray(getter, setter, array2, array);
					TweenerCore<Vector3, object, Vector3ArrayOptions> t2 = ((TweenerCore<Vector3, object, Vector3ArrayOptions>)(object)t).NoFrom();
					return ((TweenerCore<Vector3, Vector3[], Vector3ArrayOptions>)(object)t2).SetSpecialStartupMode(SpecialStartupMode.SetPunch);
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			return (TweenerCore<Vector3, Vector3[], Vector3ArrayOptions>)(object)new NullReferenceException();
		}

		[Token(Token = "0x6000036")]
		[Address(RVA = "0xC08004", Offset = "0xC08004", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv50 = DG.Tweening.DOTween;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, setter, vibrato, ignoreZAxis, fadeOut, randomnessMode, methodInfo, v53, duration, strength, randomness, v54, v55, v56, v57, v58);\n\tv61 = 1;\n\t*([1A3567D]) = v61;\nL_0027:\n\tgoto L_0042;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v62, setter, vibrato, ignoreZAxis, fadeOut, randomnessMode, methodInfo, v53, duration, strength, randomness, v54, v55, v56, v57, v58);\nL_0042:\n\t// 66 MakeStruct v92 @ AGGC0C0C8_3_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), strength @ V1 (System.Single), strength @ V1 (System.Single), strength @ V1 (System.Single)\n\treturnVal1 = DG.Tweening.DOTween::Shake(getter, setter, duration, v92, vibrato, randomness, ignoreZAxis, 0, fadeOut, randomnessMode);\n\treturn returnVal1;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> Shake(DOGetter<Vector3> getter, DOSetter<Vector3> setter, float duration, float strength = 3f, int vibrato = 10, float randomness = 90f, bool ignoreZAxis = true, bool fadeOut = true, ShakeRandomnessMode randomnessMode = ShakeRandomnessMode.Full)
		{
			Vector3 strength2 = default(Vector3);
			strength2.x = strength;
			strength2.y = strength;
			strength2.z = strength;
			return Shake(getter, setter, duration, strength2, vibrato, randomness, ignoreZAxis, vectorBased: false, fadeOut, randomnessMode);
		}

		[Token(Token = "0x6000037")]
		[Address(RVA = "0xC088FC", Offset = "0xC088FC", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv54 = DG.Tweening.DOTween;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, setter, vibrato, fadeOut, randomnessMode, methodInfo, v57, v58, duration, strength, v0, v2, randomness, v59, v60, v61);\n\tv64 = 1;\n\t*([1A3567E]) = v64;\nL_002B:\n\tgoto L_0048;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v65, setter, vibrato, fadeOut, randomnessMode, methodInfo, v57, v58, duration, strength, v0, v2, randomness, v59, v60, v61);\nL_0048:\n\treturnVal1 = DG.Tweening.DOTween::Shake(getter, setter, duration, strength, vibrato, randomness, 0, 1, fadeOut, randomnessMode);\n\treturn returnVal1;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> Shake(DOGetter<Vector3> getter, DOSetter<Vector3> setter, float duration, Vector3 strength, int vibrato = 10, float randomness = 90f, bool fadeOut = true, ShakeRandomnessMode randomnessMode = ShakeRandomnessMode.Full)
		{
			return Shake(getter, setter, duration, strength, vibrato, randomness, ignoreZAxis: false, vectorBased: true, fadeOut, randomnessMode);
		}

		[Token(Token = "0x6000038")]
		[Address(RVA = "0xC080CC", Offset = "0xC080CC", Length = "0x830")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0042;\n\tv70 = DG.Tweening.Core.DOTweenUtils;\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, setter, vibrato, ignoreZAxis, vectorBased, fadeOut, randomnessMode, methodInfo, duration, strength, v0, v2, randomness, v73, v74, v75);\n\tv87 = DG.Tweening.DOTween;\n\tv88 = \"il2cpp_codegen_initialize_runtime_metadata\"(v87, setter, vibrato, ignoreZAxis, vectorBased, fadeOut, randomnessMode, methodInfo, duration, strength, v0, v2, randomness, v73, v74, v75);\n\tv125 = Il2CppMethodInfo;\n\tv126 = \"il2cpp_codegen_initialize_runtime_metadata\"(v125, setter, vibrato, ignoreZAxis, vectorBased, fadeOut, randomnessMode, methodInfo, duration, strength, v0, v2, randomness, v73, v74, v75);\n\tv140 = Il2CppMethodInfo;\n\tv141 = \"il2cpp_codegen_initialize_runtime_metadata\"(v140, setter, vibrato, ignoreZAxis, vectorBased, fadeOut, randomnessMode, methodInfo, duration, strength, v0, v2, randomness, v73, v74, v75);\n\tv166 = System.Single[];\n\tv167 = \"il2cpp_codegen_initialize_runtime_metadata\"(v166, setter, vibrato, ignoreZAxis, vectorBased, fadeOut, randomnessMode, methodInfo, duration, strength, v0, v2, randomness, v73, v74, v75);\n\tv171 = UnityEngine.Vector3[];\n\tv77 = \"il2cpp_codegen_initialize_runtime_metadata\"(v171, setter, vibrato, ignoreZAxis, vectorBased, fadeOut, randomnessMode, methodInfo, duration, strength, v0, v2, randomness, v73, v74, v75);\n\tv79 = 1;\n\t*([1A3567F]) = v79;\nL_0042:\n\tv85 = vectorBased == 0;\n\tif (v85) goto L_0061;\n\tgoto L_0054;\n\tv128 = System.Math;\n\tv129 = \"il2cpp_codegen_initialize_runtime_metadata\"(v128, setter, vibrato, ignoreZAxis, vectorBased, fadeOut, randomnessMode, methodInfo, duration, strength, v82, v2, randomness, v73, v74, v75);\n\tv132 = 1;\n\t*([1A35759]) = v132;\nL_0054:\n\tgoto L_0058;\n\tv142 = \"il2cpp_codegen_runtime_class_init\"(v135, setter, vibrato, ignoreZAxis, vectorBased, fadeOut, randomnessMode, methodInfo, duration, strength, v82, v2, randomness, v73, v74, v75);\nL_0058:\n\tv145 = strength * strength;\n\tv146 = strength.y * strength.y;\n\tv147 = v145 + v146;\n\tv94 = strength.z * strength.z;\n\tv96 = v94 + v147;\n\tv104 = UnityEngine.Mathf::Sqrt(v96);\nL_0061:\n\tv108 = vibrato * duration;\n\tv123 = v108 != 0x7F800000;\n\tif (v123) goto L_FFFFFFFF;\n\tgoto L_007A;\nL_007A:\n\tv154 = v149 - 2;\n\tv155 = v154 < 0;\n\tv156 = v154 == 0;\n\tv157 = v149 ^ 2;\n\tv158 = v149 ^ v154;\n\tv159 = v157 & v158;\n\tv160 = v159 < 0;\n\tv161 = v155 == v160;\n\tv162 = ~v156;\n\tv163 = v161 & v162;\n\tv164 = ~v163;\n\tif (v164) goto L_FFFFFFFF;\n\tgoto L_008D;\nL_008D:\n\tv693 = v104 / v172;\n\t// 142 NewArr v177 @ X0_v4 (System.Single[]), typeof(System.Single[]), v172 @ X27_v1 (System.Single)\n\tv180 = duration / v172;\nL_0096:\n\tv214 = fadeOut == 0;\n\tif (v214) goto L_00A9;\n\tv215 = v208 + 1;\n\tv217 = v215 / v172;\n\tv211 = v217 * duration;\nL_00A9:\n\tv177[v208 @ X8_v9 (System.Int32)] = v211;\n\tv208 = v208 + 1;\n\tv204 = v204 + v211;\n\tv184 = v172 != v208;\n\tif (v184) goto L_0096;\n\tv526 = duration / v204;\nL_00C5:\n\tv672 = v526 * v177[v528 @ X8_v14 (System.Int32)];\n\tv177[v528 @ X8_v14 (System.Int32)] = v672;\n\tv528 = v528 + 1;\n\tv655 = v172 != v528;\n\tif (v655) goto L_00C5;\n\tv681 = UnityEngine.Random::Range(0f, 360f);\n\t// 221 NewArr v684 @ X0_v11 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), v172 @ X27_v1 (System.Single)\n\tv685 = -randomness;\n\tv690 = ignoreZAxis ^ 1;\n\tv446 = v172 - 1;\n\tv319 = v684 + 0x28;\n\tv465 = v690 | vectorBased;\nL_00ED:\n\tv718 = v322 < v446;\n\tv401 = ~v718;\n\tif (v401) goto L_0129;\n\tgoto L_0105;\n\tv727 = UnityEngine.Quaternion;\n\tv728 = \"il2cpp_codegen_initialize_runtime_metadata\"(v727, v342, vibrato, ignoreZAxis, vectorBased, fadeOut, randomnessMode, methodInfo, v418, v412, v476, v470, v289, v285, v281, v328);\n\tv730 = 1;\n\t*([1A3551A]) = v730;\nL_0105:\n\tv736 = UnityEngine.Quaternion;\n\tv737 = *([v736 @ X8_v39 (Il2CppClass<UnityEngine.Quaternion>)+B8]);\n\tv302 = v737.identityQuaternion;\n\tv297 = *([v737 @ X8_v40 (Il2CppStaticFields<UnityEngine.Quaternion>)+4]);\n\tv292 = *([v737 @ X8_v40 (Il2CppStaticFields<UnityEngine.Quaternion>)+8]);\n\tv307 = *([v737 @ X8_v40 (Il2CppStaticFields<UnityEngine.Quaternion>)+C]);\n\tv353 = randomnessMode != 1;\n\tif (v353) goto L_0144;\n\tv749 = v322 == 0;\n\tif (v749) goto L_0121;\n\tv755 = UnityEngine.Random::Range(0f, randomness);\n\tv759 = v791 + 0xC3340000;\n\tv791 = v759 + v755;\nL_0121:\n\tv764 = v465 & 1;\n\tv765 = v764 == 0;\n\tif (v765) goto L_0176;\n\tgoto L_0154;\nL_0129:\n\tgoto L_013D;\n\tv744 = v453;\n\tv745 = v328;\n\tv746 = \"il2cpp_codegen_initialize_runtime_metadata\"(v744, v342, vibrato, ignoreZAxis, vectorBased, fadeOut, randomnessMode, methodInfo, v418, v412, v476, v470, v289, v285, v281, v328);\n\tv747 = v745;\n\tv748 = 1;\n\t*([1A35519]) = v748;\nL_013D:\n\tv780 = UnityEngine.Vector3;\n\tv781 = *([v780 @ X8_v31 (Il2CppClass<UnityEngine.Vector3>)+B8]);\n\t*([v319 @ X29_v4-8]) = v781.zeroVector;\n\t*([v319 @ X29_v4]) = *([v781 @ X8_v32 (Il2CppStaticFields<UnityEngine.Vector3>)+8]);\n\tgoto L_02FB;\nL_0144:\n\tv750 = v322 == 0;\n\tif (v750) goto L_014E;\n\tv769 = UnityEngine.Random::Range(v685, randomness);\n\tv773 = v791 + 0xC3340000;\n\tv791 = v773 + v769;\nL_014E:\n\tv778 = v465 & 1;\n\tv779 = v778 == 0;\n\tif (v779) goto L_0176;\nL_0154:\n\tv885 = UnityEngine.Random::Range(v879, randomness);\n\tgoto L_0168;\n\tv908 = v453;\n\tv909 = \"il2cpp_codegen_initialize_runtime_metadata\"(v908, v342, vibrato, ignoreZAxis, vectorBased, fadeOut, randomnessMode, methodInfo, v885, v883, v476, v470, v289, v285, v281, v328);\n\tv913 = 1;\n\t*([1A3575B]) = v913;\nL_0168:\n\tv796 = UnityEngine.Quaternion::AngleAxis(v885, v802.upVector);\nL_0176:\n\tgoto L_017B;\n\tv886 = \"il2cpp_codegen_runtime_class_init\"(v808, v342, vibrato, ignoreZAxis, vectorBased, fadeOut, randomnessMode, methodInfo, v795, v793, v804, v468, v289, v285, v281, v328);\nL_017B:\n\tv416 = DG.Tweening.Core.DOTweenUtils::Vector3FromAngle(v791, v822);\n\tv901 = vectorBased == 0;\n\tif (v901) goto L_01C4;\n\t// 397 MakeStruct v272 @ AGGC0C4CC_0_v5 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v302 @ V14_v7 (UnityEngine.Quaternion), v297 @ V15_v7 (System.Single), v292 @ V13_v7 (System.Single), v307 @ V8_v8 (System.Single)\n\tv992 = UnityEngine.Quaternion::op_Multiply(v272, v416);\n\tgoto L_01A3;\n\tv945 = System.Math;\n\tv946 = v925;\n\tv947 = v935;\n\tv948 = \"il2cpp_codegen_initialize_runtime_metadata\"(v945, v342, vibrato, ignoreZAxis, vectorBased, fadeOut, randomnessMode, methodInfo, v925, v932, v933, v935, v288, v284, v280, v328);\n\tv959 = v947;\n\tv954 = v946;\n\tv952 = v316;\n\tv957 = 1;\n\t*([1A3575A]) = v957;\nL_01A3:\n\tv960 = v992 * v992;\n\tv961 = v992.y * v992.y;\n\tv962 = v992.z * v992.z;\n\tv963 = v960 + v961;\n\tv964 = v962 + v963;\n\tv309 = v630 * v630;\n\tv977 = v964 <= v309;\n\tif (v977) goto L_0218;\n\tv981 = UnityEngine.Mathf::Sqrt(v964);\n\tv997 = System.Math;\n\tv1000 = *([v997 @ X0_v62 (Il2CppClass<System.Math>)+E0]) == 0;\n\tif (v1000) goto L_0207;\n\tv1083 = v992 / v981;\n\tv994 = v630 * v1083;\n\tgoto L_0218;\nL_01C4:\n\tv927 = ignoreZAxis == 0;\n\tif (v927) goto L_01DB;\n\tv978 = v322 < v684.Length;\n\tv521 = ~v978;\n\tv483 = ~v521;\n\tif (v483) goto L_01F1;\n\tgoto L_0334;\nL_01DB:\n\t// 475 MakeStruct v247 @ AGGC0C58C_0_v6 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v302 @ V14_v7 (UnityEngine.Quaternion), v297 @ V15_v7 (System.Single), v292 @ V13_v7 (System.Single), v307 @ V8_v8 (System.Single)\n\tv417 = UnityEngine.Quaternion::op_Multiply(v247, v416);\nL_01F1:\n\tv860 = v822 - v693;\n\tv844 = fadeOut == 0;\n\t*([v319 @ X29_v4-8]) = v818;\n\t*([v319 @ X29_v4-4]) = v817;\n\t*([v319 @ X29_v4]) = v816;\n\tv827 = ~v844;\n\tv829 = ~v827;\n\tif (v829) goto L_0201;\n\tgoto L_0201;\nL_0201:\n\tgoto L_02FB;\nL_0207:\n\t;\n\tv1111 = v992 / v981;\n\tv993 = v630 * v1111;\n\tv999 = *([1A3575A]) == 0;\n\tif (v999) goto L_0215;\n\tgoto L_FFFFFFFF;\nL_0215:\n\t*([1A3575A]) = 1;\nL_0218:\n\tv1007 = v992 * v992;\n\tv1008 = v961 + v1007;\n\tv1009 = v962 + v1008;\n\tv294 = v634 * v634;\n\tv1021 = v1009 <= v294;\n\tif (v1021) goto L_0248;\n\tv1036 = UnityEngine.Mathf::Sqrt(v1009);\n\tv1051 = System.Math;\n\tv1055 = *([v1051 @ X0_v57 (Il2CppClass<System.Math>)+E0]) == 0;\n\tif (v1055) goto L_0239;\n\tv1048 = v1061 / v1036;\n\tv1061 = v634 * v1048;\n\tgoto L_0248;\nL_0239:\n\t;\n\tv1047 = v1061 / v1036;\n\tv1061 = v634 * v1047;\n\tv1054 = *([1A3575A]) == 0;\n\tif (v1054) goto L_0247;\n\tgoto L_0248;\nL_0247:\n\t*([1A3575A]) = 1;\nL_02\n// ... truncated")]
		private static TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> Shake(DOGetter<Vector3> getter, DOSetter<Vector3> setter, float duration, Vector3 strength, int vibrato, float randomness, bool ignoreZAxis, bool vectorBased, bool fadeOut, ShakeRandomnessMode randomnessMode)
		{
			//IL_0825: Unknown result type (might be due to invalid IL or missing references)
			//IL_082a: Expected O, but got Unknown
			//IL_0837: Expected O, but got F4
			//IL_0240: Expected O, but got I
			//IL_0306: Expected I, but got O
			//IL_030f: Expected I, but got O
			//IL_0326: Expected O, but got I
			//IL_09c9: Expected O, but got I
			//IL_0909: Expected I, but got O
			//IL_0912: Expected I, but got O
			//IL_092b: Expected F4, but got I
			//IL_093b: Expected F4, but got I
			//IL_094b: Expected F4, but got I
			//IL_0b96: Expected O, but got F4
			//IL_042f: Expected I, but got O
			//IL_05ff: Expected I, but got O
			//IL_0485: Expected O, but got F4
			//IL_0bc7: Expected O, but got F4
			//IL_0c7e: Expected I, but got O
			//IL_0c87: Expected I, but got O
			//IL_0c97: Expected F4, but got I
			//IL_0704: Expected O, but got F4
			//IL_0d23: Expected O, but got F4
			bool flag = !vectorBased;
			Vector3 vector = default(Vector3);
			float num = vector.x;
			if (!flag)
			{
				float num2 = vector.x * vector.x;
				float num3 = strength.y * strength.y;
				float num4 = num2 + num3;
				float num5 = strength.z * strength.z;
				float f = num5 + num4;
				num = Mathf.Sqrt(f);
			}
			float num6 = (float)vibrato * duration;
			float num7 = ((num6 != float.PositiveInfinity) ? num6 : -0f);
			float num8 = num7 - 3E-45f;
			bool flag2 = num8 < 0f;
			bool flag3 = num8 == 0f;
			object obj = num7 ^ 2;
			object obj2 = num7 ^ num8;
			int num9 = (int)((nint)obj & (nint)obj2);
			bool flag4 = num9 < 0;
			bool flag5 = flag2 == flag4;
			bool flag6 = !flag3;
			float num10 = ((!(flag5 && flag6)) ? 3E-45f : num7);
			float num11 = num / num10;
			float[] array = new float[num10];
			float num12 = duration / num10;
			float num13 = 0f;
			int num14 = 0;
			do
			{
				bool flag7 = !fadeOut;
				float num15 = num12;
				if (!flag7)
				{
					int num16 = num14 + 1;
					float num17 = (float)num16 / num10;
					num15 = num17 * duration;
				}
				array[num14] = num15;
				num14++;
				num13 += num15;
			}
			while (num10 != (float)num14);
			float num18 = duration / num13;
			int num19 = 0;
			do
			{
				float num20 = num18 * array[num19];
				array[num19] = num20;
				num19++;
			}
			while (num10 != (float)num19);
			float num21 = UnityEngine.Random.Range(0f, 360f);
			Vector3[] array2 = new Vector3[num10];
			float num22 = 0f - randomness;
			int num23 = (ignoreZAxis ? 1 : 0) ^ 1;
			float num24 = num10 - float.Epsilon;
			object obj3 = (nint)array2 + 40;
			int num25 = num23 | (vectorBased ? 1 : 0);
			int num26 = 0;
			float num27 = num;
			float num28 = num21;
			Vector3 vector2 = strength;
			float num29 = strength.z;
			float num30 = strength.y;
			Quaternion quaternion3 = default(Quaternion);
			object obj4 = default(object);
			Quaternion quaternion4 = default(Quaternion);
			while (true)
			{
				if (!((float)num26 < num24))
				{
					nint num31 = (nint)typeof(Vector3);
					nint num32 = (nint)Vector3.zero;
					_ = Vector3.zero;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v781 @ X8_v32 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
					obj3 = 0;
					goto IL_09ac;
				}
				nint num33 = (nint)typeof(Quaternion);
				nint num34 = (nint)Quaternion.identity;
				Quaternion quaternion = Quaternion.identity;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v737 @ X8_v40 (Il2CppStaticFields<UnityEngine.Quaternion>)+4]");
				float y = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v737 @ X8_v40 (Il2CppStaticFields<UnityEngine.Quaternion>)+8]");
				float z = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v737 @ X8_v40 (Il2CppStaticFields<UnityEngine.Quaternion>)+C]");
				float w = 0f;
				float minInclusive;
				if (randomnessMode == ShakeRandomnessMode.Harmonic)
				{
					if (num26 != 0)
					{
						float num35 = UnityEngine.Random.Range(0f, randomness);
						float num36 = num28 + -180f;
						num28 = num36 + num35;
					}
					if ((num25 & 1) == 0)
					{
						goto IL_038a;
					}
					minInclusive = 0f;
				}
				else
				{
					if (num26 != 0)
					{
						float num37 = UnityEngine.Random.Range(num22, randomness);
						float num38 = num28 + -180f;
						num28 = num38 + num37;
					}
					if ((num25 & 1) == 0)
					{
						goto IL_038a;
					}
					minInclusive = num22;
				}
				float angle = UnityEngine.Random.Range(minInclusive, randomness);
				Quaternion quaternion2 = Quaternion.AngleAxis(angle, Vector3.upVector);
				z = quaternion2.z;
				y = quaternion2.y;
				quaternion = quaternion2;
				w = quaternion2.w;
				goto IL_038a;
				IL_09ac:
				num26++;
				obj3 = (nint)obj3 + 12;
				if (num10 == (float)num26)
				{
					TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t = ToArray(getter, setter, array2, array);
					TweenerCore<Vector3, object, Vector3ArrayOptions> t2 = ((TweenerCore<Vector3, object, Vector3ArrayOptions>)(object)t).NoFrom();
					return ((TweenerCore<Vector3, Vector3[], Vector3ArrayOptions>)(object)t2).SetSpecialStartupMode(SpecialStartupMode.SetShake);
				}
				continue;
				IL_038a:
				Vector3 vector3 = DOTweenUtils.Vector3FromAngle(num28, num27);
				if (vectorBased)
				{
					quaternion3.x = quaternion.x;
					quaternion3.y = y;
					quaternion3.z = z;
					quaternion3.w = w;
					Vector3 vector4 = quaternion3 * vector3;
					float num39 = vector4.y;
					float num40 = vector4.x * vector4.x;
					float num41 = vector4.y * vector4.y;
					float num42 = vector4.z * vector4.z;
					float num43 = num40 + num41;
					float num44 = num42 + num43;
					float num45 = vector2.x * vector2.x;
					if (num44 > num45)
					{
						float num46 = Mathf.Sqrt(num44);
						nint num47 = (nint)typeof(Math);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v997 @ X0_v62 (Il2CppClass<System.Math>)+E0]");
						if ((nint)0 != 0)
						{
							float num48 = vector4.x / num46;
							float num49 = vector2.x * num48;
							vector4 = (Vector3)num49;
						}
						else
						{
							float num50 = vector4.x / num46;
							float num51 = vector2.x * num50;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1A3575A]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							vector4 = (Vector3)num51;
						}
					}
					float num52 = vector4.x * vector4.x;
					float num53 = num41 + num52;
					float num54 = num42 + num53;
					float num55 = num30 * num30;
					if (num54 > num55)
					{
						float num56 = Mathf.Sqrt(num54);
						nint num57 = (nint)typeof(Math);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1051 @ X0_v57 (Il2CppClass<System.Math>)+E0]");
						if ((nint)0 != 0)
						{
							float num58 = num39 / num56;
							num39 = num30 * num58;
						}
						else
						{
							float num59 = num39 / num56;
							num39 = num30 * num59;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1A3575A]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
						}
					}
					float num60 = num39 * num39;
					float num61 = num52 + num60;
					float num62 = num42 + num61;
					float num63 = num29 * num29;
					bool flag8 = !(num62 > num63);
					float num64 = vector4.z;
					if (!flag8)
					{
						float num65 = Mathf.Sqrt(num62);
						float num66 = vector4.z / num65;
						num64 = num29 * num66;
					}
					float num67 = num64 * num64;
					float f2 = num61 + num67;
					float num68 = Mathf.Sqrt(f2);
					float num69;
					float num70;
					if (num68 > 1E-05f)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
						num69 = num64 / num68;
						num70 = vector4.x / 1E-05f;
					}
					else
					{
						nint num71 = (nint)typeof(Vector3);
						nint num72 = (nint)Vector3.zero;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1173 @ X8_v74 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
						num69 = 0f;
						num70 = Vector3.zero.x;
					}
					float num73 = num70 * (float)obj4;
					float num74 = num27 * num69;
					obj3 = num74;
					float num75 = num27 - num11;
					if (fadeOut)
					{
						num27 = num75;
					}
					float num76 = num55 + num45;
					float num77 = num63 + num76;
					float num78 = num27 * num27;
					if (num77 > num78)
					{
						float num79 = Mathf.Sqrt(num77);
						float num80 = vector2.x / num79;
						float num81 = num30 / num79;
						float num82 = num29 / num79;
						float num83 = num80 * num27;
						float num84 = num81 * num27;
						float num85 = num82 * num27;
						vector2 = (Vector3)num83;
						num29 = num85;
						num30 = num84;
					}
				}
				else
				{
					float z2;
					if (ignoreZAxis)
					{
						bool flag9 = num26 < array2.Length;
						bool flag10 = !flag9;
						bool flag11 = !flag10;
						z2 = vector3.z;
						float y2 = vector3.y;
						Vector3 vector5 = vector3;
						if (!flag11)
						{
							break;
						}
					}
					else
					{
						quaternion4.x = quaternion.x;
						quaternion4.y = y;
						quaternion4.z = z;
						quaternion4.w = w;
						Vector3 vector6 = quaternion4 * vector3;
						z2 = vector6.z;
						float y2 = vector6.y;
						Vector3 vector5 = vector6;
					}
					float num86 = num27 - num11;
					bool flag12 = !fadeOut;
					obj3 = z2;
					if (!flag12)
					{
						num27 = num86;
					}
				}
				goto IL_09ac;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			return (TweenerCore<Vector3, Vector3[], Vector3ArrayOptions>)(object)new NullReferenceException();
		}

		[Token(Token = "0x6000039")]
		[Address(RVA = "0xC07DE0", Offset = "0xC07DE0", Length = "0x224")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0037;\n\tv32 = Il2CppMethodInfo;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, setter, endValues, durations, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv52 = DG.Tweening.DOTween;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, setter, endValues, durations, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv184 = Il2CppMethodInfo;\n\tv185 = \"il2cpp_codegen_initialize_runtime_metadata\"(v184, setter, endValues, durations, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv198 = System.Single[];\n\tv199 = \"il2cpp_codegen_initialize_runtime_metadata\"(v198, setter, endValues, durations, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv279 = UnityEngine.Vector3[];\n\tv280 = \"il2cpp_codegen_initialize_runtime_metadata\"(v279, setter, endValues, durations, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv287 = \"To Vector3 array tween: endValues and durations arrays must have the same length\";\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v287, setter, endValues, durations, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv49 = 1;\n\t*([1A35680]) = v49;\nL_0037:\n\tv196 = durations.Length != endValues.Length;\n\tif (v196) goto L_00E6;\n\t// 61 NewArr v204 @ X0_v8 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), durations.Length\n\t// 68 NewArr v170 @ X0_v10 (System.Single[]), typeof(System.Single[]), durations.Length\n\tv298 = durations.Length < 1;\n\tif (v298) goto L_00CE;\n\tv178 = durations.Length & 0xFFFFFFFF;\n\tv101 = v178 << 1;\n\tv302 = v178 + v101;\n\tv97 = v302 << 2;\nL_0073:\n\tv399 = endValues + v94;\n\tv400 = v204 + v94;\n\t*([v400 @ X14_v9+20]) = *([v399 @ X14_v8+20]);\n\t*([v400 @ X14_v9+28]) = *([v399 @ X14_v8+28]);\n\tv94 = v94 + 0xC;\n\tv170[v89 @ X10_v5 (System.Int32)] = durations[v89 @ X10_v5 (System.Int32)];\n\tv89 = v89 + 1;\n\tv342 = v97 != v94;\n\tif (v342) goto L_0073;\n\tv316 = durations.Length < 1;\n\tif (v316) goto L_00CE;\nL_00BB:\n\tv312 = v370 + 1;\n\tv107 = v371 + v170[v370 @ X9_v9 (System.Int32)];\n\tv315 = v178 != v312;\n\tif (v315) goto L_00BB;\nL_00CE:\n\tgoto L_00D8;\n\tv361 = \"il2cpp_codegen_runtime_class_init\"(v337, v111, endValues, durations, methodInfo, v35, v36, v37, v305, v65, v40, v41, v42, v43, v44, v45);\nL_00D8:\n\tv367 = DG.Tweening.DOTween::ApplyTo(getter, setter, v204, v107, 0);\n\tv171 = DG.Tweening.Core.Extensions::NoFrom(v367);\n\tv171.plugOptions.durations = v170;\n\tgoto L_00F2;\nL_00E6:\n\tDG.Tweening.Core.Debugger::LogError(\"To Vector3 array tween: endValues and durations arrays must have the same length\", 0);\nL_00F2:\n\treturn returnVal2;\n\tv169 = new System.IndexOutOfRangeException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 195 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> ToArray(DOGetter<Vector3> getter, DOSetter<Vector3> setter, Vector3[] endValues, float[] durations)
		{
			//IL_0087: Expected I4, but got I8
			//IL_00d5: Expected O, but got I
			//IL_00e3: Expected O, but got I
			if (durations.Length == endValues.Length)
			{
				Vector3[] array = new Vector3[durations.Length];
				float[] array2 = new float[durations.Length];
				bool flag = durations.Length < 1;
				float num = 0f;
				if (!flag)
				{
					int num2 = (int)(durations.Length & 0xFFFFFFFFL);
					int num3 = num2 << 1;
					int num4 = num2 + num3;
					int num5 = num4 << 2;
					int num6 = 0;
					int num7 = 0;
					do
					{
						object obj = (nint)endValues + num7;
						object obj2 = (nint)array + num7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ X14_v8+20]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ X14_v8+28]");
						_ = 0;
						num7 += 12;
						array2[num6] = durations[num6];
						num6++;
					}
					while (num5 != num7);
					bool flag2 = durations.Length < 1;
					num = 0f;
					if (!flag2)
					{
						int num8 = 0;
						float num9 = 0f;
						bool flag3;
						do
						{
							int num10 = num8 + 1;
							num = num9 + array2[num8];
							flag3 = num2 != num10;
							num8 = num10;
							num9 = num;
						}
						while (flag3);
					}
				}
				TweenerCore<Vector3, object, Vector3ArrayOptions> t = ApplyTo<Vector3, object, Vector3ArrayOptions>(getter, setter, array, num);
				TweenerCore<Vector3, object, Vector3ArrayOptions> tweenerCore = t.NoFrom();
				tweenerCore.plugOptions.durations = array2;
				return (TweenerCore<Vector3, Vector3[], Vector3ArrayOptions>)(object)tweenerCore;
			}
			Debugger.LogError("To Vector3 array tween: endValues and durations arrays must have the same length");
			return null;
		}

		[Token(Token = "0x600003A")]
		[Address(RVA = "0xC089C8", Offset = "0xC089C8", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, setter, endValue, methodInfo, v33, v34, v35, v36, duration, v37, v38, v39, v40, v41, v42, v43);\n\tv59 = DG.Tweening.DOTween;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, setter, endValue, methodInfo, v33, v34, v35, v36, duration, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A35681]) = v47;\nL_001C:\n\tv48 = endValue.ca;\n\tgoto L_0032;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v50, setter, endValue, methodInfo, v33, v34, v35, v36, v49, v48, v38, v39, v40, v41, v42, v43);\nL_0032:\n\treturnVal1 = DG.Tweening.DOTween::ApplyTo(getter, setter, &v48 @ V1_v1 (UnityEngine.Color), duration, 0);\n\treturn returnVal1;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe static TweenerCore<Color2, Color2, ColorOptions> To(DOGetter<Color2> getter, DOSetter<Color2> setter, Color2 endValue, float duration)
		{
			//IL_001b: Expected O, but got Ref
			Color ca = endValue.ca;
			return ApplyTo<Color2, Color2, ColorOptions>(getter, setter, (Color2)(&ca), duration);
		}

		[Token(Token = "0x600003B")]
		[Address(RVA = "0xC08A7C", Offset = "0xC08A7C", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = DG.Tweening.DOTween;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv43 = DG.Tweening.Core.TweenManager;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A35682]) = v35;\nL_001A:\n\tgoto L_001C;\n\tv44 = \"il2cpp_codegen_runtime_class_init\"(v36, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001C:\n\tDG.Tweening.DOTween::InitCheck();\n\tgoto L_0024;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v46, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0024:\n\tv53 = DG.Tweening.Core.TweenManager::GetSequence();\n\tDG.Tweening.Sequence::Setup(v53);\n\treturn v53;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sequence Sequence()
		{
			InitCheck();
			Sequence sequence = TweenManager.GetSequence();
			DG.Tweening.Sequence.Setup(sequence);
			return sequence;
		}

		[Token(Token = "0x600003C")]
		[Address(RVA = "0xC08BD8", Offset = "0xC08BD8", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = DG.Tweening.DOTween;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv46 = Il2CppMethodInfo;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A35683]) = v38;\nL_001C:\n\tgoto L_001E;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001E:\n\tv49 = DG.Tweening.DOTween::Sequence();\n\treturnVal1 = DG.Tweening.TweenSettingsExtensions::SetTarget(v49, target);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sequence Sequence(object target)
		{
			Sequence t = Sequence();
			return t.SetTarget(target);
		}

		[Token(Token = "0x600003D")]
		[Address(RVA = "0xC08C48", Offset = "0xC08C48", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = DG.Tweening.Core.TweenManager;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35684]) = v37;\nL_0017:\n\tgoto L_0027;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0027:\n\treturnVal1 = DG.Tweening.Core.TweenManager::FilteredOperation(0, 0, 0, 0, withCallbacks, 0, 0);\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int CompleteAll(bool withCallbacks = false)
		{
			//IL_0032: Expected F4, but got I4
			return TweenManager.FilteredOperation(default(OperationType), default(FilterType), null, optionalBool: false, withCallbacks ? 1 : 0);
		}

		[Token(Token = "0x600003E")]
		[Address(RVA = "0xC08CBC", Offset = "0xC08CBC", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = DG.Tweening.Core.TweenManager;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, withCallbacks, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A35685]) = v36;\nL_0012:\n\tv37 = targetOrId == 0;\n\tif (v37) goto L_0032;\n\tgoto L_002A;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v40, withCallbacks, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_002A:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(0, 1, targetOrId, 0, withCallbacks, 0, 0);\n\treturn returnVal2;\nL_0032:\n\treturn 0;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Complete(object targetOrId, bool withCallbacks = false)
		{
			//IL_0031: Expected F4, but got I4
			if (targetOrId != null)
			{
				return TweenManager.FilteredOperation(default(OperationType), FilterType.TargetOrId, targetOrId, optionalBool: false, withCallbacks ? 1 : 0);
			}
			return 0;
		}

		[Token(Token = "0x600003F")]
		[Address(RVA = "0xC08D48", Offset = "0xC08D48", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35686]) = v34;\nL_0015:\n\tgoto L_0023;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0023:\n\treturnVal1 = DG.Tweening.Core.TweenManager::FilteredOperation(0, 0, 0, 1, 0f, 0, 0);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int CompleteAndReturnKilledTot()
		{
			return TweenManager.FilteredOperation(default(OperationType), default(FilterType), null, optionalBool: true, 0f);
		}

		[Token(Token = "0x6000040")]
		[Address(RVA = "0xC08DB4", Offset = "0xC08DB4", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A35687]) = v33;\nL_0010:\n\tv34 = targetOrId == 0;\n\tif (v34) goto L_002D;\n\tgoto L_0026;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v37, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0026:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(0, 1, targetOrId, 1, 0f, 0, 0);\n\treturn returnVal2;\nL_002D:\n\treturn 0;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int CompleteAndReturnKilledTot(object targetOrId)
		{
			if (targetOrId != null)
			{
				return TweenManager.FilteredOperation(default(OperationType), FilterType.TargetOrId, targetOrId, optionalBool: true, 0f);
			}
			return 0;
		}

		[Token(Token = "0x6000041")]
		[Address(RVA = "0xC08E38", Offset = "0xC08E38", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = DG.Tweening.Core.TweenManager;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, id, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A35688]) = v36;\nL_0012:\n\tv37 = target == 0;\n\tif (v37) goto L_0033;\n\tv38 = id == 0;\n\tif (v38) goto L_0033;\n\tgoto L_002B;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v47, id, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_002B:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(0, 2, id, 1, 0f, target, 0);\n\treturn returnVal2;\nL_0033:\n\treturn 0;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int CompleteAndReturnKilledTot(object target, object id)
		{
			if (target != null && id != null)
			{
				return TweenManager.FilteredOperation(default(OperationType), FilterType.TargetAndId, id, optionalBool: true, 0f, target);
			}
			return 0;
		}

		[Token(Token = "0x6000042")]
		[Address(RVA = "0xC08EC4", Offset = "0xC08EC4", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = DG.Tweening.Core.TweenManager;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35689]) = v37;\nL_0017:\n\tgoto L_0026;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0026:\n\treturnVal1 = DG.Tweening.Core.TweenManager::FilteredOperation(0, 3, 0, 1, 0f, 0, excludeTargetsOrIds);\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int CompleteAndReturnKilledTotExceptFor(params object[] excludeTargetsOrIds)
		{
			return TweenManager.FilteredOperation(default(OperationType), FilterType.AllExceptTargetsOrIds, null, optionalBool: true, 0f, null, excludeTargetsOrIds);
		}

		[Token(Token = "0x6000043")]
		[Address(RVA = "0xC08F34", Offset = "0xC08F34", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A3568A]) = v34;\nL_0015:\n\tgoto L_0023;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0023:\n\treturnVal1 = DG.Tweening.Core.TweenManager::FilteredOperation(2, 0, 0, 0, 0f, 0, 0);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int FlipAll()
		{
			return TweenManager.FilteredOperation(OperationType.Flip, default(FilterType), null, optionalBool: false, 0f);
		}

		[Token(Token = "0x6000044")]
		[Address(RVA = "0xC08FA0", Offset = "0xC08FA0", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A3568B]) = v33;\nL_0010:\n\tv34 = targetOrId == 0;\n\tif (v34) goto L_002D;\n\tgoto L_0026;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v37, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0026:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(2, 1, targetOrId, 0, 0f, 0, 0);\n\treturn returnVal2;\nL_002D:\n\treturn 0;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Flip(object targetOrId)
		{
			if (targetOrId != null)
			{
				return TweenManager.FilteredOperation(OperationType.Flip, FilterType.TargetOrId, targetOrId, optionalBool: false, 0f);
			}
			return 0;
		}

		[Token(Token = "0x6000045")]
		[Address(RVA = "0xC09024", Offset = "0xC09024", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = DG.Tweening.Core.TweenManager;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, to, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A3568C]) = v40;\nL_0019:\n\tgoto L_0029;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v25, v26, v27, v28, v29, v30, to, v31, v32, v33, v34, v35, v36, v37);\nL_0029:\n\treturnVal1 = DG.Tweening.Core.TweenManager::FilteredOperation(3, 0, 0, andPlay, to, 0, 0);\n\treturn returnVal1;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int GotoAll(float to, bool andPlay = false)
		{
			return TweenManager.FilteredOperation(OperationType.Goto, default(FilterType), null, andPlay, to);
		}

		[Token(Token = "0x6000046")]
		[Address(RVA = "0xC090A0", Offset = "0xC090A0", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv22 = DG.Tweening.Core.TweenManager;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, andPlay, methodInfo, v25, v26, v27, v28, v29, to, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A3568D]) = v39;\nL_0014:\n\tv40 = targetOrId == 0;\n\tif (v40) goto L_0035;\n\tgoto L_002C;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v43, andPlay, methodInfo, v25, v26, v27, v28, v29, to, v30, v31, v32, v33, v34, v35, v36);\nL_002C:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(3, 1, targetOrId, andPlay, to, 0, 0);\n\treturn returnVal2;\nL_0035:\n\treturn 0;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Goto(object targetOrId, float to, bool andPlay = false)
		{
			if (targetOrId != null)
			{
				return TweenManager.FilteredOperation(OperationType.Goto, FilterType.TargetOrId, targetOrId, andPlay, to);
			}
			return 0;
		}

		[Token(Token = "0x6000047")]
		[Address(RVA = "0xC09138", Offset = "0xC09138", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = DG.Tweening.DOTween;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv40 = DG.Tweening.Core.TweenManager;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A3568E]) = v34;\nL_0016:\n\tv38 = complete == 0;\n\tif (v38) goto L_FFFFFFFF;\n\tgoto L_0020;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0020:\n\tv50 = DG.Tweening.DOTween::CompleteAndReturnKilledTot();\n\tgoto L_0028;\nL_0028:\n\tgoto L_002B;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v56, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_002B:\n\tv63 = DG.Tweening.Core.TweenManager::DespawnAll();\n\treturnVal1 = v63 + v53;\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000048")]
		[Address(RVA = "0xC091CC", Offset = "0xC091CC", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = DG.Tweening.DOTween;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, idsOrTargetsToExclude, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv42 = DG.Tweening.Core.TweenManager;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, idsOrTargetsToExclude, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A3568F]) = v37;\nL_0017:\n\tv40 = idsOrTargetsToExclude == 0;\n\tif (v40) goto L_0029;\n\tv44 = complete == 0;\n\tif (v44) goto L_FFFFFFFF;\n\tgoto L_0025;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v49, idsOrTargetsToExclude, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0025:\n\tv64 = DG.Tweening.DOTween::CompleteAndReturnKilledTotExceptFor(idsOrTargetsToExclude);\n\tgoto L_003B;\nL_0029:\n\tv46 = complete == 0;\n\tif (v46) goto L_FFFFFFFF;\n\tgoto L_0033;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v56, idsOrTargetsToExclude, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0033:\n\tv76 = DG.Tweening.DOTween::CompleteAndReturnKilledTot();\n\tgoto L_004D;\nL_003B:\n\tgoto L_0045;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v70, idsOrTargetsToExclude, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0045:\n\tv96 = DG.Tweening.Core.TweenManager::FilteredOperation(1, 3, 0, 0, 0f, 0, idsOrTargetsToExclude);\n\treturnVal1 = v96 + v67;\n\tgoto L_0057;\nL_004D:\n\tgoto L_0050;\n\tv97 = \"il2cpp_codegen_runtime_class_init\"(v82, idsOrTargetsToExclude, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0050:\n\tv100 = DG.Tweening.Core.TweenManager::DespawnAll();\n\treturnVal1 = v100 + v79;\nL_0057:\n\treturn returnVal1;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000049")]
		[Address(RVA = "0xC092D4", Offset = "0xC092D4", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = DG.Tweening.DOTween;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, complete, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv40 = DG.Tweening.Core.TweenManager;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, complete, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A35690]) = v37;\nL_0015:\n\tv38 = targetOrId == 0;\n\tif (v38) goto L_FFFFFFFF;\n\tv44 = complete == 0;\n\tif (v44) goto L_FFFFFFFF;\n\tgoto L_0025;\n\tv80 = \"il2cpp_codegen_runtime_class_init\"(v48, complete, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0025:\n\tv83 = DG.Tweening.DOTween::CompleteAndReturnKilledTot(targetOrId);\n\tgoto L_002F;\n\tgoto L_0040;\nL_002F:\n\tgoto L_0039;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v88, complete, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0039:\n\tv93 = DG.Tweening.Core.TweenManager::FilteredOperation(1, 1, targetOrId, 0, 0f, 0, 0);\n\treturnVal1 = v93 + v72;\nL_0040:\n\treturn returnVal1;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x600004A")]
		[Address(RVA = "0xC09398", Offset = "0xC09398", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = DG.Tweening.DOTween;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, id, complete, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv44 = DG.Tweening.Core.TweenManager;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, id, complete, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A35691]) = v40;\nL_0018:\n\tv42 = target == 0;\n\tif (v42) goto L_0045;\n\tv45 = id == 0;\n\tif (v45) goto L_0045;\n\tv74 = complete == 0;\n\tif (v74) goto L_FFFFFFFF;\n\tgoto L_0029;\n\tv82 = \"il2cpp_codegen_runtime_class_init\"(v77, id, complete, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0029:\n\tv86 = DG.Tweening.DOTween::CompleteAndReturnKilledTot(target, id);\n\tgoto L_0033;\nL_0033:\n\tgoto L_003D;\n\tv96 = \"il2cpp_codegen_runtime_class_init\"(v94, v87, complete, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_003D:\n\tv99 = DG.Tweening.Core.TweenManager::FilteredOperation(1, 2, id, 0, 0f, target, 0);\n\treturnVal1 = v99 + v65;\nL_0045:\n\treturn returnVal1;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Kill(object target, object id, bool complete = false)
		{
			bool flag = target == null;
			int result = 0;
			if (!flag)
			{
				bool flag2 = id == null;
				result = 0;
				if (!flag2)
				{
					int num2;
					if (complete)
					{
						int num = CompleteAndReturnKilledTot(target, id);
						num2 = num;
					}
					else
					{
						num2 = 0;
					}
					int num3 = TweenManager.FilteredOperation(OperationType.Despawn, FilterType.TargetAndId, id, optionalBool: false, 0f, target);
					result = num3 + num2;
				}
			}
			return result;
		}

		[Token(Token = "0x600004B")]
		[Address(RVA = "0xC0946C", Offset = "0xC0946C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35692]) = v34;\nL_0015:\n\tgoto L_0023;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0023:\n\treturnVal1 = DG.Tweening.Core.TweenManager::FilteredOperation(4, 0, 0, 0, 0f, 0, 0);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int PauseAll()
		{
			return TweenManager.FilteredOperation(OperationType.Pause, default(FilterType), null, optionalBool: false, 0f);
		}

		[Token(Token = "0x600004C")]
		[Address(RVA = "0xC094D8", Offset = "0xC094D8", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A35693]) = v33;\nL_0010:\n\tv34 = targetOrId == 0;\n\tif (v34) goto L_002D;\n\tgoto L_0026;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v37, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0026:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(4, 1, targetOrId, 0, 0f, 0, 0);\n\treturn returnVal2;\nL_002D:\n\treturn 0;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Pause(object targetOrId)
		{
			if (targetOrId != null)
			{
				return TweenManager.FilteredOperation(OperationType.Pause, FilterType.TargetOrId, targetOrId, optionalBool: false, 0f);
			}
			return 0;
		}

		[Token(Token = "0x600004D")]
		[Address(RVA = "0xC0955C", Offset = "0xC0955C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35694]) = v34;\nL_0015:\n\tgoto L_0023;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0023:\n\treturnVal1 = DG.Tweening.Core.TweenManager::FilteredOperation(5, 0, 0, 0, 0f, 0, 0);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int PlayAll()
		{
			return TweenManager.FilteredOperation(OperationType.Play, default(FilterType), null, optionalBool: false, 0f);
		}

		[Token(Token = "0x600004E")]
		[Address(RVA = "0xC095C8", Offset = "0xC095C8", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A35695]) = v33;\nL_0010:\n\tv34 = targetOrId == 0;\n\tif (v34) goto L_002D;\n\tgoto L_0026;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v37, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0026:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(5, 1, targetOrId, 0, 0f, 0, 0);\n\treturn returnVal2;\nL_002D:\n\treturn 0;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Play(object targetOrId)
		{
			if (targetOrId != null)
			{
				return TweenManager.FilteredOperation(OperationType.Play, FilterType.TargetOrId, targetOrId, optionalBool: false, 0f);
			}
			return 0;
		}

		[Token(Token = "0x600004F")]
		[Address(RVA = "0xC0964C", Offset = "0xC0964C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = DG.Tweening.Core.TweenManager;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, id, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A35696]) = v36;\nL_0012:\n\tv37 = target == 0;\n\tif (v37) goto L_0033;\n\tv38 = id == 0;\n\tif (v38) goto L_0033;\n\tgoto L_002B;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v47, id, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_002B:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(5, 2, id, 0, 0f, target, 0);\n\treturn returnVal2;\nL_0033:\n\treturn 0;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Play(object target, object id)
		{
			if (target != null && id != null)
			{
				return TweenManager.FilteredOperation(OperationType.Play, FilterType.TargetAndId, id, optionalBool: false, 0f, target);
			}
			return 0;
		}

		[Token(Token = "0x6000050")]
		[Address(RVA = "0xC096D8", Offset = "0xC096D8", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35697]) = v34;\nL_0015:\n\tgoto L_0023;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0023:\n\treturnVal1 = DG.Tweening.Core.TweenManager::FilteredOperation(7, 0, 0, 0, 0f, 0, 0);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int PlayBackwardsAll()
		{
			return TweenManager.FilteredOperation(OperationType.PlayBackwards, default(FilterType), null, optionalBool: false, 0f);
		}

		[Token(Token = "0x6000051")]
		[Address(RVA = "0xC09744", Offset = "0xC09744", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A35698]) = v33;\nL_0010:\n\tv34 = targetOrId == 0;\n\tif (v34) goto L_002D;\n\tgoto L_0026;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v37, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0026:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(7, 1, targetOrId, 0, 0f, 0, 0);\n\treturn returnVal2;\nL_002D:\n\treturn 0;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int PlayBackwards(object targetOrId)
		{
			if (targetOrId != null)
			{
				return TweenManager.FilteredOperation(OperationType.PlayBackwards, FilterType.TargetOrId, targetOrId, optionalBool: false, 0f);
			}
			return 0;
		}

		[Token(Token = "0x6000052")]
		[Address(RVA = "0xC097C8", Offset = "0xC097C8", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = DG.Tweening.Core.TweenManager;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, id, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A35699]) = v36;\nL_0012:\n\tv37 = target == 0;\n\tif (v37) goto L_0033;\n\tv38 = id == 0;\n\tif (v38) goto L_0033;\n\tgoto L_002B;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v47, id, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_002B:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(7, 2, id, 0, 0f, target, 0);\n\treturn returnVal2;\nL_0033:\n\treturn 0;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int PlayBackwards(object target, object id)
		{
			if (target != null && id != null)
			{
				return TweenManager.FilteredOperation(OperationType.PlayBackwards, FilterType.TargetAndId, id, optionalBool: false, 0f, target);
			}
			return 0;
		}

		[Token(Token = "0x6000053")]
		[Address(RVA = "0xC09854", Offset = "0xC09854", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A3569A]) = v34;\nL_0015:\n\tgoto L_0023;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0023:\n\treturnVal1 = DG.Tweening.Core.TweenManager::FilteredOperation(6, 0, 0, 0, 0f, 0, 0);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int PlayForwardAll()
		{
			return TweenManager.FilteredOperation(OperationType.PlayForward, default(FilterType), null, optionalBool: false, 0f);
		}

		[Token(Token = "0x6000054")]
		[Address(RVA = "0xC098C0", Offset = "0xC098C0", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A3569B]) = v33;\nL_0010:\n\tv34 = targetOrId == 0;\n\tif (v34) goto L_002D;\n\tgoto L_0026;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v37, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0026:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(6, 1, targetOrId, 0, 0f, 0, 0);\n\treturn returnVal2;\nL_002D:\n\treturn 0;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int PlayForward(object targetOrId)
		{
			if (targetOrId != null)
			{
				return TweenManager.FilteredOperation(OperationType.PlayForward, FilterType.TargetOrId, targetOrId, optionalBool: false, 0f);
			}
			return 0;
		}

		[Token(Token = "0x6000055")]
		[Address(RVA = "0xC09944", Offset = "0xC09944", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = DG.Tweening.Core.TweenManager;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, id, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A3569C]) = v36;\nL_0012:\n\tv37 = target == 0;\n\tif (v37) goto L_0033;\n\tv38 = id == 0;\n\tif (v38) goto L_0033;\n\tgoto L_002B;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v47, id, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_002B:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(6, 2, id, 0, 0f, target, 0);\n\treturn returnVal2;\nL_0033:\n\treturn 0;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int PlayForward(object target, object id)
		{
			if (target != null && id != null)
			{
				return TweenManager.FilteredOperation(OperationType.PlayForward, FilterType.TargetAndId, id, optionalBool: false, 0f, target);
			}
			return 0;
		}

		[Token(Token = "0x6000056")]
		[Address(RVA = "0xC099D0", Offset = "0xC099D0", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = DG.Tweening.Core.TweenManager;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A3569D]) = v37;\nL_0017:\n\tgoto L_0026;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0026:\n\treturnVal1 = DG.Tweening.Core.TweenManager::FilteredOperation(0xA, 0, 0, includeDelay, 0f, 0, 0);\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int RestartAll(bool includeDelay = true)
		{
			return TweenManager.FilteredOperation(OperationType.Restart, default(FilterType), null, includeDelay, 0f);
		}

		[Token(Token = "0x6000057")]
		[Address(RVA = "0xC09A40", Offset = "0xC09A40", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv22 = DG.Tweening.Core.TweenManager;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, includeDelay, methodInfo, v25, v26, v27, v28, v29, changeDelayTo, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A3569E]) = v39;\nL_0014:\n\tv40 = targetOrId == 0;\n\tif (v40) goto L_0035;\n\tgoto L_002C;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v43, includeDelay, methodInfo, v25, v26, v27, v28, v29, changeDelayTo, v30, v31, v32, v33, v34, v35, v36);\nL_002C:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(0xA, 1, targetOrId, includeDelay, changeDelayTo, 0, 0);\n\treturn returnVal2;\nL_0035:\n\treturn 0;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Restart(object targetOrId, bool includeDelay = true, float changeDelayTo = -1f)
		{
			if (targetOrId != null)
			{
				return TweenManager.FilteredOperation(OperationType.Restart, FilterType.TargetOrId, targetOrId, includeDelay, changeDelayTo);
			}
			return 0;
		}

		[Token(Token = "0x6000058")]
		[Address(RVA = "0xC09AD8", Offset = "0xC09AD8", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv26 = DG.Tweening.Core.TweenManager;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, id, includeDelay, methodInfo, v29, v30, v31, v32, changeDelayTo, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3569F]) = v42;\nL_0016:\n\tv43 = target == 0;\n\tif (v43) goto L_003B;\n\tv44 = id == 0;\n\tif (v44) goto L_003B;\n\tgoto L_0031;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v55, id, includeDelay, methodInfo, v29, v30, v31, v32, changeDelayTo, v33, v34, v35, v36, v37, v38, v39);\nL_0031:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(0xA, 2, id, includeDelay, changeDelayTo, target, 0);\n\treturn returnVal2;\nL_003B:\n\treturn 0;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Restart(object target, object id, bool includeDelay = true, float changeDelayTo = -1f)
		{
			if (target != null && id != null)
			{
				return TweenManager.FilteredOperation(OperationType.Restart, FilterType.TargetAndId, id, includeDelay, changeDelayTo, target);
			}
			return 0;
		}

		[Token(Token = "0x6000059")]
		[Address(RVA = "0xC09B84", Offset = "0xC09B84", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = DG.Tweening.Core.TweenManager;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A356A0]) = v37;\nL_0017:\n\tgoto L_0026;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0026:\n\treturnVal1 = DG.Tweening.Core.TweenManager::FilteredOperation(8, 0, 0, includeDelay, 0f, 0, 0);\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int RewindAll(bool includeDelay = true)
		{
			return TweenManager.FilteredOperation(OperationType.Rewind, default(FilterType), null, includeDelay, 0f);
		}

		[Token(Token = "0x600005A")]
		[Address(RVA = "0xC09BF4", Offset = "0xC09BF4", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = DG.Tweening.Core.TweenManager;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, includeDelay, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A356A1]) = v36;\nL_0012:\n\tv37 = targetOrId == 0;\n\tif (v37) goto L_0031;\n\tgoto L_0029;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v40, includeDelay, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0029:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(8, 1, targetOrId, includeDelay, 0f, 0, 0);\n\treturn returnVal2;\nL_0031:\n\treturn 0;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Rewind(object targetOrId, bool includeDelay = true)
		{
			if (targetOrId != null)
			{
				return TweenManager.FilteredOperation(OperationType.Rewind, FilterType.TargetOrId, targetOrId, includeDelay, 0f);
			}
			return 0;
		}

		[Token(Token = "0x600005B")]
		[Address(RVA = "0xC09C7C", Offset = "0xC09C7C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A356A2]) = v34;\nL_0015:\n\tgoto L_0023;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0023:\n\treturnVal1 = DG.Tweening.Core.TweenManager::FilteredOperation(9, 0, 0, 0, 0f, 0, 0);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int SmoothRewindAll()
		{
			return TweenManager.FilteredOperation(OperationType.SmoothRewind, default(FilterType), null, optionalBool: false, 0f);
		}

		[Token(Token = "0x600005C")]
		[Address(RVA = "0xC09CE8", Offset = "0xC09CE8", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A356A3]) = v33;\nL_0010:\n\tv34 = targetOrId == 0;\n\tif (v34) goto L_002D;\n\tgoto L_0026;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v37, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0026:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(9, 1, targetOrId, 0, 0f, 0, 0);\n\treturn returnVal2;\nL_002D:\n\treturn 0;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int SmoothRewind(object targetOrId)
		{
			if (targetOrId != null)
			{
				return TweenManager.FilteredOperation(OperationType.SmoothRewind, FilterType.TargetOrId, targetOrId, optionalBool: false, 0f);
			}
			return 0;
		}

		[Token(Token = "0x600005D")]
		[Address(RVA = "0xC09D6C", Offset = "0xC09D6C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A356A4]) = v34;\nL_0015:\n\tgoto L_0023;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0023:\n\treturnVal1 = DG.Tweening.Core.TweenManager::FilteredOperation(0xB, 0, 0, 0, 0f, 0, 0);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int TogglePauseAll()
		{
			return TweenManager.FilteredOperation(OperationType.TogglePause, default(FilterType), null, optionalBool: false, 0f);
		}

		[Token(Token = "0x600005E")]
		[Address(RVA = "0xC09DD8", Offset = "0xC09DD8", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A356A5]) = v33;\nL_0010:\n\tv34 = targetOrId == 0;\n\tif (v34) goto L_002D;\n\tgoto L_0026;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v37, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0026:\n\treturnVal2 = DG.Tweening.Core.TweenManager::FilteredOperation(0xB, 1, targetOrId, 0, 0f, 0, 0);\n\treturn returnVal2;\nL_002D:\n\treturn 0;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int TogglePause(object targetOrId)
		{
			if (targetOrId != null)
			{
				return TweenManager.FilteredOperation(OperationType.TogglePause, FilterType.TargetOrId, targetOrId, optionalBool: false, 0f);
			}
			return 0;
		}

		[Token(Token = "0x600005F")]
		[Address(RVA = "0xC09E5C", Offset = "0xC09E5C", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = DG.Tweening.Core.TweenManager;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, alsoCheckIfIsPlaying, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A356A6]) = v40;\nL_0019:\n\tgoto L_0023;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, alsoCheckIfIsPlaying, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0023:\n\tv55 = DG.Tweening.Core.TweenManager::FilteredOperation(0xC, 1, targetOrId, alsoCheckIfIsPlaying, 0f, 0, 0);\n\tv63 = v55 < 0;\n\tv64 = v55 == 0;\n\tv66 = v55 ^ v55;\n\tv67 = v55 & v66;\n\tv68 = v67 < 0;\n\tv69 = v63 == v68;\n\tv70 = ~v64;\n\tv71 = v69 & v70;\n\treturn v71;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000060")]
		[Address(RVA = "0xC09EE4", Offset = "0xC09EE4", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A356A7]) = v34;\nL_0015:\n\tgoto L_001E;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = DG.Tweening.Core.TweenManager;\nL_001E:\n\treturn v42.totActiveTweens;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int TotalActiveTweens()
		{
			return TweenManager.totActiveTweens;
		}

		[Token(Token = "0x6000061")]
		[Address(RVA = "0xC09F3C", Offset = "0xC09F3C", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A356A8]) = v34;\nL_0015:\n\tgoto L_001E;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = DG.Tweening.Core.TweenManager;\nL_001E:\n\treturn v42.totActiveTweeners;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int TotalActiveTweeners()
		{
			return TweenManager.totActiveTweeners;
		}

		[Token(Token = "0x6000062")]
		[Address(RVA = "0xC09F94", Offset = "0xC09F94", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A356A9]) = v34;\nL_0015:\n\tgoto L_001E;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = DG.Tweening.Core.TweenManager;\nL_001E:\n\treturn v42.totActiveSequences;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int TotalActiveSequences()
		{
			return TweenManager.totActiveSequences;
		}

		[Token(Token = "0x6000063")]
		[Address(RVA = "0xC09FEC", Offset = "0xC09FEC", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = 0x1854D08(methodInfo, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25);\n\treturn returnVal1;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0012;\n\tX0 = *([19369D8]);\n\tX0 = 0xAD9498(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 1;\n\t*([1A356AA]) = X8;\nL_0012:\n\tX0 = *([1936000]);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0018;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0018:\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX0 = 0;\n\tX30 = stack[0];\n\t// 28 ShiftStack 32\n\tX0 = DG.Tweening.Core.TweenManager::TotalPlayingTweens(X0);\n\treturn X0;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int TotalPlayingTweens()
		{
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1854D08 (inside System.__Il2CppComDelegate::Finalize +0xF4)");
			int result = default(int);
			return result;
		}

		[Token(Token = "0x6000064")]
		[Address(RVA = "0xC0A03C", Offset = "0xC0A03C", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = DG.Tweening.Core.TweenManager;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, playingOnly, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A356AB]) = v36;\nL_0012:\n\tv37 = id == 0;\n\tif (v37) goto L_002C;\n\tgoto L_0024;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v40, playingOnly, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0024:\n\treturnVal2 = DG.Tweening.Core.TweenManager::TotalTweensById(id, playingOnly);\n\treturn returnVal2;\nL_002C:\n\treturn 0;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int TotalTweensById(object id, bool playingOnly = false)
		{
			if (id != null)
			{
				return TweenManager.TotalTweensById(id, playingOnly);
			}
			return 0;
		}

		[Token(Token = "0x6000065")]
		[Address(RVA = "0xC0A0B0", Offset = "0xC0A0B0", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv39 = DG.Tweening.Core.TweenManager;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v39, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A356AC]) = v34;\nL_0015:\n\tv37 = fillableList == 0;\n\tif (v37) goto L_0030;\n\tv42 = fillableList._version + 1;\n\tfillableList._size = 0;\n\tfillableList._version = v42;\n\tv53 = fillableList._size < 1;\n\tif (v53) goto L_0030;\n\tSystem.Array::Clear(fillableList._items, 0, fillableList._size);\nL_0030:\n\tgoto L_0039;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v80, v56, v76, v54, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0039:\n\treturnVal1 = DG.Tweening.Core.TweenManager::GetActiveTweens(1, fillableList);\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static List<Tween> PlayingTweens(List<Tween> fillableList = null)
		{
			if (fillableList != null)
			{
				int version = fillableList._version + 1;
				fillableList._size = 0;
				fillableList._version = version;
				if (fillableList.Count >= 1)
				{
					Array.Clear(fillableList._items, 0, fillableList.Count);
				}
			}
			return TweenManager.GetActiveTweens(playing: true, fillableList);
		}

		[Token(Token = "0x6000066")]
		[Address(RVA = "0xC0A140", Offset = "0xC0A140", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv39 = DG.Tweening.Core.TweenManager;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v39, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A356AD]) = v34;\nL_0015:\n\tv37 = fillableList == 0;\n\tif (v37) goto L_0030;\n\tv42 = fillableList._version + 1;\n\tfillableList._size = 0;\n\tfillableList._version = v42;\n\tv53 = fillableList._size < 1;\n\tif (v53) goto L_0030;\n\tSystem.Array::Clear(fillableList._items, 0, fillableList._size);\nL_0030:\n\tgoto L_0039;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v80, v56, v76, v54, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0039:\n\treturnVal1 = DG.Tweening.Core.TweenManager::GetActiveTweens(0, fillableList);\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static List<Tween> PausedTweens(List<Tween> fillableList = null)
		{
			if (fillableList != null)
			{
				int version = fillableList._version + 1;
				fillableList._size = 0;
				fillableList._version = version;
				if (fillableList.Count >= 1)
				{
					Array.Clear(fillableList._items, 0, fillableList.Count);
				}
			}
			return TweenManager.GetActiveTweens(playing: false, fillableList);
		}

		[Token(Token = "0x6000067")]
		[Address(RVA = "0xC0A1D0", Offset = "0xC0A1D0", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, playingOnly, fillableList, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv43 = DG.Tweening.Core.TweenManager;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, playingOnly, fillableList, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A356AE]) = v40;\nL_0017:\n\tv41 = id == 0;\n\tif (v41) goto L_004B;\n\tv46 = fillableList == 0;\n\tif (v46) goto L_0036;\n\tv55 = fillableList._version + 1;\n\tfillableList._size = 0;\n\tfillableList._version = v55;\n\tv66 = fillableList._size < 1;\n\tif (v66) goto L_0036;\n\tSystem.Array::Clear(fillableList._items, 0, fillableList._size);\nL_0036:\n\tgoto L_0042;\n\tv126 = \"il2cpp_codegen_runtime_class_init\"(v93, v69, v89, v67, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0042:\n\treturnVal2 = DG.Tweening.Core.TweenManager::GetTweensById(id, playingOnly, fillableList);\n\treturn returnVal2;\nL_004B:\n\treturn 0;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static List<Tween> TweensById(object id, bool playingOnly = false, List<Tween> fillableList = null)
		{
			if (id != null)
			{
				if (fillableList != null)
				{
					int version = fillableList._version + 1;
					fillableList._size = 0;
					fillableList._version = version;
					if (fillableList.Count >= 1)
					{
						Array.Clear(fillableList._items, 0, fillableList.Count);
					}
				}
				return TweenManager.GetTweensById(id, playingOnly, fillableList);
			}
			return null;
		}

		[Token(Token = "0x6000068")]
		[Address(RVA = "0xC0A28C", Offset = "0xC0A28C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, playingOnly, fillableList, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv45 = DG.Tweening.Core.TweenManager;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, playingOnly, fillableList, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A356AF]) = v40;\nL_0019:\n\tv43 = fillableList == 0;\n\tif (v43) goto L_0034;\n\tv48 = fillableList._version + 1;\n\tfillableList._size = 0;\n\tfillableList._version = v48;\n\tv59 = fillableList._size < 1;\n\tif (v59) goto L_0034;\n\tSystem.Array::Clear(fillableList._items, 0, fillableList._size);\nL_0034:\n\tgoto L_0040;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v86, v62, v82, v60, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0040:\n\treturnVal1 = DG.Tweening.Core.TweenManager::GetTweensByTarget(target, playingOnly, fillableList);\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static List<Tween> TweensByTarget(object target, bool playingOnly = false, List<Tween> fillableList = null)
		{
			if (fillableList != null)
			{
				int version = fillableList._version + 1;
				fillableList._size = 0;
				fillableList._version = version;
				if (fillableList.Count >= 1)
				{
					Array.Clear(fillableList._items, 0, fillableList.Count);
				}
			}
			return TweenManager.GetTweensByTarget(target, playingOnly, fillableList);
		}

		[Token(Token = "0x6000069")]
		[Address(RVA = "0xC06D30", Offset = "0xC06D30", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = UnityEngine.Application;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = DG.Tweening.DOTween;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A356B0]) = v35;\nL_0018:\n\tgoto L_001D;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v36, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv44 = DG.Tweening.DOTween;\nL_001D:\n\tv47 = ~v45.initialized;\n\tv48 = ~v47;\n\tif (v48) goto L_003B;\n\tgoto L_0029;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v51, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0029:\n\tv57 = UnityEngine.Application::get_isPlaying();\n\tv60 = v57 == 0;\n\tif (v60) goto L_003B;\n\tgoto L_0033;\n\tv85 = \"il2cpp_codegen_runtime_class_init\"(v82, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0033:\n\tv56 = DG.Tweening.DOTween::get_isQuitting();\n\tv59 = v56 == 0;\n\tif (v59) goto L_0040;\nL_003B:\n\treturn;\nL_0040:\n\tgoto L_0046;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v88, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0046:\n\tDG.Tweening.DOTween::AutoInit();\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void InitCheck()
		{
			if (!initialized && Application.isPlaying && !isQuitting)
			{
				AutoInit();
			}
		}

		[Token(Token = "0x600006A")]
		[Address(RVA = "0xDA84A8", Offset = "0xDA84A8", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv41 = *([plugin @ X3 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+38]) == 0;\n\tv42 = ~v41;\n\tif (v42) goto L_002B;\n\tv71 = *([plugin @ X3 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+38]) == 0;\n\tv57 = ~v71;\n\tif (v57) goto L_002B;\n\tv54 = 0xB3490C(plugin, setter, endValue, plugin, methodInfo, v47, v48, v49, duration, v34, v32, v30, v28, v50, v51, v52);\nL_002B:\n\tgoto L_002E;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v62, setter, endValue, plugin, methodInfo, v47, v48, v49, duration, v34, v32, v30, v28, v50, v51, v52);\nL_002E:\n\tDG.Tweening.DOTween::InitCheck();\n\tgoto L_0037;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v74, setter, endValue, plugin, methodInfo, v47, v48, v49, duration, v34, v32, v30, v28, v50, v51, v52);\nL_0037:\n\tv81 = *([plugin @ X3 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+38]);\n\tv83 = DG.Tweening.Core.TweenManager::GetTweener /* +1 sharing this address */(*([v81 @ X8_v7]));\n\tv84 = *([plugin @ X3 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+38]);\n\tv95 = DG.Tweening.Tweener::Setup /* +1 sharing this address */(v83, getter, setter, endValue, duration, *([v84 @ X8_v8+30]), v47);\n\tv96 = v95 & 1;\n\tv97 = v96 == 0;\n\tv98 = ~v97;\n\tif (v98) goto L_0062;\n\tgoto L_0053;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v99, v85, v86, v93, v88, v47, v48, v49, v87, v89, v90, v91, v92, v50, v51, v52);\nL_0053:\n\tDG.Tweening.Core.TweenManager::Despawn(v83, 1);\nL_0062:\n\treturn v110;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static TweenerCore<T1, T2, TPlugOptions> ApplyTo<T1, T2, TPlugOptions>(DOGetter<T1> getter, DOSetter<T1> setter, T2 endValue, float duration, ABSTweenPlugin<T1, T2, TPlugOptions> plugin = null) where TPlugOptions : struct, IPlugOptions
		{
			//IL_0093: Expected O, but got I
			//IL_00b2: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [plugin @ X3 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [plugin @ X3 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+38]");
				if ((nint)0 == 0)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @B3490C");
				}
			}
			InitCheck();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [plugin @ X3 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+38]");
			object obj = 0;
			Il2CppRuntime.Boundary("MANAGED", "Method not found @CB2A5C (DG.Tweening.Core.TweenManager::GetTweener, and 1 more at this address)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [plugin @ X3 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+38]");
			object obj2 = 0;
			Il2CppRuntime.Boundary("MANAGED", "Method not found @CC7EDC (DG.Tweening.Tweener::Setup, and 1 more at this address)");
			object obj3 = default(object);
			int num = (int)((nint)obj3 & 1);
			bool flag = num == 0;
			bool flag2 = !flag;
			Tween tween = default(Tween);
			TweenerCore<T1, T2, TPlugOptions> result = (TweenerCore<T1, T2, TPlugOptions>)tween;
			if (!flag2)
			{
				TweenManager.Despawn(tween);
				result = null;
			}
			return result;
		}

		[Token(Token = "0x600006B")]
		[Address(RVA = "0xC0A330", Offset = "0xC0A330", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTween()
		{
		}

		[Token(Token = "0x600006C")]
		[Address(RVA = "0xC0A338", Offset = "0xC0A338", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv26 = DG.Tweening.DOTween;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv68 = Il2CppMethodInfo;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv73 = System.Collections.Generic.List`1<DG.Tweening.TweenCallback>;\n\tv74 = \"il2cpp_codegen_initialize_runtime_metadata\"(v73, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv85 = \"1.2.765\";\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v85, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv47 = 1;\n\t*([1A356B1]) = v47;\nL_0028:\n\tv52.Version = \"1.2.765\";\n\tv57.safeModeLogBehaviour = 1E-323d;\n\tv57.timeScale = 0f;\n\tv57.useSafeMode = 1;\n\tv57.rewindCallbackMode = 4.243991582E-314d;\n\tv57.maxSmoothUnscaledTime = 0.15f;\n\tv57.defaultAutoPlay = 3;\n\tv57.showUnityEditorReport = 0;\n\tv57.drawGizmos = 1;\n\tv57._fooDebugStoreTargetId = 1;\n\tv57.defaultUpdateType = 0;\n\tv57.defaultTimeScaleIndependent = 0;\n\tv57.defaultAutoKill = 1;\n\tv57.defaultLoopType = 0;\n\tv57.defaultEaseType = 6;\n\tv57.defaultEaseOvershootOrAmplitude = 5.292621394E-315d;\n\tv66 = new System.Collections.Generic.List`1<DG.Tweening.TweenCallback>();\n\tSystem.Collections.Generic.List`1<DG.Tweening.TweenCallback>::.ctor(v66);\n\tv79.GizmosDelegates = v66;\n\tv79._isQuittingFrame = 0xFFFFFFFF;\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static DOTween()
		{
			//IL_001d: Expected I4, but got F8
			//IL_003f: Expected I4, but got F8
			Version = "1.2.765";
			safeModeLogBehaviour = SafeModeLogBehaviour.None;
			timeScale = 0f;
			useSafeMode = true;
			rewindCallbackMode = RewindCallbackMode.FireIfPositionChanged;
			maxSmoothUnscaledTime = 0.15f;
			defaultAutoPlay = AutoPlay.All;
			showUnityEditorReport = false;
			drawGizmos = true;
			_fooDebugStoreTargetId = true;
			defaultUpdateType = default(UpdateType);
			defaultTimeScaleIndependent = false;
			defaultAutoKill = true;
			defaultLoopType = default(LoopType);
			defaultEaseType = Ease.OutQuad;
			defaultEaseOvershootOrAmplitude = 0f;
			List<TweenCallback> gizmosDelegates = new List<TweenCallback>();
			GizmosDelegates = gizmosDelegates;
			_isQuittingFrame = -1;
		}
	}
}
