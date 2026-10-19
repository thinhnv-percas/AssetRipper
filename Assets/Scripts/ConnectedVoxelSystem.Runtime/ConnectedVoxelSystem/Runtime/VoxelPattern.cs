using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.OptionalValueSystem;
using UnityEngine;

namespace ConnectedVoxelSystem.Runtime
{
	[Serializable]
	[Token(Token = "0x200000C")]
	public struct VoxelPattern
	{
		[SerializeField]
		[Token(Token = "0x400001F")]
		[FieldOffset(Offset = "0x0")]
		private bool m_frontRight;

		[SerializeField]
		[Token(Token = "0x4000020")]
		[FieldOffset(Offset = "0x1")]
		private bool m_frontLeft;

		[SerializeField]
		[Token(Token = "0x4000021")]
		[FieldOffset(Offset = "0x2")]
		private bool m_rearLeft;

		[SerializeField]
		[Token(Token = "0x4000022")]
		[FieldOffset(Offset = "0x3")]
		private bool m_rearRight;

		[Token(Token = "0x6000040")]
		[Address(RVA = "0x3F2E11C", Offset = "0x3F2E11C", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_frontRight = frontRight;\n\tthis.m_frontLeft = frontLeft;\n\tthis.m_rearLeft = rearLeft;\n\tthis.m_rearRight = rearRight;\n\treturn;\n")]
		public VoxelPattern(bool frontRight, bool frontLeft, bool rearLeft, bool rearRight)
		{
			m_frontRight = frontRight;
			m_frontLeft = frontLeft;
			m_rearLeft = rearLeft;
			m_rearRight = rearRight;
		}

		[Token(Token = "0x6000041")]
		[Address(RVA = "0x3F2E130", Offset = "0x3F2E130", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_FFFFFFFF:\n\tv63 = 2;\n\tgoto L_002D;\nL_FFFFFFFF:\n\tv63 = 0;\nL_FFFFFFFF:\n\tv80 = 4;\n\tgoto L_0040;\nL_FFFFFFFF:\n\tv80 = 0;\nL_FFFFFFFF:\n\tv97 = 8;\n\tgoto L_0052;\nL_FFFFFFFF:\n\tv97 = 0;\n\tv118 = v97 >> 3;\n\tv119 = v118 | v82;\n\tv129 = v119 != v108;\n\tif (v129) goto L_0076;\nL_FFFFFFFF:\n\tv161 = 1;\n\tgoto L_00A3;\nL_0076:\n\tv180 = v80 >> 2;\n\tv181 = v119 & 7;\n\tv167 = v181 << 1;\n\tv182 = v180 & 0xFFFFFFFFFFFFFFF1;\n\tv160 = v182 | v167;\n\tv132 = v160 != v108;\n\tif (v132) goto L_0088;\nL_FFFFFFFF:\n\tv161 = 2;\n\tgoto L_00A3;\nL_0088:\n\tv184 = v63 >> 1;\n\tv185 = v160 & 7;\n\tv166 = v185 << 1;\n\tv186 = v184 & 0xFFFFFFFFFFFFFFF1;\n\tv169 = v186 | v166;\n\tv131 = v169 != v108;\n\tif (v131) goto L_00AF;\nL_FFFFFFFF:\n\tv161 = 3;\nL_00AF:\n\treturnVal2 = Unco.OptionalValueSystem.Optional`1<ConnectedVoxelSystem.Runtime.VertexRotation>::get_None();\n\treturn returnVal2;\nL_001F:\n\tv51 = this.m_frontLeft == 0;\n\tv57 = ~v51;\n\tv58 = ~v57;\n\tif (v58) goto L_FFFFFFFF;\nL_002D:\n\tv65 = v63 | this.m_frontRight;\n\tv70 = this.m_rearLeft == 0;\n\tv76 = ~v70;\n\tv77 = ~v76;\n\tif (v77) goto L_FFFFFFFF;\nL_0040:\n\tv82 = v65 | v80;\n\tv87 = this.m_rearRight == 0;\n\tv93 = ~v87;\n\tv94 = ~v93;\n\tif (v94) goto L_FFFFFFFF;\nL_0052:\n\tv98 = pattern & 0xFF;\n\tv99 = pattern >> 7;\n\tv100 = v99 & 2;\n\tv101 = v100 | v98;\n\tv102 = pattern >> 0xE;\n\tv103 = v102 & 4;\n\tv104 = pattern >> 0x15;\n\tv105 = v104 & 8;\n\tv106 = v103 | v105;\n\tv107 = v82 | v97;\n\tv108 = v101 | v106;\n\tv113 = v107 == v108;\nL_FFFFFFFF:\n\tv161 = 0;\n\tif (v113) goto L_00A3;\nL_00A3:\n\treturnVal1 = Unco.OptionalValueSystem.Optional`1<ConnectedVoxelSystem.Runtime.VertexRotation>::op_Implicit(v161);\n\treturn returnVal1;\n")]
		public Optional<VertexRotation> Match(VoxelPattern pattern)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VoxelPattern::Match");
			return default;
		}

		[Token(Token = "0x6000042")]
		[Address(RVA = "0x3F2E264", Offset = "0x3F2E264", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = this.m_frontLeft == 0;\n\tv13 = ~v7;\n\tv14 = ~v13;\n\tif (v14) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv17 = 2;\n\tgoto L_0014;\nL_FFFFFFFF:\n\tv17 = 0;\nL_FFFFFFFF:\n\tv34 = 4;\n\tgoto L_002B;\nL_FFFFFFFF:\n\tv34 = 0;\nL_FFFFFFFF:\n\tv50 = 8;\n\tgoto L_0038;\nL_FFFFFFFF:\n\tv50 = 0;\nL_0014:\n\tv19 = v17 | this.m_frontRight;\n\tv24 = this.m_rearLeft == 0;\n\tv30 = ~v24;\n\tv31 = ~v30;\n\tif (v31) goto L_FFFFFFFF;\nL_002B:\n\tv40 = this.m_rearRight == 0;\n\tv46 = ~v40;\n\tv47 = ~v46;\n\tif (v47) goto L_FFFFFFFF;\nL_0038:\n\tv51 = v34 | v50;\n\treturnVal1 = v19 | v51;\n\treturn returnVal1;\n")]
		public int GetBits()
		{
			int num = (m_frontLeft ? 2 : 0);
			int num2 = num | (m_frontRight ? 1 : 0);
			int num3 = (m_rearLeft ? 4 : 0);
			int num4 = (m_rearRight ? 8 : 0);
			int num5 = num3 | num4;
			return num2 | num5;
		}

		[Token(Token = "0x6000043")]
		[Address(RVA = "0x3F2E2A8", Offset = "0x3F2E2A8", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = bits >> 3;\n\tv2 = v0 & 1;\n\tv3 = bits & 7;\n\tv4 = v3 << 1;\n\tv5 = v2 & 0xFFFFFFFFFFFFFFF1;\n\tv6 = v5 | v4;\n\treturn v6;\n")]
		public static int LoopBits(int bits)
		{
			int num = bits >> 3;
			int num2 = num & 1;
			int num3 = bits & 7;
			int num4 = num3 << 1;
			int num5 = num2 & -15;
			return num5 | num4;
		}
	}
}
