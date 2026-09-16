using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using LunarConsolePluginInternal;

namespace LunarConsolePlugin
{
	[Token(Token = "0x2000007")]
	public class CVar : IEquatable<CVar>, IComparable<CVar>
	{
		[Token(Token = "0x4000010")]
		private static int s_nextId;

		[Token(Token = "0x4000011")]
		[FieldOffset(Offset = "0x10")]
		private readonly int m_id;

		[Token(Token = "0x4000012")]
		[FieldOffset(Offset = "0x18")]
		private readonly string m_name;

		[Token(Token = "0x4000013")]
		[FieldOffset(Offset = "0x20")]
		private readonly CVarType m_type;

		[Token(Token = "0x4000014")]
		[FieldOffset(Offset = "0x24")]
		private readonly CFlags m_flags;

		[Token(Token = "0x4000015")]
		[FieldOffset(Offset = "0x28")]
		internal CValue m_value;

		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x38")]
		internal CValue m_defaultValue;

		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x48")]
		internal CVarValueRange m_range;

		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0x50")]
		private CVarChangedDelegateList m_delegateList;

		[Token(Token = "0x17000002")]
		public int Id
		{
			[Token(Token = "0x6000014")]
			[Address(RVA = "0x13D4AD0", Offset = "0x13D4AD0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_id;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Id;
			}
		}

		[Token(Token = "0x17000003")]
		public string Name
		{
			[Token(Token = "0x6000015")]
			[Address(RVA = "0x13D4AD8", Offset = "0x13D4AD8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_name;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Name;
			}
		}

		[Token(Token = "0x17000004")]
		public CVarType Type
		{
			[Token(Token = "0x6000016")]
			[Address(RVA = "0x13D4AE0", Offset = "0x13D4AE0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_type;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Type;
			}
		}

		[Token(Token = "0x17000005")]
		public string DefaultValue
		{
			[Token(Token = "0x6000017")]
			[Address(RVA = "0x13D4AE8", Offset = "0x13D4AE8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_defaultValue;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return (string)m_defaultValue;
			}
		}

		[Token(Token = "0x17000006")]
		public bool IsString
		{
			[Token(Token = "0x6000018")]
			[Address(RVA = "0x13D4AF0", Offset = "0x13D4AF0", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this.m_type - 3;\n\tv6 = v4 == 0;\n\treturn v6;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				int num = (int)(Type - 3);
				return num == 0;
			}
		}

		[Token(Token = "0x17000007")]
		public string Value
		{
			[Token(Token = "0x6000019")]
			[Address(RVA = "0x13D4B00", Offset = "0x13D4B00", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_value;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return (string)m_value;
			}
			[Token(Token = "0x600001A")]
			[Address(RVA = "0x13D43AC", Offset = "0x13D43AC", Length = "0xD8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1ECD008]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028A52]) = v41;\nL_0018:\n\tv45 = System.String::op_Inequality(this.m_value, value);\n\tthis.m_value.stringValue = value;\n\tv48 = this.m_type < 3;\n\tv49 = ~v48;\n\tif (v49) goto L_0050;\n\tgoto L_0034;\n\tv63 = *([v59 @ X0_v8+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_0034;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v59, v43, v44, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0034:\n\tv72 = LunarConsolePluginInternal.StringUtils::ParseFloat(value, 0f);\n\tthis.m_value.floatValue = v72;\n\tv99 = this.m_type < 2;\n\tv92 = ~v99;\n\tv90 = this.m_type - 2;\n\tv86 = v90 == 0;\n\tv100 = ~v86;\n\tv75 = v92 & v100;\n\tif (v75) goto L_0051;\n\tthis.m_value.intValue = v72;\n\tv141 = v45 == 0;\n\tv113 = ~v141;\n\tif (v113) goto L_005C;\nL_004F:\n\treturn;\nL_0050:\n\tthis.m_value.floatValue = 0f;\nL_0051:\n\tthis.m_value.intValue = 0;\n\tv98 = v45 == 0;\n\tif (v98) goto L_004F;\nL_005C:\n\tLunarConsolePlugin.CVar::NotifyValueChanged(this);\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_009b: Expected I4, but got F4
				bool flag = (string)m_value != value;
				m_value.stringValue = value;
				if (Type < CVarType.String)
				{
					float num = StringUtils.ParseFloat(value, 0f);
					m_value.floatValue = num;
					bool flag2 = Type < CVarType.Float;
					bool flag3 = !flag2;
					int num2 = (int)(Type - 2);
					bool flag4 = num2 == 0;
					bool flag5 = !flag4;
					if (!(flag3 && flag5))
					{
						m_value.intValue = (int)num;
						if (!flag)
						{
							return;
						}
						goto IL_00d9;
					}
				}
				else
				{
					m_value.floatValue = 0f;
				}
				m_value.intValue = 0;
				if (!flag)
				{
					return;
				}
				goto IL_00d9;
				IL_00d9:
				NotifyValueChanged();
			}
		}

		[Token(Token = "0x17000008")]
		public CVarValueRange Range
		{
			[Token(Token = "0x600001B")]
			[Address(RVA = "0x13D4B90", Offset = "0x13D4B90", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_range;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return m_range;
			}
			[Token(Token = "0x600001C")]
			[Address(RVA = "0x13D4B98", Offset = "0x13D4B98", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_range = value;\n\tthis.m_range.max = value.max;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_range = value;
				m_range.max = value.max;
			}
		}

		[Token(Token = "0x17000009")]
		public bool HasRange
		{
			[Token(Token = "0x600001D")]
			[Address(RVA = "0x13D4BA0", Offset = "0x13D4BA0", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x48;\n\tgoto L_000A;\nL_000A:\n\tv13 = System.Single::IsNaN(*([v0 @ X0_v1]));\n\tv15 = v13 == 0;\n\tif (v15) goto L_0012;\n\tgoto L_0016;\nL_0012:\n\tv19 = System.Single::IsNaN(*([v0 @ X0_v1+4]));\n\tv20 = v19 ^ 1;\nL_0016:\n\treturnVal1 = v20 & 1;\n\treturn returnVal1;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000c: Expected O, but got I
				//IL_001a: Expected F4, but got O
				//IL_005a: Expected F4, but got I
				object obj = (long)(IntPtr)this + 72L;
				int num;
				if (float.IsNaN((float)obj))
				{
					num = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X0_v1+4]");
					bool flag = float.IsNaN(0f);
					num = (flag ? 1 : 0) ^ 1;
				}
				return (byte)(num & 1) != 0;
			}
		}

		[Token(Token = "0x1700000A")]
		public bool IsInt
		{
			[Token(Token = "0x600001E")]
			[Address(RVA = "0x13D4B08", Offset = "0x13D4B08", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.m_type < 2;\n\tv3 = ~v2;\n\tv11 = ~v3;\n\treturn v11;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				bool flag = Type < CVarType.Float;
				bool flag2 = !flag;
				return !flag2;
			}
		}

		[Token(Token = "0x1700000B")]
		public int IntValue
		{
			[Token(Token = "0x600001F")]
			[Address(RVA = "0x13D4BF0", Offset = "0x13D4BF0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_value.intValue;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return m_value.intValue;
			}
			[Token(Token = "0x6000020")]
			[Address(RVA = "0x13D41A4", Offset = "0x13D41A4", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EA8038]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028A53]) = v41;\nL_001C:\n\tgoto L_0025;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0025;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0025:\n\tv59 = 0xDC3560(&value @ X1 (System.Int32), 0, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv65 = this.m_value.intValue == value;\n\tthis.m_value.stringValue = v59;\n\tthis.m_value.intValue = value;\n\tthis.m_value.floatValue = value;\n\tif (v65) goto L_003C;\n\tLunarConsolePlugin.CVar::NotifyValueChanged(this);\nL_003C:\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
				bool flag = m_value.intValue == value;
				string stringValue = default(string);
				m_value.stringValue = stringValue;
				m_value.intValue = value;
				m_value.floatValue = value;
				if (!flag)
				{
					NotifyValueChanged();
				}
			}
		}

		[Token(Token = "0x1700000C")]
		public bool IsFloat
		{
			[Token(Token = "0x6000021")]
			[Address(RVA = "0x13D4B18", Offset = "0x13D4B18", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this.m_type - 2;\n\tv6 = v4 == 0;\n\treturn v6;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				int num = (int)(Type - 2);
				return num == 0;
			}
		}

		[Token(Token = "0x1700000D")]
		public float FloatValue
		{
			[Token(Token = "0x6000022")]
			[Address(RVA = "0x13D4B88", Offset = "0x13D4B88", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_value.floatValue;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return m_value.floatValue;
			}
			[Token(Token = "0x6000023")]
			[Address(RVA = "0x13D42CC", Offset = "0x13D42CC", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv24 = *([1ED16B8]);\n\tv25 = *([v24 @ X8_v10]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, value, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2028A54]) = v43;\nL_001D:\n\tgoto L_0024;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<LunarConsolePluginInternal.StringUtils>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0024;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, value, v34, v35, v36, v37, v38, v39, v40);\nL_0024:\n\tv59 = LunarConsolePluginInternal.StringUtils::ToString(value);\n\tv65 = this.m_value.floatValue == value;\n\tthis.m_value.stringValue = v59;\n\tthis.m_value.intValue = value;\n\tthis.m_value.floatValue = value;\n\tif (v65) goto L_0044;\n\tLunarConsolePlugin.CVar::NotifyValueChanged(this);\n\treturn;\nL_0044:\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0047: Expected I4, but got F4
				string stringValue = StringUtils.ToString(value);
				bool flag = m_value.floatValue == value;
				m_value.stringValue = stringValue;
				m_value.intValue = (int)value;
				m_value.floatValue = value;
				if (!flag)
				{
					NotifyValueChanged();
				}
			}
		}

		[Token(Token = "0x1700000E")]
		public bool IsBool
		{
			[Token(Token = "0x6000024")]
			[Address(RVA = "0x13D4C78", Offset = "0x13D4C78", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.m_type == 0;\n\treturn v6;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Type == CVarType.Boolean;
			}
		}

		[Token(Token = "0x1700000F")]
		public bool BoolValue
		{
			[Token(Token = "0x6000025")]
			[Address(RVA = "0x13D4C88", Offset = "0x13D4C88", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.m_value.intValue == 0;\n\tv11 = ~v6;\n\treturn v11;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				bool flag = m_value.intValue == 0;
				return !flag;
			}
			[Token(Token = "0x6000026")]
			[Address(RVA = "0x13D4C98", Offset = "0x13D4C98", Length = "0x18")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tLunarConsolePlugin.CVar::set_IntValue(this, value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				IntValue = (value ? 1 : 0);
			}
		}

		[Token(Token = "0x17000010")]
		public bool IsDefault
		{
			[Token(Token = "0x6000027")]
			[Address(RVA = "0x13D4CB0", Offset = "0x13D4CB0", Length = "0xBC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EC20A0]);\n\tv21 = *([v20 @ X8_v8]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2028A55]) = v40;\nL_0015:\n\tv42 = this.m_defaultValue;\n\tv47 = this + 0x28;\n\t// 29 Box v50 @ X0_v3, typeof(LunarConsolePlugin.CValue), &v42 @ X8_v3 (LunarConsolePlugin.CValue)\n\t// 34 Box v55 @ X0_v5, typeof(LunarConsolePlugin.CValue), v47 @ X19_v2\n\tv42 = *([v55 @ X0_v5]);\n\t*([v42 @ X8_v3 (LunarConsolePlugin.CValue)+130])(v63, v55, v50, *([v42 @ X8_v3 (LunarConsolePlugin.CValue)+138]), v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv66 = \"il2cpp_vm_object_unbox\"(v55, v50, *([v42 @ X8_v3 (LunarConsolePlugin.CValue)+138]), v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturnVal1 = v63 & 1;\n\tthis.m_value = *([v66 @ X0_v10]);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0055: Expected O, but got I
				CValue defaultValue = m_defaultValue;
				object obj = (long)(IntPtr)this + 40L;
				object obj2 = defaultValue;
				object obj3 = (CValue)obj;
				defaultValue = (CValue)obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v42 @ X8_v3 (LunarConsolePlugin.CValue)+130] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				object obj4 = default(object);
				bool result = (byte)((ulong)(long)(IntPtr)obj4 & 1uL) != 0;
				object value = default(object);
				m_value = (CValue)value;
				return result;
			}
			[Token(Token = "0x6000028")]
			[Address(RVA = "0x13D4D6C", Offset = "0x13D4D6C", Length = "0x44")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = LunarConsolePlugin.CVar::get_IsDefault(this);\n\tv17 = v14 ^ value;\n\tthis.m_value = this.m_defaultValue;\n\tthis.m_value.intValue = this.m_defaultValue.intValue;\n\tv19 = v17 == 0;\n\tif (v19) goto L_001E;\n\tLunarConsolePlugin.CVar::NotifyValueChanged(this);\n\treturn;\nL_001E:\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				bool isDefault = IsDefault;
				bool flag = isDefault ^ value;
				m_value = m_defaultValue;
				m_value.intValue = m_defaultValue.intValue;
				if (flag)
				{
					NotifyValueChanged();
				}
			}
		}

		[Token(Token = "0x17000011")]
		public CFlags Flags
		{
			[Token(Token = "0x600002A")]
			[Address(RVA = "0x13D4DC0", Offset = "0x13D4DC0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_flags;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Flags;
			}
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x13D4058", Offset = "0x13D4058", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tLunarConsolePlugin.CVar::.ctor(this, name, 0, flags);\n\tLunarConsolePlugin.CVar::set_IntValue(this, defaultValue);\n\tthis.m_defaultValue = this.m_value;\n\tthis.m_defaultValue.intValue = this.m_value.intValue;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CVar(string name, bool defaultValue, CFlags flags = CFlags.None)
			: this(name, default(CVarType), flags)
		{
			IntValue = (defaultValue ? 1 : 0);
			m_defaultValue = m_value;
			m_defaultValue.intValue = m_value.intValue;
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x13D4244", Offset = "0x13D4244", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tLunarConsolePlugin.CVar::.ctor(this, name, 1, flags);\n\tLunarConsolePlugin.CVar::set_IntValue(this, defaultValue);\n\tthis.m_defaultValue = this.m_value;\n\tthis.m_defaultValue.intValue = this.m_value.intValue;\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CVar(string name, int defaultValue, CFlags flags = CFlags.None)
			: this(name, CVarType.Integer, flags)
		{
			IntValue = defaultValue;
			m_defaultValue = m_value;
			m_defaultValue.intValue = m_value.intValue;
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x13D4280", Offset = "0x13D4280", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tLunarConsolePlugin.CVar::.ctor(this, name, 2, flags);\n\tLunarConsolePlugin.CVar::set_FloatValue(this, defaultValue);\n\tthis.m_defaultValue = this.m_value;\n\tthis.m_defaultValue.intValue = this.m_value.intValue;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CVar(string name, float defaultValue, CFlags flags = CFlags.None)
			: this(name, CVarType.Float, flags)
		{
			FloatValue = defaultValue;
			m_defaultValue = m_value;
			m_defaultValue.intValue = m_value.intValue;
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x13D4370", Offset = "0x13D4370", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tLunarConsolePlugin.CVar::.ctor(this, name, 3, flags);\n\tLunarConsolePlugin.CVar::set_Value(this, defaultValue);\n\tthis.m_defaultValue = this.m_value;\n\tthis.m_defaultValue.intValue = this.m_value.intValue;\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CVar(string name, string defaultValue, CFlags flags = CFlags.None)
			: this(name, CVarType.String, flags)
		{
			Value = defaultValue;
			m_defaultValue = m_value;
			m_defaultValue.intValue = m_value.intValue;
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x13D40A0", Offset = "0x13D40A0", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv30 = *([1F02B60]);\n\tv31 = *([v30 @ X8_v20]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, name, type, flags, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2028A50]) = v47;\n\tgoto L_0026;\n\tv54 = *([v50 @ X0_v2 (Il2CppClass<LunarConsolePlugin.CVarValueRange>)+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0026;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v50, name, type, flags, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv58 = LunarConsolePlugin.CVarValueRange;\nL_0026:\n\tv61 = *([v57 @ X0_v3 (Il2CppClass<LunarConsolePlugin.CVarValueRange>)+B8]);\n\tthis.m_range = v61.Undefined;\n\tthis.m_range.max = *([v61 @ X8_v5 (Il2CppStaticFields<LunarConsolePlugin.CVarValueRange>)+4]);\n\tSystem.Object::.ctor(this);\n\tv67 = name == 0;\n\tif (v67) goto L_0047;\n\tv73 = v71.s_nextId + 1;\n\tv71.s_nextId = v73;\n\tthis.m_id = v73;\n\tthis.m_name = name;\n\tthis.m_type = type;\n\tthis.m_flags = flags;\n\treturn;\nL_0047:\n\tv84 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v84, \"name\");\n\tthrow v84;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private CVar(string name, CVarType type, CFlags flags)
		{
			//IL_0073: Expected I, but got O
			//IL_0081: Expected I, but got O
			//IL_00a3: Expected F4, but got I
			base._002Ector();
			IntPtr intPtr = (IntPtr)typeof(CVarValueRange);
			IntPtr intPtr2 = (IntPtr)CVarValueRange.Undefined;
			m_range = CVarValueRange.Undefined;
			ref CVarValueRange range = ref m_range;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ X8_v5 (Il2CppStaticFields<LunarConsolePlugin.CVarValueRange>)+4]");
			range.max = 0f;
			if (name != null)
			{
				m_id = ++s_nextId;
				m_name = name;
				m_type = type;
				m_flags = flags;
				return;
			}
			ArgumentNullException ex = new ArgumentNullException("name");
			throw ex;
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x13D4484", Offset = "0x13D4484", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ECB530]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, del, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028A51]) = v41;\nL_0015:\n\tv42 = del == 0;\n\tif (v42) goto L_0047;\n\tv44 = this.m_delegateList == 0;\n\tif (v44) goto L_002C;\n\tv53 = LunarConsolePluginInternal.BaseList`1<LunarConsolePlugin.CVarChangedDelegate>::Contains(this.m_delegateList, del);\n\tv55 = v53 == 0;\n\tif (v55) goto L_0036;\n\treturn;\nL_002C:\n\tv94 = new LunarConsolePlugin.CVarChangedDelegateList();\n\tLunarConsolePlugin.CVarChangedDelegateList::.ctor(v94, 1);\n\tthis.m_delegateList = v94;\n\tv105 = *([v94 @ X0_v11 (LunarConsolePlugin.CVarChangedDelegateList)]);\n\tgoto L_003A;\nL_0036:\n\tv94 = this.m_delegateList;\n\tv105 = *([v94 @ X0_v11 (LunarConsolePlugin.CVarChangedDelegateList)]);\nL_003A:\n\tv81 = *([v105 @ X8_v11 (Il2CppClass<LunarConsolePlugin.CVarChangedDelegateList>)+170]);\n\tv85 = *([v105 @ X8_v11 (Il2CppClass<LunarConsolePlugin.CVarChangedDelegateList>)+178]);\n\t// 67 IndirectJump v81 @ X3_v1, v94 @ X0_v11 (LunarConsolePlugin.CVarChangedDelegateList), v94 @ X0_v11 (LunarConsolePlugin.CVarChangedDelegateList), del @ X1 (LunarConsolePlugin.CVarChangedDelegate), v85 @ X2_v6, v81 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\nL_0047:\n\tv48 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v48, \"del\");\n\tthrow v48;\n\tthrow System.NullReferenceException;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddDelegate(CVarChangedDelegate del)
		{
			//IL_0080: Expected I, but got O
			//IL_00e7: Expected O, but got I
			//IL_00f7: Expected O, but got I
			//IL_009c: Expected I, but got O
			if (del != null)
			{
				if (m_delegateList != null)
				{
					if (m_delegateList.Contains(del))
					{
						return;
					}
					CVarChangedDelegateList delegateList = m_delegateList;
					IntPtr intPtr = (IntPtr)delegateList;
				}
				else
				{
					IntPtr intPtr = (IntPtr)(m_delegateList = new CVarChangedDelegateList(1));
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ X8_v11 (Il2CppClass<LunarConsolePlugin.CVarChangedDelegateList>)+170]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ X8_v11 (Il2CppClass<LunarConsolePlugin.CVarChangedDelegateList>)+178]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v81 @ X3_v1 (should have been resolved before IL gen)");
				return;
			}
			ArgumentNullException ex = new ArgumentNullException("del");
			throw ex;
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x13D461C", Offset = "0x13D461C", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = del == 0;\n\tif (v10) goto L_001E;\n\tv13 = this.m_delegateList == 0;\n\tif (v13) goto L_001E;\n\tv34 = LunarConsolePluginInternal.BaseList`1<LunarConsolePlugin.CVarChangedDelegate>::Remove(this.m_delegateList, del);\n\tv26 = LunarConsolePluginInternal.BaseList`1<LunarConsolePlugin.CVarChangedDelegate>::get_Count(this.m_delegateList);\n\tv60 = v26 == 0;\n\tv28 = ~v60;\n\tif (v28) goto L_001E;\n\tthis.m_delegateList = 0;\nL_001E:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RemoveDelegate(CVarChangedDelegate del)
		{
			if (del != null && m_delegateList != null)
			{
				bool flag = m_delegateList.Remove(del);
				if (m_delegateList.Count == 0)
				{
					m_delegateList = null;
				}
			}
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x13D4670", Offset = "0x13D4670", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = target == 0;\n\tif (v16) goto L_004B;\n\tv18 = this.m_delegateList == 0;\n\tif (v18) goto L_004B;\n\tv74 = LunarConsolePluginInternal.BaseList`1<LunarConsolePlugin.CVarChangedDelegate>::get_Count(this.m_delegateList);\n\tv60 = this.m_delegateList;\n\tv114 = v74 - 1;\nL_0017:\n\tv180 = v114 & 0x80000000;\n\tv181 = v180 == 0;\n\tv182 = ~v181;\n\tif (v182) goto L_0040;\n\tv190 = LunarConsolePluginInternal.BaseList`1<LunarConsolePlugin.CVarChangedDelegate>::Get(v60, v114);\n\tv130 = v190.m_target != target;\n\tif (v130) goto L_0037;\n\tv202 = LunarConsolePluginInternal.BaseList`1<LunarConsolePlugin.CVarChangedDelegate>::RemoveAt(this.m_delegateList, v114);\nL_0037:\n\tv114 = v114 - 1;\n\tv204 = this.m_delegateList == 0;\n\tv161 = ~v204;\n\tif (v161) goto L_0017;\n\tthrow System.NullReferenceException;\nL_0040:\n\tv63 = LunarConsolePluginInternal.BaseList`1<LunarConsolePlugin.CVarChangedDelegate>::get_Count(v60);\n\tv188 = v63 == 0;\n\tv65 = ~v188;\n\tif (v65) goto L_004B;\n\tthis.m_delegateList = 0;\nL_004B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RemoveDelegates(object target)
		{
			//IL_0157: Expected I4, but got I8
			if (target == null || m_delegateList == null)
			{
				return;
			}
			int count = m_delegateList.Count;
			CVarChangedDelegateList delegateList = m_delegateList;
			int num = count - 1;
			while ((int)(num & 0x80000000L) == 0)
			{
				CVarChangedDelegate cVarChangedDelegate = delegateList.Get(num);
				if (cVarChangedDelegate.Target == target)
				{
					m_delegateList.RemoveAt(num);
				}
				num--;
				bool flag = m_delegateList == null;
				bool flag2 = !flag;
				delegateList = m_delegateList;
				if (!flag2)
				{
					throw new NullReferenceException();
				}
			}
			if (delegateList.Count == 0)
			{
				m_delegateList = null;
			}
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0x13D4728", Offset = "0x13D4728", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.m_delegateList == 0;\n\tif (v11) goto L_0027;\n\tv15 = LunarConsolePluginInternal.BaseList`1<LunarConsolePlugin.CVarChangedDelegate>::get_Count(this.m_delegateList);\n\tv40 = v15 < 1;\n\tif (v40) goto L_0027;\n\tLunarConsolePlugin.CVarChangedDelegateList::NotifyValueChanged(this.m_delegateList, this);\n\treturn;\nL_0027:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void NotifyValueChanged()
		{
			if (m_delegateList != null)
			{
				int count = m_delegateList.Count;
				if (count >= 1)
				{
					m_delegateList.NotifyValueChanged(this);
				}
			}
		}

		[Token(Token = "0x6000012")]
		[Address(RVA = "0x13D4A34", Offset = "0x13D4A34", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = other == 0;\n\tif (v14) goto L_FFFFFFFF;\n\tv18 = System.String::op_Equality(other.m_name, this.m_name);\n\tv28 = v18 == 0;\n\tif (v28) goto L_FFFFFFFF;\n\tv72 = other + 0x28;\n\tv22 = this + 0x28;\n\tv25 = 0x13D401C(v72, v22, 0, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85);\n\tv86 = v25 & 1;\n\tv29 = v86 == 0;\n\tif (v29) goto L_FFFFFFFF;\n\tv87 = other + 0x38;\n\tv23 = this + 0x38;\n\tv26 = 0x13D401C(v87, v23, 0, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85);\n\tv88 = v26 & 1;\n\tv30 = v88 == 0;\n\tif (v30) goto L_FFFFFFFF;\n\tv53 = other.m_type - this.m_type;\n\tv47 = v53 == 0;\n\tgoto L_0030;\nL_0030:\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Equals(CVar other)
		{
			//IL_0061: Expected O, but got I
			//IL_006d: Expected O, but got I
			//IL_00b2: Expected O, but got I
			//IL_00be: Expected O, but got I
			if (other != null && other.Name == Name)
			{
				object obj = (long)(IntPtr)other + 40L;
				object obj2 = (long)(IntPtr)this + 40L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @13D401C");
				object obj3 = default(object);
				if ((uint)((ulong)(long)(IntPtr)obj3 & 1uL) != 0)
				{
					object obj4 = (long)(IntPtr)other + 56L;
					object obj5 = (long)(IntPtr)this + 56L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @13D401C");
					object obj6 = default(object);
					if ((uint)((ulong)(long)(IntPtr)obj6 & 1uL) != 0)
					{
						int num = other.Type - Type;
						return num == 0;
					}
				}
			}
			return false;
		}

		[Token(Token = "0x6000013")]
		[Address(RVA = "0x13D4AA4", Offset = "0x13D4AA4", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = System.String::CompareTo(this.m_name, other.m_name);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(CVar other)
		{
			return Name.CompareTo(other.Name);
		}

		[Token(Token = "0x6000029")]
		[Address(RVA = "0x13D4DB0", Offset = "0x13D4DB0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.m_flags & flag;\n\tv5 = v2 == 0;\n\tv8 = ~v5;\n\treturn v8;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool HasFlag(CFlags flag)
		{
			int num = (int)(Flags & flag);
			bool flag2 = num == 0;
			return !flag2;
		}

		[Token(Token = "0x600002B")]
		[Address(RVA = "0x13D4DC8", Offset = "0x13D4DC8", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn cvar.m_value;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator string(CVar cvar)
		{
			return (string)cvar.m_value;
		}

		[Token(Token = "0x600002C")]
		[Address(RVA = "0x13D4DE0", Offset = "0x13D4DE0", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn cvar.m_value.intValue;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator int(CVar cvar)
		{
			return cvar.m_value.intValue;
		}

		[Token(Token = "0x600002D")]
		[Address(RVA = "0x13D4DF8", Offset = "0x13D4DF8", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn cvar.m_value.floatValue;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator float(CVar cvar)
		{
			return cvar.m_value.floatValue;
		}

		[Token(Token = "0x600002E")]
		[Address(RVA = "0x13D4E10", Offset = "0x13D4E10", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = cvar.m_value.intValue == 0;\n\tv12 = ~v7;\n\treturn v12;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator bool(CVar cvar)
		{
			bool flag = cvar.m_value.intValue == 0;
			return !flag;
		}
	}
}
