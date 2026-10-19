using System;
using Cpp2ILInjected;
using ElephantSocial.Inbox.Model.Request;
using ElephantSocial.Inbox.Model.Response;
using ElephantSocial.Model;
using ElephantUniTask.Threading.Tasks;

namespace ElephantSocial.Inbox
{
	[Token(Token = "0x20008DD")]
	public class InboxApi
	{
		[Token(Token = "0x4001DB8")]
		internal static readonly Lazy<InboxApi> _instance;

		[Token(Token = "0x4001DB9")]
		[FieldOffset(Offset = "0x10")]
		private readonly InboxOps _inboxOps;

		[Token(Token = "0x170003E3")]
		public static InboxApi Instance
		{
			[Token(Token = "0x600256B")]
			[Address(RVA = "0x3E0528C", Offset = "0x3E0528C", Length = "0x94")]
			get
			{
				return _instance.Value;
			}
		}

		[Token(Token = "0x600256C")]
		[Address(RVA = "0x3E05320", Offset = "0x3E05320", Length = "0x78")]
		public InboxApi()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InboxApi::.ctor");
		}

		[Token(Token = "0x600256D")]
		[Address(RVA = "0x3E053A0", Offset = "0x3E053A0", Length = "0x178")]
		public UniTask<InboxResponse> GetInboxAsync()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InboxApi::GetInboxAsync");
			return default;
		}

		[Token(Token = "0x600256E")]
		[Address(RVA = "0x3E05664", Offset = "0x3E05664", Length = "0x168")]
		public UniTask MarkAsReadAsync(int inboxItemId)
		{
			MarkAsReadRequest markAsReadRequest = (MarkAsReadRequest)new SocialBaseData();
			if (markAsReadRequest != null)
			{
				markAsReadRequest.Id = inboxItemId;
				if (_inboxOps != null)
				{
					return _inboxOps.MarkAsReadAsync(markAsReadRequest);
				}
				NullReferenceException ex = new NullReferenceException();
			}
			else
			{
				NullReferenceException ex = new NullReferenceException();
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5BF4");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF0368");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @A1B8");
			UniTask result = default(UniTask);
			return result;
		}

		[Token(Token = "0x600256F")]
		[Address(RVA = "0x3E058F0", Offset = "0x3E058F0", Length = "0x94")]
		static InboxApi()
		{
			Lazy<InboxApi> instance = new Lazy<InboxApi>();
			_instance = instance;
		}
	}
}
