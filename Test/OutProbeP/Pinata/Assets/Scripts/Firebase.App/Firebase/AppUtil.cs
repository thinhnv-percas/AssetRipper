using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Firebase
{
	[Token(Token = "0x2000009")]
	internal class AppUtil
	{
		[Token(Token = "0x600003D")]
		[Address(RVA = "0x15FB528", Offset = "0x15FB528", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ECFB48]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A08F]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Firebase.AppUtilPINVOKE>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tFirebase.AppUtilPINVOKE::PollCallbacks();\n\tv49 = Firebase.AppUtilPINVOKE+SWIGPendingException::get_Pending();\n\tv51 = v49 == 0;\n\tv52 = ~v51;\n\tif (v52) goto L_0028;\n\treturn;\nL_0028:\n\tv56 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\tthrow System.TypeLoadException;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void PollCallbacks()
		{
			AppUtilPINVOKE.PollCallbacks();
			if (!AppUtilPINVOKE.SWIGPendingException.Pending)
			{
				return;
			}
			Exception ex = AppUtilPINVOKE.SWIGPendingException.Retrieve();
			throw new TypeLoadException();
		}

		[Token(Token = "0x600003E")]
		[Address(RVA = "0x15FB630", Offset = "0x15FB630", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F00CF0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A090]) = v38;\nL_0019:\n\tgoto L_0020;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0020;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0020:\n\tFirebase.AppUtilPINVOKE::AppEnableLogCallback(arg0);\n\tv53 = Firebase.AppUtilPINVOKE+SWIGPendingException::get_Pending();\n\tv55 = v53 == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_002C;\n\treturn;\nL_002C:\n\tv61 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\tthrow System.TypeLoadException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void AppEnableLogCallback(bool arg0)
		{
			AppUtilPINVOKE.AppEnableLogCallback(arg0);
			if (!AppUtilPINVOKE.SWIGPendingException.Pending)
			{
				return;
			}
			Exception ex = AppUtilPINVOKE.SWIGPendingException.Retrieve();
			throw new TypeLoadException();
		}

		[Token(Token = "0x600003F")]
		[Address(RVA = "0x15FB750", Offset = "0x15FB750", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EBCEA0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A091]) = v38;\nL_0019:\n\tgoto L_0020;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0020;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0020:\n\tFirebase.AppUtilPINVOKE::SetEnabledAllAppCallbacks(arg0);\n\tv53 = Firebase.AppUtilPINVOKE+SWIGPendingException::get_Pending();\n\tv55 = v53 == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_002C;\n\treturn;\nL_002C:\n\tv61 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\tthrow System.TypeLoadException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void SetEnabledAllAppCallbacks(bool arg0)
		{
			AppUtilPINVOKE.SetEnabledAllAppCallbacks(arg0);
			if (!AppUtilPINVOKE.SWIGPendingException.Pending)
			{
				return;
			}
			Exception ex = AppUtilPINVOKE.SWIGPendingException.Retrieve();
			throw new TypeLoadException();
		}

		[Token(Token = "0x6000040")]
		[Address(RVA = "0x15FB870", Offset = "0x15FB870", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EC4BD0]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, arg1, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A092]) = v41;\nL_001B:\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, arg1, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0023:\n\tFirebase.AppUtilPINVOKE::SetEnabledAppCallbackByName(arg0, arg1);\n\tv57 = Firebase.AppUtilPINVOKE+SWIGPendingException::get_Pending();\n\tv59 = v57 == 0;\n\tv60 = ~v59;\n\tif (v60) goto L_0030;\n\treturn;\nL_0030:\n\tv66 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\tthrow System.TypeLoadException;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void SetEnabledAppCallbackByName(string arg0, bool arg1)
		{
			AppUtilPINVOKE.SetEnabledAppCallbackByName(arg0, arg1);
			if (!AppUtilPINVOKE.SWIGPendingException.Pending)
			{
				return;
			}
			Exception ex = AppUtilPINVOKE.SWIGPendingException.Retrieve();
			throw new TypeLoadException();
		}

		[Token(Token = "0x6000041")]
		[Address(RVA = "0x15FB9C0", Offset = "0x15FB9C0", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED3458]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A093]) = v38;\nL_0019:\n\tgoto L_0020;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0020;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0020:\n\tv53 = Firebase.AppUtilPINVOKE::GetEnabledAppCallbackByName(arg0);\n\tv55 = Firebase.AppUtilPINVOKE+SWIGPendingException::get_Pending();\n\tv57 = v55 == 0;\n\tv58 = ~v57;\n\tif (v58) goto L_002E;\n\treturn v53;\nL_002E:\n\tv64 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool GetEnabledAppCallbackByName(string arg0)
		{
			//IL_0069: Expected I4, but got O
			bool enabledAppCallbackByName = AppUtilPINVOKE.GetEnabledAppCallbackByName(arg0);
			if (!AppUtilPINVOKE.SWIGPendingException.Pending)
			{
				return enabledAppCallbackByName;
			}
			Exception ex = AppUtilPINVOKE.SWIGPendingException.Retrieve();
			TypeLoadException ex2 = new TypeLoadException();
			return (byte)(int)ex2 != 0;
		}

		[Token(Token = "0x6000042")]
		[Address(RVA = "0x15FBB04", Offset = "0x15FBB04", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC7038]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A094]) = v38;\nL_0019:\n\tgoto L_0020;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0020;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0020:\n\tFirebase.AppUtilPINVOKE::SetLogFunction(arg0);\n\tv53 = Firebase.AppUtilPINVOKE+SWIGPendingException::get_Pending();\n\tv55 = v53 == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_002C;\n\treturn;\nL_002C:\n\tv61 = Firebase.AppUtilPINVOKE+SWIGPendingException::Retrieve();\n\tthrow System.TypeLoadException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void SetLogFunction(LogUtil.LogMessageDelegate arg0)
		{
			AppUtilPINVOKE.SetLogFunction(arg0);
			if (!AppUtilPINVOKE.SWIGPendingException.Pending)
			{
				return;
			}
			Exception ex = AppUtilPINVOKE.SWIGPendingException.Retrieve();
			throw new TypeLoadException();
		}
	}
}
