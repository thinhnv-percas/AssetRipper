using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using ElephantSDK;
using ElephantSocial.Tournament.Model;
using Newtonsoft.Json;
using UnityEngine;

namespace ElephantSocial.Tournament
{
	[Token(Token = "0x2000832")]
	public class TournamentDataStore
	{
		[Token(Token = "0x2000833")]
		public class OfflineScore
		{
			[Token(Token = "0x170003BC")]
			[field: Token(Token = "0x4001BCC")]
			[field: FieldOffset(Offset = "0x10")]
			public int Score
			{
				[Token(Token = "0x600234E")]
				[Address(RVA = "0x3DDFA20", Offset = "0x3DDFA20", Length = "0x8")]
				get;
				[Token(Token = "0x600234F")]
				[Address(RVA = "0x3DDFA28", Offset = "0x3DDFA28", Length = "0x8")]
				set;
			}

			[Token(Token = "0x170003BD")]
			[field: Token(Token = "0x4001BCD")]
			[field: FieldOffset(Offset = "0x18")]
			public long Timestamp
			{
				[Token(Token = "0x6002350")]
				[Address(RVA = "0x3DDFA30", Offset = "0x3DDFA30", Length = "0x8")]
				get;
				[Token(Token = "0x6002351")]
				[Address(RVA = "0x3DDFA38", Offset = "0x3DDFA38", Length = "0x8")]
				set;
			}

			[Token(Token = "0x6002352")]
			[Address(RVA = "0x3DDEE1C", Offset = "0x3DDEE1C", Length = "0x8")]
			public OfflineScore()
			{
			}
		}

		[Token(Token = "0x4001BC5")]
		internal static readonly Lazy<TournamentDataStore> _instance;

		[Token(Token = "0x4001BC6")]
		private const string TournamentResponseDataStoreKey = "TournamentResponseStoreKey";

		[Token(Token = "0x4001BC7")]
		private const string MyTournamentsResponseDataStoreKey = "MyTournamentsResponseKey";

		[Token(Token = "0x4001BC8")]
		private const string MyTournamentResultsDataStoreKey = "MyTournamentResultsResponseKey";

		[Token(Token = "0x4001BC9")]
		private const string TournamentBoardResponseStoreKey = "TournamentBoardResponseKey";

		[Token(Token = "0x4001BCA")]
		private const string OfflineScoresKeyPrefix = "OfflineScores_Tournament_";

		[Token(Token = "0x4001BCB")]
		private const string OfflineScoresKeyIndex = "OfflineScores_KeyIndex";

		[Token(Token = "0x170003BB")]
		public static TournamentDataStore Instance
		{
			[Token(Token = "0x6002334")]
			[Address(RVA = "0x3DDD15C", Offset = "0x3DDD15C", Length = "0x94")]
			get
			{
				return _instance.Value;
			}
		}

		[Token(Token = "0x6002335")]
		[Address(RVA = "0x4D15394", Offset = "0x4D15394", Length = "0x78")]
		internal static void Save<T>(string saveKey, T data)
		{
			string value = JsonConvert.SerializeObject(data);
			PlayerPrefs.SetString(saveKey, value);
		}

		[Token(Token = "0x6002336")]
		[Address(RVA = "0x4D14EF4", Offset = "0x4D14EF4", Length = "0x1E4")]
		internal static bool Load<T>(string key, out T loadedData)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TournamentDataStore::Load");
			loadedData = default;
			return default;
		}

		[Token(Token = "0x6002337")]
		[Address(RVA = "0x3DDE3A4", Offset = "0x3DDE3A4", Length = "0x90")]
		public void SetTournaments(TournamentsResponse tournamentResponse)
		{
			Save("TournamentResponseStoreKey", tournamentResponse);
		}

		[Token(Token = "0x6002338")]
		[Address(RVA = "0x3DDE434", Offset = "0x3DDE434", Length = "0xA8")]
		public TournamentsResponse GetTournaments()
		{
			if (Load<TournamentsResponse>("TournamentResponseStoreKey", out var loadedData))
			{
				return loadedData;
			}
			return null;
		}

		[Token(Token = "0x6002339")]
		[Address(RVA = "0x3DDE4DC", Offset = "0x3DDE4DC", Length = "0x90")]
		public void SetMyTournamentsResponse(MyTournamentsResponse myTournamentsResponse)
		{
			Save("MyTournamentsResponseKey", myTournamentsResponse);
		}

		[Token(Token = "0x600233A")]
		[Address(RVA = "0x3DDE56C", Offset = "0x3DDE56C", Length = "0xA8")]
		public MyTournamentsResponse GetMyTournamentsResponse()
		{
			if (Load<MyTournamentsResponse>("MyTournamentsResponseKey", out var loadedData))
			{
				return loadedData;
			}
			return null;
		}

		[Token(Token = "0x600233B")]
		[Address(RVA = "0x3DDE614", Offset = "0x3DDE614", Length = "0x90")]
		public void SetMyTournamentResults(MyTournamentResultsResponse data)
		{
			Save("MyTournamentResultsResponseKey", data);
		}

		[Token(Token = "0x600233C")]
		[Address(RVA = "0x3DDE6A4", Offset = "0x3DDE6A4", Length = "0xA8")]
		public MyTournamentResultsResponse GetMyTournamentResults()
		{
			if (Load<MyTournamentResultsResponse>("MyTournamentResultsResponseKey", out var loadedData))
			{
				return loadedData;
			}
			return null;
		}

		[Token(Token = "0x600233D")]
		[Address(RVA = "0x3DDE74C", Offset = "0x3DDE74C", Length = "0x9C")]
		private string PrepareBoardPrefKey(int tournamentId, int scheduleId)
		{
			int num = scheduleId;
			int num2 = tournamentId;
			string text = num2.ToString();
			string text2 = num.ToString();
			return "TournamentBoardResponseKey-" + text + "-" + text2;
		}

		[Token(Token = "0x600233E")]
		[Address(RVA = "0x3DDE7E8", Offset = "0x3DDE7E8", Length = "0x120")]
		public TournamentBoardResponse GetTournamentBoardResponse(int tournamentId, int scheduleId)
		{
			int num = scheduleId;
			int num2 = tournamentId;
			string text = num2.ToString();
			string text2 = num.ToString();
			string key = "TournamentBoardResponseKey-" + text + "-" + text2;
			if (Load<TournamentBoardResponse>(key, out var loadedData))
			{
				return loadedData;
			}
			return null;
		}

		[Token(Token = "0x600233F")]
		[Address(RVA = "0x3DDE244", Offset = "0x3DDE244", Length = "0x114")]
		public void SetTournamentBoardResponse(int tournamentId, int scheduleId, TournamentBoardResponse tournamentBoardResponse)
		{
			int num = scheduleId;
			int num2 = tournamentId;
			string text = num2.ToString();
			string text2 = num.ToString();
			string saveKey = "TournamentBoardResponseKey-" + text + "-" + text2;
			Save(saveKey, tournamentBoardResponse);
		}

		[Token(Token = "0x6002340")]
		[Address(RVA = "0x3DDE908", Offset = "0x3DDE908", Length = "0xD0")]
		internal string GetOfflineScoresKey(int tournamentId, int scheduleId)
		{
			int num = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			object arg2 = default(object);
			string text = string.Format("{0}{1}_{2}", "OfflineScores_Tournament_", arg, arg2);
			AddKeyToIndex(text);
			return text;
		}

		[Token(Token = "0x6002341")]
		[Address(RVA = "0x3DDEB44", Offset = "0x3DDEB44", Length = "0x1B0")]
		public void SaveOfflineScore(int tournamentId, int scheduleId, int score)
		{
			List<OfflineScore> offlineScores = GetOfflineScores(tournamentId, scheduleId);
			OfflineScore offlineScore = new OfflineScore();
			offlineScore.Score = score;
			DateTimeOffset utcNow = DateTimeOffset.UtcNow;
			DateTimeOffset dateTimeOffset = utcNow;
			long timestamp = dateTimeOffset.ToUnixTimeSeconds();
			offlineScore.Timestamp = timestamp;
			offlineScores.Add(offlineScore);
			string offlineScoresKey = GetOfflineScoresKey(tournamentId, scheduleId);
			Save(offlineScoresKey, offlineScores);
		}

		[Token(Token = "0x6002342")]
		[Address(RVA = "0x3DDECF4", Offset = "0x3DDECF4", Length = "0x128")]
		public List<OfflineScore> GetOfflineScores(int tournamentId, int scheduleId)
		{
			int tournamentId2 = default(int);
			int scheduleId2 = default(int);
			string offlineScoresKey = GetOfflineScoresKey(tournamentId2, scheduleId2);
			if (Load<List<OfflineScore>>(offlineScoresKey, out var loadedData))
			{
				return loadedData;
			}
			return new List<OfflineScore>();
		}

		[Token(Token = "0x6002343")]
		[Address(RVA = "0x3DDD1F0", Offset = "0x3DDD1F0", Length = "0x3C")]
		public void DeleteOfflineScores(int tournamentId, int scheduleId)
		{
			string offlineScoresKey = GetOfflineScoresKey(tournamentId, scheduleId);
			PlayerPrefs.DeleteKey(offlineScoresKey);
			RemoveKeyFromIndex(offlineScoresKey);
			PlayerPrefs.Save();
		}

		[Token(Token = "0x6002344")]
		[Address(RVA = "0x3DDEF0C", Offset = "0x3DDEF0C", Length = "0x2D0")]
		public unsafe List<(int, int)> GetAllOfflineScoreTournaments()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TournamentDataStore::GetAllOfflineScoreTournaments");
			return default;
		}

		[Token(Token = "0x6002345")]
		[Address(RVA = "0x3DDF5D4", Offset = "0x3DDF5D4", Length = "0xD0")]
		private string GetStorageKey(int tournamentId, int scheduleId)
		{
			int num = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			object arg2 = default(object);
			string text = string.Format("{0}{1}_{2}", "OfflineScores_Tournament_", arg, arg2);
			AddKeyToIndex(text);
			return text;
		}

		[Token(Token = "0x6002346")]
		[Address(RVA = "0x3DDE9D8", Offset = "0x3DDE9D8", Length = "0x16C")]
		private void AddKeyToIndex(string key)
		{
			List<string> allKeysFromIndex = GetAllKeysFromIndex();
			if (!allKeysFromIndex.Contains(key))
			{
				allKeysFromIndex.Add(key);
				string value = JsonConvert.SerializeObject(allKeysFromIndex);
				PlayerPrefs.SetString("OfflineScores_KeyIndex", value);
				PlayerPrefs.Save();
			}
		}

		[Token(Token = "0x6002347")]
		[Address(RVA = "0x3DDEE24", Offset = "0x3DDEE24", Length = "0xE8")]
		internal void RemoveKeyFromIndex(string key)
		{
			List<string> allKeysFromIndex = GetAllKeysFromIndex();
			if (allKeysFromIndex.Remove(key))
			{
				string value = JsonConvert.SerializeObject(allKeysFromIndex);
				PlayerPrefs.SetString("OfflineScores_KeyIndex", value);
				PlayerPrefs.Save();
			}
		}

		[Token(Token = "0x6002348")]
		[Address(RVA = "0x3DDF1DC", Offset = "0x3DDF1DC", Length = "0x1D4")]
		private List<string> GetAllKeysFromIndex()
		{
			if (PlayerPrefs.HasKey("OfflineScores_KeyIndex"))
			{
				string value = PlayerPrefs.GetString("OfflineScores_KeyIndex");
				List<string> list = JsonConvert.DeserializeObject<List<string>>(value);
				if (list == null)
				{
					list = new List<string>();
				}
				return list;
			}
			return new List<string>();
		}

		[Token(Token = "0x6002349")]
		[Address(RVA = "0x3DDF6A4", Offset = "0x3DDF6A4", Length = "0x90")]
		private void SaveKeyIndex(List<string> keys)
		{
			string value = JsonConvert.SerializeObject(keys);
			PlayerPrefs.SetString("OfflineScores_KeyIndex", value);
			PlayerPrefs.Save();
		}

		[Token(Token = "0x600234A")]
		[Address(RVA = "0x3DDF734", Offset = "0x3DDF734", Length = "0x1D0")]
		public unsafe void CleanupAllOfflineScores()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TournamentDataStore::CleanupAllOfflineScores");
		}

		[Token(Token = "0x600234B")]
		[Address(RVA = "0x3DDF3B0", Offset = "0x3DDF3B0", Length = "0x224")]
		private bool ParseTournamentKey(string key, out int tournamentId, out int scheduleId)
		{
			tournamentId = default(int);
			scheduleId = default(int);
			tournamentId = 0;
			scheduleId = 0;
			NullReferenceException ex2 = default(NullReferenceException);
			if (key != null)
			{
				string text = key.Replace("OfflineScores_Tournament_", "");
				if (text != null)
				{
					string[] array = text.Split('_');
					if (array != null)
					{
						if (array.Length != 2)
						{
							return false;
						}
						int num = int.Parse(array[0]);
						tournamentId = num;
						if ((array.Length & -2) != 0)
						{
							int num2 = int.Parse(array[1]);
							scheduleId = num2;
							return true;
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
					}
					else
					{
						ex2 = new NullReferenceException();
					}
				}
				else
				{
					ex2 = new NullReferenceException();
				}
			}
			else
			{
				ex2 = new NullReferenceException();
			}
			throw ex2;
		}

		[Token(Token = "0x600234C")]
		[Address(RVA = "0x3DDF904", Offset = "0x3DDF904", Length = "0x8")]
		public TournamentDataStore()
		{
		}

		[Token(Token = "0x600234D")]
		[Address(RVA = "0x3DDF90C", Offset = "0x3DDF90C", Length = "0x114")]
		static TournamentDataStore()
		{
			Func<TournamentDataStore> valueFactory = () => new TournamentDataStore();
			Lazy<TournamentDataStore> instance = new Lazy<TournamentDataStore>(valueFactory);
			_instance = instance;
		}
	}
}
