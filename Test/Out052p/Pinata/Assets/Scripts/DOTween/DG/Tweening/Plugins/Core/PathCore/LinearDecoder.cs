using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening.Plugins.Core.PathCore
{
	[Token(Token = "0x2000045")]
	internal class LinearDecoder : ABSPathDecoder
	{
		[Token(Token = "0x6000252")]
		[Address(RVA = "0x1081EE0", Offset = "0x1081EE0", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tp.controlPoints = 0;\n\tv28 = p.subdivisionsXSegment * wps.Length;\n\tp.subdivisions = v28;\n\tDG.Tweening.Plugins.Core.PathCore.LinearDecoder::SetTimeToLengthTables(this, p, wps);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal override void FinalizePath(Path p, Vector3[] wps, bool isClosedPath)
		{
			//IL_003e: Expected I4, but got O
			p.controlPoints = null;
			int subdivisions = p.subdivisionsXSegment * wps.Length;
			p.subdivisions = subdivisions;
			SetTimeToLengthTables(p, (int)wps);
		}

		[Token(Token = "0x6000253")]
		[Address(RVA = "0x1082120", Offset = "0x1082120", Length = "0x1F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv38 = *([1EAD0E0]);\n\tv39 = *([v38 @ X8_v16]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, wps, p, controlPoints, methodInfo, v43, v44, v45, perc, v46, v47, v48, v49, v50, v51, v52);\n\tv56 = 0 | 1;\n\t*([2026A50]) = v56;\nL_001F:\n\tv58 = perc < 0;\n\tv59 = ~v58;\n\tv62 = perc == 0;\n\tv67 = ~v59;\n\tv68 = v67 | v62;\n\tif (v68) goto L_0068;\n\tv145 = p.timesTable;\n\tv159 = v145.Length < 2;\n\tif (v159) goto L_FFFFFFFF;\n\tv265 = v145.Length & 0xFFFFFFFF;\n\tv268 = v145 + 0x24;\nL_003F:\n\tv298 = v91 + 1;\n\tv329 = v298 < v265;\n\tv317 = ~v329;\n\tif (v317) goto L_00EE;\n\tv331 = *([v268 @ X13_v5+v91 @ X11_v3 (System.Int32)*4]) >= perc;\n\tif (v331) goto L_007F;\n\tv270 = v91 + 2;\n\tv91 = v91 + 1;\n\tv279 = v270 < v265;\n\tif (v279) goto L_003F;\n\tgoto L_0080;\nL_0068:\n\tp.linearWPIndex = 1;\n\tv161 = wps.Length == 0;\n\tif (v161) goto L_00EE;\n\treturn *([wps @ X1 (UnityEngine.Vector3[])+20]);\nL_007F:\n\tv95 = v91 + 1;\nL_0080:\n\tv348 = v91 < v145.Length;\n\tv134 = ~v348;\n\tif (v134) goto L_00EE;\n\tv352 = v91 < wps.Length;\n\tv318 = ~v352;\n\tif (v318) goto L_00EE;\n\tv353 = v95 < wps.Length;\n\tv243 = ~v353;\n\tif (v243) goto L_00EE;\n\tv356 = v95 * 0xC;\n\tv223 = wps + v356;\n\tv358 = v91 * 0xC;\n\tv221 = wps + v358;\n\tp.linearWPIndex = v95;\n\tv370 = perc - v145[v91 @ X11_v3 (System.Int32)];\n\tv372 = p.length * v370;\n\tgoto L_00C9;\n\tv376 = *([v371 @ X0_v7+E0]);\n\tv377 = v376 == 0;\n\tv378 = ~v377;\n\tif (v378) goto L_00C9;\n\tv380 = \"il2cpp_codegen_runtime_class_init\"(v371, wps, p, controlPoints, methodInfo, v43, v44, v45, v370, v369, v47, v48, v49, v50, v51, v52);\nL_00C9:\n\t// 201 MakeStruct v178 @ AGG10822B0_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v223 @ X11_v5+20], wps[v95 @ X9_v3 (System.Int32)].y (System.Single), wps[v95 @ X9_v3 (System.Int32)].z (System.Single)\n\t// 202 MakeStruct v175 @ AGG10822B0_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v221 @ X12_v7+20], wps[v91 @ X11_v3 (System.Int32)].y (System.Single), wps[v91 @ X11_v3 (System.Int32)].z (System.Single)\n\tv388 = UnityEngine.Vector3::op_Subtraction(v178, v175);\n\tv393 = UnityEngine.Vector3::ClampMagnitude(v388, v372);\n\t// 232 MakeStruct v169 @ AGG10822F8_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v221 @ X12_v7+20], wps[v91 @ X11_v3 (System.Int32)].y (System.Single), wps[v91 @ X11_v3 (System.Int32)].z (System.Single)\n\treturnVal3 = UnityEngine.Vector3::op_Addition(v169, v393);\n\treturn returnVal3;\nL_00EE:\n\tv319 = new System.IndexOutOfRangeException();\n\tthrow v319;\n\tthrow System.NullReferenceException;\n// 180 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal override Vector3 GetPoint(float perc, Vector3[] wps, Path p, ControlPoint[] controlPoints)
		{
			//IL_0171: Expected O, but got I
			//IL_009d: Expected I4, but got I8
			//IL_00ac: Expected O, but got I
			//IL_01f2: Expected O, but got I
			//IL_020e: Expected O, but got I
			//IL_0261: Expected F4, but got I
			//IL_02ac: Expected F4, but got I
			//IL_031e: Expected F4, but got I
			bool flag = perc < 0f;
			bool flag2 = !flag;
			bool flag3 = perc == 0f;
			bool flag4 = !flag2;
			float[] timesTable;
			int num2;
			if (!(flag4 || flag3))
			{
				timesTable = p.timesTable;
				if (timesTable.Length < 2)
				{
					goto IL_011b;
				}
				int num = (int)(timesTable.Length & 0xFFFFFFFFL);
				object obj = (long)(IntPtr)timesTable + 36L;
				num2 = 0;
				while (true)
				{
					int num3 = num2 + 1;
					if (num3 >= num)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ X13_v5+v91 @ X11_v3 (System.Int32)*4]");
					if (0f < perc)
					{
						int num4 = num2 + 2;
						num2++;
						if (num4 < num)
						{
							continue;
						}
						goto IL_011b;
					}
					goto IL_0171;
				}
			}
			else
			{
				p.linearWPIndex = 1;
				if (wps.Length != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [wps @ X1 (UnityEngine.Vector3[])+20]");
					return (Vector3)0;
				}
			}
			goto IL_036a;
			IL_011b:
			num2 = 0;
			int num5 = 0;
			goto IL_03ad;
			IL_03ad:
			if (num2 < timesTable.Length && num2 < wps.Length && num5 < wps.Length)
			{
				int num6 = num5 * 12;
				object obj2 = (long)(IntPtr)wps + (long)num6;
				int num7 = num2 * 12;
				object obj3 = (long)(IntPtr)wps + (long)num7;
				p.linearWPIndex = num5;
				float num8 = perc - timesTable[num2];
				float maxLength = p.length * num8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ X11_v5+20]");
				Vector3 vector = default(Vector3);
				vector.x = 0f;
				vector.y = wps[num5].y;
				vector.z = wps[num5].z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ X12_v7+20]");
				Vector3 vector2 = default(Vector3);
				vector2.x = 0f;
				vector2.y = wps[num2].y;
				vector2.z = wps[num2].z;
				Vector3 vector3 = vector - vector2;
				Vector3 vector4 = Vector3.ClampMagnitude(vector3, maxLength);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ X12_v7+20]");
				Vector3 vector5 = default(Vector3);
				vector5.x = 0f;
				vector5.y = wps[num2].y;
				vector5.z = wps[num2].z;
				return vector5 + vector4;
			}
			goto IL_036a;
			IL_036a:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_0171:
			num5 = num2 + 1;
			goto IL_03ad;
		}

		[Token(Token = "0x6000254")]
		[Address(RVA = "0x1081F14", Offset = "0x1081F14", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv46 = *([1EDF248]);\n\tv47 = *([v46 @ X8_v21]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, p, subdivisions, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv66 = 0 | 1;\n\t*([2026A51]) = v66;\nL_0023:\n\tv68 = p.wps;\n\t// 43 NewArr v165 @ X0_v15 (System.Single[]), typeof(System.Single[]), v68.Length\n\tv405 = p.wps;\n\tv233 = v405.Length == 0;\n\tif (v233) goto L_00EB;\n\tv263 = v68.Length <= 0;\n\tif (v263) goto L_00D2;\n\tv115 = *([v405 @ X8_v13 (UnityEngine.Vector3[])+20]);\n\tv112 = *([v405 @ X8_v13 (UnityEngine.Vector3[])+24]);\n\tv109 = *([v405 @ X8_v13 (UnityEngine.Vector3[])+28]);\nL_004B:\n\tv521 = v103 < v405.Length;\n\tv153 = ~v521;\n\tif (v153) goto L_00EB;\n\tv525 = v405 + v106;\n\tgoto L_006A;\n\tv531 = *([v524 @ X0_v19+E0]);\n\tv532 = v531 == 0;\n\tv533 = ~v532;\n\tif (v533) goto L_006A;\n\tv535 = \"il2cpp_codegen_runtime_class_init\"(v524, v158, subdivisions, methodInfo, v51, v52, v53, v54, v342, v339, v337, v335, v333, v331, v61, v62);\nL_006A:\n\t// 106 MakeStruct v74 @ AGG1082018_0_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v525 @ X8_v14+20], [v525 @ X8_v14+24], [v525 @ X8_v14+28]\n\t// 107 MakeStruct v71 @ AGG1082018_1_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v115 @ V8_v8 (UnityEngine.Vector3), v112 @ V9_v8 (UnityEngine.Vector3), v109 @ V10_v8 (UnityEngine.Vector3)\n\tv86 = UnityEngine.Vector3::Distance(v74, v71);\n\tv538 = v103 < v165.Length;\n\tv390 = ~v538;\n\tif (v390) goto L_00EB;\n\tv165[v103 @ X25_v8 (System.Int32)] = v86;\n\tv103 = v103 + 1;\n\tv252 = v96 + v86;\n\tv119 = v103 >= v68.Length;\n\tif (v119) goto L_0094;\n\tv405 = p.wps;\n\tv106 = v106 + 0xC;\n\tv540 = p.wps == 0;\n\tv167 = ~v540;\n\tif (v167) goto L_004B;\n\tthrow System.NullReferenceException;\nL_0094:\n\tv295 = \"SzArrayNew\"(*([v212 @ X23_v5 (Il2CppClass<System.Single[]>)]), v68.Length, subdivisions, methodInfo, v51, v52, v53, v54, v86, *([v525 @ X8_v14+24]), *([v525 @ X8_v14+28]), v115, v112, v109, v61, v62);\n\tv231 = v68.Length < 2;\n\tif (v231) goto L_00D4;\nL_00A4:\n\tv395 = v406 - 8;\n\tv419 = v395 < v301.Length;\n\tv391 = ~v419;\n\tif (v391) goto L_00EB;\n\tv523 = v395 < v295.Length;\n\tv392 = ~v523;\n\tif (v392) goto L_00EB;\n\tv290 = v406 - 7;\n\tv238 = v406 + 1;\n\tv343 = v343 + *([v301 @ X20_v2 (System.Single[])+v406 @ X8_v8 (System.Int32)*4]);\n\tv246 = v343 / v252;\n\t*([v295 @ X0_v2 (System.Single[])+v406 @ X8_v8 (System.Int32)*4]) = v246;\n\tv264 = v290 < v193;\n\tif (v264) goto L_00A4;\n\tgoto L_00D4;\nL_00D2:\n\t// 210 NewArr v295 @ X0_v2 (System.Single[]), typeof(System.Single[]), v68.Length\nL_00D4:\n\tp.length = v252;\n\tp.wpLengths = v301;\n\tp.timesTable = v295;\n\treturn;\nL_00EB:\n\tv408 = new System.IndexOutOfRangeException();\n\tthrow v408;\n\tthrow System.NullReferenceException;\n// 172 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void SetTimeToLengthTables(Path p, int subdivisions)
		{
			//IL_0089: Expected O, but got I
			//IL_0099: Expected O, but got I
			//IL_00a9: Expected O, but got I
			//IL_00d7: Expected O, but got I
			//IL_00f1: Expected F4, but got I
			//IL_0106: Expected F4, but got I
			//IL_011b: Expected F4, but got I
			//IL_01e9: Expected I, but got O
			//IL_0251: Expected I, but got O
			//IL_0271: Expected O, but got I
			//IL_0281: Expected O, but got I
			//IL_0291: Expected O, but got I
			Vector3[] wps = p.wps;
			float[] array = new float[wps.Length];
			Vector3[] wps2 = p.wps;
			float[] array2 = default(float[]);
			float num;
			int num6;
			float[] array3;
			if (wps2.Length != 0)
			{
				if (wps.Length <= 0)
				{
					array2 = new float[wps.Length];
					num = 0f;
					array3 = array;
					goto IL_03da;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ X8_v13 (UnityEngine.Vector3[])+20]");
				Vector3 vector = (Vector3)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ X8_v13 (UnityEngine.Vector3[])+24]");
				Vector3 vector2 = (Vector3)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ X8_v13 (UnityEngine.Vector3[])+28]");
				Vector3 vector3 = (Vector3)0;
				float num2 = 0f;
				int num3 = 0;
				int num4 = 0;
				Vector3 a = default(Vector3);
				Vector3 b = default(Vector3);
				while (num3 < wps2.Length)
				{
					object obj = (long)(IntPtr)wps2 + (long)num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ X8_v14+20]");
					a.x = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ X8_v14+24]");
					a.y = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ X8_v14+28]");
					a.z = 0f;
					b.x = vector.x;
					b.y = vector2.x;
					b.z = vector3.x;
					float num5 = Vector3.Distance(a, b);
					if (num3 >= array.Length)
					{
						break;
					}
					array[num3] = num5;
					num3++;
					num = num2 + num5;
					bool flag = num3 >= wps.Length;
					num6 = wps.Length;
					IntPtr intPtr = (IntPtr)typeof(float[]);
					array3 = array;
					if (!flag)
					{
						wps2 = p.wps;
						num4 += 12;
						bool flag2 = p.wps == null;
						bool flag3 = !flag2;
						num6 = wps.Length;
						intPtr = (IntPtr)typeof(float[]);
						array3 = array;
						num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ X8_v14+28]");
						vector3 = (Vector3)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ X8_v14+24]");
						vector2 = (Vector3)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ X8_v14+20]");
						vector = (Vector3)0;
						if (!flag3)
						{
							throw new NullReferenceException();
						}
						continue;
					}
					goto IL_02a5;
				}
			}
			goto IL_03a3;
			IL_02a5:
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"SzArrayNew\"");
			if (wps.Length >= 2)
			{
				float num7 = 0f;
				int num8 = 9;
				while (true)
				{
					int num9 = num8 - 8;
					if (num9 >= array3.Length || num9 >= array2.Length)
					{
						break;
					}
					int num10 = num8 - 7;
					int num11 = num8 + 1;
					float num12 = num7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ X20_v2 (System.Single[])+v406 @ X8_v8 (System.Int32)*4]");
					num7 = num12 + 0f;
					float num13 = num7 / num;
					bool flag4 = num10 < num6;
					num8 = num11;
					if (flag4)
					{
						continue;
					}
					goto IL_03da;
				}
				goto IL_03a3;
			}
			goto IL_03da;
			IL_03a3:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_03da:
			p.length = num;
			p.wpLengths = array3;
			p.timesTable = array2;
		}

		[Token(Token = "0x6000255")]
		[Address(RVA = "0x1082314", Offset = "0x1082314", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		internal void SetWaypointsLengths(Path p, int subdivisions)
		{
		}

		[Token(Token = "0x6000256")]
		[Address(RVA = "0x1082318", Offset = "0x1082318", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LinearDecoder()
		{
		}
	}
}
