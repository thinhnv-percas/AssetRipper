namespace DevX.Cecil.Binary
{
	public sealed class HintNameTable : IBinaryVisitable
	{
		public const string RuntimeMainExe = "_CorExeMain";

		public const string RuntimeMainDll = "_CorDllMain";

		public const string RuntimeCorEE = "mscoree.dll";

		public ushort Hint;

		public string RuntimeMain;

		public string RuntimeLibrary;

		public ushort EntryPoint;

		public RVA RVA;

		internal HintNameTable()
		{
		}

		public void Accept(IBinaryVisitor visitor)
		{
			visitor.VisitHintNameTable(this);
		}
	}
}
