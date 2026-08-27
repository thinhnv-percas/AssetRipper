using System.Collections.Generic;
using Wasm.Instructions;

namespace Wasm.Optimize
{
	public static class WasmFileOptimizations_ExtHost
	{
	public static void Optimize(this WasmFile file)
	{
		WasmFileOptimizations.Optimize(file);
	}
	public static void Optimize(this CodeSection section)
	{
		WasmFileOptimizations.Optimize(section);
	}
	}
}
