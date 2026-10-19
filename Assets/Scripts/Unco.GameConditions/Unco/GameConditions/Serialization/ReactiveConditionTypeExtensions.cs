using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Newtonsoft.Json.Linq;
using Unco.GameConditions.Implementations;

namespace Unco.GameConditions.Serialization
{
	[Token(Token = "0x2000006")]
	public static class ReactiveConditionTypeExtensions
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000007")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400000C")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400000D")]
			public static Func<SerializableReactiveCondition, ReactiveCondition> _003C_003E9__0_0;

			[Token(Token = "0x400000E")]
			public static Func<SerializableReactiveCondition, ReactiveCondition> _003C_003E9__0_1;

			[Token(Token = "0x400000F")]
			public static Func<object, SerializableReactiveCondition> _003C_003E9__2_0;

			[Token(Token = "0x4000010")]
			public static Func<object, SerializableReactiveCondition> _003C_003E9__2_1;

			[Token(Token = "0x4000011")]
			public static Func<ReactiveCondition, SerializableReactiveCondition> _003C_003E9__4_0;

			[Token(Token = "0x600000C")]
			[Address(RVA = "0x81ADDB0", Offset = "0x81ADDB0", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new Unco.GameConditions.Serialization.ReactiveConditionTypeExtensions+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600000D")]
			[Address(RVA = "0x81ADE14", Offset = "0x81ADE14", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal ReactiveCondition _003CDeserialize_003Eb__0_0(SerializableReactiveCondition c)
			{
				return c.Deserialize();
			}

			internal ReactiveCondition _003CDeserialize_003Eb__0_1(SerializableReactiveCondition c)
			{
				return c.Deserialize();
			}

			internal SerializableReactiveCondition _003CDeserializeArrayFromData_003Eb__2_0(object item)
			{
				bool flag = item == null;
				object result = item;
				if (!flag)
				{
					SerializableReactiveCondition serializableReactiveCondition = item as SerializableReactiveCondition;
					bool flag2 = serializableReactiveCondition != null;
					result = item;
					if (!flag2)
					{
						if (item is JObject)
						{
							return (SerializableReactiveCondition)((JToken)item).ToObject<object>();
						}
						result = null;
					}
				}
				return (SerializableReactiveCondition)result;
			}

			internal SerializableReactiveCondition _003CDeserializeArrayFromData_003Eb__2_1(object item)
			{
				bool flag = item == null;
				object result = item;
				if (!flag)
				{
					SerializableReactiveCondition serializableReactiveCondition = item as SerializableReactiveCondition;
					bool flag2 = serializableReactiveCondition != null;
					result = item;
					if (!flag2)
					{
						if (item is JObject)
						{
							return (SerializableReactiveCondition)((JToken)item).ToObject<object>();
						}
						result = null;
					}
				}
				return (SerializableReactiveCondition)result;
			}

			internal SerializableReactiveCondition _003CSerialize_003Eb__4_0(ReactiveCondition c)
			{
				return c.Serialize();
			}
		}

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x81AC534", Offset = "0x81AC534", Length = "0xC30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0064;\n\tv53 = System.String::IsNullOrEmpty(serializable.type);\n\tv60 = ~v53;\n\tv61 = ~v60;\n\tif (v61) goto L_02AF;\n\tgoto L_007C;\nL_007C:\n\tv104 = 0x21C1544(serializable.type, Il2CppMethodInfo, Il2CppMethodInfo, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv115 = System.Type::op_Equality(v104, 0);\n\tv126 = v115 == 0;\n\tv127 = ~v126;\n\tif (v127) goto L_02C7;\n\tgoto L_0092;\n\tv230 = 0xB28B000 + 0x2B8;\n\tgoto L_00B3;\nL_00A3:\n\tgoto L_00A9;\n\tv230 = 0xB28B000 + 0x2B0;\nL_00CB:\n\tgoto L_00D1;\n\tv481 = serializable.nestedCondition;\n\tv457 = serializable.nestedCondition == 0;\n\tv458 = ~v457;\n\tif (v458) goto L_00E8;\n\tv474 = Unco.GameConditions.Serialization.ReactiveConditionTypeExtensions::DeserializeFromData(serializable.data, 0);\n\tv479 = v474 == 0;\nL_FFFFFFFF:\n\tv481 = v474;\n\tif (v479) goto L_02E5;\nL_00E8:\n\tv550 = new Unco.GameConditions.Implementations.NotCondition();\n\tv550._lastState = -1;\n\tSystem.Object::.ctor(v550);\n\tv512 = Unco.GameConditions.Serialization.ReactiveConditionTypeExtensions::Deserialize(v481);\nL_FFFFFFFF:\n\tv319 = v512;\nL_FFFFFFFF:\n\tv334 = \"m_condition\";\nL_FFFFFFFF:\n\tv556 = v550;\nL_0108:\n\tgoto L_010E;\n\tv666 = serializable.leftCondition;\n\tv524 = serializable.leftCondition == 0;\n\tif (v524) goto L_0160;\n\tv671 = serializable.rightCondition;\n\tv559 = serializable.rightCondition == 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv641 = v666;\n\tif (v559) goto L_016C;\nL_011B:\n\tv637 = v666 == 0;\n\tv638 = ~v637;\n\tif (v638) goto L_0171;\n\tgoto L_02DD;\nL_0126:\n\tgoto L_012C;\n\tv785 = serializable.leftCondition;\n\tv686 = serializable.leftCondition == 0;\n\tif (v686) goto L_01D2;\n\tv790 = serializable.rightCondition;\n\tv702 = serializable.rightCondition == 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv744 = v785;\n\tif (v702) goto L_01DE;\nL_0139:\n\tv740 = v785 == 0;\n\tv741 = ~v740;\n\tif (v741) goto L_01E3;\n\tgoto L_02ED;\nL_0144:\n\tgoto L_014A;\n\tv873 = serializable.leftCondition;\n\tv805 = serializable.leftCondition == 0;\n\tif (v805) goto L_026C;\n\tv878 = serializable.rightCondition;\n\tv822 = serializable.rightCondition == 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv854 = v873;\n\tif (v822) goto L_0278;\nL_0157:\n\tv850 = v873 == 0;\n\tv851 = ~v850;\n\tif (v851) goto L_027D;\n\tgoto L_02F5;\nL_0160:\n\tv666 = Unco.GameConditions.Serialization.ReactiveConditionTypeExtensions::DeserializeFromData(serializable.data, 0);\n\tv671 = serializable.rightCondition;\n\tv653 = serializable.rightCondition == 0;\n\tv633 = ~v653;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv641 = v666;\n\tif (v633) goto L_011B;\nL_016C:\n\tv652 = Unco.GameConditions.Serialization.ReactiveConditionTypeExtensions::DeserializeFromData(serializable.data, 1);\n\tv669 = v641 == 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv666 = v641;\nL_FFFFFFFF:\n\tv671 = v652;\n\tif (v669) goto L_02DD;\nL_0171:\n\tv674 = v671 == 0;\n\tif (v674) goto L_02DD;\n\tv684 = Unco.GameConditions.Serialization.ReactiveConditionTypeExtensions::Deserialize(v666);\n\tv700 = Unco.GameConditions.Serialization.ReactiveConditionTypeExtensions::Deserialize(v671);\n\tv777 = 0xB28B000 + 0x308;\nL_FFFFFFFF:\n\tv768 = v684;\nL_FFFFFFFF:\n\tv779 = v700;\n\tgoto L_01ED;\nL_0182:\n\tgoto L_0188;\n\tv1002 = serializable.conditions;\n\tv892 = serializable.conditions == 0;\n\tv893 = ~v892;\n\tif (v893) goto L_0199;\n\tv905 = Unco.GameConditions.Serialization.ReactiveConditionTypeExtensions::DeserializeArrayFromData(serializable.data);\n\tv908 = v905 == 0;\nL_FFFFFFFF:\n\tv1002 = v905;\n\tif (v908) goto L_02FD;\nL_0199:\n\tv912 = v1002.Length == 0;\n\tif (v912) goto L_02FD;\n\tv926 = new Unco.GameConditions.Implementations.AllCondition();\n\tv926._lastState = -1;\n\tSystem.Object::.ctor(v926);\n\tgoto L_01B2;\n\tgoto L_01C0;\nL_01D2:\n\tv785 = Unco.GameConditions.Serialization.ReactiveConditionTypeExtensions::DeserializeFromData(serializable.data, 0);\n\tv790 = serializable.rightCondition;\n\tv756 = serializable.rightCondition == 0;\n\tv736 = ~v756;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv744 = v785;\n\tif (v736) goto L_0139;\nL_01DE:\n\tv755 = Unco.GameConditions.Serialization.ReactiveConditionTypeExtensions::DeserializeFromData(serializable.data, 1);\n\tv788 = v744 == 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv785 = v744;\nL_FFFFFFFF:\n\tv790 = v755;\n\tif (v788) goto L_02ED;\nL_01E3:\n\tv776 = v790 == 0;\n\tif (v776) goto L_02ED;\n\tv803 = Unco.GameConditions.Serialization.ReactiveConditionTypeExtensions::Deserialize(v785);\n\tv775 = Unco.GameConditions.Serialization.ReactiveConditionTypeExtensions::Deserialize(v790);\n\tv777 = 0xB292000 + 0x7E0;\nL_FFFFFFFF:\n\tv768 = v803;\nL_FFFFFFFF:\n\tv779 = v775;\n\t*([v784 @ X0_v150 (System.Object)+28]) = v779;\n\treturn v784;\nL_020F:\n\tgoto L_0213;\nL_0213:\n\tv917 = System.Type::GetTypeFromHandle(Unco.GameConditions.Implementations.AnyCondition);\n\tv720 = System.Type::op_Equality(v104, v917);\n\tv721 = ~v720;\n\tif (v721) goto L_0317;\n\tv1002 = serializable.conditions;\n\tv948 = serializable.conditions == 0;\n\tv949 = ~v948;\n\tif (v949) goto L_0224;\n\tv965 = Unco.GameConditions.Serialization.ReactiveConditionTypeExtensions::DeserializeArrayFromData(serializable.data);\n\tv968 = v965 == 0;\nL_FFFFFFFF:\n\tv1002 = v965;\n\tif (v968) goto L_0305;\nL_0224:\n\tv972 = v1002.Length == 0;\n\tif (v972) goto L_0305;\n\tv1014 = new Unco.GameConditions.Implementations.AnyCondition();\n\tv1014._lastState = -1;\n\tSystem.Object::.ctor(v1014);\n\tgoto L_023D;\n\tgoto L_024B;\nL_025E:\n\tv1010 = System.Linq.Enumerable::Select(v1002, v548);\n\tv1030 = System.Linq.Enumerable::ToArray(v1010);\nL_FFFFFFFF:\n\tv319 = v1030;\nL_FFFFFFFF:\n\tv334 = v544;\nL_FFFFFFFF:\n\tv550 = v557;\nL_FFFFFFFF:\n\tv556 = v557;\n\tgoto L_00F5;\nL_026C:\n\tv873 = Unco.GameConditions.Serialization.ReactiveConditionTypeExtensions::DeserializeFromData(serializable.data, 0);\n\tv878 = serializable.rightCondition;\n\tv866 = serializable.rightCondition == 0;\n\tv846 = ~v866;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv854 = v873;\n\tif (v846) goto L_0157;\nL_0278:\n\tv865 = Unco.GameConditions.Serialization.ReactiveConditionTypeExtensions::DeserializeFromData(serializable.data, 1);\n\tv876 = v854 == 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv873 = v854;\nL_FFFFFFFF:\n\tv878 = v865;\n\tif (v876) goto L_02F5;\nL_027D:\n\tv346 = v878 == 0;\n\tif (v346) goto L_02F5;\n\tv890 = Unco.GameConditions.Serialization.ReactiveConditionTypeExtensions::Deserialize(v873);\n\tv903 = Unco.GameConditions.Serialization.ReactiveConditionTypeExtensions::Deserialize(v878);\n\tv922 = new Unco.GameConditions.Implementations.XorCondition();\n\tUnco.GameConditions.Implementations.XorCondition::.ctor(v922, v890, v903);\n\treturn v922;\nL_0298:\n\tv55 = 0xB28B000 + 0x600;\n\tv62 = new v55();\n\tv90 = 0xB30F000 + 0xCE0;\n\tv107 = 0xB2EE000 + 0x3F8;\n\tSystem.ArgumentNullException::.ctor(v62, v90, v107);\n\tthrow v62;\nL_02AF:\n\tv87 = 0xB28B000 + 0x5F8;\n\tv105 = new v87();\n\tv118 = 0xB2EF000 + 0x498;\n\tv130 = 0xB30F000 + 0xCE0;\n\tSystem.ArgumentException::.ctor(v105, v118, v130);\n\tthrow v105;\nL_02C7:\n\tv162 = 0xB2F2000 + 0xDB0;\n\tv180 = System.String::Concat(v162, *([serializable @ X0 (Unco.GameConditions.Serialization.SerializableReactiveCondition)+10]));\n\tv193 = 0xB290000 + 0xB18;\n\tv200 = new v193();\n\tSystem.InvalidOperationException::.ctor(v200, v180);\n\tthrow v200;\nL_02DD:\n\tv682 = 0xB290000 + 0xB18;\n\tv697 = new v682();\n\tv598 = 0xB2EC000 + 0x3E0;\nL_FFFFFFFF:\n\tv622 = v697;\n\tgoto L_030F;\nL_02E5:\n\tv509 = 0xB290000 + 0xB18;\n\tv517 = new v509();\n\tv598 = 0xB2F8000 + 0xBF0;\nL_FFFFFFFF:\n\tv622 = v517;\n\tgoto L_030F;\nL_02ED:\n\tv801 = 0xB290000 + 0xB18;\n\tv819 = new v801();\n\tv598 = 0xB2F9000 + 0x928;\nL_FFFFFFFF:\n\tv622 = v819;\n\tgoto L_030F;\nL_02F5:\n\tv888 = 0xB290000 + 0xB18;\n\tv900 = new v888();\n\tv598 = 0xB303000 + 0x208;\nL_FFFFFFFF:\n\tv622 = v900;\n\tgoto L_030F;\nL_02FD:\n\tv929 = 0xB290000 + 0xB18;\n\tv937 = new v929();\n\tv598 = 0xB2EC000 + 0x80;\nL_FFFFFFFF:\n\tv622 = v937;\n\tgoto L_030F;\nL_0305:\n\tv1017 = 0xB290000 + 0xB18;\n\tv1032 = new v1017();\n\tv598 = 0xB2EC000 + 0x490;\nL_FFFFFFFF:\n\tv622 = v1032;\nL_FFFFFFFF:\n\t;\n\tthrow v622;\nL_0317:\n\tv727 = 0x3175AC4(v104, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv437 = *([v104 @ X0_v60 (System.Type)]);\n\t*([v437 @ X8_v23+2F8])(v763, v104, *([v437 \n// ... truncated")]
		public static ReactiveCondition Deserialize(this SerializableReactiveCondition serializable)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ReactiveConditionTypeExtensions::Deserialize");
			return default;
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0x4C5838C", Offset = "0x4C5838C", Length = "0x1CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tgoto L_0015;\nL_0015:\n\tv44 = data == 0;\n\tif (v44) goto L_0051;\nL_0018:\n\tv51 = data.Length < index;\n\tv52 = ~v51;\n\tv53 = data.Length - index;\n\tv55 = v53 == 0;\n\tv62 = data.Length <= index;\n\tif (v62) goto L_0051;\n\tv100 = ~v52;\n\tv68 = v100 | v55;\n\tif (v68) goto L_0092;\n\tv87 = data[index @ X1 (System.Int32)] == 0;\n\tif (v87) goto L_0051;\n\tgoto L_0039;\nL_0043:\n\treturn returnVal2;\n\tv46 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv213 = data == 0;\n\tv48 = ~v213;\n\tif (v48) goto L_0018;\nL_0051:\n\treturn 0;\nL_0062:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v162_asT @ Z_v8 (Newtonsoft.Json.Linq.JObject), typeof(Newtonsoft.Json.Linq.JObject), data[index @ X1 (System.Int32)]\n\tv162 = v162_asT != 0;\n\tif (v162) goto L_0090;\n\tgoto L_007E;\n\tv315 = new System.InvalidCastException();\n\tgoto L_00BC;\nL_0090:\n\treturnVal5 = Newtonsoft.Json.Linq.JToken::ToObject(data[index @ X1 (System.Int32)]);\n\treturn returnVal5;\nL_0092:\n\tv214 = new System.IndexOutOfRangeException();\n\tv138 = index != 1;\nL_FFFFFFFF:\n\tv203 = v214;\n\tif (v138) goto L_00C0;\n\tv232 = 0x8BF5BC4(v214, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv258 = 0xB7D5000 + 0x538;\n\tv193 = *([v232 @ X0_v12]);\n\tv260 = \"il2cpp_vm_class_is_assignable_from\"(*([v258 @ X8_v8 (System.Int32)+10]), *([v193 @ X8_v9]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv188 = v260 == 0;\n\tif (v188) goto L_00B5;\n\tv299 = 0x8BF5BF4(v260, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn 0;\nL_00B5:\n\tv301 = 0x8BF5BAC(8, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v301 @ X0_v16]) = *([v232 @ X0_v12]);\n\tv310 = 0xA67A000 + 0x440;\n\tv315 = 0x8BF5C48(v301, v310, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_00BC:\n\t// 188 Interrupt\n\tv249 = 0x8BF5BF4(v315, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv203 = v315;\nL_00C0:\n\tv255 = 0x8BF0368(v203, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal3 = 0xA1B8(v255, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal3;\nL_0039:\n\treturnVal2 = 0x21C11D0(data[index @ X1 (System.Int32)], Il2CppClass<T>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv187 = returnVal2 == 0;\n\tif (v187) goto L_0062;\nL_007E:\n\treturnVal2 = 0x21C11D0(data[index @ X1 (System.Int32)], Il2CppClass<T>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv313 = returnVal2 == 0;\n\tv273 = ~v313;\n\tif (v273) goto L_0043;\n")]
		private static T DeserializeFromData<T>(object[] data, int index) where T : class
		{
			InvalidCastException ex3 = default(InvalidCastException);
			IndexOutOfRangeException ex2;
			if (data != null)
			{
				bool flag = (uint)data.Length < (uint)index;
				bool flag2 = !flag;
				int num = data.Length - index;
				bool flag3 = num == 0;
				if (data.Length > index)
				{
					bool flag4 = !flag2;
					if (flag4 || flag3)
					{
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						bool flag5 = index != 1;
						ex2 = ex;
						if (!flag5)
						{
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5BC4");
							int num2 = 192761856 + 1336;
							object obj2 = default(object);
							object obj = obj2;
							Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_class_is_assignable_from", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
							object obj3 = default(object);
							if (obj3 != null)
							{
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5BF4");
								return null;
							}
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5BAC");
							object obj4 = obj2;
							nint num3 = 174564416;
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5C48");
							goto IL_023c;
						}
						goto IL_0259;
					}
					if (data[index] != null)
					{
						Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
						T val = default(T);
						if (val == null)
						{
							if (data[index] is JObject)
							{
								return (T)((JToken)data[index]).ToObject<object>();
							}
							Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
							if (val == null)
							{
								ex3 = new InvalidCastException();
								goto IL_023c;
							}
						}
						return val;
					}
				}
			}
			return null;
			IL_023c:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5BF4");
			ex2 = (IndexOutOfRangeException)(object)ex3;
			goto IL_0259;
			IL_0259:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF0368");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @A1B8");
			T result = default(T);
			return result;
		}

		[Token(Token = "0x6000007")]
		[Address(RVA = "0x81AD424", Offset = "0x81AD424", Length = "0x22C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv48 = data.Length == 0;\n\tif (v48) goto L_0077;\n\tv70 = data.Length != 1;\n\tif (v70) goto L_007D;\n\tv210 = 0x21C11D0(data[0], System.Object[], v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv130 = v210 == 0;\n\tif (v130) goto L_007D;\n\tgoto L_004A;\n\tgoto L_005B;\nL_FFFFFFFF:\n\tv218 = v254;\nL_0077:\n\treturn 0;\nL_007D:\n\tgoto L_007F;\nL_007F:\n\tv173 = v140.<>9__2_1;\n\tv142 = v140.<>9__2_1 == 0;\n\tv143 = ~v142;\n\tif (v143) goto L_FFFFFFFF;\n\tgoto L_008E;\nL_008E:\n\tgoto L_0096;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv208 = v173;\nL_FFFFFFFF:\n\tv210 = data;\nL_0026:\n\tv43 = data == 0;\n\tif (v43) goto L_0077;\nL_004A:\n\tv218 = v192.<>9__2_0;\n\tv194 = v192.<>9__2_0 == 0;\n\tv195 = ~v194;\n\tif (v195) goto L_FFFFFFFF;\nL_005B:\n\tv254 = new System.Func`2<System.Object, Unco.GameConditions.Serialization.SerializableReactiveCondition>();\n\tSystem.Func`2<System.Object, Unco.GameConditions.Serialization.SerializableReactiveCondition>::.ctor(v254, v227.<>9, Il2CppMethodInfo);\n\tv264.<>9__2_0 = v254;\nL_00A9:\n\tv219 = System.Linq.Enumerable::Select(v210, v208);\n\treturnVal2 = System.Linq.Enumerable::ToArray(v219);\n\treturn returnVal2;\nL_0096:\n\tv243 = new System.Func`2<System.Object, Unco.GameConditions.Serialization.SerializableReactiveCondition>();\n\tSystem.Func`2<System.Object, Unco.GameConditions.Serialization.SerializableReactiveCondition>::.ctor(v243, v238.<>9, Il2CppMethodInfo);\n\tv262.<>9__2_1 = v243;\nL_FFFFFFFF:\n\tv173 = v243;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv208 = v218;\n\tgoto L_00A9;\n")]
		private static SerializableReactiveCondition[] DeserializeArrayFromData(object[] data)
		{
			IEnumerable<object> enumerable = default(IEnumerable<object>);
			Func<object, object> selector;
			if (data != null && data.Length != 0)
			{
				if (data.Length == 1)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
					if (enumerable != null)
					{
						Func<object, SerializableReactiveCondition> func = _003C_003Ec._003C_003E9__2_0;
						if (_003C_003Ec._003C_003E9__2_0 == null)
						{
							func = (_003C_003Ec._003C_003E9__2_0 = delegate(object item)
							{
								bool flag = item == null;
								object result = item;
								if (!flag)
								{
									SerializableReactiveCondition serializableReactiveCondition = item as SerializableReactiveCondition;
									bool flag2 = serializableReactiveCondition != null;
									result = item;
									if (!flag2)
									{
										if (item is JObject)
										{
											return (SerializableReactiveCondition)((JToken)item).ToObject<object>();
										}
										result = null;
									}
								}
								return (SerializableReactiveCondition)result;
							});
						}
						selector = func;
						goto IL_0144;
					}
				}
				Func<object, SerializableReactiveCondition> func2 = _003C_003Ec._003C_003E9__2_1;
				if (_003C_003Ec._003C_003E9__2_1 == null)
				{
					func2 = (_003C_003Ec._003C_003E9__2_1 = delegate(object item)
					{
						bool flag = item == null;
						object result = item;
						if (!flag)
						{
							SerializableReactiveCondition serializableReactiveCondition = item as SerializableReactiveCondition;
							bool flag2 = serializableReactiveCondition != null;
							result = item;
							if (!flag2)
							{
								if (item is JObject)
								{
									return (SerializableReactiveCondition)((JToken)item).ToObject<object>();
								}
								result = null;
							}
						}
						return (SerializableReactiveCondition)result;
					});
				}
				selector = func2;
				enumerable = data;
				goto IL_0144;
			}
			return null;
			IL_0144:
			IEnumerable<object> source = enumerable.Select(selector);
			return (SerializableReactiveCondition[])source.ToArray();
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x81AD670", Offset = "0x81AD670", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v90_asT @ Z_v7 (Unco.GameConditions.Serialization.SerializableReactiveCondition), typeof(Unco.GameConditions.Serialization.SerializableReactiveCondition), item @ X0 (System.Object)\n\tv90 = v90_asT != 0;\nL_FFFFFFFF:\n\treturnVal1 = item;\n\tif (v90) goto L_005E;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v164_asT @ Z_v6 (Newtonsoft.Json.Linq.JObject), typeof(Newtonsoft.Json.Linq.JObject), item @ X0 (System.Object)\n\tv164 = v164_asT != 0;\n\tif (v164) goto L_0067;\nL_FFFFFFFF:\n\treturnVal1 = 0;\nL_0067:\n\treturnVal2 = Newtonsoft.Json.Linq.JToken::ToObject(item);\n\treturn returnVal2;\nL_001A:\n\tv41 = item == 0;\nL_FFFFFFFF:\n\treturnVal1 = item;\n\tif (v41) goto L_005E;\nL_005E:\n\treturn returnVal1;\n")]
		private static SerializableReactiveCondition DeserializeConditionFromObject(object item)
		{
			bool flag = item == null;
			SerializableReactiveCondition result = (SerializableReactiveCondition)item;
			if (!flag)
			{
				SerializableReactiveCondition serializableReactiveCondition = item as SerializableReactiveCondition;
				bool flag2 = serializableReactiveCondition != null;
				result = (SerializableReactiveCondition)item;
				if (!flag2)
				{
					if (item is JObject)
					{
						return (SerializableReactiveCondition)((JToken)item).ToObject<object>();
					}
					result = null;
				}
			}
			return result;
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x81AD74C", Offset = "0x81AD74C", Length = "0x664")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004F;\n\tv55 = System.Object::GetType(condition);\n\tv78 = new Unco.GameConditions.Serialization.SerializableReactiveCondition();\n\tSystem.Object::.ctor(v78);\n\tv103 = System.Type::get_AssemblyQualifiedName(v55);\n\tv78.type = v103;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v153_asT @ Z_v32 (Unco.GameConditions.Implementations.AlwaysTrueCondition), typeof(Unco.GameConditions.Implementations.AlwaysTrueCondition), condition @ X0 (Unco.GameConditions.Implementations.ReactiveCondition)\n\tv153 = v153_asT != 0;\n\tif (v153) goto L_01DA;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v273_asT @ Z_v31 (Unco.GameConditions.Implementations.AlwaysFalseCondition), typeof(Unco.GameConditions.Implementations.AlwaysFalseCondition), condition @ X0 (Unco.GameConditions.Implementations.ReactiveCondition)\n\tv273 = v273_asT != 0;\n\tif (v273) goto L_01DA;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v412_asT @ Z_v30 (Unco.GameConditions.Implementations.NotCondition), typeof(Unco.GameConditions.Implementations.NotCondition), condition @ X0 (Unco.GameConditions.Implementations.ReactiveCondition)\n\tv412 = v412_asT != 0;\n\tif (v412) goto L_0195;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v510_asT @ Z_v29 (Unco.GameConditions.Implementations.AndCondition), typeof(Unco.GameConditions.Implementations.AndCondition), condition @ X0 (Unco.GameConditions.Implementations.ReactiveCondition)\n\tv510 = v510_asT != 0;\n\tif (v510) goto L_0175;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v569_asT @ Z_v28 (Unco.GameConditions.Implementations.OrCondition), typeof(Unco.GameConditions.Implementations.OrCondition), condition @ X0 (Unco.GameConditions.Implementations.ReactiveCondition)\n\tv569 = v569_asT != 0;\n\tif (v569) goto L_0175;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v570_asT @ Z_v27 (Unco.GameConditions.Implementations.XorCondition), typeof(Unco.GameConditions.Implementations.XorCondition), condition @ X0 (Unco.GameConditions.Implementations.ReactiveCondition)\n\tv570 = v570_asT != 0;\n\tif (v570) goto L_0175;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v687_asT @ Z_v26 (Unco.GameConditions.Implementations.AllCondition), typeof(Unco.GameConditions.Implementations.AllCondition), condition @ X0 (Unco.GameConditions.Implementations.ReactiveCondition)\n\tv687 = v687_asT != 0;\n\tif (v687) goto L_015C;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v768_asT @ TEMPCOND_v18 (Unco.GameConditions.Implementations.AnyCondition), typeof(Unco.GameConditions.Implementations.AnyCondition), condition @ X0 (Unco.GameConditions.Implementations.ReactiveCondition)\n\tv768 = v768_asT == 0;\n\tif (v768) goto L_01FF;\nL_015C:\n\tv872 = Unco.GameConditions.Serialization.ReactiveConditionTypeExtensions::GetPrivateField(condition, \"m_conditions\");\n\tv233 = v872 == 0;\nL_FFFFFFFF:\n\tv227 = v55;\n\tif (v233) goto L_01F4;\n\tv234 = v872.Length == 0;\nL_FFFFFFFF:\n\tv227 = v55;\n\tif (v234) goto L_01F4;\n\tgoto L_016A;\nL_016A:\n\tv839 = v837.<>9__4_0 == 0;\n\tv840 = ~v839;\nL_FFFFFFFF:\n\tv855 = v872;\nL_FFFFFFFF:\n\tv737 = v837.<>9__4_0;\n\tif (v840) goto L_01C6;\n\tgoto L_01AA;\nL_0175:\n\tv592 = Unco.GameConditions.Serialization.ReactiveConditionTypeExtensions::GetPrivateField(condition, \"m_leftCondition\");\n\tv643 = Unco.GameConditions.Serialization.ReactiveConditionTypeExtensions::GetPrivateField(condition, \"m_rightCondition\");\n\tv678 = v592 == 0;\n\tif (v678) goto L_021C;\n\tv734 = v643 == 0;\n\tif (v734) goto L_021C;\n\tv798 = Unco.GameConditions.Serialization.ReactiveConditionTypeExtensions::Serialize(v592);\n\tv78.leftCondition = v798;\n\tv732 = Unco.GameConditions.Serialization.ReactiveConditionTypeExtensions::Serialize(v643);\nL_FFFFFFFF:\n\tv295 = v732;\nL_FFFFFFFF:\n\tv301 = 0x30;\n\tgoto L_01CD;\nL_0195:\n\tv501 = Unco.GameConditions.Serialization.ReactiveConditionTypeExtensions::GetPrivateField(condition, \"m_condition\");\n\tv547 = v501 == 0;\n\tif (v547) goto L_023A;\n\tv625 = Unco.GameConditions.Serialization.ReactiveConditionTypeExtensions::Serialize(v501);\nL_FFFFFFFF:\n\tv295 = v625;\nL_FFFFFFFF:\n\tv301 = 0x20;\n\tgoto L_01CD;\nL_01AA:\n\tgoto L_01B3;\nL_FFFFFFFF:\n\tv855 = v872;\nL_FFFFFFFF:\n\tv737 = v892;\nL_01DA:\n\treturn v78;\nL_01DD:\n\tv72 = 0xB28B000 + 0x600;\n\tv79 = new v72();\n\tv86 = 0xB308000 + 0xEA0;\n\tv94 = 0xB2EE000 + 0x950;\n\tSystem.ArgumentNullException::.ctor(v79, v86, v94);\n\tthrow v79;\nL_01F4:\n\tv241 = 0x3175AC4(v227, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv344 = System.Reflection.MemberInfo::get_Name(v227);\n\tv480 = 0xB2E6000 + 0x398;\nL_FFFFFFFF:\n\tv486 = v344;\n\tgoto L_0229;\nL_01FF:\n\tv788 = 0x3175AC4(v55, v103, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv804 = System.Type::get_FullName(v55);\n\tv807 = 0xB2FC000 + 0x418;\n\tv822 = System.String::Concat(v807, v804);\n\tv833 = 0xB292000 + 0x4A0;\n\tv844 = new v833();\n\tSystem.NotSupportedException::.ctor(v844, v822);\n\tthrow v844;\nL_021C:\n\tv766 = 0x3175AC4(v55, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv800 = System.Reflection.MemberInfo::get_Name(v55);\n\tv480 = 0xB2E6000 + 0x390;\nL_FFFFFFFF:\n\tv486 = v800;\n\tv671 = new v620();\n\tSystem.InvalidOperationException::.ctor(v671, v543);\n\tthrow v671;\nL_023A:\n\tv635 = 0xB290000 + 0xB18;\n\tv677 = new v635();\n\tv741 = 0xB2F8000 + 0xBE8;\n\tSystem.InvalidOperationException::.ctor(v677, v741);\n\tthrow v677;\nL_004F:\n\tv47 = condition == 0;\nL_FFFFFFFF:\n\tv227 = v55;\n\tif (v47) goto L_01DD;\nL_01C6:\n\tv868 = System.Linq.Enumerable::Select(v855, v737);\n\tv731 = System.Linq.Enumerable::ToArray(v868);\nL_FFFFFFFF:\n\tv295 = v731;\nL_FFFFFFFF:\n\tv301 = 0x38;\nL_01CD:\n\t*([v78 @ X0_v56 (Unco.GameConditions.Serialization.SerializableReactiveCondition)+v301 @ X8_v12 (System.Int32)]) = v295;\nL_01B3:\n\tv892 = new System.Func`2<Unco.GameConditions.Implementations.ReactiveCondition, Unco.GameConditions.Serialization.SerializableReactiveCondition>();\n\tSystem.Func`2<Unco.GameConditions.Implementations.ReactiveCondition, Unco.GameConditions.Serialization.SerializableReactiveCondition>::.ctor(v892, v850.<>9, Il2CppMethodInfo);\n\tv897.<>9__4_0 = v892;\nL_0229:\n\tv543 = System.String::Concat(v486, v480);\n\tv620 = 0xB290000 + 0xB18;\n")]
		public static SerializableReactiveCondition Serialize(this ReactiveCondition condition)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ReactiveConditionTypeExtensions::Serialize");
			return default;
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x4C58558", Offset = "0x4C58558", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv24 = 0x220C2B8(methodInfo, fieldName, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0015:\n\tv42 = System.Object::GetType(obj);\n\tv75 = System.Type::GetField(v42, fieldName, 0x24);\n\tv55 = System.Reflection.FieldInfo::op_Equality(v75, 0);\n\tv79 = ~v55;\n\tv69 = ~v79;\n\tif (v69) goto L_004A;\n\tv96 = System.Reflection.FieldInfo::GetValue(v75, obj);\n\tv97 = v96 == 0;\n\treturnVal1 = v96;\n\tif (v97) goto L_0047;\n\tgoto L_003D;\nL_0047:\n\treturn returnVal1;\nL_004A:\n\tv72 = 0x3175AC4(obj, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv78 = System.Object::GetType(obj);\n\tv81 = 0x3175AC4(v78, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv86 = System.Type::get_FullName(v78);\n\tv89 = 0xB2F3000 + 0x110;\n\tv100 = 0xB2E7000 + 0x5B8;\n\tv131 = System.String::Concat(v89, fieldName, v100, v86);\n\tv165 = 0xB290000 + 0xB18;\n\tv167 = new v165();\n\tSystem.InvalidOperationException::.ctor(v167, v131);\n\tthrow v167;\nL_0071:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\nL_003D:\n\treturnVal1 = 0x21C11D0(v96, Il2CppClass<T>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv115 = returnVal1 == 0;\n\tif (v115) goto L_0071;\n")]
		private static T GetPrivateField<T>(object obj, string fieldName)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ReactiveConditionTypeExtensions::GetPrivateField");
			return default;
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x81AD194", Offset = "0x81AD194", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = System.Object::GetType(obj);\n\tv88 = System.Type::GetField(v22, fieldName, 0x24);\n\tv90 = System.Reflection.FieldInfo::op_Equality(v88, 0);\n\tv115 = ~v90;\n\tv29 = v88;\n\tif (v115) goto L_0032;\n\tv54 = System.Object::GetType(obj);\n\tv134 = System.Type::get_BaseType(v54);\n\tv128 = v134 == 0;\n\tif (v128) goto L_0048;\n\tv122 = *([v134 @ X0_v37 (System.Reflection.FieldInfo)]);\n\t*([v122 @ X8_v7 (Il2CppClass<System.Reflection.FieldInfo>)+6C8])(v124, v134, fieldName, 0x24, *([v122 @ X8_v7 (Il2CppClass<System.Reflection.FieldInfo>)+6D0]), v25, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85);\n\tv29 = v124;\n\tSystem.Reflection.FieldInfo::SetValue(v29, obj, value);\n\treturn;\nL_0048:\n\tv56 = System.Reflection.FieldInfo::op_Equality(v134, 0);\nL_004C:\n\tv142 = 0x3175AC4(obj, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv145 = System.Object::GetType(obj);\n\tv147 = 0x3175AC4(v145, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv150 = System.Type::get_FullName(v145);\n\tv153 = 0xB2F3000 + 0x110;\n\tv156 = 0xB2E7000 + 0x5B8;\n\tv161 = System.String::Concat(v153, fieldName, v156, v150);\n\tv163 = 0xB290000 + 0xB18;\n\tv165 = new v163();\n\tSystem.InvalidOperationException::.ctor(v165, v161);\n\tthrow v165;\nL_0032:\n\tv55 = System.Reflection.FieldInfo::op_Equality(v29, 0);\n\tv131 = v55 == 0;\n\tv132 = ~v131;\n\tif (v132) goto L_004C;\n")]
		private static void SetPrivateField(object obj, string fieldName, object value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ReactiveConditionTypeExtensions::SetPrivateField");
		}
	}
}
