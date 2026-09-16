using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	[Token(Token = "0x2000063")]
	public class FsmVar
	{
		[Token(Token = "0x4000176")]
		[FieldOffset(Offset = "0x10")]
		public string variableName;

		[Token(Token = "0x4000177")]
		[FieldOffset(Offset = "0x18")]
		public string objectType;

		[Token(Token = "0x4000178")]
		[FieldOffset(Offset = "0x20")]
		public bool useVariable;

		[NonSerialized]
		[Token(Token = "0x4000179")]
		[FieldOffset(Offset = "0x28")]
		private NamedVariable namedVar;

		[NonSerialized]
		[Token(Token = "0x400017A")]
		[FieldOffset(Offset = "0x30")]
		private Type namedVarType;

		[Token(Token = "0x400017B")]
		[FieldOffset(Offset = "0x38")]
		private Type enumType;

		[Token(Token = "0x400017C")]
		[FieldOffset(Offset = "0x40")]
		private Enum enumValue;

		[NonSerialized]
		[Token(Token = "0x400017D")]
		[FieldOffset(Offset = "0x48")]
		private Type _objectType;

		[SerializeField]
		[Token(Token = "0x400017E")]
		[FieldOffset(Offset = "0x50")]
		private VariableType type;

		[Token(Token = "0x400017F")]
		[FieldOffset(Offset = "0x54")]
		public float floatValue;

		[Token(Token = "0x4000180")]
		[FieldOffset(Offset = "0x58")]
		public int intValue;

		[Token(Token = "0x4000181")]
		[FieldOffset(Offset = "0x5C")]
		public bool boolValue;

		[Token(Token = "0x4000182")]
		[FieldOffset(Offset = "0x60")]
		public string stringValue;

		[Token(Token = "0x4000183")]
		[FieldOffset(Offset = "0x68")]
		public Vector4 vector4Value;

		[Token(Token = "0x4000184")]
		[FieldOffset(Offset = "0x78")]
		public UnityEngine.Object objectReference;

		[Token(Token = "0x4000185")]
		[FieldOffset(Offset = "0x80")]
		public FsmArray arrayValue;

		[Token(Token = "0x4000186")]
		[FieldOffset(Offset = "0x88")]
		private Vector2 vector2;

		[Token(Token = "0x4000187")]
		[FieldOffset(Offset = "0x90")]
		private Vector3 vector3;

		[Token(Token = "0x4000188")]
		[FieldOffset(Offset = "0x9C")]
		private Rect rect;

		[Token(Token = "0x17000094")]
		public NamedVariable NamedVar
		{
			[Token(Token = "0x6000255")]
			[Address(RVA = "0xCBA024", Offset = "0xCBA024", Length = "0x30")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.namedVar;\n\tv11 = this.namedVar == 0;\n\tv12 = ~v11;\n\tif (v12) goto L_0011;\n\tHutongGames.PlayMaker.FsmVar::InitNamedVar(this);\n\treturnVal1 = this.namedVar;\nL_0011:\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				NamedVariable result = namedVar;
				if (namedVar == null)
				{
					InitNamedVar();
					result = namedVar;
				}
				return result;
			}
			[Token(Token = "0x6000256")]
			[Address(RVA = "0xCBA524", Offset = "0xCBA524", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = v24 == 0;\n\tif (v14) goto L_001A;\n\tHutongGames.PlayMaker.FsmVar::UpdateType(this, v24);\n\tthis.namedVar = v24;\n\tv20 = System.Object::GetType(v24);\n\tv33 = this.namedVar;\n\tthis.namedVarType = v20;\n\tthis.variableName = v33.name;\n\tthis.useVariable = v24.useVariable;\n\tgoto L_0023;\nL_001A:\n\tthis.variableName = 0;\n\tthis.namedVar = 0;\n\tthis.namedVarType = 0;\nL_0023:\n\tHutongGames.PlayMaker.FsmVar::UpdateValue(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				NamedVariable namedVariable = default(NamedVariable);
				if (namedVariable != null)
				{
					UpdateType(namedVariable);
					namedVar = namedVariable;
					Type type = namedVariable.GetType();
					NamedVariable namedVariable2 = namedVar;
					namedVarType = type;
					variableName = namedVariable2.Name;
					useVariable = namedVariable.UseVariable;
				}
				else
				{
					variableName = null;
					namedVar = null;
					namedVarType = null;
				}
				UpdateValue();
			}
		}

		[Token(Token = "0x17000095")]
		public Type NamedVarType
		{
			[Token(Token = "0x6000257")]
			[Address(RVA = "0xCBA710", Offset = "0xCBA710", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.namedVarType;\n\tv11 = this.namedVarType == 0;\n\tv12 = ~v11;\n\tif (v12) goto L_001A;\n\tv14 = this.namedVar == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0014;\n\tHutongGames.PlayMaker.FsmVar::InitNamedVar(this);\n\tv21 = this.namedVar == 0;\n\tif (v21) goto L_001B;\nL_0014:\n\treturnVal1 = System.Object::GetType(v29);\n\tthis.namedVarType = returnVal1;\nL_001A:\n\treturn returnVal1;\nL_001B:\n\treturnVal1 = this.namedVarType;\n\tgoto L_001A;\n\treturn X0;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Type result = namedVarType;
				if ((object)namedVarType == null)
				{
					bool flag = namedVar == null;
					bool flag2 = !flag;
					object obj = namedVar;
					if (!flag2)
					{
						InitNamedVar();
						bool flag3 = namedVar == null;
						obj = namedVar;
						if (flag3)
						{
							result = namedVarType;
							goto IL_00c2;
						}
					}
					result = (namedVarType = obj.GetType());
				}
				goto IL_00c2;
				IL_00c2:
				return result;
			}
		}

		[Token(Token = "0x17000096")]
		public Type EnumType
		{
			[Token(Token = "0x6000258")]
			[Address(RVA = "0xCBA760", Offset = "0xCBA760", Length = "0x30")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.enumType;\n\tv11 = this.enumType == 0;\n\tv12 = ~v11;\n\tif (v12) goto L_0011;\n\tHutongGames.PlayMaker.FsmVar::InitEnumType(this);\n\treturnVal1 = this.enumType;\nL_0011:\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Type result = enumType;
				if ((object)enumType == null)
				{
					InitEnumType();
					result = enumType;
				}
				return result;
			}
			[Token(Token = "0x6000259")]
			[Address(RVA = "0xCBA888", Offset = "0xCBA888", Length = "0x16C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1F084E8]);\n\tv23 = *([v22 @ X8_v21]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202369F]) = v41;\nL_001A:\n\tv47 = this.enumType == v153;\n\tif (v47) goto L_003D;\n\tv52 = v153 == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_0038;\n\tgoto L_0034;\n\tv107 = *([v72 @ X0_v16+E0]);\n\tv108 = v107 == 0;\n\tv109 = ~v108;\n\tif (v109) goto L_0034;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v72, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0034:\n\tv82 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.None);\nL_0038:\n\tthis.enumType = v64;\n\tHutongGames.PlayMaker.FsmVar::set_ObjectType(this, v64);\n\tthis.intValue = 0;\n\tthis.enumValue = 0;\nL_003D:\n\tv68 = this.namedVar == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_0055;\n\tHutongGames.PlayMaker.FsmVar::InitNamedVar(this);\n\tv90 = this.namedVar == 0;\n\tif (v90) goto L_006C;\nL_0055:\n\tgoto L_FFFFFFFF;\n\tv126 = v126_asT == 0;\n\tif (v126) goto L_0072;\n\tv153 = this.enumType;\n\tHutongGames.PlayMaker.FsmEnum::set_EnumType(v157, this.enumType);\n\tv222 = this.namedVar == 0;\n\tv162 = ~v222;\n\tif (v162) goto L_0072;\nL_006C:\n\tHutongGames.PlayMaker.FsmVar::InitNamedVar(this);\n\tv161 = this.namedVar == 0;\n\tif (v161) goto L_0095;\nL_0072:\n\tv167 = *([v157 @ X0_v5 (HutongGames.PlayMaker.FsmEnum)]);\n\tgoto L_FFFFFFFF;\n\tv195 = v195_asT != 0;\n\tif (v195) goto L_0096;\nL_0095:\n\treturn;\nL_0096:\n\tv223 = this.enumType;\n\tv224 = *([v167 @ X8_v7 (Il2CppClass<HutongGames.PlayMaker.FsmEnum>)+2B0]);\n\tv225 = *([v167 @ X8_v7 (Il2CppClass<HutongGames.PlayMaker.FsmEnum>)+2B8]);\n\t// 159 IndirectJump v224 @ X3_v1, v157 @ X0_v5 (HutongGames.PlayMaker.FsmEnum), v157 @ X0_v5 (HutongGames.PlayMaker.FsmEnum), v223 @ X1_v4 (System.Type), v225 @ X2_v1, v224 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\treturn;\n// 112 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0137: Expected I, but got O
				//IL_0184: Expected O, but got I
				//IL_0194: Expected O, but got I
				Type type = default(Type);
				while (true)
				{
					if ((object)enumType != type)
					{
						bool flag = (object)type == null;
						bool flag2 = !flag;
						Type type2 = type;
						if (!flag2)
						{
							Type typeFromHandle = typeof(None);
							type2 = typeFromHandle;
						}
						enumType = type2;
						ObjectType = type2;
						intValue = 0;
						enumValue = null;
						type = type2;
					}
					bool flag3 = namedVar == null;
					bool flag4 = !flag3;
					FsmEnum fsmEnum = (FsmEnum)namedVar;
					if (!flag4)
					{
						InitNamedVar();
						bool flag5 = namedVar == null;
						fsmEnum = (FsmEnum)namedVar;
						if (flag5)
						{
							goto IL_0100;
						}
					}
					FsmEnum fsmEnum2 = fsmEnum as FsmEnum;
					if (fsmEnum2 != null)
					{
						type = enumType;
						fsmEnum.EnumType = enumType;
						bool flag6 = namedVar == null;
						bool flag7 = !flag6;
						fsmEnum = (FsmEnum)namedVar;
						if (!flag7)
						{
							goto IL_0100;
						}
					}
					goto IL_012f;
					IL_0100:
					InitNamedVar();
					bool flag8 = namedVar == null;
					fsmEnum = (FsmEnum)namedVar;
					if (!flag8)
					{
						goto IL_012f;
					}
					break;
					IL_012f:
					IntPtr intPtr = (IntPtr)fsmEnum;
					FsmArray fsmArray = fsmEnum as FsmArray;
					if (fsmArray == null)
					{
						break;
					}
					Type type3 = enumType;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ X8_v7 (Il2CppClass<HutongGames.PlayMaker.FsmEnum>)+2B0]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ X8_v7 (Il2CppClass<HutongGames.PlayMaker.FsmEnum>)+2B8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v224 @ X3_v1 (should have been resolved before IL gen)");
				}
			}
		}

		[Token(Token = "0x17000097")]
		public Enum EnumValue
		{
			[Token(Token = "0x600025A")]
			[Address(RVA = "0xCBAAD8", Offset = "0xCBAAD8", Length = "0xF8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ED60F0]);\n\tv23 = *([v22 @ X8_v14]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20236A0]) = v42;\nL_0015:\n\treturnVal1 = this.enumValue;\n\tv44 = this.enumValue == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0061;\n\tv103 = this.enumType;\n\tv47 = this.enumType == 0;\n\tv48 = ~v47;\n\tif (v48) goto L_0021;\n\tHutongGames.PlayMaker.FsmVar::InitEnumType(this);\n\tv103 = this.enumType;\nL_0021:\n\tv114 = this.intValue;\n\t// 38 Box v118 @ X0_v6 (System.Object), typeof(System.Int32), &v114 @ X8_v4 (System.Int32)\n\tgoto L_0038;\n\tv163 = *([v159 @ X8_v5+E0]);\n\tv164 = v163 == 0;\n\tv165 = ~v164;\n\tgoto L_0038;\n\tv172 = v159;\n\tv168 = \"il2cpp_codegen_runtime_class_init\"(v172, v116, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0038:\n\tv97 = System.Enum::ToObject(v103, v118);\n\tv99 = v97 == 0;\n\tif (v99) goto L_0059;\n\tgoto L_FFFFFFFF;\n\tv185 = v185_asT == 0;\n\tif (v185) goto L_0062;\nL_0059:\n\tthis.enumValue = v97;\nL_0061:\n\treturn returnVal1;\nL_0062:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Enum result = enumValue;
				if (enumValue == null)
				{
					Type type = enumType;
					if ((object)enumType == null)
					{
						InitEnumType();
						type = enumType;
					}
					int num = intValue;
					object value = num;
					object obj = Enum.ToObject(type, value);
					if (obj != null)
					{
						Enum obj2 = obj as Enum;
						if (obj2 == null)
						{
							return (Enum)(object)new InvalidCastException();
						}
					}
					enumValue = (Enum)obj;
					result = (Enum)obj;
				}
				return result;
			}
			[Token(Token = "0x600025B")]
			[Address(RVA = "0xCBABD0", Offset = "0xCBABD0", Length = "0xFC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ED0AE8]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20236A1]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_002F;\n\tv45 = System.Object::GetType(value);\n\tHutongGames.PlayMaker.FsmVar::set_EnumType(this, v45);\n\tthis.enumValue = value;\n\tgoto L_002C;\n\tv63 = *([v58 @ X0_v12+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_002C;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v58, v49, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002C:\n\tv72 = System.Convert::ToInt32(value);\n\tthis.intValue = v72;\n\tgoto L_0061;\nL_002F:\n\tv52 = this.enumType;\n\tv47 = this.enumType == 0;\n\tv48 = ~v47;\n\tif (v48) goto L_0037;\n\tHutongGames.PlayMaker.FsmVar::InitEnumType(this);\n\tv52 = this.enumType;\nL_0037:\n\tv55 = System.Activator::CreateInstance(v52);\n\tv62 = v55 == 0;\n\tif (v62) goto L_005A;\n\tgoto L_FFFFFFFF;\n\tv93 = v93_asT == 0;\n\tif (v93) goto L_0062;\nL_005A:\n\tthis.enumValue = v55;\nL_0061:\n\treturn;\nL_0062:\n\tthrow System.InvalidCastException;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (value != null)
				{
					Type type = value.GetType();
					EnumType = type;
					enumValue = value;
					int num = Convert.ToInt32(value);
					intValue = num;
					return;
				}
				Type type2 = enumType;
				if ((object)enumType == null)
				{
					InitEnumType();
					type2 = enumType;
				}
				object obj = Activator.CreateInstance(type2);
				if (obj != null)
				{
					Enum obj2 = obj as Enum;
					if (obj2 == null)
					{
						throw new InvalidCastException();
					}
				}
				enumValue = (Enum)obj;
			}
		}

		[Token(Token = "0x17000098")]
		public Type ObjectType
		{
			[Token(Token = "0x600025C")]
			[Address(RVA = "0xCBACCC", Offset = "0xCBACCC", Length = "0xE4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EDE8E8]);\n\tv19 = *([v18 @ X8_v21]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20236A2]) = v38;\nL_0013:\n\tv61 = this._objectType;\n\tv40 = this._objectType == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_004D;\n\tgoto L_0026;\n\tv71 = *([v45 @ X0_v4+E0]);\n\tv72 = v71 == 0;\n\tv73 = ~v72;\n\tif (v73) goto L_0026;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\tv57 = HutongGames.PlayMaker.ReflectionUtils::GetGlobalType(this.objectType);\n\tthis._objectType = v57;\n\tv92 = v57 == 0;\n\tv60 = ~v92;\n\tif (v60) goto L_004D;\n\tgoto L_003D;\n\tv100 = *([v95 @ X0_v8+E0]);\n\tv101 = v100 == 0;\n\tv102 = ~v101;\n\tif (v102) goto L_003D;\n\tv104 = \"il2cpp_codegen_runtime_class_init\"(v95, v54, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003D:\n\tv107 = System.Type::GetTypeFromHandle(UnityEngine.Object);\n\tthis._objectType = v107;\n\tv56 = System.Type::get_FullName(v107);\n\tv61 = this._objectType;\n\tthis.objectType = v56;\nL_004D:\n\treturn v61;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Type result = _objectType;
				if ((object)_objectType == null)
				{
					Type type = (_objectType = ReflectionUtils.GetGlobalType(objectType));
					bool flag = (object)type == null;
					bool flag2 = !flag;
					result = type;
					if (!flag2)
					{
						string fullName = (_objectType = typeof(UnityEngine.Object)).FullName;
						result = _objectType;
						objectType = fullName;
					}
				}
				return result;
			}
			[Token(Token = "0x600025D")]
			[Address(RVA = "0xCBA9F4", Offset = "0xCBA9F4", Length = "0xE4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EA74E0]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20236A3]) = v41;\nL_0015:\n\tthis._objectType = value;\n\tv42 = value == 0;\n\tif (v42) goto L_0024;\n\tgoto L_0033;\nL_0024:\n\tgoto L_002C;\n\tv70 = *([v47 @ X0_v5+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_002C;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v47, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002C:\n\tv58 = System.Type::GetTypeFromHandle(UnityEngine.Object);\n\tthis._objectType = v58;\nL_0033:\n\tv67 = System.Type::get_FullName(v58);\n\tv68 = this.namedVar;\n\tthis.objectType = v67;\n\tv69 = this.namedVar == 0;\n\tif (v69) goto L_004A;\n\tv78 = *([v68 @ X8_v4 (HutongGames.PlayMaker.NamedVariable)]);\n\t// 67 IndirectJump [v78 @ X9_v3 (Il2CppClass<HutongGames.PlayMaker.NamedVariable>)+2B0], this.namedVar (HutongGames.PlayMaker.NamedVariable), this.namedVar (HutongGames.PlayMaker.NamedVariable), this._objectType (System.Type), [v78 @ X9_v3 (Il2CppClass<HutongGames.PlayMaker.NamedVariable>)+2B8], [v78 @ X9_v3 (Il2CppClass<HutongGames.PlayMaker.NamedVariable>)+2B0], v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\nL_004A:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_003c: Expected I, but got O
				_objectType = value;
				Type type = (((object)value != null) ? value : (_objectType = typeof(UnityEngine.Object)));
				string fullName = type.FullName;
				NamedVariable namedVariable = namedVar;
				objectType = fullName;
				if (namedVar != null)
				{
					IntPtr intPtr = (IntPtr)namedVariable;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v78 @ X9_v3 (Il2CppClass<HutongGames.PlayMaker.NamedVariable>)+2B0] (should have been resolved before IL gen)");
				}
			}
		}

		[Token(Token = "0x17000099")]
		public VariableType Type
		{
			[Token(Token = "0x600025E")]
			[Address(RVA = "0xCBADB0", Offset = "0xCBADB0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.type;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Type;
			}
			[Token(Token = "0x600025F")]
			[Address(RVA = "0xCBADB8", Offset = "0xCBADB8", Length = "0x18")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.type != value;\n\tif (v12) goto L_000D;\n\treturn;\nL_000D:\n\tthis.type = value;\n\tHutongGames.PlayMaker.FsmVar::InitNamedVar(this);\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (Type != value)
				{
					type = value;
					InitNamedVar();
				}
			}
		}

		[Token(Token = "0x1700009A")]
		public Type RealType
		{
			[Token(Token = "0x6000260")]
			[Address(RVA = "0xCBADD0", Offset = "0xCBADD0", Length = "0x220")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv17 = *([1EDA310]);\n\tv18 = *([v17 @ X8_v13]);\n\tv19 = \"il2cpp_codegen_initialize_method\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 0 | 1;\n\t*([20236A4]) = v37;\nL_0014:\n\tv39 = this.type + 1;\n\tv40 = v39 < 0xF;\n\tv41 = ~v40;\n\tv42 = v39 - 0xF;\n\tv44 = v42 == 0;\n\tv49 = ~v44;\n\tv50 = v41 & v49;\n\tif (v50) goto L_00A3;\n\tv52 = 0x181A000 + 0x980;\n\tv55 = *([v52 @ X9_v2 (System.Int32)+v39 @ X8_v4 (System.Int32)*4]) + v52;\n\t// 38 IndirectJump v55 @ X8_v10, 0, 0, methodInfo @ X1 (Il2CppMethodInfo), v21 @ X2, v22 @ X3, v23 @ X4, v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1EF3A70]);\n\tgoto L_006E;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1EFD3D8]);\n\tgoto L_006E;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1F01AE0]);\n\tgoto L_006E;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1ECC818]);\n\tgoto L_006E;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1ECE0A0]);\n\tgoto L_006E;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1EC0D30]);\n\tgoto L_006E;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1EAADF8]);\n\tgoto L_006E;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1EAEE80]);\n\tgoto L_006E;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1EC0DE0]);\n\tgoto L_006E;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1EC6448]);\n\tgoto L_006E;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1EEF208]);\n\tgoto L_006E;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1EDB098]);\nL_006E:\n\tX9 = *([X0+12F]);\n\tX19 = *([X8]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_0078;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0078;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0078:\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX0 = X19;\n\tX1 = 0;\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 126 ShiftStack 32\n\tX0 = System.Type::GetTypeFromHandle(X0, X1);\n\treturn X0;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX0 = X19;\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 134 ShiftStack 32\n\tX0 = HutongGames.PlayMaker.FsmVar::get_ObjectType(X0, X1);\n\treturn X0;\n\tX0 = *([X19+80]);\n\tif (TEMP) goto L_00AD;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 144 ShiftStack 32\n\tX0 = HutongGames.PlayMaker.FsmArray::RealType(X0, X1);\n\treturn X0;\n\tX0 = *([X19+38]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_009A;\n\tX0 = X19;\n\tHutongGames.PlayMaker.FsmVar::InitEnumType(X0, X1);\n\tX0 = *([X19+38]);\nL_009A:\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 158 ShiftStack 32\n\treturn X0;\nL_00A3:\n\tv59 = new System.ArgumentOutOfRangeException();\n\tSystem.ArgumentOutOfRangeException::.ctor(v59);\n\tthrow v59;\nL_00AD:\n\t;\n\treturn returnVal1;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0029: Expected O, but got I
				int num = (int)(Type + 1);
				bool flag = num < 15;
				bool flag2 = !flag;
				int num2 = num - 15;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					int num3 = 25272320 + 2432;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X9_v2 (System.Int32)+v39 @ X8_v4 (System.Int32)*4]");
					object obj = 0L + (long)num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v55 @ X8_v10 (should have been resolved before IL gen)");
				}
				ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
				throw ex;
			}
		}

		[Token(Token = "0x1700009B")]
		public bool IsNone
		{
			[Token(Token = "0x6000261")]
			[Address(RVA = "0xCBAFF0", Offset = "0xCBAFF0", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.useVariable;\n\tif (v2) goto L_0008;\n\treturnVal2 = System.String::IsNullOrEmpty(this.variableName);\n\treturn returnVal2;\nL_0008:\n\treturn 0;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (useVariable)
				{
					return string.IsNullOrEmpty(variableName);
				}
				return false;
			}
		}

		[Token(Token = "0x1700009C")]
		public Vector2 vector2Value
		{
			[Token(Token = "0x6000262")]
			[Address(RVA = "0xCBB00C", Offset = "0xCBB00C", Length = "0x30")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this + 0x88;\n\tv14 = 0x1588BC0(v12, 0, v15, v16, v17, v18, v19, v20, this.vector4Value, this.vector4Value.y, v21, v22, v23, v24, v25, v26);\n\treturn this.vector2;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000c: Expected O, but got I
				object obj = (long)(IntPtr)this + 136L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588BC0 (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x1CC)");
				return vector2;
			}
			[Token(Token = "0x6000263")]
			[Address(RVA = "0xCBB03C", Offset = "0xCBB03C", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this + 0x68;\n\tv7 = 0x158BC14(v2, 0, v8, v9, v10, v11, v12, v13, value, value.y, 0, 0, v14, v15, v16, v17);\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_000c: Expected O, but got I
				object obj = (long)(IntPtr)this + 104L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158BC14 (inside UnityEngine.Vector3Int::.cctor +0x248)");
			}
		}

		[Token(Token = "0x1700009D")]
		public Vector3 vector3Value
		{
			[Token(Token = "0x6000264")]
			[Address(RVA = "0xCBB050", Offset = "0xCBB050", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = this + 0x90;\n\tv15 = 0x158A1C8(v13, 0, v16, v17, v18, v19, v20, v21, this.vector4Value, this.vector4Value.y, this.vector4Value.z, v22, v23, v24, v25, v26);\n\treturn this.vector3;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000c: Expected O, but got I
				object obj = (long)(IntPtr)this + 144L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158A1C8 (inside UnityEngine.Vector3::MoveTowards +0x298)");
				return vector3;
			}
			[Token(Token = "0x6000265")]
			[Address(RVA = "0xCBB088", Offset = "0xCBB088", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = this + 0x68;\n\tv7 = 0x158BC14(v3, 0, v8, v9, v10, v11, v12, v13, value, value.y, value.z, 0, v14, v15, v16, v17);\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_000c: Expected O, but got I
				object obj = (long)(IntPtr)this + 104L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158BC14 (inside UnityEngine.Vector3Int::.cctor +0x248)");
			}
		}

		[Token(Token = "0x1700009E")]
		public Color colorValue
		{
			[Token(Token = "0x6000266")]
			[Address(RVA = "0xCBB098", Offset = "0xCBB098", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = 0;\n\tv15 = 0x101059C(&v12 @ stack_-20_v1 (UnityEngine.Color), 0, v16, v17, v18, v19, v20, v21, this.vector4Value, this.vector4Value.y, this.vector4Value.z, this.vector4Value.w, v22, v23, v24, v25);\n\treturn 0;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Color color = default(Color);
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
				return default(Color);
			}
			[Token(Token = "0x6000267")]
			[Address(RVA = "0xCBB0D0", Offset = "0xCBB0D0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this + 0x68;\n\tv7 = 0x158BC14(v4, 0, v8, v9, v10, v11, v12, v13, value, value.g, value.b, value.a, v14, v15, v16, v17);\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_000c: Expected O, but got I
				object obj = (long)(IntPtr)this + 104L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158BC14 (inside UnityEngine.Vector3Int::.cctor +0x248)");
			}
		}

		[Token(Token = "0x1700009F")]
		public Rect rectValue
		{
			[Token(Token = "0x6000268")]
			[Address(RVA = "0xCBB0DC", Offset = "0xCBB0DC", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this + 0x9C;\n\tv16 = 0x10CCFA8(v14, 0, v17, v18, v19, v20, v21, v22, this.vector4Value, this.vector4Value.y, this.vector4Value.z, this.vector4Value.w, v23, v24, v25, v26);\n\treturn this.rect;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000c: Expected O, but got I
				object obj = (long)(IntPtr)this + 156L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFA8 (inside UnityEngine.Rect::MinMaxRect +0xC)");
				return rect;
			}
			[Token(Token = "0x6000269")]
			[Address(RVA = "0xCBB114", Offset = "0xCBB114", Length = "0x94")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = this + 0x68;\n\tv26 = 0x10CCFB4(&value @ V0 (UnityEngine.Rect), 0, v27, v28, v29, v30, v31, v32, value, value.m_YMin, value.m_Width, value.m_Height, v33, v34, v35, v36);\n\tv40 = 0x10CCFC4(&value @ V0 (UnityEngine.Rect), 0, v27, v28, v29, v30, v31, v32, value, value.m_YMin, value.m_Width, value.m_Height, v33, v34, v35, v36);\n\tv44 = 0x10CD178(&value @ V0 (UnityEngine.Rect), 0, v27, v28, v29, v30, v31, v32, value, value.m_YMin, value.m_Width, value.m_Height, v33, v34, v35, v36);\n\tv48 = 0x10CD188(&value @ V0 (UnityEngine.Rect), 0, v27, v28, v29, v30, v31, v32, value, value.m_YMin, value.m_Width, value.m_Height, v33, v34, v35, v36);\n\tv55 = 0x158BC14(v18, 0, v27, v28, v29, v30, v31, v32, value, value, value, value, v33, v34, v35, v36);\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_000c: Expected O, but got I
				object obj = (long)(IntPtr)this + 104L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158BC14 (inside UnityEngine.Vector3Int::.cctor +0x248)");
			}
		}

		[Token(Token = "0x170000A0")]
		public Quaternion quaternionValue
		{
			[Token(Token = "0x600026A")]
			[Address(RVA = "0xCBB1A8", Offset = "0xCBB1A8", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = 0;\n\tv15 = 0x10CB640(&v12 @ stack_-20_v1 (UnityEngine.Quaternion), 0, v16, v17, v18, v19, v20, v21, this.vector4Value, this.vector4Value.y, this.vector4Value.z, this.vector4Value.w, v22, v23, v24, v25);\n\treturn 0;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Quaternion quaternion = default(Quaternion);
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CB640 (inside UnityEngine.QualitySettings::get_activeColorSpace +0x34)");
				return default(Quaternion);
			}
			[Token(Token = "0x600026B")]
			[Address(RVA = "0xCBB1E0", Offset = "0xCBB1E0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this + 0x68;\n\tv7 = 0x158BC14(v4, 0, v8, v9, v10, v11, v12, v13, value, value.y, value.z, value.w, v14, v15, v16, v17);\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_000c: Expected O, but got I
				object obj = (long)(IntPtr)this + 104L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158BC14 (inside UnityEngine.Vector3Int::.cctor +0x248)");
			}
		}

		[Token(Token = "0x170000A1")]
		public GameObject gameObjectValue
		{
			[Token(Token = "0x600026C")]
			[Address(RVA = "0xCBB1EC", Offset = "0xCBB1EC", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EFA550]);\n\tv19 = *([v18 @ X8_v5]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20236A5]) = v38;\nL_0013:\n\tv39 = this.objectReference;\n\tv40 = this.objectReference == 0;\n\tif (v40) goto L_FFFFFFFF;\n\tv54 = *([v39 @ X8_v3 (UnityEngine.Object)]) != UnityEngine.GameObject;\n\tif (v54) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0030;\nL_0030:\n\treturn returnVal1;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				UnityEngine.Object obj = objectReference;
				if ((object)objectReference != null)
				{
					return (GameObject)(((object)obj.GetType() != typeof(GameObject)) ? null : objectReference);
				}
				return null;
			}
			[Token(Token = "0x600026D")]
			[Address(RVA = "0xCBB254", Offset = "0xCBB254", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.objectReference = value;\n\treturn;\n")]
			set
			{
				objectReference = value;
			}
		}

		[Token(Token = "0x170000A2")]
		public Material materialValue
		{
			[Token(Token = "0x600026E")]
			[Address(RVA = "0xCBB25C", Offset = "0xCBB25C", Length = "0x84")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1ECE750]);\n\tv19 = *([v18 @ X8_v5]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20236A6]) = v38;\nL_0014:\n\tv40 = this.objectReference == 0;\n\tif (v40) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0040;\n\tv94 = v94_asT == 0;\n\tif (v94) goto L_FFFFFFFF;\n\tgoto L_0040;\nL_0040:\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if ((object)objectReference == null)
				{
					return null;
				}
				Material material = objectReference as Material;
				if ((object)material != null)
				{
					return (Material)objectReference;
				}
				return null;
			}
			[Token(Token = "0x600026F")]
			[Address(RVA = "0xCBB2E0", Offset = "0xCBB2E0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.objectReference = value;\n\treturn;\n")]
			set
			{
				objectReference = value;
			}
		}

		[Token(Token = "0x170000A3")]
		public Texture textureValue
		{
			[Token(Token = "0x6000270")]
			[Address(RVA = "0xCBB2E8", Offset = "0xCBB2E8", Length = "0x84")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EC4740]);\n\tv19 = *([v18 @ X8_v5]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20236A7]) = v38;\nL_0014:\n\tv40 = this.objectReference == 0;\n\tif (v40) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0040;\n\tv94 = v94_asT == 0;\n\tif (v94) goto L_FFFFFFFF;\n\tgoto L_0040;\nL_0040:\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if ((object)objectReference == null)
				{
					return null;
				}
				Texture texture = objectReference as Texture;
				if ((object)texture != null)
				{
					return (Texture)objectReference;
				}
				return null;
			}
			[Token(Token = "0x6000271")]
			[Address(RVA = "0xCBB36C", Offset = "0xCBB36C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.objectReference = value;\n\treturn;\n")]
			set
			{
				objectReference = value;
			}
		}

		[Token(Token = "0x6000272")]
		[Address(RVA = "0xCBB374", Offset = "0xCBB374", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.type = 0xFFFFFFFF;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmVar()
		{
			//IL_0015: Expected I4, but got I8
			base._002Ector();
			type = VariableType.Unknown;
		}

		[Token(Token = "0x6000273")]
		[Address(RVA = "0xCBB384", Offset = "0xCBB384", Length = "0x21C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EBBA50]);\n\tv23 = *([v22 @ X8_v32]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, type, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20236A8]) = v41;\nL_0018:\n\tthis.type = 0xFFFFFFFF;\n\tSystem.Object::.ctor(this);\n\tv46 = HutongGames.PlayMaker.FsmVar::GetVariableType(type);\n\tthis.type = v46;\n\tv52 = System.Type::get_IsEnum(type);\n\tv54 = v52 == 0;\n\tif (v54) goto L_0033;\n\tHutongGames.PlayMaker.FsmVar::set_EnumType(this, type);\n\treturn;\nL_0033:\n\tv83 = System.Type::get_IsArray(type);\n\tv107 = v83 == 0;\n\tif (v107) goto L_008D;\n\tv154 = System.Type::GetElementType(type);\n\tv159 = new HutongGames.PlayMaker.FsmArray();\n\t*([v159 @ X0_v26 (HutongGames.PlayMaker.NamedVariable)+38]) = 0xFFFFFFFF;\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v159);\n\tv61 = HutongGames.PlayMaker.FsmVar::GetVariableType(v154);\n\tHutongGames.PlayMaker.FsmArray::SetType(v159, v61);\n\tthis.arrayValue = v159;\n\tv197 = System.Type::get_IsEnum(v154);\n\tv199 = v197 == 0;\n\tv200 = ~v199;\n\tif (v200) goto L_0076;\n\tgoto L_006B;\n\tv210 = *([v203 @ X0_v34+E0]);\n\tv211 = v210 == 0;\n\tv212 = ~v211;\n\tif (v212) goto L_006B;\n\tv214 = \"il2cpp_codegen_runtime_class_init\"(v203, v196, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_006B:\n\tv93 = System.Type::GetTypeFromHandle(UnityEngine.Object);\n\tv188 = System.Type::IsAssignableFrom(v93, v154);\n\tv189 = v188 == 0;\n\tif (v189) goto L_00AF;\nL_0076:\n\tv94 = this.arrayValue;\n\tv140 = *([v94 @ X0_v33 (HutongGames.PlayMaker.FsmArray)]);\n\tv109 = *([v140 @ X8_v22 (Il2CppClass<HutongGames.PlayMaker.FsmArray>)+2B0]);\n\tv111 = *([v140 @ X8_v22 (Il2CppClass<HutongGames.PlayMaker.FsmArray>)+2B8]);\n\t// 131 IndirectJump v109 @ X3_v1, v94 @ X0_v33 (HutongGames.PlayMaker.FsmArray), v94 @ X0_v33 (HutongGames.PlayMaker.FsmArray), v154 @ X0_v24 (System.Type), v111 @ X2_v5, v109 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\nL_008D:\n\tgoto L_0095;\n\tv170 = *([v162 @ X0_v15+E0]);\n\tv171 = v170 == 0;\n\tv172 = ~v171;\n\tif (v172) goto L_0095;\n\tv174 = \"il2cpp_codegen_runtime_class_init\"(v162, v82, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0095:\n\tv179 = System.Type::GetTypeFromHandle(UnityEngine.Object);\n\tv183 = System.Type::IsSubclassOf(type, v179);\n\tv129 = v183 == 0;\n\tif (v129) goto L_00AF;\n\tHutongGames.PlayMaker.FsmVar::set_ObjectType(this, type);\n\treturn;\nL_00AF:\n\treturn;\n\tv73 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmVar(Type type)
		{
			//IL_01d7: Expected I4, but got I8
			//IL_0150: Expected I, but got O
			//IL_0160: Expected O, but got I
			//IL_0170: Expected O, but got I
			base._002Ector();
			this.type = VariableType.Unknown;
			VariableType variableType = GetVariableType(type);
			this.type = variableType;
			if (type.IsEnum)
			{
				EnumType = type;
				return;
			}
			if (type.IsArray)
			{
				Type elementType = type.GetElementType();
				NamedVariable namedVariable = new NamedVariable();
				_ = 4294967295L;
				VariableType variableType2 = GetVariableType(elementType);
				((FsmArray)namedVariable).SetType(variableType2);
				arrayValue = (FsmArray)namedVariable;
				if (!elementType.IsEnum)
				{
					Type typeFromHandle = typeof(UnityEngine.Object);
					if (!typeFromHandle.IsAssignableFrom(elementType))
					{
						return;
					}
				}
				FsmArray fsmArray = arrayValue;
				IntPtr intPtr = (IntPtr)fsmArray;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ X8_v22 (Il2CppClass<HutongGames.PlayMaker.FsmArray>)+2B0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ X8_v22 (Il2CppClass<HutongGames.PlayMaker.FsmArray>)+2B8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v109 @ X3_v1 (should have been resolved before IL gen)");
			}
			Type typeFromHandle2 = typeof(UnityEngine.Object);
			if (type.IsSubclassOf(typeFromHandle2))
			{
				ObjectType = type;
			}
		}

		[Token(Token = "0x6000274")]
		[Address(RVA = "0xCBB5A0", Offset = "0xCBB5A0", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.type = 0xFFFFFFFF;\n\tSystem.Object::.ctor(this);\n\tthis.variableName = source.variableName;\n\tthis.useVariable = source.useVariable;\n\tthis.type = source.type;\n\tv21 = source.namedVar == 0;\n\tv22 = ~v21;\n\tif (v22) goto L_0021;\n\tHutongGames.PlayMaker.FsmVar::InitNamedVar(source);\nL_0021:\n\tHutongGames.PlayMaker.FsmVar::GetValueFrom(this, v41);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmVar(FsmVar source)
		{
			//IL_0015: Expected I4, but got I8
			base._002Ector();
			type = VariableType.Unknown;
			variableName = source.variableName;
			useVariable = source.useVariable;
			type = source.Type;
			bool flag = source.namedVar == null;
			bool flag2 = !flag;
			INamedVariable variable = source.namedVar;
			if (!flag2)
			{
				source.InitNamedVar();
				variable = source.namedVar;
			}
			GetValueFrom(variable);
		}

		[Token(Token = "0x6000275")]
		[Address(RVA = "0xCBBCCC", Offset = "0xCBBCCC", Length = "0x1B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EE9538]);\n\tv23 = *([v22 @ X8_v18]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, variable, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20236A9]) = v41;\nL_0018:\n\tthis.type = 0xFFFFFFFF;\n\tSystem.Object::.ctor(this);\n\tv47 = variable->klass;\n\tv51 = *([v47 @ X8_v4 (Il2CppClass<HutongGames.PlayMaker.INamedVariable>)+126]) == 0;\n\tif (v51) goto L_0040;\n\tv107 = *([v47 @ X8_v4 (Il2CppClass<HutongGames.PlayMaker.INamedVariable>)+B0]) + 8;\nL_002B:\n\tv112 = *([v107 @ X11_v17-8]) == HutongGames.PlayMaker.INamedVariable;\n\tif (v112) goto L_0043;\n\tv106 = v106 + 1;\n\tv167 = v106 < *([v47 @ X8_v4 (Il2CppClass<HutongGames.PlayMaker.INamedVariable>)+126]);\n\tv85 = ~v167;\n\tv107 = v107 + 0x10;\n\tv61 = ~v85;\n\tif (v61) goto L_002B;\nL_0040:\n\tv188 = 0x8909C4(variable, HutongGames.PlayMaker.INamedVariable, 8, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004A;\nL_0043:\n\tv169 = *([v107 @ X11_v17]) + 8;\n\tv170 = v169 << 4;\n\tv171 = v47 + v170;\n\tv188 = v171 + 0x130;\nL_004A:\n\t*([v188 @ X0_v5])(v193, variable, *([v188 @ X0_v5+8]), 8, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tthis.type = v193;\n\tgoto L_0078;\n\tv198 = *([v194 @ X8_v7+B0]);\n\tv199 = 0;\n\tv200 = v198 + 8;\n\tv202 = *([v239 @ X11_v12-8]);\n\tv244 = v202 == v195;\n\tif (v244) goto L_0070;\n\tv222 = v238 + 1;\n\tv249 = v222 < v196;\n\tv220 = ~v249;\n\tv224 = v239 + 0x10;\n\tv204 = ~v220;\n\tif (v204) goto L_FFFFFFFF;\n\tv225 = 0xA;\n\tv226 = v14;\n\tv227 = 0x8909C4(v226, v195, v225, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0078;\nL_0070:\n\tv250 = *([v239 @ X11_v12]);\n\tv251 = v250 + 0xA;\n\tv252 = v251 << 4;\n\tv253 = v194 + v252;\n\tv254 = v253 + 0x130;\nL_0078:\n\tv275 = HutongGames.PlayMaker.INamedVariable::get_ObjectType(variable);\n\tHutongGames.PlayMaker.FsmVar::set_ObjectType(this, v275);\n\tgoto L_00A7;\n\tv281 = *([v278 @ X8_v10+B0]);\n\tv282 = 0;\n\tv283 = v281 + 8;\n\tv285 = *([v322 @ X11_v7-8]);\n\tv327 = v285 == v279;\n\tif (v327) goto L_00A0;\n\tv305 = v321 + 1;\n\tv332 = v305 < v280;\n\tv303 = ~v332;\n\tv307 = v322 + 0x10;\n\tv287 = ~v303;\n\tif (v287) goto L_FFFFFFFF;\n\tv308 = v14;\n\tv309 = 0;\n\tv310 = 0x8909C4(v308, v279, v309, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_00A7;\nL_00A0:\n\tv333 = *([v322 @ X11_v7]);\n\tv334 = v333 << 4;\n\tv335 = v278 + v334;\n\tv336 = v335 + 0x130;\nL_00A7:\n\tv341 = HutongGames.PlayMaker.INamedVariable::get_Name(variable);\n\tthis.variableName = v341;\n\tHutongGames.PlayMaker.FsmVar::GetValueFrom(this, variable);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 103 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmVar(INamedVariable variable)
		{
			//IL_0115: Expected I4, but got I8
			//IL_0013: Expected I, but got O
			//IL_004e: Expected O, but got I
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Expected O, but got Unknown
			//IL_00f2: Expected O, but got I
			//IL_0101: Expected O, but got I
			//IL_009a: Expected O, but got I
			base._002Ector();
			this.type = VariableType.Unknown;
			IntPtr intPtr = (IntPtr)variable;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X8_v4 (Il2CppClass<HutongGames.PlayMaker.INamedVariable>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00b3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X8_v4 (Il2CppClass<HutongGames.PlayMaker.INamedVariable>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ X11_v17-8]");
				if ((IntPtr)0 == (IntPtr)typeof(INamedVariable))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X8_v4 (Il2CppClass<HutongGames.PlayMaker.INamedVariable>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00b3;
			}
			object obj2 = obj + 8;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0144;
			IL_00b3:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0144;
			IL_0144:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v188 @ X0_v5] (should have been resolved before IL gen)");
			VariableType variableType = default(VariableType);
			this.type = variableType;
			Type type = variable.ObjectType;
			ObjectType = type;
			string name = variable.Name;
			variableName = name;
			GetValueFrom(variable);
		}

		[Token(Token = "0x6000276")]
		[Address(RVA = "0xCBBE84", Offset = "0xCBBE84", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EED4E8]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, variable, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20236AA]) = v41;\nL_0015:\n\tv42 = variable == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tv57 = variable + 0x18;\n\tv49 = HutongGames.PlayMaker.NamedVariable::get_VariableType(variable);\n\tthis.type = v49;\n\tgoto L_0025;\nL_0025:\n\tthis.variableName = variable.name;\n\tHutongGames.PlayMaker.FsmVar::set_NamedVar(this, variable);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Init(NamedVariable variable)
		{
			//IL_0014: Expected O, but got I
			string text;
			if (variable != null)
			{
				text = (string)((long)(IntPtr)variable + 24L);
				VariableType variableType = variable.VariableType;
				type = variableType;
			}
			else
			{
				text = "";
			}
			variableName = text;
			NamedVar = variable;
		}

		[Token(Token = "0x6000277")]
		[Address(RVA = "0xCBA598", Offset = "0xCBA598", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ECFE60]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, sourceVar, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20236AB]) = v41;\nL_0015:\n\tv42 = sourceVar == 0;\n\tif (v42) goto L_003E;\n\tv44 = sourceVar->klass;\n\tv48 = *([v44 @ X8_v5 (Il2CppClass<HutongGames.PlayMaker.INamedVariable>)+126]) == 0;\n\tif (v48) goto L_003B;\n\tv120 = *([v44 @ X8_v5 (Il2CppClass<HutongGames.PlayMaker.INamedVariable>)+B0]) + 8;\nL_0026:\n\tv125 = *([v120 @ X11_v11-8]) == HutongGames.PlayMaker.INamedVariable;\n\tif (v125) goto L_0050;\n\tv119 = v119 + 1;\n\tv180 = v119 < *([v44 @ X8_v5 (Il2CppClass<HutongGames.PlayMaker.INamedVariable>)+126]);\n\tv86 = ~v180;\n\tv120 = v120 + 0x10;\n\tv62 = ~v86;\n\tif (v62) goto L_0026;\nL_003B:\n\tv201 = 0x8909C4(sourceVar, HutongGames.PlayMaker.INamedVariable, 8, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0057;\nL_003E:\n\tv50 = this.type + 1;\n\tv52 = v50 == 0;\n\tif (v52) goto L_00A3;\n\tthis.type = 0xFFFFFFFF;\n\tHutongGames.PlayMaker.FsmVar::InitNamedVar(this);\n\treturn;\nL_0050:\n\tv182 = *([v120 @ X11_v11]) + 8;\n\tv183 = v182 << 4;\n\tv184 = v44 + v183;\n\tv201 = v184 + 0x130;\nL_0057:\n\t*([v201 @ X0_v3])(v206, sourceVar, *([v201 @ X0_v3+8]), 8, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv212 = this.type == v206;\n\tif (v212) goto L_006A;\n\tthis.type = v206;\n\tHutongGames.PlayMaker.FsmVar::InitNamedVar(this);\nL_006A:\n\tgoto L_0092;\n\tv222 = *([v219 @ X8_v9+B0]);\n\tv223 = 0;\n\tv224 = v222 + 8;\n\tv226 = *([v263 @ X11_v6-8]);\n\tv268 = v226 == v220;\n\tif (v268) goto L_008A;\n\tv246 = v262 + 1;\n\tv273 = v246 < v221;\n\tv244 = ~v273;\n\tv248 = v263 + 0x10;\n\tv228 = ~v244;\n\tif (v228) goto L_FFFFFFFF;\n\tv249 = 0xA;\n\tv250 = v14;\n\tv251 = 0x8909C4(v250, v220, v249, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0092;\nL_008A:\n\tv274 = *([v263 @ X11_v6]);\n\tv275 = v274 + 0xA;\n\tv276 = v275 << 4;\n\tv277 = v219 + v276;\n\tv278 = v277 + 0x130;\nL_0092:\n\tv283 = HutongGames.PlayMaker.INamedVariable::get_ObjectType(sourceVar);\n\tHutongGames.PlayMaker.FsmVar::set_ObjectType(this, v283);\n\treturn;\nL_00A3:\n\treturn;\n// 101 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateType(INamedVariable sourceVar)
		{
			//IL_000d: Expected I, but got O
			//IL_00fd: Expected I4, but got I8
			//IL_0048: Expected O, but got I
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Expected O, but got Unknown
			//IL_012f: Expected O, but got I
			//IL_013e: Expected O, but got I
			//IL_0094: Expected O, but got I
			if (sourceVar != null)
			{
				IntPtr intPtr = (IntPtr)sourceVar;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v5 (Il2CppClass<HutongGames.PlayMaker.INamedVariable>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v5 (Il2CppClass<HutongGames.PlayMaker.INamedVariable>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ X11_v11-8]");
					if ((IntPtr)0 == (IntPtr)typeof(INamedVariable))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v5 (Il2CppClass<HutongGames.PlayMaker.INamedVariable>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00ad;
				}
				object obj2 = obj + 8;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_01a5;
			}
			if (Type + 1 != VariableType.Float)
			{
				this.type = VariableType.Unknown;
				InitNamedVar();
			}
			return;
			IL_00ad:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_01a5;
			IL_01a5:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v201 @ X0_v3] (should have been resolved before IL gen)");
			int num4 = default(int);
			if (Type != (VariableType)num4)
			{
				this.type = (VariableType)num4;
				InitNamedVar();
			}
			Type type = sourceVar.ObjectType;
			ObjectType = type;
		}

		[Token(Token = "0x6000278")]
		[Address(RVA = "0xCBA054", Offset = "0xCBA054", Length = "0x4D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv19 = *([1EC4B30]);\n\tv20 = *([v19 @ X8_v15]);\n\tv21 = \"il2cpp_codegen_initialize_method\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 0 | 1;\n\t*([20236AC]) = v39;\nL_0015:\n\tv41 = v37.type + 1;\n\tv42 = v41 < 0xF;\n\tv43 = ~v42;\n\tv44 = v41 - 0xF;\n\tv46 = v44 == 0;\n\tv51 = ~v46;\n\tv52 = v43 & v51;\n\tif (v52) goto L_016B;\n\tv54 = 0x181A000 + 0x940;\n\tv56 = *([v54 @ X9_v2 (System.Int32)+v41 @ X8_v4 (System.Int32)*4]) + v54;\n\t// 38 IndirectJump v56 @ X8_v12, v37 @ X0_v1 (HutongGames.PlayMaker.FsmVar), v37 @ X0_v1 (HutongGames.PlayMaker.FsmVar), methodInfo @ X1 (Il2CppMethodInfo), v23 @ X2, v24 @ X3, v25 @ X4, v26 @ X5, v27 @ X6, v28 @ X7, v29 @ V0, v30 @ V1, v31 @ V2, v32 @ V3, v33 @ V4, v34 @ V5, v35 @ V6, v36 @ V7\n\t*([X19+28]) = 0;\n\t*([X19+30]) = 0;\n\tgoto L_015F;\n\tX21 = *([X19+10]);\n\tX8 = *([1EC1C20]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX8 = 0xFFFFFFFF;\n\tX1 = X21;\n\tX2 = 0;\n\t*([X20+38]) = X8;\n\tHutongGames.PlayMaker.NamedVariable::.ctor(X0, X1, X2);\n\tX8 = *([X19+80]);\n\tif (TEMP) goto L_0166;\n\tif (TEMP) goto L_0166;\n\tX1 = *([X8+38]);\n\tX0 = X20;\n\tHutongGames.PlayMaker.FsmArray::SetType(X0, X1, X2);\n\tX0 = *([X19+80]);\n\tif (TEMP) goto L_0178;\n\tX8 = *([X0]);\n\tX9 = *([X8+2A0]);\n\tX1 = *([X8+2A8]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X20]);\n\tX1 = X0;\n\tX0 = X20;\n\tX9 = *([X8+2B0]);\n\tX2 = *([X8+2B8]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = *([X19+80]);\n\tX0 = X20;\n\tHutongGames.PlayMaker.FsmArray::CopyValues(X0, X1, X2);\n\tX0 = X20;\n\tHutongGames.PlayMaker.FsmArray::SaveChanges(X0, X1);\n\tgoto L_0155;\n\tX21 = *([X19+10]);\n\tX8 = *([1ED98E0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = X21;\n\tX2 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.NamedVariable::.ctor(X0, X1, X2);\n\tif (TEMP) goto L_0166;\n\tX8 = *([X19+54]);\n\t*([X20+38]) = X8;\n\tgoto L_0155;\n\tX21 = *([X19+10]);\n\tX8 = *([1ECE5A0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = X21;\n\tX2 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.NamedVariable::.ctor(X0, X1, X2);\n\tif (TEMP) goto L_0166;\n\tX8 = *([X19+58]);\n\t*([X20+38]) = X8;\n\tgoto L_0155;\n\tX21 = *([X19+10]);\n\tX8 = *([1F0E6C0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = X21;\n\tX2 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.NamedVariable::.ctor(X0, X1, X2);\n\tif (TEMP) goto L_0166;\n\tX8 = *([X19+5C]);\n\t*([X20+38]) = X8;\n\tgoto L_0155;\n\tX21 = *([X19+10]);\n\tX8 = *([1EA73B8]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = X21;\n\tX2 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.NamedVariable::.ctor(X0, X1, X2);\n\tX0 = X19;\n\tX0 = HutongGames.PlayMaker.FsmVar::get_gameObjectValue(X0, X1);\n\tif (TEMP) goto L_0166;\n\tX8 = *([X20+40]);\n\tC = X8 < X0;\n\tC = ~C;\n\tTEMP1 = X8 - X0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X0;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_0155;\n\tX8 = *([X20+38]);\n\t*([X20+40]) = X0;\n\tif (TEMP) goto L_0155;\n\tX0 = X8;\n\tX1 = 0;\n\tSystem.Action::Invoke(X0, X1);\n\tgoto L_0155;\n\tX21 = *([X19+10]);\n\tX8 = *([1ED01C0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = X21;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmString::.ctor(X0, X1, X2);\n\tif (TEMP) goto L_0166;\n\tX8 = *([X19+60]);\n\t*([X20+38]) = X8;\n\tgoto L_0155;\n\tX21 = *([X19+10]);\n\tX8 = *([1EC9AF0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = X21;\n\tX2 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmVector2::.ctor(X0, X1, X2);\n\tV0 = *([X19+68]);\n\tV1 = *([X19+6C]);\n\tX0 = X19 + 0x88;\n\tX1 = 0;\n\tX0 = 0x1588BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_0166;\n\tX8 = *([X19+88]);\n\tX9 = *([X19+8C]);\n\t*([X20+38]) = X8;\n\t*([X20+3C]) = X9;\n\tgoto L_0155;\n\tX21 = *([X19+10]);\n\tX8 = *([1EDC658]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = X21;\n\tX2 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmVector3::.ctor(X0, X1, X2);\n\tV0 = *([X19+68]);\n\tV1 = *([X19+6C]);\n\tV2 = *([X19+70]);\n\tX0 = X19 + 0x90;\n\tX1 = 0;\n\tX0 = 0x158A1C8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_0166;\n\tX8 = *([X19+90]);\n\tX9 = *([X19+94]);\n\tX10 = *([X19+98]);\n\t*([X20+38]) = X8;\n\t*([X20+3C]) = X9;\n\t*([X20+40]) = X10;\n\tgoto L_0155;\n\tX21 = *([X19+10]);\n\tX8 = *([1EDA758]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = X21;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmColor::.ctor(X0, X1, X2);\n\tX0 = X19;\n\tV0 = HutongGames.PlayMaker.FsmVar::get_colorValue(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0123;\n\tgoto L_0166;\n\tX21 = *([X19+10]);\n\tX8 = *([1EC7C68]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = X21;\n\tX2 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.NamedVariable::.ctor(X0, X1, X2);\n\tX0 = X19;\n\tV0 = HutongGames.PlayMaker.FsmVar::get_rectValue(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0123;\n\tgoto L_0166;\n\tX21 = *([X19+10]);\n\tX8 = *([1F0A440]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = X21;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmObject::.ctor(X0, X1, X2);\n\tX0 = X19;\n\tX0 = HutongGames.PlayMaker.FsmVar::get_materialValue(X0, X1);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0111;\n\tgoto L_0166;\n\tX21 = *([X19+10]);\n\tX8 = *([1EF30E8]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = X21;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmObject::.ctor(X0, X1, X2);\n\tX0 = X19;\n\tX0 = HutongGames.PlayMaker.FsmVar::get_textureValue(X0, X1);\n\tif (TEMP) goto L_0166;\nL_0111:\n\t*([X20+40]) = X0;\n\tgoto L_0155;\n\tX21 = *([X19+10]);\n\tX8 = *([1EECE08]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = X21;\n\tX2 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.NamedVariable::.ctor(X0, X1, X2);\n\tX0 = X19;\n\tV0 = HutongGames.PlayMaker.FsmVar::get_quaternionValue(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tif (TEMP) goto L_0166;\nL_0123:\n\t*([X20+38]) = V0;\n\t*([X20+3C]) = V1;\n\t*([X20+40]) = V2;\n\t*([X20+44]) = V3;\n\tgoto L_0155;\n\tX21 = *([X19+10]);\n\tX8 = *([1EF1608]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = X21;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmObject::.ctor(X0, X1, X2);\n\tX0 = X19;\n\tX0 = HutongGames.PlayMaker.FsmVar::get_ObjectType(X0, X1);\n\tX1 = X0;\n\tif (TEMP) goto L_0166;\n\tX8 = *([X20]);\n\tX0 = X20;\n\tX9 = *([X8+2B0]);\n\tX2 = *([X8+2B8]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19+78]);\n\t*([X20+40]) = X8;\n\tgoto L_0155;\n\tX21 = *([X19+10]);\n\tX8 = *([1EA9A60]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = X21;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmEnum::.ctor(X0, X1, X2);\n\tX1 = *([X19+38]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_014C;\n\tX0 = X19;\n\tHutongGames.PlayMaker.FsmVar::InitEnumType(X0, X1);\n\tX1 = *([X19+38]);\nL_014C:\n\tTEMP = X20 == 0;\n\tif (TEMP) goto L_0166;\n\tX0 = X20;\n\tHutongGames.PlayMaker.FsmEnum::set_EnumType(X0, X1, X2);\n\tX0 = X19;\n\tX0 = HutongGames.PlayMaker.FsmVar::get_EnumValue(X0, X1);\n\tX1 = X0;\n\tX0 = X20;\n\tHutongGames.PlayMaker.FsmEnum::set_Value(X0, X1, X2);\nL_0155:\n\tX0 = X20;\n\tX1 = 0;\n\t*([X19+28]) = X20;\n\tX0 = System.Object::GetType(X0, X1);\n\tX8 = *([X19+28]);\n\t*([X19+30]) = X0;\n\tif (TEMP) goto L_0166;\n\tX9 = *([X19+20]);\n\t*([X8+10]) = X9;\nL_015F:\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX21 = stack[0];\n\t// 356 ShiftStack 48\n\treturn;\nL_0166:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_016B:\n\tv60 = new System.ArgumentOutOfRangeException();\n\tSystem.Argu\n// ... truncated")]
		private void InitNamedVar()
		{
			//IL_0029: Expected O, but got I
			int num = (int)(Type + 1);
			bool flag = num < 15;
			bool flag2 = !flag;
			int num2 = num - 15;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 25272320 + 2368;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X9_v2 (System.Int32)+v41 @ X8_v4 (System.Int32)*4]");
				object obj = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v56 @ X8_v12 (should have been resolved before IL gen)");
			}
			ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("Type");
			throw ex;
		}

		[Token(Token = "0x6000279")]
		[Address(RVA = "0xCBA790", Offset = "0xCBA790", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EF8A68]);\n\tv19 = *([v18 @ X8_v21]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20236AD]) = v38;\nL_001A:\n\tgoto L_0022;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0022;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0022:\n\tv55 = HutongGames.PlayMaker.ReflectionUtils::GetGlobalType(this.objectType);\n\tthis.enumType = v55;\n\tv56 = v55 == 0;\n\tif (v56) goto L_0040;\n\tv58 = System.Type::get_IsAbstract(v55);\n\tv81 = v58 == 0;\n\tv68 = ~v81;\n\tif (v68) goto L_0040;\n\tv65 = System.Type::get_IsEnum(this.enumType);\n\tv96 = v65 == 0;\n\tv67 = ~v96;\n\tif (v67) goto L_0056;\nL_0040:\n\tgoto L_0048;\n\tv82 = *([v73 @ X0_v10+E0]);\n\tv83 = v82 == 0;\n\tv84 = ~v83;\n\tif (v84) goto L_0048;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v73, v62, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0048:\n\tv91 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.None);\n\tthis.enumType = v91;\n\tv107 = System.Type::get_FullName(v91);\n\tthis.objectType = v107;\nL_0056:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void InitEnumType()
		{
			Type type = (enumType = ReflectionUtils.GetGlobalType(objectType));
			if ((object)type == null || type.IsAbstract || !enumType.IsEnum)
			{
				string fullName = (enumType = typeof(None)).FullName;
				objectType = fullName;
			}
		}

		[Token(Token = "0x600027A")]
		[Address(RVA = "0xCBBF0C", Offset = "0xCBBF0C", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv17 = *([1EC2E08]);\n\tv18 = *([v17 @ X8_v14]);\n\tv19 = \"il2cpp_codegen_initialize_method\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 0 | 1;\n\t*([20236AE]) = v37;\nL_0014:\n\tv39 = this.namedVar == 0;\n\tv40 = ~v39;\n\tif (v40) goto L_001A;\n\tHutongGames.PlayMaker.FsmVar::InitNamedVar(this);\nL_001A:\n\tv44 = this.type + 1;\n\tv45 = v44 < 0xF;\n\tv46 = ~v45;\n\tv47 = v44 - 0xF;\n\tv49 = v47 == 0;\n\tv54 = ~v49;\n\tv55 = v46 & v54;\n\tif (v55) goto L_009B;\n\tv57 = 0x181A000 + 0xA00;\n\tv60 = *([v57 @ X9_v2 (System.Int32)+v44 @ X8_v5 (System.Int32)*4]) + v57;\n\t// 44 IndirectJump v60 @ X8_v11, 0, 0, methodInfo @ X1 (Il2CppMethodInfo), v21 @ X2, v22 @ X3, v23 @ X4, v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\n\tX8 = *([X19+54]);\n\tX9 = *([1EE1A60]);\n\tgoto L_0034;\n\tX8 = *([X19+58]);\n\tX9 = *([1ED0418]);\nL_0034:\n\tX0 = *([X9]);\n\tstack[0] = X8;\n\tgoto L_0081;\n\tX8 = *([X19+5C]);\n\tX9 = *([1EC5410]);\n\tstack[0] = X8;\n\tX0 = *([X9]);\n\tgoto L_0081;\n\tX0 = X19;\n\tX0 = HutongGames.PlayMaker.FsmVar::get_gameObjectValue(X0, X1);\n\tgoto L_0083;\n\tX0 = *([X19+60]);\n\tgoto L_0083;\n\tV0 = *([X19+68]);\n\tV1 = *([X19+6C]);\n\tX0 = X19 + 0x88;\n\tX1 = 0;\n\tX0 = 0x1588BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19+88]);\n\tX9 = *([X19+8C]);\n\tX10 = *([1EFD6E0]);\n\tstack[0] = X8;\n\tstack[4] = X9;\n\tX0 = *([X10]);\n\tgoto L_0081;\n\tV0 = *([X19+68]);\n\tV1 = *([X19+6C]);\n\tV2 = *([X19+70]);\n\tX0 = X19 + 0x90;\n\tX1 = 0;\n\tX0 = 0x158A1C8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19+90]);\n\tX9 = *([X19+98]);\n\tX10 = *([1EE1550]);\n\tstack[0] = X8;\n\tstack[8] = X9;\n\tX0 = *([X10]);\n\tgoto L_0081;\n\tX0 = X19;\n\tV0 = HutongGames.PlayMaker.FsmVar::get_colorValue(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tstack[0] = V0;\n\tX8 = *([1EEBF30]);\n\tgoto L_007D;\n\tX0 = X19;\n\tV0 = HutongGames.PlayMaker.FsmVar::get_rectValue(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tstack[0] = V0;\n\tX8 = *([1ED0550]);\n\tgoto L_007D;\n\tX0 = X19;\n\tX0 = HutongGames.PlayMaker.FsmVar::get_materialValue(X0, X1);\n\tgoto L_0083;\n\tX0 = X19;\n\tX0 = HutongGames.PlayMaker.FsmVar::get_textureValue(X0, X1);\n\tgoto L_0083;\n\tX0 = X19;\n\tV0 = HutongGames.PlayMaker.FsmVar::get_quaternionValue(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tstack[0] = V0;\n\tX8 = *([1EC5B90]);\nL_007D:\n\tX0 = *([X8]);\n\tstack[4] = V1;\n\tstack[8] = V2;\n\tstack[C] = V3;\nL_0081:\n\tX1 = &stack[0];\n\tX0 = 0x8D82A8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0083:\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\t// 135 ShiftStack 48\n\treturn X0;\n\tX0 = *([X19+78]);\n\tgoto L_0083;\n\tX19 = *([X19+80]);\n\tif (TEMP) goto L_00A5;\n\tX0 = *([X19+88]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0083;\n\tX0 = X19;\n\tHutongGames.PlayMaker.FsmArray::InitArray(X0, X1);\n\tX0 = *([X19+88]);\n\tgoto L_0083;\n\tX0 = *([X19+40]);\n\tgoto L_0083;\nL_009B:\n\tv64 = new System.ArgumentOutOfRangeException();\n\tSystem.ArgumentOutOfRangeException::.ctor(v64);\n\tthrow v64;\nL_00A5:\n\t;\n\treturn returnVal1;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public object GetValue()
		{
			//IL_00a1: Expected O, but got I
			if (namedVar == null)
			{
				InitNamedVar();
			}
			int num = (int)(Type + 1);
			bool flag = num < 15;
			bool flag2 = !flag;
			int num2 = num - 15;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 25272320 + 2560;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X9_v2 (System.Int32)+v44 @ X8_v5 (System.Int32)*4]");
				object obj = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v60 @ X8_v11 (should have been resolved before IL gen)");
			}
			ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x600027B")]
		[Address(RVA = "0xCBB60C", Offset = "0xCBB60C", Length = "0x6C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EABF68]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, variable, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20236AF]) = v41;\nL_0015:\n\tv42 = variable == 0;\n\tif (v42) goto L_0380;\n\tv44 = v39.type + 1;\n\tv45 = v44 < 0xF;\n\tv46 = ~v45;\n\tv47 = v44 - 0xF;\n\tv49 = v47 == 0;\n\tv54 = ~v49;\n\tv55 = v46 & v54;\n\tif (v55) goto L_03CF;\n\tv62 = 0x181A000 + 0x9C0;\n\tv64 = *([v62 @ X9_v2 (System.Int32)+v44 @ X8_v4 (System.Int32)*4]) + v62;\n\t// 41 IndirectJump v64 @ X8_v10, v39 @ X0_v1 (HutongGames.PlayMaker.FsmVar), v39 @ X0_v1 (HutongGames.PlayMaker.FsmVar), variable @ X1 (HutongGames.PlayMaker.INamedVariable), methodInfo @ X2 (Il2CppMethodInfo), v26 @ X3, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tX9 = *([1ED98E0]);\n\tX8 = *([X19]);\n\tX1 = *([X9]);\n\tX10 = *([X8+128]);\n\tX9 = *([X1+128]);\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_03CA;\n\tX8 = *([X8+C8]);\n\tTEMPSHIFT = X9 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8-8]);\n\tC = X8 < X1;\n\tC = ~C;\n\tTEMP1 = X8 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_03CA;\n\tX8 = *([X19]);\n\tX9 = *([X1+128]);\n\tX10 = *([X8+128]);\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_03CA;\n\tX8 = *([X8+C8]);\n\tTEMPSHIFT = X9 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8-8]);\n\tC = X8 < X1;\n\tC = ~C;\n\tTEMP1 = X8 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_03CA;\n\tX0 = X19;\n\tV0 = HutongGames.PlayMaker.FsmFloat::get_Value(X0, X1);\n\t*([X20+54]) = V0;\n\tgoto L_0380;\n\tX9 = *([1ECE5A0]);\n\tX8 = *([X19]);\n\tX1 = *([X9]);\n\tX10 = *([X8+128]);\n\tX9 = *([X1+128]);\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_03CA;\n\tX8 = *([X8+C8]);\n\tTEMPSHIFT = X9 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8-8]);\n\tC = X8 < X1;\n\tC = ~C;\n\tTEMP1 = X8 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_03CA;\n\tX8 = *([X19]);\n\tX9 = *([X1+128]);\n\tX10 = *([X8+128]);\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_03CA;\n\tX8 = *([X8+C8]);\n\tTEMPSHIFT = X9 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8-8]);\n\tC = X8 < X1;\n\tC = ~C;\n\tTEMP1 = X8 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_03CA;\n\tX0 = X19;\n\tX0 = HutongGames.PlayMaker.FsmInt::get_Value(X0, X1);\n\t*([X20+58]) = X0;\n\tgoto L_0380;\n\tX9 = *([1F0E6C0]);\n\tX8 = *([X19]);\n\tX1 = *([X9]);\n\tX10 = *([X8+128]);\n\tX9 = *([X1+128]);\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_03CA;\n\tX8 = *([X8+C8]);\n\tTEMPSHIFT = X9 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8-8]);\n\tC = X8 < X1;\n\tC = ~C;\n\tTEMP1 = X8 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_03CA;\n\tX8 = *([X19]);\n\tX9 = *([X1+128]);\n\tX10 = *([X8+128]);\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_03CA;\n\tX8 = *([X8+C8]);\n\tTEMPSHIFT = X9 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8-8]);\n\tC = X8 < X1;\n\tC = ~C;\n\tTEMP1 = X8 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_03CA;\n\tX0 = X19;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tX8 = X0 & 1;\n\t*([X20+5C]) = X8;\n\tgoto L_0380;\n\tX9 = *([1EA73B8]);\n\tX8 = *([X19]);\n\tX1 = *([X9]);\n\tX10 = *([X8+128]);\n\tX9 = *([X1+128]);\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_03CA;\n\tX8 = *([X8+C8]);\n\tTEMPSHIFT = X9 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8-8]);\n\tC = X8 < X1;\n\tC = ~C;\n\tTEMP1 = X8 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_03CA;\n\tX8 = *([X19]);\n\tX9 = *([X1+128]);\n\tX10 = *([X8+128]);\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_03CA;\n\tX8 = *([X8+C8]);\n\tTEMPSHIFT = X9 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8-8]);\n\tC = X8 < X1;\n\tC = ~C;\n\tTEMP1 = X8 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_03CA;\n\tX0 = X19;\n\tX0 = HutongGames.PlayMaker.FsmGameObject::get_Value(X0, X1);\n\t*([X20+78]) = X0;\n\tgoto L_0380;\n\tX9 = *([1ED01C0]);\n\tX8 = *([X19]);\n\tX1 = *([X9]);\n\tX10 = *([X8+128]);\n\tX9 = *([X1+128]);\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_03CA;\n\tX8 = *([X8+C8]);\n\tTEMPSHIFT = X9 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8-8]);\n\tC = X8 < X1;\n\tC = ~C;\n\tTEMP1 = X8 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_03CA;\n\tX8 = *([X19]);\n\tX9 = *([X1+128]);\n\tX10 = *([X8+128]);\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_03CA;\n\tX8 = *([X8+C8]);\n\tTEMPSHIFT = X9 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8-8]);\n\tC = X8 < X1;\n\tC = ~C;\n\tTEMP1 = X8 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_03CA;\n\tX0 = X19;\n\tX0 = HutongGames.PlayMaker.FsmString::get_Value(X0, X1);\n\t*([X20+60]) = X0;\n\tgoto L_0380;\n\tX9 = *([1EC9AF0]);\n\tX8 = *([X19]);\n\tX1 = *([X9]);\n\tX10 = *([X8+128]);\n\tX9 = *([X1+128]);\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_03CA;\n\tX8 = *([X8+C8]);\n\tTEMPSHIFT = X9 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8-8]);\n\tC = X8 < X1;\n\tC = ~C;\n\tTEMP1 = X8 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_03CA;\n\tX8 = *([X19]);\n\tX9 = *([X1+128]);\n\tX10 = *([X8+128]);\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_03CA;\n\tX8 = *([X8+C8]);\n\tTEMPSHIFT = X9 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8-8]);\n\tC = X8 < X1;\n\tC = ~C;\n\tTEMP1 = X8 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_03CA;\n\tV0 = *([X19+38]);\n\tV1 = *([X19+3C]);\n\tX0 = X20 + 0x68;\n\tV2 = 0;\n\tgoto L_01F5;\n\tX9 = *([1EDC658]);\n\tX8 = *([X19]);\n\tX1 = *([X9]);\n\tX10 = *([X8+128]);\n\tX9 = *([X1+128]);\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_03CA;\n\tX8 = *([X8+C8]);\n\tTEMPSHIFT = X9 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8-8]);\n// ... 531 further instructions omitted\n// 55 bookkeeping instructions omitted: flag registers, address ba\n// ... truncated")]
		public void GetValueFrom(INamedVariable variable)
		{
			//IL_0096: Expected O, but got I
			if (variable != null)
			{
				int num = (int)(Type + 1);
				bool flag = num < 15;
				bool flag2 = !flag;
				int num2 = num - 15;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					int num3 = 25272320 + 2496;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X9_v2 (System.Int32)+v44 @ X8_v4 (System.Int32)*4]");
					object obj = 0L + (long)num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v64 @ X8_v10 (should have been resolved before IL gen)");
				}
				ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
				throw ex;
			}
		}

		[Token(Token = "0x600027C")]
		[Address(RVA = "0xCB68FC", Offset = "0xCB68FC", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.namedVar == 0;\n\tv12 = ~v11;\n\tif (v12) goto L_0012;\n\tHutongGames.PlayMaker.FsmVar::InitNamedVar(this);\nL_0012:\n\tHutongGames.PlayMaker.FsmVar::GetValueFrom(this, v15);\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateValue()
		{
			bool flag = namedVar == null;
			bool flag2 = !flag;
			INamedVariable variable = namedVar;
			if (!flag2)
			{
				InitNamedVar();
				variable = namedVar;
			}
			GetValueFrom(variable);
		}

		[Token(Token = "0x600027D")]
		[Address(RVA = "0xCBC118", Offset = "0xCBC118", Length = "0x6F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EF9BF0]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, targetVariable, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20236B0]) = v41;\nL_0015:\n\tv42 = targetVariable == 0;\n\tif (v42) goto L_03FC;\n\tv44 = v39.type + 1;\n\tv45 = v44 < 0xF;\n\tv46 = ~v45;\n\tv47 = v44 - 0xF;\n\tv49 = v47 == 0;\n\tv54 = ~v49;\n\tv55 = v46 & v54;\n\tif (v55) goto L_0402;\n\tv62 = 0x181A000 + 0xA40;\n\tv64 = *([v62 @ X9_v2 (System.Int32)+v44 @ X8_v4 (System.Int32)*4]) + v62;\n\t// 41 IndirectJump v64 @ X8_v10, v39 @ X0_v1 (HutongGames.PlayMaker.FsmVar), v39 @ X0_v1 (HutongGames.PlayMaker.FsmVar), targetVariable @ X1 (HutongGames.PlayMaker.INamedVariable), methodInfo @ X2 (Il2CppMethodInfo), v26 @ X3, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tX9 = *([1ED98E0]);\n\tX8 = *([X19]);\n\tX1 = *([X9]);\n\tX10 = *([X8+128]);\n\tX9 = *([X1+128]);\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_03FD;\n\tX8 = *([X8+C8]);\n\tTEMPSHIFT = X9 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8-8]);\n\tC = X8 < X1;\n\tC = ~C;\n\tTEMP1 = X8 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_03FD;\n\tX8 = *([X19]);\n\tX9 = *([X1+128]);\n\tX10 = *([X8+128]);\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_03FD;\n\tX8 = *([X8+C8]);\n\tTEMPSHIFT = X9 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8-8]);\n\tC = X8 < X1;\n\tC = ~C;\n\tTEMP1 = X8 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_03FD;\n\tX8 = *([X20+54]);\n\t*([X19+38]) = X8;\n\tgoto L_03FC;\n\tX9 = *([1ECE5A0]);\n\tX8 = *([X19]);\n\tX1 = *([X9]);\n\tX10 = *([X8+128]);\n\tX9 = *([X1+128]);\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_03FD;\n\tX8 = *([X8+C8]);\n\tTEMPSHIFT = X9 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8-8]);\n\tC = X8 < X1;\n\tC = ~C;\n\tTEMP1 = X8 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_03FD;\n\tX8 = *([X19]);\n\tX9 = *([X1+128]);\n\tX10 = *([X8+128]);\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_03FD;\n\tX8 = *([X8+C8]);\n\tTEMPSHIFT = X9 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8-8]);\n\tC = X8 < X1;\n\tC = ~C;\n\tTEMP1 = X8 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_03FD;\n\tX8 = *([X20+58]);\n\t*([X19+38]) = X8;\n\tgoto L_03FC;\n\tX9 = *([1F0E6C0]);\n\tX8 = *([X19]);\n\tX1 = *([X9]);\n\tX10 = *([X8+128]);\n\tX9 = *([X1+128]);\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_03FD;\n\tX8 = *([X8+C8]);\n\tTEMPSHIFT = X9 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8-8]);\n\tC = X8 < X1;\n\tC = ~C;\n\tTEMP1 = X8 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_03FD;\n\tX8 = *([X19]);\n\tX9 = *([X1+128]);\n\tX10 = *([X8+128]);\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_03FD;\n\tX8 = *([X8+C8]);\n\tTEMPSHIFT = X9 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8-8]);\n\tC = X8 < X1;\n\tC = ~C;\n\tTEMP1 = X8 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_03FD;\n\tX8 = *([X20+5C]);\n\t*([X19+38]) = X8;\n\tgoto L_03FC;\n\tX9 = *([1EA73B8]);\n\tX8 = *([X19]);\n\tX1 = *([X9]);\n\tX10 = *([X8+128]);\n\tX9 = *([X1+128]);\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_03FD;\n\tX8 = *([X8+C8]);\n\tTEMPSHIFT = X9 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8-8]);\n\tC = X8 < X1;\n\tC = ~C;\n\tTEMP1 = X8 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_03FD;\n\tX8 = *([X19]);\n\tX9 = *([X1+128]);\n\tX10 = *([X8+128]);\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_03FD;\n\tX8 = *([X8+C8]);\n\tTEMPSHIFT = X9 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8-8]);\n\tC = X8 < X1;\n\tC = ~C;\n\tTEMP1 = X8 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_03FD;\n\tX8 = *([X20+78]);\n\tif (TEMP) goto L_013D;\n\tX9 = *([1EE3A20]);\n\tX10 = *([X8]);\n\tX9 = *([X9]);\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCSEL = ~Z;\n\tif (TEMPCSEL) goto L_013B;\n\tX8 = X8;\n\tgoto L_013C;\nL_013B:\n\tX8 = 0;\nL_013C:\n\t;\nL_013D:\n\tX9 = *([X19+40]);\n\tC = X9 < X8;\n\tC = ~C;\n\tTEMP1 = X9 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X8;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_03FC;\n\tX0 = *([X19+38]);\n\t*([X19+40]) = X8;\n\tif (TEMP) goto L_03FC;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX1 = 0;\n\tX21 = stack[0];\n\t// 338 ShiftStack 48\n\tSystem.Action::Invoke(X0, X1);\n\treturn;\n\tX9 = *([1ED01C0]);\n\tX8 = *([X19]);\n\tX1 = *([X9]);\n\tX10 = *([X8+128]);\n\tX9 = *([X1+128]);\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_03FD;\n\tX8 = *([X8+C8]);\n\tTEMPSHIFT = X9 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8-8]);\n\tC = X8 < X1;\n\tC = ~C;\n\tTEMP1 = X8 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_03FD;\n\tX8 = *([X19]);\n\tX9 = *([X1+128]);\n\tX10 = *([X8+128]);\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_03FD;\n\tX8 = *([X8+C8]);\n\tTEMPSHIFT = X9 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8-8]);\n\tC = X8 < X1;\n\tC = ~C;\n\tTEMP1 = X8 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_03FD;\n\tX8 = *([X20+60]);\n\t*([X19+38]) = X8;\n\tgoto L_03FC;\n\tV0 = *([X20+68]);\n\tV1 = *([X20+6C]);\n\tX0 = X20 + 0x88;\n\tX1 = 0;\n\tX0 = 0x1588BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX9 = *([1EC9AF0]);\n\tX8 = *([X19]);\n\tX1 = *([X9]);\n\tX10 = *([X8+128]);\n\tX9 = *([X1+128]);\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_03FD;\n\tX8 = *([X8+C8]);\n\tTEMPSHIFT = X9 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8-8]);\n\tC = X8 < X1;\n\tC = ~C;\n\tTEMP1 = X8 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_03FD;\n\tX8 = *([X19]);\n\tX9 = *([X1+128]);\n\tX10 = *([X8+128]);\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_03FD;\n\tX8 = *([X8+C8]);\n// ... 580 further instructions omitted\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ApplyValueTo(INamedVariable targetVariable)
		{
			//IL_0096: Expected O, but got I
			if (targetVariable != null)
			{
				int num = (int)(Type + 1);
				bool flag = num < 15;
				bool flag2 = !flag;
				int num2 = num - 15;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					int num3 = 25272320 + 2624;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X9_v2 (System.Int32)+v44 @ X8_v4 (System.Int32)*4]");
					object obj = 0L + (long)num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v64 @ X8_v10 (should have been resolved before IL gen)");
				}
				ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
				throw ex;
			}
		}

		[Token(Token = "0x600027E")]
		[Address(RVA = "0xCBC810", Offset = "0xCBC810", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EC8310]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20236B1]) = v38;\nL_0015:\n\tv41 = System.String::IsNullOrEmpty(this.variableName);\n\tv43 = v41 == 0;\n\tif (v43) goto L_0022;\n\treturn \"None\";\nL_0022:\n\tv60 = this.namedVar;\n\tv53 = this.namedVar == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_0034;\n\tHutongGames.PlayMaker.FsmVar::InitNamedVar(this);\n\tv60 = this.namedVar;\nL_0034:\n\treturnVal2 = System.String::Concat(this.variableName, \": \", v60);\n\treturn returnVal2;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string DebugString()
		{
			if (string.IsNullOrEmpty(variableName))
			{
				return "None";
			}
			NamedVariable namedVariable = namedVar;
			if (namedVar == null)
			{
				InitNamedVar();
				namedVariable = namedVar;
			}
			return variableName + ": " + namedVariable;
		}

		[Token(Token = "0x600027F")]
		[Address(RVA = "0xCBC8A4", Offset = "0xCBC8A4", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EBE768]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20236B2]) = v38;\nL_0013:\n\tv43 = this.namedVar;\n\tv40 = this.namedVar == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_001C;\n\tHutongGames.PlayMaker.FsmVar::InitNamedVar(this);\n\tv43 = this.namedVar;\n\tv46 = this.namedVar == 0;\n\tif (v46) goto L_002D;\nL_001C:\n\tv47 = *([v43 @ X0_v3 (HutongGames.PlayMaker.NamedVariable)]);\n\tv50 = *([v47 @ X8_v3 (Il2CppClass<HutongGames.PlayMaker.NamedVariable>)+160]);\n\tv51 = *([v47 @ X8_v3 (Il2CppClass<HutongGames.PlayMaker.NamedVariable>)+168]);\n\t// 36 IndirectJump v50 @ X2_v1, v43 @ X0_v3 (HutongGames.PlayMaker.NamedVariable), v43 @ X0_v3 (HutongGames.PlayMaker.NamedVariable), v51 @ X1_v1, v50 @ X2_v1, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\nL_002D:\n\treturn \"None\";\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			//IL_003c: Expected I, but got O
			//IL_004c: Expected O, but got I
			//IL_005c: Expected O, but got I
			NamedVariable namedVariable = namedVar;
			if (namedVar == null)
			{
				InitNamedVar();
				namedVariable = namedVar;
				if (namedVar == null)
				{
					goto IL_0066;
				}
			}
			IntPtr intPtr = (IntPtr)namedVariable;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X8_v3 (Il2CppClass<HutongGames.PlayMaker.NamedVariable>)+160]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X8_v3 (Il2CppClass<HutongGames.PlayMaker.NamedVariable>)+168]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v50 @ X2_v1 (should have been resolved before IL gen)");
			goto IL_0066;
			IL_0066:
			return "None";
		}

		[Token(Token = "0x6000280")]
		[Address(RVA = "0xCBC91C", Offset = "0xCBC91C", Length = "0x5D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv25 = *([1EEA448]);\n\tv26 = *([v25 @ X8_v13]);\n\tv27 = \"il2cpp_codegen_initialize_method\"(v26, value, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20236B3]) = v44;\nL_0018:\n\tv46 = v42.type + 1;\n\tv47 = v46 < 0xF;\n\tv48 = ~v47;\n\tv49 = v46 - 0xF;\n\tv51 = v49 == 0;\n\tv56 = ~v51;\n\tv57 = v48 & v56;\n\tif (v57) goto L_025E;\n\tv59 = 0x181A000 + 0xA80;\n\tv61 = *([v59 @ X9_v2 (System.Int32)+v46 @ X8_v4 (System.Int32)*4]) + v59;\n\t// 41 IndirectJump v61 @ X8_v10, v42 @ X0_v1 (HutongGames.PlayMaker.FsmVar), v42 @ X0_v1 (HutongGames.PlayMaker.FsmVar), value @ X1 (System.Object), methodInfo @ X2 (Il2CppMethodInfo), v29 @ X3, v30 @ X4, v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\tX8 = *([1EDD508]);\n\tX21 = *([X8]);\n\tif (TEMP) goto L_01D4;\n\tX0 = X20;\n\tX1 = 0;\n\tX0 = System.Object::GetType(X0, X1);\n\tif (TEMP) goto L_026B;\n\tX8 = *([X0]);\n\tX9 = *([X8+160]);\n\tX1 = *([X8+168]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = X0;\n\tgoto L_01D7;\n\tif (TEMP) goto L_01EC;\n\tX8 = *([1EE1A60]);\n\tX9 = *([X20]);\n\tX1 = *([X8]);\n\tX8 = *([X9+40]);\n\tX9 = *([X1+40]);\n\tC = X8 < X9;\n\tC = ~C;\n\tTEMP1 = X8 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X9;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0268;\n\tX0 = X20;\n\tX0 = 0x8D82AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = *([X0]);\n\tgoto L_01ED;\n\tif (TEMP) goto L_01EF;\n\tX8 = *([1ED0418]);\n\tX9 = *([X20]);\n\tX1 = *([X8]);\n\tX8 = *([X9+40]);\n\tX9 = *([X1+40]);\n\tC = X8 < X9;\n\tC = ~C;\n\tTEMP1 = X8 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X9;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0268;\n\tX0 = X20;\n\tX0 = 0x8D82AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X0]);\n\tgoto L_01F0;\n\tif (TEMP) goto L_01F2;\n\tX8 = *([1EC5410]);\n\tX9 = *([X20]);\n\tX1 = *([X8]);\n\tX8 = *([X9+40]);\n\tX9 = *([X1+40]);\n\tC = X8 < X9;\n\tC = ~C;\n\tTEMP1 = X8 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X9;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0268;\n\tX0 = X20;\n\tX0 = 0x8D82AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X0]);\n\tgoto L_01F3;\n\tif (TEMP) goto L_0130;\n\tX8 = *([1EE3A20]);\n\tX9 = *([X20]);\n\tX8 = *([X8]);\n\tgoto L_01C3;\n\tif (TEMP) goto L_01F5;\n\tX8 = *([1EB3EF8]);\n\tX9 = *([X20]);\n\tX8 = *([X8]);\n\tC = X9 < X8;\n\tC = ~C;\n\tTEMP1 = X9 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X8;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCSEL = ~Z;\n\tif (TEMPCSEL) goto L_0099;\n\tX8 = X20;\n\tgoto L_009A;\nL_0099:\n\tX8 = 0;\nL_009A:\n\t;\n\tgoto L_01F6;\n\tX8 = *([1EFD6E0]);\n\tX8 = *([X8]);\n\tif (TEMP) goto L_01F8;\n\tX9 = *([X20]);\n\tX10 = *([X8+40]);\n\tX9 = *([X9+40]);\n\tC = X9 < X10;\n\tC = ~C;\n\tTEMP1 = X9 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X10;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_026E;\n\tX0 = X20;\n\tX0 = 0x8D82AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = *([X0]);\n\tV1 = *([X0+4]);\n\tgoto L_0205;\n\tX8 = *([1EE1550]);\n\tX8 = *([X8]);\n\tif (TEMP) goto L_0208;\n\tX9 = *([X20]);\n\tX10 = *([X8+40]);\n\tX9 = *([X9+40]);\n\tC = X9 < X10;\n\tC = ~C;\n\tTEMP1 = X9 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X10;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_026E;\n\tX0 = X20;\n\tX0 = 0x8D82AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = *([X0]);\n\tV1 = *([X0+4]);\n\tV2 = *([X0+8]);\n\tgoto L_0216;\n\tif (TEMP) goto L_0219;\n\tX8 = *([1EEBF30]);\n\tX9 = *([X20]);\n\tX1 = *([X8]);\n\tX8 = *([X9+40]);\n\tX9 = *([X1+40]);\n\tC = X8 < X9;\n\tC = ~C;\n\tTEMP1 = X8 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X9;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_0117;\n\tgoto L_0268;\n\tif (TEMP) goto L_021F;\n\tX8 = *([1ED0550]);\n\tX9 = *([X20]);\n\tX1 = *([X8]);\n\tX8 = *([X9+40]);\n\tX9 = *([X1+40]);\n\tC = X8 < X9;\n\tC = ~C;\n\tTEMP1 = X8 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X9;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0268;\n\tX0 = X20;\n\tX0 = 0x8D82AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = *([X0]);\n\tV1 = *([X0+4]);\n\tV2 = *([X0+8]);\n\tV3 = *([X0+C]);\n\tgoto L_0223;\n\tif (TEMP) goto L_0130;\n\tX8 = *([1ECA9D0]);\n\tgoto L_0122;\n\tif (TEMP) goto L_0130;\n\tX8 = *([1ED2388]);\n\tgoto L_0122;\n\tX8 = *([1EC5B90]);\n\tX8 = *([X8]);\n\tif (TEMP) goto L_0227;\n\tX9 = *([X20]);\n\tX10 = *([X8+40]);\n\tX9 = *([X9+40]);\n\tC = X9 < X10;\n\tC = ~C;\n\tTEMP1 = X9 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X10;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_026E;\nL_0117:\n\tX0 = X20;\n\tX0 = 0x8D82AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = *([X0]);\n\tV1 = *([X0+4]);\n\tV2 = *([X0+8]);\n\tV3 = *([X0+C]);\n\tgoto L_0236;\n\tif (TEMP) goto L_0130;\n\tX8 = *([1EAB010]);\nL_0122:\n\tX9 = *([X20]);\n\tX8 = *([X8]);\n\tX11 = *([X9+128]);\n\tX10 = *([X8+128]);\n\tC = X11 < X10;\n\tC = ~C;\n\tTEMP1 = X11 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X10;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_01BF;\nL_0130:\n\tX8 = 0;\n\tgoto L_01D2;\n\tif (TEMP) goto L_024F;\n\tX8 = *([1EC2648]);\n\tX9 = *([X20]);\n\tX8 = *([X8]);\n\tX11 = *([X9+128]);\n\tX10 = *([X8+128]);\n\tC = X11 < X10;\n\tC = ~C;\n\tTEMP1 = X11 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X10;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_024F;\n\tX9 = *([X9+C8]);\n\tTEMPSHIFT = X10 << 3;\n\tX9 = X9 + TEMPSHIFT;\n\tX9 = *([X9-8]);\n\tC = X9 < X8;\n\tC = ~C;\n\tTEMP1 = X9 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X8;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_024F;\n\tX0 = X20;\n\tX1 = 0;\n\tX0 = System.Array::get_Length(X0, X1);\n\tX8 = *([1EFE3C0]);\n\tX1 = X0;\n\tX8 = *([X8]);\n\tX0 = X8;\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\n\tX0 = X20;\n\tX1 = 0;\n\tX0 = System.Array::get_Length(X0, X1);\n\tC = X0 < 1;\n\tC = ~C;\n\tTEMP1 = X0 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X0 ^ 1;\n\tTEMP3 = X0 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_019B;\n\tX22 = 0;\nL_016E:\n\tX0 = X20;\n\tX1 = X22;\n\tX2 = 0;\n\tX0 = System.Array::GetValue(X0, X1, X2);\n\tX23 = X0;\n\t// 372 ConditionalJump @b121, TEMP\n\tif (TEMP) goto L_017D;\n\tX8 = *([X21]);\n\tX0 = X23;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_0271;\nL_017D:\n\tX8 = *([X21+18]);\n\tC = X22 < X8;\n\tC = ~C;\n\tTEMP1 = X22 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X8;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_026C;\n\tTEMPSHIFT = X22 << 3;\n\tX8 = X21 + TEMPSHIFT;\n\tX0 = X20;\n\tX1 = 0;\n\t*([X8+20]) = X23;\n\tX22 = X22 + 1;\n\tX0 = System.Array::get_Length(X0, X1);\n\tC = X22 < X0;\n\tC = ~C;\n\tTEMP1 = X22 - X0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X0;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_016E;\nL_019B:\n\tX20 = *([X19+80]);\n\t// 413 ConditionalJump @b121, TEMP\n\tX0 = 0;\n\t*([X20+88]) = X21;\n\tX0 = UnityEngine.Application::get_isEditor(X0);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_01A6;\n\tX0 = X20;\n\tHutongGames.PlayMaker.FsmArray::SaveChanges(X0, X1);\nL_01A6:\n\tX0 = *([X19+80]);\n\tif (TEMP) goto L_026B;\n\tHutongGames.PlayMaker.FsmArray::SaveChanges(X0, X1);\n\tgoto L_024F;\n\tif (TEMP) goto L_01BD;\n\tX8 = *([1EFE7E8]);\n\tX9 = *([X20]);\n\tX8 = *([X8]);\n\tX11 = *([X9+128]);\n\tX10 = *([X8+128]);\n\tC = X11 < X10;\n\tC = ~C;\n\tTEMP1 = X11 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X10;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_023A;\nL_01BD:\n\tX1 = 0;\n\tgoto L_024D;\nL_01BF:\n\tX9 = *([X9+C8]);\n\tTEMPSHIFT = X10 << 3;\n\tX9 = X9 + TEMPSHIFT;\n\tX9 = *([X9-8]);\nL_01C3:\n\tC = X9 < X8;\n\tC = ~C;\n\tTEMP1 = X9 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X8;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCSEL = ~Z;\n\tif (TEMPCSEL) goto L_01D0;\n\tX8 = X20;\n\tgoto\n// ... truncated")]
		public void SetValue(object value)
		{
			//IL_0029: Expected O, but got I
			int num = (int)(Type + 1);
			bool flag = num < 15;
			bool flag2 = !flag;
			int num2 = num - 15;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 25272320 + 2688;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X9_v2 (System.Int32)+v46 @ X8_v4 (System.Int32)*4]");
				object obj = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v61 @ X8_v10 (should have been resolved before IL gen)");
			}
			ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000281")]
		[Address(RVA = "0xCBCEF4", Offset = "0xCBCEF4", Length = "0x10E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1F070B0]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20236B4]) = v38;\nL_0014:\n\tv40 = this.type;\n\t// 25 Box v45 @ X0_v3 (System.Object), typeof(HutongGames.PlayMaker.VariableType), &v40 @ X8_v3 (HutongGames.PlayMaker.VariableType)\n\tv52 = System.String::Concat(\"Type: \", v45);\n\tgoto L_0031;\n\tv60 = *([v56 @ X8_v9+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_0031;\n\tv69 = v56;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v69, v48, v49, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0031:\n\tUnityEngine.Debug::Log(v52);\n\tv70 = this + 0x20;\n\tv72 = 0xE8F14C(v70, 0, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv79 = System.String::Concat(\"UseVariable: \", v72);\n\tUnityEngine.Debug::Log(v79);\n\treturn;\n\tActivateGameObjectFromListProvider::Initialize(X0, X1);\n\treturn;\n\tX0 = *([X8]);\n\tX0 = 0xCA6004(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\tX8 = *([X8+210]);\n\tX0 = 0xCA8008(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\treturn;\n// 1065 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DebugLog()
		{
			//IL_001a: Expected O, but got I
			VariableType variableType = Type;
			object obj = variableType;
			string message = "Type: " + obj;
			Debug.Log(message);
			object obj2 = (long)(IntPtr)this + 32L;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E8F14C (inside System.BitConverter::.cctor +0x64)");
			string text = default(string);
			string message2 = "UseVariable: " + text;
			Debug.Log(message2);
		}

		[Token(Token = "0x6000282")]
		[Address(RVA = "0xCB0E08", Offset = "0xCB0E08", Length = "0x3EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv20 = *([1EE52D8]);\n\tv21 = *([v20 @ X8_v62]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20236B5]) = v40;\nL_001D:\n\tgoto L_0025;\n\tv50 = *([v44 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0025;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0025:\n\tv59 = System.Type::GetTypeFromHandle(UnityEngine.Material);\n\tv64 = v59 == type;\n\tif (v64) goto L_FFFFFFFF;\n\tgoto L_003F;\n\tv77 = *([v70 @ X0_v8+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_003F;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v70, v58, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_003F:\n\tv86 = System.Type::GetTypeFromHandle(UnityEngine.Texture);\n\tv159 = v86 == type;\n\tif (v159) goto L_FFFFFFFF;\n\tgoto L_0059;\n\tv316 = *([v312 @ X0_v13+E0]);\n\tv317 = v316 == 0;\n\tv318 = ~v317;\n\tif (v318) goto L_0059;\n\tv320 = \"il2cpp_codegen_runtime_class_init\"(v312, v85, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0059:\n\tv322 = System.Type::GetTypeFromHandle(System.Single);\n\tv160 = v322 == type;\n\tif (v160) goto L_FFFFFFFF;\n\tgoto L_0073;\n\tv329 = *([v325 @ X0_v18+E0]);\n\tv330 = v329 == 0;\n\tv331 = ~v330;\n\tif (v331) goto L_0073;\n\tv333 = \"il2cpp_codegen_runtime_class_init\"(v325, v210, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0073:\n\tv335 = System.Type::GetTypeFromHandle(System.Int32);\n\tv161 = v335 == type;\n\tif (v161) goto L_FFFFFFFF;\n\tgoto L_008D;\n\tv342 = *([v338 @ X0_v23+E0]);\n\tv343 = v342 == 0;\n\tv344 = ~v343;\n\tif (v344) goto L_008D;\n\tv346 = \"il2cpp_codegen_runtime_class_init\"(v338, v211, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_008D:\n\tv348 = System.Type::GetTypeFromHandle(System.Boolean);\n\tv162 = v348 == type;\n\tif (v162) goto L_FFFFFFFF;\n\tgoto L_00A7;\n\tv355 = *([v351 @ X0_v28+E0]);\n\tv356 = v355 == 0;\n\tv357 = ~v356;\n\tif (v357) goto L_00A7;\n\tv359 = \"il2cpp_codegen_runtime_class_init\"(v351, v212, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00A7:\n\tv361 = System.Type::GetTypeFromHandle(System.String);\n\tv163 = v361 == type;\n\tif (v163) goto L_FFFFFFFF;\n\tgoto L_00C1;\n\tv368 = *([v364 @ X0_v33+E0]);\n\tv369 = v368 == 0;\n\tv370 = ~v369;\n\tif (v370) goto L_00C1;\n\tv372 = \"il2cpp_codegen_runtime_class_init\"(v364, v213, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00C1:\n\tv374 = System.Type::GetTypeFromHandle(UnityEngine.GameObject);\n\tv164 = v374 == type;\n\tif (v164) goto L_FFFFFFFF;\n\tgoto L_00DB;\n\tv381 = *([v377 @ X0_v38+E0]);\n\tv382 = v381 == 0;\n\tv383 = ~v382;\n\tif (v383) goto L_00DB;\n\tv385 = \"il2cpp_codegen_runtime_class_init\"(v377, v214, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00DB:\n\tv387 = System.Type::GetTypeFromHandle(UnityEngine.Vector2);\n\tv165 = v387 == type;\n\tif (v165) goto L_FFFFFFFF;\n\tgoto L_00F5;\n\tv394 = *([v390 @ X0_v43+E0]);\n\tv395 = v394 == 0;\n\tv396 = ~v395;\n\tif (v396) goto L_00F5;\n\tv398 = \"il2cpp_codegen_runtime_class_init\"(v390, v215, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00F5:\n\tv400 = System.Type::GetTypeFromHandle(UnityEngine.Vector3);\n\tv166 = v400 == type;\n\tif (v166) goto L_FFFFFFFF;\n\tgoto L_010F;\n\tv407 = *([v403 @ X0_v48+E0]);\n\tv408 = v407 == 0;\n\tv409 = ~v408;\n\tif (v409) goto L_010F;\n\tv411 = \"il2cpp_codegen_runtime_class_init\"(v403, v216, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_010F:\n\tv413 = System.Type::GetTypeFromHandle(UnityEngine.Rect);\n\tv167 = v413 == type;\n\tif (v167) goto L_FFFFFFFF;\n\tgoto L_0129;\n\tv420 = *([v416 @ X0_v53+E0]);\n\tv421 = v420 == 0;\n\tv422 = ~v421;\n\tif (v422) goto L_0129;\n\tv424 = \"il2cpp_codegen_runtime_class_init\"(v416, v217, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0129:\n\tv426 = System.Type::GetTypeFromHandle(UnityEngine.Quaternion);\n\tv168 = v426 == type;\n\tif (v168) goto L_FFFFFFFF;\n\tgoto L_0143;\n\tv433 = *([v429 @ X0_v58+E0]);\n\tv434 = v433 == 0;\n\tv435 = ~v434;\n\tif (v435) goto L_0143;\n\tv437 = \"il2cpp_codegen_runtime_class_init\"(v429, v218, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0143:\n\tv439 = System.Type::GetTypeFromHandle(UnityEngine.Color);\n\tv158 = v439 == type;\n\tif (v158) goto L_FFFFFFFF;\n\tgoto L_015D;\n\tv447 = *([v442 @ X0_v63+E0]);\n\tv448 = v447 == 0;\n\tv449 = ~v448;\n\tif (v449) goto L_015D;\n\tv451 = \"il2cpp_codegen_runtime_class_init\"(v442, v219, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_015D:\n\tv456 = System.Type::GetTypeFromHandle(UnityEngine.Object);\n\tv458 = System.Type::IsAssignableFrom(v456, type);\n\tv239 = v458 == 0;\n\tif (v239) goto L_0188;\n\tgoto L_01A4;\n\tgoto L_01A4;\n\tgoto L_01A4;\n\tgoto L_01A4;\n\tgoto L_01A4;\n\tgoto L_01A4;\n\tgoto L_01A4;\n\tgoto L_01A4;\n\tgoto L_01A4;\n\tgoto L_01A4;\n\tgoto L_01A4;\n\tgoto L_01A4;\n\tgoto L_01A4;\nL_0188:\n\tv465 = System.Type::get_IsEnum(type);\n\tv250 = v465 == 0;\n\tif (v250) goto L_0190;\n\tgoto L_01A4;\nL_0190:\n\tv468 = System.Type::get_IsArray(type);\n\tv169 = v468 == 0;\n\tv92 = ~v169;\n\tv89 = ~v92;\n\tif (v89) goto L_FFFFFFFF;\n\tgoto L_01A4;\nL_01A4:\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 274 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static VariableType GetVariableType(Type type)
		{
			Type typeFromHandle = typeof(Material);
			if ((object)typeFromHandle != type)
			{
				Type typeFromHandle2 = typeof(Texture);
				if ((object)typeFromHandle2 != type)
				{
					Type typeFromHandle3 = typeof(float);
					if ((object)typeFromHandle3 != type)
					{
						Type typeFromHandle4 = typeof(int);
						if ((object)typeFromHandle4 != type)
						{
							Type typeFromHandle5 = typeof(bool);
							if ((object)typeFromHandle5 != type)
							{
								Type typeFromHandle6 = typeof(string);
								if ((object)typeFromHandle6 != type)
								{
									Type typeFromHandle7 = typeof(GameObject);
									if ((object)typeFromHandle7 != type)
									{
										Type typeFromHandle8 = typeof(Vector2);
										if ((object)typeFromHandle8 != type)
										{
											Type typeFromHandle9 = typeof(Vector3);
											if ((object)typeFromHandle9 != type)
											{
												Type typeFromHandle10 = typeof(Rect);
												if ((object)typeFromHandle10 != type)
												{
													Type typeFromHandle11 = typeof(Quaternion);
													if ((object)typeFromHandle11 != type)
													{
														Type typeFromHandle12 = typeof(Color);
														if ((object)typeFromHandle12 != type)
														{
															Type typeFromHandle13 = typeof(UnityEngine.Object);
															if (typeFromHandle13.IsAssignableFrom(type))
															{
																return VariableType.Object;
															}
															if (type.IsEnum)
															{
																return VariableType.Enum;
															}
															if (type.IsArray)
															{
																return VariableType.Array;
															}
															return VariableType.Unknown;
														}
														return VariableType.Color;
													}
													return VariableType.Quaternion;
												}
												return VariableType.Rect;
											}
											return VariableType.Vector3;
										}
										return VariableType.Vector2;
									}
									return VariableType.GameObject;
								}
								return VariableType.String;
							}
							return VariableType.Bool;
						}
						return VariableType.Int;
					}
					return default(VariableType);
				}
				return VariableType.Texture;
			}
			return VariableType.Material;
		}
	}
}
