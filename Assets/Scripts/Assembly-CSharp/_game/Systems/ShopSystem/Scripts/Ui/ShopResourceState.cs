using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.RewardSystem;
using Unco.TextViewSystem;
using Unco.Utils;
using UnityEngine;
using UnityEngine.UI;
using _game.Systems.ShopSystem.Scripts.Core;

namespace _game.Systems.ShopSystem.Scripts.Ui
{
	[Token(Token = "0x200070A")]
	public class ShopResourceState : GenericElementVisualizerState
	{
		[SerializeField]
		[Token(Token = "0x4001796")]
		[FieldOffset(Offset = "0x20")]
		private TextView m_text;

		[SerializeField]
		[Token(Token = "0x4001797")]
		[FieldOffset(Offset = "0x28")]
		private Image m_icon;

		[SerializeField]
		[Token(Token = "0x4001798")]
		[FieldOffset(Offset = "0x30")]
		private Image m_frame;

		[Inject(false)]
		[Token(Token = "0x4001799")]
		[FieldOffset(Offset = "0x38")]
		private ShopVisualHub _shopVisualHub;

		[Token(Token = "0x6001DB5")]
		[Address(RVA = "0x3D7BE50", Offset = "0x3D7BE50", Length = "0x18C")]
		public override void Visualize(ShopItemData data)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ShopResourceState::Visualize");
		}

		[Token(Token = "0x6001DB6")]
		[Address(RVA = "0x4CAC83C", Offset = "0x4CAC83C", Length = "0x84")]
		public override bool IsTypeOf<T>(T shopItemData)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ShopResourceState::IsTypeOf");
			return default;
		}

		[Token(Token = "0x6001DB7")]
		[Address(RVA = "0x3D7C1B8", Offset = "0x3D7C1B8", Length = "0x8")]
		public ShopResourceState()
		{
		}
	}
}
