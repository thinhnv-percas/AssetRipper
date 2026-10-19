using AssetRipperInjected;
using Cpp2ILInjected;

namespace AlmostEngine.Screenshot
{
	[Token(Token = "0x2000048")]
	public class GalleryUtils
	{
		[Token(Token = "0x6000163")]
		[Address(RVA = "0x3C4217C", Offset = "0x3C4217C", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0x21C1814(fullpath, methodInfo, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26);\n\tv28 = 0x34F7C(v10, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv30 = 0x21C1828(v10, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn 1;\n")]
		public static bool AddToGallery(string fullpath)
		{
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1814");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @34F7C");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1828");
			return true;
		}

		[Token(Token = "0x6000164")]
		[Address(RVA = "0x3C42280", Offset = "0x3C42280", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public GalleryUtils()
		{
		}
	}
}
