using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000043")]
	internal class FakeAppleExtensions : IAppleExtensions, IStoreExtension
	{
		[Token(Token = "0x40000B6")]
		[FieldOffset(Offset = "0x10")]
		private bool m_FailRefresh;

		[CompilerGenerated]
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72C868", Offset = "0x72C868")]
		[Token(Token = "0x40000B7")]
		[FieldOffset(Offset = "0x11")]
		private bool _003CsimulateAskToBuy_003Ek__BackingField;

		[Token(Token = "0x17000024")]
		public bool simulateAskToBuy
		{
			[CompilerGenerated]
			[Token(Token = "0x60000FB")]
			[Address(RVA = "0xC5EF88", Offset = "0xC5EF88", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<simulateAskToBuy>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_003CsimulateAskToBuy_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x60000F8")]
		[Address(RVA = "0xC5EE80", Offset = "0xC5EE80", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1EB1230]);\n\tv27 = *([v26 @ X8_v11]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, successCallback, errorCallback, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023328]) = v44;\nL_0018:\n\tv46 = ~this.m_FailRefresh;\n\tif (v46) goto L_0029;\n\tSystem.Action::Invoke(errorCallback);\n\tgoto L_002B;\nL_0029:\n\tSystem.Action`1<System.String>::Invoke(successCallback, \"A fake refreshed receipt!\");\nL_002B:\n\tv69 = this.m_FailRefresh ^ 1;\n\tthis.m_FailRefresh = v69;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RefreshAppReceipt(Action<string> successCallback, Action errorCallback)
		{
			if (m_FailRefresh)
			{
				errorCallback();
			}
			else
			{
				successCallback("A fake refreshed receipt!");
			}
			int failRefresh = (m_FailRefresh ? 1 : 0) ^ 1;
			m_FailRefresh = (byte)failRefresh != 0;
		}

		[Token(Token = "0x60000F9")]
		[Address(RVA = "0xC5EF24", Offset = "0xC5EF24", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv18 = *([1ED8FA8]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, callback, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2023329]) = v38;\nL_001F:\n\tSystem.Action`1<System.Boolean>::Invoke(callback, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RestoreTransactions(Action<bool> callback)
		{
			callback(obj: true);
		}

		[Token(Token = "0x60000FA")]
		[Address(RVA = "0xC5EF84", Offset = "0xC5EF84", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void RegisterPurchaseDeferredListener(Action<Product> callback)
		{
		}

		[Token(Token = "0x60000FC")]
		[Address(RVA = "0xC5EF94", Offset = "0xC5EF94", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetStorePromotionOrder(List<Product> products)
		{
		}

		[Token(Token = "0x60000FD")]
		[Address(RVA = "0xC5EF98", Offset = "0xC5EF98", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetStorePromotionVisibility(Product product, AppleStorePromotionVisibility visible)
		{
		}

		[Token(Token = "0x60000FE")]
		[Address(RVA = "0xC5EF9C", Offset = "0xC5EF9C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void ContinuePromotionalPurchases()
		{
		}

		[Token(Token = "0x60000FF")]
		[Address(RVA = "0xC5EFA0", Offset = "0xC5EFA0", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EC2548]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202332A]) = v35;\nL_0014:\n\tv39 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v39);\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Dictionary<string, string> GetIntroductoryPriceDictionary()
		{
			return new Dictionary<string, string>();
		}

		[Token(Token = "0x6000100")]
		[Address(RVA = "0xC5F004", Offset = "0xC5F004", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FakeAppleExtensions()
		{
		}
	}
}
