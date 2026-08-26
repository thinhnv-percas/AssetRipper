using System.IO;
using System.IO.Compression;

namespace HelixToolkit.Wpf;

public class GZipHelper
{
	public static void Compress(string source)
	{
		string extension = Path.GetExtension(source);
		byte[] array;
		using (FileStream fileStream = File.OpenRead(source))
		{
			array = new byte[fileStream.Length];
			fileStream.Read(array, 0, array.Length);
		}
		string path = Path.ChangeExtension(source, extension + "z");
		using FileStream stream = File.OpenWrite(path);
		GZipStream gZipStream = new GZipStream(stream, CompressionMode.Compress);
		gZipStream.Write(array, 0, array.Length);
	}
}
