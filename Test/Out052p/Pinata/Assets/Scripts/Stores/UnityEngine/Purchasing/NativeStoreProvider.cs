using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Uniject;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200004B")]
	internal class NativeStoreProvider : INativeStoreProvider
	{
		[Token(Token = "0x6000121")]
		[Address(RVA = "0xC6A114", Offset = "0xC6A114", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = *([1EF95C0]);\n\tv31 = *([v30 @ X8_v23]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, callback, store, binder, util, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 0 | 1;\n\t*([2023385]) = v47;\nL_001D:\n\treturnVal1 = UnityEngine.Purchasing.NativeStoreProvider::GetAndroidStoreHelper(v44, callback, store, binder, util);\n\tv53 = returnVal1 == 0;\n\tif (v53) goto L_002C;\n\treturn returnVal1;\nL_002C:\n\tv64 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v64);\n\tthrow v64;\n\tv125 = 0x6D2BC0(v121, 0, Il2CppMethodInfo, binder, util, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv139 = *([v125 @ X0_v12 (System.NotSupportedException)]);\n\tv141 = *([v139 @ X19_v5 (Il2CppClass<System.NotSupportedException>)]);\n\tv143 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, v141, Il2CppMethodInfo, binder, util, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv144 = v143 & 1;\n\tv131 = v144 == 0;\n\tif (v131) goto L_006F;\n\tv145 = 0x6D2490(v143, v141, Il2CppMethodInfo, binder, util, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv162 = 0x846A20(v139, 0, Il2CppMethodInfo, binder, util, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv165 = *([v139 @ X19_v5 (Il2CppClass<System.NotSupportedException>)]);\n\tv146 = *([v165 @ X8_v12+160]);\n\tv167 = *([v165 @ X8_v12+168]);\n\tv146(v168, v139, v167, Il2CppMethodInfo, binder, util, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv175 = System.String::Concat(\"Failed to bind to native store: \", v168, 0);\n\tv180 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v180, v175, 0);\n\tthrow v180;\nL_006F:\n\tv159 = 0x6D1E60(8, v149, v147, binder, util, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv134 = *([v132 @ X20_v4 (System.NotSupportedException)]);\n\t*([v159 @ X0_v17]) = v134;\n\tv128 = 0x1E8A000 + 0x870;\n\tv164 = 0x6D2A00(v159, v128, 0, binder, util, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv130 = 0x6D2490(v164, v128, 0, binder, util, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv136 = 0x6D2380(v109, v98, v96, binder, util, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\treturnVal2 = 0x846AA4(v136, v98, v96, binder, util, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\treturn returnVal2;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public INativeStore GetAndroidStore(IUnityCallback callback, AppStore store, IPurchasingBinder binder, IUtil util)
		{
			INativeStore androidStore = GetAndroidStore(callback, store, binder, util);
			if (androidStore != null)
			{
				return androidStore;
			}
			NotImplementedException ex = new NotImplementedException();
			throw ex;
		}

		[Token(Token = "0x6000122")]
		[Address(RVA = "0xC6A2A0", Offset = "0xC6A2A0", Length = "0xC28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv40 = *([1EA5908]);\n\tv41 = *([v40 @ X8_v78]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, callback, store, binder, util, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv57 = 0 | 1;\n\t*([2023386]) = v57;\nL_0020:\n\tv61 = store - 1;\n\tv62 = v61 < 5;\n\tv63 = ~v62;\n\tv64 = v61 - 5;\n\tv66 = v64 == 0;\n\tv71 = ~v66;\n\tv72 = v63 & v71;\n\tif (v72) goto L_03B8;\n\tv74 = 0x181A000 + 0x2B4;\n\tv79 = *([v74 @ X9_v45 (System.Int32)+v61 @ X8_v3 (System.Int32)*4]) + v74;\n\t// 52 IndirectJump v79 @ X8_v75, v54 @ X0_v1 (UnityEngine.Purchasing.NativeStoreProvider), v54 @ X0_v1 (UnityEngine.Purchasing.NativeStoreProvider), callback @ X1 (UnityEngine.Purchasing.IUnityCallback), store @ X2 (UnityEngine.Purchasing.AppStore), binder @ X3 (UnityEngine.Purchasing.Extension.IPurchasingBinder), util @ X4 (Uniject.IUtil), methodInfo @ X5 (Il2CppMethodInfo), v44 @ X6, v45 @ X7, v46 @ V0, v47 @ V1, v48 @ V2, v49 @ V3, v50 @ V4, v51 @ V5, v52 @ V6, v53 @ V7\n\tX8 = *([1EAA780]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EE0278]);\n\tX2 = 0;\n\tX23 = X0;\n\tX1 = *([X8]);\n\tUnityEngine.AndroidJavaClass::.ctor(X0, X1, X2);\n\tX8 = *([1F00AB8]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX24 = X0;\n\tX0 = X24;\n\tX1 = 0;\n\tSystem.Object::.ctor(X0, X1);\n\t*([X24+10]) = X21;\n\t*([X24+18]) = X20;\n\tX8 = *([1EC8B80]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX22 = X0;\n\tX0 = X22;\n\tX1 = X24;\n\tUnityEngine.Purchasing.JavaBridge::.ctor(X0, X1, X2);\n\tX8 = *([1EFE3C0]);\n\tX0 = *([X8]);\n\tX1 = 0 | 1;\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX24 = X0;\n\tif (TEMP) goto L_03F1;\n\tif (TEMP) goto L_0061;\n\tX8 = *([X24]);\n\tX1 = *([X8+40]);\n\tX0 = X22;\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_03FA;\nL_0061:\n\tX8 = *([X24+18]);\n\tif (TEMP) goto L_03F2;\n\t*([X24+20]) = X22;\n\tif (TEMP) goto L_03F6;\n\tX8 = *([1EA4540]);\n\tX9 = *([1F10EC8]);\n\tX1 = *([X8]);\n\tX3 = *([X9]);\n\tX0 = X23;\n\tX2 = X24;\n\tX0 = UnityEngine.AndroidJavaObject::CallStatic /* +2 sharing this address */(X0, X1, X2, X3);\n\tX24 = X0;\n\tX8 = *([1EF8900]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX22 = X0;\n\tX0 = X22;\n\tX1 = 0;\n\tSystem.Object::.ctor(X0, X1);\n\t*([X22+10]) = X24;\n\tif (TEMP) goto L_03F9;\n\tX9 = *([1EE1FB0]);\n\tX8 = *([X19]);\n\tX25 = *([X9]);\n\tX9 = *([X8+126]);\n\tX1 = *([X25+18]);\n\tX2 = *([X25+48]);\n\tif (TEMP) goto L_00A0;\n\tX11 = *([X8+B0]);\n\tX10 = 0;\n\tX11 = X11 + 8;\nL_0088:\n\tX12 = *([X11-8]);\n\tC = X12 < X1;\n\tC = ~C;\n\tTEMP1 = X12 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X12 ^ X1;\n\tTEMP3 = X12 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_00A3;\n\tX10 = X10 + 1;\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX11 = X11 + 0x10;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_0088;\nL_00A0:\n\tX0 = X19;\n\tX0 = 0x8909C4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_00A8;\nL_00A3:\n\tX9 = *([X11]);\n\tX9 = X9 + X2;\n\tTEMPSHIFT = X9 << 4;\n\tX8 = X8 + TEMPSHIFT;\n\tX0 = X8 + 0x130;\nL_00A8:\n\tX0 = *([X0+8]);\n\tX1 = X25;\n\tX0 = 0x8D8294(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = X0;\n\tX9 = *([X8]);\n\tX0 = X19;\n\tX1 = X22;\n\tX2 = X8;\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX9 = *([1F0BA70]);\n\tX8 = *([X19]);\n\tX25 = *([X9]);\n\tX9 = *([X8+126]);\n\tX1 = *([X25+18]);\n\tX2 = *([X25+48]);\n\tif (TEMP) goto L_00D5;\n\tX11 = *([X8+B0]);\n\tX10 = 0;\n\tX11 = X11 + 8;\nL_00BD:\n\tX12 = *([X11-8]);\n\tC = X12 < X1;\n\tC = ~C;\n\tTEMP1 = X12 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X12 ^ X1;\n\tTEMP3 = X12 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_00D8;\n\tX10 = X10 + 1;\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX11 = X11 + 0x10;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_00BD;\nL_00D5:\n\tX0 = X19;\n\tX0 = 0x8909C4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_00DD;\nL_00D8:\n\tX9 = *([X11]);\n\tX9 = X9 + X2;\n\tTEMPSHIFT = X9 << 4;\n\tX8 = X8 + TEMPSHIFT;\n\tX0 = X8 + 0x130;\nL_00DD:\n\tX0 = *([X0+8]);\n\tX1 = X25;\n\tX0 = 0x8D8294(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = X0;\n\tX9 = *([X8]);\n\tX0 = X19;\n\tX1 = X22;\n\tX2 = X8;\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1F03220]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX22 = X0;\n\tX0 = X22;\n\tX1 = 0;\n\tSystem.Object::.ctor(X0, X1);\n\tX8 = 0x1A6;\n\tX28 = 0;\n\tX25 = 0;\n\t*([X22+10]) = X24;\n\t*([X27]) = X8;\n\tif (TEMP) goto L_0123;\nL_00F5:\n\tX10 = 0x1EAE000;\n\tX8 = *([X23]);\n\tX10 = *([1EAE898]);\n\tX9 = *([X8+126]);\n\tX1 = *([X10]);\n\tif (TEMP) goto L_0117;\n\tX11 = *([X8+B0]);\n\tX10 = 0;\n\tX11 = X11 + 8;\nL_00FF:\n\tX12 = *([X11-8]);\n\tC = X12 < X1;\n\tC = ~C;\n\tTEMP1 = X12 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X12 ^ X1;\n\tTEMP3 = X12 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_011B;\n\tX10 = X10 + 1;\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX11 = X11 + 0x10;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_00FF;\nL_0117:\n\tX0 = X23;\n\tX2 = 0;\n\tX0 = 0x8909C4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_011F;\nL_011B:\n\tX9 = *([X11]);\n\tTEMPSHIFT = X9 << 4;\n\tX8 = X8 + TEMPSHIFT;\n\tX0 = X8 + 0x130;\nL_011F:\n\tX8 = *([X0]);\n\tX1 = *([X0+8]);\n\tX0 = X23;\n\tX8(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0123:\n\tTEMP = X28 + 1;\n\tN = TEMP < 0;\n\tC = 0;\n\tV = 0;\n\tif (Z) goto L_0134;\n\tX8 = *([X27+X28*4]);\n\tC = X8 < 0x1A6;\n\tC = ~C;\n\tTEMP1 = X8 - 0x1A6;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 0x1A6;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_03B2;\nL_0134:\n\tTEMP = X25 == 0;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([1EAA780]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1ED49B0]);\n\tX2 = 0;\n\tX24 = X0;\n\tX1 = *([X8]);\n\tUnityEngine.AndroidJavaClass::.ctor(X0, X1, X2);\n\tX8 = *([1ED3668]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX23 = X0;\n\tX0 = X23;\n\tUnityEngine.Purchasing.GooglePlayStoreExtensions::.ctor(X0, X1);\n\tX8 = *([1F00AB8]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX26 = X0;\n\tX0 = X26;\n\tX1 = 0;\n\tSystem.Object::.ctor(X0, X1);\n\t*([X26+10]) = X21;\n\t*([X26+18]) = X20;\n\tX8 = *([1EC8B80]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX25 = X0;\n\tX0 = X25;\n\tX1 = X26;\n\tUnityEngine.Purchasing.JavaBridge::.ctor(X0, X1, X2);\n\tX8 = *([1EFE3C0]);\n\tX0 = *([X8]);\n\tX1 = 0 | 1;\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX26 = X0;\n\tif (TEMP) goto L_03D4;\n\tif (TEMP) goto L_016A;\n\tX8 = *([X26]);\n\tX1 = *([X8+40]);\n\tX0 = X25;\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_03EC;\nL_016A:\n\tX8 = *([X26+18]);\n\tif (TEMP) goto L_03D6;\n\t*([X26+20]) = X25;\n\tif (TEMP) goto L_03DA;\n\tX8 = *([1EA4540]);\n\tX9 = *([1F10EC8]);\n\tX1 = *([X8]);\n\tX3 = *([X9]);\n\tX0 = X24;\n\tX2 = X26;\n\tX0 = UnityEngine.AndroidJavaObject::CallStatic /* +2 sharing this address */(X0, X1, X2, X3);\n\tX25 = X0;\n\tif (TEMP) goto L_03DC;\n\t*([X23+20]) = X25;\n\tif (TEMP) goto L_03DE;\n\tX9 = *([1EE7E90]);\n\tX8 = *([X19]);\n\tX26 = *([X9]);\n\tX9 = *([X8+126]);\n\tX1 = *([X26+18]);\n\tX2 = *([X26+48]);\n\tif (TEMP) goto L_01A3;\n\tX11 = *([X8+B0]);\n\tX10 = 0;\n\tX11 = X11 + 8;\nL_018B:\n\tX12 = *([X11-8]);\n\tC = X12 < X1;\n\tC = ~C;\n\tTEMP1 = X12 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X12 ^ X1;\n\tTEMP3 = X12 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_01A6;\n\tX10 = X10 + 1;\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\t\n// ... truncated")]
		private INativeStore GetAndroidStoreHelper(IUnityCallback callback, AppStore store, IPurchasingBinder binder, IUtil util)
		{
			//IL_0029: Expected O, but got I
			int num = (int)(store - 1);
			bool flag = num < 5;
			bool flag2 = !flag;
			int num2 = num - 5;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 25272320 + 692;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ X9_v45 (System.Int32)+v61 @ X8_v3 (System.Int32)*4]");
				object obj = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v79 @ X8_v75 (should have been resolved before IL gen)");
			}
			NotImplementedException ex = new NotImplementedException();
			throw ex;
		}

		[Token(Token = "0x6000123")]
		[Address(RVA = "0xC6AF7C", Offset = "0xC6AF7C", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = *([1EDEEB8]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, callback, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023387]) = v35;\nL_0012:\n\tv37 = UnityEngine.Application::get_platform();\n\tv42 = v37 == 8;\n\tif (v42) goto L_002D;\n\tv48 = UnityEngine.Application::get_platform();\n\tv50 = v48 != 0x1F;\n\tif (v50) goto L_0035;\nL_002D:\n\tv72 = new UnityEngine.Purchasing.iOSStoreBindings();\n\tUnityEngine.Purchasing.iOSStoreBindings::.ctor(v72);\n\tgoto L_003E;\nL_0035:\n\tv79 = new UnityEngine.Purchasing.OSXStoreBindings();\n\tUnityEngine.Purchasing.OSXStoreBindings::.ctor(v79);\nL_003E:\n\treturn v94;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public INativeAppleStore GetStorekit(IUnityCallback callback)
		{
			RuntimePlatform platform = Application.platform;
			if (platform != RuntimePlatform.IPhonePlayer)
			{
				RuntimePlatform platform2 = Application.platform;
				if (platform2 != RuntimePlatform.tvOS)
				{
					return new OSXStoreBindings();
				}
			}
			return new iOSStoreBindings();
		}

		[Token(Token = "0x6000124")]
		[Address(RVA = "0xC6B018", Offset = "0xC6B018", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EBAD80]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, callback, binder, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023388]) = v35;\nL_0014:\n\tv39 = new UnityEngine.Purchasing.TizenStoreBindings();\n\tUnityEngine.Purchasing.TizenStoreBindings::.ctor(v39);\n\treturn v39;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public INativeTizenStore GetTizenStore(IUnityCallback callback, IPurchasingBinder binder)
		{
			return new TizenStoreBindings();
		}

		[Token(Token = "0x6000125")]
		[Address(RVA = "0xC6B074", Offset = "0xC6B074", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EB8698]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023389]) = v35;\nL_0014:\n\tv39 = new UnityEngine.Purchasing.FacebookStoreBindings();\n\tUnityEngine.Purchasing.FacebookStoreBindings::.ctor(v39);\n\treturn v39;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public INativeFacebookStore GetFacebookStore()
		{
			return new FacebookStoreBindings();
		}

		[Token(Token = "0x6000126")]
		[Address(RVA = "0xC6B0D0", Offset = "0xC6B0D0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public NativeStoreProvider()
		{
		}
	}
}
