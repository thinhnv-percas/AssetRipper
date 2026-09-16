using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x752E74", Offset = "0x752E74")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x752E74", Offset = "0x752E74")]
	[Token(Token = "0x200014D")]
	public class GetAnimatorLayersAffectMassCenter : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A6728", Offset = "0x7A6728")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A6728", Offset = "0x7A6728")]
		[Token(Token = "0x400119F")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7A67C0", Offset = "0x7A67C0")]
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A67C0", Offset = "0x7A67C0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A67C0", Offset = "0x7A67C0")]
		[Token(Token = "0x40011A0")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool affectMassCenter;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A6844", Offset = "0x7A6844")]
		[Token(Token = "0x40011A1")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent affectMassCenterEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A687C", Offset = "0x7A687C")]
		[Token(Token = "0x40011A2")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent doNotAffectMassCenterEvent;

		[Token(Token = "0x40011A3")]
		[FieldOffset(Offset = "0x70")]
		private Animator _animator;

		[Token(Token = "0x6000765")]
		[Address(RVA = "0xB81494", Offset = "0xB81494", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tthis.affectMassCenterEvent = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			affectMassCenterEvent = null;
		}

		[Token(Token = "0x6000766")]
		[Address(RVA = "0xB814A0", Offset = "0xB814A0", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EB1FB8]);\n\tv21 = *([v20 @ X8_v13]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20229B9]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv68 = *([v60 @ X8_v4+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_002B;\n\tv97 = v60;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v97, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv75 = UnityEngine.Object::op_Equality(v45, 0);\n\tv99 = v75 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_0055;\n\tv115 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._animator = v115;\n\tgoto L_0046;\n\tv120 = *([v116 @ X0_v14+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tif (v122) goto L_0046;\n\tv124 = \"il2cpp_codegen_runtime_class_init\"(v116, v114, v52, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv106 = UnityEngine.Object::op_Equality(v115, 0);\n\tv128 = v106 == 0;\n\tv107 = ~v128;\n\tif (v107) goto L_0055;\n\tHutongGames.PlayMaker.Actions.GetAnimatorLayersAffectMassCenter::CheckAffectMassCenter(this);\nL_0055:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null) && !((_animator = ownerDefaultTarget.GetComponent<Animator>()) == null))
			{
				CheckAffectMassCenter();
			}
			Finish();
		}

		[Token(Token = "0x6000767")]
		[Address(RVA = "0xB8159C", Offset = "0xB8159C", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EA6230]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20229BA]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Equality(this._animator, 0);\n\tv58 = v56 == 0;\n\tif (v58) goto L_0031;\n\treturn;\nL_0031:\n\tv96 = UnityEngine.Animator::get_layersAffectMassCenter(this._animator);\n\tv71 = this.affectMassCenter;\n\tv71.value = v96;\n\tv110 = v96 == 0;\n\tif (v110) goto L_0042;\n\tv78 = this.affectMassCenterEvent;\n\tgoto L_0049;\nL_0042:\n\tv78 = this.doNotAffectMassCenterEvent;\nL_0049:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, v78);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CheckAffectMassCenter()
		{
			if (!(_animator == null))
			{
				bool layersAffectMassCenter = _animator.layersAffectMassCenter;
				FsmBool fsmBool = affectMassCenter;
				fsmBool.value = layersAffectMassCenter;
				FsmEvent fsmEvent = ((!layersAffectMassCenter) ? doNotAffectMassCenterEvent : affectMassCenterEvent);
				Fsm.Event(fsmEvent);
			}
		}

		[Token(Token = "0x6000768")]
		[Address(RVA = "0xB81670", Offset = "0xB81670", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetAnimatorLayersAffectMassCenter()
		{
		}
	}
}
