using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x752B54", Offset = "0x752B54")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x752B54", Offset = "0x752B54")]
	[Token(Token = "0x2000143")]
	public class GetAnimatorGravityWeight : FsmStateActionAnimatorBase
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A57C8", Offset = "0x7A57C8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A57C8", Offset = "0x7A57C8")]
		[Token(Token = "0x400116D")]
		[FieldOffset(Offset = "0x58")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7A5860", Offset = "0x7A5860")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A5860", Offset = "0x7A5860")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A5860", Offset = "0x7A5860")]
		[Token(Token = "0x400116E")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat gravityWeight;

		[Token(Token = "0x400116F")]
		[FieldOffset(Offset = "0x68")]
		private Animator _animator;

		[Token(Token = "0x6000738")]
		[Address(RVA = "0xB7FD88", Offset = "0xB7FD88", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrameOption = 0;\n\tthis.everyFrame = 0;\n\tthis.gameObject = 0;\n\tthis.gravityWeight = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrameOption = default(AnimatorFrameUpdateSelector);
			everyFrame = false;
			gameObject = null;
			gravityWeight = null;
		}

		[Token(Token = "0x6000739")]
		[Address(RVA = "0xB7FD98", Offset = "0xB7FD98", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EB1740]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20229A3]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv70 = *([v50 @ X8_v4+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_002B;\n\tv77 = v50;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v77, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv63 = UnityEngine.Object::op_Equality(v45, 0);\n\tv79 = v63 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_005F;\n\tv123 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._animator = v123;\n\tgoto L_0046;\n\tv128 = *([v124 @ X0_v15+E0]);\n\tv129 = v128 == 0;\n\tv130 = ~v129;\n\tif (v130) goto L_0046;\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v124, v122, v59, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv114 = UnityEngine.Object::op_Equality(v123, 0);\n\tv136 = v114 == 0;\n\tv115 = ~v136;\n\tif (v115) goto L_005F;\n\tHutongGames.PlayMaker.Actions.GetAnimatorGravityWeight::DoGetGravityWeight(this);\n\tv98 = ~this.everyFrame;\n\tif (v98) goto L_005F;\n\treturn;\nL_005F:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null) && !((_animator = ownerDefaultTarget.GetComponent<Animator>()) == null))
			{
				DoGetGravityWeight();
				if (everyFrame)
				{
					return;
				}
			}
			Finish();
		}

		[Token(Token = "0x600073A")]
		[Address(RVA = "0xB7FF50", Offset = "0xB7FF50", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetAnimatorGravityWeight::DoGetGravityWeight(this);\n\treturn;\n")]
		public override void OnActionUpdate()
		{
			DoGetGravityWeight();
		}

		[Token(Token = "0x600073B")]
		[Address(RVA = "0xB7FEB0", Offset = "0xB7FEB0", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1ECF400]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20229A4]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Equality(this._animator, 0);\n\tv58 = v56 == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_0036;\n\tv70 = this.gravityWeight;\n\tv63 = UnityEngine.Animator::get_gravityWeight(this._animator);\n\tv70.value = v63;\nL_0036:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetGravityWeight()
		{
			if (!(_animator == null))
			{
				FsmFloat fsmFloat = gravityWeight;
				float value = _animator.gravityWeight;
				fsmFloat.Value = value;
			}
		}

		[Token(Token = "0x600073C")]
		[Address(RVA = "0xB7FF54", Offset = "0xB7FF54", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetAnimatorGravityWeight()
		{
		}
	}
}
