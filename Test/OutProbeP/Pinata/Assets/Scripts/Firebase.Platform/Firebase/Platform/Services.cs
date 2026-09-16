using System.Diagnostics;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Firebase.Platform.Default;

namespace Firebase.Platform
{
	[Token(Token = "0x2000022")]
	public static class Services
	{
		[CompilerGenerated]
		[Attribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72B478", Offset = "0x72B478")]
		[Token(Token = "0x400003F")]
		private static IAuthService _003CAuth_003Ek__BackingField;

		[Attribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72B4F0", Offset = "0x72B4F0")]
		[CompilerGenerated]
		[Token(Token = "0x4000041")]
		private static IClockService _003CClock_003Ek__BackingField;

		[Attribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72B52C", Offset = "0x72B52C")]
		[CompilerGenerated]
		[Token(Token = "0x4000042")]
		internal static IHttpFactoryService _003CHttpFactory_003Ek__BackingField;

		[Token(Token = "0x17000021")]
		[field: Attribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72B43C", Offset = "0x72B43C")]
		[field: Token(Token = "0x400003E")]
		public static IAppConfigExtensions AppConfig
		{
			[Token(Token = "0x600008C")]
			[Address(RVA = "0x15E8E00", Offset = "0x15E8E00", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EA5CB8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029F85]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Firebase.Platform.Services>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Firebase.Platform.Services;\nL_0024:\n\treturn v49.<AppConfig>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x600008D")]
			[Address(RVA = "0x15E8E68", Offset = "0x15E8E68", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF3728]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029F86]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Firebase.Platform.Services>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = Firebase.Platform.Services;\nL_0021:\n\tv52.<AppConfig>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal set;
		}

		[Token(Token = "0x17000022")]
		internal static IAuthService Auth
		{
			[CompilerGenerated]
			[Token(Token = "0x600008E")]
			[Address(RVA = "0x15E8ED4", Offset = "0x15E8ED4", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EA86C0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029F87]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Firebase.Platform.Services>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = Firebase.Platform.Services;\nL_0021:\n\tv52.<Auth>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_003CAuth_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000023")]
		[field: Attribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72B4B4", Offset = "0x72B4B4")]
		[field: Token(Token = "0x4000040")]
		public static ICertificateService RootCerts
		{
			[Token(Token = "0x600008F")]
			[Address(RVA = "0x15E8F40", Offset = "0x15E8F40", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EEF7F8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029F88]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Firebase.Platform.Services>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Firebase.Platform.Services;\nL_0024:\n\treturn v49.<RootCerts>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000090")]
			[Address(RVA = "0x15E8FA8", Offset = "0x15E8FA8", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EBE588]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029F89]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Firebase.Platform.Services>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = Firebase.Platform.Services;\nL_0021:\n\tv52.<RootCerts>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal set;
		}

		[Token(Token = "0x17000024")]
		internal static IClockService Clock
		{
			[CompilerGenerated]
			[Token(Token = "0x6000091")]
			[Address(RVA = "0x15E9014", Offset = "0x15E9014", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EFA300]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029F8A]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Firebase.Platform.Services>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = Firebase.Platform.Services;\nL_0021:\n\tv52.<Clock>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_003CClock_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000025")]
		internal static IHttpFactoryService HttpFactory
		{
			[CompilerGenerated]
			[Token(Token = "0x6000092")]
			[Address(RVA = "0x15E9080", Offset = "0x15E9080", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F056E0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029F8B]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Firebase.Platform.Services>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = Firebase.Platform.Services;\nL_0021:\n\tv52.<HttpFactory>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_003CHttpFactory_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000026")]
		[field: Attribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72B568", Offset = "0x72B568")]
		[field: Token(Token = "0x4000043")]
		public static ILoggingService Logging
		{
			[Token(Token = "0x6000093")]
			[Address(RVA = "0x15E90EC", Offset = "0x15E90EC", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EA95A8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029F8C]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Firebase.Platform.Services>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Firebase.Platform.Services;\nL_0024:\n\treturn v49.<Logging>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000094")]
			[Address(RVA = "0x15E9154", Offset = "0x15E9154", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED4598]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029F8D]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Firebase.Platform.Services>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = Firebase.Platform.Services;\nL_0021:\n\tv52.<Logging>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal set;
		}

		[Token(Token = "0x600008B")]
		[Address(RVA = "0x15E8A80", Offset = "0x15E8A80", Length = "0x380")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F00D18]);\n\tv19 = *([v18 @ X8_v96]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2029F84]) = v39;\nL_0019:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tgoto L_002E;\n\tv58 = *([1ED24D8]);\n\tv59 = *([v58 @ X8_v92]);\n\tv60 = \"il2cpp_codegen_initialize_method\"(v59, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv63 = 0 | 1;\n\t*([2029FC5]) = v63;\nL_002E:\n\tgoto L_003B;\n\tv68 = *([v64 @ X0_v5 (Il2CppClass<Firebase.Platform.Default.AppConfigExtensions>)+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tgoto L_003B;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v64, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv72 = Firebase.Platform.Default.AppConfigExtensions;\nL_003B:\n\tgoto L_0048;\n\tv83 = *([1EE1EB8]);\n\tv84 = *([v83 @ X8_v88]);\n\tv85 = \"il2cpp_codegen_initialize_method\"(v84, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv88 = 0 | 1;\n\t*([2029FC6]) = v88;\nL_0048:\n\tgoto L_0050;\n\tv95 = *([v91 @ X0_v8 (Il2CppClass<Firebase.Platform.Services>)+E0]);\n\tv96 = v95 == 0;\n\tv97 = ~v96;\n\tgoto L_0050;\n\tv109 = \"il2cpp_codegen_runtime_class_init\"(v91, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv99 = Firebase.Platform.Services;\nL_0050:\n\tv102.<AppConfig>k__BackingField = v75._instance;\n\tgoto L_0061;\n\tv110 = *([v105 @ X0_v10+E0]);\n\tv111 = v110 == 0;\n\tv112 = ~v111;\n\tgoto L_0061;\n\tv114 = \"il2cpp_codegen_runtime_class_init\"(v105, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0061:\n\tgoto L_006C;\n\tv122 = *([1ECE320]);\n\tv123 = *([v122 @ X8_v83]);\n\tv124 = \"il2cpp_codegen_initialize_method\"(v123, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv127 = 0 | 1;\n\t*([2029FC7]) = v127;\nL_006C:\n\tgoto L_0079;\n\tv132 = *([v128 @ X0_v13 (Il2CppClass<Firebase.Platform.Default.BaseAuthService>)+E0]);\n\tv133 = v132 == 0;\n\tv134 = ~v133;\n\tgoto L_0079;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v128, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv136 = Firebase.Platform.Default.BaseAuthService;\nL_0079:\n\tgoto L_0084;\n\tv147 = *([1F024B8]);\n\tv148 = *([v147 @ X8_v79]);\n\tv149 = \"il2cpp_codegen_initialize_method\"(v148, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv152 = 0 | 1;\n\t*([2029FC8]) = v152;\nL_0084:\n\tgoto L_008C;\n\tv157 = *([v153 @ X0_v16 (Il2CppClass<Firebase.Platform.Services>)+E0]);\n\tv158 = v157 == 0;\n\tv159 = ~v158;\n\tgoto L_008C;\n\tv171 = \"il2cpp_codegen_runtime_class_init\"(v153, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv161 = Firebase.Platform.Services;\nL_008C:\n\tv164.<Auth>k__BackingField = v139._instance;\n\tgoto L_009D;\n\tv172 = *([v167 @ X0_v18+E0]);\n\tv173 = v172 == 0;\n\tv174 = ~v173;\n\tgoto L_009D;\n\tv176 = \"il2cpp_codegen_runtime_class_init\"(v167, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_009D:\n\tgoto L_00A8;\n\tv184 = *([1F051F8]);\n\tv185 = *([v184 @ X8_v74]);\n\tv186 = \"il2cpp_codegen_initialize_method\"(v185, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv189 = 0 | 1;\n\t*([2029FC9]) = v189;\nL_00A8:\n\tgoto L_00B5;\n\tv194 = *([v190 @ X0_v21 (Il2CppClass<Firebase.Platform.NoopCertificateService>)+E0]);\n\tv195 = v194 == 0;\n\tv196 = ~v195;\n\tgoto L_00B5;\n\tv207 = \"il2cpp_codegen_runtime_class_init\"(v190, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv198 = Firebase.Platform.NoopCertificateService;\nL_00B5:\n\tgoto L_00C0;\n\tv209 = *([1EFC818]);\n\tv210 = *([v209 @ X8_v70]);\n\tv211 = \"il2cpp_codegen_initialize_method\"(v210, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv214 = 0 | 1;\n\t*([2029FCA]) = v214;\nL_00C0:\n\tgoto L_00C8;\n\tv219 = *([v215 @ X0_v24 (Il2CppClass<Firebase.Platform.Services>)+E0]);\n\tv220 = v219 == 0;\n\tv221 = ~v220;\n\tgoto L_00C8;\n\tv233 = \"il2cpp_codegen_runtime_class_init\"(v215, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv223 = Firebase.Platform.Services;\nL_00C8:\n\tv226.<RootCerts>k__BackingField = v201._instance;\n\tgoto L_00DC;\n\tv234 = *([v229 @ X0_v26 (Il2CppClass<Firebase.Platform.Default.SystemClock>)+E0]);\n\tv235 = v234 == 0;\n\tv236 = ~v235;\n\tgoto L_00DC;\n\tv247 = \"il2cpp_codegen_runtime_class_init\"(v229, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv238 = Firebase.Platform.Default.SystemClock;\nL_00DC:\n\tgoto L_00E7;\n\tv249 = *([1EFCDA0]);\n\tv250 = *([v249 @ X8_v65]);\n\tv251 = \"il2cpp_codegen_initialize_method\"(v250, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv254 = 0 | 1;\n\t*([2029FCB]) = v254;\nL_00E7:\n\tgoto L_00EF;\n\tv259 = *([v255 @ X0_v29 (Il2CppClass<Firebase.Platform.Services>)+E0]);\n\tv260 = v259 == 0;\n\tv261 = ~v260;\n\tgoto L_00EF;\n\tv273 = \"il2cpp_codegen_runtime_class_init\"(v255, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv263 = Firebase.Platform.Services;\nL_00EF:\n\tv266.<Clock>k__BackingField = v241.Instance;\n\tgoto L_0100;\n\tv274 = *([v269 @ X0_v31+E0]);\n\tv275 = v274 == 0;\n\tv276 = ~v275;\n\tgoto L_0100;\n\tv278 = \"il2cpp_codegen_runtime_class_init\"(v269, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0100:\n\tgoto L_010B;\n\tv286 = *([1EF0548]);\n\tv287 = *([v286 @ X8_v60]);\n\tv288 = \"il2cpp_codegen_initialize_method\"(v287, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv291 = 0 | 1;\n\t*([2029FCC]) = v291;\nL_010B:\n\tgoto L_0118;\n\tv296 = *([v292 @ X0_v34 (Il2CppClass<Firebase.Platform.DebugLogger>)+E0]);\n\tv297 = v296 == 0;\n\tv298 = ~v297;\n\tgoto L_0118;\n\tv309 = \"il2cpp_codegen_runtime_class_init\"(v292, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv300 = Firebase.Platform.DebugLogger;\nL_0118:\n\tgoto L_0123;\n\tv311 = *([1EE3B78]);\n\tv312 = *([v311 @ X8_v56]);\n\tv313 = \"il2cpp_codegen_initialize_method\"(v312, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv316 = 0 | 1;\n\t*([2029FCD]) = v316;\nL_0123:\n\tgoto L_012B;\n\tv321 = *([v317 @ X0_v37 (Il2CppClass<Firebase.Platform.Services>)+E0]);\n\tv322 = v321 == 0;\n\tv323 = ~v322;\n\tgoto L_012B;\n\tv334 = \"il2cpp_codegen_runtime_class_init\"(v317, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv325 = Firebase.Platform.Services;\nL_012B:\n\tv328.<Logging>k__BackingField = v303._instance;\n\treturn;\n// 147 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static Services()
		{
			AppConfig = AppConfigExtensions._instance;
			_003CAuth_003Ek__BackingField = BaseAuthService._instance;
			RootCerts = NoopCertificateService._instance;
			_003CClock_003Ek__BackingField = SystemClock.Instance;
			Logging = DebugLogger._instance;
		}
	}
}
