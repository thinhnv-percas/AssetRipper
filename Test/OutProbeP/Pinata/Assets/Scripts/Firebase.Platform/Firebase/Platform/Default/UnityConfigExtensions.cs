using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Firebase.Platform.Default
{
	[Token(Token = "0x200000A")]
	internal class UnityConfigExtensions : AppConfigExtensions
	{
		[Token(Token = "0x400001C")]
		internal new static UnityConfigExtensions _instance;

		[CompilerGenerated]
		[Token(Token = "0x400001D")]
		private static Func<string> _003C_003Ef__am_0024cache0;

		[Token(Token = "0x17000014")]
		public static IAppConfigExtensions DefaultInstance
		{
			[Token(Token = "0x6000048")]
			[Address(RVA = "0x15E5C9C", Offset = "0x15E5C9C", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EEEE10]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029F56]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Firebase.Platform.Default.UnityConfigExtensions>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Firebase.Platform.Default.UnityConfigExtensions;\nL_0024:\n\treturn v49._instance;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return _instance;
			}
		}

		[Token(Token = "0x6000047")]
		[Address(RVA = "0x15E5C34", Offset = "0x15E5C34", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE97E8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029F55]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\tSystem.Object::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public UnityConfigExtensions()
		{
		}

		[Token(Token = "0x6000049")]
		[Address(RVA = "0x15E5D04", Offset = "0x15E5D04", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EE8468]);\n\tv17 = *([v16 @ X8_v26]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, app, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2029F57]) = v37;\nL_0018:\n\tgoto L_0021;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<Firebase.Platform.Default.UnityConfigExtensions>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0021;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v40, app, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = Firebase.Platform.Default.UnityConfigExtensions;\nL_0021:\n\tv53 = v51.<>f__am$cache0 == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_0041;\n\tv59 = new System.Func`1<System.String>();\n\tSystem.Func`1<System.String>::.ctor(v59, 0, Il2CppMethodInfo);\n\tgoto L_003D;\n\tv119 = *([v98 @ X0_v15 (Il2CppClass<Firebase.Platform.Default.UnityConfigExtensions>)+E0]);\n\tv120 = v119 == 0;\n\tv121 = ~v120;\n\tif (v121) goto L_003D;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v98, v65, v63, v61, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv122 = Firebase.Platform.Default.UnityConfigExtensions;\nL_003D:\n\tv74.<>f__am$cache0 = v59;\nL_0041:\n\tgoto L_0050;\n\tv83 = *([v69 @ X0_v4 (Il2CppClass<Firebase.Platform.Default.UnityConfigExtensions>)+E0]);\n\tv84 = v83 == 0;\n\tv85 = ~v84;\n\tgoto L_0050;\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v69, v64, v62, v60, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv87 = Firebase.Platform.Default.UnityConfigExtensions;\nL_0050:\n\tgoto L_0060;\n\tv103 = *([v93 @ X8_v12+E0]);\n\tv104 = v103 == 0;\n\tv105 = ~v104;\n\tgoto L_0060;\n\tv124 = v93;\n\tv108 = \"il2cpp_codegen_runtime_class_init\"(v124, v64, v62, v60, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0060:\n\treturnVal1 = Firebase.Platform.FirebaseHandler::RunOnMainThread(v92.<>f__am$cache0);\n\treturn returnVal1;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string GetWriteablePath(IFirebaseAppPlatform app)
		{
			if (_003C_003Ef__am_0024cache0 == null)
			{
				Func<string> func = [Token(Token = "0x600004B")] [Address(RVA = "0x15E5E7C", Offset = "0x15E5E7C", Length = "0x8")] [NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Application::get_persistentDataPath();\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")] () => Application.persistentDataPath;
				_003C_003Ef__am_0024cache0 = func;
			}
			return FirebaseHandler.RunOnMainThread(_003C_003Ef__am_0024cache0);
		}

		[Token(Token = "0x600004A")]
		[Address(RVA = "0x15E5E1C", Offset = "0x15E5E1C", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EBCD98]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2029F58]) = v37;\nL_0015:\n\tv41 = new Firebase.Platform.Default.UnityConfigExtensions();\n\tFirebase.Platform.Default.UnityConfigExtensions::.ctor(v41);\n\tv44._instance = v41;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static UnityConfigExtensions()
		{
			UnityConfigExtensions instance = new UnityConfigExtensions();
			_instance = instance;
		}
	}
}
