using System;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

[Serializable]
public sealed class DefaultAssemblyReference : IModuleReference, ISupportsInterning
{
	[Serializable]
	private sealed class CurrentModuleReference : IModuleReference
	{
		public IModule Resolve(ITypeResolveContext context)
		{
			IModule currentModule = context.CurrentModule;
			if (currentModule == null)
			{
				throw new ArgumentException("A reference to the current assembly cannot be resolved in the compilation's global type resolve context.");
			}
			return currentModule;
		}
	}

	public static readonly IModuleReference CurrentAssembly = new CurrentModuleReference();

	private readonly string shortName;

	public DefaultAssemblyReference(string assemblyName)
	{
		int num = assemblyName?.IndexOf(',') ?? (-1);
		if (num >= 0)
		{
			shortName = assemblyName.Substring(0, num);
		}
		else
		{
			shortName = assemblyName;
		}
	}

	public IModule Resolve(ITypeResolveContext context)
	{
		IModule currentModule = context.CurrentModule;
		if (currentModule != null && string.Equals(shortName, currentModule.AssemblyName, StringComparison.OrdinalIgnoreCase))
		{
			return currentModule;
		}
		foreach (IModule module in context.Compilation.Modules)
		{
			if (string.Equals(shortName, module.AssemblyName, StringComparison.OrdinalIgnoreCase))
			{
				return module;
			}
		}
		return null;
	}

	public override string ToString()
	{
		return shortName;
	}

	int ISupportsInterning.GetHashCodeForInterning()
	{
		return shortName.GetHashCode();
	}

	bool ISupportsInterning.EqualsForInterning(ISupportsInterning other)
	{
		return other is DefaultAssemblyReference defaultAssemblyReference && shortName == defaultAssemblyReference.shortName;
	}
}
