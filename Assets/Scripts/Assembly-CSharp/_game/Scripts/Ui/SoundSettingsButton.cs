using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.SettingsSystem.Core;
using Unco.UncoButtonSystem;
using UnityEngine;

namespace _game.Scripts.Ui
{
	[Token(Token = "0x2000705")]
	public class SoundSettingsButton : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x400178A")]
		[FieldOffset(Offset = "0x20")]
		private GameObject m_inactiveIcon;

		[SerializeField]
		[Token(Token = "0x400178B")]
		[FieldOffset(Offset = "0x28")]
		private UncoButton m_button;

		[Inject(false)]
		[Token(Token = "0x400178C")]
		[FieldOffset(Offset = "0x30")]
		private SettingsManager _settingsManager;

		[Inject(false)]
		[Token(Token = "0x6001DA0")]
		[Address(RVA = "0x3D7B6B0", Offset = "0x3D7B6B0", Length = "0xC8")]
		public void Inject()
		{
			bool flag = _settingsManager.IsEnabled(SettingsFlags.Sound);
			bool active = (byte)((flag ? 1u : 0u) ^ 1u) != 0;
			m_inactiveIcon.SetActive(active);
			Action clickAction = delegate
			{
				bool flag2 = _settingsManager.IsEnabled(SettingsFlags.Sound);
				int sound = (flag2 ? 1 : 0) ^ 1;
				_settingsManager.SetSound(sound);
				bool flag3 = _settingsManager.IsEnabled(SettingsFlags.Sound);
				bool active2 = (byte)((flag3 ? 1u : 0u) ^ 1u) != 0;
				m_inactiveIcon.SetActive(active2);
			};
			m_button.AddListener(clickAction, removeAllListener: true, deactivateAfterClick: false);
		}

		[Token(Token = "0x6001DA1")]
		[Address(RVA = "0x3D7B778", Offset = "0x3D7B778", Length = "0x48")]
		private void InitVisual()
		{
			bool flag = _settingsManager.IsEnabled(SettingsFlags.Sound);
			bool active = (byte)((flag ? 1u : 0u) ^ 1u) != 0;
			m_inactiveIcon.SetActive(active);
		}

		[Token(Token = "0x6001DA2")]
		[Address(RVA = "0x3D7B7C0", Offset = "0x3D7B7C0", Length = "0x8")]
		public SoundSettingsButton()
		{
		}
	}
}
