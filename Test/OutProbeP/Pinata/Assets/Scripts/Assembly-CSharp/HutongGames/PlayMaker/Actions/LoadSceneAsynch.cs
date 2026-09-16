using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75CF20", Offset = "0x75CF20")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75CF20", Offset = "0x75CF20")]
	[Token(Token = "0x2000336")]
	public class LoadSceneAsynch : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C751C", Offset = "0x7C751C")]
		[Token(Token = "0x4001A62")]
		[FieldOffset(Offset = "0x4C")]
		public GetSceneActionBase.SceneSimpleReferenceOptions sceneReference;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C7554", Offset = "0x7C7554")]
		[Token(Token = "0x4001A63")]
		[FieldOffset(Offset = "0x50")]
		public FsmString sceneByName;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C758C", Offset = "0x7C758C")]
		[Token(Token = "0x4001A64")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt sceneAtIndex;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C75C4", Offset = "0x7C75C4")]
		[AttributeAttribute(Type = typeof(ObjectTypeAttribute), RVA = "0x7C75C4", Offset = "0x7C75C4")]
		[Token(Token = "0x4001A65")]
		[FieldOffset(Offset = "0x60")]
		public FsmEnum loadSceneMode;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C764C", Offset = "0x7C764C")]
		[Token(Token = "0x4001A66")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool allowSceneActivation;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C7684", Offset = "0x7C7684")]
		[Token(Token = "0x4001A67")]
		[FieldOffset(Offset = "0x70")]
		public FsmInt operationPriority;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7C76BC", Offset = "0x7C76BC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C76BC", Offset = "0x7C76BC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C76BC", Offset = "0x7C76BC")]
		[Token(Token = "0x4001A68")]
		[FieldOffset(Offset = "0x78")]
		public FsmInt aSyncOperationHashCode;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C7730", Offset = "0x7C7730")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C7730", Offset = "0x7C7730")]
		[Token(Token = "0x4001A69")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat progress;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C7780", Offset = "0x7C7780")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C7780", Offset = "0x7C7780")]
		[Token(Token = "0x4001A6A")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool isDone;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C77D0", Offset = "0x7C77D0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C77D0", Offset = "0x7C77D0")]
		[Token(Token = "0x4001A6B")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool pendingActivation;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C7820", Offset = "0x7C7820")]
		[Token(Token = "0x4001A6C")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent doneEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C7858", Offset = "0x7C7858")]
		[Token(Token = "0x4001A6D")]
		[FieldOffset(Offset = "0xA0")]
		public FsmEvent pendingActivationEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C7890", Offset = "0x7C7890")]
		[Token(Token = "0x4001A6E")]
		[FieldOffset(Offset = "0xA8")]
		public FsmEvent sceneNotFoundEvent;

		[Token(Token = "0x4001A6F")]
		[FieldOffset(Offset = "0xB0")]
		private AsyncOperation _asyncOperation;

		[Token(Token = "0x4001A70")]
		[FieldOffset(Offset = "0xB8")]
		private int _asynchOperationUid;

		[Token(Token = "0x4001A71")]
		[FieldOffset(Offset = "0xBC")]
		private bool pendingActivationCallBackDone;

		[Token(Token = "0x4001A72")]
		public static Dictionary<int, AsyncOperation> aSyncOperationLUT;

		[Token(Token = "0x4001A73")]
		private static int aSynchUidCounter;

		[Token(Token = "0x6001011")]
		[Address(RVA = "0xA3A794", Offset = "0xA3A794", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EBCB40]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E44]) = v38;\nL_0014:\n\tthis.aSyncOperationHashCode = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.LoadSceneAsynch)+6C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.LoadSceneAsynch)+5C]) = 0;\n\tthis.sceneReference = 0;\n\tv43 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v43);\n\tv43.useVariable = 1;\n\tthis.operationPriority = v43;\n\tthis.pendingActivation = 0;\n\tthis.pendingActivationEvent = 0;\n\tthis.progress = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			aSyncOperationHashCode = null;
			_ = 0;
			_ = 0;
			sceneReference = default(GetSceneActionBase.SceneSimpleReferenceOptions);
			FsmInt fsmInt = new FsmInt();
			fsmInt.useVariable = true;
			operationPriority = fsmInt;
			pendingActivation = null;
			pendingActivationEvent = null;
			progress = null;
		}

		[Token(Token = "0x6001012")]
		[Address(RVA = "0xA3A828", Offset = "0xA3A828", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.pendingActivation;\n\tthis.pendingActivationCallBackDone = 0;\n\tv10.value = 0;\n\tv12 = this.isDone;\n\tv12.value = 0;\n\tv17 = this.progress;\n\tv17.value = 0f;\n\tv41 = HutongGames.PlayMaker.Actions.LoadSceneAsynch::DoLoadAsynch(this);\n\tv43 = v41 == 0;\n\tif (v43) goto L_0022;\n\treturn;\nL_0022:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sceneNotFoundEvent);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmBool fsmBool = pendingActivation;
			pendingActivationCallBackDone = false;
			fsmBool.value = false;
			FsmBool fsmBool2 = isDone;
			fsmBool2.value = false;
			FsmFloat fsmFloat = progress;
			fsmFloat.Value = 0f;
			if (!DoLoadAsynch())
			{
				Fsm.Event(sceneNotFoundEvent);
				Finish();
			}
		}

		[Token(Token = "0x6001013")]
		[Address(RVA = "0xA3A8A8", Offset = "0xA3A8A8", Length = "0x2EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EC0598]);\n\tv21 = *([v20 @ X8_v45]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021E45]) = v40;\nL_0016:\n\tv43 = UnityEngine.SceneManagement.SceneManager::GetActiveScene();\n\tv47 = this.sceneReference == 0;\n\tif (v47) goto L_0051;\n\tv48 = 0x10D454C(&v43 @ X0_v3 (UnityEngine.SceneManagement.Scene), 0, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv58 = HutongGames.PlayMaker.FsmString::get_Value(this.sceneByName);\n\tv145 = System.String::op_Equality(v48, v58);\n\tv189 = v145 == 0;\n\tv190 = ~v189;\n\tif (v190) goto L_FFFFFFFF;\n\tv114 = HutongGames.PlayMaker.FsmString::get_Value(this.sceneByName);\n\tv166 = HutongGames.PlayMaker.FsmEnum::get_Value(this.loadSceneMode);\n\tv193 = v193_asT == 0;\n\tif (v193) goto L_0106;\n\tthis = \"il2cpp_vm_object_unbox\"(v166, UnityEngine.SceneManagement.LoadSceneMode, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv116 = UnityEngine.SceneManagement.SceneManager::LoadSceneAsync(v114, *([this @ X0 (HutongGames.PlayMaker.Actions.LoadSceneAsynch)]));\n\tgoto L_008B;\nL_0051:\n\tv49 = 0x10D45CC(&v43 @ X0_v3 (UnityEngine.SceneManagement.Scene), 0, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv142 = HutongGames.PlayMaker.FsmInt::get_Value(this.sceneAtIndex);\n\tv63 = v49 != v142;\n\tif (v63) goto L_006A;\n\tgoto L_0103;\nL_006A:\n\tv115 = HutongGames.PlayMaker.FsmInt::get_Value(this.sceneAtIndex);\n\tv168 = HutongGames.PlayMaker.FsmEnum::get_Value(this.loadSceneMode);\n\tv194 = v194_asT == 0;\n\tif (v194) goto L_0106;\n\tthis = \"il2cpp_vm_object_unbox\"(v168, UnityEngine.SceneManagement.LoadSceneMode, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv116 = UnityEngine.SceneManagement.SceneManager::LoadSceneAsync(v115, *([this @ X0 (HutongGames.PlayMaker.Actions.LoadSceneAsynch)]));\nL_008B:\n\tthis._asyncOperation = v116;\n\tv325 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.operationPriority);\n\tv327 = v325 == 0;\n\tv328 = ~v327;\n\tif (v328) goto L_00A6;\n\tv117 = HutongGames.PlayMaker.FsmInt::get_Value(this.operationPriority);\n\tUnityEngine.AsyncOperation::set_priority(this._asyncOperation, v117);\nL_00A6:\n\tv118 = HutongGames.PlayMaker.FsmBool::get_Value(this.allowSceneActivation);\n\tUnityEngine.AsyncOperation::set_allowSceneActivation(this._asyncOperation, v118);\n\tv336 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.aSyncOperationHashCode);\n\tv338 = v336 == 0;\n\tv339 = ~v338;\n\tif (v339) goto L_FFFFFFFF;\n\tgoto L_00C5;\n\tv350 = *([v341 @ X0_v23 (Il2CppClass<HutongGames.PlayMaker.Actions.LoadSceneAsynch>)+E0]);\n\tv351 = v350 == 0;\n\tv352 = ~v351;\n\tif (v352) goto L_00C5;\n\tv361 = \"il2cpp_codegen_runtime_class_init\"(v341, v335, v105, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv354 = HutongGames.PlayMaker.Actions.LoadSceneAsynch;\nL_00C5:\n\tv359 = v357.aSyncOperationLUT == 0;\n\tv360 = ~v359;\n\tif (v360) goto L_00E2;\n\tv365 = new System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.AsyncOperation>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.AsyncOperation>::.ctor(v365);\n\tgoto L_00DD;\n\tv392 = *([v387 @ X0_v32 (Il2CppClass<HutongGames.PlayMaker.Actions.LoadSceneAsynch>)+E0]);\n\tv393 = v392 == 0;\n\tv394 = ~v393;\n\tif (v394) goto L_00DD;\n\tv399 = \"il2cpp_codegen_runtime_class_init\"(v387, v366, v105, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv396 = HutongGames.PlayMaker.Actions.LoadSceneAsynch;\nL_00DD:\n\tv372.aSyncOperationLUT = v365;\nL_00E2:\n\tgoto L_00EB;\n\tv379 = *([v367 @ X0_v25 (Il2CppClass<HutongGames.PlayMaker.Actions.LoadSceneAsynch>)+E0]);\n\tv380 = v379 == 0;\n\tv381 = ~v380;\n\tgoto L_00EB;\n\tv391 = \"il2cpp_codegen_runtime_class_init\"(v367, v112, v105, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv382 = HutongGames.PlayMaker.Actions.LoadSceneAsynch;\nL_00EB:\n\tv131 = v385.aSynchUidCounter + 1;\n\tv385.aSynchUidCounter = v131;\n\tv100 = this.aSyncOperationHashCode;\n\tthis._asynchOperationUid = v131;\n\tv100.value = v131;\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.AsyncOperation>::Add(v183.aSyncOperationLUT, this._asynchOperationUid, this._asyncOperation);\nL_0103:\n\treturn returnVal2;\n\tv186 = new System.NullReferenceException();\nL_0106:\n\treturnVal1 = new System.InvalidCastException();\n\treturn returnVal1;\n// 181 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool DoLoadAsynch()
		{
			//IL_0164: Expected I4, but got O
			//IL_02d2: Expected I4, but got O
			//IL_019a: Expected I4, but got O
			//IL_009b: Expected I4, but got O
			//IL_00d1: Expected I4, but got O
			Scene activeScene = SceneManager.GetActiveScene();
			AsyncOperation asyncOperation;
			if (sceneReference != GetSceneActionBase.SceneSimpleReferenceOptions.SceneAtIndex)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10D454C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0xD8)");
				string value = sceneByName.Value;
				string text = default(string);
				if (text == value)
				{
					goto IL_0121;
				}
				string value2 = sceneByName.Value;
				Enum value3 = loadSceneMode.Value;
				if ((int)((value3 is LoadSceneMode) ? value3 : null) != 0)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					asyncOperation = SceneManager.LoadSceneAsync(value2, (LoadSceneMode)this);
					goto IL_01a3;
				}
			}
			else
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10D45CC (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x158)");
				int value4 = sceneAtIndex.Value;
				int num = default(int);
				if (num == value4)
				{
					goto IL_0121;
				}
				int value5 = sceneAtIndex.Value;
				Enum value6 = loadSceneMode.Value;
				if ((int)((value6 is LoadSceneMode) ? value6 : null) != 0)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					asyncOperation = SceneManager.LoadSceneAsync(value5, (LoadSceneMode)this);
					goto IL_01a3;
				}
			}
			InvalidCastException ex = new InvalidCastException();
			return (byte)(int)ex != 0;
			IL_0121:
			return false;
			IL_01a3:
			_asyncOperation = asyncOperation;
			if (!operationPriority.IsNone)
			{
				int value7 = operationPriority.Value;
				_asyncOperation.priority = value7;
			}
			bool value8 = allowSceneActivation.Value;
			_asyncOperation.allowSceneActivation = value8;
			if (!aSyncOperationHashCode.IsNone)
			{
				if (aSyncOperationLUT == null)
				{
					Dictionary<int, AsyncOperation> dictionary = new Dictionary<int, AsyncOperation>();
					aSyncOperationLUT = dictionary;
				}
				int num2 = ++aSynchUidCounter;
				FsmInt fsmInt = aSyncOperationHashCode;
				_asynchOperationUid = num2;
				fsmInt.Value = num2;
				aSyncOperationLUT.Add(_asynchOperationUid, _asyncOperation);
			}
			return true;
		}

		[Token(Token = "0x6001014")]
		[Address(RVA = "0xA3AB94", Offset = "0xA3AB94", Length = "0x208")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EAEEA8]);\n\tv19 = *([v18 @ X8_v24]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E46]) = v38;\nL_0014:\n\tv40 = this._asyncOperation == 0;\n\tif (v40) goto L_00A8;\n\tv42 = UnityEngine.AsyncOperation::get_isDone(this._asyncOperation);\n\tv96 = v42 == 0;\n\tif (v96) goto L_0068;\n\tv162 = this.isDone;\n\tv162.value = 1;\n\tv204 = this.progress;\n\tv129 = UnityEngine.AsyncOperation::get_progress(this._asyncOperation);\n\tv204.value = v129;\n\tgoto L_0038;\n\tv231 = *([v226 @ X0_v23 (Il2CppClass<HutongGames.PlayMaker.Actions.LoadSceneAsynch>)+E0]);\n\tv232 = v231 == 0;\n\tv233 = ~v232;\n\tif (v233) goto L_0038;\n\tv244 = \"il2cpp_codegen_runtime_class_init\"(v226, v189, v22, v23, v24, v25, v26, v27, v129, v29, v30, v31, v32, v33, v34, v35);\n\tv235 = HutongGames.PlayMaker.Actions.LoadSceneAsynch;\nL_0038:\n\tv240 = v238.aSyncOperationLUT == 0;\n\tif (v240) goto L_0056;\n\tv246 = this._asynchOperationUid + 1;\n\tv181 = v246 == 0;\n\tif (v181) goto L_0056;\n\tgoto L_0054;\n\tv187 = *([v234 @ X0_v24 (Il2CppClass<HutongGames.PlayMaker.Actions.LoadSceneAsynch>)+E0]);\n\tv265 = v187 == 0;\n\tv266 = ~v265;\n\tif (v266) goto L_0054;\n\tv273 = HutongGames.PlayMaker.Actions.LoadSceneAsynch;\n\tv274 = *([v273 @ X8_v18 (Il2CppClass<HutongGames.PlayMaker.Actions.LoadSceneAsynch>)+B8]);\n\tv201 = v274.aSyncOperationLUT;\nL_0054:\n\tv251 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.AsyncOperation>::Remove(v238.aSyncOperationLUT, this._asynchOperationUid);\nL_0056:\n\tthis._asyncOperation = 0;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.doneEvent);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0068:\n\tv90 = this.progress;\n\tv185 = UnityEngine.AsyncOperation::get_progress(this._asyncOperation);\n\tv90.value = v185;\n\tv230 = UnityEngine.AsyncOperation::get_allowSceneActivation(this._asyncOperation);\n\tv242 = v230 == 0;\n\tv243 = ~v242;\n\tif (v243) goto L_0089;\n\tv258 = HutongGames.PlayMaker.FsmBool::get_Value(this.allowSceneActivation);\n\tv260 = v258 == 0;\n\tif (v260) goto L_0089;\n\tUnityEngine.AsyncOperation::set_allowSceneActivation(this._asyncOperation, 1);\nL_0089:\n\tv75 = UnityEngine.AsyncOperation::get_progress(this._asyncOperation);\n\tv44 = v75 != 0.9f;\n\tif (v44) goto L_00A8;\n\tv80 = UnityEngine.AsyncOperation::get_allowSceneActivation(this._asyncOperation);\n\tv276 = v80 == 0;\n\tv85 = ~v276;\n\tif (v85) goto L_00A8;\n\tv83 = ~this.pendingActivationCallBackDone;\n\tif (v83) goto L_00AB;\nL_00A8:\n\treturn;\nL_00AB:\n\tthis.pendingActivationCallBackDone = 1;\n\tv194 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.pendingActivation);\n\tv278 = v194 == 0;\n\tv279 = ~v278;\n\tif (v279) goto L_00C3;\n\tv202 = this.pendingActivation;\n\tv202.value = 1;\nL_00C3:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.pendingActivationEvent);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 127 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			if (_asyncOperation == null)
			{
				return;
			}
			if (_asyncOperation.isDone)
			{
				FsmBool fsmBool = isDone;
				fsmBool.value = true;
				FsmFloat fsmFloat = progress;
				float value = _asyncOperation.progress;
				fsmFloat.Value = value;
				if (aSyncOperationLUT != null && _asynchOperationUid + 1 != 0)
				{
					bool flag = aSyncOperationLUT.Remove(_asynchOperationUid);
				}
				_asyncOperation = null;
				Fsm.Event(doneEvent);
				Finish();
				return;
			}
			FsmFloat fsmFloat2 = progress;
			float value2 = _asyncOperation.progress;
			fsmFloat2.Value = value2;
			if (!_asyncOperation.allowSceneActivation && allowSceneActivation.Value)
			{
				_asyncOperation.allowSceneActivation = true;
			}
			float num = _asyncOperation.progress;
			if (num == 0.9f && !_asyncOperation.allowSceneActivation && !pendingActivationCallBackDone)
			{
				pendingActivationCallBackDone = true;
				if (!pendingActivation.IsNone)
				{
					FsmBool fsmBool2 = pendingActivation;
					fsmBool2.value = true;
				}
				Fsm.Event(pendingActivationEvent);
			}
		}

		[Token(Token = "0x6001015")]
		[Address(RVA = "0xA3AD9C", Offset = "0xA3AD9C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._asyncOperation = 0;\n\treturn;\n")]
		public override void OnExit()
		{
			_asyncOperation = null;
		}

		[Token(Token = "0x6001016")]
		[Address(RVA = "0xA3ADA4", Offset = "0xA3ADA4", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._asynchOperationUid = 0xFFFFFFFF;\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LoadSceneAsynch()
		{
			_asynchOperationUid = -1;
		}
	}
}
