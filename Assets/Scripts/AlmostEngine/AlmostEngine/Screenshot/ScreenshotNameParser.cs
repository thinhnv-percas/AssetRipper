using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AlmostEngine.Screenshot
{
	[Token(Token = "0x200002A")]
	public class ScreenshotNameParser
	{
		[Token(Token = "0x200002B")]
		public enum DestinationFolder
		{
			[Token(Token = "0x400010E")]
			CUSTOM_FOLDER = 0,
			[Token(Token = "0x400010F")]
			DATA_PATH = 1,
			[Token(Token = "0x4000110")]
			PERSISTENT_DATA_PATH = 2,
			[Token(Token = "0x4000111")]
			PICTURES_FOLDER = 3
		}

		[Token(Token = "0x60000B8")]
		[Address(RVA = "0x3C3965C", Offset = "0x3C3965C", Length = "0x76C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = time;\n\tgoto L_0075;\nL_0079:\n\tv65 = System.DateTime::get_Year(&v24 @ stack_-48_v1 (System.DateTime));\n\tv69 = v65;\n\tv72 = System.Int32::ToString(&v69 @ stack_-4C_v1 (System.Int32));\n\tv86 = System.String::Replace(name, \"{year}\", v72);\n\tv323 = System.DateTime::get_Month(&v24 @ stack_-48_v1 (System.DateTime));\n\tv69 = v323;\n\tv208 = System.Int32::ToString(&v69 @ stack_-4C_v1 (System.Int32));\n\tv209 = System.String::PadLeft(v208, 2, 0x30);\n\tv378 = System.String::Replace(v86, \"{month}\", v209);\n\tv384 = System.DateTime::get_Day(&v24 @ stack_-48_v1 (System.DateTime));\n\tv69 = v384;\n\tv210 = System.Int32::ToString(&v69 @ stack_-4C_v1 (System.Int32));\n\tv211 = System.String::PadLeft(v210, 2, 0x30);\n\tv404 = System.String::Replace(v378, \"{day}\", v211);\n\tv410 = System.DateTime::get_Hour(&v24 @ stack_-48_v1 (System.DateTime));\n\tv69 = v410;\n\tv212 = System.Int32::ToString(&v69 @ stack_-4C_v1 (System.Int32));\n\tv213 = System.String::PadLeft(v212, 2, 0x30);\n\tv430 = System.String::Replace(v404, \"{hour}\", v213);\n\tv436 = System.DateTime::get_Minute(&v24 @ stack_-48_v1 (System.DateTime));\n\tv69 = v436;\n\tv214 = System.Int32::ToString(&v69 @ stack_-4C_v1 (System.Int32));\n\tv215 = System.String::PadLeft(v214, 2, 0x30);\n\tv455 = System.String::Replace(v430, \"{minute}\", v215);\n\tv458 = System.DateTime::get_Second(&v24 @ stack_-48_v1 (System.DateTime));\n\tv69 = v458;\n\tv216 = System.Int32::ToString(&v69 @ stack_-4C_v1 (System.Int32));\n\tv217 = System.String::PadLeft(v216, 2, 0x30);\n\tv218 = System.String::Replace(v455, \"{second}\", v217);\n\tv219 = System.Int32::ToString(&resolution.m_Width (System.Int32));\n\tv466 = System.String::Replace(v218, \"{width}\", v219);\n\tv220 = System.Int32::ToString(&resolution.m_Height (System.Int32));\n\tv471 = System.String::Replace(v466, \"{height}\", v220);\n\tv221 = System.Single::ToString(&resolution.m_Scale (System.Single));\n\tv222 = System.String::Replace(v471, \"{scale}\", v221);\n\tv223 = System.String::Replace(v222, \"{ratio}\", resolution.m_Ratio);\n\tv482 = System.String::Replace(v223, \":\", \"_\");\n\tv107 = AlmostEngine.Screenshot.ScreenshotResolution+Orientation;\n\tv224 = System.Enum::ToString(&v107 @ stack_-70_v2 (Il2CppClass<AlmostEngine.Screenshot.ScreenshotResolution+Orientation>));\n\tv225 = System.String::Replace(v482, \"{orientation}\", v224);\n\tv489 = System.String::Replace(v225, \"{name}\", resolution.m_ResolutionName);\n\tv226 = System.Int32::ToString(&resolution.m_PPI (System.Int32));\n\tv227 = System.String::Replace(v489, \"{ppi}\", v226);\n\tv497 = System.String::Replace(v227, \"{category}\", resolution.m_Category);\n\tgoto L_0171;\nL_0171:\n\tv504 = UnityEngine.SceneManagement.SceneManager::GetActiveScene();\n\tv98 = v504;\n\tv228 = UnityEngine.SceneManagement.Scene::get_name(&v98 @ stack_-50_v3 (UnityEngine.SceneManagement.Scene));\n\tv510 = System.String::Replace(v497, \"{scene}\", v228);\n\tgoto L_0189;\nL_0189:\n\tv229 = UnityEngine.Application::get_companyName();\n\tv519 = System.String::Replace(v510, \"{companyName}\", v229);\n\tv230 = UnityEngine.Application::get_productName();\n\tv523 = System.String::Replace(v519, \"{productName}\", v230);\n\tv231 = UnityEngine.Application::get_version();\n\tv528 = System.String::Replace(v523, \"{version}\", v231);\n\tv93 = UnityEngine.Time::get_time();\n\tv88 = v93;\n\tv232 = System.Single::ToString(&v88 @ stack_-54_v3 (System.Single));\n\tv534 = System.String::Replace(v528, \"{time}\", v232);\n\tv94 = UnityEngine.Time::get_unscaledTime();\n\tv88 = v94;\n\tv233 = System.Single::ToString(&v88 @ stack_-54_v3 (System.Single));\n\tv540 = System.String::Replace(v534, \"{unscaledTime}\", v233);\n\tv95 = UnityEngine.Time::get_deltaTime();\n\tv88 = v95;\n\tv234 = System.Single::ToString(&v88 @ stack_-54_v3 (System.Single));\n\tv546 = System.String::Replace(v540, \"{deltaTime}\", v234);\n\tv96 = UnityEngine.Time::get_unscaledDeltaTime();\n\tv88 = v96;\n\tv235 = System.Single::ToString(&v88 @ stack_-54_v3 (System.Single));\n\tv552 = System.String::Replace(v546, \"{unscaledDeltaTime}\", v235);\n\tv554 = UnityEngine.Time::get_frameCount();\n\tv69 = v554;\n\tv236 = System.Int32::ToString(&v69 @ stack_-4C_v1 (System.Int32));\n\tv237 = System.String::PadLeft(v236, frameNumberPadding, 0x30);\n\treturnVal2 = System.String::Replace(v552, \"{frameCount}\", v237);\n\treturn returnVal2;\nL_0075:\n\tgoto L_0079;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string ParseSymbols(string name, ScreenshotResolution resolution, DateTime time, int frameNumberPadding)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotNameParser::ParseSymbols");
			return default;
		}

		[Token(Token = "0x60000B9")]
		[Address(RVA = "0x3C39DC8", Offset = "0x3C39DC8", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = 0xB30C000 + 0x768;\n\tv25 = 0xB311000 + 0x70;\n\tv27 = 0xB30E000 + 0xC08;\n\tgoto L_002B;\nL_FFFFFFFF:\n\tv83 = v25;\n\tgoto L_003A;\nL_FFFFFFFF:\n\tv83 = v27;\nL_FFFFFFFF:\n\tv83 = v23;\n\tgoto L_004A;\nL_002B:\n\tv62 = format != 2;\n\tif (v62) goto L_FFFFFFFF;\nL_003A:\n\tv80 = format != 1;\n\tif (v80) goto L_004A;\nL_004A:\n\treturn *([v83 @ X8_v4 (System.Int32)]);\n")]
		public static string ParseExtension(TextureExporter.ImageFileFormat format)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotNameParser::ParseExtension");
			return default;
		}

		[Token(Token = "0x60000BA")]
		[Address(RVA = "0x3C31234", Offset = "0x3C31234", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\nL_0028:\n\tv57 = UnityEngine.Application::get_persistentDataPath();\n\treturnVal1 = System.String::Concat(v57, \"/\", customPath);\n\tv79 = returnVal1.Length < 1;\n\tif (v79) goto L_006B;\n\treturnVal1 = System.String::Replace(returnVal1, \"//\", \"/\");\n\tv189 = returnVal1.Length - 1;\n\tv191 = System.String::get_Chars(returnVal1, v189);\n\tv196 = v191 == 0x2F;\n\tif (v196) goto L_006B;\n\tv202 = returnVal1.Length - 1;\n\tv204 = System.String::get_Chars(returnVal1, v202);\n\tv153 = v204 != 0x5C;\n\tif (v153) goto L_0076;\nL_0076:\n\treturnVal3 = System.String::Concat(returnVal1, \"/\");\n\treturn returnVal3;\nL_0025:\n\tgoto L_0028;\nL_006B:\n\treturn returnVal1;\n")]
		public static string ParsePath(DestinationFolder destinationFolder, string customPath)
		{
			string persistentDataPath = Application.persistentDataPath;
			string text = persistentDataPath + "/" + customPath;
			if (text.Length >= 1)
			{
				text = text.Replace("//", "/");
				int index = text.Length - 1;
				char c = text[index];
				if (c != '/')
				{
					int index2 = text.Length - 1;
					char c2 = text[index2];
					if (c2 != '\\')
					{
						return text + "/";
					}
				}
			}
			return text;
		}

		[Token(Token = "0x60000BB")]
		[Address(RVA = "0x3C32068", Offset = "0x3C32068", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv100 = System.String::Concat(v73, v79);\n\tv87 = 0xB30C000 + 0x768;\n\tv89 = 0xB311000 + 0x70;\n\tv91 = 0xB30E000 + 0xC08;\n\tgoto L_005B;\nL_FFFFFFFF:\n\tv136 = v89;\n\tgoto L_006A;\nL_FFFFFFFF:\n\tv136 = v91;\nL_FFFFFFFF:\n\tv136 = v87;\n\tgoto L_0073;\n\treturn returnVal1;\nL_0094:\n\treturnVal2 = AlmostEngine.PathUtils::PreventOverwrite(returnVal1, frameNumberPadding);\n\treturn returnVal2;\nL_0029:\n\tv67 = AlmostEngine.Screenshot.ScreenshotNameParser::ParsePath(screenshotName, customPath);\n\tv73 = System.String::Concat(\"\", v67);\n\tv79 = AlmostEngine.Screenshot.ScreenshotNameParser::ParseSymbols(screenshotName, resolution, time, frameNumberPadding);\nL_005B:\n\tv114 = format != 2;\n\tif (v114) goto L_FFFFFFFF;\nL_006A:\n\tv133 = format != 1;\n\tif (v133) goto L_0073;\nL_0073:\n\treturnVal1 = System.String::Concat(v100, \".\", *([v136 @ X8_v6 (System.Int32)]));\n\tv142 = overwriteFiles == 0;\n\tif (v142) goto L_0094;\n")]
		public static string ParseFileName(string screenshotName, ScreenshotResolution resolution, DestinationFolder destination, string customPath, TextureExporter.ImageFileFormat format, bool overwriteFiles, DateTime time, int frameNumberPadding)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotNameParser::ParseFileName");
			return default;
		}

		[Token(Token = "0x60000BC")]
		[Address(RVA = "0x3C39E58", Offset = "0x3C39E58", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public ScreenshotNameParser()
		{
		}
	}
}
