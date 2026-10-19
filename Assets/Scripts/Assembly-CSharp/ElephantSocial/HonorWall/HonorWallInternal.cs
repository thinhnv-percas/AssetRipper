using System;
using System.Collections;
using Cpp2ILInjected;
using ElephantSDK;
using UnityEngine;
using UnityEngine.Networking;

namespace ElephantSocial.HonorWall
{
	[Token(Token = "0x20008F4")]
	internal class HonorWallInternal : SocialDataStore
	{
		[Token(Token = "0x4001DE8")]
		private static HonorWallInternal _instance;

		[Token(Token = "0x4001DE9")]
		[FieldOffset(Offset = "0x10")]
		private readonly HonorWallOps _honorWallOps;

		[Token(Token = "0x60025AB")]
		[Address(RVA = "0x3E080D8", Offset = "0x3E080D8", Length = "0xF4")]
		internal static HonorWallInternal GetInstance()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HonorWallInternal::GetInstance");
			return default;
		}

		[Token(Token = "0x60025AC")]
		[Address(RVA = "0x3E0885C", Offset = "0x3E0885C", Length = "0x78")]
		private HonorWallInternal()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HonorWallInternal::.ctor");
		}

		[Token(Token = "0x60025AD")]
		[Address(RVA = "0x3E081E8", Offset = "0x3E081E8", Length = "0x1A4")]
		public void GetHonors(Action<HonorWallResponse> onSuccess, Action<string> onFailed, Action<string> onError)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HonorWallInternal::GetHonors");
		}

		[Token(Token = "0x60025AE")]
		[Address(RVA = "0x3E083A8", Offset = "0x3E083A8", Length = "0x1AC")]
		public void GrantHonor(int honorId, Action onSuccess, Action<string> onFailed, Action<string> onError)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HonorWallInternal::GrantHonor");
		}
	}
}
