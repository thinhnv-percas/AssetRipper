using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x753284", Offset = "0x753284")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x753284", Offset = "0x753284")]
	[Token(Token = "0x200015A")]
	public class SetAnimatorBody : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A7A7C", Offset = "0x7A7A7C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A7A7C", Offset = "0x7A7A7C")]
		[Token(Token = "0x40011DF")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A7B14", Offset = "0x7A7B14")]
		[Token(Token = "0x40011E0")]
		[FieldOffset(Offset = "0x58")]
		public FsmGameObject target;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A7B4C", Offset = "0x7A7B4C")]
		[Token(Token = "0x40011E1")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 position;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A7B84", Offset = "0x7A7B84")]
		[Token(Token = "0x40011E2")]
		[FieldOffset(Offset = "0x68")]
		public FsmQuaternion rotation;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A7BBC", Offset = "0x7A7BBC")]
		[Token(Token = "0x40011E3")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x40011E4")]
		[FieldOffset(Offset = "0x78")]
		private Animator _animator;

		[Token(Token = "0x40011E5")]
		[FieldOffset(Offset = "0x80")]
		private Transform _transform;

		[Token(Token = "0x60007A6")]
		[Address(RVA = "0xB291BC", Offset = "0xB291BC", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EF8210]);\n\tv21 = *([v20 @ X8_v10]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20225F6]) = v40;\nL_0014:\n\tthis.gameObject = 0;\n\tthis.target = 0;\n\tv44 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v44);\n\tv44.useVariable = 1;\n\tthis.position = v44;\n\tv52 = new HutongGames.PlayMaker.FsmQuaternion();\n\tHutongGames.PlayMaker.FsmQuaternion::.ctor(v52);\n\tv52.useVariable = 1;\n\tthis.rotation = v52;\n\tthis.everyFrame = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			target = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			position = fsmVector;
			FsmQuaternion fsmQuaternion = new FsmQuaternion();
			fsmQuaternion.useVariable = true;
			rotation = fsmQuaternion;
			everyFrame = false;
		}

		[Token(Token = "0x60007A7")]
		[Address(RVA = "0xB29268", Offset = "0xB29268", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Fsm::set_HandleAnimatorIK(this.fsm, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnPreprocess()
		{
			Fsm.HandleAnimatorIK = true;
		}

		[Token(Token = "0x60007A8")]
		[Address(RVA = "0xB29288", Offset = "0xB29288", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EA98F8]);\n\tv21 = *([v20 @ X8_v15]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20225F7]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv91 = *([v66 @ X8_v5+E0]);\n\tv92 = v91 == 0;\n\tv93 = ~v92;\n\tif (v93) goto L_002B;\n\tv98 = v66;\n\tv95 = \"il2cpp_codegen_runtime_class_init\"(v98, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv80 = UnityEngine.Object::op_Equality(v45, 0);\n\tv100 = v80 == 0;\n\tv101 = ~v100;\n\tif (v101) goto L_0052;\n\tv140 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._animator = v140;\n\tgoto L_0046;\n\tv145 = *([v141 @ X0_v16+E0]);\n\tv146 = v145 == 0;\n\tv147 = ~v146;\n\tif (v147) goto L_0046;\n\tv149 = \"il2cpp_codegen_runtime_class_init\"(v141, v139, v74, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv133 = UnityEngine.Object::op_Equality(v140, 0);\n\tv134 = v133 == 0;\n\tif (v134) goto L_0058;\nL_0052:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0058:\n\tv154 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.target);\n\tgoto L_0068;\n\tv158 = *([v86 @ X8_v11+E0]);\n\tv159 = v158 == 0;\n\tv160 = ~v159;\n\tif (v160) goto L_0068;\n\tv165 = v86;\n\tv162 = \"il2cpp_codegen_runtime_class_init\"(v165, v153, v52, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0068:\n\tv81 = UnityEngine.Object::op_Inequality(v154, 0);\n\tv167 = v81 == 0;\n\tif (v167) goto L_0078;\n\tv169 = UnityEngine.GameObject::get_transform(v154);\n\tthis._transform = v169;\nL_0078:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget == null || (_animator = ownerDefaultTarget.GetComponent<Animator>()) == null)
			{
				Finish();
				return;
			}
			GameObject value = target.Value;
			if (value != null)
			{
				Transform transform = value.transform;
				_transform = transform;
			}
		}

		[Token(Token = "0x60007A9")]
		[Address(RVA = "0xB293E8", Offset = "0xB293E8", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetAnimatorBody::DoSetBody(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DoAnimatorIK(int layerIndex)
		{
			DoSetBody();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60007AA")]
		[Address(RVA = "0xB29424", Offset = "0xB29424", Length = "0x2D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv36 = *([1EF0828]);\n\tv37 = *([v36 @ X8_v27]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([20225F8]) = v56;\nL_0023:\n\tgoto L_002C;\n\tv64 = *([v60 @ X0_v2+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tgoto L_002C;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v60, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_002C:\n\tv74 = UnityEngine.Object::op_Equality(this._animator, 0);\n\tv76 = v74 == 0;\n\tif (v76) goto L_0044;\nL_003E:\n\treturn;\nL_0044:\n\tgoto L_004D;\n\tv221 = *([v113 @ X0_v6+E0]);\n\tv222 = v221 == 0;\n\tv223 = ~v222;\n\tif (v223) goto L_004D;\n\tv225 = \"il2cpp_codegen_runtime_class_init\"(v113, v72, v73, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_004D:\n\tv230 = UnityEngine.Object::op_Inequality(this._transform, 0);\n\tv235 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.position);\n\tv350 = v230 == 0;\n\tif (v350) goto L_006F;\n\tv286 = UnityEngine.Transform::get_position(this._transform);\n\tv279 = v286.y;\n\tv272 = v286.z;\n\tv374 = v235 == 0;\n\tif (v374) goto L_0098;\n\tgoto L_00BA;\nL_006F:\n\tv366 = v235 == 0;\n\tv367 = ~v366;\n\tif (v367) goto L_0084;\n\tv284 = HutongGames.PlayMaker.FsmVector3::get_Value(this.position);\n\tUnityEngine.Animator::set_bodyPosition(this._animator, v284);\nL_0084:\n\tv93 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rotation);\n\tv376 = v93 == 0;\n\tv95 = ~v376;\n\tif (v95) goto L_003E;\n\tv339 = this.rotation;\n\tv206 = this._animator;\n\tv170 = v339.value;\n\tv167 = v339.value.y;\n\tv164 = v339.value.z;\n\tv158 = v339.value.w;\n\tgoto L_010F;\nL_0098:\n\tv381 = HutongGames.PlayMaker.FsmVector3::get_Value(this.position);\n\tgoto L_00B3;\n\tv394 = *([v390 @ X0_v35+E0]);\n\tv395 = v394 == 0;\n\tv396 = ~v395;\n\tif (v396) goto L_00B3;\n\tv398 = \"il2cpp_codegen_runtime_class_init\"(v390, v319, v89, v41, v42, v43, v44, v45, v381, v386, v387, v49, v50, v51, v52, v53);\nL_00B3:\n\tv286 = UnityEngine.Vector3::op_Addition(v286, v381);\n\tv279 = v286.y;\n\tv272 = v286.z;\nL_00BA:\n\t// 186 MakeStruct v237 @ AGGB2960C_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v286 @ V0_v8 (UnityEngine.Vector3), v279 @ V1_v8 (System.Single), v272 @ V2_v8 (System.Single)\n\tUnityEngine.Animator::set_bodyPosition(v383, v237);\n\tv326 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rotation);\n\tv170 = UnityEngine.Transform::get_rotation(this._transform);\n\tv167 = v170.y;\n\tv164 = v170.z;\n\tv158 = v170.w;\n\tv425 = v326 == 0;\n\tif (v425) goto L_00DB;\n\tgoto L_010F;\nL_00DB:\n\tv342 = this.rotation;\n\tgoto L_00F8;\n\tv431 = *([v428 @ X0_v28+E0]);\n\tv432 = v431 == 0;\n\tv433 = ~v432;\n\tif (v433) goto L_00F8;\n\tv435 = \"il2cpp_codegen_runtime_class_init\"(v428, v321, v89, v41, v42, v43, v44, v45, v287, v280, v273, v265, v260, v256, v52, v53);\nL_00F8:\n\t// 248 MakeStruct v239 @ AGGB296C0_1_v4 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v342.value (UnityEngine.Quaternion), v342.value.y (System.Single), v342.value.z (System.Single), v342.value.w (System.Single)\n\tv170 = UnityEngine.Quaternion::op_Multiply(v170, v239);\n\tv167 = v170.y;\n\tv164 = v170.z;\n\tv158 = v170.w;\nL_010F:\n\t// 271 MakeStruct v120 @ AGGB296EC_1_v1 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v170 @ V0_v3 (UnityEngine.Quaternion), v167 @ V1_v3 (System.Single), v164 @ V2_v3 (System.Single), v158 @ V3_v3 (System.Single)\n\tUnityEngine.Animator::set_bodyRotation(v206, v120);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 192 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetBody()
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
			Animator animator2;
			if (flag)
			{
				Vector3 vector = _transform.position;
				float y = vector.y;
				float z = vector.z;
				Animator animator;
				if (isNone)
				{
					animator = _animator;
				}
				else
				{
					Vector3 value = position.Value;
					vector += value;
					y = vector.y;
					z = vector.z;
					animator = _animator;
				}
				Vector3 bodyPosition = default(Vector3);
				bodyPosition.x = vector.x;
				bodyPosition.y = y;
				bodyPosition.z = z;
				animator.bodyPosition = bodyPosition;
				bool isNone2 = rotation.IsNone;
				value2 = _transform.rotation;
				y2 = value2.y;
				z2 = value2.z;
				w = value2.w;
				if (isNone2)
				{
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
					animator2 = _animator;
				}
			}
			else
			{
				if (!isNone)
				{
					Vector3 value3 = position.Value;
					_animator.bodyPosition = value3;
				}
				if (rotation.IsNone)
				{
					return;
				}
				FsmQuaternion fsmQuaternion2 = rotation;
				animator2 = _animator;
				value2 = fsmQuaternion2.value;
				y2 = fsmQuaternion2.value.y;
				z2 = fsmQuaternion2.value.z;
				w = fsmQuaternion2.value.w;
			}
			Quaternion bodyRotation = default(Quaternion);
			bodyRotation.x = value2.x;
			bodyRotation.y = y2;
			bodyRotation.z = z2;
			bodyRotation.w = w;
			animator2.bodyRotation = bodyRotation;
		}

		[Token(Token = "0x60007AB")]
		[Address(RVA = "0xB296F8", Offset = "0xB296F8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetAnimatorBody()
		{
		}
	}
}
