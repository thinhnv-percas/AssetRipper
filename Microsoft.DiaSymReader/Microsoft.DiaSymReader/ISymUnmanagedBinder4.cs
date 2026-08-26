using System.Runtime.InteropServices;

namespace Microsoft.DiaSymReader;

[ComImport]
[Guid("F1DC5735-F877-48C9-BBE7-2A5486E84D7C")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[ComVisible(false)]
public interface ISymUnmanagedBinder4 : ISymUnmanagedBinder3, ISymUnmanagedBinder2, ISymUnmanagedBinder
{
	[PreserveSig]
	new int GetReaderForFile([MarshalAs(UnmanagedType.Interface)] object metadataImporter, [MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string searchPath, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader reader);

	[PreserveSig]
	new int GetReaderFromStream([MarshalAs(UnmanagedType.Interface)] object metadataImporter, [MarshalAs(UnmanagedType.Interface)] object stream, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader reader);

	[PreserveSig]
	new int GetReaderForFile2([MarshalAs(UnmanagedType.Interface)] object metadataImporter, [MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string searchPath, SymUnmanagedSearchPolicy searchPolicy, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader reader);

	[PreserveSig]
	new int GetReaderFromCallback([In][MarshalAs(UnmanagedType.Interface)] object metadataImporter, [MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string searchPath, SymUnmanagedSearchPolicy searchPolicy, [In][MarshalAs(UnmanagedType.Interface)] object callback, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader reader);

	[PreserveSig]
	int GetReaderFromPdbFile([MarshalAs(UnmanagedType.Interface)] IMetadataImportProvider metadataImportProvider, [MarshalAs(UnmanagedType.LPWStr)] string pdbFilePath, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader reader);

	[PreserveSig]
	int GetReaderFromPdbStream([MarshalAs(UnmanagedType.Interface)] IMetadataImportProvider metadataImportProvider, [MarshalAs(UnmanagedType.Interface)] object stream, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader reader);
}
