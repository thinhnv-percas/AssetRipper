using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	[Token(Token = "0x2000055")]
	public class FsmColor : NamedVariable
	{
		[SerializeField]
		[Token(Token = "0x400015F")]
		[FieldOffset(Offset = "0x38")]
		public Color value;

		[Token(Token = "0x1700006B")]
		public Color Value
		{
			[Token(Token = "0x60001B6")]
			[Address(RVA = "0xCA3D08", Offset = "0xCA3D08", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.value;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return value;
			}
			[Token(Token = "0x60001B7")]
			[Address(RVA = "0xCA3D14", Offset = "0xCA3D14", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.value = value;\n\tthis.value.g = value.g;\n\tthis.value.b = value.b;\n\tthis.value.a = value.a;\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				this.value = value;
				this.value.g = value.g;
				this.value.b = value.b;
				this.value.a = value.a;
			}
		}

		[Token(Token = "0x1700006C")]
		public override object RawValue
		{
			[Token(Token = "0x60001B8")]
			[Address(RVA = "0xCA3D20", Offset = "0xCA3D20", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1F0F950]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023532]) = v38;\nL_0014:\n\tv40 = this.value;\n\t// 25 Box returnVal1 @ X0_v3 (System.Object), typeof(UnityEngine.Color), &v40 @ V0_v1 (UnityEngine.Color)\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Color color = value;
				return color;
			}
			[Token(Token = "0x60001B9")]
			[Address(RVA = "0xCA3D84", Offset = "0xCA3D84", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EA9010]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023533]) = v41;\n\tv59 = v59_asT == 0;\n\tif (v59) goto L_0039;\n\tv62 = \"il2cpp_vm_object_unbox\"(value, UnityEngine.Color, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tthis.value.r = *([v62 @ X0_v7]);\n\tthis.value.g = *([v62 @ X0_v7+4]);\n\tthis.value.a = *([v62 @ X0_v7+C]);\n\treturn;\n\tv61 = new System.NullReferenceException();\nL_0039:\n\tthrow System.InvalidCastException;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0054: Expected F4, but got O
				//IL_006b: Expected F4, but got I
				//IL_0082: Expected F4, but got I
				if (((Color)((value is Color) ? value : null)).r != 0f)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					object obj = default(object);
					this.value.r = (float)obj;
					ref Color reference = ref this.value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X0_v7+4]");
					reference.g = 0f;
					ref Color reference2 = ref this.value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X0_v7+C]");
					reference2.a = 0f;
					return;
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x1700006D")]
		public override VariableType VariableType
		{
			[Token(Token = "0x60001BF")]
			[Address(RVA = "0xCA3F68", Offset = "0xCA3F68", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 7;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return VariableType.Color;
			}
		}

		[Token(Token = "0x60001BA")]
		[Address(RVA = "0xCA3E20", Offset = "0xCA3E20", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Color::get_black();\n\tthis.value = v11;\n\tthis.value.g = v11.g;\n\tthis.value.b = v11.b;\n\tthis.value.a = v11.a;\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this);\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmColor()
		{
			Color color = (value = Color.black);
			value.g = color.g;
			value.b = color.b;
			value.a = color.a;
		}

		[Token(Token = "0x60001BB")]
		[Address(RVA = "0xCA3E54", Offset = "0xCA3E54", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = UnityEngine.Color::get_black();\n\tthis.value = v15;\n\tthis.value.g = v15.g;\n\tthis.value.b = v15.b;\n\tthis.value.a = v15.a;\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this, name);\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmColor(string name)
		{
			Color color = (value = Color.black);
			value.g = color.g;
			value.b = color.b;
			value.a = color.a;
			base._002Ector(name);
		}

		[Token(Token = "0x60001BC")]
		[Address(RVA = "0xCA3E90", Offset = "0xCA3E90", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = UnityEngine.Color::get_black();\n\tthis.value = v15;\n\tthis.value.g = v15.g;\n\tthis.value.b = v15.b;\n\tthis.value.a = v15.a;\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this, source);\n\tv22 = source == 0;\n\tif (v22) goto L_001E;\n\tthis.value = source.value;\nL_001E:\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmColor(FsmColor source)
		{
			Color color = (value = Color.black);
			value.g = color.g;
			value.b = color.b;
			value.a = color.a;
			base._002Ector(source);
			if (source != null)
			{
				value = source.value;
			}
		}

		[Token(Token = "0x60001BD")]
		[Address(RVA = "0xCA3EDC", Offset = "0xCA3EDC", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EB10E8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023534]) = v38;\nL_0016:\n\tv42 = new HutongGames.PlayMaker.FsmColor();\n\tHutongGames.PlayMaker.FsmColor::.ctor(v42, this);\n\treturn v42;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override NamedVariable Clone()
		{
			return new FsmColor(this);
		}

		[Token(Token = "0x60001BE")]
		[Address(RVA = "0xCA3F3C", Offset = "0xCA3F3C", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Color::get_white();\n\tthis.value = v11;\n\tthis.value.g = v11.g;\n\tthis.value.b = v11.b;\n\tthis.value.a = v11.a;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Clear()
		{
			Color color = (value = Color.white);
			value.g = color.g;
			value.b = color.b;
			value.a = color.a;
		}

		[Token(Token = "0x60001C0")]
		[Address(RVA = "0xCA3F70", Offset = "0xCA3F70", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x38;\n\treturnVal1 = 0x10105BC(v0, 0, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			//IL_000c: Expected O, but got I
			object obj = (long)(IntPtr)this + 56L;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10105BC (inside UnityEngine.ClassLibraryInitializer::Init +0x28)");
			string result = default(string);
			return result;
		}

		[Token(Token = "0x60001C1")]
		[Address(RVA = "0xCA3F7C", Offset = "0xCA3F7C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv32 = *([1EEBFF0]);\n\tv33 = *([v32 @ X8_v8]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, v35, v36, v37, v38, v39, v40, v41, value, v0, v2, v3, v42, v43, v44, v45);\n\tv49 = 0 | 1;\n\t*([2023535]) = v49;\nL_0025:\n\tv58 = new HutongGames.PlayMaker.FsmColor();\n\tHutongGames.PlayMaker.FsmColor::.ctor(v58, v54.Empty);\n\tv58.value = value;\n\tv58.value.g = value.g;\n\tv58.value.b = value.b;\n\tv58.value.a = value.a;\n\treturn v58;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator FsmColor(Color value)
		{
			FsmColor fsmColor = new FsmColor(string.Empty);
			fsmColor.value = value;
			fsmColor.value.g = value.g;
			fsmColor.value.b = value.b;
			fsmColor.value.a = value.a;
			return fsmColor;
		}
	}
}
