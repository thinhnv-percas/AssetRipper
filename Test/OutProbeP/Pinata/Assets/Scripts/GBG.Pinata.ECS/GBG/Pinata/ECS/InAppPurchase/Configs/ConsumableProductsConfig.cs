using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace GBG.Pinata.ECS.InAppPurchase.Configs
{
	[CreateAssetMenu]
	[Token(Token = "0x2000056")]
	public class ConsumableProductsConfig : ScriptableObject, ISerializationCallbackReceiver
	{
		[SerializeField]
		[Token(Token = "0x40000EC")]
		[FieldOffset(Offset = "0x18")]
		private List<ConsumableProduct> products;

		[Token(Token = "0x40000ED")]
		[FieldOffset(Offset = "0x20")]
		public Dictionary<string, ProductReward> productsDictionary;

		[Token(Token = "0x60000B3")]
		[Address(RVA = "0xCBF1D0", Offset = "0xCBF1D0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void OnBeforeSerialize()
		{
		}

		[Token(Token = "0x60000B4")]
		[Address(RVA = "0xCBF1D4", Offset = "0xCBF1D4", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1ECE370]);\n\tv21 = *([v20 @ X8_v20]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202371D]) = v40;\nL_001B:\n\tv48 = new System.Collections.Generic.Dictionary`2<System.String, GBG.Pinata.ECS.InAppPurchase.Configs.ProductReward>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, GBG.Pinata.ECS.InAppPurchase.Configs.ProductReward>::.ctor(v48);\n\tthis.productsDictionary = v48;\n\tv54 = this.products == 0;\n\tif (v54) goto L_004A;\n\tv60 = System.Collections.Generic.List`1<GBG.Pinata.ECS.InAppPurchase.Configs.ConsumableProduct>::GetEnumerator(this.products);\nL_0036:\n\tv105 = System.Collections.Generic.List`1<GBG.Pinata.ECS.InAppPurchase.Configs.ConsumableProduct>+Enumerator<GBG.Pinata.ECS.InAppPurchase.Configs.ConsumableProduct>::MoveNext(&v59 @ stack_-88_v3 (System.Collections.Generic.List`1<GBG.Pinata.ECS.InAppPurchase.Configs.ConsumableProduct>+Enumerator<GBG.Pinata.ECS.InAppPurchase.Configs.ConsumableProduct>));\n\tv117 = v105 == 0;\n\tif (v117) goto L_0047;\n\tSystem.Collections.Generic.Dictionary`2<System.String, GBG.Pinata.ECS.InAppPurchase.Configs.ProductReward>::Add(this.productsDictionary, v93, v140);\n\tgoto L_0036;\nL_0047:\n\tv124 = System.Collections.Generic.List`1<GBG.Pinata.ECS.InAppPurchase.Configs.ConsumableProduct>+Enumerator<GBG.Pinata.ECS.InAppPurchase.Configs.ConsumableProduct>::Dispose(&v59 @ stack_-88_v3 (System.Collections.Generic.List`1<GBG.Pinata.ECS.InAppPurchase.Configs.ConsumableProduct>+Enumerator<GBG.Pinata.ECS.InAppPurchase.Configs.ConsumableProduct>));\n\tgoto L_0069;\n\tv84 = new System.NullReferenceException();\nL_004A:\n\tv91 = new System.NullReferenceException();\n\tgoto L_0056;\n\tgoto L_0056;\nL_0056:\n\tv115 = Il2CppMethodInfo != 1;\n\tif (v115) goto L_006A;\n\tv118 = System.Collections.Generic.List`1<GBG.Pinata.ECS.InAppPurchase.Configs.ConsumableProduct>+Enumerator<GBG.Pinata.ECS.InAppPurchase.Configs.ConsumableProduct>::MoveNext(v91);\n\tv126 = System.Collections.Generic.List`1<GBG.Pinata.ECS.InAppPurchase.Configs.ConsumableProduct>+Enumerator<GBG.Pinata.ECS.InAppPurchase.Configs.ConsumableProduct>::MoveNext(v118);\n\tv130 = System.Collections.Generic.List`1<GBG.Pinata.ECS.InAppPurchase.Configs.ConsumableProduct>+Enumerator<GBG.Pinata.ECS.InAppPurchase.Configs.ConsumableProduct>::Dispose(&v71 @ stack_-60_v3 (System.Collections.Generic.List`1<GBG.Pinata.ECS.InAppPurchase.Configs.ConsumableProduct>+Enumerator<GBG.Pinata.ECS.InAppPurchase.Configs.ConsumableProduct>));\n\tv182 = ~v118.m_value;\n\tv132 = ~v182;\n\tif (v132) goto L_006E;\nL_0069:\n\treturn;\nL_006A:\n\tv119 = System.Collections.Generic.List`1<GBG.Pinata.ECS.InAppPurchase.Configs.ConsumableProduct>+Enumerator<GBG.Pinata.ECS.InAppPurchase.Configs.ConsumableProduct>::MoveNext(v91);\nL_006E:\n\tthrow System.TypeLoadException;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void OnAfterDeserialize()
		{
			Dictionary<string, ProductReward> dictionary = new Dictionary<string, ProductReward>();
			productsDictionary = dictionary;
			bool flag = products == null;
			List<ConsumableProduct>.Enumerator enumerator2 = default(List<ConsumableProduct>.Enumerator);
			List<ConsumableProduct>.Enumerator enumerator = enumerator2;
			if (!flag)
			{
				List<ConsumableProduct>.Enumerator enumerator3 = products.GetEnumerator();
				string key = default(string);
				ProductReward value = default(ProductReward);
				while (enumerator2.MoveNext())
				{
					productsDictionary.Add(key, value);
				}
				enumerator2.Dispose();
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			if ((IntPtr)0 == (IntPtr)1)
			{
				bool flag2 = ((List<ConsumableProduct>.Enumerator*)ex)->MoveNext();
				bool flag3 = (flag2 ? ((List<ConsumableProduct>.Enumerator*)1) : ((List<ConsumableProduct>.Enumerator*)null))->MoveNext();
				enumerator.Dispose();
				if (!((bool*)(flag2 ? 1 : 0))->m_value)
				{
					return;
				}
			}
			else
			{
				bool flag4 = ((List<ConsumableProduct>.Enumerator*)ex)->MoveNext();
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000B5")]
		[Address(RVA = "0xCBF338", Offset = "0xCBF338", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EA41E0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202371E]) = v38;\nL_0016:\n\tv42 = new System.Collections.Generic.List`1<GBG.Pinata.ECS.InAppPurchase.Configs.ConsumableProduct>();\n\tSystem.Collections.Generic.List`1<GBG.Pinata.ECS.InAppPurchase.Configs.ConsumableProduct>::.ctor(v42);\n\tthis.products = v42;\n\tv50 = new System.Collections.Generic.Dictionary`2<System.String, GBG.Pinata.ECS.InAppPurchase.Configs.ProductReward>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, GBG.Pinata.ECS.InAppPurchase.Configs.ProductReward>::.ctor(v50);\n\tthis.productsDictionary = v50;\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ConsumableProductsConfig()
		{
			List<ConsumableProduct> list = new List<ConsumableProduct>();
			products = list;
			Dictionary<string, ProductReward> dictionary = new Dictionary<string, ProductReward>();
			productsDictionary = dictionary;
		}
	}
}
