using System;
using System.Collections.Generic;
using Systems.FlowSystem.Scripts.Core;
using Systems.TutorialSystem.Scripts.Data;
using Systems.TutorialSystem.Scripts.UI;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreGameKit.BaseLayer.Boosters;
using _game.CoreGameKit.BaseLayer.Services;
using _game.CoreGameKit.CoreSerivces.BoosterSystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;
using _game.Systems.UncoInput;

namespace _game.CoreGameKit.Flows
{
	[Serializable]
	[Token(Token = "0x2000603")]
	public class VacuumTutorialFlow : BoosterTutorialFlowBase
	{
		[Token(Token = "0x40014C7")]
		private const string VacuumBoosterId = "vacuum_booster";

		[Header("Timing")]
		[SerializeField]
		[Token(Token = "0x40014C8")]
		[FieldOffset(Offset = "0xD0")]
		private float m_initialDelay;

		[SerializeField]
		[Token(Token = "0x40014C9")]
		[FieldOffset(Offset = "0xD4")]
		private float m_conveyorSettleDelay;

		[Header("Conveyor Highlight")]
		[SerializeField]
		[Token(Token = "0x40014CA")]
		[FieldOffset(Offset = "0xD8")]
		private Vector2 m_conveyorHighlightPosition;

		[SerializeField]
		[Token(Token = "0x40014CB")]
		[FieldOffset(Offset = "0xE0")]
		private Vector2 m_conveyorHighlightSize;

		[Header("Speed Up")]
		[SerializeField]
		[Token(Token = "0x40014CC")]
		[FieldOffset(Offset = "0xE8")]
		private float m_speedMultiplier;

		[Header("Target Cubes")]
		[SerializeField]
		[Token(Token = "0x40014CD")]
		[FieldOffset(Offset = "0xF0")]
		private Vector2Int[] m_targetCubeGridPositions;

		[Inject(false)]
		[Token(Token = "0x40014CE")]
		[FieldOffset(Offset = "0xF8")]
		private TempTopGridVisualHolder _holder;

		[Inject(false)]
		[Token(Token = "0x40014CF")]
		[FieldOffset(Offset = "0x100")]
		private IBoosterService _boosterService;

		[Token(Token = "0x1700026B")]
		public override FlowId FlowId
		{
			[Token(Token = "0x60019BD")]
			[Address(RVA = "0x3D4D0A8", Offset = "0x3D4D0A8", Length = "0x8")]
			get
			{
				return FlowId.VacuumTutorial;
			}
		}

		[Token(Token = "0x60019BE")]
		[Address(RVA = "0x3D4D0B0", Offset = "0x3D4D0B0", Length = "0x114")]
		protected override void StartTutorial()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumTutorialFlow::StartTutorial");
		}

		[Token(Token = "0x60019BF")]
		[Address(RVA = "0x3D4D3EC", Offset = "0x3D4D3EC", Length = "0x214")]
		private void AutoBreakCubes()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumTutorialFlow::AutoBreakCubes");
		}

		[Token(Token = "0x60019C0")]
		[Address(RVA = "0x3D4D1C4", Offset = "0x3D4D1C4", Length = "0x228")]
		private void ShowConveyorHighlight()
		{
			RectData rectData = new RectData();
			rectData.m_Position = m_conveyorHighlightPosition;
			rectData.m_Position.z = 0f;
			rectData.m_SizeDelta = m_conveyorHighlightSize;
			rectData.m_IsAnchoredPosition = true;
			AnchorData center = AnchorData.Center;
			rectData.m_AnchorData = center;
			List<RectData> list = new List<RectData>();
			list.Add(rectData);
			Color color = default(Color);
			MaskData maskData = new MaskData(color, list);
			color.r = m_maskColor.r;
			color.g = m_maskColor.g;
			color.b = m_maskColor.b;
			color.a = m_maskColor.a;
			MaskUiController maskController = _uiManager.Show<MaskUiController>();
			_maskController = maskController;
			InputConfig inputConfig = new InputConfig();
			inputConfig.inputMode = default(InputMode);
			_maskController.Initialize(maskData, isUiId: false, inputConfig, default(HoleType), null, isForced: true);
		}

		[Token(Token = "0x60019C1")]
		[Address(RVA = "0x3D4D600", Offset = "0x3D4D600", Length = "0x180")]
		private void Step_HighlightButton()
		{
			Time.timeScale = 1f;
			HideOverlay();
			DisposeInputBlock();
			IDisposable inputBlock = RequestInputBlock(InputChannel.All);
			_inputBlock = inputBlock;
			RectTransform buttonRectTransform = _boosterController.GetButtonRectTransform("vacuum_booster");
			if (buttonRectTransform == null)
			{
				DisposeInputBlock();
				OnTutorialComplete();
			}
			else
			{
				Action onHoleClicked = OnButtonClicked;
				ShowMaskOnRectTransform(buttonRectTransform, onHoleClicked);
				ShowFingerOnRectTransform(buttonRectTransform);
			}
		}

		[Token(Token = "0x60019C2")]
		[Address(RVA = "0x3D4D780", Offset = "0x3D4D780", Length = "0x1B4")]
		private void OnButtonClicked()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumTutorialFlow::OnButtonClicked");
		}

		[Token(Token = "0x60019C3")]
		[Address(RVA = "0x3D4D934", Offset = "0x3D4D934", Length = "0x30")]
		protected internal override void RemoveTutorial()
		{
			Time.timeScale = 1f;
			base.RemoveTutorial();
		}

		[Token(Token = "0x60019C4")]
		[Address(RVA = "0x3D4D964", Offset = "0x3D4D964", Length = "0x90")]
		public VacuumTutorialFlow()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumTutorialFlow::.ctor");
		}
	}
}
