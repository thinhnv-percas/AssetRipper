using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x752514", Offset = "0x752514")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x752514", Offset = "0x752514")]
	[Token(Token = "0x200012E")]
	public class AnimatorMatchTarget : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A3608", Offset = "0x7A3608")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A3608", Offset = "0x7A3608")]
		[Token(Token = "0x40010FC")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A36A0", Offset = "0x7A36A0")]
		[Token(Token = "0x40010FD")]
		[FieldOffset(Offset = "0x58")]
		public AvatarTarget bodyPart;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A36D8", Offset = "0x7A36D8")]
		[Token(Token = "0x40010FE")]
		[FieldOffset(Offset = "0x60")]
		public FsmGameObject target;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A3710", Offset = "0x7A3710")]
		[Token(Token = "0x40010FF")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector3 targetPosition;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A3748", Offset = "0x7A3748")]
		[Token(Token = "0x4001100")]
		[FieldOffset(Offset = "0x70")]
		public FsmQuaternion targetRotation;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A3780", Offset = "0x7A3780")]
		[Token(Token = "0x4001101")]
		[FieldOffset(Offset = "0x78")]
		public FsmVector3 positionWeight;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A37B8", Offset = "0x7A37B8")]
		[Token(Token = "0x4001102")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat rotationWeight;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A37F0", Offset = "0x7A37F0")]
		[Token(Token = "0x4001103")]
		[FieldOffset(Offset = "0x88")]
		public FsmFloat startNormalizedTime;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A3828", Offset = "0x7A3828")]
		[Token(Token = "0x4001104")]
		[FieldOffset(Offset = "0x90")]
		public FsmFloat targetNormalizedTime;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A3860", Offset = "0x7A3860")]
		[Token(Token = "0x4001105")]
		[FieldOffset(Offset = "0x98")]
		public bool everyFrame;

		[Token(Token = "0x4001106")]
		[FieldOffset(Offset = "0xA0")]
		private Animator _animator;

		[Token(Token = "0x4001107")]
		[FieldOffset(Offset = "0xA8")]
		private Transform _transform;

		[Token(Token = "0x60006D8")]
		[Address(RVA = "0xA87898", Offset = "0xA87898", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1ED5100]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20221A4]) = v40;\nL_0014:\n\tthis.gameObject = 0;\n\tthis.bodyPart = 0;\n\tthis.target = 0;\n\tv44 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v44);\n\tv44.useVariable = 1;\n\tthis.targetPosition = v44;\n\tv52 = new HutongGames.PlayMaker.FsmQuaternion();\n\tHutongGames.PlayMaker.FsmQuaternion::.ctor(v52);\n\tv52.useVariable = 1;\n\tthis.targetRotation = v52;\n\tgoto L_003B;\n\tv96 = *([v92 @ X0_v9+E0]);\n\tv97 = v96 == 0;\n\tv98 = ~v97;\n\tif (v98) goto L_003B;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v92, v55, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_003B:\n\tv103 = UnityEngine.Vector3::get_one();\n\tv105 = HutongGames.PlayMaker.FsmVector3::op_Implicit(v103);\n\tthis.positionWeight = v105;\n\tv79 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.startNormalizedTime = 0;\n\tthis.targetNormalizedTime = 0;\n\tthis.rotationWeight = v79;\n\tthis.everyFrame = 1;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			bodyPart = default(AvatarTarget);
			target = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			targetPosition = fsmVector;
			FsmQuaternion fsmQuaternion = new FsmQuaternion();
			fsmQuaternion.useVariable = true;
			targetRotation = fsmQuaternion;
			Vector3 one = Vector3.one;
			FsmVector3 fsmVector2 = one;
			positionWeight = fsmVector2;
			FsmFloat fsmFloat = 0f;
			startNormalizedTime = null;
			targetNormalizedTime = null;
			rotationWeight = fsmFloat;
			everyFrame = true;
		}

		[Token(Token = "0x60006D9")]
		[Address(RVA = "0xA87998", Offset = "0xA87998", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EFD8B0]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20221A5]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv91 = *([v66 @ X8_v5+E0]);\n\tv92 = v91 == 0;\n\tv93 = ~v92;\n\tif (v93) goto L_002B;\n\tv98 = v66;\n\tv95 = \"il2cpp_codegen_runtime_class_init\"(v98, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv80 = UnityEngine.Object::op_Equality(v45, 0);\n\tv100 = v80 == 0;\n\tv101 = ~v100;\n\tif (v101) goto L_007D;\n\tv142 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._animator = v142;\n\tgoto L_0046;\n\tv147 = *([v143 @ X0_v16+E0]);\n\tv148 = v147 == 0;\n\tv149 = ~v148;\n\tif (v149) goto L_0046;\n\tv151 = \"il2cpp_codegen_runtime_class_init\"(v143, v141, v74, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv135 = UnityEngine.Object::op_Equality(v142, 0);\n\tv155 = v135 == 0;\n\tv136 = ~v155;\n\tif (v136) goto L_007D;\n\tv157 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.target);\n\tgoto L_005F;\n\tv161 = *([v86 @ X8_v11+E0]);\n\tv162 = v161 == 0;\n\tv163 = ~v162;\n\tif (v163) goto L_005F;\n\tv168 = v86;\n\tv165 = \"il2cpp_codegen_runtime_class_init\"(v168, v156, v52, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_005F:\n\tv81 = UnityEngine.Object::op_Inequality(v157, 0);\n\tv170 = v81 == 0;\n\tif (v170) goto L_006A;\n\tv173 = UnityEngine.GameObject::get_transform(v157);\n\tthis._transform = v173;\nL_006A:\n\tHutongGames.PlayMaker.Actions.AnimatorMatchTarget::DoMatchTarget(this);\n\tv119 = ~this.everyFrame;\n\tif (v119) goto L_007D;\n\treturn;\nL_007D:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null) && !((_animator = ownerDefaultTarget.GetComponent<Animator>()) == null))
			{
				GameObject value = target.Value;
				if (value != null)
				{
					Transform transform = value.transform;
					_transform = transform;
				}
				DoMatchTarget();
				if (everyFrame)
				{
					return;
				}
			}
			Finish();
		}

		[Token(Token = "0x60006DA")]
		[Address(RVA = "0xA87E7C", Offset = "0xA87E7C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.AnimatorMatchTarget::DoMatchTarget(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoMatchTarget();
		}

		[Token(Token = "0x60006DB")]
		[Address(RVA = "0xA87B08", Offset = "0xA87B08", Length = "0x374")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = &v31 @ stack_-10_v2;\n\tgoto L_0027;\n\tv40 = *([1EF31E8]);\n\tv41 = *([v40 @ X8_v28]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv60 = 0 | 1;\n\t*([20221A6]) = v60;\nL_0027:\n\tgoto L_0030;\n\tv70 = *([v66 @ X0_v2+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tgoto L_0030;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v66, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\nL_0030:\n\tv80 = UnityEngine.Object::op_Equality(this._animator, 0);\n\tv82 = v80 == 0;\n\tv83 = ~v82;\n\tif (v83) goto L_013D;\n\tgoto L_0042;\n\tv199 = *([v86 @ X0_v7+E0]);\n\tv200 = v199 == 0;\n\tv201 = ~v200;\n\tif (v201) goto L_0042;\n\tv203 = \"il2cpp_codegen_runtime_class_init\"(v86, v78, v79, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\nL_0042:\n\tv207 = UnityEngine.Vector3::get_zero();\n\tgoto L_0055;\n\tv294 = *([v290 @ X0_v10+E0]);\n\tv295 = v294 == 0;\n\tv296 = ~v295;\n\tif (v296) goto L_0055;\n\tv298 = \"il2cpp_codegen_runtime_class_init\"(v290, v78, v79, v45, v46, v47, v48, v49, v207, v283, v284, v53, v54, v55, v56, v57);\nL_0055:\n\tv302 = UnityEngine.Quaternion::get_identity();\n\tgoto L_006B;\n\tv315 = *([v306 @ X0_v13+E0]);\n\tv316 = v315 == 0;\n\tv317 = ~v316;\n\tif (v317) goto L_006B;\n\tv319 = \"il2cpp_codegen_runtime_class_init\"(v306, v78, v79, v45, v46, v47, v48, v49, v302, v303, v304, v305, v54, v55, v56, v57);\nL_006B:\n\tv324 = UnityEngine.Object::op_Inequality(this._transform, 0);\n\tv326 = v324 == 0;\n\tif (v326) goto L_0089;\n\tv360 = UnityEngine.Transform::get_position(this._transform);\n\tv350 = UnityEngine.Transform::get_rotation(this._transform);\nL_0089:\n\tv453 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.targetPosition);\n\t*([v30 @ X29_v1-24]) = v394;\n\tv468 = v453 == 0;\n\tv469 = ~v468;\n\tif (v469) goto L_00BB;\n\t*([v30 @ X29_v1-28]) = v387;\n\tv489 = HutongGames.PlayMaker.FsmVector3::get_Value(this.targetPosition);\n\tgoto L_00AD;\n\tv502 = *([v492 @ X0_v36+E0]);\n\tv503 = v502 == 0;\n\tv504 = ~v503;\n\tif (v504) goto L_00AD;\n\tv506 = \"il2cpp_codegen_runtime_class_init\"(v492, v483, v270, v45, v46, v47, v48, v49, v489, v490, v491, v337, v54, v55, v56, v57);\nL_00AD:\n\t// 173 MakeStruct v471 @ AGGA87CE0_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v407 @ V15_v6 (UnityEngine.Vector3), v160 @ V13_v6 (System.Single), v402 @ V8_v5 (System.Single)\n\tv482 = UnityEngine.Vector3::op_Addition(v471, v489);\n\tv387 = *([v30 @ X29_v1-28]);\n\tv394 = *([v30 @ X29_v1-24]);\nL_00BB:\n\tv463 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.targetRotation);\n\t*([v30 @ X29_v1-28]) = v402;\n\tv500 = v463 == 0;\n\tv501 = ~v500;\n\tif (v501) goto L_00F3;\n\tv465 = this.targetRotation;\n\tgoto L_00E1;\n\tv539 = *([v534 @ X0_v31+E0]);\n\tv540 = v539 == 0;\n\tv541 = ~v540;\n\tif (v541) goto L_00E1;\n\tv543 = \"il2cpp_codegen_runtime_class_init\"(v534, v434, v270, v45, v46, v47, v48, v49, v426, v420, v414, v399, v378, v375, v56, v57);\nL_00E1:\n\t// 225 MakeStruct v511 @ AGGA87D6C_0_v3 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v394 @ V9_v5 (UnityEngine.Quaternion), v391 @ V10_v5 (System.Single), v387 @ V11_v6 (System.Single), v384 @ V14_v5 (System.Single)\n\t// 226 MakeStruct v510 @ AGGA87D6C_1_v3 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v465.value (UnityEngine.Quaternion), v465.value.y (System.Single), v465.value.z (System.Single), v465.value.w (System.Single)\n\tv528 = UnityEngine.Quaternion::op_Multiply(v511, v510);\n\t*([v30 @ X29_v1-24]) = v528;\nL_00F3:\n\tv423 = HutongGames.PlayMaker.FsmVector3::get_Value(this.positionWeight);\n\tv549 = HutongGames.PlayMaker.FsmFloat::get_Value(this.rotationWeight);\n\tv551 = 0x1639294(&v115 @ stack_-90_v3 (System.Single), 0, 0, v45, v46, v47, v48, v49, v423, v423.y, v423.z, v549, v377, v374, v465.value.z, v465.value.w);\n\tv425 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startNormalizedTime);\n\tv460 = HutongGames.PlayMaker.FsmFloat::get_Value(this.targetNormalizedTime);\n\t// 298 MakeStruct v94 @ AGGA87E44_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v407 @ V15_v6 (UnityEngine.Vector3), v160 @ V13_v6 (System.Single), [v30 @ X29_v1-28]\n\t// 299 MakeStruct v91 @ AGGA87E44_2_v2 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), [v30 @ X29_v1-24], v391 @ V10_v5 (System.Single), v387 @ V11_v6 (System.Single), v384 @ V14_v5 (System.Single)\n\tUnityEngine.Animator::MatchTarget(this._animator, v94, v91, this.bodyPart, 0, v465.value.w, v115);\nL_013D:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 235 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoMatchTarget()
		{
			//IL_0204: Expected F4, but got I
			//IL_0214: Expected O, but got I
			//IL_0433: Expected F4, but got I
			//IL_0448: Expected F4, but got I
			object obj2 = default(object);
			object obj = obj2;
			if (!(_animator == null))
			{
				Vector3 zero = Vector3.zero;
				Quaternion identity = Quaternion.identity;
				bool flag = _transform != null;
				bool flag2 = !flag;
				float w = identity.w;
				float z = identity.z;
				float y = identity.y;
				Quaternion quaternion = identity;
				float z2 = zero.z;
				float y2 = zero.y;
				Vector3 vector = zero;
				if (!flag2)
				{
					Vector3 position = _transform.position;
					Quaternion rotation = _transform.rotation;
					w = rotation.w;
					z = rotation.z;
					y = rotation.y;
					quaternion = rotation;
					z2 = position.z;
					y2 = position.y;
					vector = position;
				}
				if (!targetPosition.IsNone)
				{
					Vector3 value = targetPosition.Value;
					Vector3 vector2 = default(Vector3);
					vector2.x = vector.x;
					vector2.y = y2;
					vector2.z = z2;
					Vector3 vector3 = vector2 + value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1-28]");
					z = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1-24]");
					quaternion = (Quaternion)0;
					float z3 = value.z;
					float y3 = value.y;
					z2 = vector3.z;
					y2 = vector3.y;
					vector = vector3;
				}
				FsmQuaternion fsmQuaternion = default(FsmQuaternion);
				if (!targetRotation.IsNone)
				{
					fsmQuaternion = targetRotation;
					Quaternion quaternion2 = default(Quaternion);
					quaternion2.x = quaternion.x;
					quaternion2.y = y;
					quaternion2.z = z;
					quaternion2.w = w;
					Quaternion quaternion3 = default(Quaternion);
					quaternion3.x = fsmQuaternion.value.x;
					quaternion3.y = fsmQuaternion.value.y;
					quaternion3.z = fsmQuaternion.value.z;
					quaternion3.w = fsmQuaternion.value.w;
					Quaternion quaternion4 = quaternion2 * quaternion3;
					float z3 = fsmQuaternion.value.y;
					float y3 = fsmQuaternion.value.x;
					w = quaternion4.w;
					z = quaternion4.z;
					y = quaternion4.y;
				}
				Vector3 value2 = positionWeight.Value;
				float value3 = rotationWeight.Value;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1639294 (inside UnityEngine.Experimental.Animations.AnimationScriptPlayable::.cctor +0xA0)");
				float value4 = startNormalizedTime.Value;
				float value5 = targetNormalizedTime.Value;
				Vector3 matchPosition = default(Vector3);
				matchPosition.x = vector.x;
				matchPosition.y = y2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1-28]");
				matchPosition.z = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1-24]");
				Quaternion matchRotation = default(Quaternion);
				matchRotation.x = 0f;
				matchRotation.y = y;
				matchRotation.z = z;
				matchRotation.w = w;
				float num = default(float);
				_animator.MatchTarget(matchPosition, matchRotation, bodyPart, default(MatchTargetWeightMask), fsmQuaternion.value.w, num);
			}
		}

		[Token(Token = "0x60006DC")]
		[Address(RVA = "0xA87E80", Offset = "0xA87E80", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AnimatorMatchTarget()
		{
		}
	}
}
