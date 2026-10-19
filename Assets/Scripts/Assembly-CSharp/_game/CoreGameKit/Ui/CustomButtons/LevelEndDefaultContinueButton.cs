using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.UncoButtonSystem;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Services;
using _game.Systems.MonetizationCore;

namespace _game.CoreGameKit.Ui.CustomButtons
{
	[Token(Token = "0x2000562")]
	public class LevelEndDefaultContinueButton : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x400126B")]
		[FieldOffset(Offset = "0x20")]
		private UncoButton m_button;

		[Inject(false)]
		[Token(Token = "0x400126C")]
		[FieldOffset(Offset = "0x28")]
		private BaseLayerCompleteService _completeService;

		[Inject(false)]
		[Token(Token = "0x400126D")]
		[FieldOffset(Offset = "0x30")]
		private InterstitialAdService _interstitialAdService;

		[Inject(false)]
		[Token(Token = "0x600168E")]
		[Address(RVA = "0x3D1ECEC", Offset = "0x3D1ECEC", Length = "0x94")]
		private void Construct()
		{
			Action onComplete = delegate
			{
				_completeService.Complete();
			};
			_interstitialAdService.TryShow(onComplete);
		}

		[Token(Token = "0x600168F")]
		[Address(RVA = "0x3D1ED80", Offset = "0x3D1ED80", Length = "0x8")]
		public LevelEndDefaultContinueButton()
		{
		}
	}
}
