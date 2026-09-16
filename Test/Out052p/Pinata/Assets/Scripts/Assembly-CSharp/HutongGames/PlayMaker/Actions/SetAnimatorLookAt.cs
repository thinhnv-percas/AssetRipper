using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x753554", Offset = "0x753554")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x753554", Offset = "0x753554")]
	[Token(Token = "0x2000163")]
	public class SetAnimatorLookAt : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A85EC", Offset = "0x7A85EC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A85EC", Offset = "0x7A85EC")]
		[Token(Token = "0x400120E")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A8684", Offset = "0x7A8684")]
		[Token(Token = "0x400120F")]
		[FieldOffset(Offset = "0x58")]
		public FsmGameObject target;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A86BC", Offset = "0x7A86BC")]
		[Token(Token = "0x4001210")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 targetPosition;

		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7A86F4", Offset = "0x7A86F4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A86F4", Offset = "0x7A86F4")]
		[Token(Token = "0x4001211")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat weight;

		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7A8748", Offset = "0x7A8748")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A8748", Offset = "0x7A8748")]
		[Token(Token = "0x4001212")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat bodyWeight;

		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7A879C", Offset = "0x7A879C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A879C", Offset = "0x7A879C")]
		[Token(Token = "0x4001213")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat headWeight;

		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7A87F0", Offset = "0x7A87F0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A87F0", Offset = "0x7A87F0")]
		[Token(Token = "0x4001214")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat eyesWeight;

		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7A8844", Offset = "0x7A8844")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A8844", Offset = "0x7A8844")]
		[Token(Token = "0x4001215")]
		[FieldOffset(Offset = "0x88")]
		public FsmFloat clampWeight;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A8898", Offset = "0x7A8898")]
		[Token(Token = "0x4001216")]
		[FieldOffset(Offset = "0x90")]
		public bool everyFrame;

		[Token(Token = "0x4001217")]
		[FieldOffset(Offset = "0x98")]
		private Animator _animator;

		[Token(Token = "0x4001218")]
		[FieldOffset(Offset = "0xA0")]
		private Transform _transform;

		[Token(Token = "0x60007D2")]
		[Address(RVA = "0xB2ABAC", Offset = "0xB2ABAC", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EB5A50]);\n\tv21 = *([v20 @ X8_v10]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202260B]) = v40;\nL_0014:\n\tthis.gameObject = 0;\n\tthis.target = 0;\n\tv44 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v44);\n\tv44.useVariable = 1;\n\tthis.targetPosition = v44;\n\tv52 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.weight = v52;\n\tv58 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0.3f);\n\tthis.bodyWeight = v58;\n\tv62 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0.6f);\n\tthis.headWeight = v62;\n\tv80 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.eyesWeight = v80;\n\tv70 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0.5f);\n\tthis.clampWeight = v70;\n\tthis.everyFrame = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			target = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			targetPosition = fsmVector;
			FsmFloat fsmFloat = 1f;
			weight = fsmFloat;
			FsmFloat fsmFloat2 = 0.3f;
			bodyWeight = fsmFloat2;
			FsmFloat fsmFloat3 = 0.6f;
			headWeight = fsmFloat3;
			FsmFloat fsmFloat4 = 1f;
			eyesWeight = fsmFloat4;
			FsmFloat fsmFloat5 = 0.5f;
			clampWeight = fsmFloat5;
			everyFrame = false;
		}

		[Token(Token = "0x60007D3")]
		[Address(RVA = "0xB2AC8C", Offset = "0xB2AC8C", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Fsm::set_HandleAnimatorIK(this.fsm, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnPreprocess()
		{
			Fsm.HandleAnimatorIK = true;
		}

		[Token(Token = "0x60007D4")]
		[Address(RVA = "0xB2ACAC", Offset = "0xB2ACAC", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EDA5A8]);\n\tv21 = *([v20 @ X8_v15]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202260C]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv91 = *([v66 @ X8_v5+E0]);\n\tv92 = v91 == 0;\n\tv93 = ~v92;\n\tif (v93) goto L_002B;\n\tv98 = v66;\n\tv95 = \"il2cpp_codegen_runtime_class_init\"(v98, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv80 = UnityEngine.Object::op_Equality(v45, 0);\n\tv100 = v80 == 0;\n\tv101 = ~v100;\n\tif (v101) goto L_0052;\n\tv140 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._animator = v140;\n\tgoto L_0046;\n\tv145 = *([v141 @ X0_v16+E0]);\n\tv146 = v145 == 0;\n\tv147 = ~v146;\n\tif (v147) goto L_0046;\n\tv149 = \"il2cpp_codegen_runtime_class_init\"(v141, v139, v74, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv133 = UnityEngine.Object::op_Equality(v140, 0);\n\tv134 = v133 == 0;\n\tif (v134) goto L_0058;\nL_0052:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0058:\n\tv154 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.target);\n\tgoto L_0068;\n\tv158 = *([v86 @ X8_v11+E0]);\n\tv159 = v158 == 0;\n\tv160 = ~v159;\n\tif (v160) goto L_0068;\n\tv165 = v86;\n\tv162 = \"il2cpp_codegen_runtime_class_init\"(v165, v153, v52, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0068:\n\tv81 = UnityEngine.Object::op_Inequality(v154, 0);\n\tv167 = v81 == 0;\n\tif (v167) goto L_0078;\n\tv169 = UnityEngine.GameObject::get_transform(v154);\n\tthis._transform = v169;\nL_0078:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60007D5")]
		[Address(RVA = "0xB2AE0C", Offset = "0xB2AE0C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetAnimatorLookAt::DoSetLookAt(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DoAnimatorIK(int layerIndex)
		{
			DoSetLookAt();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60007D6")]
		[Address(RVA = "0xB2AE48", Offset = "0xB2AE48", Length = "0x448")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv32 = *([1EB49D0]);\n\tv33 = *([v32 @ X8_v23]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([202260D]) = v52;\nL_0021:\n\tgoto L_002A;\n\tv60 = *([v56 @ X0_v2+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_002A;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v56, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_002A:\n\tv70 = UnityEngine.Object::op_Equality(this._animator, 0);\n\tv72 = v70 == 0;\n\tif (v72) goto L_0040;\nL_003A:\n\treturn;\nL_0040:\n\tgoto L_0049;\n\tv268 = *([v131 @ X0_v6+E0]);\n\tv269 = v268 == 0;\n\tv270 = ~v269;\n\tif (v270) goto L_0049;\n\tv272 = \"il2cpp_codegen_runtime_class_init\"(v131, v68, v69, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0049:\n\tv277 = UnityEngine.Object::op_Inequality(this._transform, 0);\n\tv283 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.targetPosition);\n\tv368 = v277 == 0;\n\tif (v368) goto L_006B;\n\tv488 = this._animator;\n\tv445 = UnityEngine.Transform::get_position(this._transform);\n\tv444 = v445.y;\n\tv443 = v445.z;\n\tv460 = v283 == 0;\n\tif (v460) goto L_007E;\n\tgoto L_00A0;\nL_006B:\n\tv371 = v283 == 0;\n\tv372 = ~v371;\n\tif (v372) goto L_00A6;\n\tv488 = this._animator;\n\tv445 = HutongGames.PlayMaker.FsmVector3::get_Value(this.targetPosition);\n\tv444 = v445.y;\n\tv443 = v445.z;\n\tv462 = this._animator == 0;\n\tv354 = ~v462;\n\tif (v354) goto L_FFFFFFFF;\n\tgoto L_018F;\nL_007E:\n\tv469 = HutongGames.PlayMaker.FsmVector3::get_Value(this.targetPosition);\n\tgoto L_0099;\n\tv500 = *([v495 @ X0_v54+E0]);\n\tv501 = v500 == 0;\n\tv502 = ~v501;\n\tif (v502) goto L_0099;\n\tv504 = \"il2cpp_codegen_runtime_class_init\"(v495, v336, v109, v37, v38, v39, v40, v41, v469, v491, v492, v45, v46, v47, v48, v49);\nL_0099:\n\tv445 = UnityEngine.Vector3::op_Addition(v445, v469);\n\tv444 = v445.y;\n\tv443 = v445.z;\nL_00A0:\n\t// 160 MakeStruct v437 @ AGGB2AFF0_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v445 @ V0_v2 (UnityEngine.Vector3), v444 @ V1_v2 (System.Single), v443 @ V2_v2 (System.Single)\n\tUnityEngine.Animator::SetLookAtPosition(v454, v437);\nL_00A6:\n\tv461 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.clampWeight);\n\tv464 = v461 == 0;\n\tif (v464) goto L_00E8;\n\tv499 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.eyesWeight);\n\tv510 = v499 == 0;\n\tif (v510) goto L_011D;\n\tv511 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.headWeight);\n\tv513 = v511 == 0;\n\tif (v513) goto L_014B;\n\tv514 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.bodyWeight);\n\tv516 = v514 == 0;\n\tif (v516) goto L_0172;\n\tv113 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.weight);\n\tv518 = v113 == 0;\n\tv115 = ~v518;\n\tif (v115) goto L_003A;\n\tv163 = HutongGames.PlayMaker.FsmFloat::get_Value(this.weight);\n\tUnityEngine.Animator::SetLookAtWeight(this._animator, v163);\n\treturn;\nL_00E8:\n\tv373 = HutongGames.PlayMaker.FsmFloat::get_Value(this.weight);\n\tv374 = HutongGames.PlayMaker.FsmFloat::get_Value(this.bodyWeight);\n\tv375 = HutongGames.PlayMaker.FsmFloat::get_Value(this.headWeight);\n\tv376 = HutongGames.PlayMaker.FsmFloat::get_Value(this.eyesWeight);\n\tv307 = HutongGames.PlayMaker.FsmFloat::get_Value(this.clampWeight);\n\tUnityEngine.Animator::SetLookAtWeight(this._animator, v373, v374, v375, v376, v307);\n\treturn;\nL_011D:\n\tv377 = HutongGames.PlayMaker.FsmFloat::get_Value(this.weight);\n\tv378 = HutongGames.PlayMaker.FsmFloat::get_Value(this.bodyWeight);\n\tv379 = HutongGames.PlayMaker.FsmFloat::get_Value(this.headWeight);\n\tv308 = HutongGames.PlayMaker.FsmFloat::get_Value(this.eyesWeight);\n\tUnityEngine.Animator::SetLookAtWeight(this._animator, v377, v378, v379, v308);\n\treturn;\nL_014B:\n\tv380 = HutongGames.PlayMaker.FsmFloat::get_Value(this.weight);\n\tv381 = HutongGames.PlayMaker.FsmFloat::get_Value(this.bodyWeight);\n\tv309 = HutongGames.PlayMaker.FsmFloat::get_Value(this.headWeight);\n\tUnityEngine.Animator::SetLookAtWeight(this._animator, v380, v381, v309);\n\treturn;\nL_0172:\n\tv382 = HutongGames.PlayMaker.FsmFloat::get_Value(this.weight);\n\tv310 = HutongGames.PlayMaker.FsmFloat::get_Value(this.bodyWeight);\n\tUnityEngine.Animator::SetLookAtWeight(this._animator, v382, v310);\n\treturn;\n\tthrow System.NullReferenceException;\nL_018F:\n\tthrow System.NullReferenceException;\n// 302 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetLookAt()
		{
			if (_animator == null)
			{
				return;
			}
			bool flag = _transform != null;
			bool isNone = targetPosition.IsNone;
			Animator animator;
			Vector3 vector;
			float y;
			float z;
			Animator animator2;
			if (flag)
			{
				animator = _animator;
				vector = _transform.position;
				y = vector.y;
				z = vector.z;
				if (isNone)
				{
					animator2 = _animator;
					goto IL_0449;
				}
				Vector3 value = targetPosition.Value;
				vector += value;
				y = vector.y;
				z = vector.z;
			}
			else
			{
				if (isNone)
				{
					goto IL_01b3;
				}
				animator = _animator;
				vector = targetPosition.Value;
				y = vector.y;
				z = vector.z;
				if ((object)_animator == null)
				{
					throw new NullReferenceException();
				}
			}
			animator2 = animator;
			goto IL_0449;
			IL_0449:
			Vector3 lookAtPosition = default(Vector3);
			lookAtPosition.x = vector.x;
			lookAtPosition.y = y;
			lookAtPosition.z = z;
			animator2.SetLookAtPosition(lookAtPosition);
			goto IL_01b3;
			IL_01b3:
			if (clampWeight.IsNone)
			{
				if (eyesWeight.IsNone)
				{
					if (headWeight.IsNone)
					{
						if (bodyWeight.IsNone)
						{
							if (!weight.IsNone)
							{
								float value2 = weight.Value;
								_animator.SetLookAtWeight(value2);
							}
						}
						else
						{
							float value3 = weight.Value;
							float value4 = bodyWeight.Value;
							_animator.SetLookAtWeight(value3, value4);
						}
					}
					else
					{
						float value5 = weight.Value;
						float value6 = bodyWeight.Value;
						float value7 = headWeight.Value;
						_animator.SetLookAtWeight(value5, value6, value7);
					}
				}
				else
				{
					float value8 = weight.Value;
					float value9 = bodyWeight.Value;
					float value10 = headWeight.Value;
					float value11 = eyesWeight.Value;
					_animator.SetLookAtWeight(value8, value9, value10, value11);
				}
			}
			else
			{
				float value12 = weight.Value;
				float value13 = bodyWeight.Value;
				float value14 = headWeight.Value;
				float value15 = eyesWeight.Value;
				float value16 = clampWeight.Value;
				_animator.SetLookAtWeight(value12, value13, value14, value15, value16);
			}
		}

		[Token(Token = "0x60007D7")]
		[Address(RVA = "0xB2B290", Offset = "0xB2B290", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetAnimatorLookAt()
		{
		}
	}
}
