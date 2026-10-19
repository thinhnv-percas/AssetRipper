using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.UncoButtonSystem;
using UnityEngine;
using UnityEngine.Serialization;
using _game.CoreGameKit.Ui.UiControllers;
using _game.CoreGameKit.UiControllers;
using _game.CoreSystem.HealthSystem;

namespace _game.CoreGameKit.BaseLayer.UI
{
	[Token(Token = "0x2000638")]
	public class BaseLayerWarnHealthLostButtonController : MonoBehaviour
	{
		[FormerlySerializedAs("m_restartButton")]
		[SerializeField]
		[Token(Token = "0x400156F")]
		[FieldOffset(Offset = "0x20")]
		private UncoButton m_warnButton;

		[SerializeField]
		[Token(Token = "0x4001570")]
		[FieldOffset(Offset = "0x28")]
		private ServiceButtonComponent m_serviceButton;

		[SerializeField]
		[Token(Token = "0x4001571")]
		[FieldOffset(Offset = "0x30")]
		private string m_warningTitleText;

		[SerializeField]
		[Token(Token = "0x4001572")]
		[FieldOffset(Offset = "0x38")]
		private string m_warningContinueButtonText;

		[SerializeField]
		[Token(Token = "0x4001573")]
		[FieldOffset(Offset = "0x40")]
		private ButtonColor m_color;

		[Inject(true)]
		[Token(Token = "0x4001574")]
		[FieldOffset(Offset = "0x48")]
		private HealthController _healthController;

		[Inject(false)]
		[Token(Token = "0x4001575")]
		[FieldOffset(Offset = "0x50")]
		private BaseLayerSessionController _sessionController;

		[Inject(false)]
		[Token(Token = "0x6001A95")]
		[Address(RVA = "0x3D55374", Offset = "0x3D55374", Length = "0xF4")]
		public void InitializeButton(UiManager _uiManager)
		{
			Action clickAction = delegate
			{
				BaseLayerWarnHealthLostButtonController baseLayerWarnHealthLostButtonController = this;
				if (baseLayerWarnHealthLostButtonController._healthController != null)
				{
					bool isInfinite = baseLayerWarnHealthLostButtonController._healthController.IsInfinite;
					baseLayerWarnHealthLostButtonController = this;
					if (isInfinite)
					{
						if ((object)baseLayerWarnHealthLostButtonController == null)
						{
							throw new NullReferenceException();
						}
					}
					else
					{
						BaseLayerSessionController sessionController = baseLayerWarnHealthLostButtonController._sessionController;
						if (!sessionController.RemoveHealthBlocked)
						{
							HealthLostWarningUiController healthLostWarningUiController = _uiManager.Show<HealthLostWarningUiController>();
							BaseLayerWarnHealthLostButtonController baseLayerWarnHealthLostButtonController2 = this;
							Action onContinue = baseLayerWarnHealthLostButtonController2.m_serviceButton.InvokeClick;
							BaseLayerWarnHealthLostButtonController baseLayerWarnHealthLostButtonController3 = this;
							healthLostWarningUiController.Initialize(onContinue, baseLayerWarnHealthLostButtonController3.m_warningTitleText, baseLayerWarnHealthLostButtonController3.m_warningContinueButtonText, baseLayerWarnHealthLostButtonController3.m_color);
							return;
						}
					}
				}
				baseLayerWarnHealthLostButtonController.m_serviceButton.InvokeClick();
			};
			m_warnButton.AddListener(clickAction, removeAllListener: true, deactivateAfterClick: false);
		}

		[Token(Token = "0x6001A96")]
		[Address(RVA = "0x3D55470", Offset = "0x3D55470", Length = "0x8")]
		public BaseLayerWarnHealthLostButtonController()
		{
		}
	}
}
