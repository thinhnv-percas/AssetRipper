using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	[Token(Token = "0x2000015")]
	internal class CustomNativeTemplateClient : ICustomNativeTemplateClient
	{
		[Token(Token = "0x400003A")]
		[FieldOffset(Offset = "0x10")]
		private AndroidJavaObject customNativeAd;

		[Token(Token = "0x60000B4")]
		[Address(RVA = "0x1344F60", Offset = "0x1344F60", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.customNativeAd = customNativeAd;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CustomNativeTemplateClient(AndroidJavaObject customNativeAd)
		{
			this.customNativeAd = customNativeAd;
		}

		[Token(Token = "0x60000B5")]
		[Address(RVA = "0x1346E18", Offset = "0x1346E18", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv58 = Il2CppMethodInfo;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv66 = System.Collections.Generic.List`1<System.String>;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv77 = \"getAvailableAssetNames\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v77, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A367B6]) = v38;\nL_0024:\n\tgoto L_002D;\n\tv48 = 0xB3490C(Il2CppMethodInfo, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_002D:\n\tgoto L_0032;\n\tv60 = 0xB348B0(v52, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0032:\n\tgoto L_003A;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v61, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_003A:\n\tgoto L_004B;\n\tv78 = 0xB348B0(v71, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_004B:\n\tv94 = UnityEngine.AndroidJavaObject::Call(this.customNativeAd, \"getAvailableAssetNames\", v83.Value);\n\tv99 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v99, v94);\n\treturn v99;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public List<string> GetAvailableAssetNames()
		{
			//IL_0040: Expected I4, but got O
			object obj = customNativeAd.Call<object>("getAvailableAssetNames", Array.Empty<object>());
			return new List<string>((int)obj);
		}

		[Token(Token = "0x60000B6")]
		[Address(RVA = "0x1346F38", Offset = "0x1346F38", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv58 = \"getTemplateId\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A367B7]) = v38;\nL_001E:\n\tgoto L_0027;\n\tv48 = 0xB3490C(Il2CppMethodInfo, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0027:\n\tgoto L_002C;\n\tv59 = 0xB348B0(v52, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_002C:\n\tgoto L_0034;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v60, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0034:\n\tgoto L_0046;\n\tv72 = 0xB348B0(v67, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0046:\n\treturnVal1 = UnityEngine.AndroidJavaObject::Call(this.customNativeAd, \"getTemplateId\", v77.Value);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetTemplateId()
		{
			return (string)customNativeAd.Call<object>("getTemplateId", Array.Empty<object>());
		}

		[Token(Token = "0x60000B7")]
		[Address(RVA = "0x1347008", Offset = "0x1347008", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, key, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv47 = System.Object[];\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, key, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = \"getImage\";\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, key, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A367B8]) = v41;\nL_001E:\n\t// 30 NewArr v45 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\tv53 = key == 0;\n\tif (v53) goto L_002D;\n\t// 39 IsInst v78 @ X0_v18, typeof(System.Object), key @ X1 (System.String)\n\tv80 = v78 == 0;\n\tif (v80) goto L_0054;\nL_002D:\n\tv45[0] = key;\n\tv66 = UnityEngine.AndroidJavaObject::Call(this.customNativeAd, \"getImage\", v45);\n\tv120 = *([v66 @ X0_v13 (System.Object)+18]) != 0;\n\tif (v120) goto L_FFFFFFFF;\n\tgoto L_0051;\nL_0051:\n\treturn returnVal2;\n\tv74 = new System.NullReferenceException();\n\tv91 = new System.IndexOutOfRangeException();\nL_0054:\n\tv100 = new System.ArrayTypeMismatchException();\n\tthrow v100;\n\treturn returnVal1;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public byte[] GetImageByteArray(string key)
		{
			object[] array = new object[1];
			if (key != null)
			{
				object obj = key as object;
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			array[0] = key;
			object result = customNativeAd.Call<object>("getImage", array);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X0_v13 (System.Object)+18]");
			if ((nint)0 == 0)
			{
				return null;
			}
			return (byte[])result;
		}

		[Token(Token = "0x60000B8")]
		[Address(RVA = "0x13470F4", Offset = "0x13470F4", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, key, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv47 = System.Object[];\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, key, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = System.String;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, key, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv77 = \"getText\";\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v77, key, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A367B9]) = v41;\nL_0021:\n\t// 33 NewArr v45 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\tv54 = key == 0;\n\tif (v54) goto L_0030;\n\t// 42 IsInst v81 @ X0_v19, typeof(System.Object), key @ X1 (System.String)\n\tv83 = v81 == 0;\n\tif (v83) goto L_005B;\nL_0030:\n\tv45[0] = key;\n\tv67 = UnityEngine.AndroidJavaObject::Call(this.customNativeAd, \"getText\", v45);\n\tv116 = System.String::Equals(v67, v114.Empty);\n\tv132 = v116 == 0;\n\tv123 = ~v132;\n\tv120 = ~v123;\n\tif (v120) goto L_FFFFFFFF;\n\tgoto L_0058;\nL_0058:\n\treturn returnVal2;\n\tv75 = new System.NullReferenceException();\n\tv94 = new System.IndexOutOfRangeException();\nL_005B:\n\tv103 = new System.ArrayTypeMismatchException();\n\tthrow v103;\n\treturn returnVal1;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetText(string key)
		{
			object[] array = new object[1];
			if (key != null)
			{
				object obj = key as object;
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			array[0] = key;
			object obj2 = customNativeAd.Call<object>("getText", array);
			if (((string)obj2).Equals(string.Empty))
			{
				return null;
			}
			return (string)obj2;
		}

		[Token(Token = "0x60000B9")]
		[Address(RVA = "0x1347208", Offset = "0x1347208", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = System.Object[];\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, assetName, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv47 = \"performClick\";\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, assetName, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A367BA]) = v41;\nL_001B:\n\t// 27 NewArr v45 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\tv50 = assetName == 0;\n\tif (v50) goto L_002A;\n\t// 36 IsInst v64 @ X0_v14, typeof(System.Object), assetName @ X1 (System.String)\n\tv66 = v64 == 0;\n\tif (v66) goto L_003D;\nL_002A:\n\tv45[0] = assetName;\n\tUnityEngine.AndroidJavaObject::Call(this.customNativeAd, \"performClick\", v45);\n\treturn;\n\tv60 = new System.NullReferenceException();\n\tv74 = new System.IndexOutOfRangeException();\nL_003D:\n\tv80 = new System.ArrayTypeMismatchException();\n\tthrow v80;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void PerformClick(string assetName)
		{
			object[] array = new object[1];
			if (assetName != null)
			{
				object obj = assetName as object;
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			array[0] = assetName;
			customNativeAd.Call("performClick", array);
		}

		[Token(Token = "0x60000BA")]
		[Address(RVA = "0x13472CC", Offset = "0x13472CC", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = \"recordImpression\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A367BB]) = v38;\nL_001B:\n\tgoto L_0024;\n\tv47 = 0xB3490C(Il2CppMethodInfo, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0024:\n\tgoto L_0029;\n\tv56 = 0xB348B0(v51, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0029:\n\tgoto L_0031;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v57, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0031:\n\tgoto L_0041;\n\tv69 = 0xB348B0(v64, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0041:\n\tUnityEngine.AndroidJavaObject::Call(this.customNativeAd, \"recordImpression\", v73.Value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RecordImpression()
		{
			customNativeAd.Call("recordImpression");
		}
	}
}
