using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75DD70", Offset = "0x75DD70")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x75DD70", Offset = "0x75DD70")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75DD70", Offset = "0x75DD70")]
	[Token(Token = "0x200035A")]
	public class GetFsmGameObject : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4001B46")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C9DD8", Offset = "0x7C9DD8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C9DD8", Offset = "0x7C9DD8")]
		[Token(Token = "0x4001B47")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C9E28", Offset = "0x7C9E28")]
		[Token(Token = "0x4001B48")]
		[FieldOffset(Offset = "0x60")]
		public FsmString variableName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C9E64", Offset = "0x7C9E64")]
		[Token(Token = "0x4001B49")]
		[FieldOffset(Offset = "0x68")]
		public FsmGameObject storeValue;

		[Token(Token = "0x4001B4A")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001B4B")]
		[FieldOffset(Offset = "0x78")]
		private GameObject goLastFrame;

		[Token(Token = "0x4001B4C")]
		[FieldOffset(Offset = "0x80")]
		private string fsmNameLastFrame;

		[Token(Token = "0x4001B4D")]
		[FieldOffset(Offset = "0x88")]
		private PlayMakerFSM fsm;

		[Token(Token = "0x60010AF")]
		[Address(RVA = "0xA2CA4C", Offset = "0xA2CA4C", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EC00F8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021DC4]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.fsmName = v43;\n\tthis.storeValue = 0;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			fsmName = fsmString;
			storeValue = null;
		}

		[Token(Token = "0x60010B0")]
		[Address(RVA = "0xA2CAAC", Offset = "0xA2CAAC", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetFsmGameObject::DoGetFsmGameObject(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetFsmGameObject();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60010B1")]
		[Address(RVA = "0xA2CCD0", Offset = "0xA2CCD0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetFsmGameObject::DoGetFsmGameObject(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetFsmGameObject();
		}

		[Token(Token = "0x60010B2")]
		[Address(RVA = "0xA2CAE8", Offset = "0xA2CAE8", Length = "0x1E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1F0F438]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021DC5]) = v42;\nL_0016:\n\tv44 = this.storeValue == 0;\n\tif (v44) goto L_00A9;\n\tv86 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002F;\n\tv158 = *([v71 @ X8_v7+E0]);\n\tv159 = v158 == 0;\n\tv160 = ~v159;\n\tif (v160) goto L_002F;\n\tv165 = v71;\n\tv162 = \"il2cpp_codegen_runtime_class_init\"(v165, v84, v85, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002F:\n\tv63 = UnityEngine.Object::op_Equality(v86, 0);\n\tv167 = v63 == 0;\n\tv67 = ~v167;\n\tif (v67) goto L_00A9;\n\tgoto L_0042;\n\tv172 = *([v168 @ X0_v13+E0]);\n\tv173 = v172 == 0;\n\tv174 = ~v173;\n\tif (v174) goto L_0042;\n\tv176 = \"il2cpp_codegen_runtime_class_init\"(v168, v59, v55, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0042:\n\tv179 = UnityEngine.Object::op_Inequality(v86, this.goLastFrame);\n\tv181 = v179 == 0;\n\tv182 = ~v181;\n\tif (v182) goto L_0053;\n\tv190 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tv186 = System.String::op_Inequality(v190, this.fsmNameLastFrame);\n\tv188 = v186 == 0;\n\tif (v188) goto L_0069;\nL_0053:\n\tthis.goLastFrame = v86;\n\tv148 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tthis.fsmNameLastFrame = v148;\n\tv194 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tv201 = HutongGames.PlayMaker.ActionHelpers::GetGameObjectFsm(v86, v194);\n\tv48 = this + 0x88;\n\tthis.fsm = v201;\n\tgoto L_006F;\nL_0069:\n\tv48 = this + 0x88;\n\tv76 = this.fsm;\nL_006F:\n\tgoto L_0078;\n\tv214 = *([v209 @ X0_v18+E0]);\n\tv215 = v214 == 0;\n\tv216 = ~v215;\n\tgoto L_0078;\n\tv218 = \"il2cpp_codegen_runtime_class_init\"(v209, v204, v203, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0078:\n\tv64 = UnityEngine.Object::op_Equality(v76, 0);\n\tv222 = v64 == 0;\n\tv68 = ~v222;\n\tif (v68) goto L_00A9;\n\tv149 = PlayMakerFSM::get_FsmVariables(*([v48 @ X21_v6]));\n\tv150 = HutongGames.PlayMaker.FsmString::get_Value(this.variableName);\n\tv65 = HutongGames.PlayMaker.FsmVariables::GetFsmGameObject(v149, v150);\n\tv69 = v65 == 0;\n\tif (v69) goto L_00A9;\n\tv151 = HutongGames.PlayMaker.FsmGameObject::get_Value(v65);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.storeValue, v151);\n\treturn;\nL_00A9:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 108 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetFsmGameObject()
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
				FsmGameObject fsmGameObject = fsmVariables.GetFsmGameObject(value4);
				if (fsmGameObject != null)
				{
					GameObject value5 = fsmGameObject.Value;
					storeValue.Value = value5;
				}
			}
		}

		[Token(Token = "0x60010B3")]
		[Address(RVA = "0xA2CCD4", Offset = "0xA2CCD4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetFsmGameObject()
		{
		}
	}
}
