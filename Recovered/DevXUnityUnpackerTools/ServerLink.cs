public class ServerLink
{
	internal static string link = "https://devxdevelopment.com";

	[FunAttr(Num = "CE0D0D8A764274F5235E345C3651782D")]
	public static string GetLink()
	{
		return link;
	}

	[FunAttr(Num = "60F56289E1A4EA7A363989DB48984039")]
	public static void SetLink(string s)
	{
		link = s;
	}
}
