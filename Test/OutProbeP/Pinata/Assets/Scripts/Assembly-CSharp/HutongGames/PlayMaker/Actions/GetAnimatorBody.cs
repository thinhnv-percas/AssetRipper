using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x752744", Offset = "0x752744")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x752744", Offset = "0x752744")]
	[Token(Token = "0x2000136")]
	public class GetAnimatorBody : FsmStateActionAnimatorBase
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A3F7C", Offset = "0x7A3F7C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A3F7C", Offset = "0x7A3F7C")]
		[Token(Token = "0x400111D")]
		[FieldOffset(Offset = "0x58")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7A4014", Offset = "0x7A4014")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A4014", Offset = "0x7A4014")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A4014", Offset = "0x7A4014")]
		[Token(Token = "0x400111E")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 bodyPosition;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A4088", Offset = "0x7A4088")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A4088", Offset = "0x7A4088")]
		[Token(Token = "0x400111F")]
		[FieldOffset(Offset = "0x68")]
		public FsmQuaternion bodyRotation;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A40D8", Offset = "0x7A40D8")]
		[Token(Token = "0x4001120")]
		[FieldOffset(Offset = "0x70")]
		public FsmGameObject bodyGameObject;

		[Token(Token = "0x4001121")]
		[FieldOffset(Offset = "0x78")]
		private Animator _animator;

		[Token(Token = "0x4001122")]
		[FieldOffset(Offset = "0x80")]
		private Transform _transform;

		[Token(Token = "0x60006F9")]
		[Address(RVA = "0xB7DD20", Offset = "0xB7DD20", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.bodyRotation = 0;\n\tthis.gameObject = 0;\n\tthis.everyFrameOption = 2;\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			everyFrame = false;
			bodyRotation = null;
			gameObject = null;
			everyFrameOption = AnimatorFrameUpdateSelector.OnAnimatorIK;
		}

		[Token(Token = "0x60006FA")]
		[Address(RVA = "0xB7DD3C", Offset = "0xB7DD3C", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EBBEC0]);\n\tv21 = *([v20 @ X8_v18]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022987]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv91 = *([v66 @ X8_v5+E0]);\n\tv92 = v91 == 0;\n\tv93 = ~v92;\n\tif (v93) goto L_002B;\n\tv98 = v66;\n\tv95 = \"il2cpp_codegen_runtime_class_init\"(v98, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv80 = UnityEngine.Object::op_Equality(v45, 0);\n\tv100 = v80 == 0;\n\tv101 = ~v100;\n\tif (v101) goto L_0052;\n\tv165 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._animator = v165;\n\tgoto L_0046;\n\tv170 = *([v166 @ X0_v16+E0]);\n\tv171 = v170 == 0;\n\tv172 = ~v171;\n\tif (v172) goto L_0046;\n\tv174 = \"il2cpp_codegen_runtime_class_init\"(v166, v164, v74, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv158 = UnityEngine.Object::op_Equality(v165, 0);\n\tv159 = v158 == 0;\n\tif (v159) goto L_0058;\nL_0052:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0058:\n\tv179 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.bodyGameObject);\n\tgoto L_0068;\n\tv183 = *([v86 @ X8_v11+E0]);\n\tv184 = v183 == 0;\n\tv185 = ~v184;\n\tif (v185) goto L_0068;\n\tv190 = v86;\n\tv187 = \"il2cpp_codegen_runtime_class_init\"(v190, v178, v52, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0068:\n\tv81 = UnityEngine.Object::op_Inequality(v179, 0);\n\tv192 = v81 == 0;\n\tif (v192) goto L_0077;\n\tv194 = UnityEngine.GameObject::get_transform(v179);\n\tthis._transform = v194;\nL_0077:\n\tv116 = this.everyFrameOption == 2;\n\tif (v116) goto L_0085;\n\tthis.everyFrameOption = 2;\nL_0085:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget == null || (_animator = ownerDefaultTarget.GetComponent<Animator>()) == null)
			{
				Finish();
				return;
			}
			GameObject value = bodyGameObject.Value;
			if (value != null)
			{
				Transform transform = value.transform;
				_transform = transform;
			}
			if (everyFrameOption != AnimatorFrameUpdateSelector.OnAnimatorIK)
			{
				everyFrameOption = AnimatorFrameUpdateSelector.OnAnimatorIK;
			}
		}

		[Token(Token = "0x60006FB")]
		[Address(RVA = "0xB7DEB0", Offset = "0xB7DEB0", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetAnimatorBody::DoGetBodyPosition(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnActionUpdate()
		{
			DoGetBodyPosition();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60006FC")]
		[Address(RVA = "0xB7DEEC", Offset = "0xB7DEEC", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1ED1F50]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022988]) = v40;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tv58 = UnityEngine.Object::op_Equality(this._animator, 0);\n\tv60 = v58 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0081;\n\tv89 = this.bodyPosition;\n\tv91 = UnityEngine.Animator::get_bodyPosition(this._animator);\n\tv89.value = v91;\n\tv89.value.y = v91.y;\n\tv89.value.z = v91.z;\n\tv169 = this.bodyRotation;\n\tv71 = UnityEngine.Animator::get_bodyRotation(this._animator);\n\tv169.value = v71;\n\tv169.value.y = v71.y;\n\tv169.value.z = v71.z;\n\tv169.value.w = v71.w;\n\tgoto L_0053;\n\tv175 = *([v171 @ X0_v14+E0]);\n\tv176 = v175 == 0;\n\tv177 = ~v176;\n\tif (v177) goto L_0053;\n\tv179 = \"il2cpp_codegen_runtime_class_init\"(v171, v162, v57, v25, v26, v27, v28, v29, v71, v69, v67, v65, v34, v35, v36, v37);\nL_0053:\n\tv77 = UnityEngine.Object::op_Inequality(this._transform, 0);\n\tv79 = v77 == 0;\n\tif (v79) goto L_0081;\n\tv103 = UnityEngine.Animator::get_bodyPosition(this._animator);\n\tUnityEngine.Transform::set_position(this._transform, v103);\n\tv138 = UnityEngine.Animator::get_bodyRotation(this._animator);\n\tUnityEngine.Transform::set_rotation(this._transform, v138);\n\treturn;\nL_0081:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetBodyPosition()
		{
			if (!(_animator == null))
			{
				FsmVector3 fsmVector = bodyPosition;
				Vector3 vector = (fsmVector.value = _animator.bodyPosition);
				fsmVector.value.y = vector.y;
				fsmVector.value.z = vector.z;
				FsmQuaternion fsmQuaternion = bodyRotation;
				Quaternion quaternion = (fsmQuaternion.value = _animator.bodyRotation);
				fsmQuaternion.value.y = quaternion.y;
				fsmQuaternion.value.z = quaternion.z;
				fsmQuaternion.value.w = quaternion.w;
				if (_transform != null)
				{
					Vector3 position = _animator.bodyPosition;
					_transform.position = position;
					Quaternion rotation = _animator.bodyRotation;
					_transform.rotation = rotation;
				}
			}
		}

		[Token(Token = "0x60006FD")]
		[Address(RVA = "0xB7E03C", Offset = "0xB7E03C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EB51A8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022989]) = v38;\nL_001D:\n\tv49 = this.everyFrameOption != 2;\n\tif (v49) goto L_FFFFFFFF;\n\tv53 = v52.Empty;\n\tgoto L_002C;\nL_002C:\n\treturn *([v53 @ X8_v10 (System.String)]);\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ErrorCheck()
		{
			if (everyFrameOption == AnimatorFrameUpdateSelector.OnAnimatorIK)
			{
				return string.Empty;
			}
			return "Getting Body Position should only be done in OnAnimatorIK";
		}

		[Token(Token = "0x60006FE")]
		[Address(RVA = "0xB7E0A8", Offset = "0xB7E0A8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetAnimatorBody()
		{
		}
	}
}
