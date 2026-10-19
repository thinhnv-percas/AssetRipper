using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using Unco.UncoButtonSystem;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Controller;

namespace _game.CoreGameKit.BaseLayer.UI
{
	[Token(Token = "0x2000635")]
	public class BaseLayerSettingsPanelController : MonoBehaviour
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000636")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400156B")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400156C")]
			public static Action<Transform> _003C_003E9__6_0;

			[Token(Token = "0x6001A90")]
			[Address(RVA = "0x3D55118", Offset = "0x3D55118", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001A91")]
			[Address(RVA = "0x3D5517C", Offset = "0x3D5517C", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal void _003CDisableSettingsButtons_003Eb__6_0(Transform button)
			{
				GameObject gameObject = button.gameObject;
				gameObject.SetActive(value: false);
			}
		}

		[SerializeField]
		[Token(Token = "0x4001566")]
		[FieldOffset(Offset = "0x20")]
		private Transform m_buttonParent;

		[SerializeField]
		[Token(Token = "0x4001567")]
		[FieldOffset(Offset = "0x28")]
		private UncoButton m_settingsButton;

		[SerializeField]
		[Token(Token = "0x4001568")]
		[FieldOffset(Offset = "0x30")]
		private GameObject m_gameBlocker;

		[Token(Token = "0x4001569")]
		[FieldOffset(Offset = "0x38")]
		private Sequence _sequence;

		[Token(Token = "0x400156A")]
		[FieldOffset(Offset = "0x48")]
		private BaseLayerTimerController _timerController;

		[Inject(true)]
		[Token(Token = "0x6001A89")]
		[Address(RVA = "0x3D54550", Offset = "0x3D54550", Length = "0x150")]
		public void Initialize(BaseLayerTimerController timerController)
		{
			BaseLayerTimerController timerController2 = default(BaseLayerTimerController);
			_timerController = timerController2;
			Action clickAction = OnSettingsClicked;
			m_settingsButton.AddListener(clickAction);
			if (m_gameBlocker != null)
			{
				m_gameBlocker.SetActive(value: false);
			}
			DisableSettingsButtons(animate: false);
		}

		[Token(Token = "0x6001A8A")]
		[Address(RVA = "0x3D54760", Offset = "0x3D54760", Length = "0x55C")]
		private void DisableSettingsButtons(bool animate)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerSettingsPanelController::DisableSettingsButtons");
		}

		[Token(Token = "0x6001A8B")]
		[Address(RVA = "0x3D54CBC", Offset = "0x3D54CBC", Length = "0x1BC")]
		private void EnableSettingsButtons()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerSettingsPanelController::EnableSettingsButtons");
		}

		[Token(Token = "0x6001A8C")]
		[Address(RVA = "0x3D54E78", Offset = "0x3D54E78", Length = "0x158")]
		private void OnSettingsClosed()
		{
			if (_timerController != null)
			{
				_timerController.Resume();
			}
			Action clickAction = OnSettingsClicked;
			m_settingsButton.AddListener(clickAction);
			if (!(m_gameBlocker != null))
			{
				DisableSettingsButtons(animate: true);
				return;
			}
			m_gameBlocker.SetActive(value: false);
			DisableSettingsButtons(animate: true);
		}

		[Token(Token = "0x6001A8D")]
		[Address(RVA = "0x3D54FD0", Offset = "0x3D54FD0", Length = "0x140")]
		private void OnSettingsClicked()
		{
			if (_timerController != null)
			{
				_timerController.Pause();
			}
			if (m_gameBlocker != null)
			{
				m_gameBlocker.SetActive(value: true);
			}
			Action clickAction = OnSettingsClosed;
			m_settingsButton.AddListener(clickAction);
			EnableSettingsButtons();
		}

		[Token(Token = "0x6001A8E")]
		[Address(RVA = "0x3D546A0", Offset = "0x3D546A0", Length = "0xC0")]
		private void SetBlockerActive(bool isActive)
		{
			if (m_gameBlocker != null)
			{
				m_gameBlocker.SetActive(isActive);
			}
		}

		[Token(Token = "0x6001A8F")]
		[Address(RVA = "0x3D55110", Offset = "0x3D55110", Length = "0x8")]
		public BaseLayerSettingsPanelController()
		{
		}
	}
}
