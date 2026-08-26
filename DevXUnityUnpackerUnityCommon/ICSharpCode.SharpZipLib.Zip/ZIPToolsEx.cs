using System.Collections.Generic;
using System.IO;

namespace ICSharpCode.SharpZipLib.Zip;

public class ZIPToolsEx
{
	internal static void ExtractZipFile(string archiveFilenameIn, string password, string outFolder)
	{
		ZipFile zipFile = null;
		try
		{
			zipFile = new ZipFile(File.OpenRead(archiveFilenameIn));
			if (!string.IsNullOrEmpty(password))
			{
				zipFile.Password = password;
			}
			foreach (ZipEntry item in zipFile)
			{
				if (item.IsFile)
				{
					string name = item.Name;
					byte[] buffer = new byte[4096];
					Stream inputStream = zipFile.GetInputStream(item);
					string path = Path.Combine(outFolder, name);
					string directoryName = Path.GetDirectoryName(path);
					if (directoryName.Length > 0)
					{
						Directory.CreateDirectory(directoryName);
					}
					using FileStream out_stream = File.Create(path);
					Copy(inputStream, out_stream, buffer);
				}
			}
		}
		finally
		{
			if (zipFile != null)
			{
				zipFile.IsStreamOwner = true;
				zipFile.Close();
			}
		}
	}

	internal static void CompressFolder(string folderName, string outPathname, string offset_path = null)
	{
		FileStream fileStream = File.Create(outPathname);
		ZipOutputStream zipOutputStream = new ZipOutputStream(fileStream);
		zipOutputStream.SetLevel(3);
		int folderOffset = (offset_path ?? folderName).Length + ((!(offset_path ?? folderName).EndsWith("\\")) ? 1 : 0);
		CompressFolder(folderName, zipOutputStream, folderOffset);
		zipOutputStream.IsStreamOwner = true;
		zipOutputStream.Flush();
		zipOutputStream.Close();
		fileStream.Close();
	}

	internal static void CompressFolder(string path, ZipOutputStream zipStream, int folderOffset)
	{
		string[] files = Directory.GetFiles(path);
		foreach (string obj in files)
		{
			FileInfo fileInfo = new FileInfo(obj);
			zipStream.PutNextEntry(new ZipEntry(ZipEntry.CleanName(obj.Substring(folderOffset)))
			{
				DateTime = fileInfo.LastWriteTime,
				Size = fileInfo.Length
			});
			byte[] buffer = new byte[4096];
			using (FileStream input_stream = File.Open(obj, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			{
				Copy(input_stream, zipStream, buffer);
			}
			zipStream.CloseEntry();
		}
		files = Directory.GetDirectories(path);
		for (int i = 0; i < files.Length; i++)
		{
			CompressFolder(files[i], zipStream, folderOffset);
		}
	}

	internal static void Copy(Stream input_stream, Stream out_stream, byte[] buffer)
	{
		int num;
		do
		{
			num = input_stream.Read(buffer, 0, buffer.Length);
			out_stream.Write(buffer, 0, num);
		}
		while (num > 0);
	}

	internal static List<string> ExtractFileNames(Stream stream, string password = null)
	{
		List<string> list = new List<string>();
		using ZipInputStream zipInputStream = new ZipInputStream(stream);
		if (!string.IsNullOrEmpty(password))
		{
			zipInputStream.Password = password;
		}
		while (true)
		{
			ZipEntry nextEntry = zipInputStream.GetNextEntry();
			if (nextEntry == null)
			{
				break;
			}
			if (!nextEntry.IsDirectory)
			{
				list.Add(nextEntry.Name);
			}
		}
		return list;
	}

	internal static MemoryStream ExtractMem(ZipEntry file_entry, string archive_file)
	{
		using Stream zip_stream = File.OpenRead(archive_file);
		return ExtractMem(file_entry, zip_stream);
	}

	internal static MemoryStream ExtractMem(ZipEntry file_entry, Stream zip_stream, string password = null)
	{
		new List<ZipEntry>();
		using (ZipInputStream zipInputStream = new ZipInputStream(zip_stream))
		{
			if (!string.IsNullOrEmpty(password))
			{
				zipInputStream.Password = password;
			}
			int num = 0;
			while (true)
			{
				ZipEntry nextEntry = zipInputStream.GetNextEntry();
				if (nextEntry == null)
				{
					break;
				}
				if (!nextEntry.IsDirectory && nextEntry.Name == file_entry.Name)
				{
					long size = nextEntry.Size;
					size = ((size < 10240) ? size : 10240);
					if (size <= 0)
					{
						size = 1024L;
					}
					byte[] buffer = new byte[size];
					int num2 = zipInputStream.Read(buffer, 0, (int)size);
					MemoryStream memoryStream = new MemoryStream();
					num++;
					while (num2 > 0)
					{
						memoryStream.Write(buffer, 0, num2);
						num2 = zipInputStream.Read(buffer, 0, (int)size);
					}
					return memoryStream;
				}
			}
		}
		return null;
	}

	internal static bool ExtractFiles(List<ZipEntry> file_entrys, string archive_file, string out_dir)
	{
		using Stream stream = File.OpenRead(archive_file);
		return ExtractFiles(file_entrys, stream, out_dir);
	}

	internal static bool ExtractFiles(List<ZipEntry> file_entrys, Stream stream, string out_dir, string password = null)
	{
		new List<ZipEntry>();
		using (ZipInputStream zipInputStream = new ZipInputStream(stream))
		{
			if (!string.IsNullOrEmpty(password))
			{
				zipInputStream.Password = password;
			}
			int num = 0;
			while (true)
			{
				ZipEntry nextEntry = zipInputStream.GetNextEntry();
				if (nextEntry == null)
				{
					break;
				}
				if (nextEntry.IsDirectory)
				{
					continue;
				}
				foreach (ZipEntry file_entry in file_entrys)
				{
					if (!(nextEntry.Name == file_entry.Name))
					{
						continue;
					}
					long size = nextEntry.Size;
					size = ((size < 10240) ? size : 10240);
					if (size <= 0)
					{
						size = 1024L;
					}
					byte[] buffer = new byte[size];
					int num2 = zipInputStream.Read(buffer, 0, (int)size);
					string path = Path.Combine(out_dir, file_entry.Name);
					if (!Directory.Exists(Path.GetDirectoryName(path)))
					{
						Directory.CreateDirectory(Path.GetDirectoryName(path));
					}
					using (FileStream fileStream = File.Create(Path.Combine(out_dir, file_entry.Name)))
					{
						num++;
						while (num2 > 0)
						{
							fileStream.Write(buffer, 0, num2);
							num2 = zipInputStream.Read(buffer, 0, (int)size);
						}
					}
					break;
				}
			}
		}
		return false;
	}
}
