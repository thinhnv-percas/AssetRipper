using System;
using System.IO;

namespace Microsoft.DiaSymReader;

public static class SymUnmanagedReaderFactory
{
	public static TSymUnmanagedReader CreateReaderWithMetadataImport<TSymUnmanagedReader>(Stream pdbStream, object metadataImport, SymUnmanagedReaderCreationOptions options = SymUnmanagedReaderCreationOptions.Default) where TSymUnmanagedReader : class, ISymUnmanagedReader3
	{
		if (pdbStream == null)
		{
			throw new ArgumentNullException("pdbStream");
		}
		if (metadataImport == null)
		{
			throw new ArgumentNullException("metadataImport");
		}
		object obj = SymUnmanagedFactory.CreateObject(createReader: true, (options & SymUnmanagedReaderCreationOptions.UseAlternativeLoadPath) != 0, (options & SymUnmanagedReaderCreationOptions.UseComRegistry) != 0, out var _, out var loadException);
		if (obj == null)
		{
			if (loadException is DllNotFoundException)
			{
				throw loadException;
			}
			throw new DllNotFoundException(loadException.Message, loadException);
		}
		TSymUnmanagedReader obj2 = (obj as TSymUnmanagedReader) ?? throw new NotSupportedException();
		obj2.Initialize(pdbStream, metadataImport);
		return obj2;
	}

	public static TSymUnmanagedReader CreateReader<TSymUnmanagedReader>(Stream pdbStream, ISymReaderMetadataProvider metadataProvider, SymUnmanagedReaderCreationOptions options = SymUnmanagedReaderCreationOptions.Default) where TSymUnmanagedReader : class, ISymUnmanagedReader3
	{
		if (metadataProvider == null)
		{
			throw new ArgumentNullException("metadataProvider");
		}
		return CreateReaderWithMetadataImport<TSymUnmanagedReader>(pdbStream, CreateSymReaderMetadataImport(metadataProvider), options);
	}

	public static object CreateSymReaderMetadataImport(ISymReaderMetadataProvider metadataProvider)
	{
		if (metadataProvider == null)
		{
			throw new ArgumentNullException("metadataProvider");
		}
		return new SymReaderMetadataAdapter(metadataProvider);
	}
}
