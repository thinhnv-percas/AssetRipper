using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x752BF4", Offset = "0x752BF4")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x752BF4", Offset = "0x752BF4")]
	[Token(Token = "0x2000145")]
	public class GetAnimatorIKGoal : FsmStateActionAnimatorBase
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A59E0", Offset = "0x7A59E0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A59E0", Offset = "0x7A59E0")]
		[Token(Token = "0x4001173")]
		[FieldOffset(Offset = "0x58")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A5A78", Offset = "0x7A5A78")]
		[AttributeAttribute(Type = typeof(ObjectTypeAttribute), RVA = "0x7A5A78", Offset = "0x7A5A78")]
		[Token(Token = "0x4001174")]
		[FieldOffset(Offset = "0x60")]
		public FsmEnum iKGoal;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7A5B00", Offset = "0x7A5B00")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A5B00", Offset = "0x7A5B00")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A5B00", Offset = "0x7A5B00")]
		[Token(Token = "0x4001175")]
		[FieldOffset(Offset = "0x68")]
		public FsmGameObject goal;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A5B74", Offset = "0x7A5B74")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A5B74", Offset = "0x7A5B74")]
		[Token(Token = "0x4001176")]
		[FieldOffset(Offset = "0x70")]
		public FsmVector3 position;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A5BC4", Offset = "0x7A5BC4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A5BC4", Offset = "0x7A5BC4")]
		[Token(Token = "0x4001177")]
		[FieldOffset(Offset = "0x78")]
		public FsmQuaternion rotation;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A5C14", Offset = "0x7A5C14")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A5C14", Offset = "0x7A5C14")]
		[Token(Token = "0x4001178")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat positionWeight;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A5C64", Offset = "0x7A5C64")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A5C64", Offset = "0x7A5C64")]
		[Token(Token = "0x4001179")]
		[FieldOffset(Offset = "0x88")]
		public FsmFloat rotationWeight;

		[Token(Token = "0x400117A")]
		[FieldOffset(Offset = "0x90")]
		private Animator _animator;

		[Token(Token = "0x400117B")]
		[FieldOffset(Offset = "0x98")]
		private Transform _transform;

		[Token(Token = "0x400117C")]
		[FieldOffset(Offset = "0xA0")]
		private AvatarIKGoal _iKGoal;

		[Token(Token = "0x6000741")]
		[Address(RVA = "0xB80108", Offset = "0xB80108", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.everyFrameOption = 0;\n\tthis.rotationWeight = 0;\n\tthis.rotation = 0;\n\tthis.goal = 0;\n\tthis.gameObject = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			everyFrame = false;
			everyFrameOption = default(AnimatorFrameUpdateSelector);
			rotationWeight = null;
			rotation = null;
			goal = null;
			gameObject = null;
		}

		[Token(Token = "0x6000742")]
		[Address(RVA = "0xB80128", Offset = "0xB80128", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1F0E0F0]);\n\tv21 = *([v20 @ X8_v15]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20229A7]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv91 = *([v66 @ X8_v5+E0]);\n\tv92 = v91 == 0;\n\tv93 = ~v92;\n\tif (v93) goto L_002B;\n\tv98 = v66;\n\tv95 = \"il2cpp_codegen_runtime_class_init\"(v98, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv80 = UnityEngine.Object::op_Equality(v45, 0);\n\tv100 = v80 == 0;\n\tv101 = ~v100;\n\tif (v101) goto L_0052;\n\tv140 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._animator = v140;\n\tgoto L_0046;\n\tv145 = *([v141 @ X0_v16+E0]);\n\tv146 = v145 == 0;\n\tv147 = ~v146;\n\tif (v147) goto L_0046;\n\tv149 = \"il2cpp_codegen_runtime_class_init\"(v141, v139, v74, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv133 = UnityEngine.Object::op_Equality(v140, 0);\n\tv134 = v133 == 0;\n\tif (v134) goto L_0058;\nL_0052:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0058:\n\tv154 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.goal);\n\tgoto L_0068;\n\tv158 = *([v86 @ X8_v11+E0]);\n\tv159 = v158 == 0;\n\tv160 = ~v159;\n\tif (v160) goto L_0068;\n\tv165 = v86;\n\tv162 = \"il2cpp_codegen_runtime_class_init\"(v165, v153, v52, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0068:\n\tv81 = UnityEngine.Object::op_Inequality(v154, 0);\n\tv167 = v81 == 0;\n\tif (v167) goto L_0078;\n\tv169 = UnityEngine.GameObject::get_transform(v154);\n\tthis._transform = v169;\nL_0078:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget == null || (_animator = ownerDefaultTarget.GetComponent<Animator>()) == null)
			{
				Finish();
				return;
			}
			GameObject value = goal.Value;
			if (value != null)
			{
				Transform transform = value.transform;
				_transform = transform;
			}
		}

		[Token(Token = "0x6000743")]
		[Address(RVA = "0xB80288", Offset = "0xB80288", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetAnimatorIKGoal::DoGetIKGoal(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnActionUpdate()
		{
			DoGetIKGoal();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000744")]
		[Address(RVA = "0xB802C4", Offset = "0xB802C4", Length = "0x228")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EF6C70]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20229A8]) = v40;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tv58 = UnityEngine.Object::op_Equality(this._animator, 0);\n\tv60 = v58 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_00D1;\n\tv132 = HutongGames.PlayMaker.FsmEnum::get_Value(this.iKGoal);\n\tv80 = v80_asT == 0;\n\tif (v80) goto L_00D5;\n\tv316 = \"il2cpp_vm_object_unbox\"(v132, UnityEngine.AvatarIKGoal, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tthis._iKGoal = *([v316 @ X0_v16]);\n\tgoto L_0052;\n\tv322 = *([v318 @ X0_v17+E0]);\n\tv323 = v322 == 0;\n\tv324 = ~v323;\n\tif (v324) goto L_0052;\n\tv326 = \"il2cpp_codegen_runtime_class_init\"(v318, v312, v57, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0052:\n\tv329 = UnityEngine.Object::op_Inequality(this._transform, 0);\n\tv331 = v329 == 0;\n\tif (v331) goto L_0079;\n\tv147 = UnityEngine.Animator::GetIKPosition(this._animator, this._iKGoal);\n\tUnityEngine.Transform::set_position(this._transform, v147);\n\tv269 = UnityEngine.Animator::GetIKRotation(this._animator, this._iKGoal);\n\tUnityEngine.Transform::set_rotation(this._transform, v269);\nL_0079:\n\tv337 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.position);\n\tv339 = v337 == 0;\n\tv340 = ~v339;\n\tif (v340) goto L_0090;\n\tv304 = this.position;\n\tv270 = UnityEngine.Animator::GetIKPosition(this._animator, this._iKGoal);\n\tv304.value = v270;\n\tv304.value.y = v270.y;\n\tv304.value.z = v270.z;\nL_0090:\n\tv344 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rotation);\n\tv346 = v344 == 0;\n\tv347 = ~v346;\n\tif (v347) goto L_00A9;\n\tv305 = this.rotation;\n\tv271 = UnityEngine.Animator::GetIKRotation(this._animator, this._iKGoal);\n\tv305.value = v271;\n\tv305.value.y = v271.y;\n\tv305.value.z = v271.z;\n\tv305.value.w = v271.w;\nL_00A9:\n\tv350 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.positionWeight);\n\tv352 = v350 == 0;\n\tv353 = ~v352;\n\tif (v353) goto L_00BC;\n\tv306 = this.positionWeight;\n\tv272 = UnityEngine.Animator::GetIKPositionWeight(this._animator, this._iKGoal);\n\tv306.value = v272;\nL_00BC:\n\tv117 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rotationWeight);\n\tv357 = v117 == 0;\n\tv120 = ~v357;\n\tif (v120) goto L_00D1;\n\tv124 = this.rotationWeight;\n\tv77 = UnityEngine.Animator::GetIKRotationWeight(this._animator, this._iKGoal);\n\tv124.value = v77;\nL_00D1:\n\treturn;\n\tthrow System.NullReferenceException;\n\tv308 = new System.NullReferenceException();\nL_00D5:\n\tthrow System.InvalidCastException;\n// 144 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetIKGoal()
		{
			//IL_005e: Expected I4, but got O
			//IL_008f: Expected I4, but got O
			if (!(_animator == null))
			{
				Enum value = iKGoal.Value;
				if ((int)((value is AvatarIKGoal) ? value : null) == 0)
				{
					throw new InvalidCastException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				object obj = default(object);
				_iKGoal = (AvatarIKGoal)obj;
				if (_transform != null)
				{
					Vector3 iKPosition = _animator.GetIKPosition(_iKGoal);
					_transform.position = iKPosition;
					Quaternion iKRotation = _animator.GetIKRotation(_iKGoal);
					_transform.rotation = iKRotation;
				}
				if (!position.IsNone)
				{
					FsmVector3 fsmVector = position;
					Vector3 vector = (fsmVector.value = _animator.GetIKPosition(_iKGoal));
					fsmVector.value.y = vector.y;
					fsmVector.value.z = vector.z;
				}
				if (!rotation.IsNone)
				{
					FsmQuaternion fsmQuaternion = rotation;
					Quaternion quaternion = (fsmQuaternion.value = _animator.GetIKRotation(_iKGoal));
					fsmQuaternion.value.y = quaternion.y;
					fsmQuaternion.value.z = quaternion.z;
					fsmQuaternion.value.w = quaternion.w;
				}
				if (!positionWeight.IsNone)
				{
					FsmFloat fsmFloat = positionWeight;
					float iKPositionWeight = _animator.GetIKPositionWeight(_iKGoal);
					fsmFloat.Value = iKPositionWeight;
				}
				if (!rotationWeight.IsNone)
				{
					FsmFloat fsmFloat2 = rotationWeight;
					float iKRotationWeight = _animator.GetIKRotationWeight(_iKGoal);
					fsmFloat2.Value = iKRotationWeight;
				}
			}
		}

		[Token(Token = "0x6000745")]
		[Address(RVA = "0xB804EC", Offset = "0xB804EC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetAnimatorIKGoal()
		{
		}
	}
}
