using AssetRipperInjected;
using Cpp2ILInjected;
using Firebase.Platform;

namespace Firebase.Unity
{
	[Token(Token = "0x200000C")]
	internal class UnityLoggingService : ILoggingService
	{
		[Token(Token = "0x400001F")]
		internal static UnityLoggingService _instance;

		[Token(Token = "0x17000016")]
		public static UnityLoggingService Instance
		{
			[Token(Token = "0x6000050")]
			[Address(RVA = "0x15EC328", Offset = "0x15EC328", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF1DA8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029FAD]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Firebase.Unity.UnityLoggingService>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Firebase.Unity.UnityLoggingService;\nL_0024:\n\treturn v49._instance;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return _instance;
			}
		}

		[Token(Token = "0x600004F")]
		[Address(RVA = "0x15EC320", Offset = "0x15EC320", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public UnityLoggingService()
		{
		}

		[Token(Token = "0x6000051")]
		[Address(RVA = "0x15EC390", Offset = "0x15EC390", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EF3E90]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, level, message, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([2029FAE]) = v41;\nL_001B:\n\tgoto L_0029;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0029;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, level, message, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0029:\n\tFirebase.Platform.FirebaseLogger::LogMessage(level, message);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LogMessage(PlatformLogLevel level, string message)
		{
			FirebaseLogger.LogMessage(level, message);
		}

		[Token(Token = "0x6000052")]
		[Address(RVA = "0x15EC404", Offset = "0x15EC404", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1F08068]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2029FAF]) = v37;\nL_0015:\n\tv41 = new Firebase.Unity.UnityLoggingService();\n\tSystem.Object::.ctor(v41);\n\tv45._instance = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static UnityLoggingService()
		{
			UnityLoggingService instance = new UnityLoggingService();
			_instance = instance;
		}
	}
}
