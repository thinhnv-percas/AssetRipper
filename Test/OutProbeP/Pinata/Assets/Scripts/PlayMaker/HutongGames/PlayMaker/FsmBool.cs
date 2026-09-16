using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	[Token(Token = "0x2000054")]
	public class FsmBool : NamedVariable
	{
		[SerializeField]
		[Token(Token = "0x400015E")]
		[FieldOffset(Offset = "0x38")]
		public bool value;

		[Token(Token = "0x17000068")]
		public bool Value
		{
			[Token(Token = "0x60001A9")]
			[Address(RVA = "0xCA3A18", Offset = "0xCA3A18", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = HutongGames.PlayMaker.NamedVariable::get_CastVariable(this);\n\tv12 = v11 == 0;\n\tif (v12) goto L_0026;\n\tv15 = HutongGames.PlayMaker.NamedVariable::get_CastVariable(this);\n\tv63 = HutongGames.PlayMaker.NamedVariable::ToInt(v15);\n\tv45 = v63 < 0;\n\tv43 = v63 == 0;\n\tv39 = v63 ^ v63;\n\tv37 = v63 & v39;\n\tv35 = v37 < 0;\n\tv79 = v45 == v35;\n\tv31 = ~v43;\n\tv33 = v79 & v31;\n\tgoto L_0031;\nL_0026:\n\tv21 = this.value == 0;\n\tv26 = ~v21;\nL_0031:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				NamedVariable castVariable = base.CastVariable;
				if (castVariable != null)
				{
					NamedVariable castVariable2 = base.CastVariable;
					int num = castVariable2.ToInt();
					bool flag = num < 0;
					bool flag2 = num == 0;
					int num2 = num ^ num;
					int num3 = num & num2;
					bool flag3 = num3 < 0;
					bool flag4 = flag == flag3;
					bool flag5 = !flag2;
					return flag4 && flag5;
				}
				bool flag6 = !value;
				return !flag6;
			}
			[Token(Token = "0x60001AA")]
			[Address(RVA = "0xCA3A7C", Offset = "0xCA3A7C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.value = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				this.value = value;
			}
		}

		[Token(Token = "0x17000069")]
		public override object RawValue
		{
			[Token(Token = "0x60001AB")]
			[Address(RVA = "0xCA3A88", Offset = "0xCA3A88", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EBDC78]);\n\tv19 = *([v18 @ X8_v5]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202352E]) = v38;\nL_0014:\n\tv40 = this.value;\n\t// 25 Box returnVal1 @ X0_v3 (System.Object), typeof(System.Boolean), &v40 @ X8_v3 (System.Boolean)\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				bool flag = value;
				return flag;
			}
			[Token(Token = "0x60001AC")]
			[Address(RVA = "0xCA3AEC", Offset = "0xCA3AEC", Length = "0x8C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EE0430]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202352F]) = v41;\n\tv59 = ~v59_asT;\n\tif (v59) goto L_0035;\n\tv62 = \"il2cpp_vm_object_unbox\"(value, System.Boolean, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tthis.value = *([v62 @ X0_v7]);\n\treturn;\n\tv61 = new System.NullReferenceException();\nL_0035:\n\tthrow System.InvalidCastException;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0012: Expected I4, but got O
				//IL_0044: Expected I4, but got O
				if ((int)((value is bool) ? value : null) != 0)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					object obj = default(object);
					this.value = (byte)(int)obj != 0;
					return;
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x1700006A")]
		public override VariableType VariableType
		{
			[Token(Token = "0x60001B1")]
			[Address(RVA = "0xCA3C2C", Offset = "0xCA3C2C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 2;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return VariableType.Bool;
			}
		}

		[Token(Token = "0x60001AD")]
		[Address(RVA = "0xCA3B78", Offset = "0xCA3B78", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmBool()
		{
		}

		[Token(Token = "0x60001AE")]
		[Address(RVA = "0xCA3B80", Offset = "0xCA3B80", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this, name);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmBool(string name)
			: base(name)
		{
		}

		[Token(Token = "0x60001AF")]
		[Address(RVA = "0xCA3B88", Offset = "0xCA3B88", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this, source);\n\tv15 = source == 0;\n\tif (v15) goto L_0013;\n\tthis.value = source.value;\nL_0013:\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmBool(FsmBool source)
			: base(source)
		{
			if (source != null)
			{
				value = source.value;
			}
		}

		[Token(Token = "0x60001B0")]
		[Address(RVA = "0xCA3BBC", Offset = "0xCA3BBC", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1F08238]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023530]) = v38;\nL_0016:\n\tv42 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v42, this);\n\tv46 = this == 0;\n\tif (v46) goto L_0025;\n\tv42.value = this.value;\nL_0025:\n\treturn v42;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override NamedVariable Clone()
		{
			FsmBool fsmBool = (FsmBool)new NamedVariable(this);
			if (this != null)
			{
				fsmBool.value = value;
			}
			return fsmBool;
		}

		[Token(Token = "0x60001B2")]
		[Address(RVA = "0xCA3C34", Offset = "0xCA3C34", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = &v5 @ stack_-10_v2;\n\tv6 = HutongGames.PlayMaker.FsmBool::get_Value(this);\n\tv10 = &v5 @ stack_-10_v2 - 4;\n\t*([v4 @ X29_v1-4]) = v6;\n\treturnVal1 = 0xE8F14C(v10, 0, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26);\n\treturn returnVal1;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			//IL_0021: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			bool flag = Value;
			object obj3 = (long)(IntPtr)obj2 - 4L;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E8F14C (inside System.BitConverter::.cctor +0x64)");
			string result = default(string);
			return result;
		}

		[Token(Token = "0x60001B3")]
		[Address(RVA = "0xCA3C64", Offset = "0xCA3C64", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.value;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override int ToInt()
		{
			return value ? 1 : 0;
		}

		[Token(Token = "0x60001B4")]
		[Address(RVA = "0xCA3C6C", Offset = "0xCA3C6C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.value = 0;\n\treturn;\n")]
		public override void Clear()
		{
			value = false;
		}

		[Token(Token = "0x60001B5")]
		[Address(RVA = "0xCA3C74", Offset = "0xCA3C74", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv20 = *([1EC4B58]);\n\tv21 = *([v20 @ X8_v10]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023531]) = v40;\nL_001C:\n\tv49 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v49, v45.Empty);\n\tv49.value = value;\n\treturn v49;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator FsmBool(bool value)
		{
			FsmBool fsmBool = (FsmBool)new NamedVariable(string.Empty);
			fsmBool.value = value;
			return fsmBool;
		}
	}
}
