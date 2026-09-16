using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75DA80", Offset = "0x75DA80")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x75DA80", Offset = "0x75DA80")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75DA80", Offset = "0x75DA80")]
	[Token(Token = "0x2000356")]
	public class GetFsmBool : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4001B26")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C9A04", Offset = "0x7C9A04")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C9A04", Offset = "0x7C9A04")]
		[Token(Token = "0x4001B27")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C9A54", Offset = "0x7C9A54")]
		[Token(Token = "0x4001B28")]
		[FieldOffset(Offset = "0x60")]
		public FsmString variableName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C9A90", Offset = "0x7C9A90")]
		[Token(Token = "0x4001B29")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool storeValue;

		[Token(Token = "0x4001B2A")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001B2B")]
		[FieldOffset(Offset = "0x78")]
		private GameObject goLastFrame;

		[Token(Token = "0x4001B2C")]
		[FieldOffset(Offset = "0x80")]
		private string fsmNameLastFrame;

		[Token(Token = "0x4001B2D")]
		[FieldOffset(Offset = "0x88")]
		private PlayMakerFSM fsm;

		[Token(Token = "0x600109B")]
		[Address(RVA = "0xA2C038", Offset = "0xA2C038", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EA46A0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021DBC]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.fsmName = v43;\n\tthis.storeValue = 0;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			fsmName = fsmString;
			storeValue = null;
		}

		[Token(Token = "0x600109C")]
		[Address(RVA = "0xA2C098", Offset = "0xA2C098", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetFsmBool::DoGetFsmBool(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetFsmBool();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600109D")]
		[Address(RVA = "0xA2C2A8", Offset = "0xA2C2A8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetFsmBool::DoGetFsmBool(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetFsmBool();
		}

		[Token(Token = "0x600109E")]
		[Address(RVA = "0xA2C0D4", Offset = "0xA2C0D4", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EF89A8]);\n\tv23 = *([v22 @ X8_v20]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021DBD]) = v42;\nL_0016:\n\tv44 = this.storeValue == 0;\n\tif (v44) goto L_009F;\n\tv92 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002F;\n\tv152 = *([v77 @ X8_v7+E0]);\n\tv153 = v152 == 0;\n\tv154 = ~v153;\n\tif (v154) goto L_002F;\n\tv159 = v77;\n\tv156 = \"il2cpp_codegen_runtime_class_init\"(v159, v90, v91, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002F:\n\tv65 = UnityEngine.Object::op_Equality(v92, 0);\n\tv161 = v65 == 0;\n\tv70 = ~v161;\n\tif (v70) goto L_009F;\n\tgoto L_0042;\n\tv166 = *([v162 @ X0_v13+E0]);\n\tv167 = v166 == 0;\n\tv168 = ~v167;\n\tif (v168) goto L_0042;\n\tv170 = \"il2cpp_codegen_runtime_class_init\"(v162, v60, v56, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0042:\n\tv173 = UnityEngine.Object::op_Inequality(v92, this.goLastFrame);\n\tv175 = v173 == 0;\n\tv176 = ~v175;\n\tif (v176) goto L_0053;\n\tv184 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tv180 = System.String::op_Inequality(v184, this.fsmNameLastFrame);\n\tv182 = v180 == 0;\n\tif (v182) goto L_0069;\nL_0053:\n\tthis.goLastFrame = v92;\n\tv144 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tthis.fsmNameLastFrame = v144;\n\tv188 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tv195 = HutongGames.PlayMaker.ActionHelpers::GetGameObjectFsm(v92, v188);\n\tv48 = this + 0x88;\n\tthis.fsm = v195;\n\tgoto L_006F;\nL_0069:\n\tv48 = this + 0x88;\n\tv83 = this.fsm;\nL_006F:\n\tgoto L_0078;\n\tv208 = *([v203 @ X0_v18+E0]);\n\tv209 = v208 == 0;\n\tv210 = ~v209;\n\tgoto L_0078;\n\tv212 = \"il2cpp_codegen_runtime_class_init\"(v203, v198, v197, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0078:\n\tv66 = UnityEngine.Object::op_Equality(v83, 0);\n\tv216 = v66 == 0;\n\tv71 = ~v216;\n\tif (v71) goto L_009F;\n\tv145 = PlayMakerFSM::get_FsmVariables(*([v48 @ X21_v6]));\n\tv146 = HutongGames.PlayMaker.FsmString::get_Value(this.variableName);\n\tv67 = HutongGames.PlayMaker.FsmVariables::GetFsmBool(v145, v146);\n\tv72 = v67 == 0;\n\tif (v72) goto L_009F;\n\tv74 = this.storeValue;\n\tv64 = HutongGames.PlayMaker.FsmBool::get_Value(v67);\n\tv74.value = v64;\nL_009F:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 98 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetFsmBool()
		{
			//IL_0137: Expected O, but got I
			//IL_015a: Expected O, but got I
			if (storeValue == null)
			{
				return;
			}
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget == null)
			{
				return;
			}
			object obj;
			PlayMakerFSM playMakerFSM;
			if (!(ownerDefaultTarget != goLastFrame))
			{
				string value = fsmName.Value;
				if (!(value != fsmNameLastFrame))
				{
					obj = (long)(IntPtr)this + 136L;
					playMakerFSM = fsm;
					goto IL_0169;
				}
			}
			goLastFrame = ownerDefaultTarget;
			string value2 = fsmName.Value;
			fsmNameLastFrame = value2;
			string value3 = fsmName.Value;
			PlayMakerFSM gameObjectFsm = ActionHelpers.GetGameObjectFsm(ownerDefaultTarget, value3);
			obj = (long)(IntPtr)this + 136L;
			fsm = gameObjectFsm;
			playMakerFSM = gameObjectFsm;
			goto IL_0169;
			IL_0169:
			if (!(playMakerFSM == null))
			{
				FsmVariables fsmVariables = ((PlayMakerFSM)obj).FsmVariables;
				string value4 = variableName.Value;
				FsmBool fsmBool = fsmVariables.GetFsmBool(value4);
				if (fsmBool != null)
				{
					FsmBool fsmBool2 = storeValue;
					bool value5 = fsmBool.Value;
					fsmBool2.value = value5;
				}
			}
		}

		[Token(Token = "0x600109F")]
		[Address(RVA = "0xA2C2AC", Offset = "0xA2C2AC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetFsmBool()
		{
		}
	}
}
