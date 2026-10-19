using System;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.BaseLayer.Services
{
	[Serializable]
	[Token(Token = "0x200065B")]
	public class KeepPlayingConfig
	{
		[SerializeField]
		[Token(Token = "0x40015D0")]
		[FieldOffset(Offset = "0x10")]
		private int[] m_costTiers;

		[Token(Token = "0x17000293")]
		public int[] CostTiers
		{
			[Token(Token = "0x6001AEA")]
			[Address(RVA = "0x3D57900", Offset = "0x3D57900", Length = "0x8")]
			get
			{
				return m_costTiers;
			}
		}

		[Token(Token = "0x6001AEB")]
		[Address(RVA = "0x3D57908", Offset = "0x3D57908", Length = "0x8")]
		public KeepPlayingConfig()
		{
		}
	}
}
