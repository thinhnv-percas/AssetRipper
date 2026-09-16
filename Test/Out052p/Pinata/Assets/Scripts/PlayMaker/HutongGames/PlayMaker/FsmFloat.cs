using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	[Token(Token = "0x2000058")]
	public class FsmFloat : NamedVariable
	{
		[SerializeField]
		[Token(Token = "0x4000167")]
		[FieldOffset(Offset = "0x38")]
		private float value;

		[Token(Token = "0x17000074")]
		public float Value
		{
			[Token(Token = "0x60001D9")]
			[Address(RVA = "0xCAC534", Offset = "0xCAC534", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = HutongGames.PlayMaker.NamedVariable::get_CastVariable(this);\n\tv12 = v11 == 0;\n\tif (v12) goto L_001C;\n\tv15 = HutongGames.PlayMaker.NamedVariable::get_CastVariable(this);\n\tv29 = *([v15 @ X0_v3 (HutongGames.PlayMaker.NamedVariable)]);\n\tv24 = *([v29 @ X8_v1 (Il2CppClass<HutongGames.PlayMaker.NamedVariable>)+330]);\n\tv37 = *([v29 @ X8_v1 (Il2CppClass<HutongGames.PlayMaker.NamedVariable>)+338]);\n\t// 22 IndirectJump v24 @ X2_v1, v15 @ X0_v3 (HutongGames.PlayMaker.NamedVariable), v15 @ X0_v3 (HutongGames.PlayMaker.NamedVariable), v37 @ X1_v3, v24 @ X2_v1, v40 @ X3, v41 @ X4, v42 @ X5, v43 @ X6, v44 @ X7, returnVal2 @ V0, v45 @ V1, v46 @ V2, v47 @ V3, v48 @ V4, v49 @ V5, v50 @ V6, v51 @ V7\nL_001C:\n\treturn this.value;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ X8_v1 (Il2CppClass<HutongGames.PlayMaker.NamedVariable>)+330]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ X8_v1 (Il2CppClass<HutongGames.PlayMaker.NamedVariable>)+338]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v24 @ X2_v1 (should have been resolved before IL gen)");
				}
				return value;
			}
			[Token(Token = "0x60001DA")]
			[Address(RVA = "0xCAC58C", Offset = "0xCAC58C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.value = value;\n\treturn;\n")]
			set
			{
				Value = value;
			}
		}

		[Token(Token = "0x17000075")]
		public override object RawValue
		{
			[Token(Token = "0x60001DB")]
			[Address(RVA = "0xCAC594", Offset = "0xCAC594", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EC2CD0]);\n\tv19 = *([v18 @ X8_v5]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235DD]) = v38;\nL_0014:\n\tv40 = this.value;\n\t// 25 Box returnVal1 @ X0_v3 (System.Object), typeof(System.Single), &v40 @ X8_v3 (System.Single)\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				float num = value;
				return num;
			}
			[Token(Token = "0x60001DC")]
			[Address(RVA = "0xCAC5F8", Offset = "0xCAC5F8", Length = "0x8C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EAABF8]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20235DE]) = v41;\n\tv59 = v59_asT == 0;\n\tif (v59) goto L_0035;\n\tv62 = \"il2cpp_vm_object_unbox\"(value, System.Single, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tthis.value = *([v62 @ X0_v7]);\n\treturn;\n\tv61 = new System.NullReferenceException();\nL_0035:\n\tthrow System.InvalidCastException;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0012: Expected F4, but got O
				//IL_0045: Expected F4, but got O
				float num = (float)((value is float) ? value : null);
				if (num != 0f)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					object obj = default(object);
					Value = (float)obj;
					return;
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x17000076")]
		public override VariableType VariableType
		{
			[Token(Token = "0x60001E2")]
			[Address(RVA = "0xCAC7DC", Offset = "0xCAC7DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return default(VariableType);
			}
		}

		[Token(Token = "0x60001DD")]
		[Address(RVA = "0xCAC684", Offset = "0xCAC684", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EB0300]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, val, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20235DF]) = v41;\nL_0015:\n\tv42 = val == 0;\n\tif (v42) goto L_0044;\n\tv93 = val->klass;\n\tv56 = *([val @ X1 (System.Object)]) != System.Single;\n\tif (v56) goto L_0037;\n\tv100 = \"il2cpp_vm_object_unbox\"(val, val, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tthis.value = *([v100 @ X0_v7]);\n\tv93 = val->klass;\nL_0037:\n\tv60 = v93 != System.Int32;\n\tif (v60) goto L_0044;\n\tv90 = \"il2cpp_vm_object_unbox\"(val, val, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tthis.value = *([v90 @ X0_v5]);\nL_0044:\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SafeAssign(object val)
		{
			//IL_000d: Expected I, but got O
			//IL_004b: Expected F4, but got O
			//IL_0053: Expected I, but got O
			//IL_006c: Expected F4, but got O
			if (val != null)
			{
				IntPtr intPtr = (IntPtr)val;
				if ((object)val.GetType() == typeof(float))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					object obj = default(object);
					Value = (float)obj;
					intPtr = (IntPtr)val;
				}
				if (intPtr == (IntPtr)typeof(int))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					object obj2 = default(object);
					Value = (float)obj2;
				}
			}
		}

		[Token(Token = "0x60001DE")]
		[Address(RVA = "0xCAC728", Offset = "0xCAC728", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmFloat()
		{
		}

		[Token(Token = "0x60001DF")]
		[Address(RVA = "0xCAC730", Offset = "0xCAC730", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this, name);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmFloat(string name)
			: base(name)
		{
		}

		[Token(Token = "0x60001E0")]
		[Address(RVA = "0xCAC738", Offset = "0xCAC738", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this, source);\n\tv15 = source == 0;\n\tif (v15) goto L_0013;\n\tthis.value = source.value;\nL_0013:\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmFloat(FsmFloat source)
			: base(source)
		{
			if (source != null)
			{
				Value = source.value;
			}
		}

		[Token(Token = "0x60001E1")]
		[Address(RVA = "0xCAC76C", Offset = "0xCAC76C", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1ED3948]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235E0]) = v38;\nL_0016:\n\tv42 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v42, this);\n\tv46 = this == 0;\n\tif (v46) goto L_0025;\n\tv42.value = this.value;\nL_0025:\n\treturn v42;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override NamedVariable Clone()
		{
			FsmFloat fsmFloat = (FsmFloat)new NamedVariable(this);
			if (this != null)
			{
				fsmFloat.Value = value;
			}
			return fsmFloat;
		}

		[Token(Token = "0x60001E3")]
		[Address(RVA = "0xCAC7E4", Offset = "0xCAC7E4", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = &v5 @ stack_-10_v2;\n\tv6 = HutongGames.PlayMaker.FsmFloat::get_Value(this);\n\tv9 = &v5 @ stack_-10_v2 - 4;\n\t*([v4 @ X29_v1-4]) = v6;\n\treturnVal1 = 0xBCCEC8(v9, 0, v12, v13, v14, v15, v16, v17, v6, v18, v19, v20, v21, v22, v23, v24);\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			//IL_0021: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			float num = Value;
			object obj3 = (long)(IntPtr)obj2 - 4L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BCCEC8 (inside System.Single::IsNaN +0x2B0)");
			string result = default(string);
			return result;
		}

		[Token(Token = "0x60001E4")]
		[Address(RVA = "0xCAC810", Offset = "0xCAC810", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.value;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override int ToInt()
		{
			//IL_0007: Expected I4, but got F4
			return (int)value;
		}

		[Token(Token = "0x60001E5")]
		[Address(RVA = "0xCAC81C", Offset = "0xCAC81C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.value = 0f;\n\treturn;\n")]
		public override void Clear()
		{
			Value = 0f;
		}

		[Token(Token = "0x60001E6")]
		[Address(RVA = "0xCAC824", Offset = "0xCAC824", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv20 = *([1ECB1E0]);\n\tv21 = *([v20 @ X8_v8]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, v23, v24, v25, v26, v27, v28, v29, value, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([20235E1]) = v40;\nL_001C:\n\tv49 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v49, v45.Empty);\n\tv49.value = value;\n\treturn v49;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator FsmFloat(float value)
		{
			FsmFloat fsmFloat = (FsmFloat)new NamedVariable(string.Empty);
			fsmFloat.Value = value;
			return fsmFloat;
		}
	}
}
