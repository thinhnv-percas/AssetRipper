using System.Runtime.InteropServices;

namespace Microsoft.DiaSymReader;

[ComImport]
[Guid("ACCEE350-89AF-4ccb-8B40-1C2C4C6F9434")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[ComVisible(false)]
public interface ISymUnmanagedBinder2 : ISymUnmanagedBinder
{
	[PreserveSig]
	new int GetReaderForFile([MarshalAs(UnmanagedType.Interface)] object metadataImporter, [MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string searchPath, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader reader);

	[PreserveSig]
	new int GetReaderFromStream([MarshalAs(UnmanagedType.Interface)] object metadataImporter, [MarshalAs(UnmanagedType.Interface)] object stream, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader reader);

	[PreserveSig]
	int GetReaderForFile2([MarshalAs(UnmanagedType.Interface)] object metadataImporter, [MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string searchPath, SymUnmanagedSearchPolicy searchPolicy, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader reader);
}
