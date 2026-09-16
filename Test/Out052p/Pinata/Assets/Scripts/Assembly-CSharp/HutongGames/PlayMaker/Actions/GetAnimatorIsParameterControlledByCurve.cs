using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x752D84", Offset = "0x752D84")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x752D84", Offset = "0x752D84")]
	[Token(Token = "0x200014A")]
	public class GetAnimatorIsParameterControlledByCurve : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A62F0", Offset = "0x7A62F0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A62F0", Offset = "0x7A62F0")]
		[Token(Token = "0x4001192")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A6388", Offset = "0x7A6388")]
		[Token(Token = "0x4001193")]
		[FieldOffset(Offset = "0x58")]
		public FsmString parameterName;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7A63C0", Offset = "0x7A63C0")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A63C0", Offset = "0x7A63C0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A63C0", Offset = "0x7A63C0")]
		[Token(Token = "0x4001194")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool isControlledByCurve;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A6434", Offset = "0x7A6434")]
		[Token(Token = "0x4001195")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent isControlledByCurveEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A646C", Offset = "0x7A646C")]
		[Token(Token = "0x4001196")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent isNotControlledByCurveEvent;

		[Token(Token = "0x4001197")]
		[FieldOffset(Offset = "0x78")]
		private Animator _animator;

		[Token(Token = "0x6000759")]
		[Address(RVA = "0xB80D38", Offset = "0xB80D38", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.isNotControlledByCurveEvent = 0;\n\tthis.gameObject = 0;\n\tthis.isControlledByCurve = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			isNotControlledByCurveEvent = null;
			gameObject = null;
			isControlledByCurve = null;
		}

		[Token(Token = "0x600075A")]
		[Address(RVA = "0xB80D48", Offset = "0xB80D48", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EB01D8]);\n\tv21 = *([v20 @ X8_v13]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20229B1]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv68 = *([v60 @ X8_v4+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_002B;\n\tv97 = v60;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v97, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv75 = UnityEngine.Object::op_Equality(v45, 0);\n\tv99 = v75 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_0055;\n\tv115 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._animator = v115;\n\tgoto L_0046;\n\tv120 = *([v116 @ X0_v14+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tif (v122) goto L_0046;\n\tv124 = \"il2cpp_codegen_runtime_class_init\"(v116, v114, v52, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv106 = UnityEngine.Object::op_Equality(v115, 0);\n\tv128 = v106 == 0;\n\tv107 = ~v128;\n\tif (v107) goto L_0055;\n\tHutongGames.PlayMaker.Actions.GetAnimatorIsParameterControlledByCurve::DoCheckIsParameterControlledByCurve(this);\nL_0055:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null) && !((_animator = ownerDefaultTarget.GetComponent<Animator>()) == null))
			{
				DoCheckIsParameterControlledByCurve();
			}
			Finish();
		}

		[Token(Token = "0x600075B")]
		[Address(RVA = "0xB80E44", Offset = "0xB80E44", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1F04660]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20229B2]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Equality(this._animator, 0);\n\tv58 = v56 == 0;\n\tif (v58) goto L_0032;\n\treturn;\nL_0032:\n\tv99 = HutongGames.PlayMaker.FsmString::get_Value(this.parameterName);\n\tv112 = UnityEngine.Animator::IsParameterControlledByCurve(this._animator, v99);\n\tv71 = this.isControlledByCurve;\n\tv71.value = v112;\n\tv117 = v112 == 0;\n\tif (v117) goto L_0049;\n\tv79 = this.isControlledByCurveEvent;\n\tgoto L_0050;\nL_0049:\n\tv79 = this.isNotControlledByCurveEvent;\nL_0050:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, v79);\n\treturn;\n\tv105 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoCheckIsParameterControlledByCurve()
		{
			if (!(_animator == null))
			{
				string value = parameterName.Value;
				bool flag = _animator.IsParameterControlledByCurve(value);
				FsmBool fsmBool = isControlledByCurve;
				fsmBool.value = flag;
				FsmEvent fsmEvent = ((!flag) ? isNotControlledByCurveEvent : isControlledByCurveEvent);
				Fsm.Event(fsmEvent);
			}
		}

		[Token(Token = "0x600075C")]
		[Address(RVA = "0xB80F30", Offset = "0xB80F30", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetAnimatorIsParameterControlledByCurve()
		{
		}
	}
}
