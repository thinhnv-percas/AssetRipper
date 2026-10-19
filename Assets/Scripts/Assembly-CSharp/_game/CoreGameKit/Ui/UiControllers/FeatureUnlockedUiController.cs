using System;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using Unco.UncoButtonSystem;
using UnityEngine;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.Ui.UiControllers
{
	[Token(Token = "0x2000543")]
	public class FeatureUnlockedUiController : UIController
	{
		[SerializeField]
		[Token(Token = "0x40011CB")]
		[FieldOffset(Offset = "0x48")]
		private UncoButton m_continueButton;

		[SerializeField]
		[Token(Token = "0x40011CC")]
		[FieldOffset(Offset = "0x50")]
		private float m_delay;

		[Token(Token = "0x40011CD")]
		[FieldOffset(Offset = "0x58")]
		private Action _onContinueAction;

		[Inject(false)]
		[Token(Token = "0x600160F")]
		[Address(RVA = "0x3D18774", Offset = "0x3D18774", Length = "0x10C")]
		public void Construct()
		{
			m_continueButton.SetInteractable(isInteractable: false);
			Action onComplete = delegate
			{
				m_continueButton.SetInteractable(isInteractable: false);
				m_continueButton.SetInteractable(isInteractable: true);
			};
			Tween tween = Tween.Delay(m_delay, onComplete, useUnscaledTime: true);
			Action clickAction = delegate
			{
				if (_onContinueAction != null)
				{
					_onContinueAction();
				}
				FeatureUnlockedUiController featureUnlockedUiController = default(FeatureUnlockedUiController);
				featureUnlockedUiController.Hide();
			};
			m_continueButton.AddListener(clickAction);
		}

		[Token(Token = "0x6001610")]
		[Address(RVA = "0x3D18880", Offset = "0x3D18880", Length = "0xB4")]
		public void AddListener(Action onComplete)
		{
			Delegate obj = Delegate.Combine(_onContinueAction, onComplete);
			if ((object)obj != null)
			{
				if ((object)obj.GetType() == typeof(Action))
				{
					_onContinueAction = (Action)obj;
					if ((object)obj.GetType() == typeof(Action))
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			_onContinueAction = null;
		}

		[Token(Token = "0x6001611")]
		[Address(RVA = "0x3D18934", Offset = "0x3D18934", Length = "0x10")]
		public FeatureUnlockedUiController()
		{
			m_delay = 0.5f;
		}
	}
}
