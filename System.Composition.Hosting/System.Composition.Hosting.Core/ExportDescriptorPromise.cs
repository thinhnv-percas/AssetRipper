using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Composition.Hosting.Properties;
using System.Linq;
using Microsoft.Internal;

namespace System.Composition.Hosting.Core;

public class ExportDescriptorPromise
{
	private readonly string _origin;

	private readonly bool _isShared;

	private readonly Lazy<ReadOnlyCollection<CompositionDependency>> _dependencies;

	private readonly Lazy<ExportDescriptor> _descriptor;

	private readonly CompositionContract _contract;

	private bool _creating;

	public string Origin => _origin;

	public bool IsShared => _isShared;

	public ReadOnlyCollection<CompositionDependency> Dependencies => _dependencies.Value;

	public CompositionContract Contract => _contract;

	public ExportDescriptorPromise(CompositionContract contract, string origin, bool isShared, Func<IEnumerable<CompositionDependency>> dependencies, Func<IEnumerable<CompositionDependency>, ExportDescriptor> getDescriptor)
	{
		ExportDescriptorPromise exportDescriptorPromise = this;
		_contract = contract;
		_origin = origin;
		_isShared = isShared;
		_dependencies = new Lazy<ReadOnlyCollection<CompositionDependency>>(() => new ReadOnlyCollection<CompositionDependency>(dependencies().ToList()), isThreadSafe: false);
		_descriptor = new Lazy<ExportDescriptor>(() => getDescriptor(exportDescriptorPromise._dependencies.Value), isThreadSafe: false);
	}

	public ExportDescriptor GetDescriptor()
	{
		if (_creating && !_descriptor.IsValueCreated)
		{
			return new CycleBreakingExportDescriptor(_descriptor);
		}
		_creating = true;
		try
		{
			ExportDescriptor value = _descriptor.Value;
			Microsoft.Internal.Assumes.IsTrue(value != null, "Export descriptor fulfillment function returned null.");
			return value;
		}
		finally
		{
			_creating = false;
		}
	}

	public override string ToString()
	{
		return string.Format(System.Composition.Hosting.Properties.Resources.ExportDescriptor_ToStringFormat, new object[2] { Contract, Origin });
	}
}
