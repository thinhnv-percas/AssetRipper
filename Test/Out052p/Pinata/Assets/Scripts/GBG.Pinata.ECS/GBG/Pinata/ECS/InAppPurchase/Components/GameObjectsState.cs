using System;
using Cpp2ILInjected;
using UnityEngine;

namespace GBG.Pinata.ECS.InAppPurchase.Components
{
	[Serializable]
	[Token(Token = "0x2000060")]
	public struct GameObjectsState
	{
		[Token(Token = "0x4000109")]
		[FieldOffset(Offset = "0x0")]
		public GameObject gameObject;

		[Token(Token = "0x400010A")]
		[FieldOffset(Offset = "0x8")]
		public bool state;
	}
}
