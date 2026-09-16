using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.Purchasing.Extension;
using UnityEngine.Purchasing.MiniJSON;
using UnityEngine.UDP;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000039")]
	internal class UDPBindings : IInitListener, IPurchaseListener, INativeUDPStore, INativeStore
	{
		[Token(Token = "0x4000095")]
		[FieldOffset(Offset = "0x10")]
		private Action<bool, string> m_PurchaseCallback;

		[Token(Token = "0x4000096")]
		[FieldOffset(Offset = "0x18")]
		private Action<bool, string> m_InitCallback;

		[Token(Token = "0x4000097")]
		[FieldOffset(Offset = "0x20")]
		private Action<bool, string> m_RetrieveProductsCallback;

		[Token(Token = "0x4000098")]
		[FieldOffset(Offset = "0x28")]
		private Inventory m_Inventory;

		[Token(Token = "0x4000099")]
		[FieldOffset(Offset = "0x30")]
		private Dictionary<string, PurchaseInfo> m_LocalPurchasesCache;

		[Token(Token = "0x400009A")]
		[FieldOffset(Offset = "0x38")]
		private bool m_InitOperating;

		[Token(Token = "0x60000B7")]
		[Address(RVA = "0x15B1358", Offset = "0x15B1358", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1F01B38]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20298C0]) = v41;\nL_0015:\n\tv42 = callback == 0;\n\tif (v42) goto L_0030;\n\tv44 = ~this.m_InitOperating;\n\tif (v44) goto L_0032;\n\tSystem.Action`2<System.Boolean, System.String>::Invoke(callback, 0, \"{ \\\"error\\\" : \\\"already initializing\\\" }\");\n\treturn;\nL_0030:\n\treturn;\nL_0032:\n\tthis.m_InitCallback = callback;\n\tthis.m_InitOperating = 1;\n\tv67 = new System.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.PurchaseInfo>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.PurchaseInfo>::.ctor(v67);\n\tthis.m_LocalPurchasesCache = v67;\n\tUnityEngine.UDP.StoreService::Initialize(this, 0);\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Initialize(Action<bool, string> callback)
		{
			if (callback != null)
			{
				if (m_InitOperating)
				{
					callback(arg1: false, "{ \"error\" : \"already initializing\" }");
					return;
				}
				m_InitCallback = callback;
				m_InitOperating = true;
				Dictionary<string, PurchaseInfo> localPurchasesCache = new Dictionary<string, PurchaseInfo>();
				m_LocalPurchasesCache = localPurchasesCache;
				StoreService.Initialize(this);
			}
		}

		[Token(Token = "0x60000B8")]
		[Address(RVA = "0x15B1430", Offset = "0x15B1430", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EB45F8]);\n\tv31 = *([v30 @ X8_v8]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, productId, callback, developerPayload, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20298C1]) = v47;\nL_0019:\n\tv48 = callback == 0;\n\tif (v48) goto L_0038;\n\tv50 = this.m_PurchaseCallback == 0;\n\tif (v50) goto L_0039;\n\tSystem.Action`2<System.Boolean, System.String>::Invoke(callback, 0, \"{ \\\"error\\\" : \\\"already purchasing\\\" }\");\n\treturn;\nL_0038:\n\treturn;\nL_0039:\n\tthis.m_PurchaseCallback = callback;\n\tUnityEngine.UDP.StoreService::Purchase(productId, developerPayload, this);\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Purchase(string productId, Action<bool, string> callback, string developerPayload = null)
		{
			if (callback != null)
			{
				if (m_PurchaseCallback != null)
				{
					callback(arg1: false, "{ \"error\" : \"already purchasing\" }");
					return;
				}
				m_PurchaseCallback = callback;
				StoreService.Purchase(productId, developerPayload, this);
			}
		}

		[Token(Token = "0x60000B9")]
		[Address(RVA = "0x15B14F4", Offset = "0x15B14F4", Length = "0x2DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EA3C28]);\n\tv31 = *([v30 @ X8_v33]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, products, callback, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([20298C2]) = v48;\nL_0019:\n\tv49 = callback == 0;\n\tif (v49) goto L_003A;\n\tv51 = this.m_RetrieveProductsCallback == 0;\n\tif (v51) goto L_003B;\n\tSystem.Action`2<System.Boolean, System.String>::Invoke(callback, 0, \"{ \\\"error\\\" : \\\"already retrieving products\\\" }\");\n\treturn;\nL_003A:\n\treturn;\nL_003B:\n\tthis.m_RetrieveProductsCallback = callback;\n\tv79 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v79);\n\tv176 = products == 0;\n\tif (v176) goto L_00C5;\n\tv181 = System.Collections.ObjectModel.ReadOnlyCollection`1<UnityEngine.Purchasing.ProductDefinition>::GetEnumerator(products);\nL_0059:\n\tgoto L_0080;\n\tv298 = *([v282 @ X8_v21+B0]);\n\tv299 = 0;\n\tv300 = v298 + 8;\n\tv302 = *([v365 @ X11_v24-8]);\n\tv370 = v302 == v283;\n\tif (v370) goto L_0079;\n\tv322 = v364 + 1;\n\tv379 = v322 < v284;\n\tv320 = ~v379;\n\tv324 = v365 + 0x10;\n\tv304 = ~v320;\n\tif (v304) goto L_FFFFFFFF;\n\tv325 = v223;\n\tv326 = 0;\n\tv327 = 0x8909C4(v325, v283, v326, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_0080;\nL_0079:\n\tv380 = *([v365 @ X11_v24]);\n\tv381 = v380 << 4;\n\tv382 = v282 + v381;\n\tv383 = v382 + 0x130;\nL_0080:\n\tv404 = System.Collections.IEnumerator::MoveNext(v181);\n\tv406 = v404 == 0;\n\tif (v406) goto L_00BB;\n\tgoto L_00AF;\n\tv503 = *([v467 @ X8_v24+B0]);\n\tv504 = 0;\n\tv505 = v503 + 8;\n\tv507 = *([v566 @ X11_v19-8]);\n\tv571 = v507 == v468;\n\tif (v571) goto L_00A8;\n\tv527 = v565 + 1;\n\tv584 = v527 < v469;\n\tv525 = ~v584;\n\tv529 = v566 + 0x10;\n\tv509 = ~v525;\n\tif (v509) goto L_FFFFFFFF;\n\tv530 = v223;\n\tv531 = 0;\n\tv532 = 0x8909C4(v530, v468, v531, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_00AF;\nL_00A8:\n\tv585 = *([v566 @ X11_v19]);\n\tv586 = v585 << 4;\n\tv587 = v467 + v586;\n\tv588 = v587 + 0x130;\nL_00AF:\n\tv347 = System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.ProductDefinition>::get_Current(v181);\n\tSystem.Collections.Generic.List`1<System.String>::Add(v79, v347.<storeSpecificId>k__BackingField);\n\tgoto L_0059;\nL_00BB:\n\tv471 = v181 == 0;\n\tv428 = ~v471;\n\tif (v428) goto L_00E2;\n\tgoto L_010A;\n\tv287 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_00C5:\n\tv229 = new System.NullReferenceException();\n\tgoto L_00D4;\n\tgoto L_00D4;\n\tgoto L_00D4;\n\tgoto L_00D4;\n\tgoto L_00D4;\nL_00D4:\n\tv281 = v140 != 1;\n\tif (v281) goto L_0126;\n\tv288 = 0x6D2BC0(v229, v140, v144, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv431 = *([v288 @ X0_v20]);\n\tv353 = 0x6D2490(v288, v140, v144, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv378 = v181 == 0;\n\tif (v378) goto L_010A;\nL_00E2:\n\tgoto L_0109;\n\tv472 = *([v434 @ X8_v11+B0]);\n\tv473 = 0;\n\tv474 = v472 + 8;\n\tv476 = *([v544 @ X11_v8-8]);\n\tv549 = v476 == v437;\n\tif (v549) goto L_0102;\n\tv496 = v543 + 1;\n\tv576 = v496 < v436;\n\tv494 = ~v576;\n\tv498 = v544 + 0x10;\n\tv478 = ~v494;\n\tif (v478) goto L_FFFFFFFF;\n\tv499 = v429;\n\tv500 = 0;\n\tv501 = 0x8909C4(v499, v437, v500, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_0109;\nL_0102:\n\tv577 = *([v544 @ X11_v8]);\n\tv578 = v577 << 4;\n\tv579 = v434 + v578;\n\tv580 = v579 + 0x130;\nL_0109:\n\tSystem.IDisposable::Dispose(v429);\nL_010A:\n\tv466 = v289 + 1;\n\tv110 = v466 == 0;\n\tv90 = ~v110;\n\tif (v90) goto L_0120;\n\tv502 = v297 == 0;\n\tv295 = ~v502;\n\tif (v295) goto L_0125;\nL_0120:\n\tUnityEngine.UDP.StoreService::QueryInventory(v79, this);\n\treturn;\nL_0125:\n\tv294 = new System.TypeLoadException();\nL_0126:\n\tv153 = 0x6D2380(v229, 0, 0, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\treturn;\n// 175 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RetrieveProducts(ReadOnlyCollection<ProductDefinition> products, Action<bool, string> callback)
		{
			//IL_0148: Expected I4, but got O
			//IL_0185: Expected I4, but got O
			if (callback == null)
			{
				return;
			}
			if (m_RetrieveProductsCallback != null)
			{
				callback(arg1: false, "{ \"error\" : \"already retrieving products\" }");
				return;
			}
			m_RetrieveProductsCallback = callback;
			List<string> list = new List<string>();
			bool flag = products == null;
			IEnumerator<ProductDefinition> enumerator2 = default(IEnumerator<ProductDefinition>);
			IEnumerator<ProductDefinition> enumerator = enumerator2;
			int num;
			int num2;
			int num3;
			int num4;
			NullReferenceException ex;
			if (!flag)
			{
				enumerator2 = products.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					ProductDefinition current = enumerator2.Current;
					list.Add(current.storeSpecificId);
				}
				bool flag2 = enumerator2 == null;
				bool flag3 = !flag2;
				num = 0;
				enumerator = enumerator2;
				num2 = 0;
				if (!flag3)
				{
					num3 = 0;
					num4 = 0;
					goto IL_024a;
				}
			}
			else
			{
				ex = new NullReferenceException();
				IntPtr intPtr = default(IntPtr);
				if (intPtr != (IntPtr)1)
				{
					goto IL_01e1;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj = default(object);
				num2 = (int)obj;
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				bool flag4 = enumerator2 == null;
				num = -1;
				num3 = -1;
				num4 = (int)obj;
				if (flag4)
				{
					goto IL_024a;
				}
			}
			enumerator.Dispose();
			num3 = num;
			num4 = num2;
			goto IL_024a;
			IL_01e1:
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			return;
			IL_024a:
			if (num3 + 1 != 0 || num4 == 0)
			{
				StoreService.QueryInventory(list, this);
				return;
			}
			TypeLoadException ex2 = new TypeLoadException();
			ex = (NullReferenceException)(object)ex2;
			goto IL_01e1;
		}

		[Token(Token = "0x60000BA")]
		[Address(RVA = "0x15B17D0", Offset = "0x15B17D0", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = UnityEngine.Purchasing.UDPBindings::FindPurchaseInfo(this, transactionID);\n\tv13 = v12 == 0;\n\tif (v13) goto L_0016;\n\tUnityEngine.UDP.StoreService::ConsumePurchase(v12, this);\n\treturn;\nL_0016:\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void FinishTransaction(ProductDefinition productDefinition, string transactionID)
		{
			PurchaseInfo purchaseInfo = FindPurchaseInfo(transactionID);
			if (purchaseInfo != null)
			{
				StoreService.ConsumePurchase(purchaseInfo, this);
			}
		}

		[Token(Token = "0x60000BB")]
		[Address(RVA = "0x15B180C", Offset = "0x15B180C", Length = "0x364")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = &v15 @ X29;\n\tgoto L_001B;\n\tv29 = *([1EBF2F8]);\n\tv30 = *([v29 @ X8_v39]);\n\tv31 = \"il2cpp_codegen_initialize_method\"(v30, transactionId, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([20298C3]) = v48;\nL_001B:\n\tv50 = &v51 @ stack_-C0;\n\t*([v15 @ X29-50]) = 0;\n\t*([v15 @ X29-68]) = 0;\n\t*([v15 @ X29-60]) = 0;\n\t*([v15 @ X29-78]) = 0;\n\t*([v15 @ X29-88]) = 0;\n\tv56 = UnityEngine.UDP.Inventory::GetPurchaseList(this.m_Inventory);\n\tv176 = System.Collections.Generic.List`1<UnityEngine.UDP.PurchaseInfo>::GetEnumerator(v56);\n\t*([v15 @ X29-50]) = *([v15 @ X29-90]);\n\t*([v15 @ X29-60]) = *([v15 @ X29-A0]);\nL_0035:\n\tv244 = &v15 @ X29 - 0x60;\n\tv245 = System.Collections.Generic.List`1<UnityEngine.UDP.PurchaseInfo>+Enumerator<UnityEngine.UDP.PurchaseInfo>::MoveNext(v244);\n\tv306 = v245 == 0;\n\tif (v306) goto L_FFFFFFFF;\n\tv110 = *([v15 @ X29-50]);\n\tv240 = System.String::Equals(v110.<GameOrderId>k__BackingField, transactionId);\n\tv242 = v240 == 0;\n\tif (v242) goto L_0035;\n\tv398 = UnityEngine.UDP.Inventory::GetPurchaseDictionary(this.m_Inventory);\n\tv400 = v398 == 0;\n\tif (v400) goto L_00AC;\n\tgoto L_0081;\n\tv515 = *([v468 @ X8_v33+B0]);\n\tv516 = 0;\n\tv517 = v515 + 8;\n\tv519 = *([v558 @ X11_v13-8]);\n\tv564 = v519 == v471;\n\tif (v564) goto L_0078;\n\tv541 = v559 + 1;\n\tv579 = v541 < v470;\n\tv537 = ~v579;\n\tv539 = v558 + 0x10;\n\tv521 = ~v537;\n\tif (v521) goto L_FFFFFFFF;\n\tv542 = 5;\n\tv543 = v402;\n\tv544 = 0x8909C4(v543, v471, v542, v33, v34, v35, v36, v37, v112, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_0081;\n\tgoto L_0085;\nL_0078:\n\tv580 = *([v558 @ X11_v13]);\n\tv581 = v580 + 5;\n\tv582 = v581 << 4;\n\tv583 = v468 + v582;\n\tv584 = v583 + 0x130;\nL_0081:\n\tv350 = System.Collections.Generic.IDictionary`2<System.String, UnityEngine.UDP.PurchaseInfo>::Remove(v398, v110.<ProductId>k__BackingField);\nL_0085:\n\tv359 = &v15 @ X29 - 0x60;\n\t*([v50 @ X23_v1]) = v355;\n\tv361 = System.Collections.Generic.List`1<UnityEngine.UDP.PurchaseInfo>+Enumerator<UnityEngine.UDP.PurchaseInfo>::Dispose(v359);\n\tv374 = v355 != 0xDB;\n\tif (v374) goto L_0098;\n\tgoto L_0148;\nL_0098:\n\tv386 = v355 - 0x6B;\n\tv388 = v386 == 0;\n\tv393 = ~v388;\n\tv394 = ~v393;\n\tif (v394) goto L_FFFFFFFF;\n\tgoto L_00A6;\nL_00A6:\n\tgoto L_00D1;\n\tv313 = new System.NullReferenceException();\n\tv364 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_00AC:\n\tv504 = new System.NullReferenceException();\n\tgoto L_00BB;\n\tgoto L_00BB;\n\tgoto L_00BB;\n\tgoto L_00BB;\n\tgoto L_00BB;\nL_00BB:\n\tv135 = v502 != 1;\n\tif (v135) goto L_0149;\n\tv472 = 0x6D2BC0(v504, v502, v499, v33, v34, v35, v36, v37, *([v15 @ X29-A0]), v39, v40, v41, v42, v43, v44, v45);\n\tv545 = 0x6D2490(v472, v502, v499, v33, v34, v35, v36, v37, *([v15 @ X29-A0]), v39, v40, v41, v42, v43, v44, v45);\n\tv570 = &v15 @ X29 - 0x60;\n\tv164 = System.Collections.Generic.List`1<UnityEngine.UDP.PurchaseInfo>+Enumerator<UnityEngine.UDP.PurchaseInfo>::Dispose(v570);\n\tv589 = *([v472 @ X0_v47]) == 0;\n\tv166 = ~v589;\n\tif (v166) goto L_00FF;\nL_00D1:\n\tv514 = System.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.PurchaseInfo>::GetEnumerator(this.m_LocalPurchasesCache);\nL_00D5:\n\tv577 = &v15 @ X29 - 0x88;\n\tv578 = System.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.PurchaseInfo>+Enumerator<System.String, UnityEngine.UDP.PurchaseInfo>::MoveNext(v577);\n\tv591 = v578 == 0;\n\tif (v591) goto L_00F6;\n\tv446 = *([v15 @ X29-70]);\n\tv573 = System.String::Equals(v446.<GameOrderId>k__BackingField, transactionId);\n\tv575 = v573 == 0;\n\tif (v575) goto L_00D5;\n\tv507 = this.m_LocalPurchasesCache == 0;\n\tif (v507) goto L_0100;\n\tv631 = System.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.PurchaseInfo>::Remove(this.m_LocalPurchasesCache, v446.<GameOrderId>k__BackingField);\n\tv432 = v432 + 1;\n\t*([v50 @ X23_v1+v432 @ X22_v5 (System.Int32)*4]) = 0xDB;\n\tgoto L_0116;\nL_00F6:\n\tv432 = v432 + 1;\n\t*([v50 @ X23_v1+v432 @ X22_v5 (System.Int32)*4]) = 0xD6;\n\tgoto L_FFFFFFFF;\n\tv600 = new System.NullReferenceException();\n\tv117 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_00FF:\n\tgoto L_014D;\nL_0100:\n\tv504 = new System.NullReferenceException();\n\tgoto L_010E;\n\tgoto L_010E;\n\tgoto L_010E;\n\tgoto L_010E;\nL_010E:\n\tv478 = transactionId != 1;\n\tif (v478) goto L_0149;\n\tv647 = 0x6D2BC0(v504, transactionId, 0, v33, v34, v35, v36, v37, *([v15 @ X29-A0]), v39, v40, v41, v42, v43, v44, v45);\n\tv443 = *([v647 @ X0_v32]);\n\tv614 = 0x6D2490(v647, transactionId, 0, v33, v34, v35, v36, v37, *([v15 @ X29-A0]), v39, v40, v41, v42, v43, v44, v45);\nL_0116:\n\tv637 = &v15 @ X29 - 0x88;\n\tv437 = System.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.PurchaseInfo>+Enumerator<System.String, UnityEngine.UDP.PurchaseInfo>::Dispose(v637);\n\tv440 = v432 + 1;\n\tv419 = v440 == 0;\n\tif (v419) goto L_0138;\n\tv420 = *([v50 @ X23_v1+v432 @ X22_v5 (System.Int32)*4]) == 0xDB;\n\tif (v420) goto L_0148;\n\tv441 = v443 == 0;\n\tif (v441) goto L_0148;\n\tv421 = *([v50 @ X23_v1+v432 @ X22_v5 (System.Int32)*4]) == 0xD6;\n\tif (v421) goto L_0148;\n\tgoto L_014D;\nL_0138:\n\tv641 = v443 == 0;\n\tv439 = ~v641;\n\tif (v439) goto L_014D;\nL_0148:\n\treturn v446;\nL_0149:\n\tv510 = 0x6D2380(v504, transactionId, 0, v33, v34, v35, v36, v37, *([v15 @ X29-A0]), v39, v40, v41, v42, v43, v44, v45);\nL_014D:\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 201 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe PurchaseInfo FindPurchaseInfo(string transactionId)
		{
			//IL_041f: Expected O, but got I
			//IL_047c: Expected O, but got I
			//IL_0484: Expected O, but got I4
			//IL_005d: Expected O, but got I
			//IL_04c6: Expected O, but got I
			//IL_020b: Expected O, but got I
			//IL_04ff: Expected O, but got I
			//IL_01a3: Expected O, but got I
			//IL_0308: Expected I4, but got O
			object obj = obj;
			object obj3 = default(object);
			object obj2 = obj3;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			List<PurchaseInfo> purchaseList = m_Inventory.GetPurchaseList();
			List<PurchaseInfo>.Enumerator enumerator = purchaseList.GetEnumerator();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X29-90]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X29-A0]");
			_ = 0;
			string text = default(string);
			object obj4 = default(object);
			object obj5 = default(object);
			while (true)
			{
				List<PurchaseInfo>.Enumerator enumerator2 = (List<PurchaseInfo>.Enumerator)((long)(IntPtr)obj - 96L);
				PurchaseInfo purchaseInfo;
				int num;
				int num2;
				NullReferenceException ex;
				if (((List<PurchaseInfo>.Enumerator*)enumerator2)->MoveNext())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X29-50]");
					purchaseInfo = (PurchaseInfo)0;
					if (!purchaseInfo.GameOrderId.Equals(transactionId))
					{
						continue;
					}
					IDictionary<string, PurchaseInfo> purchaseDictionary = m_Inventory.GetPurchaseDictionary();
					if (purchaseDictionary == null)
					{
						ex = new NullReferenceException();
						if ((IntPtr)text == (IntPtr)1)
						{
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
							List<PurchaseInfo>.Enumerator enumerator3 = (List<PurchaseInfo>.Enumerator)((long)(IntPtr)obj - 96L);
							((List<PurchaseInfo>.Enumerator*)enumerator3)->Dispose();
							if (obj4 == null)
							{
								num = -1;
								purchaseInfo = null;
								goto IL_01e7;
							}
							break;
						}
						goto IL_03d1;
					}
					bool flag = purchaseDictionary.Remove(purchaseInfo.ProductId);
					num2 = 219;
				}
				else
				{
					purchaseInfo = null;
					num2 = 107;
				}
				List<PurchaseInfo>.Enumerator enumerator4 = (List<PurchaseInfo>.Enumerator)((long)(IntPtr)obj - 96L);
				obj2 = num2;
				((List<PurchaseInfo>.Enumerator*)enumerator4)->Dispose();
				PurchaseInfo purchaseInfo2;
				if (num2 == 219)
				{
					purchaseInfo2 = purchaseInfo;
					goto IL_04ad;
				}
				num = ((num2 - 107 == 0) ? (-1) : 0);
				goto IL_01e7;
				IL_0243:
				int num3;
				if (m_LocalPurchasesCache != null)
				{
					bool flag2 = m_LocalPurchasesCache.Remove(purchaseInfo2.GameOrderId);
					num++;
					_ = 219;
					num3 = 0;
					goto IL_04f0;
				}
				ex = new NullReferenceException();
				if ((IntPtr)transactionId == (IntPtr)1)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
					num3 = (int)obj5;
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
					goto IL_031c;
				}
				goto IL_03d1;
				IL_031c:
				purchaseInfo2 = purchaseInfo;
				goto IL_04f0;
				IL_04f0:
				Dictionary<string, PurchaseInfo>.Enumerator enumerator5 = (Dictionary<string, PurchaseInfo>.Enumerator)((long)(IntPtr)obj - 136L);
				((Dictionary<string, PurchaseInfo>.Enumerator*)enumerator5)->Dispose();
				if (num + 1 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X23_v1+v432 @ X22_v5 (System.Int32)*4]");
					if ((IntPtr)0 != (IntPtr)219)
					{
						bool flag3 = num3 == 0;
						purchaseInfo2 = null;
						if (!flag3)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X23_v1+v432 @ X22_v5 (System.Int32)*4]");
							bool flag4 = (IntPtr)0 == (IntPtr)214;
							purchaseInfo2 = null;
							if (!flag4)
							{
								break;
							}
						}
					}
				}
				else
				{
					if (num3 != 0)
					{
						break;
					}
					purchaseInfo2 = null;
				}
				goto IL_04ad;
				IL_04ad:
				return purchaseInfo2;
				IL_01e7:
				Dictionary<string, PurchaseInfo>.Enumerator enumerator6 = m_LocalPurchasesCache.GetEnumerator();
				while (true)
				{
					Dictionary<string, PurchaseInfo>.Enumerator enumerator7 = (Dictionary<string, PurchaseInfo>.Enumerator)((long)(IntPtr)obj - 136L);
					if (!((Dictionary<string, PurchaseInfo>.Enumerator*)enumerator7)->MoveNext())
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X29-70]");
					purchaseInfo2 = (PurchaseInfo)0;
					if (!purchaseInfo2.GameOrderId.Equals(transactionId))
					{
						continue;
					}
					goto IL_0243;
				}
				num++;
				_ = 214;
				num3 = 0;
				goto IL_031c;
				IL_03d1:
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
				break;
			}
			return (PurchaseInfo)(object)new TypeLoadException();
		}

		[Token(Token = "0x60000BC")]
		[Address(RVA = "0x15B1B70", Offset = "0x15B1B70", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EE9998]);\n\tv23 = *([v22 @ X8_v5]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, userInfo, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20298C4]) = v41;\nL_0016:\n\tv43 = UnityEngine.Purchasing.UDPBindings::StringPropertyToDictionary(userInfo);\n\tv45 = UnityEngine.Purchasing.MiniJSON.MiniJsonExtensions::toJson(v43);\n\tSystem.Action`2<System.Boolean, System.String>::Invoke(this.m_InitCallback, 1, v45);\n\tthis.m_InitOperating = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnInitialized(UserInfo userInfo)
		{
			Dictionary<string, string> obj = StringPropertyToDictionary(userInfo);
			string arg = obj.toJson();
			m_InitCallback(arg1: true, arg);
			m_InitOperating = false;
		}

		[Token(Token = "0x60000BD")]
		[Address(RVA = "0x15B1DD4", Offset = "0x15B1DD4", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1ECE378]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, message, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20298C5]) = v41;\nL_0018:\n\tv45 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v45);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v45, \"error\", message);\n\tv67 = UnityEngine.Purchasing.MiniJSON.MiniJsonExtensions::toJson(v45);\n\tSystem.Action`2<System.Boolean, System.String>::Invoke(this.m_InitCallback, 0, v67);\n\tthis.m_InitOperating = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnInitializeFailed(string message)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.set_Item("error", message);
			string arg = dictionary.toJson();
			m_InitCallback(arg1: false, arg);
			m_InitOperating = false;
		}

		[Token(Token = "0x60000BE")]
		[Address(RVA = "0x15B1EA8", Offset = "0x15B1EA8", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EDEA18]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, purchaseInfo, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20298C6]) = v41;\nL_0016:\n\tv43 = UnityEngine.Purchasing.UDPBindings::StringPropertyToDictionary(purchaseInfo);\n\tv45 = UnityEngine.Purchasing.MiniJSON.MiniJsonExtensions::toJson(v43);\n\tSystem.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.PurchaseInfo>::set_Item(this.m_LocalPurchasesCache, purchaseInfo.<GameOrderId>k__BackingField, purchaseInfo);\n\tSystem.Action`2<System.Boolean, System.String>::Invoke(this.m_PurchaseCallback, 1, v45);\n\tthis.m_PurchaseCallback = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnPurchase(PurchaseInfo purchaseInfo)
		{
			Dictionary<string, string> obj = StringPropertyToDictionary(purchaseInfo);
			string arg = obj.toJson();
			m_LocalPurchasesCache.set_Item(purchaseInfo.GameOrderId, purchaseInfo);
			m_PurchaseCallback(arg1: true, arg);
			m_PurchaseCallback = null;
		}

		[Token(Token = "0x60000BF")]
		[Address(RVA = "0x15B1F58", Offset = "0x15B1F58", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1EE12B0]);\n\tv29 = *([v28 @ X8_v16]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, message, purchaseInfo, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20298C7]) = v46;\nL_001B:\n\tv50 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v50);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v50, \"error\", message);\n\tv79 = purchaseInfo == 0;\n\tif (v79) goto L_0039;\n\tv81 = UnityEngine.Purchasing.UDPBindings::StringPropertyToDictionary(purchaseInfo);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v50, \"purchaseInfo\", v81);\nL_0039:\n\tv72 = UnityEngine.Purchasing.MiniJSON.MiniJsonExtensions::toJson(v50);\n\tSystem.Action`2<System.Boolean, System.String>::Invoke(this.m_PurchaseCallback, 0, v72);\n\tthis.m_PurchaseCallback = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnPurchaseFailed(string message, PurchaseInfo purchaseInfo)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.set_Item("error", (object)message);
			if (purchaseInfo != null)
			{
				Dictionary<string, string> value = StringPropertyToDictionary(purchaseInfo);
				dictionary.set_Item("purchaseInfo", (object)value);
			}
			string arg = dictionary.toJson();
			m_PurchaseCallback(arg1: false, arg);
			m_PurchaseCallback = null;
		}

		[Token(Token = "0x60000C0")]
		[Address(RVA = "0x15B2060", Offset = "0x15B2060", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1F05CD8]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, purchaseInfo, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([20298C8]) = v38;\nL_001A:\n\tv45 = System.String::Concat(\"Consume Success for \", purchaseInfo.<GameOrderId>k__BackingField);\n\tgoto L_0030;\n\tv55 = *([v51 @ X8_v7+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_0030;\n\tv79 = v51;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v79, v41, v43, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0030:\n\tUnityEngine.Debug::Log(v45);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnPurchaseConsume(PurchaseInfo purchaseInfo)
		{
			string message = "Consume Success for " + purchaseInfo.GameOrderId;
			Debug.Log(message);
		}

		[Token(Token = "0x60000C1")]
		[Address(RVA = "0x15B20F4", Offset = "0x15B20F4", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EE7928]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, message, purchaseInfo, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([20298C9]) = v38;\nL_0018:\n\tv44 = System.String::Concat(\"Consume Failed: \", message);\n\tgoto L_002E;\n\tv52 = *([v48 @ X8_v7+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_002E;\n\tv65 = v48;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v65, v41, v42, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_002E:\n\tUnityEngine.Debug::Log(v44);\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnPurchaseConsumeFailed(string message, PurchaseInfo purchaseInfo)
		{
			string message2 = "Consume Failed: " + message;
			Debug.Log(message2);
		}

		[Token(Token = "0x60000C2")]
		[Address(RVA = "0x15B217C", Offset = "0x15B217C", Length = "0x5D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv36 = *([1F0F598]);\n\tv37 = *([v36 @ X8_v71]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, inventory, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([20298CA]) = v55;\nL_001D:\n\tthis.m_Inventory = inventory;\n\tv60 = new System.Collections.Generic.HashSet`1<UnityEngine.Purchasing.Extension.ProductDescription>();\n\tSystem.Collections.Generic.HashSet`1<UnityEngine.Purchasing.Extension.ProductDescription>::.ctor(v60);\n\tv68 = UnityEngine.UDP.Inventory::GetProductList(inventory);\n\tgoto L_005C;\n\tv254 = *([v202 @ X8_v11+B0]);\n\tv255 = 0;\n\tv256 = v254 + 8;\n\tv258 = *([v366 @ X11_v34-8]);\n\tv372 = v258 == v205;\n\tif (v372) goto L_0055;\n\tv280 = v367 + 1;\n\tv377 = v280 < v204;\n\tv276 = ~v377;\n\tv278 = v366 + 0x10;\n\tv260 = ~v276;\n\tif (v260) goto L_FFFFFFFF;\n\tv281 = v161;\n\tv282 = 0;\n\tv283 = 0x8909C4(v281, v205, v282, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_005C;\nL_0055:\n\tv378 = *([v366 @ X11_v34]);\n\tv379 = v378 << 4;\n\tv380 = v202 + v379;\n\tv381 = v380 + 0x130;\nL_005C:\n\tv402 = System.Collections.Generic.IEnumerable`1<UnityEngine.UDP.ProductInfo>::GetEnumerator(v68);\nL_0067:\n\tgoto L_008E;\n\tv535 = *([v527 @ X8_v27+B0]);\n\tv536 = 0;\n\tv537 = v535 + 8;\n\tv539 = *([v603 @ X11_v29-8]);\n\tv609 = v539 == v531;\n\tif (v609) goto L_0087;\n\tv561 = v604 + 1;\n\tv654 = v561 < v529;\n\tv557 = ~v654;\n\tv559 = v603 + 0x10;\n\tv541 = ~v557;\n\tif (v541) goto L_FFFFFFFF;\n\tv562 = v145;\n\tv563 = 0;\n\tv564 = 0x8909C4(v562, v531, v563, v470, v468, v466, v464, v462, v45, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_008E;\nL_0087:\n\tv655 = *([v603 @ X11_v29]);\n\tv656 = v655 << 4;\n\tv657 = v527 + v656;\n\tv658 = v657 + 0x130;\nL_008E:\n\tv679 = System.Collections.IEnumerator::MoveNext(v402);\n\tv681 = v679 == 0;\n\tif (v681) goto L_016E;\n\tgoto L_00BF;\n\tv765 = *([v731 @ X8_v30+B0]);\n\tv766 = 0;\n\tv767 = v765 + 8;\n\tv769 = *([v850 @ X11_v24-8]);\n\tv856 = v769 == v735;\n\tif (v856) goto L_00B8;\n\tv791 = v851 + 1;\n\tv916 = v791 < v733;\n\tv787 = ~v916;\n\tv789 = v850 + 0x10;\n\tv771 = ~v787;\n\tif (v771) goto L_FFFFFFFF;\n\tv792 = v145;\n\tv793 = 0;\n\tv794 = 0x8909C4(v792, v735, v793, v470, v468, v466, v464, v462, v45, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_00BF;\nL_00B8:\n\tv917 = *([v850 @ X11_v24]);\n\tv918 = v917 << 4;\n\tv919 = v731 + v918;\n\tv920 = v919 + 0x130;\nL_00BF:\n\tv586 = System.Collections.Generic.IEnumerator`1<UnityEngine.UDP.ProductInfo>::get_Current(v402);\n\tgoto L_00D6;\n\tv967 = *([v954 @ X0_v53+E0]);\n\tv968 = v967 == 0;\n\tv969 = ~v968;\n\tif (v969) goto L_00D6;\n\tv971 = \"il2cpp_codegen_runtime_class_init\"(v954, v584, v570, v470, v468, v466, v464, v462, v45, v46, v47, v48, v49, v50, v51, v52);\nL_00D6:\n\tv976 = System.Convert::ToDecimal(v586.<PriceAmountMicros>k__BackingField);\n\tv985 = 0xEA3B2C(&v475 @ stack_-70_v12, 0xF4240, 0, v470, v468, v466, 0, 0, v45, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_00F1;\n\tv992 = *([v988 @ X0_v59+E0]);\n\tv993 = v992 == 0;\n\tv994 = ~v993;\n\tif (v994) goto L_00F1;\n\tv996 = \"il2cpp_codegen_runtime_class_init\"(v988, v983, v984, v470, v468, v466, v464, v462, v45, v46, v47, v48, v49, v50, v51, v52);\nL_00F1:\n\tv1004 = System.Decimal::op_Division(v976, 0);\n\tv1009 = new UnityEngine.Purchasing.ProductMetadata();\n\tUnityEngine.Purchasing.ProductMetadata::.ctor(v1009, v586.<Price>k__BackingField, v586.<Title>k__BackingField, v586.<Description>k__BackingField, v586.<Currency>k__BackingField, v1004);\n\tv1016 = new UnityEngine.Purchasing.Extension.ProductDescription();\n\tUnityEngine.Purchasing.Extension.ProductDescription::.ctor(v1016, v586.<ProductId>k__BackingField, v1009);\n\tv1024 = UnityEngine.UDP.Inventory::HasPurchase(inventory, v586.<ProductId>k__BackingField);\n\tv1026 = v1024 == 0;\n\tif (v1026) goto L_016A;\n\tv1028 = UnityEngine.UDP.Inventory::GetPurchaseInfo(inventory, v586.<ProductId>k__BackingField);\n\tv720 = UnityEngine.Purchasing.UDPBindings::StringPropertyToDictionary(v1028);\n\tv1050 = System.Collections.Generic.Dictionary`2<System.String, System.String>::get_Item(v720, \"GameOrderId\");\n\tv1057 = System.Collections.Generic.Dictionary`2<System.String, System.String>::get_Item(v720, \"ProductId\");\n\tv1060 = System.String::IsNullOrEmpty(v1050);\n\tv1062 = v1060 == 0;\n\tv1063 = ~v1062;\n\tif (v1063) goto L_0140;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v720, \"transactionId\", v1050);\nL_0140:\n\tv1079 = System.String::IsNullOrEmpty(v1057);\n\tv1081 = v1079 == 0;\n\tv1082 = ~v1081;\n\tif (v1082) goto L_0151;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v720, \"storeSpecificId\", v1057);\nL_0151:\n\tv756 = UnityEngine.Purchasing.MiniJSON.MiniJsonExtensions::toJson(v720);\n\tv757 = v1028 == 0;\n\tif (v757) goto L_017B;\n\tv1096 = new UnityEngine.Purchasing.Extension.ProductDescription();\n\tUnityEngine.Purchasing.Extension.ProductDescription::.ctor(v1096, v586.<ProductId>k__BackingField, v1009, v756, v1028.<GameOrderId>k__BackingField);\nL_016A:\n\tv517 = System.Collections.Generic.HashSet`1<UnityEngine.Purchasing.Extension.ProductDescription>::Add(v60, v485);\n\tgoto L_0067;\nL_016E:\n\tv739 = v402 == 0;\n\tv740 = ~v739;\n\tif (v740) goto L_01B0;\n\tgoto L_01D8;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_017B:\n\tv764 = new System.NullReferenceException();\n\tgoto L_01A2;\n\t// 381 Jump @b92\n\t// 382 Jump @b92\n\t// 383 Jump @b92\n\t// 384 Jump @b92\n\t// 385 Jump @b92\n\t// 386 Jump @b92\n\t// 387 Jump @b92\n\t// 388 Jump @b92\n\t// 389 Jump @b92\n\t// 390 Jump @b92\n\t// 391 Jump @b92\n\t// 392 Jump @b92\n\t// 393 Jump @b92\n\t// 394 Jump @b92\n\t// 395 Jump @b92\n\tgoto L_01A2;\n\t// 397 Jump @b92\n\t// 398 Jump @b92\n\t// 399 Jump @b92\n\t// 400 Jump @b92\n\t// 401 Jump @b92\n\t// 402 Jump @b92\n\tgoto L_01A2;\n\tgoto L_01A2;\nL_01A2:\n\tv318 = v342 != 1;\n\tif (v318) goto L_0205;\n\tv966 = System.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v764, v342, v764);\n\tv829 = *([v966 @ X0_v34 (System.Collections.Generic.Dictionary`2<System.String, System.String>)]);\n\tv825 = System.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v966, v342, v764);\n\tv827 = v402 == 0;\n\tif (v827) goto L_01D8;\nL_01B0:\n\tgoto L_01D7;\n\tv886 = *([v835 @ X8_v18+B0]);\n\tv887 = 0;\n\tv888 = v886 + 8;\n\tv890 = *([v937 @ X11_v13-8]);\n\tv943 = v890 == v838;\n\tif (v943) goto L_01D0;\n\tv912 = v938 + 1;\n\tv958 = v912 < v837;\n\tv908 = ~v958;\n\tv910 = v937 + 0x10;\n\tv892 = ~v908;\n\tif (v892) goto L_FFFFFFFF;\n\tv913 = v145;\n\tv914 = 0;\n\tv915 = 0x8909C4(v913, v838, v914, v801, v800, v799, v798, v797, v45, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_01D7;\nL_01D0:\n\tv959 = *([v937 @ X11_v13]);\n\tv960 = v959 << 4;\n\tv961 = v835 + v960;\n\tv962 = v961 + 0x130;\nL_01D7:\n\tSystem.IDisposable::Dispose(v402);\nL_01D8:\n\tv885 = v249 + 1;\n\tv125 = v885 == 0;\n\tv110 = ~v125;\n\tif (v110) goto L_01E4;\n\tv924 = v155 == 0;\n\tv243 = ~v924;\n\tif (v243) goto L_0204;\nL_01E4:\n\tv149 = UnityEngine.Purchasing.JSONSerializer::SerializeProductDescs(v153);\n\tSystem.Action`2<System.Boolean, System.String>::Invoke(this.m_RetrieveProductsCallback, 1, v149);\n\tthis.m_RetrieveProductsCallback = 0;\n\treturn;\n\tthrow System.NullReferenceException;\nL_0204:\n\tv344 = new System.TypeLoadException();\nL_0205:\n\tv355 = System.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v344, 0, v315);\n\treturn;\n// 320 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnQueryInventory(Inventory inventory)
		{
			//IL_02c2: Expected I, but got O
			//IL_02e6: Expected I, but got O
			//IL_031b: Expected I, but got O
			//IL_0361: Expected I, but got O
			m_Inventory = inventory;
			HashSet<ProductDescription> hashSet = new HashSet<ProductDescription>();
			IList<ProductInfo> productList = inventory.GetProductList();
			IEnumerator<ProductInfo> enumerator = productList.GetEnumerator();
			HashSet<ProductDescription> hashSet2 = hashSet;
			string text3 = default(string);
			NullReferenceException value3;
			TypeLoadException ex2;
			Dictionary<string, string> dictionary2 = default(Dictionary<string, string>);
			while (true)
			{
				IntPtr intPtr;
				int num;
				HashSet<ProductDescription> products;
				IntPtr intPtr2;
				int num2;
				ProductDescription item;
				if (!enumerator.MoveNext())
				{
					bool flag = enumerator == null;
					bool flag2 = !flag;
					intPtr = (IntPtr)null;
					num = 0;
					if (!flag2)
					{
						products = hashSet2;
						intPtr2 = (IntPtr)null;
						num2 = 0;
						goto IL_0465;
					}
				}
				else
				{
					ProductInfo current = enumerator.Current;
					decimal num3 = Convert.ToDecimal(current.PriceAmountMicros);
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @EA3B2C (inside System.DateTimeParse+MatchNumberDelegate::EndInvoke +0x38)");
					decimal num4 = num3 / default(decimal);
					ProductMetadata metadata = new ProductMetadata(current.Price, current.Title, current.Description, current.Currency, num4);
					ProductDescription productDescription = new ProductDescription(current.ProductId, metadata);
					bool flag3 = inventory.HasPurchase(current.ProductId);
					bool flag4 = !flag3;
					decimal num5 = num4;
					string currency = current.Currency;
					string text = null;
					item = productDescription;
					if (flag4)
					{
						goto IL_0284;
					}
					PurchaseInfo purchaseInfo = inventory.GetPurchaseInfo(current.ProductId);
					Dictionary<string, string> dictionary = StringPropertyToDictionary(purchaseInfo);
					string value = dictionary.get_Item("GameOrderId");
					string value2 = dictionary.get_Item("ProductId");
					if (!string.IsNullOrEmpty(value))
					{
						dictionary.set_Item("transactionId", value);
					}
					if (!string.IsNullOrEmpty(value2))
					{
						dictionary.set_Item("storeSpecificId", value2);
					}
					string text2 = dictionary.toJson();
					if (purchaseInfo != null)
					{
						ProductDescription productDescription2 = new ProductDescription(current.ProductId, metadata, text2, purchaseInfo.GameOrderId);
						num5 = default(decimal);
						currency = purchaseInfo.GameOrderId;
						text = text2;
						item = productDescription2;
						goto IL_0284;
					}
					NullReferenceException ex = new NullReferenceException();
					bool flag5 = (IntPtr)text3 != (IntPtr)1;
					value3 = ex;
					ex2 = (TypeLoadException)(object)ex;
					if (flag5)
					{
						break;
					}
					((Dictionary<string, string>)(object)ex).set_Item(text3, (string)(object)ex);
					intPtr = (IntPtr)dictionary2;
					dictionary2.set_Item(text3, (string)(object)ex);
					bool flag6 = enumerator == null;
					hashSet2 = hashSet;
					num = -1;
					products = hashSet;
					intPtr2 = (IntPtr)dictionary2;
					num2 = -1;
					if (flag6)
					{
						goto IL_0465;
					}
				}
				enumerator.Dispose();
				products = hashSet2;
				intPtr2 = intPtr;
				num2 = num;
				goto IL_0465;
				IL_0284:
				bool flag7 = hashSet.Add(item);
				hashSet2 = hashSet;
				continue;
				IL_0465:
				if (num2 + 1 != 0 || intPtr2 == (IntPtr)0)
				{
					string arg = JSONSerializer.SerializeProductDescs(products);
					m_RetrieveProductsCallback(arg1: true, arg);
					m_RetrieveProductsCallback = null;
					return;
				}
				ex2 = new TypeLoadException();
				value3 = null;
				break;
			}
			((Dictionary<string, string>)(object)ex2).set_Item((string)null, (string)(object)value3);
		}

		[Token(Token = "0x60000C3")]
		[Address(RVA = "0x15B2754", Offset = "0x15B2754", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EDFF30]);\n\tv23 = *([v22 @ X8_v14]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, message, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20298CB]) = v41;\nL_0018:\n\tv45 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v45);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v45, \"error\", message);\n\tv67 = UnityEngine.Purchasing.MiniJSON.MiniJsonExtensions::toJson(v45);\n\tSystem.Action`2<System.Boolean, System.String>::Invoke(this.m_RetrieveProductsCallback, 0, v67);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnQueryInventoryFailed(string message)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.set_Item("error", message);
			string arg = dictionary.toJson();
			m_RetrieveProductsCallback(arg1: false, arg);
		}

		[Token(Token = "0x60000C4")]
		[Address(RVA = "0x15B2820", Offset = "0x15B2820", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1ED5E38]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, json, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([20298CC]) = v34;\nL_0014:\n\tv38 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RetrieveProducts(string json)
		{
			NotImplementedException ex = new NotImplementedException();
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000C5")]
		[Address(RVA = "0x15B2884", Offset = "0x15B2884", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EF4640]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, productJSON, developerPayload, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([20298CD]) = v34;\nL_0014:\n\tv38 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Purchase(string productJSON, string developerPayload)
		{
			NotImplementedException ex = new NotImplementedException();
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000C6")]
		[Address(RVA = "0x15B28E8", Offset = "0x15B28E8", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EFDA70]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, productJSON, transactionID, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([20298CE]) = v34;\nL_0014:\n\tv38 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void FinishTransaction(string productJSON, string transactionID)
		{
			NotImplementedException ex = new NotImplementedException();
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000C7")]
		[Address(RVA = "0x15B1BFC", Offset = "0x15B1BFC", Length = "0x1D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv34 = *([1F02630]);\n\tv35 = *([v34 @ X8_v27]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([20298CF]) = v54;\nL_001E:\n\tv58 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v58);\n\tv66 = System.Object::GetType(info);\n\tv172 = System.Type::GetProperties(v66);\n\tv205 = v172.Length;\n\tv221 = v172.Length < 1;\n\tif (v221) goto L_00BB;\nL_0044:\n\tv330 = v89 < v205;\n\tv130 = ~v330;\n\tif (v130) goto L_00BE;\n\tv364 = System.Reflection.PropertyInfo::get_PropertyType(v172[v89 @ X25_v8 (System.Int32)]);\n\tgoto L_0067;\n\tv370 = *([v365 @ X8_v16+E0]);\n\tv371 = v370 == 0;\n\tv372 = ~v371;\n\tif (v372) goto L_0067;\n\tv380 = v365;\n\tv375 = \"il2cpp_codegen_runtime_class_init\"(v380, v363, v71, v68, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0067:\n\tv379 = System.Type::GetTypeFromHandle(System.String);\n\tv390 = v364 != v379;\n\tif (v390) goto L_009F;\n\tv256 = System.Reflection.PropertyInfo::GetValue(v172[v89 @ X25_v8 (System.Int32)], info, 0);\n\tv258 = v256 == 0;\n\tif (v258) goto L_008C;\n\tv235 = *([v256 @ X0_v27 (System.String)]) != System.String;\n\tif (v235) goto L_00C3;\nL_008C:\n\tv407 = System.String::IsNullOrEmpty(v256);\n\tv418 = v407 == 0;\n\tv408 = ~v418;\n\tif (v408) goto L_009F;\n\tv139 = System.Reflection.MemberInfo::get_Name(v172[v89 @ X25_v8 (System.Int32)]);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v58, v139, v256);\nL_009F:\n\tv205 = v172.Length;\n\tv89 = v89 + 1;\n\tv284 = v89 < v172.Length;\n\tif (v284) goto L_0044;\nL_00BB:\n\treturn v58;\n\tv176 = new System.NullReferenceException();\nL_00BE:\n\tv206 = new System.IndexOutOfRangeException();\n\tthrow v206;\nL_00C3:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 149 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static Dictionary<string, string> StringPropertyToDictionary(object info)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			Type type = info.GetType();
			PropertyInfo[] properties = type.GetProperties();
			int num = properties.Length;
			if (properties.Length >= 1)
			{
				int num2 = 0;
				do
				{
					if (num2 < num)
					{
						Type propertyType = properties[num2].PropertyType;
						Type typeFromHandle = typeof(string);
						if ((object)propertyType == typeFromHandle)
						{
							string value = (string)properties[num2].GetValue(info, null);
							if (value != null && (object)value.GetType() != typeof(string))
							{
								return (Dictionary<string, string>)(object)new InvalidCastException();
							}
							if (!string.IsNullOrEmpty(value))
							{
								string name = properties[num2].Name;
								dictionary.set_Item(name, value);
							}
						}
						num = properties.Length;
						num2++;
						continue;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				while (num2 < properties.Length);
			}
			return dictionary;
		}

		[Token(Token = "0x60000C8")]
		[Address(RVA = "0x15B294C", Offset = "0x15B294C", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_InitOperating = 0;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public UDPBindings()
		{
			m_InitOperating = false;
		}
	}
}
