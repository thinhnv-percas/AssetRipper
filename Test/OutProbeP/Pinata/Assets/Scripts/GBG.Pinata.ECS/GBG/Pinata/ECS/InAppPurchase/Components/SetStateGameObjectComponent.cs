using System;
using Cpp2ILInjected;
using Morpeh;
using Morpeh.Globals;
using UnityEngine;
using UnityEngine.UI;

namespace GBG.Pinata.ECS.InAppPurchase.Components
{
	[Serializable]
	[Token(Token = "0x200005E")]
	public struct SetStateGameObjectComponent : IComponent
	{
		[HideInInspector]
		[Token(Token = "0x4000102")]
		[FieldOffset(Offset = "0x0")]
		public GlobalEvent OnClick;

		[Token(Token = "0x4000103")]
		[FieldOffset(Offset = "0x8")]
		public Button button;

		[Token(Token = "0x4000104")]
		[FieldOffset(Offset = "0x10")]
		public GameObject gameObject;

		[Token(Token = "0x4000105")]
		[FieldOffset(Offset = "0x18")]
		public bool state;
	}
}
