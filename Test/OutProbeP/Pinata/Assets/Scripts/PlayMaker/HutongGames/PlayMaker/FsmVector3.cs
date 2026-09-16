using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	[Token(Token = "0x2000065")]
	public class FsmVector3 : NamedVariable
	{
		[SerializeField]
		[Token(Token = "0x400018A")]
		[FieldOffset(Offset = "0x38")]
		public Vector3 value;

		[Token(Token = "0x170000A7")]
		public Vector3 Value
		{
			[Token(Token = "0x600028F")]
			[Address(RVA = "0xE4D1B8", Offset = "0xE4D1B8", Length = "0xE4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EFF3E8]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, returnVal2, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20247A5]) = v38;\nL_0014:\n\tv40 = HutongGames.PlayMaker.NamedVariable::get_CastVariable(this);\n\tv41 = v40 == 0;\n\tif (v41) goto L_0055;\n\tv43 = HutongGames.PlayMaker.NamedVariable::get_CastVariable(this);\n\tv127 = *([v43 @ X0_v5 (HutongGames.PlayMaker.NamedVariable)]);\n\tv129 = HutongGames.PlayMaker.NamedVariable::get_RawValue(v43);\n\tgoto L_FFFFFFFF;\n\tv138 = *([v133 @ X8_v6 (Il2CppClass<UnityEngine.Vector2>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\t// 42 ConditionalJump @b22, v140 @ TEMP_v13\n\tv155 = v133;\n\tv143 = \"il2cpp_codegen_runtime_class_init\"(v155, v104, v22, v23, v24, v25, v26, v27, returnVal2, v29, v30, v31, v32, v33, v34, v35);\n\tv145 = UnityEngine.Vector2;\n\tv64 = v64_asT == 0;\n\tif (v64) goto L_005A;\n\tv161 = \"il2cpp_vm_object_unbox\"(v129, *([v127 @ X8_v5 (Il2CppClass<HutongGames.PlayMaker.NamedVariable>)+2E8]), v22, v23, v24, v25, v26, v27, returnVal2, v29, v30, v31, v32, v33, v34, v35);\n\t// 72 MakeStruct v55 @ AGGE4D270_0_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), [v161 @ X0_v15], [v161 @ X0_v15+4]\n\treturnVal3 = UnityEngine.Vector2::op_Implicit(v55);\n\treturn returnVal3;\nL_0055:\n\treturn this.value;\n\tthrow System.NullReferenceException;\n\tv154 = new System.NullReferenceException();\nL_005A:\n\tthrow System.InvalidCastException;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_001c: Expected I, but got O
				//IL_007b: Expected F4, but got O
				//IL_0090: Expected F4, but got I
				NamedVariable castVariable = base.CastVariable;
				if (castVariable != null)
				{
					NamedVariable castVariable2 = base.CastVariable;
					IntPtr intPtr = (IntPtr)castVariable2;
					object rawValue = castVariable2.RawValue;
					if (((Vector2)((rawValue is Vector2) ? rawValue : null)).x != 0f)
					{
						Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						Vector2 vector = default(Vector2);
						object obj = default(object);
						vector.x = (float)obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ X0_v15+4]");
						vector.y = 0f;
						return vector;
					}
					throw new InvalidCastException();
				}
				return value;
			}
			[Token(Token = "0x6000290")]
			[Address(RVA = "0xE51124", Offset = "0xE51124", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.value = value;\n\tthis.value.y = value.y;\n\tthis.value.z = value.z;\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				this.value = value;
				this.value.y = value.y;
				this.value.z = value.z;
			}
		}

		[Token(Token = "0x170000A8")]
		public override object RawValue
		{
			[Token(Token = "0x6000291")]
			[Address(RVA = "0xE51130", Offset = "0xE51130", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EF8260]);\n\tv19 = *([v18 @ X8_v5]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20247A6]) = v38;\nL_0014:\n\tv40 = this.value;\n\t// 27 Box returnVal1 @ X0_v3 (System.Object), typeof(UnityEngine.Vector3), &v40 @ X8_v3 (UnityEngine.Vector3)\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Vector3 vector = value;
				return vector;
			}
			[Token(Token = "0x6000292")]
			[Address(RVA = "0xE5119C", Offset = "0xE5119C", Length = "0x94")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EC1B48]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20247A7]) = v41;\n\tv59 = v59_asT == 0;\n\tif (v59) goto L_0037;\n\tv62 = \"il2cpp_vm_object_unbox\"(value, UnityEngine.Vector3, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tthis.value = *([v62 @ X0_v7]);\n\tthis.value.z = *([v62 @ X0_v7+8]);\n\treturn;\n\tv61 = new System.NullReferenceException();\nL_0037:\n\tthrow System.InvalidCastException;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0066: Expected F4, but got I
				if (((Vector3)((value is Vector3) ? value : null)).x != 0f)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					object obj = default(object);
					this.value = (Vector3)obj;
					ref Vector3 reference = ref this.value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X0_v7+8]");
					reference.z = 0f;
					return;
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x170000A9")]
		public override VariableType VariableType
		{
			[Token(Token = "0x6000298")]
			[Address(RVA = "0xE512B4", Offset = "0xE512B4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 6;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return VariableType.Vector3;
			}
		}

		[Token(Token = "0x6000293")]
		[Address(RVA = "0xE51230", Offset = "0xE51230", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this);\n\treturn;\n")]
		public FsmVector3()
		{
		}

		[Token(Token = "0x6000294")]
		[Address(RVA = "0xE4F768", Offset = "0xE4F768", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this, name);\n\treturn;\n")]
		public FsmVector3(string name)
			: base(name)
		{
		}

		[Token(Token = "0x6000295")]
		[Address(RVA = "0xE4C0DC", Offset = "0xE4C0DC", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this, source);\n\tv15 = source == 0;\n\tif (v15) goto L_0014;\n\tthis.value = source.value;\n\tthis.value.z = source.value.z;\nL_0014:\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmVector3(FsmVector3 source)
			: base(source)
		{
			if (source != null)
			{
				value = source.value;
				value.z = source.value.z;
			}
		}

		[Token(Token = "0x6000296")]
		[Address(RVA = "0xE51234", Offset = "0xE51234", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EA7898]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20247A8]) = v38;\nL_0016:\n\tv42 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v42, this);\n\tv45 = this == 0;\n\tif (v45) goto L_0028;\n\tv42.value = this.value;\n\tv42.value.y = this.value.y;\n\tv42.value.z = this.value.z;\nL_0028:\n\treturn v42;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override NamedVariable Clone()
		{
			FsmVector3 fsmVector = (FsmVector3)new NamedVariable(this);
			if (this != null)
			{
				fsmVector.value = value;
				fsmVector.value.y = value.y;
				fsmVector.value.z = value.z;
			}
			return fsmVector;
		}

		[Token(Token = "0x6000297")]
		[Address(RVA = "0xE512A8", Offset = "0xE512A8", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.value.z = 0f;\n\tthis.value = 0;\n\treturn;\n")]
		public override void Clear()
		{
			value.z = 0f;
			value = default(Vector3);
		}

		[Token(Token = "0x6000299")]
		[Address(RVA = "0xE512BC", Offset = "0xE512BC", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = HutongGames.PlayMaker.FsmVector3::get_Value(this);\n\treturnVal1 = 0x158B294(&v6 @ V0_v1 (UnityEngine.Vector3), 0, v17, v18, v19, v20, v21, v22, v6, v6.y, v6.z, v23, v24, v25, v26, v27);\n\treturn returnVal1;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			Vector3 vector = Value;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158B294 (inside UnityEngine.Vector3::op_Inequality +0xBC)");
			string result = default(string);
			return result;
		}

		[Token(Token = "0x600029A")]
		[Address(RVA = "0xE512EC", Offset = "0xE512EC", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv28 = *([1EC9418]);\n\tv29 = *([v28 @ X8_v8]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, v31, v32, v33, v34, v35, v36, v37, value, v0, v2, v38, v39, v40, v41, v42);\n\tv46 = 0 | 1;\n\t*([20247A9]) = v46;\nL_0022:\n\tv55 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v55, v51.Empty);\n\tv55.value = value;\n\tv55.value.y = value.y;\n\tv55.value.z = value.z;\n\treturn v55;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator FsmVector3(Vector3 value)
		{
			FsmVector3 fsmVector = (FsmVector3)new NamedVariable(string.Empty);
			fsmVector.value = value;
			fsmVector.value.y = value.y;
			fsmVector.value.z = value.z;
			return fsmVector;
		}
	}
}
