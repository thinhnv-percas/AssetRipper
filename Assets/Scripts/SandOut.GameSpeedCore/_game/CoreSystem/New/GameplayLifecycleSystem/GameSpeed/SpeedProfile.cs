using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed
{
	[Serializable]
	[Token(Token = "0x2000006")]
	public class SpeedProfile
	{
		[Token(Token = "0x400000C")]
		[FieldOffset(Offset = "0x10")]
		public float conveyor;

		[Token(Token = "0x400000D")]
		[FieldOffset(Offset = "0x14")]
		public float sand;

		[Token(Token = "0x400000E")]
		[FieldOffset(Offset = "0x18")]
		public float mold;

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x7AF130C", Offset = "0x7AF130C", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tv45 = new _game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed.SpeedProfile();\n\tv45.conveyor = 0f;\n\tv45.mold = 1f;\n\tSystem.Object::.ctor(v45);\n\tv45.conveyor = v;\n\tv45.sand = v;\n\tv45.mold = v;\n\treturn v45;\n")]
		public static SpeedProfile Uniform(float v)
		{
			SpeedProfile speedProfile = new SpeedProfile();
			speedProfile.conveyor = 0f;
			speedProfile.mold = 1f;
			speedProfile.conveyor = v;
			speedProfile.sand = v;
			speedProfile.mold = v;
			return speedProfile;
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x7AF1388", Offset = "0x7AF1388", Length = "0x1B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv203 = p.conveyor;\n\tv53 = p.conveyor & 0x7FFFFFFF;\n\tv55 = v53 < 0x7F800000;\n\tv56 = ~v55;\n\tv57 = v53 - 0x7F800000;\n\tv59 = v57 == 0;\n\tv64 = ~v59;\n\tv65 = v56 & v64;\n\tif (v65) goto L_FFFFFFFF;\n\tv120 = p.conveyor & 0x7FFFFFFF;\n\tv121 = v120 - 1;\n\tv123 = v121 < 0x7FFFFF;\n\tv124 = ~v123;\n\tv132 = ~v124;\n\tv134 = v120 - 0x800000;\n\tv135 = v134 >> 0x18;\n\tv136 = v135 < 0x7F;\n\tv137 = ~v136;\n\tv145 = ~v137;\n\tv157 = p.conveyor < 0;\n\tif (v157) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv183 = 0;\n\tgoto L_005E;\nL_FFFFFFFF:\n\tv183 = v145;\nL_FFFFFFFF:\n\tv162 = 0;\n\tgoto L_0066;\nL_FFFFFFFF:\n\tv162 = v132;\nL_FFFFFFFF:\n\tv411 = v162;\n\tgoto L_0074;\nL_FFFFFFFF:\n\tv411 = 1;\nL_FFFFFFFF:\n\tv203 = 1f;\n\tv223 = p.sand & 0x7FFFFFFF;\n\tv224 = v223 - 1;\n\tv226 = v224 < 0x7FFFFF;\n\tv227 = ~v226;\n\tv235 = ~v227;\n\tv237 = v223 - 0x800000;\n\tv238 = v237 >> 0x18;\n\tv239 = v238 < 0x7F;\n\tv240 = ~v239;\n\tv248 = ~v240;\n\tv260 = p.sand < 0;\n\tif (v260) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv286 = 0;\n\tgoto L_00BF;\nL_FFFFFFFF:\n\tv286 = v248;\nL_FFFFFFFF:\n\tv265 = 0;\n\tgoto L_00C7;\nL_FFFFFFFF:\n\tv265 = v235;\nL_FFFFFFFF:\n\tv429 = v265;\n\tgoto L_00D5;\nL_FFFFFFFF:\n\tv429 = 1;\nL_FFFFFFFF:\n\tv308 = 1f;\n\tv338 = p.mold & 0x7FFFFFFF;\n\tv339 = v338 - 1;\n\tv341 = v339 < 0x7FFFFF;\n\tv342 = ~v341;\n\tv350 = ~v342;\n\tv352 = v338 - 0x800000;\n\tv353 = v352 >> 0x18;\n\tv354 = v353 < 0x7F;\n\tv355 = ~v354;\n\tv363 = ~v355;\n\tv375 = p.mold < 0;\n\tif (v375) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv401 = 0;\n\tgoto L_0120;\nL_FFFFFFFF:\n\tv401 = v363;\nL_FFFFFFFF:\n\tv380 = 0;\n\tgoto L_0128;\nL_FFFFFFFF:\n\tv380 = v350;\nL_FFFFFFFF:\n\tv443 = v380;\n\tgoto L_0136;\nL_FFFFFFFF:\n\tv443 = 1;\nL_FFFFFFFF:\n\tv109 = 1f;\nL_0017:\n\tv45 = new _game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed.SpeedProfile();\n\tv45.conveyor = 0f;\n\tv45.mold = 1f;\n\tSystem.Object::.ctor(v45);\n\tv50 = p == 0;\n\tif (v50) goto L_014C;\nL_014C:\n\treturn v45;\nL_005E:\n\tv221 = v203 < 0;\n\tif (v221) goto L_FFFFFFFF;\nL_0066:\n\tv327 = v120 - 0x7F800000;\n\tv329 = v327 == 0;\n\tv334 = ~v329;\n\tv159 = ~v334;\n\tif (v159) goto L_FFFFFFFF;\nL_0074:\n\tv185 = v411 | v183;\n\tv165 = v185 != 1;\n\tif (v165) goto L_0081;\nL_00BF:\n\tv336 = v308 < 0;\n\tif (v336) goto L_FFFFFFFF;\nL_00C7:\n\tv415 = v223 - 0x7F800000;\n\tv417 = v415 == 0;\n\tv422 = ~v417;\n\tv262 = ~v422;\n\tif (v262) goto L_FFFFFFFF;\nL_00D5:\n\tv288 = v429 | v286;\n\tv268 = v288 != 1;\n\tif (v268) goto L_00E2;\nL_0120:\n\tv424 = v109 < 0;\n\tif (v424) goto L_FFFFFFFF;\nL_0128:\n\tv433 = v338 - 0x7F800000;\n\tv435 = v433 == 0;\n\tv440 = ~v435;\n\tv377 = ~v440;\n\tif (v377) goto L_FFFFFFFF;\nL_0136:\n\tv403 = v443 | v401;\n\tv383 = v403 != 1;\n\tif (v383) goto L_0143;\nL_0081:\n\tv45.conveyor = v203;\n\tv308 = p.sand;\n\tv207 = p.sand & 0x7FFFFFFF;\n\tv209 = v207 < 0x7F800000;\n\tv210 = ~v209;\n\tv211 = v207 - 0x7F800000;\n\tv213 = v211 == 0;\n\tv218 = ~v213;\n\tv219 = v210 & v218;\n\tif (v219) goto L_FFFFFFFF;\nL_00E2:\n\tv45.sand = v308;\n\tv109 = p.mold;\n\tv312 = p.mold & 0x7FFFFFFF;\n\tv314 = v312 < 0x7F800000;\n\tv315 = ~v314;\n\tv316 = v312 - 0x7F800000;\n\tv318 = v316 == 0;\n\tv323 = ~v318;\n\tv324 = v315 & v323;\n\tif (v324) goto L_FFFFFFFF;\nL_0143:\n\tv45.mold = v109;\n")]
		public static SpeedProfile Sanitized(SpeedProfile p)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SpeedProfile::Sanitized");
			return default;
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x7AF1538", Offset = "0x7AF1538", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = returnVal1 & 0x7FFFFFFF;\n\tv4 = v2 < 0x7F800000;\n\tv5 = ~v4;\n\tv6 = v2 - 0x7F800000;\n\tv8 = v6 == 0;\n\tv13 = ~v8;\n\tv14 = v5 & v13;\n\tif (v14) goto L_005F;\n\tv16 = returnVal1 & 0x7FFFFFFF;\n\tv17 = v16 - 1;\n\tv19 = v17 < 0x7FFFFF;\n\tv20 = ~v19;\n\tv28 = ~v20;\n\tv30 = v16 - 0x800000;\n\tv31 = v30 >> 0x18;\n\tv32 = v31 < 0x7F;\n\tv33 = ~v32;\n\tv41 = ~v33;\n\tv53 = returnVal1 < 0;\n\tif (v53) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv83 = 0;\n\tgoto L_003C;\nL_FFFFFFFF:\n\tv83 = v41;\nL_FFFFFFFF:\n\tv60 = 0;\n\tgoto L_0044;\nL_FFFFFFFF:\n\tv60 = v28;\nL_FFFFFFFF:\n\tv121 = v60;\n\tgoto L_0052;\nL_FFFFFFFF:\n\tv121 = 1;\nL_003C:\n\tv106 = returnVal1 < 0;\n\tif (v106) goto L_FFFFFFFF;\nL_0044:\n\tv111 = v16 - 0x7F800000;\n\tv113 = v111 == 0;\n\tv118 = ~v113;\n\tv55 = ~v118;\n\tif (v55) goto L_FFFFFFFF;\nL_0052:\n\tv85 = v121 | v83;\n\tv65 = v85 != 1;\n\tif (v65) goto L_005F;\nL_005F:\n\treturn 1f;\n")]
		private static float San(float v)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SpeedProfile::San");
			return default;
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x7AF114C", Offset = "0x7AF114C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.conveyor = 0f;\n\tthis.mold = 1f;\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SpeedProfile()
		{
			conveyor = 0f;
			mold = 1f;
		}
	}
}
