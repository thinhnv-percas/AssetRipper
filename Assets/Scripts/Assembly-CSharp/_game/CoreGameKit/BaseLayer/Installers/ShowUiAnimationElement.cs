using System;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using UnityEngine;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Serializable]
	[Token(Token = "0x2000695")]
	public class ShowUiAnimationElement : IBaseLayerUiActionElement
	{
		[Token(Token = "0x4001676")]
		[FieldOffset(Offset = "0x10")]
		private Tween _tween;

		[Token(Token = "0x4001677")]
		[FieldOffset(Offset = "0x20")]
		private Action _onComplete;

		[SerializeField]
		[Token(Token = "0x4001678")]
		[FieldOffset(Offset = "0x28")]
		private float m_delay;

		[SerializeField]
		[Token(Token = "0x4001679")]
		[FieldOffset(Offset = "0x30")]
		private UIController m_uiController;

		[Inject(false)]
		[Token(Token = "0x400167A")]
		[FieldOffset(Offset = "0x38")]
		private UiManager _uiManager;

		[Token(Token = "0x6001BE9")]
		[Address(RVA = "0x3D65BF8", Offset = "0x3D65BF8", Length = "0x84")]
		public IBaseLayerUiActionElement GetInstance()
		{
			ShowUiAnimationElement showUiAnimationElement = new ShowUiAnimationElement();
			showUiAnimationElement.m_delay = m_delay;
			showUiAnimationElement.m_uiController = m_uiController;
			return showUiAnimationElement;
		}

		[Token(Token = "0x6001BEA")]
		[Address(RVA = "0x3D65C84", Offset = "0x3D65C84", Length = "0x2CC")]
		public void Play(Action onComplete)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ShowUiAnimationElement::Play");
		}

		[Token(Token = "0x6001BEB")]
		[Address(RVA = "0x3D65F58", Offset = "0x3D65F58", Length = "0x34")]
		public void Stop()
		{
			_tween.Stop();
			_onComplete = null;
		}

		[Token(Token = "0x6001BEC")]
		[Address(RVA = "0x3D65C7C", Offset = "0x3D65C7C", Length = "0x8")]
		public ShowUiAnimationElement()
		{
		}
	}
}
