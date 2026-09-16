using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[RequireComponent(typeof(EventSystem))]
	[Token(Token = "0x20000BA")]
	public abstract class BaseInputModule : UIBehaviour
	{
		[NonSerialized]
		[Token(Token = "0x4000317")]
		[FieldOffset(Offset = "0x20")]
		protected List<RaycastResult> m_RaycastResultCache;

		[SerializeField]
		[Token(Token = "0x4000318")]
		[FieldOffset(Offset = "0x28")]
		private bool m_SendPointerHoverToParent;

		[Token(Token = "0x4000319")]
		[FieldOffset(Offset = "0x30")]
		private AxisEventData m_AxisEventData;

		[Token(Token = "0x400031A")]
		[FieldOffset(Offset = "0x38")]
		private EventSystem m_EventSystem;

		[Token(Token = "0x400031B")]
		[FieldOffset(Offset = "0x40")]
		private BaseEventData m_BaseEventData;

		[Token(Token = "0x400031C")]
		[FieldOffset(Offset = "0x48")]
		protected BaseInput m_InputOverride;

		[Token(Token = "0x400031D")]
		[FieldOffset(Offset = "0x50")]
		private BaseInput m_DefaultInput;

		[Token(Token = "0x170001DD")]
		internal bool sendPointerHoverToParent
		{
			[Token(Token = "0x60006D3")]
			[Address(RVA = "0x18478E4", Offset = "0x18478E4", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60006D4")]
			[Address(RVA = "0x18478EC", Offset = "0x18478EC", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x170001DE")]
		public BaseInput input
		{
			[Token(Token = "0x60006D5")]
			[Address(RVA = "0x18478F8", Offset = "0x18478F8", Length = "0x218")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170001DF")]
		public BaseInput inputOverride
		{
			[Token(Token = "0x60006D6")]
			[Address(RVA = "0x1847B10", Offset = "0x1847B10", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60006D7")]
			[Address(RVA = "0x1847B18", Offset = "0x1847B18", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170001E0")]
		protected EventSystem eventSystem
		{
			[Token(Token = "0x60006D8")]
			[Address(RVA = "0x1847B20", Offset = "0x1847B20", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x60006D9")]
		[Address(RVA = "0x1847B28", Offset = "0x1847B28", Length = "0x58")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x60006DA")]
		[Address(RVA = "0x1847B80", Offset = "0x1847B80", Length = "0x18")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x60006DB")]
		public abstract void Process();

		[Token(Token = "0x60006DC")]
		[Address(RVA = "0x1847B98", Offset = "0x1847B98", Length = "0x114")]
		protected static RaycastResult FindFirstRaycast(List<RaycastResult> candidates)
		{
			return default(RaycastResult);
		}

		[Token(Token = "0x60006DD")]
		[Address(RVA = "0x1847CAC", Offset = "0x1847CAC", Length = "0x54")]
		protected static MoveDirection DetermineMoveDirection(float x, float y)
		{
			return MoveDirection.Left;
		}

		[Token(Token = "0x60006DE")]
		[Address(RVA = "0x1847D00", Offset = "0x1847D00", Length = "0x50")]
		protected static MoveDirection DetermineMoveDirection(float x, float y, float deadZone)
		{
			return MoveDirection.Left;
		}

		[Token(Token = "0x60006DF")]
		[Address(RVA = "0x1847D50", Offset = "0x1847D50", Length = "0x174")]
		protected static GameObject FindCommonRoot(GameObject g1, GameObject g2)
		{
			return null;
		}

		[Token(Token = "0x60006E0")]
		[Address(RVA = "0x1847EC4", Offset = "0x1847EC4", Length = "0xA84")]
		protected void HandlePointerExitAndEnter(PointerEventData currentPointerData, GameObject newEnterTarget)
		{
		}

		[Token(Token = "0x60006E1")]
		[Address(RVA = "0x1848948", Offset = "0x1848948", Length = "0x100")]
		protected virtual AxisEventData GetAxisEventData(float x, float y, float moveDeadZone)
		{
			return null;
		}

		[Token(Token = "0x60006E2")]
		[Address(RVA = "0x1848A48", Offset = "0x1848A48", Length = "0x7C")]
		protected virtual BaseEventData GetBaseEventData()
		{
			return null;
		}

		[Token(Token = "0x60006E3")]
		[Address(RVA = "0x1848AC4", Offset = "0x1848AC4", Length = "0x8")]
		public virtual bool IsPointerOverGameObject(int pointerId)
		{
			return false;
		}

		[Token(Token = "0x60006E4")]
		[Address(RVA = "0x1848ACC", Offset = "0x1848ACC", Length = "0x40")]
		public virtual bool ShouldActivateModule()
		{
			return false;
		}

		[Token(Token = "0x60006E5")]
		[Address(RVA = "0x1848B0C", Offset = "0x1848B0C", Length = "0x4")]
		public virtual void DeactivateModule()
		{
		}

		[Token(Token = "0x60006E6")]
		[Address(RVA = "0x1848B10", Offset = "0x1848B10", Length = "0x4")]
		public virtual void ActivateModule()
		{
		}

		[Token(Token = "0x60006E7")]
		[Address(RVA = "0x1848B14", Offset = "0x1848B14", Length = "0x4")]
		public virtual void UpdateModule()
		{
		}

		[Token(Token = "0x60006E8")]
		[Address(RVA = "0x1848B18", Offset = "0x1848B18", Length = "0x8")]
		public virtual bool IsModuleSupported()
		{
			return false;
		}

		[Token(Token = "0x60006E9")]
		[Address(RVA = "0x1848B20", Offset = "0x1848B20", Length = "0x7C")]
		public virtual int ConvertUIToolkitPointerId(PointerEventData sourcePointerData)
		{
			return 0;
		}

		[Token(Token = "0x60006EA")]
		[Address(RVA = "0x1848B9C", Offset = "0x1848B9C", Length = "0x84")]
		protected internal BaseInputModule()
		{
		}
	}
}
