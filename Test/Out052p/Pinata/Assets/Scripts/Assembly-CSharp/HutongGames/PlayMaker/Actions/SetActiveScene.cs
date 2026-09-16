using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.SceneManagement;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75D100", Offset = "0x75D100")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75D100", Offset = "0x75D100")]
	[Token(Token = "0x200033C")]
	public class SetActiveScene : FsmStateAction
	{
		[Token(Token = "0x2000499")]
		public enum SceneReferenceOptions
		{
			[Token(Token = "0x40021BA")]
			SceneAtBuildIndex = 0,
			[Token(Token = "0x40021BB")]
			SceneAtIndex = 1,
			[Token(Token = "0x40021BC")]
			SceneByName = 2,
			[Token(Token = "0x40021BD")]
			SceneByPath = 3,
			[Token(Token = "0x40021BE")]
			SceneByGameObject = 4
		}

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C7EB0", Offset = "0x7C7EB0")]
		[Token(Token = "0x4001A95")]
		[FieldOffset(Offset = "0x4C")]
		public SceneReferenceOptions sceneReference;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C7EE8", Offset = "0x7C7EE8")]
		[Token(Token = "0x4001A96")]
		[FieldOffset(Offset = "0x50")]
		public FsmString sceneByName;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C7F20", Offset = "0x7C7F20")]
		[Token(Token = "0x4001A97")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt sceneAtBuildIndex;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C7F58", Offset = "0x7C7F58")]
		[Token(Token = "0x4001A98")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt sceneAtIndex;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C7F90", Offset = "0x7C7F90")]
		[Token(Token = "0x4001A99")]
		[FieldOffset(Offset = "0x68")]
		public FsmString sceneByPath;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C7FC8", Offset = "0x7C7FC8")]
		[Token(Token = "0x4001A9A")]
		[FieldOffset(Offset = "0x70")]
		public FsmOwnerDefault sceneByGameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7C8000", Offset = "0x7C8000")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8000", Offset = "0x7C8000")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C8000", Offset = "0x7C8000")]
		[Token(Token = "0x4001A9B")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool success;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8074", Offset = "0x7C8074")]
		[Token(Token = "0x4001A9C")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent successEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C80AC", Offset = "0x7C80AC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C80AC", Offset = "0x7C80AC")]
		[Token(Token = "0x4001A9D")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool sceneFound;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C80FC", Offset = "0x7C80FC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C80FC", Offset = "0x7C80FC")]
		[Token(Token = "0x4001A9E")]
		[FieldOffset(Offset = "0x90")]
		public FsmEvent sceneNotActivatedEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C814C", Offset = "0x7C814C")]
		[Token(Token = "0x4001A9F")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent sceneNotFoundEvent;

		[Token(Token = "0x4001AA0")]
		[FieldOffset(Offset = "0xA0")]
		private Scene _scene;

		[Token(Token = "0x4001AA1")]
		[FieldOffset(Offset = "0xA4")]
		private bool _sceneFound;

		[Token(Token = "0x4001AA2")]
		[FieldOffset(Offset = "0xA5")]
		private bool _success;

		[Token(Token = "0x6001032")]
		[Address(RVA = "0xB284A4", Offset = "0xB284A4", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.sceneReference = 1;\n\tv8 = this + 0x50;\n\tv11 = 0x6D26F0(v8, 0, 0x50, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24);\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_0017: Expected O, but got I
			sceneReference = SceneReferenceOptions.SceneAtIndex;
			object obj = (long)(IntPtr)this + 80L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D26F0 (native memset)");
		}

		[Token(Token = "0x6001033")]
		[Address(RVA = "0xB284CC", Offset = "0xB284CC", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetActiveScene::DoSetActivate(this);\n\tv14 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.success);\n\tv47 = v14 == 0;\n\tv48 = ~v47;\n\tif (v48) goto L_0019;\n\tv51 = this.success;\n\tv51.value = this._success;\nL_0019:\n\tv58 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.sceneFound);\n\tv82 = v58 == 0;\n\tv83 = ~v82;\n\tif (v83) goto L_0024;\n\tv52 = this.sceneFound;\n\tv52.value = this._sceneFound;\nL_0024:\n\tv73 = ~this._success;\n\tif (v73) goto L_0035;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.successEvent);\n\treturn;\nL_0035:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetActivate();
			if (!success.IsNone)
			{
				FsmBool fsmBool = success;
				fsmBool.value = _success;
			}
			if (!sceneFound.IsNone)
			{
				FsmBool fsmBool2 = sceneFound;
				fsmBool2.value = _sceneFound;
			}
			if (_success)
			{
				Fsm.Event(successEvent);
			}
		}

		[Token(Token = "0x6001034")]
		[Address(RVA = "0xB28564", Offset = "0xB28564", Length = "0x29C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EF2FA0]);\n\tv21 = *([v20 @ X8_v10]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20225F0]) = v40;\nL_0015:\n\tv42 = v38.sceneReference - 1;\n\tv43 = v42 < 3;\n\tv44 = ~v43;\n\tv45 = v42 - 3;\n\tv47 = v45 == 0;\n\tv52 = ~v47;\n\tv53 = v44 & v52;\n\tif (v53) goto L_0065;\n\tv55 = 0x1819000 + 0x3E0;\n\tv57 = *([v55 @ X9_v3 (System.Int32)+v42 @ X8_v4 (System.Int32)*4]) + v55;\n\t// 38 IndirectJump v57 @ X8_v7, v38 @ X0_v1 (HutongGames.PlayMaker.Actions.SetActiveScene), v38 @ X0_v1 (HutongGames.PlayMaker.Actions.SetActiveScene), methodInfo @ X1 (Il2CppMethodInfo), v24 @ X2, v25 @ X3, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\tX0 = *([X19+60]);\n\tif (TEMP) goto L_0087;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmInt::get_Value(X0, X1);\n\tX1 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::GetSceneAt(X0, X1);\n\tgoto L_005F;\n\tX0 = *([X19+68]);\n\tif (TEMP) goto L_0085;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmString::get_Value(X0, X1);\n\tX1 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::GetSceneByPath(X0, X1);\n\tgoto L_005F;\n\tX0 = *([X19+30]);\n\tif (TEMP) goto L_0086;\n\tX1 = *([X19+70]);\n\tX2 = 0;\n\tX0 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(X0, X1, X2);\n\tX20 = X0;\n\tX8 = *([1EAB010]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_004A;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_004A;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_004A:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = UnityEngine.Object::op_Equality(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0089;\n\tif (TEMP) goto L_009A;\n\tX0 = X20;\n\tX1 = 0;\n\tX0 = UnityEngine.GameObject::get_scene(X0, X1);\n\tgoto L_005F;\n\tX0 = *([X19+50]);\n\tif (TEMP) goto L_0088;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmString::get_Value(X0, X1);\n\tX1 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::GetSceneByName(X0, X1);\nL_005F:\n\t*([X19+A0]) = X0;\n\tgoto L_0065;\nL_0065:\n\tv95 = UnityEngine.SceneManagement.Scene::op_Equality(v38._scene, 0);\n\tv81 = v95 == 0;\n\tif (v81) goto L_0079;\nL_006A:\n\tv38._sceneFound = 0;\n\tv80 = v38.fsm == 0;\n\tif (v80) goto L_00D4;\n\tHutongGames.PlayMaker.Fsm::Event(v38.fsm, v38.sceneNotFoundEvent);\n\treturn;\nL_0079:\n\tv77 = UnityEngine.SceneManagement.SceneManager::SetActiveScene(v38._scene);\n\tv38._success = v77;\n\tv38._sceneFound = 1;\n\treturn;\nL_0085:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0086:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0087:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0088:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0089:\n\tX8 = 0x1EDD000;\n\tX8 = *([1EDD7C0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX8 = *([1EB9AA0]);\n\tX1 = *([X8]);\n\tX0 = X20;\n\tX2 = 0;\n\tSystem.Exception::.ctor(X0, X1, X2);\n\tX8 = *([1EAF218]);\n\tX2 = *([X8]);\n\tX0 = X20;\n\tX1 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_009A:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_00A6;\n\tgoto L_00A6;\n\tgoto L_00A6;\n\tgoto L_00A6;\n\tgoto L_00A6;\n\tgoto L_00A6;\n\tgoto L_00A6;\n\tgoto L_00A6;\n\tgoto L_00A6;\n\tgoto L_00A6;\nL_00A6:\n\tX20 = X0;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00D7;\n\tX0 = X20;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\n\tX20 = *([X21]);\n\tX8 = *([1EDD7C0]);\n\tX1 = *([X20]);\n\tX0 = *([X8]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00CB;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00D3;\n\tX8 = *([X20]);\n\tX0 = X20;\n\tX9 = *([X8+180]);\n\tX1 = *([X8+188]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = X0;\n\tX0 = X19;\n\tX2 = 0;\n\tHutongGames.PlayMaker.FsmStateAction::LogError(X0, X1, X2);\n\tgoto L_006A;\nL_00CB:\n\tX0 = 0 | 8;\n\tX0 = 0x6D1E60(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X21]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0x870;\n\tX2 = 0;\n\tX0 = 0x6D2A00(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00D3:\n\tX0 = 0;\nL_00D4:\n\tv98 = new System.NullReferenceException();\n\tv99 = 0x6D2490(v98, 0, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00D7:\n\t;\n\tv101 = 0x6D2380(v98, 0, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv78 = 0x846AA4(v101, 0, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetActivate()
		{
			//IL_0029: Expected O, but got I
			int num = (int)(sceneReference - 1);
			bool flag = num < 3;
			bool flag2 = !flag;
			int num2 = num - 3;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 25268224 + 992;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X9_v3 (System.Int32)+v42 @ X8_v4 (System.Int32)*4]");
				object obj = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v57 @ X8_v7 (should have been resolved before IL gen)");
			}
			else if (!(_scene == default(Scene)))
			{
				bool flag5 = SceneManager.SetActiveScene(_scene);
				_success = flag5;
				_sceneFound = true;
				return;
			}
			_sceneFound = false;
			if (Fsm != null)
			{
				Fsm.Event(sceneNotFoundEvent);
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
		}

		[Token(Token = "0x6001035")]
		[Address(RVA = "0xB28800", Offset = "0xB28800", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetActiveScene()
		{
		}
	}
}
