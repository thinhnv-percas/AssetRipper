using System.Security.Cryptography.X509Certificates;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Firebase.Platform
{
	[Token(Token = "0x200001D")]
	internal class NoopCertificateService : ICertificateService
	{
		[Token(Token = "0x400003C")]
		internal static NoopCertificateService _instance;

		[Token(Token = "0x1700001F")]
		public static NoopCertificateService Instance
		{
			[Token(Token = "0x6000083")]
			[Address(RVA = "0x15E85D4", Offset = "0x15E85D4", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EE8DE8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029F7D]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Firebase.Platform.NoopCertificateService>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Firebase.Platform.NoopCertificateService;\nL_0024:\n\treturn v49._instance;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return _instance;
			}
		}

		[Token(Token = "0x6000082")]
		[Address(RVA = "0x15E85CC", Offset = "0x15E85CC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public NoopCertificateService()
		{
		}

		[Token(Token = "0x6000084")]
		[Address(RVA = "0x15E863C", Offset = "0x15E863C", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1F08460]);\n\tv17 = *([v16 @ X8_v21]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, app, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2029F7E]) = v37;\nL_0018:\n\tgoto L_0022;\n\tv44 = *([v40 @ X0_v2+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0022;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, app, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0022:\n\tgoto L_002D;\n\tv56 = *([1F0BA98]);\n\tv57 = *([v56 @ X8_v17]);\n\tv58 = \"il2cpp_codegen_initialize_method\"(v57, app, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv61 = 0 | 1;\n\t*([2029FC4]) = v61;\nL_002D:\n\tgoto L_0041;\n\tv66 = *([v62 @ X0_v5 (Il2CppClass<Firebase.Platform.Services>)+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\t// 49 Jump @b23\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v62, app, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv70 = Firebase.Platform.Services;\nL_0041:\n\tgoto L_006A;\n\tv88 = *([v78 @ X8_v10+B0]);\n\tv89 = 0;\n\tv90 = v88 + 8;\n\tv92 = *([v139 @ X11_v5-8]);\n\tv145 = v92 == v81;\n\tif (v145) goto L_0061;\n\tv125 = v140 + 1;\n\tv200 = v125 < v83;\n\tv119 = ~v200;\n\tv122 = v139 + 0x10;\n\tv95 = ~v119;\n\tif (v95) goto L_FFFFFFFF;\n\tv126 = v74;\n\tv127 = 0;\n\tv128 = 0x8909C4(v126, v81, v127, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tgoto L_006A;\nL_0061:\n\tv201 = *([v139 @ X11_v5]);\n\tv202 = v201 << 4;\n\tv203 = v78 + v202;\n\tv204 = v203 + 0x130;\nL_006A:\n\tFirebase.Platform.ILoggingService::LogMessage(v73.<Logging>k__BackingField, 3, \"No certs are being installed because the platform doesn't support it.\");\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public X509CertificateCollection Install(IFirebaseAppPlatform app)
		{
			Services.Logging.LogMessage(PlatformLogLevel.Warning, "No certs are being installed because the platform doesn't support it.");
			return null;
		}

		[Token(Token = "0x6000085")]
		[Address(RVA = "0x15E876C", Offset = "0x15E876C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1F08980]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2029F7F]) = v37;\nL_0015:\n\tv41 = new Firebase.Platform.NoopCertificateService();\n\tSystem.Object::.ctor(v41);\n\tv45._instance = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static NoopCertificateService()
		{
			NoopCertificateService instance = new NoopCertificateService();
			_instance = instance;
		}
	}
}
