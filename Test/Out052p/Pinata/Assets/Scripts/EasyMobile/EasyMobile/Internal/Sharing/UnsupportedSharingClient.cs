using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal.Sharing
{
	[Token(Token = "0x20000D5")]
	internal class UnsupportedSharingClient : ISharingClient
	{
		[Token(Token = "0x40003C4")]
		private const string UNSUPPORTED_MESSAGE = "Sharing is not supported on this platform. Please test on an iOS or Android device.";

		[Token(Token = "0x60007A3")]
		[Address(RVA = "0xB52768", Offset = "0xB52768", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EE81D8]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, imagePath, message, subject, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202279D]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, imagePath, message, subject, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::Log(\"Sharing is not supported on this platform. Please test on an iOS or Android device.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ShareImage(string imagePath, string message, string subject = "")
		{
			Debug.Log("Sharing is not supported on this platform. Please test on an iOS or Android device.");
		}

		[Token(Token = "0x60007A4")]
		[Address(RVA = "0xB527D4", Offset = "0xB527D4", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF4FD0]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, text, subject, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202279E]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, text, subject, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::Log(\"Sharing is not supported on this platform. Please test on an iOS or Android device.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ShareText(string text, string subject = "")
		{
			Debug.Log("Sharing is not supported on this platform. Please test on an iOS or Android device.");
		}

		[Token(Token = "0x60007A5")]
		[Address(RVA = "0xB52840", Offset = "0xB52840", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EBEC38]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, url, subject, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202279F]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, url, subject, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::Log(\"Sharing is not supported on this platform. Please test on an iOS or Android device.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ShareURL(string url, string subject = "")
		{
			Debug.Log("Sharing is not supported on this platform. Please test on an iOS or Android device.");
		}

		[Token(Token = "0x60007A6")]
		[Address(RVA = "0xB528AC", Offset = "0xB528AC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public UnsupportedSharingClient()
		{
		}
	}
}
