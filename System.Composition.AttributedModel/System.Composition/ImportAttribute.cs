namespace System.Composition;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
public class ImportAttribute : Attribute
{
	public string ContractName { get; private set; }

	public bool AllowDefault { get; set; }

	public ImportAttribute()
		: this(null)
	{
	}

	public ImportAttribute(string contractName)
	{
		ContractName = contractName;
	}
}
