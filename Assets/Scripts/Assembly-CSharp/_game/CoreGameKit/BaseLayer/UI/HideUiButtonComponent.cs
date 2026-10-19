using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.UncoButtonSystem;
using UnityEngine;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.BaseLayer.UI
{
	[Token(Token = "0x200063B")]
	public class HideUiButtonComponent : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4001579")]
		[FieldOffset(Offset = "0x20")]
		private UncoButton m_button;

		[Inject(false)]
		[Token(Token = "0x400157A")]
		[FieldOffset(Offset = "0x28")]
		private UiManager _uiManager;

		[Token(Token = "0x400157B")]
		[FieldOffset(Offset = "0x30")]
		private UIController _firstParent;

		[Inject(false)]
		[Token(Token = "0x6001A9B")]
		[Address(RVA = "0x3D556C8", Offset = "0x3D556C8", Length = "0x144")]
		private void Construct()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HideUiButtonComponent::Construct");
		}

		[Token(Token = "0x6001A9C")]
		[Address(RVA = "0x3D5580C", Offset = "0x3D5580C", Length = "0x8")]
		public HideUiButtonComponent()
		{
		}
	}
}
