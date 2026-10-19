using System;
using Cpp2ILInjected;

namespace _game.CoreGameKit.Ui.Animations
{
	[Serializable]
	[Token(Token = "0x2000569")]
	public struct StringParticleEntry
	{
		[Token(Token = "0x4001282")]
		[FieldOffset(Offset = "0x0")]
		public string m_key;

		[Token(Token = "0x4001283")]
		[FieldOffset(Offset = "0x8")]
		public CurrencyParticle m_particlePrefab;
	}
}
