using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Systems.ShopSystem.Scripts.Core;
using Cpp2ILInjected;
using _game.Systems.ElephantStorage;
using _game.Systems.PaymentSystem.Data;

namespace _game.Systems.ShopSystem.Scripts.IAP
{
	[Token(Token = "0x2000714")]
	public class IAPDataStore
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000715")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40017B7")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40017B8")]
			public static Func<ShopGroupRemote, bool> _003C_003E9__6_0;

			[Token(Token = "0x40017B9")]
			public static Func<ShopGroupRemote, CostData> _003C_003E9__6_1;

			[Token(Token = "0x6001DDF")]
			[Address(RVA = "0x3D7E004", Offset = "0x3D7E004", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001DE0")]
			[Address(RVA = "0x3D7E068", Offset = "0x3D7E068", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal bool _003CExtractIAPProducts_003Eb__6_0(ShopGroupRemote g)
			{
				CostData costData = g.costData;
				if (g.costData != null && costData.costType == CostData.CostType.IAP)
				{
					bool flag = string.IsNullOrEmpty(costData.bundleId);
					return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
				}
				return false;
			}

			internal CostData _003CExtractIAPProducts_003Eb__6_1(ShopGroupRemote g)
			{
				return g.costData;
			}
		}

		[Token(Token = "0x40017B4")]
		[FieldOffset(Offset = "0x10")]
		internal readonly List<CostData> _iapProducts;

		[Token(Token = "0x40017B5")]
		[FieldOffset(Offset = "0x18")]
		internal readonly ShopStorageData _shopData;

		[Token(Token = "0x40017B6")]
		[FieldOffset(Offset = "0x20")]
		internal readonly IPlayerDataHandler _dataHandler;

		[Token(Token = "0x170002E5")]
		public List<CostData> ProductList
		{
			[Token(Token = "0x6001DD5")]
			[Address(RVA = "0x3D7D760", Offset = "0x3D7D760", Length = "0x8")]
			get
			{
				return _iapProducts;
			}
		}

		[Token(Token = "0x6001DD6")]
		[Address(RVA = "0x3D7D768", Offset = "0x3D7D768", Length = "0x6C")]
		public IAPDataStore(ShopConfig shopConfig, ShopStorageData shopData, IPlayerDataHandler dataHandler)
		{
			_shopData = shopData;
			_dataHandler = dataHandler;
			List<CostData> iapProducts = ExtractIAPProducts(shopConfig);
			_iapProducts = iapProducts;
		}

		[Token(Token = "0x6001DD7")]
		[Address(RVA = "0x3D7D7D4", Offset = "0x3D7D7D4", Length = "0x24C")]
		internal static List<CostData> ExtractIAPProducts(ShopConfig shopConfig)
		{
			if (shopConfig != null && shopConfig.shopGroups != null)
			{
				bool flag = _003C_003Ec._003C_003E9__6_0 == null;
				bool flag2 = !flag;
				Func<object, bool> predicate = (Func<object, bool>)_003C_003Ec._003C_003E9__6_0;
				if (!flag2)
				{
					predicate = (Func<object, bool>)(_003C_003Ec._003C_003E9__6_0 = delegate(ShopGroupRemote g)
					{
						CostData costData = g.costData;
						if (g.costData != null && costData.costType == CostData.CostType.IAP)
						{
							bool flag5 = string.IsNullOrEmpty(costData.bundleId);
							return (byte)((flag5 ? 1u : 0u) ^ 1u) != 0;
						}
						return false;
					});
				}
				IEnumerable<object> source = shopConfig.shopGroups.Where(predicate);
				bool flag3 = _003C_003Ec._003C_003E9__6_1 == null;
				bool flag4 = !flag3;
				Func<object, object> selector = (Func<object, object>)_003C_003Ec._003C_003E9__6_1;
				if (!flag4)
				{
					selector = (Func<object, object>)(_003C_003Ec._003C_003E9__6_1 = (ShopGroupRemote g) => g.costData);
				}
				IEnumerable<object> source2 = source.Select(selector);
				return (List<CostData>)(object)source2.ToList();
			}
			return new List<CostData>();
		}

		[Token(Token = "0x6001DD8")]
		[Address(RVA = "0x3D7DA20", Offset = "0x3D7DA20", Length = "0xF0")]
		public CostData GetProduct(string bundleId)
		{
			Predicate<CostData> match = (CostData x) => x.bundleId == bundleId;
			return ProductList.Find(match);
		}

		[Token(Token = "0x6001DD9")]
		[Address(RVA = "0x3D7DB18", Offset = "0x3D7DB18", Length = "0x10C")]
		public float GetDefaultPrice(string bundleId)
		{
			//IL_006c: Expected F4, but got I
			Func<CostData, bool> predicate = (CostData x) => x.bundleId == bundleId;
			object obj = ProductList.FirstOrDefault((Func<object, bool>)predicate);
			float result;
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X0_v11 (System.Object)+30]");
				result = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X0_v11 (System.Object)+30]");
				bool flag = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X0_v11 (System.Object)+30]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X0_v11 (System.Object)+30]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X0_v11 (System.Object)+30]");
				bool flag3 = num == 0;
				bool flag4 = !flag3;
				bool flag5 = flag == flag4;
				bool flag6 = !flag2;
				if (flag5 && flag6)
				{
					goto IL_0114;
				}
			}
			result = 4.99f;
			goto IL_0114;
			IL_0114:
			return result;
		}

		[Token(Token = "0x6001DDA")]
		[Address(RVA = "0x3D7DC2C", Offset = "0x3D7DC2C", Length = "0x194")]
		public void AddPurchaseHistory(string bundleId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("IAPDataStore::AddPurchaseHistory");
		}

		[Token(Token = "0x6001DDB")]
		[Address(RVA = "0x3D7DDC0", Offset = "0x3D7DDC0", Length = "0x6C")]
		public bool IsPurchased(string bundleId)
		{
			ShopStorageData shopData = _shopData;
			string item = default(string);
			return shopData.PurchaseHistory.Contains(item);
		}

		[Token(Token = "0x6001DDC")]
		[Address(RVA = "0x3D7DE2C", Offset = "0x3D7DE2C", Length = "0xF4")]
		public int HowManyTimesPurchased(string bundleId)
		{
			ShopStorageData shopData = _shopData;
			Func<string, bool> predicate = (string x) => x == bundleId;
			return shopData.PurchaseHistory.Count((Func<object, bool>)predicate);
		}

		[Token(Token = "0x6001DDD")]
		[Address(RVA = "0x3D7DF28", Offset = "0x3D7DF28", Length = "0xB4")]
		public float TotalPurchaseHistory()
		{
			ShopStorageData shopData = _shopData;
			Func<string, float> selector = (string x) => GetProduct(x)?.defaultPrice ?? 0f;
			return shopData.PurchaseHistory.Sum((Func<object, float>)selector);
		}
	}
}
