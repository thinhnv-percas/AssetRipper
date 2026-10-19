using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x2000005")]
	public static class SolverColorExtensions
	{
		[Token(Token = "0x6000003")]
		[Address(RVA = "0x3BFC958", Offset = "0x3BFC958", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\n\tv55 = 0xA6C7000 + 0x3D8;\n\tv56 = *([v55 @ X9_v2 (System.Int32)+v39 @ X8_v3 (System.Int32)*8]);\n\treturn *([v56 @ X8_v6]);\nL_0055:\n\treturn \"?\";\nL_0036:\n\tv39 = c - 1;\n\tv40 = v39 < 0xB;\n\tv41 = ~v40;\n\tv42 = v39 - 0xB;\n\tv44 = v42 == 0;\n\tv49 = ~v44;\n\tv50 = v41 & v49;\n\tif (v50) goto L_0055;\n")]
		public static string ToShortCode(this SolverColor c)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SolverColorExtensions::ToShortCode");
			return default;
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x3BFCA58", Offset = "0x3BFCA58", Length = "0x770")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0059;\n\tv63 = v41 < 0x460029EC;\n\tv64 = ~v63;\n\tv65 = v41 - 0x460029EC;\n\tv67 = v65 == 0;\n\tv72 = ~v67;\n\tv73 = v64 & v72;\n\tif (v73) goto L_010C;\n\tv92 = v41 < 0x6AE2426;\n\tv93 = ~v92;\n\tv94 = v41 - 0x6AE2426;\n\tv96 = v94 == 0;\n\tv101 = ~v96;\n\tv102 = v93 & v101;\n\tif (v102) goto L_0196;\n\tv151 = v41 == 0x2B8B9CF;\n\tif (v151) goto L_02E9;\n\tv242 = v41 == 0x51A37C8;\n\tif (v242) goto L_0269;\n\tv386 = v41 != 0x6AE2426;\n\tif (v386) goto L_036A;\n\tv543 = System.String::op_Equality(s, \"DarkGrey\");\n\tv578 = v543 == 0;\n\tif (v578) goto L_036A;\n\treturn 2;\nL_00BB:\n\tv76 = v41 < 0xFFFFFFFFCA0C003E;\n\tv77 = ~v76;\n\tv78 = v41 - 0xFFFFFFFFCA0C003E;\n\tv80 = v78 == 0;\n\tv85 = ~v80;\n\tv86 = v77 & v85;\n\tif (v86) goto L_014F;\n\tv118 = v41 < 0xFFFFFFFFB682BA1F;\n\tv119 = ~v118;\n\tv120 = v41 - 0xFFFFFFFFB682BA1F;\n\tv122 = v120 == 0;\n\tv127 = ~v122;\n\tv128 = v119 & v127;\n\tif (v128) goto L_01CB;\n\tv195 = v41 == 0xFFFFFFFFA37F187C;\n\tif (v195) goto L_02F9;\n\tv310 = v41 == 0xFFFFFFFFA953C75C;\n\tif (v310) goto L_0279;\n\tv466 = v41 != 0xFFFFFFFFB682BA1F;\n\tif (v466) goto L_036A;\n\tv570 = System.String::op_Equality(s, \"Purple\");\n\tv579 = v570 == 0;\n\tif (v579) goto L_036A;\n\treturn 3;\nL_010C:\n\tv105 = v41 < 0x69E24D84;\n\tv106 = ~v105;\n\tv107 = v41 - 0x69E24D84;\n\tv109 = v107 == 0;\n\tv114 = ~v109;\n\tv115 = v106 & v114;\n\tif (v115) goto L_0200;\n\tv173 = v41 == 0x4EDDA5D5;\n\tif (v173) goto L_0309;\n\tv276 = v41 == 0x5F005147;\n\tif (v276) goto L_0289;\n\tv426 = v41 != 0x69E24D84;\n\tif (v426) goto L_036A;\n\tv571 = System.String::op_Equality(s, \"LG\");\n\tv580 = v571 == 0;\n\tif (v580) goto L_036A;\n\treturn 1;\nL_014F:\n\tv131 = v41 < 0xFFFFFFFFD70C14B5;\n\tv132 = ~v131;\n\tv133 = v41 - 0xFFFFFFFFD70C14B5;\n\tv135 = v133 == 0;\n\tv140 = ~v135;\n\tv141 = v132 & v140;\n\tif (v141) goto L_0235;\n\tv217 = v41 == 0xFFFFFFFFD10C0B43;\n\tif (v217) goto L_0319;\n\tv344 = v41 == 0xFFFFFFFFD20C0CD6;\n\tif (v344) goto L_0299;\n\tv506 = v41 != 0xFFFFFFFFD70C14B5;\n\tif (v506) goto L_036A;\n\tv572 = System.String::op_Equality(s, \"R\");\n\tv581 = v572 == 0;\n\tif (v581) goto L_036A;\n\treturn 0xB;\nL_0196:\n\tv162 = v41 == 0x2429CABF;\n\tif (v162) goto L_0329;\n\tv259 = v41 == 0x39CE7A3C;\n\tif (v259) goto L_02A9;\n\tv406 = v41 != 0x460029EC;\n\tif (v406) goto L_036A;\n\tv573 = System.String::op_Equality(s, \"Pk\");\n\tv582 = v573 == 0;\n\tif (v582) goto L_036A;\n\treturn 4;\nL_01CB:\n\tv206 = v41 == 0xFFFFFFFFC20BF3A6;\n\tif (v206) goto L_0339;\n\tv327 = v41 == 0xFFFFFFFFC70BFB85;\n\tif (v327) goto L_02B9;\n\tv486 = v41 != 0xFFFFFFFFCA0C003E;\n\tif (v486) goto L_036A;\n\tv574 = System.String::op_Equality(s, \"O\");\n\tv583 = v574 == 0;\n\tif (v583) goto L_036A;\n\treturn 9;\nL_0200:\n\tv184 = v41 == 0xFFFFFFFF8BB8038D;\n\tif (v184) goto L_0349;\n\tv293 = v41 == 0x6CEB2D06;\n\tif (v293) goto L_02C9;\n\tv446 = v41 != 0x727B390B;\n\tif (v446) goto L_036A;\n\tv575 = System.String::op_Equality(s, \"Orange\");\n\tv584 = v575 == 0;\n\tif (v584) goto L_036A;\n\treturn 9;\nL_0235:\n\tv228 = v41 == 0xFFFFFFFFD9CDEC69;\n\tif (v228) goto L_0359;\n\tv361 = v41 == 0xFFFFFFFFDC0C1C94;\n\tif (v361) goto L_02D9;\n\tv526 = v41 != 0xFFFFFFFFE9DD1FED;\n\tif (v526) goto L_036A;\n\tv576 = System.String::op_Equality(s, \"Blue\");\n\tv585 = v576 == 0;\n\tif (v585) goto L_036A;\n\treturn 6;\nL_0269:\n\tv392 = System.String::op_Equality(s, \"LightGrey\");\n\tv586 = v392 == 0;\n\tif (v586) goto L_036A;\n\treturn 1;\nL_0279:\n\tv472 = System.String::op_Equality(s, \"Green\");\n\tv587 = v472 == 0;\n\tif (v587) goto L_036A;\n\treturn 8;\nL_0289:\n\tv432 = System.String::op_Equality(s, \"Pr\");\n\tv588 = v432 == 0;\n\tif (v588) goto L_036A;\n\treturn 3;\nL_0299:\n\tv512 = System.String::op_Equality(s, \"W\");\n\tv589 = v512 == 0;\n\tif (v589) goto L_036A;\n\treturn 0xC;\nL_02A9:\n\tv412 = System.String::op_Equality(s, \"DG\");\n\tv590 = v412 == 0;\n\tif (v590) goto L_036A;\n\treturn 2;\nL_02B9:\n\tv492 = System.String::op_Equality(s, \"B\");\n\tv591 = v492 == 0;\n\tif (v591) goto L_036A;\n\treturn 6;\nL_02C9:\n\tv452 = System.String::op_Equality(s, \"White\");\n\tv592 = v452 == 0;\n\tif (v592) goto L_036A;\n\treturn 0xC;\nL_02D9:\n\tv532 = System.String::op_Equality(s, \"Y\");\n\tv593 = v532 == 0;\n\tif (v593) goto L_036A;\n\treturn 0xA;\nL_02E9:\n\tv252 = System.String::op_Equality(s, \"Brown\");\n\tv394 = v252 == 0;\n\tif (v394) goto L_036A;\n\treturn 5;\nL_02F9:\n\tv320 = System.String::op_Equality(s, \"Red\");\n\tv474 = v320 == 0;\n\tif (v474) goto L_036A;\n\treturn 0xB;\nL_0309:\n\tv286 = System.String::op_Equality(s, \"Br\");\n\tv434 = v286 == 0;\n\tif (v434) goto L_036A;\n\treturn 5;\nL_0319:\n\tv354 = System.String::op_Equality(s, \"T\");\n\tv514 = v354 == 0;\n\tif (v514) goto L_036A;\n\treturn 7;\nL_0329:\n\tv269 = System.String::op_Equality(s, \"Teal\");\n\tv414 = v269 == 0;\n\tif (v414) goto L_036A;\n\treturn 7;\nL_0339:\n\tv337 = System.String::op_Equality(s, \"G\");\n\tv494 = v337 == 0;\n\tif (v494) goto L_036A;\n\treturn 8;\nL_0349:\n\tv303 = System.String::op_Equality(s, \"Pink\");\n\tv454 = v303 == 0;\n\tif (v454) goto L_036A;\n\treturn 4;\nL_0359:\n\tv371 = System.String::op_Equality(s, \"Yellow\");\n\tv534 = v371 == 0;\n\tif (v534) goto L_036A;\n\treturn 0xA;\nL_036A:\n\treturn 0;\nL_0059:\n\tv41 = <PrivateImplementationDetails>::ComputeStringHash(s);\n\tv47 = v41 < 0xFFFFFFFF8BB8038D;\n\tv48 = ~v47;\n\tv49 = v41 - 0xFFFFFFFF8BB8038D;\n\tv51 = v49 == 0;\n\tv56 = ~v51;\n\tv57 = v48 & v56;\n\tif (v57) goto L_00BB;\n")]
		public static SolverColor FromString(string s)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SolverColorExtensions::FromString");
			return default;
		}

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x3BFD1C8", Offset = "0x3BFD1C8", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = c - 1;\n\tv2 = v0 < 0xA;\n\tv3 = ~v2;\n\tv4 = v0 - 0xA;\n\tv6 = v4 == 0;\n\tv11 = ~v6;\n\tv12 = v3 & v11;\n\tif (v12) goto L_0012;\n\tv14 = 0x9307000 + 0x950;\n\treturn *([v14 @ X9_v2 (System.Int32)+v0 @ X8_v1 (System.Int32)*4]);\nL_0012:\n\treturn -1;\n")]
		public static int ToGameColorInt(this SolverColor c)
		{
			int num = (int)(c - 1);
			bool flag = (uint)num < 10u;
			bool flag2 = !flag;
			int num2 = num - 10;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 154169344 + 2384;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ X9_v2 (System.Int32)+v0 @ X8_v1 (System.Int32)*4]");
				return 0;
			}
			return -1;
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0x3BFD1EC", Offset = "0x3BFD1EC", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = i < 0xC;\n\tv2 = ~v0;\n\tv3 = i - 0xC;\n\tv5 = v3 == 0;\n\tv10 = ~v5;\n\tv11 = v2 & v10;\n\tif (v11) goto L_0011;\n\tv13 = 0x9307000 + 0x97C;\n\treturn *([v13 @ X8_v2 (System.Int32)+i @ X0 (System.Int32)*4]);\nL_0011:\n\treturn 0;\n")]
		public static SolverColor FromGameColorInt(int i)
		{
			bool flag = (uint)i < 12u;
			bool flag2 = !flag;
			int num = i - 12;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 154169344 + 2428;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ X8_v2 (System.Int32)+i @ X0 (System.Int32)*4]");
				return SolverColor.None;
			}
			return default(SolverColor);
		}
	}
}
