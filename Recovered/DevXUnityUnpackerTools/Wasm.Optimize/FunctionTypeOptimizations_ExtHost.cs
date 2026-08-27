using System.Collections.Generic;

namespace Wasm.Optimize
{
	public static class FunctionTypeOptimizations_ExtHost
	{
	public static void RewriteFunctionTypeReferences(this WasmFile file, IDictionary<uint, uint> rewriteMap)
	{
		FunctionTypeOptimizations.RewriteFunctionTypeReferences(file, rewriteMap);
	}
	public static void CompressFunctionTypes(this WasmFile file)
	{
		FunctionTypeOptimizations.CompressFunctionTypes(file);
	}
	}
}
