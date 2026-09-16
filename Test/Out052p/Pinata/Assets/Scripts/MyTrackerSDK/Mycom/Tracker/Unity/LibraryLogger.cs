using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Mycom.Tracker.Unity
{
	[Token(Token = "0x2000003")]
	public static class LibraryLogger
	{
		[Token(Token = "0x4000006")]
		private static readonly string Tag = "[mytracker.unity]: ";

		[Token(Token = "0x6000001")]
		[Address(RVA = "0x161C564", Offset = "0x161C564", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EAFBC8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A30C]) = v38;\nL_0015:\n\tv41 = System.String::IsNullOrEmpty(message);\n\tv43 = v41 == 0;\n\tif (v43) goto L_0025;\n\treturn;\nL_0025:\n\tgoto L_0030;\n\tv75 = *([v50 @ X0_v4 (Il2CppClass<Mycom.Tracker.Unity.LibraryLogger>)+E0]);\n\tv76 = v75 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_0030;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v50, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv79 = Mycom.Tracker.Unity.LibraryLogger;\nL_0030:\n\tv85 = System.String::Concat(v82.Tag, message);\n\tgoto L_0046;\n\tv93 = *([v70 @ X8_v8+E0]);\n\tv94 = v93 == 0;\n\tv95 = ~v94;\n\tgoto L_0046;\n\tv98 = v70;\n\tv97 = \"il2cpp_codegen_runtime_class_init\"(v98, v83, v55, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0046:\n\tUnityEngine.Debug::Log(v85);\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Log(string message)
		{
			if (!string.IsNullOrEmpty(message))
			{
				string message2 = Tag + message;
				Debug.Log(message2);
			}
		}
	}
}
