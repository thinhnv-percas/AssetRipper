using System;
using System.Globalization;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	[Token(Token = "0x2000056")]
	public class FsmEnum : NamedVariable
	{
		[SerializeField]
		[Token(Token = "0x4000160")]
		[FieldOffset(Offset = "0x38")]
		private string enumName;

		[SerializeField]
		[Token(Token = "0x4000161")]
		[FieldOffset(Offset = "0x40")]
		private int intValue;

		[Token(Token = "0x4000162")]
		[FieldOffset(Offset = "0x48")]
		private Enum value;

		[Token(Token = "0x4000163")]
		[FieldOffset(Offset = "0x50")]
		internal int parsedIntValue;

		[Token(Token = "0x4000164")]
		[FieldOffset(Offset = "0x58")]
		private Type enumType;

		[Token(Token = "0x1700006E")]
		public override object RawValue
		{
			[Token(Token = "0x60001C2")]
			[Address(RVA = "0xCA4350", Offset = "0xCA4350", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = HutongGames.PlayMaker.FsmEnum::get_Value(this);\n\treturn returnVal1;\n")]
			get
			{
				return Value;
			}
			[Token(Token = "0x60001C3")]
			[Address(RVA = "0xCA4480", Offset = "0xCA4480", Length = "0x94")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EDF2E0]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023539]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_003F;\n\tgoto L_FFFFFFFF;\n\tv63 = v63_asT == 0;\n\tif (v63) goto L_0042;\nL_003F:\n\tHutongGames.PlayMaker.FsmEnum::set_Value(this, value);\n\treturn;\nL_0042:\n\tthrow System.InvalidCastException;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (value != null)
				{
					Enum obj = value as Enum;
					if (obj == null)
					{
						throw new InvalidCastException();
					}
				}
				Value = (Enum)value;
			}
		}

		[Token(Token = "0x1700006F")]
		public Type EnumType
		{
			[Token(Token = "0x60001C4")]
			[Address(RVA = "0xCA4594", Offset = "0xCA4594", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.enumType == 0;\n\tif (v11) goto L_001B;\n\tv13 = System.Type::get_IsAbstract(this.enumType);\n\tv30 = v13 == 0;\n\tv25 = ~v30;\n\tif (v25) goto L_001B;\n\tv40 = this.enumType;\n\tv27 = System.Type::get_IsEnum(v40);\n\tv66 = v27 == 0;\n\tv24 = ~v66;\n\tif (v24) goto L_0021;\nL_001B:\n\tHutongGames.PlayMaker.FsmEnum::InitEnumType(this);\nL_0021:\n\treturn this.enumType;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if ((object)enumType != null && !enumType.IsAbstract)
				{
					Type type = enumType;
					if (type.IsEnum)
					{
						goto IL_00a8;
					}
				}
				InitEnumType();
				goto IL_00a8;
				IL_00a8:
				return enumType;
			}
			[Token(Token = "0x60001C5")]
			[Address(RVA = "0xCA46E8", Offset = "0xCA46E8", Length = "0x16C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EFEA68]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202353A]) = v41;\nL_0016:\n\tv43 = this.enumType == 0;\n\tif (v43) goto L_002A;\n\tv45 = System.Type::get_IsAbstract(this.enumType);\n\tv60 = v45 == 0;\n\tv55 = ~v60;\n\tif (v55) goto L_002A;\n\tv76 = this.enumType;\n\tv52 = System.Type::get_IsEnum(v76);\n\tv85 = v52 == 0;\n\tv54 = ~v85;\n\tif (v54) goto L_0030;\nL_002A:\n\tHutongGames.PlayMaker.FsmEnum::InitEnumType(this);\nL_0030:\n\tv71 = this.enumType == value;\n\tif (v71) goto L_0040;\n\tv78 = value == 0;\n\tif (v78) goto L_004A;\n\tthis.enumType = value;\n\tgoto L_0057;\nL_0040:\n\treturn;\nL_004A:\n\tgoto L_0052;\n\tv202 = *([v143 @ X0_v15+E0]);\n\tv203 = v202 == 0;\n\tv204 = ~v203;\n\tif (v204) goto L_0052;\n\tv206 = \"il2cpp_codegen_runtime_class_init\"(v143, v62, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0052:\n\tv130 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.None);\n\tthis.enumType = v130;\nL_0057:\n\t;\n\tv200 = System.Type::get_FullName(v135);\n\tthis.enumName = v200;\n\tHutongGames.PlayMaker.FsmEnum::InitEnumType(this);\n\tv211 = System.Activator::CreateInstance(this.enumType);\n\tv132 = v211 == 0;\n\tif (v132) goto L_008D;\n\tgoto L_FFFFFFFF;\n\tv226 = v226_asT == 0;\n\tif (v226) goto L_0090;\nL_008D:\n\tHutongGames.PlayMaker.FsmEnum::set_Value(this, v211);\n\treturn;\nL_0090:\n\tv129 = new System.InvalidCastException();\n\tthrow System.NullReferenceException;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if ((object)enumType != null && !enumType.IsAbstract)
				{
					Type type = enumType;
					if (type.IsEnum)
					{
						goto IL_008e;
					}
				}
				InitEnumType();
				goto IL_008e;
				IL_008e:
				if ((object)enumType == value)
				{
					return;
				}
				Type type2;
				if ((object)value != null)
				{
					enumType = value;
					type2 = value;
				}
				else
				{
					type2 = (enumType = typeof(None));
				}
				string fullName = type2.FullName;
				EnumName = fullName;
				InitEnumType();
				object obj = Activator.CreateInstance(enumType);
				if (obj != null)
				{
					Enum obj2 = obj as Enum;
					if (obj2 == null)
					{
						InvalidCastException ex = new InvalidCastException();
						throw new NullReferenceException();
					}
				}
				Value = (Enum)obj;
			}
		}

		[Token(Token = "0x17000070")]
		public string EnumName
		{
			[Token(Token = "0x60001C7")]
			[Address(RVA = "0xCA4854", Offset = "0xCA4854", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.enumName;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return EnumName;
			}
			[Token(Token = "0x60001C8")]
			[Address(RVA = "0xCA485C", Offset = "0xCA485C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.enumName = value;\n\treturn;\n")]
			set
			{
				EnumName = value;
			}
		}

		[Token(Token = "0x17000071")]
		public Enum Value
		{
			[Token(Token = "0x60001C9")]
			[Address(RVA = "0xCA4354", Offset = "0xCA4354", Length = "0x12C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1ED9DF8]);\n\tv23 = *([v22 @ X8_v18]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202353C]) = v42;\nL_0016:\n\tv44 = this + 0x40;\n\tv56 = this.parsedIntValue != this.intValue;\n\tif (v56) goto L_0029;\n\treturnVal1 = this.value;\n\tv58 = this.value == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_007C;\n\tgoto L_002B;\nL_0029:\n\tthis.value = 0;\nL_002B:\n\tv111 = HutongGames.PlayMaker.FsmEnum::get_EnumType(this);\n\tgoto L_003B;\n\tv156 = *([v152 @ X8_v6+E0]);\n\tv157 = v156 == 0;\n\tv158 = ~v157;\n\tgoto L_003B;\n\tv165 = v152;\n\tv161 = \"il2cpp_codegen_runtime_class_init\"(v165, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_003B:\n\tv164 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv169 = 0xDC35C4(v44, v164, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0051;\n\tv175 = *([v171 @ X8_v7+E0]);\n\tv176 = v175 == 0;\n\tv177 = ~v176;\n\tif (v177) goto L_0051;\n\tv184 = v171;\n\tv180 = \"il2cpp_codegen_runtime_class_init\"(v184, v166, v168, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0051:\n\tv95 = System.Enum::Parse(v111, v169);\n\tv97 = v95 == 0;\n\tif (v97) goto L_0073;\n\tgoto L_FFFFFFFF;\n\tv197 = v197_asT == 0;\n\tif (v197) goto L_007D;\nL_0073:\n\tthis.value = v95;\n\tthis.parsedIntValue = this.intValue;\nL_007C:\n\treturn returnVal1;\nL_007D:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0101: Expected O, but got I
				object obj = (long)(IntPtr)this + 64L;
				Enum result;
				if (parsedIntValue == intValue)
				{
					result = value;
					if (value != null)
					{
						goto IL_0124;
					}
				}
				else
				{
					value = null;
				}
				Type type = EnumType;
				CultureInfo invariantCulture = CultureInfo.InvariantCulture;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC35C4 (inside System.InvalidCastException::.ctor +0x2EC)");
				string text = default(string);
				object obj2 = Enum.Parse(type, text);
				if (obj2 != null)
				{
					Enum obj3 = obj2 as Enum;
					if (obj3 == null)
					{
						return (Enum)(object)new InvalidCastException();
					}
				}
				value = (Enum)obj2;
				parsedIntValue = intValue;
				result = (Enum)obj2;
				goto IL_0124;
				IL_0124:
				return result;
			}
			[Token(Token = "0x60001CA")]
			[Address(RVA = "0xCA4514", Offset = "0xCA4514", Length = "0x80")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EB8D80]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202353D]) = v41;\nL_0015:\n\tthis.value = value;\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0024:\n\tv57 = System.Convert::ToInt32(value);\n\tthis.intValue = v57;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				this.value = value;
				int num = Convert.ToInt32(value);
				intValue = num;
			}
		}

		[Token(Token = "0x17000072")]
		public override VariableType VariableType
		{
			[Token(Token = "0x60001D4")]
			[Address(RVA = "0xCA4C74", Offset = "0xCA4C74", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0xE;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return VariableType.Enum;
			}
		}

		[Token(Token = "0x17000073")]
		public override Type ObjectType
		{
			[Token(Token = "0x60001D5")]
			[Address(RVA = "0xCA4C7C", Offset = "0xCA4C7C", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = HutongGames.PlayMaker.FsmEnum::get_EnumType(this);\n\treturn returnVal1;\n")]
			get
			{
				return EnumType;
			}
			[Token(Token = "0x60001D6")]
			[Address(RVA = "0xCA4C80", Offset = "0xCA4C80", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmEnum::set_EnumType(this, value);\n\treturn;\n")]
			set
			{
				EnumType = value;
			}
		}

		[Token(Token = "0x60001C6")]
		[Address(RVA = "0xCA45F0", Offset = "0xCA45F0", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EDAD08]);\n\tv19 = *([v18 @ X8_v21]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202353B]) = v38;\nL_001A:\n\tgoto L_0022;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0022;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0022:\n\tv55 = HutongGames.PlayMaker.ReflectionUtils::GetGlobalType(this.enumName);\n\tthis.enumType = v55;\n\tv56 = v55 == 0;\n\tif (v56) goto L_0040;\n\tv58 = System.Type::get_IsAbstract(v55);\n\tv81 = v58 == 0;\n\tv68 = ~v81;\n\tif (v68) goto L_0040;\n\tv65 = System.Type::get_IsEnum(this.enumType);\n\tv96 = v65 == 0;\n\tv67 = ~v96;\n\tif (v67) goto L_0056;\nL_0040:\n\tgoto L_0048;\n\tv82 = *([v73 @ X0_v10+E0]);\n\tv83 = v82 == 0;\n\tv84 = ~v83;\n\tif (v84) goto L_0048;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v73, v62, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0048:\n\tv91 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.None);\n\tthis.enumType = v91;\n\tv107 = System.Type::get_FullName(v91);\n\tthis.enumName = v107;\nL_0056:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void InitEnumType()
		{
			Type type = (enumType = ReflectionUtils.GetGlobalType(EnumName));
			if ((object)type == null || type.IsAbstract || !enumType.IsEnum)
			{
				string fullName = (enumType = typeof(None)).FullName;
				EnumName = fullName;
			}
		}

		[Token(Token = "0x60001CB")]
		[Address(RVA = "0xCA4864", Offset = "0xCA4864", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EBC2B0]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202353E]) = v42;\nL_0016:\n\tv44 = HutongGames.PlayMaker.FsmEnum::get_EnumType(this);\n\tv48 = this + 0x40;\n\tgoto L_0026;\n\tv53 = *([v49 @ X0_v4+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0026;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v49, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0026:\n\tv61 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv65 = 0xDC35C4(v48, v61, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_003C;\n\tv73 = *([v69 @ X8_v7+E0]);\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_003C;\n\tv84 = v69;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v84, v62, v64, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_003C:\n\tv83 = System.Enum::Parse(v44, v65);\n\tv85 = v83 == 0;\n\tif (v85) goto L_005D;\n\tgoto L_FFFFFFFF;\n\tv104 = v104_asT == 0;\n\tif (v104) goto L_0066;\nL_005D:\n\tthis.value = v83;\n\treturn;\nL_0066:\n\tthrow System.InvalidCastException;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ResetValue()
		{
			//IL_00a6: Expected O, but got I
			Type type = EnumType;
			object obj = (long)(IntPtr)this + 64L;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC35C4 (inside System.InvalidCastException::.ctor +0x2EC)");
			string text = default(string);
			object obj2 = Enum.Parse(type, text);
			if (obj2 != null)
			{
				Enum obj3 = obj2 as Enum;
				if (obj3 == null)
				{
					throw new InvalidCastException();
				}
			}
			value = (Enum)obj2;
		}

		[Token(Token = "0x60001CC")]
		[Address(RVA = "0xCA4964", Offset = "0xCA4964", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.parsedIntValue = 0xFFFFFFFF;\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmEnum()
		{
			parsedIntValue = -1;
		}

		[Token(Token = "0x60001CD")]
		[Address(RVA = "0xCA4974", Offset = "0xCA4974", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv28 = *([1EA4F08]);\n\tv29 = *([v28 @ X8_v10]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, name, enumType, intValue, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([202353F]) = v45;\nL_001C:\n\tthis.parsedIntValue = 0xFFFFFFFF;\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this, name);\n\tHutongGames.PlayMaker.FsmEnum::set_EnumType(this, enumType);\n\tv53 = HutongGames.PlayMaker.FsmEnum::get_EnumType(this);\n\tgoto L_0032;\n\tv61 = *([v57 @ X8_v6+E0]);\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_0032;\n\tv70 = v57;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v70, v51, v49, intValue, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0032:\n\tv69 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv74 = 0xDC35C4(&intValue @ X3 (System.Int32), v69, 0, intValue, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_0048;\n\tv82 = *([v78 @ X8_v7+E0]);\n\tv83 = v82 == 0;\n\tv84 = ~v83;\n\tif (v84) goto L_0048;\n\tv93 = v78;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v93, v71, v73, intValue, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0048:\n\tv92 = System.Enum::Parse(v53, v74);\n\tv95 = v92 == 0;\n\tif (v95) goto L_006C;\n\tgoto L_FFFFFFFF;\n\tv114 = v114_asT == 0;\n\tif (v114) goto L_0076;\nL_006C:\n\tHutongGames.PlayMaker.FsmEnum::set_Value(this, v92);\n\treturn;\nL_0076:\n\tthrow System.InvalidCastException;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmEnum(string name, Type enumType, int intValue)
		{
			parsedIntValue = -1;
			base._002Ector(name);
			EnumType = enumType;
			Type type = EnumType;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC35C4 (inside System.InvalidCastException::.ctor +0x2EC)");
			string text = default(string);
			object obj = Enum.Parse(type, text);
			if (obj == null || obj is Enum)
			{
				Value = (Enum)obj;
				return;
			}
			throw new InvalidCastException();
		}

		[Token(Token = "0x60001CE")]
		[Address(RVA = "0xCA4ABC", Offset = "0xCA4ABC", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1ED1890]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, name, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023540]) = v41;\nL_0019:\n\tthis.parsedIntValue = 0xFFFFFFFF;\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this, name);\n\tgoto L_002C;\n\tv55 = *([v49 @ X0_v3+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tgoto L_002C;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v49, v44, v45, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002C:\n\tv64 = System.Type::GetTypeFromHandle(System.Enum);\n\tv69 = System.Type::get_FullName(v64);\n\tthis.enumName = v69;\n\tv72 = System.Type::GetTypeFromHandle(System.Enum);\n\tthis.enumType = v72;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmEnum(string name)
		{
			parsedIntValue = -1;
			base._002Ector(name);
			EnumName = typeof(Enum).FullName;
			enumType = typeof(Enum);
		}

		[Token(Token = "0x60001CF")]
		[Address(RVA = "0xCA4B84", Offset = "0xCA4B84", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.parsedIntValue = 0xFFFFFFFF;\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this, source);\n\tv18 = HutongGames.PlayMaker.FsmEnum::get_EnumType(source);\n\tHutongGames.PlayMaker.FsmEnum::set_EnumType(this, v18);\n\tv37 = HutongGames.PlayMaker.FsmEnum::get_Value(source);\n\tHutongGames.PlayMaker.FsmEnum::set_Value(this, v37);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmEnum(FsmEnum source)
		{
			parsedIntValue = -1;
			base._002Ector(source);
			Type type = source.EnumType;
			EnumType = type;
			Enum obj = source.Value;
			Value = obj;
		}

		[Token(Token = "0x60001D0")]
		[Address(RVA = "0xCA4BE4", Offset = "0xCA4BE4", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EE1120]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023541]) = v38;\nL_0016:\n\tv42 = new HutongGames.PlayMaker.FsmEnum();\n\tHutongGames.PlayMaker.FsmEnum::.ctor(v42, this);\n\treturn v42;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override NamedVariable Clone()
		{
			return new FsmEnum(this);
		}

		[Token(Token = "0x60001D1")]
		[Address(RVA = "0xCA4C44", Offset = "0xCA4C44", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = HutongGames.PlayMaker.FsmEnum::get_Value(this);\n\tv10 = *([v6 @ X0_v1 (System.Enum)]);\n\tv11 = *([v10 @ X8_v1 (Il2CppClass<System.Enum>)+160]);\n\tv12 = *([v10 @ X8_v1 (Il2CppClass<System.Enum>)+168]);\n\t// 13 IndirectJump v11 @ X2_v1, v6 @ X0_v1 (System.Enum), v6 @ X0_v1 (System.Enum), v12 @ X1_v1, v11 @ X2_v1, v15 @ X3, v16 @ X4, v17 @ X5, v18 @ X6, v19 @ X7, v20 @ V0, v21 @ V1, v22 @ V2, v23 @ V3, v24 @ V4, v25 @ V5, v26 @ V6, v27 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			//IL_0017: Expected I, but got O
			//IL_0027: Expected O, but got I
			//IL_0037: Expected O, but got I
			Enum obj = Value;
			IntPtr intPtr = (IntPtr)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X8_v1 (Il2CppClass<System.Enum>)+160]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X8_v1 (Il2CppClass<System.Enum>)+168]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v11 @ X2_v1 (should have been resolved before IL gen)");
			return null;
		}

		[Token(Token = "0x60001D2")]
		[Address(RVA = "0xCA4C68", Offset = "0xCA4C68", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.intValue;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override int ToInt()
		{
			return intValue;
		}

		[Token(Token = "0x60001D3")]
		[Address(RVA = "0xCA4C70", Offset = "0xCA4C70", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Clear()
		{
		}

		[Token(Token = "0x60001D7")]
		[Address(RVA = "0xCA4C84", Offset = "0xCA4C84", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EC3388]);\n\tv27 = *([v26 @ X8_v13]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, variableType, _enumType, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023542]) = v44;\nL_0017:\n\tv45 = variableType + 1;\n\tv47 = v45 == 0;\n\tif (v47) goto L_FFFFFFFF;\n\tv54 = HutongGames.PlayMaker.NamedVariable::TestTypeConstraint(this, variableType, this.enumType);\n\tv94 = v54 == 0;\n\tif (v94) goto L_FFFFFFFF;\n\tgoto L_0037;\n\tv137 = *([v132 @ X0_v8+E0]);\n\tv138 = v137 == 0;\n\tv139 = ~v138;\n\tif (v139) goto L_0037;\n\tv141 = \"il2cpp_codegen_runtime_class_init\"(v132, v52, v50, v53, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0037:\n\tv83 = System.Type::GetTypeFromHandle(System.Enum);\n\tv67 = this.enumType == v83;\n\tif (v67) goto L_FFFFFFFF;\n\tv145 = HutongGames.PlayMaker.FsmEnum::get_EnumType(this);\n\tv148 = v145 - _enumType;\n\tv150 = v148 == 0;\n\tv104 = _enumType == 0;\n\treturnVal1 = v104 | v150;\n\tgoto L_0064;\n\tgoto L_0064;\nL_0064:\n\treturn returnVal1;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool TestTypeConstraint(VariableType variableType, Type _enumType = null)
		{
			//IL_0080: Expected O, but got I
			if (variableType + 1 != VariableType.Float)
			{
				if (!base.TestTypeConstraint(variableType, enumType))
				{
					return false;
				}
				Type typeFromHandle = typeof(Enum);
				if ((object)enumType != typeFromHandle)
				{
					Type type = EnumType;
					object obj = (long)(IntPtr)type - (long)(IntPtr)_enumType;
					bool flag = obj == null;
					bool flag2 = (object)_enumType == null;
					return flag2 || flag;
				}
			}
			return true;
		}

		[Token(Token = "0x60001D8")]
		[Address(RVA = "0xCA4D64", Offset = "0xCA4D64", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EA4CB0]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023543]) = v38;\nL_0016:\n\tv42 = new HutongGames.PlayMaker.FsmEnum();\n\tv42.parsedIntValue = 0xFFFFFFFF;\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v42);\n\tHutongGames.PlayMaker.FsmEnum::set_Value(v42, value);\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator FsmEnum(Enum value)
		{
			FsmEnum fsmEnum = (FsmEnum)new NamedVariable();
			fsmEnum.parsedIntValue = -1;
			fsmEnum.Value = value;
			return fsmEnum;
		}
	}
}
