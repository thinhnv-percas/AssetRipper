using System.Collections.Generic;
using System.Composition.Hosting;
using System.Composition.Hosting.Core;
using System.Composition.Properties;

namespace System.Composition;

public abstract class CompositionContext
{
	private const string ImportManyImportMetadataConstraintName = "IsImportMany";

	public abstract bool TryGetExport(CompositionContract contract, out object export);

	public TExport GetExport<TExport>()
	{
		return GetExport<TExport>(null);
	}

	public TExport GetExport<TExport>(string contractName)
	{
		return (TExport)GetExport(typeof(TExport), contractName);
	}

	public bool TryGetExport(Type exportType, string contractName, out object export)
	{
		return TryGetExport(new CompositionContract(exportType, contractName), out export);
	}

	public bool TryGetExport(Type exportType, out object export)
	{
		return TryGetExport(exportType, null, out export);
	}

	public bool TryGetExport<TExport>(out TExport export)
	{
		return TryGetExport((string)null, out export);
	}

	public bool TryGetExport<TExport>(string contractName, out TExport export)
	{
		if (!TryGetExport(typeof(TExport), contractName, out var export2))
		{
			export = default(TExport);
			return false;
		}
		export = (TExport)export2;
		return true;
	}

	public object GetExport(Type exportType)
	{
		return GetExport(exportType, null);
	}

	public object GetExport(Type exportType, string contractName)
	{
		return GetExport(new CompositionContract(exportType, contractName));
	}

	public object GetExport(CompositionContract contract)
	{
		if (!TryGetExport(contract, out var export))
		{
			throw new CompositionFailedException(string.Format(System.Composition.Properties.Resources.CompositionContext_NoExportFoundForContract, new object[1] { contract }));
		}
		return export;
	}

	public IEnumerable<object> GetExports(Type exportType)
	{
		return GetExports(exportType, null);
	}

	public IEnumerable<object> GetExports(Type exportType, string contractName)
	{
		CompositionContract contract = new CompositionContract(exportType.MakeArrayType(), contractName, new Dictionary<string, object> { { "IsImportMany", true } });
		return (IEnumerable<object>)GetExport(contract);
	}

	public IEnumerable<TExport> GetExports<TExport>()
	{
		return GetExports<TExport>(null);
	}

	public IEnumerable<TExport> GetExports<TExport>(string contractName)
	{
		return (IEnumerable<TExport>)GetExports(typeof(TExport), contractName);
	}
}
