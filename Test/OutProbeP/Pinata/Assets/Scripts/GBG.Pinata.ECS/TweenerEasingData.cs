using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using UnityEngine;

[Serializable]
[StructLayout((LayoutKind)0, Size = 24)]
[Token(Token = "0x200002C")]
public struct TweenerEasingData
{
	[Token(Token = "0x40000A2")]
	[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
	public bool enabledAnimationCurve;

	[Token(Token = "0x40000A3")]
	[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
	public AnimationCurve animationCurve;

	[Token(Token = "0x40000A4")]
	[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
	public Ease ease;

	[Token(Token = "0x600005A")]
	[Address(RVA = "0x84D098", Offset = "0x84D098", Length = "0xF4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x10;\n\treturnVal1 = 0xCBE828(v0, tween, methodInfo, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17);\n\treturn returnVal1;\n\t// 3 ShiftStack -16\n\tstack[0] = X29;\n\tstack[8] = X30;\n\tX29 = &stack[0];\n\tX0 = X0 + 0x61A;\n\tX0 = 0x8D82DC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t// 13 ShiftStack -16\n\tstack[0] = X29;\n\tstack[8] = X30;\n\tX29 = &stack[0];\n\tX0 = X0 + 0x61A;\n\tX0 = 0x8D82DC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n\t// 24 ShiftStack -16\n\tstack[0] = X29;\n\tstack[8] = X30;\n\tX29 = &stack[0];\n\tX0 = X0 + 0x698;\n\tX0 = 0x8D82DC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t// 34 ShiftStack -16\n\tstack[0] = X29;\n\tstack[8] = X30;\n\tX29 = &stack[0];\n\tX0 = X0 + 0x698;\n\tX0 = 0x8D82DC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n\tX8 = *([X0]);\n\t*([X1]) = X8;\n\tX8 = *([X0+4]);\n\t*([X1+4]) = X8;\n\tX8 = *([X0+8]);\n\t*([X1+8]) = X8;\n\tX8 = *([X0+C]);\n\t*([X1+C]) = X8;\n\tX8 = *([X0+10]);\n\t*([X1+10]) = X8;\n\treturn X0;\n\tX8 = *([X0]);\n\tC = X8 < 0;\n\tC = ~C;\n\tTEMP1 = X8 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 0;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tX8 = TEMPCOND;\n\t*([X1]) = X8;\n\tX8 = *([X0+4]);\n\t*([X1+4]) = X8;\n\tX8 = *([X0+8]);\n\t*([X1+8]) = X8;\n\tX8 = *([X0+C]);\n\t*([X1+C]) = X8;\n\tX8 = *([X0+10]);\n\t*([X1+10]) = X8;\n\treturn X0;\n\treturn X0;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe Tweener DoEase(Tweener tween)
	{
		//IL_000b: Expected O, but got Ref
		object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @CBE828 (inside ButtonScaleAnimator::OnPointerDown +0x54)");
		Tweener result = default(Tweener);
		return result;
	}
}
