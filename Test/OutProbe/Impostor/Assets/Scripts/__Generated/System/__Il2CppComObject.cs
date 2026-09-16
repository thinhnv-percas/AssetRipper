using AssetRipperInjected;
using Cpp2ILInjected;

namespace System
{
	[Token(Token = "0x2000002")]
	internal class __Il2CppComObject
	{
		[Token(Token = "0x6000002")]
		[Address(RVA = "0x1850BD8", Offset = "0x1850BD8", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = *([this @ X0 (System.__Il2CppComObject)+10]) == 0;\n\tif (v7) goto L_0013;\n\tv9 = 0xAD98B0(this, methodInfo, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24);\n\tv33 = *([this @ X0 (System.__Il2CppComObject)+10]);\n\tv34 = *([v33 @ X0_v5]);\n\t*([v34 @ X8_v3+10])(v26, v33, methodInfo, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24);\n\t*([this @ X0 (System.__Il2CppComObject)+10]) = 0;\nL_0013:\n\tSystem.Object::Finalize(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		extern ~__Il2CppComObject();
	}
}
