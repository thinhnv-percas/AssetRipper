using System;
using Cpp2ILInjected;
using GBG.Pinata.ECS.Schemes;
using Morpeh;
using UnityEngine;

namespace GBG.Pinata.ECS.Components
{
	[Serializable]
	[Token(Token = "0x2000086")]
	public struct WeaponsConfigComponent : IComponent
	{
		[Token(Token = "0x4000172")]
		[FieldOffset(Offset = "0x0")]
		public SpawnConfig[] hands;

		[Token(Token = "0x4000173")]
		[FieldOffset(Offset = "0x8")]
		public Transform ControllerFPS;

		[Token(Token = "0x4000174")]
		[FieldOffset(Offset = "0x10")]
		public Vector3 boxColliderSize;
	}
}
