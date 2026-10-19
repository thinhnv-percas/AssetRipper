using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace AlmostEngine.Screenshot
{
	[Token(Token = "0x2000052")]
	public class iOsUtils
	{
		[DllImport("__Internal")]
		[Token(Token = "0x6000180")]
		[Address(RVA = "0x3C43C10", Offset = "0x3C43C10", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0x21C1814(file, methodInfo, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26);\n\tv28 = 0x34F7C(v10, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv34 = 0x21C1828(v10, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
		private static extern void _AddImageToGallery(string file);

		[DllImport("__Internal")]
		[Token(Token = "0x6000181")]
		[Address(RVA = "0x3C43C38", Offset = "0x3C43C38", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = 0x35058(methodInfo, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22);\n\tv27 = v6 == 0;\n\tv32 = ~v27;\n\treturn v32;\n")]
		private static extern bool _HasGalleryAuthorization();

		[DllImport("__Internal")]
		[Token(Token = "0x6000182")]
		[Address(RVA = "0x3C43C54", Offset = "0x3C43C54", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = 0x3507C(methodInfo, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16);\n\treturn;\n")]
		private static extern void _RequestGalleryAuthorization();

		[Token(Token = "0x6000183")]
		[Address(RVA = "0x3C42258", Offset = "0x3C42258", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0x21C1814(file, methodInfo, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26);\n\tv28 = 0x34F7C(v10, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv34 = 0x21C1828(v10, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
		public static void AddImageToGallery(string file)
		{
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1814");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @34F7C");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1828");
		}

		[Token(Token = "0x6000184")]
		[Address(RVA = "0x3C2EB7C", Offset = "0x3C2EB7C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = 0x35058(methodInfo, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22);\n\tv27 = v6 == 0;\n\tv32 = ~v27;\n\treturn v32;\n")]
		public static bool HasGalleryAuthorization()
		{
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @35058");
			object obj = default(object);
			bool flag = obj == null;
			return !flag;
		}

		[Token(Token = "0x6000185")]
		[Address(RVA = "0x3C43C58", Offset = "0x3C43C58", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = 0x3507C(methodInfo, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16);\n\treturn;\n")]
		public static void RequestGalleryAuthorization()
		{
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @3507C");
		}

		[Token(Token = "0x6000186")]
		[Address(RVA = "0x3C43C5C", Offset = "0x3C43C5C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public iOsUtils()
		{
		}
	}
}
