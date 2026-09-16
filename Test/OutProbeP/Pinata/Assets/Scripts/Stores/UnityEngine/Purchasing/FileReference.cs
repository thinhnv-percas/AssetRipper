using System;
using System.IO;
using AssetRipperInjected;
using Cpp2ILInjected;
using Uniject;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000096")]
	internal class FileReference
	{
		[Token(Token = "0x400021D")]
		[FieldOffset(Offset = "0x10")]
		private string m_FilePath;

		[Token(Token = "0x400021E")]
		[FieldOffset(Offset = "0x18")]
		private ILogger m_Logger;

		[Token(Token = "0x600026B")]
		[Address(RVA = "0xC611BC", Offset = "0xC611BC", Length = "0x278")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1ED12B0]);\n\tv29 = *([v28 @ X8_v28]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, logger, util, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2023334]) = v46;\nL_0018:\n\tv47 = v167 == 0;\n\tif (v47) goto L_00B1;\n\tv49 = *([v167 @ X2_v2 (Uniject.IUtil)]);\n\tv53 = *([v49 @ X8_v7 (Il2CppClass<Uniject.IUtil>)+126]) == 0;\n\tif (v53) goto L_003E;\n\tv109 = *([v49 @ X8_v7 (Il2CppClass<Uniject.IUtil>)+B0]) + 8;\nL_0029:\n\tv114 = *([v109 @ X11_v12-8]) == Uniject.IUtil;\n\tif (v114) goto L_0041;\n\tv108 = v108 + 1;\n\tv130 = v108 < *([v49 @ X8_v7 (Il2CppClass<Uniject.IUtil>)+126]);\n\tv87 = ~v130;\n\tv109 = v109 + 0x10;\n\tv63 = ~v87;\n\tif (v63) goto L_0029;\nL_003E:\n\tv152 = 0x8909C4(v167, Uniject.IUtil, 1, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_0048;\nL_0041:\n\tv132 = *([v109 @ X11_v12]) + 1;\n\tv133 = v132 << 4;\n\tv134 = v49 + v133;\n\tv152 = v134 + 0x130;\nL_0048:\n\t*([v152 @ X0_v19])(v157, v167, *([v152 @ X0_v19+8]), v139, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_005B;\n\tv184 = *([v161 @ X0_v22+E0]);\n\tv185 = v184 == 0;\n\tv186 = ~v185;\n\tgoto L_005B;\n\tv188 = \"il2cpp_codegen_runtime_class_init\"(v161, v155, v139, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_005B:\n\tv196 = System.IO.Path::Combine(v157, \"Unity\");\n\tv205 = *([v167 @ X2_v2 (Uniject.IUtil)]);\n\tv208 = *([v205 @ X8_v16 (Il2CppClass<Uniject.IUtil>)+126]) == 0;\n\tif (v208) goto L_007F;\n\tv306 = *([v205 @ X8_v16 (Il2CppClass<Uniject.IUtil>)+B0]) + 8;\nL_006A:\n\tv311 = *([v306 @ X11_v7-8]) == Uniject.IUtil;\n\tif (v311) goto L_0082;\n\tv305 = v305 + 1;\n\tv319 = v305 < *([v205 @ X8_v16 (Il2CppClass<Uniject.IUtil>)+126]);\n\tv232 = ~v319;\n\tv306 = v306 + 0x10;\n\tv216 = ~v232;\n\tif (v216) goto L_006A;\nL_007F:\n\tv340 = 0x8909C4(v167, Uniject.IUtil, 2, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_0089;\nL_0082:\n\tv321 = *([v306 @ X11_v7]) + 2;\n\tv322 = v321 << 4;\n\tv323 = v205 + v322;\n\tv340 = v323 + 0x130;\nL_0089:\n\t*([v340 @ X0_v26])(v345, v167, *([v340 @ X0_v26+8]), v327, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv350 = System.IO.Path::Combine(v345, \"IAP\");\n\tv366 = System.IO.Path::Combine(v196, v350);\n\tv370 = System.IO.Directory::CreateDirectory(v366);\n\tv373 = System.IO.Path::Combine(v366, filename);\n\tv376 = new UnityEngine.Purchasing.FileReference();\n\tSystem.Object::.ctor(v376);\n\tv376.m_FilePath = v373;\n\tv376.m_Logger = v169;\nL_00AF:\n\treturn v359;\nL_00B1:\n\tv55 = new System.NullReferenceException();\n\tgoto L_00C4;\n\tgoto L_00C4;\n\tgoto L_00C4;\n\tgoto L_00C4;\n\tgoto L_00C4;\n\tgoto L_00C4;\n\tgoto L_00C4;\n\tgoto L_00C4;\nL_00C4:\n\tv129 = v169 != 1;\n\tif (v129) goto L_00E0;\n\tv166 = 0x6D2BC0(v55, v169, v167, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv199 = *([v166 @ X0_v11]);\n\tv202 = \"il2cpp_vm_class_is_assignable_from\"(System.Object, *([v199 @ X8_v5]), v167, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv209 = v202 & 1;\n\tv177 = v209 == 0;\n\tif (v177) goto L_00D6;\n\tv240 = 0x6D2490(v202, *([v199 @ X8_v5]), v167, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_00AF;\nL_00D6:\n\tv242 = 0x6D1E60(8, *([v199 @ X8_v5]), v167, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\t*([v242 @ X0_v15]) = *([v166 @ X0_v11]);\n\tv169 = 0x1E8A000 + 0x870;\n\tv318 = 0x6D2A00(v242, v169, 0, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv175 = 0x6D2490(v318, v169, 0, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00E0:\n\tv183 = 0x6D2380(v178, v169, 0, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\treturnVal1 = 0x846AA4(v183, v169, 0, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\treturn returnVal1;\n// 138 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static FileReference CreateInstance(string filename, ILogger logger, IUtil util)
		{
			//IL_000d: Expected I, but got O
			//IL_00c5: Expected O, but got I4
			//IL_0048: Expected O, but got I
			//IL_012b: Expected I, but got O
			//IL_033e: Expected O, but got I4
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_00f5: Expected O, but got I
			//IL_0104: Expected O, but got I
			//IL_0166: Expected O, but got I
			//IL_0094: Expected O, but got I
			//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f6: Expected O, but got Unknown
			//IL_0213: Expected O, but got I
			//IL_0222: Expected O, but got I
			//IL_01b2: Expected O, but got I
			IUtil util2 = default(IUtil);
			object obj5;
			if (util2 != null)
			{
				IntPtr intPtr = (IntPtr)util2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X8_v7 (Il2CppClass<Uniject.IUtil>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X8_v7 (Il2CppClass<Uniject.IUtil>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ X11_v12-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IUtil))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X8_v7 (Il2CppClass<Uniject.IUtil>)+126]");
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
				obj5 = util2;
				goto IL_03dd;
			}
			NullReferenceException ex = new NullReferenceException();
			ILogger logger2 = default(ILogger);
			bool flag3 = (IntPtr)logger2 != (IntPtr)1;
			NullReferenceException ex2 = ex;
			if (!flag3)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj7 = default(object);
				object obj6 = obj7;
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				object obj8 = default(object);
				if ((uint)((ulong)(long)(IntPtr)obj8 & 1uL) != 0)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
					return null;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @6D1E60 (native __cxa_allocate_exception)");
				object obj9 = obj7;
				logger2 = (ILogger)(32022528 + 2160);
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @6D2A00 (native __cxa_throw)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				NullReferenceException ex3 = default(NullReferenceException);
				ex2 = ex3;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
			FileReference result = default(FileReference);
			return result;
			IL_03dd:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v152 @ X0_v19] (should have been resolved before IL gen)");
			string path2 = default(string);
			string path = Path.Combine(path2, "Unity");
			IntPtr intPtr2 = (IntPtr)util2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ X8_v16 (Il2CppClass<Uniject.IUtil>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_01cb;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ X8_v16 (Il2CppClass<Uniject.IUtil>)+B0]");
			object obj10 = 0L + 8L;
			int num4 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ X11_v7-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IUtil))
				{
					break;
				}
				num4++;
				int num5 = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ X8_v16 (Il2CppClass<Uniject.IUtil>)+126]");
				bool flag4 = (long)num5 < 0L;
				bool flag5 = !flag4;
				obj10 = (long)(IntPtr)obj10 + 16L;
				if (!flag5)
				{
					continue;
				}
				goto IL_01cb;
			}
			object obj11 = obj10 + 2;
			int num6 = (int)((long)(IntPtr)obj11 << 4);
			object obj12 = (long)intPtr2 + (long)num6;
			object obj13 = (long)(IntPtr)obj12 + 304L;
			int num7 = 0;
			goto IL_0416;
			IL_00ad:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			obj5 = 1;
			goto IL_03dd;
			IL_0416:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v340 @ X0_v26] (should have been resolved before IL gen)");
			string path4 = default(string);
			string path3 = Path.Combine(path4, "IAP");
			string text = Path.Combine(path, path3);
			DirectoryInfo directoryInfo = Directory.CreateDirectory(text);
			string filePath = Path.Combine(text, filename);
			FileReference fileReference = null;
			fileReference.m_FilePath = filePath;
			fileReference.m_Logger = logger2;
			return fileReference;
			IL_01cb:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			num7 = 2;
			goto IL_0416;
		}

		[Token(Token = "0x600026C")]
		[Address(RVA = "0xC61434", Offset = "0xC61434", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.m_FilePath = filePath;\n\tthis.m_Logger = logger;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal FileReference(string filePath, ILogger logger)
		{
			m_FilePath = filePath;
			m_Logger = logger;
		}

		[Token(Token = "0x600026D")]
		[Address(RVA = "0xC6146C", Offset = "0xC6146C", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1F06040]);\n\tv23 = *([v22 @ X8_v4]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, payload, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023335]) = v41;\nL_0018:\n\tSystem.IO.File::WriteAllText(this.m_FilePath, payload);\n\treturn;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX19 = X0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0082;\n\tX0 = X19;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\n\tX19 = *([X21]);\n\tX8 = *([1EDD7C0]);\n\tX1 = *([X19]);\n\tX0 = *([X8]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0076;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X20+18]);\n\tif (TEMP) goto L_007E;\n\tX8 = *([X20]);\n\tX9 = *([1EA8610]);\n\tX1 = *([X9]);\n\tX10 = *([1EC3210]);\n\tX9 = *([X8+126]);\n\tX21 = *([X10]);\n\tif (TEMP) goto L_0061;\n\tX11 = *([X8+B0]);\n\tX10 = 0;\n\tX11 = X11 + 8;\nL_0049:\n\tX12 = *([X11-8]);\n\tC = X12 < X1;\n\tC = ~C;\n\tTEMP1 = X12 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X12 ^ X1;\n\tTEMP3 = X12 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_0065;\n\tX10 = X10 + 1;\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX11 = X11 + 0x10;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_0049;\nL_0061:\n\tX2 = 0 | 7;\n\tX0 = X20;\n\tX0 = 0x8909C4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_006A;\nL_0065:\n\tX9 = *([X11]);\n\tX9 = X9 + 7;\n\tTEMPSHIFT = X9 << 4;\n\tX8 = X8 + TEMPSHIFT;\n\tX0 = X8 + 0x130;\nL_006A:\n\tX4 = *([X0]);\n\tX3 = *([X0+8]);\n\tX0 = X20;\n\tX2 = X19;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX1 = X21;\n\tX21 = stack[0];\n\t// 116 ShiftStack 48\n\t// 117 IndirectJump X4, X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7\nL_0076:\n\tX0 = 0 | 8;\n\tX0 = 0x6D1E60(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X21]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0x870;\n\tX2 = 0;\n\tX0 = 0x6D2A00(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_007E:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0082:\n\tX0 = X19;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x846AA4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void Save(string payload)
		{
			File.WriteAllText(m_FilePath, payload);
		}

		[Token(Token = "0x600026E")]
		[Address(RVA = "0xC615D0", Offset = "0xC615D0", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EF2950]);\n\tv19 = *([v18 @ X8_v4]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023336]) = v38;\nL_0015:\n\treturnVal1 = System.IO.File::ReadAllText(this.m_FilePath);\nL_0016:\n\t;\n\treturn returnVal1;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX19 = X0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0041;\n\tX0 = X19;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tX8 = *([X19]);\n\tX9 = *([1EE8350]);\n\tX1 = *([X8]);\n\tX0 = *([X9]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0037;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0;\n\tgoto L_0016;\nL_0037:\n\tX0 = 0 | 8;\n\tX0 = 0x6D1E60(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0x870;\n\tX2 = 0;\n\tX0 = 0x6D2A00(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0041:\n\tX0 = X19;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x846AA4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal string Load()
		{
			return File.ReadAllText(m_FilePath);
		}
	}
}
