using System;
using System.Collections;
using Cpp2ILInjected;
using ElephantSDK;
using ElephantSocial.Tournament.Model;

namespace ElephantSocial.Tournament.Network
{
	[Token(Token = "0x200085C")]
	public class TournamentManagerOps : SocialOps
	{
		[Token(Token = "0x60023DF")]
		[Address(RVA = "0x3DE85F4", Offset = "0x3DE85F4", Length = "0x1FC")]
		public IEnumerator GetTournamentInitialConfig(Action<GenericResponse<TournamentInitResponse>> onResponse, Action<string> onError)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TournamentManagerOps::GetTournamentInitialConfig");
			return default;
		}

		[Token(Token = "0x60023E0")]
		[Address(RVA = "0x3DE88BC", Offset = "0x3DE88BC", Length = "0x8")]
		public TournamentManagerOps()
		{
		}
	}
}
