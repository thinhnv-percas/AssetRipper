using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Wasm.Binary
{
	public class BinaryWasmWriter
	{
		[CompilerGenerated]
		internal BinaryWriter _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020;

		[CompilerGenerated]
		internal Encoding _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A;

		public BinaryWriter Writer
		{
			get;
			internal set;
		}

		public Encoding StringEncoding
		{
			get;
			internal set;
		}

		public BinaryWasmWriter(BinaryWriter writer)
			: this(writer, Encoding.UTF8)
		{
		}

		public BinaryWasmWriter(BinaryWriter writer, Encoding stringEncoding)
		{
			Writer = writer;
			StringEncoding = stringEncoding;
		}

		public int WriteVarUInt64(ulong value)
		{
			int num = 0;
			do
			{
				byte b = (byte)(value & 0x7F);
				value >>= 7;
				if (value != 0L)
				{
					b = (byte)(b | 0x80);
				}
				Writer.Write(b);
				num++;
			}
			while (value != 0L);
			return num;
		}

		public int WriteVarUInt32(uint value)
		{
			return WriteVarUInt64(value);
		}

		public int WriteVarUInt7(byte value)
		{
			return WriteVarUInt32(value);
		}

		public int WriteVarUInt1(bool value)
		{
			return WriteVarUInt32(value ? 1u : 0u);
		}

		public int WriteVarInt64(long value)
		{
			int num = 0;
			bool flag = true;
			while (flag)
			{
				byte b = (byte)(value & 0x7F);
				value >>= 7;
				if ((value == 0L && (b & 0x40) == 0) || (value == -1 && (b & 0x40) == 64))
				{
					flag = false;
				}
				else
				{
					b = (byte)(b | 0x80);
				}
				Writer.Write(b);
				num++;
			}
			return num;
		}

		public int WriteVarInt32(int value)
		{
			return WriteVarInt64(value);
		}

		public int WriteVarInt7(sbyte value)
		{
			return WriteVarInt64(value);
		}

		public int WriteFloat32(float value)
		{
			Writer.Write(value);
			return 4;
		}

		public int WriteFloat64(double value)
		{
			Writer.Write(value);
			return 8;
		}

		public int WriteWasmType(WasmType value)
		{
			return WriteVarInt7((sbyte)value);
		}

		public int WriteWasmValueType(WasmValueType value)
		{
			return WriteVarInt7((sbyte)value);
		}

		public void WriteString(string value)
		{
			byte[] bytes = StringEncoding.GetBytes(value);
			WriteVarUInt32((uint)bytes.Length);
			Writer.Write(bytes);
		}

		public void WriteLengthPrefixed(Action<BinaryWasmWriter> writeData)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				BinaryWasmWriter obj = new BinaryWasmWriter(new BinaryWriter(memoryStream), StringEncoding);
				writeData(obj);
				long position = memoryStream.Position;
				memoryStream.Seek(0L, SeekOrigin.Begin);
				WriteVarUInt32((uint)position);
				Writer.Write(memoryStream.GetBuffer(), 0, (int)position);
			}
		}

		public void WriteVersionHeader(VersionHeader header)
		{
			Writer.Write(header.Magic);
			Writer.Write(header.Version);
		}

		public void WriteSection(Section value)
		{
			WriteVarInt7((sbyte)value.Name.Code);
			WriteLengthPrefixed(value.WriteCustomNameAndPayloadTo);
		}

		public void WriteFile(WasmFile file)
		{
			WriteVersionHeader(file.Header);
			foreach (Section section in file.Sections)
			{
				WriteSection(section);
			}
		}
	}
}
