using System;
using Cpp2ILInjected;
using Morpeh;
using TMPro;
using UnityEngine;

namespace GBG.Pinata.ECS.UI.Components
{
	[Serializable]
	[Token(Token = "0x2000045")]
	public struct MetaUpgradeButtonComponent : IComponent
	{
		[Token(Token = "0x40000CC")]
		[FieldOffset(Offset = "0x0")]
		public GameObject Button;

		[Token(Token = "0x40000CD")]
		[FieldOffset(Offset = "0x8")]
		public TextMeshProUGUI BoostValue;

		[Token(Token = "0x40000CE")]
		[FieldOffset(Offset = "0x10")]
		public TextMeshProUGUI CostValue;

		[Token(Token = "0x40000CF")]
		[FieldOffset(Offset = "0x18")]
		public string MetaTypeKey;
	}
}
