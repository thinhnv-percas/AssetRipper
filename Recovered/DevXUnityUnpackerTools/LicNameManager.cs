internal class LicNameManager
{
	[FunAttr(Num = "64021F247D030CCF3D9611CB7BB5B855")]
	public static string GetLicName()
	{
		string text = HiddenCalls.CallString("2495301777");
		if (text != null)
		{
			return text;
		}
		return "UnpackerFree";
	}
}
