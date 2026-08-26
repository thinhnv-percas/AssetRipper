namespace DevX.Cecil
{
	public interface ICustomAttributeProvider
	{
		CustomAttributeCollection CustomAttributes
		{
			get;
		}

		bool HasCustomAttributes
		{
			get;
		}
	}
}
