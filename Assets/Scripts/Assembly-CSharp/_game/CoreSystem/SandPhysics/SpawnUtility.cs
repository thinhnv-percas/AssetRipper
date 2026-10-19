using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using _game.CoreSystem.SandPhysics.Collision;
using _game.CoreSystem.SandPhysics.Components;

namespace _game.CoreSystem.SandPhysics
{
	[Token(Token = "0x20000AD")]
	public static class SpawnUtility
	{
		[Token(Token = "0x20000AE")]
		public struct GridLayout
		{
			[Token(Token = "0x4000235")]
			[FieldOffset(Offset = "0x0")]
			public int gridSize;

			[Token(Token = "0x4000236")]
			[FieldOffset(Offset = "0x4")]
			public float gridStep;

			[Token(Token = "0x4000237")]
			[FieldOffset(Offset = "0x8")]
			public float gridStart;

			[Token(Token = "0x4000238")]
			[FieldOffset(Offset = "0xC")]
			public float cos;

			[Token(Token = "0x4000239")]
			[FieldOffset(Offset = "0x10")]
			public float sin;
		}

		[Token(Token = "0x60002E0")]
		[Address(RVA = "0x3C7C138", Offset = "0x3C7C138", Length = "0x1B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tgoto L_001D;\nL_001D:\n\tgoto L_0021;\nL_0021:\n\tgoto L_0026;\nL_0026:\n\tgoto L_002A;\nL_002A:\n\tgoto L_002F;\nL_002F:\n\tgoto L_0033;\nL_0033:\n\tgoto L_0037;\nL_0037:\n\tv174 = rotation * 0x3C8EFA35;\n\treturnVal1 = 0x8BF5CCC(System.Math, methodInfo, v39, v40, v41, v42, v43, v44, v174, rotation, v45, v46, v47, v48, v49, v50);\n\tv182 = cubeSize * 0.5f;\n\tv184 = UnityEngine.Mathf::Sqrt(particleCount);\n\tv186 = UnityEngine.Mathf::Ceil(v184);\n\tv189 = cubeSize / v186;\n\tv190 = v189 * 0.5f;\n\tv191 = v190 - v182;\n\treturnBuffer.gridSize = v184;\n\treturnBuffer.gridStep = v189;\n\treturnBuffer.gridStart = v191;\n\treturnBuffer.cos = rotation;\n\treturnBuffer.sin = v174;\n\treturn returnBuffer;\n")]
		public static GridLayout ComputeLayout(float cubeSize, float rotation, int particleCount)
		{
			//IL_00b2: Expected I4, but got F4
			float sin = rotation * ((float)Math.PI / 180f);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5CCC");
			float num = cubeSize * 0.5f;
			float num2 = Mathf.Sqrt(particleCount);
			float num3 = Mathf.Ceil(num2);
			float num4 = cubeSize / num3;
			float num5 = num4 * 0.5f;
			float gridStart = num5 - num;
			GridLayout result = default(GridLayout);
			result.gridSize = (int)num2;
			result.gridStep = num4;
			result.gridStart = gridStart;
			result.cos = rotation;
			result.sin = sin;
			return result;
		}

		[Token(Token = "0x60002E1")]
		[Address(RVA = "0x3C7C2E8", Offset = "0x3C7C2E8", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = layout.gridStep * gx;\n\tv8 = layout.gridStart + v7;\n\tv11 = layout.gridStep * gy;\n\tv12 = layout.gridStart + v11;\n\tv15 = layout.cos * v8;\n\tv16 = v12 * layout.sin;\n\tv17 = v15 - v16;\n\treturnVal1 = cubeCenter + v17;\n\treturn returnVal1;\n")]
		public static float2 ComputePosition(float2 cubeCenter, in GridLayout layout, int gx, int gy)
		{
			float num = layout.gridStep * (float)gx;
			float num2 = layout.gridStart + num;
			float num3 = layout.gridStep * (float)gy;
			float num4 = layout.gridStart + num3;
			float num5 = layout.cos * num2;
			float num6 = num4 * layout.sin;
			float num7 = num5 - num6;
			float x = cubeCenter.x + num7;
			float2 result = default(float2);
			result.x = x;
			return result;
		}

		[Token(Token = "0x60002E2")]
		[Address(RVA = "0x3C7C32C", Offset = "0x3C7C32C", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv59 = gy * 0x64;\n\tv60 = cubeIndex * 0x2710;\n\tv61 = v59 + v60;\n\tv62 = v61 + gx;\n\tv63 = v62 + 0x68;\n\tv64 = v63 ^ v63;\n\tv66 = v64 ^ 0x3D;\n\tv67 = v66 << 3;\n\tv68 = v66 + v67;\n\tv69 = v68 ^ v68;\n\tv72 = v69 * 0x27D4EB2D;\n\tv73 = v72 ^ v72;\n\tv74 = v73 ^ v73;\n\tv75 = v74 ^ v74;\n\tv76 = v75 ^ v75;\n\tgoto L_003D;\nL_003D:\n\tv144 = v76 ^ v76;\n\tgoto L_0042;\nL_0042:\n\tv165 = v144 ^ v144;\n\tv149 = *([B193A98]) & 1;\n\tv150 = v149 == 0;\n\tif (v150) goto L_009B;\n\tv192 = v165 ^ v165;\n\tv181 = System.Math;\n\tgoto L_004F;\nL_004F:\n\tv197 = v76 >> 9;\n\tv198 = v197 & 0x7FFFFF;\n\tv200 = 0x3F800000 | v198;\n\tv203 = v200 + -1f;\n\tv206 = v203 * 0x40490FDB;\n\tv207 = v206 + v206;\n\tv121 = 0x8BF5CCC(v181, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v207, 0x40490FDB, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv213 = v192 >> 9;\n\tv123 = v213 & 0x7FFFFF;\n\tv215 = 0x3F800000 | v123;\n\tv217 = v215 + -1f;\n\tv218 = v217 * jitterStrength;\n\treturnVal2 = v218 * 0x40490FDB;\n\treturn returnVal2;\nL_0083:\n\treturn v86.zero;\nL_009B:\n\t*([B193A98]) = 1;\n\tv192 = v165 ^ v165;\n\tv181 = System.Math;\n\tgoto L_004F;\nL_001A:\n\tv50 = jitterStrength == 0;\n\tv51 = jitterStrength < 0;\n\tv52 = ~v51;\n\tv55 = ~v52;\n\tv56 = v55 | v50;\n\tif (v56) goto L_0083;\n")]
		public static float2 ComputeJitter(int cubeIndex, int gy, int gx, float jitterStrength)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SpawnUtility::ComputeJitter");
			return default;
		}

		[Token(Token = "0x60002E3")]
		[Address(RVA = "0x3C7C500", Offset = "0x3C7C500", Length = "0x31C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0060;\nL_0069:\n\tv119 = Unity.Entities.EntityCommandBuffer::Instantiate(ecb, prototype);\n\tUnity.Entities.EntityCommandBuffer::SetComponent(ecb, v119, Il2CppMethodInfo);\n\tUnity.Entities.EntityCommandBuffer::SetComponent(ecb, v119, Il2CppMethodInfo);\n\tUnity.Entities.EntityCommandBuffer::SetComponent(ecb, v119, gameColorInt);\n\tUnity.Entities.EntityCommandBuffer::SetComponent(ecb, v119, radius);\n\tUnity.Entities.EntityCommandBuffer::SetComponent(ecb, v119, 0xFFFF00);\n\tUnity.Entities.EntityCommandBuffer::SetComponent(ecb, v119, Il2CppMethodInfo);\n\tUnity.Entities.EntityCommandBuffer::SetComponent(ecb, v119, 0);\n\tgoto L_00A9;\nL_00A9:\n\tv202 = gameColorInt * 0xFFFFFFFFBBC49BA6;\n\tv204 = positionZ + v202;\n\tv209 = pos.y * 0x999D00000000;\n\tv210 = v209 >> 0x20;\n\tv211 = pos * 0x3285;\n\tv212 = v210 + v211;\n\tv214 = v212 + 0x5341;\n\tv215 = v214 & 0xFFFF;\n\tv220 = v215 / 0x477FFF00;\n\tv224 = v220 * 0x3B449BA6;\n\tv225 = v204 + v224;\n\t// 202 MakeStruct v236 @ AGG3C7C7C8_0_v1 (Unity.Mathematics.float3), typeof(Unity.Mathematics.float3), pos @ V0 (Unity.Mathematics.float2), pos.y (System.Single), v225 @ V2_v4 (System.Single)\n\tv237 = Unity.Transforms.LocalTransform::FromPositionRotationScale(v236, 0, v183.identity);\n\tv248 = v237.Position;\n\tUnity.Entities.EntityCommandBuffer::SetComponent(ecb, v119, &v248 @ stack_-D0_v1 (Unity.Mathematics.float3));\n\treturn v119;\nL_0060:\n\tgoto L_0069;\n")]
		public unsafe static Entity SpawnParticle(EntityCommandBuffer ecb, Entity prototype, float2 pos, float positionZ, float2 vel, int gameColorInt, float4 color, float radius, float visualSize)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SpawnUtility::SpawnParticle");
			return default;
		}

		[Token(Token = "0x60002E4")]
		[Address(RVA = "0x3C7C81C", Offset = "0x3C7C81C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = pos.y * 0x999D00000000;\n\tv7 = v5 >> 0x20;\n\tv8 = pos * 0x3285;\n\tv9 = v7 + v8;\n\tv11 = v9 + 0x5341;\n\tv12 = v11 & 0xFFFF;\n\tv17 = v12 / 0x477FFF00;\n\tv21 = v17 * 0x3B449BA6;\n\tv27 = gameColorInt * 0xFFFFFFFFBBC49BA6;\n\tv28 = baseZ + v27;\n\treturnVal1 = v28 + v21;\n\treturn returnVal1;\n")]
		public static float ComputeSpawnZ(float2 pos, float baseZ, int gameColorInt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SpawnUtility::ComputeSpawnZ");
			return default;
		}

		[Token(Token = "0x60002E5")]
		[Address(RVA = "0x3C7C888", Offset = "0x3C7C888", Length = "0x510")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\nL_FFFFFFFF:\n\tv332 = 0;\n\tgoto L_0048;\nL_0039:\n\tv455 = v213 & 1;\n\tv456 = v455 == 0;\n\tv375 = ~v456;\n\tif (v375) goto L_FFFFFFFF;\nL_003D:\n\tv332 = v332 + 1;\n\tv249 = v332 == v528;\n\tif (v249) goto L_0285;\nL_0048:\n\tv335 = v332 << 3;\n\tv336 = boundary.blockedLoopRanges + v335;\n\tv347 = *([v336 @ X14_v3+4]) < 1;\n\tif (v347) goto L_003D;\n\tv385 = *([v336 @ X14_v3+4]) - 1;\nL_FFFFFFFF:\n\tv213 = 0;\nL_FFFFFFFF:\n\tv387 = 0;\n\tgoto L_0069;\nL_005D:\n\tv205 = v387 + 1;\n\tv367 = *([v336 @ X14_v3+4]) == v205;\nL_FFFFFFFF:\n\tv385 = v387;\nL_FFFFFFFF:\n\tv387 = v205;\n\tif (v367) goto L_0039;\nL_0069:\n\tv401 = *([v336 @ X14_v3]) + v387;\n\tv402 = v401 << 3;\n\tv403 = boundary.blockedLoopVertices + v402;\n\tv404 = v385 + *([v336 @ X14_v3]);\n\tv357 = v404 << 3;\n\tv405 = boundary.blockedLoopVertices + v357;\n\tv406 = *([v403 @ X17_v5+4]) < returnVal1.y;\n\tv407 = *([v403 @ X17_v5+4]) == returnVal1.y;\n\tv410 = *([v403 @ X17_v5+4]) == *([v403 @ X17_v5+4]);\n\tv411 = returnVal1.y == returnVal1.y;\n\tv412 = v410 & v411;\n\tv413 = ~v412;\n\tv414 = v406 == v413;\n\tv195 = ~v407;\n\tv415 = v414 & v195;\n\tv417 = *([v405 @ X16_v6+4]) < returnVal1.y;\n\tv418 = *([v405 @ X16_v6+4]) == returnVal1.y;\n\tv421 = *([v405 @ X16_v6+4]) == *([v405 @ X16_v6+4]);\n\tv422 = returnVal1.y == returnVal1.y;\n\tv423 = v421 & v422;\n\tv424 = ~v423;\n\tv425 = v417 == v424;\n\tv426 = ~v425;\n\tv427 = v426 | v418;\n\tv374 = v415 ^ v427;\n\tv429 = v374 == 0;\n\tv400 = ~v429;\n\tif (v400) goto L_005D;\n\tv589 = *([v403 @ X17_v5]);\n\tv432 = *([v405 @ X16_v6]) - *([v403 @ X17_v5]);\n\tv433 = returnVal1.y - *([v403 @ X17_v5+4]);\n\tv434 = v433 * v432;\n\tv941 = *([v405 @ X16_v6+4]) - *([v403 @ X17_v5+4]);\n\tv436 = v434 / v941;\n\tv437 = *([v403 @ X17_v5]) + v436;\n\tv438 = returnVal1 < v437;\n\tv446 = ~v438;\n\tif (v446) goto L_005D;\n\tv213 = v213 ^ 1;\n\tgoto L_005D;\nL_FFFFFFFF:\n\tv936 = 0;\nL_FFFFFFFF:\n\tv586 = returnVal1;\nL_FFFFFFFF:\n\tv496 = 0;\nL_FFFFFFFF:\n\tv616 = 0x7F7FFFFF;\n\tgoto L_00C7;\nL_00B9:\n\tv528 = boundary.blockedLoopCount;\nL_00C7:\n\tv532 = v496 << 3;\n\tv533 = boundary.blockedLoopRanges + v532;\n\tv843 = *([v533 @ X9_v7+4]);\n\tv545 = *([v533 @ X9_v7+4]) < 1;\n\tif (v545) goto L_00BA;\n\tv815 = v550.zero;\n\tv552 = boundary.blockedLoopVertices;\n\tv553 = *([v533 @ X9_v7+4]) < 8;\n\tv554 = ~v553;\n\tv562 = ~v554;\n\tif (v562) goto L_FFFFFFFF;\n\tv622 = *([v533 @ X9_v7+4]) + *([v533 @ X9_v7]);\n\tv623 = v622 - 1;\n\tv633 = v623 >= *([v533 @ X9_v7]);\n\tif (v633) goto L_021D;\nL_FFFFFFFF:\n\tv706 = 0;\nL_0108:\n\t// 264 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv581 = v832 / v843;\nL_FFFFFFFF:\n\tv841 = *([v533 @ X9_v7]);\nL_FFFFFFFF:\n\tv842 = 1;\n\tgoto L_0146;\n\tgoto L_0129;\nL_FFFFFFFF:\n\tv936 = v1088;\nL_FFFFFFFF:\n\tv941 = v1177;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv936 = v1107;\nL_FFFFFFFF:\n\tv941 = v1177;\nL_0146:\n\tv879 = v843 != 1;\n\tif (v879) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv882 = 0;\n\tgoto L_014C;\nL_FFFFFFFF:\n\tv882 = v842;\n\t// 352 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv901 = radius < v616;\n\tv909 = ~v901;\n\tif (v909) goto L_0130;\nL_FFFFFFFF:\n\tv942 = v589;\nL_FFFFFFFF:\n\tv994 = 0x322BCC77;\n\tgoto L_01BB;\nL_016C:\n\t// 364 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv910 = returnVal1 - *([v883 @ X9_v15 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+v841 @ X22_v6*8]);\n\tv942 = v910 * v887;\n\t// 367 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv912 = v888 + 0x322BCC77;\n\tv913 = v942 + v941;\n\tv1047 = v913 / v912;\n\tv916 = v1047 & 0x7FFFFFFF;\n\tv919 = v916 < 0x7F800001;\n\tv920 = ~v919;\n\tv928 = ~v920;\n\tv929 = ~v928;\n\tif (v929) goto L_FFFFFFFF;\n\tv1011 = v1047 < 1f;\n\tv1010 = v1047 == 1f;\n\tv984 = v1047 == v1047;\n\tv985 = 1f == 1f;\n\tv986 = v984 & v985;\n\tv1008 = ~v986;\n\tgoto L_0191;\nL_FFFFFFFF:\n\tv1008 = 0;\nL_FFFFFFFF:\n\tv1010 = 0;\nL_FFFFFFFF:\n\tv1011 = 0;\n\tgoto L_019A;\nL_FFFFFFFF:\n\tv1047 = 1f;\n\tgoto L_01A7;\nL_01BB:\n\tgoto L_01BF;\nL_01BF:\n\tgoto L_01C0;\nL_01C0:\n\tv575 = UnityEngine.Mathf::Sqrt(v575);\n\tv1058 = v575 < 0x358637BD;\n\tv1059 = v575 == 0x358637BD;\n\tv1062 = v575 == v575;\n\tv1065 = ~v1062;\n\tv1066 = v1058 == v1065;\n\tv1067 = ~v1066;\n\tv1068 = v1067 | v1059;\nL_FFFFFFFF:\n\tv586 = v1089;\n\tif (v1068) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv586 = v1089;\n\tgoto L_01F5;\nL_01F5:\n\tgoto L_0200;\nL_0206:\n\tgoto L_0113;\nL_021D:\n\tv706 = *([v533 @ X9_v7+4]) & 0x7FFFFFF8;\nL_FFFFFFFF:\n\tv755 = v706;\nL_FFFFFFFF:\n\tv755 = v261;\nL_FFFFFFFF:\n\tv815 = v758;\n\tv695 = v706 == v843;\n\tif (v695) goto L_0108;\nL_FFFFFFFF:\n\tv815 = v832;\n\tgoto L_00F6;\nL_025F:\n\tv251 = v616 < 0x7F7FFFFF;\n\tv221 = ~v251;\n\tif (v221) goto L_0285;\n\tv712 = v936 * radius;\n\tv270 = v712 + v586;\nL_0028:\n\tv528 = boundary.blockedLoopCount;\n\tv92 = boundary.blockedLoopCount < 1;\n\tif (v92) goto L_0285;\nL_0285:\n\treturn v270;\nL_00BA:\n\tv496 = v496 + 1;\n\tv503 = v496 >= v528;\n\tif (v503) goto L_025F;\nL_00F8:\n\t;\n\tv832 = v815 + *([v552 @ X8_v12 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+v811 @ X10_v7*8]);\n\tv811 = v811 + 1;\n\tv814 = v813 - 1;\n\tv794 = v813 != 1;\nL_FFFFFFFF:\n\tv813 = v814;\nL_FFFFFFFF:\n\tv815 = v832;\n\tif (v794) goto L_00F8;\nL_0129:\n\tv1077 = ~v1100;\n\tif (v1077) goto L_FFFFFFFF;\nL_014C:\n\tv883 = boundary.blockedLoopVertices;\n\tv884 = v882 + *([v533 @ X9_v7]);\n\tv1089 = *([v883 @ X9_v15 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+v841 @ X22_v6*8]);\n\tv887 = *([v883 @ X9_v15 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+v884 @ X8_v15*8]) - *([v883 @ X9_v15 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+v841 @ X22_v6*8]);\n\tv888 = v887 * v887;\n\t// 338 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv890 = v575 < 0x322BCC77;\n\tv898 = ~v890;\n\tif (v898) goto L_016C;\nL_0130:\n\tv841 = v841 + 1;\n\tv842 = v842 + 1;\n\tv606 = v843 == 1;\n\tv843 = v843 - 1;\n\tif (v606) goto L_00B9;\nL_0191:\n\tv1014 = v1011 == v1008;\n\tv1015 = ~v1014;\n\tv1016 = v1015 | v1010;\n\tv1017 = ~v1016;\n\tif (v1017) goto L_FFFFFFFF;\nL_019A:\n\tv1048 = v1047 < 0;\n\tv935 = ~v1048;\n\tif (v935) goto L_01A7;\nL_01A7:\n\tv1117 = v887 * v459;\n\tv1089 = v1089 + v1117;\n\t// 427 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv965 = radius < v616;\n\tv949 = ~v965;\nL_FFFFFFFF:\n\tv994 = 0;\nL_FFFFFFFF:\n\tv589 = v942;\n\tif (v949) goto L_0130;\nL_FFFFFFFF:\n\tv589 = v942;\nL_FFFFFFFF:\n\tv616 = radius;\nL_0200:\n\tgoto L_0206;\nL_0113:\n\t// 275 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv1175 = 1f / v575;\n\tv1088 = v994 * v459;\n\tv1107 = v1173 * v1175;\n\tv1176 = v581 - v1089;\n\tv942 = v1088 * v1176;\n\t// 283 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv1100 = v942 < 0;\n\tv1179 = ~v1100;\n\tif (v1179) goto L_0129;\nL_0223:\n\t// 547 NotImplemented \"Instruction LD2 not yet implemented.\"\n\t// 557 NotImplemented \"Instruction LD2 not yet implemented.\"\n\tv774 = v815 + v589;\n\tv775 = v774 + v767;\n\tv776 = v775 + v766;\n\tv777 = v776 + v765;\n\tv778 = v777 + v779;\n\tv780 = v778 + v773;\n\tv781 = v780 + v772;\n\tv832 = v781 + v771;\n\tv703 = v755 - 8;\n\tv681 = v755 != 8;\nL_FFFFFFFF:\n\tv755 = v703;\nL_FFFFFFFF:\n\tv815 = v832;\n\tif (v681) goto L_0223;\nL_00F6:\n\tv811 = *([v533 @ X9_v7]) + v706;\n\tv813 = v843 - v706;\nL_FFFFFFFF:\n\tv811 = v264;\nL_FFFFFFFF:\n\tv813 = v268;\nL_FFFFFFFF:\n\tv815 = v758;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float2 ClampOutOfBlockedArea(float2 pos, float radius, ref NativeBoundaryData boundary)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SpawnUtility::ClampOutOfBlockedArea");
			return default;
		}

		[Token(Token = "0x60002E6")]
		[Address(RVA = "0x3C7CD98", Offset = "0x3C7CD98", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv60 = count - 1;\n\tv14 = count < 1;\n\tif (v14) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv55 = 0;\nL_FFFFFFFF:\n\tv56 = 0;\n\tgoto L_0020;\nL_0014:\n\tv52 = v56 + 1;\n\tv71 = count == v52;\nL_FFFFFFFF:\n\tv56 = v52;\nL_FFFFFFFF:\n\tv60 = v52;\nL_FFFFFFFF:\n\tv124 = v55;\n\tif (v71) goto L_005A;\nL_0020:\n\tv78 = start + v56;\n\tv79 = v78 << 3;\n\tv80 = verts + v79;\n\tv83 = v60 + start;\n\tv49 = v83 << 3;\n\tv84 = verts + v49;\n\tv85 = *([v80 @ X13_v4+4]) < point.y;\n\tv86 = *([v80 @ X13_v4+4]) == point.y;\n\tv89 = *([v80 @ X13_v4+4]) == *([v80 @ X13_v4+4]);\n\tv90 = point.y == point.y;\n\tv91 = v89 & v90;\n\tv92 = ~v91;\n\tv93 = v85 == v92;\n\tv40 = ~v86;\n\tv94 = v93 & v40;\n\tv96 = *([v84 @ X12_v5+4]) < point.y;\n\tv97 = *([v84 @ X12_v5+4]) == point.y;\n\tv100 = *([v84 @ X12_v5+4]) == *([v84 @ X12_v5+4]);\n\tv101 = point.y == point.y;\n\tv102 = v100 & v101;\n\tv103 = ~v102;\n\tv104 = v96 == v103;\n\tv105 = ~v104;\n\tv106 = v105 | v97;\n\tv37 = v94 ^ v106;\n\tv108 = v37 == 0;\n\tv31 = ~v108;\n\tif (v31) goto L_0014;\n\tv140 = *([v84 @ X12_v5]) - *([v80 @ X13_v4]);\n\tv141 = point.y - *([v80 @ X13_v4+4]);\n\tv142 = v141 * v140;\n\tv143 = *([v84 @ X12_v5+4]) - *([v80 @ X13_v4+4]);\n\tv144 = v142 / v143;\n\tv145 = *([v80 @ X13_v4]) + v144;\n\tv146 = point < v145;\n\tv154 = ~v146;\n\tif (v154) goto L_0014;\n\tv55 = v55 ^ 1;\n\tgoto L_0014;\nL_FFFFFFFF:\n\tv124 = 0;\nL_005A:\n\treturnVal1 = v124 & 1;\n\treturn returnVal1;\n")]
		private static bool IsPointInLoop(NativeArray<float2> verts, float2 point, int start, int count)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SpawnUtility::IsPointInLoop");
			return default;
		}

		[Token(Token = "0x60002E7")]
		[Address(RVA = "0x3C7CE34", Offset = "0x3C7CE34", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = b - v44;\n\tv7 = b.y - v44.y;\n\tv8 = v6 * v6;\n\tv9 = v7 * v7;\n\tv10 = v8 + v9;\n\tv14 = v10 < 0x322BCC77;\n\tif (v14) goto L_0055;\n\tv22 = p - v44;\n\tv23 = p.y - v44.y;\n\tv24 = v22 * v6;\n\tv25 = v23 * v7;\n\tv26 = v24 + v25;\n\tv106 = v26 / v10;\n\tv29 = v106 & 0x7FFFFFFF;\n\tv32 = v29 < 0x7F800001;\n\tv33 = ~v32;\n\tv42 = ~v33;\n\tv43 = ~v42;\n\tif (v43) goto L_FFFFFFFF;\n\tv95 = v106 < 1f;\n\tv94 = v106 == 1f;\n\tv83 = v106 == v106;\n\tv84 = 1f == 1f;\n\tv85 = v83 & v84;\n\tv91 = ~v85;\n\tgoto L_0039;\nL_FFFFFFFF:\n\tv91 = 0;\nL_FFFFFFFF:\n\tv94 = 0;\nL_FFFFFFFF:\n\tv95 = 0;\n\tgoto L_0042;\nL_FFFFFFFF:\n\tv106 = 1f;\nL_FFFFFFFF:\n\tv106 = 0;\n\tgoto L_004F;\nL_0055:\n\treturn v45;\nL_0039:\n\tv96 = v95 == v91;\n\tv97 = ~v96;\n\tv50 = v97 | v94;\n\tv98 = ~v50;\n\tif (v98) goto L_FFFFFFFF;\nL_0042:\n\tv71 = v106 < 0;\n\tv47 = ~v71;\n\tif (v47) goto L_004F;\nL_004F:\n\tv76 = v6 * v106;\n\tv45 = v44 + v76;\n")]
		private static float2 ClosestPointOnSegment(float2 p, float2 a, float2 b)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SpawnUtility::ClosestPointOnSegment");
			return default;
		}
	}
}
