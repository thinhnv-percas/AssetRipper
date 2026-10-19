using System;
using Cpp2ILInjected;
using Unco.TextViewSystem;
using UnityEngine;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.Ui.UiControllers
{
	[Token(Token = "0x200054A")]
	public class IapFailUiController : UIController
	{
		[SerializeField]
		[Token(Token = "0x40011DA")]
		[FieldOffset(Offset = "0x48")]
		private MultiUncoButtonView m_buttonView;

		[Token(Token = "0x40011DB")]
		[FieldOffset(Offset = "0x50")]
		internal Action _onClose;

		[Token(Token = "0x6001623")]
		[Address(RVA = "0x3D18DD8", Offset = "0x3D18DD8", Length = "0x9C")]
		private void Start()
		{
			Action clickAction = OnDismiss;
			m_buttonView.AddListener(clickAction);
		}

		[Token(Token = "0x6001624")]
		[Address(RVA = "0x3D18E74", Offset = "0x3D18E74", Length = "0x8")]
		public void Init(Action onClose = null)
		{
			_onClose = onClose;
		}

		[Token(Token = "0x6001625")]
		[Address(RVA = "0x3D18E7C", Offset = "0x3D18E7C", Length = "0x44")]
		private void OnDismiss()
		{
			if (_onClose != null)
			{
				_onClose();
			}
			IapFailUiController iapFailUiController = default(IapFailUiController);
			iapFailUiController.Hide();
		}

		[Token(Token = "0x6001626")]
		[Address(RVA = "0x3D18EC0", Offset = "0x3D18EC0", Length = "0x48")]
		public override void Hide()
		{
			m_buttonView.RemoveAllListeners();
			_onClose = null;
			base.Hide();
		}

		[Token(Token = "0x6001627")]
		[Address(RVA = "0x3D18F08", Offset = "0x3D18F08", Length = "0x8")]
		public IapFailUiController()
		{
		}
	}
}
