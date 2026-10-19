using System;
using System.Collections.Generic;
using System.Globalization;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.Utils
{
	[Token(Token = "0x2000005")]
	public static class NumberConverter
	{
		[Token(Token = "0x4000007")]
		private const float K = 1000f;

		[Token(Token = "0x4000008")]
		private const float M = 1000000f;

		[Token(Token = "0x4000009")]
		private const float B = 1E+09f;

		[Token(Token = "0x400000A")]
		private const float T = 1E+12f;

		[Token(Token = "0x400000B")]
		private const float Q = 1E+15f;

		[Token(Token = "0x400000C")]
		private const float AA = 1E+18f;

		[Token(Token = "0x400000D")]
		private const float AB = 1E+21f;

		[Token(Token = "0x400000E")]
		private const float AC = 1E+24f;

		[Token(Token = "0x400000F")]
		private const float AD = 1E+27f;

		[Token(Token = "0x4000010")]
		private const float AE = 1E+30f;

		[Token(Token = "0x4000011")]
		private const float AF = 1E+33f;

		[Token(Token = "0x4000012")]
		private static readonly List<(float, string)> Pairs;

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x81E3874", Offset = "0x81E3874", Length = "0x2C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = number;\n\tgoto L_0035;\n\tgoto L_004A;\nL_004A:\n\tv87 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv101 = System.Double::ToString(&v26 @ stack_-58_v1 (System.Double), \"#,0\", v87);\n\treturnVal2 = System.String::Replace(v101, \",\", \" \");\n\tgoto L_00EF;\nL_005F:\n\tv80 = System.String::CreateString(0, 0x23, decimalCount);\n\tv93 = System.String::Concat(\"0.\", v80);\n\tv105 = number < 0x408F400000000000;\n\tv113 = ~v105;\n\tif (v113) goto L_FFFFFFFF;\n\treturnVal2 = System.Double::ToString(&v26 @ stack_-58_v1 (System.Double), \"F0\");\n\tgoto L_00EF;\nL_FFFFFFFF:\n\tv224 = -1;\n\tgoto L_0089;\n\tv162 = v224 + 1;\n\tv171 = v162 >= v360.Count;\n\tif (v171) goto L_00BE;\n\tgoto L_00A6;\nL_00A6:\n\tv245 = System.Collections.Generic.List`1<System.ValueTuple`2<System.Single, System.Object>>::get_Item(v360, v162);\n\tv197 = v245 < number;\n\tv193 = v245 == number;\n\tv369 = v245 == v245;\n\tv181 = number == number;\n\tv185 = v369 & v181;\n\tv177 = ~v185;\n\tv370 = v197 == v177;\n\tv148 = ~v193;\n\tv173 = v370 & v148;\n\tif (v173) goto L_00CE;\n\tv224 = v224 + 1;\n\tgoto L_0089;\nL_00BE:\n\tgoto L_00C7;\nL_00C7:\n\tv373 = v360.Count - 1;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv377 = v360;\n\tgoto L_00D7;\nL_00CE:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv373 = v224;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv377 = v222.Pairs;\nL_00EF:\n\treturn returnVal2;\nL_0035:\n\tv56 = number < 0x40F86A1000000000;\n\tv64 = ~v56;\n\tif (v64) goto L_005F;\nL_0089:\n\tv360 = v167.Pairs;\nL_00D7:\n\tv378 = System.Collections.Generic.List`1<System.ValueTuple`2<System.Single, System.Object>>::get_Item(v377, v373);\n\tv288 = number / v378;\n\tv262 = v288;\n\tv389 = System.Double::ToString(&v262 @ stack_-60_v2 (System.Double), v93);\n\treturnVal2 = System.String::Concat(v389, v373);\n")]
		public static string Format(double number, int decimalCount = 2)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NumberConverter::Format");
			return default;
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0x81E3B34", Offset = "0x81E3B34", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = number;\n\tgoto L_001B;\n\treturnVal1 = System.Double::ToString(&v16 @ stack_-38_v1 (System.Double), \"0.##\");\n\treturn returnVal1;\nL_0039:\n\tgoto L_0044;\nL_0044:\n\treturnVal2 = Unco.Utils.NumberConverter::Format(number, 2);\n\treturn returnVal2;\nL_001B:\n\tv47 = number < 0x408F400000000000;\n\tv55 = ~v47;\n\tif (v55) goto L_0039;\n")]
		public static string FloatFormat(double number)
		{
			double num = number;
			if (number < 4.652007308841189E+18)
			{
				return num.ToString("0.##");
			}
			return Format(number);
		}

		[Token(Token = "0x6000007")]
		[Address(RVA = "0x81E3BF0", Offset = "0x81E3BF0", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = byteAmount;\n\tgoto L_002D;\n\tv55 = byteAmount >> 0x14;\n\tv56 = v55 == 0;\n\tif (v56) goto L_004D;\n\tv63 = byteAmount >> 0x1E;\n\tv64 = v63 == 0;\n\tif (v64) goto L_0058;\n\tv79 = byteAmount >> 0x28;\n\tv80 = v79 == 0;\n\tif (v80) goto L_0064;\n\tv106 = byteAmount * 0x3D70000000000000;\n\tv66 = v106;\n\tv107 = System.Double::ToString(&v66 @ stack_-30_v2 (System.Double), \"0\");\n\tv111 = 0xB2E5000 + 0xFC0;\n\tgoto L_0070;\nL_0048:\n\tv107 = System.Int64::ToString(&v12 @ stack_-28_v1 (System.Int64));\n\tv111 = 0xB2E5000 + 0xE00;\n\tgoto L_0070;\nL_004D:\n\tv66 = byteAmount;\n\tv107 = System.Double::ToString(&v66 @ stack_-30_v2 (System.Double), \"0\");\n\tv111 = 0xB2E5000 + 0xED0;\n\tgoto L_0070;\nL_0058:\n\tv66 = byteAmount;\n\tv107 = System.Double::ToString(&v66 @ stack_-30_v2 (System.Double), \"0\");\n\tv111 = 0xB2E5000 + 0xEE0;\n\tgoto L_0070;\nL_0064:\n\tv105 = byteAmount * 0x3E10000000000000;\n\tv66 = v105;\n\tv107 = System.Double::ToString(&v66 @ stack_-30_v2 (System.Double), \"0\");\n\tv111 = 0xB2E5000 + 0xE68;\nL_002D:\n\tv51 = byteAmount <= 0x3FF;\n\tif (v51) goto L_0048;\nL_0070:\n\treturnVal1 = System.String::Concat(v107, *([v111 @ X8_v3 (System.Int32)]));\n\treturn returnVal1;\n")]
		public static string FormatByte(long byteAmount)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NumberConverter::FormatByte");
			return default;
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x81E3D78", Offset = "0x81E3D78", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\treturn returnVal1;\nL_001A:\n\tv50 = seconds * 0xFFFFFFFF88888889;\n\tv51 = v50 >> 0x20;\n\tv52 = v51 + seconds;\n\tv53 = v52 >> 5;\n\tv54 = v52 >> 0x1F;\n\tv55 = v53 + v54;\n\tv56 = v55;\n\tv58 = 0xB7D5000 + 0x538;\n\tv61 = \"il2cpp_vm_object_box\"(*([v58 @ X23_v2 (System.Int32)+48]), &v56 @ stack_-44_v1 (System.Int32), v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv64 = v55 * 0x3C;\n\tv65 = seconds - v64;\n\tv66 = v65;\n\tv69 = \"il2cpp_vm_object_box\"(*([v58 @ X23_v2 (System.Int32)+48]), &v66 @ stack_-48_v1 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = System.String::Format(\"{0:D2}:{1:D2}\", v61, v69);\n")]
		public static string FormatTime(int seconds)
		{
			int num = seconds * -2004318071;
			int num2 = num >> 32;
			int num3 = num2 + seconds;
			int num4 = num3 >> 5;
			int num5 = num3 >> 31;
			int num6 = num4 + num5;
			int num7 = num6;
			int num8 = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			int num9 = num6 * 60;
			int num10 = seconds - num9;
			int num11 = num10;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			object arg2 = default(object);
			return $"{arg:D2}:{arg2:D2}";
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x81E3E38", Offset = "0x81E3E38", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tgoto L_0018;\nL_0018:\n\tv71 = Unco.Utils.NumberConverter::Format(value, 2);\n\tv62 = v71 == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_003C;\n\tgoto L_00C3;\nL_003C:\n\tv78 = System.String::IndexOf(v71, 0x2E);\n\tv112 = v78 == -1;\n\tif (v112) goto L_00C1;\n\tv154 = System.String::Substring(v71, 0, v78);\n\tv213 = System.String::Substring(v71, v78);\n\t// 88 NewArr v133 @ X0_v11 (System.String[]), typeof(System.String[]), 5\n\tv133[0] = \"<size=100%>\";\n\tv133[1] = v154;\n\tv133[2] = \"</size><size=60%>\";\n\tv133[3] = v213;\n\tv133[4] = \"</size>\";\n\treturnVal3 = System.String::Concat(v133);\n\treturn returnVal3;\nL_00C1:\n\treturn v71;\nL_00C3:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n")]
		public static string CustomFontSize(float value)
		{
			string text = Format(value);
			if (text != null)
			{
				int num = text.IndexOf('.');
				if (num != -1)
				{
					string text2 = text.Substring(0, num);
					string text3 = text.Substring(num);
					return "<size=100%>" + text2 + "</size><size=60%>" + text3 + "</size>";
				}
				return text;
			}
			return (string)(object)new NullReferenceException();
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x81E4038", Offset = "0x81E4038", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tgoto L_0018;\nL_0018:\n\tv71 = Unco.Utils.NumberConverter::Format(value, 2);\n\tv62 = v71 == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_003C;\n\tgoto L_00C3;\nL_003C:\n\tv78 = System.String::IndexOf(v71, 0x2E);\n\tv112 = v78 == -1;\n\tif (v112) goto L_00C1;\n\tv154 = System.String::Substring(v71, 0, v78);\n\tv213 = System.String::Substring(v71, v78);\n\t// 88 NewArr v133 @ X0_v11 (System.String[]), typeof(System.String[]), 5\n\tv133[0] = \"<size=100%>\";\n\tv133[1] = v154;\n\tv133[2] = \"</size><size=60%>\";\n\tv133[3] = v213;\n\tv133[4] = \"</size>\";\n\treturnVal3 = System.String::Concat(v133);\n\treturn returnVal3;\nL_00C1:\n\treturn v71;\nL_00C3:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n")]
		public static string CustomFontSize(double value)
		{
			string text = Format(value);
			if (text != null)
			{
				int num = text.IndexOf('.');
				if (num != -1)
				{
					string text2 = text.Substring(0, num);
					string text3 = text.Substring(num);
					return "<size=100%>" + text2 + "</size><size=60%>" + text3 + "</size>";
				}
				return text;
			}
			return (string)(object)new NullReferenceException();
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x81E4238", Offset = "0x81E4238", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = number;\n\tgoto L_001D;\n\tgoto L_0032;\nL_0032:\n\tv77 = System.Globalization.CultureInfo::get_InvariantCulture();\n\treturnVal2 = System.Double::ToString(&v16 @ stack_-38_v1 (System.Double), \"N0\", v77);\n\treturn returnVal2;\nL_0046:\n\tgoto L_0051;\nL_0051:\n\treturnVal1 = Unco.Utils.NumberConverter::Format(number, 2);\n\treturn returnVal1;\nL_001D:\n\tv46 = number < 999999995904d;\n\tv54 = ~v46;\n\tif (v54) goto L_0046;\n")]
		public static string TokenFormat(double number)
		{
			double num = number;
			if (number < 999999995904.0)
			{
				CultureInfo invariantCulture = CultureInfo.InvariantCulture;
				return num.ToString("N0", invariantCulture);
			}
			return Format(number);
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x81E4320", Offset = "0x81E4320", Length = "0x788")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004B;\n\tgoto L_0080;\nL_0080:\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.Single, System.Object>>::Add(v55, v71);\n\tv143 = 0;\n\tSystem.ValueTuple`2<System.Single, System.Object>::.ctor(&v146 @ stack_-60_v3 (System.ValueTuple`2<System.Single, System.Object>), 1000000f, \"M\");\n\tgoto L_00AF;\nL_00AF:\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.Single, System.Object>>::Add(v55, v146);\n\tv137 = 0;\n\tSystem.ValueTuple`2<System.Single, System.Object>::.ctor(&v140 @ stack_-70_v3 (System.ValueTuple`2<System.Single, System.Object>), 1E+09f, \"B\");\n\tgoto L_00DE;\nL_00DE:\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.Single, System.Object>>::Add(v55, v140);\n\tSystem.ValueTuple`2<System.Single, System.Object>::.ctor(&v134 @ stack_-80_v3 (System.ValueTuple`2<System.Single, System.Object>), 1E+12f, \"T\");\n\tgoto L_010D;\nL_010D:\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.Single, System.Object>>::Add(v55, v134);\n\tSystem.ValueTuple`2<System.Single, System.Object>::.ctor(&v128 @ stack_-90_v3 (System.ValueTuple`2<System.Single, System.Object>), 1E+15f, \"Q\");\n\tgoto L_013C;\nL_013C:\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.Single, System.Object>>::Add(v55, v128);\n\tSystem.ValueTuple`2<System.Single, System.Object>::.ctor(&v122 @ stack_-A0_v3 (System.ValueTuple`2<System.Single, System.Object>), 1E+18f, \"AA\");\n\tgoto L_016B;\nL_016B:\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.Single, System.Object>>::Add(v55, v122);\n\tSystem.ValueTuple`2<System.Single, System.Object>::.ctor(&v116 @ stack_-B0_v3 (System.ValueTuple`2<System.Single, System.Object>), 1E+21f, \"AB\");\n\tgoto L_019A;\nL_019A:\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.Single, System.Object>>::Add(v55, v116);\n\tSystem.ValueTuple`2<System.Single, System.Object>::.ctor(&v110 @ stack_-C0_v3 (System.ValueTuple`2<System.Single, System.Object>), 1E+24f, \"AC\");\n\tgoto L_01C9;\nL_01C9:\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.Single, System.Object>>::Add(v55, v110);\n\tSystem.ValueTuple`2<System.Single, System.Object>::.ctor(&v104 @ stack_-D0_v3 (System.ValueTuple`2<System.Single, System.Object>), 1E+27f, \"AD\");\n\tgoto L_01F8;\nL_01F8:\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.Single, System.Object>>::Add(v55, v104);\n\tSystem.ValueTuple`2<System.Single, System.Object>::.ctor(&v98 @ stack_-E0_v3 (System.ValueTuple`2<System.Single, System.Object>), 1E+30f, \"AE\");\n\tgoto L_0227;\nL_0227:\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.Single, System.Object>>::Add(v55, v98);\n\tSystem.ValueTuple`2<System.Single, System.Object>::.ctor(&v92 @ stack_-F0_v3 (System.ValueTuple`2<System.Single, System.Object>), 1E+33f, \"AF\");\n\tgoto L_0256;\nL_0256:\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.Single, System.Object>>::Add(v55, v92);\n\tv743.Pairs = v55;\n\treturn;\nL_004B:\n\tv55 = new System.Collections.Generic.List`1<System.ValueTuple`2<System.Single, System.String>>();\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.Single, System.String>>::.ctor(v55);\n\tv65 = 0;\n\tSystem.ValueTuple`2<System.Single, System.Object>::.ctor(&v71 @ stack_-50_v2 (System.ValueTuple`2<System.Single, System.Object>), 1000f, \"K\");\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static NumberConverter()
		{
			List<(float, string)> list = new List<(float, string)>();
			int num = 0;
			(float, object) item = (1000f, "K");
			list.Add(((float, string))item);
			int num2 = 0;
			(float, object) item2 = (1000000f, "M");
			list.Add(((float, string))item2);
			int num3 = 0;
			(float, object) item3 = (1E+09f, "B");
			list.Add(((float, string))item3);
			(float, object) item4 = (1E+12f, "T");
			list.Add(((float, string))item4);
			(float, object) item5 = (1E+15f, "Q");
			list.Add(((float, string))item5);
			(float, object) item6 = (1E+18f, "AA");
			list.Add(((float, string))item6);
			(float, object) item7 = (1E+21f, "AB");
			list.Add(((float, string))item7);
			(float, object) item8 = (1E+24f, "AC");
			list.Add(((float, string))item8);
			(float, object) item9 = (1E+27f, "AD");
			list.Add(((float, string))item9);
			(float, object) item10 = (1E+30f, "AE");
			list.Add(((float, string))item10);
			(float, object) item11 = (1E+33f, "AF");
			list.Add(((float, string))item11);
			Pairs = list;
		}
	}
}
