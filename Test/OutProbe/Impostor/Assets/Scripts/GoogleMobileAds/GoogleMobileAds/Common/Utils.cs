using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace GoogleMobileAds.Common
{
	[Token(Token = "0x2000032")]
	internal class Utils
	{
		[Token(Token = "0x6000265")]
		[Address(RVA = "0x1354BA8", Offset = "0x1354BA8", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = GoogleMobileAds.Common.MobileAdsEventExecutor;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv47 = \"You intitialized an ad object but have not yet called MobileAds.Initialize(). We highly recommend you call MobileAds.Initialize() before interacting with the Google Mobile Ads SDK.\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A368BE]) = v35;\nL_001B:\n\tgoto L_001D;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v36, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001D:\n\tv45 = GoogleMobileAds.Common.MobileAdsEventExecutor::IsActive();\n\tv49 = v45 == 0;\n\tv50 = ~v49;\n\tif (v50) goto L_0033;\n\tgoto L_002E;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v54, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_002E:\n\tUnityEngine.Debug::Log(\"You intitialized an ad object but have not yet called MobileAds.Initialize(). We highly recommend you call MobileAds.Initialize() before interacting with the Google Mobile Ads SDK.\");\nL_0033:\n\tgoto L_0039;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v66, v59, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0039:\n\tGoogleMobileAds.Common.MobileAdsEventExecutor::Initialize();\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void CheckInitialization()
		{
			if (!MobileAdsEventExecutor.IsActive())
			{
				Debug.Log("You intitialized an ad object but have not yet called MobileAds.Initialize(). We highly recommend you call MobileAds.Initialize() before interacting with the Google Mobile Ads SDK.");
			}
			MobileAdsEventExecutor.Initialize();
		}

		[Token(Token = "0x6000266")]
		[Address(RVA = "0x1354C50", Offset = "0x1354C50", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = UnityEngine.Texture2D;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A368BF]) = v37;\nL_0014:\n\tv39 = new UnityEngine.Texture2D();\n\tUnityEngine.Texture2D::.ctor(v39, 1, 1);\n\tv47 = UnityEngine.ImageConversion::LoadImage(v39, img);\n\tv49 = v47 == 0;\n\tif (v49) goto L_002B;\n\treturn v39;\nL_002B:\n\tv69 = new System.InvalidOperationException();\n\tSystem.InvalidOperationException::.ctor(v69, \"Could not load custom native template\\r\\n                        image asset as texture\");\n\tthrow v69;\n\treturn returnVal2;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Texture2D GetTexture2DFromByteArray(byte[] img)
		{
			Texture2D texture2D = new Texture2D(1, 1);
			if (texture2D.LoadImage(img))
			{
				return texture2D;
			}
			InvalidOperationException ex = new InvalidOperationException("Could not load custom native template\r\n                        image asset as texture");
			throw ex;
		}

		[Token(Token = "0x6000267")]
		[Address(RVA = "0x1354D0C", Offset = "0x1354D0C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Utils()
		{
		}
	}
}
