using System.Runtime.InteropServices;

namespace Microsoft.DiaSymReader;

[ComImport]
[Guid("EDF3A293-A10D-4F4A-A609-38D5EDE35F89")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[ComVisible(false)]
public interface IMetadataImportProvider
{
	[return: MarshalAs(UnmanagedType.Interface)]
	object GetMetadataImport();
}
