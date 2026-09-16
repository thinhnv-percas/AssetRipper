using System;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x2000022")]
	public abstract class TMP_Asset : ScriptableObject
	{
		[Token(Token = "0x4000112")]
		[FieldOffset(Offset = "0x18")]
		private int m_InstanceID;

		[Token(Token = "0x4000113")]
		[FieldOffset(Offset = "0x1C")]
		public int hashCode;

		[Token(Token = "0x4000114")]
		[FieldOffset(Offset = "0x20")]
		public Material material;

		[Token(Token = "0x4000115")]
		[FieldOffset(Offset = "0x28")]
		public int materialHashCode;

		[Token(Token = "0x17000023")]
		public int instanceID
		{
			[Token(Token = "0x600011F")]
			[Address(RVA = "0x15CFEDC", Offset = "0x15CFEDC", Length = "0x28")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x6000120")]
		[Address(RVA = "0x15CFF04", Offset = "0x15CFF04", Length = "0x8")]
		protected internal TMP_Asset()
		{
		}
	}
}
