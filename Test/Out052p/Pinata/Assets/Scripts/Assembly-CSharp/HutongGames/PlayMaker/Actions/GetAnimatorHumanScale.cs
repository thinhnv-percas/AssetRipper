using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x752BA4", Offset = "0x752BA4")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x752BA4", Offset = "0x752BA4")]
	[Token(Token = "0x2000144")]
	public class GetAnimatorHumanScale : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A58D4", Offset = "0x7A58D4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A58D4", Offset = "0x7A58D4")]
		[Token(Token = "0x4001170")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7A596C", Offset = "0x7A596C")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A596C", Offset = "0x7A596C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A596C", Offset = "0x7A596C")]
		[Token(Token = "0x4001171")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat humanScale;

		[Token(Token = "0x4001172")]
		[FieldOffset(Offset = "0x60")]
		private Animator _animator;

		[Token(Token = "0x600073D")]
		[Address(RVA = "0xB7FF5C", Offset = "0xB7FF5C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tthis.humanScale = 0;\n\treturn;\n")]
		public override void Reset()
		{
			gameObject = null;
			humanScale = null;
		}

		[Token(Token = "0x600073E")]
		[Address(RVA = "0xB7FF64", Offset = "0xB7FF64", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1F03058]);\n\tv21 = *([v20 @ X8_v13]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20229A5]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv68 = *([v60 @ X8_v4+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_002B;\n\tv97 = v60;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v97, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv75 = UnityEngine.Object::op_Equality(v45, 0);\n\tv99 = v75 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_0055;\n\tv115 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._animator = v115;\n\tgoto L_0046;\n\tv120 = *([v116 @ X0_v14+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tif (v122) goto L_0046;\n\tv124 = \"il2cpp_codegen_runtime_class_init\"(v116, v114, v52, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv106 = UnityEngine.Object::op_Equality(v115, 0);\n\tv128 = v106 == 0;\n\tv107 = ~v128;\n\tif (v107) goto L_0055;\n\tHutongGames.PlayMaker.Actions.GetAnimatorHumanScale::DoGetHumanScale(this);\nL_0055:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null) && !((_animator = ownerDefaultTarget.GetComponent<Animator>()) == null))
			{
				DoGetHumanScale();
			}
			Finish();
		}

		[Token(Token = "0x600073F")]
		[Address(RVA = "0xB80060", Offset = "0xB80060", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EC61D0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20229A6]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Equality(this._animator, 0);\n\tv58 = v56 == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_0036;\n\tv70 = this.humanScale;\n\tv63 = UnityEngine.Animator::get_humanScale(this._animator);\n\tv70.value = v63;\nL_0036:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetHumanScale()
		{
			if (!(_animator == null))
			{
				FsmFloat fsmFloat = humanScale;
				float value = _animator.humanScale;
				fsmFloat.Value = value;
			}
		}

		[Token(Token = "0x6000740")]
		[Address(RVA = "0xB80100", Offset = "0xB80100", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetAnimatorHumanScale()
		{
		}
	}
}
