using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;

namespace _game.CoreSystem.SandPhysics.SDF
{
	[Token(Token = "0x2000111")]
	public static class SandSDFSampler
	{
		[Token(Token = "0x60005C3")]
		[Address(RVA = "0x3DAE3A0", Offset = "0x3DAE3A0", Length = "0x2A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_001E:\n\tgoto L_0021;\nL_0021:\n\tgoto L_0025;\nL_0025:\n\tgoto L_0029;\nL_0029:\n\tv102 = gridHeight + -1;\n\tv111 = worldPos.y - origin.y;\n\t// 50 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv113 = v111 / cellSize;\n\tv115 = v113 + 0xBF;\n\t// 54 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 56 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 57 NotImplemented \"Instruction FCMEQ not yet implemented.\"\n\t// 58 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 60 NotImplemented \"Instruction BSL not yet implemented.\"\n\t// 61 NotImplemented \"Instruction SMIN not yet implemented.\"\n\t// 63 NotImplemented \"Instruction SMAX not yet implemented.\"\n\tv121 = v120 + 1;\n\tv134 = v121 < v123;\n\tif (v134) goto L_0053;\n\tgoto L_0053;\n\tgoto L_0068;\nL_FFFFFFFF:\n\tv176 = 0;\n\tgoto L_008A;\nL_FFFFFFFF:\n\tv176 = v110;\nL_FFFFFFFF:\n\tv187 = 0;\n\tgoto L_0097;\nL_0053:\n\t// 83 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv142 = 0xFFFFFFFFFFFFFF80 + 1;\n\tv154 = v142 < v102;\n\tif (v154) goto L_0068;\nL_0068:\n\t// 104 NotImplemented \"Instruction FABD not yet implemented.\"\n\t// 107 NotImplemented \"Instruction DUP not yet implemented.\"\n\t// 108 NotImplemented \"Instruction CMHI not yet implemented.\"\n\t// 110 NotImplemented \"Instruction FCMGT not yet implemented.\"\n\tv187 = v115 & -1;\n\t// 113 NotImplemented \"Instruction BSL not yet implemented.\"\n\t// 114 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv166 = v120 & 1;\n\tv168 = v166 == 0;\n\tv172 = ~v168;\n\tv173 = ~v172;\n\tif (v173) goto L_FFFFFFFF;\nL_008A:\n\tgoto L_0097;\nL_0097:\n\t// 151 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 152 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 155 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 157 NotImplemented \"Instruction DUP not yet implemented.\"\n\t// 161 NotImplemented \"Instruction CMEQ not yet implemented.\"\n\tv203 = v204 & 0x38;\n\t// 167 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv208 = v203 + v209;\n\t// 170 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv211 = v208 + v212;\n\t// 172 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 173 NotImplemented \"Instruction BIF not yet implemented.\"\n\t// 174 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 182 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 185 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 187 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 191 NotImplemented \"Instruction CMEQ not yet implemented.\"\n\tv226 = v52 & 0x38;\n\tv229 = v226 + v209;\n\tv230 = v229 + v212;\n\t// 197 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 198 NotImplemented \"Instruction BIF not yet implemented.\"\n\t// 199 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv231 = v211 & 0x80;\n\tv232 = v230 | v231;\n\tv234 = v211 - v120;\n\tv235 = v176 * v234;\n\tv236 = v235 + v120;\n\tv238 = v232 - v107;\n\tv239 = v176 * v238;\n\tv240 = v239 + v107;\n\tv241 = v240 - v236;\n\tv242 = v187 * v241;\n\treturnVal1 = v236 + v242;\n\treturn returnVal1;\n")]
		public static float Sample(in NativeArray<half> values, float2 origin, float cellSize, int gridWidth, int gridHeight, float2 worldPos)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandSDFSampler::Sample");
			return default;
		}

		[Token(Token = "0x60005C4")]
		[Address(RVA = "0x3DA7880", Offset = "0x3DA7880", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv50 = _game.CoreSystem.SandPhysics.SDF.SandSDFSampler::Sample(values, origin, cellSize, gridWidth, gridHeight, worldPos);\n\tv52 = worldPos + cellSize;\n\t// 42 MakeStruct v63 @ AGG3DA78F8_5_v1 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), v52 @ V3_v1 (System.Single), worldPos.y (System.Single)\n\tv64 = _game.CoreSystem.SandPhysics.SDF.SandSDFSampler::Sample(values, origin, cellSize, gridWidth, gridHeight, v63);\n\tv66 = worldPos - cellSize;\n\t// 54 MakeStruct v75 @ AGG3DA7920_5_v1 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), v66 @ V3_v2 (System.Single), worldPos.y (System.Single)\n\tv76 = _game.CoreSystem.SandPhysics.SDF.SandSDFSampler::Sample(values, origin, cellSize, gridWidth, gridHeight, v75);\n\tv79 = worldPos.y + cellSize;\n\t// 67 MakeStruct v88 @ AGG3DA794C_5_v1 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), worldPos @ V3 (Unity.Mathematics.float2), v79 @ V4_v4 (System.Single)\n\tv89 = _game.CoreSystem.SandPhysics.SDF.SandSDFSampler::Sample(values, origin, cellSize, gridWidth, gridHeight, v88);\n\tv91 = worldPos.y - cellSize;\n\t// 79 MakeStruct v100 @ AGG3DA7974_5_v1 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), worldPos @ V3 (Unity.Mathematics.float2), v91 @ V4_v5 (System.Single)\n\tv101 = _game.CoreSystem.SandPhysics.SDF.SandSDFSampler::Sample(values, origin, cellSize, gridWidth, gridHeight, v100);\n\tv102 = cellSize + cellSize;\n\tv104 = 1f / v102;\n\tv105 = v64 - v76;\n\tv106 = v104 * v105;\n\tv107 = v89 - v101;\n\tv108 = v104 * v107;\n\tgradient.x = v106;\n\tgradient.y = v108;\n\treturn v50;\n")]
		public static float SampleWithGradient(in NativeArray<half> values, float2 origin, float cellSize, int gridWidth, int gridHeight, float2 worldPos, out float2 gradient)
		{
			gradient = default(float2);
			float result = Sample(in values, origin, cellSize, gridWidth, gridHeight, worldPos);
			float x = worldPos.x + cellSize;
			float2 worldPos2 = default(float2);
			worldPos2.x = x;
			worldPos2.y = worldPos.y;
			float num = Sample(in values, origin, cellSize, gridWidth, gridHeight, worldPos2);
			float x2 = worldPos.x - cellSize;
			float2 worldPos3 = default(float2);
			worldPos3.x = x2;
			worldPos3.y = worldPos.y;
			float num2 = Sample(in values, origin, cellSize, gridWidth, gridHeight, worldPos3);
			float y = worldPos.y + cellSize;
			float2 worldPos4 = default(float2);
			worldPos4.x = worldPos.x;
			worldPos4.y = y;
			float num3 = Sample(in values, origin, cellSize, gridWidth, gridHeight, worldPos4);
			float y2 = worldPos.y - cellSize;
			float2 worldPos5 = default(float2);
			worldPos5.x = worldPos.x;
			worldPos5.y = y2;
			float num4 = Sample(in values, origin, cellSize, gridWidth, gridHeight, worldPos5);
			float num5 = cellSize + cellSize;
			float num6 = 1f / num5;
			float num7 = num - num2;
			float x3 = num6 * num7;
			float num8 = num3 - num4;
			float y3 = num6 * num8;
			gradient.x = x3;
			gradient.y = y3;
			return result;
		}

		[Token(Token = "0x60005C5")]
		[Address(RVA = "0x3DA781C", Offset = "0x3DA781C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = worldPos - origin;\n\tv8 = v7 / cellSize;\n\tv11 = v8 + -0.5f;\n\tv12 = v11 < 0;\n\tv16 = v11 == v11;\n\tv17 = ~v16;\n\tv18 = v12 == v17;\n\tv19 = ~v18;\n\treturnVal1 = 0;\n\tif (v19) goto L_003A;\n\tv20 = worldPos.y - origin.y;\n\tv21 = v20 / cellSize;\n\tv22 = v21 + -0.5f;\n\tv23 = v22 < 0;\n\tv27 = v22 == v22;\n\tv28 = ~v27;\n\tv29 = v23 == v28;\n\tv30 = ~v29;\n\treturnVal1 = 0;\n\tif (v30) goto L_003A;\n\tv49 = gridWidth + -1f;\n\tv57 = v11 == v49;\n\tv58 = v11 < v49;\n\tv59 = ~v58;\n\tv64 = ~v59;\n\tv65 = v64 | v57;\n\tif (v65) goto L_002E;\n\treturn 0;\nL_002E:\n\tv51 = gridHeight + -1f;\n\tv45 = v22 == v51;\n\tv81 = v22 < v51;\n\tv43 = ~v81;\n\tv83 = ~v43;\n\tv37 = v83 | v45;\n\treturnVal1 = v37;\nL_003A:\n\treturn returnVal1;\n")]
		public static bool IsInsideGrid(float2 origin, float cellSize, int gridWidth, int gridHeight, float2 worldPos)
		{
			float num = worldPos.x - origin.x;
			float num2 = num / cellSize;
			float num3 = num2 + -0.5f;
			bool flag = num3 < 0f;
			bool flag2 = num3 == num3;
			bool flag3 = !flag2;
			bool flag4 = flag == flag3;
			bool flag5 = !flag4;
			bool result = false;
			if (!flag5)
			{
				float num4 = worldPos.y - origin.y;
				float num5 = num4 / cellSize;
				float num6 = num5 + -0.5f;
				bool flag6 = num6 < 0f;
				bool flag7 = num6 == num6;
				bool flag8 = !flag7;
				bool flag9 = flag6 == flag8;
				bool flag10 = !flag9;
				result = false;
				if (!flag10)
				{
					float num7 = (float)gridWidth + -1f;
					bool flag11 = num3 == num7;
					bool flag12 = num3 < num7;
					bool flag13 = !flag12;
					bool flag14 = !flag13;
					if (!(flag14 || flag11))
					{
						return false;
					}
					float num8 = (float)gridHeight + -1f;
					bool flag15 = num6 == num8;
					bool flag16 = num6 < num8;
					bool flag17 = !flag16;
					bool flag18 = !flag17;
					bool flag19 = flag18 || flag15;
					result = flag19;
				}
			}
			return result;
		}
	}
}
