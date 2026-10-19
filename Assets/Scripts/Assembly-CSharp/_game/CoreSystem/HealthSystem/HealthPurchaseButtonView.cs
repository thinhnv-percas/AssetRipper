using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.UncoButtonSystem;
using UnityEngine;
using _game.CoreGameKit.CoreSerivces.HoveringTextSystem;
using _game.CoreGameKit.Ui.UiControllers;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreSystem.HealthSystem
{
	[Token(Token = "0x20004CF")]
	public class HealthPurchaseButtonView : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4001020")]
		[FieldOffset(Offset = "0x20")]
		private UncoButton m_button;

		[Inject(true)]
		[Token(Token = "0x4001021")]
		[FieldOffset(Offset = "0x28")]
		private HoveringTextController _hoveringTextController;

		[Token(Token = "0x4001022")]
		[FieldOffset(Offset = "0x30")]
		private HealthController _healthController;

		[Token(Token = "0x4001023")]
		[FieldOffset(Offset = "0x38")]
		private UiManager _uiManager;

		[Inject(false)]
		[Token(Token = "0x6001455")]
		[Address(RVA = "0x3CF4808", Offset = "0x3CF4808", Length = "0xCC")]
		private void Construct(HealthController healthController, UiManager uiManager)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HealthPurchaseButtonView::Construct");
		}

		[Token(Token = "0x6001456")]
		[Address(RVA = "0x3CF48D4", Offset = "0x3CF48D4", Length = "0x184")]
		private void OnClick()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HealthPurchaseButtonView::OnClick");
		}

		[Token(Token = "0x6001457")]
		[Address(RVA = "0x3CF4A58", Offset = "0x3CF4A58", Length = "0x8")]
		public HealthPurchaseButtonView()
		{
		}
	}
}
