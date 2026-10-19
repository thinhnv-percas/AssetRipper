using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.GameBootstrap.Core;
using Unco.TextViewSystem;
using Unco.UncoButtonSystem;
using Unco.Utils;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;
using _game.CoreGameKit.Ui.UiControllers;
using _game.CoreGameKit.UiControllers;
using _game.CoreSystem.HealthSystem;

namespace _game.CoreGameKit.MenuLayer.PlayTabInstallers
{
	[Token(Token = "0x20005EC")]
	public class HomeUiLevelController : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4001472")]
		[FieldOffset(Offset = "0x20")]
		public TextView m_levelText;

		[SerializeField]
		[Token(Token = "0x4001473")]
		[FieldOffset(Offset = "0x28")]
		public UncoButton m_playButton;

		[SerializeField]
		[Token(Token = "0x4001474")]
		[FieldOffset(Offset = "0x30")]
		private ComponentStateHandler m_componentStateHandler;

		[SerializeField]
		[Token(Token = "0x4001475")]
		[FieldOffset(Offset = "0x38")]
		private TextView m_levelDifficultyText;

		[Inject(true)]
		[Token(Token = "0x4001476")]
		[FieldOffset(Offset = "0x40")]
		private HealthController _healthController;

		[Inject(true)]
		[Token(Token = "0x4001477")]
		[FieldOffset(Offset = "0x48")]
		private UiManager _uiManager;

		[Inject(false)]
		[Token(Token = "0x6001968")]
		[Address(RVA = "0x3D47F68", Offset = "0x3D47F68", Length = "0x354")]
		public void InitializeText(ILevelProgressService progressService, ILevelList levelList, GameStateController layerController)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HomeUiLevelController::InitializeText");
		}

		[Token(Token = "0x6001969")]
		[Address(RVA = "0x3D482BC", Offset = "0x3D482BC", Length = "0xF4")]
		public void InitializeButton(GameStateController layerController)
		{
			Action clickAction = delegate
			{
				HomeUiLevelController homeUiLevelController = this;
				if (homeUiLevelController._healthController.CanPlay())
				{
					layerController.StartBaseLayer();
				}
				else
				{
					HomeUiLevelController homeUiLevelController2 = this;
					if (homeUiLevelController2._uiManager != null)
					{
						RefillHeartsUiController refillHeartsUiController = homeUiLevelController2._uiManager.Show<RefillHeartsUiController>();
					}
				}
			};
			m_playButton.AddListener(clickAction);
		}

		[Token(Token = "0x600196A")]
		[Address(RVA = "0x3D483B8", Offset = "0x3D483B8", Length = "0x8")]
		public HomeUiLevelController()
		{
		}
	}
}
