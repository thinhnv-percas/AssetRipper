using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile;
using GBG.Pinata.ECS.InAppPurchase.Configs;
using Morpeh;
using Morpeh.Globals;
using UnityEngine;

namespace GBG.Pinata.ECS.InAppPurchase.Systems
{
	[CreateAssetMenu]
	[Token(Token = "0x200004A")]
	public class PinataPurchasesSystem : UpdateSystem
	{
		[Token(Token = "0x40000D9")]
		[FieldOffset(Offset = "0x28")]
		public GlobalVariableInt coins;

		[Token(Token = "0x40000DA")]
		[FieldOffset(Offset = "0x30")]
		public GlobalVariableInt diamonds;

		[Token(Token = "0x40000DB")]
		[FieldOffset(Offset = "0x38")]
		public ConsumableProductsConfig config;

		[Token(Token = "0x6000088")]
		[Address(RVA = "0xCC1190", Offset = "0xCC1190", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EE6A38]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023743]) = v38;\nL_0016:\n\tv42 = new System.Action`1<EasyMobile.IAPProduct>();\n\tSystem.Action`1<EasyMobile.IAPProduct>::.ctor(v42, this, Il2CppMethodInfo);\n\tgoto L_0033;\n\tv57 = *([v53 @ X0_v4+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_0033;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v53, v47, v49, v50, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0033:\n\tEasyMobile.InAppPurchasing::add_PurchaseCompleted(v42);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnAwake()
		{
			Action<IAPProduct> value = OnPurchaseCompleted;
			InAppPurchasing.PurchaseCompleted += value;
		}

		[Token(Token = "0x6000089")]
		[Address(RVA = "0xCC122C", Offset = "0xCC122C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void OnUpdate(float deltaTime)
		{
		}

		[Token(Token = "0x600008A")]
		[Address(RVA = "0xCC1230", Offset = "0xCC1230", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EA8340]);\n\tv23 = *([v22 @ X8_v18]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, product, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023744]) = v41;\nL_001A:\n\tv46 = product._type == 0;\n\tv47 = ~v46;\n\tif (v47) goto L_0057;\n\tv104 = this.config;\n\tv93 = System.Collections.Generic.Dictionary`2<System.String, GBG.Pinata.ECS.InAppPurchase.Configs.ProductReward>::TryGetValue(v104.productsDictionary, product._name, &v84 @ stack_-40_v6 (GBG.Pinata.ECS.InAppPurchase.Configs.ProductReward));\n\tv142 = v93 == 0;\n\tif (v142) goto L_0057;\n\tgoto L_0039;\nL_0039:\n\tgoto L_0057;\n\tv197 = this.coins == 0;\n\tv96 = ~v197;\n\tif (v96) goto L_0047;\n\tthrow System.NullReferenceException;\nL_0047:\n\tv189 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(v145);\n\tv147 = v84 + v189;\n\tv137 = v147 + v193;\n\tMorpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(v145, v137);\nL_0057:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnPurchaseCompleted(IAPProduct product)
		{
			if (product.Type == IAPProductType.Consumable)
			{
				ConsumableProductsConfig consumableProductsConfig = config;
				if (!consumableProductsConfig.productsDictionary.TryGetValue(product.Name, out var _))
				{
				}
			}
		}

		[Token(Token = "0x600008B")]
		[Address(RVA = "0xCC1324", Offset = "0xCC1324", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.UpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PinataPurchasesSystem()
		{
		}
	}
}
