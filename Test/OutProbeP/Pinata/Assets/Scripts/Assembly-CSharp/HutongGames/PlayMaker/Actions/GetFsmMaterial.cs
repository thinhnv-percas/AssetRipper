using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75DEE8", Offset = "0x75DEE8")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x75DEE8", Offset = "0x75DEE8")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75DEE8", Offset = "0x75DEE8")]
	[Token(Token = "0x200035C")]
	public class GetFsmMaterial : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C9F78", Offset = "0x7C9F78")]
		[Token(Token = "0x4001B56")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C9FC4", Offset = "0x7C9FC4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C9FC4", Offset = "0x7C9FC4")]
		[Token(Token = "0x4001B57")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CA014", Offset = "0x7CA014")]
		[Token(Token = "0x4001B58")]
		[FieldOffset(Offset = "0x60")]
		public FsmString variableName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CA050", Offset = "0x7CA050")]
		[Token(Token = "0x4001B59")]
		[FieldOffset(Offset = "0x68")]
		public FsmMaterial storeValue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CA08C", Offset = "0x7CA08C")]
		[Token(Token = "0x4001B5A")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001B5B")]
		[FieldOffset(Offset = "0x78")]
		private GameObject goLastFrame;

		[Token(Token = "0x4001B5C")]
		[FieldOffset(Offset = "0x80")]
		private string fsmNameLastFrame;

		[Token(Token = "0x4001B5D")]
		[FieldOffset(Offset = "0x88")]
		protected PlayMakerFSM fsm;

		[Token(Token = "0x60010B9")]
		[Address(RVA = "0xA2CF54", Offset = "0xA2CF54", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EDB870]);\n\tv19 = *([v18 @ X8_v4]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021DC8]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.fsmName = v43;\n\tv46 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.variableName = v46;\n\tthis.storeValue = 0;\n\tthis.everyFrame = 0;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60010BA")]
		[Address(RVA = "0xA2CFC4", Offset = "0xA2CFC4", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetFsmMaterial::DoGetFsmVariable(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetFsmVariable();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60010BB")]
		[Address(RVA = "0xA2D1E8", Offset = "0xA2D1E8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetFsmMaterial::DoGetFsmVariable(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetFsmVariable();
		}

		[Token(Token = "0x60010BC")]
		[Address(RVA = "0xA2D000", Offset = "0xA2D000", Length = "0x1E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1F0AB50]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021DC9]) = v42;\nL_001A:\n\tv47 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002C;\n\tv113 = *([v80 @ X8_v5+E0]);\n\tv114 = v113 == 0;\n\tv115 = ~v114;\n\tif (v115) goto L_002C;\n\tv123 = v80;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v123, v45, v46, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002C:\n\tv122 = UnityEngine.Object::op_Equality(v47, 0);\n\tv125 = v122 == 0;\n\tv126 = ~v125;\n\tif (v126) goto L_00A9;\n\tgoto L_003F;\n\tv170 = *([v158 @ X0_v13+E0]);\n\tv171 = v170 == 0;\n\tv172 = ~v171;\n\tif (v172) goto L_003F;\n\tv174 = \"il2cpp_codegen_runtime_class_init\"(v158, v120, v121, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_003F:\n\tv177 = UnityEngine.Object::op_Inequality(v47, this.goLastFrame);\n\tv179 = v177 == 0;\n\tv180 = ~v179;\n\tif (v180) goto L_0050;\n\tv188 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tv184 = System.String::op_Inequality(v188, this.fsmNameLastFrame);\n\tv186 = v184 == 0;\n\tif (v186) goto L_0066;\nL_0050:\n\tthis.goLastFrame = v47;\n\tv95 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tthis.fsmNameLastFrame = v95;\n\tv192 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tv199 = HutongGames.PlayMaker.ActionHelpers::GetGameObjectFsm(v47, v192);\n\tv50 = this + 0x88;\n\tthis.fsm = v199;\n\tgoto L_006C;\nL_0066:\n\tv50 = this + 0x88;\n\tv77 = this.fsm;\nL_006C:\n\tgoto L_0075;\n\tv212 = *([v207 @ X0_v18+E0]);\n\tv213 = v212 == 0;\n\tv214 = ~v213;\n\tgoto L_0075;\n\tv216 = \"il2cpp_codegen_runtime_class_init\"(v207, v202, v201, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0075:\n\tv163 = UnityEngine.Object::op_Equality(v77, 0);\n\tv220 = v163 == 0;\n\tv165 = ~v220;\n\tif (v165) goto L_00A9;\n\tv166 = this.storeValue == 0;\n\tif (v166) goto L_00A9;\n\tv96 = PlayMakerFSM::get_FsmVariables(*([v50 @ X21_v6]));\n\tv97 = HutongGames.PlayMaker.FsmString::get_Value(this.variableName);\n\tv164 = HutongGames.PlayMaker.FsmVariables::GetFsmMaterial(v96, v97);\n\tv167 = v164 == 0;\n\tif (v167) goto L_00A9;\n\tv98 = HutongGames.PlayMaker.FsmMaterial::get_Value(v164);\n\tHutongGames.PlayMaker.FsmMaterial::set_Value(this.storeValue, v98);\n\treturn;\nL_00A9:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 108 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
				FsmMaterial fsmMaterial = fsmVariables.GetFsmMaterial(value4);
				if (fsmMaterial != null)
				{
					Material value5 = fsmMaterial.Value;
					storeValue.Value = value5;
				}
			}
		}

		[Token(Token = "0x60010BD")]
		[Address(RVA = "0xA2D1EC", Offset = "0xA2D1EC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetFsmMaterial()
		{
		}
	}
}
