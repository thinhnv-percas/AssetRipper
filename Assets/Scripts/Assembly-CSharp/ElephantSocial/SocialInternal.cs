using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using ElephantSDK;
using ElephantSocial.Model;
using UnityEngine;
using UnityEngine.Networking;

namespace ElephantSocial
{
	[Token(Token = "0x2000821")]
	public class SocialInternal : SocialDataStore
	{
		[Token(Token = "0x4001B96")]
		[FieldOffset(Offset = "0x18")]
		private readonly SocialOps _socialOps;

		[Token(Token = "0x4001B97")]
		[FieldOffset(Offset = "0x20")]
		internal readonly SocialIdPlayerCache _socialIdPlayerCache;

		[Token(Token = "0x4001B98")]
		[FieldOffset(Offset = "0x28")]
		private bool _isInitialized;

		[Token(Token = "0x4001B99")]
		private const string PlayerDataStoreKey = "PlayerDataStoreKey";

		[Token(Token = "0x4001B9A")]
		[FieldOffset(Offset = "0x29")]
		private bool _isPlayerLoaded;

		[Token(Token = "0x4001B9B")]
		[FieldOffset(Offset = "0x30")]
		private Player _player;

		[Token(Token = "0x170003B4")]
		[field: Token(Token = "0x4001B95")]
		[field: FieldOffset(Offset = "0x10")]
		public SocialConfig SocialConfig
		{
			[Token(Token = "0x60022FC")]
			[Address(RVA = "0x3DDBD0C", Offset = "0x3DDBD0C", Length = "0x8")]
			get;
			[Token(Token = "0x60022FD")]
			[Address(RVA = "0x3DDBD14", Offset = "0x3DDBD14", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x170003B5")]
		private bool IsInitialized
		{
			[Token(Token = "0x60022FE")]
			[Address(RVA = "0x3DDBD1C", Offset = "0x3DDBD1C", Length = "0x8")]
			get
			{
				return _isInitialized;
			}
		}

		[Token(Token = "0x170003B6")]
		internal Player Player
		{
			[Token(Token = "0x60022FF")]
			[Address(RVA = "0x3DDBD24", Offset = "0x3DDBD24", Length = "0xD4")]
			get
			{
				//IL_0009: Expected O, but got I4
				object obj = 192471040;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78E1FA]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					if (_isPlayerLoaded)
					{
						goto IL_005b;
					}
				}
				else
				{
					_ = 1;
					if (_isPlayerLoaded)
					{
						goto IL_005b;
					}
				}
				_isPlayerLoaded = true;
				Player player = Load<Player>("PlayerDataStoreKey");
				bool flag = player == null;
				bool flag2 = !flag;
				Player player2 = player;
				if (!flag2)
				{
					Player player3 = new Player();
					player2 = player3;
				}
				_player = player2;
				return _player;
				IL_005b:
				return _player;
			}
			[Token(Token = "0x6002300")]
			[Address(RVA = "0x3DDBDF8", Offset = "0x3DDBDF8", Length = "0x9C")]
			private set
			{
				Player player = default(Player);
				_player = player;
				Save("PlayerDataStoreKey", _player);
				_isPlayerLoaded = true;
			}
		}

		[Token(Token = "0x6002301")]
		[Address(RVA = "0x3DD59C4", Offset = "0x3DD59C4", Length = "0x1D4")]
		public void Init(SocialConfig socialConfig, Action onSuccess, Action<string> onError)
		{
			SocialConfig = socialConfig;
			if (_isInitialized)
			{
				if (onError != null)
				{
					onError("Multiple init requested");
				}
				ElephantLog.LogError("Social", "Multiple init requested");
				return;
			}
			Action onResponse = delegate
			{
				if (onSuccess != null)
				{
					onSuccess();
				}
			};
			Action<string> onError2 = delegate(string error)
			{
				Player player = Player;
				if (player != null)
				{
					Player player2 = Player;
					if (!string.IsNullOrEmpty(player2.socialId))
					{
						if (onSuccess != null)
						{
							onSuccess();
						}
						return;
					}
				}
				if (onError != null)
				{
					onError(error);
				}
				ElephantLog.LogError("Social", error);
			};
			InitPlayer(onResponse, onError2);
		}

		[Token(Token = "0x6002302")]
		[Address(RVA = "0x3DDBE94", Offset = "0x3DDBE94", Length = "0x190")]
		private void InitPlayer(Action onResponse, Action<string> onError)
		{
			Action<GenericResponse<Player>> onResponse2 = delegate(GenericResponse<Player> response)
			{
				Player = response.data;
				if (onResponse != null)
				{
					onResponse();
				}
				SocialInternal socialInternal = this;
				socialInternal._isInitialized = true;
			};
			Action<string> onError2 = delegate(string error)
			{
				ElephantLog.LogError("Social", error);
				SocialInternal socialInternal = this;
				socialInternal._isInitialized = false;
				if (onError != null)
				{
					onError(error);
				}
			};
			IEnumerator player = _socialOps.GetPlayer(onResponse2, onError2);
			Coroutine coroutine = ElephantCore.Instance.StartCoroutine(player);
		}

		[Token(Token = "0x6002303")]
		[Address(RVA = "0x3DDC024", Offset = "0x3DDC024", Length = "0x4")]
		public Player GetPlayerAsync()
		{
			return Player;
		}

		[Token(Token = "0x6002304")]
		[Address(RVA = "0x3DD5D94", Offset = "0x3DD5D94", Length = "0x20")]
		public Player GetPlayer()
		{
			Player player = Player;
			return player.Clone();
		}

		[Token(Token = "0x6002305")]
		[Address(RVA = "0x3DD5DD8", Offset = "0x3DD5DD8", Length = "0x18")]
		public void GetPlayer(string socialId, Action<Player> response, Action<string> onFailed, Action<string> onError, bool forceRefresh = false)
		{
			_socialIdPlayerCache.GetPlayer(socialId, response, onFailed, onError, forceRefresh);
		}

		[Token(Token = "0x6002306")]
		[Address(RVA = "0x3DD5BB0", Offset = "0x3DD5BB0", Length = "0x1BC")]
		public void UpdatePlayer(Player newPlayer, Action onSuccess, Action<string> onFailed, Action<string> onError)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SocialInternal::UpdatePlayer");
		}

		[Token(Token = "0x6002307")]
		[Address(RVA = "0x3DD577C", Offset = "0x3DD577C", Length = "0x158")]
		public SocialInternal()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SocialInternal::.ctor");
		}
	}
}
