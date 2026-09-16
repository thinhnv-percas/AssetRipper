using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile.Internal.GameServices
{
	[Token(Token = "0x2000102")]
	internal class EditorRealTimeMultiplayerClient : UnsupportedRealTimeMultiplayerClient
	{
		[Token(Token = "0x1700024F")]
		protected override string mUnavailableMessage
		{
			[Token(Token = "0x60008FB")]
			[Address(RVA = "0xBFBA30", Offset = "0xBFBA30", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EB2730]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022F2F]) = v35;\nL_0018:\n\treturn \"Please test Real-Time multiplayer functionalities on an iOS or Android device.\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "Please test Real-Time multiplayer functionalities on an iOS or Android device.";
			}
		}

		[Token(Token = "0x60008FC")]
		[Address(RVA = "0xBFBA78", Offset = "0xBFBA78", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EditorRealTimeMultiplayerClient()
		{
		}
	}
}
