using System;
using AssetRipperInjected;
using Cpp2ILInjected;

[Token(Token = "0x200000E")]
public static class RandNumber
{
	[Token(Token = "0x400002C")]
	private static Random _rand;

	[Token(Token = "0x400002D")]
	private static bool isLog;

	[Token(Token = "0x17000005")]
	private static Random rand
	{
		[Token(Token = "0x6000055")]
		[Address(RVA = "0xBF8C90", Offset = "0xBF8C90", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv14 = RandNumber;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A355C8]) = v34;\nL_0013:\n\treturnVal1 = v36._rand;\n\tv38 = v36._rand == 0;\n\tv39 = ~v38;\n\tif (v39) goto L_001F;\n\tRandNumber::ResetRandom();\n\treturnVal1 = v43._rand;\nL_001F:\n\treturn returnVal1;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			Random result = _rand;
			if (_rand == null)
			{
				ResetRandom();
				result = _rand;
			}
			return result;
		}
	}

	[Token(Token = "0x6000056")]
	[Address(RVA = "0xBF8CEC", Offset = "0xBF8CEC", Length = "0xC0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv16 = System.DateTime;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv47 = RandNumber;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv54 = System.Random;\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv37 = 1;\n\t*([1A355C9]) = v37;\nL_0020:\n\tgoto L_0023;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v38, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0023:\n\tv52 = System.DateTime::get_Now();\n\tv58 = System.DateTime::get_Ticks(&v52 @ X0_v5 (System.DateTime));\n\tv62 = new System.Random();\n\tSystem.Random::.ctor(v62, v58);\n\tv69._rand = v62;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void ResetRandom()
	{
		//IL_0029: Expected I4, but got I8
		long ticks = DateTime.Now.Ticks;
		Random random = new Random((int)ticks);
		_rand = random;
	}

	[Token(Token = "0x6000057")]
	[Address(RVA = "0xBF8DAC", Offset = "0xBF8DAC", Length = "0x38")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = RandNumber::get_rand();\n\tv12 = *([v10 @ X0_v1 (System.Random)]);\n\tv17 = *([v12 @ X8_v1 (Il2CppClass<System.Random>)+198]);\n\tv18 = *([v12 @ X8_v1 (Il2CppClass<System.Random>)+1A0]);\n\t// 18 IndirectJump v17 @ X4_v1, v10 @ X0_v1 (System.Random), v10 @ X0_v1 (System.Random), inclusiveMin @ X0 (System.Int32), exclusiveMax @ X1 (System.Int32), v18 @ X3_v1, v17 @ X4_v1, v20 @ X5, v21 @ X6, v22 @ X7, v23 @ V0, v24 @ V1, v25 @ V2, v26 @ V3, v27 @ V4, v28 @ V5, v29 @ V6, v30 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static int Random(int inclusiveMin, int exclusiveMax)
	{
		//IL_0016: Expected I, but got O
		//IL_0026: Expected O, but got I
		//IL_0036: Expected O, but got I
		Random random = rand;
		nint num = (nint)random;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X8_v1 (Il2CppClass<System.Random>)+198]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X8_v1 (Il2CppClass<System.Random>)+1A0]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v17 @ X4_v1 (should have been resolved before IL gen)");
		return 0;
	}

	[Token(Token = "0x6000058")]
	[Address(RVA = "0xBF8DE4", Offset = "0xBF8DE4", Length = "0x6C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = RandNumber;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, v20, v21, v22, v23, v24, v25, v26, inclusiveMin, inclusiveMax, v27, v28, v29, v30, v31, v32);\n\tv36 = 1;\n\t*([1A355CA]) = v36;\nL_0012:\n\tv37 = RandNumber::get_rand();\n\tv42 = System.Random::NextDouble(v37);\n\tv43 = inclusiveMax - inclusiveMin;\n\tv47 = inclusiveMin * v43;\n\tv49 = v47 + inclusiveMin;\n\treturn v49;\n\tthrow System.NullReferenceException;\n\treturn inclusiveMin;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static float Random(float inclusiveMin, float inclusiveMax)
	{
		Random random = rand;
		double num = random.NextDouble();
		float num2 = inclusiveMax - inclusiveMin;
		float num3 = inclusiveMin * num2;
		return num3 + inclusiveMin;
	}

	[Token(Token = "0x6000059")]
	[Address(RVA = "0xBF8E50", Offset = "0xBF8E50", Length = "0xC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = RandNumber::Random(0f, 1f);\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static float Random01()
	{
		return Random(0f, 1f);
	}
}
