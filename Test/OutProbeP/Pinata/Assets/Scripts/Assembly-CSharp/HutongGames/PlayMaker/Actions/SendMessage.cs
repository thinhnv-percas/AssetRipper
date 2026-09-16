using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75D3F4", Offset = "0x75D3F4")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75D3F4", Offset = "0x75D3F4")]
	[Token(Token = "0x2000345")]
	public class SendMessage : FsmStateAction
	{
		[Token(Token = "0x200049C")]
		public enum MessageType
		{
			[Token(Token = "0x40021CE")]
			SendMessage = 0,
			[Token(Token = "0x40021CF")]
			SendMessageUpwards = 1,
			[Token(Token = "0x40021D0")]
			BroadcastMessage = 2
		}

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8FA4", Offset = "0x7C8FA4")]
		[Token(Token = "0x4001AEB")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8FF0", Offset = "0x7C8FF0")]
		[Token(Token = "0x4001AEC")]
		[FieldOffset(Offset = "0x58")]
		public MessageType delivery;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C9028", Offset = "0x7C9028")]
		[Token(Token = "0x4001AED")]
		[FieldOffset(Offset = "0x5C")]
		public SendMessageOptions options;

		[RequiredField]
		[Token(Token = "0x4001AEE")]
		[FieldOffset(Offset = "0x60")]
		public FunctionCall functionCall;

		[Token(Token = "0x6001062")]
		[Address(RVA = "0xB2751C", Offset = "0xB2751C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tthis.delivery = 0x100000000;\n\tthis.functionCall = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_0016: Expected I4, but got I8
			gameObject = null;
			delivery = MessageType.SendMessage;
			functionCall = null;
		}

		[Token(Token = "0x6001063")]
		[Address(RVA = "0xB2752C", Offset = "0xB2752C", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SendMessage::DoSendMessage(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSendMessage();
			Finish();
		}

		[Token(Token = "0x6001064")]
		[Address(RVA = "0xB27554", Offset = "0xB27554", Length = "0x6D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EF0230]);\n\tv21 = *([v20 @ X8_v136]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20225E7]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv270 = *([v266 @ X8_v6+E0]);\n\tv271 = v270 == 0;\n\tv272 = ~v271;\n\tif (v272) goto L_002B;\n\tv338 = v266;\n\tv274 = \"il2cpp_codegen_runtime_class_init\"(v338, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv279 = UnityEngine.Object::op_Equality(v45, 0);\n\tv340 = v279 == 0;\n\tif (v340) goto L_0036;\nL_0035:\n\treturn;\nL_0036:\n\tv390 = this.functionCall;\n\tv394 = <PrivateImplementationDetails>::ComputeStringHash(v390.parameterType);\n\tv486 = v394 < 0x994C5594;\n\tv487 = ~v486;\n\tv488 = v394 - 0x994C5594;\n\tv490 = v488 == 0;\n\tv495 = ~v490;\n\tv496 = v487 & v495;\n\tif (v496) goto L_0095;\n\tv499 = v394 < 0x6B109927;\n\tv500 = ~v499;\n\tv501 = v394 - 0x6B109927;\n\tv503 = v501 == 0;\n\tv508 = ~v503;\n\tv509 = v500 & v508;\n\tif (v509) goto L_00DD;\n\tv525 = v394 < 0x17C16538;\n\tv526 = ~v525;\n\tv527 = v394 - 0x17C16538;\n\tv529 = v527 == 0;\n\tv534 = ~v529;\n\tv73 = v526 & v534;\n\tif (v73) goto L_015D;\n\tv142 = v394 == 0x16C8FCC6;\n\tif (v142) goto L_020D;\n\tv66 = v394 != 0x17C16538;\n\tif (v66) goto L_FFFFFFFF;\n\tv438 = System.String::op_Equality(v390.parameterType, \"string\");\n\tv722 = v438 == 0;\n\tif (v722) goto L_02B3;\n\tv250 = this.functionCall;\n\tv794 = HutongGames.PlayMaker.FsmString::get_Value(v250.StringParameter);\n\tgoto L_FFFFFFFF;\nL_0095:\n\tv512 = v394 < 0xCBD54F80;\n\tv513 = ~v512;\n\tv514 = v394 - 0xCBD54F80;\n\tv516 = v514 == 0;\n\tv521 = ~v516;\n\tv522 = v513 & v521;\n\tif (v522) goto L_011F;\n\tv549 = v394 < 0xC4167764;\n\tv550 = ~v549;\n\tv551 = v394 - 0xC4167764;\n\tv553 = v551 == 0;\n\tv558 = ~v553;\n\tv74 = v550 & v558;\n\tif (v74) goto L_018A;\n\tv143 = v394 == 0xA6C45D85;\n\tif (v143) goto L_0220;\n\tv67 = v394 != 0xC4167764;\n\tif (v67) goto L_FFFFFFFF;\n\tv439 = System.String::op_Equality(v390.parameterType, \"GameObject\");\n\tv753 = v439 == 0;\n\tif (v753) goto L_02B3;\n\tv251 = this.functionCall;\n\tv855 = HutongGames.PlayMaker.FsmGameObject::get_Value(v251.GameObjectParameter);\n\tgoto L_FFFFFFFF;\nL_00DD:\n\tv537 = v394 < 0x840071C3;\n\tv538 = ~v537;\n\tv539 = v394 - 0x840071C3;\n\tv541 = v539 == 0;\n\tv546 = ~v541;\n\tv75 = v538 & v546;\n\tif (v75) goto L_01B6;\n\tv414 = v394 == 0x83007030;\n\tif (v414) goto L_0237;\n\tv68 = v394 != 0x840071C3;\n\tif (v68) goto L_FFFFFFFF;\n\tv440 = System.String::op_Equality(v390.parameterType, \"Vector3\");\n\tv754 = v440 == 0;\n\tif (v754) goto L_02B3;\n\tv252 = this.functionCall;\n\tv799 = HutongGames.PlayMaker.FsmVector3::get_Value(v252.Vector3Parameter);\n\tgoto L_FFFFFFFF;\nL_011F:\n\tv561 = v394 < 0xE58E64DA;\n\tv562 = ~v561;\n\tv563 = v394 - 0xE58E64DA;\n\tv565 = v563 == 0;\n\tv570 = ~v565;\n\tv396 = v562 & v570;\n\tif (v396) goto L_01E2;\n\tv415 = v394 == 0xDE63ACAD;\n\tif (v415) goto L_024F;\n\tv69 = v394 != 0xE58E64DA;\n\tif (v69) goto L_FFFFFFFF;\n\tv441 = System.String::op_Equality(v390.parameterType, \"Object\");\n\tv755 = v441 == 0;\n\tif (v755) goto L_02B3;\n\tv253 = this.functionCall;\n\tv864 = HutongGames.PlayMaker.FsmObject::get_Value(v253.ObjectParameter);\n\tgoto L_FFFFFFFF;\nL_015D:\n\tv580 = v394 == 0x304FF7FB;\n\tif (v580) goto L_0263;\n\tv395 = v394 != 0x6B109927;\n\tif (v395) goto L_FFFFFFFF;\n\tv442 = System.String::op_Equality(v390.parameterType, \"Rect\");\n\tv756 = v442 == 0;\n\tif (v756) goto L_02B3;\n\tv475 = this.functionCall;\n\tv476 = v475.RectParamater;\n\tgoto L_02A9;\nL_018A:\n\tv144 = v394 == 0xC894953D;\n\tif (v144) goto L_026B;\n\tv70 = v394 != 0xCBD54F80;\n\tif (v70) goto L_FFFFFFFF;\n\tv443 = System.String::op_Equality(v390.parameterType, \"Material\");\n\tv757 = v443 == 0;\n\tif (v757) goto L_02B3;\n\tv254 = this.functionCall;\n\tv858 = HutongGames.PlayMaker.FsmMaterial::get_Value(v254.MaterialParameter);\n\tgoto L_FFFFFFFF;\nL_01B6:\n\tv145 = v394 == 0x95E97E5E;\n\tif (v145) goto L_0282;\n\tv71 = v394 != 0x994C5594;\n\tif (v71) goto L_FFFFFFFF;\n\tv444 = System.String::op_Equality(v390.parameterType, \"Texture\");\n\tv758 = v444 == 0;\n\tif (v758) goto L_02B3;\n\tv255 = this.functionCall;\n\tv850 = HutongGames.PlayMaker.FsmTexture::get_Value(v255.TextureParameter);\n\tgoto L_FFFFFFFF;\nL_01E2:\n\tv416 = v394 == 0xE5B43CF8;\n\tif (v416) goto L_029B;\n\tv72 = v394 != 0xE84DDA20;\n\tif (v72) goto L_FFFFFFFF;\n\tv445 = System.String::op_Equality(v390.parameterType, \"Enum\");\n\tv759 = v445 == 0;\n\tif (v759) goto L_02B3;\n\tv256 = this.functionCall;\n\tv867 = HutongGames.PlayMaker.FsmEnum::get_Value(v256.EnumParameter);\n\tgoto L_FFFFFFFF;\nL_020D:\n\tv446 = System.String::op_Equality(v390.parameterType, \"Array\");\n\tv680 = v446 == 0;\n\tif (v680) goto L_02B3;\n\tv257 = this.functionCall;\n\tv773 = HutongGames.PlayMaker.FsmArray::get_Values(v257.ArrayParameter);\n\tgoto L_FFFFFFFF;\nL_0220:\n\tv447 = System.String::op_Equality(v390.parameterType, \"float\");\n\tv702 = v447 == 0;\n\tif (v702) goto L_02B3;\n\tv258 = this.functionCall;\n\tv784 = HutongGames.PlayMaker.FsmFloat::get_Value(v258.FloatParameter);\n\tgoto L_FFFFFFFF;\nL_0237:\n\tv448 = System.String::op_Equality(v390.parameterType, \"Vector2\");\n\tv690 = v448 == 0;\n\tif (v690) goto L_02B3;\n\tv477 = this.functionCall;\n\tv478 = v477.Vector2Parameter;\n\tgoto L_FFFFFFFF;\nL_024F:\n\tv449 = System.String::op_Equality(v390.parameterType, \"Quaternion\");\n\tv714 = v449 == 0;\n\tif (v714) goto L_02B3;\n\tv479 = this.functionCall;\n\tv480 = v479.QuaternionParameter;\n\tv787 = v480.value;\n\tgoto L_02A9;\nL_0263:\n\tv618 = System.String::op_Equality(v390.parameterType, \"None\");\n\tgoto L_02B3;\nL_026B:\n\tv450 = System.String::op_Equality(v390.parameterType, \"bool\");\n\tv708 = v450 == 0;\n\tif (v708) goto L_02B3;\n\tv259 = this.functionCall;\n\tv786 = HutongGames.PlayMaker.FsmBool::get_Value(v259.BoolParameter);\n\tgoto L_FFFFFFFF;\nL_0282:\n\tv451 = System.String::op_Equality(v390.parameterType, \"int\");\n\tv696 = v451 == 0;\n\tif (v696) goto L_02B3;\n\tv260 = this.functionCall;\n\tv782 = HutongGames.PlayMaker.FsmInt::get_Value(v260.IntParameter);\n\tgoto L_02AC;\nL_029B:\n\tv452 = System.String::op_Equality(v390.parameterType, \"Color\");\n\tv720 = v452 == 0;\n\tif (v720) goto L_02B3;\n\tv481 = this.functionCall;\n\tv482 = v481.ColorParameter;\nL_02A9:\n\tv905 = *([v845 @ X8_v14]);\nL_02AC:\n\tv750 = \"il2cpp_vm_object_box\"(v905, v887, v886, v25, v26, v27, v28, v29, v784, v799.y, v799.z, v33, v34, v35, v36, v37);\nL_02B3:\n\tv364 = this.delivery == 2;\n\tif (v364) goto L_02D1;\n\tv363 = this.delivery == 1;\n\tif (v363) goto L_02DC;\n\tv771 = this.delivery == 0;\n\tv382 = ~v771;\n\tif (v382) goto L_0035;\n\tv387 = this.functionCall;\n\tUnityEngine.GameObject::SendMessage(v45, v387.FunctionName, v373, this.options);\n\tgoto L_0035;\nL_02D1:\n\tv388 = this.functionCall;\n\tUnityEngine.GameObject::BroadcastMessage(v45, v388.FunctionName, v373, this.options);\n\tgoto L_0035;\nL_02DC:\n\tv389 = this.functionCall;\n\tUnityEngine.GameObject::SendMessageUpwards(v45, v389.FunctionName, v373, this.options);\n\tgoto L_0035;\n\tv223 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 533 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSendMessage()
		{
			//IL_009c: Expected I4, but got I8
			//IL_025f: Expected I4, but got I8
			//IL_0506: Expected I4, but got I8
			//IL_02c4: Expected I4, but got I8
			//IL_03d5: Expected I4, but got I8
			//IL_0d41: Expected I4, but got O
			//IL_0d5b: Expected O, but got I4
			//IL_0970: Expected I4, but got F4
			//IL_0d2c: Expected O, but got I4
			//IL_09ef: Expected I4, but got O
			//IL_04b1: Expected I4, but got O
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget == null)
			{
				return;
			}
			FunctionCall functionCall = this.functionCall;
			uint num = global::_003CPrivateImplementationDetails_003E.ComputeStringHash(functionCall.ParameterType);
			bool flag = (int)num < 2571916692L;
			bool flag2 = !flag;
			int num2 = (int)((int)num - 2571916692L);
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			object obj;
			Quaternion value;
			object typeFromHandle;
			object obj3 = default(object);
			int num6;
			object typeFromHandle3;
			float x;
			object typeFromHandle2;
			if (!(flag2 && flag4))
			{
				bool flag5 = (int)num < 1796249895;
				bool flag6 = !flag5;
				int num3 = (int)(num - 1796249895);
				bool flag7 = num3 == 0;
				bool flag8 = !flag7;
				if (!(flag6 && flag8))
				{
					bool flag9 = (int)num < 398550328;
					bool flag10 = !flag9;
					int num4 = (int)(num - 398550328);
					bool flag11 = num4 == 0;
					bool flag12 = !flag11;
					if (flag10 && flag12)
					{
						if (num != 810547195)
						{
							if (num == 1796249895)
							{
								bool flag13 = functionCall.ParameterType == "Rect";
								bool flag14 = !flag13;
								obj = null;
								if (flag14)
								{
									goto IL_0d05;
								}
								FunctionCall functionCall2 = this.functionCall;
								FsmRect rectParamater = functionCall2.RectParamater;
								value = (Quaternion)rectParamater.value;
								object obj2 = null;
								typeFromHandle = typeof(Rect);
								goto IL_0d31;
							}
						}
						else
						{
							bool flag15 = functionCall.ParameterType == "None";
						}
						goto IL_0aa2;
					}
					if (num != 382270662)
					{
						if (num != 398550328)
						{
							goto IL_0aa2;
						}
						bool flag16 = functionCall.ParameterType == "string";
						bool flag17 = !flag16;
						obj = null;
						if (!flag17)
						{
							FunctionCall functionCall3 = this.functionCall;
							string value2 = functionCall3.StringParameter.Value;
							obj3 = value2;
							goto IL_0c1f;
						}
					}
					else
					{
						bool flag18 = functionCall.ParameterType == "Array";
						bool flag19 = !flag18;
						obj = null;
						if (!flag19)
						{
							FunctionCall functionCall4 = this.functionCall;
							object[] values = functionCall4.ArrayParameter.Values;
							obj3 = values;
							goto IL_0c1f;
						}
					}
				}
				else
				{
					bool flag20 = (int)num < 2214621635L;
					bool flag21 = !flag20;
					int num5 = (int)((int)num - 2214621635L);
					bool flag22 = num5 == 0;
					bool flag23 = !flag22;
					if (!(flag21 && flag23))
					{
						if ((int)num != 2197844016L)
						{
							if ((int)num != 2214621635L)
							{
								goto IL_0aa2;
							}
							bool flag24 = functionCall.ParameterType == "Vector3";
							bool flag25 = !flag24;
							obj = null;
							if (flag25)
							{
								goto IL_0d05;
							}
							FunctionCall functionCall5 = this.functionCall;
							Vector3 value3 = functionCall5.Vector3Parameter.Value;
							num6 = (int)value3;
							x = value3.x;
							object obj2 = null;
							typeFromHandle2 = typeof(Vector3);
						}
						else
						{
							bool flag26 = functionCall.ParameterType == "Vector2";
							bool flag27 = !flag26;
							obj = null;
							if (flag27)
							{
								goto IL_0d05;
							}
							FunctionCall functionCall6 = this.functionCall;
							FsmVector2 vector2Parameter = functionCall6.Vector2Parameter;
							num6 = (int)vector2Parameter.value;
							object obj2 = null;
							typeFromHandle2 = typeof(Vector2);
						}
						goto IL_0d24;
					}
					if ((int)num != 2515107422L)
					{
						if ((int)num != 2571916692L)
						{
							goto IL_0aa2;
						}
						bool flag28 = functionCall.ParameterType == "Texture";
						bool flag29 = !flag28;
						obj = null;
						if (!flag29)
						{
							FunctionCall functionCall7 = this.functionCall;
							Texture value4 = functionCall7.TextureParameter.Value;
							obj3 = value4;
							goto IL_0c1f;
						}
					}
					else
					{
						bool flag30 = functionCall.ParameterType == "int";
						bool flag31 = !flag30;
						obj = null;
						if (!flag31)
						{
							FunctionCall functionCall8 = this.functionCall;
							int value5 = functionCall8.IntParameter.Value;
							num6 = value5;
							object obj2 = null;
							typeFromHandle3 = typeof(int);
							goto IL_0d53;
						}
					}
				}
			}
			else
			{
				bool flag32 = (int)num < 3419754368L;
				bool flag33 = !flag32;
				int num7 = (int)((int)num - 3419754368L);
				bool flag34 = num7 == 0;
				bool flag35 = !flag34;
				if (!(flag33 && flag35))
				{
					bool flag36 = (int)num < 3289806692L;
					bool flag37 = !flag36;
					int num8 = (int)((int)num - 3289806692L);
					bool flag38 = num8 == 0;
					bool flag39 = !flag38;
					if (!(flag37 && flag39))
					{
						if ((int)num != 2797886853L)
						{
							if ((int)num != 3289806692L)
							{
								goto IL_0aa2;
							}
							bool flag40 = functionCall.ParameterType == "GameObject";
							bool flag41 = !flag40;
							obj = null;
							if (!flag41)
							{
								FunctionCall functionCall9 = this.functionCall;
								GameObject value6 = functionCall9.GameObjectParameter.Value;
								obj3 = value6;
								goto IL_0c1f;
							}
						}
						else
						{
							bool flag42 = functionCall.ParameterType == "float";
							bool flag43 = !flag42;
							obj = null;
							if (!flag43)
							{
								FunctionCall functionCall10 = this.functionCall;
								x = functionCall10.FloatParameter.Value;
								num6 = (int)x;
								object obj2 = null;
								typeFromHandle2 = typeof(float);
								goto IL_0d24;
							}
						}
					}
					else if ((int)num != 3365180733L)
					{
						if ((int)num != 3419754368L)
						{
							goto IL_0aa2;
						}
						bool flag44 = functionCall.ParameterType == "Material";
						bool flag45 = !flag44;
						obj = null;
						if (!flag45)
						{
							FunctionCall functionCall11 = this.functionCall;
							Material value7 = functionCall11.MaterialParameter.Value;
							obj3 = value7;
							goto IL_0c1f;
						}
					}
					else
					{
						bool flag46 = functionCall.ParameterType == "bool";
						bool flag47 = !flag46;
						obj = null;
						if (!flag47)
						{
							FunctionCall functionCall12 = this.functionCall;
							bool value8 = functionCall12.BoolParameter.Value;
							num6 = (value8 ? 1 : 0);
							object obj2 = null;
							typeFromHandle3 = typeof(bool);
							goto IL_0d53;
						}
					}
				}
				else
				{
					bool flag48 = (int)num < 3851314394L;
					bool flag49 = !flag48;
					int num9 = (int)((int)num - 3851314394L);
					bool flag50 = num9 == 0;
					bool flag51 = !flag50;
					if (!(flag49 && flag51))
					{
						if ((int)num != 3731074221L)
						{
							if ((int)num != 3851314394L)
							{
								goto IL_0aa2;
							}
							bool flag52 = functionCall.ParameterType == "Object";
							bool flag53 = !flag52;
							obj = null;
							if (!flag53)
							{
								FunctionCall functionCall13 = this.functionCall;
								UnityEngine.Object value9 = functionCall13.ObjectParameter.Value;
								obj3 = value9;
								goto IL_0c1f;
							}
						}
						else
						{
							bool flag54 = functionCall.ParameterType == "Quaternion";
							bool flag55 = !flag54;
							obj = null;
							if (!flag55)
							{
								FunctionCall functionCall14 = this.functionCall;
								FsmQuaternion quaternionParameter = functionCall14.QuaternionParameter;
								value = quaternionParameter.value;
								object obj2 = null;
								typeFromHandle = typeof(Quaternion);
								goto IL_0d31;
							}
						}
					}
					else if ((int)num != 3853794552L)
					{
						if ((int)num != 3897416224L)
						{
							goto IL_0aa2;
						}
						bool flag56 = functionCall.ParameterType == "Enum";
						bool flag57 = !flag56;
						obj = null;
						if (!flag57)
						{
							FunctionCall functionCall15 = this.functionCall;
							Enum value10 = functionCall15.EnumParameter.Value;
							obj3 = value10;
							goto IL_0c1f;
						}
					}
					else
					{
						bool flag58 = functionCall.ParameterType == "Color";
						bool flag59 = !flag58;
						obj = null;
						if (!flag59)
						{
							FunctionCall functionCall16 = this.functionCall;
							FsmColor colorParameter = functionCall16.ColorParameter;
							value = (Quaternion)colorParameter.value;
							object obj2 = null;
							typeFromHandle = typeof(Color);
							goto IL_0d31;
						}
					}
				}
			}
			goto IL_0d05;
			IL_0d68:
			Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			goto IL_0c1f;
			IL_0d31:
			typeFromHandle2 = typeFromHandle;
			num6 = (int)value;
			x = value.x;
			goto IL_0d24;
			IL_0d53:
			object obj4 = num6;
			typeFromHandle2 = typeFromHandle3;
			goto IL_0d68;
			IL_0d24:
			obj4 = num6;
			goto IL_0d68;
			IL_0c1f:
			obj = obj3;
			goto IL_0d05;
			IL_0d05:
			if (delivery != MessageType.BroadcastMessage)
			{
				if (delivery != MessageType.SendMessageUpwards)
				{
					if (delivery == MessageType.SendMessage)
					{
						FunctionCall functionCall17 = this.functionCall;
						ownerDefaultTarget.SendMessage(functionCall17.FunctionName, obj, options);
					}
				}
				else
				{
					FunctionCall functionCall18 = this.functionCall;
					ownerDefaultTarget.SendMessageUpwards(functionCall18.FunctionName, obj, options);
				}
			}
			else
			{
				FunctionCall functionCall19 = this.functionCall;
				ownerDefaultTarget.BroadcastMessage(functionCall19.FunctionName, obj, options);
			}
			return;
			IL_0aa2:
			obj = null;
			goto IL_0d05;
		}

		[Token(Token = "0x6001065")]
		[Address(RVA = "0xB27C24", Offset = "0xB27C24", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SendMessage()
		{
		}
	}
}
