using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening.Plugins.Options
{
	[StructLayout((LayoutKind)0, Size = 20)]
	[Token(Token = "0x2000032")]
	public struct QuaternionOptions : IPlugOptions
	{
		[Token(Token = "0x40000EF")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public RotateMode rotateMode;

		[Token(Token = "0x40000F0")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		public AxisConstraint axisConstraint;

		[Token(Token = "0x40000F1")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		public Vector3 up;

		[Token(Token = "0x6000223")]
		[Address(RVA = "0x856874", Offset = "0x856874", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x10;\n\tv2 = 0x1084D58(v0, methodInfo, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17);\n\treturn;\n\tX8 = *([X0]);\n\t*([X1]) = X8;\n\treturn;\n\tX8 = *([X0]);\n\tC = X8 < 0;\n\tC = ~C;\n\tTEMP1 = X8 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 0;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tX8 = TEMPCOND;\n\t*([X1]) = X8;\n\treturn;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Reset()
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1084D58 (inside DG.Tweening.Plugins.LongPlugin::.ctor +0x134)");
		}
	}
}
