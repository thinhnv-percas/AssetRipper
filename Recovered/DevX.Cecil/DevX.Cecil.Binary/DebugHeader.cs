using System;

namespace DevX.Cecil.Binary
{
	public sealed class DebugHeader : IBinaryVisitable, IHeader
	{
		public uint Characteristics;

		public uint TimeDateStamp;

		public ushort MajorVersion;

		public ushort MinorVersion;

		public DebugStoreType Type;

		public uint SizeOfData;

		public RVA AddressOfRawData;

		public uint PointerToRawData;

		public uint Magic;

		public Guid Signature;

		public uint Age;

		public string FileName;

		internal DebugHeader()
		{
		}

		public void SetDefaultValues()
		{
			Characteristics = 0u;
			Magic = 1396986706u;
			Age = 0u;
			Type = DebugStoreType.CodeView;
			FileName = string.Empty;
		}

		public uint GetSize()
		{
			return (uint)(52 + FileName.Length + 1);
		}

		public void Accept(IBinaryVisitor visitor)
		{
			visitor.VisitDebugHeader(this);
		}
	}
}
