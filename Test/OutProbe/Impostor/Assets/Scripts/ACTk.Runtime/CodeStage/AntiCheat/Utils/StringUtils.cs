using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace CodeStage.AntiCheat.Utils
{
	[Token(Token = "0x2000006")]
	internal static class StringUtils
	{
		[Token(Token = "0x4000006")]
		private static readonly char[] HexArray = new char[16]
		{
			'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
			'A', 'B', 'C', 'D', 'E', 'F'
		};

		[Token(Token = "0x6000013")]
		[Address(RVA = "0xBD411C", Offset = "0xBD411C", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = System.Text.Encoding::get_UTF8();\n\tv9 = *([v7 @ X0_v2 (System.Text.Encoding)]);\n\tv11 = *([v9 @ X8_v1 (Il2CppClass<System.Text.Encoding>)+218]);\n\tv12 = *([v9 @ X8_v1 (Il2CppClass<System.Text.Encoding>)+220]);\n\t// 15 IndirectJump v11 @ X3_v1, v7 @ X0_v2 (System.Text.Encoding), v7 @ X0_v2 (System.Text.Encoding), input @ X0 (System.Char[]), v12 @ X2_v1, v11 @ X3_v1, v15 @ X4, v16 @ X5, v17 @ X6, v18 @ X7, v19 @ V0, v20 @ V1, v21 @ V2, v22 @ V3, v23 @ V4, v24 @ V5, v25 @ V6, v26 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static byte[] CharsToBytes(char[] input)
		{
			//IL_0016: Expected I, but got O
			//IL_0026: Expected O, but got I
			//IL_0036: Expected O, but got I
			Encoding uTF = Encoding.UTF8;
			nint num = (nint)uTF;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ X8_v1 (Il2CppClass<System.Text.Encoding>)+218]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ X8_v1 (Il2CppClass<System.Text.Encoding>)+220]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v11 @ X3_v1 (should have been resolved before IL gen)");
			return null;
		}

		[Token(Token = "0x6000014")]
		[Address(RVA = "0xBD4060", Offset = "0xBD4060", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = System.Text.Encoding::get_UTF8();\n\tv9 = *([v7 @ X0_v2 (System.Text.Encoding)]);\n\tv11 = *([v9 @ X8_v1 (Il2CppClass<System.Text.Encoding>)+248]);\n\tv12 = *([v9 @ X8_v1 (Il2CppClass<System.Text.Encoding>)+250]);\n\t// 15 IndirectJump v11 @ X3_v1, v7 @ X0_v2 (System.Text.Encoding), v7 @ X0_v2 (System.Text.Encoding), input @ X0 (System.String), v12 @ X2_v1, v11 @ X3_v1, v15 @ X4, v16 @ X5, v17 @ X6, v18 @ X7, v19 @ V0, v20 @ V1, v21 @ V2, v22 @ V3, v23 @ V4, v24 @ V5, v25 @ V6, v26 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static byte[] StringToBytes(string input)
		{
			//IL_0016: Expected I, but got O
			//IL_0026: Expected O, but got I
			//IL_0036: Expected O, but got I
			Encoding uTF = Encoding.UTF8;
			nint num = (nint)uTF;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ X8_v1 (Il2CppClass<System.Text.Encoding>)+248]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ X8_v1 (Il2CppClass<System.Text.Encoding>)+250]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v11 @ X3_v1 (should have been resolved before IL gen)");
			return null;
		}

		[Token(Token = "0x6000015")]
		[Address(RVA = "0xBD3FA4", Offset = "0xBD3FA4", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = System.Text.Encoding::get_UTF8();\n\tv9 = *([v7 @ X0_v2 (System.Text.Encoding)]);\n\tv11 = *([v9 @ X8_v1 (Il2CppClass<System.Text.Encoding>)+2B8]);\n\tv12 = *([v9 @ X8_v1 (Il2CppClass<System.Text.Encoding>)+2C0]);\n\t// 15 IndirectJump v11 @ X3_v1, v7 @ X0_v2 (System.Text.Encoding), v7 @ X0_v2 (System.Text.Encoding), input @ X0 (System.Byte[]), v12 @ X2_v1, v11 @ X3_v1, v15 @ X4, v16 @ X5, v17 @ X6, v18 @ X7, v19 @ V0, v20 @ V1, v21 @ V2, v22 @ V3, v23 @ V4, v24 @ V5, v25 @ V6, v26 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static char[] BytesToChars(byte[] input)
		{
			//IL_0016: Expected I, but got O
			//IL_0026: Expected O, but got I
			//IL_0036: Expected O, but got I
			Encoding uTF = Encoding.UTF8;
			nint num = (nint)uTF;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ X8_v1 (Il2CppClass<System.Text.Encoding>)+2B8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ X8_v1 (Il2CppClass<System.Text.Encoding>)+2C0]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v11 @ X3_v1 (should have been resolved before IL gen)");
			return null;
		}

		[Token(Token = "0x6000016")]
		[Address(RVA = "0xBD3EE8", Offset = "0xBD3EE8", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = System.Text.Encoding::get_UTF8();\n\tv9 = *([v7 @ X0_v2 (System.Text.Encoding)]);\n\tv11 = *([v9 @ X8_v1 (Il2CppClass<System.Text.Encoding>)+368]);\n\tv12 = *([v9 @ X8_v1 (Il2CppClass<System.Text.Encoding>)+370]);\n\t// 15 IndirectJump v11 @ X3_v1, v7 @ X0_v2 (System.Text.Encoding), v7 @ X0_v2 (System.Text.Encoding), input @ X0 (System.Byte[]), v12 @ X2_v1, v11 @ X3_v1, v15 @ X4, v16 @ X5, v17 @ X6, v18 @ X7, v19 @ V0, v20 @ V1, v21 @ V2, v22 @ V3, v23 @ V4, v24 @ V5, v25 @ V6, v26 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string BytesToString(byte[] input)
		{
			//IL_0016: Expected I, but got O
			//IL_0026: Expected O, but got I
			//IL_0036: Expected O, but got I
			Encoding uTF = Encoding.UTF8;
			nint num = (nint)uTF;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ X8_v1 (Il2CppClass<System.Text.Encoding>)+368]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ X8_v1 (Il2CppClass<System.Text.Encoding>)+370]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v11 @ X3_v1 (should have been resolved before IL gen)");
			return null;
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0xBD4890", Offset = "0xBD4890", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = System.Text.Encoding::get_UTF8();\n\tv17 = *([v15 @ X0_v2 (System.Text.Encoding)]);\n\tv22 = *([v17 @ X8_v1 (Il2CppClass<System.Text.Encoding>)+378]);\n\tv23 = *([v17 @ X8_v1 (Il2CppClass<System.Text.Encoding>)+380]);\n\t// 23 IndirectJump v22 @ X5_v1, v15 @ X0_v2 (System.Text.Encoding), v15 @ X0_v2 (System.Text.Encoding), input @ X0 (System.Byte[]), index @ X1 (System.Int32), count @ X2 (System.Int32), v23 @ X4_v1, v22 @ X5_v1, v27 @ X6, v28 @ X7, v29 @ V0, v30 @ V1, v31 @ V2, v32 @ V3, v33 @ V4, v34 @ V5, v35 @ V6, v36 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string BytesToString(byte[] input, int index, int count)
		{
			//IL_0016: Expected I, but got O
			//IL_0026: Expected O, but got I
			//IL_0036: Expected O, but got I
			Encoding uTF = Encoding.UTF8;
			nint num = (nint)uTF;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ X8_v1 (Il2CppClass<System.Text.Encoding>)+378]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ X8_v1 (Il2CppClass<System.Text.Encoding>)+380]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v22 @ X5_v1 (should have been resolved before IL gen)");
			return null;
		}

		[Token(Token = "0x6000018")]
		[Address(RVA = "0xBD48D8", Offset = "0xBD48D8", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv26 = System.Char[];\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv49 = CodeStage.AntiCheat.Utils.StringUtils;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A353DE]) = v46;\nL_001F:\n\tv54 = input.Length << 1;\n\t// 32 NewArr v55 @ X0_v5 (System.Char[]), typeof(System.Char[]), v54 @ X1_v2 (System.Int32)\n\tv164 = input.Length < 1;\n\tif (v164) goto L_00A3;\nL_0044:\n\tgoto L_0048;\n\tv296 = \"il2cpp_codegen_runtime_class_init\"(v265, v54, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv297 = CodeStage.AntiCheat.Utils.StringUtils;\nL_0048:\n\tv149 = v298.HexArray;\n\tv75 = input[v88 @ X21_v5 (System.Int32)] ^ 0x90;\n\tv70 = v75 >> 4;\n\tv270 = v84 - 1;\n\tv177 = v75 & 0xF;\n\tv55[v270 @ X13_v5 (System.Int32)] = v149[v70 @ X12_v5 (System.Int32)];\n\tv88 = v88 + 1;\n\tv181 = v84 + 2;\n\tv55[v84 @ X24_v5 (System.Int32)] = v149[v177 @ X10_v6 (System.Int32)];\n\tv187 = v88 < input.Length;\n\tif (v187) goto L_0044;\nL_00A3:\n\treturnVal2 = System.String::CreateString(0, v55);\n\treturn returnVal2;\n\tv141 = new System.IndexOutOfRangeException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 138 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string HashBytesToHexString(byte[] input)
		{
			int num = input.Length << 1;
			char[] array = new char[num];
			if (input.Length >= 1)
			{
				int num2 = 1;
				int num3 = 0;
				bool flag;
				do
				{
					char[] hexArray = HexArray;
					int num4 = input[num3] ^ 0x90;
					int num5 = num4 >> 4;
					int num6 = num2 - 1;
					int num7 = num4 & 0xF;
					array[num6] = hexArray[num5];
					num3++;
					int num8 = num2 + 2;
					array[num2] = hexArray[num7];
					flag = num3 < input.Length;
					num2 = num8;
				}
				while (flag);
			}
			return ((string)null).CreateString(array);
		}
	}
}
