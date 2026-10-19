using System;
using Cpp2ILInjected;

namespace _game.CoreGameKit.Tracking.Tools
{
	[Serializable]
	[Token(Token = "0x200058F")]
	public class ErrorLogEntry
	{
		[Token(Token = "0x4001330")]
		[FieldOffset(Offset = "0x10")]
		public string Message;

		[Token(Token = "0x4001331")]
		[FieldOffset(Offset = "0x18")]
		public string StackTrace;

		[Token(Token = "0x4001332")]
		[FieldOffset(Offset = "0x20")]
		public string LogType;

		[Token(Token = "0x4001333")]
		[FieldOffset(Offset = "0x28")]
		public string Timestamp;

		[Token(Token = "0x6001797")]
		[Address(RVA = "0x3D2E724", Offset = "0x3D2E724", Length = "0x164")]
		public override string ToString()
		{
			return "[" + Timestamp + "] " + LogType + ": " + Message;
		}

		[Token(Token = "0x6001798")]
		[Address(RVA = "0x3D2E71C", Offset = "0x3D2E71C", Length = "0x8")]
		public ErrorLogEntry()
		{
		}
	}
}
