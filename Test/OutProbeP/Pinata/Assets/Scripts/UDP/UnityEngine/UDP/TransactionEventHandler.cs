using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.UDP.Analytics;

namespace UnityEngine.UDP
{
	[Token(Token = "0x200000A")]
	internal class TransactionEventHandler : IPurchaseListener
	{
		[Token(Token = "0x4000029")]
		[FieldOffset(Offset = "0x10")]
		internal PurchaseInfo _purchaseInfo;

		[Token(Token = "0x400002A")]
		[FieldOffset(Offset = "0x18")]
		private int retryTime;

		[Token(Token = "0x6000020")]
		[Address(RVA = "0x15CA914", Offset = "0x15CA914", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis._purchaseInfo = purchaseInfo;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TransactionEventHandler(PurchaseInfo purchaseInfo)
		{
			_purchaseInfo = purchaseInfo;
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x15CC938", Offset = "0x15CC938", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void OnPurchase(PurchaseInfo purchaseInfo)
		{
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0x15CC93C", Offset = "0x15CC93C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void OnPurchaseFailed(string message, PurchaseInfo purchaseInfo)
		{
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x15CC940", Offset = "0x15CC940", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void OnPurchaseConsume(PurchaseInfo purchaseInfo)
		{
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0x15CC944", Offset = "0x15CC944", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void OnPurchaseConsumeFailed(string message, PurchaseInfo purchaseInfo)
		{
		}

		[Token(Token = "0x6000025")]
		[Address(RVA = "0x15CC948", Offset = "0x15CC948", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this._purchaseInfo;\n\tv17 = UnityEngine.UDP.Inventory::GetProductInfo(inventory, v10.<ProductId>k__BackingField);\n\tv21 = this._purchaseInfo;\n\tv56 = UnityEngine.UDP.Analytics.UdpAnalytics::Transaction(v21.<ProductId>k__BackingField, v17.<Price>k__BackingField, v17.<Currency>k__BackingField, v21.<StorePurchaseJsonString>k__BackingField, v21.<GameOrderId>k__BackingField);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnQueryInventory(Inventory inventory)
		{
			PurchaseInfo purchaseInfo = _purchaseInfo;
			ProductInfo productInfo = inventory.GetProductInfo(purchaseInfo.ProductId);
			PurchaseInfo purchaseInfo2 = _purchaseInfo;
			AnalyticsResult analyticsResult = UdpAnalytics.Transaction(purchaseInfo2.ProductId, productInfo.Price, productInfo.Currency, purchaseInfo2.StorePurchaseJsonString, purchaseInfo2.GameOrderId);
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0x15CC9A4", Offset = "0x15CC9A4", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EE71E8]);\n\tv21 = *([v20 @ X8_v25]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, message, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20299EF]) = v40;\nL_001B:\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<UnityEngine.UDP.Utils>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v44, message, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv52 = UnityEngine.UDP.Utils;\nL_0023:\n\tv56 = v55.RETRY_WAIT_TIME;\n\tv69 = this.retryTime >= v56.Length;\n\tif (v69) goto L_0079;\n\tv96 = this.retryTime + 1;\n\tthis.retryTime = v96;\n\tgoto L_0041;\n\tv134 = *([v51 @ X0_v3 (Il2CppClass<UnityEngine.UDP.Utils>)+E0]);\n\tv135 = v134 == 0;\n\tv136 = ~v135;\n\tif (v136) goto L_0041;\n\tv184 = \"il2cpp_codegen_runtime_class_init\"(v51, message, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv138 = UnityEngine.UDP.Utils;\n\tv140 = *([v14 @ X19_v1 (UnityEngine.UDP.TransactionEventHandler)+18]);\nL_0041:\n\tv72 = v141.RETRY_WAIT_TIME;\n\tv185 = v96 < v72.Length;\n\tv129 = ~v185;\n\tif (v129) goto L_007C;\n\tv190 = new System.Action();\n\tSystem.Action::.ctor(v190, this, Il2CppMethodInfo);\n\tgoto L_0071;\n\tv200 = *([v196 @ X0_v13+E0]);\n\tv201 = v200 == 0;\n\tv202 = ~v201;\n\tif (v202) goto L_0071;\n\tv204 = \"il2cpp_codegen_runtime_class_init\"(v196, v152, v147, v150, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0071:\n\tUnityEngine.UDP.MainThreadDispatcher::DispatchDelayJob(v72[v96 @ X8_v12 (System.Int32)], v190);\n\treturn;\nL_0079:\n\treturn;\n\tv98 = new System.NullReferenceException();\nL_007C:\n\tv133 = new System.IndexOutOfRangeException();\n\tthrow v133;\n\treturn;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnQueryInventoryFailed(string message)
		{
			//IL_00a1: Expected F4, but got I4
			int[] rETRY_WAIT_TIME = Utils.RETRY_WAIT_TIME;
			if (retryTime < rETRY_WAIT_TIME.Length)
			{
				int num = ++retryTime;
				int[] rETRY_WAIT_TIME2 = Utils.RETRY_WAIT_TIME;
				if (num >= rETRY_WAIT_TIME2.Length)
				{
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				Action runnable = delegate
				{
					List<string> list = new List<string>();
					PurchaseInfo purchaseInfo = _purchaseInfo;
					list.Add(purchaseInfo.ProductId);
					StoreService.QueryInventory(list, this);
				};
				MainThreadDispatcher.DispatchDelayJob(rETRY_WAIT_TIME2[num], runnable);
			}
		}
	}
}
