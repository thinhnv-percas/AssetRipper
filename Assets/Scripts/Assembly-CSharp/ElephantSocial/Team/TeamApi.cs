using System;
using Cpp2ILInjected;
using ElephantSocial.Model;
using ElephantSocial.Team.Model;
using ElephantSocial.Team.Model.Request;
using ElephantSocial.Team.Model.Response;
using ElephantSocial.Team.Network;
using ElephantUniTask.Threading.Tasks;

namespace ElephantSocial.Team
{
	[Token(Token = "0x2000887")]
	public class TeamApi
	{
		[Token(Token = "0x4001C9D")]
		internal static readonly Lazy<TeamApi> _instance;

		[Token(Token = "0x4001C9E")]
		[FieldOffset(Offset = "0x10")]
		private readonly TeamOps _teamOps;

		[Token(Token = "0x170003E0")]
		public static TeamApi Instance
		{
			[Token(Token = "0x6002473")]
			[Address(RVA = "0x3DED998", Offset = "0x3DED998", Length = "0x94")]
			get
			{
				return _instance.Value;
			}
		}

		[Token(Token = "0x6002474")]
		[Address(RVA = "0x3DEDA2C", Offset = "0x3DEDA2C", Length = "0x78")]
		public TeamApi()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamApi::.ctor");
		}

		[Token(Token = "0x6002475")]
		[Address(RVA = "0x3DEDAAC", Offset = "0x3DEDAAC", Length = "0x178")]
		public UniTask<TeamsListResponse> ListTeamsAsync(string searchTerm = "")
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamApi::ListTeamsAsync");
			return default;
		}

		[Token(Token = "0x6002476")]
		[Address(RVA = "0x3DEDF2C", Offset = "0x3DEDF2C", Length = "0x128")]
		public UniTask<Player> GetPlayerAsync()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamApi::GetPlayerAsync");
			return default;
		}

		[Token(Token = "0x6002477")]
		[Address(RVA = "0x3DEE1B8", Offset = "0x3DEE1B8", Length = "0x154")]
		public UniTask<TeamResponse> GetTeamAsync(string teamId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamApi::GetTeamAsync");
			return default;
		}

		[Token(Token = "0x6002478")]
		[Address(RVA = "0x3DEE48C", Offset = "0x3DEE48C", Length = "0x1E8")]
		public UniTask<TeamResponse> CreateTeamAsync(string name, string description, int capacity, int requiredLevel, int teamType, int badge)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamApi::CreateTeamAsync");
			return default;
		}

		[Token(Token = "0x6002479")]
		[Address(RVA = "0x3DEE7BC", Offset = "0x3DEE7BC", Length = "0x1BC")]
		public UniTask<TeamResponse> JoinTeamAsync(string teamId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamApi::JoinTeamAsync");
			return default;
		}

		[Token(Token = "0x600247A")]
		[Address(RVA = "0x3DEEAC0", Offset = "0x3DEEAC0", Length = "0x174")]
		public UniTask<TeamResponse> LeaveTeamAsync()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamApi::LeaveTeamAsync");
			return default;
		}

		[Token(Token = "0x600247B")]
		[Address(RVA = "0x3DEED7C", Offset = "0x3DEED7C", Length = "0x1E8")]
		public UniTask<TeamResponse> UpdateTeamAsync(string name, int capacity, int requiredLevel, int teamType, string description, int badge)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamApi::UpdateTeamAsync");
			return default;
		}

		[Token(Token = "0x600247C")]
		[Address(RVA = "0x3DEF0AC", Offset = "0x3DEF0AC", Length = "0x1A0")]
		public UniTask<TeamResponse> PromoteMemberAsync(string targetSocialId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamApi::PromoteMemberAsync");
			return default;
		}

		[Token(Token = "0x600247D")]
		[Address(RVA = "0x3DEF394", Offset = "0x3DEF394", Length = "0x1A0")]
		public UniTask<TeamResponse> DemoteMemberAsync(string targetSocialId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamApi::DemoteMemberAsync");
			return default;
		}

		[Token(Token = "0x600247E")]
		[Address(RVA = "0x3DEF67C", Offset = "0x3DEF67C", Length = "0x1A0")]
		public UniTask<TeamResponse> KickMemberAsync(string targetSocialId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamApi::KickMemberAsync");
			return default;
		}

		[Token(Token = "0x600247F")]
		[Address(RVA = "0x3DEF964", Offset = "0x3DEF964", Length = "0x174")]
		public UniTask<JoinRequestsResponse> GetJoinRequestsAsync()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamApi::GetJoinRequestsAsync");
			return default;
		}

		[Token(Token = "0x6002480")]
		[Address(RVA = "0x3DEFC20", Offset = "0x3DEFC20", Length = "0x174")]
		public UniTask<PlayerJoinRequestsResponse> GetPlayerJoinRequestsAsync()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TeamApi::GetPlayerJoinRequestsAsync");
			return default;
		}

		[Token(Token = "0x6002481")]
		[Address(RVA = "0x3DEFEDC", Offset = "0x3DEFEDC", Length = "0x170")]
		public UniTask AcceptJoinRequestAsync(string targetSocialId)
		{
			AcceptJoinRequest acceptJoinRequest = (AcceptJoinRequest)new SocialBaseData();
			if (acceptJoinRequest != null)
			{
				acceptJoinRequest.TargetSocialId = targetSocialId;
				if (_teamOps != null)
				{
					return _teamOps.AcceptJoinRequestAsync(acceptJoinRequest);
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

		[Token(Token = "0x6002482")]
		[Address(RVA = "0x3DF01CC", Offset = "0x3DF01CC", Length = "0x170")]
		public UniTask RejectJoinRequestAsync(string targetSocialId)
		{
			RejectJoinRequest rejectJoinRequest = (RejectJoinRequest)new SocialBaseData();
			if (rejectJoinRequest != null)
			{
				rejectJoinRequest.TargetSocialId = targetSocialId;
				if (_teamOps != null)
				{
					return _teamOps.RejectJoinRequestAsync(rejectJoinRequest);
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

		[Token(Token = "0x6002483")]
		[Address(RVA = "0x3DF04BC", Offset = "0x3DF04BC", Length = "0x184")]
		public UniTask IncrementStat(int incrementValue, string statId)
		{
			IncrementStatRequest incrementStatRequest = (IncrementStatRequest)new SocialBaseData();
			if (incrementStatRequest != null)
			{
				incrementStatRequest.IncrementValue = incrementValue;
				incrementStatRequest.StatId = statId;
				if (_teamOps != null)
				{
					return _teamOps.IncrementStat(incrementStatRequest);
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

		[Token(Token = "0x6002484")]
		[Address(RVA = "0x3DF07C0", Offset = "0x3DF07C0", Length = "0x130")]
		public UniTask<bool> IsServerHealthyAsync()
		{
			if (_teamOps != null)
			{
				return _teamOps.IsServerHealthyAsync();
			}
			NullReferenceException ex = new NullReferenceException();
			throw ex;
		}

		[Token(Token = "0x6002485")]
		[Address(RVA = "0x3DF09C8", Offset = "0x3DF09C8", Length = "0x94")]
		static TeamApi()
		{
			Lazy<TeamApi> instance = new Lazy<TeamApi>();
			_instance = instance;
		}
	}
}
