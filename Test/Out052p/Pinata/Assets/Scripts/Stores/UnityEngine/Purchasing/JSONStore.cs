using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.Purchasing.Extension;
using UnityEngine.Purchasing.MiniJSON;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200004A")]
	internal class JSONStore : AbstractStore, IUnityCallback, IManagedStoreExtensions, IStoreExtension, IStoreInternal, IManagedStoreConfig, IStoreConfiguration, ITransactionHistoryExtensions
	{
		[Token(Token = "0x40000CA")]
		[FieldOffset(Offset = "0x10")]
		private StoreCatalogImpl m_managedStore;

		[Token(Token = "0x40000CB")]
		[FieldOffset(Offset = "0x18")]
		protected internal IStoreCallback unity;

		[Token(Token = "0x40000CC")]
		[FieldOffset(Offset = "0x20")]
		internal INativeStore store;

		[Token(Token = "0x40000CD")]
		[FieldOffset(Offset = "0x28")]
		private List<ProductDefinition> m_storeCatalog;

		[Token(Token = "0x40000CE")]
		[FieldOffset(Offset = "0x30")]
		private bool isManagedStoreEnabled;

		[Token(Token = "0x40000CF")]
		[FieldOffset(Offset = "0x38")]
		private ProfileData m_profileData;

		[Token(Token = "0x40000D0")]
		[FieldOffset(Offset = "0x40")]
		private bool isRefreshing;

		[Token(Token = "0x40000D1")]
		[FieldOffset(Offset = "0x41")]
		private bool isFirstTimeRetrievingProducts;

		[Token(Token = "0x40000D2")]
		[FieldOffset(Offset = "0x48")]
		private Action refreshCallback;

		[Token(Token = "0x40000D3")]
		[FieldOffset(Offset = "0x50")]
		private StandardPurchasingModule m_Module;

		[Token(Token = "0x40000D4")]
		[FieldOffset(Offset = "0x58")]
		private HashSet<ProductDefinition> m_BuilderProducts;

		[Token(Token = "0x40000D5")]
		[FieldOffset(Offset = "0x60")]
		protected internal ILogger m_Logger;

		[Token(Token = "0x40000D6")]
		[FieldOffset(Offset = "0x68")]
		private EventQueue m_EventQueue;

		[Token(Token = "0x40000D7")]
		[FieldOffset(Offset = "0x70")]
		private Dictionary<string, object> promoPayload;

		[Token(Token = "0x40000D8")]
		[FieldOffset(Offset = "0x78")]
		private bool catalogDisabled;

		[Token(Token = "0x40000D9")]
		[FieldOffset(Offset = "0x79")]
		private bool testStore;

		[Token(Token = "0x40000DA")]
		[FieldOffset(Offset = "0x80")]
		private string iapBaseUrl;

		[Token(Token = "0x40000DB")]
		[FieldOffset(Offset = "0x88")]
		private string eventBaseUrl;

		[Token(Token = "0x40000DC")]
		[FieldOffset(Offset = "0x90")]
		protected internal PurchaseFailureDescription lastPurchaseFailureDescription;

		[Token(Token = "0x40000DD")]
		[FieldOffset(Offset = "0x98")]
		private StoreSpecificPurchaseErrorCode _lastPurchaseErrorCode;

		[Token(Token = "0x40000DE")]
		[FieldOffset(Offset = "0xA0")]
		private string kStoreSpecificErrorCodeKey;

		[Token(Token = "0x17000026")]
		public Product[] storeCatalog
		{
			[Token(Token = "0x600010F")]
			[Address(RVA = "0xC632F0", Offset = "0xC632F0", Length = "0x398")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv32 = *([1F0CED8]);\n\tv33 = *([v32 @ X8_v59]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2023349]) = v52;\nL_0020:\n\tv59 = new System.Collections.Generic.List`1<UnityEngine.Purchasing.Product>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.Product>::.ctor(v59);\n\tv65 = this.m_storeCatalog == 0;\n\tif (v65) goto L_0155;\n\tgoto L_0059;\n\tv261 = *([v166 @ X8_v16+B0]);\n\tv262 = 0;\n\tv263 = v261 + 8;\n\tv265 = *([v349 @ X11_v21-8]);\n\tv354 = v265 == v168;\n\tif (v354) goto L_0052;\n\tv285 = v348 + 1;\n\tv460 = v285 < v167;\n\tv283 = ~v460;\n\tv287 = v349 + 0x10;\n\tv267 = ~v283;\n\tif (v267) goto L_FFFFFFFF;\n\tv288 = v66;\n\tv289 = 0;\n\tv290 = 0x8909C4(v288, v168, v289, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_0059;\nL_0052:\n\tv461 = *([v349 @ X11_v21]);\n\tv462 = v461 << 4;\n\tv463 = v166 + v462;\n\tv464 = v463 + 0x130;\nL_0059:\n\tv155 = UnityEngine.Purchasing.Extension.IStoreCallback::get_products(this.unity);\n\tv158 = v155.m_Products == 0;\n\tif (v158) goto L_0155;\n\tv476 = System.Collections.Generic.List`1<UnityEngine.Purchasing.ProductDefinition>::GetEnumerator(this.m_storeCatalog);\n\tgoto L_010A;\nL_0078:\n\tgoto L_009F;\n\tv580 = *([v534 @ X8_v32+B0]);\n\tv581 = 0;\n\tv582 = v580 + 8;\n\tv584 = *([v656 @ X11_v16-8]);\n\tv661 = v584 == v535;\n\tif (v661) goto L_0098;\n\tv604 = v655 + 1;\n\tv677 = v604 < v536;\n\tv602 = ~v677;\n\tv606 = v656 + 0x10;\n\tv586 = ~v602;\n\tif (v586) goto L_FFFFFFFF;\n\tv607 = v511;\n\tv608 = 0;\n\tv609 = 0x8909C4(v607, v535, v608, v37, v38, v39, v40, v41, v87, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_009F;\nL_0098:\n\tv678 = *([v656 @ X11_v16]);\n\tv679 = v678 << 4;\n\tv680 = v534 + v679;\n\tv681 = v680 + 0x130;\nL_009F:\n\tv517 = UnityEngine.Purchasing.Extension.IStoreCallback::get_products(this.unity);\n\tv483 = v517.m_Products;\n\tv520 = v517.m_Products == 0;\n\tif (v520) goto L_012A;\n\tv706 = v483.Length;\n\tv490 = v483.Length < 1;\n\tif (v490) goto L_010A;\nL_00B3:\n\tv707 = v540 < v706;\n\tv708 = ~v707;\n\tif (v708) goto L_0118;\n\tv510 = v483[v540 @ X27_v13 (System.Int32)];\n\tv722 = v510.<definition>k__BackingField;\n\tv737 = v722.<type>k__BackingField == 0;\n\tif (v737) goto L_00E2;\n\tv749 = UnityEngine.Purchasing.Product::get_hasReceipt(v483[v540 @ X27_v13 (System.Int32)]);\n\tv800 = v749 == 0;\n\tif (v800) goto L_00D2;\n\tgoto L_00DA;\nL_00D2:\n\tv836 = System.String::IsNullOrEmpty(v510.<transactionID>k__BackingField);\n\tv839 = ~v836;\nL_00DA:\n\tv761 = v840 == 0;\n\tv751 = ~v761;\nL_00E2:\n\tv777 = v774 == 0;\n\tv778 = ~v777;\n\tif (v778) goto L_00FA;\n\tv802 = ~v510.<availableToPurchase>k__BackingField;\n\tif (v802) goto L_00FA;\n\tv796 = v510.<definition>k__BackingField;\n\tv808 = System.String::op_Equality(v796.<storeSpecificId>k__BackingField, *([v478 @ stack_-88+18]));\n\tv810 = v808 == 0;\n\tif (v810) goto L_00FA;\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.Product>::Add(v59, v483[v540 @ X27_v13 (System.Int32)]);\nL_00FA:\n\tv706 = v483.Length;\n\tv540 = v540 + 1;\n\tv489 = v540 < v483.Length;\n\tif (v489) goto L_00B3;\nL_010A:\n\tv526 = System.Collections.Generic.List`1<UnityEngine.Purchasing.ProductDefinition>+Enumerator<UnityEngine.Purchasing.ProductDefinition>::MoveNext(&v89 @ stack_-98_v7 (System.Collections.Generic.List`1<UnityEngine.Purchasing.ProductDefinition>+Enumerator<UnityEngine.Purchasing.ProductDefinition>));\n\tv528 = v526 == 0;\n\tv529 = ~v528;\n\tif (v529) goto L_0078;\n\tv218 = System.Collections.Generic.List`1<UnityEngine.Purchasing.ProductDefinition>+Enumerator<UnityEngine.Purchasing.ProductDefinition>::Dispose(&v89 @ stack_-98_v7 (System.Collections.Generic.List`1<UnityEngine.Purchasing.ProductDefinition>+Enumerator<UnityEngine.Purchasing.ProductDefinition>));\n\tv533 = v59 == 0;\n\tv220 = ~v533;\n\tif (v220) goto L_0155;\n\tgoto L_0164;\nL_0118:\n\tv720 = new System.IndexOutOfRangeException();\n\tthrow v720;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv579 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_012A:\n\tv387 = new System.NullReferenceException();\n\tgoto L_0142;\n\tgoto L_0142;\n\tgoto L_0142;\n\tgoto L_0142;\n\tgoto L_0142;\n\tgoto L_0142;\n\tgoto L_0142;\n\tgoto L_0142;\n\tgoto L_0142;\n\tgoto L_0142;\n\tgoto L_0142;\n\tgoto L_0142;\n\tgoto L_0142;\n\tgoto L_0142;\nL_0142:\n\tv99 = 0 != 1;\n\tif (v99) goto L_0165;\n\tv688 = System.Collections.Generic.List`1<UnityEngine.Purchasing.Product>::Add(v387, 0);\n\tv690 = System.Collections.Generic.List`1<UnityEngine.Purchasing.Product>::Add(v688, 0);\n\tv154 = System.Collections.Generic.List`1<UnityEngine.Purchasing.ProductDefinition>+Enumerator<UnityEngine.Purchasing.ProductDefinition>::Dispose(&v89 @ stack_-98_v7 (System.Collections.Generic.List`1<UnityEngine.Purchasing.ProductDefinition>+Enumerator<UnityEngine.Purchasing.ProductDefinition>));\n\tv721 = *([v688 @ X0_v30 (System.Collections.Generic.List`1<UnityEngine.Purchasing.Product>)]) == 0;\n\tv157 = ~v721;\n\tif (v157) goto L_0169;\nL_0155:\n\treturnVal1 = System.Collections.Generic.List`1<UnityEngine.Purchasing.Product>::ToArray(v59);\n\treturn returnVal1;\nL_0164:\n\tv387 = new System.NullReferenceException();\nL_0165:\n\tv394 = System.Collections.Generic.List`1<UnityEngine.Purchasing.Product>::.ctor(v387);\nL_0169:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 223 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_01b7: Expected O, but got I
				List<Product> list = new List<Product>();
				if (m_storeCatalog != null)
				{
					ProductCollection products = unity.products;
					if (products.all != null)
					{
						List<ProductDefinition>.Enumerator enumerator = m_storeCatalog.GetEnumerator();
						List<ProductDefinition>.Enumerator enumerator2 = default(List<ProductDefinition>.Enumerator);
						List<Product> list2 = default(List<Product>);
						while (true)
						{
							if (enumerator2.MoveNext())
							{
								ProductCollection products2 = unity.products;
								Product[] all = products2.all;
								if (products2.all != null)
								{
									int num = all.Length;
									if (all.Length < 1)
									{
										continue;
									}
									int num2 = 0;
									do
									{
										if (num2 < num)
										{
											Product product = all[num2];
											ProductDefinition definition = product.definition;
											bool flag = definition.type == ProductType.Consumable;
											bool flag2 = (byte)definition.type != 0;
											if (!flag)
											{
												int num3;
												if (all[num2].hasReceipt)
												{
													num3 = 1;
												}
												else
												{
													bool flag3 = string.IsNullOrEmpty(product.transactionID);
													bool flag4 = !flag3;
													num3 = (flag4 ? 1 : 0);
												}
												bool flag5 = num3 == 0;
												bool flag6 = !flag5;
												flag2 = flag6;
											}
											if (!flag2 && product.availableToPurchase)
											{
												ProductDefinition definition2 = product.definition;
												string storeSpecificId = definition2.storeSpecificId;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v478 @ stack_-88+18]");
												if (storeSpecificId == (string)0)
												{
													list.Add(all[num2]);
												}
											}
											num = all.Length;
											num2++;
											continue;
										}
										IndexOutOfRangeException ex = new IndexOutOfRangeException();
										throw ex;
									}
									while (num2 < all.Length);
									continue;
								}
								NullReferenceException ex2 = new NullReferenceException();
								if (0 == 1)
								{
									((List<Product>)(object)ex2).Add((Product)null);
									list2.Add(null);
									enumerator2.Dispose();
									if (list2 == null)
									{
										break;
									}
								}
							}
							else
							{
								enumerator2.Dispose();
								if (list != null)
								{
									break;
								}
								NullReferenceException ex2 = (NullReferenceException)(object)new List<Product>();
							}
							return (Product[])(object)new TypeLoadException();
						}
					}
				}
				return list.ToArray();
			}
		}

		[Token(Token = "0x6000110")]
		[Address(RVA = "0xC57D28", Offset = "0xC57D28", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EB9030]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202334A]) = v38;\nL_0014:\n\tthis.isRefreshing = 0;\n\tthis.isManagedStoreEnabled = 1;\n\tthis.isFirstTimeRetrievingProducts = 1;\n\tv43 = new System.Collections.Generic.HashSet`1<UnityEngine.Purchasing.ProductDefinition>();\n\tSystem.Collections.Generic.HashSet`1<UnityEngine.Purchasing.ProductDefinition>::.ctor(v43);\n\tthis.m_BuilderProducts = v43;\n\tthis.promoPayload = 0;\n\tthis.catalogDisabled = 0;\n\tthis.iapBaseUrl = 0;\n\tthis._lastPurchaseErrorCode = 0x21;\n\tthis.eventBaseUrl = \"https://events.iap.unity3d.com/events\";\n\tthis.kStoreSpecificErrorCodeKey = \"storeSpecificErrorCode\";\n\tUnityEngine.Purchasing.Extension.AbstractStore::.ctor(this);\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public JSONStore()
		{
			isRefreshing = false;
			isManagedStoreEnabled = true;
			isFirstTimeRetrievingProducts = true;
			HashSet<ProductDefinition> builderProducts = new HashSet<ProductDefinition>();
			m_BuilderProducts = builderProducts;
			promoPayload = null;
			catalogDisabled = false;
			testStore = false;
			iapBaseUrl = null;
			_lastPurchaseErrorCode = StoreSpecificPurchaseErrorCode.Unknown;
			eventBaseUrl = "https://events.iap.unity3d.com/events";
			kStoreSpecificErrorCodeKey = "storeSpecificErrorCode";
		}

		[Token(Token = "0x6000111")]
		[Address(RVA = "0xC57ED0", Offset = "0xC57ED0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.store = native;\n\treturn;\n")]
		public void SetNativeStore(INativeStore native)
		{
			store = native;
		}

		[Token(Token = "0x6000112")]
		[Address(RVA = "0xC63688", Offset = "0xC63688", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EA8190]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, module, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202334B]) = v41;\nL_0015:\n\tv42 = module == 0;\n\tif (v42) goto L_0031;\n\tthis.m_Module = module;\n\tv47 = module.<logger>k__BackingField;\n\tv44 = module.<logger>k__BackingField == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_002A;\n\tgoto L_0029;\n\tv66 = *([v59 @ X0_v5+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tif (v68) goto L_0029;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v59, module, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0029:\n\tv47 = UnityEngine.Debug::get_unityLogger();\nL_002A:\n\tthis.m_Logger = v47;\nL_0031:\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		void IStoreInternal.SetModule(StandardPurchasingModule module)
		{
			if (module != null)
			{
				m_Module = module;
				ILogger logger = module.logger;
				if (module.logger == null)
				{
					logger = Debug.unityLogger;
				}
				m_Logger = logger;
			}
		}

		[Token(Token = "0x6000113")]
		[Address(RVA = "0xC5F168", Offset = "0xC5F168", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EFAEE8]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202334C]) = v41;\nL_0015:\n\tv42 = this.m_Module;\n\tthis.unity = callback;\n\tv46 = UnityEngine.Purchasing.EventQueue::Instance(v42.<util>k__BackingField, v42.<webUtil>k__BackingField);\n\tv60 = this.m_Module;\n\tthis.m_EventQueue = v46;\n\tv50 = UnityEngine.Purchasing.ProfileData::Instance(v60.<util>k__BackingField);\n\tv146 = this.m_Module;\n\tthis.m_profileData = v50;\n\tv147 = this.m_Module == 0;\n\tif (v147) goto L_0050;\n\tv61 = v146.<storeInstance>k__BackingField;\n\tv170 = System.String::IsNullOrEmpty(v61.<storeName>k__BackingField);\n\tv202 = v170 == 0;\n\tv203 = ~v202;\n\tif (v203) goto L_0037;\n\tv50.<StoreName>k__BackingField = v61.<storeName>k__BackingField;\nL_0037:\n\tv51 = System.String::IsNullOrEmpty(this.iapBaseUrl);\n\tv235 = v51 == 0;\n\tif (v235) goto L_003F;\n\tthis.iapBaseUrl = \"https://ecommerce.iap.unity3d.com\";\nL_003F:\n\tv62 = this.m_Module;\n\tv165 = UnityEngine.Purchasing.StoreCatalogImpl::CreateInstance(v61.<storeName>k__BackingField, this.iapBaseUrl, v62.<webUtil>k__BackingField, v62.<logger>k__BackingField, v62.<util>k__BackingField);\n\tthis.m_managedStore = v165;\nL_004F:\n\treturn;\nL_0050:\n\tv148 = this.m_Logger;\n\tv149 = this.m_Logger == 0;\n\tif (v149) goto L_004F;\n\tv152 = *([v148 @ X19_v4 (UnityEngine.ILogger)]);\n\tv130 = *([v152 @ X8_v8 (Il2CppClass<UnityEngine.ILogger>)+126]) == 0;\n\tif (v130) goto L_007D;\n\tv214 = *([v152 @ X8_v8 (Il2CppClass<UnityEngine.ILogger>)+B0]) + 8;\nL_0068:\n\tv220 = *([v214 @ X11_v5-8]) == UnityEngine.ILogger;\n\tif (v220) goto L_0080;\n\tv215 = v215 + 1;\n\tv226 = v215 < *([v152 @ X8_v8 (Il2CppClass<UnityEngine.ILogger>)+126]);\n\tv193 = ~v226;\n\tv214 = v214 + 0x10;\n\tv177 = ~v193;\n\tif (v177) goto L_0068;\nL_007D:\n\tv233 = 0x8909C4(this.m_Logger, UnityEngine.ILogger, 6, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_008F;\nL_0080:\n\tv228 = *([v214 @ X11_v5]) + 6;\n\tv229 = v228 << 4;\n\tv230 = v152 + v229;\n\tv233 = v230 + 0x130;\nL_008F:\n\t// 143 IndirectJump [v233 @ X0_v10], this.m_Logger (UnityEngine.ILogger), this.m_Logger (UnityEngine.ILogger), \"UnityIAP\", \"JSONStore init has no reference to SPM, can't start managed store\", [v233 @ X0_v10+8], [v233 @ X0_v10], v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Initialize(IStoreCallback callback)
		{
			//IL_0164: Expected I, but got O
			//IL_019f: Expected O, but got I
			//IL_021c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0221: Expected O, but got Unknown
			//IL_023e: Expected O, but got I
			//IL_024d: Expected O, but got I
			//IL_01eb: Expected O, but got I
			StandardPurchasingModule module = m_Module;
			unity = callback;
			EventQueue eventQueue = EventQueue.Instance(module.util, module.webUtil);
			StandardPurchasingModule module2 = m_Module;
			m_EventQueue = eventQueue;
			ProfileData profileData = ProfileData.Instance(module2.util);
			StandardPurchasingModule module3 = m_Module;
			m_profileData = profileData;
			if (m_Module != null)
			{
				StandardPurchasingModule.StoreInstance storeInstance = module3.storeInstance;
				if (!string.IsNullOrEmpty(storeInstance.storeName))
				{
					profileData.StoreName = storeInstance.storeName;
				}
				if (string.IsNullOrEmpty(iapBaseUrl))
				{
					iapBaseUrl = "https://ecommerce.iap.unity3d.com";
				}
				StandardPurchasingModule module4 = m_Module;
				StoreCatalogImpl managedStore = StoreCatalogImpl.CreateInstance(storeInstance.storeName, iapBaseUrl, module4.webUtil, module4.logger, module4.util);
				m_managedStore = managedStore;
				return;
			}
			ILogger logger = m_Logger;
			if (m_Logger == null)
			{
				return;
			}
			IntPtr intPtr = (IntPtr)logger;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ X8_v8 (Il2CppClass<UnityEngine.ILogger>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0204;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ X8_v8 (Il2CppClass<UnityEngine.ILogger>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ILogger))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ X8_v8 (Il2CppClass<UnityEngine.ILogger>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_0204;
			}
			object obj2 = obj + 6;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_02d1;
			IL_02d1:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v233 @ X0_v10] (should have been resolved before IL gen)");
			return;
			IL_0204:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_02d1;
		}

		[Token(Token = "0x6000114")]
		[Address(RVA = "0xC638DC", Offset = "0xC638DC", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EA7770]);\n\tv23 = *([v22 @ X8_v25]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, products, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202334D]) = v41;\nL_0016:\n\tv43 = ~this.isManagedStoreEnabled;\n\tif (v43) goto L_0043;\n\tv45 = this.m_managedStore == 0;\n\tif (v45) goto L_0043;\n\tv54 = ~this.isRefreshing;\n\tv55 = ~v54;\n\tif (v55) goto L_0025;\n\tv47 = ~this.isFirstTimeRetrievingProducts;\n\tif (v47) goto L_0043;\nL_0025:\n\tv63 = new System.Collections.Generic.HashSet`1<UnityEngine.Purchasing.ProductDefinition>();\n\tSystem.Collections.Generic.HashSet`1<UnityEngine.Purchasing.ProductDefinition>::.ctor(v63, products);\n\tthis.m_BuilderProducts = v63;\n\tv80 = new System.Action`1<System.Collections.Generic.List`1<UnityEngine.Purchasing.ProductDefinition>>();\n\tSystem.Action`1<System.Collections.Generic.List`1<UnityEngine.Purchasing.ProductDefinition>>::.ctor(v80, this, Il2CppMethodInfo);\n\tUnityEngine.Purchasing.StoreCatalogImpl::FetchProducts(this.m_managedStore, v80);\n\tgoto L_0076;\nL_0043:\n\tv52 = UnityEngine.Purchasing.JSONSerializer::SerializeProductDefs(products);\n\tgoto L_0075;\n\tv96 = *([v65 @ X8_v7+B0]);\n\tv97 = 0;\n\tv98 = v96 + 8;\n\tv100 = *([v150 @ X11_v6-8]);\n\tv156 = v100 == v68;\n\tif (v156) goto L_006D;\n\tv133 = v151 + 1;\n\tv215 = v133 < v67;\n\tv127 = ~v215;\n\tv130 = v150 + 0x10;\n\tv103 = ~v127;\n\tif (v103) goto L_FFFFFFFF;\n\tv134 = v50;\n\tv135 = 0;\n\tv136 = 0x8909C4(v134, v68, v135, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0075;\nL_006D:\n\tv216 = *([v150 @ X11_v6]);\n\tv217 = v216 << 4;\n\tv218 = v65 + v217;\n\tv219 = v218 + 0x130;\nL_0075:\n\tUnityEngine.Purchasing.INativeStore::RetrieveProducts(this.store, v52);\nL_0076:\n\tthis.isFirstTimeRetrievingProducts = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void RetrieveProducts(ReadOnlyCollection<ProductDefinition> products)
		{
			if (isManagedStoreEnabled && m_managedStore != null && (isRefreshing || isFirstTimeRetrievingProducts))
			{
				HashSet<ProductDefinition> builderProducts = new HashSet<ProductDefinition>((IEqualityComparer<ProductDefinition>)products);
				m_BuilderProducts = builderProducts;
				Action<List<ProductDefinition>> callback = ProcessManagedStoreResponse;
				m_managedStore.FetchProducts(callback);
			}
			else
			{
				string json = JSONSerializer.SerializeProductDefs(products);
				store.RetrieveProducts(json);
			}
			isFirstTimeRetrievingProducts = false;
		}

		[Token(Token = "0x6000115")]
		[Address(RVA = "0xC63BA4", Offset = "0xC63BA4", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1F06F30]);\n\tv25 = *([v24 @ X8_v20]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, storeProducts, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202334E]) = v43;\nL_0017:\n\tthis.m_storeCatalog = storeProducts;\n\tv45 = ~this.isRefreshing;\n\tif (v45) goto L_0026;\n\tthis.isRefreshing = 0;\n\tv47 = UnityEngine.Purchasing.JSONStore::get_storeCatalog(this);\n\tv51 = v47.Length == 0;\n\tif (v51) goto L_0074;\nL_0026:\n\tv59 = new System.Collections.Generic.HashSet`1<UnityEngine.Purchasing.ProductDefinition>();\n\tSystem.Collections.Generic.HashSet`1<UnityEngine.Purchasing.ProductDefinition>::.ctor(v59, this.m_BuilderProducts);\n\tv83 = storeProducts == 0;\n\tif (v83) goto L_0039;\n\tSystem.Collections.Generic.HashSet`1<UnityEngine.Purchasing.ProductDefinition>::UnionWith(v59, storeProducts);\nL_0039:\n\tv96 = UnityEngine.Purchasing.JSONSerializer::SerializeProductDefs(v59);\n\tgoto L_0072;\n\tv180 = *([v176 @ X8_v12+B0]);\n\tv181 = 0;\n\tv182 = v180 + 8;\n\tv184 = *([v220 @ X11_v5-8]);\n\tv226 = v184 == v179;\n\tif (v226) goto L_0063;\n\tv206 = v221 + 1;\n\tv231 = v206 < v178;\n\tv202 = ~v231;\n\tv204 = v220 + 0x10;\n\tv186 = ~v202;\n\tif (v186) goto L_FFFFFFFF;\n\tv207 = v94;\n\tv208 = 0;\n\tv209 = 0x8909C4(v207, v179, v208, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_0072;\nL_0063:\n\tv232 = *([v220 @ X11_v5]);\n\tv233 = v232 << 4;\n\tv234 = v176 + v233;\n\tv235 = v234 + 0x130;\nL_0072:\n\tUnityEngine.Purchasing.INativeStore::RetrieveProducts(this.store, v96);\nL_0074:\n\tv52 = this.refreshCallback == 0;\n\tif (v52) goto L_0026;\n\tSystem.Action::Invoke(this.refreshCallback);\n\tthis.refreshCallback = 0;\n\treturn;\n\tv72 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void ProcessManagedStoreResponse(List<ProductDefinition> storeProducts)
		{
			m_storeCatalog = storeProducts;
			if (isRefreshing)
			{
				isRefreshing = false;
				Product[] array = storeCatalog;
				if (array.Length == 0 && refreshCallback != null)
				{
					refreshCallback();
					refreshCallback = null;
					return;
				}
			}
			HashSet<ProductDefinition> hashSet = new HashSet<ProductDefinition>((IEqualityComparer<ProductDefinition>)m_BuilderProducts);
			if (storeProducts != null)
			{
				hashSet.UnionWith(storeProducts);
			}
			string json = JSONSerializer.SerializeProductDefs(hashSet);
			store.RetrieveProducts(json);
		}

		[Token(Token = "0x6000116")]
		[Address(RVA = "0xC63D0C", Offset = "0xC63D0C", Length = "0x5B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv32 = *([1EA55A0]);\n\tv33 = *([v32 @ X8_v71]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, product, developerPayload, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202334F]) = v50;\nL_001D:\n\tv54 = System.String::IsNullOrEmpty(developerPayload);\n\tv56 = v54 == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_0136;\n\tv60 = UnityEngine.Purchasing.MiniJSON.Json::Deserialize(developerPayload);\n\tv179 = v60 == 0;\n\tif (v179) goto L_0136;\n\tgoto L_FFFFFFFF;\n\tv114 = v114_asT == 0;\n\tif (v114) goto L_017B;\n\tv174 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(v60, \"iapPromo\");\n\tv180 = v174 == 0;\n\tif (v180) goto L_0136;\n\tv175 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v60, \"productId\", &v92 @ stack_-48_v15 (System.Object));\n\tv181 = v175 == 0;\n\tif (v181) goto L_0136;\n\tv312 = this.m_Logger;\n\tv681 = v92 == 0;\n\tif (v681) goto L_FFFFFFFF;\n\tv721 = System.Object::ToString(v92);\n\tgoto L_0072;\nL_0072:\n\tv334 = System.String::Concat(\"UnityIAP: Promo Purchase(\", v332, \")\");\n\tv832 = *([v312 @ X23_v16 (UnityEngine.ILogger)]);\n\tv240 = *([v832 @ X8_v45 (Il2CppClass<UnityEngine.ILogger>)+126]);\n\tv836 = *([v832 @ X8_v45 (Il2CppClass<UnityEngine.ILogger>)+126]) == 0;\n\tif (v836) goto L_009A;\n\tv885 = *([v832 @ X8_v45 (Il2CppClass<UnityEngine.ILogger>)+B0]) + 8;\nL_0085:\n\tv900 = *([v885 @ X11_v34-8]) == UnityEngine.ILogger;\n\tif (v900) goto L_009C;\n\tv895 = v895 + 1;\n\tv907 = v895 < v240;\n\tv878 = ~v907;\n\tv885 = v885 + 0x10;\n\tv862 = ~v878;\n\tif (v862) goto L_0085;\nL_009A:\n\tv915 = 0x8909C4(v312, UnityEngine.ILogger, 4, 0, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_00A1;\nL_009C:\n\tv240 = *([v885 @ X11_v34]);\n\tv240 = v240 + 4;\n\tv910 = v240 << 4;\n\tv238 = v832 + v910;\n\tv915 = v238 + 0x130;\nL_00A1:\n\tv238 = *([v915 @ X0_v79]);\n\t*([v915 @ X0_v79])(v921, v312, v334, *([v915 @ X0_v79+8]), 0, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tthis.promoPayload = v60;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v60, \"type\", \"iap.purchase\");\n\tv469 = 1;\n\t// 185 Box v465 @ X0_v84 (System.Object), typeof(System.Boolean), &v469 @ X8_v52 (System.Int32)\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(this.promoPayload, \"iap_service\", v465);\n\tgoto L_00F3;\n\tv975 = *([v963 @ X8_v55+B0]);\n\tv976 = 0;\n\tv977 = v975 + 8;\n\tv979 = *([v1008 @ X11_v29-8]);\n\tv1023 = v979 == v966;\n\tif (v1023) goto L_00EC;\n\tv1001 = v1018 + 1;\n\tv1028 = v1001 < v965;\n\tv999 = ~v1028;\n\tv981 = v1008 + 0x10;\n\tv983 = ~v999;\n\tif (v983) goto L_FFFFFFFF;\n\tv1002 = v549;\n\tv1003 = 0;\n\tv1004 = 0x8909C4(v1002, v966, v1003, v525, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_00F3;\nL_00EC:\n\tv1029 = *([v1008 @ X11_v29]);\n\tv1030 = v1029 << 4;\n\tv1031 = v963 + v1030;\n\tv1032 = v1031 + 0x130;\nL_00F3:\n\tv626 = UnityEngine.Purchasing.Extension.IStoreCallback::get_products(this.unity);\n\tv1038 = v92 == 0;\n\tif (v1038) goto L_FFFFFFFF;\n\tv1067 = *([v92 @ stack_-48_v15 (System.Object)]) != System.String;\n\tif (v1067) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_010F;\nL_010F:\n\tv710 = UnityEngine.Purchasing.ProductCollection::WithID(v626, v708);\n\tv751 = v710.<metadata>k__BackingField;\n\tv162 = v751.<localizedPrice>k__BackingField;\n\t// 287 Box v787 @ X0_v91 (System.Object), typeof(System.Decimal), &v162 @ X9_v38 (System.Decimal)\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(this.promoPayload, \"amount\", v787);\n\tv827 = v710.<metadata>k__BackingField;\n\tv178 = this.promoPayload == 0;\n\tif (v178) goto L_018B;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(this.promoPayload, \"currency\", v827.<isoCurrencyCode>k__BackingField);\nL_0136:\n\tv199 = v183.store;\n\tv201 = UnityEngine.Purchasing.JSONSerializer::EncodeProductDef(v185);\n\tv203 = UnityEngine.Purchasing.MiniJson::JsonEncode(v201);\n\tv238 = *([v199 @ X21_v4 (UnityEngine.Purchasing.INativeStore)]);\n\tv240 = *([v238 @ X8_v6 (Il2CppClass<UnityEngine.Purchasing.INativeStore>)+126]);\n\tv242 = *([v238 @ X8_v6 (Il2CppClass<UnityEngine.Purchasing.INativeStore>)+126]) == 0;\n\tif (v242) goto L_0162;\n\tv475 = *([v238 @ X8_v6 (Il2CppClass<UnityEngine.Purchasing.INativeStore>)+B0]) + 8;\nL_0148:\n\t;\n\tv490 = *([v475 @ X11_v7-8]) == UnityEngine.Purchasing.INativeStore;\n\tif (v490) goto L_0164;\n\tv485 = v485 + 1;\n\tv552 = v485 < v240;\n\tv365 = ~v552;\n\tv475 = v475 + 0x10;\n\tv349 = ~v365;\n\tif (v349) goto L_0148;\nL_0162:\n\tv573 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v199, UnityEngine.Purchasing.INativeStore, 1);\n\tgoto L_016E;\nL_0164:\n\tv240 = *([v475 @ X11_v7]);\n\tv240 = v240 + 1;\n\tv555 = v240 << 4;\n\tv238 = v238 + v555;\n\tv573 = v238 + 0x130;\nL_016E:\n\t*([v573 @ X0_v11])(v580, v199, v203, v187, *([v573 @ X0_v11+8]), v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn;\nL_017B:\n\tthrow System.InvalidCastException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv551 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv830 = new System.NullReferenceException();\nL_018B:\n\tv853 = new System.NullReferenceException();\n\tgoto L_01A7;\n\tgoto L_01A7;\n\tgoto L_01A7;\n\tgoto L_01A7;\n\tgoto L_01A7;\n\tgoto L_01A7;\n\tgoto L_01A7;\n\tgoto L_01A7;\n\tgoto L_01A7;\n\tgoto L_01A7;\n\tgoto L_01A7;\n\tgoto L_01A7;\n\tgoto L_01A7;\n\tgoto L_01A7;\n\tgoto L_01A7;\n\tgoto L_01A7;\n\tgoto L_01A7;\nL_01A7:\n\tv270 = \"amount\" != 1;\n\tif (v270) goto L_020C;\n\tv930 = 0x6D2BC0(v853, \"amount\", v787, Il2CppMethodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv931 = *([v930 @ X0_v31]);\n\tv949 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v931 @ X24_v8]), v787, Il2CppMethodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv950 = v949 & 1;\n\tv936 = v950 == 0;\n\tif (v936) goto L_0202;\n\tv952 = 0x6D2490(v949, *([v931 @ X24_v8]), v647, Il2CppMethodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv198 = this.m_Logger;\n\tv959 = v931 == 0;\n\tif (v959) goto L_FFFFFFFF;\n\tv238 = *([v931 @ X24_v8]);\n\tv240 = *([v238 @ X8_v6 (Il2CppClass<UnityEngine.Purchasing.INativeStore>)+160]);\n\t*([v238 @ X8_v6 (Il2CppClass<UnityEngine.Purchasing.INativeStore>)+160])(v972, v931, *([v238 @ X8_v6 (Il2CppClass<UnityEngine.Purchasing.INativeStore>)+168]), v647, Il2CppMethodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_01C9;\nL_01C9:\n\tv294 = System.String::Concat(\"JSONStore exception handling developerPayload: \", v292);\n\tv417 = *([v198 @ X22_v2 (UnityEngine.ILogger)]);\n\tv240 = *([v417 @ X8_v22 (Il2CppClass<UnityEngine.ILogger>)+126]);\n\tv412 = *([v417 @ X8_v22 (Il2CppClass<UnityEngine.ILogger>)+126]) == 0;\n\tif (v412) goto L_01F1;\n\tv378 = *([v417 @ X8_v22 (Il2CppClass<UnityEngine.ILogger>)+B0]) + 8;\nL_01DC:\n\tv397 = *([v378 @ X11_v15-8]) == UnityEngine.ILogger;\n\tif (v397) goto L_01F5;\n\tv405 = v405 + 1;\n\tv1082 = v405 < v240;\n\tv1051 = ~v1082;\n\tv378 = v378 + 0x10;\n\tv1043 = ~v1051;\n\tif (v1043) goto L_01DC;\nL_01F1:\n\tv511 = 0x8909C4(v198, UnityEngine.ILogger, 6, Il2CppMethodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_01FA;\n\tthrow System.NullReferenceException;\nL_01F5:\n\tv240 = *([v377 @ X11_v9]);\n\tv240 = v240 + 6;\n\tv421 = v240 << 4;\n\tv238 = v416 + v421;\n\tv511 = v238 + 0x130;\nL_01FA:\n\tv238 = *([v511 @ X0_v4]);\n\t*([v511 @ X0_v4])(v176, v198, \"UnityIAP\", v294, *([v511 @ X0_v4+8]), v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_0136;\nL_0202:\n\tv954 = 0x6D1E60(8, *([v931 @ X24_v8]), v787, Il2CppMethodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([v954 @ X0_v35]) = *([v930 @ X0_v31]);\n\tv664 = 0x1E8A000 + 0x870;\n\tv961 = 0x6D2A00(v954, v664, 0, Il2CppMethodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv935 = 0x6D2490(v961, v664, 0, Il2CppMethodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_020C:\n\tv940 = 0x6D2380(v675, v664, v647, Il2CppMethodInfo, v36, v37, v38, v39, v40, v\n// ... truncated")]
		public unsafe override void Purchase(ProductDefinition product, string developerPayload)
		{
			//IL_039e: Expected I, but got O
			//IL_045e: Expected O, but got I4
			//IL_03e9: Expected O, but got I
			//IL_046b: Expected I4, but got O
			//IL_04a4: Expected O, but got I
			//IL_042d: Expected O, but got I
			//IL_0156: Expected I, but got O
			//IL_0802: Expected I, but got O
			//IL_01a1: Expected O, but got I
			//IL_0215: Expected I4, but got O
			//IL_024e: Expected O, but got I
			//IL_01e5: Expected O, but got I
			//IL_06f8: Expected O, but got I4
			//IL_056c: Expected I, but got O
			//IL_05a5: Expected I, but got O
			//IL_08e4: Expected I, but got O
			//IL_05f0: Expected O, but got I
			//IL_0679: Expected I4, but got O
			//IL_06b2: Expected O, but got I
			//IL_0634: Expected O, but got I
			bool flag = string.IsNullOrEmpty(developerPayload);
			bool flag2 = !flag;
			bool flag3 = !flag2;
			JSONStore jSONStore = this;
			ProductDefinition product2 = product;
			string text = developerPayload;
			object obj;
			object value;
			object obj3 = default(object);
			int num;
			IntPtr intPtr2;
			if (!flag3)
			{
				obj = Json.Deserialize(developerPayload);
				bool flag4 = obj == null;
				jSONStore = this;
				product2 = product;
				text = developerPayload;
				if (!flag4)
				{
					Dictionary<string, object> dictionary = obj as Dictionary<string, object>;
					if (dictionary == null)
					{
						throw new InvalidCastException();
					}
					bool flag5 = ((Dictionary<string, object>)obj).ContainsKey("iapPromo");
					bool flag6 = !flag5;
					jSONStore = this;
					product2 = product;
					text = developerPayload;
					if (!flag6)
					{
						bool flag7 = ((Dictionary<string, object>)obj).TryGetValue("productId", out value);
						bool flag8 = !flag7;
						jSONStore = this;
						product2 = product;
						text = developerPayload;
						if (!flag8)
						{
							ILogger logger = m_Logger;
							string text3;
							if (value != null)
							{
								string text2 = value.ToString();
								text3 = text2;
							}
							else
							{
								text3 = null;
							}
							string text4 = "UnityIAP: Promo Purchase(" + text3 + ")";
							IntPtr intPtr = (IntPtr)logger;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ X8_v45 (Il2CppClass<UnityEngine.ILogger>)+126]");
							num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ X8_v45 (Il2CppClass<UnityEngine.ILogger>)+126]");
							if ((IntPtr)0 == (IntPtr)0)
							{
								goto IL_01fe;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ X8_v45 (Il2CppClass<UnityEngine.ILogger>)+B0]");
							object obj2 = 0L + 8L;
							int num2 = 0;
							while (true)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v885 @ X11_v34-8]");
								if ((IntPtr)0 == (IntPtr)typeof(ILogger))
								{
									break;
								}
								num2++;
								bool flag9 = num2 < num;
								bool flag10 = !flag9;
								obj2 = (long)(IntPtr)obj2 + 16L;
								if (!flag10)
								{
									continue;
								}
								goto IL_01fe;
							}
							num = (int)obj2;
							num += 4;
							int num3 = num << 4;
							intPtr2 = (IntPtr)(void*)((long)intPtr + (long)num3);
							obj3 = (long)intPtr2 + 304L;
							goto IL_07fa;
						}
					}
				}
			}
			goto IL_0788;
			IL_07fa:
			intPtr2 = (IntPtr)obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v915 @ X0_v79] (should have been resolved before IL gen)");
			promoPayload = (Dictionary<string, object>)obj;
			((Dictionary<string, object>)obj).Add("type", (object)"iap.purchase");
			int num4 = 1;
			object value2 = (byte)num4 != 0;
			promoPayload.Add("iap_service", value2);
			ProductCollection products = unity.products;
			string id;
			if (value != null)
			{
				object obj4 = (((object)value.GetType() != typeof(string)) ? null : value);
				id = (string)obj4;
			}
			else
			{
				id = null;
			}
			Product product3 = products.WithID(id);
			ProductMetadata metadata = product3.metadata;
			decimal num5 = metadata.localizedPrice;
			object obj5 = num5;
			promoPayload.Add("amount", obj5);
			ProductMetadata metadata2 = product3.metadata;
			bool flag11 = promoPayload == null;
			string text5 = (string)obj5;
			string text6 = "amount";
			if (!flag11)
			{
				promoPayload.Add("currency", metadata2.isoCurrencyCode);
				jSONStore = this;
				product2 = product;
				text = "iapPromo";
				goto IL_0788;
			}
			NullReferenceException ex = new NullReferenceException();
			bool flag12 = (IntPtr)"amount" != (IntPtr)1;
			NullReferenceException ex2 = ex;
			object obj11 = default(object);
			if (!flag12)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj7 = default(object);
				object obj6 = obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				object obj8 = default(object);
				if ((uint)((ulong)(long)(IntPtr)obj8 & 1uL) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
					ILogger logger2 = m_Logger;
					string text7;
					if (obj6 != null)
					{
						intPtr2 = (IntPtr)obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ X8_v6 (Il2CppClass<UnityEngine.Purchasing.INativeStore>)+160]");
						num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v238 @ X8_v6 (Il2CppClass<UnityEngine.Purchasing.INativeStore>)+160] (should have been resolved before IL gen)");
						string text8 = default(string);
						text7 = text8;
					}
					else
					{
						text7 = null;
					}
					string text9 = "JSONStore exception handling developerPayload: " + text7;
					IntPtr intPtr3 = (IntPtr)logger2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v417 @ X8_v22 (Il2CppClass<UnityEngine.ILogger>)+126]");
					num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v417 @ X8_v22 (Il2CppClass<UnityEngine.ILogger>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_064d;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v417 @ X8_v22 (Il2CppClass<UnityEngine.ILogger>)+B0]");
					object obj9 = 0L + 8L;
					int num6 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ X11_v15-8]");
						if ((IntPtr)0 == (IntPtr)typeof(ILogger))
						{
							break;
						}
						num6++;
						bool flag13 = num6 < num;
						bool flag14 = !flag13;
						obj9 = (long)(IntPtr)obj9 + 16L;
						if (!flag14)
						{
							continue;
						}
						goto IL_064d;
					}
					object obj10 = default(object);
					num = (int)obj10;
					num += 6;
					int num7 = num << 4;
					IntPtr intPtr4 = default(IntPtr);
					intPtr2 = (IntPtr)(void*)((long)intPtr4 + (long)num7);
					obj11 = (long)intPtr2 + 304L;
					JSONStore jSONStore2 = default(JSONStore);
					jSONStore = jSONStore2;
					ProductDefinition productDefinition = default(ProductDefinition);
					product2 = productDefinition;
					string text10 = default(string);
					text = text10;
					ILogger logger3 = default(ILogger);
					logger2 = logger3;
					goto IL_08dc;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
				object obj12 = obj7;
				text6 = (string)(32022528 + 2160);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2A00 (native __cxa_throw)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				text5 = null;
				NullReferenceException ex3 = default(NullReferenceException);
				ex2 = ex3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
			return;
			IL_01fe:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_07fa;
			IL_0446:
			INativeStore nativeStore;
			((Dictionary<string, object>)nativeStore).Add((string)(object)typeof(INativeStore), (object)1);
			goto IL_0890;
			IL_0788:
			nativeStore = jSONStore.store;
			Dictionary<string, object> json = JSONSerializer.EncodeProductDef(product2);
			string text11 = MiniJson.JsonEncode(json);
			intPtr2 = (IntPtr)nativeStore;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ X8_v6 (Il2CppClass<UnityEngine.Purchasing.INativeStore>)+126]");
			num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ X8_v6 (Il2CppClass<UnityEngine.Purchasing.INativeStore>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0446;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ X8_v6 (Il2CppClass<UnityEngine.Purchasing.INativeStore>)+B0]");
			object obj13 = 0L + 8L;
			int num8 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v475 @ X11_v7-8]");
				if ((IntPtr)0 == (IntPtr)typeof(INativeStore))
				{
					break;
				}
				num8++;
				bool flag15 = num8 < num;
				bool flag16 = !flag15;
				obj13 = (long)(IntPtr)obj13 + 16L;
				if (!flag16)
				{
					continue;
				}
				goto IL_0446;
			}
			num = (int)obj13;
			num++;
			int num9 = num << 4;
			intPtr2 = (IntPtr)(void*)((long)intPtr2 + (long)num9);
			object obj14 = (long)intPtr2 + 304L;
			goto IL_0890;
			IL_08dc:
			intPtr2 = (IntPtr)obj11;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v511 @ X0_v4] (should have been resolved before IL gen)");
			goto IL_0788;
			IL_0890:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v573 @ X0_v11] (should have been resolved before IL gen)");
			return;
			IL_064d:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			jSONStore = this;
			product2 = product;
			text = developerPayload;
			goto IL_08dc;
		}

		[Token(Token = "0x6000117")]
		[Address(RVA = "0xC5AD40", Offset = "0xC5AD40", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EBC6B0]);\n\tv27 = *([v26 @ X8_v8]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, product, transactionId, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023350]) = v44;\nL_0017:\n\tv45 = product == 0;\n\tif (v45) goto L_001E;\n\tv47 = UnityEngine.Purchasing.JSONSerializer::EncodeProductDef(product);\n\tv51 = UnityEngine.Purchasing.MiniJson::JsonEncode(v47);\nL_001E:\n\tv54 = this.store;\n\tv57 = *([v54 @ X21_v2 (UnityEngine.Purchasing.INativeStore)]);\n\tv61 = *([v57 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.INativeStore>)+126]) == 0;\n\tif (v61) goto L_0045;\n\tv115 = *([v57 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.INativeStore>)+B0]) + 8;\nL_0030:\n\tv121 = *([v115 @ X11_v5-8]) == UnityEngine.Purchasing.INativeStore;\n\tif (v121) goto L_0048;\n\tv116 = v116 + 1;\n\tv182 = v116 < *([v57 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.INativeStore>)+126]);\n\tv95 = ~v182;\n\tv115 = v115 + 0x10;\n\tv71 = ~v95;\n\tif (v71) goto L_0030;\nL_0045:\n\tv189 = 0x8909C4(v54, UnityEngine.Purchasing.INativeStore, 2, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_004C;\nL_0048:\n\tv184 = *([v115 @ X11_v5]) + 2;\n\tv185 = v184 << 4;\n\tv186 = v57 + v185;\n\tv189 = v186 + 0x130;\nL_004C:\n\tv131 = *([v189 @ X0_v5]);\n\tv129 = *([v189 @ X0_v5+8]);\n\t// 88 IndirectJump v131 @ X4_v1, v54 @ X21_v2 (UnityEngine.Purchasing.INativeStore), v54 @ X21_v2 (UnityEngine.Purchasing.INativeStore), v52 @ X20_v2 (UnityEngine.Purchasing.ProductDefinition), transactionId @ X2 (System.String), v129 @ X3_v1, v131 @ X4_v1, v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void FinishTransaction(ProductDefinition product, string transactionId)
		{
			//IL_002c: Expected I, but got O
			//IL_0179: Expected O, but got I
			//IL_0067: Expected O, but got I
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Expected O, but got Unknown
			//IL_0106: Expected O, but got I
			//IL_0115: Expected O, but got I
			//IL_00b3: Expected O, but got I
			if (product != null)
			{
				Dictionary<string, object> json = JSONSerializer.EncodeProductDef(product);
				string text = MiniJson.JsonEncode(json);
			}
			object obj4 = default(object);
			while (true)
			{
				INativeStore nativeStore = store;
				IntPtr intPtr = (IntPtr)nativeStore;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.INativeStore>)+126]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.INativeStore>)+B0]");
					object obj = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ X11_v5-8]");
						if ((IntPtr)0 == (IntPtr)typeof(INativeStore))
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.INativeStore>)+126]");
						bool flag = (long)num2 < 0L;
						bool flag2 = !flag;
						obj = (long)(IntPtr)obj + 16L;
						if (!flag2)
						{
							continue;
						}
						goto IL_00cc;
					}
					object obj2 = obj + 2;
					int num3 = (int)((long)(IntPtr)obj2 << 4);
					object obj3 = (long)intPtr + (long)num3;
					obj4 = (long)(IntPtr)obj3 + 304L;
					goto IL_0161;
				}
				goto IL_00cc;
				IL_0161:
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ X0_v5+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v131 @ X4_v1 (should have been resolved before IL gen)");
				continue;
				IL_00cc:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0161;
			}
		}

		[Token(Token = "0x6000118")]
		[Address(RVA = "0xC5A188", Offset = "0xC5A188", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EA9C40]);\n\tv23 = *([v22 @ X8_v22]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, reason, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023351]) = v41;\nL_001E:\n\tgoto L_0026;\n\tv51 = *([v44 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0026;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v44, reason, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0026:\n\tv60 = System.Type::GetTypeFromHandle(UnityEngine.Purchasing.InitializationFailureReason);\n\tgoto L_0039;\n\tv68 = *([v64 @ X8_v10+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_0039;\n\tv80 = v64;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v80, v59, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0039:\n\tv79 = System.Enum::Parse(v60, reason, 1);\n\tv97 = v97_asT == 0;\n\tif (v97) goto L_0089;\n\tv99 = \"il2cpp_vm_object_unbox\"(v79, UnityEngine.Purchasing.InitializationFailureReason, 1, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv123 = this.unity;\n\tv143 = *([v123 @ X19_v3 (UnityEngine.Purchasing.Extension.IStoreCallback)]);\n\tv144 = *([v99 @ X0_v15]);\n\tv148 = *([v143 @ X8_v16 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]) == 0;\n\tif (v148) goto L_0076;\n\tv233 = *([v143 @ X8_v16 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+B0]) + 8;\nL_0061:\n\tv248 = *([v233 @ X11_v5-8]) == UnityEngine.Purchasing.Extension.IStoreCallback;\n\tif (v248) goto L_0079;\n\tv234 = v234 + 1;\n\tv253 = v234 < *([v143 @ X8_v16 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]);\n\tv177 = ~v253;\n\tv233 = v233 + 0x10;\n\tv161 = ~v177;\n\tif (v161) goto L_0061;\nL_0076:\n\tv260 = 0x8909C4(v123, UnityEngine.Purchasing.Extension.IStoreCallback, 1, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_007D;\nL_0079:\n\tv255 = *([v233 @ X11_v5]) + 1;\n\tv256 = v255 << 4;\n\tv257 = v143 + v256;\n\tv260 = v257 + 0x130;\nL_007D:\n\tv212 = *([v260 @ X0_v16]);\n\tv214 = *([v260 @ X0_v16+8]);\n\t// 135 IndirectJump v212 @ X3_v2, v123 @ X19_v3 (UnityEngine.Purchasing.Extension.IStoreCallback), v123 @ X19_v3 (UnityEngine.Purchasing.Extension.IStoreCallback), v144 @ X20_v2, v214 @ X2_v3, v212 @ X3_v2, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tv98 = new System.NullReferenceException();\nL_0089:\n\tthrow System.InvalidCastException;\n\tthrow System.NullReferenceException;\n// 91 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnSetupFailed(string reason)
		{
			//IL_0040: Expected I4, but got O
			//IL_007e: Expected I, but got O
			//IL_01c1: Expected O, but got I
			//IL_00c1: Expected O, but got I
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Expected O, but got Unknown
			//IL_0160: Expected O, but got I
			//IL_016f: Expected O, but got I
			//IL_010d: Expected O, but got I
			Type typeFromHandle = typeof(InitializationFailureReason);
			object obj = Enum.Parse(typeFromHandle, reason, ignoreCase: true);
			object obj7 = default(object);
			if ((int)((obj is InitializationFailureReason) ? obj : null) != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				IStoreCallback storeCallback = unity;
				IntPtr intPtr = (IntPtr)storeCallback;
				object obj3 = default(object);
				object obj2 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ X8_v16 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0126;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ X8_v16 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+B0]");
				object obj4 = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IStoreCallback))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ X8_v16 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj4 = (long)(IntPtr)obj4 + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_0126;
				}
				object obj5 = obj4 + 1;
				int num3 = (int)((long)(IntPtr)obj5 << 4);
				object obj6 = (long)intPtr + (long)num3;
				obj7 = (long)(IntPtr)obj6 + 304L;
				goto IL_01a9;
			}
			throw new InvalidCastException();
			IL_01a9:
			object obj8 = obj7;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ X0_v16+8]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v212 @ X3_v2 (should have been resolved before IL gen)");
			return;
			IL_0126:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_01a9;
		}

		[Token(Token = "0x6000119")]
		[Address(RVA = "0xC642C4", Offset = "0xC642C4", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EFE868]);\n\tv23 = *([v22 @ X8_v14]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, json, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023352]) = v41;\nL_0015:\n\tv42 = this.unity;\n\tv44 = UnityEngine.Purchasing.JSONSerializer::DeserializeProductDescriptions(json);\n\tv48 = *([v42 @ X20_v2 (UnityEngine.Purchasing.Extension.IStoreCallback)]);\n\tv52 = *([v48 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]) == 0;\n\tif (v52) goto L_003F;\n\tv106 = *([v48 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+B0]) + 8;\nL_002A:\n\tv112 = *([v106 @ X11_v5-8]) == UnityEngine.Purchasing.Extension.IStoreCallback;\n\tif (v112) goto L_0042;\n\tv107 = v107 + 1;\n\tv168 = v107 < *([v48 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]);\n\tv86 = ~v168;\n\tv106 = v106 + 0x10;\n\tv62 = ~v86;\n\tif (v62) goto L_002A;\nL_003F:\n\tv175 = 0x8909C4(v42, UnityEngine.Purchasing.Extension.IStoreCallback, 2, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004A;\nL_0042:\n\tv170 = *([v106 @ X11_v5]) + 2;\n\tv171 = v170 << 4;\n\tv172 = v48 + v171;\n\tv175 = v172 + 0x130;\nL_004A:\n\t*([v175 @ X0_v6])(v180, v42, v44, *([v175 @ X0_v6+8]), v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0060;\n\tv188 = *([v184 @ X0_v9+E0]);\n\tv189 = v188 == 0;\n\tv190 = ~v189;\n\tgoto L_0060;\n\tv192 = \"il2cpp_codegen_runtime_class_init\"(v184, v179, v125, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0060:\n\tUnityEngine.Purchasing.Promo::ProvideProductsToAds(this, this.unity);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void OnProductsRetrieved(string json)
		{
			//IL_000d: Expected I, but got O
			//IL_0048: Expected O, but got I
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00e7: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_0094: Expected O, but got I
			IStoreCallback storeCallback = unity;
			List<ProductDescription> list = JSONSerializer.DeserializeProductDescriptions(json);
			IntPtr intPtr = (IntPtr)storeCallback;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IStoreCallback))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 2;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_014e;
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_014e;
			IL_014e:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v175 @ X0_v6] (should have been resolved before IL gen)");
			Promo.ProvideProductsToAds(this, unity);
		}

		[Token(Token = "0x600011A")]
		[Address(RVA = "0xC5A664", Offset = "0xC5A664", Length = "0x6DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv38 = *([1EA9A28]);\n\tv39 = *([v38 @ X8_v92]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, id, receipt, transactionID, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2023353]) = v55;\nL_0027:\n\tgoto L_004E;\n\tv282 = *([v60 @ X8_v6+B0]);\n\tv283 = 0;\n\tv284 = v282 + 8;\n\tv286 = *([v416 @ X11_v14-8]);\n\tv421 = v286 == v63;\n\tif (v421) goto L_0047;\n\tv306 = v415 + 1;\n\tv488 = v306 < v62;\n\tv304 = ~v488;\n\tv308 = v416 + 0x10;\n\tv288 = ~v304;\n\tif (v288) goto L_FFFFFFFF;\n\tv309 = v57;\n\tv310 = 0;\n\tv311 = 0x8909C4(v309, v63, v310, transactionID, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_004E;\nL_0047:\n\tv489 = *([v416 @ X11_v14]);\n\tv490 = v489 << 4;\n\tv491 = v60 + v490;\n\tv492 = v491 + 0x130;\nL_004E:\n\tv384 = UnityEngine.Purchasing.Extension.IStoreCallback::get_products(this.unity);\n\tv498 = UnityEngine.Purchasing.ProductCollection::WithStoreSpecificID(v384, id);\n\tv568 = this.promoPayload;\n\tv569 = this.promoPayload == 0;\n\tif (v569) goto L_010B;\n\tv478 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(this.promoPayload, \"productId\");\n\tv481 = v478 == 0;\n\tif (v481) goto L_0075;\n\tv474 = *([v478 @ X0_v65 (System.String)]);\n\tv442 = *([v478 @ X0_v65 (System.String)]) != System.String;\n\tif (v442) goto L_0228;\nL_0075:\n\tv610 = System.String::op_Equality(id, v478);\n\tv617 = v610 == 0;\n\tv618 = ~v617;\n\tif (v618) goto L_00A5;\n\tv479 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(this.promoPayload, \"storeSpecificId\");\n\tv482 = v479 == 0;\n\tif (v482) goto L_0095;\n\tv474 = *([v479 @ X0_v94 (System.String)]);\n\tv443 = *([v479 @ X0_v94 (System.String)]) != System.String;\n\tif (v443) goto L_0228;\nL_0095:\n\tv590 = System.String::op_Equality(id, v479);\n\tv592 = v590 == 0;\n\tif (v592) goto L_010B;\nL_00A5:\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(this.promoPayload, \"purchase\", \"OK\");\n\tv713 = v498 == 0;\n\tif (v713) goto L_00CC;\n\tv257 = v498.<definition>k__BackingField;\n\tv398 = v257.<type>k__BackingField;\n\t// 178 Box v378 @ X0_v87, typeof(UnityEngine.Purchasing.ProductType), &v398 @ X8_v81 (UnityEngine.Purchasing.ProductType)\n\tv568 = *([v378 @ X0_v87]);\n\tv474 = *([v568 @ X8_v9 (System.Collections.Generic.Dictionary`2<System.String, System.Object>)+160]);\n\t*([v568 @ X8_v9 (System.Collections.Generic.Dictionary`2<System.String, System.Object>)+160])(v764, v378, *([v568 @ X8_v9 (System.Collections.Generic.Dictionary`2<System.String, System.Object>)+168]), \"OK\", Il2CppMethodInfo, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv226 = \"il2cpp_vm_object_unbox\"(v378, *([v568 @ X8_v9 (System.Collections.Generic.Dictionary`2<System.String, System.Object>)+168]), \"OK\", Il2CppMethodInfo, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(this.promoPayload, \"productType\", v764);\nL_00CC:\n\tv742 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v742);\n\tv227 = UnityEngine.Purchasing.JSONStore::FormatUnifiedReceipt(this, receipt, transactionID);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v742, \"data\", v227);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(this.promoPayload, \"receipt\", v742);\n\tv779 = new UnityEngine.Purchasing.PurchasingEvent();\n\tSystem.Object::.ctor(v779);\n\tv779.EventDict = this.promoPayload;\n\tv228 = UnityEngine.Purchasing.ProfileData::GetProfileDict(this.m_profileData);\n\tv229 = UnityEngine.Purchasing.PurchasingEvent::FlatJSON(v779, v228);\n\tv793 = UnityEngine.Purchasing.EventQueue::SendEvent(this.m_EventQueue, v229);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Clear(this.promoPayload);\n\tthis.promoPayload = 0;\n\tgoto L_01D5;\nL_010B:\n\tv594 = v498 == 0;\n\tif (v594) goto L_01D5;\n\tv230 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v230);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v230, \"type\", \"iap.purchase\");\n\tv689 = 1;\n\t// 297 Box v692 @ X0_v29 (System.Object), typeof(System.Boolean), &v689 @ X8_v27 (System.Int32)\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v230, \"iap_service\", v692);\n\tv80 = 0;\n\t// 308 Box v745 @ X0_v32 (System.Object), typeof(System.Boolean), &v80 @ stack_-64_v5\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v230, \"iapPromo\", v745);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v230, \"purchase\", \"OK\");\n\tv263 = v498.<definition>k__BackingField;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v230, \"productId\", v263.<id>k__BackingField);\n\tv264 = v498.<definition>k__BackingField;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v230, \"storeSpecificId\", v264.<storeSpecificId>k__BackingField);\n\tv265 = v498.<metadata>k__BackingField;\n\tv217 = v265.<localizedPrice>k__BackingField;\n\t// 356 Box v784 @ X0_v38 (System.Object), typeof(System.Decimal), &v217 @ X9_v16 (System.Decimal)\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v230, \"amount\", v784);\n\tv266 = v498.<metadata>k__BackingField;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v230, \"currency\", v266.<isoCurrencyCode>k__BackingField);\n\tv267 = v498.<definition>k__BackingField;\n\tv400 = v267.<type>k__BackingField;\n\t// 383 Box v382 @ X0_v42, typeof(UnityEngine.Purchasing.ProductType), &v400 @ X8_v48 (UnityEngine.Purchasing.ProductType)\n\tv568 = *([v382 @ X0_v42]);\n\tv474 = *([v568 @ X8_v9 (System.Collections.Generic.Dictionary`2<System.String, System.Object>)+160]);\n\t*([v568 @ X8_v9 (System.Collections.Generic.Dictionary`2<System.String, System.Object>)+160])(v798, v382, *([v568 @ X8_v9 (System.Collections.Generic.Dictionary`2<System.String, System.Object>)+168]), v266.<isoCurrencyCode>k__BackingField, Il2CppMethodInfo, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv800 = \"il2cpp_vm_object_unbox\"(v382, *([v568 @ X8_v9 (System.Collections.Generic.Dictionary`2<System.String, System.Object>)+168]), v266.<isoCurrencyCode>k__BackingField, Il2CppMethodInfo, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v230, \"productType\", v798);\n\tv810 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v810);\n\tv236 = UnityEngine.Purchasing.JSONStore::FormatUnifiedReceipt(this, receipt, transactionID);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v810, \"data\", v236);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v230, \"receipt\", v810);\n\tv827 = new UnityEngine.Purchasing.PurchasingEvent();\n\tSystem.Object::.ctor(v827);\n\tv827.EventDict = v230;\n\tv237 = UnityEngine.Purchasing.ProfileData::GetProfileDict(this.m_profileData);\n\tv829 = UnityEngine.Purchasing.PurchasingEvent::FlatJSON(v827, v237);\n\tv238 = System.String::Concat(this.eventBaseUrl, \"/v1/organic_purchase\");\n\tv603 = UnityEngine.Purchasing.EventQueue::SendEvent(this.m_EventQueue, 2, v829, v238, 0);\nL_01D5:\n\tv280 = this.unity;\n\tv612 = *([v280 @ X23_v8 (UnityEngine.Purchasing.Extension.IStoreCallback)]);\n\tv615 = *([v612 @ X8_v11 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]) == 0;\n\tif (v615) goto L_01FA;\n\tv671 = *([v612 @ X8_v11 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+B0]) + 8;\nL_01E5:\n\tv676 = *([v671 @ X11_v9-8]) == UnityEngine.Purchasing.Extension.IStoreCallback;\n\tif (v676) goto L_01FC;\n\tv670 = v670 + 1;\n\tv693 = v670 < *([v612 @ X8_v11 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]);\n\tv641 = ~v693;\n\tv671 = v671 + 0x10;\n\tv625 = ~v641;\n\tif (v625) goto L_01E5;\nL_01FA\n// ... truncated")]
		public unsafe virtual void OnPurchaseSucceeded(string id, string receipt, string transactionID)
		{
			//IL_05d0: Expected I, but got O
			//IL_007d: Expected I, but got O
			//IL_060b: Expected O, but got I
			//IL_036b: Expected O, but got I4
			//IL_0374: Expected I4, but got O
			//IL_0687: Expected I, but got O
			//IL_06b3: Expected O, but got I
			//IL_06c2: Expected O, but got I
			//IL_0119: Expected I, but got O
			//IL_0657: Expected O, but got I
			//IL_02e9: Expected O, but got I
			ProductCollection products = unity.products;
			Product product = products.WithStoreSpecificID(id);
			Dictionary<string, object> dictionary = promoPayload;
			if (promoPayload == null)
			{
				goto IL_02ee;
			}
			string text = (string)promoPayload.get_Item("productId");
			IntPtr intPtr;
			if (text != null)
			{
				intPtr = (IntPtr)text;
				if ((object)text.GetType() != typeof(string))
				{
					goto IL_06d4;
				}
			}
			if (!(id == text))
			{
				string text2 = (string)promoPayload.get_Item("storeSpecificId");
				if (text2 != null)
				{
					intPtr = (IntPtr)text2;
					if ((object)text2.GetType() != typeof(string))
					{
						goto IL_06d4;
					}
				}
				if (!(id == text2))
				{
					goto IL_02ee;
				}
			}
			promoPayload.Add("purchase", "OK");
			if (product != null)
			{
				ProductDefinition definition = product.definition;
				ProductType type = definition.type;
				object obj = type;
				dictionary = (Dictionary<string, object>)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v568 @ X8_v9 (System.Collections.Generic.Dictionary`2<System.String, System.Object>)+160]");
				intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v568 @ X8_v9 (System.Collections.Generic.Dictionary`2<System.String, System.Object>)+160] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				object value = default(object);
				promoPayload.Add("productType", value);
			}
			Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
			string value2 = FormatUnifiedReceipt(receipt, transactionID);
			dictionary2.Add("data", value2);
			promoPayload.Add("receipt", dictionary2);
			PurchasingEvent purchasingEvent = null;
			purchasingEvent.EventDict = promoPayload;
			Dictionary<string, object> profileDict = m_profileData.GetProfileDict();
			string json = purchasingEvent.FlatJSON(profileDict);
			bool flag = m_EventQueue.SendEvent(json);
			promoPayload.Clear();
			promoPayload = null;
			object obj2 = 0;
			goto IL_05b9;
			IL_06d4:
			throw new InvalidCastException();
			IL_02ee:
			bool flag2 = product == null;
			obj2 = transactionID;
			if (!flag2)
			{
				Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
				dictionary3.Add("type", "iap.purchase");
				int num = 1;
				object value3 = (byte)num != 0;
				dictionary3.Add("iap_service", value3);
				object obj3 = 0;
				object value4 = (byte)(int)obj3 != 0;
				dictionary3.Add("iapPromo", value4);
				dictionary3.Add("purchase", "OK");
				ProductDefinition definition2 = product.definition;
				dictionary3.Add("productId", definition2.id);
				ProductDefinition definition3 = product.definition;
				dictionary3.Add("storeSpecificId", definition3.storeSpecificId);
				ProductMetadata metadata = product.metadata;
				decimal num2 = metadata.localizedPrice;
				object value5 = num2;
				dictionary3.Add("amount", value5);
				ProductMetadata metadata2 = product.metadata;
				dictionary3.Add("currency", metadata2.isoCurrencyCode);
				ProductDefinition definition4 = product.definition;
				ProductType type2 = definition4.type;
				object obj4 = type2;
				dictionary = (Dictionary<string, object>)obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v568 @ X8_v9 (System.Collections.Generic.Dictionary`2<System.String, System.Object>)+160]");
				intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v568 @ X8_v9 (System.Collections.Generic.Dictionary`2<System.String, System.Object>)+160] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				object value6 = default(object);
				dictionary3.Add("productType", value6);
				Dictionary<string, string> dictionary4 = new Dictionary<string, string>();
				string value7 = FormatUnifiedReceipt(receipt, transactionID);
				dictionary4.Add("data", value7);
				dictionary3.Add("receipt", dictionary4);
				PurchasingEvent purchasingEvent2 = null;
				purchasingEvent2.EventDict = dictionary3;
				Dictionary<string, object> profileDict2 = m_profileData.GetProfileDict();
				string json2 = purchasingEvent2.FlatJSON(profileDict2);
				string text3 = eventBaseUrl + "/v1/organic_purchase";
				bool flag3 = m_EventQueue.SendEvent(EventDestType.IAP, json2, text3);
				obj2 = text3;
			}
			goto IL_05b9;
			IL_0670:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0718;
			IL_0718:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v700 @ X0_v14] (should have been resolved before IL gen)");
			Promo.ProvideProductsToAds(this, unity);
			return;
			IL_05b9:
			IStoreCallback storeCallback = unity;
			IntPtr intPtr2 = (IntPtr)storeCallback;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v612 @ X8_v11 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0670;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v612 @ X8_v11 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+B0]");
			object obj5 = 0L + 8L;
			int num3 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v671 @ X11_v9-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IStoreCallback))
				{
					break;
				}
				num3++;
				int num4 = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v612 @ X8_v11 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]");
				bool flag4 = (long)num4 < 0L;
				bool flag5 = !flag4;
				obj5 = (long)(IntPtr)obj5 + 16L;
				if (!flag5)
				{
					continue;
				}
				goto IL_0670;
			}
			intPtr = (IntPtr)obj5;
			intPtr = (IntPtr)(void*)((long)intPtr + 3L);
			int num5 = (int)((long)intPtr << 4);
			dictionary = (Dictionary<string, object>)((long)intPtr2 + (long)num5);
			object obj6 = (long)(IntPtr)dictionary + 304L;
			goto IL_0718;
		}

		[Token(Token = "0x600011B")]
		[Address(RVA = "0xC5A2F8", Offset = "0xC5A2F8", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = UnityEngine.Purchasing.JSONSerializer::DeserializeFailureReason(json);\n\tUnityEngine.Purchasing.JSONStore::OnPurchaseFailed(this, v15, json);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnPurchaseFailed(string json)
		{
			PurchaseFailureDescription failure = JSONSerializer.DeserializeFailureReason(json);
			OnPurchaseFailed(failure, json);
		}

		[Token(Token = "0x600011C")]
		[Address(RVA = "0xC60CB8", Offset = "0xC60CB8", Length = "0x4C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv34 = *([1EC0BA8]);\n\tv35 = *([v34 @ X8_v61]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, failure, json, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2023354]) = v52;\nL_001C:\n\tv54 = this.promoPayload == 0;\n\tif (v54) goto L_0066;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(this.promoPayload, \"type\", \"iap.purchasefailed\");\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(this.promoPayload, \"purchase\", \"FAILED\");\n\tv332 = json == 0;\n\tif (v332) goto L_0044;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(this.promoPayload, \"failureJSON\", json);\nL_0044:\n\tv364 = new UnityEngine.Purchasing.PurchasingEvent();\n\tSystem.Object::.ctor(v364);\n\tv364.EventDict = this.promoPayload;\n\tv203 = UnityEngine.Purchasing.ProfileData::GetProfileDict(this.m_profileData);\n\tv204 = UnityEngine.Purchasing.PurchasingEvent::FlatJSON(v364, v203);\n\tv232 = this.m_EventQueue;\n\tv463 = UnityEngine.Purchasing.EventQueue::SendEvent(this.m_EventQueue, 2, v204, 0, 0);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Clear(this.promoPayload);\n\tthis.promoPayload = 0;\n\tv147 = this + 0x18;\n\tgoto L_013C;\nL_0066:\n\tv147 = this + 0x18;\n\tgoto L_0097;\n\tv302 = *([v71 @ X8_v10+B0]);\n\tv303 = 0;\n\tv304 = v302 + 8;\n\tv306 = *([v343 @ X11_v14-8]);\n\tv349 = v306 == v74;\n\tif (v349) goto L_0090;\n\tv328 = v344 + 1;\n\tv429 = v328 < v73;\n\tv324 = ~v429;\n\tv326 = v343 + 0x10;\n\tv308 = ~v324;\n\tif (v308) goto L_FFFFFFFF;\n\tv329 = v66;\n\tv330 = 0;\n\tv331 = 0x8909C4(v329, v74, v330, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_0097;\nL_0090:\n\tv430 = *([v343 @ X11_v14]);\n\tv431 = v430 << 4;\n\tv432 = v71 + v431;\n\tv433 = v432 + 0x130;\nL_0097:\n\tv214 = UnityEngine.Purchasing.Extension.IStoreCallback::get_products(this.unity);\n\tv439 = UnityEngine.Purchasing.ProductCollection::WithStoreSpecificID(v214, failure.<productId>k__BackingField);\n\tv440 = v439 == 0;\n\tif (v440) goto L_013C;\n\tv205 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v205);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v205, \"type\", \"iap.purchasefailed\");\n\tv504 = 1;\n\t// 190 Box v507 @ X0_v25 (System.Object), typeof(System.Boolean), &v504 @ X8_v19 (System.Int32)\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v205, \"iap_service\", v507);\n\tv90 = 0;\n\t// 201 Box v548 @ X0_v28 (System.Object), typeof(System.Boolean), &v90 @ stack_-58_v4\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v205, \"iapPromo\", v548);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v205, \"purchase\", \"FAILED\");\n\tv234 = v439.<definition>k__BackingField;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v205, \"productId\", v234.<id>k__BackingField);\n\tv235 = v439.<definition>k__BackingField;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v205, \"storeSpecificId\", v235.<storeSpecificId>k__BackingField);\n\tv236 = v439.<metadata>k__BackingField;\n\tv199 = v236.<localizedPrice>k__BackingField;\n\t// 249 Box v566 @ X0_v34 (System.Object), typeof(System.Decimal), &v199 @ X9_v14 (System.Decimal)\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v205, \"amount\", v566);\n\tv237 = v439.<metadata>k__BackingField;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v205, \"currency\", v237.<isoCurrencyCode>k__BackingField);\n\tv575 = json == 0;\n\tif (v575) goto L_0117;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v205, \"failureJSON\", json);\nL_0117:\n\tv210 = new UnityEngine.Purchasing.PurchasingEvent();\n\tSystem.Object::.ctor(v210);\n\tv210.EventDict = v205;\n\tv238 = this.m_Module;\n\tv291 = UnityEngine.Purchasing.ProfileData::Instance(v238.<util>k__BackingField);\n\tv211 = UnityEngine.Purchasing.ProfileData::GetProfileDict(v291);\n\tv590 = UnityEngine.Purchasing.PurchasingEvent::FlatJSON(v210, v211);\n\tv212 = System.String::Concat(this.eventBaseUrl, \"/v1/organic_purchase\");\n\tv451 = UnityEngine.Purchasing.EventQueue::SendEvent(this.m_EventQueue, 2, v590, v212, 0);\nL_013C:\n\tthis.lastPurchaseFailureDescription = failure;\n\tv213 = UnityEngine.Purchasing.JSONStore::ParseStoreSpecificPurchaseErrorCode(this, json);\n\tthis._lastPurchaseErrorCode = v213;\n\tv229 = this.unity;\n\tv232 = this.unity->klass;\n\tv460 = this.unity->klass->interface_offsets_count;\n\tv416 = *([v232 @ X8_v54 (UnityEngine.Purchasing.EventQueue)+126]) == 0;\n\tif (v416) goto L_0166;\n\tv518 = *([v232 @ X8_v54 (UnityEngine.Purchasing.EventQueue)+B0]) + 8;\nL_0151:\n\tv524 = *([v518 @ X11_v8-8]) == UnityEngine.Purchasing.Extension.IStoreCallback;\n\tif (v524) goto L_0168;\n\tv519 = v519 + 1;\n\tv536 = v519 < v460;\n\tv495 = ~v536;\n\tv518 = v518 + 0x10;\n\tv479 = ~v495;\n\tif (v479) goto L_0151;\nL_0166:\n\tv543 = 0x8909C4(v229, UnityEngine.Purchasing.Extension.IStoreCallback, 4, methodInfo, v149, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_0171;\nL_0168:\n\tv460 = *([v518 @ X11_v8]);\n\tv460 = v460 + 4;\n\tv539 = v460 << 4;\n\tv232 = v232 + v539;\n\tv543 = v232 + 0x130;\nL_0171:\n\t*([v543 @ X0_v11])(v414, v229, failure, *([v543 @ X0_v11+8]), methodInfo, v149, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\treturn;\n\tv248 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 275 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnPurchaseFailed(PurchaseFailureDescription failure, string json = null)
		{
			//IL_0129: Expected O, but got I
			//IL_042c: Expected O, but got I
			//IL_01bf: Expected O, but got I4
			//IL_01c8: Expected I4, but got O
			//IL_0108: Expected O, but got I
			//IL_0117: Expected I, but got O
			//IL_04a0: Expected I4, but got O
			//IL_04ca: Expected O, but got I
			//IL_04d9: Expected O, but got I
			//IL_0470: Expected O, but got I
			//IL_03a4: Expected I, but got O
			object obj;
			EventQueue eventQueue;
			if (promoPayload != null)
			{
				promoPayload.set_Item("type", (object)"iap.purchasefailed");
				promoPayload.Add("purchase", "FAILED");
				if (json != null)
				{
					promoPayload.Add("failureJSON", json);
				}
				PurchasingEvent purchasingEvent = null;
				purchasingEvent.EventDict = promoPayload;
				Dictionary<string, object> profileDict = m_profileData.GetProfileDict();
				string json2 = purchasingEvent.FlatJSON(profileDict);
				eventQueue = m_EventQueue;
				bool flag = m_EventQueue.SendEvent(EventDestType.IAP, json2);
				promoPayload.Clear();
				promoPayload = null;
				obj = (long)(IntPtr)this + 24L;
				int? num = null;
				IntPtr intPtr = (IntPtr)null;
			}
			else
			{
				obj = (long)(IntPtr)this + 24L;
				ProductCollection products = unity.products;
				Product product = products.WithStoreSpecificID(failure.productId);
				if (product != null)
				{
					Dictionary<string, object> dictionary = new Dictionary<string, object>();
					dictionary.Add("type", "iap.purchasefailed");
					int num2 = 1;
					object value = (byte)num2 != 0;
					dictionary.Add("iap_service", value);
					object obj2 = 0;
					object value2 = (byte)(int)obj2 != 0;
					dictionary.Add("iapPromo", value2);
					dictionary.Add("purchase", "FAILED");
					ProductDefinition definition = product.definition;
					dictionary.Add("productId", definition.id);
					ProductDefinition definition2 = product.definition;
					dictionary.Add("storeSpecificId", definition2.storeSpecificId);
					ProductMetadata metadata = product.metadata;
					decimal num3 = metadata.localizedPrice;
					object value3 = num3;
					dictionary.Add("amount", value3);
					ProductMetadata metadata2 = product.metadata;
					dictionary.Add("currency", metadata2.isoCurrencyCode);
					if (json != null)
					{
						dictionary.Add("failureJSON", json);
					}
					PurchasingEvent purchasingEvent2 = null;
					purchasingEvent2.EventDict = dictionary;
					StandardPurchasingModule module = m_Module;
					ProfileData profileData = ProfileData.Instance(module.util);
					Dictionary<string, object> profileDict2 = profileData.GetProfileDict();
					string json3 = purchasingEvent2.FlatJSON(profileDict2);
					string text = eventBaseUrl + "/v1/organic_purchase";
					bool flag2 = m_EventQueue.SendEvent(EventDestType.IAP, json3, text);
					int? num = null;
					IntPtr intPtr = (IntPtr)text;
				}
			}
			lastPurchaseFailureDescription = failure;
			StoreSpecificPurchaseErrorCode lastPurchaseErrorCode = ParseStoreSpecificPurchaseErrorCode(json);
			_lastPurchaseErrorCode = lastPurchaseErrorCode;
			object obj3 = obj;
			eventQueue = (EventQueue)obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ X8_v54 (UnityEngine.Purchasing.EventQueue)+126]");
			int num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ X8_v54 (UnityEngine.Purchasing.EventQueue)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0489;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ X8_v54 (UnityEngine.Purchasing.EventQueue)+B0]");
			object obj4 = 0L + 8L;
			int num5 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ X11_v8-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IStoreCallback))
				{
					break;
				}
				num5++;
				bool flag3 = num5 < num4;
				bool flag4 = !flag3;
				obj4 = (long)(IntPtr)obj4 + 16L;
				if (!flag4)
				{
					continue;
				}
				goto IL_0489;
			}
			num4 = (int)obj4;
			num4 += 4;
			int num6 = num4 << 4;
			eventQueue = (EventQueue)((long)(IntPtr)eventQueue + (long)num6);
			object obj5 = (long)(IntPtr)eventQueue + 304L;
			goto IL_053b;
			IL_0489:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_053b;
			IL_053b:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v543 @ X0_v11] (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600011D")]
		[Address(RVA = "0xC64960", Offset = "0xC64960", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.lastPurchaseFailureDescription;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PurchaseFailureDescription GetLastPurchaseFailureDescription()
		{
			return lastPurchaseFailureDescription;
		}

		[Token(Token = "0x600011E")]
		[Address(RVA = "0xC64968", Offset = "0xC64968", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._lastPurchaseErrorCode;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public StoreSpecificPurchaseErrorCode GetLastStoreSpecificPurchaseErrorCode()
		{
			return _lastPurchaseErrorCode;
		}

		[Token(Token = "0x600011F")]
		[Address(RVA = "0xC643C8", Offset = "0xC643C8", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EC3578]);\n\tv27 = *([v26 @ X8_v31]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, platformReceipt, transactionId, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023355]) = v44;\nL_001A:\n\tv48 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v48);\n\tv53 = this.m_Module;\n\tv54 = this.m_Module == 0;\n\tif (v54) goto L_FFFFFFFF;\n\tv55 = v53.<storeInstance>k__BackingField;\n\tv83 = v55.<storeName>k__BackingField;\n\tgoto L_003C;\nL_003C:\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v48, v84, v83);\n\tv118 = transactionId == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_004D;\n\tv125 = v123.Empty;\nL_004D:\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v48, \"TransactionID\", v125);\n\tv135 = platformReceipt == 0;\n\tv102 = ~v135;\n\tif (v102) goto L_005C;\n\tv141 = v139.Empty;\nL_005C:\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v48, \"Payload\", v141);\n\treturnVal2 = UnityEngine.Purchasing.MiniJSON.Json::Serialize(v48);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private string FormatUnifiedReceipt(string platformReceipt, string transactionId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			StandardPurchasingModule module = m_Module;
			string value;
			string key;
			if (m_Module != null)
			{
				StandardPurchasingModule.StoreInstance storeInstance = module.storeInstance;
				value = storeInstance.storeName;
				key = "Store";
			}
			else
			{
				value = "unknown";
				key = "Store";
			}
			dictionary.set_Item(key, (object)value);
			bool flag = transactionId == null;
			bool flag2 = !flag;
			string value2 = transactionId;
			if (!flag2)
			{
				value2 = string.Empty;
			}
			dictionary.set_Item("TransactionID", (object)value2);
			bool flag3 = platformReceipt == null;
			bool flag4 = !flag3;
			string value3 = platformReceipt;
			if (!flag4)
			{
				value3 = string.Empty;
			}
			dictionary.set_Item("Payload", (object)value3);
			return Json.Serialize(dictionary);
		}

		[Token(Token = "0x6000120")]
		[Address(RVA = "0xC6471C", Offset = "0xC6471C", Length = "0x244")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1EB9408]);\n\tv35 = *([v34 @ X8_v30]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, json, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([2023356]) = v53;\nL_001B:\n\tv54 = json == 0;\n\tif (v54) goto L_FFFFFFFF;\n\tv57 = UnityEngine.Purchasing.MiniJson::JsonDecode(json);\n\tv139 = v57 == 0;\n\tif (v139) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv79 = v79_asT == 0;\n\tif (v79) goto L_FFFFFFFF;\n\tv136 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(v57, this.kStoreSpecificErrorCodeKey);\n\tv140 = v136 == 0;\n\tif (v140) goto L_FFFFFFFF;\n\tgoto L_005D;\n\tv268 = *([v263 @ X0_v9+E0]);\n\tv269 = v268 == 0;\n\tv270 = ~v269;\n\tif (v270) goto L_005D;\n\tv272 = \"il2cpp_codegen_runtime_class_init\"(v263, v133, v71, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_005D:\n\tv277 = System.Type::GetTypeFromHandle(UnityEngine.Purchasing.StoreSpecificPurchaseErrorCode);\n\tv282 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v57, this.kStoreSpecificErrorCodeKey);\n\tgoto L_0075;\n\tv288 = *([v284 @ X8_v12+E0]);\n\tv289 = v288 == 0;\n\tv290 = ~v289;\n\tif (v290) goto L_0075;\n\tv296 = v284;\n\tv292 = \"il2cpp_codegen_runtime_class_init\"(v296, v279, v281, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0075:\n\tv295 = v282 == 0;\n\tif (v295) goto L_0087;\n\tv308 = *([v282 @ X0_v14 (System.Object)]) != System.String;\n\tif (v308) goto L_00E2;\nL_0087:\n\tv137 = System.Enum::IsDefined(v277, v282);\n\tv141 = v137 == 0;\n\tif (v141) goto L_FFFFFFFF;\n\tv348 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v57, this.kStoreSpecificErrorCodeKey);\n\tv367 = v348 == 0;\n\tif (v367) goto L_00A4;\n\tv368 = *([v348 @ X0_v26 (System.String)]) != System.String;\n\tif (v368) goto L_00E6;\nL_00A4:\n\tgoto L_00AC;\n\tv389 = *([v384 @ X0_v27+E0]);\n\tv390 = v389 == 0;\n\tv391 = ~v390;\n\tif (v391) goto L_00AC;\n\tv393 = \"il2cpp_codegen_runtime_class_init\"(v384, v382, v346, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_00AC:\n\tv398 = System.Type::GetTypeFromHandle(UnityEngine.Purchasing.StoreSpecificPurchaseErrorCode);\n\tgoto L_00BC;\n\tv402 = *([v343 @ X8_v20+E0]);\n\tv403 = v402 == 0;\n\tv404 = ~v403;\n\tif (v404) goto L_00BC;\n\tv409 = v343;\n\tv406 = \"il2cpp_codegen_runtime_class_init\"(v409, v397, v346, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_00BC:\n\tv338 = System.Enum::Parse(v398, v348);\n\tv161 = v161_asT == 0;\n\tif (v161) goto L_00E4;\n\tv414 = \"il2cpp_vm_object_unbox\"(v338, UnityEngine.Purchasing.StoreSpecificPurchaseErrorCode, 0, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturnVal1 = *([v414 @ X0_v34]);\n\tgoto L_00E0;\nL_00E0:\n\treturn returnVal1;\nL_00E2:\n\tv312 = new System.InvalidCastException();\n\tv344 = new System.NullReferenceException();\nL_00E4:\n\tthrow System.InvalidCastException;\nL_00E6:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 162 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private StoreSpecificPurchaseErrorCode ParseStoreSpecificPurchaseErrorCode(string json)
		{
			//IL_023a: Expected I4, but got O
			//IL_01c8: Expected I4, but got O
			//IL_01f7: Expected I4, but got O
			if (json != null)
			{
				object obj = MiniJson.JsonDecode(json);
				if (obj != null)
				{
					Dictionary<string, object> dictionary = obj as Dictionary<string, object>;
					if (dictionary != null && ((Dictionary<string, object>)obj).ContainsKey(kStoreSpecificErrorCodeKey))
					{
						Type typeFromHandle = typeof(StoreSpecificPurchaseErrorCode);
						object obj2 = ((Dictionary<string, object>)obj).get_Item(kStoreSpecificErrorCodeKey);
						if (obj2 == null || (object)obj2.GetType() == typeof(string))
						{
							if (!Enum.IsDefined(typeFromHandle, obj2))
							{
								goto IL_01fc;
							}
							string text = (string)((Dictionary<string, object>)obj).get_Item(kStoreSpecificErrorCodeKey);
							if (text != null && (object)text.GetType() != typeof(string))
							{
								InvalidCastException ex = new InvalidCastException();
								return (StoreSpecificPurchaseErrorCode)ex;
							}
							Type typeFromHandle2 = typeof(StoreSpecificPurchaseErrorCode);
							object obj3 = Enum.Parse(typeFromHandle2, text);
							if ((int)((obj3 is StoreSpecificPurchaseErrorCode) ? obj3 : null) != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
								object obj4 = default(object);
								return (StoreSpecificPurchaseErrorCode)obj4;
							}
						}
						else
						{
							InvalidCastException ex2 = new InvalidCastException();
							NullReferenceException ex3 = new NullReferenceException();
						}
						throw new InvalidCastException();
					}
				}
			}
			goto IL_01fc;
			IL_01fc:
			return StoreSpecificPurchaseErrorCode.Unknown;
		}
	}
}
