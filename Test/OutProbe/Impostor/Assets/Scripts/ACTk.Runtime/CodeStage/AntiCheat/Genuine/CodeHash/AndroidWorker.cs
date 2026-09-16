using System;
using System.Globalization;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace CodeStage.AntiCheat.Genuine.CodeHash
{
	[Token(Token = "0x2000033")]
	internal class AndroidWorker : BaseWorker
	{
		[Token(Token = "0x2000034")]
		private class CodeHashGeneratorCallback : AndroidJavaProxy
		{
			[Token(Token = "0x40000E6")]
			[FieldOffset(Offset = "0x20")]
			private readonly AndroidWorker parent;

			[Token(Token = "0x6000373")]
			[Address(RVA = "0xBEA2F4", Offset = "0xBEA2F4", Length = "0x84")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = UnityEngine.AndroidJavaProxy;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, parent, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv49 = \"net.codestage.actk.androidnative.CodeHashCallback\";\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, parent, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A35516]) = v41;\nL_001E:\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, parent, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0023:\n\tUnityEngine.AndroidJavaProxy::.ctor(this, \"net.codestage.actk.androidnative.CodeHashCallback\");\n\tthis.parent = parent;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public CodeHashGeneratorCallback(AndroidWorker parent)
				: base("net.codestage.actk.androidnative.CodeHashCallback")
			{
				this.parent = parent;
			}

			[Token(Token = "0x6000374")]
			[Address(RVA = "0xBEA378", Offset = "0xBEA378", Length = "0x19C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv40 = CodeStage.AntiCheat.Genuine.CodeHash.BuildHashes;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, buildPath, paths, hashes, summaryHash, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv59 = CodeStage.AntiCheat.Genuine.CodeHash.FileHash[];\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, buildPath, paths, hashes, summaryHash, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv174 = CodeStage.AntiCheat.Genuine.CodeHash.FileHash;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v174, buildPath, paths, hashes, summaryHash, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv56 = 1;\n\t*([1A35517]) = v56;\nL_0029:\n\t// 41 NewArr v65 @ X0_v8 (CodeStage.AntiCheat.Genuine.CodeHash.FileHash[]), typeof(CodeStage.AntiCheat.Genuine.CodeHash.FileHash[]), hashes.Length\n\tv186 = hashes.Length < 1;\n\tif (v186) goto L_0084;\nL_0059:\n\tv155 = new CodeStage.AntiCheat.Genuine.CodeHash.FileHash();\n\tSystem.Object::.ctor(v155);\n\tv155.<Path>k__BackingField = paths[v88 @ X26_v6 (System.Int32)];\n\tv155.<Hash>k__BackingField = hashes[v88 @ X26_v6 (System.Int32)];\n\t// 100 IsInst v207 @ X0_v21, typeof(CodeStage.AntiCheat.Genuine.CodeHash.FileHash), v155 @ X0_v19 (CodeStage.AntiCheat.Genuine.CodeHash.FileHash)\n\tv209 = v207 == 0;\n\tif (v209) goto L_00A8;\n\tv65[v88 @ X26_v6 (System.Int32)] = v155;\n\tv88 = v88 + 1;\n\tv219 = v88 < hashes.Length;\n\tif (v219) goto L_0059;\nL_0084:\n\tv237 = new CodeStage.AntiCheat.Genuine.CodeHash.BuildHashes();\n\tSystem.Object::.ctor(v237);\n\tv237.<FileHashes>k__BackingField = v65;\n\tv237.<SummaryHash>k__BackingField = summaryHash;\n\tv237.<BuildPath>k__BackingField = buildPath;\n\tv171 = this.parent;\n\tv156 = CodeStage.AntiCheat.Genuine.CodeHash.HashGeneratorResult::FromBuildHashes(v237);\n\tv304 = *([v171 @ X19_v5 (CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker)]);\n\tv268 = *([v304 @ X8_v14 (Il2CppClass<CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker>)+188]);\n\tv266 = *([v304 @ X8_v14 (Il2CppClass<CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker>)+190]);\n\t// 165 IndirectJump v268 @ X3_v1, v171 @ X19_v5 (CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker), v171 @ X19_v5 (CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker), v156 @ X0_v13 (CodeStage.AntiCheat.Genuine.CodeHash.HashGeneratorResult), v266 @ X2_v1, v268 @ X3_v1, summaryHash @ X4 (System.String), methodInfo @ X5 (Il2CppMethodInfo), v43 @ X6, v44 @ X7, v45 @ V0, v46 @ V1, v47 @ V2, v48 @ V3, v49 @ V4, v50 @ V5, v51 @ V6, v52 @ V7\n\tv153 = new System.IndexOutOfRangeException();\n\tv172 = new System.NullReferenceException();\nL_00A8:\n\tv214 = new System.ArrayTypeMismatchException();\n\tthrow v214;\n\treturn;\n// 133 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void OnSuccess(string buildPath, string[] paths, string[] hashes, string summaryHash)
			{
				//IL_0138: Expected I, but got O
				//IL_0148: Expected O, but got I
				//IL_0158: Expected O, but got I
				FileHash[] array = new FileHash[hashes.Length];
				if (hashes.Length < 1)
				{
					goto IL_00e3;
				}
				int num = 0;
				while (true)
				{
					FileHash fileHash = null;
					fileHash.Path = paths[num];
					fileHash.Hash = hashes[num];
					object obj = fileHash as FileHash;
					if (obj == null)
					{
						break;
					}
					array[num] = fileHash;
					num++;
					if (num < hashes.Length)
					{
						continue;
					}
					goto IL_00e3;
				}
				goto IL_0162;
				IL_0162:
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
				IL_00e3:
				BuildHashes buildHashes = null;
				buildHashes.FileHashes = array;
				buildHashes.SummaryHash = summaryHash;
				buildHashes.BuildPath = buildPath;
				AndroidWorker androidWorker = parent;
				HashGeneratorResult hashGeneratorResult = HashGeneratorResult.FromBuildHashes(buildHashes);
				nint num2 = (nint)androidWorker;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ X8_v14 (Il2CppClass<CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker>)+188]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ X8_v14 (Il2CppClass<CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker>)+190]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v268 @ X3_v1 (should have been resolved before IL gen)");
				goto IL_0162;
			}

			[Token(Token = "0x6000375")]
			[Address(RVA = "0xBEA514", Offset = "0xBEA514", Length = "0x8D0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this.parent;\n\tv8 = CodeStage.AntiCheat.Genuine.CodeHash.HashGeneratorResult::FromError(errorMessage);\n\tv9 = this.parent == 0;\n\tif (v9) goto L_0011;\n\tv10 = *([v4 @ X19_v1 (CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker)]);\n\t// 16 IndirectJump [v10 @ X8_v132 (Il2CppClass<CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker>)+188], this.parent (CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker), this.parent (CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker), v8 @ X0_v2 (CodeStage.AntiCheat.Genuine.CodeHash.HashGeneratorResult), [v10 @ X8_v132 (Il2CppClass<CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker>)+190], [v10 @ X8_v132 (Il2CppClass<CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker>)+188], v17 @ X4, v18 @ X5, v19 @ X6, v20 @ X7, v21 @ V0, v22 @ V1, v23 @ V2, v24 @ V3, v25 @ V4, v26 @ V5, v27 @ V6, v28 @ V7\nL_0011:\n\tv29 = new System.NullReferenceException();\n\tgoto L_0031;\n\tv310 = System.Globalization.CultureInfo;\n\tv311 = \"il2cpp_codegen_initialize_runtime_metadata\"(v310, errorMessage, methodInfo, v31, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\tv320 = System.Object[];\n\tv321 = \"il2cpp_codegen_initialize_runtime_metadata\"(v320, errorMessage, methodInfo, v31, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\tv332 = \"({0}, {1}, {2}, {3})\";\n\tv333 = \"il2cpp_codegen_initialize_runtime_metadata\"(v332, errorMessage, methodInfo, v31, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\tv337 = \"F5\";\n\tv315 = \"il2cpp_codegen_initialize_runtime_metadata\"(v337, errorMessage, methodInfo, v31, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\tv313 = 1;\n\t*([1A3551B]) = v313;\nL_0031:\n\tv318 = System.String::IsNullOrEmpty(errorMessage);\n\tv326 = v318 == 0;\n\tv330 = ~v326;\n\tv162 = ~v330;\n\tif (v162) goto L_FFFFFFFF;\n\tgoto L_0041;\nL_0041:\n\tv339 = methodInfo == 0;\n\tv340 = ~v339;\n\tif (v340) goto L_0059;\n\tgoto L_004D;\n\tv363 = \"il2cpp_codegen_runtime_class_init\"(v343, v317, methodInfo, v31, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\nL_004D:\n\tv366 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv355 = v366 == 0;\n\tif (v355) goto L_00D5;\n\tv357 = System.Globalization.CultureInfo::get_NumberFormat(v366);\nL_0059:\n\t// 89 NewArr v362 @ X0_v9 (System.Object[]), typeof(System.Object[]), 4\n\tv372 = System.Single::ToString(v29, v338, v348);\n\tv373 = v362 == 0;\n\tif (v373) goto L_00D5;\n\tv413 = v372 == 0;\n\tif (v413) goto L_006E;\n\t// 104 IsInst v424 @ X0_v36, typeof(System.Object), v372 @ X0_v11 (System.String)\n\tv428 = v424 == 0;\n\tif (v428) goto L_00D2;\nL_006E:\n\tv442 = v29 + 4;\n\tv362[0] = v372;\n\tv446 = System.Single::ToString(v442, v338, v348);\n\tv527 = v446 == 0;\n\tif (v527) goto L_008A;\n\t// 122 IsInst v523 @ X0_v34, typeof(System.Object), v446 @ X0_v19 (System.String)\n\tv519 = v523 == 0;\n\tif (v519) goto L_00D2;\nL_008A:\n\tv542 = v29 + 8;\n\tv362[1] = v446;\n\tv544 = System.Single::ToString(v542, v338, v348);\n\tv567 = v544 == 0;\n\tif (v567) goto L_00A6;\n\t// 150 IsInst v524 @ X0_v32, typeof(System.Object), v544 @ X0_v22 (System.String)\n\tv520 = v524 == 0;\n\tif (v520) goto L_00D2;\nL_00A6:\n\tv583 = v29 + 0xC;\n\tv362[2] = v544;\n\tv585 = System.Single::ToString(v583, v338, v348);\n\tv625 = v585 == 0;\n\tif (v625) goto L_00C2;\n\t// 178 IsInst v525 @ X0_v30, typeof(System.Object), v585 @ X0_v25 (System.String)\n\tv521 = v525 == 0;\n\tif (v521) goto L_00D2;\nL_00C2:\n\tv362[3] = v585;\n\tv289 = UnityEngine.UnityString::Format(\"({0}, {1}, {2}, {3})\", v362);\n\treturn;\n\tv499 = new System.IndexOutOfRangeException();\nL_00D2:\n\tv526 = new System.ArrayTypeMismatchException();\n\tthrow v526;\nL_00D5:\n\tv411 = new System.NullReferenceException();\n\tgoto L_00F5;\n\tv433 = System.Globalization.CultureInfo;\n\tv434 = \"il2cpp_codegen_initialize_runtime_metadata\"(v433, v401, v397, v399, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\tv501 = System.Object[];\n\tv502 = \"il2cpp_codegen_initialize_runtime_metadata\"(v501, v401, v397, v399, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\tv529 = \"F2\";\n\tv530 = \"il2cpp_codegen_initialize_runtime_metadata\"(v529, v401, v397, v399, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\tv538 = \"({0}, {1})\";\n\tv438 = \"il2cpp_codegen_initialize_runtime_metadata\"(v538, v401, v397, v399, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\tv436 = 1;\n\t*([1A3551C]) = v436;\nL_00F5:\n\tv441 = System.String::IsNullOrEmpty(v401);\n\tv507 = v441 == 0;\n\tv511 = ~v507;\n\tv163 = ~v511;\n\tif (v163) goto L_FFFFFFFF;\n\tgoto L_0105;\nL_0105:\n\tv540 = v397 == 0;\n\tv541 = ~v540;\n\tif (v541) goto L_011D;\n\tgoto L_0111;\n\tv568 = \"il2cpp_codegen_runtime_class_init\"(v547, v440, v397, v399, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\nL_0111:\n\tv571 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv561 = System.Globalization.CultureInfo::get_NumberFormat(v571);\nL_011D:\n\t// 285 NewArr v566 @ X0_v44 (System.Object[]), typeof(System.Object[]), 2\n\tv577 = System.Single::ToString(v411, v539, v552);\n\tv624 = v577 == 0;\n\tif (v624) goto L_0132;\n\t// 300 IsInst v652 @ X0_v58, typeof(System.Object), v577 @ X0_v46 (System.String)\n\tv649 = v652 == 0;\n\tif (v649) goto L_015F;\nL_0132:\n\tv670 = v411 + 4;\n\tv566[0] = v577;\n\tv672 = System.Single::ToString(v670, v539, v552);\n\tv685 = v672 == 0;\n\tif (v685) goto L_014E;\n\t// 318 IsInst v653 @ X0_v56, typeof(System.Object), v672 @ X0_v51 (System.String)\n\tv650 = v653 == 0;\n\tif (v650) goto L_015F;\nL_014E:\n\tv566[1] = v672;\n\tv290 = UnityEngine.UnityString::Format(\"({0}, {1})\", v566);\n\treturn;\n\tv620 = new System.IndexOutOfRangeException();\n\tv623 = new System.NullReferenceException();\nL_015F:\n\tv656 = new System.ArrayTypeMismatchException();\n\tthrow v656;\n\tv680 = *([1A3551D]);\n\tv684 = v680 == 0;\n\tif (v684) goto L_017E;\n\tv686 = v639 == 0;\n\tv687 = ~v686;\n\tif (v687) goto L_0197;\n\tgoto L_0188;\nL_017E:\n\t*([1A3551D]) = 1;\n\tv743 = v639 == 0;\n\tv705 = ~v743;\n\tif (v705) goto L_0197;\nL_0188:\n\tgoto L_018B;\n\tv738 = \"il2cpp_codegen_runtime_class_init\"(v724, v668, v639, v641, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\nL_018B:\n\tv741 = System.Globalization.CultureInfo::get_InvariantCulture(0);\n\tv707 = System.Globalization.CultureInfo::get_NumberFormat(v741, Il2CppMethodInfo);\nL_0197:\n\tv713 = \"SzArrayNew\"(System.Object[], 2, v639, v641, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\tv728 = *([v669 @ X0_v61]);\n\tv735 = System.Int32::ToString(&v728 @ X8_v48 (System.Int32), 0, v696, 0);\n\tv745 = v735 == 0;\n\tif (v745) goto L_01AE;\n\t// 424 IsInst v788 @ X0_v78, typeof(System.Object), v735 @ X0_v66 (System.String)\n\tv792 = v788 == 0;\n\tif (v792) goto L_01DD;\nL_01AE:\n\t*([v713 @ X0_v64 (System.Object[])+20]) = v735;\n\tv823 = *([v669 @ X0_v61+4]);\n\tv826 = System.Int32::ToString(&v823 @ X8_v52 (System.Int32), 0, v696, 0);\n\tv833 = v826 == 0;\n\tif (v833) goto L_01CC;\n\t// 444 IsInst v819 @ X0_v76, typeof(System.Object), v826 @ X0_v71 (System.String)\n\tv817 = v819 == 0;\n\tif (v817) goto L_01DD;\nL_01CC:\n\t*([v713 @ X0_v64 (System.Object[])+28]) = v826;\n\tv291 = UnityEngine.UnityString::Format(\"({0}, {1})\", v713, 0);\n\treturn;\n\tv781 = new System.IndexOutOfRangeException();\n\tv784 = new System.NullReferenceException();\nL_01DD:\n\tv822 = new System.ArrayTypeMismatchException();\n\tthrow v822;\n\tgoto L_01FF;\n\tv846 = System.Globalization.CultureInfo;\n\tv847 = \"il2cpp_codegen_initialize_runtime_metadata\"(v846, v831, v809, v811, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\tv858 = System.Object[];\n\tv859 = \"il2cpp_codegen_initialize_runtime_metadata\"(v858, v831, v809, v811, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\tv870 = \"F2\";\n\tv871 = \"il2cpp_codegen_initialize_runtime_metadata\"(v870, v831, v809, v811, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\tv875 = \"({0}, {1}, {2})\";\n\tv851 = \"il2cpp_codegen_initialize_runtime_metadata\"(v875, v831, v809, v811, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\tv849 = 1;\n\t*([1A35520]) = v849;\nL_01FF:\n\tv854 = System.String::IsNullOrEmpty(0, 0);\n\tv864 = v854 == 0;\n\tv868 = ~v864;\n\tv164 = ~v868;\n\tif (v164) goto L_FFFFFFFF;\n\tgoto L_020F;\nL_020F:\n\tv877 = v809 == 0;\n\tv878 = ~v877;\n\tif (v878) goto L_0227;\n\tgoto L_021B;\n\tv901 \n// ... truncated")]
			public unsafe void OnError(string errorMessage)
			{
				//IL_003e: Expected I, but got O
				//IL_050c: Expected O, but got I
				//IL_0527: Expected O, but got I
				//IL_0096: Expected O, but got I
				//IL_013d: Expected O, but got I
				//IL_013d: Expected Ref, but got F4
				//IL_01bc: Expected O, but got I
				//IL_01bc: Expected Ref, but got F4
				//IL_00be: Expected I, but got O
				//IL_023b: Expected O, but got I
				//IL_023b: Expected Ref, but got F4
				//IL_038f: Expected Ref, but got F4
				AndroidWorker androidWorker = parent;
				HashGeneratorResult hashGeneratorResult = HashGeneratorResult.FromError(errorMessage);
				if (parent != null)
				{
					nint num = (nint)androidWorker;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v10 @ X8_v132 (Il2CppClass<CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker>)+188] (should have been resolved before IL gen)");
				}
				NullReferenceException ex = new NullReferenceException();
				string text = ((!string.IsNullOrEmpty(errorMessage)) ? errorMessage : "F5");
				IntPtr intPtr = default(IntPtr);
				bool flag = intPtr == (IntPtr)0;
				bool flag2 = !flag;
				nint num2 = intPtr;
				IFormatProvider formatProvider;
				string text2;
				if (!flag2)
				{
					CultureInfo invariantCulture = CultureInfo.InvariantCulture;
					bool flag3 = invariantCulture == null;
					formatProvider = (IFormatProvider)(nint)intPtr;
					text2 = null;
					if (flag3)
					{
						goto IL_02bf;
					}
					NumberFormatInfo numberFormat = invariantCulture.NumberFormat;
					num2 = (nint)numberFormat;
				}
				object[] array = new object[4];
				string text3 = ((float*)ex)->ToString(text, (IFormatProvider)num2);
				bool flag4 = array == null;
				formatProvider = (IFormatProvider)num2;
				text2 = text;
				if (!flag4)
				{
					if (text3 != null)
					{
						object obj = text3 as object;
						if (obj == null)
						{
							goto IL_02ac;
						}
					}
					float num3 = (float)ex + 6E-45f;
					array[0] = text3;
					string text4 = ((float*)num3)->ToString(text, (IFormatProvider)num2);
					if (text4 != null)
					{
						object obj2 = text4 as object;
						if (obj2 == null)
						{
							goto IL_02ac;
						}
					}
					float num4 = (float)ex + 1.1E-44f;
					array[1] = text4;
					string text5 = ((float*)num4)->ToString(text, (IFormatProvider)num2);
					if (text5 != null)
					{
						object obj3 = text5 as object;
						if (obj3 == null)
						{
							goto IL_02ac;
						}
					}
					float num5 = (float)ex + 1.7E-44f;
					array[2] = text5;
					string text6 = ((float*)num5)->ToString(text, (IFormatProvider)num2);
					if (text6 != null)
					{
						object obj4 = text6 as object;
						if (obj4 == null)
						{
							goto IL_02ac;
						}
					}
					array[3] = text6;
					string text7 = UnityEngine.UnityString.Format("({0}, {1}, {2}, {3})", array);
					return;
				}
				goto IL_02bf;
				IL_02ac:
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				text2 = null;
				throw ex2;
				IL_03ff:
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
				IL_02bf:
				NullReferenceException ex4 = new NullReferenceException();
				string text8 = ((!string.IsNullOrEmpty(text2)) ? text2 : "F2");
				bool flag5 = formatProvider == null;
				bool flag6 = !flag5;
				IFormatProvider formatProvider2 = formatProvider;
				if (!flag6)
				{
					CultureInfo invariantCulture2 = CultureInfo.InvariantCulture;
					NumberFormatInfo numberFormat2 = invariantCulture2.NumberFormat;
					formatProvider2 = numberFormat2;
				}
				object[] array2 = new object[2];
				string text9 = ((float*)ex4)->ToString(text8, formatProvider2);
				if (text9 != null)
				{
					object obj5 = text9 as object;
					if (obj5 == null)
					{
						goto IL_03ff;
					}
				}
				float num6 = (float)ex4 + 6E-45f;
				array2[0] = text9;
				string text10 = ((float*)num6)->ToString(text8, formatProvider2);
				if (text10 != null)
				{
					object obj6 = text10 as object;
					if (obj6 == null)
					{
						goto IL_03ff;
					}
				}
				array2[1] = text10;
				string text11 = UnityEngine.UnityString.Format("({0}, {1})", array2);
			}
		}

		[Token(Token = "0x6000370")]
		[Address(RVA = "0xBE9E90", Offset = "0xBE9E90", Length = "0x3A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv22 = UnityEngine.AndroidJavaClass;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv46 = CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker+CodeHashGeneratorCallback;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv51 = System.IDisposable;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv59 = System.Object[];\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv66 = \"GetCodeHash\";\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv75 = \"net.codestage.actk.androidnative.CodeHashGenerator\";\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A35514]) = v42;\nL_0026:\n\tCodeStage.AntiCheat.Genuine.CodeHash.BaseWorker::Execute(this);\n\tv49 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v49, \"net.codestage.actk.androidnative.CodeHashGenerator\");\n\tv64 = CodeStage.AntiCheat.Genuine.CodeHash.CodeHashGenerator::GetFileFiltersAndroid(1);\n\t// 56 NewArr v73 @ X0_v8 (System.Object[]), typeof(System.Object[]), 2\n\tv78 = CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker::GenerateStringArrayFromFilters(v73, v64);\n\tv81 = v78 == 0;\n\tif (v81) goto L_004C;\n\tv83 = *([v73 @ X0_v8 (System.Object[])]);\n\tv86 = \"il2cpp_codegen_object_is_inst\"(v78, *([v83 @ X8_v40 (Il2CppClass<CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker>)+40]), 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv90 = v86 == 0;\n\tif (v90) goto L_00AE;\nL_004C:\n\tv73[0] = v78;\n\tv103 = new CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker+CodeHashGeneratorCallback();\n\tCodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker+CodeHashGeneratorCallback::.ctor(v103, this);\n\tv248 = v103 == 0;\n\tif (v248) goto L_0067;\n\tv275 = *([v73 @ X0_v8 (System.Object[])]);\n\tv270 = \"il2cpp_codegen_object_is_inst\"(v103, *([v275 @ X8_v39 (Il2CppClass<CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker>)+40]), 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv272 = v270 == 0;\n\tif (v272) goto L_00B1;\nL_0067:\n\tv73[1] = v103;\n\tUnityEngine.AndroidJavaObject::CallStatic(v49, \"GetCodeHash\", v73);\nL_0076:\n\tgoto L_009C;\n\tv418 = *([v332 @ X8_v9+B0]);\n\tv419 = v418 + 8;\n\tv421 = *([v498 @ X10_v7-8]);\n\tv512 = v421 == v333;\n\tif (v512) goto L_0095;\n\tv423 = v497 - 1;\n\tv425 = v498 + 0x10;\n\tv427 = v497 != 1;\n\tif (v427) goto L_FFFFFFFF;\n\tv444 = v55;\n\tv445 = 0;\n\tv446 = 0xB349B4(v444, v333, v445, v311, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_009C;\nL_0095:\n\tv544 = *([v498 @ X10_v7]);\n\tv545 = v544 << 4;\n\tv546 = v332 + v545;\n\tv547 = v546 + 0x138;\nL_009C:\n\tSystem.IDisposable::Dispose(v49);\nL_009D:\n\tv569 = 0 == 0;\n\tv154 = ~v569;\n\tif (v154) goto L_00AB;\n\treturn;\n\tv82 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_00AB:\n\tv162 = new System.OutOfMemoryException();\n\tv245 = new System.IndexOutOfRangeException();\n\tv198 = new System.NullReferenceException();\nL_00AE:\n\tv207 = new System.ArrayTypeMismatchException();\n\tthrow v207;\nL_00B1:\n\tv277 = new System.ArrayTypeMismatchException();\n\tthrow v277;\n\tgoto L_00C7;\n\tgoto L_00C7;\n\tgoto L_00B7;\nL_00B7:\n\tX22 = X1;\n\tX21 = X0;\n\tgoto L_010A;\n\tgoto L_00C7;\nL_00C7:\n\tif (1) goto L_00D1;\n\tv304 = 0x1854E70(v283, 0, v266, v255, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv329 = *([v304 @ X0_v60]);\n\tv325 = 0x1854E80(v304, 0, v266, v255, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv447 = v49 == 0;\n\tv327 = ~v447;\n\tif (v327) goto L_0076;\n\tgoto L_009D;\nL_00D1:\n\tv306 = v49 == 0;\n\tif (v306) goto L_FFFFFFFF;\nL_00D7:\n\tgoto L_00FD;\n\tv448 = *([v378 @ X8_v22+B0]);\n\tv449 = v448 + 8;\n\tv451 = *([v519 @ X10_v16-8]);\n\tv533 = v451 == v379;\n\tif (v533) goto L_00F6;\n\tv453 = v518 - 1;\n\tv455 = v519 + 0x10;\n\tv457 = v518 != 1;\n\tif (v457) goto L_FFFFFFFF;\n\tv474 = v374;\n\tv475 = 0;\n\tv476 = 0xB349B4(v474, v379, v475, v255, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_00FD;\nL_00F6:\n\tv571 = *([v519 @ X10_v16]);\n\tv572 = v571 << 4;\n\tv573 = v378 + v572;\n\tv574 = v573 + 0x138;\nL_00FD:\n\tSystem.IDisposable::Dispose(v374, Il2CppMethodInfo);\n\tif (-2) goto L_0148;\nL_010A:\n\tv486 = v404 != 1;\n\tif (v486) goto L_0152;\n\tv539 = 0x1854E70(v415, v407, v405, v255, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv588 = *([v539 @ X0_v29 (UnityEngine.AndroidJavaClass)]);\n\tv589 = *([v588 @ X8_v16 (Il2CppClass<UnityEngine.AndroidJavaClass>)]);\n\tv590 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, v589, v405, v255, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv628 = v590 & 1;\n\tv492 = v628 == 0;\n\tif (v492) goto L_0140;\n\tv629 = *([v539 @ X0_v29 (UnityEngine.AndroidJavaClass)]);\n\tv630 = 0x1854E80(v590, v589, v405, v255, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv638 = v629 == 0;\n\tif (v638) goto L_FFFFFFFF;\n\tv639 = *([v629 @ X20_v7 (Il2CppClass<UnityEngine.AndroidJavaClass>)]);\n\tv641 = *([v639 @ X8_v20+168]);\n\tv642 = *([v639 @ X8_v20+170]);\n\tv641(v643, v629, v642, v405, v255, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_012A;\nL_012A:\n\tv650 = System.String::Concat(\"[ACTk] Can't initialize NativeRoutines!\\n\", v646, 0);\n\tgoto L_013D;\n\tv656 = \"il2cpp_codegen_runtime_class_init\"(v654, v646, v613, v255, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_013D:\n\tUnityEngine.Debug::LogError(v650, 0);\n\treturn;\nL_0140:\n\tv632 = 0x1854E90(8, v589, v405, v255, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv493 = *([v539 @ X0_v29 (UnityEngine.AndroidJavaClass)]);\n\t*([v632 @ X0_v35]) = v493;\n\tv488 = 0x185A000 + 0xF88;\n\tv490 = 0x1854EA0(v632, v488, 0, v255, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0148:\n\tv369 = new System.OutOfMemoryException();\n\tv542 = v375 == 0;\n\tv371 = ~v542;\n\tif (v371) goto L_00D7;\n\tgoto L_FFFFFFFF;\n\tX21 = X0;\n\tX0 = 0x1854E80(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0152:\n\tv541 = 0xBD3CD0(v415, v407, v405, v255, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv581 = 0x9DACB4(v541, v407, v405, v255, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn;\n// 196 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Execute()
		{
			//IL_0061: Expected I, but got O
			//IL_00d4: Expected I, but got O
			base.Execute();
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("net.codestage.actk.androidnative.CodeHashGenerator");
			FileFilter[] fileFiltersAndroid = CodeHashGenerator.GetFileFiltersAndroid(il2Cpp: true);
			object[] array = new object[2];
			string[] array2 = ((AndroidWorker)(object)array).GenerateStringArrayFromFilters(fileFiltersAndroid);
			if (array2 != null)
			{
				nint num = (nint)array;
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_codegen_object_is_inst\"");
				object obj = default(object);
				if (obj == null)
				{
					goto IL_0159;
				}
			}
			array[0] = array2;
			CodeHashGeneratorCallback codeHashGeneratorCallback = new CodeHashGeneratorCallback(this);
			if (codeHashGeneratorCallback != null)
			{
				nint num2 = (nint)array;
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_codegen_object_is_inst\"");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			array[1] = codeHashGeneratorCallback;
			androidJavaClass.CallStatic("GetCodeHash", array);
			((IDisposable)androidJavaClass).Dispose();
			if (0 == 0)
			{
				return;
			}
			OutOfMemoryException ex2 = new OutOfMemoryException();
			IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
			NullReferenceException ex4 = new NullReferenceException();
			goto IL_0159;
			IL_0159:
			ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
			throw ex5;
		}

		[Token(Token = "0x6000371")]
		[Address(RVA = "0xBEA230", Offset = "0xBEA230", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = System.String[];\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, filters, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A35515]) = v37;\nL_0019:\n\t// 25 NewArr v44 @ X0_v7 (System.String[]), typeof(System.String[]), filters.Length\n\tv107 = filters.Length < 1;\n\tif (v107) goto L_0060;\nL_003C:\n\tv88 = CodeStage.AntiCheat.Genuine.CodeHash.FileFilter::ToString(filters[v137 @ X8_v9 (System.Int32)]);\n\tv169 = v137 + 1;\n\tv44[v137 @ X8_v9 (System.Int32)] = v88;\n\tv148 = filters.Length != v169;\n\tif (v148) goto L_003C;\nL_0060:\n\treturn v44;\n\tv96 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private string[] GenerateStringArrayFromFilters(FileFilter[] filters)
		{
			string[] array = new string[filters.Length];
			if (filters.Length >= 1)
			{
				int num = 0;
				bool flag;
				do
				{
					string text = filters[num].ToString();
					int num2 = num + 1;
					array[num] = text;
					flag = filters.Length != num2;
					num = num2;
				}
				while (flag);
			}
			return array;
		}

		[Token(Token = "0x6000372")]
		[Address(RVA = "0xBE9648", Offset = "0xBE9648", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tCodeStage.AntiCheat.Genuine.CodeHash.BaseWorker::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AndroidWorker()
		{
		}
	}
}
