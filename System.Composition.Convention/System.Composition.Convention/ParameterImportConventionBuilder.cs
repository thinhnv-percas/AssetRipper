namespace System.Composition.Convention;

public abstract class ParameterImportConventionBuilder
{
	private ParameterImportConventionBuilder()
	{
	}

	public T Import<T>()
	{
		return default(T);
	}

	public T Import<T>(Action<ImportConventionBuilder> configure)
	{
		return default(T);
	}
}
