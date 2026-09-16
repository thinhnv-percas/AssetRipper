using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening.Core
{
	[AddComponentMenu(null)]
	[Token(Token = "0x20000A5")]
	public class DOTweenComponent : MonoBehaviour, IDOTweenInit
	{
		[Token(Token = "0x40001CC")]
		[FieldOffset(Offset = "0x20")]
		public int inspectorUpdater;

		[Token(Token = "0x40001CD")]
		[FieldOffset(Offset = "0x24")]
		private float _unscaledTime;

		[Token(Token = "0x40001CE")]
		[FieldOffset(Offset = "0x28")]
		private float _unscaledDeltaTime;

		[Token(Token = "0x40001CF")]
		[FieldOffset(Offset = "0x2C")]
		private bool _paused;

		[Token(Token = "0x40001D0")]
		[FieldOffset(Offset = "0x30")]
		private float _pausedTime;

		[Token(Token = "0x40001D1")]
		[FieldOffset(Offset = "0x34")]
		private bool _isQuitting;

		[Token(Token = "0x40001D2")]
		[FieldOffset(Offset = "0x35")]
		private bool _duplicateToDestroy;

		[Token(Token = "0x60003E0")]
		[Address(RVA = "0xC2C478", Offset = "0xC2C478", Length = "0x210")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv20 = DG.Tweening.Core.DOTweenUtils;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv48 = DG.Tweening.DOTween;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv60 = UnityEngine.Object;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv70 = \"Duplicate DOTweenComponent instance found in scene: destroying it\";\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv75 = \"Init\";\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv86 = \"DG.Tweening.DOTweenModuleUtils\";\n\tv87 = \"il2cpp_codegen_initialize_runtime_metadata\"(v86, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv117 = \"Couldn't load Modules system\";\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v117, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A357D0]) = v40;\nL_002C:\n\tgoto L_0035;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv52 = DG.Tweening.DOTween;\nL_0035:\n\tgoto L_003B;\n\tv62 = v53;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v62, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_003B:\n\tv68 = UnityEngine.Object::op_Equality(v54.instance, 0);\n\tv73 = v68 == 0;\n\tif (v73) goto L_0072;\n\tgoto L_0048;\n\tv88 = \"il2cpp_codegen_runtime_class_init\"(v77, v66, v67, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv90 = DG.Tweening.DOTween;\nL_0048:\n\tv91.instance = this;\n\tthis.inspectorUpdater = 0;\n\tv93 = UnityEngine.Time::get_realtimeSinceStartup();\n\tthis._unscaledTime = v93;\n\tgoto L_0058;\n\tv134 = \"il2cpp_codegen_runtime_class_init\"(v120, v66, v67, v24, v25, v26, v27, v28, v93, v30, v31, v32, v33, v34, v35, v36);\nL_0058:\n\tv140 = DG.Tweening.Core.DOTweenUtils::GetLooseScriptType(\"DG.Tweening.DOTweenModuleUtils\");\n\tv146 = v140 == 0;\n\tif (v146) goto L_00AD;\n\tv162 = System.Type::GetMethod(v140, \"Init\", 0x18);\n\tv204 = System.Reflection.MethodBase::Invoke(v162, 0, 0);\n\treturn;\nL_0072:\n\tgoto L_0087;\n\tv95 = DG.Tweening.Core.Debugger;\n\tv96 = \"il2cpp_codegen_initialize_runtime_metadata\"(v95, v66, v67, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv99 = 1;\n\t*([1A35757]) = v99;\nL_0087:\n\tv115 = v103._logPriority < 1;\n\tif (v115) goto L_0090;\n\tDG.Tweening.Core.Debugger::LogWarning(\"Duplicate DOTweenComponent instance found in scene: destroying it\", 0);\nL_0090:\n\tv133 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_00A1;\n\tv147 = v141;\n\tv148 = \"il2cpp_codegen_runtime_class_init\"(v147, v132, v67, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_00A1:\n\tUnityEngine.Object::Destroy(v133);\n\treturn;\nL_00AD:\n\tDG.Tweening.Core.Debugger::LogError(\"Couldn't load Modules system\", 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 118 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			if (DOTween.instance == null)
			{
				DOTween.instance = this;
				inspectorUpdater = 0;
				float realtimeSinceStartup = Time.realtimeSinceStartup;
				_unscaledTime = realtimeSinceStartup;
				Type looseScriptType = DOTweenUtils.GetLooseScriptType("DG.Tweening.DOTweenModuleUtils");
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

		[Token(Token = "0x60003E1")]
		[Address(RVA = "0xC2C688", Offset = "0xC2C688", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = DG.Tweening.DOTween;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv46 = UnityEngine.Object;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A357D1]) = v38;\nL_001C:\n\tgoto L_0025;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv49 = DG.Tweening.DOTween;\nL_0025:\n\tgoto L_002B;\n\tv56 = v50;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v56, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_002B:\n\tv62 = UnityEngine.Object::op_Inequality(v51.instance, this);\n\tv64 = v62 == 0;\n\tif (v64) goto L_004A;\n\tthis._duplicateToDestroy = 1;\n\tv68 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_0043;\n\tv93 = v73;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v93, v67, v61, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0043:\n\tUnityEngine.Object::Destroy(v68);\n\treturn;\nL_004A:\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			if (DOTween.instance != this)
			{
				_duplicateToDestroy = true;
				GameObject obj = base.gameObject;
				UnityEngine.Object.Destroy(obj);
			}
		}

		[Token(Token = "0x60003E2")]
		[Address(RVA = "0xC2C760", Offset = "0xC2C760", Length = "0x2EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = DG.Tweening.DOTween;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv50 = DG.Tweening.Core.TweenManager;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A357D2]) = v46;\nL_001B:\n\tv48 = UnityEngine.Time::get_realtimeSinceStartup();\n\tv52 = v48 - this._unscaledTime;\n\tthis._unscaledDeltaTime = v52;\n\tgoto L_002A;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v53, methodInfo, v29, v30, v31, v32, v33, v34, v52, v51, v37, v38, v39, v40, v41, v42);\n\tv59 = DG.Tweening.DOTween;\nL_002A:\n\tv64 = ~v60.useSmoothDeltaTime;\n\tif (v64) goto L_004F;\n\tgoto L_0040;\n\tv113 = \"il2cpp_codegen_runtime_class_init\"(v58, methodInfo, v29, v30, v31, v32, v33, v34, v52, v51, v37, v38, v39, v40, v41, v42);\n\tv114 = DG.Tweening.DOTween;\n\tv115 = *([v114 @ X0_v72+B8]);\nL_0040:\n\tv70 = this._unscaledDeltaTime <= v108.maxSmoothUnscaledTime;\n\tif (v70) goto L_004F;\n\tgoto L_004A;\n\tv158 = \"il2cpp_codegen_runtime_class_init\"(v103, methodInfo, v29, v30, v31, v32, v33, v34, v100, v51, v37, v38, v39, v40, v41, v42);\n\tv171 = DG.Tweening.DOTween;\n\tv160 = *([v171 @ X8_v51+B8]);\n\tv159 = *([v160 @ X8_v52+24]);\nL_004A:\n\tthis._unscaledDeltaTime = v108.maxSmoothUnscaledTime;\nL_004F:\n\tgoto L_0054;\n\tv119 = \"il2cpp_codegen_runtime_class_init\"(v109, methodInfo, v29, v30, v31, v32, v33, v34, v98, v51, v37, v38, v39, v40, v41, v42);\n\tv121 = DG.Tweening.Core.TweenManager;\nL_0054:\n\tv124 = ~v122.hasActiveDefaultTweens;\n\tif (v124) goto L_0080;\n\tgoto L_005F;\n\tv161 = \"il2cpp_codegen_runtime_class_init\"(v127, methodInfo, v29, v30, v31, v32, v33, v34, v98, v51, v37, v38, v39, v40, v41, v42);\n\tv163 = DG.Tweening.DOTween;\nL_005F:\n\tv166 = ~v164.useSmoothDeltaTime;\n\tif (v166) goto L_0065;\n\tv182 = UnityEngine.Time::get_smoothDeltaTime();\n\tgoto L_006B;\nL_0065:\n\tv182 = UnityEngine.Time::get_deltaTime();\nL_006B:\n\tgoto L_0076;\n\tv242 = \"il2cpp_codegen_runtime_class_init\"(v184, methodInfo, v29, v30, v31, v32, v33, v34, v182, v51, v37, v38, v39, v40, v41, v42);\n\tv244 = DG.Tweening.DOTween;\nL_0076:\n\tgoto L_0079;\n\tv249 = v155;\n\tv250 = \"il2cpp_codegen_runtime_class_init\"(v249, methodInfo, v29, v30, v31, v32, v33, v34, v182, v51, v37, v38, v39, v40, v41, v42);\nL_0079:\n\tv252 = this._unscaledDeltaTime * v145.unscaledTimeScale;\n\tv147 = v182 * v145.timeScale;\n\tv149 = v145.timeScale * v252;\n\tDG.Tweening.Core.TweenManager::Update(0, v147, v149);\nL_0080:\n\tv157 = UnityEngine.Time::get_realtimeSinceStartup();\n\tthis._unscaledTime = v157;\n\tgoto L_008B;\n\tv176 = \"il2cpp_codegen_runtime_class_init\"(v167, v140, v29, v30, v31, v32, v33, v34, v157, v148, v37, v38, v39, v40, v41, v42);\n\tv178 = DG.Tweening.Core.TweenManager;\nL_008B:\n\tv181 = ~v179.isUnityEditor;\n\tif (v181) goto L_0113;\n\tv189 = this.inspectorUpdater + 1;\n\tthis.inspectorUpdater = v189;\n\tgoto L_0099;\n\tv246 = \"il2cpp_codegen_runtime_class_init\"(v190, v140, v29, v30, v31, v32, v33, v34, v157, v148, v37, v38, v39, v40, v41, v42);\n\tv247 = DG.Tweening.DOTween;\nL_0099:\n\tv223 = ~v248.showUnityEditorReport;\n\tif (v223) goto L_0113;\n\tgoto L_00A4;\n\tv257 = \"il2cpp_codegen_runtime_class_init\"(v253, v140, v29, v30, v31, v32, v33, v34, v157, v148, v37, v38, v39, v40, v41, v42);\n\tv258 = DG.Tweening.Core.TweenManager;\nL_00A4:\n\tv224 = ~v232.hasActiveTweens;\n\tif (v224) goto L_0113;\n\tgoto L_00B2;\n\tv262 = \"il2cpp_codegen_runtime_class_init\"(v219, v140, v29, v30, v31, v32, v33, v34, v157, v148, v37, v38, v39, v40, v41, v42);\n\tv271 = DG.Tweening.Core.TweenManager;\n\tv265 = *([v271 @ X8_v41+B8]);\nL_00B2:\n\tgoto L_00C2;\n\tv272 = \"il2cpp_codegen_runtime_class_init\"(v266, v140, v29, v30, v31, v32, v33, v34, v157, v148, v37, v38, v39, v40, v41, v42);\n\tv274 = DG.Tweening.DOTween;\nL_00C2:\n\tv288 = v264.totActiveTweeners <= v275.maxActiveTweenersReached;\n\tif (v288) goto L_00DB;\n\tgoto L_00D2;\n\tv307 = v289;\n\tv308 = \"il2cpp_codegen_runtime_class_init\"(v307, v140, v29, v30, v31, v32, v33, v34, v157, v148, v37, v38, v39, v40, v41, v42);\n\tv312 = DG.Tweening.Core.TweenManager;\n\tv310 = DG.Tweening.DOTween;\nL_00D2:\n\tgoto L_00D6;\n\tv323 = \"il2cpp_codegen_runtime_class_init\"(v309, v140, v29, v30, v31, v32, v33, v34, v157, v148, v37, v38, v39, v40, v41, v42);\n\tv324 = DG.Tweening.DOTween;\nL_00D6:\n\tv302.maxActiveTweenersReached = v313.totActiveTweeners;\nL_00DB:\n\tgoto L_00E5;\n\tv315 = v303;\n\tv316 = \"il2cpp_codegen_runtime_class_init\"(v315, v140, v29, v30, v31, v32, v33, v34, v157, v148, v37, v38, v39, v40, v41, v42);\n\tv320 = DG.Tweening.Core.TweenManager;\n\tv318 = DG.Tweening.DOTween;\nL_00E5:\n\tgoto L_00F5;\n\tv325 = \"il2cpp_codegen_runtime_class_init\"(v317, v140, v29, v30, v31, v32, v33, v34, v157, v148, v37, v38, v39, v40, v41, v42);\n\tv326 = DG.Tweening.DOTween;\nL_00F5:\n\tv195 = v321.totActiveSequences <= v327.maxActiveSequencesReached;\n\tif (v195) goto L_0113;\n\tgoto L_0105;\n\tv335 = v331;\n\tv336 = \"il2cpp_codegen_runtime_class_init\"(v335, v140, v29, v30, v31, v32, v33, v34, v157, v148, v37, v38, v39, v40, v41, v42);\n\tv340 = DG.Tweening.Core.TweenManager;\n\tv338 = DG.Tweening.DOTween;\nL_0105:\n\tgoto L_0109;\n\tv343 = \"il2cpp_codegen_runtime_class_init\"(v337, v140, v29, v30, v31, v32, v33, v34, v157, v148, v37, v38, v39, v40, v41, v42);\n\tv344 = DG.Tweening.DOTween;\nL_0109:\n\tv230.maxActiveSequencesReached = v341.totActiveSequences;\nL_0113:\n\treturn;\n// 169 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
				float num2 = _unscaledDeltaTime * DOTween.unscaledTimeScale;
				float deltaTime = num * DOTween.timeScale;
				float independentTime = DOTween.timeScale * num2;
				TweenManager.Update(default(UpdateType), deltaTime, independentTime);
			}
			float realtimeSinceStartup2 = Time.realtimeSinceStartup;
			_unscaledTime = realtimeSinceStartup2;
			if (!TweenManager.isUnityEditor)
			{
				return;
			}
			int num3 = inspectorUpdater + 1;
			inspectorUpdater = num3;
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

		[Token(Token = "0x60003E3")]
		[Address(RVA = "0xC2CA4C", Offset = "0xC2CA4C", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv26 = DG.Tweening.DOTween;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv52 = DG.Tweening.Core.TweenManager;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A357D3]) = v46;\nL_001E:\n\tgoto L_0023;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv55 = DG.Tweening.Core.TweenManager;\nL_0023:\n\tv58 = ~v56.hasActiveLateTweens;\n\tif (v58) goto L_003E;\n\tgoto L_0030;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v61, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv75 = DG.Tweening.DOTween;\nL_0030:\n\tv78 = ~v76.useSmoothDeltaTime;\n\tif (v78) goto L_0040;\n\tv117 = UnityEngine.Time::get_smoothDeltaTime();\n\tgoto L_0046;\nL_003E:\n\treturn;\nL_0040:\n\tv117 = UnityEngine.Time::get_deltaTime();\nL_0046:\n\tgoto L_0051;\n\tv124 = \"il2cpp_codegen_runtime_class_init\"(v119, methodInfo, v29, v30, v31, v32, v33, v34, v117, v36, v37, v38, v39, v40, v41, v42);\n\tv126 = DG.Tweening.DOTween;\nL_0051:\n\tgoto L_0054;\n\tv131 = v108;\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v131, methodInfo, v29, v30, v31, v32, v33, v34, v117, v36, v37, v38, v39, v40, v41, v42);\nL_0054:\n\tv134 = this._unscaledDeltaTime * v84.unscaledTimeScale;\n\tv100 = v117 * v84.timeScale;\n\tv88 = v84.timeScale * v134;\n\tDG.Tweening.Core.TweenManager::Update(1, v100, v88);\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void LateUpdate()
		{
			if (TweenManager.hasActiveLateTweens)
			{
				float num = ((!DOTween.useSmoothDeltaTime) ? Time.deltaTime : Time.smoothDeltaTime);
				float num2 = _unscaledDeltaTime * DOTween.unscaledTimeScale;
				float deltaTime = num * DOTween.timeScale;
				float independentTime = DOTween.timeScale * num2;
				TweenManager.Update(UpdateType.Late, deltaTime, independentTime);
			}
		}

		[Token(Token = "0x60003E4")]
		[Address(RVA = "0xC2CB64", Offset = "0xC2CB64", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv26 = DG.Tweening.DOTween;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv53 = DG.Tweening.Core.TweenManager;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv47 = 1;\n\t*([1A357D4]) = v47;\nL_001E:\n\tgoto L_0023;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv56 = DG.Tweening.Core.TweenManager;\nL_0023:\n\tv59 = ~v57.hasActiveFixedTweens;\n\tif (v59) goto L_004E;\n\tv61 = UnityEngine.Time::get_timeScale();\n\tv64 = v61 <= 0;\n\tif (v64) goto L_004E;\n\tgoto L_003F;\n\tv154 = \"il2cpp_codegen_runtime_class_init\"(v150, methodInfo, v29, v30, v31, v32, v33, v34, v61, v36, v37, v38, v39, v40, v41, v42);\n\tv156 = DG.Tweening.DOTween;\nL_003F:\n\tv159 = ~v157.useSmoothDeltaTime;\n\tif (v159) goto L_0050;\n\tv164 = UnityEngine.Time::get_smoothDeltaTime();\n\tgoto L_0056;\nL_004E:\n\treturn;\nL_0050:\n\tv164 = UnityEngine.Time::get_deltaTime();\nL_0056:\n\tgoto L_005D;\n\tv171 = \"il2cpp_codegen_runtime_class_init\"(v166, methodInfo, v29, v30, v31, v32, v33, v34, v164, v36, v37, v38, v39, v40, v41, v42);\n\tv173 = DG.Tweening.DOTween;\nL_005D:\n\tv178 = ~v174.useSmoothDeltaTime;\n\tif (v178) goto L_0061;\n\tv181 = UnityEngine.Time::get_smoothDeltaTime();\n\tgoto L_0064;\nL_0061:\n\tv181 = UnityEngine.Time::get_deltaTime();\nL_0064:\n\tv184 = UnityEngine.Time::get_timeScale();\n\tgoto L_006F;\n\tv190 = \"il2cpp_codegen_runtime_class_init\"(v185, methodInfo, v29, v30, v31, v32, v33, v34, v184, v36, v37, v38, v39, v40, v41, v42);\n\tv192 = DG.Tweening.DOTween;\nL_006F:\n\tv193 = v164 * v174.timeScale;\n\tgoto L_0078;\n\tv197 = v143;\n\tv198 = \"il2cpp_codegen_runtime_class_init\"(v197, methodInfo, v29, v30, v31, v32, v33, v34, v184, v36, v37, v38, v39, v40, v41, v42);\nL_0078:\n\tv200 = v181 / v184;\n\tv201 = v200 * v108.unscaledTimeScale;\n\tv112 = v201 * v108.timeScale;\n\tDG.Tweening.Core.TweenManager::Update(2, v193, v112);\n\treturn;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
					float num4 = num3 * DOTween.unscaledTimeScale;
					float independentTime = num4 * DOTween.timeScale;
					TweenManager.Update(UpdateType.Fixed, deltaTime, independentTime);
				}
			}
		}

		[Token(Token = "0x60003E5")]
		[Address(RVA = "0xC2CCDC", Offset = "0xC2CCDC", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv18 = DG.Tweening.DOTween;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv54 = Il2CppMethodInfo;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv128 = DG.Tweening.Core.TweenManager;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v128, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv39 = 1;\n\t*([1A357D5]) = v39;\nL_0020:\n\tgoto L_0025;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v40, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv49 = DG.Tweening.DOTween;\nL_0025:\n\tv52 = ~v50.drawGizmos;\n\tif (v52) goto L_0077;\n\tgoto L_0032;\n\tv129 = \"il2cpp_codegen_runtime_class_init\"(v58, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv130 = DG.Tweening.Core.TweenManager;\nL_0032:\n\tv115 = ~v131.isUnityEditor;\n\tif (v115) goto L_0077;\n\tgoto L_003C;\n\tv174 = \"il2cpp_codegen_runtime_class_init\"(v170, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv175 = DG.Tweening.DOTween;\nL_003C:\n\tv177 = v176.GizmosDelegates;\n\tv75 = v177._size - 1;\n\tv73 = v177._size < 1;\n\tif (v73) goto L_0077;\nL_0053:\n\tgoto L_005C;\n\tv207 = \"il2cpp_codegen_runtime_class_init\"(v199, v182, v183, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv209 = DG.Tweening.DOTween;\nL_005C:\n\tv193 = System.Collections.Generic.List`1<DG.Tweening.TweenCallback>::get_Item(v196.GizmosDelegates, v121);\n\tDG.Tweening.TweenCallback::Invoke(v193);\n\tv95 = v75 == v121;\n\tif (v95) goto L_0077;\n\tv121 = v121 + 1;\n\tgoto L_0053;\nL_0077:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDrawGizmos()
		{
			if (!DOTween.drawGizmos || !TweenManager.isUnityEditor)
			{
				return;
			}
			List<TweenCallback> gizmosDelegates = DOTween.GizmosDelegates;
			int num = gizmosDelegates.Count - 1;
			if (gizmosDelegates.Count < 1)
			{
				return;
			}
			int num2 = 0;
			while (true)
			{
				TweenCallback tweenCallback = DOTween.GizmosDelegates[num2];
				tweenCallback();
				if (num != num2)
				{
					num2++;
					continue;
				}
				break;
			}
		}

		[Token(Token = "0x60003E6")]
		[Address(RVA = "0xC2CE1C", Offset = "0xC2CE1C", Length = "0x474")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\n\tv16 = DG.Tweening.DOTween;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv42 = System.Int32;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv112 = UnityEngine.Object;\n\tv113 = \"il2cpp_codegen_initialize_runtime_metadata\"(v112, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv121 = \" startup errors\";\n\tv122 = \"il2cpp_codegen_initialize_runtime_metadata\"(v121, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv147 = \" errors inside callbacks (these might be important)\";\n\tv148 = \"il2cpp_codegen_initialize_runtime_metadata\"(v147, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv163 = \"\\n- \";\n\tv164 = \"il2cpp_codegen_initialize_runtime_metadata\"(v163, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv229 = \"Max overall simultaneous active Tweeners/Sequences: \";\n\tv230 = \"il2cpp_codegen_initialize_runtime_metadata\"(v229, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv250 = \" undetermined errors (these might be important)\";\n\tv251 = \"il2cpp_codegen_initialize_runtime_metadata\"(v250, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv263 = \"/\";\n\tv264 = \"il2cpp_codegen_initialize_runtime_metadata\"(v263, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv275 = \" missing target or field errors\";\n\tv276 = \"il2cpp_codegen_initialize_runtime_metadata\"(v275, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv295 = \"DOTween's safe mode captured {0} errors. This is usually ok (it's what safe mode is there for) but if your game is encountering issues you should set Log Behaviour to Default in DOTween Utility Panel in order to get detailed warnings when an error is captured (consider that these errors are always on the user side).\";\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v295, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 1;\n\t*([1A357D6]) = v36;\nL_0031:\n\tv39 = ~this._duplicateToDestroy;\n\tv40 = ~v39;\n\tif (v40) goto L_0184;\n\tgoto L_003D;\n\tv114 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv116 = DG.Tweening.DOTween;\nL_003D:\n\tv151 = *([v157 @ X0_v6 (Il2CppClass<DG.Tweening.DOTween>)+B8]);\n\tv119 = ~v151.showUnityEditorReport;\n\tif (v119) goto L_0061;\n\tgoto L_0048;\n\tv149 = \"il2cpp_codegen_runtime_class_init\"(v115, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv165 = DG.Tweening.DOTween;\n\tv152 = *([v165 @ X8_v70+B8]);\nL_0048:\n\tv153 = v151 + 0x6C;\n\tv155 = System.Int32::ToString(v153);\n\tv169 = v166.Version + 0x70;\n\tv170 = System.Int32::ToString(v169);\n\tv235 = System.String::Concat(\"Max overall simultaneous active Tweeners/Sequences: \", v155, \"/\", v170);\n\tDG.Tweening.Core.Debugger::LogReport(v235);\nL_0061:\n\tgoto L_0064;\n\tv156 = \"il2cpp_codegen_runtime_class_init\"(v136, v132, v128, v130, v126, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv158 = DG.Tweening.DOTween;\nL_0064:\n\tv221 = *([v157 @ X0_v6 (Il2CppClass<DG.Tweening.DOTween>)+B8]);\n\tv161 = ~v221.useSafeMode;\n\tif (v161) goto L_014B;\n\tgoto L_006F;\n\tv236 = \"il2cpp_codegen_runtime_class_init\"(v157, v132, v128, v130, v126, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv252 = DG.Tweening.DOTween;\n\tv238 = *([v252 @ X8_v62+B8]);\nL_006F:\n\tv239 = v221 + 0x74;\n\tv216 = DG.Tweening.Core.SafeModeReport::GetTotErrors(v239);\n\tv180 = v216 < 1;\n\tif (v180) goto L_014B;\n\t// 132 Box v270 @ X0_v29 (System.Object), typeof(System.Int32), &v216 @ X0_v27 (System.Int32)\n\tv283 = System.String::Format(\"DOTween's safe mode captured {0} errors. This is usually ok (it's what safe mode is there for) but if your game is encountering issues you should set Log Behaviour to Default in DOTween Utility Panel in order to get detailed warnings when an error is captured (consider that these errors are always on the user side).\", v270);\n\tgoto L_00A1;\n\tv308 = v296;\n\tv309 = \"il2cpp_codegen_runtime_class_init\"(v308, v279, v280, v130, v126, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv312 = DG.Tweening.DOTween;\nL_00A1:\n\tv325 = v313.safeModeReport < 1;\n\tif (v325) goto L_00BF;\n\tgoto L_00AF;\n\tv352 = v311;\n\tv353 = \"il2cpp_codegen_runtime_class_init\"(v352, v279, v280, v130, v126, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv380 = DG.Tweening.DOTween;\n\tv358 = *([v380 @ X8_v59+B8]);\n\tv355 = *([v358 @ X8_v60+74]);\nL_00AF:\n\tv361 = System.Int32::ToString(&v354 @ X9_v40 (System.Int32));\n\tv343 = System.String::Concat(v283, \"\\n- \", v361, \" missing target or field errors\");\nL_00BF:\n\tgoto L_00C3;\n\tv362 = v345;\n\tv363 = \"il2cpp_codegen_runtime_class_init\"(v362, v338, v334, v336, v332, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv366 = DG.Tweening.DOTween;\nL_00C3:\n\tv367 = *([v483 @ X8_v33 (Il2CppClass<DG.Tweening.DOTween>)+B8]);\n\tv413 = *([v367 @ X9_v17 (Il2CppStaticFields<DG.Tweening.DOTween>)+7C]);\n\tv379 = *([v367 @ X9_v17 (Il2CppStaticFields<DG.Tweening.DOTween>)+7C]) < 1;\n\tif (v379) goto L_00ED;\n\tgoto L_00DD;\n\tv411 = v365;\n\tv412 = \"il2cpp_codegen_runtime_class_init\"(v411, v338, v334, v336, v332, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv439 = DG.Tweening.DOTween;\n\tv417 = *([v439 @ X8_v52+B8]);\n\tv414 = *([v417 @ X8_v53+7C]);\nL_00DD:\n\tv420 = System.Int32::ToString(&v413 @ X9_v36 (System.Int32));\n\tv402 = System.String::Concat(v223, \"\\n- \", v420, \" startup errors\");\nL_00ED:\n\tgoto L_00F1;\n\tv421 = v404;\n\tv422 = \"il2cpp_codegen_runtime_class_init\"(v421, v397, v393, v395, v391, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv425 = DG.Tweening.DOTween;\nL_00F1:\n\tv426 = *([v483 @ X8_v33 (Il2CppClass<DG.Tweening.DOTween>)+B8]);\n\tv472 = *([v426 @ X9_v21 (Il2CppStaticFields<DG.Tweening.DOTween>)+78]);\n\tv438 = *([v426 @ X9_v21 (Il2CppStaticFields<DG.Tweening.DOTween>)+78]) < 1;\n\tif (v438) goto L_011B;\n\tgoto L_010B;\n\tv470 = v424;\n\tv471 = \"il2cpp_codegen_runtime_class_init\"(v470, v397, v393, v395, v391, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv489 = DG.Tweening.DOTween;\n\tv476 = *([v489 @ X8_v45+B8]);\n\tv473 = *([v476 @ X8_v46+78]);\nL_010B:\n\tv479 = System.Int32::ToString(&v472 @ X9_v32 (System.Int32));\n\tv461 = System.String::Concat(v223, \"\\n- \", v479, \" errors inside callbacks (these might be important)\");\nL_011B:\n\tgoto L_011F;\n\tv480 = v463;\n\tv481 = \"il2cpp_codegen_runtime_class_init\"(v480, v456, v452, v454, v450, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv484 = DG.Tweening.DOTween;\nL_011F:\n\tv485 = *([v483 @ X8_v33 (Il2CppClass<DG.Tweening.DOTween>)+B8]);\n\tv509 = *([v485 @ X9_v25 (Il2CppStaticFields<DG.Tweening.DOTween>)+80]);\n\tv179 = *([v485 @ X9_v25 (Il2CppStaticFields<DG.Tweening.DOTween>)+80]) < 1;\n\tif (v179) goto L_0146;\n\tgoto L_0139;\n\tv507 = v483;\n\tv508 = \"il2cpp_codegen_runtime_class_init\"(v507, v456, v452, v454, v450, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv517 = DG.Tweening.DOTween;\n\tv513 = *([v517 @ X8_v38+B8]);\n\tv510 = *([v513 @ X8_v39+80]);\nL_0139:\n\tv516 = System.Int32::ToString(&v509 @ X9_v28 (System.Int32));\n\tv504 = System.String::Concat(v223, \"\\n- \", v516, \" undetermined errors (these might be important)\");\nL_0146:\n\tDG.Tweening.Core.Debugger::LogSafeModeReport(v223);\nL_014B:\n\tgoto L_0156;\n\tv240 = \"il2cpp_codegen_runtime_class_init\"(v224, v209, v206, v90, v86, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv242 = DG.Tweening.DOTween;\nL_0156:\n\tgoto L_015C;\n\tv255 = v246;\n\tv256 = \"il2cpp_codegen_runtime_class_init\"(v255, v209, v206, v90, v86, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_015C:\n\tv261 = UnityEngine.Object::op_Equality(v245.instance, this);\n\tv273 = v261 == 0;\n\tif (v273) goto L_016E;\n\tgoto L_0169;\n\tv301 = v271;\n\tv302 = \"il2cpp_codegen_runtime_class_init\"(v301, v259, v260, v90, v86, v22, v2\n// ... truncated")]
		private unsafe void OnDestroy()
		{
			//IL_0013: Expected I, but got O
			//IL_0129: Expected I, but got O
			//IL_01a6: Expected I, but got O
			//IL_0036: Expected I, but got O
			//IL_01cf: Expected O, but got I
			//IL_0072: Expected I, but got O
			//IL_026d: Expected I, but got O
			//IL_0080: Expected I4, but got O
			//IL_0257: Expected I, but got O
			//IL_02ef: Expected I, but got O
			//IL_02d9: Expected I, but got O
			//IL_0371: Expected I, but got O
			//IL_035b: Expected I, but got O
			if (_duplicateToDestroy)
			{
				return;
			}
			nint num = (nint)typeof(DOTween);
			nint num2 = (nint)DOTween.Version;
			if (DOTween.showUnityEditorReport)
			{
				int num3 = (int)(num2 + 108);
				string text = ((int*)num3)->ToString();
				int num4 = (int)((nint)DOTween.Version + 112);
				string text2 = ((int*)num4)->ToString();
				string message = "Max overall simultaneous active Tweeners/Sequences: " + text + "/" + text2;
				Debugger.LogReport(message);
				num = (nint)typeof(DOTween);
			}
			nint num5 = (nint)DOTween.Version;
			if (DOTween.useSafeMode)
			{
				SafeModeReport safeModeReport = (SafeModeReport)(num5 + 116);
				int totErrors = ((SafeModeReport*)safeModeReport)->GetTotErrors();
				if (totErrors >= 1)
				{
					object arg = totErrors;
					string text3 = $"DOTween's safe mode captured {arg} errors. This is usually ok (it's what safe mode is there for) but if your game is encountering issues you should set Log Behaviour to Default in DOTween Utility Panel in order to get detailed warnings when an error is captured (consider that these errors are always on the user side).";
					nint num6 = (nint)typeof(DOTween);
					bool flag = (nint)DOTween.safeModeReport < 1;
					string text4 = text3;
					if (!flag)
					{
						string text5 = ((int)DOTween.safeModeReport).ToString();
						string text6 = text3 + "\n- " + text5 + " missing target or field errors";
						num6 = (nint)typeof(DOTween);
						text4 = text6;
					}
					nint num7 = (nint)DOTween.Version;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ X9_v17 (Il2CppStaticFields<DG.Tweening.DOTween>)+7C]");
					int num8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ X9_v17 (Il2CppStaticFields<DG.Tweening.DOTween>)+7C]");
					if ((nint)0 >= (nint)1)
					{
						string text7 = num8.ToString();
						string text8 = text4 + "\n- " + text7 + " startup errors";
						num6 = (nint)typeof(DOTween);
						text4 = text8;
					}
					nint num9 = (nint)DOTween.Version;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v426 @ X9_v21 (Il2CppStaticFields<DG.Tweening.DOTween>)+78]");
					int num10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v426 @ X9_v21 (Il2CppStaticFields<DG.Tweening.DOTween>)+78]");
					if ((nint)0 >= (nint)1)
					{
						string text9 = num10.ToString();
						string text10 = text4 + "\n- " + text9 + " errors inside callbacks (these might be important)";
						num6 = (nint)typeof(DOTween);
						text4 = text10;
					}
					nint num11 = (nint)DOTween.Version;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ X9_v25 (Il2CppStaticFields<DG.Tweening.DOTween>)+80]");
					int num12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ X9_v25 (Il2CppStaticFields<DG.Tweening.DOTween>)+80]");
					if ((nint)0 >= (nint)1)
					{
						string text11 = num12.ToString();
						string text12 = text4 + "\n- " + text11 + " undetermined errors (these might be important)";
						text4 = text12;
					}
					Debugger.LogSafeModeReport(text4);
				}
			}
			if (DOTween.instance == this)
			{
				DOTween.instance = null;
			}
			bool flag2 = !_isQuitting;
			bool isApplicationQuitting = !flag2;
			DOTween.Clear(destroy: true, isApplicationQuitting);
		}

		[Token(Token = "0x60003E7")]
		[Address(RVA = "0xC2D290", Offset = "0xC2D290", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = pauseStatus == 0;\n\tif (v10) goto L_000F;\n\tthis._paused = 1;\n\tv13 = UnityEngine.Time::get_realtimeSinceStartup();\n\tthis._pausedTime = v13;\n\tgoto L_001D;\nL_000F:\n\tv15 = ~this._paused;\n\tif (v15) goto L_001D;\n\tthis._paused = 0;\n\tv18 = UnityEngine.Time::get_realtimeSinceStartup();\n\tv32 = v18 - this._pausedTime;\n\tv24 = this._unscaledTime + v32;\n\tthis._unscaledTime = v24;\nL_001D:\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnApplicationPause(bool pauseStatus)
		{
			if (pauseStatus)
			{
				_paused = true;
				float realtimeSinceStartup = Time.realtimeSinceStartup;
				_pausedTime = realtimeSinceStartup;
			}
			else if (_paused)
			{
				_paused = false;
				float realtimeSinceStartup2 = Time.realtimeSinceStartup;
				float num = realtimeSinceStartup2 - _pausedTime;
				float unscaledTime = _unscaledTime + num;
				_unscaledTime = unscaledTime;
			}
		}

		[Token(Token = "0x60003E8")]
		[Address(RVA = "0xC2D2EC", Offset = "0xC2D2EC", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = DG.Tweening.DOTween;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A357D7]) = v37;\nL_0014:\n\tthis._isQuitting = 1;\n\tgoto L_0022;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0022:\n\tDG.Tweening.DOTween::set_isQuitting(1);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnApplicationQuit()
		{
			_isQuitting = true;
			DOTween.isQuitting = true;
		}

		[Token(Token = "0x60003E9")]
		[Address(RVA = "0xC2D34C", Offset = "0xC2D34C", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = DG.Tweening.Core.TweenManager;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, tweenersCapacity, sequencesCapacity, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A357D8]) = v43;\nL_001B:\n\tgoto L_0020;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v44, tweenersCapacity, sequencesCapacity, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0020:\n\tDG.Tweening.Core.TweenManager::SetCapacities(tweenersCapacity, sequencesCapacity);\n\treturn this;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IDOTweenInit SetCapacity(int tweenersCapacity, int sequencesCapacity)
		{
			TweenManager.SetCapacities(tweenersCapacity, sequencesCapacity);
			return this;
		}

		[Token(Token = "0x60003EA")]
		[Address(RVA = "0xC2D3C0", Offset = "0xC2D3C0", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = DG.Tweening.Core.DOTweenComponent+<WaitForCompletion>d__17;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, t, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A357D9]) = v37;\nL_0014:\n\tv39 = new DG.Tweening.Core.DOTweenComponent+<WaitForCompletion>d__17();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0;\n\tv39.t = t;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal IEnumerator WaitForCompletion(Tween t)
		{
			_003CWaitForCompletion_003Ed__17 _003CWaitForCompletion_003Ed__18 = null;
			_003CWaitForCompletion_003Ed__18._003C_003E1__state = 0;
			_003CWaitForCompletion_003Ed__18.t = t;
			return _003CWaitForCompletion_003Ed__18;
		}

		[Token(Token = "0x60003EB")]
		[Address(RVA = "0xC2D448", Offset = "0xC2D448", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = DG.Tweening.Core.DOTweenComponent+<WaitForRewind>d__18;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, t, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A357DA]) = v37;\nL_0014:\n\tv39 = new DG.Tweening.Core.DOTweenComponent+<WaitForRewind>d__18();\n\tDG.Tweening.Core.DOTweenComponent+<WaitForRewind>d__18::.ctor(v39, 0);\n\tv39.t = t;\n\treturn v39;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal IEnumerator WaitForRewind(Tween t)
		{
			while (t.active)
			{
				if (t.playedOnce)
				{
					int num = t.completedLoops + 1;
					float num2 = t.position * (float)num;
					if (!(num2 > 0f))
					{
						break;
					}
				}
				yield return null;
			}
		}

		[Token(Token = "0x60003EC")]
		[Address(RVA = "0xC2D4B0", Offset = "0xC2D4B0", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = DG.Tweening.Core.DOTweenComponent+<WaitForKill>d__19;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, t, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A357DB]) = v37;\nL_0014:\n\tv39 = new DG.Tweening.Core.DOTweenComponent+<WaitForKill>d__19();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0;\n\tv39.t = t;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal IEnumerator WaitForKill(Tween t)
		{
			_003CWaitForKill_003Ed__19 _003CWaitForKill_003Ed__20 = null;
			_003CWaitForKill_003Ed__20._003C_003E1__state = 0;
			_003CWaitForKill_003Ed__20.t = t;
			return _003CWaitForKill_003Ed__20;
		}

		[Token(Token = "0x60003ED")]
		[Address(RVA = "0xC2D538", Offset = "0xC2D538", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = DG.Tweening.Core.DOTweenComponent+<WaitForElapsedLoops>d__20;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, t, elapsedLoops, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A357DC]) = v40;\nL_0016:\n\tv42 = new DG.Tweening.Core.DOTweenComponent+<WaitForElapsedLoops>d__20();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0;\n\tv42.t = t;\n\tv42.elapsedLoops = elapsedLoops;\n\treturn v42;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal IEnumerator WaitForElapsedLoops(Tween t, int elapsedLoops)
		{
			_003CWaitForElapsedLoops_003Ed__20 _003CWaitForElapsedLoops_003Ed__21 = null;
			_003CWaitForElapsedLoops_003Ed__21._003C_003E1__state = 0;
			_003CWaitForElapsedLoops_003Ed__21.t = t;
			_003CWaitForElapsedLoops_003Ed__21.elapsedLoops = elapsedLoops;
			return _003CWaitForElapsedLoops_003Ed__21;
		}

		[Token(Token = "0x60003EE")]
		[Address(RVA = "0xC2D5D0", Offset = "0xC2D5D0", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = DG.Tweening.Core.DOTweenComponent+<WaitForPosition>d__21;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, t, methodInfo, v25, v26, v27, v28, v29, position, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A357DD]) = v40;\nL_0016:\n\tv42 = new DG.Tweening.Core.DOTweenComponent+<WaitForPosition>d__21();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0;\n\tv42.t = t;\n\tv42.position = position;\n\treturn v42;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal IEnumerator WaitForPosition(Tween t, float position)
		{
			_003CWaitForPosition_003Ed__21 _003CWaitForPosition_003Ed__22 = null;
			_003CWaitForPosition_003Ed__22._003C_003E1__state = 0;
			_003CWaitForPosition_003Ed__22.t = t;
			_003CWaitForPosition_003Ed__22.position = position;
			return _003CWaitForPosition_003Ed__22;
		}

		[Token(Token = "0x60003EF")]
		[Address(RVA = "0xC2D668", Offset = "0xC2D668", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = DG.Tweening.Core.DOTweenComponent+<WaitForStart>d__22;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, t, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A357DE]) = v37;\nL_0014:\n\tv39 = new DG.Tweening.Core.DOTweenComponent+<WaitForStart>d__22();\n\tDG.Tweening.Core.DOTweenComponent+<WaitForStart>d__22::.ctor(v39, 0);\n\tv39.t = t;\n\treturn v39;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal IEnumerator WaitForStart(Tween t)
		{
			while (t.active && !t.playedOnce)
			{
				yield return null;
			}
		}

		[Token(Token = "0x60003F0")]
		[Address(RVA = "0xC2D6D0", Offset = "0xC2D6D0", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv16 = DG.Tweening.DOTween;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv57 = UnityEngine.GameObject;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv67 = UnityEngine.Object;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv73 = \"[DOTween]\";\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v73, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv37 = 1;\n\t*([1A357DF]) = v37;\nL_0024:\n\tgoto L_002D;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v38, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv49 = DG.Tweening.DOTween;\nL_002D:\n\tgoto L_0033;\n\tv59 = v50;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v59, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0033:\n\tv65 = UnityEngine.Object::op_Inequality(v51.instance, 0);\n\tv70 = v65 == 0;\n\tv71 = ~v70;\n\tif (v71) goto L_0062;\n\tv77 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v77, \"[DOTween]\");\n\tgoto L_004A;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v114, v99, v81, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_004A:\n\tUnityEngine.Object::DontDestroyOnLoad(v77);\n\tv109 = v77 == 0;\n\tif (v109) goto L_0063;\n\tv123 = UnityEngine.GameObject::AddComponent(v77);\n\tgoto L_005C;\n\tv126 = v124;\n\tv127 = \"il2cpp_codegen_runtime_class_init\"(v126, v83, v81, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv129 = DG.Tweening.DOTween;\nL_005C:\n\tv89.instance = v123;\nL_0062:\n\treturn;\nL_0063:\n\tthrow v77;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void Create()
		{
			if (!(DOTween.instance != null))
			{
				GameObject gameObject = new GameObject("[DOTween]");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				if ((object)gameObject == null)
				{
					throw gameObject;
				}
				DOTweenComponent instance = gameObject.AddComponent<DOTweenComponent>();
				DOTween.instance = instance;
			}
		}

		[Token(Token = "0x60003F1")]
		[Address(RVA = "0xC2D80C", Offset = "0xC2D80C", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv16 = DG.Tweening.DOTween;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv45 = UnityEngine.Object;\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv37 = 1;\n\t*([1A357E0]) = v37;\nL_001B:\n\tgoto L_0024;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv48 = DG.Tweening.DOTween;\nL_0024:\n\tgoto L_002A;\n\tv55 = v49;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v55, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_002A:\n\tv61 = UnityEngine.Object::op_Inequality(v50.instance, 0);\n\tv63 = v61 == 0;\n\tif (v63) goto L_004A;\n\tgoto L_003A;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v64, v59, v60, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv86 = DG.Tweening.DOTween;\nL_003A:\n\tv99 = UnityEngine.Component::get_gameObject(v87.instance);\n\tgoto L_0045;\n\tv111 = v77;\n\tv112 = \"il2cpp_codegen_runtime_class_init\"(v111, v98, v60, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0045:\n\tUnityEngine.Object::Destroy(v99);\nL_004A:\n\tgoto L_0050;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v80, v70, v60, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv92 = DG.Tweening.DOTween;\nL_0050:\n\tv93.instance = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void DestroyInstance()
		{
			if (DOTween.instance != null)
			{
				GameObject obj = DOTween.instance.gameObject;
				UnityEngine.Object.Destroy(obj);
			}
			DOTween.instance = null;
		}

		[Token(Token = "0x60003F2")]
		[Address(RVA = "0xC2D90C", Offset = "0xC2D90C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenComponent()
		{
		}
	}
}
