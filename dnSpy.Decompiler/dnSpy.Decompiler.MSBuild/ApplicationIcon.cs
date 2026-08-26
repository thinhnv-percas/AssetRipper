#define DEBUG
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using dnlib.IO;
using dnlib.W32Resources;
using dnSpy.Decompiler.Properties;

namespace dnSpy.Decompiler.MSBuild;

internal sealed class ApplicationIcon : IFileJob, IJob
{
	private sealed class GrpIconDirEntry
	{
		public byte bWidth;

		public byte bHeight;

		public byte bColorCount;

		public byte bReserved;

		public ushort wPlanes;

		public ushort wBitCount;

		public uint dwBytesInRes;

		public ushort nID;
	}

	private const int RT_ICON = 3;

	private const int RT_GROUP_ICON = 14;

	private readonly byte[] data;

	public string Description => dnSpy_Decompiler_Resources.MSBuild_CreateApplicationIcon;

	public string Filename { get; }

	private ApplicationIcon(string filename, byte[] data)
	{
		Filename = filename;
		this.data = data;
	}

	public static ApplicationIcon TryCreate(Win32Resources resources, string filenameNoExt, FilenameCreator filenameCreator)
	{
		if (resources == null)
		{
			return null;
		}
		ResourceDirectory resourceDirectory = resources.Find(new ResourceName(14));
		if (resourceDirectory == null || resourceDirectory.Directories.Count == 0)
		{
			return null;
		}
		resourceDirectory = resourceDirectory.Directories[0];
		if (resourceDirectory.Data.Count == 0)
		{
			return null;
		}
		ResourceDirectory resourceDirectory2 = resources.Find(new ResourceName(3));
		if (resourceDirectory2 == null)
		{
			return null;
		}
		DataReader reader = resourceDirectory.Data[0].CreateReader();
		byte[] array = TryCreateIcon(ref reader, resourceDirectory2);
		if (array == null)
		{
			return null;
		}
		return new ApplicationIcon(filenameCreator.CreateName(filenameNoExt + ".ico"), array);
	}

	private static byte[] TryCreateIcon(ref DataReader reader, ResourceDirectory iconDir)
	{
		try
		{
			reader.Position = 0u;
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(reader.ReadUInt16());
			binaryWriter.Write(reader.ReadUInt16());
			ushort num;
			binaryWriter.Write(num = reader.ReadUInt16());
			List<GrpIconDirEntry> list = new List<GrpIconDirEntry>();
			for (int i = 0; i < num; i++)
			{
				GrpIconDirEntry grpIconDirEntry = new GrpIconDirEntry();
				list.Add(grpIconDirEntry);
				grpIconDirEntry.bWidth = reader.ReadByte();
				grpIconDirEntry.bHeight = reader.ReadByte();
				grpIconDirEntry.bColorCount = reader.ReadByte();
				grpIconDirEntry.bReserved = reader.ReadByte();
				grpIconDirEntry.wPlanes = reader.ReadUInt16();
				grpIconDirEntry.wBitCount = reader.ReadUInt16();
				grpIconDirEntry.dwBytesInRes = reader.ReadUInt32();
				grpIconDirEntry.nID = reader.ReadUInt16();
			}
			uint num2 = (uint)(6 + list.Count * 16);
			foreach (GrpIconDirEntry item in list)
			{
				binaryWriter.Write(item.bWidth);
				binaryWriter.Write(item.bHeight);
				binaryWriter.Write(item.bColorCount);
				binaryWriter.Write(item.bReserved);
				binaryWriter.Write(item.wPlanes);
				binaryWriter.Write(item.wBitCount);
				binaryWriter.Write(item.dwBytesInRes);
				binaryWriter.Write(num2);
				num2 += item.dwBytesInRes;
			}
			foreach (GrpIconDirEntry e in list)
			{
				ResourceDirectory resourceDirectory = iconDir.Directories.FirstOrDefault((ResourceDirectory a) => a.Name == new ResourceName(e.nID));
				if (resourceDirectory == null || resourceDirectory.Data.Count == 0)
				{
					return null;
				}
				DataReader dataReader = resourceDirectory.Data[0].CreateReader();
				Debug.Assert(dataReader.Length == e.dwBytesInRes);
				if (dataReader.Length < e.dwBytesInRes)
				{
					return null;
				}
				binaryWriter.Write(dataReader.ReadBytes((int)e.dwBytesInRes), 0, (int)e.dwBytesInRes);
			}
			return memoryStream.ToArray();
		}
		catch (IOException)
		{
		}
		return null;
	}

	public void Create(DecompileContext ctx)
	{
		using FileStream fileStream = File.Create(Filename);
		fileStream.Write(data, 0, data.Length);
	}
}
