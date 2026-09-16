using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening.Plugins.Core.PathCore
{
	[Token(Token = "0x2000099")]
	internal class CubicBezierDecoder : ABSPathDecoder
	{
		[Token(Token = "0x40001A6")]
		private static readonly ControlPoint[] _PartialControlPs;

		[Token(Token = "0x40001A7")]
		private static readonly Vector3[] _PartialWps;

		[Token(Token = "0x1700000A")]
		internal override int minInputWaypoints
		{
			[Token(Token = "0x6000389")]
			[Address(RVA = "0xC28680", Offset = "0xC28680", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 3;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return 3;
			}
		}

		[Token(Token = "0x600038A")]
		[Address(RVA = "0xC28688", Offset = "0xC28688", Length = "0x4D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv46 = DG.Tweening.Plugins.Core.PathCore.ControlPoint[];\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, p, wps, isClosedPath, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv67 = UnityEngine.Debug;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, p, wps, isClosedPath, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv72 = UnityEngine.Vector3[];\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, p, wps, isClosedPath, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv296 = \"CubicBezier paths must contain waypoints in multiple of 3 excluding the starting point added automatically by DOTween (1: waypoint, 2: IN control point, 3: OUT control point — the minimum amount of waypoints for a single curve is 3)\";\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v296, p, wps, isClosedPath, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv63 = 1;\n\t*([1A357A0]) = v63;\nL_002A:\n\tv65 = isClosedPath == 0;\n\tif (v65) goto L_FFFFFFFF;\n\tv79 = p.addedExtraEndWp == 0;\n\tv84 = ~v79;\n\tgoto L_0043;\nL_0043:\n\tv419 = p.addedExtraEndWp + p.addedExtraStartWp;\n\tv420 = v419 + 3;\n\tv196 = v420 > wps.Length;\n\tif (v196) goto L_006D;\n\tv432 = wps.Length - v419;\n\tv434 = v432 * 0x55555556;\n\tv435 = v434 >> 0x3F;\n\tv436 = v434 >> 0x20;\n\tv185 = v436 + v435;\n\tv161 = v185 << 1;\n\tv166 = v185 + v161;\n\tv236 = v432 == v166;\n\tif (v236) goto L_0086;\nL_006D:\n\tgoto L_0082;\n\tv448 = \"il2cpp_codegen_runtime_class_init\"(v441, p, wps, isClosedPath, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\nL_0082:\n\tUnityEngine.Debug::LogError(\"CubicBezier paths must contain waypoints in multiple of 3 excluding the starting point added automatically by DOTween (1: waypoint, 2: IN control point, 3: OUT control point — the minimum amount of waypoints for a single curve is 3)\");\n\treturn;\nL_0086:\n\tv280 = v185 + v419;\n\t// 137 NewArr v447 @ X0_v7 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), v280 @ X21_v3\n\tv136 = v280 - 1;\n\t// 143 NewArr v266 @ X0_v9 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[]), typeof(DG.Tweening.Plugins.Core.PathCore.ControlPoint[]), v136 @ X1_v3\n\tp.controlPoints = v266;\n\t*([v447 @ X0_v7 (UnityEngine.Vector3[])+20]) = *([wps @ X2 (UnityEngine.Vector3[])+20]);\n\t*([v447 @ X0_v7 (UnityEngine.Vector3[])+28]) = *([wps @ X2 (UnityEngine.Vector3[])+28]);\n\tif (p.addedExtraStartWp) goto L_FFFFFFFF;\n\tgoto L_00B8;\nL_00B8:\n\tv555 = v285 >= wps.Length;\n\tif (v555) goto L_0121;\nL_00BE:\n\tv460 = v285 - 2;\n\tv624 = v460 * 0xC;\n\tv625 = wps + v624;\n\tv523 = v167 * 0xC;\n\tv627 = v447 + v523;\n\t*([v627 @ X12_v8+20]) = *([v625 @ X12_v6+20]);\n\tv447[v167 @ X11_v10 (System.Int32)].z = wps[v460 @ X12_v4 (System.Int32)].z;\n\tv121 = v285 - 1;\n\tv475 = v167 - 1;\n\tv660 = v121 * 0xC;\n\tv661 = wps + v660;\n\tv663 = v285 * 0xC;\n\tv560 = wps + v663;\n\tv285 = v285 + 3;\n\tv584 = v475 * 0x18;\n\tv559 = p.controlPoints + v584;\n\tv167 = v475 + 2;\n\t*([v559 @ X12_v11+20]) = *([v661 @ X13_v8+20]);\n\t*([v559 @ X12_v11+28]) = wps[v121 @ X13_v6 (System.Int32)].z;\n\t*([v559 @ X12_v11+2C]) = *([v560 @ X13_v10+20]);\n\t*([v559 @ X12_v11+34]) = wps[v285 @ X8_v41 (System.Int32)].z;\n\tv566 = v285 < wps.Length;\n\tif (v566) goto L_00BE;\nL_0121:\n\tp.wps = v447;\n\tv524 = ~v191;\n\tif (v524) goto L_01E9;\n\tv291 = v447 + 0x20;\n\tv286 = p.controlPoints;\n\tv632 = v447.Length - 2;\n\tv635 = v632 * 0xC;\n\tv636 = v291 + v635;\n\tv638 = p.controlPoints + 0x20;\n\tv176 = v286.Length - 2;\n\tv641 = v176 * 0x18;\n\tv188 = v638 + v641;\n\tgoto L_FFFFFFFF;\n\tv645 = System.Math;\n\tv646 = \"il2cpp_codegen_initialize_runtime_metadata\"(v645, v136, wps, isClosedPath, methodInfo, v49, v50, v51, v134, v130, v107, v637, v56, v57, v58, v59);\n\tv648 = v98;\n\tv651 = 1;\n\t*([1A35759]) = v651;\n\tgoto L_0169;\n\tv657 = \"il2cpp_codegen_runtime_class_init\"(v653, v136, wps, isClosedPath, methodInfo, v49, v50, v51, v134, v130, v107, v647, v56, v57, v58, v59);\n\tv658 = v98;\nL_0169:\n\tv278 = p.controlPoints;\n\tv666 = *([v447 @ X0_v7 (UnityEngine.Vector3[])+20]) - *([v636 @ X9_v16]);\n\tv667 = v666 * v666;\n\tv668 = *([v447 @ X0_v7 (UnityEngine.Vector3[])+28]) - *([v636 @ X9_v16+8]);\n\t// 369 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv670 = v668 * v668;\n\tv671 = v667 + *([v560 @ X13_v10+20]);\n\tv672 = v671 + v670;\n\tv470 = *([v636 @ X9_v16]) - *([v188 @ X9_v18+C]);\n\tv754 = UnityEngine.Mathf::Sqrt(v672);\n\tv471 = *([v636 @ X9_v16+8]) - *([v188 @ X9_v18+14]);\n\tgoto L_0184;\n\tv679 = System.Math;\n\tv680 = \"il2cpp_codegen_initialize_runtime_metadata\"(v679, v136, wps, isClosedPath, methodInfo, v49, v50, v51, v672, v670, v674, v103, v56, v57, v58, v59);\n\tv684 = v455;\n\tv682 = v98;\n\tv687 = 1;\n\t*([1A3575A]) = v687;\nL_0184:\n\tv688 = v470 * v470;\n\tv689 = v471 * v471;\n\t// 390 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv690 = v689 + v688;\n\tv468 = v754 * v754;\n\tv702 = v690 <= v468;\n\tif (v702) goto L_019E;\n\tv703 = System.Math;\n\tv705 = *([v703 @ X0_v28 (Il2CppClass<System.Math>)+E0]) == 0;\n\tif (v705) goto L_FFFFFFFF;\n\tgoto L_01A3;\nL_019E:\n\tgoto L_01AB;\nL_01A3:\n\tv732 = UnityEngine.Mathf::Sqrt(v690);\n\t// 420 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv716 = v471 / v732;\n\tv714 = v470 / v689;\n\tv470 = v714 * v748;\n\tv471 = v754 * v716;\nL_01AB:\n\tv469 = *([v447 @ X0_v7 (UnityEngine.Vector3[])+20]) - *([v286 @ X8_v20 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+20]);\n\tv473 = v753 - *([v286 @ X8_v20 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+28]);\n\tgoto L_01B7;\n\tv734 = System.Math;\n\tv735 = \"il2cpp_codegen_initialize_runtime_metadata\"(v734, v136, wps, isClosedPath, methodInfo, v49, v50, v51, v724, v713, v711, v709, v56, v57, v58, v59);\n\tv739 = v455;\n\tv737 = v98;\n\tv742 = 1;\n\t*([1A3575A]) = v742;\nL_01B7:\n\tv743 = v469 * v469;\n\t// 440 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv744 = v473 * v473;\n\tv474 = v744 + v743;\n\tv478 = v474 <= v468;\n\tif (v478) goto L_01DA;\n\tgoto L_01D0;\n\tv762 = \"il2cpp_codegen_runtime_class_init\"(v749, v136, wps, isClosedPath, methodInfo, v49, v50, v51, v743, v744, v738, v736, v56, v57, v58, v59);\n\tv764 = v455;\n\tv763 = v98;\nL_01D0:\n\tv765 = UnityEngine.Mathf::Sqrt(v474);\n\t// 465 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv756 = v473 / v765;\n\tv755 = v469 / v744;\n\tv469 = v755 * v748;\n\tv473 = v754 * v756;\nL_01DA:\n\tv767 = v278.Length - 1;\n\tv602 = *([v636 @ X9_v16]) + v470;\n\tv601 = *([v636 @ X9_v16+8]) + v471;\n\tv600 = v753 + v473;\n\tv599 = *([v447 @ X0_v7 (UnityEngine.Vector3[])+20]) + v469;\n\tv614 = v767 * 0x18;\n\tv617 = v278 + v614;\n\t*([v617 @ X8_v31+20]) = v602;\n\tv278[v767 @ X8_v30].a.z = v601;\n\tv278[v767 @ X8_v30].b = v599;\n\tv278[v767 @ X8_v30].b.z = v600;\nL_01E9:\n\tv621 = p.subdivisionsXSegment * v280;\n\tp.subdivisions = v621;\n\tDG.Tweening.Plugins.Core.PathCore.CubicBezierDecoder::SetTimeToLengthTables(this, p, v621);\n\tDG.Tweening.Plugins.Core.PathCore.CubicBezierDecoder::SetWaypointsLengths(this, p, p.subdivisionsXSegment);\n\treturn;\n\tv265 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 349 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal override void FinalizePath(Path p, Vector3[] wps, bool isClosedPath)
		{
			//IL_0056: Expected O, but got I4
			//IL_011f: Expected O, but got I
			//IL_013b: Expected O, but got I
			//IL_034d: Expected O, but got I
			//IL_036f: Expected O, but got I4
			//IL_037e: Expected O, but got I
			//IL_038d: Expected O, but got I
			//IL_03a1: Expected O, but got I
			//IL_03b1: Expected O, but got I4
			//IL_03c0: Expected O, but got I
			//IL_03cf: Expected O, but got I
			//IL_01d2: Expected O, but got I
			//IL_01ee: Expected O, but got I
			//IL_066f: Expected O, but got I
			//IL_0261: Expected O, but got I
			//IL_027d: Expected O, but got I
			//IL_02ac: Expected O, but got I
			//IL_04ae: Expected I, but got O
			//IL_04ed: Expected O, but got I
			//IL_0507: Expected O, but got I4
			//IL_0567: Expected O, but got I
			//IL_0576: Expected O, but got I
			//IL_05ac: Expected O, but got F4
			bool flag3;
			if (isClosedPath)
			{
				bool flag = !p.addedExtraEndWp;
				bool flag2 = !flag;
				flag3 = flag2;
			}
			else
			{
				flag3 = false;
			}
			object obj = (p.addedExtraEndWp ? 1 : 0) + (p.addedExtraStartWp ? 1 : 0);
			int num = (int)((nint)obj + 3);
			if (num <= wps.Length)
			{
				int num2 = (int)(wps.Length - (nint)obj);
				int num3 = num2 * 1431655766;
				int num4 = num3 >> 63;
				int num5 = num3 >> 32;
				int num6 = num5 + num4;
				int num7 = num6 << 1;
				int num8 = num6 + num7;
				if (num2 == num8)
				{
					object obj2 = num6 + (nint)obj;
					Vector3[] array = new Vector3[obj2];
					object obj3 = (nint)obj2 - 1;
					ControlPoint[] controlPoints = new ControlPoint[obj3];
					p.controlPoints = controlPoints;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [wps @ X2 (UnityEngine.Vector3[])+20]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [wps @ X2 (UnityEngine.Vector3[])+28]");
					_ = 0;
					int num9 = (p.addedExtraStartWp ? 3 : 5);
					if (num9 < wps.Length)
					{
						int num10 = 1;
						do
						{
							int num11 = num9 - 2;
							int num12 = num11 * 12;
							object obj4 = (nint)wps + num12;
							int num13 = num10 * 12;
							object obj5 = (nint)array + num13;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v625 @ X12_v6+20]");
							_ = 0;
							array[num10].z = wps[num11].z;
							int num14 = num9 - 1;
							int num15 = num10 - 1;
							int num16 = num14 * 12;
							object obj6 = (nint)wps + num16;
							int num17 = num9 * 12;
							object obj7 = (nint)wps + num17;
							num9 += 3;
							int num18 = num15 * 24;
							object obj8 = (nint)p.controlPoints + num18;
							num10 = num15 + 2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v661 @ X13_v8+20]");
							_ = 0;
							_ = wps[num14].z;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v560 @ X13_v10+20]");
							_ = 0;
							_ = wps[num9].z;
						}
						while (num9 < wps.Length);
					}
					p.wps = array;
					if (flag3)
					{
						object obj9 = (nint)array + 32;
						ControlPoint[] controlPoints2 = p.controlPoints;
						object obj10 = array.Length - 2;
						object obj11 = (nint)obj10 * 12;
						object obj12 = (nint)obj9 + (nint)obj11;
						object obj13 = (nint)p.controlPoints + 32;
						object obj14 = controlPoints2.Length - 2;
						object obj15 = (nint)obj14 * 24;
						object obj16 = (nint)obj13 + (nint)obj15;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v447 @ X0_v7 (UnityEngine.Vector3[])+28]");
						Vector3 vector = (Vector3)0;
						ControlPoint[] controlPoints3 = p.controlPoints;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v447 @ X0_v7 (UnityEngine.Vector3[])+20]");
						float num19 = 0f - (float)obj12;
						float num20 = num19 * num19;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v447 @ X0_v7 (UnityEngine.Vector3[])+28]");
						float num21 = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v636 @ X9_v16+8]");
						float num22 = num21 - 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
						float num23 = num22 * num22;
						float num24 = num20;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v560 @ X13_v10+20]");
						float num25 = num24 + 0f;
						float f = num25 + num23;
						float num26 = (float)obj12;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ X9_v18+C]");
						float num27 = num26 - 0f;
						float num28 = Mathf.Sqrt(f);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v636 @ X9_v16+8]");
						float num29 = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ X9_v18+14]");
						float num30 = num29 - 0f;
						float num31 = num27 * num27;
						float num32 = num30 * num30;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FADDP not yet implemented.\"");
						float num33 = num32 + num31;
						float num34 = num28 * num28;
						object obj17 = default(object);
						if (num33 > num34)
						{
							nint num35 = (nint)typeof(Math);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v703 @ X0_v28 (Il2CppClass<System.Math>)+E0]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v447 @ X0_v7 (UnityEngine.Vector3[])+28]");
								vector = (Vector3)0;
							}
							float num36 = Mathf.Sqrt(num33);
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
							float num37 = num30 / num36;
							float num38 = num27 / num32;
							num27 = num38 * (float)obj17;
							num30 = num28 * num37;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v447 @ X0_v7 (UnityEngine.Vector3[])+20]");
						float num39 = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ X8_v20 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+20]");
						float num40 = num39 - 0f;
						float num41 = vector.x;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ X8_v20 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+28]");
						float num42 = num41 - 0f;
						float num43 = num40 * num40;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FADDP not yet implemented.\"");
						float num44 = num42 * num42;
						float num45 = num44 + num43;
						if (num45 > num34)
						{
							float num46 = Mathf.Sqrt(num45);
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
							float num47 = num42 / num46;
							float num48 = num40 / num44;
							num40 = num48 * (float)obj17;
							num42 = num28 * num47;
						}
						object obj18 = controlPoints3.Length - 1;
						float num49 = (float)obj12 + num27;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v636 @ X9_v16+8]");
						float z = 0f + num30;
						float z2 = vector.x + num42;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v447 @ X0_v7 (UnityEngine.Vector3[])+20]");
						float num50 = 0f + num40;
						object obj19 = (nint)obj18 * 24;
						object obj20 = (nint)controlPoints3 + (nint)obj19;
						controlPoints3[obj18].a.z = z;
						controlPoints3[obj18].b = (Vector3)num50;
						controlPoints3[obj18].b.z = z2;
					}
					SetTimeToLengthTables(p, p.subdivisions = (int)(p.subdivisionsXSegment * (nint)obj2));
					SetWaypointsLengths(p, p.subdivisionsXSegment);
					return;
				}
			}
			Debug.LogError("CubicBezier paths must contain waypoints in multiple of 3 excluding the starting point added automatically by DOTween (1: waypoint, 2: IN control point, 3: OUT control point — the minimum amount of waypoints for a single curve is 3)");
		}

		[Token(Token = "0x600038B")]
		[Address(RVA = "0xC29090", Offset = "0xC29090", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv24 = System.Math;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, wps, p, controlPoints, methodInfo, v28, v29, v30, perc, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A357A1]) = v41;\nL_001B:\n\tv47 = wps.Length - 1;\n\tgoto L_0025;\n\tv120 = \"il2cpp_codegen_runtime_class_init\"(v46, wps, p, controlPoints, methodInfo, v28, v29, v30, perc, v31, v32, v33, v34, v35, v36, v37);\n\tv121 = *([v16 @ X19_v1 (UnityEngine.Vector3[])+18]);\nL_0025:\n\tv59 = v47 * perc;\n\tv61 = UnityEngine.Mathf::Floor(v59);\n\tv135 = v61 != 0x7F800000;\n\tif (v135) goto L_FFFFFFFF;\n\tgoto L_0039;\nL_0039:\n\tv103 = wps.Length - 2;\n\tv217 = v103 - v107;\n\tv218 = v217 < 0;\n\tv219 = v217 == 0;\n\tv220 = v103 ^ v107;\n\tv221 = v103 ^ v217;\n\tv222 = v220 & v221;\n\tv223 = v222 < 0;\n\tv224 = v218 == v223;\n\tv53 = ~v219;\n\tv56 = v224 & v53;\n\tv68 = ~v56;\n\tif (v68) goto L_0064;\n\tgoto L_0064;\nL_0064:\n\tv229 = v103 + 1;\n\tv244 = v103 * 0x18;\n\tv209 = controlPoints + v244;\n\tv245 = v103 * 0xC;\n\tv196 = wps + v245;\n\tv201 = v229 * 0xC;\n\tv194 = wps + v201;\n\tv261 = *([v196 @ X9_v8 (System.Single)+20]) * v262;\n\tv164 = *([v209 @ X8_v9 (System.Single)+20]) * v263;\n\tv162 = controlPoints[v103 @ X10_v4 (System.Single)].b * v266;\n\tv267 = v261 + v164;\n\tv160 = *([v194 @ X10_v7 (System.Single)+20]) * v268;\n\tv270 = v162 + v267;\n\treturnVal2 = v160 + v270;\n\treturn returnVal2;\n\tv111 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 122 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal override Vector3 GetPoint(float perc, Vector3[] wps, Path p, ControlPoint[] controlPoints)
		{
			//IL_0015: Expected O, but got I4
			//IL_01d2: Expected O, but got F4
			//IL_01df: Expected O, but got F4
			//IL_00ca: Expected O, but got I
			//IL_00e0: Expected O, but got I
			//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Expected O, but got Unknown
			//IL_010b: Expected O, but got I
			//IL_0121: Expected O, but got I
			//IL_0130: Expected O, but got I
			//IL_013f: Expected O, but got I
			object obj = wps.Length - 1;
			float num = (float)obj * perc;
			float num2 = Mathf.Floor(num);
			float num3 = ((num2 != float.PositiveInfinity) ? num : -0f);
			float num4 = (float)wps.Length - 3E-45f;
			float num5 = num4 - num3;
			bool flag = num5 < 0f;
			bool flag2 = num5 == 0f;
			object obj2 = num4 ^ num3;
			object obj3 = num4 ^ num5;
			int num6 = (int)((nint)obj2 & (nint)obj3);
			bool flag3 = num6 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			if (flag4 && flag5)
			{
				num4 = num3;
			}
			float num7 = num4 + float.Epsilon;
			float num8 = num4 * 3.4E-44f;
			float num9 = (float)controlPoints + num8;
			float num10 = num4 * 1.7E-44f;
			float num11 = (float)wps + num10;
			float num12 = num7 * 1.7E-44f;
			float num13 = (float)wps + num12;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ X9_v8 (System.Single)+20]");
			object obj5 = default(object);
			object obj4 = 0 * (nint)obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ X8_v9 (System.Single)+20]");
			object obj7 = default(object);
			object obj6 = 0 * (nint)obj7;
			object obj9 = default(object);
			object obj8 = controlPoints[num4].b * (nint)obj9;
			object obj10 = (nint)obj4 + (nint)obj6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ X10_v7 (System.Single)+20]");
			object obj12 = default(object);
			object obj11 = 0 * (nint)obj12;
			object obj13 = (nint)obj8 + (nint)obj10;
			return (Vector3)((nint)obj11 + (nint)obj13);
		}

		[Token(Token = "0x600038C")]
		[Address(RVA = "0xC28B68", Offset = "0xC28B68", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv52 = System.Single[];\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, p, subdivisions, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv69 = 1;\n\t*([1A357A2]) = v69;\nL_0026:\n\t// 38 NewArr v72 @ X0_v3 (System.Single[]), typeof(System.Single[]), subdivisions @ X2 (System.Int32)\n\t// 43 NewArr v77 @ X0_v5 (System.Single[]), typeof(System.Single[]), subdivisions @ X2 (System.Int32)\n\tv89 = DG.Tweening.Plugins.Core.PathCore.CubicBezierDecoder::GetPoint(this, 0f, p.wps, p, p.controlPoints);\n\tv90 = subdivisions + 1;\n\tv101 = v90 < 2;\n\tif (v101) goto L_00A8;\n\tv204 = 1f / subdivisions;\nL_005A:\n\tv111 = v122 - 7;\n\tv103 = v204 * v111;\n\tv341 = DG.Tweening.Plugins.Core.PathCore.CubicBezierDecoder::GetPoint(this, v103, p.wps, p, p.controlPoints);\n\tgoto L_006F;\n\tv385 = v190;\n\tv386 = \"il2cpp_codegen_initialize_runtime_metadata\"(v385, v183, v171, v181, v175, v56, v57, v58, v173, v128, v113, v62, v63, v64, v65, v66);\n\t*([1A357E4]) = v118;\nL_006F:\n\tgoto L_0074;\n\tv391 = \"il2cpp_codegen_runtime_class_init\"(v388, v183, v171, v181, v175, v56, v57, v58, v173, v128, v113, v62, v63, v64, v65, v66);\nL_0074:\n\tv193 = v111 - 1;\n\t*([v72 @ X0_v3 (System.Single[])+v122 @ X25_v6 (System.Int32)*4]) = v103;\n\tv394 = v103 - v132;\n\tv395 = v204 - v130;\n\tv396 = v113 - v126;\n\tv397 = v394 * v394;\n\tv221 = v395 * v395;\n\tv113 = v396 * v396;\n\tv398 = v397 + v221;\n\tv399 = v113 + v398;\n\tv248 = UnityEngine.Mathf::Sqrt(v399);\n\tv258 = v193 + 2;\n\tv244 = v169 + v248;\n\t*([v77 @ X0_v5 (System.Single[])+v122 @ X25_v6 (System.Int32)*4]) = v244;\n\tv122 = v122 + 1;\n\tv227 = v258 != v90;\n\tif (v227) goto L_005A;\nL_00A8:\n\tp.length = v244;\n\tp.timesTable = v72;\n\tp.lengthsTable = v77;\n\treturn;\n\tv195 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 150 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void SetTimeToLengthTables(Path p, int subdivisions)
		{
			//IL_00e9: Expected O, but got I
			//IL_0116: Expected O, but got I
			float[] timesTable = new float[subdivisions];
			float[] lengthsTable = new float[subdivisions];
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
				float num6 = default(float);
				float num5 = num6;
				float num7 = 0f;
				float num8 = 0f;
				bool flag2;
				do
				{
					int num9 = num4 - 7;
					float num10 = num3 * (float)num9;
					Vector3 point2 = GetPoint(num10, p.wps, p, p.controlPoints);
					int num11 = num9 - 1;
					float num12 = num10 - num7;
					float num13 = num3 - num5;
					object obj3 = (nint)obj2 - (nint)obj;
					float num14 = num12 * num12;
					float num15 = num13 * num13;
					obj2 = (nint)obj3 * (nint)obj3;
					float num16 = num14 + num15;
					float f = (float)obj2 + num16;
					float num17 = Mathf.Sqrt(f);
					int num18 = num11 + 2;
					num2 = num8 + num17;
					num4++;
					flag2 = num18 != num;
					obj = obj2;
					num5 = num3;
					num7 = num10;
					num8 = num2;
				}
				while (flag2);
			}
			p.length = num2;
			p.timesTable = timesTable;
			p.lengthsTable = lengthsTable;
		}

		[Token(Token = "0x600038D")]
		[Address(RVA = "0xC28D60", Offset = "0xC28D60", Length = "0x330")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv52 = DG.Tweening.Plugins.Core.PathCore.CubicBezierDecoder;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, p, subdivisions, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv73 = System.Single[];\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v73, p, subdivisions, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv70 = 1;\n\t*([1A357A3]) = v70;\nL_0028:\n\tv74 = p.wps;\n\t// 48 NewArr v268 @ X0_v5 (System.Single[]), typeof(System.Single[]), v74.Length\n\tv268[0] = 0;\n\tv401 = v74.Length < 2;\n\tif (v401) goto L_0136;\n\tv448 = v74.Length & 0xFFFFFFFF;\n\tv449 = subdivisions + 1;\n\tv159 = 1f / subdivisions;\nL_0057:\n\tgoto L_005E;\n\tv490 = \"il2cpp_codegen_runtime_class_init\"(v487, v253, v115, v109, v106, v56, v57, v58, v178, v171, v91, v62, v63, v64, v65, v66);\n\tv491 = DG.Tweening.Plugins.Core.PathCore.CubicBezierDecoder;\nL_005E:\n\tv281 = v156 - 1;\n\tv494 = v281 * 0x18;\n\tv144 = p.controlPoints + v494;\n\tv262 = v150._PartialControlPs;\n\t*([v262 @ X9_v8 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+30]) = *([v144 @ X11_v6+30]);\n\t*([v262 @ X9_v8 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+20]) = *([v144 @ X11_v6+20]);\n\tv152 = v498._PartialWps;\n\tv499 = v281 * 0xC;\n\tv500 = p.wps + v499;\n\t*([v152 @ X10_v13 (UnityEngine.Vector3[])+20]) = *([v500 @ X8_v13+20]);\n\t*([v152 @ X10_v13 (UnityEngine.Vector3[])+28]) = *([v500 @ X8_v13+28]);\n\tv264 = v503._PartialWps;\n\tv506 = v156 * 0xC;\n\tv507 = p.wps + v506;\n\tv589 = *([v507 @ X8_v15+28]);\n\t*([v264 @ X9_v13 (UnityEngine.Vector3[])+2C]) = *([v507 @ X8_v15+20]);\n\t*([v264 @ X9_v13 (UnityEngine.Vector3[])+34]) = *([v507 @ X8_v15+28]);\n\tv521 = DG.Tweening.Plugins.Core.PathCore.CubicBezierDecoder::GetPoint(this, 0f, v516._PartialWps, p, v516._PartialControlPs);\n\tv533 = v449 < 2;\n\tif (v533) goto L_0129;\nL_00E3:\n\tgoto L_00EE;\n\tv610 = \"il2cpp_codegen_runtime_class_init\"(v605, v600, v588, v586, v585, v56, v57, v58, v590, v589, v580, v62, v63, v64, v65, v66);\n\tv612 = DG.Tweening.Plugins.Core.PathCore.CubicBezierDecoder;\nL_00EE:\n\tv571 = v581 + 1;\n\tv618 = v159 * v571;\n\tv619 = DG.Tweening.Plugins.Core.PathCore.CubicBezierDecoder::GetPoint(this, v618, v613._PartialWps, p, v613._PartialControlPs);\n\tgoto L_0100;\n\tv623 = v257;\n\tv624 = \"il2cpp_codegen_initialize_runtime_metadata\"(v623, v570, v550, v548, v547, v56, v57, v58, v618, v589, v580, v62, v63, v64, v65, v66);\n\t*([1A357E4]) = v168;\nL_0100:\n\tgoto L_0102;\n\tv628 = \"il2cpp_codegen_runtime_class_init\"(v626, v570, v550, v548, v547, v56, v57, v58, v618, v589, v580, v62, v63, v64, v65, v66);\nL_0102:\n\tv629 = v618 - v584;\n\tv630 = v589 - v583;\n\tv631 = v580 - v582;\n\tv632 = v629 * v629;\n\tv551 = v630 * v630;\n\tv405 = v631 * v631;\n\tv633 = v632 + v551;\n\tv634 = v405 + v633;\n\tv581 = v581 + 1;\n\tv552 = UnityEngine.Mathf::Sqrt(v634);\n\tv412 = v587 + v552;\n\tv553 = subdivisions != v581;\n\tif (v553) goto L_00E3;\nL_0129:\n\tv465 = v156 + 1;\n\tv268[v156 @ X24_v6 (System.Int32)] = v412;\n\tv471 = v465 != v448;\n\tif (v471) goto L_0057;\nL_0136:\n\tp.wpLengths = v268;\n\treturn;\n\tv267 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 264 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void SetWaypointsLengths(Path p, int subdivisions)
		{
			//IL_0071: Expected I4, but got I8
			//IL_00d2: Expected O, but got I
			//IL_012e: Expected O, but got I
			//IL_017c: Expected O, but got I
			//IL_018c: Expected O, but got I
			//IL_0212: Expected O, but got I
			//IL_0247: Expected O, but got I
			//IL_0256: Expected O, but got I
			//IL_0274: Expected O, but got I
			//IL_0283: Expected O, but got I
			Vector3[] wps = p.wps;
			float[] array = new float[wps.Length];
			array[0] = 0f;
			if (wps.Length >= 2)
			{
				int num = (int)(wps.Length & 0xFFFFFFFFL);
				int num2 = subdivisions + 1;
				float num3 = 1f / (float)subdivisions;
				int num4 = 1;
				object obj6 = default(object);
				bool flag3;
				do
				{
					int num5 = num4 - 1;
					int num6 = num5 * 24;
					object obj = (nint)p.controlPoints + num6;
					ControlPoint[] partialControlPs = _PartialControlPs;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ X11_v6+30]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ X11_v6+20]");
					_ = 0;
					Vector3[] partialWps = _PartialWps;
					int num7 = num5 * 12;
					object obj2 = (nint)p.wps + num7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v500 @ X8_v13+20]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v500 @ X8_v13+28]");
					_ = 0;
					Vector3[] partialWps2 = _PartialWps;
					int num8 = num4 * 12;
					object obj3 = (nint)p.wps + num8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v507 @ X8_v15+28]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v507 @ X8_v15+20]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v507 @ X8_v15+28]");
					_ = 0;
					Vector3 point = GetPoint(0f, _PartialWps, p, _PartialControlPs);
					bool flag = num2 < 2;
					float num9 = 0f;
					if (!flag)
					{
						object obj5 = obj6;
						int num10 = 0;
						object obj7 = obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v507 @ X8_v15+28]");
						object obj8 = 0;
						float num11 = 0f;
						float num12 = 0f;
						bool flag2;
						do
						{
							int num13 = num10 + 1;
							float num14 = num3 * (float)num13;
							Vector3 point2 = GetPoint(num14, _PartialWps, p, _PartialControlPs);
							float num15 = num14 - num11;
							object obj9 = (nint)obj4 - (nint)obj8;
							object obj10 = (nint)obj5 - (nint)obj7;
							float num16 = num15 * num15;
							object obj11 = (nint)obj9 * (nint)obj9;
							obj6 = (nint)obj10 * (nint)obj10;
							float num17 = num16 + (float)obj11;
							float f = (float)obj6 + num17;
							num10++;
							float num18 = Mathf.Sqrt(f);
							num9 = num12 + num18;
							flag2 = subdivisions != num10;
							obj5 = obj6;
							obj7 = obj6;
							obj8 = obj4;
							num11 = num14;
							num12 = num9;
							obj4 = obj11;
						}
						while (flag2);
					}
					int num19 = num4 + 1;
					array[num4] = num9;
					flag3 = num19 != num;
					num4 = num19;
				}
				while (flag3);
			}
			p.wpLengths = array;
		}

		[Token(Token = "0x600038E")]
		[Address(RVA = "0xC29218", Offset = "0xC29218", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CubicBezierDecoder()
		{
		}

		[Token(Token = "0x600038F")]
		[Address(RVA = "0xC29228", Offset = "0xC29228", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv22 = DG.Tweening.Plugins.Core.PathCore.ControlPoint[];\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv48 = DG.Tweening.Plugins.Core.PathCore.CubicBezierDecoder;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv56 = UnityEngine.Vector3[];\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv43 = 1;\n\t*([1A357A4]) = v43;\nL_001F:\n\t// 31 NewArr v46 @ X0_v3 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[]), typeof(DG.Tweening.Plugins.Core.PathCore.ControlPoint[]), 1\n\tv52._PartialControlPs = v46;\n\t// 37 NewArr v54 @ X0_v5 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), 2\n\tv62._PartialWps = v54;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static CubicBezierDecoder()
		{
			ControlPoint[] partialControlPs = new ControlPoint[1];
			_PartialControlPs = partialControlPs;
			Vector3[] partialWps = new Vector3[2];
			_PartialWps = partialWps;
		}
	}
}
