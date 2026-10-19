using System;
using System.Collections;
using Cpp2ILInjected;
using ElephantSDK;
using ElephantSocial.Model;
using UnityEngine.Networking;

namespace ElephantSocial
{
	[Token(Token = "0x2000818")]
	public class SocialOps : GenericResponseOps
	{
		[Token(Token = "0x600227D")]
		[Address(RVA = "0x3DD52C0", Offset = "0x3DD52C0", Length = "0x230")]
		public IEnumerator GetPlayer(Action<GenericResponse<Player>> onResponse, Action<string> onError)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SocialOps::GetPlayer");
			return default;
		}

		[Token(Token = "0x600227E")]
		[Address(RVA = "0x3DD54F0", Offset = "0x3DD54F0", Length = "0x210")]
		public IEnumerator UpdatePlayer(Player player, Action<GenericResponse<Player>> onResponseSuccess, Action<UnityWebRequest> onFailedResponse, Action<string> onError)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SocialOps::UpdatePlayer");
			return default;
		}

		[Token(Token = "0x600227F")]
		[Address(RVA = "0x3DD5700", Offset = "0x3DD5700", Length = "0x8")]
		public SocialOps()
		{
		}
	}
}
