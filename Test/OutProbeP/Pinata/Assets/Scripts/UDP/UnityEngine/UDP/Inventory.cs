using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.UDP
{
	[Token(Token = "0x200000B")]
	public class Inventory
	{
		[Token(Token = "0x400002B")]
		[FieldOffset(Offset = "0x10")]
		private readonly Dictionary<string, PurchaseInfo> _purchaseDictionary;

		[Token(Token = "0x400002C")]
		[FieldOffset(Offset = "0x18")]
		private readonly Dictionary<string, ProductInfo> _productDictionary;

		[Token(Token = "0x6000028")]
		[Address(RVA = "0x15C90D4", Offset = "0x15C90D4", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EFDE68]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, productId, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20299C5]) = v41;\nL_0018:\n\tv45 = new UnityEngine.UDP.PurchaseInfo();\n\tSystem.Object::.ctor(v45);\n\tv57 = System.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.PurchaseInfo>::TryGetValue(this._purchaseDictionary, productId, &v54 @ stack_-28_v2 (UnityEngine.UDP.PurchaseInfo));\n\tv66 = v57 == 0;\n\tv69 = ~v66;\n\tv70 = ~v69;\n\tif (v70) goto L_FFFFFFFF;\n\tgoto L_0039;\nL_0039:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PurchaseInfo GetPurchaseInfo(string productId)
		{
			PurchaseInfo purchaseInfo = new PurchaseInfo();
			if (_purchaseDictionary.TryGetValue(productId, out var value))
			{
				return value;
			}
			return null;
		}

		[Token(Token = "0x6000029")]
		[Address(RVA = "0x15C9178", Offset = "0x15C9178", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EDF620]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, productId, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20299C6]) = v41;\nL_001E:\n\tv51 = System.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.ProductInfo>::TryGetValue(this._productDictionary, productId, &v48 @ stack_-28_v2 (UnityEngine.UDP.ProductInfo));\n\tv60 = v51 == 0;\n\tv63 = ~v60;\n\tv64 = ~v63;\n\tif (v64) goto L_FFFFFFFF;\n\tgoto L_0032;\nL_0032:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ProductInfo GetProductInfo(string productId)
		{
			if (_productDictionary.TryGetValue(productId, out var value))
			{
				return value;
			}
			return null;
		}

		[Token(Token = "0x600002A")]
		[Address(RVA = "0x15C91F8", Offset = "0x15C91F8", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv22 = *([1EDF090]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, productId, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20299C7]) = v41;\nL_0022:\n\treturnVal1 = System.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.PurchaseInfo>::ContainsKey(this._purchaseDictionary, productId);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool HasPurchase(string productId)
		{
			return _purchaseDictionary.ContainsKey(productId);
		}

		[Token(Token = "0x600002B")]
		[Address(RVA = "0x15C9260", Offset = "0x15C9260", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1ED5238]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20299C8]) = v38;\nL_0017:\n\tv43 = new System.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.PurchaseInfo>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.PurchaseInfo>::.ctor(v43, this._purchaseDictionary);\n\treturn v43;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IDictionary<string, PurchaseInfo> GetPurchaseDictionary()
		{
			//IL_0010: Expected I4, but got O
			return new Dictionary<string, PurchaseInfo>((int)_purchaseDictionary);
		}

		[Token(Token = "0x600002C")]
		[Address(RVA = "0x15C92D0", Offset = "0x15C92D0", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EC5B58]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20299C9]) = v40;\nL_0019:\n\tv46 = 0;\n\tv48 = new System.Collections.Generic.List`1<UnityEngine.UDP.ProductInfo>();\n\tSystem.Collections.Generic.List`1<UnityEngine.UDP.ProductInfo>::.ctor(v48);\n\tv54 = this._productDictionary == 0;\n\tif (v54) goto L_0042;\n\tv59 = System.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.ProductInfo>::GetEnumerator(this._productDictionary);\nL_002F:\n\tv83 = System.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.ProductInfo>+Enumerator<System.String, UnityEngine.UDP.ProductInfo>::MoveNext(&v46 @ stack_-58_v1 (System.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.ProductInfo>+Enumerator<System.String, UnityEngine.UDP.ProductInfo>));\n\tv95 = v83 == 0;\n\tif (v95) goto L_003E;\n\tSystem.Collections.Generic.List`1<UnityEngine.UDP.ProductInfo>::Add(v48, v118);\n\tgoto L_002F;\nL_003E:\n\tv102 = System.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.ProductInfo>+Enumerator<System.String, UnityEngine.UDP.ProductInfo>::Dispose(&v46 @ stack_-58_v1 (System.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.ProductInfo>+Enumerator<System.String, UnityEngine.UDP.ProductInfo>));\n\tgoto L_0062;\n\tv67 = new System.NullReferenceException();\nL_0042:\n\tv73 = new System.NullReferenceException();\n\tgoto L_004E;\n\tgoto L_004E;\nL_004E:\n\tv93 = Il2CppMethodInfo != 1;\n\tif (v93) goto L_0063;\n\tv96 = System.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.ProductInfo>+Enumerator<System.String, UnityEngine.UDP.ProductInfo>::MoveNext(v73);\n\tv104 = System.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.ProductInfo>+Enumerator<System.String, UnityEngine.UDP.ProductInfo>::MoveNext(v96);\n\tv108 = System.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.ProductInfo>+Enumerator<System.String, UnityEngine.UDP.ProductInfo>::Dispose(&v46 @ stack_-58_v1 (System.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.ProductInfo>+Enumerator<System.String, UnityEngine.UDP.ProductInfo>));\n\tv153 = ~v96.m_value;\n\tv110 = ~v153;\n\tif (v110) goto L_0067;\nL_0062:\n\treturn v48;\nL_0063:\n\tv97 = System.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.ProductInfo>+Enumerator<System.String, UnityEngine.UDP.ProductInfo>::MoveNext(v73);\nL_0067:\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe IList<ProductInfo> GetProductList()
		{
			Dictionary<string, ProductInfo>.Enumerator enumerator = default(Dictionary<string, ProductInfo>.Enumerator);
			List<ProductInfo> list = new List<ProductInfo>();
			if (_productDictionary != null)
			{
				Dictionary<string, ProductInfo>.Enumerator enumerator2 = _productDictionary.GetEnumerator();
				ProductInfo item = default(ProductInfo);
				while (enumerator.MoveNext())
				{
					list.Add(item);
				}
				enumerator.Dispose();
				goto IL_00b6;
			}
			NullReferenceException ex = new NullReferenceException();
			if ((IntPtr)0 == (IntPtr)1)
			{
				bool flag = ((Dictionary<string, ProductInfo>.Enumerator*)ex)->MoveNext();
				bool flag2 = (flag ? ((Dictionary<string, ProductInfo>.Enumerator*)1) : ((Dictionary<string, ProductInfo>.Enumerator*)null))->MoveNext();
				enumerator.Dispose();
				if (!((bool*)(flag ? 1 : 0))->m_value)
				{
					goto IL_00b6;
				}
			}
			else
			{
				bool flag3 = ((Dictionary<string, ProductInfo>.Enumerator*)ex)->MoveNext();
			}
			return (IList<ProductInfo>)new TypeLoadException();
			IL_00b6:
			return list;
		}

		[Token(Token = "0x600002D")]
		[Address(RVA = "0x15C9418", Offset = "0x15C9418", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EAF248]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20299CA]) = v40;\nL_0019:\n\tv46 = 0;\n\tv48 = new System.Collections.Generic.List`1<UnityEngine.UDP.PurchaseInfo>();\n\tSystem.Collections.Generic.List`1<UnityEngine.UDP.PurchaseInfo>::.ctor(v48);\n\tv54 = this._purchaseDictionary == 0;\n\tif (v54) goto L_0042;\n\tv59 = System.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.PurchaseInfo>::GetEnumerator(this._purchaseDictionary);\nL_002F:\n\tv83 = System.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.PurchaseInfo>+Enumerator<System.String, UnityEngine.UDP.PurchaseInfo>::MoveNext(&v46 @ stack_-58_v1 (System.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.PurchaseInfo>+Enumerator<System.String, UnityEngine.UDP.PurchaseInfo>));\n\tv95 = v83 == 0;\n\tif (v95) goto L_003E;\n\tSystem.Collections.Generic.List`1<UnityEngine.UDP.PurchaseInfo>::Add(v48, v118);\n\tgoto L_002F;\nL_003E:\n\tv102 = System.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.PurchaseInfo>+Enumerator<System.String, UnityEngine.UDP.PurchaseInfo>::Dispose(&v46 @ stack_-58_v1 (System.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.PurchaseInfo>+Enumerator<System.String, UnityEngine.UDP.PurchaseInfo>));\n\tgoto L_0062;\n\tv67 = new System.NullReferenceException();\nL_0042:\n\tv73 = new System.NullReferenceException();\n\tgoto L_004E;\n\tgoto L_004E;\nL_004E:\n\tv93 = Il2CppMethodInfo != 1;\n\tif (v93) goto L_0063;\n\tv96 = System.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.PurchaseInfo>+Enumerator<System.String, UnityEngine.UDP.PurchaseInfo>::MoveNext(v73);\n\tv104 = System.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.PurchaseInfo>+Enumerator<System.String, UnityEngine.UDP.PurchaseInfo>::MoveNext(v96);\n\tv108 = System.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.PurchaseInfo>+Enumerator<System.String, UnityEngine.UDP.PurchaseInfo>::Dispose(&v46 @ stack_-58_v1 (System.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.PurchaseInfo>+Enumerator<System.String, UnityEngine.UDP.PurchaseInfo>));\n\tv153 = ~v96.m_value;\n\tv110 = ~v153;\n\tif (v110) goto L_0067;\nL_0062:\n\treturn v48;\nL_0063:\n\tv97 = System.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.PurchaseInfo>+Enumerator<System.String, UnityEngine.UDP.PurchaseInfo>::MoveNext(v73);\nL_0067:\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe List<PurchaseInfo> GetPurchaseList()
		{
			Dictionary<string, PurchaseInfo>.Enumerator enumerator = default(Dictionary<string, PurchaseInfo>.Enumerator);
			List<PurchaseInfo> list = new List<PurchaseInfo>();
			if (_purchaseDictionary != null)
			{
				Dictionary<string, PurchaseInfo>.Enumerator enumerator2 = _purchaseDictionary.GetEnumerator();
				PurchaseInfo item = default(PurchaseInfo);
				while (enumerator.MoveNext())
				{
					list.Add(item);
				}
				enumerator.Dispose();
				goto IL_00b6;
			}
			NullReferenceException ex = new NullReferenceException();
			if ((IntPtr)0 == (IntPtr)1)
			{
				bool flag = ((Dictionary<string, PurchaseInfo>.Enumerator*)ex)->MoveNext();
				bool flag2 = (flag ? ((Dictionary<string, PurchaseInfo>.Enumerator*)1) : ((Dictionary<string, PurchaseInfo>.Enumerator*)null))->MoveNext();
				enumerator.Dispose();
				if (!((bool*)(flag ? 1 : 0))->m_value)
				{
					goto IL_00b6;
				}
			}
			else
			{
				bool flag3 = ((Dictionary<string, PurchaseInfo>.Enumerator*)ex)->MoveNext();
			}
			return (List<PurchaseInfo>)(object)new TypeLoadException();
			IL_00b6:
			return list;
		}

		[Token(Token = "0x600002E")]
		[Address(RVA = "0x15C9560", Offset = "0x15C9560", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv22 = *([1ED53B0]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, productInfo, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20299CB]) = v41;\nL_0025:\n\tSystem.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.ProductInfo>::Add(this._productDictionary, productInfo.<ProductId>k__BackingField, productInfo);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void AddProduct(ProductInfo productInfo)
		{
			_productDictionary.Add(productInfo.ProductId, productInfo);
		}

		[Token(Token = "0x600002F")]
		[Address(RVA = "0x15C95D4", Offset = "0x15C95D4", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv22 = *([1EBFC18]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, purchaseInfo, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20299CC]) = v41;\nL_0025:\n\tSystem.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.PurchaseInfo>::Add(this._purchaseDictionary, purchaseInfo.<ProductId>k__BackingField, purchaseInfo);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void AddPurchase(PurchaseInfo purchaseInfo)
		{
			_purchaseDictionary.Add(purchaseInfo.ProductId, purchaseInfo);
		}

		[Token(Token = "0x6000030")]
		[Address(RVA = "0x15C9648", Offset = "0x15C9648", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EBC2A0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20299CD]) = v38;\nL_0016:\n\tv42 = new System.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.PurchaseInfo>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.PurchaseInfo>::.ctor(v42);\n\tthis._purchaseDictionary = v42;\n\tv50 = new System.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.ProductInfo>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, UnityEngine.UDP.ProductInfo>::.ctor(v50);\n\tthis._productDictionary = v50;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Inventory()
		{
			Dictionary<string, PurchaseInfo> purchaseDictionary = new Dictionary<string, PurchaseInfo>();
			_purchaseDictionary = purchaseDictionary;
			Dictionary<string, ProductInfo> productDictionary = new Dictionary<string, ProductInfo>();
			_productDictionary = productDictionary;
		}
	}
}
