using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Token(Token = "0x2000074")]
	public static class FsmUtility
	{
		[Token(Token = "0x200009A")]
		public static class BitConverter
		{
			[Token(Token = "0x60006B1")]
			[Address(RVA = "0xCB8C58", Offset = "0xCB8C58", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EAF3B8]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, startIndex, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023699]) = v41;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<System.BitConverter>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v44, startIndex, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv52 = System.BitConverter;\nL_0024:\n\tv57 = ~v55.IsLittleEndian;\n\tv58 = ~v57;\n\tif (v58) goto L_0030;\n\tSystem.Array::Reverse(value, startIndex, 4);\nL_0030:\n\tgoto L_003F;\n\tv72 = *([v67 @ X0_v4+E0]);\n\tv73 = v72 == 0;\n\tv74 = ~v73;\n\tgoto L_003F;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v67, v65, v66, v64, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003F:\n\treturnVal1 = System.BitConverter::ToInt32(value, startIndex);\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static int ToInt32(byte[] value, int startIndex)
			{
				if (!System.BitConverter.IsLittleEndian)
				{
					Array.Reverse((Array)value, startIndex, 4);
				}
				return System.BitConverter.ToInt32(value, startIndex);
			}

			[Token(Token = "0x60006B2")]
			[Address(RVA = "0xCB8A10", Offset = "0xCB8A10", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EFDA98]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, startIndex, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202369A]) = v41;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<System.BitConverter>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v44, startIndex, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv52 = System.BitConverter;\nL_0024:\n\tv57 = ~v55.IsLittleEndian;\n\tv58 = ~v57;\n\tif (v58) goto L_0030;\n\tSystem.Array::Reverse(value, startIndex, 4);\nL_0030:\n\tgoto L_003F;\n\tv72 = *([v67 @ X0_v4+E0]);\n\tv73 = v72 == 0;\n\tv74 = ~v73;\n\tgoto L_003F;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v67, v65, v66, v64, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003F:\n\treturnVal1 = System.BitConverter::ToSingle(value, startIndex);\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static float ToSingle(byte[] value, int startIndex)
			{
				if (!System.BitConverter.IsLittleEndian)
				{
					Array.Reverse((Array)value, startIndex, 4);
				}
				return System.BitConverter.ToSingle(value, startIndex);
			}

			[Token(Token = "0x60006B3")]
			[Address(RVA = "0xCB8AC4", Offset = "0xCB8AC4", Length = "0x78")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1ED2688]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, startIndex, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202369B]) = v41;\nL_001B:\n\tgoto L_002A;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_002A;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, startIndex, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002A:\n\treturnVal1 = System.BitConverter::ToBoolean(value, startIndex);\n\treturn returnVal1;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static bool ToBoolean(byte[] value, int startIndex)
			{
				return System.BitConverter.ToBoolean(value, startIndex);
			}

			[Token(Token = "0x60006B4")]
			[Address(RVA = "0xCB7928", Offset = "0xCB7928", Length = "0xC4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EDFFD8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202369C]) = v38;\nL_0019:\n\tgoto L_0023;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<System.BitConverter>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0023;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv51 = System.BitConverter;\n\tv54 = *([v51 @ X0_v15+12E]);\nL_0023:\n\tv57 = ~v55.IsLittleEndian;\n\tif (v57) goto L_0038;\n\tgoto L_0034;\n\tv63 = *([v50 @ X0_v3 (Il2CppClass<System.BitConverter>)+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_0034;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0034:\n\treturnVal1 = System.BitConverter::GetBytes(value);\n\treturn returnVal1;\nL_0038:\n\tgoto L_0040;\n\tv77 = *([v50 @ X0_v3 (Il2CppClass<System.BitConverter>)+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_0040;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0040:\n\tv86 = System.BitConverter::GetBytes(value);\n\tSystem.Array::Reverse(v86);\n\treturn v86;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static byte[] GetBytes(bool value)
			{
				if (System.BitConverter.IsLittleEndian)
				{
					return System.BitConverter.GetBytes(value);
				}
				byte[] bytes = System.BitConverter.GetBytes(value);
				Array.Reverse((Array)bytes);
				return bytes;
			}

			[Token(Token = "0x60006B5")]
			[Address(RVA = "0xCB7AE0", Offset = "0xCB7AE0", Length = "0xC4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EDC218]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202369D]) = v38;\nL_0019:\n\tgoto L_0023;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<System.BitConverter>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0023;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv51 = System.BitConverter;\n\tv54 = *([v51 @ X0_v15+12E]);\nL_0023:\n\tv57 = ~v55.IsLittleEndian;\n\tif (v57) goto L_0038;\n\tgoto L_0034;\n\tv63 = *([v50 @ X0_v3 (Il2CppClass<System.BitConverter>)+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_0034;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0034:\n\treturnVal1 = System.BitConverter::GetBytes(value);\n\treturn returnVal1;\nL_0038:\n\tgoto L_0040;\n\tv77 = *([v50 @ X0_v3 (Il2CppClass<System.BitConverter>)+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_0040;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0040:\n\tv86 = System.BitConverter::GetBytes(value);\n\tSystem.Array::Reverse(v86);\n\treturn v86;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static byte[] GetBytes(int value)
			{
				if (System.BitConverter.IsLittleEndian)
				{
					return System.BitConverter.GetBytes(value);
				}
				byte[] bytes = System.BitConverter.GetBytes(value);
				Array.Reverse((Array)bytes);
				return bytes;
			}

			[Token(Token = "0x60006B6")]
			[Address(RVA = "0xCB7858", Offset = "0xCB7858", Length = "0xD0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB70D0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, value, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202369E]) = v38;\nL_0019:\n\tgoto L_0023;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<System.BitConverter>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0023;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v41, v21, v22, v23, v24, v25, v26, v27, value, v28, v29, v30, v31, v32, v33, v34);\n\tv51 = System.BitConverter;\n\tv54 = *([v51 @ X0_v15+12E]);\nL_0023:\n\tv57 = ~v55.IsLittleEndian;\n\tif (v57) goto L_0038;\n\tgoto L_0034;\n\tv63 = *([v50 @ X0_v3 (Il2CppClass<System.BitConverter>)+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_0034;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v50, v21, v22, v23, v24, v25, v26, v27, value, v28, v29, v30, v31, v32, v33, v34);\nL_0034:\n\treturnVal1 = System.BitConverter::GetBytes(value);\n\treturn returnVal1;\nL_0038:\n\tgoto L_0040;\n\tv77 = *([v50 @ X0_v3 (Il2CppClass<System.BitConverter>)+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_0040;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v50, v21, v22, v23, v24, v25, v26, v27, value, v28, v29, v30, v31, v32, v33, v34);\nL_0040:\n\tv86 = System.BitConverter::GetBytes(value);\n\tSystem.Array::Reverse(v86);\n\treturn v86;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static byte[] GetBytes(float value)
			{
				if (System.BitConverter.IsLittleEndian)
				{
					return System.BitConverter.GetBytes(value);
				}
				byte[] bytes = System.BitConverter.GetBytes(value);
				Array.Reverse((Array)bytes);
				return bytes;
			}
		}

		[Token(Token = "0x40002F8")]
		private static UTF8Encoding encoding;

		[Token(Token = "0x170001B7")]
		public static UTF8Encoding Encoding
		{
			[Token(Token = "0x60005CA")]
			[Address(RVA = "0xCB6EDC", Offset = "0xCB6EDC", Length = "0x80")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1EAD2C0]);\n\tv17 = *([v16 @ X8_v11]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202366F]) = v37;\nL_0016:\n\tv54 = v41.encoding;\n\tv43 = v41.encoding == 0;\n\tv44 = ~v43;\n\tif (v44) goto L_002A;\n\tv48 = new System.Text.UTF8Encoding();\n\tSystem.Text.UTF8Encoding::.ctor(v48);\n\tv53.encoding = v48;\nL_002A:\n\treturn v54;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				UTF8Encoding result = encoding;
				if (encoding == null)
				{
					result = (encoding = new UTF8Encoding());
				}
				return result;
			}
		}

		[Obsolete]
		[Token(Token = "0x60005CB")]
		[Address(RVA = "0xCB6F5C", Offset = "0xCB6F5C", Length = "0x42C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1F0FA70]);\n\tv21 = *([v20 @ X8_v63]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023670]) = v40;\nL_0014:\n\tv41 = variable == 0;\n\tif (v41) goto L_FFFFFFFF;\n\tv44 = System.Object::GetType(variable);\n\tgoto L_002C;\n\tv299 = *([v50 @ X8_v4+E0]);\n\tv300 = v299 == 0;\n\tv301 = ~v300;\n\tif (v301) goto L_002C;\n\tv306 = v50;\n\tv303 = \"il2cpp_codegen_runtime_class_init\"(v306, v43, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002C:\n\tv305 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmMaterial);\n\tv130 = v44 == v305;\n\tif (v130) goto L_FFFFFFFF;\n\tgoto L_0046;\n\tv313 = *([v309 @ X0_v10+E0]);\n\tv314 = v313 == 0;\n\tv315 = ~v314;\n\tif (v315) goto L_0046;\n\tv317 = \"il2cpp_codegen_runtime_class_init\"(v309, v217, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv319 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmTexture);\n\tv131 = v44 == v319;\n\tif (v131) goto L_FFFFFFFF;\n\tgoto L_0060;\n\tv326 = *([v322 @ X0_v15+E0]);\n\tv327 = v326 == 0;\n\tv328 = ~v327;\n\tif (v328) goto L_0060;\n\tv330 = \"il2cpp_codegen_runtime_class_init\"(v322, v218, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0060:\n\tv332 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmFloat);\n\tv132 = v44 == v332;\n\tif (v132) goto L_FFFFFFFF;\n\tgoto L_007A;\n\tv339 = *([v335 @ X0_v20+E0]);\n\tv340 = v339 == 0;\n\tv341 = ~v340;\n\tif (v341) goto L_007A;\n\tv343 = \"il2cpp_codegen_runtime_class_init\"(v335, v219, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_007A:\n\tv345 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmInt);\n\tv133 = v44 == v345;\n\tif (v133) goto L_FFFFFFFF;\n\tgoto L_0094;\n\tv352 = *([v348 @ X0_v25+E0]);\n\tv353 = v352 == 0;\n\tv354 = ~v353;\n\tif (v354) goto L_0094;\n\tv356 = \"il2cpp_codegen_runtime_class_init\"(v348, v220, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0094:\n\tv358 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmBool);\n\tv134 = v44 == v358;\n\tif (v134) goto L_FFFFFFFF;\n\tgoto L_00AE;\n\tv365 = *([v361 @ X0_v30+E0]);\n\tv366 = v365 == 0;\n\tv367 = ~v366;\n\tif (v367) goto L_00AE;\n\tv369 = \"il2cpp_codegen_runtime_class_init\"(v361, v221, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00AE:\n\tv371 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmString);\n\tv135 = v44 == v371;\n\tif (v135) goto L_FFFFFFFF;\n\tgoto L_00C8;\n\tv378 = *([v374 @ X0_v35+E0]);\n\tv379 = v378 == 0;\n\tv380 = ~v379;\n\tif (v380) goto L_00C8;\n\tv382 = \"il2cpp_codegen_runtime_class_init\"(v374, v222, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00C8:\n\tv384 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmGameObject);\n\tv136 = v44 == v384;\n\tif (v136) goto L_FFFFFFFF;\n\tgoto L_00E2;\n\tv391 = *([v387 @ X0_v40+E0]);\n\tv392 = v391 == 0;\n\tv393 = ~v392;\n\tif (v393) goto L_00E2;\n\tv395 = \"il2cpp_codegen_runtime_class_init\"(v387, v223, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00E2:\n\tv397 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmVector2);\n\tv137 = v44 == v397;\n\tif (v137) goto L_FFFFFFFF;\n\tgoto L_00FC;\n\tv404 = *([v400 @ X0_v45+E0]);\n\tv405 = v404 == 0;\n\tv406 = ~v405;\n\tif (v406) goto L_00FC;\n\tv408 = \"il2cpp_codegen_runtime_class_init\"(v400, v224, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00FC:\n\tv410 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmVector3);\n\tv138 = v44 == v410;\n\tif (v138) goto L_FFFFFFFF;\n\tgoto L_0116;\n\tv417 = *([v413 @ X0_v50+E0]);\n\tv418 = v417 == 0;\n\tv419 = ~v418;\n\tif (v419) goto L_0116;\n\tv421 = \"il2cpp_codegen_runtime_class_init\"(v413, v225, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0116:\n\tv423 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmRect);\n\tv139 = v44 == v423;\n\tif (v139) goto L_FFFFFFFF;\n\tgoto L_0130;\n\tv430 = *([v426 @ X0_v55+E0]);\n\tv431 = v430 == 0;\n\tv432 = ~v431;\n\tif (v432) goto L_0130;\n\tv434 = \"il2cpp_codegen_runtime_class_init\"(v426, v226, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0130:\n\tv436 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmQuaternion);\n\tv140 = v44 == v436;\n\tif (v140) goto L_FFFFFFFF;\n\tgoto L_014A;\n\tv443 = *([v439 @ X0_v60+E0]);\n\tv444 = v443 == 0;\n\tv445 = ~v444;\n\tif (v445) goto L_014A;\n\tv447 = \"il2cpp_codegen_runtime_class_init\"(v439, v227, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_014A:\n\tv449 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmColor);\n\tv141 = v44 == v449;\n\tif (v141) goto L_FFFFFFFF;\n\tgoto L_0164;\n\tv456 = *([v452 @ X0_v65+E0]);\n\tv457 = v456 == 0;\n\tv458 = ~v457;\n\tif (v458) goto L_0164;\n\tv460 = \"il2cpp_codegen_runtime_class_init\"(v452, v228, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0164:\n\tv462 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmObject);\n\tv142 = v44 == v462;\n\tif (v142) goto L_FFFFFFFF;\n\tgoto L_017E;\n\tv469 = *([v465 @ X0_v70+E0]);\n\tv470 = v469 == 0;\n\tv471 = ~v470;\n\tif (v471) goto L_017E;\n\tv473 = \"il2cpp_codegen_runtime_class_init\"(v465, v229, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_017E:\n\tv475 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmEnum);\n\tv128 = v44 == v475;\n\tif (v128) goto L_FFFFFFFF;\n\tgoto L_0198;\n\tv482 = *([v478 @ X0_v75+E0]);\n\tv483 = v482 == 0;\n\tv484 = ~v483;\n\tif (v484) goto L_0198;\n\tv486 = \"il2cpp_codegen_runtime_class_init\"(v478, v216, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0198:\n\tv489 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmArray);\n\tv58 = v44 != v489;\n\tif (v58) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_01CD;\n\tgoto L_01CD;\n\tgoto L_01CD;\n\tgoto L_01CD;\n\tgoto L_01CD;\n\tgoto L_01CD;\n\tgoto L_01CD;\n\tgoto L_01CD;\n\tgoto L_01CD;\n\tgoto L_01CD;\n\tgoto L_01CD;\n\tgoto L_01CD;\n\tgoto L_01CD;\n\tgoto L_01CD;\n\tgoto L_01CD;\nL_01CD:\n\treturn returnVal1;\n// 300 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static VariableType GetVariableType(INamedVariable variable)
		{
			//IL_02ff: Expected I4, but got I8
			if (variable != null)
			{
				Type type = variable.GetType();
				Type typeFromHandle = typeof(FsmMaterial);
				if ((object)type != typeFromHandle)
				{
					Type typeFromHandle2 = typeof(FsmTexture);
					if ((object)type != typeFromHandle2)
					{
						Type typeFromHandle3 = typeof(FsmFloat);
						if ((object)type != typeFromHandle3)
						{
							Type typeFromHandle4 = typeof(FsmInt);
							if ((object)type != typeFromHandle4)
							{
								Type typeFromHandle5 = typeof(FsmBool);
								if ((object)type != typeFromHandle5)
								{
									Type typeFromHandle6 = typeof(FsmString);
									if ((object)type != typeFromHandle6)
									{
										Type typeFromHandle7 = typeof(FsmGameObject);
										if ((object)type != typeFromHandle7)
										{
											Type typeFromHandle8 = typeof(FsmVector2);
											if ((object)type != typeFromHandle8)
											{
												Type typeFromHandle9 = typeof(FsmVector3);
												if ((object)type != typeFromHandle9)
												{
													Type typeFromHandle10 = typeof(FsmRect);
													if ((object)type != typeFromHandle10)
													{
														Type typeFromHandle11 = typeof(FsmQuaternion);
														if ((object)type != typeFromHandle11)
														{
															Type typeFromHandle12 = typeof(FsmColor);
															if ((object)type != typeFromHandle12)
															{
																Type typeFromHandle13 = typeof(FsmObject);
																if ((object)type != typeFromHandle13)
																{
																	Type typeFromHandle14 = typeof(FsmEnum);
																	if ((object)type != typeFromHandle14)
																	{
																		Type typeFromHandle15 = typeof(FsmArray);
																		return ((object)type != typeFromHandle15) ? VariableType.Unknown : VariableType.Array;
																	}
																	return VariableType.Enum;
																}
																return VariableType.Object;
															}
															return VariableType.Color;
														}
														return VariableType.Quaternion;
													}
													return VariableType.Rect;
												}
												return VariableType.Vector3;
											}
											return VariableType.Vector2;
										}
										return VariableType.GameObject;
									}
									return VariableType.String;
								}
								return VariableType.Bool;
							}
							return VariableType.Int;
						}
						return default(VariableType);
					}
					return VariableType.Texture;
				}
				return VariableType.Material;
			}
			return VariableType.Unknown;
		}

		[Token(Token = "0x60005CC")]
		[Address(RVA = "0xCB7388", Offset = "0xCB7388", Length = "0x234")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv17 = *([1EA4128]);\n\tv18 = *([v17 @ X8_v14]);\n\tv19 = \"il2cpp_codegen_initialize_method\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 0 | 1;\n\t*([2023671]) = v37;\nL_0013:\n\tv38 = v35 + 1;\n\tv39 = v38 < 0xF;\n\tv40 = ~v39;\n\tv41 = v38 - 0xF;\n\tv43 = v41 == 0;\n\tv48 = ~v43;\n\tv49 = v40 & v48;\n\tif (v49) goto L_009B;\n\tv51 = 0x181A000 + 0x900;\n\tv53 = *([v51 @ X9_v2 (System.Int32)+v38 @ X8_v3 (System.Int32)*4]) + v51;\n\t// 36 IndirectJump v53 @ X8_v11, v35 @ X0_v1 (HutongGames.PlayMaker.VariableType), v35 @ X0_v1 (HutongGames.PlayMaker.VariableType), methodInfo @ X1 (Il2CppMethodInfo), v21 @ X2, v22 @ X3, v23 @ X4, v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX0 = 0;\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 42 ShiftStack 32\n\treturn X0;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1EF3A70]);\n\tgoto L_0085;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1EFD3D8]);\n\tgoto L_0085;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1F01AE0]);\n\tgoto L_0085;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1ECC818]);\n\tgoto L_0085;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1ECE0A0]);\n\tgoto L_0085;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1EC0D30]);\n\tgoto L_0085;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1EAADF8]);\n\tgoto L_0085;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1EAEE80]);\n\tgoto L_0085;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1EC0DE0]);\n\tgoto L_0085;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1EC6448]);\n\tgoto L_0085;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1EEF208]);\n\tgoto L_0085;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1EDB098]);\n\tgoto L_0085;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1EF54C0]);\n\tgoto L_0085;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1EE8198]);\n\tgoto L_0085;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1EA7018]);\nL_0085:\n\tX9 = *([X0+12F]);\n\tX19 = *([X8]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_008F;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_008F;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_008F:\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX0 = X19;\n\tX1 = 0;\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 149 ShiftStack 32\n\tX0 = System.Type::GetTypeFromHandle(X0, X1);\n\treturn X0;\nL_009B:\n\tv57 = new System.ArgumentOutOfRangeException();\n\tSystem.ArgumentOutOfRangeException::.ctor(v57, \"variableType\");\n\tthrow v57;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Type GetVariableRealType(VariableType variableType)
		{
			//IL_0029: Expected O, but got I
			VariableType variableType2 = default(VariableType);
			int num = (int)(variableType2 + 1);
			bool flag = num < 15;
			bool flag2 = !flag;
			int num2 = num - 15;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 25272320 + 2304;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X9_v2 (System.Int32)+v38 @ X8_v3 (System.Int32)*4]");
				object obj = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v53 @ X8_v11 (should have been resolved before IL gen)");
			}
			ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("variableType");
			throw ex;
		}

		[Token(Token = "0x60005CD")]
		[Address(RVA = "0xCB75BC", Offset = "0xCB75BC", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EBADF0]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, enumValue, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023672]) = v41;\nL_001A:\n\t// 26 Box v47 @ X0_v3 (System.Object), typeof(System.Int32), &enumValue @ X1 (System.Int32)\n\tgoto L_002C;\n\tv55 = *([v51 @ X8_v7+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tgoto L_002C;\n\tv66 = v51;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v66, v44, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002C:\n\treturnVal1 = System.Enum::ToObject(enumType, v47);\n\treturn returnVal1;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static object GetEnum(Type enumType, int enumValue)
		{
			object value = enumValue;
			return Enum.ToObject(enumType, value);
		}

		[Token(Token = "0x60005CE")]
		[Address(RVA = "0xCB7658", Offset = "0xCB7658", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EAE200]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023673]) = v38;\nL_0013:\n\tv39 = fsmEvent == 0;\n\tif (v39) goto L_FFFFFFFF;\n\tv43 = new System.Collections.Generic.List`1<System.Byte>();\n\tSystem.Collections.Generic.List`1<System.Byte>::.ctor(v43);\n\tv66 = HutongGames.PlayMaker.FsmUtility::StringToByteArray(fsmEvent.name);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v43, v66);\n\tgoto L_0030;\nL_0030:\n\treturn v59;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ICollection<byte> FsmEventToByteArray(FsmEvent fsmEvent)
		{
			if (fsmEvent != null)
			{
				List<byte> list = new List<byte>();
				byte[] collection = StringToByteArray(fsmEvent.Name);
				list.AddRange(collection);
				return list;
			}
			return null;
		}

		[Token(Token = "0x60005CF")]
		[Address(RVA = "0xCB7764", Offset = "0xCB7764", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EBFD28]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023674]) = v40;\nL_0014:\n\tv41 = fsmFloat == 0;\n\tv42 = ~v41;\n\tif (v42) goto L_0021;\n\tv46 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v46);\nL_0021:\n\tv56 = new System.Collections.Generic.List`1<System.Byte>();\n\tSystem.Collections.Generic.List`1<System.Byte>::.ctor(v56);\n\tv63 = HutongGames.PlayMaker.FsmFloat::get_Value(v50);\n\tv68 = HutongGames.PlayMaker.FsmUtility+BitConverter::GetBytes(v63);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v56, v68);\n\tv96 = HutongGames.PlayMaker.FsmUtility+BitConverter::GetBytes(v50.useVariable);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v56, v96);\n\tv101 = HutongGames.PlayMaker.FsmUtility::StringToByteArray(v50.name);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v56, v101);\n\treturn v56;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ICollection<byte> FsmFloatToByteArray(FsmFloat fsmFloat)
		{
			bool flag = fsmFloat == null;
			bool flag2 = !flag;
			FsmFloat fsmFloat2 = fsmFloat;
			if (!flag2)
			{
				FsmFloat fsmFloat3 = (FsmFloat)new NamedVariable();
				fsmFloat2 = fsmFloat3;
			}
			List<byte> list = new List<byte>();
			float value = fsmFloat2.Value;
			byte[] bytes = BitConverter.GetBytes(value);
			list.AddRange(bytes);
			byte[] bytes2 = BitConverter.GetBytes(fsmFloat2.UseVariable);
			list.AddRange(bytes2);
			byte[] collection = StringToByteArray(fsmFloat2.Name);
			list.AddRange(collection);
			return list;
		}

		[Token(Token = "0x60005D0")]
		[Address(RVA = "0xCB79EC", Offset = "0xCB79EC", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EC90C8]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023675]) = v40;\nL_0014:\n\tv41 = fsmInt == 0;\n\tv42 = ~v41;\n\tif (v42) goto L_0021;\n\tv46 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v46);\nL_0021:\n\tv56 = new System.Collections.Generic.List`1<System.Byte>();\n\tSystem.Collections.Generic.List`1<System.Byte>::.ctor(v56);\n\tv63 = HutongGames.PlayMaker.FsmInt::get_Value(v50);\n\tv67 = HutongGames.PlayMaker.FsmUtility+BitConverter::GetBytes(v63);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v56, v67);\n\tv94 = HutongGames.PlayMaker.FsmUtility+BitConverter::GetBytes(v50.useVariable);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v56, v94);\n\tv99 = HutongGames.PlayMaker.FsmUtility::StringToByteArray(v50.name);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v56, v99);\n\treturn v56;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ICollection<byte> FsmIntToByteArray(FsmInt fsmInt)
		{
			bool flag = fsmInt == null;
			bool flag2 = !flag;
			FsmInt fsmInt2 = fsmInt;
			if (!flag2)
			{
				FsmInt fsmInt3 = (FsmInt)new NamedVariable();
				fsmInt2 = fsmInt3;
			}
			List<byte> list = new List<byte>();
			int value = fsmInt2.Value;
			byte[] bytes = BitConverter.GetBytes(value);
			list.AddRange(bytes);
			byte[] bytes2 = BitConverter.GetBytes(fsmInt2.UseVariable);
			list.AddRange(bytes2);
			byte[] collection = StringToByteArray(fsmInt2.Name);
			list.AddRange(collection);
			return list;
		}

		[Token(Token = "0x60005D1")]
		[Address(RVA = "0xCB7BA4", Offset = "0xCB7BA4", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1F027D8]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023676]) = v40;\nL_0014:\n\tv41 = fsmBool == 0;\n\tv42 = ~v41;\n\tif (v42) goto L_0021;\n\tv46 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v46);\nL_0021:\n\tv56 = new System.Collections.Generic.List`1<System.Byte>();\n\tSystem.Collections.Generic.List`1<System.Byte>::.ctor(v56);\n\tv63 = HutongGames.PlayMaker.FsmBool::get_Value(v50);\n\tv67 = HutongGames.PlayMaker.FsmUtility+BitConverter::GetBytes(v63);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v56, v67);\n\tv95 = HutongGames.PlayMaker.FsmUtility+BitConverter::GetBytes(v50.useVariable);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v56, v95);\n\tv100 = HutongGames.PlayMaker.FsmUtility::StringToByteArray(v50.name);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v56, v100);\n\treturn v56;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ICollection<byte> FsmBoolToByteArray(FsmBool fsmBool)
		{
			bool flag = fsmBool == null;
			bool flag2 = !flag;
			FsmBool fsmBool2 = fsmBool;
			if (!flag2)
			{
				FsmBool fsmBool3 = (FsmBool)new NamedVariable();
				fsmBool2 = fsmBool3;
			}
			List<byte> list = new List<byte>();
			bool value = fsmBool2.Value;
			byte[] bytes = BitConverter.GetBytes(value);
			list.AddRange(bytes);
			byte[] bytes2 = BitConverter.GetBytes(fsmBool2.UseVariable);
			list.AddRange(bytes2);
			byte[] collection = StringToByteArray(fsmBool2.Name);
			list.AddRange(collection);
			return list;
		}

		[Token(Token = "0x60005D2")]
		[Address(RVA = "0xCB7C9C", Offset = "0xCB7C9C", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EBAE60]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023677]) = v40;\nL_0014:\n\tv41 = fsmVector2 == 0;\n\tv42 = ~v41;\n\tif (v42) goto L_0021;\n\tv46 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v46);\nL_0021:\n\tv56 = new System.Collections.Generic.List`1<System.Byte>();\n\tSystem.Collections.Generic.List`1<System.Byte>::.ctor(v56);\n\t// 43 MakeStruct v64 @ AGGCB7D20_0_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v50.value (UnityEngine.Vector2), v50.value.y (System.Single)\n\tv65 = HutongGames.PlayMaker.FsmUtility::Vector2ToByteArray(v64);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v56, v65);\n\tv102 = HutongGames.PlayMaker.FsmUtility+BitConverter::GetBytes(v50.useVariable);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v56, v102);\n\tv107 = HutongGames.PlayMaker.FsmUtility::StringToByteArray(v50.name);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v56, v107);\n\treturn v56;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ICollection<byte> FsmVector2ToByteArray(FsmVector2 fsmVector2)
		{
			bool flag = fsmVector2 == null;
			bool flag2 = !flag;
			FsmVector2 fsmVector3 = fsmVector2;
			if (!flag2)
			{
				FsmVector2 fsmVector4 = new FsmVector2();
				fsmVector3 = fsmVector4;
			}
			List<byte> list = new List<byte>();
			Vector2 vector = default(Vector2);
			vector.x = fsmVector3.value.x;
			vector.y = fsmVector3.value.y;
			ICollection<byte> collection = Vector2ToByteArray(vector);
			list.AddRange(collection);
			byte[] bytes = BitConverter.GetBytes(fsmVector3.UseVariable);
			list.AddRange(bytes);
			byte[] collection2 = StringToByteArray(fsmVector3.Name);
			list.AddRange(collection2);
			return list;
		}

		[Token(Token = "0x60005D3")]
		[Address(RVA = "0xCB7E58", Offset = "0xCB7E58", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EC9078]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023678]) = v40;\nL_0014:\n\tv41 = fsmVector3 == 0;\n\tv42 = ~v41;\n\tif (v42) goto L_0021;\n\tv46 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v46);\nL_0021:\n\tv56 = new System.Collections.Generic.List`1<System.Byte>();\n\tSystem.Collections.Generic.List`1<System.Byte>::.ctor(v56);\n\tv64 = HutongGames.PlayMaker.FsmVector3::get_Value(v50);\n\tv76 = HutongGames.PlayMaker.FsmUtility::Vector3ToByteArray(v64);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v56, v76);\n\tv107 = HutongGames.PlayMaker.FsmUtility+BitConverter::GetBytes(v50.useVariable);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v56, v107);\n\tv112 = HutongGames.PlayMaker.FsmUtility::StringToByteArray(v50.name);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v56, v112);\n\treturn v56;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ICollection<byte> FsmVector3ToByteArray(FsmVector3 fsmVector3)
		{
			bool flag = fsmVector3 == null;
			bool flag2 = !flag;
			FsmVector3 fsmVector4 = fsmVector3;
			if (!flag2)
			{
				FsmVector3 fsmVector5 = new FsmVector3();
				fsmVector4 = fsmVector5;
			}
			List<byte> list = new List<byte>();
			Vector3 value = fsmVector4.Value;
			ICollection<byte> collection = Vector3ToByteArray(value);
			list.AddRange(collection);
			byte[] bytes = BitConverter.GetBytes(fsmVector4.UseVariable);
			list.AddRange(bytes);
			byte[] collection2 = StringToByteArray(fsmVector4.Name);
			list.AddRange(collection2);
			return list;
		}

		[Token(Token = "0x60005D4")]
		[Address(RVA = "0xCB8044", Offset = "0xCB8044", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EB0D48]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023679]) = v40;\nL_0014:\n\tv41 = fsmRect == 0;\n\tv42 = ~v41;\n\tif (v42) goto L_0021;\n\tv46 = new HutongGames.PlayMaker.FsmRect();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v46);\nL_0021:\n\tv56 = new System.Collections.Generic.List`1<System.Byte>();\n\tSystem.Collections.Generic.List`1<System.Byte>::.ctor(v56);\n\t// 45 MakeStruct v66 @ AGGCB80CC_0_v2 (UnityEngine.Rect), typeof(UnityEngine.Rect), v50.value (UnityEngine.Rect), v50.value.m_YMin (System.Single), v50.value.m_Width (System.Single), v50.value.m_Height (System.Single)\n\tv67 = HutongGames.PlayMaker.FsmUtility::RectToByteArray(v66);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v56, v67);\n\tv108 = HutongGames.PlayMaker.FsmUtility+BitConverter::GetBytes(v50.useVariable);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v56, v108);\n\tv113 = HutongGames.PlayMaker.FsmUtility::StringToByteArray(v50.name);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v56, v113);\n\treturn v56;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ICollection<byte> FsmRectToByteArray(FsmRect fsmRect)
		{
			bool flag = fsmRect == null;
			bool flag2 = !flag;
			FsmRect fsmRect2 = fsmRect;
			if (!flag2)
			{
				FsmRect fsmRect3 = (FsmRect)new NamedVariable();
				fsmRect2 = fsmRect3;
			}
			List<byte> list = new List<byte>();
			Rect rect = default(Rect);
			rect.x = fsmRect2.value.x;
			rect.y = fsmRect2.value.y;
			rect.width = fsmRect2.value.width;
			rect.height = fsmRect2.value.height;
			ICollection<byte> collection = RectToByteArray(rect);
			list.AddRange(collection);
			byte[] bytes = BitConverter.GetBytes(fsmRect2.UseVariable);
			list.AddRange(bytes);
			byte[] collection2 = StringToByteArray(fsmRect2.Name);
			list.AddRange(collection2);
			return list;
		}

		[Token(Token = "0x60005D5")]
		[Address(RVA = "0xCB8240", Offset = "0xCB8240", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EC4628]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202367A]) = v40;\nL_0014:\n\tv41 = fsmQuaternion == 0;\n\tv42 = ~v41;\n\tif (v42) goto L_0021;\n\tv46 = new HutongGames.PlayMaker.FsmQuaternion();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v46);\nL_0021:\n\tv56 = new System.Collections.Generic.List`1<System.Byte>();\n\tSystem.Collections.Generic.List`1<System.Byte>::.ctor(v56);\n\t// 45 MakeStruct v66 @ AGGCB82C8_0_v2 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v50.value (UnityEngine.Quaternion), v50.value.y (System.Single), v50.value.z (System.Single), v50.value.w (System.Single)\n\tv67 = HutongGames.PlayMaker.FsmUtility::QuaternionToByteArray(v66);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v56, v67);\n\tv108 = HutongGames.PlayMaker.FsmUtility+BitConverter::GetBytes(v50.useVariable);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v56, v108);\n\tv113 = HutongGames.PlayMaker.FsmUtility::StringToByteArray(v50.name);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v56, v113);\n\treturn v56;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ICollection<byte> FsmQuaternionToByteArray(FsmQuaternion fsmQuaternion)
		{
			bool flag = fsmQuaternion == null;
			bool flag2 = !flag;
			FsmQuaternion fsmQuaternion2 = fsmQuaternion;
			if (!flag2)
			{
				FsmQuaternion fsmQuaternion3 = (FsmQuaternion)new NamedVariable();
				fsmQuaternion2 = fsmQuaternion3;
			}
			List<byte> list = new List<byte>();
			Quaternion quaternion = default(Quaternion);
			quaternion.x = fsmQuaternion2.value.x;
			quaternion.y = fsmQuaternion2.value.y;
			quaternion.z = fsmQuaternion2.value.z;
			quaternion.w = fsmQuaternion2.value.w;
			ICollection<byte> collection = QuaternionToByteArray(quaternion);
			list.AddRange(collection);
			byte[] bytes = BitConverter.GetBytes(fsmQuaternion2.UseVariable);
			list.AddRange(bytes);
			byte[] collection2 = StringToByteArray(fsmQuaternion2.Name);
			list.AddRange(collection2);
			return list;
		}

		[Token(Token = "0x60005D6")]
		[Address(RVA = "0xCB842C", Offset = "0xCB842C", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1ED3DB8]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202367B]) = v40;\nL_0014:\n\tv41 = fsmColor == 0;\n\tv42 = ~v41;\n\tif (v42) goto L_0020;\n\tv46 = new HutongGames.PlayMaker.FsmColor();\n\tHutongGames.PlayMaker.FsmColor::.ctor(v46);\nL_0020:\n\tv54 = new System.Collections.Generic.List`1<System.Byte>();\n\tSystem.Collections.Generic.List`1<System.Byte>::.ctor(v54);\n\t// 44 MakeStruct v64 @ AGGCB84B0_0_v2 (UnityEngine.Color), typeof(UnityEngine.Color), v48.value (UnityEngine.Color), v48.value.g (System.Single), v48.value.b (System.Single), v48.value.a (System.Single)\n\tv65 = HutongGames.PlayMaker.FsmUtility::ColorToByteArray(v64);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v54, v65);\n\tv106 = HutongGames.PlayMaker.FsmUtility+BitConverter::GetBytes(v48.useVariable);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v54, v106);\n\tv111 = HutongGames.PlayMaker.FsmUtility::StringToByteArray(v48.name);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v54, v111);\n\treturn v54;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ICollection<byte> FsmColorToByteArray(FsmColor fsmColor)
		{
			bool flag = fsmColor == null;
			bool flag2 = !flag;
			FsmColor fsmColor2 = fsmColor;
			if (!flag2)
			{
				FsmColor fsmColor3 = new FsmColor();
				fsmColor2 = fsmColor3;
			}
			List<byte> list = new List<byte>();
			Color color = default(Color);
			color.r = fsmColor2.value.r;
			color.g = fsmColor2.value.g;
			color.b = fsmColor2.value.b;
			color.a = fsmColor2.value.a;
			ICollection<byte> collection = ColorToByteArray(color);
			list.AddRange(collection);
			byte[] bytes = BitConverter.GetBytes(fsmColor2.UseVariable);
			list.AddRange(bytes);
			byte[] collection2 = StringToByteArray(fsmColor2.Name);
			list.AddRange(collection2);
			return list;
		}

		[Token(Token = "0x60005D7")]
		[Address(RVA = "0xCB851C", Offset = "0xCB851C", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv32 = *([1EC31C8]);\n\tv33 = *([v32 @ X8_v8]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, v35, v36, v37, v38, v39, v40, v41, color, v0, v2, v3, v42, v43, v44, v45);\n\tv49 = 0 | 1;\n\t*([202367C]) = v49;\nL_0020:\n\tv53 = new System.Collections.Generic.List`1<System.Byte>();\n\tSystem.Collections.Generic.List`1<System.Byte>::.ctor(v53);\n\tv59 = HutongGames.PlayMaker.FsmUtility+BitConverter::GetBytes(color);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v53, v59);\n\tv69 = HutongGames.PlayMaker.FsmUtility+BitConverter::GetBytes(color.g);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v53, v69);\n\tv98 = HutongGames.PlayMaker.FsmUtility+BitConverter::GetBytes(color.b);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v53, v98);\n\tv102 = HutongGames.PlayMaker.FsmUtility+BitConverter::GetBytes(color.a);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v53, v102);\n\treturn v53;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ICollection<byte> ColorToByteArray(Color color)
		{
			List<byte> list = new List<byte>();
			Color color2 = default(Color);
			byte[] bytes = BitConverter.GetBytes(color2.r);
			list.AddRange(bytes);
			byte[] bytes2 = BitConverter.GetBytes(color.g);
			list.AddRange(bytes2);
			byte[] bytes3 = BitConverter.GetBytes(color.b);
			list.AddRange(bytes3);
			byte[] bytes4 = BitConverter.GetBytes(color.a);
			list.AddRange(bytes4);
			return list;
		}

		[Token(Token = "0x60005D8")]
		[Address(RVA = "0xCB7D8C", Offset = "0xCB7D8C", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EF7ED0]);\n\tv21 = *([v20 @ X8_v8]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, v23, v24, v25, v26, v27, v28, v29, vector2, v0, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([202367D]) = v39;\nL_0018:\n\tv43 = new System.Collections.Generic.List`1<System.Byte>();\n\tSystem.Collections.Generic.List`1<System.Byte>::.ctor(v43);\n\tv51 = new System.TypeLoadException();\n\tv52 = HutongGames.PlayMaker.FsmUtility+BitConverter::GetBytes(vector2);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v43, v52);\n\tv64 = new System.TypeLoadException();\n\tv65 = HutongGames.PlayMaker.FsmUtility+BitConverter::GetBytes(vector2);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v43, v65);\n\treturn v43;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ICollection<byte> Vector2ToByteArray(Vector2 vector2)
		{
			List<byte> list = new List<byte>();
			TypeLoadException ex = new TypeLoadException();
			Vector2 vector3 = default(Vector2);
			byte[] bytes = BitConverter.GetBytes(vector3.x);
			list.AddRange(bytes);
			TypeLoadException ex2 = new TypeLoadException();
			byte[] bytes2 = BitConverter.GetBytes(vector3.x);
			list.AddRange(bytes2);
			return list;
		}

		[Token(Token = "0x60005D9")]
		[Address(RVA = "0xCB7F50", Offset = "0xCB7F50", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EE96F8]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, v25, v26, v27, v28, v29, v30, v31, vector3, v0, v2, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([202367E]) = v40;\nL_001A:\n\tv44 = new System.Collections.Generic.List`1<System.Byte>();\n\tSystem.Collections.Generic.List`1<System.Byte>::.ctor(v44);\n\tv52 = new System.TypeLoadException();\n\tv53 = HutongGames.PlayMaker.FsmUtility+BitConverter::GetBytes(vector3);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v44, v53);\n\tv65 = new System.TypeLoadException();\n\tv66 = HutongGames.PlayMaker.FsmUtility+BitConverter::GetBytes(vector3);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v44, v66);\n\tv87 = new System.TypeLoadException();\n\tv88 = HutongGames.PlayMaker.FsmUtility+BitConverter::GetBytes(vector3);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v44, v88);\n\treturn v44;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ICollection<byte> Vector3ToByteArray(Vector3 vector3)
		{
			List<byte> list = new List<byte>();
			TypeLoadException ex = new TypeLoadException();
			Vector3 vector4 = default(Vector3);
			byte[] bytes = BitConverter.GetBytes(vector4.x);
			list.AddRange(bytes);
			TypeLoadException ex2 = new TypeLoadException();
			byte[] bytes2 = BitConverter.GetBytes(vector4.x);
			list.AddRange(bytes2);
			TypeLoadException ex3 = new TypeLoadException();
			byte[] bytes3 = BitConverter.GetBytes(vector4.x);
			list.AddRange(bytes3);
			return list;
		}

		[Token(Token = "0x60005DA")]
		[Address(RVA = "0xCB8614", Offset = "0xCB8614", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EAAF88]);\n\tv25 = *([v24 @ X8_v8]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, v27, v28, v29, v30, v31, v32, v33, vector4, v0, v2, v3, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([202367F]) = v41;\nL_001C:\n\tv45 = new System.Collections.Generic.List`1<System.Byte>();\n\tSystem.Collections.Generic.List`1<System.Byte>::.ctor(v45);\n\tv53 = 0x158BA80(&vector4 @ V0 (UnityEngine.Vector4), 0, 0, v29, v30, v31, v32, v33, vector4, vector4.y, vector4.z, vector4.w, v34, v35, v36, v37);\n\tv54 = HutongGames.PlayMaker.FsmUtility+BitConverter::GetBytes(vector4);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v45, v54);\n\tv66 = 0x158BA80(&vector4 @ V0 (UnityEngine.Vector4), 1, 0, v29, v30, v31, v32, v33, vector4, vector4.y, vector4.z, vector4.w, v34, v35, v36, v37);\n\tv67 = HutongGames.PlayMaker.FsmUtility+BitConverter::GetBytes(vector4);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v45, v67);\n\tv88 = 0x158BA80(&vector4 @ V0 (UnityEngine.Vector4), 2, 0, v29, v30, v31, v32, v33, vector4, vector4.y, vector4.z, vector4.w, v34, v35, v36, v37);\n\tv89 = HutongGames.PlayMaker.FsmUtility+BitConverter::GetBytes(vector4);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v45, v89);\n\tv96 = 0x158BA80(&vector4 @ V0 (UnityEngine.Vector4), 3, 0, v29, v30, v31, v32, v33, vector4, vector4.y, vector4.z, vector4.w, v34, v35, v36, v37);\n\tv97 = HutongGames.PlayMaker.FsmUtility+BitConverter::GetBytes(vector4);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v45, v97);\n\treturn v45;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ICollection<byte> Vector4ToByteArray(Vector4 vector4)
		{
			List<byte> list = new List<byte>();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
			Vector4 vector5 = default(Vector4);
			byte[] bytes = BitConverter.GetBytes(vector5.x);
			list.AddRange(bytes);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
			byte[] bytes2 = BitConverter.GetBytes(vector5.x);
			list.AddRange(bytes2);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
			byte[] bytes3 = BitConverter.GetBytes(vector5.x);
			list.AddRange(bytes3);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
			byte[] bytes4 = BitConverter.GetBytes(vector5.x);
			list.AddRange(bytes4);
			return list;
		}

		[Token(Token = "0x60005DB")]
		[Address(RVA = "0xCB8138", Offset = "0xCB8138", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EBFCC0]);\n\tv25 = *([v24 @ X8_v8]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, v27, v28, v29, v30, v31, v32, v33, rect, v0, v2, v3, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([2023680]) = v41;\nL_001C:\n\tv45 = new System.Collections.Generic.List`1<System.Byte>();\n\tSystem.Collections.Generic.List`1<System.Byte>::.ctor(v45);\n\tv52 = 0x10CCFB4(&rect @ V0 (UnityEngine.Rect), 0, v28, v29, v30, v31, v32, v33, rect, rect.m_YMin, rect.m_Width, rect.m_Height, v34, v35, v36, v37);\n\tv53 = HutongGames.PlayMaker.FsmUtility+BitConverter::GetBytes(rect);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v45, v53);\n\tv64 = System.Collections.Generic.List`1<System.Byte>::AddRange(&rect @ V0 (UnityEngine.Rect), 0);\n\tv65 = HutongGames.PlayMaker.FsmUtility+BitConverter::GetBytes(rect);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v45, v65);\n\tv85 = System.Collections.Generic.List`1<System.Byte>::AddRange(&rect @ V0 (UnityEngine.Rect), 0);\n\tv86 = HutongGames.PlayMaker.FsmUtility+BitConverter::GetBytes(rect);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v45, v86);\n\tv92 = System.Collections.Generic.List`1<System.Byte>::AddRange(&rect @ V0 (UnityEngine.Rect), 0);\n\tv93 = HutongGames.PlayMaker.FsmUtility+BitConverter::GetBytes(rect);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v45, v93);\n\treturn v45;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ICollection<byte> RectToByteArray(Rect rect)
		{
			List<byte> list = new List<byte>();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
			Rect rect2 = default(Rect);
			byte[] bytes = BitConverter.GetBytes(rect2.x);
			list.AddRange(bytes);
			((List<byte>)rect).AddRange((IEnumerable<byte>)null);
			byte[] bytes2 = BitConverter.GetBytes(rect2.x);
			list.AddRange(bytes2);
			((List<byte>)rect).AddRange((IEnumerable<byte>)null);
			byte[] bytes3 = BitConverter.GetBytes(rect2.x);
			list.AddRange(bytes3);
			((List<byte>)rect).AddRange((IEnumerable<byte>)null);
			byte[] bytes4 = BitConverter.GetBytes(rect2.x);
			list.AddRange(bytes4);
			return list;
		}

		[Token(Token = "0x60005DC")]
		[Address(RVA = "0xCB8334", Offset = "0xCB8334", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv32 = *([1ED4C18]);\n\tv33 = *([v32 @ X8_v8]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, v35, v36, v37, v38, v39, v40, v41, quaternion, v0, v2, v3, v42, v43, v44, v45);\n\tv49 = 0 | 1;\n\t*([2023681]) = v49;\nL_0020:\n\tv53 = new System.Collections.Generic.List`1<System.Byte>();\n\tSystem.Collections.Generic.List`1<System.Byte>::.ctor(v53);\n\tv59 = HutongGames.PlayMaker.FsmUtility+BitConverter::GetBytes(quaternion);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v53, v59);\n\tv69 = HutongGames.PlayMaker.FsmUtility+BitConverter::GetBytes(quaternion.y);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v53, v69);\n\tv98 = HutongGames.PlayMaker.FsmUtility+BitConverter::GetBytes(quaternion.z);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v53, v98);\n\tv102 = HutongGames.PlayMaker.FsmUtility+BitConverter::GetBytes(quaternion.w);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v53, v102);\n\treturn v53;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ICollection<byte> QuaternionToByteArray(Quaternion quaternion)
		{
			List<byte> list = new List<byte>();
			Quaternion quaternion2 = default(Quaternion);
			byte[] bytes = BitConverter.GetBytes(quaternion2.x);
			list.AddRange(bytes);
			byte[] bytes2 = BitConverter.GetBytes(quaternion.y);
			list.AddRange(bytes2);
			byte[] bytes3 = BitConverter.GetBytes(quaternion.z);
			list.AddRange(bytes3);
			byte[] bytes4 = BitConverter.GetBytes(quaternion.w);
			list.AddRange(bytes4);
			return list;
		}

		[Token(Token = "0x60005DD")]
		[Address(RVA = "0xCB76F8", Offset = "0xCB76F8", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1ED6388]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023682]) = v38;\nL_0016:\n\tv42 = HutongGames.PlayMaker.FsmUtility::get_Encoding();\n\tv44 = *([v42 @ X0_v2 (System.Text.UTF8Encoding)]);\n\tv56 = v36 != 0;\n\tif (v56) goto L_002B;\n\tgoto L_002B;\nL_002B:\n\tv61 = *([v44 @ X8_v5 (Il2CppClass<System.Text.UTF8Encoding>)+250]);\n\tv62 = *([v44 @ X8_v5 (Il2CppClass<System.Text.UTF8Encoding>)+258]);\n\t// 48 IndirectJump v61 @ X3_v1, v42 @ X0_v2 (System.Text.UTF8Encoding), v42 @ X0_v2 (System.Text.UTF8Encoding), v60 @ X1_v1 (System.String), v62 @ X2_v1, v61 @ X3_v1, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static byte[] StringToByteArray(string str)
		{
			//IL_000d: Expected I, but got O
			//IL_0059: Expected O, but got I
			//IL_0069: Expected O, but got I
			UTF8Encoding uTF8Encoding = Encoding;
			IntPtr intPtr = (IntPtr)uTF8Encoding;
			string text = default(string);
			if (text == null)
			{
				string text2 = "";
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v5 (Il2CppClass<System.Text.UTF8Encoding>)+250]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v5 (Il2CppClass<System.Text.UTF8Encoding>)+258]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v61 @ X3_v1 (should have been resolved before IL gen)");
			return null;
		}

		[Token(Token = "0x60005DE")]
		[Address(RVA = "0xCB872C", Offset = "0xCB872C", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EF5BF8]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023683]) = v38;\nL_0016:\n\tv41 = v36.Length == 0;\n\tif (v41) goto L_002D;\n\tv43 = HutongGames.PlayMaker.FsmUtility::get_Encoding();\n\tv69 = *([v43 @ X0_v6 (System.Text.UTF8Encoding)]);\n\tv59 = *([v69 @ X8_v7 (Il2CppClass<System.Text.UTF8Encoding>)+350]);\n\tv57 = *([v69 @ X8_v7 (Il2CppClass<System.Text.UTF8Encoding>)+358]);\n\t// 36 IndirectJump v59 @ X3_v1, v43 @ X0_v6 (System.Text.UTF8Encoding), v43 @ X0_v6 (System.Text.UTF8Encoding), v36 @ X0_v1 (System.Byte[]), v57 @ X2_v1, v59 @ X3_v1, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\nL_002D:\n\treturn \"\";\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string ByteArrayToString(byte[] bytes)
		{
			//IL_003a: Expected I, but got O
			//IL_004a: Expected O, but got I
			//IL_005a: Expected O, but got I
			byte[] array = default(byte[]);
			if (array.Length != 0)
			{
				UTF8Encoding uTF8Encoding = Encoding;
				IntPtr intPtr = (IntPtr)uTF8Encoding;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X8_v7 (Il2CppClass<System.Text.UTF8Encoding>)+350]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X8_v7 (Il2CppClass<System.Text.UTF8Encoding>)+358]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v59 @ X3_v1 (should have been resolved before IL gen)");
			}
			return "";
		}

		[Token(Token = "0x60005DF")]
		[Address(RVA = "0xCB87B0", Offset = "0xCB87B0", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EEEDF0]);\n\tv27 = *([v26 @ X8_v10]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, startIndex, count, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023684]) = v44;\nL_0017:\n\tv45 = count == 0;\n\tif (v45) goto L_0036;\n\tv46 = HutongGames.PlayMaker.FsmUtility::get_Encoding();\n\tv81 = *([v46 @ X0_v3 (System.Text.UTF8Encoding)]);\n\tv64 = *([v81 @ X8_v7 (Il2CppClass<System.Text.UTF8Encoding>)+360]);\n\tv62 = *([v81 @ X8_v7 (Il2CppClass<System.Text.UTF8Encoding>)+368]);\n\t// 41 IndirectJump v64 @ X5_v1, v46 @ X0_v3 (System.Text.UTF8Encoding), v46 @ X0_v3 (System.Text.UTF8Encoding), v42 @ X0_v1 (System.Byte[]), startIndex @ X1 (System.Int32), count @ X2 (System.Int32), v62 @ X4_v1, v64 @ X5_v1, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\nL_0036:\n\treturn v54.Empty;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string ByteArrayToString(byte[] bytes, int startIndex, int count)
		{
			//IL_001b: Expected I, but got O
			//IL_002b: Expected O, but got I
			//IL_003b: Expected O, but got I
			if (count != 0)
			{
				UTF8Encoding uTF8Encoding = Encoding;
				IntPtr intPtr = (IntPtr)uTF8Encoding;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X8_v7 (Il2CppClass<System.Text.UTF8Encoding>)+360]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X8_v7 (Il2CppClass<System.Text.UTF8Encoding>)+368]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v64 @ X5_v1 (should have been resolved before IL gen)");
			}
			return string.Empty;
		}

		[Token(Token = "0x60005E0")]
		[Address(RVA = "0xCB884C", Offset = "0xCB884C", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EC56A8]);\n\tv27 = *([v26 @ X8_v10]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, startIndex, size, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023685]) = v44;\nL_001A:\n\tv48 = HutongGames.PlayMaker.FsmUtility::ByteArrayToString(bytes, startIndex, size);\n\tv51 = System.String::IsNullOrEmpty(v48);\n\tv53 = v51 == 0;\n\tif (v53) goto L_0030;\n\treturn 0;\nL_0030:\n\tgoto L_003E;\n\tv85 = *([v63 @ X0_v5+E0]);\n\tv86 = v85 == 0;\n\tv87 = ~v86;\n\tif (v87) goto L_003E;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v63, v49, v47, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_003E:\n\treturnVal2 = HutongGames.PlayMaker.FsmEvent::GetFsmEvent(v48);\n\treturn returnVal2;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static FsmEvent ByteArrayToFsmEvent(byte[] bytes, int startIndex, int size)
		{
			string text = ByteArrayToString(bytes, startIndex, size);
			if (string.IsNullOrEmpty(text))
			{
				return null;
			}
			return FsmEvent.GetFsmEvent(text);
		}

		[Token(Token = "0x60005E1")]
		[Address(RVA = "0xCB88F4", Offset = "0xCB88F4", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1F0E700]);\n\tv31 = *([v30 @ X8_v14]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, bytes, startIndex, totalLength, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2023686]) = v47;\nL_0019:\n\tv48 = HutongGames.PlayMaker.FsmUtility::get_Encoding();\n\tv51 = startIndex + 5;\n\tv52 = totalLength - 5;\n\tv56 = System.Text.UTF8Encoding::GetString(v48, bytes, v51, v52);\n\tv64 = System.String::op_Inequality(v56, v62.Empty);\n\tv67 = v64 == 0;\n\tif (v67) goto L_0040;\n\treturnVal2 = HutongGames.PlayMaker.Fsm::GetFsmFloat(v45, v56);\n\treturn returnVal2;\nL_0040:\n\tv91 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v91);\n\tv69 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToSingle(bytes, startIndex);\n\tv110 = startIndex + 4;\n\tv91.value = v69;\n\tv131 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToBoolean(bytes, v110);\n\tv91.useVariable = v131;\n\treturn v91;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static FsmFloat ByteArrayToFsmFloat(Fsm fsm, byte[] bytes, int startIndex, int totalLength)
		{
			UTF8Encoding uTF8Encoding = Encoding;
			int index = startIndex + 5;
			int count = totalLength - 5;
			string text = uTF8Encoding.GetString(bytes, index, count);
			Fsm fsm2 = default(Fsm);
			if (text != string.Empty)
			{
				return fsm2.GetFsmFloat(text);
			}
			FsmFloat fsmFloat = (FsmFloat)new NamedVariable();
			float value = BitConverter.ToSingle(bytes, startIndex);
			int startIndex2 = startIndex + 4;
			fsmFloat.Value = value;
			bool useVariable = BitConverter.ToBoolean(bytes, startIndex2);
			fsmFloat.useVariable = useVariable;
			return fsmFloat;
		}

		[Token(Token = "0x60005E2")]
		[Address(RVA = "0xCB8B3C", Offset = "0xCB8B3C", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1F098B0]);\n\tv31 = *([v30 @ X8_v14]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, bytes, startIndex, totalLength, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2023687]) = v47;\nL_0019:\n\tv48 = HutongGames.PlayMaker.FsmUtility::get_Encoding();\n\tv51 = startIndex + 5;\n\tv52 = totalLength - 5;\n\tv56 = System.Text.UTF8Encoding::GetString(v48, bytes, v51, v52);\n\tv64 = System.String::op_Inequality(v56, v62.Empty);\n\tv67 = v64 == 0;\n\tif (v67) goto L_0040;\n\treturnVal2 = HutongGames.PlayMaker.Fsm::GetFsmInt(v45, v56);\n\treturn returnVal2;\nL_0040:\n\tv89 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v89);\n\tv76 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToInt32(bytes, startIndex);\n\tv89.value = v76;\n\tv107 = startIndex + 4;\n\tv129 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToBoolean(bytes, v107);\n\tv89.useVariable = v129;\n\treturn v89;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static FsmInt ByteArrayToFsmInt(Fsm fsm, byte[] bytes, int startIndex, int totalLength)
		{
			UTF8Encoding uTF8Encoding = Encoding;
			int index = startIndex + 5;
			int count = totalLength - 5;
			string text = uTF8Encoding.GetString(bytes, index, count);
			Fsm fsm2 = default(Fsm);
			if (text != string.Empty)
			{
				return fsm2.GetFsmInt(text);
			}
			FsmInt fsmInt = (FsmInt)new NamedVariable();
			int value = BitConverter.ToInt32(bytes, startIndex);
			fsmInt.Value = value;
			int startIndex2 = startIndex + 4;
			bool useVariable = BitConverter.ToBoolean(bytes, startIndex2);
			fsmInt.useVariable = useVariable;
			return fsmInt;
		}

		[Token(Token = "0x60005E3")]
		[Address(RVA = "0xCB8D0C", Offset = "0xCB8D0C", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EE4F78]);\n\tv31 = *([v30 @ X8_v15]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, bytes, startIndex, totalLength, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2023688]) = v47;\nL_0019:\n\tv48 = HutongGames.PlayMaker.FsmUtility::get_Encoding();\n\tv51 = startIndex + 2;\n\tv52 = totalLength - 2;\n\tv56 = System.Text.UTF8Encoding::GetString(v48, bytes, v51, v52);\n\tv64 = System.String::op_Inequality(v56, v62.Empty);\n\tv67 = v64 == 0;\n\tif (v67) goto L_0040;\n\treturnVal2 = HutongGames.PlayMaker.Fsm::GetFsmBool(v45, v56);\n\treturn returnVal2;\nL_0040:\n\tv89 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v89);\n\tv76 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToBoolean(bytes, startIndex);\n\tv107 = startIndex + 1;\n\tv89.value = v76;\n\tv130 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToBoolean(bytes, v107);\n\tv89.useVariable = v130;\n\treturn v89;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static FsmBool ByteArrayToFsmBool(Fsm fsm, byte[] bytes, int startIndex, int totalLength)
		{
			UTF8Encoding uTF8Encoding = Encoding;
			int index = startIndex + 2;
			int count = totalLength - 2;
			string text = uTF8Encoding.GetString(bytes, index, count);
			Fsm fsm2 = default(Fsm);
			if (text != string.Empty)
			{
				return fsm2.GetFsmBool(text);
			}
			FsmBool fsmBool = (FsmBool)new NamedVariable();
			bool value = BitConverter.ToBoolean(bytes, startIndex);
			int startIndex2 = startIndex + 1;
			fsmBool.value = value;
			bool useVariable = BitConverter.ToBoolean(bytes, startIndex2);
			fsmBool.useVariable = useVariable;
			return fsmBool;
		}

		[Token(Token = "0x60005E4")]
		[Address(RVA = "0xCB8E2C", Offset = "0xCB8E2C", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToSingle(bytes, startIndex);\n\tv22 = startIndex + 4;\n\tv25 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToSingle(bytes, v22);\n\tv26 = startIndex + 8;\n\tv29 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToSingle(bytes, v26);\n\tv30 = startIndex + 0xC;\n\tv33 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToSingle(bytes, v30);\n\tv36 = 0;\n\tv42 = 0x101059C(&v36 @ stack_-50_v1 (UnityEngine.Color), 0, methodInfo, v43, v44, v45, v46, v47, v20, v25, v29, v33, v48, v49, v50, v51);\n\treturn 0;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Color ByteArrayToColor(byte[] bytes, int startIndex)
		{
			float num = BitConverter.ToSingle(bytes, startIndex);
			int startIndex2 = startIndex + 4;
			float num2 = BitConverter.ToSingle(bytes, startIndex2);
			int startIndex3 = startIndex + 8;
			float num3 = BitConverter.ToSingle(bytes, startIndex3);
			int startIndex4 = startIndex + 12;
			float num4 = BitConverter.ToSingle(bytes, startIndex4);
			Color color = default(Color);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
			return default(Color);
		}

		[Token(Token = "0x60005E5")]
		[Address(RVA = "0xCB8EC0", Offset = "0xCB8EC0", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToSingle(bytes, startIndex);\n\tv18 = startIndex + 4;\n\tv21 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToSingle(bytes, v18);\n\tv24 = 0;\n\tv27 = 0x1588A6C(&v24 @ stack_-28_v1 (UnityEngine.Vector2), 0, methodInfo, v28, v29, v30, v31, v32, v16, v21, v33, v34, v35, v36, v37, v38);\n\treturn 0;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector2 ByteArrayToVector2(byte[] bytes, int startIndex)
		{
			float num = BitConverter.ToSingle(bytes, startIndex);
			int startIndex2 = startIndex + 4;
			float num2 = BitConverter.ToSingle(bytes, startIndex2);
			Vector2 vector = default(Vector2);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
			return default(Vector2);
		}

		[Token(Token = "0x60005E6")]
		[Address(RVA = "0xCB8F18", Offset = "0xCB8F18", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EB7AA8]);\n\tv31 = *([v30 @ X8_v14]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, bytes, startIndex, totalLength, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2023689]) = v47;\nL_0019:\n\tv48 = HutongGames.PlayMaker.FsmUtility::get_Encoding();\n\tv51 = startIndex + 9;\n\tv52 = totalLength - 9;\n\tv56 = System.Text.UTF8Encoding::GetString(v48, bytes, v51, v52);\n\tv64 = System.String::op_Inequality(v56, v62.Empty);\n\tv67 = v64 == 0;\n\tif (v67) goto L_0040;\n\treturnVal2 = HutongGames.PlayMaker.Fsm::GetFsmVector2(v45, v56);\n\treturn returnVal2;\nL_0040:\n\tv93 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v93);\n\tv71 = HutongGames.PlayMaker.FsmUtility::ByteArrayToVector2(bytes, startIndex);\n\tv113 = startIndex + 8;\n\tv93.value = v71;\n\tv93.value.y = v71.y;\n\tv134 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToBoolean(bytes, v113);\n\tv93.useVariable = v134;\n\treturn v93;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static FsmVector2 ByteArrayToFsmVector2(Fsm fsm, byte[] bytes, int startIndex, int totalLength)
		{
			UTF8Encoding uTF8Encoding = Encoding;
			int index = startIndex + 9;
			int count = totalLength - 9;
			string text = uTF8Encoding.GetString(bytes, index, count);
			Fsm fsm2 = default(Fsm);
			if (text != string.Empty)
			{
				return fsm2.GetFsmVector2(text);
			}
			FsmVector2 fsmVector = new FsmVector2();
			Vector2 value = ByteArrayToVector2(bytes, startIndex);
			int startIndex2 = startIndex + 8;
			fsmVector.value = value;
			fsmVector.value.y = value.y;
			bool useVariable = BitConverter.ToBoolean(bytes, startIndex2);
			fsmVector.useVariable = useVariable;
			return fsmVector;
		}

		[Token(Token = "0x60005E7")]
		[Address(RVA = "0xCB9034", Offset = "0xCB9034", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToSingle(bytes, startIndex);\n\tv20 = startIndex + 4;\n\tv23 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToSingle(bytes, v20);\n\tv24 = startIndex + 8;\n\tv27 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToSingle(bytes, v24);\n\tv30 = 0;\n\tv35 = 0x1586898(&v30 @ stack_-40_v1 (UnityEngine.Vector3), 0, methodInfo, v36, v37, v38, v39, v40, v18, v23, v27, v41, v42, v43, v44, v45);\n\treturn 0;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector3 ByteArrayToVector3(byte[] bytes, int startIndex)
		{
			float num = BitConverter.ToSingle(bytes, startIndex);
			int startIndex2 = startIndex + 4;
			float num2 = BitConverter.ToSingle(bytes, startIndex2);
			int startIndex3 = startIndex + 8;
			float num3 = BitConverter.ToSingle(bytes, startIndex3);
			Vector3 vector = default(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			return default(Vector3);
		}

		[Token(Token = "0x60005E8")]
		[Address(RVA = "0xCB90B0", Offset = "0xCB90B0", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1ED9D58]);\n\tv31 = *([v30 @ X8_v14]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, bytes, startIndex, totalLength, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([202368A]) = v47;\nL_0019:\n\tv48 = HutongGames.PlayMaker.FsmUtility::get_Encoding();\n\tv51 = startIndex + 0xD;\n\tv52 = totalLength - 0xD;\n\tv56 = System.Text.UTF8Encoding::GetString(v48, bytes, v51, v52);\n\tv64 = System.String::op_Inequality(v56, v62.Empty);\n\tv67 = v64 == 0;\n\tif (v67) goto L_0040;\n\treturnVal2 = HutongGames.PlayMaker.Fsm::GetFsmVector3(v45, v56);\n\treturn returnVal2;\nL_0040:\n\tv95 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v95);\n\tv73 = HutongGames.PlayMaker.FsmUtility::ByteArrayToVector3(bytes, startIndex);\n\tv116 = startIndex + 0xC;\n\tv95.value = v73;\n\tv95.value.y = v73.y;\n\tv95.value.z = v73.z;\n\tv137 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToBoolean(bytes, v116);\n\tv95.useVariable = v137;\n\treturn v95;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static FsmVector3 ByteArrayToFsmVector3(Fsm fsm, byte[] bytes, int startIndex, int totalLength)
		{
			UTF8Encoding uTF8Encoding = Encoding;
			int index = startIndex + 13;
			int count = totalLength - 13;
			string text = uTF8Encoding.GetString(bytes, index, count);
			Fsm fsm2 = default(Fsm);
			if (text != string.Empty)
			{
				return fsm2.GetFsmVector3(text);
			}
			FsmVector3 fsmVector = new FsmVector3();
			Vector3 value = ByteArrayToVector3(bytes, startIndex);
			int startIndex2 = startIndex + 12;
			fsmVector.value = value;
			fsmVector.value.y = value.y;
			fsmVector.value.z = value.z;
			bool useVariable = BitConverter.ToBoolean(bytes, startIndex2);
			fsmVector.useVariable = useVariable;
			return fsmVector;
		}

		[Token(Token = "0x60005E9")]
		[Address(RVA = "0xCB91D0", Offset = "0xCB91D0", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1ED8BB0]);\n\tv31 = *([v30 @ X8_v14]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, bytes, startIndex, totalLength, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([202368B]) = v47;\nL_0019:\n\tv48 = HutongGames.PlayMaker.FsmUtility::get_Encoding();\n\tv51 = startIndex + 0x11;\n\tv52 = totalLength - 0x11;\n\tv56 = System.Text.UTF8Encoding::GetString(v48, bytes, v51, v52);\n\tv64 = System.String::op_Inequality(v56, v62.Empty);\n\tv67 = v64 == 0;\n\tif (v67) goto L_0040;\n\treturnVal2 = HutongGames.PlayMaker.Fsm::GetFsmRect(v45, v56);\n\treturn returnVal2;\nL_0040:\n\tv97 = new HutongGames.PlayMaker.FsmRect();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v97);\n\tv75 = HutongGames.PlayMaker.FsmUtility::ByteArrayToRect(bytes, startIndex);\n\tv119 = startIndex + 0x10;\n\tv97.value = v75;\n\tv97.value.m_YMin = v75.m_YMin;\n\tv97.value.m_Width = v75.m_Width;\n\tv97.value.m_Height = v75.m_Height;\n\tv140 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToBoolean(bytes, v119);\n\tv97.useVariable = v140;\n\treturn v97;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static FsmRect ByteArrayToFsmRect(Fsm fsm, byte[] bytes, int startIndex, int totalLength)
		{
			UTF8Encoding uTF8Encoding = Encoding;
			int index = startIndex + 17;
			int count = totalLength - 17;
			string text = uTF8Encoding.GetString(bytes, index, count);
			Fsm fsm2 = default(Fsm);
			if (text != string.Empty)
			{
				return fsm2.GetFsmRect(text);
			}
			FsmRect fsmRect = (FsmRect)new NamedVariable();
			Rect value = ByteArrayToRect(bytes, startIndex);
			int startIndex2 = startIndex + 16;
			fsmRect.value = value;
			fsmRect.value.y = value.y;
			fsmRect.value.width = value.width;
			fsmRect.value.height = value.height;
			bool useVariable = BitConverter.ToBoolean(bytes, startIndex2);
			fsmRect.useVariable = useVariable;
			return fsmRect;
		}

		[Token(Token = "0x60005EA")]
		[Address(RVA = "0xCB9384", Offset = "0xCB9384", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EC2D40]);\n\tv31 = *([v30 @ X8_v14]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, bytes, startIndex, totalLength, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([202368C]) = v47;\nL_0019:\n\tv48 = HutongGames.PlayMaker.FsmUtility::get_Encoding();\n\tv51 = startIndex + 0x11;\n\tv52 = totalLength - 0x11;\n\tv56 = System.Text.UTF8Encoding::GetString(v48, bytes, v51, v52);\n\tv64 = System.String::op_Inequality(v56, v62.Empty);\n\tv67 = v64 == 0;\n\tif (v67) goto L_0040;\n\treturnVal2 = HutongGames.PlayMaker.Fsm::GetFsmQuaternion(v45, v56);\n\treturn returnVal2;\nL_0040:\n\tv97 = new HutongGames.PlayMaker.FsmQuaternion();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v97);\n\tv75 = HutongGames.PlayMaker.FsmUtility::ByteArrayToQuaternion(bytes, startIndex);\n\tv119 = startIndex + 0x10;\n\tv97.value = v75;\n\tv97.value.y = v75.y;\n\tv97.value.z = v75.z;\n\tv97.value.w = v75.w;\n\tv140 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToBoolean(bytes, v119);\n\tv97.useVariable = v140;\n\treturn v97;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static FsmQuaternion ByteArrayToFsmQuaternion(Fsm fsm, byte[] bytes, int startIndex, int totalLength)
		{
			UTF8Encoding uTF8Encoding = Encoding;
			int index = startIndex + 17;
			int count = totalLength - 17;
			string text = uTF8Encoding.GetString(bytes, index, count);
			Fsm fsm2 = default(Fsm);
			if (text != string.Empty)
			{
				return fsm2.GetFsmQuaternion(text);
			}
			FsmQuaternion fsmQuaternion = (FsmQuaternion)new NamedVariable();
			Quaternion value = ByteArrayToQuaternion(bytes, startIndex);
			int startIndex2 = startIndex + 16;
			fsmQuaternion.value = value;
			fsmQuaternion.value.y = value.y;
			fsmQuaternion.value.z = value.z;
			fsmQuaternion.value.w = value.w;
			bool useVariable = BitConverter.ToBoolean(bytes, startIndex2);
			fsmQuaternion.useVariable = useVariable;
			return fsmQuaternion;
		}

		[Token(Token = "0x60005EB")]
		[Address(RVA = "0xCB9538", Offset = "0xCB9538", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EA3C88]);\n\tv31 = *([v30 @ X8_v14]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, bytes, startIndex, totalLength, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([202368D]) = v47;\nL_0019:\n\tv48 = HutongGames.PlayMaker.FsmUtility::get_Encoding();\n\tv51 = startIndex + 0x11;\n\tv52 = totalLength - 0x11;\n\tv56 = System.Text.UTF8Encoding::GetString(v48, bytes, v51, v52);\n\tv64 = System.String::op_Inequality(v56, v62.Empty);\n\tv67 = v64 == 0;\n\tif (v67) goto L_0040;\n\treturnVal2 = HutongGames.PlayMaker.Fsm::GetFsmColor(v45, v56);\n\treturn returnVal2;\nL_0040:\n\tv97 = new HutongGames.PlayMaker.FsmColor();\n\tHutongGames.PlayMaker.FsmColor::.ctor(v97);\n\tv75 = HutongGames.PlayMaker.FsmUtility::ByteArrayToColor(bytes, startIndex);\n\tv118 = startIndex + 0x10;\n\tv97.value = v75;\n\tv97.value.g = v75.g;\n\tv97.value.b = v75.b;\n\tv97.value.a = v75.a;\n\tv139 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToBoolean(bytes, v118);\n\tv97.useVariable = v139;\n\treturn v97;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static FsmColor ByteArrayToFsmColor(Fsm fsm, byte[] bytes, int startIndex, int totalLength)
		{
			UTF8Encoding uTF8Encoding = Encoding;
			int index = startIndex + 17;
			int count = totalLength - 17;
			string text = uTF8Encoding.GetString(bytes, index, count);
			Fsm fsm2 = default(Fsm);
			if (text != string.Empty)
			{
				return fsm2.GetFsmColor(text);
			}
			FsmColor fsmColor = new FsmColor();
			Color value = ByteArrayToColor(bytes, startIndex);
			int startIndex2 = startIndex + 16;
			fsmColor.value = value;
			fsmColor.value.g = value.g;
			fsmColor.value.b = value.b;
			fsmColor.value.a = value.a;
			bool useVariable = BitConverter.ToBoolean(bytes, startIndex2);
			fsmColor.useVariable = useVariable;
			return fsmColor;
		}

		[Token(Token = "0x60005EC")]
		[Address(RVA = "0xCB9654", Offset = "0xCB9654", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToSingle(bytes, startIndex);\n\tv22 = startIndex + 4;\n\tv25 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToSingle(bytes, v22);\n\tv26 = startIndex + 8;\n\tv29 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToSingle(bytes, v26);\n\tv30 = startIndex + 0xC;\n\tv33 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToSingle(bytes, v30);\n\tv36 = 0;\n\tv42 = 0x158BA74(&v36 @ stack_-50_v1 (UnityEngine.Vector4), 0, methodInfo, v43, v44, v45, v46, v47, v20, v25, v29, v33, v48, v49, v50, v51);\n\treturn 0;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector4 ByteArrayToVector4(byte[] bytes, int startIndex)
		{
			float num = BitConverter.ToSingle(bytes, startIndex);
			int startIndex2 = startIndex + 4;
			float num2 = BitConverter.ToSingle(bytes, startIndex2);
			int startIndex3 = startIndex + 8;
			float num3 = BitConverter.ToSingle(bytes, startIndex3);
			int startIndex4 = startIndex + 12;
			float num4 = BitConverter.ToSingle(bytes, startIndex4);
			Vector4 vector = default(Vector4);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA74 (inside UnityEngine.Vector3Int::.cctor +0xA8)");
			return default(Vector4);
		}

		[Token(Token = "0x60005ED")]
		[Address(RVA = "0xCB92F0", Offset = "0xCB92F0", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToSingle(bytes, startIndex);\n\tv22 = startIndex + 4;\n\tv25 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToSingle(bytes, v22);\n\tv26 = startIndex + 8;\n\tv29 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToSingle(bytes, v26);\n\tv30 = startIndex + 0xC;\n\tv33 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToSingle(bytes, v30);\n\tv36 = 0;\n\tv42 = 0x10CCF64(&v36 @ stack_-50_v1 (UnityEngine.Rect), 0, methodInfo, v43, v44, v45, v46, v47, v20, v25, v29, v33, v48, v49, v50, v51);\n\treturn 0;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Rect ByteArrayToRect(byte[] bytes, int startIndex)
		{
			float num = BitConverter.ToSingle(bytes, startIndex);
			int startIndex2 = startIndex + 4;
			float num2 = BitConverter.ToSingle(bytes, startIndex2);
			int startIndex3 = startIndex + 8;
			float num3 = BitConverter.ToSingle(bytes, startIndex3);
			int startIndex4 = startIndex + 12;
			float num4 = BitConverter.ToSingle(bytes, startIndex4);
			Rect rect = default(Rect);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
			return default(Rect);
		}

		[Token(Token = "0x60005EE")]
		[Address(RVA = "0xCB94A4", Offset = "0xCB94A4", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToSingle(bytes, startIndex);\n\tv22 = startIndex + 4;\n\tv25 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToSingle(bytes, v22);\n\tv26 = startIndex + 8;\n\tv29 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToSingle(bytes, v26);\n\tv30 = startIndex + 0xC;\n\tv33 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToSingle(bytes, v30);\n\tv36 = 0;\n\tv42 = 0x10CB640(&v36 @ stack_-50_v1 (UnityEngine.Quaternion), 0, methodInfo, v43, v44, v45, v46, v47, v20, v25, v29, v33, v48, v49, v50, v51);\n\treturn 0;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Quaternion ByteArrayToQuaternion(byte[] bytes, int startIndex)
		{
			float num = BitConverter.ToSingle(bytes, startIndex);
			int startIndex2 = startIndex + 4;
			float num2 = BitConverter.ToSingle(bytes, startIndex2);
			int startIndex3 = startIndex + 8;
			float num3 = BitConverter.ToSingle(bytes, startIndex3);
			int startIndex4 = startIndex + 12;
			float num4 = BitConverter.ToSingle(bytes, startIndex4);
			Quaternion quaternion = default(Quaternion);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CB640 (inside UnityEngine.QualitySettings::get_activeColorSpace +0x34)");
			return default(Quaternion);
		}

		[Token(Token = "0x60005EF")]
		[Address(RVA = "0xCB96E8", Offset = "0xCB96E8", Length = "0x224")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1EB3410]);\n\tv29 = *([v28 @ X8_v19]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([202368E]) = v48;\nL_0018:\n\tv49 = stream == 0;\n\tif (v49) goto L_0094;\n\tv54 = System.IO.Stream::get_Position(stream);\n\tv61 = System.IO.Stream::set_Position(stream, 0);\n\t// 42 NewArr v66 @ X0_v19 (System.Byte[]), typeof(System.Byte[]), 4096\nL_0030:\n\tv204 = stream->klass;\n\tv226 = stream->klass->vtable[27];\n\tv224 = *([v156 @ X23_v8 (System.Array)+18]) - v190;\n\tv200 = System.IO.Stream::Read(stream, v156, v190, v224);\n\tv173 = v200 < 1;\n\tif (v173) goto L_007F;\n\tv190 = v200 + v190;\n\tv86 = v190 != *([v156 @ X23_v8 (System.Array)+18]);\n\tif (v86) goto L_0030;\n\tv291 = System.IO.Stream::ReadByte(stream);\n\tv292 = v291 + 1;\n\tv101 = v292 == 0;\n\tif (v101) goto L_0030;\n\tv374 = *([v156 @ X23_v8 (System.Array)+18]) << 1;\n\t// 97 NewArr v375 @ X0_v34 (System.Byte[]), typeof(System.Byte[]), v374 @ X1_v16 (System.Int32)\n\tv226 = *([v156 @ X23_v8 (System.Array)+18]);\n\tSystem.Buffer::BlockCopy(v156, 0, v375, 0, *([v156 @ X23_v8 (System.Array)+18]));\n\tSystem.Buffer::SetByte(v375, v190, v291);\n\tv112 = v190 + 1;\n\tv381 = v375 == 0;\n\tv125 = ~v381;\n\tif (v125) goto L_0030;\n\tthrow System.NullReferenceException;\nL_007F:\n\tv215 = v190 != *([v156 @ X23_v8 (System.Array)+18]);\n\tif (v215) goto L_0086;\n\tgoto L_00B2;\nL_0086:\n\t// 134 NewArr v303 @ X0_v22 (System.Byte[]), typeof(System.Byte[]), v190 @ X21_v5 (System.Int32)\n\tSystem.Buffer::BlockCopy(v156, 0, v303, 0, v190);\n\tgoto L_00B2;\nL_0094:\n\tv68 = new System.NullReferenceException();\n\tgoto L_00A6;\n\tgoto L_00A6;\n\tgoto L_00A6;\n\tgoto L_00A6;\n\tgoto L_00A6;\n\tgoto L_00A6;\n\tgoto L_00A6;\n\tgoto L_00A6;\nL_00A6:\n\tv139 = v255 != 1;\n\tif (v139) goto L_00CA;\n\tv216 = 0x6D2BC0(v68, v255, v253, v224, v226, v222, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv248 = *([v216 @ X0_v12]);\n\tv305 = 0x6D2490(v216, v255, v253, v224, v226, v222, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_00B2:\n\tv328 = System.IO.Stream::set_Position(stream, v267);\n\tv329 = v228 & 1;\n\tv330 = v329 == 0;\n\tv331 = ~v330;\n\tif (v331) goto L_00C5;\n\tv372 = v248 == 0;\n\tv263 = ~v372;\n\tif (v263) goto L_00C9;\nL_00C5:\n\treturn v220;\nL_00C9:\n\tv261 = new System.TypeLoadException();\nL_00CA:\n\treturnVal1 = 0x6D2380(v68, 0, 0, v224, v226, v222, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\treturn returnVal1;\n// 138 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static byte[] ReadToEnd(Stream stream)
		{
			//IL_0021: Expected I8, but got I4
			//IL_027f: Expected I4, but got O
			//IL_0321: Expected I, but got O
			//IL_02a5: Expected I8, but got I4
			//IL_020f: Expected O, but got I4
			//IL_015f: Expected O, but got I4
			byte[] result;
			int num9;
			int num10;
			long position2;
			NullReferenceException ex;
			if (stream != null)
			{
				long position = stream.Position;
				stream.Position = 0L;
				byte[] array = new byte[4096];
				int num = 0;
				Array array2 = array;
				while (true)
				{
					IntPtr intPtr = (IntPtr)stream;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ X8_v13 (Il2CppClass<System.IO.Stream>)+2E8]");
					int num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ X23_v8 (System.Array)+18]");
					int count = (int)(-num);
					int num3 = stream.Read((byte[])array2, num, count);
					if (num3 < 1)
					{
						break;
					}
					num = num3 + num;
					int num4 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ X23_v8 (System.Array)+18]");
					if ((IntPtr)num4 != (IntPtr)0)
					{
						continue;
					}
					int num5 = stream.ReadByte();
					if (num5 + 1 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ X23_v8 (System.Array)+18]");
						int num6 = 0;
						byte[] array3 = new byte[num6];
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ X23_v8 (System.Array)+18]");
						num2 = 0;
						Array src = array2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ X23_v8 (System.Array)+18]");
						Buffer.BlockCopy(src, 0, array3, 0, 0);
						Buffer.SetByte(array3, num, (byte)num5);
						int num7 = num + 1;
						bool flag = array3 == null;
						bool flag2 = !flag;
						count = 0;
						object obj = 0;
						num = num7;
						array2 = array3;
						if (!flag2)
						{
							throw new NullReferenceException();
						}
					}
				}
				int num8 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ X23_v8 (System.Array)+18]");
				if ((IntPtr)num8 == (IntPtr)0)
				{
					result = (byte[])array2;
					num9 = 1;
					num10 = 0;
					position2 = position;
				}
				else
				{
					byte[] array4 = new byte[num];
					Buffer.BlockCopy(array2, 0, array4, 0, num);
					result = array4;
					object obj = 0;
					int count = 0;
					int num2 = num;
					num9 = 1;
					num10 = 0;
					position2 = position;
				}
			}
			else
			{
				ex = new NullReferenceException();
				IntPtr intPtr2 = default(IntPtr);
				if (intPtr2 != (IntPtr)1)
				{
					goto IL_02ed;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj2 = default(object);
				num10 = (int)obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				result = null;
				num9 = 0;
				position2 = 33697792L;
			}
			stream.Position = position2;
			if ((num9 & 1) != 0 || num10 == 0)
			{
				return result;
			}
			TypeLoadException ex2 = new TypeLoadException();
			ex = (NullReferenceException)(object)ex2;
			goto IL_02ed;
			IL_02ed:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			byte[] result2 = default(byte[]);
			return result2;
		}

		[Token(Token = "0x60005F0")]
		[Address(RVA = "0xCAEB88", Offset = "0xCAEB88", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EC2528]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202368F]) = v38;\nL_0013:\n\tv39 = name == 0;\n\tif (v39) goto L_002E;\n\tv46 = System.String::LastIndexOf(name, \".\", 4);\n\tv56 = v46 + 1;\n\treturnVal2 = System.String::Substring(name, v56);\n\treturn returnVal2;\nL_002E:\n\treturn \"[missing name]\";\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string StripNamespace(string name)
		{
			if (name != null)
			{
				int num = name.LastIndexOf(".", StringComparison.Ordinal);
				int startIndex = num + 1;
				return name.Substring(startIndex);
			}
			return "[missing name]";
		}

		[Token(Token = "0x60005F1")]
		[Address(RVA = "0xCAF16C", Offset = "0xCAF16C", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EDD750]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023690]) = v38;\nL_0013:\n\tv39 = state == 0;\n\tif (v39) goto L_0034;\n\tv41 = HutongGames.PlayMaker.FsmState::get_Fsm(state);\n\tv49 = v41 == 0;\n\tif (v49) goto L_FFFFFFFF;\n\tv77 = HutongGames.PlayMaker.FsmState::get_Fsm(state);\n\tv97 = HutongGames.PlayMaker.Fsm::get_OwnerDebugName(v77);\n\tv99 = HutongGames.PlayMaker.FsmState::get_Fsm(state);\n\tv88 = System.String::Concat(v97, \": \", v99.name);\n\tgoto L_0043;\nL_0034:\n\treturn \"[missing state]\";\nL_0043:\n\treturnVal2 = System.String::Concat(v88, \": \", state.name, \": \");\n\treturn returnVal2;\n\treturnVal3 = new System.NullReferenceException();\n\treturn returnVal3;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetPath(FsmState state)
		{
			if (state != null)
			{
				Fsm fsm = state.Fsm;
				string text;
				if (fsm != null)
				{
					Fsm fsm2 = state.Fsm;
					string ownerDebugName = fsm2.OwnerDebugName;
					Fsm fsm3 = state.Fsm;
					text = ownerDebugName + ": " + fsm3.Name;
				}
				else
				{
					text = "[missing FSM]";
				}
				return text + ": " + state.Name + ": ";
			}
			return "[missing state]";
		}

		[Token(Token = "0x60005F2")]
		[Address(RVA = "0xCB990C", Offset = "0xCB990C", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1ED1100]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, action, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023691]) = v41;\nL_0016:\n\tv43 = HutongGames.PlayMaker.FsmUtility::GetPath(state);\n\tv45 = action == 0;\n\tif (v45) goto L_003C;\n\tv48 = System.Object::GetType(action);\n\tv64 = System.Reflection.MemberInfo::get_Name(v48);\n\treturnVal2 = System.String::Concat(v43, v64, \": \");\n\treturn returnVal2;\nL_003C:\n\treturnVal1 = System.String::Concat(v43, \"[missing action] \");\n\treturn returnVal1;\n\treturnVal3 = new System.NullReferenceException();\n\treturn returnVal3;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetPath(FsmState state, FsmStateAction action)
		{
			string path = GetPath(state);
			if (action != null)
			{
				Type type = action.GetType();
				string name = type.Name;
				return path + name + ": ";
			}
			return path + "[missing action] ";
		}

		[Token(Token = "0x60005F3")]
		[Address(RVA = "0xCB99C4", Offset = "0xCB99C4", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1ED82D8]);\n\tv27 = *([v26 @ X8_v6]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, action, parameter, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023692]) = v44;\nL_0019:\n\tv47 = HutongGames.PlayMaker.FsmUtility::GetPath(state, action);\n\treturnVal1 = System.String::Concat(v47, parameter, \": \");\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetPath(FsmState state, FsmStateAction action, string parameter)
		{
			string path = GetPath(state, action);
			return path + parameter + ": ";
		}

		[Token(Token = "0x60005F4")]
		[Address(RVA = "0xCB9A34", Offset = "0xCB9A34", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EBF3A8]);\n\tv21 = *([v20 @ X8_v26]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023693]) = v40;\nL_0014:\n\tv41 = fsm == 0;\n\tif (v41) goto L_FFFFFFFF;\n\tgoto L_0026;\n\tv51 = *([v45 @ X0_v4+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_0026;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0026:\n\tv61 = UnityEngine.Object::op_Inequality(fsm.usedInTemplate, 0);\n\tv82 = v61 == 0;\n\tif (v82) goto L_0045;\n\tv122 = UnityEngine.Object::get_name(fsm.usedInTemplate);\n\treturnVal3 = System.String::Concat(\"Template: \", v122);\n\treturn returnVal3;\n\tgoto L_005B;\nL_0045:\n\tgoto L_004E;\n\tv123 = *([v117 @ X0_v8+E0]);\n\tv124 = v123 == 0;\n\tv125 = ~v124;\n\tif (v125) goto L_004E;\n\tv127 = \"il2cpp_codegen_runtime_class_init\"(v117, v59, v60, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_004E:\n\tv68 = UnityEngine.Object::op_Equality(fsm.owner, 0);\n\tv70 = v68 == 0;\n\tif (v70) goto L_005E;\nL_005B:\n\treturn *([v71 @ X8_v3 (System.String)]);\nL_005E:\n\tv138 = HutongGames.PlayMaker.Fsm::get_OwnerName(fsm);\n\tgoto L_0078;\n\tv145 = *([1EBC778]);\n\tv146 = *([v145 @ X8_v15]);\n\tv147 = \"il2cpp_codegen_initialize_method\"(v146, v137, v63, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv150 = 0 | 1;\n\t*([2023695]) = v150;\nL_0078:\n\treturnVal4 = System.String::Concat(v138, \" : \", fsm.name);\n\treturn returnVal4;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetFullFsmLabel(Fsm fsm)
		{
			if (fsm != null)
			{
				if (fsm.UsedInTemplate != null)
				{
					string name = fsm.UsedInTemplate.name;
					return "Template: " + name;
				}
				if (fsm.Owner == null)
				{
					return "FSM Missing Owner";
				}
				string ownerName = fsm.OwnerName;
				return ownerName + " : " + fsm.Name;
			}
			return "None (FSM)";
		}

		[Token(Token = "0x60005F5")]
		[Address(RVA = "0xCB9BF0", Offset = "0xCB9BF0", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F06748]);\n\tv19 = *([v18 @ X8_v17]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023694]) = v38;\nL_0019:\n\tgoto L_0022;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0022;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0022:\n\tv55 = UnityEngine.Object::op_Equality(fsm, 0);\n\tv57 = v55 == 0;\n\tif (v57) goto L_002D;\n\tgoto L_0050;\nL_002D:\n\tv64 = PlayMakerFSM::get_Fsm(fsm);\n\tv66 = v64 == 0;\n\tif (v66) goto L_FFFFFFFF;\n\tv101 = UnityEngine.Component::get_gameObject(fsm);\n\tv105 = UnityEngine.Object::get_name(v101);\n\tv109 = PlayMakerFSM::get_FsmName(fsm);\n\treturnVal3 = System.String::Concat(v105, \" : \", v109);\n\treturn returnVal3;\nL_0050:\n\treturn *([v67 @ X8_v7 (System.String)]);\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetFullFsmLabel(PlayMakerFSM fsm)
		{
			if (fsm == null)
			{
				return "None (PlayMakerFSM)";
			}
			Fsm fsm2 = fsm.Fsm;
			if (fsm2 != null)
			{
				GameObject gameObject = fsm.gameObject;
				string name = gameObject.name;
				string fsmName = fsm.FsmName;
				return name + " : " + fsmName;
			}
			return "None (Fsm)";
		}

		[Token(Token = "0x60005F6")]
		[Address(RVA = "0xCB9B98", Offset = "0xCB9B98", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EBC778]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023695]) = v38;\nL_0015:\n\tv56 = fsm + 0x30;\n\tv53 = fsm != 0;\n\tif (v53) goto L_002B;\n\tgoto L_002B;\nL_002B:\n\treturn *([v56 @ X8_v4 (System.String)]);\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetFsmLabel(Fsm fsm)
		{
			//IL_0022: Expected O, but got I
			string result = (string)((long)(IntPtr)fsm + 48L);
			if (fsm == null)
			{
				result = "None (Fsm)";
			}
			return result;
		}

		[Token(Token = "0x60005F7")]
		[Address(RVA = "0xCB9CE4", Offset = "0xCB9CE4", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EE4598]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023696]) = v38;\nL_0013:\n\tv39 = fsm == 0;\n\tif (v39) goto L_FFFFFFFF;\n\tgoto L_0024;\n\tv48 = *([v43 @ X0_v4+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tif (v50) goto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0024:\n\tv57 = UnityEngine.Object::op_Implicit(fsm.usedInTemplate);\n\tv63 = v57 == 0;\n\tif (v63) goto L_FFFFFFFF;\n\tgoto L_0032;\n\tgoto L_0032;\nL_0032:\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static UnityEngine.Object GetOwner(Fsm fsm)
		{
			if (fsm != null)
			{
				if ((bool)fsm.UsedInTemplate)
				{
					return fsm.UsedInTemplate;
				}
				return fsm.Owner;
			}
			return null;
		}

		[Token(Token = "0x60005F8")]
		[Address(RVA = "0xCB9D70", Offset = "0xCB9D70", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1F09A58]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2023697]) = v42;\nL_0017:\n\tv134 = fsm.name;\n\tv47 = HutongGames.PlayMaker.Fsm::get_GameObject(fsm);\n\tgoto L_002C;\n\tv79 = *([v75 @ X8_v4+E0]);\n\tv80 = v79 == 0;\n\tv81 = ~v80;\n\tif (v81) goto L_002C;\n\tv116 = v75;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v116, v46, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002C:\n\tv89 = UnityEngine.Object::op_Inequality(v47, 0);\n\tv118 = v89 == 0;\n\tif (v118) goto L_0073;\n\tv121 = HutongGames.PlayMaker.Fsm::get_GameObject(fsm);\n\tv138 = UnityEngine.Object::get_name(v121);\n\tv161 = System.String::Concat(v138, \"/\", fsm.name);\n\tv150 = HutongGames.PlayMaker.Fsm::get_GameObject(fsm);\n\tv149 = UnityEngine.GameObject::get_transform(v150);\n\tv172 = v149 == 0;\n\tv152 = ~v172;\n\tif (v152) goto L_0056;\n\tthrow System.NullReferenceException;\nL_004E:\n\tv166 = UnityEngine.Object::get_name(v182);\n\tv170 = System.String::Concat(v166, *([v126 @ X21_v5 (System.String)]), v134);\nL_0056:\n\tv182 = UnityEngine.Transform::get_parent(v178);\n\tgoto L_0066;\n\tv186 = *([v133 @ X8_v7+E0]);\n\tv187 = v186 == 0;\n\tv188 = ~v187;\n\tgoto L_0066;\n\tv193 = v133;\n\tv190 = \"il2cpp_codegen_runtime_class_init\"(v193, v181, v173, v122, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0066:\n\tv129 = UnityEngine.Object::op_Inequality(v182, 0);\n\tv195 = v129 == 0;\n\tv130 = ~v195;\n\tif (v130) goto L_004E;\nL_0073:\n\treturn v134;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetFullPath(Fsm fsm)
		{
			string text = fsm.Name;
			GameObject gameObject = fsm.GameObject;
			if (gameObject != null)
			{
				GameObject gameObject2 = fsm.GameObject;
				string name = gameObject2.name;
				string text2 = name + "/" + fsm.Name;
				GameObject gameObject3 = fsm.GameObject;
				Transform transform = gameObject3.transform;
				bool flag = (object)transform == null;
				bool flag2 = !flag;
				string text3 = "/";
				Transform transform2 = transform;
				text = text2;
				if (!flag2)
				{
					throw new NullReferenceException();
				}
				while (true)
				{
					Transform parent = transform2.parent;
					if (parent != null)
					{
						string name2 = parent.name;
						string text4 = name2 + text3 + text;
						text3 = text3;
						transform2 = parent;
						text = text4;
						continue;
					}
					break;
				}
			}
			return text;
		}

		[Token(Token = "0x60005F9")]
		[Address(RVA = "0xCB9ED0", Offset = "0xCB9ED0", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EF6A10]);\n\tv27 = *([v26 @ X8_v17]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, seperator, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2023698]) = v45;\nL_001D:\n\tgoto L_0026;\n\tv52 = *([v48 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0026;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, seperator, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0026:\n\tv62 = UnityEngine.Object::op_Equality(go, 0);\n\tv64 = v62 == 0;\n\tif (v64) goto L_0034;\n\tv92 = v68.Empty;\n\tgoto L_006E;\nL_0034:\n\tv104 = UnityEngine.Object::get_name(go);\n\tv146 = System.String::Concat(v104, \"\u00a0\");\n\tv150 = UnityEngine.GameObject::get_transform(go);\n\tv152 = v150 == 0;\n\tv153 = ~v152;\n\tif (v153) goto L_0050;\n\tthrow System.NullReferenceException;\nL_0047:\n\tv177 = UnityEngine.Object::get_name(v170);\n\tv163 = System.String::Concat(v177, \"\u00a0\", seperator, v125);\nL_0050:\n\tv170 = UnityEngine.Transform::get_parent(v165);\n\tgoto L_0060;\n\tv178 = *([v91 @ X8_v8+E0]);\n\tv179 = v178 == 0;\n\tv180 = ~v179;\n\tgoto L_0060;\n\tv185 = v91;\n\tv182 = \"il2cpp_codegen_runtime_class_init\"(v185, v169, v158, v77, v75, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0060:\n\tv85 = UnityEngine.Object::op_Inequality(v170, 0);\n\tv187 = v85 == 0;\n\tv87 = ~v187;\n\tif (v87) goto L_0047;\nL_006E:\n\treturn v92;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetFullPath(GameObject go, string seperator = "/")
		{
			string result;
			if (go == null)
			{
				result = string.Empty;
			}
			else
			{
				string name = go.name;
				string text = name + "\u00a0";
				Transform transform = go.transform;
				bool flag = (object)transform == null;
				bool flag2 = !flag;
				Transform transform2 = transform;
				string text2 = text;
				if (!flag2)
				{
					throw new NullReferenceException();
				}
				while (true)
				{
					Transform parent = transform2.parent;
					bool flag3 = parent != null;
					bool flag4 = !flag3;
					bool flag5 = !flag4;
					transform2 = parent;
					result = text2;
					if (flag5)
					{
						string name2 = parent.name;
						string text3 = name2 + "\u00a0" + seperator + text2;
						text2 = text3;
						continue;
					}
					break;
				}
			}
			return result;
		}
	}
}
