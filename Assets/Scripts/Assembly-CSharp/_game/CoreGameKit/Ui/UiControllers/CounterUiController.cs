using System;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using Unco.TextViewSystem;
using UnityEngine;
using _game.CoreGameKit.UiControllers;
using _game.CoreSystem.Events;

namespace _game.CoreGameKit.Ui.UiControllers
{
	[Token(Token = "0x2000541")]
	public class CounterUiController : UIController
	{
		[SerializeField]
		[Token(Token = "0x40011C3")]
		[FieldOffset(Offset = "0x48")]
		private TextView m_countdownText;

		[SerializeField]
		[Token(Token = "0x40011C4")]
		[FieldOffset(Offset = "0x50")]
		private CanvasGroup m_countdownGroup;

		[SerializeField]
		[Token(Token = "0x40011C5")]
		[FieldOffset(Offset = "0x58")]
		private float m_fadeDuration;

		[Inject(false)]
		[Token(Token = "0x40011C6")]
		[FieldOffset(Offset = "0x60")]
		private EventBus _eventBus;

		[Token(Token = "0x40011C7")]
		[FieldOffset(Offset = "0x68")]
		private bool _countdownActive;

		[Token(Token = "0x40011C8")]
		[FieldOffset(Offset = "0x6C")]
		private float _graceStartTime;

		[Token(Token = "0x40011C9")]
		[FieldOffset(Offset = "0x70")]
		private float _graceDuration;

		[Token(Token = "0x40011CA")]
		[FieldOffset(Offset = "0x78")]
		private Tween _fadeTween;

		[Inject(false)]
		[Token(Token = "0x6001605")]
		[Address(RVA = "0x3D18160", Offset = "0x3D18160", Length = "0xB0")]
		private void Construct()
		{
			Action<UventGraceCountdownChanged> observer = OnGraceCountdownChanged;
			_eventBus.ListenEvent(observer);
			HideCountdownGroupImmediate();
		}

		[Token(Token = "0x6001606")]
		[Address(RVA = "0x3D1835C", Offset = "0x3D1835C", Length = "0x28")]
		private void OnGraceCountdownChanged(UventGraceCountdownChanged evt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CounterUiController::OnGraceCountdownChanged");
		}

		[Token(Token = "0x6001607")]
		[Address(RVA = "0x3D18384", Offset = "0x3D18384", Length = "0x13C")]
		private void StartCountdown(float duration)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CounterUiController::StartCountdown");
		}

		[Token(Token = "0x6001608")]
		[Address(RVA = "0x3D184C0", Offset = "0x3D184C0", Length = "0x18")]
		private void StopCountdown()
		{
			if (_countdownActive)
			{
				_countdownActive = false;
				HideCountdownGroupImmediate();
			}
		}

		[Token(Token = "0x6001609")]
		[Address(RVA = "0x3D18620", Offset = "0x3D18620", Length = "0x60")]
		private void Update()
		{
			if (_countdownActive)
			{
				float time = Time.time;
				float num = time - _graceStartTime;
				float num2 = _graceDuration - num;
				bool flag = num2 == 0f;
				bool flag2 = num2 < 0f;
				bool flag3 = !flag2;
				bool flag4 = !flag3;
				if (!(flag4 || flag))
				{
					UpdateCountdownText(num2);
					return;
				}
				_countdownActive = false;
				HideCountdownGroupImmediate();
			}
		}

		[Token(Token = "0x600160A")]
		[Address(RVA = "0x3D184D8", Offset = "0x3D184D8", Length = "0x148")]
		private void UpdateCountdownText(float remaining)
		{
			//IL_00b3: Expected I4, but got F4
			if (m_countdownText != null)
			{
				float num = Mathf.Ceil(remaining);
				float num2 = ((num != 1f / 0f) ? remaining : -0f);
				string text = ((int)num2).ToString();
				m_countdownText.SetText(text);
			}
		}

		[Token(Token = "0x600160B")]
		[Address(RVA = "0x3D18210", Offset = "0x3D18210", Length = "0x14C")]
		private void HideCountdownGroupImmediate()
		{
			//IL_00c6: Expected O, but got I
			//IL_00d6: Expected O, but got I
			_fadeTween.Stop();
			UnityEngine.Object countdownGroup;
			if (!(m_countdownText != null))
			{
				countdownGroup = m_countdownGroup;
			}
			else
			{
				int num = 192761856 + 1336;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ X8_v8 (System.Int32)+90]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ X8_v9+B8]");
				object text = 0;
				m_countdownText.SetText((string)text);
				countdownGroup = m_countdownGroup;
			}
			if (countdownGroup != null)
			{
				m_countdownGroup.alpha = 0f;
				GameObject gameObject = m_countdownGroup.gameObject;
				gameObject.SetActive(value: false);
			}
		}

		[Token(Token = "0x600160C")]
		[Address(RVA = "0x3D18680", Offset = "0x3D18680", Length = "0xD8")]
		public override void OnDisable()
		{
			base.OnDisable();
			_countdownActive = false;
			HideCountdownGroupImmediate();
			if (_eventBus != null)
			{
				Action<UventGraceCountdownChanged> observer = OnGraceCountdownChanged;
				_eventBus.RemoveListener(observer);
			}
		}

		[Token(Token = "0x600160D")]
		[Address(RVA = "0x3D18758", Offset = "0x3D18758", Length = "0x14")]
		public CounterUiController()
		{
			m_fadeDuration = 0.3f;
		}
	}
}
