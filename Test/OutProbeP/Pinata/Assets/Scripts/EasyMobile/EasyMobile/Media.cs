using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Token(Token = "0x200006A")]
	public static class Media
	{
		[Token(Token = "0x400027F")]
		private static IDeviceCamera sCameraClient;

		[Token(Token = "0x4000280")]
		private static IDeviceGallery sGalleryClient;

		[Token(Token = "0x17000176")]
		public static IDeviceCamera Camera
		{
			[Token(Token = "0x600050F")]
			[Address(RVA = "0xFCB848", Offset = "0xFCB848", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = *([1EF6490]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2025641]) = v35;\nL_0015:\n\treturnVal1 = v39.sCameraClient;\n\tv41 = v39.sCameraClient == 0;\n\tv42 = ~v41;\n\tif (v42) goto L_0024;\n\tv43 = EasyMobile.Media::GetCamera();\n\tv52.sCameraClient = 0;\n\treturnVal1 = v47.sCameraClient;\nL_0024:\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				IDeviceCamera result = sCameraClient;
				if (sCameraClient == null)
				{
					IDeviceCamera camera = GetCamera();
					sCameraClient = null;
					result = sCameraClient;
				}
				return result;
			}
		}

		[Token(Token = "0x17000177")]
		public static IDeviceGallery Gallery
		{
			[Token(Token = "0x6000510")]
			[Address(RVA = "0xFCB92C", Offset = "0xFCB92C", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = *([1EAA498]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2025642]) = v35;\nL_0015:\n\treturnVal1 = v39.sGalleryClient;\n\tv41 = v39.sGalleryClient == 0;\n\tv42 = ~v41;\n\tif (v42) goto L_0023;\n\tv43 = EasyMobile.Media::GetGallery();\n\tv45.sGalleryClient = 0;\n\treturnVal1 = v50.sGalleryClient;\nL_0023:\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				IDeviceGallery result = sGalleryClient;
				if (sGalleryClient == null)
				{
					IDeviceGallery gallery = GetGallery();
					sGalleryClient = null;
					result = sGalleryClient;
				}
				return result;
			}
		}

		[Token(Token = "0x6000511")]
		[Address(RVA = "0xFCB8B8", Offset = "0xFCB8B8", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EFA418]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2025643]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\tUnityEngine.Debug::LogError(\"Camera & Gallery submodule is currently disable. Please enable it to use Media.Camera API.\");\n\treturn 0;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static IDeviceCamera GetCamera()
		{
			Debug.LogError("Camera & Gallery submodule is currently disable. Please enable it to use Media.Camera API.");
			return null;
		}

		[Token(Token = "0x6000512")]
		[Address(RVA = "0xFCB998", Offset = "0xFCB998", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EE5830]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2025644]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\tUnityEngine.Debug::LogError(\"Camera & Gallery submodule is currently disable. Please enable it to use Media.Gallery API.\");\n\treturn 0;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static IDeviceGallery GetGallery()
		{
			Debug.LogError("Camera & Gallery submodule is currently disable. Please enable it to use Media.Gallery API.");
			return null;
		}
	}
}
