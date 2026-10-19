using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Systems.RewardSystem.UnityBindings;
using Systems.ShopSystem.Scripts.Core;
using Systems.ShopSystem.Scripts.Ui.ShopGroups;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.ResourceSystem;
using Unco.RewardSystem;
using Unco.TextViewSystem;
using Unco.Utils;
using UnityEngine;
using UnityEngine.UI;
using _game.Systems.ShopSystem.Scripts.Core;

namespace _game.Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopPacks
{
	[Token(Token = "0x200070F")]
	public class MultipleGroupShopGroupView : ShopGroupView
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000710")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40017AE")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40017AF")]
			public static Func<ShopItemRemote, bool> _003C_003E9__5_0;

			[Token(Token = "0x40017B0")]
			public static Func<ShopItemRemote, string> _003C_003E9__5_2;

			[Token(Token = "0x6001DC6")]
			[Address(RVA = "0x3D7CFD8", Offset = "0x3D7CFD8", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001DC7")]
			[Address(RVA = "0x3D7D03C", Offset = "0x3D7D03C", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal bool _003CInnerInit_003Eb__5_0(ShopItemRemote item)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MultipleGroupShopGroupView._003C_003Ec::_003CInnerInit_003Eb__5_0");
				return default;
			}

			internal string _003CInnerInit_003Eb__5_2(ShopItemRemote item)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MultipleGroupShopGroupView._003C_003Ec::_003CInnerInit_003Eb__5_2");
				return default;
			}
		}

		[SerializeField]
		[Token(Token = "0x40017A9")]
		[FieldOffset(Offset = "0x70")]
		private GenericElementVisualizer m_visualizerPrefab;

		[SerializeField]
		[Token(Token = "0x40017AA")]
		[FieldOffset(Offset = "0x78")]
		private Image m_coinIcon;

		[SerializeField]
		[Token(Token = "0x40017AB")]
		[FieldOffset(Offset = "0x80")]
		private TextView m_coinAmount;

		[SerializeField]
		[Token(Token = "0x40017AC")]
		[FieldOffset(Offset = "0x88")]
		private Transform[] m_containers;

		[Inject(false)]
		[Token(Token = "0x40017AD")]
		[FieldOffset(Offset = "0x90")]
		private new ShopVisualHub _shopVisualHub;

		[Token(Token = "0x6001DC4")]
		[Address(RVA = "0x3D7C8A8", Offset = "0x3D7C8A8", Length = "0x720")]
		protected override void InnerInit()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MultipleGroupShopGroupView::InnerInit");
		}

		[Token(Token = "0x6001DC5")]
		[Address(RVA = "0x3D7CFD0", Offset = "0x3D7CFD0", Length = "0x8")]
		public MultipleGroupShopGroupView()
		{
		}
	}
}
