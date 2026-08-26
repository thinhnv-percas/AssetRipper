#define DEBUG
using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace dnlib.PE;

internal static class ProcessorArchUtils
{
	private static class RuntimeInformationUtils
	{
		private static Assembly RuntimeInformationAssembly => typeof(object).Assembly;

		private static Type System_Runtime_InteropServices_RuntimeInformation => RuntimeInformationAssembly.GetType("System.Runtime.InteropServices.RuntimeInformation", throwOnError: false);

		public static bool TryGet_RuntimeInformation_Architecture(out Machine machine)
		{
			machine = Machine.Unknown;
			MethodInfo methodInfo = System_Runtime_InteropServices_RuntimeInformation?.GetMethod("get_ProcessArchitecture", Array2.Empty<Type>());
			if (methodInfo == null)
			{
				return false;
			}
			object obj = methodInfo.Invoke(null, Array2.Empty<object>());
			return TryGetArchitecture((int)obj, out machine);
		}

		private static bool TryGetArchitecture(int architecture, out Machine machine)
		{
			switch (architecture)
			{
			case 0:
				Debug.Assert(IntPtr.Size == 4);
				machine = Machine.I386;
				return true;
			case 1:
				Debug.Assert(IntPtr.Size == 8);
				machine = Machine.AMD64;
				return true;
			case 2:
				Debug.Assert(IntPtr.Size == 4);
				machine = Machine.ARMNT;
				return true;
			case 3:
				Debug.Assert(IntPtr.Size == 8);
				machine = Machine.ARM64;
				return true;
			default:
				Debug.Fail($"Unknown process architecture: {architecture}");
				machine = Machine.Unknown;
				return false;
			}
		}
	}

	private static class WindowsUtils
	{
		private struct SYSTEM_INFO
		{
			public ushort wProcessorArchitecture;

			public ushort wReserved;

			public uint dwPageSize;

			public IntPtr lpMinimumApplicationAddress;

			public IntPtr lpMaximumApplicationAddress;

			public IntPtr dwActiveProcessorMask;

			public uint dwNumberOfProcessors;

			public uint dwProcessorType;

			public uint dwAllocationGranularity;

			public ushort wProcessorLevel;

			public ushort wProcessorRevision;
		}

		private enum ProcessorArchitecture : ushort
		{
			INTEL = 0,
			ARM = 5,
			IA64 = 6,
			AMD64 = 9,
			ARM64 = 12,
			UNKNOWN = ushort.MaxValue
		}

		private static bool canTryGetSystemInfo = true;

		[DllImport("kernel32")]
		private static extern void GetSystemInfo(out SYSTEM_INFO lpSystemInfo);

		public static bool TryGetProcessCpuArchitecture(out Machine machine)
		{
			if (canTryGetSystemInfo)
			{
				try
				{
					GetSystemInfo(out var lpSystemInfo);
					switch ((ProcessorArchitecture)lpSystemInfo.wProcessorArchitecture)
					{
					case ProcessorArchitecture.INTEL:
						Debug.Assert(IntPtr.Size == 4);
						machine = Machine.I386;
						return true;
					case ProcessorArchitecture.ARM:
						Debug.Assert(IntPtr.Size == 4);
						machine = Machine.ARMNT;
						return true;
					case ProcessorArchitecture.IA64:
						Debug.Assert(IntPtr.Size == 8);
						machine = Machine.IA64;
						return true;
					case ProcessorArchitecture.AMD64:
						Debug.Assert(IntPtr.Size == 8);
						machine = Machine.AMD64;
						return true;
					case ProcessorArchitecture.ARM64:
						Debug.Assert(IntPtr.Size == 8);
						machine = Machine.ARM64;
						return true;
					}
				}
				catch (EntryPointNotFoundException)
				{
					canTryGetSystemInfo = false;
				}
				catch (DllNotFoundException)
				{
					canTryGetSystemInfo = false;
				}
			}
			machine = Machine.Unknown;
			return false;
		}
	}

	private static Machine cachedMachine = Machine.Unknown;

	public static Machine GetProcessCpuArchitecture()
	{
		if (cachedMachine == Machine.Unknown)
		{
			cachedMachine = GetProcessCpuArchitectureCore();
		}
		return cachedMachine;
	}

	private static Machine GetProcessCpuArchitectureCore()
	{
		if (WindowsUtils.TryGetProcessCpuArchitecture(out var machine))
		{
			return machine;
		}
		try
		{
			if (RuntimeInformationUtils.TryGet_RuntimeInformation_Architecture(out machine))
			{
				return machine;
			}
		}
		catch (PlatformNotSupportedException)
		{
		}
		Debug.WriteLine("Couldn't detect CPU arch, assuming x86 or x64");
		return (IntPtr.Size == 4) ? Machine.I386 : Machine.AMD64;
	}
}
