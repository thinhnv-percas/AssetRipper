using System.Collections.Generic;
using System.Linq;

namespace System.Composition.Hosting.Core;

public abstract class DependencyAccessor
{
	protected abstract IEnumerable<ExportDescriptorPromise> GetPromises(CompositionContract exportKey);

	public IEnumerable<CompositionDependency> ResolveDependencies(object site, CompositionContract contract, bool isPrerequisite)
	{
		ExportDescriptorPromise[] array = GetPromises(contract).ToArray();
		CompositionDependency[] array2 = new CompositionDependency[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = CompositionDependency.Satisfied(contract, array[i], isPrerequisite, site);
		}
		return array2;
	}

	public CompositionDependency ResolveRequiredDependency(object site, CompositionContract contract, bool isPrerequisite)
	{
		if (!TryResolveOptionalDependency(site, contract, isPrerequisite, out var dependency))
		{
			return CompositionDependency.Missing(contract, site);
		}
		return dependency;
	}

	public bool TryResolveOptionalDependency(object site, CompositionContract contract, bool isPrerequisite, out CompositionDependency dependency)
	{
		ExportDescriptorPromise[] array = GetPromises(contract).ToArray();
		if (array.Length == 0)
		{
			dependency = null;
			return false;
		}
		if (array.Length != 1)
		{
			dependency = CompositionDependency.Oversupplied(contract, array, site);
			return true;
		}
		dependency = CompositionDependency.Satisfied(contract, array[0], isPrerequisite, site);
		return true;
	}
}
