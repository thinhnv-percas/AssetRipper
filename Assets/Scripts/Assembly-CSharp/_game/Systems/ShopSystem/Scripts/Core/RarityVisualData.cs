using System;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.Systems.ShopSystem.Scripts.Core
{
	[Serializable]
	[Token(Token = "0x2000730")]
	public class RarityVisualData
	{
		[Token(Token = "0x400180A")]
		[FieldOffset(Offset = "0x10")]
		public Sprite Frame;

		[Token(Token = "0x6001E4D")]
		[Address(RVA = "0x3D83694", Offset = "0x3D83694", Length = "0x8")]
		public RarityVisualData()
		{
		}
	}
}
