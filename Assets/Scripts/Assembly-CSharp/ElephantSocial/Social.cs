using System;
using Cpp2ILInjected;
using ElephantSDK;
using ElephantSocial.Chat.TeamChat;
using ElephantSocial.Model;
using ElephantUniTask.Threading.Tasks;

namespace ElephantSocial
{
	[Token(Token = "0x2000819")]
	public class Social
	{
		[Token(Token = "0x4001B2C")]
		[FieldOffset(Offset = "0x10")]
		public Action OnInitializeCallback;

		[Token(Token = "0x4001B2D")]
		[FieldOffset(Offset = "0x18")]
		public Action<string> OnInitializeFailedCallback;

		[Token(Token = "0x4001B2E")]
		internal static readonly Lazy<Social> _instance;

		[Token(Token = "0x4001B2F")]
		[FieldOffset(Offset = "0x20")]
		internal SocialInternal _socialInternal;

		[Token(Token = "0x17000356")]
		public SocialConfig SocialConfig
		{
			[Token(Token = "0x6002280")]
			[Address(RVA = "0x3DD5234", Offset = "0x3DD5234", Length = "0x1C")]
			get
			{
				SocialInternal socialInternal = _socialInternal;
				return socialInternal.SocialConfig;
			}
		}

		[Token(Token = "0x17000357")]
		public static Social Instance
		{
			[Token(Token = "0x6002282")]
			[Address(RVA = "0x3DD51A0", Offset = "0x3DD51A0", Length = "0x94")]
			get
			{
				return _instance.Value;
			}
		}

		[Token(Token = "0x6002281")]
		[Address(RVA = "0x3DD5708", Offset = "0x3DD5708", Length = "0x74")]
		private Social()
		{
			SocialInternal socialInternal = new SocialInternal();
			_socialInternal = socialInternal;
		}

		[Token(Token = "0x6002283")]
		[Address(RVA = "0x3DD58D4", Offset = "0x3DD58D4", Length = "0xF0")]
		public unsafe void Init(SocialConfig socialConfig)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Social::Init");
		}

		[Token(Token = "0x6002284")]
		[Address(RVA = "0x3DD5B98", Offset = "0x3DD5B98", Length = "0x18")]
		public void UpdatePlayer(Player newPlayer, Action onSuccess, Action<string> onFailed, Action<string> onError)
		{
			_socialInternal.UpdatePlayer(newPlayer, onSuccess, onFailed, onError);
		}

		[Token(Token = "0x6002285")]
		[Address(RVA = "0x3DD5D6C", Offset = "0x3DD5D6C", Length = "0x28")]
		public Player GetPlayer()
		{
			Player player = _socialInternal.Player;
			return player.Clone();
		}

		[Token(Token = "0x6002286")]
		[Address(RVA = "0x3DD5DB4", Offset = "0x3DD5DB4", Length = "0x24")]
		public void GetPlayer(string socialId, Action<Player> response, Action<string> onFailed, Action<string> onError, bool forceRefresh = false)
		{
			SocialInternal socialInternal = _socialInternal;
			socialInternal._socialIdPlayerCache.GetPlayer(socialId, response, onFailed, onError, forceRefresh);
		}

		[Token(Token = "0x6002287")]
		[Address(RVA = "0x3DD5DF0", Offset = "0x3DD5DF0", Length = "0x114")]
		static Social()
		{
			Func<Social> valueFactory = delegate
			{
				Social social = new Social();
				SocialInternal socialInternal = new SocialInternal();
				social._socialInternal = socialInternal;
				return social;
			};
			Lazy<Social> instance = new Lazy<Social>(valueFactory);
			_instance = instance;
		}
	}
}
