using System;
using System.IO;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AlmostEngine
{
	[Token(Token = "0x2000009")]
	public class PathUtils
	{
		[Token(Token = "0x6000016")]
		[Address(RVA = "0x3C45754", Offset = "0x3C45754", Length = "0x1E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0027:\n\treturn 0;\nL_002E:\n\tgoto L_0031;\nL_0031:\n\tv188 = System.IO.Path::GetInvalidPathChars();\n\tv200 = path == 0;\n\tif (v200) goto L_006A;\n\tv203 = v188.Length < 1;\n\tif (v203) goto L_0070;\nL_FFFFFFFF:\n\tv97 = 0;\nL_0052:\n\tv269 = System.Char::ToString(&v54 @ stack_-42_v2 (System.Char));\n\tv106 = System.String::Contains(path, v269);\n\tv274 = v106 == 0;\n\tv109 = ~v274;\n\tif (v109) goto L_0027;\n\tv97 = v97 + 1;\n\tv227 = v97 < v188.Length;\n\tif (v227) goto L_0049;\n\tgoto L_0070;\nL_006A:\n\tv204 = v188.Length >= 1;\n\tif (v204) goto L_0082;\nL_0070:\n\tgoto L_0074;\nL_0074:\n\tv263 = System.IO.Path::GetFullPath(path);\n\treturn 1;\nL_0082:\n\tv54 = *([v104 @ X22_v1]);\n\tgoto L_008D;\nL_008D:\n\tv249 = System.Char::ToString(&v54 @ stack_-42_v2 (System.Char));\n\tv264 = new System.NullReferenceException();\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv182 = v264;\n\tgoto L_00B5;\n\tv276 = 0x8BF5BC4(v264, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv288 = 0xB7D5000 + 0x538;\n\tv113 = *([v276 @ X0_v19]);\n\tv290 = \"il2cpp_vm_class_is_assignable_from\"(*([v288 @ X8_v11 (System.Int32)+10]), *([v113 @ X8_v12]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv110 = v290 == 0;\n\tif (v110) goto L_00AA;\n\tv107 = 0x8BF5BF4(v290, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0027;\nL_00AA:\n\tv292 = 0x8BF5BAC(8, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v292 @ X0_v23]) = *([v276 @ X0_v19]);\n\tv278 = 0xA67A000 + 0x440;\n\tv294 = 0x8BF5C48(v292, v278, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv280 = 0x8BF5BF4(v294, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv182 = v294;\nL_00B5:\n\tv284 = 0x8BF0368(v182, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal3 = 0xA1B8(v284, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal3;\nL_0019:\n\tv49 = System.String::IsNullOrEmpty(path);\n\tv51 = v49 == 0;\n\tif (v51) goto L_002E;\nL_0049:\n\tv54 = v188[v97 @ X23_v4 (System.Int32)];\n\tgoto L_0052;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsValidPath(string path)
		{
			//IL_0123: Expected I4, but got O
			if (!string.IsNullOrEmpty(path))
			{
				char[] invalidPathChars = Path.GetInvalidPathChars();
				if (path != null)
				{
					if (invalidPathChars.Length >= 1)
					{
						int num = 0;
						while (true)
						{
							char c = invalidPathChars[num];
							string value = c.ToString();
							if (path.Contains(value))
							{
								break;
							}
							num++;
							if (num < invalidPathChars.Length)
							{
								continue;
							}
							goto IL_0108;
						}
						goto IL_0005;
					}
				}
				else if (invalidPathChars.Length >= 1)
				{
					object obj = default(object);
					string text = ((char)(int)obj).ToString();
					NullReferenceException ex = new NullReferenceException();
					NullReferenceException ex2 = ex;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF0368");
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @A1B8");
					bool result = default(bool);
					return result;
				}
				goto IL_0108;
			}
			goto IL_0005;
			IL_0108:
			string fullPath = Path.GetFullPath(path);
			return true;
			IL_0005:
			return false;
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0x3C4593C", Offset = "0x3C4593C", Length = "0x284")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv130 = \"Can not create directory, filename is null or empty.\";\n\tgoto L_0070;\nL_0034:\n\tv61 = path == 0;\nL_FFFFFFFF:\n\tv80 = 0;\n\tif (v61) goto L_0097;\n\tv76 = System.String::Replace(path, \"\\\\\", \"/\");\n\tv83 = v76 == 0;\nL_FFFFFFFF:\n\tv80 = \"\\\\\";\n\tif (v83) goto L_0097;\n\tv167 = System.String::Contains(v76, \"/\");\n\tv231 = v167 == 0;\n\tif (v231) goto L_0065;\n\tv242 = System.String::LastIndexOf(v76, 0x2F);\n\tv248 = System.String::Substring(v76, 0, v242);\n\tv254 = System.IO.Directory::Exists(v248);\n\tv217 = v254 == 0;\n\tif (v217) goto L_007F;\n\treturn 1;\nL_0065:\n\tv130 = System.String::Concat(\"Can not create directory, filename is not a valid path : \", path);\n\tgoto L_0070;\nL_FFFFFFFF:\n\tv130 = v289;\nL_007F:\n\tv303 = System.String::Concat(\"Creating directory \", v248);\n\tgoto L_008A;\nL_0097:\n\tv85 = new System.NullReferenceException();\n\tv155 = v80 != 1;\nL_FFFFFFFF:\n\tv180 = v85;\n\tif (v155) goto L_00CB;\n\tv169 = 0x8BF5BC4(v85, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv234 = 0xB7D5000 + 0x538;\n\tv236 = *([v169 @ X0_v15]);\n\tv238 = \"il2cpp_vm_class_is_assignable_from\"(*([v234 @ X8_v8 (System.Int32)+10]), *([v236 @ X8_v9]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv177 = v238 == 0;\n\tif (v177) goto L_00C0;\n\tv250 = 0x8BF5BF4(v238, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv258 = 0xB2F2000 + 0xC08;\n\tv289 = System.String::Concat(v258, path);\n\tgoto L_FFFFFFFF;\nL_00C0:\n\tv252 = 0x8BF5BAC(8, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v252 @ X0_v19]) = *([v169 @ X0_v15]);\n\tv173 = 0xA67A000 + 0x440;\n\tv261 = 0x8BF5C48(v252, v173, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv175 = 0x8BF5BF4(v261, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv180 = v261;\nL_00CB:\n\tv183 = 0x8BF0368(v180, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal2 = 0xA1B8(v183, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal2;\nL_0027:\n\tv47 = System.String::IsNullOrEmpty(path);\n\tv51 = ~v47;\n\tif (v51) goto L_0034;\nL_0070:\n\tUnityEngine.Debug::LogError(v130);\n\treturn 0;\nL_008A:\n\tUnityEngine.Debug::Log(v303);\n\tv308 = System.IO.Directory::CreateDirectory(v248);\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool CreateExportDirectory(string path)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PathUtils::CreateExportDirectory");
			return default;
		}

		[Token(Token = "0x6000018")]
		[Address(RVA = "0x3C45BC0", Offset = "0x3C45BC0", Length = "0x338")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tgoto L_0039;\nL_0039:\n\tv146 = System.IO.Path::GetDirectoryName(fullname);\n\tv203 = System.IO.Path::GetFileName(fullname);\n\tv210 = System.String::Concat(v146, \"/\", v203);\n\tv214 = System.IO.Path::GetExtension(fullname);\n\tv223 = System.String::Replace(v210, v214, \"\");\n\tv272 = 0xB28A000 + 0x9B0;\n\t// 88 NewArr v298 @ X0_v43 (System.String[]), typeof(System.String[]), 5\n\tv270 = 0xB2E5000 + 0xC18;\n\tv268 = 0xB2E7000 + 0xE90;\n\tv294 = v298;\nL_0065:\n\tv294[0] = v223;\n\tv294[1] = \" (\";\n\tv299 = System.Int32::ToString(&v277 @ stack_-54_v7 (System.Int32));\n\tv386 = System.String::PadLeft(v299, frameNumberPadding, 0x30);\n\tv294[2] = v386;\n\tv294[3] = \")\";\n\tv294[4] = v214;\n\tv439 = System.String::Concat(v294);\n\tv324 = System.IO.File::Exists(v439);\n\tv326 = v324 == 0;\n\tif (v326) goto L_00C5;\n\tv309 = v277 + 1;\n\t// 189 NewArr v297 @ X0_v64 (System.String[]), typeof(System.String[]), 5\n\tv443 = v297 == 0;\n\tv303 = ~v443;\n\tv277 = v309;\n\tv294 = v297;\n\tif (v303) goto L_0065;\n\tthrow System.NullReferenceException;\nL_00C5:\n\tv300 = \"SzArrayNew\"(*([v272 @ X26_v5 (System.Int32)]), 5, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv300[0] = v223;\n\tv300[1] = *([v270 @ X25_v5 (System.Int32)]);\n\tv301 = System.Int32::ToString(&v277 @ stack_-54_v7 (System.Int32));\n\tv389 = System.String::PadLeft(v301, frameNumberPadding, 0x30);\n\tv300[2] = v389;\n\tv300[3] = *([v268 @ X24_v5 (System.Int32)]);\n\tv300[4] = v214;\n\tv117 = System.String::Concat(v300);\n\tv124 = v117;\nL_002A:\n\tv54 = System.IO.File::Exists(fullname);\n\tv58 = ~v54;\n\tv124 = fullname;\n\tif (v58) goto L_0129;\nL_0129:\n\treturn v124;\n")]
		public static string PreventOverwrite(string fullname, int frameNumberPadding = 0)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PathUtils::PreventOverwrite");
			return default;
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x3C45EF8", Offset = "0x3C45EF8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public PathUtils()
		{
		}
	}
}
