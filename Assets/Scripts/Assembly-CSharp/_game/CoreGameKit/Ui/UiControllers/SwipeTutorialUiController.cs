using System;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;
using _game.CoreGameKit.BaseLayer.Installers;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.Ui.UiControllers
{
	[Token(Token = "0x2000555")]
	public class SwipeTutorialUiController : UIController
	{
		[SerializeField]
		[Token(Token = "0x4001211")]
		[FieldOffset(Offset = "0x48")]
		private Image m_fingerImage;

		[SerializeField]
		[Token(Token = "0x4001212")]
		[FieldOffset(Offset = "0x50")]
		private Image m_bg;

		[Header("Tap Animation Settings")]
		[SerializeField]
		[Token(Token = "0x4001213")]
		[FieldOffset(Offset = "0x58")]
		private float tapScaleAmount;

		[SerializeField]
		[Token(Token = "0x4001214")]
		[FieldOffset(Offset = "0x5C")]
		private float tapDuration;

		[SerializeField]
		[Token(Token = "0x4001215")]
		[FieldOffset(Offset = "0x60")]
		private Ease tapEase;

		[Header("Swipe Animation Settings")]
		[SerializeField]
		[Token(Token = "0x4001216")]
		[FieldOffset(Offset = "0x64")]
		private float swipeDistance;

		[SerializeField]
		[Token(Token = "0x4001217")]
		[FieldOffset(Offset = "0x68")]
		private float swipeDuration;

		[SerializeField]
		[Token(Token = "0x4001218")]
		[FieldOffset(Offset = "0x6C")]
		private Ease swipeEase;

		[SerializeField]
		[Token(Token = "0x4001219")]
		[FieldOffset(Offset = "0x70")]
		private bool swipeToRight;

		[Header("Animation Loop Settings")]
		[SerializeField]
		[Token(Token = "0x400121A")]
		[FieldOffset(Offset = "0x71")]
		private bool loopAnimation;

		[SerializeField]
		[Token(Token = "0x400121B")]
		[FieldOffset(Offset = "0x74")]
		private float delayBetweenLoops;

		[Header("Alpha Animation Settings")]
		[SerializeField]
		[Token(Token = "0x400121C")]
		[FieldOffset(Offset = "0x78")]
		private float fadeInDuration;

		[SerializeField]
		[Token(Token = "0x400121D")]
		[FieldOffset(Offset = "0x7C")]
		private float fadeOutDuration;

		[SerializeField]
		[Token(Token = "0x400121E")]
		[FieldOffset(Offset = "0x80")]
		private Ease fadeEase;

		[Token(Token = "0x400121F")]
		[FieldOffset(Offset = "0x88")]
		private Sequence currentSequence;

		[Token(Token = "0x4001220")]
		[FieldOffset(Offset = "0x98")]
		private Tween delayTween;

		[Token(Token = "0x4001221")]
		[FieldOffset(Offset = "0xA8")]
		private Tween alphaTween;

		[Token(Token = "0x4001222")]
		[FieldOffset(Offset = "0xB8")]
		private RectTransform fingerRectTransform;

		[Token(Token = "0x4001223")]
		[FieldOffset(Offset = "0xC0")]
		private Vector2 fingerStartPosition;

		[Token(Token = "0x4001224")]
		[FieldOffset(Offset = "0xC8")]
		private Action _completeAction;

		[Token(Token = "0x4001225")]
		[FieldOffset(Offset = "0xD0")]
		private float _requiredInputRotation;

		[Token(Token = "0x4001226")]
		[FieldOffset(Offset = "0xD4")]
		private float _initialAlpha;

		[Token(Token = "0x4001227")]
		[FieldOffset(Offset = "0xD8")]
		private bool _hasFadedOut;

		[Token(Token = "0x4001228")]
		[FieldOffset(Offset = "0xD9")]
		private bool _isTrackingInput;

		[Token(Token = "0x4001229")]
		[FieldOffset(Offset = "0xDC")]
		private float _accumulatedSwipeDistance;

		[Token(Token = "0x400122A")]
		[FieldOffset(Offset = "0xE0")]
		private bool _isInputActive;

		[Token(Token = "0x400122B")]
		[FieldOffset(Offset = "0xE4")]
		private Vector2 _lastInputPosition;

		[Token(Token = "0x400122C")]
		[FieldOffset(Offset = "0xEC")]
		private SwipeMode _currentSwipeMode;

		[Token(Token = "0x400122D")]
		[FieldOffset(Offset = "0xF0")]
		private RectTransform _startRectTransform;

		[Token(Token = "0x400122E")]
		[FieldOffset(Offset = "0xF8")]
		private RectTransform _endRectTransform;

		[Token(Token = "0x400122F")]
		[FieldOffset(Offset = "0x100")]
		private GameObject _followGameObject;

		[Token(Token = "0x4001230")]
		[FieldOffset(Offset = "0x108")]
		private Vector3 _startWorldPoint;

		[Token(Token = "0x4001231")]
		[FieldOffset(Offset = "0x114")]
		private Vector3 _endWorldPoint;

		[Token(Token = "0x4001232")]
		[FieldOffset(Offset = "0x120")]
		private Canvas _canvas;

		[Token(Token = "0x4001233")]
		[FieldOffset(Offset = "0x128")]
		private Camera _camera;

		[Inject(false)]
		[Token(Token = "0x4001234")]
		[FieldOffset(Offset = "0x130")]
		private IInputProvider _inputProvider;

		[Inject(false)]
		[Token(Token = "0x6001647")]
		[Address(RVA = "0x3D1AD74", Offset = "0x3D1AD74", Length = "0x10C")]
		private void Initialize()
		{
			RectTransform component = m_fingerImage.GetComponent<RectTransform>();
			fingerRectTransform = component;
			Vector2 anchoredPosition = fingerRectTransform.anchoredPosition;
			fingerStartPosition.x = anchoredPosition.x;
			fingerStartPosition.y = anchoredPosition.y;
			Color color = m_bg.color;
			float initialAlpha = default(float);
			_initialAlpha = initialAlpha;
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

		[Token(Token = "0x6001648")]
		[Address(RVA = "0x3D1AE80", Offset = "0x3D1AE80", Length = "0x60")]
		public void PlaySwipeFromRectToRect(RectTransform startRect, RectTransform endRect, float requiredInputRotation, Action onRequiredInputCompleted)
		{
			_currentSwipeMode = default(SwipeMode);
			_startRectTransform = startRect;
			_endRectTransform = endRect;
			StartSwipeAnimation(requiredInputRotation, onRequiredInputCompleted);
		}

		[Token(Token = "0x6001649")]
		[Address(RVA = "0x3D1B138", Offset = "0x3D1B138", Length = "0x6C")]
		public void PlaySwipeFollowingGameObject(GameObject followTarget, Vector3 endWorldPoint, Action onRequiredInputCompleted)
		{
			_currentSwipeMode = SwipeMode.FollowGameObject;
			_followGameObject = followTarget;
			_endWorldPoint.x = endWorldPoint.x;
			_endWorldPoint.y = endWorldPoint.y;
			_endWorldPoint.z = endWorldPoint.z;
			StartSwipeAnimation(3.4028235E+38f, onRequiredInputCompleted);
		}

		[Token(Token = "0x600164A")]
		[Address(RVA = "0x3D1B1A4", Offset = "0x3D1B1A4", Length = "0x28")]
		public void PlaySwipeFromWorldToWorld(Vector3 startWorldPoint, Vector3 endWorldPoint, float requiredInputRotation, Action onRequiredInputCompleted)
		{
			_currentSwipeMode = SwipeMode.WorldPointToWorldPoint;
			_startWorldPoint.x = startWorldPoint.x;
			_startWorldPoint.y = startWorldPoint.y;
			_startWorldPoint.z = startWorldPoint.z;
			_endWorldPoint.x = endWorldPoint.x;
			_endWorldPoint.y = endWorldPoint.y;
			_endWorldPoint.z = endWorldPoint.z;
			StartSwipeAnimation(requiredInputRotation, onRequiredInputCompleted);
		}

		[Token(Token = "0x600164B")]
		[Address(RVA = "0x3D1B1CC", Offset = "0x3D1B1CC", Length = "0x58")]
		public void PlayTapAndSwipeAnimation(float requiredInputRotation, Action onRequiredInputCompleted)
		{
			_currentSwipeMode = default(SwipeMode);
			_startRectTransform = null;
			_endRectTransform = null;
			StartSwipeAnimation(requiredInputRotation, onRequiredInputCompleted);
		}

		[Token(Token = "0x600164C")]
		[Address(RVA = "0x3D1AEE0", Offset = "0x3D1AEE0", Length = "0x258")]
		private unsafe void StartSwipeAnimation(float requiredInputRotation, Action onRequiredInputCompleted)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SwipeTutorialUiController::StartSwipeAnimation");
		}

		[Token(Token = "0x600164D")]
		[Address(RVA = "0x3D1B224", Offset = "0x3D1B224", Length = "0x98")]
		public void StopAnimation()
		{
			if (!currentSequence.isAlive)
			{
				if (!delayTween.isAlive)
				{
					goto IL_0068;
				}
			}
			else
			{
				currentSequence.Stop();
				if (!delayTween.isAlive)
				{
					goto IL_0068;
				}
			}
			delayTween.Stop();
			if (!alphaTween.isAlive)
			{
				return;
			}
			goto IL_0091;
			IL_0091:
			alphaTween.Stop();
			return;
			IL_0068:
			if (alphaTween.isAlive)
			{
				goto IL_0091;
			}
		}

		[Token(Token = "0x600164E")]
		[Address(RVA = "0x3D1B2EC", Offset = "0x3D1B2EC", Length = "0x1AC")]
		private void PlayAnimationSequence()
		{
			if (fingerRectTransform == null)
			{
				return;
			}
			GameObject gameObject = fingerRectTransform.gameObject;
			if (gameObject.activeInHierarchy)
			{
				Vector2 startPosition = GetStartPosition();
				Vector2 endPosition = GetEndPosition();
				fingerRectTransform.anchoredPosition = startPosition;
				if (_currentSwipeMode == SwipeMode.FollowGameObject && _followGameObject != null)
				{
					PlayDynamicAnimationSequence(startPosition, endPosition);
				}
				else
				{
					PlayStaticAnimationSequence(startPosition, endPosition);
				}
			}
		}

		[Token(Token = "0x600164F")]
		[Address(RVA = "0x3D1B92C", Offset = "0x3D1B92C", Length = "0x24C")]
		private unsafe void PlayStaticAnimationSequence(Vector2 startPos, Vector2 endPos)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SwipeTutorialUiController::PlayStaticAnimationSequence");
		}

		[Token(Token = "0x6001650")]
		[Address(RVA = "0x3D1B6E0", Offset = "0x3D1B6E0", Length = "0x24C")]
		private unsafe void PlayDynamicAnimationSequence(Vector2 startPos, Vector2 endPos)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SwipeTutorialUiController::PlayDynamicAnimationSequence");
		}

		[Token(Token = "0x6001651")]
		[Address(RVA = "0x3D1B498", Offset = "0x3D1B498", Length = "0x154")]
		private Vector2 GetStartPosition()
		{
			if (_currentSwipeMode != SwipeMode.WorldPointToWorldPoint)
			{
				if (_currentSwipeMode != SwipeMode.FollowGameObject)
				{
					if (_currentSwipeMode == SwipeMode.RectTransformToRectTransform && _startRectTransform != null)
					{
						return RectTransformToCanvasPosition(_startRectTransform);
					}
				}
				else if (_followGameObject != null)
				{
					Transform transform = _followGameObject.transform;
					Vector3 position = transform.position;
					return WorldToCanvasPosition(position);
				}
				return fingerStartPosition;
			}
			Vector3 worldPosition = default(Vector3);
			worldPosition.x = _startWorldPoint.x;
			worldPosition.y = _startWorldPoint.y;
			worldPosition.z = _startWorldPoint.z;
			return WorldToCanvasPosition(worldPosition);
		}

		[Token(Token = "0x6001652")]
		[Address(RVA = "0x3D1B5EC", Offset = "0x3D1B5EC", Length = "0xF4")]
		private Vector2 GetEndPosition()
		{
			if (_currentSwipeMode != SwipeMode.WorldPointToWorldPoint && _currentSwipeMode != SwipeMode.FollowGameObject)
			{
				if (_currentSwipeMode == SwipeMode.RectTransformToRectTransform && _endRectTransform != null)
				{
					return RectTransformToCanvasPosition(_endRectTransform);
				}
				float num = swipeDistance;
				float num2 = 0f - swipeDistance;
				if (!swipeToRight)
				{
					num = num2;
				}
				float x = fingerStartPosition.x + num;
				Vector2 result = default(Vector2);
				result.x = x;
				return result;
			}
			Vector3 worldPosition = default(Vector3);
			worldPosition.x = _endWorldPoint.x;
			worldPosition.y = _endWorldPoint.y;
			worldPosition.z = _endWorldPoint.z;
			return WorldToCanvasPosition(worldPosition);
		}

		[Token(Token = "0x6001653")]
		[Address(RVA = "0x3D1BB78", Offset = "0x3D1BB78", Length = "0x2F0")]
		private Vector2 RectTransformToCanvasPosition(RectTransform rectTransform)
		{
			if (_canvas == null || fingerRectTransform == null)
			{
				return fingerStartPosition;
			}
			Canvas componentInParent = rectTransform.GetComponentInParent<Canvas>();
			if (!(componentInParent == _canvas))
			{
				Vector3 position = rectTransform.position;
				return WorldToCanvasPosition(position);
			}
			Camera cam = ((_canvas.renderMode == RenderMode.ScreenSpaceOverlay) ? null : _camera);
			Vector3 position2 = rectTransform.position;
			Vector3 worldPoint = default(Vector3);
			worldPoint.x = position2.x;
			worldPoint.y = position2.y;
			worldPoint.z = position2.z;
			Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(cam, worldPoint);
			Transform transform = fingerRectTransform.parent;
			Camera cam2;
			RectTransform rect;
			if (_canvas.renderMode != RenderMode.ScreenSpaceOverlay)
			{
				if ((object)transform != null)
				{
					if ((object)transform.GetType() != typeof(RectTransform))
					{
						transform = null;
					}
					cam2 = _camera;
					rect = (RectTransform)transform;
				}
				else
				{
					cam2 = _camera;
					rect = null;
				}
			}
			else if ((object)transform != null)
			{
				if ((object)transform.GetType() != typeof(RectTransform))
				{
					transform = null;
				}
				cam2 = null;
				rect = (RectTransform)transform;
			}
			else
			{
				cam2 = null;
				rect = null;
			}
			bool flag = RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, screenPoint, cam2, out var localPoint);
			return localPoint;
		}

		[Token(Token = "0x6001654")]
		[Address(RVA = "0x3D1BE68", Offset = "0x3D1BE68", Length = "0x248")]
		private Vector2 WorldToCanvasPosition(Vector3 worldPosition)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SwipeTutorialUiController::WorldToCanvasPosition");
			return default;
		}

		[Token(Token = "0x6001655")]
		[Address(RVA = "0x3D1B2BC", Offset = "0x3D1B2BC", Length = "0x30")]
		private void UpdateFingerPosition()
		{
			Vector2 startPosition = GetStartPosition();
			fingerRectTransform.anchoredPosition = startPosition;
		}

		[Token(Token = "0x6001656")]
		[Address(RVA = "0x3D1C0B0", Offset = "0x3D1C0B0", Length = "0x110")]
		private void Update()
		{
			if (_currentSwipeMode == SwipeMode.FollowGameObject && _followGameObject != null)
			{
				Transform transform = _followGameObject.transform;
				Vector3 position = transform.position;
				Vector2 anchoredPosition = WorldToCanvasPosition(position);
				if (!currentSequence.isAlive)
				{
					fingerRectTransform.anchoredPosition = anchoredPosition;
				}
			}
			if (_isTrackingInput)
			{
				TrackUserInput();
			}
		}

		[Token(Token = "0x6001657")]
		[Address(RVA = "0x3D1C1C0", Offset = "0x3D1C1C0", Length = "0x31C")]
		private void TrackUserInput()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SwipeTutorialUiController::TrackUserInput");
		}

		[Token(Token = "0x6001658")]
		[Address(RVA = "0x3D1C4DC", Offset = "0x3D1C4DC", Length = "0xC8")]
		private void OnRequiredInputCompleted()
		{
			//IL_01a5: Expected O, but got I4
			_isTrackingInput = false;
			_isInputActive = false;
			if (!currentSequence.isAlive)
			{
				if (!delayTween.isAlive)
				{
					goto IL_007e;
				}
			}
			else
			{
				currentSequence.Stop();
				if (!delayTween.isAlive)
				{
					goto IL_007e;
				}
			}
			delayTween.Stop();
			if (!alphaTween.isAlive)
			{
				goto IL_00b2;
			}
			goto IL_015a;
			IL_019c:
			object obj = 0;
			return;
			IL_00d8:
			Action completeAction;
			completeAction();
			goto IL_019c;
			IL_00b2:
			completeAction = _completeAction;
			if (_completeAction != null)
			{
				goto IL_00d8;
			}
			goto IL_019c;
			IL_007e:
			if (!alphaTween.isAlive)
			{
				goto IL_00b2;
			}
			goto IL_015a;
			IL_015a:
			alphaTween.Stop();
			completeAction = _completeAction;
			if (_completeAction != null)
			{
				goto IL_00d8;
			}
			goto IL_019c;
		}

		[Token(Token = "0x6001659")]
		[Address(RVA = "0x3D1C5A4", Offset = "0x3D1C5A4", Length = "0xAC")]
		public override void OnDisable()
		{
			base.OnDisable();
			if (!currentSequence.isAlive)
			{
				if (!delayTween.isAlive)
				{
					goto IL_0073;
				}
			}
			else
			{
				currentSequence.Stop();
				if (!delayTween.isAlive)
				{
					goto IL_0073;
				}
			}
			delayTween.Stop();
			if (!alphaTween.isAlive)
			{
				goto IL_00a7;
			}
			goto IL_0127;
			IL_00a7:
			_isTrackingInput = false;
			return;
			IL_0127:
			alphaTween.Stop();
			_isTrackingInput = false;
			return;
			IL_0073:
			if (!alphaTween.isAlive)
			{
				goto IL_00a7;
			}
			goto IL_0127;
		}

		[Token(Token = "0x600165A")]
		[Address(RVA = "0x3D1C650", Offset = "0x3D1C650", Length = "0x54")]
		public SwipeTutorialUiController()
		{
			tapScaleAmount = 1.3f;
			tapDuration = 0.4f;
			tapEase = Ease.OutQuad;
			swipeDistance = 100f;
			swipeDuration = 0.8f;
			swipeEase = Ease.InOutSine;
			swipeToRight = true;
			loopAnimation = true;
			delayBetweenLoops = 1f;
			fadeInDuration = 0.5f;
			fadeOutDuration = 0.3f;
		}
	}
}
