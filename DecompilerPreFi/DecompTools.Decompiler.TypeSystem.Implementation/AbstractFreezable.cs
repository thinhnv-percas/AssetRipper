using System;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

[Serializable]
public abstract class AbstractFreezable : IFreezable
{
	private bool isFrozen;

	public bool IsFrozen => isFrozen;

	public void Freeze()
	{
		if (!isFrozen)
		{
			FreezeInternal();
			isFrozen = true;
		}
	}

	protected virtual void FreezeInternal()
	{
	}
}
