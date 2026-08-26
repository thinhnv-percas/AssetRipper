using System.Collections.Generic;
using System.Reflection.Metadata;

namespace DecompTools.Decompiler.DebugInfo;

internal class ImportScopeInfo
{
	public readonly ImportScopeInfo Parent;

	public ImportScopeHandle Handle;

	public readonly HashSet<string> Imports = new HashSet<string>();

	public ImportScopeInfo()
	{
		Parent = null;
	}

	public ImportScopeInfo(ImportScopeInfo parent)
	{
		Parent = parent;
	}
}
