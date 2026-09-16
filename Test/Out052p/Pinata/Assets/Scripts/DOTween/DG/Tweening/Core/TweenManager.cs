using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening.Core
{
	[Token(Token = "0x2000053")]
	public static class TweenManager
	{
		[Token(Token = "0x20000BB")]
		internal enum CapacityIncreaseMode
		{
			[Token(Token = "0x4000258")]
			TweenersAndSequences = 0,
			[Token(Token = "0x4000259")]
			TweenersOnly = 1,
			[Token(Token = "0x400025A")]
			SequencesOnly = 2
		}

		[Token(Token = "0x400015D")]
		private const int _DefaultMaxTweeners = 200;

		[Token(Token = "0x400015E")]
		private const int _DefaultMaxSequences = 50;

		[Token(Token = "0x400015F")]
		private const string _MaxTweensReached = "Max Tweens reached: capacity has automatically been increased from #0 to #1. Use DOTween.SetTweensCapacity to set it manually at startup";

		[Token(Token = "0x4000160")]
		private const float _EpsilonVsTimeCheck = 1E-06f;

		[Token(Token = "0x4000161")]
		public static bool isUnityEditor;

		[Token(Token = "0x4000162")]
		internal static bool isDebugBuild;

		[Token(Token = "0x4000163")]
		internal static int maxActive;

		[Token(Token = "0x4000164")]
		internal static int maxTweeners;

		[Token(Token = "0x4000165")]
		internal static int maxSequences;

		[Token(Token = "0x4000166")]
		internal static bool hasActiveTweens;

		[Token(Token = "0x4000167")]
		internal static bool hasActiveDefaultTweens;

		[Token(Token = "0x4000168")]
		internal static bool hasActiveLateTweens;

		[Token(Token = "0x4000169")]
		internal static bool hasActiveFixedTweens;

		[Token(Token = "0x400016A")]
		internal static bool hasActiveManualTweens;

		[Token(Token = "0x400016B")]
		internal static int totActiveTweens;

		[Token(Token = "0x400016C")]
		internal static int totActiveDefaultTweens;

		[Token(Token = "0x400016D")]
		internal static int totActiveLateTweens;

		[Token(Token = "0x400016E")]
		internal static int totActiveFixedTweens;

		[Token(Token = "0x400016F")]
		internal static int totActiveManualTweens;

		[Token(Token = "0x4000170")]
		internal static int totActiveTweeners;

		[Token(Token = "0x4000171")]
		internal static int totActiveSequences;

		[Token(Token = "0x4000172")]
		internal static int totPooledTweeners;

		[Token(Token = "0x4000173")]
		internal static int totPooledSequences;

		[Token(Token = "0x4000174")]
		internal static int totTweeners;

		[Token(Token = "0x4000175")]
		internal static int totSequences;

		[Token(Token = "0x4000176")]
		internal static bool isUpdateLoop;

		[Token(Token = "0x4000177")]
		internal static Tween[] _activeTweens;

		[Token(Token = "0x4000178")]
		private static Tween[] _pooledTweeners;

		[Token(Token = "0x4000179")]
		private static readonly Stack<Tween> _PooledSequences;

		[Token(Token = "0x400017A")]
		private static readonly List<Tween> _KillList;

		[Token(Token = "0x400017B")]
		private static readonly Dictionary<Tween, TweenLink> _TweenLinks;

		[Token(Token = "0x400017C")]
		private static int _totTweenLinks;

		[Token(Token = "0x400017D")]
		private static int _maxActiveLookupId;

		[Token(Token = "0x400017E")]
		private static bool _requiresActiveReorganization;

		[Token(Token = "0x400017F")]
		private static int _reorganizeFromId;

		[Token(Token = "0x4000180")]
		private static int _minPooledTweenerId;

		[Token(Token = "0x4000181")]
		private static int _maxPooledTweenerId;

		[Token(Token = "0x4000182")]
		private static bool _despawnAllCalledFromUpdateLoopCallback;

		[Token(Token = "0x60002AC")]
		[Address(RVA = "0x1075C78", Offset = "0x1075C78", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv16 = *([1F0F620]);\n\tv17 = *([v16 @ X8_v32]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20269B6]) = v37;\nL_001A:\n\tv45.maxActive = 0xFA;\n\tv47.maxTweeners = 0xC8;\n\tv48.maxSequences = 0x32;\n\t// 35 NewArr v52 @ X0_v3 (DG.Tweening.Tween[]), typeof(DG.Tweening.Tween[]), 250\n\tv55._activeTweens = v52;\n\t// 41 NewArr v57 @ X0_v5 (DG.Tweening.Tween[]), typeof(DG.Tweening.Tween[]), 200\n\tv59._pooledTweeners = v57;\n\tv63 = new System.Collections.Generic.Stack`1<DG.Tweening.Tween>();\n\tSystem.Collections.Generic.Stack`1<DG.Tweening.Tween>::.ctor(v63);\n\tv69._PooledSequences = v63;\n\tv73 = new System.Collections.Generic.List`1<DG.Tweening.Tween>();\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::.ctor(v73, 0xFA);\n\tv80._KillList = v73;\n\tv84 = new System.Collections.Generic.Dictionary`2<DG.Tweening.Tween, DG.Tweening.Core.TweenLink>();\n\tSystem.Collections.Generic.Dictionary`2<DG.Tweening.Tween, DG.Tweening.Core.TweenLink>::.ctor(v84, 0xFA);\n\tv93._TweenLinks = v84;\n\tv94._maxActiveLookupId = 0xFFFFFFFF;\n\tv95._reorganizeFromId = 0xFFFFFFFF;\n\tv96._minPooledTweenerId = 0xFFFFFFFF;\n\tv97._maxPooledTweenerId = 0xFFFFFFFF;\n\tv98 = UnityEngine.Application::get_isEditor();\n\tv101.isUnityEditor = v98;\n\treturn;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static TweenManager()
		{
			maxActive = 250;
			maxTweeners = 200;
			maxSequences = 50;
			Tween[] activeTweens = new Tween[250];
			_activeTweens = activeTweens;
			Tween[] pooledTweeners = new Tween[200];
			_pooledTweeners = pooledTweeners;
			Stack<Tween> pooledSequences = new Stack<Tween>();
			_PooledSequences = pooledSequences;
			List<Tween> killList = new List<Tween>(250);
			_KillList = killList;
			Dictionary<Tween, TweenLink> tweenLinks = new Dictionary<Tween, TweenLink>(250);
			_TweenLinks = tweenLinks;
			_maxActiveLookupId = -1;
			_reorganizeFromId = -1;
			_minPooledTweenerId = -1;
			_maxPooledTweenerId = -1;
			bool isEditor = Application.isEditor;
			isUnityEditor = isEditor;
		}

		[Token(Token = "0x60002AD")]
		[Address(RVA = "0x135AADC", Offset = "0x135AADC", Length = "0x5E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv30 = *([1EF86B8]);\n\tv31 = *([v30 @ X8_v96]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202881E]) = v50;\nL_0020:\n\tgoto L_0028;\n\tv58 = *([v54 @ X0_v2 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv59 = v58 == 0;\n\tv60 = ~v59;\n\tgoto L_0028;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v54, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv62 = DG.Tweening.Core.TweenManager;\nL_0028:\n\tv66 = v65.totPooledTweeners;\n\tv77 = v65.totPooledTweeners < 1;\n\tif (v77) goto L_0109;\n\tgoto L_0045;\n\tv90 = *([v81 @ X0_v55+E0]);\n\tv91 = v90 == 0;\n\tv92 = ~v91;\n\tif (v92) goto L_0045;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v81, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0045:\n\tv99 = System.Type::GetTypeFromHandle(Il2CppClass<T1>);\n\tv128 = System.Type::GetTypeFromHandle(Il2CppClass<T2>);\n\tv239 = System.Type::GetTypeFromHandle(Il2CppClass<TPlugOptions>);\n\tgoto L_0060;\n\tv271 = *([v256 @ X8_v53 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv272 = v271 == 0;\n\tv273 = ~v272;\n\tif (v273) goto L_0060;\n\tv306 = v256;\n\tv276 = \"il2cpp_codegen_runtime_class_init\"(v306, v205, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv279 = DG.Tweening.Core.TweenManager;\nL_0060:\n\tv765 = v280._maxPooledTweenerId;\n\tgoto L_00A8;\nL_0064:\n\tgoto L_006D;\n\tv520 = *([v420 @ X8_v56 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv521 = v520 == 0;\n\tv522 = ~v521;\n\tif (v522) goto L_006D;\n\tv540 = v420;\n\tv526 = \"il2cpp_codegen_runtime_class_init\"(v540, v205, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv528 = DG.Tweening.Core.TweenManager;\n\tv525 = *([v528 @ X8_v89+B8]);\nL_006D:\n\tv529 = v524._pooledTweeners;\n\tv541 = v765 < v529.Length;\n\tv542 = ~v541;\n\tif (v542) goto L_0256;\n\tv314 = v529[v765 @ X25_v11 (System.Int32)];\n\tv341 = v529[v765 @ X25_v11 (System.Int32)] == 0;\n\tif (v341) goto L_00A4;\n\tv673 = v314.typeofT1 != v99;\n\tif (v673) goto L_00A4;\n\tv559 = v314.typeofT2 != v128;\n\tif (v559) goto L_00A4;\n\tv572 = v314.typeofTPlugOptions == v239;\n\tif (v572) goto L_01C4;\nL_00A4:\n\tv765 = v765 - 1;\nL_00A8:\n\tgoto L_00B3;\n\tv411 = *([v342 @ X8_v55 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv412 = v411 == 0;\n\tv413 = ~v412;\n\tgoto L_00B3;\n\tv500 = v342;\n\tv418 = \"il2cpp_codegen_runtime_class_init\"(v500, v205, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv421 = DG.Tweening.Core.TweenManager;\n\tv415 = *([v421 @ X8_v90+12E]);\nL_00B3:\n\tv309 = v422._minPooledTweenerId - 1;\n\tv434 = v765 > v309;\n\tif (v434) goto L_0064;\n\tgoto L_00D8;\n\tv511 = *([v420 @ X8_v56 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv512 = v511 == 0;\n\tv513 = ~v512;\n\tif (v513) goto L_00D8;\n\tv536 = v420;\n\tv516 = \"il2cpp_codegen_runtime_class_init\"(v536, v205, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv517 = DG.Tweening.Core.TweenManager;\n\tv515 = *([v517 @ X8_v64+B8]);\nL_00D8:\n\tv151 = v210.totTweeners < v210.maxTweeners;\n\tif (v151) goto L_0195;\n\tgoto L_00E6;\n\tv607 = *([v225 @ X8_v57+E0]);\n\tv608 = v607 == 0;\n\tv609 = ~v608;\n\tif (v609) goto L_00E6;\n\tv661 = v225;\n\tv611 = \"il2cpp_codegen_runtime_class_init\"(v661, v205, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv614 = DG.Tweening.Core.TweenManager;\n\tv610 = *([v614 @ X8_v63+B8]);\nL_00E6:\n\tv597 = v587._pooledTweeners;\n\tv66 = v587._maxPooledTweenerId;\n\tv662 = v587._maxPooledTweenerId < v597.Length;\n\tv190 = ~v662;\n\tif (v190) goto L_0256;\n\tv597[v66 @ X9_v1 (System.Int32)] = 0;\n\tv702 = v700._maxPooledTweenerId - 1;\n\tv700._maxPooledTweenerId = v702;\n\tv194 = v703.totPooledTweeners - 1;\n\tv703.totPooledTweeners = v194;\n\tv66 = v65.totTweeners;\n\tv66 = v66 - 1;\n\tv65.totTweeners = v66;\n\tgoto L_0195;\nL_0109:\n\tgoto L_0111;\n\tv100 = *([v61 @ X0_v3 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv101 = v100 == 0;\n\tv102 = ~v101;\n\tif (v102) goto L_0111;\n\tv129 = \"il2cpp_codegen_runtime_class_init\"(v61, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv105 = DG.Tweening.Core.TweenManager;\n\tv108 = *([v105 @ X0_v54+B8]);\nL_0111:\n\tv66 = v65.maxTweeners;\n\tv111 = v65.maxTweeners - 1;\n\tv122 = v65.totTweeners < v111;\n\tif (v122) goto L_0195;\n\tgoto L_012C;\n\tv240 = *([v104 @ X0_v27+E0]);\n\tv241 = v240 == 0;\n\tv242 = ~v241;\n\tif (v242) goto L_012C;\n\tv245 = \"il2cpp_codegen_runtime_class_init\"(v104, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv282 = DG.Tweening.Core.TweenManager;\n\tv248 = *([v282 @ X8_v42+B8]);\n\tv243 = *([v248 @ X8_v43+8]);\nL_012C:\n\tv249 = v65.maxSequences;\n\tDG.Tweening.Core.TweenManager::IncreaseCapacities(1);\n\tgoto L_014C;\n\tv284 = *([1ED3CD8]);\n\tv285 = *([v284 @ X8_v41]);\n\tv286 = \"il2cpp_codegen_initialize_method\"(v285, v206, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([2022B9B]) = v229;\nL_014C:\n\tv150 = v291._logPriority < 1;\n\tif (v150) goto L_0195;\n\tv349 = 0xDC3560(&v66 @ X9_v1 (System.Int32), 0, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv438 = 0xDC3560(&v249 @ X8_v21 (System.Int32), 0, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv510 = System.String::Concat(v349, \"/\", v438);\n\tv606 = System.String::Replace(\"Max Tweens reached: capacity has automatically been increased from #0 to #1. Use DOTween.SetTweensCapacity to set it manually at startup\", \"#0\", v510);\n\tgoto L_0177;\n\tv686 = *([v657 @ X8_v32 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv687 = v686 == 0;\n\tv688 = ~v687;\n\tif (v688) goto L_0177;\n\tv714 = v657;\n\tv690 = \"il2cpp_codegen_runtime_class_init\"(v714, v605, v533, v604, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv693 = DG.Tweening.Core.TweenManager;\nL_0177:\n\tv696 = v692.isUnityEditor + 8;\n\tv697 = 0xDC3560(v696, 0, v510, 0, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv717 = v715.isUnityEditor + 0xC;\n\tv718 = 0xDC3560(v717, 0, v510, 0, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv589 = System.String::Concat(v697, \"/\", v718);\n\tv213 = System.String::Replace(v606, \"#1\", v589);\n\tDG.Tweening.Core.Debugger::LogWarning(v213);\nL_0195:\n\tgoto L_0199;\n\tv251 = v231;\n\tv252 = 0x8907BC(v251, v203, v145, v143, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0199:\n\tv255 = new Il2CppClass<DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>>();\n\tv266 = DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>::.ctor(v255);\n\tgoto L_01AD;\n\tv294 = *([v267 @ X0_v20 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv295 = v294 == 0;\n\tv296 = ~v295;\n\tif (v296) goto L_01AD;\n\tv350 = \"il2cpp_codegen_runtime_class_init\"(v267, v264, v145, v143, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv298 = DG.Tweening.Core.TweenManager;\nL_01AD:\n\tv66 = v65.totTweeners;\n\tv66 = v66 + 1;\n\tv65.totTweeners = v66;\n\tDG.Tweening.Core.TweenManager::AddActiveTween(v255);\nL_01BD:\n\treturn v394;\nL_01C4:\n\tgoto L_01C9;\n\tv726 = v399;\n\tv727 = 0x8907BC(v726, v205, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_01C9:\n\t// 457 IsInst v710 @ X0_v75 (DG.Tweening.Tween), typeof(DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>), v529[v765 @ X25_v11 (System.Int32)]\n\tv711 = v710 == 0;\n\tif (v711) goto L_025C;\n\tgoto L_01D9;\n\tv737 = *([v733 @ X0_v76+E0]);\n\tv738 = v737 == 0;\n\tv739 = ~v738;\n\tif (v739) goto L_01D9;\n\tv741 = \"il2cpp_codegen_runtime_class_init\"(v733, v708, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_01D9:\n\tDG.Tweening.Core.TweenManager::AddActiveTween(v710);\n\tv596 = v65._pooledTweeners;\n\tv66 = v596.Length;\n\tv746 = v765 < v596.Length;\n\tv642 = ~v746;\n\tif (v642) goto L_0256;\n\tv596[v765 @ X25_v11 (System.Int32)] = 0;\n\tv66 = v65._maxPooledTweenerId;\n\tv756 = v65._maxPooledTweenerId == v65._minPooledTweenerId;\n\tif (v756) goto L_0248;\n\tgoto L_0211;\n\tv805 = *([v748 @ X0_v79 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv806 = v805 == 0;\n\tv807 = ~v806;\n\tif (v807) goto L_0211;\n\tv823 = \"il2cpp_codegen_runtime_class_init\"(v748, v387, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v4\n// ... truncated")]
		internal static TweenerCore<T1, T2, TPlugOptions> GetTweener<T1, T2, TPlugOptions>() where TPlugOptions : struct, IPlugOptions
		{
			//IL_045b: Expected O, but got I4
			//IL_0474: Expected O, but got I4
			int num = totPooledTweeners;
			if (totPooledTweeners >= 1)
			{
				Type typeFromHandle = typeof(T1);
				Type typeFromHandle2 = typeof(T2);
				Type typeFromHandle3 = typeof(TPlugOptions);
				int num2 = _maxPooledTweenerId;
				while (true)
				{
					int num3 = _minPooledTweenerId - 1;
					if (num2 <= num3)
					{
						if (totTweeners < maxTweeners)
						{
							break;
						}
						Tween[] pooledTweeners = _pooledTweeners;
						num = _maxPooledTweenerId;
						if (_maxPooledTweenerId < pooledTweeners.Length)
						{
							pooledTweeners[num] = null;
							int maxPooledTweenerId = _maxPooledTweenerId - 1;
							_maxPooledTweenerId = maxPooledTweenerId;
							int num4 = totPooledTweeners - 1;
							totPooledTweeners = num4;
							num = totTweeners;
							num--;
							totTweeners = num;
							break;
						}
					}
					else
					{
						Tween[] pooledTweeners2 = _pooledTweeners;
						if (num2 < pooledTweeners2.Length)
						{
							Tween tween = pooledTweeners2[num2];
							if (pooledTweeners2[num2] == null || (object)tween.typeofT1 != typeFromHandle || (object)tween.typeofT2 != typeFromHandle2 || (object)tween.typeofTPlugOptions != typeFromHandle3)
							{
								num2--;
								continue;
							}
							Tween tween2 = pooledTweeners2[num2] as TweenerCore<T1, T2, TPlugOptions>;
							if (tween2 == null)
							{
								return (TweenerCore<T1, T2, TPlugOptions>)(object)new InvalidCastException();
							}
							AddActiveTween(tween2);
							Tween[] pooledTweeners3 = _pooledTweeners;
							num = pooledTweeners3.Length;
							if (num2 < pooledTweeners3.Length)
							{
								pooledTweeners3[num2] = null;
								num = _maxPooledTweenerId;
								if (_maxPooledTweenerId != _minPooledTweenerId)
								{
									if (_maxPooledTweenerId == num2)
									{
										num = num2 - 1;
										_maxPooledTweenerId = num;
									}
									else
									{
										num = _minPooledTweenerId;
										if (_minPooledTweenerId == num2)
										{
											num = num2 + 1;
											_minPooledTweenerId = num;
										}
									}
								}
								num = totPooledTweeners;
								num--;
								totPooledTweeners = num;
								return (TweenerCore<T1, T2, TPlugOptions>)tween2;
							}
						}
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
			}
			else
			{
				num = maxTweeners;
				int num5 = maxTweeners - 1;
				if (totTweeners >= num5)
				{
					int num6 = maxSequences;
					IncreaseCapacities(CapacityIncreaseMode.TweenersOnly);
					if (Debugger._logPriority >= 1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
						string text = default(string);
						string text2 = default(string);
						string newValue = text + "/" + text2;
						string text3 = "Max Tweens reached: capacity has automatically been increased from #0 to #1. Use DOTween.SetTweensCapacity to set it manually at startup".Replace("#0", newValue);
						object obj = (isUnityEditor ? 1 : 0) + 8;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
						object obj2 = (isUnityEditor ? 1 : 0) + 12;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
						string text4 = default(string);
						string text5 = default(string);
						string newValue2 = text4 + "/" + text5;
						string message = text3.Replace("#1", newValue2);
						Debugger.LogWarning(message);
					}
				}
			}
			Tween tween3 = new TweenerCore<T1, T2, TPlugOptions>();
			num = totTweeners;
			num++;
			totTweeners = num;
			AddActiveTween(tween3);
			return (TweenerCore<T1, T2, TPlugOptions>)tween3;
		}

		[Token(Token = "0x60002AE")]
		[Address(RVA = "0x1075DF4", Offset = "0x1075DF4", Length = "0x2E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1F0F298]);\n\tv21 = *([v20 @ X8_v56]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([20269B7]) = v41;\nL_001B:\n\tgoto L_002F;\n\tv49 = *([v45 @ X0_v2 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_002F;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v45, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv55 = DG.Tweening.Core.TweenManager;\n\tv53 = *([v55 @ X0_v56+12E]);\nL_002F:\n\tv70 = v58.totPooledSequences < 1;\n\tif (v70) goto L_005E;\n\tgoto L_0041;\n\tv76 = *([v54 @ X0_v3 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv77 = v76 == 0;\n\tv78 = ~v77;\n\t// 55 ConditionalJump @b55, v78 @ TEMP_v41\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v54, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv173 = DG.Tweening.Core.TweenManager;\n\tv84 = *([v173 @ X8_v51+B8]);\nL_0041:\n\tv113 = System.Collections.Generic.Stack`1<DG.Tweening.Tween>::Pop(v58._PooledSequences);\n\tv175 = v113 == 0;\n\tif (v175) goto L_0055;\n\tv177 = *([v113 @ X0_v51 (DG.Tweening.Tween)]) != DG.Tweening.Sequence;\n\tif (v177) goto L_0105;\nL_0055:\n\tDG.Tweening.Core.TweenManager::AddActiveTween(v113);\n\tv96 = v58.totPooledSequences;\n\tv96 = v96 - 1;\n\tv58.totPooledSequences = v96;\n\tgoto L_0102;\nL_005E:\n\tgoto L_0066;\n\tv87 = *([v54 @ X0_v3 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv88 = v87 == 0;\n\tv89 = ~v88;\n\tif (v89) goto L_0066;\n\tv115 = \"il2cpp_codegen_runtime_class_init\"(v54, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv92 = DG.Tweening.Core.TweenManager;\n\tv95 = *([v92 @ X0_v44+B8]);\nL_0066:\n\tv96 = v58.maxSequences;\n\tv98 = v58.maxSequences - 1;\n\tv109 = v58.totSequences < v98;\n\tif (v109) goto L_00E5;\n\tgoto L_0081;\n\tv203 = *([v91 @ X0_v9+E0]);\n\tv204 = v203 == 0;\n\tv205 = ~v204;\n\tif (v205) goto L_0081;\n\tv208 = \"il2cpp_codegen_runtime_class_init\"(v91, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv278 = DG.Tweening.Core.TweenManager;\n\tv211 = *([v278 @ X8_v38+B8]);\n\tv206 = *([v211 @ X8_v39+C]);\nL_0081:\n\tv212 = v58.maxTweeners;\n\tDG.Tweening.Core.TweenManager::IncreaseCapacities(2);\n\tgoto L_00A0;\n\tv280 = *([1EC27E8]);\n\tv281 = *([v280 @ X8_v36]);\n\tv282 = \"il2cpp_codegen_initialize_method\"(v281, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv284 = 0 | 1;\n\t*([2022B9B]) = v284;\nL_00A0:\n\tv135 = v288._logPriority < 1;\n\tif (v135) goto L_00E5;\n\tv360 = 0xDC3560(&v212 @ X8_v16 (System.Int32), 0, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv364 = 0xDC3560(&v96 @ X9_v6 (System.Int32), 0, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv257 = System.String::Concat(v360, \"/\", v364);\n\tv375 = System.String::Replace(\"Max Tweens reached: capacity has automatically been increased from #0 to #1. Use DOTween.SetTweensCapacity to set it manually at startup\", \"#0\", v257);\n\tgoto L_00CB;\n\tv380 = *([v376 @ X8_v27 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv381 = v380 == 0;\n\tv382 = ~v381;\n\tif (v382) goto L_00CB;\n\tv392 = v376;\n\tv384 = \"il2cpp_codegen_runtime_class_init\"(v392, v374, v240, v373, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv387 = DG.Tweening.Core.TweenManager;\nL_00CB:\n\tv390 = v386.isUnityEditor + 8;\n\tv391 = 0xDC3560(v390, 0, v257, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv395 = v393.isUnityEditor + 0xC;\n\tv396 = 0xDC3560(v395, 0, v257, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv258 = System.String::Concat(v391, \"/\", v396);\n\tv158 = System.String::Replace(v375, \"#1\", v258);\n\tDG.Tweening.Core.Debugger::LogWarning(v158);\nL_00E5:\n\tv172 = new DG.Tweening.Sequence();\n\tDG.Tweening.Sequence::.ctor(v172);\n\tgoto L_00F6;\n\tv291 = *([v270 @ X0_v13 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv292 = v291 == 0;\n\tv293 = ~v292;\n\tif (v293) goto L_00F6;\n\tv361 = \"il2cpp_codegen_runtime_class_init\"(v270, v214, v128, v126, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv295 = DG.Tweening.Core.TweenManager;\nL_00F6:\n\tv96 = v58.totSequences;\n\tv96 = v96 + 1;\n\tv58.totSequences = v96;\n\tDG.Tweening.Core.TweenManager::AddActiveTween(v172);\nL_0102:\n\treturn v324;\n\tthrow System.NullReferenceException;\nL_0105:\n\tthrow System.InvalidCastException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 163 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static Sequence GetSequence()
		{
			//IL_01d1: Expected O, but got I4
			//IL_01ea: Expected O, but got I4
			int num;
			if (totPooledSequences >= 1)
			{
				Tween tween = _PooledSequences.Pop();
				if (tween == null || (object)tween.GetType() == typeof(Sequence))
				{
					AddActiveTween(tween);
					num = totPooledSequences;
					num--;
					totPooledSequences = num;
					return (Sequence)tween;
				}
				throw new InvalidCastException();
			}
			num = maxSequences;
			int num2 = maxSequences - 1;
			if (totSequences >= num2)
			{
				int num3 = maxTweeners;
				IncreaseCapacities(CapacityIncreaseMode.SequencesOnly);
				if (Debugger._logPriority >= 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
					string text = default(string);
					string text2 = default(string);
					string newValue = text + "/" + text2;
					string text3 = "Max Tweens reached: capacity has automatically been increased from #0 to #1. Use DOTween.SetTweensCapacity to set it manually at startup".Replace("#0", newValue);
					object obj = (isUnityEditor ? 1 : 0) + 8;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
					object obj2 = (isUnityEditor ? 1 : 0) + 12;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
					string text4 = default(string);
					string text5 = default(string);
					string newValue2 = text4 + "/" + text5;
					string message = text3.Replace("#1", newValue2);
					Debugger.LogWarning(message);
				}
			}
			Sequence sequence = new Sequence();
			num = totSequences;
			num++;
			totSequences = num;
			AddActiveTween(sequence);
			return sequence;
		}

		[Token(Token = "0x60002AF")]
		[Address(RVA = "0x10766D4", Offset = "0x10766D4", Length = "0x2DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1F02E10]);\n\tv27 = *([v26 @ X8_v60]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, updateType, isIndependentUpdate, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20269B8]) = v44;\nL_001A:\n\tv47 = ~t.<active>k__BackingField;\n\tif (v47) goto L_0029;\n\tv60 = t.updateType != updateType;\n\tif (v60) goto L_0037;\nL_0029:\n\tt.updateType = updateType;\n\tt.isIndependentUpdate = isIndependentUpdate;\nL_0032:\n\treturn;\nL_0037:\n\tv85 = t.updateType == 2;\n\tif (v85) goto L_0072;\n\tv172 = t.updateType == 1;\n\tif (v172) goto L_0094;\n\tv183 = t.updateType == 0;\n\tv184 = ~v183;\n\tif (v184) goto L_00B6;\n\tgoto L_0059;\n\tv296 = *([v218 @ X0_v30 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv297 = v296 == 0;\n\tv298 = ~v297;\n\tif (v298) goto L_0059;\n\tv323 = \"il2cpp_codegen_runtime_class_init\"(v218, updateType, isIndependentUpdate, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv299 = DG.Tweening.Core.TweenManager;\nL_0059:\n\tv303 = v301.totActiveDefaultTweens - 1;\n\tv301.totActiveDefaultTweens = v303;\n\tv278 = v293.totActiveDefaultTweens < 0;\n\tv275 = v293.totActiveDefaultTweens == 0;\n\tv269 = v293.totActiveDefaultTweens ^ v293.totActiveDefaultTweens;\n\tv266 = v293.totActiveDefaultTweens & v269;\n\tv263 = v266 < 0;\n\tv306 = v278 == v263;\n\tv255 = ~v275;\n\tv260 = v306 & v255;\n\tv293.hasActiveDefaultTweens = v260;\n\tgoto L_00D6;\nL_0072:\n\tgoto L_007B;\n\tv191 = *([v179 @ X0_v18 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv192 = v191 == 0;\n\tv193 = ~v192;\n\tif (v193) goto L_007B;\n\tv253 = \"il2cpp_codegen_runtime_class_init\"(v179, updateType, isIndependentUpdate, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv195 = DG.Tweening.Core.TweenManager;\nL_007B:\n\tv200 = v198.totActiveFixedTweens - 1;\n\tv198.totActiveFixedTweens = v200;\n\tv206 = v201.totActiveFixedTweens < 0;\n\tv207 = v201.totActiveFixedTweens == 0;\n\tv209 = v201.totActiveFixedTweens ^ v201.totActiveFixedTweens;\n\tv210 = v201.totActiveFixedTweens & v209;\n\tv211 = v210 < 0;\n\tv212 = v206 == v211;\n\tv213 = ~v207;\n\tv214 = v212 & v213;\n\tv201.hasActiveFixedTweens = v214;\n\tgoto L_00D6;\nL_0094:\n\tgoto L_009D;\n\tv228 = *([v187 @ X0_v22 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv229 = v228 == 0;\n\tv230 = ~v229;\n\tif (v230) goto L_009D;\n\tv318 = \"il2cpp_codegen_runtime_class_init\"(v187, updateType, isIndependentUpdate, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv232 = DG.Tweening.Core.TweenManager;\nL_009D:\n\tv237 = v235.totActiveLateTweens - 1;\n\tv235.totActiveLateTweens = v237;\n\tv243 = v238.totActiveLateTweens < 0;\n\tv244 = v238.totActiveLateTweens == 0;\n\tv246 = v238.totActiveLateTweens ^ v238.totActiveLateTweens;\n\tv247 = v238.totActiveLateTweens & v246;\n\tv248 = v247 < 0;\n\tv249 = v243 == v248;\n\tv250 = ~v244;\n\tv251 = v249 & v250;\n\tv238.hasActiveLateTweens = v251;\n\tgoto L_00D6;\nL_00B6:\n\tgoto L_00BF;\n\tv307 = *([v224 @ X0_v26 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv308 = v307 == 0;\n\tv309 = ~v308;\n\tif (v309) goto L_00BF;\n\tv324 = \"il2cpp_codegen_runtime_class_init\"(v224, updateType, isIndependentUpdate, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv310 = DG.Tweening.Core.TweenManager;\nL_00BF:\n\tv314 = v312.totActiveManualTweens - 1;\n\tv312.totActiveManualTweens = v314;\n\tv277 = v292.totActiveManualTweens < 0;\n\tv274 = v292.totActiveManualTweens == 0;\n\tv268 = v292.totActiveManualTweens ^ v292.totActiveManualTweens;\n\tv265 = v292.totActiveManualTweens & v268;\n\tv262 = v265 < 0;\n\tv317 = v277 == v262;\n\tv254 = ~v274;\n\tv259 = v317 & v254;\n\tv292.hasActiveManualTweens = v259;\nL_00D6:\n\tv115 = updateType == 2;\n\tt.updateType = updateType;\n\tt.isIndependentUpdate = isIndependentUpdate;\n\tif (v115) goto L_0102;\n\tv114 = updateType == 1;\n\tif (v114) goto L_0116;\n\tv325 = updateType == 0;\n\tv326 = ~v325;\n\tif (v326) goto L_012A;\n\tgoto L_00F9;\n\tv355 = *([v285 @ X0_v5 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv356 = v355 == 0;\n\tv357 = ~v356;\n\tif (v357) goto L_00F9;\n\tv375 = \"il2cpp_codegen_runtime_class_init\"(v285, updateType, isIndependentUpdate, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv358 = DG.Tweening.Core.TweenManager;\nL_00F9:\n\tv363 = v361.totActiveDefaultTweens + 1;\n\tv361.totActiveDefaultTweens = v363;\n\tv136.hasActiveDefaultTweens = 1;\n\tgoto L_0032;\nL_0102:\n\tgoto L_010D;\n\tv330 = *([v285 @ X0_v5 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv331 = v330 == 0;\n\tv332 = ~v331;\n\tif (v332) goto L_010D;\n\tv354 = \"il2cpp_codegen_runtime_class_init\"(v285, updateType, isIndependentUpdate, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv333 = DG.Tweening.Core.TweenManager;\nL_010D:\n\tv338 = v336.totActiveFixedTweens + 1;\n\tv336.totActiveFixedTweens = v338;\n\tv137.hasActiveFixedTweens = 1;\n\tgoto L_0032;\nL_0116:\n\tgoto L_0121;\n\tv345 = *([v285 @ X0_v5 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv346 = v345 == 0;\n\tv347 = ~v346;\n\tif (v347) goto L_0121;\n\tv373 = \"il2cpp_codegen_runtime_class_init\"(v285, updateType, isIndependentUpdate, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv348 = DG.Tweening.Core.TweenManager;\nL_0121:\n\tv353 = v351.totActiveLateTweens + 1;\n\tv351.totActiveLateTweens = v353;\n\tv138.hasActiveLateTweens = 1;\n\tgoto L_0032;\nL_012A:\n\tgoto L_0135;\n\tv364 = *([v285 @ X0_v5 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv365 = v364 == 0;\n\tv366 = ~v365;\n\tif (v366) goto L_0135;\n\tv376 = \"il2cpp_codegen_runtime_class_init\"(v285, updateType, isIndependentUpdate, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv367 = DG.Tweening.Core.TweenManager;\nL_0135:\n\tv372 = v370.totActiveManualTweens + 1;\n\tv370.totActiveManualTweens = v372;\n\tv139.hasActiveManualTweens = 1;\n\tgoto L_0032;\n\tthrow System.NullReferenceException;\n\treturn;\n// 168 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void SetUpdateType(Tween t, UpdateType updateType, bool isIndependentUpdate)
		{
			if (!t.active || t.updateType == updateType)
			{
				t.updateType = updateType;
				t.isIndependentUpdate = isIndependentUpdate;
				return;
			}
			if (t.updateType != UpdateType.Fixed)
			{
				if (t.updateType != UpdateType.Late)
				{
					if (t.updateType == UpdateType.Normal)
					{
						int num = totActiveDefaultTweens - 1;
						totActiveDefaultTweens = num;
						bool flag = totActiveDefaultTweens < 0;
						bool flag2 = totActiveDefaultTweens == 0;
						int num2 = totActiveDefaultTweens ^ totActiveDefaultTweens;
						int num3 = totActiveDefaultTweens & num2;
						bool flag3 = num3 < 0;
						bool flag4 = flag == flag3;
						bool flag5 = !flag2;
						bool flag6 = flag4 && flag5;
						hasActiveDefaultTweens = flag6;
					}
					else
					{
						int num4 = totActiveManualTweens - 1;
						totActiveManualTweens = num4;
						bool flag7 = totActiveManualTweens < 0;
						bool flag8 = totActiveManualTweens == 0;
						int num5 = totActiveManualTweens ^ totActiveManualTweens;
						int num6 = totActiveManualTweens & num5;
						bool flag9 = num6 < 0;
						bool flag10 = flag7 == flag9;
						bool flag11 = !flag8;
						bool flag12 = flag10 && flag11;
						hasActiveManualTweens = flag12;
					}
				}
				else
				{
					int num7 = totActiveLateTweens - 1;
					totActiveLateTweens = num7;
					bool flag13 = totActiveLateTweens < 0;
					bool flag14 = totActiveLateTweens == 0;
					int num8 = totActiveLateTweens ^ totActiveLateTweens;
					int num9 = totActiveLateTweens & num8;
					bool flag15 = num9 < 0;
					bool flag16 = flag13 == flag15;
					bool flag17 = !flag14;
					bool flag18 = flag16 && flag17;
					hasActiveLateTweens = flag18;
				}
			}
			else
			{
				int num10 = totActiveFixedTweens - 1;
				totActiveFixedTweens = num10;
				bool flag19 = totActiveFixedTweens < 0;
				bool flag20 = totActiveFixedTweens == 0;
				int num11 = totActiveFixedTweens ^ totActiveFixedTweens;
				int num12 = totActiveFixedTweens & num11;
				bool flag21 = num12 < 0;
				bool flag22 = flag19 == flag21;
				bool flag23 = !flag20;
				bool flag24 = flag22 && flag23;
				hasActiveFixedTweens = flag24;
			}
			bool flag25 = updateType == UpdateType.Fixed;
			t.updateType = updateType;
			t.isIndependentUpdate = isIndependentUpdate;
			if (!flag25)
			{
				switch (updateType)
				{
				case UpdateType.Normal:
				{
					int num15 = totActiveDefaultTweens + 1;
					totActiveDefaultTweens = num15;
					hasActiveDefaultTweens = true;
					break;
				}
				case UpdateType.Late:
				{
					int num14 = totActiveLateTweens + 1;
					totActiveLateTweens = num14;
					hasActiveLateTweens = true;
					break;
				}
				default:
				{
					int num13 = totActiveManualTweens + 1;
					totActiveManualTweens = num13;
					hasActiveManualTweens = true;
					break;
				}
				}
			}
			else
			{
				int num16 = totActiveFixedTweens + 1;
				totActiveFixedTweens = num16;
				hasActiveFixedTweens = true;
			}
		}

		[Token(Token = "0x60002B0")]
		[Address(RVA = "0x10769B0", Offset = "0x10769B0", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED7B98]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20269B9]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tDG.Tweening.Core.TweenManager::RemoveActiveTween(t);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void AddActiveTweenToSequence(Tween t)
		{
			RemoveActiveTween(t);
		}

		[Token(Token = "0x60002B1")]
		[Address(RVA = "0x1076F34", Offset = "0x1076F34", Length = "0x220")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EBE870]);\n\tv21 = *([v20 @ X8_v35]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([20269BA]) = v41;\nL_001A:\n\tgoto L_FFFFFFFF;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_FFFFFFFF;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v44, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv52 = DG.Tweening.Core.TweenManager;\n\tgoto L_0053;\nL_0027:\n\tgoto L_002F;\n\tv146 = *([v115 @ X0_v5 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv147 = v146 == 0;\n\tv148 = ~v147;\n\tif (v148) goto L_002F;\n\tv177 = \"il2cpp_codegen_runtime_class_init\"(v115, v67, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv151 = DG.Tweening.Core.TweenManager;\n\tv154 = *([v151 @ X0_v29+B8]);\nL_002F:\n\tv155 = v153._activeTweens;\n\tv178 = v62 < v155.Length;\n\tv96 = ~v178;\n\tif (v96) goto L_00BD;\n\tv214 = v155[v62 @ X22_v2 (System.Int32)] == 0;\n\tif (v214) goto L_004F;\n\tgoto L_004D;\n\tv268 = *([v150 @ X0_v17 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv269 = v268 == 0;\n\tv270 = ~v269;\n\tif (v270) goto L_004D;\n\tv272 = \"il2cpp_codegen_runtime_class_init\"(v150, v67, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_004D:\n\tDG.Tweening.Core.TweenManager::Despawn(v155[v62 @ X22_v2 (System.Int32)], 0);\nL_004F:\n\tv62 = v62 + 1;\nL_0053:\n\tgoto L_005D;\n\tv110 = *([v101 @ X0_v4 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv111 = v110 == 0;\n\tv112 = ~v111;\n\tgoto L_005D;\n\tv131 = \"il2cpp_codegen_runtime_class_init\"(v101, v67, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv116 = DG.Tweening.Core.TweenManager;\n\tv114 = *([v116 @ X0_v32+12E]);\nL_005D:\n\tv65 = v119._maxActiveLookupId + 1;\n\tv60 = v62 < v65;\n\tif (v60) goto L_0027;\n\tgoto L_0075;\n\tv136 = *([v115 @ X0_v5 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv137 = v136 == 0;\n\tv138 = ~v137;\n\tif (v138) goto L_0075;\n\tv141 = \"il2cpp_codegen_runtime_class_init\"(v115, v67, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv181 = DG.Tweening.Core.TweenManager;\n\tv144 = *([v181 @ X8_v21+B8]);\nL_0075:\n\tDG.Tweening.Core.TweenManager::ClearTweenArray(v143._activeTweens);\n\tv159.hasActiveManualTweens = 0;\n\tv160.hasActiveFixedTweens = 0;\n\tv161.hasActiveLateTweens = 0;\n\tv162.hasActiveDefaultTweens = 0;\n\tv163.hasActiveTweens = 0;\n\tv164.totActiveManualTweens = 0;\n\tv165.totActiveFixedTweens = 0;\n\tv166.totActiveLateTweens = 0;\n\tv167.totActiveDefaultTweens = 0;\n\tv168.totActiveTweens = 0;\n\tv169.totActiveSequences = 0;\n\tv170.totActiveTweeners = 0;\n\tv171._reorganizeFromId = 0xFFFFFFFF;\n\tv172._maxActiveLookupId = 0xFFFFFFFF;\n\tv173._requiresActiveReorganization = 0;\n\tSystem.Collections.Generic.Dictionary`2<DG.Tweening.Tween, DG.Tweening.Core.TweenLink>::Clear(v174._TweenLinks);\n\tv218._totTweenLinks = 0;\n\tv221 = ~v219.isUpdateLoop;\n\tif (v221) goto L_00BA;\n\tgoto L_00B1;\n\tv274 = *([v217 @ X0_v11 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv275 = v274 == 0;\n\tv276 = ~v275;\n\tif (v276) goto L_00B1;\n\tv278 = \"il2cpp_codegen_runtime_class_init\"(v217, v184, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv280 = DG.Tweening.Core.TweenManager;\n\tv279 = *([v280 @ X8_v19+B8]);\nL_00B1:\n\tv239._despawnAllCalledFromUpdateLoopCallback = 1;\nL_00BA:\n\treturn v55.totActiveTweens;\n\tv180 = new System.NullReferenceException();\nL_00BD:\n\tv216 = new System.IndexOutOfRangeException();\n\tthrow v216;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 105 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int DespawnAll()
		{
			int num = 0;
			while (true)
			{
				int num2 = _maxActiveLookupId + 1;
				if (num >= num2)
				{
					break;
				}
				Tween[] activeTweens = _activeTweens;
				if (num < activeTweens.Length)
				{
					if (activeTweens[num] != null)
					{
						Despawn(activeTweens[num], modifyActiveLists: false);
					}
					num++;
					continue;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			ClearTweenArray(_activeTweens);
			hasActiveManualTweens = false;
			hasActiveFixedTweens = false;
			hasActiveLateTweens = false;
			hasActiveDefaultTweens = false;
			hasActiveTweens = false;
			totActiveManualTweens = 0;
			totActiveFixedTweens = 0;
			totActiveLateTweens = 0;
			totActiveDefaultTweens = 0;
			totActiveTweens = 0;
			totActiveSequences = 0;
			totActiveTweeners = 0;
			_reorganizeFromId = -1;
			_maxActiveLookupId = -1;
			_requiresActiveReorganization = false;
			_TweenLinks.Clear();
			_totTweenLinks = 0;
			if (isUpdateLoop)
			{
				_despawnAllCalledFromUpdateLoopCallback = true;
			}
			return totActiveTweens;
		}

		[Token(Token = "0x60002B2")]
		[Address(RVA = "0x1077154", Offset = "0x1077154", Length = "0x574")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1F021D0]);\n\tv27 = *([v26 @ X8_v102]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, modifyActiveLists, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([20269BB]) = v45;\nL_001A:\n\tv48 = t.onKill == 0;\n\tif (v48) goto L_001F;\n\tv206 = DG.Tweening.Tween::OnTweenCallback(t.onKill);\nL_001F:\n\tv209 = modifyActiveLists == 0;\n\tif (v209) goto L_0031;\n\tgoto L_002E;\n\tv323 = *([v263 @ X0_v93+E0]);\n\tv324 = v323 == 0;\n\tv325 = ~v324;\n\tif (v325) goto L_002E;\n\tv327 = \"il2cpp_codegen_runtime_class_init\"(v263, v167, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_002E:\n\tDG.Tweening.Core.TweenManager::RemoveActiveTween(t);\nL_0031:\n\tv275 = ~t.isRecyclable;\n\tif (v275) goto L_00AB;\n\tv328 = t.tweenType == 0;\n\tif (v328) goto L_011F;\n\tv365 = t.tweenType != 1;\n\tif (v365) goto L_0260;\n\tgoto L_0055;\n\tv524 = *([v412 @ X0_v81 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv525 = v524 == 0;\n\tv526 = ~v525;\n\t// 74 ConditionalJump @b120, v526 @ TEMP_v126\n\tv556 = \"il2cpp_codegen_runtime_class_init\"(v412, v167, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv528 = DG.Tweening.Core.TweenManager;\nL_0055:\n\tSystem.Collections.Generic.Stack`1<DG.Tweening.Tween>::Push(v408._PooledSequences, t);\n\tv154 = v586.totPooledSequences + 1;\n\tv586.totPooledSequences = v154;\n\tv74 = *([t @ X0 (DG.Tweening.Tween)]) != DG.Tweening.Sequence;\n\tif (v74) goto L_0275;\n\tv747 = *([t @ X0 (DG.Tweening.Tween)+118]);\n\tv429 = *([v747 @ X20_v19+18]) < 1;\n\tif (v429) goto L_0260;\nL_007C:\n\tv750 = v733 < *([v747 @ X20_v19+18]);\n\tv751 = ~v750;\n\tv759 = ~v751;\n\tif (v759) goto L_008B;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_008B:\n\tv54 = v733 << 3;\n\tv777 = *([v747 @ X20_v19+10]) + v54;\n\tgoto L_0099;\n\tv790 = *([v776 @ X0_v86+E0]);\n\tv791 = v790 == 0;\n\tv792 = ~v791;\n\tif (v792) goto L_0099;\n\tv794 = \"il2cpp_codegen_runtime_class_init\"(v776, v744, v72, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0099:\n\tDG.Tweening.Core.TweenManager::Despawn(*([v777 @ X8_v92+20]), 0);\n\tv733 = v733 + 1;\n\tv75 = v733 >= *([v747 @ X20_v19+18]);\n\tif (v75) goto L_0260;\n\tv747 = *([t @ X0 (DG.Tweening.Tween)+118]);\n\tv811 = *([t @ X0 (DG.Tweening.Tween)+118]) == 0;\n\tv178 = ~v811;\n\tif (v178) goto L_007C;\n\tgoto L_026F;\nL_00AB:\n\tv329 = t.tweenType == 0;\n\tif (v329) goto L_01A7;\n\tv380 = t.tweenType != 1;\n\tif (v380) goto L_0260;\n\tgoto L_00C9;\n\tv546 = *([v511 @ X0_v25 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv547 = v546 == 0;\n\tv548 = ~v547;\n\tif (v548) goto L_00C9;\n\tv583 = \"il2cpp_codegen_runtime_class_init\"(v511, v167, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv549 = DG.Tweening.Core.TweenManager;\nL_00C9:\n\tv156 = v551.totSequences - 1;\n\tv551.totSequences = v156;\n\tv76 = *([t @ X0 (DG.Tweening.Tween)]) != DG.Tweening.Sequence;\n\tif (v76) goto L_0275;\n\tv698 = *([t @ X0 (DG.Tweening.Tween)+118]);\n\tv430 = *([v698 @ X20_v13+18]) < 1;\n\tif (v430) goto L_0260;\nL_00EA:\n\tv701 = v684 < *([v698 @ X20_v13+18]);\n\tv702 = ~v701;\n\tv710 = ~v702;\n\tif (v710) goto L_00F9;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00F9:\n\tv55 = v684 << 3;\n\tv729 = *([v698 @ X20_v13+10]) + v55;\n\tgoto L_0107;\n\tv768 = *([v728 @ X0_v29+E0]);\n\tv769 = v768 == 0;\n\tv770 = ~v769;\n\tif (v770) goto L_0107;\n\tv772 = \"il2cpp_codegen_runtime_class_init\"(v728, v695, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0107:\n\tDG.Tweening.Core.TweenManager::Despawn(*([v729 @ X8_v24+20]), 0);\n\tv684 = v684 + 1;\n\tv77 = v684 >= *([v698 @ X20_v13+18]);\n\tif (v77) goto L_0260;\n\tv698 = *([t @ X0 (DG.Tweening.Tween)+118]);\n\tv798 = *([t @ X0 (DG.Tweening.Tween)+118]) == 0;\n\tv180 = ~v798;\n\tif (v180) goto L_00EA;\n\tgoto L_026F;\nL_011F:\n\tgoto L_0128;\n\tv495 = *([v367 @ X0_v36 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv496 = v495 == 0;\n\tv497 = ~v496;\n\tif (v497) goto L_0128;\n\tv531 = \"il2cpp_codegen_runtime_class_init\"(v367, v167, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv499 = DG.Tweening.Core.TweenManager;\nL_0128:\n\tv504 = v502._maxPooledTweenerId + 1;\n\tv506 = v504 == 0;\n\tv509 = ~v506;\n\tif (v509) goto L_0144;\n\tgoto L_013B;\n\tv560 = *([v498 @ X0_v37 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv561 = v560 == 0;\n\tv562 = ~v561;\n\tif (v562) goto L_013B;\n\tv589 = \"il2cpp_codegen_runtime_class_init\"(v498, v167, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv564 = DG.Tweening.Core.TweenManager;\n\tv566 = *([v564 @ X0_v78+B8]);\nL_013B:\n\tv568 = v565.maxTweeners - 1;\n\tv565._maxPooledTweenerId = v568;\n\tv536 = v542.maxTweeners - 1;\n\tv542._minPooledTweenerId = v536;\nL_0144:\n\tgoto L_014E;\n\tv570 = *([v537 @ X0_v38 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv571 = v570 == 0;\n\tv572 = ~v571;\n\tgoto L_014E;\n\tv590 = \"il2cpp_codegen_runtime_class_init\"(v537, v167, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv575 = DG.Tweening.Core.TweenManager;\n\tv578 = *([v575 @ X0_v75+12E]);\nL_014E:\n\tv201 = v579._maxPooledTweenerId;\n\tv69 = v579.maxTweeners - 1;\n\tv80 = v579._maxPooledTweenerId >= v69;\n\tif (v80) goto L_01B5;\n\tgoto L_0166;\n\tv597 = *([v574 @ X0_v39 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv598 = v597 == 0;\n\tv599 = ~v598;\n\tif (v599) goto L_0166;\n\tv601 = \"il2cpp_codegen_runtime_class_init\"(v574, v167, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv603 = DG.Tweening.Core.TweenManager;\n\tv600 = *([v603 @ X8_v75+B8]);\n\tv604 = *([v600 @ X9_v40+84]);\nL_0166:\n\tv65 = v160._pooledTweeners;\n\t// 364 IsInst v249 @ X0_v68, typeof(DG.Tweening.Tween), t @ X0 (DG.Tweening.Tween)\n\tv252 = v249 == 0;\n\tif (v252) goto L_0277;\n\tv256 = v579._maxPooledTweenerId + 1;\n\tv65[v256 @ X8_v68 (System.Int32)] = t;\n\tv783 = v781._maxPooledTweenerId + 1;\n\tv781._maxPooledTweenerId = v783;\n\tv633 = v676._minPooledTweenerId <= v676._maxPooledTweenerId;\n\tif (v633) goto L_0255;\n\tgoto L_019F;\n\tv800 = *([v666 @ X0_v69 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv801 = v800 == 0;\n\tv802 = ~v801;\n\tif (v802) goto L_019F;\n\tv812 = \"il2cpp_codegen_runtime_class_init\"(v666, v246, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv804 = DG.Tweening.Core.TweenManager;\n\tv805 = *([v804 @ X0_v72+B8]);\n\tv803 = *([v805 @ X8_v73+84]);\nL_019F:\n\tv677._minPooledTweenerId = v676._maxPooledTweenerId;\n\tgoto L_0255;\nL_01A7:\n\tgoto L_01B0;\n\tv515 = *([v383 @ X0_v21 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv516 = v515 == 0;\n\tv517 = ~v516;\n\tif (v517) goto L_01B0;\n\tv555 = \"il2cpp_codegen_runtime_class_init\"(v383, v167, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv518 = DG.Tweening.Core.TweenManager;\nL_01B0:\n\tv465 = v481.totTweeners - 1;\n\tv481.totTweeners = v465;\n\tgoto L_0260;\nL_01B5:\n\tgoto L_01BE;\n\tv605 = *([v574 @ X0_v39 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv606 = v605 == 0;\n\tv607 = ~v606;\n\tif (v607) goto L_01BE;\n\tv622 = \"il2cpp_codegen_runtime_class_init\"(v574, v167, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv609 = DG.Tweening.Core.TweenManager;\n\tv612 = *([v609 @ X0_v65+B8]);\n\tv614 = *([v612 @ X8_v65+84]);\nL_01BE:\n\tv615 = v579._maxPooledTweenerId & 0x80000000;\n\tv616 = v615 == 0;\n\tv617 = ~v616;\n\tif (v617) goto L_0255;\n\tv64 = v579._maxPooledTweenerId + 4;\nL_01C7:\n\tgoto L_01CF;\n\tv761 = *([v713 @ X0_v45 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv762 = v761 == 0;\n\tv763 = ~v762;\n\tgoto L_01CF;\n\tv787 = \"il2cpp_codegen_runtime_class_init\"(v713, v167, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv764 = DG.Tweening.Core.TweenManager;\nL_01CF:\n\tv213 = v197._pooledTweeners;\n\tv257 = v64 - 4;\n\tv671 = *([v213 @ X23_v15 (DG.Tweening.Tween[])+v64 @ X22_v12 (System.Int32)*8]) == 0;\n\tif (v671) goto L_01F4;\n\tv64 = v64 - 1;\n\tv201 = v201 - 1;\n\tv634 = v257 > 0;\n\tif (v634) goto L_01C7;\n\tgoto L_0255;\nL_01F4:\n\tgoto L_0202;\n\tv813 = *([v175 @ X0_v46 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv814 = v813 == 0;\n\tv815 = ~v814;\n\tif (v815) goto L_0202;\n\tv820 = DG.T\n// ... truncated")]
		internal static void Despawn(Tween t, bool modifyActiveLists = true)
		{
			//IL_056e: Expected I, but got O
			//IL_058c: Expected O, but got I
			//IL_059c: Expected O, but got I
			//IL_01a0: Expected O, but got I
			//IL_01bb: Expected O, but got I
			//IL_0291: Expected O, but got I
			//IL_0752: Expected I4, but got I8
			//IL_0200: Expected O, but got I
			//IL_013a: Expected O, but got I
			//IL_02f7: Expected O, but got I
			//IL_0312: Expected O, but got I
			//IL_0357: Expected O, but got I
			if (t.onKill != null)
			{
				bool flag = Tween.OnTweenCallback(t.onKill);
			}
			if (modifyActiveLists)
			{
				RemoveActiveTween(t);
			}
			int num7 = default(int);
			if (t.isRecyclable)
			{
				if (t.tweenType == TweenType.Tweener)
				{
					if (_maxPooledTweenerId + 1 == 0)
					{
						int maxPooledTweenerId = maxTweeners - 1;
						_maxPooledTweenerId = maxPooledTweenerId;
						int minPooledTweenerId = maxTweeners - 1;
						_minPooledTweenerId = minPooledTweenerId;
					}
					int num = _maxPooledTweenerId;
					int num2 = maxTweeners - 1;
					if (_maxPooledTweenerId < num2)
					{
						Tween[] pooledTweeners = _pooledTweeners;
						object obj = t as Tween;
						if (obj == null)
						{
							goto IL_0558;
						}
						int num3 = _maxPooledTweenerId + 1;
						pooledTweeners[num3] = t;
						int maxPooledTweenerId2 = _maxPooledTweenerId + 1;
						_maxPooledTweenerId = maxPooledTweenerId2;
						if (_minPooledTweenerId > _maxPooledTweenerId)
						{
							_minPooledTweenerId = _maxPooledTweenerId;
						}
					}
					else if ((int)(_maxPooledTweenerId & 0x80000000L) == 0)
					{
						int num4 = _maxPooledTweenerId + 4;
						while (true)
						{
							Tween[] pooledTweeners2 = _pooledTweeners;
							int num5 = num4 - 4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ X23_v15 (DG.Tweening.Tween[])+v64 @ X22_v12 (System.Int32)*8]");
							if ((IntPtr)0 != (IntPtr)0)
							{
								num4--;
								num--;
								if (num5 <= 0)
								{
									goto IL_07d0;
								}
								continue;
							}
							break;
						}
						object obj2 = t as Tween;
						if (obj2 == null)
						{
							goto IL_0558;
						}
						if (_minPooledTweenerId > num)
						{
							_minPooledTweenerId = num;
						}
						if (_maxPooledTweenerId < _minPooledTweenerId)
						{
							_maxPooledTweenerId = _minPooledTweenerId;
						}
					}
					goto IL_07d0;
				}
				if (t.tweenType == TweenType.Sequence)
				{
					_PooledSequences.Push(t);
					int num6 = totPooledSequences + 1;
					totPooledSequences = num6;
					if ((object)t.GetType() != typeof(Sequence))
					{
						goto IL_053c;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Tween)+118]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v747 @ X20_v19+18]");
					if (0L >= 1L)
					{
						num7 = 0;
						goto IL_05a6;
					}
				}
			}
			else if (t.tweenType != TweenType.Tweener)
			{
				if (t.tweenType == TweenType.Sequence)
				{
					int num8 = totSequences - 1;
					totSequences = num8;
					if ((object)t.GetType() != typeof(Sequence))
					{
						goto IL_053c;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Tween)+118]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v698 @ X20_v13+18]");
					if (0L >= 1L)
					{
						int num9 = 0;
						while (true)
						{
							int num10 = num9;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v698 @ X20_v13+18]");
							if ((long)num10 >= 0L)
							{
								throw new ArgumentOutOfRangeException();
							}
							int num11 = num9 << 3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v698 @ X20_v13+10]");
							object obj5 = 0L + (long)num11;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v729 @ X8_v24+20]");
							Despawn((Tween)0, modifyActiveLists: false);
							num9++;
							int num12 = num9;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v698 @ X20_v13+18]");
							if ((long)num12 >= 0L)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Tween)+118]");
							obj4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Tween)+118]");
							if ((IntPtr)0 != (IntPtr)0)
							{
								continue;
							}
							goto IL_051a;
						}
					}
				}
			}
			else
			{
				int num13 = totTweeners - 1;
				totTweeners = num13;
			}
			goto IL_0566;
			IL_0558:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			goto IL_0536;
			IL_053c:
			InvalidCastException ex2 = new InvalidCastException();
			NullReferenceException ex3 = new NullReferenceException();
			goto IL_0558;
			IL_05a6:
			while (true)
			{
				int num14 = num7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v747 @ X20_v19+18]");
				if ((long)num14 >= 0L)
				{
					throw new ArgumentOutOfRangeException();
				}
				int num15 = num7 << 3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v747 @ X20_v19+10]");
				object obj6 = 0L + (long)num15;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v777 @ X8_v92+20]");
				Despawn((Tween)0, modifyActiveLists: false);
				num7++;
				int num16 = num7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v747 @ X20_v19+18]");
				if ((long)num16 >= 0L)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Tween)+118]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Tween)+118]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					continue;
				}
				goto IL_051a;
			}
			goto IL_0566;
			IL_07d0:
			int num17 = totPooledTweeners + 1;
			totPooledTweeners = num17;
			goto IL_0566;
			IL_0536:
			throw new TypeLoadException();
			IL_0566:
			IntPtr intPtr = (IntPtr)t;
			t.active = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v484 @ X8_v12 (Il2CppClass<DG.Tweening.Tween>)+170]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v484 @ X8_v12 (Il2CppClass<DG.Tweening.Tween>)+178]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v488 @ X2_v9 (should have been resolved before IL gen)");
			goto IL_05a6;
			IL_051a:
			NullReferenceException ex4 = new NullReferenceException();
			IndexOutOfRangeException ex5 = new IndexOutOfRangeException();
			goto IL_0536;
		}

		[Token(Token = "0x60002B3")]
		[Address(RVA = "0x107772C", Offset = "0x107772C", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv16 = *([1EBC5B8]);\n\tv17 = *([v16 @ X8_v22]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20269BC]) = v37;\n\tgoto L_0041;\nL_0018:\n\tgoto L_0020;\n\tv126 = *([v96 @ X0_v4 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv127 = v126 == 0;\n\tv128 = ~v127;\n\tif (v128) goto L_0020;\n\tv131 = \"il2cpp_codegen_runtime_class_init\"(v96, v49, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv159 = DG.Tweening.Core.TweenManager;\n\tv134 = *([v159 @ X8_v17+B8]);\nL_0020:\n\tv135 = v133._activeTweens;\n\tv155 = v47 < v135.Length;\n\tv76 = ~v155;\n\tif (v76) goto L_0092;\n\tv86 = v135[v47 @ X20_v2 (System.Int32)];\n\tv161 = v135[v47 @ X20_v2 (System.Int32)] == 0;\n\tif (v161) goto L_003C;\n\tv181 = ~v86.<active>k__BackingField;\n\tif (v181) goto L_003C;\n\tv86.<active>k__BackingField = 0;\n\tv185 = v86.onKill == 0;\n\tif (v185) goto L_003C;\n\tv183 = DG.Tweening.Tween::OnTweenCallback(v86.onKill);\nL_003C:\n\tv47 = v47 + 1;\nL_0041:\n\tgoto L_0055;\n\tv91 = *([v87 @ X0_v3 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv92 = v91 == 0;\n\tv93 = ~v92;\n\tgoto L_0055;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v87, v49, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv97 = DG.Tweening.Core.TweenManager;\n\tv95 = *([v97 @ X0_v20+12E]);\nL_0055:\n\tv42 = v47 < v100.maxActive;\n\tif (v42) goto L_0018;\n\tgoto L_0062;\n\tv116 = *([v96 @ X0_v4 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv117 = v116 == 0;\n\tv118 = ~v117;\n\tif (v118) goto L_0062;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v96, v49, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv158 = DG.Tweening.Core.TweenManager;\n\tv124 = *([v158 @ X8_v11+B8]);\nL_0062:\n\tDG.Tweening.Core.TweenManager::ClearTweenArray(v123._activeTweens);\n\tv139.hasActiveManualTweens = 0;\n\tv140.hasActiveFixedTweens = 0;\n\tv141.hasActiveLateTweens = 0;\n\tv142.hasActiveDefaultTweens = 0;\n\tv143.hasActiveTweens = 0;\n\tv144.totActiveManualTweens = 0;\n\tv145.totActiveFixedTweens = 0;\n\tv146.totActiveLateTweens = 0;\n\tv147.totActiveDefaultTweens = 0;\n\tv148.totActiveTweens = 0;\n\tv149.totActiveSequences = 0;\n\tv150.totActiveTweeners = 0;\n\tv151._reorganizeFromId = 0xFFFFFFFF;\n\tv152._maxActiveLookupId = 0xFFFFFFFF;\n\tv153._requiresActiveReorganization = 0;\n\tDG.Tweening.Core.TweenManager::PurgePools();\n\tDG.Tweening.Core.TweenManager::ResetCapacities();\n\tv174.totSequences = 0;\n\tv175.totTweeners = 0;\n\treturn;\n\tv157 = new System.NullReferenceException();\nL_0092:\n\tv172 = new System.IndexOutOfRangeException();\n\tthrow v172;\n\treturn;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void PurgeAll()
		{
			for (int i = 0; i < maxActive; i++)
			{
				Tween[] activeTweens = _activeTweens;
				if (i < activeTweens.Length)
				{
					Tween tween = activeTweens[i];
					if (activeTweens[i] != null && tween.active)
					{
						tween.active = false;
						if (tween.onKill != null)
						{
							bool flag = Tween.OnTweenCallback(tween.onKill);
						}
					}
					continue;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			ClearTweenArray(_activeTweens);
			hasActiveManualTweens = false;
			hasActiveFixedTweens = false;
			hasActiveLateTweens = false;
			hasActiveDefaultTweens = false;
			hasActiveTweens = false;
			totActiveManualTweens = 0;
			totActiveFixedTweens = 0;
			totActiveLateTweens = 0;
			totActiveDefaultTweens = 0;
			totActiveTweens = 0;
			totActiveSequences = 0;
			totActiveTweeners = 0;
			_reorganizeFromId = -1;
			_maxActiveLookupId = -1;
			_requiresActiveReorganization = false;
			PurgePools();
			ResetCapacities();
			totSequences = 0;
			totTweeners = 0;
		}

		[Token(Token = "0x60002B4")]
		[Address(RVA = "0x10778D4", Offset = "0x10778D4", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF64F0]);\n\tv15 = *([v14 @ X8_v17]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20269BD]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = DG.Tweening.Core.TweenManager;\nL_0021:\n\tv52 = v49.totTweeners - v49.totPooledTweeners;\n\tv49.totTweeners = v52;\n\tv56 = v53.totSequences - v53.totPooledSequences;\n\tv53.totSequences = v56;\n\tDG.Tweening.Core.TweenManager::ClearTweenArray(v57._pooledTweeners);\n\tSystem.Collections.Generic.Stack`1<DG.Tweening.Tween>::Clear(v61._PooledSequences);\n\tv70.totPooledSequences = 0;\n\tv71.totPooledTweeners = 0;\n\tv72._maxPooledTweenerId = 0xFFFFFFFF;\n\tv73._minPooledTweenerId = 0xFFFFFFFF;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void PurgePools()
		{
			int num = totTweeners - totPooledTweeners;
			totTweeners = num;
			int num2 = totSequences - totPooledSequences;
			totSequences = num2;
			ClearTweenArray(_pooledTweeners);
			_PooledSequences.Clear();
			totPooledSequences = 0;
			totPooledTweeners = 0;
			_maxPooledTweenerId = -1;
			_minPooledTweenerId = -1;
		}

		[Token(Token = "0x60002B5")]
		[Address(RVA = "0x1077A18", Offset = "0x1077A18", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1ECA050]);\n\tv23 = *([v22 @ X8_v35]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, tweenLink, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20269BE]) = v41;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v44, tweenLink, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv52 = DG.Tweening.Core.TweenManager;\nL_0024:\n\tv57 = v55._totTweenLinks + 1;\n\tv55._totTweenLinks = v57;\n\tv66 = System.Collections.Generic.Dictionary`2<DG.Tweening.Tween, DG.Tweening.Core.TweenLink>::ContainsKey(v58._TweenLinks, t);\n\tv85 = v66 == 0;\n\tif (v85) goto L_004E;\n\tgoto L_0047;\n\tv109 = *([v82 @ X8_v11 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv110 = v109 == 0;\n\tv111 = ~v110;\n\t// 58 ConditionalJump @b42, v111 @ TEMP_v38\n\tv210 = v82;\n\tv113 = \"il2cpp_codegen_runtime_class_init\"(v210, v64, v65, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv116 = DG.Tweening.Core.TweenManager;\nL_0047:\n\tSystem.Collections.Generic.Dictionary`2<DG.Tweening.Tween, DG.Tweening.Core.TweenLink>::set_Item(v79._TweenLinks, t, tweenLink);\n\tv214 = tweenLink == 0;\n\tv98 = ~v214;\n\tif (v98) goto L_0064;\n\tgoto L_00AE;\nL_004E:\n\tgoto L_005F;\n\tv117 = *([v82 @ X8_v11 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv118 = v117 == 0;\n\tv119 = ~v118;\n\t// 82 ConditionalJump @b43, v119 @ TEMP_v30\n\tv212 = v82;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v212, v64, v65, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv124 = DG.Tweening.Core.TweenManager;\nL_005F:\n\tSystem.Collections.Generic.Dictionary`2<DG.Tweening.Tween, DG.Tweening.Core.TweenLink>::Add(v80._TweenLinks, t, tweenLink);\nL_0064:\n\tv189 = ~tweenLink.lastSeenActive;\n\tif (v189) goto L_0086;\n\tv219 = tweenLink.behaviour - 1;\n\tv220 = v219 < 3;\n\tv170 = ~v220;\n\tv165 = v219 - 3;\n\tv155 = v165 == 0;\n\tv221 = ~v155;\n\tv130 = v170 & v221;\n\tif (v130) goto L_00AB;\n\tgoto L_0084;\n\tv232 = *([v224 @ X0_v17+E0]);\n\tv233 = v232 == 0;\n\tv234 = ~v233;\n\tif (v234) goto L_0084;\n\tv236 = \"il2cpp_codegen_runtime_class_init\"(v224, v181, v179, v175, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0084:\n\tv183 = DG.Tweening.Core.TweenManager::Play(t);\n\treturn;\nL_0086:\n\tv222 = tweenLink.behaviour < 2;\n\tv171 = ~v222;\n\tv166 = tweenLink.behaviour - 2;\n\tv156 = v166 == 0;\n\tv223 = ~v156;\n\tv131 = v171 & v223;\n\tif (v131) goto L_00AB;\n\tgoto L_00A3;\n\tv238 = *([v228 @ X0_v12+E0]);\n\tv239 = v238 == 0;\n\tv240 = ~v239;\n\tif (v240) goto L_00A3;\n\tv242 = \"il2cpp_codegen_runtime_class_init\"(v228, v181, v179, v175, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00A3:\n\tv184 = DG.Tweening.Core.TweenManager::Pause(t);\n\treturn;\nL_00AB:\n\treturn;\n\tthrow System.NullReferenceException;\nL_00AE:\n\tthrow System.NullReferenceException;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void AddTweenLink(Tween t, TweenLink tweenLink)
		{
			int totTweenLinks = _totTweenLinks + 1;
			_totTweenLinks = totTweenLinks;
			if (_TweenLinks.ContainsKey(t))
			{
				_TweenLinks.set_Item(t, tweenLink);
				if (tweenLink == null)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				_TweenLinks.Add(t, tweenLink);
			}
			if (tweenLink.lastSeenActive)
			{
				int num = (int)(tweenLink.behaviour - 1);
				bool flag = num < 3;
				bool flag2 = !flag;
				int num2 = num - 3;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					bool flag5 = Play(t);
				}
			}
			else
			{
				bool flag6 = tweenLink.behaviour < LinkBehaviour.PauseOnDisableRestartOnEnable;
				bool flag7 = !flag6;
				int num3 = (int)(tweenLink.behaviour - 2);
				bool flag8 = num3 == 0;
				bool flag9 = !flag8;
				if (!(flag7 && flag9))
				{
					bool flag10 = Pause(t);
				}
			}
		}

		[Token(Token = "0x60002B6")]
		[Address(RVA = "0x1077C94", Offset = "0x1077C94", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED6608]);\n\tv19 = *([v18 @ X8_v21]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20269BF]) = v38;\nL_0019:\n\tgoto L_0028;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\t// 29 Jump @b19\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = DG.Tweening.Core.TweenManager;\nL_0028:\n\tv60 = System.Collections.Generic.Dictionary`2<DG.Tweening.Tween, DG.Tweening.Core.TweenLink>::ContainsKey(v52._TweenLinks, t);\n\tv71 = v60 == 0;\n\tif (v71) goto L_004A;\n\tgoto L_003F;\n\tv102 = *([v72 @ X0_v9 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv103 = v102 == 0;\n\tv104 = ~v103;\n\t// 52 ConditionalJump @b21, v104 @ TEMP_v17\n\tv109 = \"il2cpp_codegen_runtime_class_init\"(v72, v58, v59, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv106 = DG.Tweening.Core.TweenManager;\nL_003F:\n\tv84 = System.Collections.Generic.Dictionary`2<DG.Tweening.Tween, DG.Tweening.Core.TweenLink>::Remove(v68._TweenLinks, t);\n\tv77 = v87._totTweenLinks - 1;\n\tv87._totTweenLinks = v77;\nL_004A:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void RemoveTweenLink(Tween t)
		{
			if (_TweenLinks.ContainsKey(t))
			{
				bool flag = _TweenLinks.Remove(t);
				int totTweenLinks = _totTweenLinks - 1;
				_totTweenLinks = totTweenLinks;
			}
		}

		[Token(Token = "0x60002B7")]
		[Address(RVA = "0x10779B4", Offset = "0x10779B4", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ED93C8]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20269C0]) = v35;\nL_0017:\n\tgoto L_0023;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0023;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0023:\n\tDG.Tweening.Core.TweenManager::SetCapacities(0xC8, 0x32);\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void ResetCapacities()
		{
			SetCapacities(200, 50);
		}

		[Token(Token = "0x60002B8")]
		[Address(RVA = "0x1070FAC", Offset = "0x1070FAC", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EC4318]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, sequencesCapacity, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20269C1]) = v41;\nL_0019:\n\tv46 = tweenersCapacity - sequencesCapacity;\n\tv47 = v46 < 0;\n\tv49 = tweenersCapacity ^ sequencesCapacity;\n\tv50 = tweenersCapacity ^ v46;\n\tv51 = v49 & v50;\n\tv52 = v51 < 0;\n\tv53 = v47 == v52;\n\tv54 = ~v53;\n\tv55 = ~v54;\n\tif (v55) goto L_FFFFFFFF;\n\tgoto L_002C;\nL_002C:\n\tgoto L_0034;\n\tv63 = *([v59 @ X0_v2 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tgoto L_0034;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v59, sequencesCapacity, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv67 = DG.Tweening.Core.TweenManager;\nL_0034:\n\tv71 = v58 + sequencesCapacity;\n\tv70.maxActive = v71;\n\tv72 = DG.Tweening.Core.TweenManager;\n\tv73.maxTweeners = v58;\n\tv74.maxSequences = sequencesCapacity;\n\tv80 = *([v72 @ X8_v6 (Il2CppClass<DG.Tweening.Core.TweenManager>)+B8]) + 0x48;\n\tSystem.Array::Resize(v80, v76.maxActive);\n\tv86 = v82.isUnityEditor + 0x50;\n\tSystem.Array::Resize(v86, v58);\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::set_Capacity(v88._KillList, v88.maxActive);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe static void SetCapacities(int tweenersCapacity, int sequencesCapacity)
		{
			//IL_00dc: Expected I, but got O
			int num = tweenersCapacity - sequencesCapacity;
			bool flag = num < 0;
			int num2 = tweenersCapacity ^ sequencesCapacity;
			int num3 = tweenersCapacity ^ num;
			int num4 = num2 & num3;
			bool flag2 = num4 < 0;
			int num5 = ((flag == flag2) ? tweenersCapacity : sequencesCapacity);
			int num6 = num5 + sequencesCapacity;
			maxActive = num6;
			IntPtr intPtr = (IntPtr)typeof(TweenManager);
			maxTweeners = num5;
			maxSequences = sequencesCapacity;
			Array.Resize(ref *(Tween[]*)((isUnityEditor ? 1 : 0) + 72), maxActive);
			Array.Resize(ref *(Tween[]*)((isUnityEditor ? 1 : 0) + 80), num5);
			_KillList.Capacity = maxActive;
		}

		[Token(Token = "0x60002B9")]
		[Address(RVA = "0x1077D70", Offset = "0x1077D70", Length = "0x1AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EBA9D0]);\n\tv21 = *([v20 @ X8_v40]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([20269C2]) = v41;\nL_001A:\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v44, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv52 = DG.Tweening.Core.TweenManager;\nL_0023:\n\tv57 = ~v55._requiresActiveReorganization;\n\tif (v57) goto L_FFFFFFFF;\n\tgoto L_002E;\n\tv70 = *([v51 @ X0_v3 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_002E;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v51, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002E:\n\tDG.Tweening.Core.TweenManager::ReorganizeActiveTweens();\n\tgoto L_006B;\nL_0035:\n\tgoto L_003D;\n\tv180 = *([v128 @ X0_v7 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv181 = v180 == 0;\n\tv182 = ~v181;\n\tif (v182) goto L_003D;\n\tv185 = \"il2cpp_codegen_runtime_class_init\"(v128, v77, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv260 = DG.Tweening.Core.TweenManager;\n\tv188 = *([v260 @ X8_v31+B8]);\nL_003D:\n\tv189 = v187._activeTweens;\n\tv240 = v111 < v189.Length;\n\tv106 = ~v240;\n\tif (v106) goto L_00AE;\n\tv284 = DG.Tweening.Tween::Validate(v189[v111 @ X22_v2 (System.Int32)]);\n\tv286 = v284 == 0;\n\tv287 = ~v286;\n\tif (v287) goto L_0066;\n\tv120 = v120 + 1;\n\tgoto L_0065;\n\tv296 = *([v288 @ X0_v25+E0]);\n\tv297 = v296 == 0;\n\tv298 = ~v297;\n\tif (v298) goto L_0065;\n\tv300 = \"il2cpp_codegen_runtime_class_init\"(v288, v78, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0065:\n\tDG.Tweening.Core.TweenManager::MarkForKilling(v189[v111 @ X22_v2 (System.Int32)]);\nL_0066:\n\tv111 = v111 + 1;\nL_006B:\n\tgoto L_0074;\n\tv125 = *([v121 @ X0_v6 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv126 = v125 == 0;\n\tv127 = ~v126;\n\tgoto L_0074;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v121, v77, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv129 = DG.Tweening.Core.TweenManager;\nL_0074:\n\tv134 = v132._maxActiveLookupId + 1;\n\tv75 = v111 < v134;\n\tif (v75) goto L_0035;\n\tv156 = v120 < 1;\n\tif (v156) goto L_00AB;\n\tgoto L_0099;\n\tv191 = *([v128 @ X0_v7 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv192 = v191 == 0;\n\tv193 = ~v192;\n\tif (v193) goto L_0099;\n\tv195 = \"il2cpp_codegen_runtime_class_init\"(v128, v77, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv276 = DG.Tweening.Core.TweenManager;\n\tv198 = *([v276 @ X8_v19+B8]);\nL_0099:\n\tDG.Tweening.Core.TweenManager::DespawnActiveTweens(v197._KillList);\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::Clear(v259._KillList);\nL_00AB:\n\treturn v120;\n\tv257 = new System.NullReferenceException();\nL_00AE:\n\tv275 = new System.IndexOutOfRangeException();\n\tthrow v275;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 104 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int Validate()
		{
			if (_requiresActiveReorganization)
			{
				ReorganizeActiveTweens();
			}
			int num = 0;
			int num2 = 0;
			while (true)
			{
				int num3 = _maxActiveLookupId + 1;
				if (num >= num3)
				{
					if (num2 >= 1)
					{
						DespawnActiveTweens(_KillList);
						_KillList.Clear();
					}
					return num2;
				}
				Tween[] activeTweens = _activeTweens;
				if (num >= activeTweens.Length)
				{
					break;
				}
				if (!activeTweens[num].Validate())
				{
					num2++;
					MarkForKilling(activeTweens[num]);
				}
				num++;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60002BA")]
		[Address(RVA = "0x106FE68", Offset = "0x106FE68", Length = "0x450")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv46 = *([1EDB0A8]);\n\tv47 = *([v46 @ X8_v76]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, methodInfo, v50, v51, v52, v53, v54, v55, deltaTime, independentTime, v56, v57, v58, v59, v60, v61);\n\tv64 = 0 | 1;\n\t*([20269C3]) = v64;\nL_0027:\n\tgoto L_0030;\n\tv71 = *([v67 @ X0_v2 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv72 = v71 == 0;\n\tv73 = ~v72;\n\tgoto L_0030;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v67, methodInfo, v50, v51, v52, v53, v54, v55, deltaTime, independentTime, v56, v57, v58, v59, v60, v61);\n\tv75 = DG.Tweening.Core.TweenManager;\nL_0030:\n\tv80 = ~v78._requiresActiveReorganization;\n\tif (v80) goto L_0040;\n\tgoto L_003B;\n\tv94 = *([v74 @ X0_v3 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv95 = v94 == 0;\n\tv96 = ~v95;\n\tif (v96) goto L_003B;\n\tv98 = \"il2cpp_codegen_runtime_class_init\"(v74, methodInfo, v50, v51, v52, v53, v54, v55, deltaTime, independentTime, v56, v57, v58, v59, v60, v61);\nL_003B:\n\tDG.Tweening.Core.TweenManager::ReorganizeActiveTweens();\nL_0040:\n\tgoto L_0049;\n\tv99 = *([v85 @ X0_v4 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv100 = v99 == 0;\n\tv101 = ~v100;\n\tgoto L_0049;\n\tv122 = \"il2cpp_codegen_runtime_class_init\"(v85, methodInfo, v50, v51, v52, v53, v54, v55, deltaTime, independentTime, v56, v57, v58, v59, v60, v61);\n\tv103 = DG.Tweening.Core.TweenManager;\nL_0049:\n\tv106.isUpdateLoop = 1;\n\tv110 = v108._maxActiveLookupId + 1;\n\tv121 = v110 < 1;\n\tif (v121) goto L_023C;\n\tgoto L_0067;\nL_0067:\n\tgoto L_006F;\n\tv262 = *([v229 @ X0_v11 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv263 = v262 == 0;\n\tv264 = ~v263;\n\tgoto L_006F;\n\tv339 = \"il2cpp_codegen_runtime_class_init\"(v229, v210, v207, v206, v52, v53, v54, v55, v214, v212, v209, v57, v58, v59, v60, v61);\n\tv266 = DG.Tweening.Core.TweenManager;\nL_006F:\n\tv270 = v269._activeTweens;\n\tv340 = v226 < v270.Length;\n\tv341 = ~v340;\n\tif (v341) goto L_0259;\n\tv201 = v270[v226 @ X23_v4 (System.Int32)];\n\tv352 = v270[v226 @ X23_v4 (System.Int32)] == 0;\n\tif (v352) goto L_01ED;\n\tv374 = v201.updateType != updateType;\n\tif (v374) goto L_01ED;\n\tgoto L_00A4;\n\tv484 = *([v265 @ X0_v12 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv485 = v484 == 0;\n\tv486 = ~v485;\n\tif (v486) goto L_00A4;\n\tv499 = \"il2cpp_codegen_runtime_class_init\"(v265, v210, v207, v206, v52, v53, v54, v55, v214, v212, v209, v57, v58, v59, v60, v61);\n\tv488 = DG.Tweening.Core.TweenManager;\n\tv491 = *([v488 @ X0_v59+B8]);\nL_00A4:\n\tv403 = v490._totTweenLinks < 1;\n\tif (v403) goto L_00B2;\n\tgoto L_00B0;\n\tv521 = *([v487 @ X0_v38+E0]);\n\tv522 = v521 == 0;\n\tv523 = ~v522;\n\tif (v523) goto L_00B0;\n\tv525 = \"il2cpp_codegen_runtime_class_init\"(v487, v210, v207, v206, v52, v53, v54, v55, v214, v212, v209, v57, v58, v59, v60, v61);\nL_00B0:\n\tDG.Tweening.Core.TweenManager::EvaluateTweenLink(v270[v226 @ X23_v4 (System.Int32)]);\nL_00B2:\n\tv509 = ~v201.<active>k__BackingField;\n\tif (v509) goto L_01E4;\n\tv465 = ~v201.isPlaying;\n\tif (v465) goto L_01ED;\n\tv201.creationLocked = 1;\n\tv566 = v201.isIndependentUpdate == 0;\n\tv571 = ~v566;\n\tv395 = ~v571;\n\tif (v395) goto L_FFFFFFFF;\n\tgoto L_00CA;\nL_00CA:\n\tv382 = v201.timeScale * v392;\n\tv615 = v382 >= 1E-06f;\n\tif (v615) goto L_00E4;\n\tv404 = v382 > -1E-06f;\n\tif (v404) goto L_01ED;\nL_00E4:\n\tv466 = ~v201.delayComplete;\n\tif (v466) goto L_0134;\nL_00E7:\n\tv650 = ~v201.startupDone;\n\tv651 = ~v650;\n\tif (v651) goto L_00F2;\n\tv548 = DG.Tweening.Tween::Startup(v270[v226 @ X23_v4 (System.Int32)]);\n\tv550 = v548 == 0;\n\tif (v550) goto L_01E4;\nL_00F2:\n\tv400 = v201.duration;\n\tv387 = v201.completedLoops;\n\tv664 = v201.duration < 0;\n\tv665 = ~v664;\n\tv668 = v201.duration == 0;\n\tv673 = ~v665;\n\tv674 = v673 | v668;\n\tif (v674) goto L_015F;\n\tv679 = ~v201.isBackwards;\n\tif (v679) goto L_016C;\n\tv709 = v201.<position>k__BackingField - v382;\n\tv690 = v387 & 0x80000000;\n\tv691 = v690 == 0;\n\tv692 = ~v691;\n\tif (v692) goto L_0121;\nL_0112:\n\tv738 = v709 >= 0;\n\tif (v738) goto L_0121;\n\tv739 = v387 - 1;\n\tv709 = v709 + v400;\n\tv712 = v387 >= 1;\n\tif (v712) goto L_0112;\nL_0121:\n\tv750 = v739 & 0x80000000;\n\tv751 = v750 == 0;\n\tv752 = ~v751;\n\tif (v752) goto L_01A3;\n\tv825 = v739 == 0;\n\tv809 = ~v825;\n\tif (v809) goto L_01B1;\n\tv764 = v201.<position>k__BackingField >= v400;\n\tif (v764) goto L_FFFFFFFF;\n\tgoto L_01B1;\nL_0134:\n\t;\n\tv399 = v382 + v201.elapsedDelay;\n\tv462 = DG.Tweening.Tween::UpdateDelay(v270[v226 @ X23_v4 (System.Int32)], v399);\n\tv654 = v399 < -1f;\n\tv545 = ~v654;\n\tv543 = v399 - -1f;\n\tv539 = v543 == 0;\n\tv655 = ~v545;\n\tv529 = v655 | v539;\n\tif (v529) goto L_01E4;\n\tv675 = v399 < 0;\n\tv453 = ~v675;\n\tv435 = v399 == 0;\n\tv676 = ~v453;\n\tv405 = v676 | v435;\n\tif (v405) goto L_01ED;\n\tv645 = ~v201.<playedOnce>k__BackingField;\n\tif (v645) goto L_00E7;\n\tv646 = v201.onPlay == 0;\n\tif (v646) goto L_00E7;\n\tv643 = DG.Tweening.Tween::OnTweenCallback(v201.onPlay);\n\tgoto L_00E7;\nL_015F:\n\tv682 = v201.loops + 1;\n\tv684 = v682 == 0;\n\tv687 = ~v684;\n\tv688 = ~v687;\n\tif (v688) goto L_0169;\n\tgoto L_FFFFFFFF;\nL_0169:\n\tv387 = v387 + 1;\n\tgoto L_01DC;\nL_016C:\n\tv854 = v382 + v201.<position>k__BackingField;\n\tv704 = v854 < v201.duration;\n\tif (v704) goto L_01B1;\nL_017A:\n\tv810 = v201.loops + 1;\n\tv848 = v810 == 0;\n\tif (v848) goto L_018B;\n\tv765 = v387 >= v201.loops;\n\tif (v765) goto L_01B1;\nL_018B:\n\tv854 = v854 - v400;\n\tv387 = v387 + 1;\n\tv766 = v854 >= v400;\n\tif (v766) goto L_017A;\n\tgoto L_01B1;\nL_01A3:\n\tv836 = v201.<position>k__BackingField < v400;\n\tif (v836) goto L_FFFFFFFF;\nL_01B1:\n\tv822 = v201.<position>k__BackingField < v400;\n\tif (v822) goto L_01C2;\n\tv387 = v387 - 1;\n\tgoto L_01C2;\nL_01C2:\n\tv878 = v387 < v201.loops;\n\tif (v878) goto L_FFFFFFFF;\n\tv906 = v201.loops - 0xFFFFFFFF;\n\tv886 = v906 == 0;\n\tgoto L_01D3;\nL_01D3:\n\tv879 = ~v886;\n\tif (v879) goto L_01DC;\n\tgoto L_01DC;\nL_01DC:\n\tv463 = DG.Tweening.Tween::DoGoto(v270[v226 @ X23_v4 (System.Int32)], v400, v387, 0);\n\tv467 = v463 == 0;\n\tif (v467) goto L_01ED;\nL_01E4:\n\tgoto L_01EB;\n\tv572 = *([v553 @ X0_v41+E0]);\n\tv573 = v572 == 0;\n\tv574 = ~v573;\n\tif (v574) goto L_01EB;\n\tv576 = \"il2cpp_codegen_runtime_class_init\"(v553, v385, v377, v375, v52, v53, v54, v55, v397, v391, v383, v57, v58, v59, v60, v61);\nL_01EB:\n\tDG.Tweening.Core.TweenManager::MarkForKilling(v270[v226 @ X23_v4 (System.Int32)]);\nL_01ED:\n\tv226 = v226 + 1;\n\tv154 = v226 < v110;\n\tif (v154) goto L_0067;\n\tv481 = v178 & 1;\n\tv196 = v481 == 0;\n\tif (v196) goto L_023C;\n\tgoto L_020B;\n\tv510 = *([v495 @ X0_v21 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv511 = v510 == 0;\n\tv512 = ~v511;\n\tif (v512) goto L_020B;\n\tv557 = \"il2cpp_codegen_runtime_class_init\"(v495, v142, v135, v133, v52, v53, v54, v55, v152, v147, v139, v57, v58, v59, v60, v61);\n\tv516 = DG.Tweening.Core.TweenManager;\n\tv514 = *([v516 @ X0_v36+12E]);\nL_020B:\n\tv520 = ~v519._despawnAllCalledFromUpdateLoopCallback;\n\tif (v520) goto L_021B;\n\tgoto L_0217;\n\tv577 = *([v515 @ X0_v22 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv578 = v577 == 0;\n\tv579 = ~v578;\n\tif (v579) goto L_0217;\n\tv598 = \"il2cpp_codegen_runtime_class_init\"(v515, v142, v135, v133, v52, v53, v54, v55, v152, v147, v139, v57, v58, v59, v60, v61);\n\tv582 = DG.Tweening.Core.TweenManager;\n\tv585 = *([v582 @ X0_v34+B8]);\nL_0217:\n\tv584._despawnAllCalledFromUpdateLoopCallback = 0;\n\tgoto L_0229;\nL_021B:\n\tgoto L_0224;\n\tv586 = *([v515 @ X0_v22 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv587 = v586 == 0;\n\tv588 = ~v587;\n\tif (v588) goto L_0224;\n\tv591 = \"il2cpp_codegen_runtime_class_init\"(v515, v142, v135, v133, v52, v53, v54, v55, v152, v147, v139, v57, v58, v59, v60, v61);\n\tv623 = DG.Tweening.Core.TweenManager;\n\tv594 = *([v623 @ X8_v35+B8]);\nL_0224:\n\tDG.Tweening.Core.TweenManager::DespawnActiveTweens(v593._KillList);\nL_0229:\n\tgoto L_0237;\n\tv616 = *([v599 @ X0_v23 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv617 = v616 == 0;\n\tv618 = ~v617;\n\t// 557 Jump @b122\n\tv636 = \"il2cpp_codegen_runtime_class_init\"(v599, v142, v135, v133, v52, v53, v54, v55, v152, v147, v139, v57, v58, v59, v60, v61);\n\tv620 = DG.Tweening.Core.TweenManager;\nL_0237:\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::Clear(v483._KillList);\nL_023C:\n\tgoto L_0244;\n\tv238 = *([v202 @ X0_v7 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv239 = v238 == 0;\n\tv240 = ~v239;\n\tif (v240) goto L_0244;\n\tv272 = \"i\n// ... truncated")]
		internal static void Update(UpdateType updateType, float deltaTime, float independentTime)
		{
			//IL_02c3: Expected I4, but got I8
			//IL_038c: Expected I4, but got I8
			//IL_06f1: Expected O, but got I8
			if (_requiresActiveReorganization)
			{
				ReorganizeActiveTweens();
			}
			isUpdateLoop = true;
			int num = _maxActiveLookupId + 1;
			if (num >= 1)
			{
				int num2 = 0;
				int num3 = 0;
				do
				{
					Tween[] activeTweens = _activeTweens;
					Tween tween;
					float num9;
					int num10;
					float num14;
					if (num3 < activeTweens.Length)
					{
						tween = activeTweens[num3];
						if (activeTweens[num3] != null && tween.updateType == updateType)
						{
							if (_totTweenLinks >= 1)
							{
								EvaluateTweenLink(activeTweens[num3]);
							}
							if (!tween.active)
							{
								goto IL_0725;
							}
							if (tween.isPlaying)
							{
								tween.creationLocked = true;
								float num4 = ((!tween.isIndependentUpdate) ? deltaTime : independentTime);
								float num5 = tween.timeScale * num4;
								if (!(num5 < 1E-06f) || !(num5 > -1E-06f))
								{
									if (!tween.delayComplete)
									{
										float num6 = num5 + tween.elapsedDelay;
										float num7 = activeTweens[num3].UpdateDelay(num6);
										bool flag = num6 < -1f;
										bool flag2 = !flag;
										float num8 = num6 - -1f;
										bool flag3 = num8 == 0f;
										bool flag4 = !flag2;
										if (flag4 || flag3)
										{
											goto IL_0725;
										}
										bool flag5 = num6 < 0f;
										bool flag6 = !flag5;
										bool flag7 = num6 == 0f;
										bool flag8 = !flag6;
										if (flag8 || flag7)
										{
											goto IL_080a;
										}
										bool flag9 = !tween.playedOnce;
										num5 = num6;
										if (!flag9)
										{
											bool flag10 = tween.onPlay == null;
											num5 = num6;
											if (!flag10)
											{
												bool flag11 = Tween.OnTweenCallback(tween.onPlay);
												num5 = num6;
											}
										}
									}
									if (tween.startupDone || activeTweens[num3].Startup())
									{
										num9 = tween.duration;
										num10 = tween.completedLoops;
										bool flag12 = tween.duration < 0f;
										bool flag13 = !flag12;
										bool flag14 = tween.duration == 0f;
										bool flag15 = !flag13;
										if (!(flag15 || flag14))
										{
											if (tween.isBackwards)
											{
												float num11 = tween.position - num5;
												int num12 = (int)(num10 & 0x80000000L);
												bool flag16 = num12 == 0;
												bool flag17 = !flag16;
												int num13 = num10;
												num14 = num11;
												if (!flag17)
												{
													bool flag19;
													do
													{
														bool flag18 = !(num11 < 0f);
														num13 = num10;
														num14 = num11;
														if (flag18)
														{
															break;
														}
														num13 = num10 - 1;
														num11 += num9;
														flag19 = num10 >= 1;
														num10 = num13;
														num14 = num11;
													}
													while (flag19);
												}
												if ((int)(num13 & 0x80000000L) != 0)
												{
													if (!(tween.position < num9))
													{
														goto IL_0699;
													}
													num10 = 0;
													num14 = 0f;
													goto IL_08e9;
												}
												bool flag20 = num13 == 0;
												bool flag21 = !flag20;
												num10 = num13;
												if (!flag21)
												{
													if (!(tween.position < num9))
													{
														goto IL_0699;
													}
													num10 = num13;
												}
											}
											else
											{
												num14 = num5 + tween.position;
												if (!(num14 < tween.duration))
												{
													while (tween.loops + 1 == 0 || num10 < tween.loops)
													{
														num14 -= num9;
														num10++;
														if (num14 < num9)
														{
															break;
														}
													}
												}
											}
											goto IL_0888;
										}
										num10 = ((tween.loops + 1 == 0) ? (num10 + 1) : tween.loops);
										num9 = 0f;
										goto IL_096b;
									}
									goto IL_0725;
								}
							}
						}
						goto IL_080a;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
					IL_080a:
					num3++;
					continue;
					IL_0699:
					num10 = 1;
					num14 = 0f;
					goto IL_0888;
					IL_0888:
					if (!(tween.position < num9))
					{
						num10--;
					}
					goto IL_08e9;
					IL_096b:
					if (Tween.DoGoto(activeTweens[num3], num9, num10, default(UpdateMode)))
					{
						goto IL_0725;
					}
					goto IL_080a;
					IL_0725:
					MarkForKilling(activeTweens[num3]);
					num2 = 1;
					goto IL_080a;
					IL_08e9:
					bool flag22;
					if (num10 >= tween.loops)
					{
						object obj = tween.loops - 4294967295L;
						flag22 = obj == null;
					}
					else
					{
						flag22 = true;
					}
					if (flag22)
					{
						num9 = num14;
					}
					goto IL_096b;
				}
				while (num3 < num);
				if ((num2 & 1) != 0)
				{
					if (_despawnAllCalledFromUpdateLoopCallback)
					{
						_despawnAllCalledFromUpdateLoopCallback = false;
					}
					else
					{
						DespawnActiveTweens(_KillList);
					}
					_KillList.Clear();
				}
			}
			isUpdateLoop = false;
		}

		[Token(Token = "0x60002BB")]
		[Address(RVA = "0x1078560", Offset = "0x1078560", Length = "0x92C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv48 = *([1EBD1D0]);\n\tv49 = *([v48 @ X8_v66]);\n\tv50 = \"il2cpp_codegen_initialize_method\"(v49, filterType, id, optionalBool, optionalObj, optionalArray, methodInfo, v52, optionalFloat, v53, v54, v55, v56, v57, v58, v59);\n\tv62 = 0 | 1;\n\t*([20269C4]) = v62;\nL_0022:\n\tv63 = optionalArray == 0;\n\tif (v63) goto L_0028;\n\tgoto L_0028;\nL_0028:\n\tv69 = filterType - 1;\n\tv72 = v69 < 1;\n\tv73 = ~v72;\n\tv74 = v69 - 1;\n\tv76 = v74 == 0;\n\tv83 = ~v76;\n\tv84 = v73 & v83;\n\tif (v84) goto L_FFFFFFFF;\n\tv85 = id == 0;\n\tif (v85) goto L_FFFFFFFF;\n\tv112 = *([id @ X2 (System.Object)]) == System.String;\n\tif (v112) goto L_005F;\n\tv111 = *([id @ X2 (System.Object)]) == System.Int32;\n\tif (v111) goto L_0061;\n\tgoto L_FFFFFFFF;\nL_005F:\n\tgoto L_FFFFFFFF;\nL_0061:\n\tv127 = \"il2cpp_vm_object_unbox\"(id, filterType, id, optionalBool, optionalObj, optionalArray, methodInfo, v52, optionalFloat, v53, v54, v55, v56, v57, v58, v59);\n\tgoto L_0075;\n\tv145 = *([v137 @ X0_v3 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv146 = v145 == 0;\n\tv147 = ~v146;\n\tgoto L_0075;\n\tv160 = \"il2cpp_codegen_runtime_class_init\"(v137, filterType, id, optionalBool, optionalObj, optionalArray, methodInfo, v52, optionalFloat, v53, v54, v55, v56, v57, v58, v59);\n\tv149 = DG.Tweening.Core.TweenManager;\nL_0075:\n\tv214 = v152._maxActiveLookupId;\n\tv154 = v152._maxActiveLookupId & 0x80000000;\n\tv155 = v154 == 0;\n\tv156 = ~v155;\n\tif (v156) goto L_FFFFFFFF;\n\tgoto L_00DF;\n\tgoto L_00DF;\n\tX8 = *([X28+109]);\n\tif (TEMP) goto L_009A;\n\tX8 = *([X28+9C]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_032B;\nL_009A:\n\tX8 = stack[14];\n\tX24 = stack[34];\n\tTEMP = X8 & 1;\n\tif (TEMP) goto L_00A2;\n\tX8 = *([X28+108]);\n\tif (TEMP) goto L_0335;\nL_00A2:\n\tX8 = stack[30];\n\tX8 = X8 + 1;\n\tstack[30] = X8;\n\tgoto L_0335;\nL_00A6:\n\tX25 = X21;\n\tgoto L_0335;\nL_00A8:\n\tX8 = *([X0+E0]);\n\tX24 = stack[34];\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00AF;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X22]);\nL_00AF:\n\tX8 = *([X0+B8]);\n\tX8 = *([X8+44]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0335;\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00BD;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00BD;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00BD:\n\tX0 = X28;\n\tX1 = 0;\n\tDG.Tweening.Core.TweenManager::Despawn(X0, X1, X2);\nL_00C0:\n\tX8 = *([X22]);\n\tX8 = *([X8+B8]);\nL_00C2:\n\tX0 = *([X8+60]);\n\tif (TEMP) goto L_03BC;\n\tX8 = *([1EB4410]);\n\tX1 = X28;\n\tX2 = *([X8]);\n\tSystem.Collections.Generic.List`1::Add /* +161 sharing this address */(X0, X1, X2);\n\tX8 = 0 | 1;\n\tstack[4] = X8;\n\tgoto L_0335;\nL_00CD:\n\tX21 = X25;\n\tgoto L_032B;\nL_00CF:\n\tX21 = 0;\n\tX25 = 0;\n\tgoto L_0335;\nL_00D2:\n\tX9 = *([X0+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_00C2;\n\tX9 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00C2;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_00C0;\nL_00DF:\n\tgoto L_00E7;\n\tv290 = *([v210 @ X0_v7 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv291 = v290 == 0;\n\tv292 = ~v291;\n\tif (v292) goto L_00E7;\n\tv368 = \"il2cpp_codegen_runtime_class_init\"(v210, filterType, id, optionalBool, optionalObj, optionalArray, methodInfo, v52, optionalFloat, v53, v54, v55, v56, v57, v58, v59);\n\tv293 = DG.Tweening.Core.TweenManager;\nL_00E7:\n\tv297 = v296._activeTweens;\n\tv369 = v214 < v297.Length;\n\tv370 = ~v369;\n\tif (v370) goto L_03B8;\n\tv186 = v297[v214 @ X23_v5 (System.Int32)];\n\tv432 = v297[v214 @ X23_v5 (System.Int32)] == 0;\n\tif (v432) goto L_0335;\n\tv355 = ~v186.<active>k__BackingField;\n\tif (v355) goto L_0335;\n\tv467 = filterType < 3;\n\tv347 = ~v467;\n\tv344 = filterType - 3;\n\tv338 = v344 == 0;\n\tv468 = ~v338;\n\tv315 = v347 & v468;\n\tif (v315) goto L_0335;\n\tv350 = 0x1825000 + 0x464;\n\tv363 = *([v350 @ X9_v10 (System.Int32)+filterType @ X1 (DG.Tweening.Core.Enums.FilterType)*4]) + v350;\n\t// 270 IndirectJump v363 @ X8_v57, v264 @ X0_v8 (Il2CppClass<DG.Tweening.Core.TweenManager>), v264 @ X0_v8 (Il2CppClass<DG.Tweening.Core.TweenManager>), filterType @ X1 (DG.Tweening.Core.Enums.FilterType), id @ X2 (System.Object), optionalBool @ X3 (System.Boolean), optionalObj @ X4 (System.Object), optionalArray @ X5 (System.Object[]), methodInfo @ X6 (Il2CppMethodInfo), v52 @ X7, optionalFloat @ V0 (System.Single), v53 @ V1, v54 @ V2, v55 @ V3, v56 @ V4, v57 @ V5, v58 @ V6, v59 @ V7\n\tTEMP = X25 & 1;\n\tif (TEMP) goto L_01D0;\n\tX0 = *([X28+38]);\n\tif (TEMP) goto L_0208;\n\tX1 = X19;\n\tX2 = 0;\n\tX0 = System.String::op_Equality(X0, X1, X2);\n\tgoto L_0130;\n\tTEMP = X25 & 1;\n\tif (TEMP) goto L_01E1;\n\tX8 = *([X28+48]);\n\tif (TEMP) goto L_0208;\n\tX0 = *([X28+38]);\n\tX1 = X19;\n\tX2 = 0;\n\tX0 = System.String::op_Equality(X0, X1, X2);\n\tX8 = stack[18];\n\tX25 = 0 | 1;\n\tif (TEMP) goto L_032B;\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_032B;\n\tX0 = stack[18];\n\tX1 = *([X28+48]);\n\tX8 = *([X0]);\n\tX9 = *([X8+130]);\n\tX2 = *([X8+138]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0130:\n\tX25 = 0 | 1;\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0241;\n\tgoto L_032B;\n\tX8 = stack[20];\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_0241;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX26 = 0;\n\tgoto L_0152;\nL_0147:\n\tX0 = X27;\n\tX0 = 0x8D82AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX9 = *([X0]);\n\tTEMP = X25 & 1;\n\tif (TEMP) goto L_0150;\n\tX20 = X9;\n\tX21 = 0 | 1;\n\tgoto L_0180;\nL_0150:\n\tX25 = 0;\n\tgoto L_0197;\nL_0152:\n\tX8 = *([X27+18]);\n\tX24 = X27;\n\tC = X26 < X8;\n\tC = ~C;\n\tTEMP1 = X26 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X26 ^ X8;\n\tTEMP3 = X26 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_03B8;\n\tX8 = stack[48];\n\tX27 = *([X8+X26*8]);\n\tif (TEMP) goto L_017D;\n\tX8 = *([1EB3EF8]);\n\tX9 = *([X8]);\n\tX8 = *([X27]);\n\tC = X8 < X9;\n\tC = ~C;\n\tTEMP1 = X8 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X9;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_0189;\n\tX9 = *([1ED0418]);\n\tX9 = *([X9]);\n\tC = X8 < X9;\n\tC = ~C;\n\tTEMP1 = X8 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X9;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_0147;\nL_017D:\n\tTEMP = X25 & 1;\n\tif (TEMP) goto L_0182;\nL_0180:\n\tX1 = X19;\n\tgoto L_018A;\nL_0182:\n\tX25 = 0;\n\tTEMP = X21 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0196;\nL_0187:\n\tX21 = 0;\n\tgoto L_01A4;\nL_0189:\n\tX1 = X27;\nL_018A:\n\tX0 = *([X28+38]);\n\tX2 = 0;\n\tX19 = X1;\n\tX0 = System.String::op_Equality(X0, X1, X2);\n\tX25 = 0 | 1;\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0206;\n\tTEMP = X21 & 1;\n\tif (TEMP) goto L_0187;\nL_0196:\n\tX9 = X20;\nL_0197:\n\tX8 = *([X28+40]);\n\tX20 = X9;\n\tX21 = 0 | 1;\n\tC = X8 < X9;\n\tC = ~C;\n\tTEMP1 = X8 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X9;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_0206;\nL_01A4:\n\tX1 = *([X28+30]);\n\tif (TEMP) goto L_01B2;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X27]);\n\tX0 = X27;\n\tX9 = *([X8+130]);\n\tX2 = *([X8+138]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0206;\nL_01B2:\n\tX1 = *([X28+48]);\n\tif (TEMP) goto L_01C0;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X27]);\n\tX0 = X27;\n\tX9 = *([X8+130]);\n\tX2 = *([X8+138]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0206;\nL_01C0:\n\tX8 = stack[38];\n\tX26 = X26 + 1;\n\tX27 = X24;\n\tC = X26 < X8;\n\tC = ~C;\n\tTEMP1 = X26 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X26 ^ X8;\n\tTEMP3 = X26 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_0152;\n\tgoto L_0241;\nL_01D0:\n\tTEMP = X21 & 1;\n\tif (TEMP) goto L_020A;\n\tX8 = *([X28+40]);\n\tX25 = 0;\n\tX21 = 0 | 1;\n\tC = X8 < X20;\n\tC = ~C;\n\tTEMP1 = X8 - X20;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X20;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_0241;\n\tgoto L_032B;\nL_01E1:\n\tTEMP = X21 & 1;\n\tif (TEMP) goto L_021A;\n\tX1 = *([X28+48]);\n\tX9 = X20;\n\tX25 = 0;\n\tX21 = 0 | 1;\n\tif (TEMP) goto L_032B;\n\tX8 = stack[18];\n\tX24 = stack[34];\n\tif (TEMP) goto L_0335;\n\tX8 = *([X28+40]);\n\tC = X8 < X9;\n\tC = ~C;\n\tTEMP1 = X8 - X9;\n\tN = TEMP1 < \n// ... truncated")]
		internal static int FilteredOperation(OperationType operationType, FilterType filterType, object id, bool optionalBool, float optionalFloat, object optionalObj = null, object[] optionalArray = null)
		{
			//IL_0454: Expected I, but got O
			//IL_0475: Expected I4, but got I8
			//IL_00a1: Expected I, but got O
			//IL_01b2: Expected O, but got I
			if (optionalArray != null)
			{
			}
			int num = (int)(filterType - 1);
			bool flag = num < 1;
			bool flag2 = !flag;
			int num2 = num - 1;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4) && id != null && (object)id.GetType() != typeof(string) && (object)id.GetType() == typeof(int))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			}
			IntPtr intPtr = (IntPtr)typeof(TweenManager);
			int num3 = _maxActiveLookupId;
			if ((int)(_maxActiveLookupId & 0x80000000L) != 0)
			{
				return 0;
			}
			while (true)
			{
				Tween[] activeTweens = _activeTweens;
				if (num3 >= activeTweens.Length)
				{
					break;
				}
				Tween tween = activeTweens[num3];
				if (activeTweens[num3] != null && tween.active)
				{
					bool flag5 = filterType < FilterType.AllExceptTargetsOrIds;
					bool flag6 = !flag5;
					int num4 = (int)(filterType - 3);
					bool flag7 = num4 == 0;
					bool flag8 = !flag7;
					if (!(flag6 && flag8))
					{
						int num5 = 25317376 + 1124;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ X9_v10 (System.Int32)+filterType @ X1 (DG.Tweening.Core.Enums.FilterType)*4]");
						object obj = 0L + (long)num5;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v363 @ X8_v57 (should have been resolved before IL gen)");
						goto IL_03a2;
					}
				}
				int num6 = num3 - 1;
				if (num3 >= 1)
				{
					intPtr = (IntPtr)typeof(TweenManager);
					num3 = num6;
					continue;
				}
				goto IL_03a2;
				IL_03a2:
				return 0;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60002BC")]
		[Address(RVA = "0x1078E8C", Offset = "0x1078E8C", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EED938]);\n\tv27 = *([v26 @ X8_v18]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, modifyActiveLists, updateMode, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20269C5]) = v44;\nL_001A:\n\tv47 = t.loops + 1;\n\tv49 = v47 == 0;\n\tif (v49) goto L_FFFFFFFF;\n\tv55 = ~t.isComplete;\n\tif (v55) goto L_0029;\n\tgoto L_0055;\nL_0029:\n\tv63 = DG.Tweening.Tween::DoGoto(t, t.duration, t.loops, updateMode);\n\tt.isPlaying = 0;\n\tv105 = ~t.autoKill;\n\tif (v105) goto L_FFFFFFFF;\n\tgoto L_003D;\n\tv120 = *([v108 @ X0_v10 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tif (v122) goto L_003D;\n\tv127 = \"il2cpp_codegen_runtime_class_init\"(v108, v46, v61, v62, v30, v31, v32, v33, v59, v35, v36, v37, v38, v39, v40, v41);\n\tv123 = DG.Tweening.Core.TweenManager;\nL_003D:\n\tv117 = ~v126.isUpdateLoop;\n\tif (v117) goto L_0044;\n\tt.<active>k__BackingField = 0;\n\tgoto L_FFFFFFFF;\nL_0044:\n\tgoto L_004C;\n\tv131 = *([v115 @ X0_v11 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv132 = v131 == 0;\n\tv133 = ~v132;\n\tif (v133) goto L_004C;\n\tv135 = \"il2cpp_codegen_runtime_class_init\"(v115, v46, v61, v62, v30, v31, v32, v33, v59, v35, v36, v37, v38, v39, v40, v41);\nL_004C:\n\tDG.Tweening.Core.TweenManager::Despawn(t, modifyActiveLists);\nL_0055:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool Complete(Tween t, bool modifyActiveLists = true, UpdateMode updateMode = UpdateMode.Goto)
		{
			if (t.loops + 1 == 0 || t.isComplete)
			{
				return false;
			}
			bool flag = Tween.DoGoto(t, t.duration, t.loops, updateMode);
			t.isPlaying = false;
			if (t.autoKill)
			{
				if (isUpdateLoop)
				{
					t.active = false;
				}
				else
				{
					Despawn(t, modifyActiveLists);
				}
			}
			return true;
		}

		[Token(Token = "0x60002BD")]
		[Address(RVA = "0x1078F80", Offset = "0x1078F80", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = t.isBackwards ^ 1;\n\tt.isBackwards = v5;\n\treturn 1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool Flip(Tween t)
		{
			int isBackwards = (t.isBackwards ? 1 : 0) ^ 1;
			t.isBackwards = (byte)isBackwards != 0;
			return true;
		}

		[Token(Token = "0x60002BE")]
		[Address(RVA = "0x1079678", Offset = "0x1079678", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EB67A8]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, isSequenced, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20269C6]) = v41;\nL_0018:\n\tv44 = ~t.startupDone;\n\tif (v44) goto L_0021;\nL_0020:\n\treturn;\nL_0021:\n\t;\n\tv53 = DG.Tweening.Tween::Startup(t);\n\tv71 = v53 == 0;\n\tv56 = ~v71;\n\tif (v56) goto L_0020;\n\tv91 = isSequenced == 0;\n\tv57 = ~v91;\n\tif (v57) goto L_0020;\n\tgoto L_003D;\n\tv97 = *([v93 @ X0_v6 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv98 = v97 == 0;\n\tv99 = ~v98;\n\tif (v99) goto L_003D;\n\tv104 = \"il2cpp_codegen_runtime_class_init\"(v93, v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv100 = DG.Tweening.Core.TweenManager;\nL_003D:\n\tv58 = ~v103.isUpdateLoop;\n\tif (v58) goto L_0044;\n\tt.<active>k__BackingField = 0;\n\tgoto L_0020;\nL_0044:\n\tgoto L_0051;\n\tv108 = *([v54 @ X0_v7 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv109 = v108 == 0;\n\tv110 = ~v109;\n\tif (v110) goto L_0051;\n\tv112 = \"il2cpp_codegen_runtime_class_init\"(v54, v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0051:\n\tDG.Tweening.Core.TweenManager::RemoveActiveTween(t);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void ForceInit(Tween t, bool isSequenced = false)
		{
			if (!t.startupDone && !t.Startup() && !isSequenced)
			{
				if (isUpdateLoop)
				{
					t.active = false;
				}
				else
				{
					RemoveActiveTween(t);
				}
			}
		}

		[Token(Token = "0x60002BF")]
		[Address(RVA = "0x1078FA8", Offset = "0x1078FA8", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv34 = *([1EDA100]);\n\tv35 = *([v34 @ X8_v14]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, andPlay, updateMode, methodInfo, v38, v39, v40, v41, to, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([20269C7]) = v51;\nL_001E:\n\tv79 = v49.duration;\n\tv49.isPlaying = andPlay;\n\tv58 = v49.duration < 0;\n\tv59 = ~v58;\n\tv62 = v49.duration == 0;\n\tv49.delayComplete = 1;\n\tv49.elapsedDelay = v49.delay;\n\tv67 = ~v59;\n\tv68 = v67 | v62;\n\tif (v68) goto L_0044;\n\tgoto L_003D;\n\tv92 = *([v73 @ X0_v12+E0]);\n\tv93 = v92 == 0;\n\tv94 = ~v93;\n\tif (v94) goto L_003D;\n\tv96 = \"il2cpp_codegen_runtime_class_init\"(v73, andPlay, updateMode, methodInfo, v38, v39, v40, v41, to, v42, v43, v44, v45, v46, v47, v48);\nL_003D:\n\tv78 = to / v49.duration;\n\tv82 = UnityEngine.Mathf::FloorToInt(v78);\n\tv79 = v49.duration;\nL_0044:\n\tv91 = 0x6D1F60(v82, andPlay, updateMode, methodInfo, v38, v39, v40, v41, to, v79, v43, v44, v45, v46, v47, v48);\n\tv114 = v49.duration;\n\tv100 = v49.loops + 1;\n\tv102 = v100 == 0;\n\tif (v102) goto L_0064;\n\tv175 = v198 < v49.loops;\n\tif (v175) goto L_0064;\n\tgoto L_006E;\nL_0064:\n\tv194 = to >= v114;\n\tif (v194) goto L_FFFFFFFF;\n\tgoto L_006E;\nL_006E:\n\tv201 = DG.Tweening.Tween::DoGoto(v49, v114, v198, updateMode);\n\tv203 = ~v49.isPlaying;\n\tif (v203) goto L_008A;\n\tv205 = andPlay == 0;\n\tv206 = ~v205;\n\tif (v206) goto L_008A;\n\tv214 = v201 == 0;\n\tv212 = ~v214;\n\tif (v212) goto L_008A;\n\tv211 = v49.onPause == 0;\n\tif (v211) goto L_008A;\n\tv209 = DG.Tweening.Tween::OnTweenCallback(v49.onPause);\nL_008A:\n\treturn v201;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 91 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool Goto(Tween t, float to, bool andPlay = false, UpdateMode updateMode = UpdateMode.Goto)
		{
			//IL_0096: Expected I4, but got O
			//IL_01f7: Expected O, but got F4
			Tween tween = default(Tween);
			float duration = tween.duration;
			tween.isPlaying = andPlay;
			bool flag = tween.duration < 0f;
			bool flag2 = !flag;
			bool flag3 = tween.duration == 0f;
			tween.delayComplete = true;
			tween.elapsedDelay = tween.delay;
			bool flag4 = !flag2;
			bool flag5 = flag4 || flag3;
			int num = (int)tween;
			int num2 = 1;
			if (!flag5)
			{
				float f = to / tween.duration;
				num = Mathf.FloorToInt(f);
				duration = tween.duration;
				num2 = num;
			}
			object obj = to % duration;
			float num3 = tween.duration;
			if (tween.loops + 1 == 0 || num2 < tween.loops)
			{
				num3 = ((!(to < num3)) ? 0f : to);
			}
			else
			{
				num2 = tween.loops;
			}
			bool flag6 = Tween.DoGoto(tween, num3, num2, updateMode);
			if (tween.isPlaying && !andPlay && !flag6 && tween.onPause != null)
			{
				bool flag7 = Tween.OnTweenCallback(tween.onPause);
			}
			return flag6;
		}

		[Token(Token = "0x60002C0")]
		[Address(RVA = "0x1077C50", Offset = "0x1077C50", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = ~t.isPlaying;\n\tif (v9) goto L_FFFFFFFF;\n\tt.isPlaying = 0;\n\tv27 = t.onPause == 0;\n\tif (v27) goto L_FFFFFFFF;\n\tv31 = DG.Tweening.Tween::OnTweenCallback(t.onPause);\n\tgoto L_0016;\nL_0016:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool Pause(Tween t)
		{
			if (t.isPlaying)
			{
				t.isPlaying = false;
				if (t.onPause != null)
				{
					bool flag = Tween.OnTweenCallback(t.onPause);
				}
				return true;
			}
			return false;
		}

		[Token(Token = "0x60002C1")]
		[Address(RVA = "0x1077BCC", Offset = "0x1077BCC", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = ~t.isPlaying;\n\tif (v9) goto L_0010;\nL_000E:\n\treturn v95;\nL_0010:\n\tv62 = ~t.isBackwards;\n\tif (v62) goto L_0030;\n\tv114 = t.completedLoops > 0;\n\tif (v114) goto L_0035;\n\tv33 = t.<position>k__BackingField <= 0;\n\tif (v33) goto L_FFFFFFFF;\n\tgoto L_0035;\nL_0030:\n\tv115 = ~t.isComplete;\n\tv63 = ~v115;\n\tif (v63) goto L_FFFFFFFF;\nL_0035:\n\tt.isPlaying = 1;\n\tv99 = ~t.<playedOnce>k__BackingField;\n\tif (v99) goto L_000E;\n\tv141 = ~t.delayComplete;\n\tif (v141) goto L_FFFFFFFF;\n\tv143 = t.onPlay == 0;\n\tif (v143) goto L_FFFFFFFF;\n\tv145 = DG.Tweening.Tween::OnTweenCallback(t.onPlay);\n\tgoto L_000E;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool Play(Tween t)
		{
			if (t.isPlaying)
			{
				goto IL_001e;
			}
			if (t.isBackwards)
			{
				if (t.completedLoops <= 0 && !(t.position > 0f))
				{
					goto IL_001e;
				}
			}
			else if (t.isComplete)
			{
				goto IL_001e;
			}
			t.isPlaying = true;
			bool flag = !t.playedOnce;
			bool result = true;
			if (!flag)
			{
				if (t.delayComplete && t.onPlay != null)
				{
					bool flag2 = Tween.OnTweenCallback(t.onPlay);
				}
				result = true;
			}
			goto IL_015b;
			IL_001e:
			result = false;
			goto IL_015b;
			IL_015b:
			return result;
		}

		[Token(Token = "0x60002C2")]
		[Address(RVA = "0x10790F0", Offset = "0x10790F0", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EDF618]);\n\tv19 = *([v18 @ X8_v24]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20269C8]) = v38;\nL_0016:\n\tv41 = t.completedLoops == 0;\n\tv42 = ~v41;\n\tif (v42) goto L_0027;\n\tv46 = t.<position>k__BackingField < 0;\n\tv47 = ~v46;\n\tv50 = t.<position>k__BackingField == 0;\n\tv55 = ~v47;\n\tv56 = v55 | v50;\n\tif (v56) goto L_0055;\nL_0027:\n\tv77 = ~t.isBackwards;\n\tif (v77) goto L_003E;\n\tgoto L_003B;\n\tv150 = *([v86 @ X0_v11+E0]);\n\tv151 = v150 == 0;\n\tv152 = ~v151;\n\tif (v152) goto L_003B;\n\tv154 = \"il2cpp_codegen_runtime_class_init\"(v86, methodInfo, v22, v23, v24, v25, v26, v27, v75, v29, v30, v31, v32, v33, v34, v35);\nL_003B:\n\treturnVal2 = DG.Tweening.Core.TweenManager::Play(t);\n\treturn returnVal2;\nL_003E:\n\tt.isBackwards = 1;\n\tgoto L_004C;\n\tv156 = *([v93 @ X0_v5+E0]);\n\tv157 = v156 == 0;\n\tv158 = ~v157;\n\tif (v158) goto L_004C;\n\tv160 = \"il2cpp_codegen_runtime_class_init\"(v93, methodInfo, v22, v23, v24, v25, v26, v27, v75, v29, v30, v31, v32, v33, v34, v35);\nL_004C:\n\tv164 = DG.Tweening.Core.TweenManager::Play(t);\n\tgoto L_0067;\nL_0055:\n\tgoto L_005E;\n\tv140 = *([v80 @ X0_v16+E0]);\n\tv141 = v140 == 0;\n\tv142 = ~v141;\n\tif (v142) goto L_005E;\n\tv144 = \"il2cpp_codegen_runtime_class_init\"(v80, methodInfo, v22, v23, v24, v25, v26, v27, v45, v29, v30, v31, v32, v33, v34, v35);\nL_005E:\n\tDG.Tweening.Core.TweenManager::ManageOnRewindCallbackWhenAlreadyRewinded(t, 1);\n\tt.isBackwards = 1;\n\tt.isPlaying = 0;\nL_0067:\n\treturn returnVal3;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool PlayBackwards(Tween t)
		{
			if (t.completedLoops == 0)
			{
				bool flag = t.position < 0f;
				bool flag2 = !flag;
				bool flag3 = t.position == 0f;
				bool flag4 = !flag2;
				if (flag4 || flag3)
				{
					ManageOnRewindCallbackWhenAlreadyRewinded(t, isPlayBackwardsOrSmoothRewind: true);
					t.isBackwards = true;
					t.isPlaying = false;
					return false;
				}
			}
			if (t.isBackwards)
			{
				return Play(t);
			}
			t.isBackwards = true;
			bool flag5 = Play(t);
			return true;
		}

		[Token(Token = "0x60002C3")]
		[Address(RVA = "0x10791FC", Offset = "0x10791FC", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1F10B98]);\n\tv19 = *([v18 @ X8_v18]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20269C9]) = v38;\nL_0016:\n\tv41 = ~t.isComplete;\n\tif (v41) goto L_001D;\n\tt.isBackwards = 0;\n\tt.isPlaying = 0;\n\tgoto L_0034;\nL_001D:\n\tv46 = ~t.isBackwards;\n\tif (v46) goto L_003B;\n\tt.isBackwards = 0;\n\tgoto L_002D;\n\tv83 = *([v59 @ X0_v10+E0]);\n\tv84 = v83 == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_002D;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v59, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tv89 = DG.Tweening.Core.TweenManager::Play(t);\nL_0034:\n\treturn returnVal2;\nL_003B:\n\tgoto L_0047;\n\tv90 = *([v65 @ X0_v5+E0]);\n\tv91 = v90 == 0;\n\tv92 = ~v91;\n\tif (v92) goto L_0047;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v65, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0047:\n\treturnVal3 = DG.Tweening.Core.TweenManager::Play(t);\n\treturn returnVal3;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool PlayForward(Tween t)
		{
			if (t.isComplete)
			{
				t.isBackwards = false;
				t.isPlaying = false;
				return false;
			}
			if (t.isBackwards)
			{
				t.isBackwards = false;
				bool flag = Play(t);
				return true;
			}
			return Play(t);
		}

		[Token(Token = "0x60002C4")]
		[Address(RVA = "0x10792C8", Offset = "0x10792C8", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv26 = *([1EB4E00]);\n\tv27 = *([v26 @ X8_v14]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, includeDelay, methodInfo, v30, v31, v32, v33, v34, changeDelayTo, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20269CA]) = v44;\nL_0023:\n\tt.isBackwards = 0;\n\tv57 = changeDelayTo < 0;\n\tif (v57) goto L_002E;\n\tt.delay = changeDelayTo;\nL_002E:\n\tgoto L_0036;\n\tv66 = *([v62 @ X0_v4+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tgoto L_0036;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v62, includeDelay, methodInfo, v30, v31, v32, v33, v34, changeDelayTo, v35, v36, v37, v38, v39, v40, v41);\nL_0036:\n\tv75 = DG.Tweening.Core.TweenManager::Rewind(t, includeDelay);\n\tv95 = t.isPlaying == 1;\n\tt.isPlaying = 1;\n\tif (v95) goto L_0056;\n\tv125 = ~t.<playedOnce>k__BackingField;\n\tif (v125) goto L_0056;\n\tv131 = ~t.delayComplete;\n\tif (v131) goto L_0056;\n\tv130 = t.onPlay == 0;\n\tif (v130) goto L_0056;\n\tv128 = DG.Tweening.Tween::OnTweenCallback(t.onPlay);\nL_0056:\n\treturn 1;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool Restart(Tween t, bool includeDelay = true, float changeDelayTo = -1f)
		{
			t.isBackwards = false;
			if (!(changeDelayTo < 0f))
			{
				t.delay = changeDelayTo;
			}
			bool flag = Rewind(t, includeDelay);
			bool flag2 = t.isPlaying;
			t.isPlaying = true;
			if (!flag2 && t.playedOnce && t.delayComplete && t.onPlay != null)
			{
				bool flag3 = Tween.OnTweenCallback(t.onPlay);
			}
			return true;
		}

		[Token(Token = "0x60002C5")]
		[Address(RVA = "0x10793A0", Offset = "0x10793A0", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1F099C8]);\n\tv25 = *([v24 @ X8_v17]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, includeDelay, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20269CB]) = v43;\nL_0018:\n\tv119 = t.delay;\n\tt.isPlaying = 0;\n\tv59 = t.delay <= 0;\n\tif (v59) goto L_0066;\n\tv64 = ~includeDelay;\n\tv69 = t.elapsedDelay - t.delay;\n\tv70 = v69 < 0;\n\tv80 = t.elapsedDelay < 0;\n\tv81 = t.elapsedDelay == 0;\n\tv83 = t.elapsedDelay ^ t.elapsedDelay;\n\tv84 = t.elapsedDelay & v83;\n\tv85 = v84 < 0;\n\tv86 = v80 == v85;\n\tv87 = ~v81;\n\tv88 = v86 & v87;\n\tv92 = includeDelay == 0;\n\tv95 = ~v92;\n\tv96 = ~v95;\n\tif (v96) goto L_0051;\n\tgoto L_0051;\nL_0051:\n\tv109 = ~v92;\n\tv98 = ~v109;\n\tif (v98) goto L_FFFFFFFF;\n\tgoto L_0058;\nL_0058:\n\tt.elapsedDelay = v119;\n\tt.delayComplete = v64;\nL_0066:\n\tv136 = t.<position>k__BackingField > 0;\n\tif (v136) goto L_007C;\n\tv151 = t.completedLoops <= 0;\n\tif (v151) goto L_008B;\nL_007C:\n\tv171 = DG.Tweening.Tween::DoGoto(t, 0f, 0, 1);\n\tv231 = ~t.isPlaying;\n\tif (v231) goto L_00A4;\n\tv241 = v171 == 0;\n\tv242 = ~v241;\n\tif (v242) goto L_00A4;\n\tv249 = t.onPause == 0;\n\tif (v249) goto L_FFFFFFFF;\n\tv260 = DG.Tweening.Tween::OnTweenCallback(t.onPause);\n\tgoto L_00A4;\nL_008B:\n\tv162 = ~t.startupDone;\n\tif (v162) goto L_007C;\n\tgoto L_009B;\n\tv253 = *([v236 @ X0_v11+E0]);\n\tv254 = v253 == 0;\n\tv255 = ~v254;\n\tif (v255) goto L_009B;\n\tv257 = \"il2cpp_codegen_runtime_class_init\"(v236, includeDelay, methodInfo, v28, v29, v30, v31, v32, v124, v107, v106, v36, v37, v38, v39, v40);\nL_009B:\n\tDG.Tweening.Core.TweenManager::ManageOnRewindCallbackWhenAlreadyRewinded(t, 0);\nL_00A4:\n\treturn v251;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 110 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool Rewind(Tween t, bool includeDelay = true)
		{
			//IL_00c8: Expected I4, but got F4
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Expected I4, but got Unknown
			float elapsedDelay = t.delay;
			t.isPlaying = false;
			bool flag = !(t.delay > 0f);
			bool flag2 = false;
			if (!flag)
			{
				bool delayComplete = !includeDelay;
				float num = t.elapsedDelay - t.delay;
				bool flag3 = num < 0f;
				bool flag4 = t.elapsedDelay < 0f;
				bool flag5 = t.elapsedDelay == 0f;
				int num2 = t.elapsedDelay ^ t.elapsedDelay;
				int num3 = t.elapsedDelay & num2;
				bool flag6 = num3 < 0;
				bool flag7 = flag4 == flag6;
				bool flag8 = !flag5;
				bool flag9 = flag7 && flag8;
				bool flag10 = !includeDelay;
				if (!flag10)
				{
					elapsedDelay = 0f;
				}
				flag2 = (flag10 ? flag3 : flag9);
				t.elapsedDelay = elapsedDelay;
				t.delayComplete = delayComplete;
			}
			int result;
			if (t.position > 0f || t.completedLoops > 0 || !t.startupDone)
			{
				bool flag11 = Tween.DoGoto(t, 0f, 0, UpdateMode.Goto);
				bool flag12 = !t.isPlaying;
				result = 1;
				if (!flag12)
				{
					bool flag13 = !flag11;
					bool flag14 = !flag13;
					result = 1;
					if (!flag14)
					{
						if (t.onPause != null)
						{
							bool flag15 = Tween.OnTweenCallback(t.onPause);
						}
						result = 1;
					}
				}
			}
			else
			{
				ManageOnRewindCallbackWhenAlreadyRewinded(t, isPlayBackwardsOrSmoothRewind: false);
				result = (flag2 ? 1 : 0);
			}
			return (byte)result != 0;
		}

		[Token(Token = "0x60002C6")]
		[Address(RVA = "0x10794D0", Offset = "0x10794D0", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv18 = *([1EC64C8]);\n\tv19 = *([v18 @ X8_v17]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20269CC]) = v38;\nL_0021:\n\tv52 = t.delay <= 0;\n\tif (v52) goto L_FFFFFFFF;\n\tt.elapsedDelay = t.delay;\n\tt.delayComplete = 1;\n\tv59 = t.elapsedDelay - t.delay;\n\tv60 = v59 < 0;\n\tgoto L_003F;\nL_003F:\n\tv91 = t.<position>k__BackingField > 0;\n\tif (v91) goto L_0054;\n\tv155 = t.completedLoops <= 0;\n\tif (v155) goto L_006F;\nL_0054:\n\tv174 = t.loopType == 2;\n\tif (v174) goto L_0065;\n\tv181 = DG.Tweening.TweenExtensions::ElapsedDirectionalPercentage(t);\n\tv189 = v181 * t.duration;\n\tDG.Tweening.TweenExtensions::Goto(t, v189, 0);\nL_0065:\n\tDG.Tweening.TweenExtensions::PlayBackwards(t);\nL_006D:\n\treturn v211;\nL_006F:\n\tv166 = ~t.startupDone;\n\tif (v166) goto L_0054;\n\tt.isPlaying = 0;\n\tgoto L_0080;\n\tv201 = *([v196 @ X0_v10+E0]);\n\tv202 = v201 == 0;\n\tv203 = ~v202;\n\tif (v203) goto L_0080;\n\tv205 = \"il2cpp_codegen_runtime_class_init\"(v196, methodInfo, v22, v23, v24, v25, v26, v27, v79, v68, v30, v31, v32, v33, v34, v35);\nL_0080:\n\tDG.Tweening.Core.TweenManager::ManageOnRewindCallbackWhenAlreadyRewinded(t, 1);\n\tgoto L_006D;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 96 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool SmoothRewind(Tween t)
		{
			bool result;
			if (t.delay > 0f)
			{
				t.elapsedDelay = t.delay;
				t.delayComplete = true;
				float num = t.elapsedDelay - t.delay;
				bool flag = num < 0f;
				result = flag;
			}
			else
			{
				result = false;
			}
			if (t.position > 0f || t.completedLoops > 0 || !t.startupDone)
			{
				if (t.loopType != LoopType.Incremental)
				{
					float num2 = t.ElapsedDirectionalPercentage();
					float to = num2 * t.duration;
					t.Goto(to);
				}
				t.PlayBackwards();
				result = true;
			}
			else
			{
				t.isPlaying = false;
				ManageOnRewindCallbackWhenAlreadyRewinded(t, isPlayBackwardsOrSmoothRewind: true);
			}
			return result;
		}

		[Token(Token = "0x60002C7")]
		[Address(RVA = "0x10795E0", Offset = "0x10795E0", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EB3878]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20269CD]) = v38;\nL_001A:\n\tv45 = ~t.isPlaying;\n\tif (v45) goto L_002E;\n\tgoto L_002A;\n\tv52 = *([v43 @ X0_v4+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_002A;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002A:\n\treturnVal2 = DG.Tweening.Core.TweenManager::Pause(t);\n\treturn returnVal2;\nL_002E:\n\tgoto L_003A;\n\tv65 = *([v43 @ X0_v4+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_003A;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003A:\n\treturnVal3 = DG.Tweening.Core.TweenManager::Play(t);\n\treturn returnVal3;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool TogglePause(Tween t)
		{
			if (t.isPlaying)
			{
				return Pause(t);
			}
			return Play(t);
		}

		[Token(Token = "0x60002C8")]
		[Address(RVA = "0x1079824", Offset = "0x1079824", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB4678]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20269CE]) = v35;\nL_0017:\n\tgoto L_0023;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0023;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = DG.Tweening.Core.TweenManager;\nL_0023:\n\treturnVal1 = v49.totPooledSequences + v49.totPooledTweeners;\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int TotalPooledTweens()
		{
			return totPooledSequences + totPooledTweeners;
		}

		[Token(Token = "0x60002C9")]
		[Address(RVA = "0x1079890", Offset = "0x1079890", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EDB540]);\n\tv19 = *([v18 @ X8_v29]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([20269CF]) = v39;\nL_0019:\n\tgoto L_0022;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0022;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = DG.Tweening.Core.TweenManager;\nL_0022:\n\tv55 = ~v53.hasActiveTweens;\n\tif (v55) goto L_FFFFFFFF;\n\tgoto L_0030;\n\tv61 = *([v49 @ X0_v3 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_0030;\n\tv120 = \"il2cpp_codegen_runtime_class_init\"(v49, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv66 = DG.Tweening.Core.TweenManager;\n\tv69 = *([v66 @ X0_v24+B8]);\nL_0030:\n\tv71 = ~v68._requiresActiveReorganization;\n\tif (v71) goto L_FFFFFFFF;\n\tgoto L_003B;\n\tv167 = *([v65 @ X0_v6 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv168 = v167 == 0;\n\tv169 = ~v168;\n\tif (v169) goto L_003B;\n\tv171 = \"il2cpp_codegen_runtime_class_init\"(v65, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003B:\n\tDG.Tweening.Core.TweenManager::ReorganizeActiveTweens();\n\tgoto L_0064;\nL_0043:\n\tgoto L_004B;\n\tv215 = *([v107 @ X0_v9 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv216 = v215 == 0;\n\tv217 = ~v216;\n\tif (v217) goto L_004B;\n\tv223 = \"il2cpp_codegen_runtime_class_init\"(v107, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv219 = DG.Tweening.Core.TweenManager;\n\tv222 = *([v219 @ X0_v17+B8]);\nL_004B:\n\tv164 = v221._activeTweens;\n\tv224 = v76 < v164.Length;\n\tv190 = ~v224;\n\tif (v190) goto L_0086;\n\tv228 = v164[v76 @ X21_v4 (System.Int32)];\n\tv196 = v164[v76 @ X21_v4 (System.Int32)] == 0;\n\tif (v196) goto L_0060;\n\tv199 = v199 + v228.isPlaying;\nL_0060:\n\tv76 = v76 + 1;\nL_0064:\n\tgoto L_006D;\n\tv203 = *([v193 @ X0_v8 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv204 = v203 == 0;\n\tv205 = ~v204;\n\tgoto L_006D;\n\tv211 = \"il2cpp_codegen_runtime_class_init\"(v193, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv206 = DG.Tweening.Core.TweenManager;\nL_006D:\n\tv105 = v111._maxActiveLookupId + 1;\n\tv74 = v76 < v105;\n\tif (v74) goto L_0043;\n\tgoto L_0083;\nL_0083:\n\treturn v199;\n\tv226 = new System.NullReferenceException();\nL_0086:\n\tv230 = new System.IndexOutOfRangeException();\n\tthrow v230;\n\treturn returnVal2;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int TotalPlayingTweens()
		{
			int num;
			if (!hasActiveTweens)
			{
				num = 0;
			}
			else
			{
				if (_requiresActiveReorganization)
				{
					ReorganizeActiveTweens();
				}
				int num2 = 0;
				num = 0;
				while (true)
				{
					int num3 = _maxActiveLookupId + 1;
					if (num2 >= num3)
					{
						break;
					}
					Tween[] activeTweens = _activeTweens;
					if (num2 < activeTweens.Length)
					{
						Tween tween = activeTweens[num2];
						if (activeTweens[num2] != null)
						{
							num += (tween.isPlaying ? 1 : 0);
						}
						num2++;
						continue;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
			}
			return num;
		}

		[Token(Token = "0x60002CA")]
		[Address(RVA = "0x10799E8", Offset = "0x10799E8", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv28 = *([1F033F8]);\n\tv29 = *([v28 @ X8_v44]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, fillableList, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20269D0]) = v47;\n\tgoto L_0027;\n\tv54 = *([v50 @ X0_v2 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0027;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v50, fillableList, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv58 = DG.Tweening.Core.TweenManager;\nL_0027:\n\tv63 = ~v61._requiresActiveReorganization;\n\tif (v63) goto L_0037;\n\tgoto L_0032;\n\tv77 = *([v57 @ X0_v3 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_0032;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v57, fillableList, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0032:\n\tDG.Tweening.Core.TweenManager::ReorganizeActiveTweens();\nL_0037:\n\tgoto L_003F;\n\tv82 = *([v68 @ X0_v4 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv83 = v82 == 0;\n\tv84 = ~v83;\n\tgoto L_003F;\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v68, fillableList, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv86 = DG.Tweening.Core.TweenManager;\nL_003F:\n\tv172 = v89.totActiveTweens;\n\tv101 = v89.totActiveTweens < 1;\n\tif (v101) goto L_FFFFFFFF;\n\tv104 = *([v85 @ X0_v5 (Il2CppClass<DG.Tweening.Core.TweenManager>)+12F]) & 2;\n\tv105 = v104 == 0;\n\tif (v105) goto L_0053;\n\tv108 = *([v85 @ X0_v5 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]) == 0;\n\tif (v108) goto L_00D5;\nL_0053:\n\tv111 = fillableList == 0;\n\tv112 = ~v111;\n\tif (v112) goto L_006A;\nL_0059:\n\tv177 = new System.Collections.Generic.List`1<DG.Tweening.Tween>();\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::.ctor(v177, v172);\nL_006A:\n\tv198 = v187 < 1;\n\tif (v198) goto L_00B7;\nL_0074:\n\tgoto L_007C;\n\tv346 = *([v296 @ X0_v20 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv347 = v346 == 0;\n\tv348 = ~v347;\n\tgoto L_007C;\n\tv359 = \"il2cpp_codegen_runtime_class_init\"(v296, v292, v291, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv349 = DG.Tweening.Core.TweenManager;\nL_007C:\n\tv342 = v352._activeTweens;\n\tv360 = v281 < v342.Length;\n\tv330 = ~v360;\n\tif (v330) goto L_00DC;\n\tv272 = v342[v281 @ X23_v7 (System.Int32)];\n\tv322 = v272.isPlaying == 0;\n\tv307 = ~v322;\n\tv278 = v307 ^ playing;\n\tv365 = v278 == 0;\n\tv366 = ~v365;\n\tif (v366) goto L_00A5;\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::Add(v153, v342[v281 @ X23_v7 (System.Int32)]);\nL_00A5:\n\tv281 = v281 + 1;\n\tv254 = v281 < v187;\n\tif (v254) goto L_0074;\nL_00B7:\n\tv141 = v153._size - 1;\n\tv139 = v141 < 0;\n\tv135 = v153._size ^ 1;\n\tv133 = v153._size ^ v141;\n\tv131 = v135 & v133;\n\tv129 = v131 < 0;\n\tv301 = v139 == v129;\n\tv127 = ~v301;\n\tv115 = ~v127;\n\tif (v115) goto L_FFFFFFFF;\n\tgoto L_00C6;\nL_00C6:\n\tgoto L_00D1;\nL_00D1:\n\treturn returnVal1;\nL_00D5:\n\tv187 = v171.totActiveTweens;\n\tv244 = fillableList == 0;\n\tv169 = ~v244;\n\tif (v169) goto L_006A;\n\tgoto L_0059;\n\tv345 = new System.NullReferenceException();\nL_00DC:\n\tv358 = new System.IndexOutOfRangeException();\n\tthrow v358;\n\treturn returnVal2;\n// 137 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static List<Tween> GetActiveTweens(bool playing, List<Tween> fillableList = null)
		{
			//IL_02f1: Expected I, but got O
			//IL_001d: Expected I, but got O
			IntPtr intPtr = (IntPtr)typeof(TweenManager);
			if (_requiresActiveReorganization)
			{
				ReorganizeActiveTweens();
				intPtr = (IntPtr)typeof(TweenManager);
			}
			int num = totActiveTweens;
			int num2;
			List<Tween> list;
			if (totActiveTweens >= 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ X0_v5 (Il2CppClass<DG.Tweening.Core.TweenManager>)+12F]");
				if (0u != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ X0_v5 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						num2 = totActiveTweens;
						bool flag = fillableList == null;
						bool flag2 = !flag;
						list = fillableList;
						if (!flag2)
						{
							num = totActiveTweens;
							goto IL_00b2;
						}
						goto IL_00d5;
					}
				}
				bool flag3 = fillableList == null;
				bool flag4 = !flag3;
				list = fillableList;
				num2 = num;
				if (!flag4)
				{
					goto IL_00b2;
				}
				goto IL_00d5;
			}
			return null;
			IL_00d5:
			if (num2 >= 1)
			{
				int num3 = 0;
				do
				{
					Tween[] activeTweens = _activeTweens;
					if (num3 < activeTweens.Length)
					{
						Tween tween = activeTweens[num3];
						bool flag5 = !tween.isPlaying;
						bool flag6 = !flag5;
						if (!(flag6 ^ playing))
						{
							list.Add(activeTweens[num3]);
						}
						num3++;
						continue;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				while (num3 < num2);
			}
			int num4 = list.Count - 1;
			bool flag7 = num4 < 0;
			int num5 = list.Count ^ 1;
			int num6 = list.Count ^ num4;
			int num7 = num5 & num6;
			bool flag8 = num7 < 0;
			if (flag7 != flag8)
			{
				return null;
			}
			return list;
			IL_00b2:
			List<Tween> list2 = new List<Tween>(num);
			list = list2;
			num2 = num;
			goto IL_00d5;
		}

		[Token(Token = "0x60002CB")]
		[Address(RVA = "0x1079BBC", Offset = "0x1079BBC", Length = "0x2B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv38 = *([1EB7BD0]);\n\tv39 = *([v38 @ X8_v52]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, playingOnly, fillableList, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([20269D1]) = v56;\n\tgoto L_002C;\n\tv63 = *([v59 @ X0_v2 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tgoto L_002C;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v59, playingOnly, fillableList, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv67 = DG.Tweening.Core.TweenManager;\nL_002C:\n\tv72 = ~v70._requiresActiveReorganization;\n\tif (v72) goto L_003C;\n\tgoto L_0037;\n\tv86 = *([v66 @ X0_v3 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv87 = v86 == 0;\n\tv88 = ~v87;\n\tif (v88) goto L_0037;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v66, playingOnly, fillableList, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0037:\n\tDG.Tweening.Core.TweenManager::ReorganizeActiveTweens();\nL_003C:\n\tgoto L_0044;\n\tv91 = *([v77 @ X0_v4 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv92 = v91 == 0;\n\tv93 = ~v92;\n\tgoto L_0044;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v77, playingOnly, fillableList, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv95 = DG.Tweening.Core.TweenManager;\nL_0044:\n\tv192 = v98.totActiveTweens;\n\tv110 = v98.totActiveTweens < 1;\n\tif (v110) goto L_FFFFFFFF;\n\tv113 = *([v94 @ X0_v5 (Il2CppClass<DG.Tweening.Core.TweenManager>)+12F]) & 2;\n\tv114 = v113 == 0;\n\tif (v114) goto L_0058;\n\tv117 = *([v94 @ X0_v5 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]) == 0;\n\tif (v117) goto L_0095;\nL_0058:\n\tv120 = fillableList == 0;\n\tv121 = ~v120;\n\tif (v121) goto L_0066;\nL_005E:\n\tv202 = new System.Collections.Generic.List`1<DG.Tweening.Tween>();\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::.ctor(v202, v192);\nL_0066:\n\tv213 = id == 0;\n\tif (v213) goto L_FFFFFFFF;\n\tv274 = *([id @ X0 (System.Object)]) == System.String;\n\tif (v274) goto L_FFFFFFFF;\n\tv289 = *([id @ X0 (System.Object)]) == System.Int32;\n\tif (v289) goto L_009B;\n\tgoto L_00AA;\n\tgoto L_012E;\n\tgoto L_00AA;\n\tgoto L_00AA;\nL_0095:\n\tv203 = v198.totActiveTweens;\n\tv264 = fillableList == 0;\n\tv196 = ~v264;\n\tif (v196) goto L_0066;\n\tgoto L_005E;\nL_009B:\n\tv313 = \"il2cpp_vm_object_unbox\"(id, v206, Il2CppMethodInfo, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv139 = *([v313 @ X0_v32]);\nL_00AA:\n\tv327 = v203 < 1;\n\tif (v327) goto L_0112;\nL_00B2:\n\tgoto L_00BA;\n\tv422 = *([v379 @ X0_v20 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv423 = v422 == 0;\n\tv424 = ~v423;\n\tgoto L_00BA;\n\tv441 = \"il2cpp_codegen_runtime_class_init\"(v379, v375, v374, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv425 = DG.Tweening.Core.TweenManager;\nL_00BA:\n\tv418 = v428._activeTweens;\n\tv442 = v363 < v418.Length;\n\tv436 = ~v442;\n\tif (v436) goto L_0131;\n\tv335 = v418[v363 @ X28_v7 (System.Int32)];\n\tv444 = v418[v363 @ X28_v7 (System.Int32)] == 0;\n\tif (v444) goto L_0100;\n\tv445 = v135 == 0;\n\tif (v445) goto L_00E8;\n\tv473 = v335.stringId == 0;\n\tif (v473) goto L_0100;\n\tv470 = System.String::op_Inequality(v335.stringId, v172);\n\tv485 = v470 == 0;\n\tv474 = ~v485;\n\tif (v474) goto L_0100;\nL_00DA:\n\tv489 = playingOnly == 0;\n\tif (v489) goto L_00E6;\n\tv475 = ~v335.isPlaying;\n\tif (v475) goto L_0100;\nL_00E6:\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::Add(v174, v418[v363 @ X28_v7 (System.Int32)]);\n\tgoto L_0100;\nL_00E8:\n\tv476 = v137 == 0;\n\tif (v476) goto L_00F7;\n\tv455 = v335.intId == v139;\n\tif (v455) goto L_00DA;\n\tgoto L_0100;\nL_00F7:\n\tv477 = v335.id == 0;\n\tif (v477) goto L_0100;\n\tv468 = System.Object::Equals(id, v335.id);\n\tv493 = v468 == 0;\n\tv472 = ~v493;\n\tif (v472) goto L_00DA;\nL_0100:\n\tv363 = v363 + 1;\n\tv332 = v363 < v203;\n\tif (v332) goto L_00B2;\nL_0112:\n\tv153 = v174._size - 1;\n\tv151 = v153 < 0;\n\tv147 = v174._size ^ 1;\n\tv145 = v174._size ^ v153;\n\tv143 = v147 & v145;\n\tv141 = v143 < 0;\n\tv384 = v151 == v141;\n\tv126 = ~v384;\n\tv124 = ~v126;\n\tif (v124) goto L_FFFFFFFF;\n\tgoto L_012E;\nL_012E:\n\treturn returnVal1;\n\tv421 = new System.NullReferenceException();\nL_0131:\n\tv440 = new System.IndexOutOfRangeException();\n\tthrow v440;\n\treturn returnVal2;\n// 191 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static List<Tween> GetTweensById(object id, bool playingOnly, List<Tween> fillableList = null)
		{
			//IL_0522: Expected I, but got O
			//IL_001d: Expected I, but got O
			//IL_00a4: Expected O, but got I4
			//IL_00d8: Expected O, but got I4
			//IL_01fa: Expected O, but got I4
			//IL_0230: Expected I4, but got O
			IntPtr intPtr = (IntPtr)typeof(TweenManager);
			if (_requiresActiveReorganization)
			{
				ReorganizeActiveTweens();
				intPtr = (IntPtr)typeof(TweenManager);
			}
			int num = totActiveTweens;
			int num2;
			List<Tween> list;
			object obj;
			if (totActiveTweens >= 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ X0_v5 (Il2CppClass<DG.Tweening.Core.TweenManager>)+12F]");
				if (0u != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ X0_v5 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						num2 = totActiveTweens;
						bool flag = fillableList == null;
						bool flag2 = !flag;
						obj = playingOnly;
						list = fillableList;
						if (!flag2)
						{
							num = totActiveTweens;
							goto IL_00ba;
						}
						goto IL_00e5;
					}
				}
				bool flag3 = fillableList == null;
				bool flag4 = !flag3;
				num2 = num;
				obj = playingOnly;
				list = fillableList;
				if (!flag4)
				{
					goto IL_00ba;
				}
				goto IL_00e5;
			}
			return null;
			IL_00e5:
			int num3;
			int num4;
			int num5;
			object obj2;
			if (id != null)
			{
				if ((object)id.GetType() != typeof(string))
				{
					if ((object)id.GetType() != typeof(int))
					{
						num3 = 0;
						num4 = 0;
						num5 = 0;
						obj2 = null;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						object obj3 = default(object);
						num5 = (int)obj3;
						num3 = 0;
						num4 = 1;
						obj2 = null;
					}
				}
				else
				{
					num3 = 1;
					num4 = 0;
					num5 = 0;
					obj2 = id;
				}
			}
			else
			{
				num3 = 0;
				num4 = 0;
				num5 = 0;
				obj2 = id;
			}
			if (num2 >= 1)
			{
				int num6 = 0;
				do
				{
					Tween[] activeTweens = _activeTweens;
					Tween tween;
					if (num6 < activeTweens.Length)
					{
						tween = activeTweens[num6];
						if (activeTweens[num6] != null)
						{
							if (num3 != 0)
							{
								if (tween.stringId != null && !(tween.stringId != (string)obj2))
								{
									goto IL_0337;
								}
							}
							else if (num4 != 0)
							{
								if (tween.intId == num5)
								{
									goto IL_0337;
								}
							}
							else if (tween.id != null && object.Equals(id, tween.id))
							{
								goto IL_0337;
							}
						}
						goto IL_0430;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
					IL_0337:
					if (!playingOnly || tween.isPlaying)
					{
						list.Add(activeTweens[num6]);
					}
					goto IL_0430;
					IL_0430:
					num6++;
				}
				while (num6 < num2);
			}
			int num7 = list.Count - 1;
			bool flag5 = num7 < 0;
			int num8 = list.Count ^ 1;
			int num9 = list.Count ^ num7;
			int num10 = num8 & num9;
			bool flag6 = num10 < 0;
			if (flag5 != flag6)
			{
				return null;
			}
			return list;
			IL_00ba:
			List<Tween> list2 = new List<Tween>(num);
			num2 = num;
			obj = num;
			list = list2;
			goto IL_00e5;
		}

		[Token(Token = "0x60002CC")]
		[Address(RVA = "0x1079E74", Offset = "0x1079E74", Length = "0x1E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv32 = *([1EC3A38]);\n\tv33 = *([v32 @ X8_v45]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, playingOnly, fillableList, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20269D2]) = v50;\n\tgoto L_0029;\n\tv57 = *([v53 @ X0_v2 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_0029;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v53, playingOnly, fillableList, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv61 = DG.Tweening.Core.TweenManager;\nL_0029:\n\tv66 = ~v64._requiresActiveReorganization;\n\tif (v66) goto L_0039;\n\tgoto L_0034;\n\tv80 = *([v60 @ X0_v3 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv81 = v80 == 0;\n\tv82 = ~v81;\n\tif (v82) goto L_0034;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v60, playingOnly, fillableList, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0034:\n\tDG.Tweening.Core.TweenManager::ReorganizeActiveTweens();\nL_0039:\n\tgoto L_0041;\n\tv85 = *([v71 @ X0_v4 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv86 = v85 == 0;\n\tv87 = ~v86;\n\tgoto L_0041;\n\tv105 = \"il2cpp_codegen_runtime_class_init\"(v71, playingOnly, fillableList, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv89 = DG.Tweening.Core.TweenManager;\nL_0041:\n\tv176 = v92.totActiveTweens;\n\tv104 = v92.totActiveTweens < 1;\n\tif (v104) goto L_FFFFFFFF;\n\tv107 = *([v88 @ X0_v5 (Il2CppClass<DG.Tweening.Core.TweenManager>)+12F]) & 2;\n\tv108 = v107 == 0;\n\tif (v108) goto L_0055;\n\tv111 = *([v88 @ X0_v5 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]) == 0;\n\tif (v111) goto L_00D9;\nL_0055:\n\tv114 = fillableList == 0;\n\tv115 = ~v114;\n\tif (v115) goto L_006C;\nL_005B:\n\tv181 = new System.Collections.Generic.List`1<DG.Tweening.Tween>();\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::.ctor(v181, v176);\nL_006C:\n\tv202 = v191 < 1;\n\tif (v202) goto L_00BA;\nL_0076:\n\tgoto L_007E;\n\tv352 = *([v301 @ X0_v20 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv353 = v352 == 0;\n\tv354 = ~v353;\n\tgoto L_007E;\n\tv365 = \"il2cpp_codegen_runtime_class_init\"(v301, v297, v296, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv355 = DG.Tweening.Core.TweenManager;\nL_007E:\n\tv348 = v358._activeTweens;\n\tv366 = v286 < v348.Length;\n\tv335 = ~v366;\n\tif (v335) goto L_00E0;\n\tv277 = v348[v286 @ X24_v7 (System.Int32)];\n\tv312 = v277.target != target;\n\tif (v312) goto L_00A8;\n\tv370 = playingOnly == 0;\n\tif (v370) goto L_00A7;\n\tv373 = ~v277.isPlaying;\n\tif (v373) goto L_00A8;\nL_00A7:\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::Add(v156, v348[v286 @ X24_v7 (System.Int32)]);\nL_00A8:\n\tv286 = v286 + 1;\n\tv259 = v286 < v191;\n\tif (v259) goto L_0076;\nL_00BA:\n\tv144 = v156._size - 1;\n\tv142 = v144 < 0;\n\tv138 = v156._size ^ 1;\n\tv136 = v156._size ^ v144;\n\tv134 = v138 & v136;\n\tv132 = v134 < 0;\n\tv306 = v142 == v132;\n\tv130 = ~v306;\n\tv118 = ~v130;\n\tif (v118) goto L_FFFFFFFF;\n\tgoto L_00C9;\nL_00C9:\n\tgoto L_00D5;\nL_00D5:\n\treturn returnVal1;\nL_00D9:\n\tv191 = v175.totActiveTweens;\n\tv249 = fillableList == 0;\n\tv173 = ~v249;\n\tif (v173) goto L_006C;\n\tgoto L_005B;\n\tv351 = new System.NullReferenceException();\nL_00E0:\n\tv364 = new System.IndexOutOfRangeException();\n\tthrow v364;\n\treturn returnVal2;\n// 141 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static List<Tween> GetTweensByTarget(object target, bool playingOnly, List<Tween> fillableList = null)
		{
			//IL_02fc: Expected I, but got O
			//IL_001d: Expected I, but got O
			IntPtr intPtr = (IntPtr)typeof(TweenManager);
			if (_requiresActiveReorganization)
			{
				ReorganizeActiveTweens();
				intPtr = (IntPtr)typeof(TweenManager);
			}
			int num = totActiveTweens;
			int num2;
			List<Tween> list;
			if (totActiveTweens >= 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ X0_v5 (Il2CppClass<DG.Tweening.Core.TweenManager>)+12F]");
				if (0u != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ X0_v5 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						num2 = totActiveTweens;
						bool flag = fillableList == null;
						bool flag2 = !flag;
						list = fillableList;
						if (!flag2)
						{
							num = totActiveTweens;
							goto IL_00b2;
						}
						goto IL_00d5;
					}
				}
				bool flag3 = fillableList == null;
				bool flag4 = !flag3;
				list = fillableList;
				num2 = num;
				if (!flag4)
				{
					goto IL_00b2;
				}
				goto IL_00d5;
			}
			return null;
			IL_00d5:
			if (num2 >= 1)
			{
				int num3 = 0;
				do
				{
					Tween[] activeTweens = _activeTweens;
					if (num3 < activeTweens.Length)
					{
						Tween tween = activeTweens[num3];
						if (tween.target == target && (!playingOnly || tween.isPlaying))
						{
							list.Add(activeTweens[num3]);
						}
						num3++;
						continue;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				while (num3 < num2);
			}
			int num4 = list.Count - 1;
			bool flag5 = num4 < 0;
			int num5 = list.Count ^ 1;
			int num6 = list.Count ^ num4;
			int num7 = num5 & num6;
			bool flag6 = num7 < 0;
			if (flag5 != flag6)
			{
				return null;
			}
			return list;
			IL_00b2:
			List<Tween> list2 = new List<Tween>(num);
			list = list2;
			num2 = num;
			goto IL_00d5;
		}

		[Token(Token = "0x60002CD")]
		[Address(RVA = "0x10781A4", Offset = "0x10781A4", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EAB5E8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20269D3]) = v38;\nL_0015:\n\tt.<active>k__BackingField = 0;\n\tgoto L_0030;\n\tv47 = *([v42 @ X0_v5 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\t// 32 ConditionalJump @b14, v49 @ TEMP_v11\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv51 = DG.Tweening.Core.TweenManager;\nL_0030:\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::Add(v54._KillList, t);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void MarkForKilling(Tween t)
		{
			t.active = false;
			_KillList.Add(t);
		}

		[Token(Token = "0x60002CE")]
		[Address(RVA = "0x1078300", Offset = "0x1078300", Length = "0x260")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EE18D8]);\n\tv21 = *([v20 @ X8_v20]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20269D4]) = v40;\nL_001B:\n\tgoto L_002B;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\t// 31 Jump @b69\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv52 = DG.Tweening.Core.TweenManager;\nL_002B:\n\tv65 = System.Collections.Generic.Dictionary`2<DG.Tweening.Tween, DG.Tweening.Core.TweenLink>::TryGetValue(v55._TweenLinks, t, &v62 @ stack_-28_v3 (DG.Tweening.Core.TweenLink));\n\tv92 = v65 == 0;\n\tif (v92) goto L_004F;\n\tgoto L_0042;\n\tv189 = *([v183 @ X0_v12+E0]);\n\tv190 = v189 == 0;\n\tv191 = ~v190;\n\tif (v191) goto L_0042;\n\tv193 = \"il2cpp_codegen_runtime_class_init\"(v183, v63, v61, v64, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0042:\n\tv137 = UnityEngine.Object::op_Equality(v62.target, 0);\n\tv197 = v137 == 0;\n\tif (v197) goto L_0057;\nL_0048:\n\tt.<active>k__BackingField = 0;\nL_004F:\n\treturn;\nL_0057:\n\tv138 = UnityEngine.GameObject::get_activeInHierarchy(v62.target);\n\tv130 = v62.behaviour;\n\tv62.lastSeenActive = v138;\n\tv209 = v62.behaviour < 0xA;\n\tv124 = ~v209;\n\tv121 = v62.behaviour - 0xA;\n\tv115 = v121 == 0;\n\tv210 = ~v115;\n\tv100 = v124 & v210;\n\tif (v100) goto L_004F;\n\tv165 = 0x1825000 + 0x438;\n\tv167 = *([v165 @ X12_v4 (System.Int32)+v130 @ X10_v2 (DG.Tweening.LinkBehaviour)*4]) + v165;\n\t// 126 IndirectJump v167 @ X10_v4, v138 @ X0_v17 (System.Boolean), v138 @ X0_v17 (System.Boolean), 0, 0, methodof(System.Collections.Generic.Dictionary`2<DG.Tweening.Tween, DG.Tweening.Core.TweenLink>::TryGetValue), v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\tif (TEMP) goto L_004F;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X19+108]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_009C;\n\tgoto L_004F;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_009C;\n\tif (TEMP) goto L_004F;\n\tX0 = *([X21]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0097;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0097;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0097:\n\tX0 = X19;\n\tX0 = DG.Tweening.Core.TweenManager::Play(X0, X1);\n\tgoto L_004F;\n\tif (TEMP) goto L_00A9;\nL_009C:\n\tX0 = *([X21]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00A6;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00A6;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00A6:\n\tX0 = X19;\n\tX0 = DG.Tweening.Core.TweenManager::Pause(X0, X1);\n\tgoto L_004F;\nL_00A9:\n\tTEMP = X8 == 0;\n\tif (TEMP) goto L_004F;\n\tX0 = *([X21]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00B5;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00B5;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00B5:\n\tV0 = -1f;\n\tX1 = 0 | 1;\n\tX0 = X19;\n\tX0 = DG.Tweening.Core.TweenManager::Restart(X0, X1, V0, X2);\n\tgoto L_004F;\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_004F;\n\tgoto L_00E8;\n\tif (TEMP) goto L_004F;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X19+109]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_004F;\n\tX0 = X19;\n\tX1 = 0;\n\tDG.Tweening.TweenExtensions::Complete(X0, X1);\n\tgoto L_004F;\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_004F;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X19+109]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0048;\n\tX0 = X19;\n\tX1 = 0;\n\tDG.Tweening.TweenExtensions::Complete(X0, X1);\n\tgoto L_0048;\n\tif (TEMP) goto L_004F;\n\tX0 = X19;\n\tX1 = 0;\n\tX2 = 0;\n\tDG.Tweening.TweenExtensions::Rewind(X0, X1, X2);\n\tgoto L_004F;\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_004F;\n\tX0 = X19;\n\tX1 = 0;\n\tX2 = 0;\n\tDG.Tweening.TweenExtensions::Rewind(X0, X1, X2);\nL_00E8:\n\tTEMP = X19 == 0;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0048;\n\tv79 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 109 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void EvaluateTweenLink(Tween t)
		{
			//IL_013c: Expected O, but got I
			TweenLink value;
			while (_TweenLinks.TryGetValue(t, out value))
			{
				if (value.target == null)
				{
					t.active = false;
					break;
				}
				bool activeInHierarchy = value.target.activeInHierarchy;
				LinkBehaviour behaviour = value.behaviour;
				value.lastSeenActive = activeInHierarchy;
				bool flag = value.behaviour < LinkBehaviour.RewindAndKillOnDisable;
				bool flag2 = !flag;
				int num = (int)(value.behaviour - 10);
				bool flag3 = num == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					int num2 = 25317376 + 1080;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ X12_v4 (System.Int32)+v130 @ X10_v2 (DG.Tweening.LinkBehaviour)*4]");
					object obj = 0L + (long)num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v167 @ X10_v4 (should have been resolved before IL gen)");
					continue;
				}
				break;
			}
		}

		[Token(Token = "0x60002CF")]
		[Address(RVA = "0x10760D8", Offset = "0x10760D8", Length = "0x364")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EBBD78]);\n\tv23 = *([v22 @ X8_v80]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20269D5]) = v42;\nL_001B:\n\tgoto L_0024;\n\tv49 = *([v45 @ X0_v2 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0024;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv53 = DG.Tweening.Core.TweenManager;\nL_0024:\n\tv58 = ~v56._requiresActiveReorganization;\n\tif (v58) goto L_0034;\n\tgoto L_002F;\n\tv72 = *([v52 @ X0_v3 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv73 = v72 == 0;\n\tv74 = ~v73;\n\tif (v74) goto L_002F;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v52, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002F:\n\tDG.Tweening.Core.TweenManager::ReorganizeActiveTweens();\nL_0034:\n\tgoto L_003D;\n\tv77 = *([v63 @ X0_v4 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tgoto L_003D;\n\tv88 = \"il2cpp_codegen_runtime_class_init\"(v63, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv81 = DG.Tweening.Core.TweenManager;\nL_003D:\n\tv86 = v84.totActiveTweens & 0x80000000;\n\tv87 = v86 == 0;\n\tif (v87) goto L_0054;\n\tDG.Tweening.Core.Debugger::LogAddActiveTweenError(\"totActiveTweens < 0\");\n\tgoto L_0050;\n\tv123 = *([v99 @ X0_v56 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv124 = v123 == 0;\n\tv125 = ~v124;\n\tif (v125) goto L_0050;\n\tv157 = \"il2cpp_codegen_runtime_class_init\"(v99, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv126 = DG.Tweening.Core.TweenManager;\nL_0050:\n\tv97.totActiveTweens = 0;\nL_0054:\n\tt.<active>k__BackingField = 1;\n\tgoto L_0066;\n\tv128 = *([v106 @ X8_v17 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv129 = v128 == 0;\n\tv130 = ~v129;\n\tif (v130) goto L_0066;\n\tv158 = v106;\n\tv159 = \"il2cpp_codegen_runtime_class_init\"(v158, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv136 = DG.Tweening.DOTween;\n\tv133 = DG.Tweening.Core.TweenManager;\nL_0066:\n\tt.updateType = v137.defaultUpdateType;\n\tt.isIndependentUpdate = v139.defaultTimeScaleIndependent;\n\tgoto L_0076;\n\tv160 = *([v132 @ X0_v14 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv161 = v160 == 0;\n\tv162 = ~v161;\n\tgoto L_0076;\n\tv167 = \"il2cpp_codegen_runtime_class_init\"(v132, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv163 = DG.Tweening.Core.TweenManager;\nL_0076:\n\tv166._maxActiveLookupId = v166.totActiveTweens;\n\tt.activeId = v166.totActiveTweens;\n\tv114 = v120._activeTweens;\n\tv147 = v120.totActiveTweens;\n\t// 128 IsInst v152 @ X0_v17, typeof(DG.Tweening.Tween), t @ X0 (DG.Tweening.Tween)\n\tv154 = v152 == 0;\n\tif (v154) goto L_0138;\n\tv114[v147 @ X22_v3 (System.Int32)] = t;\n\tv253 = t.updateType == 2;\n\tif (v253) goto L_00D3;\n\tv262 = t.updateType == 1;\n\tif (v262) goto L_00C0;\n\tv271 = t.updateType == 0;\n\tv272 = ~v271;\n\tif (v272) goto L_00E6;\n\tgoto L_00B6;\n\tv325 = *([v289 @ X0_v45 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv326 = v325 == 0;\n\tv327 = ~v326;\n\tif (v327) goto L_00B6;\n\tv355 = \"il2cpp_codegen_runtime_class_init\"(v289, v145, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv328 = DG.Tweening.Core.TweenManager;\nL_00B6:\n\tv332 = v330.totActiveDefaultTweens + 1;\n\tv330.totActiveDefaultTweens = v332;\n\tv321.hasActiveDefaultTweens = 1;\n\tgoto L_00F7;\nL_00C0:\n\tgoto L_00C9;\n\tv297 = *([v273 @ X0_v37 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv298 = v297 == 0;\n\tv299 = ~v298;\n\tif (v299) goto L_00C9;\n\tv341 = \"il2cpp_codegen_runtime_class_init\"(v273, v145, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv301 = DG.Tweening.Core.TweenManager;\nL_00C9:\n\tv306 = v304.totActiveLateTweens + 1;\n\tv304.totActiveLateTweens = v306;\n\tv307.hasActiveLateTweens = 1;\n\tgoto L_00F7;\nL_00D3:\n\tgoto L_00DC;\n\tv277 = *([v267 @ X0_v33 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv278 = v277 == 0;\n\tv279 = ~v278;\n\tif (v279) goto L_00DC;\n\tv309 = \"il2cpp_codegen_runtime_class_init\"(v267, v145, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv281 = DG.Tweening.Core.TweenManager;\nL_00DC:\n\tv286 = v284.totActiveFixedTweens + 1;\n\tv284.totActiveFixedTweens = v286;\n\tv287.hasActiveFixedTweens = 1;\n\tgoto L_00F7;\nL_00E6:\n\tgoto L_00EF;\n\tv333 = *([v293 @ X0_v41 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv334 = v333 == 0;\n\tv335 = ~v334;\n\tif (v335) goto L_00EF;\n\tv356 = \"il2cpp_codegen_runtime_class_init\"(v293, v145, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv336 = DG.Tweening.Core.TweenManager;\nL_00EF:\n\tv340 = v338.totActiveManualTweens + 1;\n\tv338.totActiveManualTweens = v340;\n\tv320.hasActiveManualTweens = 1;\nL_00F7:\n\tgoto L_0100;\n\tv342 = *([v313 @ X0_v19 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv343 = v342 == 0;\n\tv344 = ~v343;\n\tgoto L_0100;\n\tv357 = \"il2cpp_codegen_runtime_class_init\"(v313, v145, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv346 = DG.Tweening.Core.TweenManager;\nL_0100:\n\tv351 = v349.totActiveTweens + 1;\n\tv349.totActiveTweens = v351;\n\tv354 = t.tweenType == 0;\n\tif (v354) goto L_0116;\n\tgoto L_0111;\n\tv362 = *([v345 @ X0_v20 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv363 = v362 == 0;\n\tv364 = ~v363;\n\tif (v364) goto L_0111;\n\tv382 = \"il2cpp_codegen_runtime_class_init\"(v345, v145, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv366 = DG.Tweening.Core.TweenManager;\nL_0111:\n\tv371 = v369.totActiveSequences + 1;\n\tv369.totActiveSequences = v371;\n\tgoto L_0124;\nL_0116:\n\tgoto L_011F;\n\tv372 = *([v345 @ X0_v20 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv373 = v372 == 0;\n\tv374 = ~v373;\n\tif (v374) goto L_011F;\n\tv390 = \"il2cpp_codegen_runtime_class_init\"(v345, v145, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv376 = DG.Tweening.Core.TweenManager;\nL_011F:\n\tv381 = v379.totActiveTweeners + 1;\n\tv379.totActiveTweeners = v381;\nL_0124:\n\tgoto L_012D;\n\tv391 = *([v384 @ X0_v21 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv392 = v391 == 0;\n\tv393 = ~v392;\n\tgoto L_012D;\n\tv396 = \"il2cpp_codegen_runtime_class_init\"(v384, v145, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv394 = DG.Tweening.Core.TweenManager;\nL_012D:\n\tv242.hasActiveTweens = 1;\n\treturn;\n\tv122 = new System.NullReferenceException();\nL_0138:\n\tv156 = new System.ArrayTypeMismatchException();\n\tgoto L_013D;\n\tv198 = new System.IndexOutOfRangeException();\nL_013D:\n\tthrow v197;\n// 157 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void AddActiveTween(Tween t)
		{
			//IL_014e: Expected I4, but got I8
			if (_requiresActiveReorganization)
			{
				ReorganizeActiveTweens();
			}
			if ((int)(totActiveTweens & 0x80000000L) != 0)
			{
				Debugger.LogAddActiveTweenError("totActiveTweens < 0");
				totActiveTweens = 0;
			}
			t.active = true;
			t.updateType = DOTween.defaultUpdateType;
			t.isIndependentUpdate = DOTween.defaultTimeScaleIndependent;
			_maxActiveLookupId = totActiveTweens;
			t.activeId = totActiveTweens;
			Tween[] activeTweens = _activeTweens;
			int num = totActiveTweens;
			object obj = t as Tween;
			if (obj != null)
			{
				activeTweens[num] = t;
				if (t.updateType != UpdateType.Fixed)
				{
					if (t.updateType != UpdateType.Late)
					{
						if (t.updateType == UpdateType.Normal)
						{
							int num2 = totActiveDefaultTweens + 1;
							totActiveDefaultTweens = num2;
							hasActiveDefaultTweens = true;
						}
						else
						{
							int num3 = totActiveManualTweens + 1;
							totActiveManualTweens = num3;
							hasActiveManualTweens = true;
						}
					}
					else
					{
						int num4 = totActiveLateTweens + 1;
						totActiveLateTweens = num4;
						hasActiveLateTweens = true;
					}
				}
				else
				{
					int num5 = totActiveFixedTweens + 1;
					totActiveFixedTweens = num5;
					hasActiveFixedTweens = true;
				}
				int num6 = totActiveTweens + 1;
				totActiveTweens = num6;
				if (t.tweenType != TweenType.Tweener)
				{
					int num7 = totActiveSequences + 1;
					totActiveSequences = num7;
				}
				else
				{
					int num8 = totActiveTweeners + 1;
					totActiveTweeners = num8;
				}
				hasActiveTweens = true;
				return;
			}
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			ArrayTypeMismatchException ex2 = default(ArrayTypeMismatchException);
			throw ex2;
		}

		[Token(Token = "0x60002D0")]
		[Address(RVA = "0x1077F1C", Offset = "0x1077F1C", Length = "0x288")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv28 = *([1EF67C8]);\n\tv29 = *([v28 @ X8_v48]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv49 = 0 | 1;\n\t*([20269D6]) = v49;\n\tgoto L_0033;\n\tv56 = *([v52 @ X0_v2 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv57 = v56 == 0;\n\tv58 = ~v57;\n\tgoto L_0033;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v52, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv62 = DG.Tweening.Core.TweenManager;\n\tv60 = *([v62 @ X0_v40+12E]);\nL_0033:\n\tv78 = v65.totActiveTweens <= 0;\n\tif (v78) goto L_005D;\n\tgoto L_004B;\n\tv84 = *([v61 @ X0_v3 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv85 = v84 == 0;\n\tv86 = ~v85;\n\tif (v86) goto L_004B;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v61, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv91 = DG.Tweening.Core.TweenManager;\n\tv94 = *([v91 @ X0_v37+B8]);\n\tv89 = *([v91 @ X0_v37+12E]);\nL_004B:\n\tv106 = v93._reorganizeFromId != v93._maxActiveLookupId;\n\tif (v106) goto L_006A;\n\tgoto L_0058;\n\tv194 = *([v90 @ X0_v8 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv195 = v194 == 0;\n\tv196 = ~v195;\n\tif (v196) goto L_0058;\n\tv281 = \"il2cpp_codegen_runtime_class_init\"(v90, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv199 = DG.Tweening.Core.TweenManager;\n\tv200 = *([v199 @ X0_v35+B8]);\n\tv197 = *([v200 @ X8_v43+74]);\nL_0058:\n\tv166 = v93._reorganizeFromId - 1;\n\tv178._maxActiveLookupId = v166;\n\tgoto L_010D;\nL_005D:\n\tgoto L_0066;\n\tv107 = *([v61 @ X0_v3 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv108 = v107 == 0;\n\tv109 = ~v108;\n\tif (v109) goto L_0066;\n\tv122 = \"il2cpp_codegen_runtime_class_init\"(v61, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv112 = DG.Tweening.Core.TweenManager;\n\tv115 = *([v112 @ X0_v7+B8]);\nL_0066:\n\tv114._maxActiveLookupId = 0xFFFFFFFF;\n\tgoto L_010D;\nL_006A:\n\tgoto L_0074;\n\tv201 = *([v90 @ X0_v8 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv202 = v201 == 0;\n\tv203 = ~v202;\n\tif (v203) goto L_0074;\n\tv282 = \"il2cpp_codegen_runtime_class_init\"(v90, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv209 = DG.Tweening.Core.TweenManager;\n\tv212 = *([v209 @ X0_v32+B8]);\n\tv204 = *([v212 @ X8_v41+74]);\n\tv206 = *([v212 @ X8_v41+7C]);\nL_0074:\n\tv213 = v93._reorganizeFromId - 1;\n\tv211._maxActiveLookupId = v213;\n\tv126 = v93._maxActiveLookupId + 1;\n\tv240 = v214._reorganizeFromId + 1;\n\tv227 = *([v317 @ X0_v14 (Il2CppClass<DG.Tweening.Core.TweenManager>)+12F]) >> 1;\n\tv339 = v227 & 1;\n\tv229 = v240 >= v126;\n\tif (v229) goto L_0104;\nL_0089:\n\tv341 = v339 & 1;\n\tv342 = v341 == 0;\n\tif (v342) goto L_0093;\n\tgoto L_0093;\n\tv354 = \"il2cpp_codegen_runtime_class_init\"(v337, v290, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv347 = DG.Tweening.Core.TweenManager;\nL_0093:\n\tv351 = v350._activeTweens;\n\tv355 = v240 < v351.Length;\n\tv356 = ~v355;\n\tif (v356) goto L_011E;\n\tv324 = v351[v240 @ X22_v5 (System.Int32)];\n\tv320 = v351[v240 @ X22_v5 (System.Int32)] == 0;\n\tif (v320) goto L_00F3;\n\tv293 = v266 + v240;\n\tgoto L_00B3;\n\tv437 = *([v317 @ X0_v14 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv438 = v437 == 0;\n\tv439 = ~v438;\n\tif (v439) goto L_00B3;\n\tv448 = \"il2cpp_codegen_runtime_class_init\"(v317, v290, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv440 = DG.Tweening.Core.TweenManager;\n\tv443 = *([v440 @ X0_v28+B8]);\nL_00B3:\n\tv442._maxActiveLookupId = v293;\n\tv324.activeId = v293;\n\tv285 = v396._activeTweens;\n\t// 188 IsInst v390 @ X0_v24, typeof(DG.Tweening.Tween), v351[v240 @ X22_v5 (System.Int32)]\n\tv450 = v293 < v285.Length;\n\tv385 = ~v450;\n\tif (v385) goto L_011E;\n\tv285[v293 @ X25_v8 (System.Int32)] = v351[v240 @ X22_v5 (System.Int32)];\n\tv395 = v453._activeTweens;\n\tv454 = v240 < v395.Length;\n\tv420 = ~v454;\n\tif (v420) goto L_011E;\n\tv395[v240 @ X22_v5 (System.Int32)] = 0;\n\tv318 = DG.Tweening.Core.TweenManager;\n\tv240 = v240 + 1;\n\tv458 = *([v318 @ X0_v26 (Il2CppClass<DG.Tweening.Core.TweenManager>)+12F]) >> 1;\n\tv339 = v458 & 1;\n\tv287 = v240 < v126;\n\tif (v287) goto L_0089;\n\tgoto L_0104;\nL_00F3:\n\tv240 = v240 + 1;\n\tv266 = v266 - 1;\n\tv435 = *([v317 @ X0_v14 (Il2CppClass<DG.Tweening.Core.TweenManager>)+12F]) >> 1;\n\tv339 = v435 & 1;\n\tv286 = v240 < v126;\n\tif (v286) goto L_0089;\nL_0104:\n\tgoto L_010D;\n\tv176 = *([v169 @ X0_v10 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv343 = v176 == 0;\n\tv172 = ~v343;\n\tif (v172) goto L_010D;\n\tv353 = \"il2cpp_codegen_runtime_class_init\"(v169, v132, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv168 = DG.Tweening.Core.TweenManager;\nL_010D:\n\tv181._requiresActiveReorganization = 0;\n\tv183._reorganizeFromId = 0xFFFFFFFF;\n\treturn;\n\tv399 = new System.NullReferenceException();\nL_011E:\n\tv429 = new System.IndexOutOfRangeException();\n\tgoto L_0123;\n\tv446 = new System.ArrayTypeMismatchException();\nL_0123:\n\tthrow v445;\n// 163 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void ReorganizeActiveTweens()
		{
			//IL_0238: Expected I, but got O
			//IL_0026: Expected O, but got I8
			//IL_01d2: Expected O, but got I
			//IL_0154: Expected I, but got O
			//IL_01a2: Expected I, but got O
			IntPtr intPtr = (IntPtr)typeof(TweenManager);
			if (totActiveTweens > 0)
			{
				if (_reorganizeFromId == _maxActiveLookupId)
				{
					int maxActiveLookupId = _reorganizeFromId - 1;
					_maxActiveLookupId = maxActiveLookupId;
				}
				else
				{
					int maxActiveLookupId2 = _reorganizeFromId - 1;
					_maxActiveLookupId = maxActiveLookupId2;
					int num = _maxActiveLookupId + 1;
					int num2 = _reorganizeFromId + 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ X0_v14 (Il2CppClass<DG.Tweening.Core.TweenManager>)+12F]");
					int num3 = 0;
					int num4 = num3 & 1;
					if (num2 < num)
					{
						object obj = 4294967295L;
						IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
						while (true)
						{
							if ((num4 & 1) != 0)
							{
							}
							Tween[] activeTweens = _activeTweens;
							if (num2 < activeTweens.Length)
							{
								Tween tween = activeTweens[num2];
								if (activeTweens[num2] == null)
								{
									num2++;
									obj = (long)(IntPtr)obj - 1L;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ X0_v14 (Il2CppClass<DG.Tweening.Core.TweenManager>)+12F]");
									int num5 = 0;
									num4 = num5 & 1;
									if (num2 >= num)
									{
										break;
									}
									continue;
								}
								int num6 = (tween.activeId = (_maxActiveLookupId = (int)((long)(IntPtr)obj + (long)num2)));
								Tween[] activeTweens2 = _activeTweens;
								object obj2 = activeTweens[num2] as Tween;
								if (num6 < activeTweens2.Length)
								{
									activeTweens2[num6] = activeTweens[num2];
									Tween[] activeTweens3 = _activeTweens;
									if (num2 < activeTweens3.Length)
									{
										activeTweens3[num2] = null;
										IntPtr intPtr2 = (IntPtr)typeof(TweenManager);
										num2++;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ X0_v26 (Il2CppClass<DG.Tweening.Core.TweenManager>)+12F]");
										int num7 = 0;
										num4 = num7 & 1;
										bool flag = num2 < num;
										intPtr = (IntPtr)typeof(TweenManager);
										if (!flag)
										{
											break;
										}
										continue;
									}
								}
							}
							IndexOutOfRangeException ex = new IndexOutOfRangeException();
							throw ex2;
						}
					}
				}
			}
			else
			{
				_maxActiveLookupId = -1;
			}
			_requiresActiveReorganization = false;
			_reorganizeFromId = -1;
		}

		[Token(Token = "0x60002D1")]
		[Address(RVA = "0x1078234", Offset = "0x1078234", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1F02758]);\n\tv25 = *([v24 @ X8_v13]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20269D7]) = v44;\nL_0018:\n\tv127 = tweens._size;\n\tv47 = tweens._size - 1;\n\tv48 = v47 & 0x80000000;\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tif (v50) goto L_004F;\n\tv90 = tweens._size - 2;\n\tgoto L_0026;\nL_0023:\n\tv127 = tweens._size;\n\tv92 = v92 - 1;\n\tv90 = v90 - 1;\nL_0026:\n\tv130 = v92 < v127;\n\tv82 = ~v130;\n\tv58 = ~v82;\n\tif (v58) goto L_0033;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0033:\n\tv156 = tweens._items;\n\tgoto L_0043;\n\tv161 = *([v157 @ X0_v7+E0]);\n\tv162 = v161 == 0;\n\tv163 = ~v162;\n\tif (v163) goto L_0043;\n\tv165 = \"il2cpp_codegen_runtime_class_init\"(v157, v120, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0043:\n\tDG.Tweening.Core.TweenManager::Despawn(v156[v92 @ X21_v4 (System.Int32)], 1);\n\tv167 = v90 & 0x80000000;\n\tv99 = v167 == 0;\n\tif (v99) goto L_0023;\nL_004F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void DespawnActiveTweens(List<Tween> tweens)
		{
			//IL_0037: Expected I4, but got I8
			//IL_00f3: Expected I4, but got I8
			int count = tweens.Count;
			int num = tweens.Count - 1;
			if ((int)(num & 0x80000000L) != 0)
			{
				return;
			}
			int num2 = tweens.Count - 2;
			int num3 = num;
			while (true)
			{
				if (num3 >= count)
				{
					throw new ArgumentOutOfRangeException();
				}
				Tween[] items = tweens._items;
				Despawn(items[num3]);
				if ((int)(num2 & 0x80000000L) == 0)
				{
					count = tweens.Count;
					num3--;
					num2--;
					continue;
				}
				break;
			}
		}

		[Token(Token = "0x60002D2")]
		[Address(RVA = "0x1076A14", Offset = "0x1076A14", Length = "0x520")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1F08250]);\n\tv21 = *([v20 @ X8_v119]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20269D8]) = v40;\nL_0018:\n\tv44 = t.activeId;\n\tgoto L_0030;\n\tv89 = *([v45 @ X0_v8 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv90 = v89 == 0;\n\tv91 = ~v90;\n\tif (v91) goto L_0030;\n\tv134 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv93 = DG.Tweening.Core.TweenManager;\nL_0030:\n\tv108 = v96._totTweenLinks < 1;\n\tif (v108) goto L_003F;\n\tgoto L_003C;\n\tv151 = *([v92 @ X0_v9 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv152 = v151 == 0;\n\tv153 = ~v152;\n\tif (v153) goto L_003C;\n\tv155 = \"il2cpp_codegen_runtime_class_init\"(v92, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_003C:\n\tDG.Tweening.Core.TweenManager::RemoveTweenLink(t);\nL_003F:\n\tt.activeId = 0xFFFFFFFF;\n\tgoto L_004C;\n\tv157 = *([v138 @ X0_v10 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv158 = v157 == 0;\n\tv159 = ~v158;\n\tgoto L_004C;\n\tv173 = \"il2cpp_codegen_runtime_class_init\"(v138, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv161 = DG.Tweening.Core.TweenManager;\nL_004C:\n\tv164._requiresActiveReorganization = 1;\n\tv168 = v166._reorganizeFromId + 1;\n\tv170 = v168 == 0;\n\tif (v170) goto L_0071;\n\tgoto L_006C;\n\tv262 = *([v160 @ X0_v11 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv263 = v262 == 0;\n\tv264 = ~v263;\n\tif (v264) goto L_006C;\n\tv278 = \"il2cpp_codegen_runtime_class_init\"(v160, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv265 = DG.Tweening.Core.TweenManager;\n\tv286 = *([v265 @ X0_v86+B8]);\n\tv266 = *([v286 @ X8_v110+7C]);\nL_006C:\n\tv178 = v166._reorganizeFromId <= t.activeId;\n\tif (v178) goto L_007D;\nL_0071:\n\tgoto L_0079;\n\tv270 = *([v197 @ X0_v80 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv271 = v270 == 0;\n\tv272 = ~v271;\n\tif (v272) goto L_0079;\n\tv285 = \"il2cpp_codegen_runtime_class_init\"(v197, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv274 = DG.Tweening.Core.TweenManager;\nL_0079:\n\tv277._reorganizeFromId = t.activeId;\nL_007D:\n\tgoto L_0085;\n\tv287 = *([v279 @ X0_v12 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv288 = v287 == 0;\n\tv289 = ~v288;\n\tgoto L_0085;\n\tv294 = \"il2cpp_codegen_runtime_class_init\"(v279, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv290 = DG.Tweening.Core.TweenManager;\nL_0085:\n\tv85 = v293._activeTweens;\n\tv295 = t.activeId < v85.Length;\n\tv125 = ~v295;\n\tif (v125) goto L_024A;\n\tv85[v44 @ X21_v3 (System.Int32)] = 0;\n\tv303 = t.updateType == 2;\n\tif (v303) goto L_00EB;\n\tv312 = t.updateType == 1;\n\tif (v312) goto L_0123;\n\tv321 = t.updateType == 0;\n\tv322 = ~v321;\n\tif (v322) goto L_015B;\n\tgoto L_00C6;\n\tv381 = *([v347 @ X0_v71 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv382 = v381 == 0;\n\tv383 = ~v382;\n\tif (v383) goto L_00C6;\n\tv470 = \"il2cpp_codegen_runtime_class_init\"(v347, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv385 = DG.Tweening.Core.TweenManager;\nL_00C6:\n\tv400 = v388.totActiveDefaultTweens < 1;\n\tif (v400) goto L_FFFFFFFF;\n\tgoto L_00D4;\n\tv556 = *([v384 @ X0_v72 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv557 = v556 == 0;\n\tv558 = ~v557;\n\tif (v558) goto L_00D4;\n\tv599 = \"il2cpp_codegen_runtime_class_init\"(v384, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv561 = DG.Tweening.Core.TweenManager;\n\tv563 = *([v561 @ X0_v75+B8]);\n\tv560 = *([v563 @ X8_v101+1C]);\nL_00D4:\n\tv564 = v388.totActiveDefaultTweens - 1;\n\tv562.totActiveDefaultTweens = v564;\n\tv532 = v550.totActiveDefaultTweens < 0;\n\tv529 = v550.totActiveDefaultTweens == 0;\n\tv523 = v550.totActiveDefaultTweens ^ v550.totActiveDefaultTweens;\n\tv520 = v550.totActiveDefaultTweens & v523;\n\tv517 = v520 < 0;\n\tv567 = v532 == v517;\n\tv509 = ~v529;\n\tv512 = v567 & v509;\n\tv550.hasActiveDefaultTweens = v512;\n\tgoto L_01A0;\nL_00EB:\n\tgoto L_00FE;\n\tv327 = *([v317 @ X0_v50 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv328 = v327 == 0;\n\tv329 = ~v328;\n\tif (v329) goto L_00FE;\n\tv375 = \"il2cpp_codegen_runtime_class_init\"(v317, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv331 = DG.Tweening.Core.TweenManager;\nL_00FE:\n\tv346 = v334.totActiveFixedTweens < 1;\n\tif (v346) goto L_FFFFFFFF;\n\tgoto L_010C;\n\tv427 = *([v330 @ X0_v51 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv428 = v427 == 0;\n\tv429 = ~v428;\n\tif (v429) goto L_010C;\n\tv507 = \"il2cpp_codegen_runtime_class_init\"(v330, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv434 = DG.Tweening.Core.TweenManager;\n\tv437 = *([v434 @ X0_v54+B8]);\n\tv432 = *([v437 @ X8_v74+24]);\nL_010C:\n\tv438 = v334.totActiveFixedTweens - 1;\n\tv436.totActiveFixedTweens = v438;\n\tv444 = v439.totActiveFixedTweens < 0;\n\tv445 = v439.totActiveFixedTweens == 0;\n\tv447 = v439.totActiveFixedTweens ^ v439.totActiveFixedTweens;\n\tv448 = v439.totActiveFixedTweens & v447;\n\tv449 = v448 < 0;\n\tv450 = v444 == v449;\n\tv451 = ~v445;\n\tv452 = v450 & v451;\n\tv439.hasActiveFixedTweens = v452;\n\tgoto L_01A0;\nL_0123:\n\tgoto L_0136;\n\tv355 = *([v323 @ X0_v57 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv356 = v355 == 0;\n\tv357 = ~v356;\n\tif (v357) goto L_0136;\n\tv421 = \"il2cpp_codegen_runtime_class_init\"(v323, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv359 = DG.Tweening.Core.TweenManager;\nL_0136:\n\tv374 = v362.totActiveLateTweens < 1;\n\tif (v374) goto L_FFFFFFFF;\n\tgoto L_0144;\n\tv480 = *([v358 @ X0_v58 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv481 = v480 == 0;\n\tv482 = ~v481;\n\tif (v482) goto L_0144;\n\tv580 = \"il2cpp_codegen_runtime_class_init\"(v358, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv487 = DG.Tweening.Core.TweenManager;\n\tv490 = *([v487 @ X0_v61+B8]);\n\tv485 = *([v490 @ X8_v83+20]);\nL_0144:\n\tv491 = v362.totActiveLateTweens - 1;\n\tv489.totActiveLateTweens = v491;\n\tv497 = v492.totActiveLateTweens < 0;\n\tv498 = v492.totActiveLateTweens == 0;\n\tv500 = v492.totActiveLateTweens ^ v492.totActiveLateTweens;\n\tv501 = v492.totActiveLateTweens & v500;\n\tv502 = v501 < 0;\n\tv503 = v497 == v502;\n\tv504 = ~v498;\n\tv505 = v503 & v504;\n\tv492.hasActiveLateTweens = v505;\n\tgoto L_01A0;\nL_015B:\n\tgoto L_016E;\n\tv401 = *([v351 @ X0_v64 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv402 = v401 == 0;\n\tv403 = ~v402;\n\tif (v403) goto L_016E;\n\tv475 = \"il2cpp_codegen_runtime_class_init\"(v351, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv405 = DG.Tweening.Core.TweenManager;\nL_016E:\n\tv420 = v408.totActiveManualTweens < 1;\n\tif (v420) goto L_FFFFFFFF;\n\tgoto L_017C;\n\tv568 = *([v404 @ X0_v65 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv569 = v568 == 0;\n\tv570 = ~v569;\n\tif (v570) goto L_017C;\n\tv600 = \"il2cpp_codegen_runtime_class_init\"(v404, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv573 = DG.Tweening.Core.TweenManager;\n\tv575 = *([v573 @ X0_v68+B8]);\n\tv572 = *([v575 @ X8_v92+28]);\nL_017C:\n\tv576 = v408.totActiveManualTweens - 1;\n\tv574.totActiveManualTweens = v576;\n\tv533 = v551.totActiveManualTweens < 0;\n\tv530 = v551.totActiveManualTweens == 0;\n\tv524 = v551.totActiveManualTweens ^ v551.totActiveManualTweens;\n\tv521 = v551.totActiveManualTweens & v524;\n\tv518 = v521 < 0;\n\tv579 = v533 == v518;\n\tv510 = ~v530;\n\tv513 = v579 & v510;\n\tv551.hasActiveManualTweens = v513;\n\tgoto L_01A0;\n\tgoto L_019B;\n\tgoto L_019B;\n\tgoto L_019B;\nL_019B:\n\tDG.Tweening.Core.Debugger::LogRemoveActiveTweenError(*([v466 @ X8_v23 (System.String)]));\nL_01A0:\n\tgoto L_01A9;\n\tv581 = *([v552 @ X0_v17 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv582 = v581 == 0;\n\tv583 = ~v582;\n\tif (v583) goto L_01A9;\n\tv601 = \"il2cpp_codegen_runtime_class_init\"(v552, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv585 = DG.Tweening.Core.TweenManager;\nL_01A9:\n\tv590 = v588.tot\n// ... truncated")]
		private static void RemoveActiveTween(Tween t)
		{
			//IL_05f0: Expected I4, but got I8
			//IL_0639: Expected I4, but got I8
			//IL_0682: Expected I4, but got I8
			int activeId = t.activeId;
			if (_totTweenLinks >= 1)
			{
				RemoveTweenLink(t);
			}
			t.activeId = -1;
			_requiresActiveReorganization = true;
			if (_reorganizeFromId + 1 == 0 || _reorganizeFromId > t.activeId)
			{
				_reorganizeFromId = t.activeId;
			}
			Tween[] activeTweens = _activeTweens;
			string errorInfo;
			if (t.activeId < activeTweens.Length)
			{
				activeTweens[activeId] = null;
				if (t.updateType != UpdateType.Fixed)
				{
					if (t.updateType != UpdateType.Late)
					{
						if (t.updateType == UpdateType.Normal)
						{
							if (totActiveDefaultTweens < 1)
							{
								errorInfo = "totActiveDefaultTweens < 0";
								goto IL_04e0;
							}
							int num = totActiveDefaultTweens - 1;
							totActiveDefaultTweens = num;
							bool flag = totActiveDefaultTweens < 0;
							bool flag2 = totActiveDefaultTweens == 0;
							int num2 = totActiveDefaultTweens ^ totActiveDefaultTweens;
							int num3 = totActiveDefaultTweens & num2;
							bool flag3 = num3 < 0;
							bool flag4 = flag == flag3;
							bool flag5 = !flag2;
							bool flag6 = flag4 && flag5;
							hasActiveDefaultTweens = flag6;
						}
						else
						{
							if (totActiveManualTweens < 1)
							{
								errorInfo = "totActiveManualTweens < 0";
								goto IL_04e0;
							}
							int num4 = totActiveManualTweens - 1;
							totActiveManualTweens = num4;
							bool flag7 = totActiveManualTweens < 0;
							bool flag8 = totActiveManualTweens == 0;
							int num5 = totActiveManualTweens ^ totActiveManualTweens;
							int num6 = totActiveManualTweens & num5;
							bool flag9 = num6 < 0;
							bool flag10 = flag7 == flag9;
							bool flag11 = !flag8;
							bool flag12 = flag10 && flag11;
							hasActiveManualTweens = flag12;
						}
					}
					else
					{
						if (totActiveLateTweens < 1)
						{
							errorInfo = "totActiveLateTweens < 0";
							goto IL_04e0;
						}
						int num7 = totActiveLateTweens - 1;
						totActiveLateTweens = num7;
						bool flag13 = totActiveLateTweens < 0;
						bool flag14 = totActiveLateTweens == 0;
						int num8 = totActiveLateTweens ^ totActiveLateTweens;
						int num9 = totActiveLateTweens & num8;
						bool flag15 = num9 < 0;
						bool flag16 = flag13 == flag15;
						bool flag17 = !flag14;
						bool flag18 = flag16 && flag17;
						hasActiveLateTweens = flag18;
					}
				}
				else
				{
					if (totActiveFixedTweens < 1)
					{
						errorInfo = "totActiveFixedTweens < 0";
						goto IL_04e0;
					}
					int num10 = totActiveFixedTweens - 1;
					totActiveFixedTweens = num10;
					bool flag19 = totActiveFixedTweens < 0;
					bool flag20 = totActiveFixedTweens == 0;
					int num11 = totActiveFixedTweens ^ totActiveFixedTweens;
					int num12 = totActiveFixedTweens & num11;
					bool flag21 = num12 < 0;
					bool flag22 = flag19 == flag21;
					bool flag23 = !flag20;
					bool flag24 = flag22 && flag23;
					hasActiveFixedTweens = flag24;
				}
				goto IL_04ee;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_04ee:
			int num13 = totActiveTweens - 1;
			totActiveTweens = num13;
			bool flag25 = totActiveTweens < 0;
			bool flag26 = totActiveTweens == 0;
			int num14 = totActiveTweens ^ totActiveTweens;
			int num15 = totActiveTweens & num14;
			bool flag27 = num15 < 0;
			bool flag28 = flag25 == flag27;
			bool flag29 = !flag26;
			bool flag30 = flag28 && flag29;
			hasActiveTweens = flag30;
			if (t.tweenType != TweenType.Tweener)
			{
				int num16 = totActiveSequences - 1;
				totActiveSequences = num16;
			}
			else
			{
				int num17 = totActiveTweeners - 1;
				totActiveTweeners = num17;
			}
			if ((int)(totActiveTweens & 0x80000000L) != 0)
			{
				totActiveTweens = 0;
				Debugger.LogRemoveActiveTweenError("totActiveTweens < 0");
			}
			if ((int)(totActiveTweeners & 0x80000000L) != 0)
			{
				totActiveTweeners = 0;
				Debugger.LogRemoveActiveTweenError("totActiveTweeners < 0");
			}
			if ((int)(totActiveSequences & 0x80000000L) != 0)
			{
				totActiveSequences = 0;
				Debugger.LogRemoveActiveTweenError("totActiveSequences < 0");
			}
			return;
			IL_04e0:
			Debugger.LogRemoveActiveTweenError(errorInfo);
			goto IL_04ee;
		}

		[Token(Token = "0x60002D3")]
		[Address(RVA = "0x10776C8", Offset = "0x10776C8", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = tweens.Length < 1;\n\tif (v19) goto L_0039;\n\tv36 = tweens.Length & 0xFFFFFFFF;\n\tv37 = v36 == 0;\n\tif (v37) goto L_0032;\nL_0019:\n\ttweens[v139 @ X8_v5 (System.Int32)] = 0;\n\tv139 = v139 + 1;\n\tv58 = v139 >= v36;\n\tif (v58) goto L_0039;\n\tv141 = v139 < tweens.Length;\n\tv99 = ~v141;\n\tv91 = ~v99;\n\tif (v91) goto L_0019;\nL_0032:\n\tv100 = new System.IndexOutOfRangeException();\n\tthrow v100;\nL_0039:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void ClearTweenArray(Tween[] tweens)
		{
			//IL_0033: Expected I4, but got I8
			if (tweens.Length < 1)
			{
				return;
			}
			int num = (int)(tweens.Length & 0xFFFFFFFFL);
			if (num != 0)
			{
				int num2 = 0;
				do
				{
					tweens[num2] = null;
					num2++;
					if (num2 >= num)
					{
						return;
					}
				}
				while (num2 < tweens.Length);
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60002D4")]
		[Address(RVA = "0x107643C", Offset = "0x107643C", Length = "0x298")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1F05540]);\n\tv25 = *([v24 @ X8_v43]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20269D9]) = v44;\nL_001C:\n\tgoto L_002B;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002B;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = DG.Tweening.Core.TweenManager;\nL_002B:\n\tgoto L_0034;\n\tv67 = *([v61 @ X8_v7+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tgoto L_0034;\n\tv81 = v61;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v81, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0034:\n\tv76 = v60.maxTweeners * 1.5f;\n\tv80 = UnityEngine.Mathf::Max(v76, 0xC8);\n\tv89 = v86.maxSequences * 1.5f;\n\tv91 = UnityEngine.Mathf::Max(v89, 0x32);\n\tv96 = increaseMode == 2;\n\tif (v96) goto L_0074;\n\tv111 = increaseMode != 1;\n\tif (v111) goto L_0082;\n\tgoto L_0066;\n\tv136 = *([v116 @ X0_v34 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv137 = v136 == 0;\n\tv138 = ~v137;\n\tif (v138) goto L_0066;\n\tv195 = \"il2cpp_codegen_runtime_class_init\"(v116, v84, v85, v29, v30, v31, v32, v33, v89, v35, v36, v37, v38, v39, v40, v41);\n\tv140 = DG.Tweening.Core.TweenManager;\nL_0066:\n\tv145 = v143.maxTweeners + v80;\n\tv143.maxTweeners = v145;\n\tv151 = *([v139 @ X0_v35 (Il2CppClass<DG.Tweening.Core.TweenManager>)+B8]) + 0x50;\n\tSystem.Array::Resize(v151, v147.maxTweeners);\n\tgoto L_00A1;\nL_0074:\n\tgoto L_007E;\n\tv125 = *([v112 @ X0_v25 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv126 = v125 == 0;\n\tv127 = ~v126;\n\tif (v127) goto L_007E;\n\tv171 = \"il2cpp_codegen_runtime_class_init\"(v112, v84, v85, v29, v30, v31, v32, v33, v89, v35, v36, v37, v38, v39, v40, v41);\n\tv129 = DG.Tweening.Core.TweenManager;\nL_007E:\n\tv135 = v132.maxSequences + v91;\n\tv132.maxSequences = v135;\n\tgoto L_00A1;\nL_0082:\n\tv121 = v91 + v80;\n\tgoto L_008F;\n\tv152 = *([v120 @ X0_v29 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv153 = v152 == 0;\n\tv154 = ~v153;\n\tif (v154) goto L_008F;\n\tv196 = \"il2cpp_codegen_runtime_class_init\"(v120, v84, v85, v29, v30, v31, v32, v33, v89, v35, v36, v37, v38, v39, v40, v41);\n\tv156 = DG.Tweening.Core.TweenManager;\nL_008F:\n\tv161 = v159.maxTweeners + v80;\n\tv159.maxTweeners = v161;\n\tv164 = v162.maxSequences + v91;\n\tv162.maxSequences = v164;\n\tv170 = *([v155 @ X0_v30 (Il2CppClass<DG.Tweening.Core.TweenManager>)+B8]) + 0x50;\n\tSystem.Array::Resize(v170, v166.maxTweeners);\nL_00A1:\n\tgoto L_00AB;\n\tv197 = *([v191 @ X0_v10 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv198 = v197 == 0;\n\tv199 = ~v198;\n\tgoto L_00AB;\n\tv215 = \"il2cpp_codegen_runtime_class_init\"(v191, v183, v182, v29, v30, v31, v32, v33, v89, v35, v36, v37, v38, v39, v40, v41);\n\tv201 = DG.Tweening.Core.TweenManager;\nL_00AB:\n\tv207 = v204.maxSequences + v204.maxTweeners;\n\tv204.maxActive = v207;\n\tv208 = DG.Tweening.Core.TweenManager;\n\tv214 = *([v208 @ X8_v14 (Il2CppClass<DG.Tweening.Core.TweenManager>)+B8]) + 0x48;\n\tSystem.Array::Resize(v214, v210.maxActive);\n\tv226 = v189 < 1;\n\tif (v226) goto L_00EC;\n\tgoto L_00D4;\n\tv238 = *([v227 @ X0_v13 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv239 = v238 == 0;\n\tv240 = ~v239;\n\t// 201 ConditionalJump @b49, v240 @ TEMP_v19\n\tv272 = \"il2cpp_codegen_runtime_class_init\"(v227, v212, v213, v29, v30, v31, v32, v33, v89, v35, v36, v37, v38, v39, v40, v41);\n\tv242 = DG.Tweening.Core.TweenManager;\nL_00D4:\n\tv277 = System.Collections.Generic.List`1<DG.Tweening.Tween>::get_Capacity(v245._KillList);\n\tv257 = v277 + v189;\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::set_Capacity(v245._KillList, v257);\n\treturn;\nL_00EC:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 148 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static void IncreaseCapacities(CapacityIncreaseMode increaseMode)
		{
			//IL_0024: Expected I4, but got F4
			//IL_0047: Expected I4, but got F4
			//IL_00c0: Expected I, but got O
			//IL_01ee: Expected I, but got O
			//IL_009b: Expected I, but got O
			float num = (float)maxTweeners * 1.5f;
			int num2 = Mathf.Max((int)num, 200);
			float num3 = (float)maxSequences * 1.5f;
			int num4 = Mathf.Max((int)num3, 50);
			int num6;
			switch (increaseMode)
			{
			case CapacityIncreaseMode.TweenersOnly:
			{
				IntPtr intPtr2 = (IntPtr)typeof(TweenManager);
				int num10 = maxTweeners + num2;
				maxTweeners = num10;
				Array.Resize(ref *(Tween[]*)((isUnityEditor ? 1 : 0) + 80), maxTweeners);
				num6 = num2;
				break;
			}
			default:
			{
				int num7 = num4 + num2;
				IntPtr intPtr = (IntPtr)typeof(TweenManager);
				int num8 = maxTweeners + num2;
				maxTweeners = num8;
				int num9 = maxSequences + num4;
				maxSequences = num9;
				Array.Resize(ref *(Tween[]*)((isUnityEditor ? 1 : 0) + 80), maxTweeners);
				num6 = num7;
				break;
			}
			case CapacityIncreaseMode.SequencesOnly:
			{
				int num5 = maxSequences + num4;
				maxSequences = num5;
				num6 = num4;
				break;
			}
			}
			int num11 = maxSequences + maxTweeners;
			maxActive = num11;
			IntPtr intPtr3 = (IntPtr)typeof(TweenManager);
			Array.Resize(ref *(Tween[]*)((isUnityEditor ? 1 : 0) + 72), maxActive);
			if (num6 >= 1)
			{
				int capacity = _KillList.Capacity;
				int capacity2 = capacity + num6;
				_KillList.Capacity = capacity2;
			}
		}

		[Token(Token = "0x60002D5")]
		[Address(RVA = "0x1079750", Offset = "0x1079750", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EB67A0]);\n\tv23 = *([v22 @ X8_v18]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, isPlayBackwardsOrSmoothRewind, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20269DA]) = v41;\nL_0018:\n\tv44 = t.onRewind == 0;\n\tif (v44) goto L_003C;\n\tv51 = isPlayBackwardsOrSmoothRewind == 0;\n\tif (v51) goto L_003F;\n\tgoto L_0030;\n\tv142 = *([v48 @ X0_v6 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv143 = v142 == 0;\n\tv144 = ~v143;\n\tif (v144) goto L_0030;\n\tv156 = \"il2cpp_codegen_runtime_class_init\"(v48, isPlayBackwardsOrSmoothRewind, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv145 = DG.Tweening.DOTween;\nL_0030:\n\tv65 = v147.rewindCallbackMode == 2;\n\tif (v65) goto L_0054;\nL_003C:\n\treturn;\nL_003F:\n\tgoto L_0048;\n\tv149 = *([v48 @ X0_v6 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv150 = v149 == 0;\n\tv151 = ~v150;\n\tif (v151) goto L_0048;\n\tv159 = \"il2cpp_codegen_runtime_class_init\"(v48, isPlayBackwardsOrSmoothRewind, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv152 = DG.Tweening.DOTween;\nL_0048:\n\tv81 = v155.rewindCallbackMode == 0;\n\tif (v81) goto L_003C;\nL_0054:\n\tDG.Tweening.TweenCallback::Invoke(t.onRewind);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void ManageOnRewindCallbackWhenAlreadyRewinded(Tween t, bool isPlayBackwardsOrSmoothRewind)
		{
			if (t.onRewind == null)
			{
				return;
			}
			if (isPlayBackwardsOrSmoothRewind)
			{
				if (DOTween.rewindCallbackMode != RewindCallbackMode.FireAlways)
				{
					return;
				}
			}
			else if (DOTween.rewindCallbackMode == RewindCallbackMode.FireIfPositionChanged)
			{
				return;
			}
			t.onRewind();
		}
	}
}
