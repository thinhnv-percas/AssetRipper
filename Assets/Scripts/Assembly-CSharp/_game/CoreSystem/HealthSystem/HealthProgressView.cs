using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.RealTimeSystem.Runtime;
using Unco.TextViewSystem;
using Unco.TimeTaskSystem.Runtime;
using UnityEngine;

namespace _game.CoreSystem.HealthSystem
{
	[Token(Token = "0x20004CE")]
	public class HealthProgressView : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x400101A")]
		[FieldOffset(Offset = "0x20")]
		private TimeTextView m_timerText;

		[SerializeField]
		[Token(Token = "0x400101B")]
		[FieldOffset(Offset = "0x28")]
		private GameObject m_regenRoot;

		[SerializeField]
		[Token(Token = "0x400101C")]
		[FieldOffset(Offset = "0x30")]
		private GameObject m_infiniteRoot;

		[SerializeField]
		[Token(Token = "0x400101D")]
		[FieldOffset(Offset = "0x38")]
		private GameObject m_fullRoot;

		[Token(Token = "0x400101E")]
		[FieldOffset(Offset = "0x40")]
		private HealthController _healthController;

		[Token(Token = "0x400101F")]
		[FieldOffset(Offset = "0x48")]
		private HealthState _currentState;

		[Inject(false)]
		[Token(Token = "0x600144D")]
		[Address(RVA = "0x3CF418C", Offset = "0x3CF418C", Length = "0x13C")]
		private void Construct(HealthController healthController)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HealthProgressView::Construct");
		}

		[Token(Token = "0x600144E")]
		[Address(RVA = "0x3CF449C", Offset = "0x3CF449C", Length = "0x11C")]
		private void OnDestroy()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HealthProgressView::OnDestroy");
		}

		[Token(Token = "0x600144F")]
		[Address(RVA = "0x3CF4708", Offset = "0x3CF4708", Length = "0x2C")]
		private void OnHealthStateChanged(HealthState state)
		{
			UnsubscribeTimerUpdates();
			ApplyState(state);
		}

		[Token(Token = "0x6001450")]
		[Address(RVA = "0x3CF42C8", Offset = "0x3CF42C8", Length = "0x1D4")]
		private unsafe void ApplyState(HealthState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HealthProgressView::ApplyState");
		}

		[Token(Token = "0x6001451")]
		[Address(RVA = "0x3CF45B8", Offset = "0x3CF45B8", Length = "0x150")]
		private void UnsubscribeTimerUpdates()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HealthProgressView::UnsubscribeTimerUpdates");
		}

		[Token(Token = "0x6001452")]
		[Address(RVA = "0x3CF47F8", Offset = "0x3CF47F8", Length = "0x8")]
		private void OnTimerUpdate(float elapsed, float duration)
		{
			float remainingSeconds = duration - elapsed;
			UpdateTimerDisplay(remainingSeconds);
		}

		[Token(Token = "0x6001453")]
		[Address(RVA = "0x3CF4734", Offset = "0x3CF4734", Length = "0xC4")]
		private void UpdateTimerDisplay(float remainingSeconds)
		{
			float f = Math.Max(0f, remainingSeconds);
			float num = Mathf.Ceil(f);
			TimeSpan timeText = TimeSpan.FromSeconds(num);
			m_timerText.SetTimeText(timeText);
		}

		[Token(Token = "0x6001454")]
		[Address(RVA = "0x3CF4800", Offset = "0x3CF4800", Length = "0x8")]
		public HealthProgressView()
		{
		}
	}
}
