using System;
using System.Linq;
using Cpp2ILInjected;
using Newtonsoft.Json;
using Unco.RemoteManagementSystem;

namespace _game.CoreSystem.LevelCreator
{
	[Token(Token = "0x20004BC")]
	public class LevelCreatorDataProvider : ILevelCreatorDataProvider
	{
		[Token(Token = "0x4000FE4")]
		[FieldOffset(Offset = "0x10")]
		private readonly RemoteConfigManager _remoteConfig;

		[Token(Token = "0x4000FE5")]
		[FieldOffset(Offset = "0x18")]
		private LevelCreatorDataList _cachedList;

		[Token(Token = "0x60013E9")]
		[Address(RVA = "0x3CEFEF4", Offset = "0x3CEFEF4", Length = "0x34")]
		public LevelCreatorDataProvider(RemoteConfigManager remoteConfig)
		{
			_remoteConfig = remoteConfig;
		}

		[Token(Token = "0x60013EA")]
		[Address(RVA = "0x3CEFF28", Offset = "0x3CEFF28", Length = "0x1BC")]
		public LevelCreatorData GetLevelData(string levelId)
		{
			LevelCreatorDataList cachedList = _cachedList;
			if (_cachedList == null)
			{
				string value = _remoteConfig.GetString(RemoteKey.level_creator_data);
				LevelCreatorDataList cachedList2 = JsonConvert.DeserializeObject<LevelCreatorDataList>(value, LevelCreatorJsonSettings.Settings);
				_cachedList = cachedList2;
				cachedList = _cachedList;
				if (_cachedList == null)
				{
					goto IL_00f3;
				}
			}
			if (cachedList.levels != null)
			{
				Func<LevelCreatorData, bool> predicate = (LevelCreatorData l) => l.levelId == levelId;
				return (LevelCreatorData)cachedList.levels.FirstOrDefault((Func<object, bool>)predicate);
			}
			goto IL_00f3;
			IL_00f3:
			return null;
		}
	}
}
