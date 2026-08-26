using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Microsoft.DiaSymReader.PortablePdb;

[Guid("E4B18DEF-3B78-46AE-8F50-E67E421BDF70")]
[ComVisible(true)]
public sealed class SymBinder : ISymUnmanagedBinder4, ISymUnmanagedBinder3, ISymUnmanagedBinder2, ISymUnmanagedBinder
{
	private static readonly char[] s_searchPathSeparators = new char[1] { ';' };

	[PreserveSig]
	public int GetReaderForFile([MarshalAs(UnmanagedType.Interface)] object metadataImport, [MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string searchPath, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader reader)
	{
		return GetReaderForFile2(metadataImport, fileName, searchPath, SymUnmanagedSearchPolicy.AllowReferencePathAccess, out reader);
	}

	[PreserveSig]
	public int GetReaderForFile2([MarshalAs(UnmanagedType.Interface)] object metadataImport, [MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string searchPath, SymUnmanagedSearchPolicy searchPolicy, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader reader)
	{
		reader = null;
		try
		{
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentException(null, "fileName");
			}
			MetadataImport metadataImport2 = MetadataImport.FromObject(metadataImport) ?? throw new ArgumentException(null, "metadataImport");
			if (!TryReadCodeViewData(fileName, out var codeViewData, out var stamp))
			{
				return -2147467259;
			}
			Guid guid = codeViewData.Guid;
			int age = codeViewData.Age;
			string fileName2 = Path.GetFileName(codeViewData.Path);
			LazyMetadataImport metadataImport3 = new LazyMetadataImport(metadataImport2);
			if ((searchPolicy & SymUnmanagedSearchPolicy.AllowReferencePathAccess) != 0)
			{
				string directoryName = Path.GetDirectoryName(fileName);
				string pdbFilePath = Path.Combine(new string[2] { directoryName, fileName2 });
				if (TryCreateReaderForMatchingPdb(pdbFilePath, guid, stamp, age, metadataImport3, out reader))
				{
					return 0;
				}
			}
			if ((searchPolicy & SymUnmanagedSearchPolicy.AllowOriginalPathAccess) != 0 && TryCreateReaderForMatchingPdb(codeViewData.Path, guid, stamp, age, metadataImport3, out reader))
			{
				return 0;
			}
			string peFileExtension = Path.GetExtension(fileName).TrimStart(new char[1] { '.' });
			foreach (string item in GetSearchPathsSequence(searchPath, searchPolicy))
			{
				if (TryFindMatchingPdb(item, peFileExtension, fileName2, guid, stamp, age, metadataImport3, searchPolicy, out reader))
				{
					return 0;
				}
			}
			return -2140340219;
		}
		finally
		{
			InteropUtilities.TransferOwnershipOrRelease(ref metadataImport, reader);
		}
	}

	private static IEnumerable<string> GetSearchPathsSequence(string searchPath, SymUnmanagedSearchPolicy searchPolicy)
	{
		yield return searchPath;
		_ = searchPolicy & SymUnmanagedSearchPolicy.AllowRegistryAccess;
		yield return PortableShim.Environment.GetEnvironmentVariable("_NT_ALT_SYMBOL_PATH");
		yield return PortableShim.Environment.GetEnvironmentVariable("_NT_SYMBOL_PATH");
		yield return PortableShim.Environment.GetEnvironmentVariable("SystemRoot");
	}

	private static IEnumerable<string> GetSearchPathSubdirectories(string searchPath, string peFileExtension)
	{
		yield return Path.Combine(new string[3] { searchPath, "symbols", peFileExtension });
		yield return Path.Combine(new string[2] { searchPath, peFileExtension });
		if (peFileExtension.Length > 0)
		{
			yield return Path.Combine(searchPath);
		}
	}

	private bool TryFindMatchingPdb(string searchPaths, string peFileExtension, string pdbFileName, Guid guid, uint stamp, int age, LazyMetadataImport metadataImport, SymUnmanagedSearchPolicy searchPolicy, out ISymUnmanagedReader reader)
	{
		if (searchPaths == null)
		{
			reader = null;
			return false;
		}
		string[] array = searchPaths.Split(s_searchPathSeparators, StringSplitOptions.RemoveEmptyEntries);
		foreach (string text in array)
		{
			if (text.StartsWith("SRV*", StringComparison.OrdinalIgnoreCase) || text.StartsWith("SYMSRV*", StringComparison.OrdinalIgnoreCase) || text.StartsWith("CACHE*", StringComparison.OrdinalIgnoreCase))
			{
				continue;
			}
			foreach (string searchPathSubdirectory in GetSearchPathSubdirectories(text, peFileExtension))
			{
				if (TryCreateReaderForMatchingPdb(Path.Combine(new string[2] { searchPathSubdirectory, pdbFileName }), guid, stamp, age, metadataImport, out reader))
				{
					return true;
				}
			}
		}
		reader = null;
		return false;
	}

	private bool TryCreateReaderForMatchingPdb(string pdbFilePath, Guid guid, uint stamp, int age, LazyMetadataImport metadataImport, out ISymUnmanagedReader reader)
	{
		if (PortableShim.File.Exists(pdbFilePath))
		{
			PortablePdbReader portablePdbReader;
			try
			{
				portablePdbReader = new PortablePdbReader(SymReader.CreateProviderFromFile(pdbFilePath), 1, 0);
			}
			catch
			{
				reader = null;
				return false;
			}
			try
			{
				if (portablePdbReader.MatchesModule(guid, stamp, age))
				{
					reader = new SymReader(portablePdbReader, metadataImport);
					portablePdbReader = null;
					return true;
				}
			}
			finally
			{
				portablePdbReader?.Dispose();
			}
		}
		reader = null;
		return false;
	}

	private bool TryReadCodeViewData(string peFilePath, out CodeViewDebugDirectoryData codeViewData, out uint stamp)
	{
		try
		{
			using PEReader pEReader = new PEReader(PortableShim.FileStream.CreateReadShareDelete(peFilePath));
			foreach (DebugDirectoryEntry item in pEReader.ReadDebugDirectory())
			{
				if (item.Type == DebugDirectoryEntryType.CodeView)
				{
					codeViewData = pEReader.ReadCodeViewDebugDirectoryData(item);
					stamp = item.Stamp;
					return true;
				}
			}
		}
		catch
		{
		}
		codeViewData = default(CodeViewDebugDirectoryData);
		stamp = 0u;
		return false;
	}

	[PreserveSig]
	public int GetReaderFromStream([MarshalAs(UnmanagedType.Interface)] object metadataImport, [MarshalAs(UnmanagedType.Interface)] object stream, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader reader)
	{
		reader = null;
		try
		{
			IStream stream2 = (stream as IStream) ?? throw new ArgumentNullException(null, "stream");
			MetadataImport metadataImport2 = MetadataImport.FromObject(metadataImport) ?? throw new ArgumentException(null, "metadataImport");
			reader = SymReader.CreateFromStream(stream2, new LazyMetadataImport(metadataImport2));
			return 0;
		}
		finally
		{
			InteropUtilities.TransferOwnershipOrRelease(ref metadataImport, reader);
		}
	}

	[PreserveSig]
	public int GetReaderFromCallback([In][MarshalAs(UnmanagedType.Interface)] object metadataImport, [MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string searchPath, SymUnmanagedSearchPolicy searchPolicy, [In][MarshalAs(UnmanagedType.Interface)] object callback, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader reader)
	{
		throw new NotImplementedException();
	}

	[PreserveSig]
	public int GetReaderFromPdbFile([MarshalAs(UnmanagedType.Interface)] IMetadataImportProvider metadataImportProvider, [MarshalAs(UnmanagedType.LPWStr)] string pdbFilePath, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader reader)
	{
		if (metadataImportProvider == null)
		{
			throw new ArgumentException(null, "metadataImportProvider");
		}
		if (string.IsNullOrEmpty(pdbFilePath))
		{
			throw new ArgumentException(null, "pdbFilePath");
		}
		reader = SymReader.CreateFromFile(pdbFilePath, new LazyMetadataImport(metadataImportProvider));
		return 0;
	}

	[PreserveSig]
	public int GetReaderFromPdbStream([MarshalAs(UnmanagedType.Interface)] IMetadataImportProvider metadataImportProvider, [MarshalAs(UnmanagedType.Interface)] object stream, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader reader)
	{
		IStream stream2 = (stream as IStream) ?? throw new ArgumentException(null, "stream");
		if (metadataImportProvider == null)
		{
			throw new ArgumentException(null, "metadataImportProvider");
		}
		reader = SymReader.CreateFromStream(stream2, new LazyMetadataImport(metadataImportProvider));
		return 0;
	}
}
