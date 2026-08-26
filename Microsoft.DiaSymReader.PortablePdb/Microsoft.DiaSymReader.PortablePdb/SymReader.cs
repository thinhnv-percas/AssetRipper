using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using Roslyn.Utilities;

namespace Microsoft.DiaSymReader.PortablePdb;

[ComVisible(false)]
public sealed class SymReader : ISymUnmanagedReader5, ISymUnmanagedReader4, ISymUnmanagedReader3, ISymUnmanagedReader2, ISymUnmanagedReader, ISymUnmanagedDispose, ISymUnmanagedEncUpdate
{
	private readonly Lazy<bool> _lazyVbSemantics;

	private readonly LazyMetadataImport _metadataImport;

	private List<PortablePdbReader> _pdbReaders;

	private readonly Lazy<DocumentMap> _lazyDocumentMap;

	private readonly Lazy<MethodMap> _methodMap;

	private readonly Lazy<MethodExtents> _lazyMethodExtents;

	private Dictionary<MethodId, MethodLineDeltas> _lazyMethodLineDeltas;

	internal Lazy<bool> VbSemantics => _lazyVbSemantics;

	internal bool IsDisposed => _pdbReaders == null;

	internal int Version => GetReaders().Count;

	internal SymReader(PortablePdbReader pdbReader, LazyMetadataImport metadataImport)
	{
		pdbReader.SymReader = this;
		_pdbReaders = new List<PortablePdbReader> { pdbReader };
		_metadataImport = metadataImport;
		_lazyDocumentMap = new Lazy<DocumentMap>(() => new DocumentMap(_pdbReaders[0].MetadataReader));
		_methodMap = new Lazy<MethodMap>(() => new MethodMap(_pdbReaders[0]));
		_lazyMethodExtents = new Lazy<MethodExtents>(() => new MethodExtents(_pdbReaders[0]));
		_lazyVbSemantics = new Lazy<bool>(() => IsVisualBasicAssembly());
	}

	internal DocumentMap GetDocumentMap()
	{
		return _lazyDocumentMap.Value;
	}

	internal MethodMap GetMethodMap()
	{
		return _methodMap.Value;
	}

	internal MethodExtents GetMethodExtents()
	{
		return _lazyMethodExtents.Value;
	}

	internal static SymReader CreateFromFile(string path, LazyMetadataImport metadataImport)
	{
		return new SymReader(new PortablePdbReader(CreateProviderFromFile(path), 1, 0), metadataImport);
	}

	internal static MetadataReaderProvider CreateProviderFromFile(string path)
	{
		return MetadataReaderProvider.FromPortablePdbStream(PortableShim.FileStream.CreateReadShareDelete(path));
	}

	internal static ISymUnmanagedReader CreateFromStream(IStream stream, LazyMetadataImport metadataImport)
	{
		return new SymReader(new PortablePdbReader(CreateProviderFromStream(stream), 1, 0), metadataImport);
	}

	internal static MetadataReaderProvider CreateProviderFromStream(IStream stream)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		ReadOnlyInteropStream readOnlyInteropStream = new ReadOnlyInteropStream(stream);
		byte[] array = new byte[8];
		if (readOnlyInteropStream.TryReadAll(array, 0, array.Length) == array.Length && array[0] == 77 && array[1] == 80 && array[2] == 68 && array[3] == 66)
		{
			int num = BitConverter.ToInt32(array, 4);
			byte[] array2;
			try
			{
				array2 = new byte[num];
			}
			catch
			{
				throw new BadImageFormatException();
			}
			DeflateStream val = new DeflateStream((Stream)readOnlyInteropStream, (CompressionMode)0, true);
			if (num > 0)
			{
				int num2;
				try
				{
					num2 = ((Stream)(object)val).TryReadAll(array2, 0, array2.Length);
				}
				catch (InvalidDataException ex)
				{
					throw new BadImageFormatException(ex.Message, ex.InnerException);
				}
				if (num2 != array2.Length)
				{
					throw new BadImageFormatException();
				}
			}
			if (((Stream)(object)val).ReadByte() != -1)
			{
				throw new BadImageFormatException();
			}
			return MetadataReaderProvider.FromPortablePdbImage(ImmutableByteArrayInterop.DangerousCreateFromUnderlyingArray(ref array2));
		}
		readOnlyInteropStream.Position = 0L;
		return MetadataReaderProvider.FromPortablePdbStream(readOnlyInteropStream);
	}

	internal bool IsValidVersion(int version)
	{
		if (version >= 1)
		{
			return version <= Version;
		}
		return false;
	}

	internal PortablePdbReader GetReader(int version)
	{
		if (IsDisposed)
		{
			throw new ObjectDisposedException("SymReader");
		}
		return _pdbReaders[version - 1];
	}

	internal IReadOnlyList<PortablePdbReader> GetReaders()
	{
		if (IsDisposed)
		{
			throw new ObjectDisposedException("SymReader");
		}
		return _pdbReaders;
	}

	internal MetadataImport GetMetadataImport()
	{
		if (IsDisposed)
		{
			throw new ObjectDisposedException("SymReader");
		}
		return _metadataImport.GetMetadataImport();
	}

	public int Destroy()
	{
		List<PortablePdbReader> list = Interlocked.Exchange(ref _pdbReaders, null);
		if (list == null)
		{
			return 0;
		}
		foreach (PortablePdbReader item in list)
		{
			item.Dispose();
		}
		_metadataImport.Dispose();
		return 1;
	}

	private bool IsVisualBasicAssembly()
	{
		MetadataReader metadataReader = Enumerable.First<PortablePdbReader>((IEnumerable<PortablePdbReader>)_pdbReaders).MetadataReader;
		foreach (CustomDebugInformationHandle item in metadataReader.GetCustomDebugInformation(Handle.ModuleDefinition))
		{
			if (metadataReader.GetGuid(metadataReader.GetCustomDebugInformation(item).Kind) == MetadataUtilities.VbDefaultNamespaceId)
			{
				return true;
			}
		}
		return false;
	}

	internal SymDocument AsSymDocument(ISymUnmanagedDocument document)
	{
		SymDocument symDocument = document as SymDocument;
		if (symDocument?.SymReader != this)
		{
			return null;
		}
		return symDocument;
	}

	internal SymMethod AsSymMethod(ISymUnmanagedMethod method)
	{
		SymMethod symMethod = method as SymMethod;
		if (symMethod?.SymReader != this)
		{
			return null;
		}
		return symMethod;
	}

	private void UpdateLineDeltas(MethodId methodId, MethodLineDeltas deltas)
	{
		if (_lazyMethodLineDeltas == null)
		{
			_lazyMethodLineDeltas = new Dictionary<MethodId, MethodLineDeltas>();
		}
		if (_lazyMethodLineDeltas.TryGetValue(methodId, out var value))
		{
			_lazyMethodLineDeltas[methodId] = value.Merge(deltas);
		}
		else
		{
			_lazyMethodLineDeltas[methodId] = deltas;
		}
	}

	private void RemoveLineDeltas(MethodId methodId)
	{
		_lazyMethodLineDeltas?.Remove(methodId);
	}

	internal bool TryGetLineDeltas(MethodId methodId, out MethodLineDeltas deltas)
	{
		if (_lazyMethodLineDeltas == null)
		{
			deltas = default(MethodLineDeltas);
			return false;
		}
		return _lazyMethodLineDeltas.TryGetValue(methodId, out deltas);
	}

	public int GetDocument([MarshalAs(UnmanagedType.LPWStr)] string url, Guid language, Guid languageVendor, Guid documentType, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedDocument document)
	{
		DocumentMap documentMap = GetDocumentMap();
		if (documentMap.TryGetDocument(url, out var id))
		{
			DocumentMap.DocumentInfo info = documentMap.GetInfo(id);
			document = new SymDocument(GetReader(info.Version), info.Handle);
			return 0;
		}
		document = null;
		return 1;
	}

	public int GetDocuments(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISymUnmanagedDocument[] documents)
	{
		DocumentMap documentMap = null;
		PortablePdbReader portablePdbReader = null;
		if (Version > 1)
		{
			documentMap = GetDocumentMap();
			count = documentMap.DocumentCount;
		}
		else
		{
			portablePdbReader = GetReader(1);
			count = portablePdbReader.MetadataReader.Documents.Count;
		}
		if (bufferLength == 0)
		{
			return 0;
		}
		if (documents == null)
		{
			count = 0;
			return -2147024809;
		}
		int num = 0;
		if (documentMap != null)
		{
			foreach (DocumentMap.DocumentInfo info in documentMap.Infos)
			{
				if (num >= bufferLength)
				{
					break;
				}
				documents[num++] = new SymDocument(GetReader(info.Version), info.Handle);
			}
		}
		else
		{
			foreach (DocumentHandle document in portablePdbReader.MetadataReader.Documents)
			{
				if (num >= bufferLength)
				{
					break;
				}
				documents[num++] = new SymDocument(portablePdbReader, document);
			}
		}
		return 0;
	}

	public int GetDocumentVersion(ISymUnmanagedDocument document, out int version, out bool isCurrent)
	{
		version = 1;
		isCurrent = true;
		return -2147467263;
	}

	public int GetGlobalVariables(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISymUnmanagedVariable[] variables)
	{
		count = 0;
		return -2147467263;
	}

	public int GetMethod(int methodToken, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedMethod method)
	{
		int methodImpl = GetMethodImpl(methodToken, out var method2);
		method = method2;
		return methodImpl;
	}

	private int GetMethodImpl(int methodToken, out SymMethod method)
	{
		if (TryGetDebuggableMethod(methodToken, out var pdbReader, out var handle))
		{
			method = new SymMethod(pdbReader, handle);
			return 0;
		}
		method = null;
		return -2147467259;
	}

	private bool TryGetDebuggableMethod(int methodToken, out PortablePdbReader pdbReader, out MethodDebugInformationHandle handle)
	{
		if (!MetadataUtilities.IsMethodToken(methodToken))
		{
			pdbReader = null;
			handle = default(MethodDebugInformationHandle);
			return false;
		}
		MethodId methodId = MethodId.FromToken(methodToken);
		if (Version == 1)
		{
			pdbReader = GetReader(1);
			if (pdbReader.TryGetMethodHandle(methodId, out handle))
			{
				return pdbReader.HasDebugInfo(handle);
			}
		}
		else
		{
			MethodMap methodMap = GetMethodMap();
			if (methodMap.IsValidMethodRowId(methodId.Value))
			{
				MethodMap.MethodInfo info = methodMap.GetInfo(methodId);
				pdbReader = GetReader(info.Version);
				handle = info.Handle;
				return pdbReader.HasDebugInfo(handle);
			}
		}
		pdbReader = null;
		handle = default(MethodDebugInformationHandle);
		return false;
	}

	public int GetMethodByVersion(int methodToken, int version, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedMethod method)
	{
		if (!IsValidVersion(version))
		{
			method = null;
			return -2147024809;
		}
		if (!MetadataUtilities.IsMethodToken(methodToken))
		{
			method = null;
			return -2147024809;
		}
		PortablePdbReader reader = GetReader(version);
		if (!reader.TryGetMethodHandle(MethodId.FromToken(methodToken), out var handle))
		{
			method = null;
			return -2147467259;
		}
		if (reader.MetadataReader.GetMethodDebugInformation(handle).SequencePointsBlob.IsNil)
		{
			method = null;
			return -2147467259;
		}
		method = new SymMethod(reader, handle);
		return 0;
	}

	public int GetMethodByVersionPreRemap(int methodToken, int version, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedMethod method)
	{
		return GetMethodByVersion(methodToken, version, out method);
	}

	public int GetMethodFromDocumentPosition(ISymUnmanagedDocument document, int line, int column, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedMethod method)
	{
		SymDocument symDocument = AsSymDocument(document);
		if (symDocument == null)
		{
			method = null;
			return -2147024809;
		}
		IEnumerable<(MethodId, int)> methodsContainingLine = GetMethodExtents().GetMethodsContainingLine(symDocument.GetId(), line);
		if (methodsContainingLine == null)
		{
			method = null;
			return -2147467259;
		}
		(MethodId, int) tuple = default((MethodId, int));
		foreach (var (methodId, item) in methodsContainingLine)
		{
			if (tuple.Item1.IsDefault || methodId < tuple.Item1)
			{
				tuple = (methodId, item);
			}
		}
		if (tuple.Item1.IsDefault)
		{
			method = null;
			return -2147467259;
		}
		PortablePdbReader reader = GetReader(tuple.Item2);
		if (!reader.TryGetMethodHandle(tuple.Item1, out var handle))
		{
			method = null;
			return -2147467259;
		}
		method = new SymMethod(reader, handle);
		return 0;
	}

	public int GetMethodsFromDocumentPosition(ISymUnmanagedDocument document, int line, int column, int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] ISymUnmanagedMethod[] methods)
	{
		SymDocument symDocument = AsSymDocument(document);
		if (symDocument == null)
		{
			count = 0;
			return -2147024809;
		}
		IEnumerable<(MethodId, int)> methodsContainingLine = GetMethodExtents().GetMethodsContainingLine(symDocument.GetId(), line);
		if (methodsContainingLine == null)
		{
			count = 0;
			return -2147467259;
		}
		if (bufferLength > 0)
		{
			int num = 0;
			foreach (var (id, version) in (IEnumerable<(MethodId, int)>)Enumerable.OrderBy<(MethodId, int), MethodId>(methodsContainingLine, (Func<(MethodId, int), MethodId>)(((MethodId Id, int Version) entry) => entry.Id)))
			{
				if (num == bufferLength)
				{
					break;
				}
				PortablePdbReader reader = GetReader(version);
				if (!reader.TryGetMethodHandle(id, out var handle))
				{
					throw ExceptionUtilities.Unreachable;
				}
				methods[num++] = new SymMethod(reader, handle);
			}
			count = num;
		}
		else
		{
			count = Enumerable.Count<(MethodId, int)>(methodsContainingLine);
		}
		return 0;
	}

	public int GetMethodsInDocument(ISymUnmanagedDocument document, int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ISymUnmanagedMethod[] methods)
	{
		SymDocument symDocument = AsSymDocument(document);
		if (symDocument == null)
		{
			count = 0;
			return -2147024809;
		}
		if (bufferLength > 0 && (methods == null || methods.Length < bufferLength))
		{
			count = 0;
			return -2147024809;
		}
		ImmutableArray<MethodLineExtent> methodExtents = GetMethodExtents().GetMethodExtents(symDocument.GetId());
		if (bufferLength > 0)
		{
			MethodMap methodMap = GetMethodMap();
			int num = Math.Min(methodExtents.Length, bufferLength);
			for (int i = 0; i < num; i++)
			{
				MethodMap.MethodInfo info = methodMap.GetInfo(methodExtents[i].Method);
				methods[i] = new SymMethod(GetReader(info.Version), info.Handle);
			}
			count = num;
		}
		else
		{
			count = methodExtents.Length;
		}
		return 0;
	}

	public int GetMethodVersion(ISymUnmanagedMethod method, out int version)
	{
		SymMethod symMethod = AsSymMethod(method);
		if (symMethod == null)
		{
			version = 0;
			return -2147024809;
		}
		version = symMethod.PdbReader.Version;
		return 0;
	}

	public int GetNamespaces(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISymUnmanagedNamespace[] namespaces)
	{
		count = 0;
		return -2147467263;
	}

	public int GetSymAttribute(int methodToken, [MarshalAs(UnmanagedType.LPWStr)] string name, int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] customDebugInformation)
	{
		return GetSymAttributeByVersion(methodToken, 1, name, bufferLength, out count, customDebugInformation);
	}

	public int GetSymAttributeByVersion(int methodToken, int version, [MarshalAs(UnmanagedType.LPWStr)] string name, int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] customDebugInformation)
	{
		count = 0;
		if (bufferLength != 0 != (customDebugInformation != null) || !IsValidVersion(version))
		{
			return -2147024809;
		}
		return 1;
	}

	public int GetSymAttributePreRemap(int methodToken, [MarshalAs(UnmanagedType.LPWStr)] string name, int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] customDebugInformation)
	{
		return GetSymAttribute(methodToken, name, bufferLength, out count, customDebugInformation);
	}

	public int GetSymAttributeByVersionPreRemap(int methodToken, int version, [MarshalAs(UnmanagedType.LPWStr)] string name, int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] customDebugInformation)
	{
		return GetSymAttributeByVersion(methodToken, version, name, bufferLength, out count, customDebugInformation);
	}

	public int GetSymbolStoreFileName(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] char[] name)
	{
		throw new NotImplementedException();
	}

	public int GetUserEntryPoint(out int methodToken)
	{
		foreach (PortablePdbReader reader in GetReaders())
		{
			MethodDefinitionHandle entryPoint = reader.MetadataReader.DebugMetadataHeader.EntryPoint;
			if (!entryPoint.IsNil)
			{
				methodToken = MetadataTokens.GetToken(entryPoint);
				return 0;
			}
		}
		methodToken = 0;
		return -2147467259;
	}

	public int GetVariables(int methodToken, int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ISymUnmanagedVariable[] variables)
	{
		count = 0;
		return -2147467263;
	}

	public int Initialize([MarshalAs(UnmanagedType.Interface)] object metadataImporter, [MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string searchPath, IStream stream)
	{
		return 0;
	}

	public int ReplaceSymbolStore([MarshalAs(UnmanagedType.LPWStr)] string fileName, IStream stream)
	{
		throw new NotImplementedException();
	}

	public int UpdateSymbolStore([MarshalAs(UnmanagedType.LPWStr)] string fileName, IStream stream)
	{
		if (stream != null)
		{
			return UpdateSymbolStoreImpl(stream, null, EmptyArray<SymUnmanagedLineDelta>.Instance, 0);
		}
		if (string.IsNullOrEmpty(fileName))
		{
			return -2147024809;
		}
		return UpdateSymbolStoreImpl(null, fileName, EmptyArray<SymUnmanagedLineDelta>.Instance, 0);
	}

	[PreserveSig]
	public int MatchesModule(Guid guid, uint stamp, int age, [MarshalAs(UnmanagedType.Bool)] out bool result)
	{
		result = GetReader(1).MatchesModule(guid, stamp, age);
		return 0;
	}

	[PreserveSig]
	public unsafe int GetPortableDebugMetadata(out byte* metadata, out int size)
	{
		return GetPortableDebugMetadataByVersion(Version, out metadata, out size);
	}

	[PreserveSig]
	public unsafe int GetPortableDebugMetadataByVersion(int version, out byte* metadata, out int size)
	{
		if (!IsValidVersion(version))
		{
			metadata = null;
			size = 0;
			return -2147024809;
		}
		MetadataReader metadataReader = GetReader(version).MetadataReader;
		metadata = metadataReader.MetadataPointer;
		size = metadataReader.MetadataLength;
		return 0;
	}

	[PreserveSig]
	public unsafe int GetSourceServerData(out byte* data, out int size)
	{
		MetadataReader metadataReader = GetReader(1).MetadataReader;
		BlobHandle customDebugInformation = metadataReader.GetCustomDebugInformation(EntityHandle.ModuleDefinition, MetadataUtilities.SourceLinkId);
		if (!customDebugInformation.IsNil)
		{
			BlobReader blobReader = metadataReader.GetBlobReader(customDebugInformation);
			data = blobReader.StartPointer;
			size = blobReader.Length;
			return 0;
		}
		data = null;
		size = 0;
		return 1;
	}

	[PreserveSig]
	public int UpdateSymbolStore2(IStream stream, [In][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] SymUnmanagedLineDelta[] lineDeltas, int lineDeltaCount)
	{
		if (stream == null || lineDeltas == null || lineDeltaCount < 0)
		{
			return -2147024809;
		}
		return UpdateSymbolStoreImpl(stream, null, lineDeltas, lineDeltaCount);
	}

	private int UpdateSymbolStoreImpl(IStream stream, string fileName, SymUnmanagedLineDelta[] lineDeltas, int lineDeltaCount)
	{
		lineDeltaCount = Math.Min(lineDeltas.Length, lineDeltaCount);
		MethodMap methodMap = GetMethodMap();
		DocumentMap documentMap = GetDocumentMap();
		MethodExtents methodExtents = GetMethodExtents();
		Dictionary<DocumentId, List<(MethodId, int)>> lineDeltasByDocument = GroupLineDeltasByDocument(lineDeltas, lineDeltaCount);
		int version = Version + 1;
		PortablePdbReader portablePdbReader = new PortablePdbReader((stream != null) ? CreateProviderFromStream(stream) : CreateProviderFromFile(fileName), version, documentMap.DocumentCount);
		documentMap.Update(this, portablePdbReader.MetadataReader, version, out var handleToIdMap);
		methodMap.Update(this, portablePdbReader.MetadataReader, version, out var handleToIdMap2);
		portablePdbReader.InitializeHandleToIdMaps(handleToIdMap, handleToIdMap2);
		methodExtents.Update(portablePdbReader, lineDeltasByDocument);
		for (int i = 0; i < handleToIdMap2.Length; i++)
		{
			RemoveLineDeltas(handleToIdMap2[i]);
		}
		for (int j = 0; j < lineDeltaCount; j++)
		{
			UpdateLineDeltas(MethodId.FromToken(lineDeltas[j].MethodToken), new MethodLineDeltas(lineDeltas[j].Delta, ImmutableArray<int>.Empty));
		}
		_pdbReaders.Add(portablePdbReader);
		portablePdbReader.SymReader = this;
		return 0;
	}

	private Dictionary<DocumentId, List<(MethodId, int)>> GroupLineDeltasByDocument(SymUnmanagedLineDelta[] lineDeltas, int lineDeltaCount)
	{
		GetMethodMap();
		Dictionary<DocumentId, List<(MethodId, int)>> deltasByDocument = new Dictionary<DocumentId, List<(MethodId, int)>>();
		int i;
		for (i = 0; i < lineDeltaCount; i++)
		{
			int methodToken = lineDeltas[i].MethodToken;
			if (!TryGetDebuggableMethod(methodToken, out var pdbReader, out var handle))
			{
				continue;
			}
			MethodId methodId = MethodId.FromToken(methodToken);
			var (documentHandle, enumerable) = MethodExtents.GetMethodBodyDocuments(pdbReader.MetadataReader, handle);
			if (!documentHandle.IsNil)
			{
				AddExtentForDocument(documentHandle);
				continue;
			}
			foreach (DocumentHandle item in enumerable)
			{
				AddExtentForDocument(item);
			}
			void AddExtentForDocument(DocumentHandle handle2)
			{
				DocumentId documentId = pdbReader.GetDocumentId(handle2);
				if (!deltasByDocument.TryGetValue(documentId, out var value))
				{
					deltasByDocument.Add(documentId, value = new List<(MethodId, int)>());
				}
				value.Add((methodId, lineDeltas[i].Delta));
			}
		}
		return deltasByDocument;
	}

	[PreserveSig]
	public int GetLocalVariableCount(int methodToken, out int count)
	{
		if (TryGetDebuggableMethod(methodToken, out var pdbReader, out var handle))
		{
			count = SymMethod.GetLocalVariableCount(pdbReader.MetadataReader, handle);
			return 0;
		}
		count = 0;
		return -2147467259;
	}

	[PreserveSig]
	public int GetLocalVariables(int methodToken, int bufferLength, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ISymUnmanagedVariable[] variables, out int count)
	{
		if (variables == null)
		{
			count = 0;
			return -2147024809;
		}
		int methodImpl = GetMethodImpl(methodToken, out var method);
		if (methodImpl != 0)
		{
			count = 0;
			return methodImpl;
		}
		int localVariableCount = SymMethod.GetLocalVariableCount(method.MetadataReader, method.DebugHandle);
		if (localVariableCount > (uint)bufferLength)
		{
			count = 0;
			return -2147024888;
		}
		method.AddLocalVariables(variables);
		count = localVariableCount;
		return 0;
	}

	[PreserveSig]
	public int InitializeForEnc()
	{
		GetDocumentMap();
		GetMethodMap();
		GetMethodExtents();
		return 0;
	}

	[PreserveSig]
	public int UpdateMethodLines(int methodToken, [In][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] int[] deltas, int count)
	{
		if (count == 0)
		{
			return 0;
		}
		if (deltas == null)
		{
			return -2147024809;
		}
		if (count < 0 || !TryGetDebuggableMethod(methodToken, out var pdbReader, out var handle))
		{
			return -2147467259;
		}
		ImmutableArray<int> deltas2 = ImmutableArray.Create(deltas, 0, Math.Min(deltas.Length, count));
		MethodExtents methodExtents = GetMethodExtents();
		try
		{
			methodExtents.Update(pdbReader, handle, deltas2, count);
		}
		catch (InvalidInputDataException)
		{
			return -2147467259;
		}
		UpdateLineDeltas(MethodId.FromToken(methodToken), new MethodLineDeltas(0, deltas2));
		return 0;
	}
}
