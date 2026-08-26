#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace DecompTools.Decompiler.Util;

public class ResourcesFile : IEnumerable<KeyValuePair<string, object>>, IEnumerable, IDisposable
{
	private sealed class MyBinaryReader : BinaryReader
	{
		public MyBinaryReader(Stream input, bool leaveOpen)
			: base(input, Encoding.UTF8, leaveOpen)
		{
		}

		public new int Read7BitEncodedInt()
		{
			return base.Read7BitEncodedInt();
		}

		public void Seek(long pos, SeekOrigin origin)
		{
			BaseStream.Seek(pos, origin);
		}
	}

	private enum ResourceTypeCode
	{
		Null = 0,
		String = 1,
		Boolean = 2,
		Char = 3,
		Byte = 4,
		SByte = 5,
		Int16 = 6,
		UInt16 = 7,
		Int32 = 8,
		UInt32 = 9,
		Int64 = 10,
		UInt64 = 11,
		Single = 12,
		Double = 13,
		Decimal = 14,
		DateTime = 15,
		TimeSpan = 16,
		LastPrimitive = TimeSpan,
		ByteArray = 32,
		Stream = 33,
		StartOfUserTypes = 64
	}

	public const int MagicNumber = -1091581234;

	private const int ResourceSetVersion = 2;

	private readonly MyBinaryReader reader;

	private readonly int version;

	private readonly int numResources;

	private readonly string[] typeTable;

	private readonly int[] namePositions;

	private readonly long fileStartPosition;

	private readonly long nameSectionPosition;

	private readonly long dataSectionPosition;

	private long[] startPositions;

	public int ResourceCount => numResources;

	public ResourcesFile(Stream stream, bool leaveOpen = true)
	{
		fileStartPosition = stream.Position;
		reader = new MyBinaryReader(stream, leaveOpen);
		int num = reader.ReadInt32();
		if (num != -1091581234)
		{
			throw new BadImageFormatException("Not a .resources file - invalid magic number");
		}
		int num2 = reader.ReadInt32();
		int num3 = reader.ReadInt32();
		if (num3 < 0 || num2 < 0)
		{
			throw new BadImageFormatException("Resources header corrupted.");
		}
		if (num2 > 1)
		{
			reader.BaseStream.Seek(num3, SeekOrigin.Current);
		}
		else
		{
			reader.ReadString();
			reader.ReadString();
		}
		version = reader.ReadInt32();
		if (version != 2 && version != 1)
		{
			throw new BadImageFormatException($"Unsupported resource set version: {version}");
		}
		numResources = reader.ReadInt32();
		if (numResources < 0)
		{
			throw new BadImageFormatException("Resources header corrupted.");
		}
		int num4 = reader.ReadInt32();
		if (num4 < 0)
		{
			throw new BadImageFormatException("Resources header corrupted.");
		}
		typeTable = new string[num4];
		checked
		{
			for (int i = 0; i < num4; i++)
			{
				typeTable[i] = reader.ReadString();
			}
			long num5 = reader.BaseStream.Position - fileStartPosition;
			int num6 = unchecked((int)num5) & 7;
			if (num6 != 0)
			{
				for (int j = 0; j < 8 - num6; j++)
				{
					reader.ReadByte();
				}
			}
			try
			{
				reader.Seek(4 * numResources, SeekOrigin.Current);
			}
			catch (OverflowException)
			{
				throw new BadImageFormatException("Resources header corrupted.");
			}
			namePositions = new int[numResources];
			for (int k = 0; k < numResources; k++)
			{
				int num7 = reader.ReadInt32();
				if (num7 < 0)
				{
					throw new BadImageFormatException("Resources header corrupted.");
				}
				namePositions[k] = num7;
			}
			int num8 = reader.ReadInt32();
			if (num8 < 0)
			{
				throw new BadImageFormatException("Resources header corrupted.");
			}
			nameSectionPosition = reader.BaseStream.Position;
			dataSectionPosition = fileStartPosition + num8;
			if (dataSectionPosition < nameSectionPosition)
			{
				throw new BadImageFormatException("Resources header corrupted.");
			}
		}
	}

	public void Dispose()
	{
		reader.Dispose();
	}

	public string GetResourceName(int index)
	{
		int dataOffset;
		return GetResourceName(index, out dataOffset);
	}

	private int GetResourceDataOffset(int index)
	{
		GetResourceName(index, out var dataOffset);
		return dataOffset;
	}

	private string GetResourceName(int index, out int dataOffset)
	{
		checked
		{
			long pos = nameSectionPosition + namePositions[index];
			byte[] array;
			lock (reader)
			{
				reader.Seek(pos, SeekOrigin.Begin);
				int num = reader.Read7BitEncodedInt();
				if (num < 0)
				{
					throw new BadImageFormatException("Resource name has negative length");
				}
				array = new byte[num];
				int num2 = num;
				while (num2 > 0)
				{
					int num3 = reader.Read(array, num - num2, num2);
					if (num3 == 0)
					{
						throw new BadImageFormatException("End of stream within a resource name");
					}
					num2 -= num3;
				}
				dataOffset = reader.ReadInt32();
				if (dataOffset < 0)
				{
					throw new BadImageFormatException("Negative data offset");
				}
			}
			return Encoding.Unicode.GetString(array);
		}
	}

	internal bool AllEntriesAreStreams()
	{
		if (version != 2)
		{
			return false;
		}
		lock (reader)
		{
			for (int i = 0; i < numResources; i = checked(i + 1))
			{
				int resourceDataOffset = GetResourceDataOffset(i);
				reader.Seek(checked(dataSectionPosition + resourceDataOffset), SeekOrigin.Begin);
				ResourceTypeCode resourceTypeCode = (ResourceTypeCode)reader.Read7BitEncodedInt();
				if (resourceTypeCode != ResourceTypeCode.Stream)
				{
					return false;
				}
			}
		}
		return true;
	}

	private object LoadObject(int dataOffset)
	{
		try
		{
			lock (reader)
			{
				if (version == 1)
				{
					return LoadObjectV1(dataOffset);
				}
				return LoadObjectV2(dataOffset);
			}
		}
		catch (EndOfStreamException inner)
		{
			throw new BadImageFormatException("Invalid resource file", inner);
		}
	}

	private string FindType(int typeIndex)
	{
		if (typeIndex < 0 || typeIndex >= typeTable.Length)
		{
			throw new BadImageFormatException("Type index out of bounds");
		}
		return typeTable[typeIndex];
	}

	private object LoadObjectV1(int dataOffset)
	{
		Debug.Assert(Monitor.IsEntered(reader));
		checked
		{
			reader.Seek(dataSectionPosition + dataOffset, SeekOrigin.Begin);
			int num = reader.Read7BitEncodedInt();
			if (num == -1)
			{
				return null;
			}
			string text = FindType(num);
			int num2 = text.IndexOf(',');
			if (num2 > 0)
			{
				text = text.Substring(0, num2);
			}
			switch (text)
			{
			case "System.String":
				return reader.ReadString();
			case "System.Byte":
				return reader.ReadByte();
			case "System.SByte":
				return reader.ReadSByte();
			case "System.Int16":
				return reader.ReadInt16();
			case "System.UInt16":
				return reader.ReadUInt16();
			case "System.Int32":
				return reader.ReadInt32();
			case "System.UInt32":
				return reader.ReadUInt32();
			case "System.Int64":
				return reader.ReadInt64();
			case "System.UInt64":
				return reader.ReadUInt64();
			case "System.Single":
				return reader.ReadSingle();
			case "System.Double":
				return reader.ReadDouble();
			case "System.DateTime":
				return new DateTime(reader.ReadInt64());
			case "System.TimeSpan":
				return new TimeSpan(reader.ReadInt64());
			case "System.Decimal":
			{
				int[] array = new int[4];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = reader.ReadInt32();
				}
				return new decimal(array);
			}
			default:
				return new ResourceSerializedObject(FindType(num), this, reader.BaseStream.Position);
			}
		}
	}

	private object LoadObjectV2(int dataOffset)
	{
		Debug.Assert(Monitor.IsEntered(reader));
		reader.Seek(checked(dataSectionPosition + dataOffset), SeekOrigin.Begin);
		ResourceTypeCode resourceTypeCode = (ResourceTypeCode)reader.Read7BitEncodedInt();
		switch (resourceTypeCode)
		{
		case ResourceTypeCode.Null:
			return null;
		case ResourceTypeCode.String:
			return reader.ReadString();
		case ResourceTypeCode.Boolean:
			return reader.ReadBoolean();
		case ResourceTypeCode.Char:
			return (char)reader.ReadUInt16();
		case ResourceTypeCode.Byte:
			return reader.ReadByte();
		case ResourceTypeCode.SByte:
			return reader.ReadSByte();
		case ResourceTypeCode.Int16:
			return reader.ReadInt16();
		case ResourceTypeCode.UInt16:
			return reader.ReadUInt16();
		case ResourceTypeCode.Int32:
			return reader.ReadInt32();
		case ResourceTypeCode.UInt32:
			return reader.ReadUInt32();
		case ResourceTypeCode.Int64:
			return reader.ReadInt64();
		case ResourceTypeCode.UInt64:
			return reader.ReadUInt64();
		case ResourceTypeCode.Single:
			return reader.ReadSingle();
		case ResourceTypeCode.Double:
			return reader.ReadDouble();
		case ResourceTypeCode.Decimal:
			return reader.ReadDecimal();
		case ResourceTypeCode.DateTime:
		{
			long dateData = reader.ReadInt64();
			return DateTime.FromBinary(dateData);
		}
		case ResourceTypeCode.TimeSpan:
		{
			long ticks = reader.ReadInt64();
			return new TimeSpan(ticks);
		}
		case ResourceTypeCode.ByteArray:
		{
			int num2 = reader.ReadInt32();
			if (num2 < 0)
			{
				throw new BadImageFormatException("Resource with negative length");
			}
			return reader.ReadBytes(num2);
		}
		case ResourceTypeCode.Stream:
		{
			int num = reader.ReadInt32();
			if (num < 0)
			{
				throw new BadImageFormatException("Resource with negative length");
			}
			byte[] buffer = reader.ReadBytes(num);
			return new MemoryStream(buffer, writable: false);
		}
		default:
			if (resourceTypeCode < ResourceTypeCode.StartOfUserTypes)
			{
				throw new BadImageFormatException("Invalid typeCode");
			}
			return new ResourceSerializedObject(FindType((int)checked(resourceTypeCode - 64)), this, reader.BaseStream.Position);
		}
	}

	public object GetResourceValue(int index)
	{
		GetResourceName(index, out var dataOffset);
		return LoadObject(dataOffset);
	}

	public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
	{
		for (int i = 0; i < numResources; i = checked(i + 1))
		{
			string name = GetResourceName(i, out var dataOffset);
			object val = LoadObject(dataOffset);
			yield return new KeyValuePair<string, object>(name, val);
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	private long[] GetStartPositions()
	{
		long[] array = LazyInit.VolatileRead(ref startPositions);
		if (array != null)
		{
			return array;
		}
		checked
		{
			lock (reader)
			{
				array = LazyInit.VolatileRead(ref startPositions);
				if (array != null)
				{
					return array;
				}
				array = new long[numResources * 2];
				int num = 0;
				for (int i = 0; i < numResources; i++)
				{
					array[num++] = nameSectionPosition + namePositions[i];
					array[num++] = dataSectionPosition + GetResourceDataOffset(i);
				}
				Array.Sort(array);
				return LazyInit.GetOrSet(ref startPositions, array);
			}
		}
	}

	internal byte[] GetBytesForSerializedObject(long pos)
	{
		long[] array = GetStartPositions();
		int num = Array.BinarySearch(array, pos);
		if (num < 0)
		{
			num = ~num;
		}
		lock (reader)
		{
			long num2 = ((num != array.Length) ? array[num] : reader.BaseStream.Length);
			int count = checked((int)(num2 - pos));
			reader.Seek(pos, SeekOrigin.Begin);
			return reader.ReadBytes(count);
		}
	}
}
