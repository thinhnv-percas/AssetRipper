namespace System.Composition;

[AttributeUsage(AttributeTargets.Property, Inherited = false)]
public sealed class ImportMetadataConstraintAttribute : Attribute
{
	private readonly string _name;

	private readonly object _value;

	public string Name => _name;

	public object Value => _value;

	public ImportMetadataConstraintAttribute(string name, object value)
	{
		_name = name;
		_value = value;
	}
}
