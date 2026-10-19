using System;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.Ui.Animations
{
	[Serializable]
	[Token(Token = "0x200056A")]
	public struct GenericParticleConfig
	{
		[Token(Token = "0x4001284")]
		[FieldOffset(Offset = "0x0")]
		public string m_id;

		[Token(Token = "0x4001285")]
		[FieldOffset(Offset = "0x8")]
		public Color m_color;

		[Token(Token = "0x4001286")]
		[FieldOffset(Offset = "0x18")]
		public Sprite m_sprite;
	}
}
