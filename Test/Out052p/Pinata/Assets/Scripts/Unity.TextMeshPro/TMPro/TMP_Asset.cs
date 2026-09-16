using System;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x200000C")]
	public class TMP_Asset : ScriptableObject
	{
		[Token(Token = "0x4000051")]
		[FieldOffset(Offset = "0x18")]
		public int hashCode;

		[Token(Token = "0x4000052")]
		[FieldOffset(Offset = "0x20")]
		public Material material;

		[Token(Token = "0x4000053")]
		[FieldOffset(Offset = "0x28")]
		public int materialHashCode;

		[Token(Token = "0x60000DE")]
		[Address(RVA = "0x91C1E0", Offset = "0x91C1E0", Length = "0x8")]
		public TMP_Asset()
		{
		}
	}
}
