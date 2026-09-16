using System;
using Cpp2ILInjected;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GBG.Pinata.ECS.Components
{
	[Serializable]
	[Token(Token = "0x2000087")]
	public struct EnemyConfig
	{
		[Required]
		[Token(Token = "0x4000175")]
		[FieldOffset(Offset = "0x0")]
		public Rigidbody RigidbodyParent;

		[Token(Token = "0x4000176")]
		[FieldOffset(Offset = "0x8")]
		public ParticleSystem candyFall;

		[Token(Token = "0x4000177")]
		[FieldOffset(Offset = "0x10")]
		public ParticleSystem starSplash;
	}
}
