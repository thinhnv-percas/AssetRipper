namespace DevX.Cecil.Binary
{
	public sealed class CLIHeader : IBinaryVisitable, IHeader
	{
		public uint Cb;

		public ushort MajorRuntimeVersion;

		public ushort MinorRuntimeVersion;

		public DataDirectory Metadata;

		public RuntimeImage Flags;

		public uint EntryPointToken;

		public DataDirectory Resources;

		public DataDirectory StrongNameSignature;

		public DataDirectory CodeManagerTable;

		public DataDirectory VTableFixups;

		public DataDirectory ExportAddressTableJumps;

		public DataDirectory ManagedNativeHeader;

		public byte[] ImageHash;

		internal CLIHeader()
		{
		}

		public void SetDefaultValues()
		{
			Cb = 72u;
			Flags = RuntimeImage.ILOnly;
			CodeManagerTable = DataDirectory.Zero;
			ExportAddressTableJumps = DataDirectory.Zero;
			ManagedNativeHeader = DataDirectory.Zero;
		}

		public void Accept(IBinaryVisitor visitor)
		{
			visitor.VisitCLIHeader(this);
		}
	}
}
