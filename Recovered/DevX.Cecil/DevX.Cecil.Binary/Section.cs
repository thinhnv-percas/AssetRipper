namespace DevX.Cecil.Binary
{
	public sealed class Section : IBinaryVisitable, IHeader
	{
		public const string Text = ".text";

		public const string Resources = ".rsrc";

		public const string Relocs = ".reloc";

		public const string SData = ".sdata";

		public uint VirtualSize;

		public RVA VirtualAddress;

		public uint SizeOfRawData;

		public RVA PointerToRawData;

		public RVA PointerToRelocations;

		public RVA PointerToLineNumbers;

		public ushort NumberOfRelocations;

		public ushort NumberOfLineNumbers;

		public SectionCharacteristics Characteristics;

		public string Name;

		public byte[] Data;

		internal Section()
		{
		}

		public void SetDefaultValues()
		{
			PointerToLineNumbers = RVA.Zero;
			NumberOfLineNumbers = 0;
		}

		public void Accept(IBinaryVisitor visitor)
		{
			visitor.VisitSection(this);
		}
	}
}
