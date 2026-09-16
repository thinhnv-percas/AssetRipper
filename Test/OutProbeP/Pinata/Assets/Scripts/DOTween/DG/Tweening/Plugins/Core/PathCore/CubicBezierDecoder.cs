using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening.Plugins.Core.PathCore
{
	[Token(Token = "0x2000041")]
	internal class CubicBezierDecoder : ABSPathDecoder
	{
		[Token(Token = "0x4000112")]
		private static readonly ControlPoint[] _PartialControlPs;

		[Token(Token = "0x4000113")]
		private static readonly Vector3[] _PartialWps;

		[Token(Token = "0x6000240")]
		[Address(RVA = "0x108125C", Offset = "0x108125C", Length = "0x450")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv34 = &v35 @ stack_-10_v2;\n\tgoto L_0027;\n\tv50 = *([1F0E1C8]);\n\tv51 = *([v50 @ X8_v42]);\n\tv52 = \"il2cpp_codegen_initialize_method\"(v51, p, wps, isClosedPath, methodInfo, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv67 = 0 | 1;\n\t*([2026A4B]) = v67;\nL_0027:\n\tv72 = isClosedPath == 0;\n\tif (v72) goto L_003E;\n\tv92 = p.addedExtraEndWp == 0;\n\tv77 = ~v92;\nL_003E:\n\tv373 = p.addedExtraEndWp + p.addedExtraStartWp;\n\tv374 = v373 + 3;\n\tv291 = v374 > wps.Length;\n\tif (v291) goto L_005F;\n\tv513 = wps.Length - v373;\n\tv515 = v513 * 0x55555556;\n\tv516 = v515 >> 0x3F;\n\tv265 = v515 >> 0x20;\n\tv517 = v265 + v516;\n\tv253 = v517 << 1;\n\tv258 = v517 + v253;\n\tv519 = v513 == v258;\n\tif (v519) goto L_007F;\nL_005F:\n\tgoto L_0069;\n\tv536 = *([v528 @ X0_v3+E0]);\n\tv537 = v536 == 0;\n\tv538 = ~v537;\n\tif (v538) goto L_0069;\n\tv540 = \"il2cpp_codegen_runtime_class_init\"(v528, p, wps, isClosedPath, methodInfo, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\nL_0069:\n\tUnityEngine.Debug::LogError(\"CubicBezier paths must contain waypoints in multiple of 3 excluding the starting point added automatically by DOTween (1: waypoint, 2: IN control point, 3: OUT control point — the minimum amount of waypoints for a single curve is 3)\");\nL_007C:\n\treturn;\nL_007F:\n\tv284 = v265 + v516;\n\tv358 = v284 + v373;\n\t// 131 NewArr v535 @ X0_v8 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), v358 @ X21_v4\n\tv248 = v358 - 1;\n\t// 137 NewArr v345 @ X0_v10 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[]), typeof(DG.Tweening.Plugins.Core.PathCore.ControlPoint[]), v248 @ X1_v4\n\tp.controlPoints = v345;\n\tv614 = wps.Length == 0;\n\tif (v614) goto L_01E0;\n\tv677 = v535.Length == 0;\n\tif (v677) goto L_01E0;\n\t*([v535 @ X0_v8 (UnityEngine.Vector3[])+20]) = *([wps @ X2 (UnityEngine.Vector3[])+20]);\n\t*([v535 @ X0_v8 (UnityEngine.Vector3[])+24]) = *([wps @ X2 (UnityEngine.Vector3[])+24]);\n\t*([v535 @ X0_v8 (UnityEngine.Vector3[])+28]) = *([wps @ X2 (UnityEngine.Vector3[])+28]);\n\tv695 = p.addedExtraStartWp == 0;\n\tv701 = ~v695;\n\tv221 = ~v701;\n\tif (v221) goto L_FFFFFFFF;\n\tgoto L_00B5;\nL_00B5:\n\tv714 = v362 >= wps.Length;\n\tif (v714) goto L_0122;\nL_00BB:\n\tv639 = v362 - 2;\n\tv756 = v639 < wps.Length;\n\tv671 = ~v756;\n\tif (v671) goto L_01E0;\n\tv770 = v273 < v535.Length;\n\tv672 = ~v770;\n\tif (v672) goto L_01E0;\n\tv772 = v639 * 0xC;\n\tv773 = wps + v772;\n\tv679 = v273 * 0xC;\n\tv211 = v535 + v679;\n\t*([v211 @ X14_v6+20]) = *([v773 @ X12_v12+20]);\n\tv535[v273 @ X11_v14 (System.Int32)].z = wps[v639 @ X12_v10 (System.Int32)].z;\n\tv216 = v362 - 1;\n\tv777 = v216 < wps.Length;\n\tv673 = ~v777;\n\tif (v673) goto L_01E0;\n\tv780 = v362 < wps.Length;\n\tv340 = ~v780;\n\tif (v340) goto L_01E0;\n\tv259 = p.controlPoints;\n\tv641 = v273 - 1;\n\tv812 = v641 < v259.Length;\n\tv674 = ~v812;\n\tif (v674) goto L_01E0;\n\tv816 = v216 * 0xC;\n\tv817 = wps + v816;\n\tv818 = v362 * 0xC;\n\tv819 = wps + v818;\n\tv362 = v362 + 3;\n\tv744 = v641 * 0x18;\n\tv722 = v259 + v744;\n\tv273 = v641 + 2;\n\t*([v722 @ X12_v16+20]) = *([v817 @ X13_v10+20]);\n\tv259[v641 @ X11_v15 (System.Int32)].a.y = wps[v216 @ X13_v8 (System.Int32)].y;\n\tv259[v641 @ X11_v15 (System.Int32)].a.z = wps[v216 @ X13_v8 (System.Int32)].z;\n\tv259[v641 @ X11_v15 (System.Int32)].b = *([v819 @ X14_v9+20]);\n\tv259[v641 @ X11_v15 (System.Int32)].b.y = wps[v362 @ X8_v34 (System.Int32)].y;\n\tv259[v641 @ X11_v15 (System.Int32)].b.z = wps[v362 @ X8_v34 (System.Int32)].z;\n\tv726 = v362 < wps.Length;\n\tif (v726) goto L_00BB;\nL_0122:\n\tp.wps = v535;\n\tv680 = ~v74;\n\tif (v680) goto L_01D8;\n\tv757 = v535.Length < 1;\n\tv341 = ~v757;\n\tv335 = v535.Length - 1;\n\tv323 = v335 == 0;\n\tv758 = ~v341;\n\tv293 = v758 | v323;\n\tif (v293) goto L_01E0;\n\tv368 = v535 + 0x20;\n\tv363 = p.controlPoints;\n\tv778 = v363.Length < 1;\n\tv342 = ~v778;\n\tv336 = v363.Length - 1;\n\tv324 = v336 == 0;\n\tv779 = ~v342;\n\tv294 = v779 | v324;\n\tif (v294) goto L_01E0;\n\tv782 = v535.Length << 0x20;\n\tv783 = 0xFFFFFFFE00000000 + v782;\n\tv785 = v783 >> 0x20;\n\tv786 = v785 * 0xC;\n\tv787 = v368 + v786;\n\tv790 = v363 + 0x20;\n\tv254 = v363.Length << 0x20;\n\tv792 = 0xFFFFFFFE00000000 + v254;\n\tv793 = v792 >> 0x20;\n\t*([v34 @ X29_v1-34]) = *([v363 @ X8_v26 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+20]);\n\tv794 = v793 * 0x18;\n\tv287 = v790 + v794;\n\t*([v34 @ X29_v1-38]) = *([v363 @ X8_v26 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+28]);\n\tgoto L_0177;\n\tv802 = *([v795 @ X0_v17+E0]);\n\tv803 = v802 == 0;\n\tv804 = ~v803;\n\tif (v804) goto L_0177;\n\tv806 = \"il2cpp_codegen_runtime_class_init\"(v795, v248, wps, isClosedPath, methodInfo, v54, v55, v56, v799, v58, v59, v60, v61, v62, v63, v64);\nL_0177:\n\t// 375 MakeStruct v157 @ AGG1081580_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v535 @ X0_v8 (UnityEngine.Vector3[])+20], [v535 @ X0_v8 (UnityEngine.Vector3[])+24], [v535 @ X0_v8 (UnityEngine.Vector3[])+28]\n\t// 376 MakeStruct v153 @ AGG1081580_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v787 @ X10_v12], [v787 @ X10_v12+4], [v787 @ X10_v12+8]\n\tv187 = UnityEngine.Vector3::op_Subtraction(v157, v153);\n\tv346 = 0x158AD58(&v187 @ V0_v10 (UnityEngine.Vector3), 0, wps, isClosedPath, methodInfo, v54, v55, v56, v187, v187.y, v187.z, *([v787 @ X10_v12]), *([v787 @ X10_v12+4]), *([v787 @ X10_v12+8]), v63, v64);\n\tv356 = p.controlPoints;\n\t// 397 MakeStruct v624 @ AGG10815BC_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v787 @ X10_v12], [v787 @ X10_v12+4], [v787 @ X10_v12+8]\n\t// 398 MakeStruct v623 @ AGG10815BC_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v287 @ X9_v17+C], [v363 @ X8_v26 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+28], [v363 @ X8_v26 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+28]\n\tv829 = UnityEngine.Vector3::op_Subtraction(v624, v623);\n\tv834 = UnityEngine.Vector3::ClampMagnitude(v829, v187);\n\t// 415 MakeStruct v621 @ AGG10815E8_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v787 @ X10_v12], [v787 @ X10_v12+4], [v787 @ X10_v12+8]\n\tv844 = UnityEngine.Vector3::op_Addition(v621, v834);\n\t// 430 MakeStruct v619 @ AGG1081610_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v535 @ X0_v8 (UnityEngine.Vector3[])+20], [v535 @ X0_v8 (UnityEngine.Vector3[])+24], [v535 @ X0_v8 (UnityEngine.Vector3[])+28]\n\t// 431 MakeStruct v618 @ AGG1081610_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v34 @ X29_v1-34], [v363 @ X8_v26 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+28], [v34 @ X29_v1-38]\n\tv854 = UnityEngine.Vector3::op_Subtraction(v619, v618);\n\tv859 = UnityEngine.Vector3::ClampMagnitude(v854, v187);\n\t// 448 MakeStruct v616 @ AGG108163C_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v535 @ X0_v8 (UnityEngine.Vector3[])+20], [v535 @ X0_v8 (UnityEngine.Vector3[])+24], [v535 @ X0_v8 (UnityEngine.Vector3[])+28]\n\tv630 = UnityEngine.Vector3::op_Addition(v616, v859);\n\tv681 = v356.Length == 0;\n\tif (v681) goto L_01E0;\n\tv760 = v356.Length << 0x20;\n\tv865 = 0xFFFFFFFF00000000 + v760;\n\tv866 = v865 >> 0x20;\n\tv764 = v866 * 0x18;\n\tv766 = v356 + v764;\n\t*([v766 @ X8_v32+20]) = v844;\n\tv356[v866 @ X8_v31 (System.Int32)].a.y = v844.y;\n\tv356[v866 @ X8_v31 (System.Int32)].a.z = v844.z;\n\tv356[v866 @ X8_v31 (System.Int32)].b = v630;\n\tv356[v866 @ X8_v31 (System.Int32)].b.y = v630.y;\n\tv356[v866 @ X8_v31 (System.Int32)].b.z = v630.z;\nL_01D8:\n\tv769 = p.subdivisionsXSegment * v358;\n\tp.subdivisions = v769;\n\tDG.Tweening.Plugins.Core.PathCore.CubicBezierDecoder::SetTimeToLengthTables(this, p, v769);\n\tDG.Tweening.Plugins.Core.PathCore.CubicBezierDecoder::SetWaypointsLengths(this, p, p.subdivisionsXSegment);\n\tgoto L_007C;\nL_01E0:\n\tv685 = new System.IndexOutOfRangeException();\n\tthrow v685;\n\tthrow System.NullReferenceException;\n// 318 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal override void FinalizePath(Path p, Vector3[] wps, bool isClosedPath)
		{
			//IL_0050: Expected O, but got I4
			//IL_012b: Expected O, but got I
			//IL_0147: Expected O, but got I
			//IL_0517: Expected O, but got I4
			//IL_055b: Expected O, but got I
			//IL_0599: Expected O, but got I4
			//IL_0272: Expected O, but got I
			//IL_028e: Expected O, but got I
			//IL_05f0: Expected O, but got I8
			//IL_061b: Expected O, but got I
			//IL_062a: Expected O, but got I
			//IL_064d: Expected O, but got I8
			//IL_0685: Expected O, but got I
			//IL_06af: Expected F4, but got I
			//IL_06c4: Expected F4, but got I
			//IL_06d9: Expected F4, but got I
			//IL_06e6: Expected F4, but got O
			//IL_06fb: Expected F4, but got I
			//IL_0710: Expected F4, but got I
			//IL_0754: Expected F4, but got O
			//IL_0769: Expected F4, but got I
			//IL_077e: Expected F4, but got I
			//IL_0793: Expected F4, but got I
			//IL_07a8: Expected F4, but got I
			//IL_07bd: Expected F4, but got I
			//IL_07f6: Expected F4, but got O
			//IL_080b: Expected F4, but got I
			//IL_0820: Expected F4, but got I
			//IL_0846: Expected F4, but got I
			//IL_085b: Expected F4, but got I
			//IL_0870: Expected F4, but got I
			//IL_0885: Expected F4, but got I
			//IL_089a: Expected F4, but got I
			//IL_08af: Expected F4, but got I
			//IL_08f0: Expected F4, but got I
			//IL_0905: Expected F4, but got I
			//IL_091a: Expected F4, but got I
			//IL_0384: Expected O, but got I
			//IL_03a0: Expected O, but got I
			//IL_03ca: Expected O, but got I
			//IL_0455: Expected O, but got I
			//IL_0971: Expected O, but got I8
			//IL_099c: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			bool flag = !isClosedPath;
			bool flag2 = false;
			if (!flag)
			{
				bool flag3 = !p.addedExtraEndWp;
				bool flag4 = !flag3;
				flag2 = flag4;
			}
			object obj3 = (p.addedExtraEndWp ? 1 : 0) + (p.addedExtraStartWp ? 1 : 0);
			int num = (int)((long)(IntPtr)obj3 + 3L);
			object obj4;
			Vector3[] array;
			if (num <= wps.Length)
			{
				int num2 = (int)((long)wps.Length - (long)(IntPtr)obj3);
				int num3 = num2 * 1431655766;
				int num4 = num3 >> 63;
				int num5 = num3 >> 32;
				int num6 = num5 + num4;
				int num7 = num6 << 1;
				int num8 = num6 + num7;
				if (num2 == num8)
				{
					int num9 = num5 + num4;
					obj4 = (long)num9 + (long)(IntPtr)obj3;
					array = new Vector3[obj4];
					object obj5 = (long)(IntPtr)obj4 - 1L;
					ControlPoint[] controlPoints = new ControlPoint[obj5];
					p.controlPoints = controlPoints;
					if (wps.Length != 0 && array.Length != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [wps @ X2 (UnityEngine.Vector3[])+20]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [wps @ X2 (UnityEngine.Vector3[])+24]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [wps @ X2 (UnityEngine.Vector3[])+28]");
						_ = 0;
						int num10 = ((!p.addedExtraStartWp) ? 5 : 3);
						if (num10 >= wps.Length)
						{
							goto IL_04c5;
						}
						int num11 = 1;
						while (true)
						{
							int num12 = num10 - 2;
							if (num12 >= wps.Length || num11 >= array.Length)
							{
								break;
							}
							int num13 = num12 * 12;
							object obj6 = (long)(IntPtr)wps + (long)num13;
							int num14 = num11 * 12;
							object obj7 = (long)(IntPtr)array + (long)num14;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v773 @ X12_v12+20]");
							_ = 0;
							array[num11].z = wps[num12].z;
							int num15 = num10 - 1;
							if (num15 >= wps.Length || num10 >= wps.Length)
							{
								break;
							}
							ControlPoint[] controlPoints2 = p.controlPoints;
							int num16 = num11 - 1;
							if (num16 >= controlPoints2.Length)
							{
								break;
							}
							int num17 = num15 * 12;
							object obj8 = (long)(IntPtr)wps + (long)num17;
							int num18 = num10 * 12;
							object obj9 = (long)(IntPtr)wps + (long)num18;
							num10 += 3;
							int num19 = num16 * 24;
							object obj10 = (long)(IntPtr)controlPoints2 + (long)num19;
							num11 = num16 + 2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v817 @ X13_v10+20]");
							_ = 0;
							controlPoints2[num16].a.y = wps[num15].y;
							controlPoints2[num16].a.z = wps[num15].z;
							ref ControlPoint reference = ref controlPoints2[num16];
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v819 @ X14_v9+20]");
							reference.b = (Vector3)0;
							controlPoints2[num16].b.y = wps[num10].y;
							controlPoints2[num16].b.z = wps[num10].z;
							if (num10 < wps.Length)
							{
								continue;
							}
							goto IL_04c5;
						}
					}
					goto IL_0a3c;
				}
			}
			Debug.LogError("CubicBezier paths must contain waypoints in multiple of 3 excluding the starting point added automatically by DOTween (1: waypoint, 2: IN control point, 3: OUT control point — the minimum amount of waypoints for a single curve is 3)");
			return;
			IL_0a3c:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_04c5:
			p.wps = array;
			if (flag2)
			{
				bool flag5 = array.Length < 1;
				bool flag6 = !flag5;
				object obj11 = array.Length - 1;
				bool flag7 = obj11 == null;
				bool flag8 = !flag6;
				if (!(flag8 || flag7))
				{
					object obj12 = (long)(IntPtr)array + 32L;
					ControlPoint[] controlPoints3 = p.controlPoints;
					bool flag9 = controlPoints3.Length < 1;
					bool flag10 = !flag9;
					object obj13 = controlPoints3.Length - 1;
					bool flag11 = obj13 == null;
					bool flag12 = !flag10;
					if (!(flag12 || flag11))
					{
						int num20 = array.Length << 32;
						object obj14 = -8589934592L + num20;
						int num21 = (int)((long)(IntPtr)obj14 >> 32);
						int num22 = num21 * 12;
						object obj15 = (long)(IntPtr)obj12 + (long)num22;
						object obj16 = (long)(IntPtr)controlPoints3 + 32L;
						int num23 = controlPoints3.Length << 32;
						object obj17 = -8589934592L + num23;
						int num24 = (int)((long)(IntPtr)obj17 >> 32);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ X8_v26 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+20]");
						_ = 0;
						int num25 = num24 * 24;
						object obj18 = (long)(IntPtr)obj16 + (long)num25;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ X8_v26 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+28]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v535 @ X0_v8 (UnityEngine.Vector3[])+20]");
						Vector3 vector = default(Vector3);
						vector.x = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v535 @ X0_v8 (UnityEngine.Vector3[])+24]");
						vector.y = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v535 @ X0_v8 (UnityEngine.Vector3[])+28]");
						vector.z = 0f;
						Vector3 vector2 = default(Vector3);
						vector2.x = (float)obj15;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v787 @ X10_v12+4]");
						vector2.y = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v787 @ X10_v12+8]");
						vector2.z = 0f;
						Vector3 vector3 = vector - vector2;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158AD58 (inside UnityEngine.Vector3::ClampMagnitude +0xDC)");
						ControlPoint[] controlPoints4 = p.controlPoints;
						Vector3 vector4 = default(Vector3);
						vector4.x = (float)obj15;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v787 @ X10_v12+4]");
						vector4.y = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v787 @ X10_v12+8]");
						vector4.z = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ X9_v17+C]");
						Vector3 vector5 = default(Vector3);
						vector5.x = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ X8_v26 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+28]");
						vector5.y = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ X8_v26 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+28]");
						vector5.z = 0f;
						Vector3 vector6 = vector4 - vector5;
						Vector3 vector7 = Vector3.ClampMagnitude(vector6, vector3.x);
						Vector3 vector8 = default(Vector3);
						vector8.x = (float)obj15;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v787 @ X10_v12+4]");
						vector8.y = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v787 @ X10_v12+8]");
						vector8.z = 0f;
						Vector3 vector9 = vector8 + vector7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v535 @ X0_v8 (UnityEngine.Vector3[])+20]");
						Vector3 vector10 = default(Vector3);
						vector10.x = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v535 @ X0_v8 (UnityEngine.Vector3[])+24]");
						vector10.y = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v535 @ X0_v8 (UnityEngine.Vector3[])+28]");
						vector10.z = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1-34]");
						Vector3 vector11 = default(Vector3);
						vector11.x = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ X8_v26 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+28]");
						vector11.y = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1-38]");
						vector11.z = 0f;
						Vector3 vector12 = vector10 - vector11;
						Vector3 vector13 = Vector3.ClampMagnitude(vector12, vector3.x);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v535 @ X0_v8 (UnityEngine.Vector3[])+20]");
						Vector3 vector14 = default(Vector3);
						vector14.x = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v535 @ X0_v8 (UnityEngine.Vector3[])+24]");
						vector14.y = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v535 @ X0_v8 (UnityEngine.Vector3[])+28]");
						vector14.z = 0f;
						Vector3 b = vector14 + vector13;
						if (controlPoints4.Length != 0)
						{
							int num26 = controlPoints4.Length << 32;
							object obj19 = -4294967296L + num26;
							int num27 = (int)((long)(IntPtr)obj19 >> 32);
							int num28 = num27 * 24;
							object obj20 = (long)(IntPtr)controlPoints4 + (long)num28;
							controlPoints4[num27].a.y = vector9.y;
							controlPoints4[num27].a.z = vector9.z;
							controlPoints4[num27].b = b;
							controlPoints4[num27].b.y = b.y;
							controlPoints4[num27].b.z = b.z;
							goto IL_0ac8;
						}
					}
				}
				goto IL_0a3c;
			}
			goto IL_0ac8;
			IL_0ac8:
			SetTimeToLengthTables(p, p.subdivisions = (int)((long)p.subdivisionsXSegment * (long)(IntPtr)obj4));
			SetWaypointsLengths(p, p.subdivisionsXSegment);
		}

		[Token(Token = "0x6000241")]
		[Address(RVA = "0x1081BCC", Offset = "0x1081BCC", Length = "0x288")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv42 = *([1EFEB90]);\n\tv43 = *([v42 @ X8_v16]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, wps, p, controlPoints, methodInfo, v47, v48, v49, perc, v50, v51, v52, v53, v54, v55, v56);\n\tv60 = 0 | 1;\n\t*([2026A4C]) = v60;\nL_0027:\n\tv68 = wps.Length - 1;\n\tgoto L_0032;\n\tv140 = *([v64 @ X0_v5+E0]);\n\tv141 = v140 == 0;\n\tv142 = ~v141;\n\tif (v142) goto L_0032;\n\tv144 = \"il2cpp_codegen_runtime_class_init\"(v64, wps, p, controlPoints, methodInfo, v47, v48, v49, perc, v50, v51, v52, v53, v54, v55, v56);\n\tv146 = *([v34 @ X19_v1 (UnityEngine.Vector3[])+18]);\nL_0032:\n\tv85 = v68 * perc;\n\tv122 = wps.Length - 2;\n\tv151 = v122 - v85;\n\tv152 = v151 < 0;\n\tv153 = v151 == 0;\n\tv154 = v122 ^ v85;\n\tv155 = v122 ^ v151;\n\tv156 = v154 & v155;\n\tv157 = v156 < 0;\n\tv158 = v152 == v157;\n\tv75 = ~v153;\n\tv78 = v158 & v75;\n\tv72 = ~v78;\n\tif (v72) goto L_0047;\n\tgoto L_0047;\nL_0047:\n\tv291 = v122 < wps.Length;\n\tv116 = ~v291;\n\tif (v116) goto L_0101;\n\tv304 = v122 < controlPoints.Length;\n\tv299 = ~v304;\n\tif (v299) goto L_0101;\n\tv301 = v122 + 1;\n\tv305 = v301 < wps.Length;\n\tv266 = ~v305;\n\tif (v266) goto L_0101;\n\tv309 = v122 * 0x18;\n\tv310 = controlPoints + v309;\n\tv312 = v122 * 0xC;\n\tv274 = wps + v312;\n\tv314 = v301 * 0xC;\n\tv270 = wps + v314;\n\tv316 = v85 - v122;\n\tv324 = v316 * v316;\n\tv333 = 1f - v316;\n\tv334 = v333 * v333;\n\tv335 = v316 * v324;\n\tgoto L_009C;\n\tv338 = *([v321 @ X0_v9+E0]);\n\tv339 = v338 == 0;\n\tv340 = ~v339;\n\tif (v340) goto L_009C;\n\tv342 = \"il2cpp_codegen_runtime_class_init\"(v321, wps, p, controlPoints, methodInfo, v47, v48, v49, v335, v306, v51, v52, v53, v54, v55, v56);\nL_009C:\n\tv343 = v333 * v334;\n\t// 161 MakeStruct v200 @ AGG1081D4C_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v274 @ X9_v7 (System.Single)+20], wps[v122 @ X10_v3 (System.Single)].y (System.Single), wps[v122 @ X10_v3 (System.Single)].z (System.Single)\n\tv348 = UnityEngine.Vector3::op_Multiply(v343, v200);\n\tv356 = v334 * 3f;\n\tv358 = v316 * v356;\n\t// 175 MakeStruct v197 @ AGG1081D74_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v310 @ X8_v9 (System.Single)+20], controlPoints[v122 @ X10_v3 (System.Single)].a.y (System.Single), controlPoints[v122 @ X10_v3 (System.Single)].a.z (System.Single)\n\tv361 = UnityEngine.Vector3::op_Multiply(v358, v197);\n\tv371 = UnityEngine.Vector3::op_Addition(v348, v361);\n\tv381 = v333 * 3f;\n\tv382 = v324 * v381;\n\t// 201 MakeStruct v184 @ AGG1081DBC_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), controlPoints[v122 @ X10_v3 (System.Single)].b (UnityEngine.Vector3), controlPoints[v122 @ X10_v3 (System.Single)].b.y (System.Single), controlPoints[v122 @ X10_v3 (System.Single)].b.z (System.Single)\n\tv384 = UnityEngine.Vector3::op_Multiply(v382, v184);\n\tv394 = UnityEngine.Vector3::op_Addition(v371, v384);\n\t// 225 MakeStruct v175 @ AGG1081DF8_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v270 @ X10_v6 (System.Single)+20], wps[v301 @ X11_v4 (System.Single)].y (System.Single), wps[v301 @ X11_v4 (System.Single)].z (System.Single)\n\tv405 = UnityEngine.Vector3::op_Multiply(v335, v175);\n\treturnVal2 = UnityEngine.Vector3::op_Addition(v394, v405);\n\treturn returnVal2;\nL_0101:\n\tv303 = new System.IndexOutOfRangeException();\n\tthrow v303;\n\tthrow System.NullReferenceException;\n// 188 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal override Vector3 GetPoint(float perc, Vector3[] wps, Path p, ControlPoint[] controlPoints)
		{
			//IL_0015: Expected O, but got I4
			//IL_03cb: Expected O, but got F4
			//IL_03d8: Expected O, but got F4
			//IL_015f: Expected F4, but got I
			//IL_01da: Expected F4, but got I
			//IL_02fc: Expected F4, but got I
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
			if (flag4 && flag5)
			{
				num2 = num;
			}
			if (num2 < (float)wps.Length && num2 < (float)controlPoints.Length)
			{
				float num5 = num2 + float.Epsilon;
				if (num5 < (float)wps.Length)
				{
					float num6 = num2 * 3.4E-44f;
					float num7 = (float)controlPoints + num6;
					float num8 = num2 * 1.7E-44f;
					float num9 = (float)wps + num8;
					float num10 = num5 * 1.7E-44f;
					float num11 = (float)wps + num10;
					float num12 = num - num2;
					float num13 = num12 * num12;
					float num14 = 1f - num12;
					float num15 = num14 * num14;
					float num16 = num12 * num13;
					float num17 = num14 * num15;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ X9_v7 (System.Single)+20]");
					Vector3 vector = default(Vector3);
					vector.x = 0f;
					vector.y = wps[num2].y;
					vector.z = wps[num2].z;
					Vector3 vector2 = num17 * vector;
					float num18 = num15 * 3f;
					float num19 = num12 * num18;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ X8_v9 (System.Single)+20]");
					Vector3 vector3 = default(Vector3);
					vector3.x = 0f;
					vector3.y = controlPoints[num2].a.y;
					vector3.z = controlPoints[num2].a.z;
					Vector3 vector4 = num19 * vector3;
					Vector3 vector5 = vector2 + vector4;
					float num20 = num14 * 3f;
					float num21 = num13 * num20;
					Vector3 vector6 = default(Vector3);
					vector6.x = controlPoints[num2].b.x;
					vector6.y = controlPoints[num2].b.y;
					vector6.z = controlPoints[num2].b.z;
					Vector3 vector7 = num21 * vector6;
					Vector3 vector8 = vector5 + vector7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ X10_v6 (System.Single)+20]");
					Vector3 vector9 = default(Vector3);
					vector9.x = 0f;
					vector9.y = wps[num5].y;
					vector9.z = wps[num5].z;
					Vector3 vector10 = num16 * vector9;
					return vector8 + vector10;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000242")]
		[Address(RVA = "0x10816AC", Offset = "0x10816AC", Length = "0x1F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv50 = *([1F08208]);\n\tv51 = *([v50 @ X8_v18]);\n\tv52 = \"il2cpp_codegen_initialize_method\"(v51, p, subdivisions, methodInfo, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65);\n\tv68 = 0 | 1;\n\t*([2026A4D]) = v68;\nL_0027:\n\t// 39 NewArr v73 @ X0_v3 (System.Single[]), typeof(System.Single[]), subdivisions @ X2 (System.Int32)\n\t// 44 NewArr v78 @ X0_v5 (System.Single[]), typeof(System.Single[]), subdivisions @ X2 (System.Int32)\n\tv90 = DG.Tweening.Plugins.Core.PathCore.CubicBezierDecoder::GetPoint(this, 0f, p.wps, p, p.controlPoints);\n\tv91 = subdivisions + 1;\n\tv105 = v91 < 2;\n\tif (v105) goto L_00A6;\n\tv210 = 1f / subdivisions;\nL_0057:\n\tv115 = v131 - 7;\n\tv107 = v210 * v115;\n\tv359 = DG.Tweening.Plugins.Core.PathCore.CubicBezierDecoder::GetPoint(this, v107, p.wps, p, p.controlPoints);\n\tgoto L_0074;\n\tv411 = *([v360 @ X0_v18+E0]);\n\tv412 = v411 == 0;\n\tv413 = ~v412;\n\tgoto L_0074;\n\tv415 = \"il2cpp_codegen_runtime_class_init\"(v360, v195, v183, v193, v185, v55, v56, v57, v358, v355, v343, v342, v341, v340, v64, v65);\nL_0074:\n\t// 116 MakeStruct v121 @ AGG1081800_0_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v107 @ V14_v6 (System.Single), v210 @ V0_v6 (System.Single), v343 @ V2_v4\n\t// 117 MakeStruct v118 @ AGG1081800_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v179 @ V9_v6 (System.Single), v177 @ V8_v6 (System.Single), v143 @ V10_v6\n\tv191 = UnityEngine.Vector3::Distance(v121, v118);\n\tv205 = v115 - 1;\n\tv418 = v205 < v73.Length;\n\tv175 = ~v418;\n\tif (v175) goto L_00BF;\n\t*([v73 @ X0_v3 (System.Single[])+v131 @ X24_v6 (System.Int32)*4]) = v107;\n\tv419 = v205 < v78.Length;\n\tv318 = ~v419;\n\tif (v318) goto L_00BF;\n\tv254 = v181 + v191;\n\tv267 = v205 + 2;\n\t*([v78 @ X0_v5 (System.Single[])+v131 @ X24_v6 (System.Int32)*4]) = v254;\n\tv131 = v131 + 1;\n\tv231 = v267 < v91;\n\tif (v231) goto L_0057;\nL_00A6:\n\tp.length = v254;\n\tp.timesTable = v73;\n\tp.lengthsTable = v78;\n\treturn;\n\tv207 = new System.NullReferenceException();\nL_00BF:\n\tv332 = new System.IndexOutOfRangeException();\n\tthrow v332;\n\treturn;\n// 149 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000243")]
		[Address(RVA = "0x108189C", Offset = "0x108189C", Length = "0x330")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv54 = *([1EAA618]);\n\tv55 = *([v54 @ X8_v40]);\n\tv56 = \"il2cpp_codegen_initialize_method\"(v55, p, subdivisions, methodInfo, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69);\n\tv72 = 0 | 1;\n\t*([2026A4E]) = v72;\nL_0027:\n\tv74 = p.wps;\n\t// 47 NewArr v296 @ X0_v7 (System.Single[]), typeof(System.Single[]), v74.Length\n\tv349 = v296.Length == 0;\n\tif (v349) goto L_0154;\n\tv296[0] = 0;\n\tv468 = v74.Length < 2;\n\tif (v468) goto L_013D;\n\tv526 = subdivisions + 1;\n\tv181 = 1f / subdivisions;\nL_0053:\n\tgoto L_005A;\n\tv566 = *([v562 @ X0_v13 (Il2CppClass<DG.Tweening.Plugins.Core.PathCore.CubicBezierDecoder>)+E0]);\n\tv567 = v566 == 0;\n\tv568 = ~v567;\n\tgoto L_005A;\n\tv571 = \"il2cpp_codegen_runtime_class_init\"(v562, v268, v132, v126, v123, v59, v60, v61, v195, v190, v108, v105, v102, v99, v68, v69);\n\tv569 = DG.Tweening.Plugins.Core.PathCore.CubicBezierDecoder;\nL_005A:\n\tv160 = p.controlPoints;\n\tv285 = v187 - 1;\n\tv572 = v285 < v160.Length;\n\tv262 = ~v572;\n\tif (v262) goto L_0154;\n\tv574 = v285 * 0x18;\n\tv169 = v160 + v574;\n\tv156 = v175._PartialControlPs;\n\tv521 = v156.Length == 0;\n\tif (v521) goto L_0154;\n\t*([v156 @ X9_v7 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+30]) = v160[v285 @ X8_v15 (System.Int32)].b.y;\n\t*([v156 @ X9_v7 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[])+20]) = *([v169 @ X11_v7+20]);\n\tv157 = p.wps;\n\tv576 = v285 < v157.Length;\n\tv263 = ~v576;\n\tif (v263) goto L_0154;\n\tv177 = v578._PartialWps;\n\tv522 = v177.Length == 0;\n\tif (v522) goto L_0154;\n\tv579 = v285 * 0xC;\n\tv580 = v157 + v579;\n\t*([v177 @ X10_v14 (UnityEngine.Vector3[])+20]) = *([v580 @ X8_v16+20]);\n\t*([v177 @ X10_v14 (UnityEngine.Vector3[])+24]) = v157[v285 @ X8_v15 (System.Int32)].y;\n\t*([v177 @ X10_v14 (UnityEngine.Vector3[])+28]) = v157[v285 @ X8_v15 (System.Int32)].z;\n\tv286 = p.wps;\n\tv582 = v187 < v286.Length;\n\tv264 = ~v582;\n\tif (v264) goto L_0154;\n\tv159 = v584._PartialWps;\n\tv585 = v159.Length < 1;\n\tv515 = ~v585;\n\tv513 = v159.Length - 1;\n\tv509 = v513 == 0;\n\tv586 = ~v515;\n\tv499 = v586 | v509;\n\tif (v499) goto L_0154;\n\tv587 = v187 * 0xC;\n\tv588 = v286 + v587;\n\t*([v159 @ X9_v13 (UnityEngine.Vector3[])+2C]) = *([v588 @ X8_v19+20]);\n\t*([v159 @ X9_v13 (UnityEngine.Vector3[])+30]) = v286[v187 @ X25_v7 (System.Int32)].y;\n\t*([v159 @ X9_v13 (UnityEngine.Vector3[])+34]) = v286[v187 @ X25_v7 (System.Int32)].z;\n\tv601 = DG.Tweening.Plugins.Core.PathCore.CubicBezierDecoder::GetPoint(this, 0f, v596._PartialWps, p, v596._PartialControlPs);\n\tv616 = v526 < 2;\n\tif (v616) goto L_0123;\nL_00E4:\n\tv696 = v671 + 1;\n\tv699 = v181 * v696;\n\tgoto L_00FD;\n\tv704 = *([v695 @ X0_v19 (Il2CppClass<DG.Tweening.Plugins.Core.PathCore.CubicBezierDecoder>)+E0]);\n\tv705 = v704 == 0;\n\tv706 = ~v705;\n\tgoto L_00FD;\n\tv720 = \"il2cpp_codegen_runtime_class_init\"(v695, v691, v678, v676, v675, v59, v60, v61, v697, v680, v670, v669, v668, v667, v68, v69);\n\tv708 = DG.Tweening.Plugins.Core.PathCore.CubicBezierDecoder;\nL_00FD:\n\tv715 = DG.Tweening.Plugins.Core.PathCore.CubicBezierDecoder::GetPoint(this, v699, v711._PartialWps, p, v711._PartialControlPs);\n\tgoto L_0112;\n\tv721 = *([v716 @ X0_v23+E0]);\n\tv722 = v721 == 0;\n\tv723 = ~v722;\n\tgoto L_0112;\n\tv725 = \"il2cpp_codegen_runtime_class_init\"(v716, v656, v635, v633, v632, v59, v60, v61, v713, v680, v670, v669, v668, v667, v68, v69);\nL_0112:\n\t// 274 MakeStruct v623 @ AGG1081B4C_0_v8 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v699 @ V8_v10 (System.Single), 1f, v670 @ V2_v7\n\t// 275 MakeStruct v622 @ AGG1081B4C_1_v8 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v674 @ V8_v9 (System.Single), v673 @ V9_v9 (System.Single), v672 @ V10_v9\n\tv638 = UnityEngine.Vector3::Distance(v623, v622);\n\tv671 = v671 + 1;\n\tv484 = v677 + v638;\n\tv639 = subdivisions != v671;\n\tif (v639) goto L_00E4;\nL_0123:\n\tv661 = v187 < v296.Length;\n\tv516 = ~v661;\n\tif (v516) goto L_0154;\n\tv544 = v187 + 1;\n\tv296[v187 @ X25_v7 (System.Int32)] = v484;\n\tv547 = v544 < v74.Length;\n\tif (v547) goto L_0053;\nL_013D:\n\tp.wpLengths = v296;\n\treturn;\nL_0154:\n\tv525 = new System.IndexOutOfRangeException();\n\tthrow v525;\n\tthrow System.NullReferenceException;\n// 246 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void SetWaypointsLengths(Path p, int subdivisions)
		{
			//IL_00fc: Expected O, but got I
			//IL_01d2: Expected O, but got I
			//IL_027a: Expected O, but got I4
			//IL_02cb: Expected O, but got I
			//IL_039a: Expected F4, but got O
			//IL_03c1: Expected F4, but got O
			Vector3[] wps = p.wps;
			float[] array = new float[wps.Length];
			if (array.Length != 0)
			{
				array[0] = 0f;
				if (wps.Length < 2)
				{
					goto IL_049d;
				}
				int num = subdivisions + 1;
				float num2 = 1f / (float)subdivisions;
				int num3 = 1;
				object obj6 = default(object);
				Vector3 a = default(Vector3);
				Vector3 b = default(Vector3);
				while (true)
				{
					ControlPoint[] controlPoints = p.controlPoints;
					int num4 = num3 - 1;
					if (num4 >= controlPoints.Length)
					{
						break;
					}
					int num5 = num4 * 24;
					object obj = (long)(IntPtr)controlPoints + (long)num5;
					ControlPoint[] partialControlPs = _PartialControlPs;
					if (partialControlPs.Length == 0)
					{
						break;
					}
					_ = controlPoints[num4].b.y;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ X11_v7+20]");
					_ = 0;
					Vector3[] wps2 = p.wps;
					if (num4 >= wps2.Length)
					{
						break;
					}
					Vector3[] partialWps = _PartialWps;
					if (partialWps.Length == 0)
					{
						break;
					}
					int num6 = num4 * 12;
					object obj2 = (long)(IntPtr)wps2 + (long)num6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ X8_v16+20]");
					_ = 0;
					_ = wps2[num4].y;
					_ = wps2[num4].z;
					Vector3[] wps3 = p.wps;
					if (num3 >= wps3.Length)
					{
						break;
					}
					Vector3[] partialWps2 = _PartialWps;
					bool flag = partialWps2.Length < 1;
					bool flag2 = !flag;
					object obj3 = partialWps2.Length - 1;
					bool flag3 = obj3 == null;
					bool flag4 = !flag2;
					if (flag4 || flag3)
					{
						break;
					}
					int num7 = num3 * 12;
					object obj4 = (long)(IntPtr)wps3 + (long)num7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v588 @ X8_v19+20]");
					_ = 0;
					_ = wps3[num3].y;
					_ = wps3[num3].z;
					Vector3 point = GetPoint(0f, _PartialWps, p, _PartialControlPs);
					bool flag5 = num < 2;
					float num8 = 0f;
					if (!flag5)
					{
						int num9 = 0;
						object obj5 = obj6;
						float y = 1f;
						float x = 0f;
						float num10 = 0f;
						bool flag6;
						do
						{
							int num11 = num9 + 1;
							float num12 = num2 * (float)num11;
							Vector3 point2 = GetPoint(num12, _PartialWps, p, _PartialControlPs);
							a.x = num12;
							a.y = 1f;
							a.z = (float)obj6;
							b.x = x;
							b.y = y;
							b.z = (float)obj5;
							float num13 = Vector3.Distance(a, b);
							num9++;
							num8 = num10 + num13;
							flag6 = subdivisions != num9;
							obj5 = obj6;
							y = 1f;
							x = num12;
							num10 = num8;
						}
						while (flag6);
					}
					if (num3 >= array.Length)
					{
						break;
					}
					int num14 = num3 + 1;
					array[num3] = num8;
					bool flag7 = num14 < wps.Length;
					num3 = num14;
					if (!flag7)
					{
						goto IL_049d;
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_049d:
			p.wpLengths = array;
		}

		[Token(Token = "0x6000244")]
		[Address(RVA = "0x1081E54", Offset = "0x1081E54", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CubicBezierDecoder()
		{
		}

		[Token(Token = "0x6000245")]
		[Address(RVA = "0x1081E5C", Offset = "0x1081E5C", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = *([1F001E8]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2026A4F]) = v35;\nL_0015:\n\t// 21 NewArr v40 @ X0_v3 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[]), typeof(DG.Tweening.Plugins.Core.PathCore.ControlPoint[]), 1\n\tv45._PartialControlPs = v40;\n\t// 31 NewArr v49 @ X0_v5 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), 2\n\tv51._PartialWps = v49;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static CubicBezierDecoder()
		{
			ControlPoint[] partialControlPs = new ControlPoint[1];
			_PartialControlPs = partialControlPs;
			Vector3[] partialWps = new Vector3[2];
			_PartialWps = partialWps;
		}
	}
}
