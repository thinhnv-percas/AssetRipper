using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000004")]
	public class CodelessIAPStoreListener : IStoreListener
	{
		[Token(Token = "0x400001A")]
		private static CodelessIAPStoreListener instance;

		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0x10")]
		private List<IAPButton> activeButtons;

		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0x18")]
		private List<IAPListener> activeListeners;

		[Token(Token = "0x400001D")]
		private static bool unityPurchasingInitialized;

		[Token(Token = "0x400001E")]
		[FieldOffset(Offset = "0x20")]
		protected IStoreController controller;

		[Token(Token = "0x400001F")]
		[FieldOffset(Offset = "0x28")]
		protected IExtensionProvider extensions;

		[Token(Token = "0x4000020")]
		[FieldOffset(Offset = "0x30")]
		protected ProductCatalog catalog;

		[Token(Token = "0x4000021")]
		public static bool initializationComplete;

		[Token(Token = "0x17000001")]
		public static CodelessIAPStoreListener Instance
		{
			[Token(Token = "0x600001B")]
			[Address(RVA = "0x160B44C", Offset = "0x160B44C", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = *([1EFC360]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A1F0]) = v35;\nL_0015:\n\treturnVal1 = v39.instance;\n\tv41 = v39.instance == 0;\n\tv42 = ~v41;\n\tif (v42) goto L_0021;\n\tUnityEngine.Purchasing.CodelessIAPStoreListener::CreateCodelessIAPStoreListenerInstance();\n\treturnVal1 = v46.instance;\nL_0021:\n\treturn returnVal1;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				CodelessIAPStoreListener result = instance;
				if (instance == null)
				{
					CreateCodelessIAPStoreListenerInstance();
					result = instance;
				}
				return result;
			}
		}

		[Token(Token = "0x17000002")]
		public IStoreController StoreController
		{
			[Token(Token = "0x600001D")]
			[Address(RVA = "0x160B4B0", Offset = "0x160B4B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.controller;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return StoreController;
			}
		}

		[Token(Token = "0x17000003")]
		public IExtensionProvider ExtensionProvider
		{
			[Token(Token = "0x600001E")]
			[Address(RVA = "0x160B4B8", Offset = "0x160B4B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.extensions;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ExtensionProvider;
			}
		}

		[RuntimeInitializeOnLoadMethod]
		[Token(Token = "0x6000018")]
		[Address(RVA = "0x160A5DC", Offset = "0x160A5DC", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = *([1EF41E8]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A1ED]) = v35;\nL_0012:\n\tv37 = UnityEngine.Purchasing.ProductCatalog::LoadDefaultCatalog();\n\tv40 = ~v37.enableCodelessAutoInitialization;\n\tif (v40) goto L_0029;\n\tv43 = UnityEngine.Purchasing.ProductCatalog::IsEmpty(v37);\n\tv55 = v43 == 0;\n\tv48 = ~v55;\n\tif (v48) goto L_0029;\n\tv47 = v69.instance == 0;\n\tif (v47) goto L_002E;\nL_0029:\n\treturn;\nL_002E:\n\tUnityEngine.Purchasing.CodelessIAPStoreListener::CreateCodelessIAPStoreListenerInstance();\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void InitializeCodelessPurchasingOnLoad()
		{
			ProductCatalog productCatalog = ProductCatalog.LoadDefaultCatalog();
			if (productCatalog.enableCodelessAutoInitialization && !productCatalog.IsEmpty() && instance == null)
			{
				CreateCodelessIAPStoreListenerInstance();
			}
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x160A710", Offset = "0x160A710", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EC6EB0]);\n\tv19 = *([v18 @ X8_v34]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([202A1EE]) = v39;\nL_001A:\n\tgoto L_0021;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0021;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0021:\n\tv55 = UnityEngine.Purchasing.StandardPurchasingModule::Instance();\n\tv55.<useFakeStoreUIMode>k__BackingField = 1;\n\tv63 = Il2CppClass<System.EmptyArray`1<UnityEngine.Purchasing.Extension.IPurchasingModule>>;\n\tgoto L_0034;\n\tv69 = v63;\n\tv70 = 0x8907BC(v69, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv73 = *([v63 @ X20_v2 (Il2CppClass<System.EmptyArray`1<UnityEngine.Purchasing.Extension.IPurchasingModule>>)+12E]);\nL_0034:\n\tv74 = *([v63 @ X20_v2 (Il2CppClass<System.EmptyArray`1<UnityEngine.Purchasing.Extension.IPurchasingModule>>)+12E]) & 0x200;\n\tv75 = v74 == 0;\n\tif (v75) goto L_0055;\n\tv96 = Il2CppClass<System.EmptyArray`1<UnityEngine.Purchasing.Extension.IPurchasingModule>>;\n\tgoto L_0041;\n\tv118 = v96;\n\tv119 = 0x8907BC(v118, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0041:\n\tv120 = *([v96 @ X20_v8 (Il2CppClass<System.EmptyArray`1<UnityEngine.Purchasing.Extension.IPurchasingModule>>)+E0]) == 0;\n\tv108 = ~v120;\n\tif (v108) goto L_0055;\n\tgoto L_0055;\n\tv155 = v102;\n\tv156 = 0x8907BC(v155, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0055:\n\tgoto L_005C;\n\tv121 = v113;\n\tv122 = 0x8907BC(v121, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_005C:\n\tv86 = UnityEngine.Purchasing.ConfigurationBuilder::Instance(v55, v124.Value);\n\tv90 = v154.instance;\n\tUnityEngine.Purchasing.IAPConfigurationHelper::PopulateConfigurationBuilder(&v86 @ X0_v14 (UnityEngine.Purchasing.ConfigurationBuilder), v90.catalog);\n\tUnityEngine.Purchasing.UnityPurchasing::Initialize(v162.instance, v86);\n\tv144.unityPurchasingInitialized = 1;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void InitializePurchasing()
		{
			StandardPurchasingModule standardPurchasingModule = StandardPurchasingModule.Instance();
			standardPurchasingModule.useFakeStoreUIMode = FakeStoreUIMode.StandardUser;
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ X20_v2 (Il2CppClass<System.EmptyArray`1<UnityEngine.Purchasing.Extension.IPurchasingModule>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ X20_v8 (Il2CppClass<System.EmptyArray`1<UnityEngine.Purchasing.Extension.IPurchasingModule>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			ConfigurationBuilder builder = ConfigurationBuilder.Instance(standardPurchasingModule);
			CodelessIAPStoreListener codelessIAPStoreListener = instance;
			IAPConfigurationHelper.PopulateConfigurationBuilder(ref builder, codelessIAPStoreListener.catalog);
			UnityPurchasing.Initialize(instance, builder);
			unityPurchasingInitialized = true;
		}

		[Token(Token = "0x600001A")]
		[Address(RVA = "0x160B3A4", Offset = "0x160B3A4", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EB4F40]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A1EF]) = v38;\nL_0016:\n\tv42 = new System.Collections.Generic.List`1<UnityEngine.Purchasing.IAPButton>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.IAPButton>::.ctor(v42);\n\tthis.activeButtons = v42;\n\tv50 = new System.Collections.Generic.List`1<UnityEngine.Purchasing.IAPListener>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.IAPListener>::.ctor(v50);\n\tthis.activeListeners = v50;\n\tSystem.Object::.ctor(this);\n\tv58 = UnityEngine.Purchasing.ProductCatalog::LoadDefaultCatalog();\n\tthis.catalog = v58;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private CodelessIAPStoreListener()
		{
			List<IAPButton> list = new List<IAPButton>();
			activeButtons = list;
			List<IAPListener> list2 = new List<IAPListener>();
			activeListeners = list2;
			ProductCatalog productCatalog = ProductCatalog.LoadDefaultCatalog();
			catalog = productCatalog;
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x160A660", Offset = "0x160A660", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1F10398]);\n\tv17 = *([v16 @ X8_v17]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202A1F1]) = v37;\nL_0015:\n\tv41 = new UnityEngine.Purchasing.CodelessIAPStoreListener();\n\tUnityEngine.Purchasing.CodelessIAPStoreListener::.ctor(v41);\n\tv44.instance = v41;\n\tv48 = ~v46.unityPurchasingInitialized;\n\tif (v48) goto L_002C;\n\treturn;\nL_002C:\n\tgoto L_0036;\n\tv75 = *([v55 @ X0_v4+E0]);\n\tv76 = v75 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_0036;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v55, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0036:\n\tUnityEngine.Debug::Log(\"Initializing UnityPurchasing via Codeless IAP\");\n\tUnityEngine.Purchasing.CodelessIAPStoreListener::InitializePurchasing();\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void CreateCodelessIAPStoreListenerInstance()
		{
			CodelessIAPStoreListener codelessIAPStoreListener = new CodelessIAPStoreListener();
			instance = codelessIAPStoreListener;
			if (!unityPurchasingInitialized)
			{
				Debug.Log("Initializing UnityPurchasing via Codeless IAP");
				InitializePurchasing();
			}
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x160B4C0", Offset = "0x160B4C0", Length = "0x2F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1F00BA8]);\n\tv27 = *([v26 @ X8_v32]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, productID, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([202A1F2]) = v45;\nL_0017:\n\tv46 = &v47 @ stack_-50;\n\tv49 = this.catalog;\n\tv50 = this.catalog == 0;\n\tif (v50) goto L_00CE;\n\tv52 = v49.products == 0;\n\tif (v52) goto L_00CE;\n\tgoto L_004C;\n\tv119 = *([v114 @ X8_v14+B0]);\n\tv120 = 0;\n\tv121 = v119 + 8;\n\tv123 = *([v169 @ X11_v29-8]);\n\tv175 = v123 == v117;\n\tif (v175) goto L_0045;\n\tv145 = v170 + 1;\n\tv182 = v145 < v116;\n\tv141 = ~v182;\n\tv143 = v169 + 0x10;\n\tv125 = ~v141;\n\tif (v125) goto L_FFFFFFFF;\n\tv146 = v51;\n\tv147 = 0;\n\tv148 = 0x8909C4(v146, v117, v147, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_004C;\nL_0045:\n\tv183 = *([v169 @ X11_v29]);\n\tv184 = v183 << 4;\n\tv185 = v114 + v184;\n\tv186 = v185 + 0x130;\nL_004C:\n\tv207 = System.Collections.Generic.IEnumerable`1<UnityEngine.Purchasing.ProductCatalogItem>::GetEnumerator(v49.products);\nL_0058:\n\tgoto L_007F;\n\tv445 = *([v315 @ X8_v19+B0]);\n\tv446 = 0;\n\tv447 = v445 + 8;\n\tv449 = *([v530 @ X11_v24-8]);\n\tv536 = v449 == v316;\n\tif (v536) goto L_0078;\n\tv471 = v531 + 1;\n\tv565 = v471 < v317;\n\tv467 = ~v565;\n\tv469 = v530 + 0x10;\n\tv451 = ~v467;\n\tif (v451) goto L_FFFFFFFF;\n\tv472 = v106;\n\tv473 = 0;\n\tv474 = 0x8909C4(v472, v316, v473, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_007F;\nL_0078:\n\tv566 = *([v530 @ X11_v24]);\n\tv567 = v566 << 4;\n\tv568 = v315 + v567;\n\tv569 = v568 + 0x130;\nL_007F:\n\tv357 = System.Collections.IEnumerator::MoveNext(v207);\n\tv575 = v357 == 0;\n\tif (v575) goto L_00C5;\n\tgoto L_00AE;\n\tv590 = *([v585 @ X8_v23+B0]);\n\tv591 = 0;\n\tv592 = v590 + 8;\n\tv594 = *([v630 @ X11_v19-8]);\n\tv636 = v594 == v586;\n\tif (v636) goto L_00A7;\n\tv616 = v631 + 1;\n\tv641 = v616 < v587;\n\tv612 = ~v641;\n\tv614 = v630 + 0x10;\n\tv596 = ~v612;\n\tif (v596) goto L_FFFFFFFF;\n\tv617 = v106;\n\tv618 = 0;\n\tv619 = 0x8909C4(v617, v586, v618, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_00AE;\nL_00A7:\n\tv642 = *([v630 @ X11_v19]);\n\tv643 = v642 << 4;\n\tv644 = v585 + v643;\n\tv645 = v644 + 0x130;\nL_00AE:\n\tv478 = System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.ProductCatalogItem>::get_Current(v207);\n\tv306 = System.String::op_Equality(v478.id, productID);\n\tv308 = v306 == 0;\n\tif (v308) goto L_0058;\n\t*([v46 @ X22_v1]) = 0x40;\n\tv651 = v207 == 0;\n\tv359 = ~v651;\n\tif (v359) goto L_00EB;\n\tgoto L_0113;\nL_00C5:\n\t*([v46 @ X22_v1]) = 0x3E;\n\tv589 = v207 == 0;\n\tv360 = ~v589;\n\tif (v360) goto L_00EB;\n\tgoto L_0113;\n\tv320 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_00CE:\n\tv112 = new System.NullReferenceException();\n\tgoto L_00DC;\n\tgoto L_00DC;\n\tgoto L_00DC;\n\tgoto L_00DC;\nL_00DC:\n\tv158 = v93 != 1;\n\tif (v158) goto L_0141;\n\tv180 = 0x6D2BC0(v112, v93, v62, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv362 = *([v180 @ X0_v18]);\n\tv211 = 0x6D2490(v180, v93, v62, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv314 = v105 == 0;\n\tif (v314) goto L_0113;\nL_00EB:\n\tgoto L_0112;\n\tv480 = *([v372 @ X8_v9+B0]);\n\tv481 = 0;\n\tv482 = v480 + 8;\n\tv484 = *([v551 @ X11_v8-8]);\n\tv557 = v484 == v375;\n\tif (v557) goto L_010B;\n\tv506 = v552 + 1;\n\tv576 = v506 < v374;\n\tv502 = ~v576;\n\tv504 = v551 + 0x10;\n\tv486 = ~v502;\n\tif (v486) goto L_FFFFFFFF;\n\tv507 = v361;\n\tv508 = 0;\n\tv509 = 0x8909C4(v507, v375, v508, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_0112;\nL_010B:\n\tv577 = *([v551 @ X11_v8]);\n\tv578 = v577 << 4;\n\tv579 = v372 + v578;\n\tv580 = v579 + 0x130;\nL_0112:\n\tSystem.IDisposable::Dispose(v361);\nL_0113:\n\tv400 = v215 + 1;\n\tv236 = v400 == 0;\n\tif (v236) goto L_0132;\n\tv514 = *([v46 @ X22_v1+v215 @ X23_v1 (System.Int32)*4]) == 0x40;\n\tif (v514) goto L_0140;\n\tv257 = v262 == 0;\n\tif (v257) goto L_0140;\n\tv235 = *([v46 @ X22_v1+v215 @ X23_v1 (System.Int32)*4]) == 0x3E;\n\tif (v235) goto L_0140;\n\tgoto L_0145;\nL_0132:\n\tv519 = v262 == 0;\n\tv258 = ~v519;\n\tif (v258) goto L_0145;\nL_0140:\n\treturn v563;\nL_0141:\n\tv181 = 0x6D2380(v112, v93, v62, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0145:\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 181 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool HasProductInCatalog(string productID)
		{
			//IL_02df: Expected I4, but got O
			//IL_01a1: Expected I4, but got O
			//IL_01ea: Expected I4, but got O
			//IL_00f6: Expected O, but got I4
			//IL_0082: Expected O, but got I4
			object obj2 = default(object);
			object obj = obj2;
			ProductCatalog productCatalog = catalog;
			bool flag = catalog == null;
			string text = productID;
			IEnumerable<ProductCatalogItem> enumerable = default(IEnumerable<ProductCatalogItem>);
			CodelessIAPStoreListener codelessIAPStoreListener = (CodelessIAPStoreListener)enumerable;
			IEnumerator<ProductCatalogItem> enumerator = default(IEnumerator<ProductCatalogItem>);
			int num;
			IDisposable disposable;
			int num2;
			int num3;
			int num4;
			int num5;
			int num6;
			if (!flag)
			{
				bool flag2 = productCatalog.products == null;
				string text2 = default(string);
				text = text2;
				codelessIAPStoreListener = (CodelessIAPStoreListener)enumerator;
				if (!flag2)
				{
					enumerator = ((IEnumerable<ProductCatalogItem>)productCatalog.products).GetEnumerator();
					while (enumerator.MoveNext())
					{
						ProductCatalogItem current = enumerator.Current;
						if (!(current.id == productID))
						{
							continue;
						}
						goto IL_0079;
					}
					obj = 62;
					bool flag3 = enumerator == null;
					bool flag4 = !flag3;
					num = 0;
					disposable = enumerator;
					num2 = 0;
					num3 = 0;
					if (!flag4)
					{
						num4 = 0;
						num5 = 0;
						num6 = 0;
						goto IL_0373;
					}
					goto IL_039e;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			if ((IntPtr)text == (IntPtr)1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj3 = default(object);
				num2 = (int)obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				bool flag5 = codelessIAPStoreListener == null;
				num = -1;
				disposable = (IDisposable)codelessIAPStoreListener;
				num3 = 0;
				num4 = -1;
				num5 = (int)obj3;
				num6 = 0;
				if (flag5)
				{
					goto IL_0373;
				}
				goto IL_039e;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			goto IL_02d1;
			IL_0079:
			obj = 64;
			bool flag6 = enumerator == null;
			bool flag7 = !flag6;
			num = 0;
			disposable = enumerator;
			num2 = 0;
			num3 = 1;
			if (!flag7)
			{
				num4 = 0;
				num5 = 0;
				num6 = 1;
				goto IL_0373;
			}
			goto IL_039e;
			IL_02d1:
			TypeLoadException ex2 = new TypeLoadException();
			return (byte)(int)ex2 != 0;
			IL_0373:
			bool result;
			if (num4 + 1 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X22_v1+v215 @ X23_v1 (System.Int32)*4]");
				bool flag8 = (IntPtr)0 == (IntPtr)64;
				result = (byte)num6 != 0;
				if (!flag8)
				{
					bool flag9 = num5 == 0;
					result = false;
					if (!flag9)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X22_v1+v215 @ X23_v1 (System.Int32)*4]");
						bool flag10 = (IntPtr)0 == (IntPtr)62;
						result = false;
						if (!flag10)
						{
							goto IL_02d1;
						}
					}
				}
			}
			else
			{
				if (num5 != 0)
				{
					goto IL_02d1;
				}
				result = false;
			}
			return result;
			IL_039e:
			disposable.Dispose();
			num4 = num;
			num5 = num2;
			num6 = num3;
			goto IL_0373;
		}

		[Token(Token = "0x6000020")]
		[Address(RVA = "0x160B7B8", Offset = "0x160B7B8", Length = "0x1AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EEC910]);\n\tv25 = *([v24 @ X8_v20]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, productID, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202A1F3]) = v43;\nL_0017:\n\tv45 = this.controller == 0;\n\tif (v45) goto L_0054;\n\tgoto L_0046;\n\tv114 = *([v47 @ X8_v9+B0]);\n\tv115 = 0;\n\tv116 = v114 + 8;\n\tv118 = *([v162 @ X11_v13-8]);\n\tv167 = v118 == v50;\n\tif (v167) goto L_003F;\n\tv138 = v161 + 1;\n\tv181 = v138 < v49;\n\tv136 = ~v181;\n\tv140 = v162 + 0x10;\n\tv120 = ~v136;\n\tif (v120) goto L_FFFFFFFF;\n\tv141 = v44;\n\tv142 = 0;\n\tv143 = 0x8909C4(v141, v50, v142, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_0046;\nL_003F:\n\tv182 = *([v162 @ X11_v13]);\n\tv183 = v182 << 4;\n\tv184 = v47 + v183;\n\tv185 = v184 + 0x130;\nL_0046:\n\tv102 = UnityEngine.Purchasing.IStoreController::get_products(this.controller);\n\tv105 = v102 == 0;\n\tif (v105) goto L_0054;\n\tv101 = System.String::IsNullOrEmpty(productID);\n\tv104 = v101 == 0;\n\tif (v104) goto L_0076;\nL_0054:\n\tv113 = System.String::Concat(\"CodelessIAPStoreListener attempted to get unknown product \", productID);\n\tgoto L_0065;\n\tv172 = *([v147 @ X8_v8+E0]);\n\tv173 = v172 == 0;\n\tv174 = ~v173;\n\tif (v174) goto L_0065;\n\tv189 = v147;\n\tv177 = \"il2cpp_codegen_runtime_class_init\"(v189, v110, v111, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0065:\n\tUnityEngine.Debug::LogError(v113);\n\treturn 0;\nL_0076:\n\tgoto L_009D;\n\tv275 = *([v270 @ X8_v13+B0]);\n\tv276 = 0;\n\tv277 = v275 + 8;\n\tv279 = *([v320 @ X11_v8-8]);\n\tv325 = v279 == v271;\n\tif (v325) goto L_0096;\n\tv299 = v319 + 1;\n\tv330 = v299 < v272;\n\tv297 = ~v330;\n\tv301 = v320 + 0x10;\n\tv281 = ~v297;\n\tif (v281) goto L_FFFFFFFF;\n\tv302 = v258;\n\tv303 = 0;\n\tv304 = 0x8909C4(v302, v271, v303, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_009D;\nL_0096:\n\tv331 = *([v320 @ X11_v8]);\n\tv332 = v331 << 4;\n\tv333 = v270 + v332;\n\tv334 = v333 + 0x130;\nL_009D:\n\tv308 = UnityEngine.Purchasing.IStoreController::get_products(this.controller);\n\treturnVal3 = UnityEngine.Purchasing.ProductCollection::WithID(v308, productID);\n\treturn returnVal3;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 103 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Product GetProduct(string productID)
		{
			if (StoreController != null)
			{
				ProductCollection products = StoreController.products;
				if (products != null && !string.IsNullOrEmpty(productID))
				{
					ProductCollection products2 = StoreController.products;
					return products2.WithID(productID);
				}
			}
			string message = "CodelessIAPStoreListener attempted to get unknown product " + productID;
			Debug.LogError(message);
			return null;
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x160B964", Offset = "0x160B964", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv22 = *([1EC9470]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, button, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A1F4]) = v41;\nL_0022:\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.IAPButton>::Add(this.activeButtons, button);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddButton(IAPButton button)
		{
			activeButtons.Add(button);
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0x160B9CC", Offset = "0x160B9CC", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv22 = *([1EE98E8]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, button, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A1F5]) = v41;\nL_0022:\n\tv53 = System.Collections.Generic.List`1<UnityEngine.Purchasing.IAPButton>::Remove(this.activeButtons, button);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RemoveButton(IAPButton button)
		{
			bool flag = activeButtons.Remove(button);
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x160BA34", Offset = "0x160BA34", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv22 = *([1EC0570]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, listener, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A1F6]) = v41;\nL_0022:\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.IAPListener>::Add(this.activeListeners, listener);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddListener(IAPListener listener)
		{
			activeListeners.Add(listener);
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0x160BA9C", Offset = "0x160BA9C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv22 = *([1EFA780]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, listener, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A1F7]) = v41;\nL_0022:\n\tv53 = System.Collections.Generic.List`1<UnityEngine.Purchasing.IAPListener>::Remove(this.activeListeners, listener);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RemoveListener(IAPListener listener)
		{
			bool flag = activeListeners.Remove(listener);
		}

		[Token(Token = "0x6000025")]
		[Address(RVA = "0x160BB04", Offset = "0x160BB04", Length = "0x1E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EFF030]);\n\tv23 = *([v22 @ X8_v26]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, productID, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A1F8]) = v41;\nL_0017:\n\tv44 = 0;\n\tv45 = this.controller;\n\tv46 = this.controller == 0;\n\tif (v46) goto L_0047;\n\tv48 = *([v45 @ X20_v2 (UnityEngine.Purchasing.IStoreController)]);\n\tv52 = *([v48 @ X8_v20 (Il2CppClass<UnityEngine.Purchasing.IStoreController>)+126]) == 0;\n\tif (v52) goto L_003F;\n\tv121 = *([v48 @ X8_v20 (Il2CppClass<UnityEngine.Purchasing.IStoreController>)+B0]) + 8;\nL_002A:\n\tv127 = *([v121 @ X11_v6-8]) == UnityEngine.Purchasing.IStoreController;\n\tif (v127) goto L_0072;\n\tv122 = v122 + 1;\n\tv134 = v122 < *([v48 @ X8_v20 (Il2CppClass<UnityEngine.Purchasing.IStoreController>)+126]);\n\tv90 = ~v134;\n\tv121 = v121 + 0x10;\n\tv66 = ~v90;\n\tif (v66) goto L_002A;\nL_003F:\n\tv156 = 0x8909C4(this.controller, UnityEngine.Purchasing.IStoreController, 3, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_007A;\nL_0047:\n\tgoto L_0051;\n\tv100 = *([v55 @ X0_v3+E0]);\n\tv101 = v100 == 0;\n\tv102 = ~v101;\n\tif (v102) goto L_0051;\n\tv104 = \"il2cpp_codegen_runtime_class_init\"(v55, productID, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0051:\n\tUnityEngine.Debug::LogError(\"Purchase failed because Purchasing was not initialized correctly\");\n\tv133 = this.activeButtons == 0;\n\tif (v133) goto L_0084;\n\tv167 = System.Collections.Generic.List`1<UnityEngine.Purchasing.IAPButton>::GetEnumerator(this.activeButtons);\nL_005E:\n\tv272 = System.Collections.Generic.List`1<UnityEngine.Purchasing.IAPButton>+Enumerator<UnityEngine.Purchasing.IAPButton>::MoveNext(&v44 @ stack_-48_v1 (System.Collections.Generic.List`1<UnityEngine.Purchasing.IAPButton>+Enumerator<UnityEngine.Purchasing.IAPButton>));\n\tv216 = v272 == 0;\n\tif (v216) goto L_0080;\n\tv180 = 0;\n\tv267 = System.String::op_Equality(v180.productId, productID);\n\tv270 = v267 == 0;\n\tif (v270) goto L_005E;\n\tUnityEngine.Purchasing.IAPButton::OnPurchaseFailed(0, 0, 0);\n\tgoto L_005E;\nL_0072:\n\tv136 = *([v121 @ X11_v6]) + 3;\n\tv137 = v136 << 4;\n\tv138 = v48 + v137;\n\tv156 = v138 + 0x130;\nL_007A:\n\t*([v156 @ X0_v29])(v162, this.controller, productID, *([v156 @ X0_v29+8]), v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_00A4;\nL_0080:\n\tv213 = System.Collections.Generic.List`1<UnityEngine.Purchasing.IAPButton>+Enumerator<UnityEngine.Purchasing.IAPButton>::Dispose(&v44 @ stack_-48_v1 (System.Collections.Generic.List`1<UnityEngine.Purchasing.IAPButton>+Enumerator<UnityEngine.Purchasing.IAPButton>));\n\tgoto L_00A4;\n\tv173 = new System.NullReferenceException();\nL_0084:\n\tv181 = new System.NullReferenceException();\n\tgoto L_0091;\n\tgoto L_0091;\n\tgoto L_0091;\nL_0091:\n\tv186 = Il2CppMethodInfo != 1;\n\tif (v186) goto L_00A5;\n\tv275 = 0x6D2BC0(v181, Il2CppMethodInfo, v168, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv279 = 0x6D2490(v275, Il2CppMethodInfo, v168, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv212 = System.Collections.Generic.List`1<UnityEngine.Purchasing.IAPButton>+Enumerator<UnityEngine.Purchasing.IAPButton>::Dispose(&v44 @ stack_-48_v1 (System.Collections.Generic.List`1<UnityEngine.Purchasing.IAPButton>+Enumerator<UnityEngine.Purchasing.IAPButton>));\n\tv288 = *([v275 @ X0_v13]) == 0;\n\tv215 = ~v288;\n\tif (v215) goto L_00A9;\nL_00A4:\n\treturn;\nL_00A5:\n\tv276 = 0x6D2380(v181, Il2CppMethodInfo, v168, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00A9:\n\tthrow System.TypeLoadException;\n// 104 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void InitiatePurchase(string productID)
		{
			//IL_000d: Expected I, but got O
			//IL_0048: Expected O, but got I
			//IL_0168: Unknown result type (might be due to invalid IL or missing references)
			//IL_016d: Expected O, but got Unknown
			//IL_018a: Expected O, but got I
			//IL_0199: Expected O, but got I
			//IL_0094: Expected O, but got I
			//IL_0132: Expected I, but got O
			//IL_015a: Expected I, but got O
			List<IAPButton>.Enumerator enumerator = default(List<IAPButton>.Enumerator);
			IStoreController storeController = StoreController;
			if (StoreController != null)
			{
				IntPtr intPtr = (IntPtr)storeController;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v20 (Il2CppClass<UnityEngine.Purchasing.IStoreController>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v20 (Il2CppClass<UnityEngine.Purchasing.IStoreController>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ X11_v6-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IStoreController))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v20 (Il2CppClass<UnityEngine.Purchasing.IStoreController>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00ad;
				}
				object obj2 = obj + 3;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_0295;
			}
			Debug.LogError("Purchase failed because Purchasing was not initialized correctly");
			if (activeButtons != null)
			{
				List<IAPButton>.Enumerator enumerator2 = activeButtons.GetEnumerator();
				while (enumerator.MoveNext())
				{
					IAPButton iAPButton = null;
					bool flag3 = iAPButton.productId == productID;
					bool flag4 = !flag3;
					IntPtr intPtr2 = (IntPtr)null;
					if (!flag4)
					{
						((IAPButton)null).OnPurchaseFailed((Product)null, default(PurchaseFailureReason));
						intPtr2 = (IntPtr)null;
					}
				}
				enumerator.Dispose();
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			if ((IntPtr)0 == (IntPtr)1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj5 = default(object);
				if (obj5 == null)
				{
					return;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0295;
			IL_0295:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v156 @ X0_v29] (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0x160BDCC", Offset = "0x160BDCC", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1ED1A30]);\n\tv27 = *([v26 @ X8_v19]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, controller, extensions, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202A1F9]) = v44;\nL_001B:\n\tv49 = 0;\n\tv52.initializationComplete = 1;\n\tthis.controller = controller;\n\tthis.extensions = extensions;\n\tv54 = this.activeButtons == 0;\n\tif (v54) goto L_003E;\n\tv59 = System.Collections.Generic.List`1<UnityEngine.Purchasing.IAPButton>::GetEnumerator(this.activeButtons);\nL_002E:\n\tv76 = 0xEF9AB0(&v49 @ stack_-48_v1, Il2CppMethodInfo, extensions, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv87 = v76 & 1;\n\tv88 = v87 == 0;\n\tif (v88) goto L_003B;\n\tUnityEngine.Purchasing.IAPButton::UpdateText(0);\n\tgoto L_002E;\nL_003B:\n\tv95 = 0xEF9AAC(&v49 @ stack_-48_v1, Il2CppMethodInfo, extensions, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_005E;\n\tv63 = new System.NullReferenceException();\nL_003E:\n\tv69 = new System.NullReferenceException();\n\tgoto L_004A;\n\tgoto L_004A;\nL_004A:\n\tv86 = Il2CppMethodInfo != 1;\n\tif (v86) goto L_005F;\n\tv89 = 0x6D2BC0(v69, Il2CppMethodInfo, extensions, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv97 = 0x6D2490(v89, Il2CppMethodInfo, extensions, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv101 = 0xEF9AAC(&v49 @ stack_-48_v1, Il2CppMethodInfo, extensions, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = *([v89 @ X0_v10]) == 0;\n\tv103 = ~v142;\n\tif (v103) goto L_0063;\nL_005E:\n\treturn;\nL_005F:\n\tv90 = 0x6D2380(v69, Il2CppMethodInfo, extensions, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0063:\n\tthrow System.TypeLoadException;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
		{
			//IL_00c9: Expected O, but got I4
			object obj = 0;
			initializationComplete = true;
			this.controller = controller;
			this.extensions = extensions;
			if (activeButtons != null)
			{
				List<IAPButton>.Enumerator enumerator = activeButtons.GetEnumerator();
				object obj2 = default(object);
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AB0");
					if ((int)((long)(IntPtr)obj2 & 1L) == 0)
					{
						break;
					}
					((IAPButton)null).UpdateText();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AAC");
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			if ((IntPtr)0 == (IntPtr)1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AAC");
				object obj3 = default(object);
				if (obj3 == null)
				{
					return;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x6000027")]
		[Address(RVA = "0x160C070", Offset = "0x160C070", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EF6280]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, error, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202A1FA]) = v38;\nL_0017:\n\t// 23 Box v43 @ X0_v3, typeof(UnityEngine.Purchasing.InitializationFailureReason), &error @ X1 (UnityEngine.Purchasing.InitializationFailureReason)\n\tv46 = *([v43 @ X0_v3]);\n\t*([v46 @ X8_v5+160])(v50, v43, *([v46 @ X8_v5+168]), methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv53 = \"il2cpp_vm_object_unbox\"(v43, *([v46 @ X8_v5+168]), methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv62 = System.String::Format(\"Purchasing failed to initialize. Reason: {0}\", v50);\n\tgoto L_003B;\n\tv90 = *([v66 @ X8_v9+E0]);\n\tv91 = v90 == 0;\n\tv92 = ~v91;\n\tif (v92) goto L_003B;\n\tv95 = v66;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v95, v58, v59, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_003B:\n\tUnityEngine.Debug::LogError(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnInitializeFailed(InitializationFailureReason error)
		{
			object obj = error;
			object obj2 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v46 @ X8_v5+160] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			object arg = default(object);
			string message = $"Purchasing failed to initialize. Reason: {arg}";
			Debug.LogError(message);
		}

		[Token(Token = "0x6000028")]
		[Address(RVA = "0x160C148", Offset = "0x160C148", Length = "0x2CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv28 = *([1EDA6E0]);\n\tv29 = *([v28 @ X8_v42]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, e, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([202A1FB]) = v47;\nL_001C:\n\tv52 = 0;\n\tv61 = System.Collections.Generic.List`1<UnityEngine.Purchasing.IAPButton>::GetEnumerator(this.activeButtons);\n\tgoto L_0052;\nL_0034:\n\tv312 = e.<purchasedProduct>k__BackingField;\n\tv204 = v312.<definition>k__BackingField;\n\tv327 = v312.<definition>k__BackingField == 0;\n\tif (v327) goto L_0064;\n\tv199 = System.String::op_Equality(v133.productId, v204.<id>k__BackingField);\n\tv201 = v199 == 0;\n\tif (v201) goto L_0052;\n\tv198 = UnityEngine.Purchasing.IAPButton::ProcessPurchase(v133, e);\n\tv184 = v198 == 0;\n\tv107 = v107 | v184;\nL_0052:\n\tv209 = System.Collections.Generic.List`1<UnityEngine.Purchasing.IAPButton>+Enumerator<UnityEngine.Purchasing.IAPButton>::MoveNext(&v60 @ stack_-90_v4 (System.Collections.Generic.List`1<UnityEngine.Purchasing.IAPButton>+Enumerator<UnityEngine.Purchasing.IAPButton>));\n\tv254 = v209 == 0;\n\tv255 = ~v254;\n\tif (v255) goto L_0034;\n\tv260 = System.Collections.Generic.List`1<UnityEngine.Purchasing.IAPButton>+Enumerator<UnityEngine.Purchasing.IAPButton>::Dispose(&v60 @ stack_-90_v4 (System.Collections.Generic.List`1<UnityEngine.Purchasing.IAPButton>+Enumerator<UnityEngine.Purchasing.IAPButton>));\n\tgoto L_0088;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_0064:\n\tv333 = new System.NullReferenceException();\n\tgoto L_0074;\n\tgoto L_0074;\n\tgoto L_0074;\n\tgoto L_0074;\n\tgoto L_0074;\n\tgoto L_0074;\nL_0074:\n\tv138 = Il2CppMethodInfo != 1;\n\tif (v138) goto L_00FE;\n\tv360 = System.Collections.Generic.List`1<UnityEngine.Purchasing.IAPButton>+Enumerator<UnityEngine.Purchasing.IAPButton>::MoveNext(v333);\n\tv373 = System.Collections.Generic.List`1<UnityEngine.Purchasing.IAPButton>+Enumerator<UnityEngine.Purchasing.IAPButton>::MoveNext(v360);\n\tv166 = System.Collections.Generic.List`1<UnityEngine.Purchasing.IAPButton>+Enumerator<UnityEngine.Purchasing.IAPButton>::Dispose(&v60 @ stack_-90_v4 (System.Collections.Generic.List`1<UnityEngine.Purchasing.IAPButton>+Enumerator<UnityEngine.Purchasing.IAPButton>));\n\tv380 = ~v360.m_value;\n\tv168 = ~v380;\n\tif (v168) goto L_00B0;\nL_0088:\n\tv326 = System.Collections.Generic.List`1<UnityEngine.Purchasing.IAPListener>::GetEnumerator(this.activeListeners);\n\tgoto L_009F;\nL_0090:\n\tv349 = UnityEngine.Purchasing.IAPListener::ProcessPurchase(0, e);\n\tv340 = v349 == 0;\n\tv107 = v107 | v340;\nL_009F:\n\tv353 = System.Collections.Generic.List`1<UnityEngine.Purchasing.IAPListener>+Enumerator<UnityEngine.Purchasing.IAPListener>::MoveNext(&v52 @ stack_-78_v1 (System.Collections.Generic.List`1<UnityEngine.Purchasing.IAPListener>+Enumerator<UnityEngine.Purchasing.IAPListener>));\n\tv357 = v353 == 0;\n\tv358 = ~v357;\n\tif (v358) goto L_0090;\n\tv370 = System.Collections.Generic.List`1<UnityEngine.Purchasing.IAPListener>+Enumerator<UnityEngine.Purchasing.IAPListener>::Dispose(&v52 @ stack_-78_v1 (System.Collections.Generic.List`1<UnityEngine.Purchasing.IAPListener>+Enumerator<UnityEngine.Purchasing.IAPListener>));\n\tv374 = v100 & 1;\n\tv375 = v374 == 0;\n\tif (v375) goto L_00CF;\n\tgoto L_00EF;\n\tv119 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_00B0:\n\tgoto L_0102;\n\tgoto L_00B3;\n\tgoto L_00B3;\nL_00B3:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00FE;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1ECA898]);\n\tX0 = &stack[18];\n\tX1 = *([X8]);\n\tX0 = 0xEF9AAC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00FF;\n\tTEMP = X23 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00EF;\nL_00CF:\n\tv393 = e.<purchasedProduct>k__BackingField;\n\tv396 = v393.<definition>k__BackingField;\n\tv404 = System.String::Concat(\"Purchase not correctly processed for product \\\"\", v396.<id>k__BackingField, \"\\\". Add an active IAPButton to process this purchase, or add an IAPListener to receive any unhandled purchase events.\");\n\tgoto L_00EE;\n\tv410 = *([v392 @ X8_v28+E0]);\n\tv411 = v410 == 0;\n\tv412 = ~v411;\n\tif (v412) goto L_00EE;\n\tv415 = v392;\n\tv414 = \"il2cpp_codegen_runtime_class_init\"(v415, v398, v383, v381, v33, v34, v35, v36, v112, v38, v39, v40, v41, v42, v43, v44);\nL_00EE:\n\tUnityEngine.Debug::LogError(v404);\nL_00EF:\n\tv295 = ~v107;\n\treturnVal2 = v295 & 1;\n\treturn returnVal2;\n\tv363 = new System.NullReferenceException();\nL_00FE:\n\tv366 = 0x6D2380(v362, Il2CppMethodInfo, v98, v32, v33, v34, v35, v36, v60, v38, v39, v40, v41, v42, v43, v44);\nL_00FF:\n\t;\nL_0102:\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 157 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
		{
			//IL_009b: Expected I, but got O
			//IL_0303: Expected I4, but got O
			//IL_00db: Expected I, but got O
			List<IAPListener>.Enumerator enumerator = default(List<IAPListener>.Enumerator);
			List<IAPButton>.Enumerator enumerator2 = activeButtons.GetEnumerator();
			int num = 0;
			int num2 = 0;
			List<IAPButton>.Enumerator enumerator3 = default(List<IAPButton>.Enumerator);
			IAPButton iAPButton = default(IAPButton);
			while (true)
			{
				if (enumerator3.MoveNext())
				{
					Product purchasedProduct = e.purchasedProduct;
					ProductDefinition definition = purchasedProduct.definition;
					if (purchasedProduct.definition != null)
					{
						bool flag = iAPButton.productId == definition.id;
						bool flag2 = !flag;
						IntPtr intPtr = (IntPtr)null;
						if (!flag2)
						{
							PurchaseProcessingResult purchaseProcessingResult = iAPButton.ProcessPurchase(e);
							bool flag3 = purchaseProcessingResult == PurchaseProcessingResult.Complete;
							num2 |= (flag3 ? 1 : 0);
							intPtr = (IntPtr)null;
							num = 1;
						}
						continue;
					}
					NullReferenceException ex = new NullReferenceException();
					if ((IntPtr)0 != (IntPtr)1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
						break;
					}
					bool flag4 = ((List<IAPButton>.Enumerator*)ex)->MoveNext();
					bool flag5 = (flag4 ? ((List<IAPButton>.Enumerator*)1) : ((List<IAPButton>.Enumerator*)null))->MoveNext();
					enumerator3.Dispose();
					if (((bool*)(flag4 ? 1 : 0))->m_value)
					{
						break;
					}
				}
				else
				{
					enumerator3.Dispose();
				}
				List<IAPListener>.Enumerator enumerator4 = activeListeners.GetEnumerator();
				while (enumerator.MoveNext())
				{
					PurchaseProcessingResult purchaseProcessingResult2 = ((IAPListener)null).ProcessPurchase(e);
					bool flag6 = purchaseProcessingResult2 == PurchaseProcessingResult.Complete;
					num2 |= (flag6 ? 1 : 0);
					num = 1;
				}
				enumerator.Dispose();
				if ((num & 1) == 0)
				{
					Product purchasedProduct2 = e.purchasedProduct;
					ProductDefinition definition2 = purchasedProduct2.definition;
					string message = "Purchase not correctly processed for product \"" + definition2.id + "\". Add an active IAPButton to process this purchase, or add an IAPListener to receive any unhandled purchase events.";
					Debug.LogError(message);
				}
				int num3 = ~num2;
				return (PurchaseProcessingResult)(num3 & 1);
			}
			TypeLoadException ex2 = new TypeLoadException();
			return (PurchaseProcessingResult)ex2;
		}

		[Token(Token = "0x6000029")]
		[Address(RVA = "0x160C5D4", Offset = "0x160C5D4", Length = "0x2A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv32 = *([1EE3FF8]);\n\tv33 = *([v32 @ X8_v34]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, product, reason, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202A1FC]) = v50;\nL_001E:\n\tv55 = 0;\n\tv64 = System.Collections.Generic.List`1<UnityEngine.Purchasing.IAPButton>::GetEnumerator(this.activeButtons);\nL_0032:\n\tv237 = 0xEF9AB0(&v63 @ stack_-A0_v4, Il2CppMethodInfo, v96, methodInfo, v36, v37, v38, v39, v63, v41, v42, v43, v44, v45, v46, v47);\n\tv238 = v237 & 1;\n\tv239 = v238 == 0;\n\tif (v239) goto L_004F;\n\tv181 = product.<definition>k__BackingField;\n\tv295 = product.<definition>k__BackingField == 0;\n\tif (v295) goto L_0056;\n\tv231 = System.String::op_Equality(v129.productId, v181.<id>k__BackingField);\n\tv179 = v231 == 0;\n\tif (v179) goto L_0032;\n\tUnityEngine.Purchasing.IAPButton::OnPurchaseFailed(v129, product, v171);\n\tgoto L_FFFFFFFF;\nL_004F:\n\tv291 = 0xEF9AAC(&v63 @ stack_-A0_v4, Il2CppMethodInfo, v96, methodInfo, v36, v37, v38, v39, v63, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_0079;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_0056:\n\tv307 = new System.NullReferenceException();\n\tgoto L_0065;\n\tgoto L_0065;\n\tgoto L_0065;\n\tgoto L_0065;\n\tgoto L_0065;\nL_0065:\n\tv134 = Il2CppMethodInfo != 1;\n\tif (v134) goto L_00DE;\n\tv325 = 0x6D2BC0(v307, Il2CppMethodInfo, v96, methodInfo, v36, v37, v38, v39, v63, v41, v42, v43, v44, v45, v46, v47);\n\tv329 = 0x6D2490(v325, Il2CppMethodInfo, v96, methodInfo, v36, v37, v38, v39, v63, v41, v42, v43, v44, v45, v46, v47);\n\tv161 = 0xEF9AAC(&v63 @ stack_-A0_v4, Il2CppMethodInfo, v96, methodInfo, v36, v37, v38, v39, v63, v41, v42, v43, v44, v45, v46, v47);\n\tv345 = *([v325 @ X0_v41]) == 0;\n\tv163 = ~v345;\n\tif (v163) goto L_0097;\nL_0079:\n\tv311 = System.Collections.Generic.List`1<UnityEngine.Purchasing.IAPListener>::GetEnumerator(this.activeListeners);\nL_007F:\n\tv324 = 0xEF9AB0(&v55 @ stack_-88_v1, Il2CppMethodInfo, v96, methodInfo, v36, v37, v38, v39, v63, v41, v42, v43, v44, v45, v46, v47);\n\tv327 = v324 & 1;\n\tv328 = v327 == 0;\n\tif (v328) goto L_008F;\n\tUnityEngine.Purchasing.IAPListener::OnPurchaseFailed(0, product, v171);\n\tgoto L_007F;\nL_008F:\n\tv332 = 0xEF9AAC(&v55 @ stack_-88_v1, Il2CppMethodInfo, v96, methodInfo, v36, v37, v38, v39, v63, v41, v42, v43, v44, v45, v46, v47);\n\tv343 = v66 & 1;\n\tv344 = v343 == 0;\n\tif (v344) goto L_00B6;\n\tgoto L_00DD;\n\tv114 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_0097:\n\tgoto L_00E4;\n\tgoto L_009A;\n\tgoto L_009A;\nL_009A:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00DE;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1ECA898]);\n\tX0 = &stack[18];\n\tX1 = *([X8]);\n\tX0 = 0xEF9AAC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00E1;\n\tTEMP = X21 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00DD;\nL_00B6:\n\tv336 = product.<definition>k__BackingField;\n\tv361 = System.String::Concat(\"Failed purchase not correctly handled for product \\\"\", v336.<id>k__BackingField, \"\\\". Add an active IAPButton to handle this failure, or add an IAPListener to receive any unhandled purchase failures.\");\n\tgoto L_00D2;\n\tv367 = *([v354 @ X8_v25+E0]);\n\tv368 = v367 == 0;\n\tv369 = ~v368;\n\tif (v369) goto L_00D2;\n\tv372 = v354;\n\tv371 = \"il2cpp_codegen_runtime_class_init\"(v372, v355, v348, v346, v36, v37, v38, v39, v107, v41, v42, v43, v44, v45, v46, v47);\nL_00D2:\n\tUnityEngine.Debug::LogError(v361);\nL_00DD:\n\treturn;\nL_00DE:\n\tv326 = 0x6D2380(v307, Il2CppMethodInfo, v96, methodInfo, v36, v37, v38, v39, v63, v41, v42, v43, v44, v45, v46, v47);\n\tthrow System.NullReferenceException;\nL_00E1:\n\t;\nL_00E4:\n\tthrow System.TypeLoadException;\n// 138 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
		{
			//IL_0217: Expected O, but got I4
			object obj = 0;
			List<IAPButton>.Enumerator enumerator = activeButtons.GetEnumerator();
			int num = 0;
			PurchaseFailureReason purchaseFailureReason2 = default(PurchaseFailureReason);
			object obj2 = default(object);
			IAPButton iAPButton = default(IAPButton);
			object obj3 = default(object);
			object obj4 = default(object);
			while (true)
			{
				PurchaseFailureReason purchaseFailureReason = purchaseFailureReason2;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AB0");
					if ((uint)((ulong)(long)(IntPtr)obj2 & 1uL) != 0)
					{
						ProductDefinition definition = product.definition;
						if (product.definition != null)
						{
							bool flag = iAPButton.productId == definition.id;
							bool flag2 = !flag;
							purchaseFailureReason = default(PurchaseFailureReason);
							if (!flag2)
							{
								break;
							}
							continue;
						}
						NullReferenceException ex = new NullReferenceException();
						if ((IntPtr)0 != (IntPtr)1)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
							throw new NullReferenceException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AAC");
						if (obj3 != null)
						{
							throw new TypeLoadException();
						}
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AAC");
					}
					List<IAPListener>.Enumerator enumerator2 = activeListeners.GetEnumerator();
					int num2 = num;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AB0");
						if ((int)((long)(IntPtr)obj4 & 1L) == 0)
						{
							break;
						}
						((IAPListener)null).OnPurchaseFailed(product, purchaseFailureReason2);
						num2 = 1;
						purchaseFailureReason = purchaseFailureReason2;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AAC");
					if ((num2 & 1) == 0)
					{
						ProductDefinition definition2 = product.definition;
						string message = "Failed purchase not correctly handled for product \"" + definition2.id + "\". Add an active IAPButton to handle this failure, or add an IAPListener to receive any unhandled purchase failures.";
						Debug.LogError(message);
					}
					return;
				}
				iAPButton.OnPurchaseFailed(product, purchaseFailureReason2);
				num = 1;
			}
		}
	}
}
