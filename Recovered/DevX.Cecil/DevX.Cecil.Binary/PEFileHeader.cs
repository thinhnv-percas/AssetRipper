namespace DevX.Cecil.Binary
{
	public sealed class PEFileHeader : IBinaryVisitable, IHeader
	{
		public ushort Machine;

		public ushort NumberOfSections;

		public uint TimeDateStamp;

		public uint PointerToSymbolTable;

		public uint NumberOfSymbols;

		public ushort OptionalHeaderSize;

		public ImageCharacteristics Characteristics;

		internal PEFileHeader()
		{
		}

		public void SetDefaultValues()
		{
			Machine = 332;
			PointerToSymbolTable = 0u;
			NumberOfSymbols = 0u;
			OptionalHeaderSize = 224;
		}

		public void Accept(IBinaryVisitor visitor)
		{
			visitor.VisitPEFileHeader(this);
		}
	}
}
