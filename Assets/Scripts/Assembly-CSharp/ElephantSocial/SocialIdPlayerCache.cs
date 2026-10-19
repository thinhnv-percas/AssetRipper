using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using ElephantSDK;
using ElephantSocial.Model;
using ElephantSocial.Tournament.Model;
using UnityEngine;
using UnityEngine.Networking;

namespace ElephantSocial
{
	[Token(Token = "0x200081F")]
	public class SocialIdPlayerCache : GenericResponseOps
	{
		[Token(Token = "0x4001B8F")]
		[FieldOffset(Offset = "0x10")]
		internal readonly Dictionary<string, Player> _cachedPlayers;

		[Token(Token = "0x60022F2")]
		[Address(RVA = "0x3DDB460", Offset = "0x3DDB460", Length = "0x2B0")]
		public void GetPlayer(string socialId, Action<Player> onResponse, Action<string> onFailed, Action<string> onError, bool forceRefresh = false)
		{
			if (!forceRefresh)
			{
				bool flag = _cachedPlayers.TryGetValue(socialId, out var _);
				if (flag)
				{
				}
				if (flag)
				{
					if (onResponse != null)
					{
						object obj = default(object);
						onResponse((Player)obj);
					}
					return;
				}
			}
			Action<GenericResponse<Player>> onResponse2 = delegate(GenericResponse<Player> response)
			{
				SocialIdPlayerCache socialIdPlayerCache = this;
				socialIdPlayerCache._cachedPlayers[socialId] = response.data;
				if (onResponse != null)
				{
					onResponse(response.data);
				}
			};
			Action<UnityWebRequest> onFailedResponse = OnFailedResponse;
			Action<string> onError2 = delegate(string error)
			{
				ElephantLog.LogError("Social", error);
				if (onError != null)
				{
					onError(error);
				}
			};
			IEnumerator playerWithSocialID = GetPlayerWithSocialID(socialId, onResponse2, onFailedResponse, onError2);
			Coroutine coroutine = ElephantCore.Instance.StartCoroutine(playerWithSocialID);
			[Token(Token = "0x60022F8")]
			[Address(RVA = "0x3DDBAE4", Offset = "0x3DDBAE4", Length = "0xC4")]
			void OnFailedResponse(UnityWebRequest failedResponse)
			{
				Action<long, string> action = delegate(long errorCode, string message)
				{
					if (onFailed != null)
					{
						onFailed(message);
					}
				};
				TournamentErrorResponse tournamentErrorResponse = SocialUtils.GetTournamentErrorResponse(failedResponse);
				action?.Invoke(tournamentErrorResponse.ErrorCode, tournamentErrorResponse.Message);
			}
		}

		[Token(Token = "0x60022F3")]
		[Address(RVA = "0x3DDB718", Offset = "0x3DDB718", Length = "0x9C")]
		private bool IsPlayerCached(string socialId, out Player cachedPlayer)
		{
			cachedPlayer = null;
			string key = default(string);
			bool flag = _cachedPlayers.TryGetValue(key, out var value);
			Player player = ((!flag) ? null : value);
			cachedPlayer = player;
			return flag;
		}

		[Token(Token = "0x60022F4")]
		[Address(RVA = "0x3DDB9EC", Offset = "0x3DDB9EC", Length = "0x6C")]
		private void CachePlayer(string socialId, Player player)
		{
			string key = default(string);
			Player value = default(Player);
			_cachedPlayers[key] = value;
		}

		[Token(Token = "0x60022F5")]
		[Address(RVA = "0x3DDB7B4", Offset = "0x3DDB7B4", Length = "0x238")]
		private IEnumerator GetPlayerWithSocialID(string socialId, Action<GenericResponse<Player>> onResponse, Action<UnityWebRequest> onFailedResponse, Action<string> onError)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SocialIdPlayerCache::GetPlayerWithSocialID");
			return default;
		}

		[Token(Token = "0x60022F6")]
		[Address(RVA = "0x3DDBA58", Offset = "0x3DDBA58", Length = "0x8C")]
		public SocialIdPlayerCache()
		{
			Dictionary<string, Player> cachedPlayers = new Dictionary<string, Player>();
			_cachedPlayers = cachedPlayers;
		}
	}
}
