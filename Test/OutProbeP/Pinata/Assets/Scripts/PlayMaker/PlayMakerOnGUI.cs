using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using HutongGames.PlayMaker;
using UnityEngine;

[ExecuteInEditMode]
[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x73E7AC", Offset = "0x73E7AC")]
[Token(Token = "0x2000014")]
public class PlayMakerOnGUI : MonoBehaviour
{
	[Token(Token = "0x400003B")]
	[FieldOffset(Offset = "0x18")]
	public PlayMakerFSM playMakerFSM;

	[Token(Token = "0x400003C")]
	[FieldOffset(Offset = "0x20")]
	public bool previewInEditMode;

	[Token(Token = "0x60000A9")]
	[Address(RVA = "0xE5BDB0", Offset = "0xE5BDB0", Length = "0xB0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EA3FA8]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024833]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Inequality(this.playMakerFSM, 0);\n\tv58 = v56 == 0;\n\tif (v58) goto L_003F;\n\tv59 = this.playMakerFSM;\n\tv65 = v59.fsm;\n\tv65.owner = v59;\n\tHutongGames.PlayMaker.Fsm::set_HandleOnGUI(v59.fsm, 1);\n\treturn;\nL_003F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void Start()
	{
		if (this.playMakerFSM != null)
		{
			PlayMakerFSM playMakerFSM = this.playMakerFSM;
			Fsm fsm = playMakerFSM.fsm;
			fsm.Owner = playMakerFSM;
			playMakerFSM.fsm.HandleOnGUI = true;
		}
	}

	[Token(Token = "0x60000AA")]
	[Address(RVA = "0xE5BE60", Offset = "0xE5BE60", Length = "0x10C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EEBC28]);\n\tv19 = *([v18 @ X8_v20]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024834]) = v38;\nL_0014:\n\tv40 = ~this.previewInEditMode;\n\tif (v40) goto L_0022;\n\tv42 = UnityEngine.Application::get_isPlaying();\n\tv45 = v42 == 0;\n\tif (v45) goto L_0063;\nL_0022:\n\tgoto L_002B;\n\tv54 = *([v49 @ X0_v3+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_002B;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v49, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002B:\n\tv64 = UnityEngine.Object::op_Inequality(this.playMakerFSM, 0);\n\tv70 = v64 == 0;\n\tif (v70) goto L_005D;\n\tv71 = this.playMakerFSM;\n\tv75 = v71.fsm;\n\tv75.owner = v71;\n\tv78 = v71.fsm == 0;\n\tif (v78) goto L_005D;\n\tv119 = this.playMakerFSM;\n\tv76 = v119.fsm;\n\tv76.owner = v119;\n\tv120 = v119.fsm;\n\tv79 = ~v120.handleOnGUI;\n\tif (v79) goto L_005D;\n\tv104 = this.playMakerFSM;\n\tv90 = v104.fsm;\n\tv90.owner = v104;\n\tHutongGames.PlayMaker.Fsm::OnGUI(v104.fsm);\n\treturn;\nL_005D:\n\treturn;\nL_0063:\n\tPlayMakerOnGUI::DoEditGUI();\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void OnGUI()
	{
		if (!previewInEditMode || Application.isPlaying)
		{
			if (!(this.playMakerFSM != null))
			{
				return;
			}
			PlayMakerFSM playMakerFSM = this.playMakerFSM;
			Fsm fsm = playMakerFSM.fsm;
			fsm.Owner = playMakerFSM;
			if (playMakerFSM.fsm != null)
			{
				PlayMakerFSM playMakerFSM2 = this.playMakerFSM;
				Fsm fsm2 = playMakerFSM2.fsm;
				fsm2.Owner = playMakerFSM2;
				Fsm fsm3 = playMakerFSM2.fsm;
				if (fsm3.HandleOnGUI)
				{
					PlayMakerFSM playMakerFSM3 = this.playMakerFSM;
					Fsm fsm4 = playMakerFSM3.fsm;
					fsm4.Owner = playMakerFSM3;
					playMakerFSM3.fsm.OnGUI();
				}
			}
		}
		else
		{
			DoEditGUI();
		}
	}

	[Token(Token = "0x60000AB")]
	[Address(RVA = "0xE5BF6C", Offset = "0xE5BF6C", Length = "0x124")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EC3520]);\n\tv17 = *([v16 @ X8_v25]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2024835]) = v37;\nL_0018:\n\tgoto L_0020;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0020;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = PlayMakerGUI;\nL_0020:\n\tv119 = v51.SelectedFSM;\n\tv53 = v51.SelectedFSM == 0;\n\tif (v53) goto L_0077;\n\tgoto L_0032;\n\tv128 = *([v47 @ X0_v3 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv129 = v128 == 0;\n\tv130 = ~v129;\n\tif (v130) goto L_0032;\n\tv174 = PlayMakerGUI;\n\tv175 = *([v174 @ X8_v19 (Il2CppClass<PlayMakerGUI>)+B8]);\n\tv134 = v175.SelectedFSM;\nL_0032:\n\tv114 = v119.editState == 0;\n\tif (v114) goto L_0077;\n\tv110 = HutongGames.PlayMaker.FsmState::get_IsInitialized(v119.editState);\n\tv115 = v110 == 0;\n\tif (v115) goto L_0077;\n\tv111 = HutongGames.PlayMaker.FsmState::get_Actions(v119.editState);\n\tv237 = v111.Length;\n\tv66 = v111.Length < 1;\n\tif (v66) goto L_0077;\nL_004E:\n\tv247 = v201 < v237;\n\tv219 = ~v247;\n\tif (v219) goto L_0079;\n\tv225 = v111[v201 @ X20_v7 (System.Int32)];\n\tv113 = ~v225.active;\n\tif (v113) goto L_0064;\n\tv252 = HutongGames.PlayMaker.FsmStateAction::OnGUI(v111[v201 @ X20_v7 (System.Int32)]);\nL_0064:\n\tv237 = v111.Length;\n\tv201 = v201 + 1;\n\tv64 = v201 < v111.Length;\n\tif (v64) goto L_004E;\nL_0077:\n\treturn;\n\tv230 = new System.NullReferenceException();\nL_0079:\n\tv238 = new System.IndexOutOfRangeException();\n\tthrow v238;\n\tthrow System.NullReferenceException;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private static void DoEditGUI()
	{
		Fsm selectedFSM = PlayMakerGUI.SelectedFSM;
		if (PlayMakerGUI.SelectedFSM == null || selectedFSM.EditState == null || !selectedFSM.EditState.IsInitialized)
		{
			return;
		}
		FsmStateAction[] actions = selectedFSM.EditState.Actions;
		int num = actions.Length;
		if (actions.Length < 1)
		{
			return;
		}
		int num2 = 0;
		while (num2 < num)
		{
			FsmStateAction fsmStateAction = actions[num2];
			if (fsmStateAction.Active)
			{
				actions[num2].OnGUI();
			}
			num = actions.Length;
			num2++;
			if (num2 >= actions.Length)
			{
				return;
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		throw ex;
	}

	[Token(Token = "0x60000AC")]
	[Address(RVA = "0xE5C090", Offset = "0xE5C090", Length = "0x10")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.previewInEditMode = 1;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public PlayMakerOnGUI()
	{
		previewInEditMode = true;
	}
}
