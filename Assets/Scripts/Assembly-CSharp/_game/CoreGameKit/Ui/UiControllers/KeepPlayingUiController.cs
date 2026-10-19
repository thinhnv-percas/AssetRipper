using System;
using Cpp2ILInjected;
using Unco.TextViewSystem;
using Unco.UncoButtonSystem;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.UI;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.Ui.UiControllers
{
	[Token(Token = "0x200054C")]
	public class KeepPlayingUiController : UIController
	{
		[SerializeField]
		[Token(Token = "0x40011DC")]
		[FieldOffset(Offset = "0x48")]
		private UncoButton m_continueButton;

		[SerializeField]
		[Token(Token = "0x40011DD")]
		[FieldOffset(Offset = "0x50")]
		private TextView m_costText;

		[SerializeField]
		[Token(Token = "0x40011DE")]
		[FieldOffset(Offset = "0x58")]
		private InvokeKeepPlayingClickedEventComponent m_onContinue;

		[Token(Token = "0x40011DF")]
		[FieldOffset(Offset = "0x60")]
		private Action _onContinue;

		[Token(Token = "0x6001629")]
		[Address(RVA = "0x3D18F18", Offset = "0x3D18F18", Length = "0xEC")]
		public void Init(int cost, Action onContinue)
		{
			int num = cost;
			_onContinue = onContinue;
			string text = num.ToString();
			m_costText.SetText(text);
			Action clickAction = OnContinueClicked;
			m_continueButton.AddListener(clickAction, removeAllListener: true, deactivateAfterClick: false);
		}

		[Token(Token = "0x600162A")]
		[Address(RVA = "0x3D19004", Offset = "0x3D19004", Length = "0x50")]
		private void OnContinueClicked()
		{
			m_onContinue.ServiceCalled();
			if (_onContinue != null)
			{
				_onContinue();
			}
		}

		[Token(Token = "0x600162B")]
		[Address(RVA = "0x3D19054", Offset = "0x3D19054", Length = "0x48")]
		public override void Hide()
		{
			m_continueButton.RemoveAllListeners();
			_onContinue = null;
			base.Hide();
		}

		[Token(Token = "0x600162C")]
		[Address(RVA = "0x3D1909C", Offset = "0x3D1909C", Length = "0x8")]
		public KeepPlayingUiController()
		{
		}
	}
}
