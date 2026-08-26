using System.Collections.Generic;
using System.Threading;
using Microsoft.Internal;

namespace System.Composition.Hosting.Core;

public sealed class CompositionOperation : IDisposable
{
	private List<Action> _nonPrerequisiteActions;

	private List<Action> _postCompositionActions;

	private object _sharingLock;

	private CompositionOperation()
	{
	}

	public static object Run(LifetimeContext outermostLifetimeContext, CompositeActivator compositionRootActivator)
	{
		Microsoft.Internal.Requires.NotNull(outermostLifetimeContext, "outermostLifetimeContext");
		Microsoft.Internal.Requires.NotNull(compositionRootActivator, "compositionRootActivator");
		using CompositionOperation compositionOperation = new CompositionOperation();
		object result = compositionRootActivator(outermostLifetimeContext, compositionOperation);
		compositionOperation.Complete();
		return result;
	}

	public void AddNonPrerequisiteAction(Action action)
	{
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		if (_nonPrerequisiteActions == null)
		{
			_nonPrerequisiteActions = new List<Action>();
		}
		_nonPrerequisiteActions.Add(action);
	}

	public void AddPostCompositionAction(Action action)
	{
		Microsoft.Internal.Requires.NotNull(action, "action");
		if (_postCompositionActions == null)
		{
			_postCompositionActions = new List<Action>();
		}
		_postCompositionActions.Add(action);
	}

	internal void EnterSharingLock(object sharingLock)
	{
		Microsoft.Internal.Assumes.NotNull(sharingLock, "Sharing lock is required");
		if (_sharingLock == null)
		{
			_sharingLock = sharingLock;
			Monitor.Enter(sharingLock);
		}
		Microsoft.Internal.Assumes.IsTrue(_sharingLock == sharingLock, "Sharing lock already taken in this operation.");
	}

	private void Complete()
	{
		while (_nonPrerequisiteActions != null)
		{
			RunAndClearActions();
		}
		if (_postCompositionActions == null)
		{
			return;
		}
		foreach (Action postCompositionAction in _postCompositionActions)
		{
			postCompositionAction();
		}
		_postCompositionActions = null;
	}

	private void RunAndClearActions()
	{
		List<Action> nonPrerequisiteActions = _nonPrerequisiteActions;
		_nonPrerequisiteActions = null;
		foreach (Action item in nonPrerequisiteActions)
		{
			item();
		}
	}

	public void Dispose()
	{
		if (_sharingLock != null)
		{
			Monitor.Exit(_sharingLock);
		}
	}
}
