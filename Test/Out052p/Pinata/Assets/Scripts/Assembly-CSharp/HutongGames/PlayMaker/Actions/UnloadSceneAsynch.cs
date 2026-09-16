using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75D1C4", Offset = "0x75D1C4")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75D1C4", Offset = "0x75D1C4")]
	[Token(Token = "0x200033E")]
	public class UnloadSceneAsynch : FsmStateAction
	{
		[Token(Token = "0x200049B")]
		public enum SceneReferenceOptions
		{
			[Token(Token = "0x40021C7")]
			ActiveScene = 0,
			[Token(Token = "0x40021C8")]
			SceneAtBuildIndex = 1,
			[Token(Token = "0x40021C9")]
			SceneAtIndex = 2,
			[Token(Token = "0x40021CA")]
			SceneByName = 3,
			[Token(Token = "0x40021CB")]
			SceneByPath = 4,
			[Token(Token = "0x40021CC")]
			SceneByGameObject = 5
		}

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C83D0", Offset = "0x7C83D0")]
		[Token(Token = "0x4001AAC")]
		[FieldOffset(Offset = "0x4C")]
		public SceneReferenceOptions sceneReference;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8408", Offset = "0x7C8408")]
		[Token(Token = "0x4001AAD")]
		[FieldOffset(Offset = "0x50")]
		public FsmString sceneByName;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8440", Offset = "0x7C8440")]
		[Token(Token = "0x4001AAE")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt sceneAtBuildIndex;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8478", Offset = "0x7C8478")]
		[Token(Token = "0x4001AAF")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt sceneAtIndex;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C84B0", Offset = "0x7C84B0")]
		[Token(Token = "0x4001AB0")]
		[FieldOffset(Offset = "0x68")]
		public FsmString sceneByPath;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C84E8", Offset = "0x7C84E8")]
		[Token(Token = "0x4001AB1")]
		[FieldOffset(Offset = "0x70")]
		public FsmOwnerDefault sceneByGameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8520", Offset = "0x7C8520")]
		[Token(Token = "0x4001AB2")]
		[FieldOffset(Offset = "0x78")]
		public FsmInt operationPriority;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7C8558", Offset = "0x7C8558")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8558", Offset = "0x7C8558")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C8558", Offset = "0x7C8558")]
		[Token(Token = "0x4001AB3")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat progress;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C85CC", Offset = "0x7C85CC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C85CC", Offset = "0x7C85CC")]
		[Token(Token = "0x4001AB4")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool isDone;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C861C", Offset = "0x7C861C")]
		[Token(Token = "0x4001AB5")]
		[FieldOffset(Offset = "0x90")]
		public FsmEvent doneEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8654", Offset = "0x7C8654")]
		[Token(Token = "0x4001AB6")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent sceneNotFoundEvent;

		[Token(Token = "0x4001AB7")]
		[FieldOffset(Offset = "0xA0")]
		private AsyncOperation _asyncOperation;

		[Token(Token = "0x600103A")]
		[Address(RVA = "0x986164", Offset = "0x986164", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EFB170]);\n\tv21 = *([v20 @ X8_v6]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021697]) = v40;\nL_0016:\n\tthis.sceneByGameObject = 0;\n\tthis.sceneReference = 1;\n\tthis.sceneByName = 0;\n\tthis.sceneAtIndex = 0;\n\tv46 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.operationPriority = v46;\n\tthis.progress = 0;\n\tthis.doneEvent = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			sceneByGameObject = null;
			sceneReference = SceneReferenceOptions.SceneAtBuildIndex;
			sceneByName = null;
			sceneAtIndex = null;
			FsmInt fsmInt = new FsmInt();
			fsmInt.useVariable = true;
			operationPriority = fsmInt;
			progress = null;
			doneEvent = null;
		}

		[Token(Token = "0x600103B")]
		[Address(RVA = "0x9861F8", Offset = "0x9861F8", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.isDone;\n\tv10.value = 0;\n\tv12 = this.progress;\n\tv12.value = 0f;\n\tv18 = HutongGames.PlayMaker.Actions.UnloadSceneAsynch::DoUnLoadAsynch(this);\n\tv41 = v18 == 0;\n\tif (v41) goto L_001D;\n\treturn;\nL_001D:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sceneNotFoundEvent);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmBool fsmBool = isDone;
			fsmBool.value = false;
			FsmFloat fsmFloat = progress;
			fsmFloat.Value = 0f;
			if (!DoUnLoadAsynch())
			{
				Fsm.Event(sceneNotFoundEvent);
				Finish();
			}
		}

		[Token(Token = "0x600103C")]
		[Address(RVA = "0x986268", Offset = "0x986268", Length = "0x2F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EE73E0]);\n\tv21 = *([v20 @ X8_v22]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021698]) = v40;\nL_0014:\n\tv41 = v38.sceneReference;\n\tv42 = v38.sceneReference < 5;\n\tv43 = ~v42;\n\tv44 = v38.sceneReference - 5;\n\tv46 = v44 == 0;\n\tv51 = ~v46;\n\tv52 = v43 & v51;\n\tif (v52) goto L_0077;\n\tv54 = 0x1817000 + 0xE84;\n\tv56 = *([v54 @ X9_v4 (System.Int32)+v41 @ X8_v3 (HutongGames.PlayMaker.Actions.UnloadSceneAsynch+SceneReferenceOptions)*4]) + v54;\n\t// 37 IndirectJump v56 @ X8_v19, v38 @ X0_v1 (HutongGames.PlayMaker.Actions.UnloadSceneAsynch), v38 @ X0_v1 (HutongGames.PlayMaker.Actions.UnloadSceneAsynch), methodInfo @ X1 (Il2CppMethodInfo), v24 @ X2, v25 @ X3, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\tX0 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::GetActiveScene(X0);\n\tX0 = X0 & 0xFFFFFFFF;\n\tX1 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::UnloadSceneAsync(X0, X1);\n\tgoto L_0075;\n\tX0 = *([X19+68]);\n\tif (TEMP) goto L_0094;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmString::get_Value(X0, X1);\n\tX1 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::GetSceneByPath(X0, X1);\n\tX0 = X0 & 0xFFFFFFFF;\n\tX1 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::UnloadSceneAsync(X0, X1);\n\tgoto L_0075;\n\tX0 = *([X19+60]);\n\tif (TEMP) goto L_0095;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmInt::get_Value(X0, X1);\n\tX1 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::GetSceneAt(X0, X1);\n\tX0 = X0 & 0xFFFFFFFF;\n\tX1 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::UnloadSceneAsync(X0, X1);\n\tgoto L_0075;\n\tX0 = *([X19+50]);\n\tif (TEMP) goto L_0096;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmString::get_Value(X0, X1);\n\tX1 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::UnloadSceneAsync(X0, X1);\n\tgoto L_0075;\n\tX0 = *([X19+58]);\n\tif (TEMP) goto L_0097;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmInt::get_Value(X0, X1);\n\tX1 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::UnloadSceneAsync(X0, X1);\n\tgoto L_0075;\n\tX0 = *([X19+30]);\n\tif (TEMP) goto L_0098;\n\tX1 = *([X19+70]);\n\tX2 = 0;\n\tX0 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(X0, X1, X2);\n\tX20 = X0;\n\tX8 = *([1EAB010]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0065;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0065;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0065:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = UnityEngine.Object::op_Equality(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_009C;\n\tif (TEMP) goto L_00AA;\n\tX0 = X20;\n\tX1 = 0;\n\tX0 = UnityEngine.GameObject::get_scene(X0, X1);\n\tX0 = X0 & 0xFFFFFFFF;\n\tX1 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::UnloadSceneAsync(X0, X1);\nL_0075:\n\t*([X19+A0]) = X0;\nL_0077:\n\tv58 = v38.operationPriority == 0;\n\tif (v58) goto L_0093;\n\tv118 = HutongGames.PlayMaker.NamedVariable::get_IsNone(v38.operationPriority);\n\tv126 = v118 == 0;\n\tv127 = ~v126;\n\tif (v127) goto L_0092;\n\tv123 = v38.operationPriority == 0;\n\tif (v123) goto L_0093;\n\tv142 = HutongGames.PlayMaker.FsmInt::get_Value(v38.operationPriority);\n\tUnityEngine.AsyncOperation::set_priority(v38._asyncOperation, v142);\nL_0092:\n\treturn 1;\nL_0093:\n\tv124 = new System.NullReferenceException();\nL_0094:\n\tthrow v124;\nL_0095:\n\tv140 = new System.NullReferenceException();\nL_0096:\n\tthrow v140;\nL_0097:\n\tv164 = new System.NullReferenceException();\nL_0098:\n\tthrow v164;\nL_009C:\n\tv213 = new System.Exception();\n\tSystem.Exception::.ctor(v213, \"Null GameObject\", 0);\n\tthrow v213;\nL_00AA:\n\t;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tif (1) goto L_00EF;\n\tv240 = 0x6D2BC0(v233, 0, Il2CppMethodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv162 = *([v240 @ X0_v31]);\n\tv178 = *([v162 @ X20_v10]);\n\tv202 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, v178, Il2CppMethodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv243 = v202 & 1;\n\tv204 = v243 == 0;\n\tif (v204) goto L_00E5;\n\tv180 = 0x6D2490(v202, v178, Il2CppMethodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv160 = *([v162 @ X20_v10]);\n\tv156 = *([v160 @ X8_v17+180]);\n\tv245 = *([v160 @ X8_v17+188]);\n\tv156(v246, v162, v245, Il2CppMethodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tHutongGames.PlayMaker.FsmStateAction::LogError(this, v246, 0);\n\tgoto L_0092;\n\tthrow System.NullReferenceException;\nL_00E5:\n\tv209 = 0x6D1E60(8, v200, v199, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv214 = *([v189 @ X21_v4]);\n\t*([v209 @ X0_v10]) = v214;\n\tv216 = 0x1E8A000 + 0x870;\n\tv218 = 0x6D2A00(v209, v216, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv226 = 0x6D2490(v218, v216, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00EF:\n\tv236 = 0x6D2380(v114, v96, v93, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturnVal2 = 0x846AA4(v236, v96, v93, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturn returnVal2;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool DoUnLoadAsynch()
		{
			//IL_0029: Expected O, but got I
			SceneReferenceOptions sceneReferenceOptions = sceneReference;
			bool flag = sceneReference < SceneReferenceOptions.SceneByGameObject;
			bool flag2 = !flag;
			int num = (int)(sceneReference - 5);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 25260032 + 3716;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X9_v4 (System.Int32)+v41 @ X8_v3 (HutongGames.PlayMaker.Actions.UnloadSceneAsynch+SceneReferenceOptions)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v56 @ X8_v19 (should have been resolved before IL gen)");
			}
			else if (operationPriority == null)
			{
				goto IL_00b1;
			}
			if (!operationPriority.IsNone)
			{
				if (operationPriority == null)
				{
					goto IL_00b1;
				}
				int value = operationPriority.Value;
				_asyncOperation.priority = value;
			}
			return true;
			IL_00b1:
			NullReferenceException ex = new NullReferenceException();
			throw ex;
		}

		[Token(Token = "0x600103D")]
		[Address(RVA = "0x986560", Offset = "0x986560", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = this._asyncOperation == 0;\n\tif (v13) goto L_003B;\n\tv15 = UnityEngine.AsyncOperation::get_isDone(this._asyncOperation);\n\tv33 = v15 == 0;\n\tif (v33) goto L_0030;\n\tv50 = this.isDone;\n\tv50.value = 1;\n\tv73 = this.progress;\n\tv40 = UnityEngine.AsyncOperation::get_progress(this._asyncOperation);\n\tv73.value = v40;\n\tthis._asyncOperation = 0;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.doneEvent);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0030:\n\tv27 = this.progress;\n\tv17 = UnityEngine.AsyncOperation::get_progress(this._asyncOperation);\n\tv27.value = v17;\nL_003B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			if (_asyncOperation != null)
			{
				if (_asyncOperation.isDone)
				{
					FsmBool fsmBool = isDone;
					fsmBool.value = true;
					FsmFloat fsmFloat = progress;
					float value = _asyncOperation.progress;
					fsmFloat.Value = value;
					_asyncOperation = null;
					Fsm.Event(doneEvent);
					Finish();
				}
				else
				{
					FsmFloat fsmFloat2 = progress;
					float value2 = _asyncOperation.progress;
					fsmFloat2.Value = value2;
				}
			}
		}

		[Token(Token = "0x600103E")]
		[Address(RVA = "0x98660C", Offset = "0x98660C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._asyncOperation = 0;\n\treturn;\n")]
		public override void OnExit()
		{
			_asyncOperation = null;
		}

		[Token(Token = "0x600103F")]
		[Address(RVA = "0x986614", Offset = "0x986614", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public UnloadSceneAsynch()
		{
		}
	}
}
