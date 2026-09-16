using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7530F4", Offset = "0x7530F4")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7530F4", Offset = "0x7530F4")]
	[Token(Token = "0x2000155")]
	public class GetAnimatorRoot : FsmStateActionAnimatorBase
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A74CC", Offset = "0x7A74CC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A74CC", Offset = "0x7A74CC")]
		[Token(Token = "0x40011C9")]
		[FieldOffset(Offset = "0x58")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7A7564", Offset = "0x7A7564")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A7564", Offset = "0x7A7564")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A7564", Offset = "0x7A7564")]
		[Token(Token = "0x40011CA")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 rootPosition;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A75D8", Offset = "0x7A75D8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A75D8", Offset = "0x7A75D8")]
		[Token(Token = "0x40011CB")]
		[FieldOffset(Offset = "0x68")]
		public FsmQuaternion rootRotation;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A7628", Offset = "0x7A7628")]
		[Token(Token = "0x40011CC")]
		[FieldOffset(Offset = "0x70")]
		public FsmGameObject bodyGameObject;

		[Token(Token = "0x40011CD")]
		[FieldOffset(Offset = "0x78")]
		private Animator _animator;

		[Token(Token = "0x40011CE")]
		[FieldOffset(Offset = "0x80")]
		private Transform _transform;

		[Token(Token = "0x600078E")]
		[Address(RVA = "0xB82494", Offset = "0xB82494", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.everyFrameOption = 0;\n\tthis.rootRotation = 0;\n\tthis.gameObject = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			everyFrame = false;
			everyFrameOption = default(AnimatorFrameUpdateSelector);
			rootRotation = null;
			gameObject = null;
		}

		[Token(Token = "0x600078F")]
		[Address(RVA = "0xB824AC", Offset = "0xB824AC", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EA72B0]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20229C7]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv91 = *([v66 @ X8_v5+E0]);\n\tv92 = v91 == 0;\n\tv93 = ~v92;\n\tif (v93) goto L_002B;\n\tv98 = v66;\n\tv95 = \"il2cpp_codegen_runtime_class_init\"(v98, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv80 = UnityEngine.Object::op_Equality(v45, 0);\n\tv100 = v80 == 0;\n\tv101 = ~v100;\n\tif (v101) goto L_007D;\n\tv142 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._animator = v142;\n\tgoto L_0046;\n\tv147 = *([v143 @ X0_v16+E0]);\n\tv148 = v147 == 0;\n\tv149 = ~v148;\n\tif (v149) goto L_0046;\n\tv151 = \"il2cpp_codegen_runtime_class_init\"(v143, v141, v74, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv135 = UnityEngine.Object::op_Equality(v142, 0);\n\tv155 = v135 == 0;\n\tv136 = ~v155;\n\tif (v136) goto L_007D;\n\tv157 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.bodyGameObject);\n\tgoto L_005F;\n\tv161 = *([v86 @ X8_v11+E0]);\n\tv162 = v161 == 0;\n\tv163 = ~v162;\n\tif (v163) goto L_005F;\n\tv168 = v86;\n\tv165 = \"il2cpp_codegen_runtime_class_init\"(v168, v156, v52, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_005F:\n\tv81 = UnityEngine.Object::op_Inequality(v157, 0);\n\tv170 = v81 == 0;\n\tif (v170) goto L_006A;\n\tv173 = UnityEngine.GameObject::get_transform(v157);\n\tthis._transform = v173;\nL_006A:\n\tHutongGames.PlayMaker.Actions.GetAnimatorRoot::DoGetBodyPosition(this);\n\tv119 = ~this.everyFrame;\n\tif (v119) goto L_007D;\n\treturn;\nL_007D:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null) && !((_animator = ownerDefaultTarget.GetComponent<Animator>()) == null))
			{
				GameObject value = bodyGameObject.Value;
				if (value != null)
				{
					Transform transform = value.transform;
					_transform = transform;
				}
				DoGetBodyPosition();
				if (everyFrame)
				{
					return;
				}
			}
			Finish();
		}

		[Token(Token = "0x6000790")]
		[Address(RVA = "0xB8276C", Offset = "0xB8276C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetAnimatorRoot::DoGetBodyPosition(this);\n\treturn;\n")]
		public override void OnActionUpdate()
		{
			DoGetBodyPosition();
		}

		[Token(Token = "0x6000791")]
		[Address(RVA = "0xB8261C", Offset = "0xB8261C", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1ECFCA0]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20229C8]) = v40;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tv58 = UnityEngine.Object::op_Equality(this._animator, 0);\n\tv60 = v58 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0081;\n\tv89 = this.rootPosition;\n\tv91 = UnityEngine.Animator::get_rootPosition(this._animator);\n\tv89.value = v91;\n\tv89.value.y = v91.y;\n\tv89.value.z = v91.z;\n\tv169 = this.rootRotation;\n\tv71 = UnityEngine.Animator::get_rootRotation(this._animator);\n\tv169.value = v71;\n\tv169.value.y = v71.y;\n\tv169.value.z = v71.z;\n\tv169.value.w = v71.w;\n\tgoto L_0053;\n\tv175 = *([v171 @ X0_v14+E0]);\n\tv176 = v175 == 0;\n\tv177 = ~v176;\n\tif (v177) goto L_0053;\n\tv179 = \"il2cpp_codegen_runtime_class_init\"(v171, v162, v57, v25, v26, v27, v28, v29, v71, v69, v67, v65, v34, v35, v36, v37);\nL_0053:\n\tv77 = UnityEngine.Object::op_Inequality(this._transform, 0);\n\tv79 = v77 == 0;\n\tif (v79) goto L_0081;\n\tv103 = UnityEngine.Animator::get_rootPosition(this._animator);\n\tUnityEngine.Transform::set_position(this._transform, v103);\n\tv138 = UnityEngine.Animator::get_rootRotation(this._animator);\n\tUnityEngine.Transform::set_rotation(this._transform, v138);\n\treturn;\nL_0081:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetBodyPosition()
		{
			if (!(_animator == null))
			{
				FsmVector3 fsmVector = rootPosition;
				Vector3 vector = (fsmVector.value = _animator.rootPosition);
				fsmVector.value.y = vector.y;
				fsmVector.value.z = vector.z;
				FsmQuaternion fsmQuaternion = rootRotation;
				Quaternion quaternion = (fsmQuaternion.value = _animator.rootRotation);
				fsmQuaternion.value.y = quaternion.y;
				fsmQuaternion.value.z = quaternion.z;
				fsmQuaternion.value.w = quaternion.w;
				if (_transform != null)
				{
					Vector3 position = _animator.rootPosition;
					_transform.position = position;
					Quaternion rotation = _animator.rootRotation;
					_transform.rotation = rotation;
				}
			}
		}

		[Token(Token = "0x6000792")]
		[Address(RVA = "0xB82770", Offset = "0xB82770", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetAnimatorRoot()
		{
		}
	}
}
