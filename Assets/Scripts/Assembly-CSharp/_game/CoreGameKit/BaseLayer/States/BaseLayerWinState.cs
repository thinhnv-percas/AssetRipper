using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;
using _game.CoreGameKit.CoreSerivces.FeatureUnlock;
using _game.CoreGameKit.Ui.UiControllers;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.BaseLayer.States
{
	[Serializable]
	[Token(Token = "0x200064D")]
	public class BaseLayerWinState : BaseLayerState
	{
		[Inject(false)]
		[Token(Token = "0x400159E")]
		[FieldOffset(Offset = "0x18")]
		private UiManager _uiManager;

		[Inject(false)]
		[Token(Token = "0x400159F")]
		[FieldOffset(Offset = "0x20")]
		private IFeatureUnlockService _featureUnlockService;

		[Token(Token = "0x6001AC5")]
		[Address(RVA = "0x3D566AC", Offset = "0x3D566AC", Length = "0xEC")]
		public override void OnStateEnter()
		{
			float startProgress = 0f;
			FeatureUnlockData nextUnlockFeature = _featureUnlockService.GetNextUnlockFeature(out var _, out startProgress);
			WinFeatureUiController winFeatureUiController = _uiManager.Show<WinFeatureUiController>();
			base.OnStateEnter();
		}

		[Token(Token = "0x6001AC6")]
		[Address(RVA = "0x3D56798", Offset = "0x3D56798", Length = "0x8")]
		public BaseLayerWinState()
		{
		}
	}
}
