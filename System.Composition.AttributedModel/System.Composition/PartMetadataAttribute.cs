namespace System.Composition;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class PartMetadataAttribute : Attribute
{
	public string Name { get; private set; }

	public object Value { get; private set; }

	public PartMetadataAttribute(string name, object value)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		Name = name;
		Value = value;
	}
}
