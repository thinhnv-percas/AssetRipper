using System;
using Cpp2ILInjected;
using ElephantSDK;
using Newtonsoft.Json;

namespace ElephantSocial.Tournament.Model
{
	[Serializable]
	[Token(Token = "0x2000865")]
	public class GeneralTournamentRequest : BaseData
	{
		[JsonProperty("elephant_id")]
		[Token(Token = "0x4001C32")]
		[FieldOffset(Offset = "0x110")]
		public string elephantId;

		[Token(Token = "0x6002412")]
		[Address(RVA = "0x3DE87F0", Offset = "0x3DE87F0", Length = "0xCC")]
		public GeneralTournamentRequest()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78E29C]");
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
			}
			else
			{
				_ = 1;
			}
			if ((object)ElephantCore.Instance != null)
			{
				SessionData currentSession = ElephantCore.Instance.GetCurrentSession();
				FillBaseData(currentSession.start_time);
				elephantId = user_id;
				return;
			}
			throw new NullReferenceException();
		}
	}
}
