using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75D444", Offset = "0x75D444")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75D444", Offset = "0x75D444")]
	[Token(Token = "0x2000346")]
	public class StartCoroutine : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C9070", Offset = "0x7C9070")]
		[Token(Token = "0x4001AEF")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C90BC", Offset = "0x7C90BC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C90BC", Offset = "0x7C90BC")]
		[Token(Token = "0x4001AF0")]
		[FieldOffset(Offset = "0x58")]
		public FsmString behaviour;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C911C", Offset = "0x7C911C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C911C", Offset = "0x7C911C")]
		[Token(Token = "0x4001AF1")]
		[FieldOffset(Offset = "0x60")]
		public FunctionCall functionCall;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C917C", Offset = "0x7C917C")]
		[Token(Token = "0x4001AF2")]
		[FieldOffset(Offset = "0x68")]
		public bool stopOnExit;

		[Token(Token = "0x4001AF3")]
		[FieldOffset(Offset = "0x70")]
		private MonoBehaviour component;

		[Token(Token = "0x6001066")]
		[Address(RVA = "0x99D9EC", Offset = "0x99D9EC", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.stopOnExit = 0;\n\tthis.behaviour = 0;\n\tthis.functionCall = 0;\n\tthis.gameObject = 0;\n\treturn;\n")]
		public override void Reset()
		{
			stopOnExit = false;
			behaviour = null;
			functionCall = null;
			gameObject = null;
		}

		[Token(Token = "0x6001067")]
		[Address(RVA = "0x99D9FC", Offset = "0x99D9FC", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.StartCoroutine::DoStartCoroutine(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoStartCoroutine();
			Finish();
		}

		[Token(Token = "0x6001068")]
		[Address(RVA = "0x99DA24", Offset = "0x99DA24", Length = "0x6FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EAE928]);\n\tv23 = *([v22 @ X8_v117]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20217B8]) = v42;\nL_001A:\n\tv47 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002C;\n\tv279 = *([v259 @ X8_v4+E0]);\n\tv280 = v279 == 0;\n\tv281 = ~v280;\n\tif (v281) goto L_002C;\n\tv404 = v259;\n\tv283 = \"il2cpp_codegen_runtime_class_init\"(v404, v45, v46, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002C:\n\tv286 = UnityEngine.Object::op_Equality(v47, 0);\n\tv406 = v286 == 0;\n\tif (v406) goto L_003C;\nL_0037:\n\treturn;\nL_003C:\n\tv515 = HutongGames.PlayMaker.FsmString::get_Value(this.behaviour);\n\tgoto L_004D;\n\tv523 = *([v519 @ X8_v7+E0]);\n\tv524 = v523 == 0;\n\tv525 = ~v524;\n\tif (v525) goto L_004D;\n\tv533 = v519;\n\tv528 = \"il2cpp_codegen_runtime_class_init\"(v533, v514, v205, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_004D:\n\tv532 = HutongGames.PlayMaker.ReflectionUtils::GetGlobalType(v515);\n\tv538 = UnityEngine.GameObject::GetComponent(v47, v532);\n\tv575 = v538 == 0;\n\tif (v575) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_007B;\n\tv617 = v617_asT == 0;\n\tif (v617) goto L_FFFFFFFF;\n\tgoto L_007B;\nL_007B:\n\tthis.component = v195;\n\tgoto L_0089;\n\tv625 = *([v621 @ X0_v18+E0]);\n\tv626 = v625 == 0;\n\tv627 = ~v626;\n\tgoto L_0089;\n\tv629 = \"il2cpp_codegen_runtime_class_init\"(v621, v534, v537, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0089:\n\tv548 = UnityEngine.Object::op_Equality(v195, 0);\n\tv634 = v548 == 0;\n\tif (v634) goto L_00AE;\n\tv547 = UnityEngine.Object::get_name(v47);\n\tv639 = HutongGames.PlayMaker.FsmString::get_Value(this.behaviour);\n\tv659 = System.String::Concat(\"StartCoroutine: \", v547, \" missing behaviour: \", v639);\n\tHutongGames.PlayMaker.FsmStateAction::LogWarning(this, v659);\n\treturn;\nL_00AE:\n\tv569 = this.functionCall;\n\tv461 = <PrivateImplementationDetails>::ComputeStringHash(v569.parameterType);\n\tv642 = v461 < 0x95E97E5E;\n\tv643 = ~v642;\n\tv644 = v461 - 0x95E97E5E;\n\tv646 = v644 == 0;\n\tv651 = ~v646;\n\tv652 = v643 & v651;\n\tif (v652) goto L_010D;\n\tv662 = v461 < 0x6B109927;\n\tv663 = ~v662;\n\tv664 = v461 - 0x6B109927;\n\tv666 = v664 == 0;\n\tv671 = ~v666;\n\tv70 = v663 & v671;\n\tif (v70) goto L_0158;\n\tv140 = v461 == 0x17C16538;\n\tif (v140) goto L_01FB;\n\tv141 = v461 == 0x304FF7FB;\n\tif (v141) goto L_020F;\n\tv413 = v461 != 0x6B109927;\n\tif (v413) goto L_0037;\n\tv462 = System.String::op_Equality(v569.parameterType, \"Rect\");\n\tv477 = v462 == 0;\n\tif (v477) goto L_0037;\n\tv570 = this.functionCall;\n\tv539 = v570.RectParamater;\n\tv513 = v570.FunctionName;\n\tv492 = this.component;\n\tgoto L_02C2;\nL_010D:\n\tv674 = v461 < 0xC4167764;\n\tv675 = ~v674;\n\tv676 = v461 - 0xC4167764;\n\tv678 = v676 == 0;\n\tv683 = ~v678;\n\tv71 = v675 & v683;\n\tif (v71) goto L_0190;\n\tv142 = v461 == 0x994C5594;\n\tif (v142) goto L_0229;\n\tv143 = v461 == 0xA6C45D85;\n\tif (v143) goto L_024B;\n\tv66 = v461 != 0xC4167764;\n\tif (v66) goto L_0037;\n\tv463 = System.String::op_Equality(v569.parameterType, \"GameObject\");\n\tv478 = v463 == 0;\n\tif (v478) goto L_0037;\n\tv260 = this.functionCall;\n\tv567 = this.component;\n\tv574 = v260.FunctionName;\n\tv852 = HutongGames.PlayMaker.FsmGameObject::get_Value(v260.GameObjectParameter);\n\tgoto L_0244;\nL_0158:\n\tv433 = v461 == 0x83007030;\n\tif (v433) goto L_0263;\n\tv144 = v461 == 0x840071C3;\n\tif (v144) goto L_027C;\n\tv67 = v461 != 0x95E97E5E;\n\tif (v67) goto L_0037;\n\tv464 = System.String::op_Equality(v569.parameterType, \"int\");\n\tv479 = v464 == 0;\n\tif (v479) goto L_0037;\n\tv261 = this.functionCall;\n\tv492 = this.component;\n\tv513 = v261.FunctionName;\n\tv879 = HutongGames.PlayMaker.FsmInt::get_Value(v261.IntParameter);\n\tgoto L_FFFFFFFF;\nL_0190:\n\tv695 = v461 < 0xCBD54F80;\n\tv696 = ~v695;\n\tv697 = v461 - 0xCBD54F80;\n\tv699 = v697 == 0;\n\tv704 = ~v699;\n\tv72 = v696 & v704;\n\tif (v72) goto L_01CF;\n\tv145 = v461 == 0xC894953D;\n\tif (v145) goto L_0298;\n\tv68 = v461 != 0xCBD54F80;\n\tif (v68) goto L_0037;\n\tv465 = System.String::op_Equality(v569.parameterType, \"Material\");\n\tv480 = v465 == 0;\n\tif (v480) goto L_0037;\n\tv262 = this.functionCall;\n\tv567 = this.component;\n\tv574 = v262.FunctionName;\n\tv853 = HutongGames.PlayMaker.FsmMaterial::get_Value(v262.MaterialParameter);\n\tgoto L_0244;\nL_01CF:\n\tv434 = v461 == 0xDE63ACAD;\n\tif (v434) goto L_02B3;\n\tv69 = v461 != 0xE58E64DA;\n\tif (v69) goto L_0037;\n\tv466 = System.String::op_Equality(v569.parameterType, \"Object\");\n\tv481 = v466 == 0;\n\tif (v481) goto L_0037;\n\tv263 = this.functionCall;\n\tv567 = this.component;\n\tv574 = v263.FunctionName;\n\tv854 = HutongGames.PlayMaker.FsmObject::get_Value(v263.ObjectParameter);\n\tgoto L_0244;\nL_01FB:\n\tv467 = System.String::op_Equality(v569.parameterType, \"string\");\n\tv482 = v467 == 0;\n\tif (v482) goto L_0037;\n\tv264 = this.functionCall;\n\tv567 = this.component;\n\tv574 = v264.FunctionName;\n\tv772 = HutongGames.PlayMaker.FsmString::get_Value(v264.StringParameter);\n\tgoto L_0244;\nL_020F:\n\tv468 = System.String::op_Equality(v569.parameterType, \"None\");\n\tv483 = v468 == 0;\n\tif (v483) goto L_0037;\n\tv265 = this.functionCall;\n\tv379 = UnityEngine.MonoBehaviour::StartCoroutine(this.component, v265.FunctionName);\n\treturn;\nL_0229:\n\tv469 = System.String::op_Equality(v569.parameterType, \"Texture\");\n\tv484 = v469 == 0;\n\tif (v484) goto L_0037;\n\tv266 = this.functionCall;\n\tv567 = this.component;\n\tv574 = v266.FunctionName;\n\tv785 = HutongGames.PlayMaker.FsmTexture::get_Value(v266.TextureParameter);\nL_0244:\n\tv380 = UnityEngine.MonoBehaviour::StartCoroutine(v567, v574, v549);\n\treturn;\nL_024B:\n\tv470 = System.String::op_Equality(v569.parameterType, \"float\");\n\tv485 = v470 == 0;\n\tif (v485) goto L_0037;\n\tv267 = this.functionCall;\n\tv492 = this.component;\n\tv513 = v267.FunctionName;\n\tv804 = HutongGames.PlayMaker.FsmFloat::get_Value(v267.FloatParameter);\n\tgoto L_FFFFFFFF;\nL_0263:\n\tv471 = System.String::op_Equality(v569.parameterType, \"Vector2\");\n\tv486 = v471 == 0;\n\tif (v486) goto L_0037;\n\tv571 = this.functionCall;\n\tv540 = v571.Vector2Parameter;\n\tv492 = this.component;\n\tv513 = v571.FunctionName;\n\tgoto L_FFFFFFFF;\nL_027C:\n\tv472 = System.String::op_Equality(v569.parameterType, \"Vector3\");\n\tv487 = v472 == 0;\n\tif (v487) goto L_0037;\n\tv268 = this.functionCall;\n\tv492 = this.component;\n\tv513 = v268.FunctionName;\n\tv789 = HutongGames.PlayMaker.FsmVector3::get_Value(v268.Vector3Parameter);\n\tgoto L_FFFFFFFF;\nL_0298:\n\tv473 = System.String::op_Equality(v569.parameterType, \"bool\");\n\tv488 = v473 == 0;\n\tif (v488) goto L_0037;\n\tv269 = this.functionCall;\n\tv492 = this.component;\n\tv513 = v269.FunctionName;\n\tv865 = HutongGames.PlayMaker.FsmBool::get_Value(v269.BoolParameter);\n\tgoto L_02C5;\nL_02B3:\n\tv474 = System.String::op_Equality(v569.parameterType, \"Quaternion\");\n\tv489 = v474 == 0;\n\tif (v489) goto L_0037;\n\tv572 = this.functionCall;\n\tv541 = v572.QuaternionParameter;\n\tv513 = v572.FunctionName;\n\tv492 = this.component;\nL_02C2:\n\tv895 = *([v841 @ X8_v19]);\nL_02C5:\n\tv550 = \"il2cpp_vm_object_box\"(v895, v545, v892, v27, v28, v29, v30, v31, v789, v789.y, v789.z, v35, v36, v37, v38, v39);\n\tv475 = UnityEngine.MonoBehaviour::StartCoroutine(v492, v513, v550);\n\tgoto L_0037;\n\tthrow System.NullReferenceException;\n\treturn;\n// 507 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoStartCoroutine()
		{
			//IL_01b7: Expected I4, but got I8
			//IL_0368: Expected I4, but got I8
			//IL_05a2: Expected I4, but got I8
			//IL_0b86: Expected O, but got I4
			//IL_0af1: Expected O, but got I4
			//IL_09d1: Expected O, but got I4
			//IL_0bdf: Expected O, but got I4
			//IL_092b: Expected O, but got F4
			//IL_0933: Expected O, but got F4
			//IL_093c: Expected O, but got I4
			//IL_0a61: Expected O, but got I4
			//IL_055f: Expected O, but got I4
			//IL_0325: Expected O, but got I4
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget == null)
			{
				return;
			}
			string value = behaviour.Value;
			Type globalType = ReflectionUtils.GetGlobalType(value);
			Component component = ownerDefaultTarget.GetComponent(globalType);
			UnityEngine.Object obj;
			if ((object)component == null)
			{
				obj = null;
			}
			else
			{
				MonoBehaviour monoBehaviour = component as MonoBehaviour;
				obj = (((object)monoBehaviour == null) ? null : component);
			}
			this.component = (MonoBehaviour)obj;
			if (obj == null)
			{
				string text = ownerDefaultTarget.name;
				string value2 = behaviour.Value;
				string text2 = "StartCoroutine: " + text + " missing behaviour: " + value2;
				LogWarning(text2);
				return;
			}
			FunctionCall functionCall = this.functionCall;
			uint num = global::_003CPrivateImplementationDetails_003E.ComputeStringHash(functionCall.ParameterType);
			bool flag = (int)num < 2515107422L;
			bool flag2 = !flag;
			int num2 = (int)((int)num - 2515107422L);
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			MonoBehaviour monoBehaviour2;
			string functionName;
			int num4;
			object typeFromHandle;
			Vector3 vector;
			object typeFromHandle3;
			MonoBehaviour monoBehaviour3;
			string functionName2;
			object value6;
			Vector3 value4;
			object typeFromHandle2;
			if (!(flag2 && flag4))
			{
				bool flag5 = (int)num < 1796249895;
				bool flag6 = !flag5;
				int num3 = (int)(num - 1796249895);
				bool flag7 = num3 == 0;
				bool flag8 = !flag7;
				if (flag6 && flag8)
				{
					if ((int)num != 2197844016L)
					{
						object obj2;
						if ((int)num != 2214621635L)
						{
							if ((int)num != 2515107422L || !(functionCall.ParameterType == "int"))
							{
								return;
							}
							FunctionCall functionCall2 = this.functionCall;
							monoBehaviour2 = this.component;
							functionName = functionCall2.FunctionName;
							int value3 = functionCall2.IntParameter.Value;
							num4 = value3;
							obj2 = 0;
							typeFromHandle = typeof(int);
							goto IL_0bd7;
						}
						if (!(functionCall.ParameterType == "Vector3"))
						{
							return;
						}
						FunctionCall functionCall3 = this.functionCall;
						monoBehaviour2 = this.component;
						functionName = functionCall3.FunctionName;
						value4 = functionCall3.Vector3Parameter.Value;
						vector = value4;
						obj2 = 0;
						typeFromHandle2 = typeof(Vector3);
					}
					else
					{
						if (!(functionCall.ParameterType == "Vector2"))
						{
							return;
						}
						FunctionCall functionCall4 = this.functionCall;
						FsmVector2 vector2Parameter = functionCall4.Vector2Parameter;
						monoBehaviour2 = this.component;
						functionName = functionCall4.FunctionName;
						vector = vector2Parameter.value;
						object obj2 = 0;
						typeFromHandle2 = typeof(Vector2);
					}
					goto IL_0bec;
				}
				if (num != 398550328)
				{
					switch (num)
					{
					default:
						return;
					case 1796249895u:
						break;
					case 810547195u:
						if (functionCall.ParameterType == "None")
						{
							FunctionCall functionCall5 = this.functionCall;
							Coroutine coroutine = this.component.StartCoroutine(functionCall5.FunctionName);
						}
						return;
					}
					if (!(functionCall.ParameterType == "Rect"))
					{
						return;
					}
					FunctionCall functionCall6 = this.functionCall;
					FsmRect rectParamater = functionCall6.RectParamater;
					functionName = functionCall6.FunctionName;
					monoBehaviour2 = this.component;
					value4 = (Vector3)rectParamater.value;
					object obj2 = 0;
					typeFromHandle3 = typeof(Rect);
					goto IL_0bc2;
				}
				if (!(functionCall.ParameterType == "string"))
				{
					return;
				}
				FunctionCall functionCall7 = this.functionCall;
				monoBehaviour3 = this.component;
				functionName2 = functionCall7.FunctionName;
				string value5 = functionCall7.StringParameter.Value;
				value6 = value5;
			}
			else
			{
				bool flag9 = (int)num < 3289806692L;
				bool flag10 = !flag9;
				int num5 = (int)((int)num - 3289806692L);
				bool flag11 = num5 == 0;
				bool flag12 = !flag11;
				if (!(flag10 && flag12))
				{
					if ((int)num != 2571916692L)
					{
						if ((int)num == 2797886853L)
						{
							if (!(functionCall.ParameterType == "float"))
							{
								return;
							}
							FunctionCall functionCall8 = this.functionCall;
							monoBehaviour2 = this.component;
							functionName = functionCall8.FunctionName;
							float value7 = functionCall8.FloatParameter.Value;
							vector = (Vector3)value7;
							value4 = (Vector3)value7;
							object obj2 = 0;
							typeFromHandle2 = typeof(float);
							goto IL_0bec;
						}
						if ((int)num != 3289806692L || !(functionCall.ParameterType == "GameObject"))
						{
							return;
						}
						FunctionCall functionCall9 = this.functionCall;
						monoBehaviour3 = this.component;
						functionName2 = functionCall9.FunctionName;
						GameObject value8 = functionCall9.GameObjectParameter.Value;
						value6 = value8;
					}
					else
					{
						if (!(functionCall.ParameterType == "Texture"))
						{
							return;
						}
						FunctionCall functionCall10 = this.functionCall;
						monoBehaviour3 = this.component;
						functionName2 = functionCall10.FunctionName;
						Texture value9 = functionCall10.TextureParameter.Value;
						value6 = value9;
					}
				}
				else
				{
					bool flag13 = (int)num < 3419754368L;
					bool flag14 = !flag13;
					int num6 = (int)((int)num - 3419754368L);
					bool flag15 = num6 == 0;
					bool flag16 = !flag15;
					if (!(flag14 && flag16))
					{
						if ((int)num == 3365180733L)
						{
							if (!(functionCall.ParameterType == "bool"))
							{
								return;
							}
							FunctionCall functionCall11 = this.functionCall;
							monoBehaviour2 = this.component;
							functionName = functionCall11.FunctionName;
							bool value10 = functionCall11.BoolParameter.Value;
							num4 = (value10 ? 1 : 0);
							object obj2 = 0;
							typeFromHandle = typeof(bool);
							goto IL_0bd7;
						}
						if ((int)num != 3419754368L || !(functionCall.ParameterType == "Material"))
						{
							return;
						}
						FunctionCall functionCall12 = this.functionCall;
						monoBehaviour3 = this.component;
						functionName2 = functionCall12.FunctionName;
						Material value11 = functionCall12.MaterialParameter.Value;
						value6 = value11;
					}
					else
					{
						if ((int)num == 3731074221L)
						{
							if (!(functionCall.ParameterType == "Quaternion"))
							{
								return;
							}
							FunctionCall functionCall13 = this.functionCall;
							FsmQuaternion quaternionParameter = functionCall13.QuaternionParameter;
							functionName = functionCall13.FunctionName;
							monoBehaviour2 = this.component;
							value4 = (Vector3)quaternionParameter.value;
							object obj2 = 0;
							typeFromHandle3 = typeof(Quaternion);
							goto IL_0bc2;
						}
						if ((int)num != 3851314394L || !(functionCall.ParameterType == "Object"))
						{
							return;
						}
						FunctionCall functionCall14 = this.functionCall;
						monoBehaviour3 = this.component;
						functionName2 = functionCall14.FunctionName;
						UnityEngine.Object value12 = functionCall14.ObjectParameter.Value;
						value6 = value12;
					}
				}
			}
			Coroutine coroutine2 = monoBehaviour3.StartCoroutine(functionName2, value6);
			return;
			IL_0bf9:
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value13 = default(object);
			Coroutine coroutine3 = monoBehaviour2.StartCoroutine(functionName, value13);
			return;
			IL_0bc2:
			typeFromHandle2 = typeFromHandle3;
			vector = value4;
			goto IL_0bec;
			IL_0bec:
			object obj3 = vector;
			goto IL_0bf9;
			IL_0bd7:
			obj3 = num4;
			typeFromHandle2 = typeFromHandle;
			goto IL_0bf9;
		}

		[Token(Token = "0x6001069")]
		[Address(RVA = "0x99E120", Offset = "0x99E120", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EB4130]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20217B9]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Equality(this.component, 0);\n\tv58 = v56 == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_003F;\n\tv61 = ~this.stopOnExit;\n\tif (v61) goto L_003F;\n\tv68 = this.functionCall;\n\tUnityEngine.MonoBehaviour::StopCoroutine(this.component, v68.FunctionName);\n\treturn;\nL_003F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnExit()
		{
			if (!(component == null) && stopOnExit)
			{
				FunctionCall functionCall = this.functionCall;
				component.StopCoroutine(functionCall.FunctionName);
			}
		}

		[Token(Token = "0x600106A")]
		[Address(RVA = "0x99E1CC", Offset = "0x99E1CC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public StartCoroutine()
		{
		}
	}
}
