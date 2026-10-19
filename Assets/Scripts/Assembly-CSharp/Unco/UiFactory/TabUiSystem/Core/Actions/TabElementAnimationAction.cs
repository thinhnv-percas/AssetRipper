using Cpp2ILInjected;
using PrimeTween;
using Unco.UiFactory.TabUiSystem.Interfaces;
using UnityEngine;
using _game.CoreGameKit.MenuLayer;

namespace Unco.UiFactory.TabUiSystem.Core.Actions
{
	[Token(Token = "0x2000797")]
	public class TabElementAnimationAction : TabAction
	{
		[Header("Icon")]
		[SerializeField]
		[Token(Token = "0x4001928")]
		[FieldOffset(Offset = "0x20")]
		private RectTransform m_icon;

		[SerializeField]
		[Token(Token = "0x4001929")]
		[FieldOffset(Offset = "0x28")]
		private float m_iconActiveScale;

		[SerializeField]
		[Token(Token = "0x400192A")]
		[FieldOffset(Offset = "0x2C")]
		private Vector2 m_iconActivePosition;

		[SerializeField]
		[Token(Token = "0x400192B")]
		[FieldOffset(Offset = "0x34")]
		private Vector2 m_iconInactivePosition;

		[Header("Label")]
		[SerializeField]
		[Token(Token = "0x400192C")]
		[FieldOffset(Offset = "0x40")]
		private RectTransform m_label;

		[SerializeField]
		[Token(Token = "0x400192D")]
		[FieldOffset(Offset = "0x48")]
		private float m_labelHideOffsetY;

		[Header("Animation")]
		[SerializeField]
		[Token(Token = "0x400192E")]
		[FieldOffset(Offset = "0x4C")]
		private float m_duration;

		[SerializeField]
		[Token(Token = "0x400192F")]
		[FieldOffset(Offset = "0x50")]
		private Ease m_ease;

		[SerializeField]
		[Token(Token = "0x4001930")]
		[FieldOffset(Offset = "0x54")]
		private bool m_startActive;

		[Token(Token = "0x4001931")]
		[FieldOffset(Offset = "0x58")]
		private Sequence _sequence;

		[Token(Token = "0x4001932")]
		[FieldOffset(Offset = "0x68")]
		private Vector2 _labelOriginalPos;

		[Token(Token = "0x6002004")]
		[Address(RVA = "0x3D959D0", Offset = "0x3D959D0", Length = "0x34")]
		private void Awake()
		{
			Vector2 anchoredPosition = m_label.anchoredPosition;
			_labelOriginalPos.x = anchoredPosition.x;
			_labelOriginalPos.y = anchoredPosition.y;
		}

		[Token(Token = "0x6002005")]
		[Address(RVA = "0x3D95A04", Offset = "0x3D95A04", Length = "0x14")]
		private void Start()
		{
			if (m_startActive)
			{
				SetActive();
			}
			else
			{
				SetInactive();
			}
		}

		[Token(Token = "0x6002006")]
		[Address(RVA = "0x3D95BA0", Offset = "0x3D95BA0", Length = "0x168")]
		public override void OnSelectTab(HomeTabId baseId, HomeTabId from)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TabElementAnimationAction::OnSelectTab");
		}

		[Token(Token = "0x6002007")]
		[Address(RVA = "0x3D95D08", Offset = "0x3D95D08", Length = "0x180")]
		public override void OnDeselectTab(HomeTabId baseId, HomeTabId to)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TabElementAnimationAction::OnDeselectTab");
		}

		[Token(Token = "0x6002008")]
		[Address(RVA = "0x3D95A18", Offset = "0x3D95A18", Length = "0xC8")]
		private void SetActive()
		{
			float z = Vector3.one.z * m_iconActiveScale;
			float y = m_iconActiveScale * Vector3.one.y;
			float x = m_iconActiveScale * Vector3.one.x;
			Vector3 localScale = default(Vector3);
			localScale.x = x;
			localScale.y = y;
			localScale.z = z;
			m_icon.localScale = localScale;
			Vector2 anchoredPosition = default(Vector2);
			anchoredPosition.x = m_iconActivePosition.x;
			anchoredPosition.y = m_iconActivePosition.y;
			m_icon.anchoredPosition = anchoredPosition;
			GameObject gameObject = m_label.gameObject;
			gameObject.SetActive(value: true);
			Vector2 anchoredPosition2 = default(Vector2);
			anchoredPosition2.x = _labelOriginalPos.x;
			anchoredPosition2.y = _labelOriginalPos.y;
			m_label.anchoredPosition = anchoredPosition2;
		}

		[Token(Token = "0x6002009")]
		[Address(RVA = "0x3D95AE0", Offset = "0x3D95AE0", Length = "0xC0")]
		private void SetInactive()
		{
			Vector3 localScale = default(Vector3);
			localScale.x = Vector3.one.x;
			localScale.y = Vector3.one.y;
			localScale.z = Vector3.one.z;
			m_icon.localScale = localScale;
			GameObject gameObject = m_label.gameObject;
			gameObject.SetActive(value: false);
			Vector2 anchoredPosition = default(Vector2);
			anchoredPosition.x = m_iconInactivePosition.x;
			anchoredPosition.y = m_iconInactivePosition.y;
			m_icon.anchoredPosition = anchoredPosition;
			float y = _labelOriginalPos.y + m_labelHideOffsetY;
			Vector2 anchoredPosition2 = default(Vector2);
			anchoredPosition2.x = _labelOriginalPos.x;
			anchoredPosition2.y = y;
			m_label.anchoredPosition = anchoredPosition2;
		}

		[Token(Token = "0x600200A")]
		[Address(RVA = "0x3D95E88", Offset = "0x3D95E88", Length = "0x28")]
		public TabElementAnimationAction()
		{
			m_iconActiveScale = 1.3f;
			m_labelHideOffsetY = -40f;
			m_duration = 0.25f;
			m_ease = Ease.OutCubic;
		}
	}
}
