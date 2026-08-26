using System;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation;

[Serializable]
public sealed class DefaultAssemblyReference : IAssemblyReference, ISupportsInterning
{
	[Serializable]
	private sealed class CurrentAssemblyReference : IAssemblyReference
	{
		public IAssembly Resolve(ITypeResolveContext context)
		{
			IAssembly currentAssembly = context.CurrentAssembly;
			if (currentAssembly == null)
			{
				throw new ArgumentException("A reference to the current assembly cannot be resolved in the compilation's global type resolve context.");
			}
			return currentAssembly;
		}
	}

	public static readonly IAssemblyReference CurrentAssembly = new CurrentAssemblyReference();

	[Obsolete("The corlib is not always called 'mscorlib' (as returned by this property), but might be 'System.Runtime'.")]
	public static readonly IAssemblyReference Corlib = new DefaultAssemblyReference("mscorlib");

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

	public IAssembly Resolve(ITypeResolveContext context)
	{
		IAssembly currentAssembly = context.CurrentAssembly;
		if (currentAssembly != null && string.Equals(shortName, currentAssembly.AssemblyName, StringComparison.OrdinalIgnoreCase))
		{
			return currentAssembly;
		}
		foreach (IAssembly assembly in context.Compilation.Assemblies)
		{
			if (string.Equals(shortName, assembly.AssemblyName, StringComparison.OrdinalIgnoreCase))
			{
				return assembly;
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
		if (other is DefaultAssemblyReference defaultAssemblyReference)
		{
			return shortName == defaultAssemblyReference.shortName;
		}
		return false;
	}
}
