using System.Runtime.InteropServices;

namespace Microsoft.DiaSymReader;

[ComImport]
[Guid("969708D2-05E5-4861-A3B0-96E473CDF63F")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[ComVisible(false)]
public interface ISymUnmanagedDispose
{
	[PreserveSig]
	int Destroy();
}
