using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Wasm.Binary
{
	public class BinaryWasmReader
	{
		internal BinaryReader _0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A;

		[CompilerGenerated]
		internal Encoding _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A;

		internal Func<bool> _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020;

		[CompilerGenerated]
		internal long _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A;

		public Encoding StringEncoding
		{
			get;
			internal set;
		}

		public long Position
		{
			get;
			internal set;
		}

		public BinaryWasmReader(BinaryReader reader)
			: this(reader, Encoding.UTF8)
		{
		}

		public BinaryWasmReader(BinaryReader reader, Encoding stringEncoding)
		{
			_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A = reader;
			StringEncoding = stringEncoding;
			_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020 = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A;
		}

		public BinaryWasmReader(BinaryReader reader, Encoding stringEncoding, Func<bool> streamIsEmpty)
		{
			_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A = reader;
			StringEncoding = stringEncoding;
			_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020 = streamIsEmpty;
		}

		public BinaryWasmReader(BinaryReader reader, Func<bool> streamIsEmpty)
		{
			_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A = reader;
			StringEncoding = Encoding.UTF8;
			_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020 = streamIsEmpty;
		}

		internal bool _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A()
		{
			return Position >= _0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A.BaseStream.Length;
		}

		public byte ReadByte()
		{
			byte result = _0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A.ReadByte();
			Position++;
			return result;
		}

		public byte[] ReadBytes(int count)
		{
			byte[] result = _0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A.ReadBytes(count);
			Position += count;
			return result;
		}

		public ulong ReadVarUInt64()
		{
			ulong num = 0uL;
			int num2 = 0;
			while (true)
			{
				byte b = ReadByte();
				num = (ulong)((long)num | ((long)(b & 0x7F) << num2));
				if ((b & 0x80) == 0)
				{
					break;
				}
				num2 += 7;
			}
			return num;
		}

		public bool ReadVarUInt1()
		{
			return ReadVarUInt64() != 0;
		}

		public byte ReadVarUInt7()
		{
			return (byte)ReadVarUInt64();
		}

		public uint ReadVarUInt32()
		{
			return (uint)ReadVarUInt64();
		}

		public long ReadVarInt64()
		{
			long num = 0L;
			int num2 = 0;
			byte b;
			do
			{
				b = ReadByte();
				num |= (long)(b & 0x7F) << num2;
				num2 += 7;
			}
			while ((b & 0x80) != 0);
			if (num2 < 64 && (b & 0x40) == 64)
			{
				num |= -(1L << num2);
			}
			return num;
		}

		public sbyte ReadVarInt7()
		{
			return (sbyte)ReadVarInt64();
		}

		public int ReadVarInt32()
		{
			return (int)ReadVarInt64();
		}

		public float ReadFloat32()
		{
			float result = _0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A.ReadSingle();
			Position += 4L;
			return result;
		}

		public double ReadFloat64()
		{
			double result = _0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A.ReadDouble();
			Position += 8L;
			return result;
		}

		public WasmType ReadWasmType()
		{
			return (WasmType)ReadVarInt7();
		}

		public WasmValueType ReadWasmValueType()
		{
			return (WasmValueType)ReadVarInt7();
		}

		public string ReadString()
		{
			uint count = ReadVarUInt32();
			byte[] bytes = ReadBytes((int)count);
			return StringEncoding.GetString(bytes);
		}

		public ResizableLimits ReadResizableLimits()
		{
			bool num = ReadVarUInt1();
			uint initial = ReadVarUInt32();
			uint? maximum = num ? new uint?(ReadVarUInt32()) : null;
			return new ResizableLimits(initial, maximum);
		}

		public VersionHeader ReadVersionHeader()
		{
			VersionHeader result = new VersionHeader(_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A.ReadUInt32(), _0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A.ReadUInt32());
			Position += 8L;
			return result;
		}

		public SectionHeader ReadSectionHeader()
		{
			SectionCode sectionCode = (SectionCode)ReadVarUInt7();
			uint num = ReadVarUInt32();
			if (sectionCode == SectionCode.Custom)
			{
				uint num2 = (uint)Position;
				string customName = ReadString();
				return new SectionHeader(payloadLength: (uint)((int)num - ((int)Position - (int)num2)), name: new SectionName(customName));
			}
			return new SectionHeader(new SectionName(sectionCode), num);
		}

		public Section ReadSection()
		{
			SectionHeader header = ReadSectionHeader();
			return ReadSectionPayload(header);
		}

		public Section ReadSectionPayload(SectionHeader header)
		{
			if (header.Name.IsCustom)
			{
				return ReadCustomSectionPayload(header);
			}
			return ReadKnownSectionPayload(header);
		}

		public byte[] ReadRemainingPayload(long startPosition, uint payloadLength)
		{
			return ReadBytes((int)(Position - startPosition - payloadLength));
		}

		public byte[] ReadRemainingPayload(long startPosition, SectionHeader header)
		{
			return ReadRemainingPayload(startPosition, header.PayloadLength);
		}

		internal virtual Section ReadCustomSectionPayload(SectionHeader header)
		{
			if (header.Name.CustomName == "name")
			{
				return NameSection.ReadSectionPayload(header, this);
			}
			return new CustomSection(header.Name.CustomName, ReadBytes((int)header.PayloadLength));
		}

		internal Section ReadKnownSectionPayload(SectionHeader header)
		{
			switch (header.Name.Code)
			{
			case SectionCode.Type:
				return TypeSection.ReadSectionPayload(header, this);
			case SectionCode.Import:
				return ImportSection.ReadSectionPayload(header, this);
			case SectionCode.Function:
				return FunctionSection.ReadSectionPayload(header, this);
			case SectionCode.Table:
				return TableSection.ReadSectionPayload(header, this);
			case SectionCode.Memory:
				return MemorySection.ReadSectionPayload(header, this);
			case SectionCode.Global:
				return GlobalSection.ReadSectionPayload(header, this);
			case SectionCode.Export:
				return ExportSection.ReadSectionPayload(header, this);
			case SectionCode.Start:
				return StartSection.ReadSectionPayload(header, this);
			case SectionCode.Element:
				return ElementSection.ReadSectionPayload(header, this);
			case SectionCode.Code:
				return CodeSection.ReadSectionPayload(header, this);
			case SectionCode.Data:
				return DataSection.ReadSectionPayload(header, this);
			default:
				return ReadUnknownSectionPayload(header);
			}
		}

		internal virtual Section ReadUnknownSectionPayload(SectionHeader header)
		{
			return new UnknownSection(header.Name.Code, ReadBytes((int)header.PayloadLength));
		}

		public WasmFile ReadFile()
		{
			VersionHeader header = ReadVersionHeader();
			header.Verify();
			List<Section> list = new List<Section>();
			while (!_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020())
			{
				list.Add(ReadSection());
			}
			return new WasmFile(header, list);
		}
	}
}
