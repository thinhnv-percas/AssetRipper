using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.GameBootstrap.Core;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;
using _game.CoreGameKit.Ui.UiControllers;
using _game.CoreGameKit.UiControllers;
using _game.CoreSystem.HealthSystem;

namespace _game.CoreGameKit.MenuLayer.PlayTabInstallers
{
	[Token(Token = "0x20005F1")]
	public class MainMenuUiController : UIController
	{
		[SerializeField]
		[Token(Token = "0x4001480")]
		[FieldOffset(Offset = "0x48")]
		private MainMenuLevelItem[] m_levelItems;

		[SerializeField]
		[Token(Token = "0x4001481")]
		[FieldOffset(Offset = "0x50")]
		private MainMenuPlayButton m_playButton;

		[Inject(true)]
		[Token(Token = "0x4001482")]
		[FieldOffset(Offset = "0x58")]
		private HealthController _healthController;

		[Inject(true)]
		[Token(Token = "0x4001483")]
		[FieldOffset(Offset = "0x60")]
		private UiManager _uiManager;

		[Inject(false)]
		[Token(Token = "0x6001974")]
		[Address(RVA = "0x3D48768", Offset = "0x3D48768", Length = "0x4A0")]
		public void Initialize(ILevelProgressService progressService, ILevelList levelList, GameStateController gameStateController)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MainMenuUiController::Initialize");
		}

		[Token(Token = "0x6001975")]
		[Address(RVA = "0x3D48C10", Offset = "0x3D48C10", Length = "0x88")]
		private LevelDifficulty DifficultyMapper(LevelDifficulty difficulty)
		{
			LevelDifficulty result;
			if (difficulty != LevelDifficulty.Medium)
			{
				bool flag = difficulty == LevelDifficulty.Null;
				bool flag2 = !flag;
				result = difficulty;
				if (flag2)
				{
					goto IL_0074;
				}
				Debug.LogWarning("[MainMenu] Level difficulty is null");
			}
			result = LevelDifficulty.Easy;
			goto IL_0074;
			IL_0074:
			return result;
		}

		[Token(Token = "0x6001976")]
		[Address(RVA = "0x3D48C98", Offset = "0x3D48C98", Length = "0x8")]
		public MainMenuUiController()
		{
		}
	}
}
