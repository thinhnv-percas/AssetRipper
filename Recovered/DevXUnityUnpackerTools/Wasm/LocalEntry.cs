using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Wasm.Binary;

namespace Wasm
{
	public struct LocalEntry : IEquatable<LocalEntry>
	{
		[CompilerGenerated]
		private WasmValueType _0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A;

		[CompilerGenerated]
		private uint _0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020;

		public WasmValueType LocalType
		{
			get;
			private set;
		}

		public uint LocalCount
		{
			get;
			private set;
		}

		public LocalEntry(WasmValueType localType, uint localCount)
		{
			LocalType = localType;
			LocalCount = localCount;
		}

		public void WriteTo(BinaryWasmWriter writer)
		{
			writer.WriteVarUInt32(LocalCount);
			writer.WriteWasmValueType(LocalType);
		}

		public static LocalEntry ReadFrom(BinaryWasmReader reader)
		{
			uint localCount = reader.ReadVarUInt32();
			return new LocalEntry(reader.ReadWasmValueType(), localCount);
		}

		public void Dump(TextWriter writer)
		{
			writer.Write(LocalCount);
			writer.Write(" x ");
			DumpHelpers.DumpWasmType(LocalType, writer);
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			Dump(new StringWriter(stringBuilder));
			return stringBuilder.ToString();
		}

		public override bool Equals(object obj)
		{
			if (obj is LocalEntry)
			{
				return Equals((LocalEntry)obj);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return ((int)LocalType << 16) | (int)LocalCount;
		}

		public bool Equals(LocalEntry other)
		{
			if (LocalType == other.LocalType)
			{
				return LocalCount == other.LocalCount;
			}
			return false;
		}
	}
}
