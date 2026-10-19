using Cpp2ILInjected;
using Newtonsoft.Json;
using UnityEngine;

namespace _game.Systems.ElephantStorage
{
	[Token(Token = "0x2000788")]
	public class PlayerPrefDataHandler : IPlayerDataHandler
	{
		[Token(Token = "0x400190D")]
		private const string KEY = "game_storage_fallback";

		[Token(Token = "0x400190E")]
		[FieldOffset(Offset = "0x10")]
		private GameStorage _storage;

		[Token(Token = "0x6001FD2")]
		[Address(RVA = "0x3D942D4", Offset = "0x3D942D4", Length = "0x1CC")]
		public void Load(GameStorage storage)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PlayerPrefDataHandler::Load");
		}

		[Token(Token = "0x6001FD3")]
		[Address(RVA = "0x3D944A0", Offset = "0x3D944A0", Length = "0x9C")]
		public void Save()
		{
			if (_storage != null)
			{
				string value = JsonConvert.SerializeObject(_storage);
				PlayerPrefs.SetString("game_storage_fallback", value);
				PlayerPrefs.Save();
			}
		}

		[Token(Token = "0x6001FD4")]
		[Address(RVA = "0x3D9453C", Offset = "0x3D9453C", Length = "0x8")]
		public PlayerPrefDataHandler()
		{
		}
	}
}
