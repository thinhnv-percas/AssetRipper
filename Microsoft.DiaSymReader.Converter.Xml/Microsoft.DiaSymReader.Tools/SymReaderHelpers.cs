using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.DiaSymReader.Tools;

internal static class SymReaderHelpers
{
	internal static readonly Guid VisualBasicLanguageGuid = new Guid("3a12d0b8-c26c-11d0-b442-00a0244a1dd2");

	internal static bool IsPortable(Stream pdbStream)
	{
		pdbStream.Position = 0L;
		bool result = pdbStream.ReadByte() == 66 && pdbStream.ReadByte() == 83 && pdbStream.ReadByte() == 74 && pdbStream.ReadByte() == 66;
		pdbStream.Position = 0L;
		return result;
	}

	public static ISymUnmanagedReader5 CreateWindowsPdbReader(Stream pdbStream)
	{
		return SymUnmanagedReaderFactory.CreateReader<ISymUnmanagedReader5>(pdbStream, DummySymReaderMetadataProvider.Instance);
	}

	public static ISymUnmanagedReader5 CreateWindowsPdbReader(Stream pdbStream, PEReader peReader)
	{
		return CreateWindowsPdbReader(pdbStream, peReader.GetMetadataReader());
	}

	public static ISymUnmanagedReader5 CreateWindowsPdbReader(Stream pdbStream, MetadataReader metadataReader)
	{
		return SymUnmanagedReaderFactory.CreateReader<ISymUnmanagedReader5>(pdbStream, new SymMetadataProvider(metadataReader));
	}

	public static ImmutableArray<string> GetImportStrings(ISymUnmanagedReader reader, int methodToken, int methodVersion)
	{
		ISymUnmanagedMethod methodByVersion = reader.GetMethodByVersion(methodToken, methodVersion);
		if (methodByVersion == null)
		{
			return ImmutableArray<string>.Empty;
		}
		ISymUnmanagedScope rootScope = methodByVersion.GetRootScope();
		if (rootScope == null)
		{
			return ImmutableArray<string>.Empty;
		}
		ISymUnmanagedScope[] children = rootScope.GetChildren();
		if (children.Length == 0)
		{
			return ImmutableArray<string>.Empty;
		}
		ISymUnmanagedNamespace[] namespaces = children[0].GetNamespaces();
		if (namespaces.Length == 0)
		{
			return ImmutableArray<string>.Empty;
		}
		return ImmutableArray.CreateRange(Enumerable.Select<ISymUnmanagedNamespace, string>((IEnumerable<ISymUnmanagedNamespace>)namespaces, (Func<ISymUnmanagedNamespace, string>)((ISymUnmanagedNamespace n) => n.GetName())));
	}

	public static bool TryReadPdbId(PEReader peReader, out BlobContentId id, out int age)
	{
		DebugDirectoryEntry entry = peReader.ReadDebugDirectory().LastOrDefault((DebugDirectoryEntry debugDirectoryEntry) => debugDirectoryEntry.Type == DebugDirectoryEntryType.CodeView);
		if (entry.DataSize == 0)
		{
			id = default(BlobContentId);
			age = 0;
			return false;
		}
		CodeViewDebugDirectoryData codeViewDebugDirectoryData = peReader.ReadCodeViewDebugDirectoryData(entry);
		id = new BlobContentId(codeViewDebugDirectoryData.Guid, entry.Stamp);
		age = codeViewDebugDirectoryData.Age;
		return true;
	}

	public static void GetWindowsPdbSignature(ImmutableArray<byte> bytes, out Guid guid, out uint timestamp, out int age)
	{
		byte[] array = new byte[16];
		bytes.CopyTo(0, array, 0, array.Length);
		guid = new Guid(array);
		int num = array.Length;
		timestamp = (uint)((bytes[num + 3] << 24) | (bytes[num + 2] << 16) | (bytes[num + 1] << 8) | bytes[num]);
		age = 1;
	}

	private unsafe static byte[] GetBytes(byte* data, int size)
	{
		byte[] array = new byte[size];
		Marshal.Copy((IntPtr)data, array, 0, array.Length);
		return array;
	}

	private unsafe static string GetString(byte* data, int size)
	{
		return Encoding.UTF8.GetString(data, size);
	}

	public unsafe static string GetSourceLinkData(this ISymUnmanagedReader5 reader)
	{
		if (!TryGetSourceLinkData(reader, out var data, out var size))
		{
			return null;
		}
		return GetString(data, size);
	}

	public unsafe static byte[] GetRawSourceLinkData(this ISymUnmanagedReader5 reader)
	{
		if (!TryGetSourceLinkData(reader, out var data, out var size))
		{
			return null;
		}
		return GetBytes(data, size);
	}

	private unsafe static bool TryGetSourceLinkData(ISymUnmanagedReader5 reader, out byte* data, out int size)
	{
		int sourceServerData = reader.GetSourceServerData(out data, out size);
		Marshal.ThrowExceptionForHR(sourceServerData);
		return sourceServerData != 1;
	}

	public unsafe static byte[] GetRawSourceServerData(this ISymUnmanagedReader reader)
	{
		if (!(reader is ISymUnmanagedSourceServerModule symUnmanagedSourceServerModule))
		{
			return null;
		}
		int length = 0;
		byte* data = null;
		try
		{
			return (symUnmanagedSourceServerModule.GetSourceServerData(out length, out data) == 0) ? GetBytes(data, length) : null;
		}
		finally
		{
			if (data != null)
			{
				Marshal.FreeCoTaskMem((IntPtr)data);
			}
		}
	}

	public unsafe static string GetSourceServerData(this ISymUnmanagedReader reader)
	{
		if (!(reader is ISymUnmanagedSourceServerModule symUnmanagedSourceServerModule))
		{
			return null;
		}
		int length = 0;
		byte* data = null;
		try
		{
			return (symUnmanagedSourceServerModule.GetSourceServerData(out length, out data) == 0) ? GetString(data, length) : null;
		}
		finally
		{
			if (data != null)
			{
				Marshal.FreeCoTaskMem((IntPtr)data);
			}
		}
	}

	public static byte[] GetRawEmbeddedSource(this ISymUnmanagedDocument document)
	{
		Marshal.ThrowExceptionForHR(document.GetSourceLength(out var length));
		if (length == 0)
		{
			return null;
		}
		if (length < 4)
		{
			throw new InvalidDataException();
		}
		byte[] array = new byte[length];
		Marshal.ThrowExceptionForHR(document.GetSourceRange(0, 0, int.MaxValue, int.MaxValue, length, out var count, array));
		if (count < 4 || count > array.Length)
		{
			throw new InvalidDataException();
		}
		return array;
	}
}
