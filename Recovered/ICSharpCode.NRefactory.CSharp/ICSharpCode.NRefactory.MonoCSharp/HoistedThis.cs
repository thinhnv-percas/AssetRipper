namespace ICSharpCode.NRefactory.MonoCSharp
{
	public class HoistedThis : HoistedVariable
	{
		public HoistedThis(AnonymousMethodStorey storey, Field field)
			: base(storey, field)
		{
		}
	}
}
