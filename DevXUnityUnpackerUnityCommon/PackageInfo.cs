using ICSharpCode.SharpZipLib.Zip;

public class PackageInfo
{
	public static string Version => "10.06";

	public static void CompressFolder(string folderName, string outPathname, string offtet_path = null)
	{
		ZIPToolsEx.CompressFolder(folderName, outPathname, offtet_path);
	}
}
