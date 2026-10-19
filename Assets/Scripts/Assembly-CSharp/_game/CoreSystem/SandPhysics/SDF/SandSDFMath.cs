using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace _game.CoreSystem.SandPhysics.SDF
{
	[Token(Token = "0x2000110")]
	public static class SandSDFMath
	{
		[Token(Token = "0x60005C0")]
		[Address(RVA = "0x3DAE25C", Offset = "0x3DAE25C", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv32 = b - a;\n\tv33 = b.y - a.y;\n\tv34 = v32 * v32;\n\tv35 = v33 * v33;\n\tv36 = v34 + v35;\n\tv40 = v36 < 0x2B8CBCCC;\n\tv48 = ~v40;\n\tif (v48) goto L_0038;\n\tgoto L_FFFFFFFF;\nL_0038:\n\tv54 = p - a;\n\tv55 = p.y - a.y;\n\tv56 = v54 * v32;\n\tv57 = v55 * v33;\n\tv58 = v56 + v57;\n\tv169 = v58 / v36;\n\tv61 = v169 & 0x7FFFFFFF;\n\tv64 = v61 < 0x7F800001;\n\tv65 = ~v64;\n\tv74 = ~v65;\n\tv75 = ~v74;\n\tif (v75) goto L_FFFFFFFF;\n\tv189 = v169 < 1f;\n\tv188 = v169 == 1f;\n\tv102 = v169 == v169;\n\tv103 = 1f == 1f;\n\tv104 = v102 & v103;\n\tv185 = ~v104;\n\tgoto L_005D;\nL_FFFFFFFF:\n\tv185 = 0;\nL_FFFFFFFF:\n\tv188 = 0;\nL_FFFFFFFF:\n\tv189 = 0;\n\tgoto L_0066;\nL_FFFFFFFF:\n\tv169 = 1f;\nL_FFFFFFFF:\n\tv169 = 0;\n\tgoto L_0073;\nL_008A:\n\tv179 = v173 - p.y;\n\tv180 = v170 - p;\n\tv181 = v180 * v180;\n\tv182 = v179 * v179;\n\tv183 = v181 + v182;\n\treturnVal1 = UnityEngine.Mathf::Sqrt(v183);\n\treturn returnVal1;\nL_FFFFFFFF:\n\tv170 = a;\nL_FFFFFFFF:\n\tv173 = a.y;\n\tgoto L_008A;\nL_005D:\n\tv190 = v189 == v185;\n\tv191 = ~v190;\n\tv145 = v191 | v188;\n\tv192 = ~v145;\n\tif (v192) goto L_FFFFFFFF;\nL_0066:\n\tv163 = v169 < 0;\n\tv121 = ~v163;\n\tif (v121) goto L_0073;\nL_0073:\n\tv112 = v32 * v169;\n\tv115 = v33 * v169;\n\tgoto L_0082;\nL_0082:\n\tv172 = a + v112;\n\tv173 = a.y + v115;\nL_FFFFFFFF:\n\tv170 = v172;\n\tgoto L_008A;\n")]
		public static float PointToSegmentDistance(float2 p, float2 a, float2 b)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandSDFMath::PointToSegmentDistance");
			return default;
		}

		[Token(Token = "0x60005C1")]
		[Address(RVA = "0x3DAD814", Offset = "0x3DAD814", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv81 = v44.y;\n\tv6 = b - v44;\n\tv7 = b.y - v44.y;\n\tv8 = v6 * v6;\n\tv9 = v7 * v7;\n\tv10 = v8 + v9;\n\tv14 = v10 < 0x2B8CBCCC;\n\tif (v14) goto L_0053;\n\tv22 = p - v44;\n\tv23 = p.y - v44.y;\n\tv24 = v22 * v6;\n\tv25 = v23 * v7;\n\tv26 = v24 + v25;\n\tv76 = v26 / v10;\n\tv29 = v76 & 0x7FFFFFFF;\n\tv32 = v29 < 0x7F800001;\n\tv33 = ~v32;\n\tv42 = ~v33;\n\tv43 = ~v42;\n\tif (v43) goto L_FFFFFFFF;\n\tv104 = v76 < 1f;\n\tv103 = v76 == 1f;\n\tv92 = v76 == v76;\n\tv93 = 1f == 1f;\n\tv94 = v92 & v93;\n\tv100 = ~v94;\n\tgoto L_0039;\nL_FFFFFFFF:\n\tv100 = 0;\nL_FFFFFFFF:\n\tv103 = 0;\nL_FFFFFFFF:\n\tv104 = 0;\n\tgoto L_0042;\nL_FFFFFFFF:\n\tv76 = 1f;\nL_FFFFFFFF:\n\tv76 = 0;\n\tgoto L_004F;\nL_0053:\n\tv83 = v45 - p;\n\tv84 = v81 - p.y;\n\tv85 = v83 * v83;\n\tv86 = v84 * v84;\n\treturnVal1 = v85 + v86;\n\treturn returnVal1;\nL_0039:\n\tv105 = v104 == v100;\n\tv106 = ~v105;\n\tv50 = v106 | v103;\n\tv107 = ~v50;\n\tif (v107) goto L_FFFFFFFF;\nL_0042:\n\tv71 = v76 < 0;\n\tv47 = ~v71;\n\tif (v47) goto L_004F;\nL_004F:\n\tv78 = v6 * v76;\n\tv80 = v7 * v76;\n\tv45 = v44 + v78;\n\tv81 = v81 + v80;\n")]
		public static float PointToSegmentDistanceSq(float2 p, float2 a, float2 b)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandSDFMath::PointToSegmentDistanceSq");
			return default;
		}

		[Token(Token = "0x60005C2")]
		[Address(RVA = "0x3DAD778", Offset = "0x3DAD778", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv60 = count - 1;\n\tv14 = count < 1;\n\tif (v14) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv55 = 0;\nL_FFFFFFFF:\n\tv56 = 0;\n\tgoto L_0020;\nL_0014:\n\tv52 = v56 + 1;\n\tv71 = count == v52;\nL_FFFFFFFF:\n\tv56 = v52;\nL_FFFFFFFF:\n\tv60 = v52;\nL_FFFFFFFF:\n\tv124 = v55;\n\tif (v71) goto L_005A;\nL_0020:\n\tv78 = start + v56;\n\tv79 = v78 << 3;\n\tv80 = verts + v79;\n\tv83 = v60 + start;\n\tv49 = v83 << 3;\n\tv84 = verts + v49;\n\tv85 = *([v80 @ X13_v4+4]) < point.y;\n\tv86 = *([v80 @ X13_v4+4]) == point.y;\n\tv89 = *([v80 @ X13_v4+4]) == *([v80 @ X13_v4+4]);\n\tv90 = point.y == point.y;\n\tv91 = v89 & v90;\n\tv92 = ~v91;\n\tv93 = v85 == v92;\n\tv40 = ~v86;\n\tv94 = v93 & v40;\n\tv96 = *([v84 @ X12_v5+4]) < point.y;\n\tv97 = *([v84 @ X12_v5+4]) == point.y;\n\tv100 = *([v84 @ X12_v5+4]) == *([v84 @ X12_v5+4]);\n\tv101 = point.y == point.y;\n\tv102 = v100 & v101;\n\tv103 = ~v102;\n\tv104 = v96 == v103;\n\tv105 = ~v104;\n\tv106 = v105 | v97;\n\tv37 = v94 ^ v106;\n\tv108 = v37 == 0;\n\tv31 = ~v108;\n\tif (v31) goto L_0014;\n\tv140 = *([v84 @ X12_v5]) - *([v80 @ X13_v4]);\n\tv141 = point.y - *([v80 @ X13_v4+4]);\n\tv142 = v141 * v140;\n\tv143 = *([v84 @ X12_v5+4]) - *([v80 @ X13_v4+4]);\n\tv144 = v142 / v143;\n\tv145 = *([v80 @ X13_v4]) + v144;\n\tv146 = point < v145;\n\tv154 = ~v146;\n\tif (v154) goto L_0014;\n\tv55 = v55 ^ 1;\n\tgoto L_0014;\nL_FFFFFFFF:\n\tv124 = 0;\nL_005A:\n\treturnVal1 = v124 & 1;\n\treturn returnVal1;\n")]
		public static bool IsPointInLoop(NativeArray<float2> verts, float2 point, int start, int count)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandSDFMath::IsPointInLoop");
			return default;
		}
	}
}
