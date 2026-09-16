using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Security;

namespace EasyMobile
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x7312C8", Offset = "0x7312C8")]
	[Token(Token = "0x2000062")]
	public class InAppPurchasing : MonoBehaviour
	{
		[Token(Token = "0x200012F")]
		private class StoreListener : IStoreListener
		{
			[Token(Token = "0x600099D")]
			[Address(RVA = "0xBFA3D4", Offset = "0xBFA3D4", Length = "0x50C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EDBC70]);\n\tv25 = *([v24 @ X8_v72]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, controller, extensions, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 0 | 1;\n\t*([2022F1D]) = v43;\nL_001C:\n\tgoto L_0026;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0026;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, controller, extensions, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0026:\n\tUnityEngine.Debug::Log(\"In-App Purchasing OnInitialized: PASS\");\n\tgoto L_0035;\n\tv67 = *([v63 @ X0_v5 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_0035;\n\tv80 = \"il2cpp_codegen_runtime_class_init\"(v63, v59, extensions, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv71 = EasyMobile.InAppPurchasing;\nL_0035:\n\tv74.sIsInitializing = 0;\n\tv75.sStoreController = controller;\n\tv76.sStoreExtensionProvider = extensions;\n\tv78 = v77.sStoreExtensionProvider;\n\tv83 = *([v78 @ X19_v2 (UnityEngine.Purchasing.IExtensionProvider)]);\n\tv84 = Il2CppMethodInfo;\n\tv88 = *([v83 @ X8_v17 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]) == 0;\n\tif (v88) goto L_0063;\n\tv320 = *([v83 @ X8_v17 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]) + 8;\nL_004F:\n\tv325 = *([v320 @ X11_v38-8]) == Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>;\n\tif (v325) goto L_0066;\n\tv319 = v319 + 1;\n\tv330 = v319 < *([v83 @ X8_v17 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]);\n\tv277 = ~v330;\n\tv320 = v320 + 0x10;\n\tv261 = ~v277;\n\tif (v261) goto L_004F;\nL_0063:\n\tv337 = 0x8909C4(v78, Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>, *([v84 @ X20_v4 (Il2CppMethodInfo)+48]), methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_006C;\nL_0066:\n\tv332 = *([v320 @ X11_v38]) + *([v84 @ X20_v4 (Il2CppMethodInfo)+48]);\n\tv333 = v332 << 4;\n\tv334 = v83 + v333;\n\tv337 = v334 + 0x130;\nL_006C:\n\tv341 = 0x8D8294(*([v337 @ X0_v11+8]), Il2CppMethodInfo, *([v84 @ X20_v4 (Il2CppMethodInfo)+48]), methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\t*([v341 @ X0_v13])(v221, v78, v341, *([v84 @ X20_v4 (Il2CppMethodInfo)+48]), methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv206.sAppleExtensions = v221;\n\tv241 = v248.sStoreExtensionProvider;\n\tv395 = *([v241 @ X19_v5 (UnityEngine.Purchasing.IExtensionProvider)]);\n\tv235 = Il2CppMethodInfo;\n\tv398 = *([v395 @ X8_v22 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]) == 0;\n\tif (v398) goto L_009E;\n\tv439 = *([v395 @ X8_v22 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]) + 8;\nL_008A:\n\tv444 = *([v439 @ X11_v33-8]) == Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>;\n\tif (v444) goto L_00A1;\n\tv438 = v438 + 1;\n\tv449 = v438 < *([v395 @ X8_v22 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]);\n\tv421 = ~v449;\n\tv439 = v439 + 0x10;\n\tv405 = ~v421;\n\tif (v405) goto L_008A;\nL_009E:\n\tv456 = 0x8909C4(v241, Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>, *([v235 @ X20_v5 (Il2CppMethodInfo)+48]), methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_00A7;\nL_00A1:\n\tv451 = *([v439 @ X11_v33]) + *([v235 @ X20_v5 (Il2CppMethodInfo)+48]);\n\tv452 = v451 << 4;\n\tv453 = v395 + v452;\n\tv456 = v453 + 0x130;\nL_00A7:\n\tv460 = 0x8D8294(*([v456 @ X0_v16+8]), Il2CppMethodInfo, *([v235 @ X20_v5 (Il2CppMethodInfo)+48]), methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\t*([v460 @ X0_v18])(v222, v241, v460, *([v235 @ X20_v5 (Il2CppMethodInfo)+48]), methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv207.sGooglePlayStoreExtensions = v222;\n\tv242 = v249.sStoreExtensionProvider;\n\tv467 = *([v242 @ X19_v6 (UnityEngine.Purchasing.IExtensionProvider)]);\n\tv236 = Il2CppMethodInfo;\n\tv470 = *([v467 @ X8_v27 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]) == 0;\n\tif (v470) goto L_00D9;\n\tv511 = *([v467 @ X8_v27 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]) + 8;\nL_00C5:\n\tv516 = *([v511 @ X11_v28-8]) == Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>;\n\tif (v516) goto L_00DC;\n\tv510 = v510 + 1;\n\tv521 = v510 < *([v467 @ X8_v27 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]);\n\tv493 = ~v521;\n\tv511 = v511 + 0x10;\n\tv477 = ~v493;\n\tif (v477) goto L_00C5;\nL_00D9:\n\tv528 = 0x8909C4(v242, Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>, *([v236 @ X20_v6 (Il2CppMethodInfo)+48]), methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_00E2;\nL_00DC:\n\tv523 = *([v511 @ X11_v28]) + *([v236 @ X20_v6 (Il2CppMethodInfo)+48]);\n\tv524 = v523 << 4;\n\tv525 = v467 + v524;\n\tv528 = v525 + 0x130;\nL_00E2:\n\tv532 = 0x8D8294(*([v528 @ X0_v21+8]), Il2CppMethodInfo, *([v236 @ X20_v6 (Il2CppMethodInfo)+48]), methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\t*([v532 @ X0_v23])(v223, v242, v532, *([v236 @ X20_v6 (Il2CppMethodInfo)+48]), methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv208.sAmazonExtensions = v223;\n\tv243 = v250.sStoreExtensionProvider;\n\tv539 = *([v243 @ X19_v7 (UnityEngine.Purchasing.IExtensionProvider)]);\n\tv237 = Il2CppMethodInfo;\n\tv542 = *([v539 @ X8_v32 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]) == 0;\n\tif (v542) goto L_0114;\n\tv583 = *([v539 @ X8_v32 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]) + 8;\nL_0100:\n\tv588 = *([v583 @ X11_v23-8]) == Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>;\n\tif (v588) goto L_0117;\n\tv582 = v582 + 1;\n\tv593 = v582 < *([v539 @ X8_v32 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]);\n\tv565 = ~v593;\n\tv583 = v583 + 0x10;\n\tv549 = ~v565;\n\tif (v549) goto L_0100;\nL_0114:\n\tv609 = 0x8909C4(v243, Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>, *([v237 @ X20_v7 (Il2CppMethodInfo)+48]), methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_011D;\nL_0117:\n\tv595 = *([v583 @ X11_v23]) + *([v237 @ X20_v7 (Il2CppMethodInfo)+48]);\n\tv596 = v595 << 4;\n\tv597 = v539 + v596;\n\tv609 = v597 + 0x130;\nL_011D:\n\tv613 = 0x8D8294(*([v609 @ X0_v26+8]), Il2CppMethodInfo, *([v237 @ X20_v7 (Il2CppMethodInfo)+48]), methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\t*([v613 @ X0_v28])(v617, v243, v613, *([v237 @ X20_v7 (Il2CppMethodInfo)+48]), methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv209.sSamsungAppsExtensions = v617;\n\tv621 = v619.sAppleExtensions == 0;\n\tif (v621) goto L_01C9;\n\tv623 = UnityEngine.Application::get_platform();\n\tv115 = v623 != 8;\n\tif (v115) goto L_01C9;\n\tgoto L_0144;\n\tv666 = *([v658 @ X0_v41 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv667 = v666 == 0;\n\tv668 = ~v667;\n\tif (v668) goto L_0144;\n\tv677 = \"il2cpp_codegen_runtime_class_init\"(v658, v217, v202, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv670 = EasyMobile.InAppPurchasing;\nL_0144:\n\tv244 = v251.sAppleExtensions;\n\tv224 = EasyMobile.EM_Settings::get_InAppPurchasing();\n\tv681 = *([v244 @ X19_v11 (UnityEngine.Purchasing.IAppleExtensions)]);\n\tv685 = *([v681 @ X8_v51 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+126]) == 0;\n\tif (v685) goto L_016F;\n\tv727 = *([v681 @ X8_v51 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+B0]) + 8;\nL_015A:\n\tv732 = *([v727 @ X11_v18-8]) == UnityEngine.Purchasing.IAppleExtensions;\n\tif (v732) goto L_0172;\n\tv726 = v726 + 1;\n\tv737 = v726 < *([v681 @ X8_v51 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+126]);\n\tv708 = ~v737;\n\tv727 = v727 + 0x10;\n\tv692 = ~v708;\n\tif (v692) goto L_015A;\nL_016F:\n\tv754 = 0x8909C4(v244, UnityEngine.Purchasing.IAppleExtensions, 3, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_017C;\nL_0172:\n\tv739 = *([v727 @ X11_v18]) + 3;\n\tv740 = v739 << 4;\n\tv741 = v681 + v740;\n\tv754 = v741 + 0x130;\nL_017C:\n\tv156 = v224.mSimulateAppleAskToBuy == 0;\n\tv116 = ~v156;\n\t*([v754 @ X0_v45])(v761, v244, v116, *([v754 @ X0_v45+8]), methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv245 = v764.sAppleExtensions;\n// ... truncated")]
			public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
			{
				//IL_001c: Expected I, but got O
				//IL_005d: Expected O, but got I
				//IL_011f: Expected I, but got O
				//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
				//IL_00e6: Expected O, but got Unknown
				//IL_0103: Expected O, but got I
				//IL_0112: Expected O, but got I
				//IL_0160: Expected O, but got I
				//IL_00a9: Expected O, but got I
				//IL_0222: Expected I, but got O
				//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
				//IL_01e9: Expected O, but got Unknown
				//IL_0206: Expected O, but got I
				//IL_0215: Expected O, but got I
				//IL_0263: Expected O, but got I
				//IL_01ac: Expected O, but got I
				//IL_0325: Expected I, but got O
				//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
				//IL_02ec: Expected O, but got Unknown
				//IL_0309: Expected O, but got I
				//IL_0318: Expected O, but got I
				//IL_0366: Expected O, but got I
				//IL_02af: Expected O, but got I
				//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
				//IL_03ef: Expected O, but got Unknown
				//IL_040c: Expected O, but got I
				//IL_041b: Expected O, but got I
				//IL_03b2: Expected O, but got I
				//IL_0456: Expected I, but got O
				//IL_0491: Expected O, but got I
				//IL_054c: Expected I, but got O
				//IL_050e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0513: Expected O, but got Unknown
				//IL_0530: Expected O, but got I
				//IL_053f: Expected O, but got I
				//IL_0587: Expected O, but got I
				//IL_04dd: Expected O, but got I
				//IL_05fa: Unknown result type (might be due to invalid IL or missing references)
				//IL_05ff: Expected O, but got Unknown
				//IL_061c: Expected O, but got I
				//IL_062b: Expected O, but got I
				//IL_05d3: Expected O, but got I
				Debug.Log("In-App Purchasing OnInitialized: PASS");
				sIsInitializing = false;
				sStoreController = controller;
				InAppPurchasing.sStoreExtensionProvider = extensions;
				IExtensionProvider sStoreExtensionProvider = InAppPurchasing.sStoreExtensionProvider;
				IntPtr intPtr = (IntPtr)sStoreExtensionProvider;
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ X8_v17 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00c2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ X8_v17 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ X11_v38-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ X8_v17 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00c2;
				}
				object obj2 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ X20_v4 (Il2CppMethodInfo)+48]");
				object obj3 = obj2 + 0;
				int num3 = (int)((long)(IntPtr)obj3 << 4);
				object obj4 = (long)intPtr + (long)num3;
				object obj5 = (long)(IntPtr)obj4 + 304L;
				goto IL_0692;
				IL_06df:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D8294");
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v460 @ X0_v18] (should have been resolved before IL gen)");
				IGooglePlayStoreExtensions sGooglePlayStoreExtensions = default(IGooglePlayStoreExtensions);
				InAppPurchasing.sGooglePlayStoreExtensions = sGooglePlayStoreExtensions;
				IExtensionProvider sStoreExtensionProvider2 = InAppPurchasing.sStoreExtensionProvider;
				IntPtr intPtr3 = (IntPtr)sStoreExtensionProvider2;
				IntPtr intPtr4 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ X8_v27 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_02c8;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ X8_v27 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]");
				object obj6 = 0L + 8L;
				int num4 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v511 @ X11_v28-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num4++;
					int num5 = num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ X8_v27 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
					bool flag3 = (long)num5 < 0L;
					bool flag4 = !flag3;
					obj6 = (long)(IntPtr)obj6 + 16L;
					if (!flag4)
					{
						continue;
					}
					goto IL_02c8;
				}
				object obj7 = obj6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ X20_v6 (Il2CppMethodInfo)+48]");
				object obj8 = obj7 + 0;
				int num6 = (int)((long)(IntPtr)obj8 << 4);
				object obj9 = (long)intPtr3 + (long)num6;
				object obj10 = (long)(IntPtr)obj9 + 304L;
				goto IL_072c;
				IL_072c:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D8294");
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v532 @ X0_v23] (should have been resolved before IL gen)");
				IAmazonExtensions sAmazonExtensions = default(IAmazonExtensions);
				InAppPurchasing.sAmazonExtensions = sAmazonExtensions;
				IExtensionProvider sStoreExtensionProvider3 = InAppPurchasing.sStoreExtensionProvider;
				IntPtr intPtr5 = (IntPtr)sStoreExtensionProvider3;
				IntPtr intPtr6 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v539 @ X8_v32 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_03cb;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v539 @ X8_v32 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]");
				object obj11 = 0L + 8L;
				int num7 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ X11_v23-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num7++;
					int num8 = num7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v539 @ X8_v32 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
					bool flag5 = (long)num8 < 0L;
					bool flag6 = !flag5;
					obj11 = (long)(IntPtr)obj11 + 16L;
					if (!flag6)
					{
						continue;
					}
					goto IL_03cb;
				}
				object obj12 = obj11;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ X20_v7 (Il2CppMethodInfo)+48]");
				object obj13 = obj12 + 0;
				int num9 = (int)((long)(IntPtr)obj13 << 4);
				object obj14 = (long)intPtr5 + (long)num9;
				object obj15 = (long)(IntPtr)obj14 + 304L;
				goto IL_0779;
				IL_03cb:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0779;
				IL_0779:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D8294");
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v613 @ X0_v28] (should have been resolved before IL gen)");
				ISamsungAppsExtensions sSamsungAppsExtensions = default(ISamsungAppsExtensions);
				InAppPurchasing.sSamsungAppsExtensions = sSamsungAppsExtensions;
				IAPSettings inAppPurchasing;
				if (InAppPurchasing.sAppleExtensions != null)
				{
					RuntimePlatform platform = Application.platform;
					if (platform == RuntimePlatform.IPhonePlayer)
					{
						IAppleExtensions sAppleExtensions = InAppPurchasing.sAppleExtensions;
						inAppPurchasing = EM_Settings.InAppPurchasing;
						IntPtr intPtr7 = (IntPtr)sAppleExtensions;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v681 @ X8_v51 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+126]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							goto IL_04f6;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v681 @ X8_v51 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+B0]");
						object obj16 = 0L + 8L;
						int num10 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v727 @ X11_v18-8]");
							if ((IntPtr)0 == (IntPtr)typeof(IAppleExtensions))
							{
								break;
							}
							num10++;
							int num11 = num10;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v681 @ X8_v51 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+126]");
							bool flag7 = (long)num11 < 0L;
							bool flag8 = !flag7;
							obj16 = (long)(IntPtr)obj16 + 16L;
							if (!flag8)
							{
								continue;
							}
							goto IL_04f6;
						}
						object obj17 = obj16 + 3;
						int num12 = (int)((long)(IntPtr)obj17 << 4);
						object obj18 = (long)intPtr7 + (long)num12;
						object obj19 = (long)(IntPtr)obj18 + 304L;
						goto IL_07fa;
					}
				}
				goto IL_087b;
				IL_00c2:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0692;
				IL_0692:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D8294");
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v341 @ X0_v13] (should have been resolved before IL gen)");
				IAppleExtensions sAppleExtensions2 = default(IAppleExtensions);
				InAppPurchasing.sAppleExtensions = sAppleExtensions2;
				IExtensionProvider sStoreExtensionProvider4 = InAppPurchasing.sStoreExtensionProvider;
				IntPtr intPtr8 = (IntPtr)sStoreExtensionProvider4;
				IntPtr intPtr9 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ X8_v22 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_01c5;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ X8_v22 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]");
				object obj20 = 0L + 8L;
				int num13 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v439 @ X11_v33-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num13++;
					int num14 = num13;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ X8_v22 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
					bool flag9 = (long)num14 < 0L;
					bool flag10 = !flag9;
					obj20 = (long)(IntPtr)obj20 + 16L;
					if (!flag10)
					{
						continue;
					}
					goto IL_01c5;
				}
				object obj21 = obj20;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ X20_v5 (Il2CppMethodInfo)+48]");
				object obj22 = obj21 + 0;
				int num15 = (int)((long)(IntPtr)obj22 << 4);
				object obj23 = (long)intPtr8 + (long)num15;
				object obj24 = (long)(IntPtr)obj23 + 304L;
				goto IL_06df;
				IL_07fa:
				bool flag11 = !inAppPurchasing.SimulateAppleAskToBuy;
				bool flag12 = !flag11;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v754 @ X0_v45] (should have been resolved before IL gen)");
				Action<Product> sAppleExtensions3 = (Action<Product>)(object)InAppPurchasing.sAppleExtensions;
				Action<Product> action = OnApplePurchaseDeferred;
				IntPtr intPtr10 = (IntPtr)sAppleExtensions3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v769 @ X8_v58 (Il2CppClass<System.Action`1<UnityEngine.Purchasing.Product>>)+126]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v769 @ X8_v58 (Il2CppClass<System.Action`1<UnityEngine.Purchasing.Product>>)+B0]");
					object obj25 = 0L + 8L;
					int num16 = 0;
					bool flag14;
					do
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v813 @ X11_v13-8]");
						if ((IntPtr)0 != (IntPtr)typeof(IAppleExtensions))
						{
							num16++;
							int num17 = num16;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v769 @ X8_v58 (Il2CppClass<System.Action`1<UnityEngine.Purchasing.Product>>)+126]");
							bool flag13 = (long)num17 < 0L;
							flag14 = !flag13;
							obj25 = (long)(IntPtr)obj25 + 16L;
							continue;
						}
						object obj26 = obj25 + 2;
						int num18 = (int)((long)(IntPtr)obj26 << 4);
						object obj27 = (long)intPtr10 + (long)num18;
						Action<Product> action2 = (Action<Product>)((long)(IntPtr)obj27 + 304L);
						break;
					}
					while (!flag14);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v830 @ X0_v50 (System.Action`1<UnityEngine.Purchasing.Product>)] (should have been resolved before IL gen)");
				goto IL_087b;
				IL_087b:
				if (InAppPurchasing.InitializeSucceeded != null)
				{
					InAppPurchasing.InitializeSucceeded();
				}
				return;
				IL_02c8:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_072c;
				IL_04f6:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_07fa;
				IL_01c5:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_06df;
			}

			[Token(Token = "0x600099E")]
			[Address(RVA = "0xBFA8E0", Offset = "0xBFA8E0", Length = "0x120")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1F01BB8]);\n\tv19 = *([v18 @ X8_v24]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, error, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2022F1E]) = v38;\nL_0018:\n\t// 24 Box v44 @ X0_v3 (System.Object), typeof(UnityEngine.Purchasing.InitializationFailureReason), &error @ X1 (UnityEngine.Purchasing.InitializationFailureReason)\n\tv51 = System.String::Concat(\"In-App Purchasing OnInitializeFailed. InitializationFailureReason:\", v44);\n\tgoto L_0030;\n\tv59 = *([v55 @ X8_v10+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tgoto L_0030;\n\tv68 = v55;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v68, v47, v48, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0030:\n\tUnityEngine.Debug::Log(v51);\n\tgoto L_003F;\n\tv75 = *([v71 @ X0_v8 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv76 = v75 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_003F;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v71, v67, v48, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv79 = EasyMobile.InAppPurchasing;\nL_003F:\n\tv82.sIsInitializing = 0;\n\tv85 = v83.InitializeFailed == 0;\n\tif (v85) goto L_005A;\n\tgoto L_0054;\n\tv104 = *([v78 @ X0_v9 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv105 = v104 == 0;\n\tv106 = ~v105;\n\tif (v106) goto L_0054;\n\tv121 = EasyMobile.InAppPurchasing;\n\tv122 = *([v121 @ X8_v18 (Il2CppClass<EasyMobile.InAppPurchasing>)+B8]);\n\tv110 = v122.InitializeFailed;\nL_0054:\n\tSystem.Action::Invoke(v83.InitializeFailed);\nL_005A:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void OnInitializeFailed(InitializationFailureReason error)
			{
				object obj = error;
				string message = "In-App Purchasing OnInitializeFailed. InitializationFailureReason:" + obj;
				Debug.Log(message);
				sIsInitializing = false;
				if (InAppPurchasing.InitializeFailed != null)
				{
					InAppPurchasing.InitializeFailed();
				}
			}

			[Token(Token = "0x600099F")]
			[Address(RVA = "0xBFAA00", Offset = "0xBFAA00", Length = "0x14C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1ED17C0]);\n\tv23 = *([v22 @ X8_v28]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, product, failureReason, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([2022F1F]) = v41;\nL_0017:\n\tv43 = product.<definition>k__BackingField;\n\t// 32 Box v77 @ X0_v6 (System.Object), typeof(UnityEngine.Purchasing.PurchaseFailureReason), &failureReason @ X2 (UnityEngine.Purchasing.PurchaseFailureReason)\n\tv83 = System.String::Format(\"Couldn't purchase product: '{0}', PurchaseFailureReason: {1}\", v43.<storeSpecificId>k__BackingField, v77);\n\tgoto L_0039;\n\tv114 = *([v110 @ X8_v12+E0]);\n\tv115 = v114 == 0;\n\tv116 = ~v115;\n\tif (v116) goto L_0039;\n\tv121 = v110;\n\tv118 = \"il2cpp_codegen_runtime_class_init\"(v121, v80, v51, v49, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0039:\n\tUnityEngine.Debug::Log(v83);\n\tgoto L_0049;\n\tv127 = *([v123 @ X0_v11 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv128 = v127 == 0;\n\tv129 = ~v128;\n\tif (v129) goto L_0049;\n\tv137 = \"il2cpp_codegen_runtime_class_init\"(v123, v57, v51, v49, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv131 = EasyMobile.InAppPurchasing;\nL_0049:\n\tv136 = v134.PurchaseFailed == 0;\n\tif (v136) goto L_006A;\n\tgoto L_0057;\n\tv145 = *([v130 @ X0_v12 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv146 = v145 == 0;\n\tv147 = ~v146;\n\tif (v147) goto L_0057;\n\tv148 = \"il2cpp_codegen_runtime_class_init\"(v130, v57, v51, v49, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv154 = EasyMobile.InAppPurchasing;\n\tv152 = *([v154 @ X8_v23+B8]);\n\tv150 = *([v152 @ X8_v24+20]);\nL_0057:\n\tv67 = product.<definition>k__BackingField;\n\tv59 = EasyMobile.InAppPurchasing::GetIAPProductById(v67.<id>k__BackingField);\n\tSystem.Action`1<EasyMobile.IAPProduct>::Invoke(v134.PurchaseFailed, v59);\nL_006A:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
			{
				ProductDefinition definition = product.definition;
				object arg = failureReason;
				string message = $"Couldn't purchase product: '{definition.storeSpecificId}', PurchaseFailureReason: {arg}";
				Debug.Log(message);
				if (InAppPurchasing.PurchaseFailed != null)
				{
					ProductDefinition definition2 = product.definition;
					IAPProduct iAPProductById = GetIAPProductById(definition2.id);
					InAppPurchasing.PurchaseFailed(iAPProductById);
				}
			}

			[Token(Token = "0x60009A0")]
			[Address(RVA = "0xBFAB4C", Offset = "0xBFAB4C", Length = "0x268")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ECC390]);\n\tv23 = *([v22 @ X8_v44]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, args, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 0 | 1;\n\t*([2022F20]) = v42;\nL_0015:\n\tv43 = 0;\n\tv45 = args.<purchasedProduct>k__BackingField;\n\tv93 = System.String::Concat(\"Processing purchase of product: \", v45.<transactionID>k__BackingField);\n\tgoto L_0031;\n\tv123 = *([v95 @ X8_v7+E0]);\n\tv124 = v123 == 0;\n\tv125 = ~v124;\n\tif (v125) goto L_0031;\n\tv130 = v95;\n\tv127 = \"il2cpp_codegen_runtime_class_init\"(v130, v89, v58, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0031:\n\tUnityEngine.Debug::Log(v93);\n\tgoto L_003E;\n\tv136 = *([v132 @ X0_v9 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv137 = v136 == 0;\n\tv138 = ~v137;\n\tif (v138) goto L_003E;\n\tv140 = \"il2cpp_codegen_runtime_class_init\"(v132, v61, v58, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003E:\n\tv66 = EasyMobile.InAppPurchasing::IsReceiptValidationEnabled();\n\tv144 = v66 == 0;\n\tif (v144) goto L_FFFFFFFF;\n\tv79 = args.<purchasedProduct>k__BackingField;\n\tgoto L_0053;\n\tv159 = *([v146 @ X0_v40+E0]);\n\tv160 = v159 == 0;\n\tv161 = ~v160;\n\tif (v161) goto L_0053;\n\tv163 = \"il2cpp_codegen_runtime_class_init\"(v146, v61, v58, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0053:\n\tv153 = EasyMobile.InAppPurchasing::ValidateReceipt(v79.<receipt>k__BackingField, &v43 @ stack_-38_v1 (UnityEngine.Purchasing.Security.IPurchaseReceipt[]), 0);\n\tgoto L_0057;\nL_0057:\n\tv83 = args.<purchasedProduct>k__BackingField;\n\tv80 = v83.<definition>k__BackingField;\n\tgoto L_0069;\n\tv170 = *([v165 @ X0_v13+E0]);\n\tv171 = v170 == 0;\n\tv172 = ~v171;\n\tif (v172) goto L_0069;\n\tv174 = \"il2cpp_codegen_runtime_class_init\"(v165, v62, v59, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0069:\n\tv178 = EasyMobile.InAppPurchasing::GetIAPProductById(v80.<id>k__BackingField);\n\tv181 = v86 & 1;\n\tv182 = v181 == 0;\n\tif (v182) goto L_009F;\n\tgoto L_007D;\n\tv187 = *([v179 @ X8_v14+E0]);\n\tv188 = v187 == 0;\n\tv189 = ~v188;\n\tif (v189) goto L_007D;\n\tv207 = v179;\n\tv192 = \"il2cpp_codegen_runtime_class_init\"(v207, v62, v59, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_007D:\n\tUnityEngine.Debug::Log(\"Product purchase completed.\");\n\tgoto L_008A;\n\tv217 = *([v208 @ X0_v32 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv218 = v217 == 0;\n\tv219 = ~v218;\n\tif (v219) goto L_008A;\n\tv237 = \"il2cpp_codegen_runtime_class_init\"(v208, v63, v59, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv221 = EasyMobile.InAppPurchasing;\nL_008A:\n\tv247 = v224.PurchaseCompleted;\n\tv226 = v224.PurchaseCompleted == 0;\n\tif (v226) goto L_00D6;\n\tv239 = *([v220 @ X0_v33 (Il2CppClass<EasyMobile.InAppPurchasing>)+12F]) & 2;\n\tv240 = v239 == 0;\n\tif (v240) goto L_00CD;\n\tv252 = *([v220 @ X0_v33 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]) == 0;\n\tv253 = ~v252;\n\tif (v253) goto L_00CD;\n\tv247 = v261.PurchaseCompleted;\n\tv262 = v261.PurchaseCompleted == 0;\n\tv73 = ~v262;\n\tif (v73) goto L_00CD;\n\tgoto L_00D8;\nL_009F:\n\tgoto L_00AA;\n\tv197 = *([v179 @ X8_v14+E0]);\n\tv198 = v197 == 0;\n\tv199 = ~v198;\n\tif (v199) goto L_00AA;\n\tv212 = v179;\n\tv202 = \"il2cpp_codegen_runtime_class_init\"(v212, v62, v59, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00AA:\n\tUnityEngine.Debug::Log(\"Couldn't purchase product: Invalid receipt.\");\n\tgoto L_00B7;\n\tv227 = *([v213 @ X0_v23 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv228 = v227 == 0;\n\tv229 = ~v228;\n\tif (v229) goto L_00B7;\n\tv248 = \"il2cpp_codegen_runtime_class_init\"(v213, v64, v59, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv231 = EasyMobile.InAppPurchasing;\nL_00B7:\n\tv247 = v234.PurchaseFailed;\n\tv236 = v234.PurchaseFailed == 0;\n\tif (v236) goto L_00D6;\n\tgoto L_00CD;\n\tv54 = *([v230 @ X0_v24 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv259 = v54 == 0;\n\tv257 = ~v259;\n\tif (v257) goto L_00CD;\n\tv263 = EasyMobile.InAppPurchasing;\n\tv264 = *([v263 @ X8_v23 (Il2CppClass<EasyMobile.InAppPurchasing>)+B8]);\n\tv82 = v264.PurchaseFailed;\nL_00CD:\n\tSystem.Action`1<EasyMobile.IAPProduct>::Invoke(v247, v178);\nL_00D6:\n\treturn 0;\nL_00D8:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 112 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
			{
				//IL_0127: Expected I, but got O
				//IL_020e: Expected I4, but got O
				IPurchaseReceipt[] purchaseReceipts = null;
				Product purchasedProduct = args.purchasedProduct;
				string message = "Processing purchase of product: " + purchasedProduct.transactionID;
				Debug.Log(message);
				int num;
				if (IsReceiptValidationEnabled())
				{
					Product purchasedProduct2 = args.purchasedProduct;
					bool flag = ValidateReceipt(purchasedProduct2.receipt, out purchaseReceipts);
					num = (flag ? 1 : 0);
				}
				else
				{
					num = 1;
				}
				Product purchasedProduct3 = args.purchasedProduct;
				ProductDefinition definition = purchasedProduct3.definition;
				IAPProduct iAPProductById = GetIAPProductById(definition.id);
				Action<IAPProduct> action;
				if ((num & 1) != 0)
				{
					Debug.Log("Product purchase completed.");
					IntPtr intPtr = (IntPtr)typeof(InAppPurchasing);
					action = InAppPurchasing.PurchaseCompleted;
					if (InAppPurchasing.PurchaseCompleted != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ X0_v33 (Il2CppClass<EasyMobile.InAppPurchasing>)+12F]");
						if (0u != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ X0_v33 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]");
							if ((IntPtr)0 == (IntPtr)0)
							{
								action = InAppPurchasing.PurchaseCompleted;
								if (InAppPurchasing.PurchaseCompleted == null)
								{
									NullReferenceException ex = new NullReferenceException();
									return (PurchaseProcessingResult)ex;
								}
							}
						}
						goto IL_01df;
					}
				}
				else
				{
					Debug.Log("Couldn't purchase product: Invalid receipt.");
					action = InAppPurchasing.PurchaseFailed;
					if (InAppPurchasing.PurchaseFailed != null)
					{
						goto IL_01df;
					}
				}
				goto IL_01f1;
				IL_01f1:
				return default(PurchaseProcessingResult);
				IL_01df:
				action(iAPProductById);
				goto IL_01f1;
			}

			[Token(Token = "0x60009A1")]
			[Address(RVA = "0xBFA180", Offset = "0xBFA180", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public StoreListener()
			{
			}
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000130")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000520")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000521")]
			public static Action<bool> _003C_003E9__58_0;

			[Token(Token = "0x60009A2")]
			[Address(RVA = "0xBFA188", Offset = "0xBFA188", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EB9808]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2022F1A]) = v37;\nL_0015:\n\tv41 = new EasyMobile.InAppPurchasing+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60009A3")]
			[Address(RVA = "0xBFA1EC", Offset = "0xBFA1EC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal void _003CRestorePurchases_003Eb__58_0(bool result)
			{
				//IL_011b: Expected O, but got I
				//IL_004e: Expected I, but got O
				object obj2 = default(object);
				object obj = obj2;
				object obj3 = (long)(IntPtr)obj2 - 4L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E8F14C (inside System.BitConverter::.cctor +0x64)");
				string text = default(string);
				string message = "Restoring IAP purchases result: " + text;
				Debug.Log(message);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ X29_v1-4]");
				Action action;
				if ((IntPtr)0 != (IntPtr)0)
				{
					IntPtr intPtr = (IntPtr)typeof(InAppPurchasing);
					action = InAppPurchasing.RestoreCompleted;
					if (InAppPurchasing.RestoreCompleted == null)
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ X0_v19 (Il2CppClass<EasyMobile.InAppPurchasing>)+12F]");
					if (0u != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ X0_v19 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							action = InAppPurchasing.RestoreCompleted;
							if (InAppPurchasing.RestoreCompleted == null)
							{
								throw new NullReferenceException();
							}
						}
					}
				}
				else
				{
					action = InAppPurchasing.RestoreFailed;
					if (InAppPurchasing.RestoreFailed == null)
					{
						return;
					}
				}
				action();
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x4000254")]
		private static Action m_InitializeSucceeded;

		[CompilerGenerated]
		[Token(Token = "0x4000255")]
		private static Action m_InitializeFailed;

		[CompilerGenerated]
		[Token(Token = "0x4000256")]
		private static Action<IAPProduct> m_PurchaseCompleted;

		[CompilerGenerated]
		[Token(Token = "0x4000257")]
		private static Action<IAPProduct> m_PurchaseFailed;

		[CompilerGenerated]
		[Token(Token = "0x4000258")]
		private static Action<IAPProduct> m_PurchaseDeferred;

		[CompilerGenerated]
		[Token(Token = "0x4000259")]
		private static Action<IAPProduct> m_PromotionalPurchaseIntercepted;

		[CompilerGenerated]
		[Token(Token = "0x400025A")]
		private static Action m_RestoreCompleted;

		[CompilerGenerated]
		[Token(Token = "0x400025B")]
		private static Action m_RestoreFailed;

		[Token(Token = "0x400025C")]
		private static ConfigurationBuilder sBuilder;

		[Token(Token = "0x400025D")]
		private static IStoreController sStoreController;

		[Token(Token = "0x400025E")]
		private static IExtensionProvider sStoreExtensionProvider;

		[Token(Token = "0x400025F")]
		private static IAppleExtensions sAppleExtensions;

		[Token(Token = "0x4000260")]
		private static IGooglePlayStoreExtensions sGooglePlayStoreExtensions;

		[Token(Token = "0x4000261")]
		private static IAmazonExtensions sAmazonExtensions;

		[Token(Token = "0x4000262")]
		private static ISamsungAppsExtensions sSamsungAppsExtensions;

		[Token(Token = "0x4000263")]
		private static StoreListener sStoreListener;

		[Token(Token = "0x4000264")]
		private static bool sIsInitializing;

		[Token(Token = "0x17000161")]
		[field: Token(Token = "0x4000253")]
		public static InAppPurchasing Instance
		{
			[Token(Token = "0x60004A6")]
			[Address(RVA = "0xBF53C0", Offset = "0xBF53C0", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EC5FA0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022EE4]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = EasyMobile.InAppPurchasing;\nL_0024:\n\treturn v49.<Instance>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004A7")]
			[Address(RVA = "0xBF5428", Offset = "0xBF5428", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F0F658]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022EE5]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = EasyMobile.InAppPurchasing;\nL_0021:\n\tv52.<Instance>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000162")]
		public static ConfigurationBuilder Builder
		{
			[Token(Token = "0x60004B8")]
			[Address(RVA = "0xBF6394", Offset = "0xBF6394", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EA9580]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022EF6]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = EasyMobile.InAppPurchasing;\nL_0024:\n\treturn v49.sBuilder;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return sBuilder;
			}
		}

		[Token(Token = "0x17000163")]
		public static IStoreController StoreController
		{
			[Token(Token = "0x60004B9")]
			[Address(RVA = "0xBF63FC", Offset = "0xBF63FC", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F09638]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022EF7]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = EasyMobile.InAppPurchasing;\nL_0024:\n\treturn v49.sStoreController;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return sStoreController;
			}
		}

		[Token(Token = "0x17000164")]
		public static IExtensionProvider StoreExtensionProvider
		{
			[Token(Token = "0x60004BA")]
			[Address(RVA = "0xBF6464", Offset = "0xBF6464", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EA8330]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022EF8]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = EasyMobile.InAppPurchasing;\nL_0024:\n\treturn v49.sStoreExtensionProvider;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return sStoreExtensionProvider;
			}
		}

		[Token(Token = "0x17000165")]
		public static IAppleExtensions AppleStoreExtensions
		{
			[Token(Token = "0x60004BB")]
			[Address(RVA = "0xBF64CC", Offset = "0xBF64CC", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF1580]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022EF9]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = EasyMobile.InAppPurchasing;\nL_0024:\n\treturn v49.sAppleExtensions;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return sAppleExtensions;
			}
		}

		[Token(Token = "0x17000166")]
		public static IGooglePlayStoreExtensions GooglePlayStoreExtensions
		{
			[Token(Token = "0x60004BC")]
			[Address(RVA = "0xBF6534", Offset = "0xBF6534", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EBCEF8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022EFA]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = EasyMobile.InAppPurchasing;\nL_0024:\n\treturn v49.sGooglePlayStoreExtensions;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return sGooglePlayStoreExtensions;
			}
		}

		[Token(Token = "0x17000167")]
		public static IAmazonExtensions AmazonStoreExtensions
		{
			[Token(Token = "0x60004BD")]
			[Address(RVA = "0xBF659C", Offset = "0xBF659C", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EEB318]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022EFB]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = EasyMobile.InAppPurchasing;\nL_0024:\n\treturn v49.sAmazonExtensions;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return sAmazonExtensions;
			}
		}

		[Token(Token = "0x17000168")]
		public static ISamsungAppsExtensions SamsungAppsStoreExtensions
		{
			[Token(Token = "0x60004BE")]
			[Address(RVA = "0xBF6604", Offset = "0xBF6604", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF77E8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022EFC]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = EasyMobile.InAppPurchasing;\nL_0024:\n\treturn v49.sSamsungAppsExtensions;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return sSamsungAppsExtensions;
			}
		}

		[Token(Token = "0x14000024")]
		public static event Action InitializeSucceeded
		{
			[CompilerGenerated]
			[Token(Token = "0x60004A8")]
			[Address(RVA = "0xBF5494", Offset = "0xBF5494", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EFF808]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022EE6]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.InAppPurchasing;\nL_002A:\n\tv107 = System.Delegate::Combine(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.InAppPurchasing;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 8;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_005e: Expected O, but got I
				Delegate obj = InAppPurchasing.m_InitializeSucceeded;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Combine(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 8L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60004A9")]
			[Address(RVA = "0xBF5584", Offset = "0xBF5584", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1F01878]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022EE7]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.InAppPurchasing;\nL_002A:\n\tv107 = System.Delegate::Remove(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.InAppPurchasing;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 8;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_005e: Expected O, but got I
				Delegate obj = InAppPurchasing.m_InitializeSucceeded;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Remove(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 8L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000025")]
		public static event Action InitializeFailed
		{
			[CompilerGenerated]
			[Token(Token = "0x60004AA")]
			[Address(RVA = "0xBF5674", Offset = "0xBF5674", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1ED60A8]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022EE8]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.InAppPurchasing;\nL_002A:\n\tv107 = System.Delegate::Combine(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.InAppPurchasing;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 0x10;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_005e: Expected O, but got I
				Delegate obj = InAppPurchasing.m_InitializeFailed;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Combine(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 16L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60004AB")]
			[Address(RVA = "0xBF5764", Offset = "0xBF5764", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EF17D8]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022EE9]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.InAppPurchasing;\nL_002A:\n\tv107 = System.Delegate::Remove(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.InAppPurchasing;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 0x10;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_005e: Expected O, but got I
				Delegate obj = InAppPurchasing.m_InitializeFailed;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Remove(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 16L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000026")]
		public static event Action<IAPProduct> PurchaseCompleted
		{
			[CompilerGenerated]
			[Token(Token = "0x60004AC")]
			[Address(RVA = "0xBF5854", Offset = "0xBF5854", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EDE250]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022EEA]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.InAppPurchasing;\nL_002A:\n\tv107 = System.Delegate::Combine(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action`1<EasyMobile.IAPProduct>;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.InAppPurchasing;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 0x18;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_005e: Expected O, but got I
				Delegate obj = InAppPurchasing.m_PurchaseCompleted;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Combine(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action<IAPProduct>))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 24L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60004AD")]
			[Address(RVA = "0xBF5944", Offset = "0xBF5944", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EC6000]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022EEB]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.InAppPurchasing;\nL_002A:\n\tv107 = System.Delegate::Remove(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action`1<EasyMobile.IAPProduct>;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.InAppPurchasing;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 0x18;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_005e: Expected O, but got I
				Delegate obj = InAppPurchasing.m_PurchaseCompleted;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Remove(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action<IAPProduct>))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 24L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000027")]
		public static event Action<IAPProduct> PurchaseFailed
		{
			[CompilerGenerated]
			[Token(Token = "0x60004AE")]
			[Address(RVA = "0xBF5A34", Offset = "0xBF5A34", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1ED6098]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022EEC]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.InAppPurchasing;\nL_002A:\n\tv107 = System.Delegate::Combine(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action`1<EasyMobile.IAPProduct>;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.InAppPurchasing;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 0x20;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_005e: Expected O, but got I
				Delegate obj = InAppPurchasing.m_PurchaseFailed;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Combine(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action<IAPProduct>))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 32L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60004AF")]
			[Address(RVA = "0xBF5B24", Offset = "0xBF5B24", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1F02298]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022EED]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.InAppPurchasing;\nL_002A:\n\tv107 = System.Delegate::Remove(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action`1<EasyMobile.IAPProduct>;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.InAppPurchasing;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 0x20;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_005e: Expected O, but got I
				Delegate obj = InAppPurchasing.m_PurchaseFailed;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Remove(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action<IAPProduct>))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 32L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000028")]
		public static event Action<IAPProduct> PurchaseDeferred
		{
			[CompilerGenerated]
			[Token(Token = "0x60004B0")]
			[Address(RVA = "0xBF5C14", Offset = "0xBF5C14", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EAAE98]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022EEE]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.InAppPurchasing;\nL_002A:\n\tv107 = System.Delegate::Combine(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action`1<EasyMobile.IAPProduct>;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.InAppPurchasing;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 0x28;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_005e: Expected O, but got I
				Delegate obj = InAppPurchasing.m_PurchaseDeferred;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Combine(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action<IAPProduct>))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 40L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60004B1")]
			[Address(RVA = "0xBF5D04", Offset = "0xBF5D04", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EBFF60]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022EEF]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.InAppPurchasing;\nL_002A:\n\tv107 = System.Delegate::Remove(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action`1<EasyMobile.IAPProduct>;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.InAppPurchasing;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 0x28;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_005e: Expected O, but got I
				Delegate obj = InAppPurchasing.m_PurchaseDeferred;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Remove(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action<IAPProduct>))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 40L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000029")]
		public static event Action<IAPProduct> PromotionalPurchaseIntercepted
		{
			[CompilerGenerated]
			[Token(Token = "0x60004B2")]
			[Address(RVA = "0xBF5DF4", Offset = "0xBF5DF4", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1F02190]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022EF0]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.InAppPurchasing;\nL_002A:\n\tv107 = System.Delegate::Combine(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action`1<EasyMobile.IAPProduct>;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.InAppPurchasing;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 0x30;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_005e: Expected O, but got I
				Delegate obj = InAppPurchasing.m_PromotionalPurchaseIntercepted;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Combine(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action<IAPProduct>))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 48L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60004B3")]
			[Address(RVA = "0xBF5EE4", Offset = "0xBF5EE4", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EDC558]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022EF1]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.InAppPurchasing;\nL_002A:\n\tv107 = System.Delegate::Remove(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action`1<EasyMobile.IAPProduct>;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.InAppPurchasing;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 0x30;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_005e: Expected O, but got I
				Delegate obj = InAppPurchasing.m_PromotionalPurchaseIntercepted;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Remove(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action<IAPProduct>))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 48L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x1400002A")]
		public static event Action RestoreCompleted
		{
			[CompilerGenerated]
			[Token(Token = "0x60004B4")]
			[Address(RVA = "0xBF5FD4", Offset = "0xBF5FD4", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = *([2022EF2]) & 1;\n\tv21 = v20 == 0;\n\tv22 = ~v21;\n\tif (v22) goto L_001D;\n\tv25 = 0xC097E0(value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\treturn;\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([2022EF2]) = X8;\nL_001D:\n\tgoto L_FFFFFFFF;\n\tv47 = *([v43 @ X0_v1 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_FFFFFFFF;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv51 = EasyMobile.InAppPurchasing;\nL_002B:\n\tv144 = System.Delegate::Combine(v122, value);\n\tv114 = v144 == 0;\n\tif (v114) goto L_0040;\n\tv70 = *([v144 @ X0_v5 (System.Delegate)]) != System.Action;\n\tif (v70) goto L_0062;\nL_0040:\n\tgoto L_004A;\n\tv162 = *([v157 @ X0_v6 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv163 = v162 == 0;\n\tv164 = ~v163;\n\tif (v164) goto L_004A;\n\tv169 = \"il2cpp_codegen_runtime_class_init\"(v157, v155, v60, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv166 = EasyMobile.InAppPurchasing;\nL_004A:\n\tv168 = v165.<Instance>k__BackingField + 0x38;\n\tv110 = 0x874190(v168, v144, v122, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv69 = v122 != v110;\n\tif (v69) goto L_002B;\n\treturn;\nL_0062:\n\tthrow System.InvalidCastException;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_00a2: Expected O, but got I
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [2022EF2]");
				if (0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @C097E0 (inside EasyMobile.Internal.Privacy.ConsentDialogContentSerializer+SplitContent::IsButton +0x68)");
					return;
				}
				Delegate obj = InAppPurchasing.m_RestoreCompleted;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Combine(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 56L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60004B5")]
			[Address(RVA = "0xBF60C4", Offset = "0xBF60C4", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EB04D8]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022EF3]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.InAppPurchasing;\nL_002A:\n\tv107 = System.Delegate::Remove(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.InAppPurchasing;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 0x38;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_005e: Expected O, but got I
				Delegate obj = InAppPurchasing.m_RestoreCompleted;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Remove(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 56L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x1400002B")]
		public static event Action RestoreFailed
		{
			[CompilerGenerated]
			[Token(Token = "0x60004B6")]
			[Address(RVA = "0xBF61B4", Offset = "0xBF61B4", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1F0EB20]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022EF4]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.InAppPurchasing;\nL_002A:\n\tv107 = System.Delegate::Combine(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.InAppPurchasing;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 0x40;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_005e: Expected O, but got I
				Delegate obj = InAppPurchasing.m_RestoreFailed;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Combine(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 64L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60004B7")]
			[Address(RVA = "0xBF62A4", Offset = "0xBF62A4", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EF8AA0]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022EF5]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.InAppPurchasing;\nL_002A:\n\tv107 = System.Delegate::Remove(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.InAppPurchasing;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 0x40;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_005e: Expected O, but got I
				Delegate obj = InAppPurchasing.m_RestoreFailed;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Remove(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 64L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x60004BF")]
		[Address(RVA = "0xBF666C", Offset = "0xBF666C", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1ECB388]);\n\tv23 = *([v22 @ X8_v32]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022EFD]) = v42;\nL_001B:\n\tgoto L_0025;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0025;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0025:\n\tgoto L_0030;\n\tv61 = *([1EDEDD8]);\n\tv62 = *([v61 @ X8_v28]);\n\tv63 = \"il2cpp_codegen_initialize_method\"(v62, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv66 = 0 | 1;\n\t*([2023015]) = v66;\nL_0030:\n\tgoto L_003F;\n\tv71 = *([v67 @ X0_v5 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv72 = v71 == 0;\n\tv73 = ~v72;\n\tgoto L_003F;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v67, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv75 = EasyMobile.InAppPurchasing;\nL_003F:\n\tgoto L_0049;\n\tv87 = *([v81 @ X8_v9+E0]);\n\tv88 = v87 == 0;\n\tv89 = ~v88;\n\tgoto L_0049;\n\tv98 = v81;\n\tv92 = \"il2cpp_codegen_runtime_class_init\"(v98, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0049:\n\tv97 = UnityEngine.Object::op_Inequality(v80.<Instance>k__BackingField, 0);\n\tv100 = v97 == 0;\n\tif (v100) goto L_0066;\n\tgoto L_0060;\n\tv109 = *([v101 @ X0_v20+E0]);\n\tv110 = v109 == 0;\n\tv111 = ~v110;\n\tif (v111) goto L_0060;\n\tv113 = \"il2cpp_codegen_runtime_class_init\"(v101, v95, v96, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0060:\n\tUnityEngine.Object::Destroy(this);\n\treturn;\nL_0066:\n\tgoto L_0070;\n\tv124 = *([v105 @ X0_v10+E0]);\n\tv125 = v124 == 0;\n\tv126 = ~v125;\n\tif (v126) goto L_0070;\n\tv128 = \"il2cpp_codegen_runtime_class_init\"(v105, v95, v96, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0070:\n\tgoto L_007B;\n\tv136 = *([1EE6290]);\n\tv137 = *([v136 @ X8_v19]);\n\tv138 = \"il2cpp_codegen_initialize_method\"(v137, v95, v96, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv141 = 0 | 1;\n\t*([2023016]) = v141;\nL_007B:\n\tgoto L_0083;\n\tv165 = *([v142 @ X0_v13 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv166 = v165 == 0;\n\tv167 = ~v166;\n\tgoto L_0083;\n\tv170 = \"il2cpp_codegen_runtime_class_init\"(v142, v95, v96, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv168 = EasyMobile.InAppPurchasing;\nL_0083:\n\tv160.<Instance>k__BackingField = this;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			if (Instance != null)
			{
				UnityEngine.Object.Destroy(this);
			}
			else
			{
				Instance = this;
			}
		}

		[Token(Token = "0x60004C0")]
		[Address(RVA = "0xBF67E4", Offset = "0xBF67E4", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = *([1F01758]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022EFE]) = v35;\nL_0012:\n\tv37 = EasyMobile.EM_Settings::get_InAppPurchasing();\n\tv40 = ~v37.mAutoInit;\n\tif (v40) goto L_002E;\n\tgoto L_0028;\n\tv51 = *([v44 @ X0_v5 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_0028;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0028:\n\tEasyMobile.InAppPurchasing::InitializePurchasing();\n\treturn;\nL_002E:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			IAPSettings inAppPurchasing = EM_Settings.InAppPurchasing;
			if (inAppPurchasing.IsAutoInit)
			{
				InitializePurchasing();
			}
		}

		[Token(Token = "0x60004C1")]
		[Address(RVA = "0xBF6864", Offset = "0xBF6864", Length = "0x66C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv32 = *([1EF13E8]);\n\tv33 = *([v32 @ X8_v142]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv53 = 0 | 1;\n\t*([2022EFF]) = v53;\nL_0020:\n\tgoto L_0026;\n\tv60 = *([v56 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_0026;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v56, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0026:\n\tv67 = EasyMobile.InAppPurchasing::IsInitialized();\n\tv69 = v67 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_004F;\n\tgoto L_003C;\n\tv98 = *([v73 @ X0_v6 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv99 = v98 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_003C;\n\tv223 = \"il2cpp_codegen_runtime_class_init\"(v73, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv101 = EasyMobile.InAppPurchasing;\nL_003C:\n\tv106 = v85.sIsInitializing + 7;\n\tv107 = ~v106;\n\tv78 = v107 & 7;\n\tv83 = v78 == 0;\n\tif (v83) goto L_0053;\nL_004F:\n\treturn;\nL_0053:\n\tgoto L_005E;\n\tv228 = *([v81 @ X0_v7 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv229 = v228 == 0;\n\tv230 = ~v229;\n\tif (v230) goto L_005E;\n\tv233 = \"il2cpp_codegen_runtime_class_init\"(v81, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv255 = EasyMobile.InAppPurchasing;\n\tv236 = *([v255 @ X8_v134+B8]);\nL_005E:\n\tv235.sIsInitializing = 1;\n\tgoto L_006C;\n\tv244 = *([v240 @ X0_v9+E0]);\n\tv245 = v244 == 0;\n\tv246 = ~v245;\n\tgoto L_006C;\n\tv248 = \"il2cpp_codegen_runtime_class_init\"(v240, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_006C:\n\tv252 = UnityEngine.Purchasing.StandardPurchasingModule::Instance();\n\tv261 = Il2CppClass<System.EmptyArray`1<UnityEngine.Purchasing.Extension.IPurchasingModule>>;\n\tgoto L_007B;\n\tv266 = v261;\n\tv267 = 0x8907BC(v266, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv270 = *([v261 @ X20_v2 (Il2CppClass<System.EmptyArray`1<UnityEngine.Purchasing.Extension.IPurchasingModule>>)+12E]);\nL_007B:\n\tv271 = *([v261 @ X20_v2 (Il2CppClass<System.EmptyArray`1<UnityEngine.Purchasing.Extension.IPurchasingModule>>)+12E]) & 0x200;\n\tv272 = v271 == 0;\n\tif (v272) goto L_009C;\n\tv274 = Il2CppClass<System.EmptyArray`1<UnityEngine.Purchasing.Extension.IPurchasingModule>>;\n\tgoto L_0088;\n\tv296 = v274;\n\tv297 = 0x8907BC(v296, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0088:\n\tv298 = *([v274 @ X20_v20 (Il2CppClass<System.EmptyArray`1<UnityEngine.Purchasing.Extension.IPurchasingModule>>)+E0]) == 0;\n\tv286 = ~v298;\n\tif (v286) goto L_009C;\n\tgoto L_009C;\n\tv316 = v280;\n\tv317 = 0x8907BC(v316, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_009C:\n\tgoto L_00A3;\n\tv299 = v291;\n\tv300 = 0x8907BC(v299, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_00A3:\n\tv306 = UnityEngine.Purchasing.ConfigurationBuilder::Instance(v252, v302.Value);\n\tv313.sBuilder = v306;\n\tv315 = EasyMobile.EM_Settings::get_InAppPurchasing();\n\tv321 = v315.mProducts;\n\tv650 = v321.Length;\n\tv482 = v321.Length < 1;\n\tif (v482) goto L_01A6;\nL_00C0:\n\tv662 = v419 < v650;\n\tv395 = ~v662;\n\tif (v395) goto L_02A9;\n\tv416 = v321[v419 @ X25_v9 (System.Int32)];\n\tv706 = v416._storeSpecificIds;\n\tv707 = v416._storeSpecificIds == 0;\n\tif (v707) goto L_016D;\n\tv710 = v706.Length == 0;\n\tif (v710) goto L_016D;\n\tv544 = new UnityEngine.Purchasing.IDs();\n\tUnityEngine.Purchasing.IDs::.ctor(v544);\n\tv422 = v416._storeSpecificIds;\n\tv651 = v422.Length;\n\tv833 = v422.Length < 1;\n\tif (v833) goto L_013B;\nL_00ED:\n\tv904 = v531 < v651;\n\tv510 = ~v904;\n\tif (v510) goto L_02A9;\n\tv533 = v422[v531 @ X23_v12 (System.Int32)];\n\t// 255 NewArr v944 @ X0_v92 (System.String[]), typeof(System.String[]), 1\n\tgoto L_0110;\n\tv1012 = *([v563 @ X8_v120+E0]);\n\tv1013 = v1012 == 0;\n\tv1014 = ~v1013;\n\tif (v1014) goto L_0110;\n\tv1028 = v563;\n\tv1016 = \"il2cpp_codegen_runtime_class_init\"(v1028, v514, v519, v489, v332, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0110:\n\tv546 = EasyMobile.InAppPurchasing::GetStoreName(v533.store);\n\tv1034 = v546 == 0;\n\tif (v1034) goto L_011D;\n\t// 281 IsInst v1066 @ X0_v99, typeof(System.String), v546 @ X0_v95 (System.String)\nL_011D:\n\tv648 = v944.Length == 0;\n\tif (v648) goto L_02A9;\n\tv944[0] = v546;\n\tUnityEngine.Purchasing.IDs::Add(v544, v533.id, v944);\n\tv651 = v422.Length;\n\tv531 = v531 + 1;\n\tv843 = v531 < v422.Length;\n\tif (v843) goto L_00ED;\nL_013B:\n\tgoto L_014E;\n\tv905 = *([v862 @ X0_v84 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv906 = v905 == 0;\n\tv907 = ~v906;\n\t// 319 ConditionalJump @b131, v907 @ TEMP_v86\n\tv919 = \"il2cpp_codegen_runtime_class_init\"(v862, v399, v404, v335, v332, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv909 = EasyMobile.InAppPurchasing;\nL_014E:\n\tv922 = v416._type - 1;\n\tv924 = v922 == 0;\n\tv866 = v416._type != 2;\n\tif (v866) goto L_FFFFFFFF;\n\tgoto L_0165;\nL_0165:\n\tv889 = UnityEngine.Purchasing.ConfigurationBuilder::AddProduct(v462.sBuilder, v416._id, v405, v544);\n\tgoto L_0197;\nL_016D:\n\tgoto L_017F;\n\tv757 = *([v715 @ X0_v75 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv758 = v757 == 0;\n\tv759 = ~v758;\n\t// 369 ConditionalJump @b133, v759 @ TEMP_v77\n\tv778 = \"il2cpp_codegen_runtime_class_init\"(v715, v400, v405, v336, v332, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv761 = EasyMobile.InAppPurchasing;\nL_017F:\n\tv784 = v416._type - 1;\n\tv786 = v784 == 0;\n\tv801 = v416._type != 2;\n\tif (v801) goto L_FFFFFFFF;\n\tgoto L_0196;\nL_0196:\n\tv835 = UnityEngine.Purchasing.ConfigurationBuilder::AddProduct(v463.sBuilder, v416._id, v405);\nL_0197:\n\tv650 = v321.Length;\n\tv419 = v419 + 1;\n\tv579 = v419 < v321.Length;\n\tif (v579) goto L_00C0;\nL_01A6:\n\tv612 = UnityEngine.Application::get_platform();\n\tv343 = v612 != 8;\n\tif (v343) goto L_0211;\n\tv443 = EasyMobile.EM_Settings::get_InAppPurchasing();\n\tv694 = ~v443.mInterceptApplePromotionalPurchases;\n\tif (v694) goto L_0211;\n\tgoto L_01CF;\n\tv802 = *([v767 @ X0_v59 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv803 = v802 == 0;\n\tv804 = ~v803;\n\t// 451 ConditionalJump @b137, v804 @ TEMP_v66\n\tv815 = \"il2cpp_codegen_runtime_class_init\"(v767, v397, v402, v334, v126, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv806 = EasyMobile.InAppPurchasing;\nL_01CF:\n\tv819 = UnityEngine.Purchasing.ConfigurationBuilder::Configure(v464.sBuilder);\n\tv548 = new System.Action`1<UnityEngine.Purchasing.Product>();\n\tSystem.Action`1<UnityEngine.Purchasing.Product>::.ctor(v548, 0, Il2CppMethodInfo);\n\tgoto L_020F;\n\tv948 = *([v931 @ X8_v80+B0]);\n\tv949 = 0;\n\tv950 = v948 + 8;\n\tv952 = *([v988 @ X11_v17-8]);\n\tv1003 = v952 == v934;\n\tif (v1003) goto L_0207;\n\tv956 = v989 + 1;\n\tv1019 = v956 < v933;\n\tv974 = ~v1019;\n\tv954 = v988 + 0x10;\n\tv958 = ~v974;\n\tif (v958) goto L_FFFFFFFF;\n\tv975 = v568;\n\tv976 = 0;\n\tv977 = 0x8909C4(v975, v934, v976, v490, v126, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_020F;\nL_0207:\n\tv1020 = *([v988 @ X11_v17]);\n\tv1021 = v1020 << 4;\n\tv1022 = v931 + v1021;\n\tv1023 = v1022 + 0x130;\nL_020F:\n\tUnityEngine.Purchasing.IAppleConfiguration::SetApplePromotionalPurchaseInterceptorCallback(v819, v548);\nL_0211:\n\tv698 = UnityEngine.Application::get_platform();\n\tv344 = v698 != 0xB;\n\tif (v344) goto L_028B;\n\tv444 = EasyMobile.EM_Settings::get_InAppPurchasing();\n\tv345 = v444.mTargetAndroidStore != 1;\n\tif (v345) goto L_028B;\n\tv445 = EasyMobile.EM_Settings::get_InAppPurchasing();\n\tv744 = ~v445.mEnableAmazonSandboxTesting;\n\tif (v744) goto L_028B;\n\tgoto L_024A;\n\tv935 = *([v915 @ X0_v45 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv936 = v935 == 0;\n\tv937 = ~v936;\n\t// 574 ConditionalJump @b141, v937 @ TEMP_v56\n\tv978 = \"il2cpp_codegen_runtime_class_init\"(v915, v398, v403, v129, v126, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv939 = EasyMobile.InAppPurchasing;\nL_024A:\n\tv549 = UnityEngine.Purchasing.ConfigurationBuilder::Configure(v465.sBuilder);\n\tv525 = v566.sBuilder;\n\tgoto L_0284;\n\tv1035 = *([v1030 @ X8_v60+B0]);\n\tv1036 = 0;\n\tv1037 = v1035 + 8;\n\tv1039 = *([v1070 @ X11_v11-8]);\n\tv1085 = v1039 == v1033;\n\tif (v1085) goto L_027C;\n\tv1043 = v1071 + 1;\n\tv1090 = v1043 < v1032;\n\tv1061\n// ... truncated")]
		public static void InitializePurchasing()
		{
			//IL_0506: Expected O, but got I4
			//IL_050f: Expected I4, but got O
			if (IsInitialized())
			{
				return;
			}
			object obj = (sIsInitializing ? 1 : 0) + 7;
			int num = (int)(~obj);
			if ((num & 7) != 0)
			{
				return;
			}
			sIsInitializing = true;
			StandardPurchasingModule first = StandardPurchasingModule.Instance();
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ X20_v2 (Il2CppClass<System.EmptyArray`1<UnityEngine.Purchasing.Extension.IPurchasingModule>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ X20_v20 (Il2CppClass<System.EmptyArray`1<UnityEngine.Purchasing.Extension.IPurchasingModule>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			ConfigurationBuilder configurationBuilder = ConfigurationBuilder.Instance(first);
			sBuilder = configurationBuilder;
			IAPSettings inAppPurchasing = EM_Settings.InAppPurchasing;
			IAPProduct[] products = inAppPurchasing.Products;
			int num2 = products.Length;
			if (products.Length >= 1)
			{
				ProductType productType = default(ProductType);
				int num3 = 0;
				IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
				do
				{
					IAPProduct iAPProduct;
					IDs ds;
					if (num3 < num2)
					{
						iAPProduct = products[num3];
						IAPProduct.StoreSpecificId[] storeSpecificIds = iAPProduct.StoreSpecificIds;
						if (iAPProduct.StoreSpecificIds == null || storeSpecificIds.Length == 0)
						{
							int num4 = (int)(iAPProduct.Type - 1);
							bool flag = num4 == 0;
							productType = ((iAPProduct.Type != IAPProductType.Subscription) ? (flag ? ProductType.NonConsumable : ProductType.Consumable) : ((ProductType)iAPProduct.Type));
							ConfigurationBuilder configurationBuilder2 = sBuilder.AddProduct(iAPProduct.Id, productType);
							goto IL_039c;
						}
						ds = new IDs();
						IAPProduct.StoreSpecificId[] storeSpecificIds2 = iAPProduct.StoreSpecificIds;
						int num5 = storeSpecificIds2.Length;
						if (storeSpecificIds2.Length < 1)
						{
							goto IL_02cb;
						}
						int num6 = 0;
						while (num6 < num5)
						{
							IAPProduct.StoreSpecificId storeSpecificId = storeSpecificIds2[num6];
							string[] array = new string[1];
							string storeName = GetStoreName(storeSpecificId.store);
							if (storeName != null)
							{
								object obj2 = storeName as string;
							}
							if (array.Length == 0)
							{
								break;
							}
							array[0] = storeName;
							ds.Add(storeSpecificId.id, array);
							num5 = storeSpecificIds2.Length;
							num6++;
							if (num6 < storeSpecificIds2.Length)
							{
								continue;
							}
							goto IL_02cb;
						}
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex2;
					IL_039c:
					num2 = products.Length;
					num3++;
					continue;
					IL_02cb:
					int num7 = (int)(iAPProduct.Type - 1);
					bool flag2 = num7 == 0;
					productType = ((iAPProduct.Type != IAPProductType.Subscription) ? (flag2 ? ProductType.NonConsumable : ProductType.Consumable) : ((ProductType)iAPProduct.Type));
					ConfigurationBuilder configurationBuilder3 = sBuilder.AddProduct(iAPProduct.Id, productType, ds);
					goto IL_039c;
				}
				while (num3 < products.Length);
			}
			RuntimePlatform platform = Application.platform;
			if (platform == RuntimePlatform.IPhonePlayer)
			{
				IAPSettings inAppPurchasing2 = EM_Settings.InAppPurchasing;
				if (inAppPurchasing2.InterceptApplePromotionalPurchases)
				{
					IAppleConfiguration appleConfiguration = sBuilder.Configure<IAppleConfiguration>();
					Action<Product> applePromotionalPurchaseInterceptorCallback = OnApplePromotionalPurchase;
					appleConfiguration.SetApplePromotionalPurchaseInterceptorCallback(applePromotionalPurchaseInterceptorCallback);
				}
			}
			RuntimePlatform platform2 = Application.platform;
			if (platform2 == RuntimePlatform.Android)
			{
				IAPSettings inAppPurchasing3 = EM_Settings.InAppPurchasing;
				if (inAppPurchasing3.TargetAndroidStore == IAPAndroidStore.AmazonAppStore)
				{
					IAPSettings inAppPurchasing4 = EM_Settings.InAppPurchasing;
					if (inAppPurchasing4.EnableAmazonSandboxTesting)
					{
						IAmazonConfiguration amazonConfiguration = sBuilder.Configure<IAmazonConfiguration>();
						ConfigurationBuilder configurationBuilder4 = sBuilder;
						amazonConfiguration.WriteSandboxJSON(configurationBuilder4.products);
					}
				}
			}
			UnityPurchasing.Initialize(sStoreListener, sBuilder);
		}

		[Token(Token = "0x60004C2")]
		[Address(RVA = "0xBF6ED0", Offset = "0xBF6ED0", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EDC4B0]);\n\tv15 = *([v14 @ X8_v13]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022F00]) = v35;\nL_0017:\n\tgoto L_0020;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0020;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = EasyMobile.InAppPurchasing;\nL_0020:\n\tv51 = v49.sStoreController == 0;\n\tif (v51) goto L_FFFFFFFF;\n\tgoto L_0032;\n\tv57 = *([v45 @ X0_v3 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_0032;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v45, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv103 = EasyMobile.InAppPurchasing;\n\tv65 = *([v103 @ X8_v9+B8]);\nL_0032:\n\tv71 = v64.sStoreExtensionProvider == 0;\n\tv76 = ~v71;\n\tgoto L_003F;\nL_003F:\n\treturn returnVal1;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsInitialized()
		{
			if (sStoreController == null)
			{
				return false;
			}
			bool flag = sStoreExtensionProvider == null;
			return !flag;
		}

		[Token(Token = "0x60004C3")]
		[Address(RVA = "0xBF6FEC", Offset = "0xBF6FEC", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EA7538]);\n\tv19 = *([v18 @ X8_v17]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F01]) = v38;\nL_0013:\n\tv39 = product == 0;\n\tif (v39) goto L_0032;\n\tv41 = product._id == 0;\n\tif (v41) goto L_0032;\n\tgoto L_002A;\n\tv71 = *([v52 @ X0_v6+E0]);\n\tv72 = v71 == 0;\n\tv73 = ~v72;\n\tif (v73) goto L_002A;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v52, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002A:\n\tEasyMobile.InAppPurchasing::PurchaseWithId(product._id);\n\treturn;\nL_0032:\n\tgoto L_0041;\n\tv56 = *([v46 @ X0_v2+E0]);\n\tv57 = v56 == 0;\n\tv58 = ~v57;\n\tif (v58) goto L_0041;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0041:\n\tUnityEngine.Debug::Log(\"IAP purchasing failed: product or product ID is null.\");\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Purchase(IAPProduct product)
		{
			if (product != null && product.Id != null)
			{
				PurchaseWithId(product.Id);
			}
			else
			{
				Debug.Log("IAP purchasing failed: product or product ID is null.");
			}
		}

		[Token(Token = "0x60004C4")]
		[Address(RVA = "0xBF730C", Offset = "0xBF730C", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EACAB8]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022F02]) = v40;\nL_001A:\n\tgoto L_0021;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0021;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0021:\n\tv55 = EasyMobile.InAppPurchasing::GetIAPProductByName(productName);\n\tv56 = v55 == 0;\n\tif (v56) goto L_0042;\n\tv58 = v55._id == 0;\n\tif (v58) goto L_0042;\n\tgoto L_0038;\n\tv81 = *([v70 @ X0_v12+E0]);\n\tv82 = v81 == 0;\n\tv83 = ~v82;\n\tif (v83) goto L_0038;\n\tv85 = \"il2cpp_codegen_runtime_class_init\"(v70, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0038:\n\tEasyMobile.InAppPurchasing::PurchaseWithId(v55._id);\n\treturn;\nL_0042:\n\tv69 = System.String::Concat(\"IAP purchasing failed: Not found product with name: \", productName, \" or its ID is invalid.\");\n\tgoto L_0059;\n\tv94 = *([v77 @ X8_v9+E0]);\n\tv95 = v94 == 0;\n\tv96 = ~v95;\n\tif (v96) goto L_0059;\n\tv108 = v77;\n\tv99 = \"il2cpp_codegen_runtime_class_init\"(v108, v65, v68, v66, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0059:\n\tUnityEngine.Debug::Log(v69);\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Purchase(string productName)
		{
			IAPProduct iAPProductByName = GetIAPProductByName(productName);
			if (iAPProductByName != null && iAPProductByName.Id != null)
			{
				PurchaseWithId(iAPProductByName.Id);
				return;
			}
			string message = "IAP purchasing failed: Not found product with name: " + productName + " or its ID is invalid.";
			Debug.Log(message);
		}

		[Token(Token = "0x60004C5")]
		[Address(RVA = "0xBF7098", Offset = "0xBF7098", Length = "0x274")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EADA20]);\n\tv23 = *([v22 @ X8_v48]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022F03]) = v42;\nL_001B:\n\tgoto L_0021;\n\tv49 = *([v45 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0021;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0021:\n\tv56 = EasyMobile.InAppPurchasing::IsInitialized();\n\tv58 = v56 == 0;\n\tif (v58) goto L_0060;\n\tgoto L_003A;\n\tv69 = *([v59 @ X0_v10 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\t// 45 ConditionalJump @b50, v71 @ TEMP_v45\n\tv88 = \"il2cpp_codegen_runtime_class_init\"(v59, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv73 = EasyMobile.InAppPurchasing;\nL_003A:\n\tgoto L_0070;\n\tv192 = *([v90 @ X8_v18+B0]);\n\tv193 = 0;\n\tv194 = v192 + 8;\n\tv196 = *([v261 @ X11_v14-8]);\n\tv266 = v196 == v93;\n\tif (v266) goto L_0069;\n\tv216 = v260 + 1;\n\tv323 = v216 < v92;\n\tv214 = ~v323;\n\tv218 = v261 + 0x10;\n\tv198 = ~v214;\n\tif (v198) goto L_FFFFFFFF;\n\tv219 = v77;\n\tv220 = 0;\n\tv221 = 0x8909C4(v219, v93, v220, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0070;\nL_0060:\n\tgoto L_FFFFFFFF;\n\tv79 = *([v65 @ X0_v7+E0]);\n\tv80 = v79 == 0;\n\tv81 = ~v80;\n\tif (v81) goto L_FFFFFFFF;\n\tv83 = \"il2cpp_codegen_runtime_class_init\"(v65, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_00E0;\nL_0069:\n\tv324 = *([v261 @ X11_v14]);\n\tv325 = v324 << 4;\n\tv326 = v90 + v325;\n\tv327 = v326 + 0x130;\nL_0070:\n\tv242 = UnityEngine.Purchasing.IStoreController::get_products(v76.sStoreController);\n\tv146 = UnityEngine.Purchasing.ProductCollection::WithID(v242, productId);\n\tv331 = v146 == 0;\n\tif (v331) goto L_00CF;\n\tv333 = ~v146.<availableToPurchase>k__BackingField;\n\tif (v333) goto L_00CF;\n\tv154 = v146.<definition>k__BackingField;\n\tv352 = System.String::Concat(\"Purchasing product asychronously: \", v154.<id>k__BackingField);\n\tgoto L_0095;\n\tv360 = *([v356 @ X8_v35+E0]);\n\tv361 = v360 == 0;\n\tv362 = ~v361;\n\tif (v362) goto L_0095;\n\tv367 = v356;\n\tv364 = \"il2cpp_codegen_runtime_class_init\"(v367, v348, v103, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0095:\n\tUnityEngine.Debug::Log(v352);\n\tgoto L_00A2;\n\tv372 = *([v368 @ X0_v27 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv373 = v372 == 0;\n\tv374 = ~v373;\n\tif (v374) goto L_00A2;\n\tv378 = \"il2cpp_codegen_runtime_class_init\"(v368, v139, v103, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv375 = EasyMobile.InAppPurchasing;\nL_00A2:\n\tv157 = v155.sStoreController;\n\tv379 = *([v157 @ X20_v8 (UnityEngine.Purchasing.IStoreController)]);\n\tv314 = *([v379 @ X8_v39 (Il2CppClass<UnityEngine.Purchasing.IStoreController>)+126]) == 0;\n\tif (v314) goto L_00C7;\n\tv423 = *([v379 @ X8_v39 (Il2CppClass<UnityEngine.Purchasing.IStoreController>)+B0]) + 8;\nL_00B2:\n\tv428 = *([v423 @ X11_v9-8]) == UnityEngine.Purchasing.IStoreController;\n\tif (v428) goto L_00E3;\n\tv422 = v422 + 1;\n\tv433 = v422 < *([v379 @ X8_v39 (Il2CppClass<UnityEngine.Purchasing.IStoreController>)+126]);\n\tv404 = ~v433;\n\tv423 = v423 + 0x10;\n\tv388 = ~v404;\n\tif (v388) goto L_00B2;\nL_00C7:\n\tv440 = 0x8909C4(v157, UnityEngine.Purchasing.IStoreController, 2, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_00E7;\nL_00CF:\n\tgoto L_FFFFFFFF;\n\tv342 = *([v338 @ X0_v20+E0]);\n\tv343 = v342 == 0;\n\tv344 = ~v343;\n\tif (v344) goto L_FFFFFFFF;\n\tv345 = \"il2cpp_codegen_runtime_class_init\"(v338, v138, v102, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00E0:\n\tUnityEngine.Debug::Log(*([v181 @ X8_v5 (System.String)]));\n\treturn;\nL_00E3:\n\tv435 = *([v423 @ X11_v9]) + 2;\n\tv436 = v435 << 4;\n\tv437 = v379 + v436;\n\tv440 = v437 + 0x130;\nL_00E7:\n\tv272 = *([v440 @ X0_v29]);\n\tv282 = *([v440 @ X0_v29+8]);\n\t// 242 IndirectJump v272 @ X3_v1, v157 @ X20_v8 (UnityEngine.Purchasing.IStoreController), v157 @ X20_v8 (UnityEngine.Purchasing.IStoreController), v146 @ X0_v19 (UnityEngine.Purchasing.Product), v282 @ X2_v8, v272 @ X3_v1, v28 @ X4, v29 @ X5, v30 @ X6, v31 @ X7, v32 @ V0, v33 @ V1, v34 @ V2, v35 @ V3, v36 @ V4, v37 @ V5, v38 @ V6, v39 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 141 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void PurchaseWithId(string productId)
		{
			//IL_00d8: Expected I, but got O
			//IL_024b: Expected O, but got I
			//IL_0113: Expected O, but got I
			//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a8: Expected O, but got Unknown
			//IL_01c5: Expected O, but got I
			//IL_01d4: Expected O, but got I
			//IL_015f: Expected O, but got I
			string message;
			object obj4 = default(object);
			if (!IsInitialized())
			{
				message = "IAP purchasing failed: In-App Purchasing is not initialized.";
			}
			else
			{
				ProductCollection products = sStoreController.products;
				Product product = products.WithID(productId);
				if (product != null && product.availableToPurchase)
				{
					ProductDefinition definition = product.definition;
					string message2 = "Purchasing product asychronously: " + definition.id;
					Debug.Log(message2);
					IStoreController storeController = sStoreController;
					IntPtr intPtr = (IntPtr)storeController;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ X8_v39 (Il2CppClass<UnityEngine.Purchasing.IStoreController>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_0178;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ X8_v39 (Il2CppClass<UnityEngine.Purchasing.IStoreController>)+B0]");
					object obj = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ X11_v9-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IStoreController))
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ X8_v39 (Il2CppClass<UnityEngine.Purchasing.IStoreController>)+126]");
						bool flag = (long)num2 < 0L;
						bool flag2 = !flag;
						obj = (long)(IntPtr)obj + 16L;
						if (!flag2)
						{
							continue;
						}
						goto IL_0178;
					}
					object obj2 = obj + 2;
					int num3 = (int)((long)(IntPtr)obj2 << 4);
					object obj3 = (long)intPtr + (long)num3;
					obj4 = (long)(IntPtr)obj3 + 304L;
					goto IL_0233;
				}
				message = "IAP purchasing failed: product not found or not available for purchase.";
			}
			Debug.Log(message);
			return;
			IL_0178:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0233;
			IL_0233:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v440 @ X0_v29+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v272 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60004C6")]
		[Address(RVA = "0xBF74B0", Offset = "0xBF74B0", Length = "0x32C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv20 = *([1EA5FA0]);\n\tv21 = *([v20 @ X8_v51]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([2022F04]) = v41;\n\tgoto L_0021;\n\tv49 = *([v45 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0021;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0021:\n\tv56 = EasyMobile.InAppPurchasing::IsInitialized();\n\tv58 = v56 == 0;\n\tif (v58) goto L_007A;\n\tv60 = UnityEngine.Application::get_platform();\n\tv71 = v60 == 8;\n\tif (v71) goto L_0042;\n\tv87 = UnityEngine.Application::get_platform();\n\tv89 = v87 != 1;\n\tif (v89) goto L_0087;\nL_0042:\n\tgoto L_004A;\n\tv150 = *([v108 @ X0_v16 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv151 = v150 == 0;\n\tv152 = ~v151;\n\tif (v152) goto L_004A;\n\tv162 = \"il2cpp_codegen_runtime_class_init\"(v108, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv154 = EasyMobile.InAppPurchasing;\nL_004A:\n\tv158 = v157.sStoreExtensionProvider;\n\tv165 = *([v158 @ X19_v8 (UnityEngine.Purchasing.IExtensionProvider)]);\n\tv166 = Il2CppMethodInfo;\n\tv170 = *([v165 @ X8_v19 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]) == 0;\n\tif (v170) goto L_0072;\n\tv367 = *([v165 @ X8_v19 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]) + 8;\nL_005E:\n\tv381 = *([v367 @ X11_v14-8]) == Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>;\n\tif (v381) goto L_00B3;\n\tv366 = v366 + 1;\n\tv393 = v366 < *([v165 @ X8_v19 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]);\n\tv307 = ~v393;\n\tv367 = v367 + 0x10;\n\tv291 = ~v307;\n\tif (v291) goto L_005E;\nL_0072:\n\tv401 = System.Action`1<System.Boolean>::.ctor(v158, Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>, *([v166 @ X20_v6 (Il2CppMethodInfo)+48]));\n\tgoto L_00B9;\nL_007A:\n\tgoto L_FFFFFFFF;\n\tv76 = *([v63 @ X0_v7+E0]);\n\tv77 = v76 == 0;\n\tv78 = ~v77;\n\tif (v78) goto L_FFFFFFFF;\n\tv80 = \"il2cpp_codegen_runtime_class_init\"(v63, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0084:\n\tUnityEngine.Debug::Log(v140);\n\tgoto L_0129;\nL_0087:\n\tv161 = UnityEngine.Application::get_platform();\n\t// 142 Box v52 @ X0_v3 (Il2CppClass<EasyMobile.InAppPurchasing>), typeof(UnityEngine.RuntimePlatform), &v161 @ X0_v48 (UnityEngine.RuntimePlatform)\n\tv386 = *([v52 @ X0_v3 (Il2CppClass<EasyMobile.InAppPurchasing>)]);\n\t*([v386 @ X8_v43+160])(v390, v52, *([v386 @ X8_v43+168]), v24, v177, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv52 = \"il2cpp_vm_object_unbox\"(v52, *([v386 @ X8_v43+168]), v24, v177, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv140 = System.String::Concat(\"Couldn't restore IAP purchases: not supported on platform \", v390);\n\tgoto L_00B1;\n\tv439 = *([v145 @ X8_v47+E0]);\n\tv440 = v439 == 0;\n\tv441 = ~v440;\n\tif (v441) goto L_00B1;\n\tv459 = v145;\n\tv443 = \"il2cpp_codegen_runtime_class_init\"(v459, v117, v115, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00B1:\n\tgoto L_0084;\nL_00B3:\n\tv395 = *([v367 @ X11_v14]) + *([v166 @ X20_v6 (Il2CppMethodInfo)+48]);\n\tv396 = v395 << 4;\n\tv397 = v165 + v396;\n\tv401 = v397 + 0x130;\nL_00B9:\n\tv405 = UnityEngine.Purchasing.IExtensionProvider::GetExtension(*([v401 @ X0_v20 (System.Action`1<System.Boolean>)+8]));\n\t*([v405 @ X0_v22 (UnityEngine.Purchasing.IAppleExtensions)])(v415, v158, v405, *([v166 @ X20_v6 (Il2CppMethodInfo)+48]), v177, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_00CF;\n\tv426 = *([v417 @ X8_v22 (Il2CppClass<EasyMobile.InAppPurchasing+<>c>)+E0]);\n\tv427 = v426 == 0;\n\tv428 = ~v427;\n\tgoto L_00CF;\n\tv444 = v417;\n\tv431 = \"il2cpp_codegen_runtime_class_init\"(v444, v414, v169, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv434 = EasyMobile.InAppPurchasing+<>c;\nL_00CF:\n\tv194 = v435.<>9__58_0;\n\tv437 = v435.<>9__58_0 == 0;\n\tv438 = ~v437;\n\tif (v438) goto L_00F3;\n\tgoto L_00E3;\n\tv460 = *([v433 @ X8_v23 (Il2CppClass<EasyMobile.InAppPurchasing+<>c>)+E0]);\n\tv461 = v460 == 0;\n\tv462 = ~v461;\n\tif (v462) goto L_00E3;\n\tv477 = v433;\n\tv466 = \"il2cpp_codegen_runtime_class_init\"(v477, v414, v169, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv468 = EasyMobile.InAppPurchasing+<>c;\n\tv464 = *([v468 @ X8_v36+B8]);\nL_00E3:\n\tv455 = new System.Action`1<System.Boolean>();\n\tSystem.Action`1<System.Boolean>::.ctor(v455, v463.<>9, Il2CppMethodInfo);\n\tv458.<>9__58_0 = v455;\nL_00F3:\n\tv473 = *([v415 @ X0_v24 (System.Action`1<System.Boolean>)]);\n\tv264 = *([v473 @ X8_v25 (Il2CppClass<System.Action`1<System.Boolean>>)+126]) == 0;\n\tif (v264) goto L_0116;\n\tv514 = *([v473 @ X8_v25 (Il2CppClass<System.Action`1<System.Boolean>>)+B0]) + 8;\nL_0101:\n\tv528 = *([v514 @ X11_v9-8]) == UnityEngine.Purchasing.IAppleExtensions;\n\tif (v528) goto L_0119;\n\tv513 = v513 + 1;\n\tv533 = v513 < *([v473 @ X8_v25 (Il2CppClass<System.Action`1<System.Boolean>>)+126]);\n\tv507 = ~v533;\n\tv514 = v514 + 0x10;\n\tv491 = ~v507;\n\tif (v491) goto L_0101;\nL_0116:\n\tv540 = System.Action`1<System.Boolean>::.ctor(v415, UnityEngine.Purchasing.IAppleExtensions, 1);\n\tgoto L_0121;\nL_0119:\n\tv535 = *([v514 @ X11_v9]) + 1;\n\tv536 = v535 << 4;\n\tv537 = v473 + v536;\n\tv540 = v537 + 0x130;\nL_0121:\n\t*([v540 @ X0_v27 (System.Action`1<System.Boolean>)])(v52, v415, v194, *([v540 @ X0_v27 (System.Action`1<System.Boolean>)+8]), Il2CppMethodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0129:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 183 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void RestorePurchases()
		{
			//IL_02e2: Expected I, but got O
			//IL_0087: Expected I, but got O
			//IL_015b: Expected I, but got O
			//IL_0168: Expected O, but got I
			//IL_0328: Expected O, but got I
			//IL_00c8: Expected O, but got I
			//IL_01f0: Expected I, but got O
			//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b2: Expected O, but got Unknown
			//IL_01cf: Expected O, but got I
			//IL_01de: Expected O, but got I
			//IL_0114: Expected O, but got I
			//IL_022b: Expected O, but got I
			//IL_029e: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a3: Expected O, but got Unknown
			//IL_02c0: Expected O, but got I
			//IL_02cf: Expected O, but got I
			//IL_0277: Expected O, but got I
			IntPtr intPtr = (IntPtr)typeof(InAppPurchasing);
			string message;
			if (IsInitialized())
			{
				RuntimePlatform platform = Application.platform;
				if (platform != RuntimePlatform.IPhonePlayer)
				{
					RuntimePlatform platform2 = Application.platform;
					if (platform2 != RuntimePlatform.OSXPlayer)
					{
						RuntimePlatform platform3 = Application.platform;
						intPtr = (IntPtr)(object)platform3;
						object obj = (long)intPtr;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v386 @ X8_v43+160] (should have been resolved before IL gen)");
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						string text = default(string);
						message = "Couldn't restore IAP purchases: not supported on platform " + text;
						goto IL_033c;
					}
				}
				IExtensionProvider extensionProvider = sStoreExtensionProvider;
				IntPtr intPtr2 = (IntPtr)extensionProvider;
				IntPtr intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ X8_v19 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ X8_v19 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]");
					object obj2 = 0L + 8L;
					int num = 0;
					bool flag2;
					do
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ X11_v14-8]");
						if ((IntPtr)0 != (IntPtr)0)
						{
							num++;
							int num2 = num;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ X8_v19 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
							bool flag = (long)num2 < 0L;
							flag2 = !flag;
							obj2 = (long)(IntPtr)obj2 + 16L;
							continue;
						}
						object obj3 = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ X20_v6 (Il2CppMethodInfo)+48]");
						object obj4 = obj3 + 0;
						int num3 = (int)((long)(IntPtr)obj4 << 4);
						object obj5 = (long)intPtr2 + (long)num3;
						Action<bool> action = (Action<bool>)((long)(IntPtr)obj5 + 304L);
						break;
					}
					while (!flag2);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ X0_v20 (System.Action`1<System.Boolean>)+8]");
				IAppleExtensions extension = ((IExtensionProvider)0).GetExtension<IAppleExtensions>();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v405 @ X0_v22 (UnityEngine.Purchasing.IAppleExtensions)] (should have been resolved before IL gen)");
				Action<bool> _003C_003E9__58_ = _003C_003Ec._003C_003E9__58_0;
				if (_003C_003Ec._003C_003E9__58_0 == null)
				{
					_003C_003E9__58_ = (_003C_003Ec._003C_003E9__58_0 = delegate
					{
						//IL_011b: Expected O, but got I
						//IL_004e: Expected I, but got O
						object obj10 = default(object);
						object obj9 = obj10;
						object obj11 = (long)(IntPtr)obj10 - 4L;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E8F14C (inside System.BitConverter::.cctor +0x64)");
						string text2 = default(string);
						string message2 = "Restoring IAP purchases result: " + text2;
						Debug.Log(message2);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ X29_v1-4]");
						Action action4;
						if ((IntPtr)0 != (IntPtr)0)
						{
							IntPtr intPtr5 = (IntPtr)typeof(InAppPurchasing);
							action4 = InAppPurchasing.RestoreCompleted;
							if (InAppPurchasing.RestoreCompleted == null)
							{
								return;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ X0_v19 (Il2CppClass<EasyMobile.InAppPurchasing>)+12F]");
							if (0u != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ X0_v19 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]");
								if ((IntPtr)0 == (IntPtr)0)
								{
									action4 = InAppPurchasing.RestoreCompleted;
									if (InAppPurchasing.RestoreCompleted == null)
									{
										throw new NullReferenceException();
									}
								}
							}
						}
						else
						{
							action4 = InAppPurchasing.RestoreFailed;
							if (InAppPurchasing.RestoreFailed == null)
							{
								return;
							}
						}
						action4();
					});
				}
				Action<bool> action2 = default(Action<bool>);
				IntPtr intPtr4 = (IntPtr)action2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v473 @ X8_v25 (Il2CppClass<System.Action`1<System.Boolean>>)+126]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v473 @ X8_v25 (Il2CppClass<System.Action`1<System.Boolean>>)+B0]");
					object obj6 = 0L + 8L;
					int num4 = 0;
					bool flag4;
					do
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ X11_v9-8]");
						if ((IntPtr)0 != (IntPtr)typeof(IAppleExtensions))
						{
							num4++;
							int num5 = num4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v473 @ X8_v25 (Il2CppClass<System.Action`1<System.Boolean>>)+126]");
							bool flag3 = (long)num5 < 0L;
							flag4 = !flag3;
							obj6 = (long)(IntPtr)obj6 + 16L;
							continue;
						}
						object obj7 = obj6 + 1;
						int num6 = (int)((long)(IntPtr)obj7 << 4);
						object obj8 = (long)intPtr4 + (long)num6;
						Action<bool> action3 = (Action<bool>)((long)(IntPtr)obj8 + 304L);
						break;
					}
					while (!flag4);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v540 @ X0_v27 (System.Action`1<System.Boolean>)] (should have been resolved before IL gen)");
				return;
			}
			message = "Couldn't restore IAP purchases: In-App Purchasing is not initialized.";
			goto IL_033c;
			IL_033c:
			Debug.Log(message);
		}

		[Token(Token = "0x60004C7")]
		[Address(RVA = "0xBF77DC", Offset = "0xBF77DC", Length = "0x1BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1ED34B0]);\n\tv21 = *([v20 @ X8_v28]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022F05]) = v40;\nL_0016:\n\tv43 = 0;\n\tgoto L_0021;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0021;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0021:\n\tv55 = EasyMobile.InAppPurchasing::IsInitialized();\n\tv57 = v55 == 0;\n\tif (v57) goto L_FFFFFFFF;\n\tgoto L_0030;\n\tv119 = *([v58 @ X0_v9+E0]);\n\tv120 = v119 == 0;\n\tv121 = ~v120;\n\tif (v121) goto L_0030;\n\tv123 = \"il2cpp_codegen_runtime_class_init\"(v58, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0030:\n\tv127 = EasyMobile.InAppPurchasing::GetIAPProductByName(productName);\n\tv150 = v127 == 0;\n\tif (v150) goto L_00A2;\n\tgoto L_0049;\n\tv214 = *([v210 @ X0_v13 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv215 = v214 == 0;\n\tv216 = ~v215;\n\t// 60 ConditionalJump @b44, v216 @ TEMP_v38\n\tv223 = \"il2cpp_codegen_runtime_class_init\"(v210, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv218 = EasyMobile.InAppPurchasing;\nL_0049:\n\tgoto L_0070;\n\tv231 = *([v225 @ X8_v13+B0]);\n\tv232 = 0;\n\tv233 = v231 + 8;\n\tv235 = *([v279 @ X11_v8-8]);\n\tv285 = v235 == v228;\n\tif (v285) goto L_0069;\n\tv257 = v280 + 1;\n\tv290 = v257 < v227;\n\tv253 = ~v290;\n\tv255 = v279 + 0x10;\n\tv237 = ~v253;\n\tif (v237) goto L_FFFFFFFF;\n\tv258 = v117;\n\tv259 = 0;\n\tv260 = 0x8909C4(v258, v228, v259, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_0070;\nL_0069:\n\tv291 = *([v279 @ X11_v8]);\n\tv292 = v291 << 4;\n\tv293 = v225 + v292;\n\tv294 = v293 + 0x130;\nL_0070:\n\tv266 = UnityEngine.Purchasing.IStoreController::get_products(v221.sStoreController);\n\tv265 = UnityEngine.Purchasing.ProductCollection::WithID(v266, v127._id);\n\tv109 = UnityEngine.Purchasing.Product::get_hasReceipt(v265);\n\tv111 = v109 == 0;\n\tif (v111) goto L_FFFFFFFF;\n\tgoto L_0089;\n\tv304 = *([v300 @ X0_v24 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv305 = v304 == 0;\n\tv306 = ~v305;\n\tif (v306) goto L_0089;\n\tv308 = \"il2cpp_codegen_runtime_class_init\"(v300, v101, v69, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0089:\n\tv310 = EasyMobile.InAppPurchasing::IsReceiptValidationEnabled();\n\tv152 = v310 == 0;\n\tif (v152) goto L_FFFFFFFF;\n\tgoto L_009B;\n\tv316 = *([v312 @ X0_v28+E0]);\n\tv317 = v316 == 0;\n\tv318 = ~v317;\n\tif (v318) goto L_009B;\n\tv320 = \"il2cpp_codegen_runtime_class_init\"(v312, v101, v69, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_009B:\n\tv147 = EasyMobile.InAppPurchasing::ValidateReceipt(v265.<receipt>k__BackingField, &v43 @ stack_-28_v1 (UnityEngine.Purchasing.Security.IPurchaseReceipt[]), 0);\n\tgoto L_00A2;\nL_00A2:\n\treturnVal1 = v127 & 1;\n\treturn returnVal1;\n\tgoto L_00A2;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 91 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsProductOwned(string productName)
		{
			//IL_0114: Expected O, but got I4
			//IL_00fc: Expected O, but got I4
			IPurchaseReceipt[] purchaseReceipts = null;
			if (!IsInitialized())
			{
				goto IL_0101;
			}
			IAPProduct iAPProduct = GetIAPProductByName(productName);
			if (iAPProduct != null)
			{
				ProductCollection products = sStoreController.products;
				Product product = products.WithID(iAPProduct.Id);
				if (!product.hasReceipt)
				{
					goto IL_0101;
				}
				if (IsReceiptValidationEnabled())
				{
					bool flag = ValidateReceipt(product.receipt, out purchaseReceipts);
					iAPProduct = (IAPProduct)flag;
				}
				else
				{
					iAPProduct = (IAPProduct)1;
				}
			}
			goto IL_0123;
			IL_0101:
			iAPProduct = null;
			goto IL_0123;
			IL_0123:
			return (byte)((ulong)(long)(IntPtr)iAPProduct & 1uL) != 0;
		}

		[Token(Token = "0x60004C8")]
		[Address(RVA = "0xBF7E90", Offset = "0xBF7E90", Length = "0x2A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EB6780]);\n\tv25 = *([v24 @ X8_v46]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, errorCallback, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022F06]) = v43;\nL_0019:\n\tv47 = new EasyMobile.InAppPurchasing+<>c__DisplayClass60_0();\n\tSystem.Object::.ctor(v47);\n\tv47.successCallback = successCallback;\n\tv47.errorCallback = errorCallback;\n\tv52 = UnityEngine.Application::get_platform();\n\tv77 = v52 != 8;\n\tif (v77) goto L_007A;\n\tgoto L_003A;\n\tv205 = *([v131 @ X0_v14 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv206 = v205 == 0;\n\tv207 = ~v206;\n\tif (v207) goto L_003A;\n\tv209 = \"il2cpp_codegen_runtime_class_init\"(v131, v48, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_003A:\n\tv212 = EasyMobile.InAppPurchasing::IsInitialized();\n\tv223 = v212 == 0;\n\tif (v223) goto L_0089;\n\tgoto L_004A;\n\tv239 = *([v229 @ X0_v20 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv240 = v239 == 0;\n\tv241 = ~v240;\n\tif (v241) goto L_004A;\n\tv251 = \"il2cpp_codegen_runtime_class_init\"(v229, v48, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv242 = EasyMobile.InAppPurchasing;\nL_004A:\n\tv122 = v125.sStoreExtensionProvider;\n\tv254 = *([v122 @ X20_v7 (UnityEngine.Purchasing.IExtensionProvider)]);\n\tv255 = Il2CppMethodInfo;\n\tv259 = *([v254 @ X8_v26 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]) == 0;\n\tif (v259) goto L_0072;\n\tv291 = *([v254 @ X8_v26 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]) + 8;\nL_005E:\n\tv305 = *([v291 @ X11_v12-8]) == Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>;\n\tif (v305) goto L_009D;\n\tv290 = v290 + 1;\n\tv310 = v290 < *([v254 @ X8_v26 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]);\n\tv286 = ~v310;\n\tv291 = v291 + 0x10;\n\tv270 = ~v286;\n\tif (v270) goto L_005E;\nL_0072:\n\tv317 = 0x8909C4(v122, Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>, *([v255 @ X21_v4 (Il2CppMethodInfo)+48]), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_00A3;\nL_007A:\n\tgoto L_FFFFFFFF;\n\tv213 = *([v137 @ X0_v11+E0]);\n\tv214 = v213 == 0;\n\tv215 = ~v214;\n\tif (v215) goto L_FFFFFFFF;\n\tv217 = \"il2cpp_codegen_runtime_class_init\"(v137, v48, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_009A;\nL_0089:\n\tgoto L_FFFFFFFF;\n\tv245 = *([v235 @ X0_v17+E0]);\n\tv246 = v245 == 0;\n\tv247 = ~v246;\n\tif (v247) goto L_FFFFFFFF;\n\tv248 = \"il2cpp_codegen_runtime_class_init\"(v235, v48, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_009A:\n\tUnityEngine.Debug::Log(*([v197 @ X8_v6 (System.String)]));\n\treturn;\nL_009D:\n\tv312 = *([v291 @ X11_v12]) + *([v255 @ X21_v4 (Il2CppMethodInfo)+48]);\n\tv313 = v312 << 4;\n\tv314 = v254 + v313;\n\tv317 = v314 + 0x130;\nL_00A3:\n\tv321 = UnityEngine.Purchasing.IExtensionProvider::GetExtension(*([v317 @ X0_v22+8]));\n\t*([v321 @ X0_v24 (UnityEngine.Purchasing.IAppleExtensions)])(v326, v122, v321, *([v255 @ X21_v4 (Il2CppMethodInfo)+48]), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv331 = new System.Action`1<System.String>();\n\tSystem.Action`1<System.String>::.ctor(v331, v47, Il2CppMethodInfo);\n\tv113 = new System.Action();\n\tSystem.Action::.ctor(v113, v47, Il2CppMethodInfo);\n\tgoto L_00FB;\n\tv347 = *([v343 @ X8_v38+B0]);\n\tv348 = 0;\n\tv349 = v347 + 8;\n\tv351 = *([v379 @ X11_v7-8]);\n\tv393 = v351 == v346;\n\tif (v393) goto L_00EB;\n\tv353 = v378 + 1;\n\tv398 = v353 < v345;\n\tv373 = ~v398;\n\tv355 = v379 + 0x10;\n\tv357 = ~v373;\n\tif (v357) goto L_FFFFFFFF;\n\tv374 = v121;\n\tv375 = 0;\n\tv376 = 0x8909C4(v374, v346, v375, v59, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_00FB;\nL_00EB:\n\tv399 = *([v379 @ X11_v7]);\n\tv400 = v399 << 4;\n\tv401 = v343 + v400;\n\tv402 = v401 + 0x130;\nL_00FB:\n\tUnityEngine.Purchasing.IAppleExtensions::RefreshAppReceipt(v326, v331, v113);\n\tthrow System.NullReferenceException;\n\treturn;\n// 161 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void RefreshAppleAppReceipt(Action<string> successCallback, Action errorCallback)
		{
			//IL_0080: Expected I, but got O
			//IL_020f: Expected O, but got I
			//IL_00c1: Expected O, but got I
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0170: Expected O, but got Unknown
			//IL_018d: Expected O, but got I
			//IL_019c: Expected O, but got I
			//IL_010d: Expected O, but got I
			RuntimePlatform platform = Application.platform;
			string message;
			if (platform == RuntimePlatform.IPhonePlayer)
			{
				if (IsInitialized())
				{
					IExtensionProvider extensionProvider = sStoreExtensionProvider;
					IntPtr intPtr = (IntPtr)extensionProvider;
					IntPtr intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ X8_v26 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_0126;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ X8_v26 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]");
					object obj = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ X11_v12-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ X8_v26 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
						bool flag = (long)num2 < 0L;
						bool flag2 = !flag;
						obj = (long)(IntPtr)obj + 16L;
						if (!flag2)
						{
							continue;
						}
						goto IL_0126;
					}
					object obj2 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ X21_v4 (Il2CppMethodInfo)+48]");
					object obj3 = obj2 + 0;
					int num3 = (int)((long)(IntPtr)obj3 << 4);
					object obj4 = (long)intPtr + (long)num3;
					object obj5 = (long)(IntPtr)obj4 + 304L;
					goto IL_01fe;
				}
				message = "Couldn't refresh Apple app receipt: In-App Purchasing is not initialized.";
			}
			else
			{
				message = "Refreshing Apple app receipt is only available on iOS.";
			}
			Debug.Log(message);
			return;
			IL_0126:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_01fe;
			IL_01fe:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ X0_v22+8]");
			IAppleExtensions extension = ((IExtensionProvider)0).GetExtension<IAppleExtensions>();
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v321 @ X0_v24 (UnityEngine.Purchasing.IAppleExtensions)] (should have been resolved before IL gen)");
			Action<string> successCallback2 = delegate(string receipt)
			{
				if (successCallback != null)
				{
					successCallback(receipt);
				}
			};
			Action errorCallback2 = delegate
			{
				if (errorCallback != null)
				{
					errorCallback();
				}
			};
			IAppleExtensions appleExtensions = default(IAppleExtensions);
			appleExtensions.RefreshAppReceipt(successCallback2, errorCallback2);
		}

		[Token(Token = "0x60004C9")]
		[Address(RVA = "0xBF8138", Offset = "0xBF8138", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1F04308]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022F07]) = v40;\nL_001A:\n\tgoto L_0022;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0022;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = EasyMobile.InAppPurchasing;\nL_0022:\n\tv75 = v54.sAppleExtensions;\n\tv56 = v54.sAppleExtensions == 0;\n\tif (v56) goto L_005F;\n\tgoto L_0034;\n\tv66 = *([v50 @ X0_v3 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tif (v68) goto L_0034;\n\tv177 = EasyMobile.InAppPurchasing;\n\tv74 = *([v177 @ X8_v12 (Il2CppClass<EasyMobile.InAppPurchasing>)+B8]);\n\tv76 = v74.sAppleExtensions;\nL_0034:\n\tv78 = *([v75 @ X20_v4 (UnityEngine.Purchasing.IAppleExtensions)]);\n\tv82 = *([v78 @ X8_v8 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+126]) == 0;\n\tif (v82) goto L_0057;\n\tv188 = *([v78 @ X8_v8 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+B0]) + 8;\nL_0042:\n\tv194 = *([v188 @ X11_v5-8]) == UnityEngine.Purchasing.IAppleExtensions;\n\tif (v194) goto L_0061;\n\tv189 = v189 + 1;\n\tv200 = v189 < *([v78 @ X8_v8 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+126]);\n\tv169 = ~v200;\n\tv188 = v188 + 0x10;\n\tv153 = ~v169;\n\tif (v153) goto L_0042;\nL_0057:\n\tv207 = 0x8909C4(v54.sAppleExtensions, UnityEngine.Purchasing.IAppleExtensions, 3, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_006F;\nL_005F:\n\treturn;\nL_0061:\n\tv202 = *([v188 @ X11_v5]) + 3;\n\tv203 = v202 << 4;\n\tv204 = v78 + v203;\n\tv207 = v204 + 0x130;\nL_006F:\n\t// 111 IndirectJump [v207 @ X0_v5], v54.sAppleExtensions (UnityEngine.Purchasing.IAppleExtensions), v54.sAppleExtensions (UnityEngine.Purchasing.IAppleExtensions), shouldSimulate @ X0 (System.Boolean), [v207 @ X0_v5+8], [v207 @ X0_v5], v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetSimulateAppleAskToBuy(bool shouldSimulate)
		{
			//IL_0012: Expected I, but got O
			//IL_004d: Expected O, but got I
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Expected O, but got Unknown
			//IL_00ed: Expected O, but got I
			//IL_00fc: Expected O, but got I
			//IL_0099: Expected O, but got I
			IAppleExtensions appleExtensions = sAppleExtensions;
			if (sAppleExtensions == null)
			{
				return;
			}
			IntPtr intPtr = (IntPtr)appleExtensions;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ X8_v8 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00b2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ X8_v8 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IAppleExtensions))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ X8_v8 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00b2;
			}
			object obj2 = obj + 3;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0157;
			IL_0157:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v207 @ X0_v5] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-30), the output could be wrong!");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-30), the output could be wrong!");
			return;
			IL_00b2:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0157;
		}

		[Token(Token = "0x60004CA")]
		[Address(RVA = "0xBF8258", Offset = "0xBF8258", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EDF6B8]);\n\tv17 = *([v16 @ X8_v17]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2022F08]) = v37;\nL_0018:\n\tgoto L_0020;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0020;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = EasyMobile.InAppPurchasing;\nL_0020:\n\tv71 = v51.sAppleExtensions;\n\tv53 = v51.sAppleExtensions == 0;\n\tif (v53) goto L_005C;\n\tgoto L_0032;\n\tv62 = *([v47 @ X0_v3 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_0032;\n\tv169 = EasyMobile.InAppPurchasing;\n\tv70 = *([v169 @ X8_v12 (Il2CppClass<EasyMobile.InAppPurchasing>)+B8]);\n\tv72 = v70.sAppleExtensions;\nL_0032:\n\tv74 = *([v71 @ X19_v4 (UnityEngine.Purchasing.IAppleExtensions)]);\n\tv78 = *([v74 @ X8_v8 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+126]) == 0;\n\tif (v78) goto L_0055;\n\tv180 = *([v74 @ X8_v8 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+B0]) + 8;\nL_0040:\n\tv186 = *([v180 @ X11_v5-8]) == UnityEngine.Purchasing.IAppleExtensions;\n\tif (v186) goto L_005E;\n\tv181 = v181 + 1;\n\tv192 = v181 < *([v74 @ X8_v8 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+126]);\n\tv161 = ~v192;\n\tv180 = v180 + 0x10;\n\tv145 = ~v161;\n\tif (v145) goto L_0040;\nL_0055:\n\tv199 = 0x8909C4(v51.sAppleExtensions, UnityEngine.Purchasing.IAppleExtensions, 6, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tgoto L_006A;\nL_005C:\n\treturn;\nL_005E:\n\tv194 = *([v180 @ X11_v5]) + 6;\n\tv195 = v194 << 4;\n\tv196 = v74 + v195;\n\tv199 = v196 + 0x130;\nL_006A:\n\t// 106 IndirectJump [v199 @ X0_v5], v51.sAppleExtensions (UnityEngine.Purchasing.IAppleExtensions), v51.sAppleExtensions (UnityEngine.Purchasing.IAppleExtensions), [v199 @ X0_v5+8], [v199 @ X0_v5], v21 @ X3, v22 @ X4, v23 @ X5, v24 @ X6, v25 @ X7, v26 @ V0, v27 @ V1, v28 @ V2, v29 @ V3, v30 @ V4, v31 @ V5, v32 @ V6, v33 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ContinueApplePromotionalPurchases()
		{
			//IL_0012: Expected I, but got O
			//IL_004d: Expected O, but got I
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Expected O, but got Unknown
			//IL_00ed: Expected O, but got I
			//IL_00fc: Expected O, but got I
			//IL_0099: Expected O, but got I
			IAppleExtensions appleExtensions = sAppleExtensions;
			if (sAppleExtensions == null)
			{
				return;
			}
			IntPtr intPtr = (IntPtr)appleExtensions;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ X8_v8 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00b2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ X8_v8 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IAppleExtensions))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ X8_v8 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00b2;
			}
			object obj2 = obj + 6;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0157;
			IL_0157:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v199 @ X0_v5] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-20), the output could be wrong!");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-20), the output could be wrong!");
			return;
			IL_00b2:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0157;
		}

		[Token(Token = "0x60004CB")]
		[Address(RVA = "0xBF8364", Offset = "0xBF8364", Length = "0x2A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EEB620]);\n\tv25 = *([v24 @ X8_v43]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, visible, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022F09]) = v43;\nL_001C:\n\tgoto L_0022;\n\tv50 = *([v46 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0022;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, visible, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0022:\n\tv57 = EasyMobile.InAppPurchasing::IsInitialized();\n\tv59 = v57 == 0;\n\tif (v59) goto L_0070;\n\tgoto L_0031;\n\tv70 = *([v60 @ X0_v10+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_0031;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v60, visible, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0031:\n\tv78 = EasyMobile.InAppPurchasing::GetIAPProductByName(productName);\n\tv90 = v78 == 0;\n\tif (v90) goto L_007F;\n\tgoto L_004A;\n\tv122 = *([v114 @ X0_v20 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv123 = v122 == 0;\n\tv124 = ~v123;\n\t// 61 ConditionalJump @b54, v124 @ TEMP_v44\n\tv255 = \"il2cpp_codegen_runtime_class_init\"(v114, visible, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv126 = EasyMobile.InAppPurchasing;\nL_004A:\n\tgoto L_00A0;\n\tv304 = *([v257 @ X8_v25+B0]);\n\tv305 = 0;\n\tv306 = v304 + 8;\n\tv308 = *([v352 @ X11_v13-8]);\n\tv358 = v308 == v260;\n\tif (v358) goto L_0099;\n\tv330 = v353 + 1;\n\tv363 = v330 < v259;\n\tv326 = ~v363;\n\tv328 = v352 + 0x10;\n\tv310 = ~v326;\n\tif (v310) goto L_FFFFFFFF;\n\tv331 = v130;\n\tv332 = 0;\n\tv333 = 0x8909C4(v331, v260, v332, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_00A0;\nL_0070:\n\tgoto L_FFFFFFFF;\n\tv79 = *([v66 @ X0_v6+E0]);\n\tv80 = v79 == 0;\n\tv81 = ~v80;\n\tif (v81) goto L_FFFFFFFF;\n\tv83 = \"il2cpp_codegen_runtime_class_init\"(v66, visible, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_0097;\nL_007F:\n\tv98 = System.String::Concat(\"Couldn't set promotion visibility: not found product with name: \", productName);\n\tgoto L_0097;\n\tv299 = *([v105 @ X8_v19+E0]);\n\tv300 = v299 == 0;\n\tv301 = ~v300;\n\t// 139 ConditionalJump @b31, v301 @ TEMP_v23\n\tv341 = v105;\n\tv303 = \"il2cpp_codegen_runtime_class_init\"(v341, v94, v92, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0097:\n\tUnityEngine.Debug::Log(v98);\n\treturn;\nL_0099:\n\tv364 = *([v352 @ X11_v13]);\n\tv365 = v364 << 4;\n\tv366 = v257 + v365;\n\tv367 = v366 + 0x130;\nL_00A0:\n\tv338 = UnityEngine.Purchasing.IStoreController::get_products(v129.sStoreController);\n\tv229 = UnityEngine.Purchasing.ProductCollection::WithID(v338, v78._id);\n\tv245 = EasyMobile.InAppPurchasing;\n\tv400 = v220.sAppleExtensions;\n\tv233 = v220.sAppleExtensions == 0;\n\tif (v233) goto L_00ED;\n\tv373 = *([v245 @ X8_v28 (Il2CppClass<EasyMobile.InAppPurchasing>)+12F]) & 2;\n\tv374 = v373 == 0;\n\tif (v374) goto L_00B5;\n\tv375 = *([v245 @ X8_v28 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]) == 0;\n\tif (v375) goto L_0105;\nL_00B5:\n\tv380 = visible == 0;\n\tv384 = ~v380;\n\tv385 = ~v384;\n\tif (v385) goto L_FFFFFFFF;\n\tv401 = 1 + 1;\n\tgoto L_00C6;\nL_00C6:\n\tgoto L_00FF;\n\tv410 = *([v404 @ X8_v30+B0]);\n\tv411 = 0;\n\tv412 = v410 + 8;\n\tv414 = *([v451 @ X11_v8-8]);\n\tv457 = v414 == v407;\n\tif (v457) goto L_00EE;\n\tv436 = v452 + 1;\n\tv462 = v436 < v406;\n\tv432 = ~v462;\n\tv434 = v451 + 0x10;\n\tv416 = ~v432;\n\tif (v416) goto L_FFFFFFFF;\n\tv437 = 5;\n\tv438 = v400;\n\tv439 = 0x8909C4(v438, v407, v437, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_00FF;\nL_00ED:\n\treturn;\nL_00EE:\n\tv463 = *([v451 @ X11_v8]);\n\tv464 = v463 + 5;\n\tv465 = v464 << 4;\n\tv466 = v404 + v465;\n\tv467 = v466 + 0x130;\nL_00FF:\n\tUnityEngine.Purchasing.IAppleExtensions::SetStorePromotionVisibility(v400, v229, v401);\nL_0105:\n\tv275 = visible == 0;\n\tv400 = v391.sAppleExtensions;\n\tv268 = ~v275;\n\tv264 = ~v268;\n\tif (v264) goto L_FFFFFFFF;\n\tv401 = 1 + 1;\n\tgoto L_0112;\nL_0112:\n\tv440 = v400 == 0;\n\tv289 = ~v440;\n\tif (v289) goto L_00C6;\n\tthrow System.NullReferenceException;\n// 159 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetAppleStorePromotionVisibility(string productName, bool visible)
		{
			//IL_00b2: Expected I, but got O
			Product product;
			IAppleExtensions appleExtensions;
			int visible2;
			string message;
			if (IsInitialized())
			{
				IAPProduct iAPProductByName = GetIAPProductByName(productName);
				if (iAPProductByName != null)
				{
					ProductCollection products = sStoreController.products;
					product = products.WithID(iAPProductByName.Id);
					IntPtr intPtr = (IntPtr)typeof(InAppPurchasing);
					appleExtensions = sAppleExtensions;
					if (sAppleExtensions == null)
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ X8_v28 (Il2CppClass<EasyMobile.InAppPurchasing>)+12F]");
					if (0u != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ X8_v28 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							bool flag = !visible;
							appleExtensions = sAppleExtensions;
							visible2 = (flag ? 1 : (1 + 1));
							if (appleExtensions == null)
							{
								throw new NullReferenceException();
							}
							goto IL_0207;
						}
					}
					visible2 = ((!visible) ? 1 : (1 + 1));
					goto IL_0207;
				}
				message = "Couldn't set promotion visibility: not found product with name: " + productName;
			}
			else
			{
				message = "Couldn't set promotion visibility: In-App Purchasing is not initialized.";
			}
			Debug.Log(message);
			return;
			IL_0207:
			appleExtensions.SetStorePromotionVisibility(product, (AppleStorePromotionVisibility)visible2);
		}

		[Token(Token = "0x60004CC")]
		[Address(RVA = "0xBF8604", Offset = "0xBF8604", Length = "0x2F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1EA9BF0]);\n\tv31 = *([v30 @ X8_v52]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2022F0A]) = v50;\nL_001F:\n\tgoto L_0025;\n\tv57 = *([v53 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_0025;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v53, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0025:\n\tv64 = EasyMobile.InAppPurchasing::IsInitialized();\n\tv66 = v64 == 0;\n\tif (v66) goto L_010F;\n\tv70 = new System.Collections.Generic.List`1<UnityEngine.Purchasing.Product>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.Product>::.ctor(v70);\n\tv349 = products._size;\n\tv114 = products._size < 1;\n\tif (v114) goto L_00CA;\nL_0046:\n\tv350 = v349 < v154;\n\tv206 = ~v350;\n\tv201 = v349 - v154;\n\tv191 = v201 == 0;\n\tv351 = ~v191;\n\tv166 = v206 & v351;\n\tif (v166) goto L_0054;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0054:\n\tv361 = products._items;\n\tv364 = v361[v154 @ X23_v7 (System.Int32)] == 0;\n\tif (v364) goto L_00B8;\n\tgoto L_006D;\n\tv399 = *([v369 @ X0_v29 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv400 = v399 == 0;\n\tv401 = ~v400;\n\t// 98 ConditionalJump @b56, v401 @ TEMP_v42\n\tv435 = \"il2cpp_codegen_runtime_class_init\"(v369, v211, v132, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv402 = EasyMobile.InAppPurchasing;\nL_006D:\n\tgoto L_0095;\n\tv462 = *([v436 @ X8_v40+B0]);\n\tv463 = 0;\n\tv464 = v462 + 8;\n\tv466 = *([v502 @ X11_v15-8]);\n\tv516 = v466 == v437;\n\tif (v516) goto L_008D;\n\tv468 = v501 + 1;\n\tv521 = v468 < v438;\n\tv488 = ~v521;\n\tv470 = v502 + 0x10;\n\tv472 = ~v488;\n\tif (v472) goto L_FFFFFFFF;\n\tv489 = v127;\n\tv490 = 0;\n\tv491 = 0x8909C4(v489, v437, v490, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_0095;\nL_008D:\n\tv522 = *([v502 @ X11_v15]);\n\tv523 = v522 << 4;\n\tv524 = v436 + v523;\n\tv525 = v524 + 0x130;\nL_0095:\n\tv540 = UnityEngine.Purchasing.IStoreController::get_products(v228.sStoreController);\n\tv542 = products._size < v154;\n\tv204 = ~v542;\n\tv199 = products._size - v154;\n\tv189 = v199 == 0;\n\tv543 = ~v189;\n\tv164 = v204 & v543;\n\tif (v164) goto L_00A6;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00A6:\n\tv545 = products._items;\n\tv226 = v545[v154 @ X23_v7 (System.Int32)];\n\tv214 = UnityEngine.Purchasing.ProductCollection::WithID(v540, v226._id);\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.Product>::Add(v70, v214);\nL_00B8:\n\tv349 = products._size;\n\tv154 = v154 + 1;\n\tv316 = v154 < products._size;\n\tif (v316) goto L_0046;\nL_00CA:\n\tgoto L_00D2;\n\tv352 = *([v332 @ X0_v15 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv353 = v352 == 0;\n\tv354 = ~v353;\n\tif (v354) goto L_00D2;\n\tv365 = \"il2cpp_codegen_runtime_class_init\"(v332, v210, v131, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv355 = EasyMobile.InAppPurchasing;\nL_00D2:\n\tv392 = v296.sAppleExtensions;\n\tv290 = v296.sAppleExtensions == 0;\n\tif (v290) goto L_0131;\n\tgoto L_00E4;\n\tv387 = *([v287 @ X0_v16 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv388 = v387 == 0;\n\tv389 = ~v388;\n\tif (v389) goto L_00E4;\n\tv440 = EasyMobile.InAppPurchasing;\n\tv227 = *([v440 @ X8_v28 (Il2CppClass<EasyMobile.InAppPurchasing>)+B8]);\n\tv224 = v227.sAppleExtensions;\nL_00E4:\n\tv395 = *([v392 @ X20_v6 (UnityEngine.Purchasing.IAppleExtensions)]);\n\tv291 = *([v395 @ X8_v24 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+126]) == 0;\n\tif (v291) goto L_0107;\n\tv443 = *([v395 @ X8_v24 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+B0]) + 8;\nL_00F2:\n\tv457 = *([v443 @ X11_v7-8]) == UnityEngine.Purchasing.IAppleExtensions;\n\tif (v457) goto L_0133;\n\tv442 = v442 + 1;\n\tv492 = v442 < *([v395 @ X8_v24 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+126]);\n\tv431 = ~v492;\n\tv443 = v443 + 0x10;\n\tv415 = ~v431;\n\tif (v415) goto L_00F2;\nL_0107:\n\tv499 = 0x8909C4(v296.sAppleExtensions, UnityEngine.Purchasing.IAppleExtensions, 4, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_0146;\nL_010F:\n\tgoto L_0124;\n\tv81 = *([v73 @ X0_v5+E0]);\n\tv82 = v81 == 0;\n\tv83 = ~v82;\n\tif (v83) goto L_0124;\n\tv85 = \"il2cpp_codegen_runtime_class_init\"(v73, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0124:\n\tUnityEngine.Debug::Log(\"Couldn't set promotion order: In-App Purchasing is not initialized.\");\n\treturn;\nL_0131:\n\treturn;\nL_0133:\n\tv494 = *([v443 @ X11_v7]) + 4;\n\tv495 = v494 << 4;\n\tv496 = v395 + v495;\n\tv499 = v496 + 0x130;\nL_0146:\n\t// 326 IndirectJump [v499 @ X0_v18], v296.sAppleExtensions (UnityEngine.Purchasing.IAppleExtensions), v296.sAppleExtensions (UnityEngine.Purchasing.IAppleExtensions), v70 @ X0_v10 (System.Collections.Generic.List`1<UnityEngine.Purchasing.Product>), [v499 @ X0_v18+8], [v499 @ X0_v18], v36 @ X4, v37 @ X5, v38 @ X6, v39 @ X7, v40 @ V0, v41 @ V1, v42 @ V2, v43 @ V3, v44 @ V4, v45 @ V5, v46 @ V6, v47 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 206 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetAppleStorePromotionOrder(List<IAPProduct> products)
		{
			//IL_0168: Expected I, but got O
			//IL_01a3: Expected O, but got I
			//IL_0231: Unknown result type (might be due to invalid IL or missing references)
			//IL_0236: Expected O, but got Unknown
			//IL_0253: Expected O, but got I
			//IL_0262: Expected O, but got I
			//IL_01ef: Expected O, but got I
			if (IsInitialized())
			{
				List<Product> list = new List<Product>();
				int count = products.Count;
				if (products.Count >= 1)
				{
					int num = 0;
					do
					{
						bool flag = count < num;
						bool flag2 = !flag;
						int num2 = count - num;
						bool flag3 = num2 == 0;
						bool flag4 = !flag3;
						if (!(flag2 && flag4))
						{
							throw new ArgumentOutOfRangeException();
						}
						IAPProduct[] items = products._items;
						if (items[num] != null)
						{
							ProductCollection products2 = sStoreController.products;
							bool flag5 = products.Count < num;
							bool flag6 = !flag5;
							int num3 = products.Count - num;
							bool flag7 = num3 == 0;
							bool flag8 = !flag7;
							if (!(flag6 && flag8))
							{
								throw new ArgumentOutOfRangeException();
							}
							IAPProduct[] items2 = products._items;
							IAPProduct iAPProduct = items2[num];
							Product item = products2.WithID(iAPProduct.Id);
							list.Add(item);
						}
						count = products.Count;
						num++;
					}
					while (num < products.Count);
				}
				IAppleExtensions appleExtensions = sAppleExtensions;
				if (sAppleExtensions == null)
				{
					return;
				}
				IntPtr intPtr = (IntPtr)appleExtensions;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ X8_v24 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0208;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ X8_v24 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+B0]");
				object obj = 0L + 8L;
				int num4 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v443 @ X11_v7-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IAppleExtensions))
					{
						break;
					}
					num4++;
					int num5 = num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ X8_v24 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+126]");
					bool flag9 = (long)num5 < 0L;
					bool flag10 = !flag9;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag10)
					{
						continue;
					}
					goto IL_0208;
				}
				object obj2 = obj + 4;
				int num6 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num6;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_038b;
			}
			Debug.Log("Couldn't set promotion order: In-App Purchasing is not initialized.");
			return;
			IL_038b:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v499 @ X0_v18] (should have been resolved before IL gen)");
			return;
			IL_0208:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_038b;
		}

		[Token(Token = "0x60004CD")]
		[Address(RVA = "0xBF88F8", Offset = "0xBF88F8", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = EasyMobile.EM_Settings::get_InAppPurchasing();\n\treturn v7.mProducts;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static IAPProduct[] GetAllIAPProducts()
		{
			IAPSettings inAppPurchasing = EM_Settings.InAppPurchasing;
			return inAppPurchasing.Products;
		}

		[Token(Token = "0x60004CE")]
		[Address(RVA = "0xBF7408", Offset = "0xBF7408", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = EasyMobile.EM_Settings::get_InAppPurchasing();\n\tv19 = v17.mProducts;\n\tv116 = v19.Length;\n\tv111 = v19.Length < 1;\n\tif (v111) goto L_FFFFFFFF;\nL_001E:\n\tv207 = v38 < v116;\n\tv74 = ~v207;\n\tif (v74) goto L_004F;\n\tv31 = v19[v38 @ X22_v7 (System.Int32)];\n\tv155 = System.String::Equals(v31._name, productName);\n\tv213 = v155 == 0;\n\tv153 = ~v213;\n\tif (v153) goto L_004E;\n\tv116 = v19.Length;\n\tv38 = v38 + 1;\n\tv133 = v38 < v19.Length;\n\tif (v133) goto L_001E;\nL_004E:\n\treturn v208;\nL_004F:\n\tv211 = new System.IndexOutOfRangeException();\n\tthrow v211;\n\tv84 = new System.NullReferenceException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static IAPProduct GetIAPProductByName(string productName)
		{
			IAPSettings inAppPurchasing = EM_Settings.InAppPurchasing;
			IAPProduct[] products = inAppPurchasing.Products;
			int num = products.Length;
			if (products.Length < 1)
			{
				goto IL_00f2;
			}
			int num2 = 0;
			IAPProduct result;
			while (true)
			{
				if (num2 < num)
				{
					IAPProduct iAPProduct = products[num2];
					bool flag = iAPProduct.Name.Equals(productName);
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = products[num2];
					if (flag3)
					{
						break;
					}
					num = products.Length;
					num2++;
					if (num2 < products.Length)
					{
						continue;
					}
					goto IL_00f2;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			goto IL_010a;
			IL_00f2:
			result = null;
			goto IL_010a;
			IL_010a:
			return result;
		}

		[Token(Token = "0x60004CF")]
		[Address(RVA = "0xBF891C", Offset = "0xBF891C", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = EasyMobile.EM_Settings::get_InAppPurchasing();\n\tv19 = v17.mProducts;\n\tv116 = v19.Length;\n\tv111 = v19.Length < 1;\n\tif (v111) goto L_FFFFFFFF;\nL_001E:\n\tv207 = v38 < v116;\n\tv74 = ~v207;\n\tif (v74) goto L_004F;\n\tv31 = v19[v38 @ X22_v7 (System.Int32)];\n\tv155 = System.String::Equals(v31._id, productId);\n\tv213 = v155 == 0;\n\tv153 = ~v213;\n\tif (v153) goto L_004E;\n\tv116 = v19.Length;\n\tv38 = v38 + 1;\n\tv133 = v38 < v19.Length;\n\tif (v133) goto L_001E;\nL_004E:\n\treturn v208;\nL_004F:\n\tv211 = new System.IndexOutOfRangeException();\n\tthrow v211;\n\tv84 = new System.NullReferenceException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static IAPProduct GetIAPProductById(string productId)
		{
			IAPSettings inAppPurchasing = EM_Settings.InAppPurchasing;
			IAPProduct[] products = inAppPurchasing.Products;
			int num = products.Length;
			if (products.Length < 1)
			{
				goto IL_00f2;
			}
			int num2 = 0;
			IAPProduct result;
			while (true)
			{
				if (num2 < num)
				{
					IAPProduct iAPProduct = products[num2];
					bool flag = iAPProduct.Id.Equals(productId);
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = products[num2];
					if (flag3)
					{
						break;
					}
					num = products.Length;
					num2++;
					if (num2 < products.Length)
					{
						continue;
					}
					goto IL_00f2;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			goto IL_010a;
			IL_00f2:
			result = null;
			goto IL_010a;
			IL_010a:
			return result;
		}

		[Token(Token = "0x60004D0")]
		[Address(RVA = "0xBF89C4", Offset = "0xBF89C4", Length = "0x1CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EEB3F8]);\n\tv21 = *([v20 @ X8_v33]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022F0B]) = v40;\nL_001A:\n\tgoto L_0020;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0020;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0020:\n\tv54 = EasyMobile.InAppPurchasing::IsInitialized();\n\tv56 = v54 == 0;\n\tif (v56) goto L_006E;\n\tgoto L_002F;\n\tv67 = *([v57 @ X0_v11+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_002F;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v57, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002F:\n\tv75 = EasyMobile.InAppPurchasing::GetIAPProductByName(productName);\n\tv87 = v75 == 0;\n\tif (v87) goto L_007D;\n\tgoto L_0048;\n\tv118 = *([v104 @ X0_v21 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv119 = v118 == 0;\n\tv120 = ~v119;\n\t// 59 ConditionalJump @b39, v120 @ TEMP_v32\n\tv213 = \"il2cpp_codegen_runtime_class_init\"(v104, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv122 = EasyMobile.InAppPurchasing;\nL_0048:\n\tgoto L_009E;\n\tv226 = *([v215 @ X8_v24+B0]);\n\tv227 = 0;\n\tv228 = v226 + 8;\n\tv230 = *([v271 @ X11_v6-8]);\n\tv277 = v230 == v218;\n\tif (v277) goto L_0097;\n\tv252 = v272 + 1;\n\tv282 = v252 < v217;\n\tv248 = ~v282;\n\tv250 = v271 + 0x10;\n\tv232 = ~v248;\n\tif (v232) goto L_FFFFFFFF;\n\tv253 = v126;\n\tv254 = 0;\n\tv255 = 0x8909C4(v253, v218, v254, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_009E;\nL_006E:\n\tgoto L_FFFFFFFF;\n\tv76 = *([v63 @ X0_v7+E0]);\n\tv77 = v76 == 0;\n\tv78 = ~v77;\n\tif (v78) goto L_FFFFFFFF;\n\tv80 = \"il2cpp_codegen_runtime_class_init\"(v63, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_008E;\nL_007D:\n\tv95 = System.String::Concat(\"Couldn't get product: not found product with name: \", productName);\n\tgoto L_008E;\n\tv221 = *([v100 @ X8_v19+E0]);\n\tv222 = v221 == 0;\n\tv223 = ~v222;\n\t// 137 ConditionalJump @b31, v223 @ TEMP_v23\n\tv260 = v100;\n\tv225 = \"il2cpp_codegen_runtime_class_init\"(v260, v91, v89, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_008E:\n\tUnityEngine.Debug::Log(v95);\n\treturn 0;\nL_0097:\n\tv283 = *([v271 @ X11_v6]);\n\tv284 = v283 << 4;\n\tv285 = v215 + v284;\n\tv286 = v285 + 0x130;\nL_009E:\n\tv259 = UnityEngine.Purchasing.IStoreController::get_products(v125.sStoreController);\n\treturnVal3 = UnityEngine.Purchasing.ProductCollection::WithID(v259, v75._id);\n\treturn returnVal3;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Product GetProduct(string productName)
		{
			string message;
			if (IsInitialized())
			{
				IAPProduct iAPProductByName = GetIAPProductByName(productName);
				if (iAPProductByName != null)
				{
					ProductCollection products = sStoreController.products;
					return products.WithID(iAPProductByName.Id);
				}
				message = "Couldn't get product: not found product with name: " + productName;
			}
			else
			{
				message = "Couldn't get product: In-App Purchasing is not initialized.";
			}
			Debug.Log(message);
			return null;
		}

		[Token(Token = "0x60004D1")]
		[Address(RVA = "0xBF8B90", Offset = "0xBF8B90", Length = "0x1CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1F07888]);\n\tv21 = *([v20 @ X8_v34]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022F0C]) = v40;\nL_001A:\n\tgoto L_0020;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0020;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0020:\n\tv54 = EasyMobile.InAppPurchasing::IsInitialized();\n\tv56 = v54 == 0;\n\tif (v56) goto L_006E;\n\tgoto L_002F;\n\tv67 = *([v57 @ X0_v12+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_002F;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v57, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002F:\n\tv75 = EasyMobile.InAppPurchasing::GetIAPProductByName(productName);\n\tv87 = v75 == 0;\n\tif (v87) goto L_007D;\n\tgoto L_0048;\n\tv113 = *([v104 @ X0_v22 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv114 = v113 == 0;\n\tv115 = ~v114;\n\t// 59 ConditionalJump @b40, v115 @ TEMP_v34\n\tv186 = \"il2cpp_codegen_runtime_class_init\"(v104, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv117 = EasyMobile.InAppPurchasing;\nL_0048:\n\tgoto L_0098;\n\tv242 = *([v188 @ X8_v25+B0]);\n\tv243 = 0;\n\tv244 = v242 + 8;\n\tv246 = *([v289 @ X11_v7-8]);\n\tv295 = v246 == v191;\n\tif (v295) goto L_0091;\n\tv268 = v290 + 1;\n\tv300 = v268 < v190;\n\tv264 = ~v300;\n\tv266 = v289 + 0x10;\n\tv248 = ~v264;\n\tif (v248) goto L_FFFFFFFF;\n\tv269 = v121;\n\tv270 = 0;\n\tv271 = 0x8909C4(v269, v191, v270, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_0098;\nL_006E:\n\tgoto L_FFFFFFFF;\n\tv76 = *([v63 @ X0_v8+E0]);\n\tv77 = v76 == 0;\n\tv78 = ~v77;\n\tif (v78) goto L_FFFFFFFF;\n\tv80 = \"il2cpp_codegen_runtime_class_init\"(v63, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_008E;\nL_007D:\n\tv95 = System.String::Concat(\"Couldn't get product localized data: not found product with name: \", productName);\n\tgoto L_008E;\n\tv194 = *([v100 @ X8_v20+E0]);\n\tv195 = v194 == 0;\n\tv196 = ~v195;\n\t// 137 ConditionalJump @b31, v196 @ TEMP_v24\n\tv278 = v100;\n\tv198 = \"il2cpp_codegen_runtime_class_init\"(v278, v91, v89, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_008E:\n\tUnityEngine.Debug::Log(v95);\n\tgoto L_00A7;\nL_0091:\n\tv301 = *([v289 @ X11_v7]);\n\tv302 = v301 << 4;\n\tv303 = v188 + v302;\n\tv304 = v303 + 0x130;\nL_0098:\n\tv276 = UnityEngine.Purchasing.IStoreController::get_products(v120.sStoreController);\n\tv275 = UnityEngine.Purchasing.ProductCollection::WithID(v276, v75._id);\n\treturnVal1 = v275.<metadata>k__BackingField;\nL_00A7:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 96 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ProductMetadata GetProductLocalizedData(string productName)
		{
			string message;
			if (IsInitialized())
			{
				IAPProduct iAPProductByName = GetIAPProductByName(productName);
				if (iAPProductByName != null)
				{
					ProductCollection products = sStoreController.products;
					Product product = products.WithID(iAPProductByName.Id);
					return product.metadata;
				}
				message = "Couldn't get product localized data: not found product with name: " + productName;
			}
			else
			{
				message = "Couldn't get product localized data: In-App Purchasing is not initialized.";
			}
			Debug.Log(message);
			return null;
		}

		[Token(Token = "0x60004D2")]
		[Address(RVA = "0xBF8D5C", Offset = "0xBF8D5C", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EC7288]);\n\tv19 = *([v18 @ X8_v21]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F0D]) = v38;\nL_0014:\n\tv40 = UnityEngine.Application::get_platform();\n\tv50 = v40 != 8;\n\tif (v50) goto L_005B;\n\tgoto L_002D;\n\tv63 = *([v53 @ X0_v11+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_002D;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v53, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tv149 = EasyMobile.InAppPurchasing::GetPurchaseReceipt(productName);\n\tv83 = v149 == 0;\n\tif (v83) goto L_006C;\n\tgoto L_FFFFFFFF;\n\tv123 = v123_asT == 0;\n\tif (v123) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_006C;\nL_005B:\n\tgoto L_0065;\n\tv72 = *([v59 @ X0_v7+E0]);\n\tv73 = v72 == 0;\n\tv74 = ~v73;\n\tif (v74) goto L_0065;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v59, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0065:\n\tUnityEngine.Debug::Log(\"Getting Apple IAP receipt is only available on iOS.\");\nL_006C:\n\treturn returnVal1;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AppleInAppPurchaseReceipt GetAppleIAPReceipt(string productName)
		{
			RuntimePlatform platform = Application.platform;
			AppleInAppPurchaseReceipt result;
			if (platform == RuntimePlatform.IPhonePlayer)
			{
				IPurchaseReceipt purchaseReceipt = GetPurchaseReceipt(productName);
				bool flag = purchaseReceipt == null;
				result = (AppleInAppPurchaseReceipt)purchaseReceipt;
				if (!flag)
				{
					AppleInAppPurchaseReceipt appleInAppPurchaseReceipt = purchaseReceipt as AppleInAppPurchaseReceipt;
					if (appleInAppPurchaseReceipt == null)
					{
						purchaseReceipt = null;
					}
					result = (AppleInAppPurchaseReceipt)purchaseReceipt;
				}
			}
			else
			{
				Debug.Log("Getting Apple IAP receipt is only available on iOS.");
				result = null;
			}
			return result;
		}

		[Token(Token = "0x60004D3")]
		[Address(RVA = "0xBF922C", Offset = "0xBF922C", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EECAF0]);\n\tv19 = *([v18 @ X8_v21]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F0E]) = v38;\nL_0014:\n\tv40 = UnityEngine.Application::get_platform();\n\tv50 = v40 != 0xB;\n\tif (v50) goto L_005B;\n\tgoto L_002D;\n\tv63 = *([v53 @ X0_v11+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_002D;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v53, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tv149 = EasyMobile.InAppPurchasing::GetPurchaseReceipt(productName);\n\tv83 = v149 == 0;\n\tif (v83) goto L_006C;\n\tgoto L_FFFFFFFF;\n\tv123 = v123_asT == 0;\n\tif (v123) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_006C;\nL_005B:\n\tgoto L_0065;\n\tv72 = *([v59 @ X0_v7+E0]);\n\tv73 = v72 == 0;\n\tv74 = ~v73;\n\tif (v74) goto L_0065;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v59, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0065:\n\tUnityEngine.Debug::Log(\"Getting Google Play receipt is only available on Android.\");\nL_006C:\n\treturn returnVal1;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static GooglePlayReceipt GetGooglePlayReceipt(string productName)
		{
			RuntimePlatform platform = Application.platform;
			GooglePlayReceipt result;
			if (platform == RuntimePlatform.Android)
			{
				IPurchaseReceipt purchaseReceipt = GetPurchaseReceipt(productName);
				bool flag = purchaseReceipt == null;
				result = (GooglePlayReceipt)purchaseReceipt;
				if (!flag)
				{
					GooglePlayReceipt googlePlayReceipt = purchaseReceipt as GooglePlayReceipt;
					if (googlePlayReceipt == null)
					{
						purchaseReceipt = null;
					}
					result = (GooglePlayReceipt)purchaseReceipt;
				}
			}
			else
			{
				Debug.Log("Getting Google Play receipt is only available on Android.");
				result = null;
			}
			return result;
		}

		[Token(Token = "0x60004D4")]
		[Address(RVA = "0xBF8E48", Offset = "0xBF8E48", Length = "0x3E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EDEF40]);\n\tv25 = *([v24 @ X8_v81]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022F0F]) = v44;\nL_0018:\n\tv47 = UnityEngine.Application::get_platform();\n\tv52 = v47 == 0xB;\n\tif (v52) goto L_0036;\n\tv58 = UnityEngine.Application::get_platform();\n\tv60 = v58 != 8;\n\tif (v60) goto L_0099;\nL_0036:\n\tgoto L_003C;\n\tv86 = *([v81 @ X0_v11 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv87 = v86 == 0;\n\tv88 = ~v87;\n\tif (v88) goto L_003C;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v81, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_003C:\n\tv93 = EasyMobile.InAppPurchasing::IsInitialized();\n\tv101 = v93 == 0;\n\tif (v101) goto L_008A;\n\tgoto L_004B;\n\tv184 = *([v111 @ X0_v17+E0]);\n\tv185 = v184 == 0;\n\tv186 = ~v185;\n\tif (v186) goto L_004B;\n\tv188 = \"il2cpp_codegen_runtime_class_init\"(v111, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_004B:\n\tv192 = EasyMobile.InAppPurchasing::GetIAPProductByName(productName);\n\tv231 = v192 == 0;\n\tif (v231) goto L_00A7;\n\tgoto L_0064;\n\tv344 = *([v269 @ X0_v27 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv345 = v344 == 0;\n\tv346 = ~v345;\n\t// 87 ConditionalJump @b88, v346 @ TEMP_v78\n\tv410 = \"il2cpp_codegen_runtime_class_init\"(v269, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv348 = EasyMobile.InAppPurchasing;\nL_0064:\n\tgoto L_00BF;\n\tv472 = *([v412 @ X8_v29+B0]);\n\tv473 = 0;\n\tv474 = v472 + 8;\n\tv476 = *([v539 @ X11_v19-8]);\n\tv554 = v476 == v415;\n\tif (v554) goto L_00B8;\n\tv480 = v540 + 1;\n\tv567 = v480 < v414;\n\tv498 = ~v567;\n\tv478 = v539 + 0x10;\n\tv482 = ~v498;\n\tif (v482) goto L_FFFFFFFF;\n\tv499 = v175;\n\tv500 = 0;\n\tv501 = 0x8909C4(v499, v415, v500, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_00BF;\nL_008A:\n\tgoto L_FFFFFFFF;\n\tv193 = *([v117 @ X0_v14+E0]);\n\tv194 = v193 == 0;\n\tv195 = ~v194;\n\tif (v195) goto L_FFFFFFFF;\n\tv196 = \"il2cpp_codegen_runtime_class_init\"(v117, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0185;\nL_0099:\n\tgoto L_FFFFFFFF;\n\tv102 = *([v96 @ X0_v77+E0]);\n\tv103 = v102 == 0;\n\tv104 = ~v103;\n\tif (v104) goto L_FFFFFFFF;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v96, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0185;\nL_00A7:\n\tv276 = System.String::Concat(\"Couldn't get purchase receipt: not found product with name: \", productName);\n\tgoto L_FFFFFFFF;\n\tv467 = *([v226 @ X8_v22+E0]);\n\tv468 = v467 == 0;\n\tv469 = ~v468;\n\tif (v469) goto L_FFFFFFFF;\n\tv537 = v226;\n\tv471 = \"il2cpp_codegen_runtime_class_init\"(v537, v206, v203, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0187;\nL_00B8:\n\tv568 = *([v539 @ X11_v19]);\n\tv569 = v568 << 4;\n\tv570 = v412 + v569;\n\tv571 = v570 + 0x130;\nL_00BF:\n\tv527 = UnityEngine.Purchasing.IStoreController::get_products(v351.sStoreController);\n\tv526 = UnityEngine.Purchasing.ProductCollection::WithID(v527, v192._id);\n\tv576 = UnityEngine.Purchasing.Product::get_hasReceipt(v526);\n\tv578 = v576 == 0;\n\tif (v578) goto L_015F;\n\tgoto L_00D8;\n\tv589 = *([v579 @ X0_v45 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv590 = v589 == 0;\n\tv591 = ~v590;\n\tif (v591) goto L_00D8;\n\tv593 = \"il2cpp_codegen_runtime_class_init\"(v579, v137, v131, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00D8:\n\tv596 = EasyMobile.InAppPurchasing::IsReceiptValidationEnabled();\n\tv604 = v596 == 0;\n\tif (v604) goto L_016E;\n\tgoto L_00EA;\n\tv615 = *([v605 @ X0_v51+E0]);\n\tv616 = v615 == 0;\n\tv617 = ~v616;\n\tif (v617) goto L_00EA;\n\tv619 = \"il2cpp_codegen_runtime_class_init\"(v605, v137, v131, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00EA:\n\tv261 = EasyMobile.InAppPurchasing::ValidateReceipt(v526.<receipt>k__BackingField, &v125 @ stack_-38_v9 (UnityEngine.Purchasing.Security.IPurchaseReceipt[]), 0);\n\tv629 = v261 == 0;\n\tif (v629) goto L_017D;\n\tv565 = v125.Length;\n\tv243 = v125.Length < 1;\n\tif (v243) goto L_FFFFFFFF;\nL_0101:\n\tv654 = v280 < v565;\n\tv454 = ~v654;\n\tif (v454) goto L_0195;\n\tv330 = v125[v280 @ X22_v7 (System.Int32)];\n\tv655 = *([v330 @ X20_v14 (UnityEngine.Purchasing.Security.IPurchaseReceipt)]);\n\tv658 = *([v655 @ X8_v60 (Il2CppClass<UnityEngine.Purchasing.Security.IPurchaseReceipt>)+126]) == 0;\n\tif (v658) goto L_0132;\n\tv690 = *([v655 @ X8_v60 (Il2CppClass<UnityEngine.Purchasing.Security.IPurchaseReceipt>)+B0]) + 8;\nL_011D:\n\tv705 = *([v690 @ X11_v14-8]) == UnityEngine.Purchasing.Security.IPurchaseReceipt;\n\tif (v705) goto L_0135;\n\tv691 = v691 + 1;\n\tv710 = v691 < *([v655 @ X8_v60 (Il2CppClass<UnityEngine.Purchasing.Security.IPurchaseReceipt>)+126]);\n\tv685 = ~v710;\n\tv690 = v690 + 0x10;\n\tv669 = ~v685;\n\tif (v669) goto L_011D;\nL_0132:\n\tv716 = 0x8909C4(v125[v280 @ X22_v7 (System.Int32)], UnityEngine.Purchasing.Security.IPurchaseReceipt, 1, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_013C;\nL_0135:\n\tv712 = *([v690 @ X11_v14]) + 1;\n\tv713 = v712 << 4;\n\tv714 = v655 + v713;\n\tv716 = v714 + 0x130;\nL_013C:\n\t*([v716 @ X0_v59])(v457, v125[v280 @ X22_v7 (System.Int32)], *([v716 @ X0_v59+8]), v425, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv333 = v526.<definition>k__BackingField;\n\tv326 = System.String::Equals(v457, v333.<storeSpecificId>k__BackingField);\n\tv721 = v326 == 0;\n\tv328 = ~v721;\n\tif (v328) goto L_0192;\n\tv565 = v125.Length;\n\tv280 = v280 + 1;\n\tv300 = v280 < v125.Length;\n\tif (v300) goto L_0101;\n\tgoto L_0192;\nL_015F:\n\tgoto L_FFFFFFFF;\n\tv597 = *([v585 @ X0_v42+E0]);\n\tv598 = v597 == 0;\n\tv599 = ~v598;\n\tif (v599) goto L_FFFFFFFF;\n\tv600 = \"il2cpp_codegen_runtime_class_init\"(v585, v137, v131, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0185;\nL_016E:\n\tgoto L_FFFFFFFF;\n\tv622 = *([v611 @ X0_v48+E0]);\n\tv623 = v622 == 0;\n\tv624 = ~v623;\n\tif (v624) goto L_FFFFFFFF;\n\tv625 = \"il2cpp_codegen_runtime_class_init\"(v611, v137, v131, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0185;\nL_017D:\n\tgoto L_FFFFFFFF;\n\tv638 = *([v632 @ X0_v55+E0]);\n\tv639 = v638 == 0;\n\tv640 = ~v639;\n\tif (v640) goto L_FFFFFFFF;\n\tv641 = \"il2cpp_codegen_runtime_class_init\"(v632, v136, v130, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0185:\n\tv220 = *([v176 @ X8_v5 (System.String)]);\nL_0187:\n\tUnityEngine.Debug::Log(v220);\nL_0192:\n\treturn v329;\n\tv536 = new System.NullReferenceException();\nL_0195:\n\tv566 = new System.IndexOutOfRangeException();\n\tthrow v566;\n\treturn returnVal2;\n// 243 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static IPurchaseReceipt GetPurchaseReceipt(string productName)
		{
			//IL_0408: Expected I, but got O
			//IL_0416: Expected O, but got I
			//IL_00d7: Expected I, but got O
			//IL_01e7: Expected I, but got O
			//IL_0222: Expected O, but got I
			//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ad: Expected O, but got Unknown
			//IL_02ca: Expected O, but got I
			//IL_02d9: Expected O, but got I
			//IL_026e: Expected O, but got I
			RuntimePlatform platform = Application.platform;
			string text;
			if (platform != RuntimePlatform.Android)
			{
				RuntimePlatform platform2 = Application.platform;
				if (platform2 != RuntimePlatform.IPhonePlayer)
				{
					text = "Getting purchase receipt is only available on Android and iOS.";
					goto IL_0400;
				}
			}
			IntPtr intPtr;
			IPurchaseReceipt result;
			if (IsInitialized())
			{
				IAPProduct iAPProductByName = GetIAPProductByName(productName);
				if (iAPProductByName == null)
				{
					string text2 = "Couldn't get purchase receipt: not found product with name: " + productName;
					intPtr = (IntPtr)text2;
					goto IL_040d;
				}
				ProductCollection products = sStoreController.products;
				Product product = products.WithID(iAPProductByName.Id);
				if (product.hasReceipt)
				{
					if (IsReceiptValidationEnabled())
					{
						if (ValidateReceipt(product.receipt, out var purchaseReceipts))
						{
							int num = purchaseReceipts.Length;
							if (purchaseReceipts.Length < 1)
							{
								goto IL_03af;
							}
							int num2 = 0;
							bool flag = false;
							string text3 = default(string);
							while (true)
							{
								if (num2 < num)
								{
									IPurchaseReceipt purchaseReceipt = purchaseReceipts[num2];
									IntPtr intPtr2 = (IntPtr)purchaseReceipt;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ X8_v60 (Il2CppClass<UnityEngine.Purchasing.Security.IPurchaseReceipt>)+126]");
									if ((IntPtr)0 == (IntPtr)0)
									{
										goto IL_0287;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ X8_v60 (Il2CppClass<UnityEngine.Purchasing.Security.IPurchaseReceipt>)+B0]");
									object obj = 0L + 8L;
									int num3 = 0;
									while (true)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v690 @ X11_v14-8]");
										if ((IntPtr)0 == (IntPtr)typeof(IPurchaseReceipt))
										{
											break;
										}
										num3++;
										int num4 = num3;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ X8_v60 (Il2CppClass<UnityEngine.Purchasing.Security.IPurchaseReceipt>)+126]");
										bool flag2 = (long)num4 < 0L;
										bool flag3 = !flag2;
										obj = (long)(IntPtr)obj + 16L;
										if (!flag3)
										{
											continue;
										}
										goto IL_0287;
									}
									object obj2 = obj + 1;
									int num5 = (int)((long)(IntPtr)obj2 << 4);
									object obj3 = (long)intPtr2 + (long)num5;
									object obj4 = (long)(IntPtr)obj3 + 304L;
									goto IL_0445;
								}
								IndexOutOfRangeException ex = new IndexOutOfRangeException();
								throw ex;
								IL_0445:
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v716 @ X0_v59] (should have been resolved before IL gen)");
								ProductDefinition definition = product.definition;
								bool flag4 = text3.Equals(definition.storeSpecificId);
								bool flag5 = !flag4;
								bool flag6 = !flag5;
								result = purchaseReceipts[num2];
								if (flag6)
								{
									break;
								}
								num = purchaseReceipts.Length;
								num2++;
								bool flag7 = num2 < purchaseReceipts.Length;
								flag = false;
								if (!flag7)
								{
									result = null;
									break;
								}
								continue;
								IL_0287:
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
								flag = true;
								goto IL_0445;
							}
							goto IL_0461;
						}
						text = "Couldn't get purchase receipt: the receipt of this product is invalid.";
					}
					else
					{
						text = "Couldn't get purchase receipt: please enable receipt validation.";
					}
				}
				else
				{
					text = "Couldn't get purchase receipt: this product doesn't have a receipt.";
				}
			}
			else
			{
				text = "Couldn't get purchase receipt: In-App Purchasing is not initialized.";
			}
			goto IL_0400;
			IL_040d:
			Debug.Log((long)intPtr);
			goto IL_03af;
			IL_03af:
			result = null;
			goto IL_0461;
			IL_0400:
			intPtr = (IntPtr)text;
			goto IL_040d;
			IL_0461:
			return result;
		}

		[Token(Token = "0x60004D5")]
		[Address(RVA = "0xBF9318", Offset = "0xBF9318", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EC5270]);\n\tv15 = *([v14 @ X8_v28]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022F10]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = EasyMobile.InAppPurchasing::IsInitialized();\n\tv51 = v49 == 0;\n\tif (v51) goto L_003E;\n\tv53 = EasyMobile.EM_Settings::get_InAppPurchasing();\n\tv76 = ~v53.mValidateAppleReceipt;\n\tif (v76) goto L_0049;\n\tgoto L_FFFFFFFF;\n\tv99 = *([v73 @ X0_v14+E0]);\n\tv100 = v99 == 0;\n\tv101 = ~v100;\n\tif (v101) goto L_FFFFFFFF;\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v73, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tgoto L_0053;\nL_003E:\n\tgoto L_FFFFFFFF;\n\tv62 = *([v56 @ X0_v8+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_FFFFFFFF;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v56, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tgoto L_0053;\nL_0049:\n\tgoto L_FFFFFFFF;\n\tv105 = *([v73 @ X0_v14+E0]);\n\tv106 = v105 == 0;\n\tv107 = ~v106;\n\tif (v107) goto L_FFFFFFFF;\n\tv108 = \"il2cpp_codegen_runtime_class_init\"(v73, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0053:\n\tUnityEngine.Debug::Log(*([v86 @ X8_v7 (System.String)]));\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AppleReceipt GetAppleAppReceipt()
		{
			string message;
			if (IsInitialized())
			{
				IAPSettings inAppPurchasing = EM_Settings.InAppPurchasing;
				message = ((!inAppPurchasing.ValidateAppleReceipt) ? "Couldn't get Apple app receipt: Please enable Apple receipt validation." : "Getting Apple app receipt is only available on iOS.");
			}
			else
			{
				message = "Couldn't get Apple app receipt: In-App Purchasing is not initialized.";
			}
			Debug.Log(message);
			return null;
		}

		[Token(Token = "0x60004D6")]
		[Address(RVA = "0xBF9418", Offset = "0xBF9418", Length = "0x434")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EF7678]);\n\tv21 = *([v20 @ X8_v90]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022F11]) = v40;\nL_0015:\n\tv42 = UnityEngine.Application::get_platform();\n\tv47 = v42 == 0xB;\n\tif (v47) goto L_0033;\n\tv53 = UnityEngine.Application::get_platform();\n\tv55 = v53 != 8;\n\tif (v55) goto L_0096;\nL_0033:\n\tgoto L_0039;\n\tv81 = *([v76 @ X0_v9 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv82 = v81 == 0;\n\tv83 = ~v82;\n\tif (v83) goto L_0039;\n\tv85 = \"il2cpp_codegen_runtime_class_init\"(v76, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0039:\n\tv88 = EasyMobile.InAppPurchasing::IsInitialized();\n\tv96 = v88 == 0;\n\tif (v96) goto L_0087;\n\tgoto L_0048;\n\tv176 = *([v106 @ X0_v15+E0]);\n\tv177 = v176 == 0;\n\tv178 = ~v177;\n\tif (v178) goto L_0048;\n\tv180 = \"il2cpp_codegen_runtime_class_init\"(v106, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0048:\n\tv184 = EasyMobile.InAppPurchasing::GetIAPProductByName(productName);\n\tv222 = v184 == 0;\n\tif (v222) goto L_00A4;\n\tgoto L_0061;\n\tv310 = *([v229 @ X0_v25 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv311 = v310 == 0;\n\tv312 = ~v311;\n\t// 84 ConditionalJump @b93, v312 @ TEMP_v80\n\tv324 = \"il2cpp_codegen_runtime_class_init\"(v229, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv314 = EasyMobile.InAppPurchasing;\nL_0061:\n\tgoto L_00BC;\n\tv405 = *([v326 @ X8_v26+B0]);\n\tv406 = 0;\n\tv407 = v405 + 8;\n\tv409 = *([v444 @ X11_v16-8]);\n\tv459 = v409 == v329;\n\tif (v459) goto L_00B5;\n\tv413 = v445 + 1;\n\tv464 = v413 < v328;\n\tv431 = ~v464;\n\tv411 = v444 + 0x10;\n\tv415 = ~v431;\n\tif (v415) goto L_FFFFFFFF;\n\tv432 = v167;\n\tv433 = 0;\n\tv434 = 0x8909C4(v432, v329, v433, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_00BC;\nL_0087:\n\tgoto L_FFFFFFFF;\n\tv185 = *([v112 @ X0_v12+E0]);\n\tv186 = v185 == 0;\n\tv187 = ~v186;\n\tif (v187) goto L_FFFFFFFF;\n\tv188 = \"il2cpp_codegen_runtime_class_init\"(v112, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_0159;\nL_0096:\n\tgoto L_FFFFFFFF;\n\tv97 = *([v91 @ X0_v81+E0]);\n\tv98 = v97 == 0;\n\tv99 = ~v98;\n\tif (v99) goto L_FFFFFFFF;\n\tv101 = \"il2cpp_codegen_runtime_class_init\"(v91, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_0159;\nL_00A4:\n\tv236 = System.String::Concat(\"Couldn't get subscription info: not found product with name: \", productName);\n\tgoto L_FFFFFFFF;\n\tv400 = *([v217 @ X8_v20+E0]);\n\tv401 = v400 == 0;\n\tv402 = ~v401;\n\tif (v402) goto L_FFFFFFFF;\n\tv442 = v217;\n\tv404 = \"il2cpp_codegen_runtime_class_init\"(v442, v197, v194, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_015B;\nL_00B5:\n\tv465 = *([v444 @ X11_v16]);\n\tv466 = v465 << 4;\n\tv467 = v326 + v466;\n\tv468 = v467 + 0x130;\nL_00BC:\n\tv438 = UnityEngine.Purchasing.IStoreController::get_products(v317.sStoreController);\n\tv379 = UnityEngine.Purchasing.ProductCollection::WithID(v438, v184._id);\n\tv394 = v379.<definition>k__BackingField;\n\tv138 = v394.<type>k__BackingField != 2;\n\tif (v138) goto L_00EF;\n\tv475 = System.String::IsNullOrEmpty(v379.<receipt>k__BackingField);\n\tv483 = v475 == 0;\n\tif (v483) goto L_00FD;\n\tgoto L_FFFFFFFF;\n\tv500 = *([v492 @ X0_v69+E0]);\n\tv501 = v500 == 0;\n\tv502 = ~v501;\n\tif (v502) goto L_FFFFFFFF;\n\tv503 = \"il2cpp_codegen_runtime_class_init\"(v492, v128, v123, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_0159;\nL_00EF:\n\tgoto L_FFFFFFFF;\n\tv484 = *([v478 @ X0_v35+E0]);\n\tv485 = v484 == 0;\n\tv486 = ~v485;\n\tif (v486) goto L_FFFFFFFF;\n\tv487 = \"il2cpp_codegen_runtime_class_init\"(v478, v129, v123, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_0159;\nL_00FD:\n\tgoto L_0104;\n\tv506 = *([v496 @ X0_v40+E0]);\n\tv507 = v506 == 0;\n\tv508 = ~v507;\n\tif (v508) goto L_0104;\n\tv510 = \"il2cpp_codegen_runtime_class_init\"(v496, v128, v123, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0104:\n\tv514 = EasyMobile.InAppPurchasing::IsProductAvailableForSubscriptionManager(v379.<receipt>k__BackingField);\n\tv516 = v514 == 0;\n\tif (v516) goto L_0151;\n\tgoto L_0114;\n\tv527 = *([v517 @ X0_v47 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv528 = v527 == 0;\n\tv529 = ~v528;\n\tif (v529) goto L_0114;\n\tv543 = \"il2cpp_codegen_runtime_class_init\"(v517, v128, v123, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv531 = EasyMobile.InAppPurchasing;\nL_0114:\n\tv569 = v534.sAppleExtensions;\n\tv536 = v534.sAppleExtensions == 0;\n\tif (v536) goto L_018B;\n\tgoto L_0126;\n\tv564 = *([v530 @ X0_v48 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv565 = v564 == 0;\n\tv566 = ~v565;\n\tif (v566) goto L_0126;\n\tv607 = EasyMobile.InAppPurchasing;\n\tv395 = *([v607 @ X8_v66 (Il2CppClass<EasyMobile.InAppPurchasing>)+B8]);\n\tv390 = v395.sAppleExtensions;\nL_0126:\n\tv572 = *([v569 @ X20_v12 (UnityEngine.Purchasing.IAppleExtensions)]);\n\tv576 = *([v572 @ X8_v55 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+126]) == 0;\n\tif (v576) goto L_0149;\n\tv609 = *([v572 @ X8_v55 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+B0]) + 8;\nL_0134:\n\tv624 = *([v609 @ X11_v11-8]) == UnityEngine.Purchasing.IAppleExtensions;\n\tif (v624) goto L_0165;\n\tv610 = v610 + 1;\n\tv630 = v610 < *([v572 @ X8_v55 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+126]);\n\tv603 = ~v630;\n\tv609 = v609 + 0x10;\n\tv587 = ~v603;\n\tif (v587) goto L_0134;\nL_0149:\n\tv636 = 0x8909C4(v534.sAppleExtensions, UnityEngine.Purchasing.IAppleExtensions, 7, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_016C;\nL_0151:\n\tgoto L_FFFFFFFF;\n\tv537 = *([v523 @ X0_v44+E0]);\n\tv538 = v537 == 0;\n\tv539 = ~v538;\n\tif (v539) goto L_FFFFFFFF;\n\tv540 = \"il2cpp_codegen_runtime_class_init\"(v523, v128, v123, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0159:\n\tv211 = *([v168 @ X8_v4 (System.String)]);\nL_015B:\n\tUnityEngine.Debug::Log(v211);\n\treturn 0;\nL_0165:\n\tv632 = *([v609 @ X11_v11]) + 7;\n\tv633 = v632 << 4;\n\tv634 = v572 + v633;\n\tv636 = v634 + 0x130;\nL_016C:\n\t*([v636 @ X0_v55])(v381, v534.sAppleExtensions, *([v636 @ X0_v55+8]), v337, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv555 = v381 == 0;\n\tif (v555) goto L_018B;\n\tv396 = v379.<definition>k__BackingField;\n\tv382 = System.Collections.Generic.Dictionary`2<System.String, System.String>::ContainsKey(v381, v396.<storeSpecificId>k__BackingField);\n\tv554 = v382 == 0;\n\tif (v554) goto L_FFFFFFFF;\n\tv397 = v379.<definition>k__BackingField;\n\tv552 = System.Collections.Generic.Dictionary`2<System.String, System.String>::get_Item(v381, v397.<storeSpecificId>k__BackingField);\n\tgoto L_018B;\nL_018B:\n\tv383 = new UnityEngine.Purchasing.SubscriptionManager();\n\tUnityEngine.Purchasing.SubscriptionManager::.ctor(v383, v379, v392);\n\treturnVal3 = UnityEngine.Purchasing.SubscriptionManager::getSubscriptionInfo(v383);\n\treturn returnVal3;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 243 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static SubscriptionInfo GetSubscriptionInfo(string productName)
		{
			//IL_03b3: Expected I, but got O
			//IL_03c1: Expected O, but got I
			//IL_00d7: Expected I, but got O
			//IL_01c9: Expected I, but got O
			//IL_0204: Expected O, but got I
			//IL_029d: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a2: Expected O, but got Unknown
			//IL_02bf: Expected O, but got I
			//IL_02ce: Expected O, but got I
			//IL_0250: Expected O, but got I
			RuntimePlatform platform = Application.platform;
			string text;
			if (platform != RuntimePlatform.Android)
			{
				RuntimePlatform platform2 = Application.platform;
				if (platform2 != RuntimePlatform.IPhonePlayer)
				{
					text = "Getting subscription info is only available on Android and iOS.";
					goto IL_03ab;
				}
			}
			IntPtr intPtr;
			Product product;
			string intro_json;
			int num4;
			if (IsInitialized())
			{
				IAPProduct iAPProductByName = GetIAPProductByName(productName);
				if (iAPProductByName == null)
				{
					string text2 = "Couldn't get subscription info: not found product with name: " + productName;
					intPtr = (IntPtr)text2;
					goto IL_03b8;
				}
				ProductCollection products = sStoreController.products;
				product = products.WithID(iAPProductByName.Id);
				ProductDefinition definition = product.definition;
				if (definition.type == ProductType.Subscription)
				{
					if (string.IsNullOrEmpty(product.receipt))
					{
						text = "Couldn't get subscription info: this product doesn't have a valid receipt.";
					}
					else
					{
						if (IsProductAvailableForSubscriptionManager(product.receipt))
						{
							IAppleExtensions appleExtensions = sAppleExtensions;
							bool flag = sAppleExtensions == null;
							intro_json = (string)(object)sAppleExtensions;
							if (!flag)
							{
								IntPtr intPtr2 = (IntPtr)appleExtensions;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ X8_v55 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+126]");
								if ((IntPtr)0 == (IntPtr)0)
								{
									goto IL_0269;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ X8_v55 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+B0]");
								object obj = 0L + 8L;
								int num = 0;
								while (true)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ X11_v11-8]");
									if ((IntPtr)0 == (IntPtr)typeof(IAppleExtensions))
									{
										break;
									}
									num++;
									int num2 = num;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ X8_v55 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+126]");
									bool flag2 = (long)num2 < 0L;
									bool flag3 = !flag2;
									obj = (long)(IntPtr)obj + 16L;
									if (!flag3)
									{
										continue;
									}
									goto IL_0269;
								}
								object obj2 = obj + 7;
								int num3 = (int)((long)(IntPtr)obj2 << 4);
								object obj3 = (long)intPtr2 + (long)num3;
								object obj4 = (long)(IntPtr)obj3 + 304L;
								num4 = 0;
								goto IL_041d;
							}
							goto IL_044c;
						}
						text = "Couldn't get subscription info: this product is not available for SubscriptionManager class, only products that are purchase by 1.19+ SDK can use this class.";
					}
				}
				else
				{
					text = "Couldn't get subscription info: this product is not a subscription product.";
				}
			}
			else
			{
				text = "Couldn't get subscripton info: In-App Purchasing is not initialized.";
			}
			goto IL_03ab;
			IL_0269:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			num4 = 7;
			goto IL_041d;
			IL_044c:
			SubscriptionManager subscriptionManager = new SubscriptionManager(product, intro_json);
			return subscriptionManager.getSubscriptionInfo();
			IL_03b8:
			Debug.Log((long)intPtr);
			return null;
			IL_03ab:
			intPtr = (IntPtr)text;
			goto IL_03b8;
			IL_041d:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v636 @ X0_v55] (should have been resolved before IL gen)");
			Dictionary<string, string> dictionary = default(Dictionary<string, string>);
			bool flag4 = dictionary == null;
			intro_json = (string)(object)dictionary;
			if (!flag4)
			{
				ProductDefinition definition2 = product.definition;
				if (dictionary.ContainsKey(definition2.storeSpecificId))
				{
					ProductDefinition definition3 = product.definition;
					string text3 = dictionary.get_Item(definition3.storeSpecificId);
					intro_json = text3;
				}
				else
				{
					intro_json = null;
				}
			}
			goto IL_044c;
		}

		[Token(Token = "0x60004D7")]
		[Address(RVA = "0xBF6F6C", Offset = "0xBF6F6C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EDA160]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F12]) = v38;\nL_0013:\n\tv39 = store < 0xA;\n\tv40 = ~v39;\n\tif (v40) goto L_002B;\n\tgoto L_002B;\nL_002B:\n\treturn v55.Empty;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetStoreName(IAPStore store)
		{
			if (store < (IAPStore)10)
			{
			}
			return string.Empty;
		}

		[Token(Token = "0x60004D8")]
		[Address(RVA = "0xBF6FD8", Offset = "0xBF6FD8", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = pType - 1;\n\tv5 = v3 == 0;\n\tv20 = pType != 2;\n\tif (v20) goto L_FFFFFFFF;\n\tgoto L_0019;\nL_0019:\n\treturn returnVal1;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ProductType GetProductType(IAPProductType pType)
		{
			int num = (int)(pType - 1);
			bool result = num == 0;
			if (pType == IAPProductType.Subscription)
			{
				return (ProductType)pType;
			}
			return result ? ProductType.NonConsumable : ProductType.Consumable;
		}

		[Token(Token = "0x60004D9")]
		[Address(RVA = "0xBF9C58", Offset = "0xBF9C58", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = store < 5;\n\tv2 = ~v0;\n\tv3 = store - 5;\n\tv5 = v3 == 0;\n\tv10 = ~v5;\n\tv11 = v2 & v10;\n\tif (v11) goto L_0011;\n\tv13 = 0x1819000 + 0xF90;\n\treturn *([v13 @ X8_v2 (System.Int32)+store @ X0 (EasyMobile.IAPAndroidStore)*4]);\nL_0011:\n\treturn 6;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AndroidStore GetAndroidStore(IAPAndroidStore store)
		{
			bool flag = store < IAPAndroidStore.NotSpecified;
			bool flag2 = !flag;
			int num = (int)(store - 5);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 25268224 + 3984;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ X8_v2 (System.Int32)+store @ X0 (EasyMobile.IAPAndroidStore)*4]");
				return AndroidStore.GooglePlay;
			}
			return AndroidStore.NotSpecified;
		}

		[Token(Token = "0x60004DA")]
		[Address(RVA = "0xBF9C78", Offset = "0xBF9C78", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = store < 5;\n\tv2 = ~v0;\n\tv3 = store - 5;\n\tv5 = v3 == 0;\n\tv10 = ~v5;\n\tv11 = v2 & v10;\n\tif (v11) goto L_0011;\n\tv13 = 0x1819000 + 0xFB0;\n\treturn *([v13 @ X8_v2 (System.Int32)+store @ X0 (EasyMobile.IAPAndroidStore)*4]);\nL_0011:\n\treturn 0;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AppStore GetAppStore(IAPAndroidStore store)
		{
			bool flag = store < IAPAndroidStore.NotSpecified;
			bool flag2 = !flag;
			int num = (int)(store - 5);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 25268224 + 4016;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ X8_v2 (System.Int32)+store @ X0 (EasyMobile.IAPAndroidStore)*4]");
				return AppStore.NotSpecified;
			}
			return default(AppStore);
		}

		[Token(Token = "0x60004DB")]
		[Address(RVA = "0xBF9C98", Offset = "0xBF9C98", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1F07AC0]);\n\tv17 = *([v16 @ X8_v38]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2022F13]) = v37;\nL_0018:\n\tgoto L_0022;\n\tv44 = *([v40 @ X0_v2+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0022;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0022:\n\tgoto L_002D;\n\tv56 = *([1F0A2E8]);\n\tv57 = *([v56 @ X8_v34]);\n\tv58 = \"il2cpp_codegen_initialize_method\"(v57, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv61 = 0 | 1;\n\t*([2023017]) = v61;\nL_002D:\n\tgoto L_0036;\n\tv66 = *([v62 @ X0_v5 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tgoto L_0036;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v62, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv70 = EasyMobile.InAppPurchasing;\nL_0036:\n\tv75 = v73.sStoreExtensionProvider == 0;\n\tif (v75) goto L_00BD;\n\tgoto L_0044;\n\tv141 = *([v69 @ X0_v6 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv142 = v141 == 0;\n\tv143 = ~v142;\n\tif (v143) goto L_0044;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v69, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0044:\n\tgoto L_004F;\n\tv202 = *([1F0A2E8]);\n\tv203 = *([v202 @ X8_v28]);\n\tv204 = \"il2cpp_codegen_initialize_method\"(v203, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv207 = 0 | 1;\n\t*([2023017]) = v207;\nL_004F:\n\tgoto L_0057;\n\tv212 = *([v208 @ X0_v11 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv213 = v212 == 0;\n\tv214 = ~v213;\n\tgoto L_0057;\n\tv219 = \"il2cpp_codegen_runtime_class_init\"(v208, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv216 = EasyMobile.InAppPurchasing;\nL_0057:\n\tv198 = v195.sStoreExtensionProvider;\n\tv222 = *([v198 @ X19_v6 (UnityEngine.Purchasing.IExtensionProvider)]);\n\tv127 = Il2CppMethodInfo;\n\tv225 = *([v222 @ X8_v19 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]) == 0;\n\tif (v225) goto L_007F;\n\tv267 = *([v222 @ X8_v19 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]) + 8;\nL_006B:\n\tv272 = *([v267 @ X11_v12-8]) == Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>;\n\tif (v272) goto L_0082;\n\tv266 = v266 + 1;\n\tv277 = v266 < *([v222 @ X8_v19 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]);\n\tv249 = ~v277;\n\tv267 = v267 + 0x10;\n\tv233 = ~v249;\n\tif (v233) goto L_006B;\nL_007F:\n\tv284 = 0x8909C4(v198, Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>, *([v127 @ X20_v4 (Il2CppMethodInfo)+48]), v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tgoto L_0088;\nL_0082:\n\tv279 = *([v267 @ X11_v12]) + *([v127 @ X20_v4 (Il2CppMethodInfo)+48]);\n\tv280 = v279 << 4;\n\tv281 = v222 + v280;\n\tv284 = v281 + 0x130;\nL_0088:\n\tv288 = UnityEngine.Purchasing.IExtensionProvider::GetExtension(*([v284 @ X0_v15+8]));\n\t*([v288 @ X0_v17 (UnityEngine.Purchasing.IAmazonExtensions)])(v129, v198, v288, *([v127 @ X20_v4 (Il2CppMethodInfo)+48]), v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv131 = v129 == 0;\n\tif (v131) goto L_00BD;\n\tgoto L_00CA;\n\tv295 = *([v291 @ X8_v22+B0]);\n\tv296 = 0;\n\tv297 = v295 + 8;\n\tv299 = *([v336 @ X11_v7-8]);\n\tv341 = v299 == v294;\n\tif (v341) goto L_00BE;\n\tv319 = v335 + 1;\n\tv346 = v319 < v293;\n\tv317 = ~v346;\n\tv321 = v336 + 0x10;\n\tv301 = ~v317;\n\tif (v301) goto L_FFFFFFFF;\n\tv322 = v135;\n\tv323 = 0;\n\tv324 = 0x8909C4(v322, v294, v323, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tgoto L_00CA;\nL_00BD:\n\treturn 0;\nL_00BE:\n\tv347 = *([v336 @ X11_v7]);\n\tv348 = v347 << 4;\n\tv349 = v291 + v348;\n\tv350 = v349 + 0x130;\nL_00CA:\n\tinterfaceTailCallResult = UnityEngine.Purchasing.IAmazonExtensions::get_amazonUserId(v129);\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 111 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetAmazonUserId()
		{
			//IL_001c: Expected I, but got O
			//IL_018c: Expected O, but got I
			//IL_005d: Expected O, but got I
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Expected O, but got Unknown
			//IL_0103: Expected O, but got I
			//IL_0112: Expected O, but got I
			//IL_00a9: Expected O, but got I
			if (sStoreExtensionProvider == null)
			{
				goto IL_011c;
			}
			IExtensionProvider extensionProvider = sStoreExtensionProvider;
			IntPtr intPtr = (IntPtr)extensionProvider;
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ X8_v19 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00c2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ X8_v19 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ X11_v12-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ X8_v19 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00c2;
			}
			object obj2 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ X20_v4 (Il2CppMethodInfo)+48]");
			object obj3 = obj2 + 0;
			int num3 = (int)((long)(IntPtr)obj3 << 4);
			object obj4 = (long)intPtr + (long)num3;
			object obj5 = (long)(IntPtr)obj4 + 304L;
			goto IL_017b;
			IL_017b:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ X0_v15+8]");
			IAmazonExtensions extension = ((IExtensionProvider)0).GetExtension<IAmazonExtensions>();
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v288 @ X0_v17 (UnityEngine.Purchasing.IAmazonExtensions)] (should have been resolved before IL gen)");
			IAmazonExtensions amazonExtensions = default(IAmazonExtensions);
			if (amazonExtensions != null)
			{
				return amazonExtensions.amazonUserId;
			}
			goto IL_011c;
			IL_011c:
			return null;
			IL_00c2:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_017b;
		}

		[Token(Token = "0x60004DC")]
		[Address(RVA = "0xBF9EA4", Offset = "0xBF9EA4", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EFEC88]);\n\tv21 = *([v20 @ X8_v24]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022F14]) = v40;\nL_0016:\n\tv42 = product.<definition>k__BackingField;\n\tv70 = System.String::Concat(\"Purchase deferred: \", v42.<id>k__BackingField);\n\tgoto L_002F;\n\tv105 = *([v74 @ X8_v9+E0]);\n\tv106 = v105 == 0;\n\tv107 = ~v106;\n\tif (v107) goto L_002F;\n\tv112 = v74;\n\tv109 = \"il2cpp_codegen_runtime_class_init\"(v112, v66, v50, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002F:\n\tUnityEngine.Debug::Log(v70);\n\tgoto L_003F;\n\tv118 = *([v114 @ X0_v9 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv119 = v118 == 0;\n\tv120 = ~v119;\n\tif (v120) goto L_003F;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v114, v53, v50, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv121 = EasyMobile.InAppPurchasing;\nL_003F:\n\tv92 = v98.PurchaseDeferred == 0;\n\tif (v92) goto L_0067;\n\tgoto L_004D;\n\tv129 = *([v90 @ X0_v10 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv130 = v129 == 0;\n\tv131 = ~v130;\n\tif (v131) goto L_004D;\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v90, v53, v50, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv138 = EasyMobile.InAppPurchasing;\n\tv135 = *([v138 @ X8_v19+B8]);\n\tv136 = *([v135 @ X8_v20+28]);\nL_004D:\n\tv61 = product.<definition>k__BackingField;\n\tv55 = EasyMobile.InAppPurchasing::GetIAPProductById(v61.<id>k__BackingField);\n\tSystem.Action`1<EasyMobile.IAPProduct>::Invoke(v98.PurchaseDeferred, v55);\n\treturn;\nL_0067:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void OnApplePurchaseDeferred(Product product)
		{
			ProductDefinition definition = product.definition;
			string message = "Purchase deferred: " + definition.id;
			Debug.Log(message);
			if (InAppPurchasing.PurchaseDeferred != null)
			{
				ProductDefinition definition2 = product.definition;
				IAPProduct iAPProductById = GetIAPProductById(definition2.id);
				InAppPurchasing.PurchaseDeferred(iAPProductById);
			}
		}

		[Token(Token = "0x60004DD")]
		[Address(RVA = "0xBF9FD4", Offset = "0xBF9FD4", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1F02F38]);\n\tv21 = *([v20 @ X8_v24]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022F15]) = v40;\nL_0016:\n\tv42 = product.<definition>k__BackingField;\n\tv70 = System.String::Concat(\"Attempted promotional purchase: \", v42.<id>k__BackingField);\n\tgoto L_002F;\n\tv105 = *([v74 @ X8_v9+E0]);\n\tv106 = v105 == 0;\n\tv107 = ~v106;\n\tif (v107) goto L_002F;\n\tv112 = v74;\n\tv109 = \"il2cpp_codegen_runtime_class_init\"(v112, v66, v50, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002F:\n\tUnityEngine.Debug::Log(v70);\n\tgoto L_003F;\n\tv118 = *([v114 @ X0_v9 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv119 = v118 == 0;\n\tv120 = ~v119;\n\tif (v120) goto L_003F;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v114, v53, v50, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv121 = EasyMobile.InAppPurchasing;\nL_003F:\n\tv92 = v98.PromotionalPurchaseIntercepted == 0;\n\tif (v92) goto L_0067;\n\tgoto L_004D;\n\tv129 = *([v90 @ X0_v10 (Il2CppClass<EasyMobile.InAppPurchasing>)+E0]);\n\tv130 = v129 == 0;\n\tv131 = ~v130;\n\tif (v131) goto L_004D;\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v90, v53, v50, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv138 = EasyMobile.InAppPurchasing;\n\tv135 = *([v138 @ X8_v19+B8]);\n\tv136 = *([v135 @ X8_v20+30]);\nL_004D:\n\tv61 = product.<definition>k__BackingField;\n\tv55 = EasyMobile.InAppPurchasing::GetIAPProductById(v61.<id>k__BackingField);\n\tSystem.Action`1<EasyMobile.IAPProduct>::Invoke(v98.PromotionalPurchaseIntercepted, v55);\n\treturn;\nL_0067:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void OnApplePromotionalPurchase(Product product)
		{
			ProductDefinition definition = product.definition;
			string message = "Attempted promotional purchase: " + definition.id;
			Debug.Log(message);
			if (InAppPurchasing.PromotionalPurchaseIntercepted != null)
			{
				ProductDefinition definition2 = product.definition;
				IAPProduct iAPProductById = GetIAPProductById(definition2.id);
				InAppPurchasing.PromotionalPurchaseIntercepted(iAPProductById);
			}
		}

		[Token(Token = "0x60004DE")]
		[Address(RVA = "0xBF7998", Offset = "0xBF7998", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv16 = *([1EE75F0]);\n\tv17 = *([v16 @ X8_v12]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2022F16]) = v37;\nL_0013:\n\tv39 = UnityEngine.Application::get_platform();\n\tv49 = v39 != 0xB;\n\tif (v49) goto L_0056;\n\tv51 = EasyMobile.EM_Settings::get_InAppPurchasing();\n\tv66 = EasyMobile.EM_Settings::get_InAppPurchasing();\n\tgoto L_003A;\n\tv175 = *([v120 @ X0_v22+E0]);\n\tv176 = v175 == 0;\n\tv177 = ~v176;\n\tif (v177) goto L_003A;\n\tv179 = \"il2cpp_codegen_runtime_class_init\"(v120, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_003A:\n\tv186 = v51.mValidateGooglePlayReceipt == 0;\n\tv191 = ~v186;\n\tv193 = v66.mTargetAndroidStore < 6;\n\tv194 = ~v193;\n\tv202 = ~v194;\n\tv204 = v66.mTargetAndroidStore & 0x3F;\n\tv206 = v204 == 0;\n\tv210 = v202 & v206;\n\treturnVal2 = v191 & v210;\n\tgoto L_008F;\nL_0056:\n\tv53 = UnityEngine.Application::get_platform();\n\tv59 = v53 == 8;\n\tif (v59) goto L_007B;\n\tv95 = UnityEngine.Application::get_platform();\n\tv106 = v95 == 1;\n\tif (v106) goto L_007B;\n\tv114 = UnityEngine.Application::get_platform();\n\tv96 = v114 != 0x1F;\n\tif (v96) goto L_FFFFFFFF;\nL_007B:\n\tv86 = EasyMobile.EM_Settings::get_InAppPurchasing();\n\tv168 = v86.mValidateAppleReceipt == 0;\n\tv173 = ~v168;\nL_008F:\n\treturn returnVal2;\n\tgoto L_008F;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 105 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool IsReceiptValidationEnabled()
		{
			RuntimePlatform platform = Application.platform;
			if (platform == RuntimePlatform.Android)
			{
				IAPSettings inAppPurchasing = EM_Settings.InAppPurchasing;
				IAPSettings inAppPurchasing2 = EM_Settings.InAppPurchasing;
				bool flag = !inAppPurchasing.ValidateGooglePlayReceipt;
				bool flag2 = !flag;
				bool flag3 = inAppPurchasing2.TargetAndroidStore < (IAPAndroidStore)6;
				bool flag4 = !flag3;
				bool flag5 = !flag4;
				int num = (int)(inAppPurchasing2.TargetAndroidStore & (IAPAndroidStore)63);
				bool flag6 = num == 0;
				bool flag7 = flag5 && flag6;
				return flag2 && flag7;
			}
			RuntimePlatform platform2 = Application.platform;
			if (platform2 != RuntimePlatform.IPhonePlayer)
			{
				RuntimePlatform platform3 = Application.platform;
				if (platform3 != RuntimePlatform.OSXPlayer)
				{
					RuntimePlatform platform4 = Application.platform;
					if (platform4 != RuntimePlatform.tvOS)
					{
						return false;
					}
				}
			}
			IAPSettings inAppPurchasing3 = EM_Settings.InAppPurchasing;
			bool flag8 = !inAppPurchasing3.ValidateAppleReceipt;
			return !flag8;
		}

		[Token(Token = "0x60004DF")]
		[Address(RVA = "0xBF7AA0", Offset = "0xBF7AA0", Length = "0x3F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv32 = *([1EC82A0]);\n\tv33 = *([v32 @ X8_v54]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, purchaseReceipts, logReceiptContent, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2022F17]) = v50;\nL_001E:\n\t// 30 NewArr receipt @ X0 (UnityEngine.Purchasing.Security.IPurchaseReceipt[]), typeof(UnityEngine.Purchasing.Security.IPurchaseReceipt[]), 0\n\t*([purchaseReceipts @ X1 (UnityEngine.Purchasing.Security.IPurchaseReceipt[]&)]) = receipt;\n\tv58 = System.String::IsNullOrEmpty(receipt);\n\tv60 = v58 == 0;\n\tif (v60) goto L_003E;\n\tgoto L_0036;\n\tv73 = *([v63 @ X0_v71+E0]);\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_0036;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v63, v57, logReceiptContent, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0036:\n\tUnityEngine.Debug::Log(\"Receipt Validation: receipt is null or empty.\");\n\tgoto L_FFFFFFFF;\nL_003E:\n\tgoto L_0045;\n\tv84 = *([v69 @ X0_v9+E0]);\n\tv85 = v84 == 0;\n\tv86 = ~v85;\n\tif (v86) goto L_0045;\n\tv88 = \"il2cpp_codegen_runtime_class_init\"(v69, v57, logReceiptContent, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0045:\n\tv92 = UnityEngine.Purchasing.Security.GooglePlayTangle::Data();\n\treceipt = UnityEngine.Application::get_identifier();\n\tv181 = new UnityEngine.Purchasing.Security.CrossPlatformValidator();\n\tUnityEngine.Purchasing.Security.CrossPlatformValidator::.ctor(v181, v92, 0, receipt);\n\tv300 = v181 == 0;\n\tif (v300) goto L_0148;\n\tv160 = UnityEngine.Purchasing.Security.CrossPlatformValidator::Validate(v181, receipt);\n\tv163 = v160 == 0;\n\tif (v163) goto L_FFFFFFFF;\n\t*([purchaseReceipts @ X1 (UnityEngine.Purchasing.Security.IPurchaseReceipt[]&)]) = v160;\n\tv343 = logReceiptContent == 0;\n\tif (v343) goto L_FFFFFFFF;\n\tgoto L_0072;\n\tv375 = *([v347 @ X0_v37+E0]);\n\tv376 = v375 == 0;\n\tv377 = ~v376;\n\tif (v377) goto L_0072;\n\tv379 = \"il2cpp_codegen_runtime_class_init\"(v347, v157, v149, v146, v144, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0072:\n\tUnityEngine.Debug::Log(\"Receipt contents:\");\n\tv246 = v160.Length;\n\tv351 = v160.Length < 1;\n\tif (v351) goto L_FFFFFFFF;\nL_0085:\n\tv405 = v328 < v246;\n\tv326 = ~v405;\n\tif (v326) goto L_0143;\n\tv244 = v160[v328 @ X23_v7 (System.Int32)];\n\tv410 = v160[v328 @ X23_v7 (System.Int32)] == 0;\n\tif (v410) goto L_0132;\n\tv412 = *([v244 @ X20_v7 (UnityEngine.Purchasing.Security.IPurchaseReceipt)]);\n\tv415 = *([v412 @ X8_v26 (Il2CppClass<UnityEngine.Purchasing.Security.IPurchaseReceipt>)+126]) == 0;\n\tif (v415) goto L_00B6;\n\tv481 = *([v412 @ X8_v26 (Il2CppClass<UnityEngine.Purchasing.Security.IPurchaseReceipt>)+B0]) + 8;\nL_00A1:\n\tv495 = *([v481 @ X11_v22-8]) == UnityEngine.Purchasing.Security.IPurchaseReceipt;\n\tif (v495) goto L_00B9;\n\tv480 = v480 + 1;\n\tv500 = v480 < *([v412 @ X8_v26 (Il2CppClass<UnityEngine.Purchasing.Security.IPurchaseReceipt>)+126]);\n\tv475 = ~v500;\n\tv481 = v481 + 0x10;\n\tv459 = ~v475;\n\tif (v459) goto L_00A1;\nL_00B6:\n\treceipt = 0x8909C4(v160[v328 @ X23_v7 (System.Int32)], UnityEngine.Purchasing.Security.IPurchaseReceipt, 1, receipt, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_00C0;\nL_00B9:\n\tv502 = *([v481 @ X11_v22]) + 1;\n\tv503 = v502 << 4;\n\tv504 = v412 + v503;\n\treceipt = v504 + 0x130;\nL_00C0:\n\t*([receipt @ X0 (UnityEngine.Purchasing.Security.IPurchaseReceipt[])])(v526, v160[v328 @ X23_v7 (System.Int32)], *([receipt @ X0 (UnityEngine.Purchasing.Security.IPurchaseReceipt[])+8]), v615, receipt, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_00CE;\n\tv531 = *([v527 @ X0_v48+E0]);\n\tv532 = v531 == 0;\n\tv533 = ~v532;\n\tgoto L_00CE;\n\tv535 = \"il2cpp_codegen_runtime_class_init\"(v527, v524, v520, v146, v144, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_00CE:\n\tUnityEngine.Debug::Log(v526);\n\tv540 = *([v244 @ X20_v7 (UnityEngine.Purchasing.Security.IPurchaseReceipt)]);\n\tv543 = *([v540 @ X8_v31 (Il2CppClass<UnityEngine.Purchasing.Security.IPurchaseReceipt>)+126]) == 0;\n\tif (v543) goto L_00F1;\n\tv576 = *([v540 @ X8_v31 (Il2CppClass<UnityEngine.Purchasing.Security.IPurchaseReceipt>)+B0]) + 8;\nL_00DC:\n\tv590 = *([v576 @ X11_v17-8]) == UnityEngine.Purchasing.Security.IPurchaseReceipt;\n\tif (v590) goto L_00F4;\n\tv575 = v575 + 1;\n\tv595 = v575 < *([v540 @ X8_v31 (Il2CppClass<UnityEngine.Purchasing.Security.IPurchaseReceipt>)+126]);\n\tv570 = ~v595;\n\tv576 = v576 + 0x10;\n\tv554 = ~v570;\n\tif (v554) goto L_00DC;\nL_00F1:\n\treceipt = 0x8909C4(v160[v328 @ X23_v7 (System.Int32)], UnityEngine.Purchasing.Security.IPurchaseReceipt, 2, receipt, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_00FB;\nL_00F4:\n\tv597 = *([v576 @ X11_v17]) + 2;\n\tv598 = v597 << 4;\n\tv599 = v540 + v598;\n\treceipt = v599 + 0x130;\nL_00FB:\n\t*([receipt @ X0 (UnityEngine.Purchasing.Security.IPurchaseReceipt[])])(receipt, v160[v328 @ X23_v7 (System.Int32)], *([receipt @ X0 (UnityEngine.Purchasing.Security.IPurchaseReceipt[])+8]), v615, receipt, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t// 256 Box v625 @ X0_v55 (System.Object), typeof(System.DateTime), &receipt @ X0 (UnityEngine.Purchasing.Security.IPurchaseReceipt[])\n\tUnityEngine.Debug::Log(v625);\n\tgoto L_012E;\n\tv630 = *([v627 @ X8_v35+B0]);\n\tv631 = 0;\n\tv632 = v630 + 8;\n\tv634 = *([v662 @ X11_v12-8]);\n\tv676 = v634 == v628;\n\tif (v676) goto L_0127;\n\tv636 = v661 + 1;\n\tv681 = v636 < v629;\n\tv656 = ~v681;\n\tv638 = v662 + 0x10;\n\tv640 = ~v656;\n\tif (v640) goto L_FFFFFFFF;\n\tv657 = v244;\n\tv658 = 0;\n\tv659 = 0x8909C4(v657, v628, v658, v146, v144, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_012E;\nL_0127:\n\tv682 = *([v662 @ X11_v12]);\n\tv683 = v682 << 4;\n\tv684 = v627 + v683;\n\tv685 = v684 + 0x130;\nL_012E:\n\treceipt = UnityEngine.Purchasing.Security.IPurchaseReceipt::get_transactionID(v160[v328 @ X23_v7 (System.Int32)]);\n\tUnityEngine.Debug::Log(receipt);\n\tv246 = v160.Length;\nL_0132:\n\tv328 = v328 + 1;\n\tv197 = v328 < v246;\n\tif (v197) goto L_0085;\n\tgoto L_0176;\n\tgoto L_0176;\nL_0143:\n\tv411 = new System.IndexOutOfRangeException();\n\tthrow v411;\nL_0148:\n\tv341 = new System.NullReferenceException();\n\tgoto L_015C;\n\tgoto L_015C;\n\tgoto L_015C;\n\tgoto L_015C;\n\tgoto L_015C;\n\tgoto L_015C;\n\tgoto L_015C;\n\tgoto L_015C;\n\tgoto L_015C;\nL_015C:\n\tv117 = v92 != 1;\n\tif (v117) goto L_0182;\n\treceipt = 0x6D2BC0(v341, v92, 0, receipt, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv172 = *([receipt @ X0 (UnityEngine.Purchasing.Security.IPurchaseReceipt[])]);\n\treceipt = \"il2cpp_vm_class_is_assignable_from\"(UnityEngine.Purchasing.Security.IAPSecurityException, *([v172 @ X8_v16]), 0, receipt, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv388 = receipt & 1;\n\tv162 = v388 == 0;\n\tif (v162) goto L_0178;\n\treceipt = 0x6D2490(receipt, *([v172 @ X8_v16]), v283, receipt, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0176:\n\treturn returnVal1;\nL_0178:\n\treceipt = 0x6D1E60(8, *([v172 @ X8_v16]), 0, receipt, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([receipt @ X0 (UnityEngine.Purchasing.Security.IPurchaseReceipt[])]) = *([receipt @ X0 (UnityEngine.Purchasing.Security.IPurchaseReceipt[])]);\n\tv287 = 0x1E8A000 + 0x870;\n\tv407 = 0x6D2A00(receipt, v287, 0, receipt, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treceipt = 0x6D2490(v407, v287, 0, receipt, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0182:\n\treceipt = 0x6D2380(v293, v287, v283, receipt, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturnVal2 = 0x846AA4(receipt, v287, v283, receipt, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn returnVal2;\n// 230 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static bool ValidateReceipt(string receipt, out IPurchaseReceipt[] purchaseReceipts, bool logReceiptContent = false)
		{
			//IL_0456: Expected O, but got I4
			//IL_0162: Expected I, but got O
			//IL_019d: Expected O, but got I
			//IL_026a: Expected I, but got O
			//IL_0223: Unknown result type (might be due to invalid IL or missing references)
			//IL_0228: Expected O, but got Unknown
			//IL_0245: Expected O, but got I
			//IL_0254: Expected O, but got I
			//IL_02a5: Expected O, but got I
			//IL_01e9: Expected O, but got I
			//IL_032b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0330: Expected O, but got Unknown
			//IL_034d: Expected O, but got I
			//IL_035c: Expected O, but got I
			//IL_02f1: Expected O, but got I
			purchaseReceipts = null;
			IPurchaseReceipt[] array = new IPurchaseReceipt[0];
			ref IPurchaseReceipt[] reference = ref *(IPurchaseReceipt[]*)receipt;
			if (string.IsNullOrEmpty(receipt))
			{
				Debug.Log("Receipt Validation: receipt is null or empty.");
			}
			else
			{
				byte[] array2 = GooglePlayTangle.Data();
				array = (IPurchaseReceipt[])(object)Application.identifier;
				CrossPlatformValidator crossPlatformValidator = new CrossPlatformValidator(array2, null, receipt);
				bool flag = crossPlatformValidator == null;
				byte[] array3 = null;
				byte[] array4 = array2;
				if (flag)
				{
					NullReferenceException ex = new NullReferenceException();
					bool flag2 = (IntPtr)array2 != (IntPtr)1;
					NullReferenceException ex2 = ex;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
						if ((uint)((ulong)(long)(IntPtr)receipt & 1uL) != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
							goto IL_0427;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
						array = (IPurchaseReceipt[])(object)receipt;
						array4 = (byte[])(32022528 + 2160);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2A00 (native __cxa_throw)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
						array3 = null;
						NullReferenceException ex3 = default(NullReferenceException);
						ex2 = ex3;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
					bool result = default(bool);
					return result;
				}
				IPurchaseReceipt[] array5 = crossPlatformValidator.Validate(receipt);
				if (array5 != null)
				{
					reference = ref *(IPurchaseReceipt[]*)array5;
					if (logReceiptContent)
					{
						Debug.Log("Receipt contents:");
						int num = array5.Length;
						if (array5.Length >= 1)
						{
							int num2 = 0;
							int num3 = 0;
							object message = default(object);
							while (num3 < num)
							{
								IPurchaseReceipt purchaseReceipt = array5[num3];
								if (array5[num3] == null)
								{
									goto IL_04df;
								}
								IntPtr intPtr = (IntPtr)purchaseReceipt;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ X8_v26 (Il2CppClass<UnityEngine.Purchasing.Security.IPurchaseReceipt>)+126]");
								if ((IntPtr)0 == (IntPtr)0)
								{
									goto IL_0202;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ X8_v26 (Il2CppClass<UnityEngine.Purchasing.Security.IPurchaseReceipt>)+B0]");
								object obj = 0L + 8L;
								int num4 = 0;
								while (true)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ X11_v22-8]");
									if ((IntPtr)0 == (IntPtr)typeof(IPurchaseReceipt))
									{
										break;
									}
									num4++;
									int num5 = num4;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ X8_v26 (Il2CppClass<UnityEngine.Purchasing.Security.IPurchaseReceipt>)+126]");
									bool flag3 = (long)num5 < 0L;
									bool flag4 = !flag3;
									obj = (long)(IntPtr)obj + 16L;
									if (!flag4)
									{
										continue;
									}
									goto IL_0202;
								}
								object obj2 = obj + 1;
								int num6 = (int)((long)(IntPtr)obj2 << 4);
								object obj3 = (long)intPtr + (long)num6;
								array = (IPurchaseReceipt[])((long)(IntPtr)obj3 + 304L);
								goto IL_0533;
								IL_0202:
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
								num2 = 1;
								goto IL_0533;
								IL_0533:
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [receipt @ X0 (UnityEngine.Purchasing.Security.IPurchaseReceipt[])] (should have been resolved before IL gen)");
								Debug.Log(message);
								IntPtr intPtr2 = (IntPtr)purchaseReceipt;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ X8_v31 (Il2CppClass<UnityEngine.Purchasing.Security.IPurchaseReceipt>)+126]");
								if ((IntPtr)0 == (IntPtr)0)
								{
									goto IL_030a;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ X8_v31 (Il2CppClass<UnityEngine.Purchasing.Security.IPurchaseReceipt>)+B0]");
								object obj4 = 0L + 8L;
								int num7 = 0;
								while (true)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v576 @ X11_v17-8]");
									if ((IntPtr)0 == (IntPtr)typeof(IPurchaseReceipt))
									{
										break;
									}
									num7++;
									int num8 = num7;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ X8_v31 (Il2CppClass<UnityEngine.Purchasing.Security.IPurchaseReceipt>)+126]");
									bool flag5 = (long)num8 < 0L;
									bool flag6 = !flag5;
									obj4 = (long)(IntPtr)obj4 + 16L;
									if (!flag6)
									{
										continue;
									}
									goto IL_030a;
								}
								object obj5 = obj4 + 2;
								int num9 = (int)((long)(IntPtr)obj5 << 4);
								object obj6 = (long)intPtr2 + (long)num9;
								array = (IPurchaseReceipt[])((long)(IntPtr)obj6 + 304L);
								goto IL_056c;
								IL_030a:
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
								num2 = 2;
								goto IL_056c;
								IL_056c:
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [receipt @ X0 (UnityEngine.Purchasing.Security.IPurchaseReceipt[])] (should have been resolved before IL gen)");
								object message2 = (DateTime)receipt;
								Debug.Log(message2);
								array = (IPurchaseReceipt[])(object)array5[num3].transactionID;
								Debug.Log(receipt);
								num = array5.Length;
								num2 = 0;
								goto IL_04df;
								IL_04df:
								num3++;
								if (num3 >= num)
								{
									return true;
								}
							}
							IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
							array3 = null;
							array4 = null;
							throw ex4;
						}
					}
					return true;
				}
			}
			goto IL_0427;
			IL_0427:
			return false;
		}

		[Token(Token = "0x60004E0")]
		[Address(RVA = "0xBF984C", Offset = "0xBF984C", Length = "0x40C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv28 = *([1F04560]);\n\tv29 = *([v28 @ X8_v77]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2022F18]) = v48;\nL_001A:\n\tv51 = UnityEngine.Purchasing.MiniJson::JsonDecode(receipt);\n\tgoto L_FFFFFFFF;\n\tv163 = v163_asT == 0;\n\tif (v163) goto L_01AD;\n\tv300 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(v51, \"Store\");\n\tv353 = v300 == 0;\n\tif (v353) goto L_0151;\n\tv358 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(v51, \"Payload\");\n\tv364 = v358 == 0;\n\tif (v364) goto L_0151;\n\tv285 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v51, \"Store\");\n\tv287 = v285 == 0;\n\tif (v287) goto L_006D;\n\tv262 = *([v285 @ X0_v27 (System.String)]) != System.String;\n\tif (v262) goto L_01B0;\nL_006D:\n\tv235 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v51, \"Payload\");\n\tv238 = v235 == 0;\n\tif (v238) goto L_0167;\n\tv92 = *([v235 @ X0_v29 (System.String)]) != System.String;\n\tif (v92) goto L_01AD;\n\tv558 = System.String::op_Equality(v285, \"GooglePlay\");\n\tv560 = v558 == 0;\n\tif (v560) goto L_016D;\n\tv137 = UnityEngine.Purchasing.MiniJson::JsonDecode(v235);\n\tgoto L_FFFFFFFF;\n\tv171 = v171_asT == 0;\n\tif (v171) goto L_01AD;\n\tv590 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(v137, \"json\");\n\tv594 = v590 == 0;\n\tif (v594) goto L_0183;\n\tv341 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v137, \"json\");\n\tv344 = v341 == 0;\n\tif (v344) goto L_00C8;\n\tv308 = *([v341 @ X0_v48 (System.String)]) != System.String;\n\tif (v308) goto L_01B1;\nL_00C8:\n\tv236 = UnityEngine.Purchasing.MiniJson::JsonDecode(v341);\n\tv239 = v236 == 0;\n\tif (v239) goto L_0192;\n\tgoto L_FFFFFFFF;\n\tv173 = v173_asT == 0;\n\tif (v173) goto L_01AD;\n\tv626 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(v236, \"developerPayload\");\n\tv628 = v626 == 0;\n\tif (v628) goto L_0192;\n\tv342 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v236, \"developerPayload\");\n\tv345 = v342 == 0;\n\tif (v345) goto L_0107;\n\tv309 = *([v342 @ X0_v57 (System.String)]) != System.String;\n\tif (v309) goto L_01B1;\nL_0107:\n\tv237 = UnityEngine.Purchasing.MiniJson::JsonDecode(v342);\n\tv240 = v237 == 0;\n\tif (v240) goto L_0142;\n\tgoto L_FFFFFFFF;\n\tv175 = v175_asT == 0;\n\tif (v175) goto L_01AD;\n\tv667 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(v237, \"is_free_trial\");\n\tv669 = v667 == 0;\n\tif (v669) goto L_0142;\n\tv581 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(v237, \"has_introductory_price_trial\");\n\tv693 = v581 == 0;\n\tv582 = ~v693;\n\tif (v582) goto L_FFFFFFFF;\nL_0142:\n\tgoto L_FFFFFFFF;\n\tv681 = *([v674 @ X0_v60+E0]);\n\tv682 = v681 == 0;\n\tv683 = ~v682;\n\tif (v683) goto L_FFFFFFFF;\n\tv684 = \"il2cpp_codegen_runtime_class_init\"(v674, v494, v454, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_015B;\nL_0151:\n\tgoto L_FFFFFFFF;\n\tv438 = *([v367 @ X0_v21+E0]);\n\tv439 = v438 == 0;\n\tv440 = ~v439;\n\tif (v440) goto L_FFFFFFFF;\n\tv442 = \"il2cpp_codegen_runtime_class_init\"(v367, v361, v360, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_015B:\n\tUnityEngine.Debug::Log(*([v506 @ X8_v11 (System.String)]));\nL_0167:\n\treturn returnVal2;\nL_016D:\n\tv567 = System.String::op_Equality(v285, \"AppleAppStore\");\n\tv569 = v567 == 0;\n\tv570 = ~v569;\n\tif (v570) goto L_FFFFFFFF;\n\tv577 = System.String::op_Equality(v285, \"AmazonApps\");\n\tv424 = v577 == 0;\n\tif (v424) goto L_01AA;\n\tgoto L_0167;\nL_0183:\n\tgoto L_FFFFFFFF;\n\tv603 = *([v599 @ X0_v44+E0]);\n\tv604 = v603 == 0;\n\tv605 = ~v604;\n\tif (v605) goto L_FFFFFFFF;\n\tv606 = \"il2cpp_codegen_runtime_class_init\"(v599, v495, v455, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_015B;\nL_0192:\n\tgoto L_FFFFFFFF;\n\tv639 = *([v632 @ X0_v51+E0]);\n\tv640 = v639 == 0;\n\tv641 = ~v640;\n\tif (v641) goto L_FFFFFFFF;\n\tv642 = \"il2cpp_codegen_runtime_class_init\"(v632, v496, v456, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_015B;\nL_01AA:\n\treturnVal3 = System.String::op_Equality(v285, \"MacAppStore\");\n\treturn returnVal3;\nL_01AD:\n\tv136 = new System.InvalidCastException();\n\tthrow System.NullReferenceException;\nL_01B0:\n\tv293 = new System.InvalidCastException();\nL_01B1:\n\treturnVal1 = new System.InvalidCastException();\n\treturn returnVal1;\n// 323 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool IsProductAvailableForSubscriptionManager(string receipt)
		{
			//IL_0114: Expected I4, but got O
			//IL_04f1: Expected I4, but got O
			object obj = MiniJson.JsonDecode(receipt);
			Dictionary<string, object> dictionary = obj as Dictionary<string, object>;
			string message;
			bool result;
			if (dictionary != null)
			{
				if (!((Dictionary<string, object>)obj).ContainsKey("Store") || !((Dictionary<string, object>)obj).ContainsKey("Payload"))
				{
					message = "The product receipt does not contain enough information, the 'Store' or 'Payload' field is missing.";
					goto IL_0508;
				}
				string text = (string)((Dictionary<string, object>)obj).get_Item("Store");
				if (text != null && (object)text.GetType() != typeof(string))
				{
					InvalidCastException ex = new InvalidCastException();
					goto IL_04e3;
				}
				string text2 = (string)((Dictionary<string, object>)obj).get_Item("Payload");
				bool flag = text2 == null;
				result = (byte)(int)text2 != 0;
				if (flag)
				{
					goto IL_0503;
				}
				if ((object)text2.GetType() == typeof(string))
				{
					switch (text)
					{
					case "GooglePlay":
						break;
					case "AppleAppStore":
					case "AmazonApps":
						goto IL_0476;
					default:
						return text == "MacAppStore";
					}
					object obj2 = MiniJson.JsonDecode(text2);
					Dictionary<string, object> dictionary2 = obj2 as Dictionary<string, object>;
					if (dictionary2 != null)
					{
						if (((Dictionary<string, object>)obj2).ContainsKey("json"))
						{
							string text3 = (string)((Dictionary<string, object>)obj2).get_Item("json");
							if (text3 != null && (object)text3.GetType() != typeof(string))
							{
								goto IL_04e3;
							}
							object obj3 = MiniJson.JsonDecode(text3);
							if (obj3 != null)
							{
								Dictionary<string, object> dictionary3 = obj3 as Dictionary<string, object>;
								if (dictionary3 == null)
								{
									goto IL_04c1;
								}
								if (((Dictionary<string, object>)obj3).ContainsKey("developerPayload"))
								{
									string text4 = (string)((Dictionary<string, object>)obj3).get_Item("developerPayload");
									if (text4 != null && (object)text4.GetType() != typeof(string))
									{
										goto IL_04e3;
									}
									object obj4 = MiniJson.JsonDecode(text4);
									if (obj4 != null)
									{
										Dictionary<string, object> dictionary4 = obj4 as Dictionary<string, object>;
										if (dictionary4 == null)
										{
											goto IL_04c1;
										}
										if (((Dictionary<string, object>)obj4).ContainsKey("is_free_trial") && ((Dictionary<string, object>)obj4).ContainsKey("has_introductory_price_trial"))
										{
											goto IL_0476;
										}
									}
									message = "The product receipt does not contain enough information, the product is not purchased using 1.19 or later.";
									goto IL_0508;
								}
							}
							message = "The product receipt does not contain enough information, the 'developerPayload' field is missing.";
						}
						else
						{
							message = "The product receipt does not contain enough information, the 'json' field is missing.";
						}
						goto IL_0508;
					}
				}
			}
			goto IL_04c1;
			IL_04e3:
			InvalidCastException ex2 = new InvalidCastException();
			return (byte)(int)ex2 != 0;
			IL_0508:
			Debug.Log(message);
			result = false;
			goto IL_0503;
			IL_04c1:
			InvalidCastException ex3 = new InvalidCastException();
			throw new NullReferenceException();
			IL_0503:
			return result;
			IL_0476:
			result = true;
			goto IL_0503;
		}

		[Token(Token = "0x60004E1")]
		[Address(RVA = "0xBFA104", Offset = "0xBFA104", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public InAppPurchasing()
		{
		}

		[Token(Token = "0x60004E2")]
		[Address(RVA = "0xBFA10C", Offset = "0xBFA10C", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EBDEE0]);\n\tv15 = *([v14 @ X8_v10]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022F19]) = v35;\nL_0014:\n\tv39 = new EasyMobile.InAppPurchasing+StoreListener();\n\tSystem.Object::.ctor(v39);\n\tv45.sStoreListener = v39;\n\tv46.sIsInitializing = 0;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static InAppPurchasing()
		{
			StoreListener storeListener = new StoreListener();
			sStoreListener = storeListener;
			sIsInitializing = false;
		}
	}
}
