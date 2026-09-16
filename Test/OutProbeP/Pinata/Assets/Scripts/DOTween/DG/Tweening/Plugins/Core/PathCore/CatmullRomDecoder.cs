using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening.Plugins.Core.PathCore
{
	[Token(Token = "0x2000044")]
	internal class CatmullRomDecoder : ABSPathDecoder
	{
		[Token(Token = "0x4000116")]
		private static readonly ControlPoint[] _PartialControlPs;

		[Token(Token = "0x4000117")]
		private static readonly Vector3[] _PartialWps;

		[Token(Token = "0x600024C")]
		[Address(RVA = "0x1080248", Offset = "0x1080248", Length = "0x288")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv42 = *([1EE8A20]);\n\tv43 = *([v42 @ X8_v32]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, p, wps, isClosedPath, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv59 = 0 | 1;\n\t*([2026A44]) = v59;\nL_0023:\n\tv182 = p.controlPoints;\n\tv187 = p.controlPoints == 0;\n\tif (v187) goto L_0036;\n\tv276 = v182.Length == 2;\n\tif (v276) goto L_003A;\nL_0036:\n\t// 54 NewArr v294 @ X0_v24 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[]), typeof(DG.Tweening.Plugins.Core.PathCore.ControlPoint[]), 2\n\tp.controlPoints = v294;\nL_003A:\n\tv257 = isClosedPath == 0;\n\tif (v257) goto L_007D;\n\tv262 = wps.Length - 2;\n\tv309 = v262 < wps.Length;\n\tv160 = ~v309;\n\tif (v160) goto L_0119;\n\tv372 = v262 * 0xC;\n\tv373 = wps + v372;\n\tgoto L_005C;\n\tv383 = *([v374 @ X0_v19+E0]);\n\tv384 = v383 == 0;\n\tv385 = ~v384;\n\tif (v385) goto L_005C;\n\tv387 = \"il2cpp_codegen_runtime_class_init\"(v374, v122, wps, isClosedPath, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\nL_005C:\n\tv102 = UnityEngine.Vector3::get_zero();\n\tv258 = v182.Length == 0;\n\tif (v258) goto L_0119;\n\t*([v182 @ X22_v5 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+20]) = *([v373 @ X8_v21+20]);\n\t*([v182 @ X22_v5 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+24]) = wps[v262 @ X8_v19].y;\n\t*([v182 @ X22_v5 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+28]) = wps[v262 @ X8_v19].z;\n\t*([v182 @ X22_v5 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+2C]) = v102;\n\t*([v182 @ X22_v5 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+30]) = v102.y;\n\t*([v182 @ X22_v5 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+34]) = v102.z;\n\tv395 = wps.Length < 1;\n\tv249 = ~v395;\n\tv244 = wps.Length - 1;\n\tv234 = v244 == 0;\n\tv396 = ~v249;\n\tv200 = v396 | v234;\n\tif (v200) goto L_0119;\n\tv183 = p.controlPoints;\n\tv88 = *([wps @ X2 (UnityEngine.Vector3[])+2C]);\n\tv86 = *([wps @ X2 (UnityEngine.Vector3[])+30]);\n\tv84 = *([wps @ X2 (UnityEngine.Vector3[])+34]);\n\tgoto L_00E6;\nL_007D:\n\tv310 = wps.Length < 1;\n\tv161 = ~v310;\n\tv156 = wps.Length - 1;\n\tv146 = v156 == 0;\n\tv311 = ~v161;\n\tv91 = v311 | v146;\n\tif (v91) goto L_0119;\n\tgoto L_0099;\n\tv389 = *([v379 @ X0_v13+E0]);\n\tv390 = v389 == 0;\n\tv391 = ~v390;\n\tif (v391) goto L_0099;\n\tv393 = \"il2cpp_codegen_runtime_class_init\"(v379, v122, wps, isClosedPath, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\nL_0099:\n\tv103 = UnityEngine.Vector3::get_zero();\n\tv259 = v182.Length == 0;\n\tif (v259) goto L_0119;\n\t*([v182 @ X22_v5 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+20]) = *([wps @ X2 (UnityEngine.Vector3[])+2C]);\n\t*([v182 @ X22_v5 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+24]) = *([wps @ X2 (UnityEngine.Vector3[])+30]);\n\t*([v182 @ X22_v5 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+28]) = *([wps @ X2 (UnityEngine.Vector3[])+34]);\n\t*([v182 @ X22_v5 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+2C]) = v103;\n\t*([v182 @ X22_v5 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+30]) = v103.y;\n\t*([v182 @ X22_v5 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+34]) = v103.z;\n\tv267 = wps.Length - 1;\n\tv397 = v267 < wps.Length;\n\tv250 = ~v397;\n\tif (v250) goto L_0119;\n\tv211 = wps.Length - 2;\n\tv402 = v211 < wps.Length;\n\tv251 = ~v402;\n\tif (v251) goto L_0119;\n\tv410 = wps + 0x20;\n\tv430 = v267 * 0xC;\n\tv426 = v410 + v430;\n\tv425 = v211 * 0xC;\n\tv421 = v410 + v425;\n\t// 208 MakeStruct v406 @ AGG108040C_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v426 @ X8_v17], [v426 @ X8_v17+4], [v426 @ X8_v17+8]\n\t// 209 MakeStruct v405 @ AGG108040C_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v421 @ X9_v6], [v421 @ X9_v6+4], [v421 @ X9_v6+8]\n\tv441 = UnityEngine.Vector3::op_Subtraction(v406, v405);\n\tv183 = p.controlPoints;\n\t// 221 MakeStruct v404 @ AGG1080430_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v426 @ X8_v17], [v426 @ X8_v17+4], [v426 @ X8_v17+8]\n\tv419 = UnityEngine.Vector3::op_Addition(v404, v441);\nL_00E6:\n\tv104 = UnityEngine.Vector3::get_zero();\n\tv447 = v183.Length < 1;\n\tv252 = ~v447;\n\tv247 = v183.Length - 1;\n\tv237 = v247 == 0;\n\tv448 = ~v252;\n\tv201 = v448 | v237;\n\tif (v201) goto L_0119;\n\t*([v183 @ X22_v6 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+38]) = v88;\n\t*([v183 @ X22_v6 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+3C]) = v86;\n\t*([v183 @ X22_v6 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+40]) = v84;\n\t*([v183 @ X22_v6 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+44]) = v104;\n\t*([v183 @ X22_v6 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+48]) = v104.y;\n\t*([v183 @ X22_v6 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+4C]) = v104.z;\n\tv451 = p.subdivisionsXSegment * wps.Length;\n\tp.subdivisions = v451;\n\tDG.Tweening.Plugins.Core.PathCore.CatmullRomDecoder::SetTimeToLengthTables(this, p, v451);\n\tDG.Tweening.Plugins.Core.PathCore.CatmullRomDecoder::SetWaypointsLengths(this, p, p.subdivisionsXSegment);\n\treturn;\n\tv185 = new System.NullReferenceException();\nL_0119:\n\tv270 = new System.IndexOutOfRangeException();\n\tthrow v270;\n\t*([v297 @ X0_v4]) = v204;\n\t*([v297 @ X0_v4+4]) = v203;\n\t*([v297 @ X0_v4+8]) = v202;\n\t*([v297 @ X0_v4+C]) = v194;\n\t*([v297 @ X0_v4+10]) = v193;\n\t*([v297 @ X0_v4+14]) = v192;\n\treturn;\n// 174 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal override void FinalizePath(Path p, Vector3[] wps, bool isClosedPath)
		{
			//IL_021f: Expected O, but got I4
			//IL_008b: Expected O, but got I4
			//IL_00c3: Expected O, but got I
			//IL_00d2: Expected O, but got I
			//IL_02d6: Expected O, but got I4
			//IL_017c: Expected O, but got I4
			//IL_030f: Expected O, but got I4
			//IL_01ce: Expected O, but got I
			//IL_01de: Expected O, but got I
			//IL_01ee: Expected O, but got I
			//IL_0347: Expected O, but got I
			//IL_0356: Expected O, but got I
			//IL_0365: Expected O, but got I
			//IL_0374: Expected O, but got I
			//IL_0383: Expected O, but got I
			//IL_0390: Expected F4, but got O
			//IL_03a5: Expected F4, but got I
			//IL_03ba: Expected F4, but got I
			//IL_03c7: Expected F4, but got O
			//IL_03dc: Expected F4, but got I
			//IL_03f1: Expected F4, but got I
			//IL_041c: Expected F4, but got O
			//IL_0431: Expected F4, but got I
			//IL_0446: Expected F4, but got I
			//IL_0469: Expected O, but got F4
			//IL_0476: Expected O, but got F4
			//IL_04af: Expected O, but got I4
			ControlPoint[] array = p.controlPoints;
			if (p.controlPoints == null || array.Length != 2)
			{
				array = (p.controlPoints = new ControlPoint[2]);
			}
			ControlPoint[] controlPoints;
			if (isClosedPath)
			{
				object obj = wps.Length - 2;
				if ((long)(IntPtr)obj < (long)wps.Length)
				{
					object obj2 = (long)(IntPtr)obj * 12L;
					object obj3 = (long)(IntPtr)wps + (long)(IntPtr)obj2;
					Vector3 zero = Vector3.zero;
					if (array.Length != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ X8_v21+20]");
						_ = 0;
						_ = wps[obj].y;
						_ = wps[obj].z;
						_ = zero.y;
						_ = zero.z;
						bool flag = wps.Length < 1;
						bool flag2 = !flag;
						object obj4 = wps.Length - 1;
						bool flag3 = obj4 == null;
						bool flag4 = !flag2;
						if (!(flag4 || flag3))
						{
							controlPoints = p.controlPoints;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [wps @ X2 (UnityEngine.Vector3[])+2C]");
							Vector3 vector = (Vector3)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [wps @ X2 (UnityEngine.Vector3[])+30]");
							Vector3 vector2 = (Vector3)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [wps @ X2 (UnityEngine.Vector3[])+34]");
							Vector3 vector3 = (Vector3)0;
							goto IL_057f;
						}
					}
				}
			}
			else
			{
				bool flag5 = wps.Length < 1;
				bool flag6 = !flag5;
				object obj5 = wps.Length - 1;
				bool flag7 = obj5 == null;
				bool flag8 = !flag6;
				if (!(flag8 || flag7))
				{
					Vector3 zero2 = Vector3.zero;
					if (array.Length != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [wps @ X2 (UnityEngine.Vector3[])+2C]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [wps @ X2 (UnityEngine.Vector3[])+30]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [wps @ X2 (UnityEngine.Vector3[])+34]");
						_ = 0;
						_ = zero2.y;
						_ = zero2.z;
						object obj6 = wps.Length - 1;
						if ((long)(IntPtr)obj6 < (long)wps.Length)
						{
							object obj7 = wps.Length - 2;
							if ((long)(IntPtr)obj7 < (long)wps.Length)
							{
								object obj8 = (long)(IntPtr)wps + 32L;
								object obj9 = (long)(IntPtr)obj6 * 12L;
								object obj10 = (long)(IntPtr)obj8 + (long)(IntPtr)obj9;
								object obj11 = (long)(IntPtr)obj7 * 12L;
								object obj12 = (long)(IntPtr)obj8 + (long)(IntPtr)obj11;
								Vector3 vector4 = default(Vector3);
								vector4.x = (float)obj10;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v426 @ X8_v17+4]");
								vector4.y = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v426 @ X8_v17+8]");
								vector4.z = 0f;
								Vector3 vector5 = default(Vector3);
								vector5.x = (float)obj12;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ X9_v6+4]");
								vector5.y = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ X9_v6+8]");
								vector5.z = 0f;
								Vector3 vector6 = vector4 - vector5;
								controlPoints = p.controlPoints;
								Vector3 vector7 = default(Vector3);
								vector7.x = (float)obj10;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v426 @ X8_v17+4]");
								vector7.y = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v426 @ X8_v17+8]");
								vector7.z = 0f;
								Vector3 vector8 = vector7 + vector6;
								Vector3 vector3 = (Vector3)vector8.z;
								Vector3 vector2 = (Vector3)vector8.y;
								Vector3 vector = vector8;
								goto IL_057f;
							}
						}
					}
				}
			}
			goto IL_0554;
			IL_0554:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_057f:
			Vector3 zero3 = Vector3.zero;
			bool flag9 = controlPoints.Length < 1;
			bool flag10 = !flag9;
			object obj13 = controlPoints.Length - 1;
			bool flag11 = obj13 == null;
			bool flag12 = !flag10;
			if (!(flag12 || flag11))
			{
				_ = zero3.y;
				_ = zero3.z;
				SetTimeToLengthTables(p, p.subdivisions = p.subdivisionsXSegment * wps.Length);
				SetWaypointsLengths(p, p.subdivisionsXSegment);
				return;
			}
			goto IL_0554;
		}

		[Token(Token = "0x600024D")]
		[Address(RVA = "0x1080AB8", Offset = "0x1080AB8", Length = "0x498")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv42 = *([1EBD658]);\n\tv43 = *([v42 @ X8_v17]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, wps, p, controlPoints, methodInfo, v47, v48, v49, perc, v50, v51, v52, v53, v54, v55, v56);\n\tv60 = 0 | 1;\n\t*([2026A45]) = v60;\nL_0025:\n\tv66 = wps.Length - 1;\n\tgoto L_0030;\n\tv188 = *([v65 @ X0_v5+E0]);\n\tv189 = v188 == 0;\n\tv190 = ~v189;\n\tif (v190) goto L_0030;\n\tv191 = \"il2cpp_codegen_runtime_class_init\"(v65, wps, p, controlPoints, methodInfo, v47, v48, v49, perc, v50, v51, v52, v53, v54, v55, v56);\nL_0030:\n\tv171 = v66 * perc;\n\tv167 = wps.Length - 2;\n\tv157 = v167 - v171;\n\tv152 = v157 < 0;\n\tv147 = v157 == 0;\n\tv142 = v167 ^ v171;\n\tv137 = v167 ^ v157;\n\tv132 = v142 & v137;\n\tv127 = v132 < 0;\n\tv197 = v152 == v127;\n\tv118 = ~v147;\n\tv122 = v197 & v118;\n\tv115 = ~v122;\n\tif (v115) goto L_FFFFFFFF;\n\tgoto L_0045;\nL_0045:\n\tv424 = v184 == 0;\n\tif (v424) goto L_005E;\n\tv168 = wps.Length;\n\tv426 = v184 - 1;\n\tv427 = v426 < wps.Length;\n\tv428 = ~v427;\n\tif (v428) goto L_01DE;\n\tv438 = v426 * 0xC;\n\tv439 = wps + v438;\n\tv446 = v439 + 0x20;\n\tv445 = v439 + 0x24;\n\tv444 = v439 + 0x28;\n\tgoto L_0064;\nL_005E:\n\tv482 = controlPoints.Length == 0;\n\tif (v482) goto L_01DE;\n\tv168 = wps.Length;\n\tv446 = controlPoints + 0x20;\n\tv445 = controlPoints + 0x24;\n\tv444 = controlPoints + 0x28;\nL_0064:\n\tv498 = v184 < v168;\n\tv479 = ~v498;\n\tif (v479) goto L_01DE;\n\tv443 = v184 + 1;\n\tv499 = v443 < v168;\n\tv476 = ~v499;\n\tif (v476) goto L_01DE;\n\tv502 = v184 * 0xC;\n\tv503 = wps + v502;\n\tv484 = v443 * 0xC;\n\tv504 = wps + v484;\n\tv113 = v184 + 2;\n\tv109 = v168 - 1;\n\tv123 = v113 <= v109;\n\tif (v123) goto L_00AC;\n\tv509 = controlPoints.Length < 1;\n\tv477 = ~v509;\n\tv473 = controlPoints.Length - 1;\n\tv465 = v473 == 0;\n\tv510 = ~v477;\n\tv447 = v510 | v465;\n\tif (v447) goto L_01DE;\n\tv521 = controlPoints + 0x38;\n\tv381 = controlPoints + 0x3C;\n\tv379 = controlPoints + 0x40;\n\tgoto L_00CB;\nL_00AC:\n\tv508 = v113 < v168;\n\tv478 = ~v508;\n\tif (v478) goto L_01DE;\n\tv513 = v113 * 0xC;\n\tv514 = wps + v513;\n\tv521 = v514 + 0x20;\n\tv381 = v514 + 0x24;\n\tv379 = v514 + 0x28;\nL_00CB:\n\tv529 = v171 - v184;\n\tgoto L_00DA;\n\tv532 = *([v525 @ X0_v7+E0]);\n\tv533 = v532 == 0;\n\tv534 = ~v533;\n\tgoto L_00DA;\n\tv536 = \"il2cpp_codegen_runtime_class_init\"(v525, wps, p, controlPoints, methodInfo, v47, v48, v49, v529, v528, v79, v82, v53, v54, v55, v56);\nL_00DA:\n\t// 218 MakeStruct v354 @ AGG1080C94_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v446.m_value (System.Single), v445.m_value (System.Single), v444.m_value (System.Single)\n\tv541 = UnityEngine.Vector3::op_UnaryNegation(v354);\n\t// 233 MakeStruct v341 @ AGG1080CC4_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v503 @ X10_v4 (System.Single)+20], wps[v184 @ X8_v9 (System.Single)].y (System.Single), wps[v184 @ X8_v9 (System.Single)].z (System.Single)\n\tv553 = UnityEngine.Vector3::op_Multiply(3f, v341);\n\tv563 = UnityEngine.Vector3::op_Addition(v541, v553);\n\t// 257 MakeStruct v328 @ AGG1080D04_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v504 @ X11_v4 (System.Single)+20], wps[v443 @ X13_v2 (System.Single)].y (System.Single), wps[v443 @ X13_v2 (System.Single)].z (System.Single)\n\tv574 = UnityEngine.Vector3::op_Multiply(3f, v328);\n\tv584 = UnityEngine.Vector3::op_Subtraction(v563, v574);\n\t// 280 MakeStruct v316 @ AGG1080D3C_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v521.m_value (System.Single), v381.m_value (System.Single), v379.m_value (System.Single)\n\tv593 = UnityEngine.Vector3::op_Addition(v584, v316);\n\tv598 = v529 * v529;\n\tv599 = v529 * v598;\n\tv600 = UnityEngine.Vector3::op_Multiply(v593, v599);\n\t// 303 MakeStruct v295 @ AGG1080D7C_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v446.m_value (System.Single), v445.m_value (System.Single), v444.m_value (System.Single)\n\tv609 = UnityEngine.Vector3::op_Multiply(2f, v295);\n\t// 318 MakeStruct v286 @ AGG1080DA8_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v503 @ X10_v4 (System.Single)+20], wps[v184 @ X8_v9 (System.Single)].y (System.Single), wps[v184 @ X8_v9 (System.Single)].z (System.Single)\n\tv621 = UnityEngine.Vector3::op_Multiply(5f, v286);\n\tv631 = UnityEngine.Vector3::op_Subtraction(v609, v621);\n\t// 345 MakeStruct v277 @ AGG1080DF4_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v504 @ X11_v4 (System.Single)+20], wps[v443 @ X13_v2 (System.Single)].y (System.Single), wps[v443 @ X13_v2 (System.Single)].z (System.Single)\n\tv645 = UnityEngine.Vector3::op_Multiply(4f, v277);\n\tv655 = UnityEngine.Vector3::op_Addition(v631, v645);\n\t// 366 MakeStruct v265 @ AGG1080E28_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v521.m_value (System.Single), v381.m_value (System.Single), v379.m_value (System.Single)\n\tv662 = UnityEngine.Vector3::op_Subtraction(v655, v265);\n\tv667 = UnityEngine.Vector3::op_Multiply(v662, v598);\n\tv677 = UnityEngine.Vector3::op_Addition(v600, v667);\n\t// 395 MakeStruct v253 @ AGG1080E70_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v446.m_value (System.Single), v445.m_value (System.Single), v444.m_value (System.Single)\n\tv687 = UnityEngine.Vector3::op_UnaryNegation(v253);\n\t// 404 MakeStruct v247 @ AGG1080E84_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v504 @ X11_v4 (System.Single)+20], wps[v443 @ X13_v2 (System.Single)].y (System.Single), wps[v443 @ X13_v2 (System.Single)].z (System.Single)\n\tv694 = UnityEngine.Vector3::op_Addition(v687, v247);\n\tv699 = UnityEngine.Vector3::op_Multiply(v694, v529);\n\tv709 = UnityEngine.Vector3::op_Addition(v677, v699);\n\t// 434 MakeStruct v235 @ AGG1080ED0_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v503 @ X10_v4 (System.Single)+20], wps[v184 @ X8_v9 (System.Single)].y (System.Single), wps[v184 @ X8_v9 (System.Single)].z (System.Single)\n\tv720 = UnityEngine.Vector3::op_Multiply(2f, v235);\n\tv730 = UnityEngine.Vector3::op_Addition(v709, v720);\n\treturnVal2 = UnityEngine.Vector3::op_Multiply(0.5f, v730);\n\treturn returnVal2;\nL_01DE:\n\tv485 = new System.IndexOutOfRangeException();\n\tthrow v485;\n\tthrow System.NullReferenceException;\n// 358 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe override Vector3 GetPoint(float perc, Vector3[] wps, Path p, ControlPoint[] controlPoints)
		{
			//IL_0015: Expected O, but got I4
			//IL_0079: Expected O, but got F4
			//IL_0086: Expected O, but got F4
			//IL_0107: Expected O, but got I4
			//IL_01bf: Expected O, but got I4
			//IL_028a: Expected O, but got I
			//IL_02d7: Expected O, but got I4
			//IL_03c6: Expected native int or pointer, but got F4
			//IL_03d8: Expected native int or pointer, but got F4
			//IL_03ea: Expected native int or pointer, but got F4
			//IL_0416: Expected F4, but got I
			//IL_0489: Expected F4, but got I
			//IL_04ef: Expected native int or pointer, but got F4
			//IL_0501: Expected native int or pointer, but got F4
			//IL_0513: Expected native int or pointer, but got F4
			//IL_056a: Expected native int or pointer, but got F4
			//IL_057c: Expected native int or pointer, but got F4
			//IL_058e: Expected native int or pointer, but got F4
			//IL_05c4: Expected F4, but got I
			//IL_0637: Expected F4, but got I
			//IL_069d: Expected native int or pointer, but got F4
			//IL_06af: Expected native int or pointer, but got F4
			//IL_06c1: Expected native int or pointer, but got F4
			//IL_070b: Expected native int or pointer, but got F4
			//IL_071d: Expected native int or pointer, but got F4
			//IL_072f: Expected native int or pointer, but got F4
			//IL_0760: Expected F4, but got I
			//IL_07e3: Expected F4, but got I
			object obj = wps.Length - 1;
			float num = (float)obj * perc;
			float num2 = (float)wps.Length - 3E-45f;
			float num3 = num2 - num;
			bool flag = num3 < 0f;
			bool flag2 = num3 == 0f;
			object obj2 = num2 ^ num;
			object obj3 = num2 ^ num3;
			int num4 = (int)((long)(IntPtr)obj2 & (long)(IntPtr)obj3);
			bool flag3 = num4 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			float num5 = ((!(flag4 && flag5)) ? num2 : num);
			object obj4;
			float num9;
			float num10;
			float num11;
			if (num5 != 0f)
			{
				obj4 = wps.Length;
				float num6 = num5 - float.Epsilon;
				if (!(num6 < (float)wps.Length))
				{
					goto IL_085d;
				}
				float num7 = num6 * 1.7E-44f;
				float num8 = (float)wps + num7;
				num9 = num8 + 4.5E-44f;
				num10 = num8 + 5E-44f;
				num11 = num8 + 5.6E-44f;
			}
			else
			{
				if (controlPoints.Length == 0)
				{
					goto IL_085d;
				}
				obj4 = wps.Length;
				num9 = (float)controlPoints + 4.5E-44f;
				num10 = (float)controlPoints + 5E-44f;
				num11 = (float)controlPoints + 5.6E-44f;
			}
			if (num5 < (float)obj4)
			{
				float num12 = num5 + float.Epsilon;
				if (num12 < (float)obj4)
				{
					float num13 = num5 * 1.7E-44f;
					float num14 = (float)wps + num13;
					float num15 = num12 * 1.7E-44f;
					float num16 = (float)wps + num15;
					float num17 = num5 + 3E-45f;
					object obj5 = (long)(IntPtr)obj4 - 1L;
					float num18;
					float num19;
					float num20;
					if (num17 > (float)obj5)
					{
						bool flag6 = controlPoints.Length < 1;
						bool flag7 = !flag6;
						object obj6 = controlPoints.Length - 1;
						bool flag8 = obj6 == null;
						bool flag9 = !flag7;
						if (flag9 || flag8)
						{
							goto IL_085d;
						}
						num18 = (float)controlPoints + 7.8E-44f;
						num19 = (float)controlPoints + 8.4E-44f;
						num20 = (float)controlPoints + 9E-44f;
					}
					else
					{
						if (!(num17 < (float)obj4))
						{
							goto IL_085d;
						}
						float num21 = num17 * 1.7E-44f;
						float num22 = (float)wps + num21;
						num18 = num22 + 4.5E-44f;
						num19 = num22 + 5E-44f;
						num20 = num22 + 5.6E-44f;
					}
					float num23 = num - num5;
					Vector3 vector = default(Vector3);
					vector.x = ((float*)(IntPtr)num9)->m_value;
					vector.y = ((float*)(IntPtr)num10)->m_value;
					vector.z = ((float*)(IntPtr)num11)->m_value;
					Vector3 vector2 = -vector;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ X10_v4 (System.Single)+20]");
					Vector3 vector3 = default(Vector3);
					vector3.x = 0f;
					vector3.y = wps[num5].y;
					vector3.z = wps[num5].z;
					Vector3 vector4 = 3f * vector3;
					Vector3 vector5 = vector2 + vector4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ X11_v4 (System.Single)+20]");
					Vector3 vector6 = default(Vector3);
					vector6.x = 0f;
					vector6.y = wps[num12].y;
					vector6.z = wps[num12].z;
					Vector3 vector7 = 3f * vector6;
					Vector3 vector8 = vector5 - vector7;
					Vector3 vector9 = default(Vector3);
					vector9.x = ((float*)(IntPtr)num18)->m_value;
					vector9.y = ((float*)(IntPtr)num19)->m_value;
					vector9.z = ((float*)(IntPtr)num20)->m_value;
					Vector3 vector10 = vector8 + vector9;
					float num24 = num23 * num23;
					float num25 = num23 * num24;
					Vector3 vector11 = vector10 * num25;
					Vector3 vector12 = default(Vector3);
					vector12.x = ((float*)(IntPtr)num9)->m_value;
					vector12.y = ((float*)(IntPtr)num10)->m_value;
					vector12.z = ((float*)(IntPtr)num11)->m_value;
					Vector3 vector13 = 2f * vector12;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ X10_v4 (System.Single)+20]");
					Vector3 vector14 = default(Vector3);
					vector14.x = 0f;
					vector14.y = wps[num5].y;
					vector14.z = wps[num5].z;
					Vector3 vector15 = 5f * vector14;
					Vector3 vector16 = vector13 - vector15;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ X11_v4 (System.Single)+20]");
					Vector3 vector17 = default(Vector3);
					vector17.x = 0f;
					vector17.y = wps[num12].y;
					vector17.z = wps[num12].z;
					Vector3 vector18 = 4f * vector17;
					Vector3 vector19 = vector16 + vector18;
					Vector3 vector20 = default(Vector3);
					vector20.x = ((float*)(IntPtr)num18)->m_value;
					vector20.y = ((float*)(IntPtr)num19)->m_value;
					vector20.z = ((float*)(IntPtr)num20)->m_value;
					Vector3 vector21 = vector19 - vector20;
					Vector3 vector22 = vector21 * num24;
					Vector3 vector23 = vector11 + vector22;
					Vector3 vector24 = default(Vector3);
					vector24.x = ((float*)(IntPtr)num9)->m_value;
					vector24.y = ((float*)(IntPtr)num10)->m_value;
					vector24.z = ((float*)(IntPtr)num11)->m_value;
					Vector3 vector25 = -vector24;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ X11_v4 (System.Single)+20]");
					Vector3 vector26 = default(Vector3);
					vector26.x = 0f;
					vector26.y = wps[num12].y;
					vector26.z = wps[num12].z;
					Vector3 vector27 = vector25 + vector26;
					Vector3 vector28 = vector27 * num23;
					Vector3 vector29 = vector23 + vector28;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ X10_v4 (System.Single)+20]");
					Vector3 vector30 = default(Vector3);
					vector30.x = 0f;
					vector30.y = wps[num5].y;
					vector30.z = wps[num5].z;
					Vector3 vector31 = 2f * vector30;
					Vector3 vector32 = vector29 + vector31;
					return 0.5f * vector32;
				}
			}
			goto IL_085d;
			IL_085d:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x600024E")]
		[Address(RVA = "0x10804D0", Offset = "0x10804D0", Length = "0x1F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv50 = *([1F0AA78]);\n\tv51 = *([v50 @ X8_v18]);\n\tv52 = \"il2cpp_codegen_initialize_method\"(v51, p, subdivisions, methodInfo, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65);\n\tv68 = 0 | 1;\n\t*([2026A46]) = v68;\nL_0027:\n\t// 39 NewArr v73 @ X0_v3 (System.Single[]), typeof(System.Single[]), subdivisions @ X2 (System.Int32)\n\t// 44 NewArr v78 @ X0_v5 (System.Single[]), typeof(System.Single[]), subdivisions @ X2 (System.Int32)\n\tv90 = DG.Tweening.Plugins.Core.PathCore.CatmullRomDecoder::GetPoint(this, 0f, p.wps, p, p.controlPoints);\n\tv91 = subdivisions + 1;\n\tv105 = v91 < 2;\n\tif (v105) goto L_00A6;\n\tv210 = 1f / subdivisions;\nL_0057:\n\tv115 = v131 - 7;\n\tv107 = v210 * v115;\n\tv359 = DG.Tweening.Plugins.Core.PathCore.CatmullRomDecoder::GetPoint(this, v107, p.wps, p, p.controlPoints);\n\tgoto L_0074;\n\tv411 = *([v360 @ X0_v18+E0]);\n\tv412 = v411 == 0;\n\tv413 = ~v412;\n\tgoto L_0074;\n\tv415 = \"il2cpp_codegen_runtime_class_init\"(v360, v195, v183, v193, v185, v55, v56, v57, v358, v355, v343, v342, v341, v340, v64, v65);\nL_0074:\n\t// 116 MakeStruct v121 @ AGG1080624_0_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v107 @ V14_v6 (System.Single), v210 @ V0_v6 (System.Single), v343 @ V2_v4\n\t// 117 MakeStruct v118 @ AGG1080624_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v179 @ V9_v6 (System.Single), v177 @ V8_v6 (System.Single), v143 @ V10_v6\n\tv191 = UnityEngine.Vector3::Distance(v121, v118);\n\tv205 = v115 - 1;\n\tv418 = v205 < v73.Length;\n\tv175 = ~v418;\n\tif (v175) goto L_00BF;\n\t*([v73 @ X0_v3 (System.Single[])+v131 @ X24_v6 (System.Int32)*4]) = v107;\n\tv419 = v205 < v78.Length;\n\tv318 = ~v419;\n\tif (v318) goto L_00BF;\n\tv254 = v181 + v191;\n\tv267 = v205 + 2;\n\t*([v78 @ X0_v5 (System.Single[])+v131 @ X24_v6 (System.Int32)*4]) = v254;\n\tv131 = v131 + 1;\n\tv231 = v267 < v91;\n\tif (v231) goto L_0057;\nL_00A6:\n\tp.length = v254;\n\tp.timesTable = v73;\n\tp.lengthsTable = v78;\n\treturn;\n\tv207 = new System.NullReferenceException();\nL_00BF:\n\tv332 = new System.IndexOutOfRangeException();\n\tthrow v332;\n\treturn;\n// 149 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void SetTimeToLengthTables(Path p, int subdivisions)
		{
			//IL_00c6: Expected F4, but got O
			//IL_00ed: Expected F4, but got O
			float[] array = new float[subdivisions];
			float[] array2 = new float[subdivisions];
			Vector3 point = GetPoint(0f, p.wps, p, p.controlPoints);
			int num = subdivisions + 1;
			bool flag = num < 2;
			float num2 = 0f;
			if (!flag)
			{
				float num3 = 1f / (float)subdivisions;
				int num4 = 8;
				object obj2 = default(object);
				object obj = obj2;
				float num5 = default(float);
				float y = num5;
				float x = 0f;
				float num6 = 0f;
				Vector3 a = default(Vector3);
				Vector3 b = default(Vector3);
				bool flag2;
				do
				{
					int num7 = num4 - 7;
					float num8 = num3 * (float)num7;
					Vector3 point2 = GetPoint(num8, p.wps, p, p.controlPoints);
					a.x = num8;
					a.y = num3;
					a.z = (float)obj2;
					b.x = x;
					b.y = y;
					b.z = (float)obj;
					float num9 = Vector3.Distance(a, b);
					int num10 = num7 - 1;
					if (num10 < array.Length && num10 < array2.Length)
					{
						num2 = num6 + num9;
						int num11 = num10 + 2;
						num4++;
						flag2 = num11 < num;
						obj = obj2;
						y = num3;
						x = num8;
						num6 = num2;
						continue;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				while (flag2);
			}
			p.length = num2;
			p.timesTable = array;
			p.lengthsTable = array2;
		}

		[Token(Token = "0x600024F")]
		[Address(RVA = "0x10806C0", Offset = "0x10806C0", Length = "0x3F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv54 = *([1ED2358]);\n\tv55 = *([v54 @ X8_v51]);\n\tv56 = \"il2cpp_codegen_initialize_method\"(v55, p, subdivisions, methodInfo, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69);\n\tv72 = 0 | 1;\n\t*([2026A47]) = v72;\nL_0027:\n\tv74 = p.wps;\n\t// 47 NewArr v269 @ X0_v10 (System.Single[]), typeof(System.Single[]), v74.Length\n\tv438 = v269.Length == 0;\n\tif (v438) goto L_01C8;\n\tv269[0] = 0;\n\tv461 = v74.Length < 2;\n\tif (v461) goto L_01AF;\n\tv462 = v74.Length - 1;\n\tv463 = subdivisions + 1;\n\tv141 = 1f / subdivisions;\nL_0055:\n\tgoto L_005D;\n\tv602 = *([v598 @ X0_v13 (Il2CppClass<DG.Tweening.Plugins.Core.PathCore.CatmullRomDecoder>)+E0]);\n\tv603 = v602 == 0;\n\tv604 = ~v603;\n\tgoto L_005D;\n\tv609 = \"il2cpp_codegen_runtime_class_init\"(v598, v239, v81, v79, v77, v59, v60, v61, v149, v147, v110, v108, v106, v104, v68, v69);\n\tv605 = DG.Tweening.Plugins.Core.PathCore.CatmullRomDecoder;\nL_005D:\n\tv257 = v608._PartialControlPs;\n\tv439 = v257.Length == 0;\n\tif (v439) goto L_01C8;\n\tv128 = v145 - 1;\n\tv162 = v145 != 1;\n\tif (v162) goto L_0077;\n\tv614 = p.controlPoints;\n\tv611 = v614.Length == 0;\n\tv440 = ~v611;\n\tif (v440) goto L_008E;\n\tgoto L_01C8;\nL_0077:\n\tv133 = p.wps;\n\tv351 = v145 - 2;\n\tv612 = v351 < v133.Length;\n\tv427 = ~v612;\n\tif (v427) goto L_01C8;\n\tv618 = v351 * 0xC;\n\tv614 = v133 + v618;\nL_008E:\n\t*([v257 @ X8_v17 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+20]) = *([v614 @ X11_v6 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+20]);\n\t*([v257 @ X8_v17 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+24]) = *([v614 @ X11_v6 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+24]);\n\t*([v257 @ X8_v17 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+28]) = *([v614 @ X11_v6 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+28]);\n\tgoto L_009C;\n\tv626 = *([v622 @ X0_v15 (Il2CppClass<DG.Tweening.Plugins.Core.PathCore.CatmullRomDecoder>)+E0]);\n\tv627 = v626 == 0;\n\tv628 = ~v627;\n\tgoto L_009C;\n\tv632 = \"il2cpp_codegen_runtime_class_init\"(v622, v239, v81, v79, v77, v59, v60, v61, v149, v147, v110, v108, v106, v104, v68, v69);\n\tv629 = DG.Tweening.Plugins.Core.PathCore.CatmullRomDecoder;\nL_009C:\n\tv258 = p.wps;\n\tv633 = v128 < v258.Length;\n\tv232 = ~v633;\n\tif (v232) goto L_01C8;\n\tv134 = v634._PartialWps;\n\tv441 = v134.Length == 0;\n\tif (v441) goto L_01C8;\n\tv635 = v128 * 0xC;\n\tv636 = v258 + v635;\n\t*([v134 @ X9_v12 (UnityEngine.Vector3[])+20]) = *([v636 @ X8_v21+20]);\n\t*([v134 @ X9_v12 (UnityEngine.Vector3[])+24]) = v258[v128 @ X25_v7 (System.Int32)].y;\n\t*([v134 @ X9_v12 (UnityEngine.Vector3[])+28]) = v258[v128 @ X25_v7 (System.Int32)].z;\n\tv259 = p.wps;\n\tv638 = v145 < v259.Length;\n\tv233 = ~v638;\n\tif (v233) goto L_01C8;\n\tv135 = v640._PartialWps;\n\tv641 = v135.Length < 1;\n\tv234 = ~v641;\n\tv225 = v135.Length - 1;\n\tv207 = v225 == 0;\n\tv642 = ~v234;\n\tv163 = v642 | v207;\n\tif (v163) goto L_01C8;\n\tv643 = v145 * 0xC;\n\tv644 = v259 + v643;\n\t*([v135 @ X9_v16 (UnityEngine.Vector3[])+2C]) = *([v644 @ X8_v24+20]);\n\t*([v135 @ X9_v16 (UnityEngine.Vector3[])+30]) = v259[v145 @ X26_v7 (System.Int32)].y;\n\t*([v135 @ X9_v16 (UnityEngine.Vector3[])+34]) = v259[v145 @ X26_v7 (System.Int32)].z;\n\tv260 = v647._PartialControlPs;\n\tv648 = v260.Length < 1;\n\tv428 = ~v648;\n\tv422 = v260.Length - 1;\n\tv410 = v422 == 0;\n\tv649 = ~v428;\n\tv381 = v649 | v410;\n\tif (v381) goto L_01C8;\n\tv164 = v145 != v462;\n\tif (v164) goto L_0113;\n\tv126 = p.controlPoints;\n\tv651 = v126.Length < 1;\n\tv429 = ~v651;\n\tv423 = v126.Length - 1;\n\tv411 = v423 == 0;\n\tv652 = ~v429;\n\tv382 = v652 | v411;\n\tif (v382) goto L_01C8;\n\tv664 = v126 + 0x38;\n\tv662 = v126 + 0x3C;\n\tv663 = v126 + 0x40;\n\tgoto L_012A;\nL_0113:\n\tv137 = p.wps;\n\tv354 = v145 + 1;\n\tv653 = v354 < v137.Length;\n\tv430 = ~v653;\n\tif (v430) goto L_01C8;\n\tv657 = v354 * 0xC;\n\tv658 = v137 + v657;\n\tv664 = v658 + 0x20;\n\tv662 = v658 + 0x24;\n\tv663 = v658 + 0x28;\nL_012A:\n\t*([v260 @ X8_v28 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+38]) = *([v664 @ X9_v19]);\n\t*([v260 @ X8_v28 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+3C]) = *([v662 @ X10_v13]);\n\t*([v260 @ X8_v28 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+40]) = *([v663 @ X11_v11]);\n\tgoto L_0142;\n\tv680 = *([v676 @ X0_v17 (Il2CppClass<DG.Tweening.Plugins.Core.PathCore.CatmullRomDecoder>)+E0]);\n\tv681 = v680 == 0;\n\tv682 = ~v681;\n\tgoto L_0142;\n\tv713 = \"il2cpp_codegen_runtime_class_init\"(v676, v239, v81, v79, v77, v59, v60, v61, v149, v147, v110, v108, v106, v104, v68, v69);\n\tv684 = DG.Tweening.Plugins.Core.PathCore.CatmullRomDecoder;\nL_0142:\n\tv697 = DG.Tweening.Plugins.Core.PathCore.CatmullRomDecoder::GetPoint(this, 0f, v687._PartialWps, p, v687._PartialControlPs);\n\tv712 = v463 < 2;\n\tif (v712) goto L_0195;\nL_0156:\n\tv793 = v775 + 1;\n\tv796 = v141 * v793;\n\tgoto L_016F;\n\tv801 = *([v792 @ X0_v23 (Il2CppClass<DG.Tweening.Plugins.Core.PathCore.CatmullRomDecoder>)+E0]);\n\tv802 = v801 == 0;\n\tv803 = ~v802;\n\tgoto L_016F;\n\tv817 = \"il2cpp_codegen_runtime_class_init\"(v792, v788, v761, v760, v759, v59, v60, v61, v794, v777, v773, v772, v771, v770, v68, v69);\n\tv805 = DG.Tweening.Plugins.Core.PathCore.CatmullRomDecoder;\nL_016F:\n\tv812 = DG.Tweening.Plugins.Core.PathCore.CatmullRomDecoder::GetPoint(this, v796, v808._PartialWps, p, v808._PartialControlPs);\n\tgoto L_0184;\n\tv818 = *([v813 @ X0_v27+E0]);\n\tv819 = v818 == 0;\n\tv820 = ~v819;\n\tgoto L_0184;\n\tv822 = \"il2cpp_codegen_runtime_class_init\"(v813, v753, v718, v717, v716, v59, v60, v61, v810, v777, v773, v772, v771, v770, v68, v69);\nL_0184:\n\t// 388 MakeStruct v726 @ AGG1080A38_0_v8 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v796 @ V8_v10 (System.Single), 1f, v773 @ V2_v7\n\t// 389 MakeStruct v725 @ AGG1080A38_1_v8 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v766 @ V8_v9 (System.Single), v767 @ V9_v9 (System.Single), v764 @ V10_v9\n\tv735 = UnityEngine.Vector3::Distance(v726, v725);\n\tv775 = v775 + 1;\n\tv349 = v774 + v735;\n\tv736 = subdivisions != v775;\n\tif (v736) goto L_0156;\nL_0195:\n\tv758 = v145 < v269.Length;\n\tv431 = ~v758;\n\tif (v431) goto L_01C8;\n\tv494 = v145 + 1;\n\tv269[v145 @ X26_v7 (System.Int32)] = v349;\n\tv502 = v494 < v74.Length;\n\tif (v502) goto L_0055;\nL_01AF:\n\tp.wpLengths = v269;\n\treturn;\n\tv316 = new System.NullReferenceException();\nL_01C8:\n\tv447 = new System.IndexOutOfRangeException();\n\tthrow v447;\n\treturn;\n// 300 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void SetWaypointsLengths(Path p, int subdivisions)
		{
			//IL_01ac: Expected O, but got I
			//IL_0223: Expected O, but got I
			//IL_02cb: Expected O, but got I4
			//IL_031c: Expected O, but got I
			//IL_0389: Expected O, but got I4
			//IL_041b: Expected O, but got I4
			//IL_04e7: Expected O, but got I
			//IL_04f6: Expected O, but got I
			//IL_0505: Expected O, but got I
			//IL_0514: Expected O, but got I
			//IL_045f: Expected O, but got I
			//IL_046e: Expected O, but got I
			//IL_047d: Expected O, but got I
			//IL_0572: Expected F4, but got O
			//IL_0599: Expected F4, but got O
			Vector3[] wps = p.wps;
			float[] array = new float[wps.Length];
			if (array.Length != 0)
			{
				array[0] = 0f;
				if (wps.Length < 2)
				{
					goto IL_0675;
				}
				int num = wps.Length - 1;
				int num2 = subdivisions + 1;
				float num3 = 1f / (float)subdivisions;
				int num4 = 1;
				object obj11 = default(object);
				Vector3 a = default(Vector3);
				Vector3 b = default(Vector3);
				while (true)
				{
					ControlPoint[] partialControlPs = _PartialControlPs;
					if (partialControlPs.Length == 0)
					{
						break;
					}
					int num5 = num4 - 1;
					if (num4 == 1)
					{
						ControlPoint[] controlPoints = p.controlPoints;
						if (controlPoints.Length == 0)
						{
							break;
						}
					}
					else
					{
						Vector3[] wps2 = p.wps;
						int num6 = num4 - 2;
						if (num6 >= wps2.Length)
						{
							break;
						}
						int num7 = num6 * 12;
						ControlPoint[] controlPoints = (ControlPoint[])((long)(IntPtr)wps2 + (long)num7);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v614 @ X11_v6 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+20]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v614 @ X11_v6 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+24]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v614 @ X11_v6 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+28]");
					_ = 0;
					Vector3[] wps3 = p.wps;
					if (num5 >= wps3.Length)
					{
						break;
					}
					Vector3[] partialWps = _PartialWps;
					if (partialWps.Length == 0)
					{
						break;
					}
					int num8 = num5 * 12;
					object obj = (long)(IntPtr)wps3 + (long)num8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v636 @ X8_v21+20]");
					_ = 0;
					_ = wps3[num5].y;
					_ = wps3[num5].z;
					Vector3[] wps4 = p.wps;
					if (num4 >= wps4.Length)
					{
						break;
					}
					Vector3[] partialWps2 = _PartialWps;
					bool flag = partialWps2.Length < 1;
					bool flag2 = !flag;
					object obj2 = partialWps2.Length - 1;
					bool flag3 = obj2 == null;
					bool flag4 = !flag2;
					if (flag4 || flag3)
					{
						break;
					}
					int num9 = num4 * 12;
					object obj3 = (long)(IntPtr)wps4 + (long)num9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ X8_v24+20]");
					_ = 0;
					_ = wps4[num4].y;
					_ = wps4[num4].z;
					ControlPoint[] partialControlPs2 = _PartialControlPs;
					bool flag5 = partialControlPs2.Length < 1;
					bool flag6 = !flag5;
					object obj4 = partialControlPs2.Length - 1;
					bool flag7 = obj4 == null;
					bool flag8 = !flag6;
					if (flag8 || flag7)
					{
						break;
					}
					if (num4 == num)
					{
						ControlPoint[] controlPoints2 = p.controlPoints;
						bool flag9 = controlPoints2.Length < 1;
						bool flag10 = !flag9;
						object obj5 = controlPoints2.Length - 1;
						bool flag11 = obj5 == null;
						bool flag12 = !flag10;
						if (flag12 || flag11)
						{
							break;
						}
						object obj6 = (long)(IntPtr)controlPoints2 + 56L;
						object obj7 = (long)(IntPtr)controlPoints2 + 60L;
						object obj8 = (long)(IntPtr)controlPoints2 + 64L;
					}
					else
					{
						Vector3[] wps5 = p.wps;
						int num10 = num4 + 1;
						if (num10 >= wps5.Length)
						{
							break;
						}
						int num11 = num10 * 12;
						object obj9 = (long)(IntPtr)wps5 + (long)num11;
						object obj6 = (long)(IntPtr)obj9 + 32L;
						object obj7 = (long)(IntPtr)obj9 + 36L;
						object obj8 = (long)(IntPtr)obj9 + 40L;
					}
					Vector3 point = GetPoint(0f, _PartialWps, p, _PartialControlPs);
					bool flag13 = num2 < 2;
					float num12 = 0f;
					if (!flag13)
					{
						object obj10 = obj11;
						float x = 0f;
						float y = 1f;
						float num13 = 0f;
						int num14 = 0;
						bool flag14;
						do
						{
							int num15 = num14 + 1;
							float num16 = num3 * (float)num15;
							Vector3 point2 = GetPoint(num16, _PartialWps, p, _PartialControlPs);
							a.x = num16;
							a.y = 1f;
							a.z = (float)obj11;
							b.x = x;
							b.y = y;
							b.z = (float)obj10;
							float num17 = Vector3.Distance(a, b);
							num14++;
							num12 = num13 + num17;
							flag14 = subdivisions != num14;
							obj10 = obj11;
							x = num16;
							y = 1f;
							num13 = num12;
						}
						while (flag14);
					}
					if (num4 >= array.Length)
					{
						break;
					}
					int num18 = num4 + 1;
					array[num4] = num12;
					bool flag15 = num18 < wps.Length;
					num4 = num18;
					if (!flag15)
					{
						goto IL_0675;
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_0675:
			p.wpLengths = array;
		}

		[Token(Token = "0x6000250")]
		[Address(RVA = "0x1080F50", Offset = "0x1080F50", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CatmullRomDecoder()
		{
		}

		[Token(Token = "0x6000251")]
		[Address(RVA = "0x1080F58", Offset = "0x1080F58", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = *([1F03930]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2026A48]) = v35;\nL_0015:\n\t// 21 NewArr v40 @ X0_v3 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[]), typeof(DG.Tweening.Plugins.Core.PathCore.ControlPoint[]), 2\n\tv45._PartialControlPs = v40;\n\t// 31 NewArr v49 @ X0_v5 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), 2\n\tv51._PartialWps = v49;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static CatmullRomDecoder()
		{
			ControlPoint[] partialControlPs = new ControlPoint[2];
			_PartialControlPs = partialControlPs;
			Vector3[] partialWps = new Vector3[2];
			_PartialWps = partialWps;
		}
	}
}
