using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening.Core
{
	[Token(Token = "0x20000B6")]
	internal static class TweenManager
	{
		[Token(Token = "0x20000B7")]
		internal enum CapacityIncreaseMode
		{
			[Token(Token = "0x4000249")]
			TweenersAndSequences = 0,
			[Token(Token = "0x400024A")]
			TweenersOnly = 1,
			[Token(Token = "0x400024B")]
			SequencesOnly = 2
		}

		[Token(Token = "0x4000222")]
		private const int _DefaultMaxTweeners = 200;

		[Token(Token = "0x4000223")]
		private const int _DefaultMaxSequences = 50;

		[Token(Token = "0x4000224")]
		private const string _MaxTweensReached = "Max Tweens reached: capacity has automatically been increased from #0 to #1. Use DOTween.SetTweensCapacity to set it manually at startup";

		[Token(Token = "0x4000225")]
		private const float _EpsilonVsTimeCheck = 1E-06f;

		[Token(Token = "0x4000226")]
		internal static bool isUnityEditor;

		[Token(Token = "0x4000227")]
		internal static bool isDebugBuild;

		[Token(Token = "0x4000228")]
		internal static int maxActive;

		[Token(Token = "0x4000229")]
		internal static int maxTweeners;

		[Token(Token = "0x400022A")]
		internal static int maxSequences;

		[Token(Token = "0x400022B")]
		internal static bool hasActiveTweens;

		[Token(Token = "0x400022C")]
		internal static bool hasActiveDefaultTweens;

		[Token(Token = "0x400022D")]
		internal static bool hasActiveLateTweens;

		[Token(Token = "0x400022E")]
		internal static bool hasActiveFixedTweens;

		[Token(Token = "0x400022F")]
		internal static bool hasActiveManualTweens;

		[Token(Token = "0x4000230")]
		internal static int totActiveTweens;

		[Token(Token = "0x4000231")]
		internal static int totActiveDefaultTweens;

		[Token(Token = "0x4000232")]
		internal static int totActiveLateTweens;

		[Token(Token = "0x4000233")]
		internal static int totActiveFixedTweens;

		[Token(Token = "0x4000234")]
		internal static int totActiveManualTweens;

		[Token(Token = "0x4000235")]
		internal static int totActiveTweeners;

		[Token(Token = "0x4000236")]
		internal static int totActiveSequences;

		[Token(Token = "0x4000237")]
		internal static int totPooledTweeners;

		[Token(Token = "0x4000238")]
		internal static int totPooledSequences;

		[Token(Token = "0x4000239")]
		internal static int totTweeners;

		[Token(Token = "0x400023A")]
		internal static int totSequences;

		[Token(Token = "0x400023B")]
		internal static bool isUpdateLoop;

		[Token(Token = "0x400023C")]
		internal static Tween[] _activeTweens;

		[Token(Token = "0x400023D")]
		private static Tween[] _pooledTweeners;

		[Token(Token = "0x400023E")]
		private static readonly Stack<Tween> _PooledSequences;

		[Token(Token = "0x400023F")]
		private static readonly List<Tween> _KillList;

		[Token(Token = "0x4000240")]
		private static readonly Dictionary<Tween, TweenLink> _TweenLinks;

		[Token(Token = "0x4000241")]
		private static int _totTweenLinks;

		[Token(Token = "0x4000242")]
		private static int _maxActiveLookupId;

		[Token(Token = "0x4000243")]
		private static bool _requiresActiveReorganization;

		[Token(Token = "0x4000244")]
		private static int _reorganizeFromId;

		[Token(Token = "0x4000245")]
		private static int _minPooledTweenerId;

		[Token(Token = "0x4000246")]
		private static int _maxPooledTweenerId;

		[Token(Token = "0x4000247")]
		private static bool _despawnAllCalledFromUpdateLoopCallback;

		[Token(Token = "0x600042C")]
		[Address(RVA = "0xC2E1F8", Offset = "0xC2E1F8", Length = "0x1EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0047;\n\tv46 = UnityEngine.Application;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv77 = Il2CppMethodInfo;\n\tv78 = \"il2cpp_codegen_initialize_runtime_metadata\"(v77, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv85 = System.Collections.Generic.Dictionary`2<DG.Tweening.Tween, DG.Tweening.Core.TweenLink>;\n\tv86 = \"il2cpp_codegen_initialize_runtime_metadata\"(v85, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv92 = Il2CppMethodInfo;\n\tv93 = \"il2cpp_codegen_initialize_runtime_metadata\"(v92, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv97 = System.Collections.Generic.List`1<DG.Tweening.Tween>;\n\tv98 = \"il2cpp_codegen_initialize_runtime_metadata\"(v97, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv104 = Il2CppMethodInfo;\n\tv105 = \"il2cpp_codegen_initialize_runtime_metadata\"(v104, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv110 = System.Collections.Generic.Stack`1<DG.Tweening.Tween>;\n\tv111 = \"il2cpp_codegen_initialize_runtime_metadata\"(v110, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv117 = DG.Tweening.Core.TweenManager;\n\tv118 = \"il2cpp_codegen_initialize_runtime_metadata\"(v117, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv123 = DG.Tweening.Tween[];\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v123, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv67 = 1;\n\t*([1A357E9]) = v67;\nL_0047:\n\tv72.maxActive = 4.243991583166E-312d;\n\tv72.maxSequences = 0x32;\n\t// 74 NewArr v75 @ X0_v3 (DG.Tweening.Tween[]), typeof(DG.Tweening.Tween[]), 250\n\tv81._activeTweens = v75;\n\t// 80 NewArr v83 @ X0_v5 (DG.Tweening.Tween[]), typeof(DG.Tweening.Tween[]), 200\n\tv88._pooledTweeners = v83;\n\tv90 = new System.Collections.Generic.Stack`1<DG.Tweening.Tween>();\n\tSystem.Collections.Generic.Stack`1<DG.Tweening.Tween>::.ctor(v90);\n\tv100._PooledSequences = v90;\n\tv102 = new System.Collections.Generic.List`1<DG.Tweening.Tween>();\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::.ctor(v102, 0xFA);\n\tv113._KillList = v102;\n\tv115 = new System.Collections.Generic.Dictionary`2<DG.Tweening.Tween, DG.Tweening.Core.TweenLink>();\n\tSystem.Collections.Generic.Dictionary`2<DG.Tweening.Tween, DG.Tweening.Core.TweenLink>::.ctor(v115, 0xFA);\n\tv127._TweenLinks = v115;\n\tv127._maxActiveLookupId = 0xFFFFFFFF;\n\tv127._reorganizeFromId = -1;\n\tv127._maxPooledTweenerId = 0xFFFFFFFF;\n\tgoto L_007A;\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v128, v120, v119, v50, v51, v52, v53, v54, v126, v56, v57, v58, v59, v60, v61, v62);\nL_007A:\n\tv135 = UnityEngine.Application::get_isEditor();\n\tv143.isUnityEditor = v135;\n\treturn;\n// 96 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static TweenManager()
		{
			//IL_008c: Expected I4, but got F8
			maxActive = 0;
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
			_maxPooledTweenerId = -1;
			bool isEditor = Application.isEditor;
			isUnityEditor = isEditor;
		}

		[Token(Token = "0x600042D")]
		[Address(RVA = "0xCAEA5C", Offset = "0xCAEA5C", Length = "0x578")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tgoto L_002E;\n\tv42 = 0xB3490C(methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_002E:\n\tgoto L_0032;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v51, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv60 = DG.Tweening.Core.TweenManager;\nL_0032:\n\tv62 = v61.totPooledTweeners;\n\tv73 = v61.totPooledTweeners < 1;\n\tif (v73) goto L_00F2;\n\tgoto L_004B;\n\tv91 = \"il2cpp_codegen_runtime_class_init\"(v79, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_004B:\n\tv95 = System.Type::GetTypeFromHandle(Il2CppClass<T1>);\n\tv123 = System.Type::GetTypeFromHandle(Il2CppClass<T2>);\n\tv232 = System.Type::GetTypeFromHandle(Il2CppClass<TPlugOptions>);\n\tgoto L_0062;\n\tv255 = v244;\n\tv256 = \"il2cpp_codegen_runtime_class_init\"(v255, v193, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv259 = DG.Tweening.Core.TweenManager;\nL_0062:\n\tv759 = v260._maxPooledTweenerId;\nL_0066:\n\tgoto L_006D;\n\tv321 = v306;\n\tv322 = \"il2cpp_codegen_runtime_class_init\"(v321, v193, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv327 = DG.Tweening.Core.TweenManager;\n\tv324 = *([v327 @ X8_v81+E0]);\nL_006D:\n\tv197 = v328._minPooledTweenerId - 1;\n\tgoto L_0080;\n\tv396 = v326;\n\tv397 = \"il2cpp_codegen_runtime_class_init\"(v396, v193, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv398 = DG.Tweening.Core.TweenManager;\nL_0080:\n\tv410 = v759 <= v197;\n\tif (v410) goto L_00C7;\n\tv475 = v201._pooledTweeners;\n\tv300 = v475[v759 @ X25_v11 (System.Int32)];\n\tv305 = v475[v759 @ X25_v11 (System.Int32)] == 0;\n\tif (v305) goto L_00B9;\n\tv610 = v300.typeofT1 != v95;\n\tif (v610) goto L_00B9;\n\tv611 = v300.typeofT2 != v123;\n\tif (v611) goto L_00B9;\n\tv620 = v300.typeofTPlugOptions == v232;\n\tif (v620) goto L_0199;\nL_00B9:\n\tv759 = v759 - 1;\n\tgoto L_0066;\nL_00C7:\n\tv141 = v201.totTweeners < v201.maxTweeners;\n\tif (v141) goto L_0172;\n\tgoto L_00D1;\n\tv592 = v218;\n\tv593 = \"il2cpp_codegen_runtime_class_init\"(v592, v193, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv596 = DG.Tweening.Core.TweenManager;\n\tv594 = *([v596 @ X8_v55+B8]);\nL_00D1:\n\tv541 = v531._pooledTweeners;\n\tv62 = v531._maxPooledTweenerId;\n\tv541[v62 @ X9_v1 (System.Int32)] = 0;\n\tv62 = v61._maxPooledTweenerId;\n\tv62 = v62 - 1;\n\tv182 = v61.totPooledTweeners - 1;\n\tv136 = v61.totTweeners - 1;\n\tv61._maxPooledTweenerId = v62;\n\tv61.totPooledTweeners = v182;\n\tv61.totTweeners = v136;\n\tgoto L_0172;\nL_00F2:\n\tgoto L_00F6;\n\tv96 = \"il2cpp_codegen_runtime_class_init\"(v59, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv98 = DG.Tweening.Core.TweenManager;\n\tv100 = *([v98 @ X0_v51+B8]);\nL_00F6:\n\tv62 = v61.maxTweeners;\n\tv103 = v61.maxTweeners - 1;\n\tv114 = v61.totTweeners < v103;\n\tif (v114) goto L_0172;\n\tgoto L_010D;\n\tv233 = \"il2cpp_codegen_runtime_class_init\"(v97, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv248 = DG.Tweening.Core.TweenManager;\n\tv237 = *([v248 @ X8_v35+B8]);\n\tv234 = *([v237 @ X8_v36+8]);\nL_010D:\n\tv238 = v61.maxSequences;\n\tDG.Tweening.Core.TweenManager::IncreaseCapacities(1);\n\tgoto L_012C;\n\tv263 = DG.Tweening.Core.Debugger;\n\tv264 = \"il2cpp_codegen_initialize_runtime_metadata\"(v263, v194, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\t*([1A35757]) = v198;\nL_012C:\n\tv140 = v268._logPriority < 1;\n\tif (v140) goto L_0172;\n\tv312 = System.Int32::ToString(&v62 @ X9_v1 (System.Int32));\n\tv334 = System.Int32::ToString(&v238 @ X8_v17 (System.Int32));\n\tv416 = System.String::Concat(v312, \"/\", v334);\n\tv551 = System.String::Replace(\"Max Tweens reached: capacity has automatically been increased from #0 to #1. Use DOTween.SetTweensCapacity to set it manually at startup\", \"#0\", v416);\n\tgoto L_0153;\n\tv647 = v597;\n\tv648 = \"il2cpp_codegen_runtime_class_init\"(v647, v550, v547, v549, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv651 = DG.Tweening.Core.TweenManager;\nL_0153:\n\tv654 = v650.isUnityEditor + 8;\n\tv655 = System.Int32::ToString(v654);\n\tv664 = v662.isUnityEditor + 0xC;\n\tv665 = System.Int32::ToString(v664);\n\tv534 = System.String::Concat(v655, \"/\", v665);\n\tv207 = System.String::Replace(v551, \"#1\", v534);\n\tDG.Tweening.Core.Debugger::LogWarning(v207, 0);\nL_0172:\n\tgoto L_0174;\n\tv240 = 0xB348B0(v222, v191, v132, v130, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0174:\n\tv242 = new Il2CppClass<DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>>();\n\tDG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>::.ctor(v242);\n\tgoto L_0183;\n\tv313 = \"il2cpp_codegen_runtime_class_init\"(v271, v253, v132, v130, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv315 = DG.Tweening.Core.TweenManager;\nL_0183:\n\tv62 = v61.totTweeners;\n\tv62 = v62 + 1;\n\tv61.totTweeners = v62;\n\tDG.Tweening.Core.TweenManager::AddActiveTween(v242);\nL_0192:\n\treturn v808;\nL_0199:\n\tgoto L_01AA;\n\tv673 = v669;\n\tv674 = 0xB348B0(v673, v669, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv675 = v674;\nL_01AA:\n\tgoto L_FFFFFFFF;\n\tv500 = v500_asT == 0;\n\tif (v500) goto L_0248;\n\tgoto L_01C2;\n\tv688 = \"il2cpp_codegen_runtime_class_init\"(v684, v639, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_01C2:\n\tDG.Tweening.Core.TweenManager::AddActiveTween(v475[v759 @ X25_v11 (System.Int32)]);\n\tv540 = v61._pooledTweeners;\n\tv540[v759 @ X25_v11 (System.Int32)] = 0;\n\tv694 = DG.Tweening.Core.TweenManager;\n\tv61 = *([v694 @ X0_v71 (Il2CppClass<DG.Tweening.Core.TweenManager>)+B8]);\n\tv62 = v61._maxPooledTweenerId;\n\tv702 = v61._maxPooledTweenerId == v61._minPooledTweenerId;\n\tv707 = v61._maxPooledTweenerId != v61._minPooledTweenerId;\n\tif (v707) goto L_FFFFFFFF;\n\tgoto L_01E9;\nL_01E9:\n\tif (v702) goto L_FFFFFFFF;\n\tv712 = *([v694 @ X0_v71 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]) == 0;\n\tif (v712) goto L_0208;\n\tv756 = v62 != v759;\n\tif (v756) goto L_021E;\nL_01F8:\n\tv62 = v61._maxPooledTweenerId;\n\tv62 = v62 - 1;\n\tv61._maxPooledTweenerId = v62;\nL_01FF:\n\tgoto L_0203;\n\tv824 = \"il2cpp_codegen_runtime_class_init\"(v773, v373, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv825 = DG.Tweening.Core.TweenManager;\nL_0203:\n\tv62 = v61.totPooledTweeners;\n\tv62 = v62 - 1;\n\tv61.totPooledTweeners = v62;\n\tgoto L_0192;\nL_0208:\n\tv806 = DG.Tweening.Core.TweenManager;\n\tv61 = *([v806 @ X0_v82 (Il2CppClass<DG.Tweening.Core.TweenManager>)+B8]);\n\tv62 = *([v806 @ X0_v82 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv807 = *([v806 @ X0_v82 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]) == 0;\n\tif (v807) goto L_023D;\n\tv795 = v61._maxPooledTweenerId == v759;\n\tv785 = v61._maxPooledTweenerId != v759;\n\tif (v785) goto L_021D;\n\tgoto L_021D;\nL_021D:\n\tif (v795) goto L_01F8;\nL_021E:\n\tv61 = v61 + 0x80;\n\tv62 = v61._minPooledTweenerId;\n\tv760 = v61._minPooledTweenerId != v759;\n\tif (v760) goto L_01FF;\n\tgoto L_0234;\n\tv831 = \"il2cpp_codegen_runtime_class_init\"(v774, v373, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv833 = DG.Tweening.Core.TweenManager;\n\tv838 = *([v833 @ X0_v80+B8]);\n\tv834 = v838 + 0x80;\n\tv832 = *([v834 @ X8_v76]);\nL_0234:\n\tv62 = v759 + 1;\n\t*([v61 @ X8_v4 (Il2CppStaticFields<DG.Tweening.Core.TweenManager>)]) = v62;\n\tgoto L_01FF;\nL_023D:\n\tv794 = v61._maxPooledTweenerId == v759;\n\tif (v794) goto L_01F8;\n\tgoto L_021E;\n\tv542 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_0248:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 413 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe static TweenerCore<T1, T2, TPlugOptions> GetTweener<T1, T2, TPlugOptions>() where TPlugOptions : struct, IPlugOptions
		{
			//IL_02c8: Expected I, but got O
			//IL_03a2: Expected I, but got O
			int num = totPooledTweeners;
			int num2;
			Tween[] pooledTweeners;
			if (totPooledTweeners >= 1)
			{
				Type typeFromHandle = typeof(T1);
				Type typeFromHandle2 = typeof(T2);
				Type typeFromHandle3 = typeof(TPlugOptions);
				num2 = _maxPooledTweenerId;
				while (true)
				{
					int num3 = _minPooledTweenerId - 1;
					if (num2 <= num3)
					{
						break;
					}
					pooledTweeners = _pooledTweeners;
					Tween tween = pooledTweeners[num2];
					if (pooledTweeners[num2] == null || (object)tween.typeofT1 != typeFromHandle || (object)tween.typeofT2 != typeFromHandle2 || (object)tween.typeofTPlugOptions != typeFromHandle3)
					{
						num2--;
						continue;
					}
					goto IL_0254;
				}
				if (totTweeners >= maxTweeners)
				{
					Tween[] pooledTweeners2 = _pooledTweeners;
					num = _maxPooledTweenerId;
					pooledTweeners2[num] = null;
					num = _maxPooledTweenerId;
					num--;
					int num4 = totPooledTweeners - 1;
					int num5 = totTweeners - 1;
					_maxPooledTweenerId = num;
					totPooledTweeners = num4;
					totTweeners = num5;
				}
			}
			else
			{
				num = maxTweeners;
				int num6 = maxTweeners - 1;
				if (totTweeners >= num6)
				{
					int num7 = maxSequences;
					IncreaseCapacities(CapacityIncreaseMode.TweenersOnly);
					if (Debugger._logPriority >= 1)
					{
						string text = num.ToString();
						string text2 = num7.ToString();
						string newValue = text + "/" + text2;
						string text3 = "Max Tweens reached: capacity has automatically been increased from #0 to #1. Use DOTween.SetTweensCapacity to set it manually at startup".Replace("#0", newValue);
						int num8 = (isUnityEditor ? 1 : 0) + 8;
						string text4 = ((int*)num8)->ToString();
						int num9 = (isUnityEditor ? 1 : 0) + 12;
						string text5 = ((int*)num9)->ToString();
						string newValue2 = text4 + "/" + text5;
						string message = text3.Replace("#1", newValue2);
						Debugger.LogWarning(message);
					}
				}
			}
			Tween tween2 = new TweenerCore<T1, T2, TPlugOptions>();
			num = totTweeners;
			num++;
			totTweeners = num;
			AddActiveTween(tween2);
			Tween result = tween2;
			goto IL_024a;
			IL_024a:
			return (TweenerCore<T1, T2, TPlugOptions>)result;
			IL_0254:
			TweenerCore<T1, T2, TPlugOptions> tweenerCore = pooledTweeners[num2] as TweenerCore<T1, T2, TPlugOptions>;
			if (tweenerCore != null)
			{
				AddActiveTween(pooledTweeners[num2]);
				Tween[] pooledTweeners3 = _pooledTweeners;
				pooledTweeners3[num2] = null;
				nint num10 = (nint)typeof(TweenManager);
				nint num11 = (isUnityEditor ? 1 : 0);
				num = _maxPooledTweenerId;
				bool flag = _maxPooledTweenerId == _minPooledTweenerId;
				result = ((_maxPooledTweenerId != _minPooledTweenerId) ? pooledTweeners[num2] : null);
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v694 @ X0_v71 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]");
					if ((nint)0 != 0)
					{
						if (num == num2)
						{
							goto IL_036f;
						}
					}
					else
					{
						nint num12 = (nint)typeof(TweenManager);
						num11 = (isUnityEditor ? 1 : 0);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v806 @ X0_v82 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]");
						num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v806 @ X0_v82 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]");
						if ((nint)0 != 0)
						{
							bool flag2 = _maxPooledTweenerId == num2;
							if (_maxPooledTweenerId == num2)
							{
								result = null;
							}
							if (flag2)
							{
								goto IL_036f;
							}
						}
						else
						{
							if (_maxPooledTweenerId == num2)
							{
								goto IL_036f;
							}
							num11 = (isUnityEditor ? 1 : 0);
						}
					}
					num11 += 128;
					num = _minPooledTweenerId;
					if (_minPooledTweenerId == num2)
					{
						num = num2 + 1;
						num11 = num;
					}
					goto IL_05fd;
				}
				goto IL_0664;
			}
			return (TweenerCore<T1, T2, TPlugOptions>)(object)new InvalidCastException();
			IL_0664:
			result = pooledTweeners[num2];
			goto IL_05fd;
			IL_05fd:
			num = totPooledTweeners;
			num--;
			totPooledTweeners = num;
			goto IL_024a;
			IL_036f:
			num = _maxPooledTweenerId;
			num--;
			_maxPooledTweenerId = num;
			goto IL_0664;
		}

		[Token(Token = "0x600042E")]
		[Address(RVA = "0xC2E3E4", Offset = "0xC2E3E4", Length = "0x2E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv20 = DG.Tweening.Sequence;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv49 = Il2CppMethodInfo;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv66 = DG.Tweening.Core.TweenManager;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv130 = \"#1\";\n\tv131 = \"il2cpp_codegen_initialize_runtime_metadata\"(v130, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv233 = \"/\";\n\tv234 = \"il2cpp_codegen_initialize_runtime_metadata\"(v233, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv283 = \"#0\";\n\tv284 = \"il2cpp_codegen_initialize_runtime_metadata\"(v283, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv306 = \"Max Tweens reached: capacity has automatically been increased from #0 to #1. Use DOTween.SetTweensCapacity to set it manually at startup\";\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v306, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv41 = 1;\n\t*([1A357EA]) = v41;\nL_0026:\n\tv42 = DG.Tweening.Core.TweenManager;\n\tv47 = *([v42 @ X0_v2 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]) == 0;\n\tif (v47) goto L_0061;\n\tv52 = v51.totPooledSequences;\n\tv63 = v51.totPooledSequences < 1;\n\tif (v63) goto L_0070;\nL_0041:\n\tv135 = System.Collections.Generic.Stack`1<DG.Tweening.Tween>::Pop(v51._PooledSequences);\n\tv236 = v135 == 0;\n\tif (v236) goto L_0053;\n\tv248 = *([v135 @ X0_v52 (DG.Tweening.Tween)]) != DG.Tweening.Sequence;\n\tif (v248) goto L_0102;\nL_0053:\n\tDG.Tweening.Core.TweenManager::AddActiveTween(v135);\n\tv52 = v51.totPooledSequences;\n\tv52 = v52 - 1;\n\tv51.totPooledSequences = v52;\n\tgoto L_00FF;\nL_0061:\n\tgoto L_006E;\n\tv228 = \"il2cpp_codegen_runtime_class_init\"(v126, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv229 = DG.Tweening.Core.TweenManager;\n\tv230 = *([v229 @ X0_v49+B8]);\nL_006E:\n\tv69 = v51.totPooledSequences >= 1;\n\tif (v69) goto L_0041;\nL_0070:\n\tv52 = v51.maxSequences;\n\tv114 = v51.maxSequences - 1;\n\tv125 = v51.totSequences < v114;\n\tif (v125) goto L_00E6;\n\tgoto L_0087;\n\tv273 = \"il2cpp_codegen_runtime_class_init\"(v108, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv298 = DG.Tweening.Core.TweenManager;\n\tv277 = *([v298 @ X8_v32+B8]);\n\tv274 = *([v277 @ X8_v33+C]);\nL_0087:\n\tv278 = v51.maxTweeners;\n\tDG.Tweening.Core.TweenManager::IncreaseCapacities(2);\n\tgoto L_00A5;\n\tv364 = DG.Tweening.Core.Debugger;\n\tv365 = \"il2cpp_codegen_initialize_runtime_metadata\"(v364, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv367 = 1;\n\t*([1A35757]) = v367;\nL_00A5:\n\tv160 = v371._logPriority < 1;\n\tif (v160) goto L_00E6;\n\tv387 = System.Int32::ToString(&v278 @ X8_v12 (System.Int32));\n\tv390 = System.Int32::ToString(&v52 @ X9_v18 (System.Int32));\n\tv181 = System.String::Concat(v387, \"/\", v390);\n\tv401 = System.String::Replace(\"Max Tweens reached: capacity has automatically been increased from #0 to #1. Use DOTween.SetTweensCapacity to set it manually at startup\", \"#0\", v181);\n\tgoto L_00CC;\n\tv405 = v402;\n\tv406 = \"il2cpp_codegen_runtime_class_init\"(v405, v400, v397, v399, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv409 = DG.Tweening.Core.TweenManager;\nL_00CC:\n\tv412 = v408.isUnityEditor + 8;\n\tv413 = System.Int32::ToString(v412);\n\tv416 = v414.isUnityEditor + 0xC;\n\tv417 = System.Int32::ToString(v416);\n\tv182 = System.String::Concat(v413, \"/\", v417);\n\tv217 = System.String::Replace(v401, \"#1\", v182);\n\tDG.Tweening.Core.Debugger::LogWarning(v217, 0);\nL_00E6:\n\tv227 = new DG.Tweening.Sequence();\n\tDG.Tweening.Sequence::.ctor(v227);\n\tgoto L_00F3;\n\tv374 = \"il2cpp_codegen_runtime_class_init\"(v301, v280, v200, v198, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv376 = DG.Tweening.Core.TweenManager;\nL_00F3:\n\tv52 = v51.totSequences;\n\tv52 = v52 + 1;\n\tv51.totSequences = v52;\n\tDG.Tweening.Core.TweenManager::AddActiveTween(v227);\nL_00FF:\n\treturn v384;\n\tthrow System.NullReferenceException;\nL_0102:\n\treturnVal1 = new System.InvalidCastException();\n\treturn returnVal1;\n// 175 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe static Sequence GetSequence()
		{
			//IL_01a8: Expected I, but got O
			nint num = (nint)typeof(TweenManager);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X0_v2 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]");
			int num2;
			if ((nint)0 != 0)
			{
				num2 = totPooledSequences;
				if (totPooledSequences >= 1)
				{
					goto IL_002c;
				}
			}
			else if (totPooledSequences >= 1)
			{
				goto IL_002c;
			}
			num2 = maxSequences;
			int num3 = maxSequences - 1;
			if (totSequences >= num3)
			{
				int num4 = maxTweeners;
				IncreaseCapacities(CapacityIncreaseMode.SequencesOnly);
				if (Debugger._logPriority >= 1)
				{
					string text = num4.ToString();
					string text2 = num2.ToString();
					string newValue = text + "/" + text2;
					string text3 = "Max Tweens reached: capacity has automatically been increased from #0 to #1. Use DOTween.SetTweensCapacity to set it manually at startup".Replace("#0", newValue);
					int num5 = (isUnityEditor ? 1 : 0) + 8;
					string text4 = ((int*)num5)->ToString();
					int num6 = (isUnityEditor ? 1 : 0) + 12;
					string text5 = ((int*)num6)->ToString();
					string newValue2 = text4 + "/" + text5;
					string message = text3.Replace("#1", newValue2);
					Debugger.LogWarning(message);
				}
			}
			Sequence sequence = new Sequence();
			num2 = totSequences;
			num2++;
			totSequences = num2;
			AddActiveTween(sequence);
			return sequence;
			IL_002c:
			Tween tween = _PooledSequences.Pop();
			if (tween == null || (object)tween.GetType() == typeof(Sequence))
			{
				AddActiveTween(tween);
				num2 = totPooledSequences;
				num2--;
				totPooledSequences = num2;
				return (Sequence)tween;
			}
			return (Sequence)(object)new InvalidCastException();
		}

		[Token(Token = "0x600042F")]
		[Address(RVA = "0xC2EBC0", Offset = "0xC2EBC0", Length = "0x244")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = DG.Tweening.Core.TweenManager;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, updateType, isIndependentUpdate, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A357EB]) = v39;\nL_0018:\n\tv43 = ~t.<active>k__BackingField;\n\tif (v43) goto L_0026;\n\tv55 = t.updateType != updateType;\n\tif (v55) goto L_0035;\nL_0026:\n\tt.updateType = updateType;\n\tt.isIndependentUpdate = isIndependentUpdate;\nL_002E:\n\treturn;\nL_0035:\n\tv81 = t.updateType == 2;\n\tif (v81) goto L_0066;\n\tv172 = t.updateType == 1;\n\tif (v172) goto L_0080;\n\tv181 = t.updateType == 0;\n\tv182 = ~v181;\n\tif (v182) goto L_009A;\n\tgoto L_0051;\n\tv272 = \"il2cpp_codegen_runtime_class_init\"(v206, updateType, isIndependentUpdate, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv273 = DG.Tweening.Core.TweenManager;\nL_0051:\n\tv275 = v270.totActiveDefaultTweens - 1;\n\tv257 = v275 < 0;\n\tv254 = v275 == 0;\n\tv248 = v275 ^ v275;\n\tv245 = v275 & v248;\n\tv242 = v245 < 0;\n\tv270.totActiveDefaultTweens = v275;\n\tv277 = v257 == v242;\n\tv234 = ~v254;\n\tv239 = v277 & v234;\n\tv270.hasActiveDefaultTweens = v239;\n\tgoto L_00B3;\nL_0066:\n\tgoto L_006B;\n\tv187 = \"il2cpp_codegen_runtime_class_init\"(v177, updateType, isIndependentUpdate, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv189 = DG.Tweening.Core.TweenManager;\nL_006B:\n\tv192 = v190.totActiveFixedTweens - 1;\n\tv196 = v192 < 0;\n\tv197 = v192 == 0;\n\tv199 = v192 ^ v192;\n\tv200 = v192 & v199;\n\tv201 = v200 < 0;\n\tv190.totActiveFixedTweens = v192;\n\tv202 = v196 == v201;\n\tv203 = ~v197;\n\tv204 = v202 & v203;\n\tv190.hasActiveFixedTweens = v204;\n\tgoto L_00B3;\nL_0080:\n\tgoto L_0085;\n\tv214 = \"il2cpp_codegen_runtime_class_init\"(v183, updateType, isIndependentUpdate, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv216 = DG.Tweening.Core.TweenManager;\nL_0085:\n\tv219 = v217.totActiveLateTweens - 1;\n\tv223 = v219 < 0;\n\tv224 = v219 == 0;\n\tv226 = v219 ^ v219;\n\tv227 = v219 & v226;\n\tv228 = v227 < 0;\n\tv217.totActiveLateTweens = v219;\n\tv229 = v223 == v228;\n\tv230 = ~v224;\n\tv231 = v229 & v230;\n\tv217.hasActiveLateTweens = v231;\n\tgoto L_00B3;\nL_009A:\n\tgoto L_009F;\n\tv278 = \"il2cpp_codegen_runtime_class_init\"(v210, updateType, isIndependentUpdate, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv279 = DG.Tweening.Core.TweenManager;\nL_009F:\n\tv281 = v269.totActiveManualTweens - 1;\n\tv256 = v281 < 0;\n\tv253 = v281 == 0;\n\tv247 = v281 ^ v281;\n\tv244 = v281 & v247;\n\tv241 = v244 < 0;\n\tv269.totActiveManualTweens = v281;\n\tv283 = v256 == v241;\n\tv233 = ~v253;\n\tv238 = v283 & v233;\n\tv269.hasActiveManualTweens = v238;\nL_00B3:\n\tv117 = updateType == 2;\n\tt.updateType = updateType;\n\tt.isIndependentUpdate = isIndependentUpdate;\n\tif (v117) goto L_00DA;\n\tv116 = updateType == 1;\n\tif (v116) goto L_00E9;\n\tv287 = updateType == 0;\n\tv288 = ~v287;\n\tif (v288) goto L_00F8;\n\tgoto L_00D3;\n\tv306 = \"il2cpp_codegen_runtime_class_init\"(v264, updateType, isIndependentUpdate, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv307 = DG.Tweening.Core.TweenManager;\nL_00D3:\n\tv138.hasActiveDefaultTweens = 1;\n\tv97 = v138.totActiveDefaultTweens + 1;\n\tv138.totActiveDefaultTweens = v97;\n\tgoto L_002E;\nL_00DA:\n\tgoto L_00E2;\n\tv291 = \"il2cpp_codegen_runtime_class_init\"(v264, updateType, isIndependentUpdate, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv292 = DG.Tweening.Core.TweenManager;\nL_00E2:\n\tv139.hasActiveFixedTweens = 1;\n\tv98 = v139.totActiveFixedTweens + 1;\n\tv139.totActiveFixedTweens = v98;\n\tgoto L_002E;\nL_00E9:\n\tgoto L_00F1;\n\tv300 = \"il2cpp_codegen_runtime_class_init\"(v264, updateType, isIndependentUpdate, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv301 = DG.Tweening.Core.TweenManager;\nL_00F1:\n\tv140.hasActiveLateTweens = 1;\n\tv99 = v140.totActiveLateTweens + 1;\n\tv140.totActiveLateTweens = v99;\n\tgoto L_002E;\nL_00F8:\n\tgoto L_0100;\n\tv311 = \"il2cpp_codegen_runtime_class_init\"(v264, updateType, isIndependentUpdate, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv312 = DG.Tweening.Core.TweenManager;\nL_0100:\n\tv141.hasActiveManualTweens = 1;\n\tv100 = v141.totActiveManualTweens + 1;\n\tv141.totActiveManualTweens = v100;\n\tgoto L_002E;\n\tthrow System.NullReferenceException;\n\treturn;\n// 145 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
						bool flag = num < 0;
						bool flag2 = num == 0;
						int num2 = num ^ num;
						int num3 = num & num2;
						bool flag3 = num3 < 0;
						totActiveDefaultTweens = num;
						bool flag4 = flag == flag3;
						bool flag5 = !flag2;
						bool flag6 = flag4 && flag5;
						hasActiveDefaultTweens = flag6;
					}
					else
					{
						int num4 = totActiveManualTweens - 1;
						bool flag7 = num4 < 0;
						bool flag8 = num4 == 0;
						int num5 = num4 ^ num4;
						int num6 = num4 & num5;
						bool flag9 = num6 < 0;
						totActiveManualTweens = num4;
						bool flag10 = flag7 == flag9;
						bool flag11 = !flag8;
						bool flag12 = flag10 && flag11;
						hasActiveManualTweens = flag12;
					}
				}
				else
				{
					int num7 = totActiveLateTweens - 1;
					bool flag13 = num7 < 0;
					bool flag14 = num7 == 0;
					int num8 = num7 ^ num7;
					int num9 = num7 & num8;
					bool flag15 = num9 < 0;
					totActiveLateTweens = num7;
					bool flag16 = flag13 == flag15;
					bool flag17 = !flag14;
					bool flag18 = flag16 && flag17;
					hasActiveLateTweens = flag18;
				}
			}
			else
			{
				int num10 = totActiveFixedTweens - 1;
				bool flag19 = num10 < 0;
				bool flag20 = num10 == 0;
				int num11 = num10 ^ num10;
				int num12 = num10 & num11;
				bool flag21 = num12 < 0;
				totActiveFixedTweens = num10;
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
					hasActiveDefaultTweens = true;
					int num15 = totActiveDefaultTweens + 1;
					totActiveDefaultTweens = num15;
					break;
				}
				case UpdateType.Late:
				{
					hasActiveLateTweens = true;
					int num14 = totActiveLateTweens + 1;
					totActiveLateTweens = num14;
					break;
				}
				default:
				{
					hasActiveManualTweens = true;
					int num13 = totActiveManualTweens + 1;
					totActiveManualTweens = num13;
					break;
				}
				}
			}
			else
			{
				hasActiveFixedTweens = true;
				int num16 = totActiveFixedTweens + 1;
				totActiveFixedTweens = num16;
			}
		}

		[Token(Token = "0x6000430")]
		[Address(RVA = "0xC2EE04", Offset = "0xC2EE04", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = DG.Tweening.Core.TweenManager;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A357EC]) = v37;\nL_0017:\n\tgoto L_001F;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\tDG.Tweening.Core.TweenManager::RemoveActiveTween(t);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void AddActiveTweenToSequence(Tween t)
		{
			RemoveActiveTween(t);
		}

		[Token(Token = "0x6000431")]
		[Address(RVA = "0xC2F2D8", Offset = "0xC2F2D8", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = Il2CppMethodInfo;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv47 = DG.Tweening.Core.TweenManager;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv41 = 1;\n\t*([1A357ED]) = v41;\nL_001B:\n\tgoto L_FFFFFFFF;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v42, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv50 = DG.Tweening.Core.TweenManager;\nL_0026:\n\tgoto L_002E;\n\tv107 = \"il2cpp_codegen_runtime_class_init\"(v98, v64, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv111 = DG.Tweening.Core.TweenManager;\n\tv109 = *([v111 @ X0_v28+E0]);\nL_002E:\n\tgoto L_0032;\n\tv116 = \"il2cpp_codegen_runtime_class_init\"(v110, v64, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv118 = DG.Tweening.Core.TweenManager;\n\tv120 = *([v118 @ X0_v26+B8]);\nL_0032:\n\tv97 = v119._activeTweens;\n\tv121 = v112._maxActiveLookupId + 1;\n\tv60 = v56 >= v121;\n\tif (v60) goto L_006A;\n\tv172 = v97[v56 @ X23_v2 (System.Int32)] == 0;\n\tif (v172) goto L_005B;\n\tgoto L_0059;\n\tv220 = \"il2cpp_codegen_runtime_class_init\"(v117, v64, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0059:\n\tDG.Tweening.Core.TweenManager::Despawn(v97[v56 @ X23_v2 (System.Int32)], 0);\nL_005B:\n\tv56 = v56 + 1;\n\tgoto L_0026;\nL_006A:\n\tv138 = v97.Length < 1;\n\tif (v138) goto L_0075;\n\tv173 = v97 + 0x20;\n\tv174 = v97.Length & 0xFFFFFFFF;\n\tv175 = v174 << 3;\n\tv177 = 0x1854F20(v173, 0, v175, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0075:\n\tv167.hasActiveManualTweens = 0;\n\tv167.hasActiveTweens = 0;\n\tv167.totActiveLateTweens = 0;\n\tv167.totActiveManualTweens = 0;\n\tv167.totActiveTweens = 0;\n\tv167.totActiveSequences = 0;\n\tv167._reorganizeFromId = 0xFFFFFFFF;\n\tv167._maxActiveLookupId = 0xFFFFFFFF;\n\tv167._requiresActiveReorganization = 0;\n\tSystem.Collections.Generic.Dictionary`2<DG.Tweening.Tween, DG.Tweening.Core.TweenLink>::Clear(v167._TweenLinks);\n\tv224._totTweenLinks = 0;\n\tv226 = ~v224.isUpdateLoop;\n\tif (v226) goto L_0099;\n\tgoto L_0090;\n\tv234 = \"il2cpp_codegen_runtime_class_init\"(v223, v196, v136, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv236 = DG.Tweening.Core.TweenManager;\n\tv235 = *([v236 @ X8_v13+B8]);\nL_0090:\n\tv233._despawnAllCalledFromUpdateLoopCallback = 1;\nL_0099:\n\treturn v51.totActiveTweens;\n\tv162 = new System.IndexOutOfRangeException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int DespawnAll()
		{
			//IL_007a: Expected O, but got I
			//IL_008e: Expected I4, but got I8
			int num = 0;
			Tween[] activeTweens;
			while (true)
			{
				activeTweens = _activeTweens;
				int num2 = _maxActiveLookupId + 1;
				if (num >= num2)
				{
					break;
				}
				if (activeTweens[num] != null)
				{
					Despawn(activeTweens[num], modifyActiveLists: false);
				}
				num++;
			}
			if (activeTweens.Length >= 1)
			{
				object obj = (nint)activeTweens + 32;
				int num3 = (int)(activeTweens.Length & 0xFFFFFFFFL);
				int num4 = num3 << 3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F20 (native memset)");
			}
			hasActiveManualTweens = false;
			hasActiveTweens = false;
			totActiveLateTweens = 0;
			totActiveManualTweens = 0;
			totActiveTweens = 0;
			totActiveSequences = 0;
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

		[Token(Token = "0x6000432")]
		[Address(RVA = "0xC2F468", Offset = "0xC2F468", Length = "0x4D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv24 = Il2CppMethodInfo;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, modifyActiveLists, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv46 = Il2CppMethodInfo;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, modifyActiveLists, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv227 = DG.Tweening.Sequence;\n\tv228 = \"il2cpp_codegen_initialize_runtime_metadata\"(v227, modifyActiveLists, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv261 = Il2CppMethodInfo;\n\tv262 = \"il2cpp_codegen_initialize_runtime_metadata\"(v261, modifyActiveLists, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv285 = DG.Tweening.Core.TweenManager;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v285, modifyActiveLists, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 1;\n\t*([1A357EE]) = v43;\nL_0024:\n\tv49 = t.onKill == 0;\n\tif (v49) goto L_002A;\n\tv231 = DG.Tweening.Tween::OnTweenCallback(t.onKill, t);\nL_002A:\n\tv234 = modifyActiveLists == 0;\n\tif (v234) goto L_0038;\n\tgoto L_0035;\n\tv286 = \"il2cpp_codegen_runtime_class_init\"(v265, v188, v180, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0035:\n\tDG.Tweening.Core.TweenManager::RemoveActiveTween(t);\nL_0038:\n\tv272 = ~t.isRecyclable;\n\tif (v272) goto L_009E;\n\tv250 = t.tweenType == 0;\n\tif (v250) goto L_FFFFFFFF;\n\tv87 = t.tweenType != 1;\n\tif (v87) goto L_0200;\n\tgoto L_0058;\n\tv425 = \"il2cpp_codegen_runtime_class_init\"(v332, v188, v180, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv427 = DG.Tweening.Core.TweenManager;\nL_0058:\n\tSystem.Collections.Generic.Stack`1<DG.Tweening.Tween>::Push(v218._PooledSequences, t);\n\tv170 = v604.totPooledSequences + 1;\n\tv604.totPooledSequences = v170;\n\tv81 = *([t @ X0 (DG.Tweening.Tween)]) != DG.Tweening.Sequence;\n\tif (v81) goto L_0210;\n\tv694 = *([t @ X0 (DG.Tweening.Tween)+120]);\n\tv82 = *([v694 @ X0_v81+18]) < 1;\n\tif (v82) goto L_0200;\nL_0082:\n\tv700 = System.Collections.Generic.List`1<System.Object>::get_Item(v694, v696);\n\tgoto L_008D;\n\tv719 = v214;\n\tv720 = \"il2cpp_codegen_runtime_class_init\"(v719, v699, v179, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_008D:\n\tDG.Tweening.Core.TweenManager::Despawn(v700, 0);\n\tv696 = v696 + 1;\n\tv131 = *([v694 @ X0_v81+18]) == v696;\n\tif (v131) goto L_0200;\n\tv694 = *([t @ X0 (DG.Tweening.Tween)+120]);\n\tv726 = *([t @ X0 (DG.Tweening.Tween)+120]) == 0;\n\tv201 = ~v726;\n\tif (v201) goto L_0082;\n\tgoto L_00F7;\nL_009E:\n\tv288 = t.tweenType == 0;\n\tif (v288) goto L_016D;\n\tv312 = t.tweenType != 1;\n\tif (v312) goto L_0200;\n\tgoto L_00B8;\n\tv476 = \"il2cpp_codegen_runtime_class_init\"(v414, v188, v180, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv478 = DG.Tweening.Core.TweenManager;\nL_00B8:\n\tv172 = v479.totSequences - 1;\n\tv479.totSequences = v172;\n\tv83 = *([t @ X0 (DG.Tweening.Tween)]) != DG.Tweening.Sequence;\n\tif (v83) goto L_0210;\n\tv653 = *([t @ X0 (DG.Tweening.Tween)+120]);\n\tv80 = *([v653 @ X0_v68+18]) < 1;\n\tif (v80) goto L_0200;\nL_00DC:\n\tv659 = System.Collections.Generic.List`1<System.Object>::get_Item(v653, v655);\n\tgoto L_00E7;\n\tv701 = v212;\n\tv702 = \"il2cpp_codegen_runtime_class_init\"(v701, v658, v177, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00E7:\n\tDG.Tweening.Core.TweenManager::Despawn(v659, 0);\n\tv655 = v655 + 1;\n\tv129 = *([v653 @ X0_v68+18]) == v655;\n\tif (v129) goto L_0200;\n\tv653 = *([t @ X0 (DG.Tweening.Tween)+120]);\n\tv722 = *([t @ X0 (DG.Tweening.Tween)+120]) == 0;\n\tv199 = ~v722;\n\tif (v199) goto L_00DC;\nL_00F7:\n\tthrow System.NullReferenceException;\n\tgoto L_0103;\n\tv273 = \"il2cpp_codegen_runtime_class_init\"(v256, v187, v181, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv275 = DG.Tweening.Core.TweenManager;\nL_0103:\n\tv278 = v276._maxPooledTweenerId + 1;\n\tv280 = v278 == 0;\n\tv283 = ~v280;\n\tif (v283) goto L_0118;\n\tgoto L_0112;\n\tv319 = \"il2cpp_codegen_runtime_class_init\"(v274, v187, v181, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv320 = DG.Tweening.Core.TweenManager;\n\tv321 = *([v320 @ X0_v53+B8]);\nL_0112:\n\tv293 = v298.maxTweeners - 1;\n\tv298._minPooledTweenerId = v293;\n\tv298._maxPooledTweenerId = v293;\nL_0118:\n\tgoto L_011F;\n\tv323 = \"il2cpp_codegen_runtime_class_init\"(v294, v187, v181, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv326 = DG.Tweening.Core.TweenManager;\n\tv324 = *([v326 @ X0_v50+E0]);\nL_011F:\n\tv77 = v327.maxTweeners - 1;\n\tgoto L_012F;\n\tv421 = \"il2cpp_codegen_runtime_class_init\"(v325, v187, v181, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv422 = DG.Tweening.Core.TweenManager;\n\tv423 = *([v422 @ X0_v48+B8]);\nL_012F:\n\tv84 = v327._maxPooledTweenerId >= v77;\n\tif (v84) goto L_0175;\n\tv223 = v216._pooledTweeners;\n\t// 312 IsInst v538 @ X0_v42, typeof(DG.Tweening.Tween), t @ X0 (DG.Tweening.Tween)\n\tv589 = v538 == 0;\n\tif (v589) goto L_0211;\n\tv628 = v216._maxPooledTweenerId + 1;\n\tv223[v628 @ X8_v39 (System.Int32)] = t;\n\tv580 = v595._maxPooledTweenerId + 1;\n\tv595._maxPooledTweenerId = v580;\n\tv550 = v595._minPooledTweenerId <= v580;\n\tif (v550) goto L_01F9;\n\tgoto L_0165;\n\tv704 = \"il2cpp_codegen_runtime_class_init\"(v584, v537, v181, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv706 = DG.Tweening.Core.TweenManager;\n\tv707 = *([v706 @ X0_v46+B8]);\n\tv705 = *([v707 @ X8_v43+84]);\nL_0165:\n\tv598._minPooledTweenerId = v580;\n\tgoto L_01F9;\nL_016D:\n\tgoto L_0172;\n\tv418 = \"il2cpp_codegen_runtime_class_init\"(v315, v188, v180, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv419 = DG.Tweening.Core.TweenManager;\nL_0172:\n\tv383 = v399.totTweeners - 1;\n\tv399.totTweeners = v383;\n\tgoto L_0200;\nL_0175:\n\tv224 = v216._maxPooledTweenerId;\n\tv484 = v216._maxPooledTweenerId & 0x80000000;\n\tv485 = v484 == 0;\n\tv486 = ~v485;\n\tif (v486) goto L_01F9;\n\tv539 = v216._maxPooledTweenerId << 3;\n\tv78 = v539 + 0x20;\nL_017F:\n\tgoto L_0183;\n\tv638 = \"il2cpp_codegen_runtime_class_init\"(v616, v187, v181, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv639 = DG.Tweening.Core.TweenManager;\nL_0183:\n\tv543 = v219._pooledTweeners;\n\tv590 = v543[v224 @ X21_v11 (System.Int32)] == 0;\n\tif (v590) goto L_01A8;\n\tv596 = v224 - 1;\n\tv78 = v78 - 8;\n\tv551 = v224 > 0;\n\tif (v551) goto L_017F;\n\tgoto L_01F9;\nL_01A8:\n\tv711 = *([v197 @ X0_v23 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]) == 0;\n\tv712 = ~v711;\n\tif (v712) goto L_01B4;\n\tv543 = v217._pooledTweeners;\nL_01B4:\n\t// 436 IsInst v611 @ X0_v26, typeof(DG.Tweening.Tween), t @ X0 (DG.Tweening.Tween)\n\tv612 = v611 == 0;\n\tif (v612) goto L_0211;\n\t*([v543 @ X23_v10 (DG.Tweening.Tween[])+v78 @ X22_v10 (System.Int32)]) = t;\n\tv739 = v224 >= v728._minPooledTweenerId;\n\tif (v739) goto L_01DC;\n\tgoto L_01D8;\n\tv751 = \"il2cpp_codegen_runtime_class_init\"(v727, v581, v181, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv752 = DG.Tweening.Core.TweenManager;\n\tv753 = *([v752 @ X0_v37+B8]);\nL_01D8:\n\tv748._minPooledTweenerId = v224;\nL_01DC:\n\tgoto L_01EB;\n\tv754 = \"il2cpp_codegen_runtime_class_init\"(v744, v581, v181, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv755 = DG.Tweening.Core.TweenManager;\nL_01EB:\n\tv549 = v597._maxPooledTweenerId >= v597._minPooledTweenerId;\n\tif (v549) goto L_01F9;\n\tgoto L_01F5;\n\tv758 = \"il2cpp_codegen_runtime_class_init\"(v585, v581, v181, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv760 = DG.Tweening.Core.TweenManager;\n\tv761 = *([v760 @ X0_v32+B8]);\n\tv759 = *([v761 @ X8_v33+80]);\nL_01F5:\n\tv594._maxPooledTweenerId = v597._minPooledTweenerId;\nL_01F9:\n\tgoto L_01FE;\n\tv622 = \"il2cpp_codegen_runtime_class_init\"(v582, v386, v181, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv623 = DG.Tweening.Core.TweenManager;\nL_01FE:\n\tv382 = v398.totPooledTweeners + 1;\n\tv398.totPooledTweeners = v382;\nL_0200:\n\tv402 = t->klass;\n\tt.<active>k__BackingField = 0;\n\tv406 = t->klass->vtable[4];\n\tv407 = t->klass->vtable[4];\n\t// 525 IndirectJump v406 @ X2_v2, t @ X0 (DG.Tweening.Tween), t @ X0 (DG.Tweening.Tween), v407 @ \n// ... truncated")]
		internal static void Despawn(Tween t, bool modifyActiveLists = true)
		{
			//IL_0323: Expected I, but got O
			//IL_0559: Expected I, but got O
			//IL_0577: Expected O, but got I
			//IL_0587: Expected O, but got I
			//IL_01c6: Expected O, but got I
			//IL_0257: Expected O, but got I
			//IL_03e8: Expected I4, but got I8
			//IL_013e: Expected O, but got I
			//IL_02df: Expected O, but got I
			if (t.onKill != null)
			{
				bool flag = Tween.OnTweenCallback(t.onKill, t);
			}
			if (modifyActiveLists)
			{
				RemoveActiveTween(t);
			}
			object obj3 = default(object);
			int num10 = default(int);
			if (t.isRecyclable)
			{
				if (t.tweenType == TweenType.Tweener)
				{
					nint num = (nint)typeof(TweenManager);
					if (_maxPooledTweenerId + 1 == 0)
					{
						_maxPooledTweenerId = (_minPooledTweenerId = maxTweeners - 1);
					}
					int num2 = maxTweeners - 1;
					if (_maxPooledTweenerId < num2)
					{
						Tween[] pooledTweeners = _pooledTweeners;
						object obj = t as Tween;
						if (obj == null)
						{
							goto IL_0543;
						}
						int num3 = _maxPooledTweenerId + 1;
						pooledTweeners[num3] = t;
						int num4 = ++_maxPooledTweenerId;
						if (_minPooledTweenerId > num4)
						{
							_minPooledTweenerId = num4;
						}
					}
					else
					{
						int num5 = _maxPooledTweenerId;
						if ((int)(_maxPooledTweenerId & 0x80000000L) == 0)
						{
							int num6 = _maxPooledTweenerId << 3;
							int num7 = num6 + 32;
							while (true)
							{
								Tween[] pooledTweeners2 = _pooledTweeners;
								if (pooledTweeners2[num5] == null)
								{
									break;
								}
								int num8 = num5 - 1;
								num7 -= 8;
								bool flag2 = num5 > 0;
								num5 = num8;
								if (!flag2)
								{
									goto IL_06e6;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ X0_v23 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]");
							if ((nint)0 == 0)
							{
								Tween[] pooledTweeners2 = _pooledTweeners;
							}
							object obj2 = t as Tween;
							if (obj2 == null)
							{
								goto IL_0543;
							}
							if (num5 < _minPooledTweenerId)
							{
								_minPooledTweenerId = num5;
							}
							if (_maxPooledTweenerId < _minPooledTweenerId)
							{
								_maxPooledTweenerId = _minPooledTweenerId;
							}
						}
					}
					goto IL_06e6;
				}
				if (t.tweenType == TweenType.Sequence)
				{
					_PooledSequences.Push(t);
					int num9 = totPooledSequences + 1;
					totPooledSequences = num9;
					if ((object)t.GetType() != typeof(Sequence))
					{
						goto IL_0535;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Tween)+120]");
					obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v694 @ X0_v81+18]");
					if ((nint)0 >= (nint)1)
					{
						num10 = 0;
						goto IL_0591;
					}
				}
			}
			else if (t.tweenType != TweenType.Tweener)
			{
				if (t.tweenType == TweenType.Sequence)
				{
					int num11 = totSequences - 1;
					totSequences = num11;
					if ((object)t.GetType() != typeof(Sequence))
					{
						goto IL_0535;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Tween)+120]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v653 @ X0_v68+18]");
					if ((nint)0 >= (nint)1)
					{
						int num12 = 0;
						while (true)
						{
							Tween t2 = (Tween)((List<object>)obj4)[num12];
							Despawn(t2, modifyActiveLists: false);
							num12++;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v653 @ X0_v68+18]");
							if ((nint)0 == num12)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Tween)+120]");
							obj4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Tween)+120]");
							if ((nint)0 != 0)
							{
								continue;
							}
							goto IL_030f;
						}
					}
				}
			}
			else
			{
				int num13 = totTweeners - 1;
				totTweeners = num13;
			}
			goto IL_0551;
			IL_0543:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
			IL_0551:
			nint num14 = (nint)t;
			t.active = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ X8_v4 (Il2CppClass<DG.Tweening.Tween>)+178]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ X8_v4 (Il2CppClass<DG.Tweening.Tween>)+180]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v406 @ X2_v2 (should have been resolved before IL gen)");
			goto IL_0591;
			IL_0591:
			while (true)
			{
				Tween t3 = (Tween)((List<object>)obj3)[num10];
				Despawn(t3, modifyActiveLists: false);
				num10++;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v694 @ X0_v81+18]");
				if ((nint)0 == num10)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Tween)+120]");
				obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Tween)+120]");
				if ((nint)0 != 0)
				{
					continue;
				}
				goto IL_030f;
			}
			goto IL_0551;
			IL_06e6:
			int num15 = totPooledTweeners + 1;
			totPooledTweeners = num15;
			goto IL_0551;
			IL_030f:
			throw new NullReferenceException();
			IL_0535:
			InvalidCastException ex2 = new InvalidCastException();
			goto IL_0543;
		}

		[Token(Token = "0x6000433")]
		[Address(RVA = "0xC2F9B0", Offset = "0xC2F9B0", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A357EF]) = v33;\nL_0013:\n\tv37 = isApplicationQuitting == 0;\n\tif (v37) goto L_FFFFFFFF;\nL_0019:\n\tgoto L_001D;\n\tv120 = \"il2cpp_codegen_runtime_class_init\"(v77, v46, v48, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv122 = DG.Tweening.Core.TweenManager;\nL_001D:\n\tv124 = v123._activeTweens;\n\tv140 = v124.Length < 1;\n\tif (v140) goto L_0035;\n\tv165 = v124 + 0x20;\n\tv166 = v124.Length & 0xFFFFFFFF;\n\tv167 = v166 << 3;\n\tv172 = 0x1854F20(v165, 0, v167, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0035:\n\tv174.hasActiveManualTweens = 0;\n\tv174.hasActiveTweens = 0;\n\tv174.totActiveLateTweens = 0;\n\tv174.totActiveManualTweens = 0;\n\tv174.totActiveTweens = 0;\n\tv174.totActiveSequences = 0;\n\tv174._reorganizeFromId = 0xFFFFFFFF;\n\tv174._maxActiveLookupId = 0xFFFFFFFF;\n\tv174._requiresActiveReorganization = 0;\n\tDG.Tweening.Core.TweenManager::PurgePools();\n\tDG.Tweening.Core.TweenManager::ResetCapacities();\n\tv204.totTweeners = 0;\n\tv204.totSequences = 0;\n\treturn;\n\tgoto L_005C;\n\tv126 = \"il2cpp_codegen_runtime_class_init\"(v117, v47, v49, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv127 = DG.Tweening.Core.TweenManager;\nL_005C:\n\tv52 = v82 >= v84.maxActive;\n\tif (v52) goto L_0019;\n\tgoto L_0065;\n\tv195 = \"il2cpp_codegen_runtime_class_init\"(v78, v47, v49, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv199 = DG.Tweening.Core.TweenManager;\n\tv197 = *([v199 @ X8_v21+B8]);\nL_0065:\n\tv161 = v196._activeTweens;\n\tv91 = v161[v82 @ X19_v7 (System.Int32)];\n\tv228 = v161[v82 @ X19_v7 (System.Int32)] == 0;\n\tif (v228) goto L_0081;\n\tv230 = ~v91.<active>k__BackingField;\n\tif (v230) goto L_0081;\n\tv91.<active>k__BackingField = 0;\n\tv234 = v91.onKill == 0;\n\tif (v234) goto L_0081;\n\tv232 = DG.Tweening.Tween::OnTweenCallback(v91.onKill, v161[v82 @ X19_v7 (System.Int32)]);\nL_0081:\n\tv82 = v82 + 1;\n\tgoto L_FFFFFFFF;\n\tv162 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void PurgeAll(bool isApplicationQuitting)
		{
			//IL_0039: Expected O, but got I
			//IL_004d: Expected I4, but got I8
			if (!isApplicationQuitting)
			{
				for (int i = 0; i < maxActive; i++)
				{
					Tween[] activeTweens = _activeTweens;
					Tween tween = activeTweens[i];
					if (activeTweens[i] != null && tween.active)
					{
						tween.active = false;
						if (tween.onKill != null)
						{
							bool flag = Tween.OnTweenCallback(tween.onKill, activeTweens[i]);
						}
					}
				}
			}
			Tween[] activeTweens2 = _activeTweens;
			if (activeTweens2.Length >= 1)
			{
				object obj = (nint)activeTweens2 + 32;
				int num = (int)(activeTweens2.Length & 0xFFFFFFFFL);
				int num2 = num << 3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F20 (native memset)");
			}
			hasActiveManualTweens = false;
			hasActiveTweens = false;
			totActiveLateTweens = 0;
			totActiveManualTweens = 0;
			totActiveTweens = 0;
			totActiveSequences = 0;
			_reorganizeFromId = -1;
			_maxActiveLookupId = -1;
			_requiresActiveReorganization = false;
			PurgePools();
			ResetCapacities();
			totTweeners = 0;
			totSequences = 0;
		}

		[Token(Token = "0x6000434")]
		[Address(RVA = "0xC2FAF8", Offset = "0xC2FAF8", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = DG.Tweening.Core.TweenManager;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A357F0]) = v35;\nL_0018:\n\tgoto L_001E;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v36, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv44 = DG.Tweening.Core.TweenManager;\nL_001E:\n\tv48 = v45._pooledTweeners;\n\tv49 = v45.totTweeners - v45.totPooledTweeners;\n\tv45.totTweeners = v49;\n\tv62 = v48.Length < 1;\n\tif (v62) goto L_003D;\n\tv94 = v48 + 0x20;\n\tv95 = v48.Length & 0xFFFFFFFF;\n\tv96 = v95 << 3;\n\tv98 = 0x1854F20(v94, 0, v96, v18, v19, v20, v21, v22, v49, v45.totPooledTweeners, v25, v26, v27, v28, v29, v30);\nL_003D:\n\tSystem.Collections.Generic.Stack`1<DG.Tweening.Tween>::Clear(v92._PooledSequences);\n\tv125.totPooledTweeners = 0;\n\tv125.totPooledSequences = 0;\n\tv125._minPooledTweenerId = -1;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void PurgePools()
		{
			//IL_0033: Expected O, but got I
			//IL_0047: Expected I4, but got I8
			Tween[] pooledTweeners = _pooledTweeners;
			int num = totTweeners - totPooledTweeners;
			totTweeners = num;
			if (pooledTweeners.Length >= 1)
			{
				object obj = (nint)pooledTweeners + 32;
				int num2 = (int)(pooledTweeners.Length & 0xFFFFFFFFL);
				int num3 = num2 << 3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F20 (native memset)");
			}
			_PooledSequences.Clear();
			totPooledTweeners = 0;
			totPooledSequences = 0;
			_minPooledTweenerId = -1;
		}

		[Token(Token = "0x6000435")]
		[Address(RVA = "0xC2FC18", Offset = "0xC2FC18", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, tweenLink, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv47 = Il2CppMethodInfo;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, tweenLink, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv58 = Il2CppMethodInfo;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, tweenLink, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv85 = DG.Tweening.Core.TweenManager;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v85, tweenLink, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A357F1]) = v41;\nL_0022:\n\tgoto L_0028;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v42, tweenLink, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = DG.Tweening.Core.TweenManager;\nL_0028:\n\tv55 = v52._totTweenLinks + 1;\n\tv52._totTweenLinks = v55;\n\tv64 = System.Collections.Generic.Dictionary`2<DG.Tweening.Tween, DG.Tweening.Core.TweenLink>::ContainsKey(v52._TweenLinks, t);\n\tgoto L_003F;\n\tv89 = v86;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v89, v62, v63, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv93 = DG.Tweening.Core.TweenManager;\nL_003F:\n\tv176 = v64 == 0;\n\tif (v176) goto L_004D;\n\tSystem.Collections.Generic.Dictionary`2<DG.Tweening.Tween, DG.Tweening.Core.TweenLink>::set_Item(v80._TweenLinks, t, tweenLink);\n\tgoto L_0052;\nL_004D:\n\tSystem.Collections.Generic.Dictionary`2<DG.Tweening.Tween, DG.Tweening.Core.TweenLink>::Add(v80._TweenLinks, t, tweenLink);\nL_0052:\n\tv154 = ~tweenLink.lastSeenActive;\n\tif (v154) goto L_0070;\n\tv188 = tweenLink.behaviour - 1;\n\tv189 = v188 < 3;\n\tv139 = ~v189;\n\tv134 = v188 - 3;\n\tv124 = v134 == 0;\n\tv190 = ~v124;\n\tv99 = v139 & v190;\n\tif (v99) goto L_0091;\n\tgoto L_006E;\n\tv197 = \"il2cpp_codegen_runtime_class_init\"(v193, v72, v70, v66, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_006E:\n\tv149 = DG.Tweening.Core.TweenManager::Play(t);\n\treturn;\nL_0070:\n\tv191 = tweenLink.behaviour < 2;\n\tv140 = ~v191;\n\tv135 = tweenLink.behaviour - 2;\n\tv125 = v135 == 0;\n\tv192 = ~v125;\n\tv100 = v140 & v192;\n\tif (v100) goto L_0091;\n\tgoto L_0089;\n\tv200 = \"il2cpp_codegen_runtime_class_init\"(v195, v72, v70, v66, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0089:\n\tv150 = DG.Tweening.Core.TweenManager::Pause(t);\n\treturn;\nL_0091:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 94 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void AddTweenLink(Tween t, TweenLink tweenLink)
		{
			int totTweenLinks = _totTweenLinks + 1;
			_totTweenLinks = totTweenLinks;
			if (_TweenLinks.ContainsKey(t))
			{
				_TweenLinks[t] = tweenLink;
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

		[Token(Token = "0x6000436")]
		[Address(RVA = "0xC2FE54", Offset = "0xC2FE54", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv44 = Il2CppMethodInfo;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv53 = DG.Tweening.Core.TweenManager;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A357F2]) = v38;\nL_001D:\n\tgoto L_0028;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv48 = DG.Tweening.Core.TweenManager;\nL_0028:\n\tv58 = System.Collections.Generic.Dictionary`2<DG.Tweening.Tween, DG.Tweening.Core.TweenLink>::ContainsKey(v49._TweenLinks, t);\n\tv69 = v58 == 0;\n\tif (v69) goto L_0046;\n\tgoto L_003B;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v70, v56, v57, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv102 = DG.Tweening.Core.TweenManager;\nL_003B:\n\tv82 = System.Collections.Generic.Dictionary`2<DG.Tweening.Tween, DG.Tweening.Core.TweenLink>::Remove(v66._TweenLinks, t);\n\tv75 = v85._totTweenLinks - 1;\n\tv85._totTweenLinks = v75;\nL_0046:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void RemoveTweenLink(Tween t)
		{
			if (_TweenLinks.ContainsKey(t))
			{
				bool flag = _TweenLinks.Remove(t);
				int totTweenLinks = _totTweenLinks - 1;
				_totTweenLinks = totTweenLinks;
			}
		}

		[Token(Token = "0x6000437")]
		[Address(RVA = "0xC2FBC4", Offset = "0xC2FBC4", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A357F3]) = v34;\nL_0015:\n\tgoto L_001D;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001D:\n\tDG.Tweening.Core.TweenManager::SetCapacities(0xC8, 0x32);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void ResetCapacities()
		{
			SetCapacities(200, 50);
		}

		[Token(Token = "0x6000438")]
		[Address(RVA = "0xC2FF30", Offset = "0xC2FF30", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, sequencesCapacity, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv57 = Il2CppMethodInfo;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, sequencesCapacity, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv62 = DG.Tweening.Core.TweenManager;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, sequencesCapacity, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A357F4]) = v41;\nL_001F:\n\tv46 = tweenersCapacity - sequencesCapacity;\n\tv47 = v46 < 0;\n\tv49 = tweenersCapacity ^ sequencesCapacity;\n\tv50 = tweenersCapacity ^ v46;\n\tv51 = v49 & v50;\n\tv52 = v51 < 0;\n\tv53 = v47 == v52;\n\tv54 = ~v53;\n\tv55 = ~v54;\n\tif (v55) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0035;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v42, sequencesCapacity, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv70 = DG.Tweening.Core.TweenManager;\nL_0035:\n\tv71 = *([v69 @ X0_v3 (Il2CppClass<DG.Tweening.Core.TweenManager>)+B8]);\n\tv72 = v63 + sequencesCapacity;\n\tv71.maxActive = v72;\n\tv71.maxTweeners = v63;\n\tv71.maxSequences = sequencesCapacity;\n\tv74 = v71 + 0x48;\n\tSystem.Array::Resize(v74, v72);\n\tv79 = v75.isUnityEditor + 0x50;\n\tSystem.Array::Resize(v79, v63);\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::set_Capacity(v81._KillList, v81.maxActive);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe static void SetCapacities(int tweenersCapacity, int sequencesCapacity)
		{
			//IL_00c1: Expected I, but got O
			int num = tweenersCapacity - sequencesCapacity;
			bool flag = num < 0;
			int num2 = tweenersCapacity ^ sequencesCapacity;
			int num3 = tweenersCapacity ^ num;
			int num4 = num2 & num3;
			bool flag2 = num4 < 0;
			int num5 = ((flag == flag2) ? tweenersCapacity : sequencesCapacity);
			nint num6 = (nint)typeof(TweenManager);
			nint num7 = (isUnityEditor ? 1 : 0);
			int newSize = (maxActive = num5 + sequencesCapacity);
			maxTweeners = num5;
			maxSequences = sequencesCapacity;
			Array.Resize(ref *(object[]*)(num7 + 72), newSize);
			Array.Resize(ref *(object[]*)((isUnityEditor ? 1 : 0) + 80), num5);
			_KillList.Capacity = maxActive;
		}

		[Token(Token = "0x6000439")]
		[Address(RVA = "0xC30010", Offset = "0xC30010", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = DG.Tweening.Core.TweenManager;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv39 = 1;\n\t*([1A357F5]) = v39;\nL_001A:\n\tgoto L_001F;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v40, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv48 = DG.Tweening.Core.TweenManager;\nL_001F:\n\tv51 = ~v49._requiresActiveReorganization;\n\tif (v51) goto L_FFFFFFFF;\n\tgoto L_0026;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v47, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0026:\n\tDG.Tweening.Core.TweenManager::ReorganizeActiveTweens();\nL_002D:\n\tgoto L_0032;\n\tv113 = \"il2cpp_codegen_runtime_class_init\"(v109, v65, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv115 = DG.Tweening.Core.TweenManager;\nL_0032:\n\tv118 = v116._maxActiveLookupId + 1;\n\tv64 = v99 >= v118;\n\tif (v64) goto L_0077;\n\tgoto L_0045;\n\tv142 = \"il2cpp_codegen_runtime_class_init\"(v114, v65, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv190 = DG.Tweening.Core.TweenManager;\n\tv145 = *([v190 @ X8_v25+B8]);\nL_0045:\n\tv146 = v144._activeTweens;\n\tv259 = DG.Tweening.Tween::Validate(v146[v99 @ X22_v2 (System.Int32)]);\n\tv261 = v259 == 0;\n\tv262 = ~v261;\n\tif (v262) goto L_006B;\n\tgoto L_0069;\n\tv273 = \"il2cpp_codegen_runtime_class_init\"(v266, v258, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0069:\n\tv108 = v108 + 1;\n\tDG.Tweening.Core.TweenManager::MarkForKilling(v146[v99 @ X22_v2 (System.Int32)], 0);\nL_006B:\n\tv99 = v99 + 1;\n\tgoto L_002D;\nL_0077:\n\tv141 = v108 < 1;\n\tif (v141) goto L_00A3;\n\tgoto L_0081;\n\tv211 = \"il2cpp_codegen_runtime_class_init\"(v114, v65, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv253 = DG.Tweening.Core.TweenManager;\n\tv214 = *([v253 @ X8_v17+B8]);\nL_0081:\n\tDG.Tweening.Core.TweenManager::DespawnActiveTweens(v213._KillList);\n\tv183 = v255._KillList;\n\tv176 = v183._version + 1;\n\tv183._size = 0;\n\tv183._version = v176;\n\tv156 = v183._size < 1;\n\tif (v156) goto L_00A3;\n\tSystem.Array::Clear(v183._items, 0, v183._size);\nL_00A3:\n\treturn v108;\n\tv210 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 113 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
					break;
				}
				Tween[] activeTweens = _activeTweens;
				if (!activeTweens[num].Validate())
				{
					num2++;
					MarkForKilling(activeTweens[num]);
				}
				num++;
			}
			if (num2 >= 1)
			{
				DespawnActiveTweens(_KillList);
				List<Tween> killList = _KillList;
				int version = killList._version + 1;
				killList._size = 0;
				killList._version = version;
				if (killList.Count >= 1)
				{
					Array.Clear(killList._items, 0, killList.Count);
				}
			}
			return num2;
		}

		[Token(Token = "0x600043A")]
		[Address(RVA = "0xC30560", Offset = "0xC30560", Length = "0x210")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv32 = Il2CppMethodInfo;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, methodInfo, v35, v36, v37, v38, v39, v40, deltaTime, independentTime, v41, v42, v43, v44, v45, v46);\n\tv56 = DG.Tweening.Core.TweenManager;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v35, v36, v37, v38, v39, v40, deltaTime, independentTime, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A357F6]) = v50;\nL_0021:\n\tgoto L_0026;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v51, methodInfo, v35, v36, v37, v38, v39, v40, deltaTime, independentTime, v41, v42, v43, v44, v45, v46);\n\tv59 = DG.Tweening.Core.TweenManager;\nL_0026:\n\tv62 = ~v60._requiresActiveReorganization;\n\tif (v62) goto L_0032;\n\tgoto L_002D;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v58, methodInfo, v35, v36, v37, v38, v39, v40, deltaTime, independentTime, v41, v42, v43, v44, v45, v46);\nL_002D:\n\tDG.Tweening.Core.TweenManager::ReorganizeActiveTweens();\nL_0032:\n\tgoto L_0038;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v66, methodInfo, v35, v36, v37, v38, v39, v40, deltaTime, independentTime, v41, v42, v43, v44, v45, v46);\n\tv77 = DG.Tweening.Core.TweenManager;\nL_0038:\n\tv78.isUpdateLoop = 1;\n\tv81 = v78._maxActiveLookupId + 1;\n\tv92 = v81 < 1;\n\tif (v92) goto L_00C9;\n\tv96 = v81 - 1;\nL_004D:\n\tgoto L_0051;\n\tv202 = \"il2cpp_codegen_runtime_class_init\"(v180, v164, v35, v36, v37, v38, v39, v40, v166, v165, v41, v42, v43, v44, v45, v46);\n\tv204 = DG.Tweening.Core.TweenManager;\nL_0051:\n\tv206 = v205._activeTweens;\n\tv159 = v206[v145 @ X23_v4 (System.Int32)];\n\tv269 = v206[v145 @ X23_v4 (System.Int32)] == 0;\n\tif (v269) goto L_007F;\n\tv280 = v159.updateType != updateType;\n\tif (v280) goto L_007F;\n\tgoto L_0079;\n\tv299 = \"il2cpp_codegen_runtime_class_init\"(v203, v164, v35, v36, v37, v38, v39, v40, v166, v165, v41, v42, v43, v44, v45, v46);\nL_0079:\n\tv293 = DG.Tweening.Core.TweenManager::Update(v206[v145 @ X23_v4 (System.Int32)], deltaTime, independentTime, 0);\n\tv143 = v143 | v293;\nL_007F:\n\tv128 = v96 == v145;\n\tif (v128) goto L_0088;\n\tv145 = v145 + 1;\n\tgoto L_004D;\nL_0088:\n\tv298 = v143 & 1;\n\tv152 = v298 == 0;\n\tif (v152) goto L_00C9;\n\tv302 = DG.Tweening.Core.TweenManager;\n\tv304 = *([v302 @ X0_v17 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]) == 0;\n\tif (v304) goto L_009C;\n\tv307 = ~v305._despawnAllCalledFromUpdateLoopCallback;\n\tif (v307) goto L_00A4;\nL_0093:\n\tv317._despawnAllCalledFromUpdateLoopCallback = 0;\n\tgoto L_00A9;\nL_009C:\n\tgoto L_00A0;\n\tv336 = \"il2cpp_codegen_runtime_class_init\"(v325, v103, v35, v36, v37, v38, v39, v40, v107, v105, v41, v42, v43, v44, v45, v46);\n\tv337 = DG.Tweening.Core.TweenManager;\n\tv338 = *([v337 @ X0_v30+B8]);\nL_00A0:\n\tv339 = ~v326._despawnAllCalledFromUpdateLoopCallback;\n\tv314 = ~v339;\n\tif (v314) goto L_0093;\nL_00A4:\n\tDG.Tweening.Core.TweenManager::DespawnActiveTweens(v323._KillList);\nL_00A9:\n\tgoto L_00AD;\n\tv340 = \"il2cpp_codegen_runtime_class_init\"(v329, v103, v35, v36, v37, v38, v39, v40, v107, v105, v41, v42, v43, v44, v45, v46);\n\tv341 = DG.Tweening.Core.TweenManager;\nL_00AD:\n\tv156 = v342._KillList;\n\tv139 = v156._version + 1;\n\tv156._size = 0;\n\tv156._version = v139;\n\tv109 = v156._size < 1;\n\tif (v109) goto L_00C9;\n\tSystem.Array::Clear(v156._items, 0, v156._size);\nL_00C9:\n\tgoto L_00D4;\n\tv189 = \"il2cpp_codegen_runtime_class_init\"(v160, v101, v99, v97, v37, v38, v39, v40, v106, v104, v41, v42, v43, v44, v45, v46);\n\tv191 = DG.Tweening.Core.TweenManager;\nL_00D4:\n\tv192.isUpdateLoop = 0;\n\treturn;\n\tv267 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 144 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void Update(UpdateType updateType, float deltaTime, float independentTime)
		{
			//IL_011a: Expected I, but got O
			if (_requiresActiveReorganization)
			{
				ReorganizeActiveTweens();
			}
			isUpdateLoop = true;
			int num = _maxActiveLookupId + 1;
			if (num >= 1)
			{
				int num2 = num - 1;
				int num3 = 0;
				int num4 = 0;
				while (true)
				{
					Tween[] activeTweens = _activeTweens;
					Tween tween = activeTweens[num4];
					if (activeTweens[num4] != null && tween.updateType == updateType)
					{
						bool flag = Update(activeTweens[num4], deltaTime, independentTime, isSingleTweenManualUpdate: false);
						num3 |= (flag ? 1 : 0);
					}
					if (num2 == num4)
					{
						break;
					}
					num4++;
				}
				if ((num3 & 1) != 0)
				{
					nint num5 = (nint)typeof(TweenManager);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ X0_v17 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]");
					if ((nint)0 != 0)
					{
						if (_despawnAllCalledFromUpdateLoopCallback)
						{
							goto IL_0159;
						}
					}
					else if (_despawnAllCalledFromUpdateLoopCallback)
					{
						goto IL_0159;
					}
					DespawnActiveTweens(_KillList);
					goto IL_02b0;
				}
			}
			goto IL_0255;
			IL_02b0:
			List<Tween> killList = _KillList;
			int version = killList._version + 1;
			killList._size = 0;
			killList._version = version;
			if (killList.Count >= 1)
			{
				Array.Clear(killList._items, 0, killList.Count);
			}
			goto IL_0255;
			IL_0159:
			_despawnAllCalledFromUpdateLoopCallback = false;
			goto IL_02b0;
			IL_0255:
			isUpdateLoop = false;
		}

		[Token(Token = "0x600043B")]
		[Address(RVA = "0xC30770", Offset = "0xC30770", Length = "0x25C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = DG.Tweening.Core.TweenManager;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, isSingleTweenManualUpdate, methodInfo, v33, v34, v35, v36, v37, deltaTime, independentTime, v38, v39, v40, v41, v42, v43);\n\tv46 = 1;\n\t*([1A357F7]) = v46;\nL_001D:\n\tgoto L_002C;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v47, isSingleTweenManualUpdate, methodInfo, v33, v34, v35, v36, v37, deltaTime, independentTime, v38, v39, v40, v41, v42, v43);\n\tv53 = DG.Tweening.Core.TweenManager;\nL_002C:\n\tv66 = v54._totTweenLinks < 1;\n\tif (v66) goto L_0038;\n\tgoto L_0034;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v52, isSingleTweenManualUpdate, methodInfo, v33, v34, v35, v36, v37, deltaTime, independentTime, v38, v39, v40, v41, v42, v43);\nL_0034:\n\tDG.Tweening.Core.TweenManager::EvaluateTweenLink(t);\nL_0038:\n\tv78 = ~t.<active>k__BackingField;\n\tif (v78) goto L_016F;\n\tv81 = ~t.isPlaying;\n\tif (v81) goto L_FFFFFFFF;\n\tif (t.isIndependentUpdate) goto L_FFFFFFFF;\n\tgoto L_0050;\nL_0050:\n\tv159 = t.timeScale * v97;\n\tt.creationLocked = 1;\n\tv296 = v159 >= 1E-06f;\n\tif (v296) goto L_0070;\n\tv182 = v159 <= -1E-06f;\n\tif (v182) goto L_0070;\n\tgoto L_017D;\nL_0070:\n\tv157 = ~t.delayComplete;\n\tif (v157) goto L_00D2;\nL_0073:\n\tv325 = ~t.startupDone;\n\tv326 = ~v325;\n\tif (v326) goto L_007E;\n\tv152 = DG.Tweening.Tween::Startup(t);\n\tv156 = v152 == 0;\n\tif (v156) goto L_016F;\nL_007E:\n\tv142 = t.duration;\n\tv404 = t.completedLoops;\n\tv341 = t.duration < 0;\n\tv342 = ~v341;\n\tv345 = t.duration == 0;\n\tv350 = ~v342;\n\tv351 = v350 | v345;\n\tif (v351) goto L_00FA;\n\tv356 = ~t.isBackwards;\n\tif (v356) goto L_0107;\n\tv386 = t.<position>k__BackingField - v159;\n\tv367 = t.completedLoops & 0x80000000;\n\tv368 = v367 == 0;\n\tv369 = ~v368;\n\tif (v369) goto L_00AD;\nL_009E:\n\tv415 = v386 >= 0;\n\tif (v415) goto L_00AD;\n\tv426 = v404 - 1;\n\tv386 = v142 + v386;\n\tv385 = v404 >= 1;\n\tif (v385) goto L_009E;\nL_00AD:\n\tv427 = v426 & 0x80000000;\n\tv428 = v427 == 0;\n\tv429 = ~v428;\n\tif (v429) goto L_00C2;\n\tv516 = v426 == 0;\n\tv483 = ~v516;\n\tif (v483) goto L_0136;\n\tv433 = t.<position>k__BackingField < v142;\n\tif (v433) goto L_0136;\nL_00C2:\n\tv473 = t.<position>k__BackingField - v142;\n\tv468 = v473 < 0;\n\tv458 = t.<position>k__BackingField ^ v142;\n\tv453 = t.<position>k__BackingField ^ v473;\n\tv448 = v458 & v453;\n\tv443 = v448 < 0;\n\tv434 = v468 == v443;\n\tgoto L_0136;\nL_00D2:\n\tv329 = v159 + t.elapsedDelay;\n\tv153 = DG.Tweening.Tween::UpdateDelay(t, v329);\n\tv330 = v329 < -1f;\n\tv133 = ~v330;\n\tv129 = v329 - -1f;\n\tv121 = v129 == 0;\n\tv331 = ~v133;\n\tv94 = v331 | v121;\n\tif (v94) goto L_016F;\n\tv352 = v329 < 0;\n\tv209 = ~v352;\n\tv200 = v329 == 0;\n\tv353 = ~v209;\n\tv183 = v353 | v200;\n\tif (v183) goto L_FFFFFFFF;\n\tv320 = ~t.<playedOnce>k__BackingField;\n\tif (v320) goto L_0073;\n\tv321 = t.onPlay == 0;\n\tif (v321) goto L_0073;\n\tv318 = DG.Tweening.Tween::OnTweenCallback(t.onPlay, t);\n\tgoto L_0073;\nL_00FA:\n\tv359 = t.loops + 1;\n\tv361 = v359 == 0;\n\tv364 = ~v361;\n\tv365 = ~v364;\n\tif (v365) goto L_0104;\n\tgoto L_FFFFFFFF;\nL_0104:\n\tv88 = t.completedLoops + 1;\n\tgoto L_0165;\nL_0107:\n\tv436 = v159 + t.<position>k__BackingField;\n\tv381 = v436 < t.duration;\n\tif (v381) goto L_0136;\nL_0115:\n\tv482 = t.loops + 1;\n\tv538 = v482 == 0;\n\tif (v538) goto L_0126;\n\tv435 = v488 >= t.loops;\n\tif (v435) goto L_0136;\nL_0126:\n\tv436 = v439 - v142;\n\tv404 = v488 + 1;\n\tv432 = v436 >= v142;\n\tif (v432) goto L_0115;\nL_0136:\n\tv492 = t.<position>k__BackingField - v142;\n\tv493 = v492 < 0;\n\tv495 = t.<position>k__BackingField ^ v142;\n\tv496 = t.<position>k__BackingField ^ v492;\n\tv497 = v495 & v496;\n\tv498 = v497 < 0;\n\tv499 = v493 == v498;\n\tv88 = v404 - v499;\n\tv513 = v88 < t.loops;\n\tif (v513) goto L_FFFFFFFF;\n\tv543 = t.loops - 0xFFFFFFFF;\n\tv559 = v543 == 0;\n\tgoto L_015C;\nL_015C:\n\tv554 = ~v559;\n\tif (v554) goto L_0165;\n\tgoto L_0165;\nL_0165:\n\tv568 = DG.Tweening.Tween::DoGoto(t, v142, v88, 0);\n\tv155 = v568 == 0;\n\tif (v155) goto L_017D;\nL_016F:\n\tgoto L_0173;\n\tv222 = \"il2cpp_codegen_runtime_class_init\"(v165, v87, v84, v82, v34, v35, v36, v37, v141, v134, v95, v39, v40, v41, v42, v43);\nL_0173:\n\tDG.Tweening.Core.TweenManager::MarkForKilling(t, isSingleTweenManualUpdate);\nL_017D:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 246 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool Update(Tween t, float deltaTime, float independentTime, bool isSingleTweenManualUpdate)
		{
			//IL_0685: Expected I4, but got F4
			//IL_0697: Expected I4, but got F4
			//IL_01e2: Expected I4, but got I8
			//IL_02b0: Expected I4, but got I8
			//IL_0706: Expected O, but got I8
			//IL_036a: Expected I4, but got F4
			//IL_037c: Expected I4, but got F4
			if (_totTweenLinks >= 1)
			{
				EvaluateTweenLink(t);
			}
			float num6;
			int num7;
			float num10;
			int num14;
			if (t.active)
			{
				if (t.isPlaying)
				{
					float num = (t.isIndependentUpdate ? independentTime : deltaTime);
					float num2 = t.timeScale * num;
					t.creationLocked = true;
					if (!(num2 < 1E-06f) || !(num2 > -1E-06f))
					{
						if (!t.delayComplete)
						{
							float num3 = num2 + t.elapsedDelay;
							float num4 = t.UpdateDelay(num3);
							bool flag = num3 < -1f;
							bool flag2 = !flag;
							float num5 = num3 - -1f;
							bool flag3 = num5 == 0f;
							bool flag4 = !flag2;
							if (flag4 || flag3)
							{
								goto IL_073a;
							}
							bool flag5 = num3 < 0f;
							bool flag6 = !flag5;
							bool flag7 = num3 == 0f;
							bool flag8 = !flag6;
							if (flag8 || flag7)
							{
								goto IL_00a3;
							}
							bool flag9 = !t.playedOnce;
							num2 = num3;
							if (!flag9)
							{
								bool flag10 = t.onPlay == null;
								num2 = num3;
								if (!flag10)
								{
									bool flag11 = Tween.OnTweenCallback(t.onPlay, t);
									num2 = num3;
								}
							}
						}
						if (t.startupDone || t.Startup())
						{
							num6 = t.duration;
							num7 = t.completedLoops;
							bool flag12 = t.duration < 0f;
							bool flag13 = !flag12;
							bool flag14 = t.duration == 0f;
							bool flag15 = !flag13;
							if (!(flag15 || flag14))
							{
								if (t.isBackwards)
								{
									float num8 = t.position - num2;
									int num9 = (int)(t.completedLoops & 0x80000000L);
									bool flag16 = num9 == 0;
									bool flag17 = !flag16;
									num10 = num8;
									int num11 = t.completedLoops;
									if (!flag17)
									{
										bool flag19;
										do
										{
											bool flag18 = !(num8 < 0f);
											num10 = num8;
											num11 = num7;
											if (flag18)
											{
												break;
											}
											num11 = num7 - 1;
											num8 = num6 + num8;
											flag19 = num7 >= 1;
											num7 = num11;
											num10 = num8;
										}
										while (flag19);
									}
									if ((int)(num11 & 0x80000000L) != 0)
									{
										goto IL_0333;
									}
									bool flag20 = num11 == 0;
									bool flag21 = !flag20;
									num7 = num11;
									if (!flag21)
									{
										bool flag22 = t.position < num6;
										num7 = num11;
										if (!flag22)
										{
											goto IL_0333;
										}
									}
								}
								else
								{
									num10 = num2 + t.position;
									if (!(num10 < t.duration))
									{
										float num12 = num10;
										int num13 = t.completedLoops;
										bool flag24;
										do
										{
											if (t.loops + 1 != 0)
											{
												bool flag23 = num13 >= t.loops;
												num10 = num12;
												num7 = num13;
												if (flag23)
												{
													break;
												}
											}
											num10 = num12 - num6;
											num7 = num13 + 1;
											flag24 = !(num10 < num6);
											num12 = num10;
											num13 = num7;
										}
										while (flag24);
									}
								}
								goto IL_064e;
							}
							num14 = ((t.loops + 1 == 0) ? (t.completedLoops + 1) : t.loops);
							num6 = 0f;
							goto IL_0818;
						}
						goto IL_073a;
					}
				}
				goto IL_00a3;
			}
			goto IL_073a;
			IL_00a3:
			bool result = false;
			goto IL_079e;
			IL_079e:
			return result;
			IL_0333:
			float num15 = t.position - num6;
			bool flag25 = num15 < 0f;
			int num16 = t.position ^ num6;
			int num17 = t.position ^ num15;
			int num18 = num16 & num17;
			bool flag26 = num18 < 0;
			bool flag27 = flag25 == flag26;
			num10 = 0f;
			num7 = (flag27 ? 1 : 0);
			goto IL_064e;
			IL_073a:
			MarkForKilling(t, isSingleTweenManualUpdate);
			result = true;
			goto IL_079e;
			IL_064e:
			float num19 = t.position - num6;
			bool flag28 = num19 < 0f;
			int num20 = t.position ^ num6;
			int num21 = t.position ^ num19;
			int num22 = num20 & num21;
			bool flag29 = num22 < 0;
			bool flag30 = flag28 == flag29;
			num14 = num7 - (flag30 ? 1 : 0);
			bool flag31;
			if (num14 >= t.loops)
			{
				object obj = t.loops - 4294967295L;
				flag31 = obj == null;
			}
			else
			{
				flag31 = true;
			}
			if (flag31)
			{
				num6 = num10;
			}
			goto IL_0818;
			IL_0818:
			bool flag32 = Tween.DoGoto(t, num6, num14, default(UpdateMode));
			bool flag33 = !flag32;
			result = false;
			if (!flag33)
			{
				goto IL_073a;
			}
			goto IL_079e;
		}

		[Token(Token = "0x600043C")]
		[Address(RVA = "0xC30C0C", Offset = "0xC30C0C", Length = "0x8E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0032;\n\tv46 = System.Int32;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, filterType, id, optionalBool, optionalObj, optionalArray, methodInfo, v49, optionalFloat, v50, v51, v52, v53, v54, v55, v56);\n\tv63 = Il2CppMethodInfo;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, filterType, id, optionalBool, optionalObj, optionalArray, methodInfo, v49, optionalFloat, v50, v51, v52, v53, v54, v55, v56);\n\tv69 = Il2CppMethodInfo;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, filterType, id, optionalBool, optionalObj, optionalArray, methodInfo, v49, optionalFloat, v50, v51, v52, v53, v54, v55, v56);\n\tv92 = Il2CppMethodInfo;\n\tv93 = \"il2cpp_codegen_initialize_runtime_metadata\"(v92, filterType, id, optionalBool, optionalObj, optionalArray, methodInfo, v49, optionalFloat, v50, v51, v52, v53, v54, v55, v56);\n\tv149 = Il2CppMethodInfo;\n\tv150 = \"il2cpp_codegen_initialize_runtime_metadata\"(v149, filterType, id, optionalBool, optionalObj, optionalArray, methodInfo, v49, optionalFloat, v50, v51, v52, v53, v54, v55, v56);\n\tv163 = System.String;\n\tv164 = \"il2cpp_codegen_initialize_runtime_metadata\"(v163, filterType, id, optionalBool, optionalObj, optionalArray, methodInfo, v49, optionalFloat, v50, v51, v52, v53, v54, v55, v56);\n\tv192 = DG.Tweening.Core.TweenManager;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v192, filterType, id, optionalBool, optionalObj, optionalArray, methodInfo, v49, optionalFloat, v50, v51, v52, v53, v54, v55, v56);\n\tv60 = 1;\n\t*([1A357F8]) = v60;\nL_0032:\n\tv61 = optionalArray == 0;\n\tif (v61) goto L_003A;\n\tgoto L_003A;\nL_003A:\n\tv75 = filterType - 1;\n\tv80 = v75 < 1;\n\tv81 = ~v80;\n\tv82 = v75 - 1;\n\tv84 = v82 == 0;\n\tv89 = ~v84;\n\tv90 = v81 & v89;\n\tif (v90) goto L_FFFFFFFF;\n\tv94 = id == 0;\n\tif (v94) goto L_FFFFFFFF;\n\tv125 = *([id @ X2 (System.Object)]) == System.String;\n\tif (v125) goto L_0071;\n\tv124 = *([id @ X2 (System.Object)]) == System.Int32;\n\tif (v124) goto L_0073;\n\tgoto L_FFFFFFFF;\nL_0071:\n\tgoto L_FFFFFFFF;\nL_0073:\n\tv140 = \"il2cpp_vm_object_unbox\"(id, filterType, id, optionalBool, optionalObj, optionalArray, methodInfo, v49, optionalFloat, v50, v51, v52, v53, v54, v55, v56);\n\tgoto L_0080;\n\tv154 = \"il2cpp_codegen_runtime_class_init\"(v144, filterType, id, optionalBool, optionalObj, optionalArray, methodInfo, v49, optionalFloat, v50, v51, v52, v53, v54, v55, v56);\n\tv156 = DG.Tweening.Core.TweenManager;\nL_0080:\n\tv225 = v157._maxActiveLookupId;\n\tv159 = v157._maxActiveLookupId & 0x80000000;\n\tv160 = v159 == 0;\n\tv161 = ~v160;\n\tif (v161) goto L_FFFFFFFF;\nL_009E:\n\tgoto L_00A2;\n\tv295 = \"il2cpp_codegen_runtime_class_init\"(v219, filterType, id, optionalBool, optionalObj, optionalArray, methodInfo, v49, optionalFloat, v50, v51, v52, v53, v54, v55, v56);\n\tv297 = DG.Tweening.Core.TweenManager;\nL_00A2:\n\tv299 = v298._activeTweens;\n\tv195 = v299[v225 @ X20_v5 (System.Int32)];\n\tv426 = v299[v225 @ X20_v5 (System.Int32)] == 0;\n\tif (v426) goto L_0319;\n\tv364 = ~v195.<active>k__BackingField;\n\tif (v364) goto L_0319;\n\tv440 = filterType < 3;\n\tv356 = ~v440;\n\tv353 = filterType - 3;\n\tv347 = v353 == 0;\n\tv441 = ~v347;\n\tv324 = v356 & v441;\n\tif (v324) goto L_0319;\n\tv313 = 0x424000 + 0x17B;\n\tv318 = *([v313 @ X11_v2 (System.Int32)+filterType @ X1 (DG.Tweening.Core.Enums.FilterType)]) << 2;\n\tv359 = 0xC34E00 + v318;\n\t// 203 IndirectJump v359 @ X9_v8 (System.Int32), v296 @ X0_v8 (Il2CppClass<DG.Tweening.Core.TweenManager>), v296 @ X0_v8 (Il2CppClass<DG.Tweening.Core.TweenManager>), filterType @ X1 (DG.Tweening.Core.Enums.FilterType), id @ X2 (System.Object), optionalBool @ X3 (System.Boolean), optionalObj @ X4 (System.Object), optionalArray @ X5 (System.Object[]), methodInfo @ X6 (Il2CppMethodInfo), v49 @ X7, optionalFloat @ V0 (System.Single), v50 @ V1, v51 @ V2, v52 @ V3, v53 @ V4, v54 @ V5, v55 @ V6, v56 @ V7\n\tTEMP = X25 & 1;\n\tif (TEMP) goto L_0189;\n\tX0 = *([X28+38]);\n\tif (TEMP) goto L_01BF;\n\tX1 = X26;\n\tX2 = 0;\n\tX0 = System.String::op_Equality(X0, X1, X2);\n\tgoto L_00ED;\n\tTEMP = X25 & 1;\n\tif (TEMP) goto L_019B;\n\tX8 = *([X28+48]);\n\tif (TEMP) goto L_01BF;\n\tX0 = *([X28+38]);\n\tX1 = X26;\n\tX2 = 0;\n\tX0 = System.String::op_Equality(X0, X1, X2);\n\tX8 = stack[18];\n\tX25 = 1;\n\tif (TEMP) goto L_0319;\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0319;\n\tX0 = stack[18];\n\tX1 = *([X28+48]);\n\tX8 = *([X0]);\n\tX9 = *([X8+138]);\n\tX2 = *([X8+140]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00ED:\n\tX25 = 1;\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0200;\n\tgoto L_0319;\n\tX8 = stack[20];\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_0200;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX22 = 0;\nL_0103:\n\tX8 = *([X19+18]);\n\tC = X22 < X8;\n\tC = ~C;\n\tTEMP1 = X22 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X8;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_FFFFFFFF;\n\tX29 = *([X24+X22*8]);\n\tif (TEMP) goto L_012C;\n\tX8 = *([19353E0]);\n\tX9 = *([X8]);\n\tX8 = *([X29]);\n\tC = X8 < X9;\n\tC = ~C;\n\tTEMP1 = X8 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X9;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_0132;\n\tX9 = *([19360E8]);\n\tX9 = *([X9]);\n\tC = X8 < X9;\n\tC = ~C;\n\tTEMP1 = X8 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X9;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_0134;\nL_012C:\n\tTEMP = X25 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_013C;\n\tX25 = 0;\n\tgoto L_0145;\nL_0132:\n\tX26 = X29;\n\tgoto L_013C;\nL_0134:\n\tX0 = X29;\n\tX0 = 0xAD95A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X0]);\n\tstack[2C] = X8;\n\tTEMP = X25 & 1;\n\tif (TEMP) goto L_0187;\n\tX21 = 1;\nL_013C:\n\tX0 = *([X28+38]);\n\tX1 = X26;\n\tX2 = 0;\n\tX0 = System.String::op_Equality(X0, X1, X2);\n\tX25 = 1;\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0319;\nL_0145:\n\tTEMP = X21 & 1;\n\tif (TEMP) goto L_0157;\nL_0148:\n\tX8 = *([X28+40]);\n\tX9 = stack[2C];\n\tX21 = 1;\n\tC = X8 < X9;\n\tC = ~C;\n\tTEMP1 = X8 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X9;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0158;\n\tgoto L_0319;\nL_0157:\n\tX21 = 0;\nL_0158:\n\tX1 = *([X28+30]);\n\tif (TEMP) goto L_016B;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X29]);\n\tX0 = X29;\n\tX9 = *([X8+138]);\n\tX2 = *([X8+140]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0319;\n\tX1 = *([X28+48]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0170;\n\tgoto L_0179;\nL_016B:\n\tX1 = *([X28+48]);\n\tif (TEMP) goto L_0179;\n\tif (TEMP) goto L_FFFFFFFF;\nL_0170:\n\tX8 = *([X29]);\n\tX0 = X29;\n\tX9 = *([X8+138]);\n\tX2 = *([X8+140]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0319;\nL_0179:\n\tX8 = stack[38];\n\tX22 = X22 + 1;\n\tC = X8 < X22;\n\tC = ~C;\n\tTEMP1 = X8 - X22;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X22;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0103;\n\tgoto L_0200;\nL_0187:\n\tX25 = 0;\n\tgoto L_0148;\nL_0189:\n\tTEMP = X21 & 1;\n\tif (TEMP) goto L_01C1;\n\tX8 = *([X28+40]);\n\tX9 = stack[2C];\n\tX25 = 0;\n\tX21 = 1;\n\tC = X8 < X9;\n\tC = ~C;\n\tTEMP1 = X8 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X9;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_0200;\n\tgoto L_0319;\nL_019B:\n\tTEMP = X21 & 1;\n\tif (TEMP) goto L_01D1;\n\tX1 = *([X28+48]);\n\tif (TEMP) goto L_01E8;\n\tX8 = stack[18];\n\tX25 = 0;\n\tX21 = 1;\n\tif (TEMP) goto L_0319;\n\tX8 = *([X28+40]);\n\tX9 = stack[2C];\n\tC = X8 < X9;\n\tC = ~C;\n\tTEMP1 = X8 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X9;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0319;\n\tX0 = stack[18];\n\tX8 = *([X0]);\n\tX9 = *([X8+138]);\n\tX2 = *([X8+140]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX25 = 0;\n\tX21 = 1;\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0200;\n\tgoto L_0319;\nL_01BF:\n\tX25 = 1;\n\tgoto L_0319;\nL_01C1:\n\tX1 = *([X28+30]);\n\tif (TEMP) goto L_01EB;\n\tX0 = stack[8];\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X0]);\n\tX9 = *([X8+138]);\n\tX2 = *([X8+140]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, \n// ... truncated")]
		internal static int FilteredOperation(OperationType operationType, FilterType filterType, object id, bool optionalBool, float optionalFloat, object optionalObj = null, object[] optionalArray = null)
		{
			//IL_0383: Expected I, but got O
			//IL_0408: Expected I4, but got I8
			//IL_018b: Expected I, but got O
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
			nint num3 = (nint)typeof(TweenManager);
			int num4 = _maxActiveLookupId;
			if ((int)(_maxActiveLookupId & 0x80000000L) != 0)
			{
				return 0;
			}
			int num9 = default(int);
			while (true)
			{
				Tween[] activeTweens = _activeTweens;
				Tween tween = activeTweens[num4];
				if (activeTweens[num4] != null && tween.active)
				{
					bool flag5 = filterType < FilterType.AllExceptTargetsOrIds;
					bool flag6 = !flag5;
					int num5 = (int)(filterType - 3);
					bool flag7 = num5 == 0;
					bool flag8 = !flag7;
					if (!(flag6 && flag8))
					{
						int num6 = 4341760 + 379;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ X11_v2 (System.Int32)+filterType @ X1 (DG.Tweening.Core.Enums.FilterType)]");
						int num7 = (int)((nint)0 << 2);
						int num8 = 12799488 + num7;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v359 @ X9_v8 (System.Int32) (should have been resolved before IL gen)");
						goto IL_017d;
					}
				}
				num9 = num4 - 1;
				if (num4 < 1)
				{
					break;
				}
				goto IL_017d;
				IL_017d:
				num3 = (nint)typeof(TweenManager);
				num4 = num9;
			}
			return 0;
		}

		[Token(Token = "0x600043D")]
		[Address(RVA = "0xC315A4", Offset = "0xC315A4", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = DG.Tweening.Core.TweenManager;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, modifyActiveLists, updateMode, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A357F9]) = v39;\nL_0017:\n\tv42 = t.loops + 1;\n\tv44 = v42 == 0;\n\tif (v44) goto L_FFFFFFFF;\n\tv49 = ~t.isComplete;\n\tif (v49) goto L_0026;\n\tgoto L_004C;\nL_0026:\n\tv57 = DG.Tweening.Tween::DoGoto(t, t.duration, t.loops, updateMode);\n\tt.isPlaying = 0;\n\tv97 = ~t.autoKill;\n\tif (v97) goto L_FFFFFFFF;\n\tv99 = ~t.<active>k__BackingField;\n\tif (v99) goto L_FFFFFFFF;\n\tgoto L_0039;\n\tv114 = \"il2cpp_codegen_runtime_class_init\"(v110, v41, v55, v56, v25, v26, v27, v28, v53, v30, v31, v32, v33, v34, v35, v36);\n\tv115 = DG.Tweening.Core.TweenManager;\nL_0039:\n\tv105 = ~v116.isUpdateLoop;\n\tif (v105) goto L_0040;\n\tt.<active>k__BackingField = 0;\n\tgoto L_FFFFFFFF;\nL_0040:\n\tgoto L_0044;\n\tv118 = \"il2cpp_codegen_runtime_class_init\"(v103, v41, v55, v56, v25, v26, v27, v28, v53, v30, v31, v32, v33, v34, v35, v36);\nL_0044:\n\tDG.Tweening.Core.TweenManager::Despawn(t, modifyActiveLists);\nL_004C:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool Complete(Tween t, bool modifyActiveLists = true, UpdateMode updateMode = UpdateMode.Goto)
		{
			if (t.loops + 1 == 0 || t.isComplete)
			{
				return false;
			}
			bool flag = Tween.DoGoto(t, t.duration, t.loops, updateMode);
			t.isPlaying = false;
			if (t.autoKill && t.active)
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

		[Token(Token = "0x600043E")]
		[Address(RVA = "0xC31684", Offset = "0xC31684", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = t.isBackwards ^ 1;\n\tt.isBackwards = v7;\n\treturn 1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool Flip(Tween t)
		{
			int isBackwards = (t.isBackwards ? 1 : 0) ^ 1;
			t.isBackwards = (byte)isBackwards != 0;
			return true;
		}

		[Token(Token = "0x600043F")]
		[Address(RVA = "0xC314F4", Offset = "0xC314F4", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = DG.Tweening.Core.TweenManager;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, isSequenced, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A357FA]) = v36;\nL_0015:\n\tv39 = ~t.startupDone;\n\tif (v39) goto L_001D;\nL_001C:\n\treturn;\nL_001D:\n\t;\n\tv47 = DG.Tweening.Tween::Startup(t);\n\tv64 = v47 == 0;\n\tv50 = ~v64;\n\tif (v50) goto L_001C;\n\tv82 = isSequenced == 0;\n\tv51 = ~v82;\n\tif (v51) goto L_001C;\n\tgoto L_0035;\n\tv88 = \"il2cpp_codegen_runtime_class_init\"(v84, v42, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv89 = DG.Tweening.Core.TweenManager;\nL_0035:\n\tv52 = ~v90.isUpdateLoop;\n\tif (v52) goto L_003C;\n\tt.<active>k__BackingField = 0;\n\tgoto L_001C;\nL_003C:\n\tgoto L_0044;\n\tv92 = \"il2cpp_codegen_runtime_class_init\"(v48, v42, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0044:\n\tDG.Tweening.Core.TweenManager::RemoveActiveTween(t);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000440")]
		[Address(RVA = "0xC316AC", Offset = "0xC316AC", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv214 = t.duration;\n\tv30 = t.duration < 0;\n\tv31 = ~v30;\n\tv34 = t.duration == 0;\n\tt.isPlaying = andPlay;\n\tt.delayComplete = 1;\n\tt.elapsedDelay = t.delay;\n\tv39 = ~v31;\n\tv40 = v39 | v34;\n\tif (v40) goto L_004D;\n\tgoto L_002F;\n\tv99 = System.Math;\n\tv100 = \"il2cpp_codegen_initialize_runtime_metadata\"(v99, andPlay, updateMode, methodInfo, v43, v44, v45, v46, v22, v47, v48, v49, v50, v51, v52, v53);\n\tv103 = 1;\n\t*([1A35822]) = v103;\nL_002F:\n\tv106 = to / t.duration;\n\tgoto L_0036;\n\tv177 = \"il2cpp_codegen_runtime_class_init\"(v107, andPlay, updateMode, methodInfo, v43, v44, v45, v46, v22, v47, v48, v49, v50, v51, v52, v53);\nL_0036:\n\tv90 = UnityEngine.Mathf::Floor(v106);\n\tv214 = t.duration;\n\tv60 = v90 != 0x7F800000;\n\tif (v60) goto L_FFFFFFFF;\n\tgoto L_004D;\nL_004D:\n\tv97 = 0x1854EF0(v66, andPlay, updateMode, methodInfo, v43, v44, v45, v46, to, v214, v48, v49, v50, v51, v52, v53);\n\tv111 = t.loops + 1;\n\tv113 = v111 == 0;\n\tif (v113) goto L_006C;\n\tv188 = v213 < t.loops;\n\tif (v188) goto L_006C;\n\tgoto L_0076;\nL_006C:\n\tv207 = to >= v214;\n\tif (v207) goto L_FFFFFFFF;\n\tgoto L_0076;\nL_0076:\n\tv218 = DG.Tweening.Tween::DoGoto(t, v214, v213, updateMode);\n\tv219 = ~andPlay;\n\tv159 = t.isPlaying & v219;\n\tv222 = v159 == 0;\n\tif (v222) goto L_0091;\n\tv224 = v218 == 0;\n\tv225 = ~v224;\n\tif (v225) goto L_0091;\n\tv231 = t.onPause == 0;\n\tif (v231) goto L_0091;\n\tv229 = DG.Tweening.Tween::OnTweenCallback(t.onPause, t);\nL_0091:\n\treturn v218;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 101 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool Goto(Tween t, float to, bool andPlay = false, UpdateMode updateMode = UpdateMode.Goto)
		{
			//IL_020a: Expected O, but got F4
			//IL_011f: Expected I4, but got F4
			//IL_0104: Expected I4, but got I8
			float num = t.duration;
			bool flag = t.duration < 0f;
			bool flag2 = !flag;
			bool flag3 = t.duration == 0f;
			t.isPlaying = andPlay;
			t.delayComplete = true;
			t.elapsedDelay = t.delay;
			bool flag4 = !flag2;
			bool flag5 = flag4 || flag3;
			Tween tween = t;
			bool flag6 = true;
			if (!flag5)
			{
				float num2 = to / t.duration;
				float num3 = Mathf.Floor(num2);
				num = t.duration;
				if (num3 == float.PositiveInfinity)
				{
					tween = (Tween)(object)typeof(Math);
					flag6 = false;
				}
				else
				{
					tween = (Tween)(object)typeof(Math);
					flag6 = (byte)(int)num2 != 0;
				}
			}
			object obj = to % num;
			if (t.loops + 1 == 0 || (flag6 ? 1 : 0) < t.loops)
			{
				num = ((!(to < num)) ? 0f : to);
			}
			else
			{
				flag6 = (byte)t.loops != 0;
			}
			bool flag7 = Tween.DoGoto(t, num, flag6 ? 1 : 0, updateMode);
			bool flag8 = !andPlay;
			if (t.isPlaying && flag8 && !flag7 && t.onPause != null)
			{
				bool flag9 = Tween.OnTweenCallback(t.onPause, t);
			}
			return flag7;
		}

		[Token(Token = "0x6000441")]
		[Address(RVA = "0xC2FE18", Offset = "0xC2FE18", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = ~t.isPlaying;\n\tif (v8) goto L_0013;\n\tt.isPlaying = 0;\n\tv26 = t.onPause == 0;\n\tif (v26) goto L_0013;\n\tv30 = DG.Tweening.Tween::OnTweenCallback(t.onPause, t);\nL_0013:\n\tv36 = t.isPlaying == 0;\n\tv41 = ~v36;\n\treturn v41;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool Pause(Tween t)
		{
			if (t.isPlaying)
			{
				t.isPlaying = false;
				if (t.onPause != null)
				{
					bool flag = Tween.OnTweenCallback(t.onPause, t);
				}
			}
			bool flag2 = !t.isPlaying;
			return !flag2;
		}

		[Token(Token = "0x6000442")]
		[Address(RVA = "0xC2FD98", Offset = "0xC2FD98", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = ~t.isPlaying;\n\tif (v6) goto L_000D;\nL_000B:\n\treturn returnVal2;\nL_000D:\n\tv59 = ~t.isBackwards;\n\tif (v59) goto L_002D;\n\tv107 = t.completedLoops > 0;\n\tif (v107) goto L_0032;\n\tv30 = t.<position>k__BackingField <= 0;\n\tif (v30) goto L_FFFFFFFF;\n\tgoto L_0032;\nL_002D:\n\tv108 = ~t.isComplete;\n\tv60 = ~v108;\n\tif (v60) goto L_FFFFFFFF;\nL_0032:\n\tt.isPlaying = 1;\n\tv94 = ~t.<playedOnce>k__BackingField;\n\tif (v94) goto L_000B;\n\tv132 = ~t.delayComplete;\n\tif (v132) goto L_FFFFFFFF;\n\tv134 = t.onPlay == 0;\n\tif (v134) goto L_FFFFFFFF;\n\tv137 = DG.Tweening.Tween::OnTweenCallback(t.onPlay, t);\n\tgoto L_000B;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
					bool flag2 = Tween.OnTweenCallback(t.onPlay, t);
				}
				result = true;
			}
			goto IL_015f;
			IL_001e:
			result = false;
			goto IL_015f;
			IL_015f:
			return result;
		}

		[Token(Token = "0x6000443")]
		[Address(RVA = "0xC317E8", Offset = "0xC317E8", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A357FB]) = v33;\nL_0015:\n\tv38 = t.completedLoops == 0;\n\tv39 = ~v38;\n\tif (v39) goto L_0026;\n\tv42 = t.<position>k__BackingField < 0;\n\tv43 = ~v42;\n\tv46 = t.<position>k__BackingField == 0;\n\tv51 = ~v43;\n\tv52 = v51 | v46;\n\tif (v52) goto L_0045;\nL_0026:\n\tv73 = ~t.isBackwards;\n\tif (v73) goto L_0036;\n\tgoto L_0033;\n\tv133 = \"il2cpp_codegen_runtime_class_init\"(v78, methodInfo, v17, v18, v19, v20, v21, v22, v71, v24, v25, v26, v27, v28, v29, v30);\nL_0033:\n\treturnVal2 = DG.Tweening.Core.TweenManager::Play(t);\n\treturn returnVal2;\nL_0036:\n\tt.isBackwards = 1;\n\tgoto L_003E;\n\tv136 = \"il2cpp_codegen_runtime_class_init\"(v83, methodInfo, v17, v18, v19, v20, v21, v22, v71, v24, v25, v26, v27, v28, v29, v30);\nL_003E:\n\tv139 = DG.Tweening.Core.TweenManager::Play(t);\n\tgoto L_0052;\nL_0045:\n\tgoto L_004A;\n\tv128 = \"il2cpp_codegen_runtime_class_init\"(v74, methodInfo, v17, v18, v19, v20, v21, v22, v41, v24, v25, v26, v27, v28, v29, v30);\nL_004A:\n\tDG.Tweening.Core.TweenManager::ManageOnRewindCallbackWhenAlreadyRewinded(t, 1);\n\tt.isBackwards = 1;\n\tt.isPlaying = 0;\nL_0052:\n\treturn returnVal3;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000444")]
		[Address(RVA = "0xC318C0", Offset = "0xC318C0", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A357FC]) = v33;\nL_0013:\n\tv36 = ~t.isComplete;\n\tif (v36) goto L_001A;\n\tt.isBackwards = 0;\n\tt.isPlaying = 0;\n\tgoto L_002C;\nL_001A:\n\tv40 = ~t.isBackwards;\n\tif (v40) goto L_0033;\n\tt.isBackwards = 0;\n\tgoto L_0026;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v52, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0026:\n\tv73 = DG.Tweening.Core.TweenManager::Play(t);\nL_002C:\n\treturn returnVal2;\nL_0033:\n\tgoto L_003A;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v56, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003A:\n\treturnVal3 = DG.Tweening.Core.TweenManager::Play(t);\n\treturn returnVal3;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000445")]
		[Address(RVA = "0xC31970", Offset = "0xC31970", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv22 = DG.Tweening.Core.TweenManager;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, includeDelay, methodInfo, v25, v26, v27, v28, v29, changeDelayTo, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A357FD]) = v39;\nL_0022:\n\tt.isBackwards = 0;\n\tv54 = changeDelayTo < 0;\n\tif (v54) goto L_002F;\n\tv57 = t.tweenType == 0;\n\tv58 = ~v57;\n\tif (v58) goto L_002F;\n\tt.delay = changeDelayTo;\nL_002F:\n\tgoto L_0033;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v62, includeDelay, methodInfo, v25, v26, v27, v28, v29, changeDelayTo, v30, v31, v32, v33, v34, v35, v36);\nL_0033:\n\tv70 = DG.Tweening.Core.TweenManager::Rewind(t, includeDelay);\n\tv93 = t.isPlaying == 1;\n\tt.isPlaying = 1;\n\tif (v93) goto L_0053;\n\tv121 = ~t.<playedOnce>k__BackingField;\n\tif (v121) goto L_0053;\n\tv128 = ~t.delayComplete;\n\tif (v128) goto L_0053;\n\tv127 = t.onPlay == 0;\n\tif (v127) goto L_0053;\n\tv125 = DG.Tweening.Tween::OnTweenCallback(t.onPlay, t);\nL_0053:\n\treturn 1;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool Restart(Tween t, bool includeDelay = true, float changeDelayTo = -1f)
		{
			t.isBackwards = false;
			if (!(changeDelayTo < 0f) && t.tweenType == TweenType.Tweener)
			{
				t.delay = changeDelayTo;
			}
			bool flag = Rewind(t, includeDelay);
			bool flag2 = t.isPlaying;
			t.isPlaying = true;
			if (!flag2 && t.playedOnce && t.delayComplete && t.onPlay != null)
			{
				bool flag3 = Tween.OnTweenCallback(t.onPlay, t);
			}
			return true;
		}

		[Token(Token = "0x6000446")]
		[Address(RVA = "0xC31A38", Offset = "0xC31A38", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = DG.Tweening.Core.TweenManager;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, includeDelay, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A357FE]) = v38;\nL_0015:\n\tv113 = t.delay;\n\tt.isPlaying = 0;\n\tv54 = t.delay <= 0;\n\tif (v54) goto L_0063;\n\tv58 = ~includeDelay;\n\tv63 = t.elapsedDelay - t.delay;\n\tv64 = v63 < 0;\n\tv74 = t.elapsedDelay < 0;\n\tv75 = t.elapsedDelay == 0;\n\tv77 = t.elapsedDelay ^ t.elapsedDelay;\n\tv78 = t.elapsedDelay & v77;\n\tv79 = v78 < 0;\n\tv80 = v74 == v79;\n\tv81 = ~v75;\n\tv82 = v80 & v81;\n\tv86 = includeDelay == 0;\n\tv89 = ~v86;\n\tv90 = ~v89;\n\tif (v90) goto L_004E;\n\tgoto L_004E;\nL_004E:\n\tv103 = ~v86;\n\tv92 = ~v103;\n\tif (v92) goto L_FFFFFFFF;\n\tgoto L_0055;\nL_0055:\n\tt.elapsedDelay = v113;\n\tt.delayComplete = v58;\nL_0063:\n\tv130 = t.<position>k__BackingField > 0;\n\tif (v130) goto L_0079;\n\tv145 = t.completedLoops <= 0;\n\tif (v145) goto L_008F;\nL_0079:\n\tv165 = DG.Tweening.Tween::DoGoto(t, 0f, 0, 1);\n\tv223 = ~v165;\n\tv224 = t.isPlaying & v223;\n\tv225 = v224 & 1;\n\tv226 = v225 == 0;\n\tif (v226) goto L_008D;\n\tv236 = t.onPause == 0;\n\tif (v236) goto L_FFFFFFFF;\n\tv249 = DG.Tweening.Tween::OnTweenCallback(t.onPause, t);\nL_008D:\n\treturn v243;\nL_008F:\n\tv156 = ~t.startupDone;\n\tif (v156) goto L_0079;\n\tgoto L_009B;\n\tv245 = \"il2cpp_codegen_runtime_class_init\"(v231, includeDelay, methodInfo, v23, v24, v25, v26, v27, v118, v101, v100, v31, v32, v33, v34, v35);\nL_009B:\n\tDG.Tweening.Core.TweenManager::ManageOnRewindCallbackWhenAlreadyRewinded(t, 0);\n\tgoto L_008D;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 106 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool Rewind(Tween t, bool includeDelay = true)
		{
			//IL_00c8: Expected I4, but got F4
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Expected I4, but got Unknown
			float elapsedDelay = t.delay;
			t.isPlaying = false;
			bool flag = !(t.delay > 0f);
			bool result = false;
			if (!flag)
			{
				bool delayComplete = !includeDelay;
				float num = t.elapsedDelay - t.delay;
				bool flag2 = num < 0f;
				bool flag3 = t.elapsedDelay < 0f;
				bool flag4 = t.elapsedDelay == 0f;
				int num2 = t.elapsedDelay ^ t.elapsedDelay;
				int num3 = t.elapsedDelay & num2;
				bool flag5 = num3 < 0;
				bool flag6 = flag3 == flag5;
				bool flag7 = !flag4;
				bool flag8 = flag6 && flag7;
				bool flag9 = !includeDelay;
				if (!flag9)
				{
					elapsedDelay = 0f;
				}
				result = (flag9 ? flag2 : flag8);
				t.elapsedDelay = elapsedDelay;
				t.delayComplete = delayComplete;
			}
			if (t.position > 0f || t.completedLoops > 0 || !t.startupDone)
			{
				bool flag10 = Tween.DoGoto(t, 0f, 0, UpdateMode.Goto);
				bool flag11 = !flag10;
				int num4 = ((t.isPlaying && flag11) ? 1 : 0);
				int num5 = num4 & 1;
				bool flag12 = num5 == 0;
				result = true;
				if (!flag12)
				{
					if (t.onPause != null)
					{
						bool flag13 = Tween.OnTweenCallback(t.onPause, t);
					}
					result = true;
				}
			}
			else
			{
				ManageOnRewindCallbackWhenAlreadyRewinded(t, isPlayBackwardsOrSmoothRewind: false);
			}
			return result;
		}

		[Token(Token = "0x6000447")]
		[Address(RVA = "0xC31B58", Offset = "0xC31B58", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A357FF]) = v33;\nL_001E:\n\tv47 = t.delay <= 0;\n\tif (v47) goto L_FFFFFFFF;\n\tt.elapsedDelay = t.delay;\n\tt.delayComplete = 1;\n\tv53 = t.elapsedDelay - t.delay;\n\tv54 = v53 < 0;\n\tgoto L_003C;\nL_003C:\n\tv85 = t.<position>k__BackingField > 0;\n\tif (v85) goto L_0051;\n\tv147 = t.completedLoops <= 0;\n\tif (v147) goto L_006B;\nL_0051:\n\tv166 = t.loopType == 2;\n\tif (v166) goto L_0062;\n\tv173 = DG.Tweening.TweenExtensions::ElapsedDirectionalPercentage(t);\n\tv181 = v173 * t.duration;\n\tDG.Tweening.TweenExtensions::Goto(t, v181, 0);\nL_0062:\n\tDG.Tweening.TweenExtensions::PlayBackwards(t);\nL_0069:\n\treturn v198;\nL_006B:\n\tv158 = ~t.startupDone;\n\tif (v158) goto L_0051;\n\tt.isPlaying = 0;\n\tgoto L_0078;\n\tv193 = \"il2cpp_codegen_runtime_class_init\"(v188, methodInfo, v17, v18, v19, v20, v21, v22, v73, v62, v25, v26, v27, v28, v29, v30);\nL_0078:\n\tDG.Tweening.Core.TweenManager::ManageOnRewindCallbackWhenAlreadyRewinded(t, 1);\n\tgoto L_0069;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000448")]
		[Address(RVA = "0xC31C54", Offset = "0xC31C54", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A35800]) = v33;\nL_0019:\n\tgoto L_001C;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001C:\n\tv46 = ~t.isPlaying;\n\tif (v46) goto L_0028;\n\treturnVal2 = DG.Tweening.Core.TweenManager::Pause(t);\n\treturn returnVal2;\nL_0028:\n\treturnVal3 = DG.Tweening.Core.TweenManager::Play(t);\n\treturn returnVal3;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool TogglePause(Tween t)
		{
			if (t.isPlaying)
			{
				return Pause(t);
			}
			return Play(t);
		}

		[Token(Token = "0x6000449")]
		[Address(RVA = "0xC31D64", Offset = "0xC31D64", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = DG.Tweening.Core.TweenManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35801]) = v34;\nL_0015:\n\tgoto L_001D;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = DG.Tweening.Core.TweenManager;\nL_001D:\n\treturnVal1 = v42.totPooledSequences + v42.totPooledTweeners;\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int TotalPooledTweens()
		{
			return totPooledSequences + totPooledTweeners;
		}

		[Token(Token = "0x600044A")]
		[Address(RVA = "0xC31DC0", Offset = "0xC31DC0", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = DG.Tweening.Core.TweenManager;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 1;\n\t*([1A35802]) = v36;\nL_0016:\n\tgoto L_001B;\n\tv41 = \"il2cpp_codegen_runtime_class_init\"(v37, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv43 = DG.Tweening.Core.TweenManager;\nL_001B:\n\tv46 = ~v44.hasActiveTweens;\n\tif (v46) goto L_FFFFFFFF;\n\tgoto L_0025;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v42, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv53 = DG.Tweening.Core.TweenManager;\n\tv55 = *([v53 @ X0_v22+B8]);\nL_0025:\n\tv57 = ~v54._requiresActiveReorganization;\n\tif (v57) goto L_FFFFFFFF;\n\tgoto L_002C;\n\tv144 = \"il2cpp_codegen_runtime_class_init\"(v52, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_002C:\n\tDG.Tweening.Core.TweenManager::ReorganizeActiveTweens();\nL_0033:\n\tgoto L_0038;\n\tv175 = \"il2cpp_codegen_runtime_class_init\"(v166, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv176 = DG.Tweening.Core.TweenManager;\nL_0038:\n\tv97 = v177._maxActiveLookupId + 1;\n\tv62 = v59 >= v97;\n\tif (v62) goto L_0069;\n\tgoto L_004B;\n\tv183 = \"il2cpp_codegen_runtime_class_init\"(v93, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv184 = DG.Tweening.Core.TweenManager;\nL_004B:\n\tv141 = v185._activeTweens;\n\tv189 = v141[v59 @ X21_v4 (System.Int32)];\n\tv169 = v141[v59 @ X21_v4 (System.Int32)] == 0;\n\tif (v169) goto L_0060;\n\tv172 = v172 + v189.isPlaying;\nL_0060:\n\tv59 = v59 + 1;\n\tgoto L_0033;\nL_0069:\n\treturn v172;\n\tv187 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
					Tween tween = activeTweens[num2];
					if (activeTweens[num2] != null)
					{
						num += (tween.isPlaying ? 1 : 0);
					}
					num2++;
				}
			}
			return num;
		}

		[Token(Token = "0x600044B")]
		[Address(RVA = "0xC31ECC", Offset = "0xC31ECC", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = DG.Tweening.Core.TweenManager;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, playingOnly, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A35803]) = v40;\nL_0019:\n\tgoto L_001E;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, playingOnly, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv47 = DG.Tweening.Core.TweenManager;\nL_001E:\n\tv50 = ~v48._requiresActiveReorganization;\n\tif (v50) goto L_002A;\n\tgoto L_0025;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v46, playingOnly, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0025:\n\tDG.Tweening.Core.TweenManager::ReorganizeActiveTweens();\nL_002A:\n\tgoto L_0039;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v54, playingOnly, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv65 = DG.Tweening.Core.TweenManager;\nL_0039:\n\tv78 = v66.totActiveTweens < 1;\n\tif (v78) goto L_0053;\n\tgoto L_004A;\n\tv88 = \"il2cpp_codegen_runtime_class_init\"(v64, playingOnly, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_004A:\n\treturnVal2 = DG.Tweening.Core.TweenManager::DoGetTweensById(id, playingOnly, 0, 0);\n\treturn returnVal2;\nL_0053:\n\treturn 0;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int TotalTweensById(object id, bool playingOnly)
		{
			if (_requiresActiveReorganization)
			{
				ReorganizeActiveTweens();
			}
			if (totActiveTweens >= 1)
			{
				return DoGetTweensById(id, playingOnly, addToList: false, null);
			}
			return 0;
		}

		[Token(Token = "0x600044C")]
		[Address(RVA = "0xC321F4", Offset = "0xC321F4", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, fillableList, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv51 = Il2CppMethodInfo;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, fillableList, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv60 = Il2CppMethodInfo;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, fillableList, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv73 = System.Collections.Generic.List`1<DG.Tweening.Tween>;\n\tv74 = \"il2cpp_codegen_initialize_runtime_metadata\"(v73, fillableList, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv94 = DG.Tweening.Core.TweenManager;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v94, fillableList, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv45 = 1;\n\t*([1A35804]) = v45;\n\tgoto L_002C;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v46, fillableList, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = DG.Tweening.Core.TweenManager;\nL_002C:\n\tv58 = ~v56._requiresActiveReorganization;\n\tif (v58) goto L_0038;\n\tgoto L_0033;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v54, fillableList, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0033:\n\tDG.Tweening.Core.TweenManager::ReorganizeActiveTweens();\nL_0038:\n\tgoto L_003C;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v65, fillableList, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv79 = DG.Tweening.Core.TweenManager;\nL_003C:\n\tv152 = v80.totActiveTweens;\n\tv92 = v80.totActiveTweens < 1;\n\tif (v92) goto L_FFFFFFFF;\n\tv96 = *([v78 @ X0_v5 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]) == 0;\n\tif (v96) goto L_00D3;\n\tv98 = fillableList == 0;\n\tif (v98) goto L_00DA;\nL_0058:\n\tv185 = v152 < 1;\n\tif (v185) goto L_00B6;\nL_0062:\n\tgoto L_0066;\n\tv353 = \"il2cpp_codegen_runtime_class_init\"(v295, v279, v276, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv354 = DG.Tweening.Core.TweenManager;\nL_0066:\n\tv351 = v355._activeTweens;\n\tv247 = v351[v282 @ X23_v7 (System.Int32)];\n\tv314 = v247.isPlaying != playing;\n\tif (v314) goto L_00A5;\n\tv350 = v148._items;\n\tv304 = v148._version + 1;\n\tv148._version = v304;\n\tv363 = v148._size;\n\tv387 = v148._size < v350.Length;\n\tv381 = ~v387;\n\tif (v381) goto L_00A4;\n\tv365 = v148._size + 1;\n\tv148._size = v365;\n\tv350[v363 @ X10_v9 (System.Int32)] = v351[v282 @ X23_v7 (System.Int32)];\n\tgoto L_00A5;\nL_00A4:\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::AddWithResize(v148, v351[v282 @ X23_v7 (System.Int32)]);\nL_00A5:\n\tv282 = v282 + 1;\n\tv252 = v152 != v282;\n\tif (v252) goto L_0062;\nL_00B6:\n\tv138 = v148._size - 1;\n\tv136 = v138 < 0;\n\tv132 = v148._size ^ 1;\n\tv130 = v148._size ^ v138;\n\tv128 = v132 & v130;\n\tv126 = v128 < 0;\n\tv300 = v136 == v126;\n\tv124 = ~v300;\n\tv102 = ~v124;\n\tif (v102) goto L_FFFFFFFF;\n\tgoto L_00C5;\nL_00C5:\n\tgoto L_00CF;\nL_00CF:\n\treturn returnVal1;\nL_00D3:\n\tv152 = v171.totActiveTweens;\n\tv192 = fillableList == 0;\n\tv167 = ~v192;\n\tif (v167) goto L_0058;\nL_00DA:\n\tv165 = new System.Collections.Generic.List`1<DG.Tweening.Tween>();\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::.ctor(v165, v174);\n\tgoto L_0058;\n\tv352 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 151 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static List<Tween> GetActiveTweens(bool playing, List<Tween> fillableList = null)
		{
			//IL_02fb: Expected I, but got O
			//IL_001d: Expected I, but got O
			nint num = (nint)typeof(TweenManager);
			if (_requiresActiveReorganization)
			{
				ReorganizeActiveTweens();
				num = (nint)typeof(TweenManager);
			}
			int num2 = totActiveTweens;
			List<Tween> list;
			if (totActiveTweens >= 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ X0_v5 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]");
				int num3;
				if ((nint)0 != 0)
				{
					bool flag = fillableList == null;
					list = fillableList;
					num3 = num2;
					if (!flag)
					{
						goto IL_0074;
					}
				}
				else
				{
					num2 = totActiveTweens;
					bool flag2 = fillableList == null;
					bool flag3 = !flag2;
					list = fillableList;
					num3 = totActiveTweens;
					if (flag3)
					{
						goto IL_0074;
					}
				}
				List<Tween> list2 = new List<Tween>(num3);
				list = list2;
				num2 = num3;
				goto IL_0074;
			}
			return null;
			IL_0074:
			if (num2 >= 1)
			{
				int num4 = 0;
				do
				{
					Tween[] activeTweens = _activeTweens;
					Tween tween = activeTweens[num4];
					if (tween.isPlaying == playing)
					{
						Tween[] items = list._items;
						int version = list._version + 1;
						list._version = version;
						int count = list.Count;
						if (list.Count < items.Length)
						{
							int size = list.Count + 1;
							list._size = size;
							items[count] = activeTweens[num4];
						}
						else
						{
							list.Add(activeTweens[num4]);
						}
					}
					num4++;
				}
				while (num2 != num4);
			}
			int num5 = list.Count - 1;
			bool flag4 = num5 < 0;
			int num6 = list.Count ^ 1;
			int num7 = list.Count ^ num5;
			int num8 = num6 & num7;
			bool flag5 = num8 < 0;
			if (flag4 != flag5)
			{
				return null;
			}
			return list;
		}

		[Token(Token = "0x600044D")]
		[Address(RVA = "0xC323F4", Offset = "0xC323F4", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, playingOnly, fillableList, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv50 = Il2CppMethodInfo;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, playingOnly, fillableList, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv59 = System.Collections.Generic.List`1<DG.Tweening.Tween>;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, playingOnly, fillableList, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv72 = DG.Tweening.Core.TweenManager;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, playingOnly, fillableList, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A35805]) = v44;\nL_0024:\n\tgoto L_0029;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v45, playingOnly, fillableList, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv54 = DG.Tweening.Core.TweenManager;\nL_0029:\n\tv57 = ~v55._requiresActiveReorganization;\n\tif (v57) goto L_0035;\n\tgoto L_0030;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v53, playingOnly, fillableList, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0030:\n\tDG.Tweening.Core.TweenManager::ReorganizeActiveTweens();\nL_0035:\n\tgoto L_0044;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v64, playingOnly, fillableList, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv77 = DG.Tweening.Core.TweenManager;\nL_0044:\n\tv90 = v78.totActiveTweens < 1;\n\tif (v90) goto L_FFFFFFFF;\n\tv91 = fillableList == 0;\n\tv92 = ~v91;\n\tif (v92) goto L_005F;\n\tgoto L_0054;\n\tv157 = \"il2cpp_codegen_runtime_class_init\"(v76, playingOnly, fillableList, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv194 = DG.Tweening.Core.TweenManager;\n\tv160 = *([v194 @ X8_v19+B8]);\n\tv161 = *([v160 @ X8_v20+18]);\nL_0054:\n\tv165 = new System.Collections.Generic.List`1<DG.Tweening.Tween>();\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::.ctor(v165, v78.totActiveTweens);\nL_005F:\n\tgoto L_0065;\n\tv166 = \"il2cpp_codegen_runtime_class_init\"(v101, v99, v97, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0065:\n\tv169 = DG.Tweening.Core.TweenManager::DoGetTweensById(id, playingOnly, 1, v104);\n\tv132 = v104._size < 0;\n\tv130 = v104._size == 0;\n\tv126 = v104._size ^ v104._size;\n\tv124 = v104._size & v126;\n\tv122 = v124 < 0;\n\tv197 = v132 == v122;\n\tv118 = ~v130;\n\tv120 = v197 & v118;\n\tv115 = ~v120;\n\tif (v115) goto L_FFFFFFFF;\n\tgoto L_007B;\nL_007B:\n\tgoto L_0084;\nL_0084:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static List<Tween> GetTweensById(object id, bool playingOnly, List<Tween> fillableList = null)
		{
			if (_requiresActiveReorganization)
			{
				ReorganizeActiveTweens();
			}
			if (totActiveTweens >= 1)
			{
				bool flag = fillableList == null;
				bool flag2 = !flag;
				List<Tween> list = fillableList;
				if (!flag2)
				{
					List<Tween> list2 = new List<Tween>(totActiveTweens);
					list = list2;
				}
				int num = DoGetTweensById(id, playingOnly, addToList: true, list);
				bool flag3 = list.Count < 0;
				bool flag4 = list.Count == 0;
				int num2 = list.Count ^ list.Count;
				int num3 = list.Count & num2;
				bool flag5 = num3 < 0;
				bool flag6 = flag3 == flag5;
				bool flag7 = !flag4;
				if (flag6 && flag7)
				{
					return list;
				}
				return null;
			}
			return null;
		}

		[Token(Token = "0x600044E")]
		[Address(RVA = "0xC31F9C", Offset = "0xC31F9C", Length = "0x258")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv38 = System.Int32;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, playingOnly, addToList, fillableList, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv60 = Il2CppMethodInfo;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, playingOnly, addToList, fillableList, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv108 = System.String;\n\tv109 = \"il2cpp_codegen_initialize_runtime_metadata\"(v108, playingOnly, addToList, fillableList, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv142 = DG.Tweening.Core.TweenManager;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v142, playingOnly, addToList, fillableList, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv55 = 1;\n\t*([1A35806]) = v55;\nL_0027:\n\tv58 = id == 0;\n\tif (v58) goto L_FFFFFFFF;\n\tv70 = *([id @ X0 (System.Object)]) == System.String;\n\tif (v70) goto L_FFFFFFFF;\n\tv88 = *([id @ X0 (System.Object)]) == System.Int32;\n\tif (v88) goto L_004F;\n\tgoto L_0058;\n\tgoto L_0058;\nL_004F:\n\tv135 = \"il2cpp_vm_object_unbox\"(id, playingOnly, addToList, fillableList, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv123 = *([v135 @ X0_v27]);\nL_0058:\n\tgoto L_0067;\n\tv144 = \"il2cpp_codegen_runtime_class_init\"(v137, playingOnly, addToList, fillableList, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv146 = DG.Tweening.Core.TweenManager;\nL_0067:\n\tv159 = v147.totActiveTweens < 1;\n\tif (v159) goto L_FFFFFFFF;\n\tv163 = v147.totActiveTweens - 1;\nL_0070:\n\tgoto L_0074;\n\tv248 = \"il2cpp_codegen_runtime_class_init\"(v200, v173, v171, fillableList, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv250 = DG.Tweening.Core.TweenManager;\nL_0074:\n\tv252 = v251._activeTweens;\n\tv176 = v252[v206 @ X20_v5 (System.Int32)];\n\tv351 = v252[v206 @ X20_v5 (System.Int32)] == 0;\n\tif (v351) goto L_00DC;\n\tv353 = v117 == 0;\n\tif (v353) goto L_0093;\n\tv392 = v176.stringId == 0;\n\tif (v392) goto L_00DC;\n\tv390 = System.String::op_Inequality(v176.stringId, v119);\n\tv393 = v390 == 0;\n\tif (v393) goto L_00AB;\n\tgoto L_00DC;\nL_0093:\n\tv394 = v121 == 0;\n\tif (v394) goto L_00A2;\n\tv377 = v176.intId == v123;\n\tif (v377) goto L_00AB;\n\tgoto L_00DC;\nL_00A2:\n\tv395 = v176.id == 0;\n\tif (v395) goto L_00DC;\n\tv391 = System.Object::Equals(id, v176.id);\n\tv396 = v391 == 0;\n\tif (v396) goto L_00DC;\nL_00AB:\n\tv409 = playingOnly == 0;\n\tif (v409) goto L_00B1;\n\tv397 = ~v176.isPlaying;\n\tif (v397) goto L_00DC;\nL_00B1:\n\tv217 = v217 + 1;\n\tv398 = addToList == 0;\n\tif (v398) goto L_00DC;\n\tv348 = fillableList._items;\n\tv313 = fillableList._version + 1;\n\tfillableList._version = v313;\n\tv355 = fillableList._size;\n\tv418 = fillableList._size < v348.Length;\n\tv385 = ~v418;\n\tif (v385) goto L_00D7;\n\tv387 = fillableList._size + 1;\n\tfillableList._size = v387;\n\tv348[v355 @ X10_v8 (System.Int32)] = v252[v206 @ X20_v5 (System.Int32)];\n\tgoto L_00DC;\nL_00D7:\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::AddWithResize(fillableList, v252[v206 @ X20_v5 (System.Int32)]);\nL_00DC:\n\tv191 = v163 == v206;\n\tif (v191) goto L_00F4;\n\tv206 = v206 + 1;\n\tgoto L_0070;\nL_00F4:\n\treturn v217;\n\tv349 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 169 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static int DoGetTweensById(object id, bool playingOnly, bool addToList, List<Tween> fillableList)
		{
			//IL_00b2: Expected I4, but got O
			if (id == null)
			{
				goto IL_0053;
			}
			int num;
			int num2;
			object obj2;
			int num3;
			if ((object)id.GetType() != typeof(string))
			{
				if ((object)id.GetType() != typeof(int))
				{
					goto IL_0053;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				object obj = default(object);
				num = (int)obj;
				num2 = 0;
				obj2 = null;
				num3 = 1;
			}
			else
			{
				num2 = 1;
				obj2 = id;
				num3 = 0;
				num = 0;
			}
			goto IL_03de;
			IL_03de:
			int num5;
			if (totActiveTweens >= 1)
			{
				int num4 = totActiveTweens - 1;
				num5 = 0;
				int num6 = 0;
				while (true)
				{
					Tween[] activeTweens = _activeTweens;
					Tween tween = activeTweens[num6];
					if (activeTweens[num6] != null)
					{
						if (num2 != 0)
						{
							if (tween.stringId != null && !(tween.stringId != (string)obj2))
							{
								goto IL_023a;
							}
						}
						else if (num3 != 0)
						{
							if (tween.intId == num)
							{
								goto IL_023a;
							}
						}
						else if (tween.id != null && object.Equals(id, tween.id))
						{
							goto IL_023a;
						}
					}
					goto IL_0367;
					IL_023a:
					if (!playingOnly || tween.isPlaying)
					{
						num5++;
						if (addToList)
						{
							Tween[] items = fillableList._items;
							int version = fillableList._version + 1;
							fillableList._version = version;
							int count = fillableList.Count;
							if (fillableList.Count < items.Length)
							{
								int size = fillableList.Count + 1;
								fillableList._size = size;
								items[count] = activeTweens[num6];
							}
							else
							{
								fillableList.Add(activeTweens[num6]);
							}
						}
					}
					goto IL_0367;
					IL_0367:
					if (num4 == num6)
					{
						break;
					}
					num6++;
				}
			}
			else
			{
				num5 = 0;
			}
			return num5;
			IL_0053:
			num2 = 0;
			obj2 = null;
			num3 = 0;
			num = 0;
			goto IL_03de;
		}

		[Token(Token = "0x600044F")]
		[Address(RVA = "0xC32540", Offset = "0xC32540", Length = "0x214")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, playingOnly, fillableList, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv54 = Il2CppMethodInfo;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, playingOnly, fillableList, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv63 = Il2CppMethodInfo;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, playingOnly, fillableList, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv76 = System.Collections.Generic.List`1<DG.Tweening.Tween>;\n\tv77 = \"il2cpp_codegen_initialize_runtime_metadata\"(v76, playingOnly, fillableList, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv97 = DG.Tweening.Core.TweenManager;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v97, playingOnly, fillableList, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv48 = 1;\n\t*([1A35807]) = v48;\n\tgoto L_002E;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v49, playingOnly, fillableList, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv58 = DG.Tweening.Core.TweenManager;\nL_002E:\n\tv61 = ~v59._requiresActiveReorganization;\n\tif (v61) goto L_003A;\n\tgoto L_0035;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v57, playingOnly, fillableList, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0035:\n\tDG.Tweening.Core.TweenManager::ReorganizeActiveTweens();\nL_003A:\n\tgoto L_003E;\n\tv80 = \"il2cpp_codegen_runtime_class_init\"(v68, playingOnly, fillableList, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv82 = DG.Tweening.Core.TweenManager;\nL_003E:\n\tv153 = v83.totActiveTweens;\n\tv95 = v83.totActiveTweens < 1;\n\tif (v95) goto L_FFFFFFFF;\n\tv99 = *([v81 @ X0_v5 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]) == 0;\n\tif (v99) goto L_00DC;\n\tv101 = fillableList == 0;\n\tif (v101) goto L_00E3;\nL_005A:\n\tv187 = v153 < 1;\n\tif (v187) goto L_00BE;\nL_0063:\n\tgoto L_0067;\n\tv352 = \"il2cpp_codegen_runtime_class_init\"(v296, v280, v277, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv353 = DG.Tweening.Core.TweenManager;\nL_0067:\n\tv350 = v354._activeTweens;\n\tv248 = v350[v283 @ X24_v7 (System.Int32)];\n\tv329 = v248.target == target;\n\tif (v329) goto L_0093;\nL_0085:\n\tv283 = v283 + 1;\n\tv253 = v153 != v283;\n\tif (v253) goto L_0063;\n\tgoto L_00BE;\nL_0093:\n\tv389 = playingOnly == 0;\n\tif (v389) goto L_009B;\n\tv383 = ~v248.isPlaying;\n\tif (v383) goto L_0085;\nL_009B:\n\tv349 = v149._items;\n\tv305 = v149._version + 1;\n\tv149._version = v305;\n\tv363 = v149._size;\n\tv392 = v149._size < v349.Length;\n\tv381 = ~v392;\n\tif (v381) goto L_00B7;\n\tv365 = v149._size + 1;\n\tv149._size = v365;\n\tv349[v363 @ X10_v8 (System.Int32)] = v350[v283 @ X24_v7 (System.Int32)];\n\tgoto L_0085;\nL_00B7:\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::AddWithResize(v149, v350[v283 @ X24_v7 (System.Int32)]);\n\tgoto L_0085;\nL_00BE:\n\tv141 = v149._size - 1;\n\tv139 = v141 < 0;\n\tv135 = v149._size ^ 1;\n\tv133 = v149._size ^ v141;\n\tv131 = v135 & v133;\n\tv129 = v131 < 0;\n\tv301 = v139 == v129;\n\tv127 = ~v301;\n\tv105 = ~v127;\n\tif (v105) goto L_FFFFFFFF;\n\tgoto L_00CD;\nL_00CD:\n\tgoto L_00D8;\nL_00D8:\n\treturn returnVal1;\nL_00DC:\n\tv153 = v173.totActiveTweens;\n\tv194 = fillableList == 0;\n\tv169 = ~v194;\n\tif (v169) goto L_005A;\nL_00E3:\n\tv167 = new System.Collections.Generic.List`1<DG.Tweening.Tween>();\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::.ctor(v167, v176);\n\tgoto L_005A;\n\tv351 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 154 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static List<Tween> GetTweensByTarget(object target, bool playingOnly, List<Tween> fillableList = null)
		{
			//IL_0338: Expected I, but got O
			//IL_001d: Expected I, but got O
			nint num = (nint)typeof(TweenManager);
			if (_requiresActiveReorganization)
			{
				ReorganizeActiveTweens();
				num = (nint)typeof(TweenManager);
			}
			int num2 = totActiveTweens;
			List<Tween> list;
			if (totActiveTweens >= 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X0_v5 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]");
				int num3;
				if ((nint)0 != 0)
				{
					bool flag = fillableList == null;
					list = fillableList;
					num3 = num2;
					if (!flag)
					{
						goto IL_0074;
					}
				}
				else
				{
					num2 = totActiveTweens;
					bool flag2 = fillableList == null;
					bool flag3 = !flag2;
					list = fillableList;
					num3 = totActiveTweens;
					if (flag3)
					{
						goto IL_0074;
					}
				}
				List<Tween> list2 = new List<Tween>(num3);
				list = list2;
				num2 = num3;
				goto IL_0074;
			}
			return null;
			IL_0074:
			if (num2 >= 1)
			{
				int num4 = 0;
				do
				{
					Tween[] activeTweens = _activeTweens;
					Tween tween = activeTweens[num4];
					if (tween.target == target && (!playingOnly || tween.isPlaying))
					{
						Tween[] items = list._items;
						int version = list._version + 1;
						list._version = version;
						int count = list.Count;
						if (list.Count < items.Length)
						{
							int size = list.Count + 1;
							list._size = size;
							items[count] = activeTweens[num4];
						}
						else
						{
							list.Add(activeTweens[num4]);
						}
					}
					num4++;
				}
				while (num2 != num4);
			}
			int num5 = list.Count - 1;
			bool flag4 = num5 < 0;
			int num6 = list.Count ^ 1;
			int num7 = list.Count ^ num5;
			int num8 = num6 & num7;
			bool flag5 = num8 < 0;
			if (flag4 != flag5)
			{
				return null;
			}
			return list;
		}

		[Token(Token = "0x6000450")]
		[Address(RVA = "0xC3038C", Offset = "0xC3038C", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, isSingleTweenManualUpdate, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv43 = DG.Tweening.Core.TweenManager;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, isSingleTweenManualUpdate, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A35808]) = v37;\nL_0018:\n\tv41 = isSingleTweenManualUpdate == 0;\n\tif (v41) goto L_0027;\n\tgoto L_0023;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v44, isSingleTweenManualUpdate, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv56 = DG.Tweening.Core.TweenManager;\nL_0023:\n\tv51 = ~v57.isUpdateLoop;\n\tif (v51) goto L_0061;\nL_0027:\n\tt.<active>k__BackingField = 0;\n\tgoto L_0030;\n\tv80 = \"il2cpp_codegen_runtime_class_init\"(v58, isSingleTweenManualUpdate, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv82 = DG.Tweening.Core.TweenManager;\nL_0030:\n\tv69 = v75._KillList;\n\tv74 = v69._items;\n\tv64 = v69._version + 1;\n\tv69._version = v64;\n\tv132 = v69._size;\n\tv149 = v69._size < v74.Length;\n\tv126 = ~v149;\n\tif (v126) goto L_005C;\n\tv134 = v69._size + 1;\n\tv69._size = v134;\n\tv74[v132 @ X10_v4 (System.Int32)] = t;\n\treturn;\nL_005C:\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::AddWithResize(v69, t);\n\treturn;\nL_0061:\n\tgoto L_006A;\n\tv83 = \"il2cpp_codegen_runtime_class_init\"(v49, isSingleTweenManualUpdate, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_006A:\n\tDG.Tweening.Core.TweenManager::Despawn(t, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void MarkForKilling(Tween t, bool isSingleTweenManualUpdate = false)
		{
			if (!isSingleTweenManualUpdate || isUpdateLoop)
			{
				t.active = false;
				List<Tween> killList = _KillList;
				Tween[] items = killList._items;
				int version = killList._version + 1;
				killList._version = version;
				int count = killList.Count;
				if (killList.Count < items.Length)
				{
					int size = killList.Count + 1;
					killList._size = size;
					items[count] = t;
				}
				else
				{
					killList.Add(t);
				}
			}
			else
			{
				Despawn(t);
			}
		}

		[Token(Token = "0x6000451")]
		[Address(RVA = "0xC309CC", Offset = "0xC309CC", Length = "0x240")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = UnityEngine.Object;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv54 = DG.Tweening.Core.TweenManager;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A35809]) = v38;\nL_001E:\n\tgoto L_002A;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv49 = DG.Tweening.Core.TweenManager;\nL_002A:\n\tv61 = System.Collections.Generic.Dictionary`2<DG.Tweening.Tween, DG.Tweening.Core.TweenLink>::TryGetValue(v50._TweenLinks, t, &v58 @ stack_-28_v3 (System.Object));\n\tv90 = v61 == 0;\n\tif (v90) goto L_0049;\n\tgoto L_003D;\n\tv179 = \"il2cpp_codegen_runtime_class_init\"(v176, v59, v57, v60, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_003D:\n\tv73 = UnityEngine.Object::op_Equality(*([v58 @ stack_-28_v3 (System.Object)+10]), 0);\n\tv183 = v73 == 0;\n\tif (v183) goto L_0051;\nL_0043:\n\tt.<active>k__BackingField = 0;\nL_0049:\n\treturn;\nL_0051:\n\tv75 = UnityEngine.GameObject::get_activeInHierarchy(*([v58 @ stack_-28_v3 (System.Object)+10]));\n\tv128 = *([v58 @ stack_-28_v3 (System.Object)+18]);\n\t*([v58 @ stack_-28_v3 (System.Object)+1C]) = v75;\n\tv193 = *([v58 @ stack_-28_v3 (System.Object)+18]) < 0xA;\n\tv120 = ~v193;\n\tv117 = *([v58 @ stack_-28_v3 (System.Object)+18]) - 0xA;\n\tv111 = v117 == 0;\n\tv194 = ~v111;\n\tv93 = v120 & v194;\n\tif (v93) goto L_0049;\n\tv159 = 0x424000 + 0x170;\n\tv142 = *([v159 @ X10_v4 (System.Int32)+v128 @ X9_v6]) << 2;\n\tv157 = 0xC34A9C + v142;\n\t// 121 IndirectJump v157 @ X12_v4 (System.Int32), v75 @ X0_v14 (System.Boolean), v75 @ X0_v14 (System.Boolean), 0, 0, methodof(System.Collections.Generic.Dictionary`2<DG.Tweening.Tween, DG.Tweening.Core.TweenLink>::TryGetValue), v23 @ X4, v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\n\tTEMP = X9 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0049;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X19+110]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00A3;\n\tgoto L_0049;\n\tTEMP = X9 & 1;\n\tif (TEMP) goto L_00A3;\n\tif (TEMP) goto L_0049;\n\tX0 = *([X21]);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0090;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0090:\n\tX0 = X19;\n\tX0 = DG.Tweening.Core.TweenManager::Play(X0, X1);\n\tgoto L_0049;\n\tTEMP = X9 & 1;\n\tif (TEMP) goto L_00A3;\n\tif (TEMP) goto L_0049;\n\tX0 = *([X21]);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_009E;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_009E:\n\tV0 = -1f;\n\tX1 = 1;\n\tX0 = X19;\n\tX0 = DG.Tweening.Core.TweenManager::Restart(X0, X1, V0, X2);\n\tgoto L_0049;\nL_00A3:\n\tX0 = *([X21]);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00A9;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00A9:\n\tX0 = X19;\n\tX0 = DG.Tweening.Core.TweenManager::Pause(X0, X1);\n\tgoto L_0049;\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0049;\n\tgoto L_00DE;\n\tTEMP = X9 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0049;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X19+111]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0049;\n\tX0 = X19;\n\tX1 = 0;\n\tDG.Tweening.TweenExtensions::Complete(X0, X1);\n\tgoto L_0049;\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0049;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X19+111]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0043;\n\tX0 = X19;\n\tX1 = 0;\n\tDG.Tweening.TweenExtensions::Complete(X0, X1);\n\tgoto L_0043;\n\tTEMP = X9 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0049;\n\tX0 = X19;\n\tX1 = 0;\n\tX2 = 0;\n\tDG.Tweening.TweenExtensions::Rewind(X0, X1, X2);\n\tgoto L_0049;\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0049;\n\tX0 = X19;\n\tX1 = 0;\n\tX2 = 0;\n\tDG.Tweening.TweenExtensions::Rewind(X0, X1, X2);\nL_00DE:\n\tTEMP = X19 == 0;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0043;\n\tthrow System.NullReferenceException;\n\treturn;\n// 105 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static void EvaluateTweenLink(Tween t)
		{
			//IL_004f: Expected O, but got I
			//IL_0094: Expected O, but got I
			//IL_00ad: Expected O, but got I
			//IL_00ea: Expected O, but got I
			object value;
			while (_TweenLinks.TryGetValue(t, out *(TweenLink*)(&value)))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ stack_-28_v3 (System.Object)+10]");
				if ((UnityEngine.Object)0 == null)
				{
					t.active = false;
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ stack_-28_v3 (System.Object)+10]");
				bool activeInHierarchy = ((GameObject)0).activeInHierarchy;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ stack_-28_v3 (System.Object)+18]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ stack_-28_v3 (System.Object)+18]");
				bool flag = (nint)0 < (nint)10;
				bool flag2 = !flag;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ stack_-28_v3 (System.Object)+18]");
				object obj2 = -10;
				bool flag3 = obj2 == null;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					int num = 4341760 + 368;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ X10_v4 (System.Int32)+v128 @ X9_v6]");
					int num2 = (int)((nint)0 << 2);
					int num3 = 12798620 + num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v157 @ X12_v4 (System.Int32) (should have been resolved before IL gen)");
					continue;
				}
				break;
			}
		}

		[Token(Token = "0x6000452")]
		[Address(RVA = "0xC2E6CC", Offset = "0xC2E6CC", Length = "0x2D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv20 = DG.Tweening.DOTween;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv46 = DG.Tweening.Core.TweenManager;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv55 = \"totActiveTweens < 0\";\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A3580A]) = v40;\nL_001E:\n\tgoto L_0023;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv50 = DG.Tweening.Core.TweenManager;\nL_0023:\n\tv53 = ~v51._requiresActiveReorganization;\n\tif (v53) goto L_002F;\n\tgoto L_002A;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v49, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_002A:\n\tDG.Tweening.Core.TweenManager::ReorganizeActiveTweens();\nL_002F:\n\tgoto L_0034;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v59, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv70 = DG.Tweening.Core.TweenManager;\nL_0034:\n\tv73 = v71.totActiveTweens & 0x80000000;\n\tv74 = v73 == 0;\n\tif (v74) goto L_004B;\n\tDG.Tweening.Core.Debugger::LogAddActiveTweenError(\"totActiveTweens < 0\", t);\n\tgoto L_0045;\n\tv113 = \"il2cpp_codegen_runtime_class_init\"(v89, v77, v78, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv114 = DG.Tweening.Core.TweenManager;\nL_0045:\n\tv87.totActiveTweens = 0;\nL_004B:\n\tt.<active>k__BackingField = 1;\n\tgoto L_0057;\n\tv115 = v95;\n\tv116 = \"il2cpp_codegen_runtime_class_init\"(v115, v81, v80, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv120 = DG.Tweening.DOTween;\n\tv118 = DG.Tweening.Core.TweenManager;\nL_0057:\n\tt.updateType = v121.defaultUpdateType;\n\tt.isIndependentUpdate = v121.defaultTimeScaleIndependent;\n\tgoto L_0061;\n\tv138 = \"il2cpp_codegen_runtime_class_init\"(v117, v81, v80, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv139 = DG.Tweening.Core.TweenManager;\nL_0061:\n\tv111 = v109.totActiveTweens;\n\tv109._maxActiveLookupId = v109.totActiveTweens;\n\tt.activeId = v109.totActiveTweens;\n\tv100 = v109._activeTweens;\n\t// 106 IsInst v131 @ X0_v17, typeof(DG.Tweening.Tween), t @ X0 (DG.Tweening.Tween)\n\tv133 = v131 == 0;\n\tif (v133) goto L_00F8;\n\tv100[v111 @ X21_v7 (System.Int32)] = t;\n\tv224 = t.updateType == 2;\n\tif (v224) goto L_FFFFFFFF;\n\tv233 = t.updateType == 1;\n\tif (v233) goto L_FFFFFFFF;\n\tv242 = t.updateType == 0;\n\tv243 = ~v242;\n\tif (v243) goto L_FFFFFFFF;\n\tgoto L_009D;\n\tv286 = \"il2cpp_codegen_runtime_class_init\"(v255, v129, v80, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv287 = DG.Tweening.Core.TweenManager;\nL_009D:\n\tv282.hasActiveDefaultTweens = 1;\n\tv275 = v282.totActiveDefaultTweens + 1;\n\tv282.totActiveDefaultTweens = v275;\n\tgoto L_00CD;\n\tgoto L_00AB;\n\tv263 = \"il2cpp_codegen_runtime_class_init\"(v244, v129, v80, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv265 = DG.Tweening.Core.TweenManager;\nL_00AB:\n\tv266.hasActiveLateTweens = 1;\n\tv269 = v266.totActiveLateTweens + 1;\n\tv266.totActiveLateTweens = v269;\n\tgoto L_00CD;\n\tgoto L_00B9;\n\tv248 = \"il2cpp_codegen_runtime_class_init\"(v238, v129, v80, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv250 = DG.Tweening.Core.TweenManager;\nL_00B9:\n\tv251.hasActiveFixedTweens = 1;\n\tv254 = v251.totActiveFixedTweens + 1;\n\tv251.totActiveFixedTweens = v254;\n\tgoto L_00CD;\n\tgoto L_00C7;\n\tv289 = \"il2cpp_codegen_runtime_class_init\"(v259, v129, v80, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv290 = DG.Tweening.Core.TweenManager;\nL_00C7:\n\tv281.hasActiveManualTweens = 1;\n\tv274 = v281.totActiveManualTweens + 1;\n\tv281.totActiveManualTweens = v274;\nL_00CD:\n\tgoto L_00D3;\n\tv292 = \"il2cpp_codegen_runtime_class_init\"(v276, v129, v80, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv296 = DG.Tweening.Core.TweenManager;\n\tv294 = *([v296 @ X0_v28+E0]);\nL_00D3:\n\tv182 = v297.totActiveTweens + 1;\n\tv297.totActiveTweens = v182;\n\tv300 = *([v276 @ X0_v18 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]) == 0;\n\tif (v300) goto L_00E1;\n\tv301 = t.tweenType == 0;\n\tif (v301) goto L_00E5;\nL_00DB:\n\tv310 = v307.totActiveSequences + 1;\n\tv307.totActiveSequences = v310;\n\tgoto L_00EA;\nL_00E1:\n\tv316 = t.tweenType == 0;\n\tv306 = ~v316;\n\tif (v306) goto L_00DB;\nL_00E5:\n\tv315 = v313.totActiveTweeners + 1;\n\tv313.totActiveTweeners = v315;\nL_00EA:\n\tgoto L_00F3;\n\tv323 = \"il2cpp_codegen_runtime_class_init\"(v318, v129, v80, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv325 = DG.Tweening.Core.TweenManager;\n\tv324 = *([v325 @ X8_v29+B8]);\nL_00F3:\n\tv213.hasActiveTweens = 1;\n\treturn;\n\tv112 = new System.NullReferenceException();\nL_00F8:\n\tv137 = new System.ArrayTypeMismatchException();\n\tthrow v137;\n\tthrow System.IndexOutOfRangeException;\n// 144 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void AddActiveTween(Tween t)
		{
			//IL_02d1: Expected I4, but got I8
			//IL_011a: Expected I, but got O
			//IL_0107: Expected I, but got O
			//IL_012d: Expected I, but got O
			//IL_00f4: Expected I, but got O
			if (_requiresActiveReorganization)
			{
				ReorganizeActiveTweens();
			}
			if ((int)(totActiveTweens & 0x80000000L) != 0)
			{
				Debugger.LogAddActiveTweenError("totActiveTweens < 0", t);
				totActiveTweens = 0;
			}
			t.active = true;
			t.updateType = DOTween.defaultUpdateType;
			t.isIndependentUpdate = DOTween.defaultTimeScaleIndependent;
			int num = totActiveTweens;
			_maxActiveLookupId = totActiveTweens;
			t.activeId = totActiveTweens;
			Tween[] activeTweens = _activeTweens;
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
							nint num2 = (nint)typeof(TweenManager);
							hasActiveDefaultTweens = true;
							int num3 = totActiveDefaultTweens + 1;
							totActiveDefaultTweens = num3;
						}
						else
						{
							nint num2 = (nint)typeof(TweenManager);
							hasActiveManualTweens = true;
							int num4 = totActiveManualTweens + 1;
							totActiveManualTweens = num4;
						}
					}
					else
					{
						nint num2 = (nint)typeof(TweenManager);
						hasActiveLateTweens = true;
						int num5 = totActiveLateTweens + 1;
						totActiveLateTweens = num5;
					}
				}
				else
				{
					nint num2 = (nint)typeof(TweenManager);
					hasActiveFixedTweens = true;
					int num6 = totActiveFixedTweens + 1;
					totActiveFixedTweens = num6;
				}
				int num7 = totActiveTweens + 1;
				totActiveTweens = num7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ X0_v18 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]");
				if ((nint)0 != 0)
				{
					if (t.tweenType != TweenType.Tweener)
					{
						goto IL_0154;
					}
				}
				else if (t.tweenType != TweenType.Tweener)
				{
					goto IL_0154;
				}
				int num8 = totActiveTweeners + 1;
				totActiveTweeners = num8;
				goto IL_0322;
			}
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
			IL_0322:
			hasActiveTweens = true;
			return;
			IL_0154:
			int num9 = totActiveSequences + 1;
			totActiveSequences = num9;
			goto IL_0322;
		}

		[Token(Token = "0x6000453")]
		[Address(RVA = "0xC30194", Offset = "0xC30194", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = DG.Tweening.Core.TweenManager;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A3580B]) = v46;\nL_0017:\n\tv47 = DG.Tweening.Core.TweenManager;\n\tv49 = *([v47 @ X0_v2 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]) == 0;\n\tif (v49) goto L_0034;\n\tv92 = *([v47 @ X0_v2 (Il2CppClass<DG.Tweening.Core.TweenManager>)+B8]);\n\tv63 = v92.totActiveTweens <= 0;\n\tif (v63) goto L_004C;\nL_002B:\n\tv173 = v92 + 0x74;\n\tv101 = *([v177 @ X0_v13 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]) == 0;\n\tif (v101) goto L_004F;\n\tgoto L_005D;\nL_0034:\n\tv118 = DG.Tweening.Core.TweenManager;\n\tv92 = *([v118 @ X0_v6 (Il2CppClass<DG.Tweening.Core.TweenManager>)+B8]);\n\tgoto L_0049;\n\tv195 = \"il2cpp_codegen_runtime_class_init\"(v118, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv196 = DG.Tweening.Core.TweenManager;\n\tv197 = *([v196 @ X0_v9+B8]);\nL_0049:\n\tv69 = v92.totActiveTweens > 0;\n\tif (v69) goto L_002B;\nL_004C:\n\tv115._maxActiveLookupId = 0xFFFFFFFF;\n\tgoto L_006A;\nL_004F:\n\tv202 = DG.Tweening.Core.TweenManager;\n\tv173 = *([v202 @ X0_v29 (Il2CppClass<DG.Tweening.Core.TweenManager>)+B8]) + 0x74;\n\tv144 = v203._maxActiveLookupId;\nL_005D:\n\tv146 = v92._reorganizeFromId != v92._maxActiveLookupId;\n\tif (v146) goto L_006F;\n\tv142 = v144 - 1;\n\t*([v173 @ X9_v9]) = v142;\nL_006A:\n\tv180._requiresActiveReorganization = 0;\n\tv180._reorganizeFromId = 0xFFFFFFFF;\n\treturn;\nL_006F:\n\tv138 = v181._reorganizeFromId;\n\tv136 = v144 + 1;\n\tv252 = v181._reorganizeFromId - 1;\n\t*([v173 @ X9_v9]) = v252;\nL_0077:\n\tgoto L_007B;\n\tv300 = \"il2cpp_codegen_runtime_class_init\"(v290, v127, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv301 = DG.Tweening.Core.TweenManager;\nL_007B:\n\tv124 = v138 + 1;\n\tv147 = v124 >= v136;\n\tif (v147) goto L_006A;\n\tv259 = v182._activeTweens;\n\tv297 = v259[v124 @ X23_v4 (System.Int32)];\n\tv294 = v259[v124 @ X23_v4 (System.Int32)] == 0;\n\tif (v294) goto L_00D4;\n\tv318 = v140 + v138;\n\tv367 = *([v177 @ X0_v13 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]) == 0;\n\tif (v367) goto L_00A5;\n\tv182._maxActiveLookupId = v318;\n\tv297.activeId = v318;\n\tgoto L_00AD;\nL_00A5:\n\tv258 = v355._activeTweens;\n\tv355._maxActiveLookupId = v318;\n\tv297.activeId = v318;\nL_00AD:\n\t// 173 IsInst v349 @ X0_v23, typeof(DG.Tweening.Tween), v259[v124 @ X23_v4 (System.Int32)]\n\tv361 = v349 == 0;\n\tif (v361) goto L_00D9;\n\tv258[v318 @ X24_v9 (System.Int32)] = v259[v124 @ X23_v4 (System.Int32)];\n\tv356 = v376._activeTweens;\n\tv356[v124 @ X23_v4 (System.Int32)] = 0;\n\tgoto L_0077;\nL_00D4:\n\tv138 = v138 + 1;\n\tv140 = v140 - 1;\n\tgoto L_0077;\n\tv347 = new System.IndexOutOfRangeException();\n\tv359 = new System.NullReferenceException();\nL_00D9:\n\tv366 = new System.ArrayTypeMismatchException();\n\tthrow v366;\n\treturn;\n// 148 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void ReorganizeActiveTweens()
		{
			//IL_02c8: Expected I, but got O
			//IL_008d: Expected I, but got O
			//IL_00a4: Expected I, but got O
			//IL_002f: Expected I, but got O
			//IL_004c: Expected O, but got I
			//IL_00c6: Expected I, but got O
			//IL_00d6: Expected O, but got I4
			//IL_00ed: Expected I, but got O
			//IL_013b: Expected O, but got I4
			//IL_0108: Expected O, but got I4
			//IL_0286: Expected I, but got O
			nint num = (nint)typeof(TweenManager);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X0_v2 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]");
			nint num2;
			if ((nint)0 != 0)
			{
				num2 = (isUnityEditor ? 1 : 0);
				bool flag = totActiveTweens <= 0;
				nint num3 = (nint)typeof(TweenManager);
				if (!flag)
				{
					goto IL_003d;
				}
			}
			else
			{
				nint num4 = (nint)typeof(TweenManager);
				num2 = (isUnityEditor ? 1 : 0);
				nint num3 = (nint)typeof(TweenManager);
				if (totActiveTweens > 0)
				{
					goto IL_003d;
				}
			}
			_maxActiveLookupId = -1;
			goto IL_032c;
			IL_032c:
			_requiresActiveReorganization = false;
			_reorganizeFromId = -1;
			return;
			IL_003d:
			object obj = num2 + 116;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ X0_v13 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]");
			int maxActiveLookupId;
			if ((nint)0 != 0)
			{
				maxActiveLookupId = _maxActiveLookupId;
			}
			else
			{
				nint num5 = (nint)typeof(TweenManager);
				obj = (isUnityEditor ? 1 : 0) + 116;
				maxActiveLookupId = _maxActiveLookupId;
				nint num3 = (nint)typeof(TweenManager);
			}
			if (_reorganizeFromId == _maxActiveLookupId)
			{
				int num6 = maxActiveLookupId - 1;
				obj = num6;
			}
			else
			{
				int num7 = _reorganizeFromId;
				int num8 = maxActiveLookupId + 1;
				int num9 = _reorganizeFromId - 1;
				obj = num9;
				int num10 = 0;
				while (true)
				{
					int num11 = num7 + 1;
					if (num11 >= num8)
					{
						break;
					}
					Tween[] activeTweens = _activeTweens;
					Tween tween = activeTweens[num11];
					if (activeTweens[num11] != null)
					{
						int num12 = num10 + num7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ X0_v13 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]");
						Tween[] array;
						if ((nint)0 != 0)
						{
							_maxActiveLookupId = num12;
							tween.activeId = num12;
							array = activeTweens;
						}
						else
						{
							array = _activeTweens;
							_maxActiveLookupId = num12;
							tween.activeId = num12;
						}
						object obj2 = activeTweens[num11] as Tween;
						if (obj2 == null)
						{
							ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
							throw ex;
						}
						array[num12] = activeTweens[num11];
						Tween[] activeTweens2 = _activeTweens;
						activeTweens2[num11] = null;
						num7 = num11;
						nint num3 = (nint)typeof(TweenManager);
					}
					else
					{
						num7++;
						num10--;
					}
				}
			}
			goto IL_032c;
		}

		[Token(Token = "0x6000454")]
		[Address(RVA = "0xC304A8", Offset = "0xC304A8", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv20 = Il2CppMethodInfo;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv43 = Il2CppMethodInfo;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv58 = DG.Tweening.Core.TweenManager;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A3580C]) = v40;\nL_001F:\n\tv49 = tweens._size < 1;\n\tv123 = tweens._size - 1;\n\tif (v49) goto L_004D;\nL_002E:\n\tv126 = System.Collections.Generic.List`1<DG.Tweening.Tween>::get_Item(tweens, v123);\n\tgoto L_0039;\n\tv157 = v98;\n\tv158 = \"il2cpp_codegen_runtime_class_init\"(v157, v125, v64, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0039:\n\tDG.Tweening.Core.TweenManager::Despawn(v126, 1);\n\tv100 = v123 - 1;\n\tv66 = v123 >= 1;\n\tif (v66) goto L_002E;\nL_004D:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void DespawnActiveTweens(List<Tween> tweens)
		{
			bool flag = tweens.Count < 1;
			int num = tweens.Count - 1;
			if (!flag)
			{
				bool flag2;
				do
				{
					Tween t = tweens[num];
					Despawn(t);
					int num2 = num - 1;
					flag2 = num >= 1;
					num = num2;
				}
				while (flag2);
			}
		}

		[Token(Token = "0x6000455")]
		[Address(RVA = "0xC2EE58", Offset = "0xC2EE58", Length = "0x480")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv16 = DG.Tweening.Core.TweenManager;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv39 = \"totActiveTweens < 0\";\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v39, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv91 = \"totActiveDefaultTweens < 0\";\n\tv92 = \"il2cpp_codegen_initialize_runtime_metadata\"(v91, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv136 = \"totActiveTweeners < 0\";\n\tv137 = \"il2cpp_codegen_initialize_runtime_metadata\"(v136, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv150 = \"totActiveFixedTweens < 0\";\n\tv151 = \"il2cpp_codegen_initialize_runtime_metadata\"(v150, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv222 = \"totActiveLateTweens < 0\";\n\tv223 = \"il2cpp_codegen_initialize_runtime_metadata\"(v222, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv255 = \"totActiveManualTweens < 0\";\n\tv256 = \"il2cpp_codegen_initialize_runtime_metadata\"(v255, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv268 = \"totActiveSequences < 0\";\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v268, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 1;\n\t*([1A3580D]) = v36;\nL_002A:\n\tv43 = t.activeId;\n\tgoto L_003E;\n\tv93 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv95 = DG.Tweening.Core.TweenManager;\nL_003E:\n\tv108 = v96._totTweenLinks < 1;\n\tif (v108) goto L_0049;\n\tgoto L_0046;\n\tv152 = \"il2cpp_codegen_runtime_class_init\"(v94, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0046:\n\tDG.Tweening.Core.TweenManager::RemoveTweenLink(t);\nL_0049:\n\tt.activeId = 0xFFFFFFFF;\n\tgoto L_0053;\n\tv155 = \"il2cpp_codegen_runtime_class_init\"(v141, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv157 = DG.Tweening.Core.TweenManager;\nL_0053:\n\tv158._requiresActiveReorganization = 1;\n\tv160 = v158._reorganizeFromId + 1;\n\tv162 = v160 == 0;\n\tif (v162) goto L_0072;\n\tgoto L_006D;\n\tv257 = \"il2cpp_codegen_runtime_class_init\"(v156, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv258 = DG.Tweening.Core.TweenManager;\n\tv269 = *([v258 @ X0_v78+B8]);\n\tv259 = *([v269 @ X8_v80+7C]);\nL_006D:\n\tv228 = v158._reorganizeFromId <= t.activeId;\n\tif (v228) goto L_007A;\nL_0072:\n\tgoto L_0076;\n\tv263 = \"il2cpp_codegen_runtime_class_init\"(v246, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv265 = DG.Tweening.Core.TweenManager;\nL_0076:\n\tv266._reorganizeFromId = t.activeId;\nL_007A:\n\tgoto L_007E;\n\tv276 = \"il2cpp_codegen_runtime_class_init\"(v270, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv277 = DG.Tweening.Core.TweenManager;\nL_007E:\n\tv87 = v278._activeTweens;\n\tv87[v43 @ X21_v3 (System.Int32)] = 0;\n\tv287 = t.updateType == 2;\n\tif (v287) goto L_00DA;\n\tv296 = t.updateType == 1;\n\tif (v296) goto L_0108;\n\tv305 = t.updateType == 0;\n\tv306 = ~v305;\n\tif (v306) goto L_0136;\n\tgoto L_00BB;\n\tv356 = \"il2cpp_codegen_runtime_class_init\"(v327, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv358 = DG.Tweening.Core.TweenManager;\nL_00BB:\n\tv371 = v359.totActiveDefaultTweens < 1;\n\tif (v371) goto L_FFFFFFFF;\n\tgoto L_00C5;\n\tv507 = \"il2cpp_codegen_runtime_class_init\"(v357, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv534 = DG.Tweening.Core.TweenManager;\n\tv510 = *([v534 @ X8_v74+B8]);\n\tv509 = *([v510 @ X8_v75+1C]);\nL_00C5:\n\tv511 = v359.totActiveDefaultTweens - 1;\n\tv485 = v511 < 0;\n\tv482 = v511 == 0;\n\tv476 = v511 ^ v511;\n\tv473 = v511 & v476;\n\tv470 = v473 < 0;\n\tv501.totActiveDefaultTweens = v511;\n\tv513 = v485 == v470;\n\tv463 = ~v482;\n\tv466 = v513 & v463;\n\tv501.hasActiveDefaultTweens = v466;\n\tgoto L_016F;\nL_00DA:\n\tgoto L_00E9;\n\tv311 = \"il2cpp_codegen_runtime_class_init\"(v301, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv313 = DG.Tweening.Core.TweenManager;\nL_00E9:\n\tv326 = v314.totActiveFixedTweens < 1;\n\tif (v326) goto L_FFFFFFFF;\n\tgoto L_00F3;\n\tv393 = \"il2cpp_codegen_runtime_class_init\"(v312, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv459 = DG.Tweening.Core.TweenManager;\n\tv398 = *([v459 @ X8_v53+B8]);\n\tv395 = *([v398 @ X8_v54+24]);\nL_00F3:\n\tv399 = v314.totActiveFixedTweens - 1;\n\tv403 = v399 < 0;\n\tv404 = v399 == 0;\n\tv406 = v399 ^ v399;\n\tv407 = v399 & v406;\n\tv408 = v407 < 0;\n\tv397.totActiveFixedTweens = v399;\n\tv409 = v403 == v408;\n\tv410 = ~v404;\n\tv411 = v409 & v410;\n\tv397.hasActiveFixedTweens = v411;\n\tgoto L_016F;\nL_0108:\n\tgoto L_0117;\n\tv335 = \"il2cpp_codegen_runtime_class_init\"(v307, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv337 = DG.Tweening.Core.TweenManager;\nL_0117:\n\tv350 = v338.totActiveLateTweens < 1;\n\tif (v350) goto L_FFFFFFFF;\n\tgoto L_0121;\n\tv439 = \"il2cpp_codegen_runtime_class_init\"(v336, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv521 = DG.Tweening.Core.TweenManager;\n\tv444 = *([v521 @ X8_v60+B8]);\n\tv441 = *([v444 @ X8_v61+20]);\nL_0121:\n\tv445 = v338.totActiveLateTweens - 1;\n\tv449 = v445 < 0;\n\tv450 = v445 == 0;\n\tv452 = v445 ^ v445;\n\tv453 = v445 & v452;\n\tv454 = v453 < 0;\n\tv443.totActiveLateTweens = v445;\n\tv455 = v449 == v454;\n\tv456 = ~v450;\n\tv457 = v455 & v456;\n\tv443.hasActiveLateTweens = v457;\n\tgoto L_016F;\nL_0136:\n\tgoto L_0145;\n\tv372 = \"il2cpp_codegen_runtime_class_init\"(v331, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv374 = DG.Tweening.Core.TweenManager;\nL_0145:\n\tv387 = v375.totActiveManualTweens < 1;\n\tif (v387) goto L_FFFFFFFF;\n\tgoto L_014F;\n\tv514 = \"il2cpp_codegen_runtime_class_init\"(v373, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv535 = DG.Tweening.Core.TweenManager;\n\tv517 = *([v535 @ X8_v67+B8]);\n\tv516 = *([v517 @ X8_v68+28]);\nL_014F:\n\tv518 = v375.totActiveManualTweens - 1;\n\tv486 = v518 < 0;\n\tv483 = v518 == 0;\n\tv477 = v518 ^ v518;\n\tv474 = v518 & v477;\n\tv471 = v474 < 0;\n\tv502.totActiveManualTweens = v518;\n\tv520 = v486 == v471;\n\tv464 = ~v483;\n\tv467 = v520 & v464;\n\tv502.hasActiveManualTweens = v467;\n\tgoto L_016F;\n\tgoto L_016E;\n\tgoto L_016E;\n\tgoto L_016E;\nL_016E:\n\tDG.Tweening.Core.Debugger::LogRemoveActiveTweenError(*([v425 @ X8_v18 (System.String)]), t);\nL_016F:\n\tv503 = DG.Tweening.Core.TweenManager;\n\tgoto L_0179;\n\tv522 = \"il2cpp_codegen_runtime_class_init\"(v503, v461, v460, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv526 = DG.Tweening.Core.TweenManager;\n\tv524 = *([v526 @ X0_v45+E0]);\nL_0179:\n\tv529 = v527.totActiveTweens - 1;\n\tv195 = v529 < 0;\n\tv193 = v529 == 0;\n\tv189 = v529 ^ v529;\n\tv187 = v529 & v189;\n\tv185 = v187 < 0;\n\tv527.totActiveTweens = v529;\n\tv531 = v195 == v185;\n\tv172 = ~v193;\n\tv175 = v531 & v172;\n\tv527.hasActiveTweens = v175;\n\tv533 = *([v503 @ X0_v15 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]) == 0;\n\tif (v533) goto L_0195;\n\tv536 = t.tweenType == 0;\n\tif (v536) goto L_0199;\nL_018F:\n\tv545 = v542.totActiveSequences - 1;\n\tv542.totActiveSequences = v545;\n\tgoto L_019E;\nL_0195:\n\tv551 = t.tweenType == 0;\n\tv541 = ~v551;\n\tif (v541) goto L_018F;\nL_0199:\n\tv550 = v548.totActiveTweeners - 1;\n\tv548.totActiveTweeners = v550;\nL_019E:\n\tgoto L_01A3;\n\tv559 = \"il2cpp_codegen_runtime_class_init\"(v553, v461, v460, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv561 = DG.Tweening.Core.TweenManager;\n\tv563 = *([v561 @ X0_v39+B8]);\nL_01A3:\n\tv565 = v562.totActiveTweens & 0x80000000;\n\tv566 = v565 == 0;\n\tif (v566) goto L_01B8;\n\tgoto L_01AD;\n\tv583 = \"il2cpp_codegen_runtime_class_init\"(v560, v461, v460, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv596 = DG.Tweening.Core.TweenManager;\n\tv586 = *([v596 @ X8_v42+B8]);\nL_01AD:\n\tv585.totActiveTweens = 0;\n\n// ... truncated")]
		private static void RemoveActiveTween(Tween t)
		{
			//IL_0121: Expected I, but got O
			//IL_0661: Expected I4, but got I8
			//IL_0691: Expected I4, but got I8
			//IL_06c1: Expected I4, but got I8
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
			activeTweens[activeId] = null;
			string errorInfo;
			if (t.updateType != UpdateType.Fixed)
			{
				if (t.updateType != UpdateType.Late)
				{
					if (t.updateType != UpdateType.Normal)
					{
						if (totActiveManualTweens >= 1)
						{
							int num = totActiveManualTweens - 1;
							bool flag = num < 0;
							bool flag2 = num == 0;
							int num2 = num ^ num;
							int num3 = num & num2;
							bool flag3 = num3 < 0;
							totActiveManualTweens = num;
							bool flag4 = flag == flag3;
							bool flag5 = !flag2;
							bool flag6 = flag4 && flag5;
							hasActiveManualTweens = flag6;
							goto IL_0113;
						}
						errorInfo = "totActiveManualTweens < 0";
					}
					else
					{
						if (totActiveDefaultTweens >= 1)
						{
							int num4 = totActiveDefaultTweens - 1;
							bool flag7 = num4 < 0;
							bool flag8 = num4 == 0;
							int num5 = num4 ^ num4;
							int num6 = num4 & num5;
							bool flag9 = num6 < 0;
							totActiveDefaultTweens = num4;
							bool flag10 = flag7 == flag9;
							bool flag11 = !flag8;
							bool flag12 = flag10 && flag11;
							hasActiveDefaultTweens = flag12;
							goto IL_0113;
						}
						errorInfo = "totActiveDefaultTweens < 0";
					}
				}
				else
				{
					if (totActiveLateTweens >= 1)
					{
						int num7 = totActiveLateTweens - 1;
						bool flag13 = num7 < 0;
						bool flag14 = num7 == 0;
						int num8 = num7 ^ num7;
						int num9 = num7 & num8;
						bool flag15 = num9 < 0;
						totActiveLateTweens = num7;
						bool flag16 = flag13 == flag15;
						bool flag17 = !flag14;
						bool flag18 = flag16 && flag17;
						hasActiveLateTweens = flag18;
						goto IL_0113;
					}
					errorInfo = "totActiveLateTweens < 0";
				}
			}
			else
			{
				if (totActiveFixedTweens >= 1)
				{
					int num10 = totActiveFixedTweens - 1;
					bool flag19 = num10 < 0;
					bool flag20 = num10 == 0;
					int num11 = num10 ^ num10;
					int num12 = num10 & num11;
					bool flag21 = num12 < 0;
					totActiveFixedTweens = num10;
					bool flag22 = flag19 == flag21;
					bool flag23 = !flag20;
					bool flag24 = flag22 && flag23;
					hasActiveFixedTweens = flag24;
					goto IL_0113;
				}
				errorInfo = "totActiveFixedTweens < 0";
			}
			Debugger.LogRemoveActiveTweenError(errorInfo, t);
			goto IL_0113;
			IL_0113:
			nint num13 = (nint)typeof(TweenManager);
			int num14 = totActiveTweens - 1;
			bool flag25 = num14 < 0;
			bool flag26 = num14 == 0;
			int num15 = num14 ^ num14;
			int num16 = num14 & num15;
			bool flag27 = num16 < 0;
			totActiveTweens = num14;
			bool flag28 = flag25 == flag27;
			bool flag29 = !flag26;
			bool flag30 = flag28 && flag29;
			hasActiveTweens = flag30;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ X0_v15 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]");
			if ((nint)0 != 0)
			{
				if (t.tweenType != TweenType.Tweener)
				{
					goto IL_0148;
				}
			}
			else if (t.tweenType != TweenType.Tweener)
			{
				goto IL_0148;
			}
			int num17 = totActiveTweeners - 1;
			totActiveTweeners = num17;
			goto IL_064e;
			IL_0148:
			int num18 = totActiveSequences - 1;
			totActiveSequences = num18;
			goto IL_064e;
			IL_064e:
			if ((int)(totActiveTweens & 0x80000000L) != 0)
			{
				totActiveTweens = 0;
				Debugger.LogRemoveActiveTweenError("totActiveTweens < 0", t);
			}
			if ((int)(totActiveTweeners & 0x80000000L) != 0)
			{
				totActiveTweeners = 0;
				Debugger.LogRemoveActiveTweenError("totActiveTweeners < 0", t);
			}
			if ((int)(totActiveSequences & 0x80000000L) != 0)
			{
				totActiveSequences = 0;
				Debugger.LogRemoveActiveTweenError("totActiveSequences < 0", t);
			}
		}

		[Token(Token = "0x6000456")]
		[Address(RVA = "0xC2F938", Offset = "0xC2F938", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = tweens.Length < 1;\n\tif (v15) goto L_0037;\n\tv33 = tweens.Length & 0xFFFFFFFF;\n\tv35 = v33 + 1;\n\tv85 = v35 & 0x1FFFFFFFE;\n\t// 24 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv75 = tweens + 0x28;\n\t// 26 NotImplemented \"Instruction DUP not yet implemented.\"\nL_001B:\n\t// 27 NotImplemented \"Instruction CMHS not yet implemented.\"\n\t// 28 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv88 = v27 & 1;\n\tv89 = v88 == 0;\n\tif (v89) goto L_0023;\n\t*([v75 @ X9_v4-8]) = 0;\nL_0023:\n\tv118 = v117 & 1;\n\tv71 = v118 == 0;\n\tif (v71) goto L_0031;\n\t*([v75 @ X9_v4]) = 0;\nL_0031:\n\tv69 = v85 - 2;\n\tv75 = v75 + 0x10;\n\tv51 = v85 != 2;\n\tif (v51) goto L_001B;\nL_0037:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void ClearTweenArray(Tween[] tweens)
		{
			//IL_0033: Expected I4, but got I8
			//IL_0053: Expected I4, but got I8
			//IL_006c: Expected O, but got I
			//IL_011e: Expected O, but got I
			//IL_008f: Expected O, but got I4
			if (tweens.Length < 1)
			{
				return;
			}
			int num = (int)(tweens.Length & 0xFFFFFFFFL);
			int num2 = num + 1;
			int num3 = (int)(num2 & 0x1FFFFFFFEL);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
			object obj = (nint)tweens + 40;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
			object obj2 = default(object);
			object obj3 = default(object);
			bool flag;
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction CMHS not yet implemented.\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				if ((int)((nint)obj2 & 1) != 0)
				{
					_ = 0;
				}
				if ((int)((nint)obj3 & 1) != 0)
				{
					obj = 0;
				}
				int num4 = num3 - 2;
				obj = (nint)obj + 16;
				flag = num3 != 2;
				num3 = num4;
			}
			while (flag);
		}

		[Token(Token = "0x6000457")]
		[Address(RVA = "0xC2E9A4", Offset = "0xC2E9A4", Length = "0x21C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv48 = Il2CppMethodInfo;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv77 = Il2CppMethodInfo;\n\tv78 = \"il2cpp_codegen_initialize_runtime_metadata\"(v77, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv82 = DG.Tweening.Core.TweenManager;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v82, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A3580E]) = v42;\n\tgoto L_0025;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv52 = DG.Tweening.Core.TweenManager;\nL_0025:\n\t;\n\tv165 = *([v51 @ X0_v3 (Il2CppClass<DG.Tweening.Core.TweenManager>)+B8]) + 0xC;\n\tv63 = v189.maxTweeners * 1.5f;\n\tv75 = v63 != 0x7F800000;\n\tif (v75) goto L_FFFFFFFF;\n\tgoto L_0042;\nL_0042:\n\tv85 = v189.maxSequences * 1.5f;\n\tv88 = v83 - 0xC8;\n\tv89 = v88 < 0;\n\tv90 = v88 == 0;\n\tv91 = v83 ^ 0xC8;\n\tv92 = v83 ^ v88;\n\tv93 = v91 & v92;\n\tv94 = v93 < 0;\n\tv96 = v89 == v94;\n\tv97 = ~v90;\n\tv98 = v96 & v97;\n\tv99 = ~v98;\n\tif (v99) goto L_FFFFFFFF;\n\tgoto L_0061;\nL_0061:\n\tv114 = v85 != 0x7F800000;\n\tif (v114) goto L_FFFFFFFF;\n\tgoto L_006A;\nL_006A:\n\tv121 = v117 - 0x32;\n\tv122 = v121 < 0;\n\tv123 = v121 == 0;\n\tv124 = v117 ^ 0x32;\n\tv125 = v117 ^ v121;\n\tv126 = v124 & v125;\n\tv127 = v126 < 0;\n\tv128 = v122 == v127;\n\tv129 = ~v123;\n\tv130 = v128 & v129;\n\tv131 = ~v130;\n\tif (v131) goto L_FFFFFFFF;\n\tgoto L_007E;\nL_007E:\n\tv139 = increaseMode == 2;\n\tif (v139) goto L_00A0;\n\tv153 = increaseMode != 1;\n\tif (v153) goto L_00AB;\n\tgoto L_0097;\n\tv174 = \"il2cpp_codegen_runtime_class_init\"(v51, methodInfo, v25, v26, v27, v28, v29, v30, v85, v55, v74, v34, v35, v36, v37, v38);\n\tv220 = DG.Tweening.Core.TweenManager;\n\tv179 = *([v220 @ X8_v21+B8]);\n\tv176 = *([v179 @ X8_v22+8]);\nL_0097:\n\tv180 = v189.maxTweeners + v214;\n\tv189.maxTweeners = v180;\n\tv182 = *([v51 @ X0_v3 (Il2CppClass<DG.Tweening.Core.TweenManager>)+B8]) + 0x50;\n\tSystem.Array::Resize(v182, v180);\n\tgoto L_FFFFFFFF;\nL_00A0:\n\tgoto L_00A6;\n\tv164 = \"il2cpp_codegen_runtime_class_init\"(v51, methodInfo, v25, v26, v27, v28, v29, v30, v85, v55, v74, v34, v35, v36, v37, v38);\n\tv171 = DG.Tweening.Core.TweenManager;\n\tv195 = *([v171 @ X8_v16+B8]);\n\tv166 = v195 + 0xC;\n\tv168 = *([v166 @ X11_v6]);\nL_00A6:\n\tv172 = v189.maxSequences + v134;\n\t*([v165 @ X11_v4]) = v172;\n\tgoto L_FFFFFFFF;\nL_00AB:\n\tv161 = v134 + v214;\n\tgoto L_00B4;\n\tv183 = \"il2cpp_codegen_runtime_class_init\"(v51, methodInfo, v25, v26, v27, v28, v29, v30, v85, v55, v74, v34, v35, v36, v37, v38);\n\tv221 = DG.Tweening.Core.TweenManager;\n\tv190 = *([v221 @ X8_v18+B8]);\n\tv185 = *([v190 @ X8_v19+8]);\n\tv187 = *([v190 @ X8_v19+C]);\nL_00B4:\n\tv191 = v189.maxTweeners + v214;\n\tv192 = v189.maxSequences + v134;\n\tv189.maxTweeners = v191;\n\tv189.maxSequences = v192;\n\tv194 = *([v51 @ X0_v3 (Il2CppClass<DG.Tweening.Core.TweenManager>)+B8]) + 0x50;\n\tSystem.Array::Resize(v194, v191);\n\tgoto L_00C3;\n\tv222 = \"il2cpp_codegen_runtime_class_init\"(v216, v197, v196, v26, v27, v28, v29, v30, v85, v55, v74, v34, v35, v36, v37, v38);\n\tv224 = DG.Tweening.Core.TweenManager;\nL_00C3:\n\t;\n\tv228 = *([v223 @ X0_v6 (Il2CppClass<DG.Tweening.Core.TweenManager>)+B8]) + 0x48;\n\tv229 = v225.maxSequences + v225.maxTweeners;\n\tv225.maxActive = v229;\n\tSystem.Array::Resize(v228, v229);\n\tv241 = v214 < 1;\n\tif (v241) goto L_00FC;\n\tgoto L_00E8;\n\tv252 = \"il2cpp_codegen_runtime_class_init\"(v242, v229, v230, v26, v27, v28, v29, v30, v85, v55, v74, v34, v35, v36, v37, v38);\n\tv254 = DG.Tweening.Core.TweenManager;\nL_00E8:\n\tv285 = System.Collections.Generic.List`1<DG.Tweening.Tween>::get_Capacity(v255._KillList);\n\tv265 = v285 + v214;\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::set_Capacity(v255._KillList, v265);\n\treturn;\nL_00FC:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 149 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static void IncreaseCapacities(CapacityIncreaseMode increaseMode)
		{
			//IL_00f2: Expected I, but got O
			//IL_0374: Expected O, but got I4
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_0148: Expected O, but got Unknown
			//IL_0155: Expected O, but got F4
			//IL_020f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0214: Expected O, but got Unknown
			//IL_0221: Expected O, but got F4
			//IL_02fe: Expected O, but got F4
			//IL_02e1: Expected I, but got O
			//IL_0314: Unknown result type (might be due to invalid IL or missing references)
			//IL_0319: Expected I4, but got Unknown
			//IL_033b: Expected I4, but got F4
			//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a9: Expected I4, but got Unknown
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Expected I4, but got Unknown
			nint num = (nint)typeof(TweenManager);
			object obj = (isUnityEditor ? 1 : 0) + 12;
			float num2 = (float)maxTweeners * 1.5f;
			float num3 = ((num2 != float.PositiveInfinity) ? num2 : -0f);
			float num4 = (float)maxSequences * 1.5f;
			float num5 = num3 - 2.8E-43f;
			bool flag = num5 < 0f;
			bool flag2 = num5 == 0f;
			object obj2 = num3 ^ 0xC8;
			object obj3 = num3 ^ num5;
			int num6 = (int)((nint)obj2 & (nint)obj3);
			bool flag3 = num6 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			float num7 = ((!(flag4 && flag5)) ? 2.8E-43f : num3);
			float num8 = ((num4 != float.PositiveInfinity) ? num4 : -0f);
			float num9 = num8 - 7E-44f;
			bool flag6 = num9 < 0f;
			bool flag7 = num9 == 0f;
			object obj4 = num8 ^ 0x32;
			object obj5 = num8 ^ num9;
			int num10 = (int)((nint)obj4 & (nint)obj5);
			bool flag8 = num10 < 0;
			bool flag9 = flag6 == flag8;
			bool flag10 = !flag7;
			float num11 = ((!(flag9 && flag10)) ? 7E-44f : num8);
			if (increaseMode != CapacityIncreaseMode.SequencesOnly)
			{
				if (increaseMode != CapacityIncreaseMode.TweenersOnly)
				{
					float num12 = num11 + num7;
					int newSize = (int)(maxTweeners + num7);
					float num13 = (float)maxSequences + num11;
					maxTweeners = newSize;
					maxSequences = (int)num13;
					Array.Resize(ref *(object[]*)((isUnityEditor ? 1 : 0) + 80), newSize);
					num7 = num12;
				}
				else
				{
					Array.Resize(newSize: maxTweeners = (int)(maxTweeners + num7), array: ref *(object[]*)((isUnityEditor ? 1 : 0) + 80));
				}
			}
			else
			{
				float num14 = (float)maxSequences + num11;
				obj = num14;
				num7 = num11;
			}
			nint num15 = (nint)typeof(TweenManager);
			Array.Resize(ref *(object[]*)((isUnityEditor ? 1 : 0) + 72), maxActive = maxSequences + maxTweeners);
			if (!(num7 < float.Epsilon))
			{
				int capacity = _KillList.Capacity;
				int capacity2 = (int)(capacity + num7);
				_KillList.Capacity = capacity2;
			}
		}

		[Token(Token = "0x6000458")]
		[Address(RVA = "0xC31CC4", Offset = "0xC31CC4", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = DG.Tweening.DOTween;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, isPlayBackwardsOrSmoothRewind, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A3580F]) = v36;\nL_0015:\n\tv39 = t.onRewind == 0;\n\tif (v39) goto L_0034;\n\tgoto L_0023;\n\tv105 = \"il2cpp_codegen_runtime_class_init\"(v74, isPlayBackwardsOrSmoothRewind, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv106 = DG.Tweening.DOTween;\nL_0023:\n\tv96 = isPlayBackwardsOrSmoothRewind == 0;\n\tif (v96) goto L_0035;\n\tv87 = v107.rewindCallbackMode == 2;\n\tif (v87) goto L_0037;\nL_0034:\n\treturn;\nL_0035:\n\tv97 = v107.rewindCallbackMode == 0;\n\tif (v97) goto L_0034;\nL_0037:\n\t;\n\tDG.Tweening.TweenCallback::Invoke(t.onRewind);\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
