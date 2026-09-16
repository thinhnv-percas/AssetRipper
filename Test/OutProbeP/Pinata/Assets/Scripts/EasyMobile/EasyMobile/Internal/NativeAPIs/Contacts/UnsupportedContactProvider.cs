using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal.NativeAPIs.Contacts
{
	[Token(Token = "0x20000FC")]
	internal class UnsupportedContactProvider : INativeContactsProvider
	{
		[Token(Token = "0x4000467")]
		private const string UnsupportedMessage = "Contacts APIs aren't supported on this platform.";

		[Token(Token = "0x1700024D")]
		public bool IsFetchingContacts
		{
			[Token(Token = "0x60008DF")]
			[Address(RVA = "0xC005D0", Offset = "0xC005D0", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EA9018]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022F92]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\tUnityEngine.Debug::LogWarning(\"Contacts APIs aren't supported on this platform.\");\n\treturn 0;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Debug.LogWarning("Contacts APIs aren't supported on this platform.");
				return false;
			}
		}

		[Token(Token = "0x60008E0")]
		[Address(RVA = "0xC00644", Offset = "0xC00644", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE5400]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, callback, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2022F93]) = v38;\nL_0019:\n\tgoto L_0023;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0023;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, callback, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0023:\n\tUnityEngine.Debug::LogWarning(\"Contacts APIs aren't supported on this platform.\");\n\tSystem.Action`2<System.String, EasyMobile.Contact[]>::Invoke(callback, \"Contacts APIs aren't supported on this platform.\", 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void GetContacts(Action<string, Contact[]> callback)
		{
			Debug.LogWarning("Contacts APIs aren't supported on this platform.");
			callback("Contacts APIs aren't supported on this platform.", null);
		}

		[Token(Token = "0x60008E1")]
		[Address(RVA = "0xC006DC", Offset = "0xC006DC", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB2470]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, contact, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022F94]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, contact, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\tUnityEngine.Debug::LogWarning(\"Contacts APIs aren't supported on this platform.\");\n\treturn \"Contacts APIs aren't supported on this platform.\";\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string AddContact(Contact contact)
		{
			Debug.LogWarning("Contacts APIs aren't supported on this platform.");
			return "Contacts APIs aren't supported on this platform.";
		}

		[Token(Token = "0x60008E2")]
		[Address(RVA = "0xC00750", Offset = "0xC00750", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EE0620]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, id, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022F95]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, id, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\tUnityEngine.Debug::LogWarning(\"Contacts APIs aren't supported on this platform.\");\n\treturn \"Contacts APIs aren't supported on this platform.\";\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string DeleteContact(string id)
		{
			Debug.LogWarning("Contacts APIs aren't supported on this platform.");
			return "Contacts APIs aren't supported on this platform.";
		}

		[Token(Token = "0x60008E3")]
		[Address(RVA = "0xC007C4", Offset = "0xC007C4", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EE28D0]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, callback, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022F96]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, callback, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::LogWarning(\"Contacts APIs aren't supported on this platform.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void PickContact(Action<string, Contact> callback)
		{
			Debug.LogWarning("Contacts APIs aren't supported on this platform.");
		}

		[Token(Token = "0x60008E4")]
		[Address(RVA = "0xC00830", Offset = "0xC00830", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public UnsupportedContactProvider()
		{
		}
	}
}
