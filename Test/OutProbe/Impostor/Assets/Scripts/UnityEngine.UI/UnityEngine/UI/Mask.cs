using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
	[RequireComponent(typeof(RectTransform))]
	[ExecuteAlways]
	[DisallowMultipleComponent]
	[AddComponentMenu("UI/Mask", 13)]
	[Token(Token = "0x2000055")]
	public class Mask : UIBehaviour, ICanvasRaycastFilter, IMaterialModifier
	{
		[NonSerialized]
		[Token(Token = "0x4000197")]
		[FieldOffset(Offset = "0x20")]
		private RectTransform m_RectTransform;

		[SerializeField]
		[Token(Token = "0x4000198")]
		[FieldOffset(Offset = "0x28")]
		private bool m_ShowMaskGraphic;

		[NonSerialized]
		[Token(Token = "0x4000199")]
		[FieldOffset(Offset = "0x30")]
		private Graphic m_Graphic;

		[NonSerialized]
		[Token(Token = "0x400019A")]
		[FieldOffset(Offset = "0x38")]
		private Material m_MaskMaterial;

		[NonSerialized]
		[Token(Token = "0x400019B")]
		[FieldOffset(Offset = "0x40")]
		private Material m_UnmaskMaterial;

		[Token(Token = "0x170000D5")]
		public RectTransform rectTransform
		{
			[Token(Token = "0x6000337")]
			[Address(RVA = "0x1829E9C", Offset = "0x1829E9C", Length = "0x58")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000D6")]
		public bool showMaskGraphic
		{
			[Token(Token = "0x6000338")]
			[Address(RVA = "0x1829EF4", Offset = "0x1829EF4", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000339")]
			[Address(RVA = "0x1829EFC", Offset = "0x1829EFC", Length = "0xB0")]
			set
			{
			}
		}

		[Token(Token = "0x170000D7")]
		public Graphic graphic
		{
			[Token(Token = "0x600033A")]
			[Address(RVA = "0x1829FAC", Offset = "0x1829FAC", Length = "0x58")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x600033B")]
		[Address(RVA = "0x182A004", Offset = "0x182A004", Length = "0x10")]
		protected Mask()
		{
		}

		[Token(Token = "0x600033C")]
		[Address(RVA = "0x182A014", Offset = "0x182A014", Length = "0x90")]
		public virtual bool MaskEnabled()
		{
			return false;
		}

		[Obsolete("Not used anymore.")]
		[Token(Token = "0x600033D")]
		[Address(RVA = "0x182A0A4", Offset = "0x182A0A4", Length = "0x4")]
		public virtual void OnSiblingGraphicEnabledDisabled()
		{
		}

		[Token(Token = "0x600033E")]
		[Address(RVA = "0x182A0A8", Offset = "0x182A0A8", Length = "0x160")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x600033F")]
		[Address(RVA = "0x182A478", Offset = "0x182A478", Length = "0x1C4")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x6000340")]
		[Address(RVA = "0x182A63C", Offset = "0x182A63C", Length = "0xAC")]
		public virtual bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
		{
			return false;
		}

		[Token(Token = "0x6000341")]
		[Address(RVA = "0x182A6E8", Offset = "0x182A6E8", Length = "0x294")]
		public virtual Material GetModifiedMaterial(Material baseMaterial)
		{
			return null;
		}
	}
}
