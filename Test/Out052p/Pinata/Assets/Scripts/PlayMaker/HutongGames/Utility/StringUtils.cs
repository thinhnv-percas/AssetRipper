using System;
using System.Text.RegularExpressions;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.Utility
{
	[Token(Token = "0x2000085")]
	public static class StringUtils
	{
		[Token(Token = "0x600067C")]
		[Address(RVA = "0xE53DB4", Offset = "0xE53DB4", Length = "0x1E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = &v11 @ stack_-10_v2;\n\tgoto L_0016;\n\tv20 = *([1ED01E8]);\n\tv21 = *([v20 @ X8_v30]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20247C9]) = v40;\nL_0016:\n\t*([v10 @ X29_v1-14]) = 0;\n\tgoto L_0027;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0027;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0027:\n\tv60 = System.Text.RegularExpressions.Regex::Match(s, \"(?<Name>.*)\\\\s(?<Number>[0-9]+)$\");\n\tv65 = System.Text.RegularExpressions.Group::get_Success(v60);\n\tv108 = v65 == 0;\n\tif (v108) goto L_0089;\n\tv86 = System.Text.RegularExpressions.Match::get_Groups(v60);\n\tv87 = System.Text.RegularExpressions.GroupCollection::get_Item(v86, \"Number\");\n\tv100 = v87._length;\n\tv88 = System.Text.RegularExpressions.Match::get_Groups(v60);\n\tv89 = System.Text.RegularExpressions.GroupCollection::get_Item(v88, \"Number\");\n\tv160 = System.Text.RegularExpressions.Capture::get_Value(v89);\n\tv161 = &v11 @ stack_-10_v2 - 0x14;\n\tv162 = System.Int32::TryParse(v160, v161);\n\tv164 = v162 == 0;\n\tv165 = ~v164;\n\tif (v165) goto L_005B;\n\t*([v10 @ X29_v1-14]) = 1;\nL_005B:\n\tv91 = System.Text.RegularExpressions.Match::get_Groups(v60);\n\tv90 = System.Text.RegularExpressions.GroupCollection::get_Item(v91, \"Name\");\n\tv171 = System.Text.RegularExpressions.Capture::get_Value(v90);\n\tv173 = *([v10 @ X29_v1-14]);\n\tv173 = v173 + 1;\n\t// 112 Box v177 @ X0_v26 (System.Object), typeof(System.Int32), &v100 @ X20_v5 (System.Int32)\n\tv184 = System.String::Concat(\"D\", v177);\n\tv188 = 0xDC3590(&v173 @ X8_v19, v184, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturnVal2 = System.String::Concat(v171, \" \", v188);\n\tgoto L_0090;\nL_0089:\n\treturnVal2 = System.String::Concat(s, \" 2\");\nL_0090:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 103 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static string IncrementStringCounter(string s)
		{
			//IL_0146: Expected O, but got I
			//IL_0155: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			Match match = Regex.Match(s, "(?<Name>.*)\\s(?<Number>[0-9]+)$");
			if (match.Success)
			{
				GroupCollection groups = match.Groups;
				Group obj3 = groups.get_Item("Number");
				int length = obj3.Length;
				GroupCollection groups2 = match.Groups;
				Group obj4 = groups2.get_Item("Number");
				string value = obj4.Value;
				if (!int.TryParse(value, out *(int*)((long)(IntPtr)obj2 - 20L)))
				{
					_ = 1;
				}
				GroupCollection groups3 = match.Groups;
				Group obj5 = groups3.get_Item("Name");
				string value2 = obj5.Value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1-14]");
				object obj6 = 0;
				obj6 = (long)(IntPtr)obj6 + 1L;
				object obj7 = length;
				string text = "D" + obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3590 (inside System.InvalidCastException::.ctor +0x2B8)");
				string text2 = default(string);
				return value2 + " " + text2;
			}
			return s + " 2";
		}
	}
}
