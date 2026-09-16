using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Default
{
	[Token(Token = "0x2000005")]
	public class WinProductDescription
	{
		[CompilerGenerated]
		[Token(Token = "0x4000001")]
		[FieldOffset(Offset = "0x10")]
		private string _003CplatformSpecificID_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000002")]
		[FieldOffset(Offset = "0x18")]
		private string _003Cprice_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000003")]
		[FieldOffset(Offset = "0x20")]
		private string _003Ctitle_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000004")]
		[FieldOffset(Offset = "0x28")]
		private string _003Cdescription_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000005")]
		[FieldOffset(Offset = "0x30")]
		private string _003CISOCurrencyCode_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x38")]
		private decimal _003CpriceDecimal_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x48")]
		private string _003Creceipt_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000008")]
		[FieldOffset(Offset = "0x50")]
		private string _003CtransactionID_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000009")]
		[FieldOffset(Offset = "0x58")]
		private bool _003Cconsumable_003Ek__BackingField;

		[Token(Token = "0x17000001")]
		private string platformSpecificID
		{
			[CompilerGenerated]
			[Token(Token = "0x6000007")]
			[Address(RVA = "0x167FFE8", Offset = "0x167FFE8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<platformSpecificID>k__BackingField = value;\n\treturn;\n")]
			set
			{
				_003CplatformSpecificID_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000002")]
		private string price
		{
			[CompilerGenerated]
			[Token(Token = "0x6000008")]
			[Address(RVA = "0x167FFF0", Offset = "0x167FFF0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<price>k__BackingField = value;\n\treturn;\n")]
			set
			{
				_003Cprice_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000003")]
		private string title
		{
			[CompilerGenerated]
			[Token(Token = "0x6000009")]
			[Address(RVA = "0x167FFF8", Offset = "0x167FFF8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<title>k__BackingField = value;\n\treturn;\n")]
			set
			{
				_003Ctitle_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000004")]
		private string description
		{
			[CompilerGenerated]
			[Token(Token = "0x600000A")]
			[Address(RVA = "0x1680000", Offset = "0x1680000", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<description>k__BackingField = value;\n\treturn;\n")]
			set
			{
				_003Cdescription_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000005")]
		private string ISOCurrencyCode
		{
			[CompilerGenerated]
			[Token(Token = "0x600000B")]
			[Address(RVA = "0x1680008", Offset = "0x1680008", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ISOCurrencyCode>k__BackingField = value;\n\treturn;\n")]
			set
			{
				_003CISOCurrencyCode_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000006")]
		private decimal priceDecimal
		{
			[CompilerGenerated]
			[Token(Token = "0x600000C")]
			[Address(RVA = "0x1680010", Offset = "0x1680010", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<priceDecimal>k__BackingField = value;\n\tthis.<priceDecimal>k__BackingField.lo = methodInfo;\n\treturn;\n")]
			set
			{
				_003CpriceDecimal_003Ek__BackingField = value;
				IntPtr intPtr = default(IntPtr);
				_003CpriceDecimal_003Ek__BackingField.lo = (int)(long)intPtr;
			}
		}

		[Token(Token = "0x17000007")]
		private string receipt
		{
			[CompilerGenerated]
			[Token(Token = "0x600000D")]
			[Address(RVA = "0x1680018", Offset = "0x1680018", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<receipt>k__BackingField = value;\n\treturn;\n")]
			set
			{
				_003Creceipt_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000008")]
		private string transactionID
		{
			[CompilerGenerated]
			[Token(Token = "0x600000E")]
			[Address(RVA = "0x1680020", Offset = "0x1680020", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<transactionID>k__BackingField = value;\n\treturn;\n")]
			set
			{
				_003CtransactionID_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000009")]
		private bool consumable
		{
			[CompilerGenerated]
			[Token(Token = "0x600000F")]
			[Address(RVA = "0x1680028", Offset = "0x1680028", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<consumable>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_003Cconsumable_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x1680034", Offset = "0x1680034", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-10_v2;\n\tSystem.Object::.ctor(this);\n\tthis.<platformSpecificID>k__BackingField = id;\n\tthis.<price>k__BackingField = price;\n\tthis.<title>k__BackingField = title;\n\tthis.<description>k__BackingField = description;\n\tthis.<ISOCurrencyCode>k__BackingField = isoCode;\n\tthis.<priceDecimal>k__BackingField = priceD;\n\tthis.<transactionID>k__BackingField = *([v24 @ X29_v1+18]);\n\tthis.<priceDecimal>k__BackingField.lo = receipt;\n\tthis.<receipt>k__BackingField = *([v24 @ X29_v1+10]);\n\tv47 = *([v24 @ X29_v1+20]) & 1;\n\tthis.<consumable>k__BackingField = v47;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public WinProductDescription(string id, string price, string title, string description, string isoCode, decimal priceD, string receipt = null, string transactionId = null, bool consumable = false)
		{
			//IL_005c: Expected O, but got I
			//IL_006b: Expected I4, but got O
			//IL_007d: Expected O, but got I
			base._002Ector();
			object obj2 = default(object);
			object obj = obj2;
			_003CplatformSpecificID_003Ek__BackingField = id;
			this._003Cprice_003Ek__BackingField = price;
			this._003Ctitle_003Ek__BackingField = title;
			this._003Cdescription_003Ek__BackingField = description;
			_003CISOCurrencyCode_003Ek__BackingField = isoCode;
			_003CpriceDecimal_003Ek__BackingField = priceD;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+18]");
			_003CtransactionID_003Ek__BackingField = (string)0;
			_003CpriceDecimal_003Ek__BackingField.lo = (int)receipt;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+10]");
			this._003Creceipt_003Ek__BackingField = (string)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+20]");
			int num = 0;
			this._003Cconsumable_003Ek__BackingField = (byte)num != 0;
		}
	}
}
