using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.Extensions
{
	[Token(Token = "0x2000016")]
	public static class MathExtensions
	{
		[Token(Token = "0x6000075")]
		[Address(RVA = "0x81A9AD8", Offset = "0x81A9AD8", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001D:\n\t// 29 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv53 = value < 1;\n\treturn v53;\nL_001B:\n\tgoto L_001D;\n")]
		public static bool Approximately(this double value, double other)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
			return value < 5E-324;
		}

		[Token(Token = "0x6000076")]
		[Address(RVA = "0x81A9B4C", Offset = "0x81A9B4C", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001E:\n\tv52 = value / interval;\n\tv56 = 0x8BF6AF4(&v54 @ stack_-38_v1 (System.Double), v28, v29, v30, v31, v32, v33, v34, v52, interval, v35, v36, v37, v38, v39, v40);\n\tv57 = v52 < 0;\n\tv61 = v52 == v52;\n\tv62 = ~v61;\n\tv63 = v57 == v62;\n\tif (v63) goto L_003B;\n\tv66 = v52 == -0.5d;\n\tv73 = ~v66;\n\tif (v73) goto L_005C;\nL_FFFFFFFF:\n\tv95 = -1d;\nL_FFFFFFFF:\n\tv153 = v54;\nL_FFFFFFFF:\n\tv103 = v54;\n\tgoto L_0047;\nL_003B:\n\tv76 = v52 == 0.5d;\n\tv83 = ~v76;\n\tif (v83) goto L_0067;\nL_FFFFFFFF:\n\tv95 = 1d;\nL_FFFFFFFF:\n\tv153 = v54;\nL_FFFFFFFF:\n\tv103 = v54;\n\tgoto L_0053;\nL_FFFFFFFF:\n\tv153 = v104;\nL_005C:\n\tv87 = v52 + -0.5d;\n\tv88 = System.Math::Ceiling(v87);\n\treturnVal1 = v88 * interval;\n\treturn returnVal1;\nL_0067:\n\tv92 = v52 + 0.5d;\n\tv93 = System.Math::Floor(v92);\n\treturnVal2 = v93 * interval;\n\treturn returnVal2;\nL_001B:\n\tgoto L_001E;\nL_0047:\n\tv104 = v153 + v95;\n\tv105 = v103 & 1;\n\tv107 = v105 == 0;\n\tv110 = ~v107;\n\tif (v110) goto L_FFFFFFFF;\nL_0053:\n\treturnVal3 = v153 * interval;\n\treturn returnVal3;\n")]
		public static double Round(this double value, float interval = 1f)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MathExtensions::Round");
			return default;
		}

		[Token(Token = "0x6000077")]
		[Address(RVA = "0x81A9C54", Offset = "0x81A9C54", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\nL_001F:\n\tv55 = value / interval;\n\tv60 = 0x8BF6AF4(&v58 @ stack_-48_v1 (System.Double), v32, v33, v34, v35, v36, v37, v38, v55, interval, v39, v40, v41, v42, v43, v44);\n\tv61 = v55 < 0;\n\tv65 = v55 == v55;\n\tv66 = ~v65;\n\tv67 = v61 == v66;\n\tif (v67) goto L_003D;\n\tv70 = v55 == -0.5d;\n\tv77 = ~v70;\n\tif (v77) goto L_0056;\nL_FFFFFFFF:\n\tv99 = -1d;\nL_FFFFFFFF:\n\tv125 = v58;\nL_FFFFFFFF:\n\tv107 = v58;\n\tgoto L_0049;\nL_003D:\n\tv80 = v55 == 0.5d;\n\tv87 = ~v80;\n\tif (v87) goto L_0059;\nL_FFFFFFFF:\n\tv99 = 1d;\nL_FFFFFFFF:\n\tv125 = v58;\nL_FFFFFFFF:\n\tv107 = v58;\n\tgoto L_0055;\nL_FFFFFFFF:\n\tv125 = v108;\nL_0056:\n\tv91 = v55 + -0.5d;\n\tv125 = System.Math::Ceiling(v91);\n\tgoto L_005C;\nL_0059:\n\tv96 = v55 + 0.5d;\n\tv125 = System.Math::Floor(v96);\nL_005C:\n\tv130 = v125 * interval;\n\treturn v130;\nL_001D:\n\tgoto L_001F;\nL_0049:\n\tv108 = v125 + v99;\n\tv109 = v107 & 1;\n\tv111 = v109 == 0;\n\tv114 = ~v111;\n\tif (v114) goto L_FFFFFFFF;\nL_0055:\n\tgoto L_005C;\n")]
		public static float Round(this float value, float interval = 1f)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MathExtensions::Round");
			return default;
		}

		[Token(Token = "0x6000078")]
		[Address(RVA = "0x81A9D44", Offset = "0x81A9D44", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0017;\nL_0017:\n\tv52 = 0x8BF6AF4(&v50 @ stack_-38_v6 (System.Double), v28, v29, v30, v31, v32, v33, v34, v83, v35, v36, v37, v38, v39, v40, v41);\n\tv59 = v83 < 0;\n\tv63 = v83 == v83;\n\tv64 = ~v63;\n\tv65 = v59 == v64;\n\tif (v65) goto L_0049;\n\tv91 = v83 == -0.5d;\n\tv98 = ~v91;\n\tif (v98) goto L_0062;\nL_FFFFFFFF:\n\tv134 = -1d;\nL_FFFFFFFF:\n\tv164 = v50;\nL_FFFFFFFF:\n\tv146 = v50;\n\tgoto L_0055;\nL_0049:\n\tv113 = v83 == 0.5d;\n\tv120 = ~v113;\n\tif (v120) goto L_0065;\nL_FFFFFFFF:\n\tv134 = 1d;\nL_FFFFFFFF:\n\tv164 = v50;\nL_FFFFFFFF:\n\tv146 = v50;\n\tgoto L_0061;\nL_FFFFFFFF:\n\tv164 = v147;\nL_0062:\n\tv126 = v83 + -0.5d;\n\tv164 = System.Math::Ceiling(v126);\n\tgoto L_006B;\nL_0065:\n\tv131 = v83 + 0.5d;\n\tv164 = System.Math::Floor(v131);\nL_006B:\n\tv175 = v164 == 0x7FF0000000000000;\n\tv183 = ~v175;\n\tif (v183) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal1 = 0xFFFFFFFF80000000;\n\tgoto L_0080;\nL_FFFFFFFF:\n\treturnVal1 = v164;\nL_0055:\n\tv147 = v164 + v134;\n\tv148 = v146 & 1;\n\tv150 = v148 == 0;\n\tv153 = ~v150;\n\tif (v153) goto L_FFFFFFFF;\nL_0061:\n\tgoto L_006B;\nL_0080:\n\treturn returnVal1;\n")]
		public static int RoundToInt(this float value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MathExtensions::RoundToInt");
			return default;
		}

		[Token(Token = "0x6000079")]
		[Address(RVA = "0x81A9E54", Offset = "0x81A9E54", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = value / 0x4059000000000000;\n\treturnVal1 = v2 + 1d;\n\treturn returnVal1;\n")]
		public static double PercentToMultiplier(this double value)
		{
			double num = value / 4.636737291354636E+18;
			return num + 1.0;
		}

		[Token(Token = "0x600007A")]
		[Address(RVA = "0x81A9E6C", Offset = "0x81A9E6C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = value / 0x42C80000;\n\treturnVal1 = v2 + 1f;\n\treturn returnVal1;\n")]
		public static float PercentToMultiplier(this float value)
		{
			float num = value / 100f;
			return num + 1f;
		}

		[Token(Token = "0x600007B")]
		[Address(RVA = "0x81A9E84", Offset = "0x81A9E84", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = value + -1d;\n\treturnVal1 = v1 * 0x4059000000000000;\n\treturn returnVal1;\n")]
		public static double MultiplierToPercent(this double value)
		{
			double num = value + -1.0;
			return num * 4.636737291354636E+18;
		}

		[Token(Token = "0x600007C")]
		[Address(RVA = "0x81A9E9C", Offset = "0x81A9E9C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = value + -1f;\n\treturnVal1 = v1 * 0x42C80000;\n\treturn returnVal1;\n")]
		public static float MultiplierToPercent(this float value)
		{
			float num = value + -1f;
			return num * 100f;
		}

		[Token(Token = "0x600007D")]
		[Address(RVA = "0x81A9EB4", Offset = "0x81A9EB4", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_002C:\n\tv66 = v45.Epsilon + value;\n\tv67 = UnityEngine.Mathf::Floor(v66);\n\tv72 = v67 == 0x7F800000;\n\tv80 = ~v72;\n\tif (v80) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal1 = 0xFFFFFFFF80000000;\n\tgoto L_0047;\nL_FFFFFFFF:\n\treturnVal1 = v66;\nL_0020:\n\tgoto L_002A;\nL_0047:\n\treturn returnVal1;\nL_002A:\n\tgoto L_002C;\n")]
		public static int FloorToIntApproximate(this float value)
		{
			//IL_0062: Expected I4, but got F4
			float num = Mathf.Epsilon + value;
			float num2 = Mathf.Floor(num);
			if (num2 == 1f / 0f)
			{
				return -2147483648;
			}
			return (int)num;
		}

		[Token(Token = "0x600007E")]
		[Address(RVA = "0x81A9FE4", Offset = "0x81A9FE4", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_002C:\n\tv66 = value - v45.Epsilon;\n\tv67 = UnityEngine.Mathf::Ceil(v66);\n\tv72 = v67 == 0x7F800000;\n\tv80 = ~v72;\n\tif (v80) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal1 = 0xFFFFFFFF80000000;\n\tgoto L_0047;\nL_FFFFFFFF:\n\treturnVal1 = v66;\nL_0020:\n\tgoto L_002A;\nL_0047:\n\treturn returnVal1;\nL_002A:\n\tgoto L_002C;\n")]
		public static int CeilToIntApproximate(this float value)
		{
			//IL_0062: Expected I4, but got F4
			float num = value - Mathf.Epsilon;
			float num2 = Mathf.Ceil(num);
			if (num2 == 1f / 0f)
			{
				return -2147483648;
			}
			return (int)num;
		}

		[Token(Token = "0x600007F")]
		[Address(RVA = "0x81A9F64", Offset = "0x81A9F64", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001D:\n\tv51 = value + maxDelta;\n\tv52 = UnityEngine.Mathf::Floor(v51);\n\tv57 = v52 == 0x7F800000;\n\tv65 = ~v57;\n\tif (v65) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal1 = 0xFFFFFFFF80000000;\n\tgoto L_0038;\nL_FFFFFFFF:\n\treturnVal1 = v51;\nL_001B:\n\tgoto L_001D;\nL_0038:\n\treturn returnVal1;\n")]
		public static int FloorToIntApproximate(this float value, float maxDelta)
		{
			//IL_0061: Expected I4, but got F4
			float num = value + maxDelta;
			float num2 = Mathf.Floor(num);
			if (num2 == 1f / 0f)
			{
				return -2147483648;
			}
			return (int)num;
		}

		[Token(Token = "0x6000080")]
		[Address(RVA = "0x81AA094", Offset = "0x81AA094", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001D:\n\tv51 = value - maxDelta;\n\tv52 = UnityEngine.Mathf::Ceil(v51);\n\tv57 = v52 == 0x7F800000;\n\tv65 = ~v57;\n\tif (v65) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal1 = 0xFFFFFFFF80000000;\n\tgoto L_0038;\nL_FFFFFFFF:\n\treturnVal1 = v51;\nL_001B:\n\tgoto L_001D;\nL_0038:\n\treturn returnVal1;\n")]
		public static int CeilToIntApproximate(this float value, float maxDelta)
		{
			//IL_0061: Expected I4, but got F4
			float num = value - maxDelta;
			float num2 = Mathf.Ceil(num);
			if (num2 == 1f / 0f)
			{
				return -2147483648;
			}
			return (int)num;
		}

		[Token(Token = "0x6000081")]
		[Address(RVA = "0x81AA114", Offset = "0x81AA114", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tgoto L_0030;\nL_FFFFFFFF:\n\tv61 = v46;\n\tgoto L_0044;\nL_FFFFFFFF:\n\tv85 = v70;\nL_0017:\n\tv61 = UnityEngine.Mathf::Abs(value);\n\tv46 = UnityEngine.Mathf::Abs(other);\n\tv47 = v61 < v46;\n\tv48 = v61 == v46;\n\tv51 = v61 == v61;\n\tv52 = v46 == v46;\n\tv53 = v51 & v52;\n\tv54 = ~v53;\n\tv55 = v47 == v54;\n\tv56 = ~v48;\n\tv57 = v55 & v56;\n\tv58 = ~v57;\n\tif (v58) goto L_FFFFFFFF;\nL_0030:\n\tv85 = v61 * 0x358637BD;\n\tv70 = v63.Epsilon * 8f;\n\tv71 = v85 < v70;\n\tv72 = v85 == v70;\n\tv75 = v85 == v85;\n\tv76 = v70 == v70;\n\tv77 = v75 & v76;\n\tv78 = ~v77;\n\tv79 = v71 == v78;\n\tv80 = ~v72;\n\tv81 = v79 & v80;\n\tv82 = ~v81;\n\tif (v82) goto L_FFFFFFFF;\nL_0044:\n\t// 68 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv86 = v70 < v85;\n\treturn v86;\n")]
		public static bool Approximately(this float value, float other)
		{
			float num = Mathf.Abs(value);
			float num2 = Mathf.Abs(other);
			bool flag = num < num2;
			bool flag2 = num == num2;
			bool flag3 = num == num;
			bool flag4 = num2 == num2;
			bool flag5 = flag3 && flag4;
			bool flag6 = !flag5;
			bool flag7 = flag == flag6;
			bool flag8 = !flag2;
			if (!(flag7 && flag8))
			{
				num = num2;
			}
			float num3 = num * 1E-06f;
			float num4 = Mathf.Epsilon * 8f;
			bool flag9 = num3 < num4;
			bool flag10 = num3 == num4;
			bool flag11 = num3 == num3;
			bool flag12 = num4 == num4;
			bool flag13 = flag11 && flag12;
			bool flag14 = !flag13;
			bool flag15 = flag9 == flag14;
			bool flag16 = !flag10;
			if (!(flag15 && flag16))
			{
				num3 = num4;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
			return num4 < num3;
		}

		[Token(Token = "0x6000082")]
		[Address(RVA = "0x81AA1AC", Offset = "0x81AA1AC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Mathf::Abs(value);\n\treturn returnVal1;\n")]
		public static float Absolute(this float value)
		{
			return Mathf.Abs(value);
		}

		[Token(Token = "0x6000083")]
		[Address(RVA = "0x81AA1B4", Offset = "0x81AA1B4", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_0025:\n\tv59 = value >= 0;\n\tif (v59) goto L_FFFFFFFF;\n\tv62 = -value;\n\tgoto L_0033;\nL_FFFFFFFF:\n\tv62 = value;\nL_001A:\n\tgoto L_0025;\nL_0033:\n\treturn v62;\n")]
		public static float Absolute(this int value)
		{
			int num = ((value >= 0) ? value : (-value));
			return num;
		}

		[Token(Token = "0x6000084")]
		[Address(RVA = "0x81AA21C", Offset = "0x81AA21C", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = v177 == 0;\n\tv8 = ~v3;\nL_FFFFFFFF:\n\tv101 = 0;\n\tif (v8) goto L_002D;\nL_0009:\n\t*([v38 @ X0_v1 (System.Single&)]) = v101;\n\tv103 = -v177;\n\tv104 = v177 < 0;\n\tv105 = v177 == 0;\n\tv108 = v177 == v177;\n\tv109 = ~v108;\n\tv110 = v104 == v109;\n\tv111 = ~v105;\n\tv112 = v110 & v111;\n\tv113 = ~v112;\n\tif (v113) goto L_FFFFFFFF;\n\tgoto L_001A;\nL_FFFFFFFF:\n\tv177 = v103;\nL_002D:\n\tgoto L_003A;\n\tgoto L_0057;\nL_FFFFFFFF:\n\tv26 = v23;\n\tv216 = v177 < 0;\n\tv217 = v177 == 0;\n\tv220 = v177 == v177;\n\tv221 = ~v220;\n\tv222 = v216 == v221;\n\tv223 = ~v222;\n\tv224 = v223 | v217;\n\tv225 = ~v224;\n\tif (v225) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv228 = -1f;\n\tgoto L_007B;\nL_FFFFFFFF:\n\tv228 = 1f;\n\tgoto L_008C;\nL_FFFFFFFF:\n\tv177 = v195;\nL_001A:\n\t*([v29 @ X1_v1 (System.Single&)]) = v177;\n\treturn;\nL_003A:\n\tv148 = UnityEngine.Mathf::Abs(v177);\n\tv150 = UnityEngine.Mathf::Max(v148, 0f);\n\tv26 = v150 * 0x358637BD;\n\tv23 = v197.Epsilon * 8f;\n\tv202 = v26 < v23;\n\tv203 = v26 == v23;\n\tv206 = v26 == v26;\n\tv207 = v23 == v23;\n\tv208 = v206 & v207;\n\tv209 = ~v208;\n\tv210 = v202 == v209;\n\tv88 = ~v203;\n\tv90 = v210 & v88;\n\tv85 = ~v90;\n\tif (v85) goto L_FFFFFFFF;\nL_0057:\n\t// 87 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv100 = v23 < v26;\nL_FFFFFFFF:\n\tv101 = 0;\n\tif (v100) goto L_0009;\nL_007B:\n\t*([v38 @ X0_v1 (System.Single&)]) = v228;\n\tv195 = -v177;\n\tv193 = v177 < 0;\n\tv191 = v177 == 0;\n\tv187 = v177 == v177;\n\tv185 = ~v187;\n\tv230 = v193 == v185;\n\tv181 = ~v191;\n\tv183 = v230 & v181;\n\tv179 = ~v183;\n\tif (v179) goto L_FFFFFFFF;\nL_008C:\n\t*([v29 @ X1_v1 (System.Single&)]) = v177;\n\treturn;\n")]
		public static void Deconstruct(this float value, out float sign, out float magnitude)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MathExtensions::Deconstruct");
			sign = default;
			magnitude = default;
		}

		[Token(Token = "0x6000085")]
		[Address(RVA = "0x81AA3E0", Offset = "0x81AA3E0", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = value < 1;\n\tif (v12) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv28 = 1;\n\tgoto L_001A;\nL_FFFFFFFF:\n\tv28 = -1;\nL_FFFFFFFF:\n\tv28 = 0;\n\tgoto L_0020;\n\tv33 = -value;\n\tgoto L_0027;\nL_FFFFFFFF:\n\tv33 = value;\nL_001A:\n\tv25 = value != 0;\n\tif (v25) goto L_0020;\nL_0020:\n\t*([sign @ X1 (System.Int32&)]) = v28;\n\tv30 = value >= 0;\n\tif (v30) goto L_FFFFFFFF;\nL_0027:\n\t*([magnitude @ X2 (System.Int32&)]) = v33;\n\treturn;\n")]
		public static void Deconstruct(this int value, out int sign, out int magnitude)
		{
			sign = default(int);
			magnitude = default(int);
			int num = ((value >= 1) ? 1 : (-1));
			if (value == 0)
			{
				num = 0;
			}
			sign = num;
			int num2 = ((value >= 0) ? value : (-value));
			magnitude = num2;
		}

		[Token(Token = "0x6000086")]
		[Address(RVA = "0x81AA428", Offset = "0x81AA428", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = value < 1f;\n\tv3 = value == 1f;\n\tv6 = value == value;\n\tv7 = 1f == 1f;\n\tv8 = v6 & v7;\n\tv9 = ~v8;\n\tv10 = v1 == v9;\n\tv11 = ~v3;\n\tv12 = v10 & v11;\n\tv13 = ~v12;\n\tif (v13) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv16 = 1f;\n\tgoto L_0012;\nL_FFFFFFFF:\n\tv16 = value;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tgoto L_001F;\nL_FFFFFFFF:\n\treturnVal1 = v16;\nL_0012:\n\tv17 = value < 0;\n\tv24 = ~v17;\n\tif (v24) goto L_FFFFFFFF;\nL_001F:\n\treturn returnVal1;\n")]
		public static float Clamp01(this float value)
		{
			bool flag = value < 1f;
			bool flag2 = value == 1f;
			bool flag3 = value == value;
			bool flag4 = 1f == 1f;
			bool flag5 = flag3 && flag4;
			bool flag6 = !flag5;
			bool flag7 = flag == flag6;
			bool flag8 = !flag2;
			float result = ((!(flag7 && flag8)) ? value : 1f);
			if (value < 0f)
			{
				return 0f;
			}
			return result;
		}

		[Token(Token = "0x6000087")]
		[Address(RVA = "0x81AA444", Offset = "0x81AA444", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = value < v16;\n\tv3 = value == v16;\n\tv6 = value == value;\n\tv7 = v16 == v16;\n\tv8 = v6 & v7;\n\tv9 = ~v8;\n\tv10 = v0 == v9;\n\tv11 = ~v3;\n\tv12 = v10 & v11;\n\tv13 = ~v12;\n\tif (v13) goto L_0011;\n\tgoto L_0011;\nL_FFFFFFFF:\n\treturnVal1 = min;\n\tgoto L_001F;\nL_FFFFFFFF:\n\treturnVal1 = value;\nL_0011:\n\tv17 = value < min;\n\tv26 = ~v17;\n\tif (v26) goto L_FFFFFFFF;\nL_001F:\n\treturn returnVal1;\n")]
		public static float Clamp(this float value, float min, float max)
		{
			float num = default(float);
			bool flag = value < num;
			bool flag2 = value == num;
			bool flag3 = value == value;
			bool flag4 = num == num;
			bool flag5 = flag3 && flag4;
			bool flag6 = !flag5;
			bool flag7 = flag == flag6;
			bool flag8 = !flag2;
			if (flag7 && flag8)
			{
			}
			if (value < min)
			{
				return min;
			}
			return value;
		}

		[Token(Token = "0x6000088")]
		[Address(RVA = "0x81AA458", Offset = "0x81AA458", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_0027:\n\treturnVal1 = System.Math::Min(value, max);\n\treturn returnVal1;\nL_001B:\n\tgoto L_0027;\n")]
		public static float ClampMax(this float value, float max)
		{
			return Math.Min(value, max);
		}

		[Token(Token = "0x6000089")]
		[Address(RVA = "0x81AA4C4", Offset = "0x81AA4C4", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_0027:\n\treturnVal1 = System.Math::Max(value, min);\n\treturn returnVal1;\nL_001B:\n\tgoto L_0027;\n")]
		public static float ClampMin(this float value, float min)
		{
			return Math.Max(value, min);
		}

		[Token(Token = "0x600008A")]
		[Address(RVA = "0x81AA530", Offset = "0x81AA530", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = value - max;\n\tv5 = v4 < 0;\n\tv7 = value ^ max;\n\tv8 = value ^ v4;\n\tv9 = v7 & v8;\n\tv10 = v9 < 0;\n\tv11 = v5 == v10;\n\tv12 = ~v11;\n\tv13 = ~v12;\n\tif (v13) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv16 = value;\n\tgoto L_0013;\nL_FFFFFFFF:\n\tv16 = max;\nL_FFFFFFFF:\n\treturnVal1 = min;\n\tgoto L_0022;\nL_FFFFFFFF:\n\treturnVal1 = v16;\nL_0013:\n\tv20 = value - min;\n\tv21 = v20 < 0;\n\tv23 = value ^ min;\n\tv24 = value ^ v20;\n\tv25 = v23 & v24;\n\tv26 = v25 < 0;\n\tv27 = v21 == v26;\n\tv28 = ~v27;\n\tv29 = ~v28;\n\tif (v29) goto L_FFFFFFFF;\nL_0022:\n\treturn returnVal1;\n")]
		public static int Clamp(this int value, int min, int max)
		{
			int num = value - max;
			bool flag = num < 0;
			int num2 = value ^ max;
			int num3 = value ^ num;
			int num4 = num2 & num3;
			bool flag2 = num4 < 0;
			int result = ((flag == flag2) ? max : value);
			int num5 = value - min;
			bool flag3 = num5 < 0;
			int num6 = value ^ min;
			int num7 = value ^ num5;
			int num8 = num6 & num7;
			bool flag4 = num8 < 0;
			if (flag3 != flag4)
			{
				return min;
			}
			return result;
		}

		[Token(Token = "0x600008B")]
		[Address(RVA = "0x81AA544", Offset = "0x81AA544", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_0027:\n\treturnVal1 = System.Math::Min(value, max);\n\treturn returnVal1;\nL_001B:\n\tgoto L_0027;\n")]
		public static int ClampMax(this int value, int max)
		{
			return Math.Min(value, max);
		}

		[Token(Token = "0x600008C")]
		[Address(RVA = "0x81AA5B0", Offset = "0x81AA5B0", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_0027:\n\treturnVal1 = System.Math::Max(value, min);\n\treturn returnVal1;\nL_001B:\n\tgoto L_0027;\n")]
		public static int ClampMin(this int value, int min)
		{
			return Math.Max(value, min);
		}

		[Token(Token = "0x600008D")]
		[Address(RVA = "0x81AA61C", Offset = "0x81AA61C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = -v17;\n\tv2 = value < v17;\n\tv4 = value == v17;\n\tv7 = value == value;\n\tv8 = v17 == v17;\n\tv9 = v7 & v8;\n\tv10 = ~v9;\n\tv11 = v2 == v10;\n\tv12 = ~v4;\n\tv13 = v11 & v12;\n\tv14 = ~v13;\n\tif (v14) goto L_0012;\n\tgoto L_0012;\nL_FFFFFFFF:\n\treturnVal1 = v0;\n\tgoto L_0023;\nL_FFFFFFFF:\n\treturnVal1 = value;\nL_0012:\n\tv18 = v0 < value;\n\tv19 = v0 == value;\n\tv22 = v0 == v0;\n\tv23 = value == value;\n\tv24 = v22 & v23;\n\tv25 = ~v24;\n\tv26 = v18 == v25;\n\tv27 = ~v19;\n\tv28 = v26 & v27;\n\tv29 = ~v28;\n\tif (v29) goto L_FFFFFFFF;\nL_0023:\n\treturn returnVal1;\n")]
		public static float ClampMagnitude(this float value, float mag)
		{
			float num2 = default(float);
			float num = 0f - num2;
			bool flag = value < num2;
			bool flag2 = value == num2;
			bool flag3 = value == value;
			bool flag4 = num2 == num2;
			bool flag5 = flag3 && flag4;
			bool flag6 = !flag5;
			bool flag7 = flag == flag6;
			bool flag8 = !flag2;
			if (flag7 && flag8)
			{
			}
			bool flag9 = num < value;
			bool flag10 = num == value;
			bool flag11 = num == num;
			bool flag12 = value == value;
			bool flag13 = flag11 && flag12;
			bool flag14 = !flag13;
			bool flag15 = flag9 == flag14;
			bool flag16 = !flag10;
			if (flag15 && flag16)
			{
				return num;
			}
			return value;
		}

		[Token(Token = "0x600008E")]
		[Address(RVA = "0x81AA314", Offset = "0x81AA314", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = v60 == 0;\n\tv7 = ~v2;\n\tif (v7) goto L_0019;\n\treturn 0;\nL_0019:\n\tgoto L_0021;\n\tgoto L_003E;\nL_FFFFFFFF:\n\tv55 = v52;\n\treturn 0;\nL_0053:\n\tv107 = v60 < 0;\n\tv104 = v60 == 0;\n\tv98 = v60 == v60;\n\tv95 = ~v98;\n\tv151 = v107 == v95;\n\tv152 = ~v151;\n\tv92 = v152 | v104;\n\tv40 = ~v92;\n\tif (v40) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal3 = -1;\n\tgoto L_0063;\nL_FFFFFFFF:\n\treturnVal3 = 1;\nL_0021:\n\tv128 = UnityEngine.Mathf::Abs(v60);\n\tv129 = UnityEngine.Mathf::Max(v128, 0f);\n\tv55 = v129 * 0x358637BD;\n\tv52 = v131.Epsilon * 8f;\n\tv136 = v55 < v52;\n\tv137 = v55 == v52;\n\tv140 = v55 == v55;\n\tv141 = v52 == v52;\n\tv142 = v140 & v141;\n\tv143 = ~v142;\n\tv144 = v136 == v143;\n\tv43 = ~v137;\n\tv145 = v144 & v43;\n\tv39 = ~v145;\n\tif (v39) goto L_FFFFFFFF;\nL_003E:\n\t// 62 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv106 = 0 < v55;\n\tv91 = ~v106;\n\tif (v91) goto L_0053;\nL_0063:\n\treturn returnVal3;\n")]
		public static int Sign(this float value)
		{
			float num = default(float);
			if (num == 0f)
			{
				return 0;
			}
			float a = Mathf.Abs(num);
			float num2 = Mathf.Max(a, 0f);
			float num3 = num2 * 1E-06f;
			float num4 = Mathf.Epsilon * 8f;
			bool flag = num3 < num4;
			bool flag2 = num3 == num4;
			bool flag3 = num3 == num3;
			bool flag4 = num4 == num4;
			bool flag5 = flag3 && flag4;
			bool flag6 = !flag5;
			bool flag7 = flag == flag6;
			bool flag8 = !flag2;
			if (!(flag7 && flag8))
			{
				num3 = num4;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
			if (0f < num3)
			{
				return 0;
			}
			bool flag9 = num < 0f;
			bool flag10 = num == 0f;
			bool flag11 = num == num;
			bool flag12 = !flag11;
			bool flag13 = flag9 == flag12;
			bool flag14 = !flag13;
			if (flag14 || flag10)
			{
				return -1;
			}
			return 1;
		}

		[Token(Token = "0x600008F")]
		[Address(RVA = "0x81AA404", Offset = "0x81AA404", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = value < 1;\n\tif (v12) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv15 = 1;\n\tgoto L_001A;\nL_FFFFFFFF:\n\tv15 = -1;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tgoto L_0020;\nL_FFFFFFFF:\n\treturnVal1 = v15;\nL_001A:\n\tv25 = value != 0;\n\tif (v25) goto L_FFFFFFFF;\nL_0020:\n\treturn returnVal1;\n")]
		public static int Sign(this int value)
		{
			int result = ((value >= 1) ? 1 : (-1));
			if (value == 0)
			{
				return 0;
			}
			return result;
		}

		[Token(Token = "0x6000090")]
		[Address(RVA = "0x81AA634", Offset = "0x81AA634", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = value < compare;\n\tv3 = value == compare;\n\tv6 = value == value;\n\tv7 = compare == compare;\n\tv8 = v6 & v7;\n\tv9 = ~v8;\n\tv12 = v0 == v9;\n\tv13 = ~v3;\n\tv14 = v12 & v13;\n\tv15 = ~v14;\n\tif (v15) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal1 = 1f;\n\tgoto L_0013;\nL_FFFFFFFF:\n\treturnVal1 = 0;\nL_0013:\n\treturn returnVal1;\n")]
		public static float Step(this float value, float compare)
		{
			bool flag = value < compare;
			bool flag2 = value == compare;
			bool flag3 = value == value;
			bool flag4 = compare == compare;
			bool flag5 = flag3 && flag4;
			bool flag6 = !flag5;
			bool flag7 = flag == flag6;
			bool flag8 = !flag2;
			if (flag7 && flag8)
			{
				return 1f;
			}
			return 0f;
		}

		[Token(Token = "0x6000091")]
		[Address(RVA = "0x81AA41C", Offset = "0x81AA41C", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = returnVal1 >= 0;\n\tif (v10) goto L_000F;\n\treturnVal1 = -returnVal1;\n\tgoto L_000F;\nL_000F:\n\treturn returnVal1;\n")]
		public static int Magnitude(this int value)
		{
			int num = default(int);
			if (num < 0)
			{
				return -num;
			}
			return num;
		}

		[Token(Token = "0x6000092")]
		[Address(RVA = "0x81AA3D0", Offset = "0x81AA3D0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = -returnVal1;\n\tv2 = returnVal1 < 0;\n\tv3 = returnVal1 == 0;\n\tv6 = returnVal1 == returnVal1;\n\tv7 = ~v6;\n\tv8 = v2 == v7;\n\tv9 = ~v3;\n\tv10 = v8 & v9;\n\tv11 = ~v10;\n\tif (v11) goto L_0010;\n\tgoto L_0010;\nL_0010:\n\treturn v0;\n")]
		public static float Magnitude(this float value)
		{
			float num = default(float);
			float result = 0f - num;
			bool flag = num < 0f;
			bool flag2 = num == 0f;
			bool flag3 = num == num;
			bool flag4 = !flag3;
			bool flag5 = flag == flag4;
			bool flag6 = !flag2;
			if (flag5 && flag6)
			{
			}
			return result;
		}

		[Token(Token = "0x6000093")]
		[Address(RVA = "0x81AA648", Offset = "0x81AA648", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = min == max;\n\tif (v3) goto L_002D;\n\tv10 = value - min;\n\tv12 = max - min;\n\tv13 = v10 / v12;\n\tv15 = v13 < 1f;\n\tv16 = v13 == 1f;\n\tv19 = v13 == v13;\n\tv20 = 1f == 1f;\n\tv21 = v19 & v20;\n\tv22 = ~v21;\n\tv23 = v15 == v22;\n\tv24 = ~v16;\n\tv25 = v23 & v24;\n\tv26 = ~v25;\n\tif (v26) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv38 = 1f;\n\tgoto L_001E;\nL_FFFFFFFF:\n\tv38 = v13;\nL_FFFFFFFF:\n\treturnVal2 = 0;\n\tgoto L_002B;\nL_FFFFFFFF:\n\treturnVal2 = v38;\nL_002D:\n\treturn 0;\nL_001E:\n\tv51 = v13 < 0;\n\tv31 = ~v51;\n\tif (v31) goto L_FFFFFFFF;\nL_002B:\n\treturn returnVal2;\n")]
		public static float InverseLerp(this float value, float min, float max)
		{
			if (min != max)
			{
				float num = value - min;
				float num2 = max - min;
				float num3 = num / num2;
				bool flag = num3 < 1f;
				bool flag2 = num3 == 1f;
				bool flag3 = num3 == num3;
				bool flag4 = 1f == 1f;
				bool flag5 = flag3 && flag4;
				bool flag6 = !flag5;
				bool flag7 = flag == flag6;
				bool flag8 = !flag2;
				float result = ((!(flag7 && flag8)) ? num3 : 1f);
				if (num3 < 0f)
				{
					return 0f;
				}
				return result;
			}
			return 0f;
		}

		[Token(Token = "0x6000094")]
		[Address(RVA = "0x81AA680", Offset = "0x81AA680", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001F:\n\tv53 = value / mod;\n\tv54 = UnityEngine.Mathf::Abs(v53);\n\tv55 = UnityEngine.Mathf::Ceil(v54);\n\tv60 = v55 == 0x7F800000;\n\tv68 = ~v60;\n\tif (v68) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv71 = 0xFFFFFFFF80000000;\n\tgoto L_0034;\nL_FFFFFFFF:\n\tv71 = v54;\nL_001B:\n\tgoto L_001F;\nL_0034:\n\tv72 = v71 * mod;\n\tv73 = value + v72;\n\tv74 = v73 / mod;\n\tv75 = v74 * mod;\n\treturnVal1 = v73 - v75;\n\treturn returnVal1;\n")]
		public static int ModuloLooped(this int value, int mod)
		{
			//IL_00cc: Expected I4, but got F4
			float f = (float)value / (float)mod;
			float num = Mathf.Abs(f);
			float num2 = Mathf.Ceil(num);
			float num3 = ((num2 != 1f / 0f) ? num : -0f);
			float num4 = num3 * (float)mod;
			float num5 = (float)value + num4;
			float num6 = num5 / (float)mod;
			float num7 = num6 * (float)mod;
			return (int)(num5 - num7);
		}

		[Token(Token = "0x6000095")]
		[Address(RVA = "0x81AA718", Offset = "0x81AA718", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = value - a;\n\tv3 = b - a;\n\tv5 = v0 / v3;\n\tv6 = d - c;\n\tv9 = v5 * v6;\n\treturnVal1 = v9 + c;\n\treturn returnVal1;\n")]
		public static float Map(this float value, float a, float b, float c, float d)
		{
			float num = value - a;
			float num2 = b - a;
			float num3 = num / num2;
			float num4 = d - c;
			float num5 = num3 * num4;
			return num5 + c;
		}

		[Token(Token = "0x6000096")]
		[Address(RVA = "0x81AA734", Offset = "0x81AA734", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = returnVal1 + 0xFFFFFFFFC3B40000;\n\tv6 = returnVal1 < 0x43340000;\n\tv7 = returnVal1 == 0x43340000;\n\tv10 = returnVal1 == returnVal1;\n\tv13 = ~v10;\n\tv14 = v6 == v13;\n\tv15 = ~v7;\n\tv16 = v14 & v15;\n\tv17 = ~v16;\n\tif (v17) goto L_0016;\n\tgoto L_0016;\nL_0016:\n\treturn v2;\n")]
		public static float ToSignedAngle(this float angle)
		{
			float num = default(float);
			float result = num + -360f;
			bool flag = num < 180f;
			bool flag2 = num == 180f;
			bool flag3 = num == num;
			bool flag4 = !flag3;
			bool flag5 = flag == flag4;
			bool flag6 = !flag2;
			if (flag5 && flag6)
			{
			}
			return result;
		}
	}
}
