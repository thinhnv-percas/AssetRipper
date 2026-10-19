using System;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Tournament.Model
{
	[Serializable]
	[Token(Token = "0x2000876")]
	public class TournamentErrorResponse
	{
		[JsonProperty("error_code")]
		[Token(Token = "0x4001C53")]
		[FieldOffset(Offset = "0x10")]
		public long ErrorCode;

		[JsonProperty("msg")]
		[Token(Token = "0x4001C54")]
		[FieldOffset(Offset = "0x18")]
		public string Message;

		[Token(Token = "0x600244D")]
		[Address(RVA = "0x3DDC630", Offset = "0x3DDC630", Length = "0x44")]
		public TournamentErrorResponse(long errorCode, string message)
		{
			Message = message;
			ErrorCode = errorCode;
		}
	}
}
