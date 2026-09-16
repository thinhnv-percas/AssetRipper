using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace com.adjust.sdk
{
	[Token(Token = "0x200000F")]
	public class AdjustEvent
	{
		[Token(Token = "0x4000048")]
		[FieldOffset(Offset = "0x10")]
		internal string currency;

		[Token(Token = "0x4000049")]
		[FieldOffset(Offset = "0x18")]
		internal string eventToken;

		[Token(Token = "0x400004A")]
		[FieldOffset(Offset = "0x20")]
		internal string callbackId;

		[Token(Token = "0x400004B")]
		[FieldOffset(Offset = "0x28")]
		internal string transactionId;

		[Token(Token = "0x400004C")]
		[FieldOffset(Offset = "0x30")]
		internal double? revenue;

		[Token(Token = "0x400004D")]
		[FieldOffset(Offset = "0x40")]
		internal List<string> partnerList;

		[Token(Token = "0x400004E")]
		[FieldOffset(Offset = "0x48")]
		internal List<string> callbackList;

		[Token(Token = "0x400004F")]
		[FieldOffset(Offset = "0x50")]
		internal string receipt;

		[Token(Token = "0x4000050")]
		[FieldOffset(Offset = "0x58")]
		internal bool isReceiptSet;

		[Token(Token = "0x60000D9")]
		[Address(RVA = "0x156D7AC", Offset = "0x156D7AC", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.eventToken = eventToken;\n\tthis.isReceiptSet = 0;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AdjustEvent(string eventToken)
		{
			this.eventToken = eventToken;
			isReceiptSet = false;
		}

		[Token(Token = "0x60000DA")]
		[Address(RVA = "0x156D7DC", Offset = "0x156D7DC", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1EF0878]);\n\tv27 = *([v26 @ X8_v7]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, currency, methodInfo, v30, v31, v32, v33, v34, amount, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20290BD]) = v44;\nL_001B:\n\tv48 = 0;\n\tv52 = 0x115B9C0(&v48 @ stack_-40_v1 (System.Nullable`1<System.Double>), Il2CppMethodInfo, methodInfo, v30, v31, v32, v33, v34, amount, v35, v36, v37, v38, v39, v40, v41);\n\tthis.currency = currency;\n\tthis.revenue = 0;\n\t*([this @ X0 (com.adjust.sdk.AdjustEvent)+38]) = 0;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void setRevenue(double amount, string currency)
		{
			double? num = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115B9C0 (inside System.Nullable`1<System.DateTime>::Unbox +0xA8)");
			this.currency = currency;
			revenue = null;
			_ = 0;
		}

		[Token(Token = "0x60000DB")]
		[Address(RVA = "0x156D864", Offset = "0x156D864", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1EF5948]);\n\tv29 = *([v28 @ X8_v11]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, key, value, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20290BE]) = v46;\nL_0018:\n\tv61 = this.callbackList;\n\tv48 = this.callbackList == 0;\n\tv49 = ~v48;\n\tif (v49) goto L_002D;\n\tv53 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v53);\n\tthis.callbackList = v53;\nL_002D:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v61, key);\n\tSystem.Collections.Generic.List`1<System.String>::Add(this.callbackList, value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void addCallbackParameter(string key, string value)
		{
			List<string> list = callbackList;
			if (callbackList == null)
			{
				list = (callbackList = new List<string>());
			}
			list.Add(key);
			callbackList.Add(value);
		}

		[Token(Token = "0x60000DC")]
		[Address(RVA = "0x156D920", Offset = "0x156D920", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1EBC400]);\n\tv29 = *([v28 @ X8_v11]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, key, value, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20290BF]) = v46;\nL_0018:\n\tv61 = this.partnerList;\n\tv48 = this.partnerList == 0;\n\tv49 = ~v48;\n\tif (v49) goto L_002D;\n\tv53 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v53);\n\tthis.partnerList = v53;\nL_002D:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v61, key);\n\tSystem.Collections.Generic.List`1<System.String>::Add(this.partnerList, value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void addPartnerParameter(string key, string value)
		{
			List<string> list = partnerList;
			if (partnerList == null)
			{
				list = (partnerList = new List<string>());
			}
			list.Add(key);
			partnerList.Add(value);
		}

		[Token(Token = "0x60000DD")]
		[Address(RVA = "0x156D9DC", Offset = "0x156D9DC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.transactionId = transactionId;\n\treturn;\n")]
		public void setTransactionId(string transactionId)
		{
			this.transactionId = transactionId;
		}

		[Token(Token = "0x60000DE")]
		[Address(RVA = "0x156D9E4", Offset = "0x156D9E4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.callbackId = callbackId;\n\treturn;\n")]
		public void setCallbackId(string callbackId)
		{
			this.callbackId = callbackId;
		}

		[Obsolete]
		[Token(Token = "0x60000DF")]
		[Address(RVA = "0x156D9EC", Offset = "0x156D9EC", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.receipt = receipt;\n\tthis.transactionId = transactionId;\n\tthis.isReceiptSet = 1;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void setReceipt(string receipt, string transactionId)
		{
			this.receipt = receipt;
			this.transactionId = transactionId;
			isReceiptSet = true;
		}
	}
}
