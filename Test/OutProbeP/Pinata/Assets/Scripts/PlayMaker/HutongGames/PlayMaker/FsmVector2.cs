using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	[Token(Token = "0x2000064")]
	public class FsmVector2 : NamedVariable
	{
		[SerializeField]
		[Token(Token = "0x4000189")]
		[FieldOffset(Offset = "0x38")]
		public Vector2 value;

		[Token(Token = "0x170000A4")]
		public Vector2 Value
		{
			[Token(Token = "0x6000283")]
			[Address(RVA = "0xE50D8C", Offset = "0xE50D8C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.value;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return value;
			}
			[Token(Token = "0x6000284")]
			[Address(RVA = "0xE50D94", Offset = "0xE50D94", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.value = value;\n\tthis.value.y = value.y;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				this.value = value;
				this.value.y = value.y;
			}
		}

		[Token(Token = "0x170000A5")]
		public override object RawValue
		{
			[Token(Token = "0x6000285")]
			[Address(RVA = "0xE50D9C", Offset = "0xE50D9C", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EC1630]);\n\tv19 = *([v18 @ X8_v5]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20247A1]) = v38;\nL_0014:\n\tv40 = this.value;\n\t// 27 Box returnVal1 @ X0_v3 (System.Object), typeof(UnityEngine.Vector2), &v40 @ X8_v3 (UnityEngine.Vector2)\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Vector2 vector = value;
				return vector;
			}
			[Token(Token = "0x6000286")]
			[Address(RVA = "0xE50E00", Offset = "0xE50E00", Length = "0x8C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EC3B98]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20247A2]) = v41;\n\tv59 = v59_asT == 0;\n\tif (v59) goto L_0037;\n\tv62 = \"il2cpp_vm_object_unbox\"(value, UnityEngine.Vector2, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tthis.value = *([v62 @ X0_v7]);\n\tthis.value.y = *([v62 @ X0_v7+4]);\n\treturn;\n\tv61 = new System.NullReferenceException();\nL_0037:\n\tthrow System.InvalidCastException;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0066: Expected F4, but got I
				if (((Vector2)((value is Vector2) ? value : null)).x != 0f)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					object obj = default(object);
					this.value = (Vector2)obj;
					ref Vector2 reference = ref this.value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X0_v7+4]");
					reference.y = 0f;
					return;
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x170000A6")]
		public override VariableType VariableType
		{
			[Token(Token = "0x600028C")]
			[Address(RVA = "0xE50FFC", Offset = "0xE50FFC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 5;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return VariableType.Vector2;
			}
		}

		[Token(Token = "0x6000287")]
		[Address(RVA = "0xE50E8C", Offset = "0xE50E8C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this);\n\treturn;\n")]
		public FsmVector2()
		{
		}

		[Token(Token = "0x6000288")]
		[Address(RVA = "0xE4F608", Offset = "0xE4F608", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this, name);\n\treturn;\n")]
		public FsmVector2(string name)
			: base(name)
		{
		}

		[Token(Token = "0x6000289")]
		[Address(RVA = "0xE4C0AC", Offset = "0xE4C0AC", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this, source);\n\tv15 = source == 0;\n\tif (v15) goto L_0014;\n\tthis.value = source.value;\n\tthis.value.y = source.value.y;\nL_0014:\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmVector2(FsmVector2 source)
			: base(source)
		{
			if (source != null)
			{
				value = source.value;
				value.y = source.value.y;
			}
		}

		[Token(Token = "0x600028A")]
		[Address(RVA = "0xE50F88", Offset = "0xE50F88", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1F01EF0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20247A3]) = v38;\nL_0016:\n\tv42 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v42, this);\n\tv45 = this == 0;\n\tif (v45) goto L_0026;\n\tv42.value = this.value;\n\tv42.value.y = this.value.y;\nL_0026:\n\treturn v42;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override NamedVariable Clone()
		{
			FsmVector2 fsmVector = (FsmVector2)new NamedVariable(this);
			if (this != null)
			{
				fsmVector.value = value;
				fsmVector.value.y = value.y;
			}
			return fsmVector;
		}

		[Token(Token = "0x600028B")]
		[Address(RVA = "0xE50FF4", Offset = "0xE50FF4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.value = 0;\n\treturn;\n")]
		public override void Clear()
		{
			value = default(Vector2);
		}

		[Token(Token = "0x600028D")]
		[Address(RVA = "0xE51004", Offset = "0xE51004", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x38;\n\treturnVal1 = 0x1588F68(v0, 0, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			//IL_000c: Expected O, but got I
			object obj = (long)(IntPtr)this + 56L;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588F68 (inside UnityEngine.Vector2::get_zero +0x94)");
			string result = default(string);
			return result;
		}

		[Token(Token = "0x600028E")]
		[Address(RVA = "0xE51010", Offset = "0xE51010", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv24 = *([1EBE550]);\n\tv25 = *([v24 @ X8_v8]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, v27, v28, v29, v30, v31, v32, v33, value, v0, v34, v35, v36, v37, v38, v39);\n\tv43 = 0 | 1;\n\t*([20247A4]) = v43;\nL_001F:\n\tv52 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v52, v48.Empty);\n\tv52.value = value;\n\tv52.value.y = value.y;\n\treturn v52;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator FsmVector2(Vector2 value)
		{
			FsmVector2 fsmVector = (FsmVector2)new NamedVariable(string.Empty);
			fsmVector.value = value;
			fsmVector.value.y = value.y;
			return fsmVector;
		}
	}
}
