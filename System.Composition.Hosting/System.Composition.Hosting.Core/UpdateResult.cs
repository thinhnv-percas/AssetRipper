using System.Collections.Generic;
using System.Linq;
using Microsoft.Internal;

namespace System.Composition.Hosting.Core;

internal class UpdateResult
{
	private static readonly ExportDescriptorPromise[] s_noPromises = EmptyArray<ExportDescriptorPromise>.Value;

	private readonly Queue<ExportDescriptorProvider> _remainingProviders;

	private readonly IList<ExportDescriptorPromise> _providedDescriptors = new List<ExportDescriptorPromise>();

	private ExportDescriptorPromise[] _results;

	public UpdateResult(IEnumerable<ExportDescriptorProvider> providers)
	{
		_remainingProviders = new Queue<ExportDescriptorProvider>(providers);
	}

	public bool TryDequeueNextProvider(out ExportDescriptorProvider provider)
	{
		if (_remainingProviders.Count == 0)
		{
			provider = null;
			return false;
		}
		provider = _remainingProviders.Dequeue();
		return true;
	}

	public void AddPromise(ExportDescriptorPromise promise)
	{
		_results = null;
		_providedDescriptors.Add(promise);
	}

	public ExportDescriptorPromise[] GetResults()
	{
		if (_results == null)
		{
			Microsoft.Internal.Assumes.IsTrue(_remainingProviders.Count == 0, "Providers remain to be queried.");
			if (_providedDescriptors.Count == 0)
			{
				_results = s_noPromises;
			}
			_results = _providedDescriptors.ToArray();
		}
		return _results;
	}
}
