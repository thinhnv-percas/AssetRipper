using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace _game.CoreSystem.SandPhysics.SDF
{
	[Token(Token = "0x200010B")]
	public struct SandSDFBakeJob : IJobParallelFor
	{
		[ReadOnly]
		[Token(Token = "0x4000375")]
		[FieldOffset(Offset = "0x0")]
		public NativeArray<float2> playableVertices;

		[ReadOnly]
		[Token(Token = "0x4000376")]
		[FieldOffset(Offset = "0x10")]
		public NativeArray<int2> playableRanges;

		[Token(Token = "0x4000377")]
		[FieldOffset(Offset = "0x20")]
		public int playableLoopCount;

		[ReadOnly]
		[Token(Token = "0x4000378")]
		[FieldOffset(Offset = "0x28")]
		public NativeArray<float2> blockedVertices;

		[ReadOnly]
		[Token(Token = "0x4000379")]
		[FieldOffset(Offset = "0x38")]
		public NativeArray<int2> blockedRanges;

		[Token(Token = "0x400037A")]
		[FieldOffset(Offset = "0x48")]
		public int blockedLoopCount;

		[Token(Token = "0x400037B")]
		[FieldOffset(Offset = "0x4C")]
		public float2 origin;

		[Token(Token = "0x400037C")]
		[FieldOffset(Offset = "0x54")]
		public float cellSize;

		[Token(Token = "0x400037D")]
		[FieldOffset(Offset = "0x58")]
		public int gridWidth;

		[Token(Token = "0x400037E")]
		[FieldOffset(Offset = "0x5C")]
		public int gridHeight;

		[WriteOnly]
		[Token(Token = "0x400037F")]
		[FieldOffset(Offset = "0x60")]
		public NativeArray<half> output;

		[Token(Token = "0x60005B3")]
		[Address(RVA = "0x3DAD28C", Offset = "0x3DAD28C", Length = "0x39C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv35 = index / this.gridWidth;\n\tv36 = v35 * this.gridWidth;\n\tv37 = index - v36;\n\tv43 = v37 + 0.5f;\n\tv44 = v43 * this.cellSize;\n\tv46 = this.origin + v44;\n\tv47 = v35 + 0.5f;\n\tv48 = v47 * this.cellSize;\n\tv49 = this.origin.y + v48;\n\tv319 = this.playableLoopCount;\n\tv61 = this.playableLoopCount < 1;\n\tif (v61) goto L_005C;\n\tv100 = this.playableRanges + 4;\nL_FFFFFFFF:\n\tv96 = this.playableLoopCount;\nL_FFFFFFFF:\n\tv98 = 0x7F7FFFFF;\n\tv229 = this.blockedLoopCount;\n\tv140 = this.blockedLoopCount >= 1;\nL_FFFFFFFF:\n\tv228 = v125;\n\tif (v140) goto L_006C;\nL_FFFFFFFF:\n\tv179 = v125;\n\tgoto L_0086;\nL_005C:\n\tv229 = this.blockedLoopCount;\n\tv82 = this.blockedLoopCount < 1;\nL_FFFFFFFF:\n\tv228 = 0x7F7FFFFF;\nL_FFFFFFFF:\n\tv179 = 0x7F7FFFFF;\n\tif (v82) goto L_0086;\nL_006C:\n\tv227 = this.blockedRanges + 4;\nL_0086:\n\tv212 = v179 < 0x7F7FFFFF;\n\tv220 = ~v212;\n\tif (v220) goto L_012B;\n\tgoto L_00A1;\nL_00A3:\n\tv319 = this.playableLoopCount;\n\tv320 = UnityEngine.Mathf::Sqrt(v179);\n\tv283 = this.playableLoopCount < 1;\nL_FFFFFFFF:\n\tv772 = v320;\n\tif (v283) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv421 = 0;\nL_FFFFFFFF:\n\tv424 = 0;\n\tgoto L_00C7;\nL_00B7:\n\tv793 = v345 & 1;\n\tv794 = v793 == 0;\n\tv418 = ~v794;\nL_FFFFFFFF:\n\tv772 = v320;\nL_FFFFFFFF:\n\tv423 = v424;\n\tif (v418) goto L_0139;\nL_00BB:\n\tv421 = v421 + 1;\n\tv494 = v421 < v319;\n\tv399 = ~v494;\n\tv390 = v421 == v319;\nL_FFFFFFFF:\n\tv424 = v399;\nL_FFFFFFFF:\n\tv772 = v320;\nL_FFFFFFFF:\n\tv423 = v399;\n\tif (v390) goto L_0139;\nL_00C7:\n\tv463 = v421 << 3;\n\tv464 = this.playableRanges + v463;\n\tv475 = *([v464 @ X15_v10+4]) < 1;\n\tif (v475) goto L_00BB;\n\tv627 = *([v464 @ X15_v10+4]) - 1;\nL_FFFFFFFF:\n\tv345 = 0;\nL_FFFFFFFF:\n\tv629 = 0;\n\tgoto L_00E8;\nL_00DC:\n\tv369 = v629 + 1;\n\tv389 = *([v464 @ X15_v10+4]) == v369;\nL_FFFFFFFF:\n\tv627 = v629;\nL_FFFFFFFF:\n\tv629 = v369;\n\tif (v389) goto L_00B7;\nL_00E8:\n\tv648 = *([v464 @ X15_v10]) + v629;\n\tv649 = v648 << 3;\n\tv650 = this.playableVertices + v649;\n\tv652 = v627 + *([v464 @ X15_v10]);\n\tv360 = v652 << 3;\n\tv653 = this.playableVertices + v360;\n\tv654 = *([v650 @ X0_v16+4]) < v49;\n\tv655 = *([v650 @ X0_v16+4]) == v49;\n\tv658 = *([v650 @ X0_v16+4]) == *([v650 @ X0_v16+4]);\n\tv659 = v49 == v49;\n\tv660 = v658 & v659;\n\tv661 = ~v660;\n\tv662 = v654 == v661;\n\tv337 = ~v655;\n\tv663 = v662 & v337;\n\tv665 = *([v653 @ X17_v12+4]) < v49;\n\tv666 = *([v653 @ X17_v12+4]) == v49;\n\tv669 = *([v653 @ X17_v12+4]) == *([v653 @ X17_v12+4]);\n\tv670 = v49 == v49;\n\tv671 = v669 & v670;\n\tv672 = ~v671;\n\tv673 = v665 == v672;\n\tv674 = ~v673;\n\tv675 = v674 | v666;\n\tv333 = v663 ^ v675;\n\tv677 = v333 == 0;\n\tv647 = ~v677;\n\tif (v647) goto L_00DC;\n\tv695 = *([v653 @ X17_v12]) - *([v650 @ X0_v16]);\n\tv696 = v49 - *([v650 @ X0_v16+4]);\n\tv697 = v696 * v695;\n\tv698 = *([v653 @ X17_v12+4]) - *([v650 @ X0_v16+4]);\n\tv699 = v697 / v698;\n\tv700 = *([v650 @ X0_v16]) + v699;\n\tv701 = v46 < v700;\n\tv709 = ~v701;\n\tif (v709) goto L_00DC;\n\tv345 = v345 ^ 1;\n\tgoto L_00DC;\nL_012B:\n\tv260 = v319 >= 1;\nL_FFFFFFFF:\n\tv320 = 0;\nL_FFFFFFFF:\n\tv772 = 0;\n\tif (v260) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv423 = 1;\nL_FFFFFFFF:\n\tv509 = 1;\nL_FFFFFFFF:\n\tv515 = 0;\n\tgoto L_0151;\nL_0140:\n\tv826 = v577 & 1;\n\tv827 = v826 == 0;\n\tv614 = ~v827;\nL_FFFFFFFF:\n\tv575 = v509;\n\tif (v614) goto L_01AC;\nL_0144:\n\tv515 = v515 + 1;\n\tv690 = v515 < this.blockedLoopCount;\n\tv536 = ~v690;\n\tv530 = v515 == this.blockedLoopCount;\n\tv520 = ~v536;\nL_FFFFFFFF:\n\tv509 = v520;\nL_FFFFFFFF:\n\tv575 = v520;\n\tif (v530) goto L_01AC;\nL_0151:\n\tv549 = v515 << 3;\n\tv550 = this.blockedRanges + v549;\n\tv561 = *([v550 @ X16_v4+4]) < 1;\n\tif (v561) goto L_0144;\n\tv725 = *([v550 @ X16_v4+4]) - 1;\nL_FFFFFFFF:\n\tv722 = 0;\nL_FFFFFFFF:\n\tv577 = 0;\n\tgoto L_0172;\nL_0166:\n\tv567 = v722 + 1;\n\tv596 = *([v550 @ X16_v4+4]) == v567;\nL_FFFFFFFF:\n\tv722 = v567;\nL_FFFFFFFF:\n\tv725 = v567;\n\tif (v596) goto L_0140;\nL_0172:\n\tv742 = *([v550 @ X16_v4]) + v722;\n\tv743 = v742 << 3;\n\tv744 = this.blockedVertices + v743;\n\tv746 = v725 + *([v550 @ X16_v4]);\n\tv579 = v746 << 3;\n\tv747 = this.blockedVertices + v579;\n\tv748 = *([v744 @ X1_v7+4]) < v49;\n\tv749 = *([v744 @ X1_v7+4]) == v49;\n\tv752 = *([v744 @ X1_v7+4]) == *([v744 @ X1_v7+4]);\n\tv753 = v49 == v49;\n\tv754 = v752 & v753;\n\tv755 = ~v754;\n\tv756 = v748 == v755;\n\tv569 = ~v749;\n\tv757 = v756 & v569;\n\tv759 = *([v747 @ X0_v8+4]) < v49;\n\tv760 = *([v747 @ X0_v8+4]) == v49;\n\tv763 = *([v747 @ X0_v8+4]) == *([v747 @ X0_v8+4]);\n\tv764 = v49 == v49;\n\tv765 = v763 & v764;\n\tv766 = ~v765;\n\tv767 = v759 == v766;\n\tv768 = ~v767;\n\tv769 = v768 | v760;\n\tv565 = v757 ^ v769;\n\tv771 = v565 == 0;\n\tv741 = ~v771;\n\tif (v741) goto L_0166;\n\tv797 = *([v747 @ X0_v8]) - *([v744 @ X1_v7]);\n\tv798 = v49 - *([v744 @ X1_v7+4]);\n\tv799 = v798 * v797;\n\tv800 = *([v747 @ X0_v8+4]) - *([v744 @ X1_v7+4]);\n\tv801 = v799 / v800;\n\tv802 = *([v744 @ X1_v7]) + v801;\n\tv803 = v46 < v802;\n\tv811 = ~v803;\n\tif (v811) goto L_0166;\n\tv577 = v577 ^ 1;\n\tgoto L_0166;\nL_FFFFFFFF:\n\tv575 = 0;\nL_FFFFFFFF:\n\tv772 = v616;\n\tgoto L_01BB;\nL_FFFFFFFF:\n\tv830 = 0x7E00;\n\tgoto L_01D9;\nL_FFFFFFFF:\n\tv830 = 0x7C00;\nL_FFFFFFFF:\n\tv849 = v830;\n\tgoto L_01EE;\nL_003D:\n\t// 61 MakeStruct v85 @ AGG3DAD328_3_v4 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), v46 @ V8_v1 (System.Single), v49 @ V9_v1 (System.Single)\n\tv125 = _game.CoreSystem.SandPhysics.SDF.SandSDFBakeJob::MinDistSqToLoop(this.playableVertices, *([v100 @ X24_v8-4]), *([v100 @ X24_v8]), v85, v98);\n\tv100 = v100 + 8;\n\tv97 = v96 - 1;\n\tv103 = v96 != 1;\nL_FFFFFFFF:\n\tv96 = v97;\nL_FFFFFFFF:\n\tv98 = v125;\n\tif (v103) goto L_003D;\nL_0074:\n\t// 116 MakeStruct v166 @ AGG3DAD384_3_v3 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), v46 @ V8_v1 (System.Single), v49 @ V9_v1 (System.Single)\n\tv208 = _game.CoreSystem.SandPhysics.SDF.SandSDFBakeJob::MinDistSqToLoop(this.blockedVertices, *([v227 @ X25_v5-4]), *([v227 @ X25_v5]), v166, v228);\n\tv227 = v227 + 8;\n\tv182 = v229 - 1;\n\tv186 = v229 != 1;\nL_FFFFFFFF:\n\tv179 = v208;\nL_FFFFFFFF:\n\tv228 = v208;\nL_FFFFFFFF:\n\tv229 = v182;\n\tif (v186) goto L_0074;\nL_00A1:\n\tgoto L_00A3;\nL_0139:\n\tv437 = this.blockedLoopCount < 1;\n\tif (v437) goto L_FFFFFFFF;\nL_01AC:\n\tv615 = v423 | v575;\n\tv616 = -v772;\n\tv617 = v615 & 1;\n\tv619 = v617 == 0;\n\tv622 = ~v619;\n\tv623 = ~v622;\n\tif (v623) goto L_01BB;\nL_01BB:\n\tv774 = v772 & 0x7FFFF000;\n\tv776 = v774 < 0x7F800000;\n\tv777 = ~v776;\n\tv778 = v774 - 0x7F800000;\n\tv780 = v778 == 0;\n\tv788 = v774 * 0x7800000;\n\tv792 = UnityEngine.Mathf::Min(v788, 260042750f);\n\tv823 = ~v780;\n\tv824 = v777 & v823;\n\tv825 = ~v824;\n\tif (v825) goto L_FFFFFFFF;\nL_01D9:\n\tv831 = v792 + 0x1000;\n\tv849 = v831 >> 0xD;\n\tv833 = v772 >> 0x17;\n\tv834 = v833 & 0xFF;\n\tv835 = v834 < 0xFE;\n\tv836 = ~v835;\n\tv837 = v834 - 0xFE;\n\tv839 = v837 == 0;\n\tv844 = ~v839;\n\tv845 = v836 & v844;\n\tv846 = ~v845;\n\tif (v846) goto L_01EE;\nL_01EE:\n\tv850 = v772 >> 0x1F;\n\tv851 = v849 | v850;\n\tv852 = this.output;\n\t*([v852 @ X9_v12 (Unity.Collections.NativeArray`1<Unity.Mathematics.half>)+index @ X1 (System.Int32)*2]) = v851;\n\treturn;\n")]
		public void Execute(int index)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandSDFBakeJob::Execute");
		}

		[Token(Token = "0x60005B4")]
		[Address(RVA = "0x3DAD628", Offset = "0x3DAD628", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = count < 1;\n\tif (v13) goto L_0091;\nL_FFFFFFFF:\n\tv44 = v42;\nL_FFFFFFFF:\n\tv96 = start;\nL_FFFFFFFF:\n\tv97 = 1;\nL_FFFFFFFF:\n\tv98 = count;\n\tgoto L_0040;\nL_0019:\n\tv175 = v158 - p;\n\tv50 = v175 * v175;\n\t// 27 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv176 = v50 < v44;\n\tv47 = ~v176;\n\tif (v47) goto L_002A;\nL_FFFFFFFF:\n\tv44 = v50;\n\tgoto L_002A;\nL_0040:\n\tv117 = v98 != 1;\n\tif (v117) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv120 = 0;\n\tgoto L_0046;\nL_FFFFFFFF:\n\tv120 = v97;\n\t// 85 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv135 = p - *([verts @ X0 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+v96 @ X11_v3 (System.Int32)*8]);\n\tv136 = v135 * v125;\n\t// 88 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv137 = v126 + v138;\n\tv138 = v136 + v139;\n\tv209 = v138 / v137;\n\tv142 = v209 & 0x7FFFFFFF;\n\tv143 = v142 < 0x7F800001;\n\tv144 = ~v143;\n\tv152 = ~v144;\n\tv153 = ~v152;\n\tif (v153) goto L_FFFFFFFF;\n\tv200 = v209 < 1f;\n\tv199 = v209 == 1f;\n\tv188 = v209 == v209;\n\tv189 = 1f == 1f;\n\tv190 = v188 & v189;\n\tv198 = ~v190;\n\tgoto L_0078;\nL_FFFFFFFF:\n\tv198 = 0;\nL_FFFFFFFF:\n\tv199 = 0;\nL_FFFFFFFF:\n\tv200 = 0;\n\tgoto L_0081;\nL_FFFFFFFF:\n\tv209 = 1f;\n\tgoto L_008D;\nL_0091:\n\treturn v44;\nL_002A:\n\tv96 = v96 + 1;\n\tv97 = v97 + 1;\n\tv79 = v98 == 1;\n\tv98 = v98 - 1;\n\tif (v79) goto L_0091;\nL_0046:\n\tv121 = v120 + start;\n\tv158 = *([verts @ X0 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+v96 @ X11_v3 (System.Int32)*8]);\n\tv125 = *([verts @ X0 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+v121 @ X12_v4 (System.Int32)*8]) - *([verts @ X0 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+v96 @ X11_v3 (System.Int32)*8]);\n\tv126 = v125 * v125;\n\t// 75 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv127 = v138 < 0x2B8CBCCC;\n\tif (v127) goto L_0019;\nL_0078:\n\tv203 = v200 == v198;\n\tv204 = ~v203;\n\tv160 = v204 | v199;\n\tv205 = ~v160;\n\tif (v205) goto L_FFFFFFFF;\nL_0081:\n\tv170 = v209 < 0;\n\tv157 = ~v170;\n\tif (v157) goto L_008D;\nL_008D:\n\tv154 = v125 * v213;\n\tv158 = v158 + v154;\n\tgoto L_0019;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static float MinDistSqToLoop(NativeArray<float2> verts, int start, int count, float2 p, float currentBest)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandSDFBakeJob::MinDistSqToLoop");
			return default;
		}
	}
}
