using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.CoreSerivces.BoosterSystem.Core
{
	[CreateAssetMenu(fileName = "BoosterDatabase", menuName = "CoreGameKit/Booster/BoosterDatabase")]
	[Token(Token = "0x2000624")]
	public class BoosterDatabase : ScriptableObject
	{
		[SerializeField]
		[Token(Token = "0x4001537")]
		[FieldOffset(Offset = "0x18")]
		private BoosterDefinition[] m_boosters;

		[SerializeField]
		[Token(Token = "0x4001538")]
		[FieldOffset(Offset = "0x20")]
		private Sprite m_coinIcon;

		[SerializeField]
		[Token(Token = "0x4001539")]
		[FieldOffset(Offset = "0x28")]
		private string m_costPrefix;

		[Token(Token = "0x1700028A")]
		public IReadOnlyList<BoosterDefinition> Boosters
		{
			[Token(Token = "0x6001A4A")]
			[Address(RVA = "0x3D52760", Offset = "0x3D52760", Length = "0x8")]
			get
			{
				return m_boosters;
			}
		}

		[Token(Token = "0x1700028B")]
		public Sprite CoinIcon
		{
			[Token(Token = "0x6001A4B")]
			[Address(RVA = "0x3D52768", Offset = "0x3D52768", Length = "0x8")]
			get
			{
				return m_coinIcon;
			}
		}

		[Token(Token = "0x1700028C")]
		public string CostPrefix
		{
			[Token(Token = "0x6001A4C")]
			[Address(RVA = "0x3D52770", Offset = "0x3D52770", Length = "0x8")]
			get
			{
				return m_costPrefix;
			}
		}

		[Token(Token = "0x6001A4D")]
		[Address(RVA = "0x3D52778", Offset = "0x3D52778", Length = "0x8")]
		public IReadOnlyList<BoosterDefinition> GetAllDefinitions()
		{
			return m_boosters;
		}

		[Token(Token = "0x6001A4E")]
		[Address(RVA = "0x3D52780", Offset = "0x3D52780", Length = "0x10C")]
		public BoosterDefinition GetDefinition(string boosterId)
		{
			BoosterDefinition[] boosters = m_boosters;
			if (boosters.Length < 1)
			{
				goto IL_00ad;
			}
			int num = 0;
			BoosterDefinition result;
			while (true)
			{
				BoosterDefinition boosterDefinition = boosters[num];
				bool flag = boosterDefinition.Id == boosterId;
				bool flag2 = !flag;
				bool flag3 = !flag2;
				result = boosters[num];
				if (flag3)
				{
					break;
				}
				num++;
				if (num < boosters.Length)
				{
					continue;
				}
				goto IL_00ad;
			}
			goto IL_00d8;
			IL_00d8:
			return result;
			IL_00ad:
			string message = "BoosterDatabase: No definition found for booster ID '" + boosterId + "'";
			Debug.LogError(message);
			result = null;
			goto IL_00d8;
		}

		[Token(Token = "0x6001A4F")]
		[Address(RVA = "0x3D5288C", Offset = "0x3D5288C", Length = "0x8")]
		public BoosterDatabase()
		{
		}
	}
}
