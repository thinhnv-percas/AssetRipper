using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.GameConditions.Enum
{
	[Token(Token = "0x2000019")]
	public static class CompareUtil
	{
		[Token(Token = "0x6000050")]
		[Address(RVA = "0x81AF648", Offset = "0x81AF648", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = op <= 1;\n\tif (v12) goto L_0038;\n\tv17 = op == 2;\n\tif (v17) goto L_0054;\n\tv27 = op == 3;\n\tif (v27) goto L_0062;\n\tv76 = op != 4;\n\tif (v76) goto L_007F;\n\tv162 = a - b;\n\tv158 = v162 < 0;\n\tv150 = a ^ b;\n\tv146 = a ^ v162;\n\tv142 = v150 & v146;\n\tv138 = v142 < 0;\n\tv134 = v158 == v138;\n\treturn v134;\nL_0038:\n\tv22 = op == 0;\n\tif (v22) goto L_0070;\n\tv56 = op != 1;\n\tif (v56) goto L_007F;\n\tv163 = a - b;\n\tv159 = v163 < 0;\n\tv151 = a ^ b;\n\tv147 = a ^ v163;\n\tv143 = v151 & v147;\n\tv139 = v143 < 0;\n\tv170 = v159 == v139;\n\tv135 = ~v170;\n\treturn v135;\nL_0054:\n\tv36 = a - b;\n\tv37 = v36 < 0;\n\tv38 = v36 == 0;\n\tv39 = a ^ b;\n\tv40 = a ^ v36;\n\tv41 = v39 & v40;\n\tv42 = v41 < 0;\n\tv43 = v37 == v42;\n\tv44 = ~v38;\n\tv45 = v43 & v44;\n\treturn v45;\nL_0062:\n\tv79 = a - b;\n\tv80 = v79 < 0;\n\tv81 = v79 == 0;\n\tv82 = a ^ b;\n\tv83 = a ^ v79;\n\tv84 = v82 & v83;\n\tv85 = v84 < 0;\n\tv86 = v80 == v85;\n\tv87 = ~v86;\n\tv88 = v87 | v81;\n\treturn v88;\nL_0070:\n\tv59 = a - b;\n\tv61 = v59 == 0;\n\treturn v61;\nL_007F:\n\tv108 = op;\n\tv173 = 0xB28C000 + 0x880;\n\tv188 = \"il2cpp_vm_object_box\"(v173, &v108 @ stack_-24_v1 (Unco.GameConditions.Enum.ComparisonOperation), b, methodInfo, v91, v175, v176, v177, v178, v179, v180, v181, v182, v183, v184, v185);\n\tv190 = 0xB28B000 + 0x608;\n\tv192 = new v190();\n\tv194 = 0xB30E000 + 0x518;\n\tSystem.ArgumentOutOfRangeException::.ctor(v192, v194, v188, 0);\n\tthrow v192;\n")]
		public static bool CompareInt(this ComparisonOperation op, int a, int b)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CompareUtil::CompareInt");
			return default;
		}
	}
}
