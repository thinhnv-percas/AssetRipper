using System;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;
using UnityEngine.UI;

namespace _game.CoreGameKit.Tools.CreativeVideo
{
	[RequireComponent(typeof(Canvas))]
	[Token(Token = "0x20005C5")]
	public class HandCursorManager : MonoBehaviour
	{
		[Header("Hand Cursor Settings")]
		[Tooltip("Hand cursor image")]
		[SerializeField]
		[Token(Token = "0x40013F1")]
		[FieldOffset(Offset = "0x20")]
		private Image handCursorImage;

		[Tooltip("Cursor size multiplier (1.0 = original size)")]
		[SerializeField]
		[Range(0.1f, 5f)]
		[Token(Token = "0x40013F2")]
		[FieldOffset(Offset = "0x28")]
		private float cursorSizeMultiplier;

		[Tooltip("Offset from mouse position")]
		[SerializeField]
		[Token(Token = "0x40013F3")]
		[FieldOffset(Offset = "0x2C")]
		private Vector2 cursorOffset;

		[Header("Click Animation")]
		[Tooltip("Enable click animation")]
		[SerializeField]
		[Token(Token = "0x40013F4")]
		[FieldOffset(Offset = "0x34")]
		private bool enableClickAnimation;

		[Tooltip("Rotation angle when clicked (in degrees)")]
		[SerializeField]
		[Range(0f, 45f)]
		[Token(Token = "0x40013F5")]
		[FieldOffset(Offset = "0x38")]
		private float clickRotationAngle;

		[Tooltip("Click animation duration")]
		[SerializeField]
		[Range(0.05f, 0.5f)]
		[Token(Token = "0x40013F6")]
		[FieldOffset(Offset = "0x3C")]
		private float clickAnimationDuration;

		[Header("Auto Setup")]
		[Tooltip("Hide system cursor when hand cursor is active")]
		[SerializeField]
		[Token(Token = "0x40013F7")]
		[FieldOffset(Offset = "0x40")]
		private bool hideSystemCursor;

		[Token(Token = "0x40013F8")]
		[FieldOffset(Offset = "0x48")]
		private Canvas canvas;

		[Token(Token = "0x40013F9")]
		[FieldOffset(Offset = "0x50")]
		private RectTransform cursorRectTransform;

		[Token(Token = "0x40013FA")]
		[FieldOffset(Offset = "0x58")]
		private Vector2 originalSize;

		[Token(Token = "0x40013FB")]
		[FieldOffset(Offset = "0x60")]
		private bool isInitialized;

		[Token(Token = "0x40013FC")]
		[FieldOffset(Offset = "0x68")]
		private Tween clickTween;

		[Token(Token = "0x40013FD")]
		[FieldOffset(Offset = "0x78")]
		private bool isMouseDown;

		[Token(Token = "0x60018C3")]
		[Address(RVA = "0x3D40650", Offset = "0x3D40650", Length = "0x1D4")]
		private void Awake()
		{
			Canvas component = GetComponent<Canvas>();
			canvas = component;
			UnityEngine.Object obj;
			if (!(canvas != null))
			{
				obj = handCursorImage;
			}
			else
			{
				canvas.renderMode = default(RenderMode);
				canvas.sortingOrder = 9999;
				obj = handCursorImage;
			}
			if (obj != null)
			{
				RectTransform component2 = handCursorImage.GetComponent<RectTransform>();
				cursorRectTransform = component2;
				if (cursorRectTransform != null)
				{
					Vector2 sizeDelta = cursorRectTransform.sizeDelta;
					originalSize.x = sizeDelta.x;
					originalSize.y = sizeDelta.y;
				}
			}
		}

		[Token(Token = "0x60018C4")]
		[Address(RVA = "0x3D40824", Offset = "0x3D40824", Length = "0x4")]
		private void Start()
		{
			Initialize();
		}

		[Token(Token = "0x60018C5")]
		[Address(RVA = "0x3D40828", Offset = "0x3D40828", Length = "0x17C")]
		private void Initialize()
		{
			if (isInitialized)
			{
				return;
			}
			if (!(handCursorImage != null))
			{
				if (!hideSystemCursor)
				{
					goto IL_005d;
				}
			}
			else
			{
				GameObject gameObject = handCursorImage.gameObject;
				gameObject.SetActive(value: true);
				if (!hideSystemCursor)
				{
					goto IL_005d;
				}
			}
			Cursor.visible = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DCE1]");
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				goto IL_0090;
			}
			goto IL_015b;
			IL_005d:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DCE1]");
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				goto IL_0090;
			}
			goto IL_015b;
			IL_009f:
			UnityEngine.Object obj;
			if (!(obj == null))
			{
				float y = originalSize.y * cursorSizeMultiplier;
				float x = cursorSizeMultiplier * originalSize.x;
				Vector2 sizeDelta = default(Vector2);
				sizeDelta.x = x;
				sizeDelta.y = y;
				cursorRectTransform.sizeDelta = sizeDelta;
			}
			isInitialized = true;
			return;
			IL_0090:
			obj = cursorRectTransform;
			goto IL_009f;
			IL_015b:
			_ = 1;
			obj = cursorRectTransform;
			goto IL_009f;
		}

		[Token(Token = "0x60018C6")]
		[Address(RVA = "0x3D40A6C", Offset = "0x3D40A6C", Length = "0x130")]
		private void Update()
		{
			if (!(handCursorImage != null))
			{
				return;
			}
			GameObject gameObject = handCursorImage.gameObject;
			if (!gameObject.activeSelf)
			{
				return;
			}
			UpdateCursorPosition();
			if (enableClickAnimation)
			{
				if (Input.GetMouseButtonDown(0) && !isMouseDown)
				{
					isMouseDown = true;
					PlayClickAnimation();
				}
				if (Input.GetMouseButtonUp(0) && isMouseDown)
				{
					isMouseDown = false;
					PlayReleaseAnimation();
				}
			}
		}

		[Token(Token = "0x60018C7")]
		[Address(RVA = "0x3D40C6C", Offset = "0x3D40C6C", Length = "0x80")]
		private void HandleClickAnimation()
		{
			if (enableClickAnimation)
			{
				if (Input.GetMouseButtonDown(0) && !isMouseDown)
				{
					isMouseDown = true;
					PlayClickAnimation();
				}
				if (Input.GetMouseButtonUp(0) && isMouseDown)
				{
					isMouseDown = false;
					PlayReleaseAnimation();
				}
			}
		}

		[Token(Token = "0x60018C8")]
		[Address(RVA = "0x3D40CEC", Offset = "0x3D40CEC", Length = "0x114")]
		private void PlayClickAnimation()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HandCursorManager::PlayClickAnimation");
		}

		[Token(Token = "0x60018C9")]
		[Address(RVA = "0x3D40E00", Offset = "0x3D40E00", Length = "0x128")]
		private void PlayReleaseAnimation()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HandCursorManager::PlayReleaseAnimation");
		}

		[Token(Token = "0x60018CA")]
		[Address(RVA = "0x3D40B9C", Offset = "0x3D40B9C", Length = "0xD0")]
		private void UpdateCursorPosition()
		{
			if (!(cursorRectTransform == null))
			{
				Vector3 mousePosition = Input.mousePosition;
				float y = mousePosition.y + cursorOffset.y;
				float x = mousePosition.x + cursorOffset.x;
				Vector3 position = default(Vector3);
				position.x = x;
				position.y = y;
				position.z = 0f;
				cursorRectTransform.position = position;
			}
		}

		[Token(Token = "0x60018CB")]
		[Address(RVA = "0x3D40F28", Offset = "0x3D40F28", Length = "0xEC")]
		public void SetCursorSize(float multiplier)
		{
			bool flag = multiplier < 5f;
			bool flag2 = multiplier == 5f;
			bool flag3 = multiplier == multiplier;
			bool flag4 = 5f == 5f;
			bool flag5 = flag3 && flag4;
			bool flag6 = !flag5;
			bool flag7 = flag == flag6;
			bool flag8 = !flag2;
			float num = ((!(flag7 && flag8)) ? multiplier : 5f);
			float num2 = ((!(multiplier < 0.1f)) ? num : 0.1f);
			cursorSizeMultiplier = num2;
			if (!(cursorRectTransform == null))
			{
				float y = originalSize.y * cursorSizeMultiplier;
				float x = cursorSizeMultiplier * originalSize.x;
				Vector2 sizeDelta = default(Vector2);
				sizeDelta.x = x;
				sizeDelta.y = y;
				cursorRectTransform.sizeDelta = sizeDelta;
			}
		}

		[Token(Token = "0x60018CC")]
		[Address(RVA = "0x3D409A4", Offset = "0x3D409A4", Length = "0xC8")]
		private void UpdateCursorSize()
		{
			if (!(cursorRectTransform == null))
			{
				float y = originalSize.y * cursorSizeMultiplier;
				float x = cursorSizeMultiplier * originalSize.x;
				Vector2 sizeDelta = default(Vector2);
				sizeDelta.x = x;
				sizeDelta.y = y;
				cursorRectTransform.sizeDelta = sizeDelta;
			}
		}

		[Token(Token = "0x60018CD")]
		[Address(RVA = "0x3D41014", Offset = "0x3D41014", Length = "0xC0")]
		public void SetHandCursorSprite(Sprite newSprite)
		{
			if (handCursorImage != null)
			{
				handCursorImage.sprite = newSprite;
			}
		}

		[Token(Token = "0x60018CE")]
		[Address(RVA = "0x3D410D4", Offset = "0x3D410D4", Length = "0x8")]
		public void SetCursorOffset(Vector2 offset)
		{
			cursorOffset.x = offset.x;
			cursorOffset.y = offset.y;
		}

		[Token(Token = "0x60018CF")]
		[Address(RVA = "0x3D410DC", Offset = "0x3D410DC", Length = "0xFC")]
		public void SetClickAnimation(bool enabled)
		{
			enableClickAnimation = enabled;
			if (!enabled && cursorRectTransform != null)
			{
				clickTween.Stop();
				Quaternion localRotation = default(Quaternion);
				localRotation.x = Quaternion.identity.x;
				localRotation.y = Quaternion.identity.y;
				localRotation.z = Quaternion.identity.z;
				localRotation.w = Quaternion.identity.w;
				cursorRectTransform.localRotation = localRotation;
			}
		}

		[Token(Token = "0x60018D0")]
		[Address(RVA = "0x3D411D8", Offset = "0x3D411D8", Length = "0x24")]
		public void SetClickRotationAngle(float angle)
		{
			bool flag = angle < 45f;
			bool flag2 = angle == 45f;
			bool flag3 = angle == angle;
			bool flag4 = !flag3;
			bool flag5 = flag == flag4;
			bool flag6 = !flag2;
			float num = ((!(flag5 && flag6)) ? angle : 45f);
			float num2 = ((!(angle < 0f)) ? num : 0f);
			clickRotationAngle = num2;
		}

		[Token(Token = "0x60018D1")]
		[Address(RVA = "0x3D411FC", Offset = "0x3D411FC", Length = "0x28")]
		public void SetClickAnimationDuration(float duration)
		{
			bool flag = duration < 0.5f;
			bool flag2 = duration == 0.5f;
			bool flag3 = duration == duration;
			bool flag4 = 0.5f == 0.5f;
			bool flag5 = flag3 && flag4;
			bool flag6 = !flag5;
			bool flag7 = flag == flag6;
			bool flag8 = !flag2;
			float num = ((!(flag7 && flag8)) ? duration : 0.5f);
			float num2 = ((!(duration < 0.05f)) ? num : 0.05f);
			clickAnimationDuration = num2;
		}

		[Token(Token = "0x60018D2")]
		[Address(RVA = "0x3D41224", Offset = "0x3D41224", Length = "0x140")]
		public void SetHandCursorImage(Image image)
		{
			Image image2 = default(Image);
			handCursorImage = image2;
			if (handCursorImage != null)
			{
				RectTransform component = handCursorImage.GetComponent<RectTransform>();
				cursorRectTransform = component;
				if (cursorRectTransform != null)
				{
					Vector2 sizeDelta = cursorRectTransform.sizeDelta;
					originalSize.x = sizeDelta.x;
					originalSize.y = sizeDelta.y;
				}
			}
		}

		[Token(Token = "0x60018D3")]
		[Address(RVA = "0x3D41364", Offset = "0x3D41364", Length = "0xDC")]
		private void OnEnable()
		{
			if (!isInitialized)
			{
				return;
			}
			if (!(handCursorImage != null))
			{
				if (!hideSystemCursor)
				{
					return;
				}
			}
			else
			{
				GameObject gameObject = handCursorImage.gameObject;
				gameObject.SetActive(value: true);
				if (!hideSystemCursor)
				{
					return;
				}
			}
			Cursor.visible = false;
		}

		[Token(Token = "0x60018D4")]
		[Address(RVA = "0x3D41440", Offset = "0x3D41440", Length = "0xCC")]
		private void OnDisable()
		{
			Cursor.visible = true;
			if (handCursorImage != null)
			{
				GameObject gameObject = handCursorImage.gameObject;
				gameObject.SetActive(value: false);
			}
			clickTween.Stop();
			isMouseDown = false;
		}

		[Token(Token = "0x60018D5")]
		[Address(RVA = "0x3D4150C", Offset = "0x3D4150C", Length = "0x30")]
		private void OnDestroy()
		{
			Cursor.visible = true;
			clickTween.Stop();
		}

		[Token(Token = "0x60018D6")]
		[Address(RVA = "0x3D4153C", Offset = "0x3D4153C", Length = "0x88")]
		public HandCursorManager()
		{
			cursorSizeMultiplier = 1f;
			_ = Vector2.zero;
			_ = 1;
			_ = 5.2386907467983756E-11;
			_ = 1;
		}
	}
}
