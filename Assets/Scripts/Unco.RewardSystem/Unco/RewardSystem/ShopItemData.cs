using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.RewardSystem
{
	[Token(Token = "0x200000D")]
	public abstract class ShopItemData
	{
		[Token(Token = "0x400000D")]
		[FieldOffset(Offset = "0x10")]
		public Sprite icon;

		[Token(Token = "0x400000E")]
		[FieldOffset(Offset = "0x18")]
		public string sourceType;

		[Token(Token = "0x4000011")]
		[FieldOffset(Offset = "0x30")]
		public string customTransactionData;

		[Token(Token = "0x4000012")]
		[FieldOffset(Offset = "0x38")]
		public object iapVisual;

		[Token(Token = "0x17000007")]
		[field: Token(Token = "0x400000F")]
		[field: FieldOffset(Offset = "0x20")]
		public double Amount
		{
			[Token(Token = "0x6000022")]
			[Address(RVA = "0x81D4DF4", Offset = "0x81D4DF4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Amount;\n")]
			get;
			[Token(Token = "0x6000023")]
			[Address(RVA = "0x81D4DFC", Offset = "0x81D4DFC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Amount = value;\n\treturn;\n")]
			set;
		}

		[Token(Token = "0x17000008")]
		[field: Token(Token = "0x4000010")]
		[field: FieldOffset(Offset = "0x28")]
		public Action OnPurchased
		{
			[Token(Token = "0x6000024")]
			[Address(RVA = "0x81D4E04", Offset = "0x81D4E04", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.OnPurchased;\n")]
			get;
			[Token(Token = "0x6000025")]
			[Address(RVA = "0x81D4E0C", Offset = "0x81D4E0C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.OnPurchased = value;\n\treturn;\n")]
			set;
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0x81D4E14", Offset = "0x81D4E14", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.icon = sprite;\n\treturn;\n")]
		public void SetIcon(Sprite sprite)
		{
			icon = sprite;
		}

		[Token(Token = "0x6000027")]
		[Address(RVA = "0x81D4E1C", Offset = "0x81D4E1C", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tUnco.RewardSystem.PurchaseHandlerRegistry::Execute(v45.<Instance>k__BackingField, this);\nL_001D:\n\t;\n\tv51 = this.OnPurchased == 0;\n\tif (v51) goto L_0032;\n\tSystem.Action::Invoke(this.OnPurchased);\n\treturn;\nL_0032:\n\treturn;\nL_0019:\n\tv47 = v45.<Instance>k__BackingField == 0;\n\tif (v47) goto L_001D;\n")]
		public virtual void OnPurchase()
		{
			if (PurchaseHandlerRegistry.Instance != null)
			{
				PurchaseHandlerRegistry.Instance.Execute(this);
			}
			if (OnPurchased != null)
			{
				OnPurchased();
			}
		}

		[Token(Token = "0x6000028")]
		[Address(RVA = "0x81D4EA4", Offset = "0x81D4EA4", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v64_asT @ TEMPCOND_v4 (Unco.RewardSystem.ShopItemData), typeof(Unco.RewardSystem.ShopItemData), returnVal1 @ X0_v2 (Unco.RewardSystem.ShopItemData)\n\tv64 = v64_asT == 0;\n\tif (v64) goto L_003E;\nL_003D:\n\treturn returnVal1;\nL_003E:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\nL_0015:\n\treturnVal1 = System.Object::MemberwiseClone(this);\n\tv43 = returnVal1 == 0;\n\tif (v43) goto L_003D;\n")]
		public virtual ShopItemData Copy()
		{
			ShopItemData shopItemData = (ShopItemData)MemberwiseClone();
			if (shopItemData != null)
			{
				ShopItemData shopItemData2 = shopItemData as ShopItemData;
				if (shopItemData2 == null)
				{
					return (ShopItemData)(object)new InvalidCastException();
				}
			}
			return shopItemData;
		}

		[Token(Token = "0x6000029")]
		[Address(RVA = "0x81D4F2C", Offset = "0x81D4F2C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public ShopItemData()
		{
		}
	}
}
