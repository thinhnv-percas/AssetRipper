using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75DCB4", Offset = "0x75DCB4")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x75DCB4", Offset = "0x75DCB4")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75DCB4", Offset = "0x75DCB4")]
	[Token(Token = "0x2000359")]
	public class GetFsmFloat : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4001B3E")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C9D00", Offset = "0x7C9D00")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C9D00", Offset = "0x7C9D00")]
		[Token(Token = "0x4001B3F")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C9D50", Offset = "0x7C9D50")]
		[Token(Token = "0x4001B40")]
		[FieldOffset(Offset = "0x60")]
		public FsmString variableName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C9D8C", Offset = "0x7C9D8C")]
		[Token(Token = "0x4001B41")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat storeValue;

		[Token(Token = "0x4001B42")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001B43")]
		[FieldOffset(Offset = "0x78")]
		private GameObject goLastFrame;

		[Token(Token = "0x4001B44")]
		[FieldOffset(Offset = "0x80")]
		private string fsmNameLastFrame;

		[Token(Token = "0x4001B45")]
		[FieldOffset(Offset = "0x88")]
		private PlayMakerFSM fsm;

		[Token(Token = "0x60010AA")]
		[Address(RVA = "0xA2C7C8", Offset = "0xA2C7C8", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EC44F0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021DC2]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.fsmName = v43;\n\tthis.storeValue = 0;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			fsmName = fsmString;
			storeValue = null;
		}

		[Token(Token = "0x60010AB")]
		[Address(RVA = "0xA2C828", Offset = "0xA2C828", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetFsmFloat::DoGetFsmFloat(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetFsmFloat();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60010AC")]
		[Address(RVA = "0xA2CA40", Offset = "0xA2CA40", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetFsmFloat::DoGetFsmFloat(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetFsmFloat();
		}

		[Token(Token = "0x60010AD")]
		[Address(RVA = "0xA2C864", Offset = "0xA2C864", Length = "0x1DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EB7E08]);\n\tv23 = *([v22 @ X8_v18]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021DC3]) = v42;\nL_0019:\n\tv46 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.storeValue);\n\tv81 = v46 == 0;\n\tv82 = ~v81;\n\tif (v82) goto L_00A4;\n\tv141 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_0035;\n\tv159 = *([v131 @ X8_v6+E0]);\n\tv160 = v159 == 0;\n\tv161 = ~v160;\n\tif (v161) goto L_0035;\n\tv166 = v131;\n\tv163 = \"il2cpp_codegen_runtime_class_init\"(v166, v139, v140, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0035:\n\tv123 = UnityEngine.Object::op_Equality(v141, 0);\n\tv168 = v123 == 0;\n\tv126 = ~v168;\n\tif (v126) goto L_00A4;\n\tgoto L_0048;\n\tv173 = *([v169 @ X0_v15+E0]);\n\tv174 = v173 == 0;\n\tv175 = ~v174;\n\tif (v175) goto L_0048;\n\tv177 = \"il2cpp_codegen_runtime_class_init\"(v169, v121, v119, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0048:\n\tv180 = UnityEngine.Object::op_Inequality(v141, this.goLastFrame);\n\tv182 = v180 == 0;\n\tv183 = ~v182;\n\tif (v183) goto L_0059;\n\tv191 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tv187 = System.String::op_Inequality(v191, this.fsmNameLastFrame);\n\tv189 = v187 == 0;\n\tif (v189) goto L_006F;\nL_0059:\n\tthis.goLastFrame = v141;\n\tv96 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tthis.fsmNameLastFrame = v96;\n\tv195 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tv202 = HutongGames.PlayMaker.ActionHelpers::GetGameObjectFsm(v141, v195);\n\tv49 = this + 0x88;\n\tthis.fsm = v202;\n\tgoto L_0075;\nL_006F:\n\tv49 = this + 0x88;\n\tv78 = this.fsm;\nL_0075:\n\tgoto L_007E;\n\tv215 = *([v210 @ X0_v20+E0]);\n\tv216 = v215 == 0;\n\tv217 = ~v216;\n\tgoto L_007E;\n\tv219 = \"il2cpp_codegen_runtime_class_init\"(v210, v205, v204, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_007E:\n\tv124 = UnityEngine.Object::op_Equality(v78, 0);\n\tv223 = v124 == 0;\n\tv127 = ~v223;\n\tif (v127) goto L_00A4;\n\tv97 = PlayMakerFSM::get_FsmVariables(*([v49 @ X21_v6]));\n\tv98 = HutongGames.PlayMaker.FsmString::get_Value(this.variableName);\n\tv99 = HutongGames.PlayMaker.FsmVariables::GetFsmFloat(v97, v98);\n\tv128 = v99 == 0;\n\tif (v128) goto L_00A4;\n\tv106 = this.storeValue;\n\tv84 = HutongGames.PlayMaker.FsmFloat::get_Value(v99);\n\tv106.value = v84;\nL_00A4:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 101 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetFsmFloat()
		{
			//IL_016e: Expected O, but got I
			//IL_0191: Expected O, but got I
			if (storeValue.IsNone)
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
					goto IL_01a0;
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
			goto IL_01a0;
			IL_01a0:
			if (!(playMakerFSM == null))
			{
				FsmVariables fsmVariables = ((PlayMakerFSM)obj).FsmVariables;
				string value4 = variableName.Value;
				FsmFloat fsmFloat = fsmVariables.GetFsmFloat(value4);
				if (fsmFloat != null)
				{
					FsmFloat fsmFloat2 = storeValue;
					float value5 = fsmFloat.Value;
					fsmFloat2.Value = value5;
				}
			}
		}

		[Token(Token = "0x60010AE")]
		[Address(RVA = "0xA2CA44", Offset = "0xA2CA44", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetFsmFloat()
		{
		}
	}
}
