using System;
using Cpp2ILInjected;
using ElephantSDK;
using Newtonsoft.Json;

namespace ElephantSocial.Model
{
	[Serializable]
	[Token(Token = "0x20008C7")]
	public class SocialBaseData : BaseData
	{
		[JsonProperty("request_id")]
		[Token(Token = "0x4001D7E")]
		[FieldOffset(Offset = "0x110")]
		public long requestId;

		[Token(Token = "0x600252C")]
		[Address(RVA = "0x3DE94F8", Offset = "0x3DE94F8", Length = "0xF0")]
		public SocialBaseData()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78E32D]");
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
				long num = ElephantSDK.Utils.Timestamp();
				requestId = num;
				return;
			}
			throw new NullReferenceException();
		}
	}
}
