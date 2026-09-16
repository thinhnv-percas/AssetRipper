using System;
using Cpp2ILInjected;
using Morpeh;
using Morpeh.Globals;
using UnityEngine;
using UnityEngine.UI;

namespace GBG.Pinata.ECS.InAppPurchase.Components
{
	[Serializable]
	[Token(Token = "0x200005D")]
	public struct OpenURLComponent : IComponent
	{
		[HideInInspector]
		[Token(Token = "0x40000FF")]
		[FieldOffset(Offset = "0x0")]
		public GlobalEvent OnClick;

		[Token(Token = "0x4000100")]
		[FieldOffset(Offset = "0x8")]
		public string URL;

		[Token(Token = "0x4000101")]
		[FieldOffset(Offset = "0x10")]
		public Button Button;
	}
}
