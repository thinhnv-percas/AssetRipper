using AssetRipperInjected;
using Cpp2ILInjected;

namespace Facebook.Unity
{
	[Token(Token = "0x200003F")]
	internal static class FBUnityUtility
	{
		[Token(Token = "0x4000072")]
		private static IAsyncRequestStringWrapper asyncRequestStringWrapper;

		[Token(Token = "0x17000052")]
		public static IAsyncRequestStringWrapper AsyncRequestStringWrapper
		{
			[Token(Token = "0x600015D")]
			[Address(RVA = "0xD2CBA0", Offset = "0xD2CBA0", Length = "0x88")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1EF3C30]);\n\tv17 = *([v16 @ X8_v13]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2023C14]) = v37;\nL_0016:\n\treturnVal1 = v41.asyncRequestStringWrapper;\n\tv43 = v41.asyncRequestStringWrapper == 0;\n\tv44 = ~v43;\n\tif (v44) goto L_002C;\n\tv48 = new Facebook.Unity.AsyncRequestStringWrapper();\n\tSystem.Object::.ctor(v48);\n\tv62.asyncRequestStringWrapper = v48;\n\treturnVal1 = v54.asyncRequestStringWrapper;\nL_002C:\n\treturn returnVal1;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				IAsyncRequestStringWrapper result = FBUnityUtility.asyncRequestStringWrapper;
				if (FBUnityUtility.asyncRequestStringWrapper == null)
				{
					AsyncRequestStringWrapper asyncRequestStringWrapper = new AsyncRequestStringWrapper();
					FBUnityUtility.asyncRequestStringWrapper = asyncRequestStringWrapper;
					result = FBUnityUtility.asyncRequestStringWrapper;
				}
				return result;
			}
		}
	}
}
