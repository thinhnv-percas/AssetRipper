using MiniJSON;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

public class CrackSettings
{
	public static bool AllowActivation;

	public static bool AllowDemoAssetRead;

	public static bool DisableDevXCheck;

	public static bool ForceDllLoad;

	public static bool AllowFakeDeviceInfo;

	public static string FakeUserName;

	public static string FakeMachineName;

	public static bool AllowOffline;

	public static bool DisableFolderOpen;

	public static bool AutoScene;

	static CrackSettings()
	{
		AllowActivation = true;
		AllowDemoAssetRead = true;
		DisableDevXCheck = false;
		ForceDllLoad = true;
		AllowFakeDeviceInfo = false;
		FakeUserName = "";
		FakeMachineName = "";
		AllowOffline = true;
		DisableFolderOpen = false;
		AutoScene = true;
	}

	public static void Save()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		FieldInfo[] fields = typeof(CrackSettings).GetFields();
		foreach (FieldInfo fieldInfo in fields)
		{
			if (fieldInfo.IsStatic)
			{
				dictionary[fieldInfo.Name] = fieldInfo.GetValue(null);
			}
		}
		File.WriteAllText(Path.Combine(Application.StartupPath, "CrackSettings.json"), Json.Serialize(dictionary));
	}

	public static void Load()
	{
		string text = Path.Combine(Application.StartupPath, "CrackSettings.json");
		if (FileManager.Exists(text))
		{
			Dictionary<string, object> dictionary = Json.Deserialize(File.ReadAllText(text)) as Dictionary<string, object>;
			if (dictionary != null && dictionary.Count != 0)
			{
				foreach (KeyValuePair<string, object> item in dictionary)
				{
					FieldInfo field = typeof(CrackSettings).GetField(item.Key);
					if (field != null)
					{
						field.SetValue(null, item.Value);
					}
				}
				return;
			}
		}
		MessageBox.Show("Json parse error. Will be used default settings.", "Crack msg");
	}
}
