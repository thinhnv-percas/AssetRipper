using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace UnityEngine.UI
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x7270E0", Offset = "0x7270E0")]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x7270E0", Offset = "0x7270E0")]
	[Token(Token = "0x2000012")]
	public class GraphicRaycaster : BaseRaycaster
	{
		[Token(Token = "0x200007E")]
		public enum BlockingObjects
		{
			[Token(Token = "0x4000236")]
			None = 0,
			[Token(Token = "0x4000237")]
			TwoD = 1,
			[Token(Token = "0x4000238")]
			ThreeD = 2,
			[Token(Token = "0x4000239")]
			All = 3
		}

		[Token(Token = "0x400005F")]
		protected const int kNoEventMaskSet = -1;

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x728800", Offset = "0x728800")]
		[SerializeField]
		[Token(Token = "0x4000060")]
		[FieldOffset(Offset = "0x20")]
		private bool m_IgnoreReversedGraphics;

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x72884C", Offset = "0x72884C")]
		[SerializeField]
		[Token(Token = "0x4000061")]
		[FieldOffset(Offset = "0x24")]
		private BlockingObjects m_BlockingObjects;

		[SerializeField]
		[Token(Token = "0x4000062")]
		[FieldOffset(Offset = "0x28")]
		protected LayerMask m_BlockingMask;

		[Token(Token = "0x4000063")]
		[FieldOffset(Offset = "0x30")]
		private Canvas m_Canvas;

		[NonSerialized]
		[Token(Token = "0x4000064")]
		[FieldOffset(Offset = "0x38")]
		private List<Graphic> m_RaycastResults;

		[NonSerialized]
		[Token(Token = "0x4000065")]
		private static readonly List<Graphic> s_SortedGraphics;

		[Token(Token = "0x17000038")]
		public override int sortOrderPriority
		{
			[Token(Token = "0x60000EC")]
			[Address(RVA = "0xF481C8", Offset = "0xF481C8", Length = "0x58")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x17000039")]
		public override int renderOrderPriority
		{
			[Token(Token = "0x60000ED")]
			[Address(RVA = "0xF482B8", Offset = "0xF482B8", Length = "0x64")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x1700003A")]
		public bool ignoreReversedGraphics
		{
			[Token(Token = "0x60000EE")]
			[Address(RVA = "0xF4831C", Offset = "0xF4831C", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60000EF")]
			[Address(RVA = "0xF48324", Offset = "0xF48324", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x1700003B")]
		public BlockingObjects blockingObjects
		{
			[Token(Token = "0x60000F0")]
			[Address(RVA = "0xF48330", Offset = "0xF48330", Length = "0x8")]
			get
			{
				return BlockingObjects.None;
			}
			[Token(Token = "0x60000F1")]
			[Address(RVA = "0xF48338", Offset = "0xF48338", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700003C")]
		private Canvas canvas
		{
			[Token(Token = "0x60000F3")]
			[Address(RVA = "0xF48220", Offset = "0xF48220", Length = "0x98")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700003D")]
		public override Camera eventCamera
		{
			[Token(Token = "0x60000F5")]
			[Address(RVA = "0xF49788", Offset = "0xF49788", Length = "0x148")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x60000F2")]
		[Address(RVA = "0xF48340", Offset = "0xF48340", Length = "0x88")]
		protected GraphicRaycaster()
		{
		}

		[Token(Token = "0x60000F4")]
		[Address(RVA = "0xF483C8", Offset = "0xF483C8", Length = "0xE48")]
		public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
		{
		}

		[Token(Token = "0x60000F6")]
		[Address(RVA = "0xF492D8", Offset = "0xF492D8", Length = "0x4B0")]
		private static void Raycast(Canvas canvas, Camera eventCamera, Vector2 pointerPosition, IList<Graphic> foundGraphics, List<Graphic> results)
		{
		}
	}
}
