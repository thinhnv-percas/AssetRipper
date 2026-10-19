using System;
using Cpp2ILInjected;
using Unco.UncoButtonSystem;
using UnityEngine;

namespace _game.Systems.SettingsSystem.UI
{
	[Token(Token = "0x2000789")]
	public class SettingsButton : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x400190F")]
		[FieldOffset(Offset = "0x20")]
		private GameObject m_line;

		[SerializeField]
		[Token(Token = "0x4001910")]
		[FieldOffset(Offset = "0x28")]
		private UncoButton m_btn;

		[Token(Token = "0x6001FD5")]
		[Address(RVA = "0x3D94544", Offset = "0x3D94544", Length = "0x118")]
		public void Init(Func<bool> onClick, bool initialState)
		{
			Action clickAction = delegate
			{
				//IL_0015: Expected O, but got I4
				object obj = onClick();
				SettingsButton settingsButton = this;
				GameObject gameObject2 = settingsButton.m_line.gameObject;
				bool active2 = (byte)((nint)obj ^ 1) != 0;
				gameObject2.SetActive(active2);
			};
			m_btn.AddListener(clickAction, removeAllListener: true, deactivateAfterClick: false);
			GameObject gameObject = m_line.gameObject;
			bool active = (byte)((initialState ? 1u : 0u) ^ 1u) != 0;
			gameObject.SetActive(active);
		}

		[Token(Token = "0x6001FD6")]
		[Address(RVA = "0x3D94664", Offset = "0x3D94664", Length = "0x3C")]
		public void SetActive(bool active)
		{
			GameObject gameObject = m_line.gameObject;
			bool active2 = (byte)((active ? 1u : 0u) ^ 1u) != 0;
			gameObject.SetActive(active2);
		}

		[Token(Token = "0x6001FD7")]
		[Address(RVA = "0x3D946A0", Offset = "0x3D946A0", Length = "0x8")]
		public SettingsButton()
		{
		}
	}
}
