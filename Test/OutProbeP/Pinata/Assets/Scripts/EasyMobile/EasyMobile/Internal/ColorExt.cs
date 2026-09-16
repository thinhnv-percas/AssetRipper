using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal
{
	[Token(Token = "0x20000C3")]
	public static class ColorExt
	{
		[Token(Token = "0x6000717")]
		[Address(RVA = "0xBFB23C", Offset = "0xBFB23C", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EEB2D0]);\n\tv23 = *([v22 @ X8_v28]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022F25]) = v42;\nL_0019:\n\t// 25 NewArr v47 @ X0_v3 (System.Object[]), typeof(System.Object[]), 4\n\t// 32 Box v47 @ X0_v3 (System.Object[]), typeof(System.Byte), &c @ X0 (UnityEngine.Color32)\n\tv57 = v47 == 0;\n\tif (v57) goto L_002C;\n\t// 41 IsInst v47 @ X0_v3 (System.Object[]), typeof(System.Object), v47 @ X0_v3 (System.Object[])\nL_002C:\n\tv122 = v47.Length;\n\tv120 = v47.Length == 0;\n\tif (v120) goto L_0092;\n\tv47[0] = v47;\n\tv122 = c >> 8;\n\t// 52 Box v47 @ X0_v3 (System.Object[]), typeof(System.Byte), &v122 @ X8_v11 (System.Int32)\n\tv253 = v47 == 0;\n\tif (v253) goto L_003E;\n\t// 59 IsInst v47 @ X0_v3 (System.Object[]), typeof(System.Object), v47 @ X0_v3 (System.Object[])\nL_003E:\n\tv122 = v47.Length;\n\tv258 = v47.Length < 1;\n\tv163 = ~v258;\n\tv159 = v47.Length - 1;\n\tv151 = v159 == 0;\n\tv259 = ~v163;\n\tv131 = v259 | v151;\n\tif (v131) goto L_0092;\n\tv47[1] = v47;\n\tv122 = c >> 0x10;\n\t// 80 Box v47 @ X0_v3 (System.Object[]), typeof(System.Byte), &v122 @ X8_v11 (System.Int32)\n\tv264 = v47 == 0;\n\tif (v264) goto L_005A;\n\t// 87 IsInst v47 @ X0_v3 (System.Object[]), typeof(System.Object), v47 @ X0_v3 (System.Object[])\nL_005A:\n\tv122 = v47.Length;\n\tv267 = v47.Length < 2;\n\tv164 = ~v267;\n\tv160 = v47.Length - 2;\n\tv152 = v160 == 0;\n\tv268 = ~v164;\n\tv132 = v268 | v152;\n\tif (v132) goto L_0092;\n\tv47[2] = v47;\n\tv122 = c >> 0x18;\n\t// 108 Box v47 @ X0_v3 (System.Object[]), typeof(System.Byte), &v122 @ X8_v11 (System.Int32)\n\tv273 = v47 == 0;\n\tif (v273) goto L_0077;\n\t// 115 IsInst v47 @ X0_v3 (System.Object[]), typeof(System.Object), v47 @ X0_v3 (System.Object[])\nL_0077:\n\tv276 = v47.Length < 3;\n\tv165 = ~v276;\n\tv161 = v47.Length - 3;\n\tv153 = v161 == 0;\n\tv277 = ~v165;\n\tv133 = v277 | v153;\n\tif (v133) goto L_0092;\n\tv47[3] = v47;\n\treturnVal2 = System.String::Format(\"{0:X2}{1:X2}{2:X2}{3:X2}\", v47);\n\treturn returnVal2;\nL_0092:\n\tv188 = new System.IndexOutOfRangeException();\n\tgoto L_0097;\n\tv252 = new System.ArrayTypeMismatchException();\nL_0097:\n\tthrow v255;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 91 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string ToRGBAHexString(this Color32 c)
		{
			//IL_02fb: Expected I4, but got O
			//IL_007d: Expected I4, but got O
			//IL_00ef: Expected O, but got I4
			//IL_0144: Expected I4, but got O
			//IL_01b6: Expected O, but got I4
			//IL_020b: Expected I4, but got O
			//IL_0273: Expected O, but got I4
			object[] array = new object[4];
			array = (object[])(object)(byte)(int)c;
			if (array != null)
			{
				array = (object[])(array as object);
			}
			int num = array.Length;
			if (array.Length != 0)
			{
				array[0] = array;
				num = (object)c >> 8;
				array = (object[])(object)(byte)num;
				if (array != null)
				{
					array = (object[])(array as object);
				}
				num = array.Length;
				bool flag = array.Length < 1;
				bool flag2 = !flag;
				object obj = array.Length - 1;
				bool flag3 = obj == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = array;
					num = (object)c >> 16;
					array = (object[])(object)(byte)num;
					if (array != null)
					{
						array = (object[])(array as object);
					}
					num = array.Length;
					bool flag5 = array.Length < 2;
					bool flag6 = !flag5;
					object obj2 = array.Length - 2;
					bool flag7 = obj2 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = array;
						num = (object)c >> 24;
						array = (object[])(object)(byte)num;
						if (array != null)
						{
							array = (object[])(array as object);
						}
						bool flag9 = array.Length < 3;
						bool flag10 = !flag9;
						object obj3 = array.Length - 3;
						bool flag11 = obj3 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[3] = array;
							return string.Format("{0:X2}{1:X2}{2:X2}{3:X2}", array);
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000718")]
		[Address(RVA = "0xBFB3E0", Offset = "0xBFB3E0", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = UnityEngine.Color32::op_Implicit(color);\n\tv13 = v12 & 0xFFFFFFFF;\n\treturnVal1 = EasyMobile.Internal.ColorExt::ToRGBAHexString(v13);\n\treturn returnVal1;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string ToRGBAHexString(this Color color)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Expected O, but got Unknown
			Color32 color2 = color;
			Color32 c = (Color32)(color2 & 0xFFFFFFFFL);
			return c.ToRGBAHexString();
		}

		[Token(Token = "0x6000719")]
		[Address(RVA = "0xBFB3FC", Offset = "0xBFB3FC", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EAEA00]);\n\tv23 = *([v22 @ X8_v28]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022F26]) = v42;\nL_0019:\n\t// 25 NewArr v47 @ X0_v3 (System.Object[]), typeof(System.Object[]), 4\n\tv51 = c >> 0x18;\n\t// 33 Box v47 @ X0_v3 (System.Object[]), typeof(System.Byte), &v51 @ X8_v5 (System.Int32)\n\tv58 = v47 == 0;\n\tif (v58) goto L_002D;\n\t// 42 IsInst v47 @ X0_v3 (System.Object[]), typeof(System.Object), v47 @ X0_v3 (System.Object[])\nL_002D:\n\tv51 = v47.Length;\n\tv121 = v47.Length == 0;\n\tif (v121) goto L_0092;\n\tv47[0] = v47;\n\t// 52 Box v47 @ X0_v3 (System.Object[]), typeof(System.Byte), &c @ X0 (UnityEngine.Color32)\n\tv253 = v47 == 0;\n\tif (v253) goto L_003E;\n\t// 59 IsInst v47 @ X0_v3 (System.Object[]), typeof(System.Object), v47 @ X0_v3 (System.Object[])\nL_003E:\n\tv51 = v47.Length;\n\tv258 = v47.Length < 1;\n\tv163 = ~v258;\n\tv159 = v47.Length - 1;\n\tv151 = v159 == 0;\n\tv259 = ~v163;\n\tv131 = v259 | v151;\n\tif (v131) goto L_0092;\n\tv47[1] = v47;\n\tv51 = c >> 8;\n\t// 80 Box v47 @ X0_v3 (System.Object[]), typeof(System.Byte), &v51 @ X8_v5 (System.Int32)\n\tv264 = v47 == 0;\n\tif (v264) goto L_005A;\n\t// 87 IsInst v47 @ X0_v3 (System.Object[]), typeof(System.Object), v47 @ X0_v3 (System.Object[])\nL_005A:\n\tv51 = v47.Length;\n\tv267 = v47.Length < 2;\n\tv164 = ~v267;\n\tv160 = v47.Length - 2;\n\tv152 = v160 == 0;\n\tv268 = ~v164;\n\tv132 = v268 | v152;\n\tif (v132) goto L_0092;\n\tv47[2] = v47;\n\tv51 = c >> 0x10;\n\t// 108 Box v47 @ X0_v3 (System.Object[]), typeof(System.Byte), &v51 @ X8_v5 (System.Int32)\n\tv273 = v47 == 0;\n\tif (v273) goto L_0077;\n\t// 115 IsInst v47 @ X0_v3 (System.Object[]), typeof(System.Object), v47 @ X0_v3 (System.Object[])\nL_0077:\n\tv276 = v47.Length < 3;\n\tv165 = ~v276;\n\tv161 = v47.Length - 3;\n\tv153 = v161 == 0;\n\tv277 = ~v165;\n\tv133 = v277 | v153;\n\tif (v133) goto L_0092;\n\tv47[3] = v47;\n\treturnVal2 = System.String::Format(\"{0:X2}{1:X2}{2:X2}{3:X2}\", v47);\n\treturn returnVal2;\nL_0092:\n\tv188 = new System.IndexOutOfRangeException();\n\tgoto L_0097;\n\tv252 = new System.ArrayTypeMismatchException();\nL_0097:\n\tthrow v255;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 91 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string ToARGBHexString(this Color32 c)
		{
			//IL_02f2: Expected I4, but got O
			//IL_0078: Expected I4, but got O
			//IL_00e1: Expected O, but got I4
			//IL_0136: Expected I4, but got O
			//IL_01a8: Expected O, but got I4
			//IL_01fd: Expected I4, but got O
			//IL_0265: Expected O, but got I4
			object[] array = new object[4];
			int num = (object)c >> 24;
			array = (object[])(object)(byte)num;
			if (array != null)
			{
				array = (object[])(array as object);
			}
			num = array.Length;
			if (array.Length != 0)
			{
				array[0] = array;
				array = (object[])(object)(byte)(int)c;
				if (array != null)
				{
					array = (object[])(array as object);
				}
				num = array.Length;
				bool flag = array.Length < 1;
				bool flag2 = !flag;
				object obj = array.Length - 1;
				bool flag3 = obj == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = array;
					num = (object)c >> 8;
					array = (object[])(object)(byte)num;
					if (array != null)
					{
						array = (object[])(array as object);
					}
					num = array.Length;
					bool flag5 = array.Length < 2;
					bool flag6 = !flag5;
					object obj2 = array.Length - 2;
					bool flag7 = obj2 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = array;
						num = (object)c >> 16;
						array = (object[])(object)(byte)num;
						if (array != null)
						{
							array = (object[])(array as object);
						}
						bool flag9 = array.Length < 3;
						bool flag10 = !flag9;
						object obj3 = array.Length - 3;
						bool flag11 = obj3 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[3] = array;
							return string.Format("{0:X2}{1:X2}{2:X2}{3:X2}", array);
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600071A")]
		[Address(RVA = "0xBFB5A0", Offset = "0xBFB5A0", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = UnityEngine.Color32::op_Implicit(color);\n\tv13 = v12 & 0xFFFFFFFF;\n\treturnVal1 = EasyMobile.Internal.ColorExt::ToARGBHexString(v13);\n\treturn returnVal1;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string ToARGBHexString(this Color color)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Expected O, but got Unknown
			Color32 color2 = color;
			Color32 c = (Color32)(color2 & 0xFFFFFFFFL);
			return c.ToARGBHexString();
		}

		[Token(Token = "0x600071B")]
		[Address(RVA = "0xBFB5BC", Offset = "0xBFB5BC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t// 0 NotImplemented \"Instruction REV not yet implemented.\"\n\treturn c;\n")]
		public static int ToRGBAHex(this Color32 c)
		{
			//IL_000f: Expected I4, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction REV not yet implemented.\"");
			return (int)c;
		}

		[Token(Token = "0x600071C")]
		[Address(RVA = "0xBFB5C4", Offset = "0xBFB5C4", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Color32::op_Implicit(color);\n\t// 10 NotImplemented \"Instruction REV not yet implemented.\"\n\treturn returnVal1;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int ToRGBAHex(this Color color)
		{
			//IL_000d: Expected I4, but got O
			int result = (int)(Color32)color;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction REV not yet implemented.\"");
			return result;
		}

		[Token(Token = "0x600071D")]
		[Address(RVA = "0xBFB5E0", Offset = "0xBFB5E0", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = c & 0xFF00FF00;\n\tv2 = c & 0xFF;\n\tv3 = v2 << 0x10;\n\tv4 = v0 & 0xFFFFFFFFFF00FFFF;\n\tv5 = v4 | v3;\n\tv6 = c >> 0x10;\n\tv7 = v6 & 0xFF;\n\tv8 = v5 & 0xFFFFFFFFFFFFFF00;\n\tv9 = v8 | v7;\n\treturn v9;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int ToARGBHex(this Color32 c)
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Expected I4, but got Unknown
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Expected I4, but got Unknown
			//IL_0057: Expected I4, but got O
			int num = (int)(c & 0xFF00FF00L);
			int num2 = c & 0xFF;
			int num3 = num2 << 16;
			int num4 = num & -16711681;
			int num5 = num4 | num3;
			int num6 = (object)c >> 16;
			int num7 = num6 & 0xFF;
			int num8 = num5 & -256;
			return num8 | num7;
		}

		[Token(Token = "0x600071E")]
		[Address(RVA = "0xBFB5F4", Offset = "0xBFB5F4", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = UnityEngine.Color32::op_Implicit(color);\n\tv13 = v12 & 0xFF00FF00;\n\tv14 = v12 & 0xFF;\n\tv15 = v14 << 0x10;\n\tv16 = v13 & 0xFFFFFFFFFF00FFFF;\n\tv17 = v16 | v15;\n\tv18 = v12 >> 0x10;\n\tv19 = v18 & 0xFF;\n\tv20 = v17 & 0xFFFFFFFFFFFFFF00;\n\tv21 = v20 | v19;\n\treturn v21;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int ToARGBHex(this Color color)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Expected I4, but got Unknown
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected I4, but got Unknown
			//IL_0064: Expected I4, but got O
			Color32 color2 = color;
			int num = (int)(color2 & 0xFF00FF00L);
			int num2 = color2 & 0xFF;
			int num3 = num2 << 16;
			int num4 = num & -16711681;
			int num5 = num4 | num3;
			int num6 = (object)color2 >> 16;
			int num7 = num6 & 0xFF;
			int num8 = num5 & -256;
			return num8 | num7;
		}
	}
}
