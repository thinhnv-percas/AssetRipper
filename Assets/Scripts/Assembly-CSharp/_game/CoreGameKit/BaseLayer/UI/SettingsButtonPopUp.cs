using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.UncoButtonSystem;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;
using _game.CoreGameKit.BaseLayer.Services;
using _game.CoreGameKit.Ui.UiControllers;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.BaseLayer.UI
{
	[Token(Token = "0x2000648")]
	public class SettingsButtonPopUp : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4001594")]
		[FieldOffset(Offset = "0x20")]
		private UncoButton m_settingsButton;

		[Inject(false)]
		[Token(Token = "0x4001595")]
		[FieldOffset(Offset = "0x28")]
		private InputBlockService _inputBlockService;

		[Inject(false)]
		[Token(Token = "0x6001ABB")]
		[Address(RVA = "0x3D561C8", Offset = "0x3D561C8", Length = "0xF4")]
		private void Construct(UiManager uiManager, BaseLayerStateMachine stateMachine)
		{
			Action clickAction = delegate
			{
				SettingsButtonPopUp settingsButtonPopUp = this;
				if (!settingsButtonPopUp._inputBlockService.IsBlocked(InputChannel.SettingsButton))
				{
					BaseLayerSettingsUiController baseLayerSettingsUiController = uiManager.Show<BaseLayerSettingsUiController>();
				}
			};
			m_settingsButton.AddListener(clickAction, removeAllListener: true, deactivateAfterClick: false);
		}

		[Token(Token = "0x6001ABC")]
		[Address(RVA = "0x3D562C4", Offset = "0x3D562C4", Length = "0x8")]
		public SettingsButtonPopUp()
		{
		}
	}
}
