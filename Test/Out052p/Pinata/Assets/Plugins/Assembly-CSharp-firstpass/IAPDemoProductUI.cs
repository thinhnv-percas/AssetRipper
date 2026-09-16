using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

[Token(Token = "0x2000003")]
public class IAPDemoProductUI : MonoBehaviour
{
	[Token(Token = "0x4000011")]
	[FieldOffset(Offset = "0x18")]
	public Button purchaseButton;

	[Token(Token = "0x4000012")]
	[FieldOffset(Offset = "0x20")]
	public Button receiptButton;

	[Token(Token = "0x4000013")]
	[FieldOffset(Offset = "0x28")]
	public Text titleText;

	[Token(Token = "0x4000014")]
	[FieldOffset(Offset = "0x30")]
	public Text descriptionText;

	[Token(Token = "0x4000015")]
	[FieldOffset(Offset = "0x38")]
	public Text priceText;

	[Token(Token = "0x4000016")]
	[FieldOffset(Offset = "0x40")]
	public Text statusText;

	[Token(Token = "0x4000017")]
	[FieldOffset(Offset = "0x48")]
	private string m_ProductID;

	[Token(Token = "0x4000018")]
	[FieldOffset(Offset = "0x50")]
	private Action<string> m_PurchaseCallback;

	[Token(Token = "0x4000019")]
	[FieldOffset(Offset = "0x58")]
	private string m_Receipt;

	[Token(Token = "0x6000013")]
	[Address(RVA = "0x160A014", Offset = "0x160A014", Length = "0x138")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EC8090]);\n\tv27 = *([v26 @ X8_v20]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, p, purchaseCallback, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202A1E9]) = v44;\nL_0019:\n\tv46 = p.<metadata>k__BackingField;\n\tv64 = UnityEngine.UI.Text::set_text(this.titleText, v46.<localizedTitle>k__BackingField);\n\tv74 = p.<metadata>k__BackingField;\n\tv65 = UnityEngine.UI.Text::set_text(this.descriptionText, v74.<localizedDescription>k__BackingField);\n\tv75 = p.<metadata>k__BackingField;\n\tv161 = UnityEngine.UI.Text::set_text(this.priceText, v75.<localizedPriceString>k__BackingField);\n\tv66 = UnityEngine.Purchasing.Product::get_hasReceipt(p);\n\tUnityEngine.UI.Selectable::set_interactable(this.receiptButton, v66);\n\tthis.m_Receipt = p.<receipt>k__BackingField;\n\tv77 = p.<definition>k__BackingField;\n\tv89 = this.statusText;\n\tthis.m_ProductID = v77.<id>k__BackingField;\n\tthis.m_PurchaseCallback = purchaseCallback;\n\tv144 = *([v89 @ X0_v15 (UnityEngine.UI.Text)]);\n\tv122 = p.<availableToPurchase>k__BackingField == 0;\n\tv108 = *([v144 @ X9_v6 (Il2CppClass<UnityEngine.UI.Text>)+5C0]);\n\tv140 = *([v144 @ X9_v6 (Il2CppClass<UnityEngine.UI.Text>)+5C8]);\n\tv105 = ~v122;\n\tv102 = ~v105;\n\tif (v102) goto L_FFFFFFFF;\n\tgoto L_0067;\nL_0067:\n\tv142 = *([v154 @ X8_v15 (System.String)]);\n\t// 111 IndirectJump v108 @ X3_v1, v89 @ X0_v15 (UnityEngine.UI.Text), v89 @ X0_v15 (UnityEngine.UI.Text), v142 @ X1_v8 (Il2CppClass<System.String>), v140 @ X2_v7, v108 @ X3_v1, v30 @ X4, v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void SetProduct(Product p, Action<string> purchaseCallback)
	{
		//IL_00e9: Expected I, but got O
		//IL_010d: Expected O, but got I
		//IL_011d: Expected O, but got I
		//IL_0165: Expected I, but got O
		ProductMetadata metadata = p.metadata;
		titleText.text = metadata.localizedTitle;
		ProductMetadata metadata2 = p.metadata;
		descriptionText.text = metadata2.localizedDescription;
		ProductMetadata metadata3 = p.metadata;
		priceText.text = metadata3.localizedPriceString;
		bool hasReceipt = p.hasReceipt;
		receiptButton.interactable = hasReceipt;
		m_Receipt = p.receipt;
		ProductDefinition definition = p.definition;
		Text text = statusText;
		m_ProductID = definition.id;
		m_PurchaseCallback = purchaseCallback;
		IntPtr intPtr = (IntPtr)text;
		bool flag = !p.availableToPurchase;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ X9_v6 (Il2CppClass<UnityEngine.UI.Text>)+5C0]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ X9_v6 (Il2CppClass<UnityEngine.UI.Text>)+5C8]");
		object obj2 = 0;
		string text2 = (flag ? "Unavailable" : "Available");
		IntPtr intPtr2 = (IntPtr)text2;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v108 @ X3_v1 (should have been resolved before IL gen)");
	}

	[Token(Token = "0x6000014")]
	[Address(RVA = "0x160A20C", Offset = "0x160A20C", Length = "0x9C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1F0B1F8]);\n\tv21 = *([v20 @ X8_v9]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, secondsRemaining, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 0 | 1;\n\t*([202A1EA]) = v39;\nL_0017:\n\tv43 = 0xDC3560(&secondsRemaining @ X1 (System.Int32), 0, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv50 = System.String::Concat(\"Pending \", v43);\n\tv57 = UnityEngine.UI.Text::set_text(this.statusText, v50);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void SetPendingTime(int secondsRemaining)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
		string text2 = default(string);
		string text = "Pending " + text2;
		statusText.text = text;
	}

	[Token(Token = "0x6000015")]
	[Address(RVA = "0x160A4A0", Offset = "0x160A4A0", Length = "0x80")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1ED9908]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A1EB]) = v38;\nL_0014:\n\tv40 = this.m_PurchaseCallback == 0;\n\tif (v40) goto L_0021;\n\tv43 = System.String::IsNullOrEmpty(this.m_ProductID);\n\tv47 = v43 == 0;\n\tif (v47) goto L_002E;\nL_0021:\n\treturn;\nL_002E:\n\tSystem.Action`1<System.String>::Invoke(this.m_PurchaseCallback, this.m_ProductID);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void PurchaseButtonClick()
	{
		if (m_PurchaseCallback != null && !string.IsNullOrEmpty(m_ProductID))
		{
			m_PurchaseCallback(m_ProductID);
		}
	}

	[Token(Token = "0x6000016")]
	[Address(RVA = "0x160A520", Offset = "0x160A520", Length = "0xB4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EC43A0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A1EC]) = v38;\nL_0015:\n\tv41 = System.String::IsNullOrEmpty(this.m_Receipt);\n\tv43 = v41 == 0;\n\tif (v43) goto L_0028;\n\treturn;\nL_0028:\n\tv57 = System.String::Concat(\"Receipt for \", this.m_ProductID, \": \", this.m_Receipt);\n\tgoto L_003E;\n\tv86 = *([v75 @ X8_v7+E0]);\n\tv87 = v86 == 0;\n\tv88 = ~v87;\n\tif (v88) goto L_003E;\n\tv91 = v75;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v91, v50, v56, v51, v54, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003E:\n\tUnityEngine.Debug::Log(v57);\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void ReceiptButtonClick()
	{
		if (!string.IsNullOrEmpty(m_Receipt))
		{
			string message = "Receipt for " + m_ProductID + ": " + m_Receipt;
			Debug.Log(message);
		}
	}

	[Token(Token = "0x6000017")]
	[Address(RVA = "0x160A5D4", Offset = "0x160A5D4", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public IAPDemoProductUI()
	{
	}
}
