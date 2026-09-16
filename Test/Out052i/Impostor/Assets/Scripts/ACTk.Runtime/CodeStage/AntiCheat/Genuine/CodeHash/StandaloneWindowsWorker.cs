using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using AssetRipperInjected;
using CodeStage.AntiCheat.Utils;
using Cpp2ILInjected;
using UnityEngine;

namespace CodeStage.AntiCheat.Genuine.CodeHash
{
	[Token(Token = "0x2000036")]
	internal class StandaloneWindowsWorker : BaseWorker
	{
		[Token(Token = "0x600037D")]
		[Address(RVA = "0xBEAE28", Offset = "0xBEAE28", Length = "0x5C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003F;\n\tv38 = System.IO.BufferedStream;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, fileFilters, sha1, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv63 = CodeStage.AntiCheat.Genuine.CodeHash.BuildHashes;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, fileFilters, sha1, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv67 = CodeStage.AntiCheat.Genuine.CodeHash.FileHash;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, fileFilters, sha1, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv243 = System.IO.FileStream;\n\tv244 = \"il2cpp_codegen_initialize_runtime_metadata\"(v243, fileFilters, sha1, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv361 = System.IDisposable;\n\tv362 = \"il2cpp_codegen_initialize_runtime_metadata\"(v361, fileFilters, sha1, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv466 = Il2CppMethodInfo;\n\tv467 = \"il2cpp_codegen_initialize_runtime_metadata\"(v466, fileFilters, sha1, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv550 = Il2CppMethodInfo;\n\tv551 = \"il2cpp_codegen_initialize_runtime_metadata\"(v550, fileFilters, sha1, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv627 = Il2CppMethodInfo;\n\tv628 = \"il2cpp_codegen_initialize_runtime_metadata\"(v627, fileFilters, sha1, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv672 = System.Collections.Generic.List`1<CodeStage.AntiCheat.Genuine.CodeHash.FileHash>;\n\tv673 = \"il2cpp_codegen_initialize_runtime_metadata\"(v672, fileFilters, sha1, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv718 = CodeStage.AntiCheat.Utils.StringUtils;\n\tv719 = \"il2cpp_codegen_initialize_runtime_metadata\"(v718, fileFilters, sha1, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv746 = \"*\";\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v746, fileFilters, sha1, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv56 = 1;\n\t*([1A35524]) = v56;\nL_003F:\n\tv61 = System.IO.Directory::GetFiles(buildPath, \"*\", 1);\n\tv71 = v61.Length == 0;\n\tif (v71) goto L_FFFFFFFF;\n\tv250 = new System.Collections.Generic.List`1<CodeStage.AntiCheat.Genuine.CodeHash.FileHash>();\n\tSystem.Collections.Generic.List`1<CodeStage.AntiCheat.Genuine.CodeHash.FileHash>::.ctor(v250);\n\tv478 = v61.Length < 1;\n\tif (v478) goto L_01FA;\n\tv553 = v61.Length & 0xFFFFFFFF;\nL_0070:\n\tv208 = System.IO.Directory::Exists(v639[v139 @ X29_v10 (System.Int32)]);\n\tv721 = v208 == 0;\n\tv722 = ~v721;\n\tif (v722) goto L_01EB;\n\tv758 = fileFilters.Length < 1;\n\tif (v758) goto L_01EB;\nL_0097:\n\tv818 = CodeStage.AntiCheat.Genuine.CodeHash.FileFilter::MatchesPath(fileFilters[v234 @ X22_v17 (System.Int32)], v639[v139 @ X29_v10 (System.Int32)], v787);\n\tv820 = v818 == 0;\n\tif (v820) goto L_016A;\n\tv824 = new System.IO.FileStream();\n\tSystem.IO.FileStream::.ctor(v824, v639[v139 @ X29_v10 (System.Int32)], 3, 1);\n\tv843 = new System.IO.BufferedStream();\n\tSystem.IO.BufferedStream::.ctor(v843, v824);\n\tv846 = sha1 == 0;\n\tif (v846) goto L_017A;\n\tv850 = System.Security.Cryptography.HashAlgorithm::ComputeHash(sha1, v843);\n\tgoto L_00BF;\n\tv860 = \"il2cpp_codegen_runtime_class_init\"(v856, v848, v849, v838, v264, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_00BF:\n\tv864 = CodeStage.AntiCheat.Utils.StringUtils::HashBytesToHexString(v850);\n\tv888 = new CodeStage.AntiCheat.Genuine.CodeHash.FileHash();\n\tCodeStage.AntiCheat.Genuine.CodeHash.FileHash::.ctor(v888, v639[v139 @ X29_v10 (System.Int32)], v864);\n\tv453 = v250 == 0;\n\tif (v453) goto L_017F;\n\tv460 = v250._items;\n\tv419 = v250._version + 1;\n\tv250._version = v419;\n\tv454 = v250._items == 0;\n\tif (v454) goto L_0181;\n\tv892 = v250._size;\n\tv894 = v250._size < v460.Length;\n\tv895 = ~v894;\n\tif (v895) goto L_00EE;\n\tv903 = v250._size + 1;\n\tv250._size = v903;\n\tv460[v892 @ X10_v25 (System.Int32)] = v888;\n\tgoto L_00F2;\nL_00EE:\n\tSystem.Collections.Generic.List`1<CodeStage.AntiCheat.Genuine.CodeHash.FileHash>::AddWithResize(v250, v888);\nL_00F2:\n\tv921 = v843 == 0;\n\tif (v921) goto L_0121;\nL_00FA:\n\tgoto L_0120;\n\tv948 = *([v922 @ X8_v51+B0]);\n\tv949 = v948 + 8;\n\tv951 = *([v981 @ X10_v42-8]);\n\tv996 = v951 == v926;\n\tif (v996) goto L_0119;\n\tv955 = v982 - 1;\n\tv953 = v981 + 0x10;\n\tv957 = v982 != 1;\n\tif (v957) goto L_FFFFFFFF;\n\tv974 = v425;\n\tv975 = 0;\n\tv976 = 0xB349B4(v974, v926, v975, v266, v264, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_0120;\nL_0119:\n\tv1005 = *([v981 @ X10_v42]);\n\tv1006 = v1005 << 4;\n\tv1007 = v922 + v1006;\n\tv1008 = v1007 + 0x138;\nL_0120:\n\tSystem.IDisposable::Dispose(v843);\nL_0121:\n\tv947 = v353 == 0;\n\tv882 = ~v947;\n\tif (v882) goto L_017D;\n\tv977 = v311 & 1;\n\tv978 = v977 == 0;\n\tif (v978) goto L_012A;\nL_012A:\n\tv1003 = v824 == 0;\n\tif (v1003) goto L_0159;\n\tgoto L_0158;\n\tv1037 = *([v1012 @ X8_v47+B0]);\n\tv1038 = v1037 + 8;\n\tv1040 = *([v1068 @ X10_v34-8]);\n\tv1083 = v1040 == v1016;\n\tif (v1083) goto L_0151;\n\tv1044 = v1069 - 1;\n\tv1042 = v1068 + 0x10;\n\tv1046 = v1069 != 1;\n\tif (v1046) goto L_FFFFFFFF;\n\tv1063 = v262;\n\tv1064 = 0;\n\tv1065 = 0xB349B4(v1063, v1016, v1064, v266, v264, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_0158;\nL_0151:\n\tv1089 = *([v1068 @ X10_v34]);\n\tv1090 = v1089 << 4;\n\tv1091 = v1012 + v1090;\n\tv1092 = v1091 + 0x138;\nL_0158:\n\tSystem.IDisposable::Dispose(v824);\nL_0159:\n\tv1036 = v353 == 0;\n\tv300 = ~v1036;\n\tif (v300) goto L_021A;\n\tv307 = v258 | 8;\n\tv276 = v307 != 8;\n\tif (v276) goto L_FFFFFFFF;\nL_016A:\n\t;\n\tv234 = v234 + 1;\n\tv759 = v234 < fileFilters.Length;\n\tif (v759) goto L_0097;\n\tgoto L_01EB;\nL_017A:\n\tthrow v843;\nL_017D:\n\tv617 = new System.OutOfMemoryException();\n\tgoto L_0221;\nL_017F:\n\tthrow v888;\nL_0181:\n\tthrow v888;\n\tgoto L_0189;\n\tgoto L_0189;\n\tgoto L_0189;\n\tX20 = X27;\n\tgoto L_01D4;\n\tgoto L_01D4;\nL_0189:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_019D;\n\tX0 = 0x1854E70(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX27 = *([X0]);\n\tX0 = 0x1854E80(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX28 = 0;\n\tX19 = 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00FA;\n\tgoto L_0121;\nL_019D:\n\tstack[8] = X0;\n\tstack[10] = X1;\n\tX27 = 0;\n\tif (TEMP) goto L_01CF;\nL_01A2:\n\tX8 = *([X26]);\n\tX9 = *([X8+12E]);\n\tX10 = *([19359E8]);\n\tX1 = *([X10]);\n\tif (TEMP) goto L_01C3;\n\tX10 = *([X8+B0]);\n\tX10 = X10 + 8;\nL_01AB:\n\tX11 = *([X10-8]);\n\tC = X11 < X1;\n\tC = ~C;\n\tTEMP1 = X11 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X1;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_01C7;\n\tC = X9 < 1;\n\tC = ~C;\n\tTEMP1 = X9 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ 1;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX9 = X9 - 1;\n\tX10 = X10 + 0x10;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_01AB;\nL_01C3:\n\tX0 = X26;\n\tX2 = 0;\n\tX0 = 0xB349B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_01CB;\nL_01C7:\n\tX9 = *([X10]);\n\tTEMPSHIFT = X9 << 4;\n\tX8 = X8 + TEMPSHIFT;\n\tX0 = X8 + 0x138;\nL_01CB:\n\tX8 = *([X0]);\n\tX1 = *([X0+8]);\n\tX0 = X26;\n\tX8(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_01CF:\n\tX0 = stack[8];\n\tX1 = stack[10];\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_021C;\nL_01D4:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_021D;\n\tX0 = 0x1854E70(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX26 = *([X0]);\n\tX0 = 0x1854E80(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_FFFFFFFF;\n\tstack[8] = X0;\n\tstack[10] = X1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_01A2;\n\tgoto L_01CF;\nL_01EB:\n\tv139 = v139 + 1;\n\tv565 = v139 != v553;\n\tif (v565) goto L_0070;\nL_01FA:\n\tv301 = v250._size == 0;\n\tif (v301) goto L_FFFFFFFF;\n\treturnVal1 = new CodeStage.AntiCheat.Genuine.CodeHash.BuildHashes();\n\tCodeStage.AntiCheat.Genuine.CodeHash.BuildHashes::.ctor(returnVal1, v220, v250, v225);\n\tgoto L_0216;\nL_0216:\n\treturn returnV\n// ... truncated")]
		public static BuildHashes GetBuildHashes(string buildPath, FileFilter[] fileFilters, SHA1Managed sha1)
		{
			//IL_0076: Expected I4, but got I8
			//IL_02f9: Expected O, but got I
			string[] files = Directory.GetFiles(buildPath, "*", SearchOption.AllDirectories);
			List<FileHash> list;
			string buildPath2;
			SHA1Managed sha2;
			if (files.Length != 0)
			{
				list = new List<FileHash>();
				bool flag = files.Length < 1;
				buildPath2 = buildPath;
				sha2 = sha1;
				if (flag)
				{
					goto IL_0437;
				}
				int num = (int)(files.Length & 0xFFFFFFFFL);
				int num2 = 0;
				string[] array = files;
				string text = buildPath;
				BuildHashes result = default(BuildHashes);
				while (true)
				{
					if (!Directory.Exists(array[num2]) && fileFilters.Length >= 1)
					{
						int num3 = 0;
						while (true)
						{
							if (fileFilters[num3].MatchesPath(array[num2], text))
							{
								FileStream fileStream = new FileStream(array[num2], FileMode.Open, FileAccess.Read);
								BufferedStream bufferedStream = new BufferedStream(fileStream);
								if (sha1 == null)
								{
									throw bufferedStream;
								}
								byte[] input = sha1.ComputeHash(bufferedStream);
								string text2 = StringUtils.HashBytesToHexString(input);
								FileHash fileHash = new FileHash(array[num2], text2);
								if (list == null)
								{
									throw fileHash;
								}
								FileHash[] items = list._items;
								int version = list._version + 1;
								list._version = version;
								if (list._items == null)
								{
									throw fileHash;
								}
								int count = list.Count;
								int num4;
								int num5;
								if (list.Count < items.Length)
								{
									int size = list.Count + 1;
									list._size = size;
									items[count] = fileHash;
									string text3 = text2;
									Stream stream = (Stream)(object)array[num2];
									num4 = 0;
									num5 = 0;
								}
								else
								{
									list.Add(fileHash);
									string text3 = (string)0;
									Stream stream = (Stream)(object)fileHash;
									num4 = 0;
									num5 = 0;
								}
								if (bufferedStream != null)
								{
									((IDisposable)bufferedStream).Dispose();
									string text3 = null;
									Stream stream = null;
								}
								if (num4 != 0)
								{
									OutOfMemoryException ex = new OutOfMemoryException();
									if (fileStream != null)
									{
										((IDisposable)fileStream).Dispose();
										string text3 = null;
										Stream stream = null;
									}
									if (bufferedStream == null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BD3CD0");
									}
									OutOfMemoryException ex2 = new OutOfMemoryException();
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9DACB4");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9DACB4");
									return result;
								}
								int num6 = num5 & 1;
								bool flag2 = num6 == 0;
								int num7 = 8;
								if (!flag2)
								{
									num7 = 0;
									num4 = 0;
								}
								((IDisposable)fileStream)?.Dispose();
								if (num4 != 0)
								{
									throw new OutOfMemoryException();
								}
								int num8 = num7 | 8;
								bool flag3 = num8 != 8;
								text = buildPath;
								if (flag3)
								{
									break;
								}
							}
							num3++;
							if (num3 < fileFilters.Length)
							{
								continue;
							}
							goto IL_03f2;
						}
						break;
					}
					goto IL_03f2;
					IL_03f2:
					num2++;
					bool flag4 = num2 != num;
					buildPath2 = text;
					sha2 = sha1;
					array = files;
					if (flag4)
					{
						continue;
					}
					goto IL_0437;
				}
			}
			goto IL_0479;
			IL_0479:
			return null;
			IL_0437:
			if (list.Count != 0)
			{
				return new BuildHashes(buildPath2, list, sha2);
			}
			goto IL_0479;
		}

		[Token(Token = "0x600037E")]
		[Address(RVA = "0xBEB3F0", Offset = "0xBEB3F0", Length = "0x274")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv20 = UnityEngine.Application;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv47 = System.Threading.ParameterizedThreadStart;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv54 = System.IO.Path;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv62 = Il2CppMethodInfo;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv72 = System.Threading.Thread;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv80 = \"\\\\..\\\\\";\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A35525]) = v40;\nL_0024:\n\tthis.<IsBusy>k__BackingField = 1;\n\tgoto L_002C;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_002C:\n\tv52 = UnityEngine.Application::get_dataPath();\n\tv60 = System.String::Concat(v52, \"\\\\..\\\\\");\n\tgoto L_003D;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v67, v58, v59, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_003D:\n\tv78 = System.IO.Path::GetFullPath(v60);\n\tv85 = new System.Threading.ParameterizedThreadStart();\n\tSystem.Threading.ParameterizedThreadStart::.ctor(v85, this, Il2CppMethodInfo);\n\tv95 = new System.Threading.Thread();\n\tSystem.Threading.Thread::.ctor(v95, v85);\n\tv99 = v95 == 0;\n\tif (v99) goto L_005F;\n\tSystem.Threading.Thread::Start(v95, v78);\n\treturn;\nL_005F:\n\tthrow v95;\n\tgoto L_0070;\n\tgoto L_0070;\n\tgoto L_0070;\n\tgoto L_0070;\n\tgoto L_0070;\nL_0070:\n\tv115 = v85 != 1;\n\tif (v115) goto L_00BE;\n\tv172 = 0x1854E70(v103, v85, 0, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv188 = *([v172 @ X0_v21]);\n\tv189 = *([v188 @ X8_v17]);\n\tv190 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, v189, 0, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv191 = v190 & 1;\n\tv192 = v191 == 0;\n\tif (v192) goto L_00B3;\n\tv193 = *([v172 @ X0_v21]);\n\tv194 = 0x1854E80(v190, v189, 0, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv206 = v193 == 0;\n\tif (v206) goto L_FFFFFFFF;\n\tv216 = *([v193 @ X20_v10]);\n\tv218 = *([v216 @ X8_v24+168]);\n\tv219 = *([v216 @ X8_v24+170]);\n\tv218(v220, v193, v219, 0, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tgoto L_0090;\nL_0090:\n\tv227 = System.String::Concat(\"[ACTk] Something went wrong while calculating hash!\\n\", v223, 0);\n\tgoto L_009C;\n\tv233 = \"il2cpp_codegen_runtime_class_init\"(v230, v223, v208, v91, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_009C:\n\tUnityEngine.Debug::LogError(v227, 0);\n\tv156 = v193 == 0;\n\tif (v156) goto L_00BA;\n\tv235 = *([v193 @ X20_v10]);\n\tv111 = *([v235 @ X8_v22+168]);\n\tv237 = *([v235 @ X8_v22+170]);\n\tv111(v238, v193, v237, 0, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv240 = CodeStage.AntiCheat.Genuine.CodeHash.HashGeneratorResult::FromError(v238, 0);\n\tv161 = this->klass;\n\tv145 = this->klass->vtable[5];\n\tv147 = this->klass->vtable[5];\n\t// 177 IndirectJump v145 @ X3_v2, this @ X0 (CodeStage.AntiCheat.Genuine.CodeHash.StandaloneWindowsWorker), this @ X0 (CodeStage.AntiCheat.Genuine.CodeHash.StandaloneWindowsWorker), v240 @ X0_v46 (CodeStage.AntiCheat.Genuine.CodeHash.HashGeneratorResult), v147 @ X2_v8, v145 @ X3_v2, v25 @ X4, v26 @ X5, v27 @ X6, v28 @ X7, v29 @ V0, v30 @ V1, v31 @ V2, v32 @ V3, v33 @ V4, v34 @ V5, v35 @ V6, v36 @ V7\nL_00B3:\n\tv196 = 0x1854E90(8, v189, 0, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv200 = *([v172 @ X0_v21]);\n\t*([v196 @ X0_v30]) = v200;\n\tv202 = 0x185A000 + 0xF88;\n\tv204 = 0x1854EA0(v196, v202, 0, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_00BA:\n\tv215 = new System.NullReferenceException();\n\tv177 = 0x1854E80(v215, v175, v174, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_00BE:\n\tv183 = 0xBD3CD0(v165, v151, v148, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv154 = 0x9DACB4(v183, v151, v148, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\treturn;\n// 113 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Execute()
		{
			IsBusy = true;
			string dataPath = Application.dataPath;
			string path = dataPath + "\\..\\";
			string fullPath = Path.GetFullPath(path);
			ParameterizedThreadStart start = GenerateHashThread;
			Thread thread = new Thread(start);
			if (thread != null)
			{
				thread.Start(fullPath);
				return;
			}
			throw thread;
		}

		[Token(Token = "0x600037F")]
		[Address(RVA = "0xBEB664", Offset = "0xBEB664", Length = "0x1FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = System.Security.Cryptography.SHA1Managed;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, folder, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv40 = System.String;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, folder, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A35526]) = v37;\nL_0015:\n\tv38 = folder == 0;\n\tif (v38) goto L_0029;\n\tv54 = *([folder @ X1 (System.Object)]) != System.String;\n\tif (v54) goto L_004B;\nL_0029:\n\tv78 = new System.Security.Cryptography.SHA1Managed();\n\tSystem.Security.Cryptography.SHA1Managed::.ctor(v78);\n\tv104 = CodeStage.AntiCheat.Genuine.CodeHash.CodeHashGenerator::GetFileFiltersStandaloneWindows(1);\n\tv117 = CodeStage.AntiCheat.Genuine.CodeHash.StandaloneWindowsWorker::GetBuildHashes(folder, v104, v78);\n\tSystem.Security.Cryptography.HashAlgorithm::Clear(v78);\n\tv152 = CodeStage.AntiCheat.Genuine.CodeHash.HashGeneratorResult::FromBuildHashes(v117);\n\tv179 = CodeStage.AntiCheat.Genuine.CodeHash.BaseWorker::Complete(this, v152);\n\treturn;\n\tthrow System.NullReferenceException;\nL_004B:\n\tv100 = new System.InvalidCastException();\n\tgoto L_005A;\n\tgoto L_005A;\n\tgoto L_005A;\n\tgoto L_005A;\nL_005A:\n\tv115 = v104 != 1;\n\tif (v115) goto L_00A7;\n\tv119 = 0x1854E70(v100, v104, v78, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv147 = *([v119 @ X0_v10]);\n\tv149 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v147 @ X8_v5]), v78, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv153 = v149 & 1;\n\tv154 = v153 == 0;\n\tif (v154) goto L_009C;\n\tv196 = *([v119 @ X0_v10]);\n\tv197 = 0x1854E80(v149, *([v147 @ X8_v5]), v123, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv209 = *([v119 @ X0_v10]) == 0;\n\tif (v209) goto L_FFFFFFFF;\n\tv219 = *([v196 @ X20_v7]);\n\t*([v219 @ X8_v12+168])(v223, *([v119 @ X0_v10]), *([v219 @ X8_v12+170]), v123, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tgoto L_007A;\nL_007A:\n\tv230 = System.String::Concat(\"[ACTk] Something went wrong in thread: \", v226);\n\tgoto L_0086;\n\tv236 = \"il2cpp_codegen_runtime_class_init\"(v233, v226, v211, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0086:\n\tUnityEngine.Debug::LogError(v230);\n\tv182 = *([v119 @ X0_v10]) == 0;\n\tif (v182) goto L_00A3;\n\tv238 = *([v196 @ X20_v7]);\n\t*([v238 @ X8_v10+168])(v241, *([v119 @ X0_v10]), *([v238 @ X8_v10+170]), 0, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv243 = CodeStage.AntiCheat.Genuine.CodeHash.HashGeneratorResult::FromError(v241);\n\tv191 = this->klass;\n\tv156 = this->klass->vtable[5];\n\tv165 = this->klass->vtable[5];\n\t// 154 IndirectJump v156 @ X3_v1, this @ X0 (CodeStage.AntiCheat.Genuine.CodeHash.StandaloneWindowsWorker), this @ X0 (CodeStage.AntiCheat.Genuine.CodeHash.StandaloneWindowsWorker), v243 @ X0_v35 (CodeStage.AntiCheat.Genuine.CodeHash.HashGeneratorResult), v165 @ X2_v6, v156 @ X3_v1, v22 @ X4, v23 @ X5, v24 @ X6, v25 @ X7, v26 @ V0, v27 @ V1, v28 @ V2, v29 @ V3, v30 @ V4, v31 @ V5, v32 @ V6, v33 @ V7\nL_009C:\n\tv199 = 0x1854E90(8, *([v147 @ X8_v5]), v78, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\t*([v199 @ X0_v19]) = *([v119 @ X0_v10]);\n\tv125 = 0x185A000 + 0xF88;\n\tv207 = 0x1854EA0(v199, v125, 0, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_00A3:\n\tv218 = new System.NullReferenceException();\n\tv128 = 0x1854E80(v218, v125, v123, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_00A7:\n\tv138 = 0xBD3CD0(v131, v125, v123, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv143 = 0x9DACB4(v138, v125, v123, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\treturn;\n// 108 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void GenerateHashThread(object folder)
		{
			//IL_0031: Expected I4, but got O
			//IL_0236: Expected O, but got I4
			//IL_019d: Expected O, but got I4
			//IL_01d8: Expected I, but got O
			//IL_01e8: Expected O, but got I
			//IL_01f8: Expected O, but got I
			SHA1Managed sHA1Managed = default(SHA1Managed);
			FileFilter[] array = default(FileFilter[]);
			InvalidCastException ex2;
			if (folder != null)
			{
				bool flag = (object)folder.GetType() != typeof(string);
				object obj = sHA1Managed;
				int num = (int)array;
				if (flag)
				{
					InvalidCastException ex = new InvalidCastException();
					bool flag2 = (nint)array != 1;
					ex2 = ex;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
						object obj3 = default(object);
						object obj2 = obj3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
						object obj4 = default(object);
						if ((int)((nint)obj4 & 1) != 0)
						{
							object obj5 = obj3;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
							string text;
							if (obj3 != null)
							{
								object obj6 = obj5;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v219 @ X8_v12+168] (should have been resolved before IL gen)");
								string text2 = default(string);
								text = text2;
							}
							else
							{
								text = null;
							}
							string message = "[ACTk] Something went wrong in thread: " + text;
							Debug.LogError(message);
							bool flag3 = obj3 == null;
							obj = 0;
							num = 0;
							if (flag3)
							{
								goto IL_023b;
							}
							object obj7 = obj5;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v238 @ X8_v10+168] (should have been resolved before IL gen)");
							string errorMessage = default(string);
							HashGeneratorResult hashGeneratorResult = HashGeneratorResult.FromError(errorMessage);
							nint num2 = (nint)this;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ X8_v11 (Il2CppClass<CodeStage.AntiCheat.Genuine.CodeHash.StandaloneWindowsWorker>)+188]");
							object obj8 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ X8_v11 (Il2CppClass<CodeStage.AntiCheat.Genuine.CodeHash.StandaloneWindowsWorker>)+190]");
							object obj9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v156 @ X3_v1 (should have been resolved before IL gen)");
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E90 (native __cxa_allocate_exception)");
						object obj10 = obj3;
						num = 25534464 + 3976;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EA0 (native __cxa_throw)");
						obj = 0;
						goto IL_023b;
					}
					goto IL_025b;
				}
			}
			sHA1Managed = new SHA1Managed();
			array = CodeHashGenerator.GetFileFiltersStandaloneWindows(il2Cpp: true);
			BuildHashes buildHashes = GetBuildHashes((string)folder, array, sHA1Managed);
			sHA1Managed.Clear();
			HashGeneratorResult result = HashGeneratorResult.FromBuildHashes(buildHashes);
			base.Complete(result);
			return;
			IL_023b:
			NullReferenceException ex3 = new NullReferenceException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
			ex2 = (InvalidCastException)(object)ex3;
			goto IL_025b;
			IL_025b:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BD3CD0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9DACB4");
		}

		[Token(Token = "0x6000380")]
		[Address(RVA = "0xBEB860", Offset = "0xBEB860", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public StandaloneWindowsWorker()
		{
		}
	}
}
