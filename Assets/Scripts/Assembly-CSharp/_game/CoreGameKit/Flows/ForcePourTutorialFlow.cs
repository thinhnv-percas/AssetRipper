using System;
using Systems.FlowSystem.Scripts.Core;
using Systems.TutorialSystem.Scripts.UI;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreGameKit.BaseLayer.Services;
using _game.CoreSystem.Events;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;

namespace _game.CoreGameKit.Flows
{
	[Serializable]
	[Token(Token = "0x20005FC")]
	public class ForcePourTutorialFlow : BoosterTutorialFlowBase
	{
		[Token(Token = "0x400149E")]
		private const string HammerBoosterId = "hammer_booster";

		[Header("Timing")]
		[SerializeField]
		[Token(Token = "0x400149F")]
		[FieldOffset(Offset = "0xD0")]
		private float m_initialDelay;

		[SerializeField]
		[Token(Token = "0x40014A0")]
		[FieldOffset(Offset = "0xD4")]
		private float m_postActivateDelay;

		[Header("Target Cube")]
		[SerializeField]
		[Token(Token = "0x40014A1")]
		[FieldOffset(Offset = "0xD8")]
		private Vector2Int m_targetCubeGridPos;

		[Header("Cube Hole Size")]
		[SerializeField]
		[Token(Token = "0x40014A2")]
		[FieldOffset(Offset = "0xE0")]
		private Vector2 m_cubeHoleSize;

		[Inject(false)]
		[Token(Token = "0x40014A3")]
		[FieldOffset(Offset = "0xE8")]
		private new EventBus _eventBus;

		[Inject(false)]
		[Token(Token = "0x40014A4")]
		[FieldOffset(Offset = "0xF0")]
		private TempTopGridVisualHolder _topGridVisualHolder;

		[Token(Token = "0x17000266")]
		public override FlowId FlowId
		{
			[Token(Token = "0x6001996")]
			[Address(RVA = "0x3D4A960", Offset = "0x3D4A960", Length = "0x8")]
			get
			{
				return FlowId.ForcePourTutorial;
			}
		}

		[Token(Token = "0x6001997")]
		[Address(RVA = "0x3D4A968", Offset = "0x3D4A968", Length = "0x144")]
		protected override void StartTutorial()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ForcePourTutorialFlow::StartTutorial");
		}

		[Token(Token = "0x6001998")]
		[Address(RVA = "0x3D4AAAC", Offset = "0x3D4AAAC", Length = "0x1C4")]
		private void Step_HighlightButton()
		{
			RectTransform buttonRectTransform = _boosterController.GetButtonRectTransform("hammer_booster");
			if (!(buttonRectTransform == null))
			{
				Action onHoleClicked = OnButtonClicked;
				ShowMaskOnRectTransform(buttonRectTransform, onHoleClicked);
				ShowFingerOnRectTransform(buttonRectTransform);
				return;
			}
			if (_inputBlock != null)
			{
				_inputBlock.Dispose();
			}
			_inputBlock = null;
			OnTutorialComplete();
		}

		[Token(Token = "0x6001999")]
		[Address(RVA = "0x3D4AC70", Offset = "0x3D4AC70", Length = "0x108")]
		private void OnButtonClicked()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ForcePourTutorialFlow::OnButtonClicked");
		}

		[Token(Token = "0x600199A")]
		[Address(RVA = "0x3D4AD78", Offset = "0x3D4AD78", Length = "0x2B0")]
		private void Step_HighlightCube()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ForcePourTutorialFlow::Step_HighlightCube");
		}

		[Token(Token = "0x600199B")]
		[Address(RVA = "0x3D4B028", Offset = "0x3D4B028", Length = "0x16C")]
		private void OnCubeClicked()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ForcePourTutorialFlow::OnCubeClicked");
		}

		[Token(Token = "0x600199C")]
		[Address(RVA = "0x3D4B194", Offset = "0x3D4B194", Length = "0xA4")]
		public ForcePourTutorialFlow()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ForcePourTutorialFlow::.ctor");
		}
	}
}
