using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x2000070")]
	public struct RaycastResult
	{
		[Token(Token = "0x4000210")]
		[FieldOffset(Offset = "0x0")]
		private GameObject m_GameObject;

		[Token(Token = "0x4000211")]
		[FieldOffset(Offset = "0x8")]
		public BaseRaycaster module;

		[Token(Token = "0x4000212")]
		[FieldOffset(Offset = "0x10")]
		public float distance;

		[Token(Token = "0x4000213")]
		[FieldOffset(Offset = "0x14")]
		public float index;

		[Token(Token = "0x4000214")]
		[FieldOffset(Offset = "0x18")]
		public int depth;

		[Token(Token = "0x4000215")]
		[FieldOffset(Offset = "0x1C")]
		public int sortingLayer;

		[Token(Token = "0x4000216")]
		[FieldOffset(Offset = "0x20")]
		public int sortingOrder;

		[Token(Token = "0x4000217")]
		[FieldOffset(Offset = "0x24")]
		public Vector3 worldPosition;

		[Token(Token = "0x4000218")]
		[FieldOffset(Offset = "0x30")]
		public Vector3 worldNormal;

		[Token(Token = "0x4000219")]
		[FieldOffset(Offset = "0x3C")]
		public Vector2 screenPosition;

		[Token(Token = "0x170001A7")]
		public GameObject gameObject
		{
			[Token(Token = "0x6000602")]
			[Address(RVA = "0x84BFCC", Offset = "0x84BFCC", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000603")]
			[Address(RVA = "0x84BFD4", Offset = "0x84BFD4", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170001A8")]
		public bool isValid
		{
			[Token(Token = "0x6000604")]
			[Address(RVA = "0x84BFDC", Offset = "0x84BFDC", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x6000605")]
		[Address(RVA = "0x84BFE4", Offset = "0x84BFE4", Length = "0x8")]
		public void Clear()
		{
		}

		[Token(Token = "0x6000606")]
		[Address(RVA = "0x84BFEC", Offset = "0x84BFEC", Length = "0x8")]
		public override string ToString()
		{
			return null;
		}
	}
}
