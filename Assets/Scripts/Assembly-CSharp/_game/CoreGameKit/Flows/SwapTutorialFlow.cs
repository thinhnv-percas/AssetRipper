using System;
using Systems.FlowSystem.Scripts.Core;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Services;

namespace _game.CoreGameKit.Flows
{
	[Serializable]
	[Token(Token = "0x2000600")]
	public class SwapTutorialFlow : BoosterTutorialFlowBase
	{
		[Token(Token = "0x40014B4")]
		private const string SwapBoosterId = "swap_booster";

		[Header("Timing")]
		[SerializeField]
		[Token(Token = "0x40014B5")]
		[FieldOffset(Offset = "0xD0")]
		private float m_initialDelay;

		[Token(Token = "0x17000269")]
		public override FlowId FlowId
		{
			[Token(Token = "0x60019AE")]
			[Address(RVA = "0x3D4BD0C", Offset = "0x3D4BD0C", Length = "0x8")]
			get
			{
				return FlowId.SwapTutorial;
			}
		}

		[Token(Token = "0x60019AF")]
		[Address(RVA = "0x3D4BD14", Offset = "0x3D4BD14", Length = "0xFC")]
		protected override void StartTutorial()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SwapTutorialFlow::StartTutorial");
		}

		[Token(Token = "0x60019B0")]
		[Address(RVA = "0x3D4BE10", Offset = "0x3D4BE10", Length = "0x138")]
		private void Step_HighlightButton()
		{
			RectTransform buttonRectTransform = _boosterController.GetButtonRectTransform("swap_booster");
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

		[Token(Token = "0x60019B1")]
		[Address(RVA = "0x3D4BF48", Offset = "0x3D4BF48", Length = "0x6C")]
		private void OnButtonClicked()
		{
			_boosterController.TriggerBoosterUse("swap_booster");
			OnTutorialComplete();
			DisposeInputBlock();
		}

		[Token(Token = "0x60019B2")]
		[Address(RVA = "0x3D4BFB4", Offset = "0x3D4BFB4", Length = "0x10")]
		public SwapTutorialFlow()
		{
			m_initialDelay = 1.5f;
		}
	}
}
