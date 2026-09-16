using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x752CE4", Offset = "0x752CE4")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x752CE4", Offset = "0x752CE4")]
	[Token(Token = "0x2000148")]
	public class GetAnimatorIsLayerInTransition : FsmStateActionAnimatorBase
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A5FAC", Offset = "0x7A5FAC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A5FAC", Offset = "0x7A5FAC")]
		[Token(Token = "0x4001187")]
		[FieldOffset(Offset = "0x58")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A6044", Offset = "0x7A6044")]
		[Token(Token = "0x4001188")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt layerIndex;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7A6090", Offset = "0x7A6090")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A6090", Offset = "0x7A6090")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A6090", Offset = "0x7A6090")]
		[Token(Token = "0x4001189")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool isInTransition;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A6104", Offset = "0x7A6104")]
		[Token(Token = "0x400118A")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent isInTransitionEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A613C", Offset = "0x7A613C")]
		[Token(Token = "0x400118B")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent isNotInTransitionEvent;

		[Token(Token = "0x400118C")]
		[FieldOffset(Offset = "0x80")]
		private Animator _animator;

		[Token(Token = "0x600074F")]
		[Address(RVA = "0xB808E8", Offset = "0xB808E8", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.everyFrameOption = 0;\n\tthis.gameObject = 0;\n\tthis.isInTransitionEvent = 0;\n\tthis.isNotInTransitionEvent = 0;\n\tthis.isInTransition = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			everyFrameOption = default(AnimatorFrameUpdateSelector);
			gameObject = null;
			isInTransitionEvent = null;
			isNotInTransitionEvent = null;
			isInTransition = null;
		}

		[Token(Token = "0x6000750")]
		[Address(RVA = "0xB80900", Offset = "0xB80900", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1F0B218]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20229AD]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv70 = *([v50 @ X8_v4+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_002B;\n\tv77 = v50;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v77, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv63 = UnityEngine.Object::op_Equality(v45, 0);\n\tv79 = v63 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_005F;\n\tv123 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._animator = v123;\n\tgoto L_0046;\n\tv128 = *([v124 @ X0_v15+E0]);\n\tv129 = v128 == 0;\n\tv130 = ~v129;\n\tif (v130) goto L_0046;\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v124, v122, v59, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv114 = UnityEngine.Object::op_Equality(v123, 0);\n\tv136 = v114 == 0;\n\tv115 = ~v136;\n\tif (v115) goto L_005F;\n\tHutongGames.PlayMaker.Actions.GetAnimatorIsLayerInTransition::DoCheckIsInTransition(this);\n\tv98 = ~this.everyFrame;\n\tif (v98) goto L_005F;\n\treturn;\nL_005F:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null) && !((_animator = ownerDefaultTarget.GetComponent<Animator>()) == null))
			{
				DoCheckIsInTransition();
				if (everyFrame)
				{
					return;
				}
			}
			Finish();
		}

		[Token(Token = "0x6000751")]
		[Address(RVA = "0xB80B1C", Offset = "0xB80B1C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetAnimatorIsLayerInTransition::DoCheckIsInTransition(this);\n\treturn;\n")]
		public override void OnActionUpdate()
		{
			DoCheckIsInTransition();
		}

		[Token(Token = "0x6000752")]
		[Address(RVA = "0xB80A18", Offset = "0xB80A18", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EBA5D0]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20229AE]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Equality(this._animator, 0);\n\tv58 = v56 == 0;\n\tif (v58) goto L_0032;\n\treturn;\nL_0032:\n\tv95 = HutongGames.PlayMaker.FsmInt::get_Value(this.layerIndex);\n\tv111 = UnityEngine.Animator::IsInTransition(this._animator, v95);\n\tv113 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.isInTransition);\n\tv121 = v113 == 0;\n\tv122 = ~v121;\n\tif (v122) goto L_004B;\n\tv117 = this.isInTransition;\n\tv117.value = v111;\nL_004B:\n\tv126 = v111 == 0;\n\tif (v126) goto L_0053;\n\tv75 = this.isInTransitionEvent;\n\tgoto L_005A;\nL_0053:\n\tv75 = this.isNotInTransitionEvent;\nL_005A:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, v75);\n\treturn;\n\tv101 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoCheckIsInTransition()
		{
			if (!(_animator == null))
			{
				int value = layerIndex.Value;
				bool flag = _animator.IsInTransition(value);
				if (!isInTransition.IsNone)
				{
					FsmBool fsmBool = isInTransition;
					fsmBool.value = flag;
				}
				FsmEvent fsmEvent = ((!flag) ? isNotInTransitionEvent : isInTransitionEvent);
				Fsm.Event(fsmEvent);
			}
		}

		[Token(Token = "0x6000753")]
		[Address(RVA = "0xB80B20", Offset = "0xB80B20", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetAnimatorIsLayerInTransition()
		{
		}
	}
}
