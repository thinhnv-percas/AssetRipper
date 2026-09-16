using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75DBF8", Offset = "0x75DBF8")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x75DBF8", Offset = "0x75DBF8")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75DBF8", Offset = "0x75DBF8")]
	[Token(Token = "0x2000358")]
	public class GetFsmEnum : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C9BA4", Offset = "0x7C9BA4")]
		[Token(Token = "0x4001B36")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C9BF0", Offset = "0x7C9BF0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C9BF0", Offset = "0x7C9BF0")]
		[Token(Token = "0x4001B37")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C9C40", Offset = "0x7C9C40")]
		[Token(Token = "0x4001B38")]
		[FieldOffset(Offset = "0x60")]
		public FsmString variableName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C9C7C", Offset = "0x7C9C7C")]
		[Token(Token = "0x4001B39")]
		[FieldOffset(Offset = "0x68")]
		public FsmEnum storeValue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C9CB8", Offset = "0x7C9CB8")]
		[Token(Token = "0x4001B3A")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001B3B")]
		[FieldOffset(Offset = "0x78")]
		private GameObject goLastFrame;

		[Token(Token = "0x4001B3C")]
		[FieldOffset(Offset = "0x80")]
		private string fsmNameLastFrame;

		[Token(Token = "0x4001B3D")]
		[FieldOffset(Offset = "0x88")]
		private PlayMakerFSM fsm;

		[Token(Token = "0x60010A5")]
		[Address(RVA = "0xA2C538", Offset = "0xA2C538", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F0C928]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021DC0]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.fsmName = v43;\n\tthis.storeValue = 0;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			fsmName = fsmString;
			storeValue = null;
		}

		[Token(Token = "0x60010A6")]
		[Address(RVA = "0xA2C598", Offset = "0xA2C598", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetFsmEnum::DoGetFsmEnum(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetFsmEnum();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60010A7")]
		[Address(RVA = "0xA2C7BC", Offset = "0xA2C7BC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetFsmEnum::DoGetFsmEnum(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetFsmEnum();
		}

		[Token(Token = "0x60010A8")]
		[Address(RVA = "0xA2C5D4", Offset = "0xA2C5D4", Length = "0x1E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EA4278]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021DC1]) = v42;\nL_0016:\n\tv44 = this.storeValue == 0;\n\tif (v44) goto L_00A9;\n\tv86 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002F;\n\tv158 = *([v71 @ X8_v7+E0]);\n\tv159 = v158 == 0;\n\tv160 = ~v159;\n\tif (v160) goto L_002F;\n\tv165 = v71;\n\tv162 = \"il2cpp_codegen_runtime_class_init\"(v165, v84, v85, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002F:\n\tv63 = UnityEngine.Object::op_Equality(v86, 0);\n\tv167 = v63 == 0;\n\tv67 = ~v167;\n\tif (v67) goto L_00A9;\n\tgoto L_0042;\n\tv172 = *([v168 @ X0_v13+E0]);\n\tv173 = v172 == 0;\n\tv174 = ~v173;\n\tif (v174) goto L_0042;\n\tv176 = \"il2cpp_codegen_runtime_class_init\"(v168, v59, v55, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0042:\n\tv179 = UnityEngine.Object::op_Inequality(v86, this.goLastFrame);\n\tv181 = v179 == 0;\n\tv182 = ~v181;\n\tif (v182) goto L_0053;\n\tv190 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tv186 = System.String::op_Inequality(v190, this.fsmNameLastFrame);\n\tv188 = v186 == 0;\n\tif (v188) goto L_0069;\nL_0053:\n\tthis.goLastFrame = v86;\n\tv148 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tthis.fsmNameLastFrame = v148;\n\tv194 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tv201 = HutongGames.PlayMaker.ActionHelpers::GetGameObjectFsm(v86, v194);\n\tv48 = this + 0x88;\n\tthis.fsm = v201;\n\tgoto L_006F;\nL_0069:\n\tv48 = this + 0x88;\n\tv76 = this.fsm;\nL_006F:\n\tgoto L_0078;\n\tv214 = *([v209 @ X0_v18+E0]);\n\tv215 = v214 == 0;\n\tv216 = ~v215;\n\tgoto L_0078;\n\tv218 = \"il2cpp_codegen_runtime_class_init\"(v209, v204, v203, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0078:\n\tv64 = UnityEngine.Object::op_Equality(v76, 0);\n\tv222 = v64 == 0;\n\tv68 = ~v222;\n\tif (v68) goto L_00A9;\n\tv149 = PlayMakerFSM::get_FsmVariables(*([v48 @ X21_v6]));\n\tv150 = HutongGames.PlayMaker.FsmString::get_Value(this.variableName);\n\tv65 = HutongGames.PlayMaker.FsmVariables::GetFsmEnum(v149, v150);\n\tv69 = v65 == 0;\n\tif (v69) goto L_00A9;\n\tv151 = HutongGames.PlayMaker.FsmEnum::get_Value(v65);\n\tHutongGames.PlayMaker.FsmEnum::set_Value(this.storeValue, v151);\n\treturn;\nL_00A9:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 108 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetFsmEnum()
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
				FsmEnum fsmEnum = fsmVariables.GetFsmEnum(value4);
				if (fsmEnum != null)
				{
					Enum value5 = fsmEnum.Value;
					storeValue.Value = value5;
				}
			}
		}

		[Token(Token = "0x60010A9")]
		[Address(RVA = "0xA2C7C0", Offset = "0xA2C7C0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetFsmEnum()
		{
		}
	}
}
