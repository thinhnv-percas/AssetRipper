using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	[Token(Token = "0x200005F")]
	public class FsmQuaternion : NamedVariable
	{
		[SerializeField]
		[Token(Token = "0x4000173")]
		[FieldOffset(Offset = "0x38")]
		public Quaternion value;

		[Token(Token = "0x17000088")]
		public Quaternion Value
		{
			[Token(Token = "0x6000225")]
			[Address(RVA = "0xCB2B88", Offset = "0xCB2B88", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.value;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return value;
			}
			[Token(Token = "0x6000226")]
			[Address(RVA = "0xCB2B94", Offset = "0xCB2B94", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.value = value;\n\tthis.value.y = value.y;\n\tthis.value.z = value.z;\n\tthis.value.w = value.w;\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				this.value = value;
				this.value.y = value.y;
				this.value.z = value.z;
				this.value.w = value.w;
			}
		}

		[Token(Token = "0x17000089")]
		public override object RawValue
		{
			[Token(Token = "0x6000227")]
			[Address(RVA = "0xCB2BA0", Offset = "0xCB2BA0", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1ED6AE0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023623]) = v38;\nL_0014:\n\tv40 = this.value;\n\t// 25 Box returnVal1 @ X0_v3 (System.Object), typeof(UnityEngine.Quaternion), &v40 @ V0_v1 (UnityEngine.Quaternion)\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Quaternion quaternion = value;
				return quaternion;
			}
			[Token(Token = "0x6000228")]
			[Address(RVA = "0xCB2C04", Offset = "0xCB2C04", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EA71E0]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023624]) = v41;\n\tv59 = v59_asT == 0;\n\tif (v59) goto L_0039;\n\tv62 = \"il2cpp_vm_object_unbox\"(value, UnityEngine.Quaternion, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tthis.value.x = *([v62 @ X0_v7]);\n\tthis.value.y = *([v62 @ X0_v7+4]);\n\tthis.value.w = *([v62 @ X0_v7+C]);\n\treturn;\n\tv61 = new System.NullReferenceException();\nL_0039:\n\tthrow System.InvalidCastException;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_004f: Expected F4, but got O
				//IL_0066: Expected F4, but got I
				//IL_007d: Expected F4, but got I
				if (((Quaternion)((value is Quaternion) ? value : null)).x != 0f)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					object obj = default(object);
					this.value.x = (float)obj;
					ref Quaternion reference = ref this.value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X0_v7+4]");
					reference.y = 0f;
					ref Quaternion reference2 = ref this.value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X0_v7+C]");
					reference2.w = 0f;
					return;
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x1700008A")]
		public override VariableType VariableType
		{
			[Token(Token = "0x600022E")]
			[Address(RVA = "0xCB2D78", Offset = "0xCB2D78", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0xB;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return VariableType.Quaternion;
			}
		}

		[Token(Token = "0x6000229")]
		[Address(RVA = "0xCB2B78", Offset = "0xCB2B78", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmQuaternion()
		{
		}

		[Token(Token = "0x600022A")]
		[Address(RVA = "0xCB2CA0", Offset = "0xCB2CA0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this, name);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmQuaternion(string name)
			: base(name)
		{
		}

		[Token(Token = "0x600022B")]
		[Address(RVA = "0xCB01A8", Offset = "0xCB01A8", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this, source);\n\tv15 = source == 0;\n\tif (v15) goto L_0017;\n\tthis.value.x = source.value;\n\tthis.value.y = source.value.y;\n\tthis.value.w = source.value.w;\nL_0017:\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmQuaternion(FsmQuaternion source)
			: base(source)
		{
			if (source != null)
			{
				value.x = source.value.x;
				value.y = source.value.y;
				value.w = source.value.w;
			}
		}

		[Token(Token = "0x600022C")]
		[Address(RVA = "0xCB2CA8", Offset = "0xCB2CA8", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EFDC70]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023625]) = v38;\nL_0016:\n\tv42 = new HutongGames.PlayMaker.FsmQuaternion();\n\tHutongGames.PlayMaker.FsmQuaternion::.ctor(v42, this);\n\treturn v42;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override NamedVariable Clone()
		{
			return new FsmQuaternion(this);
		}

		[Token(Token = "0x600022D")]
		[Address(RVA = "0xCB2D08", Offset = "0xCB2D08", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F05E18]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023626]) = v38;\nL_0019:\n\tgoto L_0020;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0020;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0020:\n\tv53 = UnityEngine.Quaternion::get_identity();\n\tthis.value = v53;\n\tthis.value.y = v53.y;\n\tthis.value.z = v53.z;\n\tthis.value.w = v53.w;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Clear()
		{
			Quaternion quaternion = (value = Quaternion.identity);
			value.y = quaternion.y;
			value.z = quaternion.z;
			value.w = quaternion.w;
		}

		[Token(Token = "0x600022F")]
		[Address(RVA = "0xCB2D80", Offset = "0xCB2D80", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this + 0x38;\n\tv9 = 0x10CC508(v6, 0, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23);\n\treturnVal1 = 0x158B294(&v16 @ V0, 0, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23);\n\treturn returnVal1;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			//IL_000c: Expected O, but got I
			object obj = (long)(IntPtr)this + 56L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CC508 (inside UnityEngine.Quaternion::Internal_MakePositive +0x9C)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B294 (inside UnityEngine.Vector3::op_Inequality +0xBC)");
			string result = default(string);
			return result;
		}

		[Token(Token = "0x6000230")]
		[Address(RVA = "0xCB2DB8", Offset = "0xCB2DB8", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv32 = *([1EA4F38]);\n\tv33 = *([v32 @ X8_v8]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, v35, v36, v37, v38, v39, v40, v41, value, v0, v2, v3, v42, v43, v44, v45);\n\tv49 = 0 | 1;\n\t*([2023627]) = v49;\nL_0025:\n\tv58 = new HutongGames.PlayMaker.FsmQuaternion();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v58, v54.Empty);\n\tv58.value = value;\n\tv58.value.y = value.y;\n\tv58.value.z = value.z;\n\tv58.value.w = value.w;\n\treturn v58;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator FsmQuaternion(Quaternion value)
		{
			FsmQuaternion fsmQuaternion = (FsmQuaternion)new NamedVariable(string.Empty);
			fsmQuaternion.value = value;
			fsmQuaternion.value.y = value.y;
			fsmQuaternion.value.z = value.z;
			fsmQuaternion.value.w = value.w;
			return fsmQuaternion;
		}
	}
}
