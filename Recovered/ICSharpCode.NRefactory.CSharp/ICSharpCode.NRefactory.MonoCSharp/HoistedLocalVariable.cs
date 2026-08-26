namespace ICSharpCode.NRefactory.MonoCSharp
{
	internal class HoistedLocalVariable : HoistedVariable
	{
		public HoistedLocalVariable(AnonymousMethodStorey storey, LocalVariable local, string name)
			: base(storey, name, local.Type)
		{
		}
	}
}
