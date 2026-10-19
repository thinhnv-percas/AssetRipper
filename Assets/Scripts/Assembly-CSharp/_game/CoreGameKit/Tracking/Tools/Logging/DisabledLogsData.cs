using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace _game.CoreGameKit.Tracking.Tools.Logging
{
	[Serializable]
	[Token(Token = "0x2000591")]
	public class DisabledLogsData
	{
		[Token(Token = "0x4001336")]
		[FieldOffset(Offset = "0x10")]
		public bool disableAll;

		[Token(Token = "0x4001337")]
		[FieldOffset(Offset = "0x18")]
		public List<string> disabledTypes;

		[Token(Token = "0x60017A1")]
		[Address(RVA = "0x3D2EFD8", Offset = "0x3D2EFD8", Length = "0x8C")]
		public DisabledLogsData()
		{
			List<string> list = new List<string>();
			disabledTypes = list;
		}
	}
}
