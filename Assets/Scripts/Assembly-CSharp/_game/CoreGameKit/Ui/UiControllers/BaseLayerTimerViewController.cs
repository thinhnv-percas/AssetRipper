using System;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using Unco.TextViewSystem;
using Unco.TimeTaskSystem.Runtime;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Controller;
using _game.Scripts.TweenerSystem;

namespace _game.CoreGameKit.Ui.UiControllers
{
	[Token(Token = "0x200053E")]
	public class BaseLayerTimerViewController : MonoBehaviour, IDisposable
	{
		[SerializeField]
		[Token(Token = "0x40011AA")]
		[FieldOffset(Offset = "0x20")]
		private TextView m_textView;

		[SerializeField]
		[Token(Token = "0x40011AB")]
		[FieldOffset(Offset = "0x28")]
		private Tweener m_timeAddEffectTweener;

		[SerializeField]
		[Token(Token = "0x40011AC")]
		[FieldOffset(Offset = "0x30")]
		private TimeTextView m_timeAddEffectText;

		[Token(Token = "0x40011AD")]
		[FieldOffset(Offset = "0x38")]
		private BaseLayerTimerController _timerController;

		[Inject(true)]
		[Token(Token = "0x60015F3")]
		[Address(RVA = "0x3D17008", Offset = "0x3D17008", Length = "0x160")]
		public void Initialize(BaseLayerTimerController timerController)
		{
			BaseLayerTimerController baseLayerTimerController = default(BaseLayerTimerController);
			if (baseLayerTimerController != null)
			{
				_timerController = baseLayerTimerController;
				OnTimerUpdate onTimerUpdate = OnTimerUpdated;
				_timerController.AddListener(onTimerUpdate);
				Action<float> value = OnTimeAdded;
				_timerController.add_OnTimeAdded(value);
				float elapsedTime = _timerController.GetElapsedTime();
				BaseLayerTimerController timerController2 = _timerController;
				OnTimerUpdated(elapsedTime, timerController2._duration);
			}
			else
			{
				GameObject gameObject = base.gameObject;
				gameObject.SetActive(value: false);
			}
		}

		[Token(Token = "0x60015F4")]
		[Address(RVA = "0x3D172DC", Offset = "0x3D172DC", Length = "0x10C")]
		public void Dispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerTimerViewController::Dispose");
		}

		[Token(Token = "0x60015F5")]
		[Address(RVA = "0x3D17168", Offset = "0x3D17168", Length = "0x174")]
		private void OnTimerUpdated(float elapsed, float duration)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerTimerViewController::OnTimerUpdated");
		}

		[Token(Token = "0x60015F6")]
		[Address(RVA = "0x3D173E8", Offset = "0x3D173E8", Length = "0xC0")]
		private void OnTimeAdded(float timeAdded)
		{
			TimeSpan timeText = TimeSpan.FromSeconds(timeAdded);
			if ((object)m_timeAddEffectText != null)
			{
				m_timeAddEffectText.SetTimeText(timeText);
				Sequence sequence = m_timeAddEffectTweener.Play();
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x60015F7")]
		[Address(RVA = "0x3D174A8", Offset = "0x3D174A8", Length = "0x8")]
		public BaseLayerTimerViewController()
		{
		}
	}
}
