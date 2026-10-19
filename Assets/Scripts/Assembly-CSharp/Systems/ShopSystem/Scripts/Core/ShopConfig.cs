using System;
using System.Collections.Generic;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.Utils;
using _game.Systems.PaymentSystem.Data;

namespace Systems.ShopSystem.Scripts.Core
{
	[Token(Token = "0x2000042")]
	public class ShopConfig
	{
		[Token(Token = "0x4000092")]
		[FieldOffset(Offset = "0x10")]
		public List<ShopGroupRemote> shopGroups;

		[Token(Token = "0x4000093")]
		[FieldOffset(Offset = "0x18")]
		public List<ShopLayoutConfig> shopLayouts;

		[Token(Token = "0x4000094")]
		[FieldOffset(Offset = "0x20")]
		public List<string> activeGroupKeys;

		[Token(Token = "0x4000095")]
		[FieldOffset(Offset = "0x28")]
		public List<Pair<string, string>> visualKeyPairs;

		[Token(Token = "0x60000D8")]
		[Address(RVA = "0x3C67D8C", Offset = "0x3C67D8C", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv51.groupKey = groupKey;\n\tv76 = new System.Func`2<Systems.ShopSystem.Scripts.Core.ShopGroupRemote, System.Boolean>();\n\tSystem.Func`2<Systems.ShopSystem.Scripts.Core.ShopGroupRemote, System.Boolean>::.ctor(v76, v51, Il2CppMethodInfo);\n\treturnVal2 = System.Linq.Enumerable::FirstOrDefault(this.shopGroups, v76);\n\treturn returnVal2;\nL_0023:\n\tv51 = new Systems.ShopSystem.Scripts.Core.ShopConfig+<>c__DisplayClass4_0();\n\tSystem.Object::.ctor(v51);\n")]
		public ShopGroupRemote GetGroupConfig(string groupKey)
		{
			Func<ShopGroupRemote, bool> predicate = (ShopGroupRemote pair) => pair.groupKey == groupKey;
			return (ShopGroupRemote)shopGroups.FirstOrDefault((Func<object, bool>)predicate);
		}

		[Token(Token = "0x60000D9")]
		[Address(RVA = "0x3C67E80", Offset = "0x3C67E80", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv51.bundleId = bundleId;\n\tv76 = new System.Func`2<Systems.ShopSystem.Scripts.Core.ShopGroupRemote, System.Boolean>();\n\tSystem.Func`2<Systems.ShopSystem.Scripts.Core.ShopGroupRemote, System.Boolean>::.ctor(v76, v51, Il2CppMethodInfo);\n\treturnVal2 = System.Linq.Enumerable::FirstOrDefault(this.shopGroups, v76);\n\treturn returnVal2;\nL_0023:\n\tv51 = new Systems.ShopSystem.Scripts.Core.ShopConfig+<>c__DisplayClass5_0();\n\tSystem.Object::.ctor(v51);\n")]
		public ShopGroupRemote GetGroupConfigBundleId(string bundleId)
		{
			Func<ShopGroupRemote, bool> predicate = delegate(ShopGroupRemote pair)
			{
				CostData costData = pair.costData;
				return costData.bundleId == bundleId;
			};
			return (ShopGroupRemote)shopGroups.FirstOrDefault((Func<object, bool>)predicate);
		}

		[Token(Token = "0x60000DA")]
		[Address(RVA = "0x3C67F74", Offset = "0x3C67F74", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv51.layoutId = layoutId;\n\tv69 = this.shopLayouts == 0;\n\tif (v69) goto L_0056;\n\tv77 = new System.Func`2<Systems.ShopSystem.Scripts.Core.ShopLayoutConfig, System.Boolean>();\n\tSystem.Func`2<Systems.ShopSystem.Scripts.Core.ShopLayoutConfig, System.Boolean>::.ctor(v77, v51, Il2CppMethodInfo);\n\treturnVal3 = System.Linq.Enumerable::FirstOrDefault(this.shopLayouts, v77);\n\treturn returnVal3;\nL_0056:\n\treturn 0;\nL_0023:\n\tv51 = new Systems.ShopSystem.Scripts.Core.ShopConfig+<>c__DisplayClass6_0();\n\tSystem.Object::.ctor(v51);\n")]
		public ShopLayoutConfig GetLayout(string layoutId)
		{
			if (shopLayouts != null)
			{
				Func<ShopLayoutConfig, bool> predicate = (ShopLayoutConfig l) => l.layoutId == layoutId;
				return (ShopLayoutConfig)shopLayouts.FirstOrDefault((Func<object, bool>)predicate);
			}
			return null;
		}

		[Token(Token = "0x60000DB")]
		[Address(RVA = "0x3C68084", Offset = "0x3C68084", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\treturnVal1 = v48.orderedGroupKeys;\n\tv53 = v48.orderedGroupKeys == 0;\n\tif (v53) goto L_002F;\nL_0027:\n\treturn returnVal1;\nL_0028:\n\treturnVal1 = this.activeGroupKeys;\n\tv55 = this.activeGroupKeys == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_0027;\nL_002F:\n\tv70 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v70);\n\treturn v70;\nL_001A:\n\tv48 = Systems.ShopSystem.Scripts.Core.ShopConfig::GetLayout(this, v40);\n\tv51 = v48 == 0;\n\tif (v51) goto L_0028;\n")]
		public List<string> GetOrderedKeys(string layoutId)
		{
			string layoutId2 = default(string);
			ShopLayoutConfig layout = GetLayout(layoutId2);
			List<string> orderedGroupKeys;
			if (layout != null)
			{
				orderedGroupKeys = layout.orderedGroupKeys;
				if (layout.orderedGroupKeys != null)
				{
					goto IL_0030;
				}
			}
			else
			{
				orderedGroupKeys = activeGroupKeys;
				if (activeGroupKeys != null)
				{
					goto IL_0030;
				}
			}
			return new List<string>();
			IL_0030:
			return orderedGroupKeys;
		}

		[Token(Token = "0x60000DC")]
		[Address(RVA = "0x3C68130", Offset = "0x3C68130", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public ShopConfig()
		{
		}
	}
}
