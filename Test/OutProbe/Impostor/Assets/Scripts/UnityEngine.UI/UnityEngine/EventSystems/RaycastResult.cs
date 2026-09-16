using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x20000C8")]
	public struct RaycastResult
	{
		[Token(Token = "0x400034F")]
		[FieldOffset(Offset = "0x0")]
		private GameObject m_GameObject;

		[Token(Token = "0x4000350")]
		[FieldOffset(Offset = "0x8")]
		public BaseRaycaster module;

		[Token(Token = "0x4000351")]
		[FieldOffset(Offset = "0x10")]
		public float distance;

		[Token(Token = "0x4000352")]
		[FieldOffset(Offset = "0x14")]
		public float index;

		[Token(Token = "0x4000353")]
		[FieldOffset(Offset = "0x18")]
		public int depth;

		[Token(Token = "0x4000354")]
		[FieldOffset(Offset = "0x1C")]
		public int sortingGroupID;

		[Token(Token = "0x4000355")]
		[FieldOffset(Offset = "0x20")]
		public int sortingGroupOrder;

		[Token(Token = "0x4000356")]
		[FieldOffset(Offset = "0x24")]
		public int sortingLayer;

		[Token(Token = "0x4000357")]
		[FieldOffset(Offset = "0x28")]
		public int sortingOrder;

		[Token(Token = "0x4000358")]
		[FieldOffset(Offset = "0x2C")]
		public Vector3 worldPosition;

		[Token(Token = "0x4000359")]
		[FieldOffset(Offset = "0x38")]
		public Vector3 worldNormal;

		[Token(Token = "0x400035A")]
		[FieldOffset(Offset = "0x44")]
		public Vector2 screenPosition;

		[Token(Token = "0x400035B")]
		[FieldOffset(Offset = "0x4C")]
		public int displayIndex;

		[Token(Token = "0x170001F8")]
		public GameObject gameObject
		{
			[Token(Token = "0x600075A")]
			[Address(RVA = "0x184E5D4", Offset = "0x184E5D4", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600075B")]
			[Address(RVA = "0x184E5DC", Offset = "0x184E5DC", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170001F9")]
		public bool isValid
		{
			[Token(Token = "0x600075C")]
			[Address(RVA = "0x184E5E4", Offset = "0x184E5E4", Length = "0x98")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x600075D")]
		[Address(RVA = "0x184E67C", Offset = "0x184E67C", Length = "0xA8")]
		public void Clear()
		{
		}

		[Token(Token = "0x600075E")]
		[Address(RVA = "0x1843500", Offset = "0x1843500", Length = "0x430")]
		public override string ToString()
		{
			return null;
		}
	}
}
