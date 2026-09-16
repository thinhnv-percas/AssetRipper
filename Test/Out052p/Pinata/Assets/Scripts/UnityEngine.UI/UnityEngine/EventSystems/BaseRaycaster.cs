using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x200006D")]
	public abstract class BaseRaycaster : UIBehaviour
	{
		[Token(Token = "0x4000208")]
		[FieldOffset(Offset = "0x18")]
		private BaseRaycaster m_RootRaycaster;

		[Token(Token = "0x1700019D")]
		public abstract Camera eventCamera
		{
			[Token(Token = "0x60005EB")]
			get;
		}

		[Obsolete]
		[Token(Token = "0x1700019E")]
		public virtual int priority
		{
			[Token(Token = "0x60005EC")]
			[Address(RVA = "0xC420A0", Offset = "0xC420A0", Length = "0x8")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x1700019F")]
		public virtual int sortOrderPriority
		{
			[Token(Token = "0x60005ED")]
			[Address(RVA = "0xC420A8", Offset = "0xC420A8", Length = "0x8")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x170001A0")]
		public virtual int renderOrderPriority
		{
			[Token(Token = "0x60005EE")]
			[Address(RVA = "0xC420B0", Offset = "0xC420B0", Length = "0x8")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x170001A1")]
		public BaseRaycaster rootRaycaster
		{
			[Token(Token = "0x60005EF")]
			[Address(RVA = "0xC420B8", Offset = "0xC420B8", Length = "0xC8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x60005EA")]
		public abstract void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList);

		[Token(Token = "0x60005F0")]
		[Address(RVA = "0xC42180", Offset = "0xC42180", Length = "0x288")]
		public override string ToString()
		{
			return null;
		}

		[Token(Token = "0x60005F1")]
		[Address(RVA = "0xC42408", Offset = "0xC42408", Length = "0x64")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x60005F2")]
		[Address(RVA = "0xC4253C", Offset = "0xC4253C", Length = "0x64")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x60005F3")]
		[Address(RVA = "0xC42670", Offset = "0xC42670", Length = "0x8")]
		protected override void OnCanvasHierarchyChanged()
		{
		}

		[Token(Token = "0x60005F4")]
		[Address(RVA = "0xC4267C", Offset = "0xC4267C", Length = "0x8")]
		protected override void OnTransformParentChanged()
		{
		}

		[Token(Token = "0x60005F5")]
		[Address(RVA = "0xC42688", Offset = "0xC42688", Length = "0x8")]
		protected internal BaseRaycaster()
		{
		}
	}
}
