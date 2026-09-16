using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening.Plugins.Core.PathCore
{
	[Token(Token = "0x200009C")]
	internal class CatmullRomDecoder : ABSPathDecoder
	{
		[Token(Token = "0x40001AA")]
		private static readonly ControlPoint[] _PartialControlPs;

		[Token(Token = "0x40001AB")]
		private static readonly Vector3[] _PartialWps;

		[Token(Token = "0x1700000C")]
		internal override int minInputWaypoints
		{
			[Token(Token = "0x6000397")]
			[Address(RVA = "0xC2940C", Offset = "0xC2940C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return 1;
			}
		}

		[Token(Token = "0x6000398")]
		[Address(RVA = "0xC29414", Offset = "0xC29414", Length = "0x258")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv32 = DG.Tweening.Plugins.Core.PathCore.ControlPoint[];\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, p, wps, isClosedPath, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 1;\n\t*([1A357A6]) = v48;\nL_001D:\n\tv147 = p.controlPoints;\n\tv150 = p.controlPoints == 0;\n\tif (v150) goto L_0030;\n\tv221 = v147.Length == 2;\n\tif (v221) goto L_0034;\nL_0030:\n\t// 48 NewArr v239 @ X0_v19 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[]), typeof(DG.Tweening.Plugins.Core.PathCore.ControlPoint[]), 2\n\tp.controlPoints = v239;\nL_0034:\n\tv205 = isClosedPath == 0;\n\tif (v205) goto L_0094;\n\tv210 = wps.Length - 2;\n\tv321 = v210 * 0xC;\n\tv322 = wps + v321;\n\tgoto L_0059;\n\tv329 = UnityEngine.Vector3;\n\tv330 = \"il2cpp_codegen_initialize_runtime_metadata\"(v329, v79, wps, isClosedPath, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv331 = 1;\n\t*([1A35519]) = v331;\nL_0059:\n\tv142 = UnityEngine.Vector3;\n\tv338 = *([v142 @ X8_v24 (Il2CppClass<UnityEngine.Vector3>)+B8]);\n\t*([v147 @ X22_v5 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+20]) = *([v322 @ X8_v19+20]);\n\t*([v147 @ X22_v5 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+28]) = wps[v210 @ X8_v17].z;\n\t*([v147 @ X22_v5 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+2C]) = v338.zeroVector;\n\t*([v147 @ X22_v5 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+34]) = *([v338 @ X9_v10 (Il2CppStaticFields<UnityEngine.Vector3>)+8]);\n\tv279 = p.controlPoints;\n\tv273 = *([wps @ X2 (UnityEngine.Vector3[])+34]);\n\tv271 = *([wps @ X2 (UnityEngine.Vector3[])+2C]);\n\tgoto L_00E0;\nL_0094:\n\tgoto L_00A1;\n\tv333 = UnityEngine.Vector3;\n\tv334 = \"il2cpp_codegen_initialize_runtime_metadata\"(v333, v79, wps, isClosedPath, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv335 = 1;\n\t*([1A35519]) = v335;\nL_00A1:\n\tv53 = wps.Length - 1;\n\tv143 = UnityEngine.Vector3;\n\tv343 = *([v143 @ X8_v15 (Il2CppClass<UnityEngine.Vector3>)+B8]);\n\t*([v147 @ X22_v5 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+20]) = *([wps @ X2 (UnityEngine.Vector3[])+2C]);\n\t*([v147 @ X22_v5 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+28]) = *([wps @ X2 (UnityEngine.Vector3[])+34]);\n\t*([v147 @ X22_v5 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+2C]) = v343.zeroVector;\n\t*([v147 @ X22_v5 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+34]) = *([v343 @ X9_v4 (Il2CppStaticFields<UnityEngine.Vector3>)+8]);\n\tv56 = wps.Length - 2;\n\tv279 = p.controlPoints;\n\tv374 = v53 * 0xC;\n\tv358 = wps + v374;\n\tv365 = v56 * 0xC;\n\tv359 = wps + v365;\n\tv355 = wps[v53 @ X11_v4].z - wps[v56 @ X10_v4].z;\n\tv353 = *([v358 @ X11_v6+20]) - *([v359 @ X10_v6+20]);\n\tv273 = wps[v53 @ X11_v4].z + v355;\n\tv271 = *([v358 @ X11_v6+20]) + v353;\nL_00E0:\n\tv368 = *([v367 @ X8_v6 (Il2CppClass<UnityEngine.Vector3>)+B8]);\n\t*([v279 @ X9_v3 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+38]) = v271;\n\t*([v279 @ X9_v3 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+40]) = v273;\n\t*([v279 @ X9_v3 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+44]) = v368.zeroVector;\n\t*([v279 @ X9_v3 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+4C]) = *([v368 @ X8_v7 (Il2CppStaticFields<UnityEngine.Vector3>)+8]);\n\tv371 = p.subdivisionsXSegment * wps.Length;\n\tp.subdivisions = v371;\n\tDG.Tweening.Plugins.Core.PathCore.CatmullRomDecoder::SetTimeToLengthTables(this, p, v371);\n\tDG.Tweening.Plugins.Core.PathCore.CatmullRomDecoder::SetWaypointsLengths(this, p, p.subdivisionsXSegment);\n\treturn;\n\tv148 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 188 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal override void FinalizePath(Path p, Vector3[] wps, bool isClosedPath)
		{
			//IL_0154: Expected O, but got I4
			//IL_0162: Expected I, but got O
			//IL_016b: Expected I, but got O
			//IL_0083: Expected O, but got I4
			//IL_01ad: Expected O, but got I4
			//IL_0097: Expected O, but got I
			//IL_00a6: Expected O, but got I
			//IL_00b9: Expected I, but got O
			//IL_00c2: Expected I, but got O
			//IL_01d3: Expected O, but got I
			//IL_01e2: Expected O, but got I
			//IL_01f1: Expected O, but got I
			//IL_0200: Expected O, but got I
			//IL_0229: Expected O, but got F4
			//IL_0246: Expected O, but got I
			//IL_025c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0261: Expected F4, but got Unknown
			//IL_0284: Expected O, but got I
			//IL_0292: Expected I, but got O
			//IL_02bd: Expected I, but got O
			//IL_011c: Expected O, but got I
			//IL_012c: Expected O, but got I
			//IL_013a: Expected I, but got O
			ControlPoint[] controlPoints = p.controlPoints;
			if (p.controlPoints == null || controlPoints.Length != 2)
			{
				ControlPoint[] controlPoints2 = new ControlPoint[2];
				p.controlPoints = controlPoints2;
			}
			if (isClosedPath)
			{
				object obj = wps.Length - 2;
				object obj2 = (nint)obj * 12;
				object obj3 = (nint)wps + (nint)obj2;
				nint num = (nint)typeof(Vector3);
				nint num2 = (nint)Vector3.zero;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ X8_v19+20]");
				_ = 0;
				_ = wps[obj].z;
				_ = Vector3.zero;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v338 @ X9_v10 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				_ = 0;
				ControlPoint[] controlPoints3 = p.controlPoints;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [wps @ X2 (UnityEngine.Vector3[])+34]");
				Vector3 vector = (Vector3)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [wps @ X2 (UnityEngine.Vector3[])+2C]");
				Vector3 vector2 = (Vector3)0;
				nint num3 = (nint)typeof(Vector3);
			}
			else
			{
				object obj4 = wps.Length - 1;
				nint num4 = (nint)typeof(Vector3);
				nint num5 = (nint)Vector3.zero;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [wps @ X2 (UnityEngine.Vector3[])+2C]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [wps @ X2 (UnityEngine.Vector3[])+34]");
				_ = 0;
				_ = Vector3.zero;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ X9_v4 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				_ = 0;
				object obj5 = wps.Length - 2;
				ControlPoint[] controlPoints3 = p.controlPoints;
				object obj6 = (nint)obj4 * 12;
				object obj7 = (nint)wps + (nint)obj6;
				object obj8 = (nint)obj5 * 12;
				object obj9 = (nint)wps + (nint)obj8;
				object obj10 = wps[obj4].z - wps[obj5].z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ X11_v6+20]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v359 @ X10_v6+20]");
				object obj11 = num6 - 0;
				float x = wps[obj4].z + obj10;
				Vector3 vector = default(Vector3);
				vector.x = x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ X11_v6+20]");
				Vector3 vector2 = (Vector3)(0 + (nint)obj11);
				nint num3 = (nint)typeof(Vector3);
			}
			nint num7 = (nint)Vector3.zero;
			_ = Vector3.zero;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ X8_v7 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			_ = 0;
			SetTimeToLengthTables(p, p.subdivisions = p.subdivisionsXSegment * wps.Length);
			SetWaypointsLengths(p, p.subdivisionsXSegment);
		}

		[Token(Token = "0x6000399")]
		[Address(RVA = "0xC29C48", Offset = "0xC29C48", Length = "0x274")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv24 = System.Math;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, wps, p, controlPoints, methodInfo, v28, v29, v30, perc, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A357A7]) = v41;\nL_001B:\n\tv47 = wps.Length - 1;\n\tgoto L_0023;\n\tv160 = \"il2cpp_codegen_runtime_class_init\"(v46, wps, p, controlPoints, methodInfo, v28, v29, v30, perc, v31, v32, v33, v34, v35, v36, v37);\nL_0023:\n\tv147 = v47 * perc;\n\tv140 = UnityEngine.Mathf::Floor(v147);\n\tv174 = v140 != 0x7F800000;\n\tif (v174) goto L_FFFFFFFF;\n\tgoto L_0037;\nL_0037:\n\tv135 = wps.Length - 2;\n\tv125 = v135 - v157;\n\tv120 = v125 < 0;\n\tv115 = v125 == 0;\n\tv110 = v135 ^ v157;\n\tv105 = v135 ^ v125;\n\tv100 = v110 & v105;\n\tv95 = v100 < 0;\n\tv266 = v120 == v95;\n\tv52 = ~v115;\n\tv56 = v266 & v52;\n\tv91 = ~v56;\n\tif (v91) goto L_FFFFFFFF;\n\tgoto L_004A;\nL_004A:\n\tv269 = v157 == 0;\n\tif (v269) goto L_0065;\n\tv136 = wps.Length;\n\tv271 = v157 - 1;\n\tv283 = v271 * 0xC;\n\tv284 = wps + v283;\n\tv292 = v284 + 0x20;\n\tgoto L_0073;\nL_0065:\n\tv136 = wps.Length;\n\tv292 = controlPoints + 0x20;\nL_0073:\n\tv289 = v157 + 1;\n\tv346 = v157 * 0xC;\n\tv347 = wps + v346;\n\tv329 = v289 * 0xC;\n\tv348 = wps + v329;\n\tv89 = v157 + 2;\n\tv85 = v136 - 1;\n\tv57 = v89 <= v85;\n\tif (v57) goto L_00BB;\n\tv222 = controlPoints + 0x38;\n\tgoto L_00CF;\nL_00BB:\n\tv357 = v89 * 0xC;\n\tv358 = wps + v357;\n\tv222 = v358 + 0x20;\nL_00CF:\n\tv378 = *([v347 @ X10_v4 (System.Single)+20]) * 0;\n\tv379 = *([v348 @ X11_v4 (System.Single)+20]) * 0;\n\tv181 = *([v348 @ X11_v4 (System.Single)+20]) * 0;\n\tv380 = *([v348 @ X11_v4 (System.Single)+20]) - v292.m_value;\n\tv381 = v378 - v292.m_value;\n\tv382 = v292.m_value + v292.m_value;\n\tv383 = *([v347 @ X10_v4 (System.Single)+20]) * 0;\n\tv384 = v382 + v383;\n\t// 219 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv210 = v380 * v390;\n\tv193 = v381 - v379;\n\tv394 = v384 + v181;\n\tv216 = v193 + v222.m_value;\n\tv398 = v394 - v222.m_value;\n\tv399 = v216 * v390;\n\tv400 = v398 * v401;\n\tv402 = v399 + v400;\n\tv214 = *([v347 @ X10_v4 (System.Single)+20]) + *([v347 @ X10_v4 (System.Single)+20]);\n\tv403 = v210 + v402;\n\tv405 = v214 + v403;\n\treturnVal2 = v405 * 0x3F;\n\treturn returnVal2;\n\tv150 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 184 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe override Vector3 GetPoint(float perc, Vector3[] wps, Path p, ControlPoint[] controlPoints)
		{
			//IL_0015: Expected O, but got I4
			//IL_0223: Expected O, but got F4
			//IL_0230: Expected O, but got F4
			//IL_00e2: Expected O, but got I4
			//IL_008f: Expected O, but got I4
			//IL_0169: Expected O, but got I
			//IL_02c2: Expected O, but got I
			//IL_02d8: Expected O, but got I
			//IL_02ee: Expected O, but got I
			//IL_02ff: Expected native int or pointer, but got F4
			//IL_0313: Expected native int or pointer, but got F4
			//IL_0322: Expected native int or pointer, but got F4
			//IL_032c: Expected native int or pointer, but got F4
			//IL_034d: Expected O, but got I
			//IL_039c: Expected native int or pointer, but got F4
			//IL_03b0: Expected native int or pointer, but got F4
			//IL_0405: Expected O, but got I
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
			if (!(flag4 && flag5))
			{
				num3 = num4;
			}
			object obj4;
			float num10;
			if (num3 != 0f)
			{
				obj4 = wps.Length;
				float num7 = num3 - float.Epsilon;
				float num8 = num7 * 1.7E-44f;
				float num9 = (float)wps + num8;
				num10 = num9 + 4.5E-44f;
			}
			else
			{
				obj4 = wps.Length;
				num10 = (float)controlPoints + 4.5E-44f;
			}
			float num11 = num3 + float.Epsilon;
			float num12 = num3 * 1.7E-44f;
			float num13 = (float)wps + num12;
			float num14 = num11 * 1.7E-44f;
			float num15 = (float)wps + num14;
			float num16 = num3 + 3E-45f;
			object obj5 = (nint)obj4 - 1;
			float num17;
			if (num16 > (float)obj5)
			{
				num17 = (float)controlPoints + 7.8E-44f;
			}
			else
			{
				float num18 = num16 * 1.7E-44f;
				float num19 = (float)wps + num18;
				num17 = num19 + 4.5E-44f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ X10_v4 (System.Single)+20]");
			object obj6 = (nint)0 * (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ X11_v4 (System.Single)+20]");
			object obj7 = (nint)0 * (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ X11_v4 (System.Single)+20]");
			object obj8 = (nint)0 * (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ X11_v4 (System.Single)+20]");
			float num20 = 0f - ((float*)(nint)num10)->m_value;
			float num21 = (float)obj6 - ((float*)(nint)num10)->m_value;
			float num22 = ((float*)(nint)num10)->m_value + ((float*)(nint)num10)->m_value;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ X10_v4 (System.Single)+20]");
			object obj9 = (nint)0 * (nint)0;
			float num23 = num22 + (float)obj9;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
			object obj10 = default(object);
			float num24 = num20 * (float)obj10;
			float num25 = num21 - (float)obj7;
			float num26 = num23 + (float)obj8;
			float num27 = num25 + ((float*)(nint)num17)->m_value;
			float num28 = num26 - ((float*)(nint)num17)->m_value;
			float num29 = num27 * (float)obj10;
			object obj11 = default(object);
			float num30 = num28 * (float)obj11;
			float num31 = num29 + num30;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ X10_v4 (System.Single)+20]");
			nint num32 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ X10_v4 (System.Single)+20]");
			object obj12 = num32 + 0;
			float num33 = num24 + num31;
			float num34 = (float)obj12 + num33;
			float x = num34 * 8.8E-44f;
			Vector3 result = default(Vector3);
			result.x = x;
			return result;
		}

		[Token(Token = "0x600039A")]
		[Address(RVA = "0xC2966C", Offset = "0xC2966C", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv52 = System.Single[];\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, p, subdivisions, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv69 = 1;\n\t*([1A357A8]) = v69;\nL_0026:\n\t// 38 NewArr v72 @ X0_v3 (System.Single[]), typeof(System.Single[]), subdivisions @ X2 (System.Int32)\n\t// 43 NewArr v77 @ X0_v5 (System.Single[]), typeof(System.Single[]), subdivisions @ X2 (System.Int32)\n\tv89 = DG.Tweening.Plugins.Core.PathCore.CatmullRomDecoder::GetPoint(this, 0f, p.wps, p, p.controlPoints);\n\tv90 = subdivisions + 1;\n\tv101 = v90 < 2;\n\tif (v101) goto L_00A8;\n\tv204 = 1f / subdivisions;\nL_005A:\n\tv111 = v122 - 7;\n\tv103 = v204 * v111;\n\tv341 = DG.Tweening.Plugins.Core.PathCore.CatmullRomDecoder::GetPoint(this, v103, p.wps, p, p.controlPoints);\n\tgoto L_006F;\n\tv385 = v190;\n\tv386 = \"il2cpp_codegen_initialize_runtime_metadata\"(v385, v183, v171, v181, v175, v56, v57, v58, v173, v128, v113, v62, v63, v64, v65, v66);\n\t*([1A357E4]) = v118;\nL_006F:\n\tgoto L_0074;\n\tv391 = \"il2cpp_codegen_runtime_class_init\"(v388, v183, v171, v181, v175, v56, v57, v58, v173, v128, v113, v62, v63, v64, v65, v66);\nL_0074:\n\tv193 = v111 - 1;\n\t*([v72 @ X0_v3 (System.Single[])+v122 @ X25_v6 (System.Int32)*4]) = v103;\n\tv394 = v103 - v132;\n\tv395 = v204 - v130;\n\tv396 = v113 - v126;\n\tv397 = v394 * v394;\n\tv221 = v395 * v395;\n\tv113 = v396 * v396;\n\tv398 = v397 + v221;\n\tv399 = v113 + v398;\n\tv248 = UnityEngine.Mathf::Sqrt(v399);\n\tv258 = v193 + 2;\n\tv244 = v169 + v248;\n\t*([v77 @ X0_v5 (System.Single[])+v122 @ X25_v6 (System.Int32)*4]) = v244;\n\tv122 = v122 + 1;\n\tv227 = v258 != v90;\n\tif (v227) goto L_005A;\nL_00A8:\n\tp.length = v244;\n\tp.timesTable = v72;\n\tp.lengthsTable = v77;\n\treturn;\n\tv195 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 150 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x600039B")]
		[Address(RVA = "0xC29864", Offset = "0xC29864", Length = "0x3E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv52 = DG.Tweening.Plugins.Core.PathCore.CatmullRomDecoder;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, p, subdivisions, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv73 = System.Single[];\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v73, p, subdivisions, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv70 = 1;\n\t*([1A357A9]) = v70;\nL_0028:\n\tv74 = p.wps;\n\t// 48 NewArr v244 @ X0_v7 (System.Single[]), typeof(System.Single[]), v74.Length\n\tv244[0] = 0;\n\tv492 = v74.Length < 2;\n\tif (v492) goto L_01A0;\n\tv493 = v74.Length - 1;\n\tv494 = subdivisions + 1;\n\tv495 = v74.Length & 0xFFFFFFFF;\n\tv120 = 1f / subdivisions;\nL_0059:\n\tgoto L_005D;\n\tv536 = \"il2cpp_codegen_runtime_class_init\"(v532, v228, v81, v79, v77, v56, v57, v58, v133, v128, v92, v62, v63, v64, v65, v66);\n\tv537 = DG.Tweening.Plugins.Core.PathCore.CatmullRomDecoder;\nL_005D:\n\tv260 = v538._PartialControlPs;\n\tv115 = v118 - 1;\n\tv150 = v118 != 1;\n\tif (v150) goto L_007B;\n\tv543 = p.controlPoints;\n\tv540 = v543.Length == 0;\n\tv382 = ~v540;\n\tif (v382) goto L_008E;\n\tgoto L_01B8;\nL_007B:\n\tv293 = v118 - 2;\n\tv547 = v293 * 0xC;\n\tv543 = p.wps + v547;\nL_008E:\n\t*([v260 @ X8_v14 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+20]) = *([v543 @ X11_v5 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+20]);\n\t*([v260 @ X8_v14 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+24]) = *([v543 @ X11_v5 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+24]);\n\t*([v260 @ X8_v14 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+28]) = *([v543 @ X11_v5 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+28]);\n\tgoto L_00A7;\n\tv552 = \"il2cpp_codegen_runtime_class_init\"(v548, v228, v81, v79, v77, v56, v57, v58, v134, v129, v93, v62, v63, v64, v65, v66);\n\tv553 = DG.Tweening.Plugins.Core.PathCore.CatmullRomDecoder;\nL_00A7:\n\tv238 = v555._PartialWps;\n\tv556 = v115 * 0xC;\n\tv557 = p.wps + v556;\n\t*([v238 @ X9_v12 (UnityEngine.Vector3[])+20]) = *([v557 @ X8_v17+20]);\n\t*([v238 @ X9_v12 (UnityEngine.Vector3[])+28]) = *([v557 @ X8_v17+28]);\n\tv239 = v560._PartialWps;\n\tv563 = v118 * 0xC;\n\tv564 = p.wps + v563;\n\t*([v239 @ X9_v16 (UnityEngine.Vector3[])+2C]) = *([v564 @ X8_v19+20]);\n\t*([v239 @ X9_v16 (UnityEngine.Vector3[])+34]) = *([v564 @ X8_v19+28]);\n\tv263 = v566._PartialControlPs;\n\tv152 = v118 != v493;\n\tif (v152) goto L_010F;\n\tv590 = p.controlPoints + 0x38;\n\tv295 = p.controlPoints + 0x3C;\n\tv299 = p.controlPoints + 0x40;\n\tgoto L_0120;\nL_010F:\n\tv294 = v118 + 1;\n\tv576 = v294 * 0xC;\n\tv577 = p.wps + v576;\n\tv590 = v577 + 0x20;\n\tv295 = v577 + 0x24;\n\tv299 = v577 + 0x28;\nL_0120:\n\tv680 = *([v295 @ X10_v9]);\n\tv674 = *([v299 @ X11_v7]);\n\t*([v263 @ X8_v22 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+38]) = *([v590 @ X9_v19]);\n\t*([v263 @ X8_v22 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+3C]) = *([v295 @ X10_v9]);\n\t*([v263 @ X8_v22 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+40]) = *([v299 @ X11_v7]);\n\tgoto L_0136;\n\tv599 = \"il2cpp_codegen_runtime_class_init\"(v595, v228, v81, v79, v77, v56, v57, v58, v592, v593, v594, v62, v63, v64, v65, v66);\n\tv601 = DG.Tweening.Plugins.Core.PathCore.CatmullRomDecoder;\nL_0136:\n\tv612 = DG.Tweening.Plugins.Core.PathCore.CatmullRomDecoder::GetPoint(this, 0f, v602._PartialWps, p, v602._PartialControlPs);\n\tv624 = v494 < 2;\n\tif (v624) goto L_0193;\nL_014D:\n\tgoto L_0158;\n\tv701 = \"il2cpp_codegen_runtime_class_init\"(v696, v691, v670, v669, v668, v56, v57, v58, v681, v680, v674, v62, v63, v64, v65, v66);\n\tv703 = DG.Tweening.Plugins.Core.PathCore.CatmullRomDecoder;\nL_0158:\n\tv662 = v679 + 1;\n\tv709 = v120 * v662;\n\tv710 = DG.Tweening.Plugins.Core.PathCore.CatmullRomDecoder::GetPoint(this, v709, v704._PartialWps, p, v704._PartialControlPs);\n\tgoto L_016A;\n\tv714 = v231;\n\tv715 = \"il2cpp_codegen_initialize_runtime_metadata\"(v714, v661, v632, v631, v630, v56, v57, v58, v709, v680, v674, v62, v63, v64, v65, v66);\n\t*([1A357E4]) = v126;\nL_016A:\n\tgoto L_016C;\n\tv719 = \"il2cpp_codegen_runtime_class_init\"(v717, v661, v632, v631, v630, v56, v57, v58, v709, v680, v674, v62, v63, v64, v65, v66);\nL_016C:\n\tv720 = v709 - v678;\n\tv721 = v680 - v677;\n\tv722 = v674 - v676;\n\tv723 = v720 * v720;\n\tv642 = v721 * v721;\n\tv674 = v722 * v722;\n\tv724 = v723 + v642;\n\tv725 = v674 + v724;\n\tv679 = v679 + 1;\n\tv643 = UnityEngine.Mathf::Sqrt(v725);\n\tv285 = v675 + v643;\n\tv644 = subdivisions != v679;\n\tif (v644) goto L_014D;\nL_0193:\n\tv511 = v118 + 1;\n\tv244[v118 @ X25_v6 (System.Int32)] = v285;\n\tv517 = v511 != v495;\n\tif (v517) goto L_0059;\nL_01A0:\n\tp.wpLengths = v244;\n\treturn;\n\tv266 = new System.NullReferenceException();\nL_01B8:\n\tthrow System.IndexOutOfRangeException;\n// 338 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void SetWaypointsLengths(Path p, int subdivisions)
		{
			//IL_008f: Expected I4, but got I8
			//IL_0151: Expected O, but got I
			//IL_0185: Expected O, but got I
			//IL_01d3: Expected O, but got I
			//IL_028f: Expected O, but got I
			//IL_029e: Expected O, but got I
			//IL_02ad: Expected O, but got I
			//IL_02bc: Expected O, but got I
			//IL_022e: Expected O, but got I
			//IL_0242: Expected O, but got I
			//IL_0256: Expected O, but got I
			//IL_030f: Expected O, but got I
			//IL_031e: Expected O, but got I
			//IL_033c: Expected O, but got I
			//IL_034b: Expected O, but got I
			Vector3[] wps = p.wps;
			float[] array = new float[wps.Length];
			array[0] = 0f;
			if (wps.Length >= 2)
			{
				int num = wps.Length - 1;
				int num2 = subdivisions + 1;
				int num3 = (int)(wps.Length & 0xFFFFFFFFL);
				float num4 = 1f / (float)subdivisions;
				int num5 = 1;
				bool flag3;
				do
				{
					ControlPoint[] partialControlPs = _PartialControlPs;
					int num6 = num5 - 1;
					if (num5 == 1)
					{
						ControlPoint[] controlPoints = p.controlPoints;
						if (controlPoints.Length == 0)
						{
							throw new IndexOutOfRangeException();
						}
					}
					else
					{
						int num7 = num5 - 2;
						int num8 = num7 * 12;
						ControlPoint[] controlPoints = (ControlPoint[])((nint)p.wps + num8);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v543 @ X11_v5 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+20]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v543 @ X11_v5 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+24]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v543 @ X11_v5 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+28]");
					_ = 0;
					Vector3[] partialWps = _PartialWps;
					int num9 = num6 * 12;
					object obj = (nint)p.wps + num9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ X8_v17+20]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ X8_v17+28]");
					_ = 0;
					Vector3[] partialWps2 = _PartialWps;
					int num10 = num5 * 12;
					object obj2 = (nint)p.wps + num10;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ X8_v19+20]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ X8_v19+28]");
					_ = 0;
					ControlPoint[] partialControlPs2 = _PartialControlPs;
					object obj4;
					object obj5;
					if (num5 == num)
					{
						object obj3 = (nint)p.controlPoints + 56;
						obj4 = (nint)p.controlPoints + 60;
						obj5 = (nint)p.controlPoints + 64;
					}
					else
					{
						int num11 = num5 + 1;
						int num12 = num11 * 12;
						object obj6 = (nint)p.wps + num12;
						object obj3 = (nint)obj6 + 32;
						obj4 = (nint)obj6 + 36;
						obj5 = (nint)obj6 + 40;
					}
					object obj7 = obj4;
					object obj8 = obj5;
					Vector3 point = GetPoint(0f, _PartialWps, p, _PartialControlPs);
					bool flag = num2 < 2;
					float num13 = 0f;
					if (!flag)
					{
						float num14 = 0f;
						object obj9 = obj5;
						object obj10 = obj4;
						float num15 = 0f;
						int num16 = 0;
						bool flag2;
						do
						{
							int num17 = num16 + 1;
							float num18 = num4 * (float)num17;
							Vector3 point2 = GetPoint(num18, _PartialWps, p, _PartialControlPs);
							float num19 = num18 - num15;
							object obj11 = (nint)obj7 - (nint)obj10;
							object obj12 = (nint)obj8 - (nint)obj9;
							float num20 = num19 * num19;
							object obj13 = (nint)obj11 * (nint)obj11;
							obj8 = (nint)obj12 * (nint)obj12;
							float num21 = num20 + (float)obj13;
							float f = (float)obj8 + num21;
							num16++;
							float num22 = Mathf.Sqrt(f);
							num13 = num14 + num22;
							flag2 = subdivisions != num16;
							num14 = num13;
							obj9 = obj8;
							obj10 = obj7;
							num15 = num18;
							obj7 = obj13;
						}
						while (flag2);
					}
					int num23 = num5 + 1;
					array[num5] = num13;
					flag3 = num23 != num3;
					num5 = num23;
				}
				while (flag3);
			}
			p.wpLengths = array;
		}

		[Token(Token = "0x600039C")]
		[Address(RVA = "0xC29EBC", Offset = "0xC29EBC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CatmullRomDecoder()
		{
		}

		[Token(Token = "0x600039D")]
		[Address(RVA = "0xC29EC4", Offset = "0xC29EC4", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv22 = DG.Tweening.Plugins.Core.PathCore.CatmullRomDecoder;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv48 = DG.Tweening.Plugins.Core.PathCore.ControlPoint[];\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv56 = UnityEngine.Vector3[];\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv43 = 1;\n\t*([1A357AA]) = v43;\nL_001F:\n\t// 31 NewArr v46 @ X0_v3 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[]), typeof(DG.Tweening.Plugins.Core.PathCore.ControlPoint[]), 2\n\tv52._PartialControlPs = v46;\n\t// 37 NewArr v54 @ X0_v5 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), 2\n\tv62._PartialWps = v54;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static CatmullRomDecoder()
		{
			ControlPoint[] partialControlPs = new ControlPoint[2];
			_PartialControlPs = partialControlPs;
			Vector3[] partialWps = new Vector3[2];
			_PartialWps = partialWps;
		}
	}
}
