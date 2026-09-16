using System;
using Cpp2ILInjected;
using Morpeh;
using UnityEngine;

namespace GBG.Pinata.ECS.Components
{
	[Serializable]
	[Token(Token = "0x2000081")]
	public struct EnemyPartsComponent : IComponent
	{
		[Token(Token = "0x400015B")]
		[FieldOffset(Offset = "0x0")]
		public Transform[] Parts;
	}
}
