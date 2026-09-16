using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal.Privacy
{
	[Token(Token = "0x20000D9")]
	internal class UnsupportedEEARegionValidator : IPlatformEEARegionValidator
	{
		[Token(Token = "0x40003CB")]
		private const string UNSUPPORTED_MSG = "EEA region validation is not supported on this platform.";

		[Token(Token = "0x60007B5")]
		[Address(RVA = "0xB50C60", Offset = "0xB50C60", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EFAB38]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methods, callback, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2022782]) = v38;\nL_0019:\n\tgoto L_0023;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0023;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methods, callback, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0023:\n\tUnityEngine.Debug::Log(\"EEA region validation is not supported on this platform.\");\n\tv56 = callback == 0;\n\tif (v56) goto L_0037;\n\tSystem.Action`1<EasyMobile.EEARegionStatus>::Invoke(callback, 0);\n\treturn;\nL_0037:\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ValidateEEARegionStatus(List<EEARegionValidationMethods> methods, Action<EEARegionStatus> callback)
		{
			Debug.Log("EEA region validation is not supported on this platform.");
			callback?.Invoke(default(EEARegionStatus));
		}

		[Token(Token = "0x60007B6")]
		[Address(RVA = "0xB50CF8", Offset = "0xB50CF8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public UnsupportedEEARegionValidator()
		{
		}
	}
}
