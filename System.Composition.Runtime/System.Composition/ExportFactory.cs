namespace System.Composition;

public class ExportFactory<T>
{
	private readonly Func<Tuple<T, Action>> _exportLifetimeContextCreator;

	public ExportFactory(Func<Tuple<T, Action>> exportCreator)
	{
		if (exportCreator == null)
		{
			throw new ArgumentNullException("exportCreator");
		}
		_exportLifetimeContextCreator = exportCreator;
	}

	public Export<T> CreateExport()
	{
		Tuple<T, Action> tuple = _exportLifetimeContextCreator();
		return new Export<T>(tuple.Item1, tuple.Item2);
	}
}
public class ExportFactory<T, TMetadata> : ExportFactory<T>
{
	private readonly TMetadata _metadata;

	public TMetadata Metadata => _metadata;

	public ExportFactory(Func<Tuple<T, Action>> exportCreator, TMetadata metadata)
		: base(exportCreator)
	{
		_metadata = metadata;
	}
}
