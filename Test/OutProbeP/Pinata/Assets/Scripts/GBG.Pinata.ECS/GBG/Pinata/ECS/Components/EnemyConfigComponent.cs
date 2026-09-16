using System;
using Cpp2ILInjected;
using Morpeh;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GBG.Pinata.ECS.Components
{
	[Serializable]
	[Token(Token = "0x200007F")]
	public struct EnemyConfigComponent : IComponent
	{
		[Token(Token = "0x4000155")]
		[FieldOffset(Offset = "0x0")]
		public EnemyConfig config;

		[Required]
		[Token(Token = "0x4000156")]
		[FieldOffset(Offset = "0x18")]
		public Transform spawn;
	}
}
