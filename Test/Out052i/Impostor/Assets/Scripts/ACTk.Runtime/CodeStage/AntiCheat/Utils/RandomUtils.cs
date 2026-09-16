using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace CodeStage.AntiCheat.Utils
{
	[Token(Token = "0x2000005")]
	internal class RandomUtils
	{
		[Token(Token = "0x6000007")]
		[Address(RVA = "0xBD414C", Offset = "0xBD414C", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = System.Char[];\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A353D6]) = v37;\nL_0015:\n\t// 21 NewArr v40 @ X0_v3 (System.Char[]), typeof(System.Char[]), length @ X0 (System.Int32)\n\tv42 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateCharArrayKey(v40);\n\treturnVal1 = System.String::CreateString(0, v40);\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GenerateRandomString(int length)
		{
			char[] array = new char[length];
			char[] array2 = GenerateCharArrayKey(array);
			return ((string)null).CreateString(array);
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0xBD4280", Offset = "0xBD4280", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = CodeStage.AntiCheat.Utils.ThreadSafeRandom;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A353D7]) = v34;\nL_0015:\n\tgoto L_0019;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0019:\n\treturnVal1 = CodeStage.AntiCheat.Utils.ThreadSafeRandom::Next(0x64, 0xFF);\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static byte GenerateByteKey()
		{
			return (byte)ThreadSafeRandom.Next(100, 255);
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0xBD44CC", Offset = "0xBD44CC", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = CodeStage.AntiCheat.Utils.ThreadSafeRandom;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A353D8]) = v34;\nL_0015:\n\tgoto L_0019;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0019:\n\treturnVal1 = CodeStage.AntiCheat.Utils.ThreadSafeRandom::Next(0x64, 0x7F);\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static sbyte GenerateSByteKey()
		{
			return (sbyte)ThreadSafeRandom.Next(100, 127);
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0xBD4524", Offset = "0xBD4524", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = CodeStage.AntiCheat.Utils.ThreadSafeRandom;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A353D9]) = v34;\nL_0015:\n\tgoto L_0019;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0019:\n\treturnVal1 = CodeStage.AntiCheat.Utils.ThreadSafeRandom::Next(0x2710, 0xEA60);\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static char GenerateCharKey()
		{
			return (char)ThreadSafeRandom.Next(10000, 60000);
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0xBD457C", Offset = "0xBD457C", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = CodeStage.AntiCheat.Utils.ThreadSafeRandom;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A353DA]) = v34;\nL_0015:\n\tgoto L_0019;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0019:\n\treturnVal1 = CodeStage.AntiCheat.Utils.ThreadSafeRandom::Next(0x2710, 0x7FFF);\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static short GenerateShortKey()
		{
			return (short)ThreadSafeRandom.Next(10000, 32767);
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0xBD45D4", Offset = "0xBD45D4", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = CodeStage.AntiCheat.Utils.ThreadSafeRandom;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A353DB]) = v34;\nL_0015:\n\tgoto L_0019;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0019:\n\treturnVal1 = CodeStage.AntiCheat.Utils.ThreadSafeRandom::Next(0x2710, 0xFFFF);\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static ushort GenerateUShortKey()
		{
			return (ushort)ThreadSafeRandom.Next(10000, 65535);
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0xBD462C", Offset = "0xBD462C", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = CodeStage.AntiCheat.Utils.ThreadSafeRandom;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A353DC]) = v34;\nL_0015:\n\tgoto L_001E;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\treturnVal1 = CodeStage.AntiCheat.Utils.ThreadSafeRandom::Next(0x3B9ACA00, 0x7FFFFFFF);\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int GenerateIntKey()
		{
			return ThreadSafeRandom.Next(1000000000, int.MaxValue);
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0xBD4684", Offset = "0xBD4684", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\treturn returnVal1;\n")]
		internal static uint GenerateUIntKey()
		{
			return (uint)GenerateIntKey();
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0xBD4688", Offset = "0xBD4688", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\treturn v2;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static long GenerateLongKey()
		{
			//IL_000e: Expected I8, but got I4
			int num = GenerateIntKey();
			return num;
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0xBD469C", Offset = "0xBD469C", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateIntKey();\n\treturn v2;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static ulong GenerateULongKey()
		{
			//IL_000e: Expected I8, but got I4
			int num = GenerateIntKey();
			return (ulong)num;
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0xBD41AC", Offset = "0xBD41AC", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv14 = System.Char[];\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv39 = UnityEngine.Debug;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v39, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv88 = CodeStage.AntiCheat.Utils.ThreadSafeRandom;\n\tv89 = \"il2cpp_codegen_initialize_runtime_metadata\"(v88, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv116 = \"[ACTk] Passed arrayToFill length is less than minimum required 7 chars. Allocating new array instead.\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v116, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A353DD]) = v34;\nL_001B:\n\tv37 = arrayToFill == 0;\n\tif (v37) goto L_003C;\n\tv53 = arrayToFill.Length > 6;\n\tif (v53) goto L_0042;\n\tgoto L_0037;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v92, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0037:\n\tUnityEngine.Debug::LogWarning(\"[ACTk] Passed arrayToFill length is less than minimum required 7 chars. Allocating new array instead.\");\nL_003C:\n\t// 60 NewArr v86 @ X0_v10 (System.Char[]), typeof(System.Char[]), 7\nL_0042:\n\tgoto L_0045;\n\tv120 = \"il2cpp_codegen_runtime_class_init\"(v111, v95, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0045:\n\tCodeStage.AntiCheat.Utils.ThreadSafeRandom::NextChars(v108);\n\treturn v108;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static char[] GenerateCharArrayKey(char[] arrayToFill = null)
		{
			char[] array;
			if (arrayToFill != null)
			{
				bool flag = arrayToFill.Length > 6;
				array = arrayToFill;
				if (flag)
				{
					goto IL_005b;
				}
				Debug.LogWarning("[ACTk] Passed arrayToFill length is less than minimum required 7 chars. Allocating new array instead.");
			}
			char[] array2 = new char[7];
			array = array2;
			goto IL_005b;
			IL_005b:
			ThreadSafeRandom.NextChars(array);
			return array;
		}

		[Token(Token = "0x6000012")]
		[Address(RVA = "0xBD4888", Offset = "0xBD4888", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RandomUtils()
		{
		}
	}
}
