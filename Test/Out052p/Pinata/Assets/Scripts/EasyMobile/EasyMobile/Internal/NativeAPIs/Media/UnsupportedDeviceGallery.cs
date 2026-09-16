using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal.NativeAPIs.Media
{
	[Token(Token = "0x20000FA")]
	internal class UnsupportedDeviceGallery : IDeviceGallery
	{
		[Token(Token = "0x4000466")]
		private const string UnsupportedMessage = "Device gallery is not supported on this platform.";

		[Token(Token = "0x60008D6")]
		[Address(RVA = "0xC02E64", Offset = "0xC02E64", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB5CD8]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, callback, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022FB8]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, callback, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::LogWarning(\"Device gallery is not supported on this platform.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Pick(Action<string, MediaResult[]> callback)
		{
			Debug.LogWarning("Device gallery is not supported on this platform.");
		}

		[Token(Token = "0x60008D7")]
		[Address(RVA = "0xC02ED0", Offset = "0xC02ED0", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EC7E30]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, image, name, format, callback, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022FB9]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, image, name, format, callback, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::LogWarning(\"Device gallery is not supported on this platform.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SaveImage(Texture2D image, string name, ImageFormat format = ImageFormat.JPG, Action<string> callback = null)
		{
			Debug.LogWarning("Device gallery is not supported on this platform.");
		}

		[Token(Token = "0x60008D8")]
		[Address(RVA = "0xC02F3C", Offset = "0xC02F3C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F0D9B8]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, media, callback, maxSize, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022FBA]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, media, callback, maxSize, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::LogWarning(\"Device gallery is not supported on this platform.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LoadImage(MediaResult media, Action<string, Texture2D> callback, int maxSize = -1)
		{
			Debug.LogWarning("Device gallery is not supported on this platform.");
		}

		[Token(Token = "0x60008D9")]
		[Address(RVA = "0xC02FA8", Offset = "0xC02FA8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public UnsupportedDeviceGallery()
		{
		}
	}
}
