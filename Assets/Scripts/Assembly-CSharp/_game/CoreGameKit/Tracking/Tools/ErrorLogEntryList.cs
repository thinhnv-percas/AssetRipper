using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace _game.CoreGameKit.Tracking.Tools
{
	[Serializable]
	[Token(Token = "0x200058D")]
	internal class ErrorLogEntryList
	{
		[Token(Token = "0x400132C")]
		[FieldOffset(Offset = "0x10")]
		public List<ErrorLogEntry> Errors;

		[Token(Token = "0x6001789")]
		[Address(RVA = "0x3D2DD2C", Offset = "0x3D2DD2C", Length = "0x8C")]
		public ErrorLogEntryList()
		{
			List<ErrorLogEntry> errors = new List<ErrorLogEntry>();
			Errors = errors;
		}
	}
}
