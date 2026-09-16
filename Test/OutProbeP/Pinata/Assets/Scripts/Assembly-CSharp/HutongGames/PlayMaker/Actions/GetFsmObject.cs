using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75DFA4", Offset = "0x75DFA4")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x75DFA4", Offset = "0x75DFA4")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75DFA4", Offset = "0x75DFA4")]
	[Token(Token = "0x200035D")]
	public class GetFsmObject : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CA0C4", Offset = "0x7CA0C4")]
		[Token(Token = "0x4001B5E")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CA110", Offset = "0x7CA110")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CA110", Offset = "0x7CA110")]
		[Token(Token = "0x4001B5F")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CA160", Offset = "0x7CA160")]
		[Token(Token = "0x4001B60")]
		[FieldOffset(Offset = "0x60")]
		public FsmString variableName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CA19C", Offset = "0x7CA19C")]
		[Token(Token = "0x4001B61")]
		[FieldOffset(Offset = "0x68")]
		public FsmObject storeValue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CA1D8", Offset = "0x7CA1D8")]
		[Token(Token = "0x4001B62")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001B63")]
		[FieldOffset(Offset = "0x78")]
		private GameObject goLastFrame;

		[Token(Token = "0x4001B64")]
		[FieldOffset(Offset = "0x80")]
		private string fsmNameLastFrame;

		[Token(Token = "0x4001B65")]
		[FieldOffset(Offset = "0x88")]
		protected PlayMakerFSM fsm;

		[Token(Token = "0x60010BE")]
		[Address(RVA = "0xA2D1F4", Offset = "0xA2D1F4", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EAC7B0]);\n\tv19 = *([v18 @ X8_v4]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021DCA]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.fsmName = v43;\n\tv46 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.variableName = v46;\n\tthis.storeValue = 0;\n\tthis.everyFrame = 0;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			fsmName = fsmString;
			FsmString fsmString2 = "";
			variableName = fsmString2;
			storeValue = null;
			everyFrame = false;
		}

		[Token(Token = "0x60010BF")]
		[Address(RVA = "0xA2D264", Offset = "0xA2D264", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetFsmObject::DoGetFsmVariable(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetFsmVariable();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60010C0")]
		[Address(RVA = "0xA2D470", Offset = "0xA2D470", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetFsmObject::DoGetFsmVariable(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetFsmVariable();
		}

		[Token(Token = "0x60010C1")]
		[Address(RVA = "0xA2D2A0", Offset = "0xA2D2A0", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EC4718]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021DCB]) = v42;\nL_001A:\n\tv47 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002C;\n\tv113 = *([v80 @ X8_v5+E0]);\n\tv114 = v113 == 0;\n\tv115 = ~v114;\n\tif (v115) goto L_002C;\n\tv123 = v80;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v123, v45, v46, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002C:\n\tv122 = UnityEngine.Object::op_Equality(v47, 0);\n\tv125 = v122 == 0;\n\tv126 = ~v125;\n\tif (v126) goto L_009E;\n\tgoto L_003F;\n\tv163 = *([v150 @ X0_v13+E0]);\n\tv164 = v163 == 0;\n\tv165 = ~v164;\n\tif (v165) goto L_003F;\n\tv167 = \"il2cpp_codegen_runtime_class_init\"(v150, v120, v121, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_003F:\n\tv170 = UnityEngine.Object::op_Inequality(v47, this.goLastFrame);\n\tv172 = v170 == 0;\n\tv173 = ~v172;\n\tif (v173) goto L_0050;\n\tv181 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tv177 = System.String::op_Inequality(v181, this.fsmNameLastFrame);\n\tv179 = v177 == 0;\n\tif (v179) goto L_0066;\nL_0050:\n\tthis.goLastFrame = v47;\n\tv95 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tthis.fsmNameLastFrame = v95;\n\tv185 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tv192 = HutongGames.PlayMaker.ActionHelpers::GetGameObjectFsm(v47, v185);\n\tv50 = this + 0x88;\n\tthis.fsm = v192;\n\tgoto L_006C;\nL_0066:\n\tv50 = this + 0x88;\n\tv77 = this.fsm;\nL_006C:\n\tgoto L_0075;\n\tv205 = *([v200 @ X0_v18+E0]);\n\tv206 = v205 == 0;\n\tv207 = ~v206;\n\tgoto L_0075;\n\tv209 = \"il2cpp_codegen_runtime_class_init\"(v200, v195, v194, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0075:\n\tv155 = UnityEngine.Object::op_Equality(v77, 0);\n\tv213 = v155 == 0;\n\tv157 = ~v213;\n\tif (v157) goto L_009E;\n\tv158 = this.storeValue == 0;\n\tif (v158) goto L_009E;\n\tv96 = PlayMakerFSM::get_FsmVariables(*([v50 @ X21_v6]));\n\tv97 = HutongGames.PlayMaker.FsmString::get_Value(this.variableName);\n\tv156 = HutongGames.PlayMaker.FsmVariables::GetFsmObject(v96, v97);\n\tv159 = v156 == 0;\n\tif (v159) goto L_009E;\n\tv105 = this.storeValue;\n\tv98 = HutongGames.PlayMaker.FsmObject::get_Value(v156);\n\tv105.value = v98;\nL_009E:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetFsmVariable()
		{
			//IL_0137: Expected O, but got I
			//IL_015a: Expected O, but got I
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
			if (!(playMakerFSM == null) && storeValue != null)
			{
				FsmVariables fsmVariables = ((PlayMakerFSM)obj).FsmVariables;
				string value4 = variableName.Value;
				FsmObject fsmObject = fsmVariables.GetFsmObject(value4);
				if (fsmObject != null)
				{
					FsmObject fsmObject2 = storeValue;
					UnityEngine.Object value5 = fsmObject.Value;
					fsmObject2.Value = value5;
				}
			}
		}

		[Token(Token = "0x60010C2")]
		[Address(RVA = "0xA2D474", Offset = "0xA2D474", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetFsmObject()
		{
		}
	}
}
