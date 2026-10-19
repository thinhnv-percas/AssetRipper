using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _game.CoreGameKit.Ui
{
	[RequireComponent(typeof(Graphic))]
	[Token(Token = "0x200053C")]
	public class PeekableBackground : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		[SerializeField]
		[Token(Token = "0x40011A3")]
		[FieldOffset(Offset = "0x20")]
		private CanvasGroup _targetCanvasGroup;

		[SerializeField]
		[Token(Token = "0x40011A4")]
		[FieldOffset(Offset = "0x28")]
		private float _fadeOutDuration;

		[SerializeField]
		[Token(Token = "0x40011A5")]
		[FieldOffset(Offset = "0x2C")]
		private float _fadeInDuration;

		[Token(Token = "0x40011A6")]
		[FieldOffset(Offset = "0x30")]
		private Tween _activeTween;

		[Token(Token = "0x60015EB")]
		[Address(RVA = "0x3D16B40", Offset = "0x3D16B40", Length = "0xDC")]
		private void Awake()
		{
			if (_targetCanvasGroup == null)
			{
				CanvasGroup componentInParent = GetComponentInParent<CanvasGroup>();
				_targetCanvasGroup = componentInParent;
			}
		}

		[Token(Token = "0x60015EC")]
		[Address(RVA = "0x3D16C1C", Offset = "0x3D16C1C", Length = "0x64")]
		public void OnPointerDown(PointerEventData eventData)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PeekableBackground::OnPointerDown");
		}

		[Token(Token = "0x60015ED")]
		[Address(RVA = "0x3D16C80", Offset = "0x3D16C80", Length = "0x64")]
		public void OnPointerUp(PointerEventData eventData)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PeekableBackground::OnPointerUp");
		}

		[Token(Token = "0x60015EE")]
		[Address(RVA = "0x3D16CE4", Offset = "0x3D16CE4", Length = "0xB8")]
		private void OnDisable()
		{
			_activeTween.Stop();
			if (_targetCanvasGroup != null)
			{
				_targetCanvasGroup.alpha = 1f;
			}
		}

		[Token(Token = "0x60015EF")]
		[Address(RVA = "0x3D16D9C", Offset = "0x3D16D9C", Length = "0x14")]
		public PeekableBackground()
		{
			_fadeOutDuration = 0.15f;
			_fadeInDuration = 0.2f;
		}
	}
}
