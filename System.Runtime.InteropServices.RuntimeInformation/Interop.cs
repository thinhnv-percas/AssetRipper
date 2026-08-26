using System;
using System.Runtime.InteropServices;

internal static class Interop
{
	internal class NtDll
	{
		internal struct RTL_OSVERSIONINFOEX
		{
			internal uint dwOSVersionInfoSize;

			internal uint dwMajorVersion;

			internal uint dwMinorVersion;

			internal uint dwBuildNumber;

			internal uint dwPlatformId;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
			internal string szCSDVersion;
		}

		[DllImport("ntdll.dll")]
		private static extern int RtlGetVersion(out RTL_OSVERSIONINFOEX lpVersionInformation);

		internal static string RtlGetVersion()
		{
			RTL_OSVERSIONINFOEX lpVersionInformation = default(RTL_OSVERSIONINFOEX);
			lpVersionInformation.dwOSVersionInfoSize = (uint)Marshal.SizeOf(lpVersionInformation);
			if (RtlGetVersion(out lpVersionInformation) == 0)
			{
				return string.Format("{0} {1}.{2}.{3} {4}", "Microsoft Windows", lpVersionInformation.dwMajorVersion, lpVersionInformation.dwMinorVersion, lpVersionInformation.dwBuildNumber, lpVersionInformation.szCSDVersion);
			}
			return "Microsoft Windows";
		}
	}

	internal static class Libraries
	{
		internal const string Advapi32 = "advapi32.dll";

		internal const string BCrypt = "BCrypt.dll";

		internal const string Crypt32 = "crypt32.dll";

		internal const string Error_L1 = "api-ms-win-core-winrt-error-l1-1-0.dll";

		internal const string HttpApi = "httpapi.dll";

		internal const string IpHlpApi = "iphlpapi.dll";

		internal const string Kernel32 = "kernel32.dll";

		internal const string Memory_L1_3 = "api-ms-win-core-memory-l1-1-3.dll";

		internal const string Mswsock = "mswsock.dll";

		internal const string NCrypt = "ncrypt.dll";

		internal const string NtDll = "ntdll.dll";

		internal const string OleAut32 = "oleaut32.dll";

		internal const string RoBuffer = "api-ms-win-core-winrt-robuffer-l1-1-0.dll";

		internal const string Secur32 = "secur32.dll";

		internal const string Shell32 = "shell32.dll";

		internal const string SspiCli = "sspicli.dll";

		internal const string User32 = "user32.dll";

		internal const string Version = "version.dll";

		internal const string WebSocket = "websocket.dll";

		internal const string WinHttp = "winhttp.dll";

		internal const string Ws2_32 = "ws2_32.dll";

		internal const string Zlib = "clrcompression.dll";
	}

	internal class Kernel32
	{
		internal struct SYSTEM_INFO
		{
			internal ushort wProcessorArchitecture;

			internal ushort wReserved;

			internal int dwPageSize;

			internal IntPtr lpMinimumApplicationAddress;

			internal IntPtr lpMaximumApplicationAddress;

			internal IntPtr dwActiveProcessorMask;

			internal int dwNumberOfProcessors;

			internal int dwProcessorType;

			internal int dwAllocationGranularity;

			internal short wProcessorLevel;

			internal short wProcessorRevision;
		}

		internal enum ProcessorArchitecture : ushort
		{
			Processor_Architecture_INTEL = 0,
			Processor_Architecture_ARM = 5,
			Processor_Architecture_IA64 = 6,
			Processor_Architecture_AMD64 = 9,
			Processor_Architecture_ARM64 = 12,
			Processor_Architecture_UNKNOWN = ushort.MaxValue
		}

		[DllImport("kernel32.dll")]
		internal static extern void GetNativeSystemInfo(out SYSTEM_INFO lpSystemInfo);

		[DllImport("kernel32.dll")]
		internal static extern void GetSystemInfo(out SYSTEM_INFO lpSystemInfo);
	}
}
