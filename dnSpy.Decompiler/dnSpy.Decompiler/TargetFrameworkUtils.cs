#define DEBUG
using System.Diagnostics;
using dnlib.DotNet;
using dnlib.PE;
using dnSpy.Decompiler.Properties;

namespace dnSpy.Decompiler;

internal static class TargetFrameworkUtils
{
	public static string GetArchString(ModuleDef module)
	{
		if (module == null)
		{
			return "???";
		}
		if (module.Machine.IsI386())
		{
			switch ((module.Is32BitRequired ? 2 : 0) + (module.Is32BitPreferred ? 1 : 0))
			{
			case 0:
				if (!module.IsILOnly)
				{
					return "x86";
				}
				return dnSpy_Decompiler_Resources.Decompile_AnyCPU64BitPreferred;
			case 1:
				return "???";
			case 2:
				return "x86";
			case 3:
				return dnSpy_Decompiler_Resources.Decompile_AnyCPU32BitPreferred;
			}
		}
		return GetArchString(module.Machine);
	}

	public static string GetArchString(Machine machine)
	{
		if (machine.IsI386())
		{
			return "x86";
		}
		if (machine.IsAMD64())
		{
			return "x64";
		}
		if (machine == Machine.IA64)
		{
			return "IA-64";
		}
		if (machine.IsARMNT())
		{
			return "ARM";
		}
		if (machine.IsARM64())
		{
			return "ARM64";
		}
		Debug.Fail("Unknown machine");
		return machine.ToString();
	}
}
