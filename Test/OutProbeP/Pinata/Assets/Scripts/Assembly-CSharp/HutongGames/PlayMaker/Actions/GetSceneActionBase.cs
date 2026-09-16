using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.SceneManagement;

namespace HutongGames.PlayMaker.Actions
{
	[Token(Token = "0x2000334")]
	public abstract class GetSceneActionBase : FsmStateAction
	{
		[Token(Token = "0x2000495")]
		public enum SceneReferenceOptions
		{
			[Token(Token = "0x40021AA")]
			SceneAtIndex = 0,
			[Token(Token = "0x40021AB")]
			SceneByName = 1,
			[Token(Token = "0x40021AC")]
			SceneByPath = 2
		}

		[Token(Token = "0x2000496")]
		public enum SceneSimpleReferenceOptions
		{
			[Token(Token = "0x40021AE")]
			SceneAtIndex = 0,
			[Token(Token = "0x40021AF")]
			SceneByName = 1
		}

		[Token(Token = "0x2000497")]
		public enum SceneBuildReferenceOptions
		{
			[Token(Token = "0x40021B1")]
			SceneAtBuildIndex = 0,
			[Token(Token = "0x40021B2")]
			SceneByName = 1
		}

		[Token(Token = "0x2000498")]
		public enum SceneAllReferenceOptions
		{
			[Token(Token = "0x40021B4")]
			ActiveScene = 0,
			[Token(Token = "0x40021B5")]
			SceneAtIndex = 1,
			[Token(Token = "0x40021B6")]
			SceneByName = 2,
			[Token(Token = "0x40021B7")]
			SceneByPath = 3,
			[Token(Token = "0x40021B8")]
			SceneByGameObject = 4
		}

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C70D4", Offset = "0x7C70D4")]
		[Token(Token = "0x4001A51")]
		[FieldOffset(Offset = "0x4C")]
		public SceneAllReferenceOptions sceneReference;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C710C", Offset = "0x7C710C")]
		[Token(Token = "0x4001A52")]
		[FieldOffset(Offset = "0x50")]
		public FsmInt sceneAtIndex;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C7144", Offset = "0x7C7144")]
		[Token(Token = "0x4001A53")]
		[FieldOffset(Offset = "0x58")]
		public FsmString sceneByName;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C717C", Offset = "0x7C717C")]
		[Token(Token = "0x4001A54")]
		[FieldOffset(Offset = "0x60")]
		public FsmString sceneByPath;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C71B4", Offset = "0x7C71B4")]
		[Token(Token = "0x4001A55")]
		[FieldOffset(Offset = "0x68")]
		public FsmOwnerDefault sceneByGameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C71EC", Offset = "0x7C71EC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C71EC", Offset = "0x7C71EC")]
		[Token(Token = "0x4001A56")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool sceneFound;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C723C", Offset = "0x7C723C")]
		[Token(Token = "0x4001A57")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent sceneFoundEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C7274", Offset = "0x7C7274")]
		[Token(Token = "0x4001A58")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent sceneNotFoundEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C72AC", Offset = "0x7C72AC")]
		[Token(Token = "0x4001A59")]
		[FieldOffset(Offset = "0x88")]
		protected internal Scene _scene;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C72E4", Offset = "0x7C72E4")]
		[Token(Token = "0x4001A5A")]
		[FieldOffset(Offset = "0x8C")]
		protected internal bool _sceneFound;

		[Token(Token = "0x600100A")]
		[Address(RVA = "0xA3411C", Offset = "0xA3411C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneActionBase)+84]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneActionBase)+7C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneActionBase)+6C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneActionBase)+5C]) = 0;\n\tthis.sceneReference = 0;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			sceneReference = default(SceneAllReferenceOptions);
		}

		[Token(Token = "0x600100B")]
		[Address(RVA = "0xA34158", Offset = "0xA34158", Length = "0x2CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EDE2D8]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021E09]) = v40;\nL_0014:\n\tv41 = v38.sceneReference;\n\tv42 = v38.sceneReference < 4;\n\tv43 = ~v42;\n\tv44 = v38.sceneReference - 4;\n\tv46 = v44 == 0;\n\tv51 = ~v46;\n\tv52 = v43 & v51;\n\tif (v52) goto L_0065;\n\tv54 = 0x1818000 + 0x844;\n\tv56 = *([v54 @ X9_v4 (System.Int32)+v41 @ X8_v3 (HutongGames.PlayMaker.Actions.GetSceneActionBase+SceneAllReferenceOptions)*4]) + v54;\n\t// 37 IndirectJump v56 @ X8_v13, v38 @ X0_v1 (HutongGames.PlayMaker.Actions.GetSceneActionBase), v38 @ X0_v1 (HutongGames.PlayMaker.Actions.GetSceneActionBase), methodInfo @ X1 (Il2CppMethodInfo), v24 @ X2, v25 @ X3, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\tX0 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::GetActiveScene(X0);\n\tgoto L_0061;\n\tX0 = *([X19+30]);\n\tif (TEMP) goto L_009B;\n\tX1 = *([X19+68]);\n\tX2 = 0;\n\tX0 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(X0, X1, X2);\n\tX20 = X0;\n\tX8 = *([1EAB010]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_003C;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_003C;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_003C:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = UnityEngine.Object::op_Equality(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_009F;\n\tif (TEMP) goto L_00B0;\n\tX0 = X20;\n\tX1 = 0;\n\tX0 = UnityEngine.GameObject::get_scene(X0, X1);\n\tgoto L_0061;\n\tX0 = *([X19+58]);\n\tif (TEMP) goto L_009C;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmString::get_Value(X0, X1);\n\tX1 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::GetSceneByName(X0, X1);\n\tgoto L_0061;\n\tX0 = *([X19+60]);\n\tif (TEMP) goto L_009D;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmString::get_Value(X0, X1);\n\tX1 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::GetSceneByPath(X0, X1);\n\tgoto L_0061;\n\tX0 = *([X19+50]);\n\tif (TEMP) goto L_009E;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmInt::get_Value(X0, X1);\n\tX1 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::GetSceneAt(X0, X1);\nL_0061:\n\t*([X19+88]) = X0;\nL_0065:\n\tv60 = UnityEngine.SceneManagement.Scene::op_Equality(v38._scene, 0);\n\tv100 = v60 == 0;\n\tif (v100) goto L_0086;\n\tv38._sceneFound = 0;\n\tv102 = v38.sceneFound == 0;\n\tif (v102) goto L_00E2;\n\tv107 = HutongGames.PlayMaker.NamedVariable::get_IsNone(v38.sceneFound);\n\tv117 = v107 == 0;\n\tv118 = ~v117;\n\tif (v118) goto L_0078;\n\tv124 = v38.sceneFound;\n\tv125 = v38.sceneFound == 0;\n\tif (v125) goto L_00E2;\n\tv124.value = 0;\nL_0078:\n\tv82 = v38.fsm == 0;\n\tif (v82) goto L_00E2;\n\tHutongGames.PlayMaker.Fsm::Event(v38.fsm, v38.sceneNotFoundEvent);\n\treturn;\nL_0086:\n\tv38._sceneFound = 1;\n\tv105 = v38.sceneFound == 0;\n\tif (v105) goto L_00E2;\n\tv79 = HutongGames.PlayMaker.NamedVariable::get_IsNone(v38.sceneFound);\n\tv122 = v79 == 0;\n\tv123 = ~v122;\n\tif (v123) goto L_009A;\n\tv129 = v38.sceneFound;\n\tv130 = v38.sceneFound == 0;\n\tif (v130) goto L_00E2;\n\tv129.value = 1;\nL_009A:\n\treturn;\nL_009B:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_009C:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_009D:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_009E:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_009F:\n\tX8 = 0x1EDD000;\n\tX8 = *([1EDD7C0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX8 = *([1EB9AA0]);\n\tX1 = *([X8]);\n\tX0 = X20;\n\tX2 = 0;\n\tSystem.Exception::.ctor(X0, X1, X2);\n\tX8 = *([1EE3148]);\n\tX2 = *([X8]);\n\tX0 = X20;\n\tX1 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00B0:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_00BC;\n\tgoto L_00BC;\n\tgoto L_00BC;\n\tgoto L_00BC;\n\tgoto L_00BC;\n\tgoto L_00BC;\n\tgoto L_00BC;\n\tgoto L_00BC;\n\tgoto L_00BC;\n\tgoto L_00BC;\nL_00BC:\n\tX20 = X0;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00ED;\n\tX0 = X20;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\n\tX20 = *([X21]);\n\tX8 = *([1EDD7C0]);\n\tX1 = *([X20]);\n\tX0 = *([X8]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00E3;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t// 214 ConditionalJump @b69, TEMP\n\tX8 = *([X20]);\n\tX0 = X20;\n\tX9 = *([X8+180]);\n\tX1 = *([X8+188]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = X0;\n\tX0 = X19;\n\tX2 = 0;\n\tHutongGames.PlayMaker.FsmStateAction::LogError(X0, X1, X2);\n\tgoto L_0065;\nL_00E2:\n\tthrow System.NullReferenceException;\nL_00E3:\n\t;\n\tv133 = 0x6D2490(v128, v73, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00ED:\n\t;\n\tv135 = 0x6D2380(v128, v73, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv80 = 0x846AA4(v135, v73, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturn;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			//IL_0029: Expected O, but got I
			SceneAllReferenceOptions sceneAllReferenceOptions = sceneReference;
			bool flag = sceneReference < SceneAllReferenceOptions.SceneByGameObject;
			bool flag2 = !flag;
			int num = (int)(sceneReference - 4);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 25264128 + 2116;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X9_v4 (System.Int32)+v41 @ X8_v3 (HutongGames.PlayMaker.Actions.GetSceneActionBase+SceneAllReferenceOptions)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v56 @ X8_v13 (should have been resolved before IL gen)");
			}
			else if (!(_scene == default(Scene)))
			{
				_sceneFound = true;
				if (sceneFound != null)
				{
					if (sceneFound.IsNone)
					{
						return;
					}
					FsmBool fsmBool = sceneFound;
					if (sceneFound != null)
					{
						fsmBool.value = true;
						return;
					}
				}
				goto IL_01ea;
			}
			_sceneFound = false;
			if (sceneFound != null)
			{
				if (!sceneFound.IsNone)
				{
					FsmBool fsmBool2 = sceneFound;
					if (sceneFound == null)
					{
						goto IL_01ea;
					}
					fsmBool2.value = false;
				}
				if (Fsm != null)
				{
					Fsm.Event(sceneNotFoundEvent);
					return;
				}
			}
			goto IL_01ea;
			IL_01ea:
			throw new NullReferenceException();
		}

		[Token(Token = "0x600100C")]
		[Address(RVA = "0xA34424", Offset = "0xA34424", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal GetSceneActionBase()
		{
		}
	}
}
