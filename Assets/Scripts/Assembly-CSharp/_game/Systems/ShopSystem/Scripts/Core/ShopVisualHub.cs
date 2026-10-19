using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using Systems.ShopSystem.Scripts.Core;
using Systems.ShopSystem.Scripts.Ui.ShopGroups;
using Cpp2ILInjected;
using Unco.Utils;
using UnityEngine;

namespace _game.Systems.ShopSystem.Scripts.Core
{
	[Token(Token = "0x200072B")]
	public class ShopVisualHub : ScriptableObject
	{
		[CompilerGenerated]
		[Token(Token = "0x200072C")]
		private sealed class _003C_003Ec__DisplayClass10_0
		{
			[Token(Token = "0x4001806")]
			[FieldOffset(Offset = "0x10")]
			public ShopItemVisualData offerTag;

			[Token(Token = "0x6001E45")]
			[Address(RVA = "0x3D8363C", Offset = "0x3D8363C", Length = "0x8")]
			public _003C_003Ec__DisplayClass10_0()
			{
			}

			internal bool _003COfferTagText_003Eb__0(Pair<ShopOfferTag, string> pair)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ShopVisualHub._003C_003Ec__DisplayClass10_0::_003COfferTagText_003Eb__0");
				return default;
			}
		}

		[SerializeField]
		[Token(Token = "0x4001801")]
		[FieldOffset(Offset = "0x18")]
		private List<Pair<string, Sprite>> m_shopIcons;

		[SerializeField]
		[Token(Token = "0x4001802")]
		[FieldOffset(Offset = "0x20")]
		private List<Pair<RarityType, RarityVisualData>> m_rarityVisuals;

		[SerializeField]
		[Token(Token = "0x4001803")]
		[FieldOffset(Offset = "0x28")]
		private List<Pair<string, ShopGroupView>> m_groupViewPrefabs;

		[SerializeField]
		[Token(Token = "0x4001804")]
		[FieldOffset(Offset = "0x30")]
		private RectTransform m_lineRowPrefab;

		[SerializeField]
		[Token(Token = "0x4001805")]
		[FieldOffset(Offset = "0x38")]
		private List<Pair<ShopOfferTag, string>> m_offerTags;

		[Token(Token = "0x170002E7")]
		public RectTransform LineRowPrefab
		{
			[Token(Token = "0x6001E3F")]
			[Address(RVA = "0x3D833DC", Offset = "0x3D833DC", Length = "0x8")]
			get
			{
				return m_lineRowPrefab;
			}
		}

		[Token(Token = "0x6001E40")]
		[Address(RVA = "0x3D7BFDC", Offset = "0x3D7BFDC", Length = "0xF4")]
		public Sprite GetShopIcon(string id)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ShopVisualHub::GetShopIcon");
			return default;
		}

		[Token(Token = "0x6001E41")]
		[Address(RVA = "0x3D833EC", Offset = "0x3D833EC", Length = "0xF4")]
		public ShopGroupView GetGroupViewPrefab(string viewType)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ShopVisualHub::GetGroupViewPrefab");
			return default;
		}

		[Token(Token = "0x6001E42")]
		[Address(RVA = "0x3D7C0D0", Offset = "0x3D7C0D0", Length = "0xE8")]
		public RarityVisualData GetRarityVisual(RarityType common)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ShopVisualHub::GetRarityVisual");
			return default;
		}

		[Token(Token = "0x6001E43")]
		[Address(RVA = "0x3D834F0", Offset = "0x3D834F0", Length = "0x14C")]
		public unsafe string OfferTagText(ShopItemVisualData offerTag)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ShopVisualHub::OfferTagText");
			return default;
		}

		[Token(Token = "0x6001E44")]
		[Address(RVA = "0x3D83644", Offset = "0x3D83644", Length = "0x8")]
		public ShopVisualHub()
		{
		}
	}
}
