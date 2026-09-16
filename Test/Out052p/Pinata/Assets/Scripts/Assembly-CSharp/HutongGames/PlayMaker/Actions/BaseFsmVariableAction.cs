using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75D494", Offset = "0x75D494")]
	[Attribute(Type = typeof(ActionTarget), RVA = "0x75D494", Offset = "0x75D494")]
	[Token(Token = "0x2000347")]
	public abstract class BaseFsmVariableAction : FsmStateAction
	{
		[Attribute(Type = typeof(ActionSection), RVA = "0x7C91B4", Offset = "0x7C91B4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C91B4", Offset = "0x7C91B4")]
		[Token(Token = "0x4001AF4")]
		[FieldOffset(Offset = "0x50")]
		public FsmEvent fsmNotFound;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C9214", Offset = "0x7C9214")]
		[Token(Token = "0x4001AF5")]
		[FieldOffset(Offset = "0x58")]
		public FsmEvent variableNotFound;

		[Token(Token = "0x4001AF6")]
		[FieldOffset(Offset = "0x60")]
		private GameObject cachedGameObject;

		[Token(Token = "0x4001AF7")]
		[FieldOffset(Offset = "0x68")]
		private string cachedFsmName;

		[Token(Token = "0x4001AF8")]
		[FieldOffset(Offset = "0x70")]
		protected internal PlayMakerFSM fsm;

		[Token(Token = "0x600106B")]
		[Address(RVA = "0xA8B3E4", Offset = "0xA8B3E4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.fsmNotFound = 0;\n\tthis.variableNotFound = 0;\n\treturn;\n")]
		public override void Reset()
		{
			fsmNotFound = null;
			variableNotFound = null;
		}

		[Token(Token = "0x600106C")]
		[Address(RVA = "0xA8B3EC", Offset = "0xA8B3EC", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv28 = *([1EC5500]);\n\tv29 = *([v28 @ X8_v22]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, go, fsmName, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20221C7]) = v46;\nL_001E:\n\tgoto L_0027;\n\tv53 = *([v49 @ X0_v2+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0027;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v49, go, fsmName, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0027:\n\tv63 = UnityEngine.Object::op_Equality(go, 0);\n\tv65 = v63 == 0;\n\tif (v65) goto L_0032;\n\tgoto L_008C;\nL_0032:\n\tgoto L_003B;\n\tv91 = *([v67 @ X0_v7+E0]);\n\tv92 = v91 == 0;\n\tv93 = ~v92;\n\tif (v93) goto L_003B;\n\tv95 = \"il2cpp_codegen_runtime_class_init\"(v67, v61, v62, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_003B:\n\tv101 = UnityEngine.Object::op_Equality(this.fsm, 0);\n\tv121 = v101 == 0;\n\tv122 = ~v121;\n\tif (v122) goto L_005D;\n\tgoto L_004E;\n\tv147 = *([v123 @ X0_v26+E0]);\n\tv148 = v147 == 0;\n\tv149 = ~v148;\n\tif (v149) goto L_004E;\n\tv151 = \"il2cpp_codegen_runtime_class_init\"(v123, v99, v100, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_004E:\n\tv136 = UnityEngine.Object::op_Inequality(this.cachedGameObject, go);\n\tv159 = v136 == 0;\n\tv139 = ~v159;\n\tif (v139) goto L_005D;\n\tv135 = System.String::op_Inequality(this.cachedFsmName, fsmName);\n\tv138 = v135 == 0;\n\tif (v138) goto L_FFFFFFFF;\nL_005D:\n\tv146 = HutongGames.PlayMaker.ActionHelpers::GetGameObjectFsm(go, fsmName);\n\tthis.cachedFsmName = fsmName;\n\tthis.fsm = v146;\n\tthis.cachedGameObject = go;\n\tgoto L_006F;\n\tv160 = *([v154 @ X0_v16+E0]);\n\tv161 = v160 == 0;\n\tv162 = ~v161;\n\tif (v162) goto L_006F;\n\tv164 = \"il2cpp_codegen_runtime_class_init\"(v154, v144, v145, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_006F:\n\tv170 = UnityEngine.Object::op_Equality(v146, 0);\n\tv173 = v170 == 0;\n\tif (v173) goto L_FFFFFFFF;\n\tv179 = System.String::Concat(\"Could not find FSM: \", fsmName);\n\tHutongGames.PlayMaker.FsmStateAction::LogWarning(this, v179);\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.fsmNotFound);\nL_008C:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal bool UpdateCache(GameObject go, string fsmName)
		{
			if (go == null)
			{
				return false;
			}
			if (fsm == null || cachedGameObject != go || cachedFsmName != fsmName)
			{
				PlayMakerFSM gameObjectFsm = ActionHelpers.GetGameObjectFsm(go, fsmName);
				cachedFsmName = fsmName;
				fsm = gameObjectFsm;
				cachedGameObject = go;
				if (gameObjectFsm == null)
				{
					string text = "Could not find FSM: " + fsmName;
					LogWarning(text);
					Fsm.Event(fsmNotFound);
				}
			}
			return true;
		}

		[Token(Token = "0x600106D")]
		[Address(RVA = "0xA8B580", Offset = "0xA8B580", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EC7518]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, variableName, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20221C8]) = v41;\nL_001A:\n\tv47 = System.String::Concat(\"Could not find variable: \", variableName);\n\tHutongGames.PlayMaker.FsmStateAction::LogWarning(this, v47);\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.variableNotFound);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal void DoVariableNotFound(string variableName)
		{
			string text = "Could not find variable: " + variableName;
			LogWarning(text);
			Fsm.Event(variableNotFound);
		}

		[Token(Token = "0x600106E")]
		[Address(RVA = "0xA8B608", Offset = "0xA8B608", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal BaseFsmVariableAction()
		{
		}
	}
}
