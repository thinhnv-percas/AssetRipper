using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Morpeh.Globals;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GBG.Pinata.ECS
{
	[Serializable]
	[Token(Token = "0x200002F")]
	public struct EnemySettings
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74AED4", Offset = "0x74AED4")]
		[Token(Token = "0x40000AF")]
		[FieldOffset(Offset = "0x0")]
		public GlobalVariableInt CurrentEnemy;

		[Token(Token = "0x40000B0")]
		[FieldOffset(Offset = "0x8")]
		public GlobalVariableInt CurrentEnemyHealth;

		[TableList]
		[Token(Token = "0x40000B1")]
		[FieldOffset(Offset = "0x10")]
		public List<EnemySetupClass> EnemiesSetup;
	}
}
