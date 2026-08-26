using System;

namespace DevX.Cecil
{
	[Flags]
	public enum AssemblyFlags : uint
	{
		PublicKey = 0x1,
		SideBySideCompatible = 0x0,
		Retargetable = 0x100,
		EnableJITcompileTracking = 0x8000,
		DisableJITcompileOptimizer = 0x4000
	}
}
