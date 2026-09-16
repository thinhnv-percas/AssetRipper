using AssetRipperInjected;
using Cpp2ILInjected;

namespace Firebase.Platform
{
	[Token(Token = "0x2000021")]
	internal class DebugLogger : ILoggingService
	{
		[Token(Token = "0x400003D")]
		internal static DebugLogger _instance;

		[Token(Token = "0x17000020")]
		public static DebugLogger Instance
		{
			[Token(Token = "0x6000088")]
			[Address(RVA = "0x15E57E0", Offset = "0x15E57E0", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB11C8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029F4C]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Firebase.Platform.DebugLogger>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Firebase.Platform.DebugLogger;\nL_0024:\n\treturn v49._instance;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return _instance;
			}
		}

		[Token(Token = "0x6000087")]
		[Address(RVA = "0x15E57D8", Offset = "0x15E57D8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DebugLogger()
		{
		}

		[Token(Token = "0x6000089")]
		[Address(RVA = "0x15E5848", Offset = "0x15E5848", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void LogMessage(PlatformLogLevel level, string message)
		{
		}

		[Token(Token = "0x600008A")]
		[Address(RVA = "0x15E584C", Offset = "0x15E584C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EFB518]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2029F4D]) = v37;\nL_0015:\n\tv41 = new Firebase.Platform.DebugLogger();\n\tSystem.Object::.ctor(v41);\n\tv45._instance = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static DebugLogger()
		{
			DebugLogger instance = new DebugLogger();
			_instance = instance;
		}
	}
}
