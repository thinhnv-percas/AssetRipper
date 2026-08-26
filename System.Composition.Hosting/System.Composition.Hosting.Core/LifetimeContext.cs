using System.Collections.Generic;
using System.Composition.Hosting.Properties;
using System.Composition.Hosting.Util;
using System.Threading;
using Microsoft.Internal;

namespace System.Composition.Hosting.Core;

public sealed class LifetimeContext : CompositionContext, IDisposable
{
	private readonly LifetimeContext _root;

	private readonly LifetimeContext _parent;

	private readonly object _sharingLock = new object();

	private SmallSparseInitonlyArray _sharedPartInstances;

	private SmallSparseInitonlyArray _instancesUndergoingInitialization;

	private readonly object _boundPartLock = new object();

	private List<IDisposable> _boundPartInstances = new List<IDisposable>(0);

	private readonly string[] _sharingBoundaries;

	private readonly ExportDescriptorRegistry _partRegistry;

	private static int s_nextSharingId = -1;

	public static int AllocateSharingId()
	{
		return Interlocked.Increment(ref s_nextSharingId);
	}

	internal LifetimeContext(ExportDescriptorRegistry partRegistry, string[] sharingBoundaries)
	{
		_root = this;
		_sharingBoundaries = sharingBoundaries;
		_partRegistry = partRegistry;
	}

	internal LifetimeContext(LifetimeContext parent, string[] sharingBoundaries)
	{
		_parent = parent;
		_root = parent._root;
		_sharingBoundaries = sharingBoundaries;
		_partRegistry = parent._partRegistry;
	}

	public LifetimeContext FindContextWithin(string sharingBoundary)
	{
		if (sharingBoundary == null)
		{
			return _root;
		}
		for (LifetimeContext lifetimeContext = this; lifetimeContext != null; lifetimeContext = lifetimeContext._parent)
		{
			string[] sharingBoundaries = lifetimeContext._sharingBoundaries;
			foreach (string text in sharingBoundaries)
			{
				if (text == sharingBoundary)
				{
					return lifetimeContext;
				}
			}
		}
		throw ThrowHelper.CompositionException(string.Format(System.Composition.Hosting.Properties.Resources.Component_NotCreatableOutsideSharingBoundary, new object[1] { sharingBoundary }));
	}

	public void Dispose()
	{
		IEnumerable<IDisposable> enumerable = null;
		lock (_boundPartLock)
		{
			if (_boundPartInstances != null)
			{
				enumerable = _boundPartInstances;
				_boundPartInstances = null;
			}
		}
		if (enumerable == null)
		{
			return;
		}
		foreach (IDisposable item in enumerable)
		{
			item.Dispose();
		}
	}

	public void AddBoundInstance(IDisposable instance)
	{
		lock (_boundPartLock)
		{
			if (_boundPartInstances == null)
			{
				throw new ObjectDisposedException(ToString());
			}
			_boundPartInstances.Add(instance);
		}
	}

	public object GetOrCreate(int sharingId, CompositionOperation operation, CompositeActivator creator)
	{
		if (_sharedPartInstances != null && _sharedPartInstances.TryGetValue(sharingId, out var result))
		{
			return result;
		}
		operation.EnterSharingLock(_sharingLock);
		if (_sharedPartInstances == null)
		{
			_sharedPartInstances = new SmallSparseInitonlyArray();
			_instancesUndergoingInitialization = new SmallSparseInitonlyArray();
		}
		else if (_sharedPartInstances.TryGetValue(sharingId, out result))
		{
			return result;
		}
		if (_instancesUndergoingInitialization.TryGetValue(sharingId, out result))
		{
			return result;
		}
		result = creator(this, operation);
		_instancesUndergoingInitialization.Add(sharingId, result);
		operation.AddPostCompositionAction(delegate
		{
			_sharedPartInstances.Add(sharingId, result);
		});
		return result;
	}

	public override bool TryGetExport(CompositionContract contract, out object export)
	{
		if (!_partRegistry.TryGetSingleForExport(contract, out var defaultForExport))
		{
			export = null;
			return false;
		}
		export = CompositionOperation.Run(this, defaultForExport.Activator);
		return true;
	}

	public override string ToString()
	{
		if (_parent == null)
		{
			return "Root Lifetime Context";
		}
		if (_sharingBoundaries.Length == 0)
		{
			return "Non-sharing Lifetime Context";
		}
		return "Boundary for " + string.Join(", ", _sharingBoundaries);
	}
}
