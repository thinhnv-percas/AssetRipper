using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75E060", Offset = "0x75E060")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x75E060", Offset = "0x75E060")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75E060", Offset = "0x75E060")]
	[Token(Token = "0x200035E")]
	public class GetFsmQuaternion : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CA210", Offset = "0x7CA210")]
		[Token(Token = "0x4001B66")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CA25C", Offset = "0x7CA25C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CA25C", Offset = "0x7CA25C")]
		[Token(Token = "0x4001B67")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CA2AC", Offset = "0x7CA2AC")]
		[Token(Token = "0x4001B68")]
		[FieldOffset(Offset = "0x60")]
		public FsmString variableName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CA2E8", Offset = "0x7CA2E8")]
		[Token(Token = "0x4001B69")]
		[FieldOffset(Offset = "0x68")]
		public FsmQuaternion storeValue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CA324", Offset = "0x7CA324")]
		[Token(Token = "0x4001B6A")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001B6B")]
		[FieldOffset(Offset = "0x78")]
		private GameObject goLastFrame;

		[Token(Token = "0x4001B6C")]
		[FieldOffset(Offset = "0x80")]
		private string fsmNameLastFrame;

		[Token(Token = "0x4001B6D")]
		[FieldOffset(Offset = "0x88")]
		protected PlayMakerFSM fsm;

		[Token(Token = "0x60010C3")]
		[Address(RVA = "0xA2D47C", Offset = "0xA2D47C", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F0FFB8]);\n\tv19 = *([v18 @ X8_v4]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021DCC]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.fsmName = v43;\n\tv46 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.variableName = v46;\n\tthis.storeValue = 0;\n\tthis.everyFrame = 0;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60010C4")]
		[Address(RVA = "0xA2D4EC", Offset = "0xA2D4EC", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetFsmQuaternion::DoGetFsmVariable(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetFsmVariable();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60010C5")]
		[Address(RVA = "0xA2D704", Offset = "0xA2D704", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetFsmQuaternion::DoGetFsmVariable(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetFsmVariable();
		}

		[Token(Token = "0x60010C6")]
		[Address(RVA = "0xA2D528", Offset = "0xA2D528", Length = "0x1DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EE7978]);\n\tv23 = *([v22 @ X8_v20]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021DCD]) = v42;\nL_001A:\n\tv47 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002C;\n\tv111 = *([v80 @ X8_v5+E0]);\n\tv112 = v111 == 0;\n\tv113 = ~v112;\n\tif (v113) goto L_002C;\n\tv121 = v80;\n\tv115 = \"il2cpp_codegen_runtime_class_init\"(v121, v45, v46, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002C:\n\tv120 = UnityEngine.Object::op_Equality(v47, 0);\n\tv123 = v120 == 0;\n\tv124 = ~v123;\n\tif (v124) goto L_00A1;\n\tgoto L_003F;\n\tv169 = *([v155 @ X0_v13+E0]);\n\tv170 = v169 == 0;\n\tv171 = ~v170;\n\tif (v171) goto L_003F;\n\tv173 = \"il2cpp_codegen_runtime_class_init\"(v155, v118, v119, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_003F:\n\tv176 = UnityEngine.Object::op_Inequality(v47, this.goLastFrame);\n\tv178 = v176 == 0;\n\tv179 = ~v178;\n\tif (v179) goto L_0050;\n\tv187 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tv183 = System.String::op_Inequality(v187, this.fsmNameLastFrame);\n\tv185 = v183 == 0;\n\tif (v185) goto L_0066;\nL_0050:\n\tthis.goLastFrame = v47;\n\tv94 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tthis.fsmNameLastFrame = v94;\n\tv191 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tv198 = HutongGames.PlayMaker.ActionHelpers::GetGameObjectFsm(v47, v191);\n\tv50 = this + 0x88;\n\tthis.fsm = v198;\n\tgoto L_006C;\nL_0066:\n\tv50 = this + 0x88;\n\tv77 = this.fsm;\nL_006C:\n\tgoto L_0075;\n\tv211 = *([v206 @ X0_v18+E0]);\n\tv212 = v211 == 0;\n\tv213 = ~v212;\n\tgoto L_0075;\n\tv215 = \"il2cpp_codegen_runtime_class_init\"(v206, v201, v200, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0075:\n\tv163 = UnityEngine.Object::op_Equality(v77, 0);\n\tv219 = v163 == 0;\n\tv164 = ~v219;\n\tif (v164) goto L_00A1;\n\tv165 = this.storeValue == 0;\n\tif (v165) goto L_00A1;\n\tv95 = PlayMakerFSM::get_FsmVariables(*([v50 @ X21_v6]));\n\tv96 = HutongGames.PlayMaker.FsmString::get_Value(this.variableName);\n\tv97 = HutongGames.PlayMaker.FsmVariables::GetFsmQuaternion(v95, v96);\n\tv166 = v97 == 0;\n\tif (v166) goto L_00A1;\n\tv106 = this.storeValue;\n\tv106.value.x = v97.value;\n\tv106.value.y = v97.value.y;\n\tv106.value.w = v97.value.w;\nL_00A1:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 99 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
				FsmQuaternion fsmQuaternion = fsmVariables.GetFsmQuaternion(value4);
				if (fsmQuaternion != null)
				{
					FsmQuaternion fsmQuaternion2 = storeValue;
					fsmQuaternion2.value.x = fsmQuaternion.value.x;
					fsmQuaternion2.value.y = fsmQuaternion.value.y;
					fsmQuaternion2.value.w = fsmQuaternion.value.w;
				}
			}
		}

		[Token(Token = "0x60010C7")]
		[Address(RVA = "0xA2D708", Offset = "0xA2D708", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetFsmQuaternion()
		{
		}
	}
}
