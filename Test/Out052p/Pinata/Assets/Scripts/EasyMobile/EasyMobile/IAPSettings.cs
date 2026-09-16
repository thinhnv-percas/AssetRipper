using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x200005F")]
	public class IAPSettings
	{
		[SerializeField]
		[Token(Token = "0x4000239")]
		[FieldOffset(Offset = "0x10")]
		private bool mAutoInit;

		[SerializeField]
		[Token(Token = "0x400023A")]
		[FieldOffset(Offset = "0x14")]
		private IAPAndroidStore mTargetAndroidStore;

		[SerializeField]
		[Token(Token = "0x400023B")]
		[FieldOffset(Offset = "0x18")]
		private bool mSimulateAppleAskToBuy;

		[SerializeField]
		[Token(Token = "0x400023C")]
		[FieldOffset(Offset = "0x19")]
		private bool mInterceptApplePromotionalPurchases;

		[SerializeField]
		[Token(Token = "0x400023D")]
		[FieldOffset(Offset = "0x1A")]
		private bool mEnableAmazonSandboxTesting;

		[SerializeField]
		[Token(Token = "0x400023E")]
		[FieldOffset(Offset = "0x1B")]
		private bool mValidateAppleReceipt;

		[SerializeField]
		[Token(Token = "0x400023F")]
		[FieldOffset(Offset = "0x1C")]
		private bool mValidateGooglePlayReceipt;

		[SerializeField]
		[Token(Token = "0x4000240")]
		[FieldOffset(Offset = "0x20")]
		private IAPProduct[] mProducts;

		[Token(Token = "0x17000159")]
		public bool IsAutoInit
		{
			[Token(Token = "0x6000496")]
			[Address(RVA = "0xBF5318", Offset = "0xBF5318", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mAutoInit;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsAutoInit;
			}
			[Token(Token = "0x6000497")]
			[Address(RVA = "0xBF5320", Offset = "0xBF5320", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mAutoInit = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				mAutoInit = value;
			}
		}

		[Token(Token = "0x1700015A")]
		public IAPAndroidStore TargetAndroidStore
		{
			[Token(Token = "0x6000498")]
			[Address(RVA = "0xBF532C", Offset = "0xBF532C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mTargetAndroidStore;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TargetAndroidStore;
			}
		}

		[Token(Token = "0x1700015B")]
		public bool SimulateAppleAskToBuy
		{
			[Token(Token = "0x6000499")]
			[Address(RVA = "0xBF5334", Offset = "0xBF5334", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mSimulateAppleAskToBuy;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SimulateAppleAskToBuy;
			}
			[Token(Token = "0x600049A")]
			[Address(RVA = "0xBF533C", Offset = "0xBF533C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mSimulateAppleAskToBuy = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				mSimulateAppleAskToBuy = value;
			}
		}

		[Token(Token = "0x1700015C")]
		public bool InterceptApplePromotionalPurchases
		{
			[Token(Token = "0x600049B")]
			[Address(RVA = "0xBF5348", Offset = "0xBF5348", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mInterceptApplePromotionalPurchases;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return InterceptApplePromotionalPurchases;
			}
			[Token(Token = "0x600049C")]
			[Address(RVA = "0xBF5350", Offset = "0xBF5350", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mInterceptApplePromotionalPurchases = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				mInterceptApplePromotionalPurchases = value;
			}
		}

		[Token(Token = "0x1700015D")]
		public bool EnableAmazonSandboxTesting
		{
			[Token(Token = "0x600049D")]
			[Address(RVA = "0xBF535C", Offset = "0xBF535C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mEnableAmazonSandboxTesting;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return EnableAmazonSandboxTesting;
			}
			[Token(Token = "0x600049E")]
			[Address(RVA = "0xBF5364", Offset = "0xBF5364", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mEnableAmazonSandboxTesting = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				mEnableAmazonSandboxTesting = value;
			}
		}

		[Token(Token = "0x1700015E")]
		public bool ValidateAppleReceipt
		{
			[Token(Token = "0x600049F")]
			[Address(RVA = "0xBF5370", Offset = "0xBF5370", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mValidateAppleReceipt;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ValidateAppleReceipt;
			}
			[Token(Token = "0x60004A0")]
			[Address(RVA = "0xBF5378", Offset = "0xBF5378", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mValidateAppleReceipt = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				mValidateAppleReceipt = value;
			}
		}

		[Token(Token = "0x1700015F")]
		public bool ValidateGooglePlayReceipt
		{
			[Token(Token = "0x60004A1")]
			[Address(RVA = "0xBF5384", Offset = "0xBF5384", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mValidateGooglePlayReceipt;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ValidateGooglePlayReceipt;
			}
			[Token(Token = "0x60004A2")]
			[Address(RVA = "0xBF538C", Offset = "0xBF538C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mValidateGooglePlayReceipt = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				mValidateGooglePlayReceipt = value;
			}
		}

		[Token(Token = "0x17000160")]
		public IAPProduct[] Products
		{
			[Token(Token = "0x60004A3")]
			[Address(RVA = "0xBF5398", Offset = "0xBF5398", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mProducts;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Products;
			}
			[Token(Token = "0x60004A4")]
			[Address(RVA = "0xBF53A0", Offset = "0xBF53A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mProducts = value;\n\treturn;\n")]
			set
			{
				Products = value;
			}
		}

		[Token(Token = "0x60004A5")]
		[Address(RVA = "0xBF53A8", Offset = "0xBF53A8", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mAutoInit = 1;\n\tthis.mValidateAppleReceipt = 1;\n\tthis.mValidateGooglePlayReceipt = 1;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IAPSettings()
		{
			mAutoInit = true;
			mValidateAppleReceipt = true;
			mValidateGooglePlayReceipt = true;
		}
	}
}
