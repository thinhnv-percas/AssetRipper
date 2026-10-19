using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Cpp2ILInjected;
using ElephantSDK;
using ElephantSocial.Model;
using ElephantSocial.Tournament.Model;
using UnityEngine;
using UnityEngine.Networking;

namespace ElephantSocial.Tournament.Network
{
	[Token(Token = "0x200085D")]
	public class TournamentOps : GenericResponseOps
	{
		[CompilerGenerated]
		[Token(Token = "0x200085E")]
		private sealed class _003C_003Ec__DisplayClass0_0<T> where T : new()
		{
			[Token(Token = "0x4001C1D")]
			[FieldOffset(Offset = "0x0")]
			public Action<GenericResponse<T>> onResponse;

			[Token(Token = "0x4001C1E")]
			[FieldOffset(Offset = "0x0")]
			public Action<string> onError;

			[Token(Token = "0x4001C1F")]
			[FieldOffset(Offset = "0x0")]
			public Action<long, string> _003C_003E9__3;

			[Token(Token = "0x60023EF")]
			[Address(RVA = "0x4FFD460", Offset = "0x4FFD460", Length = "0x8")]
			public _003C_003Ec__DisplayClass0_0()
			{
			}

			internal void _003CMakeRequest_003Eb__0(GenericResponse<T> response)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TournamentOps._003C_003Ec__DisplayClass0_0::_003CMakeRequest_003Eb__0");
			}

			internal void _003CMakeRequest_003Eb__1(UnityWebRequest request)
			{
				Action<long, string> error = _003C_003E9__3;
				if (_003C_003E9__3 == null)
				{
					error = (_003C_003E9__3 = delegate(long code, string message)
					{
						if (onError != null)
						{
							int num = 192761856 + 1336;
							Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
							object arg = default(object);
							string obj = $"Error {arg}: {message}";
							onError(obj);
						}
					});
				}
				GenericResponseOps.HandleErrorResponse(request, error);
			}

			internal void _003CMakeRequest_003Eb__3(long code, string message)
			{
				if (onError != null)
				{
					int num = 192761856 + 1336;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					object arg = default(object);
					string obj = $"Error {arg}: {message}";
					onError(obj);
				}
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200085F")]
		private sealed class _003C_003Ec__DisplayClass0_1<T> where T : new()
		{
			[Token(Token = "0x4001C20")]
			[FieldOffset(Offset = "0x0")]
			public GenericResponse<T> response;

			[Token(Token = "0x4001C21")]
			[FieldOffset(Offset = "0x0")]
			public _003C_003Ec__DisplayClass0_0<T> CS_0024_003C_003E8__locals1;

			[Token(Token = "0x60023F3")]
			[Address(RVA = "0x4FFE484", Offset = "0x4FFE484", Length = "0x8")]
			public _003C_003Ec__DisplayClass0_1()
			{
			}

			internal void _003CMakeRequest_003Eb__2(T r)
			{
				_003C_003Ec__DisplayClass0_0<T> _003C_003Ec__DisplayClass0_2 = CS_0024_003C_003E8__locals1;
				if (_003C_003Ec__DisplayClass0_2.onResponse != null)
				{
					_003C_003Ec__DisplayClass0_2.onResponse(response);
				}
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000860")]
		private sealed class _003CCheckServerHealth_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4001C22")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4001C23")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4001C24")]
			[FieldOffset(Offset = "0x20")]
			public TournamentOps _003C_003E4__this;

			[Token(Token = "0x4001C25")]
			[FieldOffset(Offset = "0x28")]
			public Action onError;

			[Token(Token = "0x4001C26")]
			[FieldOffset(Offset = "0x30")]
			public Action onSuccess;

			[Token(Token = "0x4001C27")]
			[FieldOffset(Offset = "0x38")]
			private UnityWebRequest _003Crequest_003E5__2;

			[Token(Token = "0x170003C1")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60023F9")]
				[Address(RVA = "0x3DE9214", Offset = "0x3DE9214", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x170003C2")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60023FB")]
				[Address(RVA = "0x3DE925C", Offset = "0x3DE925C", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60023F5")]
			[Address(RVA = "0x3DE8B8C", Offset = "0x3DE8B8C", Length = "0x2C")]
			public _003CCheckServerHealth_003Ed__12(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x60023F6")]
			[Address(RVA = "0x3DE8BB8", Offset = "0x3DE8BB8", Length = "0xDC")]
			void IDisposable.Dispose()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TournamentOps._003CCheckServerHealth_003Ed__12::Dispose");
			}

			[Token(Token = "0x60023F7")]
			[Address(RVA = "0x3DE8C94", Offset = "0x3DE8C94", Length = "0x4BC")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TournamentOps._003CCheckServerHealth_003Ed__12::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[Token(Token = "0x60023F8")]
			[Address(RVA = "0x3DE9150", Offset = "0x3DE9150", Length = "0xC4")]
			private void _003C_003Em__Finally1()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TournamentOps._003CCheckServerHealth_003Ed__12::_003C_003Em__Finally1");
			}

			[DebuggerHidden]
			[Token(Token = "0x60023FA")]
			[Address(RVA = "0x3DE921C", Offset = "0x3DE921C", Length = "0x40")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x60023E1")]
		[Address(RVA = "0x4D15514", Offset = "0x4D15514", Length = "0x200")]
		private IEnumerator MakeRequest<T>(string url, object data, Action<GenericResponse<T>> onResponse, Action<string> onError, int timeout = 30) where T : new()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TournamentOps::MakeRequest");
			return default;
		}

		[Token(Token = "0x60023E2")]
		[Address(RVA = "0x3DE51C0", Offset = "0x3DE51C0", Length = "0x22C")]
		public IEnumerator AddScore(int score, int tournamentId, int scheduleId, int timeout, Action<GenericResponse<TournamentAddScoreResponse>> onResponse, Action<string> onError, Action<UnityWebRequest> onFailedResponse)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TournamentOps::AddScore");
			return default;
		}

		[Token(Token = "0x60023E3")]
		[Address(RVA = "0x3DE57B0", Offset = "0x3DE57B0", Length = "0x224")]
		public IEnumerator AddScores(int tournamentId, int scheduleId, List<PlayerScore> scores, int timeout, Action<GenericResponse<TournamentBulkAddScoresResponse>> onResponse, Action<string> onError, Action<UnityWebRequest> onFailedResponse)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TournamentOps::AddScores");
			return default;
		}

		[Token(Token = "0x60023E4")]
		[Address(RVA = "0x3DE4A4C", Offset = "0x3DE4A4C", Length = "0x188")]
		public IEnumerator GetBoard(int tournamentId, int scheduleId, Action<GenericResponse<TournamentBoardResponse>> onResponse, Action<string> onError)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TournamentOps::GetBoard");
			return default;
		}

		[Token(Token = "0x60023E5")]
		[Address(RVA = "0x3DE53F4", Offset = "0x3DE53F4", Length = "0x224")]
		public IEnumerator AddMatch(int tournamentId, int scheduleId, List<ScoreUpdate> scoreUpdates, Action<GenericResponse<object>> onResponse, Action<string> onError)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TournamentOps::AddMatch");
			return default;
		}

		[Token(Token = "0x60023E6")]
		[Address(RVA = "0x3DE5620", Offset = "0x3DE5620", Length = "0x188")]
		public IEnumerator ListMatches(int tournamentId, int scheduleId, Action<GenericResponse<List<TournamentMatchItem>>> onResponse, Action<string> onError)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TournamentOps::ListMatches");
			return default;
		}

		[Token(Token = "0x60023E7")]
		[Address(RVA = "0x3DE4D5C", Offset = "0x3DE4D5C", Length = "0x190")]
		public IEnumerator JoinTournament(int tournamentId, int scheduleId, int segmentId, Action<GenericResponse<TournamentJoinResponse>> onResponse, Action<string> onError)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TournamentOps::JoinTournament");
			return default;
		}

		[Token(Token = "0x60023E8")]
		[Address(RVA = "0x3DE5030", Offset = "0x3DE5030", Length = "0x188")]
		public IEnumerator ClaimTournament(int tournamentId, int scheduleId, Action<GenericResponse<TournamentFinishResponse>> onResponse, Action<string> onError)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TournamentOps::ClaimTournament");
			return default;
		}

		[Token(Token = "0x60023E9")]
		[Address(RVA = "0x3DE474C", Offset = "0x3DE474C", Length = "0x178")]
		public IEnumerator GetTournaments(Action<GenericResponse<TournamentsResponse>> onResponse, Action<string> onError)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TournamentOps::GetTournaments");
			return default;
		}

		[Token(Token = "0x60023EA")]
		[Address(RVA = "0x3DE48CC", Offset = "0x3DE48CC", Length = "0x178")]
		public IEnumerator GetMyTournaments(Action<GenericResponse<MyTournamentsResponse>> onResponse, Action<string> onError)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TournamentOps::GetMyTournaments");
			return default;
		}

		[Token(Token = "0x60023EB")]
		[Address(RVA = "0x3DE4BDC", Offset = "0x3DE4BDC", Length = "0x178")]
		public IEnumerator GetMyTournamentResults(Action<GenericResponse<MyTournamentResultsResponse>> onResponse, Action<string> onError)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TournamentOps::GetMyTournamentResults");
			return default;
		}

		[Token(Token = "0x60023EC")]
		[Address(RVA = "0x3DE094C", Offset = "0x3DE094C", Length = "0xFC")]
		public void TournamentHealthCheck(Action onSuccess, Action onError)
		{
			_003CCheckServerHealth_003Ed__12 _003CCheckServerHealth_003Ed__13 = (_003CCheckServerHealth_003Ed__12)FormatterServices.GetUninitializedObject(typeof(_003CCheckServerHealth_003Ed__12));
			_003CCheckServerHealth_003Ed__13._003C_003E1__state = 0;
			_003CCheckServerHealth_003Ed__13._003C_003E4__this = this;
			_003CCheckServerHealth_003Ed__13.onSuccess = onSuccess;
			_003CCheckServerHealth_003Ed__13.onError = onError;
			Coroutine coroutine = ElephantCore.Instance.StartCoroutine(_003CCheckServerHealth_003Ed__13);
		}

		[IteratorStateMachine(typeof(_003CCheckServerHealth_003Ed__12))]
		[Token(Token = "0x60023ED")]
		[Address(RVA = "0x3DE8AE4", Offset = "0x3DE8AE4", Length = "0xA8")]
		private IEnumerator CheckServerHealth(Action onSuccess, Action onError)
		{
			_003CCheckServerHealth_003Ed__12 _003CCheckServerHealth_003Ed__13 = (_003CCheckServerHealth_003Ed__12)FormatterServices.GetUninitializedObject(typeof(_003CCheckServerHealth_003Ed__12));
			_003CCheckServerHealth_003Ed__13._003C_003E1__state = 0;
			_003CCheckServerHealth_003Ed__13._003C_003E4__this = this;
			_003CCheckServerHealth_003Ed__13.onSuccess = onSuccess;
			_003CCheckServerHealth_003Ed__13.onError = onError;
			return _003CCheckServerHealth_003Ed__13;
		}

		[Token(Token = "0x60023EE")]
		[Address(RVA = "0x3DDFEEC", Offset = "0x3DDFEEC", Length = "0x8")]
		public TournamentOps()
		{
		}
	}
}
