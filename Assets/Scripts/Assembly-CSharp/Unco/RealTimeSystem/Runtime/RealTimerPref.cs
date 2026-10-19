using System;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace Unco.RealTimeSystem.Runtime
{
	[Serializable]
	[Token(Token = "0x20007F3")]
	public struct RealTimerPref
	{
		[JsonProperty]
		[Token(Token = "0x4001A81")]
		[FieldOffset(Offset = "0x0")]
		public string Key;

		[JsonProperty]
		[Token(Token = "0x4001A82")]
		[FieldOffset(Offset = "0x8")]
		public DateTime LastTriggerTime;
	}
}
