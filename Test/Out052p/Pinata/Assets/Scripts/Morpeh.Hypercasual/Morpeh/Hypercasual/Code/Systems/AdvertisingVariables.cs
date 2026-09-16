using AssetRipperInjected;
using Cpp2ILInjected;
using LunarConsolePlugin;

namespace Morpeh.Hypercasual.Code.Systems
{
	[CVarContainer]
	[Token(Token = "0x2000013")]
	public static class AdvertisingVariables
	{
		[Token(Token = "0x4000031")]
		public static readonly CVar IronSourceAndroid;

		[Token(Token = "0x4000032")]
		public static readonly CVar IronSourceiOS;

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x16335C0", Offset = "0x16335C0", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv22 = *([1EBABD8]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 0 | 1;\n\t*([202A4DA]) = v43;\nL_001D:\n\tv52 = new LunarConsolePlugin.CVar();\n\tLunarConsolePlugin.CVar::.ctor(v52, \"IronSourceAndroid\", v48.Empty, 0);\n\tv63.IronSourceAndroid = v52;\n\tv68 = new LunarConsolePlugin.CVar();\n\tLunarConsolePlugin.CVar::.ctor(v68, \"IronSourceiOS\", v66.Empty, 0);\n\tv77.IronSourceiOS = v68;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static AdvertisingVariables()
		{
			CVar ironSourceAndroid = new CVar("IronSourceAndroid", string.Empty);
			IronSourceAndroid = ironSourceAndroid;
			CVar ironSourceiOS = new CVar("IronSourceiOS", string.Empty);
			IronSourceiOS = ironSourceiOS;
		}
	}
}
