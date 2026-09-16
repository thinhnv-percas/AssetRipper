using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	[Token(Token = "0x200005A")]
	public class FsmInt : NamedVariable
	{
		[SerializeField]
		[Token(Token = "0x400016A")]
		[FieldOffset(Offset = "0x38")]
		private int value;

		[Token(Token = "0x1700007B")]
		public int Value
		{
			[Token(Token = "0x60001F7")]
			[Address(RVA = "0xCACE20", Offset = "0xCACE20", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = HutongGames.PlayMaker.NamedVariable::get_CastVariable(this);\n\tv12 = v11 == 0;\n\tif (v12) goto L_001C;\n\tv15 = HutongGames.PlayMaker.NamedVariable::get_CastVariable(this);\n\tv27 = *([v15 @ X0_v4 (HutongGames.PlayMaker.NamedVariable)]);\n\tv22 = *([v27 @ X8_v1 (Il2CppClass<HutongGames.PlayMaker.NamedVariable>)+340]);\n\tv35 = *([v27 @ X8_v1 (Il2CppClass<HutongGames.PlayMaker.NamedVariable>)+348]);\n\t// 22 IndirectJump v22 @ X2_v1, v15 @ X0_v4 (HutongGames.PlayMaker.NamedVariable), v15 @ X0_v4 (HutongGames.PlayMaker.NamedVariable), v35 @ X1_v3, v22 @ X2_v1, v38 @ X3, v39 @ X4, v40 @ X5, v41 @ X6, v42 @ X7, v43 @ V0, v44 @ V1, v45 @ V2, v46 @ V3, v47 @ V4, v48 @ V5, v49 @ V6, v50 @ V7\nL_001C:\n\treturn this.value;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ X8_v1 (Il2CppClass<HutongGames.PlayMaker.NamedVariable>)+340]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ X8_v1 (Il2CppClass<HutongGames.PlayMaker.NamedVariable>)+348]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v22 @ X2_v1 (should have been resolved before IL gen)");
				}
				return value;
			}
			[Token(Token = "0x60001F8")]
			[Address(RVA = "0xCACE78", Offset = "0xCACE78", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.value = value;\n\treturn;\n")]
			set
			{
				Value = value;
			}
		}

		[Token(Token = "0x1700007C")]
		public override object RawValue
		{
			[Token(Token = "0x60001F9")]
			[Address(RVA = "0xCACE80", Offset = "0xCACE80", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1ECBE68]);\n\tv19 = *([v18 @ X8_v5]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235EB]) = v38;\nL_0014:\n\tv40 = this.value;\n\t// 25 Box returnVal1 @ X0_v3 (System.Object), typeof(System.Int32), &v40 @ X8_v3 (System.Int32)\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				int num = value;
				return num;
			}
			[Token(Token = "0x60001FA")]
			[Address(RVA = "0xCACEE4", Offset = "0xCACEE4", Length = "0x8C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1ED8678]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20235EC]) = v41;\n\tv59 = v59_asT == 0;\n\tif (v59) goto L_0035;\n\tv62 = \"il2cpp_vm_object_unbox\"(value, System.Int32, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tthis.value = *([v62 @ X0_v7]);\n\treturn;\n\tv61 = new System.NullReferenceException();\nL_0035:\n\tthrow System.InvalidCastException;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0012: Expected I4, but got O
				//IL_0048: Expected I4, but got O
				if ((int)((value is int) ? value : null) != 0)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					object obj = default(object);
					Value = (int)obj;
					return;
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x1700007D")]
		public override VariableType VariableType
		{
			[Token(Token = "0x6000200")]
			[Address(RVA = "0xCAD114", Offset = "0xCAD114", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return VariableType.Int;
			}
		}

		[Token(Token = "0x60001FB")]
		[Address(RVA = "0xCACF70", Offset = "0xCACF70", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EC0CD8]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, val, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20235ED]) = v41;\nL_0015:\n\tv42 = val == 0;\n\tif (v42) goto L_0064;\n\tv159 = val->klass;\n\tv56 = *([val @ X1 (System.Object)]) != System.Int32;\n\tif (v56) goto L_0037;\n\tv117 = \"il2cpp_vm_object_unbox\"(val, val, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tthis.value = *([v117 @ X0_v13]);\n\tv159 = val->klass;\nL_0037:\n\tv64 = v159 != System.Single;\n\tif (v64) goto L_0064;\n\tv145 = UnityEngine.Mathf;\n\tv147 = *([v145 @ X0_v4 (Il2CppClass<UnityEngine.Mathf>)+12F]) & 2;\n\tv148 = v147 == 0;\n\tv149 = ~v148;\n\tif (v149) goto L_FFFFFFFF;\n\tgoto L_0057;\n\tgoto L_0057;\n\tv158 = \"il2cpp_codegen_runtime_class_init\"(v145, v152, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv155 = System.Single;\n\tv160 = *([v14 @ X20_v1 (System.Object)]);\nL_0057:\n\tv62 = *([v159 @ X8_v8 (Il2CppClass<System.Object>)+40]) != *([v60 @ X1_v2 (Il2CppClass<System.Object>)+40]);\n\tif (v62) goto L_0065;\n\tv163 = \"il2cpp_vm_object_unbox\"(val, v60, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv102 = UnityEngine.Mathf::FloorToInt(*([v163 @ X0_v8]));\n\tthis.value = v102;\nL_0064:\n\treturn;\nL_0065:\n\tthrow System.InvalidCastException;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SafeAssign(object val)
		{
			//IL_000d: Expected I, but got O
			//IL_0050: Expected I4, but got O
			//IL_0058: Expected I, but got O
			//IL_006b: Expected I, but got O
			//IL_00db: Expected F4, but got O
			if (val == null)
			{
				return;
			}
			IntPtr intPtr = (IntPtr)val;
			if ((object)val.GetType() == typeof(int))
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				object obj = default(object);
				Value = (int)obj;
				intPtr = (IntPtr)val;
			}
			if (intPtr == (IntPtr)typeof(float))
			{
				IntPtr intPtr2 = (IntPtr)typeof(Mathf);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ X0_v4 (Il2CppClass<UnityEngine.Mathf>)+12F]");
				if (0 == 0)
				{
					IntPtr intPtr3 = intPtr;
				}
				else
				{
					IntPtr intPtr3 = intPtr;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ X8_v8 (Il2CppClass<System.Object>)+40]");
				IntPtr intPtr4 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ X1_v2 (Il2CppClass<System.Object>)+40]");
				if (intPtr4 != (IntPtr)0)
				{
					throw new InvalidCastException();
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				object obj2 = default(object);
				int num = Mathf.FloorToInt((float)obj2);
				Value = num;
			}
		}

		[Token(Token = "0x60001FC")]
		[Address(RVA = "0xCAD060", Offset = "0xCAD060", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmInt()
		{
		}

		[Token(Token = "0x60001FD")]
		[Address(RVA = "0xCAD068", Offset = "0xCAD068", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this, name);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmInt(string name)
			: base(name)
		{
		}

		[Token(Token = "0x60001FE")]
		[Address(RVA = "0xCAD070", Offset = "0xCAD070", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this, source);\n\tv15 = source == 0;\n\tif (v15) goto L_0013;\n\tthis.value = source.value;\nL_0013:\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmInt(FsmInt source)
			: base(source)
		{
			if (source != null)
			{
				Value = source.value;
			}
		}

		[Token(Token = "0x60001FF")]
		[Address(RVA = "0xCAD0A4", Offset = "0xCAD0A4", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EF7D88]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235EE]) = v38;\nL_0016:\n\tv42 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v42, this);\n\tv46 = this == 0;\n\tif (v46) goto L_0025;\n\tv42.value = this.value;\nL_0025:\n\treturn v42;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override NamedVariable Clone()
		{
			FsmInt fsmInt = (FsmInt)new NamedVariable(this);
			if (this != null)
			{
				fsmInt.Value = value;
			}
			return fsmInt;
		}

		[Token(Token = "0x6000201")]
		[Address(RVA = "0xCAD11C", Offset = "0xCAD11C", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = &v5 @ stack_-10_v2;\n\tv6 = HutongGames.PlayMaker.FsmInt::get_Value(this);\n\t*([v4 @ X29_v1-4]) = v6;\n\tv9 = &v5 @ stack_-10_v2 - 4;\n\treturnVal1 = 0xDC3560(v9, 0, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25);\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			//IL_0026: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			int num = Value;
			object obj3 = (long)(IntPtr)obj2 - 4L;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
			string result = default(string);
			return result;
		}

		[Token(Token = "0x6000202")]
		[Address(RVA = "0xCAD148", Offset = "0xCAD148", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.value;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float ToFloat()
		{
			//IL_0007: Expected F4, but got I4
			return value;
		}

		[Token(Token = "0x6000203")]
		[Address(RVA = "0xCAD154", Offset = "0xCAD154", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.value;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override int ToInt()
		{
			return value;
		}

		[Token(Token = "0x6000204")]
		[Address(RVA = "0xCAD15C", Offset = "0xCAD15C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.value = 0;\n\treturn;\n")]
		public override void Clear()
		{
			Value = 0;
		}

		[Token(Token = "0x6000205")]
		[Address(RVA = "0xCAD164", Offset = "0xCAD164", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv20 = *([1F0F470]);\n\tv21 = *([v20 @ X8_v8]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20235EF]) = v40;\nL_001C:\n\tv49 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v49, v45.Empty);\n\tv49.value = value;\n\treturn v49;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator FsmInt(int value)
		{
			FsmInt fsmInt = (FsmInt)new NamedVariable(string.Empty);
			fsmInt.Value = value;
			return fsmInt;
		}
	}
}
