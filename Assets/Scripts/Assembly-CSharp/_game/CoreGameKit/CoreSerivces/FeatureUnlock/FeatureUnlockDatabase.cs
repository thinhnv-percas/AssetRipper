using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.CoreSerivces.FeatureUnlock
{
	[Token(Token = "0x2000613")]
	public class FeatureUnlockDatabase : ScriptableObject
	{
		[Token(Token = "0x40014F8")]
		[FieldOffset(Offset = "0x18")]
		public FeatureUnlockData[] FeatureUnlocks;

		[Token(Token = "0x6001A13")]
		[Address(RVA = "0x3D50018", Offset = "0x3D50018", Length = "0xF4")]
		public FeatureUnlockData GetFeatureUnlockData(string levelUnlockedFeatureId)
		{
			FeatureUnlockData[] featureUnlocks = FeatureUnlocks;
			if (featureUnlocks.Length < 1)
			{
				goto IL_00ad;
			}
			int num = 0;
			FeatureUnlockData result;
			while (true)
			{
				FeatureUnlockData featureUnlockData = featureUnlocks[num];
				bool flag = featureUnlockData.featureId == levelUnlockedFeatureId;
				bool flag2 = !flag;
				bool flag3 = !flag2;
				result = featureUnlocks[num];
				if (flag3)
				{
					break;
				}
				num++;
				if (num < featureUnlocks.Length)
				{
					continue;
				}
				goto IL_00ad;
			}
			goto IL_00d3;
			IL_00d3:
			return result;
			IL_00ad:
			string message = "FeatureUnlockDatabase: No feature unlock data found for feature ID " + levelUnlockedFeatureId;
			Debug.LogError(message);
			result = null;
			goto IL_00d3;
		}

		[Token(Token = "0x6001A14")]
		[Address(RVA = "0x3D5010C", Offset = "0x3D5010C", Length = "0x8")]
		public FeatureUnlockDatabase()
		{
		}
	}
}
