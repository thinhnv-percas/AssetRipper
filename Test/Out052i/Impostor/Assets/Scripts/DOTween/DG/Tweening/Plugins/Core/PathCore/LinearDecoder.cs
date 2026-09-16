using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening.Plugins.Core.PathCore
{
	[Token(Token = "0x200009D")]
	internal class LinearDecoder : ABSPathDecoder
	{
		[Token(Token = "0x1700000D")]
		internal override int minInputWaypoints
		{
			[Token(Token = "0x600039E")]
			[Address(RVA = "0xC29F60", Offset = "0xC29F60", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return 1;
			}
		}

		[Token(Token = "0x600039F")]
		[Address(RVA = "0xC29F68", Offset = "0xC29F68", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tp.controlPoints = 0;\n\tv24 = p.subdivisionsXSegment * wps.Length;\n\tp.subdivisions = v24;\n\tDG.Tweening.Plugins.Core.PathCore.LinearDecoder::SetTimeToLengthTables(this, p, wps);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal override void FinalizePath(Path p, Vector3[] wps, bool isClosedPath)
		{
			//IL_003e: Expected I4, but got O
			p.controlPoints = null;
			int subdivisions = p.subdivisionsXSegment * wps.Length;
			p.subdivisions = subdivisions;
			SetTimeToLengthTables(p, (int)wps);
		}

		[Token(Token = "0x60003A0")]
		[Address(RVA = "0xC2A1A0", Offset = "0xC2A1A0", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = perc < 0;\n\tv18 = ~v16;\n\tv21 = perc == 0;\n\tv26 = ~v18;\n\tv27 = v26 | v21;\n\tif (v27) goto L_0049;\n\tv51 = p.timesTable;\n\tv147 = v51.Length < 2;\n\tif (v147) goto L_FFFFFFFF;\n\tv148 = v51.Length & 0xFFFFFFFF;\n\tv151 = v51 + 0x24;\n\tv152 = v148 - 1;\nL_0036:\n\tv272 = *([v151 @ X12_v9+v253 @ X10_v8 (System.Int32)*4]) >= perc;\n\tif (v272) goto L_0052;\n\tv253 = v253 + 1;\n\tv252 = v252 + 0x100000000;\n\tv164 = v152 != v253;\n\tif (v164) goto L_0036;\n\tgoto L_0077;\nL_0049:\n\tp.linearWPIndex = 1;\n\treturnVal2 = *([wps @ X1 (UnityEngine.Vector3[])+20]);\n\tgoto L_00C2;\nL_0052:\n\tv42 = v253 + 1;\n\tv39 = v252 >> 0x20;\nL_0077:\n\tv324 = v42 * 0xC;\n\tv306 = wps + v324;\n\tv327 = v39 * 0xC;\n\tv305 = wps + v327;\n\tp.linearWPIndex = v42;\n\tv331 = perc - v51[v39 @ X11_v4 (System.Int32)];\n\tv343 = p.length * v331;\n\tv291 = *([v306 @ X9_v7+20]) - *([v305 @ X12_v7+20]);\n\tv334 = wps[v42 @ X10_v4 (System.Int32)].z - wps[v39 @ X11_v4 (System.Int32)].z;\n\tgoto L_0095;\n\tv338 = System.Math;\n\tv339 = v332;\n\tv340 = \"il2cpp_codegen_initialize_runtime_metadata\"(v338, wps, p, controlPoints, methodInfo, v89, v90, v91, v331, v329, v332, v293, v292, v95, v96, v97);\n\tv344 = v339;\n\tv346 = 1;\n\t*([1A3575A]) = v346;\nL_0095:\n\tv347 = v291 * v291;\n\tv348 = v334 * v334;\n\t// 151 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv285 = v348 + v347;\n\tv349 = v343 * v343;\n\tv308 = v285 <= v349;\n\tif (v308) goto L_00B7;\n\tgoto L_00B1;\n\tv369 = \"il2cpp_codegen_runtime_class_init\"(v355, wps, p, controlPoints, methodInfo, v89, v90, v91, v349, v348, v343, v293, v292, v95, v96, v97);\nL_00B1:\n\tv371 = UnityEngine.Mathf::Sqrt(v285);\n\t// 178 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv363 = v291 / v348;\n\tv291 = v363 * v372;\nL_00B7:\n\treturnVal2 = *([v305 @ X12_v7+20]) + v291;\nL_00C2:\n\treturn returnVal2;\n\tv84 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn perc;\n// 140 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal override Vector3 GetPoint(float perc, Vector3[] wps, Path p, ControlPoint[] controlPoints)
		{
			//IL_0145: Expected O, but got I
			//IL_0187: Expected O, but got I
			//IL_01a3: Expected O, but got I
			//IL_01f9: Expected O, but got I
			//IL_0222: Expected O, but got F4
			//IL_0098: Expected I4, but got I8
			//IL_00a7: Expected O, but got I
			//IL_0269: Expected O, but got I
			//IL_0278: Expected O, but got I
			//IL_0311: Expected O, but got I
			//IL_00ec: Expected I4, but got I8
			//IL_02e7: Expected O, but got I
			//IL_02f6: Expected O, but got I
			bool flag = perc < 0f;
			bool flag2 = !flag;
			bool flag3 = perc == 0f;
			bool flag4 = !flag2;
			float[] timesTable;
			int num5;
			int num6;
			if (!(flag4 || flag3))
			{
				timesTable = p.timesTable;
				if (timesTable.Length < 2)
				{
					goto IL_010b;
				}
				int num = (int)(timesTable.Length & 0xFFFFFFFFL);
				object obj = (nint)timesTable + 36;
				int num2 = num - 1;
				int num3 = 0;
				int num4 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ X12_v9+v253 @ X10_v8 (System.Int32)*4]");
					if (!(0f < perc))
					{
						break;
					}
					num4++;
					num3 = (int)(num3 + 4294967296L);
					if (num2 != num4)
					{
						continue;
					}
					goto IL_010b;
				}
				num5 = num4 + 1;
				num6 = num3 >> 32;
				goto IL_016b;
			}
			p.linearWPIndex = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [wps @ X1 (UnityEngine.Vector3[])+20]");
			return (Vector3)0;
			IL_016b:
			int num7 = num5 * 12;
			object obj2 = (nint)wps + num7;
			int num8 = num6 * 12;
			object obj3 = (nint)wps + num8;
			p.linearWPIndex = num5;
			float num9 = perc - timesTable[num6];
			float num10 = p.length * num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ X9_v7+20]");
			nint num11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ X12_v7+20]");
			object obj4 = num11 - 0;
			object obj5 = wps[num5].z - wps[num6].z;
			object obj6 = (nint)obj4 * (nint)obj4;
			object obj7 = (nint)obj5 * (nint)obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FADDP not yet implemented.\"");
			float num12 = (float)obj7 + (float)obj6;
			float num13 = num10 * num10;
			if (num12 > num13)
			{
				float num14 = Mathf.Sqrt(num12);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
				object obj8 = (nint)obj4 / (nint)obj7;
				object obj9 = default(object);
				obj4 = (nint)obj8 * (nint)obj9;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ X12_v7+20]");
			return (Vector3)(0 + (nint)obj4);
			IL_010b:
			num6 = 0;
			num5 = 0;
			goto IL_016b;
		}

		[Token(Token = "0x60003A1")]
		[Address(RVA = "0xC29F94", Offset = "0xC29F94", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv46 = System.Single[];\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, p, subdivisions, methodInfo, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv65 = 1;\n\t*([1A357AB]) = v65;\nL_0022:\n\tv67 = p.wps;\n\t// 42 NewArr v200 @ X0_v11 (System.Single[]), typeof(System.Single[]), v67.Length\n\tv401 = p.wps;\n\tv142 = v67.Length <= 0;\n\tif (v142) goto L_00D4;\n\tv136 = *([v401 @ X8_v12 (UnityEngine.Vector3[])+20]);\n\tv132 = *([v401 @ X8_v12 (UnityEngine.Vector3[])+24]);\n\tv128 = *([v401 @ X8_v12 (UnityEngine.Vector3[])+28]);\n\tv458 = v67.Length & 0xFFFFFFFF;\n\tv108 = v458 - 1;\nL_0057:\n\tv474 = v401 + v124;\n\tgoto L_0066;\n\tv479 = v139;\n\tv480 = \"il2cpp_codegen_initialize_runtime_metadata\"(v479, v190, subdivisions, methodInfo, v50, v51, v52, v53, v91, v87, v83, v57, v58, v59, v60, v61);\n\t*([1A357E4]) = v103;\nL_0066:\n\tgoto L_0075;\n\tv485 = \"il2cpp_codegen_runtime_class_init\"(v482, v190, subdivisions, methodInfo, v50, v51, v52, v53, v91, v87, v83, v57, v58, v59, v60, v61);\nL_0075:\n\tv487 = *([v474 @ X8_v13+20]) - v136;\n\tv488 = *([v474 @ X8_v13+24]) - v132;\n\tv489 = *([v474 @ X8_v13+28]) - v128;\n\tv490 = v487 * v487;\n\tv85 = v488 * v488;\n\tv81 = v489 * v489;\n\tv491 = v490 + v85;\n\tv492 = v81 + v491;\n\tv89 = UnityEngine.Mathf::Sqrt(v492);\n\tv166 = v108 == v120;\n\tv273 = v113 + v89;\n\tv200[v120 @ X26_v7 (System.Int32)] = v89;\n\tif (v166) goto L_0096;\n\tv401 = p.wps;\n\tv120 = v120 + 1;\n\tv124 = v124 + 0xC;\n\tv494 = p.wps == 0;\n\tv203 = ~v494;\n\tif (v203) goto L_0057;\n\tthrow System.NullReferenceException;\nL_0096:\n\tv313 = \"SzArrayNew\"(*([v197 @ X24_v4 (Il2CppClass<System.Single[]>)]), v67.Length, subdivisions, methodInfo, v50, v51, v52, v53, v89, v85, v81, v57, v58, v59, v60, v61);\n\tv250 = v67.Length < 2;\n\tif (v250) goto L_00D6;\n\tv80 = v200 + 0x24;\nL_00C0:\n\tv258 = v211 << 2;\n\tv256 = v313 + v258;\n\tv211 = v211 + 1;\n\tv92 = v92 + *([v80 @ X10_v4+v211 @ X8_v7 (System.Int32)*4]);\n\tv264 = v92 / v273;\n\t*([v256 @ X11_v6+24]) = v264;\n\tv283 = v108 != v211;\n\tif (v283) goto L_00C0;\n\tgoto L_00D6;\nL_00D4:\n\t// 212 NewArr v313 @ X0_v2 (System.Single[]), typeof(System.Single[]), v67.Length\nL_00D6:\n\tp.length = v273;\n\tp.wpLengths = v318;\n\tp.timesTable = v313;\n\treturn;\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 178 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void SetTimeToLengthTables(Path p, int subdivisions)
		{
			//IL_006a: Expected O, but got I
			//IL_007a: Expected O, but got I
			//IL_008a: Expected O, but got I
			//IL_009e: Expected I4, but got I8
			//IL_00da: Expected O, but got I
			//IL_01c7: Expected I, but got O
			//IL_0233: Expected I, but got O
			//IL_0253: Expected O, but got I
			//IL_0263: Expected O, but got I
			//IL_0273: Expected O, but got I
			//IL_02bf: Expected O, but got I
			//IL_02f2: Expected O, but got I
			Vector3[] wps = p.wps;
			float[] array = new float[wps.Length];
			Vector3[] wps2 = p.wps;
			float num14;
			float[] wpLengths;
			float[] array2 = default(float[]);
			if (wps.Length > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ X8_v12 (UnityEngine.Vector3[])+20]");
				Vector3 vector = (Vector3)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ X8_v12 (UnityEngine.Vector3[])+24]");
				Vector3 vector2 = (Vector3)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ X8_v12 (UnityEngine.Vector3[])+28]");
				Vector3 vector3 = (Vector3)0;
				int num = (int)(wps.Length & 0xFFFFFFFFL);
				int num2 = num - 1;
				float num3 = 0f;
				int num4 = 0;
				int num5 = 0;
				while (true)
				{
					object obj = (nint)wps2 + num5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ X8_v13+20]");
					float num6 = 0f - vector.x;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ X8_v13+24]");
					float num7 = 0f - vector2.x;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ X8_v13+28]");
					float num8 = 0f - vector3.x;
					float num9 = num6 * num6;
					float num10 = num7 * num7;
					float num11 = num8 * num8;
					float num12 = num9 + num10;
					float f = num11 + num12;
					float num13 = Mathf.Sqrt(f);
					bool flag = num2 == num4;
					num14 = num3 + num13;
					array[num4] = num13;
					nint num15 = (nint)typeof(float[]);
					wpLengths = array;
					if (flag)
					{
						break;
					}
					wps2 = p.wps;
					num4++;
					num5 += 12;
					bool flag2 = p.wps == null;
					bool flag3 = !flag2;
					num15 = (nint)typeof(float[]);
					wpLengths = array;
					num3 = num14;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ X8_v13+28]");
					vector3 = (Vector3)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ X8_v13+24]");
					vector2 = (Vector3)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ X8_v13+20]");
					vector = (Vector3)0;
					if (!flag3)
					{
						throw new NullReferenceException();
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"SzArrayNew\"");
				if (wps.Length >= 2)
				{
					object obj2 = (nint)array + 36;
					float num16 = 0f;
					int num17 = 0;
					do
					{
						int num18 = num17 << 2;
						object obj3 = (nint)array2 + num18;
						num17++;
						float num19 = num16;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ X10_v4+v211 @ X8_v7 (System.Int32)*4]");
						num16 = num19 + 0f;
						float num20 = num16 / num14;
					}
					while (num2 != num17);
				}
			}
			else
			{
				array2 = new float[wps.Length];
				num14 = 0f;
				wpLengths = array;
			}
			p.length = num14;
			p.wpLengths = wpLengths;
			p.timesTable = array2;
		}

		[Token(Token = "0x60003A2")]
		[Address(RVA = "0xC2A348", Offset = "0xC2A348", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		internal void SetWaypointsLengths(Path p, int subdivisions)
		{
		}

		[Token(Token = "0x60003A3")]
		[Address(RVA = "0xC2A34C", Offset = "0xC2A34C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LinearDecoder()
		{
		}
	}
}
