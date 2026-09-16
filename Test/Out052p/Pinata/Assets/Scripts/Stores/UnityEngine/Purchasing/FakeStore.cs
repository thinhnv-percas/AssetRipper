using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200008D")]
	internal class FakeStore : JSONStore, IStoreExtension, INativeStore
	{
		[Token(Token = "0x200008E")]
		protected enum DialogType
		{
			[Token(Token = "0x4000208")]
			Purchase = 0,
			[Token(Token = "0x4000209")]
			RetrieveProducts = 1
		}

		[CompilerGenerated]
		[Token(Token = "0x2000090")]
		private sealed class _003C_003Ec__DisplayClass15_0
		{
			[Token(Token = "0x400020C")]
			[FieldOffset(Offset = "0x10")]
			public FakeStore _003C_003E4__this;

			[Token(Token = "0x400020D")]
			[FieldOffset(Offset = "0x18")]
			public ProductDefinition product;

			[Token(Token = "0x600024B")]
			[Address(RVA = "0xC608C8", Offset = "0xC608C8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec__DisplayClass15_0()
			{
			}

			internal unsafe void _003CFakePurchase_003Eb__0(bool allow, PurchaseFailureReason failureReason)
			{
				//IL_008f: Expected I4, but got O
				if (allow)
				{
					ProductDefinition productDefinition = product;
					Guid guid = Guid.NewGuid();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @C12510 (inside System.Guid::StringToLong +0x320)");
					string transactionID = default(string);
					_003C_003E4__this.OnPurchaseSucceeded(productDefinition.storeSpecificId, "{ \"this\" : \"is a fake receipt\" }", transactionID);
					return;
				}
				Type typeFromHandle = typeof(PurchaseFailureReason);
				object obj = Enum.Parse(typeFromHandle, "Unknown");
				if ((int)((obj is PurchaseFailureReason) ? obj : null) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					ProductDefinition productDefinition2 = product;
					PurchaseFailureReason reason = (((IntPtr)this != (IntPtr)(void*)(int)failureReason) ? failureReason : PurchaseFailureReason.UserCancelled);
					PurchaseFailureDescription failure = new PurchaseFailureDescription(productDefinition2.storeSpecificId, reason, "failed a fake store purchase");
					_003C_003E4__this.OnPurchaseFailed(failure);
					return;
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x4000202")]
		[FieldOffset(Offset = "0xA8")]
		private IStoreCallback m_Biller;

		[Token(Token = "0x4000203")]
		[FieldOffset(Offset = "0xB0")]
		private List<string> m_PurchasedProducts;

		[Token(Token = "0x4000204")]
		[FieldOffset(Offset = "0xB8")]
		public bool purchaseCalled;

		[Token(Token = "0x4000206")]
		[FieldOffset(Offset = "0xC8")]
		public FakeStoreUIMode UIMode;

		[Token(Token = "0x17000059")]
		public string unavailableProductId
		{
			[CompilerGenerated]
			[Token(Token = "0x600023E")]
			[Address(RVA = "0xC5F138", Offset = "0xC5F138", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<unavailableProductId>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return unavailableProductId;
			}
		}

		[Token(Token = "0x600023F")]
		[Address(RVA = "0xC5F140", Offset = "0xC5F140", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_Biller = biller;\n\tUnityEngine.Purchasing.JSONStore::Initialize(this, biller);\n\tthis.store = this;\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Initialize(IStoreCallback biller)
		{
			m_Biller = biller;
			base.Initialize(biller);
			store = this;
		}

		[Token(Token = "0x6000240")]
		[Address(RVA = "0xC5F2FC", Offset = "0xC5F2FC", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1F0E760]);\n\tv23 = *([v22 @ X8_v20]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, json, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202332D]) = v41;\nL_0017:\n\tv44 = UnityEngine.Purchasing.MiniJson::JsonDecode(json);\n\tv45 = v44 == 0;\n\tif (v45) goto L_003D;\n\tgoto L_FFFFFFFF;\n\tv66 = v66_asT == 0;\n\tif (v66) goto L_0058;\nL_003D:\n\tv102 = UnityEngine.Purchasing.ProductDefinitionExtensions::DecodeJSON(v44, \"fake\");\n\tv121 = System.Linq.Enumerable::ToList(v102);\n\tv127 = new System.Collections.ObjectModel.ReadOnlyCollection`1<UnityEngine.Purchasing.ProductDefinition>();\n\tSystem.Collections.ObjectModel.ReadOnlyCollection`1<UnityEngine.Purchasing.ProductDefinition>::.ctor(v127, v121);\n\tUnityEngine.Purchasing.FakeStore::StoreRetrieveProducts(this, v127);\n\treturn;\nL_0058:\n\tthrow System.InvalidCastException;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RetrieveProducts(string json)
		{
			object obj = MiniJson.JsonDecode(json);
			if (obj != null)
			{
				List<object> list = obj as List<object>;
				if (list == null)
				{
					throw new InvalidCastException();
				}
			}
			List<ProductDefinition> source = ((List<object>)obj).DecodeJSON("fake");
			List<ProductDefinition> list2 = source.ToList();
			ReadOnlyCollection<ProductDefinition> productDefinitions = new ReadOnlyCollection<ProductDefinition>(list2);
			StoreRetrieveProducts(productDefinitions);
		}

		[Token(Token = "0x6000241")]
		[Address(RVA = "0xC5FA98", Offset = "0xC5FA98", Length = "0x8C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = &v21 @ X29;\n\tgoto L_0022;\n\tv35 = *([1EC1FE0]);\n\tv36 = *([v35 @ X8_v103]);\n\tv37 = \"il2cpp_codegen_initialize_method\"(v36, productDefinitions, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([202332E]) = v54;\nL_0022:\n\tv61 = new UnityEngine.Purchasing.FakeStore+<>c__DisplayClass13_0();\n\tSystem.Object::.ctor(v61);\n\tv61.<>4__this = this;\n\tv68 = new System.Collections.Generic.List`1<UnityEngine.Purchasing.Extension.ProductDescription>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.Extension.ProductDescription>::.ctor(v68);\n\tv61.products = v68;\n\tv222 = System.Collections.ObjectModel.ReadOnlyCollection`1<UnityEngine.Purchasing.ProductDefinition>::GetEnumerator(productDefinitions);\n\t*([v21 @ X29-68]) = 0;\nL_0045:\n\tgoto L_006C;\n\tv369 = *([v363 @ X8_v44+B0]);\n\tv370 = 0;\n\tv371 = v369 + 8;\n\tv373 = *([v436 @ X11_v55-8]);\n\tv441 = v373 == v364;\n\tif (v441) goto L_0065;\n\tv393 = v435 + 1;\n\tv482 = v393 < v365;\n\tv391 = ~v482;\n\tv395 = v436 + 0x10;\n\tv375 = ~v391;\n\tif (v375) goto L_FFFFFFFF;\n\tv396 = v206;\n\tv397 = 0;\n\tv398 = 0x8909C4(v396, v364, v397, v298, v296, v300, v294, v290, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_006C;\nL_0065:\n\tv483 = *([v436 @ X11_v55]);\n\tv484 = v483 << 4;\n\tv485 = v363 + v484;\n\tv486 = v485 + 0x130;\nL_006C:\n\tv507 = System.Collections.IEnumerator::MoveNext(v222);\n\tv509 = v507 == 0;\n\tif (v509) goto L_0254;\n\tgoto L_009D;\n\tv628 = *([v555 @ X8_v48+B0]);\n\tv629 = 0;\n\tv630 = v628 + 8;\n\tv632 = *([v783 @ X11_v50-8]);\n\tv788 = v632 == v559;\n\tif (v788) goto L_0096;\n\tv652 = v782 + 1;\n\tv864 = v652 < v557;\n\tv650 = ~v864;\n\tv654 = v783 + 0x10;\n\tv634 = ~v650;\n\tif (v634) goto L_FFFFFFFF;\n\tv655 = v206;\n\tv656 = 0;\n\tv657 = 0x8909C4(v655, v559, v656, v298, v296, v300, v294, v290, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_009D;\nL_0096:\n\tv865 = *([v783 @ X11_v50]);\n\tv866 = v865 << 4;\n\tv867 = v555 + v866;\n\tv868 = v867 + 0x130;\nL_009D:\n\tv419 = System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.ProductDefinition>::get_Current(v222);\n\tv352 = System.String::op_Inequality(this.<unavailableProductId>k__BackingField, v419.<id>k__BackingField);\n\tv355 = v352 == 0;\n\tif (v355) goto L_0045;\n\tv977 = System.String::Concat(\"Fake title for \", v419.<id>k__BackingField);\n\t*([v21 @ X29-60]) = 0;\n\t*([v21 @ X29-58]) = 0;\n\tv981 = &v21 @ X29 - 0x60;\n\tv988 = 0xEA3E34(v981, 1, 0, 0, 0, 2, 0, v661, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv1010 = new UnityEngine.Purchasing.ProductMetadata();\n\tv171 = *([v21 @ X29-60]);\n\tv165 = *([v21 @ X29-58]);\n\tUnityEngine.Purchasing.ProductMetadata::.ctor(v1010, \"$0.01\", v977, \"Fake description\", \"USD\", *([v21 @ X29-60]));\n\tv546 = UnityEngine.Purchasing.ProductCatalog::LoadDefaultCatalog();\n\tv1037 = v546 == 0;\n\tif (v1037) goto L_00FC;\n\t*([v21 @ X29-6C]) = v346;\n\tv548 = v546.products == 0;\n\tif (v548) goto L_0264;\n\tgoto L_010A;\n\tv1078 = *([v1041 @ X8_v66+B0]);\n\tv1079 = 0;\n\tv1080 = v1078 + 8;\n\tv1082 = *([v1121 @ X11_v45-8]);\n\tv1126 = v1082 == v1045;\n\tif (v1126) goto L_0101;\n\tv1102 = v1120 + 1;\n\tv1131 = v1102 < v1043;\n\tv1100 = ~v1131;\n\tv1104 = v1121 + 0x10;\n\tv1084 = ~v1100;\n\tif (v1084) goto L_FFFFFFFF;\n\tv1105 = v526;\n\tv1106 = 0;\n\tv1107 = v357;\n\tv1108 = v288;\n\tv1109 = 0x8909C4(v1105, v1045, v1106, v522, v520, v524, v518, v514, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_010A;\nL_00FC:\n\t*([v21 @ X29-78]) = v1010;\n\tgoto L_0241;\nL_0101:\n\tv1132 = *([v1121 @ X11_v45]);\n\tv1133 = v357;\n\tv1134 = v288;\n\tv1135 = v1132 << 4;\n\tv1136 = v1041 + v1135;\n\tv1137 = v1136 + 0x130;\nL_010A:\n\tv1160 = System.Collections.Generic.IEnumerable`1<UnityEngine.Purchasing.ProductCatalogItem>::GetEnumerator(v546.products);\nL_010D:\n\t*([v21 @ X29-78]) = v1164;\nL_010F:\n\tv756 = v1160 == 0;\n\tif (v756) goto L_01B3;\n\tgoto L_013F;\n\tv1206 = *([v1201 @ X8_v71+B0]);\n\tv1207 = 0;\n\tv1208 = v1206 + 8;\n\tv1210 = *([v1248 @ X11_v40-8]);\n\tv1253 = v1210 == v1202;\n\tif (v1253) goto L_0137;\n\tv1230 = v1247 + 1;\n\tv1258 = v1230 < v1203;\n\tv1228 = ~v1258;\n\tv1232 = v1248 + 0x10;\n\tv1212 = ~v1228;\n\tif (v1212) goto L_FFFFFFFF;\n\tv1233 = *([v24 @ X29_v1-6C]);\n\tv1234 = v584;\n\tv1235 = 0;\n\tv1236 = 0x8909C4(v1234, v1202, v1235, v580, v578, v582, v576, v572, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_013F;\nL_0137:\n\tv1259 = *([v1248 @ X11_v40]);\n\tv1260 = *([v24 @ X29_v1-6C]);\n\tv1261 = v1259 << 4;\n\tv1262 = v1201 + v1261;\n\tv1263 = v1262 + 0x130;\nL_013F:\n\tv1285 = System.Collections.IEnumerator::MoveNext(v1160);\n\tv1287 = v1285 == 0;\n\tif (v1287) goto L_01AB;\n\tgoto L_0174;\n\tv1298 = *([v1288 @ X8_v84+B0]);\n\tv1299 = 0;\n\tv1300 = v1298 + 8;\n\tv1302 = *([v1347 @ X11_v35-8]);\n\tv1352 = v1302 == v1292;\n\tif (v1352) goto L_016B;\n\tv1322 = v1346 + 1;\n\tv1420 = v1322 < v1290;\n\tv1320 = ~v1420;\n\tv1324 = v1347 + 0x10;\n\tv1304 = ~v1320;\n\tif (v1304) goto L_FFFFFFFF;\n\tv1325 = v584;\n\tv1326 = 0;\n\tv1327 = v622;\n\tv1328 = v570;\n\tv1329 = 0x8909C4(v1325, v1292, v1326, v580, v578, v582, v576, v572, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_0174;\nL_016B:\n\tv1421 = *([v1347 @ X11_v35]);\n\tv1422 = v622;\n\tv1423 = v570;\n\tv1424 = v1421 << 4;\n\tv1425 = v1288 + v1424;\n\tv1426 = v1425 + 0x130;\nL_0174:\n\tv1430 = System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.ProductCatalogItem>::get_Current(v1160);\n\tv757 = v1430 == 0;\n\tif (v757) goto L_01B6;\n\tv208 = v419.<id>k__BackingField;\n\tv1198 = System.String::op_Equality(v1430.id, v419.<id>k__BackingField);\n\tv1200 = v1198 == 0;\n\tif (v1200) goto L_010F;\n\tv758 = v1430.googlePrice == 0;\n\tif (v758) goto L_01B9;\n\tv1468 = v1430.googlePrice + 0x10;\n\tv1469 = 0xEA4608(v1468, 0, 0, v169, v167, v171, v165, v661, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv769 = v1430.defaultDescription;\n\tv759 = v1430.defaultDescription == 0;\n\tif (v759) goto L_01BC;\n\tv1472 = UnityEngine.Purchasing.LocalizedProductDescription::DecodeNonLatinCharacters(v769.title);\n\t*([v21 @ X29-88]) = v1469;\n\t*([v21 @ X29-80]) = v1472;\n\tv770 = v1430.defaultDescription;\n\tv760 = v1430.defaultDescription == 0;\n\tif (v760) goto L_01BF;\n\tv1475 = UnityEngine.Purchasing.LocalizedProductDescription::DecodeNonLatinCharacters(v770.description);\n\tv771 = v1430.googlePrice;\n\tv761 = v1430.googlePrice == 0;\n\tif (v761) goto L_01C2;\n\t*([v21 @ X29-90]) = v771.value;\n\t*([v21 @ X29-98]) = v771.value.lo;\n\tv1481 = new UnityEngine.Purchasing.ProductMetadata();\n\tv208 = *([v21 @ X29-88]);\n\tv165 = *([v21 @ X29-98]);\n\tv171 = *([v21 @ X29-90]);\n\tUnityEngine.Purchasing.ProductMetadata::.ctor(v1481, *([v21 @ X29-88]), *([v21 @ X29-80]), v1475, \"USD\", *([v21 @ X29-90]));\n\tgoto L_010D;\nL_01AB:\n\tv1294 = 1;\n\t*([v1069 @ X19_v13 (UnityEngine.Purchasing.ProductCatalogItem)+v1294 @ X25_v22 (UnityEngine.Purchasing.ProductMetadata)*4]) = 0x11E;\n\tv1296 = v1160 == 0;\n\tv1297 = ~v1296;\n\tif (v1297) goto L_01F2;\n\tgoto L_021A;\nL_01B3:\n\tv750 = new System.NullReferenceException();\n\tgoto L_026A;\nL_01B6:\n\tv751 = new System.NullReferenceException();\n\tgoto L_026A;\nL_01B9:\n\tv752 = new System.NullReferenceException();\n\tgoto L_026A;\nL_01BC:\n\tv753 = new System.NullReferenceException();\n\tgoto L_026A;\nL_01BF:\n\tv754 = new System.NullReferenceException();\n\tgoto L_026A;\nL_01C2:\n\tv755 = new System.NullReferenceException();\n\tgoto L_026A;\n\tgoto L_01D2;\n\tgoto L_01D2;\n\tgoto L_01D2;\n\tgoto L_01D2;\n\tgoto L_01D2;\n\tX8 = X1;\n\tX2 = X0;\n\tgoto L_01D5;\n\tgoto L_01D2;\n\tgoto L_01D2;\n\tgoto L_01D2;\n\tgoto L_01D2;\n\tgoto L_01D2;\n\tgoto L_01D2;\nL_01D2:\n\tX8 = X1;\n\tX2 = X0;\n\tX27 = X19;\nL_01D5:\n\tX19 = X25;\n\tX25 = *([X29-6C]);\n\tgoto L_01DA;\n\tX8 = X1;\n\tX2 = X0;\nL_01DA:\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0293;\n\tX0 = X2;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X0]);\n\t*([X29-68]) = X8;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_021A;\nL_01F2:\n\tgoto L_0219;\n\tv1390 = *([v1330 @ X8_v80+B0]);\n\tv1391 = 0;\n\tv1392 = v1390 + 8;\n\tv1394 = *([v1445 @ X11_v29-8]);\n\tv1450 = v1394 == v1334;\n\tif (v1450) goto L_0212;\n\tv1414 = v1444 + 1;\n\tv1459 = v1414 < v1332;\n\tv1412 = ~v1459;\n\tv1416 = v1445 + 0x10;\n\tv1396 = ~v1412;\n\tif (v1396) goto L_FFFFFFFF;\n\tv1417 = v58\n// ... truncated")]
		public void StoreRetrieveProducts(ReadOnlyCollection<ProductDefinition> productDefinitions)
		{
			//IL_0060: Expected O, but got I8
			//IL_05e0: Expected O, but got I
			//IL_05ef: Expected O, but got I
			//IL_063d: Expected O, but got I
			//IL_0a2d: Expected O, but got I
			//IL_00de: Expected O, but got I
			//IL_0111: Expected O, but got I
			//IL_0125: Expected O, but got I
			//IL_0135: Expected O, but got I
			//IL_081f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0824: Expected O, but got Unknown
			//IL_093f: Expected O, but got I
			//IL_03d3: Expected O, but got I4
			//IL_09d3: Expected O, but got I4
			//IL_057f: Expected O, but got I4
			//IL_059c: Expected O, but got I4
			//IL_053f: Expected O, but got I8
			//IL_0247: Expected O, but got I
			//IL_0357: Expected O, but got I
			//IL_0357: Expected O, but got I
			//IL_0357: Expected O, but got I
			//IL_036b: Expected O, but got I
			//IL_037b: Expected O, but got I
			//IL_038b: Expected O, but got I
			object obj = obj;
			List<ProductDescription> list = new List<ProductDescription>();
			List<ProductDescription> products = list;
			IEnumerator<ProductDefinition> enumerator = productDefinitions.GetEnumerator();
			_ = 0;
			object obj2 = default(object);
			ProductCatalogItem productCatalogItem = (ProductCatalogItem)obj2;
			ProductMetadata productMetadata = (ProductMetadata)4294967295L;
			ReadOnlyCollection<ProductDefinition> readOnlyCollection = productDefinitions;
			int num2 = default(int);
			object obj4;
			object obj6 = default(object);
			decimal num4 = default(decimal);
			ProductMetadata productMetadata3;
			ProductCatalogItem productCatalogItem3 = default(ProductCatalogItem);
			int num5 = default(int);
			ProductMetadata productMetadata6 = default(ProductMetadata);
			object obj8 = default(object);
			string text2 = default(string);
			string text4 = default(string);
			decimal num6 = default(decimal);
			ReadOnlyCollection<ProductDefinition> readOnlyCollection4 = default(ReadOnlyCollection<ProductDefinition>);
			object obj11 = default(object);
			ProductMetadata productMetadata12 = default(ProductMetadata);
			while (true)
			{
				object obj3;
				ProductMetadata productMetadata2;
				ProductCatalogItem productCatalogItem2;
				int num;
				object obj5;
				decimal num3;
				ReadOnlyCollection<ProductDefinition> readOnlyCollection2;
				if (!enumerator.MoveNext())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-68]");
					obj3 = 0;
					productMetadata2 = (ProductMetadata)((long)(IntPtr)productMetadata + 1L);
					_ = 338;
					if (enumerator == null)
					{
						productCatalogItem2 = productCatalogItem;
						num = num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-68]");
						obj4 = 0;
						obj5 = obj6;
						num3 = num4;
						productMetadata3 = productMetadata2;
						readOnlyCollection2 = readOnlyCollection;
						break;
					}
					goto IL_0a4f;
				}
				ProductDefinition current = enumerator.Current;
				if (!(unavailableProductId != current.id))
				{
					continue;
				}
				string title = "Fake title for " + current.id;
				_ = 0;
				_ = 0;
				object obj7 = (long)(IntPtr)obj - 96L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EA3E34 (inside System.DateTimeParse+MatchNumberDelegate::EndInvoke +0x340)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-60]");
				ProductMetadata productMetadata4 = new ProductMetadata("$0.01", title, "Fake description", "USD", 0m);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-60]");
				num4 = 0m;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-58]");
				obj6 = 0;
				ProductCatalog productCatalog = ProductCatalog.LoadDefaultCatalog();
				ProductMetadata productMetadata5;
				ReadOnlyCollection<ProductDefinition> readOnlyCollection3;
				IEnumerator<ProductCatalogItem> enumerator2;
				string text5;
				ProductCatalogItem productCatalogItem4;
				ProductCatalogItem current2;
				string text7;
				TypeLoadException ex3;
				if (productCatalog != null)
				{
					string text;
					string text3;
					if (productCatalog.products == null)
					{
						NullReferenceException ex = new NullReferenceException();
						productCatalogItem = productCatalogItem3;
						num2 = num5;
						productMetadata5 = productMetadata6;
						obj6 = obj8;
						text = text2;
						text3 = text4;
						num4 = num6;
						readOnlyCollection3 = readOnlyCollection4;
						goto IL_06b0;
					}
					enumerator2 = ((IEnumerable<ProductCatalogItem>)productCatalog.products).GetEnumerator();
					ProductMetadata productMetadata7 = productMetadata4;
					num2 = 0;
					productMetadata5 = productMetadata4;
					text = "USD";
					text3 = "Fake description";
					readOnlyCollection3 = null;
					text5 = null;
					productCatalogItem4 = null;
					while (enumerator2 != null)
					{
						if (!enumerator2.MoveNext())
						{
							goto IL_03ca;
						}
						current2 = enumerator2.Current;
						if (current2 == null)
						{
							goto IL_0424;
						}
						text5 = current.id;
						bool flag = current2.id == current.id;
						bool flag2 = !flag;
						readOnlyCollection3 = null;
						productCatalogItem4 = null;
						if (flag2)
						{
							continue;
						}
						if (current2.googlePrice == null)
						{
							goto IL_044c;
						}
						object obj9 = (long)(IntPtr)current2.googlePrice + 16L;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EA4608 (inside System.Decimal::FCallDivide +0x140)");
						LocalizedProductDescription defaultDescription = current2.defaultDescription;
						if (current2.defaultDescription == null)
						{
							goto IL_046f;
						}
						string text6 = LocalizedProductDescription.DecodeNonLatinCharacters(defaultDescription.title);
						LocalizedProductDescription defaultDescription2 = current2.defaultDescription;
						if (current2.defaultDescription == null)
						{
							goto IL_049f;
						}
						text7 = LocalizedProductDescription.DecodeNonLatinCharacters(defaultDescription2.description);
						Price googlePrice = current2.googlePrice;
						if (current2.googlePrice != null)
						{
							_ = googlePrice.value;
							_ = googlePrice.value.lo;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-88]");
							IntPtr intPtr = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-80]");
							IntPtr intPtr2 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-90]");
							ProductMetadata productMetadata8 = new ProductMetadata((string)(long)intPtr, (string)(long)intPtr2, text7, "USD", 0m);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-88]");
							text5 = (string)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-98]");
							obj6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-90]");
							num4 = 0m;
							productMetadata7 = productMetadata8;
							num2 = 0;
							productMetadata5 = (ProductMetadata)(object)text7;
							text = "USD";
							text3 = text7;
							readOnlyCollection3 = null;
							productCatalogItem4 = null;
							continue;
						}
						goto IL_04cf;
					}
					NullReferenceException ex2 = new NullReferenceException();
					productCatalogItem = productCatalogItem4;
					ex3 = (TypeLoadException)(object)ex2;
					goto IL_09f0;
				}
				num2 = 0;
				ProductMetadata productMetadata9 = productMetadata;
				readOnlyCollection3 = readOnlyCollection;
				productCatalogItem4 = productCatalogItem;
				goto IL_0925;
				IL_03ca:
				ProductMetadata productMetadata10 = (ProductMetadata)1;
				_ = 286;
				enumerator2?.Dispose();
				object obj10 = 1 + 1;
				if (obj10 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1069 @ X19_v13 (UnityEngine.Purchasing.ProductCatalogItem)+v1294 @ X25_v22 (UnityEngine.Purchasing.ProductMetadata)*4]");
					if ((IntPtr)0 == (IntPtr)286)
					{
						ProductMetadata productMetadata11 = (ProductMetadata)(1 + 4294967294L);
						productMetadata9 = productMetadata11;
						goto IL_0925;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-68]");
				bool flag3 = (IntPtr)0 == (IntPtr)0;
				bool flag4 = !flag3;
				productCatalogItem = productCatalogItem4;
				productMetadata5 = (ProductMetadata)1;
				if (flag4)
				{
					goto IL_06b0;
				}
				_ = 0;
				productMetadata9 = (ProductMetadata)1;
				goto IL_0925;
				IL_06b0:
				ex3 = new TypeLoadException();
				text5 = null;
				goto IL_09f0;
				IL_0a4f:
				enumerator.Dispose();
				productCatalogItem2 = productCatalogItem;
				num = num2;
				obj4 = obj3;
				obj5 = obj6;
				num3 = num4;
				productMetadata3 = productMetadata2;
				readOnlyCollection2 = readOnlyCollection;
				break;
				IL_09f0:
				if ((IntPtr)text5 == (IntPtr)1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
					obj3 = obj11;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
					bool flag5 = enumerator == null;
					productMetadata2 = productMetadata5;
					readOnlyCollection = readOnlyCollection3;
					productCatalogItem2 = productCatalogItem;
					num = num2;
					obj4 = obj11;
					obj5 = obj6;
					num3 = num4;
					productMetadata3 = productMetadata5;
					readOnlyCollection2 = readOnlyCollection3;
					if (flag5)
					{
						break;
					}
					goto IL_0a4f;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
				return;
				IL_0925:
				string storeSpecificId = current.storeSpecificId;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-78]");
				ProductDescription item = new ProductDescription(storeSpecificId, (ProductMetadata)0);
				products.Add(item);
				productCatalogItem = productCatalogItem4;
				productMetadata = productMetadata9;
				readOnlyCollection = readOnlyCollection3;
				continue;
				IL_04cf:
				NullReferenceException ex4 = new NullReferenceException();
				productCatalogItem = current2;
				productMetadata5 = (ProductMetadata)(object)text7;
				readOnlyCollection3 = null;
				text5 = null;
				ex3 = (TypeLoadException)(object)ex4;
				goto IL_09f0;
				IL_049f:
				NullReferenceException ex5 = new NullReferenceException();
				productCatalogItem = current2;
				productMetadata5 = productMetadata12;
				readOnlyCollection3 = null;
				text5 = null;
				ex3 = (TypeLoadException)(object)ex5;
				goto IL_09f0;
				IL_046f:
				NullReferenceException ex6 = new NullReferenceException();
				productCatalogItem = current2;
				productMetadata5 = productMetadata12;
				readOnlyCollection3 = null;
				text5 = null;
				ex3 = (TypeLoadException)(object)ex6;
				goto IL_09f0;
				IL_044c:
				NullReferenceException ex7 = new NullReferenceException();
				productCatalogItem = current2;
				readOnlyCollection3 = null;
				ex3 = (TypeLoadException)(object)ex7;
				goto IL_09f0;
				IL_0424:
				NullReferenceException ex8 = new NullReferenceException();
				productCatalogItem = current2;
				readOnlyCollection3 = null;
				text5 = null;
				ex3 = (TypeLoadException)(object)ex8;
				goto IL_09f0;
			}
			object obj12 = (long)(IntPtr)productMetadata3 + 1L;
			if (obj12 != null)
			{
				if (obj4 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X27_v5 (UnityEngine.Purchasing.ProductCatalogItem)+v132 @ X25_v5 (UnityEngine.Purchasing.ProductMetadata)*4]");
					if ((IntPtr)0 != (IntPtr)338)
					{
						goto IL_0795;
					}
				}
			}
			else if (obj4 != null)
			{
				goto IL_0795;
			}
			Action<bool, InitializationFailureReason> action = delegate(bool allow, InitializationFailureReason failureReason)
			{
				//IL_00ee: Expected I, but got O
				//IL_0037: Expected I, but got O
				//IL_02cc: Expected O, but got I
				//IL_0129: Expected O, but got I
				//IL_0072: Expected O, but got I
				//IL_0202: Unknown result type (might be due to invalid IL or missing references)
				//IL_0207: Expected O, but got Unknown
				//IL_0224: Expected O, but got I
				//IL_0233: Expected O, but got I
				//IL_0175: Expected O, but got I
				//IL_01f8: Expected O, but got I
				//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
				//IL_01ab: Expected O, but got Unknown
				//IL_01c8: Expected O, but got I
				//IL_01d7: Expected O, but got I
				//IL_00be: Expected O, but got I
				FakeStore fakeStore = this;
				IStoreCallback biller = fakeStore.m_Biller;
				if (allow)
				{
					IntPtr intPtr4 = (IntPtr)biller;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ X8_v8 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_00d7;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ X8_v8 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+B0]");
					object obj15 = 0L + 8L;
					int num8 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ X11_v12-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IStoreCallback))
						{
							break;
						}
						num8++;
						int num9 = num8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ X8_v8 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]");
						bool flag6 = (long)num9 < 0L;
						bool flag7 = !flag6;
						obj15 = (long)(IntPtr)obj15 + 16L;
						if (!flag7)
						{
							continue;
						}
						goto IL_00d7;
					}
					object obj16 = obj15 + 2;
					int num10 = (int)((long)(IntPtr)obj16 << 4);
					object obj17 = (long)intPtr4 + (long)num10;
					object obj18 = (long)(IntPtr)obj17 + 304L;
					goto IL_0271;
				}
				IntPtr intPtr5 = (IntPtr)biller;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ X8_v5 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_018e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ X8_v5 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+B0]");
				object obj19 = 0L + 8L;
				int num11 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ X11_v6-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IStoreCallback))
					{
						break;
					}
					num11++;
					int num12 = num11;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ X8_v5 (Il2CppClass<UnityEngine.Purchasing.Extension.IStoreCallback>)+126]");
					bool flag8 = (long)num12 < 0L;
					bool flag9 = !flag8;
					obj19 = (long)(IntPtr)obj19 + 16L;
					if (!flag9)
					{
						continue;
					}
					goto IL_018e;
				}
				object obj20 = obj19 + 1;
				int num13 = (int)((long)(IntPtr)obj20 << 4);
				object obj21 = (long)intPtr5 + (long)num13;
				object obj22 = (long)(IntPtr)obj21 + 304L;
				goto IL_02b4;
				IL_018e:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_02b4;
				IL_0271:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v292 @ X0_v10] (should have been resolved before IL gen)");
				JSONStore jSONStore = this;
				FakeStore purchaser = this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ X19_v5 (UnityEngine.Purchasing.JSONStore)+A8]");
				Promo.ProvideProductsToAds(purchaser, (IStoreCallback)0);
				return;
				IL_02b4:
				object obj23 = obj22;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ X0_v5+8]");
				object obj24 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v123 @ X3_v1 (should have been resolved before IL gen)");
				return;
				IL_00d7:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0271;
			};
			if (UIMode == FakeStoreUIMode.DeveloperUser)
			{
				IntPtr intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v991 @ X1_v13 (Il2CppMethodInfo)+48]");
				int num7 = 0;
				object obj13 = this + num7;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v997 @ X0_v22 (System.Action`2<System.Boolean, UnityEngine.Purchasing.InitializationFailureReason>)] (should have been resolved before IL gen)");
				object obj14 = default(object);
				if ((uint)((ulong)(long)(IntPtr)obj14 & 1uL) != 0)
				{
					return;
				}
			}
			action(arg1: true, InitializationFailureReason.AppNotKnown);
			return;
			IL_0795:
			throw new TypeLoadException();
		}

		[Token(Token = "0x6000242")]
		[Address(RVA = "0xC60434", Offset = "0xC60434", Length = "0x29C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv32 = *([1EDEB60]);\n\tv33 = *([v32 @ X8_v33]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, productJSON, developerPayload, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([202332F]) = v51;\nL_001D:\n\tv55 = UnityEngine.Purchasing.MiniJson::JsonDecode(productJSON);\n\tgoto L_FFFFFFFF;\n\tv100 = v100_asT == 0;\n\tif (v100) goto L_00E8;\n\tv195 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v55, \"id\", &v87 @ stack_-58_v5 (System.Object));\n\tv237 = System.Object::ToString(v87);\n\tv240 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v55, \"storeSpecificId\", &v87 @ stack_-58_v5 (System.Object));\n\tv300 = System.Object::ToString(v87);\n\tv303 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v55, \"type\", &v87 @ stack_-58_v5 (System.Object));\n\tv307 = System.Object::ToString(v87);\n\tgoto L_0082;\n\tv315 = *([v310 @ X8_v19+E0]);\n\tv316 = v315 == 0;\n\tv317 = ~v316;\n\tif (v317) goto L_0082;\n\tv325 = v310;\n\tv320 = \"il2cpp_codegen_runtime_class_init\"(v325, v306, v93, v85, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_0082:\n\tv324 = System.Type::GetTypeFromHandle(UnityEngine.Purchasing.ProductType);\n\tgoto L_0094;\n\tv332 = *([v328 @ X8_v20+E0]);\n\tv333 = v332 == 0;\n\tv334 = ~v333;\n\tif (v334) goto L_0094;\n\tv343 = v328;\n\tv337 = \"il2cpp_codegen_runtime_class_init\"(v343, v323, v93, v85, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_0094:\n\tv342 = System.Enum::IsDefined(v324, v307);\n\tv345 = v342 == 0;\n\tif (v345) goto L_FFFFFFFF;\n\tgoto L_00A5;\n\tv352 = *([v346 @ X0_v33+E0]);\n\tv353 = v352 == 0;\n\tv354 = ~v353;\n\tif (v354) goto L_00A5;\n\tv356 = \"il2cpp_codegen_runtime_class_init\"(v346, v340, v341, v85, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_00A5:\n\tv361 = System.Type::GetTypeFromHandle(UnityEngine.Purchasing.ProductType);\n\tgoto L_00B5;\n\tv378 = *([v155 @ X8_v26+E0]);\n\tv379 = v378 == 0;\n\tv380 = ~v379;\n\tif (v380) goto L_00B5;\n\tv385 = v155;\n\tv382 = \"il2cpp_codegen_runtime_class_init\"(v385, v360, v341, v85, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_00B5:\n\tv143 = System.Enum::Parse(v361, v307);\n\tv205 = v205_asT == 0;\n\tif (v205) goto L_00E9;\n\tv368 = \"il2cpp_vm_object_unbox\"(v143, UnityEngine.Purchasing.ProductType, 0, Il2CppMethodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv365 = *([v368 @ X0_v40]);\n\tgoto L_00D0;\nL_00D0:\n\tv372 = new UnityEngine.Purchasing.ProductDefinition();\n\tUnityEngine.Purchasing.ProductDefinition::.ctor(v372, v237, v300, v365);\n\tUnityEngine.Purchasing.FakeStore::FakePurchase(this, v372, v300);\n\treturn;\n\tthrow System.NullReferenceException;\nL_00E8:\n\tv191 = new System.InvalidCastException();\nL_00E9:\n\tthrow System.InvalidCastException;\n// 174 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Purchase(string productJSON, string developerPayload)
		{
			//IL_012d: Expected I4, but got O
			//IL_015c: Expected I4, but got O
			object obj = MiniJson.JsonDecode(productJSON);
			Dictionary<string, object> dictionary = obj as Dictionary<string, object>;
			if (dictionary != null)
			{
				bool flag = ((Dictionary<string, object>)obj).TryGetValue("id", out object value);
				string id = value.ToString();
				bool flag2 = ((Dictionary<string, object>)obj).TryGetValue("storeSpecificId", out value);
				string text = value.ToString();
				bool flag3 = ((Dictionary<string, object>)obj).TryGetValue("type", out value);
				string value2 = value.ToString();
				Type typeFromHandle = typeof(ProductType);
				ProductType type;
				if (Enum.IsDefined(typeFromHandle, value2))
				{
					Type typeFromHandle2 = typeof(ProductType);
					object obj2 = Enum.Parse(typeFromHandle2, value2);
					if ((int)((obj2 is ProductType) ? obj2 : null) == 0)
					{
						goto IL_017f;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					object obj3 = default(object);
					type = (ProductType)obj3;
				}
				else
				{
					type = default(ProductType);
				}
				ProductDefinition product = new ProductDefinition(id, text, type);
				FakePurchase(product, text);
				return;
			}
			InvalidCastException ex = new InvalidCastException();
			goto IL_017f;
			IL_017f:
			throw new InvalidCastException();
		}

		[Token(Token = "0x6000243")]
		[Address(RVA = "0xC606D0", Offset = "0xC606D0", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1F0F7E8]);\n\tv23 = *([v22 @ X8_v40]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, product, developerPayload, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023330]) = v41;\nL_0018:\n\tv45 = new UnityEngine.Purchasing.FakeStore+<>c__DisplayClass15_0();\n\tSystem.Object::.ctor(v45);\n\tv45.<>4__this = this;\n\tv45.product = product;\n\tthis.purchaseCalled = 1;\n\tv50 = v45.product;\n\tv80 = v50.<type>k__BackingField == 0;\n\tif (v80) goto L_0033;\n\tSystem.Collections.Generic.List`1<System.String>::Add(this.m_PurchasedProducts, v50.<storeSpecificId>k__BackingField);\nL_0033:\n\tv108 = new System.Action`2<System.Boolean, UnityEngine.Purchasing.PurchaseFailureReason>();\n\tSystem.Action`2<System.Boolean, UnityEngine.Purchasing.PurchaseFailureReason>::.ctor(v108, v45, Il2CppMethodInfo);\n\tv162 = Il2CppMethodInfo;\n\tv56 = *([v162 @ X1_v7 (Il2CppMethodInfo)+48]) << 4;\n\tv165 = *([this @ X0 (UnityEngine.Purchasing.FakeStore)]) + v56;\n\tv167 = System.Action`2<System.Boolean, UnityEngine.Purchasing.PurchaseFailureReason>::.ctor(*([v165 @ X8_v18+138]), Il2CppMethodInfo, Il2CppMethodInfo);\n\t*([v167 @ X0_v14 (System.Action`2<System.Boolean, UnityEngine.Purchasing.PurchaseFailureReason>)])(v193, this, v45.product, 0, v108, v167, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv213 = v193 & 1;\n\tv196 = v213 == 0;\n\tif (v196) goto L_0062;\n\treturn;\nL_0062:\n\tgoto L_006A;\n\tv223 = *([v216 @ X0_v17+E0]);\n\tv224 = v223 == 0;\n\tv225 = ~v224;\n\tif (v225) goto L_006A;\n\tv227 = \"il2cpp_codegen_runtime_class_init\"(v216, v190, v185, v58, v53, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_006A:\n\tv232 = System.Type::GetTypeFromHandle(UnityEngine.Purchasing.PurchaseFailureReason);\n\tgoto L_007E;\n\tv239 = *([v235 @ X8_v27+E0]);\n\tv240 = v239 == 0;\n\tv241 = ~v240;\n\tif (v241) goto L_007E;\n\tv247 = v235;\n\tv243 = \"il2cpp_codegen_runtime_class_init\"(v247, v231, v185, v58, v53, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_007E:\n\tv67 = System.Enum::Parse(v232, \"Unknown\");\n\tv111 = v111_asT == 0;\n\tif (v111) goto L_00A5;\n\tv252 = \"il2cpp_vm_object_unbox\"(v67, UnityEngine.Purchasing.PurchaseFailureReason, 0, v108, v167, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tSystem.Action`2<System.Boolean, UnityEngine.Purchasing.PurchaseFailureReason>::Invoke(v108, 1, *([v252 @ X0_v24]));\n\treturn;\n\tv96 = new System.NullReferenceException();\nL_00A5:\n\tthrow System.InvalidCastException;\n// 119 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void FakePurchase(ProductDefinition product, string developerPayload)
		{
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Expected O, but got Unknown
			//IL_0126: Expected I4, but got O
			//IL_015f: Expected I4, but got O
			_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass15_0();
			CS_0024_003C_003E8__locals8._003C_003E4__this = this;
			CS_0024_003C_003E8__locals8.product = product;
			purchaseCalled = true;
			ProductDefinition productDefinition = CS_0024_003C_003E8__locals8.product;
			if (productDefinition.type != ProductType.Consumable)
			{
				m_PurchasedProducts.Add(productDefinition.storeSpecificId);
			}
			Action<bool, PurchaseFailureReason> action = delegate(bool allow, PurchaseFailureReason failureReason)
			{
				//IL_008f: Expected I4, but got O
				if (allow)
				{
					ProductDefinition productDefinition2 = CS_0024_003C_003E8__locals8.product;
					Guid guid = Guid.NewGuid();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @C12510 (inside System.Guid::StringToLong +0x320)");
					string transactionID = default(string);
					CS_0024_003C_003E8__locals8._003C_003E4__this.OnPurchaseSucceeded(productDefinition2.storeSpecificId, "{ \"this\" : \"is a fake receipt\" }", transactionID);
				}
				else
				{
					Type typeFromHandle2 = typeof(PurchaseFailureReason);
					object obj5 = Enum.Parse(typeFromHandle2, "Unknown");
					if ((int)((obj5 is PurchaseFailureReason) ? obj5 : null) == 0)
					{
						throw new InvalidCastException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					ProductDefinition productDefinition3 = CS_0024_003C_003E8__locals8.product;
					PurchaseFailureReason reason = (((IntPtr)CS_0024_003C_003E8__locals8 != (IntPtr)(void*)(int)failureReason) ? failureReason : PurchaseFailureReason.UserCancelled);
					PurchaseFailureDescription failure = new PurchaseFailureDescription(productDefinition3.storeSpecificId, reason, "failed a fake store purchase");
					CS_0024_003C_003E8__locals8._003C_003E4__this.OnPurchaseFailed(failure);
				}
			};
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ X1_v7 (Il2CppMethodInfo)+48]");
			int num = 0;
			object obj = this + num;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v167 @ X0_v14 (System.Action`2<System.Boolean, UnityEngine.Purchasing.PurchaseFailureReason>)] (should have been resolved before IL gen)");
			object obj2 = default(object);
			if ((int)((long)(IntPtr)obj2 & 1L) == 0)
			{
				Type typeFromHandle = typeof(PurchaseFailureReason);
				object obj3 = Enum.Parse(typeFromHandle, "Unknown");
				if ((int)((obj3 is PurchaseFailureReason) ? obj3 : null) == 0)
				{
					throw new InvalidCastException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				object obj4 = default(object);
				action(arg1: true, (PurchaseFailureReason)obj4);
			}
		}

		[Token(Token = "0x6000244")]
		[Address(RVA = "0xC608D0", Offset = "0xC608D0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void FinishTransaction(string productJSON, string transactionID)
		{
		}

		[Token(Token = "0x6000245")]
		[Address(RVA = "0xC608D4", Offset = "0xC608D4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void FinishTransaction(ProductDefinition product, string transactionId)
		{
		}

		[Token(Token = "0x6000246")]
		[Address(RVA = "0xD6C5D4", Offset = "0xD6C5D4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual bool StartUI<T>(object model, DialogType dialogType, Action<bool, T> callback)
		{
			return false;
		}

		[Token(Token = "0x6000247")]
		[Address(RVA = "0xC608D8", Offset = "0xC608D8", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EBFF68]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023331]) = v38;\nL_0016:\n\tv42 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v42);\n\tthis.m_PurchasedProducts = v42;\n\tthis.UIMode = 0;\n\tUnityEngine.Purchasing.JSONStore::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FakeStore()
		{
			List<string> purchasedProducts = new List<string>();
			m_PurchasedProducts = purchasedProducts;
			UIMode = default(FakeStoreUIMode);
		}
	}
}
