using System.Collections.Generic;
using System.Composition.Hosting.Properties;
using System.Linq;
using System.Text;
using Microsoft.Internal;

namespace System.Composition.Hosting.Core;

internal class ExportDescriptorRegistryUpdate : DependencyAccessor
{
	private readonly IDictionary<CompositionContract, ExportDescriptor[]> _partDefinitions;

	private readonly ExportDescriptorProvider[] _exportDescriptorProviders;

	private readonly IDictionary<CompositionContract, UpdateResult> _updateResults = new Dictionary<CompositionContract, UpdateResult>();

	private static readonly CompositionDependency[] s_noDependenciesValue = EmptyArray<CompositionDependency>.Value;

	private static readonly Func<CompositionDependency[]> s_noDependencies = () => s_noDependenciesValue;

	private bool _updateFinished;

	public ExportDescriptorRegistryUpdate(IDictionary<CompositionContract, ExportDescriptor[]> partDefinitions, ExportDescriptorProvider[] exportDescriptorProviders)
	{
		_partDefinitions = partDefinitions;
		_exportDescriptorProviders = exportDescriptorProviders;
	}

	public void Execute(CompositionContract contract)
	{
		if (_updateFinished)
		{
			throw new InvalidOperationException("The update has already executed.");
		}
		if (TryResolveOptionalDependency("initial request", contract, isPrerequisite: true, out var dependency))
		{
			HashSet<ExportDescriptorPromise> hashSet = new HashSet<ExportDescriptorPromise>();
			Stack<CompositionDependency> checking = new Stack<CompositionDependency>();
			CheckTarget(dependency, hashSet, checking);
		}
		_updateFinished = true;
		foreach (KeyValuePair<CompositionContract, UpdateResult> updateResult in _updateResults)
		{
			CompositionContract key = updateResult.Key;
			ExportDescriptor[] value = (from cb in updateResult.Value.GetResults()
				select cb.GetDescriptor()).ToArray();
			_partDefinitions.Add(key, value);
		}
	}

	private void CheckTarget(CompositionDependency dependency, HashSet<ExportDescriptorPromise> @checked, Stack<CompositionDependency> checking)
	{
		if (dependency.IsError)
		{
			StringBuilder stringBuilder = new StringBuilder();
			dependency.DescribeError(stringBuilder);
			stringBuilder.AppendLine();
			stringBuilder.Append(DescribeCompositionStack(dependency, checking));
			throw ThrowHelper.CompositionException(stringBuilder.ToString());
		}
		if (@checked.Contains(dependency.Target))
		{
			return;
		}
		@checked.Add(dependency.Target);
		checking.Push(dependency);
		foreach (CompositionDependency dependency2 in dependency.Target.Dependencies)
		{
			CheckDependency(dependency2, @checked, checking);
		}
		checking.Pop();
	}

	private void CheckDependency(CompositionDependency dependency, HashSet<ExportDescriptorPromise> @checked, Stack<CompositionDependency> checking)
	{
		if (@checked.Contains(dependency.Target))
		{
			bool flag = false;
			bool flag2 = !dependency.IsPrerequisite;
			foreach (CompositionDependency item in checking)
			{
				if (item.Target.IsShared)
				{
					flag = true;
				}
				if (flag & flag2)
				{
					break;
				}
				if (item.Target.Equals(dependency.Target))
				{
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.AppendFormat(System.Composition.Hosting.Properties.Resources.ExportDescriptor_UnsupportedCycle, new object[1] { dependency.Target.Origin });
					stringBuilder.AppendLine();
					stringBuilder.Append(DescribeCompositionStack(dependency, checking));
					throw ThrowHelper.CompositionException(stringBuilder.ToString());
				}
				if (!item.IsPrerequisite)
				{
					flag2 = true;
				}
			}
		}
		CheckTarget(dependency, @checked, checking);
	}

	private StringBuilder DescribeCompositionStack(CompositionDependency import, IEnumerable<CompositionDependency> dependencies)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (dependencies.FirstOrDefault() == null)
		{
			return stringBuilder;
		}
		foreach (CompositionDependency dependency in dependencies)
		{
			stringBuilder.AppendFormat(System.Composition.Hosting.Properties.Resources.ExportDescriptor_DependencyErrorLine, new object[2]
			{
				import.Site,
				dependency.Target.Origin
			});
			stringBuilder.AppendLine();
			import = dependency;
		}
		stringBuilder.AppendFormat(System.Composition.Hosting.Properties.Resources.ExportDescriptor_DependencyErrorContract, new object[1] { import.Contract });
		return stringBuilder;
	}

	protected override IEnumerable<ExportDescriptorPromise> GetPromises(CompositionContract contract)
	{
		Microsoft.Internal.Assumes.IsTrue(!_updateFinished, "Update is finished - dependencies should have been requested earlier.");
		if (_partDefinitions.TryGetValue(contract, out var value))
		{
			return value.Select((ExportDescriptor d) => new ExportDescriptorPromise(contract, "Preexisting", isShared: false, s_noDependencies, (IEnumerable<CompositionDependency> _) => d)).ToArray();
		}
		if (!_updateResults.TryGetValue(contract, out var value2))
		{
			value2 = new UpdateResult(_exportDescriptorProviders);
			_updateResults.Add(contract, value2);
		}
		ExportDescriptorProvider provider;
		while (value2.TryDequeueNextProvider(out provider))
		{
			IEnumerable<ExportDescriptorPromise> exportDescriptors = provider.GetExportDescriptors(contract, this);
			foreach (ExportDescriptorPromise item in exportDescriptors)
			{
				value2.AddPromise(item);
			}
		}
		return value2.GetResults();
	}
}
