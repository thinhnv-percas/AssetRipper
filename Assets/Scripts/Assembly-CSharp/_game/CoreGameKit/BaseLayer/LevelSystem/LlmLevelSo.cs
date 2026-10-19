using Cpp2ILInjected;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;

namespace _game.CoreGameKit.BaseLayer.LevelSystem
{
	[Token(Token = "0x2000678")]
	public class LlmLevelSo : LevelSo
	{
		[SerializeField]
		[Token(Token = "0x400162D")]
		[FieldOffset(Offset = "0x50")]
		private string m_reportHtmlPath;

		[SerializeField]
		[Token(Token = "0x400162E")]
		[FieldOffset(Offset = "0x58")]
		private IntendedStep[] m_intendedPath;

		[Token(Token = "0x170002BD")]
		public string ReportHtmlPath
		{
			[Token(Token = "0x6001B6F")]
			[Address(RVA = "0x3D5DEBC", Offset = "0x3D5DEBC", Length = "0x8")]
			get
			{
				return m_reportHtmlPath;
			}
		}

		[Token(Token = "0x170002BE")]
		public bool HasIntendedPath
		{
			[Token(Token = "0x6001B70")]
			[Address(RVA = "0x3D5DEC4", Offset = "0x3D5DEC4", Length = "0x20")]
			get
			{
				IntendedStep[] intendedPath = IntendedPath;
				if (IntendedPath != null)
				{
					bool flag = intendedPath.Length == 0;
					return !flag;
				}
				return false;
			}
		}

		[Token(Token = "0x170002BF")]
		public IntendedStep[] IntendedPath
		{
			[Token(Token = "0x6001B71")]
			[Address(RVA = "0x3D5DEE4", Offset = "0x3D5DEE4", Length = "0x8")]
			get
			{
				return m_intendedPath;
			}
		}

		[Token(Token = "0x6001B72")]
		[Address(RVA = "0x3D5DEEC", Offset = "0x3D5DEEC", Length = "0x14")]
		public LlmLevelSo()
		{
			m_landHome = true;
			m_difficulty = LevelDifficulty.Easy;
		}
	}
}
