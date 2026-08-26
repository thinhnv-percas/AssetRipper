using System.Runtime.InteropServices;

namespace Microsoft.DiaSymReader;

[ComImport]
[Guid("AA544D42-28CB-11d3-BD22-0000F80849BD")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[ComVisible(false)]
public interface ISymUnmanagedBinder
{
	[PreserveSig]
	int GetReaderForFile([MarshalAs(UnmanagedType.Interface)] object metadataImporter, [MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string searchPath, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader reader);

	[PreserveSig]
	int GetReaderFromStream([MarshalAs(UnmanagedType.Interface)] object metadataImporter, [MarshalAs(UnmanagedType.Interface)] object stream, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader reader);
}
