internal class LicNameManagerGlobal
{
	[FunAttr(Num = "4FA8F0BC897ED93F74AEE5B473A42194")]
	public static string GetLicName()
	{
		(string, string)[] array = new(string, string)[6]
		{
			("1256295088", "UnpackerEditorStudioLIC"),
			("3494623331", "UnpackerStudioLIC"),
			("2054242326", "RePackerToolsLIC"),
			("1996428747", "UnpackerToolsLIC"),
			("457736779", "AndroidUnpackerLIC"),
			("3122060381", "GameModdingLIC")
		};
		foreach ((string, string) valueTuple in array)
		{
			if (HiddenCalls.Call2(valueTuple.Item1))
			{
				return valueTuple.Item2;
			}
		}
		return "UnpackerFreeLIC";
	}
}
