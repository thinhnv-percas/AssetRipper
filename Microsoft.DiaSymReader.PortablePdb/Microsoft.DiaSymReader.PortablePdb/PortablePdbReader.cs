using System;
using System.Collections.Immutable;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace Microsoft.DiaSymReader.PortablePdb;

internal sealed class PortablePdbReader : IDisposable
{
	internal SymReader _symReader;

	internal readonly int Version;

	internal readonly int PreviousDocumentCount;

	private readonly MetadataReader _metadataReader;

	private MetadataReaderProvider _metadataReaderProvider;

	private ImmutableArray<DocumentId> _documentHandleToIdMapOpt;

	private ImmutableArray<MethodId> _methodHandleToIdMapOpt;

	internal SymReader SymReader
	{
		get
		{
			return _symReader;
		}
		set
		{
			_symReader = value;
		}
	}

	internal MetadataReader MetadataReader
	{
		get
		{
			if (IsDisposed)
			{
				throw new ObjectDisposedException("SymReader");
			}
			return _metadataReader;
		}
	}

	internal bool IsDisposed => _metadataReaderProvider == null;

	internal PortablePdbReader(MetadataReaderProvider provider, int version, int previousDocumentCount)
	{
		try
		{
			_metadataReader = provider.GetMetadataReader();
		}
		finally
		{
			if (_metadataReader == null)
			{
				provider.Dispose();
			}
		}
		_metadataReaderProvider = provider;
		Version = version;
		PreviousDocumentCount = previousDocumentCount;
	}

	internal DocumentId GetDocumentId(DocumentHandle handle)
	{
		int rowNumber = MetadataTokens.GetRowNumber(handle);
		if (!_documentHandleToIdMapOpt.IsDefault)
		{
			return _documentHandleToIdMapOpt[rowNumber - 1];
		}
		return new DocumentId(rowNumber);
	}

	internal MethodId GetMethodId(MethodDebugInformationHandle handle)
	{
		int rowNumber = MetadataTokens.GetRowNumber(handle);
		if (!_methodHandleToIdMapOpt.IsDefault)
		{
			return _methodHandleToIdMapOpt[rowNumber - 1];
		}
		return new MethodId(rowNumber);
	}

	internal bool TryGetMethodHandle(MethodId id, out MethodDebugInformationHandle handle)
	{
		if (id.IsDefault)
		{
			handle = default(MethodDebugInformationHandle);
			return false;
		}
		if (_methodHandleToIdMapOpt.IsDefault)
		{
			if (id.Value > _metadataReader.MethodDebugInformation.Count)
			{
				handle = default(MethodDebugInformationHandle);
				return false;
			}
			handle = MetadataTokens.MethodDebugInformationHandle(id.Value);
			return true;
		}
		int num = _methodHandleToIdMapOpt.BinarySearch(id);
		if (num >= 0)
		{
			handle = MetadataTokens.MethodDebugInformationHandle(num + 1);
			return true;
		}
		handle = default(MethodDebugInformationHandle);
		return false;
	}

	internal bool HasDebugInfo(MethodDebugInformationHandle handle)
	{
		return !MetadataReader.GetMethodDebugInformation(handle).SequencePointsBlob.IsNil;
	}

	internal void InitializeHandleToIdMaps(ImmutableArray<DocumentId> documentIds, ImmutableArray<MethodId> methodIds)
	{
		_documentHandleToIdMapOpt = documentIds;
		_methodHandleToIdMapOpt = methodIds;
	}

	internal bool MatchesModule(Guid guid, uint stamp, int age)
	{
		if (age != 1)
		{
			return false;
		}
		BlobContentId blobContentId = new BlobContentId(MetadataReader.DebugMetadataHeader.Id);
		if (blobContentId.Guid == guid)
		{
			return blobContentId.Stamp == stamp;
		}
		return false;
	}

	public void Dispose()
	{
		_metadataReaderProvider?.Dispose();
		_metadataReaderProvider = null;
	}

	internal int GetMethodSourceExtentInDocument(ISymUnmanagedDocument document, SymMethod method, out int startLine, out int endLine)
	{
		SymDocument symDocument = SymReader.AsSymDocument(document);
		if (symDocument == null)
		{
			startLine = (endLine = 0);
			return -2147024809;
		}
		if (!SymReader.GetMethodExtents().TryGetMethodSourceExtent(symDocument.GetId(), method.GetId(), out startLine, out endLine))
		{
			startLine = (endLine = 0);
			return -2147467259;
		}
		return 0;
	}
}
