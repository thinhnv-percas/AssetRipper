using System;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.AppLayerInstaller
{
	[Serializable]
	[Token(Token = "0x20006F8")]
	public struct RateUsConfig
	{
		[SerializeField]
		[Token(Token = "0x400175E")]
		[FieldOffset(Offset = "0x0")]
		private ShowLocation m_location;

		[SerializeField]
		[Token(Token = "0x400175F")]
		[FieldOffset(Offset = "0x4")]
		private int m_level;

		[Token(Token = "0x170002E0")]
		public ShowLocation Location
		{
			[Token(Token = "0x6001D6D")]
			[Address(RVA = "0x3D78404", Offset = "0x3D78404", Length = "0x8")]
			get
			{
				return m_location;
			}
		}

		[Token(Token = "0x170002E1")]
		public int Level
		{
			[Token(Token = "0x6001D6E")]
			[Address(RVA = "0x3D7840C", Offset = "0x3D7840C", Length = "0x8")]
			get
			{
				return m_level;
			}
		}
	}
}
