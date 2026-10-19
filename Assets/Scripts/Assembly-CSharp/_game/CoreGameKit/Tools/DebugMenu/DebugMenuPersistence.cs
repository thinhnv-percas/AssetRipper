using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.Tools.DebugMenu
{
	[Token(Token = "0x20005B2")]
	public static class DebugMenuPersistence
	{
		[Token(Token = "0x4001396")]
		private const string k_KeyPrefix = "DebugMenu.";

		[Token(Token = "0x6001854")]
		[Address(RVA = "0x488AA9C", Offset = "0x488AA9C", Length = "0x1C4")]
		public static T Load<T>(string moduleId, T fallback) where T : class
		{
			//IL_0082: Expected O, but got I
			//IL_0092: Expected O, but got I
			string key = "DebugMenu." + moduleId;
			bool flag = PlayerPrefs.HasKey(key);
			bool flag2 = !flag;
			T result = fallback;
			if (!flag2)
			{
				int num = 192761856 + 1336;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ X8_v7 (System.Int32)+90]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X8_v8+B8]");
				object defaultValue = 0;
				string text = PlayerPrefs.GetString(key, (string)defaultValue);
				bool flag3 = string.IsNullOrEmpty(text);
				bool flag4 = !flag3;
				bool flag5 = !flag4;
				result = fallback;
				if (!flag5)
				{
					T val = JsonUtility.FromJson<T>(text);
					result = ((val != null) ? val : fallback);
				}
			}
			return result;
		}

		[Token(Token = "0x6001855")]
		[Address(RVA = "0x488AC60", Offset = "0x488AC60", Length = "0x188")]
		public static void Save<T>(string moduleId, T data)
		{
			if (data != null)
			{
				string key = "DebugMenu." + moduleId;
				string value = JsonUtility.ToJson(data);
				PlayerPrefs.SetString(key, value);
				PlayerPrefs.Save();
			}
		}

		[Token(Token = "0x6001856")]
		[Address(RVA = "0x3D37A78", Offset = "0x3D37A78", Length = "0x68")]
		public static void Clear(string moduleId)
		{
			string key = "DebugMenu." + moduleId;
			PlayerPrefs.DeleteKey(key);
			PlayerPrefs.Save();
		}
	}
}
