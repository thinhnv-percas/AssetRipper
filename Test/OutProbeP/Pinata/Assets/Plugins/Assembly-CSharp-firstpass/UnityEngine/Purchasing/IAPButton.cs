using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UnityEngine.Purchasing
{
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x7DCD14", Offset = "0x7DCD14")]
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x7DCD14", Offset = "0x7DCD14")]
	[AttributeAttribute(Type = typeof(HelpURLAttribute), RVA = "0x7DCD14", Offset = "0x7DCD14")]
	[Token(Token = "0x2000006")]
	public class IAPButton : MonoBehaviour
	{
		[Token(Token = "0x2000009")]
		public enum ButtonType
		{
			[Token(Token = "0x400002F")]
			Purchase = 0,
			[Token(Token = "0x4000030")]
			Restore = 1
		}

		[Serializable]
		[Token(Token = "0x200000A")]
		public class OnPurchaseCompletedEvent : UnityEvent<Product>
		{
			[Token(Token = "0x600003D")]
			[Address(RVA = "0x160D540", Offset = "0x160D540", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EDC9F8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A206]) = v38;\nL_001C:\n\tUnityEngine.Events.UnityEvent`1<UnityEngine.Purchasing.Product>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public OnPurchaseCompletedEvent()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x200000B")]
		public class OnPurchaseFailedEvent : UnityEvent<Product, PurchaseFailureReason>
		{
			[Token(Token = "0x600003E")]
			[Address(RVA = "0x160D590", Offset = "0x160D590", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EB57C8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A207]) = v38;\nL_001C:\n\tUnityEngine.Events.UnityEvent`2<UnityEngine.Purchasing.Product, UnityEngine.Purchasing.PurchaseFailureReason>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public OnPurchaseFailedEvent()
			{
			}
		}

		[HideInInspector]
		[Token(Token = "0x4000022")]
		[FieldOffset(Offset = "0x18")]
		public string productId;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7DCE30", Offset = "0x7DCE30")]
		[Token(Token = "0x4000023")]
		[FieldOffset(Offset = "0x20")]
		public ButtonType buttonType;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7DCE68", Offset = "0x7DCE68")]
		[Token(Token = "0x4000024")]
		[FieldOffset(Offset = "0x24")]
		public bool consumePurchase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7DCEA0", Offset = "0x7DCEA0")]
		[Token(Token = "0x4000025")]
		[FieldOffset(Offset = "0x28")]
		public OnPurchaseCompletedEvent onPurchaseComplete;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7DCED8", Offset = "0x7DCED8")]
		[Token(Token = "0x4000026")]
		[FieldOffset(Offset = "0x30")]
		public OnPurchaseFailedEvent onPurchaseFailed;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7DCF10", Offset = "0x7DCF10")]
		[Token(Token = "0x4000027")]
		[FieldOffset(Offset = "0x38")]
		public Text titleText;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7DCF48", Offset = "0x7DCF48")]
		[Token(Token = "0x4000028")]
		[FieldOffset(Offset = "0x40")]
		public Text descriptionText;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7DCF80", Offset = "0x7DCF80")]
		[Token(Token = "0x4000029")]
		[FieldOffset(Offset = "0x48")]
		public Text priceText;

		[Token(Token = "0x600002C")]
		[Address(RVA = "0x160CA40", Offset = "0x160CA40", Length = "0x230")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EB2CB8]);\n\tv21 = *([v20 @ X8_v43]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A1FE]) = v40;\nL_0018:\n\tv45 = UnityEngine.Component::GetComponent(this);\n\tv52 = this.buttonType == 1;\n\tif (v52) goto L_0095;\n\tv57 = this.buttonType == 0;\n\tv58 = ~v57;\n\tif (v58) goto L_00C2;\n\tgoto L_0036;\n\tv103 = *([v67 @ X0_v17+E0]);\n\tv104 = v103 == 0;\n\tv105 = ~v104;\n\tif (v105) goto L_0036;\n\tv107 = \"il2cpp_codegen_runtime_class_init\"(v67, v44, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0036:\n\tv112 = UnityEngine.Object::op_Implicit(v45);\n\tv159 = v112 == 0;\n\tif (v159) goto L_0050;\n\tv192 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v192, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(v45.m_OnClick, v192);\nL_0050:\n\tv176 = System.String::IsNullOrEmpty(this.productId);\n\tv201 = v176 == 0;\n\tif (v201) goto L_0065;\n\tgoto L_0064;\n\tv220 = *([v210 @ X0_v33+E0]);\n\tv221 = v220 == 0;\n\tv222 = ~v221;\n\tif (v222) goto L_0064;\n\tv224 = \"il2cpp_codegen_runtime_class_init\"(v210, v175, v72, v76, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0064:\n\tUnityEngine.Debug::LogError(\"IAPButton productId is empty\");\nL_0065:\n\tv205 = UnityEngine.Purchasing.CodelessIAPStoreListener::get_Instance();\n\tv81 = UnityEngine.Purchasing.CodelessIAPStoreListener::HasProductInCatalog(v205, this.productId);\n\tv228 = v81 == 0;\n\tv84 = ~v228;\n\tif (v84) goto L_00C2;\n\tv235 = System.String::Concat(\"The product catalog has no product with the ID \\\"\", this.productId, \"\\\"\");\n\tgoto L_008D;\n\tv242 = *([v147 @ X8_v28+E0]);\n\tv243 = v242 == 0;\n\tv244 = ~v243;\n\tif (v244) goto L_008D;\n\tv247 = v147;\n\tv246 = \"il2cpp_codegen_runtime_class_init\"(v247, v231, v120, v128, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_008D:\n\tUnityEngine.Debug::LogWarning(v235);\n\treturn;\nL_0095:\n\tgoto L_009D;\n\tv96 = *([v61 @ X0_v9+E0]);\n\tv97 = v96 == 0;\n\tv98 = ~v97;\n\tif (v98) goto L_009D;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v61, v44, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_009D:\n\tv82 = UnityEngine.Object::op_Implicit(v45);\n\tv85 = v82 == 0;\n\tif (v85) goto L_00C2;\n\tv181 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v181, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(v45.m_OnClick, v181);\n\treturn;\nL_00C2:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 133 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			//IL_00cf: Expected I4, but got O
			Button component = GetComponent<Button>();
			if (buttonType != ButtonType.Restore)
			{
				if (buttonType == ButtonType.Purchase)
				{
					if ((bool)component)
					{
						UnityAction call = PurchaseProduct;
						component.onClick.AddListener(call);
					}
					if (string.IsNullOrEmpty(productId))
					{
						Debug.LogError("IAPButton productId is empty");
						bool flag = (byte)(int)"IAPButton productId is empty" != 0;
					}
					CodelessIAPStoreListener instance = CodelessIAPStoreListener.Instance;
					if (!instance.HasProductInCatalog(productId))
					{
						string message = "The product catalog has no product with the ID \"" + productId + "\"";
						Debug.LogWarning(message);
					}
				}
			}
			else if ((bool)component)
			{
				UnityAction call2 = Restore;
				component.onClick.AddListener(call2);
			}
		}

		[Token(Token = "0x600002D")]
		[Address(RVA = "0x160CC70", Offset = "0x160CC70", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1ECA2E0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A1FF]) = v38;\nL_0014:\n\tv40 = v36.buttonType == 0;\n\tif (v40) goto L_001C;\nL_001B:\n\treturn;\nL_001C:\n\tv44 = UnityEngine.Purchasing.CodelessIAPStoreListener::get_Instance();\n\tUnityEngine.Purchasing.CodelessIAPStoreListener::AddButton(v44, v36);\n\tv46 = ~v71.initializationComplete;\n\tif (v46) goto L_001B;\n\tUnityEngine.Purchasing.IAPButton::UpdateText(v36);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnEnable()
		{
			if (buttonType == ButtonType.Purchase)
			{
				CodelessIAPStoreListener instance = CodelessIAPStoreListener.Instance;
				instance.AddButton(this);
				if (CodelessIAPStoreListener.initializationComplete)
				{
					UpdateText();
				}
			}
		}

		[Token(Token = "0x600002E")]
		[Address(RVA = "0x160CCF4", Offset = "0x160CCF4", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.buttonType == 0;\n\tif (v11) goto L_000E;\n\treturn;\nL_000E:\n\tv15 = UnityEngine.Purchasing.CodelessIAPStoreListener::get_Instance();\n\tUnityEngine.Purchasing.CodelessIAPStoreListener::RemoveButton(v15, this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			if (buttonType == ButtonType.Purchase)
			{
				CodelessIAPStoreListener instance = CodelessIAPStoreListener.Instance;
				instance.RemoveButton(this);
			}
		}

		[Token(Token = "0x600002F")]
		[Address(RVA = "0x160CD34", Offset = "0x160CD34", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EAFBD0]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A200]) = v38;\nL_0014:\n\tv40 = this.buttonType == 0;\n\tif (v40) goto L_0021;\n\treturn;\nL_0021:\n\tv50 = System.String::Concat(\"IAPButton.PurchaseProduct() with product ID: \", this.productId);\n\tgoto L_0032;\n\tv79 = *([v68 @ X8_v8+E0]);\n\tv80 = v79 == 0;\n\tv81 = ~v80;\n\tif (v81) goto L_0032;\n\tv86 = v68;\n\tv83 = \"il2cpp_codegen_runtime_class_init\"(v86, v46, v48, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0032:\n\tUnityEngine.Debug::Log(v50);\n\tv61 = UnityEngine.Purchasing.CodelessIAPStoreListener::get_Instance();\n\tUnityEngine.Purchasing.CodelessIAPStoreListener::InitiatePurchase(v61, this.productId);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void PurchaseProduct()
		{
			if (buttonType == ButtonType.Purchase)
			{
				string message = "IAPButton.PurchaseProduct() with product ID: " + productId;
				Debug.Log(message);
				CodelessIAPStoreListener instance = CodelessIAPStoreListener.Instance;
				instance.InitiatePurchase(productId);
			}
		}

		[Token(Token = "0x6000030")]
		[Address(RVA = "0x160CDE4", Offset = "0x160CDE4", Length = "0x68C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv20 = *([1EF1988]);\n\tv21 = *([v20 @ X8_v75]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A201]) = v40;\nL_001F:\n\tv52 = this.buttonType != 1;\n\tif (v52) goto L_00B7;\n\tv237 = UnityEngine.Application::get_platform();\n\tv154 = v237 == 0x12;\n\tif (v154) goto L_0046;\n\tv237 = UnityEngine.Application::get_platform();\n\tv227 = v237 == 0x13;\n\tif (v227) goto L_0046;\n\tv237 = UnityEngine.Application::get_platform();\n\tv212 = v237 != 0x14;\n\tif (v212) goto L_00B9;\nL_0046:\n\tv239 = UnityEngine.Purchasing.CodelessIAPStoreListener::get_Instance();\n\tv243 = v239.extensions;\n\tv356 = *([v243 @ X19_v6 (UnityEngine.Purchasing.IExtensionProvider)]);\n\tv142 = Il2CppMethodInfo;\n\tv359 = *([v356 @ X8_v7 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]) == 0;\n\tif (v359) goto L_0071;\n\tv476 = *([v356 @ X8_v7 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]) + 8;\nL_005D:\n\tv490 = *([v476 @ X11_v14-8]) == Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>;\n\tif (v490) goto L_0074;\n\tv475 = v475 + 1;\n\tv516 = v475 < *([v356 @ X8_v7 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]);\n\tv462 = ~v516;\n\tv476 = v476 + 0x10;\n\tv446 = ~v462;\n\tif (v446) goto L_005D;\nL_0071:\n\tthis = 0x8909C4(v243, Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>, *([v142 @ X20_v6 (Il2CppMethodInfo)+48]), v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_007A;\nL_0074:\n\tv518 = *([v476 @ X11_v14]) + *([v142 @ X20_v6 (Il2CppMethodInfo)+48]);\n\tv519 = v518 << 4;\n\tv520 = v356 + v519;\n\tthis = v520 + 0x130;\nL_007A:\n\tv527 = UnityEngine.Purchasing.IExtensionProvider::GetExtension(*([this @ X0 (UnityEngine.Purchasing.IAPButton)+8]));\n\t*([v527 @ X0_v14 (UnityEngine.Purchasing.IMicrosoftExtensions)])(v329, v243, v527, *([v142 @ X20_v6 (Il2CppMethodInfo)+48]), v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_00B0;\n\tv545 = *([v532 @ X8_v10+B0]);\n\tv546 = 0;\n\tv547 = v545 + 8;\n\tv549 = *([v608 @ X11_v9-8]);\n\tv622 = v549 == v535;\n\tif (v622) goto L_00A9;\n\tv551 = v607 + 1;\n\tv649 = v551 < v534;\n\tv571 = ~v649;\n\tv553 = v608 + 0x10;\n\tv555 = ~v571;\n\tif (v555) goto L_FFFFFFFF;\n\tv572 = v135;\n\tv573 = 0;\n\tv574 = 0x8909C4(v572, v535, v573, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_00B0;\nL_00A9:\n\tv650 = *([v608 @ X11_v9]);\n\tv651 = v650 << 4;\n\tv652 = v532 + v651;\n\tv653 = v652 + 0x130;\nL_00B0:\n\tUnityEngine.Purchasing.IMicrosoftExtensions::RestoreTransactions(v329);\nL_00B7:\n\treturn;\nL_00B9:\n\tv514 = UnityEngine.Application::get_platform();\n\tv469 = v514 == 8;\n\tif (v469) goto L_00DD;\n\tv514 = UnityEngine.Application::get_platform();\n\tv507 = v514 == 1;\n\tif (v507) goto L_00DD;\n\tv514 = UnityEngine.Application::get_platform();\n\tv497 = v514 != 0x1F;\n\tif (v497) goto L_015A;\nL_00DD:\n\tv330 = UnityEngine.Purchasing.CodelessIAPStoreListener::get_Instance();\n\tv427 = v330.extensions;\n\tv539 = *([v427 @ X20_v10 (UnityEngine.Purchasing.IExtensionProvider)]);\n\tv540 = Il2CppMethodInfo;\n\tv544 = *([v539 @ X8_v19 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]) == 0;\n\tif (v544) goto L_0108;\n\tv630 = *([v539 @ X8_v19 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]) + 8;\nL_00F4:\n\tv644 = *([v630 @ X11_v28-8]) == Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>;\n\tif (v644) goto L_010B;\n\tv629 = v629 + 1;\n\tv678 = v629 < *([v539 @ X8_v19 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]);\n\tv603 = ~v678;\n\tv630 = v630 + 0x10;\n\tv587 = ~v603;\n\tif (v587) goto L_00F4;\nL_0108:\n\tthis = 0x8909C4(v427, Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>, *([v540 @ X21_v7 (Il2CppMethodInfo)+48]), v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_0111;\nL_010B:\n\tv680 = *([v630 @ X11_v28]) + *([v540 @ X21_v7 (Il2CppMethodInfo)+48]);\n\tv681 = v680 << 4;\n\tv682 = v539 + v681;\n\tthis = v682 + 0x130;\nL_0111:\n\tv689 = UnityEngine.Purchasing.IExtensionProvider::GetExtension(*([this @ X0 (UnityEngine.Purchasing.IAPButton)+8]));\n\t*([v689 @ X0_v43 (UnityEngine.Purchasing.IAppleExtensions)])(v839, v427, v689, *([v540 @ X21_v7 (Il2CppMethodInfo)+48]), v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv415 = new System.Action`1<System.Boolean>();\n\tSystem.Action`1<System.Boolean>::.ctor(v415, this, Il2CppMethodInfo);\n\tv734 = *([v839 @ X0_v34 (System.Action`1<System.Boolean>)]);\n\tv738 = *([v734 @ X8_v27 (Il2CppClass<System.Action`1<System.Boolean>>)+126]) == 0;\n\tif (v738) goto L_FFFFFFFF;\n\tv784 = *([v734 @ X8_v27 (Il2CppClass<System.Action`1<System.Boolean>>)+B0]) + 8;\nL_0137:\n\tv798 = *([v784 @ X11_v23-8]) == UnityEngine.Purchasing.IAppleExtensions;\n\tif (v798) goto L_014F;\n\tv783 = v783 + 1;\n\tv853 = v783 < *([v734 @ X8_v27 (Il2CppClass<System.Action`1<System.Boolean>>)+126]);\n\tv772 = ~v853;\n\tv784 = v784 + 0x10;\n\tv756 = ~v772;\n\tif (v756) goto L_0137;\nL_014C:\n\tv918 = System.Action`1<System.Boolean>::.ctor(v839, v817, v815);\n\tgoto L_0157;\nL_014F:\n\tv855 = *([v784 @ X11_v23]) + 1;\n\tv856 = v855 << 4;\n\tv911 = v734 + v856;\nL_0152:\n\tv918 = v911 + 0x130;\nL_0157:\n\t*([v918 @ X0_v36 (System.Action`1<System.Boolean>)])(this, v144, v64, *([v918 @ X0_v36 (System.Action`1<System.Boolean>)+8]), v62, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_00B7;\nL_015A:\n\tv576 = UnityEngine.Application::get_platform();\n\tv268 = v576 != 0xB;\n\tif (v268) goto L_01B1;\n\tgoto L_0173;\n\tv690 = *([v659 @ X0_v96+E0]);\n\tv691 = v690 == 0;\n\tv692 = ~v691;\n\tif (v692) goto L_0173;\n\tv694 = \"il2cpp_codegen_runtime_class_init\"(v659, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0173:\n\tv331 = UnityEngine.Purchasing.StandardPurchasingModule::Instance();\n\tv673 = UnityEngine.Purchasing.StandardPurchasingModule::get_appStore(v331);\n\tv269 = v673 != 4;\n\tif (v269) goto L_01B1;\n\tv332 = UnityEngine.Purchasing.CodelessIAPStoreListener::get_Instance();\n\tv429 = v332.extensions;\n\tv860 = *([v429 @ X20_v17 (UnityEngine.Purchasing.IExtensionProvider)]);\n\tv861 = Il2CppMethodInfo;\n\tv865 = *([v860 @ X8_v62 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]) == 0;\n\tif (v865) goto L_01AE;\n\tv953 = *([v860 @ X8_v62 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]) + 8;\nL_019A:\n\tv967 = *([v953 @ X11_v50-8]) == Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>;\n\tif (v967) goto L_0236;\n\tv952 = v952 + 1;\n\tv980 = v952 < *([v860 @ X8_v62 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]);\n\tv947 = ~v980;\n\tv953 = v953 + 0x10;\n\tv931 = ~v947;\n\tif (v931) goto L_019A;\nL_01AE:\n\tthis = 0x8909C4(v429, Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>, *([v861 @ X21_v13 (Il2CppMethodInfo)+48]), v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_023C;\nL_01B1:\n\tv677 = UnityEngine.Application::get_platform();\n\tv270 = v677 != 0xB;\n\tif (v270) goto L_0208;\n\tgoto L_01CA;\n\tv722 = *([v709 @ X0_v79+E0]);\n\tv723 = v722 == 0;\n\tv724 = ~v723;\n\tif (v724) goto L_01CA;\n\tv726 = \"il2cpp_codegen_runtime_class_init\"(v709, v260, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_01CA:\n\tv333 = UnityEngine.Purchasing.StandardPurchasingModule::Instance();\n\tv715 = UnityEngine.Purchasing.StandardPurchasingModule::get_appStore(v333);\n\tv271 = v715 != 3;\n\tif (v271) goto L_0208;\n\tv334 = UnityEngine.Purchasing.CodelessIAPStoreListener::get_Instance();\n\tv430 = v334.extensions;\n\tv974 = *([v430 @ X20_v15 (UnityEngine.Purchasing.IExtensionProvider)]);\n\tv975 = Il2CppMethodInfo;\n\tv979 = *([v974 @ X8_v47 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]) == 0;\n\tif (v979) goto L_0205;\n\tv1032 = *([v974 @ X8_v47 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]) + 8;\nL_01F1:\n\tv1046 = *([v1032 @ X11_v40-8]) == Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>;\n\tif (v1046) goto L_0277;\n\tv1031 = v1031 + 1;\n\tv1053 = v1031 < *([v974 @ X8_v47 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]);\n\tv1018 = ~v1053;\n\tv1032 = v1032 + 0x10;\n\tv1002 = ~v1018;\n\tif (v1002) goto L_01F1;\nL_0205:\n\tthis = 0x8909C4(v430, Il2CppClass<UnityEngine.Purchasing.IExtensio\n// ... truncated")]
		private void Restore()
		{
			//IL_00a2: Expected I, but got O
			//IL_0a5a: Expected O, but got I
			//IL_00e3: Expected O, but got I
			//IL_016c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Expected O, but got Unknown
			//IL_018e: Expected O, but got I
			//IL_019d: Expected O, but got I
			//IL_012f: Expected O, but got I
			//IL_0244: Expected I, but got O
			//IL_0aae: Expected O, but got I
			//IL_0285: Expected O, but got I
			//IL_034c: Expected I, but got O
			//IL_0411: Expected I, but got O
			//IL_030e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0313: Expected O, but got Unknown
			//IL_0330: Expected O, but got I
			//IL_033f: Expected O, but got I
			//IL_0387: Expected O, but got I
			//IL_02d1: Expected O, but got I
			//IL_0427: Unknown result type (might be due to invalid IL or missing references)
			//IL_042c: Expected O, but got Unknown
			//IL_0449: Expected O, but got I
			//IL_0c4e: Expected O, but got I
			//IL_03d3: Expected O, but got I
			//IL_04f5: Expected I, but got O
			//IL_0640: Expected I, but got O
			//IL_0b3e: Expected O, but got I
			//IL_0536: Expected O, but got I
			//IL_0b95: Expected O, but got I
			//IL_0681: Expected O, but got I
			//IL_07ab: Expected I, but got O
			//IL_07de: Expected I, but got O
			//IL_08e6: Expected I, but got O
			//IL_0919: Expected I, but got O
			//IL_076d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0772: Expected O, but got Unknown
			//IL_078f: Expected O, but got I
			//IL_079e: Expected O, but got I
			//IL_08a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_08ad: Expected O, but got Unknown
			//IL_08ca: Expected O, but got I
			//IL_08d9: Expected O, but got I
			//IL_080a: Expected O, but got I
			//IL_0582: Expected O, but got I
			//IL_0945: Expected O, but got I
			//IL_06cd: Expected O, but got I
			//IL_09f2: Expected I4, but got O
			//IL_0a00: Expected O, but got I
			//IL_0856: Expected O, but got I
			//IL_0991: Expected O, but got I
			//IL_09b8: Expected I, but got O
			//IL_088b: Expected I, but got O
			if (buttonType != ButtonType.Restore)
			{
				return;
			}
			RuntimePlatform platform = Application.platform;
			IAPButton iAPButton;
			if (platform != RuntimePlatform.MetroPlayerX86)
			{
				platform = Application.platform;
				if (platform != RuntimePlatform.MetroPlayerX64)
				{
					platform = Application.platform;
					if (platform != RuntimePlatform.MetroPlayerARM)
					{
						RuntimePlatform platform2 = Application.platform;
						if (platform2 != RuntimePlatform.IPhonePlayer)
						{
							platform2 = Application.platform;
							if (platform2 != RuntimePlatform.OSXPlayer)
							{
								platform2 = Application.platform;
								if (platform2 != RuntimePlatform.tvOS)
								{
									RuntimePlatform platform3 = Application.platform;
									if (platform3 == RuntimePlatform.Android)
									{
										StandardPurchasingModule standardPurchasingModule = StandardPurchasingModule.Instance();
										AppStore appStore = standardPurchasingModule.appStore;
										if (appStore == AppStore.SamsungApps)
										{
											CodelessIAPStoreListener instance = CodelessIAPStoreListener.Instance;
											IExtensionProvider extensionProvider = instance.ExtensionProvider;
											IntPtr intPtr = (IntPtr)extensionProvider;
											IntPtr intPtr2 = (IntPtr)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v860 @ X8_v62 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
											if ((IntPtr)0 == (IntPtr)0)
											{
												goto IL_059b;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v860 @ X8_v62 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]");
											object obj = 0L + 8L;
											int num = 0;
											while (true)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v953 @ X11_v50-8]");
												if ((IntPtr)0 == (IntPtr)0)
												{
													break;
												}
												num++;
												int num2 = num;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v860 @ X8_v62 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
												bool flag = (long)num2 < 0L;
												bool flag2 = !flag;
												obj = (long)(IntPtr)obj + 16L;
												if (!flag2)
												{
													continue;
												}
												goto IL_059b;
											}
											object obj2 = obj;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v861 @ X21_v13 (Il2CppMethodInfo)+48]");
											object obj3 = obj2 + 0;
											int num3 = (int)((long)(IntPtr)obj3 << 4);
											object obj4 = (long)intPtr + (long)num3;
											iAPButton = (IAPButton)((long)(IntPtr)obj4 + 304L);
											goto IL_0b2d;
										}
									}
									RuntimePlatform platform4 = Application.platform;
									if (platform4 == RuntimePlatform.Android)
									{
										StandardPurchasingModule standardPurchasingModule2 = StandardPurchasingModule.Instance();
										AppStore appStore2 = standardPurchasingModule2.appStore;
										if (appStore2 == AppStore.CloudMoolah)
										{
											CodelessIAPStoreListener instance2 = CodelessIAPStoreListener.Instance;
											IExtensionProvider extensionProvider2 = instance2.ExtensionProvider;
											IntPtr intPtr3 = (IntPtr)extensionProvider2;
											IntPtr intPtr4 = (IntPtr)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v974 @ X8_v47 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
											if ((IntPtr)0 == (IntPtr)0)
											{
												goto IL_06e6;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v974 @ X8_v47 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]");
											object obj5 = 0L + 8L;
											int num4 = 0;
											while (true)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1032 @ X11_v40-8]");
												if ((IntPtr)0 == (IntPtr)0)
												{
													break;
												}
												num4++;
												int num5 = num4;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v974 @ X8_v47 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
												bool flag3 = (long)num5 < 0L;
												bool flag4 = !flag3;
												obj5 = (long)(IntPtr)obj5 + 16L;
												if (!flag4)
												{
													continue;
												}
												goto IL_06e6;
											}
											object obj6 = obj5;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v975 @ X21_v11 (Il2CppMethodInfo)+48]");
											object obj7 = obj6 + 0;
											int num6 = (int)((long)(IntPtr)obj7 << 4);
											object obj8 = (long)intPtr3 + (long)num6;
											iAPButton = (IAPButton)((long)(IntPtr)obj8 + 304L);
											goto IL_0b84;
										}
									}
									RuntimePlatform platform5 = Application.platform;
									iAPButton = (IAPButton)(object)platform5;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v739 @ X8_v38+160] (should have been resolved before IL gen)");
									Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
									string text = default(string);
									string message = text + " is not a supported platform for the Codeless IAP restore button";
									Debug.LogWarning(message);
									return;
								}
							}
						}
						CodelessIAPStoreListener instance3 = CodelessIAPStoreListener.Instance;
						IExtensionProvider extensionProvider3 = instance3.ExtensionProvider;
						IntPtr intPtr5 = (IntPtr)extensionProvider3;
						IntPtr intPtr6 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v539 @ X8_v19 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							goto IL_02ea;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v539 @ X8_v19 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]");
						object obj9 = 0L + 8L;
						int num7 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v630 @ X11_v28-8]");
							if ((IntPtr)0 == (IntPtr)0)
							{
								break;
							}
							num7++;
							int num8 = num7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v539 @ X8_v19 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
							bool flag5 = (long)num8 < 0L;
							bool flag6 = !flag5;
							obj9 = (long)(IntPtr)obj9 + 16L;
							if (!flag6)
							{
								continue;
							}
							goto IL_02ea;
						}
						object obj10 = obj9;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ X21_v7 (Il2CppMethodInfo)+48]");
						object obj11 = obj10 + 0;
						int num9 = (int)((long)(IntPtr)obj11 << 4);
						object obj12 = (long)intPtr5 + (long)num9;
						iAPButton = (IAPButton)((long)(IntPtr)obj12 + 304L);
						goto IL_0a9d;
					}
				}
			}
			CodelessIAPStoreListener instance4 = CodelessIAPStoreListener.Instance;
			IExtensionProvider extensionProvider4 = instance4.ExtensionProvider;
			IntPtr intPtr7 = (IntPtr)extensionProvider4;
			IntPtr intPtr8 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v356 @ X8_v7 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0148;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v356 @ X8_v7 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+B0]");
			object obj13 = 0L + 8L;
			int num10 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v476 @ X11_v14-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num10++;
				int num11 = num10;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v356 @ X8_v7 (Il2CppClass<UnityEngine.Purchasing.IExtensionProvider>)+126]");
				bool flag7 = (long)num11 < 0L;
				bool flag8 = !flag7;
				obj13 = (long)(IntPtr)obj13 + 16L;
				if (!flag8)
				{
					continue;
				}
				goto IL_0148;
			}
			object obj14 = obj13;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X20_v6 (Il2CppMethodInfo)+48]");
			object obj15 = obj14 + 0;
			int num12 = (int)((long)(IntPtr)obj15 << 4);
			object obj16 = (long)intPtr7 + (long)num12;
			iAPButton = (IAPButton)((long)(IntPtr)obj16 + 304L);
			goto IL_0a49;
			IL_0a9d:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (UnityEngine.Purchasing.IAPButton)+8]");
			IAppleExtensions extension = ((IExtensionProvider)0).GetExtension<IAppleExtensions>();
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v689 @ X0_v43 (UnityEngine.Purchasing.IAppleExtensions)] (should have been resolved before IL gen)");
			Action<bool> action = OnTransactionsRestored;
			Action<bool> action2 = default(Action<bool>);
			IntPtr intPtr9 = (IntPtr)action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v734 @ X8_v27 (Il2CppClass<System.Action`1<System.Boolean>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_03ec;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v734 @ X8_v27 (Il2CppClass<System.Action`1<System.Boolean>>)+B0]");
			object obj17 = 0L + 8L;
			int num13 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v784 @ X11_v23-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IAppleExtensions))
				{
					break;
				}
				num13++;
				int num14 = num13;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v734 @ X8_v27 (Il2CppClass<System.Action`1<System.Boolean>>)+126]");
				bool flag9 = (long)num14 < 0L;
				bool flag10 = !flag9;
				obj17 = (long)(IntPtr)obj17 + 16L;
				if (!flag10)
				{
					continue;
				}
				goto IL_03ec;
			}
			object obj18 = obj17 + 1;
			int num15 = (int)((long)(IntPtr)obj18 << 4);
			object obj19 = (long)intPtr9 + (long)num15;
			IntPtr intPtr10 = (IntPtr)0;
			Action<bool> action3 = action;
			Action<bool> action4 = action2;
			goto IL_0c3f;
			IL_06e6:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0b84;
			IL_0b84:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (UnityEngine.Purchasing.IAPButton)+8]");
			IMoolahExtension extension2 = ((IExtensionProvider)0).GetExtension<IMoolahExtension>();
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1064 @ X0_v87 (UnityEngine.Purchasing.IMoolahExtension)] (should have been resolved before IL gen)");
			Action<RestoreTransactionIDState> action5 = delegate(RestoreTransactionIDState restoreTransactionIDState)
			{
				//IL_0012: Expected I4, but got I8
				int num22 = (int)((long)restoreTransactionIDState & 0xFFFFFFFEL);
				int num23 = num22 - 2;
				bool flag20 = num23 == 0;
				bool success = !flag20;
				OnTransactionsRestored(success);
			};
			Action<bool> action6 = default(Action<bool>);
			IntPtr intPtr11 = (IntPtr)action6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1152 @ X8_v30 (Il2CppClass<System.Action`1<System.Boolean>>)+126]");
			bool flag11 = (IntPtr)0 == (IntPtr)0;
			intPtr10 = (IntPtr)0;
			action3 = (Action<bool>)(object)action5;
			IntPtr intPtr12 = (IntPtr)typeof(IMoolahExtension);
			action4 = action6;
			if (flag11)
			{
				goto IL_09ce;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1152 @ X8_v30 (Il2CppClass<System.Action`1<System.Boolean>>)+B0]");
			object obj20 = 0L + 8L;
			int num16 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v882 @ X11_v30-8]");
				bool flag12 = (IntPtr)0 == (IntPtr)typeof(IMoolahExtension);
				intPtr10 = (IntPtr)0;
				action3 = (Action<bool>)(object)action5;
				action4 = action6;
				if (flag12)
				{
					break;
				}
				num16++;
				int num17 = num16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1152 @ X8_v30 (Il2CppClass<System.Action`1<System.Boolean>>)+126]");
				bool flag13 = (long)num17 < 0L;
				bool flag14 = !flag13;
				obj20 = (long)(IntPtr)obj20 + 16L;
				bool flag15 = !flag14;
				intPtr10 = (IntPtr)0;
				action3 = (Action<bool>)(object)action5;
				intPtr12 = (IntPtr)typeof(IMoolahExtension);
				action4 = action6;
				if (flag15)
				{
					continue;
				}
				goto IL_09ce;
			}
			goto IL_09e4;
			IL_0c3f:
			Action<bool> action7 = (Action<bool>)((long)(IntPtr)obj19 + 304L);
			goto IL_0afc;
			IL_0afc:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v918 @ X0_v36 (System.Action`1<System.Boolean>)] (should have been resolved before IL gen)");
			return;
			IL_03ec:
			intPtr10 = (IntPtr)0;
			action3 = action;
			int num18 = 1;
			intPtr12 = (IntPtr)typeof(IAppleExtensions);
			action4 = action2;
			goto IL_0afc;
			IL_059b:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0b2d;
			IL_09e4:
			int num19 = obj20 << 4;
			obj19 = (long)intPtr11 + (long)num19;
			goto IL_0c3f;
			IL_0b2d:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (UnityEngine.Purchasing.IAPButton)+8]");
			ISamsungAppsExtensions extension3 = ((IExtensionProvider)0).GetExtension<ISamsungAppsExtensions>();
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v991 @ X0_v104 (UnityEngine.Purchasing.ISamsungAppsExtensions)] (should have been resolved before IL gen)");
			Action<bool> action8 = OnTransactionsRestored;
			Action<bool> action9 = default(Action<bool>);
			intPtr11 = (IntPtr)action9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1152 @ X8_v30 (Il2CppClass<System.Action`1<System.Boolean>>)+126]");
			bool flag16 = (IntPtr)0 == (IntPtr)0;
			intPtr10 = (IntPtr)0;
			action3 = action8;
			intPtr12 = (IntPtr)typeof(ISamsungAppsExtensions);
			action4 = action9;
			if (flag16)
			{
				goto IL_09ce;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1152 @ X8_v30 (Il2CppClass<System.Action`1<System.Boolean>>)+B0]");
			obj20 = 0L + 8L;
			int num20 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v882 @ X11_v30-8]");
				bool flag17 = (IntPtr)0 == (IntPtr)typeof(ISamsungAppsExtensions);
				intPtr10 = (IntPtr)0;
				action3 = action8;
				action4 = action9;
				if (flag17)
				{
					break;
				}
				num20++;
				int num21 = num20;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1152 @ X8_v30 (Il2CppClass<System.Action`1<System.Boolean>>)+126]");
				bool flag18 = (long)num21 < 0L;
				bool flag19 = !flag18;
				obj20 = (long)(IntPtr)obj20 + 16L;
				if (!flag19)
				{
					continue;
				}
				goto IL_086f;
			}
			goto IL_09e4;
			IL_086f:
			intPtr10 = (IntPtr)0;
			action3 = action8;
			intPtr12 = (IntPtr)typeof(ISamsungAppsExtensions);
			action4 = action9;
			goto IL_09ce;
			IL_0148:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0a49;
			IL_09ce:
			num18 = 0;
			action2 = action4;
			goto IL_0afc;
			IL_0a49:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (UnityEngine.Purchasing.IAPButton)+8]");
			IMicrosoftExtensions extension4 = ((IExtensionProvider)0).GetExtension<IMicrosoftExtensions>();
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v527 @ X0_v14 (UnityEngine.Purchasing.IMicrosoftExtensions)] (should have been resolved before IL gen)");
			IMicrosoftExtensions microsoftExtensions = default(IMicrosoftExtensions);
			microsoftExtensions.RestoreTransactions();
			return;
			IL_02ea:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0a9d;
		}

		[Token(Token = "0x6000031")]
		[Address(RVA = "0x160D470", Offset = "0x160D470", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = &v7 @ stack_-10_v2;\n\t*([v6 @ X29_v1-4]) = success;\n\tgoto L_0013;\n\tv16 = *([1EB1B28]);\n\tv17 = *([v16 @ X8_v10]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, success, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 0 | 1;\n\t*([202A202]) = v36;\nL_0013:\n\tv37 = &v7 @ stack_-10_v2 - 4;\n\tv39 = 0xE8F14C(v37, 0, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv46 = System.String::Concat(\"Transactions restored: \", v39);\n\tgoto L_002D;\n\tv54 = *([v50 @ X8_v8+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_002D;\n\tv63 = v50;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v63, v42, v43, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_002D:\n\tUnityEngine.Debug::Log(v46);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnTransactionsRestored(bool success)
		{
			//IL_002b: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			object obj3 = (long)(IntPtr)obj2 - 4L;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E8F14C (inside System.BitConverter::.cctor +0x64)");
			string text = default(string);
			string message = "Transactions restored: " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x6000032")]
		[Address(RVA = "0x160C414", Offset = "0x160C414", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1F10E98]);\n\tv23 = *([v22 @ X8_v18]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, e, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A203]) = v41;\nL_0017:\n\tv43 = e.<purchasedProduct>k__BackingField;\n\tv48 = v43.<definition>k__BackingField;\n\tv72 = System.String::Format(\"IAPButton.ProcessPurchase(PurchaseEventArgs {0} - {1})\", e, v48.<id>k__BackingField);\n\tgoto L_0034;\n\tv99 = *([v64 @ X8_v11+E0]);\n\tv100 = v99 == 0;\n\tv101 = ~v100;\n\tif (v101) goto L_0034;\n\tv106 = v64;\n\tv103 = \"il2cpp_codegen_runtime_class_init\"(v106, v70, v58, v54, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0034:\n\tUnityEngine.Debug::Log(v72);\n\tUnityEngine.Events.UnityEvent`1<UnityEngine.Purchasing.Product>::Invoke(this.onPurchaseComplete, e.<purchasedProduct>k__BackingField);\n\tv94 = this.consumePurchase ^ 1;\n\treturnVal2 = v94 & 0xFF;\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
		{
			Product purchasedProduct = e.purchasedProduct;
			ProductDefinition definition = purchasedProduct.definition;
			string message = $"IAPButton.ProcessPurchase(PurchaseEventArgs {e} - {definition.id})";
			Debug.Log(message);
			onPurchaseComplete.Invoke(e.purchasedProduct);
			int num = (consumePurchase ? 1 : 0) ^ 1;
			return (PurchaseProcessingResult)(num & 0xFF);
		}

		[Token(Token = "0x6000033")]
		[Address(RVA = "0x160BCE4", Offset = "0x160BCE4", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EEF600]);\n\tv27 = *([v26 @ X8_v15]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, product, reason, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202A204]) = v44;\nL_001C:\n\t// 28 Box v50 @ X0_v3 (System.Object), typeof(UnityEngine.Purchasing.PurchaseFailureReason), &reason @ X2 (UnityEngine.Purchasing.PurchaseFailureReason)\n\tv58 = System.String::Format(\"IAPButton.OnPurchaseFailed(Product {0}, PurchaseFailureReason {1})\", product, v50);\n\tgoto L_0035;\n\tv66 = *([v62 @ X8_v10+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tgoto L_0035;\n\tv75 = v62;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v75, v54, v53, v55, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0035:\n\tUnityEngine.Debug::Log(v58);\n\tUnityEngine.Events.UnityEvent`2<UnityEngine.Purchasing.Product, UnityEngine.Purchasing.PurchaseFailureReason>::Invoke(this.onPurchaseFailed, product, reason);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
		{
			object arg = reason;
			string message = $"IAPButton.OnPurchaseFailed(Product {product}, PurchaseFailureReason {arg})";
			Debug.Log(message);
			onPurchaseFailed.Invoke(product, reason);
		}

		[Token(Token = "0x6000034")]
		[Address(RVA = "0x160BEF4", Offset = "0x160BEF4", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1F10A68]);\n\tv23 = *([v22 @ X8_v24]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202A205]) = v42;\nL_0015:\n\tv43 = UnityEngine.Purchasing.CodelessIAPStoreListener::get_Instance();\n\tv46 = UnityEngine.Purchasing.CodelessIAPStoreListener::GetProduct(v43, v40.productId);\n\tv80 = v46 == 0;\n\tif (v80) goto L_0084;\n\tgoto L_002D;\n\tv119 = *([v99 @ X0_v10+E0]);\n\tv120 = v119 == 0;\n\tv121 = ~v120;\n\tif (v121) goto L_002D;\n\tv123 = \"il2cpp_codegen_runtime_class_init\"(v99, v45, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002D:\n\tv87 = UnityEngine.Object::op_Inequality(v40.titleText, 0);\n\tv151 = v87 == 0;\n\tif (v151) goto L_0041;\n\tv74 = v46.<metadata>k__BackingField;\n\tv158 = UnityEngine.UI.Text::set_text(v40.titleText, v74.<localizedTitle>k__BackingField);\nL_0041:\n\tgoto L_004A;\n\tv166 = *([v162 @ X0_v15+E0]);\n\tv167 = v166 == 0;\n\tv168 = ~v167;\n\tgoto L_004A;\n\tv170 = \"il2cpp_codegen_runtime_class_init\"(v162, v155, v153, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_004A:\n\tv88 = UnityEngine.Object::op_Inequality(v40.descriptionText, 0);\n\tv175 = v88 == 0;\n\tif (v175) goto L_005E;\n\tv75 = v46.<metadata>k__BackingField;\n\tv182 = UnityEngine.UI.Text::set_text(v40.descriptionText, v75.<localizedDescription>k__BackingField);\nL_005E:\n\tgoto L_0067;\n\tv190 = *([v186 @ X0_v20+E0]);\n\tv191 = v190 == 0;\n\tv192 = ~v191;\n\tgoto L_0067;\n\tv194 = \"il2cpp_codegen_runtime_class_init\"(v186, v179, v177, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0067:\n\tv89 = UnityEngine.Object::op_Inequality(v40.priceText, 0);\n\tv110 = v89 == 0;\n\tif (v110) goto L_0084;\n\tv76 = v46.<metadata>k__BackingField;\n\tv68 = v40.priceText;\n\tv132 = *([v68 @ X0_v24 (UnityEngine.UI.Text)]);\n\tv140 = v76.<localizedPriceString>k__BackingField;\n\tv128 = *([v132 @ X9_v6 (Il2CppClass<UnityEngine.UI.Text>)+5C0]);\n\tv134 = *([v132 @ X9_v6 (Il2CppClass<UnityEngine.UI.Text>)+5C8]);\n\t// 124 IndirectJump v128 @ X3_v1, v68 @ X0_v24 (UnityEngine.UI.Text), v68 @ X0_v24 (UnityEngine.UI.Text), v140 @ X1_v10 (System.String), v134 @ X2_v9, v128 @ X3_v1, v28 @ X4, v29 @ X5, v30 @ X6, v31 @ X7, v32 @ V0, v33 @ V1, v34 @ V2, v35 @ V3, v36 @ V4, v37 @ V5, v38 @ V6, v39 @ V7\nL_0084:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void UpdateText()
		{
			//IL_0140: Expected I, but got O
			//IL_015d: Expected O, but got I
			//IL_016d: Expected O, but got I
			CodelessIAPStoreListener instance = CodelessIAPStoreListener.Instance;
			Product product = instance.GetProduct(productId);
			if (product != null)
			{
				if (titleText != null)
				{
					ProductMetadata metadata = product.metadata;
					titleText.text = metadata.localizedTitle;
				}
				if (descriptionText != null)
				{
					ProductMetadata metadata2 = product.metadata;
					descriptionText.text = metadata2.localizedDescription;
				}
				if (priceText != null)
				{
					ProductMetadata metadata3 = product.metadata;
					Text text = priceText;
					IntPtr intPtr = (IntPtr)text;
					string localizedPriceString = metadata3.localizedPriceString;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ X9_v6 (Il2CppClass<UnityEngine.UI.Text>)+5C0]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ X9_v6 (Il2CppClass<UnityEngine.UI.Text>)+5C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v128 @ X3_v1 (should have been resolved before IL gen)");
				}
			}
		}

		[Token(Token = "0x6000035")]
		[Address(RVA = "0x160D510", Offset = "0x160D510", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.consumePurchase = 1;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IAPButton()
		{
			consumePurchase = true;
		}
	}
}
