using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75DB3C", Offset = "0x75DB3C")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x75DB3C", Offset = "0x75DB3C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75DB3C", Offset = "0x75DB3C")]
	[Token(Token = "0x2000357")]
	public class GetFsmColor : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4001B2E")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C9ADC", Offset = "0x7C9ADC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C9ADC", Offset = "0x7C9ADC")]
		[Token(Token = "0x4001B2F")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C9B2C", Offset = "0x7C9B2C")]
		[Token(Token = "0x4001B30")]
		[FieldOffset(Offset = "0x60")]
		public FsmString variableName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C9B68", Offset = "0x7C9B68")]
		[Token(Token = "0x4001B31")]
		[FieldOffset(Offset = "0x68")]
		public FsmColor storeValue;

		[Token(Token = "0x4001B32")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001B33")]
		[FieldOffset(Offset = "0x78")]
		private GameObject goLastFrame;

		[Token(Token = "0x4001B34")]
		[FieldOffset(Offset = "0x80")]
		private string fsmNameLastFrame;

		[Token(Token = "0x4001B35")]
		[FieldOffset(Offset = "0x88")]
		private PlayMakerFSM fsm;

		[Token(Token = "0x60010A0")]
		[Address(RVA = "0xA2C2B4", Offset = "0xA2C2B4", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EDA458]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021DBE]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.fsmName = v43;\n\tthis.storeValue = 0;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			fsmName = fsmString;
			storeValue = null;
		}

		[Token(Token = "0x60010A1")]
		[Address(RVA = "0xA2C314", Offset = "0xA2C314", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetFsmColor::DoGetFsmColor(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetFsmColor();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60010A2")]
		[Address(RVA = "0xA2C52C", Offset = "0xA2C52C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetFsmColor::DoGetFsmColor(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetFsmColor();
		}

		[Token(Token = "0x60010A3")]
		[Address(RVA = "0xA2C350", Offset = "0xA2C350", Length = "0x1DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EE3EE0]);\n\tv23 = *([v22 @ X8_v20]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021DBF]) = v42;\nL_0016:\n\tv44 = this.storeValue == 0;\n\tif (v44) goto L_00A1;\n\tv95 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002F;\n\tv156 = *([v80 @ X8_v7+E0]);\n\tv157 = v156 == 0;\n\tv158 = ~v157;\n\tif (v158) goto L_002F;\n\tv163 = v80;\n\tv160 = \"il2cpp_codegen_runtime_class_init\"(v163, v93, v94, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002F:\n\tv71 = UnityEngine.Object::op_Equality(v95, 0);\n\tv165 = v71 == 0;\n\tv75 = ~v165;\n\tif (v75) goto L_00A1;\n\tgoto L_0042;\n\tv170 = *([v166 @ X0_v13+E0]);\n\tv171 = v170 == 0;\n\tv172 = ~v171;\n\tif (v172) goto L_0042;\n\tv174 = \"il2cpp_codegen_runtime_class_init\"(v166, v67, v63, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0042:\n\tv177 = UnityEngine.Object::op_Inequality(v95, this.goLastFrame);\n\tv179 = v177 == 0;\n\tv180 = ~v179;\n\tif (v180) goto L_0053;\n\tv188 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tv184 = System.String::op_Inequality(v188, this.fsmNameLastFrame);\n\tv186 = v184 == 0;\n\tif (v186) goto L_0069;\nL_0053:\n\tthis.goLastFrame = v95;\n\tv148 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tthis.fsmNameLastFrame = v148;\n\tv192 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tv199 = HutongGames.PlayMaker.ActionHelpers::GetGameObjectFsm(v95, v192);\n\tv54 = this + 0x88;\n\tthis.fsm = v199;\n\tgoto L_006F;\nL_0069:\n\tv54 = this + 0x88;\n\tv86 = this.fsm;\nL_006F:\n\tgoto L_0078;\n\tv212 = *([v207 @ X0_v18+E0]);\n\tv213 = v212 == 0;\n\tv214 = ~v213;\n\tgoto L_0078;\n\tv216 = \"il2cpp_codegen_runtime_class_init\"(v207, v202, v201, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0078:\n\tv72 = UnityEngine.Object::op_Equality(v86, 0);\n\tv220 = v72 == 0;\n\tv76 = ~v220;\n\tif (v76) goto L_00A1;\n\tv149 = PlayMakerFSM::get_FsmVariables(*([v54 @ X21_v6]));\n\tv150 = HutongGames.PlayMaker.FsmString::get_Value(this.variableName);\n\tv70 = HutongGames.PlayMaker.FsmVariables::GetFsmColor(v149, v150);\n\tv77 = v70 == 0;\n\tif (v77) goto L_00A1;\n\tv79 = this.storeValue;\n\tv79.value.r = v70.value;\n\tv79.value.g = v70.value.g;\n\tv79.value.a = v70.value.a;\nL_00A1:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 99 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetFsmColor()
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
				FsmColor fsmColor = fsmVariables.GetFsmColor(value4);
				if (fsmColor != null)
				{
					FsmColor fsmColor2 = storeValue;
					fsmColor2.value.r = fsmColor.value.r;
					fsmColor2.value.g = fsmColor.value.g;
					fsmColor2.value.a = fsmColor.value.a;
				}
			}
		}

		[Token(Token = "0x60010A4")]
		[Address(RVA = "0xA2C530", Offset = "0xA2C530", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetFsmColor()
		{
		}
	}
}
