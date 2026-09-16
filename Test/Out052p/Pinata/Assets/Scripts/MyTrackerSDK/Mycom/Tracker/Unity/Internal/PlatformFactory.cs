using AssetRipperInjected;
using Cpp2ILInjected;
using Mycom.Tracker.Unity.Internal.Implementations.Android;
using Mycom.Tracker.Unity.Internal.Interfaces;

namespace Mycom.Tracker.Unity.Internal
{
	[Token(Token = "0x2000009")]
	internal static class PlatformFactory
	{
		[Token(Token = "0x600004C")]
		[Address(RVA = "0x1622C0C", Offset = "0x1622C0C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF6A00]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A30B]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Mycom.Tracker.Unity.Internal.Implementations.Android.Tracker>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Mycom.Tracker.Unity.Internal.Implementations.Android.Tracker;\nL_0024:\n\treturn v49.Instance;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static ITracker CreateTracker()
		{
			return Mycom.Tracker.Unity.Internal.Implementations.Android.Tracker.Instance;
		}
	}
}
