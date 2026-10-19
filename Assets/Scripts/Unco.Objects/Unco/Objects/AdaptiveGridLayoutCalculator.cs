using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.Objects
{
	[Token(Token = "0x2000026")]
	public static class AdaptiveGridLayoutCalculator
	{
		[Token(Token = "0x2000027")]
		public struct CellRect
		{
			[Token(Token = "0x4000095")]
			[FieldOffset(Offset = "0x0")]
			public Vector2 TopLeft;

			[Token(Token = "0x4000096")]
			[FieldOffset(Offset = "0x8")]
			public Vector2 Size;
		}

		[Token(Token = "0x60000AD")]
		[Address(RVA = "0x81C4808", Offset = "0x81C4808", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv31 = count < 1;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tif (v31) goto L_00A2;\n\tv34 = width == 0;\n\tv35 = width < 0;\n\tv36 = ~v35;\n\tv39 = ~v36;\n\tv40 = v39 | v34;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tif (v40) goto L_00A2;\n\tv85 = height == 0;\n\tv107 = height < 0;\n\tv94 = ~v107;\n\tv108 = ~v94;\n\tv73 = v108 | v85;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tif (v73) goto L_00A2;\n\tv110 = count * width;\n\tv111 = v110 / height;\n\tgoto L_003D;\nL_0042:\n\tv66 = UnityEngine.Mathf::Ceil(v64);\n\tv142 = v64 - 1;\n\tv143 = v142 < 0;\n\tv144 = v142 == 0;\n\tv145 = v64 ^ 1;\n\tv146 = v64 ^ v142;\n\tv147 = v145 & v146;\n\tv148 = v147 < 0;\n\tv149 = v143 == v148;\n\tv150 = ~v144;\n\tv151 = v149 & v150;\n\tv152 = ~v151;\n\tif (v152) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv169 = v64;\n\tgoto L_0059;\nL_FFFFFFFF:\n\tv169 = 1;\n\tgoto L_0067;\nL_FFFFFFFF:\n\tv169 = 1;\nL_FFFFFFFF:\n\tv60 = v169;\n\tgoto L_0077;\nL_FFFFFFFF:\n\tv60 = count;\nL_FFFFFFFF:\n\tv46 = v60;\n\tgoto L_008A;\nL_FFFFFFFF:\n\tv46 = maxColumns;\nL_FFFFFFFF:\n\treturnVal1 = v46;\n\tgoto L_00A2;\nL_FFFFFFFF:\n\treturnVal1 = v60;\nL_00A2:\n\treturn returnVal1;\nL_003D:\n\tv64 = UnityEngine.Mathf::Sqrt(v111);\n\tgoto L_0042;\nL_0059:\n\tv158 = v66 == 0x7F800000;\n\tv165 = ~v158;\n\tv166 = ~v165;\n\tif (v166) goto L_FFFFFFFF;\nL_0067:\n\tv170 = v169 < count;\n\tv171 = ~v170;\n\tv179 = ~v171;\n\tv180 = ~v179;\n\tif (v180) goto L_FFFFFFFF;\nL_0077:\n\tv183 = v60 < maxColumns;\n\tv184 = ~v183;\n\tv192 = ~v184;\n\tv193 = ~v192;\n\tif (v193) goto L_FFFFFFFF;\nL_008A:\n\tv89 = maxColumns < 0;\n\tv86 = maxColumns == 0;\n\tv81 = maxColumns ^ maxColumns;\n\tv79 = maxColumns & v81;\n\tv77 = v79 < 0;\n\tv197 = v89 == v77;\n\tv52 = ~v86;\n\tv74 = v197 & v52;\n\tv49 = ~v74;\n\tif (v49) goto L_FFFFFFFF;\n")]
		public static int CalculateColumns(int count, float width, float height, int maxColumns = 0)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AdaptiveGridLayoutCalculator::CalculateColumns");
			return default;
		}

		[Token(Token = "0x60000AE")]
		[Address(RVA = "0x81C447C", Offset = "0x81C447C", Length = "0x25C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv49 = count < 1;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tif (v49) goto L_0140;\n\tv52 = width == 0;\n\tv53 = width < 0;\n\tv54 = ~v53;\n\tv57 = ~v54;\n\tv58 = v57 | v52;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tif (v58) goto L_0140;\n\tv214 = height == 0;\n\tv215 = height < 0;\n\tv216 = ~v215;\n\tv219 = ~v214;\n\tv157 = v216 & v219;\n\tv153 = ~v157;\n\tif (v153) goto L_FFFFFFFF;\n\tv177 = buffer == 0;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv177 = 1;\n\tv156 = buffer.Length >= count;\n\tif (v156) goto L_005B;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tgoto L_0140;\nL_005B:\n\tv307 = Unco.Objects.AdaptiveGridLayoutCalculator::CalculateColumns(count, width, height, maxColumns);\n\tv309 = count / v307;\n\tv311 = 0x81C48D4(0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v309, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv320 = padding == 0;\nL_FFFFFFFF:\n\tv113 = 0;\nL_FFFFFFFF:\n\tv115 = 0;\nL_FFFFFFFF:\n\tv117 = 0;\nL_FFFFFFFF:\n\tv327 = 0;\nL_FFFFFFFF:\n\tv329 = 0;\n\tif (v320) goto L_007D;\n\tv323 = UnityEngine.RectOffset::get_left(padding);\n\tv354 = UnityEngine.RectOffset::get_right(padding);\n\tv359 = UnityEngine.RectOffset::get_top(padding);\n\tv333 = UnityEngine.RectOffset::get_bottom(padding);\nL_FFFFFFFF:\n\tv113 = v354;\nL_FFFFFFFF:\n\tv115 = v323;\nL_FFFFFFFF:\n\tv117 = v359;\nL_FFFFFFFF:\n\tv327 = 0;\nL_FFFFFFFF:\n\tv329 = v333;\nL_FFFFFFFF:\n\tv107 = v327;\n\tgoto L_0095;\nL_FFFFFFFF:\n\tv105 = v327;\n\tgoto L_00A5;\nL_FFFFFFFF:\n\tv102 = v327;\n\tgoto L_00C1;\n\tv421 = v307 - v78;\n\tv437 = v421 < 0;\n\tv436 = v421 == 0;\n\tv424 = v307 ^ v78;\n\tv425 = v307 ^ v421;\n\tv426 = v424 & v425;\n\tv432 = v426 < 0;\n\tgoto L_00DF;\nL_FFFFFFFF:\n\tv432 = 0;\nL_FFFFFFFF:\n\tv436 = 1;\nL_FFFFFFFF:\n\tv437 = 0;\nL_FFFFFFFF:\n\tv99 = v107;\nL_00EE:\n\tv110 = v60 * v307;\n\tv96 = v231 - v110;\n\tv492 = v72 * v60;\n\tv93 = v117 + v492;\n\tv493 = v115 + v250;\n\tv494 = spacing + v99;\n\tv90 = v494 * v96;\n\tv119 = v493 + v90;\n\t*([v229 @ X13_v3-C]) = v119;\n\t*([v229 @ X13_v3-8]) = v93;\n\t*([v229 @ X13_v3-4]) = v99;\n\t*([v229 @ X13_v3]) = v105;\n\tv231 = v231 + 1;\n\tv229 = v229 + 0x10;\n\tv155 = count != v231;\n\tif (v155) goto L_00C3;\n\tgoto L_FFFFFFFF;\nL_010E:\n\tv458 = lastRowAlignment == 1;\nL_FFFFFFFF:\n\tv250 = 0;\n\tif (v458) goto L_FFFFFFFF;\n\tv482 = lastRowAlignment == 3;\n\tif (v482) goto L_FFFFFFFF;\n\tv459 = lastRowAlignment == 2;\nL_FFFFFFFF:\n\tv99 = v107;\nL_FFFFFFFF:\n\tv250 = v196;\n\tif (v459) goto L_00EE;\nL_FFFFFFFF:\n\tv250 = v69;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv99 = v102;\nL_FFFFFFFF:\n\tv250 = 0;\n\tgoto L_00EE;\nL_FFFFFFFF:\n\treturnVal1 = 1;\nL_0140:\n\treturn returnVal1;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tif (v177) goto L_0140;\nL_007D:\n\tv335 = width - v115;\n\tv336 = v335 - v113;\n\tv337 = height - v117;\n\tv338 = v337 - v329;\n\tv339 = v307 - 1;\n\tv341 = spacing * v339;\n\tv342 = v336 - v341;\n\tv107 = v342 / v307;\n\tv344 = v107 < 0;\n\tv147 = v311 - 1;\n\tv351 = ~v344;\n\tif (v351) goto L_0095;\nL_0095:\n\tv360 = spacing.y * v147;\n\tv361 = v338 - v360;\n\tv105 = v361 / v311;\n\tv364 = v105 < 0;\n\tv370 = ~v364;\n\tif (v370) goto L_00A5;\nL_00A5:\n\tv374 = v147 * v307;\n\tv78 = count - v374;\n\tv375 = v307 - v78;\n\tv377 = spacing + v107;\n\tv196 = v377 * v375;\n\tv378 = v78 - 1;\n\tv72 = spacing.y + v105;\n\tv380 = spacing * v378;\n\tv381 = v336 - v380;\n\tv102 = v381 / v78;\n\tv384 = v102 < 0;\n\tv390 = ~v384;\n\tif (v390) goto L_00C1;\nL_00C1:\n\tv69 = v196 * 0.5f;\n\tv229 = buffer + 0x2C;\nL_FFFFFFFF:\n\tv231 = 0;\nL_00DF:\n\tv440 = v437 == v432;\n\tv63 = ~v436;\n\tv266 = v440 & v63;\nL_FFFFFFFF:\n\tv250 = 0;\n\tif (v266) goto L_010E;\nL_00C3:\n\tv60 = v231 / v307;\n\tv151 = v60 != v147;\n\tif (v151) goto L_FFFFFFFF;\n")]
		public static bool Calculate(int count, float width, float height, RectOffset padding, Vector2 spacing, int maxColumns, LastRowAlignment lastRowAlignment, CellRect[] buffer)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AdaptiveGridLayoutCalculator::Calculate");
			return default;
		}
	}
}
