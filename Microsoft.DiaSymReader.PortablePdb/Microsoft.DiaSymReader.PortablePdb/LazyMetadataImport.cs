using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Microsoft.DiaSymReader.PortablePdb;

internal sealed class LazyMetadataImport : IDisposable
{
	private MetadataImport _lazyMetadataImport;

	private readonly IMetadataImportProvider _metadataImportProviderOpt;

	public LazyMetadataImport(MetadataImport metadataImport)
	{
		_lazyMetadataImport = metadataImport;
	}

	public LazyMetadataImport(IMetadataImportProvider metadataImportProvider)
	{
		_metadataImportProviderOpt = metadataImportProvider;
	}

	public MetadataImport GetMetadataImport()
	{
		if (_lazyMetadataImport == null)
		{
			MetadataImport value = MetadataImport.FromObject(_metadataImportProviderOpt.GetMetadataImport()) ?? throw new InvalidOperationException();
			Interlocked.CompareExchange(ref _lazyMetadataImport, value, null);
		}
		return _lazyMetadataImport;
	}

	public void Dispose()
	{
		MetadataImport metadataImport = Interlocked.Exchange(ref _lazyMetadataImport, null);
		if (metadataImport != null && Marshal.IsComObject(metadataImport))
		{
			Marshal.ReleaseComObject(metadataImport);
		}
	}
}
