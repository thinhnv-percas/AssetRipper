using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Api
{
	[Token(Token = "0x200004E")]
	public class CustomNativeTemplateAd
	{
		[Token(Token = "0x4000119")]
		[FieldOffset(Offset = "0x10")]
		private ICustomNativeTemplateClient client;

		[Token(Token = "0x6000326")]
		[Address(RVA = "0x13558B0", Offset = "0x13558B0", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.client = client;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal CustomNativeTemplateAd(ICustomNativeTemplateClient client)
		{
			this.client = client;
		}

		[Token(Token = "0x6000327")]
		[Address(RVA = "0x13585F8", Offset = "0x13585F8", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = GoogleMobileAds.Common.ICustomNativeTemplateClient;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A36904]) = v33;\nL_0019:\n\tgoto L_0044;\n\tv43 = *([v37 @ X8_v3+B0]);\n\tv44 = v43 + 8;\n\tv46 = *([v93 @ X10_v7-8]);\n\tv98 = v46 == v40;\n\tif (v98) goto L_0038;\n\tv76 = v92 - 1;\n\tv78 = v93 + 0x10;\n\tv49 = v92 != 1;\n\tif (v49) goto L_FFFFFFFF;\n\tv79 = 2;\n\tv80 = v34;\n\tv81 = 0xB349B4(v80, v40, v79, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tgoto L_0044;\nL_0038:\n\tv148 = *([v93 @ X10_v7]);\n\tv149 = v148 + 2;\n\tv150 = v149 << 4;\n\tv151 = v37 + v150;\n\tv152 = v151 + 0x138;\nL_0044:\n\tinterfaceTailCallResult = GoogleMobileAds.Common.ICustomNativeTemplateClient::GetAvailableAssetNames(this.client);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public List<string> GetAvailableAssetNames()
		{
			return client.GetAvailableAssetNames();
		}

		[Token(Token = "0x6000328")]
		[Address(RVA = "0x1355A38", Offset = "0x1355A38", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = GoogleMobileAds.Common.ICustomNativeTemplateClient;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A36905]) = v33;\nL_0019:\n\tgoto L_0043;\n\tv43 = *([v37 @ X8_v3+B0]);\n\tv44 = v43 + 8;\n\tv46 = *([v93 @ X10_v7-8]);\n\tv98 = v46 == v40;\n\tif (v98) goto L_0038;\n\tv76 = v92 - 1;\n\tv78 = v93 + 0x10;\n\tv49 = v92 != 1;\n\tif (v49) goto L_FFFFFFFF;\n\tv79 = v34;\n\tv80 = 0;\n\tv81 = 0xB349B4(v79, v40, v80, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tgoto L_0043;\nL_0038:\n\tv148 = *([v93 @ X10_v7]);\n\tv149 = v148 << 4;\n\tv150 = v37 + v149;\n\tv151 = v150 + 0x138;\nL_0043:\n\tinterfaceTailCallResult = GoogleMobileAds.Common.ICustomNativeTemplateClient::GetTemplateId(this.client);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetCustomTemplateId()
		{
			return client.GetTemplateId();
		}

		[Token(Token = "0x6000329")]
		[Address(RVA = "0x135869C", Offset = "0x135869C", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = GoogleMobileAds.Common.ICustomNativeTemplateClient;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, key, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A36906]) = v36;\nL_001B:\n\tgoto L_0043;\n\tv46 = *([v40 @ X8_v3+B0]);\n\tv47 = v46 + 8;\n\tv49 = *([v96 @ X10_v7-8]);\n\tv101 = v49 == v43;\n\tif (v101) goto L_003A;\n\tv79 = v95 - 1;\n\tv81 = v96 + 0x10;\n\tv52 = v95 != 1;\n\tif (v52) goto L_FFFFFFFF;\n\tv82 = 1;\n\tv83 = v37;\n\tv84 = 0xB349B4(v83, v43, v82, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tgoto L_0043;\nL_003A:\n\tv159 = *([v96 @ X10_v7]);\n\tv160 = v159 + 1;\n\tv161 = v160 << 4;\n\tv162 = v40 + v161;\n\tv163 = v162 + 0x138;\nL_0043:\n\treturnVal2 = GoogleMobileAds.Common.ICustomNativeTemplateClient::GetImageByteArray(this.client, key);\n\tv146 = returnVal2 == 0;\n\tif (v146) goto L_0052;\n\treturnVal3 = GoogleMobileAds.Common.Utils::GetTexture2DFromByteArray(returnVal2);\n\treturn returnVal3;\nL_0052:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Texture2D GetTexture2D(string key)
		{
			Texture2D imageByteArray = (Texture2D)(object)client.GetImageByteArray(key);
			if ((object)imageByteArray != null)
			{
				return Utils.GetTexture2DFromByteArray((byte[])(object)imageByteArray);
			}
			return imageByteArray;
		}

		[Token(Token = "0x600032A")]
		[Address(RVA = "0x135875C", Offset = "0x135875C", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = GoogleMobileAds.Common.ICustomNativeTemplateClient;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, key, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A36907]) = v36;\nL_001B:\n\tgoto L_0048;\n\tv46 = *([v40 @ X8_v3+B0]);\n\tv47 = v46 + 8;\n\tv49 = *([v96 @ X10_v7-8]);\n\tv101 = v49 == v43;\n\tif (v101) goto L_003A;\n\tv79 = v95 - 1;\n\tv81 = v96 + 0x10;\n\tv52 = v95 != 1;\n\tif (v52) goto L_FFFFFFFF;\n\tv82 = 3;\n\tv83 = v37;\n\tv84 = 0xB349B4(v83, v43, v82, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tgoto L_0048;\nL_003A:\n\tv155 = *([v96 @ X10_v7]);\n\tv156 = v155 + 3;\n\tv157 = v156 << 4;\n\tv158 = v40 + v157;\n\tv159 = v158 + 0x138;\nL_0048:\n\tinterfaceTailCallResult = GoogleMobileAds.Common.ICustomNativeTemplateClient::GetText(this.client, key);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetText(string key)
		{
			return client.GetText(key);
		}

		[Token(Token = "0x600032B")]
		[Address(RVA = "0x1358808", Offset = "0x1358808", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = GoogleMobileAds.Common.ICustomNativeTemplateClient;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, assetName, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A36908]) = v36;\nL_001B:\n\tgoto L_0048;\n\tv46 = *([v40 @ X8_v3+B0]);\n\tv47 = v46 + 8;\n\tv49 = *([v96 @ X10_v7-8]);\n\tv101 = v49 == v43;\n\tif (v101) goto L_003A;\n\tv79 = v95 - 1;\n\tv81 = v96 + 0x10;\n\tv52 = v95 != 1;\n\tif (v52) goto L_FFFFFFFF;\n\tv82 = 4;\n\tv83 = v37;\n\tv84 = 0xB349B4(v83, v43, v82, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tgoto L_0048;\nL_003A:\n\tv155 = *([v96 @ X10_v7]);\n\tv156 = v155 + 4;\n\tv157 = v156 << 4;\n\tv158 = v40 + v157;\n\tv159 = v158 + 0x138;\nL_0048:\n\tGoogleMobileAds.Common.ICustomNativeTemplateClient::PerformClick(this.client, assetName);\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void PerformClick(string assetName)
		{
			client.PerformClick(assetName);
		}

		[Token(Token = "0x600032C")]
		[Address(RVA = "0x13588B4", Offset = "0x13588B4", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = GoogleMobileAds.Common.ICustomNativeTemplateClient;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A36909]) = v33;\nL_0019:\n\tgoto L_0044;\n\tv43 = *([v37 @ X8_v3+B0]);\n\tv44 = v43 + 8;\n\tv46 = *([v93 @ X10_v7-8]);\n\tv98 = v46 == v40;\n\tif (v98) goto L_0038;\n\tv76 = v92 - 1;\n\tv78 = v93 + 0x10;\n\tv49 = v92 != 1;\n\tif (v49) goto L_FFFFFFFF;\n\tv79 = 5;\n\tv80 = v34;\n\tv81 = 0xB349B4(v80, v40, v79, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tgoto L_0044;\nL_0038:\n\tv148 = *([v93 @ X10_v7]);\n\tv149 = v148 + 5;\n\tv150 = v149 << 4;\n\tv151 = v37 + v150;\n\tv152 = v151 + 0x138;\nL_0044:\n\tGoogleMobileAds.Common.ICustomNativeTemplateClient::RecordImpression(this.client);\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RecordImpression()
		{
			client.RecordImpression();
		}
	}
}
