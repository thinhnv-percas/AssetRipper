using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x752A64", Offset = "0x752A64")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x752A64", Offset = "0x752A64")]
	[Token(Token = "0x2000140")]
	public class GetAnimatorDelta : FsmStateActionAnimatorBase
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A541C", Offset = "0x7A541C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A541C", Offset = "0x7A541C")]
		[Token(Token = "0x4001161")]
		[FieldOffset(Offset = "0x58")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A54B4", Offset = "0x7A54B4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A54B4", Offset = "0x7A54B4")]
		[Token(Token = "0x4001162")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 deltaPosition;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A5504", Offset = "0x7A5504")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A5504", Offset = "0x7A5504")]
		[Token(Token = "0x4001163")]
		[FieldOffset(Offset = "0x68")]
		public FsmQuaternion deltaRotation;

		[Token(Token = "0x4001164")]
		[FieldOffset(Offset = "0x70")]
		private Animator _animator;

		[Token(Token = "0x600072A")]
		[Address(RVA = "0xB7F804", Offset = "0xB7F804", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.everyFrameOption = 0;\n\tthis.deltaPosition = 0;\n\tthis.deltaRotation = 0;\n\tthis.gameObject = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			everyFrameOption = default(AnimatorFrameUpdateSelector);
			deltaPosition = null;
			deltaRotation = null;
			gameObject = null;
		}

		[Token(Token = "0x600072B")]
		[Address(RVA = "0xB7F818", Offset = "0xB7F818", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1ED9318]);\n\tv21 = *([v20 @ X8_v13]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202299D]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv68 = *([v60 @ X8_v4+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_002B;\n\tv97 = v60;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v97, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv75 = UnityEngine.Object::op_Equality(v45, 0);\n\tv99 = v75 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_0055;\n\tv115 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._animator = v115;\n\tgoto L_0046;\n\tv120 = *([v116 @ X0_v14+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tif (v122) goto L_0046;\n\tv124 = \"il2cpp_codegen_runtime_class_init\"(v116, v114, v52, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv106 = UnityEngine.Object::op_Equality(v115, 0);\n\tv128 = v106 == 0;\n\tv107 = ~v128;\n\tif (v107) goto L_0055;\n\tHutongGames.PlayMaker.Actions.GetAnimatorDelta::DoGetDeltaPosition(this);\nL_0055:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null) && !((_animator = ownerDefaultTarget.GetComponent<Animator>()) == null))
			{
				DoGetDeltaPosition();
			}
			Finish();
		}

		[Token(Token = "0x600072C")]
		[Address(RVA = "0xB7F9D8", Offset = "0xB7F9D8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetAnimatorDelta::DoGetDeltaPosition(this);\n\treturn;\n")]
		public override void OnActionUpdate()
		{
			DoGetDeltaPosition();
		}

		[Token(Token = "0x600072D")]
		[Address(RVA = "0xB7F914", Offset = "0xB7F914", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EABFC8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202299E]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Equality(this._animator, 0);\n\tv58 = v56 == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_0049;\n\tv79 = this.deltaPosition;\n\tv85 = UnityEngine.Animator::get_deltaPosition(this._animator);\n\tv79.value = v85;\n\tv79.value.y = v85.y;\n\tv79.value.z = v85.z;\n\tv77 = this.deltaRotation;\n\tv69 = UnityEngine.Animator::get_deltaRotation(this._animator);\n\tv77.value = v69;\n\tv77.value.y = v69.y;\n\tv77.value.z = v69.z;\n\tv77.value.w = v69.w;\nL_0049:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetDeltaPosition()
		{
			if (!(_animator == null))
			{
				FsmVector3 fsmVector = deltaPosition;
				Vector3 vector = (fsmVector.value = _animator.deltaPosition);
				fsmVector.value.y = vector.y;
				fsmVector.value.z = vector.z;
				FsmQuaternion fsmQuaternion = deltaRotation;
				Quaternion quaternion = (fsmQuaternion.value = _animator.deltaRotation);
				fsmQuaternion.value.y = quaternion.y;
				fsmQuaternion.value.z = quaternion.z;
				fsmQuaternion.value.w = quaternion.w;
			}
		}

		[Token(Token = "0x600072E")]
		[Address(RVA = "0xB7F9DC", Offset = "0xB7F9DC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetAnimatorDelta()
		{
		}
	}
}
