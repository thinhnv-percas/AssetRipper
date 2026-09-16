using Cpp2ILInjected;
using Morpeh;
using UnityEngine;

namespace GBG.Pinata.ECS.Components
{
	[Token(Token = "0x200007E")]
	public struct EnemyComponent : IComponent
	{
		[Token(Token = "0x4000152")]
		[FieldOffset(Offset = "0x0")]
		public GameObject go;

		[Token(Token = "0x4000153")]
		[FieldOffset(Offset = "0x8")]
		public Transform spawn;

		[Token(Token = "0x4000154")]
		[FieldOffset(Offset = "0x10")]
		public EnemyConfig config;
	}
}
