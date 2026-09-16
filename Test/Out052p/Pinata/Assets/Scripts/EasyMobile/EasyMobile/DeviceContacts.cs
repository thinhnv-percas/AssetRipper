using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.Internal.NativeAPIs.Contacts;
using UnityEngine;

namespace EasyMobile
{
	[Token(Token = "0x2000065")]
	public static class DeviceContacts
	{
		[Token(Token = "0x4000273")]
		internal static INativeContactsProvider sNativeProvider;

		[Token(Token = "0x4000274")]
		private const string InvalidNameMessage = "Name can't be null or empty.";

		[Token(Token = "0x4000275")]
		private const string InvalidPhonenumber = "Phone number can't be null or empty.";

		[Token(Token = "0x4000276")]
		private const string InvalidContactMessage = "Contact can't be null.";

		[Token(Token = "0x4000277")]
		private const string InvalidContactIdMessage = "Can't delete a contact with null id.";

		[Token(Token = "0x4000278")]
		private const string NullContactsProviderMessage = "The contacts provider hasn't been initialized.";

		[Token(Token = "0x17000174")]
		private static INativeContactsProvider NativeProvider
		{
			[Token(Token = "0x6000500")]
			[Address(RVA = "0xA54F64", Offset = "0xA54F64", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EBEC10]);\n\tv15 = *([v14 @ X8_v19]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021FA0]) = v35;\nL_0017:\n\tgoto L_0020;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.DeviceContacts>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0020;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = EasyMobile.DeviceContacts;\nL_0020:\n\tv51 = v49.sNativeProvider == 0;\n\tv52 = ~v51;\n\tif (v52) goto L_0034;\n\tgoto L_002C;\n\tv66 = *([v45 @ X0_v3 (Il2CppClass<EasyMobile.DeviceContacts>)+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tif (v68) goto L_002C;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v45, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_002C:\n\tv72 = EasyMobile.DeviceContacts::GetNativeContactsProvider();\n\tv62.sNativeProvider = 0;\nL_0034:\n\tgoto L_0041;\n\tv73 = *([v57 @ X0_v4 (Il2CppClass<EasyMobile.DeviceContacts>)+E0]);\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tgoto L_0041;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v57, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv77 = EasyMobile.DeviceContacts;\nL_0041:\n\treturn v80.sNativeProvider;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (sNativeProvider == null)
				{
					INativeContactsProvider nativeContactsProvider = GetNativeContactsProvider();
					sNativeProvider = null;
				}
				return sNativeProvider;
			}
		}

		[Token(Token = "0x17000175")]
		public static bool IsFetchingContacts
		{
			[Token(Token = "0x6000501")]
			[Address(RVA = "0xA5508C", Offset = "0xA5508C", Length = "0xFC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB8990]);\n\tv15 = *([v14 @ X8_v14]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021FA1]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.DeviceContacts>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\treturnVal1 = EasyMobile.DeviceContacts::get_NativeProvider();\n\tv50 = ~returnVal1;\n\tif (v50) goto L_0058;\n\tgoto L_002A;\n\tv58 = *([v51 @ X0_v5 (Il2CppClass<EasyMobile.DeviceContacts>)+E0]);\n\tv59 = v58 == 0;\n\tv60 = ~v59;\n\tif (v60) goto L_002A;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v51, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_002A:\n\tv65 = EasyMobile.DeviceContacts::get_NativeProvider();\n\tgoto L_0064;\n\tv132 = *([v128 @ X8_v7+B0]);\n\tv133 = 0;\n\tv134 = v132 + 8;\n\tv136 = *([v172 @ X11_v5-8]);\n\tv178 = v136 == v131;\n\tif (v178) goto L_0059;\n\tv158 = v173 + 1;\n\tv183 = v158 < v130;\n\tv154 = ~v183;\n\tv156 = v172 + 0x10;\n\tv138 = ~v154;\n\tif (v138) goto L_FFFFFFFF;\n\tv159 = v124;\n\tv160 = 0;\n\tv161 = 0x8909C4(v159, v131, v160, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tgoto L_0064;\nL_0058:\n\treturn returnVal1;\nL_0059:\n\tv184 = *([v172 @ X11_v5]);\n\tv185 = v184 << 4;\n\tv186 = v128 + v185;\n\tv187 = v186 + 0x130;\nL_0064:\n\tinterfaceTailCallResult = EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider::get_IsFetchingContacts(v65);\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000e: Expected I4, but got O
				bool flag = (byte)(int)NativeProvider != 0;
				if (flag)
				{
					INativeContactsProvider nativeProvider = NativeProvider;
					return nativeProvider.IsFetchingContacts;
				}
				return flag;
			}
		}

		[Token(Token = "0x6000502")]
		[Address(RVA = "0xA55188", Offset = "0xA55188", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F02AF8]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021FA2]) = v38;\nL_0013:\n\tv39 = callback == 0;\n\tif (v39) goto L_005D;\n\tgoto L_0021;\n\tv50 = *([v42 @ X0_v2 (Il2CppClass<EasyMobile.DeviceContacts>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tif (v52) goto L_0021;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0021:\n\tv57 = EasyMobile.DeviceContacts::get_NativeProvider();\n\tv118 = v57 == 0;\n\tif (v118) goto L_006B;\n\tgoto L_002E;\n\tv141 = *([v135 @ X0_v6 (Il2CppClass<EasyMobile.DeviceContacts>)+E0]);\n\tv142 = v141 == 0;\n\tv143 = ~v142;\n\tif (v143) goto L_002E;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v135, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002E:\n\tv147 = EasyMobile.DeviceContacts::get_NativeProvider();\n\tv149 = *([v147 @ X0_v8 (EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider)]);\n\tv119 = *([v149 @ X8_v9 (Il2CppClass<EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider>)+126]) == 0;\n\tif (v119) goto L_0056;\n\tv193 = *([v149 @ X8_v9 (Il2CppClass<EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider>)+B0]) + 8;\nL_0041:\n\tv199 = *([v193 @ X11_v5-8]) == EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider;\n\tif (v199) goto L_006E;\n\tv194 = v194 + 1;\n\tv204 = v194 < *([v149 @ X8_v9 (Il2CppClass<EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider>)+126]);\n\tv175 = ~v204;\n\tv193 = v193 + 0x10;\n\tv159 = ~v175;\n\tif (v159) goto L_0041;\nL_0056:\n\tv211 = 0x8909C4(v147, EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider, 1, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0072;\nL_005D:\n\treturn;\nL_006B:\n\tSystem.Action`2<System.String, EasyMobile.Contact[]>::Invoke(callback, \"The contacts provider hasn't been initialized.\", 0);\n\treturn;\nL_006E:\n\tv206 = *([v193 @ X11_v5]) + 1;\n\tv207 = v206 << 4;\n\tv208 = v149 + v207;\n\tv211 = v208 + 0x130;\nL_0072:\n\tv66 = *([v211 @ X0_v10]);\n\tv72 = *([v211 @ X0_v10+8]);\n\t// 123 IndirectJump v66 @ X3_v2, v147 @ X0_v8 (EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider), v147 @ X0_v8 (EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider), callback @ X0 (System.Action`2<System.String, EasyMobile.Contact[]>), v72 @ X2_v3, v66 @ X3_v2, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void GetContacts(Action<string, Contact[]> callback)
		{
			//IL_004b: Expected I, but got O
			//IL_01a9: Expected O, but got I
			//IL_0086: Expected O, but got I
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Expected O, but got Unknown
			//IL_0136: Expected O, but got I
			//IL_0145: Expected O, but got I
			//IL_00d2: Expected O, but got I
			if (callback == null)
			{
				return;
			}
			INativeContactsProvider nativeProvider = NativeProvider;
			object obj4 = default(object);
			if (nativeProvider != null)
			{
				INativeContactsProvider nativeProvider2 = NativeProvider;
				IntPtr intPtr = (IntPtr)nativeProvider2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ X8_v9 (Il2CppClass<EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00eb;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ X8_v9 (Il2CppClass<EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(INativeContactsProvider))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ X8_v9 (Il2CppClass<EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00eb;
				}
				object obj2 = obj + 1;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_0191;
			}
			callback("The contacts provider hasn't been initialized.", null);
			return;
			IL_00eb:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0191;
			IL_0191:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ X0_v10+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v66 @ X3_v2 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000503")]
		[Address(RVA = "0xA552C0", Offset = "0xA552C0", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EDFF68]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021FA3]) = v38;\nL_0013:\n\tv39 = contact == 0;\n\tif (v39) goto L_0053;\n\tgoto L_0021;\n\tv53 = *([v42 @ X0_v3 (Il2CppClass<EasyMobile.DeviceContacts>)+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0021:\n\tv60 = EasyMobile.DeviceContacts::get_NativeProvider();\n\tv127 = *([v60 @ X0_v5 (EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider)]);\n\tv115 = *([v127 @ X8_v9 (Il2CppClass<EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider>)+126]) == 0;\n\tif (v115) goto L_0049;\n\tv171 = *([v127 @ X8_v9 (Il2CppClass<EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider>)+B0]) + 8;\nL_0034:\n\tv177 = *([v171 @ X11_v5-8]) == EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider;\n\tif (v177) goto L_0055;\n\tv172 = v172 + 1;\n\tv182 = v172 < *([v127 @ X8_v9 (Il2CppClass<EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider>)+126]);\n\tv153 = ~v182;\n\tv171 = v171 + 0x10;\n\tv137 = ~v153;\n\tif (v137) goto L_0034;\nL_0049:\n\tv189 = 0x8909C4(v60, EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider, 2, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0059;\nL_0053:\n\treturn \"Contact can't be null.\";\nL_0055:\n\tv184 = *([v171 @ X11_v5]) + 2;\n\tv185 = v184 << 4;\n\tv186 = v127 + v185;\n\tv189 = v186 + 0x130;\nL_0059:\n\tv62 = *([v189 @ X0_v7]);\n\tv72 = *([v189 @ X0_v7+8]);\n\t// 98 IndirectJump v62 @ X3_v1, v60 @ X0_v5 (EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider), v60 @ X0_v5 (EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider), contact @ X0 (EasyMobile.Contact), v72 @ X2_v2, v62 @ X3_v1, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string AddContact(Contact contact)
		{
			//IL_0020: Expected I, but got O
			//IL_0173: Expected O, but got I
			//IL_005b: Expected O, but got I
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Expected O, but got Unknown
			//IL_0100: Expected O, but got I
			//IL_010f: Expected O, but got I
			//IL_00a7: Expected O, but got I
			object obj4 = default(object);
			if (contact != null)
			{
				INativeContactsProvider nativeProvider = NativeProvider;
				IntPtr intPtr = (IntPtr)nativeProvider;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ X8_v9 (Il2CppClass<EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00c0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ X8_v9 (Il2CppClass<EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(INativeContactsProvider))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ X8_v9 (Il2CppClass<EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00c0;
				}
				object obj2 = obj + 2;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_015b;
			}
			return "Contact can't be null.";
			IL_015b:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ X0_v7+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v62 @ X3_v1 (should have been resolved before IL gen)");
			return null;
			IL_00c0:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_015b;
		}

		[Token(Token = "0x6000504")]
		[Address(RVA = "0xA553B8", Offset = "0xA553B8", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EF2308]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021FA4]) = v38;\nL_0013:\n\tv39 = id == 0;\n\tif (v39) goto L_0053;\n\tgoto L_0021;\n\tv53 = *([v42 @ X0_v3 (Il2CppClass<EasyMobile.DeviceContacts>)+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0021:\n\tv60 = EasyMobile.DeviceContacts::get_NativeProvider();\n\tv127 = *([v60 @ X0_v5 (EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider)]);\n\tv115 = *([v127 @ X8_v9 (Il2CppClass<EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider>)+126]) == 0;\n\tif (v115) goto L_0049;\n\tv171 = *([v127 @ X8_v9 (Il2CppClass<EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider>)+B0]) + 8;\nL_0034:\n\tv177 = *([v171 @ X11_v5-8]) == EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider;\n\tif (v177) goto L_0055;\n\tv172 = v172 + 1;\n\tv182 = v172 < *([v127 @ X8_v9 (Il2CppClass<EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider>)+126]);\n\tv153 = ~v182;\n\tv171 = v171 + 0x10;\n\tv137 = ~v153;\n\tif (v137) goto L_0034;\nL_0049:\n\tv189 = 0x8909C4(v60, EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider, 3, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0059;\nL_0053:\n\treturn \"Can't delete a contact with null id.\";\nL_0055:\n\tv184 = *([v171 @ X11_v5]) + 3;\n\tv185 = v184 << 4;\n\tv186 = v127 + v185;\n\tv189 = v186 + 0x130;\nL_0059:\n\tv62 = *([v189 @ X0_v7]);\n\tv72 = *([v189 @ X0_v7+8]);\n\t// 98 IndirectJump v62 @ X3_v1, v60 @ X0_v5 (EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider), v60 @ X0_v5 (EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider), id @ X0 (System.String), v72 @ X2_v2, v62 @ X3_v1, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string DeleteContact(string id)
		{
			//IL_0020: Expected I, but got O
			//IL_0173: Expected O, but got I
			//IL_005b: Expected O, but got I
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Expected O, but got Unknown
			//IL_0100: Expected O, but got I
			//IL_010f: Expected O, but got I
			//IL_00a7: Expected O, but got I
			object obj4 = default(object);
			if (id != null)
			{
				INativeContactsProvider nativeProvider = NativeProvider;
				IntPtr intPtr = (IntPtr)nativeProvider;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ X8_v9 (Il2CppClass<EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00c0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ X8_v9 (Il2CppClass<EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(INativeContactsProvider))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ X8_v9 (Il2CppClass<EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00c0;
				}
				object obj2 = obj + 3;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_015b;
			}
			return "Can't delete a contact with null id.";
			IL_015b:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ X0_v7+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v62 @ X3_v1 (should have been resolved before IL gen)");
			return null;
			IL_00c0:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_015b;
		}

		[Token(Token = "0x6000505")]
		[Address(RVA = "0xA554B0", Offset = "0xA554B0", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EC5DD0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021FA5]) = v38;\nL_0013:\n\tv39 = contact == 0;\n\tif (v39) goto L_0032;\n\tgoto L_0028;\n\tv54 = *([v43 @ X0_v3+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_0028;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0028:\n\treturnVal2 = EasyMobile.DeviceContacts::DeleteContact(contact.id);\n\treturn returnVal2;\nL_0032:\n\treturn \"The contacts provider hasn't been initialized.\";\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string DeleteContact(Contact contact)
		{
			if (contact != null)
			{
				return DeleteContact(contact.Id);
			}
			return "The contacts provider hasn't been initialized.";
		}

		[Token(Token = "0x6000506")]
		[Address(RVA = "0xA55534", Offset = "0xA55534", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EA4DB8]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021FA6]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.DeviceContacts>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = EasyMobile.DeviceContacts::get_NativeProvider();\n\tv56 = *([v52 @ X0_v4 (EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider)]);\n\tv60 = *([v56 @ X8_v7 (Il2CppClass<EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider>)+126]) == 0;\n\tif (v60) goto L_0047;\n\tv113 = *([v56 @ X8_v7 (Il2CppClass<EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider>)+B0]) + 8;\nL_0032:\n\tv119 = *([v113 @ X11_v5-8]) == EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider;\n\tif (v119) goto L_004A;\n\tv114 = v114 + 1;\n\tv174 = v114 < *([v56 @ X8_v7 (Il2CppClass<EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider>)+126]);\n\tv93 = ~v174;\n\tv113 = v113 + 0x10;\n\tv69 = ~v93;\n\tif (v69) goto L_0032;\nL_0047:\n\tv181 = 0x8909C4(v52, EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider, 4, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_004E;\nL_004A:\n\tv176 = *([v113 @ X11_v5]) + 4;\n\tv177 = v176 << 4;\n\tv178 = v56 + v177;\n\tv181 = v178 + 0x130;\nL_004E:\n\tv127 = *([v181 @ X0_v6]);\n\tv134 = *([v181 @ X0_v6+8]);\n\t// 87 IndirectJump v127 @ X3_v1, v52 @ X0_v4 (EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider), v52 @ X0_v4 (EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider), callback @ X0 (System.Action`2<System.String, EasyMobile.Contact>), v134 @ X2_v2, v127 @ X3_v1, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void PickContact(Action<string, Contact> callback)
		{
			//IL_001b: Expected I, but got O
			//IL_0150: Expected O, but got I
			//IL_0056: Expected O, but got I
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_00f5: Expected O, but got I
			//IL_0104: Expected O, but got I
			//IL_00a2: Expected O, but got I
			INativeContactsProvider nativeProvider = NativeProvider;
			IntPtr intPtr = (IntPtr)nativeProvider;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X8_v7 (Il2CppClass<EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00bb;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X8_v7 (Il2CppClass<EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(INativeContactsProvider))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X8_v7 (Il2CppClass<EasyMobile.Internal.NativeAPIs.Contacts.INativeContactsProvider>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00bb;
			}
			object obj2 = obj + 4;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0138;
			IL_00bb:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0138;
			IL_0138:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v127 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000507")]
		[Address(RVA = "0xA55018", Offset = "0xA55018", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF1418]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021FA7]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\tUnityEngine.Debug::LogError(\"Contacts submodule is currently disable. Please enable it to use DeviceContacts API.\");\n\treturn 0;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static INativeContactsProvider GetNativeContactsProvider()
		{
			Debug.LogError("Contacts submodule is currently disable. Please enable it to use DeviceContacts API.");
			return null;
		}
	}
}
