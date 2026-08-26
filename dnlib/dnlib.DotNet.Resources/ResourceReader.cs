using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using dnlib.IO;

namespace dnlib.DotNet.Resources;

public struct ResourceReader
{
	private sealed class ResourceInfo
	{
		public string name;

		public long offset;

		public ResourceInfo(string name, long offset)
		{
			this.name = name;
			this.offset = offset;
		}

		public override string ToString()
		{
			return $"{offset:X8} - {name}";
		}
	}

	private DataReader reader;

	private readonly uint baseFileOffset;

	private readonly ResourceDataFactory resourceDataFactory;

	private readonly CreateResourceDataDelegate createResourceDataDelegate;

	private ResourceReader(ModuleDef module, ref DataReader reader, CreateResourceDataDelegate createResourceDataDelegate)
	{
		this.reader = reader;
		resourceDataFactory = new ResourceDataFactory(module);
		this.createResourceDataDelegate = createResourceDataDelegate;
		baseFileOffset = reader.StartOffset;
	}

	public static bool CouldBeResourcesFile(DataReader reader)
	{
		return reader.CanRead(4u) && reader.ReadUInt32() == 3203386062u;
	}

	public static ResourceElementSet Read(ModuleDef module, DataReader reader)
	{
		return Read(module, reader, null);
	}

	public static ResourceElementSet Read(ModuleDef module, DataReader reader, CreateResourceDataDelegate createResourceDataDelegate)
	{
		return new ResourceReader(module, ref reader, createResourceDataDelegate).Read();
	}

	private ResourceElementSet Read()
	{
		ResourceElementSet resourceElementSet = new ResourceElementSet();
		uint num = reader.ReadUInt32();
		if (num != 3203386062u)
		{
			throw new ResourceReaderException($"Invalid resource sig: {num:X8}");
		}
		if (!CheckReaders())
		{
			throw new ResourceReaderException("Invalid resource reader");
		}
		int num2 = reader.ReadInt32();
		if (num2 != 2)
		{
			throw new ResourceReaderException($"Invalid resource version: {num2}");
		}
		int num3 = reader.ReadInt32();
		if (num3 < 0)
		{
			throw new ResourceReaderException($"Invalid number of resources: {num3}");
		}
		int num4 = reader.ReadInt32();
		if (num4 < 0)
		{
			throw new ResourceReaderException($"Invalid number of user types: {num4}");
		}
		List<UserResourceType> list = new List<UserResourceType>();
		for (int i = 0; i < num4; i++)
		{
			list.Add(new UserResourceType(reader.ReadSerializedString(), (ResourceTypeCode)(64 + i)));
		}
		reader.Position = (reader.Position + 7) & 0xFFFFFFF8u;
		int[] array = new int[num3];
		for (int j = 0; j < num3; j++)
		{
			array[j] = reader.ReadInt32();
		}
		int[] array2 = new int[num3];
		for (int k = 0; k < num3; k++)
		{
			array2[k] = reader.ReadInt32();
		}
		long num5 = reader.Position;
		long num6 = reader.ReadInt32();
		long num7 = reader.Position;
		long num8 = reader.Length;
		List<ResourceInfo> list2 = new List<ResourceInfo>(num3);
		for (int l = 0; l < num3; l++)
		{
			reader.Position = (uint)(num7 + array2[l]);
			string name = reader.ReadSerializedString(Encoding.Unicode);
			long offset = num6 + reader.ReadInt32();
			list2.Add(new ResourceInfo(name, offset));
		}
		list2.Sort((ResourceInfo a, ResourceInfo b) => a.offset.CompareTo(b.offset));
		for (int num9 = 0; num9 < list2.Count; num9++)
		{
			ResourceInfo resourceInfo = list2[num9];
			ResourceElement resourceElement = new ResourceElement();
			resourceElement.Name = resourceInfo.name;
			reader.Position = (uint)resourceInfo.offset;
			long num10 = ((num9 == list2.Count - 1) ? num8 : list2[num9 + 1].offset);
			int size = (int)(num10 - resourceInfo.offset);
			resourceElement.ResourceData = ReadResourceData(list, size);
			resourceElement.ResourceData.StartOffset = (FileOffset)(baseFileOffset + (uint)(int)resourceInfo.offset);
			resourceElement.ResourceData.EndOffset = (FileOffset)(baseFileOffset + reader.Position);
			resourceElementSet.Add(resourceElement);
		}
		return resourceElementSet;
	}

	private IResourceData ReadResourceData(List<UserResourceType> userTypes, int size)
	{
		uint num = reader.Position + (uint)size;
		uint num2 = ReadUInt32(ref reader);
		switch ((ResourceTypeCode)num2)
		{
		case ResourceTypeCode.Null:
			return resourceDataFactory.CreateNull();
		case ResourceTypeCode.String:
			return resourceDataFactory.Create(reader.ReadSerializedString());
		case ResourceTypeCode.Boolean:
			return resourceDataFactory.Create(reader.ReadBoolean());
		case ResourceTypeCode.Char:
			return resourceDataFactory.Create(reader.ReadChar());
		case ResourceTypeCode.Byte:
			return resourceDataFactory.Create(reader.ReadByte());
		case ResourceTypeCode.SByte:
			return resourceDataFactory.Create(reader.ReadSByte());
		case ResourceTypeCode.Int16:
			return resourceDataFactory.Create(reader.ReadInt16());
		case ResourceTypeCode.UInt16:
			return resourceDataFactory.Create(reader.ReadUInt16());
		case ResourceTypeCode.Int32:
			return resourceDataFactory.Create(reader.ReadInt32());
		case ResourceTypeCode.UInt32:
			return resourceDataFactory.Create(reader.ReadUInt32());
		case ResourceTypeCode.Int64:
			return resourceDataFactory.Create(reader.ReadInt64());
		case ResourceTypeCode.UInt64:
			return resourceDataFactory.Create(reader.ReadUInt64());
		case ResourceTypeCode.Single:
			return resourceDataFactory.Create(reader.ReadSingle());
		case ResourceTypeCode.Double:
			return resourceDataFactory.Create(reader.ReadDouble());
		case ResourceTypeCode.Decimal:
			return resourceDataFactory.Create(reader.ReadDecimal());
		case ResourceTypeCode.DateTime:
			return resourceDataFactory.Create(DateTime.FromBinary(reader.ReadInt64()));
		case ResourceTypeCode.TimeSpan:
			return resourceDataFactory.Create(new TimeSpan(reader.ReadInt64()));
		case ResourceTypeCode.ByteArray:
			return resourceDataFactory.Create(reader.ReadBytes(reader.ReadInt32()));
		case ResourceTypeCode.Stream:
			return resourceDataFactory.CreateStream(reader.ReadBytes(reader.ReadInt32()));
		default:
		{
			int num3 = (int)(num2 - 64);
			if (num3 < 0 || num3 >= userTypes.Count)
			{
				throw new ResourceReaderException($"Invalid resource data code: {num2}");
			}
			UserResourceType type = userTypes[num3];
			byte[] array = reader.ReadBytes((int)(num - reader.Position));
			if (createResourceDataDelegate != null)
			{
				IResourceData resourceData = createResourceDataDelegate(resourceDataFactory, type, array);
				if (resourceData != null)
				{
					return resourceData;
				}
			}
			return resourceDataFactory.CreateSerialized(array, type);
		}
		}
	}

	private static uint ReadUInt32(ref DataReader reader)
	{
		try
		{
			return reader.Read7BitEncodedUInt32();
		}
		catch
		{
			throw new ResourceReaderException("Invalid encoded int32");
		}
	}

	private bool CheckReaders()
	{
		bool result = false;
		int num = reader.ReadInt32();
		if (num < 0)
		{
			throw new ResourceReaderException($"Invalid number of readers: {num}");
		}
		int num2 = reader.ReadInt32();
		if (num2 < 0)
		{
			throw new ResourceReaderException($"Invalid readers size: {num2:X8}");
		}
		for (int i = 0; i < num; i++)
		{
			string input = reader.ReadSerializedString();
			reader.ReadSerializedString();
			if (Regex.IsMatch(input, "^System\\.Resources\\.ResourceReader,\\s*mscorlib,"))
			{
				result = true;
			}
		}
		return result;
	}
}
