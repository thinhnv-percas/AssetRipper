using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed
{
	[Token(Token = "0x2000004")]
	public static class GameSpeedResolver
	{
		[Token(Token = "0x4000006")]
		public const float MinClock = 1f;

		[Token(Token = "0x6000003")]
		[Address(RVA = "0x7AF0F64", Offset = "0x7AF0F64", Length = "0x1E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\nL_002B:\n\tv382 = baseline.conveyor;\n\tv198 = active->klass;\n\tv315 = active->klass->interface_offsets_count;\n\tv155 = *([v198 @ X8_v16 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed.SpeedProfile>>)+12E]) == 0;\n\tv190 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed.SpeedProfile>;\n\tv200 = 0;\n\tv68 = v162;\n\tv193 = baseline.conveyor;\n\tv143 = 0;\n\tif (v155) goto L_0051;\nL_0032:\n\tv314 = *([v198 @ X8_v16 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed.SpeedProfile>>)+B0]) + 8;\n\tv314 = v314 + 0x10;\n\tv232 = v315 - 1;\n\tv212 = v315 != 1;\n\tv68 = *([v195 @ X0_v9+14]);\n\tv193 = v382;\n\tv143 = v200;\n\tv315 = v232;\n\tif (v212) goto L_0038;\nL_0051:\n\tv328 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed.SpeedProfile>::get_Count(active);\n\tv339 = v143 < v328;\n\tif (v339) goto L_0073;\n\tv382 = v193;\n\tgoto L_00C6;\nL_0060:\n\tv342 = *([v314 @ X10_v14]) << 4;\n\tv343 = v198 + v342;\n\tv344 = v343 + 0x138;\n\t*([v344 @ X0_v23])(v348, active, *([v344 @ X0_v23+8]), v166, v35, v36, v37, v38, v39, *([v195 @ X0_v9+14]), v41, v42, v43, v44, v45, v46, v47);\n\tv358 = v200 >= v348;\n\tv68 = *([v195 @ X0_v9+14]);\n\tv193 = v382;\n\tv143 = v200;\n\tif (v358) goto L_00C6;\nL_0073:\n\tv377 = active->klass;\n\tv414 = active->klass->interface_offsets_count;\n\tv379 = *([v377 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed.SpeedProfile>>)+12E]) == 0;\n\tif (v379) goto L_0095;\n\tv115 = *([v377 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed.SpeedProfile>>)+B0]) + 8;\n\tv115 = v115 + 0x10;\n\tv400 = v414 - 1;\n\tv390 = v414 != 1;\n\tv414 = v400;\n\tif (v390) goto L_007E;\nL_0095:\n\tv166 = *([v403 @ X0_v11+8]);\n\tv195 = System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed.SpeedProfile>::get_Item(active, v143);\n\tv417 = v195 == 0;\n\tv137 = ~v417;\n\tif (v137) goto L_00A9;\n\tgoto L_00DD;\nL_009E:\n\tv72 = *([v115 @ X10_v8]) << 4;\n\tv419 = v377 + v72;\n\tv420 = v419 + 0x138;\n\tv166 = *([v420 @ X0_v14+8]);\n\t*([v420 @ X0_v14])(v195, active, v143, *([v420 @ X0_v14+8]), v35, v36, v37, v38, v39, v68, v41, v42, v43, v44, v45, v46, v47);\nL_00A9:\n\tv181 = *([v195 @ X0_v9+10]) < v193;\n\tv179 = *([v195 @ X0_v9+10]) == v193;\n\tv435 = *([v195 @ X0_v9+10]) == *([v195 @ X0_v9+10]);\n\tv177 = v193 == v193;\n\tv183 = v435 & v177;\n\tv171 = ~v183;\n\tv436 = v181 == v171;\n\tv161 = ~v179;\n\tv169 = v436 & v161;\n\tv159 = ~v169;\n\tif (v159) goto L_00BB;\n\tv193 = *([v195 @ X0_v9+10]);\n\tgoto L_00BB;\n\tv68 = *([v195 @ X0_v9+14]);\n\tv143 = v200;\n\tgoto L_0051;\nL_00C6:\n\tv387 = new _game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed.SpeedProfile();\n\tv387.conveyor = 0f;\n\tv387.mold = 1f;\n\tSystem.Object::.ctor(v387);\n\tv387.conveyor = v382;\n\tv387.sand = baseline.sand;\n\treturn v387;\nL_00DD:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_0038:\n\tv320 = *([v314 @ X10_v14-8]) == v190;\n\tif (v320) goto L_0060;\nL_007E:\n\tv99 = *([v115 @ X10_v8-8]) == System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed.SpeedProfile>;\n\tif (v99) goto L_009E;\nL_00BB:\n\t// 187 NotImplemented \"Instruction FCMGT not yet implemented.\"\n\t// 188 NotImplemented \"Instruction BIT not yet implemented.\"\n\tv200 = v143 + 1;\n\tv198 = active->klass;\n\tv315 = active->klass->interface_offsets_count;\n\tv439 = *([v198 @ X8_v16 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed.SpeedProfile>>)+12E]) == 0;\n\tv197 = ~v439;\n\tv190 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed.SpeedProfile>;\n\tv382 = v193;\n\tif (v197) goto L_0032;\n")]
		public static SpeedProfile ResolveEffective(SpeedProfile baseline, IReadOnlyList<SpeedProfile> active)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameSpeedResolver::ResolveEffective");
			return default;
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x7AF1164", Offset = "0x7AF1164", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001E:\n\tv52 = v64 == 1f;\n\tv53 = v64 < 1f;\n\tv54 = ~v53;\n\tv59 = ~v54;\n\tv60 = v59 | v52;\n\tv61 = ~v60;\n\tif (v61) goto L_002D;\n\tgoto L_002D;\nL_FFFFFFFF:\n\treturnVal1 = 0xFFFFFFFF80000002;\n\tgoto L_0049;\nL_FFFFFFFF:\n\treturnVal1 = v67;\nL_001A:\n\tgoto L_001E;\nL_002D:\n\tv65 = UnityEngine.Mathf::Ceil(1f);\n\tv67 = 1f + 2;\n\tv71 = v65 == 0x7F800000;\n\tv80 = ~v71;\n\tif (v80) goto L_FFFFFFFF;\nL_0049:\n\treturn returnVal1;\n")]
		public static int DeriveMaxSubSteps(float clock)
		{
			//IL_007e: Expected I4, but got F4
			float num = default(float);
			bool flag = num == 1f;
			bool flag2 = num < 1f;
			bool flag3 = !flag2;
			bool flag4 = !flag3;
			if (flag4 || flag)
			{
			}
			float num2 = Mathf.Ceil(1f);
			float num3 = 1f + 3E-45f;
			if (num2 == 1f / 0f)
			{
				return -2147483646;
			}
			return (int)num3;
		}

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x7AF11F0", Offset = "0x7AF11F0", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = baselineConveyor == 0;\n\tv6 = baselineConveyor < 0;\n\tv7 = ~v6;\n\tv10 = ~v7;\n\tv11 = v10 | v5;\n\treturnVal1 = 0;\n\tif (v11) goto L_000E;\n\tv12 = effectiveConveyor / baselineConveyor;\n\treturnVal1 = UnityEngine.Mathf::Max(v12, 0f);\nL_000E:\n\treturn returnVal1;\n")]
		public static float ConveyorSpeedFactor(float effectiveConveyor, float baselineConveyor)
		{
			bool flag = baselineConveyor == 0f;
			bool flag2 = baselineConveyor < 0f;
			bool flag3 = !flag2;
			bool flag4 = !flag3;
			bool flag5 = flag4 || flag;
			float result = 0f;
			if (!flag5)
			{
				float a = effectiveConveyor / baselineConveyor;
				result = Mathf.Max(a, 0f);
			}
			return result;
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0x7AF1210", Offset = "0x7AF1210", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_0026:\n\tv65 = effective.sand < effective.conveyor;\n\tv66 = effective.sand == effective.conveyor;\n\tv69 = effective.sand == effective.sand;\n\tv70 = effective.conveyor == effective.conveyor;\n\tv71 = v69 & v70;\n\tv72 = ~v71;\n\tv73 = v65 == v72;\n\tv74 = ~v66;\n\tv75 = v73 & v74;\n\tv76 = ~v75;\n\tif (v76) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv165 = effective.sand;\n\tgoto L_0037;\nL_FFFFFFFF:\n\tv165 = effective.conveyor;\nL_FFFFFFFF:\n\tv165 = effective.mold;\n\tgoto L_0049;\nL_FFFFFFFF:\n\tv165 = 1f;\n\tgoto L_0058;\nL_FFFFFFFF:\n\tv121 = 0xFFFFFFFF80000002;\n\tgoto L_006D;\nL_FFFFFFFF:\n\tv121 = v168;\nL_FFFFFFFF:\n\t;\n\tgoto L_0026;\nL_0037:\n\tv140 = effective.mold < v165;\n\tv141 = effective.mold == v165;\n\tv144 = effective.mold == effective.mold;\n\tv145 = v165 == v165;\n\tv146 = v144 & v145;\n\tv147 = ~v146;\n\tv148 = v140 == v147;\n\tv94 = ~v141;\n\tv97 = v148 & v94;\n\tv149 = ~v97;\n\tif (v149) goto L_0049;\nL_0049:\n\tv154 = v165 < 1f;\n\tv162 = ~v154;\n\tif (v162) goto L_0058;\nL_0058:\n\tv167 = UnityEngine.Mathf::Ceil(v165);\n\tv168 = v165 + 2;\n\tv112 = v167 == 0x7F800000;\n\tv91 = ~v112;\n\tif (v91) goto L_FFFFFFFF;\nL_006D:\n\tv82 = effective.mold / v165;\n\treturnBuffer.GroupTimeMultiplier = v165;\n\treturnBuffer.MaxSubSteps = v121;\n\t// 113 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv89 = effective.conveyor / v165;\n\t// 115 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\treturnBuffer.SandScale = v89;\n\treturnBuffer.MoldScale = v82;\n\treturn returnBuffer;\n")]
		public static ResolvedGameSpeed ToApplied(SpeedProfile effective)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameSpeedResolver::ToApplied");
			return default;
		}
	}
}
