using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.ContainerSystem.Runtime;
using Unco.UncoButtonSystem;
using UnityEngine;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;
using _game.CoreGameKit.MenuLayer;
using _game.CoreGameKit.Ui.UiControllers;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.Ui.CustomButtons
{
	[Token(Token = "0x2000566")]
	public class TabNavigationButton : MonoBehaviour
	{
		[Token(Token = "0x4001278")]
		private const int HOVERING_SHOP_UNLOCK_LEVEL = 11;

		[SerializeField]
		[Token(Token = "0x4001279")]
		[FieldOffset(Offset = "0x20")]
		private HomeTabId m_landTabId;

		[SerializeField]
		[Token(Token = "0x400127A")]
		[FieldOffset(Offset = "0x28")]
		private UncoButton m_uncoButton;

		[SerializeField]
		[Token(Token = "0x400127B")]
		[FieldOffset(Offset = "0x30")]
		private GameObject m_plusIcon;

		[SerializeField]
		[Token(Token = "0x400127C")]
		[FieldOffset(Offset = "0x38")]
		private bool m_isHovering;

		[Inject(false)]
		[Token(Token = "0x400127D")]
		[FieldOffset(Offset = "0x40")]
		private UiManager _uiManager;

		[Inject(false)]
		[Token(Token = "0x60016A9")]
		[Address(RVA = "0x3D1F79C", Offset = "0x3D1F79C", Length = "0x1BC")]
		private void Construct(Instancer instancer, ILevelProgressService levelProgressService)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TabNavigationButton::Construct");
		}

		[Token(Token = "0x60016AA")]
		[Address(RVA = "0x3D1F960", Offset = "0x3D1F960", Length = "0x8")]
		public TabNavigationButton()
		{
		}
	}
}
