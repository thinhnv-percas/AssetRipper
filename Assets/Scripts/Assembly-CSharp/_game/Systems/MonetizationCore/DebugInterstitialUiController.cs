using System;
using Cpp2ILInjected;
using Unco.UncoButtonSystem;
using UnityEngine;
using _game.CoreGameKit.UiControllers;

namespace _game.Systems.MonetizationCore
{
	[Token(Token = "0x200076C")]
	public class DebugInterstitialUiController : UIController
	{
		[SerializeField]
		[Token(Token = "0x40018C3")]
		[FieldOffset(Offset = "0x48")]
		private UncoButton m_dismissButton;

		[Token(Token = "0x40018C4")]
		[FieldOffset(Offset = "0x50")]
		private Action _onDismissed;

		[Token(Token = "0x6001F4A")]
		[Address(RVA = "0x3D8DE98", Offset = "0x3D8DE98", Length = "0x114")]
		public void Initialize(Action onDismissed)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DebugInterstitialUiController::Initialize");
		}

		[Token(Token = "0x6001F4B")]
		[Address(RVA = "0x3D8DFAC", Offset = "0x3D8DFAC", Length = "0xF8")]
		private void OnDismissClicked()
		{
			_onDismissed = null;
			if (!(m_dismissButton != null))
			{
				base.Hide();
				if (_onDismissed == null)
				{
					return;
				}
			}
			else
			{
				m_dismissButton.RemoveAllListeners();
				base.Hide();
				if (_onDismissed == null)
				{
					return;
				}
			}
			_onDismissed();
		}

		[Token(Token = "0x6001F4C")]
		[Address(RVA = "0x3D8E0A4", Offset = "0x3D8E0A4", Length = "0x8")]
		public DebugInterstitialUiController()
		{
		}
	}
}
