using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine.Unity
{
	[Token(Token = "0x200006C")]
	public static class SkeletonDataCompatibility
	{
		[Token(Token = "0x200006D")]
		public enum SourceType
		{
			[Token(Token = "0x40002B1")]
			Json = 0,
			[Token(Token = "0x40002B2")]
			Binary = 1
		}

		[Serializable]
		[Token(Token = "0x200006E")]
		public class VersionInfo
		{
			[Token(Token = "0x40002B3")]
			[FieldOffset(Offset = "0x10")]
			public string rawVersion;

			[Token(Token = "0x40002B4")]
			[FieldOffset(Offset = "0x18")]
			public int[] version;

			[Token(Token = "0x40002B5")]
			[FieldOffset(Offset = "0x20")]
			public SourceType sourceType;

			[Token(Token = "0x60004A5")]
			[Address(RVA = "0x15521DC", Offset = "0x15521DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public VersionInfo()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x200006F")]
		public class CompatibilityProblemInfo
		{
			[Token(Token = "0x40002B6")]
			[FieldOffset(Offset = "0x10")]
			public VersionInfo actualVersion;

			[Token(Token = "0x40002B7")]
			[FieldOffset(Offset = "0x18")]
			public int[][] compatibleVersions;

			[Token(Token = "0x60004A6")]
			[Address(RVA = "0x15521E4", Offset = "0x15521E4", Length = "0x2C0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv30 = System.Int32;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv54 = System.Object[];\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv233 = \"Skeleton data could not be loaded. Data version: {0}. Required version: {1}.\\nPlease re-export skeleton data with Spine {1} or change runtime to version {2}.{3}.\";\n\tv234 = \"il2cpp_codegen_initialize_runtime_metadata\"(v233, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv327 = \"{0}{1}.{2}\";\n\tv328 = \"il2cpp_codegen_initialize_runtime_metadata\"(v327, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv345 = \"\";\n\tv346 = \"il2cpp_codegen_initialize_runtime_metadata\"(v345, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv384 = \" or \";\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v384, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A37BDC]) = v50;\nL_0027:\n\tv51 = this.compatibleVersions;\n\tv221 = v51.Length;\n\tv72 = v51.Length < 1;\n\tif (v72) goto L_008B;\nL_004E:\n\tv109 = v51[v118 @ X25_v7 (System.Int32)];\n\tv432 = v109[0];\n\t// 88 Box v369 @ X0_v32 (System.Object), typeof(System.Int32), &v432 @ X8_v34 (System.Int32)\n\tv440 = v109[1];\n\t// 107 Box v443 @ X0_v34 (System.Object), typeof(System.Int32), &v440 @ X8_v36 (System.Int32)\n\tv452 = System.String::Format(\"{0}{1}.{2}\", v228, v369, v443);\n\tv259 = System.String::Concat(v137, v452);\n\tv118 = v118 + 1;\n\tv248 = v118 < v51.Length;\n\tif (v248) goto L_004E;\nL_008B:\n\t// 139 NewArr v204 @ X0_v11 (System.Object[]), typeof(System.Object[]), 4\n\tv221 = this.actualVersion;\n\tv385 = v221.rawVersion == 0;\n\tif (v385) goto L_009E;\n\t// 152 IsInst v308 @ X0_v29, typeof(System.Object), v221.rawVersion (System.String)\n\tv313 = v308 == 0;\n\tif (v313) goto L_011E;\nL_009E:\n\tv204[0] = v221.rawVersion;\n\tv439 = v138 == 0;\n\tif (v439) goto L_00B4;\n\t// 164 IsInst v309 @ X0_v27, typeof(System.Object), v138 @ X21_v5 (System.String)\n\tv314 = v309 == 0;\n\tif (v314) goto L_011E;\nL_00B4:\n\tv204[1] = v138;\n\tv221 = this.actualVersion;\n\tv223 = v221.version;\n\tv456 = v223[0];\n\t// 194 Box v459 @ X0_v15, typeof(System.Int32), &v456 @ X8_v16 (System.Int32)\n\tv460 = v459 == 0;\n\tif (v460) goto L_00D9;\n\t// 201 IsInst v310 @ X0_v25, typeof(System.Object), v459 @ X0_v15\n\tv315 = v310 == 0;\n\tif (v315) goto L_011E;\nL_00D9:\n\tv204[2] = v459;\n\tv221 = this.actualVersion;\n\tv225 = v221.version;\n\tv467 = v225[1];\n\t// 241 Box v470 @ X0_v18, typeof(System.Int32), &v467 @ X8_v21 (System.Int32)\n\tv471 = v470 == 0;\n\tif (v471) goto L_010A;\n\t// 248 IsInst v311 @ X0_v23, typeof(System.Object), v470 @ X0_v18\n\tv316 = v311 == 0;\n\tif (v316) goto L_011E;\nL_010A:\n\tv204[3] = v470;\n\treturnVal2 = System.String::Format(\"Skeleton data could not be loaded. Data version: {0}. Required version: {1}.\\nPlease re-export skeleton data with Spine {1} or change runtime to version {2}.{3}.\", v204);\n\treturn returnVal2;\n\tv202 = new System.IndexOutOfRangeException();\n\tv231 = new System.NullReferenceException();\nL_011E:\n\tv325 = new System.ArrayTypeMismatchException();\n\tthrow v325;\n\treturn returnVal1;\n// 220 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public string DescriptionString()
			{
				//IL_000f: Expected O, but got I4
				int[][] array = compatibleVersions;
				VersionInfo versionInfo = (VersionInfo)array.Length;
				bool flag = array.Length < 1;
				string text = "";
				if (!flag)
				{
					int num = 0;
					string text2 = "";
					string arg = null;
					bool flag2;
					do
					{
						int[] array2 = array[num];
						int num2 = array2[0];
						object arg2 = num2;
						int num3 = array2[1];
						object arg3 = num3;
						string text3 = $"{arg}{arg2}.{arg3}";
						string text4 = text2 + text3;
						num++;
						flag2 = num < array.Length;
						text = text4;
						text2 = text4;
						arg = " or ";
					}
					while (flag2);
				}
				object[] array3 = new object[4];
				versionInfo = actualVersion;
				if (versionInfo.rawVersion != null)
				{
					object obj = versionInfo.rawVersion as object;
					if (obj == null)
					{
						goto IL_0348;
					}
				}
				array3[0] = versionInfo.rawVersion;
				if (text != null)
				{
					object obj2 = text as object;
					if (obj2 == null)
					{
						goto IL_0348;
					}
				}
				array3[1] = text;
				versionInfo = actualVersion;
				int[] version = versionInfo.version;
				int num4 = version[0];
				object obj3 = num4;
				if (obj3 != null)
				{
					object obj4 = obj3 as object;
					if (obj4 == null)
					{
						goto IL_0348;
					}
				}
				array3[2] = obj3;
				versionInfo = actualVersion;
				int[] version2 = versionInfo.version;
				int num5 = version2[1];
				object obj5 = num5;
				if (obj5 != null)
				{
					object obj6 = obj5 as object;
					if (obj6 == null)
					{
						goto IL_0348;
					}
				}
				array3[3] = obj5;
				return string.Format("Skeleton data could not be loaded. Data version: {0}. Required version: {1}.\nPlease re-export skeleton data with Spine {1} or change runtime to version {2}.{3}.", array3);
				IL_0348:
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}

			[Token(Token = "0x60004A7")]
			[Address(RVA = "0x15524A4", Offset = "0x15524A4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public CompatibilityProblemInfo()
			{
			}
		}
	}
}
