using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using GoogleMobileAds.Common;

namespace GoogleMobileAds.Api
{
	[Token(Token = "0x200004F")]
	public class InitializationStatus
	{
		[Token(Token = "0x400011A")]
		[FieldOffset(Offset = "0x10")]
		internal IInitializationStatusClient client;

		[Token(Token = "0x600032D")]
		[Address(RVA = "0x1358958", Offset = "0x1358958", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.client = client;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal InitializationStatus(IInitializationStatusClient client)
		{
			this.client = client;
		}

		[Token(Token = "0x600032E")]
		[Address(RVA = "0x1358980", Offset = "0x1358980", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = GoogleMobileAds.Common.IInitializationStatusClient;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, className, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A3690A]) = v36;\nL_001B:\n\tgoto L_0047;\n\tv46 = *([v40 @ X8_v3+B0]);\n\tv47 = v46 + 8;\n\tv49 = *([v96 @ X10_v7-8]);\n\tv101 = v49 == v43;\n\tif (v101) goto L_003A;\n\tv79 = v95 - 1;\n\tv81 = v96 + 0x10;\n\tv52 = v95 != 1;\n\tif (v52) goto L_FFFFFFFF;\n\tv82 = v37;\n\tv83 = 0;\n\tv84 = 0xB349B4(v82, v43, v83, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tgoto L_0047;\nL_003A:\n\tv155 = *([v96 @ X10_v7]);\n\tv156 = v155 << 4;\n\tv157 = v40 + v156;\n\tv158 = v157 + 0x138;\nL_0047:\n\tinterfaceTailCallResult = GoogleMobileAds.Common.IInitializationStatusClient::getAdapterStatusForClassName(this.client, className);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AdapterStatus getAdapterStatusForClassName(string className)
		{
			return client.getAdapterStatusForClassName(className);
		}

		[Token(Token = "0x600032F")]
		[Address(RVA = "0x1358A28", Offset = "0x1358A28", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = GoogleMobileAds.Common.IInitializationStatusClient;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A3690B]) = v33;\nL_0019:\n\tgoto L_0044;\n\tv43 = *([v37 @ X8_v3+B0]);\n\tv44 = v43 + 8;\n\tv46 = *([v93 @ X10_v7-8]);\n\tv98 = v46 == v40;\n\tif (v98) goto L_0038;\n\tv76 = v92 - 1;\n\tv78 = v93 + 0x10;\n\tv49 = v92 != 1;\n\tif (v49) goto L_FFFFFFFF;\n\tv79 = 1;\n\tv80 = v34;\n\tv81 = 0xB349B4(v80, v40, v79, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tgoto L_0044;\nL_0038:\n\tv148 = *([v93 @ X10_v7]);\n\tv149 = v148 + 1;\n\tv150 = v149 << 4;\n\tv151 = v37 + v150;\n\tv152 = v151 + 0x138;\nL_0044:\n\tinterfaceTailCallResult = GoogleMobileAds.Common.IInitializationStatusClient::getAdapterStatusMap(this.client);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Dictionary<string, AdapterStatus> getAdapterStatusMap()
		{
			return client.getAdapterStatusMap();
		}
	}
}
