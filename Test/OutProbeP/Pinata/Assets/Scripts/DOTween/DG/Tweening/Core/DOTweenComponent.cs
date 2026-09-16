using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening.Core
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x72F5D4", Offset = "0x72F5D4")]
	[Token(Token = "0x200004C")]
	public class DOTweenComponent : MonoBehaviour, IDOTweenInit
	{
		[Token(Token = "0x4000137")]
		[FieldOffset(Offset = "0x18")]
		public int inspectorUpdater;

		[Token(Token = "0x4000138")]
		[FieldOffset(Offset = "0x1C")]
		private float _unscaledTime;

		[Token(Token = "0x4000139")]
		[FieldOffset(Offset = "0x20")]
		private float _unscaledDeltaTime;

		[Token(Token = "0x400013A")]
		[FieldOffset(Offset = "0x24")]
		private float _pausedTime;

		[Token(Token = "0x400013B")]
		[FieldOffset(Offset = "0x28")]
		private bool _duplicateToDestroy;

		[Token(Token = "0x6000287")]
		[Address(RVA = "0x106F308", Offset = "0x106F308", Length = "0x1F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EC9650]);\n\tv23 = *([v22 @ X8_v38]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2026979]) = v42;\nL_001B:\n\tgoto L_002A;\n\tv49 = *([v45 @ X0_v2 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_002A;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv53 = DG.Tweening.DOTween;\nL_002A:\n\tgoto L_0034;\n\tv65 = *([v59 @ X8_v5+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tgoto L_0034;\n\tv76 = v59;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v76, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0034:\n\tv75 = UnityEngine.Object::op_Equality(v58.instance, 0);\n\tv78 = v75 == 0;\n\tif (v78) goto L_0073;\n\tgoto L_0045;\n\tv87 = *([v79 @ X0_v18 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv88 = v87 == 0;\n\tv89 = ~v88;\n\tif (v89) goto L_0045;\n\tv120 = \"il2cpp_codegen_runtime_class_init\"(v79, v73, v74, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv91 = DG.Tweening.DOTween;\nL_0045:\n\tv94.instance = this;\n\tthis.inspectorUpdater = 0;\n\tv96 = UnityEngine.Time::get_realtimeSinceStartup();\n\tthis._unscaledTime = v96;\n\tgoto L_0058;\n\tv135 = *([v123 @ X0_v21+E0]);\n\tv136 = v135 == 0;\n\tv137 = ~v136;\n\tgoto L_0058;\n\tv139 = \"il2cpp_codegen_runtime_class_init\"(v123, v73, v74, v27, v28, v29, v30, v31, v96, v33, v34, v35, v36, v37, v38, v39);\nL_0058:\n\tv145 = DG.Tweening.Core.Utils::GetLooseScriptType(\"DG.Tweening.DOTweenModuleUtils\");\n\tv151 = v145 == 0;\n\tif (v151) goto L_00B3;\n\tv172 = System.Type::GetMethod(v145, \"Init\", 0x18);\n\tv217 = System.Reflection.MethodBase::Invoke(v172, 0, 0);\n\treturn;\nL_0073:\n\tgoto L_0089;\n\tv98 = *([1EC27E8]);\n\tv99 = *([v98 @ X8_v18]);\n\tv100 = \"il2cpp_codegen_initialize_method\"(v99, v73, v74, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv103 = 0 | 1;\n\t*([2022B9B]) = v103;\nL_0089:\n\tv119 = v107._logPriority < 1;\n\tif (v119) goto L_0091;\n\tDG.Tweening.Core.Debugger::LogWarning(\"Duplicate DOTweenComponent instance found in scene: destroying it\");\nL_0091:\n\tv134 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_00A7;\n\tv152 = *([v146 @ X8_v14+E0]);\n\tv153 = v152 == 0;\n\tv154 = ~v153;\n\tif (v154) goto L_00A7;\n\tv182 = v146;\n\tv157 = \"il2cpp_codegen_runtime_class_init\"(v182, v133, v74, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00A7:\n\tUnityEngine.Object::Destroy(v134);\n\treturn;\nL_00B3:\n\tDG.Tweening.Core.Debugger::LogError(\"Couldn't load Modules system\");\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			if (DOTween.instance == null)
			{
				DOTween.instance = this;
				inspectorUpdater = 0;
				float realtimeSinceStartup = Time.realtimeSinceStartup;
				_unscaledTime = realtimeSinceStartup;
				Type looseScriptType = Utils.GetLooseScriptType("DG.Tweening.DOTweenModuleUtils");
				if ((object)looseScriptType != null)
				{
					MethodInfo method = looseScriptType.GetMethod("Init", BindingFlags.Static | BindingFlags.Public);
					object obj = method.Invoke(null, null);
				}
				else
				{
					Debugger.LogError("Couldn't load Modules system");
				}
			}
			else
			{
				if (Debugger._logPriority >= 1)
				{
					Debugger.LogWarning("Duplicate DOTweenComponent instance found in scene: destroying it");
				}
				GameObject obj2 = base.gameObject;
				UnityEngine.Object.Destroy(obj2);
			}
		}

		[Token(Token = "0x6000288")]
		[Address(RVA = "0x106F9FC", Offset = "0x106F9FC", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1ED3E68]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202697A]) = v40;\nL_001A:\n\tgoto L_0029;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0029;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = DG.Tweening.DOTween;\nL_0029:\n\tgoto L_0033;\n\tv63 = *([v57 @ X8_v5+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tgoto L_0033;\n\tv74 = v57;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v74, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0033:\n\tv73 = UnityEngine.Object::op_Inequality(v56.instance, this);\n\tv76 = v73 == 0;\n\tif (v76) goto L_0058;\n\tthis._duplicateToDestroy = 1;\n\tv80 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_0050;\n\tv110 = *([v86 @ X8_v7+E0]);\n\tv111 = v110 == 0;\n\tv112 = ~v111;\n\tif (v112) goto L_0050;\n\tv115 = v86;\n\tv114 = \"il2cpp_codegen_runtime_class_init\"(v115, v79, v72, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0050:\n\tUnityEngine.Object::Destroy(v80);\n\treturn;\nL_0058:\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			if (DOTween.instance != this)
			{
				_duplicateToDestroy = true;
				GameObject obj = base.gameObject;
				UnityEngine.Object.Destroy(obj);
			}
		}

		[Token(Token = "0x6000289")]
		[Address(RVA = "0x106FAF4", Offset = "0x106FAF4", Length = "0x374")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1F0F410]);\n\tv27 = *([v26 @ X8_v80]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202697B]) = v46;\nL_0018:\n\tv48 = UnityEngine.Time::get_realtimeSinceStartup();\n\tv51 = v48 - this._unscaledTime;\n\tthis._unscaledDeltaTime = v51;\n\tgoto L_002B;\n\tv57 = *([v53 @ X0_v3 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_002B;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v53, methodInfo, v30, v31, v32, v33, v34, v35, v51, v49, v38, v39, v40, v41, v42, v43);\n\tv61 = DG.Tweening.DOTween;\nL_002B:\n\tv66 = ~v64.useSmoothDeltaTime;\n\tif (v66) goto L_005A;\n\tgoto L_0045;\n\tv120 = *([v60 @ X0_v4 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tif (v122) goto L_0045;\n\tv138 = \"il2cpp_codegen_runtime_class_init\"(v60, methodInfo, v30, v31, v32, v33, v34, v35, v51, v49, v38, v39, v40, v41, v42, v43);\n\tv123 = DG.Tweening.DOTween;\n\tv124 = *([v123 @ X0_v72+B8]);\nL_0045:\n\tv73 = this._unscaledDeltaTime <= v113.maxSmoothUnscaledTime;\n\tif (v73) goto L_005A;\n\tgoto L_0053;\n\tv165 = *([v107 @ X0_v68+E0]);\n\tv166 = v165 == 0;\n\tv167 = ~v166;\n\tif (v167) goto L_0053;\n\tv168 = \"il2cpp_codegen_runtime_class_init\"(v107, methodInfo, v30, v31, v32, v33, v34, v35, v104, v49, v38, v39, v40, v41, v42, v43);\n\tv200 = DG.Tweening.DOTween;\n\tv170 = *([v200 @ X8_v75+B8]);\nL_0053:\n\tthis._unscaledDeltaTime = v169.maxSmoothUnscaledTime;\nL_005A:\n\tgoto L_0063;\n\tv128 = *([v116 @ X0_v6 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv129 = v128 == 0;\n\tv130 = ~v129;\n\tgoto L_0063;\n\tv142 = \"il2cpp_codegen_runtime_class_init\"(v116, methodInfo, v30, v31, v32, v33, v34, v35, v103, v49, v38, v39, v40, v41, v42, v43);\n\tv132 = DG.Tweening.Core.TweenManager;\nL_0063:\n\tv137 = ~v135.hasActiveDefaultTweens;\n\tif (v137) goto L_0097;\n\tgoto L_0072;\n\tv171 = *([v143 @ X0_v51 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv172 = v171 == 0;\n\tv173 = ~v172;\n\tif (v173) goto L_0072;\n\tv185 = \"il2cpp_codegen_runtime_class_init\"(v143, methodInfo, v30, v31, v32, v33, v34, v35, v103, v49, v38, v39, v40, v41, v42, v43);\n\tv175 = DG.Tweening.DOTween;\nL_0072:\n\tv180 = ~v178.useSmoothDeltaTime;\n\tif (v180) goto L_0078;\n\tv201 = UnityEngine.Time::get_smoothDeltaTime();\n\tgoto L_007E;\nL_0078:\n\tv201 = UnityEngine.Time::get_deltaTime();\nL_007E:\n\tgoto L_008C;\n\tv262 = *([v203 @ X0_v54 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv263 = v262 == 0;\n\tv264 = ~v263;\n\tif (v264) goto L_008C;\n\tv281 = \"il2cpp_codegen_runtime_class_init\"(v203, methodInfo, v30, v31, v32, v33, v34, v35, v201, v49, v38, v39, v40, v41, v42, v43);\n\tv266 = DG.Tweening.DOTween;\nL_008C:\n\tgoto L_0092;\n\tv282 = *([v270 @ X0_v56+E0]);\n\tv283 = v282 == 0;\n\tv284 = ~v283;\n\tgoto L_0092;\n\tv286 = \"il2cpp_codegen_runtime_class_init\"(v270, methodInfo, v30, v31, v32, v33, v34, v35, v201, v49, v38, v39, v40, v41, v42, v43);\nL_0092:\n\tv154 = v201 * v269.timeScale;\n\tv156 = v269.timeScale * this._unscaledDeltaTime;\n\tDG.Tweening.Core.TweenManager::Update(0, v154, v156);\nL_0097:\n\tv164 = UnityEngine.Time::get_realtimeSinceStartup();\n\tthis._unscaledTime = v164;\n\tgoto L_00A6;\n\tv190 = *([v181 @ X0_v10 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv191 = v190 == 0;\n\tv192 = ~v191;\n\tif (v192) goto L_00A6;\n\tv207 = \"il2cpp_codegen_runtime_class_init\"(v181, methodInfo, v30, v31, v32, v33, v34, v35, v164, v155, v38, v39, v40, v41, v42, v43);\n\tv194 = DG.Tweening.Core.TweenManager;\nL_00A6:\n\tv199 = ~v197.isUnityEditor;\n\tif (v199) goto L_0156;\n\tv209 = this.inspectorUpdater + 1;\n\tthis.inspectorUpdater = v209;\n\tgoto L_00B8;\n\tv274 = *([v210 @ X0_v13 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv275 = v274 == 0;\n\tv276 = ~v275;\n\tif (v276) goto L_00B8;\n\tv287 = \"il2cpp_codegen_runtime_class_init\"(v210, methodInfo, v30, v31, v32, v33, v34, v35, v164, v155, v38, v39, v40, v41, v42, v43);\n\tv277 = DG.Tweening.DOTween;\nL_00B8:\n\tv243 = ~v280.showUnityEditorReport;\n\tif (v243) goto L_0156;\n\tgoto L_00C7;\n\tv292 = *([v288 @ X0_v15 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv293 = v292 == 0;\n\tv294 = ~v293;\n\tif (v294) goto L_00C7;\n\tv298 = \"il2cpp_codegen_runtime_class_init\"(v288, methodInfo, v30, v31, v32, v33, v34, v35, v164, v155, v38, v39, v40, v41, v42, v43);\n\tv295 = DG.Tweening.Core.TweenManager;\nL_00C7:\n\tv244 = ~v252.hasActiveTweens;\n\tif (v244) goto L_0156;\n\tgoto L_00D9;\n\tv302 = *([v239 @ X0_v16 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv303 = v302 == 0;\n\tv304 = ~v303;\n\tif (v304) goto L_00D9;\n\tv307 = \"il2cpp_codegen_runtime_class_init\"(v239, methodInfo, v30, v31, v32, v33, v34, v35, v164, v155, v38, v39, v40, v41, v42, v43);\n\tv337 = DG.Tweening.Core.TweenManager;\n\tv310 = *([v337 @ X8_v54+B8]);\nL_00D9:\n\tgoto L_00ED;\n\tv316 = *([v311 @ X0_v18 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv317 = v316 == 0;\n\tv318 = ~v317;\n\tgoto L_00ED;\n\tv338 = \"il2cpp_codegen_runtime_class_init\"(v311, methodInfo, v30, v31, v32, v33, v34, v35, v164, v155, v38, v39, v40, v41, v42, v43);\n\tv320 = DG.Tweening.DOTween;\nL_00ED:\n\tv336 = v309.totActiveTweeners <= v323.maxActiveTweenersReached;\n\tif (v336) goto L_010E;\n\tgoto L_0101;\n\tv357 = *([v339 @ X8_v46 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv358 = v357 == 0;\n\tv359 = ~v358;\n\tif (v359) goto L_0101;\n\tv381 = v339;\n\tv382 = \"il2cpp_codegen_runtime_class_init\"(v381, methodInfo, v30, v31, v32, v33, v34, v35, v164, v155, v38, v39, v40, v41, v42, v43);\n\tv365 = DG.Tweening.Core.TweenManager;\n\tv362 = DG.Tweening.DOTween;\nL_0101:\n\tgoto L_0109;\n\tv383 = *([v361 @ X0_v35 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv384 = v383 == 0;\n\tv385 = ~v384;\n\tgoto L_0109;\n\tv399 = \"il2cpp_codegen_runtime_class_init\"(v361, methodInfo, v30, v31, v32, v33, v34, v35, v164, v155, v38, v39, v40, v41, v42, v43);\n\tv386 = DG.Tweening.DOTween;\nL_0109:\n\tv352.maxActiveTweenersReached = v366.totActiveTweeners;\nL_010E:\n\tgoto L_011C;\n\tv369 = *([v353 @ X8_v31 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv370 = v369 == 0;\n\tv371 = ~v370;\n\tgoto L_011C;\n\tv388 = v353;\n\tv389 = \"il2cpp_codegen_runtime_class_init\"(v388, methodInfo, v30, v31, v32, v33, v34, v35, v164, v155, v38, v39, v40, v41, v42, v43);\n\tv377 = DG.Tweening.Core.TweenManager;\n\tv374 = DG.Tweening.DOTween;\nL_011C:\n\tgoto L_0130;\n\tv390 = *([v373 @ X0_v21 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv391 = v390 == 0;\n\tv392 = ~v391;\n\tgoto L_0130;\n\tv400 = \"il2cpp_codegen_runtime_class_init\"(v373, methodInfo, v30, v31, v32, v33, v34, v35, v164, v155, v38, v39, v40, v41, v42, v43);\n\tv393 = DG.Tweening.DOTween;\nL_0130:\n\tv215 = v378.totActiveSequences <= v395.maxActiveSequencesReached;\n\tif (v215) goto L_0156;\n\tgoto L_0144;\n\tv405 = *([v401 @ X8_v37 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv406 = v405 == 0;\n\tv407 = ~v406;\n\tif (v407) goto L_0144;\n\tv417 = v401;\n\tv418 = \"il2cpp_codegen_runtime_class_init\"(v417, methodInfo, v30, v31, v32, v33, v34, v35, v164, v155, v38, v39, v40, v41, v42, v43);\n\tv413 = DG.Tweening.Core.TweenManager;\n\tv410 = DG.Tweening.DOTween;\nL_0144:\n\tgoto L_014C;\n\tv419 = *([v409 @ X0_v23 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv420 = v419 == 0;\n\tv421 = ~v420;\n\tgoto L_014C;\n\tv424 = \"il2cpp_codegen_runtime_class_init\"(v409, methodInfo, v30, v31, v32, v33, v34, v35, v164, v155, v38, v39, v40, v41, v42, v43);\n\tv422 = DG.Tweening.DOTween;\nL_014C:\n\tv250.maxActiveSequencesReached = v414.totActiveSequences;\nL_0156:\n\treturn;\n// 168 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			float unscaledDeltaTime = realtimeSinceStartup - _unscaledTime;
			_unscaledDeltaTime = unscaledDeltaTime;
			if (DOTween.useSmoothDeltaTime && _unscaledDeltaTime > DOTween.maxSmoothUnscaledTime)
			{
				_unscaledDeltaTime = DOTween.maxSmoothUnscaledTime;
			}
			if (TweenManager.hasActiveDefaultTweens)
			{
				float num = ((!DOTween.useSmoothDeltaTime) ? Time.deltaTime : Time.smoothDeltaTime);
				float deltaTime = num * DOTween.timeScale;
				float independentTime = DOTween.timeScale * _unscaledDeltaTime;
				TweenManager.Update(default(UpdateType), deltaTime, independentTime);
			}
			float realtimeSinceStartup2 = Time.realtimeSinceStartup;
			_unscaledTime = realtimeSinceStartup2;
			if (!TweenManager.isUnityEditor)
			{
				return;
			}
			int num2 = inspectorUpdater + 1;
			inspectorUpdater = num2;
			if (DOTween.showUnityEditorReport && TweenManager.hasActiveTweens)
			{
				if (TweenManager.totActiveTweeners > DOTween.maxActiveTweenersReached)
				{
					DOTween.maxActiveTweenersReached = TweenManager.totActiveTweeners;
				}
				if (TweenManager.totActiveSequences > DOTween.maxActiveSequencesReached)
				{
					DOTween.maxActiveSequencesReached = TweenManager.totActiveSequences;
				}
			}
		}

		[Token(Token = "0x600028A")]
		[Address(RVA = "0x10702B8", Offset = "0x10702B8", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EDFDF0]);\n\tv27 = *([v26 @ X8_v22]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202697C]) = v46;\nL_001D:\n\tgoto L_0026;\n\tv53 = *([v49 @ X0_v2 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0026;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v49, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv57 = DG.Tweening.Core.TweenManager;\nL_0026:\n\tv62 = ~v60.hasActiveLateTweens;\n\tif (v62) goto L_0045;\n\tgoto L_0037;\n\tv78 = *([v66 @ X0_v4 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_0037;\n\tv114 = \"il2cpp_codegen_runtime_class_init\"(v66, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv82 = DG.Tweening.DOTween;\nL_0037:\n\tv87 = ~v85.useSmoothDeltaTime;\n\tif (v87) goto L_0047;\n\tv119 = UnityEngine.Time::get_smoothDeltaTime();\n\tgoto L_004D;\nL_0045:\n\treturn;\nL_0047:\n\tv119 = UnityEngine.Time::get_deltaTime();\nL_004D:\n\tgoto L_005B;\n\tv126 = *([v121 @ X0_v7 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv127 = v126 == 0;\n\tv128 = ~v127;\n\tif (v128) goto L_005B;\n\tv140 = \"il2cpp_codegen_runtime_class_init\"(v121, methodInfo, v30, v31, v32, v33, v34, v35, v119, v37, v38, v39, v40, v41, v42, v43);\n\tv130 = DG.Tweening.DOTween;\nL_005B:\n\tgoto L_0061;\n\tv141 = *([v134 @ X0_v9+E0]);\n\tv142 = v141 == 0;\n\tv143 = ~v142;\n\tgoto L_0061;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v134, methodInfo, v30, v31, v32, v33, v34, v35, v119, v37, v38, v39, v40, v41, v42, v43);\nL_0061:\n\tv99 = v119 * v133.timeScale;\n\tv89 = v133.timeScale * this._unscaledDeltaTime;\n\tDG.Tweening.Core.TweenManager::Update(1, v99, v89);\n\treturn;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void LateUpdate()
		{
			if (TweenManager.hasActiveLateTweens)
			{
				float num = ((!DOTween.useSmoothDeltaTime) ? Time.deltaTime : Time.smoothDeltaTime);
				float deltaTime = num * DOTween.timeScale;
				float independentTime = DOTween.timeScale * _unscaledDeltaTime;
				TweenManager.Update(UpdateType.Late, deltaTime, independentTime);
			}
		}

		[Token(Token = "0x600028B")]
		[Address(RVA = "0x10703EC", Offset = "0x10703EC", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EDDD70]);\n\tv27 = *([v26 @ X8_v23]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 0 | 1;\n\t*([202697D]) = v47;\nL_001D:\n\tgoto L_0026;\n\tv54 = *([v50 @ X0_v2 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0026;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv58 = DG.Tweening.Core.TweenManager;\nL_0026:\n\tv63 = ~v61.hasActiveFixedTweens;\n\tif (v63) goto L_0055;\n\tv66 = UnityEngine.Time::get_timeScale();\n\tv68 = v66 <= 0;\n\tif (v68) goto L_0055;\n\tgoto L_0046;\n\tv157 = *([v153 @ X0_v6 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv158 = v157 == 0;\n\tv159 = ~v158;\n\tif (v159) goto L_0046;\n\tv167 = \"il2cpp_codegen_runtime_class_init\"(v153, methodInfo, v30, v31, v32, v33, v34, v35, v66, v37, v38, v39, v40, v41, v42, v43);\n\tv161 = DG.Tweening.DOTween;\nL_0046:\n\tv166 = ~v164.useSmoothDeltaTime;\n\tif (v166) goto L_0057;\n\tv172 = UnityEngine.Time::get_smoothDeltaTime();\n\tgoto L_005D;\nL_0055:\n\treturn;\nL_0057:\n\tv172 = UnityEngine.Time::get_deltaTime();\nL_005D:\n\tgoto L_0068;\n\tv179 = *([v174 @ X0_v9 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv180 = v179 == 0;\n\tv181 = ~v180;\n\tif (v181) goto L_0068;\n\tv191 = \"il2cpp_codegen_runtime_class_init\"(v174, methodInfo, v30, v31, v32, v33, v34, v35, v172, v37, v38, v39, v40, v41, v42, v43);\n\tv183 = DG.Tweening.DOTween;\nL_0068:\n\tv190 = ~v186.useSmoothDeltaTime;\n\tif (v190) goto L_006C;\n\tv194 = UnityEngine.Time::get_smoothDeltaTime();\n\tgoto L_006F;\nL_006C:\n\tv194 = UnityEngine.Time::get_deltaTime();\nL_006F:\n\tv197 = UnityEngine.Time::get_timeScale();\n\tgoto L_007E;\n\tv203 = *([v198 @ X0_v13 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv204 = v203 == 0;\n\tv205 = ~v204;\n\tif (v205) goto L_007E;\n\tv215 = \"il2cpp_codegen_runtime_class_init\"(v198, methodInfo, v30, v31, v32, v33, v34, v35, v197, v37, v38, v39, v40, v41, v42, v43);\n\tv207 = DG.Tweening.DOTween;\nL_007E:\n\tv211 = v172 * v186.timeScale;\n\tgoto L_008A;\n\tv216 = *([v146 @ X8_v16+E0]);\n\tv217 = v216 == 0;\n\tv218 = ~v217;\n\tgoto L_008A;\n\tv222 = v146;\n\tv220 = \"il2cpp_codegen_runtime_class_init\"(v222, methodInfo, v30, v31, v32, v33, v34, v35, v197, v37, v38, v39, v40, v41, v42, v43);\nL_008A:\n\tv221 = v194 / v197;\n\tv112 = v221 * v210.timeScale;\n\tDG.Tweening.Core.TweenManager::Update(2, v211, v112);\n\treturn;\n// 91 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void FixedUpdate()
		{
			if (TweenManager.hasActiveFixedTweens)
			{
				float timeScale = Time.timeScale;
				if (timeScale > 0f)
				{
					float num = ((!DOTween.useSmoothDeltaTime) ? Time.deltaTime : Time.smoothDeltaTime);
					float num2 = ((!DOTween.useSmoothDeltaTime) ? Time.deltaTime : Time.smoothDeltaTime);
					float timeScale2 = Time.timeScale;
					float deltaTime = num * DOTween.timeScale;
					float num3 = num2 / timeScale2;
					float independentTime = num3 * DOTween.timeScale;
					TweenManager.Update(UpdateType.Fixed, deltaTime, independentTime);
				}
			}
		}

		[Token(Token = "0x600028C")]
		[Address(RVA = "0x1070580", Offset = "0x1070580", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EEA978]);\n\tv21 = *([v20 @ X8_v31]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([202697E]) = v41;\nL_001A:\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv52 = DG.Tweening.DOTween;\nL_0023:\n\tv57 = ~v55.drawGizmos;\n\tif (v57) goto L_008D;\n\tgoto L_0034;\n\tv130 = *([v61 @ X0_v5 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv131 = v130 == 0;\n\tv132 = ~v131;\n\tif (v132) goto L_0034;\n\tv174 = \"il2cpp_codegen_runtime_class_init\"(v61, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv133 = DG.Tweening.Core.TweenManager;\nL_0034:\n\tv119 = ~v136.isUnityEditor;\n\tif (v119) goto L_008D;\n\tgoto L_0042;\n\tv179 = *([v175 @ X0_v7 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv180 = v179 == 0;\n\tv181 = ~v180;\n\tif (v181) goto L_0042;\n\tv186 = \"il2cpp_codegen_runtime_class_init\"(v175, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv182 = DG.Tweening.DOTween;\nL_0042:\n\tv122 = v185.GizmosDelegates;\n\tv76 = v122._size < 1;\n\tif (v76) goto L_008D;\n\tgoto L_0058;\nL_0058:\n\tgoto L_0060;\n\tv241 = *([v234 @ X0_v13 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv242 = v241 == 0;\n\tv243 = ~v242;\n\tgoto L_0060;\n\tv247 = \"il2cpp_codegen_runtime_class_init\"(v234, v191, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv244 = DG.Tweening.DOTween;\nL_0060:\n\tv66 = v220.GizmosDelegates;\n\tv249 = v195 < v66._size;\n\tv231 = ~v249;\n\tv223 = ~v231;\n\tif (v223) goto L_0071;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0071:\n\tv252 = v66._items;\n\tDG.Tweening.TweenCallback::Invoke(v252[v195 @ X21_v6 (System.Int32)]);\n\tv195 = v195 + 1;\n\tv75 = v195 < v122._size;\n\tif (v75) goto L_0058;\nL_008D:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDrawGizmos()
		{
			if (!DOTween.drawGizmos || !TweenManager.isUnityEditor)
			{
				return;
			}
			List<TweenCallback> gizmosDelegates = DOTween.GizmosDelegates;
			if (gizmosDelegates.Count < 1)
			{
				return;
			}
			int num = 0;
			do
			{
				List<TweenCallback> gizmosDelegates2 = DOTween.GizmosDelegates;
				if (num >= gizmosDelegates2.Count)
				{
					throw new ArgumentOutOfRangeException();
				}
				TweenCallback[] items = gizmosDelegates2._items;
				items[num]();
				num++;
			}
			while (num < gizmosDelegates.Count);
		}

		[Token(Token = "0x600028D")]
		[Address(RVA = "0x10706C8", Offset = "0x10706C8", Length = "0x478")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EC3AD0]);\n\tv21 = *([v20 @ X8_v77]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202697F]) = v40;\nL_0015:\n\tv42 = this._duplicateToDestroy;\n\tv43 = ~this._duplicateToDestroy;\n\tv44 = ~v43;\n\tif (v44) goto L_01A0;\n\tgoto L_0026;\n\tv114 = *([v47 @ X0_v3 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv115 = v114 == 0;\n\tv116 = ~v115;\n\tif (v116) goto L_0026;\n\tv124 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv118 = DG.Tweening.DOTween;\nL_0026:\n\tv155 = *([v163 @ X0_v6 (Il2CppClass<DG.Tweening.DOTween>)+B8]);\n\tv122 = v155.showUnityEditorReport;\n\tv123 = ~v155.showUnityEditorReport;\n\tif (v123) goto L_004E;\n\tgoto L_0035;\n\tv149 = *([v117 @ X0_v4 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv150 = v149 == 0;\n\tv151 = ~v150;\n\tif (v151) goto L_0035;\n\tv154 = \"il2cpp_codegen_runtime_class_init\"(v117, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv226 = DG.Tweening.DOTween;\n\tv156 = *([v226 @ X8_v73+B8]);\nL_0035:\n\tv157 = v155 + 0x60;\n\tv159 = 0xDC3560(v157, 0, v130, v486, v482, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv173 = v170.Version + 0x64;\n\tv174 = 0xDC3560(v173, 0, v130, v486, v482, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv231 = System.String::Concat(\"Max overall simultaneous active Tweeners/Sequences: \", v159, \"/\", v174);\n\tDG.Tweening.Core.Debugger::LogReport(v231);\nL_004E:\n\tgoto L_0055;\n\tv160 = *([v138 @ X0_v5 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv161 = v160 == 0;\n\tv162 = ~v161;\n\tgoto L_0055;\n\tv175 = \"il2cpp_codegen_runtime_class_init\"(v138, v134, v130, v132, v128, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv164 = DG.Tweening.DOTween;\nL_0055:\n\tv237 = *([v163 @ X0_v6 (Il2CppClass<DG.Tweening.DOTween>)+B8]);\n\tv122 = v237.useSafeMode;\n\tv169 = ~v237.useSafeMode;\n\tif (v169) goto L_0163;\n\tgoto L_0067;\n\tv232 = *([v163 @ X0_v6 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv233 = v232 == 0;\n\tv234 = ~v233;\n\tif (v234) goto L_0067;\n\tv257 = \"il2cpp_codegen_runtime_class_init\"(v163, v134, v130, v132, v128, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv236 = DG.Tweening.DOTween;\n\tv238 = *([v236 @ X0_v76+B8]);\nL_0067:\n\tv42 = *([v237 @ X8_v23 (Il2CppStaticFields<DG.Tweening.DOTween>)+74]);\n\tv122 = *([v237 @ X8_v23 (Il2CppStaticFields<DG.Tweening.DOTween>)+6C]) + v237.safeModeReport;\n\tv122 = v122 + *([v237 @ X8_v23 (Il2CppStaticFields<DG.Tweening.DOTween>)+70]);\n\tv42 = v122 + v42;\n\tv180 = v42 < 1;\n\tif (v180) goto L_0163;\n\t// 124 Box v262 @ X0_v26 (System.Object), typeof(System.Int32), &v42 @ X8_v3 (System.Boolean)\n\tv279 = System.String::Format(\"DOTween's safe mode captured {0} errors. This is usually ok (it's what safe mode is there for) but if your game is encountering issues you should set Log Behaviour to Default in DOTween Utility Panel in order to get detailed warnings when an error is captured (consider that these errors are always on the user side).\", v262);\n\tgoto L_0092;\n\tv302 = *([v284 @ X8_v29 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv303 = v302 == 0;\n\tv304 = ~v303;\n\tif (v304) goto L_0092;\n\tv335 = v284;\n\tv307 = \"il2cpp_codegen_runtime_class_init\"(v335, v275, v276, v132, v128, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv310 = DG.Tweening.DOTween;\nL_0092:\n\tv369 = v311.safeModeReport;\n\tv323 = v311.safeModeReport < 1;\n\tif (v323) goto L_00BF;\n\tgoto L_00AF;\n\tv366 = *([v309 @ X8_v30 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv367 = v366 == 0;\n\tv368 = ~v367;\n\tif (v368) goto L_00AF;\n\tv400 = v309;\n\tv372 = \"il2cpp_codegen_runtime_class_init\"(v400, v275, v276, v132, v128, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv434 = DG.Tweening.DOTween;\n\tv374 = *([v434 @ X8_v62+B8]);\n\tv370 = *([v374 @ X8_v63+68]);\nL_00AF:\n\tv377 = 0xDC3560(&v369 @ X9_v59 (DG.Tweening.Core.SafeModeReport), 0, 0, v486, v482, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv354 = System.String::Concat(v279, \"\\n- \", v377, \" missing target or field errors\");\nL_00BF:\n\tgoto L_00C7;\n\tv378 = *([v357 @ X8_v31 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv379 = v378 == 0;\n\tv380 = ~v379;\n\tgoto L_00C7;\n\tv405 = v357;\n\tv383 = \"il2cpp_codegen_runtime_class_init\"(v405, v349, v345, v347, v343, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv386 = DG.Tweening.DOTween;\nL_00C7:\n\tv387 = *([v523 @ X8_v36 (Il2CppClass<DG.Tweening.DOTween>)+B8]);\n\tv122 = *([v387 @ X9_v31 (Il2CppStaticFields<DG.Tweening.DOTween>)+70]);\n\tv399 = *([v387 @ X9_v31 (Il2CppStaticFields<DG.Tweening.DOTween>)+70]) < 1;\n\tif (v399) goto L_00F5;\n\tgoto L_00E5;\n\tv435 = *([v385 @ X8_v32 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv436 = v435 == 0;\n\tv437 = ~v436;\n\tif (v437) goto L_00E5;\n\tv469 = v385;\n\tv441 = \"il2cpp_codegen_runtime_class_init\"(v469, v349, v345, v347, v343, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv503 = DG.Tweening.DOTween;\n\tv443 = *([v503 @ X8_v55+B8]);\n\tv439 = *([v443 @ X8_v56+70]);\nL_00E5:\n\tv446 = 0xDC3560(&v122 @ X9_v2 (System.Boolean), 0, v484, v486, v482, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv424 = System.String::Concat(v222, \"\\n- \", v446, \" startup errors\");\nL_00F5:\n\tgoto L_00FD;\n\tv447 = *([v427 @ X8_v33 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv448 = v447 == 0;\n\tv449 = ~v448;\n\tgoto L_00FD;\n\tv474 = v427;\n\tv452 = \"il2cpp_codegen_runtime_class_init\"(v474, v419, v415, v417, v413, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv455 = DG.Tweening.DOTween;\nL_00FD:\n\tv456 = *([v523 @ X8_v36 (Il2CppClass<DG.Tweening.DOTween>)+B8]);\n\tv122 = *([v456 @ X9_v36 (Il2CppStaticFields<DG.Tweening.DOTween>)+6C]);\n\tv468 = *([v456 @ X9_v36 (Il2CppStaticFields<DG.Tweening.DOTween>)+6C]) < 1;\n\tif (v468) goto L_012B;\n\tgoto L_011B;\n\tv504 = *([v454 @ X8_v34 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv505 = v504 == 0;\n\tv506 = ~v505;\n\tif (v506) goto L_011B;\n\tv529 = v454;\n\tv510 = \"il2cpp_codegen_runtime_class_init\"(v529, v419, v415, v417, v413, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv551 = DG.Tweening.DOTween;\n\tv512 = *([v551 @ X8_v48+B8]);\n\tv508 = *([v512 @ X8_v49+6C]);\nL_011B:\n\tv515 = 0xDC3560(&v122 @ X9_v2 (System.Boolean), 0, v484, v486, v482, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv493 = System.String::Concat(v222, \"\\n- \", v515, \" errors inside callbacks (these might be important)\");\nL_012B:\n\tgoto L_0133;\n\tv516 = *([v496 @ X8_v35 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv517 = v516 == 0;\n\tv518 = ~v517;\n\tgoto L_0133;\n\tv534 = v496;\n\tv521 = \"il2cpp_codegen_runtime_class_init\"(v534, v488, v484, v486, v482, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv524 = DG.Tweening.DOTween;\nL_0133:\n\tv525 = *([v523 @ X8_v36 (Il2CppClass<DG.Tweening.DOTween>)+B8]);\n\tv122 = *([v525 @ X9_v41 (Il2CppStaticFields<DG.Tweening.DOTween>)+74]);\n\tv179 = *([v525 @ X9_v41 (Il2CppStaticFields<DG.Tweening.DOTween>)+74]) < 1;\n\tif (v179) goto L_015E;\n\tgoto L_0151;\n\tv552 = *([v523 @ X8_v36 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv553 = v552 == 0;\n\tv554 = ~v553;\n\tif (v554) goto L_0151;\n\tv564 = v523;\n\tv558 = \"il2cpp_codegen_runtime_class_init\"(v564, v488, v484, v486, v482, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv568 = DG.Tweening.DOTween;\n\tv560 = *([v568 @ X8_v41+B8]);\n\tv556 = *([v560 @ X8_v42+74]);\nL_0151:\n\tv563 = 0xDC3560(&v122 @ X9_v2 (System.Boolean), 0, v484, v486, v482, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv546 = System.String::Concat(v222, \"\\n- \", v563, \" undetermined errors (these might be important)\");\nL_015E:\n\tDG.Tweening.Core.Debugger::LogSafeModeReport(v222);\nL_0163:\n\tgoto L_0172;\n\tv244 = *([v212 @ X0_v7 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv245 = v244 == 0;\n\tv246 = ~v245;\n\tgoto L_0172;\n\tv263 = \"il2cpp_codegen_runtime_class_init\"(v212, v207, v204, v94, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv248 = DG.Tweening.DOTween;\nL_0172:\n\tgoto L_017C;\n\tv264 = *([v254 @ X8_v17+E0]);\n\tv265 = v264 == 0;\n\tv266 = ~v265;\n\tgoto L_017C;\n\tv280 = v254;\n\tv269 = \"il2cpp_codegen_runtime_class_init\"(v280, v207, v204, v94, v90, v27, v28, \n// ... truncated")]
		private void OnDestroy()
		{
			//IL_0013: Expected I, but got O
			//IL_011d: Expected I, but got O
			//IL_01a6: Expected I, but got O
			//IL_014f: Expected O, but got I
			//IL_016e: Expected O, but got I
			//IL_002f: Expected O, but got I4
			//IL_004e: Expected I, but got O
			//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ef: Expected I4, but got Unknown
			//IL_008a: Expected I, but got O
			//IL_02cc: Expected I, but got O
			//IL_0296: Expected O, but got I4
			//IL_02b6: Expected I, but got O
			//IL_036a: Expected I, but got O
			//IL_0334: Expected O, but got I4
			//IL_0354: Expected I, but got O
			//IL_0408: Expected I, but got O
			//IL_03d2: Expected O, but got I4
			//IL_03f2: Expected I, but got O
			bool duplicateToDestroy = _duplicateToDestroy;
			if (_duplicateToDestroy)
			{
				return;
			}
			IntPtr intPtr = (IntPtr)typeof(DOTween);
			IntPtr intPtr2 = (IntPtr)DOTween.Version;
			bool showUnityEditorReport = DOTween.showUnityEditorReport;
			if (DOTween.showUnityEditorReport)
			{
				object obj = (long)intPtr2 + 96L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
				object obj2 = (long)(IntPtr)DOTween.Version + 100L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
				string text = default(string);
				string text2 = default(string);
				string message = "Max overall simultaneous active Tweeners/Sequences: " + text + "/" + text2;
				Debugger.LogReport(message);
				object obj3 = 0;
				string text3 = "/";
				string text4 = text2;
				intPtr = (IntPtr)typeof(DOTween);
			}
			IntPtr intPtr3 = (IntPtr)DOTween.Version;
			showUnityEditorReport = DOTween.useSafeMode;
			if (DOTween.useSafeMode)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ X8_v23 (Il2CppStaticFields<DG.Tweening.DOTween>)+74]");
				duplicateToDestroy = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ X8_v23 (Il2CppStaticFields<DG.Tweening.DOTween>)+6C]");
				showUnityEditorReport = (byte)(0 + DOTween.safeModeReport) != 0;
				bool num = showUnityEditorReport;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ X8_v23 (Il2CppStaticFields<DG.Tweening.DOTween>)+70]");
				showUnityEditorReport = (byte)((ulong)(num ? 1 : 0) + 0uL) != 0;
				duplicateToDestroy = (byte)((showUnityEditorReport ? 1u : 0u) + (duplicateToDestroy ? 1u : 0u)) != 0;
				if ((duplicateToDestroy ? 1 : 0) >= (true ? 1 : 0))
				{
					object arg = (duplicateToDestroy ? 1 : 0);
					string text5 = $"DOTween's safe mode captured {arg} errors. This is usually ok (it's what safe mode is there for) but if your game is encountering issues you should set Log Behaviour to Default in DOTween Utility Panel in order to get detailed warnings when an error is captured (consider that these errors are always on the user side).";
					IntPtr intPtr4 = (IntPtr)typeof(DOTween);
					SafeModeReport safeModeReport = DOTween.safeModeReport;
					bool flag = (long)(IntPtr)DOTween.safeModeReport < 1L;
					string text6 = null;
					string text7 = text5;
					if (!flag)
					{
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
						string text9 = default(string);
						string text8 = text5 + "\n- " + text9 + " missing target or field errors";
						object obj3 = 0;
						text6 = text9;
						string text4 = " missing target or field errors";
						intPtr4 = (IntPtr)typeof(DOTween);
						text7 = text8;
					}
					IntPtr intPtr5 = (IntPtr)DOTween.Version;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ X9_v31 (Il2CppStaticFields<DG.Tweening.DOTween>)+70]");
					showUnityEditorReport = false;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ X9_v31 (Il2CppStaticFields<DG.Tweening.DOTween>)+70]");
					if (0L >= 1L)
					{
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
						string text11 = default(string);
						string text10 = text7 + "\n- " + text11 + " startup errors";
						object obj3 = 0;
						text6 = text11;
						string text4 = " startup errors";
						intPtr4 = (IntPtr)typeof(DOTween);
						text7 = text10;
					}
					IntPtr intPtr6 = (IntPtr)DOTween.Version;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ X9_v36 (Il2CppStaticFields<DG.Tweening.DOTween>)+6C]");
					showUnityEditorReport = false;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ X9_v36 (Il2CppStaticFields<DG.Tweening.DOTween>)+6C]");
					if (0L >= 1L)
					{
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
						string text13 = default(string);
						string text12 = text7 + "\n- " + text13 + " errors inside callbacks (these might be important)";
						object obj3 = 0;
						text6 = text13;
						string text4 = " errors inside callbacks (these might be important)";
						intPtr4 = (IntPtr)typeof(DOTween);
						text7 = text12;
					}
					IntPtr intPtr7 = (IntPtr)DOTween.Version;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ X9_v41 (Il2CppStaticFields<DG.Tweening.DOTween>)+74]");
					showUnityEditorReport = false;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ X9_v41 (Il2CppStaticFields<DG.Tweening.DOTween>)+74]");
					if (0L >= 1L)
					{
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
						string text15 = default(string);
						string text14 = text7 + "\n- " + text15 + " undetermined errors (these might be important)";
						text7 = text14;
					}
					Debugger.LogSafeModeReport(text7);
				}
			}
			if (DOTween.instance == this)
			{
				DOTween.instance = null;
			}
			DOTween.Clear(destroy: true);
		}

		[Token(Token = "0x600028E")]
		[Address(RVA = "0x1070ED8", Offset = "0x1070ED8", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = pauseStatus == 0;\n\tif (v14) goto L_0010;\n\tv16 = UnityEngine.Time::get_realtimeSinceStartup();\n\tthis._pausedTime = v16;\n\tgoto L_001A;\nL_0010:\n\tv19 = UnityEngine.Time::get_realtimeSinceStartup();\n\tv21 = v19 - this._pausedTime;\n\tv22 = this._unscaledTime + v21;\n\tthis._unscaledTime = v22;\nL_001A:\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnApplicationPause(bool pauseStatus)
		{
			if (pauseStatus)
			{
				float realtimeSinceStartup = Time.realtimeSinceStartup;
				_pausedTime = realtimeSinceStartup;
				return;
			}
			float realtimeSinceStartup2 = Time.realtimeSinceStartup;
			float num = realtimeSinceStartup2 - _pausedTime;
			float unscaledTime = _unscaledTime + num;
			_unscaledTime = unscaledTime;
		}

		[Token(Token = "0x600028F")]
		[Address(RVA = "0x1070F2C", Offset = "0x1070F2C", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EF24B0]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, tweenersCapacity, sequencesCapacity, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2026980]) = v44;\nL_001D:\n\tgoto L_0025;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0025;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, tweenersCapacity, sequencesCapacity, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0025:\n\tDG.Tweening.Core.TweenManager::SetCapacities(tweenersCapacity, sequencesCapacity);\n\treturn this;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IDOTweenInit SetCapacity(int tweenersCapacity, int sequencesCapacity)
		{
			TweenManager.SetCapacities(tweenersCapacity, sequencesCapacity);
			return this;
		}

		[Token(Token = "0x6000290")]
		[Address(RVA = "0x107109C", Offset = "0x107109C", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EC93F8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, t, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2026981]) = v38;\nL_0016:\n\tv42 = new DG.Tweening.Core.DOTweenComponent+<WaitForCompletion>d__14();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0;\n\tv42.t = t;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal IEnumerator WaitForCompletion(Tween t)
		{
			_003CWaitForCompletion_003Ed__14 _003CWaitForCompletion_003Ed__15 = null;
			_003CWaitForCompletion_003Ed__15._003C_003E1__state = 0;
			_003CWaitForCompletion_003Ed__15.t = t;
			return _003CWaitForCompletion_003Ed__15;
		}

		[Token(Token = "0x6000291")]
		[Address(RVA = "0x107113C", Offset = "0x107113C", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EC70C8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, t, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2026982]) = v38;\nL_0016:\n\tv42 = new DG.Tweening.Core.DOTweenComponent+<WaitForRewind>d__15();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0;\n\tv42.t = t;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal IEnumerator WaitForRewind(Tween t)
		{
			_003CWaitForRewind_003Ed__15 _003CWaitForRewind_003Ed__16 = null;
			_003CWaitForRewind_003Ed__16._003C_003E1__state = 0;
			_003CWaitForRewind_003Ed__16.t = t;
			return _003CWaitForRewind_003Ed__16;
		}

		[Token(Token = "0x6000292")]
		[Address(RVA = "0x10711DC", Offset = "0x10711DC", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EF1890]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, t, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2026983]) = v38;\nL_0016:\n\tv42 = new DG.Tweening.Core.DOTweenComponent+<WaitForKill>d__16();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0;\n\tv42.t = t;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal IEnumerator WaitForKill(Tween t)
		{
			_003CWaitForKill_003Ed__16 _003CWaitForKill_003Ed__17 = null;
			_003CWaitForKill_003Ed__17._003C_003E1__state = 0;
			_003CWaitForKill_003Ed__17.t = t;
			return _003CWaitForKill_003Ed__17;
		}

		[Token(Token = "0x6000293")]
		[Address(RVA = "0x107127C", Offset = "0x107127C", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1ECA370]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, t, elapsedLoops, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([2026984]) = v41;\nL_0018:\n\tv45 = new DG.Tweening.Core.DOTweenComponent+<WaitForElapsedLoops>d__17();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.t = t;\n\tv45.elapsedLoops = elapsedLoops;\n\treturn v45;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal IEnumerator WaitForElapsedLoops(Tween t, int elapsedLoops)
		{
			_003CWaitForElapsedLoops_003Ed__17 _003CWaitForElapsedLoops_003Ed__18 = null;
			_003CWaitForElapsedLoops_003Ed__18._003C_003E1__state = 0;
			_003CWaitForElapsedLoops_003Ed__18.t = t;
			_003CWaitForElapsedLoops_003Ed__18.elapsedLoops = elapsedLoops;
			return _003CWaitForElapsedLoops_003Ed__18;
		}

		[Token(Token = "0x6000294")]
		[Address(RVA = "0x107132C", Offset = "0x107132C", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1F085A0]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, t, methodInfo, v26, v27, v28, v29, v30, position, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([2026985]) = v41;\nL_0018:\n\tv45 = new DG.Tweening.Core.DOTweenComponent+<WaitForPosition>d__18();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.t = t;\n\tv45.position = position;\n\treturn v45;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal IEnumerator WaitForPosition(Tween t, float position)
		{
			_003CWaitForPosition_003Ed__18 _003CWaitForPosition_003Ed__19 = null;
			_003CWaitForPosition_003Ed__19._003C_003E1__state = 0;
			_003CWaitForPosition_003Ed__19.t = t;
			_003CWaitForPosition_003Ed__19.position = position;
			return _003CWaitForPosition_003Ed__19;
		}

		[Token(Token = "0x6000295")]
		[Address(RVA = "0x10713DC", Offset = "0x10713DC", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1ECDFD0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, t, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2026986]) = v38;\nL_0016:\n\tv42 = new DG.Tweening.Core.DOTweenComponent+<WaitForStart>d__19();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0;\n\tv42.t = t;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal IEnumerator WaitForStart(Tween t)
		{
			_003CWaitForStart_003Ed__19 _003CWaitForStart_003Ed__20 = null;
			_003CWaitForStart_003Ed__20._003C_003E1__state = 0;
			_003CWaitForStart_003Ed__20.t = t;
			return _003CWaitForStart_003Ed__20;
		}

		[Token(Token = "0x6000296")]
		[Address(RVA = "0x107147C", Offset = "0x107147C", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ECBB00]);\n\tv19 = *([v18 @ X8_v23]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2026987]) = v39;\nL_0019:\n\tgoto L_0028;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0028;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = DG.Tweening.DOTween;\nL_0028:\n\tgoto L_0032;\n\tv62 = *([v56 @ X8_v5+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tgoto L_0032;\n\tv73 = v56;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v73, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0032:\n\tv72 = UnityEngine.Object::op_Inequality(v55.instance, 0);\n\tv75 = v72 == 0;\n\tv76 = ~v75;\n\tif (v76) goto L_006A;\n\tv80 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v80, \"[DOTween]\");\n\tgoto L_004D;\n\tv123 = *([v119 @ X0_v10+E0]);\n\tv124 = v123 == 0;\n\tv125 = ~v124;\n\tif (v125) goto L_004D;\n\tv127 = \"il2cpp_codegen_runtime_class_init\"(v119, v103, v82, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_004D:\n\tUnityEngine.Object::DontDestroyOnLoad(v80);\n\tv133 = UnityEngine.GameObject::AddComponent(v80);\n\tgoto L_0063;\n\tv139 = *([v135 @ X8_v15 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv140 = v139 == 0;\n\tv141 = ~v140;\n\tif (v141) goto L_0063;\n\tv145 = v135;\n\tv142 = \"il2cpp_codegen_runtime_class_init\"(v145, v84, v82, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv144 = DG.Tweening.DOTween;\nL_0063:\n\tv92.instance = v133;\nL_006A:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void Create()
		{
			if (!(DOTween.instance != null))
			{
				GameObject gameObject = new GameObject("[DOTween]");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				DOTweenComponent instance = gameObject.AddComponent<DOTweenComponent>();
				DOTween.instance = instance;
			}
		}

		[Token(Token = "0x6000297")]
		[Address(RVA = "0x10715BC", Offset = "0x10715BC", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE9B48]);\n\tv19 = *([v18 @ X8_v19]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2026988]) = v39;\nL_0019:\n\tgoto L_0028;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0028;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = DG.Tweening.DOTween;\nL_0028:\n\tgoto L_0032;\n\tv62 = *([v56 @ X8_v5+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tgoto L_0032;\n\tv73 = v56;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v73, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0032:\n\tv72 = UnityEngine.Object::op_Inequality(v55.instance, 0);\n\tv75 = v72 == 0;\n\tif (v75) goto L_005A;\n\tgoto L_0046;\n\tv96 = *([v76 @ X0_v12 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv97 = v96 == 0;\n\tv98 = ~v97;\n\t// 62 ConditionalJump @b29, v98 @ TEMP_v28\n\tv119 = \"il2cpp_codegen_runtime_class_init\"(v76, v70, v71, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv100 = DG.Tweening.DOTween;\nL_0046:\n\tv121 = UnityEngine.Component::get_gameObject(v103.instance);\n\tgoto L_0055;\n\tv137 = *([v89 @ X8_v14+E0]);\n\tv138 = v137 == 0;\n\tv139 = ~v138;\n\tif (v139) goto L_0055;\n\tv142 = v89;\n\tv141 = \"il2cpp_codegen_runtime_class_init\"(v142, v120, v71, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0055:\n\tUnityEngine.Object::Destroy(v121);\nL_005A:\n\tgoto L_0062;\n\tv106 = *([v92 @ X0_v8 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv107 = v106 == 0;\n\tv108 = ~v107;\n\tif (v108) goto L_0062;\n\tv123 = \"il2cpp_codegen_runtime_class_init\"(v92, v80, v71, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv110 = DG.Tweening.DOTween;\nL_0062:\n\tv113.instance = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void DestroyInstance()
		{
			if (DOTween.instance != null)
			{
				GameObject obj = DOTween.instance.gameObject;
				UnityEngine.Object.Destroy(obj);
			}
			DOTween.instance = null;
		}

		[Token(Token = "0x6000298")]
		[Address(RVA = "0x10716E8", Offset = "0x10716E8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenComponent()
		{
		}
	}
}
