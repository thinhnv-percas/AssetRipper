using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using Newtonsoft.Json;
using Sirenix.Utilities;
using Unco.ResourceSystem;
using UnityEngine.Serialization;

namespace _game.Systems.PaymentSystem.Data
{
	[Serializable]
	[Token(Token = "0x200074F")]
	public class CostData
	{
		[Token(Token = "0x2000750")]
		public enum CostType
		{
			[Token(Token = "0x4001882")]
			Free = 0,
			[Token(Token = "0x4001883")]
			Rewarded = 1,
			[Token(Token = "0x4001884")]
			Custom = 2,
			[Token(Token = "0x4001885")]
			IAP = 3,
			[Token(Token = "0x4001886")]
			Resource = 4
		}

		[Token(Token = "0x4001874")]
		[FieldOffset(Offset = "0x10")]
		public CostType costType;

		[FormerlySerializedAs("id")]
		[Token(Token = "0x4001875")]
		[FieldOffset(Offset = "0x18")]
		public string bundleId;

		[DefaultValue(IAPProductType.Consumable)]
		[Token(Token = "0x4001876")]
		[FieldOffset(Offset = "0x20")]
		public IAPProductType productType;

		[DefaultValue(null)]
		[Token(Token = "0x4001877")]
		[FieldOffset(Offset = "0x28")]
		public string adjustID;

		[DefaultValue(0f)]
		[Token(Token = "0x4001878")]
		[FieldOffset(Offset = "0x30")]
		public float defaultPrice;

		[DefaultValue(0.0)]
		[Token(Token = "0x4001879")]
		[FieldOffset(Offset = "0x38")]
		public double amount;

		[DefaultValue(ResourceType.SoftCurrency)]
		[Token(Token = "0x400187A")]
		[FieldOffset(Offset = "0x40")]
		public ResourceType resourceType;

		[DefaultValue(0)]
		[Token(Token = "0x400187B")]
		[FieldOffset(Offset = "0x44")]
		public int rwType;

		[DefaultValue(null)]
		[Token(Token = "0x400187C")]
		[FieldOffset(Offset = "0x48")]
		public string uniqueId;

		[Token(Token = "0x400187D")]
		[FieldOffset(Offset = "0x50")]
		public string sourceType;

		[CompilerGenerated]
		[Token(Token = "0x400187E")]
		[FieldOffset(Offset = "0x58")]
		private Action Pay;

		[DefaultValue(null)]
		[Token(Token = "0x400187F")]
		[FieldOffset(Offset = "0x60")]
		public object metadata;

		[JsonIgnore]
		[Token(Token = "0x4001880")]
		[FieldOffset(Offset = "0x68")]
		private Dictionary<CostType, string> _costStrings;

		[CompilerGenerated]
		[Token(Token = "0x6001EC1")]
		[Address(RVA = "0x3D88AE0", Offset = "0x3D88AE0", Length = "0xA4")]
		public void add_Pay(Action value)
		{
			Action action = Pay;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref Pay, value2, action2);
			}
			while ((object)action != action2);
		}

		[CompilerGenerated]
		[Token(Token = "0x6001EC2")]
		[Address(RVA = "0x3D88B84", Offset = "0x3D88B84", Length = "0xA4")]
		public void remove_Pay(Action value)
		{
			Action action = Pay;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref Pay, value2, action2);
			}
			while ((object)action != action2);
		}

		[Token(Token = "0x6001EC3")]
		[Address(RVA = "0x3D88C28", Offset = "0x3D88C28", Length = "0xB8")]
		public CostData()
		{
			adjustID = "";
			Dictionary<CostType, string> costStrings = new Dictionary<CostType, string>();
			_costStrings = costStrings;
		}

		[Token(Token = "0x6001EC4")]
		[Address(RVA = "0x3D88CE0", Offset = "0x3D88CE0", Length = "0x6C")]
		public void OverrideCostString(CostType type, string str)
		{
			string value = default(string);
			_costStrings[type] = value;
		}

		[Token(Token = "0x6001EC5")]
		[Address(RVA = "0x3D88D4C", Offset = "0x3D88D4C", Length = "0x10")]
		public bool ShouldSerializebundleId()
		{
			int num = (int)(costType - 3);
			return num == 0;
		}

		[Token(Token = "0x6001EC6")]
		[Address(RVA = "0x3D88D5C", Offset = "0x3D88D5C", Length = "0x10")]
		public bool ShouldSerializeproductType()
		{
			int num = (int)(costType - 3);
			return num == 0;
		}

		[Token(Token = "0x6001EC7")]
		[Address(RVA = "0x3D88D6C", Offset = "0x3D88D6C", Length = "0x34")]
		public bool ShouldSerializeadjustID()
		{
			if (costType == CostType.IAP)
			{
				bool flag = string.IsNullOrEmpty(adjustID);
				return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
			}
			return false;
		}

		[Token(Token = "0x6001EC8")]
		[Address(RVA = "0x3D88DA0", Offset = "0x3D88DA0", Length = "0x24")]
		public bool ShouldSerializedefaultPrice()
		{
			if (costType == CostType.IAP)
			{
				bool flag = defaultPrice < 0f;
				bool flag2 = defaultPrice == 0f;
				bool flag3 = defaultPrice == defaultPrice;
				bool flag4 = !flag3;
				bool flag5 = flag == flag4;
				bool flag6 = !flag2;
				return flag5 && flag6;
			}
			return false;
		}

		[Token(Token = "0x6001EC9")]
		[Address(RVA = "0x3D88DC4", Offset = "0x3D88DC4", Length = "0x14")]
		public bool ShouldSerializeamount()
		{
			if (costType - 4 != CostType.Free)
			{
				int num = (int)(costType - 1);
				return num == 0;
			}
			return true;
		}

		[Token(Token = "0x6001ECA")]
		[Address(RVA = "0x3D88DD8", Offset = "0x3D88DD8", Length = "0x10")]
		public bool ShouldSerializeresourceType()
		{
			int num = (int)(costType - 4);
			return num == 0;
		}

		[Token(Token = "0x6001ECB")]
		[Address(RVA = "0x3D88DE8", Offset = "0x3D88DE8", Length = "0x10")]
		public bool ShouldSerializerwType()
		{
			int num = (int)(costType - 1);
			return num == 0;
		}

		[Token(Token = "0x6001ECC")]
		[Address(RVA = "0x3D88DF8", Offset = "0x3D88DF8", Length = "0x34")]
		public bool ShouldSerializeuniqueId()
		{
			if (costType == CostType.Rewarded)
			{
				bool flag = uniqueId.IsNullOrWhitespace();
				return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
			}
			return false;
		}

		[Token(Token = "0x6001ECD")]
		[Address(RVA = "0x3D88E2C", Offset = "0x3D88E2C", Length = "0x24")]
		public bool ShouldSerializemetadata()
		{
			if (costType == CostType.Custom)
			{
				bool flag = metadata == null;
				return !flag;
			}
			return false;
		}

		[Token(Token = "0x6001ECE")]
		[Address(RVA = "0x3D88E50", Offset = "0x3D88E50", Length = "0x60")]
		public static CostData Free()
		{
			CostData costData = new CostData();
			costData.costType = default(CostType);
			return costData;
		}

		[Token(Token = "0x6001ECF")]
		[Address(RVA = "0x3D88EB0", Offset = "0x3D88EB0", Length = "0xCC")]
		public static CostData Rewarded(string source, int rewardedType, int rewardedCount = 0, string uniqueId = "")
		{
			CostData costData = new CostData();
			costData.sourceType = source;
			costData.rwType = rewardedType;
			costData.costType = CostType.Rewarded;
			bool flag = uniqueId.IsNullOrWhitespace();
			if ((uint)rewardedCount >= 2u && !flag)
			{
				costData.uniqueId = uniqueId;
				costData.amount = rewardedCount;
			}
			return costData;
		}

		[Token(Token = "0x6001ED0")]
		[Address(RVA = "0x3D72DCC", Offset = "0x3D72DCC", Length = "0xEC")]
		public static CostData Resource(ResourceType resourceType, double amount, string sourceType)
		{
			CostData costData = new CostData();
			costData.resourceType = resourceType;
			costData.amount = amount;
			object arg = resourceType;
			string text = $"{sourceType}_{arg}";
			costData.sourceType = text;
			costData.costType = CostType.Resource;
			return costData;
		}

		[Token(Token = "0x6001ED1")]
		[Address(RVA = "0x3D88F7C", Offset = "0x3D88F7C", Length = "0xC8")]
		public static CostData IAP(string bundleId, string sourceType, IAPProductType productType = IAPProductType.Consumable, string adjustID = "", float defaultPrice = 0f)
		{
			CostData costData = new CostData();
			costData.bundleId = bundleId;
			costData.sourceType = sourceType;
			costData.costType = CostType.IAP;
			costData.productType = productType;
			costData.adjustID = adjustID;
			costData.defaultPrice = defaultPrice;
			return costData;
		}

		[Token(Token = "0x6001ED2")]
		[Address(RVA = "0x3D89044", Offset = "0x3D89044", Length = "0x80")]
		public static CostData Custom(object metadata)
		{
			CostData costData = new CostData();
			costData.metadata = metadata;
			costData.costType = CostType.Custom;
			return costData;
		}

		[Token(Token = "0x6001ED3")]
		[Address(RVA = "0x3D890C4", Offset = "0x3D890C4", Length = "0x88")]
		public CostData Copy()
		{
			CostData costData = (CostData)MemberwiseClone();
			if (costData != null)
			{
				CostData costData2 = costData as CostData;
				if (costData2 == null)
				{
					return (CostData)(object)new InvalidCastException();
				}
			}
			return costData;
		}

		[Token(Token = "0x6001ED4")]
		[Address(RVA = "0x3D8914C", Offset = "0x3D8914C", Length = "0x1C")]
		public void OnPay()
		{
			if (Pay != null)
			{
				Pay();
			}
		}

		[Token(Token = "0x6001ED5")]
		[Address(RVA = "0x3D89168", Offset = "0x3D89168", Length = "0xBC")]
		public void Set(CostData costData)
		{
			if (costData != null)
			{
				costType = costData.costType;
				bundleId = costData.bundleId;
				productType = costData.productType;
				adjustID = costData.adjustID;
				defaultPrice = costData.defaultPrice;
				amount = costData.amount;
				rwType = costData.rwType;
				uniqueId = costData.uniqueId;
				resourceType = costData.resourceType;
				sourceType = costData.sourceType;
				metadata = costData.metadata;
				_costStrings = costData._costStrings;
			}
		}
	}
}
