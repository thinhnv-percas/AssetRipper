using System.Runtime.InteropServices;

namespace Microsoft.DiaSymReader;

[ComImport]
[Guid("997DD0CC-A76F-4c82-8D79-EA87559D27AD")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[ComVisible(false)]
public interface ISymUnmanagedSourceServerModule
{
	[PreserveSig]
	unsafe int GetSourceServerData(out int length, out byte* data);
}
