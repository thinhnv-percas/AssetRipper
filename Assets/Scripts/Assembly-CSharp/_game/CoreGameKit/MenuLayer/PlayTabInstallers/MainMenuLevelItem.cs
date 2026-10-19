using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.UText.External.TextViewSystem;
using Unco.Utils;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;

namespace _game.CoreGameKit.MenuLayer.PlayTabInstallers
{
	[Token(Token = "0x20005EE")]
	public class MainMenuLevelItem : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x20005EF")]
		private sealed class _003C_003Ec__DisplayClass2_0
		{
			[Token(Token = "0x400147C")]
			[FieldOffset(Offset = "0x10")]
			public LevelDifficulty difficulty;

			[Token(Token = "0x600196F")]
			[Address(RVA = "0x3D48718", Offset = "0x3D48718", Length = "0x8")]
			public _003C_003Ec__DisplayClass2_0()
			{
			}

			internal bool _003CSetLevelData_003Eb__0(Pair<LevelDifficulty, UTextView> pair)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MainMenuLevelItem._003C_003Ec__DisplayClass2_0::_003CSetLevelData_003Eb__0");
				return default;
			}
		}

		[SerializeField]
		[Token(Token = "0x400147A")]
		[FieldOffset(Offset = "0x20")]
		private Pair<LevelDifficulty, GameObject>[] m_difficultyViews;

		[SerializeField]
		[Token(Token = "0x400147B")]
		[FieldOffset(Offset = "0x28")]
		private List<Pair<LevelDifficulty, UTextView>> m_levelNumberTexts;

		[Token(Token = "0x600196D")]
		[Address(RVA = "0x3D48460", Offset = "0x3D48460", Length = "0x2B8")]
		public unsafe void SetLevelData(int levelNumber, LevelDifficulty difficulty)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MainMenuLevelItem::SetLevelData");
		}

		[Token(Token = "0x600196E")]
		[Address(RVA = "0x3D48720", Offset = "0x3D48720", Length = "0x8")]
		public MainMenuLevelItem()
		{
		}
	}
}
