using System.Collections.Generic;

namespace Wasm.Optimize
{
	public static class FunctionBodyOptimizations_ExtHost
	{
	public static void CompressLocalEntries(this FunctionBody body)
	{
		FunctionBodyOptimizations.CompressLocalEntries(body);
	}
	public static void ExpandLocalEntries(this FunctionBody body)
	{
		FunctionBodyOptimizations.ExpandLocalEntries(body);
	}
	}
}
