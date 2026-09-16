using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x752D34", Offset = "0x752D34")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x752D34", Offset = "0x752D34")]
	[Token(Token = "0x2000149")]
	public class GetAnimatorIsMatchingTarget : FsmStateActionAnimatorBase
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A6174", Offset = "0x7A6174")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A6174", Offset = "0x7A6174")]
		[Token(Token = "0x400118D")]
		[FieldOffset(Offset = "0x58")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7A620C", Offset = "0x7A620C")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A620C", Offset = "0x7A620C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A620C", Offset = "0x7A620C")]
		[Token(Token = "0x400118E")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool isMatchingActive;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A6280", Offset = "0x7A6280")]
		[Token(Token = "0x400118F")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent matchingActivatedEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A62B8", Offset = "0x7A62B8")]
		[Token(Token = "0x4001190")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent matchingDeactivedEvent;

		[Token(Token = "0x4001191")]
		[FieldOffset(Offset = "0x78")]
		private Animator _animator;

		[Token(Token = "0x6000754")]
		[Address(RVA = "0xB80B28", Offset = "0xB80B28", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.everyFrameOption = 0;\n\tthis.matchingActivatedEvent = 0;\n\tthis.gameObject = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			everyFrame = false;
			everyFrameOption = default(AnimatorFrameUpdateSelector);
			matchingActivatedEvent = null;
			gameObject = null;
		}

		[Token(Token = "0x6000755")]
		[Address(RVA = "0xB80B40", Offset = "0xB80B40", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1ED48B8]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20229AF]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv70 = *([v50 @ X8_v4+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_002B;\n\tv77 = v50;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v77, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv63 = UnityEngine.Object::op_Equality(v45, 0);\n\tv79 = v63 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_005F;\n\tv123 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._animator = v123;\n\tgoto L_0046;\n\tv128 = *([v124 @ X0_v15+E0]);\n\tv129 = v128 == 0;\n\tv130 = ~v129;\n\tif (v130) goto L_0046;\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v124, v122, v59, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv114 = UnityEngine.Object::op_Equality(v123, 0);\n\tv136 = v114 == 0;\n\tv115 = ~v136;\n\tif (v115) goto L_005F;\n\tHutongGames.PlayMaker.Actions.GetAnimatorIsMatchingTarget::DoCheckIsMatchingActive(this);\n\tv98 = ~this.everyFrame;\n\tif (v98) goto L_005F;\n\treturn;\nL_005F:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null) && !((_animator = ownerDefaultTarget.GetComponent<Animator>()) == null))
			{
				DoCheckIsMatchingActive();
				if (everyFrame)
				{
					return;
				}
			}
			Finish();
		}

		[Token(Token = "0x6000756")]
		[Address(RVA = "0xB80D2C", Offset = "0xB80D2C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetAnimatorIsMatchingTarget::DoCheckIsMatchingActive(this);\n\treturn;\n")]
		public override void OnActionUpdate()
		{
			DoCheckIsMatchingActive();
		}

		[Token(Token = "0x6000757")]
		[Address(RVA = "0xB80C58", Offset = "0xB80C58", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EDB590]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20229B0]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Equality(this._animator, 0);\n\tv58 = v56 == 0;\n\tif (v58) goto L_0031;\n\treturn;\nL_0031:\n\tv96 = UnityEngine.Animator::get_isMatchingTarget(this._animator);\n\tv71 = this.isMatchingActive;\n\tv71.value = v96;\n\tv110 = v96 == 0;\n\tif (v110) goto L_0042;\n\tv78 = this.matchingActivatedEvent;\n\tgoto L_0049;\nL_0042:\n\tv78 = this.matchingDeactivedEvent;\nL_0049:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, v78);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoCheckIsMatchingActive()
		{
			if (!(_animator == null))
			{
				bool isMatchingTarget = _animator.isMatchingTarget;
				FsmBool fsmBool = isMatchingActive;
				fsmBool.value = isMatchingTarget;
				FsmEvent fsmEvent = ((!isMatchingTarget) ? matchingDeactivedEvent : matchingActivatedEvent);
				Fsm.Event(fsmEvent);
			}
		}

		[Token(Token = "0x6000758")]
		[Address(RVA = "0xB80D30", Offset = "0xB80D30", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetAnimatorIsMatchingTarget()
		{
		}
	}
}
