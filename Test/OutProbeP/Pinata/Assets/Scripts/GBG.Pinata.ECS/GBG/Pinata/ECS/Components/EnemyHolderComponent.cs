using System;
using Cpp2ILInjected;
using Morpeh;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GBG.Pinata.ECS.Components
{
	[Serializable]
	[Token(Token = "0x2000080")]
	public struct EnemyHolderComponent : IComponent
	{
		[Required]
		[Token(Token = "0x4000157")]
		[FieldOffset(Offset = "0x0")]
		public Transform Parent;

		[Token(Token = "0x4000158")]
		[FieldOffset(Offset = "0x8")]
		public float Speed;

		[Token(Token = "0x4000159")]
		[FieldOffset(Offset = "0xC")]
		public float UpPosition;

		[Token(Token = "0x400015A")]
		[FieldOffset(Offset = "0x10")]
		public float BottomPosition;
	}
}
