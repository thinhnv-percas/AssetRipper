using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Facebook.Unity.Example
{
	[Token(Token = "0x200005A")]
	internal class AppEvents : MenuBase
	{
		[Token(Token = "0x6000286")]
		[Address(RVA = "0xA060D0", Offset = "0xA060D0", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EE01C0]);\n\tv19 = *([v18 @ X8_v33]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021C94]) = v38;\nL_0017:\n\tv43 = Facebook.Unity.Example.ConsoleBase::Button(this, \"Log FB App Event\");\n\tv45 = v43 == 0;\n\tif (v45) goto L_0080;\n\tthis.status = \"Logged FB.AppEvent\";\n\tv52 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v52);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v52, \"fb_description\", \"Clicked 'Log AppEvent' button\");\n\tgoto L_0047;\n\tv105 = *([v101 @ X0_v9+E0]);\n\tv106 = v105 == 0;\n\tv107 = ~v106;\n\tif (v107) goto L_0047;\n\tv109 = \"il2cpp_codegen_runtime_class_init\"(v101, v95, v96, v97, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0047:\n\tFacebook.Unity.FB::LogAppEvent(\"fb_mobile_achievement_unlocked\", 0, v52);\n\tgoto L_0057;\n\tv122 = *([1EB8180]);\n\tv123 = *([v122 @ X8_v28]);\n\tv124 = \"il2cpp_codegen_initialize_method\"(v123, v114, v115, v64, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv127 = 0 | 1;\n\t*([2021D31]) = v127;\nL_0057:\n\tgoto L_0064;\n\tv132 = *([v128 @ X0_v13 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv133 = v132 == 0;\n\tv134 = ~v133;\n\tgoto L_0064;\n\tv144 = \"il2cpp_codegen_runtime_class_init\"(v128, v114, v115, v64, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv136 = Facebook.Unity.FB;\nL_0064:\n\tv143 = System.String::Concat(\"You may see results showing up at https://www.facebook.com/analytics/\", v140.<AppId>k__BackingField);\n\tgoto L_0079;\n\tv151 = *([v84 @ X8_v25+E0]);\n\tv152 = v151 == 0;\n\tv153 = ~v152;\n\tgoto L_0079;\n\tv156 = v84;\n\tv155 = \"il2cpp_codegen_runtime_class_init\"(v156, v74, v66, v64, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0079:\n\tFacebook.Unity.Example.LogView::AddLog(v143);\n\treturn;\nL_0080:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 86 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void GetGui()
		{
			if (Button("Log FB App Event"))
			{
				status = "Logged FB.AppEvent";
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				dictionary.Add("fb_description", "Clicked 'Log AppEvent' button");
				FB.LogAppEvent("fb_mobile_achievement_unlocked", null, dictionary);
				string log = "You may see results showing up at https://www.facebook.com/analytics/" + FB.AppId;
				LogView.AddLog(log);
			}
		}

		[Token(Token = "0x6000287")]
		[Address(RVA = "0xA063C8", Offset = "0xA063C8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tFacebook.Unity.Example.MenuBase::.ctor(this);\n\treturn;\n")]
		public AppEvents()
		{
		}
	}
}
