using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Token(Token = "0x2000023")]
	public abstract class ObiShapeTracker
	{
		[Token(Token = "0x400007C")]
		[FieldOffset(Offset = "0x10")]
		protected internal Component collider;

		[Token(Token = "0x400007D")]
		[FieldOffset(Offset = "0x18")]
		protected internal Oni.Shape adaptor;

		[Token(Token = "0x400007E")]
		[FieldOffset(Offset = "0x58")]
		protected internal IntPtr oniShape;

		[Token(Token = "0x1700002D")]
		public IntPtr OniShape
		{
			[Token(Token = "0x60001FE")]
			[Address(RVA = "0x10236C4", Offset = "0x10236C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.oniShape;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return OniShape;
			}
		}

		[Token(Token = "0x60001FF")]
		[Address(RVA = "0x10236CC", Offset = "0x10236CC", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EBF668]);\n\tv19 = *([v18 @ X8_v4]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026201]) = v38;\nL_0014:\n\tOni::DestroyShape(this.oniShape);\n\tthis.oniShape = 0;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void Destroy()
		{
			Oni.DestroyShape(OniShape);
			oniShape = (IntPtr)0;
		}

		[Token(Token = "0x6000200")]
		public abstract bool UpdateIfNeeded();

		[Token(Token = "0x6000201")]
		[Address(RVA = "0x10237B0", Offset = "0x10237B0", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EEF100]);\n\tv19 = *([v18 @ X8_v4]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026202]) = v38;\nL_0013:\n\tthis.oniShape = 0;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal ObiShapeTracker()
		{
			oniShape = (IntPtr)0;
		}
	}
}
