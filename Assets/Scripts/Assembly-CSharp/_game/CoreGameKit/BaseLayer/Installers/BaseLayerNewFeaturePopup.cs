using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.Extensions;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;
using _game.CoreGameKit.Ui.UiControllers;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Serializable]
	[Token(Token = "0x2000698")]
	public class BaseLayerNewFeaturePopup : IBaseLayerIntroElement
	{
		[Token(Token = "0x400167F")]
		[FieldOffset(Offset = "0x10")]
		private ILevel _level;

		[Token(Token = "0x4001680")]
		[FieldOffset(Offset = "0x18")]
		private UiManager _uiFactory;

		[Token(Token = "0x6001BF5")]
		[Address(RVA = "0x3D662C8", Offset = "0x3D662C8", Length = "0x58")]
		public IBaseLayerIntroElement GetInstance()
		{
			return new BaseLayerNewFeaturePopup();
		}

		[Inject(false)]
		[Token(Token = "0x6001BF6")]
		[Address(RVA = "0x3D66328", Offset = "0x3D66328", Length = "0x34")]
		public void Initialize(ILevel level, UiManager uiFactory)
		{
			_level = level;
			_uiFactory = uiFactory;
		}

		[Token(Token = "0x6001BF7")]
		[Address(RVA = "0x3D6635C", Offset = "0x3D6635C", Length = "0x174")]
		public void Play(Action onComplete)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerNewFeaturePopup::Play");
		}

		[Token(Token = "0x6001BF8")]
		[Address(RVA = "0x3D664D0", Offset = "0x3D664D0", Length = "0x54")]
		public void Stop()
		{
			_uiFactory.ForceHideIfExist<FeatureUnlockedUiController>();
		}

		[Token(Token = "0x6001BF9")]
		[Address(RVA = "0x3D66320", Offset = "0x3D66320", Length = "0x8")]
		public BaseLayerNewFeaturePopup()
		{
		}
	}
}
