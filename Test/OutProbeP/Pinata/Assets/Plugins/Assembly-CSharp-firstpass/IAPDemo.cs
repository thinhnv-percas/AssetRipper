using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
using UnityEngine.UI;

[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x7DCCA4", Offset = "0x7DCCA4")]
[Token(Token = "0x2000002")]
public class IAPDemo : MonoBehaviour, IStoreListener
{
	[Token(Token = "0x4000001")]
	[FieldOffset(Offset = "0x18")]
	private IStoreController m_Controller;

	[Token(Token = "0x4000002")]
	[FieldOffset(Offset = "0x20")]
	private IAppleExtensions m_AppleExtensions;

	[Token(Token = "0x4000003")]
	[FieldOffset(Offset = "0x28")]
	private IMoolahExtension m_MoolahExtensions;

	[Token(Token = "0x4000004")]
	[FieldOffset(Offset = "0x30")]
	private ISamsungAppsExtensions m_SamsungExtensions;

	[Token(Token = "0x4000005")]
	[FieldOffset(Offset = "0x38")]
	private IMicrosoftExtensions m_MicrosoftExtensions;

	[Token(Token = "0x4000006")]
	[FieldOffset(Offset = "0x40")]
	private ITransactionHistoryExtensions m_TransactionHistoryExtensions;

	[Token(Token = "0x4000007")]
	[FieldOffset(Offset = "0x48")]
	private IGooglePlayStoreExtensions m_GooglePlayStoreExtensions;

	[Token(Token = "0x4000008")]
	[FieldOffset(Offset = "0x50")]
	private bool m_IsGooglePlayStoreSelected;

	[Token(Token = "0x4000009")]
	[FieldOffset(Offset = "0x51")]
	private bool m_IsSamsungAppsStoreSelected;

	[Token(Token = "0x400000A")]
	[FieldOffset(Offset = "0x52")]
	private bool m_IsCloudMoolahStoreSelected;

	[Token(Token = "0x400000B")]
	[FieldOffset(Offset = "0x53")]
	private bool m_PurchaseInProgress;

	[Token(Token = "0x400000C")]
	[FieldOffset(Offset = "0x58")]
	private Dictionary<string, IAPDemoProductUI> m_ProductUIs;

	[Token(Token = "0x400000D")]
	[FieldOffset(Offset = "0x60")]
	public GameObject productUITemplate;

	[Token(Token = "0x400000E")]
	[FieldOffset(Offset = "0x68")]
	public RectTransform contentRect;

	[Token(Token = "0x400000F")]
	[FieldOffset(Offset = "0x70")]
	public Button restoreButton;

	[Token(Token = "0x4000010")]
	[FieldOffset(Offset = "0x78")]
	public Text versionText;

	[Token(Token = "0x6000001")]
	[Address(RVA = "0x16072A4", Offset = "0x16072A4", Length = "0x818")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv38 = *([1F0EED8]);\n\tv39 = *([v38 @ X8_v101]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, controller, extensions, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([202A1D8]) = v56;\nL_001F:\n\tthis.m_Controller = controller;\n\tv62 = extensions->klass;\n\tv63 = Il2CppMethodInfo;\n\tv64 = extensions->klass->interface_offsets_count;\n\tv67 = *([v62 @ X8_v7 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]) == 0;\n\tif (v67) goto L_0047;\n\tv382 = *([v62 @ X8_v7 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]) + 8;\nL_0033:\n\tv387 = *([v382 @ X11_v63-8]) == Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>;\n\tif (v387) goto L_0049;\n\tv381 = v381 + 1;\n\tv474 = v381 < v64;\n\tv306 = ~v474;\n\tv382 = v382 + 0x10;\n\tv290 = ~v306;\n\tif (v290) goto L_0033;\nL_0047:\n\tv494 = 0x8909C4(extensions, Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>, *([v63 @ X22_v6 (Il2CppMethodInfo)+48]), methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_0050;\nL_0049:\n\tv64 = *([v382 @ X11_v63]);\n\tv64 = v64 + *([v63 @ X22_v6 (Il2CppMethodInfo)+48]);\n\tv477 = v64 << 4;\n\tv478 = v62 + v477;\n\tv494 = v478 + 0x130;\nL_0050:\n\tv498 = 0x8D8294(*([v494 @ X0_v10+8]), Il2CppMethodInfo, *([v63 @ X22_v6 (Il2CppMethodInfo)+48]), methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv64 = *([v498 @ X0_v12]);\n\t*([v498 @ X0_v12])(v557, extensions, v498, *([v63 @ X22_v6 (Il2CppMethodInfo)+48]), methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tthis.m_AppleExtensions = v557;\n\tv560 = Il2CppMethodInfo;\n\tv561 = extensions->klass;\n\tv64 = extensions->klass->interface_offsets_count;\n\tv565 = *([v561 @ X8_v12 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]) == 0;\n\tif (v565) goto L_007C;\n\tv654 = *([v561 @ X8_v12 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]) + 8;\nL_0068:\n\tv659 = *([v654 @ X11_v58-8]) == Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>;\n\tif (v659) goto L_007E;\n\tv653 = v653 + 1;\n\tv664 = v653 < v64;\n\tv588 = ~v664;\n\tv654 = v654 + 0x10;\n\tv572 = ~v588;\n\tif (v572) goto L_0068;\nL_007C:\n\tv684 = 0x8909C4(extensions, Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>, *([v560 @ X22_v7 (Il2CppMethodInfo)+48]), methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_0085;\nL_007E:\n\tv64 = *([v654 @ X11_v58]);\n\tv64 = v64 + *([v560 @ X22_v7 (Il2CppMethodInfo)+48]);\n\tv667 = v64 << 4;\n\tv668 = v561 + v667;\n\tv684 = v668 + 0x130;\nL_0085:\n\tv688 = 0x8D8294(*([v684 @ X0_v15+8]), Il2CppMethodInfo, *([v560 @ X22_v7 (Il2CppMethodInfo)+48]), methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv64 = *([v688 @ X0_v17]);\n\t*([v688 @ X0_v17])(v693, extensions, v688, *([v560 @ X22_v7 (Il2CppMethodInfo)+48]), methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tthis.m_SamsungExtensions = v693;\n\tv696 = Il2CppMethodInfo;\n\tv697 = extensions->klass;\n\tv64 = extensions->klass->interface_offsets_count;\n\tv701 = *([v697 @ X8_v17 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]) == 0;\n\tif (v701) goto L_00B1;\n\tv742 = *([v697 @ X8_v17 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]) + 8;\nL_009D:\n\tv747 = *([v742 @ X11_v53-8]) == Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>;\n\tif (v747) goto L_00B3;\n\tv741 = v741 + 1;\n\tv752 = v741 < v64;\n\tv724 = ~v752;\n\tv742 = v742 + 0x10;\n\tv708 = ~v724;\n\tif (v708) goto L_009D;\nL_00B1:\n\tv772 = 0x8909C4(extensions, Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>, *([v696 @ X22_v8 (Il2CppMethodInfo)+48]), methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_00BA;\nL_00B3:\n\tv64 = *([v742 @ X11_v53]);\n\tv64 = v64 + *([v696 @ X22_v8 (Il2CppMethodInfo)+48]);\n\tv755 = v64 << 4;\n\tv756 = v697 + v755;\n\tv772 = v756 + 0x130;\nL_00BA:\n\tv776 = 0x8D8294(*([v772 @ X0_v20+8]), Il2CppMethodInfo, *([v696 @ X22_v8 (Il2CppMethodInfo)+48]), methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv64 = *([v776 @ X0_v22]);\n\t*([v776 @ X0_v22])(v781, extensions, v776, *([v696 @ X22_v8 (Il2CppMethodInfo)+48]), methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tthis.m_MoolahExtensions = v781;\n\tv784 = Il2CppMethodInfo;\n\tv785 = extensions->klass;\n\tv64 = extensions->klass->interface_offsets_count;\n\tv789 = *([v785 @ X8_v22 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]) == 0;\n\tif (v789) goto L_00E6;\n\tv830 = *([v785 @ X8_v22 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]) + 8;\nL_00D2:\n\tv835 = *([v830 @ X11_v48-8]) == Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>;\n\tif (v835) goto L_00E8;\n\tv829 = v829 + 1;\n\tv840 = v829 < v64;\n\tv812 = ~v840;\n\tv830 = v830 + 0x10;\n\tv796 = ~v812;\n\tif (v796) goto L_00D2;\nL_00E6:\n\tv860 = 0x8909C4(extensions, Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>, *([v784 @ X22_v9 (Il2CppMethodInfo)+48]), methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_00EF;\nL_00E8:\n\tv64 = *([v830 @ X11_v48]);\n\tv64 = v64 + *([v784 @ X22_v9 (Il2CppMethodInfo)+48]);\n\tv843 = v64 << 4;\n\tv844 = v785 + v843;\n\tv860 = v844 + 0x130;\nL_00EF:\n\tv864 = 0x8D8294(*([v860 @ X0_v25+8]), Il2CppMethodInfo, *([v784 @ X22_v9 (Il2CppMethodInfo)+48]), methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv64 = *([v864 @ X0_v27]);\n\t*([v864 @ X0_v27])(v869, extensions, v864, *([v784 @ X22_v9 (Il2CppMethodInfo)+48]), methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tthis.m_MicrosoftExtensions = v869;\n\tv872 = Il2CppMethodInfo;\n\tv873 = extensions->klass;\n\tv64 = extensions->klass->interface_offsets_count;\n\tv877 = *([v873 @ X8_v27 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]) == 0;\n\tif (v877) goto L_011B;\n\tv918 = *([v873 @ X8_v27 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]) + 8;\nL_0107:\n\tv923 = *([v918 @ X11_v43-8]) == Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>;\n\tif (v923) goto L_011D;\n\tv917 = v917 + 1;\n\tv928 = v917 < v64;\n\tv900 = ~v928;\n\tv918 = v918 + 0x10;\n\tv884 = ~v900;\n\tif (v884) goto L_0107;\nL_011B:\n\tv948 = 0x8909C4(extensions, Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>, *([v872 @ X22_v10 (Il2CppMethodInfo)+48]), methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_0124;\nL_011D:\n\tv64 = *([v918 @ X11_v43]);\n\tv64 = v64 + *([v872 @ X22_v10 (Il2CppMethodInfo)+48]);\n\tv931 = v64 << 4;\n\tv932 = v873 + v931;\n\tv948 = v932 + 0x130;\nL_0124:\n\tv952 = 0x8D8294(*([v948 @ X0_v30+8]), Il2CppMethodInfo, *([v872 @ X22_v10 (Il2CppMethodInfo)+48]), methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv64 = *([v952 @ X0_v32]);\n\t*([v952 @ X0_v32])(v957, extensions, v952, *([v872 @ X22_v10 (Il2CppMethodInfo)+48]), methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tthis.m_TransactionHistoryExtensions = v957;\n\tv280 = Il2CppMethodInfo;\n\tv960 = extensions->klass;\n\tv64 = extensions->klass->interface_offsets_count;\n\tv963 = *([v960 @ X8_v32 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]) == 0;\n\tif (v963) goto L_0150;\n\tv1004 = *([v960 @ X8_v32 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]) + 8;\nL_013C:\n\tv1009 = *([v1004 @ X11_v38-8]) == Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>;\n\tif (v1009) goto L_0152;\n\tv1003 = v1003 + 1;\n\tv1014 = v1003 < v64;\n\tv986 = ~v1014;\n\tv1004 = v1004 + 0x10;\n\tv970 = ~v986;\n\tif (v970) goto L_013C;\nL_0150:\n\tv1021 = 0x8909C4(extensions, Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>, *([v280 @ X22_v11 (Il2CppMethodInfo)+48]), methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_0159;\nL_0152:\n\tv64 = *([v1004 @ X11_v38]);\n\tv64 = v64 + *([v280 @ X22_v11 (Il2CppMethodInfo)+48]);\n\tv1017 = v64 << 4;\n\tv1018 = v960 + v1017;\n\tv1021 = v1018 + 0x130;\nL_0159:\n\tv1025 = 0x8D8294(*([v1021 @ X0_v35+8]), Il2CppMethodInfo, *([v280 @ X22_v11 (Il2CppMethodInfo)+48]), methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv64 = *([v1025 @ X0_v37]);\n\t*([v1025 @ X0_v37])(v234, extensions, v1025, *([v280 @ X22_v11 (Il\n// ... truncated")]
	public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
	{
		//IL_000d: Expected I, but got O
		//IL_0b57: Expected I4, but got O
		//IL_0b79: Expected I, but got O
		//IL_005e: Expected O, but got I
		//IL_0be7: Expected I4, but got O
		//IL_0c09: Expected I, but got O
		//IL_0132: Expected O, but got I
		//IL_00d7: Expected I4, but got O
		//IL_0108: Expected O, but got I
		//IL_0117: Expected O, but got I
		//IL_00a2: Expected O, but got I
		//IL_0c77: Expected I4, but got O
		//IL_0c99: Expected I, but got O
		//IL_0206: Expected O, but got I
		//IL_01ab: Expected I4, but got O
		//IL_01dc: Expected O, but got I
		//IL_01eb: Expected O, but got I
		//IL_0176: Expected O, but got I
		//IL_0d07: Expected I4, but got O
		//IL_0d29: Expected I, but got O
		//IL_02da: Expected O, but got I
		//IL_027f: Expected I4, but got O
		//IL_02b0: Expected O, but got I
		//IL_02bf: Expected O, but got I
		//IL_024a: Expected O, but got I
		//IL_0d97: Expected I4, but got O
		//IL_0db9: Expected I, but got O
		//IL_03ae: Expected O, but got I
		//IL_0353: Expected I4, but got O
		//IL_0384: Expected O, but got I
		//IL_0393: Expected O, but got I
		//IL_031e: Expected O, but got I
		//IL_0e27: Expected I4, but got O
		//IL_0482: Expected O, but got I
		//IL_0427: Expected I4, but got O
		//IL_0458: Expected O, but got I
		//IL_0467: Expected O, but got I
		//IL_03f2: Expected O, but got I
		//IL_04fb: Expected I4, but got O
		//IL_052c: Expected O, but got I
		//IL_053b: Expected O, but got I
		//IL_04c6: Expected O, but got I
		//IL_0579: Expected I, but got O
		//IL_05c4: Expected O, but got I
		//IL_062e: Expected I4, but got O
		//IL_0658: Expected O, but got I
		//IL_0667: Expected O, but got I
		//IL_0608: Expected O, but got I
		//IL_0765: Expected O, but got I4
		//IL_0ec6: Expected O, but got I
		//IL_07f0: Expected O, but got I4
		//IL_0f24: Expected O, but got I
		//IL_0861: Expected O, but got I4
		//IL_08d5: Expected O, but got I4
		//IL_0901: Expected O, but got I4
		//IL_0f82: Expected O, but got I
		//IL_099d: Expected O, but got I4
		//IL_0fe0: Expected O, but got I
		//IL_09fc: Expected O, but got I4
		//IL_103e: Expected O, but got I
		//IL_0a5b: Expected O, but got I4
		m_Controller = controller;
		IntPtr intPtr = (IntPtr)extensions;
		IntPtr intPtr2 = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X8_v7 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
		int num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X8_v7 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
		if ((IntPtr)0 == (IntPtr)0)
		{
			goto IL_00bb;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X8_v7 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]");
		object obj = 0L + 8L;
		int num2 = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ X11_v63-8]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				break;
			}
			num2++;
			bool flag = num2 < num;
			bool flag2 = !flag;
			obj = (long)(IntPtr)obj + 16L;
			if (!flag2)
			{
				continue;
			}
			goto IL_00bb;
		}
		num = (int)obj;
		int num3 = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ X22_v6 (Il2CppMethodInfo)+48]");
		num = (int)((long)num3 + 0L);
		int num4 = num << 4;
		object obj2 = (long)intPtr + (long)num4;
		object obj3 = (long)(IntPtr)obj2 + 304L;
		goto IL_0b40;
		IL_04df:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
		goto IL_0e10;
		IL_0337:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
		goto IL_0cf0;
		IL_0cf0:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8D8294");
		object obj4 = default(object);
		num = (int)obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v864 @ X0_v27] (should have been resolved before IL gen)");
		IMicrosoftExtensions microsoftExtensions = default(IMicrosoftExtensions);
		m_MicrosoftExtensions = microsoftExtensions;
		IntPtr intPtr3 = (IntPtr)0;
		IntPtr intPtr4 = (IntPtr)extensions;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v873 @ X8_v27 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
		num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v873 @ X8_v27 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
		if ((IntPtr)0 == (IntPtr)0)
		{
			goto IL_040b;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v873 @ X8_v27 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]");
		object obj5 = 0L + 8L;
		int num5 = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v918 @ X11_v43-8]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				break;
			}
			num5++;
			bool flag3 = num5 < num;
			bool flag4 = !flag3;
			obj5 = (long)(IntPtr)obj5 + 16L;
			if (!flag4)
			{
				continue;
			}
			goto IL_040b;
		}
		num = (int)obj5;
		int num6 = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v872 @ X22_v10 (Il2CppMethodInfo)+48]");
		num = (int)((long)num6 + 0L);
		int num7 = num << 4;
		object obj6 = (long)intPtr4 + (long)num7;
		object obj7 = (long)(IntPtr)obj6 + 304L;
		goto IL_0d80;
		IL_040b:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
		goto IL_0d80;
		IL_00bb:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
		goto IL_0b40;
		IL_0b40:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8D8294");
		object obj8 = default(object);
		num = (int)obj8;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v498 @ X0_v12] (should have been resolved before IL gen)");
		IAppleExtensions appleExtensions = default(IAppleExtensions);
		m_AppleExtensions = appleExtensions;
		IntPtr intPtr5 = (IntPtr)0;
		IntPtr intPtr6 = (IntPtr)extensions;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v561 @ X8_v12 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
		num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v561 @ X8_v12 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
		if ((IntPtr)0 == (IntPtr)0)
		{
			goto IL_018f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v561 @ X8_v12 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]");
		object obj9 = 0L + 8L;
		int num8 = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v654 @ X11_v58-8]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				break;
			}
			num8++;
			bool flag5 = num8 < num;
			bool flag6 = !flag5;
			obj9 = (long)(IntPtr)obj9 + 16L;
			if (!flag6)
			{
				continue;
			}
			goto IL_018f;
		}
		num = (int)obj9;
		int num9 = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v560 @ X22_v7 (Il2CppMethodInfo)+48]");
		num = (int)((long)num9 + 0L);
		int num10 = num << 4;
		object obj10 = (long)intPtr6 + (long)num10;
		object obj11 = (long)(IntPtr)obj10 + 304L;
		goto IL_0bd0;
		IL_0e10:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8D8294");
		object obj12 = default(object);
		num = (int)obj12;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1025 @ X0_v37] (should have been resolved before IL gen)");
		IGooglePlayStoreExtensions googlePlayStoreExtensions = default(IGooglePlayStoreExtensions);
		m_GooglePlayStoreExtensions = googlePlayStoreExtensions;
		ProductCollection products = controller.products;
		InitUI(null);
		Action<Product> appleExtensions2 = (Action<Product>)(object)m_AppleExtensions;
		Action<Product> action = OnDeferred;
		IntPtr intPtr7 = (IntPtr)appleExtensions2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1098 @ X8_v42 (Il2CppClass<System.Action`1<UnityEngine.Purchasing.Product>>)+126]");
		num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1098 @ X8_v42 (Il2CppClass<System.Action`1<UnityEngine.Purchasing.Product>>)+126]");
		if ((IntPtr)0 != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1098 @ X8_v42 (Il2CppClass<System.Action`1<UnityEngine.Purchasing.Product>>)+B0]");
			object obj13 = 0L + 8L;
			int num11 = 0;
			bool flag8;
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1144 @ X11_v28-8]");
				if ((IntPtr)0 != (IntPtr)typeof(IAppleExtensions))
				{
					num11++;
					bool flag7 = num11 < num;
					flag8 = !flag7;
					obj13 = (long)(IntPtr)obj13 + 16L;
					continue;
				}
				num = (int)obj13;
				num += 2;
				int num12 = num << 4;
				object obj14 = (long)intPtr7 + (long)num12;
				Action<Product> action2 = (Action<Product>)((long)(IntPtr)obj14 + 304L);
				break;
			}
			while (!flag8);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1175 @ X0_v46 (System.Action`1<UnityEngine.Purchasing.Product>)] (should have been resolved before IL gen)");
		Debug.Log("Available items:");
		ProductCollection products2 = controller.products;
		Product[] all = products2.all;
		int num13 = all.Length;
		if (all.Length >= 1)
		{
			int num14 = 0;
			IntPtr intPtr8 = default(IntPtr);
			Action<Product> action3 = default(Action<Product>);
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			do
			{
				if (num14 < num13)
				{
					Product product = all[num14];
					if (!product.availableToPurchase)
					{
						goto IL_0aa6;
					}
					string[] array = new string[7];
					ProductMetadata metadata = product.metadata;
					if (metadata.localizedTitle != null)
					{
						object obj15 = metadata.localizedTitle as string;
					}
					object obj16 = array.Length;
					if (array.Length != 0)
					{
						array[0] = metadata.localizedTitle;
						ProductMetadata metadata2 = product.metadata;
						if (metadata2.localizedDescription != null)
						{
							object obj17 = metadata2.localizedDescription as string;
							obj16 = array.Length;
						}
						bool flag9 = (long)(IntPtr)obj16 < 1L;
						bool flag10 = !flag9;
						object obj18 = (long)(IntPtr)obj16 - 1L;
						bool flag11 = obj18 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[1] = metadata2.localizedDescription;
							ProductMetadata metadata3 = product.metadata;
							if (metadata3.isoCurrencyCode != null)
							{
								object obj19 = metadata3.isoCurrencyCode as string;
								obj16 = array.Length;
							}
							bool flag13 = (long)(IntPtr)obj16 < 2L;
							bool flag14 = !flag13;
							object obj20 = (long)(IntPtr)obj16 - 2L;
							bool flag15 = obj20 == null;
							bool flag16 = !flag14;
							if (!(flag16 || flag15))
							{
								array[2] = metadata3.isoCurrencyCode;
								ProductMetadata metadata4 = product.metadata;
								decimal num15 = metadata4.localizedPrice;
								if (action3 != null)
								{
									object obj21 = action3 as string;
								}
								object obj22 = array.Length;
								bool flag17 = array.Length < 3;
								bool flag18 = !flag17;
								object obj23 = array.Length - 3;
								bool flag19 = obj23 == null;
								bool flag20 = !flag18;
								if (!(flag20 || flag19))
								{
									array[3] = (string)(object)action3;
									ProductMetadata metadata5 = product.metadata;
									if (metadata5.localizedPriceString != null)
									{
										object obj24 = metadata5.localizedPriceString as string;
										obj22 = array.Length;
									}
									bool flag21 = (long)(IntPtr)obj22 < 4L;
									bool flag22 = !flag21;
									object obj25 = (long)(IntPtr)obj22 - 4L;
									bool flag23 = obj25 == null;
									bool flag24 = !flag22;
									if (!(flag24 || flag23))
									{
										array[4] = metadata5.localizedPriceString;
										if (product.transactionID != null)
										{
											object obj26 = product.transactionID as string;
											obj22 = array.Length;
										}
										bool flag25 = (long)(IntPtr)obj22 < 5L;
										bool flag26 = !flag25;
										object obj27 = (long)(IntPtr)obj22 - 5L;
										bool flag27 = obj27 == null;
										bool flag28 = !flag26;
										if (!(flag28 || flag27))
										{
											array[5] = product.transactionID;
											if (product.receipt != null)
											{
												object obj28 = product.receipt as string;
												obj22 = array.Length;
											}
											bool flag29 = (long)(IntPtr)obj22 < 6L;
											bool flag30 = !flag29;
											object obj29 = (long)(IntPtr)obj22 - 6L;
											bool flag31 = obj29 == null;
											bool flag32 = !flag30;
											if (!(flag32 || flag31))
											{
												array[6] = product.receipt;
												string message = string.Join(" - ", array);
												Debug.Log(message);
												intPtr8 = default(IntPtr);
												goto IL_0aa6;
											}
										}
									}
								}
							}
						}
					}
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex2;
				IL_0aa6:
				num13 = all.Length;
				num14++;
			}
			while (num14 < all.Length);
		}
		ProductCollection products3 = m_Controller.products;
		AddProductUIs(products3.all);
		LogProductDefinitions();
		return;
		IL_0263:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
		goto IL_0c60;
		IL_0c60:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8D8294");
		object obj30 = default(object);
		num = (int)obj30;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v776 @ X0_v22] (should have been resolved before IL gen)");
		IMoolahExtension moolahExtensions = default(IMoolahExtension);
		m_MoolahExtensions = moolahExtensions;
		IntPtr intPtr9 = (IntPtr)0;
		IntPtr intPtr10 = (IntPtr)extensions;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v785 @ X8_v22 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
		num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v785 @ X8_v22 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
		if ((IntPtr)0 == (IntPtr)0)
		{
			goto IL_0337;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v785 @ X8_v22 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]");
		object obj31 = 0L + 8L;
		int num16 = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v830 @ X11_v48-8]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				break;
			}
			num16++;
			bool flag33 = num16 < num;
			bool flag34 = !flag33;
			obj31 = (long)(IntPtr)obj31 + 16L;
			if (!flag34)
			{
				continue;
			}
			goto IL_0337;
		}
		num = (int)obj31;
		int num17 = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v784 @ X22_v9 (Il2CppMethodInfo)+48]");
		num = (int)((long)num17 + 0L);
		int num18 = num << 4;
		object obj32 = (long)intPtr10 + (long)num18;
		object obj33 = (long)(IntPtr)obj32 + 304L;
		goto IL_0cf0;
		IL_0d80:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8D8294");
		object obj34 = default(object);
		num = (int)obj34;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v952 @ X0_v32] (should have been resolved before IL gen)");
		ITransactionHistoryExtensions transactionHistoryExtensions = default(ITransactionHistoryExtensions);
		m_TransactionHistoryExtensions = transactionHistoryExtensions;
		IntPtr intPtr11 = (IntPtr)0;
		IntPtr intPtr12 = (IntPtr)extensions;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v960 @ X8_v32 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
		num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v960 @ X8_v32 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
		if ((IntPtr)0 == (IntPtr)0)
		{
			goto IL_04df;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v960 @ X8_v32 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]");
		object obj35 = 0L + 8L;
		int num19 = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1004 @ X11_v38-8]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				break;
			}
			num19++;
			bool flag35 = num19 < num;
			bool flag36 = !flag35;
			obj35 = (long)(IntPtr)obj35 + 16L;
			if (!flag36)
			{
				continue;
			}
			goto IL_04df;
		}
		num = (int)obj35;
		int num20 = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ X22_v11 (Il2CppMethodInfo)+48]");
		num = (int)((long)num20 + 0L);
		int num21 = num << 4;
		object obj36 = (long)intPtr12 + (long)num21;
		object obj37 = (long)(IntPtr)obj36 + 304L;
		goto IL_0e10;
		IL_018f:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
		goto IL_0bd0;
		IL_0bd0:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8D8294");
		object obj38 = default(object);
		num = (int)obj38;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v688 @ X0_v17] (should have been resolved before IL gen)");
		ISamsungAppsExtensions samsungExtensions = default(ISamsungAppsExtensions);
		m_SamsungExtensions = samsungExtensions;
		IntPtr intPtr13 = (IntPtr)0;
		IntPtr intPtr14 = (IntPtr)extensions;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v697 @ X8_v17 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
		num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v697 @ X8_v17 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
		if ((IntPtr)0 == (IntPtr)0)
		{
			goto IL_0263;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v697 @ X8_v17 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]");
		object obj39 = 0L + 8L;
		int num22 = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v742 @ X11_v53-8]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				break;
			}
			num22++;
			bool flag37 = num22 < num;
			bool flag38 = !flag37;
			obj39 = (long)(IntPtr)obj39 + 16L;
			if (!flag38)
			{
				continue;
			}
			goto IL_0263;
		}
		num = (int)obj39;
		int num23 = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v696 @ X22_v8 (Il2CppMethodInfo)+48]");
		num = (int)((long)num23 + 0L);
		int num24 = num << 4;
		object obj40 = (long)intPtr14 + (long)num24;
		object obj41 = (long)(IntPtr)obj40 + 304L;
		goto IL_0c60;
	}

	[Token(Token = "0x6000002")]
	[Address(RVA = "0x16081C0", Offset = "0x16081C0", Length = "0xF0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EE9E58]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, e, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A1D9]) = v41;\nL_0017:\n\tv43 = e.<purchasedProduct>k__BackingField;\n\tv58 = v43.<definition>k__BackingField;\n\tv68 = System.String::Concat(\"Purchase OK: \", v58.<id>k__BackingField);\n\tgoto L_0033;\n\tv95 = *([v91 @ X8_v10+E0]);\n\tv96 = v95 == 0;\n\tv97 = ~v96;\n\tif (v97) goto L_0033;\n\tv101 = v91;\n\tv99 = \"il2cpp_codegen_runtime_class_init\"(v101, v64, v49, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0033:\n\tUnityEngine.Debug::Log(v68);\n\tv59 = e.<purchasedProduct>k__BackingField;\n\tv105 = System.String::Concat(\"Receipt: \", v59.<receipt>k__BackingField);\n\tUnityEngine.Debug::Log(v105);\n\tthis.m_PurchaseInProgress = 0;\n\tIAPDemo::UpdateProductUI(this, e.<purchasedProduct>k__BackingField);\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
	{
		Product purchasedProduct = e.purchasedProduct;
		ProductDefinition definition = purchasedProduct.definition;
		string message = "Purchase OK: " + definition.id;
		Debug.Log(message);
		Product purchasedProduct2 = e.purchasedProduct;
		string message2 = "Receipt: " + purchasedProduct2.receipt;
		Debug.Log(message2);
		m_PurchaseInProgress = false;
		UpdateProductUI(e.purchasedProduct);
		return default(PurchaseProcessingResult);
	}

	[Token(Token = "0x6000003")]
	[Address(RVA = "0x16083B0", Offset = "0x16083B0", Length = "0x2AC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EAC420]);\n\tv27 = *([v26 @ X8_v35]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, item, r, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202A1DA]) = v44;\nL_0019:\n\tv46 = item.<definition>k__BackingField;\n\tv145 = System.String::Concat(\"Purchase failed: \", v46.<id>k__BackingField);\n\tgoto L_0032;\n\tv195 = *([v191 @ X8_v8+E0]);\n\tv196 = v195 == 0;\n\tv197 = ~v196;\n\tif (v197) goto L_0032;\n\tv255 = v191;\n\tv199 = \"il2cpp_codegen_runtime_class_init\"(v255, v141, v112, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0032:\n\tUnityEngine.Debug::Log(v145);\n\t// 56 Box v120 @ X0_v11 (System.Object), typeof(UnityEngine.Purchasing.PurchaseFailureReason), &r @ X2 (UnityEngine.Purchasing.PurchaseFailureReason)\n\tUnityEngine.Debug::Log(v120);\n\tv131 = this.m_TransactionHistoryExtensions;\n\tv260 = *([v131 @ X20_v4 (UnityEngine.Purchasing.ITransactionHistoryExtensions)]);\n\tv263 = *([v260 @ X8_v11 (Il2CppClass<UnityEngine.Purchasing.ITransactionHistoryExtensions>)+126]) == 0;\n\tif (v263) goto L_0062;\n\tv305 = *([v260 @ X8_v11 (Il2CppClass<UnityEngine.Purchasing.ITransactionHistoryExtensions>)+B0]) + 8;\nL_004D:\n\tv310 = *([v305 @ X11_v20-8]) == UnityEngine.Purchasing.ITransactionHistoryExtensions;\n\tif (v310) goto L_0065;\n\tv304 = v304 + 1;\n\tv315 = v304 < *([v260 @ X8_v11 (Il2CppClass<UnityEngine.Purchasing.ITransactionHistoryExtensions>)+126]);\n\tv286 = ~v315;\n\tv305 = v305 + 0x10;\n\tv270 = ~v286;\n\tif (v270) goto L_004D;\nL_0062:\n\tv145 = 0x8909C4(v131, UnityEngine.Purchasing.ITransactionHistoryExtensions, 1, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_006C;\nL_0065:\n\tv317 = *([v305 @ X11_v20]) + 1;\n\tv318 = v317 << 4;\n\tv319 = v260 + v318;\n\tv145 = v319 + 0x130;\nL_006C:\n\t*([v145 @ X0_v7 (System.String)])(v145, v131, *([v145 @ X0_v7 (System.String)+8]), v321, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\t// 115 Box v333 @ X0_v16 (System.Object), typeof(UnityEngine.Purchasing.StoreSpecificPurchaseErrorCode), &v145 @ X0_v7 (System.String)\n\tv145 = System.String::Concat(\"Store specific error code: \", v333);\n\tUnityEngine.Debug::Log(v145);\n\tgoto L_00AB;\n\tv342 = *([v338 @ X8_v20+B0]);\n\tv343 = 0;\n\tv344 = v342 + 8;\n\tv346 = *([v383 @ X11_v15-8]);\n\tv388 = v346 == v339;\n\tif (v388) goto L_00A4;\n\tv366 = v382 + 1;\n\tv393 = v366 < v340;\n\tv364 = ~v393;\n\tv368 = v383 + 0x10;\n\tv348 = ~v364;\n\tif (v348) goto L_FFFFFFFF;\n\tv369 = v132;\n\tv370 = 0;\n\tv371 = 0x8909C4(v369, v339, v370, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_00AB;\nL_00A4:\n\tv394 = *([v383 @ X11_v15]);\n\tv395 = v394 << 4;\n\tv396 = v338 + v395;\n\tv397 = v396 + 0x130;\nL_00AB:\n\tv122 = UnityEngine.Purchasing.ITransactionHistoryExtensions::GetLastPurchaseFailureDescription(this.m_TransactionHistoryExtensions);\n\tv401 = v122 == 0;\n\tif (v401) goto L_00F4;\n\tgoto L_00DC;\n\tv414 = *([v410 @ X8_v24+B0]);\n\tv415 = 0;\n\tv416 = v414 + 8;\n\tv418 = *([v455 @ X11_v10-8]);\n\tv460 = v418 == v411;\n\tif (v460) goto L_00D5;\n\tv438 = v454 + 1;\n\tv465 = v438 < v412;\n\tv436 = ~v465;\n\tv440 = v455 + 0x10;\n\tv420 = ~v436;\n\tif (v420) goto L_FFFFFFFF;\n\tv441 = v133;\n\tv442 = 0;\n\tv443 = 0x8909C4(v441, v411, v442, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_00DC;\nL_00D5:\n\tv466 = *([v455 @ X11_v10]);\n\tv467 = v466 << 4;\n\tv468 = v410 + v467;\n\tv469 = v468 + 0x130;\nL_00DC:\n\tv181 = UnityEngine.Purchasing.ITransactionHistoryExtensions::GetLastPurchaseFailureDescription(this.m_TransactionHistoryExtensions);\n\tv145 = System.String::Concat(\"Purchase failure description message: \", v181.<message>k__BackingField);\n\tgoto L_00F3;\n\tv481 = *([v409 @ X8_v29+E0]);\n\tv482 = v481 == 0;\n\tv483 = ~v482;\n\tif (v483) goto L_00F3;\n\tv486 = v409;\n\tv485 = \"il2cpp_codegen_runtime_class_init\"(v486, v474, v403, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00F3:\n\tUnityEngine.Debug::Log(v145);\nL_00F4:\n\tthis.m_PurchaseInProgress = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 156 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void OnPurchaseFailed(Product item, PurchaseFailureReason r)
	{
		//IL_006e: Expected I, but got O
		//IL_01f0: Expected I4, but got O
		//IL_00a9: Expected O, but got I
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Expected O, but got Unknown
		//IL_0156: Expected O, but got I
		//IL_0165: Expected O, but got I
		//IL_00f5: Expected O, but got I
		ProductDefinition definition = item.definition;
		string text = "Purchase failed: " + definition.id;
		Debug.Log(text);
		object message = r;
		Debug.Log(message);
		ITransactionHistoryExtensions transactionHistoryExtensions = m_TransactionHistoryExtensions;
		IntPtr intPtr = (IntPtr)transactionHistoryExtensions;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ X8_v11 (Il2CppClass<UnityEngine.Purchasing.ITransactionHistoryExtensions>)+126]");
		if ((IntPtr)0 == (IntPtr)0)
		{
			goto IL_010e;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ X8_v11 (Il2CppClass<UnityEngine.Purchasing.ITransactionHistoryExtensions>)+B0]");
		object obj = 0L + 8L;
		int num = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ X11_v20-8]");
			if ((IntPtr)0 == (IntPtr)typeof(ITransactionHistoryExtensions))
			{
				break;
			}
			num++;
			int num2 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ X8_v11 (Il2CppClass<UnityEngine.Purchasing.ITransactionHistoryExtensions>)+126]");
			bool flag = (long)num2 < 0L;
			bool flag2 = !flag;
			obj = (long)(IntPtr)obj + 16L;
			if (!flag2)
			{
				continue;
			}
			goto IL_010e;
		}
		object obj2 = obj + 1;
		int num3 = (int)((long)(IntPtr)obj2 << 4);
		object obj3 = (long)intPtr + (long)num3;
		text = (string)((long)(IntPtr)obj3 + 304L);
		int num4 = 0;
		goto IL_01dd;
		IL_010e:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
		num4 = 1;
		goto IL_01dd;
		IL_01dd:
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v145 @ X0_v7 (System.String)] (should have been resolved before IL gen)");
		object obj4 = (StoreSpecificPurchaseErrorCode)text;
		text = "Store specific error code: " + obj4;
		Debug.Log(text);
		PurchaseFailureDescription lastPurchaseFailureDescription = m_TransactionHistoryExtensions.GetLastPurchaseFailureDescription();
		if (lastPurchaseFailureDescription != null)
		{
			PurchaseFailureDescription lastPurchaseFailureDescription2 = m_TransactionHistoryExtensions.GetLastPurchaseFailureDescription();
			text = "Purchase failure description message: " + lastPurchaseFailureDescription2.message;
			Debug.Log(text);
		}
		m_PurchaseInProgress = false;
	}

	[Token(Token = "0x6000004")]
	[Address(RVA = "0x160865C", Offset = "0x160865C", Length = "0x114")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED9260]);\n\tv19 = *([v18 @ X8_v26]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, error, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202A1DB]) = v38;\nL_0019:\n\tgoto L_0023;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0023;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, error, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0023:\n\tUnityEngine.Debug::Log(\"Billing failed to initialize!\");\n\tv56 = error == 0;\n\tif (v56) goto L_0054;\n\tv61 = error == 1;\n\tif (v61) goto L_0061;\n\tv79 = error != 2;\n\tif (v79) goto L_0077;\n\tgoto L_004E;\n\tv135 = *([v93 @ X0_v13+E0]);\n\tv136 = v135 == 0;\n\tv137 = ~v136;\n\tif (v137) goto L_004E;\n\tv139 = \"il2cpp_codegen_runtime_class_init\"(v93, v54, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_004E:\n\tUnityEngine.Debug::LogError(\"Is your App correctly uploaded on the relevant publisher console?\");\n\treturn;\nL_0054:\n\tgoto L_FFFFFFFF;\n\tv84 = *([v66 @ X0_v7+E0]);\n\tv85 = v84 == 0;\n\tv86 = ~v85;\n\tif (v86) goto L_FFFFFFFF;\n\tv88 = \"il2cpp_codegen_runtime_class_init\"(v66, v54, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tgoto L_0070;\nL_0061:\n\tgoto L_FFFFFFFF;\n\tv101 = *([v80 @ X0_v10+E0]);\n\tv102 = v101 == 0;\n\tv103 = ~v102;\n\tif (v103) goto L_FFFFFFFF;\n\tv105 = \"il2cpp_codegen_runtime_class_init\"(v80, v54, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0070:\n\tUnityEngine.Debug::Log(*([v128 @ X8_v7 (System.String)]));\n\treturn;\nL_0077:\n\treturn;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void OnInitializeFailed(InitializationFailureReason error)
	{
		Debug.Log("Billing failed to initialize!");
		string message;
		switch (error)
		{
		case InitializationFailureReason.AppNotKnown:
			Debug.LogError("Is your App correctly uploaded on the relevant publisher console?");
			return;
		case InitializationFailureReason.PurchasingUnavailable:
			message = "Billing disabled!";
			break;
		case InitializationFailureReason.NoProductsAvailable:
			message = "No products available for purchase!";
			break;
		default:
			return;
		}
		Debug.Log(message);
	}

	[Token(Token = "0x6000005")]
	[Address(RVA = "0x1608770", Offset = "0x1608770", Length = "0x1018")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = &v21 @ X29;\n\tgoto L_0024;\n\tv33 = *([1EF0FC0]);\n\tv34 = *([v33 @ X8_v184]);\n\tv35 = \"il2cpp_codegen_initialize_method\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([202A1DC]) = v53;\nL_0024:\n\tgoto L_002B;\n\tv63 = *([v59 @ X0_v2+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tgoto L_002B;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v59, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_002B:\n\tv71 = UnityEngine.Purchasing.StandardPurchasingModule::Instance();\n\tv71.<useFakeStoreUIMode>k__BackingField = 1;\n\tv79 = Il2CppClass<System.EmptyArray`1<UnityEngine.Purchasing.Extension.IPurchasingModule>>;\n\tgoto L_003E;\n\tv353 = v79;\n\tv354 = 0x8907BC(v353, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv357 = *([v79 @ X20_v6 (Il2CppClass<System.EmptyArray`1<UnityEngine.Purchasing.Extension.IPurchasingModule>>)+12E]);\nL_003E:\n\tv358 = *([v79 @ X20_v6 (Il2CppClass<System.EmptyArray`1<UnityEngine.Purchasing.Extension.IPurchasingModule>>)+12E]) & 0x200;\n\tv359 = v358 == 0;\n\tif (v359) goto L_005F;\n\tv429 = Il2CppClass<System.EmptyArray`1<UnityEngine.Purchasing.Extension.IPurchasingModule>>;\n\tgoto L_004B;\n\tv451 = v429;\n\tv452 = 0x8907BC(v451, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_004B:\n\tv453 = *([v429 @ X20_v11 (Il2CppClass<System.EmptyArray`1<UnityEngine.Purchasing.Extension.IPurchasingModule>>)+E0]) == 0;\n\tv441 = ~v453;\n\tif (v441) goto L_005F;\n\tgoto L_005F;\n\tv563 = v435;\n\tv564 = 0x8907BC(v563, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_005F:\n\tgoto L_0066;\n\tv454 = v446;\n\tv455 = 0x8907BC(v454, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0066:\n\tv288 = UnityEngine.Purchasing.ConfigurationBuilder::Instance(v71, v329.Value);\n\tv289 = UnityEngine.Purchasing.ConfigurationBuilder::Configure(v288);\n\tgoto L_00A0;\n\tv697 = *([v628 @ X8_v24+B0]);\n\tv698 = 0;\n\tv699 = v697 + 8;\n\tv701 = *([v737 @ X11_v104-8]);\n\tv743 = v701 == v631;\n\tif (v743) goto L_0098;\n\tv723 = v738 + 1;\n\tv748 = v723 < v630;\n\tv719 = ~v748;\n\tv721 = v737 + 0x10;\n\tv703 = ~v719;\n\tif (v703) goto L_FFFFFFFF;\n\tv724 = v238;\n\tv725 = 0;\n\tv726 = 0x8909C4(v724, v631, v725, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_00A0;\nL_0098:\n\tv749 = *([v737 @ X11_v104]);\n\tv750 = v749 << 4;\n\tv751 = v628 + v750;\n\tv752 = v751 + 0x130;\nL_00A0:\n\tUnityEngine.Purchasing.IMicrosoftConfiguration::set_useMockBillingSystem(v289, 0);\n\tv770 = UnityEngine.Application::get_platform();\n\tv143 = v770 != 0xB;\n\tif (v143) goto L_00BE;\n\tv783 = UnityEngine.Purchasing.StandardPurchasingModule::get_appStore(v71);\n\tv790 = v783 - 1;\n\tv788 = v790 == 0;\nL_00BE:\n\tthis.m_IsGooglePlayStoreSelected = v331;\n\tv290 = UnityEngine.Purchasing.ConfigurationBuilder::Configure(v288);\n\tgoto L_00F8;\n\tv803 = *([v797 @ X8_v29+B0]);\n\tv804 = 0;\n\tv805 = v803 + 8;\n\tv807 = *([v843 @ X11_v99-8]);\n\tv849 = v807 == v799;\n\tif (v849) goto L_00F0;\n\tv829 = v844 + 1;\n\tv854 = v829 < v801;\n\tv825 = ~v854;\n\tv827 = v843 + 0x10;\n\tv809 = ~v825;\n\tif (v809) goto L_FFFFFFFF;\n\tv830 = v239;\n\tv831 = 0;\n\tv832 = 0x8909C4(v830, v799, v831, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_00F8;\nL_00F0:\n\tv855 = *([v843 @ X11_v99]);\n\tv856 = v855 << 4;\n\tv857 = v797 + v856;\n\tv858 = v857 + 0x130;\nL_00F8:\n\tUnityEngine.Purchasing.IMoolahConfiguration::set_appKey(v290, \"d93f4564c41d463ed3d3cd207594ee1b\");\n\tv291 = UnityEngine.Purchasing.ConfigurationBuilder::Configure(v288);\n\tv867 = *([v291 @ X0_v36 (UnityEngine.Purchasing.IMoolahConfiguration)]);\n\tv871 = *([v867 @ X8_v32 (Il2CppClass<UnityEngine.Purchasing.IMoolahConfiguration>)+126]) == 0;\n\tif (v871) goto L_0124;\n\tv912 = *([v867 @ X8_v32 (Il2CppClass<UnityEngine.Purchasing.IMoolahConfiguration>)+B0]) + 8;\nL_010F:\n\tv918 = *([v912 @ X11_v94-8]) == UnityEngine.Purchasing.IMoolahConfiguration;\n\tif (v918) goto L_0127;\n\tv913 = v913 + 1;\n\tv923 = v913 < *([v867 @ X8_v32 (Il2CppClass<UnityEngine.Purchasing.IMoolahConfiguration>)+126]);\n\tv894 = ~v923;\n\tv912 = v912 + 0x10;\n\tv878 = ~v894;\n\tif (v878) goto L_010F;\nL_0124:\n\tv930 = 0x8909C4(v291, UnityEngine.Purchasing.IMoolahConfiguration, 1, v1397, v571, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_012F;\nL_0127:\n\tv925 = *([v912 @ X11_v94]) + 1;\n\tv926 = v925 << 4;\n\tv927 = v867 + v926;\n\tv930 = v927 + 0x130;\nL_012F:\n\t*([v930 @ X0_v37])(v934, v291, \"cc\", *([v930 @ X0_v37+8]), v1397, v571, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv292 = UnityEngine.Purchasing.ConfigurationBuilder::Configure(v288);\n\tv936 = *([v292 @ X0_v41 (UnityEngine.Purchasing.IMoolahConfiguration)]);\n\tv939 = *([v936 @ X8_v35 (Il2CppClass<UnityEngine.Purchasing.IMoolahConfiguration>)+126]) == 0;\n\tif (v939) goto L_0158;\n\tv980 = *([v936 @ X8_v35 (Il2CppClass<UnityEngine.Purchasing.IMoolahConfiguration>)+B0]) + 8;\nL_0143:\n\tv986 = *([v980 @ X11_v89-8]) == UnityEngine.Purchasing.IMoolahConfiguration;\n\tif (v986) goto L_015B;\n\tv981 = v981 + 1;\n\tv991 = v981 < *([v936 @ X8_v35 (Il2CppClass<UnityEngine.Purchasing.IMoolahConfiguration>)+126]);\n\tv962 = ~v991;\n\tv980 = v980 + 0x10;\n\tv946 = ~v962;\n\tif (v946) goto L_0143;\nL_0158:\n\tv1007 = 0x8909C4(v292, UnityEngine.Purchasing.IMoolahConfiguration, 2, v1397, v571, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_0163;\nL_015B:\n\tv993 = *([v980 @ X11_v89]) + 2;\n\tv994 = v993 << 4;\n\tv995 = v936 + v994;\n\tv1007 = v995 + 0x130;\nL_0163:\n\t*([v1007 @ X0_v42])(v1012, v292, 1, *([v1007 @ X0_v42+8]), v1397, v571, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv1014 = UnityEngine.Application::get_platform();\n\tv146 = v1014 != 0xB;\n\tif (v146) goto L_FFFFFFFF;\n\tv1026 = UnityEngine.Purchasing.StandardPurchasingModule::get_appStore(v71);\n\tv1030 = v1026 - 3;\n\tv1032 = v1030 == 0;\n\tgoto L_0181;\nL_0181:\n\tthis.m_IsCloudMoolahStoreSelected = v334;\n\tv293 = UnityEngine.Purchasing.ProductCatalog::LoadDefaultCatalog();\n\tv294 = UnityEngine.Purchasing.ProductCatalog::get_allValidProducts(v293);\n\tgoto L_01B7;\n\tv1046 = *([v1041 @ X8_v39+B0]);\n\tv1047 = 0;\n\tv1048 = v1046 + 8;\n\tv1050 = *([v1086 @ X11_v84-8]);\n\tv1092 = v1050 == v1044;\n\tif (v1092) goto L_01B0;\n\tv1072 = v1087 + 1;\n\tv1097 = v1072 < v1043;\n\tv1068 = ~v1097;\n\tv1070 = v1086 + 0x10;\n\tv1052 = ~v1068;\n\tif (v1052) goto L_FFFFFFFF;\n\tv1073 = v242;\n\tv1074 = 0;\n\tv1075 = 0x8909C4(v1073, v1044, v1074, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_01B7;\nL_01B0:\n\tv1098 = *([v1086 @ X11_v84]);\n\tv1099 = v1098 << 4;\n\tv1100 = v1041 + v1099;\n\tv1101 = v1100 + 0x130;\nL_01B7:\n\tv1122 = System.Collections.Generic.IEnumerable`1<UnityEngine.Purchasing.ProductCatalogItem>::GetEnumerator(v294);\n\t*([v21 @ X29-60]) = v71;\n\t*([v21 @ X29-58]) = this;\nL_01C9:\n\tgoto L_01F0;\n\tv1207 = *([v1201 @ X8_v127+B0]);\n\tv1208 = 0;\n\tv1209 = v1207 + 8;\n\tv1211 = *([v1288 @ X11_v79-8]);\n\tv1294 = v1211 == v1202;\n\tif (v1294) goto L_01E9;\n\tv1233 = v1289 + 1;\n\tv1325 = v1233 < v1203;\n\tv1229 = ~v1325;\n\tv1231 = v1288 + 0x10;\n\tv1213 = ~v1229;\n\tif (v1213) goto L_FFFFFFFF;\n\tv1234 = v496;\n\tv1235 = 0;\n\tv1236 = 0x8909C4(v1234, v1202, v1235, v1138, v93, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_01F0;\nL_01E9:\n\tv1326 = *([v1288 @ X11_v79]);\n\tv1327 = v1326 << 4;\n\tv1328 = v1201 + v1327;\n\tv1329 = v1328 + 0x130;\nL_01F0:\n\tv1350 = System.Collections.IEnumerator::MoveNext(v1122);\n\tv1352 = v1350 == 0;\n\tif (v1352) goto L_03AC;\n\tgoto L_0221;\n\tv1437 = *([v1382 @ X8_v131+B0]);\n\tv1438 = 0;\n\tv1439 = v1437 + 8;\n\tv1441 = *([v1585 @ X11_v74-8]);\n\tv1591 = v1441 == v1386;\n\tif (v1591) goto L_021A;\n\tv1463 = v1586 + 1;\n\tv1661 = v1463 < v1384;\n\tv1459 = ~v1661;\n\tv1461 = v1585 + 0x10;\n\tv1443 = ~v1459;\n\tif (v1443) goto L_FFFFFFFF;\n\tv1464 = v496;\n\tv1465 = 0;\n\tv1466 = 0x8909C4(v1464, v1386, v1465, v1138, v93, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_0221;\nL_021A:\n\tv1662 = *([v1585 @ X11_v74]);\n\tv1663 = v1662 << 4;\n\tv1664 = v1382 + v1663;\n\tv1665 = v1664 + 0x130;\nL_0221:\n\tv1270 = System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.ProductCatalogItem>::get_Current(v1122);\n\tv1318 =\n// ... truncated")]
	public void Awake()
	{
		//IL_0107: Expected I, but got O
		//IL_0142: Expected O, but got I
		//IL_0202: Expected I, but got O
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Expected O, but got Unknown
		//IL_01e6: Expected O, but got I
		//IL_01f5: Expected O, but got I
		//IL_023d: Expected O, but got I
		//IL_018e: Expected O, but got I
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Expected O, but got Unknown
		//IL_02e1: Expected O, but got I
		//IL_02f0: Expected O, but got I
		//IL_0289: Expected O, but got I
		//IL_106a: Expected O, but got I8
		//IL_1078: Expected I, but got O
		//IL_06b7: Expected O, but got I
		//IL_11e9: Expected O, but got I
		//IL_0761: Expected O, but got I
		//IL_03db: Expected O, but got I
		//IL_0528: Expected O, but got I
		//IL_053e: Expected O, but got I
		//IL_07a2: Expected I4, but got O
		//IL_07d3: Expected I, but got O
		//IL_07f1: Expected I, but got O
		//IL_0801: Expected O, but got I
		//IL_0809: Expected I4, but got O
		//IL_11a0: Expected O, but got I
		//IL_11af: Expected O, but got I
		//IL_05b1: Expected O, but got I4
		//IL_063a: Expected I4, but got I8
		//IL_0648: Expected O, but got I
		//IL_0662: Expected O, but got I
		//IL_0689: Expected O, but got I
		//IL_06a3: Expected I, but got O
		//IL_046a: Expected I4, but got O
		//IL_05e2: Expected O, but got I4
		//IL_04f1: Expected O, but got I
		//IL_0e7b: Expected O, but got I
		//IL_0e91: Expected O, but got I
		object obj = obj;
		StandardPurchasingModule standardPurchasingModule = StandardPurchasingModule.Instance();
		standardPurchasingModule.useFakeStoreUIMode = FakeStoreUIMode.StandardUser;
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ X20_v6 (Il2CppClass<System.EmptyArray`1<UnityEngine.Purchasing.Extension.IPurchasingModule>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v429 @ X20_v11 (Il2CppClass<System.EmptyArray`1<UnityEngine.Purchasing.Extension.IPurchasingModule>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		ConfigurationBuilder configurationBuilder = ConfigurationBuilder.Instance(standardPurchasingModule);
		IMicrosoftConfiguration microsoftConfiguration = configurationBuilder.Configure<IMicrosoftConfiguration>();
		microsoftConfiguration.useMockBillingSystem = false;
		RuntimePlatform platform = Application.platform;
		bool flag = platform != RuntimePlatform.Android;
		bool isGooglePlayStoreSelected = false;
		if (!flag)
		{
			AppStore appStore = standardPurchasingModule.appStore;
			int num = (int)(appStore - 1);
			bool flag2 = num == 0;
			isGooglePlayStoreSelected = flag2;
		}
		m_IsGooglePlayStoreSelected = isGooglePlayStoreSelected;
		IMoolahConfiguration moolahConfiguration = configurationBuilder.Configure<IMoolahConfiguration>();
		moolahConfiguration.appKey = "d93f4564c41d463ed3d3cd207594ee1b";
		IMoolahConfiguration moolahConfiguration2 = configurationBuilder.Configure<IMoolahConfiguration>();
		IntPtr intPtr3 = (IntPtr)moolahConfiguration2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v867 @ X8_v32 (Il2CppClass<UnityEngine.Purchasing.IMoolahConfiguration>)+126]");
		if ((IntPtr)0 == (IntPtr)0)
		{
			goto IL_01a7;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v867 @ X8_v32 (Il2CppClass<UnityEngine.Purchasing.IMoolahConfiguration>)+B0]");
		object obj2 = 0L + 8L;
		int num2 = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v912 @ X11_v94-8]");
			if ((IntPtr)0 == (IntPtr)typeof(IMoolahConfiguration))
			{
				break;
			}
			num2++;
			int num3 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v867 @ X8_v32 (Il2CppClass<UnityEngine.Purchasing.IMoolahConfiguration>)+126]");
			bool flag3 = (long)num3 < 0L;
			bool flag4 = !flag3;
			obj2 = (long)(IntPtr)obj2 + 16L;
			if (!flag4)
			{
				continue;
			}
			goto IL_01a7;
		}
		object obj3 = obj2 + 1;
		int num4 = (int)((long)(IntPtr)obj3 << 4);
		object obj4 = (long)intPtr3 + (long)num4;
		object obj5 = (long)(IntPtr)obj4 + 304L;
		goto IL_0fb8;
		IL_0ee0:
		throw new TypeLoadException();
		IL_02a2:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
		goto IL_0ffe;
		IL_01a7:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
		goto IL_0fb8;
		IL_0ffe:
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1007 @ X0_v42] (should have been resolved before IL gen)");
		RuntimePlatform platform2 = Application.platform;
		bool isCloudMoolahStoreSelected;
		if (platform2 == RuntimePlatform.Android)
		{
			AppStore appStore2 = standardPurchasingModule.appStore;
			int num5 = (int)(appStore2 - 3);
			bool flag5 = num5 == 0;
			isCloudMoolahStoreSelected = flag5;
		}
		else
		{
			isCloudMoolahStoreSelected = false;
		}
		m_IsCloudMoolahStoreSelected = isCloudMoolahStoreSelected;
		ProductCatalog productCatalog = ProductCatalog.LoadDefaultCatalog();
		ICollection<ProductCatalogItem> allValidProducts = productCatalog.allValidProducts;
		IEnumerator<ProductCatalogItem> enumerator = allValidProducts.GetEnumerator();
		string[] array = (string[])4294967295L;
		IntPtr intPtr4 = (IntPtr)typeof(IDs);
		object obj7 = default(object);
		object obj6 = obj7;
		string[] array3;
		IDs ds2 = default(IDs);
		int num7;
		object obj12 = default(object);
		while (true)
		{
			string[] array2;
			int num6;
			IntPtr intPtr5;
			object obj8;
			IDs ds;
			string[] array4;
			if (!enumerator.MoveNext())
			{
				array2 = (string[])((long)(IntPtr)array + 1L);
				_ = 326;
				bool flag6 = enumerator == null;
				bool flag7 = !flag6;
				num6 = 0;
				if (!flag7)
				{
					array3 = array2;
					intPtr5 = intPtr4;
					obj8 = obj6;
					ds = ds2;
					num7 = 0;
					array4 = null;
					break;
				}
				goto IL_1206;
			}
			ProductCatalogItem current = enumerator.Current;
			ICollection<StoreID> allStoreIDs = current.allStoreIDs;
			int count = allStoreIDs.Count;
			if (count < 1)
			{
				ConfigurationBuilder configurationBuilder2 = configurationBuilder.AddProduct(current.id, current.type);
				ds2 = null;
				continue;
			}
			IDs ds3 = new IDs();
			ICollection<StoreID> allStoreIDs2 = current.allStoreIDs;
			IEnumerator<StoreID> enumerator2 = allStoreIDs2.GetEnumerator();
			array2 = array;
			ds = ds2;
			string text = null;
			array4 = null;
			string[] array5;
			while (true)
			{
				if (enumerator2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-64]");
					array2 = (string[])0;
					if (!enumerator2.MoveNext())
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-78]");
						object obj9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-64]");
						array5 = (string[])(0L + 1L);
						_ = 261;
						enumerator2?.Dispose();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-78]");
						obj6 = 0;
						object obj10 = (long)(IntPtr)array5 + 1L;
						if (obj10 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1470 @ X26_v13+v1133 @ X28_v20 (System.String[])*4]");
							if ((IntPtr)0 == (IntPtr)261)
							{
								break;
							}
						}
						TypeLoadException ex = new TypeLoadException();
						array2 = array;
						ds = ds2;
						text = null;
						array4 = null;
						NullReferenceException ex2 = (NullReferenceException)(object)ex;
					}
					else
					{
						StoreID current2 = enumerator2.Current;
						if (current2 != null)
						{
							string[] array6 = new string[1];
							if (array6 != null)
							{
								bool flag8 = current2.store == null;
								int num8 = 1;
								if (!flag8)
								{
									object obj11 = current2.store as string;
									bool flag9 = obj11 == null;
									num8 = (int)typeof(string);
									if (flag9)
									{
										ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
										throw ex3;
									}
								}
								if (array6.Length == 0)
								{
									IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
									throw ex4;
								}
								array6[0] = current2.store;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-70]");
								if ((IntPtr)0 != (IntPtr)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-70]");
									((IDs)0).Add(current2.id, array6);
									array2 = array6;
									ds = null;
									text = current2.id;
									array4 = array6;
									continue;
								}
								NullReferenceException ex2 = new NullReferenceException();
								array2 = array6;
								text = (string)num8;
								array4 = null;
							}
							else
							{
								NullReferenceException ex2 = new NullReferenceException();
								array2 = array6;
								text = (string)1;
								array4 = null;
							}
						}
						else
						{
							NullReferenceException ex2 = new NullReferenceException();
							text = null;
							array4 = null;
						}
					}
				}
				else
				{
					NullReferenceException ex2 = new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-78]");
				obj6 = 0;
				if ((IntPtr)text == (IntPtr)1)
				{
					goto IL_078b;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
				return;
			}
			int num9 = (int)(0xFFFFFFFFL ^ (long)(IntPtr)array5);
			array5 = (string[])((long)(IntPtr)array5 + (long)num9);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-70]");
			ds2 = (IDs)0;
			string id = current.id;
			ProductType type = current.type;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-70]");
			ConfigurationBuilder configurationBuilder3 = configurationBuilder.AddProduct(id, type, (IDs)0);
			array = array5;
			intPtr4 = (IntPtr)typeof(IDs);
			continue;
			IL_078b:
			Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
			num6 = (int)obj12;
			Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
			bool flag10 = enumerator == null;
			intPtr4 = (IntPtr)typeof(IDs);
			ds2 = ds;
			array3 = array2;
			intPtr5 = (IntPtr)typeof(IDs);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-78]");
			obj8 = 0;
			num7 = (int)obj12;
			if (flag10)
			{
				break;
			}
			goto IL_1206;
			IL_1206:
			enumerator.Dispose();
			array3 = array2;
			intPtr5 = intPtr4;
			obj8 = obj6;
			ds = ds2;
			num7 = num6;
			array4 = null;
			break;
		}
		object obj13 = (long)(IntPtr)array3 + 1L;
		if (obj13 != null)
		{
			if (num7 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ X26_v8+v97 @ X28_v8 (System.String[])*4]");
				if ((IntPtr)0 != (IntPtr)326)
				{
					goto IL_0ee0;
				}
			}
		}
		else if (num7 != 0)
		{
			goto IL_0ee0;
		}
		IDs ds4 = new IDs();
		string[] array7 = new string[1];
		if ("MacAppStore" != null)
		{
			object obj14 = "MacAppStore" as string;
		}
		if (array7.Length != 0)
		{
			array7[0] = "MacAppStore";
			ds4.Add("com.unity3d.unityiap.unityiapdemo.100goldcoins.7", array7);
			string[] array8 = new string[1];
			if ("TizenStore" != null)
			{
				object obj15 = "TizenStore" as string;
			}
			if (array8.Length != 0)
			{
				array8[0] = "TizenStore";
				ds4.Add("000000596586", array8);
				string[] array9 = new string[1];
				if ("MoolahAppStore" != null)
				{
					object obj16 = "MoolahAppStore" as string;
				}
				if (array9.Length != 0)
				{
					array9[0] = "MoolahAppStore";
					ds4.Add("com.ff", array9);
					string[] array10 = new string[1];
					if ("AmazonApps" != null)
					{
						object obj17 = "AmazonApps" as string;
					}
					if (array10.Length != 0)
					{
						array10[0] = "AmazonApps";
						ds4.Add("100.gold.coins", array10);
						string[] array11 = new string[1];
						if ("AppleAppStore" != null)
						{
							object obj18 = "AppleAppStore" as string;
						}
						if (array11.Length != 0)
						{
							array11[0] = "AppleAppStore";
							ds4.Add("100.gold.coins", array11);
							ConfigurationBuilder configurationBuilder4 = configurationBuilder.AddProduct("100.gold.coins", default(ProductType), ds4);
							IDs ds5 = new IDs();
							string[] array12 = new string[1];
							if ("MacAppStore" != null)
							{
								object obj19 = "MacAppStore" as string;
							}
							if (array12.Length != 0)
							{
								array12[0] = "MacAppStore";
								ds5.Add("com.unity3d.unityiap.unityiapdemo.500goldcoins.7", array12);
								string[] array13 = new string[1];
								if ("TizenStore" != null)
								{
									object obj20 = "TizenStore" as string;
								}
								if (array13.Length != 0)
								{
									array13[0] = "TizenStore";
									ds5.Add("000000596581", array13);
									string[] array14 = new string[1];
									if ("MoolahAppStore" != null)
									{
										object obj21 = "MoolahAppStore" as string;
									}
									if (array14.Length != 0)
									{
										array14[0] = "MoolahAppStore";
										ds5.Add("com.ee", array14);
										string[] array15 = new string[1];
										if ("AmazonApps" != null)
										{
											object obj22 = "AmazonApps" as string;
										}
										if (array15.Length != 0)
										{
											array15[0] = "AmazonApps";
											ds5.Add("500.gold.coins", array15);
											ConfigurationBuilder configurationBuilder5 = configurationBuilder.AddProduct("500.gold.coins", default(ProductType), ds5);
											IDs storeIDs = new IDs();
											ConfigurationBuilder configurationBuilder6 = configurationBuilder.AddProduct("300.gold.coins", default(ProductType), storeIDs);
											IDs storeIDs2 = new IDs();
											ConfigurationBuilder configurationBuilder7 = configurationBuilder.AddProduct("sub1", ProductType.Subscription, storeIDs2);
											IDs storeIDs3 = new IDs();
											ConfigurationBuilder configurationBuilder8 = configurationBuilder.AddProduct("sub2", ProductType.Subscription, storeIDs3);
											ISamsungAppsConfiguration samsungAppsConfiguration = configurationBuilder.Configure<ISamsungAppsConfiguration>();
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-58]");
											IStoreListener listener = (IStoreListener)0;
											samsungAppsConfiguration.SetMode(SamsungAppsMode.AlwaysSucceed);
											RuntimePlatform platform3 = Application.platform;
											if (platform3 == RuntimePlatform.Android)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-60]");
												AppStore appStore3 = ((StandardPurchasingModule)0).appStore;
												int num10 = (int)(appStore3 - 4);
												bool flag11 = num10 == 0;
												bool flag12 = flag11;
											}
											else
											{
												bool flag12 = false;
											}
											ITizenStoreConfiguration tizenStoreConfiguration = configurationBuilder.Configure<ITizenStoreConfiguration>();
											tizenStoreConfiguration.SetGroupId("100000085616");
											UnityPurchasing.Initialize(listener, configurationBuilder);
											return;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		IndexOutOfRangeException ex5 = new IndexOutOfRangeException();
		goto IL_0ee0;
		IL_0fb8:
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v930 @ X0_v37] (should have been resolved before IL gen)");
		IMoolahConfiguration moolahConfiguration3 = configurationBuilder.Configure<IMoolahConfiguration>();
		IntPtr intPtr6 = (IntPtr)moolahConfiguration3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v936 @ X8_v35 (Il2CppClass<UnityEngine.Purchasing.IMoolahConfiguration>)+126]");
		if ((IntPtr)0 == (IntPtr)0)
		{
			goto IL_02a2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v936 @ X8_v35 (Il2CppClass<UnityEngine.Purchasing.IMoolahConfiguration>)+B0]");
		object obj23 = 0L + 8L;
		int num11 = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v980 @ X11_v89-8]");
			if ((IntPtr)0 == (IntPtr)typeof(IMoolahConfiguration))
			{
				break;
			}
			num11++;
			int num12 = num11;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v936 @ X8_v35 (Il2CppClass<UnityEngine.Purchasing.IMoolahConfiguration>)+126]");
			bool flag13 = (long)num12 < 0L;
			bool flag14 = !flag13;
			obj23 = (long)(IntPtr)obj23 + 16L;
			if (!flag14)
			{
				continue;
			}
			goto IL_02a2;
		}
		object obj24 = obj23 + 2;
		int num13 = (int)((long)(IntPtr)obj24 << 4);
		object obj25 = (long)intPtr6 + (long)num13;
		object obj26 = (long)(IntPtr)obj25 + 304L;
		goto IL_0ffe;
	}

	[Token(Token = "0x6000006")]
	[Address(RVA = "0x1609788", Offset = "0x1609788", Length = "0xA0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = &v7 @ stack_-10_v2;\n\t*([v6 @ X29_v1-4]) = success;\n\tgoto L_0013;\n\tv16 = *([1EC65B0]);\n\tv17 = *([v16 @ X8_v10]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, success, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 0 | 1;\n\t*([202A1DD]) = v36;\nL_0013:\n\tv37 = &v7 @ stack_-10_v2 - 4;\n\tv39 = 0xE8F14C(v37, 0, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv46 = System.String::Concat(\"Transactions restored.\", v39);\n\tgoto L_002D;\n\tv54 = *([v50 @ X8_v8+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_002D;\n\tv63 = v50;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v63, v42, v43, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_002D:\n\tUnityEngine.Debug::Log(v46);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnTransactionsRestored(bool success)
	{
		//IL_002b: Expected O, but got I
		object obj2 = default(object);
		object obj = obj2;
		object obj3 = (long)(IntPtr)obj2 - 4L;
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E8F14C (inside System.BitConverter::.cctor +0x64)");
		string text = default(string);
		string message = "Transactions restored." + text;
		Debug.Log(message);
	}

	[Token(Token = "0x6000007")]
	[Address(RVA = "0x1609828", Offset = "0x1609828", Length = "0x9C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1F00918]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, item, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202A1DE]) = v38;\nL_0015:\n\tv40 = item.<definition>k__BackingField;\n\tv51 = System.String::Concat(\"Purchase deferred: \", v40.<id>k__BackingField);\n\tgoto L_0033;\n\tv78 = *([v55 @ X8_v9+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_0033;\n\tv83 = v55;\n\tv82 = \"il2cpp_codegen_runtime_class_init\"(v83, v46, v49, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0033:\n\tUnityEngine.Debug::Log(v51);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnDeferred(Product item)
	{
		ProductDefinition definition = item.definition;
		string message = "Purchase deferred: " + definition.id;
		Debug.Log(message);
	}

	[Token(Token = "0x6000008")]
	[Address(RVA = "0x1607ABC", Offset = "0x1607ABC", Length = "0x114")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EE9768]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, items, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A1DF]) = v40;\nL_0018:\n\tv44 = UnityEngine.Component::get_gameObject(this.restoreButton);\n\tUnityEngine.GameObject::SetActive(v44, 1);\n\tIAPDemo::ClearProductUIs(this);\n\tv95 = this.restoreButton;\n\tv101 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v101, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(v95.m_OnClick, v101);\n\tv111 = this.versionText;\n\tv120 = UnityEngine.Application::get_unityVersion();\n\tv109 = System.String::Concat(\"Unity version: \", v120, \"\\nIAP version: 1.23.1\");\n\tv89 = *([v111 @ X19_v4 (UnityEngine.UI.Text)]);\n\tv77 = *([v89 @ X8_v13 (Il2CppClass<UnityEngine.UI.Text>)+5C0]);\n\tv79 = *([v89 @ X8_v13 (Il2CppClass<UnityEngine.UI.Text>)+5C8]);\n\t// 79 IndirectJump v77 @ X3_v5, v111 @ X19_v4 (UnityEngine.UI.Text), v111 @ X19_v4 (UnityEngine.UI.Text), v109 @ X0_v16 (System.String), v79 @ X2_v7, v77 @ X3_v5, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\tv57 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void InitUI(IEnumerable<Product> items)
	{
		//IL_00a5: Expected I, but got O
		//IL_00b5: Expected O, but got I
		//IL_00c5: Expected O, but got I
		GameObject gameObject = restoreButton.gameObject;
		gameObject.SetActive(value: true);
		ClearProductUIs();
		Button button = restoreButton;
		UnityAction call = RestoreButtonClick;
		button.onClick.AddListener(call);
		Text text = versionText;
		string unityVersion = Application.unityVersion;
		string text2 = "Unity version: " + unityVersion + "\nIAP version: 1.23.1";
		IntPtr intPtr = (IntPtr)text;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ X8_v13 (Il2CppClass<UnityEngine.UI.Text>)+5C0]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ X8_v13 (Il2CppClass<UnityEngine.UI.Text>)+5C8]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v77 @ X3_v5 (should have been resolved before IL gen)");
	}

	[Token(Token = "0x6000009")]
	[Address(RVA = "0x1609A20", Offset = "0x1609A20", Length = "0x2A4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EC5580]);\n\tv25 = *([v24 @ X8_v40]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, productID, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202A1E0]) = v43;\nL_0017:\n\tv45 = ~this.m_PurchaseInProgress;\n\tif (v45) goto L_0033;\n\tgoto L_0030;\n\tv54 = *([v48 @ X0_v37+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_0030;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v48, productID, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0030:\n\tUnityEngine.Debug::Log(\"Please wait, purchase in progress\");\n\treturn;\nL_0033:\n\tv53 = this.m_Controller == 0;\n\tif (v53) goto L_0061;\n\tgoto L_0072;\n\tv83 = *([v72 @ X8_v12+B0]);\n\tv84 = 0;\n\tv85 = v83 + 8;\n\tv87 = *([v247 @ X11_v20-8]);\n\tv252 = v87 == v75;\n\tif (v252) goto L_006B;\n\tv117 = v246 + 1;\n\tv280 = v117 < v74;\n\tv114 = ~v280;\n\tv120 = v247 + 0x10;\n\tv90 = ~v114;\n\tif (v90) goto L_FFFFFFFF;\n\tv122 = v52;\n\tv123 = 0;\n\tv124 = 0x8909C4(v122, v75, v123, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_0072;\nL_0061:\n\tgoto L_FFFFFFFF;\n\tv125 = *([v79 @ X0_v3+E0]);\n\tv126 = v125 == 0;\n\tv127 = ~v126;\n\tif (v127) goto L_FFFFFFFF;\n\tv129 = \"il2cpp_codegen_runtime_class_init\"(v79, productID, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_00C0;\nL_006B:\n\tv281 = *([v247 @ X11_v20]);\n\tv282 = v281 << 4;\n\tv283 = v72 + v282;\n\tv284 = v283 + 0x130;\nL_0072:\n\tv292 = UnityEngine.Purchasing.IStoreController::get_products(this.m_Controller);\n\tv296 = UnityEngine.Purchasing.ProductCollection::WithID(v292, productID);\n\tv338 = v296 == 0;\n\tif (v338) goto L_00A8;\n\tv336 = this.m_Controller;\n\tthis.m_PurchaseInProgress = 1;\n\tgoto L_00C9;\n\tv356 = *([v347 @ X8_v23+B0]);\n\tv357 = 0;\n\tv358 = v356 + 8;\n\tv360 = *([v402 @ X11_v15-8]);\n\tv407 = v360 == v348;\n\tif (v407) goto L_00C2;\n\tv380 = v401 + 1;\n\tv413 = v380 < v349;\n\tv378 = ~v413;\n\tv382 = v402 + 0x10;\n\tv362 = ~v378;\n\tif (v362) goto L_FFFFFFFF;\n\tv383 = v336;\n\tv384 = 0;\n\tv385 = 0x8909C4(v383, v348, v384, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_00C9;\nL_00A8:\n\tv212 = System.String::Concat(\"No product has id \", productID);\n\tgoto L_00C0;\n\tv386 = *([v279 @ X8_v21+E0]);\n\tv387 = v386 == 0;\n\tv388 = ~v387;\n\t// 180 ConditionalJump @b33, v388 @ TEMP_v21\n\tv412 = v279;\n\tv390 = \"il2cpp_codegen_runtime_class_init\"(v412, v274, v259, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00C0:\n\tUnityEngine.Debug::LogError(v212);\n\treturn;\nL_00C2:\n\tv414 = *([v402 @ X11_v15]);\n\tv415 = v414 << 4;\n\tv416 = v347 + v415;\n\tv417 = v416 + 0x130;\nL_00C9:\n\tv330 = UnityEngine.Purchasing.IStoreController::get_products(this.m_Controller);\n\tv423 = UnityEngine.Purchasing.ProductCollection::WithID(v330, productID);\n\tv425 = *([v336 @ X20_v6 (UnityEngine.Purchasing.IStoreController)]);\n\tv217 = *([v425 @ X8_v26 (Il2CppClass<UnityEngine.Purchasing.IStoreController>)+126]) == 0;\n\tif (v217) goto L_00F5;\n\tv472 = *([v425 @ X8_v26 (Il2CppClass<UnityEngine.Purchasing.IStoreController>)+B0]) + 8;\nL_00E0:\n\tv477 = *([v472 @ X11_v10-8]) == UnityEngine.Purchasing.IStoreController;\n\tif (v477) goto L_00F8;\n\tv471 = v471 + 1;\n\tv482 = v471 < *([v425 @ X8_v26 (Il2CppClass<UnityEngine.Purchasing.IStoreController>)+126]);\n\tv453 = ~v482;\n\tv472 = v472 + 0x10;\n\tv437 = ~v453;\n\tif (v437) goto L_00E0;\nL_00F5:\n\tv489 = 0x8909C4(this.m_Controller, UnityEngine.Purchasing.IStoreController, 1, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_0108;\nL_00F8:\n\tv484 = *([v472 @ X11_v10]) + 1;\n\tv485 = v484 << 4;\n\tv486 = v425 + v485;\n\tv489 = v486 + 0x130;\nL_0108:\n\t// 264 IndirectJump [v489 @ X0_v26], this.m_Controller (UnityEngine.Purchasing.IStoreController), this.m_Controller (UnityEngine.Purchasing.IStoreController), v423 @ X0_v25 (UnityEngine.Purchasing.Product), \"developerPayload\", [v489 @ X0_v26+8], [v489 @ X0_v26], v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 162 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void PurchaseButtonClick(string productID)
	{
		//IL_00c9: Expected I, but got O
		//IL_0104: Expected O, but got I
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_01a8: Expected O, but got I
		//IL_01b7: Expected O, but got I
		//IL_0150: Expected O, but got I
		if (m_PurchaseInProgress)
		{
			Debug.Log("Please wait, purchase in progress");
			return;
		}
		string message;
		if (m_Controller == null)
		{
			message = "Purchasing is not initialized";
		}
		else
		{
			ProductCollection products = m_Controller.products;
			Product product = products.WithID(productID);
			if (product != null)
			{
				IStoreController controller = m_Controller;
				m_PurchaseInProgress = true;
				ProductCollection products2 = m_Controller.products;
				Product product2 = products2.WithID(productID);
				IntPtr intPtr = (IntPtr)controller;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ X8_v26 (Il2CppClass<UnityEngine.Purchasing.IStoreController>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0169;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ X8_v26 (Il2CppClass<UnityEngine.Purchasing.IStoreController>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ X11_v10-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IStoreController))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ X8_v26 (Il2CppClass<UnityEngine.Purchasing.IStoreController>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_0169;
				}
				object obj2 = obj + 1;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_0233;
			}
			message = "No product has id " + productID;
		}
		Debug.LogError(message);
		return;
		IL_0233:
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v489 @ X0_v26] (should have been resolved before IL gen)");
		return;
		IL_0169:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
		goto IL_0233;
	}

	[Token(Token = "0x600000A")]
	[Address(RVA = "0x1609CC4", Offset = "0x1609CC4", Length = "0x350")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EA4668]);\n\tv21 = *([v20 @ X8_v39]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A1E1]) = v40;\nL_0015:\n\tv42 = ~this.m_IsCloudMoolahStoreSelected;\n\tif (v42) goto L_004B;\n\tv44 = this.m_MoolahExtensions;\n\tv47 = new System.Action`1<UnityEngine.Purchasing.RestoreTransactionIDState>();\n\tSystem.Action`1<UnityEngine.Purchasing.RestoreTransactionIDState>::.ctor(v47, this, Il2CppMethodInfo);\n\tv84 = *([v44 @ X20_v13 (UnityEngine.Purchasing.IMoolahExtension)]);\n\tv88 = *([v84 @ X8_v36 (Il2CppClass<UnityEngine.Purchasing.IMoolahExtension>)+126]) == 0;\n\tif (v88) goto L_FFFFFFFF;\n\tv452 = *([v84 @ X8_v36 (Il2CppClass<UnityEngine.Purchasing.IMoolahExtension>)+B0]) + 8;\nL_0036:\n\tv269 = *([v452 @ X11_v4-8]) == UnityEngine.Purchasing.IMoolahExtension;\n\tif (v269) goto L_0116;\n\tv264 = v264 + 1;\n\tv423 = v264 < *([v84 @ X8_v36 (Il2CppClass<UnityEngine.Purchasing.IMoolahExtension>)+126]);\n\tv213 = ~v423;\n\tv452 = v452 + 0x10;\n\tv181 = ~v213;\n\tif (v181) goto L_0036;\n\tgoto L_FFFFFFFF;\nL_004B:\n\tv49 = ~this.m_IsSamsungAppsStoreSelected;\n\tif (v49) goto L_0084;\n\tv59 = this.m_SamsungExtensions;\n\tv62 = new System.Action`1<System.Boolean>();\n\tSystem.Action`1<System.Boolean>::.ctor(v62, this, Il2CppMethodInfo);\n\tv240 = *([v59 @ X20_v12 (UnityEngine.Purchasing.ISamsungAppsExtensions)]);\n\tv237 = *([v240 @ X8_v31 (Il2CppClass<UnityEngine.Purchasing.ISamsungAppsExtensions>)+126]) == 0;\n\tif (v237) goto L_FFFFFFFF;\n\tv452 = *([v240 @ X8_v31 (Il2CppClass<UnityEngine.Purchasing.ISamsungAppsExtensions>)+B0]) + 8;\nL_006C:\n\tv441 = *([v452 @ X11_v4-8]) == UnityEngine.Purchasing.ISamsungAppsExtensions;\n\tif (v441) goto L_0116;\n\tv456 = v456 + 1;\n\tv546 = v456 < *([v240 @ X8_v31 (Il2CppClass<UnityEngine.Purchasing.ISamsungAppsExtensions>)+126]);\n\tv212 = ~v546;\n\tv452 = v452 + 0x10;\n\tv180 = ~v212;\n\tif (v180) goto L_006C;\nL_0081:\n\tv544 = System.Action`1<System.Boolean>::.ctor(v306, v302, v299);\n\tgoto L_0119;\nL_0084:\n\tv64 = UnityEngine.Application::get_platform();\n\tv78 = v64 == 0x12;\n\tif (v78) goto L_00B1;\n\tv161 = UnityEngine.Application::get_platform();\n\tv166 = v161 == 0x13;\n\tif (v166) goto L_00B1;\n\tv170 = UnityEngine.Application::get_platform();\n\tv92 = v170 != 0x14;\n\tif (v92) goto L_00E0;\nL_00B1:\n\tgoto L_00DE;\n\tv393 = *([v248 @ X8_v12+B0]);\n\tv394 = 0;\n\tv395 = v393 + 8;\n\tv397 = *([v491 @ X11_v10-8]);\n\tv497 = v397 == v251;\n\tif (v497) goto L_00D1;\n\tv419 = v492 + 1;\n\tv549 = v419 < v250;\n\tv415 = ~v549;\n\tv417 = v491 + 0x10;\n\tv399 = ~v415;\n\tif (v399) goto L_FFFFFFFF;\n\tv420 = v151;\n\tv421 = 0;\n\tv422 = 0x8909C4(v420, v251, v421, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_00DE;\nL_00D1:\n\tv550 = *([v491 @ X11_v10]);\n\tv551 = v550 << 4;\n\tv552 = v248 + v551;\n\tv553 = v552 + 0x130;\nL_00DE:\n\tUnityEngine.Purchasing.IMicrosoftExtensions::RestoreTransactions(this.m_MicrosoftExtensions);\nL_00E0:\n\tv548 = ~this.m_IsGooglePlayStoreSelected;\n\tif (v548) goto L_0125;\n\tv156 = this.m_GooglePlayStoreExtensions;\n\tv143 = new System.Action`1<System.Boolean>();\n\tSystem.Action`1<System.Boolean>::.ctor(v143, this, Il2CppMethodInfo);\n\tv241 = *([v156 @ X20_v11 (UnityEngine.Purchasing.IGooglePlayStoreExtensions)]);\n\tv238 = *([v241 @ X8_v26 (Il2CppClass<UnityEngine.Purchasing.IGooglePlayStoreExtensions>)+126]) == 0;\n\tif (v238) goto L_FFFFFFFF;\n\tv452 = *([v241 @ X8_v26 (Il2CppClass<UnityEngine.Purchasing.IGooglePlayStoreExtensions>)+B0]) + 8;\nL_0101:\n\tv442 = *([v452 @ X11_v4-8]) == UnityEngine.Purchasing.IGooglePlayStoreExtensions;\n\tif (v442) goto L_0116;\n\tv457 = v457 + 1;\n\tv606 = v457 < *([v241 @ X8_v26 (Il2CppClass<UnityEngine.Purchasing.IGooglePlayStoreExtensions>)+126]);\n\tv214 = ~v606;\n\tv452 = v452 + 0x10;\n\tv182 = ~v214;\n\tif (v182) goto L_0101;\n\tgoto L_FFFFFFFF;\nL_0116:\n\tv468 = *([v452 @ X11_v4]) << 4;\n\tv536 = v84 + v468;\nL_0118:\n\tv544 = v536 + 0x130;\nL_0119:\n\tv359 = *([v544 @ X0_v6 (System.Action`1<System.Boolean>)]);\n\tv362 = *([v544 @ X0_v6 (System.Action`1<System.Boolean>)+8]);\n\t// 291 IndirectJump v359 @ X3_v4 (Il2CppClass<System.Action`1<System.Boolean>>), v545 @ X20_v4 (UnityEngine.Purchasing.IAppleExtensions), v545 @ X20_v4 (UnityEngine.Purchasing.IAppleExtensions), v542 @ X21_v3 (System.Action`1<System.Boolean>), v362 @ X2_v4, v359 @ X3_v4 (Il2CppClass<System.Action`1<System.Boolean>>), v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\nL_0125:\n\tv545 = this.m_AppleExtensions;\n\tv144 = new System.Action`1<System.Boolean>();\n\tSystem.Action`1<System.Boolean>::.ctor(v144, this, Il2CppMethodInfo);\n\tv311 = *([v545 @ X20_v4 (UnityEngine.Purchasing.IAppleExtensions)]);\n\tv309 = *([v311 @ X8_v20 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+126]) == 0;\n\tif (v309) goto L_FFFFFFFF;\n\tv525 = *([v311 @ X8_v20 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+B0]) + 8;\nL_0143:\n\tv517 = *([v525 @ X11_v15-8]) == UnityEngine.Purchasing.IAppleExtensions;\n\tif (v517) goto L_015A;\n\tv527 = v527 + 1;\n\tv607 = v527 < *([v311 @ X8_v20 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+126]);\n\tv583 = ~v607;\n\tv525 = v525 + 0x10;\n\tv575 = ~v583;\n\tif (v575) goto L_0143;\n\tgoto L_0081;\nL_015A:\n\tv533 = *([v525 @ X11_v15]) + 1;\n\tv505 = v533 << 4;\n\tv536 = v311 + v505;\n\tgoto L_0118;\n\tthrow System.NullReferenceException;\n\treturn;\n// 233 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void RestoreButtonClick()
	{
		//IL_002d: Expected I, but got O
		//IL_0053: Expected I, but got O
		//IL_0143: Expected I, but got O
		//IL_0169: Expected I, but got O
		//IL_007f: Expected O, but got I
		//IL_0195: Expected O, but got I
		//IL_0585: Expected I, but got O
		//IL_0595: Expected O, but got I
		//IL_03c6: Expected I4, but got O
		//IL_03d4: Expected O, but got I
		//IL_0623: Expected O, but got I
		//IL_00cb: Expected O, but got I
		//IL_0401: Expected I, but got O
		//IL_01e1: Expected O, but got I
		//IL_01fb: Expected I, but got O
		//IL_04b9: Expected I, but got O
		//IL_02e5: Expected I, but got O
		//IL_030b: Expected I, but got O
		//IL_00f3: Expected I, but got O
		//IL_043c: Expected O, but got I
		//IL_0337: Expected O, but got I
		//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d4: Expected O, but got Unknown
		//IL_04f1: Expected O, but got I
		//IL_0488: Expected O, but got I
		//IL_0383: Expected O, but got I
		//IL_03ab: Expected I, but got O
		IMoolahExtension moolahExtensions;
		IntPtr intPtr;
		object obj;
		IGooglePlayStoreExtensions googlePlayStoreExtensions;
		object obj4;
		IAppleExtensions appleExtensions;
		IntPtr intPtr2;
		if (m_IsCloudMoolahStoreSelected)
		{
			moolahExtensions = m_MoolahExtensions;
			Action<RestoreTransactionIDState> action = delegate(RestoreTransactionIDState restoreTransactionIDState)
			{
				//IL_0058: Unknown result type (might be due to invalid IL or missing references)
				//IL_005d: Expected I4, but got Unknown
				object obj6 = restoreTransactionIDState;
				object obj7 = obj6;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v46 @ X8_v5+160] (should have been resolved before IL gen)");
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				string text2 = default(string);
				string text = "restoreTransactionIDState = " + text2;
				Debug.Log(text);
				object obj8 = default(object);
				int num11 = (int)(obj8 & 0xFFFFFFFEL);
				int num12 = num11 - 2;
				bool flag16 = num12 == 0;
				bool success = !flag16;
				((IAPDemo)(object)text).OnTransactionsRestored(success);
			};
			intPtr = (IntPtr)moolahExtensions;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ X8_v36 (Il2CppClass<UnityEngine.Purchasing.IMoolahExtension>)+126]");
			bool flag = (IntPtr)0 == (IntPtr)0;
			intPtr2 = (IntPtr)typeof(IMoolahExtension);
			appleExtensions = (IAppleExtensions)moolahExtensions;
			if (flag)
			{
				goto IL_0211;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ X8_v36 (Il2CppClass<UnityEngine.Purchasing.IMoolahExtension>)+B0]");
			obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ X11_v4-8]");
				bool flag2 = (IntPtr)0 == (IntPtr)typeof(IMoolahExtension);
				appleExtensions = (IAppleExtensions)moolahExtensions;
				if (flag2)
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ X8_v36 (Il2CppClass<UnityEngine.Purchasing.IMoolahExtension>)+126]");
				bool flag3 = (long)num2 < 0L;
				bool flag4 = !flag3;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag4)
				{
					continue;
				}
				goto IL_00e4;
			}
		}
		else
		{
			if (!m_IsSamsungAppsStoreSelected)
			{
				RuntimePlatform platform = Application.platform;
				if (platform != RuntimePlatform.MetroPlayerX86)
				{
					RuntimePlatform platform2 = Application.platform;
					if (platform2 != RuntimePlatform.MetroPlayerX64)
					{
						RuntimePlatform platform3 = Application.platform;
						if (platform3 != RuntimePlatform.MetroPlayerARM)
						{
							if (m_IsGooglePlayStoreSelected)
							{
								googlePlayStoreExtensions = m_GooglePlayStoreExtensions;
								Action<bool> action2 = OnTransactionsRestored;
								IntPtr intPtr3 = (IntPtr)googlePlayStoreExtensions;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ X8_v26 (Il2CppClass<UnityEngine.Purchasing.IGooglePlayStoreExtensions>)+126]");
								bool flag5 = (IntPtr)0 == (IntPtr)0;
								intPtr2 = (IntPtr)typeof(IGooglePlayStoreExtensions);
								appleExtensions = (IAppleExtensions)googlePlayStoreExtensions;
								if (flag5)
								{
									goto IL_0211;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ X8_v26 (Il2CppClass<UnityEngine.Purchasing.IGooglePlayStoreExtensions>)+B0]");
								obj = 0L + 8L;
								int num3 = 0;
								while (true)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ X11_v4-8]");
									bool flag6 = (IntPtr)0 == (IntPtr)typeof(IGooglePlayStoreExtensions);
									intPtr = intPtr3;
									appleExtensions = (IAppleExtensions)googlePlayStoreExtensions;
									if (flag6)
									{
										break;
									}
									num3++;
									int num4 = num3;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ X8_v26 (Il2CppClass<UnityEngine.Purchasing.IGooglePlayStoreExtensions>)+126]");
									bool flag7 = (long)num4 < 0L;
									bool flag8 = !flag7;
									obj = (long)(IntPtr)obj + 16L;
									if (!flag8)
									{
										continue;
									}
									goto IL_039c;
								}
								goto IL_03b8;
							}
							appleExtensions = m_AppleExtensions;
							Action<bool> action3 = OnTransactionsRestored;
							IntPtr intPtr4 = (IntPtr)appleExtensions;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ X8_v20 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+126]");
							if ((IntPtr)0 == (IntPtr)0)
							{
								goto IL_04a1;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ X8_v20 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+B0]");
							object obj2 = 0L + 8L;
							int num5 = 0;
							while (true)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ X11_v15-8]");
								if ((IntPtr)0 == (IntPtr)typeof(IAppleExtensions))
								{
									break;
								}
								num5++;
								int num6 = num5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ X8_v20 (Il2CppClass<UnityEngine.Purchasing.IAppleExtensions>)+126]");
								bool flag9 = (long)num6 < 0L;
								bool flag10 = !flag9;
								obj2 = (long)(IntPtr)obj2 + 16L;
								if (!flag10)
								{
									continue;
								}
								goto IL_04a1;
							}
							object obj3 = obj2 + 1;
							int num7 = (int)((long)(IntPtr)obj3 << 4);
							obj4 = (long)intPtr4 + (long)num7;
							goto IL_0614;
						}
					}
				}
				goto IL_059f;
			}
			ISamsungAppsExtensions samsungExtensions = m_SamsungExtensions;
			Action<bool> action4 = OnTransactionsRestored;
			IntPtr intPtr5 = (IntPtr)samsungExtensions;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ X8_v31 (Il2CppClass<UnityEngine.Purchasing.ISamsungAppsExtensions>)+126]");
			bool flag11 = (IntPtr)0 == (IntPtr)0;
			intPtr2 = (IntPtr)typeof(ISamsungAppsExtensions);
			appleExtensions = (IAppleExtensions)samsungExtensions;
			if (flag11)
			{
				goto IL_0211;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ X8_v31 (Il2CppClass<UnityEngine.Purchasing.ISamsungAppsExtensions>)+B0]");
			obj = 0L + 8L;
			int num8 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ X11_v4-8]");
				bool flag12 = (IntPtr)0 == (IntPtr)typeof(ISamsungAppsExtensions);
				intPtr = intPtr5;
				appleExtensions = (IAppleExtensions)samsungExtensions;
				if (flag12)
				{
					break;
				}
				num8++;
				int num9 = num8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ X8_v31 (Il2CppClass<UnityEngine.Purchasing.ISamsungAppsExtensions>)+126]");
				bool flag13 = (long)num9 < 0L;
				bool flag14 = !flag13;
				obj = (long)(IntPtr)obj + 16L;
				bool flag15 = !flag14;
				intPtr2 = (IntPtr)typeof(ISamsungAppsExtensions);
				appleExtensions = (IAppleExtensions)samsungExtensions;
				if (flag15)
				{
					continue;
				}
				goto IL_0211;
			}
		}
		goto IL_03b8;
		IL_059f:
		m_MicrosoftExtensions.RestoreTransactions();
		return;
		IL_0211:
		IntPtr intPtr6 = default(IntPtr);
		Action<bool> action5 = (Action<bool>)(object)appleExtensions;
		goto IL_057d;
		IL_04a1:
		intPtr6 = (IntPtr)1;
		intPtr2 = (IntPtr)typeof(IAppleExtensions);
		action5 = (Action<bool>)(object)appleExtensions;
		goto IL_057d;
		IL_057d:
		Action<bool> action6 = default(Action<bool>);
		IntPtr intPtr7 = (IntPtr)action6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v544 @ X0_v6 (System.Action`1<System.Boolean>)+8]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v359 @ X3_v4 (Il2CppClass<System.Action`1<System.Boolean>>) (should have been resolved before IL gen)");
		goto IL_059f;
		IL_039c:
		intPtr2 = (IntPtr)typeof(IGooglePlayStoreExtensions);
		appleExtensions = (IAppleExtensions)googlePlayStoreExtensions;
		goto IL_0211;
		IL_00e4:
		intPtr2 = (IntPtr)typeof(IMoolahExtension);
		appleExtensions = (IAppleExtensions)moolahExtensions;
		goto IL_0211;
		IL_03b8:
		int num10 = obj << 4;
		obj4 = (long)intPtr + (long)num10;
		goto IL_0614;
		IL_0614:
		action6 = (Action<bool>)((long)(IntPtr)obj4 + 304L);
		goto IL_057d;
	}

	[Token(Token = "0x600000B")]
	[Address(RVA = "0x16098C4", Offset = "0x16098C4", Length = "0x15C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EF4D10]);\n\tv23 = *([v22 @ X8_v22]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202A1E2]) = v42;\nL_0018:\n\tv46 = 0;\n\tv53 = System.Collections.Generic.Dictionary`2<System.String, IAPDemoProductUI>::GetEnumerator(this.m_ProductUIs);\nL_0027:\n\tv138 = System.Collections.Generic.Dictionary`2<System.String, IAPDemoProductUI>+Enumerator<System.String, IAPDemoProductUI>::MoveNext(&v46 @ stack_-58_v1 (System.Collections.Generic.Dictionary`2<System.String, IAPDemoProductUI>+Enumerator<System.String, IAPDemoProductUI>));\n\tv165 = v138 == 0;\n\tif (v165) goto L_0043;\n\tv123 = v167 == 0;\n\tif (v123) goto L_0045;\n\tv202 = UnityEngine.Component::get_gameObject(v167);\n\tgoto L_003D;\n\tv209 = *([v203 @ X0_v25+E0]);\n\tv210 = v209 == 0;\n\tv211 = ~v210;\n\tif (v211) goto L_003D;\n\tv213 = \"il2cpp_codegen_runtime_class_init\"(v203, v201, v26, v27, v28, v29, v30, v31, v43, v33, v34, v35, v36, v37, v38, v39);\nL_003D:\n\tUnityEngine.Object::Destroy(v202);\n\tgoto L_0027;\nL_0043:\n\tv172 = System.Collections.Generic.Dictionary`2<System.String, IAPDemoProductUI>+Enumerator<System.String, IAPDemoProductUI>::Dispose(&v46 @ stack_-58_v1 (System.Collections.Generic.Dictionary`2<System.String, IAPDemoProductUI>+Enumerator<System.String, IAPDemoProductUI>));\n\tgoto L_0065;\nL_0045:\n\tv121 = new System.NullReferenceException();\n\tgoto L_0052;\n\tgoto L_0052;\n\tgoto L_0052;\nL_0052:\n\tv99 = Il2CppMethodInfo != 1;\n\tif (v99) goto L_006F;\n\tv216 = System.Collections.Generic.Dictionary`2<System.String, IAPDemoProductUI>+Enumerator<System.String, IAPDemoProductUI>::MoveNext(v121);\n\tv217 = System.Collections.Generic.Dictionary`2<System.String, IAPDemoProductUI>+Enumerator<System.String, IAPDemoProductUI>::MoveNext(v216);\n\tv153 = System.Collections.Generic.Dictionary`2<System.String, IAPDemoProductUI>+Enumerator<System.String, IAPDemoProductUI>::Dispose(&v46 @ stack_-58_v1 (System.Collections.Generic.Dictionary`2<System.String, IAPDemoProductUI>+Enumerator<System.String, IAPDemoProductUI>));\n\tv220 = ~v216.m_value;\n\tv155 = ~v220;\n\tif (v155) goto L_0073;\nL_0065:\n\tSystem.Collections.Generic.Dictionary`2<System.String, IAPDemoProductUI>::Clear(this.m_ProductUIs);\n\treturn;\n\tv95 = new System.NullReferenceException();\nL_006F:\n\tv128 = System.Collections.Generic.Dictionary`2<System.String, IAPDemoProductUI>+Enumerator<System.String, IAPDemoProductUI>::MoveNext(v120);\nL_0073:\n\tthrow System.TypeLoadException;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private unsafe void ClearProductUIs()
	{
		Dictionary<string, IAPDemoProductUI>.Enumerator enumerator = default(Dictionary<string, IAPDemoProductUI>.Enumerator);
		Dictionary<string, IAPDemoProductUI>.Enumerator enumerator2 = m_ProductUIs.GetEnumerator();
		Component component = default(Component);
		NullReferenceException ex2 = default(NullReferenceException);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if ((object)component != null)
				{
					GameObject obj = component.gameObject;
					UnityEngine.Object.Destroy(obj);
					continue;
				}
				NullReferenceException ex = new NullReferenceException();
				if ((IntPtr)0 != (IntPtr)1)
				{
					bool flag = ((Dictionary<string, IAPDemoProductUI>.Enumerator*)ex2)->MoveNext();
					break;
				}
				bool flag2 = ((Dictionary<string, IAPDemoProductUI>.Enumerator*)ex)->MoveNext();
				bool flag3 = (flag2 ? ((Dictionary<string, IAPDemoProductUI>.Enumerator*)1) : ((Dictionary<string, IAPDemoProductUI>.Enumerator*)null))->MoveNext();
				enumerator.Dispose();
				if (((bool*)(flag2 ? 1 : 0))->m_value)
				{
					break;
				}
			}
			else
			{
				enumerator.Dispose();
			}
			m_ProductUIs.Clear();
			return;
		}
		throw new TypeLoadException();
	}

	[Token(Token = "0x600000C")]
	[Address(RVA = "0x1607BD0", Offset = "0x1607BD0", Length = "0x31C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv44 = *([1EB2970]);\n\tv45 = *([v44 @ X8_v32]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, products, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\tv63 = 0 | 1;\n\t*([202A1E3]) = v63;\nL_0023:\n\tIAPDemo::ClearProductUIs(this);\n\tv72 = UnityEngine.GameObject::GetComponent(this.productUITemplate);\n\tv292 = UnityEngine.RectTransform::get_rect(v72);\n\tv343 = 0x10CD188(&v292 @ V0_v4 (UnityEngine.Rect), 0, methodInfo, v48, v49, v50, v51, v52, v292, v292.m_YMin, v292.m_Width, v292.m_Height, v57, v58, v59, v60);\n\tv193 = UnityEngine.Transform::get_localPosition(v72);\n\tv292 = products.Length;\n\tv441 = products.Length * products.Length;\n\tUnityEngine.RectTransform::SetSizeWithCurrentAnchors(this.contentRect, 1, v441);\n\tv219 = products.Length;\n\tv453 = products.Length < 1;\n\tif (v453) goto L_0117;\nL_0065:\n\tv492 = v116 < v219;\n\tv151 = ~v492;\n\tif (v151) goto L_011B;\n\tv227 = products[v116 @ X25_v7 (System.Int32)];\n\tv495 = UnityEngine.GameObject::get_gameObject(this.productUITemplate);\n\tgoto L_0089;\n\tv503 = *([v499 @ X8_v14+E0]);\n\tv504 = v503 == 0;\n\tv505 = ~v504;\n\tif (v505) goto L_0089;\n\tv511 = v499;\n\tv507 = \"il2cpp_codegen_runtime_class_init\"(v511, v494, v153, v96, v49, v50, v51, v52, v194, v190, v186, v182, v85, v82, v59, v60);\nL_0089:\n\tv206 = UnityEngine.Object::Instantiate(v495);\n\tv274 = UnityEngine.GameObject::get_transform(v206);\n\tv207 = UnityEngine.GameObject::get_transform(this.productUITemplate);\n\tv275 = UnityEngine.Transform::get_parent(v207);\n\tUnityEngine.Transform::SetParent(v274, v275, 0);\n\tv208 = UnityEngine.GameObject::GetComponent(v206);\n\t// 173 MakeStruct v94 @ AGG1607DB4_1_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v166 @ V9_v7 (UnityEngine.Vector3), v162 @ V10_v7 (System.Single), v158 @ V11_v7 (System.Single)\n\tUnityEngine.Transform::set_localPosition(v208, v94);\n\tgoto L_00BC;\n\tv528 = *([v524 @ X0_v33+E0]);\n\tv529 = v528 == 0;\n\tv530 = ~v529;\n\tif (v530) goto L_00BC;\n\tv532 = \"il2cpp_codegen_runtime_class_init\"(v524, v521, v154, v97, v49, v50, v51, v52, v518, v519, v520, v182, v85, v82, v59, v60);\nL_00BC:\n\tv536 = UnityEngine.Vector3::get_down();\n\tv541 = UnityEngine.Vector3::op_Multiply(v536, v292);\n\t// 204 MakeStruct v80 @ AGG1607E08_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v166 @ V9_v7 (UnityEngine.Vector3), v162 @ V10_v7 (System.Single), v158 @ V11_v7 (System.Single)\n\tv195 = UnityEngine.Vector3::op_Addition(v80, v541);\n\tUnityEngine.GameObject::SetActive(v206, 1);\n\tv555 = UnityEngine.GameObject::GetComponent(v206);\n\tv276 = new System.Action`1<System.String>();\n\tSystem.Action`1<System.String>::.ctor(v276, this, Il2CppMethodInfo);\n\tIAPDemoProductUI::SetProduct(v555, products[v116 @ X25_v7 (System.Int32)], v276);\n\tv223 = v227.<definition>k__BackingField;\n\tSystem.Collections.Generic.Dictionary`2<System.String, IAPDemoProductUI>::set_Item(this.m_ProductUIs, v223.<id>k__BackingField, v555);\n\tv219 = products.Length;\n\tv116 = v116 + 1;\n\tv468 = v116 < products.Length;\n\tif (v468) goto L_0065;\nL_0117:\n\treturn;\n\tthrow System.NullReferenceException;\n\tv289 = new System.NullReferenceException();\nL_011B:\n\tv338 = new System.IndexOutOfRangeException();\n\tthrow v338;\n\treturn;\n// 224 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void AddProductUIs(Product[] products)
	{
		//IL_0056: Expected O, but got I4
		ClearProductUIs();
		RectTransform component = productUITemplate.GetComponent<RectTransform>();
		Rect rect = component.rect;
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
		Vector3 localPosition = component.localPosition;
		rect = (Rect)products.Length;
		float size = (float)products.Length * (float)products.Length;
		contentRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size);
		int num = products.Length;
		if (products.Length < 1)
		{
			return;
		}
		int num2 = 0;
		float z = localPosition.z;
		float y = localPosition.y;
		Vector3 vector = localPosition;
		Vector3 localPosition2 = default(Vector3);
		Vector3 vector3 = default(Vector3);
		while (num2 < num)
		{
			Product product = products[num2];
			GameObject original = productUITemplate.gameObject;
			GameObject gameObject = UnityEngine.Object.Instantiate(original);
			Transform transform = gameObject.transform;
			Transform transform2 = productUITemplate.transform;
			Transform parent = transform2.parent;
			transform.SetParent(parent, worldPositionStays: false);
			RectTransform component2 = gameObject.GetComponent<RectTransform>();
			localPosition2.x = vector.x;
			localPosition2.y = y;
			localPosition2.z = z;
			component2.localPosition = localPosition2;
			Vector3 down = Vector3.down;
			Vector3 vector2 = down * rect.x;
			vector3.x = vector.x;
			vector3.y = y;
			vector3.z = z;
			Vector3 vector4 = vector3 + vector2;
			gameObject.SetActive(value: true);
			IAPDemoProductUI component3 = gameObject.GetComponent<IAPDemoProductUI>();
			Action<string> purchaseCallback = PurchaseButtonClick;
			component3.SetProduct(products[num2], purchaseCallback);
			ProductDefinition definition = product.definition;
			m_ProductUIs.set_Item(definition.id, component3);
			num = products.Length;
			num2++;
			bool flag = num2 < products.Length;
			z = vector4.z;
			y = vector4.y;
			vector = vector4;
			if (!flag)
			{
				return;
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		throw ex;
	}

	[Token(Token = "0x600000D")]
	[Address(RVA = "0x16082B0", Offset = "0x16082B0", Length = "0x100")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EBEF20]);\n\tv25 = *([v24 @ X8_v18]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, p, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202A1E4]) = v43;\nL_0018:\n\tv45 = p.<definition>k__BackingField;\n\tv61 = System.Collections.Generic.Dictionary`2<System.String, IAPDemoProductUI>::ContainsKey(this.m_ProductUIs, v45.<id>k__BackingField);\n\tv89 = v61 == 0;\n\tif (v89) goto L_0055;\n\tv67 = p.<definition>k__BackingField;\n\tv122 = System.Collections.Generic.Dictionary`2<System.String, IAPDemoProductUI>::get_Item(this.m_ProductUIs, v67.<id>k__BackingField);\n\tv62 = new System.Action`1<System.String>();\n\tSystem.Action`1<System.String>::.ctor(v62, this, Il2CppMethodInfo);\n\tIAPDemoProductUI::SetProduct(v122, p, v62);\n\treturn;\nL_0055:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void UpdateProductUI(Product p)
	{
		ProductDefinition definition = p.definition;
		if (m_ProductUIs.ContainsKey(definition.id))
		{
			ProductDefinition definition2 = p.definition;
			IAPDemoProductUI iAPDemoProductUI = m_ProductUIs.get_Item(definition2.id);
			Action<string> purchaseCallback = PurchaseButtonClick;
			iAPDemoProductUI.SetProduct(p, purchaseCallback);
		}
	}

	[Token(Token = "0x600000E")]
	[Address(RVA = "0x160A14C", Offset = "0x160A14C", Length = "0xC0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EC6E28]);\n\tv27 = *([v26 @ X8_v13]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, p, secondsRemaining, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202A1E5]) = v44;\nL_0019:\n\tv46 = p.<definition>k__BackingField;\n\tv53 = System.Collections.Generic.Dictionary`2<System.String, IAPDemoProductUI>::ContainsKey(this.m_ProductUIs, v46.<id>k__BackingField);\n\tv77 = v53 == 0;\n\tif (v77) goto L_0045;\n\tv57 = p.<definition>k__BackingField;\n\tv67 = System.Collections.Generic.Dictionary`2<System.String, IAPDemoProductUI>::get_Item(this.m_ProductUIs, v57.<id>k__BackingField);\n\tIAPDemoProductUI::SetPendingTime(v67, secondsRemaining);\n\treturn;\nL_0045:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void UpdateProductPendingUI(Product p, int secondsRemaining)
	{
		ProductDefinition definition = p.definition;
		if (m_ProductUIs.ContainsKey(definition.id))
		{
			ProductDefinition definition2 = p.definition;
			IAPDemoProductUI iAPDemoProductUI = m_ProductUIs.get_Item(definition2.id);
			iAPDemoProductUI.SetPendingTime(secondsRemaining);
		}
	}

	[Token(Token = "0x600000F")]
	[Address(RVA = "0x160A2A8", Offset = "0x160A2A8", Length = "0x9C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Application::get_platform();\n\tv21 = v11 != 8;\n\tif (v21) goto L_0016;\n\tgoto L_0026;\nL_0016:\n\tv77 = UnityEngine.Application::get_platform();\n\tv29 = v77 != 1;\n\tif (v29) goto L_0028;\nL_0026:\n\treturn returnVal1;\nL_0028:\n\tv71 = UnityEngine.Application::get_platform();\n\tv51 = v71 == 0x1F;\n\tif (v51) goto L_FFFFFFFF;\n\tv72 = UnityEngine.Application::get_platform();\n\tv52 = v72 == 0x12;\n\tif (v52) goto L_FFFFFFFF;\n\tv73 = UnityEngine.Application::get_platform();\n\tv53 = v73 == 0x13;\n\tif (v53) goto L_FFFFFFFF;\n\tv74 = UnityEngine.Application::get_platform();\n\tv54 = v74 == 0x14;\n\tif (v54) goto L_FFFFFFFF;\n\tv121 = ~this.m_IsSamsungAppsStoreSelected;\n\tv24 = ~v121;\n\tif (v24) goto L_FFFFFFFF;\n\tv97 = this.m_IsCloudMoolahStoreSelected == 0;\n\tv82 = ~v97;\n\tgoto L_0026;\n\treturn X0;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private bool NeedRestoreButton()
	{
		RuntimePlatform platform = Application.platform;
		bool result;
		if (platform != RuntimePlatform.IPhonePlayer)
		{
			RuntimePlatform platform2 = Application.platform;
			bool flag = platform2 != RuntimePlatform.OSXPlayer;
			result = (byte)platform2 != 0;
			if (!flag)
			{
				goto IL_0068;
			}
			RuntimePlatform platform3 = Application.platform;
			if (platform3 != RuntimePlatform.tvOS)
			{
				RuntimePlatform platform4 = Application.platform;
				if (platform4 != RuntimePlatform.MetroPlayerX86)
				{
					RuntimePlatform platform5 = Application.platform;
					if (platform5 != RuntimePlatform.MetroPlayerX64)
					{
						RuntimePlatform platform6 = Application.platform;
						if (platform6 != RuntimePlatform.MetroPlayerARM && !m_IsSamsungAppsStoreSelected)
						{
							bool flag2 = !m_IsCloudMoolahStoreSelected;
							bool flag3 = !flag2;
							result = flag3;
							goto IL_0068;
						}
					}
				}
			}
		}
		result = true;
		goto IL_0068;
		IL_0068:
		return result;
	}

	[Token(Token = "0x6000010")]
	[Address(RVA = "0x1607EEC", Offset = "0x1607EEC", Length = "0x2D4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv34 = *([1EAAF00]);\n\tv35 = *([v34 @ X8_v39]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([202A1E6]) = v54;\nL_0025:\n\tgoto L_004C;\n\tv198 = *([v59 @ X8_v7+B0]);\n\tv199 = 0;\n\tv200 = v198 + 8;\n\tv202 = *([v277 @ X11_v9-8]);\n\tv283 = v202 == v62;\n\tif (v283) goto L_0045;\n\tv224 = v278 + 1;\n\tv349 = v224 < v61;\n\tv220 = ~v349;\n\tv222 = v277 + 0x10;\n\tv204 = ~v220;\n\tif (v204) goto L_FFFFFFFF;\n\tv225 = v56;\n\tv226 = 0;\n\tv227 = 0x8909C4(v225, v62, v226, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_004C;\nL_0045:\n\tv350 = *([v277 @ X11_v9]);\n\tv351 = v350 << 4;\n\tv352 = v59 + v351;\n\tv353 = v352 + 0x130;\nL_004C:\n\tv170 = UnityEngine.Purchasing.IStoreController::get_products(this.m_Controller);\n\tv89 = v170.m_Products;\n\tv409 = v89.Length;\n\tv420 = v89.Length < 1;\n\tif (v420) goto L_0130;\nL_0068:\n\tv523 = v79 < v409;\n\tv147 = ~v523;\n\tif (v147) goto L_0133;\n\tv77 = v89[v79 @ X23_v8 (System.Int32)];\n\t// 121 NewArr v171 @ X0_v16 (System.Object[]), typeof(System.Object[]), 4\n\tv188 = v77.<definition>k__BackingField;\n\tv527 = v188.<id>k__BackingField == 0;\n\tif (v527) goto L_008B;\n\t// 136 IsInst v531 @ X0_v42, typeof(System.Object), v188.<id>k__BackingField (System.String)\nL_008B:\n\tv409 = v171.Length;\n\tv336 = v171.Length == 0;\n\tif (v336) goto L_0133;\n\tv171[0] = v188.<id>k__BackingField;\n\tv163 = v77.<definition>k__BackingField;\n\tv557 = v163.<storeSpecificId>k__BackingField == 0;\n\tif (v557) goto L_009C;\n\t// 152 IsInst v548 @ X0_v40, typeof(System.Object), v163.<storeSpecificId>k__BackingField (System.String)\n\tv409 = v171.Length;\nL_009C:\n\tv560 = v409 < 1;\n\tv148 = ~v560;\n\tv142 = v409 - 1;\n\tv130 = v142 == 0;\n\tv561 = ~v148;\n\tv100 = v561 | v130;\n\tif (v100) goto L_0133;\n\tv171[1] = v163.<storeSpecificId>k__BackingField;\n\tv190 = v77.<definition>k__BackingField;\n\tv264 = v190.<type>k__BackingField;\n\t// 178 Box v258 @ X0_v22, typeof(UnityEngine.Purchasing.ProductType), &v264 @ X8_v22 (UnityEngine.Purchasing.ProductType)\n\tv409 = *([v258 @ X0_v22]);\n\t*([v409 @ X8_v10 (System.Int32)+160])(v567, v258, *([v409 @ X8_v10 (System.Int32)+168]), v96, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv569 = \"il2cpp_vm_object_unbox\"(v258, *([v409 @ X8_v10 (System.Int32)+168]), v96, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv571 = v567 == 0;\n\tif (v571) goto L_00C8;\n\t// 197 IsInst v549 @ X0_v38, typeof(System.Object), v567 @ X0_v24\nL_00C8:\n\tv409 = v171.Length;\n\tv574 = v171.Length < 2;\n\tv149 = ~v574;\n\tv143 = v171.Length - 2;\n\tv131 = v143 == 0;\n\tv575 = ~v149;\n\tv101 = v575 | v131;\n\tif (v101) goto L_0133;\n\tv171[2] = v567;\n\tv164 = v77.<definition>k__BackingField;\n\tv540 = v164.<enabled>k__BackingField == 0;\n\tv535 = ~v540;\n\tv290 = ~v535;\n\tif (v290) goto L_FFFFFFFF;\n\tgoto L_00EC;\nL_00EC:\n\tv580 = *([v329 @ X9_v16 (System.String)]) == 0;\n\tif (v580) goto L_00F5;\n\t// 241 IsInst v550 @ X0_v36, typeof(System.Object), [v329 @ X9_v16 (System.String)]\n\tv409 = v171.Length;\nL_00F5:\n\tv583 = v409 < 3;\n\tv322 = ~v583;\n\tv320 = v409 - 3;\n\tv316 = v320 == 0;\n\tv584 = ~v322;\n\tv306 = v584 | v316;\n\tif (v306) goto L_0133;\n\tv171[3] = *([v329 @ X9_v16 (System.String)]);\n\tv587 = System.String::Format(\"id: {0}\\nstore-specific id: {1}\\ntype: {2}\\nenabled: {3}\\n\", v171);\n\tgoto L_0114;\n\tv592 = *([v588 @ X8_v28+E0]);\n\tv593 = v592 == 0;\n\tv594 = ~v593;\n\tif (v594) goto L_0114;\n\tv597 = v588;\n\tv596 = \"il2cpp_codegen_runtime_class_init\"(v597, v586, v438, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0114:\n\tUnityEngine.Debug::Log(v587);\n\tv409 = v89.Length;\n\tv79 = v79 + 1;\n\tv440 = v79 < v89.Length;\n\tif (v440) goto L_0068;\nL_0130:\n\treturn;\n\tv266 = new System.NullReferenceException();\nL_0133:\n\tv348 = new System.IndexOutOfRangeException();\n\tgoto L_0138;\n\tv398 = new System.ArrayTypeMismatchException();\nL_0138:\n\tthrow v397;\n// 201 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void LogProductDefinitions()
	{
		//IL_03c2: Expected O, but got I4
		//IL_01b5: Expected I4, but got O
		//IL_0233: Expected O, but got I4
		//IL_0463: Expected O, but got I4
		ProductCollection products = m_Controller.products;
		Product[] all = products.all;
		int num = all.Length;
		if (all.Length < 1)
		{
			return;
		}
		int num2 = 0;
		int num3 = 0;
		object obj5 = default(object);
		while (num2 < num)
		{
			Product product = all[num2];
			object[] array = new object[4];
			ProductDefinition definition = product.definition;
			if (definition.id != null)
			{
				object obj = definition.id as object;
			}
			num = array.Length;
			if (array.Length == 0)
			{
				break;
			}
			array[0] = definition.id;
			ProductDefinition definition2 = product.definition;
			if (definition2.storeSpecificId != null)
			{
				object obj2 = definition2.storeSpecificId as object;
				num = array.Length;
			}
			bool flag = num < 1;
			bool flag2 = !flag;
			object obj3 = num - 1;
			bool flag3 = obj3 == null;
			bool flag4 = !flag2;
			if (flag4 || flag3)
			{
				break;
			}
			array[1] = definition2.storeSpecificId;
			ProductDefinition definition3 = product.definition;
			ProductType type = definition3.type;
			object obj4 = type;
			num = (int)obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v409 @ X8_v10 (System.Int32)+160] (should have been resolved before IL gen)");
			Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			if (obj5 != null)
			{
				object obj6 = obj5 as object;
			}
			num = array.Length;
			bool flag5 = array.Length < 2;
			bool flag6 = !flag5;
			object obj7 = array.Length - 2;
			bool flag7 = obj7 == null;
			bool flag8 = !flag6;
			if (flag8 || flag7)
			{
				break;
			}
			array[2] = obj5;
			ProductDefinition definition4 = product.definition;
			string text = ((!definition4.enabled) ? "disabled" : "enabled");
			if (text != null)
			{
				object obj8 = text as object;
				num = array.Length;
			}
			bool flag9 = num < 3;
			bool flag10 = !flag9;
			object obj9 = num - 3;
			bool flag11 = obj9 == null;
			bool flag12 = !flag10;
			if (flag12 || flag11)
			{
				break;
			}
			array[3] = text;
			string message = string.Format("id: {0}\nstore-specific id: {1}\ntype: {2}\nenabled: {3}\n", array);
			Debug.Log(message);
			num = all.Length;
			num2++;
			bool flag13 = num2 < all.Length;
			num3 = 0;
			if (!flag13)
			{
				return;
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000011")]
	[Address(RVA = "0x160A344", Offset = "0x160A344", Length = "0x70")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EB61F0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A1E7]) = v38;\nL_0016:\n\tv42 = new System.Collections.Generic.Dictionary`2<System.String, IAPDemoProductUI>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, IAPDemoProductUI>::.ctor(v42);\n\tthis.m_ProductUIs = v42;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public IAPDemo()
	{
		Dictionary<string, IAPDemoProductUI> productUIs = new Dictionary<string, IAPDemoProductUI>();
		m_ProductUIs = productUIs;
	}
}
