using System;
using Cpp2ILInjected;
using Unco.ResourceSystem;

namespace _game.CoreGameKit.Ui.Animations
{
	[Serializable]
	[Token(Token = "0x2000568")]
	public struct ResourceParticleEntry
	{
		[Token(Token = "0x4001280")]
		[FieldOffset(Offset = "0x0")]
		public ResourceType m_resourceType;

		[Token(Token = "0x4001281")]
		[FieldOffset(Offset = "0x8")]
		public CurrencyParticle m_particlePrefab;
	}
}
