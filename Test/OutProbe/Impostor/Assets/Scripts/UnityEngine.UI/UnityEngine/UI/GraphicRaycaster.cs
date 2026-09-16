using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace UnityEngine.UI
{
	[AddComponentMenu("Event/Graphic Raycaster")]
	[RequireComponent(typeof(Canvas))]
	[Token(Token = "0x200001F")]
	public class GraphicRaycaster : BaseRaycaster
	{
		[Token(Token = "0x2000020")]
		public enum BlockingObjects
		{
			[Token(Token = "0x400008C")]
			None = 0,
			[Token(Token = "0x400008D")]
			TwoD = 1,
			[Token(Token = "0x400008E")]
			ThreeD = 2,
			[Token(Token = "0x400008F")]
			All = 3
		}

		[Token(Token = "0x4000084")]
		protected const int kNoEventMaskSet = -1;

		[SerializeField]
		[FormerlySerializedAs("ignoreReversedGraphics")]
		[Token(Token = "0x4000085")]
		[FieldOffset(Offset = "0x28")]
		private bool m_IgnoreReversedGraphics;

		[FormerlySerializedAs("blockingObjects")]
		[SerializeField]
		[Token(Token = "0x4000086")]
		[FieldOffset(Offset = "0x2C")]
		private BlockingObjects m_BlockingObjects;

		[SerializeField]
		[Token(Token = "0x4000087")]
		[FieldOffset(Offset = "0x30")]
		protected LayerMask m_BlockingMask;

		[Token(Token = "0x4000088")]
		[FieldOffset(Offset = "0x38")]
		private Canvas m_Canvas;

		[NonSerialized]
		[Token(Token = "0x4000089")]
		[FieldOffset(Offset = "0x40")]
		private List<Graphic> m_RaycastResults;

		[NonSerialized]
		[Token(Token = "0x400008A")]
		private static readonly List<Graphic> s_SortedGraphics;

		[Token(Token = "0x17000043")]
		public override int sortOrderPriority
		{
			[Token(Token = "0x6000120")]
			[Address(RVA = "0x16CEF64", Offset = "0x16CEF64", Length = "0x48")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x17000044")]
		public override int renderOrderPriority
		{
			[Token(Token = "0x6000121")]
			[Address(RVA = "0x16CF040", Offset = "0x16CF040", Length = "0x54")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x17000045")]
		public bool ignoreReversedGraphics
		{
			[Token(Token = "0x6000122")]
			[Address(RVA = "0x16CF094", Offset = "0x16CF094", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000123")]
			[Address(RVA = "0x16CF09C", Offset = "0x16CF09C", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000046")]
		public BlockingObjects blockingObjects
		{
			[Token(Token = "0x6000124")]
			[Address(RVA = "0x16CF0A8", Offset = "0x16CF0A8", Length = "0x8")]
			get
			{
				return BlockingObjects.None;
			}
			[Token(Token = "0x6000125")]
			[Address(RVA = "0x16CF0B0", Offset = "0x16CF0B0", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000047")]
		public LayerMask blockingMask
		{
			[Token(Token = "0x6000126")]
			[Address(RVA = "0x16CF0B8", Offset = "0x16CF0B8", Length = "0x8")]
			get
			{
				return default(LayerMask);
			}
			[Token(Token = "0x6000127")]
			[Address(RVA = "0x16CF0C0", Offset = "0x16CF0C0", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000048")]
		private Canvas canvas
		{
			[Token(Token = "0x6000129")]
			[Address(RVA = "0x16CEFAC", Offset = "0x16CEFAC", Length = "0x94")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000049")]
		public override Camera eventCamera
		{
			[Token(Token = "0x600012B")]
			[Address(RVA = "0x16D0398", Offset = "0x16D0398", Length = "0xC8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000128")]
		[Address(RVA = "0x16CF0C8", Offset = "0x16CF0C8", Length = "0x94")]
		protected GraphicRaycaster()
		{
		}

		[Token(Token = "0x600012A")]
		[Address(RVA = "0x16CF15C", Offset = "0x16CF15C", Length = "0xC18")]
		public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
		{
		}

		[Token(Token = "0x600012C")]
		[Address(RVA = "0x16CFE30", Offset = "0x16CFE30", Length = "0x568")]
		private static void Raycast(Canvas canvas, Camera eventCamera, Vector2 pointerPosition, IList<Graphic> foundGraphics, List<Graphic> results)
		{
		}
	}
}
