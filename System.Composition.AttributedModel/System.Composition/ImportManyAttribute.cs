namespace System.Composition;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
public class ImportManyAttribute : Attribute
{
	public string ContractName { get; private set; }

	public ImportManyAttribute()
		: this(null)
	{
	}

	public ImportManyAttribute(string contractName)
	{
		ContractName = contractName;
	}
}
