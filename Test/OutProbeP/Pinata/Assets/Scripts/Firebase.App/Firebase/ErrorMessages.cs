using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Firebase.Platform;

namespace Firebase
{
	[Token(Token = "0x2000016")]
	internal class ErrorMessages
	{
		[Token(Token = "0x4000038")]
		private static string DEPENDENCY_NOT_FOUND_ERROR_ANDROID = "On Android, Firebase requires C/C++ and Java components\nthat are distributed with the Firebase and Android SDKs.\n\nIt's likely the required dependencies for Firebase were not included\nin your Unity project.\nAssets/Plugins/Android/ in your Unity project should contain\nAAR files in the form firebase-*.aar\nYou may have disabled the Android Resolver which would\nhave added the AAR dependencies for you.\n\nDo the following to enable the Android Resolver in Unity:\n* Select the menu option 'Assets -> Play Services Resolver -> \n  Android Resolver -> Settings'\n* In the Android Resolver settings check\n  'Enable Background Resolution'\n* Select the menu option 'Assets -> Play Services Resolver ->\n  Android Resolver -> Resolve Client Jars' to force Android\n  dependency resolution.\n* Rebuild your APK and deploy.\n";

		[Token(Token = "0x4000039")]
		private static string DEPENDENCY_NOT_FOUND_ERROR_IOS = "On iOS, Firebase requires native (C/C++) and Cocoapod components\nthat are distributed with the Firebase SDK and via Cocoapods.\n\nIt's likely that you did not include the require Cocoapod\ndependencies for Firebase in your Unity project.\nYou may have disabled the iOS Resolver which would have added\nthe Cocoapod dependencies for you.\n\nDo the following to enable the iOS Resolver in Unity:\n* Select the menu option 'Assets -> Play Services Resolver ->\n  iOS Resolver -> Settings'\n* In the iOS Resolver settings check 'Podfile Generation' and\n  'Add Cocoapods to Generated Xcode Project'.\n* Build your iOS project and check the Unity console for any\n  errors associated with Cocoapod tool execution.\n  You will need to correctly install Cocoapods tools to generate\n  a working build.\n";

		[Token(Token = "0x400003A")]
		private static string DEPENDENCY_NOT_FOUND_ERROR_GENERIC = "Firebase is distributed with native (C/C++) dependencies\nthat are required by the SDK.\n\nIt's possible that parts of Firebase SDK have been removed from\nyour Unity project.\n\nTo resolve the problem, try re-importing your Firebase plugins and\nbuilding again.\n\nAlternatively, you may be trying to use Firebase on an unsupported\nplatform.  See the Firebase website for the list of supported\nplatforms.\n";

		[Token(Token = "0x400003B")]
		private static string DLL_NOT_FOUND_ERROR_ANDROID = "Firebase's libApp.so was not found for this device's architecture\nin your APK.\n";

		[Token(Token = "0x400003C")]
		private static string DLL_NOT_FOUND_ERROR_IOS = "A Firebase static library (e.g libApp.a) was not linked with your\niOS application.\n";

		[Token(Token = "0x400003D")]
		private static string DLL_NOT_FOUND_ERROR_GENERIC = "A Firebase shared library (.dll / .so) could not be loaded.\n";

		[Token(Token = "0x17000017")]
		internal static string DependencyNotFoundErrorMessage
		{
			[Token(Token = "0x6000092")]
			[Address(RVA = "0x15FDCE4", Offset = "0x15FDCE4", Length = "0xD8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = *([1EB6DF0]);\n\tv15 = *([v14 @ X8_v18]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A180]) = v35;\nL_0012:\n\tv37 = Firebase.Platform.PlatformInformation::get_IsAndroid();\n\tv39 = v37 == 0;\n\tif (v39) goto L_0026;\n\tgoto L_0024;\n\tv48 = *([v42 @ X0_v14 (Il2CppClass<Firebase.ErrorMessages>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tif (v50) goto L_0024;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v42, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv52 = Firebase.ErrorMessages;\nL_0024:\n\tgoto L_004C;\nL_0026:\n\tv47 = Firebase.Platform.PlatformInformation::get_IsIOS();\n\tv61 = v47 == 0;\n\tif (v61) goto L_003D;\n\tgoto L_003A;\n\tv85 = *([v58 @ X8_v4 (Il2CppClass<Firebase.ErrorMessages>)+E0]);\n\tv86 = v85 == 0;\n\tv87 = ~v86;\n\tif (v87) goto L_003A;\n\tv99 = v58;\n\tv88 = \"il2cpp_codegen_runtime_class_init\"(v99, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv90 = Firebase.ErrorMessages;\nL_003A:\n\tgoto L_004C;\nL_003D:\n\tgoto L_004C;\n\tv92 = *([v58 @ X8_v4 (Il2CppClass<Firebase.ErrorMessages>)+E0]);\n\tv93 = v92 == 0;\n\tv94 = ~v93;\n\t// 65 ConditionalJump @b23, v94 @ TEMP_v13\n\tv100 = v58;\n\tv95 = \"il2cpp_codegen_runtime_class_init\"(v100, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv97 = Firebase.ErrorMessages;\nL_004C:\n\treturn v73.DEPENDENCY_NOT_FOUND_ERROR_ANDROID;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (PlatformInformation.IsAndroid || PlatformInformation.IsIOS)
				{
				}
				return DEPENDENCY_NOT_FOUND_ERROR_ANDROID;
			}
		}

		[Token(Token = "0x17000018")]
		internal static string DllNotFoundExceptionErrorMessage
		{
			[Token(Token = "0x6000093")]
			[Address(RVA = "0x15FDDBC", Offset = "0x15FDDBC", Length = "0x108")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = *([1EC7C70]);\n\tv15 = *([v14 @ X8_v13]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A181]) = v35;\nL_0012:\n\tv91 = Firebase.Platform.PlatformInformation::get_IsAndroid();\n\tv39 = v91 == 0;\n\tif (v39) goto L_0028;\n\tgoto L_0025;\n\tv48 = *([v42 @ X8_v9 (Il2CppClass<Firebase.ErrorMessages>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tif (v50) goto L_0025;\n\tv65 = v42;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v65, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv56 = Firebase.ErrorMessages;\nL_0025:\n\tv66 = v55.DEPENDENCY_NOT_FOUND_ERROR_ANDROID + 0x18;\n\tgoto L_004D;\nL_0028:\n\tv91 = Firebase.Platform.PlatformInformation::get_IsIOS();\n\tv64 = v91 == 0;\n\tif (v64) goto L_003F;\n\tgoto L_003B;\n\tv95 = *([v61 @ X8_v4 (Il2CppClass<Firebase.ErrorMessages>)+E0]);\n\tv96 = v95 == 0;\n\tv97 = ~v96;\n\tif (v97) goto L_003B;\n\tv117 = v61;\n\tv99 = \"il2cpp_codegen_runtime_class_init\"(v117, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv100 = Firebase.ErrorMessages;\nL_003B:\n\tv66 = v77.DEPENDENCY_NOT_FOUND_ERROR_ANDROID + 0x20;\n\tgoto L_004D;\nL_003F:\n\tgoto L_0048;\n\tv102 = *([v61 @ X8_v4 (Il2CppClass<Firebase.ErrorMessages>)+E0]);\n\tv103 = v102 == 0;\n\tv104 = ~v103;\n\tif (v104) goto L_0048;\n\tv118 = v61;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v118, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv107 = Firebase.ErrorMessages;\nL_0048:\n\tv66 = v76.DEPENDENCY_NOT_FOUND_ERROR_ANDROID + 0x28;\nL_004D:\n\tgoto L_0054;\n\tv87 = *([v75 @ X8_v3+E0]);\n\tv88 = v87 == 0;\n\tv89 = ~v88;\n\tgoto L_0054;\n\tv109 = v75;\n\tv92 = \"il2cpp_codegen_runtime_class_init\"(v109, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0054:\n\tv94 = Firebase.ErrorMessages::get_DependencyNotFoundErrorMessage();\n\treturnVal1 = System.String::Concat(*([v66 @ X9_v1]), v94);\n\treturn returnVal1;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_00be: Expected O, but got I
				//IL_0094: Expected O, but got I
				//IL_00a9: Expected O, but got I
				object obj = (PlatformInformation.IsAndroid ? ((object)((long)(IntPtr)DEPENDENCY_NOT_FOUND_ERROR_ANDROID + 24L)) : ((!PlatformInformation.IsIOS) ? ((object)((long)(IntPtr)DEPENDENCY_NOT_FOUND_ERROR_ANDROID + 40L)) : ((object)((long)(IntPtr)DEPENDENCY_NOT_FOUND_ERROR_ANDROID + 32L))));
				string dependencyNotFoundErrorMessage = DependencyNotFoundErrorMessage;
				return (string)obj + dependencyNotFoundErrorMessage;
			}
		}
	}
}
