using Systems.ShopSystem.Scripts.Core;
using Systems.ShopSystem.Scripts.Ui.ShopGroups;
using Cpp2ILInjected;
using Unco.TextViewSystem;
using Unco.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace _game.Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopPacks
{
	[Token(Token = "0x200070E")]
	public class LineShopView : ShopGroupView
	{
		[SerializeField]
		[Token(Token = "0x40017A7")]
		[FieldOffset(Offset = "0x70")]
		private Image m_image;

		[SerializeField]
		[Token(Token = "0x40017A8")]
		[FieldOffset(Offset = "0x78")]
		private TextView m_amount;

		[Token(Token = "0x6001DC2")]
		[Address(RVA = "0x3D7C7C0", Offset = "0x3D7C7C0", Length = "0xE0")]
		protected override void InnerInit()
		{
			ShopGroupRemote config = _config;
			ShopItemRemote[] shopItems = config.shopItems;
			ShopItemRemote shopItemRemote = shopItems[0];
			Sprite shopIcon = _shopVisualHub.GetShopIcon(config.groupKey);
			m_image.sprite = shopIcon;
			string text = NumberConverter.Format(shopItemRemote.lootDrop.Amount);
			TextView textView = default(TextView);
			textView.SetText(text);
		}

		[Token(Token = "0x6001DC3")]
		[Address(RVA = "0x3D7C8A0", Offset = "0x3D7C8A0", Length = "0x8")]
		public LineShopView()
		{
		}
	}
}
