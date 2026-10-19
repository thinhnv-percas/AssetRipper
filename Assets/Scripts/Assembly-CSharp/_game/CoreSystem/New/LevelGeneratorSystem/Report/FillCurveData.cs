using System;
using System.Globalization;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Report
{
	[Serializable]
	[Token(Token = "0x200032E")]
	public class FillCurveData
	{
		[Token(Token = "0x400095C")]
		[FieldOffset(Offset = "0x10")]
		public float[] designed;

		[Token(Token = "0x400095D")]
		[FieldOffset(Offset = "0x18")]
		public float[] headless;

		[Token(Token = "0x400095E")]
		[FieldOffset(Offset = "0x20")]
		public float[] intended;

		[Token(Token = "0x400095F")]
		[FieldOffset(Offset = "0x28")]
		public float[] player;

		[Token(Token = "0x6000D94")]
		[Address(RVA = "0x3EF2D6C", Offset = "0x3EF2D6C", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv83 = System.Text.StringBuilder::Append(v54, 0x2C);\n\t_game.CoreSystem.New.LevelGeneratorSystem.Report.FillCurveData::Series(v54, \"headless\", this.headless);\n\tv104 = System.Text.StringBuilder::Append(v54, 0x2C);\n\t_game.CoreSystem.New.LevelGeneratorSystem.Report.FillCurveData::Series(v54, \"intended\", this.intended);\n\tv135 = System.Text.StringBuilder::Append(v54, 0x2C);\n\t_game.CoreSystem.New.LevelGeneratorSystem.Report.FillCurveData::Series(v54, \"player\", this.player);\n\tv89 = System.Text.StringBuilder::Append(v54, 0x7D);\n\tv89 = System.Text.StringBuilder::ToString(v89);\n\treturn v89;\nL_002C:\n\tv54 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v54, \"{\");\n\t_game.CoreSystem.New.LevelGeneratorSystem.Report.FillCurveData::Series(v54, \"designed\", this.designed);\n")]
		public string ToJson()
		{
			StringBuilder stringBuilder = new StringBuilder("{");
			Series(stringBuilder, "designed", designed);
			StringBuilder stringBuilder2 = stringBuilder.Append(',');
			Series(stringBuilder, "headless", headless);
			StringBuilder stringBuilder3 = stringBuilder.Append(',');
			Series(stringBuilder, "intended", intended);
			StringBuilder stringBuilder4 = stringBuilder.Append(',');
			Series(stringBuilder, "player", player);
			StringBuilder stringBuilder5 = stringBuilder.Append('}');
			return stringBuilder5.ToString();
		}

		[Token(Token = "0x6000D95")]
		[Address(RVA = "0x3EF2ED0", Offset = "0x3EF2ED0", Length = "0x1A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv56 = System.Text.StringBuilder::Append(sb, 0x22);\n\tv98 = System.Text.StringBuilder::Append(v56, key);\n\tv162 = System.Text.StringBuilder::Append(v98, \"\\\":[\");\n\tv163 = values == 0;\n\tif (v163) goto L_00A1;\n\tv175 = values.Length < 1;\n\tif (v175) goto L_00A1;\n\tgoto L_0048;\nL_0048:\n\tv225 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv230 = values + 0x20;\n\tv231 = System.Single::ToString(v230, \"0.###\", v225);\n\tv208 = System.Text.StringBuilder::Append(sb, v231);\n\tv183 = values.Length < 2;\n\tif (v183) goto L_00A1;\n\tv248 = values + 0x24;\n\tv232 = 1;\nL_0071:\n\tv246 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv279 = System.Single::ToString(v248, \"0.###\", v246);\n\tv207 = System.Text.StringBuilder::Append(sb, v279);\n\tv232 = v232 + 1;\n\tv248 = v248 + 4;\n\tv182 = v232 < values.Length;\n\tif (v182) goto L_0069;\nL_00A1:\n\tv143 = System.Text.StringBuilder::Append(sb, 0x5D);\n\treturn;\nL_0069:\n\tv268 = System.Text.StringBuilder::Append(sb, 0x2C);\n\tgoto L_0071;\n")]
		private unsafe static void Series(StringBuilder sb, string key, float[] values)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FillCurveData::Series");
		}

		[Token(Token = "0x6000D96")]
		[Address(RVA = "0x3EF3070", Offset = "0x3EF3070", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_002B:\n\treturnVal1 = UnityEngine.JsonUtility::FromJson(json);\n\tv54 = returnVal1 == 0;\n\tif (v54) goto L_0035;\nL_0033:\n\treturn returnVal1;\nL_0035:\n\treturnVal1 = new _game.CoreSystem.New.LevelGeneratorSystem.Report.FillCurveData();\n\t_game.CoreSystem.New.LevelGeneratorSystem.Report.FillCurveData::.ctor(returnVal1);\n\tgoto L_0033;\nL_0019:\n\tv43 = System.String::IsNullOrEmpty(json);\n\tv46 = ~v43;\n\tif (v46) goto L_002B;\n\tv53 = new _game.CoreSystem.New.LevelGeneratorSystem.Report.FillCurveData();\n\t_game.CoreSystem.New.LevelGeneratorSystem.Report.FillCurveData::.ctor(v53);\n\treturn v53;\n")]
		public static FillCurveData FromJson(string json)
		{
			if (!string.IsNullOrEmpty(json))
			{
				FillCurveData fillCurveData = JsonUtility.FromJson<FillCurveData>(json);
				if (fillCurveData == null)
				{
					fillCurveData = new FillCurveData();
				}
				return fillCurveData;
			}
			return new FillCurveData();
		}

		[Token(Token = "0x6000D97")]
		[Address(RVA = "0x3EF3454", Offset = "0x3EF3454", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_FFFFFFFF:\n\tv71 = capUnits;\n\tgoto L_0031;\nL_FFFFFFFF:\n\tv71 = 1f;\n\tv73.designed = v77;\n\tv86 = _game.CoreSystem.New.LevelGeneratorSystem.Report.FillCurveData::PercentOf(achievedUnits, v71);\n\tv73.headless = v86;\n\treturn v73;\nL_0020:\n\tv58 = capUnits < 0;\n\tv59 = capUnits == 0;\n\tv61 = capUnits ^ capUnits;\n\tv62 = capUnits & v61;\n\tv63 = v62 < 0;\n\tv65 = v58 == v63;\n\tv66 = ~v59;\n\tv67 = v65 & v66;\n\tv68 = ~v67;\n\tif (v68) goto L_FFFFFFFF;\nL_0031:\n\tv73 = new _game.CoreSystem.New.LevelGeneratorSystem.Report.FillCurveData();\n\t_game.CoreSystem.New.LevelGeneratorSystem.Report.FillCurveData::.ctor(v73);\n\tv77 = _game.CoreSystem.New.LevelGeneratorSystem.Report.FillCurveData::PercentOf(designedUnits, v71);\n")]
		public static FillCurveData FromMoldUnits(int[] designedUnits, int[] achievedUnits, int capUnits)
		{
			bool flag = capUnits < 0;
			bool flag2 = capUnits == 0;
			int num = capUnits ^ capUnits;
			int num2 = capUnits & num;
			bool flag3 = num2 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			float cap = ((!(flag4 && flag5)) ? 1f : ((float)capUnits));
			FillCurveData fillCurveData = new FillCurveData();
			float[] array = PercentOf(designedUnits, cap);
			fillCurveData.designed = array;
			float[] array2 = PercentOf(achievedUnits, cap);
			fillCurveData.headless = array2;
			return fillCurveData;
		}

		[Token(Token = "0x6000D98")]
		[Address(RVA = "0x3EF3704", Offset = "0x3EF3704", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv46.designed = v49;\n\tv57 = _game.CoreSystem.New.LevelGeneratorSystem.Report.FillCurveData::PercentOf(achieved);\n\tv46.headless = v57;\n\treturn v46;\nL_0018:\n\tv46 = new _game.CoreSystem.New.LevelGeneratorSystem.Report.FillCurveData();\n\t_game.CoreSystem.New.LevelGeneratorSystem.Report.FillCurveData::.ctor(v46);\n\tv49 = _game.CoreSystem.New.LevelGeneratorSystem.Report.FillCurveData::PercentOf(designed);\n")]
		public static FillCurveData FromFractions(float[] designed, float[] achieved)
		{
			FillCurveData fillCurveData = new FillCurveData();
			float[] array = PercentOf(designed);
			fillCurveData.designed = array;
			float[] array2 = PercentOf(achieved);
			fillCurveData.headless = array2;
			return fillCurveData;
		}

		[Token(Token = "0x6000D99")]
		[Address(RVA = "0x3EF3960", Offset = "0x3EF3960", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\treturnVal1 = _game.CoreSystem.New.LevelGeneratorSystem.Report.FillCurveData::PercentOf(v41, particleCapacity);\n\treturn returnVal1;\nL_0033:\n\tgoto L_0034;\nL_0034:\n\tv71 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tv74 = *([v71 @ X0_v18 (Il2CppClass<System.EmptyArray`1<System.Single>>)+135]) & 1;\n\tv75 = v74 == 0;\n\tv114 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tif (v75) goto L_0058;\nL_003C:\n\tgoto L_003E;\nL_003E:\n\tv128 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tv131 = *([v128 @ X0_v16 (Il2CppClass<System.EmptyArray`1<System.Single>>)+135]) & 1;\n\tv132 = v131 == 0;\n\tv143 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tif (v132) goto L_0066;\nL_004D:\n\treturn v95.Value;\n\tv77 = 0x220C2B8(Il2CppMethodInfo, particleCapacity, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv107 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tv120 = *([v107 @ X0_v12 (Il2CppClass<System.EmptyArray`1<System.Single>>)+135]) & 1;\n\tv121 = v120 == 0;\n\tv109 = ~v121;\n\tv114 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tif (v109) goto L_003C;\nL_0058:\n\tv117 = 0x220C238(v114, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv137 = *([v117 @ X0_v9+E4]) == 0;\n\tv124 = ~v137;\n\tif (v124) goto L_003E;\n\tv139 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tv148 = *([v139 @ X0_v7 (Il2CppClass<System.EmptyArray`1<System.Single>>)+135]) & 1;\n\tv149 = v148 == 0;\n\tv140 = ~v149;\n\tv143 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tif (v140) goto L_004D;\nL_0066:\n\tv145 = 0x220C238(v143, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv96 = *([v145 @ X0_v3+B8]);\n\treturn *([v96 @ X8_v7]);\nL_0022:\n\tv57 = particleCapacity <= 0;\n\tif (v57) goto L_0033;\n")]
		public static float[] PlayedPercent(int[] occupancy, int particleCapacity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FillCurveData::PlayedPercent");
			return default;
		}

		[Token(Token = "0x6000D9A")]
		[Address(RVA = "0x3EF351C", Offset = "0x3EF351C", Length = "0x1E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\t// 28 NewArr returnVal1 @ X0_v19 (System.Single[]), typeof(System.Single[]), values.Length\n\tv64 = values.Length < 1;\n\tif (v64) goto L_00B8;\n\tv144 = values.Length & 0x7FFFFFFF;\n\tv270 = v144 - 1;\n\tv146 = v270 < returnVal1.Length;\n\tv147 = ~v146;\n\tv155 = ~v147;\n\tv156 = ~v155;\n\tif (v156) goto L_FFFFFFFF;\n\tgoto L_0040;\nL_FFFFFFFF:\n\tv270 = returnVal1.Length;\nL_FFFFFFFF:\n\tv295 = 0;\n\tgoto L_0099;\nL_0051:\n\tgoto L_0052;\nL_0052:\n\tv65 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tv68 = *([v65 @ X0_v17 (Il2CppClass<System.EmptyArray`1<System.Single>>)+135]) & 1;\n\tv69 = v68 == 0;\nL_FFFFFFFF:\n\tv135 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tif (v69) goto L_00C3;\nL_005A:\n\tgoto L_0062;\nL_0062:\n\tgoto L_006B;\nL_006B:\n\treturn v232.Value;\nL_006C:\n\tv281 = v270 + 1;\n\tv322 = v281 & 7;\n\tv284 = v322 == 0;\n\tv288 = ~v284;\n\tif (v288) goto L_0079;\nL_FFFFFFFF:\n\tv322 = 8;\n\tgoto L_0079;\nL_0099:\n\tv316 = v295 << 2;\n\tv166 = v316 + 0x20;\n\tv193 = v144 - v295;\nL_00A1:\n\tv329 = *([values @ X0 (System.Int32[])+v166 @ X11_v6 (System.Int32)]) / cap;\n\tv84 = v329 * 0x42C80000;\n\t*([returnVal1 @ X0_v19 (System.Single[])+v166 @ X11_v6 (System.Int32)]) = v84;\n\tv166 = v166 + 4;\n\tv122 = v193 - 1;\n\tv102 = v193 != 1;\nL_FFFFFFFF:\n\tv193 = v122;\n\tif (v102) goto L_00A1;\nL_00B8:\n\treturn returnVal1;\n\tv71 = 0x220C2B8(Il2CppMethodInfo, methodInfo, v23, v24, v25, v26, v27, v28, cap, v29, v30, v31, v32, v33, v34, v35);\n\tv128 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tv141 = *([v128 @ X0_v9 (Il2CppClass<System.EmptyArray`1<System.Single>>)+135]) & 1;\n\tv142 = v141 == 0;\n\tv130 = ~v142;\nL_FFFFFFFF:\n\tv135 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tif (v130) goto L_005A;\nL_00C3:\n\tv138 = 0x220C238(v135, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv255 = *([v138 @ X0_v6+E4]) == 0;\n\tv241 = ~v255;\n\tif (v241) goto L_0062;\n\tgoto L_00D0;\nL_00D0:\n\tgoto L_006B;\nL_0016:\n\tv40 = values == 0;\n\tif (v40) goto L_0051;\nL_0040:\n\tv271 = v270 < 8;\n\tv272 = ~v271;\n\tif (v272) goto L_006C;\nL_0079:\n\tv295 = v281 - v322;\n\t// 122 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv335 = values + 0x30;\n\tv334 = returnVal1 + 0x30;\n\t// 126 NotImplemented \"Instruction DUP not yet implemented.\"\nL_FFFFFFFF:\n\tv333 = v295;\nL_FFFFFFFF:\n\tv333 = v80;\nL_FFFFFFFF:\n\tv334 = v87;\nL_FFFFFFFF:\n\tv335 = v90;\nL_0082:\n\t// 130 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 131 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv347 = *([v335 @ X11_v11-10]) / cap;\n\tv348 = *([v335 @ X11_v11]) / cap;\n\tv290 = v347 * v29;\n\tv289 = v348 * v29;\n\t*([v334 @ X12_v6-10]) = v290;\n\t*([v334 @ X12_v6]) = v289;\n\tv335 = v335 + 0x20;\n\tv334 = v334 + 0x20;\n\tv291 = v333 - 8;\n\tv298 = v333 != 8;\nL_FFFFFFFF:\n\tv333 = v291;\n\tif (v298) goto L_0082;\n")]
		private static float[] PercentOf(int[] values, float cap)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FillCurveData::PercentOf");
			return default;
		}

		[Token(Token = "0x6000D9B")]
		[Address(RVA = "0x3EF37A0", Offset = "0x3EF37A0", Length = "0x1C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\t// 27 NewArr returnVal1 @ X0_v19 (System.Single[]), typeof(System.Single[]), fractions.Length\n\tv63 = fractions.Length < 1;\n\tif (v63) goto L_009B;\n\tv140 = fractions.Length & 0x7FFFFFFF;\n\tv263 = v140 - 1;\n\tv142 = v263 < returnVal1.Length;\n\tv143 = ~v142;\n\tv151 = ~v143;\n\tv152 = ~v151;\n\tif (v152) goto L_FFFFFFFF;\n\tgoto L_003F;\nL_FFFFFFFF:\n\tv263 = returnVal1.Length;\n\tv274 = returnVal1 - fractions;\n\tv275 = v274 < 0x20;\n\tv276 = ~v275;\n\tv284 = ~v276;\nL_FFFFFFFF:\n\tv293 = 0;\n\tif (v284) goto L_007E;\n\tv317 = v263 + 1;\n\tv329 = v317 & 7;\n\tv320 = v329 == 0;\n\tv290 = ~v320;\n\tif (v290) goto L_0063;\nL_FFFFFFFF:\n\tv329 = 8;\n\tgoto L_0063;\nL_007E:\n\tv314 = v293 << 2;\n\tv162 = v314 + 0x20;\n\tv188 = v140 - v293;\nL_0086:\n\tv80 = *([fractions @ X0 (System.Single[])+v162 @ X11_v8 (System.Int32)]) * 0x42C80000;\n\t*([returnVal1 @ X0_v19 (System.Single[])+v162 @ X11_v8 (System.Int32)]) = v80;\n\tv162 = v162 + 4;\n\tv117 = v188 - 1;\n\tv97 = v188 != 1;\nL_FFFFFFFF:\n\tv188 = v117;\n\tif (v97) goto L_0086;\nL_009B:\n\treturn returnVal1;\nL_00A1:\n\tgoto L_00A2;\nL_00A2:\n\tv64 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tv67 = *([v64 @ X0_v17 (Il2CppClass<System.EmptyArray`1<System.Single>>)+135]) & 1;\n\tv68 = v67 == 0;\nL_FFFFFFFF:\n\tv130 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tif (v68) goto L_00C6;\nL_00AA:\n\tgoto L_00B2;\nL_00B2:\n\tgoto L_00BB;\nL_00BB:\n\treturn v225.Value;\n\tv70 = 0x220C2B8(Il2CppMethodInfo, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv123 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tv136 = *([v123 @ X0_v9 (Il2CppClass<System.EmptyArray`1<System.Single>>)+135]) & 1;\n\tv137 = v136 == 0;\n\tv125 = ~v137;\nL_FFFFFFFF:\n\tv130 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tif (v125) goto L_00AA;\nL_00C6:\n\tv133 = 0x220C238(v130, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv248 = *([v133 @ X0_v6+E4]) == 0;\n\tv234 = ~v248;\n\tif (v234) goto L_00B2;\n\tgoto L_00D3;\nL_00D3:\n\tgoto L_00BB;\nL_0015:\n\tv39 = fractions == 0;\n\tif (v39) goto L_00A1;\nL_003F:\n\tv264 = v263 < 8;\n\tv265 = ~v264;\n\tv273 = ~v265;\nL_FFFFFFFF:\n\tv293 = 0;\n\tif (v273) goto L_007E;\nL_0063:\n\tv293 = v317 - v329;\n\tv338 = fractions + 0x30;\n\tv337 = returnVal1 + 0x30;\n\t// 103 NotImplemented \"Instruction DUP not yet implemented.\"\nL_FFFFFFFF:\n\tv335 = v293;\nL_FFFFFFFF:\n\tv335 = v76;\nL_FFFFFFFF:\n\tv337 = v83;\nL_FFFFFFFF:\n\tv338 = v89;\nL_006B:\n\tv288 = *([v338 @ X11_v13-10]) * v27;\n\tv285 = *([v338 @ X11_v13]) * v27;\n\t*([v337 @ X12_v7-10]) = v288;\n\t*([v337 @ X12_v7]) = v285;\n\tv338 = v338 + 0x20;\n\tv337 = v337 + 0x20;\n\tv286 = v335 - 8;\n\tv296 = v335 != 8;\nL_FFFFFFFF:\n\tv335 = v286;\n\tif (v296) goto L_006B;\n")]
		private static float[] PercentOf(float[] fractions)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FillCurveData::PercentOf");
			return default;
		}

		[Token(Token = "0x6000D9C")]
		[Address(RVA = "0x3EF31A4", Offset = "0x3EF31A4", Length = "0x2B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = 0xB78E000;\n\tv20 = *([B78E96E]) & 1;\n\tv21 = v20 == 0;\n\tif (v21) goto L_008F;\n\tgoto L_0014;\nL_0014:\n\tv50 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tv53 = *([v50 @ X0_v78 (Il2CppClass<System.EmptyArray`1<System.Single>>)+135]) & 1;\n\tv54 = v53 == 0;\n\tv72 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tif (v54) goto L_009F;\nL_001C:\n\tgoto L_0024;\nL_0024:\n\tgoto L_002A;\nL_002A:\n\tthis.designed = v112.Value;\n\tgoto L_0030;\nL_0030:\n\tv123 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tv126 = *([v123 @ X0_v71 (Il2CppClass<System.EmptyArray`1<System.Single>>)+135]) & 1;\n\tv127 = v126 == 0;\n\tv138 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tif (v127) goto L_00B7;\nL_0038:\n\tgoto L_0040;\nL_0040:\n\tgoto L_0046;\nL_0046:\n\tthis.headless = v173.Value;\n\tgoto L_004C;\nL_004C:\n\tv184 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tv187 = *([v184 @ X0_v65 (Il2CppClass<System.EmptyArray`1<System.Single>>)+135]) & 1;\n\tv188 = v187 == 0;\n\tv199 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tif (v188) goto L_00CF;\nL_0054:\n\tgoto L_005C;\nL_005C:\n\tgoto L_0062;\nL_0062:\n\tthis.intended = v234.Value;\n\tgoto L_0068;\nL_0068:\n\tv245 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tv248 = *([v245 @ X0_v59 (Il2CppClass<System.EmptyArray`1<System.Single>>)+135]) & 1;\n\tv249 = v248 == 0;\n\tv260 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tif (v249) goto L_00E7;\nL_0070:\n\tgoto L_0078;\nL_0078:\n\tgoto L_007E;\nL_007E:\n\tthis.player = v295.Value;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_008F:\n\t*([v16 @ X20_v1+96E]) = 1;\n\tgoto L_0014;\n\tv60 = System.Array::Empty();\n\tv64 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tv79 = *([v64 @ X0_v9 (Il2CppClass<System.EmptyArray`1<System.Single>>)+135]) & 1;\n\tv80 = v79 == 0;\n\tv66 = ~v80;\n\tv72 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tif (v66) goto L_001C;\nL_009F:\n\tv76 = 0x220C238(v72, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv99 = *([v76 @ X0_v5+E4]) == 0;\n\tv83 = ~v99;\n\tif (v83) goto L_0024;\n\tgoto L_00AC;\nL_00AC:\n\tgoto L_002A;\n\tv129 = System.Array::Empty();\n\tv131 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tv144 = *([v131 @ X0_v24 (Il2CppClass<System.EmptyArray`1<System.Single>>)+135]) & 1;\n\tv145 = v144 == 0;\n\tv133 = ~v145;\n\tv138 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tif (v133) goto L_0038;\nL_00B7:\n\tv141 = 0x220C238(v138, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv162 = *([v141 @ X0_v21+E4]) == 0;\n\tv148 = ~v162;\n\tif (v148) goto L_0040;\n\tgoto L_00C4;\nL_00C4:\n\tgoto L_0046;\n\tv190 = System.Array::Empty();\n\tv192 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tv205 = *([v192 @ X0_v36 (Il2CppClass<System.EmptyArray`1<System.Single>>)+135]) & 1;\n\tv206 = v205 == 0;\n\tv194 = ~v206;\n\tv199 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tif (v194) goto L_0054;\nL_00CF:\n\tv202 = 0x220C238(v199, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv223 = *([v202 @ X0_v33+E4]) == 0;\n\tv209 = ~v223;\n\tif (v209) goto L_005C;\n\tgoto L_00DC;\nL_00DC:\n\tgoto L_0062;\n\tv251 = System.Array::Empty();\n\tv253 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tv266 = *([v253 @ X0_v48 (Il2CppClass<System.EmptyArray`1<System.Single>>)+135]) & 1;\n\tv267 = v266 == 0;\n\tv255 = ~v267;\n\tv260 = Il2CppClass<System.EmptyArray`1<System.Single>>;\n\tif (v255) goto L_0070;\nL_00E7:\n\tv263 = 0x220C238(v260, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv284 = *([v263 @ X0_v45+E4]) == 0;\n\tv270 = ~v284;\n\tif (v270) goto L_0078;\n\tgoto L_00F4;\nL_00F4:\n\tgoto L_007E;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FillCurveData()
		{
			object obj = 192471040;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78E96E]");
			if ((int)((nint)0 & (nint)1) == 0)
			{
				_ = 1;
			}
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X0_v78 (Il2CppClass<System.EmptyArray`1<System.Single>>)+135]");
			int num2 = (int)((nint)0 & (nint)1);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (flag)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ X0_v5+E4]");
				if ((nint)0 != 0)
				{
				}
			}
			designed = Array.Empty<float>();
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ X0_v71 (Il2CppClass<System.EmptyArray`1<System.Single>>)+135]");
			int num5 = (int)((nint)0 & (nint)1);
			bool flag2 = num5 == 0;
			nint num6 = 0;
			if (flag2)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ X0_v21+E4]");
				if ((nint)0 != 0)
				{
				}
			}
			headless = Array.Empty<float>();
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ X0_v65 (Il2CppClass<System.EmptyArray`1<System.Single>>)+135]");
			int num8 = (int)((nint)0 & (nint)1);
			bool flag3 = num8 == 0;
			nint num9 = 0;
			if (flag3)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ X0_v33+E4]");
				if ((nint)0 != 0)
				{
				}
			}
			intended = Array.Empty<float>();
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ X0_v59 (Il2CppClass<System.EmptyArray`1<System.Single>>)+135]");
			int num11 = (int)((nint)0 & (nint)1);
			bool flag4 = num11 == 0;
			nint num12 = 0;
			if (flag4)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ X0_v45+E4]");
				if ((nint)0 != 0)
				{
				}
			}
			player = Array.Empty<float>();
		}
	}
}
