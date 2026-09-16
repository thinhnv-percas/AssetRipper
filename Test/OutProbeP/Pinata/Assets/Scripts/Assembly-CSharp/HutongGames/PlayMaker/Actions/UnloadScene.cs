using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Obsolete]
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75D150", Offset = "0x75D150")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75D150", Offset = "0x75D150")]
	[Token(Token = "0x200033D")]
	public class UnloadScene : FsmStateAction
	{
		[Token(Token = "0x200049A")]
		public enum SceneReferenceOptions
		{
			[Token(Token = "0x40021C0")]
			ActiveScene = 0,
			[Token(Token = "0x40021C1")]
			SceneAtBuildIndex = 1,
			[Token(Token = "0x40021C2")]
			SceneAtIndex = 2,
			[Token(Token = "0x40021C3")]
			SceneByName = 3,
			[Token(Token = "0x40021C4")]
			SceneByPath = 4,
			[Token(Token = "0x40021C5")]
			SceneByGameObject = 5
		}

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8184", Offset = "0x7C8184")]
		[Token(Token = "0x4001AA3")]
		[FieldOffset(Offset = "0x4C")]
		public SceneReferenceOptions sceneReference;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C81BC", Offset = "0x7C81BC")]
		[Token(Token = "0x4001AA4")]
		[FieldOffset(Offset = "0x50")]
		public FsmString sceneByName;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C81F4", Offset = "0x7C81F4")]
		[Token(Token = "0x4001AA5")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt sceneAtBuildIndex;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C822C", Offset = "0x7C822C")]
		[Token(Token = "0x4001AA6")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt sceneAtIndex;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8264", Offset = "0x7C8264")]
		[Token(Token = "0x4001AA7")]
		[FieldOffset(Offset = "0x68")]
		public FsmString sceneByPath;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C829C", Offset = "0x7C829C")]
		[Token(Token = "0x4001AA8")]
		[FieldOffset(Offset = "0x70")]
		public FsmOwnerDefault sceneByGameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7C82D4", Offset = "0x7C82D4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C82D4", Offset = "0x7C82D4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C82D4", Offset = "0x7C82D4")]
		[Token(Token = "0x4001AA9")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool unloaded;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8348", Offset = "0x7C8348")]
		[Token(Token = "0x4001AAA")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent unloadedEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8380", Offset = "0x7C8380")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C8380", Offset = "0x7C8380")]
		[Token(Token = "0x4001AAB")]
		[FieldOffset(Offset = "0x88")]
		public FsmEvent failureEvent;

		[Token(Token = "0x6001036")]
		[Address(RVA = "0x985DD8", Offset = "0x985DD8", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.sceneReference = 1;\n\tthis.sceneByGameObject = 0;\n\tthis.unloadedEvent = 0;\n\tthis.sceneByName = 0;\n\tthis.sceneAtIndex = 0;\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			sceneReference = SceneReferenceOptions.SceneAtBuildIndex;
			sceneByGameObject = null;
			unloadedEvent = null;
			sceneByName = null;
			sceneAtIndex = null;
		}

		[Token(Token = "0x6001037")]
		[Address(RVA = "0x985DF0", Offset = "0x985DF0", Length = "0x31C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EF2818]);\n\tv21 = *([v20 @ X8_v13]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021695]) = v40;\nL_0014:\n\tv41 = v38.sceneReference;\n\tv42 = v38.sceneReference < 5;\n\tv43 = ~v42;\n\tv44 = v38.sceneReference - 5;\n\tv46 = v44 == 0;\n\tv51 = ~v46;\n\tv52 = v43 & v51;\n\tif (v52) goto L_00CD;\n\tv54 = 0x1817000 + 0xE6C;\n\tv56 = *([v54 @ X9_v6 (System.Int32)+v41 @ X8_v3 (HutongGames.PlayMaker.Actions.UnloadScene+SceneReferenceOptions)*4]) + v54;\n\t// 37 IndirectJump v56 @ X8_v10, v38 @ X0_v1 (HutongGames.PlayMaker.Actions.UnloadScene), v38 @ X0_v1 (HutongGames.PlayMaker.Actions.UnloadScene), methodInfo @ X1 (Il2CppMethodInfo), v24 @ X2, v25 @ X3, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\tX0 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::GetActiveScene(X0);\n\tX0 = X0 & 0xFFFFFFFF;\n\tX1 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::UnloadScene(X0, X1);\n\tX20 = X0;\n\t// 44 Jump @b90\n\tX0 = *([X19+68]);\n\tif (TEMP) goto L_007C;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmString::get_Value(X0, X1);\n\tX1 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::GetSceneByPath(X0, X1);\n\tX0 = X0 & 0xFFFFFFFF;\n\tX1 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::UnloadScene(X0, X1);\n\tX20 = X0;\n\t// 56 Jump @b90\n\tX0 = *([X19+60]);\n\tif (TEMP) goto L_007D;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmInt::get_Value(X0, X1);\n\tX1 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::GetSceneAt(X0, X1);\n\tX0 = X0 & 0xFFFFFFFF;\n\tX1 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::UnloadScene(X0, X1);\n\tX20 = X0;\n\t// 68 Jump @b90\n\tX0 = *([X19+50]);\n\tif (TEMP) goto L_007E;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmString::get_Value(X0, X1);\n\tX1 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::UnloadScene(X0, X1);\n\tX20 = X0;\n\t// 77 Jump @b90\n\tX0 = *([X19+58]);\n\tif (TEMP) goto L_007F;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmInt::get_Value(X0, X1);\n\tX1 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::UnloadScene(X0, X1);\n\tX20 = X0;\n\t// 86 Jump @b90\n\tX0 = *([X19+30]);\n\tif (TEMP) goto L_0080;\n\tX1 = *([X19+70]);\n\tX2 = 0;\n\tX0 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(X0, X1, X2);\n\tX20 = X0;\n\tX8 = *([1EAB010]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_006A;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_006A;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_006A:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = UnityEngine.Object::op_Equality(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0081;\n\tif (TEMP) goto L_0092;\n\tX0 = X20;\n\tX1 = 0;\n\tX0 = UnityEngine.GameObject::get_scene(X0, X1);\n\tX0 = X0 & 0xFFFFFFFF;\n\tX1 = 0;\n\tX0 = UnityEngine.SceneManagement.SceneManager::UnloadScene(X0, X1);\n\tX20 = X0;\n\t// 123 Jump @b90\nL_007C:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_007D:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_007E:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_007F:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0080:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0081:\n\tX8 = 0x1EDD000;\n\tX8 = *([1EDD7C0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX8 = *([1EB9AA0]);\n\tX1 = *([X8]);\n\tX0 = X20;\n\tX2 = 0;\n\tSystem.Exception::.ctor(X0, X1, X2);\n\tX8 = *([1F00EF0]);\n\tX2 = *([X8]);\n\tX0 = X20;\n\tX1 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0092:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_00A4;\n\tgoto L_00A4;\n\tgoto L_00A4;\n\tgoto L_00A4;\n\tgoto L_00A4;\n\tgoto L_00A4;\n\tgoto L_00A4;\n\tgoto L_00A4;\n\tgoto L_00A4;\n\tgoto L_00A4;\n\tgoto L_00A4;\n\tgoto L_00A4;\n\tgoto L_00A4;\n\tgoto L_00A4;\n\tgoto L_00A4;\n\tgoto L_00A4;\nL_00A4:\n\tX20 = X0;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00FC;\n\tX0 = X20;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\n\tX20 = *([X21]);\n\tX8 = *([1EDD7C0]);\n\tX1 = *([X20]);\n\tX0 = *([X8]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00F1;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00F0;\n\tX8 = *([X20]);\n\tX0 = X20;\n\tX9 = *([X8+180]);\n\tX1 = *([X8+188]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = X0;\n\tX0 = X19;\n\tX2 = 0;\n\tHutongGames.PlayMaker.FsmStateAction::LogError(X0, X1, X2);\nL_00CD:\n\tv90 = HutongGames.PlayMaker.NamedVariable::get_IsNone(v38.unloaded);\n\tv102 = v90 == 0;\n\tv103 = ~v102;\n\tif (v103) goto L_00DA;\n\tv108 = v38.unloaded;\n\tv106 = v38.unloaded == 0;\n\tif (v106) goto L_00F0;\n\tv108.value = 0;\nL_00DA:\n\tgoto L_00E1;\n\tv122 = v38.unloadedEvent;\n\tgoto L_00E3;\nL_00E1:\n\tv122 = v38.failureEvent;\nL_00E3:\n\tHutongGames.PlayMaker.Fsm::Event(v38.fsm, v122);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(v38);\n\treturn;\n\tthrow System.NullReferenceException;\nL_00F0:\n\tthrow System.NullReferenceException;\nL_00F1:\n\t;\n\tv81 = *([v1 @ X21]);\n\t*([v116 @ X0_v7]) = v81;\n\tv67 = 0x1E8A000 + 0x870;\n\tv118 = 0x6D2A00(v116, v67, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv121 = 0x6D2490(v118, v67, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00FC:\n\tv124 = 0x6D2380(v118, v67, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv73 = 0x846AA4(v124, v67, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturn;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
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
				int num2 = 25260032 + 3692;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X9_v6 (System.Int32)+v41 @ X8_v3 (HutongGames.PlayMaker.Actions.UnloadScene+SceneReferenceOptions)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v56 @ X8_v10 (should have been resolved before IL gen)");
			}
			if (!unloaded.IsNone)
			{
				FsmBool fsmBool = unloaded;
				if (unloaded == null)
				{
					throw new NullReferenceException();
				}
				fsmBool.value = false;
			}
			FsmEvent fsmEvent = failureEvent;
			Fsm.Event(fsmEvent);
			Finish();
		}

		[Token(Token = "0x6001038")]
		[Address(RVA = "0x98610C", Offset = "0x98610C", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = *([1ECD038]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021696]) = v35;\nL_001A:\n\treturn v41.Empty;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ErrorCheck()
		{
			return string.Empty;
		}

		[Token(Token = "0x6001039")]
		[Address(RVA = "0x98615C", Offset = "0x98615C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public UnloadScene()
		{
		}
	}
}
