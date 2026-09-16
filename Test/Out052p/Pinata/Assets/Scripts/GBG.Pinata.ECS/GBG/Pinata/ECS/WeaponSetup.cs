using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Sirenix.OdinInspector;

namespace GBG.Pinata.ECS
{
	[Serializable]
	[Token(Token = "0x2000031")]
	public struct WeaponSetup
	{
		[TableList]
		[Token(Token = "0x40000B4")]
		[FieldOffset(Offset = "0x0")]
		public List<WeaponSetupClass> Collection;
	}
}
