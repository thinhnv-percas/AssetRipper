using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	[Token(Token = "0x2000060")]
	public class FsmRect : NamedVariable
	{
		[SerializeField]
		[Token(Token = "0x4000174")]
		[FieldOffset(Offset = "0x38")]
		public Rect value;

		[Token(Token = "0x1700008B")]
		public Rect Value
		{
			[Token(Token = "0x6000231")]
			[Address(RVA = "0xCB2E60", Offset = "0xCB2E60", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.value;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return value;
			}
			[Token(Token = "0x6000232")]
			[Address(RVA = "0xCB2E6C", Offset = "0xCB2E6C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.value = value;\n\tthis.value.m_YMin = value.m_YMin;\n\tthis.value.m_Width = value.m_Width;\n\tthis.value.m_Height = value.m_Height;\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				this.value = value;
				this.value.y = value.y;
				this.value.width = value.width;
				this.value.height = value.height;
			}
		}

		[Token(Token = "0x1700008C")]
		public override object RawValue
		{
			[Token(Token = "0x6000233")]
			[Address(RVA = "0xCB2E78", Offset = "0xCB2E78", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1F0B2A0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023628]) = v38;\nL_0014:\n\tv40 = this.value;\n\t// 25 Box returnVal1 @ X0_v3 (System.Object), typeof(UnityEngine.Rect), &v40 @ V0_v1 (UnityEngine.Rect)\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Rect rect = value;
				return rect;
			}
			[Token(Token = "0x6000234")]
			[Address(RVA = "0xCB2EDC", Offset = "0xCB2EDC", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1F037D0]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023629]) = v41;\n\tv59 = v59_asT == 0;\n\tif (v59) goto L_0039;\n\tv62 = \"il2cpp_vm_object_unbox\"(value, UnityEngine.Rect, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tthis.value.m_XMin = *([v62 @ X0_v7]);\n\tthis.value.m_YMin = *([v62 @ X0_v7+4]);\n\tthis.value.m_Height = *([v62 @ X0_v7+C]);\n\treturn;\n\tv61 = new System.NullReferenceException();\nL_0039:\n\tthrow System.InvalidCastException;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0054: Expected F4, but got O
				//IL_006b: Expected F4, but got I
				//IL_0082: Expected F4, but got I
				if (((Rect)((value is Rect) ? value : null)).x != 0f)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					object obj = default(object);
					this.value.x = (float)obj;
					ref Rect reference = ref this.value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X0_v7+4]");
					reference.y = 0f;
					ref Rect reference2 = ref this.value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X0_v7+C]");
					reference2.height = 0f;
					return;
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x1700008D")]
		public override VariableType VariableType
		{
			[Token(Token = "0x600023A")]
			[Address(RVA = "0xCB2FE8", Offset = "0xCB2FE8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 8;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return VariableType.Rect;
			}
		}

		[Token(Token = "0x6000235")]
		[Address(RVA = "0xCB2B70", Offset = "0xCB2B70", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmRect()
		{
		}

		[Token(Token = "0x6000236")]
		[Address(RVA = "0xCB2F78", Offset = "0xCB2F78", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this, name);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmRect(string name)
			: base(name)
		{
		}

		[Token(Token = "0x6000237")]
		[Address(RVA = "0xCB0164", Offset = "0xCB0164", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this, source);\n\tv15 = source == 0;\n\tif (v15) goto L_0017;\n\tthis.value.m_XMin = source.value;\n\tthis.value.m_YMin = source.value.m_YMin;\n\tthis.value.m_Height = source.value.m_Height;\nL_0017:\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmRect(FsmRect source)
			: base(source)
		{
			if (source != null)
			{
				value.x = source.value.x;
				value.y = source.value.y;
				value.height = source.value.height;
			}
		}

		[Token(Token = "0x6000238")]
		[Address(RVA = "0xCB2F80", Offset = "0xCB2F80", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EE9BF0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202362A]) = v38;\nL_0016:\n\tv42 = new HutongGames.PlayMaker.FsmRect();\n\tHutongGames.PlayMaker.FsmRect::.ctor(v42, this);\n\treturn v42;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override NamedVariable Clone()
		{
			return new FsmRect(this);
		}

		[Token(Token = "0x6000239")]
		[Address(RVA = "0xCB2FE0", Offset = "0xCB2FE0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.value = 0;\n\tthis.value.m_Width = 0f;\n\treturn;\n")]
		public override void Clear()
		{
			value = default(Rect);
			value.width = 0f;
		}

		[Token(Token = "0x600023B")]
		[Address(RVA = "0xCB2FF0", Offset = "0xCB2FF0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x38;\n\treturnVal1 = 0x10CD5A0(v0, 0, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			//IL_000c: Expected O, but got I
			object obj = (long)(IntPtr)this + 56L;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD5A0 (inside UnityEngine.Rect::op_Equality +0x214)");
			string result = default(string);
			return result;
		}

		[Token(Token = "0x600023C")]
		[Address(RVA = "0xCB2FFC", Offset = "0xCB2FFC", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv32 = *([1F0F590]);\n\tv33 = *([v32 @ X8_v8]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, v35, v36, v37, v38, v39, v40, v41, value, v0, v2, v3, v42, v43, v44, v45);\n\tv49 = 0 | 1;\n\t*([202362B]) = v49;\nL_0025:\n\tv58 = new HutongGames.PlayMaker.FsmRect();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v58, v54.Empty);\n\tv58.value = value;\n\tv58.value.m_YMin = value.m_YMin;\n\tv58.value.m_Width = value.m_Width;\n\tv58.value.m_Height = value.m_Height;\n\treturn v58;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator FsmRect(Rect value)
		{
			FsmRect fsmRect = (FsmRect)new NamedVariable(string.Empty);
			fsmRect.value = value;
			fsmRect.value.y = value.y;
			fsmRect.value.width = value.width;
			fsmRect.value.height = value.height;
			return fsmRect;
		}
	}
}
