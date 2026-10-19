using System;
using System.Collections;
using Cpp2ILInjected;
using ElephantSDK;
using ElephantSocial.Model;
using UnityEngine.Networking;

namespace ElephantSocial.HonorWall
{
	[Token(Token = "0x20008F7")]
	public class HonorWallOps : GenericResponseOps
	{
		[Token(Token = "0x60025B9")]
		[Address(RVA = "0x3E088E4", Offset = "0x3E088E4", Length = "0x20C")]
		public IEnumerator GetHonors(Action<GenericResponse<HonorWallResponse>> onResponse, Action<UnityWebRequest> onFailedResponse, Action<string> onError)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HonorWallOps::GetHonors");
			return default;
		}

		[Token(Token = "0x60025BA")]
		[Address(RVA = "0x3E08AF8", Offset = "0x3E08AF8", Length = "0x210")]
		public IEnumerator GrantHonor(int honorId, Action<GenericResponse<HonorWallGrantResponse>> onResponse, Action<UnityWebRequest> onFailedResponse, Action<string> onError)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HonorWallOps::GrantHonor");
			return default;
		}

		[Token(Token = "0x60025BB")]
		[Address(RVA = "0x3E088D4", Offset = "0x3E088D4", Length = "0x8")]
		public HonorWallOps()
		{
		}
	}
}
