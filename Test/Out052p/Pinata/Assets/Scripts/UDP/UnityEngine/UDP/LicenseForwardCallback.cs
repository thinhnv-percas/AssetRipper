using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.UDP
{
	[Token(Token = "0x2000009")]
	public class LicenseForwardCallback : AndroidJavaProxy
	{
		[Token(Token = "0x4000024")]
		[FieldOffset(Offset = "0x20")]
		private ILicensingListener _listener;

		[Token(Token = "0x4000025")]
		private const int LICENSED = 1;

		[Token(Token = "0x4000026")]
		private const int RETRY = 2;

		[Token(Token = "0x4000027")]
		private const int NOT_LICENSED = 3;

		[Token(Token = "0x4000028")]
		private const int STORE_NOT_SUPPORT = 4;

		[Token(Token = "0x600001A")]
		[Address(RVA = "0x15C96E0", Offset = "0x15C96E0", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1ECBB40]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, listener, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20299CE]) = v41;\nL_001B:\n\tgoto L_0026;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0026;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, listener, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0026:\n\tUnityEngine.AndroidJavaProxy::.ctor(this, \"com.unity.udp.sdk.LicenseCheckCallback\");\n\tthis._listener = listener;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LicenseForwardCallback(ILicensingListener listener)
			: base("com.unity.udp.sdk.LicenseCheckCallback")
		{
			_listener = listener;
		}

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x15C9768", Offset = "0x15C9768", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EE45F8]);\n\tv27 = *([v26 @ X8_v18]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, code, message, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20299CF]) = v44;\nL_001C:\n\t// 28 Box v50 @ X0_v3 (System.Object), typeof(System.Int32), &code @ X1 (System.Int32)\n\tv58 = System.String::Format(\"License check succeeded. ResultCode: {0}, message:{1}\", v50, message);\n\tgoto L_0035;\n\tv66 = *([v62 @ X8_v10+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tgoto L_0035;\n\tv75 = v62;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v75, v53, v54, v55, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0035:\n\tUnityEngine.Debug::Log(v58);\n\tv77 = this._listener == 0;\n\tif (v77) goto L_0082;\n\tv78 = code - 1;\n\tv79 = v78 < 2;\n\tv80 = ~v79;\n\tv81 = v78 - 2;\n\tv83 = v81 == 0;\n\tv88 = ~v83;\n\tv89 = v80 & v88;\n\tif (v89) goto L_FFFFFFFF;\n\tv152 = 0x183B000 + 0xFA4;\n\tv142 = *([v152 @ X9_v9 (System.Int32)+v78 @ X8_v12 (System.Int32)*4]);\n\tgoto L_0051;\nL_0051:\n\tgoto L_007A;\n\tv161 = *([v157 @ X8_v13+B0]);\n\tv162 = 0;\n\tv163 = v161 + 8;\n\tv165 = *([v193 @ X11_v6-8]);\n\tv207 = v165 == v160;\n\tif (v207) goto L_0071;\n\tv167 = v192 + 1;\n\tv212 = v167 < v159;\n\tv187 = ~v212;\n\tv169 = v193 + 0x10;\n\tv171 = ~v187;\n\tif (v171) goto L_FFFFFFFF;\n\tv188 = v76;\n\tv189 = 0;\n\tv190 = 0x8909C4(v188, v160, v189, v55, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_007A;\nL_0071:\n\tv213 = *([v193 @ X11_v6]);\n\tv214 = v213 << 4;\n\tv215 = v157 + v214;\n\tv216 = v215 + 0x130;\nL_007A:\n\tUnityEngine.UDP.ILicensingListener::allow(this._listener, v142, message);\nL_0082:\n\treturn;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void allow(int code, string message)
		{
			object arg = code;
			string message2 = $"License check succeeded. ResultCode: {arg}, message:{message}";
			Debug.Log(message2);
			if (_listener != null)
			{
				int num = code - 1;
				bool flag = num < 2;
				bool flag2 = !flag;
				int num2 = num - 2;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				int code2;
				if (!(flag2 && flag4))
				{
					int num3 = 25407488 + 4004;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ X9_v9 (System.Int32)+v78 @ X8_v12 (System.Int32)*4]");
					code2 = 0;
				}
				else
				{
					code2 = 3;
				}
				_listener.allow((LicensingCode)code2, message);
			}
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x15C98E8", Offset = "0x15C98E8", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EF4BB0]);\n\tv27 = *([v26 @ X8_v18]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, code, message, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20299D0]) = v44;\nL_001C:\n\t// 28 Box v50 @ X0_v3 (System.Object), typeof(System.Int32), &code @ X1 (System.Int32)\n\tv58 = System.String::Format(\"License check failed. ResultCode: {0}, message:{1}\", v50, message);\n\tgoto L_0035;\n\tv66 = *([v62 @ X8_v10+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tgoto L_0035;\n\tv75 = v62;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v75, v53, v54, v55, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0035:\n\tUnityEngine.Debug::Log(v58);\n\tv76 = this._listener;\n\tv77 = this._listener == 0;\n\tif (v77) goto L_0083;\n\tv78 = code - 1;\n\tv79 = v78 < 2;\n\tv80 = ~v79;\n\tv81 = v78 - 2;\n\tv83 = v81 == 0;\n\tv88 = ~v83;\n\tv89 = v80 & v88;\n\tif (v89) goto L_FFFFFFFF;\n\tv152 = 0x183B000 + 0xFA4;\n\tv142 = *([v152 @ X9_v10 (System.Int32)+v78 @ X8_v12 (System.Int32)*4]);\n\tgoto L_004C;\nL_004C:\n\tv157 = *([v76 @ X20_v2 (UnityEngine.UDP.ILicensingListener)]);\n\tv140 = *([v157 @ X8_v13 (Il2CppClass<UnityEngine.UDP.ILicensingListener>)+126]) == 0;\n\tif (v140) goto L_006F;\n\tv193 = *([v157 @ X8_v13 (Il2CppClass<UnityEngine.UDP.ILicensingListener>)+B0]) + 8;\nL_005A:\n\tv207 = *([v193 @ X11_v6-8]) == UnityEngine.UDP.ILicensingListener;\n\tif (v207) goto L_0072;\n\tv192 = v192 + 1;\n\tv212 = v192 < *([v157 @ X8_v13 (Il2CppClass<UnityEngine.UDP.ILicensingListener>)+126]);\n\tv187 = ~v212;\n\tv193 = v193 + 0x10;\n\tv171 = ~v187;\n\tif (v171) goto L_005A;\nL_006F:\n\tv219 = 0x8909C4(this._listener, UnityEngine.UDP.ILicensingListener, 1, 0, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_007B;\nL_0072:\n\tv214 = *([v193 @ X11_v6]) + 1;\n\tv215 = v214 << 4;\n\tv216 = v157 + v215;\n\tv219 = v216 + 0x130;\nL_007B:\n\t*([v219 @ X0_v9])(v138, this._listener, v142, message, *([v219 @ X0_v9+8]), v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0083:\n\treturn;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void dontAllow(int code, string message)
		{
			//IL_01ce: Expected I, but got O
			//IL_00ea: Expected O, but got I
			//IL_0167: Unknown result type (might be due to invalid IL or missing references)
			//IL_016c: Expected O, but got Unknown
			//IL_0189: Expected O, but got I
			//IL_0198: Expected O, but got I
			//IL_0136: Expected O, but got I
			object arg = code;
			string message2 = $"License check failed. ResultCode: {arg}, message:{message}";
			Debug.Log(message2);
			ILicensingListener listener = _listener;
			if (_listener == null)
			{
				return;
			}
			int num = code - 1;
			bool flag = num < 2;
			bool flag2 = !flag;
			int num2 = num - 2;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 25407488 + 4004;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ X9_v10 (System.Int32)+v78 @ X8_v12 (System.Int32)*4]");
				int num4 = 0;
			}
			else
			{
				int num4 = 3;
			}
			IntPtr intPtr = (IntPtr)listener;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ X8_v13 (Il2CppClass<UnityEngine.UDP.ILicensingListener>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_014f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ X8_v13 (Il2CppClass<UnityEngine.UDP.ILicensingListener>)+B0]");
			object obj = 0L + 8L;
			int num5 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ X11_v6-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ILicensingListener))
				{
					break;
				}
				num5++;
				int num6 = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ X8_v13 (Il2CppClass<UnityEngine.UDP.ILicensingListener>)+126]");
				bool flag5 = (long)num6 < 0L;
				bool flag6 = !flag5;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag6)
				{
					continue;
				}
				goto IL_014f;
			}
			object obj2 = obj + 1;
			int num7 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num7;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_021d;
			IL_014f:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_021d;
			IL_021d:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v219 @ X0_v9] (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x15C9A48", Offset = "0x15C9A48", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EB4940]);\n\tv27 = *([v26 @ X8_v19]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, code, message, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20299D1]) = v44;\nL_001C:\n\t// 28 Box v50 @ X0_v3 (System.Object), typeof(System.Int32), &code @ X1 (System.Int32)\n\tv58 = System.String::Format(\"License check error. ResultCode: {0}, message:{1}\", v50, message);\n\tgoto L_0035;\n\tv66 = *([v62 @ X8_v10+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tgoto L_0035;\n\tv75 = v62;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v75, v53, v54, v55, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0035:\n\tUnityEngine.Debug::Log(v58);\n\tv76 = this._listener;\n\tv77 = this._listener == 0;\n\tif (v77) goto L_0087;\n\tv78 = code - 1;\n\tv79 = v78 < 4;\n\tv80 = ~v79;\n\tv81 = v78 - 4;\n\tv83 = v81 == 0;\n\tv88 = ~v83;\n\tv89 = v80 & v88;\n\tif (v89) goto L_0050;\n\tv152 = 0x183B000 + 0xF7C;\n\tv155 = *([v152 @ X9_v9 (System.Int32)+v78 @ X8_v12 (System.Int32)*4]) + v152;\n\t// 75 IndirectJump v155 @ X9_v10, v58 @ X0_v5 (System.String), v58 @ X0_v5 (System.String), 0, message @ X2 (System.String), 0, v30 @ X4, v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\tX21 = X8;\n\tgoto L_0050;\nL_0050:\n\tv183 = *([v76 @ X20_v2 (UnityEngine.UDP.ILicensingListener)]);\n\tv140 = *([v183 @ X8_v13 (Il2CppClass<UnityEngine.UDP.ILicensingListener>)+126]) == 0;\n\tif (v140) goto L_0073;\n\tv218 = *([v183 @ X8_v13 (Il2CppClass<UnityEngine.UDP.ILicensingListener>)+B0]) + 8;\nL_005E:\n\tv233 = *([v218 @ X11_v6-8]) == UnityEngine.UDP.ILicensingListener;\n\tif (v233) goto L_0076;\n\tv219 = v219 + 1;\n\tv238 = v219 < *([v183 @ X8_v13 (Il2CppClass<UnityEngine.UDP.ILicensingListener>)+126]);\n\tv213 = ~v238;\n\tv218 = v218 + 0x10;\n\tv197 = ~v213;\n\tif (v197) goto L_005E;\nL_0073:\n\tv245 = 0x8909C4(this._listener, UnityEngine.UDP.ILicensingListener, 2, 0, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_007F;\nL_0076:\n\tv240 = *([v218 @ X11_v6]) + 2;\n\tv241 = v240 << 4;\n\tv242 = v183 + v241;\n\tv245 = v242 + 0x130;\nL_007F:\n\t*([v245 @ X0_v9])(v138, this._listener, 5, message, *([v245 @ X0_v9+8]), v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0087:\n\treturn;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void applicationError(int code, string message)
		{
			//IL_01ca: Expected I, but got O
			//IL_00c6: Expected O, but got I
			//IL_00e6: Expected O, but got I
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0168: Expected O, but got Unknown
			//IL_0185: Expected O, but got I
			//IL_0194: Expected O, but got I
			//IL_0132: Expected O, but got I
			object arg = code;
			string message2 = $"License check error. ResultCode: {arg}, message:{message}";
			Debug.Log(message2);
			ILicensingListener listener = _listener;
			if (_listener == null)
			{
				return;
			}
			int num = code - 1;
			bool flag = num < 4;
			bool flag2 = !flag;
			int num2 = num - 4;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			IntPtr intPtr = default(IntPtr);
			if (!(flag2 && flag4))
			{
				int num3 = 25407488 + 3964;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ X9_v9 (System.Int32)+v78 @ X8_v12 (System.Int32)*4]");
				object obj = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v155 @ X9_v10 (should have been resolved before IL gen)");
			}
			else
			{
				intPtr = (IntPtr)listener;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ X8_v13 (Il2CppClass<UnityEngine.UDP.ILicensingListener>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_014b;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ X8_v13 (Il2CppClass<UnityEngine.UDP.ILicensingListener>)+B0]");
			object obj2 = 0L + 8L;
			int num4 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ X11_v6-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ILicensingListener))
				{
					break;
				}
				num4++;
				int num5 = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ X8_v13 (Il2CppClass<UnityEngine.UDP.ILicensingListener>)+126]");
				bool flag5 = (long)num5 < 0L;
				bool flag6 = !flag5;
				obj2 = (long)(IntPtr)obj2 + 16L;
				if (!flag6)
				{
					continue;
				}
				goto IL_014b;
			}
			object obj3 = obj2 + 2;
			int num6 = (int)((long)(IntPtr)obj3 << 4);
			object obj4 = (long)intPtr + (long)num6;
			object obj5 = (long)(IntPtr)obj4 + 304L;
			goto IL_0219;
			IL_0219:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v245 @ X0_v9] (should have been resolved before IL gen)");
			return;
			IL_014b:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0219;
		}

		[Token(Token = "0x600001E")]
		[Address(RVA = "0x15C98C4", Offset = "0x15C98C4", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = codeFromLicenseService - 1;\n\tv2 = v0 < 2;\n\tv3 = ~v2;\n\tv4 = v0 - 2;\n\tv6 = v4 == 0;\n\tv11 = ~v6;\n\tv12 = v3 & v11;\n\tif (v12) goto L_0012;\n\tv14 = 0x183B000 + 0xFA4;\n\treturn *([v14 @ X9_v2 (System.Int32)+v0 @ X8_v1 (System.Int32)*4]);\nL_0012:\n\treturn 3;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private LicensingCode convertLicensingCode(int codeFromLicenseService)
		{
			int num = codeFromLicenseService - 1;
			bool flag = num < 2;
			bool flag2 = !flag;
			int num2 = num - 2;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 25407488 + 4004;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ X9_v2 (System.Int32)+v0 @ X8_v1 (System.Int32)*4]");
				return LicensingCode.RETRY;
			}
			return LicensingCode.STORE_NOT_SUPPORT;
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x15C9BB8", Offset = "0x15C9BB8", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = errorCodeFromService - 1;\n\tv2 = v0 < 4;\n\tv3 = ~v2;\n\tv4 = v0 - 4;\n\tv6 = v4 == 0;\n\tv11 = ~v6;\n\tv12 = v3 & v11;\n\tif (v12) goto L_0016;\n\tv14 = 0x183B000 + 0xF90;\n\tv17 = *([v14 @ X9_v2 (System.Int32)+v0 @ X8_v1 (System.Int32)*4]) + v14;\n\t// 18 IndirectJump v17 @ X9_v3, 1, 1, errorCodeFromService @ X1 (System.Int32), methodInfo @ X2 (Il2CppMethodInfo), v19 @ X3, v20 @ X4, v21 @ X5, v22 @ X6, v23 @ X7, v24 @ V0, v25 @ V1, v26 @ V2, v27 @ V3, v28 @ V4, v29 @ V5, v30 @ V6, v31 @ V7\n\tX0 = X8;\n\treturn X0;\nL_0016:\n\treturn 5;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private LicensingErrorCode convertLicensingErrorCode(int errorCodeFromService)
		{
			//IL_008f: Expected O, but got I
			int num = errorCodeFromService - 1;
			bool flag = num < 4;
			bool flag2 = !flag;
			int num2 = num - 4;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 25407488 + 3984;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ X9_v2 (System.Int32)+v0 @ X8_v1 (System.Int32)*4]");
				object obj = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v17 @ X9_v3 (should have been resolved before IL gen)");
			}
			return LicensingErrorCode.ERROR_MISSING_PERMISSION;
		}
	}
}
