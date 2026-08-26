using System.Threading;
using Mon3.Collections.Generic;

namespace Mon3.Cecil.Cil;

public sealed class ImportDebugInformation : DebugInformation
{
	internal ImportDebugInformation parent;

	internal Collection<ImportTarget> targets;

	public bool HasTargets => !targets.IsNullOrEmpty();

	public Collection<ImportTarget> Targets
	{
		get
		{
			if (targets == null)
			{
				Interlocked.CompareExchange(ref targets, new Collection<ImportTarget>(), null);
			}
			return targets;
		}
	}

	public ImportDebugInformation Parent
	{
		get
		{
			return parent;
		}
		set
		{
			parent = value;
		}
	}

	public ImportDebugInformation()
	{
		token = new MetadataToken(TokenType.ImportScope);
	}
}
