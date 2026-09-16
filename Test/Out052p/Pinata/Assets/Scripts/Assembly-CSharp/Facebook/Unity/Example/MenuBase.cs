using System;
using System.Collections;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Facebook.Unity.Example
{
	[Token(Token = "0x2000058")]
	internal abstract class MenuBase : ConsoleBase
	{
		[Token(Token = "0x400026F")]
		private static ShareDialogMode shareDialogMode;

		[Token(Token = "0x6000279")]
		protected abstract void GetGui();

		[Token(Token = "0x600027A")]
		[Address(RVA = "0xA0A704", Offset = "0xA0A704", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual bool ShowDialogModeSelector()
		{
			return false;
		}

		[Token(Token = "0x600027B")]
		[Address(RVA = "0xA0A70C", Offset = "0xA0A70C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual bool ShowBackButton()
		{
			return true;
		}

		[Token(Token = "0x600027C")]
		[Address(RVA = "0xA08D80", Offset = "0xA08D80", Length = "0x3AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EFD608]);\n\tv23 = *([v22 @ X8_v60]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, result, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021CB9]) = v41;\nL_0015:\n\tv42 = v146 == 0;\n\tif (v42) goto L_0042;\n\tthis.<LastResponseTexture>k__BackingField = 0;\n\tgoto L_0055;\n\tv58 = *([v44 @ X8_v11+B0]);\n\tv59 = 0;\n\tv60 = v58 + 8;\n\tv62 = *([v186 @ X11_v39-8]);\n\tv191 = v62 == v47;\n\tif (v191) goto L_004E;\n\tv92 = v185 + 1;\n\tv196 = v92 < v46;\n\tv89 = ~v196;\n\tv95 = v186 + 0x10;\n\tv65 = ~v89;\n\tif (v65) goto L_FFFFFFFF;\n\tv97 = v14;\n\tv98 = 0;\n\tv99 = 0x8909C4(v97, v47, v98, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0055;\nL_0042:\n\tthis.lastResponse = \"Null Response\\n\";\n\tgoto L_017B;\n\tgoto L_017B;\n\tgoto L_FFFFFFFF;\nL_004E:\n\tv197 = *([v186 @ X11_v39]);\n\tv198 = v197 << 4;\n\tv199 = v44 + v198;\n\tv200 = v199 + 0x130;\nL_0055:\n\tv221 = Facebook.Unity.IResult::get_Error(v146);\n\tv223 = System.String::IsNullOrEmpty(v221);\n\tv227 = v223 == 0;\n\tif (v227) goto L_0082;\n\tv228 = *([v146 @ X1_v2 (Facebook.Unity.IResult)]);\n\tv231 = *([v228 @ X8_v30 (Il2CppClass<Facebook.Unity.IResult>)+126]) == 0;\n\tif (v231) goto L_007D;\n\tv310 = *([v228 @ X8_v30 (Il2CppClass<Facebook.Unity.IResult>)+B0]) + 8;\nL_0068:\n\tv315 = *([v310 @ X11_v34-8]) == Facebook.Unity.IResult;\n\tif (v315) goto L_00A8;\n\tv309 = v309 + 1;\n\tv341 = v309 < *([v228 @ X8_v30 (Il2CppClass<Facebook.Unity.IResult>)+126]);\n\tv261 = ~v341;\n\tv310 = v310 + 0x10;\n\tv245 = ~v261;\n\tif (v245) goto L_0068;\nL_007D:\n\tv362 = 0x8909C4(v146, Facebook.Unity.IResult, 3, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_00AF;\nL_0082:\n\tthis.status = \"Error - Check log for details\";\n\tgoto L_0106;\n\tv269 = *([v235 @ X8_v24+B0]);\n\tv270 = 0;\n\tv271 = v269 + 8;\n\tv273 = *([v331 @ X11_v10-8]);\n\tv336 = v273 == v236;\n\tif (v336) goto L_00FF;\n\tv293 = v330 + 1;\n\tv370 = v293 < v237;\n\tv291 = ~v370;\n\tv295 = v331 + 0x10;\n\tv275 = ~v291;\n\tif (v275) goto L_FFFFFFFF;\n\tv296 = v14;\n\tv297 = 0;\n\tv298 = 0x8909C4(v296, v236, v297, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0106;\nL_00A8:\n\tv343 = *([v310 @ X11_v34]) + 3;\n\tv344 = v343 << 4;\n\tv345 = v228 + v344;\n\tv362 = v345 + 0x130;\nL_00AF:\n\t*([v362 @ X0_v24])(v367, v146, *([v362 @ X0_v24+8]), v416, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv368 = v367 & 1;\n\tv369 = v368 == 0;\n\tif (v369) goto L_00DB;\n\tthis.status = \"Cancelled - Check log for details\";\n\tv401 = *([v146 @ X1_v2 (Facebook.Unity.IResult)]);\n\tv404 = *([v401 @ X8_v51 (Il2CppClass<Facebook.Unity.IResult>)+126]) == 0;\n\tif (v404) goto L_00D9;\n\tv571 = *([v401 @ X8_v51 (Il2CppClass<Facebook.Unity.IResult>)+B0]) + 8;\nL_00C4:\n\tv576 = *([v571 @ X11_v29-8]) == Facebook.Unity.IResult;\n\tif (v576) goto L_010B;\n\tv570 = v570 + 1;\n\tv603 = v570 < *([v401 @ X8_v51 (Il2CppClass<Facebook.Unity.IResult>)+126]);\n\tv492 = ~v603;\n\tv571 = v571 + 0x10;\n\tv476 = ~v492;\n\tif (v476) goto L_00C4;\nL_00D9:\n\tv609 = 0x8909C4(v146, Facebook.Unity.IResult, 2, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0112;\nL_00DB:\n\tv405 = *([v146 @ X1_v2 (Facebook.Unity.IResult)]);\n\tv408 = *([v405 @ X8_v33 (Il2CppClass<Facebook.Unity.IResult>)+126]) == 0;\n\tif (v408) goto L_00FD;\n\tv592 = *([v405 @ X8_v33 (Il2CppClass<Facebook.Unity.IResult>)+B0]) + 8;\nL_00E8:\n\tv597 = *([v592 @ X11_v23-8]) == Facebook.Unity.IResult;\n\tif (v597) goto L_0117;\n\tv591 = v591 + 1;\n\tv614 = v591 < *([v405 @ X8_v33 (Il2CppClass<Facebook.Unity.IResult>)+126]);\n\tv522 = ~v614;\n\tv592 = v592 + 0x10;\n\tv506 = ~v522;\n\tif (v506) goto L_00E8;\nL_00FD:\n\tv620 = 0x8909C4(v146, Facebook.Unity.IResult, 2, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_011E;\nL_00FF:\n\tv371 = *([v331 @ X11_v10]);\n\tv372 = v371 << 4;\n\tv373 = v235 + v372;\n\tv374 = v373 + 0x130;\nL_0106:\n\tv457 = Facebook.Unity.IResult::get_Error(v146);\n\tgoto L_015F;\nL_010B:\n\tv605 = *([v571 @ X11_v29]) + 2;\n\tv606 = v605 << 4;\n\tv607 = v401 + v606;\n\tv609 = v607 + 0x130;\nL_0112:\n\t*([v609 @ X0_v41])(v457, v146, *([v609 @ X0_v41+8]), v416, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_015F;\nL_0117:\n\tv616 = *([v592 @ X11_v23]) + 2;\n\tv617 = v616 << 4;\n\tv618 = v405 + v617;\n\tv620 = v618 + 0x130;\nL_011E:\n\t*([v620 @ X0_v27])(v625, v146, *([v620 @ X0_v27+8]), v416, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv626 = System.String::IsNullOrEmpty(v625);\n\tv551 = v626 == 0;\n\tif (v551) goto L_012B;\n\tgoto L_0160;\nL_012B:\n\tthis.status = \"Success - Check log for details\";\n\tv632 = *([v146 @ X1_v2 (Facebook.Unity.IResult)]);\n\tv461 = *([v632 @ X8_v39 (Il2CppClass<Facebook.Unity.IResult>)+126]) == 0;\n\tif (v461) goto L_014E;\n\tv676 = *([v632 @ X8_v39 (Il2CppClass<Facebook.Unity.IResult>)+B0]) + 8;\nL_0139:\n\tv681 = *([v676 @ X11_v18-8]) == Facebook.Unity.IResult;\n\tif (v681) goto L_0151;\n\tv675 = v675 + 1;\n\tv686 = v675 < *([v632 @ X8_v39 (Il2CppClass<Facebook.Unity.IResult>)+126]);\n\tv657 = ~v686;\n\tv676 = v676 + 0x10;\n\tv641 = ~v657;\n\tif (v641) goto L_0139;\nL_014E:\n\tv692 = 0x8909C4(v146, Facebook.Unity.IResult, 2, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0158;\nL_0151:\n\tv688 = *([v676 @ X11_v18]) + 2;\n\tv689 = v688 << 4;\n\tv690 = v632 + v689;\n\tv692 = v690 + 0x130;\nL_0158:\n\t*([v692 @ X0_v31])(v457, v146, *([v692 @ X0_v31+8]), v416, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_015F:\n\tv548 = System.String::Concat(*([v462 @ X8_v14 (System.String)]), v457);\nL_0160:\n\tthis.lastResponse = v548;\n\tv554 = *([v146 @ X1_v2 (Facebook.Unity.IResult)]);\n\t*([v554 @ X8_v17 (Il2CppClass<Facebook.Unity.IResult>)+160])(v156, v146, *([v554 @ X8_v17 (Il2CppClass<Facebook.Unity.IResult>)+168]), v416, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_017B;\n\tgoto L_017B;\nL_017B:\n\tFacebook.Unity.Example.LogView::AddLog(v161);\n\treturn;\n// 225 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal void HandleResult(IResult result)
		{
			//IL_0056: Expected I, but got O
			//IL_0499: Expected I, but got O
			//IL_04b3: Expected O, but got I
			//IL_0091: Expected O, but got I
			//IL_0239: Expected I, but got O
			//IL_0179: Expected I, but got O
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_012c: Expected O, but got Unknown
			//IL_0149: Expected O, but got I
			//IL_0158: Expected O, but got I
			//IL_0274: Expected O, but got I
			//IL_00dd: Expected O, but got I
			//IL_0390: Expected I, but got O
			//IL_01b4: Expected O, but got I
			//IL_0339: Unknown result type (might be due to invalid IL or missing references)
			//IL_033e: Expected O, but got Unknown
			//IL_035b: Expected O, but got I
			//IL_036a: Expected O, but got I
			//IL_03cb: Expected O, but got I
			//IL_02c0: Expected O, but got I
			//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ff: Expected O, but got Unknown
			//IL_031c: Expected O, but got I
			//IL_032b: Expected O, but got I
			//IL_0200: Expected O, but got I
			//IL_0451: Unknown result type (might be due to invalid IL or missing references)
			//IL_0456: Expected O, but got Unknown
			//IL_0473: Expected O, but got I
			//IL_0482: Expected O, but got I
			//IL_0417: Expected O, but got I
			string error2 = default(string);
			string text;
			IResult result2 = default(IResult);
			int num4;
			if (result2 != null)
			{
				LastResponseTexture = null;
				string error = result2.Error;
				if (string.IsNullOrEmpty(error))
				{
					IntPtr intPtr = (IntPtr)result2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ X8_v30 (Il2CppClass<Facebook.Unity.IResult>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_00f6;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ X8_v30 (Il2CppClass<Facebook.Unity.IResult>)+B0]");
					object obj = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ X11_v34-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IResult))
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ X8_v30 (Il2CppClass<Facebook.Unity.IResult>)+126]");
						bool flag = (long)num2 < 0L;
						bool flag2 = !flag;
						obj = (long)(IntPtr)obj + 16L;
						if (!flag2)
						{
							continue;
						}
						goto IL_00f6;
					}
					object obj2 = obj + 3;
					int num3 = (int)((long)(IntPtr)obj2 << 4);
					object obj3 = (long)intPtr + (long)num3;
					object obj4 = (long)(IntPtr)obj3 + 304L;
					num4 = 0;
					goto IL_0587;
				}
				status = "Error - Check log for details";
				error2 = result2.Error;
				text = "Error Response:\n";
				goto IL_06ba;
			}
			lastResponse = "Null Response\n";
			string log = "Null Response\n";
			goto IL_04ea;
			IL_0219:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			num4 = 2;
			goto IL_0602;
			IL_06a2:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v692 @ X0_v31] (should have been resolved before IL gen)");
			text = "Success Response:\n";
			goto IL_06ba;
			IL_0487:
			string text2;
			lastResponse = text2;
			IntPtr intPtr2 = (IntPtr)result2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v554 @ X8_v17 (Il2CppClass<Facebook.Unity.IResult>)+160] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v554 @ X8_v17 (Il2CppClass<Facebook.Unity.IResult>)+168]");
			result2 = (IResult)0;
			string text3 = default(string);
			log = text3;
			goto IL_04ea;
			IL_0430:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			num4 = 2;
			goto IL_06a2;
			IL_02d9:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			num4 = 2;
			goto IL_0644;
			IL_0644:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v620 @ X0_v27] (should have been resolved before IL gen)");
			string value = default(string);
			if (string.IsNullOrEmpty(value))
			{
				text2 = "Empty Response\n";
				goto IL_0487;
			}
			status = "Success - Check log for details";
			IntPtr intPtr3 = (IntPtr)result2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v632 @ X8_v39 (Il2CppClass<Facebook.Unity.IResult>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0430;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v632 @ X8_v39 (Il2CppClass<Facebook.Unity.IResult>)+B0]");
			object obj5 = 0L + 8L;
			int num5 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v676 @ X11_v18-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IResult))
				{
					break;
				}
				num5++;
				int num6 = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v632 @ X8_v39 (Il2CppClass<Facebook.Unity.IResult>)+126]");
				bool flag3 = (long)num6 < 0L;
				bool flag4 = !flag3;
				obj5 = (long)(IntPtr)obj5 + 16L;
				if (!flag4)
				{
					continue;
				}
				goto IL_0430;
			}
			object obj6 = obj5 + 2;
			int num7 = (int)((long)(IntPtr)obj6 << 4);
			object obj7 = (long)intPtr3 + (long)num7;
			object obj8 = (long)(IntPtr)obj7 + 304L;
			goto IL_06a2;
			IL_04ea:
			LogView.AddLog(log);
			return;
			IL_0602:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v609 @ X0_v41] (should have been resolved before IL gen)");
			text = "Cancelled Response:\n";
			goto IL_06ba;
			IL_00f6:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			num4 = 3;
			goto IL_0587;
			IL_0587:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v362 @ X0_v24] (should have been resolved before IL gen)");
			object obj9 = default(object);
			if ((uint)((ulong)(long)(IntPtr)obj9 & 1uL) != 0)
			{
				status = "Cancelled - Check log for details";
				IntPtr intPtr4 = (IntPtr)result2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ X8_v51 (Il2CppClass<Facebook.Unity.IResult>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0219;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ X8_v51 (Il2CppClass<Facebook.Unity.IResult>)+B0]");
				object obj10 = 0L + 8L;
				int num8 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v571 @ X11_v29-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IResult))
					{
						break;
					}
					num8++;
					int num9 = num8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ X8_v51 (Il2CppClass<Facebook.Unity.IResult>)+126]");
					bool flag5 = (long)num9 < 0L;
					bool flag6 = !flag5;
					obj10 = (long)(IntPtr)obj10 + 16L;
					if (!flag6)
					{
						continue;
					}
					goto IL_0219;
				}
				object obj11 = obj10 + 2;
				int num10 = (int)((long)(IntPtr)obj11 << 4);
				object obj12 = (long)intPtr4 + (long)num10;
				object obj13 = (long)(IntPtr)obj12 + 304L;
				goto IL_0602;
			}
			IntPtr intPtr5 = (IntPtr)result2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ X8_v33 (Il2CppClass<Facebook.Unity.IResult>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_02d9;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ X8_v33 (Il2CppClass<Facebook.Unity.IResult>)+B0]");
			object obj14 = 0L + 8L;
			int num11 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ X11_v23-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IResult))
				{
					break;
				}
				num11++;
				int num12 = num11;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ X8_v33 (Il2CppClass<Facebook.Unity.IResult>)+126]");
				bool flag7 = (long)num12 < 0L;
				bool flag8 = !flag7;
				obj14 = (long)(IntPtr)obj14 + 16L;
				if (!flag8)
				{
					continue;
				}
				goto IL_02d9;
			}
			object obj15 = obj14 + 2;
			int num13 = (int)((long)(IntPtr)obj15 << 4);
			object obj16 = (long)intPtr5 + (long)num13;
			object obj17 = (long)(IntPtr)obj16 + 304L;
			goto IL_0644;
			IL_06ba:
			text2 = text + error2;
			num4 = 0;
			goto IL_0487;
		}

		[Token(Token = "0x600027D")]
		[Address(RVA = "0xA0A714", Offset = "0xA0A714", Length = "0x61C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1ED9F50]);\n\tv31 = *([v30 @ X8_v97]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2021CBA]) = v50;\nL_001C:\n\tv55 = 0x6D26F0(&v52 @ stack_-98, 0, 0x44, v35, v36, v37, v38, v39, v527, v41, v42, v43, v44, v45, v46, v47);\n\tv57 = UnityEngine.Screen::get_orientation();\n\tv67 = v57 != 3;\n\tif (v67) goto L_0094;\n\tv72 = Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>;\n\tgoto L_0037;\n\tv93 = v72;\n\tv94 = 0x8907BC(v93, v54, v53, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv97 = *([v72 @ X20_v27 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]);\nL_0037:\n\tv98 = *([v72 @ X20_v27 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]) & 0x200;\n\tv99 = v98 == 0;\n\tif (v99) goto L_0058;\n\tv102 = Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>;\n\tgoto L_0044;\n\tv132 = v102;\n\tv133 = 0x8907BC(v132, v54, v53, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0044:\n\tv134 = *([v102 @ X20_v35 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]) == 0;\n\tv112 = ~v134;\n\tif (v112) goto L_0058;\n\tgoto L_0058;\n\tv353 = v117;\n\tv354 = 0x8907BC(v353, v54, v53, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0058:\n\tgoto L_005E;\n\tv135 = v119;\n\tv136 = 0x8907BC(v135, v54, v53, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_005E:\n\tUnityEngine.GUILayout::BeginHorizontal(v138.Value);\n\tv277 = Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>;\n\tgoto L_006A;\n\tv357 = v277;\n\tv358 = 0x8907BC(v357, v139, v53, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv361 = *([v277 @ X20_v30 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]);\nL_006A:\n\tv362 = *([v277 @ X20_v30 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]) & 0x200;\n\tv363 = v362 == 0;\n\tif (v363) goto L_008B;\n\tv388 = Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>;\n\tgoto L_0077;\n\tv489 = v388;\n\tv490 = 0x8907BC(v489, v139, v53, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0077:\n\tv491 = *([v388 @ X20_v33 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]) == 0;\n\tv398 = ~v491;\n\tif (v398) goto L_008B;\n\tgoto L_008B;\n\tv508 = v403;\n\tv509 = 0x8907BC(v508, v139, v53, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_008B:\n\tgoto L_0091;\n\tv492 = v89;\n\tv493 = 0x8907BC(v492, v139, v53, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0091:\n\tUnityEngine.GUILayout::BeginVertical(v87.Value);\nL_0094:\n\tv92 = System.Object::GetType(this);\n\tv127 = System.Reflection.MemberInfo::get_Name(v92);\n\tv130 = Facebook.Unity.Example.ConsoleBase::get_LabelStyle(this);\n\tv146 = Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>;\n\tgoto L_00AC;\n\tv282 = v146;\n\tv283 = 0x8907BC(v282, v126, v53, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv286 = *([v146 @ X22_v4 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]);\nL_00AC:\n\tv287 = *([v146 @ X22_v4 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]) & 0x200;\n\tv288 = v287 == 0;\n\tif (v288) goto L_00CD;\n\tv365 = Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>;\n\tgoto L_00B9;\n\tv408 = v365;\n\tv409 = 0x8907BC(v408, v126, v53, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_00B9:\n\tv410 = *([v365 @ X22_v14 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]) == 0;\n\tv377 = ~v410;\n\tif (v377) goto L_00CD;\n\tgoto L_00CD;\n\tv502 = v371;\n\tv503 = 0x8907BC(v502, v126, v53, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_00CD:\n\tgoto L_00D4;\n\tv411 = v382;\n\tv412 = 0x8907BC(v411, v126, v53, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_00D4:\n\t;\n\tUnityEngine.GUILayout::Label(v127, v130, v414.Value);\n\tFacebook.Unity.Example.MenuBase::AddStatus(this);\n\tv507 = UnityEngine.Input::get_touchCount();\n\tv522 = v507 < 1;\n\tif (v522) goto L_0134;\n\tv523 = &v563 @ stack_-E0_v5 (System.Int32);\n\tv526 = UnityEngine.Input::GetTouch(0);\n\tv563 = *([v523 @ X8_v61]);\n\tv592 = 0x6D2410(&v52 @ stack_-98, &v563 @ stack_-E0_v5 (System.Int32), 0x44, 0, v36, v37, v38, v39, v527, v41, v42, v43, v44, v45, v46, v47);\n\tv581 = 0x16717C4(&v52 @ stack_-98, 0, 0x44, 0, v36, v37, v38, v39, v527, v41, v42, v43, v44, v45, v46, v47);\n\tv570 = v581 != 1;\n\tif (v570) goto L_0134;\n\tv613 = UnityEngine.Input::GetTouch(0);\n\tv563 = v613.m_FingerId;\n\tv619 = 0x6D2410(&v52 @ stack_-98, &v563 @ stack_-E0_v5 (System.Int32), 0x44, 0, v36, v37, v38, v39, v527, v41, v42, v43, v44, v45, v46, v47);\n\tv580 = 0x16717AC(&v52 @ stack_-98, 0, 0x44, 0, v36, v37, v38, v39, v527, v41, v42, v43, v44, v45, v46, v47);\n\tv527 = this.scrollPosition.y + v41;\n\tthis.scrollPosition.x = this.scrollPosition;\n\tthis.scrollPosition.y = v527;\nL_0134:\n\t// 308 NewArr v589 @ X0_v26 (UnityEngine.GUILayoutOption[]), typeof(UnityEngine.GUILayoutOption[]), 1\n\tgoto L_0144;\n\tv599 = *([v594 @ X8_v15+E0]);\n\tv600 = v599 == 0;\n\tv601 = ~v600;\n\tgoto L_0144;\n\tv608 = v594;\n\tv603 = \"il2cpp_codegen_runtime_class_init\"(v608, v587, v218, v220, v36, v37, v38, v39, v527, v41, v42, v43, v44, v45, v46, v47);\nL_0144:\n\tv606 = Facebook.Unity.Constants::get_IsMobile();\n\tv610 = v606 == 0;\n\tif (v610) goto L_FFFFFFFF;\n\tv620 = UnityEngine.Screen::get_width();\n\tgoto L_014E;\nL_014E:\n\tv622 = UnityEngine.GUILayout::MinWidth(v620);\n\tv625 = v622 == 0;\n\tif (v625) goto L_015B;\n\t// 343 IsInst v261 @ X0_v108, typeof(UnityEngine.GUILayoutOption), v622 @ X0_v32 (UnityEngine.GUILayoutOption)\nL_015B:\n\tv655 = v589.Length == 0;\n\tif (v655) goto L_024B;\n\tv589[0] = v622;\n\t// 354 MakeStruct v158 @ AGGA0AA90_0_v5 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), this.scrollPosition (UnityEngine.Vector2), this.scrollPosition.y (System.Single)\n\tv665 = UnityEngine.GUILayout::BeginScrollView(v158, v589);\n\tthis.scrollPosition = v665;\n\tthis.scrollPosition.y = v665.y;\n\tv669 = Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>;\n\tgoto L_0172;\n\tv674 = v669;\n\tv675 = 0x8907BC(v674, v664, v218, v220, v36, v37, v38, v39, v665, v666, v42, v43, v44, v45, v46, v47);\n\tv678 = *([v669 @ X20_v10 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]);\nL_0172:\n\tv679 = *([v669 @ X20_v10 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]) & 0x200;\n\tv680 = v679 == 0;\n\tif (v680) goto L_0193;\n\tv682 = Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>;\n\tgoto L_017F;\n\tv704 = v682;\n\tv705 = 0x8907BC(v704, v664, v218, v220, v36, v37, v38, v39, v665, v666, v42, v43, v44, v45, v46, v47);\nL_017F:\n\tv706 = *([v682 @ X20_v23 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]) == 0;\n\tv692 = ~v706;\n\tif (v692) goto L_0193;\n\tgoto L_0193;\n\tv723 = v697;\n\tv724 = 0x8907BC(v723, v664, v218, v220, v36, v37, v38, v39, v665, v666, v42, v43, v44, v45, v46, v47);\nL_0193:\n\tgoto L_0199;\n\tv707 = v699;\n\tv708 = 0x8907BC(v707, v664, v218, v220, v36, v37, v38, v39, v665, v666, v42, v43, v44, v45, v46, v47);\nL_0199:\n\tUnityEngine.GUILayout::BeginHorizontal(v710.Value);\n\tv720 = Facebook.Unity.Example.MenuBase::ShowBackButton(this);\n\tv722 = v720 == 0;\n\tif (v722) goto L_01A5;\n\tFacebook.Unity.Example.MenuBase::AddBackButton(this);\nL_01A5:\n\tFacebook.Unity.Example.MenuBase::AddLogButton(this);\n\tv734 = Facebook.Unity.Example.MenuBase::ShowBackButton(this);\n\tv736 = v734 == 0;\n\tif (v736) goto L_01F3;\n\tgoto L_01BF;\n\tv756 = *([v739 @ X0_v77 (Il2CppClass<UnityEngine.GUIContent>)+E0]);\n\tv757 = v756 == 0;\n\tv758 = ~v757;\n\tif (v758) goto L_01BF;\n\tv773 = \"il2cpp_codegen_runtime_class_init\"(v739, v733, v218, v220, v36, v37, v38, v39, v665, v666, v42, v43, v44, v45, v46, v47);\n\tv760 = UnityEngine.GUIContent;\nL_01BF:\n\t// 447 NewArr v765 @ X0_v80 (UnityEngine.GUILayoutOption[]), typeof(UnityEngine.GUILayoutOption[]), 1\n\tgoto L_01CD;\n\tv787 = *([v774 @ X8_v48+E0]);\n\tv788 = v787 == 0;\n\tv789 = ~v788;\n\tgoto L_01CD;\n\tv802 = v774;\n\tv791 = \"il2cpp_codegen_runtime_class_init\"(v802, v632, v218, v220, v36, v37, v38, v39, v665, v666, v42, \n// ... truncated")]
		protected void OnGUI()
		{
			//IL_0181: Expected O, but got I4
			//IL_0197: Expected I4, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D26F0 (native memset)");
			ScreenOrientation orientation = Screen.orientation;
			if (orientation == ScreenOrientation.LandscapeLeft)
			{
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ X20_v27 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ X20_v35 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				GUILayout.BeginHorizontal();
				IntPtr intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ X20_v30 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr4 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ X20_v33 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				GUILayout.BeginVertical();
			}
			Type type = GetType();
			string text = type.Name;
			GUIStyle style = base.LabelStyle;
			IntPtr intPtr5 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ X22_v4 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr6 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v365 @ X22_v14 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			GUILayout.Label(text, style);
			AddStatus();
			int touchCount = Input.touchCount;
			if (touchCount >= 1)
			{
				int num = default(int);
				object obj = num;
				Touch touch = Input.GetTouch(0);
				num = (int)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @16717C4 (inside UnityEngine.SendMouseEvents::.cctor +0x1A4)");
				object obj2 = default(object);
				if ((IntPtr)obj2 == (IntPtr)1)
				{
					num = Input.GetTouch(0).fingerId;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @16717AC (inside UnityEngine.SendMouseEvents::.cctor +0x18C)");
					object obj3 = default(object);
					float y = scrollPosition.y + (float)obj3;
					scrollPosition.x = scrollPosition.x;
					scrollPosition.y = y;
				}
			}
			GUILayoutOption[] array = new GUILayoutOption[1];
			int num2 = ((!Constants.IsMobile) ? 760 : Screen.width);
			GUILayoutOption gUILayoutOption = GUILayout.MinWidth(num2);
			if (gUILayoutOption != null)
			{
				object obj4 = gUILayoutOption as GUILayoutOption;
			}
			if (array.Length != 0)
			{
				array[0] = gUILayoutOption;
				Vector2 vector = default(Vector2);
				vector.x = scrollPosition.x;
				vector.y = scrollPosition.y;
				Vector2 vector2 = (scrollPosition = GUILayout.BeginScrollView(vector, array));
				scrollPosition.y = vector2.y;
				IntPtr intPtr7 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v669 @ X20_v10 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr8 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v682 @ X20_v23 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				GUILayout.BeginHorizontal();
				if (ShowBackButton())
				{
					AddBackButton();
				}
				AddLogButton();
				if (ShowBackButton())
				{
					GUILayoutOption[] array2 = new GUILayoutOption[1];
					float minWidth = ((!Constants.IsMobile) ? 48f : 0f);
					GUILayoutOption gUILayoutOption2 = GUILayout.MinWidth(minWidth);
					if (gUILayoutOption2 != null)
					{
						object obj5 = gUILayoutOption2 as GUILayoutOption;
					}
					if (array2.Length == 0)
					{
						goto IL_0580;
					}
					array2[0] = gUILayoutOption2;
					GUILayout.Label(GUIContent.none, array2);
				}
				GUILayout.EndHorizontal();
				if (ShowDialogModeSelector())
				{
					AddDialogModeButtons();
				}
				IntPtr intPtr9 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ X20_v14 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr10 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v807 @ X20_v18 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				GUILayout.BeginVertical();
				GetGui();
				GUILayout.Space(10f);
				GUILayout.EndVertical();
				GUILayout.EndScrollView();
				return;
			}
			goto IL_0580;
			IL_0580:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600027E")]
		[Address(RVA = "0xA0AD30", Offset = "0xA0AD30", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1F08800]);\n\tv23 = *([v22 @ X8_v21]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021CBB]) = v42;\nL_0017:\n\tUnityEngine.GUILayout::Space(5f);\n\tv50 = System.String::Concat(\"Status: \", this.status);\n\tv53 = Facebook.Unity.Example.ConsoleBase::get_TextStyle(this);\n\t// 39 NewArr v60 @ X0_v8 (UnityEngine.GUILayoutOption[]), typeof(UnityEngine.GUILayoutOption[]), 1\n\tgoto L_0037;\n\tv68 = *([v64 @ X8_v10+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_0037;\n\tv77 = v64;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v77, v57, v48, v27, v28, v29, v30, v31, v43, v33, v34, v35, v36, v37, v38, v39);\nL_0037:\n\tv76 = Facebook.Unity.Constants::get_IsMobile();\n\tv79 = v76 == 0;\n\tif (v79) goto L_FFFFFFFF;\n\tv81 = UnityEngine.Screen::get_width();\n\tv84 = v81 - 0x1E;\n\tgoto L_0043;\nL_0043:\n\tv90 = UnityEngine.GUILayout::MinWidth(v86);\n\tv93 = v90 == 0;\n\tif (v93) goto L_0050;\n\t// 76 IsInst v99 @ X0_v24, typeof(UnityEngine.GUILayoutOption), v90 @ X0_v14 (UnityEngine.GUILayoutOption)\nL_0050:\n\tv106 = v60.Length == 0;\n\tif (v106) goto L_0062;\n\tv60[0] = v90;\n\tUnityEngine.GUILayout::Box(v50, v53, v60);\n\treturn;\n\tv95 = new System.NullReferenceException();\nL_0062:\n\tv111 = new System.IndexOutOfRangeException();\n\tgoto L_0067;\n\tv122 = new System.ArrayTypeMismatchException();\nL_0067:\n\tthrow v124;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void AddStatus()
		{
			GUILayout.Space(5f);
			string text = "Status: " + status;
			GUIStyle style = base.TextStyle;
			GUILayoutOption[] array = new GUILayoutOption[1];
			float minWidth;
			if (Constants.IsMobile)
			{
				int width = Screen.width;
				int num = width - 30;
				minWidth = num;
			}
			else
			{
				minWidth = 700f;
			}
			GUILayoutOption gUILayoutOption = GUILayout.MinWidth(minWidth);
			if (gUILayoutOption != null)
			{
				object obj = gUILayoutOption as GUILayoutOption;
			}
			if (array.Length != 0)
			{
				array[0] = gUILayoutOption;
				GUILayout.Box(text, style, array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600027F")]
		[Address(RVA = "0xA0AE78", Offset = "0xA0AE78", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EB7428]);\n\tv21 = *([v20 @ X8_v22]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021CBC]) = v40;\nL_001A:\n\tgoto L_0024;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0024;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tgoto L_002F;\n\tv59 = *([1EA3610]);\n\tv60 = *([v59 @ X8_v18]);\n\tv61 = \"il2cpp_codegen_initialize_method\"(v60, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv64 = 0 | 1;\n\t*([2021D33]) = v64;\nL_002F:\n\tgoto L_003B;\n\tv69 = *([v65 @ X0_v5 (Il2CppClass<Facebook.Unity.Example.ConsoleBase>)+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tgoto L_003B;\n\tv82 = \"il2cpp_codegen_runtime_class_init\"(v65, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv73 = Facebook.Unity.Example.ConsoleBase;\nL_003B:\n\tv81 = System.Linq.Enumerable::Any(v77.menuStack);\n\tgoto L_004C;\n\tv90 = *([v86 @ X8_v10+E0]);\n\tv91 = v90 == 0;\n\tv92 = ~v91;\n\tgoto L_004C;\n\tv99 = v86;\n\tv95 = \"il2cpp_codegen_runtime_class_init\"(v99, v80, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_004C:\n\tUnityEngine.GUI::set_enabled(v81);\n\tv104 = Facebook.Unity.Example.ConsoleBase::Button(this, \"Back\");\n\tv106 = v104 == 0;\n\tif (v106) goto L_005A;\n\tFacebook.Unity.Example.ConsoleBase::GoBack(v104);\nL_005A:\n\tgoto L_0068;\n\tv111 = *([v107 @ X0_v13+E0]);\n\tv112 = v111 == 0;\n\tv113 = ~v112;\n\tif (v113) goto L_0068;\n\tv115 = \"il2cpp_codegen_runtime_class_init\"(v107, v103, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0068:\n\tUnityEngine.GUI::set_enabled(1);\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void AddBackButton()
		{
			//IL_004d: Expected O, but got I4
			bool flag = ConsoleBase.menuStack.Any();
			GUI.enabled = flag;
			bool flag2 = Button("Back");
			if (flag2)
			{
				((ConsoleBase)flag2).GoBack();
			}
			GUI.enabled = true;
		}

		[Token(Token = "0x6000280")]
		[Address(RVA = "0xA0AFA8", Offset = "0xA0AFA8", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1ED6540]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021CBD]) = v38;\nL_0017:\n\tv43 = Facebook.Unity.Example.ConsoleBase::Button(this, \"Log\");\n\tv45 = v43 == 0;\n\tif (v45) goto L_003B;\n\tgoto L_002C;\n\tv59 = *([v48 @ X0_v4+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_002C;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v48, v42, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002C:\n\tv68 = System.Type::GetTypeFromHandle(Facebook.Unity.Example.LogView);\n\tFacebook.Unity.Example.ConsoleBase::SwitchMenu(this, v68);\n\treturn;\nL_003B:\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void AddLogButton()
		{
			if (Button("Log"))
			{
				Type typeFromHandle = typeof(LogView);
				SwitchMenu(typeFromHandle);
			}
		}

		[Token(Token = "0x6000281")]
		[Address(RVA = "0xA0B04C", Offset = "0xA0B04C", Length = "0x348")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EE4068]);\n\tv23 = *([v22 @ X8_v50]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021CBE]) = v42;\nL_0019:\n\tv47 = Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>;\n\tgoto L_0022;\n\tv52 = v47;\n\tv53 = 0x8907BC(v52, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv56 = *([v47 @ X20_v2 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]);\nL_0022:\n\tv57 = *([v47 @ X20_v2 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]) & 0x200;\n\tv58 = v57 == 0;\n\tif (v58) goto L_0043;\n\tv60 = Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>;\n\tgoto L_002F;\n\tv82 = v60;\n\tv83 = 0x8907BC(v82, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002F:\n\tv84 = *([v60 @ X20_v15 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]) == 0;\n\tv70 = ~v84;\n\tif (v70) goto L_0043;\n\tgoto L_0043;\n\tv103 = v75;\n\tv104 = 0x8907BC(v103, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0043:\n\tgoto L_0049;\n\tv85 = v77;\n\tv86 = 0x8907BC(v85, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0049:\n\tUnityEngine.GUILayout::BeginHorizontal(v88.Value);\n\tgoto L_005B;\n\tv107 = *([v96 @ X0_v6+E0]);\n\tv108 = v107 == 0;\n\tv109 = ~v108;\n\tif (v109) goto L_005B;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v96, v89, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_005B:\n\tv116 = System.Type::GetTypeFromHandle(Facebook.Unity.ShareDialogMode);\n\tgoto L_006C;\n\tv124 = *([v120 @ X8_v19+E0]);\n\tv125 = v124 == 0;\n\tv126 = ~v125;\n\tif (v126) goto L_006C;\n\tv134 = v120;\n\tv129 = \"il2cpp_codegen_runtime_class_init\"(v134, v115, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_006C:\n\tv133 = System.Enum::GetValues(v116);\n\tv137 = System.Array::GetEnumerator(v133);\n\tv196 = v137 == 0;\n\tif (v196) goto L_00F0;\nL_007C:\n\tgoto L_00A3;\n\tv268 = *([v254 @ X8_v30+B0]);\n\tv269 = 0;\n\tv270 = v268 + 8;\n\tv272 = *([v357 @ X11_v23-8]);\n\tv362 = v272 == v255;\n\tif (v362) goto L_009C;\n\tv292 = v356 + 1;\n\tv369 = v292 < v256;\n\tv290 = ~v369;\n\tv294 = v357 + 0x10;\n\tv274 = ~v290;\n\tif (v274) goto L_FFFFFFFF;\n\tv295 = v194;\n\tv296 = 0;\n\tv297 = 0x8909C4(v295, v255, v296, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_00A3;\nL_009C:\n\tv370 = *([v357 @ X11_v23]);\n\tv371 = v370 << 4;\n\tv372 = v254 + v371;\n\tv373 = v372 + 0x130;\nL_00A3:\n\tv394 = System.Collections.IEnumerator::MoveNext(v137);\n\tv396 = v394 == 0;\n\tif (v396) goto L_FFFFFFFF;\n\tv433 = *([v137 @ X0_v34 (System.Collections.IEnumerator)]);\n\tv436 = *([v433 @ X8_v33 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v436) goto L_00C9;\n\tv506 = *([v433 @ X8_v33 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_00B4:\n\tv511 = *([v506 @ X11_v18-8]) == System.Collections.IEnumerator;\n\tif (v511) goto L_00CC;\n\tv505 = v505 + 1;\n\tv546 = v505 < *([v433 @ X8_v33 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv486 = ~v546;\n\tv506 = v506 + 0x10;\n\tv470 = ~v486;\n\tif (v470) goto L_00B4;\nL_00C9:\n\tv562 = 0x8909C4(v137, System.Collections.IEnumerator, 1, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_00D1;\nL_00CC:\n\tv548 = *([v506 @ X11_v18]) + 1;\n\tv549 = v548 << 4;\n\tv550 = v433 + v549;\n\tv562 = v550 + 0x130;\nL_00D1:\n\tv333 = *([v562 @ X0_v39+8]);\n\t*([v562 @ X0_v39])(v567, v137, *([v562 @ X0_v39+8]), v303, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv226 = v226_asT == 0;\n\tif (v226) goto L_00EE;\n\tv625 = \"il2cpp_vm_object_unbox\"(v567, Facebook.Unity.ShareDialogMode, v303, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tFacebook.Unity.Example.MenuBase::AddDialogModeButton(this, *([v625 @ X0_v45]));\n\tgoto L_007C;\n\tgoto L_0108;\n\tv602 = new System.NullReferenceException();\nL_00EE:\n\tv188 = new System.InvalidCastException();\n\tv195 = new System.NullReferenceException();\nL_00F0:\n\tv219 = new System.NullReferenceException();\n\tgoto L_00FE;\n\tgoto L_00FE;\n\tgoto L_00FE;\n\tgoto L_00FE;\nL_00FE:\n\tv267 = v333 != 1;\n\tif (v267) goto L_0150;\n\tv298 = 0x6D2BC0(v219, v333, v303, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv340 = *([v298 @ X0_v30]);\n\tv368 = 0x6D2490(v298, v333, v303, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0108:\n\t// 264 IsInst v463 @ X0_v15 (System.IDisposable), typeof(System.IDisposable), v459 @ X20_v7 (System.Collections.IEnumerator)\n\tv494 = v463 == 0;\n\tif (v494) goto L_0138;\n\tgoto L_0137;\n\tv568 = *([v516 @ X8_v22+B0]);\n\tv569 = 0;\n\tv570 = v568 + 8;\n\tv572 = *([v614 @ X11_v7-8]);\n\tv619 = v572 == v517;\n\tif (v619) goto L_0130;\n\tv592 = v613 + 1;\n\tv627 = v592 < v518;\n\tv590 = ~v627;\n\tv594 = v614 + 0x10;\n\tv574 = ~v590;\n\tif (v574) goto L_FFFFFFFF;\n\tv595 = v344;\n\tv596 = 0;\n\tv597 = 0x8909C4(v595, v517, v596, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0137;\nL_0130:\n\tv628 = *([v614 @ X11_v7]);\n\tv629 = v628 << 4;\n\tv630 = v516 + v629;\n\tv631 = v630 + 0x130;\nL_0137:\n\tSystem.IDisposable::Dispose(v463);\nL_0138:\n\tv545 = v330 + 1;\n\tv316 = v545 == 0;\n\tv306 = ~v316;\n\tif (v306) goto L_014A;\n\tv598 = v340 == 0;\n\tv338 = ~v598;\n\tif (v338) goto L_014F;\nL_014A:\n\tUnityEngine.GUILayout::EndHorizontal();\n\treturn;\nL_014F:\n\tv336 = new System.TypeLoadException();\nL_0150:\n\tv345 = 0x6D2380(v219, v333, v303, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\treturn;\n// 192 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void AddDialogModeButtons()
		{
			//IL_009f: Expected I, but got O
			//IL_0288: Expected I4, but got O
			//IL_00bd: Expected I, but got O
			//IL_00f8: Expected O, but got I
			//IL_01ca: Expected I4, but got O
			//IL_02ef: Expected I, but got O
			//IL_017e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0183: Expected O, but got Unknown
			//IL_01a0: Expected O, but got I
			//IL_01af: Expected O, but got I
			//IL_01fb: Expected I4, but got O
			//IL_0144: Expected O, but got I
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X20_v2 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ X20_v15 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			GUILayout.BeginHorizontal();
			Type typeFromHandle = typeof(ShareDialogMode);
			Array values = Enum.GetValues(typeFromHandle);
			IEnumerator enumerator = values.GetEnumerator();
			bool flag = enumerator == null;
			IntPtr intPtr3 = (IntPtr)null;
			IEnumerator enumerator2 = enumerator;
			if (flag)
			{
				goto IL_0248;
			}
			object obj5 = default(object);
			object obj6 = default(object);
			int num4;
			while (enumerator.MoveNext())
			{
				IntPtr intPtr4 = (IntPtr)enumerator;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ X8_v33 (Il2CppClass<System.Collections.IEnumerator>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_015d;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ X8_v33 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ X11_v18-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IEnumerator))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ X8_v33 (Il2CppClass<System.Collections.IEnumerator>)+126]");
					bool flag2 = (long)num2 < 0L;
					bool flag3 = !flag2;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag3)
					{
						continue;
					}
					goto IL_015d;
				}
				object obj2 = obj + 1;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr4 + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				num4 = 0;
				goto IL_0366;
				IL_015d:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				num4 = 1;
				goto IL_0366;
				IL_0366:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ X0_v39+8]");
				intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v562 @ X0_v39] (should have been resolved before IL gen)");
				if ((int)((obj5 is ShareDialogMode) ? obj5 : null) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					AddDialogModeButton((ShareDialogMode)obj6);
					continue;
				}
				goto IL_0224;
			}
			int num5 = 0;
			int num6 = 0;
			enumerator2 = enumerator;
			goto IL_038a;
			IL_02fc:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			return;
			IL_0224:
			InvalidCastException ex = new InvalidCastException();
			enumerator2 = enumerator;
			NullReferenceException ex2 = new NullReferenceException();
			goto IL_0248;
			IL_038a:
			(enumerator2 as IDisposable)?.Dispose();
			if (num5 + 1 != 0 || num6 == 0)
			{
				GUILayout.EndHorizontal();
				return;
			}
			TypeLoadException ex3 = new TypeLoadException();
			num4 = 0;
			intPtr3 = (IntPtr)null;
			NullReferenceException ex4 = (NullReferenceException)(object)ex3;
			goto IL_02fc;
			IL_0248:
			ex4 = new NullReferenceException();
			if (intPtr3 != (IntPtr)1)
			{
				goto IL_02fc;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
			object obj7 = default(object);
			num6 = (int)obj7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
			num5 = -1;
			goto IL_038a;
		}

		[Token(Token = "0x6000282")]
		[Address(RVA = "0xA0B394", Offset = "0xA0B394", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv27 = *([1EFFF10]);\n\tv28 = *([v27 @ X8_v29]);\n\tv29 = \"il2cpp_codegen_initialize_method\"(v28, mode, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2021CBF]) = v46;\nL_001E:\n\tgoto L_0025;\n\tv53 = *([v49 @ X0_v2+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0025;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v49, mode, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0025:\n\tv61 = UnityEngine.GUI::get_enabled();\n\tv63 = v61 == 0;\n\tif (v63) goto L_FFFFFFFF;\n\tv71 = v67.shareDialogMode - mode;\n\tv73 = v71 == 0;\n\tv78 = ~v73;\n\tgoto L_0041;\nL_0041:\n\tgoto L_0049;\n\tv108 = *([v104 @ X0_v6+E0]);\n\tv109 = v108 == 0;\n\tv110 = ~v109;\n\tgoto L_0049;\n\tv112 = \"il2cpp_codegen_runtime_class_init\"(v104, mode, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0049:\n\tUnityEngine.GUI::set_enabled(v103);\n\t// 78 Box v121 @ X0_v10, typeof(Facebook.Unity.ShareDialogMode), &mode @ X1 (Facebook.Unity.ShareDialogMode)\n\tv124 = *([v121 @ X0_v10]);\n\t*([v124 @ X8_v10+160])(v128, v121, *([v124 @ X8_v10+168]), methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv131 = \"il2cpp_vm_object_unbox\"(v121, *([v124 @ X8_v10+168]), methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv137 = Facebook.Unity.Example.ConsoleBase::Button(this, v128);\n\tv139 = v137 == 0;\n\tif (v139) goto L_006F;\n\tv171.shareDialogMode = *([v131 @ X0_v15]);\n\tFacebook.Unity.FB+Mobile::set_ShareDialogMode(*([v131 @ X0_v15]));\nL_006F:\n\tgoto L_0077;\n\tv180 = *([v176 @ X0_v19+E0]);\n\tv181 = v180 == 0;\n\tv182 = ~v181;\n\tif (v182) goto L_0077;\n\tv184 = \"il2cpp_codegen_runtime_class_init\"(v176, v173, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0077:\n\tUnityEngine.GUI::set_enabled(v101);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 86 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void AddDialogModeButton(ShareDialogMode mode)
		{
			//IL_00f0: Expected I4, but got O
			//IL_00f9: Expected I4, but got O
			int num2;
			bool flag3;
			if (GUI.enabled)
			{
				int num = shareDialogMode - mode;
				bool flag = num == 0;
				bool flag2 = !flag;
				num2 = 1;
				flag3 = flag2;
			}
			else
			{
				num2 = 0;
				flag3 = false;
			}
			GUI.enabled = flag3;
			object obj = mode;
			object obj2 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v124 @ X8_v10+160] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			string label = default(string);
			if (Button(label))
			{
				object obj3 = default(object);
				shareDialogMode = (ShareDialogMode)obj3;
				FB.Mobile.ShareDialogMode = (ShareDialogMode)obj3;
			}
			GUI.enabled = (byte)num2 != 0;
		}

		[Token(Token = "0x6000283")]
		[Address(RVA = "0xA0606C", Offset = "0xA0606C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC6EE0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021CC0]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tFacebook.Unity.Example.ConsoleBase::.ctor(this);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal MenuBase()
		{
		}
	}
}
