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
	[Token(Token = "0x200064A")]
	public class SettingsButtonPopUpController : UIController
	{
		[SerializeField]
		[Token(Token = "0x4001598")]
		[FieldOffset(Offset = "0x48")]
		private UncoButton m_settingsButton;

		[Inject(false)]
		[Token(Token = "0x6001ABF")]
		[Address(RVA = "0x3D564DC", Offset = "0x3D564DC", Length = "0x128")]
		private void Construct(UiManager uiManager, BaseLayerWaitState waitState, BaseLayerStateMachine stateMachine, InputBlockService inputBlockService)
		{
			Action clickAction = delegate
			{
				if (!inputBlockService.IsBlocked(InputChannel.SettingsButton))
				{
					stateMachine.SetState(waitState);
					BaseLayerSettingsUiController baseLayerSettingsUiController = uiManager.Show<BaseLayerSettingsUiController>();
				}
			};
			m_settingsButton.AddListener(clickAction, removeAllListener: true, deactivateAfterClick: false);
		}

		[Token(Token = "0x6001AC0")]
		[Address(RVA = "0x3D5660C", Offset = "0x3D5660C", Length = "0x8")]
		public SettingsButtonPopUpController()
		{
		}
	}
}
