using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;
using _game.CoreGameKit.Ui.UiControllers;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Serializable]
	[Token(Token = "0x2000697")]
	public class BaseLayerLevelDifficultyPopUp : IBaseLayerIntroElement
	{
		[SerializeField]
		[Token(Token = "0x400167C")]
		[FieldOffset(Offset = "0x10")]
		private LevelDifficulty[] m_shownDifficulties;

		[Token(Token = "0x400167D")]
		[FieldOffset(Offset = "0x18")]
		private ILevel _level;

		[Token(Token = "0x400167E")]
		[FieldOffset(Offset = "0x20")]
		private UiManager _uiFactory;

		[Token(Token = "0x6001BF0")]
		[Address(RVA = "0x3D65FC4", Offset = "0x3D65FC4", Length = "0x34")]
		private BaseLayerLevelDifficultyPopUp(LevelDifficulty[] shownDifficulties)
		{
			m_shownDifficulties = shownDifficulties;
		}

		[Token(Token = "0x6001BF1")]
		[Address(RVA = "0x3D65FF8", Offset = "0x3D65FF8", Length = "0x78")]
		public IBaseLayerIntroElement GetInstance()
		{
			return new BaseLayerLevelDifficultyPopUp(m_shownDifficulties);
		}

		[Inject(false)]
		[Token(Token = "0x6001BF2")]
		[Address(RVA = "0x3D66070", Offset = "0x3D66070", Length = "0x34")]
		public void Initialize(ILevel level, UiManager uiFactory)
		{
			_level = level;
			_uiFactory = uiFactory;
		}

		[Token(Token = "0x6001BF3")]
		[Address(RVA = "0x3D660A4", Offset = "0x3D660A4", Length = "0x1D0")]
		public void Play(Action onComplete)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerLevelDifficultyPopUp::Play");
		}

		[Token(Token = "0x6001BF4")]
		[Address(RVA = "0x3D66274", Offset = "0x3D66274", Length = "0x54")]
		public void Stop()
		{
			_uiFactory.ForceHideIfExist<FeatureUnlockedUiController>();
		}
	}
}
