namespace System.Composition;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Interface, AllowMultiple = true, Inherited = false)]
public sealed class ExportMetadataAttribute : Attribute
{
	public string Name { get; private set; }

	public object Value { get; private set; }

	public ExportMetadataAttribute(string name, object value)
	{
		Name = name ?? string.Empty;
		Value = value;
	}
}
