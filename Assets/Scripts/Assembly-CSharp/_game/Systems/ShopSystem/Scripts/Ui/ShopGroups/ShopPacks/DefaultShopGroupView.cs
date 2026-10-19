using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Systems.RewardSystem.UnityBindings;
using Systems.ShopSystem.Scripts.Core;
using Systems.ShopSystem.Scripts.Ui.ShopGroups;
using Cpp2ILInjected;
using Unco.ResourceSystem;
using Unco.RewardSystem;
using UnityEngine;

namespace _game.Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopPacks
{
	[Token(Token = "0x200070B")]
	public class DefaultShopGroupView : ShopGroupView
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200070C")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400179D")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400179E")]
			public static Func<ShopItemRemote, bool> _003C_003E9__3_0;

			[Token(Token = "0x6001DBA")]
			[Address(RVA = "0x3D7C420", Offset = "0x3D7C420", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001DBB")]
			[Address(RVA = "0x3D7C484", Offset = "0x3D7C484", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal bool _003CInnerInit_003Eb__3_0(ShopItemRemote item)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("DefaultShopGroupView._003C_003Ec::_003CInnerInit_003Eb__3_0");
				return default;
			}
		}

		[SerializeField]
		[Token(Token = "0x400179A")]
		[FieldOffset(Offset = "0x70")]
		private GenericElementVisualizer m_itemCardPrefab;

		[SerializeField]
		[Token(Token = "0x400179B")]
		[FieldOffset(Offset = "0x78")]
		private Transform m_container;

		[SerializeField]
		[Token(Token = "0x400179C")]
		[FieldOffset(Offset = "0x80")]
		private string m_sourceType;

		[Token(Token = "0x6001DB8")]
		[Address(RVA = "0x3D7C1C0", Offset = "0x3D7C1C0", Length = "0x1FC")]
		protected unsafe override void InnerInit()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DefaultShopGroupView::InnerInit");
		}

		[Token(Token = "0x6001DB9")]
		[Address(RVA = "0x3D7C3BC", Offset = "0x3D7C3BC", Length = "0x64")]
		public DefaultShopGroupView()
		{
			m_sourceType = "Shop";
		}
	}
}
