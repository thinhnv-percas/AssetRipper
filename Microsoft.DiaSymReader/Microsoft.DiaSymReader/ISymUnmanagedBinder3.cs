using System.Runtime.InteropServices;

namespace Microsoft.DiaSymReader;

[ComImport]
[Guid("28AD3D43-B601-4d26-8A1B-25F9165AF9D7")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[ComVisible(false)]
public interface ISymUnmanagedBinder3 : ISymUnmanagedBinder2, ISymUnmanagedBinder
{
	[PreserveSig]
	new int GetReaderForFile([MarshalAs(UnmanagedType.Interface)] object metadataImporter, [MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string searchPath, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader reader);

	[PreserveSig]
	new int GetReaderFromStream([MarshalAs(UnmanagedType.Interface)] object metadataImporter, [MarshalAs(UnmanagedType.Interface)] object stream, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader reader);

	[PreserveSig]
	new int GetReaderForFile2([MarshalAs(UnmanagedType.Interface)] object metadataImporter, [MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string searchPath, SymUnmanagedSearchPolicy searchPolicy, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader reader);

	[PreserveSig]
	int GetReaderFromCallback([In][MarshalAs(UnmanagedType.Interface)] object metadataImporter, [MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string searchPath, SymUnmanagedSearchPolicy searchPolicy, [In][MarshalAs(UnmanagedType.Interface)] object callback, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedReader reader);
}
