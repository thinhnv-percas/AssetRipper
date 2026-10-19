using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unco.RealTimeSystem.Runtime;

namespace _game.Systems.ElephantStorage
{
	[Serializable]
	[Token(Token = "0x2000786")]
	public class RealTimeStorageData
	{
		[Token(Token = "0x1700030F")]
		[field: Token(Token = "0x400190C")]
		[field: FieldOffset(Offset = "0x10")]
		public List<RealTimerPref> Timers
		{
			[Token(Token = "0x6001FCD")]
			[Address(RVA = "0x3D942C4", Offset = "0x3D942C4", Length = "0x8")]
			get;
			[Token(Token = "0x6001FCE")]
			[Address(RVA = "0x3D942CC", Offset = "0x3D942CC", Length = "0x8")]
			set;
		}

		[Token(Token = "0x6001FCF")]
		[Address(RVA = "0x3D941E8", Offset = "0x3D941E8", Length = "0x8C")]
		public RealTimeStorageData()
		{
			List<RealTimerPref> list = new List<RealTimerPref>();
			Timers = list;
		}
	}
}
