using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x72C59C", Offset = "0x72C59C")]
	[Token(Token = "0x200001B")]
	internal class MoolahStoreImpl : MonoBehaviour, IStore, IMoolahExtension, IStoreExtension, IMoolahConfiguration, IStoreConfiguration
	{
		[Token(Token = "0x400002E")]
		private static readonly string pollingPath = "https://api.cloudmoolah.com/CMPayment/api/polling.ashx";

		[Token(Token = "0x400002F")]
		private static readonly string requestAuthCodePath = "https://api.cloudmoolah.com/CMPayment/api/authGlobal.ashx";

		[Token(Token = "0x4000030")]
		private static readonly string requestRestoreTransactionUrl = "https://api.cloudmoolah.com/CMPayment/receipt/recover.ashx";

		[Token(Token = "0x4000031")]
		private static readonly string requestValidateReceiptUrl = "https://api.cloudmoolah.com/CMPayment/receipt/validate.ashx";

		[Token(Token = "0x4000032")]
		private static readonly string requestProductValidateUrl = "https://api.cloudmoolah.com/CMPayment/product/validate.ashx";

		[Token(Token = "0x4000033")]
		[FieldOffset(Offset = "0x18")]
		private IStoreCallback m_callback;

		[Token(Token = "0x4000034")]
		[FieldOffset(Offset = "0x20")]
		private bool isNeedPolling;

		[Token(Token = "0x4000035")]
		[FieldOffset(Offset = "0x28")]
		private string m_CurrentStoreProductID;

		[Token(Token = "0x4000036")]
		[FieldOffset(Offset = "0x30")]
		private bool isRequestAuthCodeing;

		[Token(Token = "0x4000037")]
		[FieldOffset(Offset = "0x38")]
		private string m_appKey;

		[Token(Token = "0x4000038")]
		[FieldOffset(Offset = "0x40")]
		private string m_hashKey;

		[Token(Token = "0x4000039")]
		[FieldOffset(Offset = "0x48")]
		private string m_notificationURL;

		[Token(Token = "0x400003A")]
		[FieldOffset(Offset = "0x50")]
		private CloudMoolahMode m_mode;

		[Token(Token = "0x400003B")]
		[FieldOffset(Offset = "0x58")]
		private string m_CustomerID;

		[Token(Token = "0x17000015")]
		public string appKey
		{
			[Token(Token = "0x600005F")]
			[Address(RVA = "0xC67824", Offset = "0xC67824", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_appKey;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return appKey;
			}
			[Token(Token = "0x6000060")]
			[Address(RVA = "0xC6782C", Offset = "0xC6782C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_appKey = value;\n\treturn;\n")]
			set
			{
				appKey = value;
			}
		}

		[Token(Token = "0x17000016")]
		public string hashKey
		{
			[Token(Token = "0x6000061")]
			[Address(RVA = "0xC67834", Offset = "0xC67834", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_hashKey;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return hashKey;
			}
			[Token(Token = "0x6000062")]
			[Address(RVA = "0xC6783C", Offset = "0xC6783C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_hashKey = value;\n\treturn;\n")]
			set
			{
				hashKey = value;
			}
		}

		[Token(Token = "0x17000017")]
		public string notificationURL
		{
			[Token(Token = "0x6000063")]
			[Address(RVA = "0xC67614", Offset = "0xC67614", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_notificationURL;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return notificationURL;
			}
			[Token(Token = "0x6000064")]
			[Address(RVA = "0xC67844", Offset = "0xC67844", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_notificationURL = value;\n\treturn;\n")]
			set
			{
				notificationURL = value;
			}
		}

		[Token(Token = "0x600004C")]
		[Address(RVA = "0xC65004", Offset = "0xC65004", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EA6918]);\n\tv23 = *([v22 @ X8_v23]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, m_callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023360]) = v41;\nL_001B:\n\tgoto L_0025;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0025;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, m_callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0025:\n\tUnityEngine.Debug::Log(\"CloudMoolah Initialize\");\n\tthis.m_callback = m_callback;\n\tv61 = System.String::IsNullOrEmpty(this.m_appKey);\n\tv63 = v61 == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_003F;\n\tv67 = System.String::IsNullOrEmpty(this.m_hashKey);\n\tv73 = v67 == 0;\n\tv74 = ~v73;\n\tif (v74) goto L_0046;\n\treturn;\nL_003F:\n\tv87 = new System.Exception();\n\tgoto L_004C;\nL_0046:\n\tv87 = new System.Exception();\nL_004C:\n\tSystem.Exception::.ctor(v87, *([v89 @ X8_v9 (System.String)]));\n\tthrow v87;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Initialize(IStoreCallback m_callback)
		{
			Debug.Log("CloudMoolah Initialize");
			this.m_callback = m_callback;
			Exception ex;
			if (!string.IsNullOrEmpty(appKey))
			{
				if (!string.IsNullOrEmpty(hashKey))
				{
					return;
				}
				ex = new Exception();
				string text = "IMoolahConfiguration.hashKey is null!";
			}
			else
			{
				string text = default(string);
				ex = new Exception(text);
				text = "IMoolahConfiguration.appkey is null!";
			}
			throw ex;
		}

		[Token(Token = "0x600004D")]
		[Address(RVA = "0xC65104", Offset = "0xC65104", Length = "0x708")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = &v21 @ X29;\n\tgoto L_001E;\n\tv35 = *([1EA8DA0]);\n\tv36 = *([v35 @ X8_v88]);\n\tv37 = \"il2cpp_codegen_initialize_method\"(v36, productDefinitions, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2023361]) = v54;\nL_001E:\n\t*([v21 @ X29-70]) = &v56 @ stack_-90;\n\t*([v21 @ X29-68]) = this;\n\tv59 = this.m_mode == 0;\n\tif (v59) goto L_00D5;\n\tv63 = new System.Collections.Generic.List`1<UnityEngine.Purchasing.Extension.ProductDescription>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.Extension.ProductDescription>::.ctor(v63);\n\tv82 = System.Collections.ObjectModel.ReadOnlyCollection`1<UnityEngine.Purchasing.ProductDefinition>::GetEnumerator(productDefinitions);\nL_0045:\n\tgoto L_006C;\n\tv422 = *([v387 @ X8_v61+B0]);\n\tv423 = 0;\n\tv424 = v422 + 8;\n\tv426 = *([v505 @ X11_v50-8]);\n\tv510 = v426 == v388;\n\tif (v510) goto L_0065;\n\tv446 = v504 + 1;\n\tv540 = v446 < v389;\n\tv444 = ~v540;\n\tv448 = v505 + 0x10;\n\tv428 = ~v444;\n\tif (v428) goto L_FFFFFFFF;\n\tv449 = v175;\n\tv450 = 0;\n\tv451 = 0x8909C4(v449, v388, v450, v345, v343, v347, v341, v337, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_006C;\nL_0065:\n\tv541 = *([v505 @ X11_v50]);\n\tv542 = v541 << 4;\n\tv543 = v387 + v542;\n\tv544 = v543 + 0x130;\nL_006C:\n\tv565 = System.Collections.IEnumerator::MoveNext(v82);\n\tv567 = v565 == 0;\n\tif (v567) goto L_0182;\n\tgoto L_009B;\n\tv694 = *([v598 @ X8_v72+B0]);\n\tv695 = 0;\n\tv696 = v694 + 8;\n\tv698 = *([v870 @ X11_v45-8]);\n\tv875 = v698 == v599;\n\tif (v875) goto L_0094;\n\tv718 = v869 + 1;\n\tv1006 = v718 < v600;\n\tv716 = ~v1006;\n\tv720 = v870 + 0x10;\n\tv700 = ~v716;\n\tif (v700) goto L_FFFFFFFF;\n\tv721 = v175;\n\tv722 = 0;\n\tv723 = 0x8909C4(v721, v599, v722, v345, v343, v347, v341, v337, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_009B;\nL_0094:\n\tv1007 = *([v870 @ X11_v45]);\n\tv1008 = v1007 << 4;\n\tv1009 = v598 + v1008;\n\tv1010 = v1009 + 0x130;\nL_009B:\n\tv1017 = System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.ProductDefinition>::get_Current(v82);\n\tv1198 = System.String::Concat(\"CloudMoolah title for \", v1017.<storeSpecificId>k__BackingField);\n\t*([v21 @ X29-60]) = 0;\n\t*([v21 @ X29-58]) = 0;\n\tv1267 = &v21 @ X29 - 0x60;\n\tv1274 = 0xEA3E34(v1267, 1, 0, 0, 0, 2, 0, 0, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv1323 = new UnityEngine.Purchasing.ProductMetadata();\n\tUnityEngine.Purchasing.ProductMetadata::.ctor(v1323, \"$0.01\", v1198, \"CloudMoolah description\", \"USD\", *([v21 @ X29-60]));\n\tv1383 = new UnityEngine.Purchasing.Extension.ProductDescription();\n\tUnityEngine.Purchasing.Extension.ProductDescription::.ctor(v1383, v1017.<storeSpecificId>k__BackingField, v1323);\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.Extension.ProductDescription>::Add(v63, v1383);\n\tgoto L_0045;\nL_00D5:\n\tv67 = new System.Collections.Generic.List`1<System.Object>();\n\tSystem.Collections.Generic.List`1<System.Object>::.ctor(v67);\n\tv174 = System.Collections.ObjectModel.ReadOnlyCollection`1<UnityEngine.Purchasing.ProductDefinition>::GetEnumerator(productDefinitions);\n\tv244 = v174 == 0;\n\tif (v244) goto L_01A1;\nL_00F5:\n\tgoto L_011C;\n\tv452 = *([v418 @ X8_v37+B0]);\n\tv453 = 0;\n\tv454 = v452 + 8;\n\tv456 = *([v526 @ X11_v30-8]);\n\tv531 = v456 == v419;\n\tif (v531) goto L_0115;\n\tv476 = v525 + 1;\n\tv568 = v476 < v420;\n\tv474 = ~v568;\n\tv478 = v526 + 0x10;\n\tv458 = ~v474;\n\tif (v458) goto L_FFFFFFFF;\n\tv479 = v237;\n\tv480 = 0;\n\tv481 = 0x8909C4(v479, v419, v480, v395, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_011C;\nL_0115:\n\tv569 = *([v526 @ X11_v30]);\n\tv570 = v569 << 4;\n\tv571 = v418 + v570;\n\tv572 = v571 + 0x130;\nL_011C:\n\tv593 = System.Collections.IEnumerator::MoveNext(v174);\n\tv595 = v593 == 0;\n\tif (v595) goto L_018B;\n\tgoto L_014B;\n\tv730 = *([v608 @ X8_v41+B0]);\n\tv731 = 0;\n\tv732 = v730 + 8;\n\tv734 = *([v963 @ X11_v25-8]);\n\tv968 = v734 == v609;\n\tif (v968) goto L_0144;\n\tv754 = v962 + 1;\n\tv1114 = v754 < v610;\n\tv752 = ~v1114;\n\tv756 = v963 + 0x10;\n\tv736 = ~v752;\n\tif (v736) goto L_FFFFFFFF;\n\tv757 = v237;\n\tv758 = 0;\n\tv759 = 0x8909C4(v757, v609, v758, v395, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_014B;\nL_0144:\n\tv1115 = *([v963 @ X11_v25]);\n\tv1116 = v1115 << 4;\n\tv1117 = v608 + v1116;\n\tv1118 = v1117 + 0x130;\nL_014B:\n\tv1134 = System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.ProductDefinition>::get_Current(v174);\n\tv1136 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v1136);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v1136, \"pid\", v1134.<storeSpecificId>k__BackingField);\n\tv1386 = v1134.<type>k__BackingField < 3;\n\tv216 = ~v1386;\n\tv180 = ~v216;\n\tif (v180) goto L_016D;\n\tgoto L_016F;\nL_016D:\n\tv1390 = v1134.<type>k__BackingField + 1;\nL_016F:\n\t*([v21 @ X29-60]) = v1390;\n\tv1391 = &v21 @ X29 - 0x60;\n\t// 369 Box v1392 @ X0_v62 (System.Object), typeof(System.Int32), v1391 @ X1_v30\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v1136, \"productType\", v1392);\n\tSystem.Collections.Generic.List`1<System.Object>::Add(v67, v1136);\n\tgoto L_00F5;\nL_0182:\n\tv602 = *([v21 @ X29-70]);\n\tv604 = 0;\n\t*([v602 @ X9_v31]) = 0x8C;\n\tv606 = v82 == 0;\n\tv607 = ~v606;\n\tif (v607) goto L_0248;\n\tgoto L_0275;\nL_018B:\n\tv612 = *([v21 @ X29-70]);\n\t*([v612 @ X9_v21]) = 0x110;\n\tv616 = v174 == 0;\n\tv617 = ~v616;\n\tif (v617) goto L_01CD;\n\tgoto L_01F5;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv243 = new System.NullReferenceException();\n\tv290 = new System.NullReferenceException();\nL_01A1:\n\tv332 = new System.NullReferenceException();\n\tgoto L_01BE;\n\tgoto L_022E;\n\tgoto L_01BE;\n\tgoto L_01BE;\n\tgoto L_01BE;\n\tgoto L_022E;\n\tgoto L_022E;\n\tgoto L_01BE;\n\tgoto L_01BE;\n\tgoto L_01BE;\n\tgoto L_01BE;\n\tgoto L_01BE;\n\tgoto L_01BE;\n\tgoto L_022E;\n\tgoto L_022E;\n\tgoto L_022E;\n\tgoto L_01BE;\nL_01BE:\n\tv493 = v325 != 1;\n\tif (v493) goto L_029E;\n\tv537 = System.Collections.ObjectModel.ReadOnlyCollection`1<UnityEngine.Purchasing.ProductDefinition>::GetEnumerator(v332);\n\tv762 = *([v537 @ X0_v30 (System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.ProductDefinition>)]);\n\tv597 = System.Collections.ObjectModel.ReadOnlyCollection`1<UnityEngine.Purchasing.ProductDefinition>::GetEnumerator(v537);\n\tv619 = v792 == 0;\n\tif (v619) goto L_01F5;\nL_01CD:\n\tgoto L_01F4;\n\tv973 = *([v796 @ X8_v19+B0]);\n\tv974 = 0;\n\tv975 = v973 + 8;\n\tv977 = *([v1148 @ X11_v11-8]);\n\tv1153 = v977 == v799;\n\tif (v1153) goto L_01ED;\n\tv997 = v1147 + 1;\n\tv1250 = v997 < v798;\n\tv995 = ~v1250;\n\tv999 = v1148 + 0x10;\n\tv979 = ~v995;\n\tif (v979) goto L_FFFFFFFF;\n\tv1000 = v792;\n\tv1001 = 0;\n\tv1002 = 0x8909C4(v1000, v799, v1001, v767, v766, v768, v765, v763, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_01F4;\nL_01ED:\n\tv1251 = *([v1148 @ X11_v11]);\n\tv1252 = v1251 << 4;\n\tv1253 = v796 + v1252;\n\tv1254 = v1253 + 0x130;\nL_01F4:\n\tSystem.IDisposable::Dispose(v174);\nL_01F5:\n\tv854 = v853 + 1;\n\tv856 = v854 == 0;\n\tif (v856) goto L_020A;\n\tv1003 = v1026 == 0;\n\tif (v1003) goto L_020F;\n\tv1158 = *([v21 @ X29-70]);\n\tv1164 = *([v1158 @ X8_v12+v853 @ X19_v2 (System.Int32)*4]) == 0x110;\n\tif (v1164) goto L_020F;\n\tgoto L_FFFFFFFF;\nL_020A:\n\tv1004 = v1026 == 0;\n\tv1005 = ~v1004;\n\tif (v1005) goto L_FFFFFFFF;\nL_020F:\n\tv1181 = UnityEngine.Purchasing.MiniJson::JsonEncode(v849);\n\tv1258 = *([v21 @ X29-68]);\n\tv1265 = new System.Action`2<System.Boolean, System.String>();\n\tSystem.Action`2<System.Boolean, System.String>::.ctor(v1265, *([v21 @ X29-68]), Il2CppMethodInfo);\n\tv1365 = UnityEngine.Purchasing.MoolahStoreImpl::VaildateProduct(*([v21 @ X29-68]), v1258.m_appKey, v1181, v1265);\n\tv1306 = UnityEngine.MonoBehaviour::StartCoroutine(*([v21 @ X29-68]), v1365);\n\tgoto L_029C;\n\tgoto L_022E;\n\tgoto L_022E;\n\tgoto L_022E;\nL_022E:\n\tX8 = X1;\n\tX2 = X0;\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_029E;\n\tX0 = X2;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3\n// ... truncated")]
		public void RetrieveProducts(ReadOnlyCollection<ProductDefinition> productDefinitions)
		{
			//IL_0293: Expected I, but got O
			//IL_01f5: Expected O, but got I
			//IL_01fe: Expected O, but got I4
			//IL_021d: Expected I, but got O
			//IL_01a5: Expected O, but got I
			//IL_01b7: Expected O, but got I4
			//IL_02c5: Expected I, but got O
			//IL_0239: Expected I, but got O
			//IL_0065: Expected O, but got I
			//IL_0098: Expected O, but got I
			//IL_0385: Expected O, but got I
			//IL_039c: Expected O, but got I
			//IL_0565: Expected O, but got I
			//IL_056e: Expected I4, but got O
			//IL_0490: Expected O, but got I
			//IL_03c8: Expected O, but got I
			//IL_0316: Expected O, but got I
			//IL_03e6: Expected O, but got I
			object obj = obj;
			if (m_mode != CloudMoolahMode.Production)
			{
				List<ProductDescription> list = new List<ProductDescription>();
				IEnumerator<ProductDefinition> enumerator = productDefinitions.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ProductDefinition current = enumerator.Current;
					string title = "CloudMoolah title for " + current.storeSpecificId;
					_ = 0;
					_ = 0;
					object obj2 = (long)(IntPtr)obj - 96L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EA3E34 (inside System.DateTimeParse+MatchNumberDelegate::EndInvoke +0x340)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-60]");
					ProductMetadata metadata = new ProductMetadata("$0.01", title, "CloudMoolah description", "USD", 0m);
					ProductDescription item = new ProductDescription(current.storeSpecificId, metadata);
					list.Add(item);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-70]");
				object obj3 = 0;
				int num = 0;
				obj3 = 140;
				enumerator?.Dispose();
				List<ProductDescription> products = list;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-68]");
				((MoolahStoreImpl)0).RetrieveProductsSucceeded(products);
				return;
			}
			List<object> list2 = new List<object>();
			IEnumerator<ProductDefinition> enumerator2 = productDefinitions.GetEnumerator();
			IntPtr intPtr2;
			int num2;
			IntPtr intPtr3;
			List<object> json;
			int num3;
			if (enumerator2 == null)
			{
				NullReferenceException ex = new NullReferenceException();
				IntPtr intPtr = default(IntPtr);
				if (intPtr != (IntPtr)1)
				{
					IEnumerator<ProductDefinition> enumerator3 = ((ReadOnlyCollection<ProductDefinition>)(object)ex).GetEnumerator();
					return;
				}
				IEnumerator<ProductDefinition> enumerator4 = ((ReadOnlyCollection<ProductDefinition>)(object)ex).GetEnumerator();
				intPtr2 = (IntPtr)enumerator4;
				IEnumerator<ProductDefinition> enumerator5 = ((ReadOnlyCollection<ProductDefinition>)enumerator4).GetEnumerator();
				IEnumerator<ProductDefinition> enumerator6 = default(IEnumerator<ProductDefinition>);
				bool flag = enumerator6 == null;
				num2 = -1;
				intPtr3 = (IntPtr)enumerator4;
				List<object> list3 = default(List<object>);
				json = list3;
				num3 = -1;
				if (flag)
				{
					goto IL_0593;
				}
			}
			else
			{
				while (enumerator2.MoveNext())
				{
					ProductDefinition current2 = enumerator2.Current;
					Dictionary<string, object> dictionary = new Dictionary<string, object>();
					dictionary.Add("pid", current2.storeSpecificId);
					if (current2.type >= (ProductType)3)
					{
						int num4 = 0;
					}
					else
					{
						int num4 = (int)(current2.type + 1);
					}
					object obj4 = (long)(IntPtr)obj - 96L;
					object value = (int)obj4;
					dictionary.Add("productType", value);
					list2.Add(dictionary);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-70]");
				object obj5 = 0;
				obj5 = 272;
				bool flag2 = enumerator2 == null;
				bool flag3 = !flag2;
				intPtr2 = (IntPtr)null;
				num2 = 0;
				if (!flag3)
				{
					intPtr3 = (IntPtr)null;
					json = list2;
					num3 = 0;
					goto IL_0593;
				}
			}
			enumerator2.Dispose();
			intPtr3 = intPtr2;
			json = list2;
			num3 = num2;
			goto IL_0593;
			IL_0443:
			throw new TypeLoadException();
			IL_0593:
			if (num3 + 1 != 0)
			{
				if (intPtr3 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-70]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1158 @ X8_v12+v853 @ X19_v2 (System.Int32)*4]");
					if ((IntPtr)0 != (IntPtr)272)
					{
						goto IL_0443;
					}
				}
			}
			else if (intPtr3 != (IntPtr)0)
			{
				goto IL_0443;
			}
			string productInfo = MiniJson.JsonEncode(json);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-68]");
			MoolahStoreImpl moolahStoreImpl = (MoolahStoreImpl)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-68]");
			Action<bool, string> result = ((MoolahStoreImpl)0)._003CRetrieveProducts_003Eb__9_0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-68]");
			IEnumerator routine = ((MoolahStoreImpl)0).VaildateProduct(moolahStoreImpl.appKey, productInfo, result);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-68]");
			Coroutine coroutine = ((MonoBehaviour)0).StartCoroutine(routine);
		}

		[Token(Token = "0x600004E")]
		[Address(RVA = "0xC658DC", Offset = "0xC658DC", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = type < 2;\n\tv2 = ~v0;\n\tv3 = type - 2;\n\tv5 = v3 == 0;\n\tv10 = ~v5;\n\tv11 = v2 & v10;\n\tif (v11) goto L_000F;\n\treturnVal1 = type + 1;\n\treturn returnVal1;\nL_000F:\n\treturn 0;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private int GetProductTypeIndex(ProductType type)
		{
			bool flag = type < ProductType.Subscription;
			bool flag2 = !flag;
			int num = (int)(type - 2);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				return (int)(type + 1);
			}
			return 0;
		}

		[Token(Token = "0x600004F")]
		[Address(RVA = "0xC65988", Offset = "0xC65988", Length = "0x600")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv38 = *([1EF4370]);\n\tv39 = *([v38 @ X8_v87]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, state, result, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2023362]) = v56;\nL_0023:\n\tv63 = state == 0;\n\tif (v63) goto L_FFFFFFFF;\n\tv66 = UnityEngine.Purchasing.MiniJson::JsonDecode(v71);\n\tgoto L_FFFFFFFF;\n\tv287 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v66, \"code\");\n\tv785 = *([v287 @ X0_v17]);\n\t*([v785 @ X8_v29 (System.Int32)+160])(v536, v287, *([v785 @ X8_v29 (System.Int32)+168]), Il2CppMethodInfo, v371, v369, v367, v365, v363, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv541 = System.String::op_Equality(v536, \"1\");\n\tv543 = v541 == 0;\n\tv544 = ~v543;\n\tif (v544) goto L_0071;\n\tv548 = System.String::op_Equality(v536, \"2\");\n\tv119 = v548 == 0;\n\tif (v119) goto L_FFFFFFFF;\nL_0071:\n\tv558 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v66, \"values\");\n\tv560 = v558 == 0;\n\tif (v560) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_00A3;\nL_0088:\n\tUnityEngine.Purchasing.MoolahStoreImpl::RetrieveProductsFailed(v116, v114);\n\tgoto L_020C;\n\tgoto L_0088;\n\tv602 = v602_asT == 0;\n\tif (v602) goto L_FFFFFFFF;\n\tgoto L_00A3;\nL_00A3:\n\tv230 = new System.Collections.Generic.List`1<UnityEngine.Purchasing.Extension.ProductDescription>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.Extension.ProductDescription>::.ctor(v230);\n\tv615 = System.Collections.Generic.List`1<System.Object>::GetEnumerator(v238);\nL_00BD:\n\tv720 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v174 @ stack_-A8_v6 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv722 = v720 == 0;\n\tif (v722) goto L_01A7;\n\tv729 = *([v617 @ stack_-98]);\n\tv785 = *([v696 @ X24_v10 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, System.Object>>)]);\n\tv731 = *([v729 @ X9_v20+128]) < *([v785 @ X8_v29 (System.Int32)+128]);\n\tv732 = ~v731;\n\tv740 = ~v732;\n\tif (v740) goto L_FFFFFFFF;\n\tv661 = *([v785 @ X8_v29 (System.Int32)+128]) << 3;\n\tv759 = *([v729 @ X9_v20+C8]) + v661;\n\tv663 = *([v759 @ X9_v22-8]) != v785;\n\tif (v663) goto L_FFFFFFFF;\n\tv782 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v617, *([v648 @ X25_v9 (System.String)]));\n\tv783 = v782 == 0;\n\tif (v783) goto L_FFFFFFFF;\n\tv785 = *([v782 @ X0_v52]);\n\t*([v785 @ X8_v29 (System.Int32)+160])(v792, v782, *([v785 @ X8_v29 (System.Int32)+168]), Il2CppMethodInfo, v371, v369, v367, v365, v363, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_00F1;\nL_00F1:\n\tv703 = System.String::IsNullOrEmpty(v713);\n\tv812 = v703 == 0;\n\tv707 = ~v812;\n\tif (v707) goto L_00BD;\n\tv822 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v617, *([v646 @ X26_v9 (System.String)]));\n\tv825 = v822 == 0;\n\tif (v825) goto L_FFFFFFFF;\n\tv785 = *([v822 @ X0_v57]);\n\t*([v785 @ X8_v29 (System.Int32)+160])(v829, v822, *([v785 @ X8_v29 (System.Int32)+168]), Il2CppMethodInfo, v371, v369, v367, v365, v363, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_0105;\nL_0105:\n\tv704 = System.String::IsNullOrEmpty(v641);\n\tv836 = v704 == 0;\n\tv708 = ~v836;\n\tif (v708) goto L_00BD;\n\tgoto L_0118;\n\tv843 = *([v839 @ X0_v61+E0]);\n\tv844 = v843 == 0;\n\tv845 = ~v844;\n\tif (v845) goto L_0118;\n\tv847 = \"il2cpp_codegen_runtime_class_init\"(v839, v700, v658, v632, v630, v628, v626, v624, v650, v47, v48, v49, v50, v51, v52, v53);\nL_0118:\n\tv46 = System.Convert::ToDouble(v641);\n\tv857 = 0xA6632C(&v46 @ V0 (System.Double), \"f2\", 0, v371, v369, v367, v365, v363, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv864 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v617, \"title\");\n\tv865 = v864 == 0;\n\tif (v865) goto L_FFFFFFFF;\n\tv785 = *([v864 @ X0_v67]);\n\t*([v785 @ X8_v29 (System.Int32)+160])(v869, v864, *([v785 @ X8_v29 (System.Int32)+168]), Il2CppMethodInfo, v371, v369, v367, v365, v363, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_0135;\nL_0135:\n\tv882 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v617, \"description\");\n\tv883 = v882 == 0;\n\tif (v883) goto L_FFFFFFFF;\n\tv785 = *([v882 @ X0_v70]);\n\t*([v785 @ X8_v29 (System.Int32)+160])(v887, v882, *([v785 @ X8_v29 (System.Int32)+168]), Il2CppMethodInfo, v371, v369, v367, v365, v363, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_0144;\nL_0144:\n\tv900 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v617, \"currencyCode\");\n\tv901 = v900 == 0;\n\tif (v901) goto L_FFFFFFFF;\n\tv785 = *([v900 @ X0_v73]);\n\t*([v785 @ X8_v29 (System.Int32)+160])(v905, v900, *([v785 @ X8_v29 (System.Int32)+168]), Il2CppMethodInfo, v371, v369, v367, v365, v363, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_0157;\nL_0157:\n\tv921 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v617, \"localizedPrice\");\n\tv655 = v921 != 0;\n\tif (v655) goto L_FFFFFFFF;\n\tgoto L_016F;\nL_016F:\n\tgoto L_0177;\n\tv932 = *([v929 @ X0_v77+E0]);\n\tv933 = v932 == 0;\n\tv934 = ~v933;\n\tgoto L_0177;\n\tv936 = \"il2cpp_codegen_runtime_class_init\"(v929, v919, v918, v632, v630, v628, v626, v624, v651, v47, v48, v49, v50, v51, v52, v53);\nL_0177:\n\tv941 = System.Convert::ToDecimal(v928);\n\tv947 = new UnityEngine.Purchasing.ProductMetadata();\n\tUnityEngine.Purchasing.ProductMetadata::.ctor(v947, v857, v873, v890, v908, v941);\n\tv954 = new UnityEngine.Purchasing.Extension.ProductDescription();\n\tUnityEngine.Purchasing.Extension.ProductDescription::.ctor(v954, v713, v947);\n\tv709 = v230 == 0;\n\tif (v709) goto L_01AC;\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.Extension.ProductDescription>::Add(v230, v954);\n\tgoto L_00BD;\nL_01A7:\n\tv728 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v174 @ stack_-A8_v6 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_01DF;\n\tthrow System.NullReferenceException;\nL_01AC:\n\tv427 = new System.NullReferenceException();\n\tgoto L_01D0;\n\tgoto L_01D0;\n\tgoto L_01D0;\n\tgoto L_01D0;\n\tgoto L_01D0;\n\tgoto L_01D0;\n\tgoto L_01BA;\n\tgoto L_01BA;\n\tX27 = stack[10];\n\tgoto L_01D0;\n\tgoto L_01D0;\n\tgoto L_01D0;\nL_01BA:\n\tX28 = stack[8];\n\tX27 = stack[10];\n\tgoto L_01D0;\n\tgoto L_01D0;\n\tgoto L_01D0;\n\tgoto L_01D0;\n\tgoto L_01D0;\n\tgoto L_01D0;\n\tgoto L_01D0;\n\tgoto L_01D0;\n\tgoto L_01D0;\n\tgoto L_01D0;\n\tgoto L_01D0;\nL_01D0:\n\tv400 = v713 != 1;\n\tif (v400) goto L_020F;\n\tv795 = 0x6D2BC0(v427, v713, v947, 0, v908, v941, 0, 0, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv805 = 0x6D2490(v795, v713, v947, 0, v908, v941, 0, 0, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv529 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v174 @ stack_-A8_v6 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv823 = *([v795 @ X0_v45]) == 0;\n\tv530 = ~v823;\n\tif (v530) goto L_0213;\nL_01DF:\n\tUnityEngine.Purchasing.MoolahStoreImpl::RetrieveProductsSucceeded(v236, v230);\n\tv785 = v230._size;\n\tv788 = 0xDC3560(&v785 @ X8_v29 (System.Int32), 0, v395, v371, v369, v367, v365, v363, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv801 = System.String::Concat(\"CloudMoolah ProductList.length: \", v788);\n\tgoto L_01FE;\n\tv815 = *([v344 @ X8_v35+E0]);\n\tv816 = v815 == 0;\n\tv817 = ~v816;\n\tif (v817) goto L_01FE;\n\tv824 = v344;\n\tv819 = \"il2cpp_codegen_runtime_class_init\"(v824, v798, v318, v149, v147, v145, v143, v141, v171, v47, v48, v49, v50, v51, v52, v53);\nL_01FE:\n\tUnityEngine.Debug::Log(v801);\nL_020C:\n\treturn;\n\tv427 = new System.NullReferenceException();\nL_020F:\n\tv439 = 0x6D2380(v427, v425, v395, v371, v369, v367, v365, v363, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0213:\n\tthrow System.TypeLoadException;\n// 368 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void VaildateProductProcess(bool state, string result)
		{
			//IL_001f: Expected I, but got O
			//IL_005a: Expected I4, but got O
			//IL_00df: Expected I4, but got O
			//IL_017a: Expected O, but got I4
			//IL_0198: Expected F8, but got O
			//IL_01ac: Expected I, but got O
			//IL_0135: Expected O, but got I4
			//IL_050c: Expected O, but got I
			//IL_0236: Expected O, but got I
			//IL_0295: Expected I4, but got O
			//IL_02ef: Expected I4, but got O
			//IL_036a: Expected I4, but got O
			//IL_0395: Expected I4, but got O
			//IL_03c0: Expected I4, but got O
			//IL_0466: Expected O, but got I4
			//IL_047b: Expected I, but got O
			//IL_0483: Expected I, but got O
			//IL_04b8: Expected O, but got I4
			//IL_04cd: Expected I, but got O
			//IL_04f3: Expected I, but got O
			InitializationFailureReason reason;
			if (state)
			{
				string text = default(string);
				object obj = MiniJson.JsonDecode(text);
				IntPtr intPtr = (IntPtr)text;
				string text2 = null;
				Dictionary<string, object> dictionary = obj as Dictionary<string, object>;
				object obj2 = ((Dictionary<string, object>)obj).get_Item("code");
				int num = (int)obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v785 @ X8_v29 (System.Int32)+160] (should have been resolved before IL gen)");
				string text3 = default(string);
				if (text3 == "1" || text3 == "2")
				{
					int num2 = (int)((Dictionary<string, object>)obj).get_Item("values");
					int num3;
					if (num2 == 0)
					{
						num3 = 0;
					}
					else
					{
						List<object> list = num2 as List<object>;
						num3 = ((list != null) ? num2 : 0);
					}
					List<ProductDescription> list2 = new List<ProductDescription>();
					object enumerator = ((List<object>)num3).GetEnumerator();
					string key = "priceString";
					string key2 = "pid";
					List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
					double num4 = (double)enumerator2;
					intPtr = (IntPtr)0;
					IntPtr intPtr2 = (IntPtr)typeof(Dictionary<string, object>);
					MoolahStoreImpl moolahStoreImpl = this;
					object obj4 = default(object);
					string text5 = default(string);
					string text6 = default(string);
					string text7 = default(string);
					string text8 = default(string);
					string text10 = default(string);
					string text11 = default(string);
					object obj13 = default(object);
					string text13 = default(string);
					while (true)
					{
						if (enumerator2.MoveNext())
						{
							object obj3 = obj4;
							num = (int)(long)intPtr2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v729 @ X9_v20+128]");
							IntPtr intPtr3 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v785 @ X8_v29 (System.Int32)+128]");
							if ((long)intPtr3 >= 0L)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v785 @ X8_v29 (System.Int32)+128]");
								int num5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v729 @ X9_v20+C8]");
								object obj5 = 0L + (long)num5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v759 @ X9_v22-8]");
								if ((IntPtr)0 == (IntPtr)num)
								{
									object obj6 = ((Dictionary<string, object>)obj4).get_Item(key2);
									string text4;
									if (obj6 != null)
									{
										num = (int)obj6;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v785 @ X8_v29 (System.Int32)+160] (should have been resolved before IL gen)");
										text4 = text5;
									}
									else
									{
										text4 = null;
									}
									bool flag = string.IsNullOrEmpty(text4);
									bool flag2 = !flag;
									bool flag3 = !flag2;
									intPtr = (IntPtr)0;
									if (flag3)
									{
										continue;
									}
									object obj7 = ((Dictionary<string, object>)obj4).get_Item(key);
									string value;
									if (obj7 != null)
									{
										num = (int)obj7;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v785 @ X8_v29 (System.Int32)+160] (should have been resolved before IL gen)");
										value = text6;
									}
									else
									{
										value = null;
									}
									bool flag4 = string.IsNullOrEmpty(value);
									bool flag5 = !flag4;
									bool flag6 = !flag5;
									intPtr = (IntPtr)0;
									if (flag6)
									{
										continue;
									}
									num4 = Convert.ToDouble(value);
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @A6632C (inside System.Double::IsNaN +0x448)");
									object obj8 = ((Dictionary<string, object>)obj4).get_Item("title");
									string title;
									if (obj8 != null)
									{
										num = (int)obj8;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v785 @ X8_v29 (System.Int32)+160] (should have been resolved before IL gen)");
										title = text7;
									}
									else
									{
										title = null;
									}
									object obj9 = ((Dictionary<string, object>)obj4).get_Item("description");
									string description;
									if (obj9 != null)
									{
										num = (int)obj9;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v785 @ X8_v29 (System.Int32)+160] (should have been resolved before IL gen)");
										description = text8;
									}
									else
									{
										description = null;
									}
									object obj10 = ((Dictionary<string, object>)obj4).get_Item("currencyCode");
									string text9;
									if (obj10 != null)
									{
										num = (int)obj10;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v785 @ X8_v29 (System.Int32)+160] (should have been resolved before IL gen)");
										text9 = text10;
									}
									else
									{
										text9 = null;
									}
									object obj11 = ((Dictionary<string, object>)obj4).get_Item("localizedPrice");
									string value2 = ((obj11 != null) ? "0.00" : text11);
									decimal num6 = Convert.ToDecimal(value2);
									ProductMetadata productMetadata = new ProductMetadata(text11, title, description, text9, num6);
									ProductDescription item = new ProductDescription(text4, productMetadata);
									bool flag7 = list2 == null;
									int num7 = 0;
									object obj12 = 0;
									decimal num8 = num6;
									string text12 = text9;
									IntPtr intPtr4 = (IntPtr)null;
									intPtr = (IntPtr)productMetadata;
									text2 = text4;
									if (!flag7)
									{
										list2.Add(item);
										num7 = 0;
										obj12 = 0;
										num8 = num6;
										text12 = text9;
										intPtr4 = (IntPtr)null;
										key = "priceString";
										key2 = "pid";
										intPtr = (IntPtr)0;
										intPtr2 = (IntPtr)typeof(Dictionary<string, object>);
										continue;
									}
									NullReferenceException ex = new NullReferenceException();
									if ((IntPtr)text4 == (IntPtr)1)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
										enumerator2.Dispose();
										bool flag8 = obj13 == null;
										bool flag9 = !flag8;
										moolahStoreImpl = moolahStoreImpl;
										if (flag9)
										{
											break;
										}
										goto IL_0592;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
									break;
								}
							}
							text2 = (string)0;
							throw new NullReferenceException();
						}
						enumerator2.Dispose();
						goto IL_0592;
						IL_0592:
						moolahStoreImpl.RetrieveProductsSucceeded(list2);
						num = list2.Count;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
						string message = "CloudMoolah ProductList.length: " + text13;
						Debug.Log(message);
						return;
					}
					throw new TypeLoadException();
				}
				reason = InitializationFailureReason.NoProductsAvailable;
			}
			else
			{
				reason = default(InitializationFailureReason);
			}
			RetrieveProductsFailed(reason);
		}

		[Token(Token = "0x6000050")]
		[Address(RVA = "0xC65F88", Offset = "0xC65F88", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = obj == 0;\n\tif (v0) goto L_0009;\n\tv2 = obj->klass;\n\tv4 = obj->klass->vtable[3];\n\tv5 = obj->klass->vtable[3];\n\t// 7 IndirectJump v4 @ X2_v1, obj @ X1 (System.Object), obj @ X1 (System.Object), v5 @ X8_v2, v4 @ X2_v1, v7 @ X3, v8 @ X4, v9 @ X5, v10 @ X6, v11 @ X7, v12 @ V0, v13 @ V1, v14 @ V2, v15 @ V3, v16 @ V4, v17 @ V5, v18 @ V6, v19 @ V7\nL_0009:\n\treturn 0;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private string GetCurrentString(object obj)
		{
			//IL_0025: Expected I, but got O
			//IL_0035: Expected O, but got I
			//IL_0045: Expected O, but got I
			if (obj != null)
			{
				IntPtr intPtr = (IntPtr)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<System.Object>)+160]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<System.Object>)+168]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ X2_v1 (should have been resolved before IL gen)");
			}
			return null;
		}

		[Token(Token = "0x6000051")]
		[Address(RVA = "0xC658F4", Offset = "0xC658F4", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1EC1CA8]);\n\tv31 = *([v30 @ X8_v6]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, appkey, productInfo, result, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2023363]) = v47;\nL_001C:\n\tv51 = new UnityEngine.Purchasing.MoolahStoreImpl+<VaildateProduct>d__13();\n\tSystem.Object::.ctor(v51);\n\tv51.<>1__state = 0;\n\tv51.result = result;\n\tv51.<>4__this = this;\n\tv51.appkey = appkey;\n\tv51.productInfo = productInfo;\n\treturn v51;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator VaildateProduct(string appkey, string productInfo, Action<bool, string> result)
		{
			_003CVaildateProduct_003Ed__13 _003CVaildateProduct_003Ed__14 = null;
			_003CVaildateProduct_003Ed__14._003C_003E1__state = 0;
			_003CVaildateProduct_003Ed__14.result = result;
			_003CVaildateProduct_003Ed__14._003C_003E4__this = this;
			_003CVaildateProduct_003Ed__14.appkey = appkey;
			_003CVaildateProduct_003Ed__14.productInfo = productInfo;
			return _003CVaildateProduct_003Ed__14;
		}

		[Token(Token = "0x6000052")]
		[Address(RVA = "0xC65814", Offset = "0xC65814", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EF46D8]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, products, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023364]) = v41;\nL_0015:\n\tv42 = this.m_callback;\n\tv45 = *([v42 @ X20_v2 (UnityEngine.Purchasing.Extension.IStoreCallback)]);\n\tv49 = *([v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]) == 0;\n\tif (v49) goto L_003C;\n\tv103 = *([v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+B0]) + 8;\nL_0027:\n\tv109 = *([v103 @ X11_v5-8]) == UnityEngine.Purchasing.Extension.IStoreCallback;\n\tif (v109) goto L_003F;\n\tv104 = v104 + 1;\n\tv166 = v104 < *([v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]);\n\tv83 = ~v166;\n\tv103 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_0027;\nL_003C:\n\tv173 = 0x8909C4(v42, UnityEngine.Purchasing.Extension.IStoreCallback, 2, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0043;\nL_003F:\n\tv168 = *([v103 @ X11_v5]) + 2;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv173 = v170 + 0x130;\nL_0043:\n\tv117 = *([v173 @ X0_v4]);\n\tv124 = *([v173 @ X0_v4+8]);\n\t// 77 IndirectJump v117 @ X3_v1, v42 @ X20_v2 (UnityEngine.Purchasing.Extension.IStoreCallback), v42 @ X20_v2 (UnityEngine.Purchasing.Extension.IStoreCallback), products @ X1 (System.Collections.Generic.List`1<UnityEngine.Purchasing.Extension.ProductDescription>), v124 @ X2_v2, v117 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void RetrieveProductsSucceeded(List<ProductDescription> products)
		{
			//IL_000d: Expected I, but got O
			//IL_014c: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00e7: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_0094: Expected O, but got I
			IStoreCallback callback = m_callback;
			IntPtr intPtr = (IntPtr)callback;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IStoreCallback))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]");
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
			goto IL_0134;
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0134;
			IL_0134:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v4+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v117 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000053")]
		[Address(RVA = "0xC65FA8", Offset = "0xC65FA8", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EAE4F8]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, reason, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023365]) = v41;\nL_0015:\n\tv42 = this.m_callback;\n\tv45 = *([v42 @ X20_v2 (UnityEngine.Purchasing.Extension.IStoreCallback)]);\n\tv49 = *([v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]) == 0;\n\tif (v49) goto L_003C;\n\tv103 = *([v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+B0]) + 8;\nL_0027:\n\tv109 = *([v103 @ X11_v5-8]) == UnityEngine.Purchasing.Extension.IStoreCallback;\n\tif (v109) goto L_003F;\n\tv104 = v104 + 1;\n\tv166 = v104 < *([v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]);\n\tv83 = ~v166;\n\tv103 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_0027;\nL_003C:\n\tv173 = 0x8909C4(v42, UnityEngine.Purchasing.Extension.IStoreCallback, 1, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0043;\nL_003F:\n\tv168 = *([v103 @ X11_v5]) + 1;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv173 = v170 + 0x130;\nL_0043:\n\tv117 = *([v173 @ X0_v4]);\n\tv124 = *([v173 @ X0_v4+8]);\n\t// 77 IndirectJump v117 @ X3_v1, v42 @ X20_v2 (UnityEngine.Purchasing.Extension.IStoreCallback), v42 @ X20_v2 (UnityEngine.Purchasing.Extension.IStoreCallback), reason @ X1 (UnityEngine.Purchasing.InitializationFailureReason), v124 @ X2_v2, v117 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void RetrieveProductsFailed(InitializationFailureReason reason)
		{
			//IL_000d: Expected I, but got O
			//IL_014c: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00e7: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_0094: Expected O, but got I
			IStoreCallback callback = m_callback;
			IntPtr intPtr = (IntPtr)callback;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IStoreCallback))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 1;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0134;
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0134;
			IL_0134:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v4+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v117 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000054")]
		[Address(RVA = "0xC6609C", Offset = "0xC6609C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC2338]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, result, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023366]) = v38;\nL_0019:\n\tgoto L_0023;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0023;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, result, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tUnityEngine.Debug::Log(\"CloudMoolah ClosePayWebView\");\n\tv57 = ~this.isNeedPolling;\n\tif (v57) goto L_003A;\n\tthis.isNeedPolling = 0;\n\tUnityEngine.Purchasing.MoolahStoreImpl::PurchaseFailed(this, this.m_CurrentStoreProductID, 4, \"UserCancelled\");\n\treturn;\nL_003A:\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ClosePayWebView(string result)
		{
			Debug.Log("CloudMoolah ClosePayWebView");
			if (isNeedPolling)
			{
				isNeedPolling = false;
				PurchaseFailed(m_CurrentStoreProductID, PurchaseFailureReason.UserCancelled, "UserCancelled");
			}
		}

		[Token(Token = "0x6000055")]
		[Address(RVA = "0xC66240", Offset = "0xC66240", Length = "0x454")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv36 = *([1EB13F8]);\n\tv37 = *([v36 @ X8_v63]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, resultJson, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2023367]) = v55;\nL_001F:\n\tthis.isNeedPolling = 0;\n\tv59 = UnityEngine.Purchasing.MiniJson::JsonDecode(resultJson);\n\tv62 = v59 == 0;\n\tif (v62) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_004D;\n\tv113 = v113_asT == 0;\n\tif (v113) goto L_FFFFFFFF;\n\tgoto L_004D;\nL_004D:\n\tv138 = System.String::Concat(\"CloudMoolah PurchaseResult resultJson: \", resultJson);\n\tgoto L_005E;\n\tv146 = *([v142 @ X8_v8+E0]);\n\tv147 = v146 == 0;\n\tv148 = ~v147;\n\tgoto L_005E;\n\tv155 = v142;\n\tv151 = \"il2cpp_codegen_runtime_class_init\"(v155, v135, v136, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_005E:\n\tUnityEngine.Debug::Log(v138);\n\tv164 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v130, \"code\");\n\tv311 = *([v164 @ X0_v15]);\n\t*([v311 @ X8_v33 (System.Int32)+160])(v321, v164, *([v311 @ X8_v33 (System.Int32)+168]), Il2CppMethodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv326 = System.String::op_Equality(v321, \"1\");\n\tv369 = v326 == 0;\n\tif (v369) goto L_0125;\n\tv211 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v130, \"values\");\n\tgoto L_FFFFFFFF;\n\tv285 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v211, \"state\");\n\tv311 = *([v285 @ X0_v22]);\n\t*([v311 @ X8_v33 (System.Int32)+160])(v468, v285, *([v311 @ X8_v33 (System.Int32)+168]), Il2CppMethodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv286 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v211, \"tradeSeq\");\n\tv311 = *([v286 @ X0_v25]);\n\t*([v311 @ X8_v33 (System.Int32)+160])(v473, v286, *([v311 @ X8_v33 (System.Int32)+168]), Il2CppMethodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv287 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v211, \"productId\");\n\tv311 = *([v287 @ X0_v28]);\n\t*([v311 @ X8_v33 (System.Int32)+160])(v478, v287, *([v311 @ X8_v33 (System.Int32)+168]), Il2CppMethodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv288 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v130, \"msg\");\n\tv311 = *([v288 @ X0_v31]);\n\t*([v311 @ X8_v33 (System.Int32)+160])(v483, v288, *([v311 @ X8_v33 (System.Int32)+168]), Il2CppMethodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv311 = 1;\n\t// 216 Box v289 @ X0_v34, typeof(UnityEngine.Purchasing.TradeSeqState), &v311 @ X8_v33 (System.Int32)\n\tv311 = *([v289 @ X0_v34]);\n\t*([v311 @ X8_v33 (System.Int32)+160])(v489, v289, *([v311 @ X8_v33 (System.Int32)+168]), Il2CppMethodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv491 = \"il2cpp_vm_object_unbox\"(v289, *([v311 @ X8_v33 (System.Int32)+168]), Il2CppMethodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv496 = System.String::op_Equality(v468, v489);\n\tv498 = v496 == 0;\n\tv499 = ~v498;\n\tif (v499) goto L_010C;\n\tv311 = 2;\n\t// 242 Box v290 @ X0_v47, typeof(UnityEngine.Purchasing.TradeSeqState), &v311 @ X8_v33 (System.Int32)\n\tv311 = *([v290 @ X0_v47]);\n\t*([v311 @ X8_v33 (System.Int32)+160])(v515, v290, *([v311 @ X8_v33 (System.Int32)+168]), 0, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv517 = \"il2cpp_vm_object_unbox\"(v290, *([v311 @ X8_v33 (System.Int32)+168]), 0, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv506 = System.String::op_Equality(v468, v515);\n\tv508 = v506 == 0;\n\tif (v508) goto L_0128;\nL_010C:\n\tv291 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v211, \"receipt\");\n\tv311 = *([v291 @ X0_v43]);\n\t*([v311 @ X8_v33 (System.Int32)+160])(v519, v291, *([v311 @ X8_v33 (System.Int32)+168]), Il2CppMethodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tUnityEngine.Purchasing.MoolahStoreImpl::PurchaseSucceed(this, v478, v519, v473);\nL_0125:\n\treturn;\nL_0128:\n\tv231 = 0;\n\t// 297 Box v292 @ X0_v55, typeof(UnityEngine.Purchasing.TradeSeqState), &v231 @ stack_-64_v10\n\tv311 = *([v292 @ X0_v55]);\n\t*([v311 @ X8_v33 (System.Int32)+160])(v526, v292, *([v311 @ X8_v33 (System.Int32)+168]), 0, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv528 = \"il2cpp_vm_object_unbox\"(v292, *([v311 @ X8_v33 (System.Int32)+168]), 0, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv407 = System.String::op_Equality(v468, v526);\n\tv410 = v407 == 0;\n\tif (v410) goto L_0125;\n\tgoto L_014F;\n\tv540 = *([v533 @ X0_v62+E0]);\n\tv541 = v540 == 0;\n\tv542 = ~v541;\n\tif (v542) goto L_014F;\n\tv544 = \"il2cpp_codegen_runtime_class_init\"(v533, v388, v384, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_014F:\n\tv549 = System.Type::GetTypeFromHandle(UnityEngine.Purchasing.PurchaseFailureReason);\n\tgoto L_0163;\n\tv556 = *([v552 @ X8_v52+E0]);\n\tv557 = v556 == 0;\n\tv558 = ~v557;\n\tif (v558) goto L_0163;\n\tv564 = v552;\n\tv560 = \"il2cpp_codegen_runtime_class_init\"(v564, v548, v384, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_0163:\n\tv293 = System.Enum::Parse(v549, \"Unknown\");\n\tv333 = v333_asT == 0;\n\tif (v333) goto L_0180;\n\tv569 = \"il2cpp_vm_object_unbox\"(v293, UnityEngine.Purchasing.PurchaseFailureReason, 0, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tUnityEngine.Purchasing.MoolahStoreImpl::PurchaseFailed(this, v478, *([v569 @ X0_v69]), v483);\n\tgoto L_0125;\n\tv318 = new System.NullReferenceException();\nL_0180:\n\tthrow System.InvalidCastException;\n// 290 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void PurchaseRusult(string resultJson)
		{
			//IL_0082: Expected I4, but got O
			//IL_0108: Expected I4, but got O
			//IL_0131: Expected I4, but got O
			//IL_015a: Expected I4, but got O
			//IL_0183: Expected I4, but got O
			//IL_01b0: Expected I4, but got O
			//IL_028b: Expected I4, but got O
			//IL_0225: Expected I4, but got O
			//IL_02b6: Expected O, but got I4
			//IL_02bf: Expected I4, but got O
			//IL_02d0: Expected I4, but got O
			//IL_0353: Expected I4, but got O
			//IL_038c: Expected I4, but got O
			isNeedPolling = false;
			object obj = MiniJson.JsonDecode(resultJson);
			object obj2;
			if (obj == null)
			{
				obj2 = null;
			}
			else
			{
				Dictionary<string, object> dictionary = obj as Dictionary<string, object>;
				obj2 = ((dictionary == null) ? null : obj);
			}
			string message = "CloudMoolah PurchaseResult resultJson: " + resultJson;
			Debug.Log(message);
			object obj3 = ((Dictionary<string, object>)obj2).get_Item("code");
			int num = (int)obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v311 @ X8_v33 (System.Int32)+160] (should have been resolved before IL gen)");
			string text = default(string);
			if (!(text == "1"))
			{
				return;
			}
			object obj4 = ((Dictionary<string, object>)obj2).get_Item("values");
			Dictionary<string, object> dictionary2 = obj4 as Dictionary<string, object>;
			object obj5 = ((Dictionary<string, object>)obj4).get_Item("state");
			num = (int)obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v311 @ X8_v33 (System.Int32)+160] (should have been resolved before IL gen)");
			object obj6 = ((Dictionary<string, object>)obj4).get_Item("tradeSeq");
			num = (int)obj6;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v311 @ X8_v33 (System.Int32)+160] (should have been resolved before IL gen)");
			object obj7 = ((Dictionary<string, object>)obj4).get_Item("productId");
			num = (int)obj7;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v311 @ X8_v33 (System.Int32)+160] (should have been resolved before IL gen)");
			object obj8 = ((Dictionary<string, object>)obj2).get_Item("msg");
			num = (int)obj8;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v311 @ X8_v33 (System.Int32)+160] (should have been resolved before IL gen)");
			num = 1;
			object obj9 = (TradeSeqState)num;
			num = (int)obj9;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v311 @ X8_v33 (System.Int32)+160] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			string text2 = default(string);
			string text3 = default(string);
			string storeSpecificId = default(string);
			if (!(text2 == text3))
			{
				num = 2;
				object obj10 = (TradeSeqState)num;
				num = (int)obj10;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v311 @ X8_v33 (System.Int32)+160] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				string text4 = default(string);
				if (!(text2 == text4))
				{
					object obj11 = 0;
					object obj12 = (TradeSeqState)obj11;
					num = (int)obj12;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v311 @ X8_v33 (System.Int32)+160] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					string text5 = default(string);
					if (text2 == text5)
					{
						Type typeFromHandle = typeof(PurchaseFailureReason);
						object obj13 = Enum.Parse(typeFromHandle, "Unknown");
						if ((int)((obj13 is PurchaseFailureReason) ? obj13 : null) == 0)
						{
							throw new InvalidCastException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						object obj14 = default(object);
						string msg = default(string);
						PurchaseFailed(storeSpecificId, (PurchaseFailureReason)obj14, msg);
					}
					return;
				}
			}
			object obj15 = ((Dictionary<string, object>)obj4).get_Item("receipt");
			num = (int)obj15;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v311 @ X8_v33 (System.Int32)+160] (should have been resolved before IL gen)");
			string receipt = default(string);
			string transactionId = default(string);
			PurchaseSucceed(storeSpecificId, receipt, transactionId);
		}

		[Token(Token = "0x6000056")]
		[Address(RVA = "0xC667A8", Offset = "0xC667A8", Length = "0x2A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv32 = *([1ED5DC8]);\n\tv33 = *([v32 @ X8_v44]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, product, developerPayload, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2023368]) = v50;\nL_001F:\n\tv56 = new UnityEngine.Purchasing.MoolahStoreImpl+<>c__DisplayClass18_0();\n\tSystem.Object::.ctor(v56);\n\tv56.<>4__this = this;\n\tv69 = System.String::Concat(\"CloudMoolah Purchase: \", product.<storeSpecificId>k__BackingField);\n\tgoto L_003E;\n\tv126 = *([v117 @ X8_v16+E0]);\n\tv127 = v126 == 0;\n\tv128 = ~v127;\n\tif (v128) goto L_003E;\n\tv138 = v117;\n\tv130 = \"il2cpp_codegen_runtime_class_init\"(v138, v65, v67, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_003E:\n\tUnityEngine.Debug::Log(v69);\n\tv144 = this.m_mode == 2;\n\tif (v144) goto L_0077;\n\tv72 = this.m_mode != 1;\n\tif (v72) goto L_007A;\n\tgoto L_0063;\n\tv220 = *([v215 @ X0_v26+E0]);\n\tv221 = v220 == 0;\n\tv222 = ~v221;\n\tif (v222) goto L_0063;\n\tv224 = \"il2cpp_codegen_runtime_class_init\"(v215, v104, v67, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0063:\n\tv228 = System.Guid::NewGuid();\n\tv256 = 0xC12510(&v228 @ X0_v29 (System.Guid), 0, 0, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tUnityEngine.Purchasing.MoolahStoreImpl::PurchaseSucceed(this, product.<storeSpecificId>k__BackingField, \"CloudMoolah TestMode receipt\", v256);\n\tgoto L_00C1;\nL_0077:\n\tUnityEngine.Purchasing.MoolahStoreImpl::PurchaseFailed(this, product.<storeSpecificId>k__BackingField, 4, \"TestMode UserCancelled\");\n\tgoto L_00C1;\nL_007A:\n\tv219 = ~this.isNeedPolling;\n\tv108 = ~v219;\n\tif (v108) goto L_00C7;\n\tv232 = new System.Action`3<System.String, System.String, System.String>();\n\tSystem.Action`3<System.String, System.String, System.String>::.ctor(v232, v56, Il2CppMethodInfo);\n\tv56.purchaseSucceed = v232;\n\tv268 = new System.Action`3<System.String, UnityEngine.Purchasing.PurchaseFailureReason, System.String>();\n\tSystem.Action`3<System.String, UnityEngine.Purchasing.PurchaseFailureReason, System.String>::.ctor(v268, v56, Il2CppMethodInfo);\n\tv56.purchaseFailed = v268;\n\tv278 = new System.Action`3<System.String, System.String, System.String>();\n\tSystem.Action`3<System.String, System.String, System.String>::.ctor(v278, v56, Il2CppMethodInfo);\n\tv287 = new System.Action`2<System.String, System.String>();\n\tSystem.Action`2<System.String, System.String>::.ctor(v287, v56, Il2CppMethodInfo);\n\tthis.m_CurrentStoreProductID = product.<storeSpecificId>k__BackingField;\n\tUnityEngine.Purchasing.MoolahStoreImpl::RequestAuthCode(this, product.<storeSpecificId>k__BackingField, developerPayload, v278, v287);\nL_00C1:\n\treturn;\n\tthrow System.NullReferenceException;\nL_00C7:\n\tv114 = new System.Exception();\n\tSystem.Exception::.ctor(v114, \"CloudMoolah Aborting this purchase. Pending purchase detected.\");\n\tthrow v114;\n// 159 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Purchase(ProductDefinition product, string developerPayload)
		{
			string message = "CloudMoolah Purchase: " + product.storeSpecificId;
			Debug.Log(message);
			if (m_mode != CloudMoolahMode.AlwaysFailed)
			{
				if (m_mode == CloudMoolahMode.AlwaysSucceed)
				{
					Guid guid = Guid.NewGuid();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @C12510 (inside System.Guid::StringToLong +0x320)");
					string transactionId = default(string);
					PurchaseSucceed(product.storeSpecificId, "CloudMoolah TestMode receipt", transactionId);
					return;
				}
				if (isNeedPolling)
				{
					Exception ex = new Exception("CloudMoolah Aborting this purchase. Pending purchase detected.");
					throw ex;
				}
				Action<string, string, string> action = delegate(string productid, string receipt, string transactionId2)
				{
					PurchaseSucceed(productid, receipt, transactionId2);
				};
				Action<string, string, string> purchaseSucceed = action;
				Action<string, PurchaseFailureReason, string> action2 = delegate(string storeSpecificId, PurchaseFailureReason failureReason, string msg)
				{
					//IL_003c: Expected I4, but got O
					Type typeFromHandle = typeof(PurchaseFailureReason);
					object obj = Enum.Parse(typeFromHandle, "Unknown");
					if ((int)((obj is PurchaseFailureReason) ? obj : null) == 0)
					{
						throw new InvalidCastException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					object obj2 = default(object);
					PurchaseFailureReason purchaseFailureReason = default(PurchaseFailureReason);
					if ((IntPtr)obj2 == (IntPtr)(void*)(int)purchaseFailureReason)
					{
					}
					PurchaseFailed(storeSpecificId, PurchaseFailureReason.UserCancelled, msg);
				};
				Action<string, PurchaseFailureReason, string> purchaseFailed = action2;
				Action<string, string, string> succeed = delegate(string text, string authGlobal, string paymentUrl)
				{
					//IL_00e0: Expected O, but got I4
					Exception ex2;
					if (!string.IsNullOrEmpty(paymentUrl))
					{
						if (!string.IsNullOrEmpty(authGlobal))
						{
							if (!string.IsNullOrEmpty(text))
							{
								MoolahStoreImpl moolahStoreImpl = this;
								moolahStoreImpl.isNeedPolling = true;
								MoolahStoreImpl moolahStoreImpl2 = this;
								string customID = moolahStoreImpl2.m_CustomerID;
								bool flag = string.IsNullOrEmpty(moolahStoreImpl2.m_CustomerID);
								if (flag)
								{
									string text2 = ((MoolahStoreImpl)flag).DeviceUniqueIdentifier();
									customID = text2;
								}
								RuntimePlatform platform = Application.platform;
								if (platform == RuntimePlatform.Android)
								{
									MoolahStoreImpl moolahStoreImpl3 = this;
									PayMethod.showPayWebView(paymentUrl, authGlobal, text, moolahStoreImpl3.hashKey, customID);
								}
								else
								{
									Application.OpenURL(paymentUrl);
									IEnumerator routine = StartPurchasePolling(authGlobal, text, purchaseSucceed, purchaseFailed);
									Coroutine coroutine = StartCoroutine(routine);
								}
								return;
							}
							ex2 = new Exception();
							string text3 = "transactionId is null! ";
						}
						else
						{
							ex2 = new Exception();
							string text3 = "authGlobal is null! ";
						}
					}
					else
					{
						string text3 = default(string);
						ex2 = new Exception(text3);
						text3 = "authGlobal is null!";
					}
					throw ex2;
				};
				Action<string, string> failed = delegate(string productID, string msg)
				{
					PurchaseFailed(productID, PurchaseFailureReason.PaymentDeclined, "request MoolahStoreAuthCode failed !");
				};
				m_CurrentStoreProductID = product.storeSpecificId;
				RequestAuthCode(product.storeSpecificId, developerPayload, succeed, failed);
			}
			else
			{
				PurchaseFailed(product.storeSpecificId, PurchaseFailureReason.UserCancelled, "TestMode UserCancelled");
			}
		}

		[Token(Token = "0x6000057")]
		[Address(RVA = "0xC67238", Offset = "0xC67238", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv16 = *([1EEA218]);\n\tv17 = *([v16 @ X8_v10]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2023369]) = v37;\nL_0012:\n\tv38 = UnityEngine.Purchasing.PayMethod::getDeviceID();\n\tv46 = System.String::Concat(\"CloudMoolah getDeviceID: \", v38);\n\tgoto L_002B;\n\tv54 = *([v50 @ X8_v8+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_002B;\n\tv63 = v50;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v63, v42, v43, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_002B:\n\tUnityEngine.Debug::Log(v46);\n\treturn v38;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private string DeviceUniqueIdentifier()
		{
			string deviceID = PayMethod.getDeviceID();
			string message = "CloudMoolah getDeviceID: " + deviceID;
			Debug.Log(message);
			return deviceID;
		}

		[Token(Token = "0x6000058")]
		[Address(RVA = "0xC66A58", Offset = "0xC66A58", Length = "0x7E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv42 = *([1EB3270]);\n\tv43 = *([v42 @ X8_v122]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, productID, payload, succeed, failed, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv58 = 0 | 1;\n\t*([202336A]) = v58;\nL_0022:\n\tv62 = ~this.isRequestAuthCodeing;\n\tv63 = ~v62;\n\tif (v63) goto L_02D8;\n\tv116 = this.m_CustomerID;\n\tv67 = System.String::IsNullOrEmpty(this.m_CustomerID);\n\tv133 = v67 == 0;\n\tif (v133) goto L_0030;\n\tv142 = UnityEngine.Purchasing.MoolahStoreImpl::DeviceUniqueIdentifier(v67);\nL_0030:\n\tv147 = System.String::IsNullOrEmpty(v116);\n\tv153 = v147 == 0;\n\tv154 = ~v153;\n\tif (v154) goto L_02EA;\n\tgoto L_0047;\n\tv201 = *([v158 @ X0_v24+E0]);\n\tv202 = v201 == 0;\n\tv203 = ~v202;\n\tif (v203) goto L_0047;\n\tv205 = \"il2cpp_codegen_runtime_class_init\"(v158, v146, payload, succeed, failed, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_0047:\n\tv209 = System.Guid::NewGuid();\n\tv223 = 0xC12510(&v209 @ X0_v27 (System.Guid), 0, v95, succeed, failed, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\t// 83 NewArr v277 @ X0_v31 (System.String[]), typeof(System.String[]), 6\n\tv342 = this.m_appKey == 0;\n\tif (v342) goto L_0060;\n\t// 93 IsInst this @ X0 (UnityEngine.Purchasing.MoolahStoreImpl), typeof(System.String), this.m_appKey (System.String)\nL_0060:\n\tv617 = v277.Length;\n\tv386 = v277.Length == 0;\n\tif (v386) goto L_02CF;\n\tv277[0] = this.m_appKey;\n\tv387 = v116 == 0;\n\tif (v387) goto L_006D;\n\t// 105 IsInst this @ X0 (UnityEngine.Purchasing.MoolahStoreImpl), typeof(System.String), v116 @ X25_v5 (System.String)\n\tv617 = v277.Length;\nL_006D:\n\tv737 = v617 < 1;\n\tv525 = ~v737;\n\tv508 = v617 - 1;\n\tv474 = v508 == 0;\n\tv738 = ~v525;\n\tv389 = v738 | v474;\n\tif (v389) goto L_02CF;\n\tv277[1] = v116;\n\tv741 = productID == 0;\n\tif (v741) goto L_0083;\n\t// 127 IsInst this @ X0 (UnityEngine.Purchasing.MoolahStoreImpl), typeof(System.String), productID @ X1 (System.String)\n\tv617 = v277.Length;\nL_0083:\n\tv744 = v617 < 2;\n\tv526 = ~v744;\n\tv509 = v617 - 2;\n\tv475 = v509 == 0;\n\tv745 = ~v526;\n\tv390 = v745 | v475;\n\tif (v390) goto L_02CF;\n\tv277[2] = productID;\n\tv746 = v223 == 0;\n\tif (v746) goto L_0099;\n\t// 149 IsInst this @ X0 (UnityEngine.Purchasing.MoolahStoreImpl), typeof(System.String), v223 @ X0_v29 (System.String)\n\tv617 = v277.Length;\nL_0099:\n\tv749 = v617 < 3;\n\tv527 = ~v749;\n\tv510 = v617 - 3;\n\tv476 = v510 == 0;\n\tv750 = ~v527;\n\tv391 = v750 | v476;\n\tif (v391) goto L_02CF;\n\tv277[3] = v223;\n\tv751 = \"1\" == 0;\n\tif (v751) goto L_00AF;\n\t// 171 IsInst this @ X0 (UnityEngine.Purchasing.MoolahStoreImpl), typeof(System.String), \"1\"\n\tv617 = v277.Length;\nL_00AF:\n\tv754 = v617 < 4;\n\tv528 = ~v754;\n\tv511 = v617 - 4;\n\tv477 = v511 == 0;\n\tv755 = ~v528;\n\tv392 = v755 | v477;\n\tif (v392) goto L_02CF;\n\tv277[4] = \"1\";\n\tv756 = this.m_hashKey == 0;\n\tif (v756) goto L_00C6;\n\t// 194 IsInst this @ X0 (UnityEngine.Purchasing.MoolahStoreImpl), typeof(System.String), this.m_hashKey (System.String)\n\tv617 = v277.Length;\nL_00C6:\n\tv759 = v617 < 5;\n\tv360 = ~v759;\n\tv358 = v617 - 5;\n\tv354 = v358 == 0;\n\tv760 = ~v360;\n\tv344 = v760 | v354;\n\tif (v344) goto L_02CF;\n\tv277[5] = this.m_hashKey;\n\tv763 = System.String::Concat(v277);\n\tv765 = UnityEngine.Purchasing.MoolahStoreImpl::GetStringMD5(v763, v763);\n\t// 220 NewArr v370 @ X0_v50 (System.String[]), typeof(System.String[]), 14\n\tv769 = \"?APPId=\" == 0;\n\tif (v769) goto L_00EA;\n\t// 231 IsInst this @ X0 (UnityEngine.Purchasing.MoolahStoreImpl), typeof(System.String), \"?APPId=\"\nL_00EA:\n\tv630 = v370.Length;\n\tv592 = v370.Length == 0;\n\tif (v592) goto L_02CF;\n\tv370[0] = \"?APPId=\";\n\tv772 = this.m_appKey == 0;\n\tif (v772) goto L_00F9;\n\t// 245 IsInst this @ X0 (UnityEngine.Purchasing.MoolahStoreImpl), typeof(System.String), this.m_appKey (System.String)\n\tv630 = v370.Length;\nL_00F9:\n\tv775 = v630 < 1;\n\tv529 = ~v775;\n\tv512 = v630 - 1;\n\tv478 = v512 == 0;\n\tv776 = ~v529;\n\tv393 = v776 | v478;\n\tif (v393) goto L_02CF;\n\tv370[1] = this.m_appKey;\n\tv779 = \"&customerId=\" == 0;\n\tif (v779) goto L_0111;\n\t// 269 IsInst this @ X0 (UnityEngine.Purchasing.MoolahStoreImpl), typeof(System.String), \"&customerId=\"\n\tv630 = v370.Length;\nL_0111:\n\tv781 = v630 < 2;\n\tv530 = ~v781;\n\tv513 = v630 - 2;\n\tv479 = v513 == 0;\n\tv782 = ~v530;\n\tv394 = v782 | v479;\n\tif (v394) goto L_02CF;\n\tv370[2] = \"&customerId=\";\n\tv783 = v116 == 0;\n\tif (v783) goto L_0128;\n\t// 292 IsInst this @ X0 (UnityEngine.Purchasing.MoolahStoreImpl), typeof(System.String), v116 @ X25_v5 (System.String)\n\tv630 = v370.Length;\nL_0128:\n\tv786 = v630 < 3;\n\tv531 = ~v786;\n\tv514 = v630 - 3;\n\tv480 = v514 == 0;\n\tv787 = ~v531;\n\tv395 = v787 | v480;\n\tif (v395) goto L_02CF;\n\tv370[3] = v116;\n\tv790 = \"&productId=\" == 0;\n\tif (v790) goto L_0140;\n\t// 316 IsInst this @ X0 (UnityEngine.Purchasing.MoolahStoreImpl), typeof(System.String), \"&productId=\"\n\tv630 = v370.Length;\nL_0140:\n\tv792 = v630 < 4;\n\tv532 = ~v792;\n\tv515 = v630 - 4;\n\tv481 = v515 == 0;\n\tv793 = ~v532;\n\tv396 = v793 | v481;\n\tif (v396) goto L_02CF;\n\tv370[4] = \"&productId=\";\n\tv794 = productID == 0;\n\tif (v794) goto L_0157;\n\t// 339 IsInst this @ X0 (UnityEngine.Purchasing.MoolahStoreImpl), typeof(System.String), productID @ X1 (System.String)\n\tv630 = v370.Length;\nL_0157:\n\tv797 = v630 < 5;\n\tv533 = ~v797;\n\tv516 = v630 - 5;\n\tv482 = v516 == 0;\n\tv798 = ~v533;\n\tv397 = v798 | v482;\n\tif (v397) goto L_02CF;\n\tv370[5] = productID;\n\tv801 = \"&tradeSeq=\" == 0;\n\tif (v801) goto L_016F;\n\t// 363 IsInst this @ X0 (UnityEngine.Purchasing.MoolahStoreImpl), typeof(System.String), \"&tradeSeq=\"\n\tv630 = v370.Length;\nL_016F:\n\tv803 = v630 < 6;\n\tv534 = ~v803;\n\tv517 = v630 - 6;\n\tv483 = v517 == 0;\n\tv804 = ~v534;\n\tv398 = v804 | v483;\n\tif (v398) goto L_02CF;\n\tv370[6] = \"&tradeSeq=\";\n\tv805 = v223 == 0;\n\tif (v805) goto L_0186;\n\t// 386 IsInst this @ X0 (UnityEngine.Purchasing.MoolahStoreImpl), typeof(System.String), v223 @ X0_v29 (System.String)\n\tv630 = v370.Length;\nL_0186:\n\tv808 = v630 < 7;\n\tv535 = ~v808;\n\tv518 = v630 - 7;\n\tv484 = v518 == 0;\n\tv809 = ~v535;\n\tv399 = v809 | v484;\n\tif (v399) goto L_02CF;\n\tv370[7] = v223;\n\tv812 = \"&tradeType=\" == 0;\n\tif (v812) goto L_019E;\n\t// 410 IsInst this @ X0 (UnityEngine.Purchasing.MoolahStoreImpl), typeof(System.String), \"&tradeType=\"\n\tv630 = v370.Length;\nL_019E:\n\tv814 = v630 < 8;\n\tv536 = ~v814;\n\tv519 = v630 - 8;\n\tv485 = v519 == 0;\n\tv815 = ~v536;\n\tv400 = v815 | v485;\n\tif (v400) goto L_02CF;\n\tv370[8] = \"&tradeType=\";\n\tv816 = \"1\" == 0;\n\tif (v816) goto L_01B5;\n\t// 433 IsInst this @ X0 (UnityEngine.Purchasing.MoolahStoreImpl), typeof(System.String), \"1\"\n\tv630 = v370.Length;\nL_01B5:\n\tv819 = v630 < 9;\n\tv537 = ~v819;\n\tv520 = v630 - 9;\n\tv486 = v520 == 0;\n\tv820 = ~v537;\n\tv401 = v820 | v486;\n\tif (v401) goto L_02CF;\n\tv370[9] = \"1\";\n\tv823 = \"&payLoad=\" == 0;\n\tif (v823) goto L_01CD;\n\t// 457 IsInst this @ X0 (UnityEngine.Purchasing.MoolahStoreImpl), typeof(System.String), \"&payLoad=\"\n\tv630 = v370.Length;\nL_01CD:\n\tv825 = v630 < 0xA;\n\tv538 = ~v825;\n\tv521 = v630 - 0xA;\n\tv487 = v521 == 0;\n\tv826 = ~v538;\n\tv402 = v826 | v487;\n\tif (v402) goto L_02CF;\n\tv370[10] = \"&payLoad=\";\n\tv827 = v95 == 0;\n\tif (v827) goto L_01E4;\n\t// 480 IsInst this @ X0 (UnityEngine.Purchasing.MoolahStoreImpl), typeof(System.String), v95 @ X2_v5 (System.String)\n\tv630 = v370.Length;\nL_01E4:\n\tv830 = v630 < 0xB;\n\tv539 = ~v830;\n\tv522 = v630 - 0xB;\n\tv488 = v522 == 0;\n\tv831 = ~v539;\n\tv403 = v831 | v488;\n\tif (v403) goto L_02CF;\n\tv370[11] = v95;\n\tv834 = \"&sign=\" == 0;\n\tif (v834) goto L_01FC;\n\t// 504 IsInst this @ X0 (UnityEngine.Purchasing.MoolahStoreImpl), typeof(System.String), \"&sign=\"\n\tv630 = v370.Length;\nL_01FC:\n\tv836 = v630 < 0xC;\n\tv540 = ~v836;\n\tv523 = v630 - 0xC;\n\tv489 = v523 == 0;\n\tv837 = ~v540;\n\tv404 = v837 | v489;\n\tif (v404) goto L_02CF;\n\tv370[12] = \"&sign=\";\n\tv838 = v765 == 0;\n\tif (v838) goto L_0213;\n\t// 527 IsInst this @ X0 (UnityEngine.Purchasing.MoolahStoreImpl), typeof(System.String), v765 @ X0_v48 (System.String)\n\tv630 = v370.Length;\nL_0213:\n\tv841 = v630 < 0xD;\n\tv244 = ~v841;\n\tv242 = v630 - 0xD;\n\tv238 = v242 == 0;\n\tv842 = ~v244;\n\tv228 = v842 | v238;\n\tif (v228) goto L_02CF;\n\tv370[13] = v765;\n\tv845 = System.String::Concat(v370);\n\tv261 = new UnityEngine.WWWForm();\n\tUnityEngine.WWWForm::.ctor(v261);\n\tUnityEngine.WWWForm::AddField(v261, \"APPId\", th\n// ... truncated")]
		private void RequestAuthCode(string productID, string payload, Action<string, string, string> succeed, Action<string, string> failed)
		{
			//IL_0044: Expected O, but got I4
			//IL_00c2: Expected O, but got I4
			//IL_0a1f: Expected O, but got I
			//IL_012e: Expected O, but got I4
			//IL_0a7d: Expected O, but got I
			//IL_017e: Expected O, but got I4
			//IL_0adb: Expected O, but got I
			//IL_01ce: Expected O, but got I4
			//IL_0b39: Expected O, but got I
			//IL_0220: Expected O, but got I4
			//IL_0b97: Expected O, but got I
			//IL_0275: Expected O, but got I4
			//IL_02ff: Expected O, but got I4
			//IL_0bf5: Expected O, but got I
			//IL_036e: Expected O, but got I4
			//IL_0c53: Expected O, but got I
			//IL_03c2: Expected O, but got I4
			//IL_0cb1: Expected O, but got I
			//IL_0413: Expected O, but got I4
			//IL_0d0f: Expected O, but got I
			//IL_0465: Expected O, but got I4
			//IL_0d6d: Expected O, but got I
			//IL_04b6: Expected O, but got I4
			//IL_0dcb: Expected O, but got I
			//IL_0508: Expected O, but got I4
			//IL_0e29: Expected O, but got I
			//IL_0559: Expected O, but got I4
			//IL_0e87: Expected O, but got I
			//IL_05ab: Expected O, but got I4
			//IL_0ee5: Expected O, but got I
			//IL_05fe: Expected O, but got I4
			//IL_0f43: Expected O, but got I
			//IL_0651: Expected O, but got I4
			//IL_0fa1: Expected O, but got I
			//IL_06a2: Expected O, but got I4
			//IL_0fff: Expected O, but got I
			//IL_06f4: Expected O, but got I4
			//IL_105d: Expected O, but got I
			//IL_0745: Expected O, but got I4
			//IL_0881: Expected I, but got O
			Exception ex3;
			if (!isRequestAuthCodeing)
			{
				string text = m_CustomerID;
				bool flag = string.IsNullOrEmpty(m_CustomerID);
				if (flag)
				{
					string text2 = ((MoolahStoreImpl)flag).DeviceUniqueIdentifier();
					text = text2;
				}
				if (!string.IsNullOrEmpty(text))
				{
					Guid guid = Guid.NewGuid();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @C12510 (inside System.Guid::StringToLong +0x320)");
					string[] array = new string[6];
					if (appKey != null)
					{
						MoolahStoreImpl moolahStoreImpl = (MoolahStoreImpl)(object)(appKey as string);
					}
					object obj = array.Length;
					if (array.Length != 0)
					{
						array[0] = appKey;
						if (text != null)
						{
							MoolahStoreImpl moolahStoreImpl = (MoolahStoreImpl)(object)(text as string);
							obj = array.Length;
						}
						bool flag2 = (long)(IntPtr)obj < 1L;
						bool flag3 = !flag2;
						object obj2 = (long)(IntPtr)obj - 1L;
						bool flag4 = obj2 == null;
						bool flag5 = !flag3;
						if (!(flag5 || flag4))
						{
							array[1] = text;
							if (productID != null)
							{
								MoolahStoreImpl moolahStoreImpl = (MoolahStoreImpl)(object)(productID as string);
								obj = array.Length;
							}
							bool flag6 = (long)(IntPtr)obj < 2L;
							bool flag7 = !flag6;
							object obj3 = (long)(IntPtr)obj - 2L;
							bool flag8 = obj3 == null;
							bool flag9 = !flag7;
							if (!(flag9 || flag8))
							{
								array[2] = productID;
								string text3 = default(string);
								if (text3 != null)
								{
									MoolahStoreImpl moolahStoreImpl = (MoolahStoreImpl)(object)(text3 as string);
									obj = array.Length;
								}
								bool flag10 = (long)(IntPtr)obj < 3L;
								bool flag11 = !flag10;
								object obj4 = (long)(IntPtr)obj - 3L;
								bool flag12 = obj4 == null;
								bool flag13 = !flag11;
								if (!(flag13 || flag12))
								{
									array[3] = text3;
									if ("1" != null)
									{
										MoolahStoreImpl moolahStoreImpl = (MoolahStoreImpl)(object)("1" as string);
										obj = array.Length;
									}
									bool flag14 = (long)(IntPtr)obj < 4L;
									bool flag15 = !flag14;
									object obj5 = (long)(IntPtr)obj - 4L;
									bool flag16 = obj5 == null;
									bool flag17 = !flag15;
									if (!(flag17 || flag16))
									{
										array[4] = "1";
										if (hashKey != null)
										{
											MoolahStoreImpl moolahStoreImpl = (MoolahStoreImpl)(object)(hashKey as string);
											obj = array.Length;
										}
										bool flag18 = (long)(IntPtr)obj < 5L;
										bool flag19 = !flag18;
										object obj6 = (long)(IntPtr)obj - 5L;
										bool flag20 = obj6 == null;
										bool flag21 = !flag19;
										if (!(flag21 || flag20))
										{
											array[5] = hashKey;
											string text4 = string.Concat(array);
											string stringMD = ((MoolahStoreImpl)(object)text4).GetStringMD5(text4);
											string[] array2 = new string[14];
											if ("?APPId=" != null)
											{
												MoolahStoreImpl moolahStoreImpl = (MoolahStoreImpl)(object)("?APPId=" as string);
											}
											object obj7 = array2.Length;
											if (array2.Length != 0)
											{
												array2[0] = "?APPId=";
												if (appKey != null)
												{
													MoolahStoreImpl moolahStoreImpl = (MoolahStoreImpl)(object)(appKey as string);
													obj7 = array2.Length;
												}
												bool flag22 = (long)(IntPtr)obj7 < 1L;
												bool flag23 = !flag22;
												object obj8 = (long)(IntPtr)obj7 - 1L;
												bool flag24 = obj8 == null;
												bool flag25 = !flag23;
												if (!(flag25 || flag24))
												{
													array2[1] = appKey;
													if ("&customerId=" != null)
													{
														MoolahStoreImpl moolahStoreImpl = (MoolahStoreImpl)(object)("&customerId=" as string);
														obj7 = array2.Length;
													}
													bool flag26 = (long)(IntPtr)obj7 < 2L;
													bool flag27 = !flag26;
													object obj9 = (long)(IntPtr)obj7 - 2L;
													bool flag28 = obj9 == null;
													bool flag29 = !flag27;
													if (!(flag29 || flag28))
													{
														array2[2] = "&customerId=";
														if (text != null)
														{
															MoolahStoreImpl moolahStoreImpl = (MoolahStoreImpl)(object)(text as string);
															obj7 = array2.Length;
														}
														bool flag30 = (long)(IntPtr)obj7 < 3L;
														bool flag31 = !flag30;
														object obj10 = (long)(IntPtr)obj7 - 3L;
														bool flag32 = obj10 == null;
														bool flag33 = !flag31;
														if (!(flag33 || flag32))
														{
															array2[3] = text;
															if ("&productId=" != null)
															{
																MoolahStoreImpl moolahStoreImpl = (MoolahStoreImpl)(object)("&productId=" as string);
																obj7 = array2.Length;
															}
															bool flag34 = (long)(IntPtr)obj7 < 4L;
															bool flag35 = !flag34;
															object obj11 = (long)(IntPtr)obj7 - 4L;
															bool flag36 = obj11 == null;
															bool flag37 = !flag35;
															if (!(flag37 || flag36))
															{
																array2[4] = "&productId=";
																if (productID != null)
																{
																	MoolahStoreImpl moolahStoreImpl = (MoolahStoreImpl)(object)(productID as string);
																	obj7 = array2.Length;
																}
																bool flag38 = (long)(IntPtr)obj7 < 5L;
																bool flag39 = !flag38;
																object obj12 = (long)(IntPtr)obj7 - 5L;
																bool flag40 = obj12 == null;
																bool flag41 = !flag39;
																if (!(flag41 || flag40))
																{
																	array2[5] = productID;
																	if ("&tradeSeq=" != null)
																	{
																		MoolahStoreImpl moolahStoreImpl = (MoolahStoreImpl)(object)("&tradeSeq=" as string);
																		obj7 = array2.Length;
																	}
																	bool flag42 = (long)(IntPtr)obj7 < 6L;
																	bool flag43 = !flag42;
																	object obj13 = (long)(IntPtr)obj7 - 6L;
																	bool flag44 = obj13 == null;
																	bool flag45 = !flag43;
																	if (!(flag45 || flag44))
																	{
																		array2[6] = "&tradeSeq=";
																		if (text3 != null)
																		{
																			MoolahStoreImpl moolahStoreImpl = (MoolahStoreImpl)(object)(text3 as string);
																			obj7 = array2.Length;
																		}
																		bool flag46 = (long)(IntPtr)obj7 < 7L;
																		bool flag47 = !flag46;
																		object obj14 = (long)(IntPtr)obj7 - 7L;
																		bool flag48 = obj14 == null;
																		bool flag49 = !flag47;
																		if (!(flag49 || flag48))
																		{
																			array2[7] = text3;
																			if ("&tradeType=" != null)
																			{
																				MoolahStoreImpl moolahStoreImpl = (MoolahStoreImpl)(object)("&tradeType=" as string);
																				obj7 = array2.Length;
																			}
																			bool flag50 = (long)(IntPtr)obj7 < 8L;
																			bool flag51 = !flag50;
																			object obj15 = (long)(IntPtr)obj7 - 8L;
																			bool flag52 = obj15 == null;
																			bool flag53 = !flag51;
																			if (!(flag53 || flag52))
																			{
																				array2[8] = "&tradeType=";
																				if ("1" != null)
																				{
																					MoolahStoreImpl moolahStoreImpl = (MoolahStoreImpl)(object)("1" as string);
																					obj7 = array2.Length;
																				}
																				bool flag54 = (long)(IntPtr)obj7 < 9L;
																				bool flag55 = !flag54;
																				object obj16 = (long)(IntPtr)obj7 - 9L;
																				bool flag56 = obj16 == null;
																				bool flag57 = !flag55;
																				if (!(flag57 || flag56))
																				{
																					array2[9] = "1";
																					if ("&payLoad=" != null)
																					{
																						MoolahStoreImpl moolahStoreImpl = (MoolahStoreImpl)(object)("&payLoad=" as string);
																						obj7 = array2.Length;
																					}
																					bool flag58 = (long)(IntPtr)obj7 < 10L;
																					bool flag59 = !flag58;
																					object obj17 = (long)(IntPtr)obj7 - 10L;
																					bool flag60 = obj17 == null;
																					bool flag61 = !flag59;
																					if (!(flag61 || flag60))
																					{
																						array2[10] = "&payLoad=";
																						string text5 = default(string);
																						if (text5 != null)
																						{
																							MoolahStoreImpl moolahStoreImpl = (MoolahStoreImpl)(object)(text5 as string);
																							obj7 = array2.Length;
																						}
																						bool flag62 = (long)(IntPtr)obj7 < 11L;
																						bool flag63 = !flag62;
																						object obj18 = (long)(IntPtr)obj7 - 11L;
																						bool flag64 = obj18 == null;
																						bool flag65 = !flag63;
																						if (!(flag65 || flag64))
																						{
																							array2[11] = text5;
																							if ("&sign=" != null)
																							{
																								MoolahStoreImpl moolahStoreImpl = (MoolahStoreImpl)(object)("&sign=" as string);
																								obj7 = array2.Length;
																							}
																							bool flag66 = (long)(IntPtr)obj7 < 12L;
																							bool flag67 = !flag66;
																							object obj19 = (long)(IntPtr)obj7 - 12L;
																							bool flag68 = obj19 == null;
																							bool flag69 = !flag67;
																							if (!(flag69 || flag68))
																							{
																								array2[12] = "&sign=";
																								if (stringMD != null)
																								{
																									MoolahStoreImpl moolahStoreImpl = (MoolahStoreImpl)(object)(stringMD as string);
																									obj7 = array2.Length;
																								}
																								bool flag70 = (long)(IntPtr)obj7 < 13L;
																								bool flag71 = !flag70;
																								object obj20 = (long)(IntPtr)obj7 - 13L;
																								bool flag72 = obj20 == null;
																								bool flag73 = !flag71;
																								if (!(flag73 || flag72))
																								{
																									array2[13] = stringMD;
																									string text6 = string.Concat(array2);
																									WWWForm wWWForm = new WWWForm();
																									wWWForm.AddField("APPId", appKey);
																									wWWForm.AddField("customerId", text);
																									wWWForm.AddField("productId", productID);
																									wWWForm.AddField("tradeSeq", text3);
																									wWWForm.AddField("tradeType", "1");
																									wWWForm.AddField("payload", text5);
																									if (notificationURL != null && notificationURL != "")
																									{
																										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @C713C0 (inside UnityEngine.Purchasing.StoreCatalogImpl::handleCachedCatalog +0x204)");
																										return;
																									}
																									wWWForm.AddField("sign", stringMD);
																									isRequestAuthCodeing = true;
																									IntPtr intPtr = (IntPtr)typeof(MoolahStoreImpl);
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v905 @ X0_v85 (Il2CppClass<UnityEngine.Purchasing.MoolahStoreImpl>)+12F]");
																									Action<string, string> failed2 = ((0u != 0) ? failed : failed);
																									string message = "CloudMoolah: " + requestAuthCodePath + text6;
																									Debug.Log(message);
																									IEnumerator routine = RequestAuthCode(wWWForm, productID, text3, succeed, failed2);
																									Coroutine coroutine = StartCoroutine(routine);
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
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
					throw ex2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846A20 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8)");
				failed(productID, "customerId is null");
				ex3 = new Exception();
				string text7 = "customerId or m_UniqueID is null!";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846A20 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8)");
				failed(productID, "RequestAuthCode repeat");
				string text7 = default(string);
				ex3 = new Exception(text7);
				text7 = "RequestAuthCode repeat";
			}
			throw ex3;
		}

		[Token(Token = "0x6000059")]
		[Address(RVA = "0xC6761C", Offset = "0xC6761C", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv38 = *([1F086A0]);\n\tv39 = *([v38 @ X8_v6]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, wf, productID, transactionId, succeed, failed, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([202336B]) = v53;\nL_0020:\n\tv57 = new UnityEngine.Purchasing.MoolahStoreImpl+<RequestAuthCode>d__22();\n\tSystem.Object::.ctor(v57);\n\tv57.<>1__state = 0;\n\tv57.failed = failed;\n\tv57.<>4__this = this;\n\tv57.wf = wf;\n\tv57.productID = productID;\n\tv57.transactionId = transactionId;\n\tv57.succeed = succeed;\n\treturn v57;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator RequestAuthCode(WWWForm wf, string productID, string transactionId, Action<string, string, string> succeed, Action<string, string> failed)
		{
			_003CRequestAuthCode_003Ed__22 _003CRequestAuthCode_003Ed__23 = null;
			_003CRequestAuthCode_003Ed__23._003C_003E1__state = 0;
			_003CRequestAuthCode_003Ed__23.failed = failed;
			_003CRequestAuthCode_003Ed__23._003C_003E4__this = this;
			_003CRequestAuthCode_003Ed__23.wf = wf;
			_003CRequestAuthCode_003Ed__23.productID = productID;
			_003CRequestAuthCode_003Ed__23.transactionId = transactionId;
			_003CRequestAuthCode_003Ed__23.succeed = succeed;
			return _003CRequestAuthCode_003Ed__23;
		}

		[Token(Token = "0x600005A")]
		[Address(RVA = "0xC676F0", Offset = "0xC676F0", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv34 = *([1ED4A28]);\n\tv35 = *([v34 @ X8_v6]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, authGlobal, transactionId, purchaseSucceed, purchaseFailed, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202336C]) = v50;\nL_001E:\n\tv54 = new UnityEngine.Purchasing.MoolahStoreImpl+<StartPurchasePolling>d__23();\n\tSystem.Object::.ctor(v54);\n\tv54.<>1__state = 0;\n\tv54.purchaseFailed = purchaseFailed;\n\tv54.<>4__this = this;\n\tv54.authGlobal = authGlobal;\n\tv54.transactionId = transactionId;\n\tv54.purchaseSucceed = purchaseSucceed;\n\treturn v54;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator StartPurchasePolling(string authGlobal, string transactionId, Action<string, string, string> purchaseSucceed, Action<string, PurchaseFailureReason, string> purchaseFailed)
		{
			_003CStartPurchasePolling_003Ed__23 _003CStartPurchasePolling_003Ed__24 = null;
			_003CStartPurchasePolling_003Ed__24._003C_003E1__state = 0;
			_003CStartPurchasePolling_003Ed__24.purchaseFailed = purchaseFailed;
			_003CStartPurchasePolling_003Ed__24._003C_003E4__this = this;
			_003CStartPurchasePolling_003Ed__24.authGlobal = authGlobal;
			_003CStartPurchasePolling_003Ed__24.transactionId = transactionId;
			_003CStartPurchasePolling_003Ed__24.purchaseSucceed = purchaseSucceed;
			return _003CStartPurchasePolling_003Ed__24;
		}

		[Token(Token = "0x600005B")]
		[Address(RVA = "0xC66694", Offset = "0xC66694", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1ED1550]);\n\tv31 = *([v30 @ X8_v15]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, storeSpecificId, receipt, transactionId, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([202336D]) = v47;\nL_001F:\n\tgoto L_0029;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0029;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, storeSpecificId, receipt, transactionId, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0029:\n\tUnityEngine.Debug::Log(\"CloudMoolah PurchaseSucceed\");\n\tv65 = this.m_callback;\n\tv68 = *([v65 @ X22_v2 (UnityEngine.Purchasing.Extension.IStoreCallback)]);\n\tv72 = *([v68 @ X8_v9 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]) == 0;\n\tif (v72) goto L_0051;\n\tv126 = *([v68 @ X8_v9 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+B0]) + 8;\nL_003C:\n\tv132 = *([v126 @ X11_v5-8]) == UnityEngine.Purchasing.Extension.IStoreCallback;\n\tif (v132) goto L_0054;\n\tv127 = v127 + 1;\n\tv197 = v127 < *([v68 @ X8_v9 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]);\n\tv106 = ~v197;\n\tv126 = v126 + 0x10;\n\tv82 = ~v106;\n\tif (v82) goto L_003C;\nL_0051:\n\tv204 = 0x8909C4(v65, UnityEngine.Purchasing.Extension.IStoreCallback, 3, transactionId, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0058;\nL_0054:\n\tv199 = *([v126 @ X11_v5]) + 3;\n\tv200 = v199 << 4;\n\tv201 = v68 + v200;\n\tv204 = v201 + 0x130;\nL_0058:\n\tv144 = *([v204 @ X0_v7]);\n\tv142 = *([v204 @ X0_v7+8]);\n\t// 102 IndirectJump v144 @ X5_v1, v65 @ X22_v2 (UnityEngine.Purchasing.Extension.IStoreCallback), v65 @ X22_v2 (UnityEngine.Purchasing.Extension.IStoreCallback), storeSpecificId @ X1 (System.String), receipt @ X2 (System.String), transactionId @ X3 (System.String), v142 @ X4_v1, v144 @ X5_v1, v35 @ X6, v36 @ X7, v37 @ V0, v38 @ V1, v39 @ V2, v40 @ V3, v41 @ V4, v42 @ V5, v43 @ V6, v44 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void PurchaseSucceed(string storeSpecificId, string receipt, string transactionId)
		{
			//IL_0026: Expected I, but got O
			//IL_015b: Expected O, but got I
			//IL_0061: Expected O, but got I
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Expected O, but got Unknown
			//IL_0100: Expected O, but got I
			//IL_010f: Expected O, but got I
			//IL_00ad: Expected O, but got I
			Debug.Log("CloudMoolah PurchaseSucceed");
			IStoreCallback callback = m_callback;
			IntPtr intPtr = (IntPtr)callback;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ X8_v9 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00c6;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ X8_v9 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IStoreCallback))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ X8_v9 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00c6;
			}
			object obj2 = obj + 3;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0143;
			IL_00c6:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0143;
			IL_0143:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ X0_v7+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v144 @ X5_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600005C")]
		[Address(RVA = "0xC66140", Offset = "0xC66140", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1F0FF48]);\n\tv31 = *([v30 @ X8_v10]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, storeSpecificId, reason, msg, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([202336E]) = v47;\nL_001C:\n\tv51 = new UnityEngine.Purchasing.Extension.PurchaseFailureDescription();\n\tUnityEngine.Purchasing.Extension.PurchaseFailureDescription::.ctor(v51, storeSpecificId, reason, msg);\n\tv57 = this.m_callback;\n\tv60 = *([v57 @ X20_v2 (UnityEngine.Purchasing.Extension.IStoreCallback)]);\n\tv64 = *([v60 @ X8_v5 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]) == 0;\n\tif (v64) goto L_004A;\n\tv118 = *([v60 @ X8_v5 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+B0]) + 8;\nL_0035:\n\tv124 = *([v118 @ X11_v5-8]) == UnityEngine.Purchasing.Extension.IStoreCallback;\n\tif (v124) goto L_004D;\n\tv119 = v119 + 1;\n\tv185 = v119 < *([v60 @ X8_v5 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]);\n\tv98 = ~v185;\n\tv118 = v118 + 0x10;\n\tv74 = ~v98;\n\tif (v74) goto L_0035;\nL_004A:\n\tv192 = 0x8909C4(v57, UnityEngine.Purchasing.Extension.IStoreCallback, 4, msg, 0, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0051;\nL_004D:\n\tv187 = *([v118 @ X11_v5]) + 4;\n\tv188 = v187 << 4;\n\tv189 = v60 + v188;\n\tv192 = v189 + 0x130;\nL_0051:\n\tv163 = *([v192 @ X0_v6]);\n\tv165 = *([v192 @ X0_v6+8]);\n\t// 93 IndirectJump v163 @ X3_v2, v57 @ X20_v2 (UnityEngine.Purchasing.Extension.IStoreCallback), v57 @ X20_v2 (UnityEngine.Purchasing.Extension.IStoreCallback), v51 @ X0_v3 (UnityEngine.Purchasing.Extension.PurchaseFailureDescription), v165 @ X2_v3, v163 @ X3_v2, 0, v34 @ X5, v35 @ X6, v36 @ X7, v37 @ V0, v38 @ V1, v39 @ V2, v40 @ V3, v41 @ V4, v42 @ V5, v43 @ V6, v44 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void PurchaseFailed(string storeSpecificId, PurchaseFailureReason reason, string msg)
		{
			//IL_000d: Expected I, but got O
			//IL_0162: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00e7: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_0094: Expected O, but got I
			PurchaseFailureDescription purchaseFailureDescription = new PurchaseFailureDescription(storeSpecificId, reason, msg);
			IStoreCallback callback = m_callback;
			IntPtr intPtr = (IntPtr)callback;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ X8_v5 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ X8_v5 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IStoreCallback))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ X8_v5 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 4;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_014a;
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_014a;
			IL_014a:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v163 @ X3_v2 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600005D")]
		[Address(RVA = "0xC677B8", Offset = "0xC677B8", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ED4508]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, product, transactionId, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202336F]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, product, transactionId, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::Log(\"CloudMoolah FinishTransaction\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void FinishTransaction(ProductDefinition product, string transactionId)
		{
			Debug.Log("CloudMoolah FinishTransaction");
		}

		[Token(Token = "0x600005E")]
		[Address(RVA = "0xC674A0", Offset = "0xC674A0", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EB3BD8]);\n\tv25 = *([v24 @ X8_v19]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, md5String, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2023370]) = v44;\nL_0017:\n\tv46 = System.Text.Encoding::get_UTF8();\n\tv52 = System.Text.Encoding::GetBytes(v46, md5String);\n\tv58 = new System.Security.Cryptography.MD5CryptoServiceProvider();\n\tSystem.Security.Cryptography.MD5CryptoServiceProvider::.ctor(v58);\n\tv104 = System.Security.Cryptography.HashAlgorithm::ComputeHash(v58, v52);\n\tv144 = v104.Length;\n\tv209 = v104.Length < 1;\n\tif (v209) goto L_0085;\nL_0044:\n\tv271 = v64 < v144;\n\tv93 = ~v271;\n\tif (v93) goto L_0088;\n\tgoto L_005D;\n\tv277 = *([v273 @ X0_v21+E0]);\n\tv278 = v277 == 0;\n\tv279 = ~v278;\n\tif (v279) goto L_005D;\n\tv281 = \"il2cpp_codegen_runtime_class_init\"(v273, v137, v133, v60, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_005D:\n\tv105 = System.Convert::ToString(v104[v64 @ X22_v7 (System.Int32)], 0x10);\n\tv286 = System.String::PadLeft(v105, 2, 0x30);\n\tv259 = System.String::Concat(v115, v286);\n\tv144 = v104.Length;\n\tv64 = v64 + 1;\n\tv248 = v64 < v104.Length;\n\tif (v248) goto L_0044;\nL_0085:\n\treturnVal2 = System.String::PadLeft(v192, 0x20, 0x30);\n\treturn returnVal2;\n\tv116 = new System.NullReferenceException();\nL_0088:\n\tv146 = new System.IndexOutOfRangeException();\n\tthrow v146;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 106 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private string GetStringMD5(string md5String)
		{
			Encoding uTF = Encoding.UTF8;
			byte[] bytes = uTF.GetBytes(md5String);
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] array = mD5CryptoServiceProvider.ComputeHash(bytes);
			int num = array.Length;
			bool flag = array.Length < 1;
			string text = "";
			if (!flag)
			{
				int num2 = 0;
				string text2 = "";
				bool flag2;
				do
				{
					if (num2 < num)
					{
						string text3 = Convert.ToString(array[num2], 16);
						string text4 = text3.PadLeft(2, '0');
						string text5 = text2 + text4;
						num = array.Length;
						num2++;
						flag2 = num2 < array.Length;
						text = text5;
						text2 = text5;
						continue;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				while (flag2);
			}
			return text.PadLeft(32, '0');
		}

		[Token(Token = "0x6000065")]
		[Address(RVA = "0xC6784C", Offset = "0xC6784C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_mode = mode;\n\treturn;\n")]
		public void SetMode(CloudMoolahMode mode)
		{
			m_mode = mode;
		}

		[Token(Token = "0x6000066")]
		[Address(RVA = "0xC6580C", Offset = "0xC6580C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_mode;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private CloudMoolahMode GetMode()
		{
			return m_mode;
		}

		[Token(Token = "0x6000067")]
		[Address(RVA = "0xC67854", Offset = "0xC67854", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EAC040]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, result, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023371]) = v41;\nL_001A:\n\tv47 = this.m_mode == 2;\n\tif (v47) goto L_FFFFFFFF;\n\tv61 = this.m_mode != 1;\n\tif (v61) goto L_0042;\n\tgoto L_003E;\nL_003E:\n\tSystem.Action`1<UnityEngine.Purchasing.RestoreTransactionIDState>::Invoke(result, v95);\n\treturn;\nL_0042:\n\tv66 = UnityEngine.Purchasing.MoolahStoreImpl::RestoreTransactionIDProcess(this, result);\n\tv94 = UnityEngine.MonoBehaviour::StartCoroutine(this, v66);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RestoreTransactionID(Action<RestoreTransactionIDState> result)
		{
			int obj;
			if (m_mode != CloudMoolahMode.AlwaysFailed)
			{
				if (m_mode != CloudMoolahMode.AlwaysSucceed)
				{
					IEnumerator routine = RestoreTransactionIDProcess(result);
					Coroutine coroutine = StartCoroutine(routine);
					return;
				}
				obj = 1;
			}
			else
			{
				obj = 2;
			}
			result((RestoreTransactionIDState)obj);
		}

		[Token(Token = "0x6000068")]
		[Address(RVA = "0xC67910", Offset = "0xC67910", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EEE570]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, result, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023372]) = v41;\nL_0018:\n\tv45 = new UnityEngine.Purchasing.MoolahStoreImpl+<RestoreTransactionIDProcess>d__45();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.result = result;\n\tv45.<>4__this = this;\n\treturn v45;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator RestoreTransactionIDProcess(Action<RestoreTransactionIDState> result)
		{
			_003CRestoreTransactionIDProcess_003Ed__45 _003CRestoreTransactionIDProcess_003Ed__46 = null;
			_003CRestoreTransactionIDProcess_003Ed__46._003C_003E1__state = 0;
			_003CRestoreTransactionIDProcess_003Ed__46.result = result;
			_003CRestoreTransactionIDProcess_003Ed__46._003C_003E4__this = this;
			return _003CRestoreTransactionIDProcess_003Ed__46;
		}

		[Token(Token = "0x6000069")]
		[Address(RVA = "0xC679BC", Offset = "0xC679BC", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv30 = *([1EE9398]);\n\tv31 = *([v30 @ X8_v15]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, transactionId, receipt, result, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2023373]) = v47;\nL_001B:\n\tv50 = System.String::IsNullOrEmpty(v148);\n\tv52 = v50 == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_FFFFFFFF;\n\tv56 = System.String::IsNullOrEmpty(receipt);\n\tv60 = v56 == 0;\n\tif (v60) goto L_0040;\nL_0039:\n\tSystem.Action`3<System.String, UnityEngine.Purchasing.ValidateReceiptState, System.String>::Invoke(v150, v148, v131, v135);\n\treturn;\nL_0040:\n\tv87 = this.m_mode == 2;\n\tif (v87) goto L_FFFFFFFF;\n\tv67 = this.m_mode != 1;\n\tif (v67) goto L_0066;\n\tgoto L_0039;\n\tgoto L_FFFFFFFF;\nL_0066:\n\tv201 = UnityEngine.Purchasing.MoolahStoreImpl::ValidateReceiptProcess(this, v148, receipt, result);\n\tv183 = UnityEngine.MonoBehaviour::StartCoroutine(this, v201);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ValidateReceipt(string transactionId, string receipt, Action<string, ValidateReceiptState, string> result)
		{
			string text = default(string);
			string text2;
			int arg;
			string arg2;
			Action<string, ValidateReceiptState, string> action;
			if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(receipt))
			{
				text2 = "transactionId or receipt is null";
			}
			else
			{
				if (m_mode != CloudMoolahMode.AlwaysFailed)
				{
					if (m_mode == CloudMoolahMode.AlwaysSucceed)
					{
						arg = 0;
						arg2 = "TestMode ValidateSucceed";
						action = result;
						goto IL_010b;
					}
					IEnumerator routine = ValidateReceiptProcess(text, receipt, result);
					Coroutine coroutine = StartCoroutine(routine);
					return;
				}
				text2 = "TestMode ValidateFailed";
			}
			arg = 1;
			arg2 = text2;
			action = result;
			goto IL_010b;
			IL_010b:
			action(text, (ValidateReceiptState)arg, arg2);
		}

		[Token(Token = "0x600006A")]
		[Address(RVA = "0xC67AEC", Offset = "0xC67AEC", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1EFDFC0]);\n\tv31 = *([v30 @ X8_v6]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, transactionId, receipt, result, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2023374]) = v47;\nL_001C:\n\tv51 = new UnityEngine.Purchasing.MoolahStoreImpl+<ValidateReceiptProcess>d__47();\n\tSystem.Object::.ctor(v51);\n\tv51.<>1__state = 0;\n\tv51.result = result;\n\tv51.<>4__this = this;\n\tv51.transactionId = transactionId;\n\tv51.receipt = receipt;\n\treturn v51;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator ValidateReceiptProcess(string transactionId, string receipt, Action<string, ValidateReceiptState, string> result)
		{
			_003CValidateReceiptProcess_003Ed__47 _003CValidateReceiptProcess_003Ed__48 = null;
			_003CValidateReceiptProcess_003Ed__48._003C_003E1__state = 0;
			_003CValidateReceiptProcess_003Ed__48.result = result;
			_003CValidateReceiptProcess_003Ed__48._003C_003E4__this = this;
			_003CValidateReceiptProcess_003Ed__48.transactionId = transactionId;
			_003CValidateReceiptProcess_003Ed__48.receipt = receipt;
			return _003CValidateReceiptProcess_003Ed__48;
		}

		[Token(Token = "0x600006B")]
		[Address(RVA = "0xC67BAC", Offset = "0xC67BAC", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1ECCB80]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023375]) = v38;\nL_0013:\n\tthis.isNeedPolling = 0;\n\tthis.isRequestAuthCodeing = 0;\n\tthis.m_mode = 0;\n\tthis.m_CustomerID = \"\";\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MoolahStoreImpl()
		{
			isNeedPolling = false;
			isRequestAuthCodeing = false;
			m_mode = default(CloudMoolahMode);
			m_CustomerID = "";
		}
	}
}
