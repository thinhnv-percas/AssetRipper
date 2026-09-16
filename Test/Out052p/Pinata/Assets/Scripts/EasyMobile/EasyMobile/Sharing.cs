using System;
using System.IO;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.Internal;
using EasyMobile.Internal.Sharing;
using UnityEngine;

namespace EasyMobile
{
	[Token(Token = "0x2000090")]
	public static class Sharing
	{
		[Token(Token = "0x400035F")]
		private static ISharingClient sSharingClient;

		[Token(Token = "0x170001B3")]
		private static ISharingClient SharingClient
		{
			[Token(Token = "0x60005FA")]
			[Address(RVA = "0xFD481C", Offset = "0xFD481C", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = *([1EED3D8]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20256C1]) = v35;\nL_0015:\n\treturnVal1 = v39.sSharingClient;\n\tv41 = v39.sSharingClient == 0;\n\tv42 = ~v41;\n\tif (v42) goto L_0024;\n\tv43 = EasyMobile.Sharing::GetSharingClient();\n\tv52.sSharingClient = v43;\n\treturnVal1 = v47.sSharingClient;\nL_0024:\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ISharingClient result = sSharingClient;
				if (sSharingClient == null)
				{
					ISharingClient sharingClient = GetSharingClient();
					sSharingClient = sharingClient;
					result = sSharingClient;
				}
				return result;
			}
		}

		[Token(Token = "0x60005FB")]
		[Address(RVA = "0xFD48E8", Offset = "0xFD48E8", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1F0D318]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, subject, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20256C2]) = v41;\nL_0015:\n\tv42 = EasyMobile.Sharing::get_SharingClient();\n\tgoto L_004E;\n\tv52 = *([v46 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v49;\n\tif (v109) goto L_003F;\n\tv89 = v104 + 1;\n\tv168 = v89 < v48;\n\tv83 = ~v168;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = v43;\n\tv91 = 0;\n\tv92 = 0x8909C4(v90, v49, v91, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004E;\nL_003F:\n\tv169 = *([v103 @ X11_v5]);\n\tv170 = v169 << 4;\n\tv171 = v46 + v170;\n\tv172 = v171 + 0x130;\nL_004E:\n\tEasyMobile.Internal.Sharing.ISharingClient::ShareText(v42, v39, subject);\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ShareText(string text, string subject = "")
		{
			ISharingClient sharingClient = SharingClient;
			string text2 = default(string);
			sharingClient.ShareText(text2, subject);
		}

		[Token(Token = "0x60005FC")]
		[Address(RVA = "0xFD49B0", Offset = "0xFD49B0", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EF6300]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, subject, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20256C3]) = v41;\nL_0015:\n\tv42 = EasyMobile.Sharing::get_SharingClient();\n\tv46 = *([v42 @ X0_v2 (EasyMobile.Internal.Sharing.ISharingClient)]);\n\tv50 = *([v46 @ X8_v3 (Il2CppClass<EasyMobile.Internal.Sharing.ISharingClient>)+126]) == 0;\n\tif (v50) goto L_003D;\n\tv103 = *([v46 @ X8_v3 (Il2CppClass<EasyMobile.Internal.Sharing.ISharingClient>)+B0]) + 8;\nL_0028:\n\tv109 = *([v103 @ X11_v5-8]) == EasyMobile.Internal.Sharing.ISharingClient;\n\tif (v109) goto L_0040;\n\tv104 = v104 + 1;\n\tv168 = v104 < *([v46 @ X8_v3 (Il2CppClass<EasyMobile.Internal.Sharing.ISharingClient>)+126]);\n\tv83 = ~v168;\n\tv103 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_0028;\nL_003D:\n\tv175 = 0x8909C4(v42, EasyMobile.Internal.Sharing.ISharingClient, 1, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0044;\nL_0040:\n\tv170 = *([v103 @ X11_v5]) + 1;\n\tv171 = v170 << 4;\n\tv172 = v46 + v171;\n\tv175 = v172 + 0x130;\nL_0044:\n\tv119 = *([v175 @ X0_v4]);\n\tv117 = *([v175 @ X0_v4+8]);\n\t// 79 IndirectJump v119 @ X4_v1, v42 @ X0_v2 (EasyMobile.Internal.Sharing.ISharingClient), v42 @ X0_v2 (EasyMobile.Internal.Sharing.ISharingClient), v39 @ X0_v1 (System.String), subject @ X1 (System.String), v117 @ X3_v1, v119 @ X4_v1, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ShareURL(string url, string subject = "")
		{
			//IL_000d: Expected I, but got O
			//IL_014b: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00e7: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_0094: Expected O, but got I
			ISharingClient sharingClient = SharingClient;
			IntPtr intPtr = (IntPtr)sharingClient;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v3 (Il2CppClass<EasyMobile.Internal.Sharing.ISharingClient>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v3 (Il2CppClass<EasyMobile.Internal.Sharing.ISharingClient>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ISharingClient))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v3 (Il2CppClass<EasyMobile.Internal.Sharing.ISharingClient>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 1;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0133;
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0133;
			IL_0133:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ X0_v4+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v119 @ X4_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60005FD")]
		[Address(RVA = "0xFD4A7C", Offset = "0xFD4A7C", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EC9618]);\n\tv27 = *([v26 @ X8_v8]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, message, subject, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20256C4]) = v44;\nL_0017:\n\tv45 = EasyMobile.Sharing::get_SharingClient();\n\tv49 = *([v45 @ X0_v2 (EasyMobile.Internal.Sharing.ISharingClient)]);\n\tv53 = *([v49 @ X8_v3 (Il2CppClass<EasyMobile.Internal.Sharing.ISharingClient>)+126]) == 0;\n\tif (v53) goto L_003F;\n\tv106 = *([v49 @ X8_v3 (Il2CppClass<EasyMobile.Internal.Sharing.ISharingClient>)+B0]) + 8;\nL_002A:\n\tv112 = *([v106 @ X11_v5-8]) == EasyMobile.Internal.Sharing.ISharingClient;\n\tif (v112) goto L_0042;\n\tv107 = v107 + 1;\n\tv175 = v107 < *([v49 @ X8_v3 (Il2CppClass<EasyMobile.Internal.Sharing.ISharingClient>)+126]);\n\tv86 = ~v175;\n\tv106 = v106 + 0x10;\n\tv62 = ~v86;\n\tif (v62) goto L_002A;\nL_003F:\n\tv182 = 0x8909C4(v45, EasyMobile.Internal.Sharing.ISharingClient, 2, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0046;\nL_0042:\n\tv177 = *([v106 @ X11_v5]) + 2;\n\tv178 = v177 << 4;\n\tv179 = v49 + v178;\n\tv182 = v179 + 0x130;\nL_0046:\n\tv124 = *([v182 @ X0_v4]);\n\tv122 = *([v182 @ X0_v4+8]);\n\t// 83 IndirectJump v124 @ X5_v1, v45 @ X0_v2 (EasyMobile.Internal.Sharing.ISharingClient), v45 @ X0_v2 (EasyMobile.Internal.Sharing.ISharingClient), v42 @ X0_v1 (System.String), message @ X1 (System.String), subject @ X2 (System.String), v122 @ X4_v1, v124 @ X5_v1, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ShareImage(string imagePath, string message, string subject = "")
		{
			//IL_000d: Expected I, but got O
			//IL_014b: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00e7: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_0094: Expected O, but got I
			ISharingClient sharingClient = SharingClient;
			IntPtr intPtr = (IntPtr)sharingClient;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X8_v3 (Il2CppClass<EasyMobile.Internal.Sharing.ISharingClient>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X8_v3 (Il2CppClass<EasyMobile.Internal.Sharing.ISharingClient>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ISharingClient))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X8_v3 (Il2CppClass<EasyMobile.Internal.Sharing.ISharingClient>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 2;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0133;
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0133;
			IL_0133:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ X0_v4+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v124 @ X5_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60005FE")]
		[Address(RVA = "0xFD4B50", Offset = "0xFD4B50", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = UnityEngine.Screen::get_width();\n\tv24 = UnityEngine.Screen::get_height();\n\treturnVal1 = EasyMobile.Sharing::ShareScreenshot(0f, 0f, v21, v24, filename, message, subject);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string ShareScreenshot(string filename, string message, string subject = "")
		{
			int width = Screen.width;
			int height = Screen.height;
			return ShareScreenshot(0f, 0f, width, height, filename, message, subject);
		}

		[Token(Token = "0x60005FF")]
		[Address(RVA = "0xFD4BAC", Offset = "0xFD4BAC", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = EasyMobile.Sharing::SaveScreenshot(startX, startY, width, height, filename);\n\tv23 = v16 == 0;\n\tif (v23) goto L_0018;\n\tEasyMobile.Sharing::ShareImage(v16, message, subject);\nL_0018:\n\treturn v16;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string ShareScreenshot(float startX, float startY, float width, float height, string filename, string message, string subject = "")
		{
			string text = SaveScreenshot(startX, startY, width, height, filename);
			if (text != null)
			{
				ShareImage(text, message, subject);
			}
			return text;
		}

		[Token(Token = "0x6000600")]
		[Address(RVA = "0xFD4D1C", Offset = "0xFD4D1C", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv30 = *([1EB9790]);\n\tv31 = *([v30 @ X8_v9]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, filename, message, subject, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20256C5]) = v47;\nL_001B:\n\tv50 = UnityEngine.ImageConversion::EncodeToPNG(tt);\n\tv53 = UnityEngine.Application::get_persistentDataPath();\n\tv60 = System.String::Concat(filename, \".png\");\n\tgoto L_0037;\n\tv68 = *([v64 @ X8_v7+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_0037;\n\tv79 = v64;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v79, v59, v58, subject, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0037:\n\tv78 = System.IO.Path::Combine(v53, v60);\n\tEasyMobile.Internal.FileUtil::WriteAllBytes(v78, v50);\n\tEasyMobile.Sharing::ShareImage(v78, message, subject);\n\treturn v78;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string ShareTexture2D(Texture2D tt, string filename, string message, string subject = "")
		{
			byte[] bytes = tt.EncodeToPNG();
			string persistentDataPath = Application.persistentDataPath;
			string path = filename + ".png";
			string text = Path.Combine(persistentDataPath, path);
			FileUtil.WriteAllBytes(text, bytes);
			ShareImage(text, message, subject);
			return text;
		}

		[Token(Token = "0x6000601")]
		[Address(RVA = "0xFD4E08", Offset = "0xFD4E08", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Screen::get_width();\n\tv16 = UnityEngine.Screen::get_height();\n\treturnVal1 = EasyMobile.Sharing::SaveScreenshot(0f, 0f, v13, v16, filename);\n\treturn returnVal1;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string SaveScreenshot(string filename)
		{
			int width = Screen.width;
			int height = Screen.height;
			return SaveScreenshot(0f, 0f, width, height, filename);
		}

		[Token(Token = "0x6000602")]
		[Address(RVA = "0xFD4BF4", Offset = "0xFD4BF4", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv38 = *([1EF3D68]);\n\tv39 = *([v38 @ X8_v14]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, methodInfo, v42, v43, v44, v45, v46, v47, startX, startY, width, height, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([20256C6]) = v54;\nL_001E:\n\tv56 = UnityEngine.Application::get_persistentDataPath();\n\tv62 = EasyMobile.Sharing::CaptureScreenshot(startX, startY, width, height);\n\tv65 = UnityEngine.ImageConversion::EncodeToPNG(v62);\n\tv72 = System.String::Concat(filename, \".png\");\n\tgoto L_0040;\n\tv80 = *([v76 @ X8_v7+E0]);\n\tv81 = v80 == 0;\n\tv82 = ~v81;\n\tif (v82) goto L_0040;\n\tv91 = v76;\n\tv85 = \"il2cpp_codegen_runtime_class_init\"(v91, v71, v70, v43, v44, v45, v46, v47, v57, v58, v59, v60, v48, v49, v50, v51);\nL_0040:\n\tv90 = System.IO.Path::Combine(v56, v72);\n\tEasyMobile.Internal.FileUtil::WriteAllBytes(v90, v65);\n\tgoto L_0053;\n\tv101 = *([v97 @ X0_v11+E0]);\n\tv102 = v101 == 0;\n\tv103 = ~v102;\n\tif (v103) goto L_0053;\n\tv105 = \"il2cpp_codegen_runtime_class_init\"(v97, v92, v93, v43, v44, v45, v46, v47, v57, v58, v59, v60, v48, v49, v50, v51);\nL_0053:\n\tUnityEngine.Object::Destroy(v62);\n\treturn v90;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string SaveScreenshot(float startX, float startY, float width, float height, string filename)
		{
			string persistentDataPath = Application.persistentDataPath;
			Texture2D texture2D = CaptureScreenshot(startX, startY, width, height);
			byte[] bytes = texture2D.EncodeToPNG();
			string path = filename + ".png";
			string text = Path.Combine(persistentDataPath, path);
			FileUtil.WriteAllBytes(text, bytes);
			UnityEngine.Object.Destroy(texture2D);
			return text;
		}

		[Token(Token = "0x6000603")]
		[Address(RVA = "0xFD4F34", Offset = "0xFD4F34", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = UnityEngine.Screen::get_width();\n\tv12 = UnityEngine.Screen::get_height();\n\treturnVal1 = EasyMobile.Sharing::CaptureScreenshot(0f, 0f, v9, v12);\n\treturn returnVal1;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Texture2D CaptureScreenshot()
		{
			int width = Screen.width;
			int height = Screen.height;
			return CaptureScreenshot(0f, 0f, width, height);
		}

		[Token(Token = "0x6000604")]
		[Address(RVA = "0xFD4E4C", Offset = "0xFD4E4C", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1ED05C8]);\n\tv31 = *([v30 @ X8_v6]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, v33, v34, v35, v36, v37, v38, v39, startX, startY, width, height, v40, v41, v42, v43);\n\tv47 = 0 | 1;\n\t*([20256C7]) = v47;\nL_001C:\n\tv51 = new UnityEngine.Texture2D();\n\tUnityEngine.Texture2D::.ctor(v51, width, height, 3, 0);\n\tv59 = 0;\n\tv66 = 0x10CCF64(&v59 @ stack_-50_v1, 0, height, 3, 0, 0, v38, v39, startX, startY, width, height, v40, v41, v42, v43);\n\t// 55 MakeStruct v78 @ AGGFD4F00_1_v1 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, v70 @ stack_-4C, 0, v73 @ stack_-44\n\tUnityEngine.Texture2D::ReadPixels(v51, v78, 0, 0);\n\tUnityEngine.Texture2D::Apply(v51);\n\treturn v51;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Texture2D CaptureScreenshot(float startX, float startY, float width, float height)
		{
			//IL_007c: Expected I4, but got F4
			//IL_007c: Expected I4, but got F4
			//IL_008a: Expected O, but got I4
			//IL_0020: Expected F4, but got O
			//IL_003b: Expected F4, but got O
			Texture2D texture2D = new Texture2D((int)width, (int)height, TextureFormat.RGB24, mipChain: false);
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
			Rect source = default(Rect);
			source.x = 0f;
			object obj2 = default(object);
			source.y = (float)obj2;
			source.width = 0f;
			object obj3 = default(object);
			source.height = (float)obj3;
			texture2D.ReadPixels(source, 0, 0);
			texture2D.Apply();
			return texture2D;
		}

		[Token(Token = "0x6000605")]
		[Address(RVA = "0xFD488C", Offset = "0xFD488C", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EAF1A0]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20256C8]) = v35;\nL_0014:\n\tv39 = new EasyMobile.Internal.Sharing.AndroidSharingClient();\n\tEasyMobile.Internal.Sharing.AndroidSharingClient::.ctor(v39);\n\treturn v39;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static ISharingClient GetSharingClient()
		{
			return new AndroidSharingClient();
		}
	}
}
