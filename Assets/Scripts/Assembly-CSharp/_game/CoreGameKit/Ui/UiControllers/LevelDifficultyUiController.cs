using System;
using Cpp2ILInjected;
using PrimeTween;
using Unco.Utils;
using UnityEngine;
using UnityEngine.UI;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.Ui.UiControllers
{
	[Token(Token = "0x200054D")]
	public class LevelDifficultyUiController : UIController
	{
		[SerializeField]
		[Token(Token = "0x40011E0")]
		[FieldOffset(Offset = "0x48")]
		private Pair<LevelDifficulty, GameObject>[] m_shines;

		[SerializeField]
		[Token(Token = "0x40011E1")]
		[FieldOffset(Offset = "0x50")]
		private Pair<LevelDifficulty, GameObject>[] m_levelParents;

		[SerializeField]
		[Token(Token = "0x40011E2")]
		[FieldOffset(Offset = "0x58")]
		private Pair<LevelDifficulty, GameObject>[] m_scalableChildren;

		[SerializeField]
		[Token(Token = "0x40011E3")]
		[FieldOffset(Offset = "0x60")]
		private Pair<LevelDifficulty, Image>[] m_strokes;

		[SerializeField]
		[Token(Token = "0x40011E4")]
		[FieldOffset(Offset = "0x68")]
		private TweenSettings<Vector3> m_scaleUpSettings;

		[SerializeField]
		[Token(Token = "0x40011E5")]
		[FieldOffset(Offset = "0xB8")]
		private TweenSettings<Vector3> m_scaleDownSettings;

		[SerializeField]
		[Token(Token = "0x40011E6")]
		[FieldOffset(Offset = "0x108")]
		private TweenSettings<Vector3> m_rotationSettings;

		[SerializeField]
		[Token(Token = "0x40011E7")]
		[FieldOffset(Offset = "0x158")]
		private TweenSettings<float> m_alphaSettings;

		[SerializeField]
		[Token(Token = "0x40011E8")]
		[FieldOffset(Offset = "0x198")]
		private float m_duration;

		[Token(Token = "0x40011E9")]
		[FieldOffset(Offset = "0x1A0")]
		private Tween _rotationTween;

		[Token(Token = "0x40011EA")]
		[FieldOffset(Offset = "0x1B0")]
		private Tween _alphaTween;

		[Token(Token = "0x40011EB")]
		[FieldOffset(Offset = "0x1C0")]
		private Tween _timerTween;

		[Token(Token = "0x40011EC")]
		[FieldOffset(Offset = "0x1D0")]
		private Tween _scaleTween;

		[Token(Token = "0x40011ED")]
		[FieldOffset(Offset = "0x1E0")]
		private Action _onComplete;

		[Token(Token = "0x600162D")]
		[Address(RVA = "0x3D190A4", Offset = "0x3D190A4", Length = "0x554")]
		public float InitAnimation(LevelDifficulty difficulty, Action onComplete)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelDifficultyUiController::InitAnimation");
			return default;
		}

		[Token(Token = "0x600162E")]
		[Address(RVA = "0x3D19600", Offset = "0x3D19600", Length = "0x114")]
		private void HideWithScaleDown(GameObject scalableChild)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelDifficultyUiController::HideWithScaleDown");
		}

		[Token(Token = "0x600162F")]
		[Address(RVA = "0x3D19714", Offset = "0x3D19714", Length = "0x54")]
		public override void Hide()
		{
			_rotationTween.Stop();
			_alphaTween.Stop();
			_timerTween.Stop();
			_scaleTween.Stop();
			base.Hide();
		}

		[Token(Token = "0x6001630")]
		[Address(RVA = "0x3D19768", Offset = "0x3D19768", Length = "0x388")]
		public LevelDifficultyUiController()
		{
			Vector3 startValue = default(Vector3);
			startValue.x = Vector3.zero.x;
			startValue.y = Vector3.zero.y;
			startValue.z = Vector3.zero.z;
			Vector3 endValue = default(Vector3);
			endValue.x = Vector3.one.x;
			endValue.y = Vector3.one.y;
			endValue.z = Vector3.one.z;
			TweenSettings<Vector3> scaleUpSettings = new TweenSettings<Vector3>(startValue, endValue, 0.3f, Ease.OutBack, 1, default(CycleMode), 0f, 0f, useUnscaledTime: true);
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			m_scaleUpSettings = scaleUpSettings;
			Vector3 startValue2 = default(Vector3);
			startValue2.x = Vector3.one.x;
			startValue2.y = Vector3.one.y;
			startValue2.z = Vector3.one.z;
			Vector3 endValue2 = default(Vector3);
			endValue2.x = Vector3.zero.x;
			endValue2.y = Vector3.zero.y;
			endValue2.z = Vector3.zero.z;
			TweenSettings<Vector3> scaleDownSettings = new TweenSettings<Vector3>(startValue2, endValue2, 0.2f, Ease.InBack, 1, default(CycleMode), 0f, 0f, useUnscaledTime: true);
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			m_scaleDownSettings = scaleDownSettings;
			Vector3 endValue3 = default(Vector3);
			endValue3.x = 0f;
			endValue3.y = 0f;
			endValue3.z = -10f;
			TweenSettings<Vector3> rotationSettings = new TweenSettings<Vector3>(endValue3, 0.5f, Ease.Linear, -1, CycleMode.Incremental, 0f, 0f, useUnscaledTime: true);
			_ = 0;
			_ = 0;
			_ = 0;
			m_rotationSettings = rotationSettings;
			_ = 0;
			TweenSettings<float> alphaSettings = new TweenSettings<float>(0.3f, 1f, 0.8f, Ease.InOutSine, -1, CycleMode.Yoyo, 0f, 0f, useUnscaledTime: true);
			m_alphaSettings = alphaSettings;
			_ = 0;
			_ = 0;
			_ = 0;
		}
	}
}
