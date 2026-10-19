using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;
using UnityEngine.UI;

namespace _game.CoreGameKit.MenuLayer.SideBubbleSystem
{
	[RequireComponent(typeof(LayoutElement))]
	[Token(Token = "0x20005E9")]
	public class SideBubbleSlot : MonoBehaviour
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20005EA")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001469")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400146A")]
			public static Action<LayoutElement, float> _003C_003E9__15_0;

			[Token(Token = "0x400146B")]
			public static Action<LayoutElement, float> _003C_003E9__15_1;

			[Token(Token = "0x400146C")]
			public static Action<LayoutElement, float> _003C_003E9__16_0;

			[Token(Token = "0x400146D")]
			public static Action<LayoutElement, float> _003C_003E9__16_1;

			[Token(Token = "0x600195B")]
			[Address(RVA = "0x3D47960", Offset = "0x3D47960", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600195C")]
			[Address(RVA = "0x3D479C4", Offset = "0x3D479C4", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal void _003CShow_003Eb__15_0(LayoutElement le, float v)
			{
				LayoutElement layoutElement = default(LayoutElement);
				layoutElement.preferredWidth = v;
			}

			internal void _003CShow_003Eb__15_1(LayoutElement le, float v)
			{
				LayoutElement layoutElement = default(LayoutElement);
				layoutElement.preferredHeight = v;
			}

			internal void _003CHide_003Eb__16_0(LayoutElement le, float v)
			{
				LayoutElement layoutElement = default(LayoutElement);
				layoutElement.preferredWidth = v;
			}

			internal void _003CHide_003Eb__16_1(LayoutElement le, float v)
			{
				LayoutElement layoutElement = default(LayoutElement);
				layoutElement.preferredHeight = v;
			}
		}

		[SerializeField]
		[Token(Token = "0x400145E")]
		[FieldOffset(Offset = "0x20")]
		private float m_targetWidth;

		[SerializeField]
		[Token(Token = "0x400145F")]
		[FieldOffset(Offset = "0x24")]
		private float m_targetHeight;

		[SerializeField]
		[Token(Token = "0x4001460")]
		[FieldOffset(Offset = "0x28")]
		private float m_offscreenDistance;

		[SerializeField]
		[Token(Token = "0x4001461")]
		[FieldOffset(Offset = "0x2C")]
		private float m_animDuration;

		[SerializeField]
		[Token(Token = "0x4001462")]
		[FieldOffset(Offset = "0x30")]
		private Ease m_showEase;

		[SerializeField]
		[Token(Token = "0x4001463")]
		[FieldOffset(Offset = "0x34")]
		private Ease m_hideEase;

		[SerializeField]
		[Token(Token = "0x4001464")]
		[FieldOffset(Offset = "0x38")]
		private RectTransform m_buttonRect;

		[SerializeField]
		[Token(Token = "0x4001465")]
		[FieldOffset(Offset = "0x40")]
		private LayoutElement m_layoutElement;

		[Token(Token = "0x4001466")]
		[FieldOffset(Offset = "0x48")]
		private Sequence _activeSequence;

		[Token(Token = "0x4001467")]
		[FieldOffset(Offset = "0x58")]
		internal SideBubbleSide _side;

		[Token(Token = "0x4001468")]
		[FieldOffset(Offset = "0x5C")]
		private bool _isVisible;

		[Token(Token = "0x17000264")]
		public bool IsVisible
		{
			[Token(Token = "0x6001953")]
			[Address(RVA = "0x3D470F4", Offset = "0x3D470F4", Length = "0x8")]
			get
			{
				return _isVisible;
			}
		}

		[Token(Token = "0x6001954")]
		[Address(RVA = "0x3D470FC", Offset = "0x3D470FC", Length = "0x8")]
		public void SetSide(SideBubbleSide side)
		{
			_side = side;
		}

		[Token(Token = "0x6001955")]
		[Address(RVA = "0x3D47104", Offset = "0x3D47104", Length = "0x84")]
		public void InitHidden()
		{
			m_layoutElement.preferredWidth = 0f;
			m_layoutElement.preferredHeight = 0f;
			float x = m_offscreenDistance;
			float num = 0f - m_offscreenDistance;
			if (_side == SideBubbleSide.Left)
			{
				x = num;
			}
			Vector2 anchoredPosition = default(Vector2);
			anchoredPosition.x = x;
			anchoredPosition.y = 0f;
			m_buttonRect.anchoredPosition = anchoredPosition;
			_isVisible = false;
		}

		[Token(Token = "0x6001956")]
		[Address(RVA = "0x3D471A4", Offset = "0x3D471A4", Length = "0x3D0")]
		public Sequence Show()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SideBubbleSlot::Show");
			return default;
		}

		[Token(Token = "0x6001957")]
		[Address(RVA = "0x3D47574", Offset = "0x3D47574", Length = "0x38C")]
		public Sequence Hide()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SideBubbleSlot::Hide");
			return default;
		}

		[Token(Token = "0x6001958")]
		[Address(RVA = "0x3D47188", Offset = "0x3D47188", Length = "0x1C")]
		private Vector2 GetOffscreenPosition()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SideBubbleSlot::GetOffscreenPosition");
			return default;
		}

		[Token(Token = "0x6001959")]
		[Address(RVA = "0x3D47900", Offset = "0x3D47900", Length = "0x40")]
		private void OnDisable()
		{
			if (_activeSequence.isAlive)
			{
				_activeSequence.Stop();
			}
		}

		[Token(Token = "0x600195A")]
		[Address(RVA = "0x3D47940", Offset = "0x3D47940", Length = "0x20")]
		public SideBubbleSlot()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [9308080]");
			m_targetWidth = 0f;
			m_showEase = Ease.Default;
		}
	}
}
