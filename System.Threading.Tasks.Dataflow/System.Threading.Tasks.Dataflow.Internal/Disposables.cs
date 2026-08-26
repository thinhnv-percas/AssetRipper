using System.Diagnostics;

namespace System.Threading.Tasks.Dataflow.Internal;

internal sealed class Disposables
{
	[DebuggerDisplay("Disposed = true")]
	private sealed class NopDisposable : IDisposable
	{
		void IDisposable.Dispose()
		{
		}
	}

	[DebuggerDisplay("Disposed = {Disposed}")]
	private sealed class Disposable<T1, T2> : IDisposable
	{
		private readonly T1 m_arg1;

		private readonly T2 m_arg2;

		private Action<T1, T2> m_action;

		private bool Disposed => m_action == null;

		internal Disposable(Action<T1, T2> action, T1 arg1, T2 arg2)
		{
			m_action = action;
			m_arg1 = arg1;
			m_arg2 = arg2;
		}

		void IDisposable.Dispose()
		{
			Action<T1, T2> action = m_action;
			if (action != null && Interlocked.CompareExchange(ref m_action, null, action) == action)
			{
				action(m_arg1, m_arg2);
			}
		}
	}

	[DebuggerDisplay("Disposed = {Disposed}")]
	private sealed class Disposable<T1, T2, T3> : IDisposable
	{
		private readonly T1 m_arg1;

		private readonly T2 m_arg2;

		private readonly T3 m_arg3;

		private Action<T1, T2, T3> m_action;

		private bool Disposed => m_action == null;

		internal Disposable(Action<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3)
		{
			m_action = action;
			m_arg1 = arg1;
			m_arg2 = arg2;
			m_arg3 = arg3;
		}

		void IDisposable.Dispose()
		{
			Action<T1, T2, T3> action = m_action;
			if (action != null && Interlocked.CompareExchange(ref m_action, null, action) == action)
			{
				action(m_arg1, m_arg2, m_arg3);
			}
		}
	}

	internal static readonly IDisposable Nop = new NopDisposable();

	internal static IDisposable Create<T1, T2>(Action<T1, T2> action, T1 arg1, T2 arg2)
	{
		return new Disposable<T1, T2>(action, arg1, arg2);
	}

	internal static IDisposable Create<T1, T2, T3>(Action<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3)
	{
		return new Disposable<T1, T2, T3>(action, arg1, arg2, arg3);
	}
}
