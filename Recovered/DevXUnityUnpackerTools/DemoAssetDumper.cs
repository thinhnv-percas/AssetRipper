using @as;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

public class DemoAssetDumper
{
	private static Dictionary<string, StrSthData> dictData;

	public static Dictionary<string, StrSthData> GetData()
	{
		if (dictData == null)
		{
			dictData = new Dictionary<string, StrSthData>();
			MessageBox.Show("Loading data for assets loading...\nThe program freezes during this loading.\nPlease wait.", "Crack msg");
			string[] array = new string[2]
			{
				"ClassAll.zip",
				"UnityType.zip"
			};
			foreach (string text in array)
			{
				try
				{
					foreach (var item in ZipManager.ParseZip(new MemoryStream(File.ReadAllBytes(Path.Combine(DevXSystemInfo.StreamingAssets, text)))))
					{
						if (item.Name.EndsWith(".xml"))
						{
							dictData[text + "\\" + item.Name] = new StrSthData(item.Content);
						}
					}
				}
				catch (Exception)
				{
				}
			}
			MessageBox.Show("Data loaded!", "Crack msg");
		}
		return dictData;
	}
}
