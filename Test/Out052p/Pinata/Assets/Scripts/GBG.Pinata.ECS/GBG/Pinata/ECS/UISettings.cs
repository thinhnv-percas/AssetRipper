using System;
using System.Runtime.InteropServices;
using Cpp2ILInjected;
using UnityEngine;

namespace GBG.Pinata.ECS
{
	[Serializable]
	[StructLayout((LayoutKind)0, Size = 8)]
	[Token(Token = "0x200002E")]
	public struct UISettings
	{
		[AttributeAttribute(Type = typeof(HeaderAttribute), RVA = "0x74AE9C", Offset = "0x74AE9C")]
		[Token(Token = "0x40000AD")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public float MinimumOpacity;

		[Token(Token = "0x40000AE")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		public float MaximumOpacity;
	}
}
