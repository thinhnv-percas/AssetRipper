using System;
using Cpp2ILInjected;
using Unco.UncoButtonSystem;
using Unco.Utils;
using UnityEngine;
using UnityEngine.UI;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;

namespace _game.CoreGameKit.MenuLayer.PlayTabInstallers
{
	[Token(Token = "0x20005F0")]
	public class MainMenuPlayButton : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x400147D")]
		[FieldOffset(Offset = "0x20")]
		internal UncoButton m_playButton;

		[SerializeField]
		[Token(Token = "0x400147E")]
		[FieldOffset(Offset = "0x28")]
		private Image m_buttonBackground;

		[SerializeField]
		[Token(Token = "0x400147F")]
		[FieldOffset(Offset = "0x30")]
		private Pair<LevelDifficulty, GameObject>[] m_difficultyViews;

		[Token(Token = "0x6001971")]
		[Address(RVA = "0x3D48738", Offset = "0x3D48738", Length = "0x4")]
		public void SetDifficulty(LevelDifficulty difficulty)
		{
		}

		[Token(Token = "0x6001972")]
		[Address(RVA = "0x3D4873C", Offset = "0x3D4873C", Length = "0x24")]
		public void SetClickAction(Action onClick)
		{
			m_playButton.AddListener(onClick, removeAllListener: true, deactivateAfterClick: false);
		}

		[Token(Token = "0x6001973")]
		[Address(RVA = "0x3D48760", Offset = "0x3D48760", Length = "0x8")]
		public MainMenuPlayButton()
		{
		}
	}
}
