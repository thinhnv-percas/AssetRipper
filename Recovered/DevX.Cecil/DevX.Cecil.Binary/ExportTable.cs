namespace DevX.Cecil.Binary
{
	public sealed class ExportTable : IBinaryVisitable
	{
		public uint Characteristics;

		public uint TimeDateStamp;

		public ushort MajorVersion;

		public ushort MinorVersion;

		public string Name;

		public uint Base;

		public uint NumberOfFunctions;

		public uint NumberOfNames;

		public RVA AddressOfFunctions;

		public RVA AddressOfNames;

		public RVA AddressOfNameOrdinals;

		public RVA[] AddressesOfFunctions;

		public RVA[] AddressesOfNames;

		public ushort[] NameOrdinals;

		public string[] Names;

		internal ExportTable()
		{
		}

		public void Accept(IBinaryVisitor visitor)
		{
			visitor.VisitExportTable(this);
		}
	}
}
