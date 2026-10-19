using System;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.Ui.UiControllers
{
	[Token(Token = "0x2000557")]
	public class TapFingerUiController : UIController
	{
		[SerializeField]
		[Token(Token = "0x4001239")]
		[FieldOffset(Offset = "0x48")]
		private Image m_fingerImage;

		[Header("Tap Animation Settings")]
		[SerializeField]
		[Token(Token = "0x400123A")]
		[FieldOffset(Offset = "0x50")]
		private float m_tapScaleAmount;

		[SerializeField]
		[Token(Token = "0x400123B")]
		[FieldOffset(Offset = "0x54")]
		private float m_tapDuration;

		[SerializeField]
		[Token(Token = "0x400123C")]
		[FieldOffset(Offset = "0x58")]
		private Ease m_tapEase;

		[Token(Token = "0x400123D")]
		[FieldOffset(Offset = "0x60")]
		private RectTransform _fingerRectTransform;

		[Token(Token = "0x400123E")]
		[FieldOffset(Offset = "0x68")]
		private Sequence _tapSequence;

		[Token(Token = "0x400123F")]
		[FieldOffset(Offset = "0x78")]
		private Vector3 _worldPosition;

		[Token(Token = "0x4001240")]
		[FieldOffset(Offset = "0x84")]
		private Vector3 _offset;

		[Token(Token = "0x4001241")]
		[FieldOffset(Offset = "0x90")]
		private Action _onTapComplete;

		[Token(Token = "0x4001242")]
		[FieldOffset(Offset = "0x98")]
		private Camera _camera;

		[Token(Token = "0x4001243")]
		[FieldOffset(Offset = "0xA0")]
		private Canvas _canvas;

		[Token(Token = "0x4001244")]
		[FieldOffset(Offset = "0xA8")]
		private bool _isAnimating;

		[Token(Token = "0x4001245")]
		[FieldOffset(Offset = "0xAC")]
		private Vector2 _fingerSize;

		[Token(Token = "0x4001246")]
		[FieldOffset(Offset = "0xB8")]
		private RectTransform _targetRectTransform;

		[Inject(false)]
		[Token(Token = "0x600165D")]
		[Address(RVA = "0x3D1C98C", Offset = "0x3D1C98C", Length = "0xDC")]
		private void Initialize()
		{
			RectTransform component = m_fingerImage.GetComponent<RectTransform>();
			_fingerRectTransform = component;
			Canvas componentInParent = GetComponentInParent<Canvas>();
			_canvas = componentInParent;
			if ((object)_canvas != null)
			{
				Camera worldCamera = _canvas.worldCamera;
				if ((object)worldCamera != null)
				{
					_camera = worldCamera;
					return;
				}
			}
			Camera main = Camera.main;
			_camera = main;
		}

		[Token(Token = "0x600165E")]
		[Address(RVA = "0x3D1CA68", Offset = "0x3D1CA68", Length = "0x7C")]
		public void StartTapAnimation(Vector3 worldPosition, Vector2 fingerSize, Vector3 offset, Action onTapComplete)
		{
			_onTapComplete = onTapComplete;
			_worldPosition.x = worldPosition.x;
			_worldPosition.y = worldPosition.y;
			_fingerSize.x = fingerSize.x;
			_fingerSize.y = fingerSize.y;
			_worldPosition.z = worldPosition.z;
			_offset.x = offset.x;
			_offset.y = offset.y;
			_offset.z = offset.z;
			_isAnimating = true;
			_fingerRectTransform.sizeDelta = fingerSize;
			UpdateFingerPosition();
			PlayTapAnimation();
		}

		[Token(Token = "0x600165F")]
		[Address(RVA = "0x3D1CD74", Offset = "0x3D1CD74", Length = "0xAC")]
		public void StartTapAnimationOnRectTransform(RectTransform target, Vector2 fingerSize, Vector3 offset, Action onTapComplete)
		{
			_targetRectTransform = target;
			_onTapComplete = onTapComplete;
			_fingerSize.x = fingerSize.x;
			_fingerSize.y = fingerSize.y;
			_offset.x = offset.x;
			_offset.y = offset.y;
			_offset.z = offset.z;
			_isAnimating = true;
			_fingerRectTransform.sizeDelta = fingerSize;
			UpdateFingerPositionFromRect();
			PlayTapAnimation();
		}

		[Token(Token = "0x6001660")]
		[Address(RVA = "0x3D1CF58", Offset = "0x3D1CF58", Length = "0x58")]
		public unsafe void StopAnimation()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TapFingerUiController::StopAnimation");
		}

		[Token(Token = "0x6001661")]
		[Address(RVA = "0x3D1CBF8", Offset = "0x3D1CBF8", Length = "0x17C")]
		private void PlayTapAnimation()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TapFingerUiController::PlayTapAnimation");
		}

		[Token(Token = "0x6001662")]
		[Address(RVA = "0x3D1CFB0", Offset = "0x3D1CFB0", Length = "0xBC")]
		private void Update()
		{
			if (_isAnimating)
			{
				if (_targetRectTransform != null)
				{
					UpdateFingerPositionFromRect();
					CheckForTapInput();
				}
				else
				{
					UpdateFingerPosition();
					CheckForTapInput();
				}
			}
		}

		[Token(Token = "0x6001663")]
		[Address(RVA = "0x3D1CAE4", Offset = "0x3D1CAE4", Length = "0x114")]
		private void UpdateFingerPosition()
		{
			if (!(_camera == null) && !(_fingerRectTransform == null))
			{
				Vector3 worldPosition = default(Vector3);
				worldPosition.x = _worldPosition.x;
				worldPosition.y = _worldPosition.y;
				worldPosition.z = _worldPosition.z;
				Vector2 vector = WorldToCanvasPosition(worldPosition);
				float y = vector.y + _offset.y;
				float x = vector.x + _offset.x;
				Vector2 anchoredPosition = default(Vector2);
				anchoredPosition.x = x;
				anchoredPosition.y = y;
				_fingerRectTransform.anchoredPosition = anchoredPosition;
			}
		}

		[Token(Token = "0x6001664")]
		[Address(RVA = "0x3D1CE20", Offset = "0x3D1CE20", Length = "0x138")]
		private void UpdateFingerPositionFromRect()
		{
			if (!(_targetRectTransform == null) && !(_fingerRectTransform == null))
			{
				Vector3 position = _targetRectTransform.position;
				_fingerRectTransform.position = position;
				Vector2 anchoredPosition = _fingerRectTransform.anchoredPosition;
				float x = anchoredPosition.x + _offset.x;
				float y = anchoredPosition.y + _offset.y;
				Vector2 anchoredPosition2 = default(Vector2);
				anchoredPosition2.x = x;
				anchoredPosition2.y = y;
				_fingerRectTransform.anchoredPosition = anchoredPosition2;
			}
		}

		[Token(Token = "0x6001665")]
		[Address(RVA = "0x3D1D200", Offset = "0x3D1D200", Length = "0x268")]
		private Vector2 WorldToCanvasPosition(Vector3 worldPosition)
		{
			Vector2 localPoint = default(Vector2);
			if (!(_canvas == null) && !(_camera == null))
			{
				Vector3 vector = _camera.WorldToScreenPoint(worldPosition);
				Transform transform = _canvas.transform;
				Camera cam;
				RectTransform rect;
				if (_canvas.renderMode != RenderMode.ScreenSpaceOverlay)
				{
					if ((object)transform != null)
					{
						if ((object)transform.GetType() != typeof(RectTransform))
						{
							transform = null;
						}
					}
					else
					{
						transform = null;
					}
					cam = _camera;
					rect = (RectTransform)transform;
				}
				else if ((object)transform != null)
				{
					if ((object)transform.GetType() != typeof(RectTransform))
					{
						transform = null;
					}
					cam = null;
					rect = (RectTransform)transform;
				}
				else
				{
					cam = null;
					rect = null;
				}
				Vector2 screenPoint = default(Vector2);
				screenPoint.x = vector.x;
				screenPoint.y = vector.y;
				bool flag = RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, screenPoint, cam, out localPoint);
			}
			return Vector2.zero;
		}

		[Token(Token = "0x6001666")]
		[Address(RVA = "0x3D1D06C", Offset = "0x3D1D06C", Length = "0x194")]
		private unsafe void CheckForTapInput()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TapFingerUiController::CheckForTapInput");
		}

		[Token(Token = "0x6001667")]
		[Address(RVA = "0x3D1D468", Offset = "0x3D1D468", Length = "0x150")]
		private bool IsTapNearTarget(Vector2 screenPosition)
		{
			if (_camera == null)
			{
				return false;
			}
			Vector3 position = default(Vector3);
			position.x = _worldPosition.x;
			position.y = _worldPosition.y;
			position.z = _worldPosition.z;
			Vector3 vector = _camera.WorldToScreenPoint(position);
			float num = screenPosition.y - vector.y;
			float num2 = screenPosition.x - vector.x;
			float num3 = num2 * num2;
			float num4 = num * num;
			float f = num3 + num4;
			float num5 = Mathf.Sqrt(f);
			bool flag = num5 == 92f;
			bool flag2 = num5 < 92f;
			bool flag3 = !flag2;
			bool flag4 = !flag3;
			return flag4 || flag;
		}

		[Token(Token = "0x6001668")]
		[Address(RVA = "0x3D1D5B8", Offset = "0x3D1D5B8", Length = "0x74")]
		private unsafe void OnTapDetected()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TapFingerUiController::OnTapDetected");
		}

		[Token(Token = "0x6001669")]
		[Address(RVA = "0x3D1D62C", Offset = "0x3D1D62C", Length = "0x60")]
		public unsafe override void OnDisable()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TapFingerUiController::OnDisable");
		}

		[Token(Token = "0x600166A")]
		[Address(RVA = "0x3D1D68C", Offset = "0x3D1D68C", Length = "0x1C")]
		public TapFingerUiController()
		{
			m_tapScaleAmount = 0.85f;
			m_tapDuration = 0.6f;
			m_tapEase = Ease.InOutQuad;
		}
	}
}
