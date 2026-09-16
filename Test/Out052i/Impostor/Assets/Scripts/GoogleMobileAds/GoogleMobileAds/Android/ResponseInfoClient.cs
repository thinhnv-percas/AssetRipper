using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	[Token(Token = "0x200001B")]
	internal class ResponseInfoClient : IResponseInfoClient
	{
		[Token(Token = "0x4000049")]
		[FieldOffset(Offset = "0x10")]
		private AndroidJavaObject adFormat;

		[Token(Token = "0x400004A")]
		[FieldOffset(Offset = "0x18")]
		private AndroidJavaObject androidResponseInfo;

		[Token(Token = "0x60000F1")]
		[Address(RVA = "0x1346960", Offset = "0x1346960", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, adFormat, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, adFormat, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv52 = \"getResponseInfo\";\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, adFormat, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A367E9]) = v41;\nL_001D:\n\tSystem.Object::.ctor(this);\n\tthis.adFormat = adFormat;\n\tgoto L_002C;\n\tv54 = 0xB3490C(Il2CppMethodInfo, 0, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002C:\n\tgoto L_0031;\n\tv63 = 0xB348B0(v58, v43, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0031:\n\tgoto L_0039;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v64, v43, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0039:\n\tgoto L_0046;\n\tv76 = 0xB348B0(v71, v43, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv88 = UnityEngine.AndroidJavaObject::Call(adFormat, \"getResponseInfo\", v81.Value);\n\tthis.androidResponseInfo = v88;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ResponseInfoClient(AndroidJavaObject adFormat)
		{
			this.adFormat = adFormat;
			androidResponseInfo = (AndroidJavaObject)adFormat.Call<object>("getResponseInfo", Array.Empty<object>());
		}

		[Token(Token = "0x60000F2")]
		[Address(RVA = "0x134B5A0", Offset = "0x134B5A0", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = Il2CppMethodInfo;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv40 = Il2CppMethodInfo;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv54 = \"getMediationAdapterClassName\";\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 1;\n\t*([1A367EA]) = v36;\nL_0018:\n\tv38 = this.androidResponseInfo == 0;\n\tif (v38) goto L_004E;\n\tgoto L_0029;\n\tv56 = 0xB3490C(Il2CppMethodInfo, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0029:\n\tgoto L_002E;\n\tv85 = 0xB348B0(v60, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_002E:\n\tgoto L_003A;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v86, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_003A:\n\tgoto L_0046;\n\tv101 = 0xB348B0(v95, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0046:\n\treturnVal2 = UnityEngine.AndroidJavaObject::Call(this.androidResponseInfo, \"getMediationAdapterClassName\", v82.Value);\n\treturn returnVal2;\nL_004E:\n\treturn 0;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetMediationAdapterClassName()
		{
			if (androidResponseInfo != null)
			{
				return (string)androidResponseInfo.Call<object>("getMediationAdapterClassName", Array.Empty<object>());
			}
			return null;
		}

		[Token(Token = "0x60000F3")]
		[Address(RVA = "0x134B67C", Offset = "0x134B67C", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = Il2CppMethodInfo;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv40 = Il2CppMethodInfo;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv54 = \"getResponseId\";\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 1;\n\t*([1A367EB]) = v36;\nL_0018:\n\tv38 = this.androidResponseInfo == 0;\n\tif (v38) goto L_004E;\n\tgoto L_0029;\n\tv56 = 0xB3490C(Il2CppMethodInfo, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0029:\n\tgoto L_002E;\n\tv85 = 0xB348B0(v60, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_002E:\n\tgoto L_003A;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v86, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_003A:\n\tgoto L_0046;\n\tv101 = 0xB348B0(v95, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0046:\n\treturnVal2 = UnityEngine.AndroidJavaObject::Call(this.androidResponseInfo, \"getResponseId\", v82.Value);\n\treturn returnVal2;\nL_004E:\n\treturn 0;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetResponseId()
		{
			if (androidResponseInfo != null)
			{
				return (string)androidResponseInfo.Call<object>("getResponseId", Array.Empty<object>());
			}
			return null;
		}

		[Token(Token = "0x60000F4")]
		[Address(RVA = "0x134B758", Offset = "0x134B758", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv58 = \"toString\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A367EC]) = v38;\nL_001E:\n\tgoto L_0027;\n\tv48 = 0xB3490C(Il2CppMethodInfo, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0027:\n\tgoto L_002C;\n\tv59 = 0xB348B0(v52, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_002C:\n\tgoto L_0034;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v60, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0034:\n\tgoto L_0046;\n\tv72 = 0xB348B0(v67, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0046:\n\treturnVal1 = UnityEngine.AndroidJavaObject::Call(this.androidResponseInfo, \"toString\", v77.Value);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			return (string)androidResponseInfo.Call<object>("toString", Array.Empty<object>());
		}
	}
}
