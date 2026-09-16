using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	[Token(Token = "0x2000061")]
	public class FsmString : NamedVariable
	{
		[SerializeField]
		[Token(Token = "0x4000175")]
		[FieldOffset(Offset = "0x38")]
		private string value;

		[Token(Token = "0x1700008E")]
		public string Value
		{
			[Token(Token = "0x600023D")]
			[Address(RVA = "0xCB1E64", Offset = "0xCB1E64", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = HutongGames.PlayMaker.NamedVariable::get_CastVariable(this);\n\tv12 = v11 == 0;\n\tif (v12) goto L_001C;\n\tv15 = HutongGames.PlayMaker.NamedVariable::get_CastVariable(this);\n\tv27 = *([v15 @ X0_v4 (HutongGames.PlayMaker.NamedVariable)]);\n\tv22 = *([v27 @ X8_v1 (Il2CppClass<HutongGames.PlayMaker.NamedVariable>)+160]);\n\tv35 = *([v27 @ X8_v1 (Il2CppClass<HutongGames.PlayMaker.NamedVariable>)+168]);\n\t// 22 IndirectJump v22 @ X2_v1, v15 @ X0_v4 (HutongGames.PlayMaker.NamedVariable), v15 @ X0_v4 (HutongGames.PlayMaker.NamedVariable), v35 @ X1_v3, v22 @ X2_v1, v38 @ X3, v39 @ X4, v40 @ X5, v41 @ X6, v42 @ X7, v43 @ V0, v44 @ V1, v45 @ V2, v46 @ V3, v47 @ V4, v48 @ V5, v49 @ V6, v50 @ V7\nL_001C:\n\treturn this.value;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_003e: Expected I, but got O
				//IL_004e: Expected O, but got I
				//IL_005e: Expected O, but got I
				NamedVariable castVariable = base.CastVariable;
				if (castVariable != null)
				{
					NamedVariable castVariable2 = base.CastVariable;
					IntPtr intPtr = (IntPtr)castVariable2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ X8_v1 (Il2CppClass<HutongGames.PlayMaker.NamedVariable>)+160]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ X8_v1 (Il2CppClass<HutongGames.PlayMaker.NamedVariable>)+168]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v22 @ X2_v1 (should have been resolved before IL gen)");
				}
				return value;
			}
			[Token(Token = "0x600023E")]
			[Address(RVA = "0xCB5FCC", Offset = "0xCB5FCC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.value = value;\n\treturn;\n")]
			set
			{
				Value = value;
			}
		}

		[Token(Token = "0x1700008F")]
		public override object RawValue
		{
			[Token(Token = "0x600023F")]
			[Address(RVA = "0xCB5FD4", Offset = "0xCB5FD4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.value;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return value;
			}
			[Token(Token = "0x6000240")]
			[Address(RVA = "0xCB5FDC", Offset = "0xCB5FDC", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EAB1A8]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023658]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_0026;\n\tv56 = *([value @ X1 (System.Object)]) != System.String;\n\tif (v56) goto L_002F;\nL_0026:\n\tthis.value = value;\n\treturn;\nL_002F:\n\tthrow System.InvalidCastException;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (value == null || (object)value.GetType() == typeof(string))
				{
					Value = (string)value;
					return;
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x17000090")]
		public override VariableType VariableType
		{
			[Token(Token = "0x6000245")]
			[Address(RVA = "0xCB6170", Offset = "0xCB6170", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 4;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return VariableType.String;
			}
		}

		[Token(Token = "0x6000241")]
		[Address(RVA = "0xCB6050", Offset = "0xCB6050", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EB0A10]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023659]) = v38;\nL_0018:\n\tthis.value = \"\";\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this);\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmString()
		{
			Value = "";
		}

		[Token(Token = "0x6000242")]
		[Address(RVA = "0xCB60A8", Offset = "0xCB60A8", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EAD8F0]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, name, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202365A]) = v41;\nL_001B:\n\tthis.value = \"\";\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this, name);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmString(string name)
		{
			Value = "";
			base._002Ector(name);
		}

		[Token(Token = "0x6000243")]
		[Address(RVA = "0xCABD5C", Offset = "0xCABD5C", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EC5840]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, source, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202365B]) = v41;\nL_001B:\n\tthis.value = \"\";\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this, source);\n\tv48 = source == 0;\n\tif (v48) goto L_0027;\n\tthis.value = source.value;\nL_0027:\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmString(FsmString source)
		{
			Value = "";
			base._002Ector(source);
			if (source != null)
			{
				Value = source.value;
			}
		}

		[Token(Token = "0x6000244")]
		[Address(RVA = "0xCB6110", Offset = "0xCB6110", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EEE508]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202365C]) = v38;\nL_0016:\n\tv42 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v42, this);\n\treturn v42;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override NamedVariable Clone()
		{
			return new FsmString(this);
		}

		[Token(Token = "0x6000246")]
		[Address(RVA = "0xCB6178", Offset = "0xCB6178", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = HutongGames.PlayMaker.FsmString::get_Value(this);\n\treturn returnVal1;\n")]
		public override string ToString()
		{
			return Value;
		}

		[Token(Token = "0x6000247")]
		[Address(RVA = "0xCB617C", Offset = "0xCB617C", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = &v5 @ stack_-10_v2;\n\t*([v4 @ X29_v1-4]) = 0;\n\tv8 = &v5 @ stack_-10_v2 - 4;\n\tv10 = System.Single::TryParse(this.value, v8);\n\treturn *([v4 @ X29_v1-4]);\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override int ToInt()
		{
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			bool flag = float.TryParse(value, out *(float*)((long)(IntPtr)obj2 - 4L));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ X29_v1-4]");
			return 0;
		}

		[Token(Token = "0x6000248")]
		[Address(RVA = "0xCB61B0", Offset = "0xCB61B0", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EEA7A0]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202365D]) = v38;\nL_0016:\n\tthis.value = \"\";\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Clear()
		{
			Value = "";
		}

		[Token(Token = "0x6000249")]
		[Address(RVA = "0xCB6200", Offset = "0xCB6200", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = &v5 @ stack_-10_v2;\n\t*([v4 @ X29_v1-4]) = 0;\n\tv8 = &v5 @ stack_-10_v2 - 4;\n\tv10 = System.Single::TryParse(this.value, v8);\n\treturn *([v4 @ X29_v1-4]);\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override float ToFloat()
		{
			//IL_003d: Expected F4, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			bool flag = float.TryParse(value, out *(float*)((long)(IntPtr)obj2 - 4L));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ X29_v1-4]");
			return 0f;
		}

		[Token(Token = "0x600024A")]
		[Address(RVA = "0xCABDD4", Offset = "0xCABDD4", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv20 = *([1EC5D08]);\n\tv21 = *([v20 @ X8_v8]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202365E]) = v40;\nL_001C:\n\tv49 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v49, v45.Empty);\n\tv49.value = value;\n\treturn v49;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator FsmString(string value)
		{
			FsmString fsmString = new FsmString(string.Empty);
			fsmString.Value = value;
			return fsmString;
		}

		[Token(Token = "0x600024B")]
		[Address(RVA = "0xCB2B28", Offset = "0xCB2B28", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = fsmString == 0;\n\tif (v10) goto L_0013;\n\tv13 = HutongGames.PlayMaker.NamedVariable::get_IsNone(fsmString);\n\tv18 = v13 == 0;\n\tif (v18) goto L_001A;\nL_0013:\n\treturn 1;\nL_001A:\n\treturnVal2 = System.String::IsNullOrEmpty(fsmString.value);\n\treturn returnVal2;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsNullOrEmpty(FsmString fsmString)
		{
			if (fsmString == null || fsmString.IsNone)
			{
				return true;
			}
			return string.IsNullOrEmpty(fsmString.value);
		}
	}
}
