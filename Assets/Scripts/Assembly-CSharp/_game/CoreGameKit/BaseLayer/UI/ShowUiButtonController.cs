using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.UncoButtonSystem;
using UnityEngine;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.BaseLayer.UI
{
	[Token(Token = "0x2000647")]
	public class ShowUiButtonController : ServiceButtonComponent
	{
		[SerializeField]
		[Token(Token = "0x4001591")]
		[FieldOffset(Offset = "0x20")]
		private UncoButton m_button;

		[SerializeField]
		[Token(Token = "0x4001592")]
		[FieldOffset(Offset = "0x28")]
		private UIController m_uiController;

		[Inject(false)]
		[Token(Token = "0x4001593")]
		[FieldOffset(Offset = "0x30")]
		private UiManager _uiManager;

		[Inject(false)]
		[Token(Token = "0x6001AB8")]
		[Address(RVA = "0x3D560E0", Offset = "0x3D560E0", Length = "0x9C")]
		private void Construct()
		{
			Action clickAction = base.InvokeClick;
			m_button.AddListener(clickAction);
		}

		[Token(Token = "0x6001AB9")]
		[Address(RVA = "0x3D5617C", Offset = "0x3D5617C", Length = "0x44")]
		protected override void OnInvoke()
		{
			Type type = m_uiController.GetType();
			UIController uIController = _uiManager.Show(type);
		}

		[Token(Token = "0x6001ABA")]
		[Address(RVA = "0x3D561C0", Offset = "0x3D561C0", Length = "0x8")]
		public ShowUiButtonController()
		{
		}
	}
}
