using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Firebase.Platform
{
	[Token(Token = "0x2000029")]
	internal class FirebaseAppUtilsStub : IFirebaseAppUtils
	{
		[Token(Token = "0x4000054")]
		internal static FirebaseAppUtilsStub _instance;

		[Token(Token = "0x17000029")]
		public static FirebaseAppUtilsStub Instance
		{
			[Token(Token = "0x60000AA")]
			[Address(RVA = "0x15E5E8C", Offset = "0x15E5E8C", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EFB430]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029F59]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Firebase.Platform.FirebaseAppUtilsStub>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Firebase.Platform.FirebaseAppUtilsStub;\nL_0024:\n\treturn v49._instance;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return _instance;
			}
		}

		[Token(Token = "0x60000A9")]
		[Address(RVA = "0x15E5E84", Offset = "0x15E5E84", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FirebaseAppUtilsStub()
		{
		}

		[Token(Token = "0x60000AB")]
		[Address(RVA = "0x15E5EF4", Offset = "0x15E5EF4", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Action::Invoke(action);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void TranslateDllNotFoundException(Action action)
		{
			action();
		}

		[Token(Token = "0x60000AC")]
		[Address(RVA = "0x15E5F14", Offset = "0x15E5F14", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void PollCallbacks()
		{
		}

		[Token(Token = "0x60000AD")]
		[Address(RVA = "0x15E5F18", Offset = "0x15E5F18", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IFirebaseAppPlatform GetDefaultInstance()
		{
			return null;
		}

		[Token(Token = "0x60000AE")]
		[Address(RVA = "0x15E5F20", Offset = "0x15E5F20", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1F10490]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029F5A]) = v35;\nL_0018:\n\treturn \"__FIRAPP_DEFAULT\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetDefaultInstanceName()
		{
			return "__FIRAPP_DEFAULT";
		}

		[Token(Token = "0x60000AF")]
		[Address(RVA = "0x15E5F68", Offset = "0x15E5F68", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PlatformLogLevel GetLogLevel()
		{
			return PlatformLogLevel.Debug;
		}

		[Token(Token = "0x60000B0")]
		[Address(RVA = "0x15E5F70", Offset = "0x15E5F70", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EC5ED0]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2029F5B]) = v37;\nL_0015:\n\tv41 = new Firebase.Platform.FirebaseAppUtilsStub();\n\tSystem.Object::.ctor(v41);\n\tv45._instance = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static FirebaseAppUtilsStub()
		{
			FirebaseAppUtilsStub instance = new FirebaseAppUtilsStub();
			_instance = instance;
		}
	}
}
