using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Obi
{
	[Token(Token = "0x2000016")]
	public struct StructuralConstraint
	{
		[Token(Token = "0x4000043")]
		[FieldOffset(Offset = "0x0")]
		public IStructuralConstraintBatch batchIndex;

		[Token(Token = "0x4000044")]
		[FieldOffset(Offset = "0x8")]
		public int constraintIndex;

		[Token(Token = "0x4000045")]
		[FieldOffset(Offset = "0xC")]
		public float force;

		[Token(Token = "0x17000024")]
		public unsafe float restLength
		{
			[Token(Token = "0x60001B8")]
			[Address(RVA = "0x856164", Offset = "0x856164", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x10;\n\tv2 = 0x1036094(v0, methodInfo, v4, v5, v6, v7, v8, v9, returnVal1, v11, v12, v13, v14, v15, v16, v17);\n\treturn returnVal1;\n")]
			get
			{
				//IL_000b: Expected O, but got Ref
				object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1036094 (inside Obi.ShadowmapExposer::.ctor +0x8)");
				float result = default(float);
				return result;
			}
			[Token(Token = "0x60001B9")]
			[Address(RVA = "0x85616C", Offset = "0x85616C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x10;\n\tv2 = 0x1036158(v0, methodInfo, v4, v5, v6, v7, v8, v9, value, v11, v12, v13, v14, v15, v16, v17);\n\treturn;\n")]
			set
			{
				//IL_000b: Expected O, but got Ref
				object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1036158 (inside Obi.ShadowmapExposer::.ctor +0xCC)");
			}
		}

		[Token(Token = "0x60001BA")]
		[Address(RVA = "0x856174", Offset = "0x856174", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (Obi.StructuralConstraint)+10]) = batchIndex;\n\t*([this @ X0 (Obi.StructuralConstraint)+18]) = constraintIndex;\n\t*([this @ X0 (Obi.StructuralConstraint)+1C]) = force;\n\treturn;\n\t// 4 ShiftStack -32\n\tstack[0] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX8 = *([X0]);\n\tX19 = X1;\n\t*([X19]) = X8;\n\tX8 = *([X0+8]);\n\t*([X19+8]) = X8;\n\tX8 = *([X0+10]);\n\t*([X19+10]) = X8;\n\tX8 = *([X0+14]);\n\tX0 = X0 + 0x18;\n\t*([X19+14]) = X8;\n\tX0 = 0x8D8470(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+18]) = X0;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX19 = stack[0];\n\t// 24 ShiftStack 32\n\treturn;\n\treturn;\n")]
		public StructuralConstraint(IStructuralConstraintBatch batchIndex, int constraintIndex, float force)
		{
		}
	}
}
