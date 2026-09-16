using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x753414", Offset = "0x753414")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x753414", Offset = "0x753414")]
	[Token(Token = "0x200015F")]
	public class SetAnimatorIKGoal : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A802C", Offset = "0x7A802C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A802C", Offset = "0x7A802C")]
		[Token(Token = "0x40011F7")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A80C4", Offset = "0x7A80C4")]
		[Token(Token = "0x40011F8")]
		[FieldOffset(Offset = "0x58")]
		public AvatarIKGoal iKGoal;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A80FC", Offset = "0x7A80FC")]
		[Token(Token = "0x40011F9")]
		[FieldOffset(Offset = "0x60")]
		public FsmGameObject goal;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A8134", Offset = "0x7A8134")]
		[Token(Token = "0x40011FA")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector3 position;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A816C", Offset = "0x7A816C")]
		[Token(Token = "0x40011FB")]
		[FieldOffset(Offset = "0x70")]
		public FsmQuaternion rotation;

		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7A81A4", Offset = "0x7A81A4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A81A4", Offset = "0x7A81A4")]
		[Token(Token = "0x40011FC")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat positionWeight;

		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7A81F8", Offset = "0x7A81F8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A81F8", Offset = "0x7A81F8")]
		[Token(Token = "0x40011FD")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat rotationWeight;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A824C", Offset = "0x7A824C")]
		[Token(Token = "0x40011FE")]
		[FieldOffset(Offset = "0x88")]
		public bool everyFrame;

		[Token(Token = "0x40011FF")]
		[FieldOffset(Offset = "0x90")]
		private Animator _animator;

		[Token(Token = "0x4001200")]
		[FieldOffset(Offset = "0x98")]
		private Transform _transform;

		[Token(Token = "0x60007BE")]
		[Address(RVA = "0xB29FAC", Offset = "0xB29FAC", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EADB20]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022602]) = v42;\nL_0015:\n\tthis.gameObject = 0;\n\tthis.goal = 0;\n\tv46 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.position = v46;\n\tv54 = new HutongGames.PlayMaker.FsmQuaternion();\n\tHutongGames.PlayMaker.FsmQuaternion::.ctor(v54);\n\tv54.useVariable = 1;\n\tthis.rotation = v54;\n\tv88 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.positionWeight = v88;\n\tv76 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.rotationWeight = v76;\n\tthis.everyFrame = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			goal = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			position = fsmVector;
			FsmQuaternion fsmQuaternion = new FsmQuaternion();
			fsmQuaternion.useVariable = true;
			rotation = fsmQuaternion;
			FsmFloat fsmFloat = 1f;
			positionWeight = fsmFloat;
			FsmFloat fsmFloat2 = 1f;
			rotationWeight = fsmFloat2;
			everyFrame = false;
		}

		[Token(Token = "0x60007BF")]
		[Address(RVA = "0xB2A088", Offset = "0xB2A088", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Fsm::set_HandleAnimatorIK(this.fsm, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnPreprocess()
		{
			Fsm.HandleAnimatorIK = true;
		}

		[Token(Token = "0x60007C0")]
		[Address(RVA = "0xB2A0A8", Offset = "0xB2A0A8", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1F03D30]);\n\tv21 = *([v20 @ X8_v15]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022603]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv91 = *([v66 @ X8_v5+E0]);\n\tv92 = v91 == 0;\n\tv93 = ~v92;\n\tif (v93) goto L_002B;\n\tv98 = v66;\n\tv95 = \"il2cpp_codegen_runtime_class_init\"(v98, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv80 = UnityEngine.Object::op_Equality(v45, 0);\n\tv100 = v80 == 0;\n\tv101 = ~v100;\n\tif (v101) goto L_0052;\n\tv140 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._animator = v140;\n\tgoto L_0046;\n\tv145 = *([v141 @ X0_v16+E0]);\n\tv146 = v145 == 0;\n\tv147 = ~v146;\n\tif (v147) goto L_0046;\n\tv149 = \"il2cpp_codegen_runtime_class_init\"(v141, v139, v74, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv133 = UnityEngine.Object::op_Equality(v140, 0);\n\tv134 = v133 == 0;\n\tif (v134) goto L_0058;\nL_0052:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0058:\n\tv154 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.goal);\n\tgoto L_0068;\n\tv158 = *([v86 @ X8_v11+E0]);\n\tv159 = v158 == 0;\n\tv160 = ~v159;\n\tif (v160) goto L_0068;\n\tv165 = v86;\n\tv162 = \"il2cpp_codegen_runtime_class_init\"(v165, v153, v52, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0068:\n\tv81 = UnityEngine.Object::op_Inequality(v154, 0);\n\tv167 = v81 == 0;\n\tif (v167) goto L_0078;\n\tv169 = UnityEngine.GameObject::get_transform(v154);\n\tthis._transform = v169;\nL_0078:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60007C1")]
		[Address(RVA = "0xB2A208", Offset = "0xB2A208", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetAnimatorIKGoal::DoSetIKGoal(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DoAnimatorIK(int layerIndex)
		{
			DoSetIKGoal();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60007C2")]
		[Address(RVA = "0xB2A244", Offset = "0xB2A244", Length = "0x378")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv38 = *([1F0DC78]);\n\tv39 = *([v38 @ X8_v28]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv58 = 0 | 1;\n\t*([2022604]) = v58;\nL_0024:\n\tgoto L_002D;\n\tv66 = *([v62 @ X0_v2+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tgoto L_002D;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v62, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_002D:\n\tv76 = UnityEngine.Object::op_Equality(this._animator, 0);\n\tv78 = v76 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_012C;\n\tgoto L_0040;\n\tv171 = *([v80 @ X0_v7+E0]);\n\tv172 = v171 == 0;\n\tv173 = ~v172;\n\tif (v173) goto L_0040;\n\tv175 = \"il2cpp_codegen_runtime_class_init\"(v80, v74, v75, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_0040:\n\tv181 = UnityEngine.Object::op_Inequality(this._transform, 0);\n\tv274 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.position);\n\tv418 = v181 == 0;\n\tif (v418) goto L_0064;\n\tv355 = UnityEngine.Transform::get_position(this._transform);\n\tv347 = v355.y;\n\tv339 = v355.z;\n\tv455 = v274 == 0;\n\tif (v455) goto L_0090;\n\tgoto L_00B3;\nL_0064:\n\tv446 = v274 == 0;\n\tv447 = ~v446;\n\tif (v447) goto L_007B;\n\tv352 = HutongGames.PlayMaker.FsmVector3::get_Value(this.position);\n\tUnityEngine.Animator::SetIKPosition(this._animator, this.iKGoal, v352);\nL_007B:\n\tv384 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rotation);\n\tv457 = v384 == 0;\n\tv458 = ~v457;\n\tif (v458) goto L_0103;\n\tv404 = this.rotation;\n\tv494 = this._animator;\n\tv492 = this.iKGoal;\n\tv488 = v404.value;\n\tv487 = v404.value.y;\n\tv486 = v404.value.z;\n\tv481 = v404.value.w;\n\tgoto L_00FD;\nL_0090:\n\tv464 = HutongGames.PlayMaker.FsmVector3::get_Value(this.position);\n\tgoto L_00AB;\n\tv512 = *([v507 @ X0_v46+E0]);\n\tv513 = v512 == 0;\n\tv514 = ~v513;\n\tif (v514) goto L_00AB;\n\tv516 = \"il2cpp_codegen_runtime_class_init\"(v507, v376, v180, v43, v44, v45, v46, v47, v464, v503, v504, v51, v52, v53, v54, v55);\nL_00AB:\n\tv355 = UnityEngine.Vector3::op_Addition(v355, v464);\n\tv347 = v355.y;\n\tv339 = v355.z;\nL_00B3:\n\t// 179 MakeStruct v277 @ AGGB2A424_2_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v355 @ V0_v13 (UnityEngine.Vector3), v347 @ V1_v10 (System.Single), v339 @ V2_v10 (System.Single)\n\tUnityEngine.Animator::SetIKPosition(v500, v422, v277);\n\tv386 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rotation);\n\tv488 = UnityEngine.Transform::get_rotation(this._transform);\n\tv487 = v488.y;\n\tv486 = v488.z;\n\tv481 = v488.w;\n\tv545 = v386 == 0;\n\tif (v545) goto L_00D6;\n\tgoto L_00FD;\nL_00D6:\n\tv407 = this.rotation;\n\tgoto L_00F3;\n\tv551 = *([v548 @ X0_v39+E0]);\n\tv552 = v551 == 0;\n\tv553 = ~v552;\n\tif (v553) goto L_00F3;\n\tv555 = \"il2cpp_codegen_runtime_class_init\"(v548, v378, v370, v43, v44, v45, v46, v47, v356, v348, v340, v321, v304, v300, v54, v55);\nL_00F3:\n\t// 243 MakeStruct v279 @ AGGB2A4E0_1_v6 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v407.value (UnityEngine.Quaternion), v407.value.y (System.Single), v407.value.z (System.Single), v407.value.w (System.Single)\n\tv488 = UnityEngine.Quaternion::op_Multiply(v488, v279);\n\tv487 = v488.y;\n\tv486 = v488.z;\n\tv481 = v488.w;\nL_00FD:\n\t// 253 MakeStruct v465 @ AGGB2A4F4_2_v4 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v488 @ V0_v4 (UnityEngine.Quaternion), v487 @ V1_v4 (System.Single), v486 @ V2_v4 (System.Single), v481 @ V3_v4 (System.Single)\n\tUnityEngine.Animator::SetIKRotation(v494, v492, v465);\nL_0103:\n\tv511 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.positionWeight);\n\tv527 = v511 == 0;\n\tv528 = ~v527;\n\tif (v528) goto L_0119;\n\tv358 = HutongGames.PlayMaker.FsmFloat::get_Value(this.positionWeight);\n\tUnityEngine.Animator::SetIKPositionWeight(this._animator, this.iKGoal, v358);\nL_0119:\n\tv150 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rotationWeight);\n\tv152 = v150 == 0;\n\tif (v152) goto L_0133;\nL_012C:\n\treturn;\nL_0133:\n\tv239 = HutongGames.PlayMaker.FsmFloat::get_Value(this.rotationWeight);\n\tUnityEngine.Animator::SetIKRotationWeight(this._animator, this.iKGoal, v239);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 235 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetIKGoal()
		{
			if (_animator == null)
			{
				return;
			}
			bool flag = _transform != null;
			bool isNone = position.IsNone;
			Quaternion value2;
			float y2;
			float z2;
			float w;
			AvatarIKGoal avatarIKGoal2;
			Animator animator2;
			if (flag)
			{
				Vector3 vector = _transform.position;
				float y = vector.y;
				float z = vector.z;
				AvatarIKGoal avatarIKGoal;
				Animator animator;
				if (isNone)
				{
					avatarIKGoal = iKGoal;
					animator = _animator;
				}
				else
				{
					Vector3 value = position.Value;
					vector += value;
					y = vector.y;
					z = vector.z;
					avatarIKGoal = iKGoal;
					animator = _animator;
				}
				Vector3 goalPosition = default(Vector3);
				goalPosition.x = vector.x;
				goalPosition.y = y;
				goalPosition.z = z;
				animator.SetIKPosition(avatarIKGoal, goalPosition);
				bool isNone2 = rotation.IsNone;
				value2 = _transform.rotation;
				y2 = value2.y;
				z2 = value2.z;
				w = value2.w;
				if (isNone2)
				{
					avatarIKGoal2 = iKGoal;
					animator2 = _animator;
				}
				else
				{
					FsmQuaternion fsmQuaternion = rotation;
					Quaternion quaternion = default(Quaternion);
					quaternion.x = fsmQuaternion.value.x;
					quaternion.y = fsmQuaternion.value.y;
					quaternion.z = fsmQuaternion.value.z;
					quaternion.w = fsmQuaternion.value.w;
					value2 *= quaternion;
					y2 = value2.y;
					z2 = value2.z;
					w = value2.w;
					avatarIKGoal2 = iKGoal;
					animator2 = _animator;
				}
			}
			else
			{
				if (!isNone)
				{
					Vector3 value3 = position.Value;
					_animator.SetIKPosition(iKGoal, value3);
				}
				if (rotation.IsNone)
				{
					goto IL_0382;
				}
				FsmQuaternion fsmQuaternion2 = rotation;
				animator2 = _animator;
				avatarIKGoal2 = iKGoal;
				value2 = fsmQuaternion2.value;
				y2 = fsmQuaternion2.value.y;
				z2 = fsmQuaternion2.value.z;
				w = fsmQuaternion2.value.w;
			}
			Quaternion goalRotation = default(Quaternion);
			goalRotation.x = value2.x;
			goalRotation.y = y2;
			goalRotation.z = z2;
			goalRotation.w = w;
			animator2.SetIKRotation(avatarIKGoal2, goalRotation);
			goto IL_0382;
			IL_0382:
			if (!positionWeight.IsNone)
			{
				float value4 = positionWeight.Value;
				_animator.SetIKPositionWeight(iKGoal, value4);
			}
			if (!rotationWeight.IsNone)
			{
				float value5 = rotationWeight.Value;
				_animator.SetIKRotationWeight(iKGoal, value5);
			}
		}

		[Token(Token = "0x60007C3")]
		[Address(RVA = "0xB2A5BC", Offset = "0xB2A5BC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetAnimatorIKGoal()
		{
		}
	}
}
