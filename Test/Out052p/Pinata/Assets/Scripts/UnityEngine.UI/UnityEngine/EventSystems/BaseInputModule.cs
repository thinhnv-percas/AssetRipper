using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x727D60", Offset = "0x727D60")]
	[Token(Token = "0x2000067")]
	public abstract class BaseInputModule : UIBehaviour
	{
		[NonSerialized]
		[Token(Token = "0x40001E3")]
		[FieldOffset(Offset = "0x18")]
		protected List<RaycastResult> m_RaycastResultCache;

		[Token(Token = "0x40001E4")]
		[FieldOffset(Offset = "0x20")]
		private AxisEventData m_AxisEventData;

		[Token(Token = "0x40001E5")]
		[FieldOffset(Offset = "0x28")]
		private EventSystem m_EventSystem;

		[Token(Token = "0x40001E6")]
		[FieldOffset(Offset = "0x30")]
		private BaseEventData m_BaseEventData;

		[Token(Token = "0x40001E7")]
		[FieldOffset(Offset = "0x38")]
		protected BaseInput m_InputOverride;

		[Token(Token = "0x40001E8")]
		[FieldOffset(Offset = "0x40")]
		private BaseInput m_DefaultInput;

		[Token(Token = "0x1700018F")]
		public BaseInput input
		{
			[Token(Token = "0x600058D")]
			[Address(RVA = "0xC410A4", Offset = "0xC410A4", Length = "0x224")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000190")]
		public BaseInput inputOverride
		{
			[Token(Token = "0x600058E")]
			[Address(RVA = "0xC412C8", Offset = "0xC412C8", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600058F")]
			[Address(RVA = "0xC412D0", Offset = "0xC412D0", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000191")]
		protected EventSystem eventSystem
		{
			[Token(Token = "0x6000590")]
			[Address(RVA = "0xC412D8", Offset = "0xC412D8", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000591")]
		[Address(RVA = "0xC412E0", Offset = "0xC412E0", Length = "0x60")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x6000592")]
		[Address(RVA = "0xC41494", Offset = "0xC41494", Length = "0x18")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x6000593")]
		public abstract void Process();

		[Token(Token = "0x6000594")]
		[Address(RVA = "0xC414B0", Offset = "0xC414B0", Length = "0x130")]
		protected static RaycastResult FindFirstRaycast(List<RaycastResult> candidates)
		{
			return default(RaycastResult);
		}

		[Token(Token = "0x6000595")]
		[Address(RVA = "0xC415E0", Offset = "0xC415E0", Length = "0xC")]
		protected static MoveDirection DetermineMoveDirection(float x, float y)
		{
			return MoveDirection.Left;
		}

		[Token(Token = "0x6000596")]
		[Address(RVA = "0xC415EC", Offset = "0xC415EC", Length = "0xEC")]
		protected static MoveDirection DetermineMoveDirection(float x, float y, float deadZone)
		{
			return MoveDirection.Left;
		}

		[Token(Token = "0x6000597")]
		[Address(RVA = "0xC416D8", Offset = "0xC416D8", Length = "0x1AC")]
		protected static GameObject FindCommonRoot(GameObject g1, GameObject g2)
		{
			return null;
		}

		[Token(Token = "0x6000598")]
		[Address(RVA = "0xC41884", Offset = "0xC41884", Length = "0x5AC")]
		protected void HandlePointerExitAndEnter(PointerEventData currentPointerData, GameObject newEnterTarget)
		{
		}

		[Token(Token = "0x6000599")]
		[Address(RVA = "0xC41E30", Offset = "0xC41E30", Length = "0xFC")]
		protected virtual AxisEventData GetAxisEventData(float x, float y, float moveDeadZone)
		{
			return null;
		}

		[Token(Token = "0x600059A")]
		[Address(RVA = "0xC41F2C", Offset = "0xC41F2C", Length = "0x98")]
		protected virtual BaseEventData GetBaseEventData()
		{
			return null;
		}

		[Token(Token = "0x600059B")]
		[Address(RVA = "0xC41FC4", Offset = "0xC41FC4", Length = "0x8")]
		public virtual bool IsPointerOverGameObject(int pointerId)
		{
			return false;
		}

		[Token(Token = "0x600059C")]
		[Address(RVA = "0xC41FCC", Offset = "0xC41FCC", Length = "0x50")]
		public virtual bool ShouldActivateModule()
		{
			return false;
		}

		[Token(Token = "0x600059D")]
		[Address(RVA = "0xC4201C", Offset = "0xC4201C", Length = "0x4")]
		public virtual void DeactivateModule()
		{
		}

		[Token(Token = "0x600059E")]
		[Address(RVA = "0xC42020", Offset = "0xC42020", Length = "0x4")]
		public virtual void ActivateModule()
		{
		}

		[Token(Token = "0x600059F")]
		[Address(RVA = "0xC42024", Offset = "0xC42024", Length = "0x4")]
		public virtual void UpdateModule()
		{
		}

		[Token(Token = "0x60005A0")]
		[Address(RVA = "0xC42028", Offset = "0xC42028", Length = "0x8")]
		public virtual bool IsModuleSupported()
		{
			return false;
		}

		[Token(Token = "0x60005A1")]
		[Address(RVA = "0xC42030", Offset = "0xC42030", Length = "0x70")]
		protected internal BaseInputModule()
		{
		}
	}
}
