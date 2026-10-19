using System;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.BaseLayer.LevelSystem
{
	[Serializable]
	[Token(Token = "0x200066E")]
	public struct LevelOrderEntry
	{
		[Token(Token = "0x4001604")]
		[FieldOffset(Offset = "0x0")]
		public LevelSoBase Level;

		[HideInInspector]
		[Token(Token = "0x4001605")]
		[FieldOffset(Offset = "0x8")]
		public string UniqueId;

		[HideInInspector]
		[Token(Token = "0x4001606")]
		[FieldOffset(Offset = "0x10")]
		public string LevelName;

		[Token(Token = "0x6001B38")]
		[Address(RVA = "0x3D5BD1C", Offset = "0x3D5BD1C", Length = "0xDC")]
		public string GetUniqueIdForResolve()
		{
			if (Level != null)
			{
				LevelSoBase level = Level;
				if (!string.IsNullOrEmpty(level.UniqueId))
				{
					LevelSoBase level2 = Level;
					return level2.UniqueId;
				}
			}
			return UniqueId;
		}

		[Token(Token = "0x6001B39")]
		[Address(RVA = "0x3D5BDF8", Offset = "0x3D5BDF8", Length = "0xDC")]
		public string GetLevelNameForResolve()
		{
			if (Level != null)
			{
				string name = Level.name;
				if (!string.IsNullOrEmpty(name))
				{
					return Level.name;
				}
			}
			return LevelName;
		}
	}
}
