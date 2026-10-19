using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.SettingsSyste.Core;
using Unco.UncoButtonSystem;
using UnityEngine;

namespace _game.Scripts.Ui
{
	[Token(Token = "0x2000702")]
	public class HapticSettingsButton : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x400177C")]
		[FieldOffset(Offset = "0x20")]
		private GameObject m_inactiveIcon;

		[SerializeField]
		[Token(Token = "0x400177D")]
		[FieldOffset(Offset = "0x28")]
		private UncoButton m_button;

		[Token(Token = "0x400177E")]
		[FieldOffset(Offset = "0x30")]
		private HapticManager _hapticManager;

		[Inject(false)]
		[Token(Token = "0x6001D8B")]
		[Address(RVA = "0x3D7A5CC", Offset = "0x3D7A5CC", Length = "0xDC")]
		public void Inject(HapticManager hapticManager)
		{
			HapticManager hapticManager2 = default(HapticManager);
			_hapticManager = hapticManager2;
			bool flag = _hapticManager.IsHapticsEnabled();
			bool active = (byte)((flag ? 1u : 0u) ^ 1u) != 0;
			m_inactiveIcon.SetActive(active);
			Action clickAction = delegate
			{
				bool flag2 = _hapticManager.IsHapticsEnabled();
				bool hapticsEnabled = (byte)((flag2 ? 1u : 0u) ^ 1u) != 0;
				_hapticManager.SetHapticsEnabled(hapticsEnabled);
				bool flag3 = _hapticManager.IsHapticsEnabled();
				bool active2 = (byte)((flag3 ? 1u : 0u) ^ 1u) != 0;
				m_inactiveIcon.SetActive(active2);
			};
			m_button.AddListener(clickAction, removeAllListener: true, deactivateAfterClick: false);
		}

		[Token(Token = "0x6001D8C")]
		[Address(RVA = "0x3D7A6A8", Offset = "0x3D7A6A8", Length = "0x44")]
		private void InitVisual()
		{
			bool flag = _hapticManager.IsHapticsEnabled();
			bool active = (byte)((flag ? 1u : 0u) ^ 1u) != 0;
			m_inactiveIcon.SetActive(active);
		}

		[Token(Token = "0x6001D8D")]
		[Address(RVA = "0x3D7A6EC", Offset = "0x3D7A6EC", Length = "0x8")]
		public HapticSettingsButton()
		{
		}
	}
}
