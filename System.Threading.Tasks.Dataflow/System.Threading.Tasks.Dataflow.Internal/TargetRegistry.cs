using System.Collections.Generic;
using System.Diagnostics;

namespace System.Threading.Tasks.Dataflow.Internal;

[DebuggerTypeProxy(typeof(TargetRegistry<>.DebugView))]
[DebuggerDisplay("Count={Count}")]
internal sealed class TargetRegistry<T>
{
	internal sealed class LinkedTargetInfo
	{
		internal readonly ITargetBlock<T> Target;

		internal readonly bool PropagateCompletion;

		internal int RemainingMessages;

		internal LinkedTargetInfo Previous;

		internal LinkedTargetInfo Next;

		internal LinkedTargetInfo(ITargetBlock<T> target, DataflowLinkOptions linkOptions)
		{
			Target = target;
			PropagateCompletion = linkOptions.PropagateCompletion;
			RemainingMessages = linkOptions.MaxMessages;
		}
	}

	[DebuggerTypeProxy(typeof(TargetRegistry<>.NopLinkPropagator.DebugView))]
	[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
	private sealed class NopLinkPropagator : IPropagatorBlock<T, T>, ITargetBlock<T>, ISourceBlock<T>, IDataflowBlock, IDebuggerDisplay
	{
		private sealed class DebugView
		{
			private readonly NopLinkPropagator m_passthrough;

			public ITargetBlock<T> LinkedTarget => m_passthrough.m_target;

			public DebugView(NopLinkPropagator passthrough)
			{
				m_passthrough = passthrough;
			}
		}

		private readonly ISourceBlock<T> m_owningSource;

		private readonly ITargetBlock<T> m_target;

		Task IDataflowBlock.Completion => m_owningSource.Completion;

		private object DebuggerDisplayContent
		{
			get
			{
				IDebuggerDisplay debuggerDisplay = m_owningSource as IDebuggerDisplay;
				IDebuggerDisplay debuggerDisplay2 = m_target as IDebuggerDisplay;
				return string.Format("{0} Source=\"{1}\", Target=\"{2}\"", new object[3]
				{
					Common.GetNameForDebugger(this),
					(debuggerDisplay != null) ? debuggerDisplay.Content : m_owningSource,
					(debuggerDisplay2 != null) ? debuggerDisplay2.Content : m_target
				});
			}
		}

		object IDebuggerDisplay.Content => DebuggerDisplayContent;

		internal NopLinkPropagator(ISourceBlock<T> owningSource, ITargetBlock<T> target)
		{
			m_owningSource = owningSource;
			m_target = target;
		}

		DataflowMessageStatus ITargetBlock<T>.OfferMessage(DataflowMessageHeader messageHeader, T messageValue, ISourceBlock<T> source, bool consumeToAccept)
		{
			return m_target.OfferMessage(messageHeader, messageValue, this, consumeToAccept);
		}

		T ISourceBlock<T>.ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<T> target, out bool messageConsumed)
		{
			return m_owningSource.ConsumeMessage(messageHeader, this, out messageConsumed);
		}

		bool ISourceBlock<T>.ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<T> target)
		{
			return m_owningSource.ReserveMessage(messageHeader, this);
		}

		void ISourceBlock<T>.ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<T> target)
		{
			m_owningSource.ReleaseReservation(messageHeader, this);
		}

		void IDataflowBlock.Complete()
		{
			m_target.Complete();
		}

		void IDataflowBlock.Fault(Exception exception)
		{
			m_target.Fault(exception);
		}

		IDisposable ISourceBlock<T>.LinkTo(ITargetBlock<T> target, DataflowLinkOptions linkOptions)
		{
			throw new NotSupportedException(Resource.NotSupported_MemberNotNeeded);
		}
	}

	private sealed class DebugView
	{
		private readonly TargetRegistry<T> m_registry;

		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public ITargetBlock<T>[] Targets => m_registry.TargetsForDebugger;

		public DebugView(TargetRegistry<T> registry)
		{
			m_registry = registry;
		}
	}

	private readonly ISourceBlock<T> m_owningSource;

	private readonly Dictionary<ITargetBlock<T>, LinkedTargetInfo> m_targetInformation;

	private LinkedTargetInfo m_firstTarget;

	private LinkedTargetInfo m_lastTarget;

	private int m_linksWithRemainingMessages;

	internal LinkedTargetInfo FirstTargetNode => m_firstTarget;

	private int Count => m_targetInformation.Count;

	private ITargetBlock<T>[] TargetsForDebugger
	{
		get
		{
			ITargetBlock<T>[] array = new ITargetBlock<T>[Count];
			int num = 0;
			for (LinkedTargetInfo linkedTargetInfo = m_firstTarget; linkedTargetInfo != null; linkedTargetInfo = linkedTargetInfo.Next)
			{
				array[num++] = linkedTargetInfo.Target;
			}
			return array;
		}
	}

	internal TargetRegistry(ISourceBlock<T> owningSource)
	{
		m_owningSource = owningSource;
		m_targetInformation = new Dictionary<ITargetBlock<T>, LinkedTargetInfo>();
	}

	internal void Add(ref ITargetBlock<T> target, DataflowLinkOptions linkOptions)
	{
		if (m_targetInformation.TryGetValue(target, out var _))
		{
			target = new NopLinkPropagator(m_owningSource, target);
		}
		LinkedTargetInfo linkedTargetInfo = new LinkedTargetInfo(target, linkOptions);
		AddToList(linkedTargetInfo, linkOptions.Append);
		m_targetInformation.Add(target, linkedTargetInfo);
		if (linkedTargetInfo.RemainingMessages > 0)
		{
			m_linksWithRemainingMessages++;
		}
		DataflowEtwProvider log = DataflowEtwProvider.Log;
		if (log.IsEnabled())
		{
			log.DataflowBlockLinking(m_owningSource, target);
		}
	}

	internal bool Contains(ITargetBlock<T> target)
	{
		return m_targetInformation.ContainsKey(target);
	}

	internal void Remove(ITargetBlock<T> target, bool onlyIfReachedMaxMessages = false)
	{
		if (!onlyIfReachedMaxMessages || m_linksWithRemainingMessages != 0)
		{
			Remove_Slow(target, onlyIfReachedMaxMessages);
		}
	}

	private void Remove_Slow(ITargetBlock<T> target, bool onlyIfReachedMaxMessages)
	{
		if (!m_targetInformation.TryGetValue(target, out var value))
		{
			return;
		}
		if (!onlyIfReachedMaxMessages || value.RemainingMessages == 1)
		{
			RemoveFromList(value);
			m_targetInformation.Remove(target);
			if (value.RemainingMessages == 0)
			{
				m_linksWithRemainingMessages--;
			}
			DataflowEtwProvider log = DataflowEtwProvider.Log;
			if (log.IsEnabled())
			{
				log.DataflowBlockUnlinking(m_owningSource, target);
			}
		}
		else if (value.RemainingMessages > 0)
		{
			value.RemainingMessages--;
		}
	}

	internal LinkedTargetInfo ClearEntryPoints()
	{
		LinkedTargetInfo firstTarget = m_firstTarget;
		m_firstTarget = (m_lastTarget = null);
		m_targetInformation.Clear();
		m_linksWithRemainingMessages = 0;
		return firstTarget;
	}

	internal void PropagateCompletion(LinkedTargetInfo firstTarget)
	{
		Task completion = m_owningSource.Completion;
		for (LinkedTargetInfo linkedTargetInfo = firstTarget; linkedTargetInfo != null; linkedTargetInfo = linkedTargetInfo.Next)
		{
			if (linkedTargetInfo.PropagateCompletion)
			{
				Common.PropagateCompletion(completion, linkedTargetInfo.Target, Common.AsyncExceptionHandler);
			}
		}
	}

	internal void AddToList(LinkedTargetInfo node, bool append)
	{
		if (m_firstTarget == null && m_lastTarget == null)
		{
			m_firstTarget = (m_lastTarget = node);
		}
		else if (append)
		{
			node.Previous = m_lastTarget;
			m_lastTarget.Next = node;
			m_lastTarget = node;
		}
		else
		{
			node.Next = m_firstTarget;
			m_firstTarget.Previous = node;
			m_firstTarget = node;
		}
	}

	internal void RemoveFromList(LinkedTargetInfo node)
	{
		LinkedTargetInfo previous = node.Previous;
		LinkedTargetInfo next = node.Next;
		if (node.Previous != null)
		{
			node.Previous.Next = next;
			node.Previous = null;
		}
		if (node.Next != null)
		{
			node.Next.Previous = previous;
			node.Next = null;
		}
		if (m_firstTarget == node)
		{
			m_firstTarget = next;
		}
		if (m_lastTarget == node)
		{
			m_lastTarget = previous;
		}
	}
}
