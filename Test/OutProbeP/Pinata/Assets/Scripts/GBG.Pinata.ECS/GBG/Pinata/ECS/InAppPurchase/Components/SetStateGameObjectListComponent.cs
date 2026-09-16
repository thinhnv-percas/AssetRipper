using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Morpeh;
using Morpeh.Globals;
using UnityEngine;
using UnityEngine.UI;

namespace GBG.Pinata.ECS.InAppPurchase.Components
{
	[Serializable]
	[Token(Token = "0x200005F")]
	public struct SetStateGameObjectListComponent : IComponent
	{
		[HideInInspector]
		[Token(Token = "0x4000106")]
		[FieldOffset(Offset = "0x0")]
		public GlobalEvent OnClick;

		[Token(Token = "0x4000107")]
		[FieldOffset(Offset = "0x8")]
		public Button button;

		[Token(Token = "0x4000108")]
		[FieldOffset(Offset = "0x10")]
		public List<GameObjectsState> GameObjectsStates;
	}
}
