using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.RewardSystem
{
	[Token(Token = "0x2000017")]
	public class IAPShopItemData : ShopItemData
	{
		[Token(Token = "0x400002A")]
		private static readonly Dictionary<IAPItemType, Action<IAPShopItemData>> Handlers;

		[Token(Token = "0x1700000C")]
		[field: Token(Token = "0x400002B")]
		[field: FieldOffset(Offset = "0x40")]
		public IAPItemType IAPItemType
		{
			[Token(Token = "0x6000041")]
			[Address(RVA = "0x81D5AD0", Offset = "0x81D5AD0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.IAPItemType;\n")]
			get;
			[Token(Token = "0x6000042")]
			[Address(RVA = "0x81D5AD8", Offset = "0x81D5AD8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.IAPItemType = value;\n\treturn;\n")]
			set;
		}

		[Token(Token = "0x6000043")]
		[Address(RVA = "0x81D5AE0", Offset = "0x81D5AE0", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0025;\nL_0025:\n\tSystem.Collections.Generic.Dictionary`2<Unco.RewardSystem.IAPItemType, System.Action`1<Unco.RewardSystem.IAPShopItemData>>::set_Item(v50.Handlers, type, handler);\n\treturn;\n")]
		public static void RegisterHandler(IAPItemType type, Action<IAPShopItemData> handler)
		{
			Handlers[type] = handler;
		}

		[Token(Token = "0x6000044")]
		[Address(RVA = "0x81D5B8C", Offset = "0x81D5B8C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0023;\nL_0023:\n\tv75 = System.Collections.Generic.Dictionary`2<Unco.RewardSystem.IAPItemType, System.Action`1<Unco.RewardSystem.IAPShopItemData>>::Remove(v49.Handlers, type);\n\treturn;\n")]
		public static void UnregisterHandler(IAPItemType type)
		{
			bool flag = Handlers.Remove(type);
		}

		[Token(Token = "0x6000045")]
		[Address(RVA = "0x81D5C30", Offset = "0x81D5C30", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0015;\nL_0015:\n\tv52 = data == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_0034;\n\tgoto L_0047;\nL_0034:\n\tv80 = System.Collections.Generic.Dictionary`2<Unco.RewardSystem.IAPItemType, System.Action`1<Unco.RewardSystem.IAPShopItemData>>::TryGetValue(v68.Handlers, data.IAPItemType, &v82 @ stack_-38_v3 (System.Action`1<Unco.RewardSystem.IAPShopItemData>));\n\tv90 = ~v80;\n\tif (v90) goto L_0046;\n\tSystem.Action`1<Unco.RewardSystem.IAPShopItemData>::Invoke(v82, data);\nL_0047:\n\tthrow System.NullReferenceException;\nL_0046:\n\treturn;\n")]
		public static void InvokeHandler(IAPShopItemData data)
		{
			if (data != null)
			{
				if (Handlers.TryGetValue(data.IAPItemType, out var value))
				{
					value(data);
				}
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000046")]
		[Address(RVA = "0x81D5D0C", Offset = "0x81D5D0C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public IAPShopItemData()
		{
		}

		[Token(Token = "0x6000047")]
		[Address(RVA = "0x81D5D14", Offset = "0x81D5D14", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\treturn;\nL_0020:\n\tv49 = new System.Collections.Generic.Dictionary`2<Unco.RewardSystem.IAPItemType, System.Action`1<Unco.RewardSystem.IAPShopItemData>>();\n\tSystem.Collections.Generic.Dictionary`2<Unco.RewardSystem.IAPItemType, System.Action`1<Unco.RewardSystem.IAPShopItemData>>::.ctor(v49);\n\tv58.Handlers = v49;\n")]
		static IAPShopItemData()
		{
			Dictionary<IAPItemType, Action<IAPShopItemData>> handlers = new Dictionary<IAPItemType, Action<IAPShopItemData>>();
			Handlers = handlers;
		}
	}
}
