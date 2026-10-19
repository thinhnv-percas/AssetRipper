using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.Controllers.LevelSystem.Serializable;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;

namespace _game.CoreGameKit.BaseLayer.LevelSystem
{
	[Token(Token = "0x2000670")]
	public class LevelListSo : CompressedRemote
	{
		[SerializeField]
		[HideInInspector]
		[Token(Token = "0x4001608")]
		[FieldOffset(Offset = "0x18")]
		internal LevelSoBase[] m_levels;

		[SerializeField]
		[Token(Token = "0x4001609")]
		[FieldOffset(Offset = "0x20")]
		internal LevelOrderConfig m_levelOrderConfig;

		[Token(Token = "0x1700029C")]
		public IReadOnlyList<ILevel> Levels
		{
			[Token(Token = "0x6001B3A")]
			[Address(RVA = "0x3D5CC60", Offset = "0x3D5CC60", Length = "0x8")]
			get
			{
				return m_levels;
			}
		}

		[Token(Token = "0x1700029D")]
		public LevelOrderConfig LevelOrderConfig
		{
			[Token(Token = "0x6001B3B")]
			[Address(RVA = "0x3D5CC68", Offset = "0x3D5CC68", Length = "0x3C")]
			get
			{
				if (m_levelOrderConfig != null)
				{
					m_levelOrderConfig.Resolve(m_levels);
					return m_levelOrderConfig;
				}
				return null;
			}
		}

		[Token(Token = "0x6001B3C")]
		[Address(RVA = "0x3D5CCA4", Offset = "0x3D5CCA4", Length = "0x8")]
		public LevelSoBase[] Internal_GetLevels()
		{
			return m_levels;
		}

		[Token(Token = "0x6001B3D")]
		[Address(RVA = "0x3D5CCAC", Offset = "0x3D5CCAC", Length = "0x8")]
		public LevelListSo()
		{
		}
	}
}
