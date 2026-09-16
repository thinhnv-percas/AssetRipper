using AssetRipperInjected;
using Cpp2ILInjected;
using LunarConsolePlugin;

namespace LunarConsolePluginInternal
{
	[Token(Token = "0x2000020")]
	public static class CVarExtension
	{
		[Token(Token = "0x60000C2")]
		[Address(RVA = "0x13DF12C", Offset = "0x13DF12C", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1EEDC38]);\n\tv27 = *([v26 @ X8_v22]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, value, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2028AB8]) = v45;\nL_001B:\n\tgoto L_002D;\n\tv51 = *([1F10000]);\n\tv52 = *([v51 @ X8_v19]);\n\tv53 = \"il2cpp_codegen_initialize_method\"(v52, value, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv56 = 0 | 1;\n\t*([2028B29]) = v56;\nL_002D:\n\tgoto L_0036;\n\tv68 = *([v63 @ X0_v3+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tgoto L_0036;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v63, value, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0036:\n\tv78 = UnityEngine.Object::op_Inequality(v62.s_instance, 0);\n\tv80 = v78 == 0;\n\tif (v80) goto L_0061;\n\tLunarConsolePlugin.CVar::set_Value(cvar, value);\n\tgoto L_0057;\n\tv123 = *([1F10000]);\n\tv124 = *([v123 @ X8_v14]);\n\tv125 = \"il2cpp_codegen_initialize_method\"(v124, v90, v77, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv128 = 0 | 1;\n\t*([2028B29]) = v128;\nL_0057:\n\tLunarConsolePlugin.LunarConsole::UpdateVariable(v112.s_instance, cvar);\n\treturn;\nL_0061:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Set(this CVar cvar, string value)
		{
			if (LunarConsole.s_instance != null)
			{
				cvar.Value = value;
				LunarConsole.s_instance.UpdateVariable(cvar);
			}
		}
	}
}
