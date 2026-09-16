using System;
using Cpp2ILInjected;
using UnityEngine;

namespace GBG.Pinata.ECS.Schemes
{
	[Serializable]
	[Token(Token = "0x2000074")]
	public struct SpawnConfig
	{
		[Token(Token = "0x400014D")]
		[FieldOffset(Offset = "0x0")]
		public bool enabled;

		[Token(Token = "0x400014E")]
		[FieldOffset(Offset = "0x8")]
		public Transform parent;
	}
}
