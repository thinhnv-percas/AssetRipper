using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x20000C4")]
	public abstract class BaseRaycaster : UIBehaviour
	{
		[Token(Token = "0x4000346")]
		[FieldOffset(Offset = "0x20")]
		private BaseRaycaster m_RootRaycaster;

		[Token(Token = "0x170001EE")]
		public abstract Camera eventCamera
		{
			[Token(Token = "0x6000740")]
			get;
		}

		[Obsolete("Please use sortOrderPriority and renderOrderPriority", false)]
		[Token(Token = "0x170001EF")]
		public virtual int priority
		{
			[Token(Token = "0x6000741")]
			[Address(RVA = "0x184D1DC", Offset = "0x184D1DC", Length = "0x8")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x170001F0")]
		public virtual int sortOrderPriority
		{
			[Token(Token = "0x6000742")]
			[Address(RVA = "0x184D1E4", Offset = "0x184D1E4", Length = "0x8")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x170001F1")]
		public virtual int renderOrderPriority
		{
			[Token(Token = "0x6000743")]
			[Address(RVA = "0x184D1EC", Offset = "0x184D1EC", Length = "0x8")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x170001F2")]
		public BaseRaycaster rootRaycaster
		{
			[Token(Token = "0x6000744")]
			[Address(RVA = "0x18441D4", Offset = "0x18441D4", Length = "0xB8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x600073F")]
		public abstract void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList);

		[Token(Token = "0x6000745")]
		[Address(RVA = "0x184D1F4", Offset = "0x184D1F4", Length = "0x1C8")]
		public override string ToString()
		{
			return null;
		}

		[Token(Token = "0x6000746")]
		[Address(RVA = "0x184D3BC", Offset = "0x184D3BC", Length = "0x54")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x6000747")]
		[Address(RVA = "0x184D410", Offset = "0x184D410", Length = "0x54")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x6000748")]
		[Address(RVA = "0x184D464", Offset = "0x184D464", Length = "0x8")]
		protected override void OnCanvasHierarchyChanged()
		{
		}

		[Token(Token = "0x6000749")]
		[Address(RVA = "0x184D470", Offset = "0x184D470", Length = "0x8")]
		protected override void OnTransformParentChanged()
		{
		}

		[Token(Token = "0x600074A")]
		[Address(RVA = "0x18424C8", Offset = "0x18424C8", Length = "0x8")]
		protected internal BaseRaycaster()
		{
		}
	}
}
